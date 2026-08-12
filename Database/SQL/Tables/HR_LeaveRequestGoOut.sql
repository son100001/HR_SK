CREATE TABLE [dbo].[HR_LeaveRequestGoOut] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TimeDate] DATETIME NOT NULL,
    [TimeOut_] DATETIME NOT NULL,
    [TimeIn] DATETIME NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NULL,
    [ShiftName] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(500) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [ApproverName] NVARCHAR(50) NOT NULL,
    [ApproveDate] DATETIME NULL,
    [ApproveLevel] NVARCHAR(50) NULL,
    [ThuTuDuyet] INT NULL,
    [TrangThai] NVARCHAR(50) NULL,
    [GioVaoThucTe] DATETIME NULL,
    [TrangThaiVao] NVARCHAR(50) NULL,
    [CurrentStepSince] DATETIME NULL
);

ALTER TABLE [dbo].[HR_LeaveRequestGoOut] ADD CONSTRAINT [PK_HR_LeaveRequestGoOut] PRIMARY KEY ([Employee_ID] ASC, [TimeOut_] ASC);

CREATE NONCLUSTERED INDEX [HR_LeaveRequestGoOut] ON [dbo].[HR_LeaveRequestGoOut] ([InsertDate] ASC) INCLUDE ([TrangThai]);
