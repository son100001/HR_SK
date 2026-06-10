# Template: Tạo Form Nghiệp Vụ Mới (POCONS HR)

> **Mục đích:** Hướng dẫn tạo một form nghiệp vụ mới từ đầu.
> Copy template này và điều chỉnh cho form cụ thể.

---

## Bước 1: Tạo Form

1. Thêm **Windows Form** mới vào `SmartBooks.HumanResource\Froms\`
2. Đặt tên: `frm{TenChucNang}.vb` (ví dụ: `frmAward.vb`)
3. Trong Designer, set **Inherits** = `WindowsControlLibrary.HRFORM`

## Bước 2: Code Behind – Boilerplate

```vb
' ===================================================================
' File: frm{TenChucNang}.vb
' Inherits: WindowsControlLibrary.HRFORM (qua Designer)
' Table:    {TEN_BANG_DB}
' ===================================================================

' Khai báo các biến dùng chung
Dim kn As New connect(WindowsControlLibrary.DbSetting.dataPath)
Dim obj As New WindowsControlLibrary.DbSetting
Dim tvcn As New WindowsControlLibrary.ThuVienChucNang

' ===================== FORM LOAD =====================
Private Sub frm{TenChucNang}_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ' 1. Set bảng DB chính
    HRFORM_TableName = "{TEN_BANG_DB}"
    
    ' 2. Set quyền
    Quyen = tvcn.KiemTraQuyen("{MA_CHUC_NANG}")
    
    ' 3. Đánh dấu trường bắt buộc (dấu * đỏ)
    tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel1, HRFORM_TableName)
    
    ' 4. Load dropdown data
    tvcn.SearchEmployee(Employee_ID)                              ' Dropdown nhân viên
    tvcn.GetDataOnDropDownCategoryCodeName(cbbLoai, "LoaiDanhMuc") ' Dropdown danh mục
    
    ' 5. Set giá trị mặc định
    dtNgay.EditValue = Today
    
    ' 6. Load giao diện (ẩn/hiện nút theo quyền + config)
    LoadGiaoDienTheoDieuKien()
    
    ' 7. Tìm kiếm dữ liệu
    Search()
End Sub

' ===================== TÌM KIẾM =====================
Private Sub Search()
    Dim QR As String = "exec [dbo].[sp_{TEN_BANG_DB}] " & _
                       "'" & Employee_ID.Text & "', " & _
                       "'" & Format(FromDate.EditValue, "yyyy-MM-dd") & "', " & _
                       "'" & Format(ToDate.EditValue, "yyyy-MM-dd") & "'"
    Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
    HRFORM_QueryView = QR
End Sub

' ===================== SAU KHI LOAD GRID =====================
Public Overrides Sub AfterViewForm()
    ' Tùy chỉnh grid sau khi load
    ' Thêm dropdown cho cột grid nếu cần:
    tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "COLUMN_NAME", kn.ReadData("SELECT Code, Name FROM DanhMuc", "T"))
End Sub

' ===================== TRƯỚC KHI LƯU =====================
Public Overrides Function BeforeSave() As Integer
    ' Validate dữ liệu trước khi lưu
    If Employee_ID.Text = "" Then
        MsgBox("Vui lòng chọn nhân viên")
        Return 0  ' DỪNG, không lưu
    End If
    Return 1  ' TIẾP TỤC lưu
End Function

' ===================== SAU KHI LƯU =====================
Public Overrides Sub AfterSave()
    ' Refresh lại dữ liệu sau khi lưu
    Search()
End Sub

' ===================== TRƯỚC KHI XÓA =====================
Public Overrides Function BeforeDelete() As Integer
    ' Validate trước khi xóa
    Return 1
End Function

' ===================== SAU KHI XÓA =====================
Public Overrides Sub AfterDelete()
    Search()
End Sub

' ===================== KEYBOARD SHORTCUT =====================
Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
    Gridview_KeyUp(sender, e)
End Sub
```

## Bước 3: Designer Config

Trong **Designer** của form, cần set các property HRFORM:

```
HRFORM_TableName = "{TEN_BANG_DB}"          ' Bảng DB chính
HRFORM_GridControl = GridControl1            ' DevExpress GridControl
HRFORM_Gridview = GridView1                  ' DevExpress GridView
HRFORM_TypeOfForm = View                     ' View/Input/ViewInput
HRFORM_InputForm = "frm{TenChucNang}Input"   ' Tên form nhập (nếu có)
```

### Ẩn/Hiện nút toolbar

```
HRFORM_VisibleControl_Xem = True             ' Nút Xem
HRFORM_VisibleControl_ThemMoi = True          ' Nút Thêm
HRFORM_VisibleControl_Sua = True              ' Nút Sửa
HRFORM_VisibleControl_Luu = True              ' Nút Lưu
HRFORM_VisibleControl_Xoa = True              ' Nút Xóa
HRFORM_VisibleControl_ExportExcel = True      ' Nút Export Excel
HRFORM_VisibleControl_ImportExcel = False      ' Nút Import Excel
HRFORM_VisibleControl_cbbReport = True        ' ComboBox báo cáo
HRFORM_VisibleControl_ThucHien = True         ' Nút Thực hiện
```

## Bước 4: Form Nhập (Nếu TypeOfForm = View)

Nếu form chính là **View** (danh sách), tạo thêm form nhập:

```vb
' frm{TenChucNang}Input.vb – Inherits HRFORM
' TypeOfForm = Input
' HRFORM_TuDongDongSauKhiLuu = True

