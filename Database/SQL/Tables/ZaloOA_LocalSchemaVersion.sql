CREATE TABLE [dbo].[ZaloOA_LocalSchemaVersion] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [script_name] NVARCHAR(200) NOT NULL,
    [script_version] NVARCHAR(50) NOT NULL,
    [applied_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [applied_by] NVARCHAR(128) NOT NULL DEFAULT (suser_sname()),
    [notes] NVARCHAR(1000) NULL
);

ALTER TABLE [dbo].[ZaloOA_LocalSchemaVersion] ADD CONSTRAINT [PK_ZaloOA_LocalSchemaVersion] PRIMARY KEY ([id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_LocalSchemaVersion_Script] ON [dbo].[ZaloOA_LocalSchemaVersion] ([script_name] ASC, [script_version] ASC);
