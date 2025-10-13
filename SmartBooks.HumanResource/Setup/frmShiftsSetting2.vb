Imports DevExpress.XtraGrid.Views.Base
 

Public Class frmShiftsSetting2
    Private Sub frmShiftsSetting2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel3, HRFORM_TableName)
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub
    Public Overrides Sub AfterViewForm()
        If Not IsNothing(HRFORM_Gridview.Columns("FromTime")) Then
            HRFORM_Gridview.Columns("FromTime").Visible = False
        End If
        If Not IsNothing(HRFORM_Gridview.Columns("ToTime")) Then
            HRFORM_Gridview.Columns("ToTime").Visible = False
        End If
        If Not IsNothing(HRFORM_Gridview.Columns("RestTimeFrom")) Then
            HRFORM_Gridview.Columns("RestTimeFrom").Visible = False
        End If
        If Not IsNothing(HRFORM_Gridview.Columns("RestTimeTo")) Then
            HRFORM_Gridview.Columns("RestTimeTo").Visible = False
        End If
        If Not IsNothing(HRFORM_Gridview.Columns("RestTimeFrom1")) Then
            HRFORM_Gridview.Columns("RestTimeFrom1").Visible = False
        End If
        If Not IsNothing(HRFORM_Gridview.Columns("RestTimeTo1")) Then
            HRFORM_Gridview.Columns("RestTimeTo1").Visible = False
        End If
    End Sub

    Private Sub Search()
        Dim QR As String = "exec sp_BangCaiDatCa"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    'Private Sub cbNhapGioNghiGiuaGio_CheckedChanged(sender As Object, e As EventArgs)
    '    RestTimeFrom.Enabled = cbNhapGioNghiGiuaGio.Checked
    '    RestTimeTo.Enabled = cbNhapGioNghiGiuaGio.Checked
    '    If cbNhapGioNghiGiuaGio.Checked = True Then
    '        RestTimeTo.Value = Today
    '        RestTimeFrom.Value = Today
    '    Else
    '        RestTimeTo.Value = Nothing
    '        RestTimeFrom.Value = Nothing
    '    End If
    'End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.CheckErrorProvider(TableLayoutPanel3, ErrorProvider1, tvcn.GetColumns_ISNOTNULLABLE_OfTable(HRFORM_TableName)) = False Then
            Exit Sub
        End If
        tvcn.LuuHoacXoaTuForm(HRFORM_TableName, TableLayoutPanel3, True, QuyenHRFORM)
        ShiftName.Select()
        Search()
    End Sub



    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim CotTimeSpan As TimeSpan
        Dim CotDateTime As DateTime
        If Not IsNothing(GridView1.Columns("FromTime")) And Not IsNothing(GridView1.Columns("FromTime_Edit")) Then
            If e.Column.Name = "colFromTime_Edit" Then
                CotTimeSpan = GridView1.GetFocusedDataRow().Item("FromTime_Edit")
                CotDateTime = GridView1.GetFocusedDataRow().Item("FromTime")
                GridView1.GetFocusedDataRow().Item("FromTime") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
            End If
        End If
        If Not IsNothing(GridView1.Columns("ToTime")) And Not IsNothing(GridView1.Columns("ToTime_Edit")) Then
            If e.Column.Name = "colToTime_Edit" Then
                CotTimeSpan = GridView1.GetFocusedDataRow().Item("ToTime_Edit")
                CotDateTime = GridView1.GetFocusedDataRow().Item("ToTime")
                GridView1.GetFocusedDataRow().Item("ToTime") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
            End If
        End If
        If Not IsNothing(GridView1.Columns("RestTimeFrom")) And Not IsNothing(GridView1.Columns("RestTimeFrom_Edit")) Then
            If e.Column.Name = "colRestTimeFrom_Edit" Then
                CotTimeSpan = GridView1.GetFocusedDataRow().Item("RestTimeFrom_Edit")
                CotDateTime = GridView1.GetFocusedDataRow().Item("RestTimeFrom")
                GridView1.GetFocusedDataRow().Item("RestTimeFrom") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
            End If
        End If
        If Not IsNothing(GridView1.Columns("RestTimeTo")) And Not IsNothing(GridView1.Columns("RestTimeTo_Edit")) Then
            If e.Column.Name = "colRestTimeTo_Edit" Then
                CotTimeSpan = GridView1.GetFocusedDataRow().Item("RestTimeTo_Edit")
                CotDateTime = GridView1.GetFocusedDataRow().Item("RestTimeTo")
                GridView1.GetFocusedDataRow().Item("RestTimeTo") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
            End If
        End If
    End Sub
End Class