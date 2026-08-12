create PROCEDURE [dbo].[usp_DeleteHR_DangKyCom]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_MucLuong '8348','admin'
	@ID int,
	@Employee_ID nvarchar(50),
	@Ngay datetime,
	@ComTrua nvarchar(50),
	@ComToi nvarchar(50),
	@Remark nvarchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime
	declare @ThongBao nvarchar(max)

	if @ID is null begin
		select @ID = ID from HR_DangKyCom where Employee_ID = @Employee_ID and Ngay = @Ngay
	end

	delete HR_DangKyCom
	where ID = @ID

	select isnull(@ThongBao,'') as ThongBao
END




GO
