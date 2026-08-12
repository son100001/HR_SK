CREATE TABLE [dbo].[HR_RequestLeaveGoOut_History] (
    [Request_ID] INT NOT NULL,
    [Approver_ID] NVARCHAR(50) NOT NULL,
    [Approver_Name] NVARCHAR(100) NULL,
    [Approve_Date] DATETIME NULL,
    [ApproveLevel] NVARCHAR(50) NULL,
    [DepartmentCode] NVARCHAR(500) NULL,
    [Chucdanh] NVARCHAR(100) NULL
);

ALTER TABLE [dbo].[HR_RequestLeaveGoOut_History] ADD CONSTRAINT [PK_HR_RequestLeaveGoOut_History] PRIMARY KEY ([Request_ID] ASC, [Approver_ID] ASC);
