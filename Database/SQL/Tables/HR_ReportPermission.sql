CREATE TABLE [dbo].[HR_ReportPermission] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [User_] NVARCHAR(50) NOT NULL,
    [ReportCode] VARCHAR(50) NOT NULL,
    [Remark] NVARCHAR(256) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ReportPermission] ADD CONSTRAINT [PK_HR_ReportPermission] PRIMARY KEY ([User_] ASC, [ReportCode] ASC);
