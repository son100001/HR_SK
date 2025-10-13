Imports System.IO
Public Class DatabaseRestore
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clmFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstView As System.Windows.Forms.ListView
    Friend WithEvents btnRestore As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstView = New System.Windows.Forms.ListView()
        Me.clmFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRestore = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(528, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Backup file list"
        '
        'lstView
        '
        Me.lstView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmFileName, Me.clmDate})
        Me.lstView.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstView.GridLines = True
        Me.lstView.HideSelection = False
        Me.lstView.Location = New System.Drawing.Point(16, 32)
        Me.lstView.MultiSelect = False
        Me.lstView.Name = "lstView"
        Me.lstView.Size = New System.Drawing.Size(552, 336)
        Me.lstView.TabIndex = 3
        Me.lstView.UseCompatibleStateImageBehavior = False
        Me.lstView.View = System.Windows.Forms.View.Details
        '
        'clmFileName
        '
        Me.clmFileName.Text = "File Name"
        Me.clmFileName.Width = 371
        '
        'clmDate
        '
        Me.clmDate.Text = "Backup Date"
        Me.clmDate.Width = 177
        '
        'btnRestore
        '
        Me.btnRestore.Location = New System.Drawing.Point(20, 384)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(168, 32)
        Me.btnRestore.TabIndex = 9
        Me.btnRestore.Text = "Restore"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(207, 384)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(168, 32)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(400, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(168, 32)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'DatabaseRestore
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(584, 430)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.lstView)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DatabaseRestore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Restore"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private dbTasks As DBTasks = New DBTasks
    Private Sub LoadFileList(ByVal path As String)
        Dim Files() As String = Directory.GetFiles(path)
        lstView.View = System.Windows.Forms.View.List
        Dim Filename As String
        Dim item As ListViewItem
        Dim fileDetail As IO.FileInfo
        lstView.View = View.Details
        lstView.BeginUpdate()
        For Each Filename In Files
            item = lstView.Items.Add(Filename.Substring(Filename.LastIndexOf("\") + 1))
            item.SubItems.Add(System.IO.File.GetCreationTime(Filename))
        Next
        lstView.EndUpdate()
        lstView.Refresh()
    End Sub

    Private Sub DatabaseRestore_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFileList(dbTasks.GetBackupFolder)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If (lstView.SelectedItems.Count > 0) Then
            dbTasks.restore(lstView.SelectedItems.Item(0).SubItems(0).Text)
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim pathFileName As String
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If (lstView.SelectedItems.Count > 0) Then
            pathFileName = dbTasks.GetBackupFolder & "\" & lstView.SelectedItems.Item(0).SubItems(0).Text
            Dim fileInfo As FileInfo = New FileInfo(pathFileName)
            fileInfo.Delete()
            lstView.Clear()
            LoadFileList(dbTasks.GetBackupFolder)
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
