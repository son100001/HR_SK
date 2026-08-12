CREATE PROCEDURE [dbo].[sp_BangThongTinNhanVien]
	-- Add the parameters for the stored procedure here
	--exec sp_BangThongTinNhanVien '2026-06-30','2026-06-30',6,N'',N'',N'',N'',N'',N''
	@fromdate datetime,
	@todate datetime,
	@TypeOfReport int=1,--1:toàn bộ nhân viên,2:thông tin nhân viên trong giao diện chuyển vị trí
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Emp nvarchar(50)=null,
	@UserName nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int, @Year int
	select @SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	select @year = year(@fromdate)
	Declare @FOJan datetime, @EOJan datetime, @FOFeb datetime, @EOFeb datetime, @FOMar datetime, @EOMar datetime, @FOApr datetime, @EOApr datetime, @FOMay datetime, @EOMay datetime,
			@FOJun datetime, @EOJun datetime, @FOJul datetime, @EOJul datetime, @FOAug datetime, @EOAug datetime, @FOSep datetime, @EOSep datetime, @FOOct datetime, @EOOct datetime,
			@FONov datetime, @EONov datetime, @FODec datetime, @EODec datetime, @LFODec datetime, @LEODec datetime
			

	select @FOJan = cast(@Year as nvarchar(5)) + '-1-1', @EOJan = EOMONTH(@FOJan), @FOFeb = cast(@Year as nvarchar(5)) + '-2-1', @EOFeb = EOMONTH(@FOFeb), @FOMar = cast(@Year as nvarchar(5)) + '-3-1', @EOMar = EOMONTH(@FOMar), @FOApr = cast(@Year as nvarchar(5)) + '-4-1', @EOApr = EOMONTH(@FOApr)
			, @FOMay = cast(@Year as nvarchar(5)) + '-5-1', @EOMay = EOMONTH(@FOMay), @FOJun = cast(@Year as nvarchar(5)) + '-6-1', @EOJun = EOMONTH(@FOJun), @FOJul = cast(@Year as nvarchar(5)) + '-7-1', @EOJul = EOMONTH(@FOJul), @FOAug = cast(@Year as nvarchar(5)) + '-8-1', @EOAug = EOMONTH(@FOAug)
			, @FOSep = cast(@Year as nvarchar(5)) + '-9-1', @EOSep = EOMONTH(@FOSep), @FOOct = cast(@Year as nvarchar(5)) + '-10-1', @EOOct = EOMONTH(@FOOct), @FONov = cast(@Year as nvarchar(5)) + '-11-1', @EONov = EOMONTH(@FONov), @FODec = cast(@Year as nvarchar(5)) + '-12-1', @EODec = EOMONTH(@FODec)
			, @LFODec = cast(@Year-1 as nvarchar(5)) + '-12-1', @LEODec = EOMONTH(@LFODec)

	
	IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
	select empl.*,[dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullName
			,CASE
				WHEN isTrucTiep=1 THEN N'Trực Tiếp'
				WHEN isTrucTiep=0 THEN N'Gián tiếp'
				ELSE NULL 
			END AS LoaiCV
			,CASE WHEN Employee_Status in ('Hiring','Incumbent') or Employee_Status is null THEN 'Active' ELSE 'Terminated' END AS TinhTrangNV
            --,CASE WHEN TonGiao IS NULL THEN N'Không' ELSE TonGiao END AS TonGiao
	into #tab
	FROM
	[dbo].[udf_EmployeeFilter_Full](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
	/*left join--Tàn tật
	(
		select d.* from
		(select Employee_ID,max(Fromdate) as Fromdate from HR_Disable where Todate is null or Todate>=GETDATE() group by Employee_ID)maxTanTat
		left join
		HR_Disable d
		on maxTanTat.Employee_ID=d.Employee_ID and maxTanTat.Fromdate=d.Fromdate
	)d
	on empl.Employee_ID=d.Employee_ID
	--left join
	--[dbo].[udf_TongHopHopDongLaoDong]('1900-1-1',isnull(@todate,getdate()),@fact,@dept,@sect,@team,@pos,@posc,@Emp) hd
	--on empl.Employee_ID=hd.Employee_ID
	left join
	udf_DanhSachHuongCheDo(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan) cdo
	on empl.Employee_ID = cdo.Employee_ID --and ((cdo.pregFromdate between @fromdate and @todate) or (cdo.pregTodate between @fromdate and @todate) or (cdo.babyFromdate between @fromdate and @todate) or (cdo.babyFromdate between @fromdate and @todate))
	--where hdts.CL_RegisterDate < ta.PlanTernimationDate or ta.PlanTernimationDate = null
	left join
	[dbo].[udf_DanhSachNgayChuyenViTri_Horizontal]('Position',null) ncvt
	on empl.Employee_ID=ncvt.Employee_ID
	*/
	order by Employee_Status,Employee_ID asc

	if @TypeOfReport=1
	BEGIN--toàn bộ nhân viên
		select *
		from
		#tab
		order by OrderBy
	END
	
	
	ELSE if @TypeOfReport=2
	BEGIN--thông tin nhân viên trong giao diện chuyển vị trí
		select Employee_ID,[dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullName,StartedDate,Factory_ID,DepartmentCode,SectionCode,TeamCode,Position_ID,PositionCategory_ID,ChucDanh,JobCode
		from [dbo].[udf_EmployeeFilter_Full](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate()))
		where (case when @Emp is null or @Emp='' then '' else Employee_ID end)=(case when @Emp is null or @Emp='' then '' else @Emp end)
			and TernimationDate is null
		order by OrderBy
	end 
	
	
	ELSE if @TypeOfReport=3
	BEGIN--nhân viên mới vào
		select *
		FROM #tab
		WHERE ComStartedDate between @fromdate and @todate
		order by OrderBy
	END
	
	
	ELSE if @TypeOfReport=4
	BEGIN--nhân viên thôi việc		

		select 
			empl.Employee_ID
            ,empl.Employee_Firstname,empl.Employee_LastName
			,dbo.udf_FullName(Employee_Firstname,Employee_LastName) AS FullName
            ,empl.StartedDate,empl.OfficialDate
			,empl.Position_ID, NULL AS DepCode
			,empl.PositionCategory_ID
			,CASE
				WHEN isTrucTiep=1 THEN N'Trực Tiếp'
				WHEN isTrucTiep=0 THEN N'Gián tiếp'
				ELSE NULL 
			END AS LoaiCV
			,empl.Factory_ID

			,empl.Qualification,empl.BirthDate,empl.BirthPlace
			,empl.Sex
			,empl.ID_number,empl.ID_date,empl.ID_place
            ,empl.NativePlace   
            ,CASE WHEN TonGiao IS NULL THEN N'Không' ELSE TonGiao END AS TonGiao
            ,NULL AS DanToc
			,empl.Nationality
			
			,empl.Address_Permanent, NULL AS SoNha_ThuongTru
			,empl.Tinh_TP_ThuongTru,empl.Huyen_ThiXa_ThuongTru, empl.Xa_Phuong_ThuongTru
			,empl.Address_Temporary
			
			,empl.Tel,empl.BankAccount,empl.MaSoThue
			,CASE WHEN Employee_Status in ('Hiring','Incumbent') or Employee_Status is null THEN 'Active' ELSE 'Terminated' END AS TinhTrangNV
			
			,empl.TernimationDate,empl.NgayNopDon,empl.LyDoNghi,empl.NgayQuyetDinh
			
			,NULL AS SYLL, NULL AS KS, NULL AS DXV, NULL as	KSK
			,NULL AS HoKhau, NULL AS BangCap, NULL AS Anh, NULL AS HanhKiem

			,NULL AS KhongChamCong
			,NULL AS KhongTangCa
			,NULL AS KhongTinh13    
			,empl.DepartmentCode1
			,empl.FactoryName
			,empl.DepartmentName
			,empl.SectionName
			,empl.ChucDanhName
			,empl.SoNhaThonXom, empl.PhuongXa, empl.QuanHuyen, empl.TinhThanhPho 
		FROM
		dbo.udf_EmployeeFilter_Full('VN',@fact,@dept,@sect,@team,@pos,@posc,NULL,@fromdate) empl
		LEFT JOIN
        dbo.SmartBooks_Department dep
		ON empl.DepartmentCode=dep.Factory_ID+'_'+dep.DepartmentCode
		WHERE TernimationDate >= @fromdate and TernimationDate <= @todate
		order by empl.OrderBy
	END
	
	
	ELSE if @TypeOfReport=5
	BEGIN
		SELECT empl.*
		from
		#tab empl
		left join
		udf_BangPhep(@fromdate,@todate,@emp) erml
		on empl.Employee_ID COLLATE DATABASE_DEFAULT=erml.Employee_ID and DATEADD(YEAR,DATEPART(YEAR,@fromdate)-DATEPART(YEAR,empl.BirthDate),empl.BirthDate) between erml.Fromdate and isnull(erml.ToDate,isnull(erml.NgayDuKienQuayLai,erml.Fromdate))
		where 
		(
			DATEADD(YEAR,DATEPART(YEAR,@fromdate)-DATEPART(YEAR,empl.BirthDate),empl.BirthDate) between @fromdate and @todate
			or DATEADD(YEAR,DATEPART(YEAR,@todate)-DATEPART(YEAR,empl.BirthDate),empl.BirthDate) between @fromdate and @todate
		)
		and
		(
			DATEADD(YEAR,DATEPART(YEAR,@fromdate)-DATEPART(YEAR,empl.BirthDate),empl.BirthDate)>=empl.ComStartedDate
		)
		and
		(
			empl.TernimationDate is null
			or
			(
				@todate<empl.TernimationDate
			)
		)
		and empl.ComStartedDate is not null
		order by empl.OrderBy
	END
	
	
	ELSE if @TypeOfReport =6
	BEGIN--nhân viên đang làm việc
		select 
			empl.Employee_ID
            ,empl.Employee_Firstname,empl.Employee_LastName
			,dbo.udf_FullName(Employee_Firstname,Employee_LastName) AS FullName
            ,empl.StartedDate,empl.OfficialDate
			,empl.Position_ID, NULL AS DepCode
			,empl.PositionCategory_ID
			,CASE
				WHEN isTrucTiep=1 THEN N'Trực Tiếp'
				WHEN isTrucTiep=0 THEN N'Gián tiếp'
				ELSE NULL 
			END AS LoaiCV
			,empl.Factory_ID

			,empl.Qualification,empl.BirthDate,empl.BirthPlace
			,empl.Sex
			,empl.ID_number,empl.ID_date,empl.ID_place
            ,empl.NativePlace   
            ,CASE WHEN TonGiao IS NULL THEN N'Không' ELSE TonGiao END AS TonGiao
            ,empl.Nation
			,empl.Nationality
			
			,empl.Address_Permanent, NULL AS SoNha_ThuongTru
			,empl.Tinh_TP_ThuongTru,empl.Huyen_ThiXa_ThuongTru, empl.Xa_Phuong_ThuongTru
			,empl.Address_Temporary
			
			,empl.Tel,empl.BankAccount,empl.MaSoThue
			,CASE WHEN Employee_Status in ('Incumbent','Incumbent') or Employee_Status is null THEN 'Active' ELSE 'Terminated' END AS TinhTrangNV
			
			,empl.TernimationDate,empl.NgayNopDon,empl.LyDoNghi,empl.NgayQuyetDinh
			
			,NULL AS SYLL, NULL AS KS, NULL AS DXV, NULL as	KSK
			,NULL AS HoKhau, NULL AS BangCap, NULL AS Anh, NULL AS HanhKiem

			,NULL AS KhongChamCong
			,NULL AS KhongTangCa
			,NULL AS KhongTinh13
			,empl.DepartmentCode1
			,empl.FactoryName
			,empl.DepartmentName
			,empl.SectionName
			,empl.ChucDanhName
			,empl.SoNhaThonXom, empl.PhuongXa, empl.QuanHuyen, empl.TinhThanhPho
			
		FROM dbo.udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,NULL,@fromdate) empl
		LEFT JOIN
        dbo.SmartBooks_Department dep
		ON empl.DepartmentCode=dep.Factory_ID+'_'+dep.DepartmentCode
		WHERE ComStartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate)
		order by empl.OrderBy
	END
	
	
	ELSE if @TypeOfReport=7
	BEGIN--Nhân viên Hiring
		select *
		FROM dbo.udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,NULL,@fromdate) empl
		WHERE Employee_Status='Hiring' and ComStartedDate between @fromdate and @todate
	END
	
	
	ELSE if @TypeOfReport=8
	BEGIN--nhân viên đang làm việc không bao gồm phép
		select * 
		from #tab left join
		[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,null) ctl
		on #tab.Employee_ID=ctl.Employee_ID
		where ComStartedDate<=@todate and (TernimationDate is null 
		or TernimationDate>@fromdate) and #tab.Employee_ID not in (select Employee_ID from udf_BangPhep(@fromdate,@todate,@emp) where LeaveType_ID not in (31,32))
		order by OrderBy
	end 
	
	
	ELSE if @TypeOfReport=9 
	BEGIN--nhân viên đang làm việc bao gồm phép
		select * 
		from #tab left join
		[dbo].[udf_HopDongTuSinh](@fromdate,@todate,1,@LAN,@fact,@dept,@sect,@team,@pos,@posc,null) ctl
		on #tab.Employee_ID=ctl.Employee_ID
		where ComStartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate) and #tab.Employee_ID not in (select Employee_ID from [dbo].[HR_EmployeeRegisMaternityLeave] where LeaveType_ID = '28' and @fromdate between fromdate and todate)
		order by OrderBy
	END
	
	
	ELSE if @TypeOfReport=10
	BEGIN --daily report
		--exec sp_BangThongTinNhanVien '2021-4-14','2021-4-14',10,N'',N'',N'',N'',N'',N''
		declare @tabDailyReport as table (DepartmentName nvarchar(100),SectionName nvarchar(100),NameEN nvarchar(50),Group_ nvarchar(50),SoNVHQ int,HN_VM int,HN_NV int,HN_Tong int,GT_Nam int,GT_Nu int,GT_Tong int,VM_CP int,VM_KP int,VM_NCL int,VM_Tong int,DiLAMTT int,OrderBy int)
		
		insert into @tabDailyReport(/*DepartmentName,*/SectionName,NameEN,Group_,SoNVHQ,HN_VM,HN_NV,GT_Nam,VM_CP,VM_KP,VM_NCL,OrderBy)
		select N'관리_관리자_관리팀 QLVP',sect.SectionName_EN, sect.Group_
			,sum(case when StartedDate<=@fromdate-1 and (TernimationDate is null or TernimationDate>=@fromdate) then 1 else 0 end) as SoNVHQ
			,sum(case when StartedDate=@fromdate and empl.Factory_ID='VP' then 1 else 0 end) as HN_VM
			,sum(case when TernimationDate=@fromdate then 1 else 0 end) as HN_NV
			,sum(case when sex='Male' and (TernimationDate is null or TernimationDate>=@fromdate) then 1 else 0 end) as GT_Nam
			,sum(case when phep.Employee_ID is not null and isnull(lt.NotAllow,0)=0 and isnull(lt.isLeave_ComPay,0)=1 then 1 else 0 end) as VM_CP
			,sum(case when phep.Employee_ID is not null and isnull(lt.NotAllow,0)=1 then 1 else 0 end) as VM_KP
			,sum(case when phep.Employee_ID is not null and isnull(lt.isLeave_ComPay,0)=1 then 1 else 0 end) as VM_NCL
			,sect.OrderBy
		from
		udf_EmployeeFilter_Full(@LAN,null,null,null,null,null,null,null,@fromdate) empl
		left join
		udf_BangPhepTheoNgay(1,@fromdate,@fromdate,null,null,null,null,null,null,null,null) phep
		on empl.Employee_ID=phep.Employee_ID and empl.StartedDate<=@fromdate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
		left join
		SmartBooks_LeaveType lt
		on phep.LeaveType_ID=lt.LeaveType_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
		where empl.SectionCode like N'%QL%'
		group by sect.SectionName_EN, sect.Group_,sect.OrderBy
		
		insert into @tabDailyReport(DepartmentName,SectionName,NameEN,Group_,SoNVHQ,HN_VM,HN_NV,GT_Nam,VM_CP,VM_KP,VM_NCL,OrderBy)
		select DepartmentName,SectionName,sect.SectionName_EN, sect.Group_
			,sum(case when StartedDate<=@fromdate-1 and (TernimationDate is null or TernimationDate>=@fromdate) then 1 else 0 end) as SoNVHQ
			,sum(case when StartedDate=@fromdate and empl.Factory_ID='VP' then 1 else 0 end) as HN_VM
			,sum(case when TernimationDate=@fromdate then 1 else 0 end) as HN_NV
			,sum(case when sex='Male' and (TernimationDate is null or TernimationDate>=@fromdate) then 1 else 0 end) as GT_Nam
			,sum(case when phep.Employee_ID is not null and isnull(lt.NotAllow,0)=0 and isnull(lt.isLeave_ComPay,0)=1 then 1 else 0 end) as VM_CP
			,sum(case when phep.Employee_ID is not null and isnull(lt.NotAllow,0)=1 then 1 else 0 end) as VM_KP
			,sum(case when phep.Employee_ID is not null and isnull(lt.isLeave_ComPay,0)=1 then 1 else 0 end) as VM_NCL
			,sect.OrderBy
		from
		udf_EmployeeFilter_Full(@LAN,null,null,null,null,null,null,null,@fromdate) empl
		left join
		udf_BangPhepTheoNgay(1,@fromdate,@fromdate,null,null,null,null,null,null,null,null) phep
		on empl.Employee_ID=phep.Employee_ID and empl.StartedDate<=@fromdate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
		left join
		SmartBooks_LeaveType lt
		on phep.LeaveType_ID=lt.LeaveType_ID
		left join
		SmartBooks_Section sect
		on empl.SectionCode=sect.Factory_ID+'_'+sect.DepartmentCode+'_'+sect.SectionCode
		where empl.SectionCode not like N'%QL%'
		group by sect.SectionName_EN, sect.Group_,DepartmentName,SectionName,sect.OrderBy
		update @tabDailyReport set HN_Tong=SoNVHQ+HN_VM-HN_NV
							,GT_Tong=SoNVHQ+HN_VM-HN_NV
							,GT_Nu=SoNVHQ+HN_VM-HN_NV-GT_Nam
							,VM_Tong=VM_CP+VM_KP+VM_NCL
							,DiLAMTT=SoNVHQ+HN_VM-HN_NV
										-(VM_CP+VM_KP+VM_NCL)--VM_Tong
		select * from @tabDailyReport order by group_ asc
	END
	
	
	ELSE if @TypeOfReport=11
	BEGIN -- TK ngân hàng vs Lương
		SELECT
			empl.Employee_ID
			,dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) as FullName
			,empl.StartedDate,empl.TernimationDate,empl.LyDoNghi
			,case when empl.Employee_Status='Terminated' and empl.TernimationDate between @fromdate and @todate then 'Terminated' else 'Active' end as Employee_Status
			,empl.Factory_ID
			,case when empl.Employee_Status='Terminated' and empl.TernimationDate between @fromdate and @todate then 'Quit' else empl.Position_ID end as SectionCode
			,CASE WHEN empl.isTrucTiep=1 THEN N'Trực Tiếp' ELSE N'Gián tiếp' END  AS TeamCode
			,empl.PositionCategory_ID
			,NULL as NotCheckInOut,null as KhongTinh13
			,empl.ID_number,ID_date
			,CASE WHEN ISNULL(empl.BankAccount,'') <>'' then empl.BankAccount else N'TienMat' end as BankAccount

		from 
		dbo.udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@pos,NULL,@todate) empl
		where  empl.StartedDate<=@todate
		and (empl.TernimationDate is null or empl.TernimationDate>=@fromdate)
		ORDER BY empl.OrderBy


	end

	--exec sp_BangThongTinNhanVien '2025-09-01', '2025-09-30', 17
	ELSE if @TypeOfReport in (12,16,17)
	BEGIN--nhân viên đang làm việc
		select t.Employee_ID, [dbo].[udf_FullName](t.[Employee_Firstname],t.Employee_LastName) as FullName,t.StartedDate,t.Employee_Status,t.TernimationDate
		,t.FactoryName,t.DepartmentName,t.SectionName,t.TeamName,t.PositionName,t.PositionCategoryName, t.Tel, t.ID_number, t.ID_date, t.ID_place, t.Address_Permanent, t.DepartmentCode1
		, dep.OrderBy, dep.Factory_ID, dep.DepartmentCode
		from
		#tab t
		left join
		SmartBooks_Department dep
		on t.FactoryName = dep.Factory_ID and t.DepartmentName = dep.DepartmentCode
		left join
		SmartBooks_Section sec
		on t.FactoryName = sec.Factory_ID and t.DepartmentName = sec.DepartmentCode and t.SectionName = sec.SectionCode
		left join
		udf_TongHopCong (@fromdate,@todate,1,@UserName) thc
		on t.Employee_ID = thc.Employee_ID
		left join
		udf_TongHopPhep (@fromdate,@todate,1) thp
		on t.Employee_ID = thp.Employee_ID
		where ComStartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate) 
				and isnull(thc.wt1,0) + isnull(thc.wt9,0) + isnull(thp.PhepHuongLuong,0) > 0
				and (
						(
							@TypeOfReport = 16 and isnull(t.FactoryName,'') <> 'SK2'
						) 
						or
						(
							@TypeOfReport = 17 and isnull(t.FactoryName,'') = 'SK2'
						) 
						or
						@TypeOfReport = 12
					)
		order by isnull(dep.OrderBy,200), isnull(sec.SectionCode,'z'), t.Employee_ID
	END
	
	
	ELSE if @TypeOfReport=13
	BEGIN -- bảng tách địa chỉ
		select Position,Employee_ID,[dbo].[udf_FullName](Employee_Firstname,Employee_LastName) as FullName
		,[dbo].[udf_LayQuanHuyen](Address_Permanent,1) as ThonXomThuongTru
		,[dbo].[udf_LayQuanHuyen](Address_Permanent,2) as XaPhuongThuongTru
		,[dbo].[udf_LayQuanHuyen](Address_Permanent,3) as QuanHuyenThuongTru
		,[dbo].[udf_LayQuanHuyen](Address_Permanent,4) as TinhTPThuongTru
		,[dbo].[udf_LayQuanHuyen](Address_Temporary,1) as ThonXomTamTru
		,[dbo].[udf_LayQuanHuyen](Address_Temporary,2) as XaPhuongTamTru
		,[dbo].[udf_LayQuanHuyen](Address_Temporary,3) as QuanHuyenTamTru
		,[dbo].[udf_LayQuanHuyen](Address_Temporary,4) as TinhTPTamTru
		,LEFT(RIGHT(hc.NameVN,LEN(hc.NameVN)-CHARINDEX('(',hc.NameVN)),LEN(RIGHT(hc.NameVN,LEN(hc.NameVN)-CHARINDEX('(',hc.NameVN)))-1) as HazardLevel
		from
		[dbo].[udf_EmployeeFilter_Full](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,getdate())) empl
		left join
		HR_HazardCategory hc
		on empl.HAZARD=hc.HAZARD
		where ComStartedDate<=@todate and (TernimationDate is null or TernimationDate>@fromdate)
	END
	
	
	ELSE if @TypeOfReport=14
	BEGIN
		declare @Dauky table (Total float, FemaleEmpl float, Bangnghe float, Socapnghe float, TrungCap float, CaoDang float, DaiHoc float, HDVTH float, HD1NAM float, HDTV float)
		declare @SoTang table (Total float, FemaleEmpl float, Bangnghe float, Socapnghe float, TrungCap float, CaoDang float, DaiHoc float, HDVTH float, HD1NAM float, HDTV float)
		declare @SoGiam table (Total float, FemaleEmpl float, Bangnghe float, Socapnghe float, TrungCap float, CaoDang float, DaiHoc float, HDVTH float, HD1NAM float, HDTV float)

		declare @dkTotal float, @dkFemaleEmpl float, @dkBangnghe float, @dkSocapnghe float, @dkTrungCap float, @dkCaoDang float, @dkDaiHoc float, @dkHDVTH float, @dkHD1NAM float, @dkHDTV float
				, @stTotal float, @stFemaleEmpl float, @stBangnghe float, @stSocapnghe float, @stTrungCap float, @stCaoDang float, @stDaiHoc float, @stHDVTH float, @stHD1NAM float, @stHDTV float
				, @sgTotal float, @sgFemaleEmpl float, @sgBangnghe float, @sgSocapnghe float, @sgTrungCap float, @sgCaoDang float, @sgDaiHoc float, @sgHDVTH float, @sgHD1NAM float, @sgHDTV float

		-- Du lieu dau ky
		insert into @Dauky
		/*select (case when Sex = 'Female' then 1 else 0 end) as FemaleEmpl, (case Graduated when 'BangNghe' then 1 when 'Socapnghe' then 2 when 'TrungCap' then 3 when 'CaoDang' then 4 when 'DaiHoc' then 5 else 0 end) as Graduated
				, (case hdts.[Type] when 'HDVTH' then 1 when 'HD1NAM' then 2 when 'PLHD' then 4 else 3 end) as ContractType*/
		select count(empl.Employee_ID) as Total, sum(case when Sex = 'Female' then 1 else 0 end) as dkFemaleEmpl, sum(case when Graduated = 'Bangnghe' then 1 else 0 end) as Bangnghe, sum(case when Graduated = 'Socapnghe' then 1 else 0 end) as Socapnghe
			, sum(case when Graduated = 'TrungCap' then 1 else 0 end) as TrungCap, sum(case when Graduated = 'CaoDang' then 1 else 0 end) as CaoDang, sum(case when Graduated = 'DaiHoc' then 1 else 0 end) as DaiHoc
			, sum(case when hdts.[Type] = 'HDVTH' then 1 else 0 end) as HDVTH, sum(case when hdts.[Type] like 'HD1NAM%' then 1 else 0 end) as HD1NAM, sum(case when hdts.[Type] like 'HDTV%' then 1 else 0 end) as HDTV
		from udf_EmployeeFilter_Full (@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@fromdate) empl
		left join
		udf_HopDongTuSinh ('1900-1-1',@fromdate,1,@LAN,null,null,null,null,null,null,null) hdts
		on hdts.Employee_ID = empl.Employee_ID
		left join
		(
			select Employee_ID, MAX(CL_RegisterDate) as MaxCL_RegisterDate from udf_HopDongTuSinh ('1900-1-1',@fromdate,1,@LAN,null,null,null,null,null,null,null) group by Employee_ID
		) hdtsMax
		on hdts.Employee_ID = hdtsMax.Employee_ID and hdts.CL_RegisterDate = hdtsMax.MaxCL_RegisterDate
		where StartedDate < @fromdate and ISNULL(TernimationDate,'2099-1-1') > @todate

		--Du lieu Tang trong ky
		insert into @SoTang
		/*select (case when Sex = 'Female' then 1 else 0 end) as FemaleEmpl, (case Graduated when 'BangNghe' then 1 when 'Socapnghe' then 2 when 'TrungCap' then 3 when 'CaoDang' then 4 when 'DaiHoc' then 5 else 0 end) as Graduated
				, (case hdts.[Type] when 'HDVTH' then 1 when 'HD1NAM' then 2 when 'PLHD' then 4 else 3 end) as ContractType*/
		select count(empl.Employee_ID) as dkTotal, sum(case when Sex = 'Female' then 1 else 0 end) as dkFemaleEmpl, sum(case when Graduated = 'Bangnghe' then 1 else 0 end) as dkBangnghe, sum(case when Graduated = 'Socapnghe' then 1 else 0 end) as dkSocapnghe
			, sum(case when Graduated = 'TrungCap' then 1 else 0 end) as dkTrungCap, sum(case when Graduated = 'CaoDang' then 1 else 0 end) as dkCaoDang, sum(case when Graduated = 'DaiHoc' then 1 else 0 end) as dkDaiHoc
			, sum(case when hdts.[Type] = 'HDVTH' then 1 else 0 end) as dkHDVTH, sum(case when hdts.[Type] like 'HD1NAM%' then 1 else 0 end) as dkHD1NAM, sum(case when hdts.[Type] like 'HDTV%' then 1 else 0 end) as dkHDTV
		from udf_EmployeeFilter_Full (@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@fromdate) empl
		left join
		udf_HopDongTuSinh ('1900-1-1',@fromdate,1,@LAN,null,null,null,null,null,null,null) hdts
		on hdts.Employee_ID = empl.Employee_ID
		left join
		(
			select Employee_ID, MAX(CL_RegisterDate) as MaxCL_RegisterDate from udf_HopDongTuSinh ('1900-1-1',@fromdate,1,@LAN,null,null,null,null,null,null,null) group by Employee_ID
		) hdtsMax
		on hdts.Employee_ID = hdtsMax.Employee_ID and hdts.CL_RegisterDate = hdtsMax.MaxCL_RegisterDate
		where StartedDate between @fromdate and @todate

		--Du lieu Giam trong ky
		insert into @SoGiam
		/*select (case when Sex = 'Female' then 1 else 0 end) as FemaleEmpl, (case Graduated when 'BangNghe' then 1 when 'Socapnghe' then 2 when 'TrungCap' then 3 when 'CaoDang' then 4 when 'DaiHoc' then 5 else 0 end) as Graduated
				, (case hdts.[Type] when 'HDVTH' then 1 when 'HD1NAM' then 2 when 'PLHD' then 4 else 3 end) as ContractType*/
		select count(empl.Employee_ID) as dkTotal, sum(case when Sex = 'Female' then 1 else 0 end) as dkFemaleEmpl, sum(case when Graduated = 'Bangnghe' then 1 else 0 end) as dkBangnghe, sum(case when Graduated = 'Socapnghe' then 1 else 0 end) as dkSocapnghe
			, sum(case when Graduated = 'TrungCap' then 1 else 0 end) as dkTrungCap, sum(case when Graduated = 'CaoDang' then 1 else 0 end) as dkCaoDang, sum(case when Graduated = 'DaiHoc' then 1 else 0 end) as dkDaiHoc
			, sum(case when hdts.[Type] = 'HDVTH' then 1 else 0 end) as dkHDVTH, sum(case when hdts.[Type] like 'HD1NAM%' then 1 else 0 end) as dkHD1NAM, sum(case when hdts.[Type] like 'HDTV%' then 1 else 0 end) as dkHDTV
		from udf_EmployeeFilter_Full (@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@fromdate) empl
		left join
		udf_HopDongTuSinh ('1900-1-1',@fromdate,1,@LAN,null,null,null,null,null,null,null) hdts
		on hdts.Employee_ID = empl.Employee_ID
		left join
		(
			select Employee_ID, MAX(CL_RegisterDate) as MaxCL_RegisterDate from udf_HopDongTuSinh ('1900-1-1',@fromdate,1,@LAN,null,null,null,null,null,null,null) group by Employee_ID
		) hdtsMax
		on hdts.Employee_ID = hdtsMax.Employee_ID and hdts.CL_RegisterDate = hdtsMax.MaxCL_RegisterDate
		where ISNULL(TernimationDate,'2099-1-1') between @fromdate and @todate

		-- Set du lieu
		-- Dau ky
		select @dkTotal = Total from @DauKy
		select @dkFemaleEmpl = FemaleEmpl from @Dauky
		select @dkBangnghe = Bangnghe from @Dauky
		select @dkSocapnghe = Socapnghe from @Dauky
		select @dkTrungCap = TrungCap from @Dauky
		select @dkCaoDang = CaoDang from @Dauky
		select @dkDaiHoc = DaiHoc from @Dauky
		select @dkHDVTH = HDVTH from @Dauky
		select @dkHD1NAM = HD1NAM from @Dauky
		select @dkHDTV = HDTV from @Dauky
		
		-- So Tang
		select @stTotal = Total from @SoTang
		select @stFemaleEmpl = FemaleEmpl from @SoTang
		select @stBangnghe = Bangnghe from @SoTang
		select @stSocapnghe = Socapnghe from @SoTang
		select @stTrungCap = TrungCap from @SoTang
		select @stCaoDang = CaoDang from @SoTang
		select @stDaiHoc = DaiHoc from @SoTang
		select @stHDVTH = HDVTH from @SoTang
		select @stHD1NAM = HD1NAM from @SoTang
		select @stHDTV = HDTV from @SoTang

		-- So Giam
		select @sgTotal = Total from @SoGiam
		select @sgFemaleEmpl = FemaleEmpl from @SoGiam
		select @sgBangnghe = Bangnghe from @SoGiam
		select @sgSocapnghe = Socapnghe from @SoGiam
		select @sgTrungCap = TrungCap from @SoGiam
		select @sgCaoDang = CaoDang from @SoGiam
		select @sgDaiHoc = DaiHoc from @SoGiam
		select @sgHDVTH = HDVTH from @SoGiam
		select @sgHD1NAM = HD1NAM from @SoGiam
		select @sgHDTV = HDTV from @SoGiam

		/*select @dkTotal as dkTotal, @dkFemaleEmpl as dkFemaleEmpl, @dkBangnghe as dkBangnghe, @dkSocapnghe as dkSocapnghe, @dkTrungCap as dkTrungCap, @dkCaoDang as dkCaoDang, @dkDaiHoc as dkDaiHoc, @dkHDVTH as dkHDVTH, @dkHD1NAM as dkHD1NAM, @dkHDTV as dkHDTV
			, @stTotal as stTotal, @stFemaleEmpl as stFemaleEmpl, @stBangnghe as stBangnghe, @stSocapnghe as stSocapnghe, @stTrungCap as stTrungCap, @stCaoDang as stCaoDang, @stDaiHoc as stDaiHoc, @stHDVTH as stHDVTH, @stHD1NAM as stHD1NAM, @stHDTV as stHDTV
			, @sgTotal as sgTotal, @sgFemaleEmpl as sgFemaleEmpl, @sgBangnghe as sgBangnghe, @sgSocapnghe as sgSocapnghe, @sgTrungCap as sgTrungCap, @sgCaoDang as sgCaoDang, @sgDaiHoc as sgDaiHoc, @sgHDVTH as sgHDVTH, @sgHD1NAM as sgHD1NAM, @sgHDTV as sgHDTV*/

		select @dkTotal as dkTotal, @dkFemaleEmpl as dkFemaleEmpl, @dkBangnghe as dkBangnghe, @dkSocapnghe as dkSocapnghe, @dkTrungCap as dkTrungCap, @dkCaoDang as dkCaoDang, @dkDaiHoc as dkDaiHoc, @dkHDVTH as dkHDVTH, @dkHD1NAM as dkHD1NAM, @dkHDTV as dkHDTV
			, @stTotal as stTotal, @stFemaleEmpl as stFemaleEmpl, @stBangnghe as stBangnghe, @stSocapnghe as stSocapnghe, @stTrungCap as stTrungCap, @stCaoDang as stCaoDang, @stDaiHoc as stDaiHoc, @stHDVTH as stHDVTH, @stHD1NAM as stHD1NAM, @stHDTV as stHDTV
			, @sgTotal as sgTotal, @sgFemaleEmpl as sgFemaleEmpl, @sgBangnghe as sgBangnghe, @sgSocapnghe as sgSocapnghe, @sgTrungCap as sgTrungCap, @sgCaoDang as sgCaoDang, @sgDaiHoc as sgDaiHoc, @sgHDVTH as sgHDVTH, @sgHD1NAM as sgHD1NAM, @sgHDTV as sgHDTV
			, t.*, hdts.CL_RegisterDate, hdts.CL_ExpiredDate, (case when hdts.[Type] = 'HDVTH' then 1 when hdts.[Type] like 'HD1NAM%' then 2 when hdts.[Type] like 'HDTV%' then 3 else 4 end) as TypeOfContract
				, ta.ResonTerminated
		from #tab t
		left join
		(
			select Employee_ID, Max(CL_StartDate) as MaxStartDate from udf_HopDongTuSinh ('1900-1-1', @todate, 1, @LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp) hdts group by Employee_ID
		) hdtsMax
		on t.Employee_ID = hdtsMax.Employee_ID
		left join
		udf_HopDongTuSinh ('1900-1-1', @todate, 1, @LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp) hdts
		on hdts.Employee_ID = t.Employee_ID and hdts.CL_StartDate = hdtsMax.MaxStartDate
		left join
		HR_TerminationAsignment ta
		on ta.Employee_ID = t.Employee_ID
		where TernimationDate between @fromdate and @todate
	END
	
	
	ELSE if @TypeOfReport = 15
	BEGIN
		--exec sp_BangThongTinNhanVien '2023-01-01','2023-01-31',15,N'',N'',N'',N'',N'',N''
		select dep.JobCode, dep.DepartmentCode, LODec.TongNV as TongNVLODec, LODec.SoTangNV as SoTangNVLODec, Jan.TongNV as TongNVJan, Jan.SoTangNV as SoTangNVJan, Feb.TongNV as TongNVFeb, Feb.SoTangNV as SoTangNVFeb, Mar.TongNV as TongNVMar, Mar.SoTangNV as SoTangNVMar, Apr.TongNV as TongNVApr, Apr.SoTangNV as SoTangNVApr
				, May.TongNV as TongNVMay, May.SoTangNV as SoTangNVMay, Jun.TongNV as TongNVJun, Jun.SoTangNV as SoTangNVJun, Jul.TongNV as TongNVJul, Jul.SoTangNV as SoTangNVJul, Aug.TongNV as TongNVAug, Aug.SoTangNV as SoTangNVAug
				, Sep.TongNV as TongNVSep, Sep.SoTangNV as SoTangNVSep, Oct.TongNV as TongNVOct, Oct.SoTangNV as SoTangNVOct, Nov.TongNV as TongNVNov, Nov.SoTangNV as SoTangNVNov, [Dec].TongNV as TongNVDec, [Dec].SoTangNV as SoTangNVDec
				, Jan.Under1Month as Under1MonthJan, Jan.From1To3Months as From1To3MonthsJan, Jan.From3To6Months as From3To6MonthsJan, Jan.From6To12Months as From6To12MonthsJan, Jan.Over1Year as Over1YearJan
				, Feb.Under1Month as Under1MonthFeb, Feb.From1To3Months as From1To3MonthsFeb, Feb.From3To6Months as From3To6MonthsFeb, Feb.From6To12Months as From6To12MonthsFeb, Feb.Over1Year as Over1YearFeb
				, Mar.Under1Month as Under1MonthMar, Mar.From1To3Months as From1To3MonthsMar, Mar.From3To6Months as From3To6MonthsMar, Mar.From6To12Months as From6To12MonthsMar, Mar.Over1Year as Over1YearMar
				, Apr.Under1Month as Under1MonthApr, Apr.From1To3Months as From1To3MonthsApr, Apr.From3To6Months as From3To6MonthsApr, Apr.From6To12Months as From6To12MonthsApr, Apr.Over1Year as Over1YearApr
				, May.Under1Month as Under1MonthMay, May.From1To3Months as From1To3MonthsMay, May.From3To6Months as From3To6MonthsMay, May.From6To12Months as From6To12MonthsMay, May.Over1Year as Over1YearMay
				, Jun.Under1Month as Under1MonthJun, Jun.From1To3Months as From1To3MonthsJun, Jun.From3To6Months as From3To6MonthsJun, Jun.From6To12Months as From6To12MonthsJun, Jun.Over1Year as Over1YearJun
				, Jul.Under1Month as Under1MonthJul, Jul.From1To3Months as From1To3MonthsJul, Jul.From3To6Months as From3To6MonthsJul, Jul.From6To12Months as From6To12MonthsJul, Jul.Over1Year as Over1YearJul
				, Aug.Under1Month as Under1MonthAug, Aug.From1To3Months as From1To3MonthsAug, Aug.From3To6Months as From3To6MonthsAug, Aug.From6To12Months as From6To12MonthsAug, Aug.Over1Year as Over1YearAug
				, Sep.Under1Month as Under1MonthSep, Sep.From1To3Months as From1To3MonthsSep, Sep.From3To6Months as From3To6MonthsSep, Sep.From6To12Months as From6To12MonthsSep, Sep.Over1Year as Over1YearSep
				, Oct.Under1Month as Under1MonthOct, Oct.From1To3Months as From1To3MonthsOct, Oct.From3To6Months as From3To6MonthsOct, Oct.From6To12Months as From6To12MonthsOct, Oct.Over1Year as Over1YearOct
				, Nov.Under1Month as Under1MonthNov, Nov.From1To3Months as From1To3MonthsNov, Nov.From3To6Months as From3To6MonthsNov, Nov.From6To12Months as From6To12MonthsNov, Nov.Over1Year as Over1YearNov
				, [Dec].Under1Month as Under1MonthDec, [Dec].From1To3Months as From1To3MonthsDec, [Dec].From3To6Months as From3To6MonthsDec, [Dec].From6To12Months as From6To12MonthsDec, [Dec].Over1Year as Over1YearDec
		from
		udf_BangTangNhanVienTrongThang (@LFODec,@LEODec) LODec
		full outer join
		udf_BangTangNhanVienTrongThang (@FOJan,@EOJan) Jan
		on LODec.DepartmentCode = Jan.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOFeb,@EOFeb) Feb
		on LODec.DepartmentCode = Feb.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOMar,@EOMar) Mar
		on LODec.DepartmentCode = Mar.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOApr,@EOApr) Apr
		on LODec.DepartmentCode = Apr.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOMay,@EOMay) May
		on LODec.DepartmentCode = May.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOJun,@EOJun) Jun
		on LODec.DepartmentCode = Jun.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOJul,@EOJul) Jul
		on LODec.DepartmentCode = Jul.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOAug,@EOAug) Aug
		on LODec.DepartmentCode = Aug.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOSep,@EOSep) Sep
		on LODec.DepartmentCode = Sep.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FOOct,@EOOct) Oct
		on LODec.DepartmentCode = Oct.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FONov,@EONov) Nov
		on LODec.DepartmentCode = Nov.DepartmentCode
		full outer join
		udf_BangTangNhanVienTrongThang (@FODec,@EODec) [Dec]
		on LODec.DepartmentCode = [Dec].DepartmentCode
		left join
		SmartBooks_Department dep
		on LODec.DepartmentCode = dep.DepartmentCode
		order by isnull(dep.JobCode,'zzz'), dep.DepartmentCode
	end

END

GO
