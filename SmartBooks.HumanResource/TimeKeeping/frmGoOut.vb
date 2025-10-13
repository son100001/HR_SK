Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base

Public Class frmGoOut
    Dim tabTypeOfGoOut As DataTable

    Private Sub frmGoOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tvcn.ThemDauSaoChoTruongBuocNhap(TableLayoutPanel2, HRFORM_TableName)
        tabTypeOfGoOut = kn.ReadData("select * from udf_GetCategory('TypeOfGoOut','" + obj.Lan + "')", "table")
        tvcn.GetDataOnDropDownCategoryCodeName(LeaveType_ID, "TypeOfGoOut")
        LoadGiaoDienTheoDieuKien()
        ShiftName.Properties.DataSource = kn.ReadData("exec sp_BangCa", "table")
        ShiftName.Properties.DisplayMember = "ShiftSign"
        ShiftName.Properties.ValueMember = "ShiftName"
        ShiftName.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        ShiftName.Properties.NullText = ""
        TimeDate.DateTime = Today
        tvcn.SearchEmployee(Employee_ID)
        ' MessageBox.Show(TimeIn.Properties.MaskSettings.MaskExpression)
        Search()
    End Sub

    Public Overrides Sub AfterViewForm()
        If XtraTabControl1.SelectedTabPage.Name = "General" Then
            If Not IsNothing(GridView1.Columns("TimeOut_")) Then
                GridView1.Columns("TimeOut_").Visible = False
            End If
            If Not IsNothing(GridView1.Columns("TimeIn")) Then
                GridView1.Columns("TimeIn").Visible = False
            End If
        End If
    End Sub

    Private Function NhapFileTemplate() As Boolean
        Dim ofd As New OpenFileDialog
        With ofd
            ' .FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Return False
            End If
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New OfficeOpenXml.ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = 7
                Dim Employee_ID, Remark, LeaveType_ID, UserName, XinRaNgoaiVaoNgayHomSau As String
                Dim TimeDate, TimeOut, TimeIn, InsertDate, OldAccessTime As DateTime
                Dim ojDate, ojTime As Object
                UserName = obj.UserName
                InsertDate = Now
                Dim datamember As String() = {"Employee_ID", "TimeDate", "TimeOut_", "TimeIn", "LeaveType_ID", "Remark", "UserName", "InsertDate"}
                Dim datamember_Value As New ArrayList
                Dim primary As String() = {"Employee_ID", "TimeOut_"}
                Dim primary_Value As New ArrayList
                While worksheet.Cells("B" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = worksheet.Cells("B" + index.ToString).Text.Trim
                    XinRaNgoaiVaoNgayHomSau = worksheet.Cells("H" + index.ToString).Text.Trim
                    ojDate = worksheet.Cells("C" + index.ToString).Value
                    If Not IsNothing(ojDate) Then
                        If tvcn.CheckingBlock("HR_GoOut", ojDate) = True Then
                            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        TimeDate = ojDate
                        ojTime = worksheet.Cells("D" + index.ToString).Value
                        If Not IsNothing(ojTime) Then
                            If ojTime.GetType.ToString = "System.Double" Then
                                TimeOut = DateTime.FromOADate(ojTime)
                            Else
                                TimeOut = CType(ojTime, DateTime)
                            End If
                            If XinRaNgoaiVaoNgayHomSau = "1" Then
                                TimeOut = New DateTime(TimeDate.AddDays(1).Year, TimeDate.AddDays(1).Month, TimeDate.AddDays(1).Day, TimeOut.Hour, TimeOut.Minute, TimeOut.Second)
                            Else
                                TimeOut = New DateTime(TimeDate.Year, TimeDate.Month, TimeDate.Day, TimeOut.Hour, TimeOut.Minute, TimeOut.Second)
                            End If

                            ojTime = worksheet.Cells("E" + index.ToString).Value
                            If Not IsNothing(ojTime) Then
                                If ojTime.GetType.ToString = "System.Double" Then
                                    TimeIn = DateTime.FromOADate(ojTime)
                                Else
                                    TimeIn = CType(ojTime, DateTime)
                                End If
                                If TimeOut.Hour > TimeIn.Hour Then
                                    TimeIn = New DateTime(TimeDate.AddDays(1).Year, TimeDate.AddDays(1).Month, TimeDate.AddDays(1).Day, TimeIn.Hour, TimeIn.Minute, TimeIn.Second)
                                Else
                                    TimeIn = New DateTime(TimeDate.Year, TimeDate.Month, TimeDate.Day, TimeIn.Hour, TimeIn.Minute, TimeIn.Second)
                                End If
                                If XinRaNgoaiVaoNgayHomSau = "1" Then
                                    TimeIn = TimeIn.AddDays(1)
                                End If
                            End If
                            LeaveType_ID = worksheet.Cells("F" + index.ToString).Text.Trim
                            Remark = worksheet.Cells("G" + index.ToString).Text.Trim

                            datamember_Value.Clear()
                            datamember_Value.Add(Employee_ID)
                            datamember_Value.Add(TimeDate)
                            datamember_Value.Add(TimeOut)
                            datamember_Value.Add(TimeIn)
                            datamember_Value.Add(LeaveType_ID)
                            datamember_Value.Add(Remark)
                            datamember_Value.Add(UserName)
                            datamember_Value.Add(InsertDate)

                            primary_Value.Clear()
                            primary_Value.Add(Employee_ID)
                            primary_Value.Add(TimeOut)
                            If tvcn.LuuKhongGhiLog(False, "HR_GoOut", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                                If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + tvcn.GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                                    Return False
                                End If
                            End If
                        End If
                    End If
                    index += 1
                End While
            End Using
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        End If
    End Function

    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportRow("ReportCode") = "GoOutInputTemplate" Then
            NhapFileTemplate()
        End If
    End Sub

    Private Function LayCa(ByVal Employee_ID As String, ByVal timedate As DateTime) As String
        ShiftName.EditValue = String.Empty
        If Employee_ID <> String.Empty Then
            ShiftName.EditValue = String.Empty
            Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_TraVeDangKyCaDuaVaoCaXoay]('" + timedate.ToString("yyyy-MM-dd") + "','" + timedate.ToString("yyyy-MM-dd") + "',null,null,null,null,null,null,N'" + Employee_ID + "')", "table")
            If tab.Rows.Count > 0 Then
                If Not IsDBNull(tab.Rows(0)("ShiftName")) Then
                    Return tab.Rows(0)("ShiftName")
                End If
            End If
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If tvcn.SaveByStore(QuyenHRFORM, HRFORM_TableName, "[dbo].[usp_InsertUpdateHR_GoOut]", TableLayoutPanel2, ErrorProvider1) Then
            Search()
        End If
        Employee_ID.Select()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub Search()
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        Dim fd, td As DateTime
        Dim NgayChuyenDi As DateTime = tvcn.LayNgayChuyenDi(Employee_ID.Text.Trim, obj.PARA_FACTORY_ID, New DateTime(TimeDate.DateTime.Year, TimeDate.DateTime.Month, 2), New DateTime(TimeDate.DateTime.Year, TimeDate.DateTime.Month, 1).AddMonths(1).AddDays(-1))
        fd = New DateTime(TimeDate.DateTime.Year, TimeDate.DateTime.Month, 1)
        If NgayChuyenDi.Year = 1 Then
            td = fd.AddMonths(1).AddDays(-1)
        Else
            td = NgayChuyenDi.AddDays(-1)
        End If
        Dim QR As String = "exec [dbo].[sp_BangPhepXinRaNgoai] '" + fd.ToString("yyyy-MM-dd") + "','" + td.ToString("yyyy-MM-dd") + "',1,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "',N'" + EmID + "'"
        Xem(QR, False, HRFORM_GridControl, HRFORM_Gridview)
        HRFORM_QueryView = QR
    End Sub

    Private Sub TimeDate_EditValueChanged(sender As Object, e As EventArgs) Handles TimeDate.EditValueChanged
        Dim EmID As String
        If Not IsNothing(Employee_ID.EditValue) Then
            EmID = Employee_ID.EditValue.ToString.Trim
        End If
        ShiftName.EditValue = LayCa(EmID, TimeDate.DateTime)
    End Sub

    Private Sub Employee_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Employee_ID.EditValueChanged
        Search()
    End Sub

    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        Gridview_KeyUp(sender, e)
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim CotTimeSpan As TimeSpan
        Dim CotDateTime As DateTime
        If Not IsNothing(GridView1.Columns("TimeOut_")) And Not IsNothing(GridView1.Columns("TimeOut_Edit")) Then
            If e.Column.Name = "colTimeOut_Edit" Then
                CotTimeSpan = GridView1.GetFocusedDataRow().Item("TimeOut_Edit")
                CotDateTime = GridView1.GetFocusedDataRow().Item("TimeOut_")
                GridView1.GetFocusedDataRow().Item("TimeOut_") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
            End If
        End If
        If Not IsNothing(GridView1.Columns("TimeIn")) And Not IsNothing(GridView1.Columns("TimeIn_Edit")) Then
            If e.Column.Name = "colTimeIn_Edit" Then
                CotTimeSpan = GridView1.GetFocusedDataRow().Item("TimeIn_Edit")
                CotDateTime = GridView1.GetFocusedDataRow().Item("TimeIn")
                GridView1.GetFocusedDataRow().Item("TimeIn") = New DateTime(CotDateTime.Year, CotDateTime.Month, CotDateTime.Day, CotTimeSpan.Hours, CotTimeSpan.Minutes, CotTimeSpan.Seconds)
            End If
        End If
    End Sub
End Class