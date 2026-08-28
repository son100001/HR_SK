# =============================================================================
#  Export toan bo DDL (stored procedure / function / table) cua 1 database ra
#  thu muc Database/SQL/ theo dung dinh dang ma repo dang dung.
#
#  Vi du:
#    .\Export-Ddl.ps1 -Database HR_SnK_Dev -OutDir E:\SourceCodeHR\SnK_Dev\Database\SQL `
#                     -Server 113.161.180.44 -User skbp -Password '<mat-khau>'
#
#  KHONG hardcode mat khau trong file nay (file nay duoc commit len git).
#
#  Dinh dang output (da doi chieu byte-for-byte voi bo export cu, 707/707 file khop):
#    - UTF-8 CO BOM, xuong dong CRLF
#    - Module: sys.sql_modules.definition NGUYEN VAN (giu ca dong trong thua o cuoi)
#              + "\r\nGO\r\n"
#    - Table : CREATE TABLE -> PRIMARY KEY -> UNIQUE -> FOREIGN KEY -> CREATE INDEX,
#              moi lenh cach nhau 1 dong trong; cot INCLUDE viet lien khong khoang trang
#              sau dau phay.
#
#  Cach verify bo export nay con dung chuan sau khi sua doi: chay len 1 DB snapshot cu
#  (vd HR_SnK_Dev_260811) roi diff -r voi ban da commit trong git - phai khop gan het.
# =============================================================================
param(
    [Parameter(Mandatory=$true)][string]$Database,
    [Parameter(Mandatory=$true)][string]$OutDir,
    [Parameter(Mandatory=$true)][string]$Server,
    [Parameter(Mandatory=$true)][string]$User,
    [Parameter(Mandatory=$true)][string]$Password
)

$ErrorActionPreference = "Stop"

$connStr = "Server=$Server;Database=$Database;User ID=$User;Password=$Password;Connect Timeout=60;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

function Invoke-Q([string]$sql) {
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = $sql
    $cmd.CommandTimeout = 300
    $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dt = New-Object System.Data.DataTable
    [void]$da.Fill($dt)
    return ,$dt   # dau phay: chan PowerShell "unroll" DataTable thanh tung DataRow
}

# UTF-8 WITH BOM, CRLF -- khop dinh dang cac file dang co trong Database/SQL/
$enc = New-Object System.Text.UTF8Encoding($true)

function Write-Ddl([string]$path, [string]$content) {
    $content = $content -replace "`r`n", "`n"
    $content = $content -replace "`r", "`n"
    $content = $content -replace "`n", "`r`n"
    [System.IO.File]::WriteAllText($path, $content, $enc)
}

function Sanitize([string]$name) {
    foreach ($c in [System.IO.Path]::GetInvalidFileNameChars()) {
        $name = $name.Replace([string]$c, '_')
    }
    return $name
}

# ---------------------------------------------------------------- modules ---
$folderOf = @{
    'P'  = 'StoredProcedures'
    'FN' = 'Functions\Scalar'
    'TF' = 'Functions\TableValued'
    'IF' = 'Functions\InlineTableValued'
}
foreach ($f in $folderOf.Values) {
    $p = Join-Path $OutDir $f
    if (-not (Test-Path $p)) { [void](New-Item -ItemType Directory -Path $p -Force) }
}

$modules = Invoke-Q @"
SELECT o.name, o.type, m.definition
FROM sys.sql_modules m
JOIN sys.objects o ON o.object_id = m.object_id
WHERE o.type IN ('P','FN','TF','IF') AND o.is_ms_shipped = 0
ORDER BY o.name;
"@

$nMod = 0
foreach ($r in $modules.Rows) {
    $def = [string]$r["definition"]
    if ([string]::IsNullOrWhiteSpace($def)) { continue }
    $otype = ([string]$r["type"]).Trim()
    $dir  = Join-Path $OutDir $folderOf[$otype]
    $file = Join-Path $dir ((Sanitize ([string]$r["name"])) + ".sql")
    # definition ghi NGUYEN VAN (ke ca dong trong thua o cuoi) + GO
    Write-Ddl $file ($def + "`r`nGO`r`n")
    $nMod++
}

# ----------------------------------------------------------------- tables ---
$tblDir = Join-Path $OutDir 'Tables'
if (-not (Test-Path $tblDir)) { [void](New-Item -ItemType Directory -Path $tblDir -Force) }

