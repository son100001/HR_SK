CREATE PROC [dbo].[sp_PayrollConfirm]
    @Employee_ID NVARCHAR(50),
    @Salary_Month INT,
    @Salary_Year INT,
    @SalaryConfirmStatus BIT,
    @Remark NVARCHAR(MAX),
    @Key NVARCHAR(50) = 'Monthly_Salary'
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE SmartBooks_Salary
    SET SalaryConfirmStatus = @SalaryConfirmStatus,
        Remark = @Remark
    WHERE Employee_ID = @Employee_ID
      AND Salary_Month = @Salary_Month
      AND Salary_Year = @Salary_Year
      AND [Key] = @Key;

    -- Trả về số dòng bị ảnh hưởng
    SELECT @@ROWCOUNT AS RowsUpdated;
END

GO
