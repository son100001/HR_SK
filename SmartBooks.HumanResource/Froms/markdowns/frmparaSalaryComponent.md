# frmparaSalaryComponent – Chọn thành phần lương (form tham số)

## Vị trí file
- `Froms/Para/frmparaSalaryComponent.vb` (thuần code-behind, không có file `.Designer.vb` riêng — giao diện sinh trong cùng file, trong vùng `#Region " Windows Form Designer generated code "`)
- Kế thừa: `WindowsControlLibrary.HRFORM`, nhưng **không dùng theo pattern grid+search chuẩn** của HRFORM
- `HRFORM_TableName = "abc"` (giá trị giả/không dùng thật)
- Nguồn dữ liệu grid gán trực tiếp: `GridControl1.DataSource = kn.ReadData(...)` từ bảng `HR_SalaryComponentCategory`

## Mục đích
Là một **form tham số/dialog phụ trợ** (mở bằng `ShowDialog()`) dùng để **chọn một hoặc nhiều thành phần lương** (`SalaryComponent`) từ danh mục `HR_SalaryComponentCategory`, phục vụ các form khác khi cần lấy mẫu Excel nhập liệu/khai báo theo các cột thành phần lương được chọn. Qua tra cứu mã nguồn, form được gọi từ:
- `Payroll/frmLuongCoDinh.vb`
- `Payroll/frmSalaryComponent.vb` (khi `ReportCode = "SalaryComponentGetTemplate"`, gán `frm.bMonthlyChanging = True` trước khi `ShowDialog()`)
- `Payroll/frmContractList.vb`

Sau khi người dùng chọn thành phần lương (checkbox) và bấm OK, form cha đọc kết quả để tạo mẫu Excel hoặc dùng làm danh sách cột thành phần lương cần xử lý.

## Bố cục giao diện/field chính
Không dùng `TableLayoutPanel` chuẩn của HRFORM; bố cục gồm 2 khối:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| `Panel2` (Dock=Fill) | `GridControl1` / `GridView1` | DevExpress Grid, `OptionsSelection.MultiSelect=True`, `MultiSelectMode=CheckBoxRowSelect` | Danh sách thành phần lương (cột `SalaryComponent`, `Name<Lan>`, `Insurance`, `MonthlyChanging`) với checkbox chọn nhiều dòng, có auto-filter row |
| `Panel1` (Dock=Bottom) | `btnOk`, `btnCancel` | SimpleButton | Xác nhận chọn / Hủy |

Thanh `PanelButton` chuẩn của `HRFORM` bị **ẩn hoàn toàn** (`Me.PanelButton.Visible = False`).

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Ok** (`btnOk`) | `btnOk_Click` (có `Handles btnOk.Click`) | Nếu có ít nhất 1 dòng đang được chọn (`GridView1.SelectedRowsCount > 0`) thì set `bLuu = True` (field kế thừa từ `HRFORM`), ngược lại `bLuu = False`; sau đó đóng form (`Me.Close()`) |
| **Cancel** (`btnCancel`) | `btnCancel_Click` (có `Handles btnCancel.Click`) | Đóng form, không set `bLuu` |

## Luồng xử lý chính

1. **Trước khi mở form**, form cha có thể set thuộc tính public `bMonthlyChanging` để quyết định tập dữ liệu hiển thị (mặc định `False`).

2. **`frmparaSalaryComponent_Load`**
   - Set tiêu đề `Me.Text = "Thành Phần Lương/Salary Component"`.
   - Nạp `GridControl1.DataSource`:
     - Nếu `bMonthlyChanging = True`: `select SalaryComponent, Name<Lan>, Insurance, MonthlyChanging from HR_SalaryComponentCategory where MonthlyChanging=1 order by OrderBy` (các thành phần lương "biến đổi theo tháng").
     - Ngược lại: cùng câu lệnh nhưng `where MonthlyChanging=0 or MonthlyChanging is null` (thành phần lương cố định).
   - Dịch tiêu đề cột theo ngôn ngữ hiện hành: duyệt toàn bộ `GridColumn.FieldName`, gọi `tvcn.DichNgonNgu` với file `lang\lang.<Lan>.js` để lấy tên cột đã dịch và gán vào `col.Caption`.
   - Cấu hình `HRFORM_Gridview` (chính là `GridView1`) cho phép chọn nhiều dòng bằng checkbox: `OptionsSelection.MultiSelect = True`, `MultiSelectMode = CheckBoxRowSelect`, `CheckBoxSelectorColumnWidth = 25`, ẩn checkbox khi in/xuất (`ShowCheckBoxSelectorInPrintExport = False`), tắt tự auto-width cột, bật auto-filter row (`ShowAutoFilterRow = True`).

3. **Sau khi đóng form (`ShowDialog`)**, form cha kiểm tra `frm.bLuu`; nếu `True` thì đọc kết quả qua:
   - `GetSalaryComponentCode()` – mảng mã `SalaryComponent` của các dòng đang được chọn (nối bằng `"###"` rồi `Split`).
   - `GetSalaryComponentNamveVn()` – mảng tên `NameVN` tương ứng (lưu ý tên hàm có lỗi chính tả "Namve" thay vì "Name").

## Ghi chú kỹ thuật
- **Không theo pattern HRFORM chuẩn**: không có `Search()`/`sp_...` phân quyền theo cơ cấu tổ chức, không có `TableLayoutPanel` nhập liệu, không dùng `HRFORM_VisibleControl_...`; đây là **dialog chọn dữ liệu (picker)** dùng chung cơ chế `bLuu` của `HRFORM` để báo hiệu kết quả chọn cho form cha, tương tự `para_NhanVienActive` nhưng có phần **chọn nhiều dòng bằng checkbox** (`CheckBoxRowSelect`) thay vì chọn hàng thường.
- Khác với `para_NhanVienActive`, các nút **OK/Cancel** ở đây được gắn `Handles` đầy đủ nên hoạt động bình thường. Tuy nhiên `Sub Gridex1_KeyUp` (xử lý Tab để focus `btnOk`, hoặc Ctrl+Enter để xác nhận chọn) **không có `Handles`** và cũng không thấy `AddHandler` gắn với `GridControl1.KeyUp`/`GridView1.KeyUp` trong file — theo code đọc được, phím tắt này hiện không được kích hoạt.
- File không có `.Designer.vb` tách riêng, giao diện nằm chung trong `frmparaSalaryComponent.vb`.
