# Appsettings – Tài liệu Flow & Mapping

> **Vai trò:** Project chứa cấu hình kết nối DB, thông tin user login, cấu hình hệ thống, logic chấm công, và các utility cài đặt.

---

## Cấu trúc thư mục

```
Appsettings/
├── DbSetting.vb             ← Class CHÍNH – cấu hình DB, user, ngôn ngữ (Shared/Static)
├── HROption.vb               ← Form cài đặt tham số HR (30KB)
├── HRSetting.xsd             ← Dataset schema cài đặt
├── HRSetting.Designer.vb     ← Auto-generated dataset
├── clsTimeKeeping.vb          ← Class logic chấm công (tính giờ, ca, OT)
├── clsDateTimeChecking.vb     ← Class kiểm tra ngày giờ
├── clsAppSecurity.vb          ← Security class
├── mdGenerate.vb              ← Module generate (29KB – tạo mã, serial)
└── AssemblyInfo.vb            ← Assembly metadata
```

---

## DbSetting – Class cấu hình trung tâm

**File:** [DbSetting.vb](file:///e:/SourceCodeHR/POCONS/Appsettings/DbSetting.vb)

Đây là class **Shared (Static)** – mọi property đều là `Public Shared`, truy cập từ bất kỳ nơi nào trong solution.

### Properties quan trọng

| Property | Kiểu | Mô tả |
|---|---|---|
| `dataPath` | String (Shared) | **Connection string SQL Server** – quan trọng nhất |
| `UserName` | String (Shared) | Tên user đang đăng nhập |
| `UserLogin` | String (Shared) | Username đăng nhập |
| `PassUser` | String (Shared) | Password user |
| `Lan` | String (Shared) | Ngôn ngữ: `"VN"`, `"EN"`, `"KR"` |
| `DayWork` | Date (Shared) | Ngày làm việc (fromdate khi login) |
| `fromdate` / `todate` | DateTime (Shared) | Khoảng thời gian filter |
| `CompanyCode` | String (Shared) | Mã công ty |
| `Permision` | String (Shared) | Quyền: `"ADMIN"`, `"MANAGER"`, `"EDIT"`, `"View"` |
| `Level` | Integer (Shared) | Cấp quyền (0-3) |
| `Terminal` | String (Shared) | Terminal kết nối |

### Cách sử dụng trong code

```vb
' Bất kỳ đâu trong solution:
Dim kn As New connect(DbSetting.dataPath)    ' Tạo kết nối DB
Dim lang As String = DbSetting.Lan           ' Lấy ngôn ngữ
Dim user As String = DbSetting.UserName      ' Lấy username
```

### Instance Properties (Read-Only)

| Property | Return |
|---|---|
| `FactoryName(Terminal)` | Tên nhà máy theo terminal |
| `Delete(lan)` | Message confirm xóa theo ngôn ngữ |
| `Save(lan)` | Message lưu thành công theo ngôn ngữ |
| `Version` | Phiên bản: `"SmartBooks 2009"` |

---

## Luồng khởi tạo DbSetting

```
Login.vb (SmartBooks.HumanResource)
    │
    ├── Đọc HR_CompanyInfor.json → Decrypt server info
    │
    ├── Appsettings.DbSetting.dataPath = "Server=...;Database=...;User ID=...;Password=..."
    ├── Appsettings.DbSetting.UserName = txtusername.Text
    ├── Appsettings.DbSetting.Lan = "VN"/"EN"/"KR"
    ├── Appsettings.DbSetting.fromdate = txtfromdate.EditValue
    ├── Appsettings.DbSetting.CompanyCode = txtcompanycode.Text
    │
    ├── WindowsControlLibrary.DbSetting.dataPath = (same)
    ├── WindowsControlLibrary.DbSetting.UserName = (same)
    └── WindowsControlLibrary.DbSetting.Lan = (same)
```

> **QUAN TRỌNG:** Có **2 class DbSetting** riêng biệt:
> - `Appsettings.DbSetting` – dùng trong SmartBooks.HumanResource, SmartBooks.BusinessLogic
> - `WindowsControlLibrary.DbSetting` – dùng trong WindowsControlLibrary

> Khi Login, **CẢ HAI** đều được set cùng giá trị.

---

## Dependency

```
Appsettings
    └── (Không phụ thuộc project nào – là project nền tảng)
```

**Được tham chiếu bởi:** SmartBooks.BusinessLogic, SmartBooks.HumanResource, WindowsControlLibrary, Entity
