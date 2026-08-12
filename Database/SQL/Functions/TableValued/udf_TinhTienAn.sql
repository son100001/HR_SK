
--select * from udf_TinhTienAn('2024-11-01','2024-11-30',null,null,null,null,null,null) where Employee_ID in ('SS201105')
CREATE function [dbo].[udf_TinhTienAn]
(
	@fromdate datetime,
	@todate datetime,
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
)
returns @rtnTinhTienAn table (Employee_ID nvarchar(50), TienAnTrua float, TienAnChieu float , TienAnDem float, TienAnPhuDem float, TongTienAn float, primary key(Employee_ID))
as
begin
	declare @TienAnDem float, @TienAnChieu float, @TienAnTrua float, @TienAnPhuDem float
	select @TienAnDem = Value from HR_SetUpFollowDate where Group_ = 'Salary' and Code = 'TienAnDem' and Fromdate <= @todate and isnull(Todate,@todate) >= @todate order by Fromdate
	select @TienAnChieu = Value from HR_SetUpFollowDate where Group_ = 'Salary' and Code = 'TienAnChieu' and Fromdate <= @todate and isnull(Todate,@todate) >= @todate order by Fromdate
	select @TienAnTrua = Value from HR_SetUpFollowDate where Group_ = 'Salary' and Code = 'TienAnTrua' and Fromdate <= @todate and isnull(Todate,@todate) >= @todate order by Fromdate
	select @TienAnPhuDem = Value from HR_SetUpFollowDate where Group_ = 'Salary' and Code = 'TienAnPhuDem' and Fromdate <= @todate and isnull(Todate,@todate) >= @todate order by Fromdate
	insert into @rtnTinhTienAn (Employee_ID, TienAnTrua, TienAnChieu, TienAnDem, TienAnPhuDem)
	select tito.Employee_ID, sum(case when tito.ShiftName not like '%Shift3' and cast(shi.RestTimeFrom as time) between cast(tito.TimeIn as time) and cast(tito.[TimeOut] as time) then 1 else 0 end)*@TienAnTrua as TienAnTrua
			, sum(case when tito.ShiftName not like '%Shift3' and (case when tito.ShiftName = '90-Shift0' then '17:30:00.000' when tito.ShiftName = '10-Shift0' then '15:30:00.000' else '00:00:00.000' end) between cast(tito.TimeIn as time) and cast(tito.[TimeOut] as time) then 1 else 0 end)*@TienAnChieu as TienAnChieu
			, sum(case when tito.ShiftName like '%Shift3' and cast(shi.RestTimeFrom as time) between cast(tito.TimeIn as time) and cast(tito.[TimeOut] as time) then 1 else 0 end)*@TienAnDem as TienAnDem
			, sum(case when tito.ShiftName like '%Shift3' and '03:30:00.000' between cast(tito.TimeIn as time) and cast(tito.[TimeOut] as time) then 1 else 0 end)*@TienAnPhuDem as TienAnPhuDem
	from
	HR_TimeIn_TimeOut tito
	left join
	HR_Shifts shi
	on tito.ShiftName = shi.ShiftName
	where tito.OT_date between @fromdate and @todate and (tito.TimeIn is not null and tito.[TimeOut] is not null)
	group by tito.Employee_ID
	
	update @rtnTinhTienAn
	set TongTienAn = TienAnTrua + TienAnChieu + TienAnDem + TienAnPhuDem

	return
end

GO
