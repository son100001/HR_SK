# frmBacTayNghe – Danh mục Bậc tay nghề

## Vị trí file
- `Payroll/frmBacTayNghe.vb`, `frmBacTayNghe.Designer.vb`, `frmBacTayNghe.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_BacTayNghe` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_BacTayNghe"`
- `HRFORM_DeleteStore = "usp_DeleteHR_BacTayNghe"`

## Mục đích
Khai báo **danh mục Bậc tay nghề** dùng chung cho toàn công ty: mỗi dòng gồm Nhóm tay nghề, Bậc, khoảng thời gian hiệu lực (Từ ngày/Đến ngày), Số tiền (phụ cấp/đơn giá theo bậc) và Ghi chú. Đây là bảng danh mục gốc – được `frmBacTayNgheNhanVien` (gán bậc tay nghề cho từng nhân viên) sử dụng làm nguồn dữ liệu cho 2 dropdown "Nhóm" và "Bậc" (xem phần Ghi chú kỹ thuật).

## Bố cục giao diện
Form 1 tab "General", có `TableLayoutPanel2` chia 2 vùng (nhập liệu + nút Lưu) và 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Nhập liệu (`pnDuLieuNhap`) | `Nhom` | TextBox | Nhóm tay nghề (gõ tự do, không phải dropdown) |
| Nhập liệu (`pnDuLieuNhap`) | `Bac` | TextBox | Bậc tay nghề (gõ tự do) |
| Nhập liệu (`pnDuLieuNhap`) | `lblFromDate` + `FromDate` | Label + DateEdit | Từ ngày hiệu lực (mặc định = hôm nay khi Load) |
| Nhập liệu (`pnDuLieuNhap`) | `cbToDate` + `lblToDate` + `ToDate` | CheckBox + Label + DateEdit | Tick để bật nhập "Đến ngày" (mặc định `ToDate` bị `Enabled = False`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblAmount` + `Amount` | Label + TextBox | Số tiền – tự động format số khi gõ (`Amount_TextChanged`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi từ panel |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách toàn bộ bậc tay nghề đã khai báo |

Không có vùng tìm kiếm (`pnSearch`) – form luôn hiển thị toàn bộ danh mục.

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_BacTayNghe]", TableLayoutPanel2, ErrorProvider1)` – tự kiểm tra quyền, kiểm tra trường bắt buộc (`NOT NULL`), hỏi xác nhận, build tham số từ toàn bộ control trên `TableLayoutPanel2` khớp tên cột bảng `HR_BacTayNghe`, thực thi stored procedure. Nếu thành công thì gọi lại `Search()`; sau đó luôn `Nhom.Select()` để focus lại ô đầu tiên |
| Nút Lưu chuẩn của `HRFORM` (trên `PanelButton`, Ctrl+S) | kế thừa (`btnLuu_Click` trong `HRFORM`) | Vì `HRFORM_VisibleControl_Luu` **không** bị set `False` (mặc định `True`) nên nút Lưu/Ctrl+S chuẩn vẫn hoạt động song song: nếu sửa trực tiếp trên grid rồi bấm, sẽ lấy `Table.GetChanges()` và gọi `tvcn.LuuTuDataTable(HRFORM_SaveStore, HRFORM_TableName, Table, QuyenHRFORM)` để lưu hàng loạt các dòng đã đổi – tương tự cơ chế 2 đường lưu song song đã thấy ở `frmChuyenViTri` |
| Các nút chuẩn `HRFORM` khác | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn popup Thêm/Sửa; nút Xóa dùng `usp_DeleteHR_BacTayNghe` |

## Luồng xử lý

1. **`frmBacTayNghe_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) các trường bắt buộc theo cấu trúc bảng `HR_BacTayNghe`.
   - `FromDate.EditValue = Today`.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt nút theo quyền.
   - Gọi `Search()`.

2. **`Search()`**
   - Câu lệnh cố định: `select * from HR_BacTayNghe` – **không lọc theo Nhóm/Bậc/FromDate/ToDate** dù các control này tồn tại trên panel; toàn bộ danh mục luôn được hiển thị hết.
   - `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ lên `GridControl1`; lưu `HRFORM_QueryView = QR`.

3. **`cbToDate_CheckedChanged`** – tick thì `ToDate.EditValue = Today` và bật `Enabled`; bỏ tick thì xóa giá trị và khóa lại control.

4. **`Amount_TextChanged`** – gọi `tvcn.AmountFormat(Amount)` để tự động định dạng số khi gõ.

5. **`Gridex1_KeyUp`** → ủy quyền cho `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5).

6. Không override `BeforeSave()`, `AfterSave()`, `AfterViewForm()` – dùng nguyên hành vi mặc định của `HRFORM`.

## Ghi chú kỹ thuật
- **Quan hệ với `frmBacTayNgheNhanVien`**: bảng `HR_BacTayNghe` do form này quản lý là **nguồn danh mục** để `frmBacTayNgheNhanVien` nạp 2 dropdown "Nhóm tay nghề" và "Bậc tay nghề" khi gán cho từng nhân viên (`select distinct Nhom ... from HR_BacTayNghe`, `select distinct Bac ... from HR_BacTayNghe`) – nghĩa là 2 cột `Nhom`/`Bac` ở đây thực chất đang đóng vai trò "danh mục cha" dù bản thân chúng chỉ là `TextBox` tự do (không kiểm soát trùng lặp/chính tả ở tầng UI).
- Form không có vùng tìm kiếm, không lọc theo ngày hiệu lực dù có đầy đủ `FromDate`/`cbToDate`/`ToDate` trên UI – các trường này chỉ được dùng làm **dữ liệu nhập của từng dòng** (khoảng hiệu lực của mức tiền), không phải điều kiện lọc danh sách.
- Có 2 cơ chế lưu cùng tồn tại (nút `btnSave` tùy biến gọi `SaveByStore` cho 1 dòng nhập trên panel; nút Lưu/Ctrl+S chuẩn của `HRFORM` cho sửa hàng loạt trực tiếp trên grid) vì `HRFORM_SaveStore` được khai báo và `HRFORM_VisibleControl_Luu` không bị ẩn – giống mô hình đã ghi nhận ở `frmChuyenViTri`, nhưng ở đây **không có** override `BeforeSave()` để validate/xử lý riêng cho trường hợp sửa nhiều dòng trên grid, nên hành vi lưu hàng loạt hoàn toàn phụ thuộc cơ chế mặc định của `HRFORM.btnLuu_Click`.
- `btnSave_Click` hardcode tên stored procedure `"[dbo].[usp_InsertUpdateHR_BacTayNghe]"` thay vì dùng biến `HRFORM_SaveStore` (khác với `frmCaiDatPhuCap` – xem file tương ứng – dùng `HRFORM_SaveStore` động); giá trị trùng nhau nên không gây lỗi nhưng nếu sau này đổi `HRFORM_SaveStore` trong Designer thì `btnSave` sẽ không đồng bộ theo.
