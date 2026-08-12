# frmDiseasesRecord – Bệnh lý

## Vị trí file
- `Froms/frmDiseasesRecord.vb`, `frmDiseasesRecord.Designer.vb`, `frmDiseasesRecord.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_DiseasesRecord` (`HRFORM_TableName = "HR_DiseasesRecord"`)

## Mục đích
Quản lý **hồ sơ bệnh lý** của nhân viên: loại bệnh, ngày khám bệnh, chi tiết bệnh trạng. Người dùng tìm nhân viên, xem/nhập trực tiếp trên panel, lưu lại; danh sách các bản ghi bệnh lý hiển thị trên grid.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `cbFind` | CheckBox (không có nhãn text trong Designer) | Chuyển đổi tham số thứ 3 truyền vào stored procedure tìm kiếm giữa `1` (tick) và `2` (không tick) — ý nghĩa nghiệp vụ cụ thể của 2 chế độ này do `sp_BangDiseasesRecord` quyết định, không thể hiện trên giao diện |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblTypeOfDiseases` + `TypeOfDiseases` | Label + LookUpEdit | Loại bệnh (đổ dữ liệu từ `HR_Category`, `CategoryFather='TypeOfDiseases'`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblMedicalExaminationDay` + `MedicalExaminationDay` | Label + DateEdit | Ngày khám bệnh – mặc định = hôm nay khi Load |
| Nhập liệu (`pnDuLieuNhap`) | `lblDetailOfDiseases` + `DetailOfDiseases` | Label + RichTextBox | Chi tiết loại bệnh |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` (Dock=Fill trong `pnLuu`) | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách bản ghi bệnh lý đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` và trạng thái checkbox `cbFind` đang chọn |
| **Lưu** (`btnSave`) | `btnSave_Click` | Kiểm tra bắt buộc nhập (`tvcn.CheckErrorProvider`) → nếu hợp lệ, gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update → focus lại `Employee_ID` → gọi `Search()` refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → không dùng popup Thêm/Sửa, nhập trực tiếp trên panel |

## Luồng xử lý

1. **`frmDiseasesRecord_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - `tvcn.GetDataOnDropDownCategoryCodeName(TypeOfDiseases, "TypeOfDiseases")` – nạp danh mục "Loại bệnh".
   - `MedicalExaminationDay.EditValue = Today` – mặc định ngày khám là hôm nay.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Build: `exec [dbo].[sp_BangDiseasesRecord] '1900-1-1','<Today>',<1|2>,'<Lan>',N'<UserName>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
     trong đó tham số chế độ (`1` hoặc `2`) lấy từ `cbFind.Checked` (`True` → `1`, `False` → `2`); khoảng lọc ngày cố định từ 1900-01-01 đến **hôm nay**.
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ dữ liệu lên `GridControl1`.
   - Lưu lại `HRFORM_QueryView = QR` (dùng khi F5 refresh).

3. **`AfterViewForm()`** (override)
   - Nếu grid có cột `TypeOfDiseases` thì gắn dropdown cho cột này, dữ liệu lấy từ `HR_Category where CategoryFather='TypeOfDiseases'` (tên hiển thị chọn theo `obj.Lan` qua `IIf(...)` — `NameVN`/`NameEN`/`NameKR`) qua `tvcn.TaoDropDowTrenGrid`.

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng gọi `Search()` bị **comment**, đổi nhân viên không tự động lọc lại; phải bấm nút **Tìm**.

5. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM`.

## Ghi chú kỹ thuật
- Việc lưu dùng chung hàm `tvcn.LuuHoacXoaTuForm`, tự động Insert nếu bản ghi mới, Update nếu đã tồn tại.
- **Điểm khác biệt kỹ thuật đáng chú ý:** trong `frmDiseasesRecord.Designer.vb`, phần `InitializeComponent` **không** có 2 dòng gán `Me.HRFORM_GridControl = Me.GridControl1` và `Me.HRFORM_Gridview = Me.GridView1` (khác với `frmTrainingRecord`, `frmLicense`, `frmHealthCheck`, `frmSurgeryHistory` đều có gán rõ ràng). `Search()` và `AfterViewForm()` của form này vẫn tham chiếu `HRFORM_GridControl`/`HRFORM_Gridview`, nên hành vi phụ thuộc vào giá trị mặc định các thuộc tính này được set ở nơi khác (constructor `HRFORM` hoặc thiết kế lại chưa được đồng bộ) — cần kiểm tra khi bảo trì để tránh lỗi null reference.
- `cbFind` không có nhãn (Label) đi kèm trên giao diện — người dùng cuối không thấy rõ tác dụng của checkbox này; cần xác nhận thêm với nghiệp vụ/stored procedure `sp_BangDiseasesRecord` nếu muốn bổ sung chú thích.
- Là 1 trong 3 form của nhóm (cùng `frmTrainingRecord`, `frmSurgeryHistory`) có `AfterViewForm()` gắn dropdown trên cột grid theo danh mục.
