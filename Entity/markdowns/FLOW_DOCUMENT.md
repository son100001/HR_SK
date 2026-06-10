# Entity – Tài liệu Flow & Mapping

> **Vai trò:** Project chứa các entity/data class mô tả cấu trúc dữ liệu nghiệp vụ.
> Mỗi entity class tương ứng với 1 bảng/nhóm bảng trong database.

---

## Cấu trúc thư mục

```
Entity/
├── SmartBooks_Employee.vb               ← Entity nhân viên (124KB – file lớn nhất)
├── SmartBooks_Salary.vb                 ← Entity lương (93KB)
├── SmartBooks_Salary_Name.vb            ← Entity tên cột lương (15KB)
├── HR_EmpRegisLeave.vb                  ← Entity đăng ký nghỉ phép (37KB)
├── HR_EmpRegisTimeSheet.vb              ← Entity đăng ký ca (25KB)
├── HR_EmployeeRegisMaternityLeave.vb    ← Entity nghỉ thai sản (18KB)
├── HR_GoOut.vb                          ← Entity xin ra ngoài (28KB)
├── HR_TimeIn_TimeOut.vb                 ← Entity thời gian vào/ra (17KB)
├── HR_Khoa.vb                           ← Entity khóa dữ liệu (17KB)
├── HR_FormulaExcel.vb                   ← Entity công thức Excel (18KB)
├── HR_TemplateReport.vb                 ← Entity template báo cáo (19KB)
├── SetUp.vb                             ← Entity cài đặt (14KB)
├── Accessdb.vb                          ← Data access helper (34KB)
├── DynamicImportData.vb                 ← Entity import data động
├── XMLProcessing.vb                     ← Xử lý XML
├── GeneralParams.vb                     ← Params chung
└── objectParameter.vb                   ← Object parameter
```

---

## Pattern Entity Class

Mỗi entity class tuân theo pattern:

```vb
Public Class SmartBooks_Employee
    ' 1. PROPERTIES – tương ứng cột trong DB
    Private _Employee_ID As String
    Public Property Employee_ID() As String
        Get / Set
    End Property

    Private _FullName As String
    Public Property FullName() As String
        Get / Set
    End Property
    ' ... (hàng trăm properties cho mỗi entity)

    ' 2. CRUD METHODS – gọi stored procedures
    Public Function Select_All() As DataTable
    Public Function Select_ByID(ID) As DataTable
    Public Function Insert() As Integer
    Public Function Update() As Integer
    Public Function Delete(ID) As Integer

    ' 3. DB CONNECTION
    Dim kncsdl As New SmartBooks.BusinessLogic.KetNoiCSDL
End Class
```

### Các entity chính và bảng DB tương ứng

| Entity Class | Bảng DB | Mô tả |
|---|---|---|
| `SmartBooks_Employee` | `HR_Employee`, `HR_Employee_Detail` | Thông tin nhân viên (lớn nhất, ~124KB) |
| `SmartBooks_Salary` | `HR_Salary_*` | Bảng lương (~93KB) |
| `HR_EmpRegisLeave` | `HR_EmpRegisLeave` | Đăng ký nghỉ phép |
| `HR_EmpRegisTimeSheet` | `HR_EmpRegisTimeSheet` | Đăng ký ca làm việc |
| `HR_GoOut` | `HR_GoOut` | Xin ra ngoài |
| `HR_TimeIn_TimeOut` | `HR_TimeIn_TimeOut` | Chấm công vào/ra |
| `HR_Khoa` | `HR_Khoa` | Khóa/mở dữ liệu theo tháng |
| `HR_FormulaExcel` | `HR_FormulaExcel` | Công thức tính lương |
| `HR_TemplateReport` | `HR_TemplateReport` | Template báo cáo |
| `SetUp` | `HR_Setup` | Cài đặt hệ thống |

---

## Dependency

```
Entity
    │
    └──► SmartBooks.BusinessLogic (KetNoiCSDL – cho CRUD)
```
