CREATE proc [dbo].[sp_ketchuyencongngoaile]
@fromdate datetime,
@todate datetime
as
begin
	--exec sp_ketchuyencongngoaile '2026-02-01', '2026-02-28'
	delete HR_BangCongNgoaiLe
	where Ngay between @fromdate and @todate and InsertBy = 'Auto'

	insert into HR_BangCongNgoaiLe (Employee_ID, Ngay, wt1, wt2, wt3, wt4, wt5, wt6, wt7, wt8, wt9, wt10, InsertDate, InsertBy, GhiChu)
	select Employee_ID, Ngay, wt1, wt2, wt3, wt4, wt5, wt6, wt7, wt8, wt9, wt10, InsertDate, 'Auto', GhiChu
	from
	HR_SNK.dbo.HR_BangCongNgoaiLe
	where Ngay between @fromdate and @todate
	--insert into HR_
end
GO
