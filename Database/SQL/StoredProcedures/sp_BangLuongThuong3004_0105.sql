CREATE PROCEDURE [dbo].[sp_BangLuongThuong3004_0105]
	-- Add the parameters for the stored procedure here
	-- exec sp_BangLuongThuong3004_0105 4,2020,1
	@month int,
	@year int,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @NgayCuoiThang datetime,@NgayTinhBienBan datetime,@NgayTinhThuong datetime,@SalaryKey varchar(50),@NgayKetThucTinhBienBan datetime
	if @TypeOfReport=1 begin--tính thưởng 30/4 - 1/5
		set @NgayTinhBienBan=datefromparts(@year,1,1)
		set @NgayKetThucTinhBienBan=datefromparts(@year,4,30)
		set @NgayTinhThuong=datefromparts(@year,4,30)
		set @SalaryKey='Thuong30040105'
	end else if @TypeOfReport=2 begin--tính thưởng 2/9
		set @NgayTinhBienBan=datefromparts(@year,5,1)
		set @NgayKetThucTinhBienBan=dateadd(day,-1,dateadd(month,1,datefromparts(@year,@month,1)))
		set @NgayTinhThuong=datefromparts(@year,9,2)
		set @SalaryKey='Thuong0209'
	end else if @TypeOfReport=3 begin--tính thưởng tháng 13
		set @NgayTinhBienBan=datefromparts(@year,1,1)
		set @NgayKetThucTinhBienBan=dateadd(day,-1,dateadd(month,1,datefromparts(@year,12,1)))
		set @NgayTinhThuong=dateadd(day,-1,dateadd(month,1,datefromparts(@year,12,1)))
		set @SalaryKey='ThuongThang13'
	end
	
	
	set @NgayCuoiThang=dateadd(day,-1,dateadd(month,1,datefromparts(@year,@month,1)))
	select
	@SalaryKey as SalaryKey,@month as Salary_Month,@year as Salary_Year,null as PayDate
	,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.PositionCategory_ID,empl.bankAccount,empl.startedDate,@NgayTinhThuong as NgayTinh,LuongTinhThuong.LuongTinhThuong as SalaryBasic
		,SoToBBKP.SoToBBKP,SoToBBKT.SoToBBKT
		,qtPIT.TongTNChiuThue-(GiamTruCaNhan+GiamGiaCanh+BHBatBuoc) as TongTNChiuThue
	from
	[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
	left join
	(
		select sc.Employee_ID,sum(isnull(Amount,0)) as LuongTinhThuong from
		(
			select Employee_ID, max([Fromdate]) as Fromdate,SalaryComponent from [dbo].[HR_SalaryComponent]
			where [Fromdate]<=@NgayCuoiThang and salarycomponent in (select salarycomponent from HR_SalaryComponentCategory where SalaryComponent in ('luongcoban','pctheoluong'))
			group by Employee_ID,SalaryComponent
		)scmax
		left join
		[dbo].[HR_SalaryComponent] sc
		on sc.Employee_ID=scmax.Employee_ID and scmax.Fromdate=sc.Fromdate and scmax.SalaryComponent=sc.SalaryComponent
		group by sc.Employee_ID
	) LuongTinhThuong
	on empl.Employee_ID=LuongTinhThuong.Employee_ID
	left join
	(
		select Employee_ID,sum(datediff(day,case when fromdate<=@NgayTinhBienBan then @NgayTinhBienBan else fromdate end,case when todate>@NgayKetThucTinhBienBan then @NgayKetThucTinhBienBan else todate end)+1-[dbo].[udf_CountSunDay](fromdate,todate)) as SoToBBKP
		from [dbo].[HR_EmployeeRegisMaternityLeave]
		where leavetype_id in (select leavetype_id from smartbooks_leavetype where NotAllow=1) and fromdate<=@NgayKetThucTinhBienBan and todate>=@NgayTinhBienBan
		group by Employee_ID
	)SoToBBKP
	on empl.Employee_ID=SoToBBKP.Employee_ID
	left join
	(
		select Employee_ID,count(Employee_ID) as SoToBBKT from [dbo].[HR_Discipline] where [DisciplineBegin] between @NgayTinhBienBan and @NgayKetThucTinhBienBan group by Employee_ID
	)SoToBBKT
	on empl.Employee_ID=SoToBBKT.Employee_ID
	left join
	[dbo].[udf_QuyetToanPITTheoThang](@month,@year) qtPIT
	on empl.Employee_ID=qtPIT.Employee_ID
	where empl.starteddate<=@NgayTinhThuong and (empl.ternimationdate is null or empl.ternimationdate>@NgayTinhThuong) and empl.factory_id not in ('TV03','TV05')
END



GO
