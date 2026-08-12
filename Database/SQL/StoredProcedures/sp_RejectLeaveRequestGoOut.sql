
CREATE   PROCEDURE [dbo].[sp_RejectLeaveRequestGoOut] 
	@ID INT, 
	@Employee_ID nvarchar(50) = null,
	@TimeDate datetime = null,
	@TimeOut_ datetime = null,
	@TimeIn datetime = null,
	@LeaveType_ID nvarchar(50) = null,
	@ShiftName nvarchar(50) = null,
	@Remark nvarchar(MAX) = null,
	@UserName nvarchar(50) = null,
	@InsertDate datetime = null,
	@ApproveDate datetime = null,
	@TrangThai nvarchar(50) = null
AS
BEGIN
	--exec [dbo].[sp_RejectLeaveRequestGoOut] '1'
	DECLARE @ApproverName NVARCHAR(100)
		, @Approver nvarchar(50)
		, @ThuTuDuyet int
		, @Approver1_Name nvarchar(50)
		, @ApproveLevel int
		, @DepartmentName nvarchar(100)
		, @ChucDanh nvarchar(100)
		, @Employee_Name nvarchar(100)
		, @EmailDuPhong nvarchar(100)

	if @ID is null begin
		select @ID = ID from HR_LeaveRequestGoOut
		WHERE Employee_ID = @Employee_ID and TimeDate = @TimeDate and TimeOut_ = @TimeOut_ and TimeIn = @TimeIn
	end
	else if @Employee_ID is null begin
		select @Employee_ID = Employee_ID
		from HR_LeaveRequestGoOut
		where ID = @ID
	end

	select @Employee_Name = dbo.udf_FullName(Employee_Firstname, Employee_LastName)
	from SmartBooks_Employee
	where Employee_ID = @Employee_ID

	select @EmailDuPhong = [Value] from SetUp where FunctionID = 'Email' and ID = 'EmailDuPhong'
	
	--Get basic information from HR_LeaveRequestGoOut
	Select @ThuTuDuyet = ThuTuDuyet + 1, @ApproverName = ApproverName, @Approver = ApproveLevel
	from
	HR_LeaveRequestGoOut
	where @ID = ID
	
	--Get Basic information of Aprrover
	select @DepartmentName = DepartmentName, @Approver1_Name = dbo.udf_FullName (Employee_Firstname, Employee_LastName), @ChucDanh = ChucDanh
			,@ApproveLevel = LvDuyet
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Approver,GETDATE())
	
	update HR_LeaveRequestGoOut
	set TrangThai = 'Rejected'
	WHERE ID = @ID

	insert into HR_RequestLeaveGoOut_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
	select @ID, @Approver, @Approver1_Name, GETDATE(), @ApproveLevel, @DepartmentName, @ChucDanh

	Delete HR_DanhSachNguoiNhanThongBao
	where Employee_ID = @Employee_ID and Type_ = 'RejectGoOut'

	insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao)
	select @Employee_ID, empl.Employee_ID, @Employee_Name, 'RejectGoOut', CASE WHEN ISNULL(empl.Email,'') = '' THEN @EmailDuPhong ELSE empl.Email END, 0, 1
	from SmartBooks_Employee empl
	where empl.Employee_ID = @Employee_ID
END;

GO
