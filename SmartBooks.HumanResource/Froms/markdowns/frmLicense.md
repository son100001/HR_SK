# frmLicense – Chứng chỉ / Bằng cấp nhân viên

## Vị trí file
- `Froms/frmLicense.vb`, `frmLicense.Designer.vb`, `frmLicense.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_LicenseOfEmployee` (`HRFORM_TableName = "HR_LicenseOfEmployee"`)

## Mục đích
Quản lý **bằng cấp/chứng chỉ** của nhân viên: loại bằng cấp, mã bằng cấp, ngày cấp, thời hạn hiệu lực, nơi/giấy chứng nhận ban hành. Người dùng tìm nhân viên, xem/nhập trực tiếp trên panel, lưu lại; danh sách bằng cấp đã khai báo hiển thị trên grid.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên để lọc |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblLicenseType` + `LicenseType` | Label + LookUpEdit | Loại bằng cấp (đổ dữ liệu từ `HR_Category`, `CategoryFather='BangCap'`) |
| Nhập liệu (`pnDuLieuNhap`) | `lblLicenseID` + `LicenseID` | Label + RichTextBox | Mã bằng cấp |
| Nhập liệu (`pnDuLieuNhap`) | `lblValidFromdate` + `ValidFromdate` | Label + DateEdit | Hiệu lực từ ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lblValidTodate` + `ValidTodate` | Label + DateEdit | Hiệu lực đến ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lblIssuedDate` + `IssuedDate` | Label + DateEdit | Ngày cấp – mặc định = hôm nay khi Load |
| Nhập liệu (`pnDuLieuNhap`) | `lblLicenseDoc` + `LicenseDoc` | Label + RichTextBox | Giấy chứng nhận |
| Nhập liệu (`pnDuLieuNhap`) | `lblIssuedAt` + `IssuedAt` | Label + RichTextBox | Ban hành tại |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách bằng cấp/chứng chỉ đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi lại `Search()` để lọc danh sách theo `Employee_ID` đang chọn |
| **Lưu** (`btnSave`) | `btnSave_Click` | Kiểm tra bắt buộc nhập (`tvcn.CheckErrorProvider`) → nếu hợp lệ, gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update → focus lại `Employee_ID` → gọi `Search()` refresh grid |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → không dùng popup Thêm/Sửa, nhập trực tiếp trên panel |

## Luồng xử lý

1. **`frmLicense_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt control theo quyền `QuyenHRFORM`.
   - `tvcn.GetDataOnDropDownCategoryCodeName(LicenseType, "BangCap")` – nạp danh mục "Loại bằng cấp".
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên cho LookUpEdit tìm kiếm (form này **có** gọi, khác với `frmTrainingRecord`/`frmHealthCheck`/`frmDiseasesRecord`/`frmSurgeryHistory` không thấy gọi hàm này trong `Load`).
   - `IssuedDate.DateTime = Today` – mặc định ngày cấp là hôm nay.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có) làm `EmID`.
   - Build: `exec [dbo].[sp_BangLicenseOfEmployee] '1900-1-1','<Today>',1,'<Lan>',N'<UserName>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmID>'`
     (khoảng lọc ngày cố định từ 1900-01-01 đến **hôm nay**, khác với `frmTrainingRecord`/`frmHealthCheck` dùng mốc tương lai `Today + N năm`).
   - Gọi `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()`** (override)
   - Nếu grid có cột `LicenseType` thì gắn dropdown cho cột này, dữ liệu lấy từ `HR_Category where CategoryFather='BangCap'` (cột tên hiển thị build bằng `"Name" + obj.Lan`, tức `NameVN`/`NameEN`/`NameKR` tùy ngôn ngữ đang chọn — khác cách viết `IIf(...)` dùng ở `frmTrainingRecord`/`frmDiseasesRecord`/`frmSurgeryHistory` nhưng cùng bản chất).

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng gọi `Search()` bị **comment**, đổi nhân viên không tự động lọc lại; phải bấm nút **Tìm**.

5. **`GridControl1_KeyUp`** – có định nghĩa hàm ủy quyền cho `Gridview_KeyUp`, **nhưng không có mệnh đề `Handles GridControl1.KeyUp`** (khác với 4 form còn lại trong nhóm). Do đó hàm này thực chất **không được gắn vào sự kiện KeyUp của grid** trong code hiện tại → các phím tắt chuẩn (Ctrl+S/D/F/Q, F5) khi focus trên `GridControl1` có thể không hoạt động qua đường này (cần kiểm tra lại nếu muốn sửa).

## Ghi chú kỹ thuật
- Việc lưu dùng chung hàm `tvcn.LuuHoacXoaTuForm`, tự động Insert nếu bản ghi mới, Update nếu đã tồn tại.
- Là form duy nhất trong nhóm gọi `tvcn.SearchEmployee(Employee_ID)` khi Load để nạp sẵn danh sách nhân viên cho ô tìm kiếm.
- Là form duy nhất trong nhóm có sự cố tiềm ẩn: sự kiện `GridControl1_KeyUp` không được `Handles` gắn vào control tương ứng, nên phím tắt chuẩn của `HRFORM` có thể không hoạt động trên form này như mong đợi.
- So với `frmTrainingRecord`/`frmHealthCheck` (khoảng lọc ngày trong `Search()` chạy đến tương lai), `frmLicense` chỉ lọc đến ngày hiện tại — nghĩa là các bằng cấp có ngày liên quan lớn hơn hôm nay (nếu có) sẽ không xuất hiện trong danh sách tìm kiếm mặc định.
