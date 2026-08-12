CREATE TABLE [dbo].[HR_WorkingTimeCompensation] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Month_] INT NOT NULL,
    [Year_] INT NOT NULL,
    [MaCong] NVARCHAR(50) NOT NULL,
    [WorkingTime] FLOAT NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_WorkingTimeCompensation] ADD CONSTRAINT [PK_HR_WorkingTimeCompensation] PRIMARY KEY ([Employee_ID] ASC, [Month_] ASC, [Year_] ASC, [MaCong] ASC);
