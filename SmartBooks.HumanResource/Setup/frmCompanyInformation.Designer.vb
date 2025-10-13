<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompanyInformation
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.btnXoaAnh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAnh = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPicture = New System.Windows.Forms.Label()
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.fax = New System.Windows.Forms.TextBox()
        Me.lblfax = New System.Windows.Forms.Label()
        Me.phone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.Address_VN = New System.Windows.Forms.TextBox()
        Me.lblAddress_VN = New System.Windows.Forms.Label()
        Me.Address_EN = New System.Windows.Forms.TextBox()
        Me.lblAddress_EN = New System.Windows.Forms.Label()
        Me.company_name_VN = New System.Windows.Forms.TextBox()
        Me.lblcompany_name_VN = New System.Windows.Forms.Label()
        Me.company_name = New System.Windows.Forms.TextBox()
        Me.lblcompany_name = New System.Windows.Forms.Label()
        Me.CompanyID = New System.Windows.Forms.TextBox()
        Me.lblCompanyID = New System.Windows.Forms.Label()
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
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 322)
        Me.PanelButton.Size = New System.Drawing.Size(1134, 51)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1134, 322)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1132, 297)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(5, 149)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1127, 146)
        Me.GridControl1.TabIndex = 1317
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1132, 145)
        Me.TableLayoutPanel3.TabIndex = 1316
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.btnXoaAnh)
        Me.pnDuLieuNhap.Controls.Add(Me.btnChonAnh)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPicture)
        Me.pnDuLieuNhap.Controls.Add(Me.Picture)
        Me.pnDuLieuNhap.Controls.Add(Me.fax)
        Me.pnDuLieuNhap.Controls.Add(Me.lblfax)
        Me.pnDuLieuNhap.Controls.Add(Me.phone)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPhone)
        Me.pnDuLieuNhap.Controls.Add(Me.Address_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAddress_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.Address_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAddress_EN)
        Me.pnDuLieuNhap.Controls.Add(Me.company_name_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.lblcompany_name_VN)
        Me.pnDuLieuNhap.Controls.Add(Me.company_name)
        Me.pnDuLieuNhap.Controls.Add(Me.lblcompany_name)
        Me.pnDuLieuNhap.Controls.Add(Me.CompanyID)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCompanyID)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(1010, 137)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'btnXoaAnh
        '
        Me.btnXoaAnh.Location = New System.Drawing.Point(912, 56)
        Me.btnXoaAnh.Name = "btnXoaAnh"
        Me.btnXoaAnh.Size = New System.Drawing.Size(78, 23)
        Me.btnXoaAnh.TabIndex = 1298
        Me.btnXoaAnh.Text = "Xóa Ảnh"
        '
        'btnChonAnh
        '
        Me.btnChonAnh.Location = New System.Drawing.Point(912, 27)
        Me.btnChonAnh.Name = "btnChonAnh"
        Me.btnChonAnh.Size = New System.Drawing.Size(78, 23)
        Me.btnChonAnh.TabIndex = 1297
        Me.btnChonAnh.Text = "Chọn Ảnh"
        '
        'lblPicture
        '
        Me.lblPicture.BackColor = System.Drawing.Color.Transparent
        Me.lblPicture.Location = New System.Drawing.Point(728, 2)
        Me.lblPicture.Name = "lblPicture"
        Me.lblPicture.Size = New System.Drawing.Size(80, 19)
        Me.lblPicture.TabIndex = 1296
        Me.lblPicture.Text = "Ảnh"
        Me.lblPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Picture
        '
        Me.Picture.BackColor = System.Drawing.Color.Transparent
        Me.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture.Location = New System.Drawing.Point(729, 25)
        Me.Picture.Margin = New System.Windows.Forms.Padding(0)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(180, 96)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture.TabIndex = 1293
        Me.Picture.TabStop = False
        '
        'fax
        '
        Me.fax.Location = New System.Drawing.Point(560, 28)
        Me.fax.Name = "fax"
        Me.fax.Size = New System.Drawing.Size(157, 21)
        Me.fax.TabIndex = 13
        '
        'lblfax
        '
        Me.lblfax.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfax.Location = New System.Drawing.Point(482, 27)
        Me.lblfax.Name = "lblfax"
        Me.lblfax.Size = New System.Drawing.Size(70, 20)
        Me.lblfax.TabIndex = 1034
        Me.lblfax.Text = "Fax"
        Me.lblfax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'phone
        '
        Me.phone.Location = New System.Drawing.Point(560, 5)
        Me.phone.Name = "phone"
        Me.phone.Size = New System.Drawing.Size(157, 21)
        Me.phone.TabIndex = 11
        '
        'lblPhone
        '
        Me.lblPhone.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhone.Location = New System.Drawing.Point(481, 4)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(70, 20)
        Me.lblPhone.TabIndex = 1033
        Me.lblPhone.Text = "Phone"
        Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Address_VN
        '
        Me.Address_VN.Location = New System.Drawing.Point(169, 28)
        Me.Address_VN.Name = "Address_VN"
        Me.Address_VN.Size = New System.Drawing.Size(287, 21)
        Me.Address_VN.TabIndex = 3
        '
        'lblAddress_VN
        '
        Me.lblAddress_VN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress_VN.Location = New System.Drawing.Point(7, 26)
        Me.lblAddress_VN.Name = "lblAddress_VN"
        Me.lblAddress_VN.Size = New System.Drawing.Size(156, 20)
        Me.lblAddress_VN.TabIndex = 1030
        Me.lblAddress_VN.Text = "Địa chỉ (VN)"
        Me.lblAddress_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Address_EN
        '
        Me.Address_EN.Location = New System.Drawing.Point(169, 50)
        Me.Address_EN.Name = "Address_EN"
        Me.Address_EN.Size = New System.Drawing.Size(287, 21)
        Me.Address_EN.TabIndex = 5
        '
        'lblAddress_EN
        '
        Me.lblAddress_EN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress_EN.Location = New System.Drawing.Point(8, 49)
        Me.lblAddress_EN.Name = "lblAddress_EN"
        Me.lblAddress_EN.Size = New System.Drawing.Size(155, 20)
        Me.lblAddress_EN.TabIndex = 1028
        Me.lblAddress_EN.Text = "Địa chỉ (EN)"
        Me.lblAddress_EN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'company_name_VN
        '
        Me.company_name_VN.Location = New System.Drawing.Point(167, 99)
        Me.company_name_VN.Name = "company_name_VN"
        Me.company_name_VN.Size = New System.Drawing.Size(337, 21)
        Me.company_name_VN.TabIndex = 9
        '
        'lblcompany_name_VN
        '
        Me.lblcompany_name_VN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcompany_name_VN.Location = New System.Drawing.Point(6, 98)
        Me.lblcompany_name_VN.Name = "lblcompany_name_VN"
        Me.lblcompany_name_VN.Size = New System.Drawing.Size(155, 20)
        Me.lblcompany_name_VN.TabIndex = 1027
        Me.lblcompany_name_VN.Text = "Tên công ty (VN)"
        Me.lblcompany_name_VN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'company_name
        '
        Me.company_name.Location = New System.Drawing.Point(167, 75)
        Me.company_name.Name = "company_name"
        Me.company_name.Size = New System.Drawing.Size(337, 21)
        Me.company_name.TabIndex = 7
        '
        'lblcompany_name
        '
        Me.lblcompany_name.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcompany_name.Location = New System.Drawing.Point(6, 75)
        Me.lblcompany_name.Name = "lblcompany_name"
        Me.lblcompany_name.Size = New System.Drawing.Size(155, 20)
        Me.lblcompany_name.TabIndex = 1026
        Me.lblcompany_name.Text = "Tên công ty (EN)"
        Me.lblcompany_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CompanyID
        '
        Me.CompanyID.Location = New System.Drawing.Point(169, 4)
        Me.CompanyID.Name = "CompanyID"
        Me.CompanyID.Size = New System.Drawing.Size(287, 21)
        Me.CompanyID.TabIndex = 1
        '
        'lblCompanyID
        '
        Me.lblCompanyID.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyID.Location = New System.Drawing.Point(7, 2)
        Me.lblCompanyID.Name = "lblCompanyID"
        Me.lblCompanyID.Size = New System.Drawing.Size(156, 20)
        Me.lblCompanyID.TabIndex = 1019
        Me.lblCompanyID.Text = "Mã công ty"
        Me.lblCompanyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(1022, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(97, 137)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 77)
        Me.btnSave.TabIndex = 1299
        Me.btnSave.Text = "Lưu"
        '
        'frmCompanyInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 373)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_InputForm = "frmCompanyInformation_Nhap"
        Me.HRFORM_TableName = "SmartBooks_Company"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmCompanyInformation"
        Me.Text = "frmCompanyInformation"
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
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents btnXoaAnh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAnh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPicture As Label
    Friend WithEvents Picture As PictureBox
    Friend WithEvents fax As TextBox
    Friend WithEvents lblfax As Label
    Friend WithEvents phone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents Address_VN As TextBox
    Friend WithEvents lblAddress_VN As Label
    Friend WithEvents Address_EN As TextBox
    Friend WithEvents lblAddress_EN As Label
    Friend WithEvents company_name_VN As TextBox
    Friend WithEvents lblcompany_name_VN As Label
    Friend WithEvents company_name As TextBox
    Friend WithEvents lblcompany_name As Label
    Friend WithEvents CompanyID As TextBox
    Friend WithEvents lblCompanyID As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
