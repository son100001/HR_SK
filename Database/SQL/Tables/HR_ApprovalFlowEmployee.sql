CREATE TABLE [dbo].[HR_ApprovalFlowEmployee] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [RequestType] NVARCHAR(50) NOT NULL,
    [FlowCode] NVARCHAR(50) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [FromDate] DATETIME NULL,
    [ToDate] DATETIME NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ApprovalFlowEmployee] ADD CONSTRAINT [PK_HR_ApprovalFlowEmployee] PRIMARY KEY ([ID] ASC);

ALTER TABLE [dbo].[HR_ApprovalFlowEmployee] ADD CONSTRAINT [UQ_HR_ApprovalFlowEmployee_Request_Employee] UNIQUE NONCLUSTERED ([RequestType] ASC, [Employee_ID] ASC);
