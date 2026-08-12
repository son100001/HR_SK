CREATE TABLE [dbo].[ZaloOA_WebhookAction] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [event_name] NVARCHAR(100) NOT NULL,
    [event_group] NVARCHAR(50) NOT NULL,
    [action_name] NVARCHAR(80) NOT NULL,
    [action_status] NVARCHAR(30) NOT NULL,
    [entity_type] NVARCHAR(50) NOT NULL,
    [entity_id] NVARCHAR(128) NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [user_id_by_app] NVARCHAR(128) NULL,
    [message_id] NVARCHAR(128) NULL,
    [raw_json] NVARCHAR(MAX) NOT NULL,
    [event_time_utc] DATETIME2(7) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_WebhookAction] ADD CONSTRAINT [PK_ZaloOA_WebhookAction] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_WebhookAction_Event] ON [dbo].[ZaloOA_WebhookAction] ([company_code] ASC, [oa_id] ASC, [event_group] ASC, [created_at_utc] DESC);
