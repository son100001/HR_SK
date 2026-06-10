# WindowsControlLibrary – Tài liệu Flow & Mapping

> **Vai trò:** Base UI Layer – project thư viện chứa Base Form (`HRFORM`), các Class tiện ích (`ThuVienChucNang`) và Custom Controls. 
> Mọi Form nghiệp vụ trong `SmartBooks.HumanResource` đều kế thừa từ project này.

---

## Cấu trúc thư mục

```
WindowsControlLibrary/
├── HRFORM.vb                  ← Form gốc (Base Form) của tất cả màn hình
├── HRFORM.Designer.vb         ← Chứa UI toolbar, các nút Xem/Thêm/Lưu/Xóa
├── Library/
│   └── ThuVienChucNang.vb     ← Class chứa hàm tiện ích (5000+ dòng)
├── Control/
│   ├── Address.vb             ← Custom Control nhập địa chỉ
│   ├── MonthYear.vb           ← Custom Control nhập Tháng/Năm
│   └── MultiSelectComboBox.vb ← Combobox chọn nhiều
└── Para/                      ← Form in/báo cáo base
```

---

## 1. Cơ chế Mapping Tự Động (Control ↔ Database)

Đây là **kiến trúc cốt lõi** của hệ thống, giúp tiết kiệm thời gian code form. Hệ thống tự động map giữa Control và Database dựa vào **Tên (Name) của Control**.

### Quy tắc đặt tên:
- **Tên Control (TextBox, DateEdit...):** Phải ĐÚNG bằng tên cột trong CSDL (Ví dụ: `Employee_ID`, `FullName`). Không phân biệt hoa/thường.
- **Tên Label Bắt Buộc (Require):** Đối với các cột `NOT NULL` trong DB, tạo Label có tên là `"lbl" + Tên Control` (VD: `lblFullName`).
- **HRFORM_TableName:** Phải khai báo tên bảng chính của form (VD: `HRFORM_TableName = "HR_Employee"`).

### Luồng lưu tự động (Save Flow):
1. **Click nút Lưu:** Kích hoạt sự kiện `Luu_ItemClick` trong `HRFORM.vb`.
2. **Gọi BeforeSave():** Chạy logic `BeforeSave()` của form con (nếu có override) để validate dữ liệu.
3. **Thêm/Sửa (tvcn.AddNewOrEdit):** Xác định form đang ở chế độ Thêm mới hay Sửa (dựa vào cờ `AddNew`).
4. **Quét Control (GetDataMemberAndPrimaryFromControl):** `ThuVienChucNang` sẽ đệ quy quét toàn bộ các control trên Form.
   - Hàm sẽ so sánh `Control.Name` với cấu trúc cột lấy từ DB (`sp_GetAllInformationInTable`).
   - Tự động lấy giá trị từ các loại Control khác nhau (`TextEdit.Text`, `LookUpEdit.EditValue`, `DateEdit.DateTime`, `CheckBox.Checked`, `NumericUpDown.Value`...).
   - Nếu tìm thấy Label có tên `lblXXX` và trường đó trống, hàm tự động báo lỗi *"Bạn vui lòng nhập vào ô..."*.
5. **Thực thi SQL:** Sinh câu lệnh thao tác Database với các tham số đã map.

---

## 2. HRFORM – Base Form

