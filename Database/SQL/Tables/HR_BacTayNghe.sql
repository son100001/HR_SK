CREATE TABLE [dbo].[HR_BacTayNghe] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Nhom] VARCHAR(50) NOT NULL,
    [Bac] VARCHAR(50) NOT NULL,
    [Amount] FLOAT NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_BacTayNghe] ADD CONSTRAINT [PK_HR_BacTayNghe] PRIMARY KEY ([Nhom] ASC, [Bac] ASC, [FromDate] ASC);
