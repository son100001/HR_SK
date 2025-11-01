Imports WindowsControlLibrary
 
Imports System.IO
Imports OfficeOpenXml
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmContractList
    Inherits HRFORM
    Private tabOldSalary, tabNewSalary, tabSalaryComponentCategory, tabLoaiHD As DataTable
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents CL_ExpiredDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CL_StartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CL_RegisterDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Type As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbContractAnneID As Label
    Friend WithEvents ContractAnnexID As RichTextBox
    Friend WithEvents InsertSource As TextBox
    Friend WithEvents lblInsertSource As Label
    Friend WithEvents CL_FatherID As TextBox
    Friend WithEvents lblCL_FatherID As Label
    Friend WithEvents lblGhiChu As Label
    Friend WithEvents CL_Remark As RichTextBox
    Friend WithEvents lblstatus As Label
    Friend WithEvents status As CheckBox
    Friend WithEvents lblCL_ExpiredDate As Label
    Friend WithEvents lblCL_StartDate As Label
    Friend WithEvents lblType As Label
    Friend WithEvents lblCL_RegisterDate As Label
    Friend WithEvents Contract_ID As TextBox
    Friend WithEvents lblContract_ID As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Dim intThoiGianHopDong As Integer = 1
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
    Friend WithEvents mi_HuyLocToanBo As System.Windows.Forms.MenuItem
    Friend WithEvents mi_LocHopDongMoiNhat As System.Windows.Forms.MenuItem
    Friend WithEvents mi_Loc As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnXoa As System.Windows.Forms.MenuItem
    Friend WithEvents mnIn As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnitXemHD As System.Windows.Forms.MenuItem
    Friend WithEvents mi_XemToanBoHopDong As System.Windows.Forms.MenuItem
    Friend WithEvents mi_HuyLoc As System.Windows.Forms.MenuItem


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.mi_HuyLocToanBo = New System.Windows.Forms.MenuItem()
        Me.mi_LocHopDongMoiNhat = New System.Windows.Forms.MenuItem()
        Me.mi_Loc = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnXoa = New System.Windows.Forms.MenuItem()
        Me.mnIn = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnitXemHD = New System.Windows.Forms.MenuItem()
        Me.mi_XemToanBoHopDong = New System.Windows.Forms.MenuItem()
        Me.mi_HuyLoc = New System.Windows.Forms.MenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.CL_ExpiredDate = New DevExpress.XtraEditors.DateEdit()
        Me.CL_StartDate = New DevExpress.XtraEditors.DateEdit()
        Me.CL_RegisterDate = New DevExpress.XtraEditors.DateEdit()
        Me.Type = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbContractAnneID = New System.Windows.Forms.Label()
        Me.ContractAnnexID = New System.Windows.Forms.RichTextBox()
        Me.InsertSource = New System.Windows.Forms.TextBox()
        Me.lblInsertSource = New System.Windows.Forms.Label()
        Me.CL_FatherID = New System.Windows.Forms.TextBox()
        Me.lblCL_FatherID = New System.Windows.Forms.Label()
        Me.lblGhiChu = New System.Windows.Forms.Label()
        Me.CL_Remark = New System.Windows.Forms.RichTextBox()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.status = New System.Windows.Forms.CheckBox()
        Me.lblCL_ExpiredDate = New System.Windows.Forms.Label()
        Me.lblCL_StartDate = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblCL_RegisterDate = New System.Windows.Forms.Label()
        Me.Contract_ID = New System.Windows.Forms.TextBox()
        Me.lblContract_ID = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.CL_ExpiredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CL_ExpiredDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CL_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CL_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CL_RegisterDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CL_RegisterDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 411)
        Me.PanelButton.Size = New System.Drawing.Size(1369, 55)
        '
        'mi_HuyLocToanBo
        '
        Me.mi_HuyLocToanBo.Index = -1
        Me.mi_HuyLocToanBo.Text = "Hủy lọc toàn bộ"
        '
        'mi_LocHopDongMoiNhat
        '
        Me.mi_LocHopDongMoiNhat.Index = -1
        Me.mi_LocHopDongMoiNhat.Text = "Lọc hợp đồng mới nhất"
        '
        'mi_Loc
        '
        Me.mi_Loc.Index = -1
        Me.mi_Loc.Text = "Lọc"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = -1
        Me.MenuItem1.Text = "-"
        '
        'mnXoa
        '
        Me.mnXoa.Enabled = False
        Me.mnXoa.Index = -1
        Me.mnXoa.Text = "&Xóa (X)"
        '
        'mnIn
        '
        Me.mnIn.Index = -1
        Me.mnIn.Text = "View trên Form"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = -1
        Me.MenuItem2.Text = "-"
        '
        'mnitXemHD
        '
        Me.mnitXemHD.Index = -1
        Me.mnitXemHD.Text = "Xuất file Word"
        '
        'mi_XemToanBoHopDong
        '
        Me.mi_XemToanBoHopDong.Index = -1
        Me.mi_XemToanBoHopDong.Text = "Xem Toàn bộ hợp đồng"
        '
        'mi_HuyLoc
        '
        Me.mi_HuyLoc.Index = -1
        Me.mi_HuyLoc.Text = "Hủy lọc"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(1369, 411)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1367, 386)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 157)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1362, 227)
        Me.GridControl1.TabIndex = 1324
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1367, 153)
        Me.TableLayoutPanel2.TabIndex = 1323
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(316, 145)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(7, 68)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1227
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(7, 42)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1225
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(10, 15)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(99, 23)
        Me.lblEmployee_ID.TabIndex = 1226
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.CL_ExpiredDate)
        Me.pnDuLieuNhap.Controls.Add(Me.CL_StartDate)
        Me.pnDuLieuNhap.Controls.Add(Me.CL_RegisterDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Type)
        Me.pnDuLieuNhap.Controls.Add(Me.lbContractAnneID)
        Me.pnDuLieuNhap.Controls.Add(Me.ContractAnnexID)
        Me.pnDuLieuNhap.Controls.Add(Me.InsertSource)
        Me.pnDuLieuNhap.Controls.Add(Me.lblInsertSource)
        Me.pnDuLieuNhap.Controls.Add(Me.CL_FatherID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCL_FatherID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGhiChu)
        Me.pnDuLieuNhap.Controls.Add(Me.CL_Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblstatus)
        Me.pnDuLieuNhap.Controls.Add(Me.status)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCL_ExpiredDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCL_StartDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblType)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCL_RegisterDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Contract_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblContract_ID)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(327, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(861, 145)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'CL_ExpiredDate
        '
        Me.CL_ExpiredDate.EditValue = Nothing
        Me.CL_ExpiredDate.Location = New System.Drawing.Point(455, 37)
        Me.CL_ExpiredDate.Name = "CL_ExpiredDate"
        Me.CL_ExpiredDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CL_ExpiredDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CL_ExpiredDate.Properties.DisplayFormat.FormatString = ""
        Me.CL_ExpiredDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CL_ExpiredDate.Properties.EditFormat.FormatString = ""
        Me.CL_ExpiredDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CL_ExpiredDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.CL_ExpiredDate.Properties.MaskSettings.Set("mask", "d")
        Me.CL_ExpiredDate.Properties.UseMaskAsDisplayFormat = True
        Me.CL_ExpiredDate.Size = New System.Drawing.Size(121, 20)
        Me.CL_ExpiredDate.TabIndex = 1291
        '
        'CL_StartDate
        '
        Me.CL_StartDate.EditValue = Nothing
        Me.CL_StartDate.Location = New System.Drawing.Point(455, 12)
        Me.CL_StartDate.Name = "CL_StartDate"
        Me.CL_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CL_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CL_StartDate.Properties.DisplayFormat.FormatString = ""
        Me.CL_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CL_StartDate.Properties.EditFormat.FormatString = ""
        Me.CL_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CL_StartDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.CL_StartDate.Properties.MaskSettings.Set("mask", "d")
        Me.CL_StartDate.Properties.UseMaskAsDisplayFormat = True
        Me.CL_StartDate.Size = New System.Drawing.Size(121, 20)
        Me.CL_StartDate.TabIndex = 1290
        '
        'CL_RegisterDate
        '
        Me.CL_RegisterDate.EditValue = Nothing
        Me.CL_RegisterDate.Location = New System.Drawing.Point(130, 58)
        Me.CL_RegisterDate.Name = "CL_RegisterDate"
        Me.CL_RegisterDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CL_RegisterDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CL_RegisterDate.Properties.DisplayFormat.FormatString = ""
        Me.CL_RegisterDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CL_RegisterDate.Properties.EditFormat.FormatString = ""
        Me.CL_RegisterDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CL_RegisterDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.CL_RegisterDate.Properties.MaskSettings.Set("mask", "d")
        Me.CL_RegisterDate.Properties.UseMaskAsDisplayFormat = True
        Me.CL_RegisterDate.Size = New System.Drawing.Size(121, 20)
        Me.CL_RegisterDate.TabIndex = 1289
        '
        'Type
        '
        Me.Type.Location = New System.Drawing.Point(130, 34)
        Me.Type.Name = "Type"
        Me.Type.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Type.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Type.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Type.Size = New System.Drawing.Size(142, 20)
        Me.Type.TabIndex = 1288
        '
        'lbContractAnneID
        '
        Me.lbContractAnneID.Location = New System.Drawing.Point(590, 108)
        Me.lbContractAnneID.Name = "lbContractAnneID"
        Me.lbContractAnneID.Size = New System.Drawing.Size(100, 26)
        Me.lbContractAnneID.TabIndex = 328
        Me.lbContractAnneID.Text = "Số Phụ lục hợp đồng"
        Me.lbContractAnneID.Visible = False
        '
        'ContractAnnexID
        '
        Me.ContractAnnexID.Location = New System.Drawing.Point(710, 108)
        Me.ContractAnnexID.Name = "ContractAnnexID"
        Me.ContractAnnexID.Size = New System.Drawing.Size(120, 26)
        Me.ContractAnnexID.TabIndex = 327
        Me.ContractAnnexID.Text = ""
        Me.ContractAnnexID.Visible = False
        '
        'InsertSource
        '
        Me.InsertSource.Location = New System.Drawing.Point(710, 32)
        Me.InsertSource.Name = "InsertSource"
        Me.InsertSource.ReadOnly = True
        Me.InsertSource.Size = New System.Drawing.Size(120, 21)
        Me.InsertSource.TabIndex = 326
        '
        'lblInsertSource
        '
        Me.lblInsertSource.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsertSource.Location = New System.Drawing.Point(590, 31)
        Me.lblInsertSource.Name = "lblInsertSource"
        Me.lblInsertSource.Size = New System.Drawing.Size(104, 20)
        Me.lblInsertSource.TabIndex = 325
        Me.lblInsertSource.Text = "Nguồn nhập"
        Me.lblInsertSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CL_FatherID
        '
        Me.CL_FatherID.Location = New System.Drawing.Point(710, 6)
        Me.CL_FatherID.Name = "CL_FatherID"
        Me.CL_FatherID.ReadOnly = True
        Me.CL_FatherID.Size = New System.Drawing.Size(120, 21)
        Me.CL_FatherID.TabIndex = 324
        '
        'lblCL_FatherID
        '
        Me.lblCL_FatherID.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCL_FatherID.Location = New System.Drawing.Point(590, 5)
        Me.lblCL_FatherID.Name = "lblCL_FatherID"
        Me.lblCL_FatherID.Size = New System.Drawing.Size(114, 20)
        Me.lblCL_FatherID.TabIndex = 323
        Me.lblCL_FatherID.Text = "Hợp đồng chính"
        Me.lblCL_FatherID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGhiChu
        '
        Me.lblGhiChu.Location = New System.Drawing.Point(594, 59)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(100, 16)
        Me.lblGhiChu.TabIndex = 322
        Me.lblGhiChu.Text = "Ghi chú"
        '
        'CL_Remark
        '
        Me.CL_Remark.Location = New System.Drawing.Point(710, 59)
        Me.CL_Remark.Name = "CL_Remark"
        Me.CL_Remark.Size = New System.Drawing.Size(120, 43)
        Me.CL_Remark.TabIndex = 321
        Me.CL_Remark.Text = ""
        '
        'lblstatus
        '
        Me.lblstatus.Location = New System.Drawing.Point(299, 64)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(129, 16)
        Me.lblstatus.TabIndex = 320
        Me.lblstatus.Text = "status"
        '
        'status
        '
        Me.status.Location = New System.Drawing.Point(455, 61)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(16, 24)
        Me.status.TabIndex = 316
        '
        'lblCL_ExpiredDate
        '
        Me.lblCL_ExpiredDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCL_ExpiredDate.Location = New System.Drawing.Point(295, 35)
        Me.lblCL_ExpiredDate.Name = "lblCL_ExpiredDate"
        Me.lblCL_ExpiredDate.Size = New System.Drawing.Size(154, 20)
        Me.lblCL_ExpiredDate.TabIndex = 318
        Me.lblCL_ExpiredDate.Text = "Ngày hết hạn HĐ"
        Me.lblCL_ExpiredDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCL_StartDate
        '
        Me.lblCL_StartDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCL_StartDate.Location = New System.Drawing.Point(295, 11)
        Me.lblCL_StartDate.Name = "lblCL_StartDate"
        Me.lblCL_StartDate.Size = New System.Drawing.Size(154, 20)
        Me.lblCL_StartDate.TabIndex = 317
        Me.lblCL_StartDate.Text = "Ngày hiệu lực HĐ"
        Me.lblCL_StartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblType
        '
        Me.lblType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(7, 33)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(117, 20)
        Me.lblType.TabIndex = 303
        Me.lblType.Text = "Loại HĐ"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCL_RegisterDate
        '
        Me.lblCL_RegisterDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCL_RegisterDate.Location = New System.Drawing.Point(7, 57)
        Me.lblCL_RegisterDate.Name = "lblCL_RegisterDate"
        Me.lblCL_RegisterDate.Size = New System.Drawing.Size(117, 20)
        Me.lblCL_RegisterDate.TabIndex = 302
        Me.lblCL_RegisterDate.Text = "Ngày ký"
        Me.lblCL_RegisterDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Contract_ID
        '
        Me.Contract_ID.Location = New System.Drawing.Point(130, 8)
        Me.Contract_ID.Name = "Contract_ID"
        Me.Contract_ID.Size = New System.Drawing.Size(104, 21)
        Me.Contract_ID.TabIndex = 298
        '
        'lblContract_ID
        '
        Me.lblContract_ID.Location = New System.Drawing.Point(3, 8)
        Me.lblContract_ID.Name = "lblContract_ID"
        Me.lblContract_ID.Size = New System.Drawing.Size(121, 23)
        Me.lblContract_ID.TabIndex = 299
        Me.lblContract_ID.Text = "Mã hợp đồng"
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1195, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 145)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Lưu"
        '
        'frmContractList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1369, 466)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_DeleteStore = "usp_DeleteSmartBooks_ContractList"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmContractList_Nhap"
        Me.HRFORM_SaveStore = "usp_InsertUpdateSmartBooks_ContractList"
        Me.HRFORM_TableName = "SmartBooks_ContractList"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmContractList"
        Me.Text = "Create/Edit  Contract List"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.CL_ExpiredDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CL_ExpiredDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CL_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CL_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CL_RegisterDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CL_RegisterDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overrides Sub AfterViewForm()
        If Not IsNothing(HRFORM_Gridview.Columns("Type")) Then
            Dim tab As DataTable = kn.ReadData("select Contract_ID as Code, ConTract_Name" + obj.Lan + " as Name from SmartBooks_Contract", "table")
            tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "Type", tab)
        End If
    End Sub

    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportCode = "ContractListGetInputTemplate" Then
            Dim frm As New frmparaSalaryComponent
            frm.bMonthlyChanging = False
            frm.ShowDialog()
            'If frm.bluu = False Then
            '    Exit Sub
            'End If
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.DefaultExt = "xlsx"
            fileChooser.FileName = "NhapHopDong.xlsx"
            Dim result As DialogResult = fileChooser.ShowDialog()
            fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                LayTemplateHD(Application.StartupPath() + "\Teamleate\NhapHopDong.xlsx", fileChooser.FileName, frm.GetSalaryComponentCode, frm.GetSalaryComponentNamveVn)
            End If
        ElseIf ReportCode = "ContractListInputTemplate" Then
            NhapHD()
        End If
    End Sub

    Private Sub NhapHD()
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim excel As New FileInfo(ofd.FileName)
            Dim strError As String = ""
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = 8
                Dim ColConfig As Integer = 6
                Dim intColStart As Integer = 9
                Dim objFD, objTD As Object
                Dim Employee_ID, SalaryComponent, Amount, fromdate, todate, Remark, InsertDate, UserName As String
                Dim Type, CL_FatherID, Contract_ID, status, CL_Remark As String
                Dim ContractAnnexID As String
                InsertDate = "'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                UserName = "N'" + obj.UserName + "'"
                While worksheet.Cells("B" + index.ToString).Text.Trim <> String.Empty And worksheet.Cells("D" + index.ToString).Text.Trim <> String.Empty
                    Contract_ID = worksheet.Cells("A" + index.ToString).Text.Trim
                    If Contract_ID = String.Empty Then
                        Contract_ID = "null"
                    Else
                        Contract_ID = "N'" + Contract_ID + "'"
                    End If
                    Employee_ID = "N'" + worksheet.Cells("B" + index.ToString).Text.Trim + "'"
                    objFD = worksheet.Cells("D" + index.ToString()).Value
                    If Not IsNothing(objFD) Then
                        fromdate = "'" + CDate(objFD).ToString("yyyy-MM-dd") + "'"
                    Else
                        fromdate = "null"
                        objFD = New DateTime(1900, 1, 1)
                    End If
                    objTD = worksheet.Cells("E" + index.ToString()).Value
                    If Not IsNothing(objTD) Then
                        todate = "'" + CDate(objTD).ToString("yyyy-MM-dd") + "'"
                    Else
                        todate = "null"
                        objTD = New DateTime(1900, 1, 1)
                    End If
                    Type = worksheet.Cells("F" + index.ToString).Text.Trim
                    If Type = String.Empty Then
                        Type = "null"
                    Else
                        Type = "N'" + Type + "'"
                    End If
                    CL_FatherID = worksheet.Cells("G" + index.ToString).Text.Trim
                    If CL_FatherID = String.Empty Then
                        CL_FatherID = "null"
                    Else
                        CL_FatherID = "N'" + CL_FatherID + "'"
                    End If
                    status = worksheet.Cells("H" + index.ToString).Text.Trim
                    If status = String.Empty Then
                        status = "null"
                    End If
                    Remark = worksheet.Cells("I" + index.ToString).Text.Trim
                    CL_Remark = Remark
                    If Remark = String.Empty Then
                        Remark = "null"
                    Else
                        Remark = "N'" + Remark + "'"
                    End If
                    If ContractAnnexID = String.Empty Then
                        ContractAnnexID = "null"
                    Else
                        ContractAnnexID = "N'" + ContractAnnexID + "'"
                    End If

                    Dim tabCheck As DataTable
                    tabCheck = kn.ReadData("exec [dbo].[usp_InsertUpdateSmartBooks_ContractList] null," + Contract_ID + "," + Employee_ID + "," + fromdate + "," + todate + "," + fromdate + "," + status + "," + Type + "," + CL_FatherID + "," + Remark + ",'NhapExcel'," + InsertDate + "," + UserName + "," + ContractAnnexID, "table")
                    If Not IsNothing(tabCheck) Then
                        If tabCheck.Rows(0)("ThongBao") <> "" Then
                            'MessageBox.Show("Lỗi " + tabCheck.Rows(0)("ThongBao") + ", ở dòng thứ: " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            strError += tvcn.GetLanguagesTranslated("Popup.Error") + ": " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")) + ", " + tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + " ; "
                            'Exit Sub
                        End If
                    Else
                        'MessageBox.Show("Có lỗi ở dòng: " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        strError += tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + " ; "
                        Exit Sub
                    End If
                    For intcol As Integer = intColStart To ColExel.Length - 1
                        If worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim <> String.Empty Then
                            SalaryComponent = "N'" + worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim + "'"
                            If Not IsNothing(worksheet.Cells(ColExel(intcol) + index.ToString).Value) Then
                                Amount = worksheet.Cells(ColExel(intcol) + index.ToString).Value.ToString
                            Else
                                Amount = String.Empty
                            End If
                            If Amount <> String.Empty Then
                                tabCheck = kn.ReadData("exec usp_InsertUpdateHR_SalaryComponent null," + Employee_ID + "," + SalaryComponent + "," + Amount + "," + fromdate + "," + todate + ",'contract'," + Remark + "," + InsertDate + "," + UserName, "table")
                                If Not IsNothing(tabCheck) Then
                                    If tabCheck.Rows(0)("ThongBao") <> "" Then
                                        'MessageBox.Show("Lỗi " + tabCheck.Rows(0)("ThongBao") + ", ở dòng thứ: " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        strError += tvcn.GetLanguagesTranslated("Popup.Error") + ": " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")) + ", " + tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + " ; "
                                        'Exit Sub
                                    End If
                                Else
                                    'MessageBox.Show("Có lỗi ở dòng: " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    strError += tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + " ; "
                                    'Exit Sub
                                End If
                            End If
                        Else
                            Exit For
                        End If
                    Next
                    index += 1
                End While
                If strError <> String.Empty Then
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuketthucnhungcomotsobanghibiloibanvuilongkiemtralai") + ": " + strError)
                Else
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        End If
    End Sub

    Private Sub LayTemplateHD(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal ListOfSalaryComponentCode As String(), ByVal ListOfSalaryComponentName As String())
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"}
        Dim urlTemplate As String = LinkFileTemplate
        Dim urlOut As String = LinkFileXuat
        Dim excel As New FileInfo(LinkFileTemplate)
        Using package As New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim intColStart As Integer = 9
            Dim index As Integer = 7
            If Not IsNothing(ListOfSalaryComponentCode) Then
                For i As Integer = 0 To ListOfSalaryComponentCode.Length - 1
                    ws.Cells(ColExel(intColStart) + (index - 1).ToString).Value = ListOfSalaryComponentCode(i)
                    ws.Cells(ColExel(intColStart) + index.ToString).Value = ListOfSalaryComponentName(i)
                    intColStart += 1
                Next
            End If
            Dim fi As New FileInfo(LinkFileXuat)
            package.SaveAs(fi)
            System.Diagnostics.Process.Start(LinkFileXuat)
        End Using
    End Sub

    Private Sub frmContractList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        tabLoaiHD = kn.ReadData("select * from SmartBooks_Contract", "table")
        CL_StartDate.DateTime = Today
        CL_RegisterDate.DateTime = Today

        Type.Properties.DataSource = tabLoaiHD
        Type.Properties.DisplayMember = "ConTract_Name" + obj.Lan
        Type.Properties.ValueMember = "Contract_ID"
        Type.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        Type.Properties.NullText = ""
        tvcn.SearchEmployee(Employee_ID)
        Contract_ID.Select()
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateSmartBooks_ContractList]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub
    Private Sub CL_StartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CL_StartDate.EditValueChanged
        CL_ExpiredDate.DateTime = GetNgayHetHanHD()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub CL_RegisterDate_ValueChanged(sender As Object, e As EventArgs) Handles CL_RegisterDate.EditValueChanged
        CL_StartDate.DateTime = CL_RegisterDate.DateTime
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Function GetNgayHetHanHD() As DateTime
        Dim dtNgayHetHanHD As DateTime = CL_StartDate.DateTime
        If Not IsNothing(tabLoaiHD) Then
            Dim drContractType As DataRow() = tabLoaiHD.Select("Contract_ID='" + Type.Text.Trim + "'")
            intThoiGianHopDong = 1
            If drContractType.Length > 0 Then
                If Not IsDBNull(drContractType(0)("NumberOfMonth")) Then
                    dtNgayHetHanHD = dtNgayHetHanHD.AddMonths(drContractType(0)("NumberOfMonth"))
                End If
                If Not IsDBNull(drContractType(0)("NumberOfYear")) Then
                    dtNgayHetHanHD = dtNgayHetHanHD.AddYears(drContractType(0)("NumberOfYear"))
                End If
                If Not IsDBNull(drContractType(0)("NumberOfDay")) Then
                    dtNgayHetHanHD = dtNgayHetHanHD.AddDays(drContractType(0)("NumberOfDay"))
                End If
            End If
        End If
        If dtNgayHetHanHD <> CL_StartDate.DateTime Then
            dtNgayHetHanHD = dtNgayHetHanHD.AddDays(-1)
        End If
        Return dtNgayHetHanHD
    End Function

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangHopDong] '1990-1-1','" + Today.AddMonths(1).AddDays(-Today.Day).ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',null,N'" + EmID + "'" + ContractAnnexID.Text.Trim
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

End Class
