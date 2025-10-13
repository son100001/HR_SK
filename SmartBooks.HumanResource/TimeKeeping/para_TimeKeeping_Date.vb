Imports WindowsControlLibrary
Imports VBReport
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Imports System.Text.RegularExpressions
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class para_TimeKeeping_Date
    Inherits HRFORM
    Dim tabAccessTime, tabMaxOverTime As DataTable
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As GridControl
    Friend WithEvents GridView1 As Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents Employee_ID As LookUpEdit
    Friend WithEvents btnTinhCong As SimpleButton
    Friend WithEvents btnSearch As SimpleButton
    Friend WithEvents cbTypeOfReport As CheckBox
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents MaCong As LookUpEdit
    Friend WithEvents InsertSource As TextBox
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblMaCong As Label
    Friend WithEvents wt As TextBox
    Friend WithEvents lblNgay As Label
    Friend WithEvents lblwt As Label
    Friend WithEvents lblGhiChu As Label
    Friend WithEvents Ngay As DateEdit
    Friend WithEvents TimeOut_KH As DateEdit
    Friend WithEvents TimeIn_KH As DateEdit
    Friend WithEvents pnLuu As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLuuDuLieuQuet As SimpleButton
    Friend WithEvents CongDiff As CheckBox
    Friend WithEvents CongDM As CheckBox
    Friend WithEvents CongGoc As CheckBox
    Friend WithEvents btnSave As SimpleButton
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
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents ds As SmartBooks.BusinessLogic.SmartData
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ctmBangCong As System.Windows.Forms.ContextMenu
    Friend WithEvents mi_Loc As System.Windows.Forms.MenuItem
    Friend WithEvents mi_HuyLoc As System.Windows.Forms.MenuItem
    Friend WithEvents mi_HuyLocToanBo As System.Windows.Forms.MenuItem
    Friend WithEvents mi_ThemGioCongNgoaiLe As System.Windows.Forms.MenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdbNhapTuDong As RadioButton
    Friend WithEvents rdbNhapTheoDungGioCa As RadioButton
    Friend WithEvents lblShiftName As Label
    Friend WithEvents lblReason As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark1 As RichTextBox
    Public WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents rdbSuaDuLieuQuet As RadioButton
    Friend WithEvents rdbSuaCa As RadioButton
    Friend WithEvents pnLuaChonSua As Panel
    Friend WithEvents pnSuaGioQuet As Panel
    Friend WithEvents lblAccessTime As Label
    Friend WithEvents lblInOutStatus As Label
    Friend WithEvents pnLyDoGhiChu As Panel
    Friend WithEvents pnSuaCa As Panel
    Friend WithEvents pnNhapLuu As Panel
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents rdbNhapTheoGioNhap As RadioButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(para_TimeKeeping_Date))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnLuaChonSua = New System.Windows.Forms.Panel()
        Me.rdbSuaDuLieuQuet = New System.Windows.Forms.RadioButton()
        Me.rdbSuaCa = New System.Windows.Forms.RadioButton()
        Me.pnSuaGioQuet = New System.Windows.Forms.Panel()
        Me.rdbNhapTheoGioNhap = New System.Windows.Forms.RadioButton()
        Me.lblAccessTime = New System.Windows.Forms.Label()
        Me.lblInOutStatus = New System.Windows.Forms.Label()
        Me.rdbNhapTuDong = New System.Windows.Forms.RadioButton()
        Me.rdbNhapTheoDungGioCa = New System.Windows.Forms.RadioButton()
        Me.pnSuaCa = New System.Windows.Forms.Panel()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.pnLyDoGhiChu = New System.Windows.Forms.Panel()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark1 = New System.Windows.Forms.RichTextBox()
        Me.pnNhapLuu = New System.Windows.Forms.Panel()
        Me.ctmBangCong = New System.Windows.Forms.ContextMenu()
        Me.mi_Loc = New System.Windows.Forms.MenuItem()
        Me.mi_HuyLoc = New System.Windows.Forms.MenuItem()
        Me.mi_HuyLocToanBo = New System.Windows.Forms.MenuItem()
        Me.mi_ThemGioCongNgoaiLe = New System.Windows.Forms.MenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnTinhCong = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.cbTypeOfReport = New System.Windows.Forms.CheckBox()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.MaCong = New DevExpress.XtraEditors.LookUpEdit()
        Me.InsertSource = New System.Windows.Forms.TextBox()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblMaCong = New System.Windows.Forms.Label()
        Me.wt = New System.Windows.Forms.TextBox()
        Me.lblNgay = New System.Windows.Forms.Label()
        Me.lblwt = New System.Windows.Forms.Label()
        Me.lblGhiChu = New System.Windows.Forms.Label()
        Me.Ngay = New DevExpress.XtraEditors.DateEdit()
        Me.TimeOut_KH = New DevExpress.XtraEditors.DateEdit()
        Me.TimeIn_KH = New DevExpress.XtraEditors.DateEdit()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLuuDuLieuQuet = New DevExpress.XtraEditors.SimpleButton()
        Me.CongGoc = New System.Windows.Forms.CheckBox()
        Me.CongDM = New System.Windows.Forms.CheckBox()
        Me.CongDiff = New System.Windows.Forms.CheckBox()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnLuaChonSua.SuspendLayout()
        Me.pnSuaGioQuet.SuspendLayout()
        Me.pnSuaCa.SuspendLayout()
        Me.pnLyDoGhiChu.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.MaCong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ngay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ngay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeOut_KH.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeOut_KH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeIn_KH.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeIn_KH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 371)
        Me.PanelButton.Size = New System.Drawing.Size(1280, 61)
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Location = New System.Drawing.Point(-1, 280)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1290, 72)
        Me.Panel2.TabIndex = 25
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 10
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuaChonSua, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnSuaGioQuet, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnSuaCa, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLyDoGhiChu, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnNhapLuu, 9, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1290, 72)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'pnLuaChonSua
        '
        Me.pnLuaChonSua.Controls.Add(Me.rdbSuaDuLieuQuet)
        Me.pnLuaChonSua.Controls.Add(Me.rdbSuaCa)
        Me.pnLuaChonSua.Location = New System.Drawing.Point(3, 3)
        Me.pnLuaChonSua.Name = "pnLuaChonSua"
        Me.pnLuaChonSua.Size = New System.Drawing.Size(119, 62)
        Me.pnLuaChonSua.TabIndex = 1
        '
        'rdbSuaDuLieuQuet
        '
        Me.rdbSuaDuLieuQuet.AutoSize = True
        Me.rdbSuaDuLieuQuet.Checked = True
        Me.rdbSuaDuLieuQuet.Location = New System.Drawing.Point(3, 5)
        Me.rdbSuaDuLieuQuet.Name = "rdbSuaDuLieuQuet"
        Me.rdbSuaDuLieuQuet.Size = New System.Drawing.Size(102, 17)
        Me.rdbSuaDuLieuQuet.TabIndex = 1295
        Me.rdbSuaDuLieuQuet.TabStop = True
        Me.rdbSuaDuLieuQuet.Text = "Sửa dữ liệu quẹt"
        Me.rdbSuaDuLieuQuet.UseVisualStyleBackColor = True
        '
        'rdbSuaCa
        '
        Me.rdbSuaCa.AutoSize = True
        Me.rdbSuaCa.Location = New System.Drawing.Point(3, 39)
        Me.rdbSuaCa.Name = "rdbSuaCa"
        Me.rdbSuaCa.Size = New System.Drawing.Size(59, 17)
        Me.rdbSuaCa.TabIndex = 1296
        Me.rdbSuaCa.Text = "Sửa ca"
        Me.rdbSuaCa.UseVisualStyleBackColor = True
        '
        'pnSuaGioQuet
        '
        Me.pnSuaGioQuet.Controls.Add(Me.rdbNhapTheoGioNhap)
        Me.pnSuaGioQuet.Controls.Add(Me.lblAccessTime)
        Me.pnSuaGioQuet.Controls.Add(Me.lblInOutStatus)
        Me.pnSuaGioQuet.Controls.Add(Me.rdbNhapTuDong)
        Me.pnSuaGioQuet.Controls.Add(Me.rdbNhapTheoDungGioCa)
        Me.pnSuaGioQuet.Location = New System.Drawing.Point(128, 3)
        Me.pnSuaGioQuet.Name = "pnSuaGioQuet"
        Me.pnSuaGioQuet.Size = New System.Drawing.Size(451, 62)
        Me.pnSuaGioQuet.TabIndex = 0
        '
        'rdbNhapTheoGioNhap
        '
        Me.rdbNhapTheoGioNhap.AutoSize = True
        Me.rdbNhapTheoGioNhap.Checked = True
        Me.rdbNhapTheoGioNhap.Location = New System.Drawing.Point(251, 3)
        Me.rdbNhapTheoGioNhap.Name = "rdbNhapTheoGioNhap"
        Me.rdbNhapTheoGioNhap.Size = New System.Drawing.Size(119, 17)
        Me.rdbNhapTheoGioNhap.TabIndex = 1297
        Me.rdbNhapTheoGioNhap.TabStop = True
        Me.rdbNhapTheoGioNhap.Text = "Nhập theo giờ nhập"
        Me.rdbNhapTheoGioNhap.UseVisualStyleBackColor = True
        '
        'lblAccessTime
        '
        Me.lblAccessTime.BackColor = System.Drawing.Color.Transparent
        Me.lblAccessTime.Location = New System.Drawing.Point(4, 3)
        Me.lblAccessTime.Name = "lblAccessTime"
        Me.lblAccessTime.Size = New System.Drawing.Size(64, 19)
        Me.lblAccessTime.TabIndex = 1285
        Me.lblAccessTime.Text = "Giờ quẹt"
        Me.lblAccessTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInOutStatus
        '
        Me.lblInOutStatus.Location = New System.Drawing.Point(3, 38)
        Me.lblInOutStatus.Name = "lblInOutStatus"
        Me.lblInOutStatus.Size = New System.Drawing.Size(99, 16)
        Me.lblInOutStatus.TabIndex = 1290
        Me.lblInOutStatus.Text = "Trạng thái Vào/Ra"
        '
        'rdbNhapTuDong
        '
        Me.rdbNhapTuDong.AutoSize = True
        Me.rdbNhapTuDong.Location = New System.Drawing.Point(320, 36)
        Me.rdbNhapTuDong.Name = "rdbNhapTuDong"
        Me.rdbNhapTuDong.Size = New System.Drawing.Size(113, 17)
        Me.rdbNhapTuDong.TabIndex = 1296
        Me.rdbNhapTuDong.Text = "Theo ca +-15 phút"
        Me.rdbNhapTuDong.UseVisualStyleBackColor = True
        '
        'rdbNhapTheoDungGioCa
        '
        Me.rdbNhapTheoDungGioCa.AutoSize = True
        Me.rdbNhapTheoDungGioCa.Location = New System.Drawing.Point(251, 36)
        Me.rdbNhapTheoDungGioCa.Name = "rdbNhapTheoDungGioCa"
        Me.rdbNhapTheoDungGioCa.Size = New System.Drawing.Size(65, 17)
        Me.rdbNhapTheoDungGioCa.TabIndex = 1295
        Me.rdbNhapTheoDungGioCa.Text = "Theo ca"
        Me.rdbNhapTheoDungGioCa.UseVisualStyleBackColor = True
        '
        'pnSuaCa
        '
        Me.pnSuaCa.Controls.Add(Me.lblShiftName)
        Me.pnSuaCa.Location = New System.Drawing.Point(585, 3)
        Me.pnSuaCa.Name = "pnSuaCa"
        Me.pnSuaCa.Size = New System.Drawing.Size(173, 62)
        Me.pnSuaCa.TabIndex = 3
        '
        'lblShiftName
        '
        Me.lblShiftName.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftName.Location = New System.Drawing.Point(3, 4)
        Me.lblShiftName.Name = "lblShiftName"
        Me.lblShiftName.Size = New System.Drawing.Size(64, 19)
        Me.lblShiftName.TabIndex = 1294
        Me.lblShiftName.Text = "Ca"
        Me.lblShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLyDoGhiChu
        '
        Me.pnLyDoGhiChu.Controls.Add(Me.lblReason)
        Me.pnLyDoGhiChu.Controls.Add(Me.lblRemark)
        Me.pnLyDoGhiChu.Controls.Add(Me.Remark1)
        Me.pnLyDoGhiChu.Location = New System.Drawing.Point(764, 3)
        Me.pnLyDoGhiChu.Name = "pnLyDoGhiChu"
        Me.pnLyDoGhiChu.Size = New System.Drawing.Size(263, 62)
        Me.pnLyDoGhiChu.TabIndex = 2
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.Color.Transparent
        Me.lblReason.Location = New System.Drawing.Point(3, 4)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(64, 19)
        Me.lblReason.TabIndex = 1291
        Me.lblReason.Text = "Lý do"
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.Location = New System.Drawing.Point(3, 35)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 16)
        Me.lblRemark.TabIndex = 1287
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark1
        '
        Me.Remark1.Location = New System.Drawing.Point(81, 31)
        Me.Remark1.Name = "Remark1"
        Me.Remark1.Size = New System.Drawing.Size(171, 25)
        Me.Remark1.TabIndex = 1286
        Me.Remark1.Text = ""
        '
        'pnNhapLuu
        '
        Me.pnNhapLuu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnNhapLuu.Location = New System.Drawing.Point(1075, 3)
        Me.pnNhapLuu.Name = "pnNhapLuu"
        Me.pnNhapLuu.Size = New System.Drawing.Size(212, 62)
        Me.pnNhapLuu.TabIndex = 4
        '
        'ctmBangCong
        '
        Me.ctmBangCong.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mi_Loc, Me.mi_HuyLoc, Me.mi_HuyLocToanBo, Me.mi_ThemGioCongNgoaiLe})
        '
        'mi_Loc
        '
        Me.mi_Loc.Index = 0
        Me.mi_Loc.Text = "Lọc"
        '
        'mi_HuyLoc
        '
        Me.mi_HuyLoc.Index = 1
        Me.mi_HuyLoc.Text = "Hủy lọc"
        '
        'mi_HuyLocToanBo
        '
        Me.mi_HuyLocToanBo.Index = 2
        Me.mi_HuyLocToanBo.Text = "Hủy lọc toàn bộ"
        '
        'mi_ThemGioCongNgoaiLe
        '
        Me.mi_ThemGioCongNgoaiLe.Index = 3
        Me.mi_ThemGioCongNgoaiLe.Text = "Thêm giờ công ngoại lệ"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Empty
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        Me.ImageList2.Images.SetKeyName(7, "")
        Me.ImageList2.Images.SetKeyName(8, "")
        Me.ImageList2.Images.SetKeyName(9, "")
        Me.ImageList2.Images.SetKeyName(10, "")
        Me.ImageList2.Images.SetKeyName(11, "")
        Me.ImageList2.Images.SetKeyName(12, "")
        Me.ImageList2.Images.SetKeyName(13, "")
        Me.ImageList2.Images.SetKeyName(14, "")
        Me.ImageList2.Images.SetKeyName(15, "")
        '
        'flag
        '
        Me.flag.ImageStream = CType(resources.GetObject("flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.flag.TransparentColor = System.Drawing.Color.Transparent
        Me.flag.Images.SetKeyName(0, "")
        Me.flag.Images.SetKeyName(1, "")
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1280, 432)
        Me.XtraTabControl1.TabIndex = 1010
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1278, 407)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 85)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1278, 259)
        Me.GridControl1.TabIndex = 1308
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
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1278, 85)
        Me.TableLayoutPanel3.TabIndex = 1307
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.btnTinhCong)
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.cbTypeOfReport)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 75)
        Me.pnSearch.TabIndex = 1320
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(9, 26)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1302
        '
        'btnTinhCong
        '
        Me.btnTinhCong.Location = New System.Drawing.Point(89, 47)
        Me.btnTinhCong.Name = "btnTinhCong"
        Me.btnTinhCong.Size = New System.Drawing.Size(85, 23)
        Me.btnTinhCong.TabIndex = 1301
        Me.btnTinhCong.Text = "Tính công"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(28, 47)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(58, 23)
        Me.btnSearch.TabIndex = 1300
        Me.btnSearch.Text = "Tìm"
        '
        'cbTypeOfReport
        '
        Me.cbTypeOfReport.AutoSize = True
        Me.cbTypeOfReport.Location = New System.Drawing.Point(9, 52)
        Me.cbTypeOfReport.Name = "cbTypeOfReport"
        Me.cbTypeOfReport.Size = New System.Drawing.Size(15, 14)
        Me.cbTypeOfReport.TabIndex = 1299
        Me.cbTypeOfReport.UseVisualStyleBackColor = True
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(7, 5)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(108, 23)
        Me.lblEmployee_ID.TabIndex = 1222
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.CongDiff)
        Me.pnDuLieuNhap.Controls.Add(Me.CongDM)
        Me.pnDuLieuNhap.Controls.Add(Me.CongGoc)
        Me.pnDuLieuNhap.Controls.Add(Me.MaCong)
        Me.pnDuLieuNhap.Controls.Add(Me.InsertSource)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMaCong)
        Me.pnDuLieuNhap.Controls.Add(Me.wt)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNgay)
        Me.pnDuLieuNhap.Controls.Add(Me.lblwt)
        Me.pnDuLieuNhap.Controls.Add(Me.lblGhiChu)
        Me.pnDuLieuNhap.Controls.Add(Me.Ngay)
        Me.pnDuLieuNhap.Controls.Add(Me.TimeOut_KH)
        Me.pnDuLieuNhap.Controls.Add(Me.TimeIn_KH)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(660, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'MaCong
        '
        Me.MaCong.Location = New System.Drawing.Point(329, 7)
        Me.MaCong.Name = "MaCong"
        Me.MaCong.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MaCong.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.MaCong.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.MaCong.Size = New System.Drawing.Size(183, 20)
        Me.MaCong.TabIndex = 1292
        '
        'InsertSource
        '
        Me.InsertSource.Location = New System.Drawing.Point(3, 51)
        Me.InsertSource.Name = "InsertSource"
        Me.InsertSource.Size = New System.Drawing.Size(36, 21)
        Me.InsertSource.TabIndex = 1288
        Me.InsertSource.Text = "NhapTay"
        Me.InsertSource.Visible = False
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(329, 33)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(223, 39)
        Me.Remark.TabIndex = 1287
        Me.Remark.Text = ""
        '
        'lblMaCong
        '
        Me.lblMaCong.BackColor = System.Drawing.Color.Transparent
        Me.lblMaCong.Location = New System.Drawing.Point(219, 5)
        Me.lblMaCong.Name = "lblMaCong"
        Me.lblMaCong.Size = New System.Drawing.Size(104, 23)
        Me.lblMaCong.TabIndex = 1280
        Me.lblMaCong.Text = "Mã công"
        Me.lblMaCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'wt
        '
        Me.wt.Location = New System.Drawing.Point(90, 34)
        Me.wt.Name = "wt"
        Me.wt.Size = New System.Drawing.Size(120, 21)
        Me.wt.TabIndex = 1278
        '
        'lblNgay
        '
        Me.lblNgay.BackColor = System.Drawing.SystemColors.Control
        Me.lblNgay.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgay.Location = New System.Drawing.Point(13, 6)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(74, 20)
        Me.lblNgay.TabIndex = 1277
        Me.lblNgay.Text = "Ngày"
        Me.lblNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblwt
        '
        Me.lblwt.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwt.Location = New System.Drawing.Point(13, 33)
        Me.lblwt.Name = "lblwt"
        Me.lblwt.Size = New System.Drawing.Size(74, 20)
        Me.lblwt.TabIndex = 1275
        Me.lblwt.Text = "Số giờ"
        Me.lblwt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGhiChu
        '
        Me.lblGhiChu.BackColor = System.Drawing.SystemColors.Control
        Me.lblGhiChu.Location = New System.Drawing.Point(219, 37)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(104, 16)
        Me.lblGhiChu.TabIndex = 1271
        Me.lblGhiChu.Text = "Ghi chú"
        '
        'Ngay
        '
        Me.Ngay.EditValue = Nothing
        Me.Ngay.Location = New System.Drawing.Point(90, 7)
        Me.Ngay.Name = "Ngay"
        Me.Ngay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Ngay.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Ngay.Properties.DisplayFormat.FormatString = ""
        Me.Ngay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Ngay.Properties.EditFormat.FormatString = ""
        Me.Ngay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Ngay.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Ngay.Properties.MaskSettings.Set("mask", "d")
        Me.Ngay.Properties.UseMaskAsDisplayFormat = True
        Me.Ngay.Size = New System.Drawing.Size(120, 20)
        Me.Ngay.TabIndex = 1291
        '
        'TimeOut_KH
        '
        Me.TimeOut_KH.EditValue = Nothing
        Me.TimeOut_KH.Location = New System.Drawing.Point(138, 50)
        Me.TimeOut_KH.Name = "TimeOut_KH"
        Me.TimeOut_KH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeOut_KH.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeOut_KH.Properties.DisplayFormat.FormatString = ""
        Me.TimeOut_KH.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TimeOut_KH.Properties.EditFormat.FormatString = ""
        Me.TimeOut_KH.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TimeOut_KH.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.TimeOut_KH.Properties.MaskSettings.Set("mask", "")
        Me.TimeOut_KH.Size = New System.Drawing.Size(35, 20)
        Me.TimeOut_KH.TabIndex = 1294
        Me.TimeOut_KH.Visible = False
        '
        'TimeIn_KH
        '
        Me.TimeIn_KH.EditValue = Nothing
        Me.TimeIn_KH.Location = New System.Drawing.Point(179, 51)
        Me.TimeIn_KH.Name = "TimeIn_KH"
        Me.TimeIn_KH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeIn_KH.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeIn_KH.Properties.DisplayFormat.FormatString = ""
        Me.TimeIn_KH.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TimeIn_KH.Properties.EditFormat.FormatString = ""
        Me.TimeIn_KH.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TimeIn_KH.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.TimeIn_KH.Properties.MaskSettings.Set("mask", "")
        Me.TimeIn_KH.Size = New System.Drawing.Size(25, 20)
        Me.TimeIn_KH.TabIndex = 1293
        Me.TimeIn_KH.Visible = False
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(991, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(68, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 72)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnLuuDuLieuQuet)
        Me.Panel1.Location = New System.Drawing.Point(1066, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(60, 77)
        Me.Panel1.TabIndex = 1327
        '
        'btnLuuDuLieuQuet
        '
        Me.btnLuuDuLieuQuet.Appearance.Options.UseTextOptions = True
        Me.btnLuuDuLieuQuet.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnLuuDuLieuQuet.Location = New System.Drawing.Point(4, 2)
        Me.btnLuuDuLieuQuet.Name = "btnLuuDuLieuQuet"
        Me.btnLuuDuLieuQuet.Size = New System.Drawing.Size(53, 73)
        Me.btnLuuDuLieuQuet.TabIndex = 2
        Me.btnLuuDuLieuQuet.Text = "Lưu dữ liệu quẹt"
        '
        'CongGoc
        '
        Me.CongGoc.AutoSize = True
        Me.CongGoc.Location = New System.Drawing.Point(567, 9)
        Me.CongGoc.Name = "CongGoc"
        Me.CongGoc.Size = New System.Drawing.Size(51, 17)
        Me.CongGoc.TabIndex = 1295
        Me.CongGoc.Text = "Công"
        Me.CongGoc.UseVisualStyleBackColor = True
        '
        'CongDM
        '
        Me.CongDM.AutoSize = True
        Me.CongDM.Enabled = False
        Me.CongDM.Location = New System.Drawing.Point(567, 29)
        Me.CongDM.Name = "CongDM"
        Me.CongDM.Size = New System.Drawing.Size(69, 17)
        Me.CongDM.TabIndex = 1296
        Me.CongDM.Text = "Công DM"
        Me.CongDM.UseVisualStyleBackColor = True
        '
        'CongDiff
        '
        Me.CongDiff.AutoSize = True
        Me.CongDiff.Location = New System.Drawing.Point(567, 49)
        Me.CongDiff.Name = "CongDiff"
        Me.CongDiff.Size = New System.Drawing.Size(49, 17)
        Me.CongDiff.TabIndex = 1297
        Me.CongDiff.Text = "DIFF"
        Me.CongDiff.UseVisualStyleBackColor = True
        '
        'para_TimeKeeping_Date
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1280, 432)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_WTDaily"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.Name = "para_TimeKeeping_Date"
        Me.Text = "TimeKeeping Daily - Date Parameter"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnLuaChonSua.ResumeLayout(False)
        Me.pnLuaChonSua.PerformLayout()
        Me.pnSuaGioQuet.ResumeLayout(False)
        Me.pnSuaGioQuet.PerformLayout()
        Me.pnSuaCa.ResumeLayout(False)
        Me.pnLyDoGhiChu.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        Me.pnSearch.PerformLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.MaCong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ngay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ngay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeOut_KH.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeOut_KH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeIn_KH.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeIn_KH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim KHFromDate, KHToDate As DateTime
    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub para_TimeKeeping_Date_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)

        MaCong.Properties.DataSource = kn.ReadData("select MaCong, LoaiCong, Name" + obj.Lan + ", isWorkingTime from HR_LoaiCong", "table")
        MaCong.Properties.DisplayMember = "Name" + obj.Lan
        MaCong.Properties.ValueMember = "MaCong"
        MaCong.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        MaCong.Properties.NullText = ""

        Ngay.EditValue = Today
        CongGoc.Checked = True

        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        'Search()
    End Sub

    'Private Sub XtraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
    '    btnGetTemplate.Visible = False
    '    btnImportExcel.Visible = False
    '    btnSave.Visible = False
    '    btnRemove.Visible = False
    '    Dim KH As String = tvcn.getSetUp("KH")
    '    KHFromDate = CType(KH.Split("#"c)(0), Date)
    '    KHToDate = CType(KH.Split("#"c)(1), Date)
    '    If e.Page.Name = "TinhCong" Then
    '        HRFORM_TableName = "HR_WTDaily"
    '        HRFORM_DeleteStore = "usp_DeleteHR_WTDaily"
    '        HRFORM_SaveStore = "usp_InsertUpdateHR_WTDaily"
    '        btnGetTemplate.Visible = True
    '        btnImportExcel.Visible = True
    '        btnSave.Visible = True
    '        btnRemove.Visible = True
    '        'HRFORM_Gridex = Gridex1
    '    ElseIf e.Page.Name = "BatThuong" Then
    '        HRFORM_DeleteStore = ""
    '        HRFORM_SaveStore = ""
    '        'HRFORM_Gridex = GridEX2
    '    ElseIf e.Page.Name = "CongKhachHang" Then
    '        HRFORM_DeleteStore = ""
    '        HRFORM_SaveStore = ""
    '        'HRFORM_Gridex = GridEX3
    '    End If
    '    HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
    'End Sub

    Private Sub GetTemplateWorkingTime()
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.DefaultExt = "xls"
        fileChooser.FileName = "NhapBangCong.xlsx"
        Dim result As DialogResult = fileChooser.ShowDialog()
        fileChooser.CheckFileExists = False
        If result = DialogResult.OK Then
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"}
            Dim intColStart As Integer = 3
            Dim index As Integer = 7
            Dim tabLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "table")
            Using fs As FileStream = File.OpenRead(Application.StartupPath() + "\Teamleate\NhapBangCong.xlsx")
                Using package As New ExcelPackage(fs)
                    Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
                    For Each r As DataRow In tabLoaiCong.Rows
                        ws.Cells(ColExel(intColStart) + (index - 1).ToString).Value = r("MaCong")
                        ws.Cells(ColExel(intColStart) + index.ToString).Value = r("NameVN")
                        intColStart += 1
                    Next
                    Dim fi As New FileInfo(fileChooser.FileName)
                    package.SaveAs(fi)
                    System.Diagnostics.Process.Start(fileChooser.FileName)
                End Using
            End Using
        End If
    End Sub

    Private Sub NhapTempale()
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim index As Integer = 8
            Dim ColConfig As Integer = 6
            Dim intColStart As Integer = 3
            Dim objDt As DateTime
            Dim Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName As String
            InsertDate = "'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
            UserName = "N'" + obj.UserName + "'"
            InsertSource = "'NhapTay'"
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = "N'" + worksheet.Cells("A" + index.ToString).Text.Trim + "'"
                    objDt = worksheet.Cells("B" + index.ToString).Value
                    If objDt.Year <> 1 Then
                        If tvcn.CheckingBlock("HR_WTDaily", objDt) = True Then
                            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        Ngay = "'" + objDt.ToString("yyyy-MM-dd") + "'"
                        Remark = worksheet.Cells("C" + index.ToString).Text.Trim
                        If Remark = String.Empty Then
                            Remark = "null"
                        Else
                            Remark = "N'" + Remark + "'"
                        End If
                        For intcol As Integer = intColStart To ColExel.Length - 1
                            If worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim <> String.Empty Then
                                MaCong = "N'" + worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim + "'"
                                wt = worksheet.Cells(ColExel(intcol) + index.ToString).Text.Trim
                                If wt <> String.Empty And wt <> "0" Then
                                    If kn.SaveData("exec usp_InsertUpdateHR_WTDaily " + Employee_ID + "," + MaCong + "," + Ngay + "," + InsertSource + "," + wt + "," + Remark + "," + UserName) = False Then
                                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Banvuilongkiemtralaidulieu"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                End If
                            Else
                                Exit For
                            End If
                        Next
                    End If
                    index += 1
                End While
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Private Sub NhapBangCongChiTiet()
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim urlTemplate As String = ofd.FileName
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"}
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index, SoCotThongTinChung, RowConfig, i As Integer
                index = 12
                SoCotThongTinChung = 13
                RowConfig = 9
                Dim objDt As Object
                Dim Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName, LeaveType_ID, HourLeave, ShiftName, strSQL As String
                InsertDate = "'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                UserName = "N'" + obj.UserName + "'"
                InsertSource = "'NhapTay'"
                Dim CotEmployee_ID As String
                For i = 0 To SoCotThongTinChung
                    If worksheet.Cells(ColExel(i) + RowConfig.ToString).Text.Trim.ToUpper = "EMPLOYEE_ID" Then
                        CotEmployee_ID = ColExel(i)
                    End If
                Next
                While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = "N'" + worksheet.Cells(CotEmployee_ID + index.ToString).Text.Trim + "'"
                    strSQL = String.Empty
                    If worksheet.Cells(ColExel(SoCotThongTinChung - 3) + index.ToString).Text.Trim.ToUpper = "HR_WTDAILY" Then
                        MaCong = "'" + worksheet.Cells(ColExel(SoCotThongTinChung - 2) + index.ToString).Value + "'"
                        For i = SoCotThongTinChung To ColExel.Length - 1
                            objDt = worksheet.Cells(ColExel(i) + RowConfig.ToString()).Value
                            If Not IsNothing(objDt) Then
                                If tvcn.CheckingBlock("HR_WTDaily", CDate(objDt)) = True Then
                                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bangcongdabikhoabankhongthenhapdulieu"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                                Ngay = "'" + CDate(objDt).ToString("yyyy-MM-dd") + "'"
                                wt = worksheet.Cells(ColExel(i) + index.ToString).Text.Trim
                                If wt = String.Empty Then
                                    wt = "0"
                                End If
                                strSQL += "exec [dbo].[usp_InsertUpdateHR_WTDaily] " + Employee_ID + "," + MaCong + "," + Ngay + ",'NhapTay'," + wt + ",N'','" + obj.UserName + "' "
                            Else
                                Exit For
                            End If
                        Next
                    ElseIf worksheet.Cells(ColExel(SoCotThongTinChung - 3) + index.ToString).Text.Trim.ToUpper = "HR_EMPREGISLEAVE" Then
                        For i = SoCotThongTinChung To ColExel.Length - 1
                            objDt = worksheet.Cells(ColExel(i) + RowConfig.ToString()).Value
                            If Not IsNothing(objDt) Then
                                If CType(objDt, DateTime).Year <> 1900 And CType(objDt, DateTime).Year <> 1 Then
                                    If tvcn.CheckingBlock("HR_EmpRegisLeave", CDate(objDt)) = True Then
                                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa") + ": HR_EmpRegisLeave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If
                                    Ngay = "'" + CDate(objDt).ToString("yyyy-MM-dd") + "'"
                                    LeaveType_ID = worksheet.Cells(ColExel(i) + index.ToString).Text.Trim
                                    If LeaveType_ID = String.Empty Then
                                        HourLeave = "null"
                                        LeaveType_ID = "null"
                                    Else
                                        If LeaveType_ID.IndexOf("/") > 0 Then
                                            HourLeave = LeaveType_ID.Split("/")(1)
                                            LeaveType_ID = LeaveType_ID.Split("/")(0)
                                        Else
                                            HourLeave = "8"
                                        End If
                                    End If
                                    strSQL += "exec [dbo].[usp_InsertUpdateHR_EmpRegisLeave] " + Employee_ID + "," + LeaveType_ID + "," + Ngay + ",'NhapTuBangCongChiTiet'," + HourLeave + ",N'','" + obj.UserName + "' "
                                Else
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Next
                    ElseIf worksheet.Cells(ColExel(SoCotThongTinChung - 3) + index.ToString).Text.Trim.ToUpper = "HR_EMPREGISTIMESHEET" Then
                        For i = SoCotThongTinChung To ColExel.Length - 1
                            objDt = worksheet.Cells(ColExel(i) + RowConfig.ToString()).Value
                            If Not IsNothing(objDt) Then
                                If tvcn.CheckingBlock("HR_EmpRegisTimeSheet", CDate(objDt)) = True Then
                                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa") + ": HR_EmpRegisTimeSheet", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                                Ngay = "'" + CDate(objDt).ToString("yyyy-MM-dd") + "'"
                                ShiftName = "N'" + worksheet.Cells(ColExel(i) + index.ToString).Text.Trim + "'"
                                strSQL += "exec [dbo].[usp_InsertUpdateHR_EmpRegisTimeSheet] " + Employee_ID + "," + Ngay + "," + ShiftName + ",N'NhapTuBangCongChiTiet','" + obj.UserName + "' "
                            Else
                                Exit For
                            End If
                        Next
                    End If
                    If strSQL <> String.Empty Then
                        If kn.SaveData(strSQL) = False Then
                            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + Employee_ID.Remove(0, 2).Replace("'", ""), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    index += 1
                End While
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportRow("ReportCode") = "WorkingTimeGetTemplate" Then
            GetTemplateWorkingTime()
        ElseIf ReportRow("ReportCode") = "WorkingTimeInputTemplate" Then
            NhapTempale()
        ElseIf ReportRow("ReportCode") = "WorkingTimeDetailExportExcel" Then
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.DefaultExt = "xlsx"
            fileChooser.FileName = "BangChamCongChiTietThang" + obj.PARA_FROMDATE.Month.ToString + obj.PARA_FROMDATE.Year.ToString + ".xlsx"
            Dim result As DialogResult = fileChooser.ShowDialog()
            fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                Dim f As New frmPBar
                Dim frmLoaiCong As New para_BangLoaiGioCong
                frmLoaiCong.ShowDialog()
                If (Not IsNothing(frmLoaiCong.Get_MangLoaiCong) Or frmLoaiCong.cbViewTimeInTimeOut.Checked = True Or frmLoaiCong.cbViewShift.Checked = True Or frmLoaiCong.cbViewLeave.Checked = True) And frmLoaiCong.bCancel = False Then
                    f.TKD_XuatBangCong_DanhSachLoaiCong = frmLoaiCong.Get_MangLoaiCong()
                    f.TKD_XuatBangCong_DanhSachTenCong = frmLoaiCong.Get_MangTenCong
                    f.TKD_XuatBangCong_FilePathWT = fileChooser.FileName
                    f.TKD_XuatBangCong_ViewLeave = frmLoaiCong.cbViewLeave.Checked
                    f.TKD_XuatBangCong_ViewShift = frmLoaiCong.cbViewShift.Checked
                    f.TKD_XuatBangCong_ViewTimeInTimeOut = frmLoaiCong.cbViewTimeInTimeOut.Checked
                    f.TKD_XuatBangCong_ViewPhieuCong = frmLoaiCong.cbViewPhieuCong.Checked
                    f.TKD_XuatBangCong_ViewDKTangCa = frmLoaiCong.cbViewMaxOverTime.Checked
                    f.TKD_XuatBangCong_ViewLateIn = frmLoaiCong.cbViewLateIn.Checked
                    f.FormKeyCall = "TKD_XuatBangCong"
                    f.Show()
                End If
            End If
        ElseIf ReportRow("ReportCode") = "WorkingTimeDetailExportExcelSK1" Then
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.DefaultExt = "xlsx"
            fileChooser.FileName = "BangChamCongChiTietThang" + obj.PARA_FROMDATE.Month.ToString + obj.PARA_FROMDATE.Year.ToString + ".xlsx"
            Dim result As DialogResult = fileChooser.ShowDialog()
            fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                Dim f As New frmPBar
                Dim frmLoaiCong As New para_BangLoaiGioCong
                frmLoaiCong.ShowDialog()
                If (Not IsNothing(frmLoaiCong.Get_MangLoaiCong) Or frmLoaiCong.cbViewTimeInTimeOut.Checked = True Or frmLoaiCong.cbViewShift.Checked = True Or frmLoaiCong.cbViewLeave.Checked = True) And frmLoaiCong.bCancel = False Then
                    f.TKD_XuatBangCong_DanhSachLoaiCong = frmLoaiCong.Get_MangLoaiCong()
                    f.TKD_XuatBangCong_DanhSachTenCong = frmLoaiCong.Get_MangTenCong
                    f.TKD_XuatBangCong_FilePathWT = fileChooser.FileName
                    f.TKD_XuatBangCong_ViewLeave = frmLoaiCong.cbViewLeave.Checked
                    f.TKD_XuatBangCong_ViewShift = frmLoaiCong.cbViewShift.Checked
                    f.TKD_XuatBangCong_ViewTimeInTimeOut = frmLoaiCong.cbViewTimeInTimeOut.Checked
                    f.TKD_XuatBangCong_ViewPhieuCong = frmLoaiCong.cbViewPhieuCong.Checked
                    f.TKD_XuatBangCong_ViewDKTangCa = frmLoaiCong.cbViewMaxOverTime.Checked
                    f.TKD_XuatBangCong_ViewLateIn = frmLoaiCong.cbViewLateIn.Checked
                    f.FormKeyCall = "TKD_XuatBangCongSK1"
                    f.Show()
                End If
            End If
        ElseIf ReportRow("ReportCode") = "WorkingTimeDetailExportExcelSK2" Then
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.DefaultExt = "xlsx"
            fileChooser.FileName = "BangChamCongChiTietThang" + obj.PARA_FROMDATE.Month.ToString + obj.PARA_FROMDATE.Year.ToString + ".xlsx"
            Dim result As DialogResult = fileChooser.ShowDialog()
            fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                Dim f As New frmPBar
                Dim frmLoaiCong As New para_BangLoaiGioCong
                frmLoaiCong.ShowDialog()
                If (Not IsNothing(frmLoaiCong.Get_MangLoaiCong) Or frmLoaiCong.cbViewTimeInTimeOut.Checked = True Or frmLoaiCong.cbViewShift.Checked = True Or frmLoaiCong.cbViewLeave.Checked = True) And frmLoaiCong.bCancel = False Then
                    f.TKD_XuatBangCong_DanhSachLoaiCong = frmLoaiCong.Get_MangLoaiCong()
                    f.TKD_XuatBangCong_DanhSachTenCong = frmLoaiCong.Get_MangTenCong
                    f.TKD_XuatBangCong_FilePathWT = fileChooser.FileName
                    f.TKD_XuatBangCong_ViewLeave = frmLoaiCong.cbViewLeave.Checked
                    f.TKD_XuatBangCong_ViewShift = frmLoaiCong.cbViewShift.Checked
                    f.TKD_XuatBangCong_ViewTimeInTimeOut = frmLoaiCong.cbViewTimeInTimeOut.Checked
                    f.TKD_XuatBangCong_ViewPhieuCong = frmLoaiCong.cbViewPhieuCong.Checked
                    f.TKD_XuatBangCong_ViewDKTangCa = frmLoaiCong.cbViewMaxOverTime.Checked
                    f.TKD_XuatBangCong_ViewLateIn = frmLoaiCong.cbViewLateIn.Checked
                    f.FormKeyCall = "TKD_XuatBangCongSK2"
                    f.Show()
                End If
            End If
        ElseIf ReportRow("ReportCode") = "WorkingTimeImportDetailExcel" Then
            NhapBangCongChiTiet()
        End If
    End Sub

    Private Sub Gridex2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Then
            LoadDetailInfor(True, True)
        End If
    End Sub

    Private Sub GridEX2_Click(sender As Object, e As EventArgs)
        LoadDetailInfor(True, True)
    End Sub

    Private Sub rdbAccessTimeOneDay_CheckedChanged(sender As Object, e As EventArgs)
        'If rdbAccessTimeOneDay.Checked = True Then
        '    LoadDetailInfor(True, False)
        'End If
    End Sub

    Private Sub rdbAccessTimeThreeDay_CheckedChanged(sender As Object, e As EventArgs)
        'If rdbAccessTimeThreeDay.Checked = True Then
        '    LoadDetailInfor(True, False)
        'End If
    End Sub

    Private Sub rdbAccessTimeInMonth_CheckedChanged(sender As Object, e As EventArgs)
        'If rdbAccessTimeInMonth.Checked = True Then
        '    LoadDetailInfor(True, False)
        'End If
    End Sub

    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs) Handles Employee_ID.KeyUp
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            btnSearch_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        Else
            EmID = ""
        End If
        Dim fd, td As DateTime
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(Ngay.EditValue.Year, Ngay.EditValue.Month, 2), New DateTime(Ngay.EditValue.Year, Ngay.EditValue.Month, 1).AddMonths(1).AddDays(-1))

        fd = New DateTime(Ngay.EditValue.Year, Ngay.EditValue.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If
        Dim QR As String = "exec [dbo].[sp_BangCong] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "', " + IIf(cbTypeOfReport.Checked = True, "1", "3") + ",'" + obj.Lan + "','" + obj.UserName + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, GridControl1, GridView1)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnTinhCong_Click(sender As Object, e As EventArgs) Handles btnTinhCong.Click
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        If EmID <> String.Empty Then
            Dim tabCheck As DataTable
            Dim fd, td As DateTime
            fd = New DateTime(Ngay.EditValue.Year, Ngay.EditValue.Month, 1)
            td = fd.AddMonths(1).AddDays(-1)
            tabCheck = kn.ReadData("exec [dbo].[sp_TinhCong] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',N'" + obj.UserName + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "','" + EmID + "'", "Table")
            If Not IsNothing(tabCheck) Then
                If tabCheck.Rows(0)("ThongBao") <> "" Then
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Public Overrides Sub AfterViewForm()
        'If HRFORM_Gridex.RootTable.Columns.Contains("ertsShiftName") Then
        '    'HRFORM_Gridex.RootTable.Columns("ertsShiftName").DropDown = GridEX2.DropDowns("ShiftName")
        '    HRFORM_Gridex.RootTable.Columns("ertsShiftName").EditType = EditType.MultiColumnCombo
        'End If
        'If HRFORM_Gridex.RootTable.Columns.Contains("Reason") Then
        '    Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='ReasonOfEditAccessTime'", "table")
        '    tvcn.TaoDropDowTrenGrid(HRFORM_Gridex, "Reason", tab)
        '    HRFORM_Gridex.RootTable.Columns("Reason").EditType = EditType.MultiColumnCombo
        '    HRFORM_Gridex.RootTable.Columns("Reason").FilterEditType = FilterEditType.Combo
        '    HRFORM_Gridex.RootTable.Columns("Reason").DropDown = HRFORM_Gridex.DropDowns("Reason")
        'End If
        If Not IsNothing(HRFORM_Gridview.Columns("MaCong")) Then
            Dim tab As DataTable = kn.ReadData("select MaCong as Code,Name" + obj.Lan + " as Name from HR_LoaiCong", "table")
            tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "MaCong", tab)
        End If
        'If ReportCode = "WorkingTimeDetailForSalary_Horizontal" Then
        '    For Each gr As GridEXRow In HRFORM_Gridex.GetRows
        '        gr.BeginEdit()
        '        If Not IsDBNull(gr.Cells("wt9").Value) Then
        '            If gr.Cells("wt9").Value > 0 Then
        '                gr.Cells("wt1").Value = IIf(Not IsDBNull(gr.Cells("wt1").Value), gr.Cells("wt1").Value, 0) + gr.Cells("wt9").Value
        '            End If
        '        End If
        '        gr.EndEdit()
        '    Next
        'End If
    End Sub

    Public Overrides Sub AfterImportExcel()
        'For Each r As GridEXRow In HRFORM_Gridex.GetRows
        '    r.BeginEdit()
        '    r.Cells("InsertSource").Value = "NhapTay"
        '    r.EndEdit()
        'Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'TimeIn_KH2.Value = Nothing
        'TimeOut_KH2.Value = Nothing
        TimeIn_KH.EditValue = Nothing
        TimeOut_KH.EditValue = Nothing
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_WTDaily]", TableLayoutPanel3, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub btnLuuDuLieuQuet_Click(sender As Object, e As EventArgs) Handles btnLuuDuLieuQuet.Click
        If QuyenHRFORM.ToUpper = "VIEW" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim tabChange As DataTable
        tabChange = Table.GetChanges()
        If Not IsNothing(tabChange) Then
            If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
            Dim Employee_ID, ListOfEmployee As String
            Dim AccessDateGoc, AccessDate, RealTimeIn, RealTimeOut As DateTime
            Dim RealTimeIn_TS, RealTimeOut_TS As TimeSpan
            Dim TrangThaiLuu As String

            For Each row As DataRow In tabChange.Rows
                Employee_ID = row("Employee_ID")
                AccessDateGoc = row("Ngay")
                If Not IsDBNull(row("Ngay")) And Not IsDBNull(row("Employee_ID")) Then
                    If Not IsDBNull(row("RealTimeIn")) And Not IsDBNull(row("RealTimeOut")) Then
                        RealTimeIn_TS = row("RealTimeIn")
                        RealTimeOut_TS = row("RealTimeOut")
                        RealTimeIn = New DateTime(AccessDateGoc.Year, AccessDateGoc.Month, AccessDateGoc.Day, RealTimeIn_TS.Hours, RealTimeIn_TS.Minutes, RealTimeIn_TS.Seconds)
                        If RealTimeIn_TS.Hours > RealTimeOut_TS.Hours Then
                            AccessDate = AccessDateGoc.AddDays(1)
                        Else
                            AccessDate = AccessDateGoc
                        End If
                        RealTimeOut = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, RealTimeOut_TS.Hours, RealTimeOut_TS.Minutes, RealTimeOut_TS.Seconds)
                        If kn.SaveData("exec [dbo].[usp_InsertUpdateHR_DuLieuQuetVaoRa] null,N'" + Employee_ID + "','" + AccessDateGoc.ToString("yyyy-MM-dd") + "','" + RealTimeIn.ToString("yyyy-MM-dd HH:mm:ss") + "','" + RealTimeOut.ToString("yyyy-MM-dd HH:mm:ss") + "',null,'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + obj.UserName + "'") = False Then
                            TrangThaiLuu = "1"
                        End If
                    Else
                        If IsDBNull(row("RealTimeIn")) Or IsDBNull(row("RealTimeOut")) Then
                            kn.SaveData("delete HR_DuLieuQuetVaoRa where Employee_ID=N'" + Employee_ID + "' and Ngay='" + AccessDateGoc.ToString("yyyy-MM-dd") + "'")
                        End If
                    End If
                Else
                    TrangThaiLuu = "2"
                End If
                If TrangThaiLuu <> String.Empty Then
                    If MessageBox.Show("Dòng mã: " + Employee_ID + ", ngày:" + AccessDate.ToString("dd/MM/yyyy") + " đang không lưu được, code lỗi: " + TrangThaiLuu + ". Bạn lưu ý khi lưu cần có đủ giờ vào ra, mã nhân viên và ngày. Bạn có muốn tiếp tục lưu?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Exit For
                    End If
                End If
            Next
            Table.AcceptChanges()
            If IsNothing(TrangThaiLuu) Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub LoadDetailInfor(ByVal LoadAccessTime As Boolean, ByVal LoadMaxOverTime As Boolean)
        'If IsNothing(GridEX2.RootTable) Then
        '    Exit Sub
        'End If
        'If IsNothing(GridEX2.GetRow()) Then
        '    Exit Sub
        'End If
        'If IsNothing(GridEX2.GetRow.Cells("Employee_ID").Value) Then
        '    Exit Sub
        'End If
        'If CDate(GridEX2.GetRow.Cells("Ngay").Value).Year = 1 Then
        '    Exit Sub
        'End If
        'Dim strQuery As String
        'If LoadAccessTime = True Then
        '    Dim fromdate, todate As DateTime
        '    fromdate = GridEX2.GetRow.Cells("Ngay").Value
        '    todate = GridEX2.GetRow.Cells("Ngay").Value
        '    If rdbAccessTimeThreeDay.Checked = True Then
        '        fromdate = fromdate.AddDays(-1)
        '        todate = todate.AddDays(1)
        '    ElseIf rdbAccessTimeInMonth.Checked = True Then
        '        fromdate = fromdate.AddDays(1 - fromdate.Day)
        '        todate = fromdate.AddMonths(1).AddDays(-1)
        '    End If
        '    strQuery = "select Employee_ID, AccessDate, cast(AccessTime as time(0)) as AccessTime,InOutStatus,InsertSource,ID from HR_TimeKeeping_Data where Employee_ID=N'" + GridEX2.GetRow.Cells("Employee_ID").Value + "' and AccessDate between '" + fromdate.ToString("yyyy-MM-dd") + "' and '" + todate.ToString("yyyy-MM-dd") + "' order by AccessDate, AccessTime asc"
        '    tvcn.Xem(strQuery, "", gridAccessTime, tabAccessTime)
        '    tvcn.DropDownInOut(gridAccessTime)
        '    gridAccessTime.RowHeaders = InheritableBoolean.False
        '    gridAccessTime.GroupByBoxVisible = False
        '    gridAccessTime.FilterMode = False
        'End If
        'If LoadMaxOverTime = True Then
        '    strQuery = "select Employee_ID,workingdate,maxovertime,TypeOfOT,ShiftName,NgayNghiBu,Remark,ID from HR_MaxOvertime where Employee_ID=N'" + GridEX2.GetRow.Cells("Employee_ID").Value + "' and workingdate='" + CDate(GridEX2.GetRow.Cells("Ngay").Value).ToString("yyyy-MM-dd") + "'"
        '    tvcn.Xem(strQuery, "", gridMaxOverTime, tabMaxOverTime)
        '    tvcn.DropDownInOut(gridMaxOverTime)
        '    gridMaxOverTime.RowHeaders = InheritableBoolean.False
        '    gridMaxOverTime.GroupByBoxVisible = False
        '    gridMaxOverTime.FilterMode = False
        'End If
    End Sub

    Private Sub wt_Leave(sender As Object, e As EventArgs)
        If wt.Text.Trim <> String.Empty Then
            If tvcn.isNumber(wt.Text) = False Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Loidinhdangso"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                wt.Select()
            End If
        End If
    End Sub

    Private Sub CongDM_CheckedChanged(sender As Object, e As EventArgs) Handles CongDM.CheckedChanged
        If CongDM.Checked = True Then
            kn.SaveData("update Setup set [Value] = 1 where ID=N'" + obj.UserName + "' and FunctionID ='KH'")
        End If
    End Sub

    Private Sub CongGoc_CheckedChanged(sender As Object, e As EventArgs) Handles CongGoc.CheckedChanged
        If CongGoc.Checked = False And CongDiff.Checked = False Then
            CongDM.Checked = True
        End If
        If CongGoc.Checked = True Then
            CongDiff.Checked = False
            CongDM.Checked = False
        End If
        If CongGoc.Checked = True Then
            kn.SaveData("update Setup set [Value] = 0 where ID=N'" + obj.UserName + "' and FunctionID ='KH'")
        End If
    End Sub

    Private Sub CongDiff_CheckedChanged(sender As Object, e As EventArgs) Handles CongDiff.CheckedChanged
        If CongDM.Checked = False And CongDiff.Checked = False Then
            CongDM.Checked = True
        End If
        If CongDiff.Checked = True Then
            CongDM.Checked = False
            CongGoc.Checked = False
        End If
        If CongDiff.Checked = True Then
            kn.SaveData("update Setup set [Value] = 2 where ID=N'" + obj.UserName + "' and FunctionID ='KH'")
        End If
    End Sub

    Private Function FindMatch(ByVal text As String, ByVal expr As String) As String
        Dim mc As MatchCollection = Regex.Matches(text, expr)
        Dim m As Match
        For Each m In mc
            Return m.Value
        Next m
    End Function

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        If IsNothing(GridView1.GetDataRow(0)) Then
            Exit Sub
        End If

        If Not IsNothing(GridView1.Columns("Employee_ID")) Then
            If GridView1.GetDataRow(0).Item("Employee_ID") = "" Then
                Exit Sub
            End If
        End If
        If Not IsNothing(GridView1.Columns("Ngay")) Then
            If CDate(GridView1.GetDataRow(0).Item("Ngay")).Year = 1 Then
                Exit Sub
            End If
        End If

        If Not IsNothing(GridView1.Columns("InsertSource")) Then
            If GridView1.GetFocusedDataRow("InsertSource").ToString() = "NhapTay" Then
                'GridView1.Columns.Item("wt").OptionsColumn.AllowEdit = True
                GridView1.OptionsBehavior.Editable = True
            Else
                'GridView1.Columns.Item("wt").OptionsColumn.AllowEdit = False
                GridView1.OptionsBehavior.Editable = False
            End If
        End If

    End Sub
End Class