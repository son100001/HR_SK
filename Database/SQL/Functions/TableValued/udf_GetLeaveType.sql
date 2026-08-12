
CREATE function [dbo].[udf_GetLeaveType]
(
	@TypeOfReport int = 1
)
returns @rtnGetLeaveType table
(
	[LeaveType_ID] [nvarchar](50) NOT NULL,
	[LeaveType_VN] [nvarchar](50) NULL,
	[LeaveType_EN] [nvarchar](255) NULL,
	[LeaveType_KR] [nvarchar](50) NULL,
	[isLeave_nonPay] [bit] NULL,
	[isLeave_InsPay] [bit] NULL,
	[isLeave_ComPay] [bit] NULL,
	[NotAllow] [bit] NULL,
	[PhepNam] [bit] NULL,
	[Termination] [bit] NULL,
	[LongTermLeaving] [bit] NULL,
	[ShortTermLeave] [bit] NULL,
	[NumberOfDate] [float] NULL,
	[NumberOfMonth] [float] NULL,
	[isMaternityLeave] [bit] NULL,
	[Remark] [nvarchar](max) NULL,
	[isMiscarriage] [bit] NULL,
	[isNghiTruPhepNam] [bit] NULL,
	[isNghiKhamThai] [bit] NULL,
	[isTinhChuyenCan] [bit] NULL,
	[InsertDate] [datetime] NULL,
	[UserName] [nvarchar](50) NULL,
	[AbsentSign] [varchar](50) NULL,
	[NumberSign] [int] NULL
)
as
begin
	--If @TypeOfReport = 1 begin
	insert into @rtnGetLeaveType
	select LeaveType_ID, LeaveType_VN, LeaveType_EN, LeaveType_KR, isLeave_nonPay, isLeave_InsPay, isLeave_ComPay, NotAllow, PhepNam, Termination, LongTermLeaving, ShortTermLeave, NumberOfDate, 
                         NumberOfMonth, isMaternityLeave, Remark, isMiscarriage, isNghiTruPhepNam, isNghiKhamThai, null, InsertDate, UserName, AbsentSign, null 
	from SmartBooks_LeaveType
	where LeaveType_ID in (11,12,21,24,46,48,49,52,20,33,23,25,13)
	--end

	return
end

GO
