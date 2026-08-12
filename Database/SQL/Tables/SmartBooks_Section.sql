CREATE TABLE [dbo].[SmartBooks_Section] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [SectionCode] NVARCHAR(50) NOT NULL,
    [DepartmentCode] NVARCHAR(50) NOT NULL,
    [Factory_ID] NVARCHAR(50) NOT NULL,
    [SectionName_VN] NVARCHAR(500) NULL,
    [SectionName_EN] NVARCHAR(500) NULL,
    [SectionName_KR] NVARCHAR(500) NULL,
    [Direct] BIT NULL,
    [CaMacDinh] NVARCHAR(50) NULL,
    [GioiHanTangCaMacDinh] FLOAT NULL,
    [AnnualLeaveDays] FLOAT NULL,
    [ContractFlow] NVARCHAR(50) NULL,
    [OrderBy] INT NULL,
    [JobCode] VARCHAR(50) NULL,
    [Group_] NVARCHAR(250) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Section] ADD CONSTRAINT [PK_SmartBooks_Section_1] PRIMARY KEY ([SectionCode] ASC, [DepartmentCode] ASC, [Factory_ID] ASC);
