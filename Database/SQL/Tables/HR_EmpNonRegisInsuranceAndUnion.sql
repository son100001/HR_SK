CREATE TABLE [dbo].[HR_EmpNonRegisInsuranceAndUnion] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Thang] INT NOT NULL,
    [Nam] INT NOT NULL,
    [SocialInsurance] BIT NULL,
    [HealthInsurance] BIT NULL,
    [UnemploymentInsurance] BIT NULL,
    [UnionFee] BIT NULL,
    [Comment] NVARCHAR(1024) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_EmpNonRegisInsuranceAndUnion] ADD CONSTRAINT [PK_HR_EmpNonRegisInsuranceAndUnion_1] PRIMARY KEY ([Employee_ID] ASC, [Thang] ASC, [Nam] ASC);
