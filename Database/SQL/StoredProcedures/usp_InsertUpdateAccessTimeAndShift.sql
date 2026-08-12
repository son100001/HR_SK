CREATE PROCEDURE [dbo].[usp_InsertUpdateAccessTimeAndShift]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@TimeDate datetime,
	@OldShiftName nvarchar(50),
	@NewShiftName nvarchar(50),
	@ShiftRemark nvarchar(255),
	@TimeIn datetime,
	@TimeOut datetime,
	@Reason varchar(100),
	@TiToRemark nvarchar(255),
	@UserName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @fromtime datetime,@totime datetime,@ti datetime, @to datetime,@ChanDau float, @ChanCuoi float,@InsertSource varchar(50)
	Declare @ThongBao nvarchar(255)
	set @InsertSource='NhapTay'
	if @Reason='TemporarilyCalculatedData' begin
		set @InsertSource='MayChamCong'
	end
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@TimeDate,@UserName,'HR_WTDaily')
	if ISNULL(@ThongBao,'')='' begin
		--LƯU CA
		--if isnull(@NewShiftName,'') <>'' begin
		--	if isnull(@OldShiftName,'')<>isnull(@NewShiftName,'') begin
		--		if not exists(select Employee_ID from HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate and ShiftName=@NewShiftName) begin
		--			if not exists(select Employee_ID from HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate) begin
		--				insert into HR_EmpRegisTimeSheet (Employee_ID,TimeDate,ShiftName,Remark,UserName,InsertDate)
		--				values(@Employee_ID,@TimeDate,@NewShiftName,@ShiftRemark,@UserName,GETDATE())
		--			end else begin
		--				update HR_EmpRegisTimeSheet set ShiftName=@NewShiftName,Remark=@ShiftRemark,UserName=@UserName,InsertDate=GETDATE() where Employee_ID=@Employee_ID and TimeDate=@TimeDate
		--			end
		--		end
		--	end
		--end else begin
		--	if exists(select Employee_ID from HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate) begin
		--		delete HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate
		--	end
		--end
		-- LƯU DỮ LIỆU QUẸT
		if @TimeIn is null or @TimeOut is null begin
			return
		end
		select @fromtime=FromTime,@totime=ToTime,@ChanDau=ChanDau,@ChanCuoi=ChanCuoi from HR_Shifts where ShiftName=isnull(@NewShiftName,@OldShiftName)
		if @fromtime is null begin
			return
		end

		set @fromtime=[dbo].[GhepGioVaoNgay](@TimeDate,@fromtime)
		if DATEPART(HOUR,@fromtime)<DATEPART(HOUR,@totime) begin--Ca trong ngay
			set @totime=[dbo].[GhepGioVaoNgay](@TimeDate,@totime)
		end else begin--ca qua dem
			set @totime=[dbo].[GhepGioVaoNgay](@TimeDate+1,@totime)
		end

		set @ti=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeIn)
		if @ti not between DATEADD(HOUR,0-@ChanDau,@fromtime) and DATEADD(HOUR,@ChanCuoi,@totime) begin
			set @ti=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeIn)
		end
		set @to=[dbo].[GhepGioVaoNgay](@TimeDate,@TimeOut)
		if @to not between DATEADD(HOUR,0-@ChanDau,@fromtime) and DATEADD(HOUR,@ChanCuoi,@totime) begin
			set @to=[dbo].[GhepGioVaoNgay](@TimeDate+1,@TimeOut)
		end
	
		if @ti<@to begin
			set @TimeIn=@ti
			set @TimeOut=@to
		end else begin
			set @TimeIn=@to
			set @TimeOut=@ti
		end
	
		if exists(select * from HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime between DATEADD(HOUR,0-@ChanDau,@fromtime) and DATEADD(HOUR,@ChanCuoi,@totime) and InsertSource=@InsertSource) begin
			delete HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime between DATEADD(HOUR,0-@ChanDau,@fromtime) and DATEADD(HOUR,@ChanCuoi,@totime) and InsertSource=@InsertSource
		end
	
		if not exists(select * from HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime=@TimeIn) begin
			insert into HR_TimeKeeping_Data (Employee_ID,[AccessDate],[AccessTime],[CardNumber],[InsertSource],InOutStatus,Reason,Remark,UserName,InsertDate)
			values(@Employee_ID,DATEFROMPARTS(DATEPART(YEAR,@TimeIn),DATEPART(MONTH,@TimeIn),DATEPART(DAY,@TimeIn)),@TimeIn,@Employee_ID,@InsertSource,0,@Reason,@TiToRemark,@UserName,GETDATE())
		end
		if not exists(select * from HR_TimeKeeping_Data where Employee_ID=@Employee_ID and AccessTime=@TimeOut) begin
			insert into HR_TimeKeeping_Data (Employee_ID,[AccessDate],[AccessTime],[CardNumber],[InsertSource],[InOutStatus],Reason,Remark,UserName,InsertDate)
			values(@Employee_ID,DATEFROMPARTS(DATEPART(YEAR,@TimeOut),DATEPART(MONTH,@TimeOut),DATEPART(DAY,@TimeOut)),@TimeOut,@Employee_ID,@InsertSource,1,@Reason,@TiToRemark,@UserName,GETDATE())
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END



GO
