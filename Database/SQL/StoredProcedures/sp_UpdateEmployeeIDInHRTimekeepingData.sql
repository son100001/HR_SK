CREATE procedure [dbo].[sp_UpdateEmployeeIDInHRTimekeepingData]
@fromdate datetime,
@todate datetime
--exec sp_UpdateEmployeeIDInHRTimekeepingData '2024-11-23','2024-11-29'
as
begin
	Update tkd
	set tkd.Employee_ID = empl.Employee_ID
	from
	HR_TimeKeeping_Data tkd
	left join
	SmartBooks_Employee empl
	on tkd.Employee_ID = empl.Card_Code
	left join
	HR_TimeKeeping_Data tkd1
	on tkd1.CardNumber = tkd.CardNumber and tkd1.AccessDate = tkd.AccessDate and tkd1.AccessTime = tkd1.AccessTime and tkd1.Employee_ID <> tkd.Employee_ID
	where tkd.AccessDate between @fromdate and @todate and empl.Employee_ID is not null and tkd1.Employee_ID is null
	select 'ThanhCong' as ThongBao
end

GO
