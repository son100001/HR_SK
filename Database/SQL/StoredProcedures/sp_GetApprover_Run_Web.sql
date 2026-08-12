/*
  Web approval rebuild engine.

  This procedure intentionally does not hardcode company-specific people
  or factory codes. It reads the approval rule
  configuration tables and still writes the legacy HR_GetApprover cache.
*/
CREATE   PROCEDURE [dbo].[sp_GetApprover_Run_Web]
    @Account nvarchar(50),
    @TypeOfReport int,
    @LAN nvarchar(50) = N'VN',
    @Date datetime = null,
    @LuongDuyet nvarchar(50) = NULL,
    @RequestType nvarchar(50) = N'RequestLeave'
AS
BEGIN
    SET NOCOUNT ON;

    IF @Date IS NULL
        SET @Date = GETDATE();

    DECLARE @FlowFilter nvarchar(50) = NULLIF(LTRIM(RTRIM(@LuongDuyet)), N'');
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
      AND (@FlowFilter IS NULL OR e.LvDuyetNorm = @FlowFilter)
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
        IsNotifyOnly bit NOT NULL
    );

    INSERT INTO #Resolved (
        Employee_ID, Factory_ID, DepartmentCode, SectionCode, ChucDanh,
        StepOrder, PickPriority, Approver, ApproverName, IsNotifyOnly
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
        CASE WHEN ISNULL(r.IsNotifyOnly, 0) = 1 OR st.StepType = N'NotifyOnly' THEN 1 ELSE 0 END AS IsNotifyOnly
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
                    -- DepartmentGroup cho FixedEmployee: dùng rm.FactoryGroupCode như tham chiếu
                    -- nhóm chung (một nhóm là một nhóm), so member ScopeType='Department'.
                    -- Nhánh này không đạt tới từ UI vì NormalizeScopeType ép FixedEmployee -> None;
                    -- thêm để engine nhất quán với FactoryGroup.
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

    CREATE TABLE #RtnGetApprover (
        Factory_ID nvarchar(50) NULL,
        DepartmentCode nvarchar(200) NULL,
        SectionName nvarchar(200) NULL,
        ChucDanh nvarchar(200) NULL,
        Employee_ID nvarchar(50) NOT NULL,
        Code nvarchar(200) NOT NULL,
        [Name] nvarchar(500) NULL,
        ChiGuiThongBao nvarchar(200) NULL,
        RequestType nvarchar(50) NOT NULL,
        PRIMARY KEY (Employee_ID, Code, RequestType)
    );

    ;WITH Agg AS (
        SELECT
            r.Employee_ID,
            MAX(r.Factory_ID) AS Factory_ID,
            MAX(r.DepartmentCode) AS DepartmentCode,
            MAX(r.SectionCode) AS SectionName,
            MAX(r.ChucDanh) AS ChucDanh,
            STRING_AGG(CASE WHEN r.IsNotifyOnly = 0 THEN CAST(r.Approver AS nvarchar(50)) END, N',')
                WITHIN GROUP (ORDER BY r.StepOrder, r.PickPriority, r.Approver) AS ApproverCode,
            STRING_AGG(CASE WHEN r.IsNotifyOnly = 0 THEN r.ApproverName END, N', ')
                WITHIN GROUP (ORDER BY r.StepOrder, r.PickPriority, r.Approver) AS ApproverName,
            STRING_AGG(CASE WHEN r.IsNotifyOnly = 1 THEN CAST(r.Approver AS nvarchar(50)) END, N',')
                WITHIN GROUP (ORDER BY r.StepOrder, r.PickPriority, r.Approver) AS NotifyOnlyCodes
        FROM #Resolved r
        GROUP BY r.Employee_ID
    )
    INSERT INTO #RtnGetApprover (Factory_ID, DepartmentCode, SectionName, ChucDanh, Employee_ID, Code, [Name], ChiGuiThongBao, RequestType)
    SELECT
        Factory_ID,
        DepartmentCode,
        SectionName,
        ChucDanh,
        Employee_ID,
        ApproverCode,
        ApproverName,
        NotifyOnlyCodes,
        @RequestType
    FROM Agg
    WHERE ApproverCode IS NOT NULL
      AND LTRIM(RTRIM(ApproverCode)) <> N'';

    DELETE ga
    FROM HR_GetApprover ga
    INNER JOIN #TargetEmp te
        ON te.Employee_ID = ga.Employee_ID
    WHERE ga.RequestType = @RequestType;

    IF @Account IS NULL AND @FlowFilter IS NULL
    BEGIN
        DELETE FROM HR_GetApprover
        WHERE Employee_ID = N'All'
          AND RequestType = @RequestType;
    END

    INSERT INTO HR_GetApprover (Factory_ID, DepartmentCode, SectionCode, ChucDanh, Employee_ID, Code, [Name], ChiGuiThongBao, RequestType)
    SELECT Factory_ID, DepartmentCode, SectionName, ChucDanh, Employee_ID, Code, [Name], ChiGuiThongBao, RequestType
    FROM #RtnGetApprover;

    /* -----------------------------------------------------------------
       Per-employee approval-config status.
       An approval level is "empty" (Trống) for an employee when a required
       approval step of their flow resolved to nobody in #Resolved.
       HasEmptyLevel = (distinct resolved approval steps) < (required approval steps).
       Skipped when HR_ApproverConfigStatus does not exist (pre-migration).
       ----------------------------------------------------------------- */
    IF OBJECT_ID('dbo.HR_ApproverConfigStatus') IS NOT NULL
    BEGIN
        DELETE cs
        FROM HR_ApproverConfigStatus cs
        INNER JOIN #TargetEmp te ON te.Employee_ID = cs.Employee_ID
        WHERE cs.RequestType = @RequestType;

        ;WITH FlowReq AS (
            SELECT f.FlowCode, COUNT(DISTINCT st.StepOrder) AS RequiredSteps
            FROM HR_ApprovalFlow f
            INNER JOIN HR_ApprovalStep st
                ON st.FlowID = f.FlowID AND st.IsActive = 1 AND st.StepType = N'Approval'
            INNER JOIN HR_ApprovalRule r
                ON r.StepID = st.StepID AND r.IsActive = 1 AND ISNULL(r.IsNotifyOnly, 0) = 0
            WHERE f.RequestType = @RequestType AND f.IsActive = 1
            GROUP BY f.FlowCode
        ),
        EmpStatus AS (
            SELECT
                te.Employee_ID,
                ISNULL(fr.RequiredSteps, 0) AS RequiredSteps,
                ISNULL(res.ResolvedSteps, 0) AS ResolvedSteps
            FROM #TargetEmp te
            LEFT JOIN FlowReq fr ON fr.FlowCode = te.LvDuyetNorm
            OUTER APPLY (
                SELECT COUNT(DISTINCT rr.StepOrder) AS ResolvedSteps
                FROM #Resolved rr
                WHERE rr.Employee_ID = te.Employee_ID AND rr.IsNotifyOnly = 0
            ) res
        )
        INSERT INTO HR_ApproverConfigStatus
            (Employee_ID, RequestType, RequiredApprovalSteps, ResolvedApprovalSteps, HasEmptyLevel, UpdatedAt)
        SELECT
            s.Employee_ID, @RequestType, s.RequiredSteps, s.ResolvedSteps,
            CASE WHEN s.ResolvedSteps < s.RequiredSteps THEN 1 ELSE 0 END,
            @Date
        FROM EmpStatus s;
    END

    SELECT * FROM #RtnGetApprover;
END

GO
