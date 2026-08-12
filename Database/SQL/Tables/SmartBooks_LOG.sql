CREATE TABLE [dbo].[SmartBooks_LOG] (
    [Datetime] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [KeySumary] NVARCHAR(50) NULL,
    [TableName] NVARCHAR(50) NULL,
    [Form] NVARCHAR(50) NULL,
    [Action] NVARCHAR(3000) NULL
);
