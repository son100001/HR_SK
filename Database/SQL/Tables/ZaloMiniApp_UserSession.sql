CREATE TABLE [dbo].[ZaloMiniApp_UserSession] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [mini_app_id] NVARCHAR(100) NOT NULL,
    [oa_id] NVARCHAR(64) NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [user_id_by_app] NVARCHAR(128) NULL,
    [employee_id] NVARCHAR(50) NULL,
    [user_name] NVARCHAR(100) NULL,
    [session_key_hash] VARBINARY(32) NULL,
    [session_status] NVARCHAR(30) NOT NULL DEFAULT (N'ACTIVE'),
    [expires_at_utc] DATETIME2(7) NULL,
    [raw_json] NVARCHAR(MAX) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloMiniApp_UserSession] ADD CONSTRAINT [PK_ZaloMiniApp_UserSession] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloMiniApp_UserSession_User] ON [dbo].[ZaloMiniApp_UserSession] ([company_code] ASC, [mini_app_id] ASC, [zalo_user_id] ASC, [session_status] ASC);
