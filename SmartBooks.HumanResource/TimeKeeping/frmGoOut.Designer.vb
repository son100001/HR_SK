<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoOut
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
        Me.RepositoryItemDateTimeOffsetEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateTimeOffsetEdit()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.TimeIn = New DevExpress.XtraEditors.DateTimeOffsetEdit()
        Me.TimeOut_ = New DevExpress.XtraEditors.DateTimeOffsetEdit()
        Me.TimeDate = New DevExpress.XtraEditors.DateEdit()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTimeDate = New System.Windows.Forms.Label()
        Me.lblShiftName = New System.Windows.Forms.Label()
        Me.lblTimeOut_ = New System.Windows.Forms.Label()
        Me.lblTimeIn = New System.Windows.Forms.Label()
        Me.LeaveType_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.ShiftName = New DevExpress.XtraEditors.LookUpEdit()
        Me.pnLuu = New System.Windows.Forms.Panel()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateTimeOffsetEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        CType(Me.TimeIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeOut_.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeaveType_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Size = New System.Drawing.Size(1288, 51)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1288, 355)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1286, 330)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(4, 87)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateTimeOffsetEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1282, 241)
        Me.GridControl1.TabIndex = 1328
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'RepositoryItemDateTimeOffsetEdit1
        '
        Me.RepositoryItemDateTimeOffsetEdit1.AutoHeight = False
        Me.RepositoryItemDateTimeOffsetEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateTimeOffsetEdit1.Name = "RepositoryItemDateTimeOffsetEdit1"
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1286, 85)
        Me.TableLayoutPanel2.TabIndex = 1327
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 77)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(5, 49)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(53, 23)
        Me.btnSearch.TabIndex = 1221
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(5, 25)
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
        Me.pnDuLieuNhap.Controls.Add(Me.TimeIn)
        Me.pnDuLieuNhap.Controls.Add(Me.TimeOut_)
        Me.pnDuLieuNhap.Controls.Add(Me.TimeDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.Label1)
        Me.pnDuLieuNhap.Controls.Add(Me.Label2)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTimeDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblShiftName)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTimeOut_)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTimeIn)
        Me.pnDuLieuNhap.Controls.Add(Me.LeaveType_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.ShiftName)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(868, 77)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'TimeIn
        '
        Me.TimeIn.EditValue = Nothing
        Me.TimeIn.Location = New System.Drawing.Point(572, 29)
        Me.TimeIn.Name = "TimeIn"
        Me.TimeIn.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeIn.Properties.MaskSettings.Set("mask", "t")
        Me.TimeIn.Size = New System.Drawing.Size(103, 20)
        Me.TimeIn.TabIndex = 11
        '
        'TimeOut_
        '
        Me.TimeOut_.EditValue = Nothing
        Me.TimeOut_.Location = New System.Drawing.Point(572, 5)
        Me.TimeOut_.Name = "TimeOut_"
        Me.TimeOut_.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeOut_.Properties.MaskSettings.Set("mask", "t")
        Me.TimeOut_.Size = New System.Drawing.Size(103, 20)
        Me.TimeOut_.TabIndex = 9
        '
        'TimeDate
        '
        Me.TimeDate.EditValue = Nothing
        Me.TimeDate.Location = New System.Drawing.Point(377, 5)
        Me.TimeDate.Name = "TimeDate"
        Me.TimeDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeDate.Properties.DisplayFormat.FormatString = ""
        Me.TimeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TimeDate.Properties.EditFormat.FormatString = ""
        Me.TimeDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TimeDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.TimeDate.Properties.MaskSettings.Set("mask", "d")
        Me.TimeDate.Properties.UseMaskAsDisplayFormat = True
        Me.TimeDate.Size = New System.Drawing.Size(118, 20)
        Me.TimeDate.TabIndex = 5
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(744, 6)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(121, 43)
        Me.Remark.TabIndex = 13
        Me.Remark.Text = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(291, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 1317
        Me.Label1.Text = "Phép"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(683, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 1322
        Me.Label2.Text = "Ghi chú"
        '
        'lblTimeDate
        '
        Me.lblTimeDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblTimeDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeDate.Location = New System.Drawing.Point(289, 6)
        Me.lblTimeDate.Name = "lblTimeDate"
        Me.lblTimeDate.Size = New System.Drawing.Size(81, 20)
        Me.lblTimeDate.TabIndex = 1318
        Me.lblTimeDate.Text = "Ngày"
        Me.lblTimeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShiftName
        '
        Me.lblShiftName.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftName.Location = New System.Drawing.Point(17, 9)
        Me.lblShiftName.Name = "lblShiftName"
        Me.lblShiftName.Size = New System.Drawing.Size(96, 19)
        Me.lblShiftName.TabIndex = 1321
        Me.lblShiftName.Text = "Ca"
        Me.lblShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTimeOut_
        '
        Me.lblTimeOut_.BackColor = System.Drawing.SystemColors.Control
        Me.lblTimeOut_.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeOut_.Location = New System.Drawing.Point(501, 5)
        Me.lblTimeOut_.Name = "lblTimeOut_"
        Me.lblTimeOut_.Size = New System.Drawing.Size(72, 20)
        Me.lblTimeOut_.TabIndex = 1320
        Me.lblTimeOut_.Text = "Giờ ra"
        Me.lblTimeOut_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTimeIn
        '
        Me.lblTimeIn.BackColor = System.Drawing.SystemColors.Control
        Me.lblTimeIn.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeIn.Location = New System.Drawing.Point(501, 29)
        Me.lblTimeIn.Name = "lblTimeIn"
        Me.lblTimeIn.Size = New System.Drawing.Size(72, 20)
        Me.lblTimeIn.TabIndex = 1319
        Me.lblTimeIn.Text = "Giờ vào"
        Me.lblTimeIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LeaveType_ID
        '
        Me.LeaveType_ID.Location = New System.Drawing.Point(377, 29)
        Me.LeaveType_ID.Name = "LeaveType_ID"
        Me.LeaveType_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LeaveType_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LeaveType_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LeaveType_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LeaveType_ID.Size = New System.Drawing.Size(118, 20)
        Me.LeaveType_ID.TabIndex = 7
        '
        'ShiftName
        '
        Me.ShiftName.Location = New System.Drawing.Point(120, 9)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ShiftName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ShiftName.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ShiftName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ShiftName.Size = New System.Drawing.Size(154, 20)
        Me.ShiftName.TabIndex = 3
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1199, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
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
        'frmGoOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1288, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_GoOut"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_GoOut"
        Me.HRFORM_TableName = "HR_GoOut"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmGoOut"
        Me.Text = "frmGoOut"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateTimeOffsetEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnSearch.ResumeLayout(False)
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        CType(Me.TimeIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeOut_.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeaveType_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemDateTimeOffsetEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateTimeOffsetEdit
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents TimeIn As DevExpress.XtraEditors.DateTimeOffsetEdit
    Friend WithEvents TimeOut_ As DevExpress.XtraEditors.DateTimeOffsetEdit
    Friend WithEvents TimeDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTimeDate As Label
    Friend WithEvents lblShiftName As Label
    Friend WithEvents lblTimeOut_ As Label
    Friend WithEvents lblTimeIn As Label
    Friend WithEvents LeaveType_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ShiftName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
