Imports WindowsControlLibrary
Public Class frmUsers_Nhap
    'Private kn1 As New WindowsControlLibrary.connect(DbSetting.dataPath)
    'Private tvcn1 As New WindowsControlLibrary.ThuVienChucNang
    Private Sub frmUsers_Nhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(Me, HRFORM_TableName)
        UserName.Select()
    End Sub

    Public Overrides Sub BeforeLoad()
        'tvcn.LoadPosition(FatherUser, "User", "UserName")
        'QuyenTruyXuat.DataSource = kn.ReadData("select * from udf_Position('" + obj.Lan + "')", "table")
        NewPassword.Enabled = False
        lblUserName123.Text = lblUserName123.Text + " *"
        lblUserName123.ForeColor = Color.Red
    End Sub

    Public Overrides Function BeforeSave() As Integer
        Dim tab As DataTable = kn.ReadData("select * from [User] where UserName=N'" + UserName.Text.Trim + "'", "table")
        If cbDoiMatKhau.Checked = True Then
            If tab.Rows.Count = 1 Then
                Dim OldPassword As String
                If Not IsDBNull(tab.Rows(0)("Password")) Then
                    OldPassword = tab.Rows(0)("Password")
                End If
                If Password.Text.Trim <> OldPassword Then
                    MessageBox.Show("Mật khẩu cũ không đúng! Bạn vui lòng nhập lại mật khẩu cũ.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return 0
                End If
                Password.Text = tvcn.Encode(NewPassword.Text.Trim)
            Else
                MessageBox.Show("Tài khoản không tồn tại, bạn vui lòng kiểm tra lại.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End If
        Else
            If tab.Rows.Count < 1 Then
                Password.Text = tvcn.Encode(Password.Text.Trim)
            Else
                If Not IsDBNull(tab.Rows(0)("Password")) Then
                    Password.Text = tab.Rows(0)("Password")
                Else
                    Password.Text = String.Empty
                End If
            End If
        End If
        InsertBy.Text = DbSetting.UserName
        InsertDate.EditValue = Now
        Return 1
    End Function

    Private Sub cbDoiMatKhau_CheckedChanged(sender As Object, e As EventArgs) Handles cbDoiMatKhau.CheckedChanged
        If cbDoiMatKhau.Checked = True Then
            NewPassword.Enabled = True
        Else
            NewPassword.Enabled = False
        End If
    End Sub
End Class