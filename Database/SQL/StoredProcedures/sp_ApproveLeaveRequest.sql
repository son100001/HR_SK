
CREATE   PROCEDURE [dbo].[sp_ApproveLeaveRequest]
	@ID INT,
	@Employee_ID nvarchar(50) = null,
	@LeaveType_ID NVARCHAR(50) = NULL,
	@Fromdate DATETIME = NULL,
	@ToDate DATETIME = NULL,
	@Reason NVARCHAR(250) = NULL,
	@PlanStatus VARCHAR(50) = NULL,
	@Remark NVARCHAR(250) = NULL,
	@TrangThai NVARCHAR(50) = NULL,
	@InsertDate DATETIME = NULL,
	@UserName NVARCHAR(50) = NULL,
	@isDaNopGiay BIT = NULL,
	@isBlock BIT = NULL,
	@isChoUngPhep BIT = NULL
AS
BEGIN
	DECLARE
		@ApproverName NVARCHAR(200)
		, @Approver1 NVARCHAR(200), @Approver1First NVARCHAR(50), @Approver nvarchar(200), @ApproverCurrentFirst nvarchar(50), @ActualApprover nvarchar(50)
		, @Quyen1 INT
		, @ThuTuDuyet int
		, @Approver1_Name nvarchar(50)
		, @ApproveLevel int
		, @DepartmentName nvarchar(100)
		, @ChucDanh nvarchar(100)
		, @Email nvarchar(100), @EmailDuPhong nvarchar(100)
		, @Employee_Name nvarchar(100)
		, @NextEmployee_ID nvarchar(50)
		, @NotifyOnlyApprovers nvarchar(max)
		, @FlowCode nvarchar(50)
		, @RequestType nvarchar(50) = N'RequestLeave'

	-- Get ID if ID is null
	If @ID is null
		select @ID = ID
		from
		HR_EmployeeLeaveRequests
		where Employee_ID = @Employee_ID and @Fromdate = Fromdate and @ToDate = ToDate and LeaveType_ID = @LeaveType_ID

	else if @Employee_ID is null
		select @Employee_ID = Employee_ID, @Fromdate = Fromdate, @ToDate = Todate, @LeaveType_ID = LeaveType_ID
		from
		HR_EmployeeLeaveRequests
		where ID = @ID

	-- Đơn đã Approved rồi thì dừng ngay, không xử lý lại lần nữa. Chặn double-click / gọi lại API
	-- duyệt 2 lần cho cùng 1 đơn — không thì ThuTuDuyet bị cộng thêm 1 lần nữa (nhảy cấp), và
	-- INSERT vào HR_RequestLeave_History bên dưới sẽ đụng khóa chính (Request_ID, Approver_ID) đã
	-- ghi ở lần duyệt trước. Sao chép nguyên mẫu từ sp_ApproveLeaveRequestGoOut (đã có sẵn chốt
	-- này từ trước).
	IF EXISTS (
		SELECT 1
		FROM HR_EmployeeLeaveRequests
		WHERE ID = @ID
			AND TrangThai = N'Approved'
	)
		RETURN;

	-- Get basic information from HR_EmployeeLeaveRequests
	Select @ThuTuDuyet = ThuTuDuyet + 1, @ApproverName = ApproverName, @Approver = ApproveLevel
	from
	HR_EmployeeLeaveRequests
	where @ID = ID
	print 'a'
	print @ApproverName
	print @Approver
	print 'b'
	SELECT @ApproverCurrentFirst = [Data]
	FROM Split(@Approver, ',')
	WHERE Order_ = 1

	SELECT @ActualApprover = COALESCE(NULLIF(us.Employee_ID, ''), NULLIF(@UserName, ''), @ApproverCurrentFirst)
	FROM [User] us
	WHERE us.UserName = @UserName

	SET @ActualApprover = ISNULL(NULLIF(@ActualApprover, ''), ISNULL(NULLIF(@UserName, ''), @ApproverCurrentFirst))


	SELECT @NotifyOnlyApprovers = ISNULL(ChiGuiThongBao, '')
	FROM HR_EmployeeLeaveRequests
	WHERE ID = @ID
