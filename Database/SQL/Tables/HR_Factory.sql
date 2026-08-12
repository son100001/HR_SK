CREATE TABLE [dbo].[HR_Factory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Factory_ID] NVARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(150) NULL,
    [NameKR] NVARCHAR(150) NULL,
    [NameEN] NVARCHAR(150) NULL,
    [AnnualLeaveDays] FLOAT NULL,
    [DiaChi] NVARCHAR(255) NULL,
    [OrderBy] INT NULL,
    [JobCode] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [CaMacDinh] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Factory] ADD CONSTRAINT [PK_HR_Factory] PRIMARY KEY ([Factory_ID] ASC);
