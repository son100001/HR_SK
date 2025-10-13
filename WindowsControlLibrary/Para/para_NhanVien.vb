Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Janus.Windows.GridEX

Public Class para_NhanVien
    Inherits System.Windows.Forms.Form
    Public Employee_ID As String
    Dim tvcn As New WindowsControlLibrary.ThuVienChucNang
    Public bLuu As Boolean
    Private obj As New DbSetting
    Friend WithEvents gridDanhSachNhanVien As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Dim kn As New WindowsControlLibrary.connect(DbSetting.dataPath)


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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gridDanhSachNhanVien = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridDanhSachNhanVien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnOk)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 344)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1192, 64)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.gridDanhSachNhanVien)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1192, 344)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'gridDanhSachNhanVien
        '
        Me.gridDanhSachNhanVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDanhSachNhanVien.Location = New System.Drawing.Point(3, 16)
        Me.gridDanhSachNhanVien.MainView = Me.GridView1
        Me.gridDanhSachNhanVien.Name = "gridDanhSachNhanVien"
        Me.gridDanhSachNhanVien.Size = New System.Drawing.Size(1186, 325)
        Me.gridDanhSachNhanVien.TabIndex = 1322
        Me.gridDanhSachNhanVien.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridDanhSachNhanVien
        Me.GridView1.Name = "GridView1"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(477, 19)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 27)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(572, 19)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 27)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'para_NhanVien
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1192, 410)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "para_NhanVien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "para_NhanVien"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gridDanhSachNhanVien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub para_NhanVien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ChangeLanguageToForm(Me, Me.Name, 0)
        Dim tabQuyenTruyXuat As DataTable = kn.ReadData("select * from [user] where username='" + obj.UserName + "'", "table")
        gridDanhSachNhanVien.DataSource = kn.ReadData("select * from [dbo].[udf_GetBasicInformationEmployee]() order by EmployeeStatus asc, Employee_ID", "table")
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        GridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25
        GridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsMenu.ShowAutoFilterRowItem = True
        GridView1.OptionsView.ShowAutoFilterRow = True
        'tvcn.FocusGrd(gridDanhSachNhanVien, 0, -2)
        'gridDanhSachNhanVien.SelectCurrentCellText()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If (GridView1.SelectedRowsCount > 0) Then
            'Employee_ID = GridView1.GetDataRow(GridView1.GetSelectedRows(0)).Item("Employee_ID").ToString()
            For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
                Employee_ID += GridView1.GetDataRow(GridView1.GetSelectedRows(0)).Item("Employee_ID").ToString() + ","
            Next
        End If
        bLuu = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        bLuu = False
        Me.Close()
    End Sub

    Private Sub gridDanhSachNhanVien_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Employee_ID = GridView1.GetDataRow(GridView1.GetSelectedRows(0)).Item("Employee_ID").ToString()
        Me.Close()
    End Sub

    Private Sub gridDanhSachNhanVien_KeyUp(sender As Object, e As KeyEventArgs) Handles gridDanhSachNhanVien.KeyUp
        If e.Control AndAlso Keys.Enter Then
            Employee_ID = GridView1.GetDataRow(GridView1.GetSelectedRows(0)).Item("Employee_ID").ToString()
            If Not IsNothing(Employee_ID) Then
                Me.Close()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
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
            If GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Card_Code").ToString() <> "" Then
                str_DanhSachTheTu += GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("Card_Code").ToString() + Environment.NewLine
            End If
        Next
        If Not IsNothing(str_DanhSachTheTu) Then
            Return str_DanhSachTheTu.Trim
        End If
    End Function
End Class
