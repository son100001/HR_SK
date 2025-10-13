<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShiftsSetting2
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
        Me.RestTimeTo = New DevExpress.XtraEditors.DateEdit()
        Me.RestTimeFrom = New DevExpress.XtraEditors.DateEdit()
        Me.ToTime = New DevExpress.XtraEditors.DateEdit()
        Me.FromTime = New DevExpress.XtraEditors.DateEdit()
        Me.ShiftGroup = New System.Windows.Forms.TextBox()
        Me.ShiftSign = New System.Windows.Forms.TextBox()
        Me.lblShiftSign = New System.Windows.Forms.Label()
        Me.lblMinMinute = New System.Windows.Forms.Label()
        Me.MinMinute = New System.Windows.Forms.NumericUpDown()
        Me.lblChanCuoi = New System.Windows.Forms.Label()
        Me.ChanCuoi = New System.Windows.Forms.NumericUpDown()
        Me.lblChanDau = New System.Windows.Forms.Label()
        Me.ChanDau = New System.Windows.Forms.NumericUpDown()
        Me.lblRestTimeFrom = New System.Windows.Forms.Label()
        Me.lblRestTimeTo = New System.Windows.Forms.Label()
        Me.ShiftName = New System.Windows.Forms.TextBox()
        Me.lblShiftGroup = New System.Windows.Forms.Label()
        Me.lblAllowEarlyOut = New System.Windows.Forms.Label()
        Me.AllowEarlyOut = New System.Windows.Forms.NumericUpDown()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblAllowLateIn = New System.Windows.Forms.Label()
        Me.AllowLateIn = New System.Windows.Forms.NumericUpDown()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.lblFromtime = New System.Windows.Forms.Label()
        Me.lblTotime = New System.Windows.Forms.Label()
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
        CType(Me.RestTimeTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestTimeTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestTimeFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestTimeFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToTime.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromTime.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinMinute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChanCuoi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChanDau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllowEarlyOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllowLateIn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 395)
        Me.PanelButton.Size = New System.Drawing.Size(1014, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1014, 395)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1012, 370)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 225)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1008, 143)
        Me.GridControl1.TabIndex = 1320
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1012, 223)
        Me.TableLayoutPanel3.TabIndex = 1319
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.RestTimeTo)
        Me.pnDuLieuNhap.Controls.Add(Me.RestTimeFrom)
        Me.pnDuLieuNhap.Controls.Add(Me.ToTime)
        Me.pnDuLieuNhap.Controls.Add(Me.FromTime)
        Me.pnDuLieuNhap.Controls.Add(Me.ShiftGroup)
        Me.pnDuLieuNhap.Controls.Add(Me.ShiftSign)
        Me.pnDuLieuNhap.Controls.Add(Me.lblShiftSign)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMinMinute)
        Me.pnDuLieuNhap.Controls.Add(Me.MinMinute)
        Me.pnDuLieuNhap.Controls.Add(Me.lblChanCuoi)
        Me.pnDuLieuNhap.Controls.Add(Me.ChanCuoi)
        Me.pnDuLieuNhap.Controls.Add(Me.lblChanDau)
        Me.pnDuLieuNhap.Controls.Add(Me.ChanDau)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRestTimeFrom)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRestTimeTo)
        Me.pnDuLieuNhap.Controls.Add(Me.ShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.lblShiftGroup)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAllowEarlyOut)
        Me.pnDuLieuNhap.Controls.Add(Me.AllowEarlyOut)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAllowLateIn)
        Me.pnDuLieuNhap.Controls.Add(Me.AllowLateIn)
        Me.pnDuLieuNhap.Controls.Add(Me.lblShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFromtime)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTotime)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(625, 215)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'RestTimeTo
        '
        Me.RestTimeTo.EditValue = Nothing
        Me.RestTimeTo.Location = New System.Drawing.Point(503, 25)
        Me.RestTimeTo.Name = "RestTimeTo"
        Me.RestTimeTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RestTimeTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RestTimeTo.Properties.DisplayFormat.FormatString = ""
        Me.RestTimeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RestTimeTo.Properties.EditFormat.FormatString = ""
        Me.RestTimeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RestTimeTo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.RestTimeTo.Properties.MaskSettings.Set("mask", "t")
        Me.RestTimeTo.Properties.UseMaskAsDisplayFormat = True
        Me.RestTimeTo.Size = New System.Drawing.Size(90, 20)
        Me.RestTimeTo.TabIndex = 17
        '
        'RestTimeFrom
        '
        Me.RestTimeFrom.EditValue = Nothing
        Me.RestTimeFrom.Location = New System.Drawing.Point(503, 2)
        Me.RestTimeFrom.Name = "RestTimeFrom"
        Me.RestTimeFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RestTimeFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RestTimeFrom.Properties.DisplayFormat.FormatString = ""
        Me.RestTimeFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RestTimeFrom.Properties.EditFormat.FormatString = ""
        Me.RestTimeFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RestTimeFrom.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.RestTimeFrom.Properties.MaskSettings.Set("mask", "t")
        Me.RestTimeFrom.Properties.UseMaskAsDisplayFormat = True
        Me.RestTimeFrom.Size = New System.Drawing.Size(90, 20)
        Me.RestTimeFrom.TabIndex = 15
        '
        'ToTime
        '
        Me.ToTime.EditValue = Nothing
        Me.ToTime.Location = New System.Drawing.Point(180, 78)
        Me.ToTime.Name = "ToTime"
        Me.ToTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToTime.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToTime.Properties.DisplayFormat.FormatString = ""
        Me.ToTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToTime.Properties.EditFormat.FormatString = ""
        Me.ToTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ToTime.Properties.MaskSettings.Set("mask", "t")
        Me.ToTime.Properties.UseMaskAsDisplayFormat = True
        Me.ToTime.Size = New System.Drawing.Size(90, 20)
        Me.ToTime.TabIndex = 7
        '
        'FromTime
        '
        Me.FromTime.EditValue = Nothing
        Me.FromTime.Location = New System.Drawing.Point(180, 53)
        Me.FromTime.Name = "FromTime"
        Me.FromTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromTime.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromTime.Properties.DisplayFormat.FormatString = ""
        Me.FromTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromTime.Properties.EditFormat.FormatString = ""
        Me.FromTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.FromTime.Properties.MaskSettings.Set("mask", "t")
        Me.FromTime.Properties.UseMaskAsDisplayFormat = True
        Me.FromTime.Size = New System.Drawing.Size(90, 20)
        Me.FromTime.TabIndex = 5
        '
        'ShiftGroup
        '
        Me.ShiftGroup.Location = New System.Drawing.Point(179, 2)
        Me.ShiftGroup.Name = "ShiftGroup"
        Me.ShiftGroup.Size = New System.Drawing.Size(120, 21)
        Me.ShiftGroup.TabIndex = 1
        '
        'ShiftSign
        '
        Me.ShiftSign.Location = New System.Drawing.Point(179, 156)
        Me.ShiftSign.Name = "ShiftSign"
        Me.ShiftSign.Size = New System.Drawing.Size(144, 21)
        Me.ShiftSign.TabIndex = 13
        '
        'lblShiftSign
        '
        Me.lblShiftSign.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftSign.Location = New System.Drawing.Point(3, 159)
        Me.lblShiftSign.Name = "lblShiftSign"
        Me.lblShiftSign.Size = New System.Drawing.Size(132, 20)
        Me.lblShiftSign.TabIndex = 1071
        Me.lblShiftSign.Text = "Ký hiệu ca"
        Me.lblShiftSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinMinute
        '
        Me.lblMinMinute.BackColor = System.Drawing.Color.Transparent
        Me.lblMinMinute.Location = New System.Drawing.Point(358, 104)
        Me.lblMinMinute.Name = "lblMinMinute"
        Me.lblMinMinute.Size = New System.Drawing.Size(141, 23)
        Me.lblMinMinute.TabIndex = 1069
        Me.lblMinMinute.Text = "Số phút nhỏ nhất được tính công"
        Me.lblMinMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MinMinute
        '
        Me.MinMinute.DecimalPlaces = 1
        Me.MinMinute.Location = New System.Drawing.Point(505, 101)
        Me.MinMinute.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.MinMinute.Name = "MinMinute"
        Me.MinMinute.Size = New System.Drawing.Size(64, 21)
        Me.MinMinute.TabIndex = 23
        '
        'lblChanCuoi
        '
        Me.lblChanCuoi.BackColor = System.Drawing.Color.Transparent
        Me.lblChanCuoi.Location = New System.Drawing.Point(358, 77)
        Me.lblChanCuoi.Name = "lblChanCuoi"
        Me.lblChanCuoi.Size = New System.Drawing.Size(110, 23)
        Me.lblChanCuoi.TabIndex = 1067
        Me.lblChanCuoi.Text = "Chặn cuối"
        Me.lblChanCuoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChanCuoi
        '
        Me.ChanCuoi.DecimalPlaces = 1
        Me.ChanCuoi.Location = New System.Drawing.Point(505, 77)
        Me.ChanCuoi.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ChanCuoi.Name = "ChanCuoi"
        Me.ChanCuoi.Size = New System.Drawing.Size(64, 21)
        Me.ChanCuoi.TabIndex = 21
        '
        'lblChanDau
        '
        Me.lblChanDau.BackColor = System.Drawing.Color.Transparent
        Me.lblChanDau.Location = New System.Drawing.Point(358, 50)
        Me.lblChanDau.Name = "lblChanDau"
        Me.lblChanDau.Size = New System.Drawing.Size(110, 23)
        Me.lblChanDau.TabIndex = 1066
        Me.lblChanDau.Text = "Chặn đầu"
        Me.lblChanDau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChanDau
        '
        Me.ChanDau.DecimalPlaces = 1
        Me.ChanDau.Location = New System.Drawing.Point(505, 51)
        Me.ChanDau.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.ChanDau.Name = "ChanDau"
        Me.ChanDau.Size = New System.Drawing.Size(64, 21)
        Me.ChanDau.TabIndex = 19
        '
        'lblRestTimeFrom
        '
        Me.lblRestTimeFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestTimeFrom.Location = New System.Drawing.Point(358, 1)
        Me.lblRestTimeFrom.Name = "lblRestTimeFrom"
        Me.lblRestTimeFrom.Size = New System.Drawing.Size(101, 20)
        Me.lblRestTimeFrom.TabIndex = 1065
        Me.lblRestTimeFrom.Text = "Giờ nghỉ từ"
        Me.lblRestTimeFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRestTimeTo
        '
        Me.lblRestTimeTo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestTimeTo.Location = New System.Drawing.Point(358, 25)
        Me.lblRestTimeTo.Name = "lblRestTimeTo"
        Me.lblRestTimeTo.Size = New System.Drawing.Size(117, 20)
        Me.lblRestTimeTo.TabIndex = 1064
        Me.lblRestTimeTo.Text = "Giờ nghỉ đến"
        Me.lblRestTimeTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShiftName
        '
        Me.ShiftName.Location = New System.Drawing.Point(180, 25)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Size = New System.Drawing.Size(120, 21)
        Me.ShiftName.TabIndex = 3
        '
        'lblShiftGroup
        '
        Me.lblShiftGroup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftGroup.Location = New System.Drawing.Point(3, 2)
        Me.lblShiftGroup.Name = "lblShiftGroup"
        Me.lblShiftGroup.Size = New System.Drawing.Size(118, 20)
        Me.lblShiftGroup.TabIndex = 1059
        Me.lblShiftGroup.Text = "Nhóm"
        Me.lblShiftGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAllowEarlyOut
        '
        Me.lblAllowEarlyOut.BackColor = System.Drawing.Color.Transparent
        Me.lblAllowEarlyOut.Location = New System.Drawing.Point(3, 128)
        Me.lblAllowEarlyOut.Name = "lblAllowEarlyOut"
        Me.lblAllowEarlyOut.Size = New System.Drawing.Size(150, 23)
        Me.lblAllowEarlyOut.TabIndex = 1058
        Me.lblAllowEarlyOut.Text = "Số phút được phép về sớm"
        Me.lblAllowEarlyOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AllowEarlyOut
        '
        Me.AllowEarlyOut.Location = New System.Drawing.Point(179, 128)
        Me.AllowEarlyOut.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.AllowEarlyOut.Name = "AllowEarlyOut"
        Me.AllowEarlyOut.Size = New System.Drawing.Size(64, 21)
        Me.AllowEarlyOut.TabIndex = 11
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(358, 131)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(128, 19)
        Me.lblRemark.TabIndex = 1057
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(505, 127)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(114, 51)
        Me.Remark.TabIndex = 30
        Me.Remark.Text = ""
        '
        'lblAllowLateIn
        '
        Me.lblAllowLateIn.BackColor = System.Drawing.Color.Transparent
        Me.lblAllowLateIn.Location = New System.Drawing.Point(3, 102)
        Me.lblAllowLateIn.Name = "lblAllowLateIn"
        Me.lblAllowLateIn.Size = New System.Drawing.Size(150, 23)
        Me.lblAllowLateIn.TabIndex = 1056
        Me.lblAllowLateIn.Text = "Số phút được phép muộn"
        Me.lblAllowLateIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AllowLateIn
        '
        Me.AllowLateIn.Location = New System.Drawing.Point(179, 102)
        Me.AllowLateIn.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.AllowLateIn.Name = "AllowLateIn"
        Me.AllowLateIn.Size = New System.Drawing.Size(64, 21)
        Me.AllowLateIn.TabIndex = 9
        '
        'lblShiftName
        '
        Me.lblShiftName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftName.Location = New System.Drawing.Point(3, 28)
        Me.lblShiftName.Name = "lblShiftName"
        Me.lblShiftName.Size = New System.Drawing.Size(118, 20)
        Me.lblShiftName.TabIndex = 1053
        Me.lblShiftName.Text = "Ca"
        Me.lblShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFromtime
        '
        Me.lblFromtime.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromtime.Location = New System.Drawing.Point(3, 52)
        Me.lblFromtime.Name = "lblFromtime"
        Me.lblFromtime.Size = New System.Drawing.Size(118, 20)
        Me.lblFromtime.TabIndex = 1052
        Me.lblFromtime.Text = "Giờ vào ca"
        Me.lblFromtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotime
        '
        Me.lblTotime.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotime.Location = New System.Drawing.Point(3, 76)
        Me.lblTotime.Name = "lblTotime"
        Me.lblTotime.Size = New System.Drawing.Size(110, 20)
        Me.lblTotime.TabIndex = 1051
        Me.lblTotime.Text = "Giờ tan ca"
        Me.lblTotime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(637, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Lưu"
        '
        'frmShiftsSetting2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 446)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmShiftsSetting2_Nhap"
        Me.HRFORM_TableName = "HR_Shifts"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmShiftsSetting2"
        Me.Text = "frmShiftsSetting2"
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
        CType(Me.RestTimeTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestTimeTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestTimeFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestTimeFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToTime.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromTime.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinMinute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChanCuoi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChanDau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllowEarlyOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllowLateIn, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents RestTimeTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents RestTimeFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ToTime As DevExpress.XtraEditors.DateEdit
    Friend WithEvents FromTime As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ShiftGroup As TextBox
    Friend WithEvents ShiftSign As TextBox
    Friend WithEvents lblShiftSign As Label
    Friend WithEvents lblMinMinute As Label
    Friend WithEvents MinMinute As NumericUpDown
    Friend WithEvents lblChanCuoi As Label
    Friend WithEvents ChanCuoi As NumericUpDown
    Friend WithEvents lblChanDau As Label
    Friend WithEvents ChanDau As NumericUpDown
    Friend WithEvents lblRestTimeFrom As Label
    Friend WithEvents lblRestTimeTo As Label
    Friend WithEvents ShiftName As TextBox
    Friend WithEvents lblShiftGroup As Label
    Friend WithEvents lblAllowEarlyOut As Label
    Friend WithEvents AllowEarlyOut As NumericUpDown
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblAllowLateIn As Label
    Friend WithEvents AllowLateIn As NumericUpDown
    Friend WithEvents lblShiftName As Label
    Friend WithEvents lblFromtime As Label
    Friend WithEvents lblTotime As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
