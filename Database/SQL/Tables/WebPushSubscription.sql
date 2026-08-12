CREATE TABLE [dbo].[WebPushSubscription] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [UserId] NVARCHAR(50) NOT NULL,
    [Endpoint] NVARCHAR(500) NOT NULL,
    [P256dh] NVARCHAR(200) NOT NULL,
    [Auth] NVARCHAR(100) NOT NULL,
    [Browser] NVARCHAR(50) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT (sysdatetime())
);

ALTER TABLE [dbo].[WebPushSubscription] ADD CONSTRAINT [PK__WebPushS__3214EC07F15081A3] PRIMARY KEY ([Id] ASC);

ALTER TABLE [dbo].[WebPushSubscription] ADD CONSTRAINT [UQ__WebPushS__32C4E31FE29774B8] UNIQUE NONCLUSTERED ([Endpoint] ASC);

CREATE NONCLUSTERED INDEX [IX_WebPushSubscription_User] ON [dbo].[WebPushSubscription] ([UserId] ASC);
