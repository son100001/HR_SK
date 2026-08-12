create function [dbo].[udf_NgayCongDacBietToanCongTy]
(
	@fromdate datetime,
	@todate datetime
)
returns @rtnNgayCongDacBietToanCongTy table
(
	Ngay datetime
)
as
begin
	insert into @rtnNgayCongDacBietToanCongTy
	select Fromdate
	from
	udf_BangThoiGian (@fromdate,@todate) btg
	left join
	HR_SetUpFollowDate sufd
	on btg.Date_ between sufd.Fromdate and sufd.Todate and sufd.Code in ('Holiday','Hol','Sunday','Sun') and Group_ = 'Cong'
	where Fromdate between @fromdate and @todate and sufd.Fromdate is not null
	union
	select H_date
	from
	SmartBooks_HolidaysPlan
	where H_date between @fromdate and @todate

	return
end
GO
