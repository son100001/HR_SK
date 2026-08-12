CREATE TABLE [dbo].[HR_Khoa] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [TableName] NVARCHAR(50) NOT NULL,
    [Block_Date] DATETIME NOT NULL,
    [Block_User] NVARCHAR(50) NOT NULL,
    [Status] BIT NULL,
    [Remark] NVARCHAR(500) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Khoa] ADD CONSTRAINT [PK_HR_Khoa] PRIMARY KEY ([TableName] ASC, [Block_User] ASC);
