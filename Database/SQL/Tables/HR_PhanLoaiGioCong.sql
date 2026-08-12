CREATE TABLE [dbo].[HR_PhanLoaiGioCong] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [ShiftName] VARCHAR(MAX) NULL,
    [fromtime] DATETIME NOT NULL,
    [totime] DATETIME NULL,
    [TrongCa] VARCHAR(50) NULL,
    [TCNgayThuong] VARCHAR(50) NULL,
    [TCChuNhat] VARCHAR(50) NULL,
    [TCNgayLe] VARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);
