$sourceRoot = "e:\SourceCodeHR\SnK_Dev"
$targetRoot = "E:\SourceCodeHR\Myungjin"

# Find all markdown files (excluding common build/temp folders like .git, .vs, packages, obj, bin)
$mdFiles = Get-ChildItem -Path $sourceRoot -Filter *.md -Recurse -File | Where-Object {
    $_.FullName -notmatch '\\\.git\\' -and 
    $_.FullName -notmatch '\\\.vs\\' -and 
    $_.FullName -notmatch '\\packages\\' -and
    $_.FullName -notmatch '\\obj\\' -and
    $_.FullName -notmatch '\\bin\\'
}

Write-Output "Found $($mdFiles.Count) markdown files to copy."

foreach ($file in $mdFiles) {
    # Calculate relative path
    $relative = $file.FullName.Substring($sourceRoot.Length).TrimStart([char]92) # 92 is backslash
    
    # Do not copy root README.md if it is not desired, but let's copy it anyway or keep it
    # We will copy it and Myungjin already has one, but it is better to overwrite or keep it.
    
    $destFile = Join-Path $targetRoot $relative
    $destDir = Split-Path $destFile -Parent
    
    # Create destination directory if it doesn't exist
    if (-not (Test-Path $destDir)) {
        New-Item -ItemType Directory -Path $destDir -Force | Out-Null
    }
    
    # Read file content (ensure correct encoding)
    $content = [System.IO.File]::ReadAllText($file.FullName, [System.Text.Encoding]::UTF8)
    
    # Perform path replacements (case-insensitive)
    $updatedContent = $content
    $updatedContent = $updatedContent -ireplace "file:///e:/SourceCodeHR/POCONS/", "file:///E:/SourceCodeHR/Myungjin/"
    $updatedContent = $updatedContent -ireplace "file:///e:/SourceCodeHR/SnK_Dev/", "file:///E:/SourceCodeHR/Myungjin/"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR/POCONS", "SourceCodeHR/Myungjin"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR\\POCONS", "SourceCodeHR\Myungjin"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR/SnK_Dev", "SourceCodeHR/Myungjin"
    $updatedContent = $updatedContent -ireplace "SourceCodeHR\\SnK_Dev", "SourceCodeHR\Myungjin"
    
    # Write to destination
    [System.IO.File]::WriteAllText($destFile, $updatedContent, [System.Text.Encoding]::UTF8)
    
    Write-Output "Copied and updated: $relative"
}

Write-Output "Copying completed successfully."
