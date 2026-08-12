# para_Salary – Bảng lương (Tính lương)

## Vị trí file
- `Payroll/para_Salary.vb` (InitializeComponent nằm ngay trong file `.vb`, **không có file `.Designer.vb` riêng**), `para_Salary.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu chính: `SmartBooks_Salary` (`HRFORM_TableName`)
- `HRFORM_DeleteStore = "usp_DeleteSmartBooks_Salary"`; **không có `HRFORM_SaveStore`** (lưu qua override `BeforeSave` tự viết, không dùng `tvcn.SaveByStore`/`LuuHoacXoaTuForm`)
- `HRFORM_VisibleControl_GetTemplate = False`, `HRFORM_VisibleControl_ImportExcel = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThemMoi = False`
- Đăng ký ở menu: `frmMain.vb` → `addMethod("Payroll", "tinhluong", GetType(para_Salary))`

## Mục đích
**Bảng tổng hợp kết quả tính lương** (khác các form khác trong `Payroll/` — đây không phải form nhập liệu mà là **màn hình xem/quản lý kết quả bảng lương đã tính**, cho phép khóa/mở khóa bảng lương và xóa dòng). Dữ liệu được chia thành 10 tab, mỗi tab là 1 loại kết quả lương khác nhau: Bảng lương tổng (General), Lương thôi việc, Trợ cấp thôi việc, Thanh toán phép năm, Truy thu phép năm, Trợ cấp con nhỏ, Quyết toán PIT, Thưởng 30/04-01/05, Thưởng 02/09, Lương tháng 13.

> **Lưu ý về tên file:** mặc dù có tiền tố `para_` (thường dùng cho các form tham số/bộ lọc mở popup, ví dụ `frmPara`), `para_Salary` **thực chất là màn hình danh sách/quản lý chính** của chức năng "Tính lương", được gọi trực tiếp từ menu — không phải popup được mở từ form khác. Tên gọi có thể do kế thừa quy ước đặt tên cũ, không phản ánh đúng vai trò hiện tại của form.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| `Panel1` (docked Top, ngoài tab) | `CongGoc`, `CongDM`, `CongDiff` | 3 CheckBox | Chọn nguồn "Công" (ngày công) dùng để tính — có tính loại trừ lẫn nhau, lưu lựa chọn vào bảng `Setup` (`FunctionID='KH'`) theo user |
| `Panel1` | `lblPayDate`/`PayDate`, `lblXoaNgayThanhToan`/`cbXoaNgayThanhToan`, `btnCapNhat` | Label/DateEdit/CheckBox/Button | Cập nhật ngày thanh toán hàng loạt — **toàn bộ nhóm control này có `Visible = False` mặc định trong Designer**, không hiển thị trên UI thực tế |
| `Panel2` (docked Right trong `Panel1`) | `btnKhoa`, `btnMoKhoa` | SimpleButton | Khóa / Mở khóa bảng lương |
| `XtraTabControl1` (docked Fill) | `General`+`GridControl1`, `LuongThoiViec`+`GridControl2`, `TroCapThoiViec`+`GridControl3`, `ThanhToanPhepNam`+`GridControl4`, `TruyThuPhepNam`+`GridControl5`, `TroCapConNho`+`GridControl6`, `QuyetToanPIT`+`GridControl7`, `Thuong3004_0105`+`GridControl8`, `Thuong0209`+`GridControl9`, `Thang13`+`GridControl10` | 10 tab, mỗi tab 1 `GridControl`/`GridView` riêng | Kết quả từng loại lương/phụ cấp/thưởng theo kỳ |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Khóa** (`btnKhoa`) | `btnKhoa_Click` → `Khoa_MoKhoa(1)` | Yêu cầu chọn ít nhất 1 dòng, xác nhận Yes/No, rồi `UPDATE smartbooks_salary SET trangthai=1 WHERE Employee_ID=... AND salary_month=... AND salary_year=... AND [Key]=...` (chạy SQL trực tiếp qua `kn.SaveData`, không qua stored procedure) cho từng dòng đang chọn, sau đó `HRFORMXem()` refresh |
| **Mở khóa** (`btnMoKhoa`) | `btnMoKhoa_Click` → `Khoa_MoKhoa(0)` | Tương tự Khóa nhưng set `trangthai=0` |
| **Cập nhật** (`btnCapNhat`, ẩn mặc định) | `btnCapNhat_Click` | Dự kiến cập nhật `PayDate` hàng loạt cho các dòng chọn qua `usp_InsertUpdateSmartBooks_Salary`; **có lỗi runtime** (xem Ghi chú kỹ thuật) |
| Checkbox **Công/Công DM/DIFF** | `CongGoc_CheckedChanged` / `CongDM_CheckedChanged` / `CongDiff_CheckedChanged` | Chọn 1 trong 3 nguồn tính công, lưu vào `Setup.Value` (0/1/2) theo `UserName` + `FunctionID='KH'` |
| Nút chuẩn `HRFORM` — **Xóa** | `BeforeDelete()` override | Duy nhất trong nhóm nút chuẩn được bật (`HRFORM_VisibleControl_Xoa = True` trên mọi tab); Thêm/Sửa/Lấy mẫu/Nhập-Xuất Excel đều bị tắt trên mọi tab |
| Nút chuẩn `HRFORM` — **Xem/Tải lại** (F5) | `HRFORMXem()` (kế thừa) | Vì không có `Search()` tự viết, form dùng cơ chế chuẩn của `HRFORM`: khi `HRFORM_QueryView` rỗng, tự tìm cấu hình trong bảng `Report` (`ReportFather = Me.Name`, `ControlNameAction = 'btnXem'`, có thể lọc thêm theo `TabKey` = tab đang chọn) để mở popup tham số `frmPara`, build câu truy vấn rồi `Xem(...)` đổ lên grid của tab đang active |
| Nút chuẩn `HRFORM` — **Lưu** | `BeforeSave()` override | Duyệt `Table.GetChanges()` (các dòng vừa sửa trực tiếp trên grid `General`) và gọi `usp_InsertUpdateSmartBooks_Salary` cho từng dòng thay đổi |

## Luồng xử lý chính

1. **`frmBatch_Load` (Handles MyBase.Load)** — tên hàm không khớp tên form (`frmBatch_Load` thay vì `para_Salary_Load`), dấu vết copy từ form mẫu khác. Gán `PayDate = Today`, `CongGoc.Checked = True`; dòng `LoadGiaoDienTheoDieuKien()` bị comment.

2. **`XtraTabControl1_SelectedPageChanged`** — mỗi lần đổi tab: reset toàn bộ `HRFORM_VisibleControl_GetTemplate/ImportExcel/Luu/Sua/ThemMoi/Xoa = False`, `HRFORM_GridControl`/`HRFORM_Gridview = Nothing`; sau đó theo `e.Page.Name` gán lại đúng cặp `GridControlN`/`GridViewN` tương ứng và bật `HRFORM_VisibleControl_Xoa = True`; gọi `HRFORM_XtraTabControl_SelectedTabChanged` (hàm nền chuẩn của `HRFORM`) rồi `LoadGiaoDienTheoDieuKien()`. Kết quả: mọi tab đều chỉ cho phép Xóa trong nhóm nút chuẩn, không tab nào cho Thêm/Sửa/Lưu-dạng-panel/Lấy mẫu/Import-Export Excel.

3. **`BeforeSave()` (override)** — chỉ thao tác trên `Table`/`GridView1` (tab General): kiểm tra quyền (`QuyenHRFORM = "View"` thì báo và dừng); lấy `Table.GetChanges()`, với mỗi dòng thay đổi build và gọi `usp_InsertUpdateSmartBooks_Salary` (tham số `PayDate`/`isPaid`/`Remark` xử lý `null` khi rỗng); nếu SP báo lỗi, hỏi tiếp tục hay dừng; kết thúc thông báo "Nhập thành công!".

4. **`BeforeDelete()` (override)** — kiểm tra quyền, xác nhận Yes/No, yêu cầu có dòng chọn; với mỗi dòng chọn trong `GridView1` gọi `usp_DeleteSmartBooks_Salary`; refresh lại `Xem(HRFORM_QueryView, ...)`; thông báo thành công.

5. **`Khoa_MoKhoa(trangthai)`** — khóa/mở khóa hàng loạt bằng UPDATE SQL trực tiếp trên `smartbooks_salary` (không qua stored procedure, không kiểm tra quyền `QuyenHRFORM`), rồi `HRFORMXem()` load lại.

6. **`Gridex1_KeyUp`** — định nghĩa gọi `Gridview_KeyUp` nhưng **không gắn `Handles`** với control nào (không có control tên `Gridex1` trong form) → dead code còn sót lại từ bản cũ.

7. Một khối lớn `UltraTabControl1_SelectedTabChanged` (tương đương logic mục 2) bị **comment toàn bộ** — dấu vết form từng dùng `Infragistics UltraWinTabControl` trước khi chuyển sang `DevExpress XtraTabControl`.

## Ghi chú kỹ thuật
- Đây là form **duy nhất trong 4 form được khảo sát không theo pattern "panel nhập liệu + Lưu trực tiếp"** hay "popup Thêm/Sửa" — mà là màn hình nhiều tab hiển thị/khóa/xóa kết quả tính lương, nạp dữ liệu qua cơ chế `Report`/`frmPara` chuẩn của `HRFORM` (không có `Search()` riêng).
- **Lỗi tiềm ẩn trong `btnCapNhat_Click`**: biến `gr As DataRow` được khai báo nhưng **không bao giờ được gán** bên trong vòng lặp `For numberRow ... Next` (thiếu dòng `gr = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow))` như trong `Khoa_MoKhoa`) → mọi truy cập `gr.Item(...)` sẽ ném `NullReferenceException` nếu tính năng này được kích hoạt. Do nút `btnCapNhat` và cả cụm control liên quan (`PayDate`, `cbXoaNgayThanhToan`...) đều `Visible = False` mặc định, tính năng này hiện **không tiếp cận được từ UI** — có thể là tính năng dở dang.
- `Khoa_MoKhoa` và `BeforeDelete` đều thao tác cứng trên `GridView1` (tab **General**) bất kể tab nào đang thực sự active — nếu người dùng chọn dòng trên grid của 1 tab khác (vd `TroCapThoiViec`/`GridView3`) rồi bấm Khóa/Xóa, hành vi có thể không như mong đợi vì code không đọc từ `HRFORM_Gridview` (tab hiện hành) mà đọc cố định `GridView1`.
- `Khoa_MoKhoa` cập nhật `trangthai` bằng câu `UPDATE` SQL trực tiếp (`kn.SaveData`), không qua stored procedure và không kiểm tra `QuyenHRFORM` trước khi thực hiện — khác các thao tác Lưu/Xóa khác trong form đều có kiểm tra quyền.
- `BeforeSave()` chỉ xử lý được thay đổi trên `GridView1`/tab General; do `HRFORM_VisibleControl_Luu` bị set `False` ở mọi tab trong `XtraTabControl1_SelectedPageChanged`, cần xác minh thêm liệu nút Lưu có thực sự khả dụng ở trạng thái tab mặc định khi form vừa mở hay không.
- Còn nhiều đoạn code bị comment (logic tab cũ dùng Infragistics, `AfterViewForm` định dạng số N2 theo `SmartBooks_Salary_Name`) — cho thấy form đã trải qua nhiều lần refactor/migration UI.
