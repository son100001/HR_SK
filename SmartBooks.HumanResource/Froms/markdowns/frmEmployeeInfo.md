# frmEmployeeInfo – Thông tin nhân viên (Hồ sơ nhân sự)

## Vị trí file
- `Froms/frmEmployeeInfo.vb`, `frmEmployeeInfo.Designer.vb`, `frmEmployeeInfo.resx`
- Kế thừa: `WindowsControlLibrary.HRFORM`
- Bảng dữ liệu chính: `SmartBooks_Employee` (`HRFORM_TableName = "SmartBooks_Employee"`)
- Stored procedure Lưu: `usp_InsertUpdateSmartBooks_Employee` (`HRFORM_SaveStore`)
- Stored procedure Xóa: `usp_DeleteEmployeeInformation` (`HRFORM_DeleteStore`)
- `HRFORM_TypeOfForm = ViewInput`, `HRFORM_VisibleControl_ThemMoi = False`, `HRFORM_VisibleControl_Sua = False`, `HRFORM_VisibleControl_GetTemplate = False`, `HRFORM_TuDongDongSauKhiLuu = False`

## Mục đích
Đây là **form phức tạp nhất** trong toàn bộ hệ thống HR: quản lý toàn bộ **hồ sơ lý lịch nhân viên** — từ thông tin cá nhân/CCCD, địa chỉ, cơ cấu tổ chức & hợp đồng lao động, trình độ chuyên môn, liên hệ khẩn cấp, ngân hàng/thẻ, sức khỏe, ảnh chân dung, cho tới các tiện ích quản trị (nhập nhân viên mới, cập nhật hàng loạt qua Excel, đổi mã nhân viên toàn hệ thống, chụp ảnh/quét QR CCCD trực tiếp bằng webcam). Việc nhập liệu thực hiện trực tiếp trên panel lớn (không qua popup `HRFORM_InputForm`), theo đúng cơ chế "nhập liệu tại chỗ" giống `frmInsurance`.

## Bố cục tổng thể
Form gồm `XtraTabControl1` với **3 tab lớn**: `General` (hồ sơ nhân viên), `NhapNVMoi` (nhập nhân viên mới – vị trí/chức vụ), `Utilities` (tiện ích). Sự kiện `XtraTabControl1_SelectedPageChanged` (`UltraTabControl1_SelectedTabChanged`) chuyển đổi `HRFORM_GridControl/Gridview`, ẩn/hiện các nút chuẩn, đổi `TypeOfReport` và gọi lại `Search(TypeOfReport)` mỗi khi đổi tab.

---

## Tab 1 – `General` (Hồ sơ nhân viên)

Bố cục 2 vùng:
- **Bên trái**: `GridControl1`/`GridView1` (Dock=Left, rộng 320px) – danh sách/kết quả tìm kiếm nhân viên, đổ dữ liệu từ `sp_BangThongTinNhanVien` (typeofreport = 1).
- **Bên phải**: `Panel1` (Dock=Fill) chứa `XtraTabControl2` → 1 trang duy nhất `MainInformation` (AutoScroll=True) – panel nhập liệu khổng lồ, chia thành nhiều **nhóm thông tin** đánh dấu bằng các label tiêu đề (`lblThongTinChinh`, `lblThongTinLienLac`, `lblThongTinNganHangThe`, `lblTrangThaiLamViec`, `lblTrinhDoChuyenMon`, `lblThongTinKhac`...).

### Nhóm "Tìm kiếm nhân viên"
| Control | Kiểu | Ý nghĩa |
|---|---|---|
| `EmployeeSearch` | LookUpEdit | Ô tìm nhanh nhân viên theo mã/tên (nạp qua `tvcn.SearchEmployee`) |
| `btnSearch` ("Tìm") | SimpleButton | Nạp hồ sơ nhân viên đang chọn lên form |
| `IsNhapNhanVienMoi` (checkbox, nhãn "Trạng thái làm việc") | CheckBox | Bật "chế độ nhập nhân viên mới" |

