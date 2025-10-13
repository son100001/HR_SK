 

Public Class Holidays_Plan
    Dim tabLeaveType As DataTable
    Private Sub Holidays_Plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        tabLeaveType = kn.ReadData("select LeaveType_ID as Code,LeaveType_" + obj.Lan + " + (case when NumberOfDate is not null or NumberOfMonth is not null then ' - ' else '' end)+ (case when NumberOfDate is not null then N'Tối đa:' + cast(NumberOfDate as varchar(10)) +' ngày ' else '' end) +(case when NumberOfMonth is not null then  N'Tối đa:' + cast(NumberOfMonth as varchar(10)) +' tháng' else '' end) as Name from SmartBooks_LeaveType", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(TypeOfLeave, tabLeaveType)
        LoadGiaoDienTheoDieuKien()
        H_date.DateTime = Today
        Search()
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from SmartBooks_HolidaysPlan"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    Public Overrides Sub AfterViewForm()
        If Not IsNothing(HRFORM_Gridview.Columns("TypeOfLeave")) Then
            tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "TypeOfLeave", tabLeaveType)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel2, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)
        TypeOfLeave.Select()
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class