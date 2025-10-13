<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaoDieuChinhDanhMucLuong
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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.lblMonthlyChanging = New System.Windows.Forms.Label()
        Me.lblInsurance = New System.Windows.Forms.Label()
        Me.lblSalaryComponent = New System.Windows.Forms.Label()
        Me.SalaryComponent = New System.Windows.Forms.TextBox()
        Me.OrderBy = New System.Windows.Forms.NumericUpDown()
        Me.lblOrderBy = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.MonthlyChanging = New System.Windows.Forms.CheckBox()
        Me.Insurance = New System.Windows.Forms.CheckBox()
        Me.NameVN = New System.Windows.Forms.TextBox()
        Me.lblNameVN = New System.Windows.Forms.Label()
        Me.NameKR = New System.Windows.Forms.TextBox()
        Me.lblNameKR = New System.Windows.Forms.Label()
        Me.NameEN = New System.Windows.Forms.TextBox()
        Me.lblNameEN = New System.Windows.Forms.Label()
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
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 329)
        Me.PanelButton.Size = New System.Drawing.Size(1089, 49)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1089, 329)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1087, 304)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 96)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1088, 206)
        Me.GridControl1.TabIndex = 1325
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1087, 94)
        Me.TableLayoutPanel3.TabIndex = 1324
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblMonthlyChanging)
        Me.pnDuLieuNhap.Controls.Add(Me.lblInsurance)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSalaryComponent)
        Me.pnDuLieuNhap.Controls.Add(Me.SalaryComponent)
        Me.pnDuLieuNhap.Controls.Add(Me.OrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.lblOrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.MonthlyChanging)
        Me.pnDuLieuNhap.Controls.Add(Me.Insurance)
        Me.pnDuLieuNhap.Controls.Add(Me.NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameEN)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1003, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblMonthlyChanging
        '
        Me.lblMonthlyChanging.BackColor = System.Drawing.Color.Transparent
        Me.lblMonthlyChanging.Location = New System.Drawing.Point(3, 59)
        Me.lblMonthlyChanging.Name = "lblMonthlyChanging"
        Me.lblMonthlyChanging.Size = New System.Drawing.Size(121, 19)
        Me.lblMonthlyChanging.TabIndex = 1220
        Me.lblMonthlyChanging.Text = "Thay đổi theo tháng"
        Me.lblMonthlyChanging.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInsurance
        '
        Me.lblInsurance.BackColor = System.Drawing.Color.Transparent
        Me.lblInsurance.Location = New System.Drawing.Point(3, 31)
        Me.lblInsurance.Name = "lblInsurance"
        Me.lblInsurance.Size = New System.Drawing.Size(121, 19)
        Me.lblInsurance.TabIndex = 1219
        Me.lblInsurance.Text = "Lương đóng BH"
        Me.lblInsurance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSalaryComponent
        '
        Me.lblSalaryComponent.BackColor = System.Drawing.Color.Transparent
        Me.lblSalaryComponent.Location = New System.Drawing.Point(3, 4)
        Me.lblSalaryComponent.Name = "lblSalaryComponent"
        Me.lblSalaryComponent.Size = New System.Drawing.Size(121, 19)
        Me.lblSalaryComponent.TabIndex = 1218
        Me.lblSalaryComponent.Text = "Mã thành phần lương"
        Me.lblSalaryComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SalaryComponent
        '
        Me.SalaryComponent.Location = New System.Drawing.Point(125, 4)
        Me.SalaryComponent.Name = "SalaryComponent"
        Me.SalaryComponent.Size = New System.Drawing.Size(168, 21)
        Me.SalaryComponent.TabIndex = 1
        '
        'OrderBy
        '
        Me.OrderBy.Location = New System.Drawing.Point(748, 6)
        Me.OrderBy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.OrderBy.Name = "OrderBy"
        Me.OrderBy.Size = New System.Drawing.Size(64, 21)
        Me.OrderBy.TabIndex = 13
        Me.OrderBy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblOrderBy
        '
        Me.lblOrderBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrderBy.Location = New System.Drawing.Point(644, 4)
        Me.lblOrderBy.Name = "lblOrderBy"
        Me.lblOrderBy.Size = New System.Drawing.Size(72, 23)
        Me.lblOrderBy.TabIndex = 1216
        Me.lblOrderBy.Text = "Số thứ tự"
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(644, 31)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(98, 19)
        Me.lblRemark.TabIndex = 1214
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(748, 31)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(248, 50)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'MonthlyChanging
        '
        Me.MonthlyChanging.Location = New System.Drawing.Point(149, 55)
        Me.MonthlyChanging.Name = "MonthlyChanging"
        Me.MonthlyChanging.Size = New System.Drawing.Size(130, 24)
        Me.MonthlyChanging.TabIndex = 5
        '
        'Insurance
        '
        Me.Insurance.Location = New System.Drawing.Point(149, 29)
        Me.Insurance.Name = "Insurance"
        Me.Insurance.Size = New System.Drawing.Size(104, 24)
        Me.Insurance.TabIndex = 3
        '
        'NameVN
        '
        Me.NameVN.Location = New System.Drawing.Point(392, 3)
        Me.NameVN.Name = "NameVN"
        Me.NameVN.Size = New System.Drawing.Size(240, 21)
        Me.NameVN.TabIndex = 7
        '
        'lblNameVN
        '
        Me.lblNameVN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameVN.Location = New System.Drawing.Point(303, 3)
        Me.lblNameVN.Name = "lblNameVN"
        Me.lblNameVN.Size = New System.Drawing.Size(74, 19)
        Me.lblNameVN.TabIndex = 318
        Me.lblNameVN.Text = "Tên (VN)"
        Me.lblNameVN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameKR
        '
        Me.NameKR.Location = New System.Drawing.Point(392, 50)
        Me.NameKR.Name = "NameKR"
        Me.NameKR.Size = New System.Drawing.Size(240, 21)
        Me.NameKR.TabIndex = 11
        '
        'lblNameKR
        '
        Me.lblNameKR.BackColor = System.Drawing.Color.Transparent
        Me.lblNameKR.Location = New System.Drawing.Point(304, 50)
        Me.lblNameKR.Name = "lblNameKR"
        Me.lblNameKR.Size = New System.Drawing.Size(74, 19)
        Me.lblNameKR.TabIndex = 317
        Me.lblNameKR.Text = "Tên (KR)"
        Me.lblNameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameEN
        '
        Me.NameEN.Location = New System.Drawing.Point(392, 26)
        Me.NameEN.Name = "NameEN"
        Me.NameEN.Size = New System.Drawing.Size(240, 21)
        Me.NameEN.TabIndex = 9
        '
        'lblNameEN
        '
        Me.lblNameEN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameEN.Location = New System.Drawing.Point(304, 26)
        Me.lblNameEN.Name = "lblNameEN"
        Me.lblNameEN.Size = New System.Drawing.Size(74, 19)
        Me.lblNameEN.TabIndex = 316
        Me.lblNameEN.Text = "Tên (EN)"
        Me.lblNameEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1015, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 1302
        Me.btnSave.Text = "Lưu"
        '
        'frmTaoDieuChinhDanhMucLuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 378)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_SalaryComponentCategory"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmTaoDieuChinhDanhMucLuong"
        Me.Text = "frmTaoDieuChinhDanhMucLuong"
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
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblMonthlyChanging As Label
    Friend WithEvents lblInsurance As Label
    Friend WithEvents lblSalaryComponent As Label
    Friend WithEvents SalaryComponent As TextBox
    Friend WithEvents OrderBy As NumericUpDown
    Friend WithEvents lblOrderBy As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents MonthlyChanging As CheckBox
    Friend WithEvents Insurance As CheckBox
    Friend WithEvents NameVN As TextBox
    Friend WithEvents lblNameVN As Label
    Friend WithEvents NameKR As TextBox
    Friend WithEvents lblNameKR As Label
    Friend WithEvents NameEN As TextBox
    Friend WithEvents lblNameEN As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