### Nhóm "Thông tin chính" (`lblThongTinChinh`)
| Field | Nhãn | Kiểu |
|---|---|---|
| `Employee_ID` | Mã nhân viên | TextBox (tự sinh mã tạm `C...` khi bật `IsNhapNhanVienMoi`) |
| `Employee_Lastname` / `Employee_Firstname` | Tên (Họ đệm/Tên) | TextBox |
| `Sex` | Giới tính | LookUpEdit (danh mục `Sex`) |
| `BirthDate` + `BirthDateFormat` | Ngày sinh | DateEdit + ComboBox chọn định dạng (`yyyy` hoặc đầy đủ ngày) |
| `BirthPlace` | Nơi sinh | TextBox |
| `NativePlace` | Nguyên quán | TextBox |
| `Nation` | Dân tộc | TextBox |
| `Nationality` | Quốc tịch | LookUpEdit (danh mục `Nationality`) |
| `TonGiao` | Tôn giáo | TextBox |
| `MaritalStatus` | Tình trạng hôn nhân | LookUpEdit (danh mục `MaritalStatus`, không có label riêng trong Designer) |
| `isTanTat` / `TanTat` | Bị tàn tật / mô tả | CheckBox bật thì `TanTat` (RichTextBox) được enable |
| `Qualification` | Chuyên môn | LookUpEdit (danh mục `Qualification`) |

### Nhóm "CCCD / Căn cước công dân" (quét QR)
| Field | Nhãn | Kiểu |
|---|---|---|
| `ID_number` | CCCD | TextBox |
| `ID_date` | Ngày cấp | DateEdit |
| `ID_place` | Cấp tại | TextBox |
| `NgayHetHanCCCD` | Ngày hết CCCD | DateEdit – **tự tính** theo tuổi khi đổi `BirthDate` hoặc khi quét QR |
| `CCCDCu` / `CCCDCu_Date` / `CCCDCu_Place` | CCCD Cũ / Ngày CCCD cũ / Đ/C CCCD cũ | TextBox/DateEdit/TextBox (thông tin CMND cũ) |
| `PictureCCCD` + `btnChonAnhCCCD`/`btnXoaAnhCCCD` | Ảnh CCCD | PictureBox – chọn ảnh mặt CCCD để giải mã QR |
| `cbbChonCam`, `btnStartCam`/`btnStopCam`, `PicCam`, `btnChup` | Camera / Chụp | Chụp trực tiếp bằng webcam qua AForge, tự động dò QR nền |

### Nhóm địa chỉ
| Field | Nhãn | Kiểu |
|---|---|---|
| `Address_Permanent` | Đ/C thường trú | `WindowsControlLibrary.Address` (control địa chỉ dùng chung) |
| `Address_Temporary` | Đ/C Tạm trú | `WindowsControlLibrary.Address` |
| `SoNhaThonXom` / `PhuongXa` / `QuanHuyen` / `TinhThanhPho` | Số nhà thôn xóm / Phường xã / Quận huyện / Tỉnh thành phố | TextBox (chi tiết địa chỉ rời) |

