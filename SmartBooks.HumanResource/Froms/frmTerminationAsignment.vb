 
Imports WindowsControlLibrary

Public Class frmTerminationAsignment
    Private Sub frmTerminationAsignment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        tvcn.GetDataOnDropDownCategoryCodeName(ResonTerminated, "resigned")
        tvcn.GetDataOnDropDownCategoryCodeName(DecisionStatus, "DecisionStatus")
        LoadGiaoDienTheoDieuKien()
        DecisionStatus.EditValue = "Approved"
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        Dim tabResonTerminated As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='resigned'", "table")
        tvcn.TaoDropDowTrenGrid(GridView1, "ResonTerminated", tabResonTerminated)

        Dim tabDecisionStatus As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather='DecisionStatus'", "table")
        tvcn.TaoDropDowTrenGrid(GridView1, "DecisionStatus", tabDecisionStatus)
        If Not IsNothing(GridView1.Columns("ThangTinhLuong")) Then
            GridView1.Columns("ThangTinhLuong").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns("ThangTinhLuong").DisplayFormat.FormatString = "MM/yyyy"
        End If
    End Sub
    Public Overrides Function BeforeDelete() As Integer
        If GridView1.GetSelectedRows.Length <= 0 Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Banvuilongchondongcanxoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonxoa"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim bCheckThanhCong As Boolean = True
                Dim gridrow As DataRow
                For numberRow As Integer = 0 To GridView1.SelectedRowsCount - 1
                    gridrow = GridView1.GetDataRow(GridView1.GetSelectedRows(numberRow))
                    If kn.SaveData("exec usp_DeleteHR_TerminationAsignment '" + gridrow.Item("Employee_ID").ToString + "','" + CDate(gridrow.Item("PlanTernimationDate")).ToString("yyyy-MM-dd") + "'") = False Then
                        bCheckThanhCong = False
                    End If
                Next
                If bCheckThanhCong = False Then
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Xoakhongthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Xoathanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
            End If
        End If

        Return 0
    End Function

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "[dbo].[sp_BangQuyetDinhThoiViec] '1900-1-1','" + Today.AddMonths(1).ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "','',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_TerminationAsignment]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs)
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Employee_ID_EditValueChanged_1(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class