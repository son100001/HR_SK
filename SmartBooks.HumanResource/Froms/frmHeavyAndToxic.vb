Imports WindowsControlLibrary

Public Class frmHeavyAndToxic
    Dim tabHazard As DataTable
    Private Sub frmChuyenChucVu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        Dim tab As DataTable = kn.ReadData("select Position_ID as Code, Position_Name" + obj.Lan + " as Name from SmartBooks_Position", "table")
        tabHazard = kn.ReadData("select HAZARD as Code, Name" + obj.Lan + " as Name from HR_HazardCategory", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(HAZARD, tabHazard)
        Fromdate.EditValue = Today
        tvcn.SearchEmployee(Employee_ID)
        LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub Employee_ID_Leave(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Search()
        Dim tabSub As DataTable = kn.ReadData("select * from udf_EmployeeFilter_Full ('VN',null,null,null,null,null,null,'" + Employee_ID.EditValue.ToString.Trim + "','" + DirectCast(Fromdate.EditValue, DateTime).ToString("yyyy-MM-dd") + "')", "table")
        If tabSub IsNot Nothing AndAlso tabSub.Rows.Count > 0 Then
            Factory_ID.Text = tabSub.Rows(0)("FactoryName").ToString()
            departmentcode.Text = tabSub.Rows(0)("DepartmentName").ToString()
            sectioncode.Text = tabSub.Rows(0)("SectionName").ToString()
            ChucDanh.Text = tabSub.Rows(0)("ChucDanhName").ToString()
            StartedDate.EditValue = DirectCast(tabSub.Rows(0)("StartedDate"), DateTime)
        End If
        Dim QR As String
        QR = "exec [dbo].[sp_BangChuyenGiaTriFloat] '1900-1-1','" + Today.AddDays(100).ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + Employee_ID.EditValue.ToString.Trim + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_TransferFloatType]", XtraTabControl1, ErrorProvider1) Then
            Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
        End If
        Employee_ID.Select()
    End Sub

    Private Sub GridEX2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Public Overrides Sub AfterViewForm()
        Try
            If Not IsNothing(GridView1.Columns("TypeOfTransfer")) Then
                GridView1.Columns("TypeOfTransfer").OptionsColumn.AllowEdit = False
            End If
            If Not IsNothing(GridView1.Columns("PositionName")) Then
                GridView1.Columns("PositionName").Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub UltraTabControl1_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
    '    HRFORM_UltraTabControl_SelectedTabChanged(sender, e)
    '    LoadGiaoDienTheoDieuKien()
    '    Search()
    'End Sub

    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
End Class