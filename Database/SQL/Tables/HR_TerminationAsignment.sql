CREATE TABLE [dbo].[HR_TerminationAsignment] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [PlanTernimationDate] DATETIME NOT NULL,
    [ResonTerminated] NVARCHAR(255) NULL,
    [DecisionCode] VARCHAR(50) NULL,
    [DecisionStatus] VARCHAR(50) NULL,
    [NgayNopDon] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [ThangTinhLuong] DATETIME NULL
);

ALTER TABLE [dbo].[HR_TerminationAsignment] ADD CONSTRAINT [PK_HR_TerminationAsignment] PRIMARY KEY ([Employee_ID] ASC, [PlanTernimationDate] ASC);
