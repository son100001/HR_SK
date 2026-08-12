CREATE TABLE [dbo].[SmartBooks_Salary_Name] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Salary] NVARCHAR(100) NOT NULL,
    [Name_VN] NVARCHAR(100) NULL,
    [Name_EN] NVARCHAR(100) NULL,
    [Name_KR] NVARCHAR(100) NULL,
    [PIT] BIT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[SmartBooks_Salary_Name] ADD CONSTRAINT [PK_SmartBooks_Salary_Name] PRIMARY KEY ([Salary] ASC);
