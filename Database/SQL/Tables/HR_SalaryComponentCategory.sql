CREATE TABLE [dbo].[HR_SalaryComponentCategory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [SalaryComponent] NVARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(250) NULL,
    [NameEN] NVARCHAR(250) NULL,
    [NameKR] NVARCHAR(250) NULL,
    [Insurance] BIT NULL,
    [MonthlyChanging] BIT NULL,
    [OrderBy] INT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_SalaryComponentCategory] ADD CONSTRAINT [PK_HR_SalaryComponentCategory] PRIMARY KEY ([SalaryComponent] ASC);
