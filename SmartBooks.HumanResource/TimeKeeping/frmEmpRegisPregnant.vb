Public Class frmEmpRegisPregnant
    Private Sub frmEmpRegisPregnant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        todate.EditValue = Today
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        'If Not IsNothing(GridView1.Columns("UltraDate")) Then
        '    GridView1.Columns("UltraDate").Visible = False
        'End If
        'If Not IsNothing(GridView1.Columns("PregWeeks")) Then
        '    GridView1.Columns("PregWeeks").Visible = False
        'End If
        'If Not IsNothing(GridView1.Columns("PregDays")) Then
        '    GridView1.Columns("PregDays").Visible = False
        'End If
    End Sub
    Public Overrides Sub aftersave()
        If ReportCode = "PregnantViewForInputFollowEmployee" Then
            Table.Clear()
            Table.AcceptChanges()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Fromdate.DateTime = todate.DateTime.AddDays(-280)
        'todate.DateTime = Fromdate.DateTime.AddMonths(9).AddDays(10)
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_EmployeeRegisPregnant]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangMangThai] '" + Today.ToString("yyyy-MM-dd") + "','" + Today.ToString("yyyy-MM-dd") + "',4,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub todate_EditValueChanged(sender As Object, e As EventArgs) Handles todate.EditValueChanged
        If todate.DateTime.Year <> 1 Then
            Fromdate.EditValue = DateAdd(DateInterval.Day, -10, DateAdd(DateInterval.Month, -9, todate.DateTime))
        End If
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