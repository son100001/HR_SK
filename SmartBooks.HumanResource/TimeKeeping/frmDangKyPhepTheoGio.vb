Public Class frmDangKyPhepTheoGio
    Private Sub frmDangKyPhepTheoGio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        DateLeave.EditValue = Today
        tvcn.GetDataOnDropDownCategoryCodeName(LeaveType_ID, kn.ReadData("select LeaveType_ID as Code, AbsentSign + ': ' + LeaveType_" + obj.Lan + " + (case when NumberOfDate is not null or NumberOfMonth is not null then ' - ' else '' end)+ (case when NumberOfDate is not null then N'Tối đa:' + cast(NumberOfDate as varchar(10)) +' ngày ' else '' end) +(case when NumberOfMonth is not null then  N'Tối đa:' + cast(NumberOfMonth as varchar(10)) +' tháng' else '' end) as Name from SmartBooks_LeaveType where AbsentSign is not null", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(TypeOfLeave, "LoaiDangKyPhepTheoGio")
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_DangKyPhepTheoGio]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If

        Dim fd, td As DateTime
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(DateLeave.DateTime.Year, DateLeave.DateTime.Month, 2), New DateTime(DateLeave.DateTime.Year, DateLeave.DateTime.Month, 1).AddMonths(1).AddDays(-1))
        fd = New DateTime(DateLeave.DateTime.Year, DateLeave.DateTime.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If
        Dim QR As String = "exec [dbo].[sp_BangDangKyPhepTheoGio] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class