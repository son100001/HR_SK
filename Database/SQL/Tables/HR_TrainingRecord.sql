CREATE TABLE [dbo].[HR_TrainingRecord] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TrainingType] NVARCHAR(50) NOT NULL,
    [Group] NVARCHAR(50) NULL,
    [TrainingSubject] NVARCHAR(50) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [TrainingHour] FLOAT NULL,
    [TrainingCost] FLOAT NULL,
    [Trainer] NVARCHAR(MAX) NULL,
    [TrainingRecordNo] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_TrainingRecord] ADD CONSTRAINT [PK_HR_TrainingRecord] PRIMARY KEY ([Employee_ID] ASC, [TrainingType] ASC, [TrainingSubject] ASC, [Fromdate] ASC);
