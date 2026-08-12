/*
  Trả về danh sách candidate đã resolve theo TỪNG STEP cho 1 nhân viên cụ thể,
  phục vụ màn tạo đơn (cho phép chọn approver khi step đó bật AllowSelectApprover
  và có >1 candidate). Khác với sp_GetApprover_Run_Web: KHÔNG gộp STRING_AGG các
  step thành 1 chuỗi, không ghi vào bảng cache HR_GetApprover — chỉ đọc, trả rời
  từng dòng theo StepOrder.

  Logic resolve candidate (theo HR_ApprovalRule/HR_ApprovalLevelMember/
  HR_ApprovalScopeGroupMember/HR_ApprovalRuleMember) sao chép nguyên trạng từ
  sp_GetApprover_Run_Web để đảm bảo nhất quán — nếu sửa 1 trong 2 SP, cần soát
  lại SP còn lại.
*/
CREATE   PROCEDURE [dbo].[sp_GetApprovalStepCandidates_Web]
    @Account nvarchar(50),
    @RequestType nvarchar(50) = N'RequestLeave',
    @LAN nvarchar(50) = N'VN',
    @Date datetime = null
AS
BEGIN
    SET NOCOUNT ON;

    IF @Date IS NULL
        SET @Date = GETDATE();

    SET @RequestType = ISNULL(NULLIF(LTRIM(RTRIM(@RequestType)), N''), N'RequestLeave');

    CREATE TABLE #Emp (
        Employee_ID nvarchar(50) NOT NULL PRIMARY KEY,
        FullName nvarchar(200) NULL,
        Factory_ID nvarchar(200) NULL,
        DepartmentName nvarchar(200) NULL,
        SectionName nvarchar(200) NULL,
        ChucDanh nvarchar(200) NULL,
        LvDuyet nvarchar(50) NULL,
        LvDuyetNorm nvarchar(50) NULL,
        DepartmentCode1 nvarchar(200) NULL
    );

    INSERT INTO #Emp (
        Employee_ID, FullName, Factory_ID, DepartmentName, SectionName,
        ChucDanh, LvDuyet, LvDuyetNorm, DepartmentCode1
    )
    SELECT
        ef.Employee_ID,
        dbo.udf_FullName(ef.Employee_Firstname, ef.Employee_LastName),
        ef.FactoryName,
        ef.DepartmentName,
        ef.SectionName,
        ef.ChucDanh,
        CAST(ef.LvDuyet AS nvarchar(50)),
        NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N''),
        ef.DepartmentCode1
    FROM udf_EmployeeFilter_Web(@LAN, null, null, null, null, null, null, null, @Date) ef;

    CREATE TABLE #TargetEmp (
        Employee_ID nvarchar(50) NOT NULL PRIMARY KEY,
        FullName nvarchar(200) NULL,
        Factory_ID nvarchar(200) NULL,
        DepartmentName nvarchar(200) NULL,
        SectionName nvarchar(200) NULL,
        ChucDanh nvarchar(200) NULL,
        LvDuyetNorm nvarchar(50) NULL,
        DepartmentCode1 nvarchar(200) NULL
    );

    INSERT INTO #TargetEmp (
        Employee_ID, FullName, Factory_ID, DepartmentName, SectionName,
        ChucDanh, LvDuyetNorm, DepartmentCode1
    )
    SELECT
        e.Employee_ID, e.FullName, e.Factory_ID, e.DepartmentName,
        e.SectionName, e.ChucDanh, e.LvDuyetNorm, e.DepartmentCode1
    FROM #Emp e
    WHERE e.LvDuyetNorm IS NOT NULL
      AND (
            @Account IS NULL
            OR e.Employee_ID = @Account
            OR EXISTS (
                SELECT 1
                FROM [User] us
                WHERE us.UserName = @Account
                  AND us.Employee_ID = e.Employee_ID
            )
          );

    CREATE TABLE #Resolved (
        Employee_ID nvarchar(50) NOT NULL,
        Factory_ID nvarchar(200) NULL,
        DepartmentCode nvarchar(200) NULL,
        SectionCode nvarchar(200) NULL,
        ChucDanh nvarchar(200) NULL,
        StepOrder int NOT NULL,
        PickPriority int NOT NULL,
        Approver nvarchar(50) NOT NULL,
        ApproverName nvarchar(500) NULL,
        IsNotifyOnly bit NOT NULL,
        AllowSelectApprover bit NOT NULL
    );

    INSERT INTO #Resolved (
        Employee_ID, Factory_ID, DepartmentCode, SectionCode, ChucDanh,
        StepOrder, PickPriority, Approver, ApproverName, IsNotifyOnly, AllowSelectApprover
    )
    SELECT
        te.Employee_ID,
        te.Factory_ID,
        te.DepartmentName,
        te.SectionName,
        te.ChucDanh,
        st.StepOrder,
        primaryPick.PickPriority,
        primaryPick.Employee_ID AS Approver,
        COALESCE(primaryPick.FullName, primaryPick.Employee_ID) AS ApproverName,
        CASE WHEN ISNULL(r.IsNotifyOnly, 0) = 1 OR st.StepType = N'NotifyOnly' THEN 1 ELSE 0 END AS IsNotifyOnly,
        ISNULL(r.AllowSelectApprover, 0) AS AllowSelectApprover
    FROM #TargetEmp te
    INNER JOIN HR_ApprovalFlow f
        ON f.RequestType = @RequestType
       AND f.FlowCode = te.LvDuyetNorm
       AND f.IsActive = 1
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.IsActive = 1
       AND st.StepType IN (N'Approval', N'NotifyOnly')
    INNER JOIN HR_ApprovalRule r
        ON r.StepID = st.StepID
       AND r.IsActive = 1
    OUTER APPLY (
        SELECT picked.Employee_ID, picked.FullName, picked.PickPriority
        FROM (
            SELECT
                lm.Employee_ID,
                COALESCE(emp.FullName, dbo.udf_FullName(se.Employee_Firstname, se.Employee_LastName), lm.Employee_ID) AS FullName,
                ISNULL(lm.Priority, 1000) AS PickPriority
            FROM HR_ApprovalLevelMember lm
            LEFT JOIN #Emp emp
                ON emp.Employee_ID = lm.Employee_ID
            LEFT JOIN SmartBooks_Employee se
                ON se.Employee_ID = lm.Employee_ID
            WHERE r.ResolveType = N'ByLevelManager'
              AND lm.LevelCode = NULLIF(LTRIM(RTRIM(r.TargetLevel)), N'')
              AND lm.IsActive = 1
              AND (
                    r.ScopeType = N'None'
                    OR (r.ScopeType = N'SameFactory' AND ISNULL(emp.Factory_ID, N'') = ISNULL(te.Factory_ID, N''))
                    OR (r.ScopeType = N'SameDepartment' AND ISNULL(emp.DepartmentName, N'') = ISNULL(te.DepartmentName, N''))
                    OR (
                        r.ScopeType = N'FactoryGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember approverGroup
                                ON approverGroup.GroupCode = empGroup.GroupCode
                               AND approverGroup.ScopeType = N'Factory'
                               AND approverGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Factory'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = te.Factory_ID
                              AND approverGroup.ScopeValue = emp.Factory_ID
                        )
                    )
                    OR (
                        r.ScopeType = N'DepartmentGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember approverGroup
                                ON approverGroup.GroupCode = empGroup.GroupCode
                               AND approverGroup.ScopeType = N'Department'
                               AND approverGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Department'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = te.DepartmentName
                              AND approverGroup.ScopeValue = emp.DepartmentName
                        )
                    )
                  )

            UNION ALL

            SELECT
                cand.Employee_ID,
                cand.FullName,
                1000 AS PickPriority
            FROM #Emp cand
            WHERE r.ResolveType = N'ByLevelManager'
              AND cand.LvDuyetNorm = NULLIF(LTRIM(RTRIM(r.TargetLevel)), N'')
              AND NOT EXISTS (
                    SELECT 1
                    FROM HR_ApprovalLevelMember lm
                    WHERE lm.LevelCode = NULLIF(LTRIM(RTRIM(r.TargetLevel)), N'')
                      AND lm.IsActive = 1
                  )
              AND (
                    r.ScopeType = N'None'
                    OR (r.ScopeType = N'SameFactory' AND ISNULL(cand.Factory_ID, N'') = ISNULL(te.Factory_ID, N''))
                    OR (r.ScopeType = N'SameDepartment' AND ISNULL(cand.DepartmentName, N'') = ISNULL(te.DepartmentName, N''))
                    OR (
                        r.ScopeType = N'FactoryGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember candGroup
                                ON candGroup.GroupCode = empGroup.GroupCode
                               AND candGroup.ScopeType = N'Factory'
                               AND candGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Factory'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = te.Factory_ID
                              AND candGroup.ScopeValue = cand.Factory_ID
                        )
                    )
                    OR (
                        r.ScopeType = N'DepartmentGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember candGroup
                                ON candGroup.GroupCode = empGroup.GroupCode
                               AND candGroup.ScopeType = N'Department'
                               AND candGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Department'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = te.DepartmentName
                              AND candGroup.ScopeValue = cand.DepartmentName
                        )
                    )
                  )

            UNION ALL

            SELECT
                rm.Employee_ID,
                COALESCE(emp.FullName, dbo.udf_FullName(se.Employee_Firstname, se.Employee_LastName), rm.Employee_ID) AS FullName,
                ISNULL(rm.Priority, 1000) AS PickPriority
            FROM HR_ApprovalRuleMember rm
            LEFT JOIN #Emp emp
                ON emp.Employee_ID = rm.Employee_ID
            LEFT JOIN SmartBooks_Employee se
                ON se.Employee_ID = rm.Employee_ID
            WHERE r.ResolveType = N'FixedEmployee'
              AND rm.RuleID = r.RuleID
              AND rm.IsActive = 1
              AND (@Date >= ISNULL(rm.FromDate, @Date) AND @Date <= ISNULL(rm.ToDate, @Date))
              AND (
                    r.ScopeType = N'None'
                    OR (r.ScopeType = N'SameFactory' AND (rm.Factory_ID IS NULL OR rm.Factory_ID = te.Factory_ID))
                    OR (r.ScopeType = N'SameDepartment' AND (rm.DepartmentCode IS NULL OR rm.DepartmentCode IN (te.DepartmentName, te.DepartmentCode1)))
                    OR (
                        r.ScopeType = N'FactoryGroup'
                        AND (
                            rm.FactoryGroupCode IS NULL
                            OR EXISTS (
                                SELECT 1
                                FROM HR_ApprovalScopeGroupMember scopeMember
                                WHERE scopeMember.GroupCode = rm.FactoryGroupCode
                                  AND scopeMember.ScopeType = N'Factory'
                                  AND scopeMember.ScopeValue = te.Factory_ID
                                  AND scopeMember.IsActive = 1
                            )
                        )
                    )
                    OR (
                        r.ScopeType = N'DepartmentGroup'
                        AND (
                            rm.FactoryGroupCode IS NULL
                            OR EXISTS (
                                SELECT 1
                                FROM HR_ApprovalScopeGroupMember scopeMember
                                WHERE scopeMember.GroupCode = rm.FactoryGroupCode
                                  AND scopeMember.ScopeType = N'Department'
                                  AND scopeMember.ScopeValue = te.DepartmentName
                                  AND scopeMember.IsActive = 1
                            )
                        )
                    )
                  )
        ) picked
        WHERE picked.Employee_ID IS NOT NULL
    ) primaryPick
    WHERE primaryPick.Employee_ID IS NOT NULL;

    SELECT DISTINCT
        r.StepOrder,
        r.Approver AS Code,
        r.ApproverName AS [Name],
        r.AllowSelectApprover
    FROM #Resolved r
    WHERE r.IsNotifyOnly = 0
    ORDER BY r.StepOrder, r.Approver;
END

GO
