Imports DevExpress.XtraEditors.Controls

Public Class frmRegisMaxOvertime
    Dim TypeOfReport As Integer = 1
    Private Sub frmRegisMaxOvertime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        ShiftName.Properties.DataSource = kn.ReadData("exec sp_BangCa", "table")
        ShiftName.Properties.DisplayMember = "ShiftSign"
        ShiftName.Properties.ValueMember = "ShiftName"
        ShiftName.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        ShiftName.Properties.NullText = ""
        tvcn.GetDataOnDropDownCategoryCodeName(Factory_ID_SK1, kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "') where code <> 'SK2'", "table"))
        tvcn.GetDataOnDropDownCategoryCodeName(Factory_ID_SK2, kn.ReadData("select * from udf_FactorySK2 ('VN')", "table"))
        tvcn.SearchEmployee(Employee_ID)
        LoadGiaoDienTheoDieuKien()
        Search(TypeOfReport)
    End Sub
    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportRow("ReportCode") = "RegisMaxOvertimeGetTemplateFollowDate" Then
            Dim frm As New para_NhanVienActive
            frm.Set_FromDate(obj.PARA_FROMDATE)
            frm.Set_ToDate(obj.PARA_TODATE)
            frm.ShowDialog()
            If frm.bluu = True Then
                Dim fileChooser As SaveFileDialog = New SaveFileDialog
                fileChooser.FileName = "TempNhapTheoThoiGian.xlsx"
                Dim result As DialogResult = fileChooser.ShowDialog()
                fileChooser.CheckFileExists = False
                If result = DialogResult.OK Then
                    tvcn.LayTemplateTheoThoiGian(fileChooser.FileName, frm.GridView1, obj.PARA_FROMDATE, obj.PARA_TODATE, True)
                End If
            End If
        ElseIf ReportRow("ReportCode") = "RegisMaxOvertimeImportTemplateFollowDate" Then
            tvcn.NhapTemplateTheoThoiGian("HR_MaxOvertime")
        End If
    End Sub

    'Public Overrides Function BeforeSave() As Integer
    '    If btnNhap.Enabled = True Then
    '        For Each grid As GridEXRow In Gridex1.GetRows
    '            If IsDBNull(grid.Cells("InsertDate").Value) And IsDBNull(grid.Cells("UserName").Value) Then
    '                grid.BeginEdit()
    '                grid.Cells("InsertDate").Value = Now
    '                grid.Cells("UserName").Value = obj.UserName
    '                grid.EndEdit()
    '            End If
    '        Next
    '    End If
    '    Return 1
    'End Function
    Public Overrides Sub AfterViewForm()
        'If Not IsNothing(HRFORM_Gridex.RootTable) Then
        '    If ReportCode = "RegisMaxOvertimeViewToImportFollowGrid" Then
        '        workingdate.DateTime = obj.PARA_NGAY
        '    End If
        '    'If HRFORM_Gridex.RootTable.Columns.Contains("workingdate") And HRFORM_Gridex.RootTable.Columns.Contains("Employee_ID") And HRFORM_Gridex.RootTable.Columns.Contains("ShiftName") Then
        '    '    btnLoadShift.Enabled = True
        '    'Else
        '    '    btnLoadShift.Enabled = False
        '    'End If
        'End If

    End Sub

    Private Function KiemTraNgayNghiBu() As Boolean
        If TypeOfOT.EditValue = "4" Then
            If NgayNghiBu.DateTime = workingdate.DateTime Or NgayNghiBu.DateTime < workingdate.DateTime.AddDays(-7) Or NgayNghiBu.DateTime > workingdate.DateTime.AddDays(7) Or NgayNghiBu.DateTime.Month <> workingdate.DateTime.Month Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Ngaynghibukhonghople"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        Return True
    End Function


    Public Overrides Sub AfterImportExcel()

    End Sub

    Private Sub Search(ByVal TypeOfReport As Integer)
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd As DateTime, td As DateTime

        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(workingdate.DateTime.Year, workingdate.DateTime.Month, 2), New DateTime(workingdate.DateTime.Year, workingdate.DateTime.Month, 1).AddMonths(1).AddDays(-1))

        If TypeOfReport = 1 Then
            fd = New DateTime(workingdate.DateTime.Year, workingdate.DateTime.Month, 1)
        ElseIf TypeOfReport = 6 Then
            fd = New DateTime(Ngay_SK1.DateTime.Year, Ngay_SK1.DateTime.Month, 1)
        Else
            fd = New DateTime(Ngay_SK2.DateTime.Year, Ngay_SK2.DateTime.Month, 1)
        End If

        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If

        Dim QR As String = "exec [dbo].[sp_BangDangKyTangCa] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "'," + TypeOfReport.ToString + ",'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub


    Private Sub TypeOfOT_EditValueChanged(sender As Object, e As EventArgs) Handles TypeOfOT.EditValueChanged
        If TypeOfOT.EditValue = "4" Then
            NgayNghiBu.Enabled = True
            NgayNghiBu.DateTime = Today
        Else
            NgayNghiBu.Enabled = False
            NgayNghiBu.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub NgayNghiBu_EditValueChanged(sender As Object, e As EventArgs) Handles NgayNghiBu.EditValueChanged
        KiemTraNgayNghiBu()
    End Sub

    Private Sub workingdate_EditValueChanged(sender As Object, e As EventArgs) Handles workingdate.EditValueChanged
        If workingdate.DateTime.Year = 1 Then
            workingdate.DateTime = Today
        End If
        Dim tabNgayLe As DataTable = kn.ReadData("select * from SmartBooks_HolidaysPlan where H_date='" + workingdate.DateTime.ToString("yyyy-MM-dd") + "'", "table")
        If tabNgayLe.Rows.Count > 0 Then
            TypeOfOT.Text = String.Empty
            tvcn.GetDataOnDropDownCategoryCodeName(TypeOfOT, "HolidayTypeOfOT")
        ElseIf workingdate.DateTime.DayOfWeek = DayOfWeek.Sunday Then
            TypeOfOT.Text = String.Empty
            tvcn.GetDataOnDropDownCategoryCodeName(TypeOfOT, "HolidayTypeOfOT")
            'TypeOfOT.SelectedIndex = 0
        Else
            TypeOfOT.Text = String.Empty
            tvcn.GetDataOnDropDownCategoryCodeName(TypeOfOT, "TypeOfOT")
            'TypeOfOT.SelectedIndex = 0
        End If
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search(TypeOfReport)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If KiemTraNgayNghiBu() = False Then
            Employee_ID.Select()
            Exit Sub
        End If
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[sp_InsertUpdateHR_MaxOvertime]", XtraTabControl1, ErrorProvider1) Then
            Search(TypeOfReport)
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search(TypeOfReport)
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Dim KH As String = tvcn.getSetUp("KH")
        If e.Page.Name = "General" Then
            HRFORM_TableName = "HR_MaxOvertime"
            HRFORM_GridControl = GridControl1
            HRFORM_Gridview = GridView1
            HRFORM_InputForm = ""
            HRFORM_SaveStore = "sp_InsertUpdateHR_MaxOvertime"
            HRFORM_DeleteStore = "usp_DeleteHR_MaxOvertime"
            btnGetTemplate.Visible = True
            btnImportExcel.Visible = True
            TypeOfReport = 1
        ElseIf e.Page.Name = "TangCaNgoaiLe_SK1" Then
            HRFORM_TableName = "HR_TangCaNgoaiLe_SK1"
            Ngay_SK1.DateTime = Today
            HRFORM_GridControl = GridControl2
            HRFORM_Gridview = GridView2
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = True
            HRFORM_SaveStore = ""
            HRFORM_DeleteStore = ""
            TypeOfReport = 6
        Else
            HRFORM_TableName = "HR_TangCaNgoaiLe_SK2"
            Ngay_SK2.DateTime = Today
            HRFORM_GridControl = GridControl3
            HRFORM_Gridview = GridView3
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnGetTemplate.Visible = False
            btnImportExcel.Visible = True
            HRFORM_SaveStore = ""
            HRFORM_DeleteStore = ""
            TypeOfReport = 7
        End If
        HRFORM_XtraTabControl_SelectedTabChanged(sender, e)
        LoadGiaoDienTheoDieuKien()
        Search(TypeOfReport)
    End Sub

    Private Sub Tim_SK1_Click(sender As Object, e As EventArgs) Handles Tim_SK1.Click
        Search(TypeOfReport)
    End Sub

    Private Sub Tim_SK2_Click(sender As Object, e As EventArgs) Handles Tim_SK2.Click
        Search(TypeOfReport)
    End Sub

    Private Sub Luu_SK2_Click(sender As Object, e As EventArgs) Handles Luu_SK2.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[sp_InsertUpdateHR_TangCaNgoaiLe_SK2]", XtraTabControl1, ErrorProvider1) Then
            Search(TypeOfReport)
        End If
    End Sub

    Private Sub Luu_SK1_Click(sender As Object, e As EventArgs) Handles Luu_SK1.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[sp_InsertUpdateHR_TangCaNgoaiLe_SK1]", XtraTabControl1, ErrorProvider1) Then
            Search(TypeOfReport)
        End If
    End Sub
End Class