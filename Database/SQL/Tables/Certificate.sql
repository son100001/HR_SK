CREATE TABLE [dbo].[Certificate] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Certificate_Name_VN] NVARCHAR(255) NULL,
    [Certificate_Name_EN] NVARCHAR(255) NULL,
    [Certificate_Name_KR] NVARCHAR(255) NULL
);

ALTER TABLE [dbo].[Certificate] ADD CONSTRAINT [PK_Certificate] PRIMARY KEY ([ID] ASC);
