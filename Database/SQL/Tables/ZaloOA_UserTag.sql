CREATE TABLE [dbo].[ZaloOA_UserTag] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [zalo_user_id] NVARCHAR(128) NOT NULL,
    [tag_id] NVARCHAR(100) NULL,
    [tag_name] NVARCHAR(200) NOT NULL,
    [source] NVARCHAR(50) NULL,
    [is_active] BIT NOT NULL DEFAULT ((1)),
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_UserTag] ADD CONSTRAINT [PK_ZaloOA_UserTag] PRIMARY KEY ([id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_UserTag] ON [dbo].[ZaloOA_UserTag] ([company_code] ASC, [oa_id] ASC, [zalo_user_id] ASC, [tag_name] ASC);
