# frmBacTayNgheNhanVien – Gán Bậc tay nghề cho nhân viên

## Vị trí file
- `Payroll/frmBacTayNgheNhanVien.vb`, `frmBacTayNgheNhanVien.Designer.vb`, `frmBacTayNgheNhanVien.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_BacTayNgheNhanVien` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_BacTayNgheNhanVien"`
- `HRFORM_DeleteStore = "usp_DeleteHR_BacTayNgheNhanVien"`
- Stored procedure truy vấn danh sách: `sp_BangTayNgheNhanVien`
- `Imports WindowsControlLibrary` – khai báo import riêng (không thấy ở 3 form còn lại khảo sát cùng đợt)

## Mục đích
Gán/khai báo **bậc tay nghề cụ thể cho từng nhân viên** (Nhóm tay nghề + Bậc + khoảng thời gian hiệu lực + Số tiền + Ghi chú), dựa trên danh mục Nhóm/Bậc đã khai báo ở `frmBacTayNghe`. Người dùng tìm theo mã nhân viên, xem lịch sử các lần gán, nhập bản ghi mới.

## Bố cục giao diện
Form 1 tab "General", `TableLayoutPanel2` chia 3 vùng ngang (tìm kiếm, nhập liệu, nút Lưu) + grid danh sách:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblNhom` + `Nhom` | Label + LookUpEdit | Nhóm tay nghề – nạp từ `select distinct Nhom as Code, Nhom as Name from HR_BacTayNghe` |
| Nhập liệu (`pnDuLieuNhap`) | `lblBac` + `SalaryStep` | Label + LookUpEdit | Bậc tay nghề – control tên `SalaryStep` nhưng nhãn hiển thị là "Bậc tay nghề", nạp từ `select distinct Bac as Code, Bac as Name from HR_BacTayNghe` |
| Nhập liệu (`pnDuLieuNhap`) | `lblFromDate` + `FromDate` | Label + DateEdit | Từ ngày (mặc định = hôm nay khi Load) |
| Nhập liệu (`pnDuLieuNhap`) | `cbToDate` + `lblToDate` + `ToDate` | CheckBox + Label + DateEdit | Đến ngày (tick để bật – **xem Ghi chú kỹ thuật: sự kiện không được wire**) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Nút Lưu tùy biến – **hiện không làm gì** (xem Ghi chú kỹ thuật) |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Lịch sử các lần gán bậc tay nghề của nhân viên |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | **Thân hàm rỗng** – bấm nút không thực hiện bất kỳ thao tác nào (không lưu, không kiểm tra lỗi, không refresh). Đây là lỗi/còn dang dở, vì `HRFORM_SaveStore = "usp_InsertUpdateHR_BacTayNgheNhanVien"` đã được khai báo trong Designer nhưng không hề được gọi ở đâu trong `.vb` |
| Nút Lưu chuẩn của `HRFORM` (trên `PanelButton`, Ctrl+S) | kế thừa (`btnLuu_Click`) | Do `HRFORM_VisibleControl_Luu` không bị ẩn (mặc định `True`), đây là cách **duy nhất thực sự lưu được dữ liệu**: sửa/thêm trực tiếp trên grid rồi bấm nút Lưu chuẩn hoặc Ctrl+S → lấy `Table.GetChanges()` → `tvcn.LuuTuDataTable(HRFORM_SaveStore, HRFORM_TableName, Table, QuyenHRFORM)` gọi `usp_InsertUpdateHR_BacTayNgheNhanVien` |
| Các nút chuẩn `HRFORM` khác | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn popup Thêm/Sửa; nút Xóa dùng `usp_DeleteHR_BacTayNgheNhanVien` |

## Luồng xử lý

1. **`frmBacTayNgheNhanVien_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)`.
   - `FromDate.EditValue = Today`.
   - Đọc 2 `DataTable` phân biệt (distinct) `Nhom` và `Bac` từ bảng `HR_BacTayNghe`, nạp vào 2 LookUpEdit `Nhom` và `SalaryStep` qua `tvcn.GetDataOnDropDownCategoryCodeName`.
   - `LoadGiaoDienTheoDieuKien()`.
   - Gọi `Search()`.

2. **`Search()`**
   - Build: `[dbo].[sp_BangTayNgheNhanVien] null,null,1,'<Lan>',NULL,NULL,NULL,NULL,NULL,NULL,N'<Employee_ID.Text>'`
     – 2 tham số đầu (`null,null`) tương ứng vị trí ngày (không truyền `FromDate`/`ToDate` dù có control trên UI); các `NULL` giữa là tham số phân quyền cơ cấu tổ chức (Factory/Dept/Section/Team/Position/PositionCategory) đều bỏ trống; tham số cuối là `Employee_ID`.
   - Lấy giá trị lọc bằng `Employee_ID.Text.Trim` (không dùng `.EditValue` như các form khác dùng `LookUpEdit` để lọc nhân viên, ví dụ `frmInsurance`/`frmChuyenViTri`).
   - `Xem(...)` đổ lên grid; lưu `HRFORM_QueryView`.

3. **`Employee_ID_KeyUp`** – có xử lý F3 (mở `para_NhanVien` để chọn nhanh nhân viên, gán `Employee_ID.Text`) và Ctrl+S (gọi `btnSave_Click` nếu `btnSave.Enabled`), nhưng **khai báo không có `Handles Employee_ID.KeyUp`** và cũng không có `AddHandler` ở đâu khác → **hàm này chết, không bao giờ được gọi**. F3 và Ctrl+S từ ô mã nhân viên không hoạt động trên thực tế.

4. **`cbToDate_CheckedChanged`** – có logic bật/tắt `ToDate.Enabled` nhưng **không có `Handles cbToDate.CheckedChanged`** → cũng là hàm chết, tick checkbox không có tác dụng gì (khác với `frmBacTayNghe`, nơi cùng tên hàm này có khai báo `Handles` đầy đủ và hoạt động đúng).

5. **`Employee_ID_EditValueChanged`** – có `Handles Employee_ID.EditValueChanged` nhưng toàn bộ thân hàm chỉ có 1 dòng comment `'Search()` → đổi nhân viên không tự động tìm kiếm, phải bấm nút **Tìm**.

