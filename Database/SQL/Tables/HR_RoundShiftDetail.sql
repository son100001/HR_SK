CREATE TABLE [dbo].[HR_RoundShiftDetail] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [RoundCode] VARCHAR(50) NOT NULL,
    [ShiftName] NVARCHAR(50) NULL,
    [RoundDays] INT NULL,
    [RoundMonths] INT NULL,
    [RoundOrder] INT NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_RoundShiftDetail] ADD CONSTRAINT [PK_HR_RoundShiftDetail_1] PRIMARY KEY ([RoundCode] ASC, [RoundOrder] ASC);
