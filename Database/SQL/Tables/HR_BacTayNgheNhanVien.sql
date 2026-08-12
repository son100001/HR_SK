CREATE TABLE [dbo].[HR_BacTayNgheNhanVien] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Nhom] VARCHAR(50) NULL,
    [Bac] VARCHAR(50) NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_BacTayNgheNhanVien] ADD CONSTRAINT [PK_HR_BacTayNgheNhanVien] PRIMARY KEY ([Employee_ID] ASC, [FromDate] ASC);
