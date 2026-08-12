CREATE TABLE [dbo].[HR_JobCodeCategory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [JobCode] VARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(MAX) NULL,
    [NameEN] NVARCHAR(MAX) NULL,
    [NameKR] NVARCHAR(MAX) NULL,
    [Hazard] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_JobCodeCategory] ADD CONSTRAINT [PK_HR_JobCodeCategory] PRIMARY KEY ([JobCode] ASC);
