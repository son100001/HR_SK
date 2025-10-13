<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhieuLuongMoi
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnSearch = New System.Windows.Forms.Panel()
        Me.cboYear = New WindowsControlLibrary.Year()
        Me.cboMonth = New WindowsControlLibrary.Month()
        Me.lblnam = New System.Windows.Forms.Label()
        Me.lblthang = New System.Windows.Forms.Label()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Employee_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.btnGuiPhieuLuong = New DevExpress.XtraEditors.SimpleButton()
        Me.UiButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.lbBCC = New System.Windows.Forms.Label()
        Me.tbBCC = New System.Windows.Forms.TextBox()
        Me.lbChuDe = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.lbCC = New System.Windows.Forms.Label()
        Me.tbCC = New System.Windows.Forms.TextBox()
        Me.lbMatKhau = New System.Windows.Forms.Label()
        Me.tbpassemailfrom = New System.Windows.Forms.TextBox()
        Me.lbFrommail = New System.Windows.Forms.Label()
        Me.tbEmailFrom = New System.Windows.Forms.TextBox()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnSearch.SuspendLayout()
        CType(Me.Employee_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDuLieuNhap.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Size = New System.Drawing.Size(1109, 51)
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(1109, 355)
        Me.XtraTabControl1.TabIndex = 1010
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel2)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1107, 330)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 94)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1107, 236)
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
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1107, 94)
        Me.TableLayoutPanel2.TabIndex = 1327
        '
        'pnSearch
        '
        Me.pnSearch.Controls.Add(Me.cboYear)
        Me.pnSearch.Controls.Add(Me.cboMonth)
        Me.pnSearch.Controls.Add(Me.lblnam)
        Me.pnSearch.Controls.Add(Me.lblthang)
        Me.pnSearch.Controls.Add(Me.btnSearch)
        Me.pnSearch.Controls.Add(Me.Employee_ID)
        Me.pnSearch.Controls.Add(Me.lblEmployee_ID)
        Me.pnSearch.Location = New System.Drawing.Point(4, 4)
        Me.pnSearch.Name = "pnSearch"
        Me.pnSearch.Size = New System.Drawing.Size(313, 86)
        Me.pnSearch.TabIndex = 1320
        '
        'cboYear
        '
        Me.cboYear.Location = New System.Drawing.Point(236, 51)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(60, 26)
        Me.cboYear.TabIndex = 1306
        '
        'cboMonth
        '
        Me.cboMonth.Location = New System.Drawing.Point(128, 51)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(42, 26)
        Me.cboMonth.TabIndex = 1305
        '
        'lblnam
        '
        Me.lblnam.BackColor = System.Drawing.Color.Transparent
        Me.lblnam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnam.Location = New System.Drawing.Point(182, 56)
        Me.lblnam.Name = "lblnam"
        Me.lblnam.Size = New System.Drawing.Size(48, 21)
        Me.lblnam.TabIndex = 1303
        Me.lblnam.Text = "Year:"
        Me.lblnam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblthang
        '
        Me.lblthang.BackColor = System.Drawing.Color.Transparent
        Me.lblthang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblthang.Location = New System.Drawing.Point(74, 55)
        Me.lblthang.Name = "lblthang"
        Me.lblthang.Size = New System.Drawing.Size(48, 21)
        Me.lblthang.TabIndex = 1304
        Me.lblthang.Text = "Month:"
        Me.lblthang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnDuLieuNhap.Controls.Add(Me.btnGuiPhieuLuong)
        Me.pnDuLieuNhap.Controls.Add(Me.UiButton1)
        Me.pnDuLieuNhap.Controls.Add(Me.lbBCC)
        Me.pnDuLieuNhap.Controls.Add(Me.tbBCC)
        Me.pnDuLieuNhap.Controls.Add(Me.lbChuDe)
        Me.pnDuLieuNhap.Controls.Add(Me.txtSubject)
        Me.pnDuLieuNhap.Controls.Add(Me.lbCC)
        Me.pnDuLieuNhap.Controls.Add(Me.tbCC)
        Me.pnDuLieuNhap.Controls.Add(Me.lbMatKhau)
        Me.pnDuLieuNhap.Controls.Add(Me.tbpassemailfrom)
        Me.pnDuLieuNhap.Controls.Add(Me.lbFrommail)
        Me.pnDuLieuNhap.Controls.Add(Me.tbEmailFrom)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(324, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(662, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'btnGuiPhieuLuong
        '
        Me.btnGuiPhieuLuong.Location = New System.Drawing.Point(314, 60)
        Me.btnGuiPhieuLuong.Name = "btnGuiPhieuLuong"
        Me.btnGuiPhieuLuong.Size = New System.Drawing.Size(124, 20)
        Me.btnGuiPhieuLuong.TabIndex = 1303
        Me.btnGuiPhieuLuong.Text = "Gửi phiếu lương"
        '
        'UiButton1
        '
        Me.UiButton1.Location = New System.Drawing.Point(314, 8)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(60, 20)
        Me.UiButton1.TabIndex = 1302
        Me.UiButton1.Text = "Save"
        '
        'lbBCC
        '
        Me.lbBCC.Location = New System.Drawing.Point(381, 8)
        Me.lbBCC.Name = "lbBCC"
        Me.lbBCC.Size = New System.Drawing.Size(37, 20)
        Me.lbBCC.TabIndex = 86
        Me.lbBCC.Text = "BCC"
        Me.lbBCC.Visible = False
        '
        'tbBCC
        '
        Me.tbBCC.Location = New System.Drawing.Point(424, 8)
        Me.tbBCC.Name = "tbBCC"
        Me.tbBCC.Size = New System.Drawing.Size(14, 21)
        Me.tbBCC.TabIndex = 85
        Me.tbBCC.Visible = False
        '
        'lbChuDe
        '
        Me.lbChuDe.Location = New System.Drawing.Point(12, 60)
        Me.lbChuDe.Name = "lbChuDe"
        Me.lbChuDe.Size = New System.Drawing.Size(64, 16)
        Me.lbChuDe.TabIndex = 84
        Me.lbChuDe.Text = "Chủ đề"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(76, 60)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(232, 21)
        Me.txtSubject.TabIndex = 83
        '
        'lbCC
        '
        Me.lbCC.Location = New System.Drawing.Point(12, 34)
        Me.lbCC.Name = "lbCC"
        Me.lbCC.Size = New System.Drawing.Size(64, 23)
        Me.lbCC.TabIndex = 82
        Me.lbCC.Text = "CC"
        '
        'tbCC
        '
        Me.tbCC.Location = New System.Drawing.Point(76, 34)
        Me.tbCC.Name = "tbCC"
        Me.tbCC.Size = New System.Drawing.Size(232, 21)
        Me.tbCC.TabIndex = 81
        '
        'lbMatKhau
        '
        Me.lbMatKhau.Location = New System.Drawing.Point(164, 8)
        Me.lbMatKhau.Name = "lbMatKhau"
        Me.lbMatKhau.Size = New System.Drawing.Size(56, 23)
        Me.lbMatKhau.TabIndex = 80
        Me.lbMatKhau.Text = "Mật khẩu"
        '
        'tbpassemailfrom
        '
        Me.tbpassemailfrom.Location = New System.Drawing.Point(220, 8)
        Me.tbpassemailfrom.Name = "tbpassemailfrom"
        Me.tbpassemailfrom.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbpassemailfrom.Size = New System.Drawing.Size(88, 21)
        Me.tbpassemailfrom.TabIndex = 79
        '
        'lbFrommail
        '
        Me.lbFrommail.Location = New System.Drawing.Point(12, 8)
        Me.lbFrommail.Name = "lbFrommail"
        Me.lbFrommail.Size = New System.Drawing.Size(64, 23)
        Me.lbFrommail.TabIndex = 78
        Me.lbFrommail.Text = "Từ"
        '
        'tbEmailFrom
        '
        Me.tbEmailFrom.Location = New System.Drawing.Point(76, 8)
        Me.tbEmailFrom.Name = "tbEmailFrom"
        Me.tbEmailFrom.Size = New System.Drawing.Size(80, 21)
        Me.tbEmailFrom.TabIndex = 77
        '
        'PhieuLuongMoi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 406)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "Smartbooks_Salary"
        Me.HRFORM_VisibleControl_ExportExcel = False
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_ImportExcel = False
        Me.HRFORM_VisibleControl_Luu = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_Xoa = False
        Me.Name = "PhieuLuongMoi"
        Me.Text = "PhieuLuongMoi"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
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
        Me.ResumeLayout(False)

    End Sub

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
    Friend WithEvents cboYear As WindowsControlLibrary.Year
    Friend WithEvents cboMonth As WindowsControlLibrary.Month
    Friend WithEvents lblnam As Label
    Friend WithEvents lblthang As Label
    Friend WithEvents lbBCC As Label
    Friend WithEvents tbBCC As TextBox
    Friend WithEvents lbChuDe As Label
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents lbCC As Label
    Friend WithEvents tbCC As TextBox
    Friend WithEvents lbMatKhau As Label
    Friend WithEvents tbpassemailfrom As TextBox
    Friend WithEvents lbFrommail As Label
    Friend WithEvents tbEmailFrom As TextBox
    Friend WithEvents btnGuiPhieuLuong As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UiButton1 As DevExpress.XtraEditors.SimpleButton
End Class
