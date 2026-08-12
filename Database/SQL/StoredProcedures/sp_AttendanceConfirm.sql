CREATE PROC [dbo].[sp_AttendanceConfirm]
    @Employee_ID NVARCHAR(50),
    @Attendance_Month INT,
    @Attendance_Year INT,
    @AttendanceConfirmStatus BIT,
    @Remark NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM HR_AttendanceConfirm
        WHERE Employee_ID = @Employee_ID
          AND Attendance_Month = @Attendance_Month
          AND Attendance_Year = @Attendance_Year
    )
    BEGIN
        UPDATE HR_AttendanceConfirm
        SET AttendanceConfirmStatus = @AttendanceConfirmStatus,
            Remark = @Remark
        WHERE Employee_ID = @Employee_ID
          AND Attendance_Month = @Attendance_Month
          AND Attendance_Year = @Attendance_Year;

        SELECT @@ROWCOUNT AS RowsAffected, 'update' AS ActionType;
    END
    ELSE
    BEGIN
        INSERT INTO HR_AttendanceConfirm (Employee_ID, Attendance_Month, Attendance_Year, AttendanceConfirmStatus, Remark)
        VALUES (@Employee_ID, @Attendance_Month, @Attendance_Year, @AttendanceConfirmStatus, @Remark);

        SELECT @@ROWCOUNT AS RowsAffected, 'insert' AS ActionType;
    END
END

GO
