# CommonLib – Tài liệu

> **Vai trò:** Thư mục chứa toàn bộ **DLL bên thứ 3** (third-party libraries) dùng cho solution.
> **KHÔNG có source code** – chỉ chứa DLL binary.

---

## Các thư viện chính

### DevExpress v20.1 (UI Controls)
| DLL | Chức năng |
|---|---|
| `DevExpress.XtraGrid.v20.1.dll` | GridControl, GridView |
| `DevExpress.XtraEditors.v20.1.dll` | TextEdit, DateEdit, LookUpEdit, ComboBox |
| `DevExpress.XtraBars.v20.1.dll` | BarManager, Menu, Toolbar |
| `DevExpress.XtraReports.v20.1.dll` | Report designer & viewer |
| `DevExpress.XtraCharts.v20.1.dll` | Charts |
| `DevExpress.BonusSkins.v20.1.dll` | Themes/Skins |
| `DevExpress.XtraLayout.v20.1.dll` | Layout control |
| `DevExpress.XtraPrinting.v20.1.dll` | Print engine |
| `DevExpress.Data.v20.1.dll` | Data processing |
| `DevExpress.Utils.v20.1.dll` | Utilities |

### Janus Controls v2 (Legacy Grid)
| DLL | Chức năng |
|---|---|
| `Janus.Windows.GridEX.v2.dll` | GridEX control (legacy grid) |
| `Janus.Windows.ButtonBar.v2.dll` | Button bar |
| `Janus.Windows.CalendarCombo.v2.dll` | Calendar combo |
| `Janus.Windows.UI.v2.dll` | UI controls |
| `Janus.Windows.Schedule.v2.dll` | Schedule view |

### Infragistics v5.1 (Legacy Controls)
| DLL | Chức năng |
|---|---|
| `Infragistics.Win.UltraWinGrid.v5.1.dll` | UltraGrid |
| `Infragistics.Win.UltraWinToolbars.v5.1.dll` | Toolbars |
| `Infragistics.Win.UltraWinExplorerBar.v5.1.dll` | Explorer bar (menu dạng panel) |
| `Infragistics.UltraChart.v5.1.Design.dll` | Chart |
| `Infragistics.Excel.v5.1.dll` | Excel export |

### Crystal Reports
| DLL | Chức năng |
|---|---|
| `CrystalDecisions.CrystalReports.Engine.dll` | Report engine |
| `CrystalDecisions.Windows.Forms.dll` | WinForms viewer |
| `CrystalDecisions.Shared.dll` | Shared components |

### Excel/Data
| DLL | Chức năng |
|---|---|
| `EPPlus.dll` | Đọc/ghi Excel .xlsx (không cần Office) |
| `VBReport.dll` + `VBReport.XlsCrt.dll` | Tạo báo cáo Excel |
| `Interop.Excel.dll` | COM Interop Excel |
| `Interop.Microsoft.Office.Interop.Excel.dll` | Office Interop |

### Khác
| DLL | Chức năng |
|---|---|
| `Newtonsoft.Json.dll` | JSON serialize/deserialize |
| `JSON.NET.dll` | JSON processing |
| `Microsoft.ApplicationBlocks.Data.dll` | SqlHelper (Microsoft pattern) |
| `log4net.dll` | Logging framework |
| `FINDNET.dll` | Network discovery |
| `vnConvert.dll` | Chuyển đổi font chữ tiếng Việt |
| `Microsoft.Office.Interop.Word.dll` | Word automation (MailMerge) |

---

## Lưu ý

- **Không nên cập nhật** các DLL này trừ khi cần thiết – nhiều version cũ (Janus v2, Infragistics v5.1) có thể gây breaking changes.
- **DevExpress v20.1** là phiên bản chính đang dùng cho UI.
- Nếu thêm DLL mới, copy vào thư mục `CommonLib` và thêm reference trong `.vbproj` của project cần dùng.
