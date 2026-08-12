# 🚀 SQL Performance Playbook — Cẩm nang tối ưu SQL Server cho hệ thống này

> **Mục đích:** File này portable — mang sang bất kỳ database nào khác của cùng hệ thống (POCONS/
> Kido/SmartBooks HR, vì mỗi khách hàng là 1 bản copy gần như y hệt của cùng phần mềm) để đọc là biết
> ngay **object nào cần sửa, sửa gì, sửa như thế nào** — không phải build lại quy trình chẩn đoán/đo đạc
> từ đầu. Viết cho cả người và AI đọc.
>
> **Nguyên tắc bất di bất dịch:** không đoán — đo. Không sửa xong là xong — phải test bằng dữ liệu thật
> trước/sau. Không sửa 1 function dùng chung mà không kiểm tra hết các nơi gọi tới nó trước. Sửa xong
> đo LẠI đúng cái caller thực tế đang dùng (không chỉ đo function con riêng lẻ — xem cảnh báo cuối file).
>
> Lịch sử/nhật ký các lần áp dụng cụ thể (ngày nào, deploy script nào) nằm ở file riêng:
> [SQL_PERFORMANCE_HISTORY.md](SQL_PERFORMANCE_HISTORY.md) — file này chỉ chứa cách sửa tổng quát.

> [!NOTE]
> **Nguồn gốc file này:** port nguyên văn từ `Kido_New/markdowns/SQL_PERFORMANCE_PLAYBOOK.md` (database
> `HR_KIDO_35`) ngày 2026-08-12, vì đây là bản copy khác của cùng hệ thống POCONS/SmartBooks HR — mọi
> pattern ở đây được viết chung, không đặc thù riêng cho `HR_KIDO_35`.
>
> **Đã đối chiếu trực tiếp với DB `HR_SnK_Dev_260811` (113.161.180.44) ngày 2026-08-12** — xác nhận:
> - `compatibility_level = 120` (giống hệt `HR_KIDO_35`) → mọi cảnh báo về `STRING_SPLIT()` và Scalar UDF
>   Inlining trong mục B.1/C5 áp dụng y hệt.
> - `dbo.Split` **vẫn là MSTVF gốc** (chưa sửa) → mục A1 áp dụng thẳng được.
> - `dbo.SmartBooks_Employee` **chưa có** index trên `ID_number` → mục A2 áp dụng thẳng được.
> - `dbo.DuLieuQuet` **vẫn là MSTVF gốc**, `dbo.HR_TimeKeeping_Data` **chưa có** index trên `AccessDate`
>   → mục A6 (bước 1+2) áp dụng thẳng được (bước 3 — inline hoá `GhepGioVaoNgay`/`udf_CompareGetMax` —
>   cần đọc kỹ thân `udf_TinhCong` của DB này trước, có thể đã khác nhẹ so với bản Kido).
> - Toàn bộ object khác nhắc tới trong mục A (`udf_EmployeeFilter`, `sp_TinhCong`, `sp_Insert_HR_BangPhepDaNghi`,
>   `udf_BangPhepTheoNgay`, `udf_BangPhep`, `udf_PhepNamTheoThang`, `udf_DangKyCa`, `HR_MaxOvertime`...)
>   **đều tồn tại** trong `HR_SnK_Dev_260811` với cùng tên — DDL đầy đủ đã export sẵn ở
>   [`Database/SQL/`](../Database/SQL/), dùng để đối chiếu/verify trước khi sửa thay vì phải connect DB.
> - Riêng `sp_XuLyCongKhachHangNew`, `sp_XuLyPhepNam`, bảng `HR_BangPhepNam` (nhắc ở mục A4/A7) **không
>   tồn tại** trong `HR_SnK_Dev_260811` với tên này — có thể đã đổi tên, không có trong bản deploy cho
>   khách hàng này, hoặc logic tương đương nằm ở object khác. Kiểm tra lại bằng
>   `SELECT name FROM sys.objects WHERE name LIKE '%TenGanGiong%'` trước khi áp dụng phần liên quan.
> - **Chưa áp dụng bất kỳ fix nào trong file này lên `HR_SnK_Dev_260811`** — đây chỉ là bước đối chiếu
>   khả năng áp dụng. Xem [SQL_PERFORMANCE_HISTORY.md](SQL_PERFORMANCE_HISTORY.md) để biết trạng thái mới
>   nhất trước khi bắt tay sửa (tránh áp dụng trùng lặp).

---

## A. Áp dụng nhanh — object đã biết cần sửa gì (kiểm tra trên DB mới, apply thẳng nếu khớp)

Với mỗi object, **kiểm tra triệu chứng trước** (DB khác có thể đã tự sửa rồi, hoặc code khác bản), rồi
mới áp dụng fix.

### A1. `dbo.Split` — ✅ an toàn, áp dụng thẳng

**Kiểm tra:** `SELECT type_desc FROM sys.objects WHERE name = 'Split';` → nếu ra
`SQL_TABLE_VALUED_FUNCTION` (không phải `SQL_INLINE_TABLE_VALUED_FUNCTION`) → cần sửa.

**Vấn đề:** MSTVF dùng vòng lặp `WHILE` để tách chuỗi theo dấu phẩy → SQL Server ước lượng sai
cardinality khi hàm này được dùng trong `IN (SELECT ... FROM Split(...))` → ép nested-loop quét lại
toàn bộ bảng phía ngoài 1 lần cho MỖI giá trị trong danh sách lọc.

