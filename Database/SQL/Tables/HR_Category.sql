CREATE TABLE [dbo].[HR_Category] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [CategoryFather] NVARCHAR(50) NOT NULL,
    [Category] NVARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(MAX) NULL,
    [NameEN] NVARCHAR(MAX) NULL,
    [NameKR] NVARCHAR(MAX) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [Amount] FLOAT NULL
);

ALTER TABLE [dbo].[HR_Category] ADD CONSTRAINT [PK_HR_Category] PRIMARY KEY ([CategoryFather] ASC, [Category] ASC);