Private Sub frmInput_Load(...)
    HRFORM_TableName = "{TEN_BANG_DB}"
    HRFORM_TypeOfForm = TypeOfForm.Input
    
    ' Map dữ liệu từ grid lên form nhập
    tvcn.NhapDuLieuTuGridLenFormNhap(Me, HRFORM_TableName)
    
    ' Dịch ngôn ngữ
    tvcn.ChangeLanguageToForm(Me, KeyOfForm1, 1)
End Sub
```

## Bước 5: Nguyên Tắc Mapping Control & Cột Database (QUAN TRỌNG)

Khi lưu hoặc load dữ liệu, hệ thống tự động map giữa Control trên form và cột trong database dựa vào **Tên (Name) của Control**.

1. **Đặt tên Control nhập liệu (TextBox, DateEdit, CheckBox, LookUpEdit...):**
   - Bắt buộc phải đặt `Name` của control **GIỐNG HỆT** với tên cột tương ứng trong database (`HRFORM_TableName`). 
   - *Hệ thống tự động dùng hàm `tvcn.LuuHoacXoaTuForm` để quét tất cả control có `Name` trùng với cột trong DB để lưu dữ liệu.*
   - Ví dụ: Cột trong DB tên là `FullName`, thì TextEdit trên form cũng phải đặt `Name` = `FullName`.

2. **Đặt tên Label bắt buộc (Require):**
   - Nếu cột đó `IS_NULLABLE = 'NO'` trong CSDL, bạn cần tạo một Label để hiển thị tên trường đó.
   - Bắt buộc phải đặt `Name` của Label theo cú pháp: `lbl` + `Tên Control` (hoặc `LBL...`).
   - Hàm `tvcn.ThemDauSaoChoTruongBuocNhap` sẽ tự động tìm Label này để gắn thêm dấu `*` đỏ, và hàm save sẽ tự động bắt lỗi nếu bỏ trống control đó.
   - Ví dụ: Control nhập là `FullName`, thì Label tương ứng phải đặt `Name` = `lblFullName`.

3. **Cơ chế lưu tự động (HRFORM):**
   - Khi bấm nút Lưu, hàm `HRFORM.BeforeSave` được gọi trước.
   - Sau đó `tvcn.AddNewOrEdit` và `tvcn.LuuHoacXoaTuForm` sẽ tự động ghép tên cột trong DB `HRFORM_TableName` với giá trị lấy từ các control (ví dụ `TextBox.Text`, `LookUpEdit.EditValue`, `DateEdit.DateTime`...) và tạo câu lệnh SQL thực thi. Bạn không cần phải tự viết code INSERT/UPDATE tay.

## Bước 6: Stored Procedure

Tạo stored procedure trên SQL Server:

```sql
-- SP Xem danh sách
CREATE PROCEDURE [dbo].[sp_{TEN_BANG_DB}]
    @Employee_ID NVARCHAR(50) = '',
    @FromDate DATE = NULL,
    @ToDate DATE = NULL
AS
BEGIN
    SELECT * FROM {TEN_BANG_DB}
    WHERE (@Employee_ID = '' OR Employee_ID = @Employee_ID)
      AND (@FromDate IS NULL OR NgayTao >= @FromDate)
      AND (@ToDate IS NULL OR NgayTao <= @ToDate)
    ORDER BY NgayTao DESC
END

-- Bảng HR_Report: thêm config báo cáo cho form
INSERT INTO HR_Report (ReportFather, ReportCode, ReportName, ...)
VALUES ('frm{TenChucNang}', 'RP_{CODE}', N'Tên báo cáo', ...)
```

## Bước 7: Menu & Phân quyền

1. Thêm vào bảng `HR_Menu` để form hiện trong menu
2. Thêm phân quyền: `INSERT INTO [Permission] (FormID, ...) VALUES ('frm{TenChucNang}', ...)`

---

## Checklist tạo form mới

- [ ] Tạo form `.vb` trong `Froms/`, Inherits HRFORM
- [ ] Set `HRFORM_TableName`, `HRFORM_GridControl`, `HRFORM_Gridview`
- [ ] Set `HRFORM_TypeOfForm` (View/Input/ViewInput)
- [ ] Ẩn/hiện buttons toolbar theo nghiệp vụ
- [ ] Override `BeforeSave()`, `AfterViewForm()` nếu cần
- [ ] Tạo hàm `Search()` với query/stored proc
- [ ] Tạo stored procedure trên DB
- [ ] Thêm vào bảng `HR_Menu` và `HR_Report`
- [ ] Set phân quyền trong bảng `Permission`
- [ ] Test: Load → Thêm → Sửa → Lưu → Xóa → Export Excel
