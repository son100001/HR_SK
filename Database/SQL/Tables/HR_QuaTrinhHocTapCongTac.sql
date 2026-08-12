CREATE TABLE [dbo].[HR_QuaTrinhHocTapCongTac] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [LoaiQuaTrinh] VARCHAR(50) NOT NULL,
    [FromDate] DATETIME NOT NULL,
    [ToDate] DATE NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_QuaTrinhHocTapCongTac] ADD CONSTRAINT [PK_HR_QuaTrinhHocTapCongTac] PRIMARY KEY ([Employee_ID] ASC, [LoaiQuaTrinh] ASC, [FromDate] ASC);
