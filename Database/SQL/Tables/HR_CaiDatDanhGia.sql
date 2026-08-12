CREATE TABLE [dbo].[HR_CaiDatDanhGia] (
    [DanhGiaID] INT IDENTITY(1,1) NOT NULL,
    [Position_ID] NVARCHAR(50) NOT NULL,
    [DanhGiaToChuc] NVARCHAR(50) NOT NULL,
    [DanhGiaCaNhan] NVARCHAR(50) NOT NULL,
    [Sotien] DECIMAL(18,0) NULL,
    [Beginingdate] DATETIME NULL,
    [EndDate] DATETIME NULL,
    [Approved] BIT NULL
);

ALTER TABLE [dbo].[HR_CaiDatDanhGia] ADD CONSTRAINT [PK_HR_CaiDatDanhGia] PRIMARY KEY ([DanhGiaID] ASC);
