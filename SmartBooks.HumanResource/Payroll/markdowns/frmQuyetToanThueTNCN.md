# frmQuyetToanThueTNCN – Quyết toán thuế thu nhập cá nhân

## Vị trí file
- `Payroll/frmQuyetToanThueTNCN.vb`, `frmQuyetToanThueTNCN.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- `HRFORM_TableName` **không được gán** (không có bảng dữ liệu chính riêng cho form này)
- Không set `HRFORM_SaveStore`/`HRFORM_DeleteStore`
- Cờ hiển thị bị tắt: `HRFORM_VisibleControl_GetTemplate = False`, `HRFORM_VisibleControl_ImportExcel = False`, `HRFORM_VisibleControl_Luu = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Xem = False` (ẩn `btnRefresh`), `HRFORM_VisibleControl_Xoa = False`
- Các cờ còn lại (`cbbReport`, `ThucHien`/`btnExcute`, `ExportExcel`, `SaveLayout`, `RefreshLayout`, `QuickPrint`, `Đóng`) **giữ mặc định `True`** theo base `HRFORM` (không bị form này override)

## Mục đích
**KHÔNG phải form CRUD/nhập liệu.** Đây thực chất là một **"form vỏ" (report launcher)**: dùng để chọn 1 mẫu báo cáo Quyết toán thuế TNCN đã khai báo sẵn trong danh mục `HR_Report` (những dòng có `ReportFather = 'frmQuyetToanThueTNCN'`) rồi bấm **Thực hiện** để xuất/in báo cáo. Toàn bộ code phía sau (`.vb`) gần như trống — không có `Search()`, không gán `DataSource` cho grid, không có logic nghiệp vụ tính thuế nào nằm trong file này.

## Bố cục giao diện
Form chỉ có `XtraTabControl1` → 1 tab `General` chứa `GridControl1`/`GridView1` (Dock=Fill), **không có panel nhập liệu nào khác**. Grid này trên thực tế **luôn trống** vì không có đoạn code nào gán dữ liệu cho nó (không override `AfterViewForm`, không gọi `Xem(...)`). Toàn bộ tương tác của người dùng nằm ở thanh nút chuẩn `PanelButton` phía trên/dưới form:

| Control | Vị trí | Ý nghĩa |
|---|---|---|
| `cbbReport` | `PanelButton` (chuẩn `HRFORM`) | Danh sách mẫu báo cáo Quyết toán thuế TNCN, nạp từ `HR_Report` với điều kiện `ReportFather = 'frmQuyetToanThueTNCN'` (và `TabKey = 'General'` do form có gán `HRFORM_XtraTabControl`) |
| `btnExcute` ("Thực hiện") | `PanelButton` | Thực thi mẫu báo cáo đang chọn |
| `GridControl1`/`GridView1` | Tab `General` | Grid trống, chỉ tồn tại về mặt giao diện, không có dữ liệu |

## Danh sách nút & tác dụng

| Nút | Sự kiện (kế thừa từ `HRFORM`) | Tác dụng |
|---|---|---|
| **Thực hiện** (`btnExcute`) | `btnExcute_Click` → `ThucHien(String.Empty)` (định nghĩa trong `HRFORM.vb`) | Lấy dòng `HR_Report` tương ứng `ReportCode` đang chọn ở `cbbReport`, mở `frmPara` (form nhập tham số báo cáo dùng chung toàn hệ thống) với `ReportInformation` = dòng đó, sau đó xuất/in báo cáo theo `TemplateFile` khai báo trong `HR_Report` |
| `cbbReport` | `cbbReport_ValueChanged` (base) | Đổi báo cáo đang chọn, cập nhật `ReportCode`/`ReportRow` dùng khi bấm Thực hiện |
| `btnExportExcel`, `btnSaveLayout`, `btnRefreshLayout`, `btnQuickPrint` | kế thừa base | Vẫn hiển thị theo mặc định nhưng ít có tác dụng thực tế vì grid không có dữ liệu |
| Thêm/Sửa/Xóa/Lưu/Tải lại (Xem)/Lấy mẫu/Nhập Excel | kế thừa base | Toàn bộ bị ẩn (`HRFORM_VisibleControl_... = False`), không dùng trên form này |

## Luồng xử lý
1. **`frmQuyetToanThueTNCN_Load`** – **rỗng**, không có xử lý riêng.
2. **`HRFORM_Load`** (base, chạy cùng sự kiện `MyBase.Load`) – vì `_HRFORM_TypeOfForm <> Input` và `HRFORM_XtraTabControl` đã được gán (`= XtraTabControl1`), nên nạp `Report = kn.ReadData("select ... from HR_Report where isnull(NotUsing,0)=0 and ReportFather=N'frmQuyetToanThueTNCN ' and TabKey = N'General' order by OrderBy", "table")` rồi gán `cbbReport.DataSource = Report`.
3. **`GridControl1_KeyUp`** – ủy quyền cho `Gridview_KeyUp` xử lý phím tắt chuẩn (Ctrl+S/D/F/Q, F5), nhưng phần lớn thao tác (Lưu/Xóa/Tải lại) đã bị ẩn nên các phím này gần như vô nghĩa trên form này.
4. **Bấm "Thực hiện"** → `ThucHien(String.Empty)` (base) → mở `frmPara` để người dùng nhập tham số quyết toán thuế (kỳ tính, nhân viên...) → xuất báo cáo theo `TemplateFile` đã cấu hình.

## Ghi chú kỹ thuật
- Form **không theo pattern "grid CRUD chuẩn"** như đa số form khác trong `Payroll/` (`frmMucLuongNhanVien`...) — nó gần với vai trò của các form "para_..." (form tham số mở báo cáo) nhưng lại được cài đặt như một `HRFORM` đầy đủ (có `XtraTabControl`, `GridControl`) thay vì 1 form popup tham số đơn giản.
- Toàn bộ nghiệp vụ "Quyết toán thuế TNCN" (công thức tính thuế, mẫu biểu, tham số) **không nằm trong code `.vb` của form** mà nằm ở cấu hình báo cáo trong bảng `HR_Report` (cột `ReportFather = 'frmQuyetToanThueTNCN'`) và stored procedure/template đứng sau `TemplateFile` — muốn biết chi tiết công thức quyết toán phải tra dữ liệu `HR_Report` và report template tương ứng, không thể chỉ đọc mã nguồn form.
- Vì `HRFORM_TableName` không được gán và không có `Search()`/`AfterViewForm()` nào gán dữ liệu cho `GridControl1`, chức năng "Xuất Excel" (`btnExportExcel`, vẫn hiển thị vì không bị ẩn) trên thực tế sẽ xuất một grid trống nếu người dùng bấm mà chưa chạy báo cáo nào.
