# PhieuLuongMoi – Phiếu lương (xem bảng tính lương & gửi email)

## Vị trí file
- `Payroll/PhieuLuongMoi.vb`, `PhieuLuongMoi.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- `HRFORM_TableName = "Smartbooks_Salary"`
- Không gán `HRFORM_SaveStore`/`HRFORM_DeleteStore`
- Cờ ẩn: `HRFORM_VisibleControl_ExportExcel = False`, `HRFORM_VisibleControl_GetTemplate = False`, `HRFORM_VisibleControl_ImportExcel = False`, `HRFORM_VisibleControl_Luu = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Xoa = False` (chỉ còn về cơ bản: `btnRefresh` (Xem), `cbbReport`, `btnExcute`, `btnSaveLayout`/`btnRefreshLayout`, `btnQuickPrint` theo mặc định)

## Mục đích
Đây **không phải form nhập liệu CRUD chuẩn** mà là màn hình **xem bảng tính lương theo tháng** (từ `sp_BangTinhLuong`) kết hợp chức năng **xuất phiếu lương PDF hàng loạt và gửi email phiếu lương** cho từng nhân viên được chọn trên grid. Tên "Phiếu lương" phản ánh đúng vai trò report-viewer/gửi mail hơn là 1 form quản lý dữ liệu lương.

## Bố cục giao diện
`TableLayoutPanel2` chia 2 vùng ngang + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Có trên giao diện nhưng **không được dùng** trong `btnSearch_Click`/`Search` (xem Ghi chú kỹ thuật) |
| Tìm kiếm (`pnSearch`) | `lblthang` + `cboMonth`, `lblnam` + `cboYear` | Label + `WindowsControlLibrary.Month`/`Year` | Tháng/Năm cần xem bảng lương |
| Tìm kiếm (`pnSearch`) | `btnSearch` ("Tìm") | SimpleButton | Nạp bảng tính lương của tháng/năm đã chọn lên grid |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `lbFrommail` + `tbEmailFrom` | Label + TextBox | Email người gửi (Gmail) |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `lbMatKhau` + `tbpassemailfrom` | Label + TextBox (PasswordChar) | Mật khẩu email người gửi |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `lbCC` + `tbCC` | Label + TextBox | CC (chưa thấy dùng trong `SendEmail`) |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `lbBCC` + `tbBCC` | Label + TextBox | BCC — **`Visible = False`**, ẩn trên giao diện |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `lbChuDe` + `txtSubject` | Label + TextBox | Chủ đề mail, tự sinh `"Phiếu lương tháng <Month>/<Year>"` |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `UiButton1` ("Save") | SimpleButton | Lưu lại tài khoản email gửi (Mail/PassMail) vào `login.xml` |
| Cấu hình gửi mail (`pnDuLieuNhap`) | `btnGuiPhieuLuong` ("Gửi phiếu lương") | SimpleButton | Xuất PDF + gửi email phiếu lương cho các nhân viên đang chọn |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Bảng tính lương theo tháng, hỗ trợ chọn nhiều dòng (`SelectedRowsCount`) |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Cập nhật `txtSubject`; build `exec [dbo].[sp_BangTinhLuong] <Month>,<Year>,2,'<Lan>','admin'` rồi `Xem(...)` đổ lên `GridControl1`; lưu `HRFORM_QueryView` |
| **Save** (`UiButton1`) | `UiButton1_Click` | Đọc `login.xml` (`Application.StartupPath\login.xml`), yêu cầu nhập đủ Email/Mật khẩu, ghi đè `Mail`/`PassMail` vào dòng đầu tiên rồi `WriteXml` lại vào `obj.GetAppPath()\login.xml`; báo "Save successful!" |
| **Gửi phiếu lương** (`btnGuiPhieuLuong`) | `btnGuiPhieuLuong_Click` | Xóa toàn bộ file cũ trong thư mục `In\Private\`, sau đó gọi `GuiEmailNhieuPhieuLuong()` |
| `cboMonth`, `cboYear` | `cboMonth_Click`/`cboYear_Click` | Cập nhật lại `txtSubject` theo tháng/năm mới chọn |

## Luồng xử lý

1. **`PhieuLuongMoi_Load`**
   - `bTHANHPHANLUONG = False`.
   - Set `txtSubject.Text = "Phiếu lương tháng " + cboMonth.Text + "/" + cboYear.Text"`.
   - Đọc `login.xml` (`Application.StartupPath\login.xml`) lấy `Mail`/`PassMail` đã lưu trước đó, đổ vào `tbEmailFrom`/`tbpassemailfrom`.
   - Dòng `tvcn.LayDieuKienTheoQuyen(...)` (áp điều kiện phân quyền cơ cấu tổ chức lên các control ẩn `txtdepartmentcode`/`txtsectioncode`/`txtteamcode`) và `MaCongTy = tvcn.MaCongTy()` đều **bị comment** — form hiện không áp phân quyền cơ cấu tổ chức khi tìm bảng lương.

