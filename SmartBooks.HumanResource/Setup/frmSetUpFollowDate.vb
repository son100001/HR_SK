Imports WindowsControlLibrary
Public Class frmSetUpFollowDate
    Private Sub frmSetUpFollowDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tvcn.GetDataOnDropDownCategoryCodeName(Group_, kn.ReadData("select distinct Group_ as Code, Group_ as Name from HR_SetUpFollowDate", "table"))
        'tvcn.GetDataOnDropDownCategoryCodeName(Code, kn.ReadData("select distinct Code, Code as Name from HR_SetUpFollowDate", "table"))
        FromDate.EditValue = Today
        ToDate.EditValue = DBNull.Value
        ToDate.Enabled = False
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub cbToDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTodate.CheckedChanged
        If cbTodate.Checked = True Then
            ToDate.Enabled = True
            ToDate.EditValue = FromDate.EditValue
        Else
            ToDate.Enabled = False
            ToDate.EditValue = DBNull.Value
        End If
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from " + HRFORM_TableName
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        Code.Select()
        Search()
    End Sub
End Class