CREATE TABLE [dbo].[HR_TinhCongLog] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [RunID] UNIQUEIDENTIFIER NULL,
    [BatchID] INT NULL,
    [Employee_ID] NVARCHAR(50) NULL,
    [StartTime] DATETIME NULL,
    [EndTime] DATETIME NULL,
    [Status] NVARCHAR(50) NULL,
    [Message] NVARCHAR(MAX) NULL
);

ALTER TABLE [dbo].[HR_TinhCongLog] ADD CONSTRAINT [PK__HR_TinhC__3214EC2773C6C3DB] PRIMARY KEY ([ID] ASC);

CREATE NONCLUSTERED INDEX [IX_HR_TinhCongLog_RunBatchEmp] ON [dbo].[HR_TinhCongLog] ([RunID] ASC, [BatchID] ASC, [Employee_ID] ASC, [ID] ASC);
