
CREATE   PROCEDURE [dbo].[sp_RejectLeaveRequest] 
@ID int = null, 
@Employee_ID nvarchar(50) = null,
@LeaveType_ID nvarchar(50) = null,
@Fromdate datetime = null,
@ToDate datetime = null,
@Reason nvarchar(250) = null,
@PlanStatus varchar(50) = null,
@Remark nvarchar(250) = null,
@TrangThai nvarchar(50) = null,
@InsertDate datetime = null,
@UserName nvarchar(50) = null,
@isDaNopGiay bit = null,
@isBlock bit = null,
@isChoUngPhep bit = null
AS
BEGIN

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
		select @ID = ID from HR_EmployeeLeaveRequests
		WHERE Employee_ID = @Employee_ID and @Fromdate = Fromdate and @ToDate = ToDate and LeaveType_ID = @LeaveType_ID
	end
	else if @Employee_ID is null begin
		select @Employee_ID = Employee_ID
		from HR_EmployeeLeaveRequests
		where ID = @ID
	end

	select @Employee_Name = dbo.udf_FullName(Employee_Firstname, Employee_LastName)
	from SmartBooks_Employee
	where Employee_ID = @Employee_ID

	select @EmailDuPhong = [Value] from SetUp where FunctionID = 'Email' and ID = 'EmailDuPhong'

	--Get basic information from HR_EmployeeLeaveRequests
	Select @ThuTuDuyet = ThuTuDuyet + 1, @ApproverName = ApproverName, @Approver = ApproveLevel
	from
	HR_EmployeeLeaveRequests
	where @ID = ID
	
	--Get Basic information of Aprrover
	select @DepartmentName = DepartmentName, @Approver1_Name = dbo.udf_FullName (Employee_Firstname, Employee_LastName), @ChucDanh = ChucDanh
			,@ApproveLevel = LvDuyet
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Approver,GETDATE())
	
	update HR_EmployeeLeaveRequests
	set TrangThai = 'Rejected'
	WHERE ID = @ID

	insert into HR_RequestLeave_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
	select @ID, @Approver, @Approver1_Name, GETDATE(), @ApproveLevel, @DepartmentName, @ChucDanh

	Delete HR_DanhSachNguoiNhanThongBao
	where Employee_ID = @Employee_ID and Type_ = 'RejectLeave'

	insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao)
	select @Employee_ID, empl.Employee_ID, @Employee_Name, 'RejectLeave', CASE WHEN ISNULL(empl.Email,'') = '' THEN @EmailDuPhong ELSE empl.Email END, 0, 1
	from SmartBooks_Employee empl
	where empl.Employee_ID = @Employee_ID
END;

GO
