CREATE TABLE [dbo].[HR_ContractFlow] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [ContractFlow] NVARCHAR(50) NOT NULL,
    [Contract_ID] NVARCHAR(50) NOT NULL,
    [No_] INT NOT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_ContractFlow] ADD CONSTRAINT [PK_HR_ContractFlow] PRIMARY KEY ([ContractFlow] ASC, [Contract_ID] ASC, [No_] ASC);
