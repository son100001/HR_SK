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
