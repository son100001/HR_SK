Imports Appsettings
Imports DevExpress.XtraGrid.Views.Grid
Imports SmartBooks.BusinessLogic


Public Class para_BangLoaiGioCong
    Inherits WindowsControlLibrary.HRFORM
    'Dim kn As New connect(DbSetting.dataPath)
    Public bCancel As Boolean
    Friend WithEvents cbViewLeave As CheckBox
    Friend WithEvents cbViewShift As CheckBox
    Friend WithEvents cbViewTimeInTimeOut As CheckBox
    Friend WithEvents cbViewPhieuCong As CheckBox
    Friend WithEvents cbViewMaxOverTime As CheckBox
    Friend WithEvents cbViewLateIn As CheckBox
    Public KEYCALL As String
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cbViewLateIn = New System.Windows.Forms.CheckBox()
        Me.cbViewMaxOverTime = New System.Windows.Forms.CheckBox()
        Me.cbViewPhieuCong = New System.Windows.Forms.CheckBox()
        Me.cbViewTimeInTimeOut = New System.Windows.Forms.CheckBox()
        Me.cbViewLeave = New System.Windows.Forms.CheckBox()
        Me.cbViewShift = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 460)
        Me.PanelButton.Size = New System.Drawing.Size(576, 12)
        Me.PanelButton.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Controls.Add(Me.cbViewLateIn)
        Me.GroupBox2.Controls.Add(Me.cbViewMaxOverTime)
        Me.GroupBox2.Controls.Add(Me.cbViewPhieuCong)
        Me.GroupBox2.Controls.Add(Me.cbViewTimeInTimeOut)
        Me.GroupBox2.Controls.Add(Me.cbViewLeave)
        Me.GroupBox2.Controls.Add(Me.cbViewShift)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 396)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 74)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(484, 35)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(78, 23)
        Me.btnCancel.TabIndex = 1229
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(400, 35)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(78, 23)
        Me.btnOK.TabIndex = 1228
        Me.btnOK.Text = "OK"
        '
        'cbViewLateIn
        '
        Me.cbViewLateIn.AutoSize = True
        Me.cbViewLateIn.Location = New System.Drawing.Point(395, 12)
        Me.cbViewLateIn.Name = "cbViewLateIn"
        Me.cbViewLateIn.Size = New System.Drawing.Size(122, 17)
        Me.cbViewLateIn.TabIndex = 65
        Me.cbViewLateIn.Text = "Hiển thị đi làm muộn"
        Me.cbViewLateIn.UseVisualStyleBackColor = True
        Me.cbViewLateIn.Visible = False
        '
        'cbViewMaxOverTime
        '
        Me.cbViewMaxOverTime.AutoSize = True
        Me.cbViewMaxOverTime.Location = New System.Drawing.Point(131, 41)
        Me.cbViewMaxOverTime.Name = "cbViewMaxOverTime"
        Me.cbViewMaxOverTime.Size = New System.Drawing.Size(121, 17)
        Me.cbViewMaxOverTime.TabIndex = 64
        Me.cbViewMaxOverTime.Text = "Hiển thị đăng ký TC"
        Me.cbViewMaxOverTime.UseVisualStyleBackColor = True
        '
        'cbViewPhieuCong
        '
        Me.cbViewPhieuCong.AutoSize = True
        Me.cbViewPhieuCong.Location = New System.Drawing.Point(266, 19)
        Me.cbViewPhieuCong.Name = "cbViewPhieuCong"
        Me.cbViewPhieuCong.Size = New System.Drawing.Size(80, 17)
        Me.cbViewPhieuCong.TabIndex = 63
        Me.cbViewPhieuCong.Text = "Phiếu công"
        Me.cbViewPhieuCong.UseVisualStyleBackColor = True
        '
        'cbViewTimeInTimeOut
        '
        Me.cbViewTimeInTimeOut.AutoSize = True
        Me.cbViewTimeInTimeOut.Checked = True
        Me.cbViewTimeInTimeOut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbViewTimeInTimeOut.Location = New System.Drawing.Point(131, 19)
        Me.cbViewTimeInTimeOut.Name = "cbViewTimeInTimeOut"
        Me.cbViewTimeInTimeOut.Size = New System.Drawing.Size(119, 17)
        Me.cbViewTimeInTimeOut.TabIndex = 62
        Me.cbViewTimeInTimeOut.Text = "Hiển thị giờ QV, QR"
        Me.cbViewTimeInTimeOut.UseVisualStyleBackColor = True
        '
        'cbViewLeave
        '
        Me.cbViewLeave.AutoSize = True
        Me.cbViewLeave.Checked = True
        Me.cbViewLeave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbViewLeave.Location = New System.Drawing.Point(16, 41)
        Me.cbViewLeave.Name = "cbViewLeave"
        Me.cbViewLeave.Size = New System.Drawing.Size(89, 17)
        Me.cbViewLeave.TabIndex = 61
        Me.cbViewLeave.Text = "Hiển thị phép"
        Me.cbViewLeave.UseVisualStyleBackColor = True
        '
        'cbViewShift
        '
        Me.cbViewShift.AutoSize = True
        Me.cbViewShift.Location = New System.Drawing.Point(16, 18)
        Me.cbViewShift.Name = "cbViewShift"
        Me.cbViewShift.Size = New System.Drawing.Size(77, 17)
        Me.cbViewShift.TabIndex = 60
        Me.cbViewShift.Text = "Hiển thị ca"
        Me.cbViewShift.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 390)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(576, 390)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'para_BangLoaiGioCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(576, 472)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "abc"
        Me.Name = "para_BangLoaiGioCong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "para_BangLoaiGioCong"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub para_BangLoaiGioCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ChangeLanguageToForm(Me, "TimeKeeping", 0)
        GridControl1.DataSource = kn.ReadData("select * from HR_LoaiCong where MaCong not like 'CN%' order by OrderBy asc", "Table")
        'GridView1.OptionsSelection.MultiSelect = True

        'Set up Default HRFORM_Gridview
        HRFORM_Gridview.OptionsSelection.MultiSelect = True
        HRFORM_Gridview.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        HRFORM_Gridview.OptionsSelection.CheckBoxSelectorColumnWidth = 25
        HRFORM_Gridview.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False
        HRFORM_Gridview.OptionsView.ColumnAutoWidth = False
        HRFORM_Gridview.OptionsMenu.ShowAutoFilterRowItem = True
        HRFORM_Gridview.OptionsView.ShowAutoFilterRow = True
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
    Public Function Get_MangLoaiCong() As String()
        Dim str_LoaiCong As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            str_LoaiCong += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("MaCong").ToString() + ","
        Next
        If str_LoaiCong <> String.Empty Then
            str_LoaiCong = str_LoaiCong.Remove(str_LoaiCong.Length - 1, 1)
            Return Split(str_LoaiCong, ",")
        End If
    End Function

    Public Function Get_MangTenCong() As String()
        Dim str_TenCong As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            str_TenCong += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("NameVN").ToString() + ","
        Next
        If str_TenCong <> String.Empty Then
            str_TenCong = str_TenCong.Remove(str_TenCong.Length - 1, 1)
            Return Split(str_TenCong, ",")
        End If
    End Function
    Public Function Get_SQLTongCong() As String
        Dim strSQLTongCong As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            strSQLTongCong += "isnull(" + GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("MaCong").ToString() + ",0)+"
        Next
        If strSQLTongCong <> String.Empty Then
            strSQLTongCong = strSQLTongCong.Remove(strSQLTongCong.Length - 1, 1)
            Return strSQLTongCong
        End If
    End Function
    Private Sub gridLoaiGioCong_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            btnOK_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            btnCancel_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Tab Then
            cbViewShift.Focus()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        bCancel = True
        Me.Close()
    End Sub
End Class
