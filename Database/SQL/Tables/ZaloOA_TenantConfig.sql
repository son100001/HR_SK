CREATE TABLE [dbo].[ZaloOA_TenantConfig] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [app_id] BIGINT NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [oa_name] NVARCHAR(255) NOT NULL DEFAULT (N''),
    [frontend_base_url] NVARCHAR(500) NOT NULL,
    [backend_base_url] NVARCHAR(500) NOT NULL,
    [callback_url] NVARCHAR(500) NOT NULL,
    [webhook_url] NVARCHAR(500) NOT NULL,
    [return_path] NVARCHAR(300) NOT NULL,
    [is_active] BIT NOT NULL DEFAULT ((1)),
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL,
    [central_registry_id] INT NULL,
    [database_key] NVARCHAR(50) NULL,
    [token_storage_mode] NVARCHAR(20) NOT NULL DEFAULT (N'CUSTOMER'),
    [tenant_status] NVARCHAR(20) NOT NULL DEFAULT (N'ACTIVE'),
    [settings_json] NVARCHAR(MAX) NULL,
    [last_sync_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_TenantConfig] ADD CONSTRAINT [PK_ZaloOA_TenantConfig] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_TenantConfig_OA] ON [dbo].[ZaloOA_TenantConfig] ([oa_id] ASC, [is_active] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_TenantConfig_Company_App_OA] ON [dbo].[ZaloOA_TenantConfig] ([company_code] ASC, [app_id] ASC, [oa_id] ASC);
