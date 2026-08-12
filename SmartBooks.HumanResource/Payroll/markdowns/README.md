# Module Payroll – Tài liệu các Form

> Module quản lý **Bảng lương / Tính lương** của project `SmartBooks.HumanResource`:
> hợp đồng lao động, mức lương/thang bảng lương, bậc tay nghề, phụ cấp, thuế TNCN, phiếu lương, báo cáo lương.

## Danh sách form

| Form | Chức năng | File chi tiết |
|---|---|---|
| `frmContractList` | Danh sách hợp đồng lao động của nhân viên | [frmContractList.md](frmContractList.md) |
| `frmMucLuong` | Danh mục thang bảng lương (Nhóm lương/Bậc lương) | [frmMucLuong.md](frmMucLuong.md) |
| `frmMucLuongNhanVien` | Gán/khai báo mức lương áp dụng cho từng nhân viên | [frmMucLuongNhanVien.md](frmMucLuongNhanVien.md) |
| `frmLuongCoDinh` | Khai báo các khoản lương cố định theo nhân viên | [frmLuongCoDinh.md](frmLuongCoDinh.md) |
| `frmSalaryComponent` | Danh mục thành phần lương (các khoản cấu thành bảng lương) | [frmSalaryComponent.md](frmSalaryComponent.md) |
| `frmCaiDatPhuCap` | Cài đặt phụ cấp | [frmCaiDatPhuCap.md](frmCaiDatPhuCap.md) |
| `frmBacTayNghe` | Danh mục Bậc tay nghề | [frmBacTayNghe.md](frmBacTayNghe.md) |
| `frmBacTayNgheNhanVien` | Gán Bậc tay nghề cho từng nhân viên | [frmBacTayNgheNhanVien.md](frmBacTayNgheNhanVien.md) |
| `frmEmpRegisParameter` | Đăng ký tham số lương theo nhân viên/khoảng ngày | [frmEmpRegisParameter.md](frmEmpRegisParameter.md) |
| `frmEmpRegisterNumberOfWDPerMonth` | Đăng ký số ngày công/tháng | [frmEmpRegisterNumberOfWDPerMonth.md](frmEmpRegisterNumberOfWDPerMonth.md) |
| `frmDanhSachNguoiPhuThuoc` | Danh sách người phụ thuộc (giảm trừ gia cảnh thuế TNCN) | [frmDanhSachNguoiPhuThuoc.md](frmDanhSachNguoiPhuThuoc.md) |
| `frmQuyetToanThueTNCN` | Quyết toán thuế thu nhập cá nhân (form chọn/chạy báo cáo) | [frmQuyetToanThueTNCN.md](frmQuyetToanThueTNCN.md) |
| `frmBaoCaoLuong` | Báo cáo lương (form chọn/chạy báo cáo qua danh mục `HR_Report`) | [frmBaoCaoLuong.md](frmBaoCaoLuong.md) |
| `PhieuLuongMoi` | Phiếu lương – xem/in/gửi email phiếu lương hàng loạt | [PhieuLuongMoi.md](PhieuLuongMoi.md) |
| `Salary_Parameter` | Form CRUD tham số lương (bảng `SmartBooks_Salary_Parameter`) | [Salary_Parameter.md](Salary_Parameter.md) |
| `para_Salary` | Màn hình chính **Bảng lương/Tính lương** nhiều tab (không phải form tham số như tên gợi ý) | [para_Salary.md](para_Salary.md) |

## Đặc điểm chung

Đa số form kế thừa `WindowsControlLibrary.HRFORM` (xem quy ước chung trong `Froms/markdowns/README.md` và `BaoHiem/markdowns/README.md`): PanelButton chuẩn (Thêm/Sửa/Xóa/Lưu/Xem/Export Excel...), phím tắt Ctrl+S/D/F/Q, F5, cơ chế Search bằng `exec sp_...` + `Xem(...)`.

Tuy nhiên module này có một số form **không theo pattern CRUD chuẩn**, cần lưu ý khi tra cứu:

- **`frmQuyetToanThueTNCN`** và **`frmBaoCaoLuong`** thực chất là form-vỏ chọn/chạy báo cáo (dùng `cbbReport` + `btnExcute`/danh mục `HR_Report` của `HRFORM`), không có `Search()`/CRUD riêng.
- **`PhieuLuongMoi`** là report-viewer kiêm chức năng gửi email phiếu lương hàng loạt, không phải form nhập liệu.
- **`para_Salary`** — mặc dù tên có tiền tố "para_" giống các form tham số/bộ lọc, thực tế đây là **màn hình chính thực hiện tính lương/xem bảng lương** với nhiều tab kết quả, khác hẳn giả định ban đầu.
- **`Salary_Parameter`** ngược lại — dù tên nghe như "tham số", đây lại là **form CRUD thật** cho bảng `SmartBooks_Salary_Parameter`.

## Lưu ý khi đọc tài liệu

Các agent viết tài liệu đã đọc trực tiếp mã nguồn (`.vb` + `.Designer.vb`) và ghi chú rõ các điểm bất thường/code chết phát hiện được (sự kiện thiếu `Handles`, nút Lưu tùy biến có thân hàm rỗng, form popup được tham chiếu nhưng không tồn tại trong mã nguồn, v.v.) trong phần "Ghi chú kỹ thuật" của từng file — nên đọc kỹ phần này trước khi dựa vào tài liệu để sửa/mở rộng chức năng.
