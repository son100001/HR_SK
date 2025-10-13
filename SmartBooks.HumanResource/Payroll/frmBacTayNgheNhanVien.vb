Imports WindowsControlLibrary

Public Class frmBacTayNgheNhanVien
    Private Sub frmBacTayNgheNhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        FromDate.EditValue = Today
        Dim tabNhom As DataTable = kn.ReadData("select distinct Nhom as Code, Nhom as Name from HR_BacTayNghe", "table")
        Dim tabBac As DataTable = kn.ReadData("select distinct Bac as Code, Bac as Name from HR_BacTayNghe", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(Nhom, tabNhom)
        tvcn.GetDataOnDropDownCategoryCodeName(SalaryStep, tabBac)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Private Sub Gridex1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            If btnSave.Enabled = True Then
                btnSave_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim QR As String = "[dbo].[sp_BangTayNgheNhanVien] null,null,1,'" + obj.Lan + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + Employee_ID.Text.Trim + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub cbToDate_CheckedChanged(sender As Object, e As EventArgs)
        ToDate.Enabled = cbToDate.Checked
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub
End Class