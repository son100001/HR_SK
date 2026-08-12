
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[udf_InsertUpdateAccessTimeAndShift]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@isSaveShiftName bit,
	@TimeDate datetime,
	@ShiftName nvarchar(50),
	@ShiftRemark nvarchar(255),
	@TimeIn datetime,
	@TimeOut datetime,
	@TiToRemark nvarchar(255),
	@UserName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @fromtime datetime
	declare @InsertDate datetime
	select @fromtime=FromTime from HR_Shifts where ShiftName=@ShiftName
	if @fromtime is null begin
		return
	end
	if @isSaveShiftName=1 begin
		if exists(select * from HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate and ShiftName=@ShiftName) begin
			insert into HR_EmpRegisTimeSheet (Employee_ID,TimeDate,ShiftName,Remark,UserName,InsertDate)
			values(@Employee_ID,@TimeDate,@ShiftName,@ShiftRemark,@UserName,GETDATE())
		end
	end
	if DATEPART(HOUR,@TimeIn)>=DATEPART(HOUR,@fromtime) begin
		set @TimeIn=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeIn)
	end else begin
		set @TimeIn=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeIn)
	end
	if DATEPART(HOUR,@TimeOut)>=DATEPART(HOUR,@fromtime) begin
		set @TimeOut=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeOut)
	end else begin
		set @TimeOut=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeOut)
	end
	if not exists(select * from HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime=@TimeIn) and @TimeIn is not null begin
		insert into HR_TimeKeeping_Data (Employee_ID,[AccessDate],[AccessTime],[CardNumber],[InsertSource],Remark)
		values(@Employee_ID,@TimeDate,@TimeIn,@Employee_ID,'NhapTay',@TiToRemark)
	end
	if not exists(select * from HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime=@TimeOut) and @TimeOut is not null begin
		insert into HR_TimeKeeping_Data (Employee_ID,[AccessDate],[AccessTime],[CardNumber],[InsertSource],Remark)
		values(@Employee_ID,@TimeDate,@TimeOut,@Employee_ID,'NhapTay',@TiToRemark)
	end
END





GO
