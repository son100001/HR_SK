CREATE TABLE [dbo].[HR_MucLuongNhanVien] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [SalaryGroup] VARCHAR(50) NULL,
    [SalaryStep] VARCHAR(50) NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_MucLuongNhanVien] ADD CONSTRAINT [PK_HR_MucLuongNhanVien] PRIMARY KEY ([Employee_ID] ASC, [FromDate] ASC);
