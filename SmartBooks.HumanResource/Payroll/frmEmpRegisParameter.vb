 

Public Class frmEmpRegisParameter
    Dim tabParameterCode As DataTable
    Private Sub frmEmpRegisParameter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        tabParameterCode = kn.ReadData("select parameter as Code, Name" + obj.Lan + " as Name from HR_ParameterCategory", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(Parameter, tabParameterCode)
        'Try
        '    Parameter.SelectedIndex = 0
        'Catch ex As Exception

        'End Try
        fromdate.DateTime = Today
        todate.DateTime = Today
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "[dbo].[sp_BangThamSoLuong] '" + fromdate.DateTime.ToString("yyyy-MM-dd") + "','" + todate.DateTime.ToString("yyyy-MM-dd") + "','" + Parameter.EditValue + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Public Overrides Sub AfterViewForm()
        If Not IsNothing(HRFORM_Gridview.Columns("ParameterValue")) Then
            Dim tabDropDown As DataTable = kn.ReadData("select Category as Code,Name" + obj.Lan + " as Name from HR_Category where CategoryFather='" + Parameter.EditValue + "'", "table")
            tvcn.TaoDropDowTrenGrid(HRFORM_Gridview, "ParameterValue", tabDropDown)
        End If
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs)
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_EmpRegisParameter]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub Parameter_EditValueChanged(sender As Object, e As EventArgs) Handles Parameter.EditValueChanged
        tvcn.GetDataOnDropDownCategoryCodeName(ParameterValue, Parameter.EditValue)
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class