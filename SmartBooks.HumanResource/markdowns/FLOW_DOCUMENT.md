# SmartBooks.HumanResource – Tài liệu Flow & Mapping

> **Vai trò:** Đây là **project chính** – ứng dụng WinForms application.
> Chứa tất cả màn hình nghiệp vụ, form Login, form Main, và startup logic.

---

## Cấu trúc thư mục

```
SmartBooks.HumanResource/
├── Login.vb                     ← Form đăng nhập
├── frmMain.vb                   ← Form chính (MDI Parent)
├── frmServerLogin.vb            ← Form cấu hình server
├── frmAbout.vb                  ← Giới thiệu
├── Form1.vb                     ← Layout form (bàn phím tắt, menu TreeView)
├── DBConnection.vb              ← DB connection helper riêng cho project
├── DBTasks.vb                   ← Task liên quan DB
├── MdlDeclare.vb                ← Module khai báo biến global
├── MdlLIBRARY.vb                ← Module thư viện utility riêng
├── ThuVienChucNang.vb           ← Thư viện hàm riêng project (Excel, MailMerge)
├── UpdateManager.vb             ← Auto-update checker
├── DownloadProgressForm.vb      ← Form hiện tiến trình download update
├── app.config                   ← Cấu hình ứng dụng
│
├── Froms/                       ← TẤT CẢ các form nghiệp vụ
│   ├── frmEmployeeInfo.vb       ← Thông tin nhân viên (form phức tạp nhất)
│   ├── frmChuyenViTri.vb        ← Chuyển vị trí/phòng ban
│   ├── frmAward.vb              ← Khen thưởng
│   ├── frmDiscipline.vb         ← Kỷ luật
│   ├── frmFamily.vb             ← Gia đình nhân viên
│   ├── frmTerminationAsignment.vb ← Nghỉ việc
│   ├── frmTrainingRecord.vb     ← Hồ sơ đào tạo
│   ├── frmLicense.vb            ← Chứng chỉ
│   ├── frmHealthCheck.vb        ← Khám sức khỏe
│   ├── frmDiseasesRecord.vb     ← Bệnh lý
│   ├── frmSurgeryHistory.vb     ← Lịch sử phẫu thuật
│   ├── frmHeavyAndToxic.vb      ← Độc hại/nặng nhọc
│   ├── frmBankAccountOfEmployee.vb ← Tài khoản ngân hàng
│   ├── frmCapPhatAo.vb          ← Cấp phát áo
│   ├── frmDisable.vb            ← Disable
│   ├── frmQuanLyTheTu.vb        ← Quản lý thẻ từ
│   ├── frmQuaTrinhHocTapCongTac.vb ← Quá trình học tập/công tác
│   ├── Holidays_Plan.vb         ← Kế hoạch nghỉ lễ
│   ├── Para/                    ← Form parameter cho báo cáo
│   └── ShowReports/             ← Form hiển thị báo cáo
│
├── BaseForms/                   ← Form base riêng project
│   ├── frmPBar.vb               ← Panel bar form (69KB – form nghiệp vụ lớn)
│   ├── frmShow.vb               ← Form hiển thị
│   ├── frmParaDanhSachCong.vb   ← Form tham số chấm công
│   ├── Accessdb.vb              ← DB access riêng
│   ├── PublicFunction.vb        ← Hàm public
│   ├── ReportCommon.vb          ← Report common
│   └── ReportViewer.vb          ← Viewer báo cáo
│
├── BaoHiem/                     ← Module bảo hiểm
├── Payroll/                     ← Module bảng lương
├── TimeKeeping/                 ← Module chấm công
├── ToolBar/                     ← Module toolbar
└── Images/                      ← Hình ảnh, icon
```

---

## Luồng khởi động ứng dụng

```
Application.Run(frmMain)
    │
    ├── frmMain_Load()
    │   ├── Login()  ← Mở form Login
    │   │       │
    │   │       ├── Đọc login.xml (lưu username, companyCode trước đó)
    │   │       ├── User nhập: username, password, companyCode, fromDate
    │   │       ├── GetServerCompanyInfor(companyCode)
    │   │       │       ├── Đọc HR_CompanyInfor.json
    │   │       │       ├── Decrypt ServerName, DatabaseName, UserID, Password
    │   │       │       └── Trả về CompanyInfor object
    │   │       │
    │   │       ├── Tạo connection string → Appsettings.DbSetting.dataPath
    │   │       ├── Tạo connection string → WindowsControlLibrary.DbSetting.dataPath
    │   │       ├── CheckExsitUser() → CheckUserNameAndPassword()
    │   │       ├── Ghi login.xml (nhớ lần login sau)
    │   │       ├── RaiseEvent doIt() → frmMain nhận event → mở Form1 (layout)
    │   │       └── Close Login form
    │   │
    │   └── CheckForUpdateAsync() ← Kiểm tra update tự động (async)
    │
    └── Form1 (Layout form – MDI Child)
        ├── Load menu từ HR_Menu table
        ├── TreeView hiện danh sách chức năng theo quyền
        └── Click menu → tvcn.CreateForm(formName) → ShowDialog
```

---

