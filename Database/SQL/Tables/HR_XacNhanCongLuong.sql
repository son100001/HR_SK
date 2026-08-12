CREATE TABLE [dbo].[HR_XacNhanCongLuong] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Month_] INT NOT NULL,
    [Year_] INT NOT NULL,
    [XacNhanCong] NVARCHAR(50) NULL,
    [XacNhanLuong] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_XacNhanCongLuong] ADD CONSTRAINT [PK_HR_XacNhanCongLuong] PRIMARY KEY ([Employee_ID] ASC, [Month_] ASC, [Year_] ASC);
