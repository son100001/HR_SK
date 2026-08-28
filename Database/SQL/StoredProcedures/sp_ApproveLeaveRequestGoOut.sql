
CREATE   PROCEDURE [dbo].[sp_ApproveLeaveRequestGoOut]
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
	SET NOCOUNT ON;

	DECLARE
		@ApproverName NVARCHAR(200),
		@Approver1 NVARCHAR(200),
		@Approver1First NVARCHAR(50),
		@Approver nvarchar(200),
		@ApproverCurrentFirst nvarchar(50),
		@ActualApprover nvarchar(50),
		@ThuTuDuyet int,
		@Approver1_Name nvarchar(50),
		@ApproveLevel int,
		@DepartmentName nvarchar(100),
		@ChucDanh nvarchar(100),
		@Employee_Name nvarchar(100),
		@NotifyOnlyApprovers nvarchar(max),
		@FlowCode nvarchar(50),
		@RequestType nvarchar(50) = N'RequestGoOut';

	IF @ID IS NULL
		SELECT @ID = ID
		FROM HR_LeaveRequestGoOut
		WHERE Employee_ID = @Employee_ID
		    AND TimeDate = @TimeDate
		    AND TimeOut_ = @TimeOut_
		    AND TimeIn = @TimeIn;
	ELSE IF @Employee_ID IS NULL
		SELECT
			@Employee_ID = Employee_ID,
			@LeaveType_ID = LeaveType_ID,
			@TimeDate = TimeDate,
			@TimeOut_ = TimeOut_,
			@TimeIn = TimeIn
		FROM HR_LeaveRequestGoOut
		WHERE ID = @ID;

	SELECT
		@ThuTuDuyet = ThuTuDuyet + 1,
		@ApproverName = ApproverName,
		@Approver = ApproveLevel
	FROM HR_LeaveRequestGoOut
	WHERE ID = @ID;

	IF EXISTS (
		SELECT 1
		FROM HR_LeaveRequestGoOut
		WHERE ID = @ID
		    AND TrangThai = N'Approved'
	)
		RETURN;

	SELECT @ApproverCurrentFirst = [Data]
	FROM Split(@Approver, ',')
	WHERE Order_ = 1;

	SELECT @ActualApprover = COALESCE(NULLIF(us.Employee_ID, ''), NULLIF(@UserName, ''), @ApproverCurrentFirst)
	FROM [User] us
	WHERE us.UserName = @UserName;

	SET @ActualApprover = ISNULL(NULLIF(@ActualApprover, ''), ISNULL(NULLIF(@UserName, ''), @ApproverCurrentFirst));

	-- Notify-only approvers must come from RequestGoOut cache only (never fallback to RequestLeave).
	SELECT TOP 1 @NotifyOnlyApprovers = ISNULL(ga.ChiGuiThongBao, N'')
	FROM HR_GetApprover ga
	WHERE ga.Employee_ID = @Employee_ID
	    AND ga.RequestType = @RequestType
	    AND ISNULL(LTRIM(RTRIM(ga.ChiGuiThongBao)), N'') <> N''
	    AND (
	                REPLACE(ga.Code, N' ', N'') = REPLACE(@ApproverName, N' ', N'')
	                OR REPLACE(ga.Code, N' ', N'') = REPLACE(@Approver, N' ', N'')
	                OR REPLACE(@ApproverName, N' ', N'') LIKE REPLACE(ga.Code, N' ', N'') + N',%'
	    )
	ORDER BY LEN(ga.Code) DESC;

	SET @NotifyOnlyApprovers = ISNULL(@NotifyOnlyApprovers, N'');

	SELECT TOP 1
		@ThuTuDuyet = nextApprover.Order_,
		@Approver1First = nextApprover.[Data]
	FROM Split(@ApproverName, ',') nextApprover
	WHERE nextApprover.Order_ >= @ThuTuDuyet
	    AND nextApprover.[Data] <> N''
	    AND NOT EXISTS (
	                SELECT 1
	                FROM Split(@Approver, ',') currentApprover
	                WHERE currentApprover.[Data] = nextApprover.[Data]
	    )
	    AND NOT EXISTS (
	                SELECT 1
	                FROM Split(ISNULL(@NotifyOnlyApprovers, N''), ',') notifyOnlyApprover
	                WHERE LTRIM(RTRIM(notifyOnlyApprover.[Data])) = LTRIM(RTRIM(nextApprover.[Data]))
	    )
	ORDER BY nextApprover.Order_;

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
	                FROM Split(ISNULL(@NotifyOnlyApprovers, N''), ',') notifyOnlyApprover
	                WHERE LTRIM(RTRIM(notifyOnlyApprover.[Data])) = LTRIM(RTRIM(ap.[Data]))
	    );

	SET @Approver1 = ISNULL(NULLIF(@Approver1, N''), @Approver1First);

	SELECT @Employee_Name = Employee_Firstname + N' ' + Employee_LastName
	FROM SmartBooks_Employee
	WHERE Employee_ID = @Employee_ID;

	SELECT @FlowCode = dbo.udf_ResolveApprovalFlow(@Employee_ID, @RequestType, GETDATE());
	IF @FlowCode IS NULL
	BEGIN
		SELECT TOP 1 @FlowCode = NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
		FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @Employee_ID, GETDATE()) ef;
	END

	IF @Approver1 IS NOT NULL
		SET @TrangThai = N'Pending';
	ELSE
		SET @TrangThai = N'Approved';

	SELECT
		@DepartmentName = DepartmentName,
		@Approver1_Name = dbo.udf_FullName(Employee_Firstname, Employee_LastName),
		@ChucDanh = ChucDanh,
		@ApproveLevel = LvDuyet
	FROM udf_EmployeeFilter(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @ActualApprover, GETDATE());

	BEGIN TRANSACTION InsertApprove;

		UPDATE HR_LeaveRequestGoOut
		SET TrangThai = @TrangThai,
		        ApproveDate = GETDATE(),
		        ApproveLevel = @Approver1,
		        ThuTuDuyet = @ThuTuDuyet,
		        CurrentStepSince = CASE WHEN @TrangThai = N'Pending' THEN GETDATE() ELSE NULL END
		WHERE ID = @ID;

		IF @Approver1 IS NULL
		BEGIN
			INSERT INTO [dbo].[HR_GoOut] (Employee_ID, TimeDate, TimeOut_, TimeIn, LeaveType_ID, ShiftName, Remark, UserName, InsertDate)
			SELECT
				Employee_ID,
				TimeDate,
				TimeOut_,
				TimeIn,
				LeaveType_ID,
				ShiftName,
				Remark,
				@ActualApprover,
				GETDATE()
			FROM HR_LeaveRequestGoOut req
			WHERE req.ID = @ID
			    AND NOT EXISTS (
			            SELECT 1
			            FROM HR_GoOut goout
			            WHERE goout.Employee_ID = req.Employee_ID
			                AND goout.TimeDate = req.TimeDate
			                AND goout.TimeOut_ = req.TimeOut_
			                AND goout.TimeIn = req.TimeIn
			    );

			DELETE HR_DanhSachNguoiNhanThongBao
			WHERE Employee_ID = @Employee_ID
			    AND Type_ = N'RequestGoOutGuard';

			IF EXISTS (SELECT 1 FROM SmartBooks_Employee WHERE Employee_ID = N'BV')
			BEGIN
				INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
				SELECT
					@Employee_ID,
					N'BV',
					@Employee_Name,
					N'RequestGoOutGuard',
					ISNULL(empl.Email, N''),
					0,
					0,
					1, 1, 0
				FROM SmartBooks_Employee empl
				WHERE empl.Employee_ID = N'BV';
			END
			ELSE
			BEGIN
				INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
				VALUES (@Employee_ID, N'BV', @Employee_Name, N'RequestGoOutGuard', N'', 0, 0, 1, 1, 0);
			END
		END

		-- Chốt phòng thủ thứ 2 — xem ghi chú đầu file. Chỉ ghi khi (Request_ID, Approver_ID) chưa
		-- có, để không bao giờ tự đụng PK_HR_RequestLeaveGoOut_History dù bị gọi trùng vì lý do gì.
		IF NOT EXISTS (
			SELECT 1 FROM HR_RequestLeaveGoOut_History
			WHERE Request_ID = @ID AND Approver_ID = @ActualApprover
		)
			INSERT INTO HR_RequestLeaveGoOut_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
			SELECT @ID, @ActualApprover, @Approver1_Name, GETDATE(), @ApproveLevel, @DepartmentName, @ChucDanh;

		IF @TrangThai = N'Pending'
		BEGIN
			DELETE HR_DanhSachNguoiNhanThongBao
			WHERE Employee_ID = @Employee_ID
			    AND Type_ = N'RequestGoOut';

			INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
			SELECT
				@Employee_ID,
				dt.[Data],
				@Employee_Name,
				N'RequestGoOut',
				ISNULL(empl.Email, N''),
				0,
				0,
				ch.NotifyViaWeb,
				ch.NotifyViaEmail,
				ch.NotifyViaZalo
			FROM Split(@Approver1, ',') dt
			LEFT JOIN SmartBooks_Employee empl
			        ON dt.[Data] = empl.Employee_ID
			CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, @ThuTuDuyet, 0) ch
			WHERE dt.[Data] <> N'';
		END
		ELSE IF @TrangThai = N'Approved'
		BEGIN
			DECLARE @ChiGuiThongBao NVARCHAR(MAX);
			SET @ChiGuiThongBao = ISNULL(@NotifyOnlyApprovers, N'');

			DELETE HR_DanhSachNguoiNhanThongBao
			WHERE Employee_ID = @Employee_ID
			    AND Type_ = N'RequestGoOut';

			INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
			SELECT
				@Employee_ID,
				dt.[Data],
				@Employee_Name,
				N'RequestGoOut',
				ISNULL(empl.Email, N''),
				0,
				1,
				ch.NotifyViaWeb,
				ch.NotifyViaEmail,
				ch.NotifyViaZalo
			FROM Split(@ChiGuiThongBao, ',') dt
			LEFT JOIN SmartBooks_Employee empl
			        ON dt.[Data] = empl.Employee_ID
			CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, NULL, 1) ch
			WHERE dt.[Data] <> N'';

			INSERT INTO HR_DanhSachNguoiNhanThongBao (Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo)
			SELECT
				@Employee_ID,
				empl.Employee_ID,
				@Employee_Name,
				N'RequestGoOut',
				ISNULL(empl.Email, N''),
				0,
				1,
				ch.NotifyViaWeb,
				ch.NotifyViaEmail,
				ch.NotifyViaZalo
			FROM SmartBooks_Employee empl
			CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, NULL, NULL) ch
			WHERE empl.Employee_ID = @Employee_ID;
		END

	IF @@ERROR = 0
		COMMIT TRANSACTION InsertApprove;
	ELSE
		ROLLBACK TRANSACTION InsertApprove;
END

GO
