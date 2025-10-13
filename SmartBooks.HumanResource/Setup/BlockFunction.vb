 
Public Class BlockFunction
    Dim tabUser As DataTable
    Private Sub BlockFunction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' sp_BangUser
        tvcn.Xem("exec sp_BangUser '" + obj.UserName + "'", "", GridControl2, GridView2, tabUser)
        GridView2.Columns("Password").Visible = False
        Dim tabName As DataTable = kn.ReadData("select Category as Code, NameVN as Name from HR_Category where CategoryFather='ListOfBlock'", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(TableName, tabName)
        Block_Date.EditValue = Today
        'LoadGiaoDienTheoDieuKien()
    End Sub
    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bLoi As Boolean
        If GridView2.SelectedRowsCount <= 0 Then
            MessageBox.Show("Bạn chưa chọn user để khóa!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If tvcn.CheckErrorProvider(XtraTabControl1, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        Dim UserName As String = ""
        For numberRow As Integer = 0 To GridView2.SelectedRowsCount - 1
            UserName = GridView1.GetDataRow(GridView2.GetSelectedRows(numberRow)).Item("UserName").ToString()
            If Save(0, TableName.EditValue.ToString, Block_Date.EditValue, UserName, True, Remark.Text.Trim) = False Then
                MessageBox.Show("Nhập lỗi!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bLoi = True
                Exit For
            End If
        Next
        If bLoi = False Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
    End Sub
    Private Function Save(ByVal ID As Integer, ByVal TableName As String, ByVal block_date As DateTime, ByVal Block_User As String, ByVal status As Boolean, ByVal Remark As String) As Boolean
        If kn.SaveData("exec usp_InsertUpdateHR_Khoa " + IIf(ID = 0, "null", ID.ToString()) + ",'" + TableName + "','" + block_date.ToString("yyyy-MM-dd") + "','" + Block_User + "'," + IIf(status = True, "1", "null") + ",N'" + Remark + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "',N'" + obj.UserName + "'") Then
            Return True
        End If
    End Function

    Private Sub btnNhapNgayKhoa_Click(sender As Object, e As EventArgs) Handles btnNhapNgayKhoa.Click
        If HRFORM_Gridview.SelectedRowsCount <= 0 Then
            MessageBox.Show("Bạn chưa chọn dòng để nhập ngày khóa.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim row As DataRow
        For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
            GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow)).Item("block_date") = Block_Date.EditValue
        Next
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp, MyBase.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub GridControl2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class