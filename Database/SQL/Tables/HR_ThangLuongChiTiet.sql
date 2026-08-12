CREATE TABLE [dbo].[HR_ThangLuongChiTiet] (
    [MaThangLuong] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NULL,
    [NhomLuong] NVARCHAR(50) NULL,
    [BacLuong] INT NULL,
    [Fromdate] DATETIME NULL,
    [Todate] DATETIME NULL,
    [Status] INT NULL DEFAULT ((1)),
    [isprobation] BIT NULL
);

ALTER TABLE [dbo].[HR_ThangLuongChiTiet] ADD CONSTRAINT [PK_HR_ThangLuongChiTiet] PRIMARY KEY ([MaThangLuong] ASC);
