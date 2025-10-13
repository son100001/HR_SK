Imports WindowsControlLibrary
 

Public Class frmFactory
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents JobCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblJobCode As Label
    Friend WithEvents lblOrderBy As Label
    Friend WithEvents OrderBy As NumericUpDown
    Friend WithEvents AnnualLeaveDays As TextBox
    Friend WithEvents lblAnnualLeaveDays As Label
    Friend WithEvents DiaChi As TextBox
    Friend WithEvents lblDiaChi As Label
    Friend WithEvents NameEN As TextBox
    Friend WithEvents NameVN As TextBox
    Friend WithEvents NameKR As TextBox
    Friend WithEvents lblNameVN As Label
    Friend WithEvents lblNameEN As Label
    Friend WithEvents Factory_ID As TextBox
    Friend WithEvents lblFactory_ID As Label
    Friend WithEvents lblNameKR As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactory))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.JobCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblJobCode = New System.Windows.Forms.Label()
        Me.lblOrderBy = New System.Windows.Forms.Label()
        Me.OrderBy = New System.Windows.Forms.NumericUpDown()
        Me.AnnualLeaveDays = New System.Windows.Forms.TextBox()
        Me.lblAnnualLeaveDays = New System.Windows.Forms.Label()
        Me.DiaChi = New System.Windows.Forms.TextBox()
        Me.lblDiaChi = New System.Windows.Forms.Label()
        Me.NameEN = New System.Windows.Forms.TextBox()
        Me.NameVN = New System.Windows.Forms.TextBox()
        Me.NameKR = New System.Windows.Forms.TextBox()
        Me.lblNameVN = New System.Windows.Forms.Label()
        Me.lblNameEN = New System.Windows.Forms.Label()
        Me.Factory_ID = New System.Windows.Forms.TextBox()
        Me.lblFactory_ID = New System.Windows.Forms.Label()
        Me.lblNameKR = New System.Windows.Forms.Label()
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
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 350)
        Me.PanelButton.Size = New System.Drawing.Size(1274, 52)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "")
        Me.ImageList1.Images.SetKeyName(13, "")
        Me.ImageList1.Images.SetKeyName(14, "")
        Me.ImageList1.Images.SetKeyName(15, "")
        Me.ImageList1.Images.SetKeyName(16, "")
        Me.ImageList1.Images.SetKeyName(17, "")
        Me.ImageList1.Images.SetKeyName(18, "")
        Me.ImageList1.Images.SetKeyName(19, "")
        Me.ImageList1.Images.SetKeyName(20, "")
        Me.ImageList1.Images.SetKeyName(21, "")
        Me.ImageList1.Images.SetKeyName(22, "")
        Me.ImageList1.Images.SetKeyName(23, "")
        Me.ImageList1.Images.SetKeyName(24, "")
        Me.ImageList1.Images.SetKeyName(25, "")
        Me.ImageList1.Images.SetKeyName(26, "")
        Me.ImageList1.Images.SetKeyName(27, "")
        Me.ImageList1.Images.SetKeyName(28, "")
        Me.ImageList1.Images.SetKeyName(29, "")
        Me.ImageList1.Images.SetKeyName(30, "")
        Me.ImageList1.Images.SetKeyName(31, "")
        Me.ImageList1.Images.SetKeyName(32, "")
        Me.ImageList1.Images.SetKeyName(33, "")
        Me.ImageList1.Images.SetKeyName(34, "")
        Me.ImageList1.Images.SetKeyName(35, "")
        Me.ImageList1.Images.SetKeyName(36, "")
        Me.ImageList1.Images.SetKeyName(37, "")
        Me.ImageList1.Images.SetKeyName(38, "")
        Me.ImageList1.Images.SetKeyName(39, "")
        Me.ImageList1.Images.SetKeyName(40, "")
        Me.ImageList1.Images.SetKeyName(41, "")
        Me.ImageList1.Images.SetKeyName(42, "")
        Me.ImageList1.Images.SetKeyName(43, "")
        Me.ImageList1.Images.SetKeyName(44, "")
        Me.ImageList1.Images.SetKeyName(45, "")
        Me.ImageList1.Images.SetKeyName(46, "")
        Me.ImageList1.Images.SetKeyName(47, "")
        Me.ImageList1.Images.SetKeyName(48, "")
        Me.ImageList1.Images.SetKeyName(49, "")
        Me.ImageList1.Images.SetKeyName(50, "")
        Me.ImageList1.Images.SetKeyName(51, "")
        Me.ImageList1.Images.SetKeyName(52, "")
        Me.ImageList1.Images.SetKeyName(53, "")
        Me.ImageList1.Images.SetKeyName(54, "")
        Me.ImageList1.Images.SetKeyName(55, "")
        Me.ImageList1.Images.SetKeyName(56, "")
        Me.ImageList1.Images.SetKeyName(57, "")
        '
        'flag
        '
        Me.flag.ImageStream = CType(resources.GetObject("flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.flag.TransparentColor = System.Drawing.Color.Transparent
        Me.flag.Images.SetKeyName(0, "")
        Me.flag.Images.SetKeyName(1, "")
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1274, 350)
        Me.XtraTabControl1.TabIndex = 1317
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1272, 325)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 91)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1269, 232)
        Me.GridControl1.TabIndex = 1318
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1272, 85)
        Me.TableLayoutPanel3.TabIndex = 1317
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.JobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblJobCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblOrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.OrderBy)
        Me.pnDuLieuNhap.Controls.Add(Me.AnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAnnualLeaveDays)
        Me.pnDuLieuNhap.Controls.Add(Me.DiaChi)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDiaChi)
        Me.pnDuLieuNhap.Controls.Add(Me.NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.Factory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFactory_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameKR)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1079, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'JobCode
        '
        Me.JobCode.Location = New System.Drawing.Point(857, 5)
        Me.JobCode.Name = "JobCode"
        Me.JobCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.JobCode.Size = New System.Drawing.Size(183, 20)
        Me.JobCode.TabIndex = 15
        '
        'lblJobCode
        '
        Me.lblJobCode.BackColor = System.Drawing.Color.Transparent
        Me.lblJobCode.Location = New System.Drawing.Point(780, 5)
        Me.lblJobCode.Name = "lblJobCode"
        Me.lblJobCode.Size = New System.Drawing.Size(101, 19)
        Me.lblJobCode.TabIndex = 1276
        Me.lblJobCode.Text = "Job code"
        Me.lblJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOrderBy
        '
        Me.lblOrderBy.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderBy.Location = New System.Drawing.Point(621, 50)
        Me.lblOrderBy.Name = "lblOrderBy"
        Me.lblOrderBy.Size = New System.Drawing.Size(74, 19)
        Me.lblOrderBy.TabIndex = 1272
        Me.lblOrderBy.Text = "Thứ tự"
        Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OrderBy
        '
        Me.OrderBy.Location = New System.Drawing.Point(704, 50)
        Me.OrderBy.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.OrderBy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.OrderBy.Name = "OrderBy"
        Me.OrderBy.Size = New System.Drawing.Size(64, 21)
        Me.OrderBy.TabIndex = 13
        Me.OrderBy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'AnnualLeaveDays
        '
        Me.AnnualLeaveDays.Location = New System.Drawing.Point(527, 50)
        Me.AnnualLeaveDays.Name = "AnnualLeaveDays"
        Me.AnnualLeaveDays.Size = New System.Drawing.Size(56, 21)
        Me.AnnualLeaveDays.TabIndex = 11
        '
        'lblAnnualLeaveDays
        '
        Me.lblAnnualLeaveDays.BackColor = System.Drawing.Color.Transparent
        Me.lblAnnualLeaveDays.Location = New System.Drawing.Point(379, 50)
        Me.lblAnnualLeaveDays.Name = "lblAnnualLeaveDays"
        Me.lblAnnualLeaveDays.Size = New System.Drawing.Size(141, 19)
        Me.lblAnnualLeaveDays.TabIndex = 1270
        Me.lblAnnualLeaveDays.Text = "Số ngày phép năm"
        Me.lblAnnualLeaveDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DiaChi
        '
        Me.DiaChi.Location = New System.Drawing.Point(129, 50)
        Me.DiaChi.Name = "DiaChi"
        Me.DiaChi.Size = New System.Drawing.Size(240, 21)
        Me.DiaChi.TabIndex = 9
        '
        'lblDiaChi
        '
        Me.lblDiaChi.BackColor = System.Drawing.Color.Transparent
        Me.lblDiaChi.Location = New System.Drawing.Point(7, 51)
        Me.lblDiaChi.Name = "lblDiaChi"
        Me.lblDiaChi.Size = New System.Drawing.Size(116, 19)
        Me.lblDiaChi.TabIndex = 312
        Me.lblDiaChi.Text = "Dịa chỉ"
        Me.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameEN
        '
        Me.NameEN.Location = New System.Drawing.Point(528, 4)
        Me.NameEN.Name = "NameEN"
        Me.NameEN.Size = New System.Drawing.Size(240, 21)
        Me.NameEN.TabIndex = 5
        '
        'NameVN
        '
        Me.NameVN.Location = New System.Drawing.Point(128, 26)
        Me.NameVN.Name = "NameVN"
        Me.NameVN.Size = New System.Drawing.Size(240, 21)
        Me.NameVN.TabIndex = 3
        '
        'NameKR
        '
        Me.NameKR.Location = New System.Drawing.Point(528, 25)
        Me.NameKR.Name = "NameKR"
        Me.NameKR.Size = New System.Drawing.Size(240, 21)
        Me.NameKR.TabIndex = 7
        '
        'lblNameVN
        '
        Me.lblNameVN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameVN.Location = New System.Drawing.Point(8, 26)
        Me.lblNameVN.Name = "lblNameVN"
        Me.lblNameVN.Size = New System.Drawing.Size(109, 19)
        Me.lblNameVN.TabIndex = 304
        Me.lblNameVN.Text = "NameVN"
        Me.lblNameVN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNameEN
        '
        Me.lblNameEN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameEN.Location = New System.Drawing.Point(380, 4)
        Me.lblNameEN.Name = "lblNameEN"
        Me.lblNameEN.Size = New System.Drawing.Size(116, 19)
        Me.lblNameEN.TabIndex = 309
        Me.lblNameEN.Text = "NameEN"
        Me.lblNameEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Factory_ID
        '
        Me.Factory_ID.Location = New System.Drawing.Point(128, 3)
        Me.Factory_ID.Name = "Factory_ID"
        Me.Factory_ID.Size = New System.Drawing.Size(240, 21)
        Me.Factory_ID.TabIndex = 1
        '
        'lblFactory_ID
        '
        Me.lblFactory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblFactory_ID.Location = New System.Drawing.Point(7, 4)
        Me.lblFactory_ID.Name = "lblFactory_ID"
        Me.lblFactory_ID.Size = New System.Drawing.Size(114, 19)
        Me.lblFactory_ID.TabIndex = 302
        Me.lblFactory_ID.Text = "Factory_ID"
        Me.lblFactory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNameKR
        '
        Me.lblNameKR.BackColor = System.Drawing.Color.Transparent
        Me.lblNameKR.Location = New System.Drawing.Point(380, 25)
        Me.lblNameKR.Name = "lblNameKR"
        Me.lblNameKR.Size = New System.Drawing.Size(116, 19)
        Me.lblNameKR.TabIndex = 310
        Me.lblNameKR.Text = "NameKR"
        Me.lblNameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1091, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 1300
        Me.btnSave.Text = "Lưu"
        '
        'frmFactory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1274, 402)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_Factory"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmFactory"
        Me.Text = "frmFactory"
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
        CType(Me.JobCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Gridex1_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub frmFactory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'JobCode1.DataSource = kn.ReadData("exec sp_BangDanhMucJobCode ", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(JobCode, kn.ReadData("select JobCode as Code, Name" + obj.Lan + " as Name from HR_JobCodeCategory", "table"))
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Search()
        Dim QR As String = "select * from HR_Factory"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        Factory_ID.Select()
        Search()
    End Sub
End Class
