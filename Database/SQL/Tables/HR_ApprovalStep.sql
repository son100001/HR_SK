CREATE TABLE [dbo].[HR_ApprovalStep] (
    [StepID] INT IDENTITY(1,1) NOT NULL,
    [FlowID] INT NOT NULL,
    [StepOrder] INT NOT NULL,
    [StepName] NVARCHAR(200) NULL,
    [StepType] NVARCHAR(50) NOT NULL DEFAULT (N'Approval'),
    [IsRequired] BIT NOT NULL DEFAULT ((1)),
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL,
    [EscalationEnabled] BIT NOT NULL DEFAULT ((0)),
    [EscalationValue] INT NULL,
    [EscalationUnit] CHAR(1) NULL,
    [EscalationAfterHours] DECIMAL(10,2) NULL,
    [FallbackEnabled] BIT NOT NULL DEFAULT ((0)),
    [FallbackLevelCode] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_ApprovalStep] ADD CONSTRAINT [PK_HR_ApprovalStep] PRIMARY KEY ([StepID] ASC);

ALTER TABLE [dbo].[HR_ApprovalStep] ADD CONSTRAINT [UQ_HR_ApprovalStep_Flow_Order] UNIQUE NONCLUSTERED ([FlowID] ASC, [StepOrder] ASC);
