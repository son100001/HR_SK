using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
// ❌ XÓA dòng này - nó gây conflict
// using static System.Net.Mime.MediaTypeNames;

namespace SmartBooksUpdater
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Cần 3 tham số: đường dẫn app, thư mục update, process ID
            if (args.Length < 3)
            {
                MessageBox.Show("Lỗi: Thiếu tham số cho updater.\n\n" +
                               "Cần: [App Path] [Update Folder] [Process ID]",
                               "Updater Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return;
            }

            string targetAppPath = args[0];
            string updateSourceFolder = args[1];
            string processIdString = args[2];

            // Hiển thị progress form
            System.Windows.Forms.Application.EnableVisualStyles();
            var progressForm = new UpdateProgressForm();
            progressForm.Show();
            progressForm.SetStatus("Đang chờ ứng dụng đóng...");
            System.Windows.Forms.Application.DoEvents();

            try
            {
                // Bước 1: Đợi app cũ đóng hoàn toàn
                progressForm.SetStatus("Đang đợi ứng dụng đóng...");
                WaitForApplicationToClose(processIdString, progressForm);

                // Bước 2: Backup files cũ (optional nhưng khuyến khích)
                progressForm.SetStatus("Đang sao lưu phiên bản cũ...");
                string appDirectory = Path.GetDirectoryName(targetAppPath);
                BackupOldVersion(appDirectory);

                // Bước 3: Copy files mới
                progressForm.SetStatus("Đang cập nhật files...");
                UpdateFiles(updateSourceFolder, appDirectory, progressForm);

                // Bước 4: Cleanup temp folder
                progressForm.SetStatus("Đang dọn dẹp...");
                CleanupTempFolder(updateSourceFolder);

                // Bước 5: Restart app
                progressForm.SetStatus("Đang khởi động lại ứng dụng...");
                Thread.Sleep(500);

                Process.Start(new ProcessStartInfo
                {
                    FileName = targetAppPath,
                    WorkingDirectory = appDirectory,
                    UseShellExecute = true
                });

                progressForm.Close();
            }
            catch (Exception ex)
            {
                progressForm.Close();
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}\n\n{ex.StackTrace}",
                               "Update Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        static void WaitForApplicationToClose(string processIdString, UpdateProgressForm progressForm)
        {
            try
            {
                int processId = int.Parse(processIdString);
                var process = Process.GetProcessById(processId);

                int waitTime = 0;
                int maxWaitTime = 15000; // 15 giây

                while (!process.HasExited && waitTime < maxWaitTime)
                {
                    Thread.Sleep(500);
                    waitTime += 500;
                    progressForm.SetStatus($"Đang đợi ứng dụng đóng... ({waitTime / 1000}s)");
                    System.Windows.Forms.Application.DoEvents();
                }

                if (!process.HasExited)
                {
                    // Force kill nếu cần
                    process.Kill();
                    Thread.Sleep(2000);
                }
            }
            catch (ArgumentException)
            {
                // Process không tồn tại = đã đóng rồi
                Thread.Sleep(1000);
            }
        }

        static void BackupOldVersion(string appDirectory)
        {
            string backupFolder = Path.Combine(
                Path.GetDirectoryName(appDirectory),
                "Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            // Chỉ backup các file quan trọng
            string[] importantFiles = { "*.exe", "*.dll", "*.config" };

            foreach (string pattern in importantFiles)
            {
                foreach (string file in Directory.GetFiles(appDirectory, pattern))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(backupFolder, fileName);

                    try
                    {
                        File.Copy(file, destFile, true);
                    }
                    catch
                    {
                        // Ignore nếu không copy được
                    }
                }
            }
        }

        static void UpdateFiles(string sourceDir, string targetDir, UpdateProgressForm progressForm)
        {
            // Lấy danh sách tất cả files cần update
            var allFiles = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
            int totalFiles = allFiles.Length;
            int currentFile = 0;

            foreach (string sourceFile in allFiles)
            {
                currentFile++;
                string relativePath = sourceFile.Substring(sourceDir.Length).TrimStart('\\', '/');
                string targetFile = Path.Combine(targetDir, relativePath);

                // Update progress
                int percentage = (currentFile * 100) / totalFiles;
                progressForm.UpdateProgress(percentage,
                    $"Đang cập nhật: {Path.GetFileName(sourceFile)} ({currentFile}/{totalFiles})");

                // Tạo thư mục nếu chưa có
                string targetSubDir = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(targetSubDir))
                {
                    Directory.CreateDirectory(targetSubDir);
                }

                // Copy file với retry logic
                CopyFileWithRetry(sourceFile, targetFile, 5);
            }
        }

        static void CopyFileWithRetry(string sourceFile, string targetFile, int maxRetries)
        {
            int retries = maxRetries;

            while (retries > 0)
            {
                try
                {
                    // Nếu file đích tồn tại và đang được sử dụng, xóa nó trước
                    if (File.Exists(targetFile))
                    {
                        File.SetAttributes(targetFile, FileAttributes.Normal);
                    }

                    File.Copy(sourceFile, targetFile, true);
                    break; // Success
                }
                catch (IOException ex)
                {
                    retries--;

                    if (retries == 0)
                    {
                        throw new Exception($"Không thể copy file {Path.GetFileName(sourceFile)}: {ex.Message}");
                    }

                    Thread.Sleep(1000); // Đợi 1 giây trước khi retry
                }
            }
        }

        static void CleanupTempFolder(string tempFolder)
        {
            try
            {
                if (Directory.Exists(tempFolder))
                {
                    Directory.Delete(tempFolder, true);
                }
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
    }
}