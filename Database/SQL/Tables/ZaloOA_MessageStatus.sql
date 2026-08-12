CREATE TABLE [dbo].[ZaloOA_MessageStatus] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [event_name] NVARCHAR(100) NOT NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [message_id] NVARCHAR(128) NULL,
    [message_status] NVARCHAR(30) NULL,
    [raw_json] NVARCHAR(MAX) NOT NULL,
    [event_time_utc] DATETIME2(7) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_MessageStatus] ADD CONSTRAINT [PK_ZaloOA_MessageStatus] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_MessageStatus_Message] ON [dbo].[ZaloOA_MessageStatus] ([company_code] ASC, [oa_id] ASC, [message_id] ASC, [created_at_utc] DESC);
