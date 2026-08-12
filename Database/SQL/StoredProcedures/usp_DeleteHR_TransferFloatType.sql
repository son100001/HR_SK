--select * from HR_TransferFloatType where Employee_ID='19000808'
CREATE PROCEDURE [dbo].[usp_DeleteHR_TransferFloatType]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_TransferFloatType '19000808','2019-8-1','HeavyAndToxic','admin'
	@Employee_ID nvarchar(50),
	@Fromdate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime,@ThongBao nvarchar(max)
	set @ThongBao=''
	set @ThongBao=@ThongBao+[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	--if @TypeOfTransfer='HeavyAndToxic' begin
	--	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_TransferFloatType_HeavyAndToxic' and Block_User=@UserName
	--end
	if @ThongBao='' begin
		if @Block_Date<@Fromdate or @Block_Date is null begin
			delete HR_TransferFloatType where Employee_ID=@Employee_ID and Fromdate=@Fromdate 
 		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
