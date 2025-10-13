<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuanLyTheTu
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
        Me.RFID = New DevExpress.XtraEditors.LookUpEdit()
        Me.EffectiveDate = New DevExpress.XtraEditors.DateEdit()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblRFID = New System.Windows.Forms.Label()
        Me.OldRFID = New System.Windows.Forms.TextBox()
        Me.lblEffectiveDate = New System.Windows.Forms.Label()
        Me.lblCurrentlyRFID = New System.Windows.Forms.Label()
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
        CType(Me.RFID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EffectiveDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 423)
        Me.PanelButton.Size = New System.Drawing.Size(1001, 55)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1001, 423)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(999, 398)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 91)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(996, 304)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(999, 89)
        Me.TableLayoutPanel2.TabIndex = 1317
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(226, 81)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(4, 50)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1227
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(3, 24)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(220, 20)
        Me.Employee_ID.TabIndex = 1225
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployee_ID.Location = New System.Drawing.Point(7, 5)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(99, 23)
        Me.lblEmployee_ID.TabIndex = 1226
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.AutoScroll = True
        Me.pnDuLieuNhap.Controls.Add(Me.RFID)
        Me.pnDuLieuNhap.Controls.Add(Me.EffectiveDate)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRFID)
        Me.pnDuLieuNhap.Controls.Add(Me.OldRFID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblEffectiveDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCurrentlyRFID)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(237, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(505, 81)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'RFID
        '
        Me.RFID.Location = New System.Drawing.Point(121, 35)
        Me.RFID.Name = "RFID"
        Me.RFID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.RFID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RFID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.RFID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.RFID.Size = New System.Drawing.Size(112, 20)
        Me.RFID.TabIndex = 1318
        '
        'EffectiveDate
        '
        Me.EffectiveDate.EditValue = Nothing
        Me.EffectiveDate.Location = New System.Drawing.Point(338, 12)
        Me.EffectiveDate.Name = "EffectiveDate"
        Me.EffectiveDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EffectiveDate.Properties.DisplayFormat.FormatString = ""
        Me.EffectiveDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EffectiveDate.Properties.EditFormat.FormatString = ""
        Me.EffectiveDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EffectiveDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.EffectiveDate.Properties.MaskSettings.Set("mask", "d")
        Me.EffectiveDate.Properties.UseMaskAsDisplayFormat = True
        Me.EffectiveDate.Size = New System.Drawing.Size(112, 20)
        Me.EffectiveDate.TabIndex = 1349
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(338, 35)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(135, 42)
        Me.Remark.TabIndex = 1308
        Me.Remark.Text = ""
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(244, 38)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(63, 19)
        Me.lblRemark.TabIndex = 1310
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRFID
        '
        Me.lblRFID.BackColor = System.Drawing.Color.Transparent
        Me.lblRFID.Location = New System.Drawing.Point(11, 32)
        Me.lblRFID.Name = "lblRFID"
        Me.lblRFID.Size = New System.Drawing.Size(104, 19)
        Me.lblRFID.TabIndex = 1312
        Me.lblRFID.Text = "RFID"
        Me.lblRFID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OldRFID
        '
        Me.OldRFID.Location = New System.Drawing.Point(121, 8)
        Me.OldRFID.Name = "OldRFID"
        Me.OldRFID.Size = New System.Drawing.Size(112, 21)
        Me.OldRFID.TabIndex = 4
        '
        'lblEffectiveDate
        '
        Me.lblEffectiveDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEffectiveDate.Location = New System.Drawing.Point(244, 11)
        Me.lblEffectiveDate.Name = "lblEffectiveDate"
        Me.lblEffectiveDate.Size = New System.Drawing.Size(88, 19)
        Me.lblEffectiveDate.TabIndex = 1314
        Me.lblEffectiveDate.Text = "Ngày hiệu lực"
        Me.lblEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrentlyRFID
        '
        Me.lblCurrentlyRFID.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentlyRFID.Location = New System.Drawing.Point(11, 8)
        Me.lblCurrentlyRFID.Name = "lblCurrentlyRFID"
        Me.lblCurrentlyRFID.Size = New System.Drawing.Size(104, 19)
        Me.lblCurrentlyRFID.TabIndex = 1316
        Me.lblCurrentlyRFID.Text = "RFID hiện tại"
        Me.lblCurrentlyRFID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(749, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 77)
        Me.pnLuu.TabIndex = 1327
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 70
        Me.btnSave.Text = "Lưu"
        '
        'frmQuanLyTheTu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 478)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteHR_Transfer"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateHR_Transfer"
        Me.HRFORM_TableName = "HR_Transfer"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmQuanLyTheTu"
        Me.Text = "frmQuanLyTheTu"
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
        CType(Me.RFID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EffectiveDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EffectiveDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblCurrentlyRFID As Label
    Friend WithEvents lblEffectiveDate As Label
    Friend WithEvents lblRFID As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents pnSearch As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents EffectiveDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents OldRFID As TextBox
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RFID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
