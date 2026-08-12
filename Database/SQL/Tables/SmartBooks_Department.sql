CREATE TABLE [dbo].[SmartBooks_Department] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [DepartmentCode] NVARCHAR(50) NOT NULL,
    [Factory_ID] NVARCHAR(50) NOT NULL,
    [DepartmentName_VN] NVARCHAR(500) NULL,
    [DepartmentName_EN] NVARCHAR(500) NULL,
    [DepartmentName_KR] NVARCHAR(500) NULL,
    [Direct] BIT NULL,
    [CaMacDinh] NVARCHAR(50) NULL,
    [GioiHanTangCaMacDinh] FLOAT NULL,
    [AnnualLeaveDays] FLOAT NULL,
    [ContractFlow] NVARCHAR(50) NULL,
    [OrderBy] INT NULL,
    [JobCode] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Department] ADD CONSTRAINT [PK_SmartBooks_Department] PRIMARY KEY ([DepartmentCode] ASC, [Factory_ID] ASC);
