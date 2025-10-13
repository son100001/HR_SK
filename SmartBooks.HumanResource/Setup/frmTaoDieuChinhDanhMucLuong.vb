Imports System.Text.RegularExpressions
Imports WindowsControlLibrary
Public Class frmTaoDieuChinhDanhMucLuong
    Private Sub frmTaoDieuChinhDanhMucLuong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from HR_SalaryComponentCategory"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    Private Sub SalaryComponent_Leave(sender As Object, e As EventArgs) Handles SalaryComponent.Leave
        Dim pattern As String = "\s+"
        Dim replacement As String = ""
        Dim rgx As New Regex(pattern)
        SalaryComponent.Text = rgx.Replace(SalaryComponent.Text.Trim, replacement)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        SalaryComponent.Select()
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class