# frmFamily – Gia đình nhân viên

## Vị trí file
- `Froms/frmFamily.vb`, `frmFamily.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `SmartBooks_Employee_Family` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateSmartBooks_Employee_Family"`
- `HRFORM_DeleteStore = "usp_DeleteSmartBooks_Employee_Family"`
- `HRFORM_VisibleControl_GetTemplate = False` (ẩn nút "Lấy mẫu" import Excel)

## Mục đích
Quản lý **thông tin người thân/gia đình** của nhân viên (phục vụ đăng ký giảm trừ gia cảnh, khai báo BHXH...): họ tên, quan hệ, ngày sinh, giới tính, thông tin CMT/CCCD, địa chỉ theo giấy khai sinh (tỉnh/quận/phường), mã số thuế, quốc tịch, khoảng thời gian phụ thuộc (giảm trừ gia cảnh theo tháng), ngày bắt đầu chế độ baby care, ngày mất, tình trạng nộp giấy tờ.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu | `RelatedName` | TextBox | Họ tên người thân |
| Nhập liệu | `RelatedType` | LookUpEdit | Quan hệ (danh mục `QuanHeGiaDinh`) |
| Nhập liệu | `BirthDate` | DateEdit | Ngày sinh |
| Nhập liệu | `Sex` | LookUpEdit | Giới tính (danh mục `Sex`) |
| Nhập liệu | `DependFromMonth` / `DependToMonth` | DateEdit (mask `MM/yyyy`) | Phụ thuộc từ tháng / đến tháng |
| Nhập liệu | `btn18Tuoi` | Button ("18 tuổi") | Tự tính `DependToMonth = BirthDate + 18 năm` |
| Nhập liệu | `isDaNopGiay` | CheckBox | Đã nộp giấy |
| Nhập liệu | `QuocTich` | LookUpEdit | Quốc tịch (từ `HR_Country`) |
| Nhập liệu | `ID_Number` / `ID_date` / `ID_place` | TextBox / DateEdit / TextBox | Số / Ngày cấp / Nơi cấp CMT |
| Nhập liệu | `Address`, `Occupation`, `Tel`, `MaSoThue` | TextBox | Địa chỉ, Nghề nghiệp, Điện thoại, Mã số thuế |
| Nhập liệu | `GKS_So`, `GKS_QuyenSo` | TextBox | Số / Quyển số giấy khai sinh |
| Nhập liệu | `GKS_TinhTP`, `GKS_QuanHuyen`, `GKS_PhuongXa` | LookUpEdit | Tỉnh/TP, Quận/Huyện, Phường/Xã theo giấy khai sinh (từ `HR_TinhThanhPho`/`HR_QuanHuyen`/`HR_PhuongXa`, khóa ghép dạng `Tinh_Huyen_Xa`) |
| Nhập liệu | `BabyCareStartDate` | DateEdit | Ngày bắt đầu baby care |
| Nhập liệu | `DateOfDeath` | DateEdit | Ngày mất |
| Nhập liệu | `Remark` | RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi (luôn **thêm mới**, xem Ghi chú kỹ thuật) |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách người thân đã khai báo |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Chặn nếu `QuyenHRFORM = "View"`; kiểm tra NOT NULL qua `tvcn.CheckErrorProvider`; hỏi xác nhận Yes/No; nếu Yes gọi hàm private `Save(0, ...)` (ID luôn = 0) để **Insert** qua `usp_InsertUpdateSmartBooks_Employee_Family`; nếu thành công gọi `Search()`; **sau đó luôn** gọi `tvcn.ClearTextInControlOnForm(TableLayoutPanel2)` và focus `Employee_ID` (xem Ghi chú kỹ thuật) |
| **18 tuổi** (`btn18Tuoi`) | `btn18Tuoi_Click` | Nếu `DependFromMonth` đã có giá trị: gán `DependToMonth = BirthDate + 18 năm`; ngược lại cảnh báo yêu cầu nhập `DependFromMonth` trước — **nút này bị `Enabled = False` cố định trong Designer, không có code nào bật lại**, nên hiện không thể bấm được |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_GetTemplate = False` |

## Luồng xử lý

1. **`frmFamily_Load`**
   - Đánh dấu (*) trường bắt buộc.
   - Nạp `RelatedType` (danh mục `QuanHeGiaDinh`), `Sex` (danh mục `Sex`) qua overload ngắn.
   - Tự build DataTable cho `GKS_TinhTP`/`GKS_QuanHuyen`/`GKS_PhuongXa` (khóa nối chuỗi `MaTinhThanhPho[+_+MaQuanHuyen[+_+MaPhuongXa]]`) và `QuocTich` (từ `HR_Country`).
   - `tvcn.SearchEmployee(Employee_ID)`, `LoadGiaoDienTheoDieuKien()`, gọi `Search()`.

2. **`Search()`**
   - Build `exec [dbo].[sp_BangThongTinGiaDinh] '1900-1-1','<today>',1,N'<Factory>',...,N'<EmID>'` (không truyền tham số `Lan` như các form khác).
   - `Xem(...)`, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)** — gắn dropdown chọn nhanh trên cột grid `RelatedType` (`tvcn.TaoDropDowTrenGrid`) từ danh mục `QuanHeGiaDinh`.

4. **`Save(ID, Employee_ID, RelatedName, ...)` (private, ~24 tham số vị trí)**
   - Build và thực thi `exec usp_InsertUpdateSmartBooks_Employee_Family` với toàn bộ giá trị control; các trường ngày có thể rỗng (`ID_date`, `DependFromMonth`, `DependToMonth`, `BabyCareStartDate`, `DateOfDeath`) được kiểm tra `.Year = 1` để quyết định truyền `null` hay giá trị ngày cụ thể (do `DateTime` mặc định chưa gán = năm 1).
   - Nếu SP trả lỗi → hiển thị `MessageBox` lỗi, trả `False`; nếu thành công → thông báo **"Nhập thành công!"** (chuỗi tiếng Việt hardcode, không qua `tvcn.GetLanguagesTranslated`), trả `True`.

5. **`Employee_ID_EditValueChanged`** — thân hàm bị comment, không tự động tìm kiếm khi đổi nhân viên.

6. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn).

## Ghi chú kỹ thuật
- Không dùng `tvcn.LuuHoacXoaTuForm`/`tvcn.SaveByStore` chuẩn để lưu; tự viết hàm `Save(...)` gọi trực tiếp `usp_InsertUpdateSmartBooks_Employee_Family` với **`ID` luôn truyền `0`** → nút Lưu trên form này **chỉ dùng để Thêm mới** người thân qua panel, không hỗ trợ sửa lại 1 dòng đã có qua panel (muốn sửa phải làm trực tiếp trên grid nếu được cấp quyền).
- Sau khi bấm Lưu, form **luôn** gọi `tvcn.ClearTextInControlOnForm(TableLayoutPanel2)` để xóa trắng input — kể cả khi người dùng chọn "Không" ở hộp thoại xác nhận hoặc khi `Save()` trả về lỗi — có thể khiến mất dữ liệu vừa nhập nếu chưa lưu thành công.
- Nút **"18 tuổi"** bị `Enabled = False` cố định trong Designer và không có đoạn code nào set lại `True` → tính năng tự tính "Phụ thuộc đến tháng theo 18 tuổi" hiện **không thể sử dụng** trên giao diện.
- 3 LookUpEdit `GKS_TinhTP`/`GKS_QuanHuyen`/`GKS_PhuongXa` nạp **toàn bộ** danh mục tỉnh/huyện/xã cùng lúc, **không lọc theo cấp cha** (không cascade filter tỉnh → huyện → xã).
- Cùng với `frmTerminationAsignment`, đây là 1 trong 2 form set `HRFORM_VisibleControl_GetTemplate = False` để ẩn nút "Lấy mẫu" import Excel.
- Thông báo dùng chuỗi tiếng Việt hardcode ("Nhập thành công!", "Bạn có thực sự muốn lưu?"...) thay vì `tvcn.GetLanguagesTranslated` như một số form khác (`frmChuyenViTri`) — không nhất quán về đa ngôn ngữ.
- Không override `BeforeSave`/`BeforeDelete`, không mở form phụ nào khác, không có constructor overload.