**Cách sửa** — DROP + CREATE lại (không `ALTER` được, khác loại object):
```sql
IF OBJECT_ID('dbo.Split', 'IF') IS NOT NULL DROP FUNCTION [dbo].[Split];
IF OBJECT_ID('dbo.Split', 'TF') IS NOT NULL DROP FUNCTION [dbo].[Split];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[Split]
    (
      @RowData NVARCHAR(max),
      @SplitOn NVARCHAR(5)
    )
RETURNS TABLE
AS
RETURN
(
    SELECT CAST(LTRIM(RTRIM(t.value('.', 'nvarchar(1000)'))) AS NVARCHAR(1000)) AS Data
    FROM (
        SELECT CAST(N'<x>' + REPLACE((SELECT @RowData AS [*] FOR XML PATH('')), @SplitOn, N'</x><x>') + N'</x>' AS XML) AS xdata
    ) AS src
    CROSS APPLY src.xdata.nodes('/x') AS t2(t)
);
GO
```
Giữ nguyên tên hàm/tham số/tên cột kết quả (`Data`)/hành vi trim + token rỗng → tương thích ngược 100%,
**không cần sửa bất kỳ caller nào**. An toàn dùng ở mọi compatibility level (không cần `STRING_SPLIT`,
không giới hạn đệ quy).

**Trước khi drop:** check permission riêng trên object (`SELECT * FROM sys.database_permissions WHERE
major_id = OBJECT_ID('dbo.Split')`) để cấp lại nếu có.

---

### A2. `dbo.SmartBooks_Employee` — thiếu index trên `ID_number` — ✅ an toàn, áp dụng thẳng

**Kiểm tra:** `SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID('dbo.SmartBooks_Employee');` → nếu
không có index nào có `ID_number` làm leading key → cần thêm.

**Vấn đề:** tra 1 nhân viên theo CMND/CCCD (`udf_EmployeeFilter`'s tham số `@Empl`, so khớp cả
`Employee_ID` lẫn `ID_number`) không có index hỗ trợ cho nhánh `ID_number` → full scan.

**Cách sửa:**
```sql
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID('dbo.SmartBooks_Employee') AND name = 'IX_SmartBooks_Employee_ID_number'
)
CREATE NONCLUSTERED INDEX [IX_SmartBooks_Employee_ID_number]
    ON [dbo].[SmartBooks_Employee] ([ID_number] ASC)
    INCLUDE ([Employee_ID]);
GO
```
Additive, không đổi hành vi gì. Nếu bảng đã có `IX_SmartBooks_Employee_Filter` (phủ Factory/Dept/
Section/Team/Position/PositionCategory) rồi thì giữ nguyên, chỉ thêm index này bổ sung — không trùng.

---

### A3. `dbo.udf_EmployeeFilter` — không cần sửa trực tiếp, tự nhanh lên nhờ A1+A2

Bản thân function này **không cần đổi 1 dòng SQL nào** — nó tự động nhanh lên khi `Split` (A1) và index
`ID_number` (A2) được áp dụng, vì nó gọi `Split` bên trong và filter theo `ID_number`. Nếu 1 DB khác có
1 hàm tương tự (hàm lấy dữ liệu nhân viên nền tảng, được rất nhiều store/function khác gọi), luôn kiểm
tra trước hết các **dependency bên trong nó** (theo Pattern B dưới) thay vì sửa thẳng hàm đó.

---

### A4. `dbo.sp_XuLyCongKhachHangNew` — cursor xử lý tăng ca — ✅ an toàn, áp dụng thẳng

> ⚠️ **Chưa xác nhận object này tồn tại trong `HR_SnK_Dev_260811`** (không thấy `sp_XuLyCongKhachHangNew`
> trong export ngày 2026-08-12) — kiểm tra lại tên thật trước khi áp dụng, có thể là proc khác đảm nhiệm
> logic tương tự trong bản deploy cho khách hàng này.

**Kiểm tra:** trong thân proc có bảng tạm `#TongTangCaTheoNgayPhu` (hoặc tương đương — bảng tạm bị
truy vấn lặp lại nhiều lần trong 1 cursor loop) mà **không có** `CREATE CLUSTERED INDEX` ngay sau
`CREATE TABLE` của nó → cần sửa. Và/hoặc có nhiều câu `SELECT @var = col FROM cungBang WHERE
cungDieuKien` tách rời liền nhau (cùng bảng, cùng điều kiện) → gộp được.

**Cách sửa (áp dụng cho `#TongTangCaTheoNgayPhu` cụ thể, tổng quát hoá cho bảng tạm tương tự):**

1. Ngay sau `CREATE TABLE #TongTangCaTheoNgayPhu (...)`, thêm:
   ```sql
   CREATE CLUSTERED INDEX IX_TongTangCaNgayPhu_Ngay ON #TongTangCaTheoNgayPhu(Ngay);
   ```
2. Gộp:
   ```sql
   select @MinOT = wtTC from #TongTangCaTheoNgayPhu where Ngay = @MaxOTDate
   select @TongWt = Tongwt from #TongTangCaTheoNgayPhu where Ngay = @MaxOTDate
   select @TCT = TCT from #TongTangCaTheoNgayPhu where Ngay = @MaxOTDate
   ```
   thành:
   ```sql
   select @MinOT = wtTC, @TongWt = Tongwt, @TCT = TCT from #TongTangCaTheoNgayPhu where Ngay = @MaxOTDate
   ```

