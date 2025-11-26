Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class UpdateManager

    ' ===== CẤU HÌNH =====
    Private Const VERSION_URL As String = "https://hr.ssaudit.com/beapproval/sk/version.txt"
    Private Const DOWNLOAD_URL As String = "https://hr.ssaudit.com/beapproval/sk/Debug.zip"
    Private Const LOCAL_VERSION_FILE As String = "version.txt"

    Private ReadOnly _currentVersion As String
    Private ReadOnly _appPath As String
    Private ReadOnly _updaterPath As String

    Public Sub New()
        _currentVersion = ReadLocalVersion()
        _appPath = Application.ExecutablePath
        _updaterPath = Path.Combine(Application.StartupPath, "HRUpdater.exe")
    End Sub

    ''' <summary>
    ''' Đọc version từ file version.txt local
    ''' </summary>
    Private Function ReadLocalVersion() As String
        Try
            Dim versionFilePath As String = Path.Combine(Application.StartupPath, LOCAL_VERSION_FILE)

            If File.Exists(versionFilePath) Then
                Dim version As String = File.ReadAllText(versionFilePath).Trim()
                If Not String.IsNullOrWhiteSpace(version) Then
                    Return version
                End If
            End If

            ' Fallback về Assembly version
            Return Application.ProductVersion

        Catch ex As Exception
            Debug.WriteLine($"Cannot read local version file: {ex.Message}")
            Return Application.ProductVersion
        End Try
    End Function

    ''' <summary>
    ''' Kiểm tra update từ server
    ''' </summary>
    Public Async Function CheckAndUpdate() As Task
        Try
            Dim serverVersion As String = Await DownloadTextAsync(VERSION_URL)
            serverVersion = serverVersion.Trim()

            If IsNewerVersion(serverVersion, _currentVersion) Then
                Dim result = MessageBox.Show(
                    $"🎉 Có phiên bản mới: {serverVersion}" & vbCrLf &
                    $"📦 Phiên bản hiện tại: {_currentVersion}" & vbCrLf & vbCrLf &
                    "Bạn có muốn cập nhật ngay bây giờ?",
                    "HumanResource - Cập nhật mới",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information)

                If result = DialogResult.Yes Then
                    Await DownloadAndInstall(serverVersion)
                End If
            Else
                System.Diagnostics.Debug.WriteLine($"Already up to date: {_currentVersion}")
            End If

        Catch ex As Exception
            ' Silent fail - không crash app
            System.Diagnostics.Debug.WriteLine($"Update check failed: {ex.Message}")
        End Try
    End Function

    ''' <summary>
    ''' Download và cài đặt update
    ''' </summary>
    Private Async Function DownloadAndInstall(newVersion As String) As Task
        ' ✅ Đổi tên thư mục temp
        Dim tempFolder As String = Path.Combine(
            Path.GetTempPath(),
            "HumanResourceUpdate_" & Guid.NewGuid().ToString("N"))

        Directory.CreateDirectory(tempFolder)

        Dim progressForm As New DownloadProgressForm()
        progressForm.Show()

        Try
            ' Download Debug.zip
            Dim zipPath As String = Path.Combine(tempFolder, "Debug.zip")
            progressForm.SetStatus("Đang tải xuống bản cập nhật...")

            Await DownloadFileAsync(DOWNLOAD_URL, zipPath, progressForm)

            ' Extract ZIP
            progressForm.SetStatus("Đang giải nén...")
            progressForm.SetProgress(0)

            ZipFile.ExtractToDirectory(zipPath, tempFolder)
            File.Delete(zipPath)

            ' Ghi version mới vào file
            Dim newVersionFilePath As String = Path.Combine(tempFolder, LOCAL_VERSION_FILE)
            File.WriteAllText(newVersionFilePath, newVersion)

            progressForm.Close()

            ' Hỏi restart
            Dim result = MessageBox.Show(
                "✅ Tải xuống hoàn tất!" & vbCrLf & vbCrLf &
                "Ứng dụng cần khởi động lại để hoàn tất cập nhật." & vbCrLf &
                "Khởi động lại ngay bây giờ?",
                "HumanResource - Cập nhật sẵn sàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                StartUpdater(tempFolder)
            Else
                Directory.Delete(tempFolder, True)
            End If

        Catch ex As Exception
            progressForm.Close()

            Try
                Directory.Delete(tempFolder, True)
            Catch
            End Try

            MessageBox.Show(
                $"❌ Lỗi tải xuống:{vbCrLf}{ex.Message}",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try
    End Function

    Private Async Function DownloadTextAsync(url As String) As Task(Of String)
        Using client As New WebClient()
            Return Await client.DownloadStringTaskAsync(url)
        End Using
    End Function

    Private Async Function DownloadFileAsync(url As String, savePath As String, progressForm As DownloadProgressForm) As Task
        Using client As New WebClient()
            AddHandler client.DownloadProgressChanged, Sub(s, e)
                                                           Dim mbDownloaded = e.BytesReceived \ 1024 \ 1024
                                                           Dim mbTotal = e.TotalBytesToReceive \ 1024 \ 1024
                                                           progressForm.SetProgress(e.ProgressPercentage)
                                                           progressForm.SetStatus($"📥 Đang tải: {mbDownloaded} MB / {mbTotal} MB ({e.ProgressPercentage}%)")
                                                       End Sub

            Await client.DownloadFileTaskAsync(url, savePath)
        End Using
    End Function

    Private Function IsNewerVersion(serverVersion As String, currentVersion As String) As Boolean
        Try
            Dim server As New Version(serverVersion)
            Dim current As New Version(currentVersion)
            Return server > current
        Catch
            Return String.Compare(serverVersion, currentVersion, StringComparison.OrdinalIgnoreCase) > 0
        End Try
    End Function

    ''' <summary>
    ''' Khởi động HRUpdater.exe và tắt app (ẨN CMD)
    ''' </summary>
    Private Sub StartUpdater(updateFolder As String)
        If Not File.Exists(_updaterPath) Then
            MessageBox.Show(
                "⚠️ Không tìm thấy HRUpdater.exe" & vbCrLf & vbCrLf &
                $"Bạn có thể copy thủ công từ:{vbCrLf}{updateFolder}",
                "Cập nhật thủ công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Process.Start("explorer.exe", updateFolder)
            Return
        End If

        Dim processId As Integer = Process.GetCurrentProcess().Id
        Dim arguments As String = $"""{_appPath}"" ""{updateFolder}"" ""{processId}"""

        ' ✅ CẤU HÌNH ẨN CMD WINDOW
        Dim startInfo As New ProcessStartInfo With {
            .FileName = _updaterPath,
            .Arguments = arguments,
            .UseShellExecute = False,              ' QUAN TRỌNG: Phải là False
            .CreateNoWindow = True,                ' ẨN console window
            .WindowStyle = ProcessWindowStyle.Hidden, ' ẨN window
            .WorkingDirectory = Application.StartupPath
        }

        Process.Start(startInfo)
        Environment.Exit(0)
    End Sub

End Class