# frmTrainingRecord – Hồ sơ đào tạo

## Vị trí file
- `Froms/frmTrainingRecord.vb`, `frmTrainingRecord.Designer.vb`, `frmTrainingRecord.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_TrainingRecord` (`HRFORM_TableName = "HR_TrainingRecord"`)

## Mục đích
Quản lý **hồ sơ đào tạo** của nhân viên: loại huấn luyện, thời gian (từ ngày – đến ngày), nội dung, bên đào tạo, chi phí. Người dùng tìm nhân viên, xem/nhập thông tin khóa đào tạo trên panel, lưu lại; danh sách các lần đào tạo hiển thị dưới dạng grid.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblTrainingType` + `TrainingType` | Label + LookUpEdit | Kiểu huấn luyện (đổ dữ liệu từ `HR_Category`, `CategoryFather='TrainingType'`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblGroup` + `Group` | Label + TextBox | Group |
| Nhập liệu (`pnDuLieuNhap`) | `lblTrainingSubject` + `TrainingSubject` | Label + TextBox | Nội dung |
| Nhập liệu (`pnDuLieuNhap`) | `lblTrainingCost` + `TrainingCost` | Label + TextBox | Phí đào tạo |
| Nhập liệu (`pnDuLieuNhap`) | `lblfromdate` + `fromdate` | Label + DateEdit | Từ ngày – mặc định = hôm nay khi Load |
| Nhập liệu (`pnDuLieuNhap`) | `lbltodate` + `todate` + `cbtodate` | Label + DateEdit + CheckBox | Đến ngày – chỉ **Enabled** và có giá trị khi tick checkbox `cbtodate`; bỏ tick thì `todate` bị vô hiệu hóa và xóa giá trị |
| Nhập liệu (`pnDuLieuNhap`) | `lblTrainingHour` + `TrainingHour` | Label + TextBox | Thời gian huấn luyện |
| Nhập liệu (`pnDuLieuNhap`) | `lblTrainer` + `Trainer` | Label + TextBox | Bên đào tạo |
| Nhập liệu (`pnDuLieuNhap`) | `lblTrainingRecordNo` + `TrainingRecordNo` | Label + TextBox | Khóa đào tạo (mã hồ sơ) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách hồ sơ đào tạo đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` đang nhập |
| **Lưu** (`btnSave`) | `btnSave_Click` | 1) Kiểm tra bắt buộc nhập trên `TableLayoutPanel2` bằng `tvcn.CheckErrorProvider`, nếu thiếu thì dừng và báo lỗi qua `ErrorProvider1`. 2) Gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update trực tiếp bản ghi từ giá trị các control trên panel. 3) Focus lại vào `Employee_ID`. 4) Gọi lại `Search()` để refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn nút Thêm/Sửa dạng popup vì nhập trực tiếp trên panel; các nút Xóa/Xuất Excel/F5... vẫn theo cơ chế chung của `HRFORM` |

## Luồng xử lý

1. **`frmTrainingRecord_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) các trường bắt buộc theo cấu trúc bảng `HR_TrainingRecord`.
   - `fromdate.EditValue = Today` – mặc định ngày bắt đầu là hôm nay.
   - `tvcn.GetDataOnDropDownCategoryCodeName(TrainingType, "TrainingType")` – nạp danh mục "Kiểu huấn luyện" từ `HR_Category`.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - Gọi `Search()` để hiển thị dữ liệu ban đầu.
   - **Không** gọi `tvcn.SearchEmployee(Employee_ID)` để nạp danh sách nhân viên cho LookUpEdit tìm kiếm (khác với `frmLicense`).

2. **`Search()`**
   - Build câu lệnh: `[dbo].[sp_BangTrainingRecord] '1900-1-1','<Today+10 năm>',1,'<Lan>',N'<UserName>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>',N'<PositionCategory>',N'<EmployeeID>'`
     (2 tham số ngày đầu là khoảng lọc từ 1900-01-01 đến 10 năm sau ngày hiện tại — coi như không giới hạn thời gian; tham số `1` cố định, không phân biệt loại dữ liệu như ở `sp_ThongTinBaoHiem`).
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ dữ liệu lên `GridControl1`.
   - Lưu lại `HRFORM_QueryView = QR` (dùng khi F5 refresh).

3. **`AfterViewForm()`** (override)
   - Nếu grid có cột `TypeOfTransfer` (điều kiện kiểm tra, có thể là tên cột cũ/tàn dư khi copy code từ form khác) thì gắn dropdown cho cột **`TrainingType`** trên grid, dữ liệu lấy từ `HR_Category where CategoryFather='TrainingType'` qua `tvcn.TaoDropDowTrenGrid`. **Lưu ý:** điều kiện kiểm tra cột `TypeOfTransfer` không khớp với cột được gắn dropdown là `TrainingType` — nhiều khả năng là sai sót copy-paste từ form khác nên trên thực tế nhánh gắn dropdown gần như không bao giờ chạy (trừ khi grid vô tình có cả 2 cột).

4. **`cbtodate_CheckedChanged`** – khi tick `cbtodate`: `todate.Enabled = True` và gán `todate.EditValue = Today`; khi bỏ tick: `todate.Enabled = False` và xóa giá trị (`Nothing`).

5. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng gọi `Search()` bị **comment**, nên đổi nhân viên không tự động tìm kiếm; phải bấm nút **Tìm**.

6. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM`.

## Ghi chú kỹ thuật
- Việc lưu dùng chung hàm `tvcn.LuuHoacXoaTuForm`, tự động Insert nếu bản ghi mới, Update nếu đã tồn tại.
- Khoảng lọc ngày trong `Search()` cố định `'1900-1-1'` đến `Today + 10 năm` — thực chất là lấy toàn bộ dữ liệu không phân biệt khoảng thời gian, khác với cơ chế lọc theo `fromdate/todate` nhập trên panel (2 trường này chỉ dùng khi **nhập/lưu** bản ghi mới, không dùng để lọc tìm kiếm).
- `todate` chỉ nhận giá trị khi checkbox `cbtodate` được tick — nếu không tick, trường "Đến ngày" coi như chưa xác định (đào tạo chưa kết thúc/không có ngày kết thúc).
- So với nhóm form cùng pattern (`frmLicense`, `frmHealthCheck`, `frmDiseasesRecord`, `frmSurgeryHistory`): đây là form duy nhất có thêm cơ chế bật/tắt trường ngày kết thúc bằng checkbox (`cbtodate`), và là 1 trong 3 form (cùng `frmDiseasesRecord`, `frmSurgeryHistory`) có `AfterViewForm()` gắn dropdown trên cột grid cho danh mục phân loại.
