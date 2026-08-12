# frmCaiDatPhuCap – Cài đặt Phụ cấp

## Vị trí file
- `Payroll/frmCaiDatPhuCap.vb`, `frmCaiDatPhuCap.Designer.vb`, `frmCaiDatPhuCap.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_CaiDatPhuCap` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_CaiDatPhuCap"`
- `HRFORM_DeleteStore = "usp_DeleteHR_CaiDatPhuCap"`

## Mục đích
Khai báo **mức phụ cấp cố định theo Loại phụ cấp + Nhóm + Bậc** (ví dụ phụ cấp theo nhóm/bậc tay nghề, chức vụ...), gồm Loại phụ cấp (chọn từ danh mục thành phần lương `HR_SalaryComponentCategory`), Nhóm, Bậc (gõ tự do), khoảng thời gian hiệu lực, Số tiền và Ghi chú. Cấu trúc UI gần như song sinh với `frmBacTayNghe` (cùng bố cục panel, cùng kiểu control Nhóm/Bậc dạng TextBox) nhưng phục vụ nghiệp vụ **phụ cấp** thay vì **bậc tay nghề**, và có thêm dropdown "Loại PC" mà `frmBacTayNghe` không có.

## Bố cục giao diện
Form 1 tab "General", `TableLayoutPanel2` chia 2 vùng (nhập liệu + nút Lưu) + grid danh sách:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Nhập liệu (`pnDuLieuNhap`) | `lblLoaiPhuCap` + `LoaiPhuCap` | Label + LookUpEdit | Loại phụ cấp – nạp từ `select SalaryComponent as Code, Name<Lan> as Name, Insurance from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0 order by OrderBy` (chỉ lấy các thành phần lương **không** biến động theo tháng) |
| Nhập liệu (`pnDuLieuNhap`) | `lblNhom` + `Nhom` | Label + TextBox | Nhóm (gõ tự do) |
| Nhập liệu (`pnDuLieuNhap`) | `lblBac` + `Bac` | Label + TextBox | Bậc (gõ tự do) |
| Nhập liệu (`pnDuLieuNhap`) | `lblFromDate` + `FromDate` | Label + DateEdit | Từ ngày hiệu lực (mặc định = hôm nay khi Load) |
| Nhập liệu (`pnDuLieuNhap`) | `cbToDate` + `lblToDate` + `ToDate` | CheckBox + Label + DateEdit | Tick để bật nhập Đến ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lblAmount` + `Amount` | Label + TextBox | Số tiền phụ cấp – tự động format số khi gõ |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi từ panel |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách toàn bộ mức phụ cấp đã khai báo |

Không có vùng tìm kiếm (`pnSearch`).

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[" + HRFORM_SaveStore + "]", TableLayoutPanel2, ErrorProvider1)` – kiểm tra quyền, kiểm tra trường bắt buộc, hỏi xác nhận, build tham số từ toàn bộ control trên `TableLayoutPanel2` khớp cột bảng `HR_CaiDatPhuCap`, thực thi `usp_InsertUpdateHR_CaiDatPhuCap`. Thành công thì gọi lại `Search()`; sau đó luôn `LoaiPhuCap.Select()` để focus lại ô đầu tiên (khác `frmBacTayNghe` focus vào `Nhom`) |
| Nút Lưu chuẩn của `HRFORM` (trên `PanelButton`, Ctrl+S) | kế thừa (`btnLuu_Click`) | Do `HRFORM_VisibleControl_Luu` không bị ẩn (mặc định `True`), vẫn hoạt động song song cho trường hợp sửa trực tiếp trên grid – lấy `Table.GetChanges()` rồi gọi `tvcn.LuuTuDataTable(HRFORM_SaveStore, HRFORM_TableName, Table, QuyenHRFORM)` |
| Các nút chuẩn `HRFORM` khác | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn popup Thêm/Sửa; nút Xóa dùng `usp_DeleteHR_CaiDatPhuCap` |

## Luồng xử lý

