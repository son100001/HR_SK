CREATE TABLE [dbo].[HR_WorkingDaySpecial] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [WorkingDate] DATETIME NOT NULL,
    [WorkingDayType] VARCHAR(50) NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_WorkingDaySpecial] ADD CONSTRAINT [PK_HR_WorkingDaySpecial] PRIMARY KEY ([Employee_ID] ASC, [WorkingDate] ASC);
