# Salary_Parameter – Tham số lương theo Tháng/Năm

## Vị trí file
- `Payroll/Salary_Parameter.vb` — **không có file `.Designer.vb` riêng**; toàn bộ code Designer (`InitializeComponent`, khai báo control) nằm gộp trong chính file `.vb`, trong `#Region " Windows Form Designer generated code "` (phong cách VB.NET đời cũ, khác với các form mới hơn dùng Partial Class + `.Designer.vb` tách riêng)
- Kế thừa: `HRFORM` (`Public Class Salary_Parameter \n Inherits HRFORM`)
- Bảng dữ liệu: `SmartBooks_Salary_Parameter` (`HRFORM_TableName = "SmartBooks_Salary_Parameter"`)
- Không gán `HRFORM_SaveStore`, không gán `HRFORM_DeleteStore`, không gán `HRFORM_InputForm`
- **Không** ẩn nút Thêm/Sửa/Xóa/Lưu chuẩn của `HRFORM` (không set các cờ `HRFORM_VisibleControl_...` = False) → khác với đa số form "nhập liệu tại chỗ trên panel" khác trong `Payroll/`

## Mục đích
**Lưu ý quan trọng:** mặc dù tên file có tiền tố `Salary_Parameter` (gợi ý "form tham số/bộ lọc" giống `para_NhanVienActive`), đọc code thực tế cho thấy đây **là 1 form CRUD thật**, quản lý bảng `SmartBooks_Salary_Parameter`: khai báo các **tham số tính lương theo từng Tháng/Năm** — tỷ giá quy đổi (`ExchangeRate`), số ngày công chuẩn của tháng (`WorkingDay`, `WorkingDay1`) và ghi chú. Đây là dữ liệu nền dùng chung cho việc tính lương toàn công ty theo kỳ lương, không gắn với 1 nhân viên/phòng ban cụ thể.

## Bố cục giao diện
`TableLayoutPanel2` gồm 2 vùng ngang + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Nhập liệu (`pnDuLieuNhap`) | `lblMonth` + `Salary_Month` + `Salary_Year` | Label + `WindowsControlLibrary.Month` + `WindowsControlLibrary.Year` | Tháng/Năm áp dụng tham số |
| Nhập liệu (`pnDuLieuNhap`) | `lblWorkingDay` + `WorkingDay` | Label + TextBox | Số ngày công (chuẩn) |
| Nhập liệu (`pnDuLieuNhap`) | `lblWorkingDay1` + `WorkingDay1` | Label + TextBox | Số ngày công 1 (không có mô tả rõ ràng trong code, chỉ có nhãn mặc định "WorkingDay1") |
| Nhập liệu (`pnDuLieuNhap`) | `lblExchangeRate` + `ExchangeRate` | Label + TextBox | Tỷ giá / Số tiền (tự động format dấu phẩy ngàn khi gõ) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnNhap`) | `btnSave` ("Lưu") | SimpleButton | Nút Lưu tùy biến — **hiện không có xử lý** (xem Ghi chú kỹ thuật) |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách tham số lương đã khai báo theo từng Tháng/Năm |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| `btnSave` (panel `pnNhap`, "Lưu") | `btnSave_Click` | **Rỗng — không có code xử lý bên trong.** Bấm nút này hiện tại không lưu gì cả |
| Các nút chuẩn của `HRFORM` (Thêm/Sửa/Xóa/Lưu/Tải lại...) | kế thừa, không bị ẩn | Hoạt động theo cơ chế popup chuẩn (`tvcn.AddNewOrEdit` gọi `HRFORM_InputForm`) — nhưng `HRFORM_InputForm` **không được gán** trong đoạn code đọc được, nên chưa rõ popup nhập liệu nào sẽ được mở khi bấm Thêm/Sửa chuẩn |

## Luồng xử lý

1. **`frmDependentPerson_Load`** (Handles `MyBase.Load`) — tên hàm không khớp tên class `Salary_Parameter` (nhiều khả năng code được copy từ form khác tên `frmDependentPerson` – "Người phụ thuộc" – rồi đổi tên class nhưng quên đổi tên hàm; do vẫn có `Handles MyBase.Load` nên chức năng Load không bị ảnh hưởng):
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc theo cấu trúc bảng `SmartBooks_Salary_Parameter`.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt nút theo quyền.
   - Gọi `Search()`.

2. **`Search()`** — `QR = "select * from SmartBooks_Salary_Parameter"` rồi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)`, lưu `HRFORM_QueryView = QR`. **Không có điều kiện lọc** (không theo tháng/năm, không theo phân quyền cơ cấu tổ chức) — hợp lý vì đây là bảng tham số chung, số dòng dữ liệu nhỏ (1 dòng/tháng).

3. **`AfterViewForm()`** (override) — set `GridView1.Columns.ColumnByFieldName("ExchangeRate").DisplayFormat.FormatString = "N2"` để hiển thị số có phần thập phân/phân cách ngàn trên grid.

4. **`ExchangeRate_TextChanged`** — tự động format lại nội dung ô `ExchangeRate` theo dạng `"###,###"` (phân cách hàng ngàn) mỗi khi gõ; nếu nhập ký tự không hợp lệ thì hiển thị cảnh báo `Popup.Loidinhdangtien` và tự xóa ký tự vừa gõ sai.

5. **`Gridex1_KeyUp`** (bắt trên `GridControl1.KeyUp`) — ủy quyền cho `Gridview_KeyUp` xử lý phím tắt chuẩn (Ctrl+S/D/F/Q, F5).

6. **`btnSave_Click`** (nút "Lưu" tùy biến trên `pnNhap`) — rỗng, không làm gì.

## Ghi chú kỹ thuật
- **Không phải form tham số/bộ lọc mở báo cáo khác** như phỏng đoán ban đầu theo quy ước đặt tên `_Parameter` — code cho thấy đây là 1 form quản lý danh mục (CRUD) thật sự cho bảng `SmartBooks_Salary_Parameter`.
- Tên hàm Load là `frmDependentPerson_Load` thay vì `Salary_Parameter_Load` — dấu vết code được sao chép từ form "Người phụ thuộc" (`frmDependentPerson`) rồi đổi tên class nhưng quên đổi tên thủ tục; không ảnh hưởng chức năng vì vẫn gắn `Handles MyBase.Load`.
- Nút "Lưu" tùy biến (`btnSave` trên `pnNhap`) có `Click` handler **rỗng** — hiện không hoạt động. Việc lưu dữ liệu (nếu có) chỉ có thể qua nút Thêm/Sửa chuẩn của `HRFORM` (popup `AddNewOrEdit`), nhưng `HRFORM_InputForm` (tên form popup dùng để nhập) không thấy được gán ở bất kỳ đâu trong file — cùng với việc `HRFORM_SaveStore` cũng không được set, đây là dấu hiệu form **chưa hoàn thiện chức năng lưu**, cần kiểm tra thêm nếu được dùng thực tế trong nghiệp vụ tính lương.
- `Search()` không áp dụng điều kiện phân quyền cơ cấu tổ chức (`obj.PARA_...`) như hầu hết form khác trong `Payroll/` — phù hợp vì dữ liệu tham số lương là dữ liệu chung toàn công ty theo kỳ, không phân theo phòng ban/nhân viên.
- Vì không tách file `.Designer.vb`, mọi thay đổi giao diện qua Visual Studio Designer sẽ ghi đè trực tiếp vào phần `#Region` bên trong `Salary_Parameter.vb`.
