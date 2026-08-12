# frmBaoCaoBaoHiem – Báo tăng/giảm Bảo hiểm

## Vị trí file
- `BaoHiem/frmBaoCaoBaoHiem.vb`, `frmBaoCaoBaoHiem.Designer.vb`, `frmBaoCaoBaoHiem.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_IncreaseDecreaseInsurance` (`HRFORM_TableName`)
- Stored procedure Lưu: `usp_InsertUpdateHR_IncreaseDecreaseInsurance` (`HRFORM_SaveStore`)
- Stored procedure Xóa: `usp_DeleteHR_IncreaseDecreaseInsurance` (`HRFORM_DeleteStore`)

## Mục đích
Khai báo các đợt **báo tăng** hoặc **báo giảm** bảo hiểm cho nhân viên (ví dụ: tăng khi ký HĐLĐ chính thức, giảm khi nghỉ việc/nghỉ không lương...), cùng mức lương đóng bảo hiểm áp dụng cho từng đợt khai báo.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblMonth` + `Month_` | Label + control `Month` | Tháng khai báo |
| Nhập liệu (`pnDuLieuNhap`) | `lblYear` + `Year_` | Label + control `Year` | Năm khai báo |
| Nhập liệu (`pnDuLieuNhap`) | `lblPhuongAn` + `PhuongAn` | Label + LookUpEdit (category `PhuongAnTangGiam`) | Phương án tăng/giảm (vd: Tăng mới, Giảm nghỉ việc...) |
| Nhập liệu (`pnDuLieuNhap`) | `lblLoaiKhaiBao` + `LoaiKhaiBao` | Label + LookUpEdit (category `LoaiTangGiam`) | Loại khai báo tăng/giảm |
| Nhập liệu (`pnDuLieuNhap`) | `lblNgayTangGiam` + `NgayTangGiam` | Label + DateEdit | Ngày báo tăng/giảm |
| Nhập liệu (`pnDuLieuNhap`) | `lblInsuranceSalary` + `InsuranceSalary` | Label + TextBox | Lương đóng bảo hiểm (được format số qua `tvcn.AmountFormat`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Ẩn | `InsertSource` | TextBox (Visible=False, mặc định "NhapTay") | Đánh dấu nguồn gốc bản ghi = nhập tay (phân biệt với dữ liệu sinh tự động/import) |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách các đợt báo tăng/giảm đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc lại danh sách theo nhân viên |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "usp_InsertUpdateHR_IncreaseDecreaseInsurance", XtraTabControl1, ErrorProvider1)` – kiểm tra hợp lệ + lưu toàn bộ giá trị control trong `XtraTabControl1` xuống DB qua stored procedure; nếu thành công thì gọi lại `Xem(HRFORM_QueryView, ...)` để refresh grid, sau đó focus lại `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel, không dùng popup Thêm/Sửa; nút Xóa dùng `usp_DeleteHR_IncreaseDecreaseInsurance` |

## Luồng xử lý

1. **`frmBaoCaoBaoHiem_Load`**
   - Nạp danh mục `PhuongAn` (category `PhuongAnTangGiam`) và `LoaiKhaiBao` (category `LoaiTangGiam`) qua `tvcn.GetDataOnDropDownCategoryCodeName`.
   - Đánh dấu (*) trường bắt buộc trên toàn bộ `XtraTabControl1`.
   - `LoadGiaoDienTheoDieuKien()`, nạp danh sách nhân viên cho LookUpEdit.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Build: `exec [dbo].[sp_BangBaoHiem] null,null,2,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)** – sau khi load grid xong, với 2 cột `PHUONGAN` và `LOAIKHAIBAO` trên grid, tự động gắn **dropdown chọn nhanh ngay trên ô grid** (`tvcn.TaoDropDowTrenGrid`) lấy dữ liệu từ `udf_GetCategory('PhuongAnTangGiam', ...)` và `udf_GetCategory('LoaiTangGiam', ...)` — cho phép sửa nhanh 2 cột này trực tiếp trên grid mà không cần mở lại panel nhập liệu.

4. **`InsuranceSalary_TextChanged`** – định dạng số tiền khi gõ (`tvcn.AmountFormat`). *Lưu ý*: sự kiện này được khai báo nhưng **không gắn `Handles InsuranceSalary.TextChanged`**, nên trên thực tế không tự kích hoạt khi người dùng gõ (có thể là điểm cần rà soát/known issue).

5. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng `Search()` bị comment, tương tự `frmInsurance`: đổi nhân viên không tự tìm kiếm lại, phải bấm **Tìm**.

## Ghi chú kỹ thuật
- Là form duy nhất trong module dùng `tvcn.SaveByStore` (lưu theo toàn bộ control trong `XtraTabControl1`) thay vì `tvcn.LuuHoacXoaTuForm` (lưu theo `TableLayoutPanel`) như các form còn lại — phù hợp với nghiệp vụ có nhiều loại danh mục con (Phương án, Loại khai báo) cần xử lý cùng lúc.
- Trường `InsertSource` ẩn cho thấy hệ thống có phân biệt dữ liệu **nhập tay tại form này** với dữ liệu **được sinh tự động** từ nghiệp vụ khác (vd: tự động tạo báo giảm khi xử lý nghỉ việc ở `frmTerminationAsignment`).
