CREATE TABLE [dbo].[HR_LuongDuyet] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [LoaiDuyet] NVARCHAR(50) NOT NULL,
    [LuongDuyet] NVARCHAR(50) NOT NULL,
    [ThuTuDuyet] NVARCHAR(50) NOT NULL,
    [CapBacDuyet] NVARCHAR(50) NULL,
    [ChiGuiThongBao] BIT NULL,
    [General] BIT NULL
);

ALTER TABLE [dbo].[HR_LuongDuyet] ADD CONSTRAINT [PK_HR_LuongDuyet] PRIMARY KEY ([LuongDuyet] ASC, [ThuTuDuyet] ASC, [LoaiDuyet] ASC);
