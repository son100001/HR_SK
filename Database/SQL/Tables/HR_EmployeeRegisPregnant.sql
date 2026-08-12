CREATE TABLE [dbo].[HR_EmployeeRegisPregnant] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [UltraPaper] NVARCHAR(50) NULL,
    [UltraDate] DATETIME NULL,
    [PregWeeks] FLOAT NULL,
    [PregDays] INT NULL,
    [Fromdate] DATETIME NOT NULL,
    [ToDate] DATETIME NOT NULL,
    [MiscarriageDate] DATETIME NULL,
    [Remark] NVARCHAR(225) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [Ngaynghitruocsinh] DATETIME NULL,
    [Ngayvaosausinh] DATETIME NULL
);

ALTER TABLE [dbo].[HR_EmployeeRegisPregnant] ADD CONSTRAINT [PK_HR_EmployeeRegisPregnant] PRIMARY KEY ([Employee_ID] ASC, [Fromdate] ASC);
