CREATE TABLE [dbo].[SmartBooks_TimeKeeping_Date] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [WorkingDay] DATETIME NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [WokingTime] FLOAT NULL,
    [MaCong] NVARCHAR(50) NOT NULL,
    [SlotCode] VARCHAR(50) NULL,
    [TimeIn] DATETIME NULL,
    [TimeOut_] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[SmartBooks_TimeKeeping_Date] ADD CONSTRAINT [PK_SmartBooks_TimeKeeping_Date] PRIMARY KEY ([ID] ASC);
