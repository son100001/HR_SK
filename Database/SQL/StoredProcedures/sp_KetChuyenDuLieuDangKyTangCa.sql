
CREATE proc [dbo].[sp_KetChuyenDuLieuDangKyTangCa]
@fromdate datetime,
@todate datetime
as
begin
	--exec sp_KetChuyenDuLieuDangKyTangCa '2025-04-01', '2025-04-30'
	Delete HR_MaxOvertime 
	where workingdate between @fromdate and @todate and UserName = 'Auto'

	insert into HR_MaxOvertime (Employee_ID, workingdate, maxovertime, TypeOfOT, Remark, UserName, InsertDate)
	select ovt.Employee_id, ovt.workingdate, ovt.maxovertime, 1, ovt.Shiftid, 'Auto', ovt.InsertDate
	from
	HR_SNK.dbo.HR_MaxOvertime ovt
	left join
	HR_MaxOvertime mot
	on ovt.Employee_id collate SQL_Latin1_General_CP1_CI_AS = mot.Employee_ID and ovt.workingdate = mot.workingdate and mot.TypeOfOT = 1
	where ovt.workingdate between @fromdate and @todate and ovt.maxovertime is not null and mot.Employee_ID is null
	
end
GO
