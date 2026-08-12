CREATE TABLE [dbo].[ZaloOA_MediaAsset] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [asset_type] NVARCHAR(30) NOT NULL,
    [asset_id] NVARCHAR(200) NOT NULL,
    [file_name] NVARCHAR(255) NULL,
    [content_type] NVARCHAR(100) NULL,
    [file_size] BIGINT NULL,
    [source_url] NVARCHAR(500) NULL,
    [expires_at_utc] DATETIME2(7) NULL,
    [raw_json] NVARCHAR(MAX) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_MediaAsset] ADD CONSTRAINT [PK_ZaloOA_MediaAsset] PRIMARY KEY ([id] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_MediaAsset] ON [dbo].[ZaloOA_MediaAsset] ([company_code] ASC, [oa_id] ASC, [asset_type] ASC, [asset_id] ASC);
