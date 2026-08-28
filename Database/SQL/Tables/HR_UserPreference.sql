CREATE TABLE [dbo].[HR_UserPreference] (
    [UserName] NVARCHAR(50) NOT NULL,
    [Employee_ID] NVARCHAR(50) NULL,
    [Language] NVARCHAR(10) NULL,
    [UpdatedDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_UserPreference] ADD CONSTRAINT [PK_HR_UserPreference] PRIMARY KEY ([UserName] ASC);

CREATE NONCLUSTERED INDEX [IX_HR_UserPreference_Employee] ON [dbo].[HR_UserPreference] ([Employee_ID] ASC) INCLUDE ([Language]);