Không đổi 1 dòng kết quả nào — chỉ giảm round-trip. Áp dụng được cho MỌI cursor loop khác trong hệ
thống có cùng hình dạng (bảng tạm không index bị truy vấn lặp lại hàng chục nghìn lần + nhiều SELECT
đơn tách rời cùng bảng/cùng điều kiện) — không riêng gì proc này.

Toàn văn proc đã sửa (bản Kido, `HR_KIDO_35`):
[`Kido_New/Database/DeployScripts/2026-08-07_sp_XuLyCongKhachHangNew_TCT_case.sql`](../../Kido_New/Database/DeployScripts/2026-08-07_sp_XuLyCongKhachHangNew_TCT_case.sql)
(file này gộp cả 1 fix logic nghiệp vụ khác không liên quan hiệu năng — đọc kỹ trước khi copy thẳng
sang DB khác, phần hiệu năng an toàn để lấy riêng).

---

### A5. `dbo.udf_DangKyCa` + 4 hàm con — ⚠️ ĐÃ THỬ (trên `HR_KIDO_35`), KHÔNG ÁP DỤNG — đừng lặp lại y hệt

**Object liên quan:** `udf_DangKyCa` (hàm ngoài), gọi lồng `udf_BangThoiGian`,
`udf_BangDangKyCaTheoViTri`, `udf_TraVeDangKyCaDuaVaoCaXoay`, `udf_DanhSachHuongCheDo` (4 hàm con, đều
là MSTVF).

**Đã xác nhận bằng đo thật:** convert 3/4 hàm con (những hàm chỉ bọc 1 SELECT) sang inline TVF, giữ
nguyên hàm thứ 4 (`udf_TraVeDangKyCaDuaVaoCaXoay` — có cursor xử lý ca xoay tuần tự thật, không inline
hoá an toàn được) → khiến `udf_DangKyCa` **CHẬM HƠN bản gốc**, dù từng hàm con riêng lẻ đo nhanh hơn rõ
rệt. Lý do: cardinality estimate không đồng đều giữa các nhánh JOIN khiến optimizer chọn plan tổng thể
tệ hơn. Chi tiết đầy đủ + số đo: `Kido_New/markdowns/SQL_PERFORMANCE_HISTORY.md` (không portable, riêng
cho `HR_KIDO_35`).

**Nếu DB khác có cùng chuỗi hàm này, và muốn tối ưu:**
- **Đừng sửa nửa chừng như trên** (kinh nghiệm thật, không phải suy đoán).
- Muốn tối ưu thật sự: phải xử lý được cả `udf_TraVeDangKyCaDuaVaoCaXoay` (viết lại thuật toán ca xoay
  set-based) CÙNG LÚC với 3 hàm kia — đây là việc rủi ro nghiệp vụ cao (thuật toán lịch ca xoay phức
  tạp, cursor + nhiều `WHILE` lồng nhau), **phải xác nhận với người yêu cầu trước khi làm**, không tự ý.
- Hoặc đơn giản là không đụng vào — giữ nguyên toàn bộ 4-5 hàm ở dạng MSTVF ban đầu.

`HR_SnK_Dev_260811` cũng có `dbo.udf_DangKyCa` — bài học "đừng sửa nửa chừng" áp dụng y hệt nếu có ý
định tối ưu hàm này ở đây.

---

### A6. `dbo.udf_TinhCong` (+ `dbo.DuLieuQuet`, bảng `HR_TimeKeeping_Data`) — ✅ an toàn, áp dụng thẳng, nhưng theo ĐÚNG THỨ TỰ

**Bối cảnh:** `udf_TinhCong` ghép dữ liệu quẹt vân tay (`DuLieuQuet` → bảng `HR_TimeKeeping_Data`) với
khung giờ ca làm việc (giờ đầu/giờ cuối) + tăng ca trước/tăng ca sau, dùng bởi `udf_TinhCong_QuetVao`/
`udf_TinhCong_QuetRa` (gọi bởi `sp_TinhGioXinRaNgoai`) — **trong toàn bộ codebase, luôn gọi với 1
`Employee_ID` cụ thể, không có nơi nào gọi kiểu "toàn bộ nhân viên"**. (Xác nhận trên `HR_KIDO_35` —
kiểm tra lại caller thật của `HR_SnK_Dev_260811` trước khi tin giả định này.)

**Kiểm tra:**
1. `SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID('dbo.HR_TimeKeeping_Data');` → nếu không có
   index nào có `AccessDate` làm leading key → thiếu (bảng này thường rất lớn, nhiều triệu dòng, chỉ
   filter theo AccessDate mà không có Employee_ID kèm theo).
2. `SELECT type_desc FROM sys.objects WHERE name = 'DuLieuQuet';` → nếu `SQL_TABLE_VALUED_FUNCTION` →
   cần sửa (Pattern C1, hàm chỉ bọc 1 SELECT từ bảng quẹt thẻ).
3. Trong thân `udf_TinhCong`, tìm `dbo.GhepGioVaoNgay(` và `dbo.udf_CompareGetMax(` bên trong điều
   kiện `on ... between ... and ...` của JOIN tới `DuLieuQuet` → nếu có, đây là Pattern C5 (scalar
   function trong điều kiện JOIN).

