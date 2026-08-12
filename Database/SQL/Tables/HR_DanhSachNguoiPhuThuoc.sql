CREATE TABLE [dbo].[HR_DanhSachNguoiPhuThuoc] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [RelatedName] NVARCHAR(100) NOT NULL,
    [Tel] NVARCHAR(50) NULL,
    [RelatedType] NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(MAX) NULL,
    [Occupation] NVARCHAR(50) NULL,
    [BirthDate] DATETIME NOT NULL,
    [Sex] NVARCHAR(50) NULL,
    [GKS_So] NVARCHAR(50) NULL,
    [GKS_QuyenSo] NVARCHAR(50) NULL,
    [GKS_TinhTP] NVARCHAR(128) NULL,
    [GKS_QuanHuyen] NVARCHAR(128) NULL,
    [GKS_PhuongXa] NVARCHAR(128) NULL,
    [MaSoThue] NVARCHAR(50) NULL,
    [QuocTich] NVARCHAR(50) NULL,
    [ID_Number] NVARCHAR(50) NULL,
    [ID_date] DATETIME NULL,
    [ID_place] NVARCHAR(128) NULL,
    [DependFromMonth] DATETIME NOT NULL,
    [DependToMonth] DATETIME NULL,
    [isDaNopGiay] BIT NULL,
    [Remark] NVARCHAR(255) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_DanhSachNguoiPhuThuoc] ADD CONSTRAINT [PK__HR_DanhS__B2537E0E25AACB10] PRIMARY KEY ([Employee_ID] ASC, [RelatedName] ASC, [BirthDate] ASC);
