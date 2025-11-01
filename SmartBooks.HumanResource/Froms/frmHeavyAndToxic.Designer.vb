<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHeavyAndToxic
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
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.lblStartedDate = New System.Windows.Forms.Label()
        Me.StartedDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblTodate = New System.Windows.Forms.Label()
        Me.Todate = New DevExpress.XtraEditors.DateEdit()
        Me.ChucDanh = New System.Windows.Forms.TextBox()
        Me.sectioncode = New System.Windows.Forms.TextBox()
        Me.departmentcode = New System.Windows.Forms.TextBox()
        Me.Factory_ID = New System.Windows.Forms.TextBox()
        Me.lblPositionCategory_ID = New System.Windows.Forms.Label()
        Me.lblsectioncode1 = New System.Windows.Forms.Label()
        Me.lblsectioncode = New System.Windows.Forms.Label()
        Me.lbldepartmentcode = New System.Windows.Forms.Label()
        Me.HAZARD = New DevExpress.XtraEditors.LookUpEdit()
        Me.Fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.lblHAZARD = New System.Windows.Forms.Label()
        Me.lblFromdate = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.VL = New System.Windows.Forms.NumericUpDown()
        Me.lblPhamTram = New System.Windows.Forms.Label()
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
        CType(Me.StartedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HAZARD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 379)
        Me.PanelButton.Size = New System.Drawing.Size(1117, 55)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1117, 434)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1115, 409)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 153)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1110, 199)
        Me.GridControl1.TabIndex = 1340
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1115, 98)
        Me.TableLayoutPanel2.TabIndex = 1339
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(302, 90)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(3, 59)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1224
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 32)
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
        Me.lblEmployee_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployee_ID.Location = New System.Drawing.Point(3, 9)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(71, 19)
        Me.lblEmployee_ID.TabIndex = 1333
        Me.lblEmployee_ID.Text = "Mã NV"
        Me.lblEmployee_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblStartedDate)
        Me.pnDuLieuNhap.Controls.Add(Me.StartedDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTodate)
        Me.pnDuLieuNhap.Controls.Add(Me.Todate)
        Me.pnDuLieuNhap.Controls.Add(Me.ChucDanh)
        Me.pnDuLieuNhap.Controls.Add(Me.sectioncode)
        Me.pnDuLieuNhap.Controls.Add(Me.departmentcode)
        Me.pnDuLieuNhap.Controls.Add(Me.Factory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPositionCategory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblsectioncode1)
        Me.pnDuLieuNhap.Controls.Add(Me.lblsectioncode)
        Me.pnDuLieuNhap.Controls.Add(Me.lbldepartmentcode)
        Me.pnDuLieuNhap.Controls.Add(Me.HAZARD)
        Me.pnDuLieuNhap.Controls.Add(Me.Fromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblHAZARD)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.VL)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPhamTram)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(313, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(681, 90)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblStartedDate
        '
        Me.lblStartedDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartedDate.Location = New System.Drawing.Point(208, 34)
        Me.lblStartedDate.Name = "lblStartedDate"
        Me.lblStartedDate.Size = New System.Drawing.Size(88, 19)
        Me.lblStartedDate.TabIndex = 1570
        Me.lblStartedDate.Text = "Ngày vào công ty"
        Me.lblStartedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StartedDate
        '
        Me.StartedDate.EditValue = Nothing
        Me.StartedDate.Enabled = False
        Me.StartedDate.Location = New System.Drawing.Point(301, 34)
        Me.StartedDate.Name = "StartedDate"
        Me.StartedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartedDate.Properties.DisplayFormat.FormatString = ""
        Me.StartedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.StartedDate.Properties.EditFormat.FormatString = ""
        Me.StartedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.StartedDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.StartedDate.Properties.MaskSettings.Set("mask", "d")
        Me.StartedDate.Properties.UseMaskAsDisplayFormat = True
        Me.StartedDate.Size = New System.Drawing.Size(96, 20)
        Me.StartedDate.TabIndex = 1569
        '
        'lblTodate
        '
        Me.lblTodate.BackColor = System.Drawing.Color.Transparent
        Me.lblTodate.Location = New System.Drawing.Point(406, 34)
        Me.lblTodate.Name = "lblTodate"
        Me.lblTodate.Size = New System.Drawing.Size(88, 19)
        Me.lblTodate.TabIndex = 1568
        Me.lblTodate.Text = "Đến ngày"
        Me.lblTodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Todate
        '
        Me.Todate.EditValue = Nothing
        Me.Todate.Location = New System.Drawing.Point(499, 36)
        Me.Todate.Name = "Todate"
        Me.Todate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Todate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Todate.Properties.DisplayFormat.FormatString = ""
        Me.Todate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Todate.Properties.EditFormat.FormatString = ""
        Me.Todate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Todate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Todate.Properties.MaskSettings.Set("mask", "d")
        Me.Todate.Properties.UseMaskAsDisplayFormat = True
        Me.Todate.Size = New System.Drawing.Size(96, 20)
        Me.Todate.TabIndex = 1567
        '
        'ChucDanh
        '
        Me.ChucDanh.Enabled = False
        Me.ChucDanh.Location = New System.Drawing.Point(301, 9)
        Me.ChucDanh.Name = "ChucDanh"
        Me.ChucDanh.Size = New System.Drawing.Size(96, 21)
        Me.ChucDanh.TabIndex = 1566
        '
        'sectioncode
        '
        Me.sectioncode.Enabled = False
        Me.sectioncode.Location = New System.Drawing.Point(89, 59)
        Me.sectioncode.Name = "sectioncode"
        Me.sectioncode.Size = New System.Drawing.Size(112, 21)
        Me.sectioncode.TabIndex = 1565
        '
        'departmentcode
        '
        Me.departmentcode.Enabled = False
        Me.departmentcode.Location = New System.Drawing.Point(90, 34)
        Me.departmentcode.Name = "departmentcode"
        Me.departmentcode.Size = New System.Drawing.Size(112, 21)
        Me.departmentcode.TabIndex = 1564
        '
        'Factory_ID
        '
        Me.Factory_ID.Enabled = False
        Me.Factory_ID.Location = New System.Drawing.Point(90, 9)
        Me.Factory_ID.Name = "Factory_ID"
        Me.Factory_ID.Size = New System.Drawing.Size(112, 21)
        Me.Factory_ID.TabIndex = 1563
        '
        'lblPositionCategory_ID
        '
        Me.lblPositionCategory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_ID.Location = New System.Drawing.Point(208, 8)
        Me.lblPositionCategory_ID.Name = "lblPositionCategory_ID"
        Me.lblPositionCategory_ID.Size = New System.Drawing.Size(72, 19)
        Me.lblPositionCategory_ID.TabIndex = 1562
        Me.lblPositionCategory_ID.Text = "Loại chức vụ"
        Me.lblPositionCategory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblsectioncode1
        '
        Me.lblsectioncode1.BackColor = System.Drawing.Color.Transparent
        Me.lblsectioncode1.Location = New System.Drawing.Point(5, 57)
        Me.lblsectioncode1.Name = "lblsectioncode1"
        Me.lblsectioncode1.Size = New System.Drawing.Size(79, 19)
        Me.lblsectioncode1.TabIndex = 1561
        Me.lblsectioncode1.Text = "Loại chức vụ"
        Me.lblsectioncode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblsectioncode
        '
        Me.lblsectioncode.BackColor = System.Drawing.Color.Transparent
        Me.lblsectioncode.Location = New System.Drawing.Point(8, 33)
        Me.lblsectioncode.Name = "lblsectioncode"
        Me.lblsectioncode.Size = New System.Drawing.Size(76, 19)
        Me.lblsectioncode.TabIndex = 1557
        Me.lblsectioncode.Text = "Phòng ban"
        Me.lblsectioncode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbldepartmentcode
        '
        Me.lbldepartmentcode.BackColor = System.Drawing.Color.Transparent
        Me.lbldepartmentcode.Location = New System.Drawing.Point(8, 9)
        Me.lbldepartmentcode.Name = "lbldepartmentcode"
        Me.lbldepartmentcode.Size = New System.Drawing.Size(76, 19)
        Me.lbldepartmentcode.TabIndex = 1556
        Me.lbldepartmentcode.Text = "Bộ phận"
        Me.lbldepartmentcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HAZARD
        '
        Me.HAZARD.Location = New System.Drawing.Point(634, 35)
        Me.HAZARD.Name = "HAZARD"
        Me.HAZARD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.HAZARD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.HAZARD.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.HAZARD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.HAZARD.Size = New System.Drawing.Size(34, 20)
        Me.HAZARD.TabIndex = 1341
        Me.HAZARD.Visible = False
        '
        'Fromdate
        '
        Me.Fromdate.EditValue = Nothing
        Me.Fromdate.Location = New System.Drawing.Point(499, 9)
        Me.Fromdate.Name = "Fromdate"
        Me.Fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Fromdate.Properties.DisplayFormat.FormatString = ""
        Me.Fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Fromdate.Properties.EditFormat.FormatString = ""
        Me.Fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.Fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.Fromdate.Size = New System.Drawing.Size(96, 20)
        Me.Fromdate.TabIndex = 1340
        '
        'lblHAZARD
        '
        Me.lblHAZARD.BackColor = System.Drawing.Color.Transparent
        Me.lblHAZARD.Location = New System.Drawing.Point(589, 37)
        Me.lblHAZARD.Name = "lblHAZARD"
        Me.lblHAZARD.Size = New System.Drawing.Size(37, 15)
        Me.lblHAZARD.TabIndex = 1338
        Me.lblHAZARD.Text = "HAZARD"
        Me.lblHAZARD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHAZARD.Visible = False
        '
        'lblFromdate
        '
        Me.lblFromdate.BackColor = System.Drawing.Color.Transparent
        Me.lblFromdate.Location = New System.Drawing.Point(406, 8)
        Me.lblFromdate.Name = "lblFromdate"
        Me.lblFromdate.Size = New System.Drawing.Size(88, 19)
        Me.lblFromdate.TabIndex = 1331
        Me.lblFromdate.Text = "Từ ngày"
        Me.lblFromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(499, 61)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(167, 19)
        Me.Remark.TabIndex = 1329
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(406, 61)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(73, 19)
        Me.lblRemark.TabIndex = 1332
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VL
        '
        Me.VL.DecimalPlaces = 1
        Me.VL.Location = New System.Drawing.Point(638, 6)
        Me.VL.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.VL.Name = "VL"
        Me.VL.Size = New System.Drawing.Size(30, 21)
        Me.VL.TabIndex = 1327
        Me.VL.Visible = False
        '
        'lblPhamTram
        '
        Me.lblPhamTram.BackColor = System.Drawing.Color.Transparent
        Me.lblPhamTram.Location = New System.Drawing.Point(589, 7)
        Me.lblPhamTram.Name = "lblPhamTram"
        Me.lblPhamTram.Size = New System.Drawing.Size(37, 15)
        Me.lblPhamTram.TabIndex = 1335
        Me.lblPhamTram.Text = "Phần trăm"
        Me.lblPhamTram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPhamTram.Visible = False
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1001, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(69, 90)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(63, 85)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmHeavyAndToxic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_TransferFloatType"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_TransferFloatType"
        Me.HRFORM_TableName = "HR_TransferFloatType"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmHeavyAndToxic"
        Me.Text = "frmHeavyAndToxic"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
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
        CType(Me.StartedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HAZARD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblHAZARD As Label
    Friend WithEvents VL As NumericUpDown
    Friend WithEvents lblPhamTram As Label
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblFromdate As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents HAZARD As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblsectioncode1 As Label
    Friend WithEvents lblsectioncode As Label
    Friend WithEvents lbldepartmentcode As Label
    Friend WithEvents lblPositionCategory_ID As Label
    Friend WithEvents ChucDanh As TextBox
    Friend WithEvents sectioncode As TextBox
    Friend WithEvents departmentcode As TextBox
    Friend WithEvents Factory_ID As TextBox
    Friend WithEvents Todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblStartedDate As Label
    Friend WithEvents StartedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTodate As Label
End Class
