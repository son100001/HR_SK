CREATE TABLE [dbo].[AccessForm] (
    [Module] NVARCHAR(50) NOT NULL,
    [RouterLink] NVARCHAR(400) NOT NULL,
    [UserID] VARCHAR(50) NOT NULL,
    [Show] INT NULL
);

ALTER TABLE [dbo].[AccessForm] ADD CONSTRAINT [PK_AccessForm] PRIMARY KEY ([Module] ASC, [RouterLink] ASC, [UserID] ASC);
