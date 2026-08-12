CREATE proc [dbo].[sp_KetChuyenDuLieuDangKyCa]
@fromdate datetime,
@todate datetime
as
begin
	--exec sp_KetChuyenDuLieuDangKyCa '2025-02-01', '2025-02-28'
	Delete HR_RoundShift 
	where FromDate between @fromdate and @todate and UserName = 'Auto'

	--insert into HR_RoundShift (Employee_ID, ShiftName, FromDate, ToDate, TypeOfRegister)
	--select ctvt.Employee_ID, ctvt.ShiftName, DATEFROMPARTS(ctvt.Nam,ctvt.Thang,1), NULL, 1
	--from
	--HR_SNK.dbo.HR_CaTheoViTri ctvt
	--left join
	--HR_RoundShift rs
	--on ctvt.Employee_ID COLLATE SQL_Latin1_General_CP437_CI_AS = rs.Employee_ID 
	--	and DATEFROMPARTS(ctvt.Nam,ctvt.Thang,1) = rs.FromDate
	----where Nam <= 2022 or (Nam >= 2023 and Thang <= 10)
	--where Nam = Year(@fromdate) and Thang = MONTH(@fromdate) and rs.Employee_ID is null
	
	insert into HR_RoundShift (Employee_ID, ShiftName, FromDate, ToDate, TypeOfRegister, UserName)
	select erts.Employee_ID, erts.ShiftName, TimeDate, TimeDate, 1, 'Auto'
	from
	 HR_SNK.dbo.HR_EmpRegisTimeSheet erts
	 left join
	 HR_RoundShift rs
	 on erts.Employee_ID COLLATE SQL_Latin1_General_CP437_CI_AS = rs.Employee_ID and erts.TimeDate = rs.FromDate
	where TimeDate between @fromdate and @todate and rs.Employee_ID is null
	
	--Update rs
	--set rs.ShiftName = erts.ShiftName
	--from
	--HR_RoundShift rs
	--left join
	--HR_PREX.dbo.HR_EmpRegisTimeSheet erts
	--on rs.Employee_ID COLLATE SQL_Latin1_General_CP437_CI_AS = erts.Employee_ID and rs.FromDate = erts.TimeDate and erts.Employee_ID is not null and erts.ShiftName is not null
	
	Update rs
	set rs.ShiftName = case when sh.ShiftName is not null then sh.ShiftName else rs.ShiftName end
	from
	HR_RoundShift rs
	left join
	HR_Shifts sh
	on rs.ShiftName = sh.ShiftSign
	where FromDate between @fromdate and @todate and rs.UserName = 'Auto'

	Delete HR_RoundShift
	where isnull(ShiftName,'') = ''

end
GO
