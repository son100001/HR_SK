CREATE TABLE [dbo].[HR_DanhSachDangKyDiLam] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Ngay] DATETIME NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_DanhSachDangKyDiLam] ADD CONSTRAINT [PK_HR_DanhSachDangKyDiLam] PRIMARY KEY ([Employee_ID] ASC, [Ngay] ASC);
