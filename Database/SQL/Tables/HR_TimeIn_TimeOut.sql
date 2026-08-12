CREATE TABLE [dbo].[HR_TimeIn_TimeOut] (
    [TimeKeeping_Data_ID] INT IDENTITY(1,1) NOT NULL,
    [OT_date] DATETIME NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TimeIn] DATETIME NULL,
    [TimeOut] DATETIME NULL,
    [LateIn] FLOAT NULL,
    [EarlyOut] FLOAT NULL,
    [WorkingTime] FLOAT NULL,
    [WorkingTime_Maternity] FLOAT NULL,
    [AbsenceHour] FLOAT NULL,
    [RealLateIn] FLOAT NULL,
    [RealEarlyOut] FLOAT NULL,
    [RealTimeIn] DATETIME NULL,
    [RealTimeOut] DATETIME NULL,
    [ShiftName] NVARCHAR(50) NULL,
    [ShiftFromTime] DATETIME NULL,
    [ShiftToTime] DATETIME NULL,
    [MealHour] FLOAT NULL,
    [MaxOverTime] FLOAT NULL,
    [isPushWorkingTime] BIT NULL,
    [TimeIn_KH] DATETIME NULL,
    [TimeOut_KH] DATETIME NULL
);

ALTER TABLE [dbo].[HR_TimeIn_TimeOut] ADD CONSTRAINT [PK_HR_TimeIn_TimeOut] PRIMARY KEY ([OT_date] ASC, [Employee_ID] ASC);
