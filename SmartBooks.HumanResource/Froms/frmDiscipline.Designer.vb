<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiscipline
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
        Me.SalaryIncreaseDate = New DevExpress.XtraEditors.DateEdit()
        Me.ViolationDate = New DevExpress.XtraEditors.DateEdit()
        Me.DisciplineEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DisciplineBegin = New DevExpress.XtraEditors.DateEdit()
        Me.BehaviorCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.Reason = New System.Windows.Forms.RichTextBox()
        Me.lblProcAsign = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.ProcAsign = New System.Windows.Forms.TextBox()
        Me.lblBehaviorCode = New System.Windows.Forms.Label()
        Me.lblSalaryIncreaseDate = New System.Windows.Forms.Label()
        Me.lblDisciplineBegin = New System.Windows.Forms.Label()
        Me.lblViolationDate = New System.Windows.Forms.Label()
        Me.lblDisciplineEnd = New System.Windows.Forms.Label()
        Me.pnNhap = New System.Windows.Forms.Panel()
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
        CType(Me.SalaryIncreaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalaryIncreaseDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViolationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViolationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisciplineEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisciplineEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisciplineBegin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DisciplineBegin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNhap.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 352)
        Me.PanelButton.Size = New System.Drawing.Size(1367, 54)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1367, 352)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1365, 327)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 117)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1361, 208)
        Me.GridControl1.TabIndex = 1321
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
        Me.TableLayoutPanel2.Controls.Add(Me.pnNhap, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1365, 115)
        Me.TableLayoutPanel2.TabIndex = 1320
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(302, 107)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(3, 63)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1275
        Me.btnSearch.Text = "Tìm"
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
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.SalaryIncreaseDate)
        Me.pnDuLieuNhap.Controls.Add(Me.ViolationDate)
        Me.pnDuLieuNhap.Controls.Add(Me.DisciplineEnd)
        Me.pnDuLieuNhap.Controls.Add(Me.DisciplineBegin)
        Me.pnDuLieuNhap.Controls.Add(Me.BehaviorCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblReason)
        Me.pnDuLieuNhap.Controls.Add(Me.Reason)
        Me.pnDuLieuNhap.Controls.Add(Me.lblProcAsign)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.ProcAsign)
        Me.pnDuLieuNhap.Controls.Add(Me.lblBehaviorCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblSalaryIncreaseDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDisciplineBegin)
        Me.pnDuLieuNhap.Controls.Add(Me.lblViolationDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDisciplineEnd)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(313, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(944, 107)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'SalaryIncreaseDate
        '
        Me.SalaryIncreaseDate.EditValue = Nothing
        Me.SalaryIncreaseDate.Location = New System.Drawing.Point(793, 17)
        Me.SalaryIncreaseDate.Name = "SalaryIncreaseDate"
        Me.SalaryIncreaseDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SalaryIncreaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SalaryIncreaseDate.Properties.DisplayFormat.FormatString = ""
        Me.SalaryIncreaseDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.SalaryIncreaseDate.Properties.EditFormat.FormatString = ""
        Me.SalaryIncreaseDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.SalaryIncreaseDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.SalaryIncreaseDate.Properties.MaskSettings.Set("mask", "d")
        Me.SalaryIncreaseDate.Properties.UseMaskAsDisplayFormat = True
        Me.SalaryIncreaseDate.Size = New System.Drawing.Size(120, 20)
        Me.SalaryIncreaseDate.TabIndex = 19
        Me.SalaryIncreaseDate.Visible = False
        '
        'ViolationDate
        '
        Me.ViolationDate.EditValue = Nothing
        Me.ViolationDate.Location = New System.Drawing.Point(115, 64)
        Me.ViolationDate.Name = "ViolationDate"
        Me.ViolationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ViolationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ViolationDate.Properties.DisplayFormat.FormatString = ""
        Me.ViolationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ViolationDate.Properties.EditFormat.FormatString = ""
        Me.ViolationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ViolationDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ViolationDate.Properties.MaskSettings.Set("mask", "d")
        Me.ViolationDate.Properties.UseMaskAsDisplayFormat = True
        Me.ViolationDate.Size = New System.Drawing.Size(201, 20)
        Me.ViolationDate.TabIndex = 17
        '
        'DisciplineEnd
        '
        Me.DisciplineEnd.EditValue = Nothing
        Me.DisciplineEnd.Location = New System.Drawing.Point(796, 44)
        Me.DisciplineEnd.Name = "DisciplineEnd"
        Me.DisciplineEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DisciplineEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DisciplineEnd.Properties.DisplayFormat.FormatString = ""
        Me.DisciplineEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DisciplineEnd.Properties.EditFormat.FormatString = ""
        Me.DisciplineEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DisciplineEnd.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.DisciplineEnd.Properties.MaskSettings.Set("mask", "d")
        Me.DisciplineEnd.Properties.UseMaskAsDisplayFormat = True
        Me.DisciplineEnd.Size = New System.Drawing.Size(120, 20)
        Me.DisciplineEnd.TabIndex = 15
        Me.DisciplineEnd.Visible = False
        '
        'DisciplineBegin
        '
        Me.DisciplineBegin.EditValue = Nothing
        Me.DisciplineBegin.Location = New System.Drawing.Point(115, 38)
        Me.DisciplineBegin.Name = "DisciplineBegin"
        Me.DisciplineBegin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DisciplineBegin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DisciplineBegin.Properties.DisplayFormat.FormatString = ""
        Me.DisciplineBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DisciplineBegin.Properties.EditFormat.FormatString = ""
        Me.DisciplineBegin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DisciplineBegin.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.DisciplineBegin.Properties.MaskSettings.Set("mask", "d")
        Me.DisciplineBegin.Properties.UseMaskAsDisplayFormat = True
        Me.DisciplineBegin.Size = New System.Drawing.Size(201, 20)
        Me.DisciplineBegin.TabIndex = 9
        '
        'BehaviorCode
        '
        Me.BehaviorCode.Location = New System.Drawing.Point(115, 12)
        Me.BehaviorCode.Name = "BehaviorCode"
        Me.BehaviorCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.BehaviorCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BehaviorCode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.BehaviorCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.BehaviorCode.Size = New System.Drawing.Size(201, 20)
        Me.BehaviorCode.TabIndex = 5
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.SystemColors.Control
        Me.lblReason.Location = New System.Drawing.Point(335, 15)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(103, 30)
        Me.lblReason.TabIndex = 1285
        Me.lblReason.Text = "Lý do"
        '
        'Reason
        '
        Me.Reason.Location = New System.Drawing.Point(444, 12)
        Me.Reason.Name = "Reason"
        Me.Reason.Size = New System.Drawing.Size(201, 42)
        Me.Reason.TabIndex = 7
        Me.Reason.Text = ""
        '
        'lblProcAsign
        '
        Me.lblProcAsign.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcAsign.Location = New System.Drawing.Point(665, 71)
        Me.lblProcAsign.Name = "lblProcAsign"
        Me.lblProcAsign.Size = New System.Drawing.Size(125, 20)
        Me.lblProcAsign.TabIndex = 1283
        Me.lblProcAsign.Text = "ProcAsign"
        Me.lblProcAsign.Visible = False
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(444, 60)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(201, 38)
        Me.Remark.TabIndex = 11
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(335, 63)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(103, 16)
        Me.lblRemark.TabIndex = 1272
        Me.lblRemark.Text = "Ghi chú"
        '
        'ProcAsign
        '
        Me.ProcAsign.Location = New System.Drawing.Point(796, 70)
        Me.ProcAsign.Name = "ProcAsign"
        Me.ProcAsign.Size = New System.Drawing.Size(129, 21)
        Me.ProcAsign.TabIndex = 13
        Me.ProcAsign.Visible = False
        '
        'lblBehaviorCode
        '
        Me.lblBehaviorCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBehaviorCode.Location = New System.Drawing.Point(6, 15)
        Me.lblBehaviorCode.Name = "lblBehaviorCode"
        Me.lblBehaviorCode.Size = New System.Drawing.Size(103, 18)
        Me.lblBehaviorCode.TabIndex = 1273
        Me.lblBehaviorCode.Text = "Hành vi"
        '
        'lblSalaryIncreaseDate
        '
        Me.lblSalaryIncreaseDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblSalaryIncreaseDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalaryIncreaseDate.Location = New System.Drawing.Point(672, 16)
        Me.lblSalaryIncreaseDate.Name = "lblSalaryIncreaseDate"
        Me.lblSalaryIncreaseDate.Size = New System.Drawing.Size(115, 20)
        Me.lblSalaryIncreaseDate.TabIndex = 1281
        Me.lblSalaryIncreaseDate.Text = "Ngày tăng lương"
        Me.lblSalaryIncreaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSalaryIncreaseDate.Visible = False
        '
        'lblDisciplineBegin
        '
        Me.lblDisciplineBegin.BackColor = System.Drawing.SystemColors.Control
        Me.lblDisciplineBegin.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblDisciplineBegin.Location = New System.Drawing.Point(6, 37)
        Me.lblDisciplineBegin.Name = "lblDisciplineBegin"
        Me.lblDisciplineBegin.Size = New System.Drawing.Size(103, 20)
        Me.lblDisciplineBegin.TabIndex = 1270
        Me.lblDisciplineBegin.Text = "Ngày lập BB"
        Me.lblDisciplineBegin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblViolationDate
        '
        Me.lblViolationDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblViolationDate.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblViolationDate.Location = New System.Drawing.Point(6, 62)
        Me.lblViolationDate.Name = "lblViolationDate"
        Me.lblViolationDate.Size = New System.Drawing.Size(103, 20)
        Me.lblViolationDate.TabIndex = 1279
        Me.lblViolationDate.Text = "Ngày vi phạm"
        Me.lblViolationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDisciplineEnd
        '
        Me.lblDisciplineEnd.BackColor = System.Drawing.SystemColors.Control
        Me.lblDisciplineEnd.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisciplineEnd.Location = New System.Drawing.Point(672, 43)
        Me.lblDisciplineEnd.Name = "lblDisciplineEnd"
        Me.lblDisciplineEnd.Size = New System.Drawing.Size(118, 20)
        Me.lblDisciplineEnd.TabIndex = 1277
        Me.lblDisciplineEnd.Text = "Ngày kết thúc BB"
        Me.lblDisciplineEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDisciplineEnd.Visible = False
        '
        'pnNhap
        '
        Me.pnNhap.Controls.Add(Me.btnSave)
        Me.pnNhap.Location = New System.Drawing.Point(1264, 4)
        Me.pnNhap.Name = "pnNhap"
        Me.pnNhap.Size = New System.Drawing.Size(57, 107)
        Me.pnNhap.TabIndex = 1325
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(2, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 36
        Me.btnSave.Text = "Lưu"
        '
        'frmDiscipline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1367, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_Discipline"
        Me.HRFORM_TableName = "HR_Discipline"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmDiscipline"
        Me.Text = "frmDiscipline"
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
        CType(Me.SalaryIncreaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalaryIncreaseDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViolationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViolationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisciplineEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisciplineEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisciplineBegin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DisciplineBegin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnNhap.ResumeLayout(False)
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
    Friend WithEvents SalaryIncreaseDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ViolationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DisciplineEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DisciplineBegin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BehaviorCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblReason As Label
    Friend WithEvents Reason As RichTextBox
    Friend WithEvents lblProcAsign As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents ProcAsign As TextBox
    Friend WithEvents lblBehaviorCode As Label
    Friend WithEvents lblSalaryIncreaseDate As Label
    Friend WithEvents lblDisciplineBegin As Label
    Friend WithEvents lblViolationDate As Label
    Friend WithEvents lblDisciplineEnd As Label
    Friend WithEvents pnNhap As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
