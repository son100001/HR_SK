CREATE PROCEDURE [dbo].[sp_BangMangThai]
	-- Add the parameters for the stored procedure here
	--exec [dbo].[sp_BangMangThai] '1990-1-1','2026-02-17',4,'VN',null,null,null,null,null,null,'C14813',null
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null,
	@ListOfID nvarchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ID int, @FD datetime,@TD datetime,@Remark nvarchar(max),@InsertDate datetime,@UserName nvarchar(50),@KiemTraDuLieuNhap nvarchar(max),@UltraPaper nvarchar(50),@UltraDate datetime,@PregWeeks float
			,@SoNgaySauKhiMangBauDuocHuongThaiSan int
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=Value from SetUp where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	if @TypeOfReport in(1,3,4,6) begin
		IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,empl.StartedDate,empl.ternimationdate
			,erp.UltraDate,erp.UltraPaper,erp.PregWeeks,erp.PregDays
			,erp.Fromdate,erp.MiscarriageDate,erp.ToDate
			,(case when erp.MiscarriageDate is null or erp.MiscarriageDate>isnull(cast(erp.Remark as datetime),DATEADD(DAY,@SoNgaySauKhiMangBauDuocHuongThaiSan,erp.Fromdate))
					then isnull(cast(erp.Remark as datetime),DATEADD(DAY,@SoNgaySauKhiMangBauDuocHuongThaiSan,erp.Fromdate))
				else null end) as NgayBatDauHuongCheDo
			,NghiSinh.Fromdate as NghiSinhTuNgay,NghiSinh.ToDate+1 as NgayDiLamLai
			--,datediff(day,NghiSinh.fromdate,NghiSinh.todate)/30 as SoThangNghiSinh
			--,datediff(day,NghiDS.fromdate,NghiDS.todate)+1 as SoNgayNghiDS
			--,NghiSinh.ToDate+isnull(datediff(day,NghiDS.fromdate,NghiDS.todate),0)+1 as NgayDiLamLaiSauNghiDS
			,f.BirthDate as NgaySinhEmBe
			,dateadd(year,1,f.BirthDate) as NgayEmBeTron1Tuoi
			,erp.Remark,erp.InsertDate,erp.UserName,erp.ID
			into #tab
		from 
		HR_EmployeeRegisPregnant erp
		left join
		[dbo].[udf_EmployeeFilter_Full](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on empl.Employee_ID COLLATE DATABASE_DEFAULT=erp.Employee_ID
		left join
		HR_EmployeeRegisMaternityLeave NghiSinh
		on erp.Employee_ID COLLATE DATABASE_DEFAULT=NghiSinh.Employee_ID and NghiSinh.Fromdate between erp.Fromdate and erp.ToDate+30 and NghiSinh.LeaveType_ID=24 and erp.MiscarriageDate is null
		left join
		HR_EmployeeRegisMaternityLeave NghiDS
		on erp.Employee_ID COLLATE DATABASE_DEFAULT=NghiDS.Employee_ID and NghiDS.Fromdate between erp.ToDate and dateadd(month,7,erp.ToDate) and NghiDS.LeaveType_ID IN (48,49) and erp.MiscarriageDate is null
		left join
		SmartBooks_Employee_Family f
		on erp.Employee_ID=f.Employee_ID and f.BirthDate between erp.Fromdate and erp.ToDate+30 and erp.MiscarriageDate is null
		where empl.Employee_ID is not null
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,erp.Fromdate
		
		--Nhập nghỉ khám thai vào
		alter table #tab add KhamThaiLan1 datetime
		alter table #tab add KhamThaiLan2 datetime
		alter table #tab add KhamThaiLan3 datetime
		alter table #tab add KhamThaiLan4 datetime
		alter table #tab add KhamThaiLan5 datetime
		--alter table #tab add NgayNghiSayThai datetime
		declare @Employee_ID nvarchar(50),@OLDEmployee_ID nvarchar(50),@LanKhamThu int,@NgayKhamThai datetime,@SQL nvarchar(max),@OLDID int
		DECLARE cur CURSOR FOR    
		select erp.ID,erml.Fromdate from
		#tab erp
		left join
		HR_EmployeeRegisMaternityLeave erml
		on erp.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and erml.Fromdate between erp.Fromdate and erp.ToDate and erml.LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where isNghiKhamThai=1)
		where erml.Employee_ID is not null
		order by erp.ID,erml.Fromdate
		OPEN  cur  
		FETCH NEXT FROM cur INTO @ID,@NgayKhamThai  
		WHILE @@FETCH_STATUS = 0    
		BEGIN
			if @OLDID is null or (@OLDID<>@ID) begin
				set @LanKhamThu=1
			end
			set @SQL='update #tab set KhamThaiLan'+cast(@LanKhamThu as varchar)+'='''+convert(varchar, @NgayKhamThai, 111)+'''where ID='+cast(@ID as varchar)
			set @OLDID=@ID
			set @LanKhamThu=@LanKhamThu+1
			exec (@SQL)
		FETCH NEXT FROM cur INTO @ID,@NgayKhamThai
		END 
		CLOSE cur    
		DEALLOCATE cur
		----Begin Nhập nghỉ sảy thai
		--update #tab set #tab.NgayNghiSayThai=erml.Fromdate
		--from
		--#tab t
		--inner join
		--HR_EmployeeRegisMaternityLeave erml
		--on t.Employee_ID=erml.Employee_ID and erml.LeaveType_ID=26 and erml.Fromdate between t.Fromdate and t.ToDate
		----END Nhập nghỉ sảy thai
		if @TypeOfReport=1 begin--danh sach thai san
			select * from #tab where Fromdate<=@todate and ToDate>=@fromdate
		end else if @TypeOfReport=3 begin-- danh sach huong che do ve som
			select * from #tab where NgayBatDauHuongCheDo<=@todate and todate>=@fromdate and (MiscarriageDate is null or MiscarriageDate>NgayBatDauHuongCheDo) and (ternimationdate is null or ternimationdate>@fromdate)
		end else if @TypeOfReport=4 begin-- all
			select * from #tab
		end else if @TypeOfReport=6 begin--@fromdate=1990-1-1 và @todate là ngày người dùng nhập vào
			select *,case when @todate>MiscarriageDate then N'Thai lưu'
							when @todate between NghiSinhTuNgay and NgayDiLamLai-1 then N'Nghỉ sinh'
							when @todate between NgaySinhEmBe and NgayEmBeTron1Tuoi-1 then N'Nuôi con nhỏ'
							when @todate>=NgayBatDauHuongCheDo and @todate<= isnull(MiscarriageDate,ToDate) then N'Chế độ mang thai được về sớm'
							else null end as TrangThai
							
			 from #tab where Fromdate<=@todate and ToDate>=@fromdate
		end
	end else if @TypeOfReport=2 begin--giao diện nhập theo mã nv
		select
		'' as DepartmentName, '' as SectionName, '' as TeamName, '' as PositionName,'' as PositionCategoryName
		,'' as FullName,'' as Employee_ID,@UltraPaper,@UltraDate,@PregWeeks,@FD as FromDate,@TD as ToDate,@Remark as Remark,@KiemTraDuLieuNhap as KiemTraDuLieuNhap,@InsertDate as InsertDate,@UserName as UserName
	end else if @TypeOfReport=5 begin-- in the ve som
			select 
			isnull(empl.TeamName,isnull(empl.sectionname,isnull(departmentname,isnull(empl.FactoryName,'')))) as Dept, empl.Position_ID, empl.PositionCategory_ID,emp.Picture
			,erp.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate,empl.ternimationdate
			,erp.UltraDate,erp.UltraPaper,erp.PregWeeks,erp.PregDays
			,erp.Fromdate,erp.ToDate,DATEADD(DAY,@SoNgaySauKhiMangBauDuocHuongThaiSan,erp.Fromdate) as NgayBatDauHuongCheDo,DATEADD(DAY,36*7,erp.Fromdate) as NgayNghiSinh,DATEADD(MONTH,6,DATEADD(DAY,36*7,erp.Fromdate))-1 as NghiSinhDenNgay,MiscarriageDate,erp.Remark,erp.InsertDate,erp.UserName,erp.ID
			from
			[dbo].[udf_EmployeeFilter](@LAN,null,null,null,null,null,null,null,isnull(@todate,GETDATE())) empl
			left join
			HR_EmployeeRegisPregnant erp
			on erp.Employee_ID COLLATE DATABASE_DEFAULT= empl.Employee_ID
			left join
			Smartbooks_Employee emp
			on empl.Employee_ID=emp.Employee_ID
			where erp.ID in (select [Data] from Split(@ListOfID,','))
	end else if @TypeOfReport=7 begin --In the con nho duoi 1 tuoi
		select empl.Employee_ID, dbo.udf_FullName(empl.Employee_FirstName,empl.Employee_LastName) as FullName, emf.BirthDate as NgaySinhCon, dateadd(year,1,emf.BirthDate) as NgayConTron1Tuoi
		from
		SmartBooks_Employee_Family emf
		left join
		SmartBooks_Employee empl
		on emf.Employee_ID = empl.Employee_ID
		where
		emf.RelatedName in ('6','7') and dateadd(year,1,emf.BirthDate) >= @fromdate and emf.BirthDate <= @todate
	end
END




GO
