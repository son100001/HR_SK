CREATE TABLE [dbo].[HR_Disable] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] VARCHAR(50) NOT NULL,
    [TypeOfDisable] NVARCHAR(50) NULL,
    [Reason] NVARCHAR(MAX) NULL,
    [PhanTram] FLOAT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [Approval] BIT NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_Disable] ADD CONSTRAINT [PK_HR_Disable] PRIMARY KEY ([Employee_ID] ASC, [Fromdate] ASC);
