# frmDisable – Khai báo tình trạng khuyết tật/tàn tật của nhân viên

## Vị trí file
- `Froms/frmDisable.vb`, `frmDisable.Designer.vb`, `frmDisable.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_Disable` (`HRFORM_TableName`)
- **Không** gán `HRFORM_SaveStore`/`HRFORM_DeleteStore` trong Designer (form không dùng cơ chế `SaveByStore` mà dùng `LuuHoacXoaTuForm` – xem phần Luồng xử lý)

## Mục đích
Tên form (`frmDisable`) không tự giải thích nghĩa, nhưng qua code xác định rõ đây là màn hình **khai báo tình trạng khuyết tật/tàn tật (mất sức lao động) của nhân viên** theo từng giai đoạn: loại tàn tật, khoảng thời gian hiệu lực, lý do, phần trăm suy giảm khả năng lao động, trạng thái duyệt và ghi chú. Dữ liệu này phục vụ chế độ/chính sách dành cho nhân viên khuyết tật (ví dụ miễn trừ một số nghĩa vụ, chế độ bảo hiểm/phúc lợi đặc biệt). Stored procedure truy vấn chính tên là `sp_BangTanTat` ("Bảng Tàn tật") – xác nhận đây không phải nghiệp vụ "vô hiệu hóa" gì khác mà đúng là quản lý tình trạng tàn tật.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblLoaiTanTat` + `TypeOfDisable` | Label + LookUpEdit | Loại tàn tật (danh mục `"DisableStatus"`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblReason` + `Reason` | Label + RichTextBox | Lý do |
| Nhập liệu (`pnDuLieuNhap`) | `lblPhanTram` + `PhanTram` | Label + NumericUpDown | Phần trăm (mất sức lao động), 1 số thập phân, tối đa 1000 |
| Nhập liệu (`pnDuLieuNhap`) | `lblfromdate` + `FromDate` | Label + DateEdit | Từ ngày (mặc định = hôm nay khi mở form) |
| Nhập liệu (`pnDuLieuNhap`) | `lbltodate` + `ToDate` | Label + DateEdit | Đến ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lblApproval` + `Approval` | Label + CheckBox | Duyệt |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnNhap`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách khai báo tàn tật theo tháng đang xem |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc lại danh sách |
| **Lưu** (`btnSave`) | `btnSave_Click` | 1) Kiểm tra trường bắt buộc bằng `tvcn.CheckErrorProvider(TableLayoutPanel2, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName))`, nếu thiếu thì dừng lại. 2) Gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update trực tiếp bản ghi từ giá trị control trên panel. 3) Focus lại `Employee_ID`. 4) Gọi lại `Search()` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel, không dùng popup Thêm/Sửa |

## Luồng xử lý

1. **`frmDisable_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc theo cấu trúc bảng `HR_Disable`.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên.
   - `FromDate.EditValue = Today`.
   - `tvcn.GetDataOnDropDownCategoryCodeName(TypeOfDisable, "DisableStatus")` – nạp danh mục loại tàn tật.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - **Đặc biệt**: khoảng lọc dữ liệu hiển thị trên grid **không dùng trực tiếp `FromDate`/`ToDate` nhập trên panel** mà tự tính lại theo **tháng chứa `FromDate`**: `fd = ngày 1 của tháng(FromDate)`, `td = ngày cuối tháng đó` (`fd.AddMonths(1).AddDays(-1)`). Nghĩa là control `ToDate` trên panel chỉ dùng khi **nhập** dữ liệu (đến ngày hiệu lực), không ảnh hưởng đến việc **lọc xem** danh sách – việc xem luôn giới hạn trong phạm vi 1 tháng theo `FromDate`.
   - Build: `exec [dbo].[sp_BangTanTat] '<fd>','<td>','<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'` (đầy đủ tham số phân quyền theo cơ cấu tổ chức từ `obj.PARA_...`).
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng `Search()` bị comment, không tự tìm khi đổi nhân viên.

4. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp`.

## Ghi chú kỹ thuật
- Đây là form thuộc kiểu (a) nhưng dùng `tvcn.LuuHoacXoaTuForm` thay vì `tvcn.SaveByStore` (giống `frmInsurance` ở module BaoHiem) – phù hợp với việc Designer **không gán** `HRFORM_SaveStore`/`HRFORM_DeleteStore`, để hệ thống tự suy luận Insert/Update/khóa chính từ cấu trúc bảng `HR_Disable`.
- Việc lọc dữ liệu hiển thị theo **tháng của `FromDate`** (bất kể `ToDate` nhập là gì) là điểm khác biệt cần lưu ý khi bảo trì hoặc mở rộng: nếu người dùng khai báo một giai đoạn tàn tật kéo dài nhiều tháng, khi xem lại theo tháng khác (không trùng tháng `FromDate`) sẽ **không thấy** bản ghi đó trên grid trừ khi đổi `FromDate` sang tháng tương ứng rồi bấm Tìm.
- `PhanTram` giới hạn tối đa 1000 (không phải 100) trong `NumericUpDown.Maximum` – có thể là dư thừa từ control mẫu dùng chung, cần tự kiểm tra hợp lý khi nhập (không có validate riêng ≤ 100% trong code).
- `Approval` (Duyệt) chỉ là checkbox lưu cờ, không thấy logic khóa sửa/ẩn nút theo trạng thái đã duyệt trong code hiện tại.