**Cách sửa — áp dụng đúng theo thứ tự này (đã đo: áp dụng thiếu 1 bước có thể LÀM CHẬM HƠN, xem cảnh
báo bên dưới):**
1. Thêm index: `CREATE NONCLUSTERED INDEX IX_HR_TimeKeeping_Data_AccessDate ON HR_TimeKeeping_Data(AccessDate);`
2. Convert `DuLieuQuet` sang inline TVF (xem Pattern C1 — chỉ là bọc lại 1 SELECT, không đổi logic).
3. Trong `udf_TinhCong`, thay `cast([dbo].[GhepGioVaoNgay](@Ngay,@Gio) as datetime)` bằng:
   ```sql
   DATEADD(second, DATEDIFF(second, CAST(CAST(@Gio AS date) AS datetime), @Gio), CAST(CAST(@Ngay AS date) AS datetime))
   ```
   và `dbo.udf_CompareGetMax(@a,@b)` bằng `(CASE WHEN (@a) >= (@b) THEN (@a) ELSE (@b) END)`.

Toàn văn cả 3 thay đổi (bản Kido, `HR_KIDO_35`):
[`Kido_New/Database/DeployScripts/2026-08-11_Optimize_udf_TinhCong.sql`](../../Kido_New/Database/DeployScripts/2026-08-11_Optimize_udf_TinhCong.sql)
— **đọc kỹ và đối chiếu với thân `udf_TinhCong` thật của `HR_SnK_Dev_260811`**
([`Database/SQL/Functions/TableValued/udf_TinhCong.sql`](../Database/SQL/Functions/TableValued/udf_TinhCong.sql))
trước khi copy, vì 2 bản có thể đã lệch nhau qua thời gian.

**⚠️ Phải làm CẢ 3 bước, không dừng ở bước 2:** đã đo thật trên `HR_KIDO_35` — chỉ làm bước 1+2 (chưa
inline hoá scalar function) khiến kịch bản "toàn bộ nhân viên" **CHẬM HƠN** bản gốc (240s → 303s cho 1
tháng), giống hệt bài học ở mục E (cardinality lệch giữa nhánh đã sửa và chưa sửa). Làm đủ cả 3 bước thì
nhanh hơn bản gốc ở **cả 2 kịch bản**: 1 nhân viên/1 ngày 750ms→41ms (~18 lần), và ngay cả kịch bản tổng
hợp "toàn bộ nhân viên/1 tháng" cũng giảm từ 240s → 184s.

---

### A7. `dbo.sp_TinhCong` — bottleneck KHÔNG nằm ở chỗ tưởng tượng (kết quả đo trên `HR_KIDO_35`)

**Đã xác nhận bằng đo thật trên `HR_KIDO_35` (không đoán):** cursor chính của `sp_TinhCong` (chạy trên
dữ liệu từ `udf_TinhCong`) **KHÔNG phải bottleneck** — mỗi dòng chỉ tốn 0-3ms (đo bằng PRINT/DATEDIFF
timing đã có sẵn trong code). Nếu định tối ưu `sp_TinhCong` ở DB khác, **đừng mặc định nhắm vào cursor
trước** — hãy chạy thử với `PRINT`/`DATEDIFF(ms,...)` (proc này thường có sẵn instrumentation ở hầu hết
các khối) để xem thật sự khối nào tốn thời gian, TRƯỚC khi quyết định sửa gì.

**Bottleneck thật trên `HR_KIDO_35`:** `sp_XuLyPhepNam` (gọi tính phép năm cho TOÀN BỘ CÔNG TY bất kể
đang tính cho 1 hay nhiều nhân viên) → nội bộ gọi `udf_PhepNamTheoThang` (MSTVF nặng, ~30+ cuộc gọi
scalar function `udf_CountDayExceptSunday`), và `udf_BangPhep` (UNION với `HR_MaxOvertime` — 2.5 triệu
dòng, thiếu index trên `NgayNghiBu`). Toàn bộ chi tiết + số đo đầy đủ 4 vòng điều tra/fix (bug `@emp`
không dùng, quy tắc "giữ MSTVF chỉ sửa nội bộ", index filtered cho `HR_MaxOvertime`...) nằm ở
`Kido_New/markdowns/SQL_PERFORMANCE_HISTORY.md` — **không portable, chỉ để tham khảo cách chẩn đoán**,
vì `HR_SnK_Dev_260811` không có `sp_XuLyPhepNam`/`HR_BangPhepNam` với tên này (xem ghi chú đầu file).

**Nếu tối ưu `sp_TinhCong` ở `HR_SnK_Dev_260811`:** áp dụng đúng quy trình chẩn đoán ở mục B bên dưới từ
đầu (đo bằng `sys.dm_exec_procedure_stats` để tìm statement chậm nhất thật sự), không giả định bottleneck
giống hệt `HR_KIDO_35` vì tên object khác nhau (`sp_XuLyPhepNam` không tồn tại ở đây).

---

## B. Quy trình chẩn đoán chung (khi gặp object MỚI, chưa có trong mục A)

1. **Kiểm tra compatibility level của DB trước tiên** — quyết định feature T-SQL nào dùng được:
   ```sql
   SELECT compatibility_level FROM sys.databases WHERE name = DB_NAME();
   ```
   `STRING_SPLIT()` chỉ dùng được từ compat level 130+ — đừng giả định engine mới thì feature mới nào
   cũng dùng được, luôn check compat level của từng DB cụ thể (có DB compat level 120 dù engine chạy
   SQL Server 2025). **`HR_SnK_Dev_260811` đang ở compat level 120** — `STRING_SPLIT()` KHÔNG dùng được,
   dùng kỹ thuật XML `nodes()` như A1.

