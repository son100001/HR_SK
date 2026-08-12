CREATE TABLE [dbo].[HR_DependentPerson] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [DependentPerson] INT NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_DependentPerson] ADD CONSTRAINT [PK_HR_DependentPerson] PRIMARY KEY ([Employee_ID] ASC, [Fromdate] ASC);
