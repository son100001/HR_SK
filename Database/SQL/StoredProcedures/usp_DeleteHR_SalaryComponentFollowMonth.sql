CREATE PROCEDURE [dbo].[usp_DeleteHR_SalaryComponentFollowMonth]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_EmployeeRegisMaternityLeave '8348','admin'
	@Employee_ID nvarchar(50),
	@SalaryComponent nvarchar(50),
	@Year_ int,
	@Month_ int,
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime,@NgayDauThang datetime
	declare @ThongBao nvarchar(max)
	set @ThongBao=''
	set @NgayDauThang=cast(@Year_ as varchar)+'-'+cast(@Month_ as varchar)+'-1'
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_SalaryComponentFollowMonth' and Block_User=@UserName
	set @ThongBao=@ThongBao+[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		if @Block_Date<@NgayDauThang or @Block_Date is null begin
			delete HR_SalaryComponentFollowMonth where Employee_ID=@Employee_ID and Year_=@year_ and Month_=@Month_ and SalaryComponent=@SalaryComponent
		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END




GO
