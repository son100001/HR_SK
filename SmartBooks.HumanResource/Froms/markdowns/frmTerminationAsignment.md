# frmTerminationAsignment – Nghỉ việc

## Vị trí file
- `Froms/frmTerminationAsignment.vb`, `frmTerminationAsignment.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_TerminationAsignment` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_TerminationAsignment"`
- `HRFORM_VisibleControl_GetTemplate = False` (ẩn nút "Lấy mẫu" import Excel)
- Không khai báo `HRFORM_DeleteStore` — việc xóa được xử lý hoàn toàn thủ công qua override `BeforeDelete()` (xem bên dưới)

## Mục đích
Ghi nhận **quyết định thôi việc/nghỉ việc** của nhân viên: lý do nghỉ, ngày dự định nghỉ, ngày nộp đơn, tháng tính lương liên quan, trạng thái quyết định, mã quyết định, ghi chú.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu (`pnDuLieuNhap`) | `ResonTerminated` | LookUpEdit | Lý do (danh mục `resigned`) |
| Nhập liệu (`pnDuLieuNhap`) | `DecisionStatus` | LookUpEdit | Trạng thái (danh mục `DecisionStatus`, mặc định `"Approved"` khi Load) |
| Nhập liệu (`pnDuLieuNhap`) | `PlanTernimationDate` | DateEdit | Ngày dự định nghỉ |
| Nhập liệu (`pnDuLieuNhap`) | `NgayNopDon` | DateEdit | Ngày nộp đơn |
| Nhập liệu (`pnDuLieuNhap`) | `Remark` | RichTextBox | Ghi chú |
| Ẩn (`Visible=False`) | `ThangTinhLuong` (+ label) | DateEdit (mask `MM/yyyy`) | Tháng tính lương — ẩn khỏi panel nhưng vẫn hiển thị dưới dạng cột trên grid kết quả (định dạng riêng trong `AfterViewForm`) |
| Ẩn (`Visible=False`) | `DecisionCode` | TextBox | Mã quyết định — ẩn hoàn toàn, không có label tương ứng |
| Lưu (`pnNhap`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách quyết định thôi việc |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_TerminationAsignment]", TableLayoutPanel2, ErrorProvider1)`; nếu thành công gọi lại `Search()`; focus `Employee_ID` |
| Nút **Xóa** chuẩn của `HRFORM` | override `BeforeDelete()` | Xử lý xóa **thủ công theo khóa ghép**, khác cơ chế mặc định (xem chi tiết bên dưới) |
| Các nút chuẩn `HRFORM` khác | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` |

## Luồng xử lý

1. **`frmTerminationAsignment_Load`**
   - Đánh dấu (*) trường bắt buộc.
   - Nạp `ResonTerminated` (danh mục `resigned`), `DecisionStatus` (danh mục `DecisionStatus`).
   - `LoadGiaoDienTheoDieuKien()`, gán `DecisionStatus.EditValue = "Approved"` mặc định.
   - `tvcn.SearchEmployee(Employee_ID)`, gọi `Search()`.

2. **`Search()`**
   - Build `[dbo].[sp_BangQuyetDinhThoiViec] '1900-1-1','<today+1 tháng>',1,'<Lan>',...,'',N'<EmID>'`.
   - **Lưu ý bất thường**: chuỗi này **không có từ khóa `exec`** ở đầu (khác toàn bộ các form còn lại luôn dùng `exec [dbo].[...]`), và có thêm **1 tham số rỗng `''`** chèn ngay trước `Employee_ID` so với pattern chuẩn 8 tham số của các form khác.
   - `Xem(...)`, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)**
   - Gắn dropdown chọn nhanh trên grid cho cột `ResonTerminated` (danh mục `resigned`) và `DecisionStatus` (danh mục `DecisionStatus`) qua `tvcn.TaoDropDowTrenGrid`.
   - Nếu grid có cột `ThangTinhLuong`: set `DisplayFormat` = `MM/yyyy` (vì trường này bị ẩn trên panel nhập nhưng vẫn hiển thị trên grid).

4. **`BeforeDelete()` (override)** — **form duy nhất trong 5 form khảo sát override hàm này**:
   - Nếu không có dòng nào được chọn trên grid → cảnh báo "Bạn vui lòng chọn dòng cần xóa".
   - Nếu có, hỏi xác nhận Yes/No.
   - Nếu Yes: **lặp qua từng dòng đang chọn** (`GridView1.GetSelectedRows`), với mỗi dòng gọi `kn.SaveData("exec usp_DeleteHR_TerminationAsignment 'Employee_ID','PlanTernimationDate'")` — xóa theo **khóa ghép** `Employee_ID` + `PlanTernimationDate` (không phải khóa đơn `ID` như phần lớn bảng khác); nếu bất kỳ dòng nào lỗi thì đặt cờ thất bại.
   - Sau khi xử lý xong tất cả dòng đã chọn, hiển thị **1 thông báo tổng kết duy nhất** (không báo riêng từng dòng lỗi).
   - Gọi `Xem(HRFORM_QueryView, ...)` để load lại grid; luôn `Return 0`.

5. **`Employee_ID_EditValueChanged` / `Employee_ID_EditValueChanged_1`** — **có 2 hàm trùng chức năng**: 1 hàm không gắn `Handles`, thân rỗng/comment, **không được gọi ở đâu cả** (dead code thừa); hàm còn lại (`_1`) mới thực sự gắn `Handles Employee_ID.EditValueChanged` nhưng thân cũng chỉ chứa dòng `Search()` bị comment → đổi nhân viên không tự động tìm kiếm.

6. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn).

## Ghi chú kỹ thuật
- Là form **duy nhất** trong 5 form khảo sát override `BeforeDelete()` — thực hiện xóa **multi-select thủ công** theo khóa ghép `Employee_ID + PlanTernimationDate` qua SP `usp_DeleteHR_TerminationAsignment`, thay vì dùng cơ chế `HRFORM_DeleteStore` chuẩn (vì bảng `HR_TerminationAsignment` không có khóa chính đơn phù hợp với cơ chế xóa mặc định của `HRFORM`).
- Trường `ThangTinhLuong` (Tháng tính lương) và `DecisionCode` (Mã quyết định) bị ẩn khỏi panel nhập liệu nhưng `ThangTinhLuong` vẫn hiển thị trên cột grid kết quả với định dạng `MM/yyyy` được set riêng trong `AfterViewForm`.
- Có **2 hàm `Employee_ID_EditValueChanged` trùng lặp**, 1 hàm dư thừa không gắn `Handles` và không được gọi ở đâu — dead code còn sót lại (có thể do đổi tên sự kiện qua Designer).
- Câu lệnh trong `Search()` **không có từ khóa `exec`** ở đầu chuỗi và có thêm 1 tham số rỗng `''` chèn trước `Employee_ID`, không nhất quán với toàn bộ các form khác trong hệ thống — cần rà soát khi bảo trì (không rõ có phải lỗi tiềm ẩn hay `Xem()`/`kn.ReadData` tự xử lý được cả 2 dạng chuỗi).
- **Khác với suy đoán ban đầu**: form này **không có** constructor overload (không mở được kèm tham số Employee_ID/ngày có sẵn từ form khác) và **không** gọi `usp_HR_Transfer_Department` — đây là điểm khác biệt so với `frmChuyenViTri`. Sự phức tạp đặc trưng của form nằm ở cơ chế xóa theo khóa ghép (`BeforeDelete`), không phải ở logic lưu.
- Không override `BeforeSave`; không mở form phụ nào khác.
