CREATE TABLE [dbo].[HR_MaxOvertimeInPeriod] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NOT NULL,
    [maxovertime] FLOAT NOT NULL,
    [Remark] NVARCHAR(256) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_MaxOvertimeInPeriod] ADD CONSTRAINT [PK_HR_MaxOvertimeInPeriod] PRIMARY KEY ([Employee_ID] ASC, [Fromdate] ASC);
