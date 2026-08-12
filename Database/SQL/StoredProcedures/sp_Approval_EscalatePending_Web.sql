/*
  Auto-escalate pending leave / go-out requests when SLA expires at the current step.
  Intended to run from SQL Agent every 15 minutes.

  History row: Approver_ID = SYSTEM, Approver_Name = auto-escalation label.
*/
CREATE   PROCEDURE [dbo].[sp_Approval_EscalatePending_Web]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Now datetime = GETDATE();
    DECLARE @SystemApprover nvarchar(50) = N'SYSTEM';
    DECLARE @SystemName nvarchar(200) = N'Tự chuyển cấp (quá hạn SLA)';

    CREATE TABLE #Queue (
        RequestKind nvarchar(10) NOT NULL,
        ID int NOT NULL,
        Employee_ID nvarchar(50) NOT NULL,
        RequestType nvarchar(50) NOT NULL,
        ApproverName nvarchar(max) NULL,
        ApproveLevel nvarchar(200) NULL,
        ThuTuDuyet int NULL,
        ChiGuiThongBao nvarchar(max) NULL,
        FlowCode nvarchar(50) NULL,
        StepOrder int NOT NULL,
        PRIMARY KEY (RequestKind, ID)
    );

    INSERT INTO #Queue (
        RequestKind, ID, Employee_ID, RequestType, ApproverName, ApproveLevel,
        ThuTuDuyet, ChiGuiThongBao, FlowCode, StepOrder
    )
    SELECT
        N'Leave',
        lr.ID,
        lr.Employee_ID,
        N'RequestLeave',
        lr.ApproverName,
        lr.ApproveLevel,
        ISNULL(lr.ThuTuDuyet, 1),
        lr.ChiGuiThongBao,
        COALESCE(
            dbo.udf_ResolveApprovalFlow(lr.Employee_ID, N'RequestLeave', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        ),
        ISNULL(lr.ThuTuDuyet, 1)
    FROM HR_EmployeeLeaveRequests lr
    OUTER APPLY (
        SELECT TOP 1 ef.LvDuyet
        FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, lr.Employee_ID, @Now) ef
    ) ef
    INNER JOIN HR_ApprovalFlow f
        ON f.RequestType = N'RequestLeave'
       AND f.FlowCode = COALESCE(
            dbo.udf_ResolveApprovalFlow(lr.Employee_ID, N'RequestLeave', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        )
       AND f.IsActive = 1
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.StepOrder = ISNULL(lr.ThuTuDuyet, 1)
       AND st.IsActive = 1
       AND st.StepType IN (N'Approval', N'NotifyOnly')
    INNER JOIN HR_ApprovalRule r
        ON r.StepID = st.StepID
       AND r.IsActive = 1
    WHERE lr.TrangThai = N'Pending'
      AND lr.ApproveLevel IS NOT NULL
      AND ISNULL(st.EscalationEnabled, 0) = 1
      AND st.EscalationAfterHours IS NOT NULL
      AND lr.CurrentStepSince IS NOT NULL
      AND DATEDIFF(MINUTE, lr.CurrentStepSince, @Now) >= ROUND(st.EscalationAfterHours * 60.0, 0)
      AND ISNULL(r.IsNotifyOnly, 0) = 0
      AND st.StepType <> N'NotifyOnly'
      -- Only escalate to a real approval step; never auto-approve when only notify-only steps remain.
      AND EXISTS (
            SELECT 1
            FROM HR_ApprovalStep st2
            INNER JOIN HR_ApprovalRule r2
                ON r2.StepID = st2.StepID
               AND r2.IsActive = 1
               AND ISNULL(r2.IsNotifyOnly, 0) = 0
               AND st2.StepType = N'Approval'
            WHERE st2.FlowID = f.FlowID
              AND st2.IsActive = 1
              AND st2.StepOrder > st.StepOrder
      );

    INSERT INTO #Queue (
        RequestKind, ID, Employee_ID, RequestType, ApproverName, ApproveLevel,
        ThuTuDuyet, ChiGuiThongBao, FlowCode, StepOrder
    )
    SELECT
        N'GoOut',
        go.ID,
        go.Employee_ID,
        N'RequestGoOut',
        go.ApproverName,
        go.ApproveLevel,
        ISNULL(go.ThuTuDuyet, 1),
        ISNULL((
            SELECT TOP 1 ga.ChiGuiThongBao
            FROM HR_GetApprover ga
            WHERE ga.Employee_ID = go.Employee_ID
              AND ga.RequestType = N'RequestGoOut'
              AND ISNULL(LTRIM(RTRIM(ga.ChiGuiThongBao)), N'') <> N''
            ORDER BY LEN(ga.Code) DESC
        ), N''),
        COALESCE(
            dbo.udf_ResolveApprovalFlow(go.Employee_ID, N'RequestGoOut', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        ),
        ISNULL(go.ThuTuDuyet, 1)
    FROM HR_LeaveRequestGoOut go
    OUTER APPLY (
        SELECT TOP 1 ef.LvDuyet
        FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, go.Employee_ID, @Now) ef
    ) ef
    INNER JOIN HR_ApprovalFlow f
        ON f.RequestType = N'RequestGoOut'
       AND f.FlowCode = COALESCE(
            dbo.udf_ResolveApprovalFlow(go.Employee_ID, N'RequestGoOut', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        )
       AND f.IsActive = 1
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.StepOrder = ISNULL(go.ThuTuDuyet, 1)
       AND st.IsActive = 1
       AND st.StepType IN (N'Approval', N'NotifyOnly')
    INNER JOIN HR_ApprovalRule r
        ON r.StepID = st.StepID
       AND r.IsActive = 1
    WHERE go.TrangThai = N'Pending'
      AND go.ApproveLevel IS NOT NULL
      AND ISNULL(st.EscalationEnabled, 0) = 1
      AND st.EscalationAfterHours IS NOT NULL
      AND go.CurrentStepSince IS NOT NULL
      AND DATEDIFF(MINUTE, go.CurrentStepSince, @Now) >= ROUND(st.EscalationAfterHours * 60.0, 0)
      AND ISNULL(r.IsNotifyOnly, 0) = 0
      AND st.StepType <> N'NotifyOnly'
      AND EXISTS (
            SELECT 1
            FROM HR_ApprovalStep st2
            INNER JOIN HR_ApprovalRule r2
                ON r2.StepID = st2.StepID
               AND r2.IsActive = 1
               AND ISNULL(r2.IsNotifyOnly, 0) = 0
               AND st2.StepType = N'Approval'
            WHERE st2.FlowID = f.FlowID
              AND st2.IsActive = 1
              AND st2.StepOrder > st.StepOrder
      );

    DECLARE
        @RequestKind nvarchar(10),
        @ID int,
        @Employee_ID nvarchar(50),
        @RequestType nvarchar(50),
        @ApproverName nvarchar(max),
        @Approver nvarchar(200),
        @ThuTuDuyet int,
        @NotifyOnlyApprovers nvarchar(max),
        @FlowCode nvarchar(50),
        @Approver1 nvarchar(200),
        @Approver1First nvarchar(50),
        @TrangThai nvarchar(50),
        @Employee_Name nvarchar(100),
        @DepartmentName nvarchar(100),
        @ChucDanh nvarchar(100),
        @ApproveLevelHist int;

    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT RequestKind, ID, Employee_ID, RequestType, ApproverName, ApproveLevel, ThuTuDuyet, ChiGuiThongBao, FlowCode
        FROM #Queue;

    OPEN cur;
    FETCH NEXT FROM cur INTO @RequestKind, @ID, @Employee_ID, @RequestType, @ApproverName, @Approver, @ThuTuDuyet, @NotifyOnlyApprovers, @FlowCode;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION EscalateOne;

            -- Reset mỗi vòng lặp: 2 biến này khai báo NGOÀI cursor nên giữ giá trị của đơn xử lý
            -- trước. Nếu không reset, đơn không tìm được cấp kế sẽ "thừa hưởng" người duyệt của đơn
            -- trước (SELECT trả 0 dòng thì T-SQL giữ nguyên giá trị cũ, không set NULL).
            SET @Approver1First = NULL;
            SET @Approver1 = NULL;

            SET @ThuTuDuyet = ISNULL(@ThuTuDuyet, 1) + 1;
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
                    FROM Split(@NotifyOnlyApprovers, ',') notifyOnlyApprover
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
                    FROM Split(@NotifyOnlyApprovers, ',') notifyOnlyApprover
                    WHERE LTRIM(RTRIM(notifyOnlyApprover.[Data])) = LTRIM(RTRIM(ap.[Data]))
              );

            SET @Approver1 = ISNULL(NULLIF(@Approver1, N''), @Approver1First);

            -- ROOT-CAUSE FIX: không tìm được người duyệt cấp kế thực sự trong ApproverName
            -- (chuỗi bị đóng băng lúc nộp đơn thiếu cấp cao hơn, hoặc cấu hình bước lệch).
            -- KHÔNG được: tự duyệt (Approved) sai, HOẶC re-notify + reset CurrentStepSince —
            -- vì với SLA nhỏ (vd 0.25h) đơn sẽ tái tạo dòng Sended=0 mỗi 15 phút → thông báo lặp vô hạn.
            -- Đúng nghiệp vụ: giữ nguyên đơn ở cấp hiện tại, bỏ qua để người duyệt hiện tại xử lý tay.
            IF @Approver1First IS NULL OR @Approver1 IS NULL
            BEGIN
                ROLLBACK TRANSACTION EscalateOne;
                FETCH NEXT FROM cur INTO @RequestKind, @ID, @Employee_ID, @RequestType, @ApproverName, @Approver, @ThuTuDuyet, @NotifyOnlyApprovers, @FlowCode;
                CONTINUE;
            END

            -- Sau guard trên @Approver1 luôn có giá trị → escalate chỉ chuyển đơn sang cấp kế
            -- (Pending), không bao giờ tự Approved. Nhánh Approved cũ là dead code, đã bỏ.
            SET @TrangThai = N'Pending';

            SELECT @Employee_Name = Employee_Firstname + N' ' + Employee_LastName
            FROM SmartBooks_Employee
            WHERE Employee_ID = @Employee_ID;

            SELECT
                @DepartmentName = DepartmentName,
                @ChucDanh = ChucDanh,
                @ApproveLevelHist = LvDuyet
            FROM udf_EmployeeFilter(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @SystemApprover, @Now);

            IF @RequestKind = N'Leave'
            BEGIN
                UPDATE HR_EmployeeLeaveRequests
                SET TrangThai = @TrangThai,
                    ApproveDate = @Now,
                    ApproveLevel = @Approver1,
                    ThuTuDuyet = @ThuTuDuyet,
                    CurrentStepSince = @Now
                WHERE ID = @ID;

                -- KHÓA CHÍNH (Request_ID, Approver_ID): mỗi đơn chỉ có 1 dòng lịch sử cho 'SYSTEM'.
                -- Escalate nhiều cấp (L1->L2->L3) sẽ ghi 'SYSTEM' nhiều lần → INSERT thẳng gây
                -- trùng khóa chính → CATCH nuốt lỗi → ROLLBACK → đơn kẹt cấp. Dùng UPDATE-nếu-đã-có
                -- (giống nhánh fallback) để escalate được nhiều cấp.
                IF EXISTS (SELECT 1 FROM HR_RequestLeave_History WHERE Request_ID = @ID AND Approver_ID = @SystemApprover)
                    UPDATE HR_RequestLeave_History
                    SET Approver_Name = @SystemName, Approve_Date = @Now, ApproveLevel = @ApproveLevelHist,
                        DepartmentCode = @DepartmentName, Chucdanh = @ChucDanh
                    WHERE Request_ID = @ID AND Approver_ID = @SystemApprover;
                ELSE
                    INSERT INTO HR_RequestLeave_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
                    VALUES (@ID, @SystemApprover, @SystemName, @Now, @ApproveLevelHist, @DepartmentName, @ChucDanh);

                DELETE HR_DanhSachNguoiNhanThongBao
                WHERE Employee_ID = @Employee_ID AND Type_ = N'RequestLeave';

                INSERT INTO HR_DanhSachNguoiNhanThongBao (
                    Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao,
                    NotifyViaWeb, NotifyViaEmail, NotifyViaZalo
                )
                SELECT @Employee_ID, dt.[Data], @Employee_Name, N'RequestLeave', ISNULL(empl.Email, N''), 0, 0,
                       ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
                FROM Split(@Approver1, ',') dt
                LEFT JOIN SmartBooks_Employee empl ON empl.Employee_ID = dt.[Data]
                CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, @ThuTuDuyet, 0) ch
                WHERE dt.[Data] <> N'';
            END
            ELSE
            BEGIN
                UPDATE HR_LeaveRequestGoOut
                SET TrangThai = @TrangThai,
                    ApproveDate = @Now,
                    ApproveLevel = @Approver1,
                    ThuTuDuyet = @ThuTuDuyet,
                    CurrentStepSince = @Now
                WHERE ID = @ID;

                -- KHÓA CHÍNH (Request_ID, Approver_ID): tránh trùng 'SYSTEM' khi escalate nhiều cấp (xem chú thích nhánh Leave).
                IF EXISTS (SELECT 1 FROM HR_RequestLeaveGoOut_History WHERE Request_ID = @ID AND Approver_ID = @SystemApprover)
                    UPDATE HR_RequestLeaveGoOut_History
                    SET Approver_Name = @SystemName, Approve_Date = @Now, ApproveLevel = @ApproveLevelHist,
                        DepartmentCode = @DepartmentName, Chucdanh = @ChucDanh
                    WHERE Request_ID = @ID AND Approver_ID = @SystemApprover;
                ELSE
                    INSERT INTO HR_RequestLeaveGoOut_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
                    VALUES (@ID, @SystemApprover, @SystemName, @Now, @ApproveLevelHist, @DepartmentName, @ChucDanh);

                DELETE HR_DanhSachNguoiNhanThongBao
                WHERE Employee_ID = @Employee_ID AND Type_ = N'RequestGoOut';

                INSERT INTO HR_DanhSachNguoiNhanThongBao (
                    Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao,
                    NotifyViaWeb, NotifyViaEmail, NotifyViaZalo
                )
                SELECT @Employee_ID, dt.[Data], @Employee_Name, N'RequestGoOut', ISNULL(empl.Email, N''), 0, 0,
                       ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
                FROM Split(@Approver1, ',') dt
                LEFT JOIN SmartBooks_Employee empl ON empl.Employee_ID = dt.[Data]
                CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@RequestType, @FlowCode, @ThuTuDuyet, 0) ch
                WHERE dt.[Data] <> N'';
            END

            COMMIT TRANSACTION EscalateOne;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION EscalateOne;
        END CATCH

        FETCH NEXT FROM cur INTO @RequestKind, @ID, @Employee_ID, @RequestType, @ApproverName, @Approver, @ThuTuDuyet, @NotifyOnlyApprovers, @FlowCode;
    END

    CLOSE cur;
    DEALLOCATE cur;

    -- =========================================================
    -- FALLBACK BRANCH: last step overdue → transfer to fallback level
    -- Runs independently; conditions are mutually exclusive with
    -- the escalation branch above (NOT EXISTS vs EXISTS higher step).
    -- =========================================================

    CREATE TABLE #FallbackQueue (
        RequestKind nvarchar(10) NOT NULL,
        ID int NOT NULL,
        Employee_ID nvarchar(50) NOT NULL,
        RequestType nvarchar(50) NOT NULL,
        FlowCode nvarchar(50) NULL,
        StepOrder int NOT NULL,
        FallbackLevelCode nvarchar(50) NOT NULL,
        PRIMARY KEY (RequestKind, ID)
    );

    INSERT INTO #FallbackQueue (RequestKind, ID, Employee_ID, RequestType, FlowCode, StepOrder, FallbackLevelCode)
    SELECT
        N'Leave',
        lr.ID,
        lr.Employee_ID,
        N'RequestLeave',
        COALESCE(
            dbo.udf_ResolveApprovalFlow(lr.Employee_ID, N'RequestLeave', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        ),
        st.StepOrder,
        st.FallbackLevelCode
    FROM HR_EmployeeLeaveRequests lr
    OUTER APPLY (
        SELECT TOP 1 ef.LvDuyet
        FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, lr.Employee_ID, @Now) ef
    ) ef
    INNER JOIN HR_ApprovalFlow f
        ON f.RequestType = N'RequestLeave'
       AND f.FlowCode = COALESCE(
            dbo.udf_ResolveApprovalFlow(lr.Employee_ID, N'RequestLeave', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        )
       AND f.IsActive = 1
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.StepOrder = ISNULL(lr.ThuTuDuyet, 1)
       AND st.IsActive = 1
       AND st.StepType = N'Approval'
    WHERE lr.TrangThai = N'Pending'
      AND lr.ApproveLevel IS NOT NULL
      AND ISNULL(st.FallbackEnabled, 0) = 1
      AND st.FallbackLevelCode IS NOT NULL AND st.FallbackLevelCode <> N''
      AND st.EscalationAfterHours IS NOT NULL
      AND lr.CurrentStepSince IS NOT NULL
      AND DATEDIFF(MINUTE, lr.CurrentStepSince, @Now) >= ROUND(st.EscalationAfterHours * 60.0, 0)
      AND NOT EXISTS (
            SELECT 1
            FROM HR_ApprovalStep st2
            INNER JOIN HR_ApprovalRule r2
                ON r2.StepID = st2.StepID AND r2.IsActive = 1
               AND ISNULL(r2.IsNotifyOnly, 0) = 0
               AND st2.StepType = N'Approval'
            WHERE st2.FlowID = f.FlowID AND st2.IsActive = 1 AND st2.StepOrder > st.StepOrder
      );

    INSERT INTO #FallbackQueue (RequestKind, ID, Employee_ID, RequestType, FlowCode, StepOrder, FallbackLevelCode)
    SELECT
        N'GoOut',
        go.ID,
        go.Employee_ID,
        N'RequestGoOut',
        COALESCE(
            dbo.udf_ResolveApprovalFlow(go.Employee_ID, N'RequestGoOut', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        ),
        st.StepOrder,
        st.FallbackLevelCode
    FROM HR_LeaveRequestGoOut go
    OUTER APPLY (
        SELECT TOP 1 ef.LvDuyet
        FROM udf_EmployeeFilter_Web(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, go.Employee_ID, @Now) ef
    ) ef
    INNER JOIN HR_ApprovalFlow f
        ON f.RequestType = N'RequestGoOut'
       AND f.FlowCode = COALESCE(
            dbo.udf_ResolveApprovalFlow(go.Employee_ID, N'RequestGoOut', @Now),
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'')
        )
       AND f.IsActive = 1
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.StepOrder = ISNULL(go.ThuTuDuyet, 1)
       AND st.IsActive = 1
       AND st.StepType = N'Approval'
    WHERE go.TrangThai = N'Pending'
      AND go.ApproveLevel IS NOT NULL
      AND ISNULL(st.FallbackEnabled, 0) = 1
      AND st.FallbackLevelCode IS NOT NULL AND st.FallbackLevelCode <> N''
      AND st.EscalationAfterHours IS NOT NULL
      AND go.CurrentStepSince IS NOT NULL
      AND DATEDIFF(MINUTE, go.CurrentStepSince, @Now) >= ROUND(st.EscalationAfterHours * 60.0, 0)
      AND NOT EXISTS (
            SELECT 1
            FROM HR_ApprovalStep st2
            INNER JOIN HR_ApprovalRule r2
                ON r2.StepID = st2.StepID AND r2.IsActive = 1
               AND ISNULL(r2.IsNotifyOnly, 0) = 0
               AND st2.StepType = N'Approval'
            WHERE st2.FlowID = f.FlowID AND st2.IsActive = 1 AND st2.StepOrder > st.StepOrder
      );

    DECLARE
        @fb_RequestKind nvarchar(10),
        @fb_ID int,
        @fb_Employee_ID nvarchar(50),
        @fb_RequestType nvarchar(50),
        @fb_FlowCode nvarchar(50),
        @fb_StepOrder int,
        @fb_FallbackLevelCode nvarchar(50),
        @fb_FallbackApprovers nvarchar(max),
        @fb_Employee_Name nvarchar(100),
        @fb_NewThuTuDuyet int,
        @fb_ApproveLevelHist int,
        @fb_DepartmentName nvarchar(100),
        @fb_ChucDanh nvarchar(100);

    DECLARE fb_cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT RequestKind, ID, Employee_ID, RequestType, FlowCode, StepOrder, FallbackLevelCode
        FROM #FallbackQueue;

    OPEN fb_cur;
    FETCH NEXT FROM fb_cur INTO @fb_RequestKind, @fb_ID, @fb_Employee_ID, @fb_RequestType, @fb_FlowCode, @fb_StepOrder, @fb_FallbackLevelCode;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION FallbackOne;

            -- Get members of the fallback level
            SELECT @fb_FallbackApprovers = STRING_AGG(CAST(m.Employee_ID AS nvarchar(max)), N',')
            FROM HR_ApprovalLevelMember m
            WHERE m.LevelCode = @fb_FallbackLevelCode AND m.IsActive = 1;

            IF @fb_FallbackApprovers IS NULL OR @fb_FallbackApprovers = N''
            BEGIN
                ROLLBACK TRANSACTION FallbackOne;
                FETCH NEXT FROM fb_cur INTO @fb_RequestKind, @fb_ID, @fb_Employee_ID, @fb_RequestType, @fb_FlowCode, @fb_StepOrder, @fb_FallbackLevelCode;
                CONTINUE;
            END

            SET @fb_NewThuTuDuyet = @fb_StepOrder + 1; -- sentinel: no real step matches → Approved on approval

            SELECT @fb_Employee_Name = Employee_Firstname + N' ' + Employee_LastName
            FROM SmartBooks_Employee WHERE Employee_ID = @fb_Employee_ID;

            SELECT
                @fb_DepartmentName = DepartmentName,
                @fb_ChucDanh = ChucDanh,
                @fb_ApproveLevelHist = LvDuyet
            FROM udf_EmployeeFilter(N'VN', NULL, NULL, NULL, NULL, NULL, NULL, @SystemApprover, @Now);

            IF @fb_RequestKind = N'Leave'
            BEGIN
                UPDATE HR_EmployeeLeaveRequests
                SET ApproveLevel = @fb_FallbackApprovers,
                    ThuTuDuyet = @fb_NewThuTuDuyet,
                    CurrentStepSince = @Now
                WHERE ID = @fb_ID;

                IF EXISTS (SELECT 1 FROM HR_RequestLeave_History WHERE Request_ID = @fb_ID AND Approver_ID = @SystemApprover)
                    UPDATE HR_RequestLeave_History
                    SET Approver_Name = N'Chuyển cấp xử lý cuối (quá hạn)', Approve_Date = @Now,
                        ApproveLevel = @fb_ApproveLevelHist, DepartmentCode = @fb_DepartmentName, Chucdanh = @fb_ChucDanh
                    WHERE Request_ID = @fb_ID AND Approver_ID = @SystemApprover;
                ELSE
                    INSERT INTO HR_RequestLeave_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
                    VALUES (@fb_ID, @SystemApprover, N'Chuyển cấp xử lý cuối (quá hạn)', @Now, @fb_ApproveLevelHist, @fb_DepartmentName, @fb_ChucDanh);

                DELETE HR_DanhSachNguoiNhanThongBao
                WHERE Employee_ID = @fb_Employee_ID AND Type_ = N'RequestLeave';

                INSERT INTO HR_DanhSachNguoiNhanThongBao (
                    Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao,
                    NotifyViaWeb, NotifyViaEmail, NotifyViaZalo
                )
                SELECT @fb_Employee_ID, dt.[Data], @fb_Employee_Name, N'RequestLeave', ISNULL(empl.Email, N''), 0, 0,
                       ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
                FROM Split(@fb_FallbackApprovers, ',') dt
                LEFT JOIN SmartBooks_Employee empl ON empl.Employee_ID = dt.[Data]
                CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@fb_RequestType, @fb_FlowCode, @fb_StepOrder, 0) ch
                WHERE dt.[Data] <> N'';
            END
            ELSE
            BEGIN
                UPDATE HR_LeaveRequestGoOut
                SET ApproveLevel = @fb_FallbackApprovers,
                    ThuTuDuyet = @fb_NewThuTuDuyet,
                    CurrentStepSince = @Now
                WHERE ID = @fb_ID;

                IF EXISTS (SELECT 1 FROM HR_RequestLeaveGoOut_History WHERE Request_ID = @fb_ID AND Approver_ID = @SystemApprover)
                    UPDATE HR_RequestLeaveGoOut_History
                    SET Approver_Name = N'Chuyển cấp xử lý cuối (quá hạn)', Approve_Date = @Now,
                        ApproveLevel = @fb_ApproveLevelHist, DepartmentCode = @fb_DepartmentName, Chucdanh = @fb_ChucDanh
                    WHERE Request_ID = @fb_ID AND Approver_ID = @SystemApprover;
                ELSE
                    INSERT INTO HR_RequestLeaveGoOut_History (Request_ID, Approver_ID, Approver_Name, Approve_Date, ApproveLevel, DepartmentCode, Chucdanh)
                    VALUES (@fb_ID, @SystemApprover, N'Chuyển cấp xử lý cuối (quá hạn)', @Now, @fb_ApproveLevelHist, @fb_DepartmentName, @fb_ChucDanh);

                DELETE HR_DanhSachNguoiNhanThongBao
                WHERE Employee_ID = @fb_Employee_ID AND Type_ = N'RequestGoOut';

                INSERT INTO HR_DanhSachNguoiNhanThongBao (
                    Employee_ID, Approver_ID, Fullname, Type_, Email1, Sended, ChiNhanThongBao,
                    NotifyViaWeb, NotifyViaEmail, NotifyViaZalo
                )
                SELECT @fb_Employee_ID, dt.[Data], @fb_Employee_Name, N'RequestGoOut', ISNULL(empl.Email, N''), 0, 0,
                       ch.NotifyViaWeb, ch.NotifyViaEmail, ch.NotifyViaZalo
                FROM Split(@fb_FallbackApprovers, ',') dt
                LEFT JOIN SmartBooks_Employee empl ON empl.Employee_ID = dt.[Data]
                CROSS APPLY dbo.udf_ApprovalNotifyChannels_Web(@fb_RequestType, @fb_FlowCode, @fb_StepOrder, 0) ch
                WHERE dt.[Data] <> N'';
            END

            COMMIT TRANSACTION FallbackOne;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION FallbackOne;
        END CATCH

        FETCH NEXT FROM fb_cur INTO @fb_RequestKind, @fb_ID, @fb_Employee_ID, @fb_RequestType, @fb_FlowCode, @fb_StepOrder, @fb_FallbackLevelCode;
    END

    CLOSE fb_cur;
    DEALLOCATE fb_cur;
END

GO
