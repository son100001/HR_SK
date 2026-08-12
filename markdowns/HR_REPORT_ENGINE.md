# ❤️ HR_Report – Trái tim của hệ thống (Report/Action Engine)

> **TL;DR:** `HR_Report` không chỉ là bảng chứa báo cáo. Đây là **bảng cấu hình trung tâm** mà gần như
> mọi màn hình nghiệp vụ (thông qua base class `HRFORM`) đọc vào để biết: *gọi cái gì* (function / store
> / table / code VB), *với tham số nào* (lấy từ control nào trên form), *xuất ra đâu* (Grid / Excel /
> Print / Word / Document theo template), và *ai được thấy nó* (qua `HR_ReportPermission`). Khoá để tra
> cứu 1 dòng cấu hình luôn là **`ReportCode`**.

> [!NOTE]
> **Nguồn gốc file này:** port và điều chỉnh từ `Kido_New/markdowns/HR_REPORT_ENGINE.md` (viết cho
> `HR_KIDO_35`) ngày 2026-08-12, vì `SmartBooks.HumanResource`/`WindowsControlLibrary` là cùng 1 bộ
> source code — cơ chế `HR_Report`/`HRFORM.ThucHien` hoạt động y hệt ở đây. Đã xác nhận bảng `HR_Report`
> tồn tại trong `HR_SnK_Dev_260811` (372 dòng cấu hình đang dùng thật) và `WindowsControlLibrary/HRFORM.vb`
> + `WindowsControlLibrary/Para/frmPara.vb` tồn tại trong repo này.
>
> **⚠️ Khác biệt đã phát hiện so với `HR_KIDO_35`:** bản `SnK_Dev` **không có** file
> `SmartBooks.HumanResource/Report/frmReport.vb` / `frmReportPermission.vb` — nghĩa là "cửa vào" #1 ở
> mục 5 dưới đây (màn hình menu Report dạng cây) **không tồn tại trong build này**. Chỉ còn "cửa vào" #2
> (nút hành động gắn trực tiếp trên từng form nghiệp vụ qua `HRFORM.ThucHien`) là đang hoạt động thật.
> Có thể do bản deploy cho khách hàng này đã bỏ màn hình Report riêng, hoặc tên file khác đi — nếu cần
> xác nhận, tìm bằng cách khác: `grep -r "HR_Report" SmartBooks.HumanResource/ --include=*.vb -l`.

> [!IMPORTANT]
> **Chú ý khi tối ưu DB (đọc trước khi chạy bất kỳ thay đổi DB nào):**
> DB đang thao tác qua kết nối trực tiếp (`113.161.180.44` / `HR_SnK_Dev_260811`) có tên gợi ý đây là
> bản **dev/snapshot** (hậu tố ngày `260811`), không chắc chắn là server thật khách hàng đang chạy —
> **xác nhận với người yêu cầu trước khi giả định** thay đổi có tự lan sang môi trường khác hay không.
> Dù ở môi trường nào, **nguyên tắc an toàn vẫn giữ nguyên**: mỗi lần thực hiện 1 thay đổi DB (đặc biệt
> là `CREATE INDEX`/`ALTER FUNCTION`/`ALTER PROCEDURE`), phải đồng thời tạo **1 file `.sql` deploy** trong
> [`Database/DeployScripts/`](../Database/DeployScripts/) chứa đúng câu lệnh đã chạy (có kiểm tra
> `IF NOT EXISTS`/`IF OBJECT_ID(...) IS NOT NULL` để chạy lại nhiều lần không lỗi, hoặc `CREATE OR ALTER`
> cho function/procedure), để dễ mang chạy lại ở môi trường khác nếu cần. Xem cách sửa cụ thể cho các
> object đã biết trong hệ thống này ở [SQL_PERFORMANCE_PLAYBOOK.md](SQL_PERFORMANCE_PLAYBOOK.md).

---

## 1. Vì sao gọi là "trái tim"

- **Không phải chỉ dùng cho màn hình Report** riêng biệt (bản `SnK_Dev` thậm chí không có màn hình đó,
  xem cảnh báo ở đầu file). Class cơ sở [`HRFORM.vb`](../WindowsControlLibrary/HRFORM.vb) — cha của
  **tất cả** các form nghiệp vụ (`frm*` trong `SmartBooks.HumanResource`) — đọc thẳng từ `HR_Report` để
  dựng danh sách nút "Thực hiện" / "Xem" / import-export Excel ngay trên từng form.
