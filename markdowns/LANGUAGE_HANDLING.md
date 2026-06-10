# Hướng Dẫn Xử Lý Đa Ngôn Ngữ (Multi-Language)

> **Mục đích:** Tài liệu này giải thích cơ chế đa ngôn ngữ của POCONS HR và cách thêm/sửa đổi ngôn ngữ cho giao diện (UI) và báo cáo.

---

## 1. Vị trí lưu trữ file ngôn ngữ

Các file ngôn ngữ được hệ thống biên dịch lưu trữ tại thư mục output của project chính (`SmartBooks.HumanResource`), cụ thể:
- **Bản x86:** `E:\SourceCodeHR\POCONS\SmartBooks.HumanResource\bin\x86\Debug\lang\`
- **Bản x64:** `E:\SourceCodeHR\POCONS\SmartBooks.HumanResource\bin\x64\Debug\lang\`

*(Lưu ý: Khi deploy bản Release, thư mục `lang` này phải được copy đi kèm file `.exe`)*

### Các file chính:
1. `lang.VN.js`: File chứa từ điển Tiếng Việt (Format JSON).
2. `lang.EN.js`: File chứa từ điển Tiếng Anh (Format JSON).
3. `lang.KR.js`: File chứa từ điển Tiếng Hàn (Format JSON).
4. `LangAll.txd`: File XML tổng hợp tất cả ngôn ngữ.

---

## 2. Cấu trúc file ngôn ngữ

### Cấu trúc file `.js` (JSON)
Các file `.js` này không phải là Javascript code mà thực chất là **JSON Key-Value format**. 
- **Key:** Thường được cấu trúc theo dạng `{Tên_Phân_Hệ}.{Tên_Form}.{Tên_Control}` hoặc `{Từ_Khóa_Chung}`.
- **Value:** Text sẽ hiển thị trên giao diện tương ứng với ngôn ngữ đó.

*Ví dụ trong `lang.VN.js`:*
```json
{
  "General.Save": "Lưu",
  "General.Dong": "(&C) Đóng",
  "EmployeeInformation.frmAward": "Khen thưởng",
  "EmployeeInformation.frmEmployeeInfo.MaCu": "Mã NV cũ",
  "Popup.Luuthanhcong": "Lưu thành công."
}
```

### Cấu trúc file `.txd` (XML)
File `LangAll.txd` là file XML định nghĩa các thẻ `<text>` chứa giá trị dịch cho từng culture (ví dụ `<culture name="en">`).
```xml
<culture name="en">
    <text key="EmployeeInformation.frmAward">Award</text>
    <text key="General.Save">Save</text>
</culture>
```

---

## 3. Cơ chế hoạt động trong Code (ThuVienChucNang.vb)

Hệ thống sử dụng các hàm trong thư viện `ThuVienChucNang` để tự động map ngôn ngữ:

1. **Khởi tạo ngôn ngữ:** 
   - Khi chạy ứng dụng, biến toàn cục `DbSetting.Lan` sẽ lưu ngôn ngữ đang chọn (VD: `"VN"`, `"EN"`, `"KR"`).

2. **Dịch tự động cho Form (`ChangeLanguageToForm`)**:
   - Khi Form load, hàm `tvcn.ChangeLanguageToForm(Me, "KeyOfForm", ...)` được gọi.
   - Hàm này sẽ đọc file `lang.{DbSetting.Lan}.js`,### 3. Tìm key ngôn ngữ cho Control trên Form
Nếu bạn thêm một `Label` hoặc `Button` mới vào Form và muốn dịch nó, bạn cần biết chính xác hệ thống lấy key như thế nào.

**QUAN TRỌNG: Quy tắc tự động cắt bỏ tiền tố (Prefix Stripping)**
Hàm `AdjustCaption` trong `ThuVienChucNang.vb` của phần mềm có quy tắc tự động lược bỏ các tiền tố đặt tên control thông dụng **trước khi** dùng để map với key trong file JSON:
- Nếu tên control bắt đầu bằng `lbl` hoặc `btn` -> bị cắt đi 3 ký tự đầu. (VD: `lblEmail1` -> key là `Email1`)
- Nếu tên control bắt đầu bằng `lb` hoặc `bt` -> bị cắt đi 2 ký tự đầu. (VD: `lbFrommail` -> key là `Frommail`)
- Các control khác như CheckBox, RadioButton, hay `UiButton` -> giữ nguyên tên. (VD: `UiButton1` -> key là `UiButton1`)

**Ví dụ thực tế Form Gửi Email (PhieuLuongMoi):**
- Textbox Email từ: Tên control là `lbFrommail` -> Key là `Payroll.PhieuLuongMoi.Frommail` (Không phải `Payroll.PhieuLuongMoi.lbFrommail`)
- Textbox Mật khẩu: Tên control là `lbMatKhau` -> Key là `Payroll.PhieuLuongMoi.MatKhau`
- Button Gửi: Tên control là `btnGuiPhieuLuong` -> Key là `Payroll.PhieuLuongMoi.GuiPhieuLuong`
- Button khác: Tên control là `UiButton1` -> Key là `Payroll.PhieuLuongMoi.UiButton1`

Nếu không tìm thấy trong Form (`FormName.ControlName`), hệ thống sẽ tự động fallback sang tìm trong cấu hình chung (`General.ControlName`).

3. **Dịch các đoạn Text tùy chỉnh (`GetLanguagesTranslated`)**:
   - Đối với các MessageBox thông báo lỗi, cảnh báo, code sử dụng hàm:
     `MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuthanhcong"))`
   - Hàm này sẽ tra cứu chuỗi "Popup.Luuthanhcong" trong file json tương ứng và trả về text để show ra màn hình.

