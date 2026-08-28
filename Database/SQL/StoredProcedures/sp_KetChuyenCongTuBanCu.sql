
CREATE proc [dbo].[sp_KetChuyenCongTuBanCu]
@fromdate datetime,
@todate datetime
as
begin
--EXEC sp_KetChuyenCongTuBanCu '2026-06-01','2026-06-30'
BEGIN TRANSACTION

exec sp_ketchuyencongngoaile @fromdate, @todate

exec sp_KetChuyenDuLieuChamCong @fromdate, @todate

exec sp_KetChuyenDuLieuDangKyCa @fromdate, @todate

exec sp_KetChuyenDuLieuDangKyTangCa @fromdate, @todate

exec sp_KetChuyenDuLieuGiaDinh '2000-01-01', @todate

exec sp_KetChuyenDuLieuMangThai '2000-01-01', @todate

exec sp_KetChuyenDuLieuNghiPhep '2000-01-01', @todate

exec sp_KetChuyenTangCaNgoaiLe @fromdate, @todate

exec sp_ketchuyendulieuxinrangoai @fromdate, @todate

IF @@ERROR <> 0 
    ROLLBACK;
ELSE
    COMMIT;

	select 'ThanhCong' as ThongBao

end
GO
