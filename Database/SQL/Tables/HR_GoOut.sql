CREATE TABLE [dbo].[HR_GoOut] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TimeDate] DATETIME NOT NULL,
    [TimeOut_] DATETIME NOT NULL,
    [TimeIn] DATETIME NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NULL,
    [ShiftName] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [GioVaoThucTe] DATETIME NULL
);

ALTER TABLE [dbo].[HR_GoOut] ADD CONSTRAINT [PK_HR_GoOut_1] PRIMARY KEY ([Employee_ID] ASC, [TimeOut_] ASC);
