CREATE TABLE [dbo].[HR_WebPushNotifyLog] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TypeOfNoti] NVARCHAR(50) NULL,
    [RequesterEmployee_ID] NVARCHAR(50) NULL,
    [Message] NVARCHAR(500) NULL,
    [ActionUrl] NVARCHAR(500) NULL,
    [ErrorCode] INT NOT NULL DEFAULT ((0)),
    [ErrorMessage] NVARCHAR(500) NULL,
    [SentAt] DATETIME NOT NULL DEFAULT (getdate()),
    [IsRead] BIT NOT NULL DEFAULT ((0)),
    [RequestId] NVARCHAR(50) NULL,
    [ApprovalType] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_WebPushNotifyLog] ADD CONSTRAINT [PK__HR_WebPu__3214EC07AE99D4BA] PRIMARY KEY ([Id] ASC);

CREATE NONCLUSTERED INDEX [IX_HR_WebPushNotifyLog_SentAt] ON [dbo].[HR_WebPushNotifyLog] ([SentAt] DESC);
