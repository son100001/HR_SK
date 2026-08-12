# frmMucLuong – Mức lương (thang bảng lương theo Nhóm lương / Bậc lương)

## Vị trí file
- `Payroll/frmMucLuong.vb`, `frmMucLuong.designer.vb`, `frmMucLuong.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_MucLuong` (`HRFORM_TableName`)
- Stored procedure Lưu/Xóa: `usp_InsertUpdateHR_MucLuong` (`HRFORM_SaveStore`) / `usp_DeleteHR_MucLuong` (`HRFORM_DeleteStore`)

## Mục đích
Đây là **danh mục mức lương (thang bảng lương)** chung của công ty — không gắn với từng nhân viên cụ thể, mà khai báo số tiền tương ứng với từng cặp **Nhóm lương** (`SalaryGroup`) + **Bậc lương** (`SalaryStep`), có hiệu lực theo khoảng thời gian (`FromDate`–`ToDate`). Đây chính là bảng "thang bảng lương" dùng làm cơ sở tra cứu khi tính lương theo nhóm/bậc cho nhân viên (khác với `frmLuongCoDinh` là khai báo số tiền lương cố định **theo từng nhân viên**).

## Bố cục giao diện
Tab "General", panel nhập (`TableLayoutPanel2`, chỉ có 2 vùng — **không có vùng tìm kiếm `pnSearch`**) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Nhập liệu (`pnDuLieuNhap`) | `lblSalaryGroup` + `SalaryGroup` | Label + TextBox | Mã nhóm lương |
| Nhập liệu (`pnDuLieuNhap`) | `lblSalaryStep` + `SalaryStep` | Label + TextBox | Mã bậc lương |
| Nhập liệu (`pnDuLieuNhap`) | `lblFromDate` + `FromDate` | Label + DateEdit | Từ ngày áp dụng (mặc định = hôm nay) |
| Nhập liệu (`pnDuLieuNhap`) | `cbToDate` (CheckBox) + `lblToDate` + `ToDate` | CheckBox + Label + DateEdit | Bật `cbToDate` mới cho phép nhập `ToDate`; nếu tắt thì `ToDate.Enabled = False` và giá trị = Nothing (không giới hạn) |
| Nhập liệu (`pnDuLieuNhap`) | `lblAmount` + `Amount` | Label + TextBox | Số tiền tương ứng nhóm/bậc lương (tự format số khi gõ) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách toàn bộ mức lương theo nhóm/bậc đã khai báo |

**Khác biệt so với 3 form còn lại trong đợt khảo sát**: không có `Employee_ID`, không có `pnSearch`/nút **Tìm** — vì đây là danh mục dùng chung, không lọc theo nhân viên hay theo cơ cấu tổ chức.

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Lưu** (`btnSave`) | `btnSave_Click` | `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_MucLuong]", TableLayoutPanel2, ErrorProvider1)` — kiểm tra quyền + trường bắt buộc, Insert/Update; nếu thành công gọi lại `Search()`. Sau đó focus vào `SalaryGroup` (khác các form khác focus lại `Employee_ID`, vì form này không có trường nhân viên) |
| Các nút chuẩn khác (Thêm/Sửa/Thực hiện/chọn mẫu in) | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_ThucHien = False`, `HRFORM_VisibleControl_cbbReport = False` → ẩn hết, chỉ còn Xóa/Xuất Excel/F5... hoạt động theo cơ chế chung |

## Luồng xử lý

1. **`frmMucLuong_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2`.
   - `FromDate.EditValue = Today`.
   - `LoadGiaoDienTheoDieuKien()`.
   - Gọi `Search()` ngay để hiển thị dữ liệu ban đầu (không cần bấm nút Tìm vì không có nút này).

2. **`Search()`**
   - Câu lệnh: `select * from HR_MucLuong` — **không** dùng stored procedure với tham số phân quyền cơ cấu tổ chức như các form khác trong module (`sp_BangThamSoLuong`, `sp_BangLuongCoDinh`...), cũng không lọc theo ngày hiệu lực hay bất kỳ điều kiện nào — luôn tải **toàn bộ** bảng `HR_MucLuong`.
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.
   - Vì không có nút **Tìm**/panel tìm kiếm, `Search()` chỉ được gọi lại tự động sau khi Lưu thành công (`btnSave_Click`) hoặc khi form Load — người dùng không có cách chủ động lọc lại từ giao diện (ngoài F5 tải lại của `HRFORM`, vẫn dùng lại cùng câu `select *`).

3. **`cbToDate_CheckedChanged`** — bật/tắt cho phép nhập ngày kết thúc, logic giống hệt `cbtodate_CheckedChanged` của `frmLuongCoDinh`.

4. **`Amount_TextChanged`** — tự động format số khi gõ: `tvcn.AmountFormat(Amount)`.

5. **`Gridex1_KeyUp`** — ủy quyền phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` của `HRFORM`.

## Ghi chú kỹ thuật
- Là form **danh mục dùng chung** (không có khái niệm "theo nhân viên"), khác biệt rõ với 3 form còn lại trong đợt khảo sát này — không có `Employee_ID`, không có `pnSearch`, không gọi `tvcn.SearchEmployee`.
- `Search()` dùng câu `select * from HR_MucLuong` trực tiếp thay vì gọi qua stored procedure như hầu hết form khác trong hệ thống — không áp dụng logic phân quyền theo cơ cấu tổ chức (`obj.PARA_...`) vì dữ liệu là danh mục chung, không thuộc về nhân viên/phòng ban nào cụ thể. Cũng đồng nghĩa **không có phân trang hay giới hạn số dòng** — nếu bảng `HR_MucLuong` lớn, việc tải toàn bộ mỗi lần Load/Lưu có thể ảnh hưởng hiệu năng, nhưng do bản chất là thang bảng lương (số dòng thường nhỏ, hữu hạn theo số nhóm × bậc lương) nên rủi ro thấp trong thực tế.
- Có liên quan tới form `frmMucLuongNhanVien` (cùng thư mục `Payroll/`, không thuộc phạm vi khảo sát lần này) — nhiều khả năng đó là form gán mức lương nhóm/bậc (`HR_MucLuong`) cho từng nhân viên cụ thể; nên tra cứu thêm nếu cần hiểu trọn luồng "khai báo thang bảng lương → gán cho nhân viên".
- Trường `SalaryGroup`/`SalaryStep` là `TextBox` tự do (không phải LookUpEdit tra danh mục) — người nhập gõ tay mã nhóm/bậc, không có validate chọn từ danh sách có sẵn ngay trên form này.
