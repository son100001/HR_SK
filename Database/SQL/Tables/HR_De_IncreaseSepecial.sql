CREATE TABLE [dbo].[HR_De_IncreaseSepecial] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Year_] INT NOT NULL,
    [Month_] INT NOT NULL,
    [isDecrease] BIT NULL,
    [TypeOfDe_Increase] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_De_IncreaseSepecial] ADD CONSTRAINT [PK_HR_De_IncreaseSepecial] PRIMARY KEY ([Employee_ID] ASC, [Year_] ASC, [Month_] ASC);
