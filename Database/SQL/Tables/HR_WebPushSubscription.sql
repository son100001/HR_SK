CREATE TABLE [dbo].[HR_WebPushSubscription] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Endpoint] NVARCHAR(500) NOT NULL,
    [P256dh] NVARCHAR(255) NOT NULL,
    [Auth] NVARCHAR(255) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT (getdate()),
    [UpdatedAt] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1))
);

ALTER TABLE [dbo].[HR_WebPushSubscription] ADD CONSTRAINT [PK__HR_WebPu__3214EC07DCFE380B] PRIMARY KEY ([Id] ASC);

CREATE NONCLUSTERED INDEX [IX_HR_WebPushSubscription_Employee] ON [dbo].[HR_WebPushSubscription] ([Employee_ID] ASC);

CREATE UNIQUE NONCLUSTERED INDEX [UX_HR_WebPushSubscription_Endpoint] ON [dbo].[HR_WebPushSubscription] ([Endpoint] ASC);
