CREATE TABLE [dbo].[HR_DayVacationRemain] (
    [Year] INT NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [DaysRemain] FLOAT NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_DayVacationRemain] ADD CONSTRAINT [PK_HR_DayVacationRemain] PRIMARY KEY ([Year] ASC, [Employee_ID] ASC);