### Nhóm "Trạng thái làm việc" (`lblTrangThaiLamViec`) – Cơ cấu tổ chức & Hợp đồng
| Field | Nhãn | Kiểu |
|---|---|---|
| `Factory_ID` | Xưởng | LookUpEdit (`udf_Factory`) |
| `departmentcode` | Bộ phận | LookUpEdit – nạp lại cascade khi đổi `Factory_ID` |
| `sectioncode` | Phòng ban | LookUpEdit – nạp lại cascade khi đổi `departmentcode` |
| `teamcode` | Tổ | LookUpEdit (`udf_Team`) |
| `PositionCategory_ID` | Loại chức vụ | LookUpEdit (`SmartBooks_PositionCategory`) |
| `Position_ID` | Chức vụ | LookUpEdit (`SmartBooks_Position`) |
| `ChucDanh` | Chức danh | LookUpEdit (`hr_chucdanh`) |
| `JobCode` | Job code | TextBox |
| `RFID` | RFID | TextBox (mã thẻ chấm công) |
| `TypeOfHiring` | Loại tuyển dụng | LookUpEdit (danh mục `TypeOfHiring`) |
| `ContractFlow` | Luồng hợp đồng | LookUpEdit (`HR_ContractFlow`) |
| `StartedDate` | Ngày vào làm | DateEdit |
| `ComStartedDate` | Ngày vào công ty | DateEdit |
| `OfficialDate` | Ngày chính thức | DateEdit |
| `DecisionCode` / `DecisionStatus` | Mã quyết định / Trạng thái | TextBox / LookUpEdit (`DecisionStatus`) |
| `Employee_Status` | Trạng thái (làm việc) | LookUpEdit (danh mục `Employee_Status`) |
| `TernimationDate` / `PlanTernimationDate` | Ngày thôi việc / Ngày TV dự tính | DateEdit |
| `ResonTerminated` | Lý do (thôi việc) | TextBox |
| `isManager` | Là Quản lý | CheckBox |
| `IsSeasonWorker` / `EndOfSeasonWorker` | Công nhân thời vụ / Ký CN chính thức | CheckBox bật thì enable ô ngày ký chính thức |
| `isThuViec85PhanTram` | (Thử việc 85%) | CheckBox |
| `SoNgayPhepNam` | Số ngày phép năm | TextBox |
| `NgayTGCongDoan` | Ngày tham gia CĐ | DateEdit |
| `CamKet` | Cam kết | CheckBox |
| `AbsentStatus`, `IE_FLAG` | (không có nhãn riêng) | TextBox – cờ nội bộ |

### Nhóm "Trình độ chuyên môn" (`lblTrinhDoChuyenMon`)
| Field | Nhãn | Kiểu |
|---|---|---|
| `Qualification` | Chuyên môn | LookUpEdit |
| `Graduated` | Bằng cấp | TextBox |
| `GraduatedFrom` | Nơi cấp bằng | TextBox |

### Nhóm "Thông tin liên lạc" (`lblThongTinLienLac`)
| Field | Nhãn | Kiểu |
|---|---|---|
| `Tel` | Điện thoại | TextBox |
| `Email` | Email | TextBox |
| `NguoiLienHeGap` | Người liên hệ gấp | TextBox |
| `NguoiGT` | Người GT | TextBox |
| `QuanHeVoiChuHo` | Quan hệ với chủ hộ | LookUpEdit (danh mục `QuanHeGiaDinh`) |
| `TenChuHo` | Tên chủ hộ | TextBox |

### Nhóm "Thông tin Ngân hàng – Thẻ" (`lblThongTinNganHangThe`)
| Field | Nhãn | Kiểu |
|---|---|---|
| `BankName` / `BankCode` / `BankAccount` | Tên ngân hàng / Mã ngân hàng / Số tài khoản | TextBox |
| `DebitAccount` | Thẻ ghi nợ | TextBox |
| `MaSoThue` | Mã số thuế | TextBox |
| `Card_No` / `Card_Code` | Số thẻ / Mã thẻ | TextBox |
| `Accountcode1/2/3` | AccountCode1/2/3 | TextBox (nội bộ, chưa dịch) |
| `SoSoBaoHiem` | Số sổ BH | TextBox |

### Nhóm Sức khỏe
| Field | Nhãn | Kiểu |
|---|---|---|
| `Height` / `Weight` | Chiều cao / Cân nặng | NumericUpDown |
| `HealthCheckFee` | Tiền khám SK | TextBox |
| `Hospital` | Khám tại bệnh viện | RichTextBox |

### Nhóm "Thông tin khác" (`lblThongTinKhac`) & Ảnh
| Field | Nhãn | Kiểu |
|---|---|---|
| `CongViecPhaiLam` | Công việc phải làm | RichTextBox |
| `Remark` | Ghi chú | RichTextBox |
| `Picture` + `btnChonAnh`/`btnXoaAnh` | Ảnh | PictureBox – ảnh chân dung nhân viên, lưu dạng byte[] vào cột `picture` |
| `UserName` / `InsertDate` | UserName / InsertDate | TextBox/DateEdit – tự set khi lưu (`BeforeSave`) |

