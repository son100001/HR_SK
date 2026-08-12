CREATE PROCEDURE [dbo].[usp_DeleteHR_SalaryComponent]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_EmployeeRegisMaternityLeave '8348','admin'
	@Employee_ID nvarchar(50),
	@SalaryComponent nvarchar(50),
	@Fromdate datetime,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime
	declare @ThongBao nvarchar(max)
	set @ThongBao=''
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_SalaryComponent' and Block_User=@UserName
	set @ThongBao=@ThongBao+[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		if @Block_Date<@fromdate or @Block_Date is null begin
			delete HR_SalaryComponent where Employee_ID=@Employee_ID and fromdate=@fromdate and SalaryComponent=@SalaryComponent
		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