6. **`Gridex1_KeyUp`** → ủy quyền cho `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5) – đây là đường Ctrl+S thực sự hoạt động (khi focus ở grid), khác với Ctrl+S gõ từ `Employee_ID` (mục 3, bị chết).

7. Không override `BeforeSave()`, `AfterSave()`, `AfterViewForm()`.

## Ghi chú kỹ thuật
- **Quan hệ với `frmBacTayNghe`**: đây là form "chi tiết áp dụng cho nhân viên", còn `frmBacTayNghe` là "danh mục gốc". Toàn bộ 2 dropdown `Nhom` và `SalaryStep` (Bậc) trong form này được nạp trực tiếp bằng `distinct` từ bảng `HR_BacTayNghe` mà `frmBacTayNghe` quản lý – nếu `frmBacTayNghe` chưa có dữ liệu, 2 dropdown này sẽ rỗng.
- **Nút "Lưu" tùy biến (`btnSave`) không hoạt động** – thân hàm `btnSave_Click` rỗng hoàn toàn, mặc dù `HRFORM_SaveStore` đã trỏ đúng stored procedure `usp_InsertUpdateHR_BacTayNgheNhanVien`. Đây là điểm khác biệt lớn nhất so với `frmBacTayNghe`/`frmCaiDatPhuCap` (2 form có cấu trúc UI gần như giống hệt nhưng `btnSave_Click` của chúng gọi `tvcn.SaveByStore(...)` đầy đủ). Nhiều khả năng đây là code dở dang/bug: chức năng nhập 1 dòng trực tiếp qua panel (Nhóm/Bậc/Từ ngày/Đến ngày/Ghi chú) hiện **không lưu được** bằng nút Lưu trên panel; người dùng chỉ có thể lưu được dữ liệu mới bằng cách sửa/thêm dòng ngay trên grid rồi dùng nút Lưu chuẩn/Ctrl+S của `HRFORM` (cơ chế `Table.GetChanges()`).
- **2 sự kiện bị khai báo thiếu `Handles`** (không phải bị comment, mà là chưa gắn sự kiện): `Employee_ID_KeyUp` (mất luôn cả tính năng F3 mở popup chọn nhân viên và Ctrl+S nhanh) và `cbToDate_CheckedChanged` (checkbox "Đến ngày" không bật/tắt được ô `ToDate`). Cả 2 đều là dead code do thiếu dây nối sự kiện, khác với kiểu dead code "bị comment" thấy ở `frmChuyenViTri`.
- `Search()` dùng `Employee_ID.Text.Trim` thay vì `Employee_ID.EditValue` để lọc – cần kiểm tra kỹ khi `LookUpEdit` có `ValueMember`/`DisplayMember` khác nhau vì có thể gửi sai giá trị lọc xuống SP nếu Text hiển thị khác với mã nhân viên thực.
- Không có phân trang; lọc theo Employee_ID; các tham số ngày và tổ chức đều truyền `NULL` cố định trong `Search()`.
