CREATE TABLE [dbo].[ZaloOA_UserBindingAudit] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [event_type] NVARCHAR(50) NOT NULL,
    [ticket_id] BIGINT NULL,
    [erp_user_id] NVARCHAR(100) NULL,
    [employee_id] NVARCHAR(50) NULL,
    [user_name] NVARCHAR(100) NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [user_id_by_app] NVARCHAR(128) NULL,
    [actor_user] NVARCHAR(100) NULL,
    [bind_code_hash] VARBINARY(32) NULL,
    [event_status] NVARCHAR(50) NULL,
    [detail_message] NVARCHAR(500) NULL,
    [raw_json] NVARCHAR(MAX) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_UserBindingAudit] ADD CONSTRAINT [PK_ZaloOA_UserBindingAudit] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserBindingAudit_Target] ON [dbo].[ZaloOA_UserBindingAudit] ([company_code] ASC, [oa_id] ASC, [erp_user_id] ASC, [employee_id] ASC, [user_name] ASC, [created_at_utc] DESC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserBindingAudit_Zalo] ON [dbo].[ZaloOA_UserBindingAudit] ([company_code] ASC, [oa_id] ASC, [zalo_user_id] ASC, [created_at_utc] DESC);
