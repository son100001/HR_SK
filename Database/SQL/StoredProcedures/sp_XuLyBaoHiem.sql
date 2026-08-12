CREATE PROCEDURE [dbo].[sp_XuLyBaoHiem]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_XuLyBaoHiem] 9,2019,1,'admin'
	@Month int,
	@Year int,
	@TypeOfReport int=1,
	@LAN nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @NgayBatDauBaoTangGiam datetime,@NgayKetThucBaoTangGiam datetime,@NgayDauThang datetime,@NgayCuoiThang datetime,@NgayDauThangTruoc datetime,@NgayCuoiThangTruoc datetime
		,@Employee_ID nvarchar(50),@TypeOfDe_Increase nvarchar(50)
	Declare @dNext datetime
	set @ngaydauthang=cast(@year as varchar)+'-'+cast(@month as varchar)+'-1'
	set @ngaycuoithang=dateadd(month,1,@ngaydauthang)-1
	set @NgayDauThangTruoc=DATEADD(month,-1,@NgayDauThang)
	set @NgayCuoiThangTruoc=@NgayDauThang-1
	set @NgayBatDauBaoTangGiam=dateadd(month,-1,@ngaydauthang)+15
	set @NgayKetThucBaoTangGiam=@ngaydauthang+14
	DECLARE @TangGiamBH TABLE
		(
			  Employee_ID nvarchar(50),
			  PhuongAn varchar(50),
			  LoaiKhaiBao varchar(50)
		)
	DECLARE @TangGiamBHThangTruoc TABLE
		(
			  Employee_ID nvarchar(50),
			  PhuongAn varchar(50),
			  LoaiKhaiBao varchar(50)
		)
    -- Insert statements for procedure here
	--BEGIN Lay trang thai tang giam hien tai cua nhan vien
	DECLARE @TrangThaiTangGiamHienTai TABLE
		(
			  Employee_ID nvarchar(50),
			  LoaiKhaiBao varchar(50)
		)
	insert into @TrangThaiTangGiamHienTai
	select id.Employee_ID,id.LoaiKhaiBao
	from
	(select Employee_ID,max(cast(Year_ as varchar)+'-'+cast(Month_ as varchar)+'-1') as NgayTangGiam from HR_IncreaseDecreaseInsurance where cast(Year_ as varchar)+'-'+cast(Month_ as varchar)+'-1'<=@NgayCuoiThang group by Employee_ID)as MaxTG
	left join
	HR_IncreaseDecreaseInsurance id
	on MaxTG.Employee_ID=id.Employee_ID and MaxTG.NgayTangGiam=cast(id.Year_ as varchar)+'-'+cast(id.Month_ as varchar)+'-1'

	--END Lay trang thai tang giam hien tai cua nhan vien

	--BEGIN dem so nghi khong dong bao hiem tháng hiện tại
	declare @DemSoNgayKhongDuocTinhLuongThangHienTai TABLE
	(
		Employee_ID nvarchar(50),
		SoNgayKhongDuocTinhLuong float
	)
	insert into @DemSoNgayKhongDuocTinhLuongThangHienTai
	select * from udf_DemSoNgayKhongDuocTinhLuong(@NgayDauThang,@NgayCuoiThang)
	--BEGIN dem so nghi khong dong bao hiem tháng hiện tại

	--BEGIN dem so nghi khong dong bao hiem thang truoc
	declare @DemSoNgayKhongDuocTinhLuongThangTruoc TABLE
	(
		Employee_ID nvarchar(50),
		SoNgayKhongDuocTinhLuong float
	)
	insert into @DemSoNgayKhongDuocTinhLuongThangTruoc
	select * from udf_DemSoNgayKhongDuocTinhLuong(@NgayDauThangTruoc,@NgayCuoiThangTruoc)
	--BEGIN dem so nghi khong dong bao hiem thang truoc

	if @TypeOfReport=1 begin--DANH SACH TANG BAO HIEM
		--BEGIN NHẬP BÁO TĂNG ĐỐI VỚI NGƯỜI MỚI VÀO
		insert into @TangGiamBH(Employee_ID,PhuongAn,LoaiKhaiBao)
		select employee_id,'TM','1' from smartbooks_employee where StartedDate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam and (TernimationDate is null or TernimationDate>@NgayKetThucBaoTangGiam)
		--END NHẬP BÁO TĂNG ĐỐI VỚI NGƯỜI MỚI VÀO
		
		--BEGIN Tăng TH nghỉ sinh quay lại
		insert into @TangGiamBH(Employee_ID,PhuongAn,LoaiKhaiBao)
		select Employee_ID,'ON' ,'1'from
		HR_EmployeeRegisMaternityLeave
		where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where [isMaternityLeave]=1) 
			and todate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam
			and Employee_ID in (select Employee_ID from HR_TimeKeeping_Data where Accessdate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam)
			and Employee_ID not in (select Employee_ID from SmartBooks_Employee where TernimationDate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam
									union select Employee_ID from HR_EmployeeRegisMaternityLeave where LeaveType_ID=28 and Fromdate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam)
			--and Employee_ID in (select Employee_ID from @TrangThaiTangGiamHienTai where isnull(isIncrease,0)=0)
		--END Tăng TH nghỉ sinh quay lại
		--BEGIN Tim nhung nguoi nghi khong luong dai ngay (nghi sinh, om dau) de bao tang
		--select * from HR_EmployeeRegisMaternityLeave where 
		--END Tim nhung nguoi nghi khong luong dai ngay (nghi sinh, om dau) de bao tang
	end else if @TypeOfReport=2 begin--DANH SACH GIAM BAO HIEM
		--BEGIN NHẬP BÁO GIẢM ĐỐI VỚI NGƯỜI NGHI SINH
		insert into @TangGiamBH(Employee_ID,PhuongAn,LoaiKhaiBao)
		select erml.Employee_ID,'TS','3'
		from
		HR_EmployeeRegisMaternityLeave erml
		left join
		@DemSoNgayKhongDuocTinhLuongThangHienTai nkl
		on erml.Employee_ID=nkl.Employee_ID
		where erml.LeaveType_ID=24
		and nkl.SoNgayKhongDuocTinhLuong>=14
		and erml.Fromdate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam
		and erml.Employee_ID in (select Employee_ID from @TrangThaiTangGiamHienTai where LoaiKhaiBao in (1,2,4))
		--END NHẬP BÁO GIẢM ĐỐI VỚI NGƯỜI NGHI SINH
		--BEGIN NHẬP BÁO GIẢM ĐỐI VỚI NGƯỜI THÔI VIỆC -SENDINGLETTER
		insert into @TangGiamBH(Employee_ID,PhuongAn,LoaiKhaiBao)
		select distinct Employee_ID,'GH','3' from
		(
			select Employee_ID from smartbooks_employee where ternimationdate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam
			union
			select Employee_ID from HR_EmployeeRegisMaternityLeave where Fromdate between @NgayBatDauBaoTangGiam and @NgayKetThucBaoTangGiam and LeaveType_ID='28'
		)gbh
		where gbh.Employee_ID in (select Employee_ID from @TrangThaiTangGiamHienTai where LoaiKhaiBao in (1,2,4))
		--END NHẬP BÁO GIẢM ĐỐI VỚI NGƯỜI THÔI VIỆC -SENDINGLETTER
		-- BEGIN BÁO GIẢM LÙI CỦA NGƯỜI KHÔNG ĐỦ CÔNG THÁNG TRƯỚC
		insert into @TangGiamBHThangTruoc (Employee_ID,PhuongAn,LoaiKhaiBao)
		select Employee_ID,'UnKnow','UnKnow' from @DemSoNgayKhongDuocTinhLuongThangTruoc where SoNgayKhongDuocTinhLuong>=14 and Employee_ID in (select Employee_ID from @TrangThaiTangGiamHienTai where LoaiKhaiBao in (1,2,4))
		-- END BÁO GIẢM LÙI CỦA NGƯỜI KHÔNG ĐỦ CÔNG THÁNG TRƯỚC
	end
	select empl.PositionFullName
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID
		,empl.StartedDate,empl.TernimationDate
		,@Month as Month_,@Year as Year_
		,tg.*,cast(@Year as varchar)+'-'+cast(@Month as varchar)+'-1' as NgayTangGiam,null as Remark
		from
		@TangGiamBH tg
		left join
		[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,@NgayCuoiThang) empl
		on tg.Employee_ID=empl.Employee_ID
END



GO
