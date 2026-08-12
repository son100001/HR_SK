CREATE FUNCTION [dbo].[DuLieuQuet]  
(
	--select * from DuLieuQuet ('2023-04-01','2023-04-30') where Employee_ID = '17020003'
	-- Add the parameters for the function here
	@fromdate datetime,
	@todate datetime
)
RETURNS  @rtnDuLieuQuet TABLE 
(
    -- columns returned by the function
	[Employee_ID] [nvarchar](50) NOT NULL,
	[AccessDate] [datetime] NULL,
	[AccessTime] [datetime] NOT NULL,
	[Device_ID] [varchar](50) NULL,
	[CardNumber] [nvarchar](50) NOT NULL,
	[DeviceIP] [varchar](20) NULL,
	[InOutStatus] [varchar](10) NULL,
	[InsertSource] [nvarchar](50) NULL,
	[Reason] [nvarchar](100) NULL,
	[Remark] [nvarchar](100) NULL,
	[UserName] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	primary key ([Employee_ID],[AccessTime])
)
AS
BEGIN
	-- Declare the return variable here
	insert @rtnDuLieuQuet
	select [Employee_ID],
		[AccessDate],
		[AccessTime],
		[Device_ID],
		[CardNumber],
		[DeviceIP],
		[InOutStatus],
		[InsertSource],
		[Reason],
		[Remark],
		[UserName],
		[InsertDate] from hr_timekeeping_Data where [AccessDate] between @fromdate and @todate

	--xóa dữ liệu quẹt 
	delete dlq from
	@rtnDuLieuQuet dlq
	inner join
	HR_DuLieuQuetVaoRa dlqvr
	on dlq.Employee_ID=dlqvr.Employee_ID and dlq.accesstime between dlqvr.TimeIn and dlqvr.[TimeOut]

	-- thêm dữ liệu quẹt từ HR_DuLieuQuetVaoRa
	insert @rtnDuLieuQuet
	select [Employee_ID],
		DATEFROMPARTS(year(TimeIn),month(TimeIn),day(TimeIn)) as [AccessDate],
		TimeIn as [AccessTime],
		null as Device_ID,
		[Employee_ID],
		null as [DeviceIP],
		'I' as [InOutStatus],
		'NhapTay' as [InsertSource],
		null as [Reason],
		N'Sửa từ CHẤM CÔNG THEO NGÀY' as [Remark],
		[UserName],
		[InsertDate] from
		HR_DuLieuQuetVaoRa where Ngay between @fromdate and @todate
		union all
	select [Employee_ID],
		DATEFROMPARTS(year([TimeOut]),month([TimeOut]),day([TimeOut])) as [AccessDate],
		[TimeOut] as [AccessTime],
		null as Device_ID,
		[Employee_ID],
		null as [DeviceIP],
		'O' as [InOutStatus],
		'NhapTay' as [InsertSource],
		null as [Reason],
		N'Sửa từ CHẤM CÔNG THEO NGÀY' as [Remark],
		[UserName],
		[InsertDate] from
		HR_DuLieuQuetVaoRa where Ngay between @fromdate and @todate

	RETURN 

END




GO
