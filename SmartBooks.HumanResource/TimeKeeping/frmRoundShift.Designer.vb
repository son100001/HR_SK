<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoundShift
    Inherits WindowsControlLibrary.HRFORM
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.RoundShift = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbTypeOfReport = New System.Windows.Forms.CheckBox()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.ShiftName = New DevExpress.XtraEditors.LookUpEdit()
        Me.todate = New DevExpress.XtraEditors.DateEdit()
        Me.fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.TypeOfRegister = New System.Windows.Forms.TextBox()
        Me.GioTCTruoc = New System.Windows.Forms.TextBox()
        Me.lblGioTCTruoc = New System.Windows.Forms.Label()
        Me.lblExtraHours = New System.Windows.Forms.Label()
        Me.ExtraHours = New System.Windows.Forms.NumericUpDown()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblfromdate = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.lbltodate = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.RoundShiftDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.RoundShift.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExtraHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.RoundShiftDetail.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 371)
        Me.PanelButton.Size = New System.Drawing.Size(1150, 50)
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
        Me.XtraTabControl1.SelectedTabPage = Me.RoundShift
        Me.XtraTabControl1.Size = New System.Drawing.Size(1150, 371)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.RoundShift, Me.RoundShiftDetail})
        '
        'RoundShift
        '
        Me.RoundShift.Controls.Add(Me.GridControl1)
        Me.RoundShift.Controls.Add(Me.TableLayoutPanel2)
        Me.RoundShift.Name = "RoundShift"
        Me.RoundShift.Size = New System.Drawing.Size(1148, 346)
        Me.RoundShift.Text = "Round shift"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 85)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1148, 259)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel2
        '
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1148, 84)
        Me.TableLayoutPanel2.TabIndex = 1322
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.cbTypeOfReport)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 75)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(30, 47)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1301
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 22)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1
        '
        'cbTypeOfReport
        '
        Me.cbTypeOfReport.AutoSize = True
        Me.cbTypeOfReport.Location = New System.Drawing.Point(9, 50)
        Me.cbTypeOfReport.Name = "cbTypeOfReport"
        Me.cbTypeOfReport.Size = New System.Drawing.Size(15, 14)
        Me.cbTypeOfReport.TabIndex = 4
        Me.cbTypeOfReport.UseVisualStyleBackColor = True
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(1, 3)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(102, 23)
        Me.lblEmployee_ID.TabIndex = 1229
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.ShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.todate)
        Me.pnDuLieuNhap.Controls.Add(Me.fromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.TypeOfRegister)
        Me.pnDuLieuNhap.Controls.Add(Me.GioTCTruoc)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGioTCTruoc)
        Me.pnDuLieuNhap.Controls.Add(Me.lblExtraHours)
        Me.pnDuLieuNhap.Controls.Add(Me.ExtraHours)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblfromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.lbltodate)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(690, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'ShiftName
        '
        Me.ShiftName.Location = New System.Drawing.Point(94, 7)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ShiftName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ShiftName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ShiftName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ShiftName.Size = New System.Drawing.Size(95, 20)
        Me.ShiftName.TabIndex = 6
        '
        'todate
        '
        Me.todate.EditValue = Nothing
        Me.todate.Location = New System.Drawing.Point(277, 31)
        Me.todate.Name = "todate"
        Me.todate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.todate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.todate.Properties.DisplayFormat.FormatString = ""
        Me.todate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.todate.Properties.EditFormat.FormatString = ""
        Me.todate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.todate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.todate.Properties.MaskSettings.Set("mask", "d")
        Me.todate.Properties.UseMaskAsDisplayFormat = True
        Me.todate.Size = New System.Drawing.Size(123, 20)
        Me.todate.TabIndex = 10
        '
        'fromdate
        '
        Me.fromdate.EditValue = Nothing
        Me.fromdate.Location = New System.Drawing.Point(277, 7)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.DisplayFormat.FormatString = ""
        Me.fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditFormat.FormatString = ""
        Me.fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.fromdate.Size = New System.Drawing.Size(123, 20)
        Me.fromdate.TabIndex = 8
        '
        'TypeOfRegister
        '
        Me.TypeOfRegister.Location = New System.Drawing.Point(6, 50)
        Me.TypeOfRegister.Name = "TypeOfRegister"
        Me.TypeOfRegister.Size = New System.Drawing.Size(38, 21)
        Me.TypeOfRegister.TabIndex = 1232
        Me.TypeOfRegister.Text = "1"
        Me.TypeOfRegister.Visible = False
        '
        'GioTCTruoc
        '
        Me.GioTCTruoc.Location = New System.Drawing.Point(633, 7)
        Me.GioTCTruoc.Name = "GioTCTruoc"
        Me.GioTCTruoc.Size = New System.Drawing.Size(45, 21)
        Me.GioTCTruoc.TabIndex = 1231
        '
        'lblGioTCTruoc
        '
        Me.lblGioTCTruoc.BackColor = System.Drawing.Color.Transparent
        Me.lblGioTCTruoc.Location = New System.Drawing.Point(533, 4)
        Me.lblGioTCTruoc.Name = "lblGioTCTruoc"
        Me.lblGioTCTruoc.Size = New System.Drawing.Size(92, 23)
        Me.lblGioTCTruoc.TabIndex = 1230
        Me.lblGioTCTruoc.Text = "TC trước"
        Me.lblGioTCTruoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExtraHours
        '
        Me.lblExtraHours.BackColor = System.Drawing.Color.Transparent
        Me.lblExtraHours.Location = New System.Drawing.Point(403, 3)
        Me.lblExtraHours.Name = "lblExtraHours"
        Me.lblExtraHours.Size = New System.Drawing.Size(76, 23)
        Me.lblExtraHours.TabIndex = 1228
        Me.lblExtraHours.Text = "Giờ thêm"
        Me.lblExtraHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExtraHours
        '
        Me.ExtraHours.DecimalPlaces = 1
        Me.ExtraHours.Location = New System.Drawing.Point(485, 6)
        Me.ExtraHours.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ExtraHours.Name = "ExtraHours"
        Me.ExtraHours.Size = New System.Drawing.Size(43, 21)
        Me.ExtraHours.TabIndex = 13
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(482, 29)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(198, 38)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblfromdate
        '
        Me.lblfromdate.BackColor = System.Drawing.SystemColors.Control
        Me.lblfromdate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfromdate.Location = New System.Drawing.Point(195, 6)
        Me.lblfromdate.Name = "lblfromdate"
        Me.lblfromdate.Size = New System.Drawing.Size(78, 20)
        Me.lblfromdate.TabIndex = 1218
        Me.lblfromdate.Text = "Từ ngày"
        Me.lblfromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(404, 34)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(71, 16)
        Me.lblRemark.TabIndex = 1220
        Me.lblRemark.Text = "Ghi chú"
        '
        'lblShiftName
        '
        Me.lblShiftName.BackColor = System.Drawing.SystemColors.Control
        Me.lblShiftName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftName.Location = New System.Drawing.Point(3, 7)
        Me.lblShiftName.Name = "lblShiftName"
        Me.lblShiftName.Size = New System.Drawing.Size(85, 20)
        Me.lblShiftName.TabIndex = 1224
        Me.lblShiftName.Text = "Ca"
        Me.lblShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltodate
        '
        Me.lbltodate.BackColor = System.Drawing.SystemColors.Control
        Me.lbltodate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltodate.Location = New System.Drawing.Point(195, 30)
        Me.lbltodate.Name = "lbltodate"
        Me.lbltodate.Size = New System.Drawing.Size(78, 20)
        Me.lbltodate.TabIndex = 1226
        Me.lbltodate.Text = "Đến ngày"
        Me.lbltodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1021, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(61, 76)
        Me.pnLuu.TabIndex = 1327
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(4, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Lưu"
        '
        'RoundShiftDetail
        '
        Me.RoundShiftDetail.Controls.Add(Me.GridControl2)
        Me.RoundShiftDetail.Name = "RoundShiftDetail"
        Me.RoundShiftDetail.Size = New System.Drawing.Size(1148, 346)
        Me.RoundShiftDetail.Text = "Round shift detail"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1148, 346)
        Me.GridControl2.TabIndex = 1324
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'frmRoundShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 421)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_RoundShift"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_RoundShift"
        Me.HRFORM_TableName = "HR_RoundShift"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmRoundShift"
        Me.Text = "frmRoundShift"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.RoundShift.ResumeLayout(False)
        Me.RoundShift.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        Me.pnSearch.PerformLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExtraHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.RoundShiftDetail.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents RoundShift As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbTypeOfReport As CheckBox
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents ShiftName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TypeOfRegister As TextBox
    Friend WithEvents GioTCTruoc As TextBox
    Friend WithEvents lblGioTCTruoc As Label
    Friend WithEvents lblExtraHours As Label
    Friend WithEvents ExtraHours As NumericUpDown
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblfromdate As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblShiftName As Label
    Friend WithEvents lbltodate As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RoundShiftDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
