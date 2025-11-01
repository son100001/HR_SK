Imports WindowsControlLibrary
 
Imports DevExpress.XtraEditors.Controls

Public Class frmRoundShift

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If e.Page.Name = "RoundShift" Then
            fromdate.DateTime = Today
            HRFORM_TableName = "HR_RoundShift"
            HRFORM_GridControl = GridControl1
            HRFORM_Gridview = GridView1
            HRFORM_VisibleControl_Sua = False
            HRFORM_VisibleControl_ThemMoi = False
            btnAdd.Visible = False
            btnEdit.Visible = False
            cbbReport.Visible = True
            btnExcute.Visible = True
        ElseIf e.Page.Name = "RoundShiftDetail" Then
            HRFORM_TableName = "HR_RoundShiftDetail"
            HRFORM_GridControl = GridControl2
            HRFORM_Gridview = GridView2
            cbbReport.Visible = False
            btnExcute.Visible = False
            btnAdd.Visible = True
            btnEdit.Visible = True
            HRFORM_VisibleControl_Sua = False
            HRFORM_VisibleControl_ThemMoi = False
            HRFORM_DeleteStore = String.Empty
        End If
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        If ReportCode = "RoundShiftViewForInput" Then
            fromdate.DateTime = obj.PARA_NGAY
        End If
        'If HRFORM_Gridex.RootTable.Columns.Contains("TypeOfRegister") Then
        '    HRFORM_Gridex.RootTable.Columns("TypeOfRegister").EditType = EditType.NoEdit
        'End If
    End Sub
    'Public Overrides Sub AfterImportExcel()
    '    If UltraTabControl1.SelectedTab.Key = "RoundShift" Then
    '        For Each r As GridEXRow In HRFORM_Gridex.GetRows
    '            r.BeginEdit()
    '            If Not IsDBNull(r.Cells("ToDate").Value) Then
    '                r.Cells("TypeOfRegister").Value = 1
    '            Else
    '                r.Cells("TypeOfRegister").Value = 0
    '            End If
    '            r.EndEdit()
    '        Next
    '    End If
    'End Sub

    Private Sub frmRoundShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        ShiftName.Properties.DataSource = kn.ReadData("exec sp_BangCa", "table")
        ShiftName.Properties.DisplayMember = "ShiftSign"
        ShiftName.Properties.ValueMember = "ShiftName"
        ShiftName.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        ShiftName.Properties.NullText = ""
        fromdate.DateTime = Today
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub
    Private Sub GridView1_CustomDrawColumnHeader(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles GridView1.CustomDrawColumnHeader
        If e.Column Is Nothing Then
            Return
        End If

        Dim colName As String = e.Column.FieldName
        Dim dt As DateTime

        If DateTime.TryParse(colName, dt) Then
            If dt.DayOfWeek = DayOfWeek.Saturday OrElse dt.DayOfWeek = DayOfWeek.Sunday Then
                e.Appearance.BackColor = Color.LightBlue
                e.Appearance.ForeColor = Color.DarkRed
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Grid_Rowstyle(sender, e)
        'If e.Column Is Nothing Then
        '    Return
        'End If

        'Dim colName As String = e.Column.FieldName
        'Dim dt As DateTime
        'If DateTime.TryParse(colName, dt) Then
        '    If dt.DayOfWeek = DayOfWeek.Saturday OrElse dt.DayOfWeek = DayOfWeek.Sunday Then
        '        e.Appearance.BackColor = Color.Snow
        '        e.Appearance.ForeColor = Color.Black
        '    End If
        'End If
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd, td As DateTime

        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(fromdate.DateTime.Year, fromdate.DateTime.Month, 2), New DateTime(fromdate.DateTime.Year, fromdate.DateTime.Month, 1).AddMonths(1).AddDays(-1))
        fd = New DateTime(fromdate.DateTime.Year, fromdate.DateTime.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If

        Dim QR As String
        If cbTypeOfReport.Checked = False Then
            QR = "exec [dbo].[sp_BangDangKyCaXoay] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',4,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Else
            QR = "exec [dbo].[sp_BangDangKyCaXoay] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',5,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        End If

        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub GioTCTruoc_Leave(sender As Object, e As EventArgs) Handles GioTCTruoc.Leave
        tvcn.FloatFormat(GioTCTruoc)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_RoundShift]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub GridControl2_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class