1. **`frmCaiDatPhuCap_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)`.
   - Đọc `HR_SalaryComponentCategory` (lọc `isnull(MonthlyChanging,0)=0`, sắp theo `OrderBy`) và gán trực tiếp vào `LoaiPhuCap.Properties.DataSource/DisplayMember/ValueMember` (khác cách nạp dropdown gián tiếp qua `tvcn.GetDataOnDropDownCategoryCodeName` mà `frmBacTayNgheNhanVien` dùng – ở đây set thẳng `Properties` của `LookUpEdit`).
   - `FromDate.EditValue = Today`.
   - `LoadGiaoDienTheoDieuKien()`.
   - Gọi `Search()`.

2. **`Search()`**
   - Câu lệnh: `select * from ` + `HRFORM_TableName` (tức `select * from HR_CaiDatPhuCap`) – dùng biến `HRFORM_TableName` thay vì hardcode tên bảng như `frmBacTayNghe`.
   - **Không lọc** theo Loại PC/Nhóm/Bậc/FromDate/ToDate dù các control này tồn tại trên panel – toàn bộ danh mục luôn hiển thị hết (giống hệt hành vi của `frmBacTayNghe`).
   - `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)`; lưu `HRFORM_QueryView = QR`.

3. **`cbToDate_CheckedChanged`** – có `Handles cbToDate.CheckedChanged` đầy đủ (không bị thiếu như ở `frmBacTayNgheNhanVien`): tick thì set `ToDate.EditValue = Today` và bật `Enabled`; bỏ tick thì xóa giá trị và khóa lại.

4. **`Amount_TextChanged`** – gọi `tvcn.AmountFormat(Amount)` để tự động định dạng số.

5. **`Gridex1_KeyUp`** → ủy quyền cho `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5).

6. Không override `BeforeSave()`, `AfterSave()`, `AfterViewForm()`.

## Ghi chú kỹ thuật
- Cấu trúc code gần như **sao chép từ `frmBacTayNghe`** (cùng panel layout, cùng logic `cbToDate`/`Amount_TextChanged`/`Search()` không lọc điều kiện) nhưng có 2 khác biệt đáng chú ý:
  1. `btnSave_Click` ở đây dùng **`HRFORM_SaveStore` động** (`"[dbo].[" + HRFORM_SaveStore + "]"`) thay vì hardcode tên stored procedure như `frmBacTayNghe` – cách làm này an toàn hơn nếu sau này đổi `HRFORM_SaveStore` trong Designer.
  2. Có thêm dropdown `LoaiPhuCap` (Loại phụ cấp) liên kết tới danh mục `HR_SalaryComponentCategory`, còn `Nhom`/`Bac` vẫn chỉ là `TextBox` tự do giống `frmBacTayNghe` (không liên kết ràng buộc với bảng `HR_BacTayNghe`/`HR_BacTayNgheNhanVien` ở tầng UI, dù nghiệp vụ có thể liên quan).
  3. `LoaiPhuCap` chỉ hiển thị các thành phần lương có `MonthlyChanging = 0` (mức phụ cấp cố định, không biến động theo tháng) – phù hợp với bản chất "cài đặt" (setup) một lần chứ không phải nhập biến động hàng tháng.
- Có 2 cơ chế lưu song song (nút `btnSave` tùy biến cho nhập 1 dòng qua panel; nút Lưu/Ctrl+S chuẩn của `HRFORM` cho sửa hàng loạt trên grid) như đã ghi nhận ở `frmBacTayNghe`/`frmChuyenViTri`; không có override `BeforeSave()` riêng để xử lý validate cho trường hợp sửa nhiều dòng trên grid.
- Không có mối liên hệ trực tiếp (khóa ngoại/truy vấn chéo) với `frmBacTayNghe`/`frmBacTayNgheNhanVien` trong code – dù cùng có khái niệm "Nhóm"/"Bậc", 3 form này quản lý 3 bảng độc lập (`HR_CaiDatPhuCap`, `HR_BacTayNghe`, `HR_BacTayNgheNhanVien`) không tham chiếu lẫn nhau ở tầng ứng dụng.
