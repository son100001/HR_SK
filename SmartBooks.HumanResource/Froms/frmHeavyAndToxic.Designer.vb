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
        Me.HAZARD = New DevExpress.XtraEditors.LookUpEdit()
        Me.EffectiveDate = New DevExpress.XtraEditors.DateEdit()
        Me.Position_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblHAZARD = New System.Windows.Forms.Label()
        Me.lblEffectiveDate = New System.Windows.Forms.Label()
        Me.lblPosition_ID = New System.Windows.Forms.Label()
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
        CType(Me.HAZARD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Position_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 379)
        Me.PanelButton.Size = New System.Drawing.Size(968, 55)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(968, 434)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(966, 409)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 109)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(961, 243)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(966, 107)
        Me.TableLayoutPanel2.TabIndex = 1339
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(302, 99)
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
        Me.pnDuLieuNhap.Controls.Add(Me.HAZARD)
        Me.pnDuLieuNhap.Controls.Add(Me.EffectiveDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Position_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblHAZARD)
        Me.pnDuLieuNhap.Controls.Add(Me.lblEffectiveDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPosition_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.VL)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPhamTram)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(313, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(565, 99)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'HAZARD
        '
        Me.HAZARD.Location = New System.Drawing.Point(327, 8)
        Me.HAZARD.Name = "HAZARD"
        Me.HAZARD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.HAZARD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.HAZARD.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.HAZARD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.HAZARD.Size = New System.Drawing.Size(220, 20)
        Me.HAZARD.TabIndex = 1341
        '
        'EffectiveDate
        '
        Me.EffectiveDate.EditValue = Nothing
        Me.EffectiveDate.Location = New System.Drawing.Point(108, 34)
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
        Me.EffectiveDate.Size = New System.Drawing.Size(108, 20)
        Me.EffectiveDate.TabIndex = 1340
        '
        'Position_ID
        '
        Me.Position_ID.Location = New System.Drawing.Point(108, 9)
        Me.Position_ID.Name = "Position_ID"
        Me.Position_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Position_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Position_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Position_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Position_ID.Size = New System.Drawing.Size(108, 20)
        Me.Position_ID.TabIndex = 1339
        '
        'lblHAZARD
        '
        Me.lblHAZARD.BackColor = System.Drawing.Color.Transparent
        Me.lblHAZARD.Location = New System.Drawing.Point(248, 11)
        Me.lblHAZARD.Name = "lblHAZARD"
        Me.lblHAZARD.Size = New System.Drawing.Size(73, 15)
        Me.lblHAZARD.TabIndex = 1338
        Me.lblHAZARD.Text = "HAZARD"
        Me.lblHAZARD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEffectiveDate
        '
        Me.lblEffectiveDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEffectiveDate.Location = New System.Drawing.Point(12, 32)
        Me.lblEffectiveDate.Name = "lblEffectiveDate"
        Me.lblEffectiveDate.Size = New System.Drawing.Size(88, 19)
        Me.lblEffectiveDate.TabIndex = 1331
        Me.lblEffectiveDate.Text = "Ngày hiệu lực"
        Me.lblEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition_ID
        '
        Me.lblPosition_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition_ID.Location = New System.Drawing.Point(15, 12)
        Me.lblPosition_ID.Name = "lblPosition_ID"
        Me.lblPosition_ID.Size = New System.Drawing.Size(73, 15)
        Me.lblPosition_ID.TabIndex = 1337
        Me.lblPosition_ID.Text = "Chức vụ"
        Me.lblPosition_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(327, 34)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(220, 50)
        Me.Remark.TabIndex = 1329
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(248, 35)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(62, 19)
        Me.lblRemark.TabIndex = 1332
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VL
        '
        Me.VL.DecimalPlaces = 1
        Me.VL.Location = New System.Drawing.Point(108, 60)
        Me.VL.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.VL.Name = "VL"
        Me.VL.Size = New System.Drawing.Size(64, 21)
        Me.VL.TabIndex = 1327
        '
        'lblPhamTram
        '
        Me.lblPhamTram.BackColor = System.Drawing.Color.Transparent
        Me.lblPhamTram.Location = New System.Drawing.Point(12, 62)
        Me.lblPhamTram.Name = "lblPhamTram"
        Me.lblPhamTram.Size = New System.Drawing.Size(73, 15)
        Me.lblPhamTram.TabIndex = 1335
        Me.lblPhamTram.Text = "Phần trăm"
        Me.lblPhamTram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(885, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmHeavyAndToxic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_TransferFloatType"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_TransferFloatType"
        Me.HRFORM_TableName = "HR_TransferFloatType"
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_ImportExcel = False
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
        CType(Me.HAZARD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Position_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblHAZARD As Label
    Friend WithEvents lblPosition_ID As Label
    Friend WithEvents VL As NumericUpDown
    Friend WithEvents lblPhamTram As Label
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblEffectiveDate As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Position_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents HAZARD As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents EffectiveDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
