Public Class frmBaoCaoLuong

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If e.Page.Name = "MonthlySalary" Then
            HRFORM_Gridview = GridView2
            HRFORM_GridControl = GridControl2
            HRFORM_VisibleControl_GetTemplate = False
            HRFORM_VisibleControl_ImportExcel = False
            HRFORM_VisibleControl_Luu = False
            HRFORM_VisibleControl_Sua = False
            HRFORM_VisibleControl_Xoa = False
        ElseIf e.Page.Name = "General" Then
            HRFORM_Gridview = GridView1
            HRFORM_GridControl = GridControl1
            HRFORM_VisibleControl_GetTemplate = False
            HRFORM_VisibleControl_ImportExcel = False
            HRFORM_VisibleControl_Luu = False
            HRFORM_VisibleControl_Sua = False
            HRFORM_VisibleControl_Xoa = False
        End If
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub GridControl2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class