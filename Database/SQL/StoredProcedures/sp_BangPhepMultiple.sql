
CREATE PROCEDURE [dbo].[sp_BangPhepMultiple]
--exec [dbo].[sp_BangPhepMultiple] '1900-09-01','2025-09-30',1,null,null,null,null,null,null,null,'C3673'
	-- Add the parameters for the stored procedure here
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
	@ListOfLeaveType varchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @KiemTraDuLieuNhap nvarchar(max),@NumberOfDate as int,@ID int,@SoNgaySauKhiMangBauDuocHuongThaiSan int
	declare @MaPhep as varchar(10),@SQLMaPhep as varchar(max),@SQL nvarchar(max)
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=Value from SetUp where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	if @TypeOfReport=1 begin-- danh sách nghỉ theo khoảng thời gian
		select
		empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
		,empl.ComStartedDate,empl.Employee_Status,empl.TernimationDate
		,isnull(erml.LeaveType_ID,bptn.LeaveType_ID) as LeaveType_ID,isnull(erml.[Fromdate],bptn.DateLeave) as Fromdate,isnull(erml.ToDate,bptn.DateLeave) as ToDate,isnull([dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate) + 1,1) as NumberOfDate,erml.Reason,erml.PlanStatus,cast(erml.isDaNopGiay as bit) as isDaNopGiay,cast(erml.isBlock as bit) as isBlock,cast(erml.isChoUngPhep as bit) as isChoUngPhep,isnull(erml.Remark,bptn.Remark_) as Remark,erml.InsertDate,erml.UserName,erml.ID
		from
		udf_EmployeeFilter_Full (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		left join
		udf_BangThoiGian (@fromdate,@todate) btg
		on btg.Date_ >= empl.StartedDate
		left join
		HR_EmployeeRegisMaternityLeave erml
		on empl.Employee_ID = erml.Employee_ID and erml.Fromdate <> erml.ToDate and (erml.Fromdate between @fromdate and @todate or erml.ToDate between @fromdate and @todate) and btg.Date_ between erml.Fromdate and erml.ToDate
		left join
		udf_BangPhepTheoNgay (2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@Emp,null) bptn
		on bptn.Employee_ID = empl.Employee_ID and bptn.DateLeave not between isnull(erml.Fromdate,@fromdate-1) and isnull(erml.ToDate,@fromdate-1) and bptn.DateLeave = btg.Date_
		where erml.Employee_ID is not null or (bptn.DateLeave is not null AND bptn.LeaveType_ID <> '14')
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, StartedDate,erml.Fromdate,erml.LeaveType_ID
	end else if @TypeOfReport=4 begin-- danh sách người thôi việc nhưng vẫn có đăng ký phép
		select empl.Position
		--empl.Factory_ID,empl.DepartmentCode, empl.SectionCode, empl.TeamCode, empl.Position_ID, empl.PositionCategory_ID
		,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.ComStartedDate,empl.TernimationDate
		,erml.LeaveType_ID,erml.[Fromdate],erml.ToDate,[dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) as NumberOfDate,erml.Reason,erml.PlanStatus,cast(erml.isDaNopGiay as bit) as isDaNopGiay,cast(erml.isBlock as bit) as isBlock,cast(erml.isChoUngPhep as bit) as isChoUngPhep,erml.Remark,erml.InsertDate,erml.UserName,erml.ID
		from
		udf_BangPhep(@fromdate,@todate,@Emp) erml
		inner join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on erml.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where empl.TernimationDate<=erml.Fromdate
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, StartedDate,erml.Fromdate,erml.LeaveType_ID
	end else if @TypeOfReport=5 begin-- số phép năm đã nghỉ
		select sum((case when LeaveType_ID in ('31','32') then [dbo].[udf_CountWorkingDay]([Fromdate],ToDate)/2.0 else [dbo].[udf_CountWorkingDay]([Fromdate],[ToDate]) end)) as TongPhepNamDaNghi
		from
		udf_BangPhep(@fromdate,@todate,@Emp) where LeaveType_ID in (select LeaveType_ID from SmartBooks_LeaveType where PhepNam=1)
	end else if @TypeOfReport=6 begin -- danh sách nghỉ không phép từ 5 lần trong vòng 30 ngày
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.position,kp5lan.DanhSachNgayNghiKP
		from
		[dbo].[udf_TraVeNghiKhongPhep5LanTrong30Ngay](@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp) kp5lan
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		ON kp5lan.Employee_ID=empl.Employee_ID
		where empl.Employee_ID is not null
	end else if @TypeOfReport=7 begin--đăng ký phép bất thường
		select empl.Position,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,qv.Employee_ID,qv.DateLeave,qv.LeaveType_ID,qv.ShiftName,cast(qv.GioNghiTu as time(0))as GioNghiTu,cast(qv.GioNghiDen as time(0)) as GioNghiDen,cast(qv.QuetVao as time(0)) as QuetVao,cast(qr.QuetRa as time(0)) as QuetRa from
		(
			select Employee_ID,DateLeave,LeaveType_ID,ShiftName,GioNghiTu,GioNghiDen,min(AccessTime) as QuetVao from [dbo].[udf_PhepVaDuLieuQuetLienQuan](@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp) group by Employee_ID,DateLeave,LeaveType_ID,GioNghiTu,GioNghiDen,ShiftName
		)qv
		left join
		(
			select Employee_ID,DateLeave,max(AccessTime) as QuetRa from [dbo].[udf_PhepVaDuLieuQuetLienQuan](@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp) group by Employee_ID,DateLeave
		)qr
		on qv.Employee_ID=qr.Employee_ID and qv.DateLeave=qr.DateLeave
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,getdate())) empl
		on qv.Employee_ID=empl.Employee_ID
		where datediff(minute,case when qv.QuetVao<qv.GioNghiTu then qv.GioNghiTu else qv.QuetVao end,case when qr.QuetRa>qv.GioNghiDen then qv.GioNghiDen else qr.QuetRa end)>=60 
		 and empl.Employee_ID is not null
	end else if @TypeOfReport=8 begin-- bảng phép theo loại phép
		set @SQLMaPhep=''
			DECLARE cur CURSOR LOCAL FOR
			select AbsentSign from SmartBooks_LeaveType order by AbsentSign asc
			OPEN  cur 
			FETCH NEXT FROM cur INTO @MaPhep
			WHILE @@FETCH_STATUS = 0
			BEGIN
				set @SQLMaPhep=@SQLMaPhep+replace(@MaPhep,'/','')+','
				FETCH NEXT FROM cur INTO @MaPhep
			END
			CLOSE cur
			DEALLOCATE cur
			set @SQLMaPhep=left(@SQLMaPhep,len(@SQLMaPhep)-1)
		IF OBJECT_ID('tempdb..#tabTongHophep') IS NOT NULL DROP TABLE #tabTongHophep
		select Employee_ID,sum(isnull(HourLeave,0)) as Value, lt.AbsentSign as Lable into #tabTongHophep from
		udf_BangPhepTheoNgay(2,@fromdate,@todate,null,null,null,null,null,null,null,null) ptn
		left join
		SmartBooks_LeaveType lt
		on ptn.LeaveType_ID=lt.LeaveType_ID
		where DateLeave between @fromdate and @todate group by Employee_ID,lt.AbsentSign
		set @SQL='select Empl.PositionFullName,ctN.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,'+@SQLMaPhep+'
				from (select Employee_ID,Lable,Value '
				+'from #tabTongHophep) a pivot(sum(Value) for lable in ('+@SQLMaPhep+'))ctn left join [dbo].[udf_EmployeeFilter]('''+@LAN+''',null,null,null,null,null,null,null,'''+convert(nvarchar(10), @todate, 111)+''') empl on ctn.Employee_ID=empl.Employee_ID
				order by empl.PositionFullName,ctn.Employee_ID'
			exec (@SQL)
		--exec [dbo].[sp_BangPhepMultiple] '2022-2-1','2022-2-28',8
	end else if @TypeOfReport=9 begin-- bảng phép theo ngày
		set @SQLMaPhep=''
			select @SQLMaPhep=@SQLMaPhep+'['+replace(left(convert(nvarchar(10), date_, 105),5),'-','')+'],' from udf_BangThoiGian(@fromdate,@todate)
			set @SQLMaPhep=left(@SQLMaPhep,len(@SQLMaPhep)-1)
		IF OBJECT_ID('tempdb..#tabTongHophepTheoNgay') IS NOT NULL DROP TABLE #tabTongHophepTheoNgay
		select Employee_ID,sum(isnull(HourLeave,0)) as Value, replace(left(convert(nvarchar(10), ptn.DateLeave, 105),5),'-','') as Lable into #tabTongHophepTheoNgay
		from
		[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@emp,@ListOfLeaveType) ptn
		left join
		SmartBooks_LeaveType lt
		on ptn.LeaveType_ID=lt.LeaveType_ID
		where ptn.DateLeave between @fromdate and @todate group by ptn.Employee_ID,ptn.Dateleave
		set @SQL='select Empl.PositionFullName,ctN.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,'+@SQLMaPhep+'
				from (select Employee_ID,Lable,Value '
				+'from #tabTongHophepTheoNgay) a pivot(sum(Value) for lable in ('+@SQLMaPhep+'))ctn left join [dbo].[udf_EmployeeFilter]('''+@LAN+''',null,null,null,null,null,null,null,'''+convert(nvarchar(10), @todate, 111)+''') empl on ctn.Employee_ID=empl.Employee_ID
				order by empl.PositionFullName,ctn.Employee_ID'
			exec (@SQL)
		--exec [dbo].[sp_BangPhepMultiple] '2022-2-1','2022-2-28',9
	end if @TypeOfReport = 10
	begin
		select 
				elr.TrangThai, elr.LeaveType_ID, elr.Fromdate, elr.Todate
				, round(case when LeaveType_ID IN ('49','24') then 
					[dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate],elr.ToDate)/1 else
					[dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) 
					END,2) as NumberOfDate
				,CASE 
				WHEN LeaveType_ID IN ('49','24')
				THEN 			
					--ISNULL(elr.HourLeave,8* ([dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate],elr.ToDate)) )
					8* ([dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate],elr.ToDate))
				ELSE
					--ISNULL(elr.HourLeave,8 * ([dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)) /(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) ) 
					8 * ([dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)) /(case when LeaveType_ID in ('31','32') then 2.0 else 1 end)
				END as HourLeave
				--,
				--ISNULL(elr.HourLeave,8) * ([dbo].[udf_CountWorkingDay](elr.[Fromdasp_BangPhepXinRaNgoaite],elr.ToDate)) /(case when LeaveType_ID in ('31','32') then 2.0 else 1 end)
				
				, elr.RaSomVaoMuon
				, elr.ApproverName as Approver, elr.ApproveLevel as ApproverCurrent--, elr.ApproveDate
				, elr.isChoUngPhep, elr.ID, elr.InsertDate, elr.ImageBinary,elr.ImageFileName,elr.ImageFileType,elr.ImageFileSize
		from
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		left join
		HR_EmployeeLeaveRequests elr
		on elr.Employee_ID = empl.Employee_ID
		--left join
		--udf_GetApprover (@Emp,1,'VN') gap
		--on gap.Code = elr.Employee_ID
		where elr.Fromdate between @fromdate and @todate and TrangThai in ('Pending','Rejected')
		AND elr.LeaveType_ID <>'14'
	--exec [dbo].[sp_BangPhepMultiple] '2025-01-01','2025-10-31',10,'VN',N'',N'',N'',N'',N'',N'',N'C11605',null

		union
		select 
				'Approved' as TrangThai
				,isnull(erml.LeaveType_ID,bptn.LeaveType_ID) as LeaveType_ID
				,isnull(erml.Fromdate,bptn.DateLeave) as Fromdate
				,isnull(erml.Todate,bptn.DateLeave) as Todate
				
				,Round((case
					when erml.LeaveType_ID in ('24','49') then [dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate],erml.ToDate)/1 
					when erml.Employee_ID is not null then [dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate) 
					else bptn.HourLeave/8.0
				end)
				/(case
					when erml.Employee_ID is not null and erml.LeaveType_ID in ('31','32') then 2.0
					else 1
				end),2) as NumberOfDate

				,isnull(bptn.HourLeave,8) 
				* (case
						when erml.LeaveType_ID IN ('49','24') then [dbo].[udf_CountWorkingDayWithSun](erml.[Fromdate],erml.ToDate)/1 
						when erml.Employee_ID is not null then  [dbo].[udf_CountWorkingDay](erml.[Fromdate],erml.ToDate) 
						when bptn.LeaveType_ID in ('31','32') then 1
						else 1
					end)
				--/(case
				--	when erml.Employee_ID is not null and erml.LeaveType_ID in ('31','32') then 2.0
				--	else 1
				--end) as HourLeave
				
				, null as RaSomVaoMuon
				, erml.UserName, null as ApproverCurrent--, erml.InsertDate
				, erml.isChoUngPhep, Null as ID, erml.InsertDate,'','','',''
		from
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		left join
		udf_BangThoiGian (@fromdate,@todate) btg
		on btg.Date_ >= empl.StartedDate
		left join
		HR_EmployeeRegisMaternityLeave erml
		on empl.Employee_ID = erml.Employee_ID and erml.Fromdate <> erml.ToDate and (erml.Fromdate between @fromdate and @todate or erml.ToDate between @fromdate and @todate) and btg.Date_ between erml.Fromdate and erml.ToDate
		left join
		udf_BangPhepTheoNgay (2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,@Emp,null) bptn
		on bptn.Employee_ID = empl.Employee_ID and bptn.DateLeave not between isnull(erml.Fromdate,@fromdate-1) and isnull(erml.ToDate,@fromdate-1) and bptn.DateLeave = btg.Date_
		where erml.Employee_ID is not null or (bptn.DateLeave is not null AND bptn.LeaveType_ID <> '14')
		ORDER by Fromdate desc
	end
	--------------------------------------
	
	else if @TypeOfReport=11 begin
		select empl.DepartmentName, elr.Employee_ID, dbo.udf_FullName (empl.Employee_FirstName, empl.Employee_LastName) as FullName,
				elr.TrangThai, elr.LeaveType_ID, elr.Fromdate, elr.Todate
				, round(case when LeaveType_ID=49 then 
					[dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate],elr.ToDate)/1 else
					[dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) end,2) as NumberOfDate
				--, isnull(elr.HourLeave,8) * ([dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end)) as HourLeave, elr.RaSomVaoMuon
				, 8 * ([dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end)) as HourLeave, elr.RaSomVaoMuon
				, elr.isDaNopGiay, elr.isChoUngPhep, elr.ID, elr.InsertDate, elr.ImageBinary,elr.ImageFileName,elr.ImageFileType,elr.ImageFileSize
		from
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		left join
		HR_EmployeeLeaveRequests elr
		on elr.Employee_ID = empl.Employee_ID
		where elr.Fromdate between @fromdate and @todate and TrangThai in ('Pending')
		ORDER by Fromdate desc
	END
	--------------------------
	
	---danh sách phép cần duyệt
	--exec [dbo].[sp_BangPhepMultiple] '2025-08-01','2025-08-30',10,'VN',null,null,null,null,null,null,'C11605'
	ELSE if @TypeOfReport=12
	BEGIN
		select empl.PositionFullName as DepartmentName, empl.Employee_ID, dbo.udf_FullName (empl.Employee_Firstname, empl.Employee_LastName) as FullName, elr.TrangThai, elr.LeaveType_ID, elr.Fromdate, elr.Todate
				, CASE
						WHEN LeaveType_ID in ('49','24') then [dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate],elr.ToDate)/1
						ELSE [dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end)
					END as NumberOfDate, isnull(elr.HourLeave,8)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) as HourLeave
					, elr.isChoUngPhep--, elr.InsertDate
					, elr.ID
					, rlh.Approver_Name as LastestApprover, rlh.Approve_Date as LastestApproveDate, elr.InsertDate
		FROM            
		HR_EmployeeLeaveRequests elr
		left join
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
		on elr.Employee_ID = empl.Employee_ID
		left join
		(
			select *, ROW_NUMBER () over (partition by Request_ID order by Approve_Date) as rn
			from
			HR_RequestLeave_History rlh
		) rlh
		on elr.ID = rlh.Request_ID
		where elr.ApproveLevel = @Emp and elr.TrangThai = 'Pending' and (elr.Fromdate between @fromdate and @todate or elr.Todate between @fromdate and @todate)
		order by Fromdate

	end else if @TypeOfReport=13 begin
		select empl.DepartmentName, elr.Employee_ID, dbo.udf_FullName (empl.Employee_FirstName, empl.Employee_LastName) as FullName,
				elr.TrangThai, elr.LeaveType_ID, elr.Fromdate, elr.Todate
				, case when LeaveType_ID=49 then 
					[dbo].[udf_CountWorkingDayWithSun](elr.[Fromdate],elr.ToDate)/1 else
					[dbo].[udf_CountWorkingDay](elr.[Fromdate],elr.ToDate)/(case when LeaveType_ID in ('31','32') then 2.0 else 1 end) end as NumberOfDate
				, isnull(elr.HourLeave,8) as HourLeave, elr.RaSomVaoMuon
				, elr.isDaNopGiay, elr.isChoUngPhep, elr.ID
		from
		udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		left join
		HR_EmployeeLeaveRequests elr
		on elr.Employee_ID = empl.Employee_ID
		where elr.Fromdate between @fromdate and @todate and TrangThai in ('Pending')
	end else if @TypeOfReport=14 begin
		declare @s nvarchar(max); set @s=''
		--select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		set @s= left(@s,len(@s)-1)
		
		set @sql = 'Select *
					from
					(
						select empl.Employee_ID, empl.Employee_Firstname, empl.Employee_LastName, empl.FactoryName, empl.DepartmentName, empl.Employee_Status, empl.TernimationDate
								, CONVERT(varchar(12),Date_,111) as Date_, lt.AbsentSign
						from
						udf_BangThoiGian (@fromdate,@todate) btg
						left join
						udf_EmployeeFilter (@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Emp, @todate) empl
						on btg.Date_ > empl.StartedDate
						left join
						HR_BangPhepDaNghi bpdn
						on empl.Employee_ID = bpdn.Employee_ID and btg.Date_ = bpdn.DateLeave
						left join
						Smartbooks_LeaveType lt
						on bpdn.LeaveType_ID = lt.LeaveType_ID
						where empl.Employee_ID is not null
					) src
					pivot
					(
						max(AbsentSign)
						for Date_ in (@s1)
					) as pivot_table
					order by FactoryName, DepartmentName, Employee_ID'
					print @sql
		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime, @LAN nvarchar(50), @SoNgaySauKhiMangBauDuocHuongThaiSan int, @fact nvarchar(50), @dept nvarchar(100), @sect nvarchar(50), @team nvarchar(50), @pos nvarchar(50), @posc nvarchar(50), @Emp nvarchar(50)'
				  , @fromdate = @fromdate  
				  , @todate = @todate
				  , @LAN = @LAN
				  , @SoNgaySauKhiMangBauDuocHuongThaiSan = @SoNgaySauKhiMangBauDuocHuongThaiSan
				  , @fact = @fact
				  , @dept = @dept
				  , @sect = @sect
				  , @team = @team
				  , @pos = @pos
				  , @posc = @posc
				  , @Emp = @Emp
	end
END

	--exec [dbo].[sp_BangPhepMultiple] '2025-10-01','2025-10-30',14,'VN',null,null,null,null,null,null,'C10851'



GO
