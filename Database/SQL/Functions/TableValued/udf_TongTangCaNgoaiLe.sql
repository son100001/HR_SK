CREATE function [dbo].[udf_TongTangCaNgoaiLe]
(
	@fromdate datetime,
	@todate datetime
)
returns @rtnTongTangCaNgoaiLe table (Factory_ID nvarchar(50), Ngay datetime, Gio float, primary key (Factory_ID, Ngay))
as
begin
	insert into @rtnTongTangCaNgoaiLe
	select Factory_ID_SK1, Ngay_SK1, Gio_SK1
	from
	HR_TangCaNgoaiLe_SK1
	where Ngay_SK1 between @fromdate and @todate
	union
	select Factory_ID_SK2, Ngay_SK2, Gio_SK2
	from
	HR_TangCaNgoaiLe_SK2
	where Ngay_SK2 between @fromdate and @todate and Factory_ID_SK2 = 'SK2-Assembly'
	return
end
GO
