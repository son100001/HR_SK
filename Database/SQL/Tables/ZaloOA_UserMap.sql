CREATE TABLE [dbo].[ZaloOA_UserMap] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [company_code] NVARCHAR(50) NOT NULL,
    [oa_id] NVARCHAR(64) NOT NULL,
    [employee_id] NVARCHAR(50) NULL,
    [user_name] NVARCHAR(100) NULL,
    [zalo_user_id] NVARCHAR(128) NOT NULL,
    [user_id_by_app] NVARCHAR(128) NULL,
    [display_name] NVARCHAR(255) NULL,
    [avatar] NVARCHAR(500) NULL,
    [is_follower] BIT NULL,
    [is_active] BIT NOT NULL DEFAULT ((1)),
    [last_seen_at_utc] DATETIME2(7) NULL,
    [raw_json] NVARCHAR(MAX) NULL,
    [created_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime()),
    [updated_at_utc] DATETIME2(7) NULL,
    [erp_user_id] NVARCHAR(100) NULL,
    [phone] NVARCHAR(50) NULL,
    [phone_normalized] NVARCHAR(30) NULL,
    [binding_status] NVARCHAR(30) NOT NULL DEFAULT (N'UNMAPPED'),
    [binding_source] NVARCHAR(50) NULL,
    [consent_status] NVARCHAR(30) NOT NULL DEFAULT (N'UNKNOWN'),
    [last_interaction_at_utc] DATETIME2(7) NULL,
    [followed_at_utc] DATETIME2(7) NULL,
    [unfollowed_at_utc] DATETIME2(7) NULL,
    [last_profile_sync_at_utc] DATETIME2(7) NULL,
    [verified_at_utc] DATETIME2(7) NULL,
    [revoked_at_utc] DATETIME2(7) NULL,
    [revoked_reason] NVARCHAR(200) NULL,
    [last_bind_ticket_id] BIGINT NULL,
    [binding_version] INT NOT NULL DEFAULT ((0))
);

ALTER TABLE [dbo].[ZaloOA_UserMap] ADD CONSTRAINT [PK_ZaloOA_UserMap] PRIMARY KEY ([id] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserMap_Employee] ON [dbo].[ZaloOA_UserMap] ([company_code] ASC, [employee_id] ASC, [is_active] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserMap_Phone] ON [dbo].[ZaloOA_UserMap] ([company_code] ASC, [phone_normalized] ASC, [is_active] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserMap_TargetEmployee] ON [dbo].[ZaloOA_UserMap] ([company_code] ASC, [oa_id] ASC, [employee_id] ASC, [binding_status] ASC, [is_active] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserMap_TargetUser] ON [dbo].[ZaloOA_UserMap] ([company_code] ASC, [oa_id] ASC, [erp_user_id] ASC, [user_name] ASC, [binding_status] ASC, [is_active] ASC);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_UserMap_ZaloActive] ON [dbo].[ZaloOA_UserMap] ([company_code] ASC, [oa_id] ASC, [zalo_user_id] ASC, [is_active] ASC, [binding_status] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_ZaloOA_UserMap_Company_OA_User] ON [dbo].[ZaloOA_UserMap] ([company_code] ASC, [oa_id] ASC, [zalo_user_id] ASC);
