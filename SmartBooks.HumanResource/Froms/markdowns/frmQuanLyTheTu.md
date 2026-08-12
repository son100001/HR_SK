# frmQuanLyTheTu – Quản lý thẻ từ (RFID) của nhân viên

## Vị trí file
- `Froms/frmQuanLyTheTu.vb`, `frmQuanLyTheTu.Designer.vb`, `frmQuanLyTheTu.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu: `HR_Transfer` (`HRFORM_TableName`) – bảng dùng chung cho nhiều loại "chuyển đổi/gán mã" của nhân viên, ở form này được dùng riêng cho gán **thẻ từ RFID**
- Stored procedure Lưu: `usp_InsertUpdateHR_Transfer` (`HRFORM_SaveStore`, và cũng được gọi trực tiếp trong hàm `Save()` riêng của form)
- Stored procedure Xóa: `usp_DeleteHR_Transfer` (`HRFORM_DeleteStore`)

## Mục đích
Gán/cập nhật **mã thẻ từ (RFID)** dùng để chấm công/ra vào cho từng nhân viên, có ngày hiệu lực và ghi chú; đồng thời hiển thị thẻ từ hiện tại của nhân viên đang chọn để tiện đối chiếu trước khi đổi. Đây là một biến thể tái sử dụng bảng `HR_Transfer` (bảng "chuyển đổi" dùng chung), với `TypeOfTransfer` và `AssignType` luôn được ghi cứng là `"RFID"`.

## Bố cục giao diện
Form gồm 1 tab "General" chia 3 vùng ngang (`TableLayoutPanel2`) + grid danh sách bên dưới:

| Vùng | Control | Kiểu | Ý nghĩa |
|---|---|---|---|
| Tìm kiếm (`pnSearch`) | `lblEmployee_ID` + `Employee_ID` | Label + LookUpEdit | Mã nhân viên |
| Tìm kiếm (`pnSearch`) | `btnSearch` | SimpleButton ("Tìm") | Tìm kiếm |
| Nhập liệu (`pnDuLieuNhap`) | `lblCurrentlyRFID` + `OldRFID` | Label + TextBox (readonly theo logic) | "RFID hiện tại" – RFID đang gán cho nhân viên, tự động nạp khi gõ mã NV |
| Nhập liệu (`pnDuLieuNhap`) | `lblRFID` + `RFID` | Label + LookUpEdit | Mã thẻ từ mới cần gán |
| Nhập liệu (`pnDuLieuNhap`) | `lblEffectiveDate` + `EffectiveDate` | Label + DateEdit | Ngày hiệu lực (mặc định = hôm nay khi mở form) |
| Nhập liệu (`pnDuLieuNhap`) | `lblRemark` + `Remark` | Label + RichTextBox | Ghi chú |
| Lưu (`pnLuu`) | `btnSave` | SimpleButton ("Lưu") | Lưu bản ghi gán thẻ |
| Danh sách | `GridControl1` / `GridView1` | DevExpress Grid | Lịch sử gán thẻ từ, có cột `TypeOfTransfer`, `AssignType`,... |

## Danh sách nút & tác dụng

| Nút | Sự kiện | Tác dụng |
|---|---|---|
| **Tìm** (`btnSearch`) | `btnSearch_Click` | Gọi `Search()` |
| **Lưu** (`btnSave`) | `btnSave_Click` | Xử lý theo thứ tự: 1) Nếu `QuyenHRFORM = "View"` → cảnh báo "Bạn không có quyền thay đổi" và dừng lại. 2) Kiểm tra 2 trường bắt buộc `{"Employee_ID","RFID"}` qua `tvcn.CheckErrorProvider`. 3) Hiện hộp thoại xác nhận "Bạn có thực sự muốn lưu?" (Yes/No). 4) Nếu Yes → gọi hàm `Save(...)` nội bộ; nếu thành công gọi lại `Search()`. 5) Focus lại `Employee_ID` |
| Các nút chuẩn `HRFORM` | kế thừa | `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False` → nhập liệu trực tiếp trên panel |

## Luồng xử lý

1. **`frmQuanLyTheTu_Load`**
   - `tvcn.ThemDauSaoChoTruongBuocNhap(XtraTabControl1, HRFORM_TableName)` – đánh dấu (*) trường bắt buộc (áp dụng cho cả `XtraTabControl1` thay vì chỉ `TableLayoutPanel2` như đa số form khác).
   - Đọc danh sách `select Category as Code, Name<Lan> as Name from [dbo].[HR_Category] where CategoryFather = 'phongban'` rồi nạp vào dropdown `RFID` qua `tvcn.GetDataOnDropDownCategoryCodeName(RFID, tabRFID)`. **Lưu ý bất thường**: nguồn dữ liệu cho danh mục "RFID" lại là danh mục con của `'phongban'` (phòng ban) trong `HR_Category`, chứ không phải danh sách thẻ từ thực tế – nhiều khả năng là sai sót copy-paste từ form khác, cần xác minh lại với người phát triển gốc nếu muốn sửa.
   - `EffectiveDate.EditValue = Today`.
   - `LoadGiaoDienTheoDieuKien()` **không được gọi trực tiếp** trong `Load` (dòng gọi bị comment).

2. **`Search()`**
   - Build: `exec [dbo].[sp_BangChuyenViTri] '1900-1-1','<Today+100 ngày>',5,'<Lan>',NULL,NULL,NULL,NULL,NULL,NULL,N'<Employee_ID.Text>'` (tham số loại `5` phân biệt với các loại "chuyển đổi" khác dùng chung stored procedure `sp_BangChuyenViTri`; 6 tham số phân quyền theo cơ cấu tổ chức đều `NULL`, chỉ lọc theo `Employee_ID`).
   - `Xem(...)` đổ dữ liệu lên grid, lưu `HRFORM_QueryView`.

3. **`Save(ID, Employee_ID, TransferCode, EffectiveDate, TypeOfTransfer, AssignType, Remark)` (hàm riêng, không phải override của HRFORM)**
   - Gọi trực tiếp: `exec usp_InsertUpdateHR_Transfer <ID>,'<Employee_ID>','<RFID.EditValue>','<EffectiveDate>','RFID','RFID',<Remark>,'<yyyy-MM-dd HH:mm:ss>','<UserName>'` – **lưu ý**: hàm nhận tham số `TransferCode` nhưng bên trong lại dùng lại `RFID.EditValue` thay vì tham số truyền vào; `TypeOfTransfer`/`AssignType` bị ghi cứng `"RFID"` bất kể tham số truyền vào.
   - Đọc cột `ThongBao` trả về: nếu khác rỗng → hiển thị lỗi qua `tvcn.GetLanguagesTranslated`, trả về `False`.
   - Nếu không lỗi → hiển thị "Nhập thành công", trả về `True`.

4. **`AfterViewForm()` (override)** – sau khi hiển thị dữ liệu lên grid: khóa không cho sửa trực tiếp cột `TypeOfTransfer` trên grid, ẩn cột `AssignType`.

5. **`AfterImportExcel()` (override)** – sau khi import Excel, với mọi dòng vừa nhập vào grid: gán cứng `block_date = "RFID"` và `AssignType = "RFID"`, đảm bảo dữ liệu import qua Excel vẫn được đánh dấu đúng loại RFID.

6. **`XtraTabControl1_SelectedPageChanged`** – gọi `HRFORM_XtraTabControl_SelectedTabChanged`, `LoadGiaoDienTheoDieuKien()` và `Search()` khi đổi tab.

7. **`Employee_ID_TextChanged`** – khi mã nhân viên thay đổi: gọi `Search()`, xóa `OldRFID.Text`, rồi truy vấn `select RFID from udf_EmployeeFilter('',null,null,null,null,null,null,'<Employee_ID>',getdate())` để hiển thị RFID hiện tại của nhân viên vào ô `OldRFID`. **Lưu ý**: hàm này **không có mệnh đề `Handles`** trong code hiện tại, nên về nguyên tắc sẽ không tự động được gọi khi người dùng gõ vào ô `Employee_ID` trừ khi được gắn `AddHandler` ở nơi khác không thấy trong 2 file này – cần kiểm tra thêm khi bảo trì nếu tính năng "hiện RFID hiện tại" không hoạt động như mong đợi.

8. **`Employee_ID_EditValueChanged`** – khai báo nhưng dòng `Search()` bị comment.

9. **`Employee_ID_KeyUp`** – khai báo nhưng không có `Handles`, tương tự không được gọi tự động.

10. **`GridControl1_KeyUp`** – ủy quyền phím tắt chuẩn cho `Gridview_KeyUp`.

## Ghi chú kỹ thuật
- Form dùng chung bảng `HR_Transfer` với các nghiệp vụ "chuyển đổi vị trí/mã" khác trong hệ thống (tương tự cách `frmHeavyAndToxic` dùng chung `HR_TransferFloatType`) – phân biệt bằng cặp giá trị cố định `TypeOfTransfer = 'RFID'`, `AssignType = 'RFID'` và tham số loại `5` trong `sp_BangChuyenViTri`.
- Có 3 sự kiện khai báo nhưng thiếu `Handles` (`Employee_ID_TextChanged`, `Employee_ID_KeyUp`) – nên coi là **code khả nghi/không chắc được thực thi**, cần rà soát lại trước khi dựa vào các tính năng liên quan (hiển thị RFID hiện tại, mở popup chọn nhân viên bằng F3) khi vận hành thực tế.
- Nguồn dữ liệu dropdown `RFID` lấy từ danh mục con của `'phongban'` trong `HR_Category` thay vì danh sách thẻ từ – khả năng cao là lỗi cấu hình danh mục, nên xác minh với nghiệp vụ thực tế/CSDL trước khi coi đây là hành vi đúng.
- Có bước xác nhận Yes/No trước khi lưu và kiểm tra quyền `"View"` thủ công ngay trong `btnSave_Click`, giống mô hình an toàn bổ sung đã thấy ở `frmEmpNonRegisInsurance` (module BaoHiem).