2. **Đo trước khi sửa, đo lại sau khi sửa** — không kết luận "chậm vì X" nếu chưa đo:
   - Ad-hoc: `SET STATISTICS IO ON; SET STATISTICS TIME ON;` trước câu lệnh test → đọc `logical reads`,
     `scan count`, `elapsed time`.
   - **Bóc tách từng statement bên trong 1 stored procedure đã chạy** (cách tìm nút thắt chính xác,
     không đoán):
     ```sql
     DECLARE @h varbinary(64);
     SELECT @h = plan_handle FROM sys.dm_exec_procedure_stats WHERE object_id = OBJECT_ID('dbo.TenProc');
     IF @h IS NOT NULL DBCC FREEPROCCACHE(@h);
     EXEC dbo.TenProc ...;
     SELECT qs.total_elapsed_time/1000.0 AS TotalElapsed_ms, qs.execution_count,
            SUBSTRING(st.text, (qs.statement_start_offset/2)+1,
              ((CASE qs.statement_end_offset WHEN -1 THEN DATALENGTH(st.text) ELSE qs.statement_end_offset END
                - qs.statement_start_offset)/2) + 1) AS StatementText
     FROM sys.dm_exec_procedure_stats ps
     JOIN sys.dm_exec_query_stats qs ON qs.plan_handle = ps.plan_handle
     CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
     WHERE ps.object_id = OBJECT_ID('dbo.TenProc')
     ORDER BY qs.total_elapsed_time DESC;
     ```

3. **Trước khi sửa 1 function/proc dùng chung, tìm hết nơi đang gọi nó** (định lượng "blast radius"):
   ```sql
   SELECT o.name, o.type_desc
   FROM sys.sql_modules m JOIN sys.objects o ON o.object_id = m.object_id
   WHERE m.definition LIKE '%TenFunctionCanTim%' AND o.object_id <> OBJECT_ID('dbo.TenFunctionCanTim');
   ```
   Caller càng nhiều → đòn bẩy càng cao (sửa 1 chỗ lợi lan toả tự động), nhưng cũng càng phải cẩn thận.
   Có thể tra nhanh không cần connect DB bằng cách `grep` toàn bộ [`Database/SQL/`](../Database/SQL/)
   (đã export sẵn toàn bộ 176 table + 531 store/function của `HR_SnK_Dev_260811`).

4. **Test bằng dữ liệu thật, đúng kịch bản đã báo lỗi/chậm** — không chỉ test "chạy không lỗi". Tìm 1
   bản ghi thật khớp đúng điều kiện đang xử lý, so before/after từng dòng dữ liệu (dùng `EXCEPT` cả 2
   chiều giữa snapshot cũ và kết quả mới để bắt chính xác từng khác biệt, không chỉ so số dòng).

5. **Sau khi sửa, LUÔN đo lại đúng object caller thực tế đang dùng — không chỉ đo function con vừa
   sửa riêng lẻ.** Xem cảnh báo ở mục C — 1 fix đo nhanh hơn khi test riêng vẫn có thể làm chậm hơn khi
   ghép vào query thật.

6. **Mọi thay đổi DB phải có file deploy đi kèm** trong `Database/DeployScripts/` (xem quy định ở
   `markdowns/INDEX.md`) vì DB local/DB đang connect chỉ là 1 bản, thay đổi trực tiếp trên đó không tự
   có trên server khác.

7. ⚠️ **Bẫy encoding khi chạy script chứa tiếng Việt**: `sqlcmd -i file.sql` (không kèm `-f 65001`) đọc
   sai codepage, làm hỏng NVARCHAR tiếng Việt **thật trong DB** (không phải lỗi hiển thị). Không dùng
   `sqlcmd -i` cho script có tiếng Việt. Dùng ADO.NET:
   ```powershell
   $text = [System.IO.File]::ReadAllText($ScriptPath, [System.Text.Encoding]::UTF8)
   $batches = [System.Text.RegularExpressions.Regex]::Split($text, '(?im)^\s*GO\s*$')
   $conn = New-Object System.Data.SqlClient.SqlConnection($connString); $conn.Open()
   foreach ($b in $batches) { if ($b.Trim()) { $cmd=$conn.CreateCommand(); $cmd.CommandText=$b; $cmd.ExecuteNonQuery() } }
   ```
   Sau khi chạy xong, luôn `grep` file export lại tìm ký tự `Ã|á»|â€"` (dấu hiệu mojibake) để xác nhận
   sạch trước khi coi là xong.

---

## C. Các pattern tổng quát (áp dụng cho object chưa gặp bao giờ)

### C1. Multi-statement TVF bị dùng như 1 hàm "tiện ích" nhỏ

**Triệu chứng:** function khai báo `RETURNS @X TABLE (...)` + `BEGIN...END` (multi-statement TVF —
MSTVF), thay vì `RETURNS TABLE AS RETURN (<1 câu SELECT>)` (inline TVF).

**Vì sao chậm:** SQL Server không inline được MSTVF vào query gọi nó — coi kết quả là 1 "hộp đen" với
số dòng ước lượng CỐ ĐỊNH, không dựa vào dữ liệu thật → optimizer hay chọn nested-loop quét lại toàn bộ
bảng phía ngoài 1 lần cho MỖI dòng kết quả của MSTVF. Nặng hơn nếu bên trong còn có `WHILE` (RBAR).

**Xác minh:** `SELECT type_desc FROM sys.objects WHERE name = 'TenFunction';` —
`SQL_TABLE_VALUED_FUNCTION` = nghi vấn, `SQL_INLINE_TABLE_VALUED_FUNCTION` = ổn. Rồi
`SET STATISTICS IO ON` gọi 1 caller thật, tìm bảng có `scan count` cao bất thường.

