# frmMucLuongNhanVien – Mức lương nhân viên

## Vị trí file
- `Payroll/frmMucLuongNhanVien.vb`, `frmMucLuongNhanVien.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_MucLuongNhanVien` (`HRFORM_TableName = "HR_MucLuongNhanVien"`)
- Stored procedure Lưu: `[dbo].[usp_InsertUpdateHR_MucLuongNhanVien]` (gọi trực tiếp trong `btnSave_Click`, không gán qua `HRFORM_SaveStore`)
- Stored procedure Xóa: `usp_DeleteHR_MucLuongNhanVien` (`HRFORM_DeleteStore`)
- `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nút Thêm/Sửa dạng popup bị ẩn, nhập liệu thực hiện trực tiếp trên panel (giống `frmInsurance`)

## Mục đích
Quản lý **lịch sử mức lương** của từng nhân viên: mỗi bản ghi gồm Nhóm lương (`SalaryGroup`), Bậc lương (`SalaryStep`), khoảng thời gian áp dụng (`FromDate` → `ToDate`, có thể để trống ngày kết thúc nếu đang áp dụng) và ghi chú. Người dùng tìm theo mã nhân viên, nhập/sửa mức lương ngay trên panel rồi lưu.

## Bố cục giao diện
Form gồm 1 tab `General`, bên trong `TableLayoutPanel2` chia 3 vùng ngang + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên cần xem/nhập mức lương |
| Tìm kiếm (`pnSearch`) | `btnSearch` ("Tìm") | SimpleButton | Lọc lại danh sách theo `Employee_ID` |
| Nhập liệu (`pnDuLieuNhap`) | `lblSalaryGroup` + `SalaryGroup` | Label + LookUpEdit | Nhóm lương (nạp distinct từ `HR_MucLuong`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblSalaryStep` + `SalaryStep` | Label + LookUpEdit | Bậc lương (nạp distinct từ `HR_MucLuong`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblFromDate` + `FromDate` | Label + DateEdit | Từ ngày áp dụng (mặc định = hôm nay) |
| Nhập liệu (`pnDuLieuNhap`) | `cbToDate` + `lblToDate` + `ToDate` | CheckBox + Label + DateEdit | Bật `cbToDate` mới cho phép nhập `ToDate` (đến ngày); tắt thì `ToDate` bị disable và xóa giá trị |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` ("Lưu") | SimpleButton | Lưu bản ghi mức lương |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Lịch sử mức lương đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_MucLuongNhanVien]", TableLayoutPanel2, ErrorProvider1)` — hàm tiện ích đọc toàn bộ control trên `TableLayoutPanel2` và gọi thẳng stored procedure chỉ định (khác cơ chế `tvcn.LuuHoacXoaTuForm` dùng ở `frmInsurance`); nếu thành công thì gọi lại `Search()`, sau đó focus vào `SalaryGroup` |
| `cbToDate` (checkbox) | `cbToDate_CheckedChanged` | Bật/tắt (Enable) ô `ToDate`; bật thì set `ToDate = Today`, tắt thì xóa `ToDate.EditValue` |
| Các nút chuẩn của `HRFORM` (Thêm/Sửa/Xóa/Xuất Excel/F5...) | kế thừa | `ThemMoi`/`Sua` bị ẩn (nhập trực tiếp trên panel); các nút Xóa/Xuất Excel/Tải lại... hoạt động theo cơ chế chung của `HRFORM` |

## Luồng xử lý

1. **`frmMucLuongNhanVien_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc theo cấu trúc bảng `HR_MucLuongNhanVien`.
   - `FromDate.EditValue = Today`.
   - Đọc `select distinct SalaryGroup from HR_MucLuong` và `select distinct SalaryStep from HR_MucLuong`, nạp vào 2 LookUpEdit `SalaryGroup`/`SalaryStep` qua `tvcn.GetDataOnDropDownCategoryCodeName` (danh mục nhóm/bậc lương lấy từ chính bảng thang lương `HR_MucLuong`, không phải bảng danh mục riêng).
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt nút theo quyền (`QuyenHRFORM`).
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Build: `exec [dbo].[sp_BangMucLuongNhanVien] null,null,1,'<Lan>',NULL,NULL,NULL,NULL,NULL,NULL,N'<Employee_ID>'` (tham số cơ cấu tổ chức đều truyền `NULL`, chỉ lọc theo `Employee_ID` nếu có nhập).
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ lên `GridControl1`; lưu `HRFORM_QueryView = QR` để F5 refresh.

3. **`Gridex1_KeyUp`** (bắt trên `GridControl1.KeyUp`) – ủy quyền cho `Gridview_KeyUp` xử lý phím tắt chuẩn (Ctrl+S/D/F/Q, F5).

4. **`btnSave_Click`** → như mô tả ở bảng nút trên; **`cbToDate_CheckedChanged`** → bật/tắt `ToDate`.

## Ghi chú kỹ thuật
- Hàm `Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)` được khai báo trong code (dự định: F3 mở `para_NhanVien` để chọn nhanh nhân viên, Ctrl+S gọi `btnSave_Click`) nhưng **không có mệnh đề `Handles Employee_ID.KeyUp`** — sự kiện này không được nối dây với control `Employee_ID` (cả trong `.vb` lẫn `.Designer.vb` đều không có `AddHandler`/`Handles` tương ứng). Do đó phím F3/Ctrl+S trên ô `Employee_ID` **không hoạt động** trên thực tế; đây nhiều khả năng là code sao chép từ form khác còn sót lại.
- Việc lưu dùng `tvcn.SaveByStore` (gọi thẳng stored procedure theo tên control trùng tên cột) thay vì `tvcn.LuuHoacXoaTuForm` như `frmInsurance` — cả hai đều là cơ chế "nhập liệu tại chỗ trên panel", nhưng khác helper nội bộ.
- Danh mục `SalaryGroup`/`SalaryStep` được nạp động từ dữ liệu thực tế trong bảng thang lương `HR_MucLuong` (distinct value) chứ không phải từ bảng danh mục hệ thống (`udf_...`), nên chỉ hiển thị được các nhóm/bậc đã từng khai báo thang lương.
