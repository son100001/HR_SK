Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports WindowsControlLibrary
Public Class frmUsers
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        'Dim passEdit = New RepositoryItemTextEdit()
        'passEdit.PasswordChar = "*'"
        'HRFORM_Gridview.Columns("Password"). = passEdit
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from [User]"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs)
        ChangePasswordFormat(sender, e)
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs)
        ChangePasswordShownEditor(sender, e)
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class