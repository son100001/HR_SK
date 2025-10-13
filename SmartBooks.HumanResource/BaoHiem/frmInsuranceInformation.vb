Imports WindowsControlLibrary.HRFORM
Public Class frmInsuranceInformation
    Private Sub frmInsuranceInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub Gridex2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl2.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If e.Page.Name = "InsuranceBook" Then
            HRFORM_TableName = "HR_Insurance"
            HRFORM_GridControl = GridControl1
            HRFORM_Gridview = GridView1
            HRFORM_InputForm = "frmSoBaoHiem_Nhap"
        ElseIf e.Page.Name = "InsuranceCard" Then
            HRFORM_TableName = "HR_TheBHYT"
            HRFORM_GridControl = GridControl2
            HRFORM_Gridview = GridView2
            HRFORM_InputForm = "frmTheBHYT_Nhap"
        End If
        LoadGiaoDienTheoDieuKien()
        'HRFORM_UltraTabControl_SelectedTabChanged(sender, e)
    End Sub
End Class