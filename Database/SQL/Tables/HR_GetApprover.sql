CREATE TABLE [dbo].[HR_GetApprover] (
    [Factory_ID] NVARCHAR(50) NULL,
    [DepartmentCode] NVARCHAR(100) NULL,
    [SectionCode] NVARCHAR(100) NULL,
    [PositionCategory_ID] NVARCHAR(100) NULL,
    [ChucDanh] NVARCHAR(100) NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Code] NVARCHAR(200) NOT NULL,
    [Name] NVARCHAR(500) NULL,
    [ChiGuiThongBao] NVARCHAR(100) NULL,
    [RequestType] NVARCHAR(50) NOT NULL DEFAULT (N'RequestLeave')
);

ALTER TABLE [dbo].[HR_GetApprover] ADD CONSTRAINT [PK_HR_GetApprover] PRIMARY KEY ([Employee_ID] ASC, [Code] ASC, [RequestType] ASC);
