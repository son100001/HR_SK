Imports WindowsControlLibrary
 

Public Class frmQuanLyTheTu
    Private Sub frmQuanLyTheTu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(XtraTabControl1, HRFORM_TableName)
        'LoadGiaoDienTheoDieuKien()
        Dim tabRFID As DataTable = kn.ReadData("select Category as Code, Name" + obj.Lan + " as Name from [dbo].[HR_Category] where CategoryFather = 'phongban'", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(RFID, tabRFID)
        EffectiveDate.EditValue = Today
    End Sub

    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim QR As String
        QR = "exec [dbo].[sp_BangChuyenViTri] '1900-1-1','" + Today.AddDays(100).ToString("yyyy-MM-dd") + "',5,'" + obj.Lan + "',NULL,NULL,NULL,NULL,NULL,NULL,N'" + Employee_ID.Text.Trim + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim DanhSachBuocNhap() As String = {"Employee_ID", "RFID"}
        If tvcn.CheckErrorProvider(XtraTabControl1, ErrorProvider1, DanhSachBuocNhap) = False Then
            Exit Sub
        End If
        If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Save(0, Employee_ID.Text.Trim, RFID.Text.Trim, EffectiveDate.EditValue.ToString, "RFID", "RFID", Remark.Text.Trim) = True Then
                Search()
            End If
        End If
        Employee_ID.Select()
    End Sub

    Private Function Save(ByVal ID As Integer, ByVal Employee_ID As String, ByVal TransferCode As String, ByVal EffectiveDate As DateTime, ByVal TypeOfTransfer As String, ByVal AssignType As String, ByVal Remark As String) As Boolean
        Dim tabCheck As DataTable
        tabCheck = kn.ReadData("exec usp_InsertUpdateHR_Transfer " + IIf(ID = 0, "null", ID.ToString()) + ",'" + Employee_ID + "','" + RFID.EditValue.ToString + "','" + EffectiveDate.ToString("yyyy-MM-dd") + "','RFID','RFID'," + IIf(Remark.Trim = String.Empty, "null", "N'" + Remark + "'") + ",'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + obj.UserName + "'", "Table")
        If Not IsNothing(tabCheck) Then
            If tabCheck.Rows(0)("ThongBao") <> "" Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            Return False
        End If
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function
    Public Overrides Sub AfterViewForm()
        Try
            If Not IsNothing(GridView1.Columns("TypeOfTransfer")) Then
                GridView1.Columns("TypeOfTransfer").OptionsColumn.AllowEdit = False
            End If
            If Not IsNothing(GridView1.Columns("AssignType")) Then
                GridView1.Columns("AssignType").Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Overrides Sub AfterImportExcel()
        For r = 0 To HRFORM_Gridview.RowCount - 1
            GridView1.GetDataRow(r).Item("block_date") = "RFID"
            GridView1.GetDataRow(r).Item("AssignType") = "RFID"
        Next
    End Sub
    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub Employee_ID_TextChanged(sender As Object, e As EventArgs)
        Search()
        OldRFID.Text = String.Empty
        Dim tab As DataTable = kn.ReadData("select RFID from udf_EmployeeFilter('',null,null,null,null,null,null,'" + Employee_ID.Text.Trim + "',getdate())", "table")
        If tab.Rows.Count > 0 Then
            If Not IsDBNull(tab.Rows(0)("RFID")) Then
                OldRFID.Text = tab.Rows(0)("RFID")
            End If
        End If
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class