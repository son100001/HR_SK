# frmEmpNonRegisInsurance – Khai báo NV không đóng BH/Công đoàn

## Vị trí file
- `BaoHiem/frmEmpNonRegisInsurance.vb` (chứa cả code + `InitializeComponent` – không tách file `.Designer.vb` riêng)
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_EmpNonRegisInsuranceAndUnion` (`HRFORM_TableName`)
- Stored procedure Lưu: `usp_InsertUpdateHR_EmpNonRegisInsuranceAndUnion` (`HRFORM_SaveStore`, và cũng được gọi trực tiếp trong hàm `Save()` riêng của form)

## Mục đích
Khai báo theo **tháng/năm** những nhân viên **không tham gia** (hoặc có tham gia theo trường hợp đặc biệt khác với logic mặc định của hệ thống) đối với 4 khoản: **BHXH, BHYT, BHTN, Công đoàn**. Dùng cho các trường hợp ngoại lệ (nhân viên thử việc, nhân viên nước ngoài, theo thỏa thuận riêng...).

## Bố cục giao diện

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblThang` + `Thang` | Label + control `Month` | Tháng áp dụng |
| Nhập liệu (`pnDuLieuNhap`) | `lblNam` + `Nam` | Label + control `Year` | Năm áp dụng |
| Nhập liệu (`pnDuLieuNhap`) | GroupBox `BHXH` (Đóng/Không đóng/Theo logic) | 3 RadioButton: `rdbSocialInsurance`, `rdbNotSocialInsurance`, `rdbTheoLogicSocialInsurance` | Trạng thái đóng BHXH của nhân viên trong tháng/năm chọn |
| Nhập liệu (`pnDuLieuNhap`) | GroupBox `BHYT` | 3 RadioButton: `rdbHealthInsurance`, `rdbNotHealthInsurance`, `rdbTheoLogicHealthInsurance` | Trạng thái đóng BHYT |
| Nhập liệu (`pnDuLieuNhap`) | GroupBox `BHTN` | 3 RadioButton: `rdbUnemploymentInsurance`, `rdbNotUnemploymentInsurance`, `rdbTheoLogicUnemploymentInsurance` | Trạng thái đóng BH Thất nghiệp |
| Nhập liệu (`pnDuLieuNhap`) | GroupBox `CD` (Công đoàn) | 3 RadioButton: `rdbUnionFee`, `rdbNotUnionFee`, `rdbTheoLogicUnionFee` | Trạng thái đóng Công đoàn phí |
| Nhập liệu (`pnDuLieuNhap`) | `lblComment` + `Comment` | Label + RichTextBox | Ghi chú lý do |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Danh sách nhân viên đã khai báo ngoại lệ theo tháng/năm |

**Ý nghĩa 3 lựa chọn của mỗi nhóm radio button:**
- **"Đóng"** → ghi giá trị `1` (bắt buộc tham gia khoản này bất kể logic mặc định).
- **"Không đóng"** → ghi giá trị `0` (loại trừ khỏi khoản này).
- **"Theo logic"** (mặc định được chọn sẵn) → ghi `null` (để hệ thống tự tính theo logic nghiệp vụ chuẩn, không có ngoại lệ).

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` lọc danh sách theo Tháng/Năm/nhân viên |
| **Lưu** (`btnSave`) | `btnSave_Click` | Xử lý theo thứ tự: 1) Nếu `QuyenHRFORM = "View"` → hiện cảnh báo "Bạn không có quyền thay đổi" và dừng lại. 2) Kiểm tra trường bắt buộc qua `tvcn.CheckErrorProvider`. 3) Hiện hộp thoại xác nhận "Bạn có thực sự muốn lưu?" (Yes/No). 4) Nếu Yes → gọi hàm `Save(...)` nội bộ, quy đổi radio button sang giá trị 1/0/null cho từng khoản rồi gọi stored procedure `usp_InsertUpdateHR_EmpNonRegisInsuranceAndUnion`. 5) Nếu lưu thành công → gọi lại `Search()` để refresh grid. 6) Focus lại `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel |

## Luồng xử lý

1. **`frmEmpNonRegisInsurance_Load`**
   - Đánh dấu (*) trường bắt buộc trên `TableLayoutPanel2`.
   - `LoadGiaoDienTheoDieuKien()`, nạp danh sách nhân viên cho LookUpEdit.
   - Gọi `Search()` hiển thị dữ liệu ban đầu.

2. **`Search()`**
   - Build: `[dbo].[sp_BangKhongDongBHCD] '<Thang>','<Nam>','<Lan>',N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>',N'<PositionCategory>',N'<EmployeeID>'`
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Save(Employee_ID, thang, nam, SocialInsurance, HealthInsurance, UnemploymentInsurance, UnionFee, Comment)` (hàm riêng, không phải override của HRFORM)**
   - Gọi trực tiếp: `exec usp_InsertUpdateHR_EmpNonRegisInsuranceAndUnion N'<Employee_ID>',<thang>,<nam>,<SocialInsurance>,<HealthInsurance>,<UnemploymentInsurance>,<UnionFee>,N'<Comment>',N'<UserName>','<yyyy-MM-dd HH:mm:ss>'`
   - Đọc cột `ThongBao` trả về từ stored procedure: nếu khác rỗng → hiển thị `MessageBox` lỗi với nội dung dịch qua `tvcn.GetLanguagesTranslated`, trả về `False`.
   - Nếu không có lỗi → hiển thị `MessageBox` "Nhập thành công", trả về `True`.

4. **`Employee_ID_EditValueChanged`** – khai báo nhưng không tự tìm kiếm lại (dòng `Search()` bị comment), giống các form khác trong module.

5. **`Gridex1_KeyUp`** – ủy quyền phím tắt chuẩn cho `Gridview_KeyUp`.

## Ghi chú kỹ thuật
- Form này **kiểm tra quyền chỉnh sửa thủ công ngay trong `btnSave_Click`** (`If QuyenHRFORM = "View" Then ... Exit Sub`), khác với các form còn lại trong module chỉ dựa vào việc `HRFORM` tự ẩn/disable nút theo quyền — đây là lớp kiểm tra an toàn bổ sung dành riêng cho nghiệp vụ nhạy cảm này.
- Có bước **xác nhận Yes/No trước khi lưu**, không có ở các form khác trong module (`frmInsurance`, `frmTheBHYT`, `frmBaoCaoBaoHiem` lưu ngay không hỏi xác nhận).
- File `.vb` chứa nguyên khối `InitializeComponent` (không tách `.Designer.vb`) – khác quy ước với 3 form còn lại trong module.