- Một dòng trong `HR_Report` đại diện cho **1 hành động gắn với 1 nút bấm cụ thể trên 1 form cụ thể**
  (`ReportFather` = tên class form, `ControlNameAction` = tên nút, `TabKey` = tab đang chọn nếu form có
  tab). (Ở bản có màn hình Report cây riêng như `HR_KIDO_35`, 1 dòng còn có thể đại diện cho 1 node menu
  Report — không áp dụng cho bản `SnK_Dev` nếu đã xác nhận không có `frmReport.vb`.)
- Vì vậy sửa/xoá nhầm 1 dòng `HR_Report`, hoặc đổi `ReportCode`, có thể làm "chết" tính năng ở rất
  nhiều màn hình khác nhau cùng lúc.

---

## 2. Sơ đồ luồng thực thi

```
                         ┌────────────────────────┐
                         │   HR_Report (1 dòng)    │   PK = ReportCode
                         │  NameOfFuntion / Store  │
                         │  / Table + Parameter    │
                         └────────────┬────────────┘
                                      │ tra theo ReportCode
                                      │      (hoặc ReportFather=Me.Name + TabKey + ControlNameAction)
                                      ▼
                         HRFORM.vb (mọi form nghiệp vụ kế thừa)
                              ThucHien(ReportCode) → new frmPara
                                      │
                         frmPara.ReportInformation = row
                         ShowDialog() thu tham số từ control
                                      │
                                      ▼
                      CreateQueryForReport() (trong frmPara)
             Ưu tiên: NameOfFuntion > NameOfStore > NameOfTable
             "select * from FN(...)" | "exec SP ..." | "select * from Table"
                                      │
        ┌──────────────────┬─────────┴─────────────────────┐
        ▼                  ▼                                ▼
   ViewOnGrid=1        PrintView=1 / PrintViewDocument=1     ExecSubOrFunctionOfVB=1
   → đổ ra Gridex       → nạp TemplateFile (Excel/Word),      → KHÔNG đụng DB qua HR_Report,
     trên form               map field theo BorderLine/         gọi thẳng Sub VB overridable
                              ConfigLine/HeaderLine/WriteLine     trong form con
                              rồi PrintReport / XuatFileWord
```

> Sơ đồ trên chỉ vẽ "cửa vào" #2 (mục 5) — cửa vào qua menu Report cây (`frmReport.vb`) đã bỏ trong bản
> `SnK_Dev`, xem cảnh báo đầu file.

---

## 3. Cấu trúc bảng `HR_Report`

DDL đầy đủ: [`Database/SQL/Tables/HR_Report.sql`](../Database/SQL/Tables/HR_Report.sql)
(`PRIMARY KEY CLUSTERED (ReportCode)`).

Nhóm cột theo vai trò thực tế đã xác nhận trong code:

### a. Định danh & vị trí trong cây / trong form
| Cột | Ý nghĩa |
|---|---|
| `ReportCode` | **Khoá chính**, mọi nơi trong code đều `.Select("ReportCode='...'")` để lấy 1 dòng. |
| `ReportFather` | **Tên class của form** (`Me.Name`) mà hành động này thuộc về — đây là cách `HRFORM.vb` biết "form này có những nút/report nào" (`WHERE ReportFather = Me.Name`). (Ở hệ thống có màn Report cây riêng, cột này còn dùng làm mã cha để dựng cây menu — không áp dụng ở bản `SnK_Dev`.) |
| `TabKey` | Nếu form có nhiều tab, chỉ định action này thuộc tab nào (`HRFORM.vb` filter thêm `AND TabKey=...`). |
| `ControlNameAction` | Tên control (nút) trên form kích hoạt report này, vd `'btnXem'`. |
| `OrderBy` | Thứ tự hiển thị trong cây/danh sách. |
| `NameVN/NameEN/NameKR` | Tên hiển thị theo ngôn ngữ (đa ngôn ngữ VN/EN/KR toàn hệ thống). |
| `NotUsing` | Cờ **soft-disable**: mọi query đọc `HR_Report` từ `HRFORM.vb` đều có `WHERE isnull(NotUsing,0)=0`. Muốn tắt 1 report/action mà không xoá dữ liệu → set `NotUsing=1`. |

