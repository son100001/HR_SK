
CREATE function [dbo].[udf_PhepNamTheoThang]
(
	@year int,
	@Lan nvarchar(50),
	@fact nvarchar(50),
	@dept nvarchar(50),
	@sect nvarchar(50),
	@team nvarchar(50),
	@pos nvarchar(50),
	@posc nvarchar(50),
	@emp nvarchar(50),
	@Date datetime
)
returns @rtnPhepNamTheoThang table
( Employee_ID nvarchar(50), jan float, feb float, mar float, apr float, may float, jun float, jul float, aug float, sep float, oct float, nov float, [dec] float, primary key(Employee_ID))
as
begin
	Declare @LeaveTable table (Employee_ID nvarchar(50), Leave float, primary key(Employee_ID))
	Declare @LeaveAllow table (Employee_ID nvarchar(50), acc_jan float, acc_feb float, acc_mar float, acc_apr float, acc_may float, acc_jun float, acc_jul float, acc_aug float, acc_sep float, acc_oct float, acc_nov float, acc_dec float
								, UnA_jan float, UnA_feb float, UnA_mar float, UnA_apr float, UnA_may float, UnA_jun float, UnA_jul float, UnA_aug float, UnA_sep float, UnA_oct float, UnA_nov float, UnA_dec float
								, sick_jan float, sick_feb float, sick_mar float, sick_apr float, sick_may float, sick_jun float, sick_jul float, sick_aug float, sick_sep float, sick_oct float, sick_nov float, sick_dec float, primary key (Employee_ID))
	Declare @FirstOfJan datetime, @EndOfJan datetime, @FirstOfFeb datetime, @EndOfFeb datetime, @FirstOfMar datetime, @EndOfMar datetime, @FirstOfApr datetime, @EndOfApr datetime, @FirstOfMay datetime, @EndOfMay datetime, @FirstOfJun datetime, @EndOfJun datetime
			, @FirstOfJul datetime, @EndOfJul datetime, @FirstOfAug datetime, @EndOfAug datetime, @FirstOfSep datetime, @EndOfSep datetime, @FirstOfOct datetime, @EndOfOct datetime, @FirstOfNov datetime, @EndOfNov datetime, @FirstOfDec datetime, @EndOfDec datetime
	
	set @FirstOfJan = DATEFROMPARTS(@year, 1, 1)
	set @EndOfJan = EOMONTH(@FirstOfJan,0)
	set @FirstOfFeb = DATEFROMPARTS(@year, 2, 1)
	set @EndOfFeb = EOMONTH(@FirstOfFeb,0)
	set @FirstOfMar = DATEFROMPARTS(@year, 3, 1)
	set @EndOfMar = EOMONTH(@FirstOfMar,0)
	set @FirstOfApr = DATEFROMPARTS(@year, 4, 1)
	set @EndOfApr = EOMONTH(@FirstOfApr,0)
	set @FirstOfMay = DATEFROMPARTS(@year, 5, 1)
	set @EndOfMay = EOMONTH(@FirstOfMay,0)
	set @FirstOfJun = DATEFROMPARTS(@year, 6, 1)
	set @EndOfJun = EOMONTH(@FirstOfJun,0)
	set @FirstOfJul = DATEFROMPARTS(@year, 7, 1)
	set @EndOfJul = EOMONTH(@FirstOfJul,0)
	set @FirstOfAug = DATEFROMPARTS(@year, 8, 1)
	set @EndOfAug = EOMONTH(@FirstOfAug,0)
	set @FirstOfSep = DATEFROMPARTS(@year, 9, 1)
	set @EndOfSep = EOMONTH(@FirstOfSep,0)
	set @FirstOfOct = DATEFROMPARTS(@year, 10, 1)
	set @EndOfOct = EOMONTH(@FirstOfOct,0)
	set @FirstOfNov = DATEFROMPARTS(@year, 11, 1)
	set @EndOfNov = EOMONTH(@FirstOfNov,0)
	set @FirstOfDec = DATEFROMPARTS(@year, 12, 1)
	set @EndOfDec = EOMONTH(@FirstOfDec,0)

	insert into @LeaveAllow (Employee_ID, acc_jan, acc_feb, acc_mar, acc_apr, acc_may, acc_jun, acc_jul, acc_aug, acc_sep, acc_oct, acc_nov, acc_dec, sick_jan, sick_feb, sick_mar, sick_apr, sick_may, sick_jun, sick_jul, sick_aug, sick_sep, sick_oct, sick_nov, sick_dec)
	select empl.Employee_ID
			--Accident
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfJan then ptn.Hourleave/8.0 else 0 end) as acc_jan
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfFeb then ptn.Hourleave/8.0 else 0 end) as acc_feb
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfMar then ptn.Hourleave/8.0 else 0 end) as acc_mar
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfApr then ptn.Hourleave/8.0 else 0 end) as acc_apr
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfMay then ptn.Hourleave/8.0 else 0 end) as acc_may
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfJun then ptn.Hourleave/8.0 else 0 end) as acc_jun
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfJul then ptn.Hourleave/8.0 else 0 end) as acc_jul
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfAug then ptn.Hourleave/8.0 else 0 end) as acc_aug
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfSep then ptn.Hourleave/8.0 else 0 end) as acc_sep
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfOct then ptn.Hourleave/8.0 else 0 end) as acc_oct
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfNov then ptn.Hourleave/8.0 else 0 end) as acc_nov
			, sum(case when LeaveType_ID = '13' and ptn.DateLeave between @FirstOfJan and @EndOfDec then ptn.Hourleave/8.0 else 0 end) as acc_dec
			--LeaveSick
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfJan then ptn.Hourleave/8.0 else 0 end) as sick_jan
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfFeb then ptn.Hourleave/8.0 else 0 end) as sick_feb
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfMar then ptn.Hourleave/8.0 else 0 end) as sick_mar
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfApr then ptn.Hourleave/8.0 else 0 end) as sick_apr
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfMay then ptn.Hourleave/8.0 else 0 end) as sick_may
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfJun then ptn.Hourleave/8.0 else 0 end) as sick_jun
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfJul then ptn.Hourleave/8.0 else 0 end) as sick_jul
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfAug then ptn.Hourleave/8.0 else 0 end) as sick_aug
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfSep then ptn.Hourleave/8.0 else 0 end) as sick_sep
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfOct then ptn.Hourleave/8.0 else 0 end) as sick_oct
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfNov then ptn.Hourleave/8.0 else 0 end) as sick_nov
			, sum(case when LeaveType_ID in ('21','22','23') and ptn.DateLeave between @FirstOfJan and @EndOfDec then ptn.Hourleave/8.0 else 0 end) as sick_dec
	from 
	[dbo].[udf_EmployeeFilter](@Lan,@fact,@dept,@sect,@team,@pos,@posc,@emp,isnull(@EndOfApr,getdate())) empl
	left join
	udf_BangPhepTheoNgay(2,@FirstOfJan,@EndOfDec,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
	on empl.Employee_ID = ptn.Employee_ID
	where empl.TernimationDate is null or empl.TernimationDate > @FirstOfJan
	group by empl.Employee_ID

	/*update la
		  set la.UnA_jan = ermp.UnA_jan
			, la.UnA_feb = ermp.UnA_feb
			, la.UnA_mar = ermp.UnA_mar
			, la.UnA_apr = ermp.UnA_apr
			, la.UnA_may = ermp.UnA_may
			, la.UnA_jun = ermp.UnA_jun
			, la.UnA_jul = ermp.UnA_jul
			, la.UnA_aug = ermp.UnA_aug
			, la.UnA_sep = ermp.UnA_sep
			, la.UnA_oct = ermp.UnA_oct
			, la.UnA_nov = ermp.UnA_nov
			, la.UnA_dec = ermp.UnA_dec
	from
	@LeaveAllow la
	left join
	(
		select Employee_ID
		, sum(case when ermp.Fromdate < @EndOfJan then (case when ermp.Todate < @EndOfJan then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfJan) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfJan then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfJan) + 1 end) else 0 end) as UnA_jan
		, sum(case when ermp.Fromdate < @EndOfFeb then (case when ermp.Todate < @EndOfFeb then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfFeb) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfFeb then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfFeb) + 1 end) else 0 end) as UnA_feb
		, sum(case when ermp.Fromdate < @EndOfMar then (case when ermp.Todate < @EndOfMar then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfMar) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfMar then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfMar) + 1 end) else 0 end) as UnA_mar
		, sum(case when ermp.Fromdate < @EndOfApr then (case when ermp.Todate < @EndOfApr then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfApr) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfApr then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfApr) + 1 end) else 0 end) as UnA_apr
		, sum(case when ermp.Fromdate < @EndOfMay then (case when ermp.Todate < @EndOfMay then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfMay) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfMay then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfMay) + 1 end) else 0 end) as UnA_may
		, sum(case when ermp.Fromdate < @EndOfJun then (case when ermp.Todate < @EndOfJun then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfJun) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfJun then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfJun) + 1 end) else 0 end) as UnA_jun
		, sum(case when ermp.Fromdate < @EndOfJul then (case when ermp.Todate < @EndOfJul then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfJul) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfJul then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfJul) + 1 end) else 0 end) as UnA_jul
		, sum(case when ermp.Fromdate < @EndOfAug then (case when ermp.Todate < @EndOfAug then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfAug) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfAug then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfAug) + 1 end) else 0 end) as UnA_aug
		, sum(case when ermp.Fromdate < @EndOfSep then (case when ermp.Todate < @EndOfSep then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfSep) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfSep then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfSep) + 1 end) else 0 end) as UnA_sep
		, sum(case when ermp.Fromdate < @EndOfOct then (case when ermp.Todate < @EndOfOct then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfOct) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfOct then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfOct) + 1 end) else 0 end) as UnA_oct
		, sum(case when ermp.Fromdate < @EndOfNov then (case when ermp.Todate < @EndOfNov then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfNov) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfNov then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfNov) + 1 end) else 0 end) as UnA_nov
		, sum(case when ermp.Fromdate < @EndOfDec then (case when ermp.Todate < @EndOfDec then datediff(day, ermp.Fromdate, ermp.Todate) + 1 else datediff(day, ermp.Fromdate, @EndOfDec) + 1 end) /* fromdate < First Of Year*/ when ermp.Fromdate < @FirstOfJan then (case when ermp.Todate < @EndOfDec then datediff(day, @FirstOfJan, ermp.Todate) + 1 else datediff(day, @FirstOfJan, @EndOfDec) + 1 end) else 0 end) as UnA_dec
		from HR_EmployeeRegisMaternityLeave ermp
		where ermp.LeaveType_ID in ('14','20','46','54') and Datediff(day,ermp.Fromdate,ermp.ToDate) > 30 and (Fromdate between @FirstOfJan and @EndOfDec or Todate between @FirstOfJan and @EndOfDec)
		group by ermp.Employee_ID
	) ermp
	on la.Employee_ID = ermp.Employee_ID*/

	--select * from @LeaveAllow where Employee_ID = @emp

	--select la.Employee_ID, ptn.DateLeave, ptn.HourLeave, ptn.LeaveType_ID
	--from
	--@LeaveAllow la
	--left join
	--udf_BangPhepTheoNgay(@FirstOfOct,@EndOfOct,null,null,null,null,null,null,@emp,null) ptn
	--on la.Employee_ID = ptn.Employee_ID
	--left join
	--SmartBooks_LeaveType lt
	--on ptn.LeaveType_ID = lt.LeaveType_ID
	--where UnA_dec > 30 or acc_dec > 180 or sick_dec > 60
	--select bptn.*, lt.isLeave_nonPay from udf_BangPhepTheoNgay ('2021-4-1','2021-4-30',null,null,null,null,null,null,'HT000087',null) bptn left join SmartBooks_LeaveType lt on bptn.LeaveType_ID = lt.LeaveType_ID
	--select * from udf_PhepNamTheoThang (2021,'VN',null,null,null,null,null,null,'HT001758',GETDATE())
	
	insert into @rtnPhepNamTheoThang
	select la.Employee_ID
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfJan,@EndOfJan)/2.0 - (case when empl.StartedDate > @FirstOfJan then dbo.udf_CountDayExceptSunday(@FirstOfJan, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfJan then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfJan) else 0 end) + (case when la.acc_jan > 180 then dbo.udf_CompareGetMax(180,la.acc_jan) - la.acc_jan else 0 end) + /*(case when la.UnA_jan > 31 then dbo.udf_CompareGetMax(31,la.UnA_jan) - la.UnA_jan else 0 end) +*/ (case when la.sick_jan > 60 then dbo.udf_CompareGetMax(60,la.sick_jan) - la.sick_jan else 0 end) - sum((case when (empl.StartedDate between @FirstOfJan and @EndOfJan or empl.TernimationDate between @FirstOfJan and @EndOfJan) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfJan and @EndOfJan) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfJan and @EndOfJan and (((empl.StartedDate between @FirstOfJan and @EndOfJan or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfJan and @EndOfJan) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_jan < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_jan,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_jan < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as jan
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfFeb,@EndOfFeb)/2.0 - (case when empl.StartedDate > @FirstOfFeb then dbo.udf_CountDayExceptSunday(@FirstOfFeb, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfFeb then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfFeb) else 0 end) + (case when la.acc_feb > 180 then dbo.udf_CompareGetMax(180,la.acc_jan) - la.acc_jan else 0 end) + /*(case when la.UnA_feb > 31 then dbo.udf_CompareGetMax(31,la.UnA_jan) - la.UnA_jan else 0 end) +*/ (case when la.sick_feb > 60 then dbo.udf_CompareGetMax(60,la.sick_jan) - la.sick_jan else 0 end) - sum((case when (empl.StartedDate between @FirstOfFeb and @EndOfFeb or empl.TernimationDate between @FirstOfFeb and @EndOfFeb) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfFeb and @EndOfFeb) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfFeb and @EndOfFeb and (((empl.StartedDate between @FirstOfFeb and @EndOfFeb or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfFeb and @EndOfFeb) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_feb < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_feb,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_feb < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as feb
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfMar,@EndOfMar)/2.0 - (case when empl.StartedDate > @FirstOfMar then dbo.udf_CountDayExceptSunday(@FirstOfMar, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfMar then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfMar) else 0 end) + (case when la.acc_mar > 180 then dbo.udf_CompareGetMax(180,la.acc_feb) - la.acc_feb else 0 end) + /*(case when la.UnA_mar > 31 then dbo.udf_CompareGetMax(31,la.UnA_feb) - la.UnA_feb else 0 end) +*/ (case when la.sick_mar > 60 then dbo.udf_CompareGetMax(60,la.sick_feb) - la.sick_feb else 0 end) - sum((case when (empl.StartedDate between @FirstOfMar and @EndOfMar or empl.TernimationDate between @FirstOfMar and @EndOfMar) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfMar and @EndOfMar) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfMar and @EndOfMar and (((empl.StartedDate between @FirstOfMar and @EndOfMar or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfMar and @EndOfMar) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_mar < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_mar,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_mar < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as mar
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfApr,@EndOfApr)/2.0 - (case when empl.StartedDate > @FirstOfApr then dbo.udf_CountDayExceptSunday(@FirstOfApr, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfApr then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfApr) else 0 end) + (case when la.acc_apr > 180 then dbo.udf_CompareGetMax(180,la.acc_mar) - la.acc_mar else 0 end) + /*(case when la.UnA_apr > 31 then dbo.udf_CompareGetMax(31,la.UnA_mar) - la.UnA_mar else 0 end) +*/ (case when la.sick_apr > 60 then dbo.udf_CompareGetMax(60,la.sick_mar) - la.sick_mar else 0 end) - sum((case when (empl.StartedDate between @FirstOfApr and @EndOfApr or empl.TernimationDate between @FirstOfApr and @EndOfApr) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfApr and @EndOfApr) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfApr and @EndOfApr and (((empl.StartedDate between @FirstOfApr and @EndOfApr or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfApr and @EndOfApr) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_apr < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_apr,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_apr < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as apr
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfMay,@EndOfMay)/2.0 - (case when empl.StartedDate > @FirstOfMay then dbo.udf_CountDayExceptSunday(@FirstOfMay, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfMay then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfMay) else 0 end) + (case when la.acc_may > 180 then dbo.udf_CompareGetMax(180,la.acc_apr) - la.acc_apr else 0 end) + /*(case when la.UnA_may > 31 then dbo.udf_CompareGetMax(31,la.UnA_apr) - la.UnA_apr else 0 end) +*/ (case when la.sick_may > 60 then dbo.udf_CompareGetMax(60,la.sick_apr) - la.sick_apr else 0 end) - sum((case when (empl.StartedDate between @FirstOfMay and @EndOfMay or empl.TernimationDate between @FirstOfMay and @EndOfMay) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfMay and @EndOfMay) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfMay and @EndOfMay and (((empl.StartedDate between @FirstOfMay and @EndOfMay or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfMay and @EndOfMay) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_may < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_may,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_may < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as may
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfJun,@EndOfJun)/2.0 - (case when empl.StartedDate > @FirstOfJun then dbo.udf_CountDayExceptSunday(@FirstOfJun, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfJun then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfJun) else 0 end) + (case when la.acc_jun > 180 then dbo.udf_CompareGetMax(180,la.acc_may) - la.acc_may else 0 end) + /*(case when la.UnA_jun > 31 then dbo.udf_CompareGetMax(31,la.UnA_may) - la.UnA_may else 0 end) +*/ (case when la.sick_jun > 60 then dbo.udf_CompareGetMax(60,la.sick_may) - la.sick_may else 0 end) - sum((case when (empl.StartedDate between @FirstOfJun and @EndOfJun or empl.TernimationDate between @FirstOfJun and @EndOfJun) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfJun and @EndOfJun) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfJun and @EndOfJun and (((empl.StartedDate between @FirstOfJun and @EndOfJun or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfJun and @EndOfJun) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_jun < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_jun,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_jun < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as jun
			, case when @year = '2025' then 0 when dbo.udf_CountDayExceptSunday(@FirstOfJul,@EndOfJul)/2.0 - (case when empl.StartedDate > @FirstOfJul then dbo.udf_CountDayExceptSunday(@FirstOfJul, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfJul then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfJul) else 0 end) + (case when la.acc_jul > 180 then dbo.udf_CompareGetMax(180,la.acc_jun) - la.acc_jun else 0 end) + /*(case when la.UnA_jul > 31 then dbo.udf_CompareGetMax(31,la.UnA_jun) - la.UnA_jun else 0 end) +*/ (case when la.sick_jul > 60 then dbo.udf_CompareGetMax(60,la.sick_jun) - la.sick_jun else 0 end) - sum((case when (empl.StartedDate between @FirstOfJul and @EndOfJul or empl.TernimationDate between @FirstOfJul and @EndOfJul) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfJul and @EndOfJul) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfJul and @EndOfJul and (((empl.StartedDate between @FirstOfJul and @EndOfJul or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfJul and @EndOfJul) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_jul < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_jul,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_jul < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as jul
			, case when dbo.udf_CountDayExceptSunday(@FirstOfAug,@EndOfAug)/2.0 - (case when empl.StartedDate > @FirstOfAug then dbo.udf_CountDayExceptSunday(@FirstOfAug, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfAug then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfAug) else 0 end) + (case when la.acc_aug > 180 then dbo.udf_CompareGetMax(180,la.acc_jul) - la.acc_jul else 0 end) + /*(case when la.UnA_aug > 31 then dbo.udf_CompareGetMax(31,la.UnA_jul) - la.UnA_jul else 0 end) +*/ (case when la.sick_aug > 60 then dbo.udf_CompareGetMax(60,la.sick_jul) - la.sick_jul else 0 end) - sum((case when (empl.StartedDate between @FirstOfAug and @EndOfAug or empl.TernimationDate between @FirstOfAug and @EndOfAug) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfAug and @EndOfAug) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfAug and @EndOfAug and (((empl.StartedDate between @FirstOfAug and @EndOfAug or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfAug and @EndOfAug) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_aug < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_aug,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_aug < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as aug
			, case when dbo.udf_CountDayExceptSunday(@FirstOfSep,@EndOfSep)/2.0 - (case when empl.StartedDate > @FirstOfSep then dbo.udf_CountDayExceptSunday(@FirstOfSep, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfSep then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfSep) else 0 end) + (case when la.acc_sep > 180 then dbo.udf_CompareGetMax(180,la.acc_aug) - la.acc_aug else 0 end) + /*(case when la.UnA_sep > 31 then dbo.udf_CompareGetMax(31,la.UnA_aug) - la.UnA_aug else 0 end) +*/ (case when la.sick_sep > 60 then dbo.udf_CompareGetMax(60,la.sick_aug) - la.sick_aug else 0 end) - sum((case when (empl.StartedDate between @FirstOfSep and @EndOfSep or empl.TernimationDate between @FirstOfSep and @EndOfSep) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfSep and @EndOfSep) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfSep and @EndOfSep and (((empl.StartedDate between @FirstOfSep and @EndOfSep or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfSep and @EndOfSep) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_sep < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_sep,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_sep < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as sep
			, case when dbo.udf_CountDayExceptSunday(@FirstOfOct,@EndOfOct)/2.0 - (case when empl.StartedDate > @FirstOfOct then dbo.udf_CountDayExceptSunday(@FirstOfOct, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfOct then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfOct) else 0 end) + (case when la.acc_oct > 180 then dbo.udf_CompareGetMax(180,la.acc_sep) - la.acc_sep else 0 end) + /*(case when la.UnA_oct > 31 then dbo.udf_CompareGetMax(31,la.UnA_sep) - la.UnA_sep else 0 end) +*/ (case when la.sick_oct > 60 then dbo.udf_CompareGetMax(60,la.sick_sep) - la.sick_sep else 0 end) - sum((case when (empl.StartedDate between @FirstOfOct and @EndOfOct or empl.TernimationDate between @FirstOfOct and @EndOfOct) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfOct and @EndOfOct) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfOct and @EndOfOct and (((empl.StartedDate between @FirstOfOct and @EndOfOct or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfOct and @EndOfOct) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_oct < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_oct,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_oct < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as oct
			, case when dbo.udf_CountDayExceptSunday(@FirstOfNov,@EndOfNov)/2.0 - (case when empl.StartedDate > @FirstOfNov then dbo.udf_CountDayExceptSunday(@FirstOfNov, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfNov then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfNov) else 0 end) + (case when la.acc_nov > 180 then dbo.udf_CompareGetMax(180,la.acc_oct) - la.acc_oct else 0 end) + /*(case when la.UnA_nov > 31 then dbo.udf_CompareGetMax(31,la.UnA_oct) - la.UnA_oct else 0 end) +*/ (case when la.sick_nov > 60 then dbo.udf_CompareGetMax(60,la.sick_oct) - la.sick_oct else 0 end) - sum((case when (empl.StartedDate between @FirstOfNov and @EndOfNov or empl.TernimationDate between @FirstOfNov and @EndOfNov) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfNov and @EndOfNov) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfNov and @EndOfNov and (((empl.StartedDate between @FirstOfNov and @EndOfNov or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfNov and @EndOfNov) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_nov < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_nov,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_nov < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as nov
			, case when dbo.udf_CountDayExceptSunday(@FirstOfDec,@EndOfDec)/2.0 - (case when empl.StartedDate > @FirstOfDec then dbo.udf_CountDayExceptSunday(@FirstOfDec, empl.StartedDate - 1) else 0 end) - (case when isnull(empl.TernimationDate, '3099-1-1') < @EndOfDec then dbo.udf_CountDayExceptSunday(empl.TernimationDate, @EndOfDec) else 0 end) + (case when la.acc_dec > 180 then dbo.udf_CompareGetMax(180,la.acc_nov) - la.acc_nov else 0 end) + /*(case when la.UnA_dec > 31 then dbo.udf_CompareGetMax(31,la.UnA_nov) - la.UnA_nov else 0 end) +*/ (case when la.sick_dec > 60 then dbo.udf_CompareGetMax(60,la.sick_nov) - la.sick_nov else 0 end) - sum((case when (empl.StartedDate between @FirstOfDec and @EndOfDec or empl.TernimationDate between @FirstOfDec and @EndOfDec) and ((isnull(lt.isLeave_nonPay,0) = 1 or isnull(lt.isLeave_inspay,0)= 1) and ptn.DateLeave between @FirstOfDec and @EndOfDec) then isnull(ptn.HourLeave,0)/8.0 when ptn.DateLeave between @FirstOfDec and @EndOfDec and (((empl.StartedDate between @FirstOfDec and @EndOfDec or isnull(empl.TernimationDate,@EndOfDec+1) between @FirstOfDec and @EndOfDec) and isnull(lt.isLeave_nonPay, 0) = 1) or lt.LeaveType_ID in ('13','48','49','24','14','20','46','21','22','23','54')) then (case when (ptn.LeaveType_ID in ('48','49','24')) or (ptn.LeaveType_ID = '13' and la.acc_dec < 180) or (ptn.LeaveType_ID in ('14','20','46','54') /*and isnull(UnA_dec,0) < 31*/) or (ptn.LeaveType_ID in ('21','22','23') and sick_dec < 60) then 0 else isnull(ptn.HourLeave,0)/8.0 end) else 0 end)) >= 0 then 1 else 0 end as [dec]
	from 																																																																																					
	@LeaveAllow la
	left join
	udf_BangPhepTheoNgay(2,@FirstOfJan,@EndOfDec,@fact,@dept,@sect,@team,@pos,@posc,@emp,null) ptn
	on la.Employee_ID = ptn.Employee_ID
	left join
	SmartBooks_LeaveType lt
	on ptn.LeaveType_ID = lt.LeaveType_ID
	left join
	udf_EmployeeFilter (@Lan,@fact,@dept,@sect,@team,@pos,@posc,@emp,@Date) empl
	on la.Employee_ID = empl.Employee_ID
	--where UnA_dec > 30 or acc_dec > 180 or sick_dec > 60
	group by la.Employee_ID, empl.StartedDate, empl.TernimationDate, acc_jan, acc_feb, acc_mar, acc_apr, acc_may, acc_jun, acc_jul, acc_aug, acc_sep, acc_oct, acc_nov, acc_dec
				/*, UnA_jan, UnA_feb, UnA_mar, UnA_apr, UnA_may, UnA_jun, UnA_jul, UnA_aug, UnA_sep, UnA_oct, UnA_nov, UnA_dec*/
				, sick_jan, sick_feb, sick_mar, sick_apr, sick_may, sick_jun, sick_jul, sick_aug, sick_sep, sick_oct, sick_nov, sick_dec



	--insert into @LeaveTable
	--select empl.Employee_ID, sum(case when lt.isLeave_nonPay = 1 and (lt.LeaveType_ID not in ('24') and lt.LeaveType_ID not in ('21','22','13')) then ptn.HourLeave/8.0 else 0 end) as Leave
	--from [dbo].[udf_EmployeeFilter]('VN',null,null,null,null,null,null,null,isnull('2022' + '-4-30',getdate())) empl
	--left join
	--udf_BangPhepTheoNgay('2022' + '-4-1','2022' + '-4-30',null,null,null,null,null,null,null,null) ptn
	--on empl.Employee_ID = ptn.Employee_ID
	--left join
	--SmartBooks_LeaveType lt
	--on ptn.LeaveType_ID = lt.LeaveType_ID
	--group by empl.Employee_ID

	--select * from @LeaveTable where Leave > 14
	return
end
GO
