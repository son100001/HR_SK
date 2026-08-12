CREATE TABLE [dbo].[HR_RoundShift] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [ShiftName] NVARCHAR(50) NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATETIME NULL,
    [TypeOfRegister] INT NOT NULL,
    [ExtraHours] FLOAT NULL,
    [GioTCTruoc] FLOAT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_RoundShift] ADD CONSTRAINT [PK_HR_RoundShift_1] PRIMARY KEY ([Employee_ID] ASC, [FromDate] ASC, [TypeOfRegister] ASC);
