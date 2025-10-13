Public Class frmMucLuong
    Private Sub frmMucLuong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        FromDate.EditValue = Today
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub cbToDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbToDate.CheckedChanged
        If cbToDate.Checked = True Then
            ToDate.EditValue = Today
            ToDate.Enabled = True
        Else
            ToDate.Enabled = False
            ToDate.EditValue = Nothing
        End If
    End Sub
    Private Sub Gridex1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_MucLuong]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        SalaryGroup.Select()
    End Sub
    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles Amount.TextChanged
        tvcn.AmountFormat(Amount)
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from HR_MucLuong"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
End Class