CREATE FUNCTION [dbo].[udf_PhepVaDuLieuQuetLienQuan]
(
	-- Add the parameters for the function here
	--select * from [dbo].[udf_BangNghiPhepVanCoDuLieuQuet]('2019-12-01','2019-12-06',null,null,null,null,null,null,null)
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null,
	@Employee_ID_ nvarchar(50)=null
)
RETURNS  @rtnTable TABLE 
(
    -- columns returned by the function
    [Employee_ID] nvarchar(50),DateLeave datetime,LeaveType_ID nvarchar(50),ShiftName nvarchar(50),GioNghiTu datetime,GioNghiDen datetime,AccessTime datetime--,primary key ([Employee_ID],AccessTime)
)
AS
BEGIN
	declare @SoNgaySauKhiMangBauDuocHuongThaiSan int
	select @SoNgaySauKhiMangBauDuocHuongThaiSan=[Value] from [dbo].[SetUp] where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'
	
	insert into @rtnTable
	select erml.Employee_ID,erml.DateLeave,erml.LeaveType_ID,s.ShiftName
	,case when LeaveType_ID<>32 then [dbo].[GhepGioVaoNgay](erml.DateLeave,s.fromtime)
		else dateadd(hour,4,[dbo].[GhepGioVaoNgay](erml.DateLeave,s.fromtime)) end
	,case when LeaveType_ID=31 then dateadd(hour,4,[dbo].[GhepGioVaoNgay](erml.DateLeave,s.fromtime))
		else [dbo].[GhepGioVaoNgay](case when DATEPART(hour,s.fromtime)<datepart(hour,s.totime) then erml.DateLeave else erml.DateLeave+1 end,s.ToTime) end
	,tkd.AccessTime from
	[dbo].[udf_BangPhepTheoNgay](2,@fromdate,@todate,null,null,null,null,null,null,null,null) erml
	left join
	udf_DangKyCa(@fromdate,@todate,@SoNgaySauKhiMangBauDuocHuongThaiSan,null,null,null,null,null,null,null)erts
	on erml.Employee_id=erts.Employee_ID and erml.dateleave=erts.AccessDate
	left join
	HR_Shifts s
	on erts.ShiftName=s.ShiftName
	left join
	HR_MaxOvertime motA
	on erts.AccessDate=motA.workingdate and erts.Employee_ID=motA.Employee_id and motA.[TypeOfOT]='1'
	left join
	HR_MaxOvertime motB
	on erts.AccessDate=motB.workingdate and erts.Employee_ID=motB.Employee_id and motB.[TypeOfOT]='2'
	left join
	[dbo].[DuLieuQuet](@fromdate,@todate+1) tkd
	on erts.Employee_ID=tkd.Employee_ID and tkd.AccessTime between cast([dbo].[GhepGioVaoNgay](erts.AccessDate,dateadd(minute,-ISNULL(ChanDau,0)*60-isnull(motB.maxovertime,0)*60,s.FromTime)) as datetime)
																and
																dateadd(minute
																			,(case when motA.maxovertime is null then isnull(ChanCuoi,0)*60 else motA.maxovertime*60+60 end)
																			,[dbo].[GhepGioVaoNgay]((Case when DATEPART(hour,s.FromTime)<DATEPART(hour,s.ToTime) then erts.AccessDate else erts.AccessDate+1 end),s.ToTime)
																	)
	where tkd.AccessTime is not null and erml.LeaveType_ID <>50



	-- Return the result of the function
	RETURN 

END



GO