### b. Nguồn dữ liệu thực thi (chọn 1 trong 3, theo đúng thứ tự ưu tiên trong code)
| Cột | Ý nghĩa | Query sinh ra |
|---|---|---|
| `NameOfFuntion` | Tên **table-valued function** | `select * from <NameOfFuntion> (<params>)` |
| `NameOfStore` | Tên **stored procedure** | `exec <NameOfStore> <params>` |
| `NameOfTable` | Tên **bảng** (dùng khi chỉ cần xem thẳng dữ liệu, không cần logic) | `select * from <NameOfTable>` (tự động `LEFT JOIN SmartBooks_Employee` nếu bảng có cột `Employee_ID`) |

> Thứ tự ưu tiên đúng như trong `frmPara.CreateQueryForReport()`: **Function → Store → Table**. Chỉ
> điền **đúng 1 trong 3 cột** này cho mỗi dòng để tránh nhầm lẫn.

### c. Tham số truyền vào (`Parameter`)
- `Parameter` (VD: `"txtdepartmentcode,txtfromdate,txttodate,cboMonth,cboYear"`) là **danh sách tên
  control trên form**, phân tách bởi dấu phẩy.
- Engine (logic trong `frmPara.vb`) sẽ:
  1. Duyệt toàn bộ control trên form theo đúng tên đã liệt kê.
  2. Tuỳ kiểu control để convert giá trị thành literal SQL an toàn theo kiểu:
     - `CalendarCombo` → `'yyyy-MM-dd HH:mm:ss'`
     - `MultiColumnCombo` → `N'...'`
     - `CheckBox` / `RadioButton` → `1` / `0`
     - `UIComboBox` (tháng/năm) → chuỗi số không có `N` prefix
  3. Ghép thành `strParameter` rồi nhúng thẳng vào câu `exec`/`select ... (...)`.
- `ParameterForm` / `ParameterFormNotShow`: nếu `ParameterFormNotShow = 1`, `HRFORM.ThucHien()` sẽ
  **bỏ qua** bước hiện dialog `frmPara` và thực thi thẳng (dùng cho action không cần người dùng nhập
  gì thêm).

> ⚠️ **Rủi ro bảo mật/hiệu năng đã ghi nhận:** tham số được nối chuỗi trực tiếp vào câu lệnh SQL
> (string concatenation), không dùng parameterized query/SqlParameter. Đây là điểm cần lưu ý khi audit
> SQL injection và cũng là nơi tối ưu performance (không tận dụng được plan cache theo tham số).

### d. Chế độ xuất kết quả (cờ bit, do `HRFORM.ThucHien()` rẽ nhánh)
| Cột | Khi = 1 thì làm gì |
|---|---|
| `ViewOnGrid` | Chạy query, đổ kết quả ra Gridex ngay trên form. |
| `ExecStore` | Đánh dấu chế độ chạy trực tiếp store (dùng ở UI cấu hình `frmPara`/`frmPara` designer). |
| `ExecSubOrFunctionOfVB` | **Bỏ qua hoàn toàn HR_Report/DB**, gọi thẳng `Sub ExecSubOrFunctionOfVB()` — 1 hàm `Overridable` khai báo ở `HRFORM.vb` mà từng form con override để chạy logic VB tuỳ biến. |
| `PrintView` | Xuất theo `TemplateFile` qua `PrintReport(...)`. |
| `PrinViewDocument` (+ `PrinViewDocument_Excel`, `PrintViewDocument_FieldKey`) | Xuất document in ấn theo danh sách key lấy từ các dòng đã tick trên grid (`PrintViewDocument_FieldKey` chỉ định cột nào là key). |
| `ExportDocumentFile` | Điền dữ liệu vào file Excel/Word mẫu (`DienGiaTriVaoKeyTrenFileExcel` / `XuatFileWord`) tuỳ `PrinViewDocument_Excel`. |
| `GetTemplateFile` | Cho phép tải template Excel mẫu về (dùng ở `frmPara`, nút "Lấy Template"). |
| `InputTemplateFile` | Cho phép nhập dữ liệu từ file Excel theo template (`NhapExcel` / `NhapExcelEPPlus`). |
| `SaveData` | Kết quả sẽ được ghi ngược lại DB (import) thay vì chỉ đọc. |
| `ExportExcel` | Cho export ra Excel từ grid. |
| `ManySheet` / `GroupBy` | Xuất Excel nhiều sheet / có group theo cột nào (danh sách cột, phân tách dấu phẩy). |

