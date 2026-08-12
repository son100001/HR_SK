-- Add FactoryName to sp_EmployeeConfirm_Summary_Web result set
-- Run this on all HR databases (HR_SnK_Test, HR_SnK_Dev, ...)

CREATE PROCEDURE [dbo].[sp_EmployeeConfirm_Summary_Web]
    @Month INT,
    @Year INT,
    @ConfirmType NVARCHAR(20),
    @LAN NVARCHAR(50) = N'VN',
    @fact NVARCHAR(50) = NULL,
    @dept NVARCHAR(50) = NULL,
    @sect NVARCHAR(50) = NULL,
    @team NVARCHAR(50) = NULL,
    @pos NVARCHAR(50) = NULL,
    @posc NVARCHAR(50) = NULL,
    @Emp NVARCHAR(50) = NULL,
    @StatusFilter NVARCHAR(20) = N'ALL'
AS
BEGIN
    SET NOCOUNT ON;

    IF @Month IS NULL OR @Month < 1 OR @Month > 12
        OR @Year IS NULL OR @Year < 1900 OR @Year > 2100
        OR @ConfirmType NOT IN (N'Cong', N'Luong')
    BEGIN
        SELECT TOP 0
            CAST(NULL AS NVARCHAR(50)) AS Employee_ID,
            CAST(NULL AS NVARCHAR(200)) AS FullName,
            CAST(NULL AS NVARCHAR(100)) AS FactoryName,
            CAST(NULL AS NVARCHAR(200)) AS DepartmentName,
            CAST(NULL AS NVARCHAR(200)) AS PositionName,
            CAST(NULL AS BIT) AS ConfirmStatus,
            CAST(NULL AS DATETIME) AS ConfirmDate,
            CAST(NULL AS NVARCHAR(MAX)) AS Remark,
            CAST(NULL AS NVARCHAR(20)) AS ConfirmStatusText;

        SELECT 0 AS ConfirmedCount, 0 AS ReviewCount, 0 AS TotalCount;
        RETURN;
    END

    IF @StatusFilter IS NULL OR LTRIM(RTRIM(@StatusFilter)) = N''
        SET @StatusFilter = N'ALL';

    IF @StatusFilter NOT IN (N'ALL', N'Confirmed', N'Review')
        SET @StatusFilter = N'ALL';

    DECLARE @PeriodDate DATE = DATEFROMPARTS(@Year, @Month, 1);

    SELECT
        ec.Employee_ID,
        ec.ConfirmStatus,
        ec.ConfirmDate,
        ec.Remark
    INTO #Confirm
    FROM dbo.HR_EmployeeConfirm ec WITH (NOLOCK)
    WHERE ec.Confirm_Month = @Month
      AND ec.Confirm_Year = @Year
      AND ec.ConfirmType = @ConfirmType
      AND (
            @StatusFilter = N'ALL'
            OR (@StatusFilter = N'Confirmed' AND ec.ConfirmStatus = 1)
            OR (@StatusFilter = N'Review' AND ec.ConfirmStatus = 0)
          );

    CREATE CLUSTERED INDEX IX_Confirm_Employee ON #Confirm (Employee_ID);

    SELECT
        c.Employee_ID,
        dbo.udf_FullName(ef.Employee_Firstname, ef.Employee_LastName) AS FullName,
        ef.FactoryName,
        ef.DepartmentName,
        COALESCE(NULLIF(LTRIM(RTRIM(ef.ChucDanhName)), N''), ef.PositionName) AS PositionName,
        c.ConfirmStatus,
        c.ConfirmDate,
        c.Remark,
        CASE WHEN c.ConfirmStatus = 1 THEN N'Confirmed' ELSE N'Review' END AS ConfirmStatusText
    INTO #Result
    FROM #Confirm c
    CROSS APPLY (
        SELECT TOP (1)
            ef.Employee_Firstname,
            ef.Employee_LastName,
            ef.FactoryName,
            ef.DepartmentName,
            ef.ChucDanhName,
            ef.PositionName
        FROM dbo.udf_EmployeeFilter(
            @LAN, @fact, @dept, @sect, @team, @pos, @posc, c.Employee_ID, @PeriodDate) ef
    ) ef;

    SELECT
        Employee_ID,
        FullName,
        FactoryName,
        DepartmentName,
        PositionName,
        ConfirmStatus,
        ConfirmDate,
        Remark,
        ConfirmStatusText
    FROM #Result
    ORDER BY ConfirmStatus ASC, ConfirmDate DESC, Employee_ID;

    SELECT
        ISNULL(SUM(CASE WHEN ConfirmStatus = 1 THEN 1 ELSE 0 END), 0) AS ConfirmedCount,
        ISNULL(SUM(CASE WHEN ConfirmStatus = 0 THEN 1 ELSE 0 END), 0) AS ReviewCount,
        COUNT(1) AS TotalCount
    FROM #Result;
END

GO
