CREATE TABLE [dbo].[HR_BankAccountOfEmployee] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [BankAccount] NVARCHAR(50) NOT NULL,
    [BankName] NVARCHAR(255) NULL,
    [isUsing] BIT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_BankAccountOfEmployee] ADD CONSTRAINT [PK_HR_BankAccountOfEmployee] PRIMARY KEY ([Employee_ID] ASC, [BankAccount] ASC);
