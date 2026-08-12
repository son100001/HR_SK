CREATE TABLE [dbo].[HR_DayAdjustAnnual] (
    [ID] INT NOT NULL,
    [Year] INT NOT NULL,
    [Months] INT NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [DaysAdjust] FLOAT NOT NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_DayAdjustAnnual] ADD CONSTRAINT [PK_HR_DayAdjustAnnual] PRIMARY KEY ([Employee_ID] ASC);
