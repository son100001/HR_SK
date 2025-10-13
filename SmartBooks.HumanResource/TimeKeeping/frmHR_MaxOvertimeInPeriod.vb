Imports WindowsControlLibrary
Public Class frmHR_MaxOvertimeInPeriod
    Private Sub frmHR_MaxOvertimeInPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class