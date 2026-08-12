CREATE TABLE [dbo].[HR_EmployeeRegisMaternityLeave] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [ToDate] DATETIME NOT NULL,
    [Reason] NVARCHAR(255) NULL,
    [PlanStatus] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(225) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [isDaNopGiay] BIT NULL,
    [isBlock] BIT NULL,
    [isChoUngPhep] BIT NULL
);

ALTER TABLE [dbo].[HR_EmployeeRegisMaternityLeave] ADD CONSTRAINT [PK_HR_EmployeeRegisMaternityLeave] PRIMARY KEY ([Employee_ID] ASC, [Fromdate] ASC);
