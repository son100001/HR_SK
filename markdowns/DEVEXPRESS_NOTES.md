# 📝 DevExpress Controls Notes & Troubleshooting

Tài liệu này lưu trữ các lưu ý, thủ thuật và cách giải quyết các vấn đề thường gặp đối với các control của thư viện DevExpress được sử dụng trong project.

---

## 1. DevExpress.XtraEditors.LookUpEdit

### 1.1 Hiện tượng không hiển thị giá trị (Blank Text) khi đã set EditValue
**Vấn đề:** 
Khi gán dữ liệu cho `LookUpEdit` (ví dụ: `departmentcode.EditValue = "Mã nào đó"` hoặc gọi hàm `tvcn.NhapDuLieuTuGridLenFormNhap`), control hiển thị một ô trống thay vì hiển thị tên (DisplayMember).

**Nguyên nhân:** 
`LookUpEdit` bị ràng buộc bởi một danh sách `DataSource` (thường là một `DataTable`). Cơ chế hoạt động của `LookUpEdit` là nó sẽ lấy `EditValue` đối chiếu với cột `ValueMember` trong `DataSource`, nếu trùng khớp, nó sẽ lấy giá trị ở cột `DisplayMember` để hiển thị lên màn hình (thuộc tính `Text`).
Nếu mã bạn gán cho `EditValue` **KHÔNG TỒN TẠI** trong `DataSource`, control sẽ không biết phải hiển thị tên gì, dẫn đến việc ô textbox của nó hoàn toàn trống.

**Cách giải quyết (Fallback Logic):**
Trong trường hợp dữ liệu được load từ một nguồn khác (ví dụ từ Database lịch sử nhân viên) có mã hoặc tên, nhưng mã đó không còn nằm trong danh mục hiện tại (ví dụ danh mục phòng ban đã đổi), ta cần phải chủ động chèn thêm một dòng dữ liệu tạm vào `DataSource` của control trước khi gán lại `EditValue`.

**Code mẫu tham khảo:**
```vb
' Ví dụ gán departmentcode nhưng departmentcode không có trong danh mục
Dim dt As DataTable = TryCast(departmentcode.Properties.DataSource, DataTable)

' Nếu DataSource chưa được khởi tạo, ta tạo cấu trúc cơ bản
If dt Is Nothing Then
    dt = New DataTable()
    dt.Columns.Add("Code", GetType(String))
    dt.Columns.Add("Name", GetType(String))
    departmentcode.Properties.DataSource = dt
    departmentcode.Properties.ValueMember = "Code"
    departmentcode.Properties.DisplayMember = "Name"
End If

' Kiểm tra xem Mã cần gán đã có trong DataSource chưa
Dim found As Boolean = False
For Each r As DataRow In dt.Rows
    If r("Code").ToString() = deptCode Then
        found = True
        Exit For
    End If
Next

' Nếu chưa có, tiến hành chèn thêm dòng tạm để LookUpEdit có thể hiển thị
If Not found Then
    Dim newRow As DataRow = dt.NewRow()
    newRow("Code") = deptCode
    newRow("Name") = deptName ' Tên hiển thị dự phòng
    dt.Rows.Add(newRow)
End If

' Sau khi chèn xong mới gán EditValue
departmentcode.EditValue = deptCode
```
*Ghi chú: Việc này không làm thay đổi dữ liệu danh mục dưới cơ sở dữ liệu, mà chỉ chèn tạm thời vào bộ nhớ trên giao diện (RAM) để control có dữ liệu đối chiếu và hiển thị.*
