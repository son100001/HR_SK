CREATE TABLE [dbo].[Permission] (
    [UserName] VARCHAR(50) NOT NULL,
    [FormID] VARCHAR(50) NOT NULL,
    [Quyen] VARCHAR(50) NOT NULL,
    [DepartmentCode] NVARCHAR(50) NULL,
    [SectionCode] NVARCHAR(50) NULL,
    [TeamCode] NVARCHAR(50) NULL,
    [TabList] NVARCHAR(MAX) NULL,
    [InsertBy] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[Permission] ADD CONSTRAINT [PK_Permission] PRIMARY KEY ([UserName] ASC, [FormID] ASC);
