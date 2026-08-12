CREATE TABLE [dbo].[ZaloOA_QuotaSnapshot] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [quota_type] NVARCHAR(50) NOT NULL,
    [remaining_count] INT NULL,
    [used_count] INT NULL,
    [total_count] INT NULL,
    [reset_at_utc] DATETIME2(7) NULL,
    [raw_json] NVARCHAR(MAX) NULL,
    [checked_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_QuotaSnapshot] ADD CONSTRAINT [PK_ZaloOA_QuotaSnapshot] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_QuotaSnapshot_OA_Checked] ON [dbo].[ZaloOA_QuotaSnapshot] ([company_code] ASC, [oa_id] ASC, [checked_at_utc] DESC);
