CREATE TABLE [dbo].[HR_DuLieuQuetVaoRa] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Ngay] DATETIME NOT NULL,
    [TimeIn] DATETIME NOT NULL,
    [TimeOut] DATETIME NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_DuLieuQuetVaoRa] ADD CONSTRAINT [PK_HR_DuLieuQuetVaoRa] PRIMARY KEY ([Employee_ID] ASC, [Ngay] ASC);
