<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurgeryHistory
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
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.SurgeryDate = New DevExpress.XtraEditors.DateEdit()
        Me.PostSurgeryEffects = New DevExpress.XtraEditors.LookUpEdit()
        Me.SurgeryReason = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSurgeryDate = New System.Windows.Forms.Label()
        Me.lblPostSurgeryEffects = New System.Windows.Forms.Label()
        Me.lblSurgeryReason = New System.Windows.Forms.Label()
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
        CType(Me.SurgeryDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurgeryDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PostSurgeryEffects.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurgeryReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 377)
        Me.PanelButton.Size = New System.Drawing.Size(1153, 57)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1153, 377)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1151, 352)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(5, 101)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1141, 249)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1151, 99)
        Me.TableLayoutPanel2.TabIndex = 1302
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(226, 91)
        Me.pnSearch.TabIndex = 1322
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(4, 50)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1227
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 24)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(220, 20)
        Me.Employee_ID.TabIndex = 1225
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(7, 5)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(99, 23)
        Me.lblEmployee_ID.TabIndex = 1226
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.AutoScroll = True
        Me.pnDuLieuNhap.Controls.Add(Me.SurgeryDate)
        Me.pnDuLieuNhap.Controls.Add(Me.PostSurgeryEffects)
        Me.pnDuLieuNhap.Controls.Add(Me.SurgeryReason)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSurgeryDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPostSurgeryEffects)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSurgeryReason)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(237, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(662, 91)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'SurgeryDate
        '
        Me.SurgeryDate.EditValue = Nothing
        Me.SurgeryDate.Location = New System.Drawing.Point(451, 8)
        Me.SurgeryDate.Name = "SurgeryDate"
        Me.SurgeryDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SurgeryDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SurgeryDate.Properties.DisplayFormat.FormatString = ""
        Me.SurgeryDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.SurgeryDate.Properties.EditFormat.FormatString = ""
        Me.SurgeryDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.SurgeryDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.SurgeryDate.Properties.MaskSettings.Set("mask", "d")
        Me.SurgeryDate.Properties.UseMaskAsDisplayFormat = True
        Me.SurgeryDate.Size = New System.Drawing.Size(197, 20)
        Me.SurgeryDate.TabIndex = 1357
        '
        'PostSurgeryEffects
        '
        Me.PostSurgeryEffects.Location = New System.Drawing.Point(146, 36)
        Me.PostSurgeryEffects.Name = "PostSurgeryEffects"
        Me.PostSurgeryEffects.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.PostSurgeryEffects.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PostSurgeryEffects.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.PostSurgeryEffects.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.PostSurgeryEffects.Size = New System.Drawing.Size(185, 20)
        Me.PostSurgeryEffects.TabIndex = 1356
        '
        'SurgeryReason
        '
        Me.SurgeryReason.Location = New System.Drawing.Point(146, 9)
        Me.SurgeryReason.Name = "SurgeryReason"
        Me.SurgeryReason.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.SurgeryReason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SurgeryReason.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.SurgeryReason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.SurgeryReason.Size = New System.Drawing.Size(185, 20)
        Me.SurgeryReason.TabIndex = 1303
        '
        'lblSurgeryDate
        '
        Me.lblSurgeryDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblSurgeryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSurgeryDate.Location = New System.Drawing.Point(337, 7)
        Me.lblSurgeryDate.Name = "lblSurgeryDate"
        Me.lblSurgeryDate.Size = New System.Drawing.Size(108, 20)
        Me.lblSurgeryDate.TabIndex = 1354
        Me.lblSurgeryDate.Text = "Ngày phẫu thuật"
        Me.lblSurgeryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPostSurgeryEffects
        '
        Me.lblPostSurgeryEffects.BackColor = System.Drawing.SystemColors.Control
        Me.lblPostSurgeryEffects.Location = New System.Drawing.Point(3, 39)
        Me.lblPostSurgeryEffects.Name = "lblPostSurgeryEffects"
        Me.lblPostSurgeryEffects.Size = New System.Drawing.Size(137, 20)
        Me.lblPostSurgeryEffects.TabIndex = 1352
        Me.lblPostSurgeryEffects.Text = "Hiệu quả phẫu thuật"
        '
        'lblSurgeryReason
        '
        Me.lblSurgeryReason.BackColor = System.Drawing.SystemColors.Control
        Me.lblSurgeryReason.Location = New System.Drawing.Point(3, 11)
        Me.lblSurgeryReason.Name = "lblSurgeryReason"
        Me.lblSurgeryReason.Size = New System.Drawing.Size(137, 18)
        Me.lblSurgeryReason.TabIndex = 1351
        Me.lblSurgeryReason.Text = "Lý do phẫu thuật"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(452, 36)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(196, 43)
        Me.Remark.TabIndex = 6
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRemark.Location = New System.Drawing.Point(337, 36)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(108, 20)
        Me.lblRemark.TabIndex = 1348
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(906, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1328
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmSurgeryHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_SurgeryHistory"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmSurgeryHistory"
        Me.Text = "frmSurgeryHistory"
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
        CType(Me.SurgeryDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurgeryDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PostSurgeryEffects.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurgeryReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblSurgeryDate As Label
    Friend WithEvents lblPostSurgeryEffects As Label
    Friend WithEvents lblSurgeryReason As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PostSurgeryEffects As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SurgeryReason As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SurgeryDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
