CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_RoundShift]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@ShiftName nvarchar(50),
	@FromDate datetime,
	@ToDate datetime,
	@TypeOfRegister int,
	@ExtraHours float,
	@GioTCTruoc float,
	@Remark nvarchar(max),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	select @ShiftName=shiftname from hr_shifts where shiftname=@shiftname or [ShiftSign]=@shiftname
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@FromDate,@UserName,'HR_RoundShift')
	if @ToDate<@Fromdate begin
		set @ThongBao=N'Dulieukhonghople'
	end
	if @ToDate is not null begin
		set @TypeOfRegister=1
	end else begin
		set @TypeOfRegister=0
	end
	--if exists(select * from HR_RoundShift where Fromdate=@FromDate and [TypeOfRegister]=@TypeOfRegister and Employee_ID=@Employee_ID and ID<>isnull(@ID,0)) begin
	--	set @ThongBao=@ThongBao+N'ĐK ca trùng với với ca trước đó;'
	--end
	if ISNULL(@thongbao,'')='' begin
			
		if exists(select Employee_ID from HR_RoundShift where (Employee_ID=@Employee_ID and Fromdate=@Fromdate and [TypeOfRegister]=@TypeOfRegister) or ID=isnull(@ID,0))
		begin
			update HR_RoundShift
			set Employee_ID=@Employee_ID, ShiftName=@ShiftName,Fromdate=@Fromdate,ToDate=@ToDate,TypeOfRegister=@TypeOfRegister,ExtraHours=@ExtraHours,GioTCTruoc=@GioTCTruoc,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and Fromdate=@Fromdate and TypeOfRegister=@TypeOfRegister) or ID=isnull(@ID,0)
		end else begin
			insert into HR_RoundShift
			(
				[Employee_ID],
				[ShiftName],
				[Fromdate],
				[ToDate],
				[TypeOfRegister],
				ExtraHours,
				GioTCTruoc,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Employee_ID,@ShiftName,@Fromdate,@ToDate,@TypeOfRegister,@ExtraHours,@GioTCTruoc,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_RoundShift where Employee_ID=@Employee_ID and Fromdate=@Fromdate and [TypeOfRegister]=@TypeOfRegister
		select @ThongBao as ThongBao,@ID as ID
END




GO
