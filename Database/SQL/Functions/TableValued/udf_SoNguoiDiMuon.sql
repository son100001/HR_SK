
--select * from udf_SoNguoiDiMuon ('2024-11-01','2024-11-30')
--Declare @fromdate datetime = '2024-11-01', @todate datetime = '2024-11-30'
CREATE function udf_SoNguoiDiMuon
(
	@fromdate datetime,
	@todate datetime
)
returns @rtnSoNguoiDiMuon table (rn int, Employee_ID nvarchar(50), OT_date datetime, TimeIn datetime, [TimeOut] datetime, LateIn float, EarlyOut float, ShiftName nvarchar(50), primary key (rn, Employee_ID))
as
begin
	insert into @rtnSoNguoiDiMuon
	select *
	from
	(
		select ROW_NUMBER() over(partition by Employee_ID order by Employee_ID, isnull(LateIn,isnull(EarlyOut,0))) as rn, Employee_ID, OT_date, TimeIn, [TimeOut], LateIn, EarlyOut, ShiftName
		from
		HR_TimeIn_TimeOut
		where isnull(LateIn,0) between 1 and 60 or isnull(EarlyOut,0) between 1 and 60 and OT_date between @fromdate and @todate
	) a
	where a.rn <= 2
	return
end
GO
