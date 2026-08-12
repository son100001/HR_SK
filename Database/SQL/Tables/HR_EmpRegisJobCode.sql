CREATE TABLE [dbo].[HR_EmpRegisJobCode] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [JobCode] VARCHAR(50) NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [Approval] BIT NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [UpdateDate] DATETIME NULL,
    [UpdateUserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_EmpRegisJobCode] ADD CONSTRAINT [PK_HR_EmpRegisJobCode] PRIMARY KEY ([Employee_ID] ASC, [JobCode] ASC, [FromDate] ASC);
