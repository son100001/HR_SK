CREATE TABLE [dbo].[ZaloMiniApp_FormDraft] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [mini_app_id] NVARCHAR(100) NOT NULL,
    [oa_id] NVARCHAR(64) NULL,
    [zalo_user_id] NVARCHAR(128) NULL,
    [employee_id] NVARCHAR(50) NULL,
    [form_type] NVARCHAR(50) NOT NULL,
    [approval_type] NVARCHAR(50) NULL,
    [approval_id] NVARCHAR(100) NULL,
    [draft_status] NVARCHAR(30) NOT NULL DEFAULT (N'DRAFT'),
    [payload_json] NVARCHAR(MAX) NOT NULL,
    [submitted_at_utc] DATETIME2(7) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL
);

ALTER TABLE [dbo].[ZaloMiniApp_FormDraft] ADD CONSTRAINT [PK_ZaloMiniApp_FormDraft] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloMiniApp_FormDraft_User] ON [dbo].[ZaloMiniApp_FormDraft] ([company_code] ASC, [mini_app_id] ASC, [zalo_user_id] ASC, [draft_status] ASC);
