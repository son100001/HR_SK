CREATE TABLE [dbo].[HR_DangKyCom] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NULL,
    [Ngay] DATETIME NULL,
    [ComTrua] NVARCHAR(50) NULL,
    [ComToi] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(500) NULL
);
