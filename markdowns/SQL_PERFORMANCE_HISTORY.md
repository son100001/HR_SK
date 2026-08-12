# 📜 Lịch sử tối ưu hiệu năng SQL — riêng cho `HR_SnK_Dev_260811`

> File này **không portable** — chỉ ghi lại lịch sử/nhật ký các lần tối ưu đã thực hiện trên database
> `HR_SnK_Dev_260811` (113.161.180.44) cụ thể (ngày nào, đo được gì, có rollback không). Muốn tra cứu
> **cách sửa tổng quát áp dụng được cho DB khác**, đọc
> [SQL_PERFORMANCE_PLAYBOOK.md](SQL_PERFORMANCE_PLAYBOOK.md) thay vì file này.
>
> Playbook ở trên được port từ `Kido_New/markdowns/SQL_PERFORMANCE_PLAYBOOK.md` (database `HR_KIDO_35`,
> cùng hệ thống POCONS/SmartBooks HR) — **không copy nhật ký của Kido vào đây**, vì các thay đổi ghi
> trong `Kido_New/markdowns/SQL_PERFORMANCE_HISTORY.md` chỉ thật sự xảy ra trên `HR_KIDO_35`, chưa hề
> chạy trên DB này.

---

## Đối chiếu ban đầu (2026-08-12) — chưa áp dụng gì, chỉ khảo sát khả năng áp dụng playbook

Kết quả `SELECT compatibility_level ...` = **120**. Đối chiếu nhanh với các mục A1-A7 của playbook trên
schema thật (dùng export đầy đủ ở [`Database/SQL/`](../Database/SQL/)):

| Mục playbook | Object | Trạng thái trên `HR_SnK_Dev_260811` hôm nay | Áp dụng được không |
|---|---|---|---|
| A1 | `dbo.Split` | Vẫn là MSTVF (`WHILE` loop) — chưa sửa | ✅ Có, chưa làm |
| A2 | `dbo.SmartBooks_Employee` | Không có index nào trên `ID_number` | ✅ Có, chưa làm |
| A4 | `dbo.sp_XuLyCongKhachHangNew` | **Không tồn tại** object tên này trong DB | ❌ Cần tìm tên tương đương trước |
| A6 bước 1 | `dbo.HR_TimeKeeping_Data` | Không có index nào trên `AccessDate` | ✅ Có, chưa làm |
| A6 bước 2 | `dbo.DuLieuQuet` | Vẫn là MSTVF — chưa sửa | ✅ Có, chưa làm |
| A6 bước 3 | `dbo.udf_TinhCong` (gọi `GhepGioVaoNgay`/`udf_CompareGetMax`) | Chưa đối chiếu thân hàm chi tiết | ⏳ Cần đọc lại thân hàm trước khi áp dụng |
| A7 | `dbo.sp_XuLyPhepNam`, bảng `HR_BangPhepNam` | **Không tồn tại** tên này trong DB | ❌ Cần điều tra lại từ đầu nếu muốn tối ưu `sp_TinhCong` ở đây |

Chưa chạy bất kỳ `CREATE INDEX`/`DROP FUNCTION`/thay đổi nào lên `HR_SnK_Dev_260811` tính đến thời điểm
này — bảng trên chỉ là kết quả khảo sát, không phải nhật ký thay đổi thật.

---

## Nhật ký thay đổi thật (điền dần khi thực sự áp dụng lên `HR_SnK_Dev_260811`)

| Ngày | Object | Loại | Tóm tắt | Deploy script |
|---|---|---|---|---|
| *(chưa có)* | | | | |
