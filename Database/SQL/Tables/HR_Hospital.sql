CREATE TABLE [dbo].[HR_Hospital] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [MaBenhVien] NVARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(256) NULL,
    [NameEN] NVARCHAR(256) NULL,
    [NameKR] NVARCHAR(256) NULL,
    [Address] NVARCHAR(256) NULL,
    [Remark] NVARCHAR(256) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Hospital] ADD CONSTRAINT [PK_HR_Hospital] PRIMARY KEY ([MaBenhVien] ASC);
