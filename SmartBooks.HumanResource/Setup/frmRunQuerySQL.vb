Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinTabControl
 
Public Class frmRunQuerySQL
    Public kn As New WindowsControlLibrary.connect(WindowsControlLibrary.DbSetting.dataPath)
    Public obj As New WindowsControlLibrary.DbSetting
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If kn.SaveData(rtbQuery.Text.Trim) Then
            MessageBox.Show("Thực hiện thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim Table As DataTable = kn.ReadData(rtbQuery.Text.Trim, "table")
        Me.GridControl1.DataSource = Table
    End Sub

    Private Sub frmRunQuerySQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If obj.UserName.ToUpper = "ADMIN" Then
            btnView.Enabled = True
            btnRun.Enabled = True
        Else
            btnView.Enabled = False
            btnRun.Enabled = True
        End If
    End Sub
End Class