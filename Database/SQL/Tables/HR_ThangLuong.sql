CREATE TABLE [dbo].[HR_ThangLuong] (
    [ThangluongID] INT IDENTITY(1,1) NOT NULL,
    [FactoryID] NVARCHAR(50) NOT NULL,
    [NhomLuong] NVARCHAR(50) NOT NULL,
    [BacLuong] INT NOT NULL,
    [TenNhom] NVARCHAR(250) NULL,
    [Heso] DECIMAL(18,4) NULL,
    [MucLuong] DECIMAL(18,0) NULL,
    [Beginingdate] DATETIME NULL,
    [EndDate] DATETIME NULL,
    [Approved] BIT NULL
);

ALTER TABLE [dbo].[HR_ThangLuong] ADD CONSTRAINT [PK_HR_ThangLuong] PRIMARY KEY ([ThangluongID] ASC);
