# frHoTroNhapLieu – Hỗ trợ nhập liệu (chuyển đổi văn bản + thực thi SQL)

## Vị trí file
- `Froms/ShowReports/frHoTroNhapLieu.vb` (thuần code-behind, không có file `.Designer.vb` riêng)
- Kế thừa: `System.Windows.Forms.Form` **(không kế thừa `HRFORM`)**
- Không gắn với bảng dữ liệu nghiệp vụ cụ thể nào (`HRFORM_TableName` không tồn tại vì form không kế thừa `HRFORM`)

## Mục đích
Đây là một **công cụ tiện ích/hỗ trợ nhập liệu nội bộ** cho người dùng vận hành hệ thống (không phải màn hình nghiệp vụ chấm công/nhân sự thông thường), gồm 2 chức năng độc lập:
1. **Chuyển đổi định dạng văn bản dán từ Excel/nguồn khác** thành chuỗi phân tách bằng tab hoặc xuống dòng, phục vụ việc chuẩn hóa dữ liệu trước khi nhập vào hệ thống — hỗ trợ 3 kiểu: Họ tên (tách từ theo khoảng trắng thành tab), Thời gian (chuyển định dạng ngày/tháng/năm theo 3 thứ tự khác nhau sang `yyyy-MM-dd`), Địa chỉ.
2. **Thực thi trực tiếp câu lệnh SQL** do người dùng nhập vào để cập nhật cơ sở dữ liệu (`kn.SaveData`).

Đây rõ ràng là một form mang tính **công cụ hỗ trợ kỹ thuật/admin**, không phải form nghiệp vụ HR thông thường, dù được đặt trong thư mục `ShowReports`.

## Bố cục giao diện/field chính
Form không dùng Grid/DevExpress mà dùng control WinForms chuẩn, chia làm các khối:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| `GroupBox1` ("Trường chuyển đổi") | `rdbHoTen`, `rdbThoiGian`, `rdbDiaChi` | RadioButton | Chọn loại dữ liệu cần chuyển đổi: Họ tên / Thời gian / Địa chỉ |
| `GroupBox2` ("Tùy chọn định dạng giờ") | `rdbNgayThangNam`, `rdbThangNgayNam`, `rdbNamThangNgay` | RadioButton | Chỉ hiện khi chọn "Thời gian" — chọn thứ tự các phần ngày/tháng/năm trong văn bản gốc |
| — | `rtbGoc` | RichTextBox | Vùng dán văn bản gốc cần chuyển đổi |
| — | `btThucHien` | Button ("Thực hiện") | Thực hiện chuyển đổi |
| — | `rtbDich1` | RichTextBox | Kết quả chuyển đổi (đích 1) |
| — | `rtbDich2` | RichTextBox | Vùng trống thứ 2 (đích 2) — có trên giao diện nhưng không thấy logic nào ghi dữ liệu vào đây trong code đọc được |
| `GroupBox3` ("Cập nhật cơ sở dữ liệu") | `rtbSQL` | RichTextBox | Người dùng nhập câu lệnh SQL cần thực thi |
| `GroupBox3` | `btCapNhatCSDL` | Button ("Cập nhật") | Thực thi câu lệnh SQL trong `rtbSQL` |

## Danh sách nút & tác dụng

| Nút/Control | Sự kiện | Tác dụng |
|---|---|---|
| **Thực hiện** (`btThucHien`) | `btThucHien_Click` | Đọc `rtbGoc.Text`, tùy theo radio đang chọn: <br>• `rdbHoTen`: dùng Regex nén khoảng trắng thừa, tách từng từ ra một dòng riêng bằng ký tự Tab (thuật toán dựa trên việc thay `-`↔khoảng trắng/tab) → ghi vào `rtbDich1`. <br>• `rdbThoiGian`: với mỗi dòng trong `rtbGoc`, tách theo `/` hoặc `\`, sắp xếp lại theo thứ tự `yyyy-MM-dd` tùy theo radio trong `GroupBox2` (Ngày-Tháng-Năm / Tháng-Ngày-Năm / Năm-Tháng-Ngày) → ghi vào `rtbDich1`; nếu dòng nào sai định dạng thì báo `MessageBox` kèm nội dung dòng lỗi và dừng xử lý. <br>• `rdbDiaChi`: khai báo nhánh `Else` nhưng **không có xử lý gì** (thân rỗng) — chức năng "Địa chỉ" hiện chưa được cài đặt logic |
| `rdbHoTen` / `rdbThoiGian` / `rdbDiaChi` (`CheckedChanged`) | tương ứng | Ẩn/hiện `GroupBox2` (tùy chọn định dạng giờ): chỉ hiện khi chọn `rdbThoiGian`, ẩn khi chọn `rdbHoTen` hoặc `rdbDiaChi` |
| **Cập nhật** (`btCapNhatCSDL`) | `btCapNhatCSDL_Click` | Gọi `kn.SaveData(rtbSQL.Text)` để **thực thi trực tiếp** câu lệnh SQL người dùng nhập trong `rtbSQL` xuống cơ sở dữ liệu; nếu thành công hiện `MessageBox` "Cập nhật thành công!" |

## Luồng xử lý chính

1. **`frHoTroNhapLieu_Load`** – chỉ ẩn `GroupBox2` (`GroupBox2.Visible = False`) làm trạng thái mặc định ban đầu.
2. Người dùng chọn 1 trong 3 radio ở `GroupBox1` → tự động ẩn/hiện `GroupBox2` theo `CheckedChanged`.
3. Người dùng dán văn bản vào `rtbGoc`, bấm **Thực hiện** → kết quả chuyển đổi hiện ở `rtbDich1` (theo logic mô tả ở bảng nút trên).
4. Độc lập với phần trên, người dùng có thể gõ/dán một câu lệnh SQL bất kỳ vào `rtbSQL` và bấm **Cập nhật** để thực thi trực tiếp lên database.

## Ghi chú kỹ thuật
- **Không kế thừa `HRFORM`** — đây là điểm khác biệt lớn nhất so với phần lớn form trong `Froms/`: không có `PanelButton`, không có cơ chế `Search()`/`Xem()`/phân quyền `QuyenHRFORM`, không có phím tắt `Gridview_KeyUp` chuẩn (Ctrl+S/D/F/Q, F5) vì form không có Grid nghiệp vụ.
- Khởi tạo kết nối DB riêng: `Dim kn As New connect(DbSetting.dataPath)` thay vì dùng biến `kn` dùng chung của module như các form kế thừa `HRFORM`.
- Chức năng "Cập nhật cơ sở dữ liệu" (`btCapNhatCSDL_Click`) cho phép **thực thi SQL tùy ý do người dùng nhập** mà không qua kiểm tra/validate nào trong code đọc được — cần lưu ý về rủi ro khi cấp quyền truy cập form này.
- Nhánh xử lý cho `rdbDiaChi` (Địa chỉ) hiện **chưa có logic chuyển đổi** (thân `Else` rỗng trong `btThucHien_Click`) — chọn radio này rồi bấm "Thực hiện" sẽ không có tác dụng gì.
- Control `rtbDich2` tồn tại trên giao diện nhưng không thấy đoạn code nào ghi/đọc dữ liệu từ nó — có thể là control dự phòng/chưa hoàn thiện.
- Vì đặt trong thư mục `ShowReports` nhưng thực chất không hiển thị báo cáo nào — tên thư mục ở đây không phản ánh đúng chức năng thực tế của form (là công cụ hỗ trợ nhập liệu/chạy SQL, không phải report viewer).
