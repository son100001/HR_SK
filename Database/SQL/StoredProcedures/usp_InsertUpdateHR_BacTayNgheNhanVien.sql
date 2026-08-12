CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_BacTayNgheNhanVien]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@Nhom varchar(50),
	@Bac varchar(50),
	@fromdate datetime,
	@todate datetime,
	@Remark nvarchar(225),
	@InsertDate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(255)
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@fromdate,@UserName,'HR_BacTayNgheNhanVien')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_BacTayNgheNhanVien where (Employee_ID=@Employee_ID and fromdate=@fromdate) or ID=isnull(@ID,0))
		begin
			update HR_BacTayNgheNhanVien
			set Employee_ID=@Employee_ID,Nhom=@Nhom,Bac=@Bac,fromdate=@fromdate,todate=@todate,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and fromdate=@fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_BacTayNgheNhanVien
			(
				[Employee_ID],
				Nhom,
				Bac,
				fromdate,
				todate,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Employee_ID,@Nhom,@Bac,@fromdate,@todate,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_BacTayNgheNhanVien where Employee_ID=@Employee_ID and fromdate=@fromdate
	select @ThongBao as ThongBao,@ID as ID
END




GO
