
CREATE PROCEDURE [dbo].[sp_EmployeeConfirm]
    @Employee_ID NVARCHAR(50),
    @Month INT,
    @Year INT,
    @ConfirmType NVARCHAR(20),
    @ConfirmStatus BIT,
    @Remark NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Employee_ID IS NULL OR LTRIM(RTRIM(@Employee_ID)) = N''
        OR @Month IS NULL OR @Month < 1 OR @Month > 12
        OR @Year IS NULL OR @Year < 1900 OR @Year > 2100
        OR @ConfirmType NOT IN (N'Cong', N'Luong')
        OR @ConfirmStatus IS NULL
    BEGIN
        SELECT 0 AS RowsAffected, N'invalid' AS ActionType;
        RETURN;
    END

    IF DATEFROMPARTS(@Year, @Month, 1) > DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
    BEGIN
        SELECT 0 AS RowsAffected, N'future_period' AS ActionType;
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM dbo.HR_EmployeeConfirm
        WHERE Employee_ID = @Employee_ID
          AND Confirm_Month = @Month
          AND Confirm_Year = @Year
          AND ConfirmType = @ConfirmType
          AND ConfirmStatus = 1
    )
    BEGIN
        SELECT 0 AS RowsAffected, N'already_confirmed' AS ActionType;
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM dbo.HR_EmployeeConfirm
        WHERE Employee_ID = @Employee_ID
          AND Confirm_Month = @Month
          AND Confirm_Year = @Year
          AND ConfirmType = @ConfirmType
    )
    BEGIN
        UPDATE dbo.HR_EmployeeConfirm
        SET ConfirmStatus = @ConfirmStatus,
            ConfirmDate = GETDATE(),
            Remark = @Remark
        WHERE Employee_ID = @Employee_ID
          AND Confirm_Month = @Month
          AND Confirm_Year = @Year
          AND ConfirmType = @ConfirmType;

        SELECT @@ROWCOUNT AS RowsAffected, N'update' AS ActionType;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.HR_EmployeeConfirm
            (Employee_ID, Confirm_Month, Confirm_Year, ConfirmType, ConfirmStatus, ConfirmDate, Remark)
        VALUES
            (@Employee_ID, @Month, @Year, @ConfirmType, @ConfirmStatus, GETDATE(), @Remark);

        SELECT @@ROWCOUNT AS RowsAffected, N'insert' AS ActionType;
    END
END

GO
