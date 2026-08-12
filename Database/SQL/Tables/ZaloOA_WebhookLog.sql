CREATE TABLE [dbo].[ZaloOA_WebhookLog] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [app_id] NVARCHAR(64) NULL,
    [oa_id] NVARCHAR(64) NULL,
    [event_name] NVARCHAR(100) NULL,
    [raw_body] NVARCHAR(MAX) NOT NULL,
    [signature] NVARCHAR(256) NULL,
    [event_timestamp] NVARCHAR(50) NULL,
    [retry_count] NVARCHAR(20) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [idempotency_key] NVARCHAR(160) NULL,
    [signature_valid] BIT NULL,
    [processing_status] NVARCHAR(30) NOT NULL DEFAULT (N'RECEIVED'),
    [processed_at_utc] DATETIME2(7) NULL,
    [error_message] NVARCHAR(1000) NULL,
    [event_group] NVARCHAR(50) NULL,
    [sender_user_id] NVARCHAR(128) NULL,
    [recipient_id] NVARCHAR(128) NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [user_id_by_app] NVARCHAR(128) NULL,
    [message_id] NVARCHAR(128) NULL,
    [message_type] NVARCHAR(50) NULL,
    [message_text] NVARCHAR(2000) NULL,
    [media_id] NVARCHAR(200) NULL,
    [media_url] NVARCHAR(1000) NULL,
    [group_id] NVARCHAR(128) NULL,
    [request_id] NVARCHAR(128) NULL,
    [call_id] NVARCHAR(128) NULL,
    [extension_order_id] NVARCHAR(128) NULL,
    [event_time_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_WebhookLog] ADD CONSTRAINT [PK_ZaloOA_WebhookLog] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookLog_Idempotency] ON [dbo].[ZaloOA_WebhookLog] ([company_code] ASC, [idempotency_key] ASC, [processing_status] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookLog_OA_Created] ON [dbo].[ZaloOA_WebhookLog] ([oa_id] ASC, [created_at_utc] DESC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookLog_Status] ON [dbo].[ZaloOA_WebhookLog] ([processing_status] ASC, [created_at_utc] ASC);
