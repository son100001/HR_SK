CREATE TABLE [dbo].[HR_PhuongXa] (
    [MaTinhThanhPho] NVARCHAR(50) NOT NULL,
    [MaQuanHuyen] NVARCHAR(50) NOT NULL,
    [MaPhuongXa] NVARCHAR(50) NOT NULL,
    [TenPhuongXa] NVARCHAR(256) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [ID] INT IDENTITY(1,1) NOT NULL
);

ALTER TABLE [dbo].[HR_PhuongXa] ADD CONSTRAINT [PK_HR_XaPhuong] PRIMARY KEY ([MaTinhThanhPho] ASC, [MaQuanHuyen] ASC, [MaPhuongXa] ASC);
