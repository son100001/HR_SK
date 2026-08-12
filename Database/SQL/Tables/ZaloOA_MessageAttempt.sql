CREATE TABLE [dbo].[ZaloOA_MessageAttempt] (
    [id] BIGINT IDENTITY(1,1) NOT NULL,
    [message_queue_id] BIGINT NOT NULL,
    [attempt_no] INT NOT NULL,
    [endpoint] NVARCHAR(500) NULL,
    [http_status] INT NULL,
    [zalo_error_code] INT NULL,
    [zalo_message] NVARCHAR(1000) NULL,
    [zalo_message_id] NVARCHAR(100) NULL,
    [response_body] NVARCHAR(MAX) NULL,
    [duration_ms] INT NULL,
    [attempted_at_utc] DATETIME2(7) NOT NULL DEFAULT (sysutcdatetime())
);

ALTER TABLE [dbo].[ZaloOA_MessageAttempt] ADD CONSTRAINT [PK_ZaloOA_MessageAttempt] PRIMARY KEY ([id] ASC);

ALTER TABLE [dbo].[ZaloOA_MessageAttempt] ADD CONSTRAINT [FK_ZaloOA_MessageAttempt_Queue] FOREIGN KEY ([message_queue_id]) REFERENCES [dbo].[ZaloOA_MessageQueue] ([id]);

CREATE NONCLUSTERED INDEX [IX_ZaloOA_MessageAttempt_Queue] ON [dbo].[ZaloOA_MessageAttempt] ([message_queue_id] ASC, [attempt_no] ASC);
