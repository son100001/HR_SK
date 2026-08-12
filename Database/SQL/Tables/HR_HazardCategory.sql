CREATE TABLE [dbo].[HR_HazardCategory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [HAZARD] VARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(255) NULL,
    [NameEN] NVARCHAR(255) NULL,
    [NameKR] NVARCHAR(255) NULL,
    [ToxicPercent] FLOAT NOT NULL,
    [Remark] NVARCHAR(255) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_HazardCategory] ADD CONSTRAINT [PK_HR_HazardCategory] PRIMARY KEY ([HAZARD] ASC);
