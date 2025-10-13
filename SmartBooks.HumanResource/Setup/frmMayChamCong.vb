Public Class frmMayChamCong
    Private Sub frmMayChamCong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from HR_MayChamCong"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        Code.Select()
        Search()
    End Sub

    Private Sub btnGetFileName_Click(sender As Object, e As EventArgs) Handles btnGetFileName.Click
        OpenFileDialog1.Filter = "Microsoft Access 2000 Database (*.mdb)|*.mdb"
        OpenFileDialog1.Title = "Please select Finger-Scanner database"
        'OpenFileDialog1.FileName = "C:\"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Address.Text = OpenFileDialog1.FileName
        End If
    End Sub
End Class