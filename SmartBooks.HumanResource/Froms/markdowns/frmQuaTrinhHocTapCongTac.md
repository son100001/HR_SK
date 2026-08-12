# frmQuaTrinhHocTapCongTac – Quá trình học tập/công tác

## Vị trí file
- `Froms/frmQuaTrinhHocTapCongTac.vb`, `frmQuaTrinhHocTapCongTac.designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_QuaTrinhHocTapCongTac` (`HRFORM_TableName`)

## Mục đích
Khai báo/quản lý **lịch sử quá trình học tập và công tác** của từng nhân viên (ví dụ: các mốc học vấn, các đơn vị công tác trước đây...), gồm loại quá trình, khoảng thời gian (từ ngày – đến ngày), mô tả và ghi chú. Người dùng chọn nhân viên, nhập trực tiếp trên panel rồi lưu; danh sách các quá trình đã khai báo hiển thị trên grid bên dưới.

## Bố cục giao diện
Form gồm 1 tab "General" chứa `TableLayoutPanel2` chia 3 vùng ngang + 1 grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Chọn/gõ mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Thực hiện tìm kiếm thủ công |
| Nhập liệu (`pnDuLieuNhap`) | `lblLoaiQuaTrinh` + `LoaiQuaTrinh` | Label + LookUpEdit (category `LoaiQuaTrinh`) | Loại quá trình (học tập/công tác...) |
| Nhập liệu (`pnDuLieuNhap`) | `lblfromdate` + `fromdate` | Label + DateEdit | Từ ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lbltodate` + `todate` | Label + DateEdit | Đến ngày |
| Nhập liệu (`pnDuLieuNhap`) | `lblDescription` + `Description` | Label + RichTextBox | Mô tả |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách các quá trình học tập/công tác đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` để lọc lại danh sách theo `Employee_ID` đang chọn |
| **Lưu** (`btnSave`) | `btnSave_Click` | 1) Kiểm tra các trường bắt buộc trên `TableLayoutPanel2` (`tvcn.CheckErrorProvider` theo `GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)`), nếu thiếu thì dừng và báo lỗi qua `ErrorProvider1`. 2) Gọi `tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)` để Insert/Update trực tiếp từ giá trị các control trên panel. 3) Focus lại vào `Employee_ID`. 4) Gọi lại `Search()` để refresh grid |
| Các nút chuẩn của `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → ẩn nút Thêm/Sửa dạng popup vì nhập liệu thực hiện trực tiếp trên panel; các nút Xóa/Xuất Excel/F5... vẫn hoạt động theo cơ chế chung của `HRFORM` |

## Luồng xử lý chính

1. **`frmQuaTrinhHocTapCongTac_Load`**
   - Đánh dấu (*) các trường bắt buộc trên `TableLayoutPanel2` theo cấu trúc bảng `HR_QuaTrinhHocTapCongTac` (`tvcn.ThemDauSaoChoTruongBuocNhap`).
   - Nạp danh mục `LoaiQuaTrinh` (category `LoaiQuaTrinh`) cho LookUpEdit qua `tvcn.GetDataOnDropDownCategoryCodeName`.
   - `LoadGiaoDienTheoDieuKien()` – bật/tắt nút theo quyền người dùng (`QuyenHRFORM`).
   - `tvcn.SearchEmployee(Employee_ID)` – nạp danh sách nhân viên cho LookUpEdit tìm kiếm.
   - Gọi `Search()` để hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Lấy `Employee_ID.EditValue` (nếu có).
   - Build: `exec [dbo].[sp_BangQuaTrinhHocTapCongTac] 1,'<Lan>',N'<UserName>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>',N'<EmployeeID>'`
     (tham số thứ 3 truyền `obj.UserName` chứ không phải `Lan` như các form khác trong `BaoHiem` – khác biệt nhỏ so với mẫu chuẩn).
   - Gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` đổ dữ liệu lên `GridControl1`, lưu `HRFORM_QueryView = QR`.

3. **`AfterViewForm()` (override)** – với cột `LoaiQuaTrinh` trên grid, tự động gắn dropdown chọn nhanh (`tvcn.TaoDropDowTrenGrid`) lấy dữ liệu từ `HR_Category where CategoryFather='LoaiQuaTrinh'` — cho phép sửa nhanh cột này trực tiếp trên grid.

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng `Search()` bị comment → đổi nhân viên không tự động tìm kiếm lại, người dùng phải bấm nút **Tìm**.

5. **`GridControl1_KeyUp`** – ủy quyền phím tắt (Ctrl+S/D/F/Q, F5) cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM`.

## Ghi chú kỹ thuật
- Theo đúng pattern chuẩn của `HRFORM`: nhập liệu trực tiếp trên `TableLayoutPanel2` + `tvcn.LuuHoacXoaTuForm`, tương tự `frmInsurance` trong module `BaoHiem`.
- Không có phân trang riêng; lọc dữ liệu dựa vào quyền xem theo cơ cấu tổ chức (`obj.PARA_...`) được set sẵn khi đăng nhập/chọn phòng ban, cộng thêm lọc theo `Employee_ID` nếu người dùng chọn.