2. **`btnSearch_Click`** — xem bảng nút ở trên. Tham số cuối truyền vào `sp_BangTinhLuong` là chuỗi hằng `'admin'` chứ không phải `obj.UserName` thực tế.

3. **`btnGuiPhieuLuong_Click` → `GuiEmailNhieuPhieuLuong()`**
   - Lặp các dòng đang được chọn (`GridView1.SelectedRowsCount`) để gom danh sách `Employee_ID`; nếu không có dòng nào được chọn → cảnh báo "Hãy chọn nhân viên để gửi mail" và dừng.
   - Gọi `TaoPhieuLuongA4_ByEmp()` để xuất file PDF phiếu lương cho từng nhân viên đã chọn.
   - Với mỗi nhân viên: lấy `Email` từ cột `Email` của dòng đang chọn trên grid, gọi `SendEmail(...)` gửi file PDF (`<Year><Month>_<Employee_ID>.pdf` trong `In\Private\`) qua SMTP Gmail; nếu gửi lỗi thì **build** câu `Insert into HR_CannotSentEmail(...)` nhưng **không thấy lệnh thực thi SQL nào chạy `strsql` này** — có khả năng là đoạn code dang dở/bug, danh sách email gửi thất bại không thực sự được ghi vào DB.
   - Kết thúc hiển thị "Send email completed!".

4. **`TaoPhieuLuongA4_ByEmp()`**
   - Đọc thông tin report `ReportCode = "PhieuLuongTheoMa"` từ `HR_Report`; nếu không tồn tại hoặc thiếu `TemplateFile` thì báo lỗi (`Popup.Baocaokhongtontaivuilongkiemtralai` / `Popup.Phaimaukhongtontai`) và thoát.
   - Với mỗi nhân viên đang chọn trên grid: dùng `frmPara.ObjectParameter()` build mảng tham số `(Month, Year, ..., Employee_ID)` rồi gọi `ExportReport(TemplateFile, subArr, addressToExport)` xuất PDF vào `In\Private\<Year><Month>_<Employee_ID>.pdf`.

5. **`SendEmail(...)`** — gửi mail qua `System.Net.Mail.SmtpClient("smtp.gmail.com", 587)` với `EnableSsl = True`, đính kèm 1 file PDF, `Body = "Salary"` cố định (không dùng `Content`/`EmailCC`/`EmailBCC` truyền vào). Có 1 khối code gửi mail qua COM `CDO.Message` cũ bị **comment toàn bộ** — cách gửi mail cũ trước khi chuyển sang `SmtpClient`.

## Ghi chú kỹ thuật
- **`Employee_ID`** (LookUpEdit tìm nhân viên) hiện diện trên panel tìm kiếm nhưng **không được dùng** ở `btnSearch_Click`/không xuất hiện trong câu lệnh gọi `sp_BangTinhLuong` — control còn sót lại từ thiết kế trước hoặc tính năng lọc theo nhân viên chưa được nối dây.
- **Không có `GridControl1_KeyUp` gắn `Handles GridControl1.KeyUp`** trên form này (khác các form Payroll khác) → phím tắt chuẩn của `HRFORM` (Ctrl+S/D/F/Q, F5 qua `Gridview_KeyUp`) **không hoạt động** khi focus ở grid của form này.
- Tham số user truyền vào `sp_BangTinhLuong` bị hard-code chuỗi `'admin'` thay vì username đăng nhập thực tế (`obj.UserName`) — cần lưu ý nếu stored procedure dùng tham số này để phân quyền/ghi log.
- Mật khẩu email (`tbpassemailfrom`) được lưu **dạng plain text** trong file `login.xml` trên máy client (đọc/ghi qua `DataSet.ReadXml`/`WriteXml`) — rủi ro bảo mật nếu file này bị lộ.
- Đoạn xử lý khi gửi mail thất bại (build câu `Insert into HR_CannotSentEmail`) **không thực thi câu SQL đã build** — khả năng là lỗi tồn đọng (bug), nên không thể dựa vào bảng `HR_CannotSentEmail` để biết chính xác các email gửi thất bại từ form này.
- Chức năng chính triển khai trên form là **xuất PDF hàng loạt + gửi email** phiếu lương, không có nút "In" phiếu lương đơn lẻ ngay trên giao diện (khác với kỳ vọng ban đầu về 1 form "xem/in phiếu lương" đơn giản).
- `tvcn.LayDieuKienTheoQuyen` (áp điều kiện phân quyền cơ cấu tổ chức) bị comment trong `Load` — nghĩa là khi tìm bảng lương theo tháng, form **không giới hạn theo phòng ban/quyền xem của người dùng** ở tầng UI (việc phân quyền, nếu có, phải nằm hoàn toàn trong `sp_BangTinhLuong`).
