CREATE TABLE [dbo].[HR_TienCom] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TienCom] FLOAT NULL,
    [Ngay] DATETIME NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_TienCom] ADD CONSTRAINT [PK_HR_TienCom] PRIMARY KEY ([Employee_ID] ASC, [Ngay] ASC);
