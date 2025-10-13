Public Class DatabaseBackup
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBackup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChooseFolder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnChooseFolder = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBackup = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File Name:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folder:"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(120, 48)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(264, 20)
        Me.txtFileName.TabIndex = 4
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(120, 8)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(264, 20)
        Me.txtPath.TabIndex = 5
        '
        'btnChooseFolder
        '
        Me.btnChooseFolder.Location = New System.Drawing.Point(388, 8)
        Me.btnChooseFolder.Name = "btnChooseFolder"
        Me.btnChooseFolder.Size = New System.Drawing.Size(32, 20)
        Me.btnChooseFolder.TabIndex = 7
        Me.btnChooseFolder.Text = "..."
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(114, 96)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(144, 32)
        Me.btnBackup.TabIndex = 8
        Me.btnBackup.Text = "Back Up"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(264, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(144, 32)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        '
        'DatabaseBackup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(432, 150)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.btnChooseFolder)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "DatabaseBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Backup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private dbtask As DBTasks = New DBTasks

    Private Sub SetBackupPath(ByVal path As String)
        txtPath.Enabled = True
        txtPath.Text = path
        txtPath.Enabled = False
    End Sub

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        dbtask.backup(txtFileName.Text.Trim, txtPath.Text.Trim)
        Me.Close()
        Me.Dispose()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DatabaseBackup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load, btnBackup.Click
        Me.Text = "Backup Data"
        txtPath.Enabled = True
        txtPath.Text = dbtask.GetBackupFolder()
        txtPath.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnChooseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFolder.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = folderDlg.SelectedPath + "\"
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        End If
    End Sub
End Class
