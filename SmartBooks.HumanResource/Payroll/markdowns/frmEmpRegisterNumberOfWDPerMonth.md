# frmEmpRegisterNumberOfWDPerMonth – Đăng ký số ngày công/tháng

## Vị trí file
- `Payroll/frmEmpRegisterNumberOfWDPerMonth.vb` (chứa cả code + `InitializeComponent` – **không có file `.Designer.vb` riêng**, giống kiểu tổ chức của `frmEmpNonRegisInsurance` trong module BaoHiem)
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_EmpRegisterNumberOfWDPerMonth` (`HRFORM_TableName`)
- Form popup Thêm/Sửa: `HRFORM_InputForm = "frmEmpRegisterNumberOfWDPerMonth_Nhap"`

## Mục đích
Đây là **form danh sách thuần (list-only)**: không có panel nhập liệu trực tiếp, không có ô tìm kiếm, chỉ có 1 `GridControl1` chiếm toàn bộ diện tích tab "General". Toàn bộ việc Thêm/Sửa được ủy quyền cho form popup `frmEmpRegisterNumberOfWDPerMonth_Nhap` (mở qua cơ chế chuẩn `tvcn.AddNewOrEdit` khi bấm nút Thêm/Sửa trên `PanelButton` kế thừa từ `HRFORM`). Tên bảng/form cho thấy nghiệp vụ là khai báo **số ngày công chuẩn theo tháng** cho từng nhân viên (dùng làm cơ sở/tham chiếu khi tính lương, ví dụ trường hợp ngày công chuẩn khác mặc định của công ty).

## Bố cục giao diện
Không có `TableLayoutPanel2`/panel nhập liệu như các form khác trong module — form chỉ gồm:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Toàn bộ tab `General` | `GridControl1` / `GridView1` | DevExpress Grid, `Dock = Fill` | Danh sách các bản ghi đăng ký số ngày công/tháng đã khai báo |

Vì không có control nhập liệu nào khác ngoài grid, toàn bộ chi tiết trường dữ liệu (nhân viên, tháng/năm, số ngày công...) nằm trong form popup `frmEmpRegisterNumberOfWDPerMonth_Nhap` — **không tìm thấy file này trong mã nguồn hiện tại** (xem Ghi chú kỹ thuật).

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| Thêm / Sửa (nút chuẩn `HRFORM`, không override) | kế thừa (`btnAdd_Click`/`btnEdit_Click` trong `HRFORM`) | Gọi `tvcn.AddNewOrEdit(True/False, Me, HRFORM_TableName, HRFORM_Gridview, QuyenHRFORM, HRFORM_InputForm)` → tạo instance form `frmEmpRegisterNumberOfWDPerMonth_Nhap` bằng `CreateForm`/`CreateObjectInstance` (khởi tạo động theo tên lớp) và mở `ShowDialog()` |
| Xóa / Xuất-nhập Excel / F5 / Lưu layout... | kế thừa | Hoạt động theo cơ chế chung của `HRFORM` (không bị ẩn bởi cờ `HRFORM_VisibleControl_...` nào trong form này — form không set các cờ ẩn nút Thêm/Sửa như các form nhập-trên-panel khác trong module) |

## Luồng xử lý

1. **`frmContractList_Load` (Handles `MyBase.Load`)** — tên hàm còn sót lại từ việc copy code từ form khác (`frmContractList`), không đổi tên theo class hiện tại. Chỉ gọi `LoadGiaoDienTheoDieuKien()` để bật/tắt nút theo quyền `QuyenHRFORM`. **Không có** hàm `Search()` riêng, không load dữ liệu ban đầu bằng câu lệnh tùy biến — dựa hoàn toàn vào cơ chế mặc định của `HRFORM` (nếu có) hoặc chỉ hiển thị grid rỗng cho tới khi Thêm/Sửa qua popup.
2. **`Gridex1_KeyUp` (Handles `GridControl1.KeyUp`)** — ủy quyền phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` của `HRFORM`.
3. Không có `Search()`, không có `btnSave_Click`, không có `AfterViewForm` override — đây là form đơn giản nhất trong 4 form được khảo sát, hoàn toàn dựa vào hành vi mặc định của `HRFORM` cho việc xem/thêm/sửa/xóa qua popup.

## Ghi chú kỹ thuật
- **Không tách `.Designer.vb`** — toàn bộ `InitializeComponent()` nằm chung trong `frmEmpRegisterNumberOfWDPerMonth.vb`, giống quy ước của `frmEmpNonRegisInsurance` (module BaoHiem).
- **Tên sự kiện Load bị đặt sai** (`frmContractList_Load` thay vì `frmEmpRegisterNumberOfWDPerMonth_Load`) — dấu vết copy-paste từ `frmContractList.vb` (form khác cùng thư mục `Payroll/`, cũng dùng cơ chế `HRFORM_InputForm = "frmContractList_Nhap"`). Không ảnh hưởng tới hoạt động vì được gắn `Handles MyBase.Load` chứ không dựa theo tên.
- **Bất thường quan trọng**: `HRFORM_InputForm = "frmEmpRegisterNumberOfWDPerMonth_Nhap"` nhưng tìm kiếm toàn bộ mã nguồn (`grep -r frmEmpRegisterNumberOfWDPerMonth_Nhap`) **không tìm thấy** file/class nào định nghĩa form này trong solution hiện tại. Vì `tvcn.AddNewOrEdit` dùng `CreateForm(InputFormName)` → `CreateObjectInstance` để khởi tạo form bằng tên lớp qua reflection, nếu class `frmEmpRegisterNumberOfWDPerMonth_Nhap` thực sự không tồn tại (không nằm trong assembly đã biên dịch), bấm nút **Thêm**/**Sửa** trên form này sẽ ném lỗi runtime (không tìm thấy Type). Có thể form popup đã bị xóa nhầm, đổi tên, hoặc nằm ở nhánh/khu vực mã nguồn khác chưa được đồng bộ — cần xác minh thêm với đội phát triển trước khi coi đây là chức năng hoạt động đầy đủ.
- Không có cờ `HRFORM_VisibleControl_ThemMoi/Sua = False` nào được set → khác hẳn 3 form còn lại trong đợt khảo sát này (`frmEmpRegisParameter`, `frmLuongCoDinh`, `frmMucLuong`) đều ẩn nút Thêm/Sửa vì nhập liệu trực tiếp trên panel; form này đi theo mô hình (b) "danh sách thuần + popup" đúng như mô tả kiến trúc chung.
