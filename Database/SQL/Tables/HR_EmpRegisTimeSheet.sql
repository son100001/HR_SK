CREATE TABLE [dbo].[HR_EmpRegisTimeSheet] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TimeDate] DATETIME NOT NULL,
    [ShiftName] NVARCHAR(50) NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] VARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_EmpRegisTimeSheet] ADD CONSTRAINT [PK_HR_EmpRegisTimeSheet] PRIMARY KEY ([Employee_ID] ASC, [TimeDate] ASC);