**File:** [HRFORM.vb](file:///e:/SourceCodeHR/POCONS/WindowsControlLibrary/HRFORM.vb)

Đây là object chính mà tất cả các form màn hình khác kế thừa. Form này cung cấp sẵn UI (Toolbar với các nút Xem, Thêm, Lưu, Xóa, Print...) và các phương thức (Methods) vòng đời.

### Các thuộc tính quan trọng (Properties)
- `HRFORM_TableName`: Tên bảng DB chính của form (Ví dụ: "HR_Employee").
- `HRFORM_TypeOfForm`: Chế độ hiển thị của form (`View`, `Input`, `ViewInput`).
- `HRFORM_InputForm`: Tên của form con (form popup nhập liệu) dùng khi TypeOfForm là `View`.
- `HRFORM_GridControl` / `HRFORM_Gridview`: DevExpress grid được dùng trong form.
- `QuyenHRFORM`: Quyền của user trên form ("EDIT", "View").

### Các hàm có thể Override (Virtual Methods)
Các form con kế thừa `HRFORM` có thể ghi đè (override) các hàm này để chèn logic nghiệp vụ riêng:

| Method | Thời điểm gọi | Return | Mô tả |
|---|---|---|---|
| `BeforeSave()` | Trước khi Lưu | 1 = Tiếp tục, 0 = Dừng | Validate dữ liệu, nghiệp vụ riêng. |
| `AfterSave()` | Sau khi Lưu | - | Refresh lại form, hiển thị thông báo. |
| `BeforeDelete()` | Trước khi Xóa | 1 = Tiếp tục, 0 = Dừng | Kiểm tra ràng buộc dữ liệu. |
| `AfterDelete()` | Sau khi Xóa | - | Refresh lưới sau khi xóa thành công. |
| `AfterViewForm()` | Sau khi nạp Grid | - | Định dạng lưới, gắn Dropdown vào grid. |
| `BeforeSearch()` | Trước khi Tìm kiếm | 1 = Tiếp, 0 = Dừng | Chuẩn bị tham số truy vấn. |

---

## 3. ThuVienChucNang – Thư Viện Tiện Ích

**File:** [Library/ThuVienChucNang.vb](file:///e:/SourceCodeHR/POCONS/WindowsControlLibrary/Library/ThuVienChucNang.vb) (File đồ sộ nhất, >5000 dòng)

Chứa các hàm xử lý dùng chung cho toàn bộ dự án. Dùng qua biến instance `tvcn`.

### Nhóm hàm chính:

1. **Mapping và Xử lý Database:**
   - `LuuHoacXoaTuForm()`: Core engine xử lý lưu form xuống DB.
   - `NhapDuLieuTuGridLenFormNhap()`: Đẩy dữ liệu từ dòng Grid đang chọn vào các Control tương ứng trên Form nhập.
   - `ThemDauSaoChoTruongBuocNhap()`: Tự động thêm dấu `*` đỏ vào Label của các trường NOT NULL.

2. **Giao Diện & Grid:**
   - `TaoDropDowTrenGrid()`: Gắn data source (Combobox) vào một cột cụ thể của lưới.
   - `FormatGridEx()`: (Legacy) Định dạng các lưới cũ.
   - `LoadDesign()`: Áp dụng theme và font cho ứng dụng.

3. **Chức Năng Excel & Export:**
   - `LayTemplateEPPlus()`: Lấy file template Excel từ máy chủ/thư mục gốc.
   - `NhapExcelToDatableEPPlus()`: Đọc file Excel đẩy vào DataTable.
   - `XuatDanhSachNhanVienTheoLuoi()`: Export Grid hiển thị thành file Excel.

4. **Dropdown Helpers:**
   - `SearchEmployee()`: Khởi tạo lookup nhân viên cho LookUpEdit.
   - `GetDataOnDropDownCategoryCodeName()`: Đổ danh sách (Tỉnh thành, chức vụ...) vào Combobox/LookUpEdit.

5. **Đa Ngôn Ngữ (Multi-language):**
   - `ChangeLanguageToForm(Form, ...)`: Đổi ngôn ngữ cho toàn bộ Label, Header của form sang EN/VN/KR.
   - `GetLanguagesTranslated(Key)`: Lấy text dịch từ file language dựa trên key.

---

## Dependencies

```
WindowsControlLibrary
    │
    ├──► SmartBooks.BusinessLogic  (Gọi để thao tác DB, phân quyền)
    ├──► Appsettings              (Sử dụng DbSetting của riêng thư viện này)
    └──► CommonLib                (DevExpress, Janus controls)
```
