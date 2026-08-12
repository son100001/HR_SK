CREATE TABLE [dbo].[ZaloOA_ApprovalAction] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [approval_type] NVARCHAR(50) NOT NULL,
    [approval_id] NVARCHAR(100) NOT NULL,
    [step_code] NVARCHAR(50) NULL,
    [action_type] NVARCHAR(30) NOT NULL,
    [action_token_hash] VARBINARY(32) NOT NULL,
    [action_status] NVARCHAR(30) NOT NULL DEFAULT (N'PENDING'),
    [approver_employee_id] NVARCHAR(50) NULL,
    [approver_user_name] NVARCHAR(100) NULL,
    [approver_zalo_user_id] NVARCHAR(128) NULL,
    [reject_reason] NVARCHAR(500) NULL,
    [expires_at_utc] DATETIME2(7) NOT NULL,
    [used_at_utc] DATETIME2(7) NULL,
    [raw_webhook_json] NVARCHAR(MAX) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloOA_ApprovalAction] ADD CONSTRAINT [PK_ZaloOA_ApprovalAction] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_ApprovalAction_Approval] ON [dbo].[ZaloOA_ApprovalAction] ([company_code] ASC, [approval_type] ASC, [approval_id] ASC, [action_status] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_ApprovalAction_Token] ON [dbo].[ZaloOA_ApprovalAction] ([action_token_hash] ASC);
