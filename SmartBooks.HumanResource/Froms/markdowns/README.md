# Module Froms – Tài liệu các Form nghiệp vụ

> Thư mục `Froms/` chứa **toàn bộ màn hình nghiệp vụ chính** của project `SmartBooks.HumanResource`
> (hồ sơ nhân viên, quá trình công tác, khen thưởng/kỷ luật, sức khỏe, tài sản, nghỉ việc...),
> cùng 2 thư mục con `Para/` (form tham số/bộ lọc cho báo cáo) và `ShowReports/` (form hỗ trợ/hiển thị báo cáo).

## Danh sách form

| Form | Chức năng | File chi tiết |
|---|---|---|
| `frmEmployeeInfo` | **Hồ sơ nhân viên** – form phức tạp nhất hệ thống, gồm nhiều tab: thông tin cá nhân, CCCD/QR, địa chỉ, cơ cấu tổ chức & hợp đồng, trình độ chuyên môn, liên lạc, ngân hàng/thẻ, sức khỏe, ảnh, nhập NV mới, tiện ích (import Excel hàng loạt, nhập ảnh hàng loạt, đổi mã nhân viên) | [frmEmployeeInfo.md](frmEmployeeInfo.md) |
| `frmChuyenViTri` | Chuyển vị trí/phòng ban nhân viên | [frmChuyenViTri.md](frmChuyenViTri.md) |
| `frmAward` | Khen thưởng | [frmAward.md](frmAward.md) |
| `frmDiscipline` | Kỷ luật | [frmDiscipline.md](frmDiscipline.md) |
| `frmFamily` | Thông tin gia đình nhân viên | [frmFamily.md](frmFamily.md) |
| `frmTerminationAsignment` | Nghỉ việc | [frmTerminationAsignment.md](frmTerminationAsignment.md) |
| `frmTrainingRecord` | Hồ sơ đào tạo | [frmTrainingRecord.md](frmTrainingRecord.md) |
| `frmLicense` | Chứng chỉ | [frmLicense.md](frmLicense.md) |
| `frmHealthCheck` | Khám sức khỏe | [frmHealthCheck.md](frmHealthCheck.md) |
| `frmDiseasesRecord` | Bệnh lý | [frmDiseasesRecord.md](frmDiseasesRecord.md) |
| `frmSurgeryHistory` | Lịch sử phẫu thuật | [frmSurgeryHistory.md](frmSurgeryHistory.md) |
| `frmHeavyAndToxic` | Công việc độc hại/nặng nhọc | [frmHeavyAndToxic.md](frmHeavyAndToxic.md) |
| `frmBankAccountOfEmployee` | Tài khoản ngân hàng của nhân viên | [frmBankAccountOfEmployee.md](frmBankAccountOfEmployee.md) |
| `frmCapPhatAo` | Cấp phát đồng phục (áo) | [frmCapPhatAo.md](frmCapPhatAo.md) |
| `frmDisable` | Khai báo tình trạng khuyết tật/tàn tật của nhân viên (bảng `HR_Disable`) | [frmDisable.md](frmDisable.md) |
| `frmQuanLyTheTu` | Quản lý thẻ từ (thẻ ra vào) | [frmQuanLyTheTu.md](frmQuanLyTheTu.md) |
| `frmQuaTrinhHocTapCongTac` | Quá trình học tập/công tác | [frmQuaTrinhHocTapCongTac.md](frmQuaTrinhHocTapCongTac.md) |
| `Holidays_Plan` | Kế hoạch nghỉ lễ | [Holidays_Plan.md](Holidays_Plan.md) |
| `Para\para_NhanVienActive` | Form tham số lọc nhân viên đang hoạt động (dùng trước khi mở báo cáo) | [para_NhanVienActive.md](para_NhanVienActive.md) |
| `Para\frmparaSalaryComponent` | Form tham số liên quan thành phần lương (dùng trước khi mở báo cáo) | [frmparaSalaryComponent.md](frmparaSalaryComponent.md) |
| `ShowReports\frHoTroNhapLieu` | Form hỗ trợ nhập liệu (hiển thị/hỗ trợ nhập cho báo cáo) | [frHoTroNhapLieu.md](frHoTroNhapLieu.md) |

## Đặc điểm chung (kế thừa từ `WindowsControlLibrary.HRFORM`)

Phần lớn form trong `Froms/` (trừ một số form trong `Para/` và `ShowReports/` – xem ghi chú riêng trong từng file) kế thừa `HRFORM`, nên dùng chung:

- **PanelButton chuẩn**: `btnAdd` (Thêm), `btnEdit` (Sửa), `btnRemove` (Xóa), `btnLuu` (Lưu), `btnRefresh` (Xem/Tải lại), `btnExportExcel`/`btnImportExcel`, `btnGetTemplate`, `btnExcute` (Thực hiện), `btnSaveLayout`/`btnRefreshLayout`, `cbbReport` (chọn mẫu in). Nút hiện/ẩn theo cờ `HRFORM_VisibleControl_...`, enable/disable theo quyền `QuyenHRFORM` ("View"/"EDIT").
- **Phím tắt chuẩn** (`Gridview_KeyUp`): `Ctrl+S` lưu dòng hiện hành, `Ctrl+D` xóa dòng đang chọn, `Ctrl+F` focus grid, `Ctrl+Q` đóng form, `F5` tải lại dữ liệu.
- **Cơ chế Search chuẩn**: build `exec [dbo].[sp_...]` với tham số phân quyền theo cơ cấu tổ chức (Factory/Dept/Section/Team/Position/PositionCategory) + mã nhân viên lọc, gọi `Xem(...)` đổ lên grid.
- **2 kiểu nhập liệu**: (a) nhập trực tiếp trên panel rồi Lưu qua `tvcn.LuuHoacXoaTuForm`/`tvcn.SaveByStore`; (b) danh sách thuần, Thêm/Sửa mở popup qua `tvcn.AddNewOrEdit` + `HRFORM_InputForm`.
- Nhiều form override `BeforeSave()` / `AfterViewForm()` / có constructor overload để mở từ form khác (đặc biệt `frmChuyenViTri`, `frmTerminationAsignment` được mở trực tiếp từ `frmEmployeeInfo`).

## Lưu ý khi đọc tài liệu

Mỗi file `.md` được viết dựa trên việc đọc trực tiếp mã nguồn (`.vb` + `.Designer.vb`) tại thời điểm viết tài liệu, có ghi chú các điểm bất thường/quirk phát hiện được trong code thực tế (dead code, sự kiện thiếu `Handles`, tên hàm không khớp, v.v.) thay vì suy đoán theo tên form. Khi code thay đổi, cần cập nhật lại file markdown tương ứng.
