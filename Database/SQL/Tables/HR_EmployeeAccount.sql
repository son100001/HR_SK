CREATE TABLE [dbo].[HR_EmployeeAccount] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [AccountingGroup] NVARCHAR(10) NULL,
    [AccountingDetail] NVARCHAR(10) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_EmployeeAccount] ADD CONSTRAINT [PK_HR_EmployeeAccount] PRIMARY KEY ([Employee_ID] ASC, [AccountingDetail] ASC, [Fromdate] ASC);
