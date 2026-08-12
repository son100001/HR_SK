CREATE TABLE [dbo].[HR_SetUpFollowDate] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Group_] NVARCHAR(50) NOT NULL,
    [Code] NVARCHAR(50) NOT NULL,
    [Value] NVARCHAR(50) NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NULL,
    [Remark] NVARCHAR(256) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_SetUpFollowDate] ADD CONSTRAINT [PK_HR_SetUpFollowDate] PRIMARY KEY ([Group_] ASC, [Code] ASC, [Fromdate] ASC);
