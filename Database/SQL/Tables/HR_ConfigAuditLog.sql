CREATE TABLE [dbo].[HR_ConfigAuditLog] (
    [ID] BIGINT IDENTITY(1,1) NOT NULL,
    [UserName] NVARCHAR(50) NULL,
    [ChangedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [ConfigGroup] NVARCHAR(50) NOT NULL,
    [ConfigKey] NVARCHAR(200) NULL,
    [BeforeJson] NVARCHAR(MAX) NULL,
    [AfterJson] NVARCHAR(MAX) NULL
);

ALTER TABLE [dbo].[HR_ConfigAuditLog] ADD CONSTRAINT [PK_HR_ConfigAuditLog] PRIMARY KEY ([ID] ASC);
