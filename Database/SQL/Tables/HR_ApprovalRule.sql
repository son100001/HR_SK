CREATE TABLE [dbo].[HR_ApprovalRule] (
    [RuleID] INT IDENTITY(1,1) NOT NULL,
    [StepID] INT NOT NULL,
    [ResolveType] NVARCHAR(50) NOT NULL DEFAULT (N'ByLevelManager'),
    [TargetLevel] NVARCHAR(50) NULL,
    [ScopeType] NVARCHAR(50) NOT NULL DEFAULT (N'None'),
    [GroupCode] NVARCHAR(50) NULL,
    [IsNotifyOnly] BIT NOT NULL DEFAULT ((0)),
    [Priority] INT NOT NULL DEFAULT ((1)),
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL,
    [NotifyViaWeb] BIT NOT NULL DEFAULT ((1)),
    [NotifyViaEmail] BIT NOT NULL DEFAULT ((1)),
    [NotifyViaZalo] BIT NOT NULL DEFAULT ((1)),
    [AllowSelectApprover] BIT NOT NULL DEFAULT ((0))
);

ALTER TABLE [dbo].[HR_ApprovalRule] ADD CONSTRAINT [PK_HR_ApprovalRule] PRIMARY KEY ([RuleID] ASC);
