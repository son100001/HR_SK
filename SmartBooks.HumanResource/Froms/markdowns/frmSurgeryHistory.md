# frmSurgeryHistory – Lịch sử phẫu thuật

## Vị trí file
- `Froms/frmSurgeryHistory.vb`, `frmSurgeryHistory.Designer.vb`, `frmSurgeryHistory.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_SurgeryHistory` (`HRFORM_TableName = "HR_SurgeryHistory"`)

## Mục đích
Quản lý **lịch sử phẫu thuật** của nhân viên: lý do phẫu thuật, ngày phẫu thuật, hiệu quả sau phẫu thuật. Người dùng tìm nhân viên, xem/nhập trực tiếp trên panel, lưu lại; danh sách các lần phẫu thuật hiển thị trên grid.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblSurgeryReason` + `SurgeryReason` | Label + LookUpEdit | Lý do phẫu thuật (đổ dữ liệu từ `HR_Category`, `CategoryFather='SurgeryReason'`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblSurgeryDate` + `SurgeryDate` | Label + DateEdit | Ngày phẫu thuật – mặc định = hôm nay khi Load |
| Nhập liệu (`pnDuLieuNhap`) | `lblPostSurgeryEffects` + `PostSurgeryEffects` | Label + LookUpEdit | Hiệu quả phẫu thuật (đổ dữ liệu từ `HR_Category`, `CategoryFather='Effects'`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách lần phẫu thuật đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` đang nhập |
| **Lưu** (`btnSave`) | `btnSave_Click` | Kiểm tra bắt buộc nhập (`tvcn.CheckErrorProvider`) → nếu hợp lệ, gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update → focus lại `Employee_ID` → gọi `Search()` refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → không dùng popup Thêm/Sửa, nhập trực tiếp trên panel |

## Luồng xử lý

1. **`frmSurgeryHistory_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - `tvcn.GetDataOnDropDownCategoryCodeName(SurgeryReason, "SurgeryReason")` – nạp danh mục "Lý do phẫu thuật".
   - `tvcn.GetDataOnDropDownCategoryCodeName(PostSurgeryEffects, "Effects")` – nạp danh mục "Hiệu quả phẫu thuật".
   - `SurgeryDate.EditValue = Today` – mặc định ngày phẫu thuật là hôm nay.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Build: `exec [dbo].[sp_BangSurgeryHistory] '1900-1-1','<Today>',1,'<Lan>',N'<UserName>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
     (khoảng lọc ngày cố định từ 1900-01-01 đến **hôm nay**, tham số chế độ cố định `1`).
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ dữ liệu lên `GridControl1`.
   - Lưu lại `HRFORM_QueryView = QR` (dùng khi F5 refresh).

3. **`AfterViewForm()`** (override) – gắn **2 dropdown** trên grid (nhiều nhất trong nhóm 5 form):
   - Nếu grid có cột `SurgeryReason`: gắn dropdown từ `HR_Category where CategoryFather='SurgeryReason'`.
   - Nếu grid có cột `PostSurgeryEffects`: gắn dropdown từ `HR_Category where CategoryFather='Effects'`.
   - Cả hai đều dùng `tvcn.TaoDropDowTrenGrid`, tên hiển thị chọn theo `obj.Lan` qua `IIf(...)` (`NameVN`/`NameEN`/`NameKR`).

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng gọi `Search()` bị **comment**, đổi nhân viên không tự động lọc lại; phải bấm nút **Tìm**.

5. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM`.

## Ghi chú kỹ thuật
- Việc lưu dùng chung hàm `tvcn.LuuHoacXoaTuForm`, tự động Insert nếu bản ghi mới, Update nếu đã tồn tại.
- Là form duy nhất trong nhóm có **2 trường LookUpEdit danh mục riêng biệt** (`SurgeryReason` và `PostSurgeryEffects`) đều được nạp dữ liệu qua `tvcn.GetDataOnDropDownCategoryCodeName` lúc Load, và cả hai đều được gắn dropdown tương ứng trên grid trong `AfterViewForm()` — nhiều nhất trong nhóm 5 form (các form khác chỉ có tối đa 1 cột danh mục).
- Cấu trúc code gần giống `frmDiseasesRecord`/`frmTrainingRecord` (cùng mẫu `Search()` + `AfterViewForm()` gắn dropdown), nhưng không có control phụ trợ nào khác (không có checkbox như `cbFind` của `frmDiseasesRecord` hay `cbtodate` của `frmTrainingRecord`).
- Designer có gán đầy đủ `Me.HRFORM_GridControl = Me.GridControl1` và `Me.HRFORM_Gridview = Me.GridView1` (khác với `frmDiseasesRecord` bị thiếu 2 dòng này).
