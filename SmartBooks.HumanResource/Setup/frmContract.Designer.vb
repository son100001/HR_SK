<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContract
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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.FromDate = New DevExpress.XtraEditors.DateEdit()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.SalaryPercent = New System.Windows.Forms.TextBox()
        Me.lblSalaryPercent = New System.Windows.Forms.Label()
        Me.isAppendix = New System.Windows.Forms.CheckBox()
        Me.isOnlyWorkingDay = New System.Windows.Forms.CheckBox()
        Me.NumberOfYear = New System.Windows.Forms.TextBox()
        Me.NumberOfMonth = New System.Windows.Forms.TextBox()
        Me.NumberOfDay = New System.Windows.Forms.TextBox()
        Me.lblNumberOfYear = New System.Windows.Forms.Label()
        Me.lblNumberOfMonth = New System.Windows.Forms.Label()
        Me.lblNumberOfDay = New System.Windows.Forms.Label()
        Me.FileTemplate = New System.Windows.Forms.TextBox()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.lblFileTemplate = New System.Windows.Forms.Label()
        Me.ConTract_NameKR = New System.Windows.Forms.TextBox()
        Me.lblConTract_NameKR = New System.Windows.Forms.Label()
        Me.ConTract_NameEN = New System.Windows.Forms.TextBox()
        Me.ConTract_NameVN = New System.Windows.Forms.TextBox()
        Me.lblConTract_NameEN = New System.Windows.Forms.Label()
        Me.lblConTract_NameVN = New System.Windows.Forms.Label()
        Me.Contract_ID = New System.Windows.Forms.TextBox()
        Me.lblContract_ID = New System.Windows.Forms.Label()
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
        CType(Me.FromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 347)
        Me.PanelButton.Size = New System.Drawing.Size(1228, 52)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1228, 347)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1226, 322)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(3, 96)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1221, 221)
        Me.GridControl1.TabIndex = 1323
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1226, 94)
        Me.TableLayoutPanel3.TabIndex = 1322
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.FromDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.SalaryPercent)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSalaryPercent)
        Me.pnDuLieuNhap.Controls.Add(Me.isAppendix)
        Me.pnDuLieuNhap.Controls.Add(Me.isOnlyWorkingDay)
        Me.pnDuLieuNhap.Controls.Add(Me.NumberOfYear)
        Me.pnDuLieuNhap.Controls.Add(Me.NumberOfMonth)
        Me.pnDuLieuNhap.Controls.Add(Me.NumberOfDay)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNumberOfYear)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNumberOfMonth)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNumberOfDay)
        Me.pnDuLieuNhap.Controls.Add(Me.FileTemplate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFromDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFileTemplate)
        Me.pnDuLieuNhap.Controls.Add(Me.ConTract_NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblConTract_NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.ConTract_NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.ConTract_NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblConTract_NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblConTract_NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.Contract_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblContract_ID)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1145, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'FromDate
        '
        Me.FromDate.EditValue = Nothing
        Me.FromDate.Location = New System.Drawing.Point(104, 29)
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
        Me.FromDate.Size = New System.Drawing.Size(139, 20)
        Me.FromDate.TabIndex = 337
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(937, 27)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(205, 56)
        Me.Remark.TabIndex = 25
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(941, 7)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(120, 19)
        Me.lblRemark.TabIndex = 336
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SalaryPercent
        '
        Me.SalaryPercent.Location = New System.Drawing.Point(810, 59)
        Me.SalaryPercent.Name = "SalaryPercent"
        Me.SalaryPercent.Size = New System.Drawing.Size(72, 21)
        Me.SalaryPercent.TabIndex = 23
        '
        'lblSalaryPercent
        '
        Me.lblSalaryPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblSalaryPercent.Location = New System.Drawing.Point(713, 56)
        Me.lblSalaryPercent.Name = "lblSalaryPercent"
        Me.lblSalaryPercent.Size = New System.Drawing.Size(91, 23)
        Me.lblSalaryPercent.TabIndex = 335
        Me.lblSalaryPercent.Text = "Phần tră lương"
        Me.lblSalaryPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'isAppendix
        '
        Me.isAppendix.AutoSize = True
        Me.isAppendix.Location = New System.Drawing.Point(714, 35)
        Me.isAppendix.Name = "isAppendix"
        Me.isAppendix.Size = New System.Drawing.Size(60, 17)
        Me.isAppendix.TabIndex = 21
        Me.isAppendix.Text = "Phụ lục"
        Me.isAppendix.UseVisualStyleBackColor = True
        '
        'isOnlyWorkingDay
        '
        Me.isOnlyWorkingDay.AutoSize = True
        Me.isOnlyWorkingDay.Location = New System.Drawing.Point(714, 12)
        Me.isOnlyWorkingDay.Name = "isOnlyWorkingDay"
        Me.isOnlyWorkingDay.Size = New System.Drawing.Size(137, 17)
        Me.isOnlyWorkingDay.TabIndex = 19
        Me.isOnlyWorkingDay.Text = "Dựa trên ngày làm việc"
        Me.isOnlyWorkingDay.UseVisualStyleBackColor = True
        '
        'NumberOfYear
        '
        Me.NumberOfYear.Location = New System.Drawing.Point(629, 56)
        Me.NumberOfYear.Name = "NumberOfYear"
        Me.NumberOfYear.Size = New System.Drawing.Size(72, 21)
        Me.NumberOfYear.TabIndex = 17
        '
        'NumberOfMonth
        '
        Me.NumberOfMonth.Location = New System.Drawing.Point(629, 32)
        Me.NumberOfMonth.Name = "NumberOfMonth"
        Me.NumberOfMonth.Size = New System.Drawing.Size(72, 21)
        Me.NumberOfMonth.TabIndex = 15
        '
        'NumberOfDay
        '
        Me.NumberOfDay.Location = New System.Drawing.Point(629, 8)
        Me.NumberOfDay.Name = "NumberOfDay"
        Me.NumberOfDay.Size = New System.Drawing.Size(72, 21)
        Me.NumberOfDay.TabIndex = 13
        '
        'lblNumberOfYear
        '
        Me.lblNumberOfYear.BackColor = System.Drawing.Color.Transparent
        Me.lblNumberOfYear.Location = New System.Drawing.Point(551, 53)
        Me.lblNumberOfYear.Name = "lblNumberOfYear"
        Me.lblNumberOfYear.Size = New System.Drawing.Size(72, 23)
        Me.lblNumberOfYear.TabIndex = 332
        Me.lblNumberOfYear.Text = "Số năm"
        Me.lblNumberOfYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumberOfMonth
        '
        Me.lblNumberOfMonth.BackColor = System.Drawing.Color.Transparent
        Me.lblNumberOfMonth.Location = New System.Drawing.Point(551, 29)
        Me.lblNumberOfMonth.Name = "lblNumberOfMonth"
        Me.lblNumberOfMonth.Size = New System.Drawing.Size(72, 23)
        Me.lblNumberOfMonth.TabIndex = 331
        Me.lblNumberOfMonth.Text = "Số tháng"
        Me.lblNumberOfMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumberOfDay
        '
        Me.lblNumberOfDay.BackColor = System.Drawing.Color.Transparent
        Me.lblNumberOfDay.Location = New System.Drawing.Point(551, 5)
        Me.lblNumberOfDay.Name = "lblNumberOfDay"
        Me.lblNumberOfDay.Size = New System.Drawing.Size(72, 23)
        Me.lblNumberOfDay.TabIndex = 330
        Me.lblNumberOfDay.Text = "Số ngày"
        Me.lblNumberOfDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FileTemplate
        '
        Me.FileTemplate.Location = New System.Drawing.Point(104, 53)
        Me.FileTemplate.Name = "FileTemplate"
        Me.FileTemplate.Size = New System.Drawing.Size(139, 21)
        Me.FileTemplate.TabIndex = 5
        '
        'lblFromDate
        '
        Me.lblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.lblFromDate.Location = New System.Drawing.Point(4, 29)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(94, 19)
        Me.lblFromDate.TabIndex = 325
        Me.lblFromDate.Text = "Áp dụng từ ngày"
        Me.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFileTemplate
        '
        Me.lblFileTemplate.BackColor = System.Drawing.Color.Transparent
        Me.lblFileTemplate.Location = New System.Drawing.Point(5, 55)
        Me.lblFileTemplate.Name = "lblFileTemplate"
        Me.lblFileTemplate.Size = New System.Drawing.Size(94, 19)
        Me.lblFileTemplate.TabIndex = 324
        Me.lblFileTemplate.Text = "Mẫu HĐ"
        Me.lblFileTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConTract_NameKR
        '
        Me.ConTract_NameKR.Location = New System.Drawing.Point(350, 53)
        Me.ConTract_NameKR.Name = "ConTract_NameKR"
        Me.ConTract_NameKR.Size = New System.Drawing.Size(186, 21)
        Me.ConTract_NameKR.TabIndex = 11
        '
        'lblConTract_NameKR
        '
        Me.lblConTract_NameKR.BackColor = System.Drawing.Color.Transparent
        Me.lblConTract_NameKR.Location = New System.Drawing.Point(249, 53)
        Me.lblConTract_NameKR.Name = "lblConTract_NameKR"
        Me.lblConTract_NameKR.Size = New System.Drawing.Size(95, 19)
        Me.lblConTract_NameKR.TabIndex = 317
        Me.lblConTract_NameKR.Text = "Tên HĐ (KR)"
        Me.lblConTract_NameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConTract_NameEN
        '
        Me.ConTract_NameEN.Location = New System.Drawing.Point(350, 29)
        Me.ConTract_NameEN.Name = "ConTract_NameEN"
        Me.ConTract_NameEN.Size = New System.Drawing.Size(186, 21)
        Me.ConTract_NameEN.TabIndex = 9
        '
        'ConTract_NameVN
        '
        Me.ConTract_NameVN.Location = New System.Drawing.Point(350, 5)
        Me.ConTract_NameVN.Name = "ConTract_NameVN"
        Me.ConTract_NameVN.Size = New System.Drawing.Size(186, 21)
        Me.ConTract_NameVN.TabIndex = 7
        '
        'lblConTract_NameEN
        '
        Me.lblConTract_NameEN.BackColor = System.Drawing.Color.Transparent
        Me.lblConTract_NameEN.Location = New System.Drawing.Point(249, 29)
        Me.lblConTract_NameEN.Name = "lblConTract_NameEN"
        Me.lblConTract_NameEN.Size = New System.Drawing.Size(95, 19)
        Me.lblConTract_NameEN.TabIndex = 316
        Me.lblConTract_NameEN.Text = "Tên HĐ (EN)"
        Me.lblConTract_NameEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConTract_NameVN
        '
        Me.lblConTract_NameVN.BackColor = System.Drawing.Color.Transparent
        Me.lblConTract_NameVN.Location = New System.Drawing.Point(249, 5)
        Me.lblConTract_NameVN.Name = "lblConTract_NameVN"
        Me.lblConTract_NameVN.Size = New System.Drawing.Size(95, 19)
        Me.lblConTract_NameVN.TabIndex = 315
        Me.lblConTract_NameVN.Text = "Tên HĐ (VN)"
        Me.lblConTract_NameVN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Contract_ID
        '
        Me.Contract_ID.Location = New System.Drawing.Point(104, 4)
        Me.Contract_ID.Name = "Contract_ID"
        Me.Contract_ID.Size = New System.Drawing.Size(139, 21)
        Me.Contract_ID.TabIndex = 1
        '
        'lblContract_ID
        '
        Me.lblContract_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblContract_ID.Location = New System.Drawing.Point(4, 4)
        Me.lblContract_ID.Name = "lblContract_ID"
        Me.lblContract_ID.Size = New System.Drawing.Size(95, 19)
        Me.lblContract_ID.TabIndex = 309
        Me.lblContract_ID.Text = "Mã hợp đồng"
        Me.lblContract_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1157, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Lưu"
        '
        'frmContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 399)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "SmartBooks_Contract"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmContract"
        Me.Text = "frmContract"
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
        CType(Me.FromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents SalaryPercent As TextBox
    Friend WithEvents lblSalaryPercent As Label
    Friend WithEvents isAppendix As CheckBox
    Friend WithEvents isOnlyWorkingDay As CheckBox
    Friend WithEvents NumberOfYear As TextBox
    Friend WithEvents NumberOfMonth As TextBox
    Friend WithEvents NumberOfDay As TextBox
    Friend WithEvents lblNumberOfYear As Label
    Friend WithEvents lblNumberOfMonth As Label
    Friend WithEvents lblNumberOfDay As Label
    Friend WithEvents FileTemplate As TextBox
    Friend WithEvents lblFromDate As Label
    Friend WithEvents lblFileTemplate As Label
    Friend WithEvents ConTract_NameKR As TextBox
    Friend WithEvents lblConTract_NameKR As Label
    Friend WithEvents ConTract_NameEN As TextBox
    Friend WithEvents ConTract_NameVN As TextBox
    Friend WithEvents lblConTract_NameEN As Label
    Friend WithEvents lblConTract_NameVN As Label
    Friend WithEvents Contract_ID As TextBox
    Friend WithEvents lblContract_ID As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FromDate As DevExpress.XtraEditors.DateEdit
End Class
