CREATE TABLE [dbo].[ZaloOA_UserConsent] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [zalo_user_id] NVARCHAR(128) NOT NULL,
    [employee_id] NVARCHAR(50) NULL,
    [consent_type] NVARCHAR(50) NOT NULL,
    [consent_status] NVARCHAR(30) NOT NULL,
    [source] NVARCHAR(50) NULL,
    [consented_at_utc] DATETIME2(7) NULL,
    [revoked_at_utc] DATETIME2(7) NULL,
    [raw_json] NVARCHAR(MAX) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_UserConsent] ADD CONSTRAINT [PK_ZaloOA_UserConsent] PRIMARY KEY ([id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_UserConsent] ON [dbo].[ZaloOA_UserConsent] ([company_code] ASC, [oa_id] ASC, [zalo_user_id] ASC, [consent_type] ASC);
