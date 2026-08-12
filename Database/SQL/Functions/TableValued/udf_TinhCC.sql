CREATE function [dbo].[udf_TinhCC]
(
	@fromdate datetime,
	@todate datetime,
	@TienCC float,
	@Empl nvarchar(50)
)
--select * from udf_TinhCC ('2023-01-01','2023-01-31',200000,null) where Employee_ID = 'M00943'
returns @rtnTinhCC table (Employee_ID nvarchar(50), DuocTienCC float, primary key (Employee_ID))
as
begin
	
	insert into @rtnTinhCC
	select empl.Employee_ID
		, case when isnull(thc.wt1,0) + isnull(thc.wt9,0) + isnull(thc.wt2,0) + isnull(thp.PhepHuongLuong,0) < (dbo.udf_CountDayExceptSunday (@fromdate,@todate)*8 - 8) or (@fromdate >= '2023-03-01' and (isnull(QuenQuet.SoLanQuenQuet,0) >= 6 or (day(empl.StartedDate) >= 3 and empl.StartedDate between @fromdate and @todate))) then 0
			when isnull(thc.wt1,0) + isnull(thc.wt9,0) + isnull(thc.wt2,0) + isnull(thp.PhepHuongLuong,0) < (dbo.udf_CountDayExceptSunday (@fromdate,@todate)*8 - case when @fromdate = '2023-01-01' then 4 else 0 end) or (@fromdate >= '2023-03-01' and (isnull(QuenQuet.SoLanQuenQuet,0) between 3 and 5 or (day(empl.StartedDate) >= 2 and empl.StartedDate between @fromdate and @todate))) then @TienCC / 2
			else @TienCC end as DuocTienCC
	from
	udf_EmployeeFilter ('VN',null,null,null,null,null,null,@Empl,GETDATE()) empl
	left join
	(
		select tito.Employee_ID, sum(case when isnull(tito.realLateIn,0) <= 15 and isnull(tito.realLateIn,0) > 0 then 1 else 0 end) + sum(case when isnull(tito.RealEarlyOut,0) <= 15 and isnull(tito.RealEarlyOut,0) > 0 then 1 else 0 end) as CountLateInEarlyOutLess15
				, sum(case when isnull(tito.realLateIn,0) > 15 then 1 else 0 end) + sum(case when isnull(tito.RealEarlyOut,0) > 15 then 1 else 0 end) as CountLateInEarlyOutOver15
		from HR_TimeIn_TimeOut tito
		where tito.OT_date between @fromdate and @todate
		group by tito.Employee_ID
	) tito
	on empl.Employee_ID = tito.Employee_ID
	left join
	(
		select Employee_ID,AccessDate as Ngay,count(Employee_ID) as SoLanQuenQuet 
		from HR_TimeKeeping_Data where AccessDate between @fromdate and @todate and insertsource='NhapTay' and isnull(Reason,'')=N'ForgotScan' group by Employee_ID, AccessDate
		union
		select Employee_ID,Ngay, 0 as SoLanQuenQuet from HR_DuLieuQuetVaoRa where Ngay between @fromdate and @todate
	)QuenQuet
	on empl.Employee_ID = QuenQuet.Employee_ID
	left join
	udf_TongHopPhep (@fromdate, @todate, 1) thp
	on empl.Employee_ID = thp.Employee_ID
	left join
	udf_TongHopCong (@fromdate,@todate,1,'admin') thc
	on empl.Employee_ID = thc.Employee_ID
	where isnull(empl.TernimationDate,@todate) >= @fromdate
	return
end
GO
