# frmTheBHYT – Thẻ Bảo hiểm Y tế

## Vị trí file
- `BaoHiem/frmTheBHYT.vb`, `frmTheBHYT.Designer.vb`, `frmTheBHYT.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_TheBHYT` (`HRFORM_TableName = "HR_TheBHYT"`)

## Mục đích
Quản lý **Thẻ bảo hiểm y tế (BHYT)** của nhân viên: số thẻ, thời hạn sử dụng, nơi khám chữa bệnh ban đầu (bệnh viện), ngày trả thẻ khi hết hạn/nghỉ việc.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Label3` + `Employee_ID` | Label + LookUpEdit | Chọn mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblMaSoThe` + `MaSoThe` | Label + TextBox | Số thẻ BHYT |
| Nhập liệu (`pnDuLieuNhap`) | `lblfromdate` + `fromdate` | Label + DateEdit | Từ ngày (hiệu lực thẻ) – mặc định = hôm nay |
| Nhập liệu (`pnDuLieuNhap`) | `lbltodate` + `todate` | Label + DateEdit | Đến ngày (hết hạn thẻ) – mặc định = hôm nay |
| Nhập liệu (`pnDuLieuNhap`) | `lblMaBenhVien` + `MaBenhVien` | Label + LookUpEdit | Mã bệnh viện đăng ký khám ban đầu (đổ dữ liệu từ bảng `HR_Hospital`, hiển thị cột `NameVN`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblNgayTraThe` + `NgayTraThe` | Label + DateEdit | Ngày trả thẻ |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnNhap`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách thẻ BHYT đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc danh sách theo nhân viên đang chọn |
| **Lưu** (`btnSave`) | `btnSave_Click` | Kiểm tra bắt buộc nhập (`tvcn.CheckErrorProvider`) → nếu hợp lệ, gọi `tvcn.LuuHoacXoaTuForm("HR_TheBHYT", TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update thẻ BHYT → focus lại `Employee_ID` → gọi `Search()` refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → không dùng popup Thêm/Sửa, nhập trực tiếp trên panel như `frmInsurance` |

## Luồng xử lý

1. **`frmTheBHYT_Load`**
   - Đổ danh sách bệnh viện vào `MaBenhVien` (`select * from HR_Hospital`, hiển thị `NameVN`, giá trị `MaBenhVien`).
   - `fromdate` và `todate` mặc định = ngày hiện tại (`Today`).
   - Đánh dấu (*) trường bắt buộc, `LoadGiaoDienTheoDieuKien()`, nạp danh sách nhân viên cho LookUpEdit.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Build: `exec [dbo].[sp_ThongTinBaoHiem] 2,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
     (tham số `2` = loại dữ liệu Thẻ BHYT trên cùng stored procedure dùng chung với `frmInsurance`).
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Employee_ID_TextChanged` (bắt sự kiện `EditValueChanged`)** – **khác với `frmInsurance`**: khi đổi nhân viên đang chọn, form **tự động gọi `Search()`** ngay lập tức (không cần bấm nút Tìm).

4. **`Gridex1_KeyUp`** – ủy quyền phím tắt chuẩn cho `Gridview_KeyUp` (Ctrl+S/D/F/Q, F5).

## Ghi chú kỹ thuật
- Cùng dùng chung stored procedure `sp_ThongTinBaoHiem` với `frmInsurance`, chỉ khác tham số loại dữ liệu đầu tiên (1 = Sổ BHXH, 2 = Thẻ BHYT).
- Trường ngày (`fromdate`, `todate`, `NgayTraThe`) dùng `DevExpress.XtraEditors.DateEdit`, định dạng mask "d".
