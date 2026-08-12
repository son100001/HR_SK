CREATE TABLE [dbo].[HR_LoaiCong] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [MaCong] NVARCHAR(50) NOT NULL,
    [LoaiCong] FLOAT NULL,
    [NameVN] NVARCHAR(50) NULL,
    [NameEN] NVARCHAR(50) NULL,
    [NameKR] NVARCHAR(50) NULL,
    [isWorkingTime] BIT NULL,
    [OrderBy] INT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_LoaiCong] ADD CONSTRAINT [PK_HR_LoaiCong] PRIMARY KEY ([MaCong] ASC);
