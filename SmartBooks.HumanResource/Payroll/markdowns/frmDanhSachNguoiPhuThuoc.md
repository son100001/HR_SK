# frmDanhSachNguoiPhuThuoc – Danh sách người phụ thuộc

## Vị trí file
- `Payroll/frmDanhSachNguoiPhuThuoc.vb`, `frmDanhSachNguoiPhuThuoc.designer.vb`, `frmDanhSachNguoiPhuThuoc.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_DanhSachNguoiPhuThuoc` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_DanhSachNguoiPhuThuoc"`
- `HRFORM_DeleteStore = "usp_DeleteHR_DanhSachNguoiPhuThuoc"`
- `HRFORM_MainFormName = "frmDanhSachNguoiPhuThuoc"`
- `HRFORM_VisibleControl_GetTemplate = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThemMoi = False`

## Mục đích
Quản lý **danh sách người phụ thuộc** của nhân viên phục vụ **giảm trừ gia cảnh thuế TNCN**: họ tên, quan hệ, ngày sinh, giới tính, quốc tịch, thông tin CMT/CCCD, địa chỉ theo giấy khai sinh (tỉnh/quận/phường), mã số thuế, khoảng thời gian được tính giảm trừ (từ tháng – đến tháng), tình trạng đã nộp giấy tờ chứng minh.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu | `RelatedName` | TextBox | Họ tên người phụ thuộc |
| Nhập liệu | `RelatedType` | LookUpEdit | Quan hệ (danh mục `QuanHeGiaDinh`) |
| Nhập liệu | `BirthDate` | DateEdit | Ngày sinh |
| Nhập liệu | `Sex` | LookUpEdit | Giới tính (danh mục `Sex`) |
| Nhập liệu | `DependFromMonth` | DateEdit (mask `MM/yyyy`) | Phụ thuộc từ tháng (mặc định = tháng hiện tại khi Load) |
| Nhập liệu | `DependToMonth` + `cbDependToMonth` | DateEdit + CheckBox | Phụ thuộc đến tháng — `DependToMonth` mặc định `Enabled = False`, chỉ bật khi tick `cbDependToMonth` |
| Nhập liệu | `isDaNopGiay` | CheckBox | Đã nộp giấy tờ chứng minh |
| Nhập liệu | `QuocTich` | LookUpEdit | Quốc tịch (từ `HR_Country`, cột `CountryName_EN`) |
| Nhập liệu | `ID_Number` / `ID_date` / `ID_place` | TextBox / DateEdit / TextBox | Số / Ngày cấp / Nơi cấp CMT-CCCD |
| Nhập liệu | `Address`, `Occupation`, `Tel`, `MaSoThue` | TextBox | Địa chỉ, Nghề nghiệp, Điện thoại, Mã số thuế |
| Nhập liệu | `GKS_So`, `GKS_QuyenSo` | TextBox | Số / Quyển số giấy khai sinh |
| Nhập liệu | `GKS_TinhTP`, `GKS_QuanHuyen`, `GKS_PhuongXa` | LookUpEdit | Tỉnh/TP, Quận/Huyện, Phường/Xã theo giấy khai sinh (từ `HR_TinhThanhPho`/`HR_QuanHuyen`/`HR_PhuongXa`, khóa ghép `Tinh[_Huyen[_Xa]]`) |
| Nhập liệu | `Remark` | RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi (Insert/Update qua `tvcn.SaveByStore`) |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách người phụ thuộc đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_DanhSachNguoiPhuThuoc]", TableLayoutPanel2, ErrorProvider1)` → hỗ trợ cả **Thêm mới lẫn Sửa** (khác `frmFamily` chỉ Insert); thành công thì `Search()` lại, focus `Employee_ID` |
| Checkbox **"Phụ thuộc đến tháng"** (`cbDependToMonth`) | `cbDependToMonth_CheckedChanged` | Bật/tắt `Enabled` của ô `DependToMonth` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_GetTemplate = False` (ẩn nút "Lấy mẫu") |

## Luồng xử lý

1. **`frmDanhSachNguoiPhuThuoc_Load`**
   - Đánh dấu (*) trường bắt buộc.
   - Nạp `RelatedType` (danh mục `QuanHeGiaDinh` — **gọi 2 lần liên tiếp**, dư thừa không ảnh hưởng chức năng), `Sex` (danh mục `Sex`).
   - Tự build DataTable cho `GKS_TinhTP`/`GKS_QuanHuyen`/`GKS_PhuongXa` (khóa ghép chuỗi, **không lọc cascade theo cấp cha** — nạp toàn bộ danh mục cùng lúc, giống `frmFamily`) và `QuocTich` (từ `HR_Country`).
   - `DependFromMonth.EditValue = Today`, `DependToMonth.EditValue = Today` (khác `frmFamily` để trống ban đầu).
   - `tvcn.SearchEmployee(Employee_ID)`, `LoadGiaoDienTheoDieuKien()`, gọi `Search()`.

2. **`Search()`** – build `exec [dbo].[sp_BangNguoiPhuThuocChiTiet] null,null,2,'<Lan>',NULL,NULL,NULL,NULL,NULL,NULL,N'<EmID>'`. **Lưu ý:** các tham số phân quyền cơ cấu tổ chức (Factory/Dept/Section/Team/Position/PositionCategory) đều truyền `NULL` cứng thay vì `obj.PARA_...` như các form khác (`frmContractList`, `frmInsurance`...) — nghĩa là danh sách không bị lọc theo phạm vi tổ chức được phân quyền, chỉ lọc theo `Employee_ID` đang chọn. Gọi `Xem(...)`, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)** – gắn dropdown chọn nhanh trên cột grid `RelatedType` từ `HR_Category where CategoryFather='QuanHeGiaDinh'`, tên cột hiển thị chọn theo `obj.Lan` (VN/EN/KR) bằng `IIf` lồng nhau (khác cách `Name<Lan>` nối chuỗi ở các form khác).

4. **`Employee_ID_KeyUp`** – định nghĩa xử lý phím **F3** (mở popup `para_NhanVien` chọn nhanh nhân viên) và **Ctrl+S** (gọi `btnSave_Click` nếu `btnSave.Enabled`), nhưng **hàm này không có mệnh đề `Handles Employee_ID.KeyUp`** → không được gắn vào sự kiện nào, **không bao giờ được gọi khi chạy thực tế** (dead code).

5. **`Employee_ID_EditValueChanged`** – khai báo nhưng bị comment, không tự tìm kiếm khi đổi nhân viên.

6. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5).

## Ghi chú kỹ thuật
- Dùng chuẩn `tvcn.SaveByStore` (Insert/Update tự động theo khóa chính) — khác hẳn `frmFamily` (form tương tự về nghiệp vụ) chỉ hỗ trợ Insert qua hàm `Save()` tự viết với `ID` luôn = 0.
- `Search()` không áp dụng bộ lọc phân quyền theo cơ cấu tổ chức (Factory/Dept/Section/Team/Position) như đa số form khác trong hệ thống — chỉ lọc theo nhân viên; cần lưu ý khi đối chiếu yêu cầu phân quyền dữ liệu.
- `Employee_ID_KeyUp` (F3 tra cứu nhanh nhân viên, Ctrl+S lưu nhanh) bị mất `Handles`, thực chất **không hoạt động** trên UI — tương tự lỗi nút "18 tuổi" bị `Enabled=False` cố định ở `frmFamily`.
- 3 LookUpEdit giấy khai sinh (`GKS_TinhTP`/`GKS_QuanHuyen`/`GKS_PhuongXa`) nạp toàn bộ danh mục, không cascade lọc theo cấp cha — giống hạn chế đã ghi nhận ở `frmFamily`.
- Không override `BeforeSave`/`BeforeDelete`; không có constructor overload nào khác ngoài mặc định.
