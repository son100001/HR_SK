# Module BaoHiem – Tài liệu các Form

> Module quản lý **Bảo hiểm** (BHXH, BHYT, BHTN) và **Công đoàn** của nhân viên.
> Nằm trong project chính `SmartBooks.HumanResource`, thư mục `BaoHiem/`.

## Danh sách form

| Form | Chức năng | Bảng dữ liệu chính | File chi tiết |
|---|---|---|---|
| `frmInsurance` | Quản lý Sổ bảo hiểm xã hội của nhân viên | `HR_Insurance` | [frmInsurance.md](frmInsurance.md) |
| `frmTheBHYT` | Quản lý Thẻ bảo hiểm y tế của nhân viên | `HR_TheBHYT` | [frmTheBHYT.md](frmTheBHYT.md) |
| `frmInsuranceInformation` | Màn hình tổng hợp 2 tab: Sổ BH + Thẻ BHYT | `HR_Insurance`, `HR_TheBHYT` | [frmInsuranceInformation.md](frmInsuranceInformation.md) |
| `frmBaoCaoBaoHiem` | Khai báo tăng/giảm bảo hiểm (báo tăng, báo giảm) | `HR_IncreaseDecreaseInsurance` | [frmBaoCaoBaoHiem.md](frmBaoCaoBaoHiem.md) |
| `frmEmpNonRegisInsurance` | Khai báo nhân viên không đóng BHXH/BHYT/BHTN/Công đoàn theo tháng | `HR_EmpNonRegisInsuranceAndUnion` | [frmEmpNonRegisInsurance.md](frmEmpNonRegisInsurance.md) |

## Đặc điểm chung

Tất cả các form đều kế thừa `WindowsControlLibrary.HRFORM` (base class dùng chung toàn hệ thống), nên có sẵn:

- **PanelButton** (thanh nút chuẩn phía dưới form): `btnAdd` (Thêm), `btnEdit` (Sửa), `btnRemove` (Xóa), `btnLuu` (Lưu), `btnRefresh` (Xem/Tải lại), `btnExportExcel`/`btnImportExcel`, `btnGetTemplate`, `btnExcute` (Thực hiện), `btnSaveLayout`/`btnRefreshLayout`, `cbbReport` (chọn mẫu in). Nút nào hiện/ẩn, bật/tắt phụ thuộc các cờ `HRFORM_VisibleControl_...` được set trong `InitializeComponent()` của từng form và quyền `QuyenHRFORM` ("View"/"EDIT").
- **Phím tắt chuẩn** (xử lý trong `Gridview_KeyUp` của HRFORM, các form chỉ gọi lại hàm này):
  - `Ctrl+S`: Lưu dòng hiện hành (nếu `btnLuu` đang Enabled)
  - `Ctrl+D`: Xóa (các) dòng đang chọn trên grid
  - `Ctrl+F`: Focus vào grid
  - `Ctrl+Q`: Đóng form
  - `F5`: Tải lại dữ liệu (Search lại)
- **Cơ chế Search chuẩn**: mỗi form tự xây câu lệnh `exec [dbo].[sp_...]` với các tham số phân quyền dữ liệu theo Nhà máy/Phòng ban/Bộ phận/Tổ/Vị trí (`obj.PARA_FACTORY_ID`, `PARA_DEPARTMENTCODE`, `PARA_SECTIONCODE`, `PARA_TEAMCODE`, `PARA_POSITION_ID`, `PARA_POSITIONCATEGORY_ID`) + mã nhân viên đang lọc, rồi gọi `Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)` để đổ dữ liệu lên grid.
- Có 2 kiểu form nhập liệu trong module này:
  1. **Form nhập trực tiếp trên panel** (`frmInsurance`, `frmTheBHYT`, `frmBaoCaoBaoHiem`, `frmEmpNonRegisInsurance`): các control nhập liệu nằm ngay trên form (không popup), khi bấm **Lưu** sẽ ghi giá trị các control xuống bảng tương ứng. Các form này tắt `HRFORM_VisibleControl_ThemMoi`/`Sua` (Thêm/Sửa dạng popup) vì việc thêm/sửa đã được thực hiện trực tiếp qua panel nhập liệu.
  2. **Form danh sách thuần** (`frmInsuranceInformation`): không có panel nhập liệu, Thêm/Sửa sẽ mở popup form con (`frmSoBaoHiem_Nhap`, `frmTheBHYT_Nhap`).

## Điều hướng liên quan

- `frmInsuranceInformation` là màn hình tổng hợp gộp dữ liệu của `frmInsurance` (tab "Sổ BH") và `frmTheBHYT` (tab "Thẻ BHYT") ở dạng chỉ xem danh sách + thêm/sửa qua popup, trong khi 2 form kia là màn hình nhập liệu trực tiếp, chi tiết hơn cho từng loại (có thêm bộ lọc theo nhân viên, ghi chú...).