---

## Tab 2 – `NhapNVMoi` (Nhập nhân viên mới)
- Toàn bộ tab chỉ có `GridControl2`/`GridView2` (Dock=Fill), `HRFORM_TypeOfForm = View`, dữ liệu nạp từ `sp_BangThongTinNhanVien` với `typeofreport = 7`.
- `GridView2.OptionsView.NewItemRowPosition = Top` → cho phép **thêm dòng trực tiếp trên grid** (dòng thêm mới luôn nằm trên cùng), dùng để khai báo vị trí/chức vụ/xưởng-bộ phận cho nhân viên mới tuyển.
- Khi bấm **Lưu** trên tab này, `AfterSave()` gọi `exec sp_XuLyNhapNhanVienMoi '<UserName>'` để xử lý hàng loạt các dòng vừa nhập/sửa; nếu lỗi thì báo `Popup.Coloitrongquatrinhnhapvitrichucvu`.
- Nút Thêm/Sửa dạng popup, `btnGetTemplate` ẩn; `btnImportExcel` hiện (cho phép import Excel danh sách nhân viên mới, dùng cơ chế Import Excel chuẩn của `HRFORM`).

## Tab 3 – `Utilities` (Tiện ích quản trị)
Khi chọn tab này, toàn bộ thanh nút chuẩn của `HRFORM` (`cbbReport`, `btnExportExcel`, `btnGetTemplate`, `btnImportExcel`, `btnLuu`, `btnRemove`, `btnExcute`, `btnRefresh`) đều bị ẩn – tab này chỉ chứa các công cụ riêng:

| Nhóm | Control | Chức năng |
|---|---|---|
| Cập nhật hàng loạt bằng Excel | `TruongCapNhat` (LookUpEdit) | Chọn **1 trường** của bảng `Smartbooks_Employee` cần cập nhật hàng loạt (danh sách cột lấy từ `tvcn.GetColumnNameOfSQLTable`) |
| | `Url` + `btnUrl` | Chọn file Excel chứa dữ liệu cập nhật (cột A = Employee_ID, cột B = giá trị mới, dữ liệu bắt đầu từ dòng 8) |
| | `btnLayTemplate` | Tải file mẫu `Teamleate\TempCapNhatThongTinNhanVien.xlsx` |
| | `btnNhap` | Đọc file Excel bằng EPPlus, với mỗi dòng build câu `UPDATE Smartbooks_Employee SET <TruongCapNhat> = <value> ... WHERE Employee_ID = ...` và thực thi (tự ép kiểu theo `DATA_TYPE` của cột: `datetime`/`nvarchar`/khác) |
| Nhập ảnh hàng loạt | `FlowLayoutPanel1`, `btnNhapAnh` | Chọn nhiều file ảnh cùng lúc, lưu ảnh theo tên file = `Employee_ID` qua `tvcn.LuuAnhNhanVien` |
| Đổi mã nhân viên (`gbDoiMaNhanVien` – "Đổi mã nhân viên") | `txtMaNVCu` / `txtMaNVMoi` / `btnDoiMaNV` | Đổi **mã nhân viên trên toàn hệ thống**: lấy danh sách tất cả bảng có cột `Employee_ID` (`sp_BangChuaMaNhanVien`), rồi chạy `UPDATE <table> SET Employee_ID = '<mã mới>' WHERE Employee_ID = '<mã cũ>'` lần lượt trên từng bảng |

---

## Danh sách nút & tác dụng

