<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDangKyPhepTheoGio
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
        Me.cbViewAll = New System.Windows.Forms.CheckBox()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.LeaveType_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.TypeOfLeave = New DevExpress.XtraEditors.LookUpEdit()
        Me.DateLeave = New DevExpress.XtraEditors.DateEdit()
        Me.lblHourLeave = New System.Windows.Forms.Label()
        Me.HourLeave = New System.Windows.Forms.TextBox()
        Me.lblTypeOfLeave = New System.Windows.Forms.Label()
        Me.lblLeaveType_ID = New System.Windows.Forms.Label()
        Me.lblDateLeave = New System.Windows.Forms.Label()
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
        CType(Me.LeaveType_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeOfLeave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateLeave.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateLeave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 352)
        Me.PanelButton.Size = New System.Drawing.Size(1016, 54)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1016, 352)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1014, 327)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 85)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1010, 240)
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1014, 85)
        Me.TableLayoutPanel2.TabIndex = 1327
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.cbViewAll)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 75)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(29, 51)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1301
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
        Me.Employee_ID.TabIndex = 1220
        '
        'cbViewAll
        '
        Me.cbViewAll.AutoSize = True
        Me.cbViewAll.Location = New System.Drawing.Point(8, 53)
        Me.cbViewAll.Name = "cbViewAll"
        Me.cbViewAll.Size = New System.Drawing.Size(15, 14)
        Me.cbViewAll.TabIndex = 3
        Me.cbViewAll.UseVisualStyleBackColor = True
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
        Me.pnDuLieuNhap.Controls.Add(Me.LeaveType_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.TypeOfLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.DateLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.lblHourLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.HourLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.lblTypeOfLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.lblLeaveType_ID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblDateLeave)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(604, 77)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'LeaveType_ID
        '
        Me.LeaveType_ID.Location = New System.Drawing.Point(117, 55)
        Me.LeaveType_ID.Name = "LeaveType_ID"
        Me.LeaveType_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LeaveType_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LeaveType_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.LeaveType_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LeaveType_ID.Size = New System.Drawing.Size(161, 20)
        Me.LeaveType_ID.TabIndex = 1310
        '
        'TypeOfLeave
        '
        Me.TypeOfLeave.Location = New System.Drawing.Point(117, 31)
        Me.TypeOfLeave.Name = "TypeOfLeave"
        Me.TypeOfLeave.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TypeOfLeave.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeOfLeave.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TypeOfLeave.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TypeOfLeave.Size = New System.Drawing.Size(161, 20)
        Me.TypeOfLeave.TabIndex = 1309
        '
        'DateLeave
        '
        Me.DateLeave.EditValue = Nothing
        Me.DateLeave.Location = New System.Drawing.Point(117, 7)
        Me.DateLeave.Name = "DateLeave"
        Me.DateLeave.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateLeave.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateLeave.Properties.DisplayFormat.FormatString = ""
        Me.DateLeave.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateLeave.Properties.EditFormat.FormatString = ""
        Me.DateLeave.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateLeave.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.DateLeave.Properties.MaskSettings.Set("mask", "d")
        Me.DateLeave.Properties.UseMaskAsDisplayFormat = True
        Me.DateLeave.Size = New System.Drawing.Size(161, 20)
        Me.DateLeave.TabIndex = 1308
        '
        'lblHourLeave
        '
        Me.lblHourLeave.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHourLeave.Location = New System.Drawing.Point(371, 9)
        Me.lblHourLeave.Name = "lblHourLeave"
        Me.lblHourLeave.Size = New System.Drawing.Size(91, 20)
        Me.lblHourLeave.TabIndex = 1307
        Me.lblHourLeave.Text = "Số giờ"
        Me.lblHourLeave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HourLeave
        '
        Me.HourLeave.Location = New System.Drawing.Point(470, 8)
        Me.HourLeave.Name = "HourLeave"
        Me.HourLeave.Size = New System.Drawing.Size(59, 21)
        Me.HourLeave.TabIndex = 13
        '
        'lblTypeOfLeave
        '
        Me.lblTypeOfLeave.BackColor = System.Drawing.Color.Transparent
        Me.lblTypeOfLeave.Location = New System.Drawing.Point(7, 34)
        Me.lblTypeOfLeave.Name = "lblTypeOfLeave"
        Me.lblTypeOfLeave.Size = New System.Drawing.Size(104, 15)
        Me.lblTypeOfLeave.TabIndex = 1305
        Me.lblTypeOfLeave.Text = "Loại phép"
        Me.lblTypeOfLeave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeaveType_ID
        '
        Me.lblLeaveType_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_ID.Location = New System.Drawing.Point(7, 58)
        Me.lblLeaveType_ID.Name = "lblLeaveType_ID"
        Me.lblLeaveType_ID.Size = New System.Drawing.Size(104, 14)
        Me.lblLeaveType_ID.TabIndex = 1303
        Me.lblLeaveType_ID.Text = "Phép"
        Me.lblLeaveType_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateLeave
        '
        Me.lblDateLeave.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateLeave.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateLeave.Location = New System.Drawing.Point(7, 7)
        Me.lblDateLeave.Name = "lblDateLeave"
        Me.lblDateLeave.Size = New System.Drawing.Size(104, 20)
        Me.lblDateLeave.TabIndex = 1222
        Me.lblDateLeave.Text = "Ngày phép"
        Me.lblDateLeave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(470, 34)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(120, 36)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemark.Location = New System.Drawing.Point(371, 35)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(85, 16)
        Me.lblRemark.TabIndex = 1225
        Me.lblRemark.Text = "Ghi chú"
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(935, 4)
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
        'frmDangKyPhepTheoGio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_DangKyPhepTheoGio"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_DangKyPhepTheoGio"
        Me.HRFORM_TableName = "HR_DangKyPhepTheoGio"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmDangKyPhepTheoGio"
        Me.Text = "frmDangKyPhepTheoGio"
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
        Me.pnSearch.PerformLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDuLieuNhap.ResumeLayout(False)
        Me.pnDuLieuNhap.PerformLayout()
        CType(Me.LeaveType_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeOfLeave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateLeave.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateLeave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cbViewAll As CheckBox
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents LeaveType_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TypeOfLeave As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DateLeave As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblHourLeave As Label
    Friend WithEvents HourLeave As TextBox
    Friend WithEvents lblTypeOfLeave As Label
    Friend WithEvents lblLeaveType_ID As Label
    Friend WithEvents lblDateLeave As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblRemark As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