-- Get the next approver group in the line. If the current level has many approvers,
	--one approval skips the whole current level and moves to the next distinct level.
	SELECT TOP 1
		@ThuTuDuyet = nextApprover.Order_,
		@Approver1First = nextApprover.[Data]
	FROM Split(@ApproverName, ',') nextApprover
	WHERE nextApprover.Order_ >= @ThuTuDuyet
		AND nextApprover.[Data] <> ''
		AND NOT EXISTS (
			SELECT 1
			FROM Split(@Approver, ',') currentApprover
			WHERE currentApprover.[Data] = nextApprover.[Data]
		)
		AND NOT EXISTS (
			SELECT 1
			FROM Split(ISNULL(@NotifyOnlyApprovers, ''), ',') notifyOnlyApprover
			WHERE LTRIM(RTRIM(notifyOnlyApprover.[Data])) = LTRIM(RTRIM(nextApprover.[Data]))
		)
	ORDER BY nextApprover.Order_

	SELECT
		@Approver1 = STRING_AGG(CAST(ap.[Data] AS nvarchar(max)), ',') WITHIN GROUP (ORDER BY ap.Order_)
	FROM Split(@ApproverName, ',') ap
	WHERE EXISTS (
		SELECT 1
		FROM HR_ApprovalLevelMember firstMember
		INNER JOIN HR_ApprovalLevelMember sameLevel
			ON sameLevel.LevelCode = firstMember.LevelCode
			AND sameLevel.IsActive = 1
		WHERE firstMember.Employee_ID = @Approver1First
			AND firstMember.IsActive = 1
			AND sameLevel.Employee_ID = ap.[Data]
	)
	AND NOT EXISTS (
		SELECT 1
		FROM Split(ISNULL(@NotifyOnlyApprovers, ''), ',') notifyOnlyApprover
		WHERE LTRIM(RTRIM(notifyOnlyApprover.[Data])) = LTRIM(RTRIM(ap.[Data]))
	)
	SET @Approver1 = ISNULL(NULLIF(@Approver1, ''), @Approver1First)
	select @Employee_Name = Employee_Firstname + ' ' + Employee_LastName from SmartBooks_Employee where Employee_ID = @Employee_ID
	-- select @EmailDuPhong = [Value] from SetUp where FunctionID = 'Email' and ID = 'EmailDuPhong' -- tất email dự phòng

	SELECT @FlowCode = dbo.udf_ResolveApprovalFlow(@Employee_ID, @RequestType, GETDATE());
	IF @FlowCode IS NULL
	BEGIN
		SELECT TOP 1 @FlowCode = NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
		FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @Employee_ID, GETDATE()) ef;
	END

	-- Check information if done set stt is Approved
	if @Approver1 is not null
		set @TrangThai = 'Pending'
	else set @TrangThai = 'Approved'

	-- Get Basic information of Aprrover
	select @DepartmentName = DepartmentName, @Approver1_Name = dbo.udf_FullName (Employee_Firstname, Employee_LastName), @ChucDanh = ChucDanh
			, @ApproveLevel = LvDuyet
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,@ActualApprover,GETDATE())

	-- Begin insert Approve
	Begin transaction InsertApprove
		UPDATE HR_EmployeeLeaveRequests
		SET TrangThai = @TrangThai,
			ApproveDate = GETDATE(),
			ApproveLevel = @Approver1,
			ThuTuDuyet = @ThuTuDuyet,
			CurrentStepSince = CASE WHEN @TrangThai = N'Pending' THEN GETDATE() ELSE NULL END
		WHERE ID = @ID

		IF @Approver1 is null
		BEGIN
			INSERT INTO [dbo].[HR_EmployeeRegisMaternityLeave] (Employee_ID, LeaveType_ID, Fromdate, ToDate, Reason, PlanStatus, Remark, InsertDate, UserName, isDaNopGiay, isBlock, isChoUngPhep)
			SELECT [Employee_ID]
				, [LeaveType_ID]
				, [Fromdate]
				, [ToDate]
				, [Reason]
				, [PlanStatus]
				, [Remark]
				, GETDATE()
				, @ActualApprover
				, [isDaNopGiay]
				, [isBlock]
				, [isChoUngPhep]
				FROM [dbo].[HR_EmployeeLeaveRequests]
				WHERE ID = @ID
		END

		-- Chốt phòng thủ thứ 2 — xem ghi chú đầu file. Chỉ ghi khi (Request_ID, Approver_ID) chưa
		-- có, để không bao giờ tự đụng PK_HR_RequestLeave_History dù bị gọi trùng vì lý do gì.
		IF NOT EXISTS (
			SELECT 1 FROM HR_RequestLeave_History
			WHERE Request_ID = @ID AND Approver_ID = @ActualApprover
		)
			insert into HR_RequestLeave_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
			select @ID, @ActualApprover, @Approver1_Name, GETDATE(), @ApproveLevel, @DepartmentName, @ChucDanh

		if @TrangThai = 'Approved' begin
			exec sp_Insert_HR_BangPhepDaNghi @fromdate,@todate,null,null,null,null,null,null,@Employee_ID
		end

		If @TrangThai = 'Pending' begin
			Delete HR_DanhSachNguoiNhanThongBao
			where Employee_ID = @Employee_ID and Type_ = 'RequestLeave'

			insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
			select @Employee_ID, dt.[Data], @Employee_Name, 'RequestLeave', ISNULL(empl.Email, ''), 0, 0, ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
			-- Email1: CASE WHEN ISNULL(empl.Email,'') = '' THEN @EmailDuPhong ELSE empl.Email END
			from Split(@Approver1, ',') dt
			left join SmartBooks_Employee empl
				on dt.[Data] = empl.Employee_ID
			CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, @ThuTuDuyet, 0) ch
			where dt.[Data] <> ''
		end else if @TrangThai = 'Approved' begin
			DECLARE @ChiGuiThongBao NVARCHAR(MAX);
			SET @ChiGuiThongBao = ISNULL(@NotifyOnlyApprovers, '')

			Delete HR_DanhSachNguoiNhanThongBao
			where Employee_ID = @Employee_ID and Type_ = 'RequestLeave'

			insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
			select @Employee_ID, dt.[Data], @Employee_Name, 'RequestLeave', ISNULL(Email, ''), 0, 1, ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
			-- Email1: CASE WHEN ISNULL(Email,'') = '' THEN @EmailDuPhong ELSE Email END
			from
			Split(@ChiGuiThongBao,',') dt
			left join
			SmartBooks_Employee empl
			on dt.[Data] = empl.Employee_ID
			CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, NULL, 1) ch
			where dt.[Data] <> ''

			insert into HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
			select @Employee_ID, empl.Employee_ID, @Employee_Name, 'RequestLeave', ISNULL(empl.Email, ''), 0, 1, ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
			-- Email1: CASE WHEN ISNULL(empl.Email,'') = '' THEN @EmailDuPhong ELSE empl.Email END
			from SmartBooks_Employee empl
			CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, NULL, NULL) ch
			where empl.Employee_ID = @Employee_ID
		end

	if @@ERROR = 0
		Commit transaction InsertApprove
	else
		Rollback transaction InsertApprove
END

GO
