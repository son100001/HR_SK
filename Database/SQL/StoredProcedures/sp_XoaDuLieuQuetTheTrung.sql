
Create proc sp_XoaDuLieuQuetTheTrung
@fromdate datetime,
@todate datetime
as
begin
	delete tkd
	from
	(
		select *, ROW_NUMBER () over (partition by Employee_ID, AccessTime order by Employee_ID, AccessTime) as rn
		from
		HR_TimeKeeping_Data
		where AccessDate between @fromdate and @todate
	) rn
	left join
	HR_TimeKeeping_Data tkd
	on rn.ID = tkd.ID
	where rn >= 2
end
GO
