CREATE TABLE [dbo].[HR_SalaryTable] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(256) NULL,
    [NameEN] NVARCHAR(256) NULL,
    [NameKR] NVARCHAR(256) NULL,
    [FileTemplate] NVARCHAR(256) NOT NULL,
    [ConfigLine] INT NULL,
    [BorderLine] INT NULL,
    [SaveLine] INT NULL,
    [StartLine] INT NULL,
    [SheetName] NVARCHAR(256) NULL,
    [SalaryOption] NVARCHAR(256) NULL,
    [Remark] NVARCHAR(256) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_SalaryTable] ADD CONSTRAINT [PK_HR_SalaryTable] PRIMARY KEY ([Code] ASC);
