CREATE TABLE [dbo].[SmartBooks_HolidaysPlan] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [H_date] DATETIME NOT NULL,
    [TypeOfLeave] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_HolidaysPlan] ADD CONSTRAINT [PK_SmartBooks_HolidaysPlan] PRIMARY KEY ([H_date] ASC);
