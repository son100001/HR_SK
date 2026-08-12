# ==============================================================================
# Script: CopyMarkdownsToMyungjin.ps1
# Mô tả: Tự động tìm tất cả file *.md từ SnK_Dev và copy sang Myungjin, 
#        đồng thời cập nhật lại các đường dẫn tuyệt đối trong link.
# Cách chạy: Mở PowerShell, di chuyển đến thư mục SnK_Dev và chạy:
#            .\CopyMarkdownsToMyungjin.ps1
# ==============================================================================

$sourceRoot = "E:\SourceCodeHR\SnK_Dev"
if (-not (Test-Path $sourceRoot)) {
    # Nếu chạy trực tiếp tại thư mục hiện tại của script
    $sourceRoot = $PSScriptRoot
}
$targetRoot = "E:\SourceCodeHR\Myungjin"

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  BẮT ĐẦU SAO CHÉP TÀI LIỆU MARKDOWN SANG MYUNGJIN" -ForegroundColor Cyan
Write-Host "  Nguồn: $sourceRoot" -ForegroundColor Yellow
Write-Host "  Đích : $targetRoot" -ForegroundColor Yellow
Write-Host "==========================================================" -ForegroundColor Cyan

# Kiểm tra thư mục đích
if (-not (Test-Path $targetRoot)) {
    Write-Host "LỖI: Thư mục đích $targetRoot không tồn tại!" -ForegroundColor Red
    Exit
}

# Tìm tất cả file markdown (loại trừ các thư mục build/tạm như .git, .vs, packages, bin, obj)
$mdFiles = Get-ChildItem -Path $sourceRoot -Filter *.md -Recurse -File | Where-Object {
    $_.FullName -notmatch '\\\.git\\' -and 
    $_.FullName -notmatch '\\\.vs\\' -and 
    $_.FullName -notmatch '\\packages\\' -and
    $_.FullName -notmatch '\\obj\\' -and
    $_.FullName -notmatch '\\bin\\' -and
    $_.Name -ne "README.md" # Giữ lại README.md gốc của Myungjin
}

Write-Host "Đã tìm thấy $($mdFiles.Count) file markdown." -ForegroundColor Green

$copiedCount = 0
foreach ($file in $mdFiles) {
    # Tính đường dẫn tương đối
    $relative = $file.FullName.Substring($sourceRoot.Length).TrimStart([char]92)
    
    $destFile = Join-Path $targetRoot $relative
    $destDir = Split-Path $destFile -Parent
    
    # Tạo thư mục đích nếu chưa có
    if (-not (Test-Path $destDir)) {
        New-Item -ItemType Directory -Path $destDir -Force | Out-Null
    }
    
    # Đọc nội dung file
    $content = [System.IO.File]::ReadAllText($file.FullName, [System.Text.Encoding]::UTF8)
    
    # Thay thế đường dẫn link
    $updatedContent = $content
    $updatedContent = $updatedContent -ireplace "file:///e:/SourceCodeHR/POCONS/", "file:///E:/SourceCodeHR/Myungjin/"
    $updatedContent = $updatedContent -ireplace "file:///e:/SourceCodeHR/SnK_Dev/", "file:///E:/SourceCodeHR/Myungjin/"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR/POCONS", "SourceCodeHR/Myungjin"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR\\POCONS", "SourceCodeHR\Myungjin"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR/SnK_Dev", "SourceCodeHR/Myungjin"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR\\SnK_Dev", "SourceCodeHR\Myungjin"
    
    # Ghi đè sang thư mục Myungjin
    [System.IO.File]::WriteAllText($destFile, $updatedContent, [System.Text.Encoding]::UTF8)
    
    Write-Host "[OK] Đã chép: $relative" -ForegroundColor Gray
    $copiedCount++
}

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host " THÀNH CÔNG: Đã copy và cập nhật link cho $copiedCount files!" -ForegroundColor Green
Write-Host "==========================================================" -ForegroundColor Cyan
