CREATE FUNCTION [dbo].[udf_QuyetToanPITTheoThang] 
(
	-- Add the parameters for the function here
	@Month int,
	@Year int
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),TongTNChiuThue float,PITDaKhauTru float,BHBatBuoc float,DependentPerson int,GiamGiaCanh float,GiamTruCaNhan float,primary key ([Employee_ID])

)
AS
BEGIN
	Declare @NgayTraLuong datetime,@NgayDauThang datetime,@NgayCuoiThang datetime
		,@GiamTruBanThan float,@GiamTruNguoiPhuThuoc float
	set @NgayDauThang=datefromparts(@Year,@month,1)
	set @NgayCuoiThang= dateadd(day,-1,dateadd(month,1,@NgayDauThang))
	select top (1) @GiamTruBanThan=value from [dbo].[HR_SetUpFollowDate] where code='GiamTruBanThan' and DATEFROMPARTS(@Year,@Month,1)>=Fromdate order by fromdate desc
	select top (1) @GiamTruNguoiPhuThuoc=value from [dbo].[HR_SetUpFollowDate] where code='GiamTruNguoiPhuThuoc' and DATEFROMPARTS(@Year,@Month,1)>=Fromdate order by fromdate desc
	insert into @rtnTable
	select ss.Employee_id
			,ss.s68--Thu nhập tính thuế trên bảng lương, số ngày có thể âm
			+isnull(depen.DependentPerson,0)*@GiamTruNguoiPhuThuoc+@GiamTruBanThan
			+isnull(ss.s67,0)-- Tiền BH bắt buộc
			+isnull(ssKhac.s54,0)-- các khoản thu nhập khác
			as TongTNChiuThue
			,ss.s51 as PITDaKhauTru
			,ss.s67 as BHBatBuoc
			,depen.DependentPerson
			,isnull(depen.DependentPerson,0)*@GiamTruNguoiPhuThuoc as GiamGiaCanh
			,@GiamTruBanThan as GiamTruCaNhan
		from
		SmartBooks_Salary ss
		left join
		(select Employee_ID,sum(case when [Key]='TruyThuPhepNam' then -1*isnull(s54,0) else isnull(s54,0) end) as s54 from SmartBooks_Salary where [Key] not in ('MonthlySalary','ResignSalary') and datepart(year,paydate)=@year and datepart(month,salary_month)=@month group by Employee_ID) ssKhac
		on ss.Employee_ID=ssKhac.Employee_ID
		left join
		(
			select Employee_ID,count(Employee_ID) as DependentPerson from HR_DanhSachNguoiPhuThuoc where DependFromMonth<=@NgayCuoiThang and (DependToMonth is null or DependToMonth>=@NgayDauThang) group by Employee_ID
		)depen
		on ss.Employee_ID=depen.Employee_ID
		where ss.[Key] in ('MonthlySalary','ResignSalary') and ss.salary_year=@Year and ss.salary_month=@month

	-- Return the result of the function
	RETURN

END



GO
