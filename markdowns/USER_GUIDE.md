# HƯỚNG DẪN SỬ DỤNG PHẦN MỀM NHÂN SỰ SMARTBOOKS.HR

> [!NOTE]
> Tài liệu này được thiết kế dành cho người mới sử dụng phần mềm Smartbooks.HumanResource. Vui lòng làm theo hướng dẫn từng bước và tham khảo các ảnh chụp màn hình minh họa đi kèm. Các ảnh minh họa (placeholder) có thể được thay thế bằng ảnh thực tế chụp từ phần mềm để tăng tính trực quan.

## MỤC LỤC
1. [I. Hướng Dẫn Chung và Đăng Nhập](#i-hướng-dẫn-chung-và-đăng-nhập)
2. [II. Phân Hệ Cài Đặt Tổng Quát](#ii-phân-hệ-cài-đặt-tổng-quát)
3. [III. Phân Hệ Quản Lý Thông Tin Nhân Viên](#iii-phân-hệ-quản-lý-thông-tin-nhân-viên)
4. [IV. Phân Hệ Chấm Công](#iv-phân-hệ-chấm-công)
5. [V. Phân Hệ Tính Lương](#v-phân-hệ-tính-lương)
6. [VI. Phân Hệ Bảo Hiểm](#vi-phân-hệ-bảo-hiểm)

---

## I. Hướng Dẫn Chung và Đăng Nhập

### 1. Khởi động và Đăng nhập
Click đúp vào biểu tượng Smartbooks HR để khởi động phần mềm. Màn hình đăng nhập sẽ hiện ra.

![Màn hình Đăng nhập - Login.vb](./images/Login.png)

- **Username:** Nhập tên đăng nhập của bạn.
- **Password:** Nhập mật khẩu.
- Nhấn **Login** để truy cập vào giao diện chính.

### 2. Giao diện làm việc chung
Hầu hết các màn hình làm việc trong hệ thống có cấu trúc tương đồng nhau gồm các phần chính:

![Giao diện chính - frmMain.vb](./images/frmMain.png)

1. **Thanh tác nghiệp (Menu bên trái):** Chứa danh sách các chức năng chính.
2. **Thanh công cụ (Phía trên):** Nhập/Lọc thông tin dữ liệu mới.
3. **Lưới dữ liệu (Lớn nhất ở giữa):** Hiển thị dữ liệu, cho phép xem báo cáo, chọn để sửa/xóa.
4. **Hộp chức năng (Dưới cùng/Góc phải):** Chứa các báo cáo, lệnh xử lý đặc biệt.
5. **Nút chức năng (Thanh dưới cùng):** Thêm, Lưu, Xóa, Làm tươi, Đóng.

> [!TIP]
> **Quy tắc chung:** Dấu `*` màu đỏ biểu thị trường dữ liệu **bắt buộc** phải nhập.

### 3. Thao tác Cơ bản (Thêm, Sửa, Xóa)
- **Thêm mới:** Nhập thông tin vào Thanh công cụ phía trên $\rightarrow$ Nhấn **Lưu**. Hoặc sử dụng tính năng Import từ Excel.
- **Sửa:** Chỉnh sửa trực tiếp trên lưới ở những cột màu xanh $\rightarrow$ Nhấn **Lưu**.
- **Xóa:** Tích chọn dòng trên lưới $\rightarrow$ Nhấn nút **Xóa (D)**.
- **Xuất Excel:** Chọn dòng $\rightarrow$ Nhấn icon Excel $\rightarrow$ Chọn đường dẫn lưu file (Tên file không dấu, không ký tự đặc biệt).

---

## II. Phân Hệ Cài Đặt Tổng Quát
Phân hệ này dùng để thiết lập các thông tin gốc áp dụng cho toàn bộ công ty (Cơ cấu tổ chức, Chức vụ, Hợp đồng...).

### 1. Cơ cấu phòng ban (Xưởng, Khu vực, Bộ phận)
Định nghĩa cơ cấu tổ chức nhiều cấp. Ví dụ: Xưởng $\rightarrow$ Khu vực $\rightarrow$ Bộ phận.

![Giao diện tạo Bộ phận](./images/frmDepartment.png)

- Chọn mục **Tạo/Điều chỉnh Xưởng** (hoặc Bộ phận) trên thanh tác nghiệp.
- Nhập tên Tiếng Việt/Tiếng Anh/Hàn.
- Nhấn **Lưu** để cập nhật.

### 2. Chức vụ và Chức danh
Quản lý các cấp bậc chức vụ (Giám đốc, Quản lý, Nhân viên...) và Chức danh nghề nghiệp.

![Giao diện tạo Chức vụ](./images/frmPosition.png)

### 3. Quản lý Hợp Đồng Lao Động (HĐLĐ)
Quản lý các loại hợp đồng (Thử việc, 1 năm, Vô thời hạn). 

![Giao diện Hợp đồng](./images/frmContractType.png)

> [!IMPORTANT]
> - Cột **Từ ngày:** Ngày bắt đầu có hiệu lực của loại HĐLĐ.
> - Cột **Phần trăm lương:** Khai báo phần trăm lương cho loại hợp đồng (Ví dụ: Thử việc 85%).

### 4. Ca làm việc cho toàn doanh nghiệp
Thiết lập các ca làm việc (Hành chính, Ca đêm...) làm cơ sở chấm công.

![Giao diện Cài đặt Ca](./images/frmShift.png)

- **Mã ca:** Đặt theo chuẩn (Ví dụ: `01-Shift1`).
- **Từ giờ / Đến giờ:** Thời gian bắt đầu và kết thúc.
- **Giờ nghỉ:** Thời gian nghỉ giữa ca.

---

## III. Phân Hệ Quản Lý Thông Tin Nhân Viên
Sử dụng để quản lý hồ sơ cơ bản, gia đình, lịch sử công tác và thôi việc.

### 1. Quản lý Thông Tin Nhân Viên
Màn hình trung tâm để nhập và tra cứu thông tin nhân sự.

![Giao diện Nhân viên - frmEmployeeInfo.vb](./images/frmEmployeeInfo.png)

- **Thêm nhân viên mới:** Chuyển sang Tab `Nhập nhân viên mới`. Điền thông tin vào các cột bắt buộc (Màu đỏ: Mã NV, Họ tên, Ngày sinh...).
- **Cập nhật thông tin chi tiết:** Tại Tab `Tổng quát`, điền đầy đủ các thông tin cá nhân, trình độ, liên lạc ở bảng bên phải. Nhấn **Lưu**.

> [!TIP]
> Bạn có thể in thẻ nhân viên bằng cách: Chọn nhân viên trên lưới $\rightarrow$ Vào **Hộp chức năng** chọn `In thẻ nhân viên` $\rightarrow$ Nhấn `Thực hiện` $\rightarrow$ Xem file in.

### 2. Thông tin Gia đình và Chế độ Con nhỏ
Khai báo người thân và thiết lập chế độ ưu tiên (Đi trễ về sớm cho con nhỏ).

![Giao diện Gia đình - frmFamily.vb](./images/frmFamily.png)

- Khi nhập Ngày sinh của con, hệ thống tự tính thời gian thụ hưởng chế độ con nhỏ dưới 1 tuổi (hoặc 6 tuổi). 

### 3. Chuyển Vị Trí / Chức Vụ
Lưu vết lịch sử thay đổi phòng ban, vị trí công việc của nhân viên.

![Giao diện Chuyển vị trí - frmChuyenViTri.vb](./images/frmChuyenViTri.png)

- Chọn nhân viên, điền vị trí mới và **Ngày hiệu lực**.
- Nhấn **Nhập** rồi nhấn **Lưu**.

### 4. Quyết định Thôi việc
Quản lý trạng thái nghỉ việc của nhân viên.

![Giao diện Thôi việc - frmTerminationAsignment.vb](./images/frmTerminationAsignment.png)

- Nhập Lý do thôi việc, trạng thái (Duyệt/Kế hoạch/Hủy), và Ngày thôi việc.

---

## IV. Phân Hệ Chấm Công
Quản lý đăng ký ca, tăng ca, nghỉ phép và lấy dữ liệu từ máy chấm công.

### 1. Đăng ký Tăng Ca
Đăng ký trước hoặc sau thời gian làm việc để hệ thống ghi nhận tính công.

![Giao diện Đăng ký Tăng ca](./images/frmDkTangCa.png)

- Chọn nhân viên, điền **Số giờ tăng ca** và **Loại tăng ca** (TC trước, TC sau, TC trưa, TC nghỉ bù).

### 2. Lấy dữ liệu từ Máy chấm công
Kéo dữ liệu quẹt thẻ thực tế vào hệ thống.

![Giao diện Lấy dữ liệu](./images/frmChamCong.png)

- Chức năng: Vào Hộp chức năng chọn `Lấy dữ liệu chấm công`.
- Chọn khoảng thời gian và nhấn OK để tải dữ liệu giờ ra/vào.

### 3. Xử lý Công Bất Thường (Chỉ có Giờ Vào / Giờ Ra)
Xử lý các trường hợp quên quẹt thẻ.

![Giao diện Xử lý Bất thường](./images/frmMissingTime.png)

- **Cách 1:** Hệ thống tự động tính bù giờ theo quy định.
- **Cách 2:** Nhập tay giờ thiếu (Ví dụ: điền trực tiếp 17:30 vào ô giờ ra).

### 4. Tính Công
Tổng hợp toàn bộ dữ liệu (Ca, Tăng ca, Giờ quẹt thẻ) để ra Bảng công.

![Giao diện Tính công](./images/frmTimeKeeping.png)

- Chọn tính công theo **Mã nhân viên** hoặc **Toàn bộ nhân viên**.
- Chọn tháng tính công $\rightarrow$ Nhấn **Tính Công**.
- **Báo cáo Bảng chấm công:** Xem chi tiết các loại công (Hành chính, Tăng ca 150%, Công đêm...).

---

## V. Phân Hệ Tính Lương
Thực hiện thiết lập các mức lương và chốt lương cuối tháng.

### 1. Cài Đặt Mức Lương và Bậc Lương
Định nghĩa hệ thống thang bảng lương của công ty.

![Giao diện Cài đặt Mức lương](./images/frmSalaryLevel.png)

- Tạo **Nhóm lương** và thiết lập **Mức lương (Số tiền)** tương ứng cho từng bậc.

### 2. Lương Cố Định và Phát Sinh
- **Lương cố định:** Các khoản lương dài hạn (Lương cơ bản, phụ cấp trách nhiệm, nhà ở...).
- **Phát sinh tăng/giảm:** Các khoản theo tháng (Thưởng năng suất, Bù lương, Phạt...).

### 3. Tính Lương và In Phiếu Lương
Chạy quy trình tính lương tự động dựa trên bảng công và các thiết lập phụ cấp.

![Giao diện Tính lương](./images/frmPayroll.png)

- Vào tab `Lương tháng` $\rightarrow$ Chọn `Tính lương` $\rightarrow$ Nhấn **Thực hiện**.
- Chọn Tháng/Năm để tính.
- **Khóa lương:** Sau khi kiểm tra đúng, thực hiện **Khóa** để không bị tính lại sai lệch dữ liệu.
- **In phiếu lương:** Chọn In Phiếu lương $\rightarrow$ Hệ thống sẽ xuất ra dạng PDF để in hoặc gửi email.

---

## VI. Phân Hệ Bảo Hiểm
Theo dõi Sổ BHXH, BHYT và quá trình đóng bảo hiểm.

### 1. Quản lý Sổ BHXH và Thẻ BHYT
Khai báo số sổ, số thẻ và bệnh viện đăng ký khám chữa bệnh.

![Giao diện Sổ Bảo hiểm](./images/frmInsurance.png)

### 2. Báo Cáo Bảo Hiểm (Mẫu D02-TS)
Tổng hợp tình hình Tăng/Giảm bảo hiểm hàng tháng.

![Giao diện Báo cáo Bảo hiểm](./images/frmInsuranceReport.png)

- Chạy lệnh phân tích dữ liệu Tăng/Giảm BH.
- Xuất file Excel nộp cho cơ quan bảo hiểm theo chuẩn.
