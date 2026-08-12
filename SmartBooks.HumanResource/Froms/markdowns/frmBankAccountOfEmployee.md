# frmBankAccountOfEmployee – Tài khoản ngân hàng của nhân viên

## Vị trí file
- `Froms/frmBankAccountOfEmployee.vb`, `frmBankAccountOfEmployee.designer.vb`, `frmBankAccountOfEmployee.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_BankAccountOfEmployee` (`HRFORM_TableName`)
- Stored procedure Lưu: `usp_InsertUpdateHR_BankAccountOfEmployee` (`HRFORM_SaveStore`)
- Stored procedure Xóa: `usp_DeleteHR_BankAccountOfEmployee` (`HRFORM_DeleteStore`)

## Mục đích
Quản lý **tài khoản ngân hàng** của từng nhân viên (dùng để chuyển lương): tên ngân hàng, số tài khoản, trạng thái đang sử dụng hay không, ghi chú. Một nhân viên có thể có nhiều dòng tài khoản (lịch sử/nhiều ngân hàng).

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`, đặt trong `TableLayoutPanel3` trống phía trên) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblBankAccount` + `BankAccount` | Label + TextBox | Số tài khoản |
| Nhập liệu (`pnDuLieuNhap`) | `lblBankName` + `BankName` | Label + LookUpEdit | Ngân hàng (danh mục `"BankName"`) |
| Nhập liệu (`pnDuLieuNhap`) | `isUsing` | CheckBox ("Using") | Đánh dấu tài khoản đang sử dụng |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách tài khoản ngân hàng đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc lại danh sách theo `Employee_ID` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, HRFORM_SaveStore, TableLayoutPanel2, ErrorProvider1)` để Insert/Update trực tiếp từ giá trị các control trên `TableLayoutPanel2`; nếu thành công gọi lại `Search()`; sau đó focus `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel, không dùng popup Thêm/Sửa; các nút Xóa/Xuất Excel/F5... vẫn theo cơ chế chung |

## Luồng xử lý

1. **`frmBankAccountOfEmployee_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc theo cấu trúc bảng `HR_BankAccountOfEmployee`.
   - `tvcn.GetDataOnDropDownCategoryCodeName(BankName, "BankName")` – nạp danh mục ngân hàng cho `BankName`.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên cho LookUpEdit tìm kiếm.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - Build: `exec [dbo].[sp_BangTaiKhoanNganHang] '<Today>',2,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'` (tham số `2` phân biệt loại dữ liệu trên stored procedure dùng chung, đầy đủ tham số phân quyền theo cơ cấu tổ chức lấy từ `obj.PARA_...`).
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Employee_ID_EditValueChanged`** – khai báo nhưng không tự tìm kiếm (dòng `Search()` bị comment); người dùng phải bấm **Tìm**.

4. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp`.

## Ghi chú kỹ thuật
- Form theo đúng khuôn mẫu kiểu (a) mô tả trong tài liệu nền (nhập trực tiếp trên panel, `tvcn.SaveByStore` gọi `HRFORM_SaveStore`) – không override `BeforeSave()`/`AfterViewForm()`, không có logic đặc thù nào khác ngoài CRUD chuẩn.
- `TableLayoutPanel3` tồn tại trong Designer nhưng rỗng (không chứa control nào, cao 2px) – phần trang trí/layout còn sót lại, không ảnh hưởng nghiệp vụ.
- Không có ràng buộc kiểm tra trùng ngân hàng/số tài khoản trong code – việc kiểm tra dữ liệu hợp lệ (nếu có) nằm trong stored procedure `usp_InsertUpdateHR_BankAccountOfEmployee`.
