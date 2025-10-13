<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTheBHYT
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.MaBenhVien = New DevExpress.XtraEditors.LookUpEdit()
        Me.NgayTraThe = New DevExpress.XtraEditors.DateEdit()
        Me.todate = New DevExpress.XtraEditors.DateEdit()
        Me.fromdate = New DevExpress.XtraEditors.DateEdit()
        Me.MaSoThe = New System.Windows.Forms.TextBox()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblMaBenhVien = New System.Windows.Forms.Label()
        Me.lblNgayTraThe = New System.Windows.Forms.Label()
        Me.lbltodate = New System.Windows.Forms.Label()
        Me.lblfromdate = New System.Windows.Forms.Label()
        Me.lblMaSoThe = New System.Windows.Forms.Label()
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
        CType(Me.MaBenhVien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayTraThe.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayTraThe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNhap.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 386)
        Me.PanelButton.Size = New System.Drawing.Size(1166, 48)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1166, 386)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1164, 361)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 106)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1164, 255)
        Me.GridControl1.TabIndex = 1322
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnSearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnDuLieuNhap, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnNhap, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1164, 106)
        Me.TableLayoutPanel2.TabIndex = 1307
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.Label3)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(232, 98)
        Me.pnSearch.TabIndex = 1320
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(12, 63)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(60, 20)
        Me.btnSearch.TabIndex = 1280
        Me.btnSearch.Text = "Tìm"
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(12, 37)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_ID.Size = New System.Drawing.Size(208, 20)
        Me.Employee_ID.TabIndex = 1278
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(13, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 23)
        Me.Label3.TabIndex = 1279
        Me.Label3.Text = "Mã nhân viên"
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.MaBenhVien)
        Me.pnDuLieuNhap.Controls.Add(Me.NgayTraThe)
        Me.pnDuLieuNhap.Controls.Add(Me.todate)
        Me.pnDuLieuNhap.Controls.Add(Me.fromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.MaSoThe)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMaBenhVien)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNgayTraThe)
        Me.pnDuLieuNhap.Controls.Add(Me.lbltodate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblfromdate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMaSoThe)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(243, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(807, 98)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'MaBenhVien
        '
        Me.MaBenhVien.Location = New System.Drawing.Point(385, 32)
        Me.MaBenhVien.Name = "MaBenhVien"
        Me.MaBenhVien.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.MaBenhVien.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MaBenhVien.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.MaBenhVien.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.MaBenhVien.Size = New System.Drawing.Size(391, 20)
        Me.MaBenhVien.TabIndex = 1350
        '
        'NgayTraThe
        '
        Me.NgayTraThe.EditValue = Nothing
        Me.NgayTraThe.Location = New System.Drawing.Point(385, 7)
        Me.NgayTraThe.Name = "NgayTraThe"
        Me.NgayTraThe.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayTraThe.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayTraThe.Properties.DisplayFormat.FormatString = ""
        Me.NgayTraThe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayTraThe.Properties.EditFormat.FormatString = ""
        Me.NgayTraThe.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayTraThe.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.NgayTraThe.Properties.MaskSettings.Set("mask", "d")
        Me.NgayTraThe.Properties.UseMaskAsDisplayFormat = True
        Me.NgayTraThe.Size = New System.Drawing.Size(112, 20)
        Me.NgayTraThe.TabIndex = 1243
        '
        'todate
        '
        Me.todate.EditValue = Nothing
        Me.todate.Location = New System.Drawing.Point(123, 55)
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
        Me.todate.Size = New System.Drawing.Size(112, 20)
        Me.todate.TabIndex = 1242
        '
        'fromdate
        '
        Me.fromdate.EditValue = Nothing
        Me.fromdate.Location = New System.Drawing.Point(123, 31)
        Me.fromdate.Name = "fromdate"
        Me.fromdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.fromdate.Properties.DisplayFormat.FormatString = ""
        Me.fromdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditFormat.FormatString = ""
        Me.fromdate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.fromdate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.fromdate.Properties.MaskSettings.Set("mask", "d")
        Me.fromdate.Properties.UseMaskAsDisplayFormat = True
        Me.fromdate.Size = New System.Drawing.Size(112, 20)
        Me.fromdate.TabIndex = 1241
        '
        'MaSoThe
        '
        Me.MaSoThe.Location = New System.Drawing.Point(123, 7)
        Me.MaSoThe.Name = "MaSoThe"
        Me.MaSoThe.Size = New System.Drawing.Size(112, 21)
        Me.MaSoThe.TabIndex = 1240
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.SystemColors.Menu
        Me.lblRemark.Location = New System.Drawing.Point(265, 62)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(64, 16)
        Me.lblRemark.TabIndex = 1239
        Me.lblRemark.Text = "Ghi chú"
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(385, 55)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(391, 40)
        Me.Remark.TabIndex = 15
        Me.Remark.Text = ""
        '
        'lblMaBenhVien
        '
        Me.lblMaBenhVien.BackColor = System.Drawing.Color.Transparent
        Me.lblMaBenhVien.Location = New System.Drawing.Point(265, 32)
        Me.lblMaBenhVien.Name = "lblMaBenhVien"
        Me.lblMaBenhVien.Size = New System.Drawing.Size(114, 19)
        Me.lblMaBenhVien.TabIndex = 181
        Me.lblMaBenhVien.Text = "Mã bệnh viện"
        Me.lblMaBenhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNgayTraThe
        '
        Me.lblNgayTraThe.BackColor = System.Drawing.Color.Transparent
        Me.lblNgayTraThe.Location = New System.Drawing.Point(265, 7)
        Me.lblNgayTraThe.Name = "lblNgayTraThe"
        Me.lblNgayTraThe.Size = New System.Drawing.Size(105, 19)
        Me.lblNgayTraThe.TabIndex = 179
        Me.lblNgayTraThe.Text = "Ngày trả thẻ"
        Me.lblNgayTraThe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltodate
        '
        Me.lbltodate.BackColor = System.Drawing.Color.Transparent
        Me.lbltodate.Location = New System.Drawing.Point(3, 55)
        Me.lbltodate.Name = "lbltodate"
        Me.lbltodate.Size = New System.Drawing.Size(96, 19)
        Me.lbltodate.TabIndex = 84
        Me.lbltodate.Text = "Đến ngày"
        Me.lbltodate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblfromdate
        '
        Me.lblfromdate.BackColor = System.Drawing.Color.Transparent
        Me.lblfromdate.Location = New System.Drawing.Point(3, 31)
        Me.lblfromdate.Name = "lblfromdate"
        Me.lblfromdate.Size = New System.Drawing.Size(96, 19)
        Me.lblfromdate.TabIndex = 83
        Me.lblfromdate.Text = "Từ ngày"
        Me.lblfromdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaSoThe
        '
        Me.lblMaSoThe.BackColor = System.Drawing.Color.Transparent
        Me.lblMaSoThe.Location = New System.Drawing.Point(3, 7)
        Me.lblMaSoThe.Name = "lblMaSoThe"
        Me.lblMaSoThe.Size = New System.Drawing.Size(96, 19)
        Me.lblMaSoThe.TabIndex = 82
        Me.lblMaSoThe.Text = "Số thẻ"
        Me.lblMaSoThe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnNhap
        '
        Me.pnNhap.Controls.Add(Me.btnSave)
        Me.pnNhap.Location = New System.Drawing.Point(1057, 4)
        Me.pnNhap.Name = "pnNhap"
        Me.pnNhap.Size = New System.Drawing.Size(57, 78)
        Me.pnNhap.TabIndex = 1325
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.Location = New System.Drawing.Point(0, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(57, 78)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Lưu"
        '
        'frmTheBHYT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1166, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_TheBHYT"
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmTheBHYT"
        Me.Text = "frmTheBHYT"
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
        CType(Me.MaBenhVien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayTraThe.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayTraThe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.todate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fromdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblMaBenhVien As Label
    Friend WithEvents lblNgayTraThe As Label
    Friend WithEvents lbltodate As Label
    Friend WithEvents lblfromdate As Label
    Friend WithEvents lblMaSoThe As Label
    Friend WithEvents pnNhap As Panel
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Employee_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents MaSoThe As TextBox
    Friend WithEvents MaBenhVien As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents NgayTraThe As DevExpress.XtraEditors.DateEdit
    Friend WithEvents todate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents fromdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
