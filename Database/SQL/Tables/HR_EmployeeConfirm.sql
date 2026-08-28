CREATE TABLE [dbo].[HR_EmployeeConfirm] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [Confirm_Month] INT NOT NULL,
    [Confirm_Year] INT NOT NULL,
    [ConfirmType] NVARCHAR(20) NOT NULL,
    [ConfirmStatus] BIT NULL,
    [ConfirmDate] DATETIME NULL,
    [Remark] NVARCHAR(MAX) NULL
);

ALTER TABLE [dbo].[HR_EmployeeConfirm] ADD CONSTRAINT [PK_HR_EmployeeConfirm] PRIMARY KEY ([Employee_ID] ASC, [Confirm_Month] ASC, [Confirm_Year] ASC, [ConfirmType] ASC);

CREATE NONCLUSTERED INDEX [IX_HR_EmployeeConfirm_Period_Type] ON [dbo].[HR_EmployeeConfirm] ([Confirm_Year] ASC, [Confirm_Month] ASC, [ConfirmType] ASC) INCLUDE ([ConfirmDate],[ConfirmStatus],[Employee_ID],[Remark]);
