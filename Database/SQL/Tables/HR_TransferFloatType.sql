CREATE TABLE [dbo].[HR_TransferFloatType] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [HAZARD] VARCHAR(50) NULL,
    [Vl] FLOAT NULL
);

ALTER TABLE [dbo].[HR_TransferFloatType] ADD CONSTRAINT [PK_HR_TransferFloatType_1] PRIMARY KEY ([Employee_ID] ASC, [Fromdate] ASC);
