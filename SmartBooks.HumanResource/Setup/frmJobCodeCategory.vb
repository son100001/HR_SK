Public Class frmJobCodeCategory
    Private Sub frmJobCodeCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        tvcn.GetDataOnDropDownCategoryCodeName(Hazard, kn.ReadData("select HAZARD as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_HazardCategory", "table"))
        'TÌM MẢNG GIÁ TRỊ VÀ PRIMARY
        LoadGiaoDienTheoDieuKien()
        Search()

    End Sub
    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp 
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from " + HRFORM_TableName
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        JobCode.Select()
        Search()
    End Sub
End Class