<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBaoCaoBaoHiem
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
        Me.LoaiKhaiBao = New DevExpress.XtraEditors.LookUpEdit()
        Me.PhuongAn = New DevExpress.XtraEditors.LookUpEdit()
        Me.NgayTangGiam = New DevExpress.XtraEditors.DateEdit()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblNgayTangGiam = New System.Windows.Forms.Label()
        Me.lblPhuongAn = New System.Windows.Forms.Label()
        Me.lblInsuranceSalary = New System.Windows.Forms.Label()
        Me.Month_ = New WindowsControlLibrary.Month()
        Me.InsuranceSalary = New System.Windows.Forms.TextBox()
        Me.Year_ = New WindowsControlLibrary.Year()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblLoaiKhaiBao = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.InsertSource = New System.Windows.Forms.TextBox()
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
        CType(Me.LoaiKhaiBao.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhuongAn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayTangGiam.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayTangGiam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 428)
        Me.PanelButton.Size = New System.Drawing.Size(1313, 47)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1313, 428)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1311, 403)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 87)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1307, 313)
        Me.GridControl1.TabIndex = 1349
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1311, 85)
        Me.TableLayoutPanel2.TabIndex = 1348
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(246, 75)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(8, 52)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1277
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(8, 26)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(229, 20)
        Me.Employee_ID.TabIndex = 1
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(5, 4)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(102, 23)
        Me.lblEmployee_ID.TabIndex = 1219
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.InsertSource)
        Me.pnDuLieuNhap.Controls.Add(Me.LoaiKhaiBao)
        Me.pnDuLieuNhap.Controls.Add(Me.PhuongAn)
        Me.pnDuLieuNhap.Controls.Add(Me.NgayTangGiam)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNgayTangGiam)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPhuongAn)
        Me.pnDuLieuNhap.Controls.Add(Me.lblInsuranceSalary)
        Me.pnDuLieuNhap.Controls.Add(Me.Month_)
        Me.pnDuLieuNhap.Controls.Add(Me.InsuranceSalary)
        Me.pnDuLieuNhap.Controls.Add(Me.Year_)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMonth)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLoaiKhaiBao)
        Me.pnDuLieuNhap.Controls.Add(Me.lblYear)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(257, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(978, 77)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'LoaiKhaiBao
        '
        Me.LoaiKhaiBao.Location = New System.Drawing.Point(293, 40)
        Me.LoaiKhaiBao.Name = "LoaiKhaiBao"
        Me.LoaiKhaiBao.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LoaiKhaiBao.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LoaiKhaiBao.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LoaiKhaiBao.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LoaiKhaiBao.Size = New System.Drawing.Size(176, 20)
        Me.LoaiKhaiBao.TabIndex = 1350
        '
        'PhuongAn
        '
        Me.PhuongAn.Location = New System.Drawing.Point(293, 14)
        Me.PhuongAn.Name = "PhuongAn"
        Me.PhuongAn.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.PhuongAn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PhuongAn.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.PhuongAn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.PhuongAn.Size = New System.Drawing.Size(176, 20)
        Me.PhuongAn.TabIndex = 1349
        '
        'NgayTangGiam
        '
        Me.NgayTangGiam.EditValue = Nothing
        Me.NgayTangGiam.Location = New System.Drawing.Point(651, 42)
        Me.NgayTangGiam.Name = "NgayTangGiam"
        Me.NgayTangGiam.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayTangGiam.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayTangGiam.Properties.DisplayFormat.FormatString = ""
        Me.NgayTangGiam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayTangGiam.Properties.EditFormat.FormatString = ""
        Me.NgayTangGiam.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayTangGiam.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.NgayTangGiam.Properties.MaskSettings.Set("mask", "d")
        Me.NgayTangGiam.Properties.UseMaskAsDisplayFormat = True
        Me.NgayTangGiam.Size = New System.Drawing.Size(140, 20)
        Me.NgayTangGiam.TabIndex = 1348
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(800, 26)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(175, 44)
        Me.Remark.TabIndex = 1336
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(797, 7)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 16)
        Me.lblRemark.TabIndex = 1339
        Me.lblRemark.Text = "Ghi chú"
        '
        'lblNgayTangGiam
        '
        Me.lblNgayTangGiam.BackColor = System.Drawing.Color.Transparent
        Me.lblNgayTangGiam.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayTangGiam.Location = New System.Drawing.Point(475, 42)
        Me.lblNgayTangGiam.Name = "lblNgayTangGiam"
        Me.lblNgayTangGiam.Size = New System.Drawing.Size(170, 20)
        Me.lblNgayTangGiam.TabIndex = 1347
        Me.lblNgayTangGiam.Text = "Ngày báo"
        Me.lblNgayTangGiam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPhuongAn
        '
        Me.lblPhuongAn.BackColor = System.Drawing.Color.Transparent
        Me.lblPhuongAn.Location = New System.Drawing.Point(157, 13)
        Me.lblPhuongAn.Name = "lblPhuongAn"
        Me.lblPhuongAn.Size = New System.Drawing.Size(185, 18)
        Me.lblPhuongAn.TabIndex = 1340
        Me.lblPhuongAn.Text = "Phương án"
        '
        'lblInsuranceSalary
        '
        Me.lblInsuranceSalary.BackColor = System.Drawing.Color.Transparent
        Me.lblInsuranceSalary.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsuranceSalary.Location = New System.Drawing.Point(475, 13)
        Me.lblInsuranceSalary.Name = "lblInsuranceSalary"
        Me.lblInsuranceSalary.Size = New System.Drawing.Size(170, 20)
        Me.lblInsuranceSalary.TabIndex = 1346
        Me.lblInsuranceSalary.Text = "Lương BH"
        Me.lblInsuranceSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Month_
        '
        Me.Month_.Location = New System.Drawing.Point(85, 13)
        Me.Month_.Name = "Month_"
        Me.Month_.Size = New System.Drawing.Size(40, 20)
        Me.Month_.TabIndex = 1330
        '
        'InsuranceSalary
        '
        Me.InsuranceSalary.Location = New System.Drawing.Point(651, 15)
        Me.InsuranceSalary.Name = "InsuranceSalary"
        Me.InsuranceSalary.Size = New System.Drawing.Size(140, 21)
        Me.InsuranceSalary.TabIndex = 1334
        '
        'Year_
        '
        Me.Year_.Location = New System.Drawing.Point(85, 36)
        Me.Year_.Name = "Year_"
        Me.Year_.Size = New System.Drawing.Size(56, 20)
        Me.Year_.TabIndex = 1331
        '
        'lblMonth
        '
        Me.lblMonth.BackColor = System.Drawing.Color.Transparent
        Me.lblMonth.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.Location = New System.Drawing.Point(12, 11)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(66, 20)
        Me.lblMonth.TabIndex = 1343
        Me.lblMonth.Text = "Tháng"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoaiKhaiBao
        '
        Me.lblLoaiKhaiBao.BackColor = System.Drawing.Color.Transparent
        Me.lblLoaiKhaiBao.Location = New System.Drawing.Point(157, 39)
        Me.lblLoaiKhaiBao.Name = "lblLoaiKhaiBao"
        Me.lblLoaiKhaiBao.Size = New System.Drawing.Size(185, 18)
        Me.lblLoaiKhaiBao.TabIndex = 1345
        Me.lblLoaiKhaiBao.Text = "Loại khai báo"
        '
        'lblYear
        '
        Me.lblYear.BackColor = System.Drawing.Color.Transparent
        Me.lblYear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.Location = New System.Drawing.Point(12, 37)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(66, 20)
        Me.lblYear.TabIndex = 1344
        Me.lblYear.Text = "Năm"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1242, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Lưu"
        '
        'InsertSource
        '
        Me.InsertSource.Location = New System.Drawing.Point(867, 2)
        Me.InsertSource.Name = "InsertSource"
        Me.InsertSource.Size = New System.Drawing.Size(66, 21)
        Me.InsertSource.TabIndex = 1351
        Me.InsertSource.Text = "NhapTay"
        Me.InsertSource.Visible = False
        '
        'frmBaoCaoBaoHiem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1313, 475)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_IncreaseDecreaseInsurance"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_IncreaseDecreaseInsurance"
        Me.HRFORM_TableName = "HR_IncreaseDecreaseInsurance"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmBaoCaoBaoHiem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBaoCaoBaoHiem"
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
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.LoaiKhaiBao.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhuongAn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayTangGiam.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayTangGiam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblNgayTangGiam As Label
    Friend WithEvents lblInsuranceSalary As Label
    Friend WithEvents InsuranceSalary As TextBox
    Friend WithEvents lblLoaiKhaiBao As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents Year_ As WindowsControlLibrary.Year
    Friend WithEvents Month_ As WindowsControlLibrary.Month
    Friend WithEvents lblPhuongAn As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NgayTangGiam As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LoaiKhaiBao As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PhuongAn As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents InsertSource As TextBox
End Class