**Cách sửa chung:**
- Nếu thân hàm chỉ là **1 câu SELECT duy nhất** bọc trong MSTVF (không WHILE, không cursor, không
  DELETE/UPDATE sau INSERT) → chuyển thẳng SELECT đó vào `RETURN (...)`, xoá `BEGIN/END`/khai báo bảng
  trả về. Rủi ro gần như 0 — chỉ là đổi vỏ, không đổi 1 dòng logic.
- Nếu thân hàm dùng `WHILE` để tách chuỗi → xem code mẫu ở A1 (XML `nodes()`), hoặc `STRING_SPLIT()`
  nếu compat level ≥ 130.
- Nếu thân hàm có **cursor xử lý tuần tự thật** (quyết định ở bước N phụ thuộc bước N-1, không chỉ là
  SELECT/tách chuỗi đơn giản) → **không cố inline hoá**, xem Pattern C4.
- Nếu thân hàm gồm 1 `INSERT` + 1 `DELETE` theo sau (dạng "insert hết rồi lọc bớt") → CÓ THỂ gộp được
  thành 1 SELECT bằng CTE + `WHERE NOT EXISTS` thay cho DELETE, **NHƯNG cẩn thận: nếu CTE đó được
  tham chiếu nhiều lần (vd 1 lần ở SELECT chính, 1 lần correlated trong NOT EXISTS), SQL Server có thể
  tính lại toàn bộ CTE nhiều lần thay vì cache 1 lần** — nếu CTE đó nặng (gọi hàm con đắt tiền bên
  trong), cách này có thể LÀM CHẬM HƠN, không nhanh hơn. Phải đo lại bằng dữ liệu thật trước khi tin,
  đừng chỉ tin vào việc "cú pháp gọn hơn".

**⚠️ Bẫy khi apply:** inline TVF và MSTVF là 2 loại object khác nhau về metadata — `ALTER FUNCTION`
không convert được giữa 2 loại (`Msg 2010: Cannot perform alter... incompatible object type`). Phải
`DROP FUNCTION` rồi `CREATE FUNCTION` lại. Check permission trước khi drop
(`sys.database_permissions`).

**⚠️ Bẫy correctness khi thân hàm dùng `ROW_NUMBER()`/`RANK()` với `ORDER BY` không có tiebreaker duy
nhất:** nếu SELECT bên trong dùng `ROW_NUMBER() OVER (PARTITION BY ... ORDER BY colA, colB)` để lọc lấy
1 dòng đại diện (`WHERE rn=1`) mà `colA, colB` **không đủ để phân biệt duy nhất** mỗi dòng trong cùng
partition (vẫn có thể có 2+ dòng trùng y hệt colA/colB) — SQL Server chọn dòng nào là `rn=1` giữa các
dòng bị trùng (tie) là **không xác định theo chuẩn SQL**, phụ thuộc kế hoạch thực thi. Khi convert
MSTVF → inline TVF, kế hoạch thực thi có thể đổi (được inline vào ngữ cảnh query khác) → **tie-break ra
kết quả khác dù text SELECT giống hệt 100%**, dù trông như Pattern C1 "chỉ đổi vỏ, an toàn tuyệt đối".
**Bắt buộc verify bằng cách so sánh kết quả CŨ và MỚI tại CÙNG 1 thời điểm dữ liệu** (không so với
snapshot chụp trước đó nếu bảng nguồn có thể đã bị ghi đè — dựng lại logic cũ thành SELECT thô chạy
song song với hàm mới, cùng 1 lần, rồi `EXCEPT` 2 chiều) trước khi tin bất kỳ hàm nào dùng
`ROW_NUMBER`/`RANK` là an toàn để inline hoá. Nếu phát hiện lệch — đây là bug tiềm ẩn có sẵn từ bản gốc
(tie-break vốn đã không xác định), không phải do việc convert gây ra, nhưng **không tự ý sửa ORDER BY để
thêm tiebreaker** — chọn "bản ghi nào thắng khi trùng" là quyết định nghiệp vụ, cần xác nhận trước.
Case thực tế (`HR_KIDO_35`): `udf_BangPhepTheoNgay` — xem `Kido_New/markdowns/SQL_PERFORMANCE_HISTORY.md`.

---

### C2. Thiếu index cho cột lọc dùng trong tra cứu điểm (point-lookup)

**Triệu chứng:** 1 điều kiện `WHERE`/`JOIN` trên cột không phải leading-key của index nào → full scan
kể cả khi chỉ tìm 1 dòng.

**Xác minh:** `SET STATISTICS IO ON` → logical reads cao bất thường. Hoặc hỏi SQL Server:
```sql
SELECT mid.statement, mid.equality_columns, mid.included_columns, migs.avg_total_user_cost, migs.user_seeks
FROM sys.dm_db_missing_index_details mid
JOIN sys.dm_db_missing_index_groups mig ON mig.index_handle = mid.index_handle
JOIN sys.dm_db_missing_index_group_stats migs ON migs.group_handle = mig.index_group_handle
WHERE mid.[database_id] = DB_ID()
ORDER BY migs.avg_total_user_cost * migs.avg_user_impact * (migs.user_seeks + migs.user_scans) DESC;
```

**Cách sửa:** thêm nonclustered index hẹp đúng cột lọc, kèm `INCLUDE` đúng cột query thực sự `SELECT`
(covering index, tránh key lookup). **Luôn check index đã có sẵn trước** (`SELECT * FROM sys.indexes
WHERE object_id = OBJECT_ID('dbo.TenBang')`) — đừng tạo trùng.

