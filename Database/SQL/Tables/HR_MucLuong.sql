CREATE TABLE [dbo].[HR_MucLuong] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [SalaryGroup] VARCHAR(50) NOT NULL,
    [SalaryStep] VARCHAR(50) NOT NULL,
    [Amount] FLOAT NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_MucLuong] ADD CONSTRAINT [PK_HR_MucLuong] PRIMARY KEY ([SalaryGroup] ASC, [SalaryStep] ASC, [FromDate] ASC);
