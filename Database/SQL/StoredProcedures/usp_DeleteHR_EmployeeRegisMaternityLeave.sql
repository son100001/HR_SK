CREATE PROCEDURE [dbo].[usp_DeleteHR_EmployeeRegisMaternityLeave]
	-- Add the parameters for the stored procedure here
	@Employee_ID nvarchar(50),
	@Fromdate nvarchar(50),
	@UserName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime,@Block_Date_Termination datetime
	declare @ThongBao nvarchar(max)
	set @ThongBao=[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	select @Block_Date=Block_Date from HR_Khoa where [TableName]='HR_EmployeeRegisMaternityLeave' and Block_User=@UserName
	if @ThongBao='' begin
		if @Block_Date<@Fromdate or @Block_Date is null begin
			if not exists(select Employee_ID from HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and Fromdate=@Fromdate) and exists(select H_date from SmartBooks_HolidaysPlan where H_date=@Fromdate) begin
				exec [dbo].[usp_InsertUpdateHR_DanhSachDangKyDiLam] null,@Employee_ID,@Fromdate,N'Xóa phép',@Fromdate,@UserName
			end else begin
				delete HR_EmployeeRegisMaternityLeave where Employee_ID=@Employee_ID and Fromdate=@Fromdate
			end
		end else begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END



GO