### Nút chuẩn `HRFORM` (hiện/ẩn tùy theo tab đang chọn – xem `UltraTabControl1_SelectedTabChanged`)
| Nút | Ghi chú |
|---|---|
| `btnLuu` (Lưu) | Lưu hồ sơ nhân viên qua `usp_InsertUpdateSmartBooks_Employee`; ẩn ở tab `Utilities` |
| `btnRemove` (Xóa) | Xóa qua `usp_DeleteEmployeeInformation`; ẩn ở tab `Utilities` |
| `btnRefresh`, `cbbReport`, `btnExportExcel`, `btnExcute` | Theo cơ chế chung; ẩn hết ở tab `Utilities` |
| `btnGetTemplate` / `btnImportExcel` | Ẩn mặc định ở `General`; **chỉ hiện `btnImportExcel` ở `NhapNVMoi`** |
| `btnAdd`/`btnEdit` (Thêm/Sửa popup) | Ẩn hoàn toàn (`HRFORM_VisibleControl_ThemMoi/Sua = False`) vì nhập liệu trực tiếp trên panel |

### Nút đặc thù
| Nút | Sự kiện | Tác dụng |
|---|---|---|
| `btnSearch` (Tìm) | `btnSearch_Click` | Nạp hồ sơ nhân viên đang chọn ở `EmployeeSearch` lên form qua `NhapDuLieuLenForm` |
| `btnChonAnh` / `btnXoaAnh` | Click | Chọn/xóa ảnh chân dung nhân viên (`Picture`) |
| `btnChonAnhCCCD` / `btnXoaAnhCCCD` | Click | Chọn ảnh mặt CCCD, tự động giải mã QR code (ZXing) và điền các trường liên quan qua `ParseAndShow` |
| `btnStartCam` / `btnStopCam` | Click | Bật/tắt webcam (AForge), preview lên `PicCam`, chạy vòng lặp `DecodeLoop` dò QR nền mỗi ~300ms |
| `btnChup` (Chụp) | Click | Chụp snapshot từ khung hình camera mới nhất, gán vào `Picture.Image` |
| `btnDoiMaNV` (Đổi mã NV) | `btnDoiMaNV_Click` | Đổi mã nhân viên trên toàn bộ các bảng liên quan (xem mục Tab 3) |
| `btnLayTemplate` | Click | Tải template Excel cập nhật hàng loạt |
| `btnUrl` | Click | Mở `OpenFileDialog` chọn file Excel |
| `btnNhap` | `btnNhap_Click` | Thực hiện cập nhật hàng loạt 1 trường theo file Excel đã chọn |
| `btnNhapAnh` | Click | Nhập ảnh hàng loạt từ nhiều file, đặt tên theo `Employee_ID` |
| `BirthDateFormat` (ComboBox) | `SelectedIndexChanged` | Đổi `EditMask` của `BirthDate` giữa `"yyyy"` và `"d"` |

---

## Luồng xử lý

### 1. `frmEmployeeInfo_Load`
- Set `HRFORM_SaveStore = "usp_InsertUpdateSmartBooks_Employee"`.
- Nạp danh mục tìm kiếm nhân viên (`tvcn.SearchEmployee`) và **hàng loạt LookUpEdit**: `ContractFlow`, `ChucDanh`, `Employee_Status`, `Sex`, `MaritalStatus`, `Nationality`, `TypeOfHiring`, `DecisionStatus`, `Factory_ID`, `teamcode`, `Qualification`, `PositionCategory_ID`, `Position_ID`, `QuanHeVoiChuHo`.
- Ẩn `btnGetTemplate`/`btnImportExcel`; bỏ chọn `IsNhapNhanVienMoi` (gọi `NhapNhanVienMoi(False)`).
- Đánh dấu (*) trường bắt buộc trên `Panel1` theo cấu trúc bảng (`tvcn.ThemDauSaoChoTruongBuocNhap`).
- Liệt kê camera khả dụng vào `cbbChonCam`; khởi tạo `BarcodeReader` (ZXing, chỉ đọc QR_CODE, `TryHarder=True`).
- Gọi `Search(TypeOfReport)` (mặc định `TypeOfReport = 1`) để nạp grid `General`.

