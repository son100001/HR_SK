# frmLuongCoDinh – Lương cố định

## Vị trí file
- `Payroll/frmLuongCoDinh.vb`, `frmLuongCoDinh.Designer.vb`, `frmLuongCoDinh.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_SalaryComponent` (`HRFORM_TableName`)
- Stored procedure Lưu/Xóa: `usp_InsertUpdateHR_SalaryComponent` (`HRFORM_SaveStore`) / `usp_DeleteHR_SalaryComponent` (`HRFORM_DeleteStore`)
- Stored procedure Tìm kiếm: `sp_BangLuongCoDinh`

## Mục đích
Khai báo **các khoản lương cố định (thành phần lương không đổi theo tháng)** cho từng nhân viên: chọn "Thành phần lương" (`SalaryComponent`, lấy từ danh mục `HR_SalaryComponentCategory` **lọc những thành phần có `MonthlyChanging = 0`**, tức các khoản lương KHÔNG biến động theo tháng, ví dụ lương cơ bản, phụ cấp cố định...), nhập số tiền (`Amount`) và khoảng thời gian áp dụng (`fromdate`–`todate`, `todate` có thể bỏ trống = áp dụng vô thời hạn). Ngoài nhập tay từng dòng, form còn hỗ trợ **nhập hàng loạt bằng Excel** (import template) và **xuất template Excel** để nhập.

## Bố cục giao diện
Tab "General", panel nhập chia 3 vùng (`TableLayoutPanel2`) phía trên + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblSalaryComponent` + `SalaryComponent` | Label + LookUpEdit | Thành phần lương cố định (chỉ các thành phần `MonthlyChanging=0`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblAmount` + `Amount` | Label + TextBox | Số tiền (định dạng số qua `tvcn.AmountFormat` khi `TextChanged`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblfromdate` + `fromdate` | Label + DateEdit | Từ ngày áp dụng (mặc định = hôm nay) |
| Nhập liệu (`pnDuLieuNhap`) | `cbtodate` (CheckBox) + `lbltodate` + `todate` | CheckBox + Label + DateEdit | Bật `cbtodate` mới cho phép nhập `todate` (Đến ngày); nếu tắt, `todate` bị disable và giá trị = Nothing (không giới hạn ngày kết thúc) |
| Nhập liệu (`pnDuLieuNhap`) | `Remark` | RichTextBox | Ghi chú |
| Nhập liệu (`pnDuLieuNhap`, ẩn) | `InsertSource` (TextBox, `Visible=False`) | TextBox | Trường ẩn lưu nguồn gốc bản ghi (nhập tay hay `'Excel'` khi import hàng loạt) — người dùng không thấy trên UI |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách lương cố định đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc theo `Employee_ID`, `fromdate` |
| **Lưu** (`btnSave`) | `btnSave_Click` | `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_SalaryComponent]", TableLayoutPanel2, ErrorProvider1)` — kiểm tra quyền + trường bắt buộc, Insert/Update; nếu thành công gọi lại `Search()`, sau đó focus `Employee_ID` |
| **Lấy mẫu Excel** (`btnGetTemplate`, nút chuẩn `HRFORM`, `ReportCode = "LuongCoDinhGetTemplate"`) | `ExecSubOrFunctionOfVB` (override) | Mở form `frmparaSalaryComponent` (chọn danh sách thành phần lương cố định muốn xuất cột), nếu người dùng xác nhận (`frm.bluu = True`) thì mở `SaveFileDialog` và gọi `LayTemplateSalaryComponent(...)` để tạo file Excel mẫu (`Teamleate\NhapLuongCoDinh.xlsx` làm khuôn, ghi mã + tên thành phần lương vào các cột bắt đầu từ cột E, dòng 7–8) rồi mở file bằng `Process.Start` |
| **Nhập từ Excel** (`btnImportExcel`, nút chuẩn `HRFORM`, `ReportCode = "LuongCoDinhInputTemplate"`) | `ExecSubOrFunctionOfVB` (override) | Gọi `NhapTempale()` |
| Các nút chuẩn khác (Thêm/Sửa) | kế thừa | `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThemMoi = False` → ẩn, vì nhập liệu trực tiếp trên panel |

## Luồng xử lý

