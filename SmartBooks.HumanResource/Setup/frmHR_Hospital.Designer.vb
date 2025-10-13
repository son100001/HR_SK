<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHR_Hospital
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
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.Address = New System.Windows.Forms.RichTextBox()
        Me.NameVN = New System.Windows.Forms.TextBox()
        Me.lblNameVN = New System.Windows.Forms.Label()
        Me.NameKR = New System.Windows.Forms.TextBox()
        Me.lblNameKR = New System.Windows.Forms.Label()
        Me.NameEN = New System.Windows.Forms.TextBox()
        Me.lblNameEN = New System.Windows.Forms.Label()
        Me.MaBenhVien = New System.Windows.Forms.TextBox()
        Me.lblMaBenhVien = New System.Windows.Forms.Label()
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
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 301)
        Me.PanelButton.Size = New System.Drawing.Size(1216, 50)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1216, 301)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1214, 276)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 96)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1209, 178)
        Me.GridControl1.TabIndex = 1323
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1214, 94)
        Me.TableLayoutPanel3.TabIndex = 1322
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAddress)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.Address)
        Me.pnDuLieuNhap.Controls.Add(Me.NameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameVN)
        Me.pnDuLieuNhap.Controls.Add(Me.NameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameKR)
        Me.pnDuLieuNhap.Controls.Add(Me.NameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblNameEN)
        Me.pnDuLieuNhap.Controls.Add(Me.MaBenhVien)
        Me.pnDuLieuNhap.Controls.Add(Me.lblMaBenhVien)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1071, 86)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(727, 54)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(77, 19)
        Me.lblRemark.TabIndex = 322
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.Location = New System.Drawing.Point(729, 8)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(75, 19)
        Me.lblAddress.TabIndex = 321
        Me.lblAddress.Text = "Địa chỉ"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(810, 50)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(258, 31)
        Me.Remark.TabIndex = 13
        Me.Remark.Text = ""
        '
        'Address
        '
        Me.Address.Location = New System.Drawing.Point(810, 6)
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(258, 39)
        Me.Address.TabIndex = 11
        Me.Address.Text = ""
        '
        'NameVN
        '
        Me.NameVN.Location = New System.Drawing.Point(485, 3)
        Me.NameVN.Name = "NameVN"
        Me.NameVN.Size = New System.Drawing.Size(240, 21)
        Me.NameVN.TabIndex = 5
        '
        'lblNameVN
        '
        Me.lblNameVN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameVN.Location = New System.Drawing.Point(396, 3)
        Me.lblNameVN.Name = "lblNameVN"
        Me.lblNameVN.Size = New System.Drawing.Size(74, 19)
        Me.lblNameVN.TabIndex = 318
        Me.lblNameVN.Text = "Tên (VN)"
        Me.lblNameVN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameKR
        '
        Me.NameKR.Location = New System.Drawing.Point(485, 50)
        Me.NameKR.Name = "NameKR"
        Me.NameKR.Size = New System.Drawing.Size(240, 21)
        Me.NameKR.TabIndex = 9
        '
        'lblNameKR
        '
        Me.lblNameKR.BackColor = System.Drawing.Color.Transparent
        Me.lblNameKR.Location = New System.Drawing.Point(397, 50)
        Me.lblNameKR.Name = "lblNameKR"
        Me.lblNameKR.Size = New System.Drawing.Size(74, 19)
        Me.lblNameKR.TabIndex = 317
        Me.lblNameKR.Text = "Tên (KR)"
        Me.lblNameKR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameEN
        '
        Me.NameEN.Location = New System.Drawing.Point(485, 26)
        Me.NameEN.Name = "NameEN"
        Me.NameEN.Size = New System.Drawing.Size(240, 21)
        Me.NameEN.TabIndex = 7
        '
        'lblNameEN
        '
        Me.lblNameEN.BackColor = System.Drawing.Color.Transparent
        Me.lblNameEN.Location = New System.Drawing.Point(397, 26)
        Me.lblNameEN.Name = "lblNameEN"
        Me.lblNameEN.Size = New System.Drawing.Size(74, 19)
        Me.lblNameEN.TabIndex = 316
        Me.lblNameEN.Text = "Tên (EN)"
        Me.lblNameEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MaBenhVien
        '
        Me.MaBenhVien.Location = New System.Drawing.Point(150, 7)
        Me.MaBenhVien.Name = "MaBenhVien"
        Me.MaBenhVien.Size = New System.Drawing.Size(240, 21)
        Me.MaBenhVien.TabIndex = 3
        '
        'lblMaBenhVien
        '
        Me.lblMaBenhVien.BackColor = System.Drawing.Color.Transparent
        Me.lblMaBenhVien.Location = New System.Drawing.Point(4, 7)
        Me.lblMaBenhVien.Name = "lblMaBenhVien"
        Me.lblMaBenhVien.Size = New System.Drawing.Size(138, 19)
        Me.lblMaBenhVien.TabIndex = 303
        Me.lblMaBenhVien.Text = "Mã  bệnh viện"
        Me.lblMaBenhVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1083, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Lưu"
        '
        'frmHR_Hospital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 351)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_Hospital"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmHR_Hospital"
        Me.Text = "frmHR_Hospital"
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
    Friend WithEvents lblRemark As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents Address As RichTextBox
    Friend WithEvents NameVN As TextBox
    Friend WithEvents lblNameVN As Label
    Friend WithEvents NameKR As TextBox
    Friend WithEvents lblNameKR As Label
    Friend WithEvents NameEN As TextBox
    Friend WithEvents lblNameEN As Label
    Friend WithEvents MaBenhVien As TextBox
    Friend WithEvents lblMaBenhVien As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
