 
Imports WindowsControlLibrary

Public Class frmChuyenViTri
    Dim tabPosition As DataTable
    Private Sub frmChuyenViTri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        EffectiveDate.EditValue = Today
        tabPosition = kn.ReadData("select * from udf_Position('" + obj.Lan + "',0)", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(Position, tabPosition)
        tvcn.GetDataOnDropDownCategoryCodeName(OldPosition, tabPosition)
        Dim tabJobCode As DataTable = kn.ReadData("SELECT JobCode as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name FROM HR_JobCodeCategory ", "table")
        Dim tabChucDanh As DataTable = kn.ReadData("select ChucDanh as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_ChucDanh", "table")
        Dim tabPositionCategory As DataTable = kn.ReadData("select PositionCategory_ID as Code," + IIf(obj.Lan = "VN", "PositionCategory_NameVN", IIf(obj.Lan = "EN", "PositionCategory_NameEN", "PositionCategory_NameKR")) + " as Name from SmartBooks_PositionCategory", "table")
        Dim tabViTri = kn.ReadData("select Position_ID as Code," + IIf(obj.Lan = "VN", "Position_NameVN", IIf(obj.Lan = "EN", "Position_NameEN", "Position_NameKR")) + " as Name from SmartBooks_Position", "table")
        Dim tabForeignerStatus As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather = 'ForeignerStatus'", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(Position_ID, tabViTri)
        tvcn.GetDataOnDropDownCategoryCodeName(OldPosition_ID, tabViTri)
        tvcn.GetDataOnDropDownCategoryCodeName(PositionCategory_ID, tabPositionCategory)
        tvcn.GetDataOnDropDownCategoryCodeName(OldPositionCategory_ID, tabPositionCategory)
        tvcn.GetDataOnDropDownCategoryCodeName(ChucDanh, tabChucDanh)
        tvcn.GetDataOnDropDownCategoryCodeName(OldChucDanh, tabChucDanh)
        tvcn.GetDataOnDropDownCategoryCodeName(JobCode, tabJobCode)
        tvcn.GetDataOnDropDownCategoryCodeName(OldJobCode, tabJobCode)
        tvcn.SearchEmployee(Employee_ID)
        LoadGiaoDienTheoDieuKien()
        'rdbNhapLenLuoi.Checked = True
        lblPosition.Text = lblPosition.Text + " *"
        Search()
    End Sub


    Public Overrides Function BeforeSave() As Integer
        If IsNothing(HRFORM_Gridview.Columns("ViTriMoi")) Or IsNothing(HRFORM_Gridview.Columns("MaCongViecMoi")) Then
            Return 1
        End If
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return 1
        End If
        'If btnSave.Enabled = True Then
        '    For Each grid As GridEXRow In GridEX2.GetRows
        '        If IsDBNull(grid.Cells("InsertDate").Value) Or IsDBNull(grid.Cells("UserName").Value) Then
        '            grid.BeginEdit()
        '            grid.Cells("InsertDate").Value = Now
        '            grid.Cells("UserName").Value = obj.UserName
        '            grid.EndEdit()
        '        End If
        '    Next
        'End If
        Dim tabChange As DataTable
        tabChange = Table.GetChanges()
        Dim tabCheck As DataTable
        Dim bCoLoi As Boolean
        If Not IsNothing(tabChange) Then
            If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return 0
            End If
            Dim DepartmentCodeNew, ViTriMoi, MaCongViecMoi, ChucDanhMoi, LoaiChucVuMoi, ChucVuMoi, EffectiveDate, TypeOfTransfer, Remark, UserName As String
            For Each r As DataRow In Table.Rows
                If Not IsDBNull(r("Employee_ID")) And Not IsDBNull(r("EffectiveDate")) And (Not IsDBNull(r("ViTriMoi")) Or Not IsDBNull(r("MaCongViecMoi")) Or Not IsDBNull(r("ChucDanhMoi")) Or Not IsDBNull(r("LoaiChucVuMoi")) Or Not IsDBNull(r("ChucVuMoi"))) Then
                    If tabChange.Select("Employee_ID='" + r("Employee_ID") + "' and EffectiveDate='" + r("EffectiveDate") + "'").Length >= 1 Then
                        If Not IsDBNull(r("EffectiveDate")) Then
                            EffectiveDate = "'" + CDate(r("EffectiveDate")).ToString("yyyy-MM-dd") + "'"
                        Else
                            EffectiveDate = "null"
                        End If
                        If Not IsDBNull(r("ViTriMoi")) Then
                            ViTriMoi = "'" + r("ViTriMoi").ToString() + "'"
                        Else
                            ViTriMoi = "null"
                        End If
                        If Not IsDBNull(r("MaCongViecMoi")) Then
                            MaCongViecMoi = "'" + r("MaCongViecMoi").ToString() + "'"
                        Else
                            MaCongViecMoi = "null"
                        End If
                        If Not IsDBNull(r("ChucDanhMoi")) Then
                            ChucDanhMoi = "'" + r("ChucDanhMoi").ToString() + "'"
                        Else
                            ChucDanhMoi = "null"
                        End If
                        If Not IsDBNull(r("LoaiChucVuMoi")) Then
                            LoaiChucVuMoi = "'" + r("LoaiChucVuMoi").ToString() + "'"
                        Else
                            LoaiChucVuMoi = "null"
                        End If
                        If Not IsDBNull(r("ChucVuMoi")) Then
                            ChucVuMoi = "'" + r("ChucVuMoi").ToString() + "'"
                        Else
                            ChucVuMoi = "null"
                        End If
                        If Not IsDBNull(r("Remark")) Then
                            Remark = "N'" + r("Remark").ToString() + "'"
                        Else
                            Remark = "null"
                        End If
                        tabCheck = kn.ReadData("exec usp_HR_Transfer_Department N'" + r("Employee_ID") + "'," + EffectiveDate + "," + ViTriMoi + "," + MaCongViecMoi + "," + ChucDanhMoi + "," + LoaiChucVuMoi + "," + ChucVuMoi + "," + Remark + ",N'" + obj.UserName + "'", "Table")
                        If Not IsNothing(tabCheck) Then
                            If Table.Columns.Contains("KiemTraDuLieuNhap") Then
                                r("KiemTraDuLieuNhap") = tabCheck.Rows(0)("ThongBao")
                                If tabCheck.Rows(0)("ThongBao") <> "" Then
                                    bCoLoi = True
                                End If
                            ElseIf tabCheck.Rows(0)("ThongBao") <> "" Then
                                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuketthuc") + ": " + r("Employee_ID") + " " + tabCheck.Rows(0)("ThongBao"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                End If
            Next
            Table.AcceptChanges()
            If bCoLoi = True Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuketthucnhungcomotsobanghibiloibanvuilongkiemtralai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Return 0
    End Function

    'Public Overrides Sub AfterViewForm() TẠM ĐÓNG ĐỂ VIEW DEVEXPRESS
    '    If HRFORM_Gridex.RootTable.Columns.Contains("TypeOfTransfer") Then
    '        HRFORM_Gridex.RootTable.Columns("TypeOfTransfer").EditType = Janus.Windows.GridEX.EditType.NoEdit
    '    End If
    '    If HRFORM_Gridex.RootTable.Columns.Contains("TransferCode") = True Then
    '        HRFORM_Gridex.RootTable.Columns("TransferCode").Width = 150
    '    End If
    '    If HRFORM_Gridex.RootTable.Columns.Contains("Name") = True Then
    '        HRFORM_Gridex.RootTable.Columns("Name").Width = 270
    '    End If
    '    If HRFORM_Gridex.RootTable.Columns.Contains("ViTriMoi") = True Then
    '        HRFORM_Gridex.RootTable.Columns("ViTriMoi").Width = 270
    '    End If
    '    If HRFORM_Gridex.RootTable.Columns.Contains("ViTriMoi") And HRFORM_Gridex.RootTable.Columns.Contains("MaCongViecMoi") And HRFORM_Gridex.RootTable.Columns.Contains("EffectiveDate") And HRFORM_Gridex.RootTable.Columns.Contains("Employee_ID") Then
    '        btnSave.Enabled = True
    '    End If
    '    If GridEX2.RootTable.Columns.Contains("ViTriMoi") Then
    '        tvcn.TaoDropDowTrenGrid(HRFORM_Gridex, "ViTriMoi", tabPosition)
    '        HRFORM_Gridex.RootTable.Columns("ViTriMoi").EditType = EditType.MultiColumnCombo
    '        HRFORM_Gridex.RootTable.Columns("ViTriMoi").DropDown = HRFORM_Gridex.DropDowns("ViTriMoi")
    '    End If
    '    If (GridEX2.RootTable.Columns.Contains("MaCongViecMoi") Or GridEX2.RootTable.Columns.Contains("JobCode")) And GridEX2.DropDowns.Contains("JobCode") = False Then
    '        Dim tabJobCode As DataTable = kn.ReadData("exec sp_BangDanhMucJobCode ", "table")
    '        Dim gdd As New GridEXDropDown
    '        gdd.Name = "JobCode"
    '        gdd.Key = "JobCode"
    '        Dim c As New GridEXColumn
    '        c.DataMember = "JobCode"
    '        c.Caption = "JobCode"
    '        c.Key = "JobCode"
    '        Dim cName As New GridEXColumn
    '        cName.Caption = "Name"
    '        cName.Key = "Name"
    '        cName.DataMember = "Name"
    '        Dim cHazard As New GridEXColumn
    '        cHazard.Caption = "Hazard"
    '        cHazard.Key = "Hazard"
    '        cHazard.DataMember = "Hazard"
    '        GridEX2.DropDowns.Add("JobCode")
    '        GridEX2.DropDowns.Item("JobCode").Columns.Add(c)
    '        GridEX2.DropDowns.Item("JobCode").Columns.Add(cName)
    '        GridEX2.DropDowns.Item("JobCode").Columns.Add(cHazard)
    '        GridEX2.DropDowns("JobCode").DisplayMember = "Name"
    '        GridEX2.DropDowns("JobCode").ValueMember = "JobCode"
    '        GridEX2.DropDowns.Item("JobCode").SetDataBinding(tabJobCode, "")
    '    End If
    '    If GridEX2.RootTable.Columns.Contains("MaCongViecMoi") Then
    '        GridEX2.RootTable.Columns("MaCongViecMoi").EditType = EditType.MultiColumnCombo
    '        GridEX2.RootTable.Columns("MaCongViecMoi").DropDown = GridEX2.DropDowns("JobCode")
    '    End If
    '    If GridEX2.RootTable.Columns.Contains("JobCode") Then
    '        GridEX2.RootTable.Columns("JobCode").EditType = EditType.MultiColumnCombo
    '        GridEX2.RootTable.Columns("JobCode").DropDown = GridEX2.DropDowns("JobCode")
    '    End If
    'End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String
        If cbTypeOfView.Checked = True Then
            QR = "exec [dbo].[sp_BangChuyenViTri] '1900-1-1','" + Today.AddDays(100).ToString("yyyy-MM-dd") + "',3,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Else
            QR = "exec [dbo].[sp_BangChuyenViTri] '1900-1-1','" + Today.AddDays(100).ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        End If
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Function Save() As Boolean
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim tabCheck As DataTable
        tabCheck = kn.ReadData("exec usp_HR_Transfer_Department N'" + EmID + "','" + EffectiveDate.DateTime.ToString("yyyy-MM-dd") + "'," + IIf(IsNothing(Position.EditValue) = True, "NULL", "N'" + Position.EditValue + "'") + "," + IIf(IsNothing(JobCode.EditValue) = True, "NULL", "N'" + JobCode.EditValue + "'") + "," + IIf(IsNothing(ChucDanh.EditValue) = True, "NULL", "N'" + ChucDanh.EditValue + "'") + "," + IIf(IsNothing(PositionCategory_ID.EditValue) = True, "NULL", "N'" + PositionCategory_ID.EditValue + "'") + "," + IIf(IsNothing(Position_ID.EditValue) = True, "NULL", "N'" + Position_ID.EditValue + "'") + "," + IIf(Remark.Text.Trim = "", "Null", "'" + Remark.Text.Trim + "'") + ",N'" + obj.UserName + "'", "Table")
        If Not IsNothing(tabCheck) Then
            If tabCheck.Rows(0)("ThongBao") <> "" Then
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            Return False
        End If
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click 
        If QuyenHRFORM = "View" Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If tvcn.CheckErrorProvider(XtraTabControl1, ErrorProvider1, {"Employee_ID", "EffectiveDate"}) = False Then
            Exit Sub
        End If
        Save()
        Employee_ID.Select()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged 
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        Else
            Exit Sub
        End If
        If Employee_ID.EditValue.ToString.Trim <> String.Empty Then
            Dim tab As DataTable = kn.ReadData("select Position,ChucDanh,JobCode,PositionCategory_ID,Position_ID from udf_EmployeeFilter('" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "',getdate())", "table")
            If tab.Rows.Count > 0 Then
                If Not IsDBNull(tab.Rows(0)("Position")) Then
                    OldPosition.EditValue = tab.Rows(0)("Position")
                End If
                If Not IsDBNull(tab.Rows(0)("ChucDanh")) Then
                    OldChucDanh.EditValue = tab.Rows(0)("ChucDanh")
                End If
                If Not IsDBNull(tab.Rows(0)("JobCode")) Then
                    OldJobCode.EditValue = tab.Rows(0)("JobCode")
                End If
                If Not IsDBNull(tab.Rows(0)("PositionCategory_ID")) Then
                    OldPositionCategory_ID.EditValue = tab.Rows(0)("PositionCategory_ID")
                End If
                If Not IsDBNull(tab.Rows(0)("Position_ID")) Then
                    OldPosition_ID.EditValue = tab.Rows(0)("Position_ID")
                End If
            End If
        End If
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click 
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub
End Class