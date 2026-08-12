CREATE TABLE [dbo].[HR_Shifts] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [ShiftName] NVARCHAR(50) NOT NULL,
    [ShiftSign] VARCHAR(50) NULL,
    [FromTime] DATETIME NOT NULL,
    [ToTime] DATETIME NOT NULL,
    [RestTimeFrom] DATETIME NULL,
    [RestTimeTo] DATETIME NULL,
    [RestTimeFrom1] DATETIME NULL,
    [RestTimeTo1] DATETIME NULL,
    [MinMinute] INT NULL,
    [AllowLateIn] INT NULL,
    [AllowEarlyOut] INT NULL,
    [ChanDau] FLOAT NULL,
    [ChanCuoi] FLOAT NULL,
    [ShiftGroup] VARCHAR(50) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Shifts] ADD CONSTRAINT [PK_HR_Shifts] PRIMARY KEY ([ShiftName] ASC);

ALTER TABLE [dbo].[HR_Shifts] ADD CONSTRAINT [IX_HR_Shifts] UNIQUE NONCLUSTERED ([ShiftName] ASC);
