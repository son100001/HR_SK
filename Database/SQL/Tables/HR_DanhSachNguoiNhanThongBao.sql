CREATE TABLE [dbo].[HR_DanhSachNguoiNhanThongBao] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Approver_ID] NVARCHAR(50) NOT NULL,
    [Fullname] NVARCHAR(500) NULL,
    [Type_] NVARCHAR(50) NOT NULL,
    [Email1] NVARCHAR(100) NULL,
    [Sended] BIT NOT NULL,
    [ChiNhanThongBao] BIT NULL,
    [NotifyViaWeb] BIT NULL,
    [NotifyViaEmail] BIT NULL,
    [NotifyViaZalo] BIT NULL
);
