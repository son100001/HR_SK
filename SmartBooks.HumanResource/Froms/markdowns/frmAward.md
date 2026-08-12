# frmAward – Khen thưởng

## Vị trí file
- `Froms/frmAward.vb`, `frmAward.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_Award` (`HRFORM_TableName`)
- Không khai báo `HRFORM_SaveStore`/`HRFORM_DeleteStore` tường minh trong Designer → lưu bằng `tvcn.LuuHoacXoaTuForm` (Insert/Update tự động theo `TableLayoutPanel2`), xóa dùng cơ chế mặc định của `HRFORM`.

## Mục đích
Khai báo các đợt **khen thưởng** cho nhân viên: loại thưởng (kèm số tiền định mức theo danh mục), ngày khen thưởng, lý do, số tiền thực tế, ghi chú.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu (`pnDuLieuNhap`) | `AwardType` | LookUpEdit | Loại thưởng (danh mục `HR_Category` có `CategoryFather='KhenThuong'`, load thủ công kèm cột `Amount`) |
| Nhập liệu (`pnDuLieuNhap`) | `AwardDate` | DateEdit | Ngày khen thưởng (mặc định = hôm nay khi Load) |
| Nhập liệu (`pnDuLieuNhap`) | `Reason` | RichTextBox | Lý do |
| Nhập liệu (`pnDuLieuNhap`) | `Amount` | TextEdit (mask numeric "n0") | Số tiền — tự động điền & khóa (ReadOnly) nếu loại thưởng đã có định mức sẵn, ngược lại cho nhập tay |
| Nhập liệu (`pnDuLieuNhap`) | `Remark` | RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách khen thưởng đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` (**không có `Handles`**, gắn thủ công bằng `AddHandler` trong `Load`) | Kiểm tra NOT NULL qua `tvcn.CheckErrorProvider` + `tvcn.GetColumns_ISNOTNULLABLE_OfTable`; gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)`; focus `Employee_ID`; gọi lại `Search()` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập trực tiếp trên panel, không popup Thêm/Sửa |

## Luồng xử lý

1. **`frmAward_Load`**
   - Đánh dấu (*) trường bắt buộc, `LoadGiaoDienTheoDieuKien()`.
   - **Tự xây dựng thủ công** `LookUpEdit.Properties` cho `AwardType` (không dùng overload chuẩn `tvcn.GetDataOnDropDownCategoryCodeName`) vì cần lấy kèm cột `Amount` từ `HR_Category where CategoryFather='KhenThuong'`; chỉ hiển thị cột `Name` trong popup (cột `Code`/`Amount` bị comment, không add vào `Properties.Columns`).
   - `tvcn.SearchEmployee(Employee_ID)`, `AwardDate.EditValue = Today`.
   - **Gắn thủ công bằng `AddHandler`**: `AwardType.EditValueChanged` và `btnSave.Click` — bắt buộc phải làm vậy vì 2 sub tương ứng (`AwardType_EditValueChanged`, `btnSave_Click`) **không có từ khóa `Handles`** trong khai báo.
   - Gọi `Search()`.

2. **`Search()`**
   - Build `exec [dbo].[sp_BangAward] '1900-1-1','<today>',1,'<Lan>',N'<UserName>',...,N'<EmID>'` — **khác các form còn lại**: truyền thêm `obj.UserName` làm tham số (không chỉ các tham số phân quyền cơ cấu tổ chức).
   - `Xem(...)`, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)**
   - Nếu grid có cột `AwardType`: gắn dropdown chọn nhanh trên grid (`tvcn.TaoDropDowTrenGrid`) từ cùng danh mục `KhenThuong`; **gắn lại thêm 1 lần nữa** `AddHandler AwardType.EditValueChanged` (xem Ghi chú kỹ thuật về rủi ro trùng lặp).
   - Chứa 1 khối code lớn bị comment nhằm ép định dạng số "n0" cho cột `Amount` trên grid (`BeginInvoke`) — hiện là dead code, không chạy.

4. **`UpdatePriceFromAwardType()` / `AwardType_EditValueChanged`**
   - Khi người dùng chọn 1 `AwardType`, đọc giá trị `Amount` gắn kèm dòng danh mục (qua `GetSelectedDataRow`/`GetColumnValue`).
   - Nếu có `Amount` hợp lệ: format số theo văn hóa `vi-VN`, gán vào control `Amount`, đặt `ReadOnly = True` và `Enabled = False` (khóa không cho sửa tay).
   - Nếu không có: mở khóa `Amount` (`ReadOnly = False`, `Enabled = True`, xóa giá trị).

5. **`Employee_ID_EditValueChanged`** — thân hàm bị comment, không tự động tìm kiếm khi đổi nhân viên.

6. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn).

## Ghi chú kỹ thuật
- `AwardType` không dùng overload chuẩn của `tvcn.GetDataOnDropDownCategoryCodeName` vì cần thêm cột `Amount` đi kèm danh mục — phải tự cấu hình `Properties.DataSource/ValueMember/DisplayMember/Columns` thủ công.
- **`btnSave_Click` và `AwardType_EditValueChanged` không có `Handles`** trong khai báo, phải gắn bằng `AddHandler` trong `Load`. Đáng chú ý: `AwardType.EditValueChanged` còn được `AddHandler` thêm **1 lần nữa** trong `AfterViewForm()` (chạy lại mỗi khi `Xem()` load lại dữ liệu) → tiềm ẩn rủi ro **gắn handler trùng lặp** nhiều lần qua các lần Search/refresh, khiến `UpdatePriceFromAwardType()` có thể chạy nhiều lần cho 1 lần đổi giá trị.
- Có cơ chế tự động đồng bộ **Số tiền theo Loại thưởng** đã chọn: nếu danh mục có định mức sẵn thì khóa (readonly) trường `Amount`, ngược lại cho nhập tay.
- `AfterViewForm()` còn chứa khối code lớn bị comment (định dạng số "n0" cho cột `Amount` trên grid) — dead code chưa dọn dẹp.
- `Search()` truyền thêm `obj.UserName` vào SP `sp_BangAward`, khác các form còn lại trong khảo sát này (chỉ truyền tham số phân quyền cơ cấu tổ chức + Employee_ID).
- Không override `BeforeSave`/`BeforeDelete`, không mở form phụ nào khác, không có constructor overload.
