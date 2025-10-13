<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpRegisPregnant
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.UltraDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblUltraDate = New System.Windows.Forms.Label()
        Me.lblPregDays = New System.Windows.Forms.Label()
        Me.PregDays = New System.Windows.Forms.NumericUpDown()
        Me.lblPregWeeks = New System.Windows.Forms.Label()
        Me.PregWeeks = New System.Windows.Forms.NumericUpDown()
        Me.MiscarriageDate = New DevExpress.XtraEditors.DateEdit()
        Me.Fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.todate = New DevExpress.XtraEditors.DateEdit()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.lblMiscarriageDate = New System.Windows.Forms.Label()
        Me.lblUltraPaper = New System.Windows.Forms.Label()
        Me.UltraPaper = New System.Windows.Forms.TextBox()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
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
        CType(Me.UltraDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PregDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PregWeeks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MiscarriageDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MiscarriageDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 352)
        Me.PanelButton.Size = New System.Drawing.Size(1109, 54)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1109, 352)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1107, 327)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 121)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1107, 206)
        Me.GridControl1.TabIndex = 1328
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
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnLuu, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1107, 121)
        Me.TableLayoutPanel2.TabIndex = 1327
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 86)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(8, 55)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1301
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(8, 25)
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
        Me.lblEmployee_ID.Location = New System.Drawing.Point(5, 4)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(102, 20)
        Me.lblEmployee_ID.TabIndex = 1219
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.UltraDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblUltraDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPregDays)
        Me.pnDuLieuNhap.Controls.Add(Me.PregDays)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPregWeeks)
        Me.pnDuLieuNhap.Controls.Add(Me.PregWeeks)
        Me.pnDuLieuNhap.Controls.Add(Me.MiscarriageDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Fromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.todate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblToDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMiscarriageDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblUltraPaper)
        Me.pnDuLieuNhap.Controls.Add(Me.UltraPaper)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(662, 113)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'UltraDate
        '
        Me.UltraDate.EditValue = Nothing
        Me.UltraDate.Location = New System.Drawing.Point(121, 66)
        Me.UltraDate.Name = "UltraDate"
        Me.UltraDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UltraDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UltraDate.Properties.DisplayFormat.FormatString = ""
        Me.UltraDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.UltraDate.Properties.EditFormat.FormatString = ""
        Me.UltraDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.UltraDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.UltraDate.Properties.MaskSettings.Set("mask", "d")
        Me.UltraDate.Properties.UseMaskAsDisplayFormat = True
        Me.UltraDate.Size = New System.Drawing.Size(131, 20)
        Me.UltraDate.TabIndex = 9
        '
        'lblUltraDate
        '
        Me.lblUltraDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblUltraDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltraDate.ForeColor = System.Drawing.Color.Red
        Me.lblUltraDate.Location = New System.Drawing.Point(11, 65)
        Me.lblUltraDate.Name = "lblUltraDate"
        Me.lblUltraDate.Size = New System.Drawing.Size(104, 20)
        Me.lblUltraDate.TabIndex = 1329
        Me.lblUltraDate.Text = "Ngày siêu âm"
        Me.lblUltraDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPregDays
        '
        Me.lblPregDays.BackColor = System.Drawing.SystemColors.Control
        Me.lblPregDays.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPregDays.ForeColor = System.Drawing.Color.Red
        Me.lblPregDays.Location = New System.Drawing.Point(257, 82)
        Me.lblPregDays.Name = "lblPregDays"
        Me.lblPregDays.Size = New System.Drawing.Size(104, 20)
        Me.lblPregDays.TabIndex = 1327
        Me.lblPregDays.Text = "Ngày thai"
        Me.lblPregDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PregDays
        '
        Me.PregDays.Location = New System.Drawing.Point(367, 84)
        Me.PregDays.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.PregDays.Name = "PregDays"
        Me.PregDays.Size = New System.Drawing.Size(51, 21)
        Me.PregDays.TabIndex = 7
        '
        'lblPregWeeks
        '
        Me.lblPregWeeks.BackColor = System.Drawing.SystemColors.Control
        Me.lblPregWeeks.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPregWeeks.ForeColor = System.Drawing.Color.Red
        Me.lblPregWeeks.Location = New System.Drawing.Point(257, 60)
        Me.lblPregWeeks.Name = "lblPregWeeks"
        Me.lblPregWeeks.Size = New System.Drawing.Size(104, 20)
        Me.lblPregWeeks.TabIndex = 1326
        Me.lblPregWeeks.Text = "Tuần thai"
        Me.lblPregWeeks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PregWeeks
        '
        Me.PregWeeks.Location = New System.Drawing.Point(367, 60)
        Me.PregWeeks.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.PregWeeks.Name = "PregWeeks"
        Me.PregWeeks.Size = New System.Drawing.Size(51, 21)
        Me.PregWeeks.TabIndex = 5
        '
        'MiscarriageDate
        '
        Me.MiscarriageDate.EditValue = Nothing
        Me.MiscarriageDate.Location = New System.Drawing.Point(515, 30)
        Me.MiscarriageDate.Name = "MiscarriageDate"
        Me.MiscarriageDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MiscarriageDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MiscarriageDate.Properties.DisplayFormat.FormatString = ""
        Me.MiscarriageDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.MiscarriageDate.Properties.EditFormat.FormatString = ""
        Me.MiscarriageDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.MiscarriageDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.MiscarriageDate.Properties.MaskSettings.Set("mask", "d")
        Me.MiscarriageDate.Properties.UseMaskAsDisplayFormat = True
        Me.MiscarriageDate.Size = New System.Drawing.Size(131, 20)
        Me.MiscarriageDate.TabIndex = 9
        '
        'Fromdate
        '
        Me.Fromdate.EditValue = Nothing
        Me.Fromdate.Location = New System.Drawing.Point(573, 66)
        Me.Fromdate.Name = "Fromdate"
        Me.Fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Fromdate.Properties.DisplayFormat.FormatString = ""
        Me.Fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Fromdate.Properties.EditFormat.FormatString = ""
        Me.Fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.Fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.Fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.Fromdate.Size = New System.Drawing.Size(39, 20)
        Me.Fromdate.TabIndex = 1323
        Me.Fromdate.Visible = False
        '
        'todate
        '
        Me.todate.EditValue = Nothing
        Me.todate.Location = New System.Drawing.Point(121, 37)
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
        Me.todate.Size = New System.Drawing.Size(131, 20)
        Me.todate.TabIndex = 5
        '
        'lblToDate
        '
        Me.lblToDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblToDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToDate.ForeColor = System.Drawing.Color.Red
        Me.lblToDate.Location = New System.Drawing.Point(11, 36)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(104, 20)
        Me.lblToDate.TabIndex = 1316
        Me.lblToDate.Text = "Ngày dự sinh *"
        Me.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMiscarriageDate
        '
        Me.lblMiscarriageDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblMiscarriageDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiscarriageDate.Location = New System.Drawing.Point(512, 7)
        Me.lblMiscarriageDate.Name = "lblMiscarriageDate"
        Me.lblMiscarriageDate.Size = New System.Drawing.Size(104, 20)
        Me.lblMiscarriageDate.TabIndex = 1315
        Me.lblMiscarriageDate.Text = "Ngày sảy thai"
        Me.lblMiscarriageDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUltraPaper
        '
        Me.lblUltraPaper.BackColor = System.Drawing.SystemColors.Control
        Me.lblUltraPaper.Location = New System.Drawing.Point(12, 10)
        Me.lblUltraPaper.Name = "lblUltraPaper"
        Me.lblUltraPaper.Size = New System.Drawing.Size(103, 23)
        Me.lblUltraPaper.TabIndex = 1314
        Me.lblUltraPaper.Text = "Mã giấy siêu âm"
        '
        'UltraPaper
        '
        Me.UltraPaper.Location = New System.Drawing.Point(121, 10)
        Me.UltraPaper.Name = "UltraPaper"
        Me.UltraPaper.Size = New System.Drawing.Size(131, 21)
        Me.UltraPaper.TabIndex = 3
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(367, 14)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(132, 40)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(259, 16)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(66, 16)
        Me.lblRemark.TabIndex = 1313
        Me.lblRemark.Text = "Ghi chú"
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(993, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Lưu"
        '
        'frmEmpRegisPregnant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_EmployeeRegisPregnant"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_EmployeeRegisPregnant"
        Me.HRFORM_TableName = "HR_EmployeeRegisPregnant"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmEmpRegisPregnant"
        Me.Text = "frmEmpRegisPregnant"
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
        CType(Me.UltraDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PregDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PregWeeks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MiscarriageDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MiscarriageDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
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
    Friend WithEvents UltraDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblUltraDate As Label
    Friend WithEvents lblPregDays As Label
    Friend WithEvents PregDays As NumericUpDown
    Friend WithEvents lblPregWeeks As Label
    Friend WithEvents PregWeeks As NumericUpDown
    Friend WithEvents MiscarriageDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblMiscarriageDate As Label
    Friend WithEvents lblUltraPaper As Label
    Friend WithEvents UltraPaper As TextBox
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
