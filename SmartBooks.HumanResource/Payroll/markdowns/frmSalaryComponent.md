# frmSalaryComponent – Thành phần lương biến động theo tháng

## Vị trí file
- `Payroll/frmSalaryComponent.vb`, `frmSalaryComponent.Designer.vb`, `frmSalaryComponent.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_SalaryComponentFollowMonth` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_SalaryComponentFollowMonth"`
- `HRFORM_DeleteStore = "usp_DeleteHR_SalaryComponentFollowMonth"`
- `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`

## Mục đích
Khai báo **các khoản lương/phụ cấp biến động theo từng tháng** cho nhân viên (ví dụ thưởng, phụ cấp phát sinh không cố định — khác các khoản lương cố định gắn theo hợp đồng ở `frmContractList`). Mỗi bản ghi gồm: nhân viên, thành phần lương, số tiền, tháng/năm áp dụng, ghi chú. Hỗ trợ xuất mẫu Excel và nhập hàng loạt từ Excel.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu (`pnDuLieuNhap`) | `SalaryComponent` | LookUpEdit | Thành phần lương — chỉ nạp các khoản có `MonthlyChanging = 1` trong `HR_SalaryComponentCategory` (khoản được phép khai báo biến động theo tháng) |
| Nhập liệu | `Amount` | TextBox | Số tiền — tự format số khi gõ (`tvcn.AmountFormat`) |
| Nhập liệu | `Month_` / `Year_` | `WindowsControlLibrary.Month` / `WindowsControlLibrary.Year` | Control chuyên dụng chọn Tháng/Năm áp dụng |
| Nhập liệu | `Remark` | RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách khoản lương biến động đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_SalaryComponentFollowMonth]", TableLayoutPanel2, ErrorProvider1)` → Insert/Update; thành công thì `Search()` lại; luôn focus `Employee_ID` |
| Nút "Lấy mẫu" (GetTemplate) | qua `ExecSubOrFunctionOfVB`, `ReportCode = "SalaryComponentGetTemplate"` | Mở popup `frmparaSalaryComponent` (`bMonthlyChanging = True`) chọn các thành phần lương biến động cần đưa vào mẫu; nếu người dùng **hủy** popup (`frm.bluu = False`) thì dừng, không xuất file; ngược lại chọn nơi lưu và xuất `NhapLuongTheoThang.xlsx` |
| Nút "Nhập Excel" (ImportExcel) | qua `ExecSubOrFunctionOfVB`, `ReportCode = "SalaryComponentInputTemplate"` | Gọi `NhapTempale()` nhập hàng loạt từ file Excel đã chọn |
| Các nút chuẩn `HRFORM` khác | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` |

## Luồng xử lý

1. **`frmSalaryComponent_Load`**
   - Đánh dấu (*) trường bắt buộc.
   - Nạp `SalaryComponent` từ `select SalaryComponent as Code, Name<Lan> as Name from HR_SalaryComponentCategory Where MonthlyChanging = 1 Order By OrderBy` qua `tvcn.GetDataOnDropDownCategoryCodeName`.
   - `LoadGiaoDienTheoDieuKien()`, `tvcn.SearchEmployee(Employee_ID)`, gọi `Search()`.

2. **`Search()`** – build `[dbo].[sp_BangLuongBienDong] '<Year_>','<Month_>',2,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmID>'` (**không có tiền tố `exec`** ở đầu câu lệnh — khác các form khác trong module luôn có `exec [dbo].[sp_...]`, xem Ghi chú kỹ thuật). Gọi `Xem(...)`, lưu `HRFORM_QueryView`.

3. **`Amount_TextChanged`** → `tvcn.AmountFormat(Amount)` tự thêm dấu phân cách hàng nghìn khi gõ.

4. **`ExecSubOrFunctionOfVB()` (override)**:
   - `"SalaryComponentGetTemplate"`: mở `frmparaSalaryComponent` (chế độ biến động theo tháng), có kiểm tra `frm.bluu` — hủy popup thì thoát không xuất file; xuất `NhapLuongTheoThang.xlsx` qua `LayTemplateSalaryComponent(...)`.
   - `"SalaryComponentInputTemplate"`: gọi `NhapTempale()`.

5. **`NhapTempale()`** – nhập từ Excel: đọc từng dòng `Employee_ID`(A), `Year`(B), `Month`(C), `Remark`(D); với các cột từ E (index 4) trở đi, mỗi cột ứng với 1 thành phần lương (tiêu đề tại dòng cấu hình số 6); nếu ô có số tiền, gọi `usp_InsertUpdateHR_SalaryComponentFollowMonth` cho từng cặp (nhân viên, thành phần lương, số tiền, tháng, năm). **Gặp lỗi ở bất kỳ dòng/cột nào là `Exit Sub` dừng ngay lập tức toàn bộ quá trình nhập** (khác `frmContractList.NhapHD` — form đó gom lỗi và nhập tiếp các dòng còn lại).

6. **`LayTemplateSalaryComponent(...)`** – điền cặp (mã, tên) thành phần lương đã chọn vào file mẫu Excel từ cột E (index 4) trở đi, dòng 7-8, lưu và mở file.

7. **`Employee_ID_EditValueChanged`** – khai báo nhưng bị comment, không tự tìm kiếm khi đổi nhân viên.

8. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn).

## Ghi chú kỹ thuật
- Câu lệnh `Search()` thiếu từ khóa `exec` ở đầu (`"[dbo].[sp_BangLuongBienDong] ..."` thay vì `"exec [dbo].[sp_BangLuongBienDong] ..."`) — không nhất quán với các form khác trong cùng module (`frmContractList`, `frmDanhSachNguoiPhuThuoc` đều có `exec`); cần xác nhận `kn.ReadData`/`Xem` có tự thêm `exec` hay không, nếu không đây có thể là lỗi khiến câu lệnh chạy sai.
- Khác với `frmContractList` (không kiểm tra `frm.bluu`), form này **có** kiểm tra nên hủy popup chọn thành phần lương sẽ không xuất file — hành vi nhất quán và an toàn hơn.
- `NhapTempale()` dừng cứng (`Exit Sub`) ngay khi gặp dòng lỗi đầu tiên, không tiếp tục xử lý các dòng sau — người dùng cần sửa lỗi và nhập lại từ đầu file thay vì chỉ sửa dòng lỗi.
- `Year_`/`Month_` là control dùng chung (`WindowsControlLibrary.Year`/`Month`) — không phải DateEdit thông thường.
- Không override `BeforeSave`/`BeforeDelete`, không có `AfterViewForm` (không có dropdown-trên-grid tùy biến).
