CREATE TABLE [dbo].[ZaloOA_ConversationMessage] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [event_name] NVARCHAR(100) NOT NULL,
    [direction] NVARCHAR(20) NOT NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [user_id_by_app] NVARCHAR(128) NULL,
    [message_id] NVARCHAR(128) NULL,
    [message_type] NVARCHAR(50) NULL,
    [message_text] NVARCHAR(2000) NULL,
    [media_id] NVARCHAR(200) NULL,
    [media_url] NVARCHAR(1000) NULL,
    [location_latitude] NVARCHAR(50) NULL,
    [location_longitude] NVARCHAR(50) NULL,
    [location_address] NVARCHAR(500) NULL,
    [raw_json] NVARCHAR(MAX) NOT NULL,
    [event_time_utc] DATETIME2(7) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_ConversationMessage] ADD CONSTRAINT [PK_ZaloOA_ConversationMessage] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_ConversationMessage_Message] ON [dbo].[ZaloOA_ConversationMessage] ([company_code] ASC, [oa_id] ASC, [message_id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_ConversationMessage_User] ON [dbo].[ZaloOA_ConversationMessage] ([company_code] ASC, [oa_id] ASC, [zalo_user_id] ASC, [created_at_utc] DESC);
