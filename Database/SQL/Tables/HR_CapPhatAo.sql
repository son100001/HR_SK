CREATE TABLE [dbo].[HR_CapPhatAo] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Size] NCHAR(10) NULL,
    [Color] NCHAR(20) NULL,
    [Number] INT NOT NULL,
    [DateIssued] DATETIME NOT NULL,
    [ReturnDate] DATETIME NULL,
    [Remark] NCHAR(225) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_CapPhatAo] ADD CONSTRAINT [PK_HR_CapPhatAo] PRIMARY KEY ([Employee_ID] ASC, [DateIssued] ASC);