$cols = Invoke-Q @"
SELECT t.name AS tbl, c.column_id, c.name AS col, ty.name AS typ,
       c.max_length, c.precision, c.scale, c.is_nullable, c.is_identity,
       ic.seed_value, ic.increment_value,
       dc.definition AS dflt,
       cc.definition AS computed
FROM sys.tables t
JOIN sys.columns c            ON c.object_id = t.object_id
JOIN sys.types ty             ON ty.user_type_id = c.user_type_id
LEFT JOIN sys.identity_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id
LEFT JOIN sys.default_constraints dc ON dc.object_id = c.default_object_id
LEFT JOIN sys.computed_columns cc ON cc.object_id = c.object_id AND cc.column_id = c.column_id
WHERE t.is_ms_shipped = 0
ORDER BY t.name, c.column_id;
"@

$keys = Invoke-Q @"
SELECT t.name AS tbl, kc.name AS cname, kc.type AS ktype, i.type_desc AS idx_type,
       STUFF((SELECT ', [' + c2.name + '] ' + CASE WHEN ic2.is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END
              FROM sys.index_columns ic2
              JOIN sys.columns c2 ON c2.object_id = ic2.object_id AND c2.column_id = ic2.column_id
              WHERE ic2.object_id = i.object_id AND ic2.index_id = i.index_id AND ic2.is_included_column = 0
              ORDER BY ic2.key_ordinal
              FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS cols
FROM sys.key_constraints kc
JOIN sys.tables t ON t.object_id = kc.parent_object_id
JOIN sys.indexes i ON i.object_id = kc.parent_object_id AND i.index_id = kc.unique_index_id
WHERE t.is_ms_shipped = 0
ORDER BY t.name, CASE kc.type WHEN 'PK' THEN 0 ELSE 1 END, kc.name;
"@

$fks = Invoke-Q @"
SELECT t.name AS tbl, fk.name AS cname,
       rt.name AS reftbl, SCHEMA_NAME(rt.schema_id) AS refsch,
       fk.delete_referential_action_desc AS del_act,
       fk.update_referential_action_desc AS upd_act,
       STUFF((SELECT ', [' + pc.name + ']'
              FROM sys.foreign_key_columns fkc2
              JOIN sys.columns pc ON pc.object_id = fkc2.parent_object_id AND pc.column_id = fkc2.parent_column_id
              WHERE fkc2.constraint_object_id = fk.object_id
              ORDER BY fkc2.constraint_column_id
              FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS pcols,
       STUFF((SELECT ', [' + rc.name + ']'
              FROM sys.foreign_key_columns fkc2
              JOIN sys.columns rc ON rc.object_id = fkc2.referenced_object_id AND rc.column_id = fkc2.referenced_column_id
              WHERE fkc2.constraint_object_id = fk.object_id
              ORDER BY fkc2.constraint_column_id
              FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS rcols
FROM sys.foreign_keys fk
JOIN sys.tables t  ON t.object_id  = fk.parent_object_id
JOIN sys.tables rt ON rt.object_id = fk.referenced_object_id
WHERE t.is_ms_shipped = 0
ORDER BY t.name, fk.name;
"@

$idxs = Invoke-Q @"
SELECT t.name AS tbl, i.name AS iname, i.type_desc, i.is_unique, i.filter_definition,
       STUFF((SELECT ', [' + c2.name + '] ' + CASE WHEN ic2.is_descending_key = 1 THEN 'DESC' ELSE 'ASC' END
              FROM sys.index_columns ic2
              JOIN sys.columns c2 ON c2.object_id = ic2.object_id AND c2.column_id = ic2.column_id
              WHERE ic2.object_id = i.object_id AND ic2.index_id = i.index_id AND ic2.is_included_column = 0
              ORDER BY ic2.key_ordinal
              FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS keycols,
       STUFF((SELECT ',[' + c3.name + ']'
              FROM sys.index_columns ic3
              JOIN sys.columns c3 ON c3.object_id = ic3.object_id AND c3.column_id = ic3.column_id
              WHERE ic3.object_id = i.object_id AND ic3.index_id = i.index_id AND ic3.is_included_column = 1
              ORDER BY ic3.index_column_id
              FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 1, '') AS inccols
FROM sys.indexes i
JOIN sys.tables t ON t.object_id = i.object_id
WHERE t.is_ms_shipped = 0
  AND i.is_primary_key = 0 AND i.is_unique_constraint = 0
  AND i.type IN (1,2) AND i.name IS NOT NULL
ORDER BY t.name, i.name;
"@

function Format-Type($r) {
    $typ = ([string]$r["typ"]).ToUpper()
    $ml  = [int]$r["max_length"]
    switch -Regex ($typ) {
        '^(NVARCHAR|NCHAR)$'                  { if ($ml -eq -1) { return "$typ(MAX)" } else { return "$typ($($ml/2))" } }
        '^(VARCHAR|CHAR|VARBINARY|BINARY)$'   { if ($ml -eq -1) { return "$typ(MAX)" } else { return "$typ($ml)" } }
        '^(DECIMAL|NUMERIC)$'                 { return "$typ($([int]$r['precision']),$([int]$r['scale']))" }
        '^(DATETIME2|TIME|DATETIMEOFFSET)$'   { return "$typ($([int]$r['scale']))" }
        default                               { return $typ }
    }
}

$tables = $cols.Rows | ForEach-Object { [string]$_["tbl"] } | Select-Object -Unique
$nTbl = 0
foreach ($tbl in $tables) {
    $sb = New-Object System.Text.StringBuilder
    [void]$sb.Append("CREATE TABLE [dbo].[$tbl] (`r`n")

    $tcols = $cols.Rows | Where-Object { [string]$_["tbl"] -eq $tbl }
    $lines = @()
    foreach ($c in $tcols) {
        $name = [string]$c["col"]
        if ($c["computed"] -isnot [DBNull]) {
            $lines += "    [$name] AS $([string]$c['computed'])"
            continue
        }
        $line = "    [$name] " + (Format-Type $c)
        if ([bool]$c["is_identity"]) {
            $line += " IDENTITY($([string]$c['seed_value']),$([string]$c['increment_value']))"
        }
        $line += if ([bool]$c["is_nullable"]) { " NULL" } else { " NOT NULL" }
        if ($c["dflt"] -isnot [DBNull]) { $line += " DEFAULT $([string]$c['dflt'])" }
        $lines += $line
    }
    [void]$sb.Append(($lines -join ",`r`n"))
    [void]$sb.Append("`r`n);`r`n")

    foreach ($k in ($keys.Rows | Where-Object { [string]$_["tbl"] -eq $tbl })) {
        $kind = if (([string]$k["ktype"]).Trim() -eq 'PK') { 'PRIMARY KEY' } else { 'UNIQUE' }
        $suffix = if ([string]$k["idx_type"] -eq 'NONCLUSTERED') { ' NONCLUSTERED' } elseif ($kind -eq 'UNIQUE') { ' CLUSTERED' } else { '' }
        [void]$sb.Append("`r`nALTER TABLE [dbo].[$tbl] ADD CONSTRAINT [$([string]$k['cname'])] $kind$suffix ($([string]$k['cols']));`r`n")
    }

    foreach ($f in ($fks.Rows | Where-Object { [string]$_["tbl"] -eq $tbl })) {
        $s = "`r`nALTER TABLE [dbo].[$tbl] ADD CONSTRAINT [$([string]$f['cname'])] FOREIGN KEY ($([string]$f['pcols'])) REFERENCES [$([string]$f['refsch'])].[$([string]$f['reftbl'])] ($([string]$f['rcols']))"
        if ([string]$f["del_act"] -ne 'NO_ACTION') { $s += " ON DELETE " + ([string]$f["del_act"]).Replace('_',' ') }
        if ([string]$f["upd_act"] -ne 'NO_ACTION') { $s += " ON UPDATE " + ([string]$f["upd_act"]).Replace('_',' ') }
        [void]$sb.Append("$s;`r`n")
    }

    foreach ($i in ($idxs.Rows | Where-Object { [string]$_["tbl"] -eq $tbl })) {
        $uq = if ([bool]$i["is_unique"]) { 'UNIQUE ' } else { '' }
        $s = "`r`nCREATE $uq$([string]$i['type_desc']) INDEX [$([string]$i['iname'])] ON [dbo].[$tbl] ($([string]$i['keycols']))"
        if ($i["inccols"] -isnot [DBNull] -and [string]$i["inccols"] -ne '') { $s += " INCLUDE ($([string]$i['inccols']))" }
        if ($i["filter_definition"] -isnot [DBNull]) { $s += " WHERE $([string]$i['filter_definition'])" }
        [void]$sb.Append("$s;`r`n")
    }

    Write-Ddl (Join-Path $tblDir ((Sanitize $tbl) + ".sql")) $sb.ToString()
    $nTbl++
}

$conn.Close()
Write-Output "DB=$Database  modules=$nMod  tables=$nTbl  ->  $OutDir"
