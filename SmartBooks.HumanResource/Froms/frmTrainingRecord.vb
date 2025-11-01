 

Public Class frmTrainingRecord
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel2, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel2, True, QuyenHRFORM)
        Employee_ID.Select()
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Search()
        'Dim QR As String = "[dbo].[sp_BangTrainingRecord] 1,'" + obj.Lan + "',N'" + obj.UserName + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + Employee_ID.Text.Trim + "'"
        Dim QR As String = "[dbo].[sp_BangTrainingRecord] '1900-1-1','" + Date.Today.AddYears(10).ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.UserName + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + Employee_ID.Text.Trim + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Public Overrides Sub AfterViewForm()
        Try
            If Not IsNothing(GridView1.Columns("TypeOfTransfer")) Then
                Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='TrainingType'", "table")
                tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "TrainingType", tab)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmTrainingRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        fromdate.EditValue = Today
        tvcn.GetDataOnDropDownCategoryCodeName(TrainingType, "TrainingType")
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub cbtodate_CheckedChanged(sender As Object, e As EventArgs) Handles cbtodate.CheckedChanged
        todate.Enabled = cbtodate.Checked
        If cbtodate.Checked = True Then
            todate.EditValue = Today
        Else
            todate.EditValue = Nothing
        End If
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class