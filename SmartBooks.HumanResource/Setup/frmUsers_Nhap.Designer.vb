<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers_Nhap
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ID = New System.Windows.Forms.TextBox()
        Me.InsertBy = New System.Windows.Forms.TextBox()
        Me.lblInsertBy = New System.Windows.Forms.Label()
        Me.lblInsertDate = New System.Windows.Forms.Label()
        Me.lblFatherUser = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.FullName = New System.Windows.Forms.TextBox()
        Me.GroupID = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblGroupID = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.cbDoiMatKhau = New System.Windows.Forms.CheckBox()
        Me.NewPassword = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.lblUserName123 = New System.Windows.Forms.Label()
        Me.lblQuyenTruyXuat = New System.Windows.Forms.Label()
        Me.QuyenTruyXuat = New System.Windows.Forms.TextBox()
        Me.InsertDate = New DevExpress.XtraEditors.DateEdit()
        Me.FatherUser = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.InsertDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FatherUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 306)
        Me.PanelButton.Size = New System.Drawing.Size(564, 48)
        '
        'ID
        '
        Me.ID.Enabled = False
        Me.ID.Location = New System.Drawing.Point(184, 9)
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Size = New System.Drawing.Size(297, 20)
        Me.ID.TabIndex = 311
        '
        'InsertBy
        '
        Me.InsertBy.Enabled = False
        Me.InsertBy.Location = New System.Drawing.Point(184, 242)
        Me.InsertBy.Name = "InsertBy"
        Me.InsertBy.ReadOnly = True
        Me.InsertBy.Size = New System.Drawing.Size(296, 20)
        Me.InsertBy.TabIndex = 308
        '
        'lblInsertBy
        '
        Me.lblInsertBy.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertBy.Location = New System.Drawing.Point(40, 242)
        Me.lblInsertBy.Name = "lblInsertBy"
        Me.lblInsertBy.Size = New System.Drawing.Size(120, 19)
        Me.lblInsertBy.TabIndex = 310
        Me.lblInsertBy.Text = "UserName"
        Me.lblInsertBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInsertDate
        '
        Me.lblInsertDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertDate.Location = New System.Drawing.Point(40, 266)
        Me.lblInsertDate.Name = "lblInsertDate"
        Me.lblInsertDate.Size = New System.Drawing.Size(120, 19)
        Me.lblInsertDate.TabIndex = 309
        Me.lblInsertDate.Text = "InsertDate"
        Me.lblInsertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFatherUser
        '
        Me.lblFatherUser.BackColor = System.Drawing.Color.Transparent
        Me.lblFatherUser.Location = New System.Drawing.Point(40, 61)
        Me.lblFatherUser.Name = "lblFatherUser"
        Me.lblFatherUser.Size = New System.Drawing.Size(96, 19)
        Me.lblFatherUser.TabIndex = 306
        Me.lblFatherUser.Text = "Người quản lý"
        Me.lblFatherUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFullName
        '
        Me.lblFullName.BackColor = System.Drawing.Color.Transparent
        Me.lblFullName.Location = New System.Drawing.Point(39, 87)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(109, 19)
        Me.lblFullName.TabIndex = 300
        Me.lblFullName.Text = "Họ tên"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FullName
        '
        Me.FullName.Location = New System.Drawing.Point(184, 87)
        Me.FullName.Name = "FullName"
        Me.FullName.Size = New System.Drawing.Size(296, 20)
        Me.FullName.TabIndex = 5
        '
        'GroupID
        '
        Me.GroupID.Location = New System.Drawing.Point(184, 137)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(296, 20)
        Me.GroupID.TabIndex = 9
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(184, 113)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password.Size = New System.Drawing.Size(296, 20)
        Me.Password.TabIndex = 7
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Location = New System.Drawing.Point(38, 9)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(72, 19)
        Me.lblID.TabIndex = 299
        Me.lblID.Text = "ID"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroupID
        '
        Me.lblGroupID.BackColor = System.Drawing.Color.Transparent
        Me.lblGroupID.Location = New System.Drawing.Point(40, 138)
        Me.lblGroupID.Name = "lblGroupID"
        Me.lblGroupID.Size = New System.Drawing.Size(138, 19)
        Me.lblGroupID.TabIndex = 298
        Me.lblGroupID.Text = "Nhóm"
        Me.lblGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Location = New System.Drawing.Point(40, 113)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(138, 19)
        Me.lblPassword.TabIndex = 297
        Me.lblPassword.Text = "Mật khẩu"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbDoiMatKhau
        '
        Me.cbDoiMatKhau.AutoSize = True
        Me.cbDoiMatKhau.Location = New System.Drawing.Point(184, 194)
        Me.cbDoiMatKhau.Name = "cbDoiMatKhau"
        Me.cbDoiMatKhau.Size = New System.Drawing.Size(89, 17)
        Me.cbDoiMatKhau.TabIndex = 11
        Me.cbDoiMatKhau.Text = "Đổi mật khẩu"
        Me.cbDoiMatKhau.UseVisualStyleBackColor = True
        '
        'NewPassword
        '
        Me.NewPassword.Location = New System.Drawing.Point(184, 217)
        Me.NewPassword.Name = "NewPassword"
        Me.NewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.NewPassword.Size = New System.Drawing.Size(296, 20)
        Me.NewPassword.TabIndex = 13
        '
        'lblNewPassword
        '
        Me.lblNewPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblNewPassword.Location = New System.Drawing.Point(40, 217)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(138, 19)
        Me.lblNewPassword.TabIndex = 314
        Me.lblNewPassword.Text = "Mật khẩu mới"
        Me.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserName
        '
        Me.UserName.Location = New System.Drawing.Point(184, 35)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(296, 20)
        Me.UserName.TabIndex = 1
        '
        'lblUserName123
        '
        Me.lblUserName123.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName123.ForeColor = System.Drawing.Color.Black
        Me.lblUserName123.Location = New System.Drawing.Point(38, 35)
        Me.lblUserName123.Name = "lblUserName123"
        Me.lblUserName123.Size = New System.Drawing.Size(138, 19)
        Me.lblUserName123.TabIndex = 316
        Me.lblUserName123.Text = "Tên đăng nhập"
        Me.lblUserName123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuyenTruyXuat
        '
        Me.lblQuyenTruyXuat.BackColor = System.Drawing.Color.Transparent
        Me.lblQuyenTruyXuat.Location = New System.Drawing.Point(40, 163)
        Me.lblQuyenTruyXuat.Name = "lblQuyenTruyXuat"
        Me.lblQuyenTruyXuat.Size = New System.Drawing.Size(96, 15)
        Me.lblQuyenTruyXuat.TabIndex = 1252
        Me.lblQuyenTruyXuat.Text = "Quyền truy xuất"
        Me.lblQuyenTruyXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'QuyenTruyXuat
        '
        Me.QuyenTruyXuat.Location = New System.Drawing.Point(185, 161)
        Me.QuyenTruyXuat.Name = "QuyenTruyXuat"
        Me.QuyenTruyXuat.Size = New System.Drawing.Size(295, 20)
        Me.QuyenTruyXuat.TabIndex = 10
        '
        'InsertDate
        '
        Me.InsertDate.EditValue = Nothing
        Me.InsertDate.Location = New System.Drawing.Point(184, 266)
        Me.InsertDate.Name = "InsertDate"
        Me.InsertDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.DisplayFormat.FormatString = ""
        Me.InsertDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.InsertDate.Properties.EditFormat.FormatString = ""
        Me.InsertDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.InsertDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.InsertDate.Properties.MaskSettings.Set("mask", "d")
        Me.InsertDate.Properties.UseMaskAsDisplayFormat = True
        Me.InsertDate.Size = New System.Drawing.Size(297, 20)
        Me.InsertDate.TabIndex = 1254
        '
        'FatherUser
        '
        Me.FatherUser.Location = New System.Drawing.Point(184, 61)
        Me.FatherUser.Name = "FatherUser"
        Me.FatherUser.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.FatherUser.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FatherUser.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.FatherUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.FatherUser.Size = New System.Drawing.Size(297, 20)
        Me.FatherUser.TabIndex = 1253
        '
        'frmUsers_Nhap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 354)
        Me.Controls.Add(Me.InsertDate)
        Me.Controls.Add(Me.FatherUser)
        Me.Controls.Add(Me.QuyenTruyXuat)
        Me.Controls.Add(Me.lblQuyenTruyXuat)
        Me.Controls.Add(Me.UserName)
        Me.Controls.Add(Me.lblUserName123)
        Me.Controls.Add(Me.NewPassword)
        Me.Controls.Add(Me.lblNewPassword)
        Me.Controls.Add(Me.cbDoiMatKhau)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.InsertBy)
        Me.Controls.Add(Me.lblInsertBy)
        Me.Controls.Add(Me.lblInsertDate)
        Me.Controls.Add(Me.lblFatherUser)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.FullName)
        Me.Controls.Add(Me.GroupID)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblGroupID)
        Me.Controls.Add(Me.lblPassword)
        Me.HRFORM_TableName = "User"
        Me.HRFORM_TypeOfForm = WindowsControlLibrary.HRFORM.TypeOfForm.Input
        Me.HRFORM_VisibleControl_cbbReport = False
        Me.HRFORM_VisibleControl_ExportExcel = False
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_ImportExcel = False
        Me.HRFORM_VisibleControl_QuickPrint = False
        Me.HRFORM_VisibleControl_RefreshLayout = False
        Me.HRFORM_VisibleControl_SaveLayout = False
        Me.HRFORM_VisibleControl_StatusBarFooter = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_VisibleControl_ThucHien = False
        Me.HRFORM_VisibleControl_Xem = False
        Me.HRFORM_VisibleControl_Xoa = False
        Me.Name = "frmUsers_Nhap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUsers_Nhap"
        Me.Controls.SetChildIndex(Me.lblPassword, 0)
        Me.Controls.SetChildIndex(Me.lblGroupID, 0)
        Me.Controls.SetChildIndex(Me.lblID, 0)
        Me.Controls.SetChildIndex(Me.Password, 0)
        Me.Controls.SetChildIndex(Me.GroupID, 0)
        Me.Controls.SetChildIndex(Me.FullName, 0)
        Me.Controls.SetChildIndex(Me.lblFullName, 0)
        Me.Controls.SetChildIndex(Me.lblFatherUser, 0)
        Me.Controls.SetChildIndex(Me.lblInsertDate, 0)
        Me.Controls.SetChildIndex(Me.lblInsertBy, 0)
        Me.Controls.SetChildIndex(Me.InsertBy, 0)
        Me.Controls.SetChildIndex(Me.ID, 0)
        Me.Controls.SetChildIndex(Me.cbDoiMatKhau, 0)
        Me.Controls.SetChildIndex(Me.lblNewPassword, 0)
        Me.Controls.SetChildIndex(Me.NewPassword, 0)
        Me.Controls.SetChildIndex(Me.lblUserName123, 0)
        Me.Controls.SetChildIndex(Me.UserName, 0)
        Me.Controls.SetChildIndex(Me.lblQuyenTruyXuat, 0)
        Me.Controls.SetChildIndex(Me.QuyenTruyXuat, 0)
        Me.Controls.SetChildIndex(Me.FatherUser, 0)
        Me.Controls.SetChildIndex(Me.InsertDate, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        CType(Me.InsertDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FatherUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ID As TextBox
    Friend WithEvents InsertBy As TextBox
    Friend WithEvents lblInsertBy As Label
    Friend WithEvents lblInsertDate As Label
    Friend WithEvents lblFatherUser As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents FullName As TextBox
    Friend WithEvents GroupID As TextBox
    Friend WithEvents Password As TextBox
    Friend WithEvents lblID As Label
    Friend WithEvents lblGroupID As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents cbDoiMatKhau As CheckBox
    Friend WithEvents NewPassword As TextBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents UserName As TextBox
    Friend WithEvents lblUserName123 As Label
    Friend WithEvents lblQuyenTruyXuat As Label
    Friend WithEvents QuyenTruyXuat As TextBox
    Friend WithEvents InsertDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents FatherUser As DevExpress.XtraEditors.LookUpEdit
End Class
