# frmInsurance – Sổ Bảo hiểm xã hội

## Vị trí file
- `BaoHiem/frmInsurance.vb`, `frmInsurance.Designer.vb`, `frmInsurance.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_Insurance` (`HRFORM_TableName = "HR_Insurance"`)

## Mục đích
Quản lý **Sổ bảo hiểm xã hội (BHXH)** của từng nhân viên: mỗi nhân viên có 1 (hoặc nhiều) số sổ BHXH kèm ghi chú. Người dùng tìm nhân viên, xem/nhập số sổ, lưu lại.

## Bố cục giao diện
Form gồm 1 tab "General" chia làm 3 vùng ngang (`TableLayoutPanel2`) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblBookCode` + `BookCode` | Label + TextBox | Số sổ BHXH |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách sổ BHXH đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` đang chọn |
| **Lưu** (`btnSave`) | `btnSave_Click` | 1) Kiểm tra các trường bắt buộc (`NOT NULL`) trên `TableLayoutPanel2` bằng `tvcn.CheckErrorProvider`, nếu thiếu thì dừng và báo lỗi qua `ErrorProvider1`. 2) Gọi `tvcn.LuuHoacXoaTuForm("HR_Insurance", TableLayoutPanel2, True, QuyenHRFORM)` để **Insert/Update** trực tiếp bản ghi Sổ BHXH từ giá trị các control trên panel. 3) Focus lại vào ô `BookCode`. 4) Gọi lại `Search()` để refresh grid |
| Các nút chuẩn của `HRFORM` (Thêm/Sửa/Xóa/Xuất Excel...) | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn nút Thêm/Sửa dạng popup vì việc nhập được thực hiện trực tiếp trên panel; các nút Xóa/Xuất Excel/F5... vẫn hoạt động theo cơ chế chung của `HRFORM` |

## Luồng xử lý

1. **`frmInsurance_Load`**
   - Đánh dấu (*) các trường bắt buộc trên `TableLayoutPanel2` theo cấu trúc bảng `HR_Insurance` (`tvcn.ThemDauSaoChoTruongBuocNhap`).
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt các nút theo quyền người dùng (`QuyenHRFORM`).
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên cho LookUpEdit tìm kiếm.
   - Gọi `Search()` để hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - Build câu lệnh: `exec [dbo].[sp_ThongTinBaoHiem] 1,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
     (tham số đầu `1` = loại dữ liệu Sổ BHXH, phân biệt với `frmTheBHYT` dùng tham số `2` trên cùng stored procedure).
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` để đổ dữ liệu lên `GridControl1`.
   - Lưu lại `HRFORM_QueryView = QR` (dùng để F5 refresh).

3. **Gridex1_KeyUp** – ủy quyền toàn bộ phím tắt (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM`.

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng **không** tự động tìm kiếm khi đổi nhân viên (dòng `Search()` bị comment) → người dùng phải bấm nút **Tìm** để lọc lại.

## Ghi chú kỹ thuật
- Việc lưu dùng chung hàm `tvcn.LuuHoacXoaTuForm`, tự động Insert nếu bản ghi mới, Update nếu đã tồn tại (dựa theo khóa chính suy ra từ `TableLayoutPanel2` + `HR_Insurance`).
- Không có phân trang riêng; toàn bộ lọc dựa vào quyền xem dữ liệu theo cơ cấu tổ chức (`obj.PARA_...`) được set sẵn khi đăng nhập/chọn phòng ban.
