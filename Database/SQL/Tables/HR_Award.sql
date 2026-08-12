CREATE TABLE [dbo].[HR_Award] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [AwardType] NVARCHAR(50) NOT NULL,
    [Reason] NVARCHAR(MAX) NULL,
    [AwardDate] DATETIME NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [Amount] FLOAT NULL
);

ALTER TABLE [dbo].[HR_Award] ADD CONSTRAINT [PK_HR_Award] PRIMARY KEY ([Employee_ID] ASC, [AwardType] ASC, [AwardDate] ASC);
