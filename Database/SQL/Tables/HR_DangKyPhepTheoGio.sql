CREATE TABLE [dbo].[HR_DangKyPhepTheoGio] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [DateLeave] DATETIME NOT NULL,
    [TypeOfLeave] VARCHAR(50) NOT NULL,
    [HourLeave] FLOAT NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_DangKyPhepTheoGio] ADD CONSTRAINT [PK_HR_DangKyPhepTheoGio] PRIMARY KEY ([Employee_ID] ASC, [DateLeave] ASC, [TypeOfLeave] ASC);
