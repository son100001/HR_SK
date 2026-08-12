CREATE PROCEDURE [dbo].[usp_DeleteHR_EmpRegisTimeSheet]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_EmployeeRegisMaternityLeave '8348','admin'
	@Employee_ID nvarchar(50),
	@TimeDate nvarchar(50),
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
	set @ThongBao=@ThongBao+[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	if @ThongBao='' begin
		select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_EmpRegisTimeSheet' and Block_User=@UserName
		if @Block_Date<@TimeDate or @Block_Date is null begin
			delete HR_EmpRegisTimeSheet where Employee_ID=@Employee_ID and TimeDate=@TimeDate
		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END
--select * from HR_TimeKeeping_Data




GO
