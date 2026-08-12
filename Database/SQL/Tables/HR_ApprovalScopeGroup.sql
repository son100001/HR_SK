CREATE TABLE [dbo].[HR_ApprovalScopeGroup] (
    [GroupCode] NVARCHAR(50) NOT NULL,
    [GroupName] NVARCHAR(200) NULL,
    [Description] NVARCHAR(500) NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [ScopeType] NVARCHAR(50) NOT NULL DEFAULT (N'Factory')
);

ALTER TABLE [dbo].[HR_ApprovalScopeGroup] ADD CONSTRAINT [PK_HR_ApprovalScopeGroup] PRIMARY KEY ([GroupCode] ASC);
