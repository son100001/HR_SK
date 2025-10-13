Imports OfficeOpenXml
Imports System.IO
Imports WindowsControlLibrary
Public Class frmLuongCoDinh
    Private Sub NhapTempale()
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            End If
            Dim urlTemplate As String = ofd.FileName
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = 8
                Dim ColConfig As Integer = 6
                Dim intColStart As Integer = 4
                Dim objDt As Object
                Dim tabCheck As DataTable
                Dim Employee_ID, SalaryComponent, Amount, fromdate, todate, Remark, InsertDate, UserName As String
                InsertDate = "'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                UserName = "N'" + obj.UserName + "'"
                While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = "N'" + CStr(worksheet.Cells("A" + index.ToString).Value).Trim + "'"
                    objDt = worksheet.Cells("B" + index.ToString()).Value
                    If Not IsNothing(objDt) Then
                        If objDt.GetType.FullName = "System.Double" Then
                            fromdate = "'" + DateTime.FromOADate(objDt).ToString("yyyy-MM-dd") + "'"
                        Else
                            fromdate = "'" + CDate(objDt).ToString("yyyy-MM-dd") + "'"
                        End If
                    End If
                    objDt = worksheet.Cells("C" + index.ToString()).Value
                    If Not IsNothing(objDt) Then
                        If objDt.GetType.FullName = "System.Double" Then
                            todate = "'" + DateTime.FromOADate(objDt).ToString("yyyy-MM-dd") + "'"
                        Else
                            todate = "'" + CDate(objDt).ToString("yyyy-MM-dd") + "'"
                        End If
                    Else
                        todate = "null"
                    End If
                    Remark = worksheet.Cells("D" + index.ToString).Text.Trim
                    If Remark = String.Empty Then
                        Remark = "null"
                    Else
                        Remark = "N'" + Remark + "'"
                    End If
                    For intcol As Integer = intColStart To ColExel.Length - 1
                        If worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim <> String.Empty Then
                            SalaryComponent = "N'" + CStr(worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Value).Trim + "'"
                            If Not IsNothing(worksheet.Cells(ColExel(intcol) + index.ToString).Value) Then
                                Amount = worksheet.Cells(ColExel(intcol) + index.ToString).Value.ToString
                            Else
                                Amount = String.Empty
                            End If

                            If Amount <> String.Empty Then
                                tabCheck = kn.ReadData("exec usp_InsertUpdateHR_SalaryComponent null," + Employee_ID + "," + SalaryComponent + "," + Amount + "," + fromdate + "," + todate + ",'Excel'," + Remark + "," + InsertDate + "," + UserName, "table")
                                If Not IsNothing(tabCheck) Then
                                    If tabCheck.Rows(0)("ThongBao") <> "" Then
                                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ", " + tvcn.GetLanguagesTranslated("Employee_ID") + ": " + " " + Employee_ID + ": " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                End If

                                'If kn.SaveData("exec usp_InsertUpdateHR_SalaryComponent null, " + Employee_ID + ", " + SalaryComponent + ", " + Amount + ", " + fromdate + ", " + todate + ",'Excel'," + Remark + "," + InsertDate + "," + UserName) = False Then
                                        '    MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString + ". Bạn vui lòng kiểm tra lại dữ liệu.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        '    Exit Sub
                                        'End If
                                    End If
                        Else
                            Exit For
                        End If
                    Next
                    index += 1
                End While
                MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Private Sub LayTemplateSalaryComponent(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal ListOfSalaryComponentCode As String(), ByVal ListOfSalaryComponentName As String())
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"}
        Dim excel As New FileInfo(LinkFileTemplate)
        Using package As New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim intColStart As Integer = 4
            Dim index As Integer = 7
            For i As Integer = 0 To ListOfSalaryComponentCode.Length - 1
                ws.Cells(ColExel(intColStart) + (index - 1).ToString).Value = ListOfSalaryComponentCode(i)
                ws.Cells(ColExel(intColStart) + index.ToString).Value = ListOfSalaryComponentName(i)
                intColStart += 1
            Next
            Dim fi As New FileInfo(LinkFileXuat)
            package.SaveAs(fi)
            System.Diagnostics.Process.Start(LinkFileXuat)
        End Using
    End Sub

    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportCode = "LuongCoDinhGetTemplate" Then
            Dim frm As New frmparaSalaryComponent
            frm.bMonthlyChanging = False
            frm.ShowDialog()
            If frm.bluu = False Then
                Exit Sub
            End If
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.DefaultExt = "xlsx"
            fileChooser.FileName = "NhapLuongCoDinh.xlsx"
            Dim result As DialogResult = fileChooser.ShowDialog()
            fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                LayTemplateSalaryComponent(Application.StartupPath() + "\Teamleate\NhapLuongCoDinh.xlsx", fileChooser.FileName, frm.GetSalaryComponentCode, frm.GetSalaryComponentNamveVn)
            End If
        ElseIf ReportCode = "LuongCoDinhInputTemplate" Then
            NhapTempale()
        End If
    End Sub

    Private Sub Gridex1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub frmLuongCoDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        fromdate.EditValue = Today
        Dim SalaryComponentDt As DataTable = kn.ReadData("select SalaryComponent as Code, Name" + obj.Lan + " as Name from HR_SalaryComponentCategory where isnull(MonthlyChanging,0)=0 order by OrderBy", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(SalaryComponent, SalaryComponentDt)
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        'Search()
    End Sub

    Private Sub cbtodate_CheckedChanged(sender As Object, e As EventArgs) Handles cbtodate.CheckedChanged
        If cbtodate.Checked = True Then
            todate.Enabled = True
            todate.EditValue = Today
        Else
            todate.Enabled = False
            todate.EditValue = Nothing
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "[dbo].[sp_BangLuongCoDinh] '" + CDate(fromdate.EditValue).ToString("yyyy-MM-dd") + "','" + CDate(fromdate.EditValue).ToString("yyyy-MM-dd") + "',3,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles Amount.TextChanged
        tvcn.AmountFormat(Amount)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_SalaryComponent]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub Employee_ID_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F3 Then
            Dim frm As New para_NhanVien
            frm.ShowDialog()
            If frm.Employee_ID <> String.Empty Then
                Employee_ID.Text = frm.Employee_ID
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            If btnSave.Enabled = True Then
                btnSave_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Employee_ID_TextChanged_1(sender As Object, e As EventArgs)
        Search()
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub
End Class