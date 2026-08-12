CREATE TABLE [dbo].[HR_TimeKeeping_Data_Delete] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NULL,
    [AccessDate] DATETIME NULL,
    [AccessTime] DATETIME NOT NULL,
    [Device_ID] INT NULL,
    [CardNumber] NVARCHAR(50) NOT NULL,
    [InsertSource] NVARCHAR(50) NULL,
    [Remark] NVARCHAR(100) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_TimeKeeping_Data_Delete] ADD CONSTRAINT [PK_HR_TimeKeeping_Data_Delete] PRIMARY KEY ([AccessTime] ASC, [CardNumber] ASC);
