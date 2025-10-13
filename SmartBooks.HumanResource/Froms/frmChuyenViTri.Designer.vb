<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChuyenViTri
    Inherits WindowsControlLibrary.HRFORM

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.cbTypeOfView = New System.Windows.Forms.CheckBox()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.EffectiveDate = New DevExpress.XtraEditors.DateEdit()
        Me.Position_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.PositionCategory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.ChucDanh = New DevExpress.XtraEditors.LookUpEdit()
        Me.JobCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.OldPosition_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.OldPositionCategory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.OldChucDanh = New DevExpress.XtraEditors.LookUpEdit()
        Me.OldJobCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.Position = New DevExpress.XtraEditors.LookUpEdit()
        Me.OldPosition = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblPosition_ID = New System.Windows.Forms.Label()
        Me.lblPositionCategory_ID = New System.Windows.Forms.Label()
        Me.lblChucDanh = New System.Windows.Forms.Label()
        Me.lblOldPosition = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblEffectiveDate = New System.Windows.Forms.Label()
        Me.lblJobCode = New System.Windows.Forms.Label()
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
        CType(Me.EffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Position_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChucDanh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldPosition_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldPositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldChucDanh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldJobCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Position.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 385)
        Me.PanelButton.Size = New System.Drawing.Size(1370, 55)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1370, 385)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1368, 360)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(1, 167)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1365, 193)
        Me.GridControl1.TabIndex = 1320
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
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1368, 165)
        Me.TableLayoutPanel2.TabIndex = 1319
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.cbTypeOfView)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(316, 157)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(29, 53)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1224
        Me.btnSearch.Text = "Tìm"
        '
        'cbTypeOfView
        '
        Me.cbTypeOfView.AutoSize = True
        Me.cbTypeOfView.Location = New System.Drawing.Point(8, 56)
        Me.cbTypeOfView.Name = "cbTypeOfView"
        Me.cbTypeOfView.Size = New System.Drawing.Size(15, 14)
        Me.cbTypeOfView.TabIndex = 1220
        Me.cbTypeOfView.UseVisualStyleBackColor = True
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(7, 27)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(5, 4)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(92, 23)
        Me.lblEmployee_ID.TabIndex = 1219
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.AutoScroll = True
        Me.pnDuLieuNhap.Controls.Add(Me.EffectiveDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Position_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.PositionCategory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.ChucDanh)
        Me.pnDuLieuNhap.Controls.Add(Me.JobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.OldPosition_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.OldPositionCategory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.OldChucDanh)
        Me.pnDuLieuNhap.Controls.Add(Me.OldJobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.Position)
        Me.pnDuLieuNhap.Controls.Add(Me.OldPosition)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPosition_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPositionCategory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblChucDanh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblOldPosition)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPosition)
        Me.pnDuLieuNhap.Controls.Add(Me.lblEffectiveDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblJobCode)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(327, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(746, 157)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'EffectiveDate
        '
        Me.EffectiveDate.EditValue = Nothing
        Me.EffectiveDate.Location = New System.Drawing.Point(584, 3)
        Me.EffectiveDate.Name = "EffectiveDate"
        Me.EffectiveDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EffectiveDate.Properties.DisplayFormat.FormatString = ""
        Me.EffectiveDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EffectiveDate.Properties.EditFormat.FormatString = ""
        Me.EffectiveDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EffectiveDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.EffectiveDate.Properties.MaskSettings.Set("mask", "d")
        Me.EffectiveDate.Properties.UseMaskAsDisplayFormat = True
        Me.EffectiveDate.Size = New System.Drawing.Size(120, 20)
        Me.EffectiveDate.TabIndex = 1346
        '
        'Position_ID
        '
        Me.Position_ID.Location = New System.Drawing.Point(289, 124)
        Me.Position_ID.Name = "Position_ID"
        Me.Position_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Position_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Position_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Position_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Position_ID.Size = New System.Drawing.Size(175, 20)
        Me.Position_ID.TabIndex = 1345
        '
        'PositionCategory_ID
        '
        Me.PositionCategory_ID.Location = New System.Drawing.Point(289, 101)
        Me.PositionCategory_ID.Name = "PositionCategory_ID"
        Me.PositionCategory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.PositionCategory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PositionCategory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.PositionCategory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.PositionCategory_ID.Size = New System.Drawing.Size(175, 20)
        Me.PositionCategory_ID.TabIndex = 1344
        '
        'ChucDanh
        '
        Me.ChucDanh.Location = New System.Drawing.Point(289, 75)
        Me.ChucDanh.Name = "ChucDanh"
        Me.ChucDanh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChucDanh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChucDanh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ChucDanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ChucDanh.Size = New System.Drawing.Size(175, 20)
        Me.ChucDanh.TabIndex = 1343
        '
        'JobCode
        '
        Me.JobCode.Location = New System.Drawing.Point(289, 51)
        Me.JobCode.Name = "JobCode"
        Me.JobCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.JobCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.JobCode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.JobCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.JobCode.Size = New System.Drawing.Size(175, 20)
        Me.JobCode.TabIndex = 1342
        '
        'OldPosition_ID
        '
        Me.OldPosition_ID.Enabled = False
        Me.OldPosition_ID.Location = New System.Drawing.Point(111, 126)
        Me.OldPosition_ID.Name = "OldPosition_ID"
        Me.OldPosition_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.OldPosition_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OldPosition_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.OldPosition_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.OldPosition_ID.Size = New System.Drawing.Size(172, 20)
        Me.OldPosition_ID.TabIndex = 1341
        '
        'OldPositionCategory_ID
        '
        Me.OldPositionCategory_ID.Enabled = False
        Me.OldPositionCategory_ID.Location = New System.Drawing.Point(111, 101)
        Me.OldPositionCategory_ID.Name = "OldPositionCategory_ID"
        Me.OldPositionCategory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.OldPositionCategory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OldPositionCategory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.OldPositionCategory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.OldPositionCategory_ID.Size = New System.Drawing.Size(172, 20)
        Me.OldPositionCategory_ID.TabIndex = 1340
        '
        'OldChucDanh
        '
        Me.OldChucDanh.Enabled = False
        Me.OldChucDanh.Location = New System.Drawing.Point(111, 75)
        Me.OldChucDanh.Name = "OldChucDanh"
        Me.OldChucDanh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.OldChucDanh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OldChucDanh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.OldChucDanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.OldChucDanh.Size = New System.Drawing.Size(172, 20)
        Me.OldChucDanh.TabIndex = 1339
        '
        'OldJobCode
        '
        Me.OldJobCode.Enabled = False
        Me.OldJobCode.Location = New System.Drawing.Point(111, 51)
        Me.OldJobCode.Name = "OldJobCode"
        Me.OldJobCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.OldJobCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OldJobCode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.OldJobCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.OldJobCode.Size = New System.Drawing.Size(172, 20)
        Me.OldJobCode.TabIndex = 1338
        '
        'Position
        '
        Me.Position.Location = New System.Drawing.Point(111, 28)
        Me.Position.Name = "Position"
        Me.Position.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Position.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Position.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Position.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Position.Size = New System.Drawing.Size(353, 20)
        Me.Position.TabIndex = 1337
        '
        'OldPosition
        '
        Me.OldPosition.Enabled = False
        Me.OldPosition.Location = New System.Drawing.Point(111, 4)
        Me.OldPosition.Name = "OldPosition"
        Me.OldPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.OldPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OldPosition.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.OldPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.OldPosition.Size = New System.Drawing.Size(353, 20)
        Me.OldPosition.TabIndex = 1336
        '
        'lblPosition_ID
        '
        Me.lblPosition_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition_ID.Location = New System.Drawing.Point(3, 127)
        Me.lblPosition_ID.Name = "lblPosition_ID"
        Me.lblPosition_ID.Size = New System.Drawing.Size(102, 19)
        Me.lblPosition_ID.TabIndex = 1330
        Me.lblPosition_ID.Text = "Chức vụ"
        Me.lblPosition_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionCategory_ID
        '
        Me.lblPositionCategory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_ID.Location = New System.Drawing.Point(3, 101)
        Me.lblPositionCategory_ID.Name = "lblPositionCategory_ID"
        Me.lblPositionCategory_ID.Size = New System.Drawing.Size(102, 19)
        Me.lblPositionCategory_ID.TabIndex = 1329
        Me.lblPositionCategory_ID.Text = "Loại chức vụ"
        Me.lblPositionCategory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChucDanh
        '
        Me.lblChucDanh.BackColor = System.Drawing.Color.Transparent
        Me.lblChucDanh.Location = New System.Drawing.Point(6, 75)
        Me.lblChucDanh.Name = "lblChucDanh"
        Me.lblChucDanh.Size = New System.Drawing.Size(99, 19)
        Me.lblChucDanh.TabIndex = 1326
        Me.lblChucDanh.Text = "Chức danh"
        Me.lblChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOldPosition
        '
        Me.lblOldPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblOldPosition.Location = New System.Drawing.Point(4, 7)
        Me.lblOldPosition.Name = "lblOldPosition"
        Me.lblOldPosition.Size = New System.Drawing.Size(101, 15)
        Me.lblOldPosition.TabIndex = 1325
        Me.lblOldPosition.Text = "Vị trí cũ"
        Me.lblOldPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(584, 27)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(129, 46)
        Me.Remark.TabIndex = 1319
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(489, 40)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(60, 19)
        Me.lblRemark.TabIndex = 1321
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition.ForeColor = System.Drawing.Color.Red
        Me.lblPosition.Location = New System.Drawing.Point(4, 30)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(101, 15)
        Me.lblPosition.TabIndex = 1323
        Me.lblPosition.Text = "Vị trí mới *"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEffectiveDate
        '
        Me.lblEffectiveDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEffectiveDate.Location = New System.Drawing.Point(487, 2)
        Me.lblEffectiveDate.Name = "lblEffectiveDate"
        Me.lblEffectiveDate.Size = New System.Drawing.Size(90, 19)
        Me.lblEffectiveDate.TabIndex = 1320
        Me.lblEffectiveDate.Text = "Ngày hiệu lực"
        Me.lblEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJobCode
        '
        Me.lblJobCode.BackColor = System.Drawing.Color.Transparent
        Me.lblJobCode.Location = New System.Drawing.Point(4, 49)
        Me.lblJobCode.Name = "lblJobCode"
        Me.lblJobCode.Size = New System.Drawing.Size(101, 19)
        Me.lblJobCode.TabIndex = 1322
        Me.lblJobCode.Text = "Job code"
        Me.lblJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1080, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "Lưu"
        '
        'frmChuyenViTri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 440)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_Transfer"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_MainFormName = "frmChuyenViTri"
        Me.HRFORM_TableName = "HR_Transfer"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmChuyenViTri"
        Me.Text = "frmChuyenViTri"
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
        Me.pnSearch.PerformLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        CType(Me.EffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Position_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChucDanh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldPosition_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldPositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldChucDanh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldJobCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Position.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbTypeOfView As CheckBox
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents EffectiveDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Position_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PositionCategory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ChucDanh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents JobCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OldPosition_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OldPositionCategory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OldChucDanh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OldJobCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Position As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OldPosition As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblPosition_ID As Label
    Friend WithEvents lblPositionCategory_ID As Label
    Friend WithEvents lblChucDanh As Label
    Friend WithEvents lblOldPosition As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblEffectiveDate As Label
    Friend WithEvents lblJobCode As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
