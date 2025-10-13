Imports Appsettings
 

Public Class para_NhanVienActive
    Inherits WindowsControlLibrary.HRFORM
    Private fromdate As DateTime
    Private todate As DateTime
    Private DanhSachMaNVLoaiTru As String()
    Public DieuKienLoc As String
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton

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
        Me.PanelButton.Location = New System.Drawing.Point(0, 432)
        Me.PanelButton.Size = New System.Drawing.Size(984, 10)
        Me.PanelButton.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 376)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(984, 64)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(481, 19)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 23)
        Me.btnCancel.TabIndex = 1229
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(393, 20)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(72, 23)
        Me.btnOK.TabIndex = 1228
        Me.btnOK.Text = "OK"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 376)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(978, 357)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'para_NhanVienActive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(984, 442)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "abc"
        Me.Name = "para_NhanVienActive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "para_NhanVienActive"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub para_NhanVienActive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "List Of Employee"
        If DieuKienLoc <> String.Empty Then
            GridControl1.DataSource = kn.ReadData("select * from SmartBooks_Employee where " + DieuKienLoc, "SmartBooks_Employee")
        Else
            LayDanhSachNhanVienActive(DanhSachMaNVLoaiTru)
        End If
        tvcn.FocusGrd(GridView1, 0, -2)
    End Sub
    Public Function Get_DanhSachNhanVienDuocChon() As String
        Dim str_DanhSachNhanVien As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            str_DanhSachNhanVien += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Employee_ID").ToString() + Environment.NewLine
        Next
        If Not IsNothing(str_DanhSachNhanVien) Then
            Return str_DanhSachNhanVien.Trim
        End If
    End Function
    Public Function Get_DanhSachTheTuDuocChon() As String
        Dim str_DanhSachTheTu As String
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            If Not IsDBNull(GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Card_Code").ToString()) Then
                str_DanhSachTheTu += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Card_Code").ToString() + Environment.NewLine
            End If
        Next
        If Not IsNothing(str_DanhSachTheTu) Then
            Return str_DanhSachTheTu.Trim
        End If
    End Function
    Public Sub Set_FromDate(ByVal fromdate_ As DateTime)
        fromdate = fromdate_
    End Sub
    Public Sub Set_ToDate(ByVal todate_ As DateTime)
        todate = todate_
    End Sub
    Public Sub Set_DanhSachMaNVLoaiTru(ByVal DanhSachMaNVLoaiTru_ As String())
        DanhSachMaNVLoaiTru = DanhSachMaNVLoaiTru_
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bluu = True
        Me.Close()
    End Sub
    Private Sub LayDanhSachNhanVienActive(ByVal strmang_DanhSachMaVNLoaiTru As String())
        If IsNothing(strmang_DanhSachMaVNLoaiTru) Then
            GridControl1.DataSource = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fromdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "','" + obj.Lan + "')", "table")
        Else
            Dim str_SQLMaNv As String
            For Each s As String In strmang_DanhSachMaVNLoaiTru
                str_SQLMaNv += "'" + s + "',"
            Next
            str_SQLMaNv = str_SQLMaNv.Remove(str_SQLMaNv.Length - 1, 1)
            GridControl1.DataSource = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fromdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "','" + obj.Lan + "') where Employee_ID not in (" + str_SQLMaNv + ")", "table")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub gridDanhSachNhanVien_KeyUp(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            btnOk_Click(Nothing, Nothing)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
