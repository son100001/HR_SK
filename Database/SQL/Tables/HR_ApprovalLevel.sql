CREATE TABLE [dbo].[HR_ApprovalLevel] (
    [LevelCode] NVARCHAR(50) NOT NULL,
    [LevelNameVN] NVARCHAR(200) NULL,
    [LevelNameEN] NVARCHAR(200) NULL,
    [LevelNameKR] NVARCHAR(200) NULL,
    [Description] NVARCHAR(500) NULL,
    [SortOrder] INT NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [CreatedBy] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedAt] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ApprovalLevel] ADD CONSTRAINT [PK_HR_ApprovalLevel] PRIMARY KEY ([LevelCode] ASC);
