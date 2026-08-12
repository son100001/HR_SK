# Holidays_Plan – Kế hoạch nghỉ lễ

## Vị trí file
- `Froms/Holidays_Plan.vb`, `Holidays_Plan.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `SmartBooks_HolidaysPlan` (`HRFORM_TableName`)

## Mục đích
Khai báo **danh sách ngày nghỉ lễ/kế hoạch nghỉ chung của công ty** (không gắn với một nhân viên cụ thể): mỗi bản ghi gồm loại nghỉ, ngày nghỉ và ghi chú. Đây là danh mục dùng chung cho toàn hệ thống (ví dụ để tính công/nghỉ lễ trong chấm công, tính lương), khác với các form quản lý nghỉ phép theo từng nhân viên.

## Bố cục giao diện
Form gồm 1 tab "General" chứa `TableLayoutPanel2` (không có vùng tìm kiếm nhân viên) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Nhập liệu (`pnDuLieuNhap`) | `lblTypeOfLeave` + `TypeOfLeave` | Label + LookUpEdit | Loại nghỉ, dữ liệu nạp từ bảng `SmartBooks_LeaveType` (hiển thị kèm số ngày/tháng tối đa được phép nghỉ của loại đó) |
| Nhập liệu (`pnDuLieuNhap`) | `lblH_date` + `H_date` | Label + DateEdit | Ngày nghỉ lễ (mặc định = ngày hiện tại khi mở form) |
| Nhập liệu (`pnDuLieuNhap`) | `lblGhiChu` + `Description` | Label + RichTextBox | Ghi chú |
| Lưu (`pnNhap`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách các ngày nghỉ lễ đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Lưu** (`btnSave`) | `btnSave_Click` | 1) Kiểm tra trường bắt buộc trên `TableLayoutPanel2` (`tvcn.CheckErrorProvider`), dừng và báo lỗi nếu thiếu. 2) `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` – Insert/Update trực tiếp bản ghi kế hoạch nghỉ lễ. 3) Focus lại `TypeOfLeave`. 4) Gọi lại `Search()` để refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThucHien = False`, `HRFORM_VisibleControl_cbbReport = False` → chỉ còn nút Xóa/Xuất Excel/F5... của `HRFORM`; ẩn hẳn nút Thực hiện và combo chọn mẫu in vì form này không xuất báo cáo |

## Luồng xử lý chính

1. **`Holidays_Plan_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2` theo cấu trúc bảng `SmartBooks_HolidaysPlan`.
   - Nạp `tabLeaveType` (biến cấp form) bằng câu SQL đọc `SmartBooks_LeaveType`, ghép chuỗi hiển thị dạng "Tên loại nghỉ - Tối đa: N ngày/tháng" làm nguồn cho LookUpEdit `TypeOfLeave` (`tvcn.GetDataOnDropDownCategoryCodeName`).
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt nút theo quyền.
   - Set `H_date.DateTime = Today` (mặc định ngày hiện tại).
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`** – câu lệnh đơn giản `select * from SmartBooks_HolidaysPlan` (không có tham số phân quyền theo cơ cấu tổ chức hay lọc theo nhân viên, vì đây là danh mục chung toàn công ty). `Xem(...)` đổ lên grid, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)** – gắn dropdown chọn nhanh trên cột `TypeOfLeave` của grid, dùng lại `tabLeaveType` đã nạp ở bước Load (`tvcn.TaoDropDowTrenGrid`).

4. **`GridControl1_KeyUp`** – ủy quyền phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` của `HRFORM`.

## Ghi chú kỹ thuật
- Khác với `frmInsurance`/`frmQuaTrinhHocTapCongTac`, form này **không có ô tìm kiếm theo nhân viên và không có nút Tìm** vì dữ liệu là danh mục chung (kế hoạch nghỉ lễ áp dụng cho cả công ty), nên `Search()` không nhận tham số và không lọc theo `Employee_ID`.
- Vẫn theo đúng pattern chuẩn của `HRFORM` cho phần nhập liệu/lưu (`TableLayoutPanel` + `tvcn.LuuHoacXoaTuForm`) và cho phần grid (`AfterViewForm` gắn dropdown trên cột).
- Nhãn `lblGhiChu` ("Ghi chú") thực chất là label của control `Description` (RichTextBox) chứ không có control riêng tên `Remark` như các form khác trong batch.
