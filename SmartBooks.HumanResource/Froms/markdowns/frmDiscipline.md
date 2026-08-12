# frmDiscipline – Kỷ luật

## Vị trí file
- `Froms/frmDiscipline.vb`, `frmDiscipline.Designer.vb`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_Discipline` (`HRFORM_TableName`)
- `HRFORM_SaveStore = "usp_InsertUpdateHR_Discipline"` (không khai báo `HRFORM_DeleteStore` tường minh)

## Mục đích
Lập **biên bản kỷ luật/vi phạm** cho nhân viên: hành vi vi phạm, các mốc ngày liên quan (ngày lập biên bản, ngày vi phạm, ngày kết thúc biên bản, ngày tăng lương liên quan), lý do, đơn vị xử lý, ghi chú.

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `Employee_ID` + `btnSearch` | LookUpEdit + SimpleButton | Mã nhân viên / Tìm |
| Nhập liệu (`pnDuLieuNhap`) | `BehaviorCode` | LookUpEdit | Hành vi (danh mục `ViPhamKyLuat`) |
| Nhập liệu (`pnDuLieuNhap`) | `DisciplineBegin` | DateEdit | Ngày lập BB |
| Nhập liệu (`pnDuLieuNhap`) | `ViolationDate` | DateEdit | Ngày vi phạm |
| Nhập liệu (`pnDuLieuNhap`) | `Reason` | RichTextBox | Lý do |
| Nhập liệu (`pnDuLieuNhap`) | `Remark` | RichTextBox | Ghi chú |
| Ẩn (`Visible=False`) | `DisciplineEnd`, `SalaryIncreaseDate`, `ProcAsign` (+ label tương ứng) | DateEdit / DateEdit / TextBox | Ngày kết thúc BB, Ngày tăng lương, Đơn vị xử lý — vẫn tồn tại trong `TableLayoutPanel2` (vẫn validate/lưu) nhưng **ẩn khỏi giao diện**, tự sinh giá trị qua code |
| Lưu (`pnNhap`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1`/`GridView1` | DevExpress Grid | Danh sách biên bản kỷ luật |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Gọi `tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_Discipline]", TableLayoutPanel2, ErrorProvider1)` — lưu ý: truyền **`TableLayoutPanel2`** (không phải toàn bộ `XtraTabControl1` như `frmBaoCaoBaoHiem`); nếu thành công gọi lại `Search()`; luôn focus `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập trực tiếp trên panel |

## Luồng xử lý

1. **`frmDiscipline_Load`**
   - Đánh dấu (*) trường bắt buộc, `LoadGiaoDienTheoDieuKien()`.
   - Nạp `BehaviorCode` bằng overload ngắn gọn `tvcn.GetDataOnDropDownCategoryCodeName(BehaviorCode, "ViPhamKyLuat")` (truyền thẳng tên category thay vì tự build DataTable như `frmChuyenViTri`/`frmAward`).
   - `tvcn.SearchEmployee(Employee_ID)`, gọi `Search()`.

2. **`Search()`**
   - Build `exec [dbo].[sp_BangViPhamKyLuat] '1900-1-1','<today+1 tháng>',1,'<Lan>',...,N'<EmID>'`.
   - `Xem(...)`, lưu `HRFORM_QueryView`.

3. **`AfterViewForm()` (override)** — gắn dropdown chọn nhanh trên cột grid `BehaviorCode` (`tvcn.TaoDropDowTrenGrid`) từ danh mục `ViPhamKyLuat`. Còn 1 dòng code cũ liên quan chỉnh độ rộng cột `Reason` trên `Gridex1` (Janus GridEX) bị comment — dead code từ thời chưa chuyển sang DevExpress.

4. **`DisciplineBegin_ValueChanged`** (`Handles DisciplineBegin.EditValueChanged`) → gọi `AutoGenDisciplineEnd()`: **tự động sao chép** giá trị `DisciplineBegin` vào `DisciplineEnd`, `ViolationDate` và `SalaryIncreaseDate` mỗi khi người dùng đổi "Ngày lập BB". Vì `DisciplineEnd`/`SalaryIncreaseDate` bị ẩn, giá trị của chúng hoàn toàn phụ thuộc cơ chế tự sinh này; riêng `ViolationDate` vẫn hiển thị nên bị **ghi đè lại** mỗi lần đổi `DisciplineBegin` (người dùng có thể sửa lại `ViolationDate` sau đó).

5. **`KiemTraNhapVaLuuMoi()`** — hàm kiểm tra hợp lệ giữa các mốc ngày (kết thúc ≥ bắt đầu, tăng lương ≥ kết thúc, vi phạm ≤ bắt đầu), cảnh báo nếu sai. **Hàm này được định nghĩa nhưng KHÔNG được gọi ở bất kỳ đâu trong code** (kể cả `btnSave_Click`) — xem Ghi chú kỹ thuật.

6. **`Employee_ID_EditValueChanged`** — thân hàm bị comment, không tự động tìm kiếm khi đổi nhân viên.

7. **`GridControl1_KeyUp`** → `Gridview_KeyUp` (phím tắt chuẩn).

## Ghi chú kỹ thuật
- Có **3 trường ẩn khỏi giao diện** (`DisciplineEnd`, `SalaryIncreaseDate`, `ProcAsign` cùng label) nhưng vẫn nằm trong `TableLayoutPanel2` nên vẫn được validate NOT NULL/lưu xuống DB; 2 trong số đó (`DisciplineEnd`, `SalaryIncreaseDate`) được tự động gán bằng giá trị `DisciplineBegin` qua `AutoGenDisciplineEnd()`.
- **`KiemTraNhapVaLuuMoi()` là dead code**: hàm kiểm tra tính hợp lệ ngày tháng được viết sẵn nhưng không được gọi trong `btnSave_Click` hay bất kỳ nơi nào khác → việc lưu dữ liệu **không thực sự áp dụng** kiểm tra logic ngày tháng này dù code tồn tại, có thể là lỗi sót khi phát triển.
- Lưu bằng `tvcn.SaveByStore` truyền `TableLayoutPanel2` (khác `frmBaoCaoBaoHiem` mẫu — truyền toàn bộ `XtraTabControl1`).
- `AfterViewForm()` còn sót dòng code comment liên quan Janus GridEX (`Gridex1`) — dấu vết chưa dọn dẹp khi chuyển sang DevExpress.
- Không override `BeforeSave`/`BeforeDelete`, không mở form phụ nào khác, không có constructor overload.
