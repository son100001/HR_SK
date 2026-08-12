CREATE TABLE [dbo].[HR_IncreaseDecreaseInsurance] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Year_] INT NOT NULL,
    [Month_] INT NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [PhuongAn] VARCHAR(50) NOT NULL,
    [LoaiKhaiBao] VARCHAR(50) NOT NULL,
    [InsuranceSalary] FLOAT NULL,
    [InsertSource] VARCHAR(50) NULL,
    [NgayTangGiam] DATETIME NULL,
    [Remark] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_IncreaseDecreaseInsurance] ADD CONSTRAINT [PK_HR_IncreaseDecreaseInsurance] PRIMARY KEY ([Employee_ID] ASC, [Year_] ASC, [Month_] ASC);
