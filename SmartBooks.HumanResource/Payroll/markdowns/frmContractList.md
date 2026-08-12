# frmContractList – Danh sách hợp đồng lao động

## Vị trí file
- `Payroll/frmContractList.vb` (InitializeComponent nằm ngay trong file `.vb`, **không có file `frmContractList.Designer.vb` riêng**), `frmContractList.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `SmartBooks_ContractList` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateSmartBooks_ContractList"`
- `HRFORM_DeleteStore = "usp_DeleteSmartBooks_ContractList"`
- `HRFORM_InputForm = "frmContractList_Nhap"` (khai báo nhưng không dùng vì Thêm/Sửa dạng popup bị ẩn – xem bên dưới)
- `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`
- Tiêu đề form: "Create/Edit Contract List"
- Được đăng ký ở menu qua `frmMain.vb`: `addMethod("Payroll", "CreateEditEmployeeContract", GetType(frmContractList))`

## Mục đích
Quản lý **danh sách hợp đồng lao động** của nhân viên: mã hợp đồng, loại hợp đồng, ngày ký/hiệu lực/hết hạn (tự tính theo loại HĐ), hợp đồng chính (cho phụ lục), ghi chú. Ngoài nhập tay từng bản ghi qua panel, form còn hỗ trợ **xuất mẫu Excel để nhập hàng loạt hợp đồng kèm các khoản lương/phụ cấp cấu thành** và **nhập ngược lại từ Excel**.

## Bố cục giao diện
1 tab "General" gồm `TableLayoutPanel2` (3 vùng ngang) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu (`pnDuLieuNhap`) | `Contract_ID` | TextBox | Mã hợp đồng |
| Nhập liệu | `Type` | LookUpEdit | Loại HĐ (nguồn `SmartBooks_Contract`, hiển thị `ConTract_Name<Lan>`) |
| Nhập liệu | `CL_RegisterDate` | DateEdit | Ngày ký |
| Nhập liệu | `CL_StartDate` | DateEdit | Ngày hiệu lực HĐ (tự đồng bộ theo Ngày ký) |
| Nhập liệu | `CL_ExpiredDate` | DateEdit | Ngày hết hạn HĐ (tự tính theo loại HĐ) |
| Nhập liệu | `status` | CheckBox (label `lblstatus` hiển thị nguyên chữ "status", chưa dịch) | Trạng thái hợp đồng |
| Nhập liệu | `CL_FatherID` | TextBox (readonly) | Hợp đồng chính (dùng khi đây là phụ lục) |
| Nhập liệu | `InsertSource` | TextBox (readonly) | Nguồn nhập (vd "NhapExcel") |
| Nhập liệu | `CL_Remark` | RichTextBox | Ghi chú |
| Nhập liệu (ẩn) | `ContractAnnexID` + `lbContractAnneID` | RichTextBox + Label, `Visible = False` | Số phụ lục hợp đồng – tồn tại trong code nhưng **không hiển thị trên UI** |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách hợp đồng |

Ngoài ra Designer khai báo sẵn một loạt `MenuItem` (`mi_HuyLocToanBo`, `mi_LocHopDongMoiNhat`, `mi_Loc`, `mnXoa`, `mnIn`, `mnitXemHD`, `mi_XemToanBoHopDong`, `mi_HuyLoc`...) nhưng **không có `ContextMenu` nào được khởi tạo/gán** trong `InitializeComponent`, và không có sự kiện `Handles` nào cho các menu item này trong code-behind → đây là control thừa, không thuộc UI đang hoạt động.

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateSmartBooks_ContractList]", TableLayoutPanel2, ErrorProvider1)` → Insert/Update trực tiếp từ panel; nếu thành công gọi lại `Search()`; luôn focus lại `Employee_ID` |
| Các nút chuẩn `HRFORM` (Xóa/Xuất-Nhập Excel/Lấy mẫu/F5...) | kế thừa, điều phối qua `ExecSubOrFunctionOfVB` | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` (nhập trực tiếp trên panel, không popup); nút "Lấy mẫu"/"Nhập Excel" gọi vào `ExecSubOrFunctionOfVB` (xem Luồng xử lý) |

## Luồng xử lý

1. **`frmContractList_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2`.
   - Nạp `tabLoaiHD` = toàn bộ `SmartBooks_Contract` (danh mục loại hợp đồng, có `NumberOfMonth`/`NumberOfYear`/`NumberOfDay`).
   - Gán mặc định `CL_StartDate`/`CL_RegisterDate = Today`.
   - Bind `Type` (LookUpEdit) vào `tabLoaiHD` (`DisplayMember = "ConTract_Name" & obj.Lan`, `ValueMember = "Contract_ID"`).
   - `tvcn.SearchEmployee(Employee_ID)`, focus `Contract_ID`, `LoadGiaoDienTheoDieuKien()`, gọi `Search()`.

2. **`CL_RegisterDate_ValueChanged`** → gán `CL_StartDate = CL_RegisterDate` (ngày hiệu lực mặc định theo ngày ký).

3. **`CL_StartDate_ValueChanged`** → gán `CL_ExpiredDate = GetNgayHetHanHD()`.

4. **`GetNgayHetHanHD()`** – tính ngày hết hạn: lấy `CL_StartDate`, cộng thêm `NumberOfMonth`/`NumberOfYear`/`NumberOfDay` của loại hợp đồng đang chọn (tra trong `tabLoaiHD` theo `Type.Text`); nếu có cộng thêm thì trừ lùi 1 ngày (hết hạn = ngày trước ngày bắt đầu kỳ kế tiếp).

5. **`Search()`** – build `exec [dbo].[sp_BangHopDong] '1990-1-1','<cuối tháng hiện tại>',1,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',null,N'<EmID>'` + nối thêm `ContractAnnexID.Text.Trim` vào cuối câu lệnh (control này bị ẩn trên UI nên giá trị luôn rỗng trong thực tế). Gọi `Xem(...)`, lưu `HRFORM_QueryView`.

