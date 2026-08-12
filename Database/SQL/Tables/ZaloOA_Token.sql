CREATE TABLE [dbo].[ZaloOA_Token] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [app_id] BIGINT NOT NULL,
    [access_token] NVARCHAR(2048) NOT NULL,
    [refresh_token] NVARCHAR(2048) NOT NULL,
    [expires_at_utc] DATETIME2(7) NOT NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [token_status] NVARCHAR(30) NOT NULL DEFAULT (N'ACTIVE'),
    [token_version] INT NOT NULL DEFAULT ((1)),
    [last_refresh_at_utc] DATETIME2(7) NULL,
    [last_refresh_error] NVARCHAR(1000) NULL,
    [refresh_lock_until_utc] DATETIME2(7) NULL,
    [refresh_lock_owner] NVARCHAR(100) NULL,
    [is_active] BIT NOT NULL DEFAULT ((1))
);

ALTER TABLE [dbo].[ZaloOA_Token] ADD CONSTRAINT [PK_ZaloOA_Token] PRIMARY KEY ([id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_Token_Company_App_OA] ON [dbo].[ZaloOA_Token] ([company_code] ASC, [app_id] ASC, [oa_id] ASC);
