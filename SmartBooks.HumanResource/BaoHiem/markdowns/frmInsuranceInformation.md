# frmInsuranceInformation – Thông tin Bảo hiểm (tổng hợp)

## Vị trí file
- `BaoHiem/frmInsuranceInformation.vb`, `frmInsuranceInformation.Designer.vb`, `frmInsuranceInformation.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: chuyển đổi động giữa `HR_Insurance` và `HR_TheBHYT` tùy tab đang chọn (form không có bảng cố định vì đóng vai trò "cửa sổ tổng hợp")

## Mục đích
Là màn hình **xem danh sách tổng hợp** cho cả 2 nghiệp vụ Sổ BHXH và Thẻ BHYT trong cùng 1 cửa sổ, thay vì phải mở 2 form riêng (`frmInsurance`, `frmTheBHYT`). Việc thêm/sửa được thực hiện qua **form popup** riêng cho từng loại.

## Bố cục giao diện
Chỉ có 1 `XtraTabControl1` với 2 tab, không có panel nhập liệu:

| Tab | Name | Nội dung |
|---|---|---|
| "Sổ BH" | `InsuranceBook` | `GridControl1` / `GridView1` – danh sách Sổ bảo hiểm (`HR_Insurance`) |
| "Thẻ BHYT" | `InsuranceCard` | `GridControl2` / `GridView2` – danh sách Thẻ BHYT (`HR_TheBHYT`) |

## Danh sách nút & tác dụng
Form không tự định nghĩa nút riêng; toàn bộ thao tác dùng **PanelButton chuẩn của `HRFORM`**, nhưng ngữ cảnh (bảng dữ liệu, popup nhập liệu) thay đổi theo tab đang active:

| Nút (kế thừa HRFORM) | Tác dụng trên tab đang chọn |
|---|---|
| **Thêm** (`btnAdd`) | Mở popup `frmSoBaoHiem_Nhap` (nếu đang ở tab "Sổ BH") hoặc `frmTheBHYT_Nhap` (nếu đang ở tab "Thẻ BHYT") để nhập bản ghi mới, qua `tvcn.AddNewOrEdit(True, ...)` |
| **Sửa** (`btnEdit`) | Mở cùng popup tương ứng ở chế độ sửa dòng đang chọn trên grid, qua `tvcn.AddNewOrEdit(False, ...)` |
| **Xóa** (`btnRemove`) | Xóa (các) dòng đang chọn trên grid của tab hiện hành |
| **Lưu** (`btnLuu`) | Lưu thay đổi trực tiếp trên grid (nếu có sửa inline) |
| **Xuất Excel / Import Excel / Mẫu / F5...** | Hoạt động theo cơ chế chuẩn của `HRFORM`, áp dụng cho grid của tab đang chọn |

## Luồng xử lý

1. **`frmInsuranceInformation_Load`** – không có logic tùy biến (dòng gọi `LoadGiaoDienTheoDieuKien()` bị comment), giao diện dùng mặc định từ Designer.

2. **`XtraTabControl1_SelectedPageChanged`** (khi người dùng đổi tab) – đây là logic quan trọng nhất của form:
   - Nếu chuyển sang tab **"InsuranceBook" (Sổ BH)**:
     - `HRFORM_TableName = "HR_Insurance"`
     - `HRFORM_GridControl = GridControl1`, `HRFORM_Gridview = GridView1`
     - `HRFORM_InputForm = "frmSoBaoHiem_Nhap"` (form popup dùng khi Thêm/Sửa)
   - Nếu chuyển sang tab **"InsuranceCard" (Thẻ BHYT)**:
     - `HRFORM_TableName = "HR_TheBHYT"`
     - `HRFORM_GridControl = GridControl2`, `HRFORM_Gridview = GridView2`
     - `HRFORM_InputForm = "frmTheBHYT_Nhap"`
   - Sau khi gán lại context, gọi `LoadGiaoDienTheoDieuKien()` để cập nhật lại trạng thái Enable/Visible của các nút PanelButton theo bảng dữ liệu + quyền hiện tại.

3. **`Gridex1_KeyUp` / `Gridex2_KeyUp`** – ủy quyền phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp`, áp dụng riêng cho từng grid tương ứng.

## Ghi chú kỹ thuật
- Đây là ví dụ điển hình của việc **1 form HRFORM dùng chung PanelButton nhưng đổi ngữ cảnh bảng dữ liệu/grid/form-nhập động** theo tab, thay vì tạo 2 form riêng biệt.
- Khác với `frmInsurance`/`frmTheBHYT` (nhập liệu trực tiếp trên panel, không có form popup), ở đây việc Thêm/Sửa được ủy quyền hoàn toàn cho `HRFORM_InputForm` (`frmSoBaoHiem_Nhap`, `frmTheBHYT_Nhap`) – các form input này không nằm trong thư mục `BaoHiem/` hiện tại (cần tra cứu thêm nếu cần chi tiết cấu trúc trường nhập của popup).
