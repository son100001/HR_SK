CREATE TABLE [dbo].[Smartbooks_Timekeeping_Confirm] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Thang] INT NOT NULL,
    [Nam] INT NOT NULL,
    [XacNhanBangCong] BIT NULL,
    [Remark] NVARCHAR(MAX) NULL
);

ALTER TABLE [dbo].[Smartbooks_Timekeeping_Confirm] ADD CONSTRAINT [PK_Smartbooks_Timekeeping_Confirm] PRIMARY KEY ([Employee_ID] ASC, [Thang] ASC, [Nam] ASC);
