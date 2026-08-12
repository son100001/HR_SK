CREATE TABLE [dbo].[HR_SurgeryHistory] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [SurgeryReason] NVARCHAR(200) NULL,
    [SurgeryDate] DATETIME NOT NULL,
    [PostSurgeryEffects] NVARCHAR(MAX) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [UserName] NVARCHAR(50) NULL,
    [InsertDate] DATETIME NULL
);

ALTER TABLE [dbo].[HR_SurgeryHistory] ADD CONSTRAINT [PK_HR_SurgeryHistory] PRIMARY KEY ([Employee_ID] ASC, [SurgeryDate] ASC);
