CREATE TABLE [dbo].[HR_MaxOvertime] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [workingdate] DATETIME NOT NULL,
    [maxovertime] FLOAT NOT NULL,
    [TypeOfOT] VARCHAR(20) NOT NULL DEFAULT ((1)),
    [NgayNghiBu] DATETIME NULL,
    [ShiftName] NVARCHAR(50) NULL,
    [PrintStatus] BIT NULL DEFAULT ((0)),
    [isActualOT] BIT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [UpdateDate] DATETIME NULL,
    [UpdateUserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_MaxOvertime] ADD CONSTRAINT [PK_HR_MaxOvertime] PRIMARY KEY ([Employee_ID] ASC, [workingdate] ASC, [TypeOfOT] ASC);
