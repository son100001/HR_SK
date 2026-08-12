CREATE TABLE [dbo].[HR_EmpRegisParameter] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [ParameterValue] NVARCHAR(50) NOT NULL,
    [Parameter] VARCHAR(50) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_EmpRegisParameter] ADD CONSTRAINT [PK_HR_EmpRegisParameter] PRIMARY KEY ([Employee_ID] ASC, [Parameter] ASC, [Fromdate] ASC);
