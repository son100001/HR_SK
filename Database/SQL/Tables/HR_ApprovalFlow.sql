CREATE TABLE [dbo].[HR_ApprovalFlow] (
    [FlowID] INT IDENTITY(1,1) NOT NULL,
    [RequestType] NVARCHAR(50) NOT NULL,
    [FlowCode] NVARCHAR(50) NOT NULL,
    [FlowName] NVARCHAR(200) NULL,
    [Description] NVARCHAR(500) NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ApprovalFlow] ADD CONSTRAINT [PK_HR_ApprovalFlow] PRIMARY KEY ([FlowID] ASC);

ALTER TABLE [dbo].[HR_ApprovalFlow] ADD CONSTRAINT [UQ_HR_ApprovalFlow_Request_Flow] UNIQUE NONCLUSTERED ([RequestType] ASC, [FlowCode] ASC);
