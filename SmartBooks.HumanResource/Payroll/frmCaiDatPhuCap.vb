Public Class frmCaiDatPhuCap
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[" + HRFORM_SaveStore + "]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        LoaiPhuCap.Select()
    End Sub
    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles Amount.TextChanged
        tvcn.AmountFormat(Amount)
    End Sub
    Private Sub Search()
        Dim QR As String = "select * from " + HRFORM_TableName
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub
    Private Sub Gridex1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
    Private Sub cbToDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbToDate.CheckedChanged
        If cbToDate.Checked = True Then
            ToDate.EditValue = Today
            ToDate.Enabled = True
        Else
            ToDate.Enabled = False
            ToDate.EditValue = Nothing
        End If
    End Sub

    Private Sub frmCaiDatPhuCap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        Dim tabLoaiPhuCap As DataTable = kn.ReadData("select SalaryComponent as Code, Name" + obj.Lan + " as Name, Insurance from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0 order by OrderBy", "table")
        LoaiPhuCap.Properties.DataSource = tabLoaiPhuCap
        LoaiPhuCap.Properties.DisplayMember = "Name"
        LoaiPhuCap.Properties.ValueMember = "Code"
        LoaiPhuCap.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        LoaiPhuCap.Properties.NullText = ""
        FromDate.EditValue = Today
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
End Class