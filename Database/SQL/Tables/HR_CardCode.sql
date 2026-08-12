CREATE TABLE [dbo].[HR_CardCode] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Card_Code] NVARCHAR(50) NOT NULL,
    [ExpiredDate] DATETIME NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_CardCode] ADD CONSTRAINT [PK_HR_CardCode_1] PRIMARY KEY ([Employee_ID] ASC, [Card_Code] ASC, [ExpiredDate] ASC);
