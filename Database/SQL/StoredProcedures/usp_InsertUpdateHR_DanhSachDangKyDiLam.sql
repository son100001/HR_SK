
CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_DanhSachDangKyDiLam]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@Ngay datetime,
	@Remark nvarchar(255),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@Ngay,@UserName,'HR_DanhSachDangKyDiLam')
	if ISNULL(@thongbao,'')='' begin
		if exists (select Employee_ID from HR_DanhSachDangKyDiLam where (Employee_ID=@Employee_ID and Ngay=@Ngay) or ID=ISNULL(@ID,0)) begin
			update HR_DanhSachDangKyDiLam set Employee_ID=@Employee_ID,Ngay=@Ngay,Remark=@Remark,InsertDate=GETDATE(),UserName=@UserName
			where (Employee_ID=@Employee_ID and Ngay=@Ngay) or ID=ISNULL(@ID,0)
		end else begin
			insert into
			HR_DanhSachDangKyDiLam
			(
				[Employee_ID],
				[Ngay],
				[Remark],
				[InsertDate],
				[UserName]
			)
			values
			(
				@Employee_ID,
				@Ngay,
				@Remark,
				GETDATE(),
				@UserName
			)
		end
	end
	select @ID=ID from HR_DanhSachDangKyDiLam where Employee_ID=@Employee_ID and Ngay=@Ngay
	select @ThongBao as ThongBao,@ID as ID
END




GO