---

### C3. Cursor/loop tra cứu lặp lại trên bảng tạm không có index

**Triệu chứng:** temp table tạo/đổ dữ liệu 1 lần mỗi vòng lặp ngoài, bị truy vấn nhiều lần trong vòng
lặp trong — nếu là heap (không index), mỗi truy vấn quét toàn bộ (dù bảng nhỏ, overhead dispatch cố
định cộng dồn qua hàng chục nghìn lần lặp).

**Cách sửa:**
1. `CREATE CLUSTERED INDEX` trên temp table ngay sau `CREATE TABLE`, theo đúng cột các truy vấn điểm
   bên trong loop dùng để lọc.
2. Gộp nhiều câu `SELECT @var = col FROM cungBang WHERE cungDieuKien` riêng lẻ (cùng bảng, cùng điều
   kiện) thành 1 câu `SELECT @var1=col1, @var2=col2, ... FROM ... WHERE ...` duy nhất.

---

### C4. Cursor RBAR "chính đáng" — không thể set-based hoá mà giữ nguyên logic

**Khi nào KHÔNG cố set-based hoá:** quyết định ở bước N phụ thuộc trạng thái tích luỹ từ bước 1..N-1
trong CÙNG 1 lần chạy (vd hạn mức còn lại sau khi các bước trước đã tiêu bớt) → không viết lại thành 1
query set-based duy nhất mà không đổi thuật toán/kết quả. Ép kiểu này = rủi ro cao, dễ sai kết quả
nghiệp vụ (đặc biệt code lương/OT/chấm công).

**Vẫn an toàn để làm** (không đụng logic quyết định): Pattern C3 (index cho bảng tạm, gộp select) để
giảm overhead mỗi vòng lặp.

**Đòn bẩy lớn hơn, rủi ro cao hơn — PHẢI xác nhận trước khi làm, không tự ý:** thay vì `INSERT`/
`UPDATE` trực tiếp vào bảng thật ngay trong từng vòng lặp, tích luỹ kết quả vào bảng tạm suốt vòng lặp
quyết định, rồi áp dụng bằng vài câu `UPDATE`/`INSERT` set-based 1 lần duy nhất sau khi vòng lặp kết
thúc. Ra kết quả giống hệt nếu làm đúng, nhưng đòi hỏi gộp đúng (SUM) các lần cùng 1 key bị chạm nhiều
lần trong 1 lần chạy — dễ sai nếu làm ẩu.

---

### C5. Scalar function bị gọi ngay trong điều kiện JOIN/WHERE

**Triệu chứng:** 1 scalar UDF (function trả về 1 giá trị đơn, không phải bảng) được gọi trực tiếp bên
trong điều kiện `ON`/`WHERE` của 1 JOIN, ví dụ `... on t1.Col = dbo.HamNaoDo(t2.ColA, t2.ColB)` hoặc
trong `BETWEEN dbo.HamA(...) AND dbo.HamB(...)`.

**Vì sao chậm:** ở compatibility level < 150, SQL Server **không tự động inline** scalar UDF (tính
năng "Scalar UDF Inlining" chỉ có từ compat level ≥150) — mỗi lần điều kiện JOIN được optimizer đánh
giá cho 1 cặp dòng ứng viên, scalar UDF chạy như 1 lệnh gọi riêng biệt kiểu RBAR. Với join có nhiều cặp
dòng ứng viên (hàng trăm nghìn tới hàng triệu), overhead cố định mỗi lần gọi cộng dồn thành số giây
đáng kể — dù bản thân logic bên trong hàm rất đơn giản (1 phép so sánh, 1 phép ghép chuỗi/ngày).
**`HR_SnK_Dev_260811` ở compat level 120 → pattern này áp dụng, mọi scalar UDF trong JOIN/WHERE đều
chạy RBAR.**

**Cách xác minh:** `SELECT compatibility_level FROM sys.databases WHERE name=DB_NAME()` → nếu <150,
mọi scalar UDF trong DB đều chạy kiểu RBAR khi dùng trong JOIN/WHERE, không có ngoại lệ. Tìm scalar UDF
đang bị gọi kiểu này: grep định nghĩa các object khác tìm `dbo.TenHam(` xuất hiện ngay sau `on`/`and`/
`between` trong điều kiện join.

**Cách sửa:** viết lại logic bên trong hàm thành 1 biểu thức T-SQL thuần (không gọi hàm), nhúng trực
tiếp vào chỗ đang gọi hàm. Với hàm đơn giản (so sánh, CASE, ghép ngày-giờ) việc này luôn khả thi và an
toàn — chỉ là "giải nén" logic, không đổi kết quả. **Bắt buộc verify bằng cách so sánh kết quả hàm gốc
với biểu thức thay thế trên hàng nghìn bộ input ngẫu nhiên** trước khi tin, vì các hàm xử lý ngày/giờ dễ
sai lệch ở biên (làm tròn giây/mili-giây, múi giờ, NULL...):
```sql
;WITH samples AS (
    SELECT TOP 2000 <sinh input ngau nhien phu hop mien gia tri cua ham> AS A, ... AS B
    FROM sys.all_objects a CROSS JOIN sys.all_objects b
)
SELECT COUNT(*) AS Mismatches FROM samples WHERE dbo.HamGoc(A,B) <> <bieu_thuc_thay_the>;
-- phai ra 0 truoc khi ap dung
```

