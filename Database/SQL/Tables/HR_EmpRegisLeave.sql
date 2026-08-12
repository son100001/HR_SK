CREATE TABLE [dbo].[HR_EmpRegisLeave] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [DateLeave] DATETIME NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NOT NULL,
    [HourLeave] FLOAT NULL,
    [InsertSource] VARCHAR(50) NULL,
    [KhungGio] INT NULL,
    [Remark] NVARCHAR(512) NULL,
    [Approval] BIT NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [UpdateDate] DATETIME NULL,
    [UpdateUserName] NVARCHAR(50) NULL,
    [isProbation] BIT NULL,
    [isNewPosition] BIT NULL
);

ALTER TABLE [dbo].[HR_EmpRegisLeave] ADD CONSTRAINT [PK_HR_EmpRegisLeave_1] PRIMARY KEY ([Employee_ID] ASC, [DateLeave] ASC);
