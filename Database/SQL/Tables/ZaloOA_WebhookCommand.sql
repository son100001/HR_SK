CREATE TABLE [dbo].[ZaloOA_WebhookCommand] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [message_id] NVARCHAR(128) NULL,
    [command_text] NVARCHAR(2000) NOT NULL,
    [command_name] NVARCHAR(50) NULL,
    [approval_type] NVARCHAR(50) NULL,
    [approval_id] NVARCHAR(100) NULL,
    [reject_reason] NVARCHAR(500) NULL,
    [command_status] NVARCHAR(30) NOT NULL DEFAULT (N'RECEIVED'),
    [raw_json] NVARCHAR(MAX) NOT NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [processed_at_utc] DATETIME2(7) NULL,
    [error_message] NVARCHAR(1000) NULL,
    [bind_code] NVARCHAR(20) NULL,
    [bind_code_hash] VARBINARY(32) NULL
);

ALTER TABLE [dbo].[ZaloOA_WebhookCommand] ADD CONSTRAINT [PK_ZaloOA_WebhookCommand] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookCommand_Approval] ON [dbo].[ZaloOA_WebhookCommand] ([company_code] ASC, [approval_type] ASC, [approval_id] ASC, [created_at_utc] DESC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookCommand_Bind] ON [dbo].[ZaloOA_WebhookCommand] ([company_code] ASC, [oa_id] ASC, [bind_code] ASC, [created_at_utc] DESC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookCommand_BindHash] ON [dbo].[ZaloOA_WebhookCommand] ([company_code] ASC, [oa_id] ASC, [bind_code_hash] ASC, [created_at_utc] DESC);
