CREATE TABLE [dbo].[HR_LicenseOfEmployee] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [LicenseType] NVARCHAR(100) NOT NULL,
    [LicenseID] NVARCHAR(50) NULL,
    [IssuedDate] DATETIME NOT NULL,
    [ValidFromdate] DATETIME NOT NULL,
    [ValidTodate] DATETIME NULL,
    [IssuedAt] NVARCHAR(MAX) NULL,
    [LicenseDoc] NVARCHAR(MAX) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_LicenseOfEmployee] ADD CONSTRAINT [PK_HR_LicenseOfEmployee] PRIMARY KEY ([Employee_ID] ASC, [LicenseType] ASC, [IssuedDate] ASC, [ValidFromdate] ASC);