## Cấu trúc một form nghiệp vụ (Pattern)

Mỗi form trong `Froms/` đều tuân theo **pattern chuẩn**:

### Form đơn giản (ví dụ: frmAward)
```vb
Public Class frmAward
    ' Inherits HRFORM (qua designer – link đến WindowsControlLibrary.HRFORM)
    
    Private Sub frmAward_Load(...)
        ' 1. Đánh dấu trường bắt buộc
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        
        ' 2. Load giao diện (enable/disable buttons theo quyền)
        LoadGiaoDienTheoDieuKien()
        
        ' 3. Load dropdown data
        tvcn.GetDataOnDropDownCategoryCodeName(AwardType, "KhenThuong")
        tvcn.SearchEmployee(Employee_ID)
        
        ' 4. Set default values
        AwardDate.EditValue = Today
        
        ' 5. Load dữ liệu
        Search()
    End Sub
    
    Private Sub Search()
        ' Tạo query gọi stored proc
        Dim QR = "exec [dbo].[sp_BangAward] ..."
        ' Gọi HRFORM.Xem() để load lên grid
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    
    ' Override AfterViewForm nếu cần tùy chỉnh grid sau khi load
    Public Overrides Sub AfterViewForm()
        ' Thêm dropdown cho cột grid
    End Sub
    
    ' Keyboard shortcut
    Private Sub GridControl1_KeyUp(...)
        Gridview_KeyUp(sender, e)  ' Delegate cho HRFORM xử lý
    End Sub
End Class
```

### Form phức tạp (ví dụ: frmChuyenViTri)
```vb
Public Class frmChuyenViTri
    ' Có thêm Constructor overload để mở từ form khác
    Public Sub New(ByVal Employee_ID1 As String, Ngay1 As Date)
        InitializeComponent()
        Quyen = "EDIT"
        Employee_ID.Text = Employee_ID1
    End Sub
    
    ' Override BeforeSave() với logic nghiệp vụ riêng
    Public Overrides Function BeforeSave() As Integer
        ' Validate dữ liệu
        ' Gọi stored proc: exec usp_HR_Transfer_Department ...
        ' Return 0 (dừng) hoặc 1 (tiếp tục)
    End Function
    
    ' Có hàm Save() riêng bên cạnh HRFORM save
    Private Function Save() As Boolean
        ' Gọi stored proc trực tiếp
        ' Hiển thị kết quả
    End Function
End Class
```

---

## Naming Convention – Quy ước đặt tên

| Prefix | Ý nghĩa | Ví dụ |
|---|---|---|
| `frm` | Form | `frmAward`, `frmChuyenViTri` |
| `btn` | Button | `btnSave`, `btnSearch` |
| `lbl` | Label | `lblPosition` |
| `txt` | TextBox | `txtusername` |
| `cb/chk` | CheckBox | `cbTypeOfView` |
| `cbb` | ComboBox | `cbbReport` |
| `sp_` | Stored Procedure (select) | `sp_BangAward` |
| `usp_` | User Stored Procedure (CUD) | `usp_HR_Transfer_Department` |
| `udf_` | User Defined Function | `udf_EmployeeFilter` |

---

## Config quan trọng

### `login.xml` (lưu thông tin đăng nhập)
```xml
<DataSet>
  <Table>
    <username>admin</username>
    <CompanyCode>ABC</CompanyCode>
    <lang>VN</lang>
    <UseInforOnline>False</UseInforOnline>
    <fromdate>05/06/2026</fromdate>
  </Table>
</DataSet>
```

### `HR_CompanyInfor.json` (thông tin server – mã hóa)
```json
{
  "CompanyInfor": [
    {
      "Code": "encrypted_code",
      "Name": "Company Name",
      "ServerName": "encrypted",
      "DatabaseName": "encrypted",
      "UserID": "encrypted",
      "Password": "encrypted"
    }
  ]
}
```

---

## MdlDeclare – Biến Global

**File:** [MdlDeclare.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.HumanResource/MdlDeclare.vb)

Module chứa biến toàn cục cho cả project:

| Biến | Mô tả |
|---|---|
| `s_StringCnn`, `s_CnnServer`, `s_CnnDataBase` | Connection info |
| `s_UserCreateID`, `s_UserUpdateID` | Audit fields |
| `S_FormatDate` | Format ngày: `"dd/MM/yyyy"` |
| `GotFocusColor / LostFocusColor` | Màu highlight control |
| `s_SystemFont` | Font hệ thống: `"Arial"` |
| `piS_Add, piS_Save, piS_Delete, ...` | Trạng thái nút (Janus controls) |

---

## Dependencies

```
SmartBooks.HumanResource (Startup Project)
    │
    ├──► WindowsControlLibrary    (HRFORM, ThuVienChucNang, Controls)
    ├──► SmartBooks.BusinessLogic  (DbAccess, KetNoiCSDL, UserPermission)
    ├──► SmartBooks.Core           (Common, Excel, List)
    ├──► SmartBooks.BL.TimeKeeping (chấm công)
    ├──► Entity                    (data entity classes)
    ├──► CommonLib                 (DLLs bên thứ 3)
    └──► Appsettings              (DbSetting, HROption)
```
