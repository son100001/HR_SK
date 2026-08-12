CREATE TABLE [dbo].[SmartBooks_DontTakePartinInsurance] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NOT NULL,
    [SocialInsurance] BIT NULL,
    [HealthInsurance] BIT NULL,
    [UnemploymentInsurance] BIT NULL,
    [UnionFee] BIT NULL,
    [Reason] NVARCHAR(250) NULL,
    [Absent] BIT NULL
);

ALTER TABLE [dbo].[SmartBooks_DontTakePartinInsurance] ADD CONSTRAINT [PK_SmartBooks_List_KhongthamgiaBH] PRIMARY KEY ([ID] ASC);
