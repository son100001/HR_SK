Public Class frmDiscipline
    Private Sub frmDiscipline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        tvcn.GetDataOnDropDownCategoryCodeName(BehaviorCode, "ViPhamKyLuat")
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        Dim tab As DataTable
        If Not IsNothing(GridView1.Columns("BehaviorCode")) Then
            tab = kn.ReadData("select Category as Code, " + IIf(obj.Lan = "EN", "NameEN", IIf(obj.Lan = "KR", "NameKR", "NameVN")) + " as Name from HR_Category where CategoryFather='ViPhamKyLuat'", "table")
            tvcn.TaoDropDowTrenGrid(GridView1, "BehaviorCode", tab)
        End If
        'If Gridex1.RootTable.Columns.Contains("Reason") Then
        '    Gridex1.RootTable.Columns("Reason").Width = 300
        'End If
    End Sub

    Private Sub DisciplineBegin_ValueChanged(sender As Object, e As EventArgs) Handles DisciplineBegin.EditValueChanged
        AutoGenDisciplineEnd()
    End Sub

    Private Sub AutoGenDisciplineEnd()
        DisciplineEnd.EditValue = DisciplineBegin.EditValue
        ViolationDate.EditValue = DisciplineBegin.EditValue
        SalaryIncreaseDate.EditValue = DisciplineBegin.EditValue
    End Sub
    Private Function KiemTraNhapVaLuuMoi()
        If DisciplineEnd.EditValue < DisciplineBegin.EditValue Or SalaryIncreaseDate.EditValue < DisciplineEnd.EditValue Or ViolationDate.EditValue > DisciplineBegin.EditValue Then
            MessageBox.Show("Bạn vui lòng kiểm tra lại ngày biên bản kết thúc hoặc ngày tăng lương hoặc ngày vi phạm kỷ luật không hợp lệ!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "exec [dbo].[sp_BangViPhamKyLuat] '1900-1-1','" + Today.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged 
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click 
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_Discipline]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click 
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class