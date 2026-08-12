# frmHeavyAndToxic – Nặng nhọc/Độc hại (khai báo giai đoạn hưởng chế độ)

## Vị trí file
- `Froms/frmHeavyAndToxic.vb`, `frmHeavyAndToxic.Designer.vb`, `frmHeavyAndToxic.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_TransferFloatType` (`HRFORM_TableName`)
- Stored procedure Lưu: `usp_InsertUpdateHR_TransferFloatType` (`HRFORM_SaveStore`)
- Stored procedure Xóa: `usp_DeleteHR_TransferFloatType` (`HRFORM_DeleteStore`)

## Mục đích
Khai báo **giai đoạn (Từ ngày – Đến ngày)** nhân viên thuộc diện **nặng nhọc/độc hại** (tên form gợi ý nghiệp vụ), lưu kèm ghi chú. Đây là một biến thể tái sử dụng cấu trúc bảng dùng chung `HR_TransferFloatType` (bảng lưu "giá trị dạng số + khoảng thời gian hiệu lực" cho nhiều nghiệp vụ khác nhau trong hệ thống), nên ngoài cặp control ngày tháng và ghi chú, panel còn chứa 2 control ẩn (`HAZARD`, `VL`) là tàn dư của thiết kế gốc.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `Factory_ID`, `departmentcode`, `sectioncode`, `ChucDanh` | TextBox (disabled) | Nhà máy/Bộ phận/Phòng ban/Chức danh của nhân viên đang chọn – tự động nạp khi Tìm, chỉ để xem, không nhập |
| Nhập liệu (`pnDuLieuNhap`) | `StartedDate` | DateEdit (disabled) | Ngày vào công ty của nhân viên – tự động nạp, chỉ để xem |
| Nhập liệu (`pnDuLieuNhap`) | `lblFromdate` + `Fromdate` | Label + DateEdit | Từ ngày (mặc định = hôm nay khi mở form) |
| Nhập liệu (`pnDuLieuNhap`) | `lblTodate` + `Todate` | Label + DateEdit | Đến ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Nhập liệu (`pnDuLieuNhap`) | `HAZARD` (LookUpEdit, `Visible = False`), `lblHAZARD` (ẩn) | – | Danh mục loại độc hại (`HR_HazardCategory`) – được nạp dữ liệu ở `Load` nhưng **bị ẩn trên giao diện**, không thao tác được |
| Nhập liệu (`pnDuLieuNhap`) | `VL` (NumericUpDown, `Visible = False`), `lblPhamTram` (ẩn) | – | "Phần trăm" – control còn sót lại từ form gốc, không hiển thị |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách giai đoạn đã khai báo, có cột `TypeOfTransfer`, `PositionName`,... |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_TransferFloatType]", XtraTabControl1, ErrorProvider1)` – lấy giá trị từ **toàn bộ `XtraTabControl1`** (bao gồm cả các control ẩn `HAZARD`/`VL`), Insert/Update; nếu thành công thì `Xem(HRFORM_QueryView, ...)` để refresh grid; sau đó focus lại `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel, không dùng popup Thêm/Sửa |

## Luồng xử lý

1. **Load** – tên hàm xử lý là `frmChuyenChucVu_Load` (gán `Handles MyBase.Load`) – dấu vết cho thấy form được sao chép từ một form "Chuyển chức vụ" khác rồi chỉnh sửa lại, tên hàm không được đổi theo:
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc.
   - Đọc danh sách `Position_ID` (không dùng ngay) và danh mục `HR_HazardCategory` (`tabHazard`) rồi `tvcn.GetDataOnDropDownCategoryCodeName(HAZARD, tabHazard)` nạp cho control `HAZARD` (dù control này đang ẩn).
   - `Fromdate.EditValue = Today`.
   - `tvcn.SearchEmployee(Employee_ID)` nạp danh sách nhân viên.
   - `LoadGiaoDienTheoDieuKien()` bật/tắt control theo quyền.

2. **`Search()`**
   - Đọc thông tin nhân viên hiện tại qua `udf_EmployeeFilter_Full('VN',null,null,null,null,null,null,'<EmployeeID>','<Fromdate>')` để đổ vào các ô chỉ-xem (Factory/Dept/Section/ChucDanh/StartedDate).
   - Build câu lệnh chính: `exec [dbo].[sp_BangChuyenGiaTriFloat] '1900-1-1','<Today+100 ngày>',1,'<Lan>',NULL,NULL,NULL,NULL,NULL,NULL,N'<EmployeeID>'` – **khác với các form khác trong cùng thư mục**: 6 tham số phân quyền theo cơ cấu tổ chức (Factory/Dept/Section/Team/Position/PositionCategory) đều truyền `NULL` cố định thay vì `obj.PARA_...`, chỉ lọc theo `Employee_ID`.
   - `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)`, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)** – sau khi hiển thị dữ liệu lên grid: cột `TypeOfTransfer` bị khóa không cho sửa trực tiếp trên grid (`AllowEdit = False`), cột `PositionName` bị ẩn.

4. **`XtraTabControl1_SelectedPageChanged`** – gọi `HRFORM_XtraTabControl_SelectedTabChanged`, `LoadGiaoDienTheoDieuKien()` và `Search()` mỗi khi đổi tab (form hiện chỉ có 1 tab "General" nên chủ yếu chuẩn bị cho mở rộng sau này).

5. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng `Search()` bị comment, không tự tìm khi đổi nhân viên.

6. **`GridEX2_KeyUp`** (gắn cho `GridControl1.KeyUp`) – ủy quyền phím tắt chuẩn cho `Gridview_KeyUp`.

7. **`Employee_ID_KeyUp`** (không có `Handles`, không được gắn sự kiện trong code hiện tại) – nội dung xử lý F3 mở `para_NhanVien` để chọn nhanh nhân viên, nhưng **không thấy `Handles Employee_ID.KeyUp`** nên đoạn này hiện không được thực thi (khả năng là code còn sót lại/lỗi thiếu Handles).

## Ghi chú kỹ thuật
- Bảng `HR_TransferFloatType` và các stored procedure liên quan (`usp_InsertUpdateHR_TransferFloatType`, `usp_DeleteHR_TransferFloatType`, `sp_BangChuyenGiaTriFloat`) mang tên chung chung "TransferFloatType" – đây là hạ tầng dùng chung, form này chỉ khai thác các cột: nhân viên, từ ngày, đến ngày, ghi chú (và có thể `HAZARD`/`VL` dù đang ẩn trên giao diện).
- 2 control `HAZARD` và `VL` được nạp dữ liệu/khởi tạo nhưng `Visible = False` trong Designer → cần lưu ý khi bảo trì: nếu sau này cần hiển thị lại phân loại độc hại cụ thể hoặc phần trăm phụ cấp, hạ tầng UI đã có sẵn, chỉ cần bật `Visible = True`.
- Câu lệnh `Search()` không lọc theo cơ cấu tổ chức (Factory/Dept/Section/Team/Position/PositionCategory) như các form khác cùng module – tất cả nhân viên (theo Employee_ID) đều hiển thị bất kể phân quyền cơ cấu tổ chức của người dùng.
- Tên hàm xử lý sự kiện Load (`frmChuyenChucVu_Load`) không khớp tên class (`frmHeavyAndToxic`) – bằng chứng code được copy từ form khác.
