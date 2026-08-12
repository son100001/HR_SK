CREATE TABLE [dbo].[SmartBooks_Contract] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Contract_ID] NVARCHAR(50) NOT NULL,
    [ConTract_NameVN] NVARCHAR(500) NULL,
    [ConTract_NameEN] NVARCHAR(500) NULL,
    [ConTract_NameKR] NVARCHAR(500) NULL,
    [FileTemplate] NVARCHAR(500) NULL,
    [FromDate] DATETIME NULL,
    [NumberOfDay] INT NULL,
    [NumberOfMonth] FLOAT NULL,
    [NumberOfYear] FLOAT NULL,
    [isAppendix] BIT NULL,
    [isOnlyWorkingDay] BIT NULL,
    [SalaryPercent] FLOAT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Contract] ADD CONSTRAINT [PK_SmartBooks_Contract] PRIMARY KEY ([Contract_ID] ASC);
