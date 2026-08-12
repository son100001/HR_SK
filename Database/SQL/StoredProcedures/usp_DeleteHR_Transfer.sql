
CREATE PROCEDURE [dbo].[usp_DeleteHR_Transfer]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_TransferFloatType '8348','admin'
	@Employee_ID nvarchar(50),
	@EffectiveDate datetime,
	@TypeOfTransfer [varchar](50),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime,@ThongBao nvarchar(max)
	set @ThongBao=[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		if @TypeOfTransfer='Position_ID' begin
			select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_Transfer_PositionID' and Block_User=@UserName
		end else begin
			select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_Transfer_Position' and Block_User=@UserName	
		end
	
		if @Block_Date<@EffectiveDate or @Block_Date is null begin
			delete HR_Transfer where Employee_ID=@Employee_ID and TypeOfTransfer=@TypeOfTransfer and EffectiveDate=@EffectiveDate
 		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	
	select isnull(@ThongBao,'') as ThongBao
END





GO
