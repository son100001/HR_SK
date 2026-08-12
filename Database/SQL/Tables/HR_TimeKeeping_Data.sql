CREATE TABLE [dbo].[HR_TimeKeeping_Data] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [AccessDate] DATETIME NULL,
    [AccessTime] DATETIME NOT NULL,
    [Device_ID] NVARCHAR(100) NULL,
    [CardNumber] NVARCHAR(50) NOT NULL,
    [DeviceIP] VARCHAR(50) NULL,
    [InOutStatus] VARCHAR(10) NULL,
    [InsertSource] NVARCHAR(50) NOT NULL,
    [Reason] NVARCHAR(100) NULL,
    [Remark] NVARCHAR(100) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_TimeKeeping_Data] ADD CONSTRAINT [PK_HR_TimeKeeping_Data_1] PRIMARY KEY ([Employee_ID] ASC, [AccessTime] ASC, [CardNumber] ASC, [InsertSource] ASC);
