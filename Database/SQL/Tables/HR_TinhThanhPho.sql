CREATE TABLE [dbo].[HR_TinhThanhPho] (
    [MaTinhThanhPho] NVARCHAR(50) NOT NULL,
    [TenTinhThanhPho] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [ID] INT IDENTITY(1,1) NOT NULL
);

ALTER TABLE [dbo].[HR_TinhThanhPho] ADD CONSTRAINT [PK_HR_TinhThanhPho] PRIMARY KEY ([MaTinhThanhPho] ASC);