### e. Cấu hình layout khi đọc/ghi Excel theo Template (`TemplateFile`)
Các dòng dùng chung 1 file Excel mẫu (`.xlsx` trong thư mục `Teamleate`) với các mốc dòng cấu hình:

| Cột | Ý nghĩa |
|---|---|
| `TemplateFile` | Tên file Excel/Word mẫu. |
| `BorderLine` | Dòng kẻ khung/định dạng border. |
| `HeaderLine` | Dòng chứa header cột. |
| `ConfigLine` / `SaveConfigLine` / `PrimaryConfigLine` | Dòng khai báo mapping tên cột DB ↔ vị trí cột Excel (đọc khi export, và khi import ngược lại). |
| `WriteLine` | Dòng bắt đầu ghi dữ liệu. |
| `SelectField` | Danh sách field sẽ chọn ra để đổ vào Excel. |
| `ValueInExcelCell` | Giá trị cố định gán vào 1 ô cụ thể trên Excel. |
| `Excel_XoaDenDong` | Xoá dữ liệu cũ đến dòng nào trước khi ghi mới. |
| `FrozenColumn` | Số cột freeze trên Gridex khi hiển thị. |
| `InsertDateName` / `UserNameName` | Tên cột ngày tạo / người tạo sẽ tự set khi `NhapExcel` (import). |
| `NotDeleteConfig` | Không xoá dòng cấu hình khi ghi lại template. |

### f. Khác
| Cột | Ý nghĩa |
|---|---|
| `GridName` | Tên Gridex đích trên form (khi form có nhiều grid). |
| `Translate` | Có áp dụng cơ chế đa ngôn ngữ cho tiêu đề cột kết quả không. |
| `Filter` | Điều kiện WHERE bổ sung mặc định. |
| `LanguageForm` | Ngôn ngữ áp dụng riêng cho report này (khác ngôn ngữ hệ thống nếu cần). |
| `Remark` | Ghi chú nội bộ cho dev/BA, không dùng trong logic. |
| `InsertDate` / `UserName` | Audit — ai tạo, khi nào (không phải tham số truyền vào query). |

---

## 4. Phân quyền – `HR_ReportPermission` + `udf_GetReportByPermission`

- Bảng [`HR_ReportPermission`](../Database/SQL/Tables/HR_ReportPermission.sql):
  `PRIMARY KEY (User_, ReportCode)` — quan hệ nhiều-nhiều giữa user và report được phép xem.
- Function [`udf_GetReportByPermission(@User)`](../Database/SQL/Functions/InlineTableValued/udf_GetReportByPermission.sql):
  ```sql
  select r.*, rp.[User_]
  from HR_Report r
  left join (select * from HR_ReportPermission where User_=@User) rp
    on rp.ReportCode = r.ReportCode
  ```
  → trả về **toàn bộ** `HR_Report`, kèm cột `User_` chỉ khác NULL nếu user hiện tại có quyền — join rồi
  lọc theo NULL/không-NULL ở tầng gọi. Ở hệ thống có màn Report cây riêng, UI chỉ add node vào TreeView
  khi `User_` không NULL (lọc ở tầng UI, không lọc ở SQL — cần lưu ý khi audit hiệu năng: kéo hết
  `HR_Report` về client mỗi lần dùng). Bản `SnK_Dev` không có `frmReport.vb` nên cần kiểm tra lại nơi
  nào khác trong code đang gọi function này trước khi giả định cùng cách dùng.
- SP lưu quyền: [`usp_InsertUpdateHR_ReportPermission`](../Database/SQL/StoredProcedures/usp_InsertUpdateHR_ReportPermission.sql).

---

## 5. "Cửa" gọi vào HR_Report

| Cửa vào | File | Khi nào dùng | Có trong `SnK_Dev`? |
|---|---|---|---|
| Menu Report cây | `SmartBooks.HumanResource/Report/frmReport.vb` | Người dùng mở màn "Report" riêng, chọn node trên TreeView | ❌ **Không tìm thấy file này trong repo `SnK_Dev`** |
| Nút hành động trên từng form nghiệp vụ | [`WindowsControlLibrary/HRFORM.vb`](../WindowsControlLibrary/HRFORM.vb) `Sub ThucHien(rc As String)` | Mọi form kế thừa `HRFORM` (Payroll, TimeKeeping, EmployeeInfo, …) gọi `ThucHien(ReportCode)` khi bấm nút → tra `HR_Report` theo `ReportCode` (hoặc theo `ReportFather=Me.Name` + `TabKey` + `ControlNameAction`), mở `frmPara` ([`WindowsControlLibrary/Para/frmPara.vb`](../WindowsControlLibrary/Para/frmPara.vb)) để thu tham số rồi rẽ nhánh theo các cờ ở mục 3.d. | ✅ Có, đây là cửa vào chính (duy nhất đã xác nhận) |

