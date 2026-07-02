# Quy Trình Xử Lý & Tối Ưu Nhập Excel — ThuVienChucNang.vb

> **Phạm vi áp dụng:** Dự án VB.NET WinForms có thư viện hàm dùng chung (`ThuVienChucNang`), SQL Server, EPPlus cho `.xlsx`, kết nối DB qua lớp `connect` (hoặc tương đương).  
> **Tệp gốc được sửa:** `WindowsControlLibrary/Library/ThuVienChucNang.vb`  
> **Ngày thực hiện:** 2026-06-27

---

## Mục lục

1. [Tổng quan hai công việc](#1-tổng-quan)
2. [Công việc 1 — NhapExcelToDatableEPPlus: Hỗ trợ thêm .xls](#2-công-việc-1)
3. [Công việc 2 — NhapExcelEPPlus: Tăng tốc](#3-công-việc-2-nhapexcelepplusr)
4. [Công việc 2 — NhapExcel(SheetName): Sửa lỗi XlsReport + tăng tốc](#4-công-việc-2-nhapexcel-sheetname)
5. [Helper mới: TaoSQLKhongGhiLog](#5-helper-taosqlkhongghilog)
6. [Checklist áp dụng sang project khác](#6-checklist)
7. [Các lưu ý quan trọng](#7-lưu-ý-quan-trọng)

---

## 1. Tổng quan

| # | Hàm | Vấn đề gốc | Giải pháp |
|---|-----|-----------|-----------|
| 1 | `NhapExcelToDatableEPPlus` | Chỉ đọc được `.xlsx`; chọn `.xls` → crash | Thêm nhánh OleDb cho `.xls` |
| 2 | `NhapExcelEPPlus` | Chậm: tra kiểu cột O(n) mỗi ô, gọi DB mỗi dòng | Dictionary O(1), đọc config 1 lần, batch SQL 100 dòng/lần |
| 3 | `NhapExcel(SheetName,...)` | Dùng `XlsReport` không đọc được dữ liệu; `Xls.Out.File()` ghi đè file nguồn gây mất dữ liệu | Thay hoàn toàn bằng OleDb; bỏ `Xls.Out.File()`; thêm batch SQL |

**Hàm hỗ trợ mới thêm:** `TaoSQLKhongGhiLog` — tái sử dụng logic SQL của `LuuKhongGhiLog` nhưng trả về `String` thay vì gọi DB trực tiếp, cho phép gom batch.

---

## 2. Công việc 1 — NhapExcelToDatableEPPlus: Hỗ trợ thêm .xls

### 2.1 Nơi được gọi

```
HRForm.vb → importExcel_Click()
    └─► tvcn.NhapExcelToDatableEPPlus(HRFORM_TableName, 6, 11)
```

Tham số: `TableName`, `LineConfigDatamember` (dòng chứa tên field), `LineStart` (dòng bắt đầu dữ liệu).

### 2.2 Vấn đề gốc

```vb
' CŨ: filter chỉ cho .xlsx
.Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"

' Toàn bộ xử lý dùng EPPlus — EPPlus không hỗ trợ định dạng .xls (Excel 97-2003)
Dim excel As New FileInfo(ofd.FileName)
Using package = New ExcelPackage(excel)   ' → NullReferenceException với .xls
```

### 2.3 Giải pháp

**Bước 1 — Cập nhật filter:**
```vb
.Filter = "Excel file (*.xlsx;*.xls)|*.xlsx;*.xls|Excel 2007+ (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*"
```

**Bước 2 — Tách nhánh theo extension:**
```vb
Dim fileExt As String = IO.Path.GetExtension(ofd.FileName).ToLower()

If fileExt = ".xls" Then
    ' ── Nhánh OleDb ──
    Dim provider As String = If(Environment.Is64BitProcess,
                                "Microsoft.ACE.OLEDB.12.0",
                                "Microsoft.Jet.OLEDB.4.0")
    Dim connStr As String = "Provider=" & provider &
                            ";Data Source=" & ofd.FileName &
                            ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"
    Dim xlsData As New DataTable
    Using conn As New System.Data.OleDb.OleDbConnection(connStr)
        conn.Open()
        ' Lấy tên sheet đầu tiên tự động (không hardcode)
        Dim dtSchema As DataTable = conn.GetOleDbSchemaTable(
            System.Data.OleDb.OleDbSchemaGuid.Tables, Nothing)
        Dim firstSheet As String = CStr(dtSchema.Rows(0)("TABLE_NAME"))
        Using adapter As New System.Data.OleDb.OleDbDataAdapter(
                "SELECT * FROM [" & firstSheet & "]", conn)
            adapter.Fill(xlsData)
        End Using
    End Using
    ' ... xử lý xlsData (xem Mục 2.4) ...
Else
    ' ── Nhánh EPPlus (giữ nguyên logic cũ) ──
    Dim excel As New FileInfo(ofd.FileName)
    Using package = New ExcelPackage(excel)
        ' ... logic cũ ...
    End Using
End If
```

### 2.4 Ánh xạ chỉ số dòng/cột trong OleDb

Với `HDR=NO`:
- Cột Excel A, B, C... → `xlsData.Columns` index 0, 1, 2... (không có tên cột gốc)
- Dòng Excel N (1-based) → `xlsData.Rows(N-1)` (0-based)
- Dòng config: `dmRowIdx = LineConfigDatamember - 1`
- Dòng dữ liệu bắt đầu: `index = LineStart`, dòng thực trong DataTable = `index - 1`

```vb
Dim dmRowIdx As Integer = LineConfigDatamember - 1
Dim index As Integer = LineStart   ' chạy từ LineStart, rowIdx = index - 1

While 1 = 1
    Dim rowIdx As Integer = index - 1
    If rowIdx >= xlsData.Rows.Count Then Exit While
    ' kiểm tra dòng có dữ liệu không...
    For ColIndex = 0 To Math.Min(ColExel.Length, xlsData.Columns.Count) - 1
        ' Đọc tên field từ dòng config
        Dim configCell As Object = xlsData.Rows(dmRowIdx)(ColIndex)
        Dim fieldName As String = CStr(If(IsDBNull(configCell), "", configCell)).Trim()
        ' Đọc giá trị dữ liệu
        Dim dataVal As Object = xlsData.Rows(rowIdx)(ColIndex)
        ' ...
    Next
    index += 1
End While
```

### 2.5 Xử lý kiểu DateTime trong OleDb

OleDb trả về DateTime theo 3 cách tùy nguồn ô:

```vb
Dim dtParsed As DateTime = New DateTime(1900, 1, 1)
If TypeOf dataVal Is DateTime Then
    dtParsed = CType(dataVal, DateTime)
ElseIf TypeOf dataVal Is Double Then
    ' Excel lưu ngày dưới dạng số OLE Automation
    dtParsed = DateTime.FromOADate(CDbl(dataVal))
Else
    DateTime.TryParse(CStr(dataVal), dtParsed)
End If
If dtParsed.Year > 1900 Then newRow(fieldName) = dtParsed
```

### 2.6 Provider OleDb theo bitness

| Môi trường | Provider |
|-----------|---------|
| x86 (32-bit process) | `Microsoft.Jet.OLEDB.4.0` |
| x64 (64-bit process) | `Microsoft.ACE.OLEDB.12.0` |

```vb
Dim provider As String = If(Environment.Is64BitProcess,
                            "Microsoft.ACE.OLEDB.12.0",
                            "Microsoft.Jet.OLEDB.4.0")
```

> **Yêu cầu:** Máy tính phải cài **Microsoft Access Database Engine** (ACE) tương ứng với bitness của ứng dụng. Tải miễn phí từ Microsoft nếu chưa có.

---

## 3. Công việc 2 — NhapExcelEPPlus: Tăng tốc

### 3.1 Nơi được gọi

```
frmPara.vb → btnOk_Click()
    └─► ElseIf InputTemplateFile.Checked = True Then
            If ofd.FileName.Contains(".xlsx") Then
                tvcn.NhapExcelEPPlus(TableName, ofd.FileName, ConfigLine, PrimaryConfigLine, WriteLine, ...)
```

### 3.2 Vấn đề gốc — 3 điểm chậm

**Điểm chậm 1: Tra kiểu cột bằng `tableInf.Select()` mỗi ô**
```vb
' CŨ — O(n) mỗi lần gọi, n = số dòng trong tableInf
tableInf.Select("COLUMN_NAME='" + Datamember(i) + "'")(0)("DATA_TYPE")
```
Với 500 dòng × 20 cột = 10.000 lần gọi `Select()`, mỗi lần duyệt toàn bộ DataTable.

**Điểm chậm 2: Gọi DB mỗi dòng**
```vb
' CŨ — mỗi dòng Excel = 1 lần gọi kn.SaveData()
LuuKhongGhiLog(...)   ' → 1 round-trip SQL Server
```

**Điểm chậm 3: Đọc lại config row mỗi vòng lặp**
```vb
' CŨ — worksheet.Cells() được gọi lại liên tục cho dòng config
worksheet.Cells(ColExel(i) + LineConfigDatamember.ToString()).Text  ' trong mỗi vòng dữ liệu
```

### 3.3 Giải pháp

**Fix 1: Dictionary O(1) thay cho `tableInf.Select()`**
```vb
' MỚI — xây 1 lần trước vòng lặp
Dim colTypeMap As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
For Each row As DataRow In tableInf.Rows
    Dim cname As String = CStr(row("COLUMN_NAME"))
    If Not colTypeMap.ContainsKey(cname) Then
        colTypeMap(cname) = CStr(row("DATA_TYPE"))
    End If
Next

' Dùng trong vòng lặp:
Dim dmType As String = ""
colTypeMap.TryGetValue(Datamember(i), dmType)   ' O(1)
```

**Fix 2: Đọc config row 1 lần, cache vào array**
```vb
' Đọc 1 lần trước vòng lặp dữ liệu
Dim strDmNames As New List(Of String)
Dim strDmCols  As New List(Of String)
For Each c As String In ColExel
    Dim cellVal As String = worksheet.Cells(c + LineConfigDatamember.ToString()).Text.Trim()
    If cellVal <> "" AndAlso colTypeMap.ContainsKey(cellVal) Then
        strDmNames.Add(cellVal)
        strDmCols.Add(c)
    End If
Next
Dim Datamember()    As String = strDmNames.ToArray()
Dim ColDatamember() As String = strDmCols.ToArray()

' Cache tên cột để xử lý bảng đặc biệt (không gọi worksheet.Cells trong vòng lặp)
Dim configColName(ColDatamember.Length - 1) As String
For i As Integer = 0 To ColDatamember.Length - 1
    configColName(i) = worksheet.Cells(ColDatamember(i) + LineConfigDatamember.ToString()).Text.ToUpper().Trim()
Next
```

**Fix 3: Batch SQL — 100 dòng/1 lần gọi DB**
```vb
Dim sb As New StringBuilder()
Dim batchCount As Integer = 0
Const BATCH_SIZE As Integer = 100

' Trong vòng lặp:
Dim rowSql As String = TaoSQLKhongGhiLog(False, TableName, Primary,
                            Primary_Value.ToArray(), Datamember, Datamember_Value.ToArray())
sb.AppendLine(rowSql)
batchCount += 1
If batchCount >= BATCH_SIZE Then
    kn.SaveData(sb.ToString())   ' 1 round-trip = 100 dòng
    sb.Clear()
    batchCount = 0
End If

' Sau vòng lặp — flush phần còn lại
If batchCount > 0 Then kn.SaveData(sb.ToString())
```

### 3.4 Ngoại lệ: Bảng cần CheckingBlock — dùng LuuKhongGhiLog từng dòng

Một số bảng có logic nghiệp vụ đặc biệt bên trong `LuuKhongGhiLog` (gọi `CheckingBlock` kiểm tra xung đột ca làm việc, nghỉ phép...). Những bảng này **không được** dùng batch, phải xử lý từng dòng:

```vb
Dim needsPerRowCheck As Boolean = (
    String.Equals(TableName, "HR_WTDaily", StringComparison.OrdinalIgnoreCase) OrElse
    String.Equals(TableName, "HR_TimeKeeping_Data", StringComparison.OrdinalIgnoreCase) OrElse
    String.Equals(TableName, "HR_EmpRegisLeave", StringComparison.OrdinalIgnoreCase) OrElse
    String.Equals(TableName, "HR_EmployeeRegisMaternityLeave", StringComparison.OrdinalIgnoreCase))

' Trong vòng lặp:
If needsPerRowCheck Then
    LuuKhongGhiLog(False, TableName, Primary, Primary_Value.ToArray(),
                   Datamember, Datamember_Value.ToArray())
Else
    ' dùng batch SQL qua TaoSQLKhongGhiLog
End If
```

> **Khi áp dụng sang project khác:** Điều chỉnh danh sách tên bảng trong `needsPerRowCheck` cho phù hợp với nghiệp vụ của project đó.

---

## 4. Công việc 2 — NhapExcel(SheetName): Sửa lỗi XlsReport + tăng tốc

### 4.1 Nơi được gọi

```
frmPara.vb → btnOk_Click()
    └─► ElseIf InputTemplateFile.Checked = True Then
            ElseIf ofd.FileName.Contains(".xls") Then
                tvcn.NhapExcel("Sheet1", TableName, ofd.FileName, ConfigLine, PrimaryConfigLine, WriteLine, ...)
```

### 4.2 Lỗi gốc: XlsReport không đọc được + ghi đè file nguồn

```vb
' CŨ — Dùng thư viện VBReport (XlsReport) vốn là thư viện TẠO báo cáo, không phải đọc dữ liệu
Dim Xls As New XlsReport
Xls.TemplateFile = LinkOfFile
Xls.Open()
' ... đọc giá trị từ Xls.ReportWorkBook ... (trả về Nothing hoặc định dạng sai)
Xls.Out.File(urlTemplate)   ' ← GHI ĐÈ file .xls nguồn! Mất dữ liệu gốc.
```

**Hậu quả:** Sau khi nhập, file `.xls` gốc bị format lại theo template báo cáo — không thể nhập lần 2.

### 4.3 Giải pháp: Thay hoàn toàn bằng OleDb

```vb
' MỚI — Đọc toàn bộ sheet vào DataTable một lần bằng OleDb
Dim provider As String = If(Environment.Is64BitProcess,
                            "Microsoft.ACE.OLEDB.12.0",
                            "Microsoft.Jet.OLEDB.4.0")
Dim connStr As String = "Provider=" & provider &
                        ";Data Source=" & LinkOfFile &
                        ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"
Dim xlsData As New DataTable
Using conn As New System.Data.OleDb.OleDbConnection(connStr)
    conn.Open()
    ' Đọc sheet theo tên (SheetName là tham số truyền vào, vd: "Sheet1")
    Using adapter As New System.Data.OleDb.OleDbDataAdapter(
            "SELECT * FROM [" & SheetName & "$]", conn)
        adapter.Fill(xlsData)
    End Using
End Using
' Không có Xls.Out.File() — file nguồn được giữ nguyên hoàn toàn
```

### 4.4 Xây dựng column map từ dòng config

```vb
Dim dmRowIdx As Integer = LineConfigDatamember - 1
Dim pkRowIdx As Integer = LineConfigPrimary - 1

Dim strDmNames As New List(Of String)
Dim strDmColIdx As New List(Of Integer)   ' chỉ số cột integer thay vì chữ cái Excel
Dim strPkNames As New List(Of String)
Dim strPkColIdx As New List(Of Integer)

For j As Integer = 0 To xlsData.Columns.Count - 1
    Dim cellVal As String = CStr(If(IsDBNull(xlsData.Rows(dmRowIdx)(j)), "",
                                    xlsData.Rows(dmRowIdx)(j))).Trim()
    If cellVal <> "" AndAlso colTypeMap.ContainsKey(cellVal) Then
        strDmNames.Add(cellVal)
        strDmColIdx.Add(j)
    End If
Next
```

### 4.5 Điều kiện dừng vòng lặp (tránh lặp vô tận)

```vb
Dim isDataNull As Integer = 0
Dim currentRowIdx As Integer = LineStart - 1   ' 0-based

While currentRowIdx < xlsData.Rows.Count
    Dim pkCellStr As String = CStr(If(IsDBNull(xlsData.Rows(currentRowIdx)(ColPkIdx(0))),
                                      "", xlsData.Rows(currentRowIdx)(ColPkIdx(0)))).Trim()
    If pkCellStr = String.Empty Then
        isDataNull += 1
        If isDataNull >= 2 Then Exit While   ' 2 dòng trống liên tiếp → dừng
        currentRowIdx += 1
        Continue While
    End If
    isDataNull = 0
    ' ... xử lý dòng dữ liệu ...
    currentRowIdx += 1
End While
```

---

## 5. Helper TaoSQLKhongGhiLog

### 5.1 Mục đích

`LuuKhongGhiLog` xây SQL `IF EXISTS/UPDATE/INSERT` và gọi DB ngay trong 1 lần. Hàm này tốt cho từng dòng nhưng không thể dùng cho batch.

`TaoSQLKhongGhiLog` tách phần **xây SQL** ra, trả về `String` thay vì gọi DB, cho phép gom nhiều câu SQL rồi gửi 1 lần.

### 5.2 Khai báo

```vb
Private Function TaoSQLKhongGhiLog(
        ByVal bInsertAndUpdateIsSame As Boolean,
        ByVal TableName As String,
        ByVal Primary() As String,
        ByVal Primary_Value As Object(),
        ByVal DataMember() As String,
        ByVal DataMember_Value() As Object) As String
    ' ... (logic giống LuuKhongGhiLog nhưng Return str_sql thay vì kn.SaveData) ...
End Function
```

### 5.3 SQL được tạo ra

```sql
-- Dạng thông thường:
IF EXISTS(SELECT * FROM [dbo].[TableName] WHERE [PK1]=... AND [PK2]=...)
BEGIN
    UPDATE [dbo].[TableName] SET [Col1]=..., [Col2]=... WHERE [PK1]=... AND [PK2]=...
END
ELSE BEGIN
    INSERT INTO [TableName] ([Col1],[Col2],...) VALUES (...)
END

-- Bảng SmartBooks_Salary — bọc thêm điều kiện trangthai:
IF NOT EXISTS(SELECT * FROM [dbo].[SmartBooks_Salary] WHERE ... AND trangthai=1)
BEGIN
    IF EXISTS(...) BEGIN UPDATE ... END ELSE BEGIN INSERT ... END
END
```

### 5.4 Vị trí đặt trong file

Đặt **ngay sau** `End Function` của `LuuKhongGhiLog` và **trước** `SaveByStore`. Giữ cùng Region `#Region "SAVE TO TABLE"`.

### 5.5 Xử lý kiểu dữ liệu đặc biệt

| Kiểu | Xử lý |
|------|-------|
| `Nothing` | → `null` |
| `String` rỗng hoặc `"NULL"` | → `null` |
| `String` có nội dung | → `N'...'` (escape dấu `'` thành `''`) |
| `Boolean` True | → `1` |
| `Boolean` False | → `0` |
| `DateTime` năm 1, 1900, 1753 | → `null` |
| `DateTime` hợp lệ | → `'yyyy-MM-dd HH:mm:ss'` |
| Số (Double, Int...) | → `'value'` |
| `DBNull` | → `null` |

---

## 6. Checklist áp dụng sang project khác

### 6.1 Điều kiện tiên quyết

- [ ] Project dùng VB.NET WinForms, .NET Framework 4.x
- [ ] Có stored procedure `sp_GetAllInformationInTable` trong SQL Server trả về: `COLUMN_NAME`, `DATA_TYPE`, `IS_NULLABLE`, `IdentityName`
- [ ] Có lớp kết nối DB với hàm:
  - `ReadData(sql, "table")` → `DataTable`
  - `SaveData(sql)` → `Boolean` (hỗ trợ multi-statement T-SQL trong 1 batch)
- [ ] EPPlus được tham chiếu trong project (NuGet: `EPPlus` ≤ 4.x cho .NET Framework)
- [ ] Máy chạy ứng dụng có cài **Microsoft Access Database Engine** phù hợp bitness

### 6.2 Các bước sao chép sang project mới

**Bước 1:** Copy hàm `TaoSQLKhongGhiLog` vào thư viện hàm dùng chung (tương đương `ThuVienChucNang`), đặt sau `LuuKhongGhiLog`.

**Bước 2:** Cập nhật `NhapExcelToDatableEPPlus`:
- Thay filter dialog → thêm `*.xls`
- Thêm nhánh `If fileExt = ".xls" Then ... Else ... End If`
- Logic xử lý hai nhánh phải **nhất quán** (cùng kiểm tra `IS_NULLABLE`, cùng xử lý bảng đặc biệt)

**Bước 3:** Cập nhật `NhapExcelEPPlus`:
- Thay `tableInf.Select()` bằng `Dictionary` + `colTypeMap`
- Đọc config row ra `List(Of String)` trước, không đọc lại trong vòng lặp
- Xác định `needsPerRowCheck` cho các bảng có CheckingBlock trong project
- Thêm `TaoSQLKhongGhiLog` + `StringBuilder` + flush mỗi 100 dòng

**Bước 4:** Viết lại `NhapExcel(SheetName, ...)`:
- Xóa toàn bộ phần `XlsReport` / `Xls.Out.File()`
- Thay bằng OleDb đọc vào `DataTable` (xem Mục 4.3)
- Xây column map theo chỉ số integer (không dùng chữ cái cột)
- Thêm batch SQL giống `NhapExcelEPPlus`

**Bước 5:** Điều chỉnh tên bảng đặc biệt:
```vb
' Sửa danh sách này theo nghiệp vụ của project mới
Dim needsPerRowCheck As Boolean = (
    String.Equals(TableName, "TEN_BANG_1", StringComparison.OrdinalIgnoreCase) OrElse
    String.Equals(TableName, "TEN_BANG_2", StringComparison.OrdinalIgnoreCase))
```

**Bước 6:** Kiểm tra tên hàm kết nối DB:
- Đổi `kn.ReadData(...)` và `kn.SaveData(...)` sang tên tương ứng trong project mới
- Đảm bảo `SaveData` chấp nhận chuỗi multi-statement (nhiều lệnh SQL ngăn cách bởi newline)

### 6.3 Test cases cần kiểm tra

| Test | Kỳ vọng |
|------|---------|
| Nhập file `.xlsx` bình thường | Dữ liệu vào DB, file nguồn không thay đổi |
| Nhập file `.xls` bình thường | Dữ liệu vào DB, file nguồn không thay đổi |
| File `.xls` trên máy x64 | Dùng ACE 12.0 — không báo lỗi provider |
| File `.xls` trên máy x86 | Dùng Jet 4.0 — không báo lỗi provider |
| Cột DateTime trong `.xls` | Ngày được parse đúng (không bị lệch 1 ngày) |
| Dòng có ô khóa chính trống | Thông báo lỗi đúng dòng, dừng nhập |
| 500+ dòng | Thấy batch hoạt động, tốc độ nhanh hơn bản cũ rõ rệt |
| Bảng trong `needsPerRowCheck` | Mỗi dòng vẫn gọi `LuuKhongGhiLog` riêng |
| Nhập lại file `.xls` lần 2 | File nguồn vẫn nguyên vẹn (không bị ghi đè) |

---

## 7. Các lưu ý quan trọng

### 7.1 EPPlus không hỗ trợ .xls
EPPlus (`OfficeOpenXml`) chỉ đọc định dạng OOXML (`.xlsx`, `.xlsm`). File `.xls` (BIFF8) bắt buộc phải dùng OleDb hoặc Interop.

### 7.2 Cảnh báo về Microsoft.Jet.OLEDB.4.0 (x86)
Jet 4.0 chỉ có trên Windows 32-bit hoặc ứng dụng chạy ở chế độ x86. Nếu deploy ứng dụng x64 trên máy chưa cài ACE, cần cài thêm [Microsoft Access Database Engine 2016 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=54920).

### 7.3 HDR=NO và IMEX=1
- `HDR=NO`: OleDb không coi hàng đầu là header → tất cả dòng đều là data, cột được đặt tên `F1, F2, F3...` (truy cập qua index integer).
- `IMEX=1`: Import Mixed (bắt buộc khi cột có cả số lẫn text) — đảm bảo mọi ô đều được đọc là Text.

### 7.4 kn.SaveData() phải hỗ trợ multi-statement
Batch SQL gồm nhiều câu `IF EXISTS...BEGIN...END` nối nhau bằng newline. `SqlCommand.ExecuteNonQuery()` xử lý được điều này theo mặc định — nhưng cần đảm bảo `CommandTimeout` đủ lớn (mặc định 30s có thể quá ngắn với batch lớn).

```vb
' Trong lớp connect, đặt timeout phù hợp:
command.CommandTimeout = 300   ' 5 phút
```

### 7.5 Không dùng .Calculate() trong EPPlus
Gọi `worksheet.Calculate()` hoặc `cell.Calculate()` với EPPlus 4.x rất chậm và không cần thiết khi chỉ đọc giá trị — luôn dùng `.Value` (kết quả đã tính sẵn) thay vì tính lại.

### 7.6 Bảo toàn logic CheckingBlock
`LuuKhongGhiLog` có thể chứa logic gọi stored procedure kiểm tra nghiệp vụ (xung đột ca, giới hạn nghỉ phép...). Những bảng này **bắt buộc** gọi `LuuKhongGhiLog` từng dòng — không được gom batch bằng `TaoSQLKhongGhiLog`.

---

*Tài liệu này mô tả đúng trạng thái code trong `ThuVienChucNang.vb` sau khi áp dụng tất cả các thay đổi ngày 2026-06-27.*
