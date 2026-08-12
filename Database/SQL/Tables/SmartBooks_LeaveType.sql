CREATE TABLE [dbo].[SmartBooks_LeaveType] (
    [ID] INT IDENTITY(1,1) NOT NULL,
    [LeaveType_ID] NVARCHAR(50) NOT NULL,
    [LeaveType_VN] NVARCHAR(50) NULL,
    [LeaveType_EN] NVARCHAR(255) NULL,
    [LeaveType_KR] NVARCHAR(50) NULL,
    [isLeave_nonPay] BIT NULL,
    [isLeave_InsPay] BIT NULL,
    [isLeave_ComPay] BIT NULL,
    [NotAllow] BIT NULL,
    [PhepNam] BIT NULL,
    [Termination] BIT NULL,
    [LongTermLeaving] BIT NULL,
    [ShortTermLeave] BIT NULL,
    [KhongTruCC] BIT NULL,
    [NumberOfDate] FLOAT NULL,
    [NumberOfMonth] FLOAT NULL,
    [isMaternityLeave] BIT NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [isMiscarriage] BIT NULL,
    [isNghiTruPhepNam] BIT NULL,
    [isNghiKhamThai] BIT NULL,
    [InsertDate] DATETIME NULL,
    [UserName] NVARCHAR(50) NULL,
    [AbsentSign] VARCHAR(50) NULL
);

ALTER TABLE [dbo].[SmartBooks_LeaveType] ADD CONSTRAINT [PK_SmartBooks_LeaveType] PRIMARY KEY ([LeaveType_ID] ASC);
