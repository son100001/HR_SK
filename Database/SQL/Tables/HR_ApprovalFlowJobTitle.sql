CREATE TABLE [dbo].[HR_ApprovalFlowJobTitle] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [RequestType] NVARCHAR(50) NOT NULL,
    [FlowCode] NVARCHAR(50) NOT NULL,
    [ChucDanh] NVARCHAR(50) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ApprovalFlowJobTitle] ADD CONSTRAINT [PK_HR_ApprovalFlowJobTitle] PRIMARY KEY ([ID] ASC);

ALTER TABLE [dbo].[HR_ApprovalFlowJobTitle] ADD CONSTRAINT [UQ_HR_ApprovalFlowJobTitle_ChucDanh] UNIQUE NONCLUSTERED ([ChucDanh] ASC);
