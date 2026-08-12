/*
  Compatibility preview helper for old callers.
  New workspace preview is resolved in sp_ApprovalConfig_GetWorkspace_Web from
  HR_ApprovalFlow/Step/Rule. This helper keeps the old signature but uses only
  generic level + scope behavior, without company-specific approver codes.
*/
CREATE   FUNCTION [dbo].[udf_ApprovalConfig_LevelPreview_Web]
(
    @LuongDuyet nvarchar(50),
    @CapBacDuyet nvarchar(50),
    @ChiGuiThongBao bit,
    @LAN nvarchar(50),
    @SampleEmployee_ID nvarchar(50) = NULL
)
RETURNS @Result TABLE
(
    ApproverCode nvarchar(50),
    ApproverName nvarchar(200),
    Email nvarchar(200)
)
AS
BEGIN
    IF @ChiGuiThongBao = 1 OR ISNULL(LTRIM(RTRIM(@CapBacDuyet)), N'') = N''
        RETURN;

    DECLARE @Date datetime = GETDATE();
    DECLARE @Factory_ID nvarchar(200);
    DECLARE @DepartmentName nvarchar(200);
    DECLARE @Flow nvarchar(50) = LTRIM(RTRIM(ISNULL(@LuongDuyet, N'')));
    DECLARE @TargetLevel nvarchar(50) = LTRIM(RTRIM(ISNULL(@CapBacDuyet, N'')));
    DECLARE @ScopeType nvarchar(50) =
        CASE
            WHEN @TargetLevel = N'4' THEN N'SameFactory'
            WHEN @TargetLevel = N'5' THEN N'SameDepartment'
            ELSE N'None'
        END;

    DECLARE @Emp TABLE (
        Employee_ID nvarchar(50) NOT NULL PRIMARY KEY,
        FullName nvarchar(200) NULL,
        FactoryName nvarchar(200) NULL,
        DepartmentName nvarchar(200) NULL,
        LvDuyetNorm nvarchar(50) NULL
    );

    INSERT INTO @Emp (Employee_ID, FullName, FactoryName, DepartmentName, LvDuyetNorm)
    SELECT
        ef.Employee_ID,
        dbo.udf_FullName(ef.Employee_Firstname, ef.Employee_LastName),
        ef.FactoryName,
        ef.DepartmentName,
        LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50))))
    FROM udf_EmployeeFilter_Web(@LAN, null, null, null, null, null, null, null, @Date) ef
    WHERE ISNULL(LTRIM(RTRIM(CAST(ef.LvDuyet AS nvarchar(50)))), N'') <> N'';

    IF @SampleEmployee_ID IS NOT NULL AND LTRIM(RTRIM(@SampleEmployee_ID)) <> N''
    BEGIN
        SELECT TOP 1
            @Factory_ID = e.FactoryName,
            @DepartmentName = e.DepartmentName
        FROM @Emp e
        WHERE e.Employee_ID = @SampleEmployee_ID
          AND e.LvDuyetNorm = @Flow;
    END

    IF @Factory_ID IS NULL
    BEGIN
        SELECT TOP 1
            @Factory_ID = e.FactoryName,
            @DepartmentName = e.DepartmentName
        FROM @Emp e
        WHERE e.LvDuyetNorm = @Flow
        ORDER BY e.Employee_ID;
    END

    IF @Factory_ID IS NULL AND @DepartmentName IS NULL
        RETURN;

    INSERT INTO @Result (ApproverCode, ApproverName, Email)
    SELECT TOP 1
        pick.Employee_ID,
        pick.FullName,
        NULLIF(LTRIM(RTRIM(ISNULL(empl.Email, N''))), N'')
    FROM @Emp pick
    LEFT JOIN SmartBooks_Employee empl
        ON empl.Employee_ID = pick.Employee_ID
    WHERE pick.LvDuyetNorm = @TargetLevel
      AND (
            @ScopeType = N'None'
            OR (@ScopeType = N'SameFactory' AND ISNULL(pick.FactoryName, N'') = ISNULL(@Factory_ID, N''))
            OR (@ScopeType = N'SameDepartment' AND ISNULL(pick.DepartmentName, N'') = ISNULL(@DepartmentName, N''))
          )
    ORDER BY pick.Employee_ID;

    RETURN;
END

GO
