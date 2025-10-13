<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLicense
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
        Me.ValidTodate = New DevExpress.XtraEditors.DateEdit()
        Me.ValidFromdate = New DevExpress.XtraEditors.DateEdit()
        Me.IssuedDate = New DevExpress.XtraEditors.DateEdit()
        Me.LicenseType = New DevExpress.XtraEditors.LookUpEdit()
        Me.IssuedAt = New System.Windows.Forms.RichTextBox()
        Me.lblIssuedAt = New System.Windows.Forms.Label()
        Me.lblLicenseDoc = New System.Windows.Forms.Label()
        Me.LicenseDoc = New System.Windows.Forms.RichTextBox()
        Me.lblValidTodate = New System.Windows.Forms.Label()
        Me.lblValidFromdate = New System.Windows.Forms.Label()
        Me.lblIssuedDate = New System.Windows.Forms.Label()
        Me.lblLicenseID = New System.Windows.Forms.Label()
        Me.LicenseID = New System.Windows.Forms.RichTextBox()
        Me.lblLicenseType = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
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
        CType(Me.ValidTodate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidTodate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidFromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidFromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IssuedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IssuedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LicenseType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 383)
        Me.PanelButton.Size = New System.Drawing.Size(1196, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1196, 383)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1194, 358)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 95)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1189, 261)
        Me.GridControl1.TabIndex = 1322
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1194, 93)
        Me.TableLayoutPanel2.TabIndex = 1321
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(305, 85)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(8, 48)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1277
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(7, 22)
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
        Me.pnDuLieuNhap.Controls.Add(Me.ValidTodate)
        Me.pnDuLieuNhap.Controls.Add(Me.ValidFromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.IssuedDate)
        Me.pnDuLieuNhap.Controls.Add(Me.LicenseType)
        Me.pnDuLieuNhap.Controls.Add(Me.IssuedAt)
        Me.pnDuLieuNhap.Controls.Add(Me.lblIssuedAt)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLicenseDoc)
        Me.pnDuLieuNhap.Controls.Add(Me.LicenseDoc)
        Me.pnDuLieuNhap.Controls.Add(Me.lblValidTodate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblValidFromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblIssuedDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLicenseID)
        Me.pnDuLieuNhap.Controls.Add(Me.LicenseID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLicenseType)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(316, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(777, 85)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'ValidTodate
        '
        Me.ValidTodate.EditValue = Nothing
        Me.ValidTodate.Location = New System.Drawing.Point(356, 31)
        Me.ValidTodate.Name = "ValidTodate"
        Me.ValidTodate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidTodate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidTodate.Properties.DisplayFormat.FormatString = ""
        Me.ValidTodate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ValidTodate.Properties.EditFormat.FormatString = ""
        Me.ValidTodate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ValidTodate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ValidTodate.Properties.MaskSettings.Set("mask", "d")
        Me.ValidTodate.Properties.UseMaskAsDisplayFormat = True
        Me.ValidTodate.Size = New System.Drawing.Size(120, 20)
        Me.ValidTodate.TabIndex = 11
        '
        'ValidFromdate
        '
        Me.ValidFromdate.EditValue = Nothing
        Me.ValidFromdate.Location = New System.Drawing.Point(356, 7)
        Me.ValidFromdate.Name = "ValidFromdate"
        Me.ValidFromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidFromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ValidFromdate.Properties.DisplayFormat.FormatString = ""
        Me.ValidFromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ValidFromdate.Properties.EditFormat.FormatString = ""
        Me.ValidFromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ValidFromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ValidFromdate.Properties.MaskSettings.Set("mask", "d")
        Me.ValidFromdate.Properties.UseMaskAsDisplayFormat = True
        Me.ValidFromdate.Size = New System.Drawing.Size(120, 20)
        Me.ValidFromdate.TabIndex = 9
        '
        'IssuedDate
        '
        Me.IssuedDate.EditValue = Nothing
        Me.IssuedDate.Location = New System.Drawing.Point(112, 55)
        Me.IssuedDate.Name = "IssuedDate"
        Me.IssuedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.IssuedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.IssuedDate.Properties.DisplayFormat.FormatString = ""
        Me.IssuedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.IssuedDate.Properties.EditFormat.FormatString = ""
        Me.IssuedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.IssuedDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.IssuedDate.Properties.MaskSettings.Set("mask", "d")
        Me.IssuedDate.Properties.UseMaskAsDisplayFormat = True
        Me.IssuedDate.Size = New System.Drawing.Size(120, 20)
        Me.IssuedDate.TabIndex = 7
        '
        'LicenseType
        '
        Me.LicenseType.Location = New System.Drawing.Point(112, 7)
        Me.LicenseType.Name = "LicenseType"
        Me.LicenseType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LicenseType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LicenseType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LicenseType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LicenseType.Size = New System.Drawing.Size(121, 20)
        Me.LicenseType.TabIndex = 3
        '
        'IssuedAt
        '
        Me.IssuedAt.Location = New System.Drawing.Point(609, 7)
        Me.IssuedAt.Name = "IssuedAt"
        Me.IssuedAt.Size = New System.Drawing.Size(165, 19)
        Me.IssuedAt.TabIndex = 15
        Me.IssuedAt.Text = ""
        '
        'lblIssuedAt
        '
        Me.lblIssuedAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblIssuedAt.Location = New System.Drawing.Point(498, 5)
        Me.lblIssuedAt.Name = "lblIssuedAt"
        Me.lblIssuedAt.Size = New System.Drawing.Size(105, 20)
        Me.lblIssuedAt.TabIndex = 1362
        Me.lblIssuedAt.Text = "Ban hành tại"
        Me.lblIssuedAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLicenseDoc
        '
        Me.lblLicenseDoc.BackColor = System.Drawing.SystemColors.Control
        Me.lblLicenseDoc.Location = New System.Drawing.Point(245, 58)
        Me.lblLicenseDoc.Name = "lblLicenseDoc"
        Me.lblLicenseDoc.Size = New System.Drawing.Size(105, 19)
        Me.lblLicenseDoc.TabIndex = 1361
        Me.lblLicenseDoc.Text = "Giấy chứng nhận"
        '
        'LicenseDoc
        '
        Me.LicenseDoc.Location = New System.Drawing.Point(356, 56)
        Me.LicenseDoc.Name = "LicenseDoc"
        Me.LicenseDoc.Size = New System.Drawing.Size(136, 19)
        Me.LicenseDoc.TabIndex = 13
        Me.LicenseDoc.Text = ""
        '
        'lblValidTodate
        '
        Me.lblValidTodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblValidTodate.Location = New System.Drawing.Point(245, 29)
        Me.lblValidTodate.Name = "lblValidTodate"
        Me.lblValidTodate.Size = New System.Drawing.Size(105, 20)
        Me.lblValidTodate.TabIndex = 1359
        Me.lblValidTodate.Text = "Hiệu lực đến ngày"
        Me.lblValidTodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidFromdate
        '
        Me.lblValidFromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblValidFromdate.Location = New System.Drawing.Point(245, 4)
        Me.lblValidFromdate.Name = "lblValidFromdate"
        Me.lblValidFromdate.Size = New System.Drawing.Size(105, 20)
        Me.lblValidFromdate.TabIndex = 1358
        Me.lblValidFromdate.Text = "Hiệu lực từ ngày"
        Me.lblValidFromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIssuedDate
        '
        Me.lblIssuedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblIssuedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblIssuedDate.Location = New System.Drawing.Point(3, 55)
        Me.lblIssuedDate.Name = "lblIssuedDate"
        Me.lblIssuedDate.Size = New System.Drawing.Size(108, 20)
        Me.lblIssuedDate.TabIndex = 1354
        Me.lblIssuedDate.Text = "Ngày cấp"
        Me.lblIssuedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLicenseID
        '
        Me.lblLicenseID.BackColor = System.Drawing.SystemColors.Control
        Me.lblLicenseID.Location = New System.Drawing.Point(3, 34)
        Me.lblLicenseID.Name = "lblLicenseID"
        Me.lblLicenseID.Size = New System.Drawing.Size(103, 19)
        Me.lblLicenseID.TabIndex = 1352
        Me.lblLicenseID.Text = "Mã bằng cấp"
        '
        'LicenseID
        '
        Me.LicenseID.Location = New System.Drawing.Point(112, 30)
        Me.LicenseID.Name = "LicenseID"
        Me.LicenseID.Size = New System.Drawing.Size(121, 19)
        Me.LicenseID.TabIndex = 5
        Me.LicenseID.Text = ""
        '
        'lblLicenseType
        '
        Me.lblLicenseType.BackColor = System.Drawing.SystemColors.Control
        Me.lblLicenseType.Location = New System.Drawing.Point(3, 8)
        Me.lblLicenseType.Name = "lblLicenseType"
        Me.lblLicenseType.Size = New System.Drawing.Size(103, 18)
        Me.lblLicenseType.TabIndex = 1351
        Me.lblLicenseType.Text = "Loại bằng cấp"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(609, 33)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(165, 42)
        Me.Remark.TabIndex = 17
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRemark.Location = New System.Drawing.Point(498, 34)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(105, 20)
        Me.lblRemark.TabIndex = 1348
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1100, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 85)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 9)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Lưu"
        '
        'frmLicense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_LicenseOfEmployee"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmLicense"
        Me.Text = "frmLicense"
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
        CType(Me.ValidTodate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidTodate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidFromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidFromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IssuedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IssuedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LicenseType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents ValidTodate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ValidFromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents IssuedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LicenseType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents IssuedAt As RichTextBox
    Friend WithEvents lblIssuedAt As Label
    Friend WithEvents lblLicenseDoc As Label
    Friend WithEvents LicenseDoc As RichTextBox
    Friend WithEvents lblValidTodate As Label
    Friend WithEvents lblValidFromdate As Label
    Friend WithEvents lblIssuedDate As Label
    Friend WithEvents lblLicenseID As Label
    Friend WithEvents LicenseID As RichTextBox
    Friend WithEvents lblLicenseType As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
