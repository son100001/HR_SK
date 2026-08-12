CREATE TABLE [dbo].[HR_ApproverConfigStatus] (
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [RequestType] NVARCHAR(50) NOT NULL,
    [RequiredApprovalSteps] INT NOT NULL DEFAULT ((0)),
    [ResolvedApprovalSteps] INT NOT NULL DEFAULT ((0)),
    [HasEmptyLevel] BIT NOT NULL DEFAULT ((0)),
    [UpdatedAt] DATETIME NOT NULL DEFAULT (getdate())
);

ALTER TABLE [dbo].[HR_ApproverConfigStatus] ADD CONSTRAINT [PK_HR_ApproverConfigStatus] PRIMARY KEY ([Employee_ID] ASC, [RequestType] ASC);
