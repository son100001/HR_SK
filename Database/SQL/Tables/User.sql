CREATE TABLE [dbo].[User] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [FatherUser] VARCHAR(50) NULL,
    [UserName] VARCHAR(50) NOT NULL,
    [Password] VARCHAR(50) NOT NULL DEFAULT (''),
    [Employee_ID] NVARCHAR(50) NULL,
    [FullName] NVARCHAR(50) NULL,
    [GroupID] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [InsertBy] NVARCHAR(50) NULL,
    [QuyenTruyXuat] NVARCHAR(MAX) NULL,
    [Quyen] FLOAT NULL,
    [FirstTimeLogin] BIT NULL
);

ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY ([UserName] ASC, [Password] ASC);
