CREATE proc [dbo].[sp_KetChuyenTangCaNgoaiLe]
@fromdate datetime,
@todate datetime
as
begin
--exec sp_KetChuyenTangCaNgoaiLe '2026-06-01', '2026-06-30'
	Delete HR_TangCaNgoaiLe_SK1
	where Ngay_SK1 between @fromdate and @todate and UserName = 'Auto'

	insert into HR_TangCaNgoaiLe_SK1 (Factory_ID_SK1, Ngay_SK1, Gio_SK1, InsertDate, UserName)
	select cast(OT.Factory as nvarchar(50)), OT.Ngay, OT.SoGio, OT.InsertDate, 'Auto'
	from
	HR_SNK.dbo.HR_OTPLAN OT
	left join
	HR_TangCaNgoaiLe_SK1 SK1
	on SK1.Ngay_SK1 = OT.Ngay and SK1.Factory_ID_SK1 collate SQL_Latin1_General_CP1_CI_AS = OT.Factory
	where OT.Ngay between @fromdate and @todate and SK1.Factory_ID_SK1 is null

	Delete HR_TangCaNgoaiLe_SK2
	where Ngay_SK2 between @fromdate and @todate and UserName = 'Auto'

	insert into HR_TangCaNgoaiLe_SK2 (Factory_ID_SK2, Ngay_SK2, Gio_SK2, InsertDate, UserName)
	select cast(OT.Factory as nvarchar(50)), OT.Ngay, OT.SoGio, GETDATE(), 'Auto'
	from
	HR_SNK.dbo.HR_OTPLANF2 OT
	left join
	HR_TangCaNgoaiLe_SK2 SK2
	on SK2.Ngay_SK2 = OT.Ngay and SK2.Factory_ID_SK2 collate SQL_Latin1_General_CP1_CI_AS = OT.Factory
	where OT.Ngay between @fromdate and @todate and SK2.Factory_ID_SK2 is null
end
GO
