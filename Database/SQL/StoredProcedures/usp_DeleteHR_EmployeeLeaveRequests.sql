
create PROCEDURE [dbo].[usp_DeleteHR_EmployeeLeaveRequests]
	-- Add the parameters for the stored procedure here
	--exec usp_DeleteHR_EmployeeRegisMaternityLeave '8348','admin'
	@ID int = null,
	@Employee_ID nvarchar(50) = null,
	@LeaveType_ID nvarchar(50) = null,
	@Fromdate datetime = null,
	@UserName nvarchar(50) = null,
	@TrangThai nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @Block_Date datetime
	declare @ThongBao nvarchar(max)
	set @ThongBao=''
	if @TrangThai <> 'Pending'
		set @ThongBao = 'Data has been processed'
	
	SELECT @Block_Date=Block_Date
	FROM HR_Khoa
	WHERE [TableName]='HR_EmployeeLeaveRequests' and Block_User=@UserName

	--set @ThongBao=@ThongBao+[dbo].[udf_KiemTraKhoaDuLieuNguoiThoiViec](@Employee_ID,@UserName)
	
	IF @ThongBao=''
	BEGIN
		if @Block_Date<@fromdate or @Block_Date is null 
		BEGIN
			if @ID is not NULL
			BEGIN
				delete HR_EmployeeLeaveRequests
				WHERE ID = @ID
			END
			ELSE begin
				delete HR_EmployeeLeaveRequests
				WHERE Employee_ID=@Employee_ID and fromdate=@fromdate and LeaveType_ID=@LeaveType_ID
			end
		END
		ELSE begin
			set @ThongBao=N'Dulieudabikhoa'
		end
	end
	select isnull(@ThongBao,'') as ThongBao
END


GO
