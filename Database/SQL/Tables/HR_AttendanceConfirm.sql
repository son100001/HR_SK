CREATE TABLE [dbo].[HR_AttendanceConfirm] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Attendance_Month] INT NOT NULL,
    [Attendance_Year] INT NOT NULL,
    [AttendanceConfirmStatus] BIT NULL,
    [Remark] NVARCHAR(MAX) NULL
);

ALTER TABLE [dbo].[HR_AttendanceConfirm] ADD CONSTRAINT [PK_HR_AttendanceConfirm] PRIMARY KEY ([Employee_ID] ASC, [Attendance_Month] ASC, [Attendance_Year] ASC);
