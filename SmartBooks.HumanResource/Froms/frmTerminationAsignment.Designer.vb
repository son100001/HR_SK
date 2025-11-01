<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTerminationAsignment
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
        Me.ThangTinhLuong = New DevExpress.XtraEditors.DateEdit()
        Me.NgayNopDon = New DevExpress.XtraEditors.DateEdit()
        Me.PlanTernimationDate = New DevExpress.XtraEditors.DateEdit()
        Me.DecisionStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.ResonTerminated = New DevExpress.XtraEditors.LookUpEdit()
        Me.DecisionCode = New System.Windows.Forms.TextBox()
        Me.lblThangTinhLuong = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblPlanTernimationDate = New System.Windows.Forms.Label()
        Me.lblResonTerminated = New System.Windows.Forms.Label()
        Me.lblNgayNopDon = New System.Windows.Forms.Label()
        Me.lblDecisionStatus = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
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
        CType(Me.ThangTinhLuong.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThangTinhLuong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayNopDon.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayNopDon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanTernimationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanTernimationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DecisionStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResonTerminated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GridControl1.Location = New System.Drawing.Point(3, 117)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1360, 208)
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
        Me.pnDuLieuNhap.Controls.Add(Me.ThangTinhLuong)
        Me.pnDuLieuNhap.Controls.Add(Me.NgayNopDon)
        Me.pnDuLieuNhap.Controls.Add(Me.PlanTernimationDate)
        Me.pnDuLieuNhap.Controls.Add(Me.DecisionStatus)
        Me.pnDuLieuNhap.Controls.Add(Me.ResonTerminated)
        Me.pnDuLieuNhap.Controls.Add(Me.DecisionCode)
        Me.pnDuLieuNhap.Controls.Add(Me.lblThangTinhLuong)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPlanTernimationDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblResonTerminated)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNgayNopDon)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDecisionStatus)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(313, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(875, 107)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'ThangTinhLuong
        '
        Me.ThangTinhLuong.EditValue = Nothing
        Me.ThangTinhLuong.Location = New System.Drawing.Point(514, 52)
        Me.ThangTinhLuong.Name = "ThangTinhLuong"
        Me.ThangTinhLuong.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ThangTinhLuong.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ThangTinhLuong.Properties.DisplayFormat.FormatString = ""
        Me.ThangTinhLuong.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ThangTinhLuong.Properties.EditFormat.FormatString = ""
        Me.ThangTinhLuong.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ThangTinhLuong.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ThangTinhLuong.Properties.MaskSettings.Set("mask", "MM/yyyy")
        Me.ThangTinhLuong.Properties.UseMaskAsDisplayFormat = True
        Me.ThangTinhLuong.Size = New System.Drawing.Size(120, 20)
        Me.ThangTinhLuong.TabIndex = 13
        Me.ThangTinhLuong.Visible = False
        '
        'NgayNopDon
        '
        Me.NgayNopDon.EditValue = Nothing
        Me.NgayNopDon.Location = New System.Drawing.Point(514, 29)
        Me.NgayNopDon.Name = "NgayNopDon"
        Me.NgayNopDon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayNopDon.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayNopDon.Properties.DisplayFormat.FormatString = ""
        Me.NgayNopDon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayNopDon.Properties.EditFormat.FormatString = ""
        Me.NgayNopDon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayNopDon.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.NgayNopDon.Properties.MaskSettings.Set("mask", "d")
        Me.NgayNopDon.Properties.UseMaskAsDisplayFormat = True
        Me.NgayNopDon.Size = New System.Drawing.Size(120, 20)
        Me.NgayNopDon.TabIndex = 11
        '
        'PlanTernimationDate
        '
        Me.PlanTernimationDate.EditValue = Nothing
        Me.PlanTernimationDate.Location = New System.Drawing.Point(514, 6)
        Me.PlanTernimationDate.Name = "PlanTernimationDate"
        Me.PlanTernimationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanTernimationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanTernimationDate.Properties.DisplayFormat.FormatString = ""
        Me.PlanTernimationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PlanTernimationDate.Properties.EditFormat.FormatString = ""
        Me.PlanTernimationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PlanTernimationDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.PlanTernimationDate.Properties.MaskSettings.Set("mask", "d")
        Me.PlanTernimationDate.Properties.UseMaskAsDisplayFormat = True
        Me.PlanTernimationDate.Size = New System.Drawing.Size(120, 20)
        Me.PlanTernimationDate.TabIndex = 9
        '
        'DecisionStatus
        '
        Me.DecisionStatus.Location = New System.Drawing.Point(151, 48)
        Me.DecisionStatus.Name = "DecisionStatus"
        Me.DecisionStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.DecisionStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DecisionStatus.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.DecisionStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.DecisionStatus.Size = New System.Drawing.Size(171, 20)
        Me.DecisionStatus.TabIndex = 7
        '
        'ResonTerminated
        '
        Me.ResonTerminated.Location = New System.Drawing.Point(151, 7)
        Me.ResonTerminated.Name = "ResonTerminated"
        Me.ResonTerminated.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ResonTerminated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ResonTerminated.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ResonTerminated.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ResonTerminated.Size = New System.Drawing.Size(171, 20)
        Me.ResonTerminated.TabIndex = 5
        '
        'DecisionCode
        '
        Me.DecisionCode.Location = New System.Drawing.Point(9, 69)
        Me.DecisionCode.Name = "DecisionCode"
        Me.DecisionCode.Size = New System.Drawing.Size(32, 21)
        Me.DecisionCode.TabIndex = 1294
        Me.DecisionCode.Visible = False
        '
        'lblThangTinhLuong
        '
        Me.lblThangTinhLuong.BackColor = System.Drawing.SystemColors.Control
        Me.lblThangTinhLuong.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThangTinhLuong.Location = New System.Drawing.Point(326, 51)
        Me.lblThangTinhLuong.Name = "lblThangTinhLuong"
        Me.lblThangTinhLuong.Size = New System.Drawing.Size(182, 20)
        Me.lblThangTinhLuong.TabIndex = 1292
        Me.lblThangTinhLuong.Text = "Tháng tính lương"
        Me.lblThangTinhLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblThangTinhLuong.Visible = False
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(677, 22)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(173, 58)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblPlanTernimationDate
        '
        Me.lblPlanTernimationDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlanTernimationDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanTernimationDate.Location = New System.Drawing.Point(327, 5)
        Me.lblPlanTernimationDate.Name = "lblPlanTernimationDate"
        Me.lblPlanTernimationDate.Size = New System.Drawing.Size(181, 20)
        Me.lblPlanTernimationDate.TabIndex = 1287
        Me.lblPlanTernimationDate.Text = "Ngày dự định nghỉ"
        Me.lblPlanTernimationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResonTerminated
        '
        Me.lblResonTerminated.BackColor = System.Drawing.Color.Transparent
        Me.lblResonTerminated.Location = New System.Drawing.Point(15, 10)
        Me.lblResonTerminated.Name = "lblResonTerminated"
        Me.lblResonTerminated.Size = New System.Drawing.Size(130, 19)
        Me.lblResonTerminated.TabIndex = 1288
        Me.lblResonTerminated.Text = "Lý do"
        Me.lblResonTerminated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayNopDon
        '
        Me.lblNgayNopDon.BackColor = System.Drawing.SystemColors.Control
        Me.lblNgayNopDon.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgayNopDon.Location = New System.Drawing.Point(328, 27)
        Me.lblNgayNopDon.Name = "lblNgayNopDon"
        Me.lblNgayNopDon.Size = New System.Drawing.Size(180, 20)
        Me.lblNgayNopDon.TabIndex = 1291
        Me.lblNgayNopDon.Text = "Ngày nộp đơn"
        Me.lblNgayNopDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDecisionStatus
        '
        Me.lblDecisionStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblDecisionStatus.Location = New System.Drawing.Point(15, 47)
        Me.lblDecisionStatus.Name = "lblDecisionStatus"
        Me.lblDecisionStatus.Size = New System.Drawing.Size(130, 19)
        Me.lblDecisionStatus.TabIndex = 1289
        Me.lblDecisionStatus.Text = "Trạng thái"
        Me.lblDecisionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(677, 3)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 16)
        Me.lblRemark.TabIndex = 1290
        Me.lblRemark.Text = "Ghi chú"
        '
        'pnNhap
        '
        Me.pnNhap.Controls.Add(Me.btnSave)
        Me.pnNhap.Location = New System.Drawing.Point(1195, 4)
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
        'frmTerminationAsignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1367, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_TerminationAsignment"
        Me.HRFORM_TableName = "HR_TerminationAsignment"
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmTerminationAsignment"
        Me.Text = "frmTerminationAsignment"
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
        CType(Me.ThangTinhLuong.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThangTinhLuong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayNopDon.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayNopDon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanTernimationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanTernimationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DecisionStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResonTerminated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ThangTinhLuong As DevExpress.XtraEditors.DateEdit
    Friend WithEvents NgayNopDon As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PlanTernimationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DecisionStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ResonTerminated As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DecisionCode As TextBox
    Friend WithEvents lblThangTinhLuong As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblPlanTernimationDate As Label
    Friend WithEvents lblResonTerminated As Label
    Friend WithEvents lblNgayNopDon As Label
    Friend WithEvents lblDecisionStatus As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents pnNhap As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
