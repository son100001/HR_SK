<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapDuLieuCong
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
        Me.Day28 = New System.Windows.Forms.TextBox()
        Me.Day29 = New System.Windows.Forms.TextBox()
        Me.Day30 = New System.Windows.Forms.TextBox()
        Me.Day31 = New System.Windows.Forms.TextBox()
        Me.Day25 = New System.Windows.Forms.TextBox()
        Me.Day26 = New System.Windows.Forms.TextBox()
        Me.Day27 = New System.Windows.Forms.TextBox()
        Me.Day22 = New System.Windows.Forms.TextBox()
        Me.Day23 = New System.Windows.Forms.TextBox()
        Me.Day24 = New System.Windows.Forms.TextBox()
        Me.Day18 = New System.Windows.Forms.TextBox()
        Me.Day19 = New System.Windows.Forms.TextBox()
        Me.Day20 = New System.Windows.Forms.TextBox()
        Me.Day21 = New System.Windows.Forms.TextBox()
        Me.Day14 = New System.Windows.Forms.TextBox()
        Me.Day15 = New System.Windows.Forms.TextBox()
        Me.Day16 = New System.Windows.Forms.TextBox()
        Me.Day17 = New System.Windows.Forms.TextBox()
        Me.Day10 = New System.Windows.Forms.TextBox()
        Me.Day11 = New System.Windows.Forms.TextBox()
        Me.Day12 = New System.Windows.Forms.TextBox()
        Me.Day13 = New System.Windows.Forms.TextBox()
        Me.Day6 = New System.Windows.Forms.TextBox()
        Me.Day7 = New System.Windows.Forms.TextBox()
        Me.Day8 = New System.Windows.Forms.TextBox()
        Me.Day9 = New System.Windows.Forms.TextBox()
        Me.Day5 = New System.Windows.Forms.TextBox()
        Me.Day4 = New System.Windows.Forms.TextBox()
        Me.Day3 = New System.Windows.Forms.TextBox()
        Me.Day2 = New System.Windows.Forms.TextBox()
        Me.Day1 = New System.Windows.Forms.TextBox()
        Me.LoaiGio = New System.Windows.Forms.TextBox()
        Me.Nam = New System.Windows.Forms.TextBox()
        Me.Thang = New System.Windows.Forms.TextBox()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLuuDuLieuQuet = New DevExpress.XtraEditors.SimpleButton()
        Me.ChuyenCan = New System.Windows.Forms.TextBox()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        Me.pnLuu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Size = New System.Drawing.Size(1288, 51)
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(1288, 355)
        Me.XtraTabControl1.TabIndex = 1011
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1286, 330)
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
        Me.GridControl1.Size = New System.Drawing.Size(1286, 182)
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
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 468.0!))
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1286, 85)
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
        Me.pnDuLieuNhap.Controls.Add(Me.ChuyenCan)
        Me.pnDuLieuNhap.Controls.Add(Me.Day28)
        Me.pnDuLieuNhap.Controls.Add(Me.Day29)
        Me.pnDuLieuNhap.Controls.Add(Me.Day30)
        Me.pnDuLieuNhap.Controls.Add(Me.Day31)
        Me.pnDuLieuNhap.Controls.Add(Me.Day25)
        Me.pnDuLieuNhap.Controls.Add(Me.Day26)
        Me.pnDuLieuNhap.Controls.Add(Me.Day27)
        Me.pnDuLieuNhap.Controls.Add(Me.Day22)
        Me.pnDuLieuNhap.Controls.Add(Me.Day23)
        Me.pnDuLieuNhap.Controls.Add(Me.Day24)
        Me.pnDuLieuNhap.Controls.Add(Me.Day18)
        Me.pnDuLieuNhap.Controls.Add(Me.Day19)
        Me.pnDuLieuNhap.Controls.Add(Me.Day20)
        Me.pnDuLieuNhap.Controls.Add(Me.Day21)
        Me.pnDuLieuNhap.Controls.Add(Me.Day14)
        Me.pnDuLieuNhap.Controls.Add(Me.Day15)
        Me.pnDuLieuNhap.Controls.Add(Me.Day16)
        Me.pnDuLieuNhap.Controls.Add(Me.Day17)
        Me.pnDuLieuNhap.Controls.Add(Me.Day10)
        Me.pnDuLieuNhap.Controls.Add(Me.Day11)
        Me.pnDuLieuNhap.Controls.Add(Me.Day12)
        Me.pnDuLieuNhap.Controls.Add(Me.Day13)
        Me.pnDuLieuNhap.Controls.Add(Me.Day6)
        Me.pnDuLieuNhap.Controls.Add(Me.Day7)
        Me.pnDuLieuNhap.Controls.Add(Me.Day8)
        Me.pnDuLieuNhap.Controls.Add(Me.Day9)
        Me.pnDuLieuNhap.Controls.Add(Me.Day5)
        Me.pnDuLieuNhap.Controls.Add(Me.Day4)
        Me.pnDuLieuNhap.Controls.Add(Me.Day3)
        Me.pnDuLieuNhap.Controls.Add(Me.Day2)
        Me.pnDuLieuNhap.Controls.Add(Me.Day1)
        Me.pnDuLieuNhap.Controls.Add(Me.LoaiGio)
        Me.pnDuLieuNhap.Controls.Add(Me.Nam)
        Me.pnDuLieuNhap.Controls.Add(Me.Thang)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(418, 75)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'Day28
        '
        Me.Day28.Location = New System.Drawing.Point(333, 34)
        Me.Day28.Name = "Day28"
        Me.Day28.Size = New System.Drawing.Size(11, 21)
        Me.Day28.TabIndex = 1312
        Me.Day28.Visible = False
        '
        'Day29
        '
        Me.Day29.Location = New System.Drawing.Point(350, 35)
        Me.Day29.Name = "Day29"
        Me.Day29.Size = New System.Drawing.Size(11, 21)
        Me.Day29.TabIndex = 1311
        Me.Day29.Visible = False
        '
        'Day30
        '
        Me.Day30.Location = New System.Drawing.Point(367, 34)
        Me.Day30.Name = "Day30"
        Me.Day30.Size = New System.Drawing.Size(11, 21)
        Me.Day30.TabIndex = 1310
        Me.Day30.Visible = False
        '
        'Day31
        '
        Me.Day31.Location = New System.Drawing.Point(384, 34)
        Me.Day31.Name = "Day31"
        Me.Day31.Size = New System.Drawing.Size(11, 21)
        Me.Day31.TabIndex = 1309
        Me.Day31.Visible = False
        '
        'Day25
        '
        Me.Day25.Location = New System.Drawing.Point(281, 34)
        Me.Day25.Name = "Day25"
        Me.Day25.Size = New System.Drawing.Size(11, 21)
        Me.Day25.TabIndex = 1308
        Me.Day25.Visible = False
        '
        'Day26
        '
        Me.Day26.Location = New System.Drawing.Point(299, 34)
        Me.Day26.Name = "Day26"
        Me.Day26.Size = New System.Drawing.Size(11, 21)
        Me.Day26.TabIndex = 1307
        Me.Day26.Visible = False
        '
        'Day27
        '
        Me.Day27.Location = New System.Drawing.Point(316, 34)
        Me.Day27.Name = "Day27"
        Me.Day27.Size = New System.Drawing.Size(11, 21)
        Me.Day27.TabIndex = 1306
        Me.Day27.Visible = False
        '
        'Day22
        '
        Me.Day22.Location = New System.Drawing.Point(230, 34)
        Me.Day22.Name = "Day22"
        Me.Day22.Size = New System.Drawing.Size(11, 21)
        Me.Day22.TabIndex = 1305
        Me.Day22.Visible = False
        '
        'Day23
        '
        Me.Day23.Location = New System.Drawing.Point(247, 34)
        Me.Day23.Name = "Day23"
        Me.Day23.Size = New System.Drawing.Size(11, 21)
        Me.Day23.TabIndex = 1304
        Me.Day23.Visible = False
        '
        'Day24
        '
        Me.Day24.Location = New System.Drawing.Point(264, 34)
        Me.Day24.Name = "Day24"
        Me.Day24.Size = New System.Drawing.Size(11, 21)
        Me.Day24.TabIndex = 1303
        Me.Day24.Visible = False
        '
        'Day18
        '
        Me.Day18.Location = New System.Drawing.Point(162, 34)
        Me.Day18.Name = "Day18"
        Me.Day18.Size = New System.Drawing.Size(11, 21)
        Me.Day18.TabIndex = 1302
        Me.Day18.Visible = False
        '
        'Day19
        '
        Me.Day19.Location = New System.Drawing.Point(179, 34)
        Me.Day19.Name = "Day19"
        Me.Day19.Size = New System.Drawing.Size(11, 21)
        Me.Day19.TabIndex = 1301
        Me.Day19.Visible = False
        '
        'Day20
        '
        Me.Day20.Location = New System.Drawing.Point(196, 34)
        Me.Day20.Name = "Day20"
        Me.Day20.Size = New System.Drawing.Size(11, 21)
        Me.Day20.TabIndex = 1300
        Me.Day20.Visible = False
        '
        'Day21
        '
        Me.Day21.Location = New System.Drawing.Point(213, 34)
        Me.Day21.Name = "Day21"
        Me.Day21.Size = New System.Drawing.Size(11, 21)
        Me.Day21.TabIndex = 1299
        Me.Day21.Visible = False
        '
        'Day14
        '
        Me.Day14.Location = New System.Drawing.Point(350, 7)
        Me.Day14.Name = "Day14"
        Me.Day14.Size = New System.Drawing.Size(11, 21)
        Me.Day14.TabIndex = 1298
        Me.Day14.Visible = False
        '
        'Day15
        '
        Me.Day15.Location = New System.Drawing.Point(367, 7)
        Me.Day15.Name = "Day15"
        Me.Day15.Size = New System.Drawing.Size(11, 21)
        Me.Day15.TabIndex = 1297
        Me.Day15.Visible = False
        '
        'Day16
        '
        Me.Day16.Location = New System.Drawing.Point(128, 34)
        Me.Day16.Name = "Day16"
        Me.Day16.Size = New System.Drawing.Size(11, 21)
        Me.Day16.TabIndex = 1296
        Me.Day16.Visible = False
        '
        'Day17
        '
        Me.Day17.Location = New System.Drawing.Point(145, 34)
        Me.Day17.Name = "Day17"
        Me.Day17.Size = New System.Drawing.Size(11, 21)
        Me.Day17.TabIndex = 1295
        Me.Day17.Visible = False
        '
        'Day10
        '
        Me.Day10.Location = New System.Drawing.Point(281, 7)
        Me.Day10.Name = "Day10"
        Me.Day10.Size = New System.Drawing.Size(11, 21)
        Me.Day10.TabIndex = 1294
        Me.Day10.Visible = False
        '
        'Day11
        '
        Me.Day11.Location = New System.Drawing.Point(299, 7)
        Me.Day11.Name = "Day11"
        Me.Day11.Size = New System.Drawing.Size(11, 21)
        Me.Day11.TabIndex = 1293
        Me.Day11.Visible = False
        '
        'Day12
        '
        Me.Day12.Location = New System.Drawing.Point(316, 7)
        Me.Day12.Name = "Day12"
        Me.Day12.Size = New System.Drawing.Size(11, 21)
        Me.Day12.TabIndex = 1292
        Me.Day12.Visible = False
        '
        'Day13
        '
        Me.Day13.Location = New System.Drawing.Point(333, 7)
        Me.Day13.Name = "Day13"
        Me.Day13.Size = New System.Drawing.Size(11, 21)
        Me.Day13.TabIndex = 1291
        Me.Day13.Visible = False
        '
        'Day6
        '
        Me.Day6.Location = New System.Drawing.Point(213, 7)
        Me.Day6.Name = "Day6"
        Me.Day6.Size = New System.Drawing.Size(11, 21)
        Me.Day6.TabIndex = 1290
        Me.Day6.Visible = False
        '
        'Day7
        '
        Me.Day7.Location = New System.Drawing.Point(230, 7)
        Me.Day7.Name = "Day7"
        Me.Day7.Size = New System.Drawing.Size(11, 21)
        Me.Day7.TabIndex = 1289
        Me.Day7.Visible = False
        '
        'Day8
        '
        Me.Day8.Location = New System.Drawing.Point(247, 7)
        Me.Day8.Name = "Day8"
        Me.Day8.Size = New System.Drawing.Size(11, 21)
        Me.Day8.TabIndex = 1288
        Me.Day8.Visible = False
        '
        'Day9
        '
        Me.Day9.Location = New System.Drawing.Point(264, 7)
        Me.Day9.Name = "Day9"
        Me.Day9.Size = New System.Drawing.Size(11, 21)
        Me.Day9.TabIndex = 1287
        Me.Day9.Visible = False
        '
        'Day5
        '
        Me.Day5.Location = New System.Drawing.Point(196, 7)
        Me.Day5.Name = "Day5"
        Me.Day5.Size = New System.Drawing.Size(11, 21)
        Me.Day5.TabIndex = 1286
        Me.Day5.Visible = False
        '
        'Day4
        '
        Me.Day4.Location = New System.Drawing.Point(179, 7)
        Me.Day4.Name = "Day4"
        Me.Day4.Size = New System.Drawing.Size(11, 21)
        Me.Day4.TabIndex = 1285
        Me.Day4.Visible = False
        '
        'Day3
        '
        Me.Day3.Location = New System.Drawing.Point(162, 7)
        Me.Day3.Name = "Day3"
        Me.Day3.Size = New System.Drawing.Size(11, 21)
        Me.Day3.TabIndex = 1284
        Me.Day3.Visible = False
        '
        'Day2
        '
        Me.Day2.Location = New System.Drawing.Point(145, 7)
        Me.Day2.Name = "Day2"
        Me.Day2.Size = New System.Drawing.Size(11, 21)
        Me.Day2.TabIndex = 1283
        Me.Day2.Visible = False
        '
        'Day1
        '
        Me.Day1.Location = New System.Drawing.Point(128, 7)
        Me.Day1.Name = "Day1"
        Me.Day1.Size = New System.Drawing.Size(11, 21)
        Me.Day1.TabIndex = 1282
        Me.Day1.Visible = False
        '
        'LoaiGio
        '
        Me.LoaiGio.Location = New System.Drawing.Point(69, 7)
        Me.LoaiGio.Name = "LoaiGio"
        Me.LoaiGio.Size = New System.Drawing.Size(53, 21)
        Me.LoaiGio.TabIndex = 1281
        Me.LoaiGio.Visible = False
        '
        'Nam
        '
        Me.Nam.Location = New System.Drawing.Point(3, 34)
        Me.Nam.Name = "Nam"
        Me.Nam.Size = New System.Drawing.Size(60, 21)
        Me.Nam.TabIndex = 1280
        Me.Nam.Visible = False
        '
        'Thang
        '
        Me.Thang.Location = New System.Drawing.Point(3, 7)
        Me.Thang.Name = "Thang"
        Me.Thang.Size = New System.Drawing.Size(60, 21)
        Me.Thang.TabIndex = 1279
        Me.Thang.Visible = False
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(749, 4)
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
        Me.Panel1.Location = New System.Drawing.Point(824, 4)
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
        'ChuyenCan
        '
        Me.ChuyenCan.Location = New System.Drawing.Point(393, 7)
        Me.ChuyenCan.Name = "ChuyenCan"
        Me.ChuyenCan.Size = New System.Drawing.Size(11, 21)
        Me.ChuyenCan.TabIndex = 1313
        Me.ChuyenCan.Visible = False
        '
        'frmNhapDuLieuCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1288, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_GioDayDuLieu"
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.Name = "frmNhapDuLieuCong"
        Me.Text = "frmNhapDuLieuCong"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
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
        Me.pnLuu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnTinhCong As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbTypeOfReport As CheckBox
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLuuDuLieuQuet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Day28 As TextBox
    Friend WithEvents Day29 As TextBox
    Friend WithEvents Day30 As TextBox
    Friend WithEvents Day31 As TextBox
    Friend WithEvents Day25 As TextBox
    Friend WithEvents Day26 As TextBox
    Friend WithEvents Day27 As TextBox
    Friend WithEvents Day22 As TextBox
    Friend WithEvents Day23 As TextBox
    Friend WithEvents Day24 As TextBox
    Friend WithEvents Day18 As TextBox
    Friend WithEvents Day19 As TextBox
    Friend WithEvents Day20 As TextBox
    Friend WithEvents Day21 As TextBox
    Friend WithEvents Day14 As TextBox
    Friend WithEvents Day15 As TextBox
    Friend WithEvents Day16 As TextBox
    Friend WithEvents Day17 As TextBox
    Friend WithEvents Day10 As TextBox
    Friend WithEvents Day11 As TextBox
    Friend WithEvents Day12 As TextBox
    Friend WithEvents Day13 As TextBox
    Friend WithEvents Day6 As TextBox
    Friend WithEvents Day7 As TextBox
    Friend WithEvents Day8 As TextBox
    Friend WithEvents Day9 As TextBox
    Friend WithEvents Day5 As TextBox
    Friend WithEvents Day4 As TextBox
    Friend WithEvents Day3 As TextBox
    Friend WithEvents Day2 As TextBox
    Friend WithEvents Day1 As TextBox
    Friend WithEvents LoaiGio As TextBox
    Friend WithEvents Nam As TextBox
    Friend WithEvents Thang As TextBox
    Friend WithEvents ChuyenCan As TextBox
End Class
