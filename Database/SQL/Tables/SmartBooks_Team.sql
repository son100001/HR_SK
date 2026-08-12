CREATE TABLE [dbo].[SmartBooks_Team] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [TeamCode] NVARCHAR(50) NOT NULL,
    [SectionCode] NVARCHAR(50) NOT NULL,
    [DepartmentCode] NVARCHAR(50) NOT NULL,
    [Factory_ID] NVARCHAR(50) NOT NULL,
    [Description_VN] NVARCHAR(500) NULL,
    [Description_EN] NVARCHAR(500) NULL,
    [Description_KR] NVARCHAR(500) NULL,
    [CaMacDinh] NVARCHAR(50) NULL,
    [GioiHanTangCaMacDinh] FLOAT NULL,
    [AnnualLeaveDays] FLOAT NULL,
    [ContractFlow] NVARCHAR(50) NULL,
    [OrderBy] INT NULL,
    [JobCode] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Team] ADD CONSTRAINT [PK_SmartBooks_Team] PRIMARY KEY ([TeamCode] ASC, [Factory_ID] ASC, [DepartmentCode] ASC, [SectionCode] ASC);
