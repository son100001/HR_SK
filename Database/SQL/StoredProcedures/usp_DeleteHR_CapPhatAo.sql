CREATE PROCEDURE  [dbo].[usp_DeleteHR_CapPhatAo] 
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@DateIssued datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ThongBao nvarchar(max)
	--Hàm kiểm tra xem nhân viên có hợp lệ không
	set @ThongBao=[dbo].[udf_KiemTraNhapDuLieuChung](@Employee_ID,@DateIssued,@UserName,'HR_CapPhatAo')
	set @ThongBao=@ThongBao+[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		delete HR_CapPhatAo where Employee_ID=@Employee_ID and DateIssued=@DateIssued
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