1. **`frmLuongCoDinh_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2`.
   - `fromdate.EditValue = Today`.
   - Nạp danh sách thành phần lương cố định cho combo `SalaryComponent`: `select SalaryComponent as Code, Name<Lan> as Name from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0 order by OrderBy`.
   - `LoadGiaoDienTheoDieuKien()`, `tvcn.SearchEmployee(Employee_ID)` nạp danh sách nhân viên.
   - Dòng `Search()` bị **comment** → **không tự tải dữ liệu ban đầu khi mở form**, khác với `frmEmpRegisParameter`/`frmMucLuong` (có gọi `Search()` ngay khi Load). Người dùng phải tự bấm **Tìm** hoặc thao tác khác để grid có dữ liệu lần đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - Build: `[dbo].[sp_BangLuongCoDinh] '<fromdate>','<fromdate>',<3 hoặc 2 tùy có/không EmID>,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
   - **Lưu ý quirk**: cả 2 tham số ngày đầu tiên của stored procedure đều truyền `fromdate` (không dùng `todate.EditValue` như tên biến gợi ý) — tức bộ lọc theo ngày chỉ dùng một mốc `fromdate` cho cả "từ" và "đến" trong câu Search, không liên quan tới cặp `fromdate`/`todate` trên panel nhập liệu (2 control đó chỉ dùng để nhập giá trị hiệu lực của bản ghi khi Lưu, không dùng để lọc tìm kiếm).
   - Tham số thứ 3 = `3` nếu không chọn nhân viên (xem toàn bộ theo phân quyền cơ cấu tổ chức), = `2` nếu có chọn nhân viên cụ thể (chế độ lọc khác nhau tùy stored procedure xử lý).
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Amount_TextChanged`** – tự động format số khi gõ: `tvcn.AmountFormat(Amount)`.

4. **`cbtodate_CheckedChanged`** – bật/tắt cho phép nhập ngày kết thúc: check → `todate.Enabled = True`, `todate.EditValue = Today`; uncheck → `todate.Enabled = False`, `todate.EditValue = Nothing`.

5. **`Employee_ID_KeyUp`** (khai báo nhưng **không gắn `Handles`** — dead code, không được gọi runtime) — logic dự kiến: F3 mở `para_NhanVien` để chọn nhanh nhân viên (gán `Employee_ID.Text`), Ctrl+S gọi `btnSave_Click`.

6. **`Employee_ID_TextChanged_1`** (cũng không gắn `Handles` — dead code) — nội dung `Search()` bị comment.

7. **`Gridex1_KeyUp`** – ủy quyền phím tắt chuẩn cho `Gridview_KeyUp`.

8. **`NhapTempale()`** (nhập Excel hàng loạt)
   - Mở `OpenFileDialog` chọn file `.xlsx`, xác nhận Yes/No trước khi nhập (`Popup.Bancothucsumuonnhap`).
   - Đọc từng dòng bắt đầu từ dòng 8 (biến `index`), cột A = Employee_ID, B = fromdate, C = todate (rỗng → null), D = Remark; các cột từ E trở đi (mỗi cột ứng với 1 thành phần lương, tên mã thành phần đọc từ dòng cấu hình `ColConfig = 6`) chứa số tiền `Amount` cho thành phần lương tương ứng.
   - Với mỗi ô có giá trị, gọi trực tiếp `exec usp_InsertUpdateHR_SalaryComponent null,<Employee_ID>,<SalaryComponent>,<Amount>,<fromdate>,<todate>,'Excel',<Remark>,<InsertDate>,<UserName>` (nguồn `InsertSource` = `'Excel'`, khớp với field ẩn `InsertSource` trên UI).
   - Nếu stored procedure trả về cột `ThongBao` khác rỗng ở bất kỳ dòng nào → hiển thị lỗi kèm số dòng + mã nhân viên rồi **dừng toàn bộ** quá trình nhập (Exit Sub), không tiếp tục các dòng sau.
   - Kết thúc thành công → thông báo "Popup.Thuchienketthuc".
   - Có đoạn code cũ dùng `kn.SaveData(...)` bị **comment out**, thay bằng cách gọi qua `kn.ReadData` (đọc `ThongBao`) — dấu vết refactor cách xử lý lỗi.

## Ghi chú kỹ thuật
- Form là ví dụ điển hình của mô hình (a) "nhập trực tiếp trên panel", nhưng bổ sung thêm tính năng **Import/Export Excel hàng loạt** không có ở `frmInsurance`/`frmEmpNonRegisInsurance` (module BaoHiem).
- **Không tự động `Search()` khi Load** — khác các form khác trong đợt khảo sát (`frmEmpRegisParameter`, `frmMucLuong` đều gọi `Search()` trong sự kiện Load). Grid trống cho tới khi người dùng bấm Tìm hoặc Lưu/Nhập Excel thành công (khi đó `Search()` được gọi lại từ `btnSave_Click`).
- Có 2 handler thừa không gắn `Handles` (`Employee_ID_KeyUp`, `Employee_ID_TextChanged_1`) — code chết, dấu hiệu người phát triển từng gắn sự kiện qua Designer rồi gỡ ra nhưng chưa dọn code.
- Ô lọc theo ngày trong `Search()` chỉ dùng `fromdate` (đúng 1 mốc thời gian, lặp lại 2 lần trong tham số SP), **không** dùng `todate` — cần lưu ý khi đọc/sửa logic tìm kiếm, tránh nhầm với cặp `fromdate`/`todate` dùng để nhập hiệu lực bản ghi.
- Import Excel dừng ngay khi gặp lỗi đầu tiên (không có cơ chế transaction rollback rõ ràng ở tầng client — phụ thuộc logic bên trong stored procedure `usp_InsertUpdateHR_SalaryComponent` để đảm bảo toàn vẹn dữ liệu các dòng đã insert trước đó).
