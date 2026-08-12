CREATE PROCEDURE [dbo].[sp_BangDuLieuQuet]
--exec [dbo].[sp_BangDuLieuQuet] '2025-9-3','2025-9-3',7,'VN',N'',N'',N'',N'',N'','',null
--exec [dbo].[sp_BangDuLieuQuet] '2019-5-1','2019-5-11'
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
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @SoNgaySauKhiBangBauDuocHuongThaiSan int
	select @SoNgaySauKhiBangBauDuocHuongThaiSan=value from setup where id='SoNgaySauKhiMangBauDuocHuongThaiSan'
	
	IF @TypeOfReport=1
	BEGIN
		select tkd.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName
			,empl.FactoryName, empl.DepartmentName, empl.SectionName, empl.ChucDanhName
			,tkd.AccessDate,tkd.AccessTime,cast(tkd.AccessTime as time(0)) as AccessTime_Edit
			,tkd.CardNumber,tkd.InsertSource,tkd.Device_ID,InOutStatus,tkd.Reason,tkd.Remark,erml.LeaveType_ID,tkd.InsertDate,tkd.UserName,tkd.ID
		from
		HR_TimeKeeping_Data tkd
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,ISNULL(@todate,GETDATE())) empl
		on tkd.Employee_ID=empl.Employee_ID
		left join
		[dbo].[HR_EmployeeRegisMaternityLeave] erml
		on tkd.InOutStatus='I' and tkd.Employee_ID=erml.Employee_ID and tkd.AccessDate between erml.Fromdate and erml.ToDate
		where tkd.AccessDate between @fromdate and @todate and empl.Employee_ID is not null
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Employee_ID/*,empl.StartedDate*/,tkd.AccessDate
	END
	
	
	ELSE if @TypeOfReport=2
	BEGIN-- quẹt vào sai ca
		select
		empl.Position,qv.Employee_ID,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName
		,qv.AccessDate,cast(qv.AccessTime as time) as TimeIn,cast(qr.AccessTime as time) as [TimeOut_],dkc.ShiftName,cast(s.fromtime as time) as fromtime,cast(s.totime as time) as totime
		,motBefore.maxovertime as OTTruoc,motAfter.maxovertime as OTSau,motFull.maxovertime as OTCN_Le
		from
		[dbo].[udf_BangQuetVao](@fromdate,@todate) qv
		left join
		[dbo].[udf_BangQuetRa](@fromdate,@todate) qr
		on qv.Employee_ID=qr.Employee_ID and qv.AccessDate=qr.AccessDate
		left join
		udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiBangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
		on qv.Employee_ID=dkc.Employee_ID and qv.AccessDate=dkc.AccessDate
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,ISNULL(@todate,GETDATE())) empl
		on qv.Employee_ID=empl.Employee_ID
		left join
		HR_Shifts s
		on dkc.ShiftName=s.ShiftName
		left join
		HR_MaxOverTime motBefore
		on qv.Employee_ID=motBefore.Employee_ID and qv.accessdate=motBefore.workingdate and motBefore.TypeOfOT='2' and motBefore.ShiftName=dkc.ShiftName
		left join
		HR_MaxOverTime motAfter
		on qv.Employee_ID=motAfter.Employee_ID and qv.accessdate=motAfter.workingdate and motAfter.TypeOfOT='1' and motAfter.ShiftName=dkc.ShiftName
		left join
		HR_MaxOverTime motFull
		on qv.Employee_ID=motFull.Employee_ID and qv.accessdate=motFull.workingdate and motFull.TypeOfOT in ('4','5') and motFull.ShiftName=dkc.ShiftName

		where empl.Employee_ID is not null
			and 
			(
				DATEDIFF(minute,qv.AccessTime,dateadd(minute,0-isnull(motBefore.maxovertime,0)*60,[dbo].[GhepGioVaoNgay](qv.AccessDate,s.fromtime)))>15
				or
				DATEDIFF(minute,dateadd(minute,isnull(motAfter.maxovertime,0)*60,[dbo].[GhepGioVaoNgay]((case when datepart(Hour,s.fromtime)>datepart(hour,s.totime) then qv.AccessDate+1 else qv.AccessDate end),s.totime)),qr.AccessTime)>15
				or
				(motFull.maxovertime is not null and DATEDIFF(minute
																--,dateadd(minute,isnull(motFull.maxovertime,0)*60,[dbo].[GhepGioVaoNgay](qv.AccessDate,s.fromtime))
																,(case when DATEDIFF(minute, [dbo].[GhepGioVaoNgay](qv.AccessDate,s.FromTime),[dbo].[GhepGioVaoNgay]((case when datepart(HOUR,s.FromTime)<datepart(HOUR,s.ToTime) then qv.AccessDate else qv.AccessDate+1 end),s.ToTime))<=480 then dateadd(minute,isnull(motFull.maxovertime,0)*60,[dbo].[GhepGioVaoNgay](qv.AccessDate,s.FromTime))
																		else (case when dateadd(minute,isnull(motFull.maxovertime,0)*60, [dbo].[GhepGioVaoNgay](qv.AccessDate,s.FromTime))>(case when DATEPART(HOUR,s.FromTime)<DATEPART(HOUR,s.RestTimeFrom) then [dbo].[GhepGioVaoNgay](qv.AccessDate,s.RestTimeFrom) else [dbo].[GhepGioVaoNgay](qv.AccessDate+1,s.RestTimeFrom) end) then dateadd(minute,isnull(motFull.maxovertime,0)*60+DATEDIFF(minute,(case when DATEPART(HOUR,s.FromTime)<DATEPART(HOUR,s.RestTimeFrom) then [dbo].[GhepGioVaoNgay](qv.AccessDate,s.RestTimeFrom) else [dbo].[GhepGioVaoNgay](qv.AccessDate+1,s.RestTimeFrom) end),(case when DATEPART(HOUR,s.FromTime)<DATEPART(HOUR,s.RestTimeTo) then [dbo].[GhepGioVaoNgay](qv.AccessDate,s.RestTimeTo) else [dbo].[GhepGioVaoNgay](qv.AccessDate+1,s.RestTimeTo) end)), [dbo].[GhepGioVaoNgay](qv.AccessDate,s.FromTime))
																					else dateadd(minute,isnull(motFull.maxovertime,0)*60, [dbo].[GhepGioVaoNgay](qv.AccessDate,s.FromTime))
																				end)
																	end)
																,qr.AccessTime)>15)
				or
				(motFull.maxovertime is not null and DATEDIFF(minute,qv.AccessTime,[dbo].[GhepGioVaoNgay](qv.AccessDate,s.fromtime))>15)
			)
			
	END
	
	
	ELSE if @TypeOfReport=3
	BEGIN-- Danh sách đã quẹt thẻ theo ca
		 WITH tabDQTTC AS (
			SELECT 
					tabDQTTC.Employee_ID,tabDQTTC.AccessDate,tabDQTTC.AccessTime,tabDQTTC.ShiftName
				   ,ROW_NUMBER() OVER(PARTITION BY tabDQTTC.Employee_ID,tabDQTTC.AccessDate
										 ORDER BY tabDQTTC.Employee_ID,tabDQTTC.AccessTime asc) AS rk
			  FROM
			  (
					select dkc.Employee_ID,dkc.AccessDate,tkd.AccessTime,dkc.ShiftName
					from
					udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiBangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
					left join
					HR_Shifts s
					on dkc.ShiftName=s.ShiftName
					left join
					HR_MaxOverTime motBefore
					on dkc.Employee_ID=motBefore.Employee_ID and dkc.accessdate=motBefore.workingdate and motBefore.TypeOfOT='2' and motBefore.ShiftName=dkc.ShiftName
					left join
					HR_TimeKeeping_Data tkd
					on dkc.Employee_ID=tkd.Employee_ID and tkd.AccessTime between DATEADD(minute,-120-isnull(motBefore.[maxovertime],0)*60,[dbo].[GhepGioVaoNgay](dkc.accessdate,s.FromTime)) and DATEADD(hour,8,[dbo].[GhepGioVaoNgay](dkc.accessdate,s.FromTime))
					where tkd.Employee_ID is not null
				)tabDQTTC)

		SELECT 
			empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName
			,s.Employee_ID,s.AccessDate,s.AccessTime,s.ShiftName
			FROM
			tabDQTTC s
			left join
			udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,ISNULL(@todate,GETDATE())) empl
			on s.Employee_ID=empl.Employee_ID
			 WHERE s.rk = 1 and empl.Employee_ID is not null
	END
	
	
	ELSE if @TypeOfReport=4
	BEGIN-- Danh sách chưa có dữ liệu quẹt thẻ theo ca
		 select empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,
				dkc.Employee_ID,dkc.AccessDate,dkc.ShiftName,erml.LeaveType_ID
			from
			udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiBangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@Emp) dkc
			left join
			HR_Shifts s
			on dkc.ShiftName=s.ShiftName
			left join
			HR_MaxOverTime motBefore
			on dkc.Employee_ID=motBefore.Employee_ID and dkc.accessdate=motBefore.workingdate and motBefore.TypeOfOT='2' and motBefore.ShiftName=dkc.ShiftName
			left join
			HR_TimeKeeping_Data tkd
			on dkc.Employee_ID=tkd.Employee_ID and tkd.AccessTime between DATEADD(minute,-60-isnull(motBefore.[maxovertime],0)*60,[dbo].[GhepGioVaoNgay](dkc.accessdate,s.FromTime)) and DATEADD(hour,8+isnull(s.ChanCuoi,0),[dbo].[GhepGioVaoNgay](dkc.accessdate,s.FromTime))
			left join
			[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,@fact,@dept,@sect,@team,@pos,@posc,null,null) erml
			on dkc.Employee_ID=erml.Employee_ID and dkc.AccessDate=erml.DateLeave
			left join
			udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,ISNULL(@todate,GETDATE())) empl
			on dkc.Employee_ID=empl.Employee_ID
			where tkd.Employee_ID is null and erml.Employee_ID is null and empl.Employee_ID is not null and GETDATE()>=DATEADD(minute,-15,[dbo].[GhepGioVaoNgay](GETDATE(),s.FromTime))
	END
	
	ELSE if @TypeOfReport=5
	BEGIN-- danh sách dữ liệu quẹt xóa
		select empl.FactoryName, empl.DepartmentName,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,tkdd.Employee_ID,tkdd.AccessDate,cast(tkdd.AccessTime as time) as AccessTime,tkdd.CardNumber/*,tkdd.InsertSource*/,tkdd.Device_ID,tkdd.Remark,tkdd.InsertDate,tkdd.UserName,tkdd.ID
		from
		HR_TimeKeeping_Data_Delete tkdd
		left join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,ISNULL(@todate,GETDATE())) empl
		on tkdd.Employee_ID=empl.Employee_ID
		where tkdd.AccessDate between @fromdate and @todate
		order by empl.DepartmentCode,empl.SectionCode,empl.TeamCode,empl.Employee_ID/*,empl.StartedDate*/,tkdd.AccessDate
	END
	

	ELSE if @typeofreport=6
	BEGIN
		select empl.Position,[dbo].[udf_FullName](empl.Employee_Firstname,empl.Employee_LastName)as FullName,dlq.Employee_ID,dlq.AccessDate
			,cast(dlq.Q01 as time) as Q01
			,cast(dlq.Q02 as time) as Q02
			,cast(dlq.Q03 as time) as Q03
			,cast(dlq.Q04 as time) as Q04
			,cast(dlq.Q05 as time) as Q05
			,cast(dlq.Q06 as time) as Q06
			,cast(dlq.Q07 as time) as Q07
			,cast(dlq.Q08 as time) as Q08
			,cast(dlq.Q09 as time) as Q09
			,cast(dlq.Q10 as time) as Q10
		from
		[dbo].[udf_DuLieuQuet_Horizontal](@fromdate,@todate,null) dlq
		inner join
		udf_EmployeeFilter(@LAN,@fact,@dept,@sect,@team,@pos,@posc,@Emp,ISNULL(@todate,GETDATE())) empl
		on dlq.Employee_ID=empl.Employee_ID
		where dlq.AccessDate between @fromdate and @todate
		order by empl.position,empl.Employee_ID,dlq.AccessDate
	end



	ELSE IF @TypeOfReport=7
	BEGIN --Xuất Danh sách quẹt thẻ theo ngày

		SELECT 
			tkd.Employee_ID
			,dbo.udf_FullName(empl.Employee_Firstname,empl.Employee_LastName) AS FullName
			,empl.FactoryName
			,empl.DepartmentName
			,empl.SectionName
			,empl.ChucDanhName
			,tkd.AccessDate
			,tkd.AccessTime
			,s.ShiftSign
			--,NULL AS DepCode
		FROM
		(
			SELECT *
			FROM dbo.HR_TimeKeeping_Data
			WHERE AccessDate =@fromdate
		) tkd
		left JOIN
        dbo.udf_EmployeeFilter('VN',@fact,@dept,@sect,@team,@pos,@posc,NULL,@todate) empl
		ON tkd.Employee_ID=empl.Employee_ID
		LEFT JOIN
		dbo.udf_DangKyCa(@fromdate,@fromdate,@SoNgaySauKhiBangBauDuocHuongThaiSan,@fact,@dept,@sect,@team,@pos,@posc,null) dkc
		ON tkd.Employee_ID=dkc.Employee_ID
        LEFT JOIN
		dbo.HR_Shifts s
		ON dkc.ShiftName=s.ShiftName
		WHERE empl.Employee_ID IS NOT NULL 
	END 

END




GO
