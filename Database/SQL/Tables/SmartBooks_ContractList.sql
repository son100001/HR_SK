CREATE TABLE [dbo].[SmartBooks_ContractList] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Contract_ID] NVARCHAR(50) NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [CL_RegisterDate] DATETIME NULL,
    [CL_ExpiredDate] DATETIME NULL,
    [CL_StartDate] DATETIME NOT NULL,
    [status] BIT NULL,
    [Type] NVARCHAR(50) NOT NULL,
    [CL_FatherID] NVARCHAR(50) NULL,
    [CL_Remark] NVARCHAR(MAX) NULL,
    [InsertSource] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [ContractAnnexID] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_ContractList] ADD CONSTRAINT [PK_SmartBooks_ContractList] PRIMARY KEY ([Employee_ID] ASC, [CL_StartDate] ASC, [Type] ASC);
