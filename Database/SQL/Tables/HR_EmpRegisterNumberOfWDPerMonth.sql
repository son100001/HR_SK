CREATE TABLE [dbo].[HR_EmpRegisterNumberOfWDPerMonth] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Month_] INT NOT NULL,
    [Year_] INT NOT NULL,
    [NumberOfWDPerMonth] FLOAT NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_EmpRegisterNumberOfWDPerMonth] ADD CONSTRAINT [PK_HR_EmpRegisterNumberOfWDPerMonth] PRIMARY KEY ([Employee_ID] ASC, [Month_] ASC, [Year_] ASC);
