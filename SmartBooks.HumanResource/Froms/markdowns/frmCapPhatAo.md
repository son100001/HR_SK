# frmCapPhatAo – Cấp phát đồng phục (áo)

## Vị trí file
- `Froms/frmCapPhatAo.vb`, `frmCapPhatAo.Designer.vb`, `frmCapPhatAo.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_CapPhatAo` (`HRFORM_TableName`)
- Stored procedure Lưu: `usp_InsertUpdateHR_CapPhatAo` (gọi trực tiếp trong `btnSave_Click`, không set qua `HRFORM_SaveStore`)
- Stored procedure Xóa: `usp_DeleteHR_CapPhatAo` (`HRFORM_DeleteStore`)

## Mục đích
Quản lý việc **cấp phát đồng phục (áo)** cho nhân viên: size áo, số lượng, màu sắc, ngày cấp, ngày trả (nếu là đồng phục mượn/thu hồi), ghi chú. Mỗi lần cấp phát là 1 dòng dữ liệu gắn với 1 nhân viên.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblSize` + `Size` | Label + LookUpEdit | Size áo (danh mục `"SizeAo"`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblColor` + `Color` | Label + TextBox | Màu sắc |
| Nhập liệu (`pnDuLieuNhap`) | `lblNumber` + `Number` | Label + TextBox | Số lượng |
| Nhập liệu (`pnDuLieuNhap`) | `lblDateIssued` + `DateIssued` | Label + DateEdit | Ngày cấp (mặc định = hôm nay khi mở form) |
| Nhập liệu (`pnDuLieuNhap`) | `lblReturnDate`(*) + `ReturnDate` | Label + DateEdit | Ngày trả |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách các lần cấp phát áo đã khai báo |

(*) Label hiển thị "Ngày trả" cạnh `ReturnDate`.

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc lại danh sách theo `Employee_ID` và cơ cấu tổ chức |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_CapPhatAo]", TableLayoutPanel2, ErrorProvider1)` Insert/Update trực tiếp từ giá trị control trên `TableLayoutPanel2`; nếu thành công gọi lại `Search()`; sau đó focus `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel |

## Luồng xử lý

1. **`frmCapPhatAo_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc.
   - `tvcn.GetDataOnDropDownCategoryCodeName(Size, "SizeAo")` – nạp danh mục size áo.
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên cho LookUpEdit tìm kiếm.
   - `DateIssued.EditValue = Today` – mặc định ngày cấp là hôm nay.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - Build: `exec [dbo].[sp_BangCapPhatAo] '1900-1-1','<Today+100 ngày>',1,'<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'` (đầy đủ tham số phân quyền theo cơ cấu tổ chức từ `obj.PARA_...`, khoảng thời gian lọc rất rộng 1900 → hôm nay+100 ngày, tức lấy toàn bộ lịch sử cấp phát).
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng `Search()` bị comment, không tự tìm khi đổi nhân viên.

4. **`GridControl1_KeyUp`** – ủy quyền toàn bộ phím tắt chuẩn (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp`.

## Ghi chú kỹ thuật
- Form theo khuôn mẫu kiểu (a): nhập trực tiếp trên panel + `tvcn.SaveByStore` gọi thẳng tên stored procedure (không set `HRFORM_SaveStore` trong Designer, mà truyền chuỗi tên SP trực tiếp trong code – khác `frmBankAccountOfEmployee` có set sẵn `HRFORM_SaveStore`). `HRFORM_SaveStore` vẫn được gán trong Designer (`usp_InsertUpdateHR_CapPhatAo`) nhưng code không dùng biến này mà hard-code lại chuỗi tên SP trong `btnSave_Click`.
- `Number` (số lượng) và `Color` (màu sắc) là `TextBox` chuỗi tự do, không có kiểm tra kiểu số/định dạng ở tầng UI.
- Không override `BeforeSave()`/`AfterViewForm()` – không có xử lý grid tùy biến nào khác ngoài CRUD chuẩn.