### 2. `NhapDuLieuLenForm(EmpID)` – nạp hồ sơ 1 nhân viên lên panel
- Gọi `sp_BangThongTinNhanVien` (kèm ngày hiện tại, `typeofreport=1`, tham số phân quyền cơ cấu tổ chức) lấy 1 dòng dữ liệu nhân viên.
- Dùng `tvcn.NhapDuLieuTuGridLenFormNhap` để đổ toàn bộ cột của dòng dữ liệu vào các control cùng tên trên `XtraTabControl2`.
- Xử lý riêng: nếu `departmentcode`/`sectioncode` không khớp danh mục hiện có, tự thêm dòng "ảo" vào `DataSource` của LookUpEdit để hiển thị đúng tên bộ phận/phòng ban (fallback khi dữ liệu cũ không còn trong danh mục).
- Nạp ảnh chân dung từ cột `picture` của `smartbooks_employee` vào `Picture.Image`.
- Nếu `EmpID` rỗng hoặc không có dữ liệu → `tvcn.ClearTextInControlOnForm(XtraTabControl2)` xóa trắng form.

### 3. `UltraTabControl1_SelectedTabChanged` (`XtraTabControl1.SelectedPageChanged`)
- Reset hiển thị các nút chuẩn về mặc định (hiện hết), sau đó tùy tab:
  - `General`: `HRFORM_GridControl/Gridview = GridControl1/GridView1`, `TypeOfForm.ViewInput`, `TypeOfReport = 1`, ẩn `btnGetTemplate`/`btnImportExcel`.
  - `NhapNVMoi`: `HRFORM_GridControl/Gridview = GridControl2/GridView2`, `TypeOfForm.View`, `TypeOfReport = 7`, hiện `btnImportExcel`, set `NewItemRowPosition = Top`.
  - `Utilities`: ẩn toàn bộ thanh nút chuẩn; nạp danh sách cột bảng `smartbooks_employee` (trừ `Employee_ID`) vào `TruongCapNhat`; disable `btnNhap`/`btnNhapAnh` nếu `QuyenHRFORM <> "EDIT"`.
- Gọi `LoadGiaoDienTheoDieuKien()` (base) rồi `Search(TypeOfReport)` để nạp lại grid tương ứng.

### 4. `Search(typeofreport)`
```
exec [dbo].[sp_BangThongTinNhanVien] '<today>','<today>',<typeofreport>,'<Lan>',
     N'<Factory>',N'<Dept>',N'<Section>',N'<Team>',N'<Position>','<PositionCategory>'
```
Đổ kết quả lên `HRFORM_GridControl/Gridview` qua `Xem(...)`, lưu `HRFORM_QueryView`.

### 5. Chọn nhân viên từ grid
`GridControl1_DoubleClick` → lấy `Employee_ID` của dòng đang chọn trên `GridView1` → gọi `NhapDuLieuLenForm`.
`EmployeeSearch_EditValueChanged` / `btnSearch_Click` → tương tự nhưng theo giá trị chọn ở LookUpEdit tìm kiếm.

### 6. `BeforeSave()` (override)
Chỉ áp dụng khi đang ở tab `General`: tự set `UserName.Text = DbSetting.UserName` và `InsertDate.EditValue = Now` trước khi lưu (audit người/ngày cập nhật cuối).

### 7. `AfterSave()` (override)
- Tab `General`: lưu ảnh chân dung (`Picture.Image`) thành PNG byte[] và gọi `kn.UpdateImagesInformation("UpdateImagesEmployee", ...)`; nếu không có ảnh thì `UPDATE ... SET picture = null`. Sau đó xóa trắng form (`ClearTextInControlOnForm`).
- Tab `NhapNVMoi`: chạy `exec sp_XuLyNhapNhanVienMoi '<UserName>'` để xử lý các dòng vừa khai báo vị trí nhân viên mới; báo lỗi nếu thất bại.

### 8. `AfterDelete()` (override)
Tab `General`: xóa trắng form sau khi xóa hồ sơ.

