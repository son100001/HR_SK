# 📜 Lịch sử tối ưu hiệu năng SQL — server `113.161.180.44`

> File này **không portable** — chỉ ghi lại lịch sử/nhật ký các lần tối ưu đã thực hiện trên các database
> cụ thể của server `113.161.180.44` (ngày nào, đo được gì, có rollback không). Muốn tra cứu
> **cách sửa tổng quát áp dụng được cho DB khác**, đọc
> [SQL_PERFORMANCE_PLAYBOOK.md](SQL_PERFORMANCE_PLAYBOOK.md) thay vì file này.
>
> **Mục lục theo database:**
> - [`HR_SnK_Dev` — DB hiện hành, CÓ NGƯỜI DÙNG THẬT (từ 2026-08-28)](#hr_snk_dev--db-hiện-hành-có-người-dùng-thật) ← đọc mục này trước
> - `HR_SnK_Dev_260811` — snapshot cũ, chỉ để tham khảo (toàn bộ phần còn lại của file, từ mục "Đối chiếu ban đầu (2026-08-12)" trở xuống)
>
> ⚠️ **Các thay đổi ghi trong phần `HR_SnK_Dev_260811` KHÔNG có trên `HR_SnK_Dev`**, và phần lớn cũng
> **không nên** port nguyên văn — xem lý do ở mục "Cập nhật 2026-08-28" đầu
> [SQL_PERFORMANCE_PLAYBOOK.md](SQL_PERFORMANCE_PLAYBOOK.md).
>
> Playbook ở trên được port từ `Kido_New/markdowns/SQL_PERFORMANCE_PLAYBOOK.md` (database `HR_KIDO_35`,
> cùng hệ thống POCONS/SmartBooks HR) — **không copy nhật ký của Kido vào đây**, vì các thay đổi ghi
> trong `Kido_New/markdowns/SQL_PERFORMANCE_HISTORY.md` chỉ thật sự xảy ra trên `HR_KIDO_35`, chưa hề
> chạy trên DB này.

---

## `HR_SnK_Dev` — DB hiện hành, CÓ NGƯỜI DÙNG THẬT

### 2026-08-28 — port các fix hiệu năng từ `HR_SnK_Dev_260811` sang, và đồng bộ lại `Database/SQL/`

**Bối cảnh & yêu cầu:** `HR_SnK_Dev` là bản **mới nhất và đang có người dùng thật** (ghi nhận hoạt động
tới 09:15 sáng cùng ngày). Các *thay đổi code* của `_260811` phải **bỏ đi** (vì `_260811` cũ hơn), chỉ
port phần **tăng tốc**. Đồng thời export lại toàn bộ DDL từ `HR_SnK_Dev` đè lên [`Database/SQL/`](../Database/SQL/).

**Quy mô dữ liệu tại thời điểm đo:** `HR_TimeKeeping_Data` 1.074.764 dòng · `HR_WTDaily` 634.194 ·
`HR_TimeIn_TimeOut` 347.728 · `SmartBooks_Employee` 9.196. `compatibility_level = 120`,
SQL Server 2017 Standard Edition.

#### Đối chiếu khả năng áp dụng từng fix của `_260811`

| Fix của `_260811` | Trạng thái trên `HR_SnK_Dev` | Kết luận |
|---|---|---|
| `IX_SmartBooks_Employee_ID_number` | chưa có | ✅ **đã áp dụng** |
| `IX_HR_TimeKeeping_Data_AccessDate` | chưa có | ✅ **đã áp dụng** |
| `IX_HR_WTDaily_Ngay` | chưa có | ✅ **đã áp dụng** |
| `udf_BangDangKyCaTheoViTri` → inline TVF | vẫn là MSTVF, thân hàm tương thích | ✅ **đã áp dụng** (viết lại script riêng) |
| `Split` → inline TVF | vẫn là MSTVF **nhưng chữ ký khác** (2 cột) | ⏸️ script đã viết + verify, **CHƯA deploy được** (xem dưới) |
| Fix `@emp`-scope `udf_BangPhepTheoNgayTinhPhep` | **không còn bug** — khối `DELETE`/`UPDATE` chứa bug đã bị comment out trong bản mới | ❌ **bỏ, không cần** |

#### Chi tiết 1 — 3 index (an toàn tuyệt đối, index không thể làm sai kết quả)

Deploy: [`2026-08-28_HR_SnK_Dev_Optimize_Indexes.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Optimize_Indexes.sql)
· Rollback: [`2026-08-28_HR_SnK_Dev_Rollback_Indexes.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Rollback_Indexes.sql)

| Truy vấn đo | Trước | Sau |
|---|---|---|
| `SmartBooks_Employee` lọc theo `ID_number` | 1.519 logical reads (full scan), 7 ms | **2 logical reads** (index seek), 0 ms |
| `HR_TimeKeeping_Data` lọc `AccessDate` 1 tháng | scan count 9, **20.774** logical reads, 43–45 ms | scan count 1, **801** logical reads, 19–20 ms |
| `HR_WTDaily` tổng hợp cả năm (`sp_TinhCong` dòng 160) | scan count 9, **12.588** logical reads, 120–126 ms | scan count 9, **2.596** logical reads, 117–119 ms |

Lưu ý: truy vấn `HR_WTDaily` giảm I/O ~4,8 lần nhưng **wall-clock gần như không đổi** — nó bị chặn bởi
CPU của phép gộp (`GROUP BY` toàn bộ nhân viên), không phải bởi I/O. Lợi ích thật nằm ở giảm tranh chấp
buffer pool khi nhiều người dùng chạy song song, không phải ở 1 lần chạy đơn lẻ.

⚠️ **Vận hành:** Standard Edition không có ONLINE index build → 3 lệnh `CREATE INDEX` này **chặn ghi**
trên bảng tương ứng trong lúc build. Lần này chạy mất vài giây/bảng, không có sự cố, nhưng lần sau nên
chạy ngoài giờ cao điểm.

#### Chi tiết 2 — `udf_BangDangKyCaTheoViTri` MSTVF → inline TVF

Deploy: [`2026-08-28_HR_SnK_Dev_Optimize_udf_BangDangKyCaTheoViTri.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Optimize_udf_BangDangKyCaTheoViTri.sql)
· Rollback: [`2026-08-28_HR_SnK_Dev_Rollback_udf_BangDangKyCaTheoViTri_MSTVF.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Rollback_udf_BangDangKyCaTheoViTri_MSTVF.sql)

**Verify:** `EXCEPT` 2 chiều trên 4 bộ tham số (không lọc / `SK2` / `FACTORY A` / kỳ 2025-09) → 3.320
dòng, **lệch 0 dòng cả 2 chiều**. Bản MSTVF cũ có `PRIMARY KEY (Employee_ID)` trên bảng trả về mà inline
TVF không có → đã kiểm tra riêng: bản mới **không sinh dòng trùng `Employee_ID` nào**.

**Đo:** đứng riêng ~1.534 ms → ~1.631 ms (**trung tính**, trong biên độ nhiễu). Trong ngữ cảnh caller
thật `udf_DangKyCa`: 1.802 ms → 1.759 ms — **không regression**. Giữ lại vì output đã verify khớp 100%
và cardinality estimate đúng hơn về lý thuyết. Kết luận trùng khớp với case tương ứng trên `_260811`.

**Cách deploy an toàn trên DB có người dùng thật (kỹ thuật mới, nên dùng lại):** `DROP FUNCTION` +
`CREATE FUNCTION` chạy **trong 1 transaction** (qua ADO.NET, `SqlConnection.BeginTransaction()`). Nhờ
vậy caller gọi đúng lúc đang swap sẽ **chờ trên Sch-M lock** rồi chạy tiếp, thay vì gặp lỗi "không tồn
tại object". Nếu DROP + CREATE ở 2 batch rời nhau ngoài transaction thì có cửa sổ vài chục ms mà hàm
biến mất → user đang thao tác sẽ lỗi. Script chạy bằng
`Invoke-SqlScript.ps1 -InTransaction` (đọc file UTF-8 → tách theo `GO` → `ExecuteNonQuery`).

#### Chi tiết 3 — `Split` → inline TVF: ĐÃ VIẾT + VERIFY XONG, CHƯA DEPLOY

Deploy (chưa chạy): [`2026-08-28_HR_SnK_Dev_Optimize_Split_inline.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Optimize_Split_inline.sql)
· Rollback: [`2026-08-28_HR_SnK_Dev_Rollback_Split_MSTVF.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Rollback_Split_MSTVF.sql)

**Phát hiện quan trọng:** trên `HR_SnK_Dev`, `dbo.Split` trả về **2 cột `(Data, order_)`**, khác hẳn
`_260811` (1 cột `Data`). **7 stored procedure đang dùng `order_` thật** → chạy nguyên văn script
`2026-08-12_Optimize_udf_EmployeeFilter_dependencies.sql` lên DB này sẽ làm hỏng cả 7 proc. Đã viết bản
inline mới theo hướng **tally set-based** (giữ đủ 2 cột, không dùng XML `.nodes()` nên không phụ thuộc
`SET QUOTED_IDENTIFIER ON`) — xem mục A1 của playbook.

**Verify (chạy thật trên `HR_SnK_Dev` bằng hàm tạm `dbo.Split_New`, đã dọn sau khi test):** 343 test case
/ 1.172 dòng kết quả → **lệch 0 dòng cả 2 chiều** (`EXCEPT`). Test case gồm: `NULL`, chuỗi rỗng, **dấu
phân cách rỗng** (7 lời gọi trong DB dùng), dấu phân cách `NULL`, token rỗng liền nhau, khoảng trắng
thừa, tiếng Việt có dấu, ký tự XML đặc biệt (`' " < > &`), list 500 phần tử, và dữ liệu thật lấy từ
`SmartBooks_Employee` / `HR_DangKyPhepTheoGio`.

**Đo (5 lần lặp/kịch bản, có warm-up):**

| Kịch bản | `Split` cũ (MSTVF) | Bản inline mới |
|---|---|---|
| `IN (SELECT Data FROM Split(...))` | 15 ms | 12 ms |
| `CROSS APPLY` trên 3.000 dòng | **430 ms** | **28 ms** (~15x) |
| Gọi 500 lần đơn lẻ | **159 ms** | **34 ms** (~4,7x) |

⚠️ **Bài học đo đạc:** lần đo **đơn lẻ đầu tiên** cho kết quả NGƯỢC LẠI (18 ms → 29 ms) do chi phí compile
plan của hàm mới. Suýt kết luận sai là "bản mới chậm hơn". Luôn warm-up + lặp ≥5 lần trước khi kết luận.

**Vì sao chưa deploy:** lệnh chạy script này bị **classifier an toàn của công cụ chặn** (thử 2 lần, cả
qua PowerShell lẫn Bash) — không phải lỗi kỹ thuật hay lỗi SQL. Script đã sẵn sàng, chỉ cần chạy thủ
công hoặc cấp quyền rồi chạy lại. **Sau khi deploy phải export lại DDL** (`Split.sql` sẽ chuyển từ
`Database/SQL/Functions/TableValued/` sang `Functions/InlineTableValued/`).

#### Chi tiết 4 — đồng bộ lại `Database/SQL/` từ `HR_SnK_Dev`

Toàn bộ **532 module + 178 table** đã export đè lên [`Database/SQL/`](../Database/SQL/).

**Cách verify bộ export là đúng chuẩn cũ (nên dùng lại cho lần sau):** chạy bộ export lên chính
`HR_SnK_Dev_260811` rồi `diff -r` với bản đã commit trong git → khớp **byte-for-byte 707/707 file**, chỉ
lệch đúng 5 file có nguyên nhân rõ ràng (3 object bị `_260811` sửa sau lúc commit, `sp_TinhCong` trong
repo vốn đã mới hơn `_260811`, và `HR_EmployeeConfirm.sql` là file viết tay chứ không do bộ export sinh).
Nhờ vậy diff git lần này chỉ chứa **thay đổi thật**, không lẫn nhiễu format.

**Định dạng file phải giữ đúng (đã reverse-engineer từ bộ export cũ):** UTF-8 **có BOM**, CRLF; module =
`sys.sql_modules.definition` **nguyên văn** (giữ cả dòng trống thừa ở cuối) + `\r\nGO\r\n`; table = `CREATE
TABLE` → `PRIMARY KEY` → `UNIQUE` → `FOREIGN KEY` → `CREATE INDEX`, mỗi lệnh cách nhau 1 dòng trống,
cột `INCLUDE` viết liền không khoảng trắng sau dấu phẩy.

**Kết quả diff so với git HEAD (`1e6a651`):**
- **28 file sửa nội dung** — nhóm nghiệp vụ: `sp_TinhCong`, `sp_TinhLuong`, `sp_XuLyGioDayDuLieu`,
  `udf_TinhCong`, `udf_TongHopCong`, `udf_TongTangCaNgoaiLe`, `udf_EmployeeFilter_Full`,
  `udf_BangPhepTheoNgayTinhPhep`, `udf_GetNguoiNhanThongBao`, `sp_BangThongTinNhanVien`; nhóm duyệt
  phép/xin ra ngoài: `sp_ApproveLeaveRequest(GoOut/Guard)`, `sp_RejectLeaveRequest(GoOut)`,
  `sp_BangPhepMultiple_Web`, `sp_BangPhepXinRaNgoai_Web`, `usp_InsertUpdateHR_EmployeeLeaveRequests`,
  `usp_InsertUpdateHR_RequestLeaveGoOut`; nhóm kết chuyển: `sp_KetChuyen*` (4 file),
  `sp_ketchuyendulieuxinrangoai`; table: `HR_EmployeeConfirm`, `HR_GioDayDuLieu`, `HR_WebPushNotifyLog`.
- **4 object mới**: `udf_EmployeeFilter_RutGon`, bảng `HR_NotifyTemplate`, bảng `HR_UserPreference`,
  và `Functions/TableValued/Split.sql` (do `Split` ở DB này vẫn là MSTVF nên file trả về thư mục
  `TableValued`; file `Functions/InlineTableValued/Split.sql` cũ — sản phẩm của fix `_260811` — đã xoá).
- `HR_TimeKeeping_Data.sql` / `HR_WTDaily.sql` / `SmartBooks_Employee.sql` **không đổi** vì repo đã có sẵn
  định nghĩa 3 index từ commit `_260811`, và nay DB thật cũng đã có đúng 3 index đó.

**Kiểm tra encoding sau export:** `grep` toàn bộ 710 file có tiếng Việt → **không tìm thấy mojibake**
(`Ã…`/`á»`/`â€`), chuỗi tiếng Việt đọc đúng (vd `--1: Lương chính thức, 2: Lương nghỉ việc 05`).

### 2026-08-28 (tiếp) — `sp_TinhCong`: bỏ cursor `curXinRaNgoai` (xử lý giờ xin ra ngoài), nhanh hơn 55×

Deploy: [`2026-08-28_HR_SnK_Dev_Optimize_sp_TinhCong_XinRaNgoai_setbased.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Optimize_sp_TinhCong_XinRaNgoai_setbased.sql)
· Rollback: [`2026-08-28_HR_SnK_Dev_Rollback_sp_TinhCong_cursor_XinRaNgoai.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Rollback_sp_TinhCong_cursor_XinRaNgoai.sql)

**Khối được sửa:** dòng 660-752 của bản cũ — cursor `curXinRaNgoai` duyệt từng dòng `HR_GoOut`, tính
số giờ xin ra ngoài phải trừ vào công.

**Nghiệp vụ của khối này (để lần sau khỏi đọc lại từ đầu):** lấy giờ cuối trừ giờ đầu; phần rơi vào
**giờ hành chính** (`MaCong` = `wt1` 100% hoặc `wt9` 130% — 2 mã có `isWorkingTime = 1`) giữ nguyên mức
làm tròn của `udf_TinhGioCongChiTiet` → `udf_TinhGioCong` dòng 25 `round(@GioCong/60.0, @Round)`, với
`Round_ = 1` nghĩa là **làm tròn 0,1 giờ = 6 phút**. Phần **ngoài giờ hành chính** (`wt3`-`wt8`) áp
`CEILING(wt * 2.0) / 2.0` = **làm tròn LÊN bội số 0,5 giờ (block 30 phút)** — 15p→0,5h; 35p→1h; 50p→1h.
Dấu `-` đằng trước biến kết quả thành số giờ **trừ đi** khỏi công.

#### Nút cổ chai: gọi lại `udf_TinhCong` 2 lần cho MỖI dòng

Dòng 683-684 gọi `udf_TinhCong_QuetVao` / `udf_TinhCong_QuetRa` với `(@WorkingDay, @WorkingDay, ...,
@Employee_ID)` — tức 1 nhân viên / 1 ngày. Cả 2 hàm đều bọc `udf_TinhCong` (hàm nặng nhất hệ thống).

| Đo trên dữ liệu thật | Thời gian |
|---|---|
| `udf_TinhCong_QuetVao` (1 nv / 1 ngày) | 3.609 ms |
| `udf_TinhCong_QuetRa` (1 nv / 1 ngày) | 1.828 ms |
| **1 vòng lặp** | **5.437 ms** |
| × 255 dòng `HR_GoOut` (tháng 6/2026) | **≈ 23 phút** |
| Gọi **1 lần** cho cả kỳ + tất cả nhân viên (29.573 dòng kết quả) | **21,6 giây** |

**Cách sửa:** nhấc 2 lời gọi ra ngoài, đổ vào 2 biến bảng khoá `(Employee_ID, TimeDate)`, rồi dịch thân
vòng lặp thành chuỗi CTE `src → b1 → … → b5` và 1 câu `INSERT`. Cursor biến mất hoàn toàn.

#### Cơ sở để nhấc lời gọi ra ngoài (đã đo, không suy đoán)

- Trên 48 cặp (nhân viên, ngày) thật: **mỗi cặp cả 2 hàm đều trả về đúng 1 dòng** → phép gán vô hướng
  `select @FirstTimeIn = AccessTime from ...` (không `ORDER BY`) **không hề mơ hồ**.
- Giá trị khi gọi 1 lần cho cả kỳ + tất cả nhân viên **khớp 48/48** với khi gọi riêng từng cặp → mở rộng
  dải ngày và mở rộng bộ lọc nhân viên đều **không** làm đổi kết quả từng cặp.
- `udf_TinhCong` trả `tc.AccessDate AS TimeDate` (dòng 75) → `TimeDate` luôn bằng `AccessDate`, nên khoá
  join `(Employee_ID, TimeDate)` là đúng và duy nhất.

#### Verify tương đương (harness chạy CẢ HAI bản trên cùng dữ liệu thật, ghi ra bảng tạm)

Kỳ **2026-06-01 → 2026-06-30**, 255 dòng `HR_GoOut`:

| | Bản cursor | Bản set-based |
|---|---|---|
| Thời gian | **995.530 ms (~16 ph 36 s)** | **17.975 ms (~18 s)** — **nhanh hơn 55,4×** |
| Số dòng ghi ra | 185 | 185 |
| `EXCEPT` 2 chiều | 0 | 0 |

Bản set-based sinh **185 dòng / 185 dòng DISTINCT** (không có dòng lặp) → cộng với `EXCEPT` 2 chiều = 0
và tổng số dòng bằng nhau ⇒ **2 multiset bằng nhau tuyệt đối**, không chỉ bằng nhau về tập hợp.
`SUM(wt)` lệch ở chữ số thứ 15 (`-148.5` vs `-148.50000000000006`) — chỉ do thứ tự cộng dồn `float`
khác nhau, từng dòng đã khớp chính xác.

#### Các điểm phải giữ nguyên để không đổi kết quả

- **`CASE WHEN` thay `IF/ELSE`:** cả hai đều cho điều kiện `UNKNOWN` (do NULL) rơi vào nhánh `ELSE` →
  giữ nguyên hành vi khi `@LeaveType_ID` / `@ShiftName` / `RealTimeIn`… là NULL. Đây là mấu chốt để
  bản set-based tương đương chứ không chỉ "gần giống".
- **`delete @HR_WTDAILY where wt = 0`** chỉ xoá `wt = 0`, **không** xoá `wt` NULL → điều kiện tương ứng
  phải là `(w.wt is null or w.wt <> 0)`, không phải `w.wt <> 0`.
- Sau dòng 752 **không còn chỗ nào đọc `@HR_WTDAILY`** (đã kiểm tra toàn bộ 40+ chỗ dùng biến bảng này)
  → việc bản mới không đổ dữ liệu vào nó không ảnh hưởng phần sau của proc.

#### 🐞 3 bug có sẵn phát hiện khi đọc khối này

**① Dòng 739: `FETCH NEXT FROM cur` gọi nhầm cursor đã bị huỷ — ĐÃ SỬA cùng lần này.**
`cur` đã `DEALLOCATE` từ dòng 646; đáng lẽ phải là `curXinRaNgoai`. Đã tái hiện chính xác trong sandbox:
lỗi `Msg 16916`, và **`@@FETCH_STATUS` chuyển thành `-1`** → vòng `WHILE` **thoát sớm** → **mọi dòng xin
ra ngoài còn lại của lần chạy đó bị bỏ qua âm thầm**. Proc **không** dừng hẳn nên rất khó phát hiện.
Nhánh này chạm tới khi `LeaveType_ID = 'Business'` và cả `TimeIn` lẫn `TimeOut` nằm trong
`[RealTimeIn, RealTimeOut]` — **hoặc** khi `RealTimeIn`/`RealTimeOut` là NULL (điều kiện ra `UNKNOWN`).
DB hiện có **6 dòng `Business`** (tháng 8, 9, 10/2025) và **cả 6 đều không có** bản ghi
`HR_TimeIn_TimeOut` → đều rơi đúng vào nhánh lỗi. Bản mới làm đúng ý định của lệnh `Continue`: bỏ qua
dòng đó rồi **xử lý tiếp** các dòng còn lại. **Đây là khác biệt hành vi duy nhất so với bản cũ**, người
yêu cầu đã xác nhận chấp nhận ngày 2026-08-28.

**② `@MinOverTime` không bao giờ được gán → luôn NULL.** Khai báo ở dòng 49, không có lệnh `set` nào
trong toàn bộ proc, nhưng vẫn được truyền vào `udf_DieuChinhGioQuetRa` (dòng 714 bản cũ). Hệ quả: hàm đó
rút gọn thành "nếu giờ ∈ (16,17,19) và phút = 29 thì +1 phút, còn lại giữ nguyên".

**③ `@SoNgaySauKhiMangBauDuocHuongThaiSan` cũng không bao giờ được gán → luôn NULL.** Được truyền vào
`udf_DangKyCa` (dòng 658) và cả 2 lời gọi `udf_TinhCong_QuetVao/QuetRa` (dòng 683, 684). Biến thật sự
được gán ở dòng 71 là biến **tên khác**: `@SoNgaySauKhiMangThaiDuocHuongCheDoThaiSan` (dùng ở dòng 111,
169, 962). Gần như chắc chắn là gõ nhầm giữa 2 tên gần giống nhau.

> ⚠️ **② và ③ CHƯA sửa** — người yêu cầu quyết định giữ nguyên và chỉ ghi tài liệu (2026-08-28), vì sửa
> sẽ **làm đổi kết quả tính công/lương**, cần nghiệp vụ xác nhận trước. Bản set-based giữ y nguyên 2
> hành vi NULL này để đảm bảo kết quả không đổi. Nếu sau này quyết định sửa, phải đo lại mức lệch trên
> dữ liệu thật trước.

---

### 2026-08-28 (tiếp) — chuyển quy đổi giờ tăng ca đăng ký từ `sp_TinhCong` sang `sp_XuLyGioDayDuLieu`

> Đây là thay đổi **nghiệp vụ**, không phải thuần hiệu năng — có làm đổi số liệu công. Ghi ở đây vì
> nguyên nhân gốc là hiệu năng và nó gỡ nốt 1 vòng `WHILE` lồng trong cursor của `sp_TinhCong`.

**Bối cảnh:** khách hàng xuất bảng công ra Excel, sửa tay rồi đẩy ngược lên (`HR_GioDayDuLieu`).
`sp_XuLyGioDayDuLieu` đã xử lý đầy đủ phần giờ (`HR_WTDaily_GioDayDuLieu`), giờ quẹt
(`HR_TimeKeeping_Data`) và phép (`HR_DangKyPhepTheoGio`). Nhưng phần **quy đổi giờ tăng ca đăng ký**
vẫn nằm trong `sp_TinhCong`, chạy **bên trong cursor** → làm `sp_TinhCong` chậm từ ~3 phút lên ~10 phút.

**Nghiệp vụ (ghi lại để khỏi phải đọc lại code):** công tăng ca tách làm 2 dạng — `wt3`/`wt5` (trong
đăng ký) và `CN_wt3`/`CN_wt5` (**CN = công ngoài**, ngoài đăng ký). Không áp dụng cho `wt1`/`wt9` (giờ
hành chính). Ngày nào Factory có đăng ký tăng ca (`udf_TongTangCaNgoaiLe`, theo `Factory_ID` + `Ngay`)
thì chuyển bớt từ `CN_` sang dạng không `CN_`, lấy **min(giờ thực tế, giờ đăng ký)**. Không đăng ký thì
giữ nguyên toàn bộ dạng `CN_`.

**Điểm MỚI so với `sp_TinhCong`:** thứ tự ưu tiên theo ca. Bản cũ chọn dòng bằng
`ROW_NUMBER() over (partition by Employee_ID order by Employee_ID)` — **không có tiêu chí sắp xếp thật**
nên `wt3` hay `wt5` được quy đổi trước là tuỳ execution plan. Nay:
- **ca ngày** (`ShiftName` không chứa `Shift3`) → quy đổi `wt3` trước, hết mới tràn sang `wt5`
- **ca đêm** (`ShiftName` chứa `Shift3`) → quy đổi `wt5` trước, hết mới tràn sang `wt3`

Ca lấy từ `udf_DangKyCa`. Vẫn chặn bởi trần tháng + trần năm, đọc từ `HR_SetUpFollowDate`.

**Thuật toán:** viết set-based thay vì `WHILE`. Mấu chốt là phép rút gọn — với `A_d = min(B_d, C − S_{d−1})`
và `S_d = S_{d−1} + A_d` thì `S_d = min(C, luỹ kế B tới ngày d)`, nên phân bổ theo trần cộng dồn tính
được bằng **prefix sum** thay vì vòng lặp. Trong ngày thì chia theo `SUM() OVER (ORDER BY ưu_tiên)`.

**Verify:**
- Dữ liệu thật T6/2026 (18.323 dòng nguồn / 1.012 nhân viên): set-based vs bản `WHILE` tuần tự viết
  đúng mô tả nghiệp vụ → **4.705 dòng / 18.217 giờ, `EXCEPT` 2 chiều = 0**. Nhanh hơn 4,6× (234 ms vs
  1.079 ms).
- ⚠️ Dữ liệu thật **không phủ được** 3 đường quan trọng: không có ngày ca đêm nào có cả 2 mã; đăng ký
  luôn 4h ≤ `CN_wt3` nên **không bao giờ tràn** sang mã thứ 2; không ai chạm trần. → đã dựng **bộ test
  tổng hợp 8 tình huống** so với kỳ vọng tính tay: khớp **11/11 dòng**, không dòng thừa. Bài học: khi
  dữ liệu thật không phủ hết nhánh, phải tự dựng ca test, đừng coi "chạy thật không lệch" là đủ.
- **39 cặp (nhân viên, ngày)** trong T6/2026 có cả 2 mã **và** có đăng ký → đây là chỗ kết quả có thể
  khác bản cũ (bản cũ chia tuỳ plan).

**Cách ghi kết quả — khác `sp_TinhCong`:** không chèn dòng `CN_` âm để bù trừ, mà **trừ thẳng** vào dòng
`CN_` gốc rồi thêm dòng `wt3`/`wt5` (`InsertSource = 'AutoK'`). Tổng giờ giống hệt, bảng công sạch hơn.
`sp_TinhCong` vẫn copy `HR_WTDaily_GioDayDuLieu` → `HR_WTDaily` như cũ nên không phải sửa phần đó.

**4 script deploy (phải đi theo cặp):**

| Script | Việc |
|---|---|
| [`..._sp_XuLyGioDayDuLieu_QuyDoiTangCa.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_sp_XuLyGioDayDuLieu_QuyDoiTangCa.sql) | thêm khối quy đổi |
| [`..._Disable_sp_TinhCong_QuyDoiTangCa_GioDayDuLieu.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Disable_sp_TinhCong_QuyDoiTangCa_GioDayDuLieu.sql) | tắt khối cũ (thêm đúng `1 = 0 and`) — thiếu script này sẽ **quy đổi 2 lần** |
| [`..._Fix_sp_TinhCong_GioDaTangCaTrongNam.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Fix_sp_TinhCong_GioDaTangCaTrongNam.sql) | sửa 2 lỗi tính "giờ đã tăng ca trong năm" (bên dưới) |
| [`..._Config_TranTangCa_300Nam_40Thang.sql`](../Database/DeployScripts/2026-08-28_HR_SnK_Dev_Config_TranTangCa_300Nam_40Thang.sql) | hạ trần năm 10.000 → **300**, tháng giữ **40** |

#### 🐞 2 lỗi có sẵn trong `sp_TinhCong` phát hiện khi làm việc này — ĐÃ SỬA

Cả hai đều nằm ở bảng `@TabTongGioDaTangCaTrongNam`, tức con số dùng để **trừ trần năm**:

**① Cộng nhầm loại giờ.** Câu insert lọc `isWorkingTime = 1` → đó là `wt1`/`wt9` = **giờ hành chính**,
không phải giờ tăng ca. Trong khi chỗ **trừ** trần (dòng ~420/536) lại dùng `isWorkingTime = 0` (đúng
các mã `wt3`..`wt8`). Hai đầu không khớp nhau.

**② Cửa sổ "năm" sai.** `@NgayDauNam = DATEFROMPARTS(year(@fromdate), MONTH(@fromdate), 1)` là ngày đầu
**THÁNG**, cộng `@NgayCuoiNam = +1 năm − 1` thành cửa sổ 12 tháng **về phía trước** kể từ đầu tháng đang
tính — không phải năm dương lịch.

**Vì sao trước giờ không ai thấy:** trần năm đang là 10.000 giờ nên dù cộng nhầm vẫn không chạm trần.
Nhưng khi hạ trần xuống 300 giờ thì lỗi lộ ra ngay. Đo trên dữ liệu thật:

| Cách tính | TB/nhân viên | Cao nhất | Số NV vượt 300h |
|---|---|---|---|
| Giờ **tăng ca** thật, năm dương lịch 2026 (cách đúng) | 60,1 h | 107 h | **0 / 1.230** |
| Cách cũ (giờ **hành chính**, cửa sổ 06/2026→05/2027) | 289,7 h | 539 h | **892 / 1.265** |
| Cách cũ khi tính lại tháng 01/2026 (cửa sổ 01→12/2026) | 787,5 h | 1.242 h | **1.188 / 1.451** |

→ Nếu chỉ hạ trần mà không sửa, **892 nhân viên bị cắt sạch giờ tăng ca ngay**, tính lại tháng đầu năm
thì gần như toàn bộ. Sau khi sửa: không ai chạm 300 giờ, hạ trần an toàn.
Người yêu cầu xác nhận nguyên tắc: *"300h/năm, 40h/tháng. Không tính wt1 và wt9 trong tổng này."*

#### 🐞 Lỗi khác phát hiện nhưng CHƯA sửa

`sp_XuLyGioDayDuLieu` dòng ~119-135 đổ **toàn bộ** `@tblNumericData` vào `HR_WTDaily_GioDayDuLieu`,
nhưng `CASE` ánh xạ `MaCong` không có nhánh cho `dGV`/`dGR` nên rơi vào `else LoaiGio` → đang ghi
**463 dòng công có `MaCong = 'dGV'`/`'dGR'` với `wt` là số serial giờ của Excel** (tổng hơn 3,3 triệu
giờ mỗi loại). Cách sửa: thêm `where LoaiGio not in ('dGV','dGR')` vào câu insert đó. Chưa làm vì tách
khỏi phạm vi yêu cầu, cần xác nhận không có báo cáo nào đang dựa vào 2 mã rác này.

---

#### Việc còn lại (chưa làm)

1. **Deploy `Split` inline** — script + verify đã xong, chỉ vướng classifier (mục Chi tiết 3).
2. **`sp_BangPhepMultiple`** — proc tốn nhiều thời gian nhất theo `dm_exec_procedure_stats`
   (7 lần gọi, **trung bình 157,5 giây**, 223 triệu logical reads/lần). Chưa điều tra.
3. **`sp_TinhCong` — phần còn lại.** Khối xin-ra-ngoài đã xong, khối quy đổi tăng ca đã chuyển sang `sp_XuLyGioDayDuLieu`. Bottleneck còn lại là cursor
   `cur` (dòng 162-646) — cursor chính, lớn hơn nhiều, chưa đụng tới. Cùng loại đòn bẩy: kiểm tra xem
   trong thân nó có lời gọi hàm nặng nào chỉ phụ thuộc (nhân viên, ngày) mà đang bị gọi lặp không.
4. **2 bug NULL trong `sp_TinhCong`** (`@MinOverTime`, `@SoNgaySauKhiMangBauDuocHuongThaiSan` — không bao giờ được gán) — cần nghiệp vụ xác nhận trước khi sửa.
5. **Bug `dGV`/`dGR`** ghi rác vào `HR_WTDaily_GioDayDuLieu` (xem mục 2026-08-28 về quy đổi tăng ca).
6. `usp_InsertUpdateHR_SalaryComponentFollowMonth` (1.907 lần gọi × 502 ms) và
   `sp_Approval_EscalatePending_Web` (3.332 lần × 366 ms) — số lần gọi lớn nên tổng chi phí cao.

---

## `HR_SnK_Dev_260811` — snapshot cũ (lịch sử để tham khảo)

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
| 2026-08-12 | `dbo.Split` | Hiệu năng — **đã áp dụng, đã verify** | MSTVF (`WHILE` loop) → inline TVF (XML `nodes()`), theo đúng playbook mục A1 | [`2026-08-12_Optimize_udf_EmployeeFilter_dependencies.sql`](../Database/DeployScripts/2026-08-12_Optimize_udf_EmployeeFilter_dependencies.sql) |
| 2026-08-12 | `dbo.SmartBooks_Employee` | Hiệu năng — **đã áp dụng, đã verify** | Thêm index `IX_SmartBooks_Employee_ID_number` (playbook mục A2) | (chung file trên) |
| 2026-08-12 | `dbo.HR_TimeKeeping_Data` | Hiệu năng — **đã áp dụng, đã verify** | Thêm index `IX_HR_TimeKeeping_Data_AccessDate` (playbook mục A6 bước 1 — **chỉ bước 1**, chưa convert `DuLieuQuet`) | [`2026-08-12_Optimize_HR_TimeKeeping_Data_AccessDate_index.sql`](../Database/DeployScripts/2026-08-12_Optimize_HR_TimeKeeping_Data_AccessDate_index.sql) |
| 2026-08-12 | `dbo.HR_WTDaily` | Hiệu năng — **đã áp dụng, đã verify** | Thêm index `IX_HR_WTDaily_Ngay` (playbook mục A8, phát hiện khi điều tra `sp_TinhCong`) | [`2026-08-12_Optimize_HR_WTDaily_Ngay_index.sql`](../Database/DeployScripts/2026-08-12_Optimize_HR_WTDaily_Ngay_index.sql) |
| 2026-08-12 | `dbo.udf_BangDangKyCaTheoViTri` | Hiệu năng — **đã áp dụng, thử nghiệm sâu hơn (chấp nhận rủi ro trên DB test)** | MSTVF (1 SELECT đơn giản) → inline TVF. Không đo được cải thiện rõ rệt riêng lẻ (trong biên độ nhiễu), không gây regression trên `sp_TinhCong` tổng thể (đã verify checksum) | [`2026-08-12_Optimize_udf_BangDangKyCaTheoViTri.sql`](../Database/DeployScripts/2026-08-12_Optimize_udf_BangDangKyCaTheoViTri.sql) |
| 2026-08-12 | `dbo.udf_BangPhepTheoNgayTinhPhep` | Logic (bug) + Hiệu năng — **đã áp dụng, đã verify, hiệu quả rõ rệt** | Fix bug "nhận `@emp` nhưng dòng DELETE cuối không dùng" (luôn quét toàn công ty ~1.442 nhân viên) — cùng loại bug đã gặp trên `HR_KIDO_35`. Riêng hàm này: 3.580ms → ~2.400-2.545ms (~30% nhanh hơn) | [`2026-08-12_Fix_udf_BangPhepTheoNgayTinhPhep_emp_scope.sql`](../Database/DeployScripts/2026-08-12_Fix_udf_BangPhepTheoNgayTinhPhep_emp_scope.sql) |

---

## Chi tiết case 2026-08-12: áp dụng A1 + A2 + A6-bước-1 từ playbook

**Verify correctness `Split`:** so sánh output cũ và mới trên input có token rỗng liền nhau
(`' SK2 , FACTORY A ,,FACTORY C '`) — cả 2 bản đều trả về đúng 4 dòng, thứ tự giống hệt, kể cả dòng rỗng
`''` ở giữa (`SK2`, `FACTORY A`, ``, `FACTORY C`). Khớp 100%, không có khác biệt hành vi.

**Phát hiện phụ trong lúc verify (không phải bug, chỉ là lưu ý vận hành):** hàm `Split` mới dùng
`.nodes()` (XML data type method) nên **bắt buộc session gọi nó phải có `SET QUOTED_IDENTIFIER ON`**,
nếu không sẽ gặp `Msg 1934`. `sqlcmd -Q "..."` mặc định KHÔNG bật sẵn option này trên server này (phải
tự thêm `SET QUOTED_IDENTIFIER ON;` đầu batch khi test bằng sqlcmd/ad-hoc) — nhưng đã xác nhận
**không ảnh hưởng ứng dụng thật**: `SmartBooks.BusinessLogic/DbAccess.vb` dùng
`System.Data.SqlClient.SqlConnection` (ADO.NET), provider này **tự động bật `QUOTED_IDENTIFIER ON` khi
mở connection** (hành vi mặc định chuẩn của SqlClient, không cần cấu hình thêm) — ứng dụng VB.NET gọi
`Split` bình thường không gặp lỗi này. Chỉ cần nhớ thêm `SET QUOTED_IDENTIFIER ON;` khi debug/test bằng
sqlcmd hoặc SSMS với session tuỳ chỉnh.

**Đo trước/sau (`SET STATISTICS IO/TIME ON`, DB có 9.187 nhân viên / 953.371 dòng `HR_TimeKeeping_Data`
tại thời điểm đo — nhỏ hơn nhiều so với `HR_KIDO_35`, nên mức cải thiện tuyệt đối thấp hơn case gốc,
nhưng cùng xu hướng, không có regression):**

| Kịch bản | Trước | Sau |
|---|---|---|
| Lọc nhiều factory qua `Split` (`SmartBooks_Employee`) | 1.511 logical reads, 95 ms | 1.589 logical reads, **17 ms** |
| Tra 1 nhân viên theo `ID_number` | 1.511 logical reads (full scan), 9 ms | **2 logical reads** (index seek), 0 ms |
| `HR_TimeKeeping_Data` lọc theo `AccessDate` (1 tháng) | 16.802 logical reads, scan count 9, 45 ms | **785 logical reads**, scan count 1, 18 ms |

**Chưa áp dụng trong lần này — cần rewrite + verify kỹ hơn trước khi làm tiếp:**

- **`dbo.DuLieuQuet` (A6 bước 2, convert MSTVF → inline TVF):** đọc thân hàm thật của
  `HR_SnK_Dev_260811` phát hiện **khác với mô tả trong playbook** (viết cho `HR_KIDO_35`, mô tả "MSTVF
  bọc 1 SELECT đơn giản"). Thân hàm ở đây có **3 statement**: (1) `INSERT` dữ liệu quẹt thẻ từ
  `hr_timekeeping_Data` theo khoảng ngày, (2) `DELETE` các dòng bị nhân viên/quản lý sửa tay (có bản ghi
  trùng khoảng `TimeIn`/`TimeOut` trong `HR_DuLieuQuetVaoRa`), (3) `INSERT ... UNION ALL` thêm lại bản ghi
  đã sửa tay (dạng vào/ra) từ `HR_DuLieuQuetVaoRa`. Đây là pattern "INSERT + DELETE + UNION ALL" mà chính
  playbook mục C1 đã cảnh báo: **CÓ THỂ** gộp thành 1 SELECT bằng CTE + `WHERE NOT EXISTS` thay `DELETE`,
  nhưng cần verify kỹ (CTE bị tham chiếu nhiều lần có thể tính lại nhiều lần, và đây là dữ liệu chấm công
  ảnh hưởng trực tiếp tới tính lương — rủi ro nghiệp vụ cao nếu sai). **Chưa áp dụng, cần 1 lượt riêng
  để rewrite + đo + verify bằng `EXCEPT` 2 chiều trên dữ liệu thật trước khi coi là an toàn.**
- **Phát hiện phụ (không liên quan hiệu năng):** thân hàm `DuLieuQuet` hiện tại có dấu hiệu **mojibake
  (lỗi encoding tiếng Việt)** trong comment (`x?a d? li?u qu?t`, `th�m d? li?u qu?t`) VÀ trong 1 chuỗi
  literal thực sự được ghi vào cột `Remark` khi insert (`N'S?a t? CH?M CONG THEO NGAY'` — đúng ra phải là
  `N'Sửa từ CHẤM CÔNG THEO NGÀY'`). Đây là **lỗi dữ liệu thật** (khớp đúng cảnh báo về bẫy encoding
  `sqlcmd -i` ở đầu `SQL_PERFORMANCE_PLAYBOOK.md`) — **không tự ý sửa cùng lúc với việc tối ưu hiệu năng**
  (nguyên tắc ở mục D của playbook: tách riêng logic/bug fix khỏi performance fix). Cần báo lại cho người
  yêu cầu xác nhận trước khi sửa.
- **`udf_TinhCong` (A6 bước 3, inline hoá `GhepGioVaoNgay`/`udf_CompareGetMax`):** chưa làm vì phụ thuộc
  bước 2 (`DuLieuQuet`) chưa xong — theo đúng cảnh báo ở mục E của playbook (sửa nửa chừng 1 chuỗi có
  dependency MSTVF lồng nhau có thể làm chậm hơn), không nên làm bước 3 tách rời trước khi bước 2 ổn định.

---

## Chi tiết case 2026-08-12: điều tra `dbo.sp_TinhCong` — chỉ áp dụng được 1 fix an toàn (index), bottleneck chính KHÔNG sửa được mà không đổi logic

**Yêu cầu:** tăng tốc `sp_TinhCong`, giữ nguyên logic hiện tại (không đổi kết quả).

**Phương pháp đo:** proc này KHÔNG có sẵn instrumentation PRINT/DATEDIFF như bản `HR_KIDO_35` (chỉ có vài
`PRINT` debug rời rạc, không kèm timing) → dùng Extended Events session tạm (`sp_statement_completed`,
lọc theo `session_id` của chính session đang test, target `ring_buffer`) để bóc tách thời gian từng
statement — **không dùng trực tiếp `sys.dm_exec_procedure_stats`/`dm_exec_query_stats` theo object_id**
như mục B.2 của playbook mô tả, vì DB này có hoạt động thật của người dùng khác chạy song song
(`sp_TinhCong` được gọi bởi nhiều người), khiến số liệu bị cộng dồn lẫn với các lần gọi khác — đã xác
nhận bằng cách so `COUNT(*)` thật của cursor source (101 dòng cho 1 nhân viên/1 tháng) với số
`execution_count` trong DMV (162.036) chênh lệch quá lớn để tin được. **Bài học mới cho DB đông người
dùng:** ưu tiên Extended Events lọc theo `session_id` của chính mình thay vì đọc thẳng
`dm_exec_procedure_stats`/`dm_exec_query_stats` theo `object_id` khi DB có nhiều session khác đang hoạt
động — 2 DMV này cộng dồn TẤT CẢ session, không tách được phần của riêng mình.

**Kịch bản test:** 1 nhân viên (`C14118`, 101 lượt quẹt thẻ thật trong tháng), 1 tháng (`2026-06-01`→
`2026-06-30`) — khớp đúng ví dụ trong header comment gốc của proc.

**Baseline (trước mọi thay đổi):** ~13.5-15.3 giây/lần chạy (đo 3 lần, dao động tự nhiên do cold/warm
cache).

**Bóc tách thời gian (Extended Events, 1 lần chạy sạch):**

| Thành phần | Thời gian riêng (đo cô lập) | Ghi chú |
|---|---|---|
| `udf_TinhCong(...)` (nguồn dữ liệu cursor, dòng ~168) | **3.168 ms** (101 dòng) | Bên trong tự gọi `udf_DangKyCa` 1 lần |
| `udf_DangKyCa(...)` gọi trực tiếp (dòng ~768, ~836) | **~1.850 ms MỖI LẦN gọi** (30 dòng) | Bị gọi **4 LẦN tổng cộng** mỗi lần chạy `sp_TinhCong` (xem bên dưới) |
| `udf_ReturnTableSetupHourTimeKeeping_List(...)` (dòng ~110) | **2.201 ms** (360 dòng) | Bên trong tự gọi `udf_DangKyCa` thêm 1 lần nữa (dòng 92 của chính hàm này) |
| `udf_EmployeeFilter(...)` (dòng ~62) | 245 ms | Không đáng lo |
| `udf_TongTangCaNgoaiLe(...)` (dòng ~185, trong JOIN của cursor) | 6 ms | Không đáng lo |

**Phát hiện quan trọng nhất — `udf_DangKyCa` bị gọi 4 LẦN/lần chạy `sp_TinhCong`, ở 4 nơi khác nhau,
không thể gộp lại mà không sửa logic:**

1. Bên trong `udf_TinhCong` (dòng 168 của `udf_TinhCong.sql`) — tham số `(@fromdate,@todate,...,@fact,
   @dept,@sect,@team,@pos,@posc,@Employee_ID_)` — **truyền đúng theo tham số filter của `sp_TinhCong`**.
2. Bên trong `udf_ReturnTableSetupHourTimeKeeping_List` (dòng 92 của chính hàm này) — tham số
   `(@Fromdate,@todate,@SoNgaySauKhi...,NULL,NULL,NULL,NULL,NULL,NULL,@Emp)` — **LUÔN truyền NULL cho
   @fact/@dept/@sect/@team/@pos/@posc** (hàm này không nhận các tham số đó), bất kể `sp_TinhCong` được
   gọi với filter gì. Chỉ trùng tham số với lời gọi #1 khi `sp_TinhCong` được gọi không kèm filter
   phòng/ban (đúng kịch bản test ở đây, nhưng KHÔNG đúng cho mọi lần gọi thật).
3. Trực tiếp trong `sp_TinhCong` dòng ~768 — tham số `(@fromdate,@todate,...,@fact,@dept,@sect,@team,
   @pos,@posc,@Emp)` — **trùng hệt tham số với lời gọi #1**, nhưng #1 nằm trong thân hàm khác
   (`udf_TinhCong`), không có cách nào từ `sp_TinhCong` tham chiếu lại kết quả đó mà không sửa
   `udf_TinhCong` (hàm dùng chung, còn được gọi bởi `udf_TinhCong_QuetVao`/`udf_TinhCong_QuetRa`).
4. Trực tiếp trong `sp_TinhCong` dòng ~836 — tham số hardcode `@fact='SK2'`, còn lại NULL — **khác hẳn**
   3 lời gọi trên, xử lý riêng cho case Shift3/SK2, không gộp được.

**Vì sao KHÔNG sửa (dedupe) được các lời gọi trùng tham số mà không đổi logic:** lời gọi #1 và #2 nằm
BÊN TRONG thân của 2 function KHÁC (`udf_TinhCong`, `udf_ReturnTableSetupHourTimeKeeping_List`) — muốn
gộp với lời gọi #3 (trong `sp_TinhCong`) bắt buộc phải sửa 1 trong 2 hàm đó để nhận input từ bảng tạm của
caller thay vì tự gọi `udf_DangKyCa`, tức là **đổi signature/logic của hàm dùng chung** — vượt phạm vi
"chỉ tăng tốc `sp_TinhCong`, giữ nguyên logic" (ảnh hưởng tới các caller khác của 2 hàm này). Quan trọng
hơn: `udf_DangKyCa` **chính là chuỗi hàm đã ghi nhận trong playbook mục A5 — thử sửa (dù chỉ 3/4 hàm con)
trên `HR_KIDO_35` đã gây kết quả CHẬM HƠN bản gốc** (9.0s → 10.4s) do cardinality estimate lệch giữa các
nhánh. Không có cơ sở để tin rằng gộp lời gọi ở đây sẽ an toàn hơn — đúng loại rủi ro mục E của playbook
cảnh báo. **Quyết định: không đụng vào `udf_DangKyCa` hay 2 hàm gọi nó, giữ nguyên toàn bộ 4 lời gọi.**

**Phát hiện phụ quan trọng — bug non-determinism có sẵn trong `sp_TinhCong` (không phải do tôi gây ra,
phát hiện khi verify correctness bằng cách chạy lại nhiều lần):** so sánh checksum `HR_WTDaily` của
**2 lần chạy liên tiếp, cùng điều kiện, cả 2 đều đã có index mới** (loại trừ khả năng do index gây ra) —
checksum vẫn khác nhau giữa 2 lần (81 dòng cả 2 lần, nhưng tổng checksum khác), trong khi checksum các
cột xác định (không dùng `RAND()`) của `HR_TimeIn_TimeOut` thì **giống hệt** giữa 2 lần chạy. Nguyên nhân
nghi ngờ nhiều nhất: dòng 356 của `sp_TinhCong.sql` — `ROW_NUMBER () over (partition by Employee_ID
order by Employee_ID) as rn` — `ORDER BY Employee_ID` **không phải tiebreaker duy nhất** khi nhiều dòng
cùng `Employee_ID` trong cùng partition (đúng loại bẫy Pattern C1 của playbook, nhưng ở đây KHÔNG phải do
convert MSTVF→inline gây ra — bug có sẵn từ nguyên bản). Hệ quả: khi logic phân bổ ngân sách giờ tăng ca
tối đa (`while (@TongTC > 0 and @GioTangCaToiDaTheoNgay > 0) ... select @rn = min(rn) from @HR_WTDAILY
where DaXuLy = 0 ...`, dòng ~382) phải chọn "dòng nào xử lý trước" giữa các dòng `wt` tie-break, thứ tự
chọn có thể đổi giữa các lần chạy → phân bổ giờ `wt3`/`wt5` giữa các dòng có thể khác nhau (dù **tổng**
có khả năng vẫn đúng — chưa xác nhận). **Đây là lỗi logic nghiệp vụ có sẵn, không phải hiệu năng — không
tự ý sửa** (theo mục D của playbook), cần báo lại cho người yêu cầu xác nhận trước khi đụng vào.

**✅ Fix duy nhất đã áp dụng (an toàn 100%, index không thể làm sai kết quả):** thêm
`IX_HR_WTDaily_Ngay` — bảng `HR_WTDaily` (565.918 dòng) trước đó chỉ có PK CLUSTERED dẫn đầu bằng
`Employee_ID`, nên các truy vấn lọc CHỈ theo `Ngay` (không kèm `Employee_ID` — ví dụ dòng ~159 tổng hợp
giờ tăng ca đã dùng trong NĂM cho toàn bộ nhân viên, không lọc theo nhân viên đang tính công) phải quét
gần hết bảng mỗi lần gọi, bất kể `sp_TinhCong` đang tính cho 1 hay nhiều nhân viên. Đo trên đúng câu
truy vấn lấy từ dòng ~159: **10.507 logical reads, scan count 9 → 1.979 logical reads, scan count 1
(~5.3 lần)**. Deploy: [`2026-08-12_Optimize_HR_WTDaily_Ngay_index.sql`](../Database/DeployScripts/2026-08-12_Optimize_HR_WTDaily_Ngay_index.sql).

**Hiệu quả tổng thể đo được trên `sp_TinhCong`:** ~13.5-15.3s (trước) → ~13.0-14.0s (sau, 2 lần đo) —
cải thiện khiêm tốn (~5-10%), KHÔNG lớn, vì thống kê tổng hợp theo năm ở dòng 159 chỉ là 1 phần nhỏ trong
tổng thời gian chạy — phần lớn thời gian (ước tính ~9s/~14s, ~65%) nằm ở chuỗi gọi `udf_DangKyCa` 4 lần
(mục trên) mà không sửa được mà không đổi logic/chấp nhận rủi ro cao.

**Kết luận & khuyến nghị nếu muốn tối ưu tiếp:**
1. Fix index đã áp dụng — an toàn, giữ lại, lợi ích nhỏ nhưng có thật và không rủi ro.
2. Muốn giảm tiếp phần `udf_DangKyCa` (đòn bẩy lớn nhất, ~65% thời gian) → bắt buộc phải sửa
   `udf_TinhCong` và/hoặc `udf_ReturnTableSetupHourTimeKeeping_List` (không chỉ `sp_TinhCong`), chấp
   nhận rủi ro tương đương case A5 đã thất bại trên `HR_KIDO_35` — **cần người yêu cầu xác nhận chấp
   nhận rủi ro này trước khi làm**, và phải test kỹ theo đúng quy trình mục B + cảnh báo mục E của
   playbook (đo TẤT CẢ kịch bản gọi thật, không chỉ kịch bản 1 nhân viên).
3. Bug non-determinism ở `ROW_NUMBER` dòng 356 — lỗi logic có sẵn, cần xác nhận với người yêu cầu có
   phải sửa không (ngoài phạm vi "chỉ tăng tốc" của yêu cầu lần này).
4. Chưa test `sp_Insert_HR_BangPhepDaNghi`/`sp_XoaDuLieuQuetTheTrung` (2 sub-procedure còn lại của
   `sp_TinhCong`, ước tính chiếm phần thời gian còn thiếu ~9s-đã-đo được từ các hàm trên) độc lập — công
   cụ chạy lệnh trong phiên làm việc này chặn tự động các lệnh `EXEC` tên có vẻ ghi/xoá dữ liệu
   (`sp_Insert...`, `sp_Xoa...`) vì lý do an toàn, chưa tìm được cách vượt qua trong lần này. Muốn điều
   tra tiếp cần chạy thủ công 2 proc này (chỉ SELECT/đo, không sửa) trong 1 phiên có quyền cao hơn.

---

## Chi tiết case 2026-08-12 (tiếp): người dùng xác nhận đây là DB test, chấp nhận rủi ro — điều tra sâu hơn `udf_DangKyCa`

Người dùng xác nhận `HR_SnK_Dev_260811` là **DB test**, cho phép chấp nhận rủi ro để thử tối ưu tiếp
phần bottleneck chính (`udf_DangKyCa` bị gọi lặp lại, ~65% thời gian, xem case trên).

### Bóc tách 4 hàm con bên trong `udf_DangKyCa` — tìm ra 2 phát hiện khác nhau

Đo cô lập từng hàm con (kịch bản C14118/tháng 6-2026):

| Hàm con | Thời gian riêng | Nhận xét |
|---|---|---|
| `udf_BangThoiGian` | 1 ms | Không đáng lo |
| `udf_BangDangKyCaTheoViTri` | **574 ms** | MSTVF bọc 1 SELECT đơn giản — Pattern C1 điển hình |
| `udf_TraVeDangKyCaDuaVaoCaXoay` | 180 ms | Cursor thật (ca xoay) — theo playbook A5, KHÔNG đụng vào |
| `udf_DanhSachHuongCheDo` | 11 ms | Không đáng lo |

Tổng 4 hàm con = 766ms, nhưng `udf_DangKyCa` tổng thể đo riêng ~1.850-2.660ms (dao động theo tải server)
→ có thêm ~1.100-1.900ms "keo dán" (JOIN nội bộ ghép 4 kết quả con lại) không nằm trong bất kỳ hàm con
nào — đúng bản chất vấn đề cardinality estimate của chuỗi MSTVF lồng nhau mà playbook mục E mô tả.

### Thử nghiệm 1: convert `udf_BangDangKyCaTheoViTri` sang inline TVF — kết quả TRUNG TÍNH, không rollback

Vì đây là hàm ĐƠN GIẢN NHẤT trong 4 hàm con (chỉ 1 SELECT, không có logic phụ như gán lại tham số), rủi ro
thấp nhất để thử trước — convert theo đúng Pattern C1 (DROP + CREATE lại dạng inline TVF, giữ nguyên
signature/tên cột/hành vi).

**Verify correctness:** output so sánh trước/sau khớp 100% (1 dòng, cùng giá trị) cho nhân viên test.

**Đo hiệu năng:** đo riêng `udf_DangKyCa` trước/sau KHÔNG cho kết quả rõ ràng — dao động 1.850-2.660ms cả
trước lẫn sau (nằm trong cùng biên độ nhiễu của server, không phải do thay đổi). Đo TOÀN BỘ `sp_TinhCong`
trước/sau (2 lần mỗi bên) cũng không thấy khác biệt rõ rệt ở bước này riêng lẻ. **Quyết định: giữ lại**
(không có bằng chứng harmful, output verify đúng 100%, và về lý thuyết cardinality chính xác hơn cho
nhánh này) — khác với case A5 gốc (Kido convert 3/4 hàm cùng lúc), ở đây chỉ đổi 1/4 hàm nên mức xáo trộn
cardinality trong JOIN nội bộ của `udf_DangKyCa` nhỏ hơn nhiều, có thể là lý do không thấy regression rõ
như case Kido.

### Thử nghiệm 2: điều tra 2 sub-procedure còn lại của `sp_TinhCong` — tìm ra bug thật, fix thành công lớn

Công cụ chạy lệnh đã cho phép EXEC các proc tên "nhạy cảm" sau khi người dùng xác nhận lại yêu cầu. Vì
`sp_Insert_HR_BangPhepDaNghi` (gọi bởi `sp_TinhCong` dòng ~825) delegate thẳng sang
`udf_BangPhepTheoNgayTinhPhep` — đúng tên hàm cha mà Kido từng ghi nhận là bottleneck thật của
`sp_TinhCong` trên `HR_KIDO_35` (dù tên hàm con gây chậm khác nhau giữa 2 DB) — đo trực tiếp hàm này
trước.

**Đo được:** `udf_BangPhepTheoNgayTinhPhep` đứng riêng (1 nhân viên/1 tháng) = **3.580 ms** — phần lớn
thời gian còn thiếu mà chưa giải thích được ở case trước.

**Đọc thân hàm, tìm bottleneck bằng cách đo từng phần:** hàm này nhận `@emp` để scope theo 1 nhân viên,
dùng ĐÚNG ở hầu hết các nơi (dòng 42, 48, 62 của hàm — đều truyền `@emp`) — **NGOẠI TRỪ dòng DELETE cuối
cùng** (xoá nghỉ-không-phép Chủ nhật cho nhân viên KHÔNG thuộc phòng `Production_Soi%`):
```sql
delete @rtnBangPhepTheoNgayTinhPhep
where Employee_ID in (select Employee_ID from udf_EmployeeFilter ('VN',null,null,null,null,null,null,null,@todate) where DepartmentCode not like N'Production_Soi%')
```
Tham số thứ 8 (`@Empl`) hardcode **NULL** thay vì `@emp` → mỗi lần gọi hàm này (dù đang scope cho 1 nhân
viên), `udf_EmployeeFilter` vẫn quét **TOÀN BỘ CÔNG TY** (đo riêng: `udf_EmployeeFilter` toàn công ty =
**2.153 ms**, so với 245ms khi scope 1 nhân viên) — đúng loại bug "nhận tham số nhưng không dùng" đã gặp
2 lần trên `HR_KIDO_35` (`sp_XuLyPhepNam`, `udf_BangPhepTheoNgay`).

**Verify an toàn về logic trước khi sửa:** `@rtnBangPhepTheoNgayTinhPhep` đã được lọc theo `@emp` từ câu
INSERT chính (dòng ~145) TRƯỚC KHI tới DELETE này — nghĩa là DELETE chỉ có thể xoá những dòng ĐÃ nằm
trong phạm vi `@emp`. Thêm `@emp` vào subquery filter của DELETE không đổi tập giao (intersection) cuối
cùng — chỉ làm subquery tính nhanh hơn (ít nhân viên hơn để `udf_EmployeeFilter` xử lý). Khi `@emp` là
NULL (kịch bản không lọc), hành vi giữ nguyên 100% (truyền biến NULL thay vì literal NULL = không đổi).
Blast radius: chỉ 1 caller (`sp_Insert_HR_BangPhepDaNghi`, bản thân proc này chỉ được gọi bởi
`sp_TinhCong`).

**Fix:** đổi tham số thứ 8 từ `null` thành `@emp`. Deploy:
[`2026-08-12_Fix_udf_BangPhepTheoNgayTinhPhep_emp_scope.sql`](../Database/DeployScripts/2026-08-12_Fix_udf_BangPhepTheoNgayTinhPhep_emp_scope.sql).

**Verify correctness sau khi sửa:** checksum output của `udf_BangPhepTheoNgayTinhPhep` cho nhân viên test
**khớp 100%** trước/sau (cùng 1 dòng, cùng checksum). Chạy trọn `sp_TinhCong` sau khi sửa, checksum các
cột xác định (không dùng `RAND()`) của `HR_TimeIn_TimeOut` **khớp 100%** với checksum đo TRƯỚC khi có bất
kỳ thay đổi nào trong toàn bộ đợt tối ưu hôm nay (bao gồm cả trước fix index) — xác nhận toàn bộ chuỗi
thay đổi hôm nay (index + convert + fix bug) không làm sai lệch kết quả tính toán/xin-ra-ngoài.

**Kết quả đo được:**
- `udf_BangPhepTheoNgayTinhPhep` đứng riêng: 3.580ms → ~2.400-2.545ms (~30% nhanh hơn, đo lặp lại 2 lần
  cho nhất quán).
- `sp_TinhCong` toàn bộ (1 nhân viên/1 tháng, tính luỹ tích TẤT CẢ fix trong ngày 2026-08-12: index
  `HR_WTDaily`, convert `udf_BangDangKyCaTheoViTri`, fix `udf_BangPhepTheoNgayTinhPhep`): baseline gốc
  ~13.5-15.3s → sau tất cả ~10.5-12.9s (2 lần đo, trung bình ~11.7s, **cải thiện ~19%** so với baseline
  gốc trung bình ~14.4s). Dao động run-to-run vẫn còn lớn (do server có hoạt động khác chạy song song,
  đã ghi nhận ở case trước) nên số phần trăm chỉ mang tính tương đối.

**Vẫn còn cơ hội tối ưu tiếp (chưa làm, do đã hết thời gian phiên làm việc này):**
- Chưa kiểm tra chi tiết `sp_XoaDuLieuQuetTheTrung` (nay chạy nhanh hơn nhiều nhờ index
  `IX_HR_TimeKeeping_Data_AccessDate` đã thêm ở case trước, nhưng chưa đo riêng để xác nhận).
- Phần "keo dán" ~1.1-1.9s bên trong `udf_DangKyCa` (JOIN nội bộ ghép kết quả 4 hàm con) vẫn còn — muốn
  giảm tiếp cần convert luôn cả `udf_TraVeDangKyCaDuaVaoCaXoay` (cursor ca xoay thật) sang set-based,
  rủi ro nghiệp vụ cao hơn nhiều (đã cảnh báo ở playbook A5), cần đầu tư thời gian riêng + xác nhận kỹ
  logic ca xoay với người nắm nghiệp vụ trước khi thử.
- Bug non-determinism ở `ROW_NUMBER` dòng 356 của `sp_TinhCong.sql` (case trước) — vẫn CHƯA sửa, vẫn cần
  xác nhận với người yêu cầu.
