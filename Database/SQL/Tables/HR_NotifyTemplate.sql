CREATE TABLE [dbo].[HR_NotifyTemplate] (
    [TemplateKey] NVARCHAR(100) NOT NULL,
    [Channel] NVARCHAR(20) NOT NULL,
    [TitleVN] NVARCHAR(400) NULL,
    [TitleEN] NVARCHAR(400) NULL,
    [TitleKR] NVARCHAR(400) NULL,
    [BodyVN] NVARCHAR(1000) NULL,
    [BodyEN] NVARCHAR(1000) NULL,
    [BodyKR] NVARCHAR(1000) NULL,
    [IsActive] BIT NOT NULL DEFAULT ((1)),
    [UpdatedBy] NVARCHAR(50) NULL,
    [UpdatedDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_NotifyTemplate] ADD CONSTRAINT [PK_HR_NotifyTemplate] PRIMARY KEY ([TemplateKey] ASC, [Channel] ASC);
