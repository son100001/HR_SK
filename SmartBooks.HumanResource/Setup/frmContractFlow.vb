Public Class frmContractFlow
    Dim tabContract As DataTable
    Private Sub Search()
        Dim QR As String = "select * from " + HRFORM_TableName
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub frmContractFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        tabContract = kn.ReadData("select Contract_ID as Code, Contract_Name" + obj.Lan + " as Name from SmartBooks_Contract", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(Contract_ID, tabContract)
        tvcn.GetDataOnDropDownCategoryCodeName(ContractFlow, tabContract)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        Contract_ID.Select()
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class