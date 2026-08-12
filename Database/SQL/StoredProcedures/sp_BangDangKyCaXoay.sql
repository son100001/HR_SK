CREATE PROCEDURE [dbo].[sp_BangDangKyCaXoay] 
--select * from [dbo].[udf_EmployeeFilter]('VN',NULL,NULL,NULL,NULL,NULL,NULL) where TeamCode is null
--exec sp_BangDangKyCaXoay '2025-08-01','2025-08-31',4,N'VN','',null,null,null,null,null

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
	@Emp nvarchar (50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @ShiftName as nvarchar(50),@FD datetime,@TD datetime,@RoundCode varchar(50), @Remark nvarchar(max),@InsertDate datetime,@UserName nvarchar(50),@KiemTraDuLieuNhap nvarchar(max),@ID int,@TypeOfRegister int
		,@ListOfShiftName nvarchar(200),@SQL nvarchar(max)
		,@SoNgaySauKhiMangThaiDuocHuongCheDo int
    -- Insert statements for procedure here
	if @TypeOfReport=1 begin--xem all
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.StartedDate, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName,rs.*
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
		inner join
		HR_RoundShift rs
		on empl.Employee_ID=rs.Employee_ID
		where rs.fromdate between @fromdate and @todate
	end else if @TypeOfReport=2 begin--xem danh sách đăng ký ca theo ngày
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
				,empl.StartedDate, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				,rs.*
		from
		(
			select Employee_ID,max(FromDate) as FromDate from HR_RoundShift where FromDate<=@fromdate and (ToDate is null or ToDate>=@fromdate)
			group by Employee_ID
		)as maxrs
		left join
		HR_RoundShift rs
		on maxrs.Employee_ID=rs.Employee_ID and maxrs.FromDate=rs.FromDate
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on empl.Employee_ID=maxrs.Employee_ID
	end else if @TypeOfReport=3 begin--Hỗ trợ nhập dữ liệu nhiều theo lưới
		select empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.Employee_ID,empl.StartedDate,rs.*,@KiemTraDuLieuNhap as KiemTraDuLieuNhap
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		left join
		HR_RoundShift rs
		on 1=2
		where empl.ComStartedDate<=@fromdate and (empl.TernimationDate is null or empl.TernimationDate>@fromdate)
	end else if @TypeOfReport=4 begin--xem chi tiét ca từ ngày đến ngày
		declare @s nvarchar(max); set @s=''
		--select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		set @s= left(@s,len(@s)-1)
		
		set @sql = 'Select *
					from
					(
						select empl.Employee_ID, empl.Employee_Firstname, empl.Employee_LastName, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
								, empl.Employee_Status, empl.TernimationDate, CONVERT(varchar(12),Date_,111) as Date_, case when sh.ShiftSign = ''CaDem'' and datename(dw,btg.Date_) = ''Saturday'' then ''CD7_173023'' else sh.ShiftSign end as ShiftSign
						from
						udf_BangThoiGian (@fromdate,@todate) btg
						left join
						udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
						on btg.Date_ > empl.StartedDate
						left join
						HR_RoundShift rs
						on btg.Date_ between rs.FromDate and rs.ToDate and empl.Employee_ID = rs.Employee_ID
						left join
						HR_Shifts sh
						on rs.ShiftName = sh.ShiftName
						where empl.Employee_ID is not null
					) src
					pivot
					(
						max(ShiftSign)
						for Date_ in (@s1)
					) as pivot_table
					order by FactoryName, DepartmentName, Employee_ID'
					print @sql
		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime, @LAN nvarchar(50), @fact nvarchar(50), @dept nvarchar(100), @sect nvarchar(50), @team nvarchar(50), @pos nvarchar(50), @posc nvarchar(50), @Emp nvarchar(50)'
				  , @fromdate = @fromdate  
				  , @todate = @todate
				  , @LAN = @LAN
				  , @fact = @fact
				  , @dept = @dept
				  , @sect = @sect
				  , @team = @team
				  , @pos = @pos
				  , @posc = @posc
				  , @Emp = @Emp
		--select
		--empl.Position
		--,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		--,erl.*
		--from
		--#tab erl
		--inner join
		--[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		--on erl.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		--where empl.[ComStartedDate]<=@todate and (empl.[TernimationDate] is null or empl.[TernimationDate]>@fromdate)
		--order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, empl.StartedDate
	end else if @TypeOfReport=5 begin --xem theo ca còn hiệu lực trong khoảng thời gian
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
			,empl.StartedDate,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName, rs.*
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		inner join
		HR_RoundShift rs
		on empl.Employee_ID=rs.Employee_ID
		where rs.fromdate<=@todate and (todate is null or todate>=@fromdate)
	end else if @TypeOfReport=6 begin --Bảng đăng ký ca theo ngày bao gồm cả bảng HR_EmpRegisTimeSheet
		select @SoNgaySauKhiMangThaiDuocHuongCheDo=[Value] from SetUp where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
		set @ListOfShiftName=''
		select @ListOfShiftName=@ListOfShiftName+'['+ShiftSign+'],' from hr_shifts where isnull(ShiftSign,'')<>''
		set @ListOfShiftName=left(@ListOfShiftName,len(@ListOfShiftName)-1)
		IF OBJECT_ID('tempdb..#BangTongHopTheoCaTheoNgay') IS NOT NULL DROP TABLE #BangTongHopTheoCaTheoNgay
		select dkc.AccessDate as TimeDate,empl.RFID, isnull(s.ShiftSign,'Unknown') as ShiftSign into #BangTongHopTheoCaTheoNgay from
		udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDo,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		left join
		HR_Shifts s
		on dkc.ShiftName=s.ShiftName
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on dkc.Employee_ID=empl.Employee_ID
		left join
		[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,null,null,null,null,null,null,null,null) erml
		on dkc.Employee_ID=erml.Employee_ID and dkc.accessdate=erml.dateleave and erml.LeaveType_ID not in (31,32)
		left join
		[dbo].[SmartBooks_HolidaysPlan] hp
		on dkc.accessdate=hp.H_Date
		where erml.Employee_ID is null and (datename(weekday,dkc.accessdate)<>'Sunday' and hp.H_date is null) and empl.employee_id is not null

		--IF OBJECT_ID('tempdb..#BangTongHopTheoCaTheoNgayCoSum') IS NOT NULL DROP TABLE #BangTongHopTheoCaTheoNgayCoSum
		set @SQL='SELECT TimeDate,RFID,'+@ListOfShiftName+',Unknown FROM  
			(	SELECT *
				FROM [dbo].[#BangTongHopTheoCaTheoNgay]
			) AS SourceTable
			PIVOT  
			(
				count(ShiftSign) FOR ShiftSign IN ('+@ListOfShiftName+',Unknown)
			) AS PivotTable'
			EXECUTE sp_executesql @sql
			--select *,ISNULL(Shift0,0)+ISNULL(Shift1,0)+ISNULL(Shift2,0)+ISNULL(Shift3,0) as Total from #BangTongHopTheoCaTheoNgayCoSum
	end else if @TypeOfReport=7 begin--bảng chưa đăng ký ca
		select [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.Employee_ID,empl.ComStartedDate,empl.TernimationDate
		,tg.Date_ as TimeDate
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		left join
		udf_BangThoiGian(@fromdate,@todate) tg
		on empl.ComStartedDate<=tg.Date_ and (empl.TernimationDate is null or empl.TernimationDate>tg.Date_)
		left join
		udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDo,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		on empl.Employee_ID=dkc.Employee_ID and tg.Date_=dkc.AccessDate
		left join
		HR_EmployeeRegisMaternityLeave SenDingLetter
		on empl.Employee_ID=SenDingLetter.Employee_ID and tg.Date_ between SenDingLetter.Fromdate and SenDingLetter.ToDate and SenDingLetter.LeaveType_ID='28'
		where dkc.ShiftName is null and SenDingLetter.Employee_ID is null and tg.Date_ is not null
	end else if @TypeOfReport=8 begin--bang dk ca sai luat, bao gom HR_EmpRegisTimeSheet
		declare @Employee_ID nvarchar(50),@OldEmployee_ID nvarchar(50), @AccessDate datetime, @OldAccessDate datetime,@OldShiftName nvarchar(50),@LeaveType_ID nvarchar(50),@OldLeaveType_ID nvarchar(50)
			,@TimeIn datetime,@OldTimeIn datetime,@TimeOut datetime,@OldTimeOut datetime
			set @OldEmployee_ID=''
		DECLARE @tabDKCaSaiLuat TABLE
		(
		  Employee_ID nvarchar(50), 
		  TimeDate datetime,
		  OldShiftName nvarchar(50),
		  OldTimeOut datetime,
		  CurShiftName nvarchar(50),
		  CurTimeIn datetime
		  --UNIQUE CLUSTERED (Employee_ID,TimeDate)
		)
		
		IF OBJECT_ID('tempdb..#tabCa') IS NOT NULL DROP TABLE #tabCa
		select dkc.Employee_ID,dkc.AccessDate
		,[dbo].[GhepGioVaoNgay](dkc.AccessDate,dateadd(minute,-isnull(motBefore.maxovertime,0)*60,s.FromTime)) as TimeIn
		,(case when DATENAME(weekday,dkc.AccessDate)<>'SunDay' and hp.H_date is null then
			[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,s.fromtime)<=datepart(hour,s.totime) then dkc.AccessDate else dkc.AccessDate+1 end),dateadd(minute,isnull(motAfter.maxovertime,0)*60,s.ToTime))
			else 
			[dbo].[GhepGioVaoNgay]((case when DATEPART(hour,s.fromtime)<=datepart(hour,s.totime) then dkc.AccessDate else dkc.AccessDate+1 end),dateadd(minute,isnull(motHolSun.maxovertime,0)*60,s.FromTime))
		end)as TimeOut_
		,dkc.ShiftName,erml.LeaveType_ID into #tabCa
		from 
		udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDo,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		left join
		[dbo].[udf_BangPhep](@fromdate,@todate,@Emp) erml
		on dkc.Employee_ID=erml.Employee_ID and dkc.AccessDate between erml.Fromdate and erml.ToDate
		left join
		HR_MaxOverTime motAfter
		on dkc.AccessDate=motAfter.workingdate and dkc.Employee_ID=motAfter.Employee_ID and motAfter.TypeOfOT='1'
		left join
		HR_MaxOverTime motBefore
		on dkc.AccessDate=motBefore.workingdate and dkc.Employee_ID=motBefore.Employee_ID and motBefore.TypeOfOT='2'
		left join
		HR_MaxOverTime motHolSun
		on dkc.AccessDate=motHolSun.workingdate and dkc.Employee_ID=motHolSun.Employee_ID and motHolSun.TypeOfOT in ('4','5')
		left join
		HR_Shifts s
		on dkc.ShiftName=s.ShiftName
		left join
		SmartBooks_HolidaysPlan hp
		on dkc.AccessDate=hp.H_date
		where dkc.ShiftName is not null
		order by dkc.Employee_ID,dkc.AccessDate
		DECLARE cur CURSOR LOCAL FOR
		select * from #tabCa
		OPEN  cur
		FETCH NEXT FROM cur INTO @Employee_ID,@AccessDate,@TimeIn,@TimeOut,@ShiftName,@LeaveType_ID
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if @OldEmployee_ID=@Employee_ID and @OldShiftName<>@ShiftName and (@OldLeaveType_ID is null or @OldLeaveType_ID='31') and (@LeaveType_ID is null or @LeaveType_ID='32') begin
				if DATEDIFF(minute,@OldTimeOut,@TimeIn)<720 begin
					insert into @tabDKCaSaiLuat(Employee_ID,TimeDate,CurShiftName,CurTimeIn,OldShiftName,OldTimeOut) values(@Employee_ID,@AccessDate,@ShiftName,@TimeIn,@OldShiftName,@OldTimeOut)
				end
			end
			set @OldEmployee_ID=@Employee_ID set @OldTimeOut=@TimeOut set @OldShiftName=@ShiftName set @OldLeaveType_ID=@LeaveType_ID
		FETCH NEXT FROM cur INTO @Employee_ID,@AccessDate,@TimeIn,@TimeOut,@ShiftName,@LeaveType_ID
		END
		CLOSE cur
		DEALLOCATE cur

		select csl.Employee_ID, [dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName, empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
				,csl.TimeDate,csl.CurShiftName,cast(csl.CurTimeIn as time) as CurTimeIn,csl.OldShiftName,cast(csl.OldTimeOut as time) as OldTimeOut
		 from
		@tabDKCaSaiLuat csl
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		on csl.Employee_ID=empl.Employee_ID
	end else if @TypeOfReport=9 begin
		select @SoNgaySauKhiMangThaiDuocHuongCheDo=[Value] from SetUp where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
		IF OBJECT_ID('tempdb..#BangTongHopTheoCa') IS NOT NULL DROP TABLE #BangTongHopTheoCa
		select dkc.AccessDate as TimeDate, isnull(ShiftGroup,'Unknown') as ShiftGroup into #BangTongHopTheoCa from
		udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDo,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		--left join
		--[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,isnull(@todate,GETDATE())) empl
		--on dkc.Employee_ID=empl.Employee_ID
		left join
		HR_Shifts s
		on dkc.ShiftName=s.ShiftName
		left join
		HR_EmployeeRegisMaternityLeave erml
		on dkc.Employee_ID=erml.Employee_ID and dkc.AccessDate between erml.Fromdate and erml.ToDate
		where erml.Employee_ID is null

		--IF OBJECT_ID('tempdb..#BangTongHopTheoCaTheoNgayCoSum') IS NOT NULL DROP TABLE #BangTongHopTheoCaTheoNgayCoSum
		SELECT TimeDate,Shift0,Shift1,Shift2,Shift3,Unknown,ISNULL(Shift0,0)+ISNULL(Shift1,0)+ISNULL(Shift2,0)+ISNULL(Shift3,0)+ISNULL(Unknown,0) as Total FROM  
			(	SELECT *
				FROM [dbo].[#BangTongHopTheoCa]
			) AS SourceTable
			PIVOT  
			( 
						
				count(ShiftGroup) FOR ShiftGroup IN (Shift0,Shift1,Shift2,Shift3,Unknown)
			) AS PivotTable
	end
END
--exec sp_BangDangKyCaXoay '2019-07-01','2019-07-21',8,N'VN',null,null,null,null,null,null

--select * from udf_DangKyCa('2019-07-01','2019-07-21',182,null,null,null,null,null,null,null) where ShiftName is null
--select * from SmartBooks_LeaveType




GO
