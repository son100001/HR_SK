# frmChuyenViTri – Chuyển vị trí/phòng ban nhân viên

## Vị trí file
- `Froms/frmChuyenViTri.vb`, `frmChuyenViTri.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_Transfer` (`HRFORM_TableName`)
- `HRFORM_DeleteStore = "usp_DeleteHR_Transfer"`
- `HRFORM_MainFormName = "frmChuyenViTri"`
- Stored procedure nghiệp vụ chính: **`usp_HR_Transfer_Department`** (được gọi từ 2 nơi khác nhau – xem phần Ghi chú kỹ thuật)
- Stored procedure truy vấn danh sách: `sp_BangChuyenViTri`

## Mục đích
Ghi nhận việc **chuyển vị trí công tác** của nhân viên: vị trí (Position/Position_ID), loại chức vụ (PositionCategory_ID), chức danh (ChucDanh), job code (JobCode), kèm ngày hiệu lực và ghi chú. Form hiển thị song song giá trị **cũ** (disabled, tham khảo) và giá trị **mới** (nhập/chọn) cho từng loại thông tin.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` | LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `cbTypeOfView` | CheckBox | Đổi loại xem dữ liệu (tham số `3` khi tick, `1` khi không, truyền cho `sp_BangChuyenViTri`) |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `OldPosition` (disabled) / `Position` | LookUpEdit | Vị trí cũ / **Vị trí mới \*** (bắt buộc, đánh dấu `*` cứng trong code Load) |
| Nhập liệu (`pnDuLieuNhap`) | `OldJobCode` (disabled) / `JobCode` | LookUpEdit | Job code cũ / mới (từ `HR_JobCodeCategory`) |
| Nhập liệu (`pnDuLieuNhap`) | `OldChucDanh` (disabled) / `ChucDanh` | LookUpEdit | Chức danh cũ / mới (từ `HR_ChucDanh`) |
| Nhập liệu (`pnDuLieuNhap`) | `OldPositionCategory_ID` (disabled) / `PositionCategory_ID` | LookUpEdit | Loại chức vụ cũ / mới (từ `SmartBooks_PositionCategory`) |
| Nhập liệu (`pnDuLieuNhap`) | `OldPosition_ID` (disabled) / `Position_ID` | LookUpEdit | Chức vụ cũ / mới (từ `SmartBooks_Position`) |
| Nhập liệu (`pnDuLieuNhap`) | `EffectiveDate` | DateEdit | Ngày hiệu lực (mặc định = hôm nay khi Load) |
| Nhập liệu (`pnDuLieuNhap`) | `Remark` | RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu 1 bản ghi từ panel |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách các đợt chuyển vị trí; **có thể sửa trực tiếp trên grid** (dữ liệu đổi được đọc lại qua `Table.GetChanges()` trong `BeforeSave`) |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Nếu `QuyenHRFORM = "View"` thì báo không có quyền và thoát; kiểm tra bắt buộc `Employee_ID`, `EffectiveDate` qua `tvcn.CheckErrorProvider`; gọi hàm private `Save()` để **insert 1 dòng mới** qua `usp_HR_Transfer_Department`; focus lại `Employee_ID` |
| Nút Lưu chuẩn của `HRFORM` (trên `PanelButton`) | override `BeforeSave()` | Dùng khi người dùng **sửa trực tiếp trên grid** rồi bấm nút Lưu/Ctrl+S chuẩn của `HRFORM` — xử lý **hàng loạt** các dòng đã đổi (xem chi tiết bên dưới) |
| Các nút chuẩn `HRFORM` khác | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn popup Thêm/Sửa; nút Xóa dùng `usp_DeleteHR_Transfer` |

## Luồng xử lý

1. **`frmChuyenViTri_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2`.
   - `EffectiveDate.EditValue = Today`.
   - Nạp danh mục vị trí (`udf_Position`), job code, chức danh, loại chức vụ, vị trí (chức vụ) cho cả cặp control cũ/mới.
   - `tvcn.SearchEmployee(Employee_ID)`, `LoadGiaoDienTheoDieuKien()`.
   - Gán thêm dấu `*` thủ công vào `lblPosition.Text` ("Vị trí mới *").
   - Gọi `Search()`.

2. **`Search()`**
   - Build `exec [dbo].[sp_BangChuyenViTri] '1900-1-1','<today+100 ngày>',<3 hoặc 1>,'<Lan>',...,N'<EmID>'` — tham số loại (3/1) phụ thuộc `cbTypeOfView.Checked`.
   - `Xem(...)` đổ lên grid, lưu `HRFORM_QueryView`.

3. **`Save()` (private, gọi từ `btnSave_Click`)**
   - Thực thi `exec usp_HR_Transfer_Department N'<Employee_ID>','<EffectiveDate>',<Position>,<JobCode>,<ChucDanh>,<PositionCategory_ID>,<Position_ID>,<Remark>,N'<UserName>'`.
   - Nếu SP trả về thông báo lỗi (`ThongBao <> ""`) thì hiển thị lỗi và dừng; nếu thành công thì báo "Lưu thành công" và `Xem(HRFORM_QueryView, ...)` để refresh grid.

4. **`BeforeSave()` (override)** — chạy khi dùng nút Lưu **chuẩn** của `HRFORM` (áp dụng cho sửa trực tiếp trên grid, không phải nút `btnSave` tùy biến):
   - Nếu grid không có cột `ViTriMoi` hoặc `MaCongViecMoi` → dừng (`Return 1`).
   - Nếu `QuyenHRFORM = "View"` → báo không có quyền, dừng (`Return 1`).
   - Lấy `Table.GetChanges()`; nếu có thay đổi, hỏi xác nhận Yes/No.
   - Với **mỗi dòng đã đổi** có đủ `Employee_ID`, `EffectiveDate` và ít nhất 1 trong các cột mới (ViTriMoi/MaCongViecMoi/ChucDanhMoi/LoaiChucVuMoi/ChucVuMoi): gọi `exec usp_HR_Transfer_Department` cho dòng đó.
   - Nếu grid có cột `KiemTraDuLieuNhap` thì set thông báo lỗi ngay trên dòng đó (inline); nếu không có cột này thì hiện `MessageBox` lỗi riêng cho từng dòng.
   - Sau khi lặp hết, `Table.AcceptChanges()` và hiện 1 thông báo tổng kết (có lỗi hay không).
   - Luôn `Return 0`.

5. **`AfterViewForm()`** — **toàn bộ bị comment** (ghi chú "TẠM ĐÓNG ĐỂ VIEW DEVEXPRESS"), là code cũ thao tác trên `Janus.Windows.GridEX` (gắn dropdown ViTriMoi/MaCongViecMoi trên grid) chưa được chuyển đổi/dọn dẹp sang DevExpress Grid.

6. **`Employee_ID_EditValueChanged`** — toàn bộ thân hàm bị comment (kể cả logic tự động điền `Old*` theo nhân viên và gọi `Search()`) → hiện tại đổi nhân viên không tự động làm gì cả, các control `Old*` **không bao giờ được tự động điền** trong code hiện hành.

7. **`GridControl1_KeyUp`** → ủy quyền cho `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5).

## Ghi chú kỹ thuật
- **2 cơ chế lưu song song** hoạt động trên cùng 1 stored procedure `usp_HR_Transfer_Department`: (1) nút **Lưu** tùy biến (`btnSave`) nhập 1 dòng qua panel, gọi `Save()`; (2) sửa **trực tiếp trên grid** (nhiều dòng cùng lúc) rồi dùng nút Lưu/Ctrl+S **chuẩn** của `HRFORM`, kích hoạt `BeforeSave()` override để lặp qua từng dòng đã đổi và gọi SP tương ứng.
- Là form duy nhất trong 5 form khảo sát khai báo `HRFORM_MainFormName` tường minh và có checkbox `cbTypeOfView` để đổi loại xem dữ liệu.
- `AfterViewForm()` và phần tự động điền "vị trí cũ" khi đổi nhân viên (`Employee_ID_EditValueChanged`) đều là **dead code** (toàn bộ bị comment), sót lại từ bản Janus GridEX cũ, chưa dọn dẹp khi chuyển sang DevExpress.
- Không mở/gọi form phụ nào khác (không dùng `tvcn.AddNewOrEdit`/`HRFORM_InputForm`), không có constructor overload.
