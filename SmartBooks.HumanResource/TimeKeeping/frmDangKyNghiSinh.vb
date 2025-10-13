Imports DevExpress.XtraGrid.Views.Grid
Imports WindowsControlLibrary

Public Class frmDangKyNghiSinh
    Inherits HRFORM
    Dim MaxDay As Integer, MaxMonth As Integer
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grThamKhao As GroupBox
    Friend WithEvents txtPNTNCN As TextBox
    Friend WithEvents lblPNTNCN As Label
    Friend WithEvents lblPNNNDHCL As Label
    Friend WithEvents txtPNNNDHCL As TextBox
    Friend WithEvents grThongTinPhepNam As GroupBox
    Friend WithEvents lblPhepNamTon As Label
    Friend WithEvents txtPNT As TextBox
    Friend WithEvents txtPNDN As TextBox
    Friend WithEvents lblPNDN As Label
    Friend WithEvents txtPNCL As TextBox
    Friend WithEvents lblPNCLHT As Label
    Friend WithEvents lblPNCLCN As Label
    Friend WithEvents txtPNCLHT As TextBox
    Friend WithEvents txtPNTC As TextBox
    Friend WithEvents lblPNTCHT As Label
    Friend WithEvents lblPNTC As Label
    Friend WithEvents txtPNTCHT As TextBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbViewAll As CheckBox
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PlanStatus As TextBox
    Friend WithEvents lblApproval As Label
    Friend WithEvents lblisDaNopGiay As Label
    Friend WithEvents isChoUngPhep As CheckBox
    Friend WithEvents isBlock As CheckBox
    Friend WithEvents isDaNopGiay As CheckBox
    Friend WithEvents lblLeaveType_ID As Label
    Friend WithEvents lblReaSon As Label
    Friend WithEvents Reason As TextBox
    Friend WithEvents lblfromdate As Label
    Friend WithEvents lbltodate As Label
    Friend WithEvents todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LeaveType_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Dim tabAdmin As DataTable

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
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents mnuClear As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents mtItemTimKiem As System.Windows.Forms.MenuItem
    Friend WithEvents mtItemHuyTimKiem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDangKyNghiSinh))
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuClear = New System.Windows.Forms.MenuItem()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.mtItemTimKiem = New System.Windows.Forms.MenuItem()
        Me.mtItemHuyTimKiem = New System.Windows.Forms.MenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grThamKhao = New System.Windows.Forms.GroupBox()
        Me.txtPNTNCN = New System.Windows.Forms.TextBox()
        Me.lblPNTNCN = New System.Windows.Forms.Label()
        Me.lblPNNNDHCL = New System.Windows.Forms.Label()
        Me.txtPNNNDHCL = New System.Windows.Forms.TextBox()
        Me.grThongTinPhepNam = New System.Windows.Forms.GroupBox()
        Me.lblPhepNamTon = New System.Windows.Forms.Label()
        Me.txtPNT = New System.Windows.Forms.TextBox()
        Me.txtPNDN = New System.Windows.Forms.TextBox()
        Me.lblPNDN = New System.Windows.Forms.Label()
        Me.txtPNCL = New System.Windows.Forms.TextBox()
        Me.lblPNCLHT = New System.Windows.Forms.Label()
        Me.lblPNCLCN = New System.Windows.Forms.Label()
        Me.txtPNCLHT = New System.Windows.Forms.TextBox()
        Me.txtPNTC = New System.Windows.Forms.TextBox()
        Me.lblPNTCHT = New System.Windows.Forms.Label()
        Me.lblPNTC = New System.Windows.Forms.Label()
        Me.txtPNTCHT = New System.Windows.Forms.TextBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.cbViewAll = New System.Windows.Forms.CheckBox()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PlanStatus = New System.Windows.Forms.TextBox()
        Me.lblApproval = New System.Windows.Forms.Label()
        Me.lblisDaNopGiay = New System.Windows.Forms.Label()
        Me.isChoUngPhep = New System.Windows.Forms.CheckBox()
        Me.isBlock = New System.Windows.Forms.CheckBox()
        Me.isDaNopGiay = New System.Windows.Forms.CheckBox()
        Me.lblLeaveType_ID = New System.Windows.Forms.Label()
        Me.lblReaSon = New System.Windows.Forms.Label()
        Me.Reason = New System.Windows.Forms.TextBox()
        Me.lblfromdate = New System.Windows.Forms.Label()
        Me.lbltodate = New System.Windows.Forms.Label()
        Me.todate = New DevExpress.XtraEditors.DateEdit()
        Me.fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.LeaveType_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grThamKhao.SuspendLayout()
        Me.grThongTinPhepNam.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeaveType_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 467)
        Me.PanelButton.Size = New System.Drawing.Size(1285, 55)
        '
        'flag
        '
        Me.flag.ImageStream = CType(resources.GetObject("flag.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.flag.TransparentColor = System.Drawing.Color.Transparent
        Me.flag.Images.SetKeyName(0, "")
        Me.flag.Images.SetKeyName(1, "")
        '
        'mnuClear
        '
        Me.mnuClear.Index = 0
        Me.mnuClear.Text = "&Xóa (X)"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuClear, Me.mtItemTimKiem, Me.mtItemHuyTimKiem})
        '
        'mtItemTimKiem
        '
        Me.mtItemTimKiem.Index = 1
        Me.mtItemTimKiem.Text = "&Tìm kiếm (T)"
        '
        'mtItemHuyTimKiem
        '
        Me.mtItemHuyTimKiem.Index = 2
        Me.mtItemHuyTimKiem.Text = "&Hủy tìm kiếm (H)"
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1285, 467)
        Me.XtraTabControl1.TabIndex = 1331
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.Panel2)
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1283, 442)
        Me.General.Text = "General"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grThamKhao)
        Me.Panel2.Controls.Add(Me.grThongTinPhepNam)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1283, 68)
        Me.Panel2.TabIndex = 1335
        '
        'grThamKhao
        '
        Me.grThamKhao.Controls.Add(Me.txtPNTNCN)
        Me.grThamKhao.Controls.Add(Me.lblPNTNCN)
        Me.grThamKhao.Controls.Add(Me.lblPNNNDHCL)
        Me.grThamKhao.Controls.Add(Me.txtPNNNDHCL)
        Me.grThamKhao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grThamKhao.Location = New System.Drawing.Point(733, 0)
        Me.grThamKhao.Name = "grThamKhao"
        Me.grThamKhao.Size = New System.Drawing.Size(550, 68)
        Me.grThamKhao.TabIndex = 1334
        Me.grThamKhao.TabStop = False
        Me.grThamKhao.Text = "Tham khảo"
        '
        'txtPNTNCN
        '
        Me.txtPNTNCN.Enabled = False
        Me.txtPNTNCN.Location = New System.Drawing.Point(266, 18)
        Me.txtPNTNCN.Name = "txtPNTNCN"
        Me.txtPNTNCN.ReadOnly = True
        Me.txtPNTNCN.Size = New System.Drawing.Size(55, 21)
        Me.txtPNTNCN.TabIndex = 1324
        '
        'lblPNTNCN
        '
        Me.lblPNTNCN.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNTNCN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNTNCN.Location = New System.Drawing.Point(21, 18)
        Me.lblPNTNCN.Name = "lblPNTNCN"
        Me.lblPNTNCN.Size = New System.Drawing.Size(239, 20)
        Me.lblPNTNCN.TabIndex = 1325
        Me.lblPNTNCN.Text = "PN thâm niên tính đến cuối năm"
        Me.lblPNTNCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPNNNDHCL
        '
        Me.lblPNNNDHCL.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNNNDHCL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNNNDHCL.Location = New System.Drawing.Point(20, 44)
        Me.lblPNNNDHCL.Name = "lblPNNNDHCL"
        Me.lblPNNNDHCL.Size = New System.Drawing.Size(240, 20)
        Me.lblPNNNDHCL.TabIndex = 1327
        Me.lblPNNNDHCL.Text = "PN NN ĐH tính đến cuối năm"
        Me.lblPNNNDHCL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPNNNDHCL
        '
        Me.txtPNNNDHCL.Enabled = False
        Me.txtPNNNDHCL.Location = New System.Drawing.Point(266, 43)
        Me.txtPNNNDHCL.Name = "txtPNNNDHCL"
        Me.txtPNNNDHCL.ReadOnly = True
        Me.txtPNNNDHCL.Size = New System.Drawing.Size(55, 21)
        Me.txtPNNNDHCL.TabIndex = 1326
        '
        'grThongTinPhepNam
        '
        Me.grThongTinPhepNam.Controls.Add(Me.lblPhepNamTon)
        Me.grThongTinPhepNam.Controls.Add(Me.txtPNT)
        Me.grThongTinPhepNam.Controls.Add(Me.txtPNDN)
        Me.grThongTinPhepNam.Controls.Add(Me.lblPNDN)
        Me.grThongTinPhepNam.Controls.Add(Me.txtPNCL)
        Me.grThongTinPhepNam.Controls.Add(Me.lblPNCLHT)
        Me.grThongTinPhepNam.Controls.Add(Me.lblPNCLCN)
        Me.grThongTinPhepNam.Controls.Add(Me.txtPNCLHT)
        Me.grThongTinPhepNam.Controls.Add(Me.txtPNTC)
        Me.grThongTinPhepNam.Controls.Add(Me.lblPNTCHT)
        Me.grThongTinPhepNam.Controls.Add(Me.lblPNTC)
        Me.grThongTinPhepNam.Controls.Add(Me.txtPNTCHT)
        Me.grThongTinPhepNam.Dock = System.Windows.Forms.DockStyle.Left
        Me.grThongTinPhepNam.Location = New System.Drawing.Point(0, 0)
        Me.grThongTinPhepNam.Name = "grThongTinPhepNam"
        Me.grThongTinPhepNam.Size = New System.Drawing.Size(733, 68)
        Me.grThongTinPhepNam.TabIndex = 1333
        Me.grThongTinPhepNam.TabStop = False
        Me.grThongTinPhepNam.Text = "Thông tin phép năm"
        '
        'lblPhepNamTon
        '
        Me.lblPhepNamTon.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPhepNamTon.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhepNamTon.Location = New System.Drawing.Point(10, 16)
        Me.lblPhepNamTon.Name = "lblPhepNamTon"
        Me.lblPhepNamTon.Size = New System.Drawing.Size(144, 20)
        Me.lblPhepNamTon.TabIndex = 1312
        Me.lblPhepNamTon.Text = "PN tồn"
        Me.lblPhepNamTon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPNT
        '
        Me.txtPNT.Enabled = False
        Me.txtPNT.Location = New System.Drawing.Point(157, 17)
        Me.txtPNT.Name = "txtPNT"
        Me.txtPNT.ReadOnly = True
        Me.txtPNT.Size = New System.Drawing.Size(55, 21)
        Me.txtPNT.TabIndex = 1311
        '
        'txtPNDN
        '
        Me.txtPNDN.Enabled = False
        Me.txtPNDN.Location = New System.Drawing.Point(157, 42)
        Me.txtPNDN.Name = "txtPNDN"
        Me.txtPNDN.ReadOnly = True
        Me.txtPNDN.Size = New System.Drawing.Size(55, 21)
        Me.txtPNDN.TabIndex = 1313
        '
        'lblPNDN
        '
        Me.lblPNDN.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNDN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNDN.Location = New System.Drawing.Point(10, 41)
        Me.lblPNDN.Name = "lblPNDN"
        Me.lblPNDN.Size = New System.Drawing.Size(144, 20)
        Me.lblPNDN.TabIndex = 1314
        Me.lblPNDN.Text = "PNĐN"
        Me.lblPNDN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPNCL
        '
        Me.txtPNCL.Enabled = False
        Me.txtPNCL.Location = New System.Drawing.Point(414, 43)
        Me.txtPNCL.Name = "txtPNCL"
        Me.txtPNCL.ReadOnly = True
        Me.txtPNCL.Size = New System.Drawing.Size(55, 21)
        Me.txtPNCL.TabIndex = 1315
        '
        'lblPNCLHT
        '
        Me.lblPNCLHT.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNCLHT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNCLHT.Location = New System.Drawing.Point(486, 43)
        Me.lblPNCLHT.Name = "lblPNCLHT"
        Me.lblPNCLHT.Size = New System.Drawing.Size(168, 20)
        Me.lblPNCLHT.TabIndex = 1323
        Me.lblPNCLHT.Text = "PNCL (Đến hiện tại)"
        Me.lblPNCLHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPNCLCN
        '
        Me.lblPNCLCN.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNCLCN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNCLCN.Location = New System.Drawing.Point(227, 40)
        Me.lblPNCLCN.Name = "lblPNCLCN"
        Me.lblPNCLCN.Size = New System.Drawing.Size(181, 20)
        Me.lblPNCLCN.TabIndex = 1316
        Me.lblPNCLCN.Text = "PNCL (Đến cuối năm)"
        Me.lblPNCLCN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPNCLHT
        '
        Me.txtPNCLHT.Enabled = False
        Me.txtPNCLHT.Location = New System.Drawing.Point(660, 42)
        Me.txtPNCLHT.Name = "txtPNCLHT"
        Me.txtPNCLHT.ReadOnly = True
        Me.txtPNCLHT.Size = New System.Drawing.Size(55, 21)
        Me.txtPNCLHT.TabIndex = 1322
        '
        'txtPNTC
        '
        Me.txtPNTC.Enabled = False
        Me.txtPNTC.Location = New System.Drawing.Point(414, 17)
        Me.txtPNTC.Name = "txtPNTC"
        Me.txtPNTC.ReadOnly = True
        Me.txtPNTC.Size = New System.Drawing.Size(55, 21)
        Me.txtPNTC.TabIndex = 1318
        '
        'lblPNTCHT
        '
        Me.lblPNTCHT.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNTCHT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNTCHT.Location = New System.Drawing.Point(487, 17)
        Me.lblPNTCHT.Name = "lblPNTCHT"
        Me.lblPNTCHT.Size = New System.Drawing.Size(167, 20)
        Me.lblPNTCHT.TabIndex = 1321
        Me.lblPNTCHT.Text = "PNTC (Đến hiện tại)"
        Me.lblPNTCHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPNTC
        '
        Me.lblPNTC.BackColor = System.Drawing.SystemColors.Menu
        Me.lblPNTC.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPNTC.Location = New System.Drawing.Point(227, 17)
        Me.lblPNTC.Name = "lblPNTC"
        Me.lblPNTC.Size = New System.Drawing.Size(181, 20)
        Me.lblPNTC.TabIndex = 1319
        Me.lblPNTC.Text = "PNTC (Đến cuối năm)"
        Me.lblPNTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPNTCHT
        '
        Me.txtPNTCHT.Enabled = False
        Me.txtPNTCHT.Location = New System.Drawing.Point(660, 17)
        Me.txtPNTCHT.Name = "txtPNTCHT"
        Me.txtPNTCHT.ReadOnly = True
        Me.txtPNTCHT.Size = New System.Drawing.Size(55, 21)
        Me.txtPNTCHT.TabIndex = 1320
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 163)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1278, 277)
        Me.GridControl1.TabIndex = 1332
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
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1283, 93)
        Me.TableLayoutPanel3.TabIndex = 1331
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.cbViewAll)
        Me.Panel1.Controls.Add(Me.Employee_ID)
        Me.Panel1.Controls.Add(Me.lblEmployee_ID)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 85)
        Me.Panel1.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(29, 60)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1300
        Me.btnSearch.Text = "Tìm"
        '
        'cbViewAll
        '
        Me.cbViewAll.AutoSize = True
        Me.cbViewAll.Location = New System.Drawing.Point(8, 63)
        Me.cbViewAll.Name = "cbViewAll"
        Me.cbViewAll.Size = New System.Drawing.Size(15, 14)
        Me.cbViewAll.TabIndex = 1299
        Me.cbViewAll.UseVisualStyleBackColor = True
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 37)
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
        Me.lblEmployee_ID.Location = New System.Drawing.Point(5, 10)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(106, 23)
        Me.lblEmployee_ID.TabIndex = 1274
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PlanStatus)
        Me.Panel3.Controls.Add(Me.lblApproval)
        Me.Panel3.Controls.Add(Me.lblisDaNopGiay)
        Me.Panel3.Controls.Add(Me.isChoUngPhep)
        Me.Panel3.Controls.Add(Me.isBlock)
        Me.Panel3.Controls.Add(Me.isDaNopGiay)
        Me.Panel3.Controls.Add(Me.lblLeaveType_ID)
        Me.Panel3.Controls.Add(Me.lblReaSon)
        Me.Panel3.Controls.Add(Me.Reason)
        Me.Panel3.Controls.Add(Me.lblfromdate)
        Me.Panel3.Controls.Add(Me.lbltodate)
        Me.Panel3.Controls.Add(Me.todate)
        Me.Panel3.Controls.Add(Me.fromdate)
        Me.Panel3.Controls.Add(Me.LeaveType_ID)
        Me.Panel3.Controls.Add(Me.Remark)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(313, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(757, 85)
        Me.Panel3.TabIndex = 1321
        '
        'PlanStatus
        '
        Me.PlanStatus.Location = New System.Drawing.Point(353, 61)
        Me.PlanStatus.Name = "PlanStatus"
        Me.PlanStatus.Size = New System.Drawing.Size(15, 21)
        Me.PlanStatus.TabIndex = 1301
        Me.PlanStatus.Visible = False
        '
        'lblApproval
        '
        Me.lblApproval.BackColor = System.Drawing.SystemColors.Menu
        Me.lblApproval.Location = New System.Drawing.Point(519, 13)
        Me.lblApproval.Name = "lblApproval"
        Me.lblApproval.Size = New System.Drawing.Size(96, 14)
        Me.lblApproval.TabIndex = 1300
        Me.lblApproval.Text = "Duyệt nhập"
        '
        'lblisDaNopGiay
        '
        Me.lblisDaNopGiay.BackColor = System.Drawing.SystemColors.Menu
        Me.lblisDaNopGiay.Location = New System.Drawing.Point(521, 43)
        Me.lblisDaNopGiay.Name = "lblisDaNopGiay"
        Me.lblisDaNopGiay.Size = New System.Drawing.Size(96, 18)
        Me.lblisDaNopGiay.TabIndex = 1299
        Me.lblisDaNopGiay.Text = "Đã nộp giấy"
        '
        'isChoUngPhep
        '
        Me.isChoUngPhep.AutoSize = True
        Me.isChoUngPhep.Location = New System.Drawing.Point(621, 14)
        Me.isChoUngPhep.Name = "isChoUngPhep"
        Me.isChoUngPhep.Size = New System.Drawing.Size(15, 14)
        Me.isChoUngPhep.TabIndex = 15
        Me.isChoUngPhep.UseVisualStyleBackColor = True
        '
        'isBlock
        '
        Me.isBlock.AutoSize = True
        Me.isBlock.Enabled = False
        Me.isBlock.Location = New System.Drawing.Point(522, 63)
        Me.isBlock.Name = "isBlock"
        Me.isBlock.Size = New System.Drawing.Size(50, 17)
        Me.isBlock.TabIndex = 1298
        Me.isBlock.Text = "Khóa"
        Me.isBlock.UseVisualStyleBackColor = True
        Me.isBlock.Visible = False
        '
        'isDaNopGiay
        '
        Me.isDaNopGiay.AutoSize = True
        Me.isDaNopGiay.Location = New System.Drawing.Point(622, 44)
        Me.isDaNopGiay.Name = "isDaNopGiay"
        Me.isDaNopGiay.Size = New System.Drawing.Size(15, 14)
        Me.isDaNopGiay.TabIndex = 17
        Me.isDaNopGiay.UseVisualStyleBackColor = True
        '
        'lblLeaveType_ID
        '
        Me.lblLeaveType_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_ID.Location = New System.Drawing.Point(15, 10)
        Me.lblLeaveType_ID.Name = "lblLeaveType_ID"
        Me.lblLeaveType_ID.Size = New System.Drawing.Size(99, 19)
        Me.lblLeaveType_ID.TabIndex = 1295
        Me.lblLeaveType_ID.Text = "Phép"
        Me.lblLeaveType_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReaSon
        '
        Me.lblReaSon.BackColor = System.Drawing.Color.Transparent
        Me.lblReaSon.Location = New System.Drawing.Point(15, 42)
        Me.lblReaSon.Name = "lblReaSon"
        Me.lblReaSon.Size = New System.Drawing.Size(46, 19)
        Me.lblReaSon.TabIndex = 1294
        Me.lblReaSon.Text = "Reason"
        Me.lblReaSon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Reason
        '
        Me.Reason.Location = New System.Drawing.Point(123, 41)
        Me.Reason.Name = "Reason"
        Me.Reason.Size = New System.Drawing.Size(161, 21)
        Me.Reason.TabIndex = 9
        '
        'lblfromdate
        '
        Me.lblfromdate.BackColor = System.Drawing.SystemColors.Menu
        Me.lblfromdate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfromdate.Location = New System.Drawing.Point(291, 9)
        Me.lblfromdate.Name = "lblfromdate"
        Me.lblfromdate.Size = New System.Drawing.Size(88, 20)
        Me.lblfromdate.TabIndex = 1236
        Me.lblfromdate.Text = "Từ ngày"
        Me.lblfromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltodate
        '
        Me.lbltodate.BackColor = System.Drawing.SystemColors.Menu
        Me.lbltodate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltodate.Location = New System.Drawing.Point(291, 42)
        Me.lbltodate.Name = "lbltodate"
        Me.lbltodate.Size = New System.Drawing.Size(92, 20)
        Me.lbltodate.TabIndex = 1240
        Me.lbltodate.Text = "Đến ngày"
        Me.lbltodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'todate
        '
        Me.todate.EditValue = Nothing
        Me.todate.Location = New System.Drawing.Point(389, 42)
        Me.todate.Name = "todate"
        Me.todate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.todate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.todate.Properties.DisplayFormat.FormatString = ""
        Me.todate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.todate.Properties.EditFormat.FormatString = ""
        Me.todate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.todate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.todate.Properties.MaskSettings.Set("mask", "d")
        Me.todate.Properties.UseMaskAsDisplayFormat = True
        Me.todate.Size = New System.Drawing.Size(120, 20)
        Me.todate.TabIndex = 13
        '
        'fromdate
        '
        Me.fromdate.EditValue = Nothing
        Me.fromdate.Location = New System.Drawing.Point(389, 10)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.DisplayFormat.FormatString = ""
        Me.fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditFormat.FormatString = ""
        Me.fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.fromdate.Size = New System.Drawing.Size(120, 20)
        Me.fromdate.TabIndex = 11
        '
        'LeaveType_ID
        '
        Me.LeaveType_ID.Location = New System.Drawing.Point(123, 9)
        Me.LeaveType_ID.Name = "LeaveType_ID"
        Me.LeaveType_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LeaveType_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LeaveType_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LeaveType_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LeaveType_ID.Size = New System.Drawing.Size(161, 20)
        Me.LeaveType_ID.TabIndex = 7
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(653, 22)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(94, 58)
        Me.Remark.TabIndex = 19
        Me.Remark.Text = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(653, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 1290
        Me.Label2.Text = "Ghi chú"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Location = New System.Drawing.Point(1077, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(57, 80)
        Me.Panel4.TabIndex = 1325
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 36
        Me.btnSave.Text = "Lưu"
        '
        'frmDangKyNghiSinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1285, 522)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_EmployeeRegisMaternityLeave"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_EmployeeRegisMaternityLeave"
        Me.HRFORM_TableName = "HR_EmployeeRegisMaternityLeave"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmDangKyNghiSinh"
        Me.Text = "frmDangKyNghiSinh"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.grThamKhao.ResumeLayout(False)
        Me.grThamKhao.PerformLayout()
        Me.grThongTinPhepNam.ResumeLayout(False)
        Me.grThongTinPhepNam.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeaveType_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmDangKyNghiSinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        tvcn.GetDataOnDropDownCategoryCodeName(LeaveType_ID, kn.ReadData("select LeaveType_ID as Code, AbsentSign + ': ' + LeaveType_" + obj.Lan + " + (case when NumberOfDate is not null or NumberOfMonth is not null then ' - ' else '' end)+ (case when NumberOfDate is not null then N'Tối đa:' + cast(NumberOfDate as varchar(10)) +' ngày ' else '' end) +(case when NumberOfMonth is not null then  N'Tối đa:' + cast(NumberOfMonth as varchar(10)) +' tháng' else '' end) as Name from SmartBooks_LeaveType where AbsentSign is not null", "table"))
        tvcn.SearchEmployee(Employee_ID)
        fromdate.DateTime = Today
        Search()
    End Sub

    Private Sub GridView1_CustomDrawColumnHeader(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles GridView1.CustomDrawColumnHeader
        If e.Column Is Nothing Then
            Return
        End If

        Dim colName As String = e.Column.FieldName
        Dim dt As DateTime

        If DateTime.TryParse(colName, dt) Then
            If dt.DayOfWeek = DayOfWeek.Saturday OrElse dt.DayOfWeek = DayOfWeek.Sunday Then
                e.Appearance.BackColor = Color.LightBlue
                e.Appearance.ForeColor = Color.DarkRed
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.Column Is Nothing Then
            Return
        End If

        Dim colName As String = e.Column.FieldName
        Dim dt As DateTime
        If DateTime.TryParse(colName, dt) Then
            If dt.DayOfWeek = DayOfWeek.Saturday OrElse dt.DayOfWeek = DayOfWeek.Sunday Then
                e.Appearance.BackColor = Color.Snow
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Public Overrides Sub AfterViewForm()
        If Not IsNothing(GridView1) Then
            If Not IsNothing(GridView1.Columns("NumberOfDate")) Then
                GridView1.Columns("NumberOfDate").OptionsColumn.AllowEdit = False
            End If
            If Not IsNothing(GridView1.Columns("PlanStatus")) Then
                GridView1.Columns("PlanStatus").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub
    Private Function DemSoNgayWorkingDay(ByVal FD As DateTime, ByVal TD As DateTime) As Integer
        Dim tab As DataTable = kn.ReadData("select [dbo].[udf_CountWorkingDay]('" + FD.ToString("yyyy-MM-dd") + "','" + TD.ToString("yyyy-MM-dd") + "')", "table")
        Return tab.Rows(0)(0)
    End Function

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd, td, FromD As DateTime
        FromD = fromdate.EditValue
        If FromD.Year = 1 Then
            FromD = Today
        Else
            FromD = FromD
        End If
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(FromD.Year, FromD.Month, 2), New DateTime(FromD.Year, FromD.Month, 1).AddMonths(1).AddDays(-1))
        If cbViewAll.Checked = True Then
            fd = New DateTime(1900, 1, 1)
            If NgayChuyenDi.Year = 1 Then
                td = New DateTime(2999, 1, 1)
            Else
                td = NgayChuyenDi.AddDays(-1)
            End If
        Else
            fd = New DateTime(FromD.Year, FromD.Month, 1)
            If NgayChuyenDi.Year = 1 Then
                td = fd.AddMonths(1).AddDays(-1)
            Else
                td = NgayChuyenDi.AddDays(-1)
            End If
        End If
        Dim QR As String = "exec [dbo].[sp_BangPhepMultiple] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "'," + If(cbViewAll.Checked, "1", "14") + ",'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub TinhPN()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        txtPNTC.Text = "0"
        txtPNT.Text = "0"
        txtPNDN.Text = "0"
        txtPNCL.Text = "0"
        If Employee_ID.Text.Trim <> String.Empty Then
            Dim tabSoPhepNamDaNghi As DataTable = kn.ReadData("select * from [dbo].[udf_QuanLyPhepNam](" + fromdate.DateTime.Year.ToString + ",EOMONTH(GETDATE()),'" + obj.Lan + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + EmID + "')", "table")
            If tabSoPhepNamDaNghi.Rows.Count > 0 Then
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("PhepNamDuocHuong")) Then
                    txtPNTC.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("PhepNamDuocHuong"))
                End If
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("PhepNamTon")) Then
                    txtPNT.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("PhepNamTon"))
                End If
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("PhepNamTon")) Then
                    txtPNT.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("PhepNamTon"))
                End If
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("TongPhepNamDaNghi")) Then
                    txtPNDN.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("TongPhepNamDaNghi"))
                End If
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("PhepNamDuocHuongDenHienTai")) Then
                    txtPNTCHT.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("PhepNamDuocHuongDenHienTai"))
                End If
                txtPNCL.Text = CDbl(txtPNTC.Text.Trim) + CDbl(txtPNT.Text.Trim) - CDbl(txtPNDN.Text.Trim)
                txtPNCLHT.Text = CDbl(txtPNTCHT.Text.Trim) + CDbl(txtPNT.Text.Trim) - CDbl(txtPNDN.Text.Trim)
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("PhepNamThamNienTinhDenCuoiNam")) Then
                    txtPNTNCN.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("PhepNamThamNienTinhDenCuoiNam"))
                End If
                If Not IsDBNull(tabSoPhepNamDaNghi.Rows(0)("PhepNamNNDHTinhDenCuoiNam")) Then
                    txtPNNNDHCL.Text = CStr(tabSoPhepNamDaNghi.Rows(0)("PhepNamNNDHTinhDenCuoiNam"))
                End If
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_EmployeeRegisMaternityLeave]", Me, ErrorProvider1) Then
            Search()
            isChoUngPhep.Checked = False
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
        TinhPN()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
        TinhPN()
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try
            If IsNothing(GridView1.GetDataRow(0)) Then
                Exit Sub
            End If
            If GridView1.GetDataRow(0).Item("Employee_ID") = "" Then
                Exit Sub
            End If
            If CDate(GridView1.GetDataRow(0).Item("fromdate")).Year = 1 Then
                Exit Sub
            End If
            If Not IsNothing(GridView1.Columns("ID")) Then
                If GridView1.GetFocusedDataRow("ID").ToString() <> "-1" Then
                    'GridView1.Columns.Item("wt").OptionsColumn.AllowEdit = True
                    GridView1.OptionsBehavior.Editable = True
                Else
                    'GridView1.Columns.Item("wt").OptionsColumn.AllowEdit = False
                    GridView1.OptionsBehavior.Editable = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
