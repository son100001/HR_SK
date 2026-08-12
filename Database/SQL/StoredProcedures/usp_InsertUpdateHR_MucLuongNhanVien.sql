CREATE PROCEDURE [dbo].[usp_InsertUpdateHR_MucLuongNhanVien]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Employee_ID nvarchar(50),
	@SalaryGroup varchar(50),
	@SalaryStep varchar(50),
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
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@fromdate,@UserName,'HR_MucLuongNhanVien')
	if ISNULL(@thongbao,'')='' begin
		if exists(select Employee_ID from HR_MucLuongNhanVien where (Employee_ID=@Employee_ID and fromdate=@fromdate) or ID=isnull(@ID,0))
		begin
			update HR_MucLuongNhanVien
			set Employee_ID=@Employee_ID,SalaryGroup=@SalaryGroup,SalaryStep=@SalaryStep,fromdate=@fromdate,todate=@todate,Remark=@Remark,UserName=@UserName,InsertDate=GETDATE()
			where (Employee_ID=@Employee_ID and fromdate=@fromdate) or ID=isnull(@ID,0)
		end else begin
			insert into HR_MucLuongNhanVien
			(
				[Employee_ID],
				SalaryGroup,
				SalaryStep,
				fromdate,
				todate,
				[Remark],
				[InsertDate],
				[UserName]
			)
			values(@Employee_ID,@SalaryGroup,@SalaryStep,@fromdate,@todate,@Remark,GETDATE(),@UserName)
		end
	end
	select @ID=ID from HR_MucLuongNhanVien where Employee_ID=@Employee_ID and fromdate=@fromdate
	select @ThongBao as ThongBao,@ID as ID
END




GO
