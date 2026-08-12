CREATE TABLE [dbo].[HR_HourLeaveException] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Year_] INT NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [HourLeave] FLOAT NOT NULL,
    [Remark] NVARCHAR(256) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_HourLeaveException] ADD CONSTRAINT [PK_HR_HourLeaveException] PRIMARY KEY ([Year_] ASC, [Employee_ID] ASC);
