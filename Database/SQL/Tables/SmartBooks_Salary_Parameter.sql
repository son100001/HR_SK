CREATE TABLE [dbo].[SmartBooks_Salary_Parameter] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Salary_Month] INT NOT NULL,
    [Salary_Year] INT NOT NULL,
    [WorkingDay] FLOAT NULL,
    [WorkingDay1] FLOAT NULL,
    [ExchangeRate] NUMERIC(18,2) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Salary_Parameter] ADD CONSTRAINT [PK_SmartBooks_Salary_Parameter] PRIMARY KEY ([Salary_Month] ASC, [Salary_Year] ASC);
