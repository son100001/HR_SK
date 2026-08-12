CREATE TABLE [dbo].[HR_MayChamCong] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Code] VARCHAR(50) NOT NULL,
    [Name_] NVARCHAR(50) NULL,
    [Address] NVARCHAR(256) NULL,
    [Query] NVARCHAR(MAX) NULL,
    [isACCESS] BIT NULL,
    [isSQL] BIT NULL,
    [ListOfUser] NVARCHAR(256) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [PassWord_] NVARCHAR(50) NULL,
    [EmployeeIDIsCardNumber] BIT NULL,
    [FormatDate] NVARCHAR(50) NULL,
    [CardCodeName] NVARCHAR(50) NULL,
    [CardCodeType] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_MayChamCong] ADD CONSTRAINT [PK_HR_MayChamCong] PRIMARY KEY ([Code] ASC);
