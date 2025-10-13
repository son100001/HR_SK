Imports WindowsControlLibrary
 

Public Class frmDepartment
    Inherits HRFORM
    'Dim kn As New WindowsControlLibrary.connect(DbSetting.dataPath)

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
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuChart As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheck As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents CaMacDinh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Factory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ContractFlow As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents JobCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblJobCode As Label
    Friend WithEvents lblOrderBy As Label
    Friend WithEvents OrderBy As NumericUpDown
    Friend WithEvents lblContractFlow As Label
    Friend WithEvents AnnualLeaveDays As TextBox
    Friend WithEvents lblAnnualLeaveDays As Label
    Friend WithEvents GioiHanTangCaMacDinh As TextBox
    Friend WithEvents lblGioiHanTangCaMacDinh As Label
    Friend WithEvents lblCaMacDinh As Label
    Friend WithEvents lblDirect As Label
    Friend WithEvents Direct As CheckBox
    Friend WithEvents DepartmentName_KR As TextBox
    Friend WithEvents lblDepartmentName_KR As Label
    Friend WithEvents DepartmentName_EN As TextBox
    Friend WithEvents lblDepartmentName_EN As Label
    Friend WithEvents lblFactory_ID As Label
    Friend WithEvents DepartmentName_VN As TextBox
    Friend WithEvents DepartmentCode As TextBox
    Friend WithEvents lblDepartmentName_VN As Label
    Friend WithEvents lblDepartmentCode As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.mnuChart = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuCheck = New System.Windows.Forms.MenuItem()
        Me.mnuClear = New System.Windows.Forms.MenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.CaMacDinh = New DevExpress.XtraEditors.LookUpEdit()
        Me.Factory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.ContractFlow = New DevExpress.XtraEditors.LookUpEdit()
        Me.JobCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblJobCode = New System.Windows.Forms.Label()
        Me.lblOrderBy = New System.Windows.Forms.Label()
        Me.OrderBy = New System.Windows.Forms.NumericUpDown()
        Me.lblContractFlow = New System.Windows.Forms.Label()
        Me.AnnualLeaveDays = New System.Windows.Forms.TextBox()
        Me.lblAnnualLeaveDays = New System.Windows.Forms.Label()
        Me.GioiHanTangCaMacDinh = New System.Windows.Forms.TextBox()
        Me.lblGioiHanTangCaMacDinh = New System.Windows.Forms.Label()
        Me.lblCaMacDinh = New System.Windows.Forms.Label()
        Me.lblDirect = New System.Windows.Forms.Label()
        Me.Direct = New System.Windows.Forms.CheckBox()
        Me.DepartmentName_KR = New System.Windows.Forms.TextBox()
        Me.lblDepartmentName_KR = New System.Windows.Forms.Label()
        Me.DepartmentName_EN = New System.Windows.Forms.TextBox()
        Me.lblDepartmentName_EN = New System.Windows.Forms.Label()
        Me.lblFactory_ID = New System.Windows.Forms.Label()
        Me.DepartmentName_VN = New System.Windows.Forms.TextBox()
        Me.DepartmentCode = New System.Windows.Forms.TextBox()
        Me.lblDepartmentName_VN = New System.Windows.Forms.Label()
        Me.lblDepartmentCode = New System.Windows.Forms.Label()
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
        CType(Me.CaMacDinh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Factory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 417)
        Me.PanelButton.Size = New System.Drawing.Size(1368, 53)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1368, 417)
        Me.XtraTabControl1.TabIndex = 1318
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1366, 392)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(3, 87)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1360, 303)
        Me.GridControl1.TabIndex = 1319
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1366, 85)
        Me.TableLayoutPanel3.TabIndex = 1318
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.CaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.Factory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.ContractFlow)
        Me.pnDuLieuNhap.Controls.Add(Me.JobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblJobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblOrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.OrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.lblContractFlow)
        Me.pnDuLieuNhap.Controls.Add(Me.AnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.GioiHanTangCaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGioiHanTangCaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCaMacDinh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDirect)
        Me.pnDuLieuNhap.Controls.Add(Me.Direct)
        Me.pnDuLieuNhap.Controls.Add(Me.DepartmentName_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDepartmentName_KR)
        Me.pnDuLieuNhap.Controls.Add(Me.DepartmentName_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDepartmentName_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFactory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.DepartmentName_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.DepartmentCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDepartmentName_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDepartmentCode)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1290, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'CaMacDinh
        '
        Me.CaMacDinh.Location = New System.Drawing.Point(896, 7)
        Me.CaMacDinh.Name = "CaMacDinh"
        Me.CaMacDinh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.CaMacDinh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CaMacDinh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.CaMacDinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CaMacDinh.Size = New System.Drawing.Size(90, 20)
        Me.CaMacDinh.TabIndex = 13
        '
        'Factory_ID
        '
        Me.Factory_ID.Location = New System.Drawing.Point(128, 25)
        Me.Factory_ID.Name = "Factory_ID"
        Me.Factory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Factory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Factory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Factory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Factory_ID.Size = New System.Drawing.Size(240, 20)
        Me.Factory_ID.TabIndex = 3
        '
        'ContractFlow
        '
        Me.ContractFlow.Location = New System.Drawing.Point(1095, 6)
        Me.ContractFlow.Name = "ContractFlow"
        Me.ContractFlow.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ContractFlow.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractFlow.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ContractFlow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ContractFlow.Size = New System.Drawing.Size(183, 20)
        Me.ContractFlow.TabIndex = 19
        '
        'JobCode
        '
        Me.JobCode.Location = New System.Drawing.Point(1095, 51)
        Me.JobCode.Name = "JobCode"
        Me.JobCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.JobCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.JobCode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.JobCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.JobCode.Size = New System.Drawing.Size(183, 20)
        Me.JobCode.TabIndex = 23
        '
        'lblJobCode
        '
        Me.lblJobCode.BackColor = System.Drawing.Color.Transparent
        Me.lblJobCode.Location = New System.Drawing.Point(993, 54)
        Me.lblJobCode.Name = "lblJobCode"
        Me.lblJobCode.Size = New System.Drawing.Size(101, 19)
        Me.lblJobCode.TabIndex = 1278
        Me.lblJobCode.Text = "Job code"
        Me.lblJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOrderBy
        '
        Me.lblOrderBy.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderBy.Location = New System.Drawing.Point(993, 30)
        Me.lblOrderBy.Name = "lblOrderBy"
        Me.lblOrderBy.Size = New System.Drawing.Size(74, 19)
        Me.lblOrderBy.TabIndex = 1274
        Me.lblOrderBy.Text = "Thứ tự"
        Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OrderBy
        '
        Me.OrderBy.Location = New System.Drawing.Point(1095, 29)
        Me.OrderBy.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.OrderBy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.OrderBy.Name = "OrderBy"
        Me.OrderBy.Size = New System.Drawing.Size(64, 21)
        Me.OrderBy.TabIndex = 21
        Me.OrderBy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblContractFlow
        '
        Me.lblContractFlow.BackColor = System.Drawing.Color.Transparent
        Me.lblContractFlow.Location = New System.Drawing.Point(992, 7)
        Me.lblContractFlow.Name = "lblContractFlow"
        Me.lblContractFlow.Size = New System.Drawing.Size(97, 19)
        Me.lblContractFlow.TabIndex = 1270
        Me.lblContractFlow.Text = "Luồng hợp đồng"
        Me.lblContractFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AnnualLeaveDays
        '
        Me.AnnualLeaveDays.Location = New System.Drawing.Point(896, 53)
        Me.AnnualLeaveDays.Name = "AnnualLeaveDays"
        Me.AnnualLeaveDays.Size = New System.Drawing.Size(56, 21)
        Me.AnnualLeaveDays.TabIndex = 17
        '
        'lblAnnualLeaveDays
        '
        Me.lblAnnualLeaveDays.BackColor = System.Drawing.Color.Transparent
        Me.lblAnnualLeaveDays.Location = New System.Drawing.Point(745, 53)
        Me.lblAnnualLeaveDays.Name = "lblAnnualLeaveDays"
        Me.lblAnnualLeaveDays.Size = New System.Drawing.Size(141, 19)
        Me.lblAnnualLeaveDays.TabIndex = 1268
        Me.lblAnnualLeaveDays.Text = "Số ngày phép năm"
        Me.lblAnnualLeaveDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GioiHanTangCaMacDinh
        '
        Me.GioiHanTangCaMacDinh.Location = New System.Drawing.Point(896, 29)
        Me.GioiHanTangCaMacDinh.Name = "GioiHanTangCaMacDinh"
        Me.GioiHanTangCaMacDinh.Size = New System.Drawing.Size(56, 21)
        Me.GioiHanTangCaMacDinh.TabIndex = 15
        '
        'lblGioiHanTangCaMacDinh
        '
        Me.lblGioiHanTangCaMacDinh.BackColor = System.Drawing.Color.Transparent
        Me.lblGioiHanTangCaMacDinh.Location = New System.Drawing.Point(745, 29)
        Me.lblGioiHanTangCaMacDinh.Name = "lblGioiHanTangCaMacDinh"
        Me.lblGioiHanTangCaMacDinh.Size = New System.Drawing.Size(141, 19)
        Me.lblGioiHanTangCaMacDinh.TabIndex = 1267
        Me.lblGioiHanTangCaMacDinh.Text = "Giới hạn tăng ca mặc định"
        Me.lblGioiHanTangCaMacDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaMacDinh
        '
        Me.lblCaMacDinh.BackColor = System.Drawing.Color.Transparent
        Me.lblCaMacDinh.Location = New System.Drawing.Point(747, 5)
        Me.lblCaMacDinh.Name = "lblCaMacDinh"
        Me.lblCaMacDinh.Size = New System.Drawing.Size(72, 19)
        Me.lblCaMacDinh.TabIndex = 1264
        Me.lblCaMacDinh.Text = "Ca mặc định"
        Me.lblCaMacDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDirect
        '
        Me.lblDirect.BackColor = System.Drawing.Color.Transparent
        Me.lblDirect.Location = New System.Drawing.Point(380, 52)
        Me.lblDirect.Name = "lblDirect"
        Me.lblDirect.Size = New System.Drawing.Size(72, 19)
        Me.lblDirect.TabIndex = 1262
        Me.lblDirect.Text = "Trực tiếp"
        Me.lblDirect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Direct
        '
        Me.Direct.AutoSize = True
        Me.Direct.Location = New System.Drawing.Point(492, 55)
        Me.Direct.Name = "Direct"
        Me.Direct.Size = New System.Drawing.Size(15, 14)
        Me.Direct.TabIndex = 11
        Me.Direct.UseVisualStyleBackColor = True
        '
        'DepartmentName_KR
        '
        Me.DepartmentName_KR.Location = New System.Drawing.Point(492, 29)
        Me.DepartmentName_KR.Name = "DepartmentName_KR"
        Me.DepartmentName_KR.Size = New System.Drawing.Size(240, 21)
        Me.DepartmentName_KR.TabIndex = 9
        '
        'lblDepartmentName_KR
        '
        Me.lblDepartmentName_KR.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName_KR.Location = New System.Drawing.Point(378, 29)
        Me.lblDepartmentName_KR.Name = "lblDepartmentName_KR"
        Me.lblDepartmentName_KR.Size = New System.Drawing.Size(108, 19)
        Me.lblDepartmentName_KR.TabIndex = 1261
        Me.lblDepartmentName_KR.Text = "Tên bộ phận (KR)"
        Me.lblDepartmentName_KR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepartmentName_EN
        '
        Me.DepartmentName_EN.Location = New System.Drawing.Point(492, 5)
        Me.DepartmentName_EN.Name = "DepartmentName_EN"
        Me.DepartmentName_EN.Size = New System.Drawing.Size(240, 21)
        Me.DepartmentName_EN.TabIndex = 7
        '
        'lblDepartmentName_EN
        '
        Me.lblDepartmentName_EN.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName_EN.Location = New System.Drawing.Point(378, 5)
        Me.lblDepartmentName_EN.Name = "lblDepartmentName_EN"
        Me.lblDepartmentName_EN.Size = New System.Drawing.Size(108, 19)
        Me.lblDepartmentName_EN.TabIndex = 1260
        Me.lblDepartmentName_EN.Text = "Tên bộ phận (EN)"
        Me.lblDepartmentName_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFactory_ID
        '
        Me.lblFactory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblFactory_ID.Location = New System.Drawing.Point(7, 28)
        Me.lblFactory_ID.Name = "lblFactory_ID"
        Me.lblFactory_ID.Size = New System.Drawing.Size(111, 15)
        Me.lblFactory_ID.TabIndex = 1256
        Me.lblFactory_ID.Text = "Phòng ban"
        Me.lblFactory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepartmentName_VN
        '
        Me.DepartmentName_VN.Location = New System.Drawing.Point(128, 47)
        Me.DepartmentName_VN.Name = "DepartmentName_VN"
        Me.DepartmentName_VN.Size = New System.Drawing.Size(240, 21)
        Me.DepartmentName_VN.TabIndex = 5
        '
        'DepartmentCode
        '
        Me.DepartmentCode.Location = New System.Drawing.Point(128, 2)
        Me.DepartmentCode.Name = "DepartmentCode"
        Me.DepartmentCode.Size = New System.Drawing.Size(240, 21)
        Me.DepartmentCode.TabIndex = 1
        '
        'lblDepartmentName_VN
        '
        Me.lblDepartmentName_VN.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName_VN.Location = New System.Drawing.Point(7, 47)
        Me.lblDepartmentName_VN.Name = "lblDepartmentName_VN"
        Me.lblDepartmentName_VN.Size = New System.Drawing.Size(111, 19)
        Me.lblDepartmentName_VN.TabIndex = 1255
        Me.lblDepartmentName_VN.Text = "Tên bộ phận (VN)"
        Me.lblDepartmentName_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentCode.Location = New System.Drawing.Point(7, 2)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(111, 19)
        Me.lblDepartmentCode.TabIndex = 1254
        Me.lblDepartmentCode.Text = "Mã bộ phận"
        Me.lblDepartmentCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1302, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 1301
        Me.btnSave.Text = "Lưu"
        '
        'frmDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1368, 470)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmDepartment_Nhap"
        Me.HRFORM_MainFormName = "frmDepartment"
        Me.HRFORM_TableName = "SmartBooks_Department"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmDepartment"
        Me.Text = "Create/Edit Department"
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
        CType(Me.CaMacDinh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Factory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        tvcn.GetDataOnDropDownCategoryCodeName(JobCode, kn.ReadData("select JobCode as Code, Name" + obj.Lan + " as Name from HR_JobCodeCategory", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(Factory_ID, kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "')", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(ContractFlow, kn.ReadData("select distinct ContractFlow as Code, ContractFlow As Name from HR_ContractFlow", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(CaMacDinh, kn.ReadData("select ShiftName as Code, ShiftSign as Name from HR_Shifts", "table"))
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Gridex1_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub AnnualLeaveDays_Leave(sender As Object, e As EventArgs) Handles AnnualLeaveDays.Leave
        If tvcn.isNumber(AnnualLeaveDays.Text.Trim) = False Then
            AnnualLeaveDays.Text = String.Empty
        End If
    End Sub

    Private Sub GioiHanTangCaMacDinh_Leave(sender As Object, e As EventArgs) Handles GioiHanTangCaMacDinh.Leave
        If tvcn.isNumber(GioiHanTangCaMacDinh.Text.Trim) = False Then
            GioiHanTangCaMacDinh.Text = String.Empty
        End If
    End Sub

    Private Sub Search()
        Dim QR As String = "select * from SmartBooks_Department"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        DepartmentCode.Select()
        Search()
    End Sub
End Class
