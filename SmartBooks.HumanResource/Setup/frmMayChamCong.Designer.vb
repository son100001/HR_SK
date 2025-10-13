<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMayChamCong
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnDuLieuNhap = New System.Windows.Forms.Panel()
        Me.btnGetFileName = New DevExpress.XtraEditors.SimpleButton()
        Me.ListOfUser = New System.Windows.Forms.RichTextBox()
        Me.lblCardCodeType = New System.Windows.Forms.Label()
        Me.CardCodeType = New System.Windows.Forms.ComboBox()
        Me.CardCodeName = New System.Windows.Forms.TextBox()
        Me.lblCardCodeName = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.FormatDate = New System.Windows.Forms.TextBox()
        Me.lblFormatDate = New System.Windows.Forms.Label()
        Me.EmployeeIDIsCardNumber = New System.Windows.Forms.CheckBox()
        Me.lblListOfUser = New System.Windows.Forms.Label()
        Me.PassWord_ = New System.Windows.Forms.TextBox()
        Me.lblPassWord = New System.Windows.Forms.Label()
        Me.isSQL = New System.Windows.Forms.RadioButton()
        Me.isACCESS = New System.Windows.Forms.RadioButton()
        Me.lblQuery = New System.Windows.Forms.Label()
        Me.Query = New System.Windows.Forms.RichTextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.Address = New System.Windows.Forms.RichTextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.Code = New System.Windows.Forms.TextBox()
        Me.Name_ = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
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
        Me.PanelButton.Location = New System.Drawing.Point(0, 359)
        Me.PanelButton.Size = New System.Drawing.Size(1076, 50)
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(1076, 359)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General})
        '
        'General
        '
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Controls.Add(Me.TableLayoutPanel3)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1074, 334)
        Me.General.Text = "General"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 182)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1071, 150)
        Me.GridControl1.TabIndex = 1325
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1074, 180)
        Me.TableLayoutPanel3.TabIndex = 1324
        '
        'pnDuLieuNhap
        '
        Me.pnDuLieuNhap.Controls.Add(Me.btnGetFileName)
        Me.pnDuLieuNhap.Controls.Add(Me.ListOfUser)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCardCodeType)
        Me.pnDuLieuNhap.Controls.Add(Me.CardCodeType)
        Me.pnDuLieuNhap.Controls.Add(Me.CardCodeName)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCardCodeName)
        Me.pnDuLieuNhap.Controls.Add(Me.lblRemark)
        Me.pnDuLieuNhap.Controls.Add(Me.Remark)
        Me.pnDuLieuNhap.Controls.Add(Me.FormatDate)
        Me.pnDuLieuNhap.Controls.Add(Me.lblFormatDate)
        Me.pnDuLieuNhap.Controls.Add(Me.EmployeeIDIsCardNumber)
        Me.pnDuLieuNhap.Controls.Add(Me.lblListOfUser)
        Me.pnDuLieuNhap.Controls.Add(Me.PassWord_)
        Me.pnDuLieuNhap.Controls.Add(Me.lblPassWord)
        Me.pnDuLieuNhap.Controls.Add(Me.isSQL)
        Me.pnDuLieuNhap.Controls.Add(Me.isACCESS)
        Me.pnDuLieuNhap.Controls.Add(Me.lblQuery)
        Me.pnDuLieuNhap.Controls.Add(Me.Query)
        Me.pnDuLieuNhap.Controls.Add(Me.lblAddress)
        Me.pnDuLieuNhap.Controls.Add(Me.Address)
        Me.pnDuLieuNhap.Controls.Add(Me.lblCode)
        Me.pnDuLieuNhap.Controls.Add(Me.Code)
        Me.pnDuLieuNhap.Controls.Add(Me.Name_)
        Me.pnDuLieuNhap.Controls.Add(Me.lblName)
        Me.pnDuLieuNhap.Location = New System.Drawing.Point(5, 4)
        Me.pnDuLieuNhap.Name = "pnDuLieuNhap"
        Me.pnDuLieuNhap.Size = New System.Drawing.Size(986, 172)
        Me.pnDuLieuNhap.TabIndex = 1321
        '
        'btnGetFileName
        '
        Me.btnGetFileName.Location = New System.Drawing.Point(441, 53)
        Me.btnGetFileName.Name = "btnGetFileName"
        Me.btnGetFileName.Size = New System.Drawing.Size(53, 52)
        Me.btnGetFileName.TabIndex = 213
        Me.btnGetFileName.Text = "..."
        '
        'ListOfUser
        '
        Me.ListOfUser.Location = New System.Drawing.Point(708, 30)
        Me.ListOfUser.Name = "ListOfUser"
        Me.ListOfUser.Size = New System.Drawing.Size(264, 21)
        Me.ListOfUser.TabIndex = 17
        Me.ListOfUser.Text = ""
        '
        'lblCardCodeType
        '
        Me.lblCardCodeType.BackColor = System.Drawing.Color.Transparent
        Me.lblCardCodeType.Location = New System.Drawing.Point(556, 123)
        Me.lblCardCodeType.Name = "lblCardCodeType"
        Me.lblCardCodeType.Size = New System.Drawing.Size(138, 19)
        Me.lblCardCodeType.TabIndex = 212
        Me.lblCardCodeType.Text = "Kiểu mã"
        Me.lblCardCodeType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CardCodeType
        '
        Me.CardCodeType.Location = New System.Drawing.Point(708, 123)
        Me.CardCodeType.Name = "CardCodeType"
        Me.CardCodeType.Size = New System.Drawing.Size(264, 21)
        Me.CardCodeType.TabIndex = 25
        '
        'CardCodeName
        '
        Me.CardCodeName.Location = New System.Drawing.Point(708, 99)
        Me.CardCodeName.Name = "CardCodeName"
        Me.CardCodeName.Size = New System.Drawing.Size(264, 21)
        Me.CardCodeName.TabIndex = 23
        '
        'lblCardCodeName
        '
        Me.lblCardCodeName.BackColor = System.Drawing.Color.Transparent
        Me.lblCardCodeName.Location = New System.Drawing.Point(556, 99)
        Me.lblCardCodeName.Name = "lblCardCodeName"
        Me.lblCardCodeName.Size = New System.Drawing.Size(138, 19)
        Me.lblCardCodeName.TabIndex = 211
        Me.lblCardCodeName.Text = "Tên mã"
        Me.lblCardCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(556, 147)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(138, 19)
        Me.lblRemark.TabIndex = 210
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(708, 147)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(264, 23)
        Me.Remark.TabIndex = 27
        Me.Remark.Text = ""
        '
        'FormatDate
        '
        Me.FormatDate.Location = New System.Drawing.Point(708, 75)
        Me.FormatDate.Name = "FormatDate"
        Me.FormatDate.Size = New System.Drawing.Size(264, 21)
        Me.FormatDate.TabIndex = 21
        '
        'lblFormatDate
        '
        Me.lblFormatDate.BackColor = System.Drawing.Color.Transparent
        Me.lblFormatDate.Location = New System.Drawing.Point(556, 75)
        Me.lblFormatDate.Name = "lblFormatDate"
        Me.lblFormatDate.Size = New System.Drawing.Size(138, 19)
        Me.lblFormatDate.TabIndex = 209
        Me.lblFormatDate.Text = "Định dạng ngày"
        Me.lblFormatDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EmployeeIDIsCardNumber
        '
        Me.EmployeeIDIsCardNumber.Location = New System.Drawing.Point(711, 51)
        Me.EmployeeIDIsCardNumber.Name = "EmployeeIDIsCardNumber"
        Me.EmployeeIDIsCardNumber.Size = New System.Drawing.Size(195, 24)
        Me.EmployeeIDIsCardNumber.TabIndex = 19
        Me.EmployeeIDIsCardNumber.Text = "Mã nhân viên là mã thẻ"
        '
        'lblListOfUser
        '
        Me.lblListOfUser.BackColor = System.Drawing.Color.Transparent
        Me.lblListOfUser.Location = New System.Drawing.Point(556, 30)
        Me.lblListOfUser.Name = "lblListOfUser"
        Me.lblListOfUser.Size = New System.Drawing.Size(138, 19)
        Me.lblListOfUser.TabIndex = 202
        Me.lblListOfUser.Text = "Danh sách user"
        Me.lblListOfUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PassWord_
        '
        Me.PassWord_.Location = New System.Drawing.Point(708, 6)
        Me.PassWord_.Name = "PassWord_"
        Me.PassWord_.Size = New System.Drawing.Size(264, 21)
        Me.PassWord_.TabIndex = 15
        '
        'lblPassWord
        '
        Me.lblPassWord.BackColor = System.Drawing.Color.Transparent
        Me.lblPassWord.Location = New System.Drawing.Point(556, 6)
        Me.lblPassWord.Name = "lblPassWord"
        Me.lblPassWord.Size = New System.Drawing.Size(138, 19)
        Me.lblPassWord.TabIndex = 201
        Me.lblPassWord.Text = "Mật khẩu"
        Me.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'isSQL
        '
        Me.isSQL.Location = New System.Drawing.Point(441, 30)
        Me.isSQL.Name = "isSQL"
        Me.isSQL.Size = New System.Drawing.Size(87, 24)
        Me.isSQL.TabIndex = 7
        Me.isSQL.Text = "SQL"
        '
        'isACCESS
        '
        Me.isACCESS.Location = New System.Drawing.Point(441, 6)
        Me.isACCESS.Name = "isACCESS"
        Me.isACCESS.Size = New System.Drawing.Size(87, 24)
        Me.isACCESS.TabIndex = 5
        Me.isACCESS.Text = "ACCESS"
        '
        'lblQuery
        '
        Me.lblQuery.BackColor = System.Drawing.Color.Transparent
        Me.lblQuery.Location = New System.Drawing.Point(6, 125)
        Me.lblQuery.Name = "lblQuery"
        Me.lblQuery.Size = New System.Drawing.Size(61, 19)
        Me.lblQuery.TabIndex = 196
        Me.lblQuery.Text = "Query"
        Me.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Query
        '
        Me.Query.Location = New System.Drawing.Point(87, 111)
        Me.Query.Name = "Query"
        Me.Query.Size = New System.Drawing.Size(441, 58)
        Me.Query.TabIndex = 13
        Me.Query.Text = ""
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.Location = New System.Drawing.Point(6, 67)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(66, 19)
        Me.lblAddress.TabIndex = 194
        Me.lblAddress.Text = "Địa chỉ"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Address
        '
        Me.Address.Location = New System.Drawing.Point(87, 53)
        Me.Address.Name = "Address"
        Me.Address.Size = New System.Drawing.Size(348, 52)
        Me.Address.TabIndex = 9
        Me.Address.Text = ""
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Location = New System.Drawing.Point(6, 2)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(75, 19)
        Me.lblCode.TabIndex = 181
        Me.lblCode.Text = "Mã máy"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Code
        '
        Me.Code.Location = New System.Drawing.Point(87, 3)
        Me.Code.Name = "Code"
        Me.Code.Size = New System.Drawing.Size(348, 21)
        Me.Code.TabIndex = 1
        '
        'Name_
        '
        Me.Name_.Location = New System.Drawing.Point(87, 27)
        Me.Name_.Name = "Name_"
        Me.Name_.Size = New System.Drawing.Size(348, 21)
        Me.Name_.TabIndex = 3
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Location = New System.Drawing.Point(6, 25)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(75, 19)
        Me.lblName.TabIndex = 180
        Me.lblName.Text = "Tên"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnLuu
        '
        Me.pnLuu.Controls.Add(Me.btnSave)
        Me.pnLuu.Location = New System.Drawing.Point(998, 4)
        Me.pnLuu.Name = "pnLuu"
        Me.pnLuu.Size = New System.Drawing.Size(59, 86)
        Me.pnLuu.TabIndex = 1326
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 73)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "Lưu"
        '
        'frmMayChamCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 409)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_TableName = "HR_MayChamCong"
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmMayChamCong"
        Me.Text = "frmMayChamCong"
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
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents pnDuLieuNhap As Panel
    Friend WithEvents btnGetFileName As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ListOfUser As RichTextBox
    Friend WithEvents lblCardCodeType As Label
    Friend WithEvents CardCodeType As ComboBox
    Friend WithEvents CardCodeName As TextBox
    Friend WithEvents lblCardCodeName As Label
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents FormatDate As TextBox
    Friend WithEvents lblFormatDate As Label
    Friend WithEvents EmployeeIDIsCardNumber As CheckBox
    Friend WithEvents lblListOfUser As Label
    Friend WithEvents PassWord_ As TextBox
    Friend WithEvents lblPassWord As Label
    Friend WithEvents isSQL As RadioButton
    Friend WithEvents isACCESS As RadioButton
    Friend WithEvents lblQuery As Label
    Friend WithEvents Query As RichTextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents Address As RichTextBox
    Friend WithEvents lblCode As Label
    Friend WithEvents Code As TextBox
    Friend WithEvents Name_ As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents pnLuu As Panel
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
End Class
