CREATE TABLE [dbo].[HR_Transfer] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [TransferCode] NVARCHAR(200) NOT NULL,
    [EffectiveDate] DATETIME NOT NULL,
    [TypeOfTransfer] NVARCHAR(200) NOT NULL,
    [AssignType] NVARCHAR(200) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Transfer] ADD CONSTRAINT [PK_HR_Transfer] PRIMARY KEY ([Employee_ID] ASC, [EffectiveDate] ASC, [TypeOfTransfer] ASC);
