# SmartBooks.BL.TimeKeeping – Tài liệu Flow & Mapping

> **Vai trò:** Business Logic layer cho module **Chấm công** (TimeKeeping).
> Chứa toàn bộ logic tính giờ, ca làm việc, tăng ca, nghỉ phép, và tổng hợp công.

---

## Cấu trúc thư mục

```
SmartBooks.BL.TimeKeeping/
├── clsTimeKeeping.vb          ← Class CHÍNH – logic chấm công (46KB)
├── clsDateTimeChecking.vb     ← Class kiểm tra & xử lý ngày giờ (14KB)
└── SmartBooks.BL.TimeKeeping.vbproj
```

---

## clsTimeKeeping – Class chấm công chính

**File:** [clsTimeKeeping.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.BL.TimeKeeping/clsTimeKeeping.vb) (~46KB)

### Chức năng chính

| Nhóm | Mô tả |
|---|---|
| Tính ca chính | Xác định ca chính (MainShift) của NV dựa trên bảng `HR_EmpRegisTimeSheet` |
| Tính giờ vào/ra | So sánh thời gian quẹt thẻ với ca đăng ký |
| Tính tăng ca (OT) | Tính giờ OT trước ca, sau ca, theo loại OT |
| Tính nghỉ phép | Tính ngày phép, loại phép (có lương/không lương/thai sản) |
| Tính suất ăn | Đếm suất ăn trưa, ăn tăng ca |
| Tính công | Tổng hợp công ngày → công tháng |
| Đồng bộ | Đồng bộ dữ liệu quẹt thẻ → bảng công |

### Properties chấm công

| Property | Kiểu | Mô tả |
|---|---|---|
| `Employee_ID` | String | Mã nhân viên |
| `ShiftName` | String | Tên ca |
| `TimeIn` / `TimeOut` | DateTime | Giờ vào / ra thực tế |
| `ShiftTimeIn` / `ShiftTimeOut` | DateTime | Giờ vào / ra theo ca |
| `OT_Hour` | Double | Số giờ tăng ca |
| `LateMins` / `EarlyMins` | Double | Số phút đi trễ / về sớm |
| `LeaveType` | String | Loại phép (nếu nghỉ) |
| `WorkDay` | Double | Số ngày công (0, 0.5, 1) |

---

## clsDateTimeChecking – Kiểm tra ngày giờ

**File:** [clsDateTimeChecking.vb](file:///e:/SourceCodeHR/POCONS/SmartBooks.BL.TimeKeeping/clsDateTimeChecking.vb) (~14KB)

### Chức năng chính

| Method | Mô tả |
|---|---|
| `IsHoliday(date)` | Kiểm tra có phải ngày lễ |
| `IsSunday(date)` | Kiểm tra Chủ nhật |
| `IsSaturday(date)` | Kiểm tra Thứ 7 |
| `GetWorkingDays(from, to)` | Đếm ngày làm việc trong khoảng |
| `GetOTType(date)` | Xác định loại OT (ngày thường/cuối tuần/lễ) |
| `RoundTime(time, interval)` | Làm tròn thời gian theo interval |

---

## Luồng xử lý chấm công

```
Quẹt thẻ vân tay (máy chấm công)
    │
    └── Import vào bảng HR_AccessData
            │
            └── Đồng bộ → SmartBooks.BL.TimeKeeping
                    │
                    ├── clsDateTimeChecking
                    │   ├── Xác định ngày lễ / cuối tuần
                    │   └── Phân loại OT
                    │
                    └── clsTimeKeeping
                        ├── 1. Lấy ca đăng ký (HR_EmpRegisTimeSheet)
                        ├── 2. So khớp thời gian quẹt với ca
                        ├── 3. Tính giờ vào/ra thực tế
                        ├── 4. Tính trễ/sớm
                        ├── 5. Tính OT
                        ├── 6. Kiểm tra nghỉ phép
                        ├── 7. Tính công (0 / 0.5 / 1)
                        └── 8. Ghi vào bảng Timekeeping_Date1
```

---

## Dependency

```
SmartBooks.BL.TimeKeeping
    │
    ├──► SmartBooks.BusinessLogic (KetNoiCSDL, DbAccess)
    └──► Appsettings (DbSetting)
```
