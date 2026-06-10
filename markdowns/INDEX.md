# 📚 POCONS HR System – Document Index

> **Dùng file này làm điểm bắt đầu để hiểu toàn bộ hệ thống.**
> Mỗi khi Antigravity mở project, đọc file này trước tiên.


> [!IMPORTANT]
> **Quy định quản lý tài liệu (Markdown Rule):** 
> Để dễ dàng tìm kiếm và di chuyển, **TOÀN BỘ** các file tài liệu `.md` của bất kỳ thư mục/project nào đều phải được đặt vào bên trong một folder tên là `markdowns` thuộc thư mục/project đó (Ví dụ: `ProjectName\markdowns\FLOW_DOCUMENT.md`). Không để các file `.md` nằm rải rác bên ngoài. Riêng các file Markdown tổng dùng chung cho toàn bộ project (như `INDEX.md`, `LANGUAGE_HANDLING.md`...) sẽ được đặt ở thư mục `markdowns` cấp cao nhất ngang hàng với thư mục Source Code.
>
> **Quy định quản lý File tạm (Antigravity Temp Files):** 
> Các file mã nguồn, file thực thi hoặc kết quả (.cs, .exe, .ps1, .txt,...) được sinh ra trong quá trình Antigravity xử lý công việc **PHẢI** được di chuyển vào một thư mục con bên trong thư mục `markdowns` cấp cao nhất. Tên thư mục con phải mô tả rõ nội dung công việc (Ví dụ: `markdowns\fix_language`). Sau khi xử lý xong và được nghiệm thu, nếu cần dọn dẹp, chỉ việc xóa toàn bộ thư mục con đó.

---

## 🏗️ Tài liệu kiến trúc

| Document | Đường dẫn | Mô tả |
|---|---|---|
| **Tổng quan kiến trúc** | [ARCHITECTURE_OVERVIEW.md](file:///e:/SourceCodeHR/POCONS/markdowns/ARCHITECTURE_OVERVIEW.md) | Solution structure, dependency flow, DB connection, multi-language, permission, reports |
| **Template tạo form mới** | [TEMPLATE_NEW_FORM.md](file:///e:/SourceCodeHR/POCONS/markdowns/TEMPLATE_NEW_FORM.md) | Hướng dẫn step-by-step tạo form nghiệp vụ mới từ đầu |
| **Xử lý Đa ngôn ngữ** | [LANGUAGE_HANDLING.md](file:///e:/SourceCodeHR/POCONS/markdowns/LANGUAGE_HANDLING.md) | Quy tắc dịch thuật, cấu trúc file JSON ngôn ngữ và cách thêm form mới |

---

## 📁 Tài liệu từng Project

| Project | Flow Document | Vai trò chính |
|---|---|---|
| **WindowsControlLibrary** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/WindowsControlLibrary/markdowns/FLOW_DOCUMENT.md) | Base form HRFORM, ThuVienChucNang, Custom Controls |
| **SmartBooks.HumanResource** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/SmartBooks.HumanResource/markdowns/FLOW_DOCUMENT.md) | App chính – Login, frmMain, tất cả form nghiệp vụ |
| **SmartBooks.BusinessLogic** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/SmartBooks.BusinessLogic/markdowns/FLOW_DOCUMENT.md) | Data Access Layer – DB, Permission, Stored Procs |
| **Appsettings** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/Appsettings/markdowns/FLOW_DOCUMENT.md) | Config trung tâm – DbSetting, connection, language |
| **SmartBooks.Core** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/SmartBooks.Core/markdowns/FLOW_DOCUMENT.md) | XML utils, Excel export, DataType mapping |
| **SmartBooks.BL.TimeKeeping** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/SmartBooks.BL.TimeKeeping/markdowns/FLOW_DOCUMENT.md) | Logic chấm công – tính ca, OT, nghỉ phép |
| **Entity** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/Entity/markdowns/FLOW_DOCUMENT.md) | Data entity classes – mô hình dữ liệu |
| **CommonLib** | [FLOW_DOCUMENT.md](file:///e:/SourceCodeHR/POCONS/CommonLib/markdowns/FLOW_DOCUMENT.md) | DLL bên thứ 3 – DevExpress, Janus, Infragistics |

---

## 🔑 Quick Reference – Các pattern quan trọng

### Tạo kết nối DB
```vb
Dim kn As New connect(WindowsControlLibrary.DbSetting.dataPath)
Dim tab As DataTable = kn.ReadData("exec sp_XXX @param='value'", "table")
```

### Form kế thừa HRFORM
```vb
' Form Inherits WindowsControlLibrary.HRFORM (trong Designer)
HRFORM_TableName = "TEN_BANG"
HRFORM_GridControl = GridControl1
HRFORM_Gridview = GridView1
```

### Kiểm tra quyền
```vb
Quyen = tvcn.KiemTraQuyen("MA_CHUC_NANG")
' → "EDIT" hoặc "View"
```

### Load dropdown
```vb
tvcn.SearchEmployee(Employee_ID_Control)
tvcn.GetDataOnDropDownCategoryCodeName(ComboBox, "LoaiDanhMuc")
```

### Dịch ngôn ngữ
```vb
tvcn.ChangeLanguageToForm(Me, KeyOfForm1, 1)
Dim text As String = tvcn.GetLanguagesTranslated("KEY")
```

### Override lifecycle
```vb
Public Overrides Function BeforeSave() As Integer   ' Return 0=stop, 1=continue
Public Overrides Sub AfterViewForm()                 ' Sau khi load grid
Public Overrides Sub AfterSave()                     ' Sau khi lưu
Public Overrides Function BeforeDelete() As Integer  ' Trước khi xóa
```

---

## 📊 Sơ đồ kiến trúc tổng thể

```
┌──────────────────────────────────────────────────────┐
│          SmartBooks.HumanResource (WinForms)          │
│  ┌─────────┐ ┌─────────┐ ┌──────────┐ ┌───────────┐ │
│  │ frmMain │ │ Login   │ │ Form1    │ │ frm*      │ │
│  │ (MDI)   │ │         │ │ (Layout) │ │ (nghiệp vụ│ │
│  └────┬────┘ └────┬────┘ └────┬─────┘ └─────┬─────┘ │
│       │           │           │              │       │
└───────┼───────────┼───────────┼──────────────┼───────┘
        │           │           │              │
        ▼           ▼           ▼              ▼
┌────────────────────────────────────────────────────┐
│           WindowsControlLibrary                     │
│  ┌──────────┐  ┌────────────────┐  ┌─────────────┐ │
│  │ HRFORM   │  │ThuVienChucNang │  │  Controls   │ │
│  │(Base Form│  │(5000+ dòng)    │  │(Address,    │ │
│  │ + toolbar│  │                │  │ MonthYear)  │ │
│  └────┬─────┘  └───────┬───────┘  └─────────────┘ │
│       │                │                            │
└───────┼────────────────┼────────────────────────────┘
        │                │
        ▼                ▼
┌────────────────┐  ┌────────────────┐  ┌──────────┐
│SmartBooks.     │  │ Appsettings    │  │SmartBooks.│
│BusinessLogic   │  │  ┌──────────┐  │  │BL.Time-  │
│┌──────────────┐│  │  │DbSetting │  │  │Keeping   │
││ DbAccess     ││  │  │(dataPath)│  │  └──────────┘
││ KetNoiCSDL   ││  │  └──────────┘  │
││ UserPermisson││  └────────────────┘
│└──────────────┘│
└────────┬───────┘
         │
         ▼
   ┌───────────┐
   │ SQL Server│
   │  Database │
   └───────────┘
```
