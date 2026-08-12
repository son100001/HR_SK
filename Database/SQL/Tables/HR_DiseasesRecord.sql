CREATE TABLE [dbo].[HR_DiseasesRecord] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [MedicalExaminationDay] DATETIME NOT NULL,
    [TypeOfDiseases] NVARCHAR(50) NOT NULL,
    [DetailOfDiseases] NVARCHAR(200) NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_DiseasesRecord] ADD CONSTRAINT [PK_HR_DiseasesRecord] PRIMARY KEY ([Employee_ID] ASC, [MedicalExaminationDay] ASC, [TypeOfDiseases] ASC, [DetailOfDiseases] ASC);