6. **`AfterViewForm()` (override)** – gắn dropdown chọn nhanh trên cột grid `Type` từ danh mục `SmartBooks_Contract` (`Code`/`Name<Lan>`).

7. **`ExecSubOrFunctionOfVB()` (override)** – điều phối theo `ReportCode` (được set bởi cơ chế Report/`ThucHien` chuẩn của `HRFORM` khi bấm nút Lấy mẫu/Nhập Excel):
   - `"ContractListGetInputTemplate"`: mở popup `frmparaSalaryComponent` (`bMonthlyChanging = False`) để người dùng chọn các thành phần lương sẽ đưa vào mẫu; chọn nơi lưu file (`NhapHopDong.xlsx`); gọi `LayTemplateHD(...)` điền mã/tên thành phần lương đã chọn vào template Excel gốc (`Teamleate\NhapHopDong.xlsx`) rồi mở file vừa xuất.
   - `"ContractListInputTemplate"`: gọi `NhapHD()`.

8. **`NhapHD()`** – nhập hợp đồng hàng loạt từ Excel: đọc từng dòng (`Contract_ID`, `Employee_ID`, `fromdate`, `todate`, `Type`, `CL_FatherID`, `status`, `Remark` ở cột A-I); gọi `usp_InsertUpdateSmartBooks_ContractList` cho từng dòng; sau đó với các cột từ J trở đi (mỗi cột = 1 thành phần lương, tiêu đề ở dòng cấu hình số 6) và có giá trị `Amount`, gọi thêm `usp_InsertUpdateHR_SalaryComponent` để nhập kèm khoản lương/phụ cấp gắn với hợp đồng đó. Gom lỗi từng dòng vào `strError`, hiển thị tổng kết cuối cùng.

9. **`LayTemplateHD(...)`** – copy file Excel mẫu, điền cặp (mã, tên) thành phần lương được chọn vào các cột bắt đầu từ cột J (index 9), dòng 7-8, lưu ra file đích và mở lên.

10. **`Employee_ID_EditValueChanged`** – khai báo nhưng **không** tự tìm kiếm khi đổi nhân viên (không gọi `Search()`).

11. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5).

## Ghi chú kỹ thuật
- Không có file `Designer.vb` riêng cho form này — toàn bộ `InitializeComponent` nằm chung trong `frmContractList.vb` (khác các form còn lại trong module dùng cặp file `.vb`/`.Designer.vb`).
- Cơ chế lưu dùng chuẩn `tvcn.SaveByStore` (tự Insert/Update dựa theo khóa chính) — khác với `frmFamily` (chỉ Insert).
- `ContractAnnexID`/`lbContractAnneID` bị `Visible = False` nhưng vẫn được nối vào câu `Search()` — code chết/không có tác dụng thực tế trên UI hiện tại.
- Bộ `MenuItem` (`mi_Loc`, `mnXoa`, `mnIn`...) khai báo trong Designer nhưng không gắn vào `ContextMenu` nào và không có handler — vestigial, không hoạt động.
- Tính năng "Lấy mẫu nhập" / "Nhập Excel" đi kèm khoản lương biến động theo hợp đồng dùng chung layout cột động (thành phần lương nằm ngang từ cột J trở đi) với `frmSalaryComponent`, nhưng `frmContractList` gắn khoản lương vào theo khoảng hiệu lực hợp đồng (`fromdate`/`todate` của hợp đồng), còn `frmSalaryComponent` gắn theo tháng/năm cụ thể.
- Đoạn `If frm.bluu = False Then Exit Sub` sau khi mở `frmparaSalaryComponent` trong `ExecSubOrFunctionOfVB` bị **comment**, khác với `frmSalaryComponent` (có kiểm tra) — nghĩa là ở `frmContractList`, dù người dùng bấm Hủy trên popup chọn thành phần lương vẫn tiếp tục xuất file.
- `NhapHD()` khi gặp lỗi ở bước insert hợp đồng chính thì `Exit Sub` dừng hẳn, nhưng lỗi ở bước insert thành phần lương phụ thì chỉ ghi nhận vào `strError` và tiếp tục dòng tiếp theo — mức độ dừng khác nhau giữa 2 loại lỗi.
