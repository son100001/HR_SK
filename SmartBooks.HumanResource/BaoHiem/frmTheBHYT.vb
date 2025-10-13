Public Class frmTheBHYT
    Private Sub frmTheBHYT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.GetDataOnDropDown(MaBenhVien, kn.ReadData("select * from HR_Hospital", "table"), "NameVN", "MaBenhVien")
        fromdate.EditValue = Today
        todate.EditValue = Today
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_ThongTinBaoHiem] 2,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    Private Sub Employee_ID_TextChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel2, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)
        Employee_ID.Select()
        Search()
    End Sub
End Class