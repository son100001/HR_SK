--exec [dbo].[usp_InsertUpdateHR_GoOut] null,N'WS000001','2021-12-31 00:00:00','2021-12-31 12:00:00','2021-12-31 14:00:00',N'Private',N'00-Shift0',N'admin','2021-12-31 12:25:56'
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_GoOut]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@TimeDate datetime,
	@TimeOut_ datetime,
	@TimeIn datetime,
	@LeaveType_ID nvarchar(50),
	@ShiftName nvarchar(50),
	@Remark nvarchar(max),
	@UserName nvarchar(50),
	@InsertDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao as nvarchar(max),@Shiftfromtime datetime
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@TimeDate,@UserName,'HR_GoOut')
	select @ShiftName=shiftname from hr_shifts where shiftname=@shiftname or [ShiftSign]=@shiftname
	--update du lieu
	if isnull(@ThongBao,'')='' begin
		select @Shiftfromtime=FromTime from HR_Shifts where ShiftName=@ShiftName
		if DATEPART(hour,@Shiftfromtime)<=DATEPART(hour,@TimeOut_) begin
			set @TimeOut_=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeOut_)
		end else begin
			set @TimeOut_=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeOut_)
		end
		if DATEPART(hour,@TimeOut_)<=DATEPART(hour,@TimeIn) begin
			set @TimeIn=[dbo].[GhepGioVaoNgay](@TimeOut_,@TimeIn)
		end else begin
			set @TimeIn=[dbo].[GhepGioVaoNgay](@TimeOut_+1,@TimeIn)
		end
		if exists(select Employee_ID from HR_GoOut where (Employee_ID=@Employee_ID and TimeOut_=@TimeOut_) or ID=isnull(@ID,0))
		begin
			update HR_GoOut
			set Employee_ID=@Employee_ID,TimeDate=@TimeDate,LeaveType_ID=@LeaveType_ID,ShiftName=@ShiftName,TimeOut_=@TimeOut_,TimeIn=@TimeIn,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and TimeDate=@TimeDate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_GoOut
			(
				Employee_ID,
				TimeDate,
				TimeOut_,
				TimeIn,
				LeaveType_ID,
				ShiftName,
				Remark,
				UserName,
				InsertDate
			)
			values(@Employee_ID,@TimeDate,@TimeOut_,@TimeIn,@LeaveType_ID,@ShiftName,@Remark,@UserName,GETDATE())
		end
	end
	select @ID=ID from HR_GoOut where Employee_ID=@Employee_ID and TimeDate=@TimeDate
	select @ThongBao as ThongBao,@ID as ID
END




GO
