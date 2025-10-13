Imports WindowsControlLibrary
 
Public Class frmSection
    Inherits HRFORM

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
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuChart As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheck As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblGroup_ As Label
    Friend WithEvents Group_ As TextBox
    Friend WithEvents cbbdepartmentcode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents JobCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ContractFlow As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents CaMacDinh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblJobCode As Label
    Friend WithEvents lblOrderBy As Label
    Friend WithEvents OrderBy As NumericUpDown
    Friend WithEvents lblDirect As Label
    Friend WithEvents Direct As CheckBox
    Friend WithEvents AnnualLeaveDays As TextBox
    Friend WithEvents GioiHanTangCaMacDinh As TextBox
    Friend WithEvents lblContractFlow As Label
    Friend WithEvents lblAnnualLeaveDays As Label
    Friend WithEvents lblGioiHanTangCaMacDinh As Label
    Friend WithEvents lblCaMacDinh As Label
    Friend WithEvents SectionName_KR As TextBox
    Friend WithEvents SectionName_EN As TextBox
    Friend WithEvents SectionName_VN As TextBox
    Friend WithEvents lblSectionName_KR As Label
    Friend WithEvents lblSectionName_EN As Label
    Friend WithEvents lblSectionName_VN As Label
    Friend WithEvents departmentcode As TextBox
    Friend WithEvents Factory_ID As TextBox
    Friend WithEvents lbldepartmentcode As Label
    Friend WithEvents SectionCode As TextBox
    Friend WithEvents lblSectionCode As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSection))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.mnuChart = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuCheck = New System.Windows.Forms.MenuItem()
        Me.mnuClear = New System.Windows.Forms.MenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.lblGroup_ = New System.Windows.Forms.Label()
        Me.Group_ = New System.Windows.Forms.TextBox()
        Me.cbbdepartmentcode = New DevExpress.XtraEditors.LookUpEdit()
        Me.JobCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.ContractFlow = New DevExpress.XtraEditors.LookUpEdit()
        Me.CaMacDinh = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblJobCode = New System.Windows.Forms.Label()
        Me.lblOrderBy = New System.Windows.Forms.Label()
        Me.OrderBy = New System.Windows.Forms.NumericUpDown()
        Me.lblDirect = New System.Windows.Forms.Label()
        Me.Direct = New System.Windows.Forms.CheckBox()
        Me.AnnualLeaveDays = New System.Windows.Forms.TextBox()
        Me.GioiHanTangCaMacDinh = New System.Windows.Forms.TextBox()
        Me.lblContractFlow = New System.Windows.Forms.Label()
        Me.lblAnnualLeaveDays = New System.Windows.Forms.Label()
        Me.lblGioiHanTangCaMacDinh = New System.Windows.Forms.Label()
        Me.lblCaMacDinh = New System.Windows.Forms.Label()
        Me.SectionName_KR = New System.Windows.Forms.TextBox()
        Me.SectionName_EN = New System.Windows.Forms.TextBox()
        Me.SectionName_VN = New System.Windows.Forms.TextBox()
        Me.lblSectionName_KR = New System.Windows.Forms.Label()
        Me.lblSectionName_EN = New System.Windows.Forms.Label()
        Me.lblSectionName_VN = New System.Windows.Forms.Label()
        Me.departmentcode = New System.Windows.Forms.TextBox()
        Me.Factory_ID = New System.Windows.Forms.TextBox()
        Me.lbldepartmentcode = New System.Windows.Forms.Label()
        Me.SectionCode = New System.Windows.Forms.TextBox()
        Me.lblSectionCode = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.cbbdepartmentcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 421)
        Me.PanelButton.Size = New System.Drawing.Size(1336, 49)
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuChart, Me.MenuItem2, Me.mnuCheck, Me.mnuClear})
        '
        'mnuChart
        '
        Me.mnuChart.Index = 0
        Me.mnuChart.Text = "Chart of Accounts"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mnuCheck
        '
        Me.mnuCheck.Index = 2
        Me.mnuCheck.Text = "Check sub-account"
        '
        'mnuClear
        '
        Me.mnuClear.Index = 3
        Me.mnuClear.Text = "Clear Content"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Empty
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        Me.ImageList2.Images.SetKeyName(7, "")
        Me.ImageList2.Images.SetKeyName(8, "")
        Me.ImageList2.Images.SetKeyName(9, "")
        Me.ImageList2.Images.SetKeyName(10, "")
        Me.ImageList2.Images.SetKeyName(11, "")
        Me.ImageList2.Images.SetKeyName(12, "")
        Me.ImageList2.Images.SetKeyName(13, "")
        Me.ImageList2.Images.SetKeyName(14, "")
        Me.ImageList2.Images.SetKeyName(15, "")
        '
        'flag
        '
        Me.flag.ImageStream = CType(resources.GetObject("flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.flag.TransparentColor = System.Drawing.Color.Transparent
        Me.flag.Images.SetKeyName(0, "")
        Me.flag.Images.SetKeyName(1, "")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        Me.ImageList1.Images.SetKeyName(18, "")
        Me.ImageList1.Images.SetKeyName(19, "")
        Me.ImageList1.Images.SetKeyName(20, "")
        Me.ImageList1.Images.SetKeyName(21, "")
        Me.ImageList1.Images.SetKeyName(22, "")
        Me.ImageList1.Images.SetKeyName(23, "")
        Me.ImageList1.Images.SetKeyName(24, "")
        Me.ImageList1.Images.SetKeyName(25, "")
        Me.ImageList1.Images.SetKeyName(26, "")
        Me.ImageList1.Images.SetKeyName(27, "")
        Me.ImageList1.Images.SetKeyName(28, "")
        Me.ImageList1.Images.SetKeyName(29, "")
        Me.ImageList1.Images.SetKeyName(30, "")
        Me.ImageList1.Images.SetKeyName(31, "")
        Me.ImageList1.Images.SetKeyName(32, "")
        Me.ImageList1.Images.SetKeyName(33, "")
        Me.ImageList1.Images.SetKeyName(34, "")
        Me.ImageList1.Images.SetKeyName(35, "")
        Me.ImageList1.Images.SetKeyName(36, "")
        Me.ImageList1.Images.SetKeyName(37, "")
        Me.ImageList1.Images.SetKeyName(38, "")
        Me.ImageList1.Images.SetKeyName(39, "")
        Me.ImageList1.Images.SetKeyName(40, "")
        Me.ImageList1.Images.SetKeyName(41, "")
        Me.ImageList1.Images.SetKeyName(42, "")
        Me.ImageList1.Images.SetKeyName(43, "")
        Me.ImageList1.Images.SetKeyName(44, "")
        Me.ImageList1.Images.SetKeyName(45, "")
        Me.ImageList1.Images.SetKeyName(46, "")
        Me.ImageList1.Images.SetKeyName(47, "")
        Me.ImageList1.Images.SetKeyName(48, "")
        Me.ImageList1.Images.SetKeyName(49, "")
        Me.ImageList1.Images.SetKeyName(50, "")
        Me.ImageList1.Images.SetKeyName(51, "")
        Me.ImageList1.Images.SetKeyName(52, "")
        Me.ImageList1.Images.SetKeyName(53, "")
        Me.ImageList1.Images.SetKeyName(54, "")
        Me.ImageList1.Images.SetKeyName(55, "")
        Me.ImageList1.Images.SetKeyName(56, "")
        Me.ImageList1.Images.SetKeyName(57, "")
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1336, 421)
        Me.XtraTabControl1.TabIndex = 1319
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1334, 396)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(3, 92)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1329, 302)
        Me.GridControl1.TabIndex = 1320
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1334, 90)
        Me.TableLayoutPanel3.TabIndex = 1319
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblGroup_)
        Me.pnDuLieuNhap.Controls.Add(Me.Group_)
        Me.pnDuLieuNhap.Controls.Add(Me.cbbdepartmentcode)
        Me.pnDuLieuNhap.Controls.Add(Me.JobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.ContractFlow)
        Me.pnDuLieuNhap.Controls.Add(Me.CaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblJobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblOrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.OrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDirect)
        Me.pnDuLieuNhap.Controls.Add(Me.Direct)
        Me.pnDuLieuNhap.Controls.Add(Me.AnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.GioiHanTangCaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblContractFlow)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGioiHanTangCaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.SectionName_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.SectionName_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.SectionName_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSectionName_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSectionName_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSectionName_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.departmentcode)
        Me.pnDuLieuNhap.Controls.Add(Me.Factory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lbldepartmentcode)
        Me.pnDuLieuNhap.Controls.Add(Me.SectionCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSectionCode)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1243, 82)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblGroup_
        '
        Me.lblGroup_.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup_.Location = New System.Drawing.Point(1106, 57)
        Me.lblGroup_.Name = "lblGroup_"
        Me.lblGroup_.Size = New System.Drawing.Size(64, 19)
        Me.lblGroup_.TabIndex = 1281
        Me.lblGroup_.Text = "Nhóm"
        Me.lblGroup_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Group_
        '
        Me.Group_.Location = New System.Drawing.Point(1176, 55)
        Me.Group_.Name = "Group_"
        Me.Group_.Size = New System.Drawing.Size(56, 21)
        Me.Group_.TabIndex = 25
        '
        'cbbdepartmentcode
        '
        Me.cbbdepartmentcode.Location = New System.Drawing.Point(108, 30)
        Me.cbbdepartmentcode.Name = "cbbdepartmentcode"
        Me.cbbdepartmentcode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cbbdepartmentcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbdepartmentcode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cbbdepartmentcode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cbbdepartmentcode.Size = New System.Drawing.Size(191, 20)
        Me.cbbdepartmentcode.TabIndex = 3
        '
        'JobCode
        '
        Me.JobCode.Location = New System.Drawing.Point(1109, 32)
        Me.JobCode.Name = "JobCode"
        Me.JobCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.JobCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.JobCode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.JobCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.JobCode.Size = New System.Drawing.Size(123, 20)
        Me.JobCode.TabIndex = 23
        '
        'ContractFlow
        '
        Me.ContractFlow.Location = New System.Drawing.Point(1020, 31)
        Me.ContractFlow.Name = "ContractFlow"
        Me.ContractFlow.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ContractFlow.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractFlow.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ContractFlow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ContractFlow.Size = New System.Drawing.Size(80, 20)
        Me.ContractFlow.TabIndex = 19
        '
        'CaMacDinh
        '
        Me.CaMacDinh.Location = New System.Drawing.Point(816, 32)
        Me.CaMacDinh.Name = "CaMacDinh"
        Me.CaMacDinh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.CaMacDinh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CaMacDinh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.CaMacDinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CaMacDinh.Size = New System.Drawing.Size(70, 20)
        Me.CaMacDinh.TabIndex = 13
        '
        'lblJobCode
        '
        Me.lblJobCode.BackColor = System.Drawing.Color.Transparent
        Me.lblJobCode.Location = New System.Drawing.Point(1106, 7)
        Me.lblJobCode.Name = "lblJobCode"
        Me.lblJobCode.Size = New System.Drawing.Size(96, 19)
        Me.lblJobCode.TabIndex = 1279
        Me.lblJobCode.Text = "Job code"
        Me.lblJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOrderBy
        '
        Me.lblOrderBy.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderBy.Location = New System.Drawing.Point(893, 54)
        Me.lblOrderBy.Name = "lblOrderBy"
        Me.lblOrderBy.Size = New System.Drawing.Size(74, 19)
        Me.lblOrderBy.TabIndex = 1277
        Me.lblOrderBy.Text = "Thứ tự"
        Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OrderBy
        '
        Me.OrderBy.Location = New System.Drawing.Point(1020, 55)
        Me.OrderBy.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.OrderBy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.OrderBy.Name = "OrderBy"
        Me.OrderBy.Size = New System.Drawing.Size(80, 21)
        Me.OrderBy.TabIndex = 21
        Me.OrderBy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblDirect
        '
        Me.lblDirect.BackColor = System.Drawing.Color.Transparent
        Me.lblDirect.Location = New System.Drawing.Point(665, 7)
        Me.lblDirect.Name = "lblDirect"
        Me.lblDirect.Size = New System.Drawing.Size(72, 19)
        Me.lblDirect.TabIndex = 1275
        Me.lblDirect.Text = "Trực tiếp"
        Me.lblDirect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Direct
        '
        Me.Direct.AutoSize = True
        Me.Direct.Location = New System.Drawing.Point(816, 7)
        Me.Direct.Name = "Direct"
        Me.Direct.Size = New System.Drawing.Size(15, 14)
        Me.Direct.TabIndex = 11
        Me.Direct.UseVisualStyleBackColor = True
        '
        'AnnualLeaveDays
        '
        Me.AnnualLeaveDays.Location = New System.Drawing.Point(1020, 4)
        Me.AnnualLeaveDays.Name = "AnnualLeaveDays"
        Me.AnnualLeaveDays.Size = New System.Drawing.Size(80, 21)
        Me.AnnualLeaveDays.TabIndex = 17
        '
        'GioiHanTangCaMacDinh
        '
        Me.GioiHanTangCaMacDinh.Location = New System.Drawing.Point(816, 55)
        Me.GioiHanTangCaMacDinh.Name = "GioiHanTangCaMacDinh"
        Me.GioiHanTangCaMacDinh.Size = New System.Drawing.Size(70, 21)
        Me.GioiHanTangCaMacDinh.TabIndex = 15
        '
        'lblContractFlow
        '
        Me.lblContractFlow.BackColor = System.Drawing.Color.Transparent
        Me.lblContractFlow.Location = New System.Drawing.Point(893, 31)
        Me.lblContractFlow.Name = "lblContractFlow"
        Me.lblContractFlow.Size = New System.Drawing.Size(103, 19)
        Me.lblContractFlow.TabIndex = 1273
        Me.lblContractFlow.Text = "Luồng hợp đồng"
        Me.lblContractFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAnnualLeaveDays
        '
        Me.lblAnnualLeaveDays.BackColor = System.Drawing.Color.Transparent
        Me.lblAnnualLeaveDays.Location = New System.Drawing.Point(893, 6)
        Me.lblAnnualLeaveDays.Name = "lblAnnualLeaveDays"
        Me.lblAnnualLeaveDays.Size = New System.Drawing.Size(113, 19)
        Me.lblAnnualLeaveDays.TabIndex = 1272
        Me.lblAnnualLeaveDays.Text = "Số ngày phép năm"
        Me.lblAnnualLeaveDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGioiHanTangCaMacDinh
        '
        Me.lblGioiHanTangCaMacDinh.BackColor = System.Drawing.Color.Transparent
        Me.lblGioiHanTangCaMacDinh.Location = New System.Drawing.Point(665, 55)
        Me.lblGioiHanTangCaMacDinh.Name = "lblGioiHanTangCaMacDinh"
        Me.lblGioiHanTangCaMacDinh.Size = New System.Drawing.Size(141, 19)
        Me.lblGioiHanTangCaMacDinh.TabIndex = 1271
        Me.lblGioiHanTangCaMacDinh.Text = "Giới hạn tăng ca mặc định"
        Me.lblGioiHanTangCaMacDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaMacDinh
        '
        Me.lblCaMacDinh.BackColor = System.Drawing.Color.Transparent
        Me.lblCaMacDinh.Location = New System.Drawing.Point(665, 33)
        Me.lblCaMacDinh.Name = "lblCaMacDinh"
        Me.lblCaMacDinh.Size = New System.Drawing.Size(72, 19)
        Me.lblCaMacDinh.TabIndex = 1267
        Me.lblCaMacDinh.Text = "Ca mặc định"
        Me.lblCaMacDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SectionName_KR
        '
        Me.SectionName_KR.Location = New System.Drawing.Point(463, 55)
        Me.SectionName_KR.Name = "SectionName_KR"
        Me.SectionName_KR.Size = New System.Drawing.Size(191, 21)
        Me.SectionName_KR.TabIndex = 9
        '
        'SectionName_EN
        '
        Me.SectionName_EN.Location = New System.Drawing.Point(463, 31)
        Me.SectionName_EN.Name = "SectionName_EN"
        Me.SectionName_EN.Size = New System.Drawing.Size(191, 21)
        Me.SectionName_EN.TabIndex = 7
        '
        'SectionName_VN
        '
        Me.SectionName_VN.Location = New System.Drawing.Point(463, 7)
        Me.SectionName_VN.Name = "SectionName_VN"
        Me.SectionName_VN.Size = New System.Drawing.Size(191, 21)
        Me.SectionName_VN.TabIndex = 5
        '
        'lblSectionName_KR
        '
        Me.lblSectionName_KR.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionName_KR.Location = New System.Drawing.Point(330, 54)
        Me.lblSectionName_KR.Name = "lblSectionName_KR"
        Me.lblSectionName_KR.Size = New System.Drawing.Size(127, 19)
        Me.lblSectionName_KR.TabIndex = 1265
        Me.lblSectionName_KR.Text = "Tên phòng ban (KR)"
        Me.lblSectionName_KR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSectionName_EN
        '
        Me.lblSectionName_EN.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionName_EN.Location = New System.Drawing.Point(330, 30)
        Me.lblSectionName_EN.Name = "lblSectionName_EN"
        Me.lblSectionName_EN.Size = New System.Drawing.Size(127, 19)
        Me.lblSectionName_EN.TabIndex = 1264
        Me.lblSectionName_EN.Text = "Tên phòng ban (EN)"
        Me.lblSectionName_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSectionName_VN
        '
        Me.lblSectionName_VN.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionName_VN.Location = New System.Drawing.Point(330, 6)
        Me.lblSectionName_VN.Name = "lblSectionName_VN"
        Me.lblSectionName_VN.Size = New System.Drawing.Size(127, 19)
        Me.lblSectionName_VN.TabIndex = 1263
        Me.lblSectionName_VN.Text = "Tên phòng ban (VN)"
        Me.lblSectionName_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'departmentcode
        '
        Me.departmentcode.Enabled = False
        Me.departmentcode.Location = New System.Drawing.Point(176, 58)
        Me.departmentcode.Name = "departmentcode"
        Me.departmentcode.ReadOnly = True
        Me.departmentcode.Size = New System.Drawing.Size(139, 21)
        Me.departmentcode.TabIndex = 1259
        '
        'Factory_ID
        '
        Me.Factory_ID.Enabled = False
        Me.Factory_ID.Location = New System.Drawing.Point(6, 57)
        Me.Factory_ID.Name = "Factory_ID"
        Me.Factory_ID.ReadOnly = True
        Me.Factory_ID.Size = New System.Drawing.Size(131, 21)
        Me.Factory_ID.TabIndex = 1258
        '
        'lbldepartmentcode
        '
        Me.lbldepartmentcode.BackColor = System.Drawing.Color.Transparent
        Me.lbldepartmentcode.Location = New System.Drawing.Point(3, 29)
        Me.lbldepartmentcode.Name = "lbldepartmentcode"
        Me.lbldepartmentcode.Size = New System.Drawing.Size(99, 15)
        Me.lbldepartmentcode.TabIndex = 1257
        Me.lbldepartmentcode.Text = "Bộ phận"
        Me.lbldepartmentcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SectionCode
        '
        Me.SectionCode.Location = New System.Drawing.Point(108, 4)
        Me.SectionCode.Name = "SectionCode"
        Me.SectionCode.Size = New System.Drawing.Size(191, 21)
        Me.SectionCode.TabIndex = 1
        '
        'lblSectionCode
        '
        Me.lblSectionCode.BackColor = System.Drawing.Color.Transparent
        Me.lblSectionCode.Location = New System.Drawing.Point(3, 4)
        Me.lblSectionCode.Name = "lblSectionCode"
        Me.lblSectionCode.Size = New System.Drawing.Size(99, 19)
        Me.lblSectionCode.TabIndex = 1256
        Me.lblSectionCode.Text = "Mã nhóm"
        Me.lblSectionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1255, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 60
        Me.btnSave.Text = "Lưu"
        '
        'frmSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1336, 470)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmSection_Nhap"
        Me.HRFORM_TableName = "SmartBooks_Section"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmSection"
        Me.Text = "Create/Edit Section"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.cbbdepartmentcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaMacDinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        tvcn.GetDataOnDropDownCategoryCodeName(JobCode, kn.ReadData("select JobCode as Code, Name" + obj.Lan + " as Name from HR_JobCodeCategory", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(cbbdepartmentcode, kn.ReadData("select * from [dbo].[udf_Department]('','" + obj.Lan + "','0')", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(ContractFlow, kn.ReadData("select distinct ContractFlow as Code, ContractFlow As Name from HR_ContractFlow", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(CaMacDinh, kn.ReadData("select ShiftName as Code, ShiftSign as Name from HR_Shifts", "table"))
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Gridex1_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub AnnualLeaveDays_Leave(sender As Object, e As EventArgs)
        If tvcn.isNumber(AnnualLeaveDays.Text.Trim) = False Then
            AnnualLeaveDays.Text = String.Empty
        End If
    End Sub
    Private Sub GioiHanTangCaMacDinh_Leave(sender As Object, e As EventArgs)
        If tvcn.isNumber(GioiHanTangCaMacDinh.Text.Trim) = False Then
            GioiHanTangCaMacDinh.Text = String.Empty
        End If
    End Sub

    Private Sub Search()
        Dim QR As String = "select * from SmartBooks_Section"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        SectionCode.Select()
        Search()
    End Sub

    Private Sub cbbdepartmentcode_EditValueChanged(sender As Object, e As EventArgs) Handles cbbdepartmentcode.EditValueChanged
        If cbbdepartmentcode.Text.Trim <> String.Empty Then
            Factory_ID.Text = Split(cbbdepartmentcode.EditValue.ToString(), "_")(0)
            departmentcode.Text = Split(cbbdepartmentcode.EditValue.ToString(), "_")(1)
        Else
            Factory_ID.Text = String.Empty
            departmentcode.Text = String.Empty
        End If
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp

    End Sub
End Class
