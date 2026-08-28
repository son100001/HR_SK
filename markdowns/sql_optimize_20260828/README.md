# Đợt tối ưu SQL + đồng bộ DDL — 2026-08-28 (`HR_SnK_Dev`)

Thư mục chứa 2 script công cụ sinh ra trong đợt làm việc ngày 2026-08-28. Nhật ký kết quả đầy đủ
(đo được gì, verify thế nào) nằm ở [../SQL_PERFORMANCE_HISTORY.md](../SQL_PERFORMANCE_HISTORY.md),
mục **`HR_SnK_Dev` — DB hiện hành**.

| File | Dùng để làm gì |
|---|---|
| [`Export-Ddl.ps1`](Export-Ddl.ps1) | Export toàn bộ procedure/function/table của 1 DB ra `Database/SQL/` đúng định dạng repo đang dùng (UTF-8 có BOM, CRLF). Chạy lại mỗi khi cần đồng bộ code DB xuống git. |
| [`Invoke-SqlScript.ps1`](Invoke-SqlScript.ps1) | Chạy file `.sql` qua ADO.NET thay cho `sqlcmd -i` (bắt buộc, vì `sqlcmd -i` làm hỏng tiếng Việt trong DB). Có `-InTransaction` để swap function an toàn trên DB đang có người dùng. |

> ⚠️ **Cả 2 script đều KHÔNG chứa mật khẩu** — mọi thông tin kết nối (`-Server`, `-User`, `-Password`)
> phải truyền vào lúc chạy. Đừng hardcode mật khẩu rồi commit lên git.

## Việc còn dở dang

`Database/DeployScripts/2026-08-28_HR_SnK_Dev_Optimize_Split_inline.sql` **đã viết + đã verify khớp 100%
output nhưng CHƯA chạy lên DB**. Chạy bằng:

```powershell
.\Invoke-SqlScript.ps1 -ScriptPath ..\..\Database\DeployScripts\2026-08-28_HR_SnK_Dev_Optimize_Split_inline.sql -Database HR_SnK_Dev -Server 113.161.180.44 -User skbp -Password '<mat-khau>' -InTransaction
```

Sau khi chạy xong **phải export lại DDL** (file `Split.sql` sẽ chuyển từ thư mục
`Database/SQL/Functions/TableValued/` sang `Database/SQL/Functions/InlineTableValued/`):

```powershell
.\Export-Ddl.ps1 -Database HR_SnK_Dev -OutDir ..\..\Database\SQL -Server 113.161.180.44 -User skbp -Password '<mat-khau>'
```
