CREATE TABLE [dbo].[HR_DuLieuQuetKhachHang] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [workingdate] DATETIME NOT NULL,
    [TimeIn] DATETIME NULL,
    [TimeOut] DATETIME NULL,
    [Remark] NVARCHAR(255) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_DuLieuQuetKhachHang] ADD CONSTRAINT [PK_HR_DuLieuQuetKhachHang] PRIMARY KEY ([Employee_ID] ASC, [workingdate] ASC);
