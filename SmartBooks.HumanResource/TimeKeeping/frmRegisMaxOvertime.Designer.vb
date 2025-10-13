<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegisMaxOvertime
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
        Me.isActualOT = New System.Windows.Forms.CheckBox()
        Me.PrintStatus = New System.Windows.Forms.CheckBox()
        Me.TypeOfOT = New DevExpress.XtraEditors.LookUpEdit()
        Me.NgayNghiBu = New DevExpress.XtraEditors.DateEdit()
        Me.ShiftName = New DevExpress.XtraEditors.LookUpEdit()
        Me.workingdate = New DevExpress.XtraEditors.DateEdit()
        Me.lblworkingdate = New System.Windows.Forms.Label()
        Me.maxovertime = New System.Windows.Forms.NumericUpDown()
        Me.lblmaxovertime = New System.Windows.Forms.Label()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblTypeOfOT = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblNgayNghiBu = New System.Windows.Forms.Label()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TangCaNgoaiLe_SK1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Gio_SK1 = New System.Windows.Forms.TextBox()
        Me.GioSK1 = New System.Windows.Forms.Label()
        Me.Factory_ID_SK1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbldepartmentcode = New System.Windows.Forms.Label()
        Me.Ngay_SK1 = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tim_SK1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Luu_SK1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TangCaNgoaiLe_SK2 = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Gio_SK2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Factory_ID_SK2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ngay_SK2 = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Tim_SK2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Luu_SK2 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        CType(Me.TypeOfOT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayNghiBu.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayNghiBu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.workingdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.workingdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maxovertime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.TangCaNgoaiLe_SK1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Factory_ID_SK1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ngay_SK1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ngay_SK1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TangCaNgoaiLe_SK2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Factory_ID_SK2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ngay_SK2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ngay_SK2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Size = New System.Drawing.Size(1170, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1170, 355)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General, Me.TangCaNgoaiLe_SK1, Me.TangCaNgoaiLe_SK2})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1168, 330)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 101)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1168, 227)
        Me.GridControl1.TabIndex = 1324
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
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1168, 99)
        Me.TableLayoutPanel2.TabIndex = 1323
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(5, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(315, 91)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(3, 59)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1301
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 31)
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
        Me.lblEmployee_ID.Location = New System.Drawing.Point(3, 5)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(120, 23)
        Me.lblEmployee_ID.TabIndex = 1214
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.BackColor = System.Drawing.SystemColors.Control
        Me.pnDuLieuNhap.Controls.Add(Me.isActualOT)
        Me.pnDuLieuNhap.Controls.Add(Me.PrintStatus)
        Me.pnDuLieuNhap.Controls.Add(Me.TypeOfOT)
        Me.pnDuLieuNhap.Controls.Add(Me.NgayNghiBu)
        Me.pnDuLieuNhap.Controls.Add(Me.ShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.workingdate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblworkingdate)
        Me.pnDuLieuNhap.Controls.Add(Me.maxovertime)
        Me.pnDuLieuNhap.Controls.Add(Me.lblmaxovertime)
        Me.pnDuLieuNhap.Controls.Add(Me.lblShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTypeOfOT)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNgayNghiBu)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(327, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(719, 91)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'isActualOT
        '
        Me.isActualOT.AutoSize = True
        Me.isActualOT.Location = New System.Drawing.Point(412, 58)
        Me.isActualOT.Name = "isActualOT"
        Me.isActualOT.Size = New System.Drawing.Size(102, 17)
        Me.isActualOT.TabIndex = 13
        Me.isActualOT.Text = "Tăng ca thực tế"
        Me.isActualOT.UseVisualStyleBackColor = True
        '
        'PrintStatus
        '
        Me.PrintStatus.AutoSize = True
        Me.PrintStatus.Location = New System.Drawing.Point(311, 57)
        Me.PrintStatus.Name = "PrintStatus"
        Me.PrintStatus.Size = New System.Drawing.Size(79, 17)
        Me.PrintStatus.TabIndex = 1265
        Me.PrintStatus.Text = "PrintStatus"
        Me.PrintStatus.UseVisualStyleBackColor = True
        Me.PrintStatus.Visible = False
        '
        'TypeOfOT
        '
        Me.TypeOfOT.Location = New System.Drawing.Point(146, 56)
        Me.TypeOfOT.Name = "TypeOfOT"
        Me.TypeOfOT.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TypeOfOT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeOfOT.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TypeOfOT.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TypeOfOT.Size = New System.Drawing.Size(120, 20)
        Me.TypeOfOT.TabIndex = 7
        '
        'NgayNghiBu
        '
        Me.NgayNghiBu.EditValue = Nothing
        Me.NgayNghiBu.Location = New System.Drawing.Point(412, 8)
        Me.NgayNghiBu.Name = "NgayNghiBu"
        Me.NgayNghiBu.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayNghiBu.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayNghiBu.Properties.DisplayFormat.FormatString = ""
        Me.NgayNghiBu.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayNghiBu.Properties.EditFormat.FormatString = ""
        Me.NgayNghiBu.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayNghiBu.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.NgayNghiBu.Properties.MaskSettings.Set("mask", "d")
        Me.NgayNghiBu.Properties.UseMaskAsDisplayFormat = True
        Me.NgayNghiBu.Size = New System.Drawing.Size(105, 20)
        Me.NgayNghiBu.TabIndex = 9
        '
        'ShiftName
        '
        Me.ShiftName.Location = New System.Drawing.Point(412, 31)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ShiftName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ShiftName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ShiftName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ShiftName.Size = New System.Drawing.Size(105, 20)
        Me.ShiftName.TabIndex = 11
        '
        'workingdate
        '
        Me.workingdate.EditValue = Nothing
        Me.workingdate.Location = New System.Drawing.Point(146, 9)
        Me.workingdate.Name = "workingdate"
        Me.workingdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.workingdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.workingdate.Properties.DisplayFormat.FormatString = ""
        Me.workingdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.workingdate.Properties.EditFormat.FormatString = ""
        Me.workingdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.workingdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.workingdate.Properties.MaskSettings.Set("mask", "d")
        Me.workingdate.Properties.UseMaskAsDisplayFormat = True
        Me.workingdate.Size = New System.Drawing.Size(120, 20)
        Me.workingdate.TabIndex = 3
        '
        'lblworkingdate
        '
        Me.lblworkingdate.BackColor = System.Drawing.SystemColors.Control
        Me.lblworkingdate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblworkingdate.Location = New System.Drawing.Point(10, 9)
        Me.lblworkingdate.Name = "lblworkingdate"
        Me.lblworkingdate.Size = New System.Drawing.Size(130, 20)
        Me.lblworkingdate.TabIndex = 1209
        Me.lblworkingdate.Text = "Ngày"
        Me.lblworkingdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'maxovertime
        '
        Me.maxovertime.DecimalPlaces = 1
        Me.maxovertime.Location = New System.Drawing.Point(212, 32)
        Me.maxovertime.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.maxovertime.Name = "maxovertime"
        Me.maxovertime.Size = New System.Drawing.Size(51, 21)
        Me.maxovertime.TabIndex = 5
        '
        'lblmaxovertime
        '
        Me.lblmaxovertime.BackColor = System.Drawing.SystemColors.Control
        Me.lblmaxovertime.Location = New System.Drawing.Point(10, 34)
        Me.lblmaxovertime.Name = "lblmaxovertime"
        Me.lblmaxovertime.Size = New System.Drawing.Size(196, 17)
        Me.lblmaxovertime.TabIndex = 1210
        Me.lblmaxovertime.Text = "Giờ tăng ca"
        '
        'lblShiftName
        '
        Me.lblShiftName.BackColor = System.Drawing.SystemColors.Control
        Me.lblShiftName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftName.Location = New System.Drawing.Point(272, 33)
        Me.lblShiftName.Name = "lblShiftName"
        Me.lblShiftName.Size = New System.Drawing.Size(129, 20)
        Me.lblShiftName.TabIndex = 1260
        Me.lblShiftName.Text = "Ca"
        Me.lblShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(528, 12)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(79, 28)
        Me.lblRemark.TabIndex = 1211
        Me.lblRemark.Text = "Ghi chú"
        '
        'lblTypeOfOT
        '
        Me.lblTypeOfOT.BackColor = System.Drawing.SystemColors.Control
        Me.lblTypeOfOT.Location = New System.Drawing.Point(10, 56)
        Me.lblTypeOfOT.Name = "lblTypeOfOT"
        Me.lblTypeOfOT.Size = New System.Drawing.Size(142, 18)
        Me.lblTypeOfOT.TabIndex = 1212
        Me.lblTypeOfOT.Text = "Loại giờ tăng ca"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(610, 9)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(95, 70)
        Me.Remark.TabIndex = 19
        Me.Remark.Text = ""
        '
        'lblNgayNghiBu
        '
        Me.lblNgayNghiBu.BackColor = System.Drawing.SystemColors.Control
        Me.lblNgayNghiBu.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayNghiBu.Location = New System.Drawing.Point(272, 8)
        Me.lblNgayNghiBu.Name = "lblNgayNghiBu"
        Me.lblNgayNghiBu.Size = New System.Drawing.Size(134, 20)
        Me.lblNgayNghiBu.TabIndex = 1256
        Me.lblNgayNghiBu.Text = "Ngày nghỉ bù"
        Me.lblNgayNghiBu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1053, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(61, 76)
        Me.pnLuu.TabIndex = 1327
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(4, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Lưu"
        '
        'TangCaNgoaiLe_SK1
        '
        Me.TangCaNgoaiLe_SK1.Controls.Add(Me.GridControl2)
        Me.TangCaNgoaiLe_SK1.Controls.Add(Me.TableLayoutPanel3)
        Me.TangCaNgoaiLe_SK1.Name = "TangCaNgoaiLe_SK1"
        Me.TangCaNgoaiLe_SK1.Size = New System.Drawing.Size(1168, 330)
        Me.TangCaNgoaiLe_SK1.Text = "SK1"
        '
        'GridControl2
        '
        Me.GridControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl2.Location = New System.Drawing.Point(0, 56)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1168, 271)
        Me.GridControl2.TabIndex = 1325
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1168, 54)
        Me.TableLayoutPanel3.TabIndex = 1324
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Gio_SK1)
        Me.Panel2.Controls.Add(Me.GioSK1)
        Me.Panel2.Controls.Add(Me.Factory_ID_SK1)
        Me.Panel2.Controls.Add(Me.lbldepartmentcode)
        Me.Panel2.Controls.Add(Me.Ngay_SK1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(6, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(839, 46)
        Me.Panel2.TabIndex = 1321
        '
        'Gio_SK1
        '
        Me.Gio_SK1.Location = New System.Drawing.Point(664, 10)
        Me.Gio_SK1.Name = "Gio_SK1"
        Me.Gio_SK1.Size = New System.Drawing.Size(162, 21)
        Me.Gio_SK1.TabIndex = 1484
        '
        'GioSK1
        '
        Me.GioSK1.BackColor = System.Drawing.Color.Transparent
        Me.GioSK1.Location = New System.Drawing.Point(558, 8)
        Me.GioSK1.Name = "GioSK1"
        Me.GioSK1.Size = New System.Drawing.Size(80, 19)
        Me.GioSK1.TabIndex = 1483
        Me.GioSK1.Text = "Giờ"
        Me.GioSK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Factory_ID_SK1
        '
        Me.Factory_ID_SK1.Location = New System.Drawing.Point(116, 9)
        Me.Factory_ID_SK1.Name = "Factory_ID_SK1"
        Me.Factory_ID_SK1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Factory_ID_SK1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Factory_ID_SK1.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Factory_ID_SK1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Factory_ID_SK1.Size = New System.Drawing.Size(162, 20)
        Me.Factory_ID_SK1.TabIndex = 1482
        '
        'lbldepartmentcode
        '
        Me.lbldepartmentcode.BackColor = System.Drawing.Color.Transparent
        Me.lbldepartmentcode.Location = New System.Drawing.Point(10, 9)
        Me.lbldepartmentcode.Name = "lbldepartmentcode"
        Me.lbldepartmentcode.Size = New System.Drawing.Size(100, 19)
        Me.lbldepartmentcode.TabIndex = 1481
        Me.lbldepartmentcode.Text = "Bộ phận"
        Me.lbldepartmentcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ngay_SK1
        '
        Me.Ngay_SK1.EditValue = Nothing
        Me.Ngay_SK1.Location = New System.Drawing.Point(390, 9)
        Me.Ngay_SK1.Name = "Ngay_SK1"
        Me.Ngay_SK1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Ngay_SK1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Ngay_SK1.Properties.DisplayFormat.FormatString = ""
        Me.Ngay_SK1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Ngay_SK1.Properties.EditFormat.FormatString = ""
        Me.Ngay_SK1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Ngay_SK1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Ngay_SK1.Properties.MaskSettings.Set("mask", "d")
        Me.Ngay_SK1.Properties.UseMaskAsDisplayFormat = True
        Me.Ngay_SK1.Size = New System.Drawing.Size(162, 20)
        Me.Ngay_SK1.TabIndex = 1210
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(284, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 1211
        Me.Label2.Text = "Ngày"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Tim_SK1)
        Me.Panel3.Controls.Add(Me.Luu_SK1)
        Me.Panel3.Location = New System.Drawing.Point(852, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(126, 46)
        Me.Panel3.TabIndex = 1327
        '
        'Tim_SK1
        '
        Me.Tim_SK1.Location = New System.Drawing.Point(3, 3)
        Me.Tim_SK1.Name = "Tim_SK1"
        Me.Tim_SK1.Size = New System.Drawing.Size(60, 43)
        Me.Tim_SK1.TabIndex = 1485
        Me.Tim_SK1.Text = "Tìm"
        '
        'Luu_SK1
        '
        Me.Luu_SK1.Location = New System.Drawing.Point(69, 3)
        Me.Luu_SK1.Name = "Luu_SK1"
        Me.Luu_SK1.Size = New System.Drawing.Size(53, 43)
        Me.Luu_SK1.TabIndex = 38
        Me.Luu_SK1.Text = "Lưu"
        '
        'TangCaNgoaiLe_SK2
        '
        Me.TangCaNgoaiLe_SK2.Controls.Add(Me.TableLayoutPanel4)
        Me.TangCaNgoaiLe_SK2.Controls.Add(Me.GridControl3)
        Me.TangCaNgoaiLe_SK2.Name = "TangCaNgoaiLe_SK2"
        Me.TangCaNgoaiLe_SK2.Size = New System.Drawing.Size(1168, 330)
        Me.TangCaNgoaiLe_SK2.Text = "SK2"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel4.ColumnCount = 5
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel1, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel4, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1168, 54)
        Me.TableLayoutPanel4.TabIndex = 1327
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Gio_SK2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Factory_ID_SK2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Ngay_SK2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(6, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(839, 46)
        Me.Panel1.TabIndex = 1321
        '
        'Gio_SK2
        '
        Me.Gio_SK2.Location = New System.Drawing.Point(664, 10)
        Me.Gio_SK2.Name = "Gio_SK2"
        Me.Gio_SK2.Size = New System.Drawing.Size(162, 21)
        Me.Gio_SK2.TabIndex = 1484
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(558, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 1483
        Me.Label1.Text = "Giờ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Factory_ID_SK2
        '
        Me.Factory_ID_SK2.Location = New System.Drawing.Point(116, 9)
        Me.Factory_ID_SK2.Name = "Factory_ID_SK2"
        Me.Factory_ID_SK2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Factory_ID_SK2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Factory_ID_SK2.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Factory_ID_SK2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Factory_ID_SK2.Size = New System.Drawing.Size(162, 20)
        Me.Factory_ID_SK2.TabIndex = 1482
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(10, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 19)
        Me.Label3.TabIndex = 1481
        Me.Label3.Text = "Bộ phận"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ngay_SK2
        '
        Me.Ngay_SK2.EditValue = Nothing
        Me.Ngay_SK2.Location = New System.Drawing.Point(390, 9)
        Me.Ngay_SK2.Name = "Ngay_SK2"
        Me.Ngay_SK2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Ngay_SK2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Ngay_SK2.Properties.DisplayFormat.FormatString = ""
        Me.Ngay_SK2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Ngay_SK2.Properties.EditFormat.FormatString = ""
        Me.Ngay_SK2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Ngay_SK2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Ngay_SK2.Properties.MaskSettings.Set("mask", "d")
        Me.Ngay_SK2.Properties.UseMaskAsDisplayFormat = True
        Me.Ngay_SK2.Size = New System.Drawing.Size(162, 20)
        Me.Ngay_SK2.TabIndex = 1210
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(284, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 1211
        Me.Label4.Text = "Ngày"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Tim_SK2)
        Me.Panel4.Controls.Add(Me.Luu_SK2)
        Me.Panel4.Location = New System.Drawing.Point(852, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(126, 46)
        Me.Panel4.TabIndex = 1327
        '
        'Tim_SK2
        '
        Me.Tim_SK2.Location = New System.Drawing.Point(3, 3)
        Me.Tim_SK2.Name = "Tim_SK2"
        Me.Tim_SK2.Size = New System.Drawing.Size(60, 43)
        Me.Tim_SK2.TabIndex = 1485
        Me.Tim_SK2.Text = "Tìm"
        '
        'Luu_SK2
        '
        Me.Luu_SK2.Location = New System.Drawing.Point(69, 3)
        Me.Luu_SK2.Name = "Luu_SK2"
        Me.Luu_SK2.Size = New System.Drawing.Size(53, 43)
        Me.Luu_SK2.TabIndex = 38
        Me.Luu_SK2.Text = "Lưu"
        '
        'GridControl3
        '
        Me.GridControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl3.Location = New System.Drawing.Point(1, 56)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1168, 269)
        Me.GridControl3.TabIndex = 1326
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        '
        'frmRegisMaxOvertime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1170, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_MaxOvertime"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "sp_InsertUpdateHR_MaxOvertime"
        Me.HRFORM_TableName = "HR_MaxOvertime"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmRegisMaxOvertime"
        Me.Text = "frmRegisMaxOvertime"
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
        CType(Me.TypeOfOT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayNghiBu.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayNghiBu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.workingdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.workingdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maxovertime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.TangCaNgoaiLe_SK1.ResumeLayout(False)
        Me.TangCaNgoaiLe_SK1.PerformLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Factory_ID_SK1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ngay_SK1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ngay_SK1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TangCaNgoaiLe_SK2.ResumeLayout(False)
        Me.TangCaNgoaiLe_SK2.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Factory_ID_SK2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ngay_SK2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ngay_SK2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents isActualOT As CheckBox
    Friend WithEvents PrintStatus As CheckBox
    Friend WithEvents TypeOfOT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents NgayNghiBu As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ShiftName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents workingdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblworkingdate As Label
    Friend WithEvents maxovertime As NumericUpDown
    Friend WithEvents lblmaxovertime As Label
    Friend WithEvents lblShiftName As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblTypeOfOT As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblNgayNghiBu As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TangCaNgoaiLe_SK1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Luu_SK1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TangCaNgoaiLe_SK2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Ngay_SK1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Factory_ID_SK1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbldepartmentcode As Label
    Friend WithEvents Gio_SK1 As TextBox
    Friend WithEvents GioSK1 As Label
    Friend WithEvents Tim_SK1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Gio_SK2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Factory_ID_SK2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Ngay_SK2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Tim_SK2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Luu_SK2 As DevExpress.XtraEditors.SimpleButton
End Class
