CREATE TABLE [dbo].[HR_ApprovalRuleMember] (
    [RuleMemberID] INT IDENTITY(1,1) NOT NULL,
    [RuleID] INT NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Factory_ID] NVARCHAR(100) NULL,
    [DepartmentCode] NVARCHAR(100) NULL,
    [FactoryGroupCode] NVARCHAR(50) NULL,
    [Priority] INT NOT NULL DEFAULT ((1)),
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [FromDate] DATETIME NULL,
    [ToDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ApprovalRuleMember] ADD CONSTRAINT [PK_HR_ApprovalRuleMember] PRIMARY KEY ([RuleMemberID] ASC);