---

## 6. Checklist khi thêm 1 report/action mới

1. Viết function/store/table trong DB trước (không được điền cả 3 cột `NameOfFuntion`/`NameOfStore`/`NameOfTable` — chỉ 1).
2. Tham số của function/store phải **đúng thứ tự** với thứ tự tên control liệt kê trong `Parameter`
   (engine build tham số theo thứ tự duyệt, không theo tên).
3. Set `ReportFather` = đúng tên class form (`Me.Name`), set `ControlNameAction` = tên nút, set `TabKey`
   nếu form có tab.
4. Chọn đúng 1 cờ output ở mục 3.d — không set nhiều cờ mâu thuẫn (`ViewOnGrid` vs `PrintView` vs
   `ExecSubOrFunctionOfVB`...).
5. Nếu cần chạy code VB thuần (không qua DB): set `ExecSubOrFunctionOfVB = 1` và override
   `Sub ExecSubOrFunctionOfVB()` trong form con.
6. Cấp quyền cho user/role tương ứng qua `HR_ReportPermission` nếu màn hình quản trị quyền tồn tại
   trong bản này (chưa xác nhận — xem mục 5).
7. Muốn tắt tạm thời: set `NotUsing = 1`, không xoá dòng (xoá sẽ ảnh hưởng các form đang tham chiếu
   `ReportCode` đó).

---

## 7. Phụ lục: `udf_EmployeeFilter` – hàm nền tảng dữ liệu nhân viên

> Hầu hết các dòng `HR_Report` có `NameOfStore`/`NameOfFuntion` trỏ tới 1 store/function nghiệp vụ, và
> **tuyệt đại đa số các store/function đó lại gọi vào `[dbo].[udf_EmployeeFilter]` để lấy dữ liệu nhân
> viên** (tên phòng ban/tổ/chức vụ đã join sẵn theo ngôn ngữ, bậc tay nghề mới nhất, hazard, v.v.). Trên
> `HR_KIDO_35` đã kiểm chứng: **58 object gọi thẳng `udf_EmployeeFilter`** (10 function + 48 stored
> procedure). Vì `SnK_Dev` dùng chung source code, con số này nhiều khả năng tương tự — nhưng **chưa
> đếm lại trên `HR_SnK_Dev_260811`**, chạy lại truy vấn ở mục B.3 của
> [SQL_PERFORMANCE_PLAYBOOK.md](SQL_PERFORMANCE_PLAYBOOK.md) để xác nhận số thật của DB này trước khi
> dùng con số 58 làm căn cứ.

DDL: [`Database/SQL/Functions/TableValued/udf_EmployeeFilter.sql`](../Database/SQL/Functions/TableValued/udf_EmployeeFilter.sql)
– tham số `@LAN, @fact, @dept, @sect, @team, @pos, @posc, @Empl, @Date`, trả về 1 dòng/nhân viên đã join
sẵn Factory/Department/Section/Team/Position/PositionCategory/ChucDanh/JobCodeCategory/HazardCategory và
bậc tay nghề mới nhất (`HR_BacTayNgheNhanVien`, lấy theo `FromDate` gần nhất qua `ROW_NUMBER()`).

> ⚠️ Trên `HR_KIDO_35` có 3 bản backup không dùng (`udf_EmployeeFilterbk`, `udf_EmployeeFilterBk1`,
> `udf_EmployeeFilter_short`) — kiểm tra `HR_SnK_Dev_260811` có tồn tại các bản backup tương tự không
> (`SELECT name FROM sys.objects WHERE name LIKE 'udf_EmployeeFilter%'`) nếu muốn dọn dẹp.

### 7.1. Trạng thái hiện tại trên `HR_SnK_Dev_260811` (đối chiếu 2026-08-12) — CHƯA tối ưu

