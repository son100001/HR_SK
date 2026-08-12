CREATE TABLE [dbo].[HR_Behavior] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [BehaviorCode] VARCHAR(50) NOT NULL,
    [DisciplineCode] VARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(MAX) NULL,
    [NameEN] NVARCHAR(MAX) NULL,
    [NameKR] NVARCHAR(MAX) NULL,
    [Remark] NVARCHAR(255) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Behavior] ADD CONSTRAINT [PK_HR_Behavior] PRIMARY KEY ([BehaviorCode] ASC, [DisciplineCode] ASC);
