CREATE TABLE [dbo].[HR_HealthCheck] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [Employee_ID] NVARCHAR(50) NOT NULL,
    [HealthCheckDate] DATETIME NOT NULL,
    [HospitalName] NVARCHAR(MAX) NULL,
    [HealthCheckingFee] FLOAT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL
);

ALTER TABLE [dbo].[HR_HealthCheck] ADD CONSTRAINT [PK_HR_HealthCheck] PRIMARY KEY ([Employee_ID] ASC, [HealthCheckDate] ASC);
