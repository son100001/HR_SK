/*
    ROLLBACK cho 2026-08-28_HR_SnK_Dev_Config_TranTangCa_300Nam_40Thang.sql
    Trả trần giờ tăng ca về đúng giá trị trước ngày 2026-08-28 trên HR_SnK_Dev:
        TangCaToiDaTheoNam   = 10000
        TangCaToiDaTheoThang = 40      (không đổi, ghi lại cho đủ)
    Chạy script này khi cần quay lui, thường là chạy kèm
    2026-08-28_HR_SnK_Dev_Rollback_sp_TinhCong_GioDaTangCaTrongNam.sql.
*/

UPDATE HR_SetUpFollowDate
   SET [Value] = N'10000', InsertDate = GETDATE(), UserName = 'admin'
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
