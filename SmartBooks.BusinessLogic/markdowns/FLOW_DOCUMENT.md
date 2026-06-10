# SmartBooks.BusinessLogic – Tài liệu Flow & Mapping

> **Vai trò:** Tầng Data Access Layer – chứa tất cả logic truy cập DB, stored procedures, dataset, phân quyền.
> Đây là project **trung tâm** kết nối giữa UI (HumanResource) và SQL Server.

---

## Cấu trúc thư mục

```
SmartBooks.BusinessLogic/
├── DbAccess.vb             ← Class chính truy cập DB (2.7MB – file lớn nhất)
├── KetNoiCSDL.vb           ← Class kết nối SQL Server (wrapper SqlConnection)
├── DBData.vb               ← Class chứa các hàm gọi stored proc theo nghiệp vụ
├── UserPermission.vb       ← Class phân quyền user (login, permission, admin check)
├── ExceptionLog.vb         ← Ghi log lỗi ra XML
├── Logs.vb                 ← Ghi log
├── Giang_TimeKeeping.vb    ← Logic chấm công (tính công, OT, ca)
├── SmartData.Designer.vb   ← Auto-generated dataset designer (6.3MB)
├── SmartData2.xsd          ← Dataset schema
└── SmartData21.Designer.vb ← Bổ sung dataset designer
```

---

## Các class chính và vai trò

### 1. `KetNoiCSDL` – Kết nối CSDL

**File:** [KetNoiCSDL.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.BusinessLogic/KetNoiCSDL.vb)

Wrapper đơn giản cho `SqlConnection` + `SqlCommand`. Dùng `DbSetting.dataPath` làm connection string.

| Method | Mô tả |
|---|---|
| `Select_CauLenhSQL(sql)` | Chạy câu SQL raw, trả về DataTable |
| `Select_(StoreProcedure)` | Gọi stored procedure không tham số |
| `Select_(sql, name(), value(), N)` | Gọi stored procedure có N tham số |
| `Upadate(sql, ...)` | ExecuteNonQuery cho UPDATE |
| `Insert(sql, ...)` | ExecuteNonQuery cho INSERT |
| `Exec(strSQL)` | ExecuteNonQuery cho SQL raw |

> **Lưu ý:** `CommandTimeout = 9000` (150 phút) cho Select.

### 2. `DbAccess` – Data Access chính

**File:** [DbAccess.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.BusinessLogic/DbAccess.vb) (2.7MB, ~file lớn nhất project)

Class này là **trái tim** của hệ thống data access. Chứa hàng trăm hàm gọi stored procedures cho mọi nghiệp vụ HR:

- Quản lý nhân viên (CRUD Employee)
- Chấm công (TimeKeeping)
- Lương (Payroll)
- Import/Export Excel
- Encoding/Decoding password
- Utilities DB chung

### 3. `UserPermission` – Phân quyền

**File:** [UserPermission.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.BusinessLogic/UserPermission.vb)

| Method | Mô tả |
|---|---|
| `CheckUserNameAndPassword(user, pass)` | Xác thực đăng nhập (password encoded) |
| `Userpermission(user, formID)` | Lấy quyền của user trên form cụ thể |
| `CheckAdmin(user)` | Kiểm tra có phải admin (`ADMIN`) |
| `CheckManager(user)` | Kiểm tra có phải manager (`MANAGER`) |
| `CheckExsitUser(user)` | Kiểm tra user tồn tại |
| `InsertUser(user, pass, name, isAdmin, group)` | Tạo user mới |
| `InsertPermission(user, setup, emp, tk, payroll)` | Gán quyền theo module |
| `ChangePassword(user, pass)` | Đổi mật khẩu |
| `GetPermssion(user)` | Lấy toàn bộ quyền của user |
| `DeleteUser(user)` | Xóa user |

**Luồng phân quyền:**
```
Login → CheckExsitUser → CheckUserNameAndPassword
           │
           └── Userpermission(UserName, FormID)
                    │
                    └── Return "EDIT" hoặc "View"
                            │
                            └── HRFORM.QuyenHRFORM = Quyen
```

### 4. `DBData` – Stored Procedure Interface

**File:** [DBData.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.BusinessLogic/DBData.vb)

Tập hợp các hàm gọi stored procedures cho nghiệp vụ cụ thể (chủ yếu là chấm công, suất ăn, phép).

| Nhóm | Ví dụ |
|---|---|
| Đồng bộ chấm công | `DongBo_BangCong_BangDangKyCa`, `DongBo_BangCong_BangQuetVanTay` |
| Suất ăn | `Insert_HR_Com`, `LayNhanVienDangKyComTrua` |
| Ra ngoài | `HR_GoOut_SelectByEmp_Date`, `LayNhanVienXinRaNgoai` |
| Phép | `LayThongTinNghiPhep`, `LayCheDoThaiSan` |
| Tăng ca | `LayThoiGianTangCa`, `HR_MaxOverTime_SelectByDate` |
| Lương | `TinhLuong`, `BuLuongNhanVienDaNghiViec` |
| Permission | `Select_Permission_One`, `Insert_Permission` |

---

## Luồng truy cập dữ liệu

```
Form UI (SmartBooks.HumanResource)
    │
    ├── [Cách 1: qua connect class]
    │   kn.ReadData("exec sp_xxx ...", "table")
    │       └── Dùng trong HRFORM, ThuVienChucNang
    │
    ├── [Cách 2: qua KetNoiCSDL]
    │   kncsdl.Select_("sp_xxx", params)
    │       └── Dùng trong DBData
    │
    └── [Cách 3: qua DbAccess]
        dataman.HamNghiepVu()
            └── Dùng trong một số form đặc biệt
```

### Stored Procedures quan trọng

| SP Name | Chức năng |
|---|---|
| `sp_GetAllInformationInTable` | Lấy schema bảng (columns, types, PK) |
| `st_getpermission` | Lấy quyền user trên form |
| `sp_checkuserandpassword` | Xác thực đăng nhập |
| `sp_checkisadmin` | Kiểm tra admin |
| `udf_Factory` | Lấy danh sách nhà máy |
| `udf_Department` | Lấy danh sách phòng ban |
| `udf_Section` | Lấy danh sách bộ phận |
| `udf_Team` | Lấy danh sách tổ |
| `udf_EmployeeFilter` | Lọc nhân viên theo điều kiện |
| `udf_Position` | Lấy danh sách vị trí |
| `sp_BangCa` | Lấy bảng ca làm việc |

---

## Dependency

```
SmartBooks.BusinessLogic
    │
    └──► Appsettings (DbSetting.dataPath, DbSetting.UserName)
```
