Imports WindowsControlLibrary
Imports VBReport
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Imports Janus.Windows.GridEX
Imports DevExpress.XtraGrid.Views.Base

Public Class para_TimeKeeping_Data2
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
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents flag As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents mnTimKiemNhanVien As System.Windows.Forms.MenuItem
    Friend WithEvents mnHuyTimKiem As System.Windows.Forms.MenuItem
    Friend WithEvents mi_HuyToanBoLoc As System.Windows.Forms.MenuItem
    Friend WithEvents ctmGridDuLieuQuet As System.Windows.Forms.ContextMenu
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabAccessTime As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents Reason As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents InOutStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AccessTime As DevExpress.XtraEditors.DateTimeOffsetEdit
    Friend WithEvents AccessDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents InsertSource As TextBox
    Friend WithEvents DeviceIP As TextBox
    Friend WithEvents CardNumber As TextBox
    Friend WithEvents Device_ID As TextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblAccessDate As Label
    Friend WithEvents lblReason As Label
    Friend WithEvents lblInOutStatus As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblAccessTime As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ListOfAccessTimeDeleted As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ErrorProvider1 As ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(para_TimeKeeping_Data2))
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.flag = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.mnTimKiemNhanVien = New System.Windows.Forms.MenuItem()
        Me.mnHuyTimKiem = New System.Windows.Forms.MenuItem()
        Me.mi_HuyToanBoLoc = New System.Windows.Forms.MenuItem()
        Me.ctmGridDuLieuQuet = New System.Windows.Forms.ContextMenu()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabAccessTime = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.Reason = New DevExpress.XtraEditors.LookUpEdit()
        Me.InOutStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.AccessTime = New DevExpress.XtraEditors.DateTimeOffsetEdit()
        Me.AccessDate = New DevExpress.XtraEditors.DateEdit()
        Me.InsertSource = New System.Windows.Forms.TextBox()
        Me.DeviceIP = New System.Windows.Forms.TextBox()
        Me.CardNumber = New System.Windows.Forms.TextBox()
        Me.Device_ID = New System.Windows.Forms.TextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblAccessDate = New System.Windows.Forms.Label()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.lblInOutStatus = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblAccessTime = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.ListOfAccessTimeDeleted = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.TabAccessTime.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.Reason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InOutStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccessTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccessDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccessDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.ListOfAccessTimeDeleted.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 349)
        Me.PanelButton.Size = New System.Drawing.Size(1231, 55)
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Empty
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
        'mnTimKiemNhanVien
        '
        Me.mnTimKiemNhanVien.Index = 0
        Me.mnTimKiemNhanVien.Text = "Lọc"
        '
        'mnHuyTimKiem
        '
        Me.mnHuyTimKiem.Index = 1
        Me.mnHuyTimKiem.Text = "Hủy lọc"
        '
        'mi_HuyToanBoLoc
        '
        Me.mi_HuyToanBoLoc.Index = 2
        Me.mi_HuyToanBoLoc.Text = "Hủy lọc toàn bộ"
        '
        'ctmGridDuLieuQuet
        '
        Me.ctmGridDuLieuQuet.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnTimKiemNhanVien, Me.mnHuyTimKiem, Me.mi_HuyToanBoLoc})
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
        Me.XtraTabControl1.SelectedTabPage = Me.TabAccessTime
        Me.XtraTabControl1.Size = New System.Drawing.Size(1231, 349)
        Me.XtraTabControl1.TabIndex = 1010
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabAccessTime, Me.ListOfAccessTimeDeleted})
        '
        'TabAccessTime
        '
        Me.TabAccessTime.Controls.Add(Me.GridControl1)
        Me.TabAccessTime.Controls.Add(Me.TableLayoutPanel2)
        Me.TabAccessTime.Name = "TabAccessTime"
        Me.TabAccessTime.Size = New System.Drawing.Size(1229, 324)
        Me.TabAccessTime.Text = "Danh sách quẹt thẻ"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 85)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1229, 239)
        Me.GridControl1.TabIndex = 1325
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
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1229, 85)
        Me.TableLayoutPanel2.TabIndex = 1324
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 75)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(4, 51)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1301
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(4, 25)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(295, 20)
        Me.Employee_ID.TabIndex = 1220
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.ForeColor = System.Drawing.Color.Red
        Me.lblEmployee_ID.Location = New System.Drawing.Point(4, 5)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(108, 17)
        Me.lblEmployee_ID.TabIndex = 1219
        Me.lblEmployee_ID.Text = "Mã nhân viên *"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.Reason)
        Me.pnDuLieuNhap.Controls.Add(Me.InOutStatus)
        Me.pnDuLieuNhap.Controls.Add(Me.AccessTime)
        Me.pnDuLieuNhap.Controls.Add(Me.AccessDate)
        Me.pnDuLieuNhap.Controls.Add(Me.InsertSource)
        Me.pnDuLieuNhap.Controls.Add(Me.DeviceIP)
        Me.pnDuLieuNhap.Controls.Add(Me.CardNumber)
        Me.pnDuLieuNhap.Controls.Add(Me.Device_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAccessDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblReason)
        Me.pnDuLieuNhap.Controls.Add(Me.lblInOutStatus)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAccessTime)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(700, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'Reason
        '
        Me.Reason.Location = New System.Drawing.Point(342, 29)
        Me.Reason.Name = "Reason"
        Me.Reason.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Reason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Reason.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Reason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Reason.Size = New System.Drawing.Size(141, 20)
        Me.Reason.TabIndex = 1301
        '
        'InOutStatus
        '
        Me.InOutStatus.Location = New System.Drawing.Point(342, 4)
        Me.InOutStatus.Name = "InOutStatus"
        Me.InOutStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.InOutStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InOutStatus.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.InOutStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.InOutStatus.Size = New System.Drawing.Size(141, 20)
        Me.InOutStatus.TabIndex = 1300
        '
        'AccessTime
        '
        Me.AccessTime.EditValue = Nothing
        Me.AccessTime.Location = New System.Drawing.Point(98, 31)
        Me.AccessTime.Name = "AccessTime"
        Me.AccessTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessTime.Properties.MaskSettings.Set("mask", "t")
        Me.AccessTime.Size = New System.Drawing.Size(118, 20)
        Me.AccessTime.TabIndex = 1299
        '
        'AccessDate
        '
        Me.AccessDate.EditValue = Nothing
        Me.AccessDate.Location = New System.Drawing.Point(98, 7)
        Me.AccessDate.Name = "AccessDate"
        Me.AccessDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessDate.Properties.DisplayFormat.FormatString = ""
        Me.AccessDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccessDate.Properties.EditFormat.FormatString = ""
        Me.AccessDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccessDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.AccessDate.Properties.MaskSettings.Set("mask", "d")
        Me.AccessDate.Properties.UseMaskAsDisplayFormat = True
        Me.AccessDate.Size = New System.Drawing.Size(118, 20)
        Me.AccessDate.TabIndex = 1298
        '
        'InsertSource
        '
        Me.InsertSource.Location = New System.Drawing.Point(57, 51)
        Me.InsertSource.Name = "InsertSource"
        Me.InsertSource.Size = New System.Drawing.Size(12, 21)
        Me.InsertSource.TabIndex = 1297
        Me.InsertSource.Visible = False
        '
        'DeviceIP
        '
        Me.DeviceIP.Location = New System.Drawing.Point(43, 51)
        Me.DeviceIP.Name = "DeviceIP"
        Me.DeviceIP.Size = New System.Drawing.Size(12, 21)
        Me.DeviceIP.TabIndex = 1296
        Me.DeviceIP.Visible = False
        '
        'CardNumber
        '
        Me.CardNumber.Location = New System.Drawing.Point(24, 51)
        Me.CardNumber.Name = "CardNumber"
        Me.CardNumber.Size = New System.Drawing.Size(13, 21)
        Me.CardNumber.TabIndex = 1295
        Me.CardNumber.Visible = False
        '
        'Device_ID
        '
        Me.Device_ID.Location = New System.Drawing.Point(8, 51)
        Me.Device_ID.Name = "Device_ID"
        Me.Device_ID.Size = New System.Drawing.Size(12, 21)
        Me.Device_ID.TabIndex = 1294
        Me.Device_ID.Visible = False
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(489, 6)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(48, 16)
        Me.lblRemark.TabIndex = 1228
        Me.lblRemark.Text = "Ghi chú"
        '
        'lblAccessDate
        '
        Me.lblAccessDate.BackColor = System.Drawing.Color.Transparent
        Me.lblAccessDate.Location = New System.Drawing.Point(5, 4)
        Me.lblAccessDate.Name = "lblAccessDate"
        Me.lblAccessDate.Size = New System.Drawing.Size(87, 19)
        Me.lblAccessDate.TabIndex = 1223
        Me.lblAccessDate.Text = "Ngày"
        Me.lblAccessDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.Color.Transparent
        Me.lblReason.Location = New System.Drawing.Point(242, 32)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(64, 19)
        Me.lblReason.TabIndex = 1293
        Me.lblReason.Text = "Lý do"
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInOutStatus
        '
        Me.lblInOutStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblInOutStatus.Location = New System.Drawing.Point(242, 5)
        Me.lblInOutStatus.Name = "lblInOutStatus"
        Me.lblInOutStatus.Size = New System.Drawing.Size(99, 23)
        Me.lblInOutStatus.TabIndex = 1224
        Me.lblInOutStatus.Text = "Trạng thái Vào/Ra"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(543, 4)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(154, 42)
        Me.Remark.TabIndex = 13
        Me.Remark.Text = ""
        '
        'lblAccessTime
        '
        Me.lblAccessTime.BackColor = System.Drawing.Color.Transparent
        Me.lblAccessTime.Location = New System.Drawing.Point(5, 33)
        Me.lblAccessTime.Name = "lblAccessTime"
        Me.lblAccessTime.Size = New System.Drawing.Size(94, 19)
        Me.lblAccessTime.TabIndex = 1226
        Me.lblAccessTime.Text = "Giờ quẹt"
        Me.lblAccessTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1031, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 39
        Me.btnSave.Text = "Lưu"
        '
        'ListOfAccessTimeDeleted
        '
        Me.ListOfAccessTimeDeleted.Controls.Add(Me.GridControl2)
        Me.ListOfAccessTimeDeleted.Name = "ListOfAccessTimeDeleted"
        Me.ListOfAccessTimeDeleted.Size = New System.Drawing.Size(1229, 324)
        Me.ListOfAccessTimeDeleted.Text = "Danh sách xóa"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1229, 324)
        Me.GridControl2.TabIndex = 1325
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'GridView3
        '
        Me.GridView3.Name = "GridView3"
        '
        'para_TimeKeeping_Data2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1231, 404)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_DeleteStore = "usp_DeleteHR_TimeKeeping_Data"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmNhapDuLieuQuet"
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_TimeKeeping_Data"
        Me.HRFORM_TableName = "HR_TimeKeeping_Data"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "para_TimeKeeping_Data2"
        Me.Text = "TimeKeeping Data"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.TabAccessTime.ResumeLayout(False)
        Me.TabAccessTime.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.Reason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InOutStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccessTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccessDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccessDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ListOfAccessTimeDeleted.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim MaCongTy As String
    Dim TypeOfReport As Integer = 1
    Dim KHFromDate, KHToDate As DateTime

    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportRow("ReportCode") = "GetAccessTimeFromMachine" Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonlaydulieuchamcong"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
            LayDuLieuQuet(False)
        ElseIf ReportRow("ReportCode") = "GetAccessTimeFromMachine_FollowGrid" Then
            Dim frmDanhSachNV As New para_NhanVien
            'frmDanhSachNV.Set_FromDate(obj.PARA_FROMDATE)
            'frmDanhSachNV.Set_ToDate(obj.PARA_TODATE)
            frmDanhSachNV.ShowDialog()
            If frmDanhSachNV.bLuu = False Then
                Exit Sub
            End If
            If Not IsNothing(frmDanhSachNV.Get_DanhSachNhanVienDuocChon()) Then
                Dim str_DanhSachTheTuSQL As String
                Dim str_MaNhanVienSQL As String = "'" + frmDanhSachNV.Get_DanhSachNhanVienDuocChon().Replace(Environment.NewLine, "','") + "'"
                If frmDanhSachNV.Get_DanhSachTheTuDuocChon() <> String.Empty Then
                    str_DanhSachTheTuSQL = "'" + frmDanhSachNV.Get_DanhSachTheTuDuocChon().Replace(Environment.NewLine, "','") + "',"
                End If
                Dim tab_TheQuet As DataTable = kn.ReadData("select * from HR_CardCode where ExpiredDate between '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "' and '" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "' and Employee_ID in (" + str_MaNhanVienSQL + ")", "table")
                For Each row As DataRow In tab_TheQuet.Rows
                    If Not IsDBNull(row("Card_Code")) Then
                        str_DanhSachTheTuSQL += "'" + row("Card_Code") + "',"
                    End If
                Next
                If str_DanhSachTheTuSQL <> String.Empty Then
                    str_DanhSachTheTuSQL = str_DanhSachTheTuSQL.Remove(str_DanhSachTheTuSQL.Length - 1, 1)
                End If
                LayDuLieuQuet(False, str_MaNhanVienSQL, str_DanhSachTheTuSQL)
            End If
        ElseIf ReportRow("ReportCode") = "InputAccessTimeFromExcelFile" Then
            NhapDuLieuQuetThe()
        ElseIf ReportRow("ReportCode") = "AccessTimeGetTemplateFollowTime" Then
            LayTemplateQuetVaoRaTheoChieuNgang(obj.PARA_FROMDATE, obj.PARA_TODATE)
        ElseIf ReportRow("ReportCode") = "AccessTimeImportTemplateFollowTime" Then
            NhapDuLieuQuetTheTheoChieuNgang()
        End If
    End Sub

    Private Sub LayDuLieuQuet(ByVal CapNhapDuLieu As Double, Optional ByVal DanhSachMaNhanVienSQL As String = "", Optional ByVal DanhSachMaTheTuSQL As String = "")
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If tvcn.CheckingBlock("HR_TimeKeeping_Data", obj.PARA_FROMDATE) = True Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim f As New frmPBar
        f.TKD_XuatBangCong_DanhSachNhanVienSQL = DanhSachMaNhanVienSQL
        f.DLQVT_DanhSachTheTuSQL = DanhSachMaTheTuSQL
        f.FormKeyCall = "DLQVT_LayDuLieuQuet"
        f.DLQVT_BangDuLieuQuet = "HR_TimeKeeping_Data"
        f.DLQVT_TuNgay = obj.PARA_FROMDATE
        f.DLQVT_DenNgay = obj.PARA_TODATE
        f.FACT = obj.PARA_FACTORY_ID
        f.DEPT = obj.PARA_DEPARTMENTCODE
        f.SECT = obj.PARA_SECTIONCODE
        f.TEAM = obj.PARA_TEAMCODE
        f.POS = obj.PARA_POSITION_ID
        f.POSC = obj.PARA_POSITIONCATEGORY_ID
        f.MaCongTy = MaCongTy
        f.Show()
    End Sub

    Private Sub NhapDuLieuQuetThe()
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim ofd As New OpenFileDialog
        With ofd
            ' .FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = 7
                Dim Employee_ID, InsertSource, InsertBy As String
                Dim AccessDate, InsertDate, AccessTime, OldAccessTime As DateTime
                Dim ojDate, ojTime As Object
                InsertBy = obj.UserName
                InsertDate = Now
                Dim datamember As String() = {"Employee_ID", "AccessDate", "AccessTime", "CardNumber", "InsertSource", "UserName", "InsertDate"}
                Dim datamember_Value As New ArrayList
                Dim primary As String() = {"Employee_ID", "AccessTime"}
                Dim primary_Value As New ArrayList
                While worksheet.Cells("C" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = worksheet.Cells("B" + index.ToString).Text.Trim
                    ojDate = worksheet.Cells("C" + index.ToString).Value
                    If tvcn.CheckingBlock("HR_TimeKeeping_Data", ojDate) = True Then
                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    If Not IsNothing(ojDate) Then
                        AccessDate = ojDate
                        ojTime = worksheet.Cells("D" + index.ToString).Value
                        If Not IsNothing(ojTime) Then
                            If ojTime.GetType.ToString = "System.Double" Then
                                AccessTime = DateTime.FromOADate(ojTime)
                            Else
                                AccessTime = CType(ojTime, DateTime)
                            End If
                            OldAccessTime = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second)
                            datamember_Value.Clear()
                            datamember_Value.Add(Employee_ID)
                            datamember_Value.Add(AccessDate)
                            datamember_Value.Add(OldAccessTime)
                            datamember_Value.Add(Employee_ID)
                            datamember_Value.Add("NhapTay")
                            datamember_Value.Add(InsertBy)
                            datamember_Value.Add(InsertDate)

                            primary_Value.Clear()
                            primary_Value.Add(Employee_ID)
                            primary_Value.Add(New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second))
                            If tvcn.LuuKhongGhiLog(False, "HR_TimeKeeping_Data", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                                If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                                    Exit Sub
                                End If
                            End If
                        End If

                        ojTime = worksheet.Cells("E" + index.ToString).Value
                        If Not IsNothing(ojTime) Then
                            If ojTime.GetType.ToString = "System.Double" Then
                                AccessTime = DateTime.FromOADate(ojTime)
                            Else
                                AccessTime = CType(ojTime, DateTime)
                            End If
                            If AccessTime.Hour < OldAccessTime.Hour Then
                                AccessDate = AccessDate.AddDays(1)
                            End If
                            AccessTime = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second)
                            datamember_Value.Clear()
                            datamember_Value.Add(Employee_ID)
                            datamember_Value.Add(AccessDate)
                            datamember_Value.Add(AccessTime)
                            datamember_Value.Add(Employee_ID)
                            datamember_Value.Add("NhapTay")
                            datamember_Value.Add(InsertBy)
                            datamember_Value.Add(InsertDate)

                            primary_Value.Clear()
                            primary_Value.Add(Employee_ID)
                            primary_Value.Add(New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second))
                            If tvcn.LuuKhongGhiLog(False, "HR_TimeKeeping_Data", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                                If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                    index += 1
                End While
            End Using
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub LayTemplateQuetVaoRaTheoChieuNgang(ByVal fromdate As DateTime, ByVal todate As DateTime)
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.DefaultExt = "xls"
        fileChooser.FileName = "NhapQuetVaoRaTheoChieuNgang.xlsx"
        Dim result As DialogResult
        result = fileChooser.ShowDialog()
        fileChooser.CheckFileExists = True
        If result = DialogResult.OK Then
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"}
            Using fs As FileStream = File.OpenRead(Application.StartupPath() + "\Teamleate\NhapQuetVaoRaTheoChieuNgang.xlsx")
                Using package As New ExcelPackage(fs)
                    Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
                    Dim indexCol As Integer = 1
                    Dim dNext As DateTime
                    dNext = fromdate
                    While dNext <= todate
                        ws.Cells(ColExel(indexCol) + "7").Value = dNext
                        ws.Cells(ColExel(indexCol) + "8").Value = "IN"
                        ws.Cells(ColExel(indexCol + 1) + "8").Value = "OUT"
                        'vẽ border
                        ws.Cells(ColExel(indexCol) + "7").Style.Border.Top.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol) + "7").Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol) + "7").Style.Border.Right.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol + 1) + "7").Style.Border.Top.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol + 1) + "7").Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol + 1) + "7").Style.Border.Right.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol) + "8").Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol) + "8").Style.Border.Right.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol + 1) + "8").Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        ws.Cells(ColExel(indexCol + 1) + "8").Style.Border.Right.Style = ExcelBorderStyle.Thin
                        indexCol += 2
                        dNext = dNext.AddDays(1)
                    End While
                    Dim fi As New FileInfo(fileChooser.FileName)
                    package.SaveAs(fi)
                    System.Diagnostics.Process.Start(fileChooser.FileName)
                End Using
            End Using
        End If
    End Sub
    Private Sub NhapDuLieuQuetTheTheoChieuNgang()
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
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
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"}
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
                Dim index As Integer = 9
                Dim colIndex As Integer = 1
                Dim Employee_ID, InsertSource, InsertBy As String
                Dim AccessDate, InsertDate, AccessTime, OldAccessTime As DateTime
                Dim ojDate, ojTime As Object
                InsertBy = obj.UserName
                InsertDate = Now
                Dim datamember As String() = {"Employee_ID", "AccessDate", "AccessTime", "CardNumber", "InsertSource", "InOutStatus", "UserName", "InsertDate"}
                Dim datamember_Value As New ArrayList
                Dim primary As String() = {"Employee_ID", "AccessTime"}
                Dim primary_Value As New ArrayList

                While ws.Cells("A" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = ws.Cells("A" + index.ToString).Text.Trim
                    For colIndex = 1 To ColExel.Length - 1
                        ojDate = ws.Cells(ColExel(colIndex) + "7").Value
                        If Not IsNothing(ojDate) Then
                            AccessDate = ojDate
                            ojTime = ws.Cells(ColExel(colIndex) + index.ToString()).Value
                            If Not IsNothing(ojTime) Then
                                If ojTime.GetType.ToString = "System.Double" Then
                                    AccessTime = DateTime.FromOADate(ojTime)
                                Else
                                    AccessTime = CType(ojTime, DateTime)
                                End If
                                OldAccessTime = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second)
                                datamember_Value.Clear()
                                datamember_Value.Add(Employee_ID)
                                datamember_Value.Add(AccessDate)
                                datamember_Value.Add(OldAccessTime)
                                datamember_Value.Add(Employee_ID)
                                datamember_Value.Add("NhapTay")
                                datamember_Value.Add(0)
                                datamember_Value.Add(InsertBy)
                                datamember_Value.Add(InsertDate)

                                primary_Value.Clear()
                                primary_Value.Add(Employee_ID)
                                primary_Value.Add(New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second))
                                If tvcn.LuuKhongGhiLog(False, "HR_TimeKeeping_Data", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                                    If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                                        Exit Sub
                                    End If
                                End If
                            End If

                            ojTime = ws.Cells(ColExel(colIndex + 1) + index.ToString()).Value
                            If Not IsNothing(ojTime) Then
                                If ojTime.GetType.ToString = "System.Double" Then
                                    AccessTime = DateTime.FromOADate(ojTime)
                                Else
                                    AccessTime = CType(ojTime, DateTime)
                                End If
                                If AccessTime.Hour < OldAccessTime.Hour Then
                                    AccessDate = AccessDate.AddDays(1)
                                End If
                                AccessTime = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second)
                                datamember_Value.Clear()
                                datamember_Value.Add(Employee_ID)
                                datamember_Value.Add(AccessDate)
                                datamember_Value.Add(AccessTime)
                                datamember_Value.Add(Employee_ID)
                                datamember_Value.Add("NhapTay")
                                datamember_Value.Add(1)
                                datamember_Value.Add(InsertBy)
                                datamember_Value.Add(InsertDate)

                                primary_Value.Clear()
                                primary_Value.Add(Employee_ID)
                                primary_Value.Add(New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second))
                                If tvcn.LuuKhongGhiLog(False, "HR_TimeKeeping_Data", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                                    If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Else
                            Exit For
                        End If
                        colIndex += 1
                    Next
                    index += 1
                End While
            End Using
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub para_TimeKeeping_Data2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        tvcn.GetDataOnDropDownCategoryCodeName(Reason, "ReasonOfEditAccessTime")
        tvcn.GetDataOnDropDownCategoryCodeName(InOutStatus, "InOutStatus")
        If Today >= KHFromDate And Today <= KHToDate Then
            TableLayoutPanel2.Visible = False
            HRFORM_GridControl.Visible = False
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = False
            btnSave.Visible = False
            btnRemove.Visible = False
            btnRefresh.Visible = False
            XtraTabControl1.TabPages("ListOfAccessTimeDeleted").Visible = False
        End If
        tvcn.SearchEmployee(Employee_ID)
        lblEmployee_ID.Text = lblEmployee_ID.Text + " *"
        LoadGiaoDienTheoDieuKien()
        Search(TypeOfReport)
    End Sub

    Public Overrides Sub AfterViewForm()
        If XtraTabControl1.SelectedTabPage.Name = "TabAccessTime" Then
            If Today >= KHFromDate And Today <= KHToDate Then
                If IsNothing(HRFORM_Gridview.Columns("InsertSource")) = False Then
                    HRFORM_Gridview.Columns("InsertSource").Visible = False
                End If
            End If
            If IsNothing(HRFORM_Gridview.Columns("InOutStatus")) = False Then
                tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "InOutStatus", kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='InOutStatus'", "table"))
            End If
            If IsNothing(HRFORM_Gridview.Columns("InsertSource")) = False Then
                HRFORM_Gridview.Columns("InsertSource").OptionsColumn.AllowEdit = False
            End If
            If IsNothing(HRFORM_Gridview.Columns("Reason")) = False Then
                tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "Reason", kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='ReasonOfEditAccessTime'", "table"))
            End If
            If IsNothing(HRFORM_Gridview.Columns("AccessTime")) = False Then
                HRFORM_Gridview.Columns("AccessTime").Visible = False
            End If
        End If
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search(TypeOfReport)
    End Sub

    Private Sub Search(ByVal TypeOfReport As Integer)
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd, td As DateTime
        If AccessDate.DateTime.Year = 1 Then
            AccessDate.DateTime = Today
        End If
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(AccessDate.DateTime.Year, AccessDate.DateTime.Month, 2), New DateTime(AccessDate.DateTime.Year, AccessDate.DateTime.Month, 1).AddMonths(1).AddDays(-1))
        fd = New DateTime(AccessDate.DateTime.Year, AccessDate.DateTime.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If
        Dim QR As String = "exec [dbo].[sp_BangDuLieuQuet] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "'," + TypeOfReport.ToString + ",'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        CardNumber.Text = Employee_ID.Text
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_TimeKeeping_Data]", TableLayoutPanel2, ErrorProvider1) Then
            Search(TypeOfReport)
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search(TypeOfReport)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        MaCongTy = tvcn.getSetUp("MaCongTy")
        Dim KH As String = tvcn.getSetUp("KH")
        KHFromDate = CType(KH.Split("#"c)(0), Date)
        KHToDate = CType(KH.Split("#"c)(1), Date)
        If e.Page.Name = "TabAccessTime" Then
            HRFORM_TableName = "HR_TimeKeeping_Data"
            HRFORM_GridControl = GridControl1
            HRFORM_Gridview = GridView1
            HRFORM_InputForm = "frmNhapDuLieuQuet"
            HRFORM_SaveStore = "usp_InsertUpdateHR_TimeKeeping_Data"
            HRFORM_DeleteStore = "usp_DeleteHR_TimeKeeping_Data"
            btnGetTemplate.Visible = True
            btnImportExcel.Visible = True
            TypeOfReport = 1
        Else
            HRFORM_TableName = "HR_TimeKeeping_Data_Delete"
            HRFORM_GridControl = GridControl2
            HRFORM_Gridview = GridView2
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnAdd.Visible = False
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = False
            HRFORM_SaveStore = ""
            HRFORM_DeleteStore = ""
            TypeOfReport = 5
        End If
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search(TypeOfReport)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            Dim CotTimeSpan As TimeSpan
            Dim CotDateTime As DateTime
            If Not IsNothing(GridView1.Columns("AccessTime")) And Not IsNothing(GridView1.Columns("AccessTime_Edit")) Then
                If e.Column.Name = "colAccessTime_Edit" Then
                    CotTimeSpan = GridView1.GetFocusedDataRow().Item("AccessTime_Edit")
                    CotDateTime = GridView1.GetFocusedDataRow().Item("AccessTime")
                    GridView1.GetFocusedDataRow().Item("AccessTime") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