Khác với `HR_KIDO_35` (đã tối ưu ngày 2026-08-04, xem `Kido_New/markdowns/HR_REPORT_ENGINE.md` mục 7.1
và `Kido_New/Database/DeployScripts/2026-08-04_Optimize_udf_EmployeeFilter_dependencies.sql`),
**`HR_SnK_Dev_260811` vẫn ở trạng thái CHƯA sửa**:
- `dbo.Split` **vẫn là multi-statement TVF** (vòng lặp `WHILE`) — cùng vấn đề cardinality estimate sai
  khi lọc nhiều factory đã mô tả trong playbook mục A1.
- `dbo.SmartBooks_Employee` **chưa có** index trên `ID_number` — cùng vấn đề full scan khi tra theo
  CMND/CCCD đã mô tả trong playbook mục A2.

Cách sửa (an toàn, đã verify tương thích ngược trên `HR_KIDO_35`): xem
[SQL_PERFORMANCE_PLAYBOOK.md](SQL_PERFORMANCE_PLAYBOOK.md) mục A1 + A2. Nếu áp dụng lên
`HR_SnK_Dev_260811`, nhớ đo trước/sau bằng `SET STATISTICS IO/TIME ON` theo đúng quy trình mục B, tạo
deploy script trong `Database/DeployScripts/`, và ghi lại kết quả vào
[SQL_PERFORMANCE_HISTORY.md](SQL_PERFORMANCE_HISTORY.md) (không phải file history của Kido).

### 7.2. Rủi ro/điểm cần lưu ý còn tồn đọng (chưa sửa, cần quyết định nghiệp vụ)

- **Tham số `@Date` không được dùng ở đâu cả** trong thân hàm hiện tại (đã xác nhận trên bản `HR_KIDO_35`
  — cần đọc lại thân hàm thật của `HR_SnK_Dev_260811` để xác nhận có giống không, xem
  [`udf_EmployeeFilter.sql`](../Database/SQL/Functions/TableValued/udf_EmployeeFilter.sql)). Nếu giống,
  nghĩa là hàm **trả về cả nhân viên đã nghỉ việc** bất kể `@Date` truyền vào là gì — không tự ý thêm
  filter này vì sẽ đổi kết quả của mọi caller, cần người nắm nghiệp vụ xác nhận trước.
- Tham số truyền vào `udf_EmployeeFilter` (và nhiều store khác) được **nối chuỗi trực tiếp vào câu lệnh
  SQL** ở tầng gọi (`frmPara.vb` — xem mục 3.c), không qua `SqlParameter`. Đây là điểm cần rà soát SQL
  injection nếu dữ liệu đầu vào (vd ô lọc tự do) không được kiểm soát chặt ở UI.

---

## 8. Tham chiếu nhanh mã nguồn

| Nội dung | File |
|---|---|
| DDL bảng `HR_Report` | [`Database/SQL/Tables/HR_Report.sql`](../Database/SQL/Tables/HR_Report.sql) |
| DDL bảng `HR_ReportPermission` | [`Database/SQL/Tables/HR_ReportPermission.sql`](../Database/SQL/Tables/HR_ReportPermission.sql) |
| Function lọc theo quyền | [`Database/SQL/Functions/InlineTableValued/udf_GetReportByPermission.sql`](../Database/SQL/Functions/InlineTableValued/udf_GetReportByPermission.sql) |
| SP lưu quyền | [`Database/SQL/StoredProcedures/usp_InsertUpdateHR_ReportPermission.sql`](../Database/SQL/StoredProcedures/usp_InsertUpdateHR_ReportPermission.sql) |
| Engine gắn vào form nghiệp vụ | [`WindowsControlLibrary/HRFORM.vb`](../WindowsControlLibrary/HRFORM.vb) (`Sub ThucHien`) |
| Form tham số dùng chung | [`WindowsControlLibrary/Para/frmPara.vb`](../WindowsControlLibrary/Para/frmPara.vb) (`ReportInformation`, `CreateQueryForReport`) |
| Hàm nền tảng dữ liệu nhân viên | [`Database/SQL/Functions/TableValued/udf_EmployeeFilter.sql`](../Database/SQL/Functions/TableValued/udf_EmployeeFilter.sql) |
| Hàm tách chuỗi dùng chung (chưa tối ưu ở đây) | [`Database/SQL/Functions/TableValued/Split.sql`](../Database/SQL/Functions/TableValued/Split.sql) |
| Bảng nhân viên gốc | [`Database/SQL/Tables/SmartBooks_Employee.sql`](../Database/SQL/Tables/SmartBooks_Employee.sql) |
