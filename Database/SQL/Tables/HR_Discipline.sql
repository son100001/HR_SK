CREATE TABLE [dbo].[HR_Discipline] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [BehaviorCode] NVARCHAR(50) NOT NULL,
    [Reason] NVARCHAR(MAX) NULL,
    [DisciplineBegin] DATETIME NOT NULL,
    [DisciplineEnd] DATETIME NULL,
    [ViolationDate] DATETIME NOT NULL,
    [SalaryIncreaseDate] DATETIME NULL,
    [Remark] NVARCHAR(255) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Discipline] ADD CONSTRAINT [PK_HR_Discipline_1] PRIMARY KEY ([Employee_ID] ASC, [DisciplineBegin] ASC);
