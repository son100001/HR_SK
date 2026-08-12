CREATE TABLE [dbo].[HR_Country] (
    [id] INT NOT NULL,
    [code] CHAR(10) NULL,
    [CountryName_VN] NVARCHAR(100) NULL,
    [CountryName_EN] NVARCHAR(100) NULL,
    [CountryName_KR] NVARCHAR(100) NULL
);

ALTER TABLE [dbo].[HR_Country] ADD CONSTRAINT [PK_HR_Country] PRIMARY KEY ([id] ASC);
