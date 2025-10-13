Public Class frmDanhSachDangKyDiLam
    Private Sub frmDanhSachDangKyDiLam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ngay.DateTime = Today
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd, td As DateTime
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(Ngay.DateTime.Year, Ngay.DateTime.Month, 2), New DateTime(Ngay.DateTime.Year, Ngay.DateTime.Month, 1).AddMonths(1).AddDays(-1))

        fd = New DateTime(Ngay.DateTime.Year, Ngay.DateTime.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If
        Dim QR As String = "exec [dbo].[sp_DanhSachDangKyDiLam] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_DanhSachDangKyDiLam]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class