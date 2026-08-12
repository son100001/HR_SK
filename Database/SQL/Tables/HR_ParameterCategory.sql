CREATE TABLE [dbo].[HR_ParameterCategory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Parameter] VARCHAR(50) NOT NULL,
    [NameVN] NVARCHAR(100) NULL,
    [NameEN] NVARCHAR(100) NULL,
    [NameKR] NVARCHAR(100) NULL,
    [TypeOfParameter] VARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_ParameterCategory] ADD CONSTRAINT [PK_HR_ParameterCategory_1] PRIMARY KEY ([Parameter] ASC);
