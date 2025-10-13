Imports VBReport
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPara
    Inherits System.Windows.Forms.Form
    Dim tvcn As New ThuVienChucNang
    Private obj As New DbSetting
    Dim kn As New Entity.connect(DbSetting.dataPath)
    Public ParameterReturn As String
    Public ReportInformation As DataRow
    Public bThucHienLenh As Boolean
    Public bViewOnGrid, bPrintView, bPrintViewDocument As Boolean
    Public KeyOfForm1 As String
    Public Quyen As String
    Dim tabQuyenTX As DataTable
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ViTri1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblChooseAll As Label
    Friend WithEvents lblFactory_ID As Label
    Friend WithEvents lblChucDanh As Label
    Friend WithEvents lblsectioncode As Label
    Friend WithEvents lblteamcode As Label
    Friend WithEvents lbldepartmentcode As Label
    Friend WithEvents lblPosition_ID As Label
    Friend WithEvents lblPositionCategory_ID As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TuNgayDenNgay2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Ngay3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Thang4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LoaiHD5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DanhSachKey6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DSNhanVien7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents nationality8 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SalaryTable9 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Nam10 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LeaveType11 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents para_Position_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents para_teamcode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents para_sectioncode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents para_departmentcode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents para_Factory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents para_Position As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents para_ChucDanh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents para_PositionCategory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbltodate As Label
    Friend WithEvents lblfromdate As Label
    Friend WithEvents para_todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents para_fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents para_Ngay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblNgay As Label
    Friend WithEvents lblMonth_ As Label
    Friend WithEvents para_TypeOfContract As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblType As Label
    Friend WithEvents para_DanhSachKey As RichTextBox
    Friend WithEvents gridDanhSachNhanVien As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents para_nationality As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblnationality As Label
    Friend WithEvents para_SalaryTable As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSalaryTable As Label
    Friend WithEvents para_year_ As Year
    Friend WithEvents lblYear_ As Label
    Friend WithEvents para_LeaveType As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents para_Year As Year
    Friend WithEvents para_Month As Month
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOk As SimpleButton
    Friend WithEvents btnCancel As SimpleButton
    Friend WithEvents ExportDocumentFile As RadioButton


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
    Friend WithEvents gbLuaChonHienThi As System.Windows.Forms.GroupBox
    Friend WithEvents PrintView As System.Windows.Forms.RadioButton
    Friend WithEvents ExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents ViewOnGrid As System.Windows.Forms.RadioButton
    Friend WithEvents GetTemplateFile As System.Windows.Forms.RadioButton
    Friend WithEvents ExecStore As System.Windows.Forms.RadioButton
    Friend WithEvents InputTemplateFile As System.Windows.Forms.RadioButton
    Friend WithEvents PrinViewDocument As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gbLuaChonHienThi = New System.Windows.Forms.GroupBox()
        Me.ExportDocumentFile = New System.Windows.Forms.RadioButton()
        Me.PrinViewDocument = New System.Windows.Forms.RadioButton()
        Me.ExecStore = New System.Windows.Forms.RadioButton()
        Me.InputTemplateFile = New System.Windows.Forms.RadioButton()
        Me.GetTemplateFile = New System.Windows.Forms.RadioButton()
        Me.PrintView = New System.Windows.Forms.RadioButton()
        Me.ExportExcel = New System.Windows.Forms.RadioButton()
        Me.ViewOnGrid = New System.Windows.Forms.RadioButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.ViTri1 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_ChucDanh = New DevExpress.XtraEditors.LookUpEdit()
        Me.para_PositionCategory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.para_Position_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.para_teamcode = New DevExpress.XtraEditors.LookUpEdit()
        Me.para_sectioncode = New DevExpress.XtraEditors.LookUpEdit()
        Me.para_departmentcode = New DevExpress.XtraEditors.LookUpEdit()
        Me.para_Factory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.para_Position = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblChooseAll = New System.Windows.Forms.Label()
        Me.lblFactory_ID = New System.Windows.Forms.Label()
        Me.lblChucDanh = New System.Windows.Forms.Label()
        Me.lblsectioncode = New System.Windows.Forms.Label()
        Me.lblteamcode = New System.Windows.Forms.Label()
        Me.lbldepartmentcode = New System.Windows.Forms.Label()
        Me.lblPosition_ID = New System.Windows.Forms.Label()
        Me.lblPositionCategory_ID = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TuNgayDenNgay2 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_todate = New DevExpress.XtraEditors.DateEdit()
        Me.para_fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.lbltodate = New System.Windows.Forms.Label()
        Me.lblfromdate = New System.Windows.Forms.Label()
        Me.Ngay3 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_Ngay = New DevExpress.XtraEditors.DateEdit()
        Me.lblNgay = New System.Windows.Forms.Label()
        Me.Thang4 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_Year = New WindowsControlLibrary.Year()
        Me.para_Month = New WindowsControlLibrary.Month()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoaiHD5 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_TypeOfContract = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblType = New System.Windows.Forms.Label()
        Me.DanhSachKey6 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_DanhSachKey = New System.Windows.Forms.RichTextBox()
        Me.DSNhanVien7 = New DevExpress.XtraTab.XtraTabPage()
        Me.gridDanhSachNhanVien = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.nationality8 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_nationality = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblnationality = New System.Windows.Forms.Label()
        Me.SalaryTable9 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_SalaryTable = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSalaryTable = New System.Windows.Forms.Label()
        Me.Nam10 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_year_ = New WindowsControlLibrary.Year()
        Me.lblYear_ = New System.Windows.Forms.Label()
        Me.LeaveType11 = New DevExpress.XtraTab.XtraTabPage()
        Me.para_LeaveType = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblMonth_ = New System.Windows.Forms.Label()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.gbLuaChonHienThi.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.ViTri1.SuspendLayout()
        CType(Me.para_ChucDanh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_PositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_Position_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_teamcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_sectioncode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_departmentcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_Factory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_Position.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TuNgayDenNgay2.SuspendLayout()
        CType(Me.para_todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ngay3.SuspendLayout()
        CType(Me.para_Ngay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.para_Ngay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Thang4.SuspendLayout()
        Me.LoaiHD5.SuspendLayout()
        CType(Me.para_TypeOfContract.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DanhSachKey6.SuspendLayout()
        Me.DSNhanVien7.SuspendLayout()
        CType(Me.gridDanhSachNhanVien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.nationality8.SuspendLayout()
        CType(Me.para_nationality.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SalaryTable9.SuspendLayout()
        CType(Me.para_SalaryTable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Nam10.SuspendLayout()
        Me.LeaveType11.SuspendLayout()
        CType(Me.para_LeaveType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbLuaChonHienThi
        '
        Me.gbLuaChonHienThi.Controls.Add(Me.ExportDocumentFile)
        Me.gbLuaChonHienThi.Controls.Add(Me.PrinViewDocument)
        Me.gbLuaChonHienThi.Controls.Add(Me.ExecStore)
        Me.gbLuaChonHienThi.Controls.Add(Me.InputTemplateFile)
        Me.gbLuaChonHienThi.Controls.Add(Me.GetTemplateFile)
        Me.gbLuaChonHienThi.Controls.Add(Me.PrintView)
        Me.gbLuaChonHienThi.Controls.Add(Me.ExportExcel)
        Me.gbLuaChonHienThi.Controls.Add(Me.ViewOnGrid)
        Me.gbLuaChonHienThi.Location = New System.Drawing.Point(0, 229)
        Me.gbLuaChonHienThi.Name = "gbLuaChonHienThi"
        Me.gbLuaChonHienThi.Size = New System.Drawing.Size(539, 120)
        Me.gbLuaChonHienThi.TabIndex = 56
        Me.gbLuaChonHienThi.TabStop = False
        Me.gbLuaChonHienThi.Text = "Lựa chọn thực hiện"
        '
        'ExportDocumentFile
        '
        Me.ExportDocumentFile.Enabled = False
        Me.ExportDocumentFile.Location = New System.Drawing.Point(210, 86)
        Me.ExportDocumentFile.Name = "ExportDocumentFile"
        Me.ExportDocumentFile.Size = New System.Drawing.Size(128, 24)
        Me.ExportDocumentFile.TabIndex = 182
        Me.ExportDocumentFile.Text = "Xuất file(Văn bản)"
        '
        'PrinViewDocument
        '
        Me.PrinViewDocument.Enabled = False
        Me.PrinViewDocument.Location = New System.Drawing.Point(8, 88)
        Me.PrinViewDocument.Name = "PrinViewDocument"
        Me.PrinViewDocument.Size = New System.Drawing.Size(128, 24)
        Me.PrinViewDocument.TabIndex = 181
        Me.PrinViewDocument.Text = "Xem file in (Văn bản)"
        '
        'ExecStore
        '
        Me.ExecStore.Enabled = False
        Me.ExecStore.Location = New System.Drawing.Point(392, 56)
        Me.ExecStore.Name = "ExecStore"
        Me.ExecStore.Size = New System.Drawing.Size(96, 24)
        Me.ExecStore.TabIndex = 180
        Me.ExecStore.Text = "Thực hiện lệnh"
        '
        'InputTemplateFile
        '
        Me.InputTemplateFile.Enabled = False
        Me.InputTemplateFile.Location = New System.Drawing.Point(210, 56)
        Me.InputTemplateFile.Name = "InputTemplateFile"
        Me.InputTemplateFile.Size = New System.Drawing.Size(104, 24)
        Me.InputTemplateFile.TabIndex = 179
        Me.InputTemplateFile.Text = "Nhập Template"
        '
        'GetTemplateFile
        '
        Me.GetTemplateFile.Enabled = False
        Me.GetTemplateFile.Location = New System.Drawing.Point(8, 56)
        Me.GetTemplateFile.Name = "GetTemplateFile"
        Me.GetTemplateFile.Size = New System.Drawing.Size(112, 24)
        Me.GetTemplateFile.TabIndex = 178
        Me.GetTemplateFile.Text = "Lấy Template"
        '
        'PrintView
        '
        Me.PrintView.Enabled = False
        Me.PrintView.Location = New System.Drawing.Point(392, 24)
        Me.PrintView.Name = "PrintView"
        Me.PrintView.Size = New System.Drawing.Size(96, 24)
        Me.PrintView.TabIndex = 177
        Me.PrintView.Text = "Xem file in"
        '
        'ExportExcel
        '
        Me.ExportExcel.Enabled = False
        Me.ExportExcel.Location = New System.Drawing.Point(210, 24)
        Me.ExportExcel.Name = "ExportExcel"
        Me.ExportExcel.Size = New System.Drawing.Size(96, 24)
        Me.ExportExcel.TabIndex = 176
        Me.ExportExcel.Text = "Xuất Excel"
        '
        'ViewOnGrid
        '
        Me.ViewOnGrid.Enabled = False
        Me.ViewOnGrid.Location = New System.Drawing.Point(8, 24)
        Me.ViewOnGrid.Name = "ViewOnGrid"
        Me.ViewOnGrid.Size = New System.Drawing.Size(96, 24)
        Me.ViewOnGrid.TabIndex = 175
        Me.ViewOnGrid.Text = "Xem trên lưới"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.ViTri1
        Me.XtraTabControl1.Size = New System.Drawing.Size(540, 223)
        Me.XtraTabControl1.TabIndex = 1010
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ViTri1, Me.TuNgayDenNgay2, Me.Ngay3, Me.Thang4, Me.LoaiHD5, Me.DanhSachKey6, Me.DSNhanVien7, Me.nationality8, Me.SalaryTable9, Me.Nam10, Me.LeaveType11})
        '
        'ViTri1
        '
        Me.ViTri1.Controls.Add(Me.para_ChucDanh)
        Me.ViTri1.Controls.Add(Me.para_PositionCategory_ID)
        Me.ViTri1.Controls.Add(Me.btnXoa)
        Me.ViTri1.Controls.Add(Me.para_Position_ID)
        Me.ViTri1.Controls.Add(Me.para_teamcode)
        Me.ViTri1.Controls.Add(Me.para_sectioncode)
        Me.ViTri1.Controls.Add(Me.para_departmentcode)
        Me.ViTri1.Controls.Add(Me.para_Factory_ID)
        Me.ViTri1.Controls.Add(Me.para_Position)
        Me.ViTri1.Controls.Add(Me.lblChooseAll)
        Me.ViTri1.Controls.Add(Me.lblFactory_ID)
        Me.ViTri1.Controls.Add(Me.lblChucDanh)
        Me.ViTri1.Controls.Add(Me.lblsectioncode)
        Me.ViTri1.Controls.Add(Me.lblteamcode)
        Me.ViTri1.Controls.Add(Me.lbldepartmentcode)
        Me.ViTri1.Controls.Add(Me.lblPosition_ID)
        Me.ViTri1.Controls.Add(Me.lblPositionCategory_ID)
        Me.ViTri1.Controls.Add(Me.TableLayoutPanel2)
        Me.ViTri1.Name = "ViTri1"
        Me.ViTri1.PageVisible = False
        Me.ViTri1.Size = New System.Drawing.Size(538, 198)
        Me.ViTri1.Text = "Vị trí"
        '
        'para_ChucDanh
        '
        Me.para_ChucDanh.Location = New System.Drawing.Point(473, 165)
        Me.para_ChucDanh.Name = "para_ChucDanh"
        Me.para_ChucDanh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_ChucDanh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_ChucDanh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_ChucDanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_ChucDanh.Size = New System.Drawing.Size(14, 20)
        Me.para_ChucDanh.TabIndex = 1329
        Me.para_ChucDanh.Visible = False
        '
        'para_PositionCategory_ID
        '
        Me.para_PositionCategory_ID.Location = New System.Drawing.Point(473, 141)
        Me.para_PositionCategory_ID.Name = "para_PositionCategory_ID"
        Me.para_PositionCategory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_PositionCategory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_PositionCategory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_PositionCategory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_PositionCategory_ID.Size = New System.Drawing.Size(14, 20)
        Me.para_PositionCategory_ID.TabIndex = 1328
        Me.para_PositionCategory_ID.Visible = False
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(410, 40)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(62, 20)
        Me.btnXoa.TabIndex = 1327
        Me.btnXoa.Text = "Xóa"
        '
        'para_Position_ID
        '
        Me.para_Position_ID.Location = New System.Drawing.Point(119, 141)
        Me.para_Position_ID.Name = "para_Position_ID"
        Me.para_Position_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_Position_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_Position_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_Position_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_Position_ID.Size = New System.Drawing.Size(285, 20)
        Me.para_Position_ID.TabIndex = 1326
        Me.para_Position_ID.Visible = False
        '
        'para_teamcode
        '
        Me.para_teamcode.Location = New System.Drawing.Point(119, 115)
        Me.para_teamcode.Name = "para_teamcode"
        Me.para_teamcode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_teamcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_teamcode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_teamcode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_teamcode.Size = New System.Drawing.Size(285, 20)
        Me.para_teamcode.TabIndex = 1325
        '
        'para_sectioncode
        '
        Me.para_sectioncode.Location = New System.Drawing.Point(119, 89)
        Me.para_sectioncode.Name = "para_sectioncode"
        Me.para_sectioncode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_sectioncode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_sectioncode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_sectioncode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_sectioncode.Size = New System.Drawing.Size(285, 20)
        Me.para_sectioncode.TabIndex = 1323
        '
        'para_departmentcode
        '
        Me.para_departmentcode.Location = New System.Drawing.Point(119, 64)
        Me.para_departmentcode.Name = "para_departmentcode"
        Me.para_departmentcode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_departmentcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_departmentcode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_departmentcode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_departmentcode.Size = New System.Drawing.Size(285, 20)
        Me.para_departmentcode.TabIndex = 1322
        '
        'para_Factory_ID
        '
        Me.para_Factory_ID.Location = New System.Drawing.Point(119, 40)
        Me.para_Factory_ID.Name = "para_Factory_ID"
        Me.para_Factory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_Factory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_Factory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_Factory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_Factory_ID.Size = New System.Drawing.Size(285, 20)
        Me.para_Factory_ID.TabIndex = 1321
        '
        'para_Position
        '
        Me.para_Position.Location = New System.Drawing.Point(119, 15)
        Me.para_Position.Name = "para_Position"
        Me.para_Position.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_Position.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_Position.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_Position.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_Position.Size = New System.Drawing.Size(353, 20)
        Me.para_Position.TabIndex = 1320
        '
        'lblChooseAll
        '
        Me.lblChooseAll.BackColor = System.Drawing.Color.Transparent
        Me.lblChooseAll.Location = New System.Drawing.Point(24, 15)
        Me.lblChooseAll.Name = "lblChooseAll"
        Me.lblChooseAll.Size = New System.Drawing.Size(73, 15)
        Me.lblChooseAll.TabIndex = 1318
        Me.lblChooseAll.Text = "Lọc toàn bộ"
        Me.lblChooseAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFactory_ID
        '
        Me.lblFactory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblFactory_ID.Location = New System.Drawing.Point(24, 40)
        Me.lblFactory_ID.Name = "lblFactory_ID"
        Me.lblFactory_ID.Size = New System.Drawing.Size(73, 15)
        Me.lblFactory_ID.TabIndex = 1316
        Me.lblFactory_ID.Text = "Phòng ban"
        Me.lblFactory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChucDanh
        '
        Me.lblChucDanh.BackColor = System.Drawing.Color.Transparent
        Me.lblChucDanh.Location = New System.Drawing.Point(432, 168)
        Me.lblChucDanh.Name = "lblChucDanh"
        Me.lblChucDanh.Size = New System.Drawing.Size(10, 19)
        Me.lblChucDanh.TabIndex = 1315
        Me.lblChucDanh.Text = "Chức danh"
        Me.lblChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblChucDanh.Visible = False
        '
        'lblsectioncode
        '
        Me.lblsectioncode.BackColor = System.Drawing.Color.Transparent
        Me.lblsectioncode.Location = New System.Drawing.Point(24, 90)
        Me.lblsectioncode.Name = "lblsectioncode"
        Me.lblsectioncode.Size = New System.Drawing.Size(73, 15)
        Me.lblsectioncode.TabIndex = 1314
        Me.lblsectioncode.Text = "Nhóm"
        Me.lblsectioncode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteamcode
        '
        Me.lblteamcode.BackColor = System.Drawing.Color.Transparent
        Me.lblteamcode.Location = New System.Drawing.Point(24, 114)
        Me.lblteamcode.Name = "lblteamcode"
        Me.lblteamcode.Size = New System.Drawing.Size(73, 15)
        Me.lblteamcode.TabIndex = 1313
        Me.lblteamcode.Text = "Tổ"
        Me.lblteamcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbldepartmentcode
        '
        Me.lbldepartmentcode.BackColor = System.Drawing.Color.Transparent
        Me.lbldepartmentcode.Location = New System.Drawing.Point(24, 66)
        Me.lbldepartmentcode.Name = "lbldepartmentcode"
        Me.lbldepartmentcode.Size = New System.Drawing.Size(73, 15)
        Me.lbldepartmentcode.TabIndex = 1312
        Me.lbldepartmentcode.Text = "Bộ phận"
        Me.lbldepartmentcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition_ID
        '
        Me.lblPosition_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition_ID.Location = New System.Drawing.Point(24, 141)
        Me.lblPosition_ID.Name = "lblPosition_ID"
        Me.lblPosition_ID.Size = New System.Drawing.Size(75, 19)
        Me.lblPosition_ID.TabIndex = 1311
        Me.lblPosition_ID.Text = "Chức vụ"
        Me.lblPosition_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPosition_ID.Visible = False
        '
        'lblPositionCategory_ID
        '
        Me.lblPositionCategory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_ID.Location = New System.Drawing.Point(433, 142)
        Me.lblPositionCategory_ID.Name = "lblPositionCategory_ID"
        Me.lblPositionCategory_ID.Size = New System.Drawing.Size(10, 19)
        Me.lblPositionCategory_ID.TabIndex = 1310
        Me.lblPositionCategory_ID.Text = "Loại chức vụ"
        Me.lblPositionCategory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPositionCategory_ID.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(538, 2)
        Me.TableLayoutPanel2.TabIndex = 1302
        '
        'TuNgayDenNgay2
        '
        Me.TuNgayDenNgay2.Controls.Add(Me.para_todate)
        Me.TuNgayDenNgay2.Controls.Add(Me.para_fromdate)
        Me.TuNgayDenNgay2.Controls.Add(Me.lbltodate)
        Me.TuNgayDenNgay2.Controls.Add(Me.lblfromdate)
        Me.TuNgayDenNgay2.Name = "TuNgayDenNgay2"
        Me.TuNgayDenNgay2.PageVisible = False
        Me.TuNgayDenNgay2.Size = New System.Drawing.Size(538, 198)
        Me.TuNgayDenNgay2.Text = "Từ ngày đến ngày"
        '
        'para_todate
        '
        Me.para_todate.EditValue = Nothing
        Me.para_todate.Location = New System.Drawing.Point(186, 73)
        Me.para_todate.Name = "para_todate"
        Me.para_todate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_todate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_todate.Properties.DisplayFormat.FormatString = ""
        Me.para_todate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.para_todate.Properties.EditFormat.FormatString = ""
        Me.para_todate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.para_todate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.para_todate.Properties.MaskSettings.Set("mask", "d")
        Me.para_todate.Properties.UseMaskAsDisplayFormat = True
        Me.para_todate.Size = New System.Drawing.Size(121, 20)
        Me.para_todate.TabIndex = 177
        '
        'para_fromdate
        '
        Me.para_fromdate.EditValue = Nothing
        Me.para_fromdate.Location = New System.Drawing.Point(186, 49)
        Me.para_fromdate.Name = "para_fromdate"
        Me.para_fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_fromdate.Properties.DisplayFormat.FormatString = ""
        Me.para_fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.para_fromdate.Properties.EditFormat.FormatString = ""
        Me.para_fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.para_fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.para_fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.para_fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.para_fromdate.Size = New System.Drawing.Size(121, 20)
        Me.para_fromdate.TabIndex = 176
        '
        'lbltodate
        '
        Me.lbltodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltodate.Location = New System.Drawing.Point(116, 72)
        Me.lbltodate.Name = "lbltodate"
        Me.lbltodate.Size = New System.Drawing.Size(56, 20)
        Me.lbltodate.TabIndex = 174
        Me.lbltodate.Text = "Đến ngày"
        Me.lbltodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblfromdate
        '
        Me.lblfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfromdate.Location = New System.Drawing.Point(116, 48)
        Me.lblfromdate.Name = "lblfromdate"
        Me.lblfromdate.Size = New System.Drawing.Size(64, 20)
        Me.lblfromdate.TabIndex = 175
        Me.lblfromdate.Text = "Từ ngày"
        Me.lblfromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ngay3
        '
        Me.Ngay3.Controls.Add(Me.para_Ngay)
        Me.Ngay3.Controls.Add(Me.lblNgay)
        Me.Ngay3.Name = "Ngay3"
        Me.Ngay3.PageVisible = False
        Me.Ngay3.Size = New System.Drawing.Size(538, 198)
        Me.Ngay3.Text = "Ngày"
        '
        'para_Ngay
        '
        Me.para_Ngay.EditValue = Nothing
        Me.para_Ngay.Location = New System.Drawing.Point(181, 51)
        Me.para_Ngay.Name = "para_Ngay"
        Me.para_Ngay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_Ngay.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_Ngay.Properties.DisplayFormat.FormatString = ""
        Me.para_Ngay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.para_Ngay.Properties.EditFormat.FormatString = ""
        Me.para_Ngay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.para_Ngay.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.para_Ngay.Properties.MaskSettings.Set("mask", "d")
        Me.para_Ngay.Properties.UseMaskAsDisplayFormat = True
        Me.para_Ngay.Size = New System.Drawing.Size(121, 20)
        Me.para_Ngay.TabIndex = 177
        '
        'lblNgay
        '
        Me.lblNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgay.Location = New System.Drawing.Point(111, 50)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(64, 20)
        Me.lblNgay.TabIndex = 175
        Me.lblNgay.Text = "Ngày"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Thang4
        '
        Me.Thang4.Controls.Add(Me.para_Year)
        Me.Thang4.Controls.Add(Me.para_Month)
        Me.Thang4.Controls.Add(Me.Label1)
        Me.Thang4.Name = "Thang4"
        Me.Thang4.PageVisible = False
        Me.Thang4.Size = New System.Drawing.Size(538, 198)
        Me.Thang4.Text = "Tháng"
        '
        'para_Year
        '
        Me.para_Year.Location = New System.Drawing.Point(246, 56)
        Me.para_Year.Name = "para_Year"
        Me.para_Year.Size = New System.Drawing.Size(56, 20)
        Me.para_Year.TabIndex = 229
        '
        'para_Month
        '
        Me.para_Month.Location = New System.Drawing.Point(194, 56)
        Me.para_Month.Name = "para_Month"
        Me.para_Month.Size = New System.Drawing.Size(40, 20)
        Me.para_Month.TabIndex = 228
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(124, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 227
        Me.Label1.Text = "Tháng"
        '
        'LoaiHD5
        '
        Me.LoaiHD5.Controls.Add(Me.para_TypeOfContract)
        Me.LoaiHD5.Controls.Add(Me.lblType)
        Me.LoaiHD5.Name = "LoaiHD5"
        Me.LoaiHD5.PageVisible = False
        Me.LoaiHD5.Size = New System.Drawing.Size(538, 198)
        Me.LoaiHD5.Text = "Loại HĐ"
        '
        'para_TypeOfContract
        '
        Me.para_TypeOfContract.Location = New System.Drawing.Point(181, 58)
        Me.para_TypeOfContract.Name = "para_TypeOfContract"
        Me.para_TypeOfContract.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_TypeOfContract.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_TypeOfContract.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_TypeOfContract.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_TypeOfContract.Size = New System.Drawing.Size(216, 20)
        Me.para_TypeOfContract.TabIndex = 1321
        '
        'lblType
        '
        Me.lblType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(71, 57)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(104, 20)
        Me.lblType.TabIndex = 306
        Me.lblType.Text = "Loại HĐ"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DanhSachKey6
        '
        Me.DanhSachKey6.Controls.Add(Me.para_DanhSachKey)
        Me.DanhSachKey6.Name = "DanhSachKey6"
        Me.DanhSachKey6.PageVisible = False
        Me.DanhSachKey6.Size = New System.Drawing.Size(538, 198)
        Me.DanhSachKey6.Text = "Danh sách key"
        '
        'para_DanhSachKey
        '
        Me.para_DanhSachKey.Location = New System.Drawing.Point(111, 36)
        Me.para_DanhSachKey.Name = "para_DanhSachKey"
        Me.para_DanhSachKey.Size = New System.Drawing.Size(240, 112)
        Me.para_DanhSachKey.TabIndex = 1
        Me.para_DanhSachKey.Text = ""
        '
        'DSNhanVien7
        '
        Me.DSNhanVien7.Controls.Add(Me.gridDanhSachNhanVien)
        Me.DSNhanVien7.Name = "DSNhanVien7"
        Me.DSNhanVien7.PageVisible = False
        Me.DSNhanVien7.Size = New System.Drawing.Size(538, 198)
        Me.DSNhanVien7.Text = "DS nhân viên"
        '
        'gridDanhSachNhanVien
        '
        Me.gridDanhSachNhanVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDanhSachNhanVien.Location = New System.Drawing.Point(0, 0)
        Me.gridDanhSachNhanVien.MainView = Me.GridView1
        Me.gridDanhSachNhanVien.Name = "gridDanhSachNhanVien"
        Me.gridDanhSachNhanVien.Size = New System.Drawing.Size(538, 198)
        Me.gridDanhSachNhanVien.TabIndex = 1322
        Me.gridDanhSachNhanVien.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridDanhSachNhanVien
        Me.GridView1.Name = "GridView1"
        '
        'nationality8
        '
        Me.nationality8.Controls.Add(Me.para_nationality)
        Me.nationality8.Controls.Add(Me.lblnationality)
        Me.nationality8.Name = "nationality8"
        Me.nationality8.PageVisible = False
        Me.nationality8.Size = New System.Drawing.Size(538, 198)
        Me.nationality8.Text = "Quốc tịch"
        '
        'para_nationality
        '
        Me.para_nationality.Location = New System.Drawing.Point(181, 67)
        Me.para_nationality.Name = "para_nationality"
        Me.para_nationality.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_nationality.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_nationality.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_nationality.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_nationality.Size = New System.Drawing.Size(216, 20)
        Me.para_nationality.TabIndex = 1322
        '
        'lblnationality
        '
        Me.lblnationality.BackColor = System.Drawing.Color.Transparent
        Me.lblnationality.Location = New System.Drawing.Point(63, 67)
        Me.lblnationality.Name = "lblnationality"
        Me.lblnationality.Size = New System.Drawing.Size(112, 19)
        Me.lblnationality.TabIndex = 84
        Me.lblnationality.Text = "Quốc tịch"
        Me.lblnationality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SalaryTable9
        '
        Me.SalaryTable9.Controls.Add(Me.para_SalaryTable)
        Me.SalaryTable9.Controls.Add(Me.lblSalaryTable)
        Me.SalaryTable9.Name = "SalaryTable9"
        Me.SalaryTable9.PageVisible = False
        Me.SalaryTable9.Size = New System.Drawing.Size(538, 198)
        Me.SalaryTable9.Text = "Bảng lương"
        '
        'para_SalaryTable
        '
        Me.para_SalaryTable.Location = New System.Drawing.Point(189, 62)
        Me.para_SalaryTable.Name = "para_SalaryTable"
        Me.para_SalaryTable.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.para_SalaryTable.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.para_SalaryTable.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.para_SalaryTable.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.para_SalaryTable.Size = New System.Drawing.Size(216, 20)
        Me.para_SalaryTable.TabIndex = 1323
        '
        'lblSalaryTable
        '
        Me.lblSalaryTable.BackColor = System.Drawing.Color.Transparent
        Me.lblSalaryTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalaryTable.Location = New System.Drawing.Point(103, 62)
        Me.lblSalaryTable.Name = "lblSalaryTable"
        Me.lblSalaryTable.Size = New System.Drawing.Size(80, 19)
        Me.lblSalaryTable.TabIndex = 212
        Me.lblSalaryTable.Text = "Bảng lương"
        Me.lblSalaryTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nam10
        '
        Me.Nam10.Controls.Add(Me.para_year_)
        Me.Nam10.Controls.Add(Me.lblYear_)
        Me.Nam10.Name = "Nam10"
        Me.Nam10.PageVisible = False
        Me.Nam10.Size = New System.Drawing.Size(538, 198)
        Me.Nam10.Text = "Năm"
        '
        'para_year_
        '
        Me.para_year_.Location = New System.Drawing.Point(174, 45)
        Me.para_year_.Name = "para_year_"
        Me.para_year_.Size = New System.Drawing.Size(56, 20)
        Me.para_year_.TabIndex = 230
        '
        'lblYear_
        '
        Me.lblYear_.Location = New System.Drawing.Point(104, 49)
        Me.lblYear_.Name = "lblYear_"
        Me.lblYear_.Size = New System.Drawing.Size(64, 16)
        Me.lblYear_.TabIndex = 229
        Me.lblYear_.Text = "Năm"
        '
        'LeaveType11
        '
        Me.LeaveType11.Controls.Add(Me.para_LeaveType)
        Me.LeaveType11.Name = "LeaveType11"
        Me.LeaveType11.PageVisible = False
        Me.LeaveType11.Size = New System.Drawing.Size(538, 198)
        Me.LeaveType11.Text = "Danh mục phép"
        '
        'para_LeaveType
        '
        Me.para_LeaveType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.para_LeaveType.Location = New System.Drawing.Point(0, 0)
        Me.para_LeaveType.MainView = Me.GridView2
        Me.para_LeaveType.Name = "para_LeaveType"
        Me.para_LeaveType.Size = New System.Drawing.Size(538, 198)
        Me.para_LeaveType.TabIndex = 1323
        Me.para_LeaveType.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.para_LeaveType
        Me.GridView2.Name = "GridView2"
        '
        'lblMonth_
        '
        Me.lblMonth_.Location = New System.Drawing.Point(71, 60)
        Me.lblMonth_.Name = "lblMonth_"
        Me.lblMonth_.Size = New System.Drawing.Size(64, 18)
        Me.lblMonth_.TabIndex = 227
        Me.lblMonth_.Text = "Tháng"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(185, 377)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 29)
        Me.btnOk.TabIndex = 1011
        Me.btnOk.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(274, 377)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 29)
        Me.btnCancel.TabIndex = 1012
        Me.btnCancel.Text = "Cancel"
        '
        'frmPara
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(540, 451)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.gbLuaChonHienThi)
        Me.Name = "frmPara"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPara"
        Me.gbLuaChonHienThi.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.ViTri1.ResumeLayout(False)
        Me.ViTri1.PerformLayout()
        CType(Me.para_ChucDanh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_PositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_Position_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_teamcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_sectioncode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_departmentcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_Factory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_Position.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TuNgayDenNgay2.ResumeLayout(False)
        CType(Me.para_todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ngay3.ResumeLayout(False)
        CType(Me.para_Ngay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.para_Ngay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Thang4.ResumeLayout(False)
        Me.LoaiHD5.ResumeLayout(False)
        CType(Me.para_TypeOfContract.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DanhSachKey6.ResumeLayout(False)
        Me.DSNhanVien7.ResumeLayout(False)
        CType(Me.gridDanhSachNhanVien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.nationality8.ResumeLayout(False)
        CType(Me.para_nationality.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SalaryTable9.ResumeLayout(False)
        CType(Me.para_SalaryTable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Nam10.ResumeLayout(False)
        Me.LeaveType11.ResumeLayout(False)
        CType(Me.para_LeaveType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmPara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabLoaiHD As DataTable = kn.ReadData("select * from SmartBooks_Contract", "table")
        tvcn.GetDataOnDropDown(para_TypeOfContract, tabLoaiHD, "ConTract_NameVN", "Contract_ID")

        Dim tabPosition As DataTable
        'Lay quyen truy xuat
        tabQuyenTX = kn.ReadData("select * from [User] where UserName='" + obj.UserName + "'", "table")
        If Not IsDBNull(tabQuyenTX.Rows(0)("QuyenTruyXuat")) Then
            tabPosition = kn.ReadData("select * from udf_Position('" + obj.Lan + "',0) where code in ('" + tabQuyenTX.Rows(0)("QuyenTruyXuat").ToString.Replace(",", "','") + "')", "table")
        Else
            tabPosition = kn.ReadData("select * from udf_Position('" + obj.Lan + "',0)", "table")
        End If
        tvcn.GetDataOnDropDownCategoryCodeName(para_Position, tabPosition)
        'load bảng loại phép
        para_LeaveType.DataSource = kn.ReadData("select Leavetype_ID as Code, LeaveType_" + obj.Lan + " as Name from smartbooks_leavetype", "table")
        'Load bảng lương
        tvcn.GetDataOnDropDown(para_SalaryTable, kn.ReadData("select * from HR_SalaryTable", "table"), "Name" + obj.Lan, "Code")

        Me.para_TypeOfContract.EditValue = obj.PARA_TYPEOFCONTRACT
        tvcn.GetDataOnDropDownCategoryCodeName(para_Factory_ID, kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "')", "table"))
        If obj.PARA_FACTORY_ID = String.Empty Then
            Me.para_Factory_ID.EditValue = DBNull.Value
        Else
            Me.para_Factory_ID.EditValue = obj.PARA_FACTORY_ID
        End If
        If obj.PARA_DEPARTMENTCODE = String.Empty Then
            Me.para_departmentcode.EditValue = DBNull.Value
        Else
            Me.para_departmentcode.EditValue = obj.PARA_DEPARTMENTCODE
        End If
        If obj.PARA_SECTIONCODE = String.Empty Then
            Me.para_sectioncode.EditValue = DBNull.Value
        Else
            Me.para_sectioncode.EditValue = obj.PARA_SECTIONCODE
        End If
        If obj.PARA_TEAMCODE = String.Empty Then
            Me.para_teamcode.EditValue = DBNull.Value
        Else
            Me.para_teamcode.EditValue = obj.PARA_TEAMCODE
        End If
        Me.para_Position_ID.EditValue = obj.PARA_POSITION_ID
        Me.para_PositionCategory_ID.EditValue = obj.PARA_POSITIONCATEGORY_ID
        Me.para_nationality.EditValue = obj.PARA_NATIONALITY
        Me.para_SalaryTable.EditValue = obj.PARA_SALARYTABLE

        'Set up Default HRFORM_Gridview
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        GridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25
        GridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsMenu.ShowAutoFilterRowItem = True
        GridView1.OptionsView.ShowAutoFilterRow = True

        'Set up Default HRFORM_Gridview
        GridView2.OptionsSelection.MultiSelect = True
        GridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        GridView2.OptionsSelection.CheckBoxSelectorColumnWidth = 25
        GridView2.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False
        GridView2.OptionsView.ColumnAutoWidth = True
        GridView2.OptionsMenu.ShowAutoFilterRowItem = True
        GridView2.OptionsView.ShowAutoFilterRow = True

        LoadLoaiReport()
        If Not IsDBNull(ReportInformation("Parameter")) Then
            For Each s As String In Split(ReportInformation("Parameter"), ",")
                LoadGiaoDien(s, Me)
            Next
        End If

        'Lưu giá trị lên biến chung
        Me.para_fromdate.EditValue = obj.PARA_FROMDATE
        Me.para_todate.EditValue = obj.PARA_TODATE
        Me.para_Ngay.EditValue = obj.PARA_NGAY
        Try
            Me.para_Month.Text = obj.PARA_MONTH.ToString
            Me.para_Year.Text = obj.PARA_YEAR.ToString
            Me.para_year_.Text = obj.PARA_YEAR_.ToString
        Catch ex As Exception

        End Try
        tvcn.ChangeLanguageToForm(Me, "")
    End Sub

    Private Sub LoadLoaiReport()
        For Each ct As Object In gbLuaChonHienThi.Controls
            Try
                If Not IsDBNull(ReportInformation(ct.Name)) Then
                    If ReportInformation(ct.Name) = True Then
                        ct.Enabled = True
                        ct.Checked = True
                    End If
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub LoadGiaoDien(ByVal ControlName As String, ByRef ParenControl As Control)
        Dim regex As Regex = New Regex("[0-9]+$")
        Dim match As Match = regex.Match(ParenControl.Name)
        Dim IndexOfTab As Integer = 0
        If match.Success Then
            IndexOfTab = CInt(match.Value) - 1
        End If
        If ParenControl.Name.ToUpper = ControlName.ToUpper Then
            XtraTabControl1.TabPages(IndexOfTab).PageVisible = True
        Else
            If ParenControl.Controls.Count >= 1 Then
                For Each ct As Control In ParenControl.Controls
                    If ct.Name.ToUpper = ControlName.ToUpper Then
                        XtraTabControl1.TabPages(IndexOfTab).PageVisible = True
                    Else
                        LoadGiaoDien(ControlName, ct)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click 'Handles btnOk.Click
        obj.PARA_FROMDATE = para_fromdate.EditValue
        obj.PARA_TODATE = para_todate.EditValue
        obj.PARA_NGAY = para_Ngay.EditValue
        Try
            obj.PARA_MONTH = CInt(para_Month.Text)
            obj.PARA_YEAR = CInt(para_Year.Text)
            obj.PARA_YEAR_ = CInt(para_year_.Text)
        Catch ex As Exception

        End Try
        obj.PARA_TYPEOFCONTRACT = para_TypeOfContract.EditValue
        If Not IsDBNull(tabQuyenTX.Rows(0)("QuyenTruyXuat")) Then
            If IsDBNull(para_Factory_ID.EditValue) Or IsNothing(para_Factory_ID.EditValue) Then
                para_Factory_ID.EditValue = tabQuyenTX.Rows(0)("QuyenTruyXuat")
            End If
        End If

        If Not IsDBNull(para_Factory_ID.EditValue) Then
            obj.PARA_FACTORY_ID = para_Factory_ID.EditValue
        Else
            obj.PARA_FACTORY_ID = String.Empty
        End If

        If Not IsDBNull(para_departmentcode.EditValue) Then
            obj.PARA_DEPARTMENTCODE = para_departmentcode.EditValue
        Else
            obj.PARA_DEPARTMENTCODE = String.Empty
        End If
        If Not IsDBNull(para_sectioncode.EditValue) Then
            obj.PARA_SECTIONCODE = para_sectioncode.EditValue
        Else
            obj.PARA_SECTIONCODE = String.Empty
        End If
        If Not IsDBNull(para_teamcode.EditValue) Then
            obj.PARA_TEAMCODE = para_teamcode.EditValue
        Else
            obj.PARA_TEAMCODE = String.Empty
        End If
        obj.PARA_POSITION_ID = para_Position_ID.EditValue
        obj.PARA_POSITIONCATEGORY_ID = para_PositionCategory_ID.EditValue
        bViewOnGrid = ViewOnGrid.Checked
        bPrintView = PrintView.Checked
        bPrintViewDocument = PrinViewDocument.Checked
        If ExportExcel.Checked = True Then
            Dim bSaveData As Boolean, Excel_XoaDenDong As Integer, NotDeleteConfig As Boolean
            NotDeleteConfig = IIf(IsDBNull(ReportInformation("NotDeleteConfig")), False, ReportInformation("NotDeleteConfig"))
            If Not IsDBNull(ReportInformation("SaveData")) Then
                bSaveData = ReportInformation("SaveData")
            End If
            Dim bExportExcel As Boolean
            Dim bisOpen As Boolean = True
            Dim TemplateFile As String = ReportInformation("TemplateFile")
            If ExportExcel.Checked = True Then
                Dim fileChooser As SaveFileDialog = New SaveFileDialog
                If TemplateFile.Contains(".xlsx") Then
                    fileChooser.DefaultExt = "xlsx"
                Else
                    fileChooser.DefaultExt = "xls"
                End If
                fileChooser.FileName = TemplateFile
                Dim result As DialogResult
                result = fileChooser.ShowDialog()
                fileChooser.CheckFileExists = True
                If result = DialogResult.OK Then
                    Dim WriteLine, ConfigLine, BorderLine, SaveConfigLine As Integer
                    WriteLine = ReportInformation("WriteLine")
                    ConfigLine = ReportInformation("ConfigLine")
                    BorderLine = ReportInformation("BorderLine")
                    If bSaveData = True Then
                        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            bisOpen = False
                        Else
                            bSaveData = False
                        End If
                    End If
                    Dim table As DataTable = kn.ReadData(CreateQueryForReport(), "table")
                    If IsNothing(table) Then
                        Exit Sub
                    End If
                    If table.Rows.Count = 0 Then
                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Khongcodulieudexuat"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    'Dim Content As String = "2"
                    'If ReportInformation("ReportCode") = "BangLuongGuiNganHangBonus" Then
                    '    Content = para_Year.Text
                    'End If

                    If TemplateFile.Contains(".xlsx") Then
                        If Not IsDBNull(ReportInformation("Excel_XoaDenDong")) Then
                            Excel_XoaDenDong = ReportInformation("Excel_XoaDenDong")
                        End If
                        If Not IsDBNull(ReportInformation("GroupBy")) Then
                            bExportExcel = tvcn.XuatExcelTheoTableEPPlus(Application.StartupPath() + "\Teamleate\" + TemplateFile, fileChooser.FileName(), table, bisOpen, WriteLine, ConfigLine, BorderLine, Split(ReportInformation("GroupBy"), ","), ReturnValuesParameter, 1, NotDeleteConfig)
                        Else
                            bExportExcel = tvcn.XuatExcelTheoTableEPPlus(Application.StartupPath() + "\Teamleate\" + TemplateFile, fileChooser.FileName(), table, bisOpen, WriteLine, ConfigLine, BorderLine, "", ReturnValuesParameter(), Excel_XoaDenDong, True, NotDeleteConfig)
                        End If
                    Else
                        If Not IsDBNull(ReportInformation("GroupBy")) Then
                            bExportExcel = tvcn.XuatExcelTheoTable(Application.StartupPath() + "\Teamleate\" + TemplateFile, {"Sheet1"}, fileChooser.FileName(), table, bisOpen, WriteLine, ConfigLine, BorderLine, Split(ReportInformation("GroupBy"), ","), ReturnValuesParameter, 1, NotDeleteConfig)
                        Else
                            bExportExcel = tvcn.XuatExcelTheoTable(Application.StartupPath() + "\Teamleate\" + TemplateFile, fileChooser.FileName(), table, bisOpen, WriteLine, ConfigLine, BorderLine, "", ReturnValuesParameter(), True, NotDeleteConfig)
                        End If
                    End If
                    If bExportExcel = True Then
                        If bSaveData = True Then
                            If Quyen.ToUpper = "VIEW" Then
                                Exit Sub
                            End If
                            'Dim tabSaveSalaryInfor As DataTable = kn.ReadData("select * from HR_Report where ReportCode='" + ReportInformation("ReportCode") + "'", "table")
                            'If tabSaveSalaryInfor.Rows.Count > 0 Then
                            Dim PrimaryConfigLine As Integer
                            Dim InsertDateName, UserNameName As String
                            SaveConfigLine = ReportInformation("SaveConfigLine")
                            PrimaryConfigLine = ReportInformation("PrimaryConfigLine")
                            If Not IsDBNull(ReportInformation("InsertDateName")) Then
                                InsertDateName = ReportInformation("InsertDateName")
                            Else
                                InsertDateName = "InsertDate"
                            End If
                            If Not IsDBNull(ReportInformation("UserNameName")) Then
                                UserNameName = ReportInformation("UserNameName")
                            Else
                                UserNameName = "UserName"
                            End If
                            If IsDBNull(ReportInformation("NameOfTable")) Then
                                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banchuanhaptenbangdulieu"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                            If TemplateFile.Contains(".xlsx") Then
                                'tvcn.NhapExcelEPPlus(ReportInformation("NameOfTable"), fileChooser.FileName(), SaveConfigLine, PrimaryConfigLine, WriteLine, InsertDateName, UserNameName)
                                tvcn.NhapExcelInteropExcel(ReportInformation("NameOfTable"), fileChooser.FileName(), SaveConfigLine, PrimaryConfigLine, WriteLine, InsertDateName, UserNameName)
                                Dim fi As New FileInfo(fileChooser.FileName())
                                System.Diagnostics.Process.Start(fileChooser.FileName())
                            Else
                                tvcn.NhapExcel("Sheet1", ReportInformation("NameOfTable"), fileChooser.FileName(), SaveConfigLine, PrimaryConfigLine, WriteLine, InsertDateName, UserNameName)
                                Dim ps As New ProcessStartInfo
                                ps.UseShellExecute = True
                                ps.FileName = fileChooser.FileName()
                                Process.Start(ps)
                            End If
                            'End If
                        End If
                    End If
                End If
            End If
        ElseIf GetTemplateFile.Checked = True Then
            Dim TemplateFile As String = ReportInformation("TemplateFile")
            tvcn.LayTemplateEPPlus(Application.StartupPath() + "\Teamleate\" + TemplateFile)
        ElseIf InputTemplateFile.Checked = True Then
            Dim WriteLine, ConfigLine, BorderLine, PrimaryConfigLine As Integer
            Dim InsertDateName, UserNameName As String
            WriteLine = ReportInformation("WriteLine")
            ConfigLine = ReportInformation("SaveConfigLine")
            PrimaryConfigLine = ReportInformation("PrimaryConfigLine")
            If Not IsDBNull(ReportInformation("InsertDateName")) Then
                InsertDateName = ReportInformation("InsertDateName")
            Else
                InsertDateName = "InsertDate"
            End If
            If Not IsDBNull(ReportInformation("UserNameName")) Then
                UserNameName = ReportInformation("UserNameName")
            Else
                UserNameName = "UserName"
            End If
            If IsDBNull(ReportInformation("NameOfTable")) Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banchuanhaptenbangdulieu"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim ofd As New OpenFileDialog
            With ofd
                '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
                .Title = "Locate File"
                .Filter = "Excel file (*.xls)|*.xls|(*.xlsx)|*.xlsx|All files (*.*)|*.*"
            End With
            If ofd.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
            If ofd.FileName.Contains(".xlsx") Then
                tvcn.NhapExcelEPPlus(ReportInformation("NameOfTable"), ofd.FileName, ConfigLine, PrimaryConfigLine, WriteLine, InsertDateName, UserNameName)
            ElseIf ofd.FileName.Contains(".xls") Then
                tvcn.NhapExcel("Sheet1", ReportInformation("NameOfTable"), ofd.FileName, ConfigLine, PrimaryConfigLine, WriteLine, InsertDateName, UserNameName)
            End If
        ElseIf ExecStore.Checked = True Then
            If Quyen.ToUpper = "VIEW" Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banchuanhaptenbangdulieu"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim tabThongBao As DataTable
            tabThongBao = kn.ReadData(CreateQueryForReport(), "table")
            If IsNothing(tabThongBao) Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitrongquatrinhthuchien"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If tabThongBao.Rows.Count > 0 Then
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup." + tabThongBao.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitrongquatrinhthuchien"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
        bThucHienLenh = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click 'Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub para_Factory_ID_ValueChanged(sender As Object, e As EventArgs) Handles para_Factory_ID.EditValueChanged
        para_departmentcode.EditValue = DBNull.Value
        para_sectioncode.EditValue = DBNull.Value
        para_teamcode.EditValue = DBNull.Value
        tvcn.GetDataOnDropDownCategoryCodeName(para_departmentcode, kn.ReadData("select * from [dbo].[udf_Department]('" + IIf(IsDBNull(para_Factory_ID.EditValue) = True, "", para_Factory_ID.EditValue) + "','" + obj.Lan + "',1)", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(para_sectioncode, kn.ReadData("select * from [dbo].[udf_Section]('" + IIf(IsDBNull(para_Factory_ID.EditValue) = True, "", para_Factory_ID.EditValue) + "',null,'" + obj.Lan + "',1)", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(para_teamcode, kn.ReadData("select * from [dbo].[udf_Team]('" + IIf(IsDBNull(para_Factory_ID.EditValue) = True, "", para_Factory_ID.EditValue) + "',null,null,'" + obj.Lan + "',1)", "table"))
    End Sub
    Private Sub para_departmentcode_ValueChanged(sender As Object, e As EventArgs) Handles para_departmentcode.EditValueChanged
        para_sectioncode.EditValue = DBNull.Value
        para_teamcode.EditValue = DBNull.Value
        Dim Filter As String
        Dim fact, dept As String
        fact = "null"
        dept = "null"
        If Not IsDBNull(para_departmentcode.EditValue) Then
            Filter = para_departmentcode.EditValue
            fact = "N'" + Split(Filter, "_")(0) + "'"
            dept = "N'" + Split(Filter, "_")(1) + "'"
        End If
        tvcn.GetDataOnDropDownCategoryCodeName(para_sectioncode, kn.ReadData("select * from [dbo].[udf_Section](" + fact + "," + dept + ",'" + obj.Lan + "',1)", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(para_teamcode, kn.ReadData("select * from [dbo].[udf_Team](" + fact + "," + dept + ",null,'" + obj.Lan + "',1)", "table"))
    End Sub
    Private Sub para_sectioncode_ValueChanged(sender As Object, e As EventArgs) Handles para_sectioncode.EditValueChanged
        para_teamcode.EditValue = DBNull.Value
        Dim Filter As String
        Dim fact, dept, sect As String
        fact = "null"
        dept = "null"
        sect = "null"
        If Not IsDBNull(para_sectioncode.EditValue) Then
            Filter = para_sectioncode.EditValue
            fact = "N'" + Split(Filter, "_")(0) + "'"
            dept = "N'" + Split(Filter, "_")(1) + "'"
            sect = "N'" + Split(Filter, "_")(2) + "'"
        End If
        tvcn.GetDataOnDropDownCategoryCodeName(para_teamcode, kn.ReadData("select * from [dbo].[udf_Team](" + fact + "," + dept + "," + sect + ",'" + obj.Lan + "',1)", "table"))
    End Sub

    Private Sub para_Position_ValueChanged(sender As Object, e As EventArgs) Handles para_Position.EditValueChanged
        para_Factory_ID.EditValue = DBNull.Value
        If Not IsDBNull(para_Position.EditValue) Then
            Dim ps As String() = Split(para_Position.EditValue, "_")
            para_Factory_ID.EditValue = ps(0)
            If ps.Length >= 2 Then
                para_departmentcode.EditValue = ps(0) + "_" + ps(1)
                If ps.Length >= 3 Then
                    para_sectioncode.EditValue = ps(0) + "_" + ps(1) + "_" + ps(2)
                    If ps.Length >= 4 Then
                        para_teamcode.EditValue = ps(0) + "_" + ps(1) + "_" + ps(2) + "_" + ps(3)
                    End If
                End If
            End If
        End If
        If Not IsDBNull(tabQuyenTX.Rows(0)("QuyenTruyXuat")) Then
            'para_Position.Enabled = False
            If Not IsDBNull(para_Factory_ID.EditValue) Then
                If para_Factory_ID.EditValue <> String.Empty Then
                    para_Factory_ID.Enabled = False
                End If
            End If
            If Not IsDBNull(para_departmentcode.EditValue) Then
                If para_departmentcode.EditValue <> String.Empty Then
                    para_departmentcode.Enabled = False
                End If
            End If
            If Not IsDBNull(para_sectioncode.EditValue) Then
                If para_sectioncode.EditValue <> String.Empty Then
                    para_sectioncode.Enabled = False
                End If
            End If
            If Not IsDBNull(para_teamcode.EditValue) Then
                If para_teamcode.EditValue <> String.Empty Then
                    para_teamcode.Enabled = False
                End If
            End If
        End If
    End Sub

    Public Function ObjectParameter() As Object()
        Dim arrlObject As New ArrayList()
        Dim strParameter, strQuery As String
        Dim ct As Control
        If Not IsDBNull(ReportInformation("Parameter")) Then
            For Each s As String In Split(ReportInformation("Parameter"), ",")
                If s.StartsWith("para_") Then
                    tvcn.FindControl(s, Me, ct)

                    If TypeOf ct Is DateTimeOffsetEdit Then
                        arrlObject.Add(CType(ct, DateTimeOffsetEdit).EditValue)
                    ElseIf TypeOf ct Is LookUpEdit Then
                        If IsNothing(CType(ct, LookUpEdit).EditValue) Then
                            arrlObject.Add("")
                        Else
                            If IsDBNull(CType(ct, LookUpEdit).EditValue) Then
                                arrlObject.Add("")
                            Else
                                arrlObject.Add(CType(ct, LookUpEdit).EditValue)
                            End If

                        End If
                    ElseIf TypeOf ct Is System.Windows.Forms.CheckBox Then
                        If CType(ct, System.Windows.Forms.CheckBox).Checked = True Then
                            arrlObject.Add(1)
                        Else
                            arrlObject.Add(0)
                        End If
                    ElseIf TypeOf ct Is System.Windows.Forms.RadioButton Then
                        If CType(ct, System.Windows.Forms.RadioButton).Checked = True Then
                            arrlObject.Add(1)
                        Else
                            arrlObject.Add(0)
                        End If
                    ElseIf TypeOf ct Is WindowsControlLibrary.Month Or TypeOf ct Is WindowsControlLibrary.Year Then
                        arrlObject.Add(ct.Text)
                    ElseIf ct.Name.ToUpper = "PARA_DANHSACHKEY" Then
                        arrlObject.Add(ct.Text)
                    Else
                        arrlObject.Add(ct.Text)
                    End If
                ElseIf s.StartsWith("#") And s.EndsWith("#") Then
                    If s.ToUpper = "#LAN#" Then
                        arrlObject.Add(obj.Lan)
                    ElseIf s.ToUpper = "#USERNAME#" Then
                        arrlObject.Add(obj.UserName)
                    End If
                ElseIf s.ToUpper = "NULL" Then
                    arrlObject.Add("")
                Else
                    arrlObject.Add(s)
                End If
            Next
        End If
        Return arrlObject.ToArray()
    End Function

    Public Function CreateQueryForReport() As String
        Dim strParameter, strQuery As String
        Dim ct As Control
        If Not IsDBNull(ReportInformation("Parameter")) Then
            For Each s As String In Split(ReportInformation("Parameter"), ",")
                If s.StartsWith("para_") Then
                    tvcn.FindControl(s, Me, ct)
                    strParameter += GetParameterInQuery(ct) + ","
                ElseIf s.StartsWith("#") And s.EndsWith("#") Then
                    If s.ToUpper = "#LAN#" Then
                        strParameter += "N'" + obj.Lan + "',"
                    ElseIf s.ToUpper = "#USERNAME#" Then
                        strParameter += "N'" + obj.UserName + "',"
                    End If
                Else
                    strParameter += s + ","
                End If
            Next
        End If
        If strParameter <> String.Empty Then
            strParameter = strParameter.Remove(strParameter.Length - 1, 1)
        End If
        'TAO QUERY TRUY VAN
        If Not IsDBNull(ReportInformation("NameOfFuntion")) Then
            strQuery = "select * from " + ReportInformation("NameOfFuntion") + " (" + strParameter + ")"
        ElseIf Not IsDBNull(ReportInformation("NameOfStore")) Then
            strQuery = "exec " + ReportInformation("NameOfStore") + " " + strParameter
        ElseIf Not IsDBNull(ReportInformation("NameOfTable")) Then
            strQuery = "select * from [dbo].[" + ReportInformation("NameOfTable") + "]"
        End If
        tvcn.GhiNoiDungVaoFileDebug(tvcn.GetAppPath() & "\LOG\Debug.txt", strQuery)
        Return strQuery
    End Function

    Public Function ReturnValuesParameter() As ArrayList
        Dim arrlRTN As New ArrayList
        Dim ct As Control
        If Not IsDBNull(ReportInformation("Parameter")) Then
            For Each s As String In Split(ReportInformation("Parameter"), ",")
                If s.StartsWith("para_") Then
                    tvcn.FindControl(s, Me, ct)
                    arrlRTN.Add(GetValueOfParameter(ct))
                ElseIf s.StartsWith("#") And s.EndsWith("#") Then
                    If s.ToUpper = "#LAN#" Then
                        arrlRTN.Add(obj.Lan)
                    ElseIf s.ToUpper = "#USERNAME#" Then
                        arrlRTN.Add(obj.UserName)
                    End If
                Else
                    arrlRTN.Add(s)
                End If
            Next
        End If
        Return arrlRTN
    End Function

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        para_Factory_ID.Text = String.Empty
    End Sub

    Private Function GetParameterInQuery(ByVal ct As Control)
        If TypeOf ct Is DateTimeOffsetEdit Then
            Return "'" + CType(ct, DateTimeOffsetEdit).EditValue.ToString("yyyy-MM-dd HH:mm:ss") + "'"
        ElseIf TypeOf ct Is DateEdit Then
            Return "'" + CType(CType(ct, DateEdit).EditValue, Date).ToString("yyyy-MM-dd") + "'"
        ElseIf TypeOf ct Is LookUpEdit Then
            Return "N'" + CType(ct, LookUpEdit).EditValue + "'"
        ElseIf TypeOf ct Is System.Windows.Forms.CheckBox Then
            If CType(ct, System.Windows.Forms.CheckBox).Checked = True Then
                Return "1"
            Else
                Return "0"
            End If
        ElseIf TypeOf ct Is System.Windows.Forms.RadioButton Then
            If CType(ct, System.Windows.Forms.RadioButton).Checked = True Then
                Return "1"
            Else
                Return "0"
            End If
        ElseIf TypeOf ct Is WindowsControlLibrary.Month Or TypeOf ct Is WindowsControlLibrary.Year Then
            Return ct.Text
        ElseIf ct.Name.ToUpper = "PARA_DANHSACHKEY" Then
            Return "'" + ct.Text + "'"
        ElseIf ct.Name.ToUpper = "PARA_LEAVETYPE" Then
            Dim lt As String
            For numberRow As Integer = 0 To GridView2.SelectedRowsCount - 1
                lt += GridView2.GetDataRow(GridView2.GetSelectedRows(numberRow)).Item("code").ToString() + ","
            Next
            If lt <> String.Empty Then
                lt = "'" + lt.Remove(lt.Length - 1, 1) + "'"
            Else
                lt = "null"
            End If
            Return lt
        Else
            Return "N'" + ct.Text.Trim + "'"
        End If
    End Function
    Private Function GetValueOfParameter(ByVal ct As Control)
        If TypeOf ct Is DateTimeOffsetEdit Then
            Return CType(ct, DateTimeOffsetEdit).EditValue
        ElseIf TypeOf ct Is LookUpEdit Then
            Return CType(ct, LookUpEdit).EditValue
        ElseIf TypeOf ct Is System.Windows.Forms.CheckBox Then
            If CType(ct, System.Windows.Forms.CheckBox).Checked = True Then
                Return "1"
            Else
                Return "0"
            End If
        ElseIf TypeOf ct Is System.Windows.Forms.RadioButton Then
            If CType(ct, System.Windows.Forms.RadioButton).Checked = True Then
                Return "1"
            Else
                Return "0"
            End If
        ElseIf TypeOf ct Is WindowsControlLibrary.Month Or TypeOf ct Is WindowsControlLibrary.Year Then
            Return ct.Text
        ElseIf ct.Name.ToUpper = "PARA_DANHSACHKEY" Then
            Return ct.Text
        ElseIf ct.Name.ToUpper = "PARA_LEAVETYPE" Then
            Dim lt As String
            For numberRow As Integer = 0 To GridView2.SelectedRowsCount - 1
                lt += GridView2.GetDataRow(GridView2.GetSelectedRows(numberRow)).Item("code").ToString() + ","
            Next
            If lt <> String.Empty Then
                lt = "'" + lt.Remove(lt.Length - 1, 1) + "'"
            Else
                lt = "null"
            End If
            Return lt
        Else
            Return ct.Text.Trim
        End If
    End Function
End Class