### 9. `NhapNhanVienMoi(isNhapNhanVienMoi As Boolean)` + `IsNhapNhanVienMoi_CheckedChanged`
- Bật/tắt (Enable) nhóm control cơ cấu tổ chức (`Factory_ID`, `departmentcode`, `sectioncode`, `teamcode`, `PositionCategory_ID`, `ChucDanh`, `RFID`, `TypeOfHiring`, `Position_ID`, `JobCode`, `IE_FLAG`) và xóa trắng chúng, xóa trắng toàn bộ `TextBox` con trong `XtraTabControl2` (đệ quy qua `ClearAllInputs`).
- Khi checkbox được **bật** (chế độ nhập nhân viên mới): gọi `sp_GexMaxEmployee_ID` lấy số lớn nhất rồi sinh mã tạm `Employee_ID = "C" + (Max+1)`. Khi **tắt**: xóa `Employee_ID`.

### 10. Cascading dropdown cơ cấu tổ chức
- `Factory_ID_EditValueChanged` → nạp lại `departmentcode` theo Factory (`udf_Department ... where Code like '<Factory>%'`).
- `departmentcode_EditValueChanged` → nạp lại `sectioncode` theo Department (`udf_Section ... where Code like '%<Dept>%'`).

### 11. Quét QR CCCD
- `btnChonAnhCCCD_Click`: chọn ảnh → `DecodeQrFromImage` (ZXing, tự phóng to ảnh nếu nhỏ) → nếu chuỗi kết quả chứa `"|"` thì `ParseAndShow(qrText)` tách các trường theo định dạng CCCD gắn chip VN (`SoCCCD|SoCCCDCu|HoTen|NgaySinh|GioiTinh|...|DiaChi|NgayCap`) và điền vào `ID_number`, `CCCDCu`, `Employee_Firstname/Lastname`, `BirthDate`, `Sex`, `Address_Permanent`, `ID_date`, đồng thời tính `NgayHetHanCCCD`.
- `StartCamera`/`StopCamera` + `DecodeLoop`: chạy nền (Task + CancellationToken), mỗi ~300ms crop vùng giữa khung hình camera, phóng to nếu cần, thử decode QR; nếu ra kết quả thì gọi `ParseAndShow` trên UI thread.
- `TinhNgayHetHanCCCD(birthDate)`: tính ngày hết hạn CCCD theo quy định (đổi CCCD khi đủ 25, 40, 60 tuổi; sau 60 tuổi không phải đổi nữa → cộng 100 năm).
- `BirthDate_EditValueChanged` cũng tự tính lại `NgayHetHanCCCD` mỗi khi đổi ngày sinh (độc lập với việc quét QR).
- `DecodeQR_FromImage_Robust` + các hàm phụ trợ (`RotateIfNeeded`, `ScaleIfNeeded`, `BoostContrast`): phiên bản dò QR "bền vững" hơn (thử nhiều góc xoay, nhiều vùng ROI, nhiều tỉ lệ phóng to, tăng tương phản) – hàm dự phòng, hiện chưa thấy được gọi trực tiếp từ luồng chính (có thể dùng khi ảnh CCCD khó đọc).

### 12. Đổi mã nhân viên (`btnDoiMaNV_Click`)
- Kiểm tra quyền (`QuyenHRFORM = "View"` → chặn), xác nhận bằng `MessageBox` Yes/No.
- Lấy danh sách toàn bộ bảng có cột `Employee_ID` qua `sp_BangChuaMaNhanVien`, lặp qua từng bảng chạy `UPDATE <table> SET Employee_ID = '<mã mới>' WHERE Employee_ID = '<mã cũ>'`. Nếu 1 bảng lỗi thì báo nhưng vẫn tiếp tục các bảng còn lại.