---

## 4. Cách thêm hoặc sửa đổi từ ngữ (Thêm/Sửa Language)

### Trường hợp 1: Sửa chữ sai hoặc thay đổi thuật ngữ hiện có
1. Xác định ngôn ngữ cần sửa (Ví dụ sửa Tiếng Anh -> mở `lang.EN.js`).
2. Tìm kiếm (Ctrl+F) từ khóa hiển thị đang bị sai hoặc tìm theo tên Form (VD: `frmAward`).
3. Chỉnh sửa phần **Value** (phần nằm sau dấu `:` và trong ngoặc kép).
   - *Lưu ý: TUYỆT ĐỐI không sửa phần Key (trước dấu `:`).*
4. Khởi động lại ứng dụng để cập nhật thay đổi.

### Trường hợp 2: Thêm Form mới hoặc Nút mới cần dịch
Khi bạn tạo một màn hình mới, ví dụ `frmNghiPhep` và có nút `btnApprove`.
1. Mở CẢ BA file `lang.VN.js`, `lang.EN.js`, `lang.KR.js`.
2. Thêm Key-Value mới vào cuối file (hoặc nhóm đúng chỗ cho gọn):
   - Vào file `lang.VN.js`: `"frmNghiPhep.btnApprove":"Duyệt",`
   - Vào file `lang.EN.js`: `"frmNghiPhep.btnApprove":"Approve",`
   - Vào file `lang.KR.js`: `"frmNghiPhep.btnApprove":"승인하다",`
   - *(Lưu ý cú pháp JSON: phải có dấu phẩy `,` ở cuối mỗi dòng nếu chưa phải dòng cuối cùng của object).*
3. Tại sự kiện `Form_Load` của form `frmNghiPhep`, hãy chắc chắn rằng bạn đã gọi hàm:
   `tvcn.ChangeLanguageToForm(Me, "frmNghiPhep", 0)`

### Trường hợp 3: Thêm câu thông báo (Popup MessageBox) mới
1. Mở CẢ BA file ngôn ngữ.
2. Thêm Key-Value mới bắt đầu bằng chữ `Popup.` (Để dễ quản lý).
   - `lang.VN.js` -> `"Popup.KhongTimThay":"Không tìm thấy dữ liệu!"`
   - `lang.EN.js` -> `"Popup.KhongTimThay":"Data not found!"`
3. Trong code VB.NET, gọi ra bằng lệnh:
   `MsgBox(tvcn.GetLanguagesTranslated("Popup.KhongTimThay"))`

---

## 5. Cảnh báo lỗi thường gặp
- **Lỗi dấu phẩy (JSON Syntax Error):** File `.js` là JSON chuẩn. Nếu bạn quên dấu phẩy ở giữa các dòng, hoặc có dấu phẩy thừa ở dòng cuối cùng, hệ thống sẽ **lỗi sập** khi load ngôn ngữ.
- **Cache / Build lại:** Nếu sửa file trong thư mục Source Code, hãy nhớ file ứng dụng thực thi sẽ nằm trong `bin/x86/Debug/lang/`. Phải đảm bảo bạn đang sửa đúng file ở thư mục output, hoặc phải chép đè từ source ra output.
- Đồng bộ các file: Nếu thêm 1 key mới, **BẮT BUỘC** phải thêm vào đủ tất cả các file ngôn ngữ (VN, EN, KR) để tránh lỗi không tìm thấy key khi user đổi ngôn ngữ.
- **Lỗi dịch thuật (Rò rỉ ngôn ngữ):** Tuyệt đối KHÔNG ĐƯỢC copy nguyên giá trị tiếng Việt từ `lang.VN.js` sang các file `lang.EN.js` và `lang.KR.js`. Nếu chưa có bản dịch, phải yêu cầu dịch thuật hoặc để trống một cách có chủ đích. Đối với file tiếng Hàn (`lang.KR.js`), KHÔNG ĐƯỢC chứa tiếng Anh hay tiếng Việt, mọi text trên màn hình (kể cả mã công hay viết tắt) đều phải được dịch chuẩn xác.
- **Lỗi Encoding (Ký tự Unicode bị mã hóa \uXXXX):** Trình phân tích JSON nội bộ của ứng dụng KHÔNG hỗ trợ đọc các ký tự Unicode dạng escape như `\u0110` (ví dụ: PowerShell `ConvertTo-Json` mặc định sinh ra định dạng này). Vì vậy, tuyệt đối KHÔNG DÙNG Script PowerShell bằng ConvertTo-Json để nối/sửa file `.js` tự động nếu chưa có logic chuyển `\uXXXX` về dạng text gốc. Hãy ưu tiên sửa tay bằng Notepad++ hoặc Visual Studio, lưu với định dạng **UTF-8 (có BOM)**.
