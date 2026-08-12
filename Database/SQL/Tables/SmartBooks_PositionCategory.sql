CREATE TABLE [dbo].[SmartBooks_PositionCategory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [PositionCategory_ID] NVARCHAR(50) NOT NULL,
    [PositionCategory_NameVN] NVARCHAR(500) NULL,
    [PositionCategory_NameEN] NVARCHAR(500) NULL,
    [PositionCategory_NameKR] NVARCHAR(500) NULL,
    [CaMacDinh] NVARCHAR(50) NULL,
    [AnnualLeaveDays] FLOAT NULL,
    [ContractFlow] NVARCHAR(50) NULL,
    [Nhom] VARCHAR(50) NULL,
    [SalaryGroup] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_PositionCategory] ADD CONSTRAINT [PK_SmartBooks_PositionCategory] PRIMARY KEY ([PositionCategory_ID] ASC);
