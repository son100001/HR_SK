<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAward
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
        Me.AwardDate = New DevExpress.XtraEditors.DateEdit()
        Me.AwardType = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblAwardDate = New System.Windows.Forms.Label()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.Reason = New System.Windows.Forms.RichTextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Amount = New DevExpress.XtraEditors.TextEdit()
        Me.lblAwardType = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        CType(Me.AwardDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AwardDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AwardType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Size = New System.Drawing.Size(1110, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1110, 406)
        Me.XtraTabControl1.TabIndex = 1007
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1108, 381)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(1, 108)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1104, 271)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1108, 98)
        Me.TableLayoutPanel2.TabIndex = 1319
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(316, 90)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(8, 53)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1276
        Me.btnSearch.Text = "Tìm"
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
        Me.pnDuLieuNhap.Controls.Add(Me.AwardDate)
        Me.pnDuLieuNhap.Controls.Add(Me.AwardType)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAwardDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblReason)
        Me.pnDuLieuNhap.Controls.Add(Me.Reason)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAmount)
        Me.pnDuLieuNhap.Controls.Add(Me.Amount)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAwardType)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.Label1)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(327, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(684, 90)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'AwardDate
        '
        Me.AwardDate.EditValue = Nothing
        Me.AwardDate.Location = New System.Drawing.Point(436, 4)
        Me.AwardDate.Name = "AwardDate"
        Me.AwardDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AwardDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AwardDate.Properties.DisplayFormat.FormatString = ""
        Me.AwardDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AwardDate.Properties.EditFormat.FormatString = ""
        Me.AwardDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AwardDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.AwardDate.Properties.MaskSettings.Set("mask", "d")
        Me.AwardDate.Properties.UseMaskAsDisplayFormat = True
        Me.AwardDate.Size = New System.Drawing.Size(120, 20)
        Me.AwardDate.TabIndex = 8
        '
        'AwardType
        '
        Me.AwardType.Location = New System.Drawing.Point(112, 1)
        Me.AwardType.Name = "AwardType"
        Me.AwardType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AwardType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.AwardType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.AwardType.Size = New System.Drawing.Size(201, 20)
        Me.AwardType.TabIndex = 4
        '
        'lblAwardDate
        '
        Me.lblAwardDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblAwardDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAwardDate.Location = New System.Drawing.Point(322, 1)
        Me.lblAwardDate.Name = "lblAwardDate"
        Me.lblAwardDate.Size = New System.Drawing.Size(108, 29)
        Me.lblAwardDate.TabIndex = 1370
        Me.lblAwardDate.Text = "Ngày khen thưởng"
        Me.lblAwardDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.SystemColors.Control
        Me.lblReason.Location = New System.Drawing.Point(3, 30)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(103, 30)
        Me.lblReason.TabIndex = 1369
        Me.lblReason.Text = "Lý do"
        '
        'Reason
        '
        Me.Reason.Location = New System.Drawing.Point(112, 31)
        Me.Reason.Name = "Reason"
        Me.Reason.Size = New System.Drawing.Size(201, 25)
        Me.Reason.TabIndex = 6
        Me.Reason.Text = ""

        'lblPrice
        '
        Me.lblAmount.BackColor = System.Drawing.SystemColors.Control
        Me.lblAmount.Location = New System.Drawing.Point(3, 60)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(103, 39)
        Me.lblAmount.TabIndex = 1369
        Me.lblAmount.Text = "Số tiền"
        '
        'Price
        '
        Me.Amount.Location = New System.Drawing.Point(112, 60)
        Me.Amount.Name = "Amount"
        Me.Amount.Properties.Appearance.Options.UseTextOptions = True
        Me.Amount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Amount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.Amount.Properties.Mask.EditMask = "n0" ' use "n2" to always show 2 decimals
        Me.Amount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.Amount.Size = New System.Drawing.Size(201, 21)
        Me.Amount.TabIndex = 6

        '
        'lblAwardType
        '
        Me.lblAwardType.BackColor = System.Drawing.SystemColors.Control
        Me.lblAwardType.Location = New System.Drawing.Point(3, 5)
        Me.lblAwardType.Name = "lblAwardType"
        Me.lblAwardType.Size = New System.Drawing.Size(103, 27)
        Me.lblAwardType.TabIndex = 1368
        Me.lblAwardType.Text = "Loại thưởng"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(437, 30)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(196, 51)
        Me.Remark.TabIndex = 10
        Me.Remark.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(322, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 29)
        Me.Label1.TabIndex = 1367
        Me.Label1.Text = "Ghi chú"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1018, 4)
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
        'frmAward
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_Award"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmAward"
        Me.Text = "frmAward"
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
        CType(Me.AwardDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AwardDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AwardType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents AwardDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents AwardType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblAwardDate As Label
    Friend WithEvents lblReason As Label
    Friend WithEvents Reason As RichTextBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents Amount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblAwardType As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
