# =============================================================================
#  Chay 1 file .sql qua ADO.NET thay vi "sqlcmd -i".
#
#  LY DO BAT BUOC (xem markdowns/INDEX.md): "sqlcmd -i file.sql" doc sai codepage file
#  UTF-8 -> lam HONG tieng Viet trong NVARCHAR ghi that vao DB, khong chi loi hien thi.
#  ADO.NET luon xu ly Unicode dung.
#
#  Vi du:
#    .\Invoke-SqlScript.ps1 -ScriptPath ..\..\Database\DeployScripts\2026-08-28_xxx.sql `
#         -Database HR_SnK_Dev -Server 113.161.180.44 -User skbp -Password '<mat-khau>' -InTransaction
#
#  KHONG hardcode mat khau trong file nay (file nay duoc commit len git).
#
#  -InTransaction: bat buoc dung khi DROP + CREATE lai function/procedure tren DB DANG CO
#  NGUOI DUNG THAT. Khi do caller goi trung luc dang swap se CHO tren Sch-M lock roi chay
#  tiep, thay vi gap loi "invalid object name". Neu chay 2 batch roi nhau ngoai transaction
#  se co cua so vai chuc ms ma function bien mat -> user dang thao tac se bi loi.
# =============================================================================
param(
    [Parameter(Mandatory=$true)][string]$ScriptPath,
    [Parameter(Mandatory=$true)][string]$Database,
    [Parameter(Mandatory=$true)][string]$Server,
    [Parameter(Mandatory=$true)][string]$User,
    [Parameter(Mandatory=$true)][string]$Password,
    [switch]$InTransaction
)

$ErrorActionPreference = "Stop"

$text = [System.IO.File]::ReadAllText($ScriptPath, [System.Text.Encoding]::UTF8)
$batches = [System.Text.RegularExpressions.Regex]::Split($text, '(?im)^\s*GO\s*$') |
           Where-Object { $_.Trim() -ne '' }

$conn = New-Object System.Data.SqlClient.SqlConnection("Server=$Server;Database=$Database;User ID=$User;Password=$Password;Connect Timeout=60;")
$conn.Open()

# SqlClient tu bat QUOTED_IDENTIFIER ON + ANSI_NULLS ON khi mo connection,
# nen object tao ra se co dung 2 option nay.
$tran = $null
if ($InTransaction) { $tran = $conn.BeginTransaction() }

try {
    $i = 0
    foreach ($b in $batches) {
        $i++
        $cmd = $conn.CreateCommand()
        $cmd.CommandText = $b
        $cmd.CommandTimeout = 600
        if ($tran) { $cmd.Transaction = $tran }
        [void]$cmd.ExecuteNonQuery()
        Write-Output ("  batch {0}/{1} OK" -f $i, $batches.Count)
    }
    if ($tran) { $tran.Commit(); Write-Output "  COMMIT" }
    Write-Output "OK: $ScriptPath"
}
catch {
    if ($tran) { $tran.Rollback(); Write-Output "  ROLLBACK" }
    Write-Output "LOI: $($_.Exception.Message)"
    throw
}
finally { $conn.Close() }
