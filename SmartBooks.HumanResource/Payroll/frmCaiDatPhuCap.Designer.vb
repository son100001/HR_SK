<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaiDatPhuCap
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
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.ToDate = New DevExpress.XtraEditors.DateEdit()
        Me.FromDate = New DevExpress.XtraEditors.DateEdit()
        Me.LoaiPhuCap = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLoaiPhuCap = New System.Windows.Forms.Label()
        Me.Bac = New System.Windows.Forms.TextBox()
        Me.Nhom = New System.Windows.Forms.TextBox()
        Me.Amount = New System.Windows.Forms.TextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.cbToDate = New System.Windows.Forms.CheckBox()
        Me.lblNhom = New System.Windows.Forms.Label()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.lblBac = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnLuu.SuspendLayout()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.ToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoaiPhuCap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 383)
        Me.PanelButton.Size = New System.Drawing.Size(1252, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1252, 383)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1250, 358)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 108)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1245, 248)
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
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1250, 106)
        Me.TableLayoutPanel2.TabIndex = 1306
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1008, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1351
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.ToDate)
        Me.pnDuLieuNhap.Controls.Add(Me.FromDate)
        Me.pnDuLieuNhap.Controls.Add(Me.LoaiPhuCap)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLoaiPhuCap)
        Me.pnDuLieuNhap.Controls.Add(Me.Bac)
        Me.pnDuLieuNhap.Controls.Add(Me.Nhom)
        Me.pnDuLieuNhap.Controls.Add(Me.Amount)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAmount)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFromDate)
        Me.pnDuLieuNhap.Controls.Add(Me.cbToDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNhom)
        Me.pnDuLieuNhap.Controls.Add(Me.lblToDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblBac)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(4, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(996, 98)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'ToDate
        '
        Me.ToDate.EditValue = Nothing
        Me.ToDate.Location = New System.Drawing.Point(546, 35)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.DisplayFormat.FormatString = ""
        Me.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.EditFormat.FormatString = ""
        Me.ToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ToDate.Properties.MaskSettings.Set("mask", "d")
        Me.ToDate.Properties.UseMaskAsDisplayFormat = True
        Me.ToDate.Size = New System.Drawing.Size(118, 20)
        Me.ToDate.TabIndex = 1351
        '
        'FromDate
        '
        Me.FromDate.EditValue = Nothing
        Me.FromDate.Location = New System.Drawing.Point(546, 12)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.DisplayFormat.FormatString = ""
        Me.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.EditFormat.FormatString = ""
        Me.FromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.FromDate.Properties.MaskSettings.Set("mask", "d")
        Me.FromDate.Properties.UseMaskAsDisplayFormat = True
        Me.FromDate.Size = New System.Drawing.Size(118, 20)
        Me.FromDate.TabIndex = 1350
        '
        'LoaiPhuCap
        '
        Me.LoaiPhuCap.Location = New System.Drawing.Point(195, 12)
        Me.LoaiPhuCap.Name = "LoaiPhuCap"
        Me.LoaiPhuCap.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LoaiPhuCap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LoaiPhuCap.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LoaiPhuCap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LoaiPhuCap.Size = New System.Drawing.Size(203, 20)
        Me.LoaiPhuCap.TabIndex = 1324
        '
        'lblLoaiPhuCap
        '
        Me.lblLoaiPhuCap.BackColor = System.Drawing.Color.Transparent
        Me.lblLoaiPhuCap.Location = New System.Drawing.Point(69, 13)
        Me.lblLoaiPhuCap.Name = "lblLoaiPhuCap"
        Me.lblLoaiPhuCap.Size = New System.Drawing.Size(120, 19)
        Me.lblLoaiPhuCap.TabIndex = 1277
        Me.lblLoaiPhuCap.Text = "Loại PC"
        Me.lblLoaiPhuCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Bac
        '
        Me.Bac.Location = New System.Drawing.Point(195, 64)
        Me.Bac.Name = "Bac"
        Me.Bac.Size = New System.Drawing.Size(203, 21)
        Me.Bac.TabIndex = 3
        '
        'Nhom
        '
        Me.Nhom.Location = New System.Drawing.Point(195, 39)
        Me.Nhom.Name = "Nhom"
        Me.Nhom.Size = New System.Drawing.Size(203, 21)
        Me.Nhom.TabIndex = 1
        '
        'Amount
        '
        Me.Amount.Location = New System.Drawing.Point(762, 11)
        Me.Amount.Name = "Amount"
        Me.Amount.Size = New System.Drawing.Size(218, 21)
        Me.Amount.TabIndex = 11
        '
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblAmount.Location = New System.Drawing.Point(679, 12)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(77, 19)
        Me.lblAmount.TabIndex = 1275
        Me.lblAmount.Text = "Số tiền"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(762, 34)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(218, 33)
        Me.Remark.TabIndex = 13
        Me.Remark.Text = ""
        '
        'lblFromDate
        '
        Me.lblFromDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblFromDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromDate.Location = New System.Drawing.Point(424, 12)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(95, 20)
        Me.lblFromDate.TabIndex = 1240
        Me.lblFromDate.Text = "Từ ngày"
        Me.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbToDate
        '
        Me.cbToDate.AutoSize = True
        Me.cbToDate.Location = New System.Drawing.Point(525, 40)
        Me.cbToDate.Name = "cbToDate"
        Me.cbToDate.Size = New System.Drawing.Size(15, 14)
        Me.cbToDate.TabIndex = 7
        Me.cbToDate.UseVisualStyleBackColor = True
        '
        'lblNhom
        '
        Me.lblNhom.BackColor = System.Drawing.Color.Transparent
        Me.lblNhom.Location = New System.Drawing.Point(69, 40)
        Me.lblNhom.Name = "lblNhom"
        Me.lblNhom.Size = New System.Drawing.Size(120, 19)
        Me.lblNhom.TabIndex = 1266
        Me.lblNhom.Text = "Nhóm"
        Me.lblNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToDate
        '
        Me.lblToDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblToDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToDate.Location = New System.Drawing.Point(424, 34)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(95, 20)
        Me.lblToDate.TabIndex = 1274
        Me.lblToDate.Text = "Đến ngày"
        Me.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBac
        '
        Me.lblBac.BackColor = System.Drawing.Color.Transparent
        Me.lblBac.Location = New System.Drawing.Point(70, 64)
        Me.lblBac.Name = "lblBac"
        Me.lblBac.Size = New System.Drawing.Size(119, 19)
        Me.lblBac.TabIndex = 1268
        Me.lblBac.Text = "Bậc"
        Me.lblBac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(679, 39)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(77, 16)
        Me.lblRemark.TabIndex = 1271
        Me.lblRemark.Text = "Ghi chú"
        '
        'frmCaiDatPhuCap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_CaiDatPhuCap"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_CaiDatPhuCap"
        Me.HRFORM_TableName = "HR_CaiDatPhuCap"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmCaiDatPhuCap"
        Me.Text = "frmCaiDatPhuCap"
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
        Me.pnLuu.ResumeLayout(False)
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.ToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoaiPhuCap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblLoaiPhuCap As Label
    Friend WithEvents Bac As TextBox
    Friend WithEvents Nhom As TextBox
    Friend WithEvents Amount As TextBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblFromDate As Label
    Friend WithEvents cbToDate As CheckBox
    Friend WithEvents lblNhom As Label
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblBac As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LoaiPhuCap As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents FromDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToDate As DevExpress.XtraEditors.DateEdit
End Class
