CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_DangKyPhepTheoGio]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@DateLeave datetime,
	@TypeOfLeave varchar(50),
	@HourLeave float,
	@LeaveType_ID nvarchar(50),
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
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@DateLeave,@UserName,'HR_DangKyPhepTheoGio')
	--if exists(select LeaveType_ID from smartbooks_leaveType where LeaveType_ID=@LeaveType_ID and phepnam=1) begin
	--	set @ThongBao=N'Bankhongcoquyenthaydoi'
	--end
	if ISNULL(@thongbao,'')='' begin
		if isnull(@LeaveType_ID,'')<>'' and @HourLeave is not null begin
			if exists(select Employee_ID from HR_DangKyPhepTheoGio where (Employee_ID=@Employee_ID and DateLeave=@DateLeave and [TypeOfLeave]=@TypeOfLeave) or ID=isnull(@ID,0))
			begin
				update HR_DangKyPhepTheoGio
				set Employee_ID=@Employee_ID, DateLeave=@DateLeave,TypeOfLeave=@TypeOfLeave,HourLeave=@HourLeave,LeaveType_ID=@LeaveType_ID,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
				where (Employee_ID=@Employee_ID and DateLeave=@DateLeave and [TypeOfLeave]=@TypeOfLeave) or ID=isnull(@ID,0)
			end else begin
				insert into HR_DangKyPhepTheoGio
				(
					[Employee_ID],
					DateLeave,
					TypeOfLeave,
					HourLeave,
					LeaveType_ID,
					[Remark],
					[InsertDate],
					[UserName]
				)
				values(@Employee_ID,@DateLeave,@TypeOfLeave,@HourLeave,@LeaveType_ID,@Remark,GETDATE(),@UserName)
			end
			select @ID=ID from HR_DangKyPhepTheoGio where Employee_ID=@Employee_ID and DateLeave=@DateLeave and [TypeOfLeave]=@TypeOfLeave
		end
	end
	select @ThongBao as ThongBao,@ID as ID
END




GO
