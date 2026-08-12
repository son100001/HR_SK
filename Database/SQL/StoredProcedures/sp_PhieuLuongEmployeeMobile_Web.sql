
CREATE PROCEDURE [dbo].[sp_PhieuLuongEmployeeMobile_Web]
    @Month INT,
    @Year INT,
    @LAN NVARCHAR(50) = N'VN',
    @UserName NVARCHAR(50),
    @Emp NVARCHAR(50),
    @SalaryKey NVARCHAR(50) = N'MonthlySalary'
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PayDate DATETIME;

    SELECT TOP (1)
        @PayDate = s.PayDate
    FROM dbo.SmartBooks_Salary s
    WHERE s.[key] = @SalaryKey
        AND s.Salary_Month = @Month
        AND s.Salary_Year = @Year
        AND s.Employee_ID = @Emp;

    SELECT
        s.Employee_ID,
        [dbo].[udf_FullName](empl.Employee_Firstname, empl.Employee_LastName) AS FullName,
        empl.DepartmentName,
        empl.PositionName,
        s.Salary_Month,
        s.Salary_Year,
        CASE WHEN @LAN = N'EN' THEN N'NET PAY THIS PERIOD' ELSE N'THỰC LĨNH KỲ NÀY' END AS NetPayLabel,
        CAST(ISNULL(s.s42, 0) AS DECIMAL(18, 0)) AS ThucLanh,
        N'VND' AS CurrencyLabel,
        ec.ConfirmStatus AS SalaryConfirmStatus,
        ec.Remark
    FROM dbo.SmartBooks_Salary s
    LEFT JOIN dbo.HR_EmployeeConfirm ec
        ON ec.Employee_ID = s.Employee_ID
        AND ec.Confirm_Month = s.Salary_Month
        AND ec.Confirm_Year = s.Salary_Year
        AND ec.ConfirmType = N'Luong'
    LEFT JOIN [dbo].[udf_EmployeeFilter](@LAN, NULL, NULL, NULL, NULL, NULL, NULL, @Emp, ISNULL(@PayDate, GETDATE())) empl
        ON empl.Employee_ID = s.Employee_ID
    WHERE s.[key] = @SalaryKey
        AND s.Salary_Month = @Month
        AND s.Salary_Year = @Year
        AND s.Employee_ID = @Emp;
END

GO
