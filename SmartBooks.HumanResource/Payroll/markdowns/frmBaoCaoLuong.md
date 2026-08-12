# frmBaoCaoLuong – Báo cáo lương

## Vị trí file
- `Payroll/frmBaoCaoLuong.vb`, `frmBaoCaoLuong.Designer.vb`, `frmBaoCaoLuong.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- `HRFORM_TableName = "SmartBooks_Salary"` (chỉ dùng để tra cứu cấu trúc bảng cho các thao tác chung, form này không Insert/Update/Delete dữ liệu)
- Không khai báo `HRFORM_SaveStore`/`HRFORM_DeleteStore` (form thuần xem/xuất báo cáo)

## Mục đích
Là **màn hình trung tâm chạy các báo cáo lương**: không tự chứa logic truy vấn/tính lương riêng mà hoàn toàn dựa vào cơ chế **danh mục báo cáo chuẩn** của `HRFORM` (bảng `HR_Report`, control `cbbReport`, nút "Thực hiện"). Form có 2 tab, mỗi tab ứng với 1 nhóm báo cáo lương khác nhau (dựa theo cột `TabKey` trong `HR_Report`):
- Tab **General** – các báo cáo lương chung.
- Tab **MonthlySalary** ("Monthly Salary") – các báo cáo lương theo tháng.

## Bố cục giao diện
Khác với 3 form còn lại khảo sát cùng đợt, `frmBaoCaoLuong` **không có `TableLayoutPanel2`/vùng nhập liệu riêng** – toàn bộ nội dung mỗi tab chỉ là 1 `GridControl` phủ kín (`Dock = Fill`):

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tab "General" | `GridControl1`/`GridView1` | DevExpress Grid | Hiển thị kết quả báo cáo thuộc nhóm General |
| Tab "MonthlySalary" | `GridControl2`/`GridView2` | DevExpress Grid | Hiển thị kết quả báo cáo thuộc nhóm MonthlySalary |
| Thanh nút chuẩn (`PanelButton`, kế thừa `HRFORM`) | `cbbReport` | ComboBox (được `HRFORM` tự thêm) | Chọn báo cáo muốn chạy (nạp từ `HR_Report`, lọc theo `ReportFather = 'frmBaoCaoLuong'` và `TabKey` = tên tab đang chọn) |
| Thanh nút chuẩn | `btnExcute` ("Thực hiện") | SimpleButton (kế thừa) | Chạy báo cáo đang chọn trong `cbbReport` |

## Danh sách nút & tác dụng
Form không có nút tùy biến nào (không có `btnSave`, `btnSearch`...) – toàn bộ thao tác dựa vào các nút chuẩn của `HRFORM`:

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **cbbReport** (chọn mẫu báo cáo) | kế thừa | Danh sách báo cáo được nạp lại mỗi khi đổi tab (`HRFORM_XtraTabControl_SelectedTabChanged` trong `HRFORM`, lọc theo `TabKey` = tên tab) |
| **Thực hiện** (`btnExcute`) | kế thừa (`ThucHien(String.Empty)` trong `HRFORM`) | Lấy báo cáo đang chọn từ `Report` (DataTable đã nạp theo tab), mở `frmPara` truyền `ReportInformation` để người dùng nhập tham số, sau đó chạy stored procedure của báo cáo và đổ kết quả lên grid tương ứng (`HRFORM_GridControl`/`HRFORM_Gridview` – được trỏ động theo tab đang chọn) |
| Xuất Excel / Xem / F5... | kế thừa | Hoạt động theo cơ chế chung của `HRFORM`, thao tác trên grid của tab đang active |
| Thêm/Sửa/Xóa/Lưu/Get Template/Import Excel | kế thừa nhưng bị **ẩn** | `HRFORM_VisibleControl_ThemMoi/Sua/Xoa/Luu/GetTemplate/ImportExcel = False` – form thuần chỉ xem báo cáo, không chỉnh sửa dữ liệu |

## Luồng xử lý

1. **Không có `frmBaoCaoLuong_Load` riêng** – form không override sự kiện `Load`; toàn bộ khởi tạo (nạp `cbbReport`, load danh sách báo cáo lần đầu theo tab `General` đang mặc định chọn) do `HRFORM_Load` (base class) đảm nhiệm.

2. **`XtraTabControl1_SelectedPageChanged`** (chạy mỗi khi đổi tab):
   - Nếu tab **MonthlySalary**: gán `HRFORM_Gridview = GridView2`, `HRFORM_GridControl = GridControl2`; ẩn `GetTemplate`, `ImportExcel`, `Luu`, `Sua`, `Xoa`.
   - Nếu tab **General**: gán `HRFORM_Gridview = GridView1`, `HRFORM_GridControl = GridControl1`; ẩn cùng nhóm nút như trên.
   - Gọi `HRFORM_XtraTabControl_SelectedTabChanged(sender, e)` (hàm base) để nạp lại `Report`/`cbbReport` theo `TabKey` mới và reset `HRFORM_QueryView`.
   - Gọi `LoadGiaoDienTheoDieuKien()` để áp lại trạng thái enable/disable nút theo quyền.

3. **`GridControl1_KeyUp` / `GridControl2_KeyUp`** → cả 2 đều ủy quyền cho `Gridview_KeyUp` (phím tắt chuẩn Ctrl+S/D/F/Q, F5) – tuy nhiên vì `Luu`/`Sua`/`Xoa` đều bị ẩn nên trên thực tế chỉ còn ý nghĩa với Ctrl+F (focus grid), Ctrl+Q (đóng form), F5 (tải lại theo `HRFORM_QueryView` hiện tại).

4. Không có hàm `Search()` riêng, không override `BeforeSave()`/`AfterViewForm()`/`AfterSave()` – **toàn bộ nghiệp vụ nạp dữ liệu báo cáo nằm ở base class** (`ThucHien`/`Xem` trong `HRFORM.vb`), form con chỉ định tuyến `HRFORM_GridControl`/`HRFORM_Gridview` theo tab.

## Ghi chú kỹ thuật
- Đây là kiểu form **"vỏ chứa báo cáo"** hoàn toàn khác biệt so với 3 form còn lại khảo sát (`frmBacTayNghe`, `frmBacTayNgheNhanVien`, `frmCaiDatPhuCap`) – không có panel nhập liệu, không có `Search()`, không thao tác trực tiếp lên bảng `HR_...` mà dữ liệu hiển thị hoàn toàn phụ thuộc vào cấu hình trong bảng danh mục `HR_Report` (cột `ReportFather = 'frmBaoCaoLuong'`, `TabKey ='General'` hoặc `'MonthlySalary'`) và các stored procedure được khai báo cho từng report code ở đó. Muốn biết chính xác báo cáo nào chạy ra dữ liệu gì phải tra bảng `HR_Report`, không thể suy ra chỉ từ code `.vb` của form.
- `HRFORM_TableName = "SmartBooks_Salary"` được set nhưng không thấy dùng trực tiếp trong code của form (không có `Search()`/`Xem` nào build query từ tên bảng này) – nhiều khả năng chỉ dùng cho các hàm tiện ích chung của `HRFORM` cần biết "bảng gốc" của form (ví dụ lấy cấu trúc cột khi cần), không phản ánh việc form thao tác trực tiếp lên bảng đó.
- Ẩn `Luu`/`Sua`/`Xoa`/`GetTemplate`/`ImportExcel` được set **lặp lại y hệt** ở cả 2 nhánh `If/ElseIf` trong `XtraTabControl1_SelectedPageChanged` (cho tab MonthlySalary và tab General) – có thể gộp chung code phía trước `If` vì không có gì khác biệt giữa 2 nhánh ngoài việc gán `HRFORM_Gridview`/`HRFORM_GridControl`; không phải lỗi nhưng là trùng lặp có thể dọn dẹp.
- Không có constructor overload, không mở form phụ nào từ chính `frmBaoCaoLuong` (form tham số `frmPara` được mở từ bên trong `HRFORM.ThucHien`, không phải code của form này).
