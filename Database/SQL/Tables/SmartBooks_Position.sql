CREATE TABLE [dbo].[SmartBooks_Position] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Position_ID] NVARCHAR(50) NOT NULL,
    [Position_NameVN] NVARCHAR(500) NULL,
    [Position_NameEN] NVARCHAR(500) NULL,
    [Position_NameKR] NVARCHAR(500) NULL,
    [CaMacDinh] NVARCHAR(50) NULL,
    [AnnualLeaveDays] FLOAT NULL,
    [ContractFlow] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Position] ADD CONSTRAINT [PK_SmartBooks_Position] PRIMARY KEY ([Position_ID] ASC);
