Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class DBTasks
    Private userName As String
    Private password As String
    Private databaseName As String
    Public serverName As String
    Public serverBackupFolder As String
    Public sharedBackupFolder As String
    Public localDatabaseServer As String

    Public Sub New()
        Dim ds As New DataSet
        Dim dsLogin As New DataSet
        ds.ReadXml(Application.StartupPath & "\AppConfig.xml")
        dsLogin.ReadXml(Application.StartupPath & "\login.xml")
        With ds.Tables(0).Rows(0)
            userName = .Item("UserID")
            password = .Item("Password")
            serverName = .Item("ServerName")
            'databaseName = .Item("DatabaseName")
            serverBackupFolder = .Item("ServerBackupFolder")
            sharedBackupFolder = .Item("SharedBackupFolderName")
            localDatabaseServer = .Item("LocalDatabaseServer")
        End With
        With dsLogin.Tables(0).Rows(0)
            databaseName = .Item("database")
        End With
    End Sub

    Public Sub BackupDatabase()
        'Declare a SaveFileDialog object
        Dim objSaveFileDialog As New SaveFileDialog

        'Set the Save dialog properties
        With objSaveFileDialog
            .DefaultExt = "Bak"
            .FileName = "Test Document"
            .Filter = "Backup files (*.bak)|*.bak"
            .FilterIndex = 1
            .OverwritePrompt = True
            .Title = "Demo Save File Dialog"
        End With

        'Show the Save dialog and if the user clicks the Save button,
        'save the file
        If objSaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'backup(objSaveFileDialog.FileName.Substring(objSaveFileDialog.FileName.LastIndexOf("\"), objSaveFileDialog.FileName.Length))
            Catch fileException As Exception
                Throw fileException
            End Try
        End If

        'Clean up
        objSaveFileDialog.Dispose()
        objSaveFileDialog = Nothing

    End Sub

    Public Sub RestoreDatabase()
        'Declare a OpenFileDialog object
        Dim objOpenFileDialog As New OpenFileDialog

        'Set the Open dialog properties
        With objOpenFileDialog
            .Filter = "Backup files (*.bak)|*.bak"
            .FilterIndex = 1
            .Title = "Demo Open File Dialog"
        End With

        'Show the Open dialog and if the user clicks the Open button,
        'load the file
        If objOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim allText As String
            Try
                restore(objOpenFileDialog.FileName)
            Catch fileException As Exception
                Throw fileException
            End Try
        End If

        'Clean up
        objOpenFileDialog.Dispose()
        objOpenFileDialog = Nothing
    End Sub

    Public Sub backup(ByVal backupFileName As String, ByVal backupFolderName As String)
        Dim dsUser As New DataSet
        dsUser.ReadXml(Application.StartupPath & "\AppConfig.xml")
        Dim server As SQLDMO.SQLServer2 = Nothing
        Try
            Dim backup As SQLDMO.BackupClass = New SQLDMO.BackupClass
            server = New SQLDMO.SQLServer2Class
            server.Connect(serverName, userName, password)
            backup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database
            backup.Database = databaseName
            backup.Files = backupFolderName & backupFileName 'GetBackupFolder() & backupFileName
            backup.Initialize = True
            backup.BackupSetDescription = "Full BackUp"
            backup.BackupSetName = backupFileName
            backup.SQLBackup(server)
            MessageBox.Show("Successfully backup data:".ToString, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dsUser.Tables(0).Rows(0)("ServerBackupFolder") = backupFolderName
            dsUser.WriteXml(Application.StartupPath & "\AppConfig.xml")
        Catch oex As System.Runtime.InteropServices.COMException
            If oex.ErrorCode = -2147203048 Then
                MessageBox.Show("Username or password is wrong.", "")
            Else
                If oex.ErrorCode = -2147218303 Then
                    MessageBox.Show("Not exist folder " & serverBackupFolder & " on database server." & Microsoft.VisualBasic.Chr(10) & "You must create this folder before backup data.")
                Else
                    If oex.ErrorCode = -2147206257 Then
                        MessageBox.Show("You have no right to backup data.", "")
                    Else
                        MessageBox.Show("Code error:" & oex.ErrorCode & "" & Microsoft.VisualBasic.Chr(10) & "Error: " & oex.Message, "")
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.GetType.ToString() & ":" & ex.Message.ToString, "")
        Finally
            Try
                server.Close()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Public Sub restore(ByVal backupFileName As String)
        Dim server As SQLDMO.SQLServer = Nothing
        Try
            KillAllConnection()
            server = New SQLDMO.SQLServerClass
            server.Connect(serverName, userName, password)
            Dim restore As SQLDMO.Restore2 = New SQLDMO.Restore2Class
            restore.Action = SQLDMO.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database
            restore.Database = databaseName
            restore.Files = GetBackupFolder() & backupFileName
            restore.ReplaceDatabase = True
            restore.SQLRestore(server)
            MessageBox.Show("Successfully restore data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch oex As System.Runtime.InteropServices.COMException
            If oex.ErrorCode = -2147203048 Then
                MessageBox.Show("Username or password is wrong.", "Restore error")
            Else
                If oex.ErrorCode = -2147206257 Then
                    MessageBox.Show("You have no right to restore database.", "Restore error")
                Else
                    If oex.ErrorCode = -2147218403 Then
                        MessageBox.Show("-You must close all programs using database." & Microsoft.VisualBasic.Chr(10) & "-Only keep your program running. ", "Restore error")
                    Else
                        If oex.ErrorCode = -2147218303 Then
                            MessageBox.Show("Not exist folder " & serverBackupFolder & " on database server." & Microsoft.VisualBasic.Chr(10) & "You must create this folder before backup data.")
                        Else
                            MessageBox.Show("Error code:" & oex.ErrorCode & "" & Microsoft.VisualBasic.Chr(10) & "Error : " & oex.Message, "Restore error")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.GetType.ToString() & ":" & ex.Message, "Restore error")
        Finally
            Try
                server.Close()
                DBConnection.Connection().Open()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub KillAllConnection()
        Dim param As SqlParameter = New SqlParameter
        Try
            param = New SqlParameter("@DatabaseName", SqlDbType.NVarChar, 100)
            param.Direction = ParameterDirection.Input
            param.Value = databaseName
            Dim masterConnectionString As String = "workstation id=.;packet size=4096;user id=" & userName & ";data source=" & serverName & ";persist security info=True;initial catalog=" & "master" & ";password=" & password
            SqlHelper.ExecuteNonQuery(New SqlConnection(masterConnectionString), CommandType.StoredProcedure, "usp_KillAllConnections", param)
        Catch ex As Exception
            Throw ex
        Finally
            If Not DBConnection.Connection Is Nothing Then
                CType(DBConnection.Connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Public Function GetBackupFolder() As String
        If (localDatabaseServer = "True") Then
            Return serverBackupFolder & "\"
        Else
            Return "\\" & serverName & "\" & sharedBackupFolder & "\"
        End If
    End Function



End Class
