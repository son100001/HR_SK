/*
  Web HR approval config workspace.

  Result sets:
  1) Flow list — HR_ApprovalFlow UNION resolved LvDuyet (udf_EmployeeFilter_Web)
  2) Applied job titles for selected flow (HR_ApprovalFlowJobTitle scope)
  3) Employees in selected flow (derived from job title scope via udf_EmployeeFilter_Web)
  4) Approval levels/rules with preview — HR_ApprovalFlow/Step/Rule only
  5) Employees in selected flow with rebuilt approver cache

  ViewAllEmployees: employee list matches sp_BangThongTinNhanVien @TypeOfReport = 6
  (udf_EmployeeFilter_Web + ComStartedDate / TernimationDate as-of @Date).
*/
CREATE   PROCEDURE [dbo].[sp_ApprovalConfig_GetWorkspace_Web]
    @LuongDuyet nvarchar(50) = NULL,
    @LAN nvarchar(50) = N'VN',
    @EmployeeSearch nvarchar(200) = NULL,
    @LoaiDuyet nvarchar(50) = N'RequestLeave',
    @ViewAllEmployees bit = 0,
    @PageNumber int = 1,
    @PageSize int = 50,
    @FilterFactory nvarchar(200) = NULL,
    @FilterDepartment nvarchar(200) = NULL,
    @FilterFlow nvarchar(50) = NULL,
    @OnlyUnconfigured bit = 0,
    @OnlyMissingLevel bit = 0
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Date datetime = GETDATE();
    DECLARE @AsOfDate date = CAST(@Date AS date);
    DECLARE @Search nvarchar(200) = NULLIF(LTRIM(RTRIM(@EmployeeSearch)), N'');
    DECLARE @FltFactory nvarchar(200) = NULLIF(LTRIM(RTRIM(@FilterFactory)), N'');
    DECLARE @FltDepartment nvarchar(200) = NULLIF(LTRIM(RTRIM(@FilterDepartment)), N'');
    DECLARE @FltFlow nvarchar(50) = NULLIF(LTRIM(RTRIM(@FilterFlow)), N'');
    DECLARE @Flow nvarchar(50) = NULLIF(LTRIM(RTRIM(@LuongDuyet)), N'');
    DECLARE @RequestType nvarchar(50) = ISNULL(NULLIF(LTRIM(RTRIM(@LoaiDuyet)), N''), N'RequestLeave');
    DECLARE @SafePageNumber int = CASE WHEN ISNULL(@PageNumber, 0) <= 0 THEN 1 ELSE @PageNumber END;
    DECLARE @SafePageSize int = CASE WHEN ISNULL(@PageSize, 0) <= 0 THEN 50 WHEN @PageSize > 500 THEN 500 ELSE @PageSize END;
    DECLARE @Offset int = (@SafePageNumber - 1) * @SafePageSize;

    IF @ViewAllEmployees = 1
    BEGIN
        SELECT CAST(NULL AS nvarchar(50)) AS LuongDuyet,
            CAST(NULL AS nvarchar(200)) AS FlowLabel,
            CAST(0 AS int) AS EmployeeCount
        WHERE 1 = 0;

        SELECT
            st.StepID AS ID,
            f.RequestType AS LoaiDuyet,
            f.FlowCode AS LuongDuyet,
            CAST(st.StepOrder AS nvarchar(50)) AS ThuTuDuyet,
            CAST(st.StepOrder AS nvarchar(50)) AS LevelOrder,
            r.TargetLevel AS CapBacDuyet,
            r.IsNotifyOnly AS ChiGuiThongBao,
            st.IsRequired AS General,
            CAST(NULL AS nvarchar(200)) AS LuongDuyetLabel,
            CAST(NULL AS nvarchar(200)) AS CapBacDuyetLabel,
            CAST(NULL AS nvarchar(50)) AS PreviewApproverCode,
            CAST(NULL AS nvarchar(200)) AS PreviewApproverName,
            CAST(NULL AS nvarchar(200)) AS PreviewEmail,
            r.ResolveType,
            r.ScopeType,
            r.GroupCode,
            fixedMember.Employee_ID AS FixedEmployee_ID,
            CAST(NULL AS nvarchar(200)) AS FixedEmployeeName,
            ISNULL(st.EscalationEnabled, 0) AS EscalationEnabled,
            st.EscalationValue,
            st.EscalationUnit,
            st.EscalationAfterHours
        FROM HR_ApprovalFlow f
        INNER JOIN HR_ApprovalStep st
            ON st.FlowID = f.FlowID
           AND st.IsActive = 1
           AND st.StepType IN (N'Approval', N'NotifyOnly')
        INNER JOIN HR_ApprovalRule r
            ON r.StepID = st.StepID
           AND r.IsActive = 1
        OUTER APPLY (
            SELECT TOP 1 rm.Employee_ID
            FROM HR_ApprovalRuleMember rm
            WHERE rm.RuleID = r.RuleID
              AND rm.IsActive = 1
            ORDER BY rm.Priority, rm.Employee_ID
        ) fixedMember
        WHERE f.RequestType = @RequestType
          AND f.IsActive = 1
        ORDER BY f.FlowCode, st.StepOrder, st.StepID;

        /* Materialize the active population ONCE — udf_EmployeeFilter_Web is a heavy
           multi-statement TVF; reuse it for both the employee page and the filter
           option lists instead of calling it 3 times. */
        IF OBJECT_ID('tempdb..#EmpAllView') IS NOT NULL DROP TABLE #EmpAllView;
        SELECT
            ef.Employee_ID,
            dbo.udf_FullName(ef.Employee_Firstname, ef.Employee_LastName) AS FullName,
            ef.FactoryName,
            ef.DepartmentName,
            NULLIF(LTRIM(RTRIM(COALESCE(ef.ChucDanhName, CAST(ef.ChucDanh AS nvarchar(200)), N''))), N'') AS JobTitle,
            NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'') AS LuongDuyet
        INTO #EmpAllView
        FROM udf_EmployeeFilter_Web(@LAN, null, null, null, null, null, null, null, @Date) ef
        WHERE ef.ComStartedDate <= @Date
          AND (ef.TernimationDate IS NULL OR ef.TernimationDate > @AsOfDate);

        ;WITH ApproverAgg AS (
            SELECT
                ga.Employee_ID,
                STRING_AGG(ga.Code, N', ')
                    WITHIN GROUP (ORDER BY ga.Code) AS ApproverCodes,
                STRING_AGG(ga.[Name], N', ')
                    WITHIN GROUP (ORDER BY ga.Code) AS ApproverNames,
                STRING_AGG(NULLIF(LTRIM(RTRIM(ga.ChiGuiThongBao)), N''), N', ')
                    WITHIN GROUP (ORDER BY ga.Code) AS NotifyOnlyCodes
            FROM HR_GetApprover ga
            WHERE ga.Employee_ID <> N'All'
              AND ga.RequestType = @RequestType
            GROUP BY ga.Employee_ID
        ),
        FilteredEmployees AS (
            SELECT
                ei.Employee_ID,
                ei.FullName,
                ei.FactoryName,
                ei.DepartmentName,
                ei.JobTitle,
                ei.LuongDuyet,
                aa.ApproverCodes,
                aa.ApproverNames,
                ISNULL(aa.ApproverCodes, N'') AS ApproversSummary,
                aa.NotifyOnlyCodes
            FROM #EmpAllView ei
            LEFT JOIN ApproverAgg aa ON aa.Employee_ID = ei.Employee_ID
            LEFT JOIN HR_ApproverConfigStatus cs
                ON cs.Employee_ID = ei.Employee_ID AND cs.RequestType = @RequestType
            WHERE (
                    @Search IS NULL
                    OR ei.Employee_ID LIKE N'%' + @Search + N'%'
                    OR ISNULL(ei.FullName, N'') LIKE N'%' + @Search + N'%'
                    OR ISNULL(ei.FactoryName, N'') LIKE N'%' + @Search + N'%'
                    OR ISNULL(ei.DepartmentName, N'') LIKE N'%' + @Search + N'%'
                    OR ISNULL(ei.JobTitle, N'') LIKE N'%' + @Search + N'%'
                  )
              AND (@FltFactory IS NULL OR ei.FactoryName = @FltFactory)
              AND (@FltDepartment IS NULL OR ei.DepartmentName = @FltDepartment)
              AND (@FltFlow IS NULL OR ei.LuongDuyet = @FltFlow)
              AND (
                    (@OnlyUnconfigured = 0 AND @OnlyMissingLevel = 0)
                    OR (@OnlyUnconfigured = 1 AND (ei.LuongDuyet IS NULL OR aa.ApproverCodes IS NULL))
                    OR (@OnlyMissingLevel = 1 AND ISNULL(cs.HasEmptyLevel, 0) = 1)
                  )
        ),
        PagedEmployees AS (
            SELECT
                fe.*,
                COUNT(*) OVER() AS TotalRecords,
                ROW_NUMBER() OVER (ORDER BY fe.JobTitle, fe.Employee_ID) AS RowNumber
            FROM FilteredEmployees fe
        )
        SELECT
            Employee_ID,
            FullName,
            FactoryName,
            DepartmentName,
            JobTitle,
            LuongDuyet,
            ApproverCodes,
            ApproverNames,
            ApproversSummary,
            NotifyOnlyCodes,
            TotalRecords
        FROM PagedEmployees
        WHERE RowNumber > @Offset
          AND RowNumber <= @Offset + @SafePageSize
        ORDER BY RowNumber;

        /* Filter option lists (distinct factory + department of the active population).
           Emitted only on the first page — FE caches them; reader skips via NextResult. */
        IF @SafePageNumber <= 1
        BEGIN
            SELECT OptType, OptValue
            FROM (
                SELECT DISTINCT N'F' AS OptType, ev.FactoryName AS OptValue
                FROM #EmpAllView ev
                WHERE NULLIF(LTRIM(RTRIM(ev.FactoryName)), N'') IS NOT NULL
                UNION
                SELECT DISTINCT N'D' AS OptType, ev.DepartmentName AS OptValue
                FROM #EmpAllView ev
                WHERE NULLIF(LTRIM(RTRIM(ev.DepartmentName)), N'') IS NOT NULL
            ) opts
            ORDER BY OptType, OptValue;
        END

        DROP TABLE #EmpAllView;
        RETURN;
    END

    CREATE TABLE #Emp (
        Employee_ID nvarchar(50) NOT NULL PRIMARY KEY,
        FullName nvarchar(200) NULL,
        FactoryName nvarchar(200) NULL,
        DepartmentName nvarchar(200) NULL,
        DepartmentCode1 nvarchar(200) NULL,
        LvDuyet nvarchar(50) NULL,
        LvDuyetNorm nvarchar(50) NULL,
        ChucDanh nvarchar(200) NULL,
        JobTitle nvarchar(200) NULL
    );

    INSERT INTO #Emp (
        Employee_ID, FullName, FactoryName, DepartmentName,
        DepartmentCode1, LvDuyet, LvDuyetNorm, ChucDanh, JobTitle
    )
    SELECT
        ef.Employee_ID,
        dbo.udf_FullName(ef.Employee_Firstname, ef.Employee_LastName),
        ef.FactoryName,
        ef.DepartmentName,
        ef.DepartmentCode1,
        CAST(ef.LvDuyet AS nvarchar(50)),
        NULLIF(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N''),
        NULLIF(LTRIM(RTRIM(CAST(ef.ChucDanh AS nvarchar(200)))), N''),
        NULLIF(LTRIM(RTRIM(COALESCE(ef.ChucDanhName, CAST(ef.ChucDanh AS nvarchar(200)), N''))), N'')
    FROM udf_EmployeeFilter_Web(@LAN, null, null, null, null, null, null, null, @Date) ef;

    CREATE TABLE #ApprovalLevel (
        NameEN nvarchar(50) NOT NULL PRIMARY KEY,
        NameVN nvarchar(200) NULL,
        NameEN2 nvarchar(200) NULL,
        NameKR nvarchar(200) NULL
    );

    INSERT INTO #ApprovalLevel (NameEN, NameVN, NameEN2, NameKR)
    SELECT
        LTRIM(RTRIM(LevelCode)) AS NameEN,
        MIN(COALESCE(LevelNameVN, LevelNameEN, LevelCode)) AS NameVN,
        MIN(COALESCE(LevelNameEN, LevelNameVN, LevelCode)) AS NameEN2,
        MIN(COALESCE(LevelNameKR, LevelNameEN, LevelNameVN, LevelCode)) AS NameKR
    FROM HR_ApprovalLevel
    WHERE IsActive = 1
      AND ISNULL(LTRIM(RTRIM(LevelCode)), N'') <> N''
    GROUP BY LTRIM(RTRIM(LevelCode));

    IF @Flow IS NULL
    BEGIN
        ;WITH FlowCodes AS (
            SELECT DISTINCT f.FlowCode AS LuongDuyet
            FROM HR_ApprovalFlow f
            WHERE f.RequestType = @RequestType
              AND f.IsActive = 1
            UNION
            SELECT DISTINCT e.LvDuyetNorm AS LuongDuyet
            FROM #Emp e
            WHERE e.LvDuyetNorm IS NOT NULL AND e.LvDuyetNorm <> N''
        ),
        EmpCounts AS (
            SELECT e.LvDuyetNorm AS LuongDuyet, COUNT(*) AS EmployeeCount
            FROM #Emp e
            WHERE e.LvDuyetNorm IS NOT NULL AND e.LvDuyetNorm <> N''
            GROUP BY e.LvDuyetNorm
        )
        SELECT
            fc.LuongDuyet,
            ISNULL(flowCfg.FlowName, N'Luong ' + fc.LuongDuyet) AS FlowLabel,
            ISNULL(ec.EmployeeCount, 0) AS EmployeeCount
        FROM FlowCodes fc
        LEFT JOIN HR_ApprovalFlow flowCfg
            ON flowCfg.RequestType = @RequestType
           AND flowCfg.FlowCode = fc.LuongDuyet
           AND flowCfg.IsActive = 1
        LEFT JOIN EmpCounts ec ON ec.LuongDuyet = fc.LuongDuyet
        ORDER BY TRY_CAST(fc.LuongDuyet AS INT), fc.LuongDuyet;
        RETURN;
    END

    SELECT CAST(NULL AS nvarchar(50)) AS LuongDuyet,
        CAST(NULL AS nvarchar(200)) AS FlowLabel,
        CAST(0 AS int) AS EmployeeCount
    WHERE 1 = 0;

    DECLARE @SampleFactory nvarchar(200);
    DECLARE @SampleDepartment nvarchar(200);

    SELECT TOP 1
        @SampleFactory = e.FactoryName,
        @SampleDepartment = e.DepartmentName
    FROM #Emp e
    WHERE e.LvDuyetNorm = @Flow
    ORDER BY e.Employee_ID;

    SELECT
        CASE @LAN
            WHEN N'EN' THEN ISNULL(NULLIF(LTRIM(RTRIM(cd.NameEN)), N''), cd.ChucDanh)
            WHEN N'KR' THEN ISNULL(NULLIF(LTRIM(RTRIM(cd.NameKR)), N''), cd.ChucDanh)
            ELSE ISNULL(NULLIF(LTRIM(RTRIM(cd.NameVN)), N''), cd.ChucDanh)
        END AS JobTitle,
        jt.ChucDanh,
        ISNULL((
            SELECT COUNT(*)
            FROM #Emp e
            WHERE e.LvDuyetNorm = @Flow
              AND e.ChucDanh = jt.ChucDanh
        ), 0) AS EmployeeCount
    FROM HR_ApprovalFlowJobTitle jt
    INNER JOIN HR_ChucDanh cd ON cd.ChucDanh = jt.ChucDanh
    WHERE jt.FlowCode = @Flow
      AND jt.IsActive = 1
    ORDER BY JobTitle;

    SELECT
        e.Employee_ID,
        e.FullName,
        ISNULL(e.DepartmentName, e.DepartmentCode1) AS DepartmentName
    FROM #Emp e
    WHERE e.LvDuyetNorm = @Flow
    ORDER BY e.Employee_ID;

    CREATE TABLE #Levels (
        ID int NULL,
        RuleID int NULL,
        LoaiDuyet nvarchar(50) NOT NULL,
        LuongDuyet nvarchar(50) NOT NULL,
        ThuTuDuyet nvarchar(50) NOT NULL,
        StepOrder int NOT NULL,
        CapBacDuyet nvarchar(50) NULL,
        ChiGuiThongBao bit NULL,
        General bit NULL,
        NotifyViaWeb bit NULL,
        NotifyViaEmail bit NULL,
        NotifyViaZalo bit NULL,
        ResolveType nvarchar(50) NULL,
        ScopeType nvarchar(50) NULL,
        GroupCode nvarchar(50) NULL,
        FixedEmployee_ID nvarchar(50) NULL,
        AllowSelectApprover bit NULL,
        EscalationEnabled bit NULL,
        EscalationValue int NULL,
        EscalationUnit char(1) NULL,
        EscalationAfterHours decimal(10, 2) NULL,
        FallbackEnabled bit NULL,
        FallbackLevelCode nvarchar(50) NULL
    );

    INSERT INTO #Levels (
        ID, RuleID, LoaiDuyet, LuongDuyet, ThuTuDuyet, StepOrder,
        CapBacDuyet, ChiGuiThongBao, General, NotifyViaWeb, NotifyViaEmail, NotifyViaZalo,
        ResolveType, ScopeType,
        GroupCode, FixedEmployee_ID, AllowSelectApprover,
        EscalationEnabled, EscalationValue, EscalationUnit, EscalationAfterHours,
        FallbackEnabled, FallbackLevelCode
    )
    SELECT
        st.StepID,
        r.RuleID,
        f.RequestType,
        f.FlowCode,
        CAST(st.StepOrder AS nvarchar(50)),
        st.StepOrder,
        r.TargetLevel,
        r.IsNotifyOnly,
        st.IsRequired,
        r.NotifyViaWeb,
        r.NotifyViaEmail,
        r.NotifyViaZalo,
        r.ResolveType,
        r.ScopeType,
        r.GroupCode,
        fixedMember.Employee_ID,
        ISNULL(r.AllowSelectApprover, 0),
        ISNULL(st.EscalationEnabled, 0),
        st.EscalationValue,
        st.EscalationUnit,
        st.EscalationAfterHours,
        ISNULL(st.FallbackEnabled, 0),
        st.FallbackLevelCode
    FROM HR_ApprovalFlow f
    INNER JOIN HR_ApprovalStep st
        ON st.FlowID = f.FlowID
       AND st.IsActive = 1
       AND st.StepType IN (N'Approval', N'NotifyOnly')
    INNER JOIN HR_ApprovalRule r
        ON r.StepID = st.StepID
       AND r.IsActive = 1
    OUTER APPLY (
        SELECT TOP 1 rm.Employee_ID
        FROM HR_ApprovalRuleMember rm
        WHERE rm.RuleID = r.RuleID
          AND rm.IsActive = 1
        ORDER BY rm.Priority, rm.Employee_ID
    ) fixedMember
    WHERE f.RequestType = @RequestType
      AND f.FlowCode = @Flow
      AND f.IsActive = 1;

    SELECT
        lv.ID,
        lv.LoaiDuyet,
        lv.LuongDuyet,
        lv.ThuTuDuyet,
        lv.ThuTuDuyet AS LevelOrder,
        lv.CapBacDuyet,
        lv.ChiGuiThongBao,
        lv.General,
        lv.NotifyViaWeb,
        lv.NotifyViaEmail,
        lv.NotifyViaZalo,
        CASE @LAN
            WHEN N'EN' THEN luongCd.NameEN2
            WHEN N'KR' THEN ISNULL(luongCd.NameKR, luongCd.NameEN2)
            ELSE luongCd.NameVN
        END AS LuongDuyetLabel,
        CASE @LAN
            WHEN N'EN' THEN capCd.NameEN2
            WHEN N'KR' THEN ISNULL(capCd.NameKR, capCd.NameEN2)
            ELSE capCd.NameVN
        END AS CapBacDuyetLabel,
        preview.Employee_ID AS PreviewApproverCode,
        preview.FullName AS PreviewApproverName,
        preview.Email AS PreviewEmail,
        lv.ResolveType,
        lv.ScopeType,
        lv.GroupCode,
        lv.FixedEmployee_ID,
        fixedName.FullName AS FixedEmployeeName,
        lv.AllowSelectApprover,
        lv.EscalationEnabled,
        lv.EscalationValue,
        lv.EscalationUnit,
        lv.EscalationAfterHours,
        lv.FallbackEnabled,
        lv.FallbackLevelCode
    FROM #Levels lv
    LEFT JOIN #ApprovalLevel luongCd ON luongCd.NameEN = LTRIM(RTRIM(ISNULL(lv.LuongDuyet, N'')))
    LEFT JOIN #ApprovalLevel capCd ON capCd.NameEN = LTRIM(RTRIM(ISNULL(lv.CapBacDuyet, N'')))
    OUTER APPLY (
        SELECT
            STRING_AGG(CAST(picked.Employee_ID AS nvarchar(max)), N',')
                WITHIN GROUP (ORDER BY picked.PickPriority, picked.Employee_ID) AS Employee_ID,
            STRING_AGG(CAST(picked.FullName AS nvarchar(max)), N', ')
                WITHIN GROUP (ORDER BY picked.PickPriority, picked.Employee_ID) AS FullName,
            STRING_AGG(CAST(picked.Email AS nvarchar(max)), N', ')
                WITHIN GROUP (ORDER BY picked.PickPriority, picked.Employee_ID) AS Email
        FROM (
            SELECT DISTINCT
                pickedInner.Employee_ID,
                pickedInner.FullName,
                pickedInner.Email,
                pickedInner.PickPriority
            FROM (
            SELECT
                lm.Employee_ID,
                COALESCE(emp.FullName, dbo.udf_FullName(se.Employee_Firstname, se.Employee_LastName), lm.Employee_ID) AS FullName,
                NULLIF(LTRIM(RTRIM(ISNULL(se.Email, N''))), N'') AS Email,
                lm.Priority AS PickPriority
            FROM HR_ApprovalLevelMember lm
            LEFT JOIN #Emp emp
                ON emp.Employee_ID = lm.Employee_ID
            LEFT JOIN SmartBooks_Employee se
                ON se.Employee_ID = lm.Employee_ID
            WHERE lv.ResolveType = N'ByLevelManager'
              AND lm.LevelCode = NULLIF(LTRIM(RTRIM(lv.CapBacDuyet)), N'')
              AND lm.IsActive = 1
              AND (
                    lv.ScopeType = N'None'
                    OR (lv.ScopeType = N'SameFactory' AND ISNULL(emp.FactoryName, N'') = ISNULL(@SampleFactory, N''))
                    OR (lv.ScopeType = N'SameDepartment' AND ISNULL(emp.DepartmentName, N'') = ISNULL(@SampleDepartment, N''))
                    OR (
                        lv.ScopeType = N'FactoryGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember approverGroup
                                ON approverGroup.GroupCode = empGroup.GroupCode
                               AND approverGroup.ScopeType = N'Factory'
                               AND approverGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Factory'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = @SampleFactory
                              AND approverGroup.ScopeValue = emp.FactoryName
                        )
                    )
                    OR (
                        lv.ScopeType = N'DepartmentGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember approverGroup
                                ON approverGroup.GroupCode = empGroup.GroupCode
                               AND approverGroup.ScopeType = N'Department'
                               AND approverGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Department'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = @SampleDepartment
                              AND approverGroup.ScopeValue = emp.DepartmentName
                        )
                    )
                  )

            UNION ALL

            SELECT
                cand.Employee_ID,
                cand.FullName,
                NULLIF(LTRIM(RTRIM(ISNULL(se.Email, N''))), N'') AS Email,
                1000 AS PickPriority
            FROM #Emp cand
            LEFT JOIN SmartBooks_Employee se
                ON se.Employee_ID = cand.Employee_ID
            WHERE lv.ResolveType = N'ByLevelManager'
              AND cand.LvDuyetNorm = NULLIF(LTRIM(RTRIM(lv.CapBacDuyet)), N'')
              AND NOT EXISTS (
                    SELECT 1
                    FROM HR_ApprovalLevelMember lm
                    WHERE lm.LevelCode = NULLIF(LTRIM(RTRIM(lv.CapBacDuyet)), N'')
                      AND lm.IsActive = 1
                  )
              AND (
                    lv.ScopeType = N'None'
                    OR (lv.ScopeType = N'SameFactory' AND ISNULL(cand.FactoryName, N'') = ISNULL(@SampleFactory, N''))
                    OR (lv.ScopeType = N'SameDepartment' AND ISNULL(cand.DepartmentName, N'') = ISNULL(@SampleDepartment, N''))
                    OR (
                        lv.ScopeType = N'FactoryGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember candGroup
                                ON candGroup.GroupCode = empGroup.GroupCode
                               AND candGroup.ScopeType = N'Factory'
                               AND candGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Factory'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = @SampleFactory
                              AND candGroup.ScopeValue = cand.FactoryName
                        )
                    )
                    OR (
                        lv.ScopeType = N'DepartmentGroup'
                        AND EXISTS (
                            SELECT 1
                            FROM HR_ApprovalScopeGroupMember empGroup
                            INNER JOIN HR_ApprovalScopeGroupMember candGroup
                                ON candGroup.GroupCode = empGroup.GroupCode
                               AND candGroup.ScopeType = N'Department'
                               AND candGroup.IsActive = 1
                            WHERE empGroup.ScopeType = N'Department'
                              AND empGroup.IsActive = 1
                              AND empGroup.ScopeValue = @SampleDepartment
                              AND candGroup.ScopeValue = cand.DepartmentName
                        )
                    )
                  )

            UNION ALL

            SELECT
                rm.Employee_ID,
                COALESCE(emp.FullName, dbo.udf_FullName(se.Employee_Firstname, se.Employee_LastName), rm.Employee_ID) AS FullName,
                NULLIF(LTRIM(RTRIM(ISNULL(se.Email, N''))), N'') AS Email,
                rm.Priority AS PickPriority
            FROM HR_ApprovalRuleMember rm
            LEFT JOIN #Emp emp
                ON emp.Employee_ID = rm.Employee_ID
            LEFT JOIN SmartBooks_Employee se
                ON se.Employee_ID = rm.Employee_ID
            WHERE lv.ResolveType = N'FixedEmployee'
              AND rm.RuleID = lv.RuleID
              AND rm.IsActive = 1
              AND (@Date >= ISNULL(rm.FromDate, @Date) AND @Date <= ISNULL(rm.ToDate, @Date))
              AND (
                    lv.ScopeType = N'None'
                    OR (lv.ScopeType = N'SameFactory' AND (rm.Factory_ID IS NULL OR rm.Factory_ID = @SampleFactory))
                    OR (lv.ScopeType = N'SameDepartment' AND (rm.DepartmentCode IS NULL OR rm.DepartmentCode = @SampleDepartment))
                    OR (
                        lv.ScopeType = N'FactoryGroup'
                        AND (
                            rm.FactoryGroupCode IS NULL
                            OR EXISTS (
                                SELECT 1
                                FROM HR_ApprovalScopeGroupMember scopeMember
                                WHERE scopeMember.GroupCode = rm.FactoryGroupCode
                                  AND scopeMember.ScopeType = N'Factory'
                                  AND scopeMember.ScopeValue = @SampleFactory
                                  AND scopeMember.IsActive = 1
                            )
                        )
                    )
                    -- DepartmentGroup cho FixedEmployee: rm.FactoryGroupCode dùng như tham chiếu
                    -- nhóm chung; không đạt tới từ UI (NormalizeScopeType ép FixedEmployee -> None).
                    OR (
                        lv.ScopeType = N'DepartmentGroup'
                        AND (
                            rm.FactoryGroupCode IS NULL
                            OR EXISTS (
                                SELECT 1
                                FROM HR_ApprovalScopeGroupMember scopeMember
                                WHERE scopeMember.GroupCode = rm.FactoryGroupCode
                                  AND scopeMember.ScopeType = N'Department'
                                  AND scopeMember.ScopeValue = @SampleDepartment
                                  AND scopeMember.IsActive = 1
                            )
                        )
                    )
                  )
            ) pickedInner
            WHERE pickedInner.Employee_ID IS NOT NULL
        ) picked
    ) preview
    OUTER APPLY (
        SELECT TOP 1 COALESCE(emp.FullName, dbo.udf_FullName(se.Employee_Firstname, se.Employee_LastName), lv.FixedEmployee_ID) AS FullName
        FROM (SELECT lv.FixedEmployee_ID AS Employee_ID) x
        LEFT JOIN #Emp emp ON emp.Employee_ID = x.Employee_ID
        LEFT JOIN SmartBooks_Employee se ON se.Employee_ID = x.Employee_ID
        WHERE x.Employee_ID IS NOT NULL
    ) fixedName
    ORDER BY lv.StepOrder, lv.ThuTuDuyet;

    ;WITH ApproverAgg AS (
        SELECT
            ga.Employee_ID,
            STRING_AGG(ga.Code, N', ')
                WITHIN GROUP (ORDER BY ga.Code) AS ApproverCodes,
            STRING_AGG(ga.[Name], N', ')
                WITHIN GROUP (ORDER BY ga.Code) AS ApproverNames,
            STRING_AGG(NULLIF(LTRIM(RTRIM(ga.ChiGuiThongBao)), N''), N', ')
                WITHIN GROUP (ORDER BY ga.Code) AS NotifyOnlyCodes
        FROM HR_GetApprover ga
        WHERE ga.Employee_ID <> N'All'
          AND ga.RequestType = @RequestType
        GROUP BY ga.Employee_ID
    ),
    FilteredEmployees AS (
        SELECT
            ef.Employee_ID,
            ef.FullName,
            ef.FactoryName,
            ISNULL(ef.DepartmentName, ef.DepartmentCode1) AS DepartmentName,
            ef.JobTitle,
            aa.ApproverCodes,
            aa.ApproverNames,
            ISNULL(aa.ApproverCodes, N'') AS ApproversSummary,
            aa.NotifyOnlyCodes
        FROM #Emp ef
        LEFT JOIN ApproverAgg aa ON aa.Employee_ID = ef.Employee_ID
        WHERE ef.LvDuyetNorm = @Flow
          AND (
                @Search IS NULL
                OR ef.Employee_ID LIKE N'%' + @Search + N'%'
                OR ef.FullName LIKE N'%' + @Search + N'%'
                OR ISNULL(ef.DepartmentName, N'') LIKE N'%' + @Search + N'%'
                OR ISNULL(ef.JobTitle, N'') LIKE N'%' + @Search + N'%'
              )
    ),
    PagedEmployees AS (
        SELECT
            fe.*,
            COUNT(*) OVER() AS TotalRecords,
            ROW_NUMBER() OVER (ORDER BY fe.JobTitle, fe.Employee_ID) AS RowNumber
        FROM FilteredEmployees fe
    )
    SELECT
        Employee_ID,
        FullName,
        FactoryName,
        DepartmentName,
        JobTitle,
        ApproverCodes,
        ApproverNames,
        ApproversSummary,
        NotifyOnlyCodes,
        TotalRecords
    FROM PagedEmployees
    WHERE RowNumber > @Offset
      AND RowNumber <= @Offset + @SafePageSize
    ORDER BY RowNumber;
END

GO
