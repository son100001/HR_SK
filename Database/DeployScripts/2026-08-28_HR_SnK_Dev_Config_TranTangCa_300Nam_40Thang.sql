/*
    Mục đích: đặt trần giờ tăng ca về 300 giờ/năm và 40 giờ/tháng (đúng mức trần của Bộ luật Lao động
    cho ngành dệt may). Người yêu cầu xác nhận ngày 2026-08-28: "300h/năm, 40h/tháng. Không tính wt1
    và wt9 trong tổng này."
    Áp dụng cho: HR_SnK_Dev (113.161.180.44). Ngày: 2026-08-28.

    Giá trị TRƯỚC khi chạy script này trên HR_SnK_Dev:
        TangCaToiDaTheoNam   / Code 'Tu012022' = 10000   -> đổi thành 300
        TangCaToiDaTheoThang / Code 'Tu012022' = 40      -> giữ nguyên 40 (ghi lại cho chắc chắn)

    ⚠️ BẮT BUỘC DEPLOY KÈM (và deploy TRƯỚC script này):
        2026-08-28_HR_SnK_Dev_Fix_sp_TinhCong_GioDaTangCaTrongNam.sql
    Lý do: sp_TinhCong bản cũ tính "giờ đã tăng ca trong năm" bằng cách cộng wt1/wt9 (GIỜ HÀNH CHÍNH)
    trên một cửa sổ 12 tháng về phía trước. Đo trên dữ liệu thật 2026-08-28: cách cũ cho trung bình
    289,7 giờ/nhân viên và 892/1.265 nhân viên đã vượt 300 giờ. Nếu hạ trần xuống 300 mà chưa sửa thì
    892 nhân viên bị cắt sạch giờ tăng ca ngay lập tức; tính lại tháng 01/2026 thì 1.188/1.451 nhân
    viên bị cắt.
    Sau khi sửa (cộng đúng giờ tăng ca, đúng năm dương lịch): trung bình 60,1 giờ, cao nhất 107 giờ,
    KHÔNG ai vượt 300 giờ -> hạ trần an toàn, không cắt của ai.

    Ai đọc 2 tham số này:
        - dbo.sp_TinhCong             (@GioTangCaToiDaTheoNam_Goc / @GioTangCaToiDaTheoThang_Goc)
        - dbo.sp_XuLyGioDayDuLieu     (khối quy đổi giờ tăng ca đăng ký, thêm ngày 2026-08-28)

    Idempotent: chỉ UPDATE các dòng đã tồn tại, chạy lại nhiều lần cho cùng kết quả.
    Rollback: 2026-08-28_HR_SnK_Dev_Rollback_Config_TranTangCa.sql
*/

UPDATE HR_SetUpFollowDate
   SET [Value] = N'300', InsertDate = GETDATE(), UserName = 'admin'
 WHERE Group_ = 'TangCaToiDaTheoNam' AND Code = 'Tu012022';
GO

UPDATE HR_SetUpFollowDate
   SET [Value] = N'40', InsertDate = GETDATE(), UserName = 'admin'
 WHERE Group_ = 'TangCaToiDaTheoThang' AND Code = 'Tu012022';
GO

SELECT Group_, Code, [Value], Fromdate, Todate
FROM HR_SetUpFollowDate
WHERE Group_ IN ('TangCaToiDaTheoNam','TangCaToiDaTheoThang')
ORDER BY Group_;
GO
