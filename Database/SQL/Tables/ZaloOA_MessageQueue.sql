CREATE TABLE [dbo].[ZaloOA_MessageQueue] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [app_id] BIGINT NULL,
    [channel] NVARCHAR(30) NOT NULL,
    [message_type] NVARCHAR(50) NOT NULL,
    [approval_type] NVARCHAR(50) NULL,
    [approval_id] NVARCHAR(100) NULL,
    [receiver_employee_id] NVARCHAR(50) NULL,
    [receiver_user_name] NVARCHAR(100) NULL,
    [receiver_zalo_user_id] NVARCHAR(128) NULL,
    [receiver_phone_normalized] NVARCHAR(30) NULL,
    [template_code] NVARCHAR(80) NULL,
    [tracking_id] NVARCHAR(100) NULL,
    [message_text] NVARCHAR(2000) NULL,
    [action_url] NVARCHAR(500) NULL,
    [payload_json] NVARCHAR(MAX) NULL,
    [queue_status] NVARCHAR(30) NOT NULL DEFAULT (N'PENDING'),
    [priority] INT NOT NULL DEFAULT ((100)),
    [attempt_count] INT NOT NULL DEFAULT ((0)),
    [max_attempt_count] INT NOT NULL DEFAULT ((5)),
    [scheduled_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [locked_until_utc] DATETIME2(7) NULL,
    [locked_by] NVARCHAR(100) NULL,
    [sent_at_utc] DATETIME2(7) NULL,
    [last_error_code] INT NULL,
    [last_error_message] NVARCHAR(1000) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL,
    [zalo_message_id] NVARCHAR(128) NULL,
    [delivery_status] NVARCHAR(30) NULL,
    [delivered_at_utc] DATETIME2(7) NULL,
    [seen_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_MessageQueue] ADD CONSTRAINT [PK_ZaloOA_MessageQueue] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_MessageQueue_Approval] ON [dbo].[ZaloOA_MessageQueue] ([company_code] ASC, [approval_type] ASC, [approval_id] ASC, [created_at_utc] DESC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_MessageQueue_Pickup] ON [dbo].[ZaloOA_MessageQueue] ([queue_status] ASC, [scheduled_at_utc] ASC, [priority] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_MessageQueue_ZaloMessage] ON [dbo].[ZaloOA_MessageQueue] ([company_code] ASC, [oa_id] ASC, [zalo_message_id] ASC);
