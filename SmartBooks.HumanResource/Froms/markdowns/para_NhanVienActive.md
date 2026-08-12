# para_NhanVienActive – Chọn danh sách nhân viên đang active (form tham số)

## Vị trí file
- `Froms/Para/para_NhanVienActive.vb` (thuần code-behind, không có file `.Designer.vb` riêng — giao diện được sinh trong cùng file, trong vùng `#Region " Windows Form Designer generated code "`)
- Kế thừa: `WindowsControlLibrary.HRFORM`, nhưng **không dùng theo pattern grid+search chuẩn** của HRFORM
- `HRFORM_TableName = "abc"` (giá trị giả/không dùng thật – form không thao tác trực tiếp trên 1 bảng nghiệp vụ cụ thể)
- Không có Load lưới theo `sp_...` chuẩn; nguồn dữ liệu grid được gán trực tiếp bằng `GridControl1.DataSource = kn.ReadData(...)`

## Mục đích
Đây **không phải một màn hình nghiệp vụ độc lập** mà là một **form tham số/dialog phụ trợ** (mở bằng `ShowDialog()`) dùng để **chọn một danh sách nhân viên đang hoạt động (active)** trong một khoảng thời gian (`fromdate` – `todate`), phục vụ cho các form khác khi cần lấy mẫu file Excel nhập liệu theo danh sách nhân viên. Qua tra cứu mã nguồn, form này được gọi từ:
- `TimeKeeping/frmRegisMaxOvertime.vb` (khi `ReportRow("ReportCode") = "RegisMaxOvertimeGetTemplateFollowDate"`, thực hiện trong `ExecSubOrFunctionOfVB`, ứng với nút **Thực hiện**/**Lấy mẫu** của form đăng ký làm thêm giờ tối đa)
- `TimeKeeping/frmEmpRegisTimeSheet.vb` (tương tự, cho form đăng ký bảng chấm công nhân viên)

Sau khi người dùng chọn nhân viên và bấm OK, form gọi lưu trả về danh sách `Employee_ID`/`Card_Code` được chọn để form cha dùng tạo file Excel mẫu (`tvcn.LayTemplateTheoThoiGian`).

## Bố cục giao diện/field chính
Không dùng `TableLayoutPanel` chuẩn của HRFORM; bố cục gồm 2 khối:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| `GroupBox1` | `GridControl1` / `GridView1` | DevExpress Grid (Dock=Fill) | Danh sách nhân viên đang active trong khoảng thời gian được truyền vào |
| `GroupBox2` | `btnOK`, `btnCancel` | SimpleButton | Xác nhận chọn / Hủy |

Thanh `PanelButton` chuẩn của `HRFORM` bị **ẩn hoàn toàn** (`Me.PanelButton.Visible = False`) vì form không dùng các nút Thêm/Sửa/Xóa/Lưu chuẩn.

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **OK** (`btnOK`) | `btnOk_Click` (đã khai báo trong code) | Set `bLuu = True` (field kế thừa từ `HRFORM`) rồi đóng form (`Me.Close()`) |
| **Cancel** (`btnCancel`) | `btnCancel_Click` (đã khai báo trong code) | Đóng form, không set `bLuu` |

## Luồng xử lý chính

1. **Trước khi mở form**, form cha gọi các hàm setter công khai để truyền tham số:
   - `Set_FromDate(fromdate_)`, `Set_ToDate(todate_)` – khoảng thời gian xét active.
   - `Set_DanhSachMaNVLoaiTru(mangMaNV())` – (tùy chọn) danh sách mã nhân viên cần loại trừ khỏi kết quả.
   - Thuộc tính public `DieuKienLoc` – (tùy chọn) chuỗi điều kiện WHERE tùy biến để lọc `SmartBooks_Employee` thay cho logic active mặc định.

2. **`para_NhanVienActive_Load`**
   - Set tiêu đề `Me.Text = "List Of Employee"`.
   - Nếu `DieuKienLoc` khác rỗng: `GridControl1.DataSource = kn.ReadData("select * from SmartBooks_Employee where " + DieuKienLoc, ...)`.
   - Ngược lại: gọi `LayDanhSachNhanVienActive(DanhSachMaNVLoaiTru)` – dùng hàm SQL `udf_NhanVienDangActiveTheoKhoangThoiGian(fromdate, todate, Lan)` để lấy danh sách nhân viên active trong khoảng thời gian; nếu có danh sách loại trừ thì thêm `where Employee_ID not in (...)`.
   - `tvcn.FocusGrd(GridView1, 0, -2)` – focus vào dòng đầu grid.

3. **Sau khi đóng form (`ShowDialog`)**, form cha kiểm tra `frm.bLuu`; nếu `True` thì đọc kết quả qua:
   - `Get_DanhSachNhanVienDuocChon()` – nối các `Employee_ID` của các dòng đang được chọn trên grid (mỗi mã 1 dòng, `Environment.NewLine`).
   - `Get_DanhSachTheTuDuocChon()` – tương tự nhưng lấy cột `Card_Code` (mã thẻ từ).

## Ghi chú kỹ thuật
- **Không theo pattern HRFORM chuẩn**: không có `Search()`/`sp_...` phân quyền cơ cấu tổ chức, không có `TableLayoutPanel` nhập liệu, không dùng `HRFORM_VisibleControl_...`; đây thực chất là một **dialog chọn dữ liệu (picker)** tận dụng lại lớp `HRFORM` chỉ để có sẵn field `bLuu` và (có thể) hạ tầng grid, chứ không dùng cơ chế Thêm/Sửa/Xóa/Lưu/Search chuẩn.
- **Phát hiện đáng lưu ý**: hai `Sub btnOk_Click` và `btnCancel_Click`, cũng như `Sub gridDanhSachNhanVien_KeyUp`, được khai báo trong code nhưng **không có mệnh đề `Handles`** gắn với sự kiện `Click`/`KeyUp` của các control tương ứng (`btnOK.Click`, `btnCancel.Click`, `GridControl1.KeyUp`), và cũng không tìm thấy `AddHandler` nào gắn thủ công trong file. Theo cú pháp VB.NET, nếu không có `Handles` hay `AddHandler` thì các sự kiện Click/KeyUp của các control này sẽ **không** tự động gọi các Sub trên. Đây có thể là lỗi tồn đọng trong code (cần rà soát thêm ở lớp designer hoặc nơi khác nếu có) chứ không phải suy đoán chủ quan — được ghi nhận đúng như đọc được từ `para_NhanVienActive.vb`.
- File không có `.Designer.vb` tách riêng; toàn bộ code giao diện nằm chung trong `para_NhanVienActive.vb` theo kiểu code cũ (không phải form được thiết kế lại theo chuẩn `HRFORM` các form khác).
