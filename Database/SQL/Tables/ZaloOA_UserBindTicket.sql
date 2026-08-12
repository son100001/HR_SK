CREATE TABLE [dbo].[ZaloOA_UserBindTicket] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [bind_code] NVARCHAR(20) NOT NULL,
    [erp_user_id] NVARCHAR(100) NULL,
    [employee_id] NVARCHAR(50) NULL,
    [user_name] NVARCHAR(100) NULL,
    [phone] NVARCHAR(50) NULL,
    [phone_normalized] NVARCHAR(30) NULL,
    [ticket_status] NVARCHAR(30) NOT NULL DEFAULT (N'ACTIVE'),
    [expires_at_utc] DATETIME2(7) NOT NULL,
    [created_by] NVARCHAR(100) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [consumed_at_utc] DATETIME2(7) NULL,
    [consumed_zalo_user_id] NVARCHAR(128) NULL,
    [updated_at_utc] DATETIME2(7) NULL,
    [bind_code_hash] VARBINARY(32) NULL,
    [consumed_user_id_by_app] NVARCHAR(128) NULL,
    [consumed_display_name] NVARCHAR(255) NULL,
    [consumed_raw_json] NVARCHAR(MAX) NULL,
    [failed_attempt_count] INT NOT NULL DEFAULT ((0)),
    [last_failed_at_utc] DATETIME2(7) NULL,
    [last_failed_zalo_user_id] NVARCHAR(128) NULL
);

ALTER TABLE [dbo].[ZaloOA_UserBindTicket] ADD CONSTRAINT [PK_ZaloOA_UserBindTicket] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserBindTicket_Code] ON [dbo].[ZaloOA_UserBindTicket] ([company_code] ASC, [oa_id] ASC, [bind_code] ASC, [ticket_status] ASC, [expires_at_utc] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserBindTicket_Hash] ON [dbo].[ZaloOA_UserBindTicket] ([company_code] ASC, [oa_id] ASC, [bind_code_hash] ASC, [ticket_status] ASC, [expires_at_utc] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserBindTicket_StatusExpiry] ON [dbo].[ZaloOA_UserBindTicket] ([company_code] ASC, [oa_id] ASC, [ticket_status] ASC, [expires_at_utc] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserBindTicket_User] ON [dbo].[ZaloOA_UserBindTicket] ([company_code] ASC, [erp_user_id] ASC, [employee_id] ASC, [user_name] ASC, [ticket_status] ASC);
