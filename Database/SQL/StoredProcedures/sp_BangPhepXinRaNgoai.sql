
CREATE PROCEDURE [dbo].[sp_BangPhepXinRaNgoai]
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
	@Emp nvarchar(50)=null
AS
BEGIN
	--exec [dbo].[sp_BangPhepXinRaNgoai] '2025-07-01','2025-07-31',4,'VN',Null,Null,Null,Null,Null,Null,N'C10851'
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @NgayCuoiThang datetime = EOMONTH(@todate), @NgayDauThang datetime
	set @NgayDauThang = DATEFROMPARTS(year(@NgayCuoiThang),Month(@NgayCuoiThang),1)

    -- Insert statements for procedure here
	if @TypeOfReport=1 begin--xin ra ngoài theo chiều dọc
		select
		empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,xrn.Employee_ID,xrn.TimeDate
		,cast(xrn.TimeOut_ as time(0)) as TimeOut_Edit
		,xrn.TimeOut_
		,cast(xrn.TimeIn as time(0)) as TimeIn_Edit
		,xrn.TimeIn
		,xrn.GioVaoThucTe
		,xrn.[LeaveType_ID] as LoaiXinRaNgoai
		,xrn.ShiftName
		--,[dbo].[udf_TinhGioXinRaNgoai](xrn.ShiftName,xrn.TimeDate,xrn.TimeOut_,xrn.TimeIn,1) as RealHour
		--,[dbo].[udf_TinhGioXinRaNgoai](xrn.shiftName,xrn.TimeDate,xrn.TimeOut_,xrn.TimeIn,0) as TotalHour
		,xrn.Remark,xrn.InsertDate,xrn.UserName,xrn.ID
		from
		[dbo].[HR_GoOut] xrn
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		on xrn.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		where xrn.TimeDate between @fromdate and @todate
		and (case when @Emp is null or @Emp='' then '' else xrn.Employee_ID end)=ISNULL(@Emp,'')
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID, StartedDate,xrn.timedate
	end else if @TypeOfReport=2 begin--xin ra ngoài theo chiều ngang
		declare @s nvarchar(max); set @s=''
		select @s=@s + '[' + CONVERT(varchar(12),Date_,111) + '],' From [udf_BangThoiGian](@fromdate, @todate)
		set @s= left(@s,len(@s)-1)
		 IF OBJECT_ID('tempdb..#tab') IS NOT NULL DROP TABLE #tab
		 create table #tab(Employee_ID nvarchar(50))
		 Declare @dtNext datetime,@sql nvarchar(max)
		 set @dtNext=@fromdate
		 while @dtNext<=@todate begin
			set @sql='alter table #tab add [' + CONVERT(varchar(12),@dtNext,103) + '] nvarchar(20)'
			exec (@sql)
			set @dtNext=@dtNext+1
		 end
		set @sql = 'insert into #tab
					SELECT * FROM  
					(	SELECT Employee_ID,timedate,LeaveType_ID+'''+'/'+'''+left(convert(varchar, TimeOut_, 8),5)+'''+'~'+'''+left(convert(varchar, TimeIn, 8),5) as abc
						FROM [dbo].[HR_GoOut] where timedate between @fromdate and @todate) AS SourceTable  
					PIVOT  
					( 
						
						Max(abc) FOR timedate IN (@s1)
					) AS PivotTable '

		set @sql = REPLACE(@sql, '@s1', @s)
		EXECUTE sp_executesql @sql
				  , N'@fromdate datetime, @todate datetime'
				  , @fromdate = @fromdate  
				  , @todate = @todate
		select
		empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate
		,xrn.*
		from
		#tab xrn
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		on xrn.Employee_ID COLLATE DATABASE_DEFAULT=empl.Employee_ID
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Position_ID,empl.PositionCategory_ID,empl.StartedDate
	end else if @TypeOfReport=3 begin--giừo xin ra ngoài từ dữ liệu quẹt thẻ
		DECLARE @GoOut TABLE
		(
			[ID] int,
			[Employee_ID] nvarchar(50),
			[TimeDate] datetime,
			[TimeOut_] datetime,
			[TimeIn] datetime,
			[LeaveType_ID] nvarchar(50),
			[ShiftName] nvarchar(50),
			[Remark] nvarchar(max),
			[UserName] nvarchar(50),
			[InsertDate] datetime
		)
		INSERT INTO @GoOut([Employee_ID],[TimeDate],[TimeOut_],[TimeIn],[LeaveType_ID],[ShiftName],[Remark])
		select giora.Employee_ID,giora.OT_date,giora.GioRa,giovao.GioVao,N'Business',giora.ShiftName,'MayChamCong' from
		(
			select tkd.Employee_ID,tito.OT_date,min(tkd.AccessTime) as GioRa,tito.ShiftName from
			HR_TimeIn_TimeOut tito
			left join
			HR_TimeKeeping_Data tkd
			on tito.Employee_ID=tkd.Employee_ID and tkd.AccessTime between DATEADD(MINUTE,5,tito.TimeIn) and DATEADD(minute,-5,tito.[TimeOut])
			where tito.OT_date between @fromdate and @todate
			group by tkd.Employee_ID,tito.OT_date,tito.ShiftName
		)GioRa
		left join
		(
			select tkd.Employee_ID,tito.OT_date,max(tkd.AccessTime) as GioVao from
			HR_TimeIn_TimeOut tito
			left join
			HR_TimeKeeping_Data tkd
			on tito.Employee_ID=tkd.Employee_ID and tkd.AccessTime between DATEADD(MINUTE,5,tito.TimeIn) and DATEADD(minute,-5,tito.[TimeOut])
			where tito.OT_date between @fromdate and @todate
			group by tkd.Employee_ID,tito.OT_date
		)GioVao
		on giora.Employee_ID=giovao.Employee_ID and giora.OT_date=giovao.OT_date
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		on GioRa.Employee_ID=empl.Employee_ID
		where DATEDIFF(MINUTE,GioRa.GioRa,giovao.GioVao)>=30
		--Declare @Employee_ID nvarchar(50),@OldEmployee_ID nvarchar(50),@AccessTime datetime,@OldAccessTime datetime,@InOutStatus int,@OldInOutStatus int,@OT_date datetime,@OldOT_date datetime,@ShiftName nvarchar(50),@OldShiftName nvarchar(50)
		--DECLARE cur CURSOR LOCAL FOR
		--select tkd.Employee_ID,tito.OT_date,tkd.AccessTime,tkd.InOutStatus,tito.ShiftName from
		--HR_TimeIn_TimeOut tito
		--left join
		--HR_TimeKeeping_Data tkd
		--on tito.Employee_ID=tkd.Employee_ID and tkd.AccessTime between DATEADD(MINUTE,5,tito.TimeIn) and DATEADD(minute,-5,tito.[TimeOut])
		--left join
		--[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		--on tkd.Employee_ID=empl.Employee_ID
		--where OT_date between @fromdate and @todate and tkd.Employee_ID is not null and empl.Employee_ID is not null
		--order by Employee_ID,tito.OT_date,tkd.AccessTime
		--OPEN  cur
		--FETCH NEXT FROM cur INTO @Employee_ID,@OT_date,@AccessTime,@InOutStatus,@ShiftName
		--WHILE @@FETCH_STATUS = 0
		--BEGIN
		--	if @InOutStatus=1 begin
		--		if (@Employee_ID<>isnull(@OldEmployee_ID,'') or (@Employee_ID=@OldEmployee_ID and DATEDIFF(MINUTE,@OldAccessTime,@AccessTime)>=5)) begin
		--			if not exists(select Employee_ID from @GoOut where Employee_ID=@Employee_ID and TimeDate=@OT_date and TimeOut_=@AccessTime) begin
		--				insert into @GoOut ([Employee_ID],[TimeDate],[TimeOut_],[LeaveType_ID],[ShiftName],[Remark])
		--				values(@Employee_ID,@OT_date,@AccessTime,N'Business',@ShiftName,N'MayChamCong')
		--			end
		--		end
		--	end else begin
		--		if exists(select Employee_ID from @GoOut where Employee_ID=@Employee_ID and TimeDate=@OT_date and TimeIn is null) begin
		--			update @GoOut set TimeIn=@AccessTime where Employee_ID=@Employee_ID and TimeDate=@OT_date and TimeIn is null
		--		end
		--	end
		--	set @OldEmployee_ID=@Employee_ID set @OldAccessTime=@AccessTime set @OldInOutStatus=@InOutStatus set @OldOT_date=@OT_date
		--FETCH NEXT FROM cur INTO @Employee_ID,@OT_date,@AccessTime,@InOutStatus,@ShiftName
		--END
		--CLOSE cur
		--DEALLOCATE cur
		select empl.Position
		,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName
		,g.Employee_ID,g.TimeDate
		,g.TimeOut_
		,cast(g.TimeOut_ as time(0)) as TimeOut_Edit
		,g.TimeIn
		,cast(g.TimeIn as time(0)) as TimeIn_Edit
		,g.[LeaveType_ID]
		,g.ShiftName
		--,[dbo].[udf_TinhGioXinRaNgoai](g.ShiftName,g.TimeDate,g.TimeOut_,g.TimeIn,1) as RealHour
		--,[dbo].[udf_TinhGioXinRaNgoai](g.shiftName,g.TimeDate,g.TimeOut_,g.TimeIn,0) as TotalHour
		,g.Remark,g.InsertDate,g.UserName,g.ID
		from
		@GoOut g
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@todate,GETDATE())) empl
		on g.Employee_ID=empl.Employee_ID
		left join
		HR_GoOut go_
		on g.Employee_ID=go_.Employee_ID and g.TimeOut_=go_.TimeOut_
		where go_.Employee_ID is null
	end 
	else if @TypeOfReport = 4 begin
    select 
            lrg.TrangThai, lrg.LeaveType_ID, lrg.TimeDate, lrg.TimeOut_, lrg.TimeIn,
            lrg.ShiftName, lrg.Remark, lrg.ApproveDate,
            lrg.ApproverName as Approver, lrg.ApproveLevel as ApproverCurrent,
            lrg.ID, lrg.InsertDate
    from
        udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
    left join
        HR_LeaveRequestGoOut lrg
        on lrg.Employee_ID = empl.Employee_ID
    where lrg.TimeDate between @fromdate and @todate  -- ✅ sửa tại đây

    union

    select 
            'Approved' as TrangThai,
            goout.LeaveType_ID, goout.TimeDate, goout.TimeOut_, goout.TimeIn,
            goout.ShiftName, goout.Remark, goout.InsertDate as ApproveDate,
            goout.UserName as Approver, null as ApproverCurrent,
            goout.ID as ID, goout.InsertDate
    from
        udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
    left join
        HR_GoOut goout
        on empl.Employee_ID = goout.Employee_ID
    where goout.TimeDate between @fromdate and @todate  -- ✅ sửa tại đây
    order by TimeDate;

	--else if @TypeOfReport = 4 begin
	--	select 
	--			lrg.TrangThai, lrg.LeaveType_ID, lrg.TimeDate, lrg.TimeOut_, lrg.TimeIn 
	--			, lrg.ShiftName, lrg.Remark, lrg.ApproveDate
	--			, lrg.ApproverName as Approver, lrg.ApproveLevel as ApproverCurrent--, lrg.ApproveDate
	--			, lrg.ID, lrg.InsertDate
	--	from
	--	udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
	--	left join
	--	HR_LeaveRequestGoOut lrg
	--	on lrg.Employee_ID = empl.Employee_ID
	--	--left join
	--	--udf_GetApprover (@Emp,1,'VN') gap
	--	--on gap.Code = lrg.Employee_ID
	--	where lrg.TimeDate between @NgayDauThang - 15 and @NgayCuoiThang + 15
	--	--exec [dbo].[sp_BangPhepXinRaNgoai] '2025-01-01','2025-12-31',4,'VN',Null,Null,Null,Null,Null,Null,N'C10851'

	--	union
	--	select 
	--			'Approved' as TrangThai
	--			, goout.LeaveType_ID, goout.TimeDate, goout.TimeOut_, goout.TimeIn
	--			, goout.ShiftName, goout.Remark, goout.InsertDate as ApproveDate
	--			, goout.UserName as Approver, null as ApproverCurrent
	--			, goout.ID as ID,goout.InsertDate
	--	from
	--	udf_EmployeeFilter (@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,@todate) empl
	--	left join
	--	HR_GoOut goout
	--	on empl.Employee_ID = goout.Employee_ID
	--	where goout.TimeDate between @NgayDauThang - 15 and @NgayCuoiThang + 15
	--	ORDER by TimeDate
	end else if @TypeOfReport = 5 begin
		select 
				empl.PositionFullName as DepartmentName, empl.Employee_ID, dbo.udf_FullName (empl.Employee_Firstname, empl.Employee_LastName) as FullName, lrg.TrangThai, lrg.LeaveType_ID, lrg.TimeDate, lrg.TimeOut_, lrg.TimeIn 
				, lrg.ShiftName, lrg.Remark
				, rlh.Approver_Name as LastestApprover, rlh.Approve_Date as LastestApproveDate
				, lrg.ID, lrg.InsertDate
		from
		HR_LeaveRequestGoOut lrg
		left join
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
		on lrg.Employee_ID = empl.Employee_ID
		left join
		(
			select *, ROW_NUMBER () over (partition by Request_ID order by Approve_Date) as rn
			from
			HR_RequestLeaveGoOut_History rlh
		) rlh
		on lrg.ID = rlh.Request_ID and rn = 1
		where lrg.TimeDate between @fromdate and @todate and lrg.ApproveLevel = @Emp and TrangThai = 'Pending'
		order by lrg.TimeOut_ desc
		--exec [dbo].[sp_BangPhepXinRaNgoai] '2025-01-01','2025-12-31',4,'VN',Null,Null,Null,Null,Null,Null,N'C10851'
	end else if @TypeOfReport = 6 begin
		select 
				empl.PositionFullName as DepartmentName, empl.Employee_ID, dbo.udf_FullName (empl.Employee_Firstname, empl.Employee_LastName) as FullName, 'Approved' as TrangThai, got.LeaveType_ID, got.TimeDate, got.TimeOut_, got.TimeIn, got.GioVaoThucTe
				, got.ShiftName, got.Remark
				, dbo.udf_FullName (emplDV.Employee_Firstname, emplDV.Employee_LastName) as Approver, got.InsertDate as ApproveDate
				, got.ID, got.InsertDate
		from
		HR_GoOut got
		left join
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) empl
		on got.Employee_ID = empl.Employee_ID
		left join
		udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,GETDATE()) emplDV
		on got.UserName = emplDV.Employee_ID
		where got.TimeDate between @fromdate and @todate
		order by got.[TimeOut_]
		--exec [dbo].[sp_BangPhepXinRaNgoai] '2025-01-01','2025-12-31',4,'VN',Null,Null,Null,Null,Null,Null,N'C10851'
	end
END



GO
