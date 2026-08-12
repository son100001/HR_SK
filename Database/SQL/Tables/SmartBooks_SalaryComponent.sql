CREATE TABLE [dbo].[SmartBooks_SalaryComponent] (
    [eDate] VARCHAR(6) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [SalaryComponent1] FLOAT NULL,
    [SalaryComponent2] FLOAT NULL,
    [SalaryComponent3] FLOAT NULL,
    [SalaryComponent4] FLOAT NULL,
    [SalaryComponent5] FLOAT NULL,
    [SalaryComponent6] FLOAT NULL,
    [SalaryComponent7] FLOAT NULL,
    [SalaryComponent8] FLOAT NULL,
    [SalaryComponent9] FLOAT NULL,
    [SalaryComponent10] FLOAT NULL,
    [SalaryComponent11] FLOAT NULL,
    [SalaryComponent12] FLOAT NULL,
    [SalaryComponent13] FLOAT NULL,
    [SalaryComponent14] FLOAT NULL,
    [SalaryComponent15] FLOAT NULL,
    [Comment] NVARCHAR(1024) NULL,
    [CreateBy] NVARCHAR(50) NULL,
    [CreateDate] DATETIME NOT NULL,
    [UpdateBy] NVARCHAR(50) NULL,
    [UpdateDate] DATETIME NULL
);

ALTER TABLE [dbo].[SmartBooks_SalaryComponent] ADD CONSTRAINT [PK_SmartBooks_SalaryComponent] PRIMARY KEY ([eDate] ASC, [Employee_ID] ASC, [CreateDate] ASC);
