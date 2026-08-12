CREATE TABLE [dbo].[HR_DisciplineAction] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [DisciplineCode] VARCHAR(50) NOT NULL,
    [DisciplineAction] NVARCHAR(255) NULL,
    [Assigment] NVARCHAR(50) NULL,
    [FromDate] DATETIME NULL,
    [ToDate] DATETIME NULL,
    [Remark] NVARCHAR(255) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_DisciplineAction] ADD CONSTRAINT [PK_HR_DisciplineAction] PRIMARY KEY ([DisciplineCode] ASC);
