# frmHealthCheck – Khám sức khỏe

## Vị trí file
- `Froms/frmHealthCheck.vb`, `frmHealthCheck.Designer.vb`, `frmHealthCheck.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_HealthCheck` (`HRFORM_TableName = "HR_HealthCheck"`)

## Mục đích
Quản lý **hồ sơ khám sức khỏe định kỳ** của nhân viên: ngày khám, bệnh viện khám, chi phí khám. Người dùng tìm nhân viên, xem/nhập trực tiếp trên panel, lưu lại; danh sách các lần khám hiển thị trên grid. Đây là form đơn giản nhất trong nhóm, không có danh mục phân loại (LookUpEdit) và không override `AfterViewForm`.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblHealthCheckDate` + `HealthCheckDate` | Label + DateEdit | Ngày khám – mặc định = hôm nay khi Load |
| Nhập liệu (`pnDuLieuNhap`) | `lblHospitalName` + `HospitalName` | Label + TextBox | Bệnh viện |
| Nhập liệu (`pnDuLieuNhap`) | `lblHealthCheckingFee` + `HealthCheckingFee` | Label + TextBox | Phí khám bệnh |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` (Dock=Fill trong `pnLuu`) | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách lần khám sức khỏe đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` đang nhập |
| **Lưu** (`btnSave`) | `btnSave_Click` | Kiểm tra bắt buộc nhập (`tvcn.CheckErrorProvider`) → nếu hợp lệ, gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update → focus lại `Employee_ID` → gọi `Search()` refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → không dùng popup Thêm/Sửa, nhập trực tiếp trên panel |

## Luồng xử lý

1. **`frmHealthCheck_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc theo cấu trúc bảng `HR_HealthCheck`.
   - `HealthCheckDate.EditValue = Today` – mặc định ngày khám là hôm nay.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.
   - Không gọi `tvcn.GetDataOnDropDownCategoryCodeName` (không có trường danh mục nào cần nạp) và không gọi `tvcn.SearchEmployee`.

2. **`Search()`**
   - Build: `[dbo].[sp_BangHealthCheck] '1900-1-1','<Today+1 năm>',1,'<Lan>',N'<UserName>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>',N'<PositionCategory>',N'<EmployeeID>'`
     (khoảng lọc ngày từ 1900-01-01 đến **hôm nay + 1 năm** — hẹp hơn `frmTrainingRecord` (+10 năm) nhưng vẫn coi như lấy gần hết dữ liệu quá khứ và một phần gần tương lai).
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ dữ liệu lên `GridControl1`.
   - Lưu lại `HRFORM_QueryView = QR` (dùng khi F5 refresh).

3. Form **không** override `AfterViewForm()` — không có cột danh mục nào trên grid cần gắn dropdown.

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng gọi `Search()` bị **comment**, đổi nhân viên không tự động lọc lại; phải bấm nút **Tìm**.

5. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM`.

## Ghi chú kỹ thuật
- Việc lưu dùng chung hàm `tvcn.LuuHoacXoaTuForm`, tự động Insert nếu bản ghi mới, Update nếu đã tồn tại.
- Là form đơn giản nhất trong nhóm 5 form: không có `LookUpEdit` danh mục, không override `AfterViewForm`, không có control phụ trợ (checkbox bật/tắt ngày như `frmTrainingRecord`, checkbox chế độ tìm như `frmDiseasesRecord`).
- `HealthCheckingFee` là TextBox nhập tự do (không có định dạng số/kiểm tra kiểu dữ liệu ở tầng UI), việc kiểm tra kiểu dữ liệu phụ thuộc vào ràng buộc cột trong bảng `HR_HealthCheck` khi lưu qua `tvcn.LuuHoacXoaTuForm`.
