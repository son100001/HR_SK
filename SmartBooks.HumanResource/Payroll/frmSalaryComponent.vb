Imports System.IO
Imports OfficeOpenXml
Imports WindowsControlLibrary

Public Class frmSalaryComponent
    Private Sub frmSalaryComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        Dim SalaryComponentDS As DataTable = kn.ReadData("select SalaryComponent as Code, Name" + obj.Lan + " as Name From HR_SalaryComponentCategory Where MonthlyChanging = 1 Order By OrderBy", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(SalaryComponent, SalaryComponentDS)
        LoadGiaoDienTheoDieuKien()
        tvcn.SearchEmployee(Employee_ID)
        Search()
    End Sub

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
                Dim Employee_ID, SalaryComponent, Amount, Remark As String
                Dim Year, Month As Integer
                Dim tabCheck As DataTable
                While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty And worksheet.Cells("B" + index.ToString).Text.Trim <> String.Empty And worksheet.Cells("C" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = worksheet.Cells("A" + index.ToString).Text.Trim
                    Year = worksheet.Cells("B" + index.ToString).Value
                    Month = worksheet.Cells("C" + index.ToString).Value
                    Remark = worksheet.Cells("D" + index.ToString).Text.Trim
                    For intcol As Integer = intColStart To ColExel.Length - 1
                        If worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim <> String.Empty Then
                            SalaryComponent = worksheet.Cells(ColExel(intcol) + ColConfig.ToString).Text.Trim
                            If Not IsNothing(worksheet.Cells(ColExel(intcol) + index.ToString).Value) Then
                                Amount = worksheet.Cells(ColExel(intcol) + index.ToString).Value.ToString
                            Else
                                Amount = String.Empty
                            End If
                            If Amount <> String.Empty Then
                                tabCheck = kn.ReadData("[dbo].[usp_InsertUpdateHR_SalaryComponentFollowMonth] null,N'" + Employee_ID + "',N'" + SalaryComponent + "','" + Amount + "','" + Year.ToString + "','" + Month.ToString + "',N'" + Remark + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "',N'" + obj.UserName + "'", "table")
                                If Not IsNothing(tabCheck) Then
                                    If tabCheck.Rows(0)("ThongBao") <> "" Then
                                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ", " + tvcn.GetLanguagesTranslated("Employee_ID") + ": " + " " + Employee_ID + ": " + tvcn.GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                End If
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
        If ReportCode = "SalaryComponentGetTemplate" Then
            Dim frm As New frmparaSalaryComponent
            frm.bMonthlyChanging = True
            frm.ShowDialog()
            If frm.bluu = False Then
                Exit Sub
            End If
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.DefaultExt = "xlsx"
            fileChooser.FileName = "NhapLuongTheoThang.xlsx"
            Dim result As DialogResult = fileChooser.ShowDialog()
            fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                LayTemplateSalaryComponent(Application.StartupPath() + "\Teamleate\NhapLuongTheoThang.xlsx", fileChooser.FileName, frm.GetSalaryComponentCode, frm.GetSalaryComponentNamveVn)
            End If
        ElseIf ReportCode = "SalaryComponentInputTemplate" Then
            NhapTempale()
        End If
    End Sub

    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim QR As String = "[dbo].[sp_BangLuongBienDong] '" + Year_.Text + "','" + Month_.Text + "',2,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles Amount.TextChanged
        tvcn.AmountFormat(Amount)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        'Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_SalaryComponentFollowMonth]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub
End Class