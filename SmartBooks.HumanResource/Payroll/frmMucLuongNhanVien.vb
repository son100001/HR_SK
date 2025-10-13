 
Imports WindowsControlLibrary
Public Class frmMucLuongNhanVien
    Private Sub frmMucLuongNhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        FromDate.EditValue = Today
        Dim salaryGroupTab = kn.ReadData("select distinct SalaryGroup from HR_MucLuong", "table")
        Dim salaryStepTab = kn.ReadData("select distinct SalaryStep from HR_MucLuong", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(SalaryGroup, salaryGroupTab)
        tvcn.GetDataOnDropDownCategoryCodeName(SalaryStep, salaryStepTab)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Private Sub Gridex1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            If btnSave.Enabled = True Then
                btnSave_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_MucLuongNhanVien]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        SalaryGroup.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        'If Employee_ID.Text.Trim = String.Empty Then
        '    Exit Sub
        'End If
        Dim QR As String = "[dbo].[sp_BangMucLuongNhanVien] null,null,1,'" + obj.Lan + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + Employee_ID.Text.Trim + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub cbToDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbToDate.CheckedChanged
        ToDate.Enabled = cbToDate.Checked
        If cbToDate.Checked = False Then
            ToDate.EditValue = Nothing
        Else
            ToDate.EditValue = Today
        End If
    End Sub
End Class