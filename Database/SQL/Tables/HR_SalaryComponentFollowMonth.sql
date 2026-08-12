CREATE TABLE [dbo].[HR_SalaryComponentFollowMonth] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [SalaryComponent] NVARCHAR(50) NOT NULL,
    [Amount] FLOAT NOT NULL,
    [Year_] INT NOT NULL,
    [Month_] INT NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_SalaryComponentFollowMonth] ADD CONSTRAINT [PK_HR_SalaryComponentFollowMonth] PRIMARY KEY ([Employee_ID] ASC, [SalaryComponent] ASC, [Year_] ASC, [Month_] ASC);
