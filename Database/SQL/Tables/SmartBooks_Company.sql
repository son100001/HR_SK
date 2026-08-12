CREATE TABLE [dbo].[SmartBooks_Company] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [CompanyID] VARCHAR(50) NOT NULL,
    [company_name] NVARCHAR(255) NOT NULL,
    [company_name_VN] NVARCHAR(255) NULL,
    [Address_EN] NVARCHAR(255) NULL,
    [Address_VN] NVARCHAR(255) NULL,
    [phone] NVARCHAR(50) NULL,
    [fax] NVARCHAR(50) NULL,
    [Picture] IMAGE NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_Company] ADD CONSTRAINT [PK_T_Company] PRIMARY KEY ([CompanyID] ASC);
