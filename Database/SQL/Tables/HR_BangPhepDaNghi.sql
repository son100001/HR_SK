CREATE TABLE [dbo].[HR_BangPhepDaNghi] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NOT NULL,
    [DateLeave] DATETIME NOT NULL,
    [HourLeave] FLOAT NULL,
    [Remark] NVARCHAR(100) NULL
);

ALTER TABLE [dbo].[HR_BangPhepDaNghi] ADD CONSTRAINT [PK_HR_BangPhepDaNghi] PRIMARY KEY ([Employee_ID] ASC, [DateLeave] ASC);
