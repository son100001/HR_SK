CREATE TABLE [dbo].[HR_WTDaily_Audit] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Ngay] DATETIME NOT NULL,
    [MaCong] NVARCHAR(50) NOT NULL,
    [InsertSource] VARCHAR(10) NOT NULL,
    [wt] FLOAT NOT NULL,
    [Remark] NVARCHAR(150) NULL,
    [InsertDate] DATETIME NULL DEFAULT (getdate()),
    [UserName] NVARCHAR(50) NULL DEFAULT (user_name())
);

ALTER TABLE [dbo].[HR_WTDaily_Audit] ADD CONSTRAINT [PK_HR_WTDaily_Audit_1] PRIMARY KEY ([Employee_ID] ASC, [Ngay] ASC, [MaCong] ASC, [InsertSource] ASC);
