CREATE TABLE [dbo].[HR_TinhCongBatchEmp] (
    [RunID] UNIQUEIDENTIFIER NOT NULL,
    [BatchID] INT NOT NULL,
    [SeqNo] INT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Status] NVARCHAR(20) NULL,
    [StartTime] DATETIME NULL,
    [EndTime] DATETIME NULL,
    [Message] NVARCHAR(MAX) NULL
);

ALTER TABLE [dbo].[HR_TinhCongBatchEmp] ADD CONSTRAINT [PK_HR_TinhCongBatchEmp] PRIMARY KEY ([RunID] ASC, [BatchID] ASC, [Employee_ID] ASC);

CREATE NONCLUSTERED INDEX [IX_HR_TinhCongBatchEmp_Batch] ON [dbo].[HR_TinhCongBatchEmp] ([RunID] ASC, [BatchID] ASC);
