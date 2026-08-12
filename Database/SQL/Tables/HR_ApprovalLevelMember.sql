CREATE TABLE [dbo].[HR_ApprovalLevelMember] (
    [LevelMemberID] INT IDENTITY(1,1) NOT NULL,
    [LevelCode] NVARCHAR(50) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Priority] INT NOT NULL DEFAULT ((1)),
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ApprovalLevelMember] ADD CONSTRAINT [PK_HR_ApprovalLevelMember] PRIMARY KEY ([LevelMemberID] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_HR_ApprovalLevelMember_Level_Employee] ON [dbo].[HR_ApprovalLevelMember] ([LevelCode] ASC, [Employee_ID] ASC);
