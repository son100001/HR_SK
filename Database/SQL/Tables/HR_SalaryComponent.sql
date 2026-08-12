CREATE TABLE [dbo].[HR_SalaryComponent] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [SalaryComponent] NVARCHAR(50) NOT NULL,
    [Amount] FLOAT NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NULL,
    [InsertSource] VARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_SalaryComponent] ADD CONSTRAINT [PK_HR_SalaryComponent] PRIMARY KEY ([Employee_ID] ASC, [SalaryComponent] ASC, [Fromdate] ASC);
