CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_TimeKeeping_Data1] 
	-- Add the parameters for the stored procedure here
	@ID [int],
	@Employee_ID [nvarchar](50),
	@AccessDate [datetime],
	@AccessTime [datetime],
	@CardNumber [nvarchar](50),
	@Device_ID [nvarchar](100),
	@DeviceIP [varchar](20),
	@InOutStatus [varchar](10),
	@InsertSource [nvarchar](50),
	@Reason [nvarchar](100),
	@Remark [nvarchar](100),
	@UserName [nvarchar](50),
	@InsertDate [datetime]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	set @AccessTime=DATETIMEFROMPARTS(datepart(year,@AccessDate),datepart(MONTH,@AccessDate),datepart(day,@AccessDate),datepart(HOUR,@AccessTime),datepart(MINUTE,@AccessTime),datepart(SECOND,@AccessTime),0)
	set @InsertSource=null
	select @InsertSource=InsertSource from HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime=@AccessTime
	if @InsertSource is null begin
		set @InsertSource='NhapTay'
	end
	set @AccessTime=[dbo].[GhepGioVaoNgay](@AccessDate,@AccessTime)
	if @CardNumber is null begin
		set @CardNumber=@Employee_ID
	end
	if exists(select Employee_ID from HR_TimeKeeping_Data where (Employee_ID=@Employee_ID and AccessTime=@AccessTime) or ID=isnull(@ID,0))
	begin
		declare @DAccessDate datetime,@DAccessTime datetime
		select @DAccessDate=AccessDate,@DAccessTime=AccessTime from HR_TimeKeeping_Data where (Employee_ID=@Employee_ID and AccessTime=@AccessTime) or ID=isnull(@ID,0) 
		if not exists(select Employee_ID from HR_TimeKeeping_Data_Delete where Employee_ID=@Employee_ID and AccessTime=@DAccessTime) begin
			insert into HR_TimeKeeping_Data_Delete (Employee_ID,AccessDate,AccessTime,CardNumber,UserName,InsertDate) values(@Employee_ID,@DAccessDate,@DAccessTime,@Employee_ID,@UserName,GETDATE())
		end

		update HR_TimeKeeping_Data
		set Employee_ID=@Employee_ID,AccessDate=@AccessDate,AccessTime=@AccessTime,Device_ID=@Device_ID,InOutStatus=@InOutStatus,InsertSource=@InsertSource,Reason=@Reason,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
		where (Employee_ID=@Employee_ID and AccessTime=@AccessTime) or ID=isnull(@ID,0)
	end else begin
		insert into HR_TimeKeeping_Data
		(
			Employee_ID,
			AccessDate,
			AccessTime,
			Device_ID,
			CardNumber,
			DeviceIP,
			InOutStatus,
			InsertSource,
			Reason,
			Remark,
			UserName,
			InsertDate
		)
		values(@Employee_ID,@AccessDate,@AccessTime,@Device_ID,@CardNumber,@DeviceIP,@InOutStatus,@InsertSource,@Reason,@Remark,@UserName,GETDATE())
	end
END
GO
