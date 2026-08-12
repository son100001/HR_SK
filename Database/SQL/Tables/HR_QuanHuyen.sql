CREATE TABLE [dbo].[HR_QuanHuyen] (
    [MaTinhThanhPho] NVARCHAR(50) NOT NULL,
    [MaQuanHuyen] NVARCHAR(50) NOT NULL,
    [TenQuanHuyen] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [ID] INT IDENTITY(1,1) NOT NULL
);

ALTER TABLE [dbo].[HR_QuanHuyen] ADD CONSTRAINT [PK_Table_1] PRIMARY KEY ([MaTinhThanhPho] ASC, [MaQuanHuyen] ASC);
