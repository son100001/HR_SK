CREATE PROCEDURE [dbo].[usp_DeleteHR_MucLuong]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_EmployeeRegisMaternityLeave '8348','admin'
	@SalaryGroup varchar(50),
	@SalaryStep varchar(50),
	@FromDate datetime,
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
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_MucLuong' and Block_User=@UserName
	if @ThongBao='' begin
		if @Block_Date<@Fromdate or @Block_Date is null begin
			delete HR_MucLuong where SalaryGroup=@SalaryGroup and SalaryStep=@SalaryStep and Fromdate=@Fromdate
		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
