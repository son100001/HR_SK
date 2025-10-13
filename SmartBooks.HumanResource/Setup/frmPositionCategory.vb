Imports WindowsControlLibrary
 
Public Class frmPositionCategory
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
    Friend WithEvents SalaryGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Nhom As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents CaMacDinh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ContractFlow As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSalaryGroup As Label
    Friend WithEvents lblNhom As Label
    Friend WithEvents lblPositionCategory_NameKR As Label
    Friend WithEvents PositionCategory_NameKR As TextBox
    Friend WithEvents lblPositionCategory_NameEN As Label
    Friend WithEvents lblPositionCategory_NameVN As Label
    Friend WithEvents PositionCategory_NameEN As TextBox
    Friend WithEvents PositionCategory_NameVN As TextBox
    Friend WithEvents lblPositionCategory_ID As Label
    Friend WithEvents PositionCategory_ID As TextBox
    Friend WithEvents AnnualLeaveDays As TextBox
    Friend WithEvents lblContractFlow As Label
    Friend WithEvents lblAnnualLeaveDays As Label
    Friend WithEvents lblCaMacDinh As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPositionCategory))
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
        Me.SalaryGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.Nhom = New DevExpress.XtraEditors.LookUpEdit()
        Me.CaMacDinh = New DevExpress.XtraEditors.LookUpEdit()
        Me.ContractFlow = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSalaryGroup = New System.Windows.Forms.Label()
        Me.lblNhom = New System.Windows.Forms.Label()
        Me.lblPositionCategory_NameKR = New System.Windows.Forms.Label()
        Me.PositionCategory_NameKR = New System.Windows.Forms.TextBox()
        Me.lblPositionCategory_NameEN = New System.Windows.Forms.Label()
        Me.lblPositionCategory_NameVN = New System.Windows.Forms.Label()
        Me.PositionCategory_NameEN = New System.Windows.Forms.TextBox()
        Me.PositionCategory_NameVN = New System.Windows.Forms.TextBox()
        Me.lblPositionCategory_ID = New System.Windows.Forms.Label()
        Me.PositionCategory_ID = New System.Windows.Forms.TextBox()
        Me.AnnualLeaveDays = New System.Windows.Forms.TextBox()
        Me.lblContractFlow = New System.Windows.Forms.Label()
        Me.lblAnnualLeaveDays = New System.Windows.Forms.Label()
        Me.lblCaMacDinh = New System.Windows.Forms.Label()
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
        CType(Me.SalaryGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nhom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 418)
        Me.PanelButton.Size = New System.Drawing.Size(1282, 52)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1282, 418)
        Me.XtraTabControl1.TabIndex = 1321
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1280, 393)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 100)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1276, 291)
        Me.GridControl1.TabIndex = 1322
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1280, 94)
        Me.TableLayoutPanel3.TabIndex = 1321
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.SalaryGroup)
        Me.pnDuLieuNhap.Controls.Add(Me.Nhom)
        Me.pnDuLieuNhap.Controls.Add(Me.CaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.ContractFlow)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSalaryGroup)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNhom)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPositionCategory_NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.PositionCategory_NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPositionCategory_NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPositionCategory_NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.PositionCategory_NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.PositionCategory_NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPositionCategory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.PositionCategory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.AnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.lblContractFlow)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCaMacDinh)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1083, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'SalaryGroup
        '
        Me.SalaryGroup.Location = New System.Drawing.Point(933, 31)
        Me.SalaryGroup.Name = "SalaryGroup"
        Me.SalaryGroup.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.SalaryGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SalaryGroup.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.SalaryGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.SalaryGroup.Size = New System.Drawing.Size(135, 20)
        Me.SalaryGroup.TabIndex = 21
        '
        'Nhom
        '
        Me.Nhom.Location = New System.Drawing.Point(933, 5)
        Me.Nhom.Name = "Nhom"
        Me.Nhom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Nhom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Nhom.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Nhom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Nhom.Size = New System.Drawing.Size(135, 20)
        Me.Nhom.TabIndex = 19
        '
        'CaMacDinh
        '
        Me.CaMacDinh.Location = New System.Drawing.Point(707, 6)
        Me.CaMacDinh.Name = "CaMacDinh"
        Me.CaMacDinh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.CaMacDinh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CaMacDinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CaMacDinh.Size = New System.Drawing.Size(80, 20)
        Me.CaMacDinh.TabIndex = 11
        '
        'ContractFlow
        '
        Me.ContractFlow.Location = New System.Drawing.Point(707, 53)
        Me.ContractFlow.Name = "ContractFlow"
        Me.ContractFlow.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ContractFlow.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractFlow.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ContractFlow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ContractFlow.Size = New System.Drawing.Size(135, 20)
        Me.ContractFlow.TabIndex = 17
        '
        'lblSalaryGroup
        '
        Me.lblSalaryGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblSalaryGroup.Location = New System.Drawing.Point(818, 31)
        Me.lblSalaryGroup.Name = "lblSalaryGroup"
        Me.lblSalaryGroup.Size = New System.Drawing.Size(100, 19)
        Me.lblSalaryGroup.TabIndex = 1288
        Me.lblSalaryGroup.Text = "Nhóm lương"
        Me.lblSalaryGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNhom
        '
        Me.lblNhom.BackColor = System.Drawing.Color.Transparent
        Me.lblNhom.Location = New System.Drawing.Point(816, 6)
        Me.lblNhom.Name = "lblNhom"
        Me.lblNhom.Size = New System.Drawing.Size(103, 19)
        Me.lblNhom.TabIndex = 1285
        Me.lblNhom.Text = "Nhóm tay nghề"
        Me.lblNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionCategory_NameKR
        '
        Me.lblPositionCategory_NameKR.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_NameKR.Location = New System.Drawing.Point(261, 50)
        Me.lblPositionCategory_NameKR.Name = "lblPositionCategory_NameKR"
        Me.lblPositionCategory_NameKR.Size = New System.Drawing.Size(117, 19)
        Me.lblPositionCategory_NameKR.TabIndex = 1283
        Me.lblPositionCategory_NameKR.Text = "Tên loại chức vụ (KR)"
        Me.lblPositionCategory_NameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PositionCategory_NameKR
        '
        Me.PositionCategory_NameKR.Location = New System.Drawing.Point(380, 53)
        Me.PositionCategory_NameKR.Name = "PositionCategory_NameKR"
        Me.PositionCategory_NameKR.Size = New System.Drawing.Size(157, 21)
        Me.PositionCategory_NameKR.TabIndex = 9
        '
        'lblPositionCategory_NameEN
        '
        Me.lblPositionCategory_NameEN.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_NameEN.Location = New System.Drawing.Point(258, 26)
        Me.lblPositionCategory_NameEN.Name = "lblPositionCategory_NameEN"
        Me.lblPositionCategory_NameEN.Size = New System.Drawing.Size(117, 19)
        Me.lblPositionCategory_NameEN.TabIndex = 1282
        Me.lblPositionCategory_NameEN.Text = "Tên loại chức vụ (EN)"
        Me.lblPositionCategory_NameEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionCategory_NameVN
        '
        Me.lblPositionCategory_NameVN.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_NameVN.Location = New System.Drawing.Point(258, 2)
        Me.lblPositionCategory_NameVN.Name = "lblPositionCategory_NameVN"
        Me.lblPositionCategory_NameVN.Size = New System.Drawing.Size(117, 19)
        Me.lblPositionCategory_NameVN.TabIndex = 1281
        Me.lblPositionCategory_NameVN.Text = "Tên loại chức vụ (VN)"
        Me.lblPositionCategory_NameVN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PositionCategory_NameEN
        '
        Me.PositionCategory_NameEN.Location = New System.Drawing.Point(381, 29)
        Me.PositionCategory_NameEN.Name = "PositionCategory_NameEN"
        Me.PositionCategory_NameEN.Size = New System.Drawing.Size(157, 21)
        Me.PositionCategory_NameEN.TabIndex = 7
        '
        'PositionCategory_NameVN
        '
        Me.PositionCategory_NameVN.Location = New System.Drawing.Point(381, 5)
        Me.PositionCategory_NameVN.Name = "PositionCategory_NameVN"
        Me.PositionCategory_NameVN.Size = New System.Drawing.Size(157, 21)
        Me.PositionCategory_NameVN.TabIndex = 5
        '
        'lblPositionCategory_ID
        '
        Me.lblPositionCategory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_ID.Location = New System.Drawing.Point(4, 7)
        Me.lblPositionCategory_ID.Name = "lblPositionCategory_ID"
        Me.lblPositionCategory_ID.Size = New System.Drawing.Size(94, 19)
        Me.lblPositionCategory_ID.TabIndex = 1276
        Me.lblPositionCategory_ID.Text = "Mã loại chức vụ"
        Me.lblPositionCategory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PositionCategory_ID
        '
        Me.PositionCategory_ID.Location = New System.Drawing.Point(104, 5)
        Me.PositionCategory_ID.Name = "PositionCategory_ID"
        Me.PositionCategory_ID.Size = New System.Drawing.Size(148, 21)
        Me.PositionCategory_ID.TabIndex = 1
        '
        'AnnualLeaveDays
        '
        Me.AnnualLeaveDays.Location = New System.Drawing.Point(707, 29)
        Me.AnnualLeaveDays.Name = "AnnualLeaveDays"
        Me.AnnualLeaveDays.Size = New System.Drawing.Size(56, 21)
        Me.AnnualLeaveDays.TabIndex = 15
        '
        'lblContractFlow
        '
        Me.lblContractFlow.BackColor = System.Drawing.Color.Transparent
        Me.lblContractFlow.Location = New System.Drawing.Point(556, 57)
        Me.lblContractFlow.Name = "lblContractFlow"
        Me.lblContractFlow.Size = New System.Drawing.Size(103, 19)
        Me.lblContractFlow.TabIndex = 1273
        Me.lblContractFlow.Text = "Luồng hợp đồng"
        Me.lblContractFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAnnualLeaveDays
        '
        Me.lblAnnualLeaveDays.BackColor = System.Drawing.Color.Transparent
        Me.lblAnnualLeaveDays.Location = New System.Drawing.Point(556, 31)
        Me.lblAnnualLeaveDays.Name = "lblAnnualLeaveDays"
        Me.lblAnnualLeaveDays.Size = New System.Drawing.Size(141, 19)
        Me.lblAnnualLeaveDays.TabIndex = 1272
        Me.lblAnnualLeaveDays.Text = "Số ngày phép năm"
        Me.lblAnnualLeaveDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaMacDinh
        '
        Me.lblCaMacDinh.BackColor = System.Drawing.Color.Transparent
        Me.lblCaMacDinh.Location = New System.Drawing.Point(556, 7)
        Me.lblCaMacDinh.Name = "lblCaMacDinh"
        Me.lblCaMacDinh.Size = New System.Drawing.Size(72, 19)
        Me.lblCaMacDinh.TabIndex = 1267
        Me.lblCaMacDinh.Text = "Ca mặc định"
        Me.lblCaMacDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1095, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Lưu"
        '
        'frmPositionCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1282, 470)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmPositionCategory_Nhap"
        Me.HRFORM_TableName = "SmartBooks_PositionCategory"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmPositionCategory"
        Me.Text = "Create/Edit Position Category"
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
        CType(Me.SalaryGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nhom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaMacDinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        tvcn.GetDataOnDropDownCategoryCodeName(ContractFlow, kn.ReadData("select distinct ContractFlow as Code, ContractFlow As Name from HR_ContractFlow", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(CaMacDinh, kn.ReadData("select ShiftName as Code, ShiftSign as Name from HR_Shifts", "table"))
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub AnnualLeaveDays_Leave(sender As Object, e As EventArgs)
        If tvcn.isNumber(AnnualLeaveDays.Text.Trim) = False Then
            AnnualLeaveDays.Text = String.Empty
        End If
    End Sub

    Private Sub Search()
        Dim QR As String = "select * from SmartBooks_PositionCategory"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        PositionCategory_ID.Select()
        Search()
    End Sub
End Class
