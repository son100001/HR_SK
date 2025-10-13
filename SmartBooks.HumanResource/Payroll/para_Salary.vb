Imports WindowsControlLibrary
Imports VBReport
 

Public Class para_Salary
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
    Friend WithEvents ds As SmartBooks.BusinessLogic.SmartData
    Friend WithEvents mnXoaThanhPhanLuong As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents lblPayDate As Label
    Friend WithEvents cbXoaNgayThanhToan As CheckBox
    Friend WithEvents lblXoaNgayThanhToan As Label
    Friend WithEvents PayDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnCapNhat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKhoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMoKhoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TroCapThoiViec As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ThanhToanPhepNam As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TruyThuPhepNam As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TroCapConNho As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents QuyetToanPIT As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Thuong3004_0105 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Thuong0209 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Thang13 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl6 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl7 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl8 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl9 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView9 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl10 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView10 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CongGoc As CheckBox
    Friend WithEvents CongDM As CheckBox
    Friend WithEvents CongDiff As CheckBox
    Friend WithEvents LuongThoiViec As DevExpress.XtraTab.XtraTabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblPayDate = New System.Windows.Forms.Label()
        Me.cbXoaNgayThanhToan = New System.Windows.Forms.CheckBox()
        Me.lblXoaNgayThanhToan = New System.Windows.Forms.Label()
        Me.PayDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnCapNhat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKhoa = New DevExpress.XtraEditors.SimpleButton()
        Me.btnMoKhoa = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LuongThoiViec = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TroCapThoiViec = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ThanhToanPhepNam = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TruyThuPhepNam = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TroCapConNho = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl6 = New DevExpress.XtraGrid.GridControl()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.QuyetToanPIT = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl7 = New DevExpress.XtraGrid.GridControl()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Thuong3004_0105 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl8 = New DevExpress.XtraGrid.GridControl()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Thuong0209 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl9 = New DevExpress.XtraGrid.GridControl()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Thang13 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl10 = New DevExpress.XtraGrid.GridControl()
        Me.GridView10 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CongGoc = New System.Windows.Forms.CheckBox()
        Me.CongDM = New System.Windows.Forms.CheckBox()
        Me.CongDiff = New System.Windows.Forms.CheckBox()
        CType(Me.PayDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PayDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LuongThoiViec.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TroCapThoiViec.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ThanhToanPhepNam.SuspendLayout()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TruyThuPhepNam.SuspendLayout()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TroCapConNho.SuspendLayout()
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QuyetToanPIT.SuspendLayout()
        CType(Me.GridControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Thuong3004_0105.SuspendLayout()
        CType(Me.GridControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Thuong0209.SuspendLayout()
        CType(Me.GridControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Thang13.SuspendLayout()
        CType(Me.GridControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 432)
        Me.PanelButton.Size = New System.Drawing.Size(1120, 50)
        '
        'lblPayDate
        '
        Me.lblPayDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayDate.Location = New System.Drawing.Point(3, 4)
        Me.lblPayDate.Name = "lblPayDate"
        Me.lblPayDate.Size = New System.Drawing.Size(88, 20)
        Me.lblPayDate.TabIndex = 1009
        Me.lblPayDate.Text = "Ngày thanh toán"
        Me.lblPayDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbXoaNgayThanhToan
        '
        Me.cbXoaNgayThanhToan.AutoSize = True
        Me.cbXoaNgayThanhToan.Location = New System.Drawing.Point(344, 8)
        Me.cbXoaNgayThanhToan.Name = "cbXoaNgayThanhToan"
        Me.cbXoaNgayThanhToan.Size = New System.Drawing.Size(15, 14)
        Me.cbXoaNgayThanhToan.TabIndex = 1011
        Me.cbXoaNgayThanhToan.UseVisualStyleBackColor = True
        '
        'lblXoaNgayThanhToan
        '
        Me.lblXoaNgayThanhToan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXoaNgayThanhToan.Location = New System.Drawing.Point(217, 6)
        Me.lblXoaNgayThanhToan.Name = "lblXoaNgayThanhToan"
        Me.lblXoaNgayThanhToan.Size = New System.Drawing.Size(108, 20)
        Me.lblXoaNgayThanhToan.TabIndex = 1012
        Me.lblXoaNgayThanhToan.Text = "Xóa ngày thanh toán"
        Me.lblXoaNgayThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PayDate
        '
        Me.PayDate.EditValue = Nothing
        Me.PayDate.Location = New System.Drawing.Point(97, 5)
        Me.PayDate.Name = "PayDate"
        Me.PayDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PayDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PayDate.Properties.DisplayFormat.FormatString = ""
        Me.PayDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PayDate.Properties.EditFormat.FormatString = ""
        Me.PayDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PayDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.PayDate.Properties.MaskSettings.Set("mask", "d")
        Me.PayDate.Properties.UseMaskAsDisplayFormat = True
        Me.PayDate.Size = New System.Drawing.Size(114, 20)
        Me.PayDate.TabIndex = 1013
        '
        'btnCapNhat
        '
        Me.btnCapNhat.Location = New System.Drawing.Point(374, 6)
        Me.btnCapNhat.Name = "btnCapNhat"
        Me.btnCapNhat.Size = New System.Drawing.Size(80, 19)
        Me.btnCapNhat.TabIndex = 1014
        Me.btnCapNhat.Text = "Cập nhật"
        '
        'btnKhoa
        '
        Me.btnKhoa.Location = New System.Drawing.Point(30, 7)
        Me.btnKhoa.Name = "btnKhoa"
        Me.btnKhoa.Size = New System.Drawing.Size(80, 19)
        Me.btnKhoa.TabIndex = 1015
        Me.btnKhoa.Text = "Khóa"
        '
        'btnMoKhoa
        '
        Me.btnMoKhoa.Location = New System.Drawing.Point(116, 7)
        Me.btnMoKhoa.Name = "btnMoKhoa"
        Me.btnMoKhoa.Size = New System.Drawing.Size(80, 19)
        Me.btnMoKhoa.TabIndex = 1016
        Me.btnMoKhoa.Text = "Mở khóa"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 32)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(1120, 400)
        Me.XtraTabControl1.TabIndex = 1017
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General, Me.LuongThoiViec, Me.TroCapThoiViec, Me.ThanhToanPhepNam, Me.TruyThuPhepNam, Me.TroCapConNho, Me.QuyetToanPIT, Me.Thuong3004_0105, Me.Thuong0209, Me.Thang13})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1118, 375)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'LuongThoiViec
        '
        Me.LuongThoiViec.Controls.Add(Me.GridControl2)
        Me.LuongThoiViec.Name = "LuongThoiViec"
        Me.LuongThoiViec.Size = New System.Drawing.Size(1118, 375)
        Me.LuongThoiViec.Text = "Lương thôi việc"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl2.TabIndex = 1
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'TroCapThoiViec
        '
        Me.TroCapThoiViec.Controls.Add(Me.GridControl3)
        Me.TroCapThoiViec.Name = "TroCapThoiViec"
        Me.TroCapThoiViec.Size = New System.Drawing.Size(1118, 375)
        Me.TroCapThoiViec.Text = "Trợ cấp thôi việc"
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl3.TabIndex = 1
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        '
        'ThanhToanPhepNam
        '
        Me.ThanhToanPhepNam.Controls.Add(Me.GridControl4)
        Me.ThanhToanPhepNam.Name = "ThanhToanPhepNam"
        Me.ThanhToanPhepNam.Size = New System.Drawing.Size(1118, 375)
        Me.ThanhToanPhepNam.Text = "Thanh toán phép năm"
        '
        'GridControl4
        '
        Me.GridControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl4.Location = New System.Drawing.Point(0, 0)
        Me.GridControl4.MainView = Me.GridView4
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl4.TabIndex = 1
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl4
        Me.GridView4.Name = "GridView4"
        '
        'TruyThuPhepNam
        '
        Me.TruyThuPhepNam.Controls.Add(Me.GridControl5)
        Me.TruyThuPhepNam.Name = "TruyThuPhepNam"
        Me.TruyThuPhepNam.Size = New System.Drawing.Size(1118, 375)
        Me.TruyThuPhepNam.Text = "Truy thu phép năm"
        '
        'GridControl5
        '
        Me.GridControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl5.Location = New System.Drawing.Point(0, 0)
        Me.GridControl5.MainView = Me.GridView5
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl5.TabIndex = 1
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GridControl5
        Me.GridView5.Name = "GridView5"
        '
        'TroCapConNho
        '
        Me.TroCapConNho.Controls.Add(Me.GridControl6)
        Me.TroCapConNho.Name = "TroCapConNho"
        Me.TroCapConNho.Size = New System.Drawing.Size(1118, 375)
        Me.TroCapConNho.Text = "Trợ cấp con nhỏ"
        '
        'GridControl6
        '
        Me.GridControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl6.Location = New System.Drawing.Point(0, 0)
        Me.GridControl6.MainView = Me.GridView6
        Me.GridControl6.Name = "GridControl6"
        Me.GridControl6.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl6.TabIndex = 1
        Me.GridControl6.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6})
        '
        'GridView6
        '
        Me.GridView6.GridControl = Me.GridControl6
        Me.GridView6.Name = "GridView6"
        '
        'QuyetToanPIT
        '
        Me.QuyetToanPIT.Controls.Add(Me.GridControl7)
        Me.QuyetToanPIT.Name = "QuyetToanPIT"
        Me.QuyetToanPIT.Size = New System.Drawing.Size(1118, 375)
        Me.QuyetToanPIT.Text = "Quyết toán PIT"
        '
        'GridControl7
        '
        Me.GridControl7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl7.Location = New System.Drawing.Point(0, 0)
        Me.GridControl7.MainView = Me.GridView7
        Me.GridControl7.Name = "GridControl7"
        Me.GridControl7.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl7.TabIndex = 1
        Me.GridControl7.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView7})
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.GridControl7
        Me.GridView7.Name = "GridView7"
        '
        'Thuong3004_0105
        '
        Me.Thuong3004_0105.Controls.Add(Me.GridControl8)
        Me.Thuong3004_0105.Name = "Thuong3004_0105"
        Me.Thuong3004_0105.Size = New System.Drawing.Size(1118, 375)
        Me.Thuong3004_0105.Text = "Thưởng 30/04 - 01/05"
        '
        'GridControl8
        '
        Me.GridControl8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl8.Location = New System.Drawing.Point(0, 0)
        Me.GridControl8.MainView = Me.GridView8
        Me.GridControl8.Name = "GridControl8"
        Me.GridControl8.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl8.TabIndex = 1
        Me.GridControl8.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView8})
        '
        'GridView8
        '
        Me.GridView8.GridControl = Me.GridControl8
        Me.GridView8.Name = "GridView8"
        '
        'Thuong0209
        '
        Me.Thuong0209.Controls.Add(Me.GridControl9)
        Me.Thuong0209.Name = "Thuong0209"
        Me.Thuong0209.Size = New System.Drawing.Size(1118, 375)
        Me.Thuong0209.Text = "Thưởng 02/09"
        '
        'GridControl9
        '
        Me.GridControl9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl9.Location = New System.Drawing.Point(0, 0)
        Me.GridControl9.MainView = Me.GridView9
        Me.GridControl9.Name = "GridControl9"
        Me.GridControl9.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl9.TabIndex = 1
        Me.GridControl9.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView9})
        '
        'GridView9
        '
        Me.GridView9.GridControl = Me.GridControl9
        Me.GridView9.Name = "GridView9"
        '
        'Thang13
        '
        Me.Thang13.Controls.Add(Me.GridControl10)
        Me.Thang13.Name = "Thang13"
        Me.Thang13.Size = New System.Drawing.Size(1118, 375)
        Me.Thang13.Text = "Lương tháng 13"
        '
        'GridControl10
        '
        Me.GridControl10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl10.Location = New System.Drawing.Point(0, 0)
        Me.GridControl10.MainView = Me.GridView10
        Me.GridControl10.Name = "GridControl10"
        Me.GridControl10.Size = New System.Drawing.Size(1118, 375)
        Me.GridControl10.TabIndex = 1
        Me.GridControl10.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView10})
        '
        'GridView10
        '
        Me.GridView10.GridControl = Me.GridControl10
        Me.GridView10.Name = "GridView10"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CongDiff)
        Me.Panel1.Controls.Add(Me.CongDM)
        Me.Panel1.Controls.Add(Me.CongGoc)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblPayDate)
        Me.Panel1.Controls.Add(Me.cbXoaNgayThanhToan)
        Me.Panel1.Controls.Add(Me.lblXoaNgayThanhToan)
        Me.Panel1.Controls.Add(Me.PayDate)
        Me.Panel1.Controls.Add(Me.btnCapNhat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1120, 32)
        Me.Panel1.TabIndex = 1018
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnKhoa)
        Me.Panel2.Controls.Add(Me.btnMoKhoa)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(909, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(211, 32)
        Me.Panel2.TabIndex = 1017
        '
        'CongGoc
        '
        Me.CongGoc.AutoSize = True
        Me.CongGoc.Location = New System.Drawing.Point(460, 7)
        Me.CongGoc.Name = "CongGoc"
        Me.CongGoc.Size = New System.Drawing.Size(51, 17)
        Me.CongGoc.TabIndex = 1296
        Me.CongGoc.Text = "Công"
        Me.CongGoc.UseVisualStyleBackColor = True
        '
        'CongDM
        '
        Me.CongDM.AutoSize = True
        Me.CongDM.Enabled = False
        Me.CongDM.Location = New System.Drawing.Point(517, 7)
        Me.CongDM.Name = "CongDM"
        Me.CongDM.Size = New System.Drawing.Size(69, 17)
        Me.CongDM.TabIndex = 1297
        Me.CongDM.Text = "Công DM"
        Me.CongDM.UseVisualStyleBackColor = True
        '
        'CongDiff
        '
        Me.CongDiff.AutoSize = True
        Me.CongDiff.Location = New System.Drawing.Point(592, 7)
        Me.CongDiff.Name = "CongDiff"
        Me.CongDiff.Size = New System.Drawing.Size(49, 17)
        Me.CongDiff.TabIndex = 1298
        Me.CongDiff.Text = "DIFF"
        Me.CongDiff.UseVisualStyleBackColor = True
        '
        'para_Salary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1120, 482)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_DeleteStore = "usp_DeleteSmartBooks_Salary"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "SmartBooks_Salary"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "para_Salary"
        Me.Text = "Para Salary"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.PayDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PayDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LuongThoiViec.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TroCapThoiViec.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ThanhToanPhepNam.ResumeLayout(False)
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TruyThuPhepNam.ResumeLayout(False)
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TroCapConNho.ResumeLayout(False)
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QuyetToanPIT.ResumeLayout(False)
        CType(Me.GridControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Thuong3004_0105.ResumeLayout(False)
        CType(Me.GridControl8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Thuong0209.ResumeLayout(False)
        CType(Me.GridControl9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Thang13.ResumeLayout(False)
        CType(Me.GridControl10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PayDate.EditValue = Today

        CongGoc.Checked = True
        'Me.Name = "General"
        'LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    'Public Overrides Sub AfterViewForm()
    '    Dim tabSalaryComponentCategory As DataTable = kn.ReadData("select * from SmartBooks_Salary_Name", "table")
    '    If Not tabSalaryComponentCategory Is Nothing Then
    '        For Each r As DataRow In tabSalaryComponentCategory.Rows
    '            GridView1.Columns(r("Salary")).FormatString = "N2"
    '        Next
    '    End If
    'End Sub

    Public Overrides Function BeforeSave() As Integer
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return 0
        End If
        Dim tabChange As DataTable = Table.GetChanges()
        If Not IsNothing(tabChange) Then
            Dim ID, Key, Salary_Month, Salary_Year, Employee_ID, PayDate, isPaid, Remark As String
            For Each r As DataRow In tabChange.Rows
                ID = r("ID").ToString()
                Key = r("Key").ToString()
                Salary_Month = r("Salary_Month").ToString()
                Salary_Year = r("Salary_Year").ToString()
                Employee_ID = "N'" + r("Employee_ID").ToString() + "'"
                If Not IsDBNull(r("PayDate")) Then
                    PayDate = "'" + CDate(r("PayDate")).ToString("yyyy-MM-dd") + "'"
                Else
                    PayDate = "null"
                End If
                If Not IsDBNull(r("isPaid")) Then
                    If r("isPaid") = True Then
                        isPaid = "1"
                    Else
                        isPaid = "Null"
                    End If
                Else
                    isPaid = "null"
                End If
                If Not IsDBNull(r("Remark")) Then
                    Remark = "N'" + r("Remark") + "'"
                Else
                    Remark = "null"
                End If
                Dim tabCheck As DataTable
                tabCheck = kn.ReadData("exec usp_InsertUpdateSmartBooks_Salary " + ID + "," + Employee_ID + "," + Salary_Month + "," + Salary_Year + "," + Employee_ID + "," + PayDate + "," + isPaid + "," + Remark + ",N'" + obj.UserName + "'", "Table")
                If Not IsNothing(tabCheck) Then
                    If tabCheck.Rows(0)("ThongBao") <> "" Then
                        If MessageBox.Show("Lỗi " + tabCheck.Rows(0)("ThongBao") + ". Bạn có muốn tiếp tục thực hiện?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                            Return 0
                        End If

                    End If
                End If

            Next
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return 0
    End Function

    Public Overrides Function BeforeDelete() As Integer
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return 0
        End If
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonxoa"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Return 0
        End If
        If HRFORM_Gridview.SelectedRowsCount <= 0 Then
            MessageBox.Show("Bạn vui lòng chọn dòng để xóa!", "", MessageBoxButtons.OK)
            Return 0
        End If
        Dim ID, Key, Salary_Month, Salary_Year, Employee_ID, PayDate, isPaid, Remark As String
        Dim tabCheck As DataTable
        Dim gr As DataRow
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            gr = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow))
            ID = gr.Item("ID").Value.ToString()
            Key = gr.Item("Key").Value.ToString()
            Salary_Month = gr.Item("Salary_Month").Value.ToString()
            Salary_Year = gr.Item("Salary_Year").Value.ToString()
            Employee_ID = "N'" + gr.Item("Employee_ID").Value.ToString() + "'"
            tabCheck = kn.ReadData("exec usp_DeleteSmartBooks_Salary " + ID + "," + Employee_ID + "," + Salary_Month + "," + Salary_Year + "," + Employee_ID + ",N'" + obj.UserName + "'", "Table")
            If Not IsNothing(tabCheck) Then
                If tabCheck.Rows(0)("ThongBao") <> "" Then
                    If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + " " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")) + ". " + tvcn.GetLanguagesTranslated("Popup.Bancomuontieptucthuchienkhong"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                        Return 0
                    End If

                End If
            End If
        Next
        Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Xoathanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return 0
    End Function

    'Private Sub UltraTabControl1_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
    '    HRFORM_VisibleControl_GetTemplate = False
    '    HRFORM_VisibleControl_ImportExcel = False
    '    HRFORM_VisibleControl_Luu = False
    '    HRFORM_VisibleControl_Sua = False
    '    HRFORM_VisibleControl_ThemMoi = False
    '    HRFORM_VisibleControl_Xoa = False
    '    HRFORM_Gridex = Nothing
    '    HRFORM_GridControl = Nothing
    '    HRFORM_Gridview = Nothing
    '    If e.Tab.Key = "General" Then
    '        HRFORM_Gridex = Gridex1
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "LuongThoiViec" Then
    '        HRFORM_Gridex = GridEX2
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "QuyetToanPIT" Then
    '        HRFORM_Gridex = GridEX3
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "TroCapThoiViec" Then
    '        HRFORM_Gridex = GridEX7
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "ThanhToanPhepNam" Then
    '        HRFORM_Gridex = GridEX8
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "TruyThuPhepNam" Then
    '        HRFORM_Gridex = GridEX9
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "TroCapConNho" Then
    '        HRFORM_Gridex = GridEX10
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "Thuong3004_0105" Then
    '        HRFORM_Gridex = GridEX4
    '        HRFORM_VisibleControl_Xoa = True
    '    ElseIf e.Tab.Key = "Thuong0209" Then
    '        HRFORM_VisibleControl_Xoa = True
    '        HRFORM_Gridex = GridEX5
    '    ElseIf e.Tab.Key = "Thang13" Then
    '        HRFORM_Gridex = GridEX6
    '        HRFORM_VisibleControl_Xoa = True
    '    End If
    '    HRFORM_UltraTabControl_SelectedTabChanged(sender, e)
    '    LoadGiaoDienTheoDieuKien()
    'End Sub

    Private Sub btnKhoa_Click(sender As Object, e As EventArgs) Handles btnKhoa.Click
        Khoa_MoKhoa(1)
    End Sub

    Private Sub Khoa_MoKhoa(ByVal trangthai As Integer)
        If HRFORM_Gridview.SelectedRowsCount <= 0 Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongchondongcankhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show(IIf(trangthai = 1, tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonkhoa"), tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonmokhoa")), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        Dim r As DataRow
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            r = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow))
            kn.SaveData("update smartbooks_salary set trangthai=" + trangthai.ToString + " where employee_id='" + r.Item("Employee_ID").ToString + "' and salary_month='" + r.Item("salary_month").ToString + "' and salary_year='" + r.Item("salary_year").ToString + "' and [Key]='" + r.Item("Key").ToString + "'")
        Next
        HRFORMXem()
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnMoKhoa_Click(sender As Object, e As EventArgs) Handles btnMoKhoa.Click
        Khoa_MoKhoa(0)
    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        If HRFORM_Gridview.SelectedRowsCount <= 0 Then
            MessageBox.Show("Bạn vui lòng chọn dòng cần cập nhật.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Bạn có thực sự muốn cập nhật?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If
        Dim tabCheck As DataTable
        Dim ID, Key, Salary_Month, Salary_Year, Employee_ID As String
        Dim gr As DataRow
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            ID = gr.Item("ID").ToString
            Key = gr.Item("Key").ToString
            Salary_Month = gr.Item("Salary_Month").ToString
            Salary_Year = gr.Item("Salary_Year").ToString
            Employee_ID = "N'" + gr.Item("Employee_ID").ToString + "'"
            tabCheck = kn.ReadData("exec usp_InsertUpdateSmartBooks_Salary " + ID + "," + Key + "," + Salary_Month + "," + Salary_Year + "," + Employee_ID + "," + IIf(cbXoaNgayThanhToan.Checked = False, "'" + PayDate.DateTime.ToString("yyyy-MM-dd") + "'", "null") + ",N'" + obj.UserName + "'", "Table")
            If Not IsNothing(tabCheck) Then
                If tabCheck.Rows(0)("ThongBao") <> "" Then
                    If MessageBox.Show("Lỗi " + tabCheck.Rows(0)("ThongBao") + ". Bạn có muốn tiếp tục thực hiện?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                        HRFORMXem()
                        Exit Sub
                    End If
                End If
            End If
        Next
        HRFORMXem()
        MessageBox.Show("Cập nhật kết thúc!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        HRFORM_VisibleControl_GetTemplate = False
        HRFORM_VisibleControl_ImportExcel = False
        HRFORM_VisibleControl_Luu = False
        HRFORM_VisibleControl_Sua = False
        HRFORM_VisibleControl_ThemMoi = False
        HRFORM_VisibleControl_Xoa = False
        HRFORM_GridControl = Nothing
        HRFORM_Gridview = Nothing
        If e.Page.Name = "General" Then
            HRFORM_GridControl = GridControl1
            HRFORM_Gridview = GridView1
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "LuongThoiViec" Then
            HRFORM_GridControl = GridControl2
            HRFORM_Gridview = GridView2
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "TroCapThoiViec" Then
            HRFORM_GridControl = GridControl3
            HRFORM_Gridview = GridView3
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "ThanhToanPhepNam" Then
            HRFORM_GridControl = GridControl4
            HRFORM_Gridview = GridView4
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "TruyThuPhepNam" Then
            HRFORM_GridControl = GridControl5
            HRFORM_Gridview = GridView5
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "TroCapConNho" Then
            HRFORM_GridControl = GridControl6
            HRFORM_Gridview = GridView6
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "QuyetToanPIT" Then
            HRFORM_GridControl = GridControl7
            HRFORM_Gridview = GridView7
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "Thuong3004_0105" Then
            HRFORM_GridControl = GridControl8
            HRFORM_Gridview = GridView8
            HRFORM_VisibleControl_Xoa = True
        ElseIf e.Page.Name = "Thuong0209" Then
            HRFORM_VisibleControl_Xoa = True
            HRFORM_GridControl = GridControl9
            HRFORM_Gridview = GridView9
        ElseIf e.Page.Name = "Thang13" Then
            HRFORM_GridControl = GridControl10
            HRFORM_Gridview = GridView10
            HRFORM_VisibleControl_Xoa = True
        End If
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
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

    Private Sub CongDM_CheckedChanged(sender As Object, e As EventArgs) Handles CongDM.CheckedChanged
        If CongDM.Checked = True Then
            kn.SaveData("update Setup set [Value] = 1 where ID=N'" + obj.UserName + "' and FunctionID ='KH'")
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
End Class