### 13. Cập nhật hàng loạt qua Excel (`btnNhap_Click`)
- Yêu cầu chọn `TruongCapNhat` + file Excel hợp lệ, xác nhận Yes/No.
- Đọc từng dòng từ dòng 8 trở đi (cột A = `Employee_ID`, cột B = giá trị), tự ép kiểu theo `DATA_TYPE` lấy từ `tvcn.GetInformationOfSQLTable("Smartbooks_Employee")`, build và chạy câu `UPDATE Smartbooks_Employee SET <field> = <value>, InsertDate = <now>, UserName = <user> WHERE Employee_ID = ...` cho từng dòng; nếu lỗi thì hỏi có tiếp tục không.

### 14. Phím tắt
`GridControl1_KeyUp` ủy quyền cho `Gridview_KeyUp` xử lý chuẩn của `HRFORM` (Ctrl+S/D/F/Q, F5).

---

## Ghi chú kỹ thuật
- Đây là form duy nhất (trong số các form đã khảo sát) tích hợp **webcam trực tiếp** (thư viện `AForge.Video`/`AForge.Video.DirectShow`) và **giải mã QR code** (`ZXing.Net`) để tự động điền thông tin từ CCCD gắn chip — kết hợp cả luồng "chụp ảnh rồi decode" và luồng "decode nền liên tục khi camera đang chạy".
- Form thao tác trên **nhiều bảng/nhiều stored procedure** ngoài `SmartBooks_Employee`: `sp_BangThongTinNhanVien` (xem/tìm kiếm, dùng chung cho cả 2 tab `General` và `NhapNVMoi` qua tham số `typeofreport`), `sp_XuLyNhapNhanVienMoi`, `sp_GexMaxEmployee_ID`, `sp_BangChuaMaNhanVien`, `usp_InsertUpdateSmartBooks_Employee`, `usp_DeleteEmployeeInformation`.
- Chức năng **"Đổi mã nhân viên"** ở tab `Utilities` là thao tác **rủi ro cao** vì update trực tiếp trên toàn bộ bảng có cột `Employee_ID` bằng chuỗi SQL động (không có transaction bao ngoài rõ ràng trong đoạn code khảo sát) – nên cân nhắc khi thao tác trên dữ liệu thật.
- Chức năng **cập nhật hàng loạt qua Excel** (`btnNhap`) build câu SQL động nối chuỗi trực tiếp từ giá trị Excel (không dùng parameterized query) – cần lưu ý dữ liệu đầu vào.
- Ảnh nhân viên (`Picture`) được lưu dạng `byte[]` (PNG) vào cột `picture` của `SmartBooks_Employee` qua `kn.UpdateImagesInformation`, tách biệt với `AfterSave` chung của `HRFORM` (ảnh không lưu qua `HRFORM_SaveStore`).
- `Address_Permanent`/`Address_Temporary` dùng control địa chỉ dùng chung `WindowsControlLibrary.Address` (không phải TextBox thường) — control này tự xử lý Tỉnh/Huyện/Xã theo cấu trúc địa chỉ chuẩn của hệ thống.
- Nhiều đoạn code cũ bị comment (khối `Gridex1_KeyUp`, `LoadDetailInfor`, `btnBrowsePic_Click`, `btnSaveImage_Click`, `cbbOfficialDate_ValueChanged`...) cho thấy form từng dùng `Infragistics.Win.UltraWinTabControl`/`GridEX` trước khi migrate sang DevExpress `XtraTabControl`/`GridView` — các control/sự kiện Infragistics không còn hoạt động, chỉ còn import dư (`Imports Infragistics.Win.UltraWinTabControl`).
- Form không override `AfterViewForm()`; toàn bộ tuỳ biến grid sau khi load được xử lý thủ công trong `UltraTabControl1_SelectedTabChanged` (đổi `HRFORM_GridControl/Gridview` theo tab) thay vì qua cơ chế `AfterViewForm` chuẩn.
- Không thấy form này mở trực tiếp các form con khác (kiểu `frmChuyenViTri`, `frmFamily`) trong đoạn code khảo sát — các nghiệp vụ liên quan (chuyển vị trí, quá trình công tác, gia đình...) nhiều khả năng được quản lý ở các form riêng khác trong `Froms/`, liên kết với nhân viên qua `Employee_ID` chứ không mở popup từ form này.
