CREATE TABLE [dbo].[ZaloOA_ApprovalNotifyLog] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [approval_type] NVARCHAR(50) NOT NULL,
    [approval_id] NVARCHAR(100) NOT NULL,
    [receiver_user_id] NVARCHAR(128) NOT NULL,
    [receiver_role] NVARCHAR(30) NOT NULL,
    [message_text] NVARCHAR(2000) NOT NULL,
    [action_url] NVARCHAR(500) NULL,
    [zalo_error_code] INT NULL,
    [zalo_message] NVARCHAR(500) NULL,
    [zalo_response] NVARCHAR(MAX) NULL,
    [sent_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [zalo_message_id] NVARCHAR(128) NULL,
    [delivery_status] NVARCHAR(30) NULL,
    [delivered_at_utc] DATETIME2(7) NULL,
    [seen_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_ApprovalNotifyLog] ADD CONSTRAINT [PK_ZaloOA_ApprovalNotifyLog] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_ApprovalNotifyLog_Approval] ON [dbo].[ZaloOA_ApprovalNotifyLog] ([company_code] ASC, [approval_type] ASC, [approval_id] ASC, [sent_at_utc] DESC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_ApprovalNotifyLog_Message] ON [dbo].[ZaloOA_ApprovalNotifyLog] ([company_code] ASC, [oa_id] ASC, [zalo_message_id] ASC);
