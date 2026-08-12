# frmEmpRegisParameter – Đăng ký tham số lương cho nhân viên

## Vị trí file
- `Payroll/frmEmpRegisParameter.vb`, `frmEmpRegisParameter.Designer.vb`, `frmEmpRegisParameter.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_EmpRegisParameter` (`HRFORM_TableName`)
- Stored procedure Lưu/Xóa: `usp_InsertUpdateHR_EmpRegisParameter` (`HRFORM_SaveStore`) / `usp_DeleteHR_EmpRegisParameter` (`HRFORM_DeleteStore`)
- Stored procedure Tìm kiếm: `sp_BangThamSoLuong`

## Mục đích
Khai báo **giá trị tham số lương theo từng khoảng thời gian (từ ngày – đến ngày)** cho từng nhân viên. Mỗi tham số (`Parameter`, lấy từ danh mục `HR_ParameterCategory`) có một **giá trị** (`ParameterValue`) áp dụng cho nhân viên đó trong khoảng `fromdate`–`todate`. Đây là cơ chế cấu hình tham số đầu vào dùng để tính lương (ví dụ hệ số, mức phụ cấp, loại hợp đồng phụ trợ... tùy dữ liệu khai báo trong `HR_ParameterCategory`) — bản thân form không cố định tên tham số, mà tra cứu động từ danh mục.

## Bố cục giao diện
Form có 1 tab "General", panel nhập chia 3 vùng (`TableLayoutPanel2`) phía trên + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblParameter` + `Parameter` | Label + LookUpEdit | Mã tham số (nạp từ `HR_ParameterCategory`, cột `parameter`/`Name<Lan>`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblParameterValue` + `ParameterValue` | Label + LookUpEdit | Giá trị của tham số đã chọn — danh sách giá trị nạp động từ `HR_Category where CategoryFather = <Parameter đang chọn>` |
| Nhập liệu (`pnDuLieuNhap`) | `lblfromdate` + `fromdate` | Label + DateEdit | Từ ngày áp dụng (mặc định = hôm nay) |
| Nhập liệu (`pnDuLieuNhap`) | `lbltodate` + `todate` | Label + DateEdit | Đến ngày áp dụng (mặc định = hôm nay) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách tham số đã đăng ký cho nhân viên |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc lại danh sách theo `Employee_ID`, `fromdate`, `todate`, `Parameter` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_EmpRegisParameter]", TableLayoutPanel2, ErrorProvider1)` — tự kiểm tra quyền, kiểm tra trường bắt buộc, Insert/Update; nếu thành công gọi lại `Search()`. Sau đó focus lại `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThucHien = False`, `HRFORM_VisibleControl_cbbReport = False` → chỉ còn Xóa/Xuất Excel/F5... hoạt động theo cơ chế chung; nhập liệu làm trực tiếp trên panel |

## Luồng xử lý

1. **`frmEmpRegisParameter_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2` (`tvcn.ThemDauSaoChoTruongBuocNhap`).
   - Nạp danh mục tham số cho combo `Parameter`: `select parameter as Code, Name<Lan> as Name from HR_ParameterCategory` → `tvcn.GetDataOnDropDownCategoryCodeName(Parameter, tabParameterCode)`.
   - (Đoạn `Parameter.SelectedIndex = 0` bị comment ra — không tự chọn sẵn tham số đầu tiên.)
   - `fromdate`/`todate` mặc định = hôm nay.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt nút theo quyền.
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên cho LookUpEdit.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - Build: `[dbo].[sp_BangThamSoLuong] '<fromdate>','<todate>','<Parameter>',1,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
   - `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView = QR`.
   - Lưu ý: `Parameter.EditValue` được nối thẳng vào chuỗi SQL **không có** dấu nháy đơn bao quanh trong đoạn `+ Parameter.EditValue + ','` (khác với các tham số string khác đều có `'...'`) — nếu `Parameter.EditValue` là `Nothing` (chưa chọn tham số) sẽ ném lỗi `NullReferenceException` khi build chuỗi, vì gọi `.ToString` ngầm định qua toán tử `+` trên object Nothing.

3. **`Public Overrides Sub AfterViewForm()`**
   - Sau khi `Xem()` đổ dữ liệu lên grid, nếu grid có cột `ParameterValue`, form tự tạo **dropdown động ngay trên ô grid** cho cột này: `select Category as Code, Name<Lan> as Name from HR_Category where CategoryFather = '<Parameter.EditValue>'` → `tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "ParameterValue", tabDropDown)`. Nhờ đó khi sửa trực tiếp trên grid, cột giá trị hiển thị đúng danh sách giá trị hợp lệ của tham số đang lọc.

4. **`Parameter_EditValueChanged`** – khi đổi tham số ở panel nhập liệu, nạp lại danh sách giá trị hợp lệ cho `ParameterValue`: `tvcn.GetDataOnDropDownCategoryCodeName(ParameterValue, Parameter.EditValue)` (dùng chính `Parameter.EditValue` làm điều kiện lọc `CategoryFather`, khác cách gọi ở `Load` truyền cả DataTable).

5. **`Employee_ID_EditValueChanged`** – khai báo nhưng **không** tự tìm kiếm khi đổi nhân viên (dòng `Search()` bị comment) → phải bấm nút **Tìm**.

6. **`GridControl1_KeyUp`** – ủy quyền phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý trong `HRFORM`.

7. Có sự kiện thừa/dư: `btnSearch_Click_1` — một sub trùng chức năng với `btnSearch_Click` (cũng gọi `Search()`) nhưng **không gắn `Handles`** nào cả, nên là code chết (dead code), không được gọi bởi runtime.

## Ghi chú kỹ thuật
- Việc lưu dùng `tvcn.SaveByStore` (khác với `frmInsurance` dùng `tvcn.LuuHoacXoaTuForm`) — gọi thẳng stored procedure `usp_InsertUpdateHR_EmpRegisParameter` thay vì build Insert/Update tự động theo cấu trúc bảng.
- Cột `ParameterValue` trên grid được gán dropdown động sau mỗi lần `Xem()` (`AfterViewForm`), phụ thuộc vào tham số đang được chọn ở panel lọc phía trên — nếu người dùng đổi `Parameter` nhưng chưa bấm **Tìm**, dropdown trên các dòng grid cũ vẫn theo tham số trước đó cho tới lần `Search()` kế tiếp.
- Có sub `btnSearch_Click_1` dư thừa không có `Handles`, khả năng là code cũ còn sót lại khi refactor.
- Nguy cơ lỗi runtime: build câu lệnh `Search()` sẽ ném `NullReferenceException` nếu `Parameter.EditValue` là `Nothing` (chưa chọn tham số nào) do thiếu kiểm tra `IsNothing` trước khi nối `Parameter.EditValue` vào chuỗi SQL (khác với xử lý `Employee_ID.EditValue` ngay phía trên có kiểm tra `IsNothing`).