**Lưu ý:** khác với Pattern C1 (MSTVF), việc này KHÔNG cần `DROP`/`CREATE` lại object nào — chỉ sửa nơi
ĐANG GỌI hàm (thường là 1 function/proc khác), giữ nguyên hàm scalar gốc (các nơi khác vẫn gọi bình
thường nếu chưa tiện sửa hết).

---

## D. Phân biệt "tối ưu hiệu năng" và "sửa lỗi logic nghiệp vụ"

Trong lúc tối ưu hiệu năng, có thể tình cờ phát hiện lỗi logic (không phải hiệu năng) — **đừng gộp 2
việc làm 1**. Ghi nhận riêng, xác nhận với người yêu cầu trước khi sửa, vì nó ảnh hưởng kết quả nghiệp
vụ trực tiếp — khác hẳn tối ưu hiệu năng thuần tuý (nguyên tắc: không đổi 1 dòng kết quả nào).

---

## E. ⚠️ Cảnh báo quan trọng: sửa nửa chừng 1 chuỗi MSTVF lồng nhau có thể làm CHẬM HƠN bản gốc

Đây là bài học phản trực giác, dễ mắc lại nếu không biết trước — trên `HR_KIDO_35` đã gặp **3 LẦN**
(2026-08-07 `udf_DangKyCa`, 2026-08-11 sáng `udf_TinhCong`, 2026-08-11 chiều `udf_BangPhepTheoNgay`/
`udf_PhepNamTheoThang`) — xem case cụ thể + số đo đầy đủ ở
`Kido_New/markdowns/SQL_PERFORMANCE_HISTORY.md` (không portable, chỉ tham khảo cách chẩn đoán).

**Tóm tắt quy tắc:** nếu 1 hàm gọi lồng N hàm MSTVF con, và bạn CHỈ sửa được M < N hàm (vì (N-M) hàm
còn lại có logic tuần tự thật/quá phức tạp, không inline hoá an toàn được) → **kết quả tổng thể có thể
chậm hơn bản gốc**, không chỉ đơn thuần "không cải thiện". Lý do: cardinality estimate không đồng đều
giữa các nhánh đã sửa (chính xác) và chưa sửa (vẫn sai, do MSTVF) khiến optimizer chọn join plan tệ hơn
cho toàn bộ query, dù từng hàm con đo riêng lẻ đều nhanh hơn rõ rệt. Đã đo được mức độ chậm đi có thể
RẤT LỚN trên `HR_KIDO_35` — không phải "chậm hơn 1 chút": lần thử đầu của case `udf_BangPhepTheoNgay`
2026-08-11 đi từ ~2 giây lên **>160 giây** (phải `KILL` session giữa chừng).

**Quy tắc hành động:**
1. Không tin số đo của 1 hàm con riêng lẻ là số đo cuối cùng của caller thực tế — luôn đo lại đúng cái
   đang thực sự được dùng (hàm ngoài cùng) SAU khi sửa.
2. **Đo TẤT CẢ các kịch bản gọi chính, không chỉ kịch bản đang nhắm tới sửa.** 1 fix có thể đúng logic
   100% (verify bằng diff không sai khác) và đo nhanh hơn rõ rệt cho kịch bản A (vd: lọc theo 1 nhân
   viên), nhưng vẫn làm sập hoàn toàn kịch bản B (vd: không lọc, chạy toàn công ty) nếu 2 kịch bản đi
   qua cùng 1 object đã sửa nhưng optimizer chọn plan khác nhau cho từng kịch bản. Trước khi báo "đã
   xong", liệt kê hết các kịch bản gọi thực tế khác nhau của object đang sửa (không chỉ đọc code — dùng
   cách chẩn đoán ở mục B.3 để tìm hết caller) và đo riêng từng kịch bản.
3. **Nếu convert MSTVF → inline TVF gây regression cho 1 kịch bản nào đó — trước khi rollback hoàn
   toàn, thử phương án "giữ nguyên MSTVF, chỉ sửa NỘI DUNG bên trong thân hàm"** (thêm điều kiện lọc,
   sửa `ORDER BY`, v.v. — không đổi khai báo `RETURNS @X TABLE`/`BEGIN...END` sang `RETURNS TABLE AS
   RETURN (...)`). Vì MSTVF luôn là "hộp đen" cố định với optimizer của CÂU QUERY GỌI NÓ bất kể logic
   nội bộ thay đổi gì, sửa nội dung bên trong 1 MSTVF (không đổi loại object) **không làm thay đổi
   cardinality estimate/query plan của nơi gọi nó** — tránh được chính xác loại regression ở mục này.
4. Với 1 chuỗi N hàm MSTVF lồng nhau mà THỰC SỰ cần convert sang inline (không chỉ sửa nội bộ): **sửa
   hết toàn bộ N hàm cùng lúc, hoặc không sửa gì cả** — tránh trạng thái sửa nửa vời.
5. Nếu đo được kết quả xấu đi sau khi sửa — rollback ngay, đừng cố "sửa thêm để bù" mà không hiểu rõ vì
   sao optimizer đổi plan (dễ sa vào việc đoán mò query hint để ép plan, rủi ro cao hơn lợi ích). Nếu đã
   thử cả quy tắc 3 (giữ MSTVF, sửa nội bộ) mà vẫn regression, và hàm cha quá lớn/phức tạp để sửa hết
   trong 1 lần (vd >100 dòng, hàng chục điểm gọi scalar function) — chấp nhận rollback toàn bộ, trừ khi
   có đủ thời gian điều tra kỹ execution plan (`SET STATISTICS XML ON`) để hiểu đúng nguyên nhân.
