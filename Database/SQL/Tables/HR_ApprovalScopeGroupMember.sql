CREATE TABLE [dbo].[HR_ApprovalScopeGroupMember] (
    [GroupMemberID] INT IDENTITY(1,1) NOT NULL,
    [GroupCode] NVARCHAR(50) NOT NULL,
    [ScopeType] NVARCHAR(50) NOT NULL DEFAULT (N'Factory'),
    [ScopeValue] NVARCHAR(100) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1))
);

ALTER TABLE [dbo].[HR_ApprovalScopeGroupMember] ADD CONSTRAINT [PK_HR_ApprovalScopeGroupMember] PRIMARY KEY ([GroupMemberID] ASC);
