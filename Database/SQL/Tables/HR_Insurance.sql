CREATE TABLE [dbo].[HR_Insurance] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] VARCHAR(50) NOT NULL,
    [BookCode] NVARCHAR(50) NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [StartedDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_Insurance] ADD CONSTRAINT [PK_HR_Insurance] PRIMARY KEY ([BookCode] ASC);
