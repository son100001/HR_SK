CREATE function [dbo].[udf_SoTienCaDem]
(
	@fromdate datetime,
	@todate datetime,
	@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan int,
	@UserName nvarchar(50),
	@fact nvarchar(50),
	@dept nvarchar(100),
	@sect nvarchar(100),
	@team nvarchar(100),
	@pos nvarchar(100),
	@posc nvarchar(100),
	@emp nvarchar(50)
)
returns @rtnSoTienCaDem table (Employee_ID nvarchar(50), SoCaDem int, TienCaDem int, primary key (Employee_ID))
as
--select * from udf_SoTienCaDem ('2025-08-01','2025-08-31',182,null,null,null,null,null,null,'C11602') where Employee_ID = 'C11602'
begin
	Declare @TrangThaiKH int = dbo.udf_TrangThaiKH(@UserName)
	insert into @rtnSoTienCaDem (Employee_ID, SoCaDem, TienCaDem)
	select isnull(wt.Employee_ID,tc.Employee_ID), isnull(sum(case when wt.Tongwt >= 4 then 1 else 0 end),0) as SoCaDem, sum(isnull(tc.TienCom,0)) as TienCaDem
	from
	(
		select wt.Employee_ID, wt.Ngay, sum(wt.wt) as Tongwt
		from
		HR_WTDaily wt
		left join
		udf_DangKyCa (@fromdate,@todate,@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan,@fact,@dept,@sect,@team,@pos,@posc,@emp) dkc
		on wt.Employee_ID = dkc.Employee_ID and wt.Ngay = dkc.AccessDate
		where wt.Ngay between @fromdate and @todate and dkc.ShiftName like N'%Shift3' and dkc.ShiftName is not null
				and (
						@TrangThaiKH = 0 
						or
						(@TrangThaiKH = 1 and wt.MaCong not like 'CN%')
						or
						(@TrangThaiKH = 2 and wt.MaCong like 'CN%')
					)
		group by wt.Employee_ID, wt.Ngay
	) wt
	FULL OUTER JOIN
	(
		select Employee_ID, sum(TienCom) as TienCom, tc.Ngay
		from
		HR_TienCom tc
		where tc.Ngay between @fromdate and @todate
		group by Employee_ID, Ngay
	) tc
	on wt.Employee_ID = tc.Employee_ID and wt.Ngay = tc.Ngay
	group by isnull(wt.Employee_ID,tc.Employee_ID)

	update @rtnSoTienCaDem
	set TienCaDem = 35000 * SoCaDem + case when @TrangThaiKH = 1 then 0 else isnull(TienCaDem,0) end


	return
end
GO
