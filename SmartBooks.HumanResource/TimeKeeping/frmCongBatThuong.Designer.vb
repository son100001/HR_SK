<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCongBatThuong
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
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelAccessTime = New System.Windows.Forms.Panel()
        Me.gridMaxOverTime = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridAccessTime = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdbAccessTimeOneDay = New System.Windows.Forms.RadioButton()
        Me.rdbAccessTimeThreeDay = New System.Windows.Forms.RadioButton()
        Me.rdbAccessTimeInMonth = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnLuaChonSua = New System.Windows.Forms.Panel()
        Me.rdbSuaDuLieuQuet = New System.Windows.Forms.RadioButton()
        Me.pnSuaGioQuet = New System.Windows.Forms.Panel()
        Me.InOutStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbGioTangCa = New System.Windows.Forms.CheckBox()
        Me.maxovertime = New System.Windows.Forms.NumericUpDown()
        Me.rdbNhapTheoGioNhap = New System.Windows.Forms.RadioButton()
        Me.lblInOutStatus = New System.Windows.Forms.Label()
        Me.rdbNhapTuDong = New System.Windows.Forms.RadioButton()
        Me.rdbNhapTheoDungGioCa = New System.Windows.Forms.RadioButton()
        Me.AccessTime = New DevExpress.XtraEditors.TimeEdit()
        Me.pnSuaCa = New System.Windows.Forms.Panel()
        Me.ShiftName = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.pnLyDoGhiChu = New System.Windows.Forms.Panel()
        Me.Reason = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.pnNhapLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNhap = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoaDKTangCa = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLuuDKTC = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAccessTime.SuspendLayout()
        CType(Me.gridMaxOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridAccessTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnLuaChonSua.SuspendLayout()
        Me.pnSuaGioQuet.SuspendLayout()
        CType(Me.InOutStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maxovertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccessTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSuaCa.SuspendLayout()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLyDoGhiChu.SuspendLayout()
        CType(Me.Reason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNhapLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 469)
        Me.PanelButton.Size = New System.Drawing.Size(1332, 52)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1332, 521)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl3)
        Me.General.Controls.Add(Me.PanelAccessTime)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1330, 496)
        Me.General.Text = "General"
        '
        'GridControl3
        '
        Me.GridControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl3.Location = New System.Drawing.Point(0, 137)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1325, 230)
        Me.GridControl3.TabIndex = 1323
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        '
        'PanelAccessTime
        '
        Me.PanelAccessTime.Controls.Add(Me.gridMaxOverTime)
        Me.PanelAccessTime.Controls.Add(Me.gridAccessTime)
        Me.PanelAccessTime.Controls.Add(Me.Panel2)
        Me.PanelAccessTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelAccessTime.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccessTime.Name = "PanelAccessTime"
        Me.PanelAccessTime.Size = New System.Drawing.Size(1330, 131)
        Me.PanelAccessTime.TabIndex = 43
        '
        'gridMaxOverTime
        '
        Me.gridMaxOverTime.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridMaxOverTime.Location = New System.Drawing.Point(733, 3)
        Me.gridMaxOverTime.MainView = Me.GridView2
        Me.gridMaxOverTime.Name = "gridMaxOverTime"
        Me.gridMaxOverTime.Size = New System.Drawing.Size(575, 125)
        Me.gridMaxOverTime.TabIndex = 1324
        Me.gridMaxOverTime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridMaxOverTime
        Me.GridView2.Name = "GridView2"
        '
        'gridAccessTime
        '
        Me.gridAccessTime.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridAccessTime.Location = New System.Drawing.Point(206, 3)
        Me.gridAccessTime.MainView = Me.GridView1
        Me.gridAccessTime.Name = "gridAccessTime"
        Me.gridAccessTime.Size = New System.Drawing.Size(521, 125)
        Me.gridAccessTime.TabIndex = 1323
        Me.gridAccessTime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridAccessTime
        Me.GridView1.Name = "GridView1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdbAccessTimeOneDay)
        Me.Panel2.Controls.Add(Me.rdbAccessTimeThreeDay)
        Me.Panel2.Controls.Add(Me.rdbAccessTimeInMonth)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 131)
        Me.Panel2.TabIndex = 0
        '
        'rdbAccessTimeOneDay
        '
        Me.rdbAccessTimeOneDay.AutoSize = True
        Me.rdbAccessTimeOneDay.BackColor = System.Drawing.Color.Transparent
        Me.rdbAccessTimeOneDay.Checked = True
        Me.rdbAccessTimeOneDay.Location = New System.Drawing.Point(11, 12)
        Me.rdbAccessTimeOneDay.Name = "rdbAccessTimeOneDay"
        Me.rdbAccessTimeOneDay.Size = New System.Drawing.Size(101, 17)
        Me.rdbAccessTimeOneDay.TabIndex = 39
        Me.rdbAccessTimeOneDay.TabStop = True
        Me.rdbAccessTimeOneDay.Text = "Xem trong ngày"
        Me.rdbAccessTimeOneDay.UseVisualStyleBackColor = False
        '
        'rdbAccessTimeThreeDay
        '
        Me.rdbAccessTimeThreeDay.AutoSize = True
        Me.rdbAccessTimeThreeDay.BackColor = System.Drawing.Color.Transparent
        Me.rdbAccessTimeThreeDay.Location = New System.Drawing.Point(11, 35)
        Me.rdbAccessTimeThreeDay.Name = "rdbAccessTimeThreeDay"
        Me.rdbAccessTimeThreeDay.Size = New System.Drawing.Size(110, 17)
        Me.rdbAccessTimeThreeDay.TabIndex = 40
        Me.rdbAccessTimeThreeDay.Text = "Xem trong 3 ngày"
        Me.rdbAccessTimeThreeDay.UseVisualStyleBackColor = False
        '
        'rdbAccessTimeInMonth
        '
        Me.rdbAccessTimeInMonth.AutoSize = True
        Me.rdbAccessTimeInMonth.BackColor = System.Drawing.Color.Transparent
        Me.rdbAccessTimeInMonth.Location = New System.Drawing.Point(11, 58)
        Me.rdbAccessTimeInMonth.Name = "rdbAccessTimeInMonth"
        Me.rdbAccessTimeInMonth.Size = New System.Drawing.Size(105, 17)
        Me.rdbAccessTimeInMonth.TabIndex = 41
        Me.rdbAccessTimeInMonth.Text = "Xem trong tháng"
        Me.rdbAccessTimeInMonth.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 370)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1327, 72)
        Me.TableLayoutPanel2.TabIndex = 1324
        '
        'pnLuaChonSua
        '
        Me.pnLuaChonSua.Controls.Add(Me.rdbSuaDuLieuQuet)
        Me.pnLuaChonSua.Location = New System.Drawing.Point(3, 3)
        Me.pnLuaChonSua.Name = "pnLuaChonSua"
        Me.pnLuaChonSua.Size = New System.Drawing.Size(23, 62)
        Me.pnLuaChonSua.TabIndex = 1
        Me.pnLuaChonSua.Visible = False
        '
        'rdbSuaDuLieuQuet
        '
        Me.rdbSuaDuLieuQuet.AutoSize = True
        Me.rdbSuaDuLieuQuet.Checked = True
        Me.rdbSuaDuLieuQuet.Location = New System.Drawing.Point(3, 5)
        Me.rdbSuaDuLieuQuet.Name = "rdbSuaDuLieuQuet"
        Me.rdbSuaDuLieuQuet.Size = New System.Drawing.Size(104, 17)
        Me.rdbSuaDuLieuQuet.TabIndex = 1295
        Me.rdbSuaDuLieuQuet.TabStop = True
        Me.rdbSuaDuLieuQuet.Text = "Sửa dữ liệu quẹt"
        Me.rdbSuaDuLieuQuet.UseVisualStyleBackColor = True
        '
        'pnSuaGioQuet
        '
        Me.pnSuaGioQuet.Controls.Add(Me.InOutStatus)
        Me.pnSuaGioQuet.Controls.Add(Me.cbGioTangCa)
        Me.pnSuaGioQuet.Controls.Add(Me.maxovertime)
        Me.pnSuaGioQuet.Controls.Add(Me.rdbNhapTheoGioNhap)
        Me.pnSuaGioQuet.Controls.Add(Me.lblInOutStatus)
        Me.pnSuaGioQuet.Controls.Add(Me.rdbNhapTuDong)
        Me.pnSuaGioQuet.Controls.Add(Me.rdbNhapTheoDungGioCa)
        Me.pnSuaGioQuet.Controls.Add(Me.AccessTime)
        Me.pnSuaGioQuet.Location = New System.Drawing.Point(32, 3)
        Me.pnSuaGioQuet.Name = "pnSuaGioQuet"
        Me.pnSuaGioQuet.Size = New System.Drawing.Size(513, 62)
        Me.pnSuaGioQuet.TabIndex = 0
        '
        'InOutStatus
        '
        Me.InOutStatus.Location = New System.Drawing.Point(6, 31)
        Me.InOutStatus.Name = "InOutStatus"
        Me.InOutStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.InOutStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InOutStatus.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.InOutStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.InOutStatus.Size = New System.Drawing.Size(115, 20)
        Me.InOutStatus.TabIndex = 1300
        '
        'cbGioTangCa
        '
        Me.cbGioTangCa.AutoSize = True
        Me.cbGioTangCa.BackColor = System.Drawing.SystemColors.Control
        Me.cbGioTangCa.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGioTangCa.Location = New System.Drawing.Point(170, 33)
        Me.cbGioTangCa.Name = "cbGioTangCa"
        Me.cbGioTangCa.Size = New System.Drawing.Size(80, 17)
        Me.cbGioTangCa.TabIndex = 1299
        Me.cbGioTangCa.Text = "Giờ tăng ca"
        Me.cbGioTangCa.UseVisualStyleBackColor = False
        '
        'maxovertime
        '
        Me.maxovertime.DecimalPlaces = 1
        Me.maxovertime.Location = New System.Drawing.Point(301, 32)
        Me.maxovertime.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.maxovertime.Name = "maxovertime"
        Me.maxovertime.Size = New System.Drawing.Size(36, 21)
        Me.maxovertime.TabIndex = 1298
        '
        'rdbNhapTheoGioNhap
        '
        Me.rdbNhapTheoGioNhap.AutoSize = True
        Me.rdbNhapTheoGioNhap.Checked = True
        Me.rdbNhapTheoGioNhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNhapTheoGioNhap.Location = New System.Drawing.Point(168, 5)
        Me.rdbNhapTheoGioNhap.Name = "rdbNhapTheoGioNhap"
        Me.rdbNhapTheoGioNhap.Size = New System.Drawing.Size(65, 17)
        Me.rdbNhapTheoGioNhap.TabIndex = 1297
        Me.rdbNhapTheoGioNhap.TabStop = True
        Me.rdbNhapTheoGioNhap.Text = "Theo giờ"
        Me.rdbNhapTheoGioNhap.UseVisualStyleBackColor = True
        '
        'lblInOutStatus
        '
        Me.lblInOutStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInOutStatus.Location = New System.Drawing.Point(3, 8)
        Me.lblInOutStatus.Name = "lblInOutStatus"
        Me.lblInOutStatus.Size = New System.Drawing.Size(99, 16)
        Me.lblInOutStatus.TabIndex = 1290
        Me.lblInOutStatus.Text = "Trạng thái Vào/Ra"
        '
        'rdbNhapTuDong
        '
        Me.rdbNhapTuDong.AutoSize = True
        Me.rdbNhapTuDong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNhapTuDong.Location = New System.Drawing.Point(377, 36)
        Me.rdbNhapTuDong.Name = "rdbNhapTuDong"
        Me.rdbNhapTuDong.Size = New System.Drawing.Size(113, 17)
        Me.rdbNhapTuDong.TabIndex = 1296
        Me.rdbNhapTuDong.Text = "Theo ca +-15 phút"
        Me.rdbNhapTuDong.UseVisualStyleBackColor = True
        '
        'rdbNhapTheoDungGioCa
        '
        Me.rdbNhapTheoDungGioCa.AutoSize = True
        Me.rdbNhapTheoDungGioCa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNhapTheoDungGioCa.Location = New System.Drawing.Point(378, 6)
        Me.rdbNhapTheoDungGioCa.Name = "rdbNhapTheoDungGioCa"
        Me.rdbNhapTheoDungGioCa.Size = New System.Drawing.Size(65, 17)
        Me.rdbNhapTheoDungGioCa.TabIndex = 1295
        Me.rdbNhapTheoDungGioCa.Text = "Theo ca"
        Me.rdbNhapTheoDungGioCa.UseVisualStyleBackColor = True
        '
        'AccessTime
        '
        Me.AccessTime.EditValue = Nothing
        Me.AccessTime.Location = New System.Drawing.Point(259, 6)
        Me.AccessTime.Name = "AccessTime"
        Me.AccessTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AccessTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccessTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.AccessTime.Properties.MaskSettings.Set("mask", "hh:mm")
        Me.AccessTime.Properties.UseMaskAsDisplayFormat = True
        Me.AccessTime.Size = New System.Drawing.Size(78, 20)
        Me.AccessTime.TabIndex = 1350
        '
        'pnSuaCa
        '
        Me.pnSuaCa.Controls.Add(Me.ShiftName)
        Me.pnSuaCa.Controls.Add(Me.lblShiftName)
        Me.pnSuaCa.Location = New System.Drawing.Point(551, 3)
        Me.pnSuaCa.Name = "pnSuaCa"
        Me.pnSuaCa.Size = New System.Drawing.Size(187, 62)
        Me.pnSuaCa.TabIndex = 3
        Me.pnSuaCa.Visible = False
        '
        'ShiftName
        '
        Me.ShiftName.Location = New System.Drawing.Point(73, 6)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ShiftName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ShiftName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ShiftName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ShiftName.Size = New System.Drawing.Size(94, 20)
        Me.ShiftName.TabIndex = 1301
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
        Me.pnLyDoGhiChu.Controls.Add(Me.Reason)
        Me.pnLyDoGhiChu.Controls.Add(Me.lblReason)
        Me.pnLyDoGhiChu.Controls.Add(Me.lblRemark)
        Me.pnLyDoGhiChu.Controls.Add(Me.Remark)
        Me.pnLyDoGhiChu.Location = New System.Drawing.Point(744, 3)
        Me.pnLyDoGhiChu.Name = "pnLyDoGhiChu"
        Me.pnLyDoGhiChu.Size = New System.Drawing.Size(269, 62)
        Me.pnLyDoGhiChu.TabIndex = 2
        '
        'Reason
        '
        Me.Reason.Location = New System.Drawing.Point(81, 6)
        Me.Reason.Name = "Reason"
        Me.Reason.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Reason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Reason.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Reason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Reason.Size = New System.Drawing.Size(168, 20)
        Me.Reason.TabIndex = 1302
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
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(81, 31)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(171, 25)
        Me.Remark.TabIndex = 1286
        Me.Remark.Text = ""
        '
        'pnNhapLuu
        '
        Me.pnNhapLuu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnNhapLuu.Controls.Add(Me.btnSave)
        Me.pnNhapLuu.Controls.Add(Me.btnNhap)
        Me.pnNhapLuu.Controls.Add(Me.btnXoaDKTangCa)
        Me.pnNhapLuu.Controls.Add(Me.btnLuuDKTC)
        Me.pnNhapLuu.Location = New System.Drawing.Point(1112, 3)
        Me.pnNhapLuu.Name = "pnNhapLuu"
        Me.pnNhapLuu.Size = New System.Drawing.Size(212, 62)
        Me.pnNhapLuu.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(155, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(40, 56)
        Me.btnSave.TabIndex = 1301
        Me.btnSave.Text = "Lưu"
        '
        'btnNhap
        '
        Me.btnNhap.Location = New System.Drawing.Point(109, 3)
        Me.btnNhap.Name = "btnNhap"
        Me.btnNhap.Size = New System.Drawing.Size(40, 56)
        Me.btnNhap.TabIndex = 1300
        Me.btnNhap.Text = "Nhập"
        '
        'btnXoaDKTangCa
        '
        Me.btnXoaDKTangCa.Location = New System.Drawing.Point(52, 3)
        Me.btnXoaDKTangCa.Name = "btnXoaDKTangCa"
        Me.btnXoaDKTangCa.Size = New System.Drawing.Size(40, 56)
        Me.btnXoaDKTangCa.TabIndex = 1299
        Me.btnXoaDKTangCa.Text = "Xóa " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "đk " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tăng " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ca"
        Me.btnXoaDKTangCa.Visible = False
        '
        'btnLuuDKTC
        '
        Me.btnLuuDKTC.Location = New System.Drawing.Point(6, 3)
        Me.btnLuuDKTC.Name = "btnLuuDKTC"
        Me.btnLuuDKTC.Size = New System.Drawing.Size(40, 56)
        Me.btnLuuDKTC.TabIndex = 1225
        Me.btnLuuDKTC.Text = "Lưu " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ĐK TC"
        Me.btnLuuDKTC.Visible = False
        '
        'frmCongBatThuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1332, 521)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl3
        Me.HRFORM_Gridview = Me.GridView3
        Me.HRFORM_TableName = "abc"
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_ImportExcel = False
        Me.HRFORM_VisibleControl_Luu = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_Xoa = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmCongBatThuong"
        Me.Text = "frmCongBatThuong"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAccessTime.ResumeLayout(False)
        CType(Me.gridMaxOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridAccessTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnLuaChonSua.ResumeLayout(False)
        Me.pnLuaChonSua.PerformLayout()
        Me.pnSuaGioQuet.ResumeLayout(False)
        Me.pnSuaGioQuet.PerformLayout()
        CType(Me.InOutStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maxovertime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccessTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSuaCa.ResumeLayout(False)
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLyDoGhiChu.ResumeLayout(False)
        CType(Me.Reason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnNhapLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Public WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnLuaChonSua As Panel
    Friend WithEvents rdbSuaDuLieuQuet As RadioButton
    Friend WithEvents pnSuaGioQuet As Panel
    Friend WithEvents cbGioTangCa As CheckBox
    Friend WithEvents maxovertime As NumericUpDown
    Friend WithEvents rdbNhapTheoGioNhap As RadioButton
    Friend WithEvents lblInOutStatus As Label
    Friend WithEvents rdbNhapTuDong As RadioButton
    Friend WithEvents rdbNhapTheoDungGioCa As RadioButton
    Friend WithEvents pnSuaCa As Panel
    Friend WithEvents lblShiftName As Label
    Friend WithEvents pnLyDoGhiChu As Panel
    Friend WithEvents lblReason As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents pnNhapLuu As Panel
    Friend WithEvents PanelAccessTime As Panel
    Friend WithEvents gridMaxOverTime As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridAccessTime As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdbAccessTimeOneDay As RadioButton
    Friend WithEvents rdbAccessTimeThreeDay As RadioButton
    Friend WithEvents rdbAccessTimeInMonth As RadioButton
    Friend WithEvents InOutStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ShiftName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Reason As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNhap As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoaDKTangCa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLuuDKTC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AccessTime As DevExpress.XtraEditors.TimeEdit
End Class
