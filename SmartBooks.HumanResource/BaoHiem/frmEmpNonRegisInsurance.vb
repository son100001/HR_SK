Imports WindowsControlLibrary
Public Class frmEmpNonRegisInsurance
    Inherits HRFORM
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblNam As Label
    Friend WithEvents CD As GroupBox
    Friend WithEvents rdbTheoLogicUnionFee As RadioButton
    Friend WithEvents rdbNotUnionFee As RadioButton
    Friend WithEvents rdbUnionFee As RadioButton
    Friend WithEvents BHTN As GroupBox
    Friend WithEvents rdbTheoLogicUnemploymentInsurance As RadioButton
    Friend WithEvents rdbNotUnemploymentInsurance As RadioButton
    Friend WithEvents rdbUnemploymentInsurance As RadioButton
    Friend WithEvents BHYT As GroupBox
    Friend WithEvents rdbTheoLogicHealthInsurance As RadioButton
    Friend WithEvents rdbNotHealthInsurance As RadioButton
    Friend WithEvents rdbHealthInsurance As RadioButton
    Friend WithEvents BHXH As GroupBox
    Friend WithEvents rdbTheoLogicSocialInsurance As RadioButton
    Friend WithEvents rdbNotSocialInsurance As RadioButton
    Friend WithEvents rdbSocialInsurance As RadioButton
    Friend WithEvents Nam As Year
    Friend WithEvents Thang As Month
    Friend WithEvents lblThang As Label
    Friend WithEvents Comment As RichTextBox
    Friend WithEvents lblComment As Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
        Me.lblNam = New System.Windows.Forms.Label()
        Me.CD = New System.Windows.Forms.GroupBox()
        Me.rdbTheoLogicUnionFee = New System.Windows.Forms.RadioButton()
        Me.rdbNotUnionFee = New System.Windows.Forms.RadioButton()
        Me.rdbUnionFee = New System.Windows.Forms.RadioButton()
        Me.BHTN = New System.Windows.Forms.GroupBox()
        Me.rdbTheoLogicUnemploymentInsurance = New System.Windows.Forms.RadioButton()
        Me.rdbNotUnemploymentInsurance = New System.Windows.Forms.RadioButton()
        Me.rdbUnemploymentInsurance = New System.Windows.Forms.RadioButton()
        Me.BHYT = New System.Windows.Forms.GroupBox()
        Me.rdbTheoLogicHealthInsurance = New System.Windows.Forms.RadioButton()
        Me.rdbNotHealthInsurance = New System.Windows.Forms.RadioButton()
        Me.rdbHealthInsurance = New System.Windows.Forms.RadioButton()
        Me.BHXH = New System.Windows.Forms.GroupBox()
        Me.rdbTheoLogicSocialInsurance = New System.Windows.Forms.RadioButton()
        Me.rdbNotSocialInsurance = New System.Windows.Forms.RadioButton()
        Me.rdbSocialInsurance = New System.Windows.Forms.RadioButton()
        Me.Nam = New WindowsControlLibrary.Year()
        Me.Thang = New WindowsControlLibrary.Month()
        Me.lblThang = New System.Windows.Forms.Label()
        Me.Comment = New System.Windows.Forms.RichTextBox()
        Me.lblComment = New System.Windows.Forms.Label()
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
        Me.CD.SuspendLayout()
        Me.BHTN.SuspendLayout()
        Me.BHYT.SuspendLayout()
        Me.BHXH.SuspendLayout()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 335)
        Me.PanelButton.Size = New System.Drawing.Size(1235, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1235, 335)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1233, 310)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 110)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1228, 198)
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
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1233, 108)
        Me.TableLayoutPanel2.TabIndex = 1307
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(222, 100)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(4, 55)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1227
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(4, 33)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(215, 20)
        Me.Employee_ID.TabIndex = 1225
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(7, 6)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(99, 23)
        Me.lblEmployee_ID.TabIndex = 1226
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblNam)
        Me.pnDuLieuNhap.Controls.Add(Me.CD)
        Me.pnDuLieuNhap.Controls.Add(Me.BHTN)
        Me.pnDuLieuNhap.Controls.Add(Me.BHYT)
        Me.pnDuLieuNhap.Controls.Add(Me.BHXH)
        Me.pnDuLieuNhap.Controls.Add(Me.Nam)
        Me.pnDuLieuNhap.Controls.Add(Me.Thang)
        Me.pnDuLieuNhap.Controls.Add(Me.lblThang)
        Me.pnDuLieuNhap.Controls.Add(Me.Comment)
        Me.pnDuLieuNhap.Controls.Add(Me.lblComment)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(233, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(917, 100)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblNam
        '
        Me.lblNam.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNam.Location = New System.Drawing.Point(10, 32)
        Me.lblNam.Name = "lblNam"
        Me.lblNam.Size = New System.Drawing.Size(64, 20)
        Me.lblNam.TabIndex = 1279
        Me.lblNam.Text = "Tháng"
        Me.lblNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CD
        '
        Me.CD.Controls.Add(Me.rdbTheoLogicUnionFee)
        Me.CD.Controls.Add(Me.rdbNotUnionFee)
        Me.CD.Controls.Add(Me.rdbUnionFee)
        Me.CD.Location = New System.Drawing.Point(603, 5)
        Me.CD.Name = "CD"
        Me.CD.Size = New System.Drawing.Size(154, 95)
        Me.CD.TabIndex = 27
        Me.CD.TabStop = False
        Me.CD.Text = "Công đoàn"
        '
        'rdbTheoLogicUnionFee
        '
        Me.rdbTheoLogicUnionFee.AutoSize = True
        Me.rdbTheoLogicUnionFee.Checked = True
        Me.rdbTheoLogicUnionFee.Location = New System.Drawing.Point(6, 65)
        Me.rdbTheoLogicUnionFee.Name = "rdbTheoLogicUnionFee"
        Me.rdbTheoLogicUnionFee.Size = New System.Drawing.Size(73, 17)
        Me.rdbTheoLogicUnionFee.TabIndex = 4
        Me.rdbTheoLogicUnionFee.TabStop = True
        Me.rdbTheoLogicUnionFee.Text = "Theo logic"
        Me.rdbTheoLogicUnionFee.UseVisualStyleBackColor = True
        '
        'rdbNotUnionFee
        '
        Me.rdbNotUnionFee.AutoSize = True
        Me.rdbNotUnionFee.Location = New System.Drawing.Point(6, 42)
        Me.rdbNotUnionFee.Name = "rdbNotUnionFee"
        Me.rdbNotUnionFee.Size = New System.Drawing.Size(82, 17)
        Me.rdbNotUnionFee.TabIndex = 1
        Me.rdbNotUnionFee.Text = "Không đóng"
        Me.rdbNotUnionFee.UseVisualStyleBackColor = True
        '
        'rdbUnionFee
        '
        Me.rdbUnionFee.AutoSize = True
        Me.rdbUnionFee.Location = New System.Drawing.Point(6, 19)
        Me.rdbUnionFee.Name = "rdbUnionFee"
        Me.rdbUnionFee.Size = New System.Drawing.Size(51, 17)
        Me.rdbUnionFee.TabIndex = 0
        Me.rdbUnionFee.Text = "Đóng"
        Me.rdbUnionFee.UseVisualStyleBackColor = True
        '
        'BHTN
        '
        Me.BHTN.Controls.Add(Me.rdbTheoLogicUnemploymentInsurance)
        Me.BHTN.Controls.Add(Me.rdbNotUnemploymentInsurance)
        Me.BHTN.Controls.Add(Me.rdbUnemploymentInsurance)
        Me.BHTN.Location = New System.Drawing.Point(430, 6)
        Me.BHTN.Name = "BHTN"
        Me.BHTN.Size = New System.Drawing.Size(167, 93)
        Me.BHTN.TabIndex = 21
        Me.BHTN.TabStop = False
        Me.BHTN.Text = "BH Thất nghiệp"
        '
        'rdbTheoLogicUnemploymentInsurance
        '
        Me.rdbTheoLogicUnemploymentInsurance.AutoSize = True
        Me.rdbTheoLogicUnemploymentInsurance.Checked = True
        Me.rdbTheoLogicUnemploymentInsurance.Location = New System.Drawing.Point(6, 67)
        Me.rdbTheoLogicUnemploymentInsurance.Name = "rdbTheoLogicUnemploymentInsurance"
        Me.rdbTheoLogicUnemploymentInsurance.Size = New System.Drawing.Size(73, 17)
        Me.rdbTheoLogicUnemploymentInsurance.TabIndex = 3
        Me.rdbTheoLogicUnemploymentInsurance.TabStop = True
        Me.rdbTheoLogicUnemploymentInsurance.Text = "Theo logic"
        Me.rdbTheoLogicUnemploymentInsurance.UseVisualStyleBackColor = True
        '
        'rdbNotUnemploymentInsurance
        '
        Me.rdbNotUnemploymentInsurance.AutoSize = True
        Me.rdbNotUnemploymentInsurance.Location = New System.Drawing.Point(6, 42)
        Me.rdbNotUnemploymentInsurance.Name = "rdbNotUnemploymentInsurance"
        Me.rdbNotUnemploymentInsurance.Size = New System.Drawing.Size(82, 17)
        Me.rdbNotUnemploymentInsurance.TabIndex = 1
        Me.rdbNotUnemploymentInsurance.Text = "Không đóng"
        Me.rdbNotUnemploymentInsurance.UseVisualStyleBackColor = True
        '
        'rdbUnemploymentInsurance
        '
        Me.rdbUnemploymentInsurance.AutoSize = True
        Me.rdbUnemploymentInsurance.Location = New System.Drawing.Point(6, 19)
        Me.rdbUnemploymentInsurance.Name = "rdbUnemploymentInsurance"
        Me.rdbUnemploymentInsurance.Size = New System.Drawing.Size(51, 17)
        Me.rdbUnemploymentInsurance.TabIndex = 0
        Me.rdbUnemploymentInsurance.Text = "Đóng"
        Me.rdbUnemploymentInsurance.UseVisualStyleBackColor = True
        '
        'BHYT
        '
        Me.BHYT.Controls.Add(Me.rdbTheoLogicHealthInsurance)
        Me.BHYT.Controls.Add(Me.rdbNotHealthInsurance)
        Me.BHYT.Controls.Add(Me.rdbHealthInsurance)
        Me.BHYT.Location = New System.Drawing.Point(295, 5)
        Me.BHYT.Name = "BHYT"
        Me.BHYT.Size = New System.Drawing.Size(129, 93)
        Me.BHYT.TabIndex = 15
        Me.BHYT.TabStop = False
        Me.BHYT.Text = "BH Y tế"
        '
        'rdbTheoLogicHealthInsurance
        '
        Me.rdbTheoLogicHealthInsurance.AutoSize = True
        Me.rdbTheoLogicHealthInsurance.Checked = True
        Me.rdbTheoLogicHealthInsurance.Location = New System.Drawing.Point(6, 67)
        Me.rdbTheoLogicHealthInsurance.Name = "rdbTheoLogicHealthInsurance"
        Me.rdbTheoLogicHealthInsurance.Size = New System.Drawing.Size(73, 17)
        Me.rdbTheoLogicHealthInsurance.TabIndex = 3
        Me.rdbTheoLogicHealthInsurance.TabStop = True
        Me.rdbTheoLogicHealthInsurance.Text = "Theo logic"
        Me.rdbTheoLogicHealthInsurance.UseVisualStyleBackColor = True
        '
        'rdbNotHealthInsurance
        '
        Me.rdbNotHealthInsurance.AutoSize = True
        Me.rdbNotHealthInsurance.Location = New System.Drawing.Point(6, 42)
        Me.rdbNotHealthInsurance.Name = "rdbNotHealthInsurance"
        Me.rdbNotHealthInsurance.Size = New System.Drawing.Size(82, 17)
        Me.rdbNotHealthInsurance.TabIndex = 1
        Me.rdbNotHealthInsurance.Text = "Không đóng"
        Me.rdbNotHealthInsurance.UseVisualStyleBackColor = True
        '
        'rdbHealthInsurance
        '
        Me.rdbHealthInsurance.AutoSize = True
        Me.rdbHealthInsurance.Location = New System.Drawing.Point(6, 19)
        Me.rdbHealthInsurance.Name = "rdbHealthInsurance"
        Me.rdbHealthInsurance.Size = New System.Drawing.Size(51, 17)
        Me.rdbHealthInsurance.TabIndex = 0
        Me.rdbHealthInsurance.Text = "Đóng"
        Me.rdbHealthInsurance.UseVisualStyleBackColor = True
        '
        'BHXH
        '
        Me.BHXH.Controls.Add(Me.rdbTheoLogicSocialInsurance)
        Me.BHXH.Controls.Add(Me.rdbNotSocialInsurance)
        Me.BHXH.Controls.Add(Me.rdbSocialInsurance)
        Me.BHXH.Location = New System.Drawing.Point(163, 5)
        Me.BHXH.Name = "BHXH"
        Me.BHXH.Size = New System.Drawing.Size(126, 91)
        Me.BHXH.TabIndex = 9
        Me.BHXH.TabStop = False
        Me.BHXH.Text = "BH Xã hội"
        '
        'rdbTheoLogicSocialInsurance
        '
        Me.rdbTheoLogicSocialInsurance.AutoSize = True
        Me.rdbTheoLogicSocialInsurance.Checked = True
        Me.rdbTheoLogicSocialInsurance.Location = New System.Drawing.Point(6, 65)
        Me.rdbTheoLogicSocialInsurance.Name = "rdbTheoLogicSocialInsurance"
        Me.rdbTheoLogicSocialInsurance.Size = New System.Drawing.Size(73, 17)
        Me.rdbTheoLogicSocialInsurance.TabIndex = 2
        Me.rdbTheoLogicSocialInsurance.TabStop = True
        Me.rdbTheoLogicSocialInsurance.Text = "Theo logic"
        Me.rdbTheoLogicSocialInsurance.UseVisualStyleBackColor = True
        '
        'rdbNotSocialInsurance
        '
        Me.rdbNotSocialInsurance.AutoSize = True
        Me.rdbNotSocialInsurance.Location = New System.Drawing.Point(6, 42)
        Me.rdbNotSocialInsurance.Name = "rdbNotSocialInsurance"
        Me.rdbNotSocialInsurance.Size = New System.Drawing.Size(82, 17)
        Me.rdbNotSocialInsurance.TabIndex = 1
        Me.rdbNotSocialInsurance.Text = "Không đóng"
        Me.rdbNotSocialInsurance.UseVisualStyleBackColor = True
        '
        'rdbSocialInsurance
        '
        Me.rdbSocialInsurance.AutoSize = True
        Me.rdbSocialInsurance.Location = New System.Drawing.Point(6, 19)
        Me.rdbSocialInsurance.Name = "rdbSocialInsurance"
        Me.rdbSocialInsurance.Size = New System.Drawing.Size(51, 17)
        Me.rdbSocialInsurance.TabIndex = 0
        Me.rdbSocialInsurance.Text = "Đóng"
        Me.rdbSocialInsurance.UseVisualStyleBackColor = True
        '
        'Nam
        '
        Me.Nam.Location = New System.Drawing.Point(80, 32)
        Me.Nam.Name = "Nam"
        Me.Nam.Size = New System.Drawing.Size(56, 20)
        Me.Nam.TabIndex = 7
        '
        'Thang
        '
        Me.Thang.Location = New System.Drawing.Point(80, 6)
        Me.Thang.Name = "Thang"
        Me.Thang.Size = New System.Drawing.Size(40, 20)
        Me.Thang.TabIndex = 5
        '
        'lblThang
        '
        Me.lblThang.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThang.Location = New System.Drawing.Point(10, 6)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(64, 20)
        Me.lblThang.TabIndex = 1278
        Me.lblThang.Text = "Tháng"
        Me.lblThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Comment
        '
        Me.Comment.Location = New System.Drawing.Point(790, 23)
        Me.Comment.Name = "Comment"
        Me.Comment.Size = New System.Drawing.Size(117, 62)
        Me.Comment.TabIndex = 29
        Me.Comment.Text = ""
        '
        'lblComment
        '
        Me.lblComment.BackColor = System.Drawing.SystemColors.Control
        Me.lblComment.Location = New System.Drawing.Point(787, 4)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(64, 16)
        Me.lblComment.TabIndex = 1271
        Me.lblComment.Text = "Ghi chú"
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1157, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1327
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmEmpNonRegisInsurance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1235, 386)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = ""
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_EmpNonRegisInsuranceAndUnion"
        Me.HRFORM_TableName = "HR_EmpNonRegisInsuranceAndUnion"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmEmpNonRegisInsurance"
        Me.Text = "frmEmpNonRegisInsurance"
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
        Me.CD.ResumeLayout(False)
        Me.CD.PerformLayout()
        Me.BHTN.ResumeLayout(False)
        Me.BHTN.PerformLayout()
        Me.BHYT.ResumeLayout(False)
        Me.BHYT.PerformLayout()
        Me.BHXH.ResumeLayout(False)
        Me.BHXH.PerformLayout()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub frmEmpNonRegisInsurance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Private Function Save(ByVal Employee_ID As String, ByVal thang As Integer, ByVal nam As Integer, ByVal SocialInsurance As String, ByVal HealthInsurance As String, ByVal UnemploymentInsurance As String, ByVal UnionFee As String, ByVal Comment As String) As Boolean
        Dim tabCheck As DataTable
        tabCheck = kn.ReadData("exec usp_InsertUpdateHR_EmpNonRegisInsuranceAndUnion N'" + Employee_ID + "'," + thang.ToString + "," + nam.ToString + "," + SocialInsurance + "," + HealthInsurance + "," + UnemploymentInsurance + "," + UnionFee + ",N'" + Comment + "',N'" + obj.UserName + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", "Table")
        If Not IsNothing(tabCheck) Then
            If tabCheck.Rows(0)("ThongBao") <> "" Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            Return False
        End If
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If tvcn.CheckErrorProvider(XtraTabControl1, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Save(Employee_ID.EditValue.Trim, CInt(Thang.Text), CInt(Nam.Text), IIf(rdbTheoLogicSocialInsurance.Checked = True, "null", IIf(rdbSocialInsurance.Checked = True, "1", "0")), IIf(rdbTheoLogicHealthInsurance.Checked = True, "null", IIf(rdbHealthInsurance.Checked = True, "1", "0")), IIf(rdbTheoLogicUnemploymentInsurance.Checked = True, "null", IIf(rdbUnemploymentInsurance.Checked = True, "1", "0")), IIf(rdbTheoLogicUnionFee.Checked = True, "null", IIf(rdbUnionFee.Checked = True, "1", "0")), Comment.Text.Trim) = True Then
                Search()
            End If
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "[dbo].[sp_BangKhongDongBHCD] '" + Thang.Text + "','" + Nam.Text + "','" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    Private Sub Gridex1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub
End Class
