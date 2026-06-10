# SmartBooks.Core – Tài liệu Flow & Mapping

> **Vai trò:** Thư viện utility lõi – chứa logic XML, Excel export, DataType mapping, và grid info.

---

## Cấu trúc thư mục

```
SmartBooks.Core/
├── Common.vb              ← XML helper, DataType enum, SQL cleaner, ExecuteDataset
├── List.vb                ← Grid export to Excel (via XML config)
├── Excel/
│   ├── Export.vb           ← Tạo file Excel từ GridInfo
│   └── FileContent.vb     ← MemoryStream + FileName wrapper
├── General/
│   ├── DBConnection.vb     ← SqlConnection wrapper cho Core
│   └── Enums.vb            ← Shared enums
└── SmartBooks.Core.vbproj
```

---

## Common.vb – Class utility chính

**File:** [Common.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.Core/Common.vb)

### Enums

```vb
Public Enum DataType
    [String] = 0    ' char, nchar, varchar, nvarchar, text, ntext, xml
    [Numeric] = 1   ' int, decimal, float, etc.
    [DateTime] = 2  ' datetime, date, time, datetime2
    [Boolean] = 3   ' bit
    [Other] = 4
End Enum

Public Enum FormType
    List = 0        ' Form danh sách
    Voucher = 1     ' Form chứng từ
End Enum
```

### Shared Methods quan trọng

| Method | Mô tả |
|---|---|
| `GetXMLDocument(xmlFile)` | Load file XML → XDocument |
| `GetXMLOptionValue(fileName, optionID)` | Lấy value từ `<option name="" value="">` |
| `GetXMLFieldTableID(file, fieldID)` | Lấy `table_id` của field |
| `GetXMLFieldTitleLanguage(file, fieldID)` | Lấy title field theo ngôn ngữ hiện tại |
| `GetDataType(sqlType)` | Map SQL data type → DataType enum |
| `CleanInput(input)` | Regex loại bỏ ký tự đặc biệt |
| `CleanQuery(commandText)` | Chặn `DROP`, `TRUNCATE`, `INSERT`, `DELETE`, `UPDATE` |
| `ExecuteDataset(commandText)` | Execute SQL query → DataSet |
| `SaveExcelFile(fileName, stream)` | Hiện SaveFileDialog → save .xlsx |

### Properties

| Property | Return |
|---|---|
| `XMLLanguage` | `"v"` (VN), `"e"` (EN), `"k"` (KR) – dùng cho XML attribute |
| `AppCommonPath` | `{AppPath}\Common` |
| `LanguageFile` | `{AppPath}\AppLanguageVN.xml` (theo ngôn ngữ) |
| `ExcelExportConfigFile` | `{AppPath}\Common\Excel\ExportConfig.xml` |

---

## List.vb – Excel Export Engine

**File:** [List.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.Core/List.vb)

### Luồng Export Excel

```
ListExport.ToExcelFile(form, exportID)
    │
    ├── CreateFile(form, exportID)
    │   ├── GetListInfo(form, exportID)
    │   │   ├── Đọc ExportConfig.xml
    │   │   ├── Lấy gridID, tableID từ XML config
    │   │   ├── GetListFields(): lấy columns từ GridEX + XML override
    │   │   ├── Query DB lấy data type cho mỗi field
    │   │   └── GetListSelectCommand(): tạo SELECT query
    │   │
    │   └── Excel.Export.CreateFile(gridInfo) → FileContent (MemoryStream)
    │
    └── Common.SaveExcelFile(fileName, stream) → SaveFileDialog → .xlsx
```

### GridInfo / GridField Classes

```vb
GridInfo:
  - Title          ' Tiêu đề (lấy từ form.Text)
  - FormID         ' Tên form
  - GridID         ' Control ID của grid trên form
  - TableID        ' Bảng DB tương ứng
  - ExportID       ' ID trong ExportConfig.xml
  - SelectCommand  ' SQL query lấy dữ liệu
  - Fields()       ' List(Of GridField)

GridField:
  - Name           ' Tên cột (DataMember)
  - Title          ' Tiêu đề cột (đa ngôn ngữ)
  - DataType       ' String/Numeric/DateTime/Boolean
  - DataFormat     ' Format string
  - Width          ' Chiều rộng cột
```

---

## Dependency

```
SmartBooks.Core
    │
    ├──► Appsettings (qua DBConnection – dùng cho language)
    └──► Janus.Windows.GridEX (3rd party grid control)
```
