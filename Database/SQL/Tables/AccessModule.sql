CREATE TABLE [dbo].[AccessModule] (
    [Module] NVARCHAR(50) NOT NULL,
    [UserID] NVARCHAR(50) NULL,
    [Rights] INT NULL
);

ALTER TABLE [dbo].[AccessModule] ADD CONSTRAINT [PK_AccessModule] PRIMARY KEY ([Module] ASC);
