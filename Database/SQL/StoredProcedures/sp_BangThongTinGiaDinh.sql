CREATE PROCEDURE [dbo].[sp_BangThongTinGiaDinh]
--exec [sp_BangThongTinGiaDinh] '2019-7-6','2019-7-6',4,null,null,null,null,null,null,null, '6072'
	--exec [dbo].[sp_BangThongTinGiaDinh] '2023-01-23','2023-08-23',7,'VN',NULL,NULL,NULL,NULL,NULL,NULL,'M00040,M00044,M00159,M00242,M00464,M00527,M00716,M00716,M00802,M00956,M00958,M01016,M01057,M01183,M01367'

	-- Add the parameters for the stored procedure here
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1:toàn bộ nhân viên,2:thông tin nhân viên trong giao diện chuyển vị trí
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp  nvarchar(50)=null,
	@ListOfID nvarchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan float
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
    -- Insert statements for procedure here
	IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
	select [dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullNameOfEmployee, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,empl.StartedDate,empl.ComStartedDate,empl.Employee_Status,empl.TernimationDate,empl.Sex as SexOfEmployee,ef.* into #tab from
	udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
	inner join
	SmartBooks_Employee_Family ef
	on empl.Employee_ID=ef.Employee_ID
	where empl.ComStartedDate<=@todate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
	if @TypeOfReport=1 begin--Xem all
		select * from #tab
	end else if @TypeOfReport=2 begin-- danh sách con nhỏ dưới 1 tuổi
		select * from udf_DanhSachConNhoDuoiNTuoi(1,@fromdate,@todate,'VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp)
	end else if @TypeOfReport=3 begin-- danh sách người phụ thuộc
		select * from #tab where DependFromMonth<=@todate and (DependToMonth is null or DependToMonth>=@fromdate)
	end else if @TypeOfReport=4 begin-- in thẻ về sớm
		select dshcd.Employee_ID, dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, isnull(dshcd.babyFromdate,dshcd.pregFromdate) as NgayVeSom
				, isnull(dshcd.babyTodate,dshcd.pregTodate) as NgayHetCheDo
				, case when dshcd.babyTodate is not null then N'Con nhỏ' when dshcd.pregFromdate is not null then N'Bầu' end as CheDo
				, empl.Picture
		from 
		udf_DanhSachHuongCheDo (@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) dshcd
		left join
		Smartbooks_Employee empl
		on dshcd.Employee_ID = empl.Employee_ID
		where (@ListOfID is null or empl.Employee_ID in (select [Data] from Split(@ListOfID,','))) and isnull(empl.TernimationDate,@todate) > @fromdate and isnull(empl.Sex,'Female') = 'Female'
	end else if @TypeOfReport=5 begin-- danh sách con nhỏ dưới 6 tuổi
		select * from udf_DanhSachConNhoDuoiNTuoi(6,@fromdate,@todate,'VN',@fact,@dept,@sect,@team,@pos,@posc,@Emp)
	end else if @TypeOfReport=7 begin --In the con nho duoi 1 tuoi
		select empl.Employee_ID, dbo.udf_FullName(empl.Employee_FirstName,empl.Employee_LastName) as FullName, emf.BirthDate as NgaySinhCon, dateadd(year,1,emf.BirthDate) as NgayConTron1Tuoi
		from
		SmartBooks_Employee_Family emf
		left join
		SmartBooks_Employee empl
		on emf.Employee_ID = empl.Employee_ID
		where
		emf.RelatedName in ('6','7') and dateadd(year,1,emf.BirthDate) >= @fromdate and emf.BirthDate <= @todate and emf.Employee_ID in (select Data from Split(@ListOfID,','))
	end else if @TypeOfReport = 8 begin
		--exec [dbo].[sp_BangThongTinGiaDinh] '2023-01-01','2023-01-31',8,NULL,NULL,NULL,NULL,NULL,NULL
		select ef.Employee_ID, dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName, erp.Fromdate as BatDauMangThai, erp.Todate as KetThucMangThai, dateadd(day,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,erp.Fromdate) as NgayVeCheDo, erml.Fromdate as NgayNghiThaiSan, erml.Todate as NgayQuayLaiThaiSan, round(datediff(day,erml.Fromdate,erml.ToDate)/30.0,0) as SoThangNghi, dateadd(year,1,ef.BirthDate) as NgayHetCheDoConNho, ef.*
		from 
		SmartBooks_Employee_Family ef
		left join
		udf_EmployeeFilter ('VN',@fact,@dept,@sect,@team,@pos,@posc,null,@todate) empl
		on ef.Employee_ID = empl.Employee_ID
		left join
		HR_EmployeeRegisPregnant erp
		on ef.Employee_ID = erp.Employee_ID and erp.ToDate >= dateadd(month,-12,ef.BirthDate)
		left join
		HR_EmployeeRegisMaternityLeave erml
		on ef.Employee_ID = erml.Employee_ID and erml.LeaveType_ID = 24 and erml.ToDate >= ef.BirthDate
		where dateadd(year,1,ef.BirthDate) >= @fromdate and isnull(empl.TernimationDate,@todate) > @fromdate and isnull(empl.Sex,'Female') = 'Female'
	end
END




GO
