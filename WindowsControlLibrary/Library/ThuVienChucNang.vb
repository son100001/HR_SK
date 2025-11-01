Imports SmartBooks.BusinessLogic
Imports Janus.Windows.GridEX
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports JSON.NET.Framework
Imports VBReport
Imports Excel1 = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.Text
Imports Microsoft.Office.Interop
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Drawing
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinTabControl
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository

Public Class ThuVienChucNang
    Dim kn As New connect(DbSetting.dataPath)
    Private obj As New DbSetting

    Public Function Encode(ByVal strDec As String) As String
        Dim strEnc As String
        Dim bt() As Byte
        ReDim bt(strDec.Length)
        bt = Encoding.Unicode.GetBytes(strDec)
        strEnc = Convert.ToBase64String(bt)
        Return strEnc
    End Function
    Public Function Decode(ByVal strEnc As String) As String
        Dim bt() As Byte
        Dim strDec As String

        bt = Convert.FromBase64String(strEnc)
        strDec = Encoding.Unicode.GetString(bt)
        Return strDec
    End Function
    Public Function FocusGrd(ByVal _Grid As GridView, ByVal _Col As Integer, ByVal _Row As Integer) 'GridEX
        _Grid.SelectCell(_Row, _Grid.Columns.Item(_Col))
        'With _Grid
        '    .Focus()
        '    .Col = _Col
        '    .Row = _Row
        '    '.SelectCurrentCellText()
        'End With
    End Function

    Public Sub LoadYear(ByRef cbo As System.Windows.Forms.ComboBox)
        Dim i As Integer
        For i = 2006 To Date.Now.Year + 1
            cbo.Items.Add(i.ToString)
        Next
        cbo.Text = Date.Now.Year.ToString
    End Sub
    Public Sub LoadMonth(ByRef cbo As System.Windows.Forms.ComboBox)
        Dim i As Integer
        For i = 1 To 12
            cbo.Items.Add(Microsoft.VisualBasic.Right("0" + i.ToString, 2))
        Next
        cbo.Text = IIf(Date.Now.Month < 10, "0", "") + Date.Now.Month.ToString
    End Sub

    Public Function GetFullNameFromEmployeeID(ByVal EmployeeID As String, Optional ByVal Ngay As DateTime = Nothing) As String
        If Ngay.Year = 1 Then
            Ngay = Today
        End If
        If EmployeeID <> String.Empty Then
            Dim tab As DataTable = kn.ReadData("select isnull(Employee_Firstname,'')+' ' + isnull(Employee_LastName,'') as fullname from [dbo].[udf_EmployeeFilter]('VN',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "','" + EmployeeID + "','" + Ngay.ToString("yyyy-MM-dd") + "')", "table")
            If tab.Rows.Count > 0 Then
                GetFullNameFromEmployeeID = tab.Rows(0)("fullname")
            Else
                GetFullNameFromEmployeeID = String.Empty
            End If
        Else
            GetFullNameFromEmployeeID = String.Empty
        End If
        Return GetFullNameFromEmployeeID
    End Function

    Public Function CreateObjectInstance(ByVal objectName As String) As Object
        ' Creates and returns an instance of any object in the assembly by its type name.

        Dim obj As Object

        Try
            If objectName.LastIndexOf(".") = -1 Then
                'Appends the root namespace if not specified.
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj

    End Function
    Public Function CreateForm(ByVal formName As String) As Form
        ' Return the instance of the form by specifying its name.
        Return DirectCast(CreateObjectInstance(formName), Form)
    End Function

    Public Function GetAppPath() As String
        Dim f As New IO.DirectoryInfo(Application.ExecutablePath)
        Return f.Parent.FullName
    End Function

    Public Function LayTenTuFileNgonNgu(ByVal parameter As String, Optional ByVal frm As Form = Nothing) As String
        Dim LanFile As String
        LanFile = GetAppPath() & "\lang\lang." + DbSetting.Lan + ".js"
        Dim tReader As TextReader = New StreamReader(LanFile)
        Dim reader As JsonReader = New JsonReader(tReader)
        Dim str_Return As String
        Dim key As String = ""
        Dim value As String = ""
        While reader.Read
            If reader.TokenType <> JsonToken.StartObject And reader.TokenType <> JsonToken.EndObject Then
                If reader.TokenType = JsonToken.PropertyName Then
                    key = reader.Value.ToString
                Else
                    If IsNothing(frm) = True Then
                        If Split(key, ".")(0) = "General" Then
                            If CStr(Split(key, ".").GetValue(Split(key, ".").Length - 1)).ToUpper = parameter.ToUpper Then
                                str_Return = reader.Value.ToString
                                Exit While
                            End If
                        End If
                    Else
                        If key.IndexOf("." + frm.Name + ".") >= 0 Then
                            If CStr(Split(key, ".").GetValue(Split(key, ".").Length - 1)).ToUpper = parameter.ToUpper Then
                                str_Return = reader.Value.ToString
                                Exit While
                            End If
                        End If
                    End If
                End If
            End If
        End While
        reader.Close()
        tReader.Close()
        Dim tReader1 As TextReader = New StreamReader(LanFile)
        Dim reader1 As JsonReader = New JsonReader(tReader1)
        If str_Return = String.Empty Then
            While reader1.Read
                If reader1.TokenType <> JsonToken.StartObject And reader1.TokenType <> JsonToken.EndObject Then
                    If reader1.TokenType = JsonToken.PropertyName Then
                        key = reader1.Value.ToString
                    Else
                        If Split(key, ".")(0) = "General" Then
                            If CStr(Split(key, ".").GetValue(Split(key, ".").Length - 1)).ToUpper = parameter.ToUpper Then
                                str_Return = reader1.Value.ToString
                                Exit While
                            End If
                        End If
                    End If
                End If
            End While
        End If
        If str_Return = String.Empty Then
            str_Return = parameter
        End If
        reader1.Close()
        tReader1.Close()
        Return str_Return
    End Function
    Public Function DichNgonNgu(ByVal PathOfLanFile As String, ByVal ListOfcode As String()) As String()
        Dim Result() As String = New String(ListOfcode.Length) {}
        Dim tReader As TextReader = New StreamReader(PathOfLanFile)
        Dim reader As JsonReader = New JsonReader(tReader)
        Dim key As String = ""
        Dim i = 0, j As Integer
        Dim keys As String()
        While reader.Read
            If reader.TokenType <> JsonToken.StartObject And reader.TokenType <> JsonToken.EndObject Then
                If reader.TokenType = JsonToken.PropertyName Then
                    key = reader.Value.ToString
                Else
                    keys = key.Split(".")
                    For j = 0 To ListOfcode.Length - 1
                        If ListOfcode(j).ToUpper = keys(keys.Length - 1).ToUpper Then
                            If IsNothing(Result(j)) Then
                                Result(j) = reader.Value.ToString()
                                i += 1
                            End If
                        End If
                    Next
                    If i = ListOfcode.Length Then
                        Exit While
                    End If
                End If
            End If
        End While
        reader.Close()
        tReader.Close()
        Return Result
    End Function
    Public Function LayTenTuFileNgonNgu(ByVal parameter As String, ByVal LanFile As String) As String
        Dim tReader As TextReader = New StreamReader(LanFile)
        Dim reader As JsonReader = New JsonReader(tReader)
        Dim str_Return As String
        Dim key As String = ""
        Dim value As String = ""
        While reader.Read
            If reader.TokenType <> JsonToken.StartObject And reader.TokenType <> JsonToken.EndObject Then
                If reader.TokenType = JsonToken.PropertyName Then
                    key = reader.Value.ToString
                Else
                    If Split(key, ".")(0) = "General" Then
                        If CStr(Split(key, ".").GetValue(Split(key, ".").Length - 1)).ToUpper = parameter.ToUpper Then
                            str_Return = reader.Value.ToString
                            Exit While
                        End If
                    End If
                End If
            End If
        End While
        reader.Close()
        tReader.Close()
        If str_Return = String.Empty Then
            Return parameter
        End If
        Return str_Return
    End Function

    Public Sub DichNgonNguForm(ByVal frmDich As Form, ByVal frmNgonNgu As Form)
        Dim LanFile As String
        LanFile = GetAppPath() & "\lang\lang." + DbSetting.Lan + ".js"
        Dim ListOfCode As String
        For Each ct As Control In frmDich.Controls
            If ct.GetType.Name.ToUpper = "LABEL" Then
                If ct.Text <> "*" Then
                    ListOfCode += ct.Name.Remove(0, 3) + ","
                End If
            ElseIf ct.GetType.Name.ToUpper = "CHECKBOX" Or ct.GetType.Name.ToUpper = "RADIOBUTTON" Then
                If ct.Text <> "" Then
                    ListOfCode += ct.Name + ","
                End If
            End If
        Next
        Dim ListOfLAN As String() = DichNgonNgu(LanFile, ListOfCode.Remove(ListOfCode.Length - 1).Split(","))
        Dim i As Integer = 0
        For Each ct As Control In frmDich.Controls
            If ct.GetType.Name.ToUpper = "LABEL" Then
                If ct.Text <> "*" Then
                    If ListOfLAN(i) <> String.Empty Then
                        ct.Text = ListOfLAN(i)
                    End If
                    i += 1
                End If
            ElseIf ct.GetType.Name.ToUpper = "CHECKBOX" Or ct.GetType.Name.ToUpper = "RADIOBUTTON" Then
                If ct.Text <> "" Then
                    If ListOfLAN(i) <> String.Empty Then
                        ct.Text = ListOfLAN(i)
                    End If
                    i += 1
                End If
            End If
        Next
    End Sub

    Public Function AddNewOrEdit(ByVal AddNew As Boolean, ByVal CurrentForm As Form, ByVal TableName As String, ByVal grid As GridView, ByVal MaQuyen As String, Optional ByVal InputFormName As String = Nothing) As Boolean '
        Dim quyen As String = KiemTraQuyen(MaQuyen)
        If quyen = "View" Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        Dim frm As Object
        If IsNothing(InputFormName) Then
            frm = CreateForm(CurrentForm.Name + "_Nhap") 'Create form
        Else
            frm = CreateForm(InputFormName)
        End If
        DichNgonNguForm(frm, CurrentForm)
        frm.BeforeLoad()
        'frm.Text = CurrentForm.Text
        frm.HRFORM_TableName = TableName
        frm.ReportRow = grid.GetFocusedDataRow 'frm.gridRow = grid.
        Dim i As Integer
        Dim ListOfDatamember As String
        For i = 0 To grid.Columns.Count - 1
            ListOfDatamember += grid.Columns(i).FieldName.ToUpper() + ","
        Next
        frm.ListOfDatamemberOfGrid = ListOfDatamember.Remove(ListOfDatamember.Length - 1).Split(",")
        frm.AddNew = AddNew
        If AddNew = True Or (AddNew <> True And Not IsNothing(grid.GetFocusedRow)) Then
            frm.ShowDialog()
            Return frm.bluu
        End If
        Return False
    End Function

    Public Function KiemTraQuyen(ByVal MaChucNang As String) As String
        Try
            Dim BangQuyen As New UserPermission
            Dim dtKiemTraQuyen As DataTable = BangQuyen.Userpermission(DbSetting.UserName, MaChucNang)
            Return dtKiemTraQuyen.Rows(0)("Quyen")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Enum ObjectType
        StringType = 0
        IntType = 1
        DoubleType = 2
        DecimalType = 3
        DateType = 4
        BoolType = 5
        TimeType = 6
        DateTimeType = 7
    End Enum
    Public Function CheckExcelNull(ByRef Xls As XlsReport, ByVal cell As String,
     Optional ByVal ObjectType As ObjectType = ObjectType.StringType, Optional ByVal _defaultVal As String = "NULL") As String
        CheckExcelNull = _defaultVal
        Dim tempData As String = ""
        Try
            tempData = Xls.Cell(cell).Value
            If (ObjectType = ObjectType.BoolType) Then
                If (tempData <> "" And tempData <> String.Empty) Then
                    CheckExcelNull = "1"
                Else
                    CheckExcelNull = "0"
                End If
            ElseIf ObjectType = ObjectType.DecimalType Or ObjectType = ObjectType.DoubleType Then
                If (tempData <> "" And tempData <> String.Empty) Then
                    If ObjectType = ObjectType.DoubleType Then
                        CheckExcelNull = Double.Parse(tempData)
                    Else
                        CheckExcelNull = Decimal.Parse(tempData)
                    End If
                Else
                    CheckExcelNull = "0"
                End If
            ElseIf ObjectType = ObjectType.TimeType Then
                If (tempData <> "" And tempData <> String.Empty) Then
                    Dim templ As String() = tempData.Trim.Split(" ")
                    Dim templ1 As String
                    If (templ.Length = 3) Then ''Dinh dang dd/mm/yyyy HH:mm tt
                        templ1 = templ(1)
                    ElseIf templ.Length = 2 Then ''Dinh dang dd/mm/yyyy HH:mm
                        templ1 = templ(1)
                    ElseIf templ.Length = 1 Then ''Dinh dang HH:mm
                        templ1 = templ(0)
                    End If

                    If (templ1.IndexOf(":") > 1) Then
                        Dim tempTime As String() = tempData.Split(":")
                        Dim _hour As String = tempTime(0)
                        Dim _minute As String = tempTime(1)
                        CheckExcelNull = _hour + ":" + _minute
                    Else
                        Dim dateNumber As Double = Decimal.Parse(templ1)
                        Dim _result As Date
                        _result = DateTime.FromOADate(dateNumber)
                        CheckExcelNull = String.Format("'{0}'", _result.ToString("HH:mm"))
                    End If
                Else
                    CheckExcelNull = ""
                End If
            ElseIf ObjectType = ObjectType.DateType Then
                If (tempData <> "" And tempData <> String.Empty) Then
                    If (tempData.IndexOf("/") >= 1) Or (tempData.IndexOf("-") >= 1) Then ' Or tempData.Split("/").Length > 0 Then
                        Dim tempDate As String()
                        If tempData.IndexOf("-") > 1 Then
                            tempDate = tempData.Split("-")
                        Else
                            tempDate = tempData.Split("/")
                        End If

                        If (tempDate.Length = 3) Then
                            Dim _year As Integer = Integer.Parse(tempDate(2))
                            ''' KiemTraKieuDuLieuNgay
                            If (_year < 20) Then
                                _year += 2000
                            Else
                                _year += 1900
                            End If
                            Try
                                Dim _dateTime As Date
                                If Integer.Parse(tempDate(0)) > 1900 Then
                                    _dateTime = New Date(Integer.Parse(tempDate(0)), Integer.Parse(tempDate(1)), Integer.Parse(tempDate(2)))
                                Else
                                    _dateTime = New Date(Integer.Parse(tempDate(2)), Integer.Parse(tempDate(1)), Integer.Parse(tempDate(0)))
                                End If

                                CheckExcelNull = String.Format("'{0}'", _dateTime.ToString("yyyy-MM-dd"))
                            Catch ex As Exception

                            End Try

                        End If
                    Else
                        Dim dateNumber As Double = Double.Parse(tempData)
                        Dim _result As Date
                        If (dateNumber < 3000) Then
                            _result = New Date(dateNumber, 1, 1)
                        Else
                            _result = DateTime.FromOADate(dateNumber)
                        End If
                        CheckExcelNull = String.Format("'{0}'", _result.ToString("yyyy-MM-dd"))
                    End If
                Else
                    CheckExcelNull = "Null"
                End If
            ElseIf ObjectType = ObjectType.DateTimeType Then
                If (tempData <> "" And tempData <> String.Empty) Then
                    Dim templ As String() = tempData.Trim.Split(" ")
                    Dim templ1 As String
                    If (templ.Length = 3) Then ''Dinh dang dd/mm/yyyy HH:mm tt
                        templ1 = templ(1)
                    ElseIf templ.Length = 2 Then ''Dinh dang dd/mm/yyyy HH:mm
                        templ1 = templ(1)
                    ElseIf templ.Length = 1 Then ''Dinh dang HH:mm
                        templ1 = templ(0)
                    End If

                    If (templ1.IndexOf(":") > 1) Then
                        Dim tempTime As String() = tempData.Split(":")
                        Dim _hour As String = tempTime(0)
                        Dim _minute As String = tempTime(1)
                        CheckExcelNull = _hour + ":" + _minute
                    Else
                        Dim dateNumber As Double = Decimal.Parse(templ1)
                        Dim _result As Date
                        _result = DateTime.FromOADate(dateNumber)
                        CheckExcelNull = String.Format("'{0}'", _result.ToString("yyyy-MM-dd HH:mm:ss"))
                    End If
                Else
                    CheckExcelNull = ""
                End If

            ElseIf ObjectType = ObjectType.StringType Then
                If (tempData <> "" And tempData <> String.Empty) Then
                    CheckExcelNull = String.Format("N'{0}'", tempData.Trim().Replace("'", ""))
                Else
                    CheckExcelNull = "Null"
                End If
            End If
        Catch ex As Exception

        End Try
    End Function
#Region "GET TEMPLATE EXCEL"
    Public Sub LayTemplateNhapCongNgoaiLe(ByVal PathOfTemplateFile As String, ByVal PathOfExportFile As String, ByVal isOpen As Boolean)
        If PathOfTemplateFile <> String.Empty Then
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim Xls As New XlsReport
            Dim urlTemplate As String = PathOfTemplateFile
            Dim urlOut As String = PathOfExportFile
            Xls.FileName = urlTemplate
            Xls.Start.File()
            Xls.Page.Begin("Sheet1", "1")
            Xls.Page.Name = "Sheet1"
            Dim intColStart As Integer = 3
            Dim index As Integer = 7
            Dim tabLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "table")
            For Each r As DataRow In tabLoaiCong.Rows
                Xls.Cell(ColExel(intColStart) + (index - 1).ToString).Value = r("MaCong")
                Xls.Cell(ColExel(intColStart) + index.ToString).Value = r("NameVN")
                intColStart += 1
            Next
            Xls.Page.End()
            Xls.Out.File(urlOut)
            If isOpen = True Then
                Dim ps As New ProcessStartInfo
                ps.UseShellExecute = True
                ps.FileName = urlOut
                Process.Start(ps)
            End If
        End If
    End Sub

    Public Sub LayTemplateTheoThoiGian(ByVal PathOfExportFile As String, ByVal Grid As GridView, ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal isOpen As Boolean) 'GridEX
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim excel As New FileInfo(Application.StartupPath() + "\Teamleate\TempNhapTheoThoiGian.xlsx")
        Using package = New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim index, rowConfig, rowHeader, colStartDate As Integer
            colStartDate = ws.Cells("A1").Value
            rowHeader = ws.Cells("A2").Value
            rowConfig = ws.Cells("A3").Value
            index = ws.Cells("A4").Value
            'Dịch header
            Dim Config As String
            Dim i As Integer
            For i = 1 To colStartDate - 1
                If ws.Cells(ColExel(i) + rowConfig.ToString).Value <> String.Empty Then
                    Config += ws.Cells(ColExel(i) + rowConfig.ToString).Value + ","
                End If
            Next
            Dim ListOfConfig As String() = Config.Remove(Config.Length - 1, 1).Split(",")
            Dim LanFile As String
            LanFile = GetAppPath() & "\lang\lang." + DbSetting.Lan + ".js"
            Dim ListOfLAN As String() = DichNgonNgu(LanFile, ListOfConfig)
            For i = 0 To ListOfLAN.Length - 1
                ws.Cells(ColExel(i + 1) + rowHeader.ToString).Value = ListOfLAN(i)
            Next
            'Ghi dữ liệu cấu hình thời gian
            Dim dnext As DateTime = Fromdate
            i = colStartDate
            While dnext <= Todate
                ws.Cells(ColExel(i) + rowConfig.ToString).Value = dnext
                ws.Cells(ColExel(i) + rowHeader.ToString).Value = dnext.Day
                dnext = dnext.AddDays(1)
                i += 1
            End While
            'Ghi dữ liệu nhân viên nếu có
            Dim stt As Integer = 1
            For numberRow As Integer = 0 To Grid.SelectedRowsCount - 1
                'For Each r As GridEXRow In Grid.GetCheckedRows
                Dim r As DataRow = Grid.GetDataRow(Grid.GetSelectedRows(numberRow))
                For i = 0 To ListOfConfig.Length - 1
                    If ListOfConfig(i).ToUpper = "NO" Then
                        ws.Cells(ColExel(i + 1) + index.ToString).Value = stt
                    Else
                        ws.Cells(ColExel(i + 1) + index.ToString).Value = r.Item(ListOfConfig(i)).ToString() 'ws.Cells(ColExel(i + 1) + index.ToString).Value = r.Item(ListOfConfig(i)).ToString()
                    End If
                Next
                stt += 1
                index += 1
            Next
            Dim fi As New FileInfo(PathOfExportFile)
            package.SaveAs(fi)
            System.Diagnostics.Process.Start(PathOfExportFile)
        End Using
    End Sub

    Public Sub LayTemplateEPPlus(ByVal TableName As String, ByVal FirtsRow As Integer, ByVal FileTemplate As String, Optional ByVal FRM As Form = Nothing)
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.FileName = FRM.Text
        Dim result As DialogResult = fileChooser.ShowDialog()
        fileChooser.CheckFileExists = False
        If result = DialogResult.OK Then
            Dim index As Integer = FirtsRow
            Dim i As Integer = 0
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim tab As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
            Using newFile = New FileStream(Application.StartupPath() + "\Teamleate\" + FileTemplate, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
                Using package As New ExcelPackage(newFile)
                    Dim ws As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1") 'or any other name for the WorkSheet 
                    Dim TitleRange As String = "A3:F3"
                    ws.Cells(TitleRange).Style.Font.Bold = True
                    ws.Cells(TitleRange).Merge = True
                    ws.Cells(TitleRange).Style.Font.Size = 14
                    ws.Cells(TitleRange).Value = FRM.Text
                    For Each r As DataRow In tab.Rows
                        If IsDBNull(r("IdentityName")) And CStr(r("COLUMN_NAME")).ToUpper <> "USERNAME" And CStr(r("COLUMN_NAME")).ToUpper <> "INSERTBY" And CStr(r("COLUMN_NAME")).ToUpper <> "INSERTDATE" And CStr(r("COLUMN_NAME")).ToUpper <> "UPDATEDATE" And CStr(r("COLUMN_NAME")).ToUpper <> "UPDATEUSERNAME" Then
                            If Not IsDBNull(r("PrimaryName")) Then
                                ws.SetValue(index - 5, i + 1, r("COLUMN_NAME"))
                            End If
                            ws.SetValue(index - 4, i + 1, r("COLUMN_NAME"))
                            ws.SetValue(index, i + 1, LayTenTuFileNgonNgu(r("COLUMN_NAME"), FRM))
                            If r("IS_NULLABLE") = "NO" Then
                                ws.Cells(index, i + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                                ws.Cells(index, i + 1).Style.Fill.BackgroundColor.SetColor(Color.Red)
                            End If
                            i += 1
                        End If
                    Next
                    Dim headerRange As String = "A" + index.ToString + ":" + ColExel(i - 1) + index.ToString
                    ws.Cells(headerRange).Style.Border.Top.Style = ExcelBorderStyle.Thin
                    ws.Cells(headerRange).Style.Border.Right.Style = ExcelBorderStyle.Thin
                    ws.Cells(headerRange).Style.Border.Left.Style = ExcelBorderStyle.Thin
                    ws.Cells(headerRange).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    ws.Cells(headerRange).Style.Font.Bold = True
                    ws.Cells(headerRange).AutoFitColumns()
                    ws.Row(index - 4).Hidden = True
                    ws.Row(index - 5).Hidden = True
                    'Here you can do some formatting like making the first column a number column, autosize the cells, ....  
                    package.SaveAs(New FileInfo(fileChooser.FileName.Replace(".xlsx", "") + ".xlsx"))
                    System.Diagnostics.Process.Start(fileChooser.FileName.Replace(".xlsx", "") + ".xlsx")
                End Using
            End Using
        End If
    End Sub
    Public Sub LayTemplate(ByVal TableName As String, ByVal FirtsRow As Integer, ByVal FileTemplate As String, Optional ByVal FRM As Form = Nothing)
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.FileName = FileTemplate
        Dim result As DialogResult = fileChooser.ShowDialog()
        fileChooser.CheckFileExists = False
        If result = DialogResult.OK Then
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim Xls As New XlsReport
            Dim index As Integer = FirtsRow
            Dim urlTemplate As String = Application.StartupPath() + "\TempImport\" + FileTemplate
            Dim urlOut As String = fileChooser.FileName()
            Xls.FileName = urlTemplate
            Xls.Start.File()
            Xls.Page.Begin("Sheet1", "1")
            Xls.Page.Name = "Sheet1"
            Dim i As Integer = 0
            Dim tab As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
            For Each r As DataRow In tab.Rows
                If IsDBNull(r("IdentityName")) And CStr(r("COLUMN_NAME")).ToUpper <> "USERNAME" And CStr(r("COLUMN_NAME")).ToUpper <> "INSERTBY" And CStr(r("COLUMN_NAME")).ToUpper <> "INSERTDATE" Then
                    If Not IsDBNull(r("PrimaryName")) Then
                        Xls.Cell(ColExel(i) + (index - 2).ToString).Value = r("COLUMN_NAME")
                    End If
                    Xls.Cell(ColExel(i) + (index - 1).ToString).Value = r("COLUMN_NAME")
                    Xls.Cell(ColExel(i) + index.ToString).Value = LayTenTuFileNgonNgu(r("COLUMN_NAME"), FRM)
                    i += 1
                End If
            Next
            Xls.Page.End()
            Xls.Out.File(urlOut)
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = urlOut
            Process.Start(ps)
        End If
    End Sub

    Public Sub LayTemplateTheoTable(ByVal TableName As String, ByVal FirtsRow As Integer, ByVal PathOfTemplateFile As String, ByVal PathOfExportFile As String, ByVal LanFile As String, ByVal isOpen As Boolean)
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim Xls As New XlsReport
        Dim index As Integer = FirtsRow
        Dim urlTemplate As String = PathOfTemplateFile
        Dim urlOut As String = PathOfExportFile
        Xls.FileName = urlTemplate
        Xls.Start.File()
        Xls.Page.Begin("Sheet1", "1")
        Xls.Page.Name = "Sheet1"
        Dim i As Integer = 0
        Dim tab As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
        For Each r As DataRow In tab.Rows
            If IsDBNull(r("IdentityName")) And CStr(r("COLUMN_NAME")).ToUpper <> "USERNAME" And CStr(r("COLUMN_NAME")).ToUpper <> "INSERTBY" And CStr(r("COLUMN_NAME")).ToUpper <> "INSERTDATE" Then
                If Not IsDBNull(r("PrimaryName")) Then
                    Xls.Cell(ColExel(i) + (index - 2).ToString).Value = r("COLUMN_NAME")
                End If
                Xls.Cell(ColExel(i) + (index - 1).ToString).Value = r("COLUMN_NAME")
                Xls.Cell(ColExel(i) + index.ToString).Value = LayTenTuFileNgonNgu(r("COLUMN_NAME"), LanFile)
                i += 1
            End If
        Next
        Xls.Page.End()
        Xls.Out.File(urlOut)
        If isOpen = True Then
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = urlOut
            Process.Start(ps)
        End If
    End Sub

    Public Sub LayTemplateEPPlus(ByVal pathFile As String)
        Dim ss As String() = Split(pathFile, "\")
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.DefaultExt = "xlsx"
        fileChooser.FileName = ss(ss.Length - 1)
        Dim result As DialogResult = fileChooser.ShowDialog()
        fileChooser.CheckFileExists = False
        If result = DialogResult.OK Then
            Using fs As FileStream = File.OpenRead(pathFile)
                Using package As New ExcelPackage(fs)
                    Dim fi As New FileInfo(fileChooser.FileName)
                    package.SaveAs(fi)
                    System.Diagnostics.Process.Start(fileChooser.FileName)
                End Using
            End Using
        End If
    End Sub
    Public Sub LayTemplate(ByVal pathFile As String)
        Dim ss As String() = Split(pathFile, "\")
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.DefaultExt = "xls"
        fileChooser.FileName = ss(ss.Length - 1)
        Dim result As DialogResult = fileChooser.ShowDialog()
        fileChooser.CheckFileExists = False
        If result = DialogResult.OK Then
            Dim Xls As New XlsReport
            Dim index As Integer = 8
            Dim urlTemplate As String = pathFile
            Dim urlOut As String = fileChooser.FileName()
            Xls.FileName = urlTemplate
            Xls.Start.File()
            Xls.Page.Begin("Sheet1", "1")
            Xls.Page.Name = "Sheet1"
            Xls.Page.End()
            Xls.Out.File(urlOut)
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = urlOut
            Process.Start(ps)
        End If
    End Sub
#End Region
#Region "TABLE INFORMATION"
    Public Function GetColumns_ISNOTNULLABLE_OfTable(ByVal TableName As String) As String()
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim arrayNULLABLE As New ArrayList
        For Each rowData As DataRow In tabTableInfor.Rows
            If IsDBNull(rowData("IdentityName")) And rowData("IS_NULLABLE") = "NO" Then
                arrayNULLABLE.Add(rowData("COLUMN_NAME"))
            End If
        Next
        If TableName.ToUpper = "HR_TimeKeeping_Data".ToUpper Then
            arrayNULLABLE.Add("Employee_ID")
        End If
        Return CType(arrayNULLABLE.ToArray(GetType(String)), String())
    End Function
    Public Function GetKeyFromTable(ByVal TableName As String) As String()
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim arrayPrimary As New ArrayList
        For Each rowData As DataRow In tabTableInfor.Rows
            If Not IsDBNull(rowData("PrimaryName")) Then
                arrayPrimary.Add(rowData("COLUMN_NAME"))
            End If
        Next
        Return CType(arrayPrimary.ToArray(GetType(String)), String())
    End Function

    Public Function GetIdentityNameOfTable(ByVal TableName As String) As String
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        For Each rowData As DataRow In tabTableInfor.Rows
            If Not IsDBNull(rowData("IdentityName")) Then
                Return rowData("COLUMN_NAME")
            End If
        Next
        Return String.Empty
    End Function

    Public Function GetDatamemberFromTable(ByVal TableName As String, Optional ByVal ListOfExcludeField As String() = Nothing) As String()
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim arrayDatamember As New ArrayList
        For Each rowData As DataRow In tabTableInfor.Rows
            If IsDBNull(rowData("IdentityName")) Then
                If IsNothing(ListOfExcludeField) Then
                    arrayDatamember.Add(rowData("COLUMN_NAME"))
                Else
                    If ListOfExcludeField.IndexOf(ListOfExcludeField, rowData("COLUMN_NAME")) < 0 Then
                        arrayDatamember.Add(rowData("COLUMN_NAME"))
                    End If
                End If
            End If
        Next
        Return CType(arrayDatamember.ToArray(GetType(String)), String())
    End Function
    Public Function GetTypeOfColumnFromTable(ByVal TableName As String, Optional ByVal ListOfExcludeField As String() = Nothing) As String()
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim arrayDatamember As New ArrayList
        For Each rowData As DataRow In tabTableInfor.Rows
            If IsDBNull(rowData("IdentityName")) Then
                If IsNothing(ListOfExcludeField) Then
                    arrayDatamember.Add(rowData("DATA_TYPE"))
                Else
                    If ListOfExcludeField.IndexOf(ListOfExcludeField, rowData("COLUMN_NAME")) < 0 Then
                        arrayDatamember.Add(rowData("DATA_TYPE"))
                    End If
                End If
            End If
        Next
        Return CType(arrayDatamember.ToArray(GetType(String)), String())
    End Function

    Public Function GetInformationOfSQLTable(ByVal TableName As String) As DataTable
        Return kn.ReadData("exec sp_GetAllInformationInTable N'" + TableName + "'", "table")
    End Function
    Public Function GetColumnNameOfSQLTable(ByVal TableName As String) As DataTable
        Return kn.ReadData("exec sp_GetColumnNameInTable N'" + TableName + "'", "table")
    End Function
#End Region
#Region "SAVE DATA TO TABLE"
    Public Function LuuHoacXoaTuForm(ByVal tableName As String, ByRef ctlControl As Control, ByVal bLuu As Boolean, ByVal Quyen As String) As Boolean
        If Quyen = "View" Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If bLuu = True Then
            If MessageBox.Show(GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return False
            End If
        End If
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + tableName + "'", "table")
        Dim arrayDatamember As New ArrayList
        Dim arrayDatamember_V As New ArrayList
        Dim arrayPrimary As New ArrayList
        Dim arrayPrimary_V As New ArrayList
        Dim oj As New Object
        Dim bIdentity As Boolean
        Dim bIdentityIsKey As Boolean
        'TÌM MẢNG GIÁ TRỊ VÀ PRIMARY
        For Each r As DataRow In tabTableInfor.Rows
            If Not IsDBNull(r("IdentityName")) Then
                bIdentity = True
            Else
                arrayDatamember.Add(r("COLUMN_NAME"))
                bIdentity = False
            End If
            If CStr(r("COLUMN_NAME")).ToUpper = "INSERTDATE" Then
                arrayDatamember_V.Add(Now)
            ElseIf (CStr(r("COLUMN_NAME")).ToUpper = "USERNAME" And tableName.ToUpper <> "USER") Or CStr(r("COLUMN_NAME")).ToUpper = "INSERTBY" Then
                arrayDatamember_V.Add(obj.UserName)
            Else
                If GetDataMemberAndPrimaryFromControl(ctlControl, r, arrayDatamember, arrayDatamember_V, arrayPrimary, arrayPrimary_V, bIdentity, bIdentityIsKey, True, False) = False Then
                    Return False
                End If
            End If
        Next
        'THỰC HIỆN SAVE
        If bLuu = True Then
            If LuuKhongGhiLog(False, tableName, CType(arrayPrimary.ToArray(GetType(String)), String()), arrayPrimary_V.ToArray(), CType(arrayDatamember.ToArray(GetType(String)), String()), arrayDatamember_V.ToArray()) = True Then
                MessageBox.Show(GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show(GetLanguagesTranslated("Popup.Luukhongthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If XoaKhongGhiLog(tableName, CType(arrayPrimary.ToArray(GetType(String)), String()), arrayPrimary_V.ToArray()) = True Then
                MessageBox.Show(GetLanguagesTranslated("Popup.Xoathanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                MessageBox.Show(GetLanguagesTranslated("Popup.Xoakhongthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        Return False
    End Function
    Public Function LuuTuDataTable(ByVal TableName As String, ByVal Table As DataTable, ByVal Quyen As String, Optional ByVal InsertDate As String = "InsertDate", Optional ByVal UserName As String = "UserName") As Boolean
        If Quyen.ToUpper = "VIEW" Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim arrayDatamember As New ArrayList
        Dim bIdentity As Boolean
        Dim tabChange As DataTable
        Dim rowData As DataRow()
        Dim bInsertAndUpdateIsSame As Boolean
        If tabTableInfor.Rows.Count = 1 Then
            bInsertAndUpdateIsSame = True
        End If
        tabChange = Table.GetChanges()
        Dim rowUser() As DataRow = tabTableInfor.Select("COLUMN_NAME='InsertBy'")
        If rowUser.Count > 0 Then
            UserName = "InsertBy"
        End If
        If Not IsNothing(tabChange) Then
            For Each row As DataRow In tabChange.Rows
                If TableName.ToUpper = "HR_TimeKeeping_Data".ToUpper Then
                    row("AccessTime") = New DateTime(CDate(row("AccessDate")).Year, CDate(row("AccessDate")).Month, CDate(row("AccessDate")).Day, CDate(row("AccessTime")).Hour, CDate(row("AccessTime")).Minute, CDate(row("AccessTime")).Second)
                    row("InsertSource") = "NhapTay"
                End If
                row(InsertDate) = Now
                row(UserName) = obj.UserName
            Next
            tabChange.AcceptChanges()
            For Each col As DataColumn In tabChange.Columns
                rowData = tabTableInfor.Select("COLUMN_NAME='" + col.ColumnName + "'")
                If rowData.Length > 0 Then
                    If IsDBNull(rowData(0)("IdentityName")) Then
                        arrayDatamember.Add(col.ColumnName)
                    End If
                End If
            Next
            If LuuTuDataTable(bInsertAndUpdateIsSame, tabChange, TableName, CType(arrayDatamember.ToArray(GetType(String)), String()), "", "abc") = True Then
                MessageBox.Show(GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Table.AcceptChanges()
                Return True
            End If
        End If
        Return False
    End Function
    Public Function LuuTuDataTable(ByVal NameOfStore As String, ByVal TableName As String, ByVal Table As DataTable, ByVal Quyen As String) As Boolean
        If Quyen.ToUpper = "VIEW" Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim bIdentity, bCoLoi, isPrimaryKeyNull As Boolean
        Dim tabChange, tabCheck As DataTable
        Dim rowData As DataRow()
        Dim row As DataRow
        Dim arrayPrimary As New ArrayList
        Dim SaveQuery, CheckChangedQuery As String
        Dim inext As Integer
        Dim dtDate As DateTime
        tabChange = Table.GetChanges()
        If Not IsNothing(tabChange) Then
            'Lấy khóa
            For Each col As DataColumn In Table.Columns
                rowData = tabTableInfor.Select("COLUMN_NAME='" + col.ColumnName + "'")
                If rowData.Length > 0 Then
                    If Not IsDBNull(rowData(0)("PrimaryName")) Then
                        arrayPrimary.Add(col.ColumnName)
                    End If
                End If
            Next
            For Each r As DataRow In Table.Rows
                CheckChangedQuery = String.Empty
                SaveQuery = String.Empty
                isPrimaryKeyNull = False
                For inext = 0 To arrayPrimary.Count - 1
                    If Not IsDBNull(r(arrayPrimary(inext))) Then
                        CheckChangedQuery += arrayPrimary(inext) + "="
                        If Table.Columns(arrayPrimary(inext)).DataType.ToString = "System.DateTime" Then
                            CheckChangedQuery += "'" + CDate(r(arrayPrimary(inext))).ToString("yyyy-MM-dd HH:mm:ss") + "' and "
                        ElseIf Table.Columns(arrayPrimary(inext)).DataType.ToString = "System.TimeSpan" Then
                            CheckChangedQuery += "'" + r(arrayPrimary(inext)).ToString() + "' and "
                        Else
                            CheckChangedQuery += "'" + CStr(r(arrayPrimary(inext))).Trim.Replace("'", "''") + "' and "
                        End If
                    Else
                        isPrimaryKeyNull = True
                    End If
                Next
                If isPrimaryKeyNull = False Or (isPrimaryKeyNull = True And TableName.ToUpper = "SmartBooks_Employee".ToUpper) Then
                    If CheckChangedQuery <> String.Empty Then
                        CheckChangedQuery = CheckChangedQuery.Remove(CheckChangedQuery.Length - 5)
                    End If
                    If tabChange.Select(CheckChangedQuery).Length >= 1 Then
                        SaveQuery = "exec " + NameOfStore + " "
                        For Each row In tabTableInfor.Rows
                            If Table.Columns.Contains(row("COLUMN_NAME")) = False Then
                                SaveQuery += "null,"
                            Else
                                If CStr(row("COLUMN_NAME")).ToUpper = "USERNAME" Then
                                    SaveQuery += "N'" + obj.UserName + "',"
                                Else
                                    If Not IsDBNull(r(row("COLUMN_NAME"))) Then
                                        If Table.Columns(row("COLUMN_NAME")).DataType.ToString = "System.DateTime" Then
                                            dtDate = CDate(r(row("COLUMN_NAME")))
                                            If dtDate.Year = 1 Then
                                                dtDate = New DateTime(1900, 1, 1, dtDate.Hour, dtDate.Minute, dtDate.Second)
                                            End If
                                            SaveQuery += "'" + dtDate.ToString("yyyy-MM-dd HH:mm:ss") + "',"
                                        ElseIf Table.Columns(row("COLUMN_NAME")).DataType.ToString = "System.String" Then
                                            SaveQuery += "N'" + CStr(r(row("COLUMN_NAME"))).Replace("'", "''") + "',"
                                        ElseIf Table.Columns(row("COLUMN_NAME")).DataType.ToString = "System.Boolean" Then
                                            If r(row("COLUMN_NAME")) = True Then
                                                SaveQuery += "'1',"
                                            Else
                                                SaveQuery += "'0',"
                                            End If
                                        Else
                                            SaveQuery += "'" + r(row("COLUMN_NAME")).ToString() + "',"
                                        End If
                                    Else
                                        SaveQuery += "null,"
                                    End If
                                End If
                            End If
                        Next
                        SaveQuery = SaveQuery.Remove(SaveQuery.Length - 1)
                        tabCheck = kn.ReadData(SaveQuery, "Table")
                        If Not IsNothing(tabCheck) Then
                            For Each col As DataColumn In tabCheck.Columns
                                If col.ColumnName.ToUpper <> "ThongBao".ToUpper Then
                                    If Not IsDBNull(tabCheck.Rows(0)(col.ColumnName)) Then
                                        r(col.ColumnName) = tabCheck.Rows(0)(col.ColumnName)
                                    End If
                                End If
                            Next
                            If Table.Columns.Contains("KiemTraDuLieuNhap") Then
                                r("KiemTraDuLieuNhap") = tabCheck.Rows(0)("ThongBao")
                                If tabCheck.Rows(0)("ThongBao") <> "" Then
                                    bCoLoi = True
                                End If
                            ElseIf tabCheck.Rows(0)("ThongBao") <> "" Then
                                If MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi") + " " + r("Employee_ID") + " " + GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")) + ". " + GetLanguagesTranslated("Popup.Bancomuontieptucthuchienkhong"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.No Then
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            'For Each row As DataRow In Table.Rows
            '    If TableName.ToUpper = "HR_TimeKeeping_Data".ToUpper Then
            '        row("AccessTime") = New DateTime(CDate(row("AccessDate")).Year, CDate(row("AccessDate")).Month, CDate(row("AccessDate")).Day, CDate(row("AccessTime")).Hour, CDate(row("AccessTime")).Minute, CDate(row("AccessTime")).Second)
            '        row("InsertSource") = "NhapTay"
            '    End If
            'Next

            Table.AcceptChanges()
            If bCoLoi = True Then
                MessageBox.Show(GetLanguagesTranslated("Popup.Luuketthucnhungcomotsobanghibiloibanvuilongkiemtralai"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(GetLanguagesTranslated("Popup.Luuketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True
        End If
        Return False
    End Function
    Public Function LuuTuDataTable(ByVal bInsertAndUpdateIsSame As Boolean, ByRef Table As DataTable, ByVal TableName As String, ByVal DataMember() As String, ByVal placeCall As String, ByVal NameOfFieldDate_CheckWithTerminate_LongTemLeave As String, Optional ByVal NameofFieldEmployee As String = "") As Boolean
        Dim DataMember_Value As New ArrayList
        Dim Primary_Value As New ArrayList
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
        Dim rowData As DataRow()
        Dim bIdentity As Boolean
        Dim arrayPrimary As New ArrayList
        Dim Primary() As String
        For Each row As DataRow In Table.Rows
            arrayPrimary.Clear()
            bIdentity = False
            For Each col As DataColumn In Table.Columns
                rowData = tabTableInfor.Select("COLUMN_NAME='" + col.ColumnName + "'")
                If rowData.Length > 0 Then
                    If Not IsDBNull(rowData(0)("IdentityName")) Then
                        If Not IsDBNull(row(col.ColumnName)) Then
                            bIdentity = True
                            arrayPrimary.Clear()
                            arrayPrimary.Add(col.ColumnName)
                        End If
                    Else
                        If Not IsDBNull(rowData(0)("PrimaryName")) And bIdentity = False Then
                            If TableName.ToUpper() = "HR_TimeKeeping_Data".ToUpper And col.ColumnName.ToUpper() = "CardNumber".ToUpper Then
                                arrayPrimary.Add("Employee_ID")
                            Else
                                arrayPrimary.Add(col.ColumnName)
                            End If
                        End If
                    End If
                End If
            Next
            Primary = CType(arrayPrimary.ToArray(GetType(String)), String())
            DataMember_Value.Clear()
            Primary_Value.Clear()
            For Each S As String In DataMember
                S = S.Replace("[", "").Replace("]", "")
                If Not IsDBNull(row(S)) Then
                    If Table.Columns(S).DataType.ToString = "System.DateTime" Then
                        If CDate(row(S)).Year = 1 Then
                            DataMember_Value.Add(CDate(row(S)).AddYears(1900))
                        Else
                            DataMember_Value.Add(row(S))
                        End If
                    Else
                        DataMember_Value.Add(row(S))
                    End If
                Else
                    If Table.Columns(S).DataType.ToString = "System.DateTime" Then
                        DataMember_Value.Add(New DateTime(1900, 1, 1))
                    ElseIf Table.Columns(S).DataType.ToString = "System.Boolean" Then
                        DataMember_Value.Add(False)
                    Else
                        DataMember_Value.Add("null")
                    End If
                End If
            Next
            For Each S As String In Primary
                S = S.Replace("[", "").Replace("]", "")
                Primary_Value.Add(row(S))
            Next
            For i As Integer = 0 To DataMember.Length - 1
                DataMember(i) = DataMember(i)
            Next
            For i As Integer = 0 To Primary.Length - 1
                Primary(i) = Primary(i)
            Next
            If NameofFieldEmployee = "" Then
                If LuuKhongGhiLog(bInsertAndUpdateIsSame, TableName, Primary, Primary_Value.ToArray, DataMember, DataMember_Value.ToArray()) = False Then
                    Dim result As Integer = MessageBox.Show(GetLanguagesTranslated("Popup.Banghihientaikhongluuduocbancomuontieptucluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.No Then
                        Return False
                    End If
                End If
            Else
                If LuuKhongGhiLog(bInsertAndUpdateIsSame, TableName, Primary, Primary_Value.ToArray, DataMember, DataMember_Value.ToArray()) = False Then
                    Dim result As Integer = MessageBox.Show(GetLanguagesTranslated("Popup.Banghihientaikhongluuduocbancomuontieptucluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.No Then
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function
    Public Function LuuVaGhiLog(ByVal bInsertAndUpdateIsSame As Boolean, ByVal TableName As String, ByVal Primary() As String, ByVal Primary_Value As Object(), ByVal DataMember() As String, ByVal DataMember_Value() As Object, ByVal dt_Terminate_LongTermLeave As DateTime, Optional ByVal Employee_ID As String = "") As Boolean
        Dim KeySumary, GhiLaiGiaTriGoc, KiemTraGhiLaiGiaTriGoc, NhapLogUpdate, NhapLogUpdate1 As String
        Dim TruongInsert, TruongGiaTri, GiaTri, sqlUpdate, sqlInsert, DieuKienUpdate, str_sql As String
        Dim dt_AccessDate, dt_AccessTime As DateTime
        NhapLogUpdate = "INSERT INTO SmartBooks_LOG ([Datetime],[UserName],KeySumary,TableName,[Form],[Action]) values(GETDATE(),N'" + obj.UserName + "',"
        GhiLaiGiaTriGoc = "declare @Log nvarchar(max) select @Log = " + "N'{"
        For i As Integer = 0 To DataMember.Length - 1
            TruongInsert = TruongInsert + DataMember(i) + ","
            If DataMember_Value(i).GetType.ToString = "System.DateTime" Then
                GhiLaiGiaTriGoc += """" + DataMember(i) + """:""'+" + "Convert(nvarchar(50), isnull(" + DataMember(i) + ",'1900-1-1'), 20)" + "+'"","
            ElseIf DataMember_Value(i).GetType.ToString = "System.Boolean" Then
                GhiLaiGiaTriGoc += """" + DataMember(i) + """:""'+" + "Cast(isnull(" + DataMember(i) + ",'0') as nvarchar(50))" + "+'"","
            ElseIf DataMember_Value(i).GetType.ToString = "System.Decimal" Or DataMember_Value(i).GetType.ToString = "System.Int32" Or DataMember_Value(i).GetType.ToString = "System.Double" Then
                GhiLaiGiaTriGoc += """" + DataMember(i) + """:""'+" + "Cast(isnull(" + DataMember(i) + ",'" + Integer.MaxValue.ToString + "') as nvarchar(50))" + "+'"","
            Else
                GhiLaiGiaTriGoc += """" + DataMember(i) + """:""'+REPLACE(isnull(" + DataMember(i) + ",''),',','######')+'"","
            End If
        Next
        If GhiLaiGiaTriGoc <> String.Empty Then
            GhiLaiGiaTriGoc = GhiLaiGiaTriGoc.Remove(GhiLaiGiaTriGoc.Length - 2, 2) + """' from [" + TableName + "] where "
        End If
        TruongInsert = TruongInsert.Remove(TruongInsert.Length - 1, 1)
        For i As Integer = 0 To DataMember_Value.Length - 1
            If DataMember_Value(i).GetType.ToString = "System.String" Then
                If CStr(DataMember_Value(i)).Trim.ToUpper <> "NULL" Then
                    If CStr(DataMember_Value(i)).Trim = "" Then
                        GiaTri = "null,"
                        NhapLogUpdate1 += DataMember(i) + """:""" + "" + ""","""
                    Else
                        GiaTri = "N'" + CStr(DataMember_Value(i)).Replace("'", "''") + "',"
                        NhapLogUpdate1 += DataMember(i) + """:""" + CType(DataMember_Value(i), String).Replace("'", "''").Replace(",", "######") + ""","""
                    End If
                Else
                    NhapLogUpdate1 += DataMember(i) + """:""" + "" + ""","""
                    GiaTri = "null,"
                End If
            ElseIf DataMember_Value(i).GetType.ToString = "System.Boolean" Then
                If DataMember_Value(i) = True Then
                    GiaTri = "1,"
                    NhapLogUpdate1 += DataMember(i) + """:""" + "1" + ""","""
                Else
                    GiaTri = "0,"
                    NhapLogUpdate1 += DataMember(i) + """:""" + "0" + ""","""
                End If
            ElseIf DataMember_Value(i).GetType.ToString = "System.DateTime" Then
                If CType(DataMember_Value(i), DateTime).Year = 1900 Or CType(DataMember_Value(i), DateTime).Year = 1 Or CType(DataMember_Value(i), DateTime).Year = 1753 Then
                    GiaTri = "null,"
                Else
                    GiaTri = "'" + CType(DataMember_Value(i), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',"
                End If
                NhapLogUpdate1 += DataMember(i) + """:""" + CType(DataMember_Value(i), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + ""","""
            Else
                If IsDBNull(DataMember_Value(i)) Then
                    GiaTri = "null,"
                    NhapLogUpdate1 += DataMember(i) + """:""" + "" + ""","""
                Else
                    GiaTri = "'" + CStr(DataMember_Value(i)) + "',"
                    NhapLogUpdate1 += DataMember(i) + """:""" + CStr(DataMember_Value(i)) + ""","""
                End If
            End If
            TruongGiaTri += GiaTri
            If bInsertAndUpdateIsSame = False Then
                If Primary.IndexOf(Primary, DataMember(i)) < 0 Then
                    sqlUpdate += DataMember(i) + "=" + GiaTri
                End If
            Else
                sqlUpdate += DataMember(i) + "=" + GiaTri
            End If
        Next
        For i As Integer = 0 To Primary_Value.Length - 1
            If Primary_Value(i).GetType.ToString = "System.String" Then
                If CStr(Primary_Value(i)).ToUpper <> "NULL" Then
                    GiaTri = "N'" + CType(Primary_Value(i), String).Replace("'", "''").Replace(",", "######") + "',"
                Else
                    NhapLogUpdate1 += CStr(Primary_Value(i)).Replace("'", "''") + """:""" + "" + ""","""
                    GiaTri = "null,"
                End If
            ElseIf Primary_Value(i).GetType.ToString = "System.Boolean" Then
                If Primary_Value(i) = True Then
                    GiaTri = "1,"
                Else
                    GiaTri = "0,"
                End If
            ElseIf Primary_Value(i).GetType.ToString = "System.DateTime" Then
                GiaTri = "'" + CType((Primary_Value(i)), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',"
            ElseIf Primary_Value(i).GetType.ToString = "System.DBNull" Then
                GiaTri = "null,"
            Else
                GiaTri = "'" + CStr(Primary_Value(i)).Replace("'", "''") + "',"
            End If
            If GiaTri.ToUpper = "NULL," Then
                DieuKienUpdate += Primary(i) + " is " + GiaTri.Replace(",", " and ")
            Else
                DieuKienUpdate += Primary(i) + "=" + GiaTri.Replace(",", " and ")
            End If
            KeySumary += GiaTri.Replace("N'", "").Replace("'", "").Replace(",", "").Replace(" 0:0:0", "") + "_"
        Next

        sqlUpdate = sqlUpdate.Remove(sqlUpdate.Length - 1, 1)
        KeySumary = KeySumary.Remove(KeySumary.Length - 1, 1)
        DieuKienUpdate = DieuKienUpdate.Remove(DieuKienUpdate.Length - 5, 5)
        NhapLogUpdate += "N'" + KeySumary + "',N'" + TableName + "',null,N'{""" + NhapLogUpdate1
        GhiLaiGiaTriGoc += DieuKienUpdate
        NhapLogUpdate += "User"":""" + obj.UserName + """,""TimeAction"":""'+CONVERT(nvarchar(50), GETDATE(), 20)+'"",""KeySumary"":""" + KeySumary + """,""TypeEdit"":""EDIT"",""FunctionID"":""" + TableName + """,""TypeRecord"":""Edit""}')"
        KiemTraGhiLaiGiaTriGoc = "IF NOT EXISTS(SELECT * FROM [dbo].[SmartBooks_LOG] WHERE TableName=N'" + TableName + "' and KeySumary=N'" + KeySumary + "') BEGIN " &
        "INSERT INTO SmartBooks_LOG ([Datetime],[UserName],KeySumary,TableName,[Form],[Action]) values(GETDATE(),N'" + obj.UserName + "',N'" + KeySumary + "',N'" + TableName + "',null,@Log+',""User"":""" + obj.UserName + """,""TimeAction"":""'+CONVERT(nvarchar(50), GETDATE(), 20)+'"",""KeySumary"":""" + KeySumary + """,""TypeEdit"":""EDIT"",""FunctionID"":""" + TableName + """,""TypeRecord"":""Original""}') END "
        TruongGiaTri = TruongGiaTri.Remove(TruongGiaTri.Length - 1, 1)
        'Kiểm tra có đang làm việc ở công ty không
        If Employee_ID <> "" Then
            Dim NgayNhap As String = dt_Terminate_LongTermLeave.ToString("yyyy-MM-dd")
            str_sql = "IF NOT EXISTS(SELECT [Employee_ID] FROM [dbo].[HR_EmployeeRegisMaternityLeave] WHERE Employee_ID = N'" + Employee_ID + "' AND ('" + NgayNhap + "' BETWEEN [Fromdate] AND (case when [ToDate] is null then [NgayDuKienQuayLai] else [ToDate] end))) " &
               "AND EXISTS(SELECT Employee_ID FROM SmartBooks_Employee WHERE Employee_ID = N'" + Employee_ID + "' AND StartedDate<= '" + NgayNhap + "' AND (TernimationDate is null or TernimationDate> '" + NgayNhap + "')) " &
               "BEGIN "
        End If
        str_sql += "IF EXISTS(SELECT * FROM [dbo].[" + TableName + "] WHERE " + DieuKienUpdate + ") " &
        "BEGIN " &
        GhiLaiGiaTriGoc + " " &
        KiemTraGhiLaiGiaTriGoc + " " &
        NhapLogUpdate + " " &
        "UPDATE [dbo].[" + TableName + "] set " + sqlUpdate + " where " + DieuKienUpdate + " END " &
        "ELSE BEGIN " + "INSERT INTO [" + TableName + "] (" + TruongInsert + ") values(" + TruongGiaTri + ") END"
        If Employee_ID <> "" Then
            str_sql += " END "
        End If
        If kn.SaveData(str_sql) Then
            Return True
        End If
        Return False
    End Function
    Public Function LuuKhongGhiLog(ByVal bInsertAndUpdateIsSame As Boolean, ByVal TableName As String, ByVal Primary() As String, ByVal Primary_Value As Object(), ByVal DataMember() As String, ByVal DataMember_Value() As Object) As Boolean
        Dim TruongInsert, TruongGiaTri, GiaTri, sqlUpdate, sqlInsert, DieuKienUpdate, str_sql As String
        Dim dt_AccessDate, dt_AccessTime As DateTime
        Dim ibug As Integer
        For i As Integer = 0 To DataMember.Length - 1
            TruongInsert = TruongInsert + "[" + DataMember(i) + "],"
        Next
        TruongInsert = TruongInsert.Remove(TruongInsert.Length - 1, 1)
        For i As Integer = 0 To DataMember_Value.Length - 1
            If IsNothing(DataMember_Value(i)) Then
                GiaTri = "null,"
            Else
                If DataMember_Value(i).GetType.ToString = "System.String" Then
                    If CStr(DataMember_Value(i)).Trim.ToUpper <> "NULL" Then
                        If CStr(DataMember_Value(i)).Trim = "" Then
                            GiaTri = "null,"
                        Else
                            GiaTri = "N'" + CStr(DataMember_Value(i)).Replace("'", "''") + "',"
                        End If
                    Else
                        GiaTri = "null,"
                    End If
                ElseIf DataMember_Value(i).GetType.ToString = "System.Boolean" Then
                    If DataMember_Value(i) = True Then
                        GiaTri = "1,"
                    Else
                        GiaTri = "0,"
                    End If
                ElseIf DataMember_Value(i).GetType.ToString = "System.DateTime" Then
                    If CType(DataMember_Value(i), DateTime).Year = 1900 Or CType(DataMember_Value(i), DateTime).Year = 1 Or CType(DataMember_Value(i), DateTime).Year = 1753 Then
                        GiaTri = "null,"
                    Else
                        GiaTri = "'" + CType(DataMember_Value(i), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',"
                    End If
                Else
                    If IsDBNull(DataMember_Value(i)) Then
                        GiaTri = "null,"
                    Else
                        GiaTri = "'" + CStr(DataMember_Value(i)) + "',"
                    End If
                End If
            End If
            TruongGiaTri += GiaTri
            If DataMember(i).ToUpper <> "InsertSource".ToUpper Then
                If bInsertAndUpdateIsSame = False Then
                    If Primary.IndexOf(Primary, DataMember(i)) < 0 Then
                        sqlUpdate += "[" + DataMember(i) + "]=" + GiaTri
                    End If
                Else
                    sqlUpdate += "[" + DataMember(i) + "]=" + GiaTri
                End If
            End If
        Next
        For i As Integer = 0 To Primary_Value.Length - 1
            If Primary_Value(i).GetType.ToString = "System.String" Then
                If CStr(Primary_Value(i)).ToUpper <> "NULL" Then
                    GiaTri = "N'" + CType(Primary_Value(i), String).Replace("'", "''").Replace(",", "######") + "',"
                Else
                    GiaTri = "null,"
                End If
            ElseIf Primary_Value(i).GetType.ToString = "System.Boolean" Then
                If Primary_Value(i) = True Then
                    GiaTri = "1,"
                Else
                    GiaTri = "0,"
                End If
            ElseIf Primary_Value(i).GetType.ToString = "System.DateTime" Then
                GiaTri = "'" + CType(Primary_Value(i), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',"
            ElseIf Primary_Value(i).GetType.ToString = "System.DBNull" Then
                GiaTri = "null,"
            Else
                GiaTri = "'" + CStr(Primary_Value(i)) + "',"
            End If
            If GiaTri.ToUpper = "NULL," Then
                DieuKienUpdate += "[" + Primary(i) + "] is " + GiaTri.Replace(",", " and ")
            Else
                DieuKienUpdate += "[" + Primary(i) + "]=" + GiaTri.Replace(",", " and ")
            End If
        Next
        sqlUpdate = sqlUpdate.Remove(sqlUpdate.Length - 1, 1)
        If IsNothing(DieuKienUpdate) Then
            Return False
        End If
        DieuKienUpdate = DieuKienUpdate.Remove(DieuKienUpdate.Length - 5, 5)
        TruongGiaTri = TruongGiaTri.Remove(TruongGiaTri.Length - 1, 1)
        'kiểm tra khóa
        If TableName.ToUpper = "HR_WTDaily".ToUpper Then
            For i = 0 To DataMember.Length - 1
                If DataMember(i).ToUpper = "NGAY" Then
                    If CheckingBlock(TableName, DataMember_Value(i)) = True Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End If
            Next
        ElseIf TableName.ToUpper = "HR_TimeKeeping_Data".ToUpper Then
            For i = 0 To DataMember.Length - 1
                If DataMember(i).ToUpper = "ACCESSDATE" Then
                    If CheckingBlock(TableName, DataMember_Value(i)) = True Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End If
            Next
        ElseIf TableName.ToUpper = "HR_EmpRegisLeave".ToUpper Then
            For i = 0 To DataMember.Length - 1
                If DataMember(i).ToUpper = "DATELEAVE" Then
                    If CheckingBlock(TableName, DataMember_Value(i)) = True Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End If
            Next
        ElseIf TableName.ToUpper = "HR_EmployeeRegisMaternityLeave".ToUpper Then
            For i = 0 To DataMember.Length - 1
                If DataMember(i).ToUpper = "FROMDATE" Then
                    If CheckingBlock(TableName, DataMember_Value(i)) = True Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Dulieudabikhoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End If
            Next
        End If
        'query
        str_sql += "IF EXISTS(SELECT * FROM [dbo].[" + TableName + "] WHERE " + DieuKienUpdate + ") " &
        "BEGIN " &
        "UPDATE [dbo].[" + TableName + "] set " + sqlUpdate + " where " + DieuKienUpdate + " END " &
        "ELSE BEGIN " + "INSERT INTO [" + TableName + "] (" + TruongInsert + ") values(" + TruongGiaTri + ") END"
        'Kiểm tra khóa
        If TableName.ToUpper = "SmartBooks_Salary".ToUpper Then
            str_sql = "IF NOT EXISTS(SELECT * FROM [dbo].[" + TableName + "] WHERE " + DieuKienUpdate + " AND trangthai=1) " &
                        "BEGIN " + str_sql + " END"
        End If
        GhiNoiDungVaoFileDebug(GetAppPath() & "\LOG\Debug.txt", str_sql)
        If kn.SaveData(str_sql) Then
            Return True
        Else
            Return False
        End If
        Return False
    End Function
    Public Function SaveByStore(ByVal Quyen As String, ByVal TableName As String, ByVal NameOfStore As String, ByVal ControlContainAllOfValue As Control, ByVal ErrorP As ErrorProvider) As Boolean

        If Quyen = "View" Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If CheckErrorProvider(ControlContainAllOfValue, ErrorP, GetColumns_ISNOTNULLABLE_OfTable(TableName)) = False Then
            Return False
        End If
        If MessageBox.Show(GetLanguagesTranslated("Popup.Bancothucsumuonluu"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TableName + "'", "table")
            Dim arrayDatamember As New ArrayList
            Dim arrayDatamember_V As New ArrayList
            Dim arrayPrimary As New ArrayList
            Dim arrayPrimary_V As New ArrayList
            Dim oj As New Object
            Dim strParameterOfStore As String
            Dim bIdentity As Boolean
            Dim bIdentityIsKey As Boolean
            'TÌM MẢNG GIÁ TRỊ VÀ PRIMARY
            For Each r As DataRow In tabTableInfor.Rows
                If Not IsDBNull(r("IdentityName")) Then
                    arrayDatamember_V.Add("null")
                End If
                If CStr(r("COLUMN_NAME")).ToUpper = "INSERTDATE" Then
                    arrayDatamember_V.Add("'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'")
                ElseIf (CStr(r("COLUMN_NAME")).ToUpper = "USERNAME" And TableName.ToUpper <> "USER") Or CStr(r("COLUMN_NAME")).ToUpper = "INSERTBY" Then
                    arrayDatamember_V.Add("N'" + obj.UserName + "'")
                Else
                    If GetDataMemberAndPrimaryFromControl(ControlContainAllOfValue, r, arrayDatamember, arrayDatamember_V, arrayPrimary, arrayPrimary_V, bIdentity, bIdentityIsKey, True, True) = False Then
                        Return False
                    End If
                End If
            Next
            For Each s As String In arrayDatamember_V
                strParameterOfStore = strParameterOfStore + s + ","
            Next
            strParameterOfStore = strParameterOfStore.Remove(strParameterOfStore.Length - 1, 1)
            Dim tabCheck As DataTable
            tabCheck = kn.ReadData("exec " + NameOfStore + " " + strParameterOfStore, "table")

            If Not IsNothing(tabCheck) Then
                If tabCheck.Rows(0)("ThongBao") <> "" Then
                    MessageBox.Show(GetLanguagesTranslated("Popup." + tabCheck.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Else
                Return False
            End If
            MessageBox.Show(GetLanguagesTranslated("Popup.Luuthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "DELETE FROM TABLE"
    Public Function XoaKhongGhiLog(ByVal TableName As String, ByVal Primary() As String, ByVal Primary_Value As Object()) As Boolean
        Dim GiaTri, DieuKienXoa, str_sql As String
        For i As Integer = 0 To Primary_Value.Length - 1
            If Primary_Value(i).GetType.ToString = "System.String" Then
                If CStr(Primary_Value(i)).ToUpper <> "NULL" Then
                    GiaTri = "N'" + CType(Primary_Value(i), String).Replace("'", "''").Replace(",", "######") + "',"
                Else
                    GiaTri = "null,"
                End If
            ElseIf Primary_Value(i).GetType.ToString = "System.Boolean" Then
                If Primary_Value(i) = True Then
                    GiaTri = "1,"
                Else
                    GiaTri = "0,"
                End If
            ElseIf Primary_Value(i).GetType.ToString = "System.DateTime" Then
                GiaTri = "'" + CType(Primary_Value(i), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "',"
            ElseIf Primary_Value(i).GetType.ToString = "System.DBNull" Then
                GiaTri = "null,"
            Else
                GiaTri = "'" + CStr(Primary_Value(i)) + "',"
            End If
            If GiaTri.ToUpper = "NULL," Then
                DieuKienXoa += Primary(i) + " is " + GiaTri.Replace(",", " and ")
            Else
                DieuKienXoa += Primary(i) + "=" + GiaTri.Replace(",", " and ")
            End If
        Next
        DieuKienXoa = DieuKienXoa.Remove(DieuKienXoa.Length - 5, 5)
        str_sql = "delete from " + TableName + " where " + DieuKienXoa
        If kn.SaveData(str_sql) Then
            Return True
        End If
        Return False
    End Function
    'Public Function XoaDongLuaChonTrenGrid(ByVal grid As GridEX, ByVal TenBang As String, ByVal Quyen As String, Optional ByVal DeleteStore As String = "") As Boolean 'GridView
    '    Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TenBang + "'", "table")
    '    If DeleteStore = "" Then
    '        Dim arrayPrimary As New ArrayList
    '        Dim bIdentity As Boolean
    '        For Each rowData As DataRow In tabTableInfor.Rows
    '            If Not IsDBNull(rowData("IdentityName")) Then
    '                If grid.RootTable.Columns.Contains(rowData("COLUMN_NAME")) Then 'If not isnothing(grid.Columns(rowData("COLUMN_NAME"))) then
    '                    bIdentity = True
    '                    arrayPrimary.Clear()
    '                    arrayPrimary.Add(rowData("COLUMN_NAME"))
    '                End If
    '            Else
    '                If Not IsDBNull(rowData("PrimaryName")) And bIdentity = False Then
    '                    arrayPrimary.Add(rowData("COLUMN_NAME"))
    '                End If
    '            End If
    '        Next
    '        If XoaDongLuaChonTrenGrid(grid, TenBang, CType(arrayPrimary.ToArray(GetType(String)), String()), Quyen) = False Then
    '            Return False
    '        End If
    '    Else
    '        Dim DeleteStoreParameter As New ArrayList
    '        If TenBang.ToUpper = "HR_TimeKeeping_Data".ToUpper Or TenBang.ToUpper = "HR_GoOut".ToUpper Then
    '            DeleteStoreParameter.Add("ID")
    '        Else
    '            For Each rowData As DataRow In tabTableInfor.Rows
    '                If Not IsDBNull(rowData("PrimaryName")) Then
    '                    DeleteStoreParameter.Add(rowData("COLUMN_NAME"))
    '                End If
    '            Next
    '        End If
    '        For Each field As String In CType(DeleteStoreParameter.ToArray(GetType(String)), String())
    '            If grid.RootTable.Columns.Contains(field) = False Then 'If isnothing(grid.Columns(field)) then
    '                MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Return False
    '            End If
    '        Next
    '        Dim DeleteQuery As String
    '        Dim tabCheckDelete As DataTable
    '        For Each gridrow As GridEXRow In grid.GetCheckedRows 'For numberRow As Integer = 0 To HRFORM_Gridview.SelectedRowsCount
    '            'Dim gridrow As DataRow = Grid.GetDataRow(Gridview1.GetSelectedRows(numberRow))
    '            DeleteQuery = "exec " + DeleteStore + " "
    '            For Each field As String In CType(DeleteStoreParameter.ToArray(GetType(String)), String())
    '                If Not IsDBNull(gridrow.Cells(field).Value) Then 'If isDBNull(gridrow.Item(field)) Then
    '                    If grid.RootTable.Columns(field).Type.ToString = "System.String" Then 'If grid.Columns(field).ColumnType.ToString() = "System.String" then
    '                        DeleteQuery += "N'" + gridrow.Cells(field).Value + "'," 'gridrow.Item(field).ToString()
    '                    ElseIf grid.RootTable.Columns(field).Type.ToString = "System.DateTime" Then 'If grid.Columns(field).ColumnType.ToString() = "System.String" then
    '                        DeleteQuery += "'" + CType(gridrow.Cells(field).Value, DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'," 'Ctype(gridrow.Item(field), Datetime).ToString("yyyy-MM-dd HH:mm:ss")
    '                    Else
    '                        DeleteQuery += "'" + CStr(gridrow.Cells(field).Value) + "'," 'gridrow.Item(field).ToString()
    '                    End If
    '                Else
    '                    DeleteQuery += "null,"
    '                End If
    '            Next
    '            tabCheckDelete = kn.ReadData(DeleteQuery + "'" + obj.UserName + "'", "table")
    '            If tabCheckDelete.Rows.Count > 0 Then
    '                If tabCheckDelete.Rows(0)("ThongBao") <> "" Then
    '                    MessageBox.Show(GetLanguagesTranslated("Popup." + tabCheckDelete.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Return False
    '                End If
    '            End If
    '        Next
    '        MessageBox.Show(GetLanguagesTranslated("Popup.Xoathanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    Return True
    'End Function
    Public Function XoaDongLuaChonTrenGrid(ByVal grid As GridView, ByVal TenBang As String, ByVal Quyen As String, Optional ByVal DeleteStore As String = "") As Boolean 'GridView
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + TenBang + "'", "table")
        If DeleteStore = "" Then
            Dim arrayPrimary As New ArrayList
            Dim bIdentity As Boolean
            For Each rowData As DataRow In tabTableInfor.Rows
                If Not IsDBNull(rowData("IdentityName")) Then
                    If Not IsNothing(grid.Columns(rowData("COLUMN_NAME"))) Then 'If not isnothing(grid.Columns(rowData("COLUMN_NAME"))) then
                        bIdentity = True
                        arrayPrimary.Clear()
                        arrayPrimary.Add(rowData("COLUMN_NAME"))
                    End If
                Else
                    If Not IsDBNull(rowData("PrimaryName")) And bIdentity = False Then
                        arrayPrimary.Add(rowData("COLUMN_NAME"))
                    End If
                End If
            Next
            If XoaDongLuaChonTrenGrid(grid, TenBang, CType(arrayPrimary.ToArray(GetType(String)), String()), Quyen) = False Then
                Return False
            End If
        Else
            Dim DeleteStoreParameter As New ArrayList
            If TenBang.ToUpper = "HR_TimeKeeping_Data".ToUpper Or TenBang.ToUpper = "HR_GoOut".ToUpper Then
                DeleteStoreParameter.Add("ID")
            Else
                For Each rowData As DataRow In tabTableInfor.Rows
                    If Not IsDBNull(rowData("PrimaryName")) Then
                        DeleteStoreParameter.Add(rowData("COLUMN_NAME"))
                    End If
                Next
            End If
            For Each field As String In CType(DeleteStoreParameter.ToArray(GetType(String)), String())
                If IsNothing(grid.Columns(field)) Then 'If isnothing(grid.Columns(field)) then
                    MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Next
            Dim DeleteQuery As String
            Dim tabCheckDelete As DataTable
            For numberRow As Integer = 0 To grid.SelectedRowsCount - 1 'For numberRow As Integer = 0 To HRFORM_Gridview.SelectedRowsCount
                Dim gridrow As DataRow = grid.GetDataRow(grid.GetSelectedRows(numberRow))
                DeleteQuery = "exec " + DeleteStore + " "
                For Each field As String In CType(DeleteStoreParameter.ToArray(GetType(String)), String())
                    If Not IsDBNull(gridrow.Item(field)) Then 'If isDBNull(gridrow.Item(field)) Then
                        If grid.Columns(field).ColumnType.ToString() = "System.String" Then 'If grid.Columns(field).ColumnType.ToString() = "System.String" then
                            DeleteQuery += "N'" + gridrow.Item(field).ToString() + "'," 'gridrow.Item(field).ToString()
                        ElseIf grid.Columns(field).ColumnType.ToString() = "System.DateTime" Then 'If grid.Columns(field).ColumnType.ToString() = "System.String" then
                            DeleteQuery += "'" + CType(gridrow.Item(field), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'," 'Ctype(gridrow.Item(field), Datetime).ToString("yyyy-MM-dd HH:mm:ss")
                        Else
                            DeleteQuery += "'" + CStr(gridrow.Item(field).ToString()) + "'," 'gridrow.Item(field).ToString()
                        End If
                    Else
                        DeleteQuery += "null,"
                    End If
                Next
                tabCheckDelete = kn.ReadData(DeleteQuery + "'" + obj.UserName + "'", "table")
                If tabCheckDelete.Rows.Count > 0 Then
                    If tabCheckDelete.Rows(0)("ThongBao") <> "" Then
                        MessageBox.Show(GetLanguagesTranslated("Popup." + tabCheckDelete.Rows(0)("ThongBao")), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If
            Next
            MessageBox.Show(GetLanguagesTranslated("Popup.Xoathanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return True
    End Function
    Public Function XoaDongLuaChonTrenGrid(ByVal grid As GridView, ByVal TenBang As String, ByVal Khoa As String(), ByVal Quyen As String, Optional ByVal DataMember() As String = Nothing, Optional ByVal isHienThiThongBao As Boolean = True) As Boolean 'Gridview
        If isHienThiThongBao = True Then
            If Quyen = "View" Then
                MessageBox.Show(GetLanguagesTranslated("Popup.Bankhongcoquyenthaydoi"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If grid.SelectedRowsCount <= 0 Then 'If grid.SelectedRowsCount <= 0
                MessageBox.Show(GetLanguagesTranslated("Popup.Banvuilongchondongcanxoa"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If
        Dim result As Integer = DialogResult.Yes
        If isHienThiThongBao = True Then
            result = MessageBox.Show(GetLanguagesTranslated("Popup.Bancothucsumuonxoa"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        If result = DialogResult.No Then
            Return False
        End If
        Dim bCheckKeyHopLe As Boolean = True
        Dim str_SQL_Ma, str_sql, str_GhiLaiGiaTriXoa, str_DieuKienXoa, KeySumary As String
        For numberRow As Integer = 0 To grid.SelectedRowsCount - 1
            Dim gr As DataRow = grid.GetDataRow(grid.GetSelectedRows(numberRow))
            'For Each gr As GridEXRow In grid.GetCheckedRows
            KeySumary = String.Empty
            str_GhiLaiGiaTriXoa = String.Empty
            str_DieuKienXoa = String.Empty
            str_sql = "delete from [dbo].[" + TenBang + "] where "
            For Each s As String In Khoa
                If IsDBNull(gr.Item(s)) Then 'if IsDBNull(gr.Item(s)) then
                    bCheckKeyHopLe = False
                Else
                    KeySumary += CStr(gr.Item(s).ToString()) 'CStr(gr.Item(s).ToString())
                    If grid.Columns(s).ColumnType.ToString() = "System.String" Then 'If grid.Columns(s).ColumnType.ToString() = "System.String" Then
                        str_sql += s + "=N'" + gr.Item(s).ToString() + "' and " 'gr.Item(s).ToString()
                        str_DieuKienXoa += s + "=N'" + gr.Item(s).ToString() + "' and " 'gr.Item(s).ToString()
                    ElseIf grid.Columns(s).ColumnType.ToString() = "System.DateTime" Then 'If grid.Columns(s).ColumnType.ToString() = "System.DateTime" Then
                        str_sql += s + "='" + CType(gr.Item(s), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "' and " 'CType(gr.Item(s), Datetime).ToString("yyyy-MM-dd HH:mm:ss")
                        str_DieuKienXoa += s + "='" + CType(gr.Item(s), DateTime).ToString("yyyy-MM-dd HH:mm:ss") + "' and " 'CType(gridrow.Item(field), Datetime).ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        str_sql += s + "='" + CStr(gr.Item(s).ToString()) + "' and " 'gr.Item(s).ToString()
                        str_DieuKienXoa += s + "='" + CStr(gr.Item(s).ToString()) + "' and " 'gr.Item(s).ToString()
                    End If
                End If
            Next
            If bCheckKeyHopLe = True Then
                str_sql = str_sql.Remove(str_sql.Length - 5, 5)
                str_DieuKienXoa = str_DieuKienXoa.Remove(str_DieuKienXoa.Length - 5, 5)
                Dim Table As DataTable = kn.ReadData("select * from [" + TenBang + "] where " + str_DieuKienXoa, "abc")
                str_GhiLaiGiaTriXoa = "declare @Log nvarchar(max) select @Log = " + "N'{" + str_GhiLaiGiaTriXoa
                If Not IsNothing(DataMember) Then
                    For Each S As String In DataMember
                        If Table.Columns(S).DataType.ToString = "System.DateTime" Then
                            str_GhiLaiGiaTriXoa += """" + S + """:""'+" + "Convert(nvarchar(50), isnull(" + S + ",'1900-1-1'), 20)" + "+'"","
                        ElseIf Table.Columns(S).DataType.ToString = "System.Boolean" Then
                            str_GhiLaiGiaTriXoa += """" + S + """:""'+" + "Cast(isnull(" + S + ",'0') as nvarchar(50))" + "+'"","
                        ElseIf Table.Columns(S).DataType.ToString = "System.Decimal" Or Table.Columns(S).DataType.ToString = "System.Int32" Or Table.Columns(S).DataType.ToString = "System.Double" Then
                            str_GhiLaiGiaTriXoa += """" + S + """:""'+" + "Cast(isnull(" + S + ",'" + Integer.MaxValue.ToString + "') as nvarchar(50))" + "+'"","
                        Else
                            str_GhiLaiGiaTriXoa += """" + S + """:""'+isnull(" + S + ",'')+'"","
                        End If
                    Next
                    If str_GhiLaiGiaTriXoa <> String.Empty Then
                        str_GhiLaiGiaTriXoa = str_GhiLaiGiaTriXoa.Remove(str_GhiLaiGiaTriXoa.Length - 2, 2) + """' from [" + TenBang + "] where " + str_DieuKienXoa
                    End If
                    str_GhiLaiGiaTriXoa += " INSERT INTO SmartBooks_LOG ([Datetime],[UserName],KeySumary,TableName,[Form],[Action]) values(GETDATE(),N'" + obj.UserName + "',N'" + KeySumary + "',N'" + TenBang + "',null,@Log+',""User"":""" + obj.UserName + """,""TimeAction"":""'+CONVERT(nvarchar(50), GETDATE(), 20)+'"",""KeySumary"":""" + KeySumary + """,""TypeEdit"":""DELETE"",""FunctionID"":""" + TenBang + """,""TypeRecord"":""Original""}') "
                    If kn.SaveData(str_GhiLaiGiaTriXoa + " " + str_sql) = False Then
                        If isHienThiThongBao = True Then
                            MessageBox.Show(GetLanguagesTranslated("Popup.Xoakhongthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Return False
                    End If
                Else
                    If kn.SaveData(str_sql) = False Then
                        If isHienThiThongBao = True Then
                            MessageBox.Show(GetLanguagesTranslated("Popup.Xoakhongthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Return False
                    End If
                End If
            End If
        Next
        If isHienThiThongBao = True Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Xoathanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return True
    End Function
#End Region
#Region "EXPORT EXCEL"
    Public Sub XuatDanhSachNhanVienTheoLuoi(ByVal NameOfTitle As String, ByVal NameOfExportFile As String, ByVal Grid As GridView) ', ByVal Grid As GridEX
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.FileName = NameOfExportFile
        Dim result As DialogResult = fileChooser.ShowDialog()
        fileChooser.FileName = fileChooser.FileName + ".xlsx"
        fileChooser.CheckFileExists = False
        If Grid.SelectedRowsCount > 0 Then
            Grid.OptionsPrint.PrintSelectedRowsOnly = True
        Else
            Grid.OptionsPrint.PrintSelectedRowsOnly = False
        End If
        Grid.ExportToXlsx(fileChooser.FileName)
        Process.Start(fileChooser.FileName)
        'If result = DialogResult.OK Then
        '    XuatExcelTheoGridex_RowCheckedEPPlus(Application.StartupPath() + "\Teamleate\ExportGeneralExcel.xlsx", fileChooser.FileName.Replace(".xlsx", "") + ".xlsx", Grid, True, True, 7, "A", 5, NameOfTitle, True, True)
        'End If
    End Sub
    Public Function XuatExcelTheoTableEPPlus(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal Table As DataTable, ByVal isOpen As Boolean, ByVal LineStart As Integer, ByVal LineConfig As Integer, ByVal LineBorder As String, ByVal Content As String, ByVal listofValue As ArrayList, ByVal XoaDenDong As Integer, Optional ByVal bTinhTong As Boolean = False, Optional ByVal NotDeleteConfig As Boolean = False) As Boolean
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim excel As New FileInfo(LinkFileTemplate)
        Using package As New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim index As Integer = LineStart
            Dim iStart As Integer = LineStart
            Dim str_Field, str_Boder, colNo, Join As String
            Dim No As Integer = 1, subNo As Integer = 1, lastRow As Integer = 0, countSumMerge As Integer = 0
            Dim iIndex, MerceTuDong, MerceGroupSum As Integer
            Dim isMerge, isGroupSum, isGroup As Boolean
            Dim CotDienDuLieu, TruongDienDuLieu, CotCauHinhGroup, CotCauHinhGroupSum, CotGroupSum As New ArrayList
            Dim StyleID
            MerceTuDong = 0

            For Each colE As String In ColExel
                'LAY CAU HINH
                str_Field = ws.Cells(colE + LineConfig.ToString).Text.Trim
                If str_Field.Trim <> String.Empty Then
                    If str_Field.ToUpper = "NO" Then
                        colNo = colE
                    Else
                        If Table.Columns.Contains(str_Field) Then
                            CotDienDuLieu.Add(colE)
                            TruongDienDuLieu.Add(str_Field)
                        End If
                    End If
                End If
                'LAY COT GROUP
                str_Boder = ws.Cells(colE + LineBorder.ToString).Text.Trim
                If str_Boder.Trim <> String.Empty Then
                    If str_Boder.ToUpper = "G" Then
                        CotCauHinhGroup.Add(colE)
                    End If
                    If str_Boder.ToUpper = "GS" Then
                        CotCauHinhGroupSum.Add(colE)
                    End If
                    If str_Boder.ToUpper = "1" Then
                        CotGroupSum.Add(colE)
                    End If
                End If
            Next
            isGroup = False
            For i As Integer = 0 To Table.Rows.Count - 1
                'DIEN DU LIEU XUONG FILE
                If isGroup = False Then
                    'ws.Cells("A" + (index - 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index - 1).ToString).Copy(ws.Cells("A" + index.ToString + ":" + ColExel(ColExel.Count - 1) + index.ToString))
                End If
                'ws.InsertRow(index + 1, 2)
                'ws.Cells("A" + (index - 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index - 1).ToString).Copy(ws.Cells("A" + index.ToString + ":" + ColExel(ColExel.Count - 1) + index.ToString))
                ws.Cells("A" + index.ToString + ":" + ColExel(ColExel.Count - 1) + index.ToString).Copy(ws.Cells("A" + (index + 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index + 1).ToString))
                ws.Cells("A" + (index + 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index + 1).ToString).Copy(ws.Cells("A" + (index + 2).ToString + ":" + ColExel(ColExel.Count - 1) + (index + 2).ToString))
                ws.Cells(colNo + index.ToString).Value = No
                For iIndex = 0 To CotDienDuLieu.Count - 1
                    If Not IsDBNull(Table.Rows(i)(TruongDienDuLieu.Item(iIndex).ToString)) Then
                        ws.Cells(CotDienDuLieu.Item(iIndex).ToString + index.ToString).Value = Table.Rows(i)(TruongDienDuLieu.Item(iIndex).ToString)
                    End If
                Next

                'Kiểm tra Merge
                isMerge = True
                For iIndex = 0 To CotCauHinhGroup.Count - 1
                    If ws.Cells(CotCauHinhGroup.Item(iIndex).ToString + (index - 1).ToString).Text <> ws.Cells(CotCauHinhGroup.Item(iIndex).ToString + index.ToString).Text Then
                        isMerge = False
                        Exit For
                    End If
                Next
                If isMerge = True Then
                    If MerceTuDong = 0 Then
                        MerceTuDong = index - 1
                        If subNo = 2 Then
                            No = No - 1
                        End If
                    End If
                    If i = Table.Rows.Count - 1 And CotCauHinhGroup.Count > 0 Then
                        isMerge = False
                    End If
                End If
                If isMerge = False Then
                    If MerceTuDong > 0 And MerceTuDong <> LineStart - 1 Then
                        Join = String.Format(colNo + "{0}:" + colNo + "{1}", MerceTuDong, (index + IIf(i = Table.Rows.Count - 1, 1, 0) - 1).ToString)
                        ws.Cells(Join).Merge = True
                        ws.Cells(Join).Style.WrapText = True
                        ws.Cells(Join).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                        No = No - (index - 1) + MerceTuDong
                        For iIndex = 0 To CotCauHinhGroup.Count - 1
                            Join = String.Format(CotCauHinhGroup.Item(iIndex).ToString + "{0}:" + CotCauHinhGroup.Item(iIndex).ToString + "{1}", MerceTuDong, (index + IIf(i = Table.Rows.Count - 1, 1, 0) - 1).ToString)
                            ws.Cells(Join).Merge = True
                            ws.Cells(Join).Style.WrapText = True
                            ws.Cells(Join).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                        Next
                        MerceTuDong = 0
                    End If
                End If

                'Kiểm tra Group Sum
                isGroupSum = True
                isGroup = False
                For iIndex = 0 To CotCauHinhGroupSum.Count - 1
                    If ws.Cells(CotCauHinhGroupSum.Item(iIndex).ToString + (index - 1).ToString).Text <> ws.Cells(CotCauHinhGroupSum.Item(iIndex).ToString + index.ToString).Text Then
                        isGroupSum = False
                        Exit For
                    End If
                Next
                If isGroupSum = True Then
                    countSumMerge = countSumMerge + 1
                    If MerceGroupSum = 0 Then
                        MerceGroupSum = index - 1
                    End If
                    If i = Table.Rows.Count - 1 And CotCauHinhGroupSum.Count > 0 Then
                        isGroupSum = False
                        lastRow = 1
                    End If
                End If
                If isGroupSum = False Then
                    If MerceGroupSum > 0 And countSumMerge >= 1 Then
                        'Copy new line
                        index += 1
                        'ws.InsertRow(index, 2)
                        ws.Cells("A" + (index - 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index - 1).ToString).Copy(ws.Cells("A" + index.ToString + ":" + ColExel(ColExel.Count - 1) + index.ToString))
                        'ws.Cells("A" + index.ToString + ":" + ColExel(ColExel.Count - 1) + index.ToString).Copy(ws.Cells("A" + (index + 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index + 1).ToString))
                        ws.Cells("A" + (index - 1 + lastRow).ToString + ":" + ColExel(ColExel.Count - 1) + (index - 1 + lastRow).ToString).Value = ""
                        ws.Cells(CotCauHinhGroupSum.Item(0).ToString + (index - 1 + lastRow).ToString).Value = "Total " + ws.Cells(CotCauHinhGroupSum.Item(0).ToString + MerceGroupSum.ToString).Value
                        ws.Cells(CotCauHinhGroupSum.Item(0).ToString + (index - 1 + lastRow).ToString).Style.Font.Bold = True
                        ws.Cells(colNo + (index - 1 + lastRow).ToString).Value = ""
                        'ws.Cells("A" + (index - 1 + lastRow).ToString + ":" + ColExel(ColExel.Count - 1) + (index - 1 + lastRow).ToString).Style.Font. = Color.DeepSkyBlue
                        'ws.Cells().interior.
                        For iIndex = 0 To CotCauHinhGroupSum.Count - 1
                            Join = String.Format(CotCauHinhGroupSum.Item(iIndex).ToString + "{0}:" + CotCauHinhGroupSum.Item(iIndex).ToString + "{1}", MerceGroupSum, (index - 2 + lastRow).ToString)
                            ws.Cells(Join).Merge = True
                            ws.Cells(Join).Style.WrapText = True
                            ws.Cells(Join).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                        Next
                        For iIndex = 0 To CotGroupSum.Count - 1
                            ws.Cells(CotGroupSum.Item(iIndex).ToString + (index - 1 + lastRow).ToString).Formula = "=SUBTOTAL(9," + CotGroupSum.Item(iIndex).ToString + MerceGroupSum.ToString + ":" + CotGroupSum.Item(iIndex).ToString + (index + lastRow - 2).ToString + ")"
                            ws.Cells(CotGroupSum.Item(iIndex).ToString + (index - 1 + lastRow).ToString).Style.Font.Bold = True
                        Next
                        MerceGroupSum = 0
                        isGroup = True
                    End If
                    countSumMerge = 0
                End If
                subNo += 1
                No += 1
                index += 1
                'index += lastRow
            Next
            If (CotGroupSum.Count = 0) And (CotCauHinhGroupSum.Count = 0) And (CotCauHinhGroup.Count = 0) Then
                bTinhTong = False
            End If
            If bTinhTong = False Then
                For Each colE As String In ColExel
                    str_Boder = ws.Cells(colE + LineBorder.ToString).Text.Trim
                    If str_Boder <> String.Empty Then
                        ws.Cells(colE + (index - 1).ToString).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                    End If
                Next
                If XoaDenDong > 0 Then
                    ws.DeleteRow(index + 1, XoaDenDong - index + 1)
                End If
            Else
                ws.Cells("C" + index.ToString).Value = "TOTAL"
                ws.Cells("C" + index.ToString).Style.Font.Bold = True
                For Each colE As String In ColExel
                    str_Boder = ws.Cells(colE + LineBorder.ToString).Text.Trim
                    If str_Boder <> String.Empty Then
                        If str_Boder = "1" Then
                            ws.Cells(colE + index.ToString).Formula = "=SUBTOTAL(9," + colE + iStart.ToString + ":" + colE + (index - 1).ToString + ")"
                        Else
                            ws.Cells(colE + index.ToString).Value = String.Empty
                        End If
                        ws.Cells(colE + index.ToString).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        ws.Cells(colE + index.ToString).Style.Border.Top.Style = ExcelBorderStyle.Thin
                        ws.Cells(colE + index.ToString).Style.Font.Bold = True
                    End If
                Next
                If XoaDenDong > 0 Then
                    ws.DeleteRow(index + 1, XoaDenDong - index + 1)
                End If

            End If
            ws.DeleteRow(index + 1)
            'Son sua - Xoa dong config
            'ws.Cells("[A" + LineConfig.ToString + ":" + ColExel(ColExel.Length - 1) + LineConfig.ToString + "]").Value = String.Empty
            'ws.Cells("[A" + LineBorder.ToString + ":" + ColExel(ColExel.Length - 1) + LineBorder.ToString + "]").Value = String.Empty
            If (Not NotDeleteConfig) Then
                ws.InsertRow(LineConfig, 1)
                ws.DeleteRow(LineConfig + 1)
                ws.InsertRow(LineBorder, 1)
                ws.DeleteRow(LineBorder + 1)
            End If
            'Điền dữ listofValue và cột A từ dòng 1 cho đến dòng 20
            For i As Integer = 1 To 20
                If isNumber(ws.Cells("A" + i.ToString).Value) = True Then
                    If listofValue.Count >= ws.Cells("A" + i.ToString).Value Then
                        ws.Cells("A" + i.ToString).Value = listofValue(ws.Cells("A" + i.ToString).Value - 1)
                    End If
                End If
            Next
            Dim fi As New FileInfo(LinkFileXuat)
            package.SaveAs(fi)
            If isOpen = True Then
                System.Diagnostics.Process.Start(LinkFileXuat)
            End If
        End Using
        Return True
    End Function

    Public Function XuatExcelTheoTableEPPlus(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal Table As DataTable, ByVal isOpen As Boolean, ByVal WriteLine As Integer, ByVal ConfigLine As Integer, ByVal BorderLine As Integer, ByVal GroupBy As String(), ByVal listofValue As ArrayList, Optional ByVal bTinhTong As Boolean = False, Optional ByVal NotDeleteConfig As Boolean = False) As Boolean
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim No, No1, index, iStart, iKiemTraGoup, OldiKiemTraGoup, LengthOfGroupBy, IndexTruocTotal As Integer
        'No: sẽ bắt đầu lại từ 1 khi qua nhóm mới; No1: đếm từ đầu đến cuối
        iKiemTraGoup = 0
        If Not IsNothing(GroupBy) Then
            LengthOfGroupBy = GroupBy.Length
        Else
            LengthOfGroupBy = 1
        End If
        OldiKiemTraGoup = LengthOfGroupBy
        Dim DongBatDau(LengthOfGroupBy - 1) As Integer
        Dim str_Field, str_Boder, str_Group, ColGroup(LengthOfGroupBy - 1), join, GhiTuCotExcel, GhiDenCotExcel As String
        Dim excel As New FileInfo(LinkFileTemplate)
        Using package As New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            'begin lấy cột bắt đầu ghi và cột kết thúc
            For Each c As String In ColExel
                If Not IsNothing(ws.Cells(c + BorderLine.ToString).Value) Then
                    If GhiTuCotExcel = String.Empty Then
                        GhiTuCotExcel = c
                    End If
                    GhiDenCotExcel = c
                End If
            Next
            'end lấy cột bắt đầu ghi và cột kết thúc
            If Not IsNothing(GroupBy) Then
                Dim iColGroupBy As Integer = 0
                For Each c As String In ColExel
                    If Not IsNothing(ws.Cells(c + ConfigLine.ToString).Value) Then
                        If CStr(ws.Cells(c + ConfigLine.ToString).Value).ToUpper = GroupBy(iColGroupBy).ToUpper Then
                            ColGroup(iColGroupBy) = c
                            If iColGroupBy + 1 = LengthOfGroupBy Then
                                Exit For
                            Else
                                iColGroupBy += 1
                            End If
                        End If
                    End If

                Next
            Else
                ColGroup(0) = "B"
            End If

            For iDongBatDau As Integer = 0 To LengthOfGroupBy - 1
                DongBatDau(iDongBatDau) = WriteLine
            Next
            index = WriteLine
            iStart = WriteLine
            No = 1
            No1 = 1
            For i As Integer = 0 To Table.Rows.Count - 1
                'ws.InsertRow(index + 1, 1)
                'ws.Cells("A" + index.ToString + ":" + ColExel(ColExel.Count - 1) + index.ToString).Copy(ws.Cells("A" + (index + 1).ToString + ":" + ColExel(ColExel.Count - 1) + (index + 1).ToString))
                If Not IsNothing(GroupBy) Then
                    If i < Table.Rows.Count - 1 Then
                        iKiemTraGoup = 0
                        For iGroup As Integer = 0 To LengthOfGroupBy - 1
                            If Not IsDBNull(Table.Rows(i + 1)(GroupBy(iGroup))) And Not IsDBNull(Table.Rows(i)(GroupBy(iGroup))) Then
                                If CStr(Table.Rows(i)(GroupBy(iGroup))).ToUpper = CStr(Table.Rows(i + 1)(GroupBy(iGroup))).ToUpper Then
                                    iKiemTraGoup += 1
                                Else
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Next
                    End If
                End If

                For Each colE As String In ColExel
                    If Not IsNothing(ws.Cells(colE + ConfigLine.ToString).Value) Then
                        str_Field = CType(ws.Cells(colE + ConfigLine.ToString).Value, String).Trim
                        If str_Field.Trim <> String.Empty Then
                            If str_Field.ToUpper = "NO" Then
                                ws.Cells(colE + index.ToString).Value = No
                            ElseIf str_Field.ToUpper = "NO1" Then
                                ws.Cells(colE + index.ToString).Value = No1
                            Else
                                If Not IsDBNull(Table.Rows(i)(str_Field)) Then
                                    ws.Cells(colE + index.ToString).Value = Table.Rows(i)(str_Field)
                                End If
                            End If
                        End If
                    End If
                Next
                join = GhiTuCotExcel + index.ToString + ":" + GhiDenCotExcel + index.ToString
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Top.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                No += 1
                No1 += 1
                index += 1
                If Not IsNothing(GroupBy) Then
                    If iKiemTraGoup <> OldiKiemTraGoup Or i = Table.Rows.Count - 1 Then
                        If i = Table.Rows.Count - 1 Then
                            iKiemTraGoup = 0
                        End If
                        If iKiemTraGoup = 0 Then
                            OldiKiemTraGoup = LengthOfGroupBy
                        Else
                            OldiKiemTraGoup = iKiemTraGoup
                        End If

                        IndexTruocTotal = index
                        For j As Integer = LengthOfGroupBy - IIf(iKiemTraGoup = 0, 1, iKiemTraGoup) To iKiemTraGoup Step -1
                            ws.Cells(ColGroup(j) + index.ToString).Value = (j + 1).ToString + ". Total"
                            ws.Cells(ColGroup(j) + index.ToString).Style.Font.Bold = True
                            join = String.Format(ColGroup(j) + "{0}:" + ColGroup(j) + "{1}", DongBatDau(j).ToString, (index - 1).ToString)
                            ws.Cells(join).Merge = True
                            ws.Cells(join).Style.WrapText = True
                            ws.Cells(join).Style.VerticalAlignment = ExcelVerticalAlignment.Center
                            For Each col As String In ColExel
                                If ColGroup(j) <> col Then
                                    ws.Cells(col + index.ToString).Value = ""
                                End If
                                If Not IsNothing(ws.Cells(col + BorderLine.ToString).Value) Then
                                    str_Boder = CStr(ws.Cells(col + BorderLine.ToString).Value).Trim
                                    If str_Boder <> String.Empty Then
                                        If str_Boder = "1" Then
                                            ws.Cells(col + index.ToString).Formula = "=SUBTOTAL(9," + col + DongBatDau(j).ToString + ":" + col + (index - 1).ToString + ")"
                                            ws.Cells(col + index.ToString).Style.Font.Bold = True
                                            No1 = 1
                                        End If
                                        ws.Cells(col + index.ToString).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                                        ws.Cells(col + index.ToString).Style.Border.Top.Style = ExcelBorderStyle.Thin
                                        ws.Cells(col + index.ToString).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                                        ws.Cells(col + index.ToString).Style.Font.Bold = True
                                    End If
                                End If
                            Next
                            ws.InsertRow(index + 4, 1)
                            'Xls.RowInsert(index + 4)
                            index += 1
                            DongBatDau(j) = IndexTruocTotal + LengthOfGroupBy - IIf(iKiemTraGoup = 0, 1, iKiemTraGoup) - iKiemTraGoup + 1
                        Next

                    End If
                End If
            Next
            If bTinhTong = False Then
                For Each colE As String In ColExel
                    If Not IsNothing(ws.Cells(colE + BorderLine.ToString).Value) Then
                        str_Boder = CType(ws.Cells(colE + BorderLine.ToString).Value, String).Trim
                        If str_Boder <> String.Empty Then
                            ws.Cells(colE + (index - 1).ToString).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                        End If
                    End If
                Next
                ws.DeleteRow(index - 1)
                ws.DeleteRow(index - 1)
                ws.DeleteRow(index - 1)
                ws.DeleteRow(index - 1)
            Else
                For Each colE As String In ColExel
                    ws.Cells(colE + index.ToString).Value = ""
                    ws.Cells(ColGroup(0) + index.ToString).Value = "TOTAL"
                    'ws.Cells(ColGroup(0) + index.ToString).Attr.Fit = False
                    If Not IsNothing(ws.Cells(colE + BorderLine.ToString).Value) Then
                        str_Boder = CStr(ws.Cells(colE + BorderLine.ToString).Value).Trim
                        If str_Boder <> String.Empty Then
                            If str_Boder = "1" Then
                                ws.Cells(colE + index.ToString).Formula = "=SUBTOTAL(9," + colE + iStart.ToString + ":" + colE + (index - 1).ToString + ")"
                            End If
                            ws.Cells(colE + index.ToString).Style.Border.Bottom.Style = ExcelBorderStyle.Thick
                            ws.Cells(colE + index.ToString).Style.Border.Top.Style = ExcelBorderStyle.Thick
                            ws.Cells(colE + index.ToString).Style.Font.Bold = True
                        End If
                    End If

                Next
                ws.DeleteColumn(index)
                ws.DeleteColumn(index)
                ws.DeleteColumn(index)
            End If
            join = GhiTuCotExcel + WriteLine.ToString + ":" + GhiDenCotExcel + index.ToString
            ws.Cells(join).Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick)
            'Xoa dong config
            'ws.DeleteRow(ConfigLine)
            'ws.DeleteRow(BorderLine)
            If (Not NotDeleteConfig) Then
                ws.InsertRow(ConfigLine, 1)
                ws.DeleteRow(ConfigLine + 1)
                ws.InsertRow(BorderLine, 1)
                ws.DeleteRow(BorderLine + 1)
            End If
            'Điền dữ listofValue và cột A từ dòng 1 cho đến dòng 20
            For i As Integer = 1 To 20
                If isNumber(ws.Cells("A" + i.ToString).Value) = True Then
                    If listofValue.Count >= ws.Cells("A" + i.ToString).Value Then
                        ws.Cells("A" + i.ToString).Value = listofValue(ws.Cells("A" + i.ToString).Value - 1)
                    End If
                End If
            Next
            'END
            Dim fi As New FileInfo(LinkFileXuat)
            package.SaveAs(fi)
            If isOpen = True Then
                System.Diagnostics.Process.Start(LinkFileXuat)
            End If

        End Using
        Return True
    End Function
    Public Function XuatExcelTheoTable(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal Table As DataTable, ByVal isOpen As Boolean, ByVal LineStart As Integer, ByVal LineConfig As Integer, ByVal LineBorder As String, ByVal Content As String, ByVal listofValue As ArrayList, Optional ByVal bTinhTong As Boolean = False, Optional ByVal NotDeleteConfig As Boolean = False) As Boolean
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim Xls As New XlsReport
        Xls.FileName = LinkFileTemplate
        Xls.Start.File()
        'Xls.Page.Begin("Sheet2", "1")
        'Xls.Page.End()
        Xls.Page.Begin("Sheet1", "1")
        Xls.Page.Name = "Sheet1"
        Dim index As Integer = LineStart
        Dim iStart As Integer = LineStart
        Dim str_Field, str_Boder, colNo As String
        Dim iIndex As Integer
        Dim No As Integer = 1
        Dim CotDienDuLieu, TruongDienDuLieu As New ArrayList
        Xls.Cell("B" + LineBorder.ToString).Value = Content
        'LAY CAU HINH
        For Each colE As String In ColExel
            str_Field = Xls.Cell(colE + LineConfig.ToString).Value
            If str_Field.Trim <> String.Empty Then
                If str_Field.ToUpper = "NO" Then
                    colNo = colE
                Else
                    If Table.Columns.Contains(str_Field) Then
                        CotDienDuLieu.Add(colE)
                        TruongDienDuLieu.Add(str_Field)
                    End If
                End If
            End If
        Next
        'DIEN DU LIEU XUONG FILE
        For i As Integer = 0 To Table.Rows.Count - 1
            Xls.RowInsert(index + 4)
            Xls.RowCopy(index - 1, index)
            Xls.RowCopy(index, index + 1)
            Xls.RowCopy(index + 1, index + 2)
            Xls.RowCopy(index + 2, index + 3)
            Xls.Cell(colNo + index.ToString).Value = No
            For iIndex = 0 To CotDienDuLieu.Count - 1
                If Not IsDBNull(Table.Rows(i)(TruongDienDuLieu.Item(iIndex).ToString)) Then
                    Xls.Cell(CotDienDuLieu.Item(iIndex).ToString + index.ToString).Value = Table.Rows(i)(TruongDienDuLieu.Item(iIndex).ToString)
                End If
            Next
            No += 1
            index += 1
        Next
        If bTinhTong = False Then
            For Each colE As String In ColExel
                str_Boder = CType(Xls.Cell(colE + LineBorder.ToString).Value, String).Trim
                If str_Boder <> String.Empty Then
                    Xls.Cell(colE + (index - 1).ToString).Attr.LineBottom = xlLineStyle.lsNormal
                End If
            Next
            Xls.RowDelete(index - 1)
            Xls.RowDelete(index - 1)
            Xls.RowDelete(index - 1)
            Xls.RowDelete(index - 1)
        Else
            Xls.Cell("B" + index.ToString).Value = "TOTAL"
            For Each colE As String In ColExel
                str_Boder = CStr(Xls.Cell(colE + LineBorder.ToString).Value).Trim
                If str_Boder <> String.Empty Then
                    If str_Boder = "1" Then
                        Xls.Cell(colE + index.ToString).Value = "=SUM(" + colE + iStart.ToString + ":" + colE + (index - 1).ToString + ")"
                    End If
                    Xls.Cell(colE + index.ToString).Attr.LineBottom = xlLineStyle.lsThick
                    Xls.Cell(colE + index.ToString).Attr.LineTop = xlLineStyle.lsThick
                    Xls.Cell(colE + index.ToString).Attr.FontStyle = xlFontStyle.xsBold
                End If
            Next
            Xls.RowDelete(index)
            Xls.RowDelete(index)
            Xls.RowDelete(index)
        End If
        'Son sua - Xoa dong config
        If Not NotDeleteConfig Then
            Xls.RowClear(LineConfig)
            Xls.RowClear(LineBorder)
        End If
        'Điền dữ listofValue và cột A từ dòng 1 cho đến dòng 20
        For i As Integer = 1 To 20
            If isNumber(Xls.Cell("A" + i.ToString).Value) = True Then
                If listofValue.Count >= Xls.Cell("A" + i.ToString).Value Then
                    Xls.Cell("A" + i.ToString).Value = listofValue(Xls.Cell("A" + i.ToString).Value - 1)
                End If
            End If
        Next
        Xls.Page.End()
        Xls.Out.File(LinkFileXuat)
        SaveFileExcel(LinkFileXuat)
        If isOpen = True Then
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = LinkFileXuat
            Process.Start(ps)
        End If
        Return True
    End Function
    Public Function XuatExcelTheoTable(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal Table As DataTable, ByVal isOpen As Boolean, ByVal TieuDe As String, ByVal PathOfLanFile As String) As Boolean
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim Xls As New XlsReport
        Xls.FileName = LinkFileTemplate
        Xls.Start.File()
        'Xls.Page.Begin("Sheet2", "1")
        'Xls.Page.End()
        Xls.Page.Begin("Sheet1", "1")
        Xls.Page.Name = "Sheet1"
        Dim LineStart, LineBorder, LineConfig, LineHeader As Integer
        LineStart = 11
        LineBorder = 8
        LineConfig = 9
        LineHeader = 10
        Dim index As Integer = LineStart
        Dim iStart As Integer = LineStart
        Dim str_Field, str_Boder, str_Datamember As String
        Dim No As Integer = 1
        For Each col As DataColumn In Table.Columns
            str_Datamember += col.Caption + ","
        Next
        str_Datamember = str_Datamember.Remove(str_Datamember.Length - 1, 1)
        Dim NgonNgu As String() = DichNgonNgu(PathOfLanFile, str_Datamember.Split(","))
        Xls.Cell("B6").Value = TieuDe
        For j As Integer = 0 To Table.Columns.Count - 1
            If Table.Columns(j).DataType.ToString = "System.Double" Then
                Xls.Cell(ColExel(j) + LineBorder.ToString).Value = "1"
            Else
                Xls.Cell(ColExel(j) + LineBorder.ToString).Value = "2"
            End If
            Xls.Cell(ColExel(j) + LineConfig.ToString).Value = Table.Columns(j).Caption
            Xls.Cell(ColExel(j) + LineHeader.ToString).Value = IIf(NgonNgu(j) = String.Empty, Table.Columns(j).Caption, NgonNgu(j)) 'LayTenTuFileNgonNgu(Table.Columns(j).Caption)
            Xls.Cell(ColExel(j) + LineHeader.ToString).Attr.LineBottom = xlLineStyle.lsNormal
            Xls.Cell(ColExel(j) + LineHeader.ToString).Attr.LineLeft = xlLineStyle.lsNormal
            Xls.Cell(ColExel(j) + LineHeader.ToString).Attr.LineRight = xlLineStyle.lsNormal
            Xls.Cell(ColExel(j) + LineHeader.ToString).Attr.LineTop = xlLineStyle.lsNormal
        Next
        For i As Integer = 0 To Table.Rows.Count - 1
            Xls.RowInsert(index + 4)
            Xls.RowCopy(index + 1, index + 2)
            For Each colE As String In ColExel
                str_Field = CType(Xls.Cell(colE + LineConfig.ToString).Value, String).Trim
                If str_Field.Trim <> String.Empty Then
                    If str_Field.ToUpper = "NO" Then
                        Xls.Cell(colE + index.ToString).Value = No
                    Else
                        If Not IsDBNull(Table.Rows(i)(str_Field)) Then
                            Xls.Cell(colE + index.ToString).Value = Table.Rows(i)(str_Field)
                            If Table.Columns(str_Field).DataType.ToString = "System.DateTime" Then
                                Xls.Cell(colE + index.ToString).Attr.Format = "dd/MM/yyyy"
                            ElseIf Table.Columns(str_Field).DataType.ToString = "System.Double" Then
                                Xls.Cell(colE + index.ToString).Attr.Format = "@"
                            End If
                        End If
                    End If
                End If
            Next
            No += 1
            index += 1
        Next
        Xls.Cell("B" + index.ToString).Value = "TOTAL"
        For Each colE As String In ColExel
            str_Boder = CStr(Xls.Cell(colE + LineBorder.ToString).Value).Trim
            If str_Boder <> String.Empty Then
                If str_Boder = "1" Then
                    Xls.Cell(colE + index.ToString).Value = "=SUM(" + colE + iStart.ToString + ":" + colE + (index - 1).ToString + ")"
                End If
                Xls.Cell(colE + index.ToString).Attr.LineBottom = xlLineStyle.lsThick
                Xls.Cell(colE + index.ToString).Attr.LineTop = xlLineStyle.lsThick
                Xls.Cell(colE + index.ToString).Attr.FontStyle = xlFontStyle.xsBold
            End If
        Next
        Xls.RowDelete(LineBorder - 1)
        Xls.RowDelete(LineBorder - 1)
        Xls.RowDelete(index)
        Xls.RowDelete(index)
        Xls.RowDelete(index)
        Xls.Page.End()
        Xls.Out.File(LinkFileXuat)
        SaveFileExcel(LinkFileXuat)
        If isOpen = True Then
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = LinkFileXuat
            Process.Start(ps)
        End If
        Return True
    End Function
    Public Function XuatExcelTheoTable(ByVal LinkFileTemplate As String, ByVal SheetName As String(), ByVal LinkFileXuat As String, ByVal Table As DataTable, ByVal isOpen As Boolean, ByVal WriteLine As Integer, ByVal ConfigLine As Integer, ByVal BorderLine As Integer, ByVal GroupBy As String(), ByVal listofValue As ArrayList, Optional ByVal bTinhTong As Boolean = False, Optional ByVal NotDeleteConfig As Boolean = False) As Boolean
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim No, index, iStart, iKiemTraGoup, OldiKiemTraGoup, LengthOfGroupBy, IndexTruocTotal As Integer
        iKiemTraGoup = 0
        If Not IsNothing(GroupBy) Then
            LengthOfGroupBy = GroupBy.Length
        Else
            LengthOfGroupBy = 1
        End If
        OldiKiemTraGoup = LengthOfGroupBy
        Dim DongBatDau(LengthOfGroupBy - 1) As Integer
        Dim str_Field, str_Boder, str_Group, ColGroup(LengthOfGroupBy - 1), join As String
        Dim Xls As New XlsReport
        Xls.FileName = LinkFileTemplate
        Xls.Start.File()

        If Not IsNothing(GroupBy) Then
            Dim iColGroupBy As Integer = 0
            For Each c As String In ColExel
                If CStr(Xls.Cell(c + ConfigLine.ToString).Value).ToUpper = GroupBy(iColGroupBy).ToUpper Then
                    ColGroup(iColGroupBy) = c
                    If iColGroupBy + 1 = LengthOfGroupBy Then
                        Exit For
                    Else
                        iColGroupBy += 1
                    End If

                End If
            Next
        Else
            ColGroup(0) = "B"
        End If

        For Each sn As String In SheetName
            Xls.Page.Begin(sn, "1")
            Xls.Page.Name = sn
            For iDongBatDau As Integer = 0 To LengthOfGroupBy - 1
                DongBatDau(iDongBatDau) = WriteLine
            Next
            index = WriteLine
            iStart = WriteLine
            No = 1
            For i As Integer = 0 To Table.Rows.Count - 1
                Xls.RowInsert(index + 4)
                Xls.RowCopy(index - 1, index)
                Xls.RowCopy(index, index + 1)
                Xls.RowCopy(index + 1, index + 2)
                Xls.RowCopy(index + 2, index + 3)
                If Not IsNothing(GroupBy) Then
                    If i < Table.Rows.Count - 1 Then
                        iKiemTraGoup = 0
                        For iGroup As Integer = 0 To LengthOfGroupBy - 1
                            If Not IsDBNull(Table.Rows(i + 1)(GroupBy(iGroup))) And Not IsDBNull(Table.Rows(i)(GroupBy(iGroup))) Then
                                If CStr(Table.Rows(i)(GroupBy(iGroup))).ToUpper = CStr(Table.Rows(i + 1)(GroupBy(iGroup))).ToUpper Then
                                    iKiemTraGoup += 1
                                Else
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Next
                    End If
                End If

                For Each colE As String In ColExel
                    str_Field = CType(Xls.Cell(colE + ConfigLine.ToString).Value, String).Trim
                    If str_Field.Trim <> String.Empty Then
                        If str_Field.ToUpper = "NO" Then
                            Xls.Cell(colE + index.ToString).Value = No
                        Else
                            If Not IsDBNull(Table.Rows(i)(str_Field)) Then
                                Xls.Cell(colE + index.ToString).Value = Table.Rows(i)(str_Field)
                            End If
                        End If
                    End If
                Next
                No += 1
                index += 1
                If Not IsNothing(GroupBy) Then
                    If iKiemTraGoup <> OldiKiemTraGoup Or i = Table.Rows.Count - 1 Then
                        If i = Table.Rows.Count - 1 Then
                            iKiemTraGoup = 0
                        End If
                        If iKiemTraGoup = 0 Then
                            OldiKiemTraGoup = LengthOfGroupBy
                        Else
                            OldiKiemTraGoup = iKiemTraGoup
                        End If

                        IndexTruocTotal = index
                        For j As Integer = LengthOfGroupBy - IIf(iKiemTraGoup = 0, 1, iKiemTraGoup) To iKiemTraGoup Step -1
                            Xls.Cell(ColGroup(j) + index.ToString).Value = (j + 1).ToString + ". Total"
                            Xls.Cell(ColGroup(j) + index.ToString).Attr.FontStyle = xlFontStyle.xsBold
                            join = String.Format(ColGroup(j) + "{0}:" + ColGroup(j) + "{1}", DongBatDau(j).ToString, (index - 1).ToString)
                            Xls.Cell(join).Attr.Joint = True
                            For Each col As String In ColExel
                                If ColGroup(j) <> col Then
                                    Xls.Cell(col + index.ToString).Value = ""
                                End If
                                str_Boder = CStr(Xls.Cell(col + BorderLine.ToString).Value).Trim
                                If str_Boder <> String.Empty Then
                                    If str_Boder = "1" Then
                                        Xls.Cell(col + index.ToString).Value = "=SUBTOTAL(9," + col + DongBatDau(j).ToString + ":" + col + (index - 1).ToString + ")"
                                        Xls.Cell(col + index.ToString).Attr.FontStyle = xlFontStyle.xsBold
                                    End If
                                End If
                            Next
                            Xls.RowInsert(index + 4)
                            index += 1
                            DongBatDau(j) = IndexTruocTotal + LengthOfGroupBy - IIf(iKiemTraGoup = 0, 1, iKiemTraGoup) - iKiemTraGoup + 1
                        Next

                    End If
                End If
            Next
            If bTinhTong = False Then
                For Each colE As String In ColExel
                    str_Boder = CType(Xls.Cell(colE + BorderLine.ToString).Value, String).Trim
                    If str_Boder <> String.Empty Then
                        Xls.Cell(colE + (index - 1).ToString).Attr.LineBottom = xlLineStyle.lsNormal
                    End If
                Next
                Xls.RowDelete(index - 1)
                Xls.RowDelete(index - 1)
                Xls.RowDelete(index - 1)
                Xls.RowDelete(index - 1)
            Else
                For Each colE As String In ColExel
                    str_Boder = CStr(Xls.Cell(colE + BorderLine.ToString).Value).Trim
                    Xls.Cell(colE + index.ToString).Value = ""
                    Xls.Cell(ColGroup(0) + index.ToString).Value = "TOTAL"
                    Xls.Cell(ColGroup(0) + index.ToString).Attr.Fit = False
                    If str_Boder <> String.Empty Then
                        If str_Boder = "1" Then
                            Xls.Cell(colE + index.ToString).Value = "=SUBTOTAL(9," + colE + iStart.ToString + ":" + colE + (index - 1).ToString + ")"
                        End If
                        Xls.Cell(colE + index.ToString).Attr.LineBottom = xlLineStyle.lsThick
                        Xls.Cell(colE + index.ToString).Attr.LineTop = xlLineStyle.lsThick
                        Xls.Cell(colE + index.ToString).Attr.FontStyle = xlFontStyle.xsBold
                    End If
                Next
                Xls.RowDelete(index)
                Xls.RowDelete(index)
                Xls.RowDelete(index)
            End If
            'Son sua - Xoa dong config
            If Not NotDeleteConfig Then
                Xls.RowClear(ConfigLine)
                Xls.RowClear(BorderLine)
            End If
            'Điền dữ listofValue và cột A từ dòng 1 cho đến dòng 20
            For i As Integer = 1 To 20
                If isNumber(Xls.Cell("A" + i.ToString).Value) = True Then
                    If listofValue.Count >= Xls.Cell("A" + i.ToString).Value Then
                        Xls.Cell("A" + i.ToString).Value = listofValue(Xls.Cell("A" + i.ToString).Value - 1)
                    End If
                End If
            Next
            'END
            Xls.Page.End()
        Next
        Xls.Out.File(LinkFileXuat)
        SaveFileExcel(LinkFileXuat)
        If isOpen = True Then
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = LinkFileXuat
            Process.Start(ps)
        End If
        Return True
    End Function
#End Region
#Region "IMPORT EXCEL"
    Public Function NhapCongNgoaiLe(ByVal PathOfInputFile As String) As Boolean
        If PathOfInputFile <> String.Empty Then
            Dim urlTemplate As String = PathOfInputFile
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim Xls As New XlsReport
            Xls.FileName = urlTemplate
            Xls.Start.File()
            Xls.Page.Begin("Sheet1", "1")
            Xls.Page.Name = "Sheet1"
            Dim index As Integer = 8
            Dim ColConfig As Integer = 6
            Dim intColStart As Integer = 3
            Dim objDt As Object
            Dim Employee_ID, Ngay, MaCong, InsertSource, wt, Remark, InsertDate, UserName As String
            InsertDate = "'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"
            UserName = "N'" + obj.UserName + "'"
            InsertSource = "'NhapTay'"
            While CStr(Xls.Cell("A" + index.ToString).Value).Trim <> String.Empty
                Employee_ID = "N'" + CStr(Xls.Cell("A" + index.ToString).Value).Trim + "'"
                objDt = CheckExcelNull(Xls, "B" + index.ToString(), ObjectType.DateType, Date.MinValue).Replace("'", "")
                If CStr(objDt).ToUpper <> "NULL" Then
                    If CType(objDt, DateTime).Year <> 1900 And CType(objDt, DateTime).Year <> 1 Then
                        Ngay = "'" + CDate(objDt).ToString("yyyy-MM-dd") + "'"
                    End If
                End If
                Remark = CStr(Xls.Cell("C" + index.ToString).Value).Trim
                If Remark = String.Empty Then
                    Remark = "null"
                Else
                    Remark = "N'" + Remark + "'"
                End If
                For intcol As Integer = intColStart To ColExel.Length - 1
                    If CStr(Xls.Cell(ColExel(intcol) + ColConfig.ToString).Value).Trim <> String.Empty Then
                        MaCong = "N'" + CStr(Xls.Cell(ColExel(intcol) + ColConfig.ToString).Value).Trim + "'"
                        wt = CStr(Xls.Cell(ColExel(intcol) + index.ToString).Value).Trim
                        If wt <> String.Empty And wt <> "0" Then
                            If kn.SaveData("exec usp_InsertUpdateHR_WTDaily " + Employee_ID + "," + MaCong + "," + Ngay + "," + InsertSource + "," + wt + "," + Remark + "," + UserName) = False Then
                                Xls.Page.End()
                                Xls.Out.File(urlTemplate)
                                Return False
                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
                index += 1
            End While
            Xls.Page.End()
            Xls.Out.File(urlTemplate)
            Return True
        End If
    End Function
    Public Function NhapDuLieuQuet(ByVal urlTemplate) As Boolean
        Dim Xls As New XlsReport
        Xls.FileName = urlTemplate
        Xls.Start.File()
        Xls.Page.Begin("Sheet1", "1")
        Xls.Page.Name = "Sheet1"
        Dim index As Integer = 7
        Dim Employee_ID, InsertSource, InsertBy As String
        Dim AccessDate, InsertDate, AccessTime, OldAccessTime As DateTime
        Dim ojDate, ojTime As Object
        InsertBy = obj.UserName
        InsertDate = Now
        Dim datamember As String() = {"Employee_ID", "AccessDate", "AccessTime", "CardNumber", "InsertSource", "UserName", "InsertDate"}
        Dim datamember_Value As New ArrayList
        Dim primary As String() = {"Employee_ID", "AccessTime"}
        Dim primary_Value As New ArrayList
        While CStr(Xls.Cell("C" + index.ToString).Value).Trim <> String.Empty
            Employee_ID = CStr(Xls.Cell("C" + index.ToString).Value).Trim
            ojDate = CheckExcelNull(Xls, "E" + index.ToString(), ObjectType.DateType, "Null")
            If ojDate <> "" And CStr(ojDate).ToUpper <> "NULL" Then
                AccessDate = CType(ojDate.ToString().Replace("'", ""), Date)
                ojTime = CheckExcelNull(Xls, "F" + index.ToString(), ObjectType.TimeType, "Null")
                If ojTime <> "" And CStr(ojTime).ToUpper <> "NULL" Then
                    AccessTime = CType(ojTime.ToString().Replace("'", ""), DateTime)
                    OldAccessTime = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second)
                    datamember_Value.Clear()
                    datamember_Value.Add(Employee_ID)
                    datamember_Value.Add(AccessDate)
                    datamember_Value.Add(OldAccessTime)
                    datamember_Value.Add(Employee_ID)
                    datamember_Value.Add("NhapTay")
                    datamember_Value.Add(InsertBy)
                    datamember_Value.Add(InsertDate)

                    primary_Value.Clear()
                    primary_Value.Add(Employee_ID)
                    primary_Value.Add(New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second))
                    If LuuKhongGhiLog(False, "HR_TimeKeeping_Data", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                        Xls.Page.End()
                        Xls.Out.File(urlTemplate)
                        Return False
                    End If
                End If

                ojTime = CheckExcelNull(Xls, "G" + index.ToString(), ObjectType.TimeType, "Null")
                If ojTime <> "" And CStr(ojTime).ToUpper <> "NULL" Then
                    AccessTime = CType(ojTime.ToString().Replace("'", ""), DateTime)
                    If AccessTime.Hour < OldAccessTime.Hour Then
                        AccessDate = AccessDate.AddDays(1)
                    End If
                    AccessTime = New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second)
                    datamember_Value.Clear()
                    datamember_Value.Add(Employee_ID)
                    datamember_Value.Add(AccessDate)
                    datamember_Value.Add(AccessTime)
                    datamember_Value.Add(Employee_ID)
                    datamember_Value.Add("NhapTay")
                    datamember_Value.Add(InsertBy)
                    datamember_Value.Add(InsertDate)

                    primary_Value.Clear()
                    primary_Value.Add(Employee_ID)
                    primary_Value.Add(New DateTime(AccessDate.Year, AccessDate.Month, AccessDate.Day, AccessTime.Hour, AccessTime.Minute, AccessTime.Second))
                    If LuuKhongGhiLog(False, "HR_TimeKeeping_Data", primary, primary_Value.ToArray, datamember, datamember_Value.ToArray) = False Then
                        Xls.Page.End()
                        Xls.Out.File(urlTemplate)
                        Return False
                    End If
                End If
            End If
            index += 1
        End While
        Xls.Page.End()
        Xls.Out.File(urlTemplate)
        Return True
    End Function

    Public Function NhapExcel(ByVal TableName As String, ByVal arrayDataMember() As String, ByVal Primary() As String, ByVal StartLine As Integer, ByVal placeCall As String, Optional ByVal FieldInserDate As String = "", Optional ByVal FieldUserName As String = "", Optional ByVal ColNotNull As String = "A") As Boolean
        Dim ofd As New OpenFileDialog
        With ofd
            .FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xls)|*.xls|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Return False
            End If
            Dim urlTemplate As String = ofd.FileName
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim Xls As New XlsReport
            Xls.FileName = urlTemplate
            Xls.Start.File()
            Xls.Page.Begin("Sheet1", "1")
            Xls.Page.Name = "Sheet1"
            Dim sqlInsert, sqlUpdate, sqlDelete As String
            Dim index As Integer = StartLine
            Dim TruongInsert, GiaTriInsert, DieuKienXoa As String
            TruongInsert = String.Empty
            Dim row As DataRow()
            Dim colCount As Integer = 0
            Dim tabType As DataTable = GetInformationOfSQLTable(TableName)
            Dim PrimaryIndex As New ArrayList
            For Each s As String In arrayDataMember
                TruongInsert = TruongInsert + "[" + s + "]" + ","
                colCount += 1
            Next
            If FieldUserName = "" Then
                TruongInsert = TruongInsert.Remove(TruongInsert.Length - 1, 1)
            Else
                TruongInsert = TruongInsert + "[" + FieldInserDate + "], [" + FieldUserName + "]"
            End If
            Dim i As Integer
            Dim dt_Ngay As DateTime
            While CStr(Xls.Cell(ColNotNull + index.ToString).Value).Trim <> String.Empty
                GiaTriInsert = String.Empty
                DieuKienXoa = String.Empty
                i = 0
                For Each s As String In arrayDataMember
                    row = tabType.Select("COLUMN_NAME='" + s + "'")
                    If row.Length > 0 Then
                        If CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim = String.Empty Then
                            GiaTriInsert = GiaTriInsert + "null,"
                        Else
                            If row(0)("DATA_TYPE") = "nvarchar" Then
                                GiaTriInsert = GiaTriInsert + "N'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "',"
                            ElseIf row(0)("DATA_TYPE") = "datetime" Then
                                dt_Ngay = CheckExcelNull(Xls, ColExel(i) + index.ToString(), ObjectType.DateType, Date.MinValue)
                                GiaTriInsert = GiaTriInsert + "'" + dt_Ngay.ToString("yyyy-MM-dd") + "',"
                            Else
                                GiaTriInsert = GiaTriInsert + "'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "',"
                            End If
                        End If
                        If Primary.IndexOf(Primary, s) >= 0 Then
                            If row(0)("DATA_TYPE") = "nvarchar" Then
                                DieuKienXoa = DieuKienXoa + "[" + s + "] = N'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "' and "
                            ElseIf row(0)("DATA_TYPE") = "datetime" Then
                                dt_Ngay = CheckExcelNull(Xls, ColExel(i) + index.ToString(), ObjectType.DateType, Date.MinValue)
                                DieuKienXoa = DieuKienXoa + "[" + s + "] = '" + dt_Ngay.ToString("yyyy-MM-dd") + "' and "
                            Else
                                DieuKienXoa = DieuKienXoa + "[" + s + "] = '" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "' and "
                            End If
                        End If
                        i += 1
                    End If
                Next
                If FieldUserName = "" Then
                    GiaTriInsert = GiaTriInsert.Remove(GiaTriInsert.Length - 1, 1)
                Else
                    GiaTriInsert = GiaTriInsert + "'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "',N'" + obj.UserName + "'"
                End If
                If DieuKienXoa <> String.Empty Then
                    DieuKienXoa = DieuKienXoa.Remove(DieuKienXoa.Length - 5, 5)
                    If kn.SaveData("DELETE FROM " + TableName + " WHERE " + DieuKienXoa) = False Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If
                Try
                    If kn.SaveDataNotReport("INSERT INTO " + TableName + "(" + TruongInsert + ") VALUES(" + GiaTriInsert + ")") = False Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Catch ex As Exception
                End Try
                index += 1
            End While
            MessageBox.Show(GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Xls.Page.End()
            Xls.Out.File(urlTemplate)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function NhapExcelEPPlus(ByVal TableName As String, ByVal LinkOfFile As String, ByVal LineConfigDatamember As Integer, ByVal LineConfigPrimary As Integer, ByVal LineStart As Integer, Optional ByVal FieldInserDate As String = "", Optional ByVal FieldUserName As String = "") As Boolean
        'Dim ofd As New OpenFileDialog
        'With ofd
        '    '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
        '    .Title = "Locate File"
        '    .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        'End With
        'If ofd.ShowDialog() = DialogResult.Cancel Then
        '    Return False
        'End If
        'If MessageBox.Show("Bạn có thực sự muốn cập nhật thông tin nhân viên!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        '    Return False
        'End If
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim str, strData, strColKey As String
        Dim Datamember As String()
        Dim Datamember_Value As New ArrayList
        Dim Primary As String()
        Dim Primary_Value As New ArrayList
        Dim ColDatamember As String()
        Dim ColKey As String()
        Dim ojDate, ojTime As Object
        Dim dtDate, dtTime, dtfromdate, StartedDate As DateTime
        Dim tableInf As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
        Dim excel As New FileInfo(LinkOfFile)
        Using package = New ExcelPackage(excel)
            Dim workbook = package.Workbook
            Dim worksheet = workbook.Worksheets.First()
            'package.Workbook.Calculate()
            For Each c As String In ColExel
                If worksheet.Cells(c + LineConfigDatamember.ToString).Text.Trim <> "" Then
                    If tableInf.Select("COLUMN_NAME='" + worksheet.Cells(c + LineConfigDatamember.ToString).Text.Trim + "'").Length > 0 Then
                        str += worksheet.Cells(c + LineConfigDatamember.ToString).Text.Trim + ","
                        strData += c + ","
                    End If
                End If
            Next
            If str <> String.Empty Then
                If FieldInserDate <> String.Empty Then
                    str += FieldInserDate + ","
                End If
                If FieldUserName <> String.Empty Then
                    str += FieldUserName + ","
                End If
                Datamember = Split(str.Remove(str.Length - 1, 1), ",")
                ColDatamember = Split(strData.Remove(strData.Length - 1, 1), ",")
            End If
            str = String.Empty
            For Each c As String In ColExel
                If worksheet.Cells(c + LineConfigPrimary.ToString).Text.Trim <> "" Then
                    If tableInf.Select("COLUMN_NAME='" + worksheet.Cells(c + LineConfigPrimary.ToString).Text.Trim + "'").Length > 0 Then
                        str += worksheet.Cells(c + LineConfigPrimary.ToString).Text.Trim + ","
                        strColKey += c + ","
                    End If
                End If
            Next
            If str <> String.Empty Then
                Primary = Split(str.Remove(str.Length - 1, 1), ",")
                ColKey = Split(strColKey.Remove(strColKey.Length - 1, 1), ",")
            End If
            Dim index As Integer = LineStart, isDataNull As Integer = 0
            While worksheet.Cells(ColKey(0) + index.ToString).Text.Trim <> String.Empty Or isDataNull < 2
                If worksheet.Cells(ColKey(0) + index.ToString).Text.Trim = String.Empty Then
                    isDataNull += 1
                    index += 1
                Else
                    isDataNull = 0
                    Primary_Value.Clear()
                    Datamember_Value.Clear()
                    For i As Integer = 0 To ColKey.Length - 1
                        worksheet.Cells(ColKey(i) + index.ToString()).Calculate
                        If tableInf.Select("COLUMN_NAME='" + Primary(i) + "'")(0)("DATA_TYPE") = "datetime" Then
                            ojDate = worksheet.Cells(ColKey(i) + index.ToString()).Value
                            ojTime = worksheet.Cells(ColKey(i) + index.ToString()).Value
                            If IsNothing(ojTime) And IsNothing(ojTime) Then
                                Primary_Value.Add(New DateTime(1900, 1, 1))
                                MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + GetLanguagesTranslated("Popup.Banluuytruongkhoakhongduocdetrong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            Else
                                If IsNothing(ojDate) Then
                                    dtDate = New DateTime(2001, 1, 1)
                                Else
                                    If dtDate.GetType.ToString = "System.Double" Then
                                        dtDate = DateTime.FromOADate(ojDate)
                                    Else
                                        dtDate = CType(ojDate, DateTime)
                                    End If

                                End If
                                If IsNothing(ojTime) Then
                                    Primary_Value.Add(dtDate)
                                Else
                                    If ojTime.GetType.ToString = "System.Double" Then
                                        dtTime = DateTime.FromOADate(ojTime)
                                    Else
                                        dtTime = CType(ojTime, DateTime)
                                    End If
                                    Primary_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                                End If
                            End If
                        Else
                            If worksheet.Cells(ColKey(i) + index.ToString()).Text.Trim <> String.Empty Then
                                Primary_Value.Add(worksheet.Cells(ColKey(i) + index.ToString()).Value)
                            Else
                                MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + GetLanguagesTranslated("Popup.Banluuytruongkhoakhongduocdetrong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            End If
                        End If
                    Next
                    For i As Integer = 0 To ColDatamember.Length - 1
                        worksheet.Cells(ColDatamember(i) + index.ToString()).Calculate
                        If tableInf.Select("COLUMN_NAME='" + Datamember(i) + "'")(0)("DATA_TYPE") = "datetime" Then
                            ojDate = worksheet.Cells(ColDatamember(i) + index.ToString()).Value
                            ojTime = worksheet.Cells(ColDatamember(i) + index.ToString()).Value
                            If IsNothing(ojTime) Then
                                Datamember_Value.Add(New DateTime(1900, 1, 1))
                            Else
                                If IsNothing(ojDate) Then
                                    dtDate = dtfromdate
                                Else
                                    'dtDate = CType(ojDate, DateTime)
                                    If ojDate.GetType.ToString = "System.Double" Then
                                        dtDate = DateTime.FromOADate(ojDate)
                                    Else
                                        dtDate = CType(ojDate, DateTime)
                                    End If
                                    If Datamember(i).ToUpper = "StartedDate".ToUpper Then
                                        StartedDate = dtDate
                                    End If
                                    If TableName = "HR_EmployeeRegisMaternityLeave" Then
                                        If worksheet.Cells(ColDatamember(i) + LineConfigDatamember.ToString()).Text.ToUpper = "FROMDATE" Then
                                            dtfromdate = dtDate
                                        End If
                                    End If
                                    If TableName = "HR_EmployeeWarning" Then
                                        If worksheet.Cells(ColDatamember(i) + LineConfigDatamember.ToString()).Text.ToUpper = "DATE_" Then
                                            dtfromdate = dtDate
                                        End If
                                    End If
                                End If
                                If IsNothing(ojTime) Then
                                    Datamember_Value.Add(dtDate)
                                Else
                                    If ojTime.GetType.ToString = "System.Double" Then
                                        dtTime = DateTime.FromOADate(ojTime)
                                    Else
                                        dtTime = CType(ojTime, DateTime)
                                    End If
                                    Datamember_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                                End If
                            End If
                        Else
                            'worksheet.Cells(ColDatamember(i) + index.ToString()).Calculate()
                            Datamember_Value.Add(worksheet.Cells(ColDatamember(i) + index.ToString()).Value)
                        End If
                    Next

                    If FieldInserDate <> String.Empty Then
                        Datamember_Value.Add(Now)
                    End If
                    If FieldUserName <> String.Empty Then
                        Datamember_Value.Add(obj.UserName)
                    End If
                    If LuuKhongGhiLog(False, TableName, Primary, Primary_Value.ToArray, Datamember, Datamember_Value.ToArray) = False Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                    index += 1
                End If
            End While
        End Using
        MessageBox.Show(GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function
    Public Function NhapExcelToDatableEPPlus(ByVal TableName As String, ByVal LineConfigDatamember As Integer, ByVal LineStart As Integer) As DataTable
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim ColIndex As Integer = 0
            Dim i As Integer
            Dim Table As DataTable
            Dim LoiDuLieu As String
            Table = New DataTable("TableName")
            Dim bCheckAddGrid As Boolean
            Dim tableInf As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
            For Each r As DataRow In tableInf.Rows
                Dim cl As DataColumn = New DataColumn(r("COLUMN_NAME"))
                If r("DATA_TYPE") = "datetime" Or r("DATA_TYPE") = "date" Then
                    cl.DataType = System.Type.GetType("System.DateTime")
                ElseIf r("DATA_TYPE") = "float" Then
                    cl.DataType = System.Type.GetType("System.Double")
                ElseIf r("DATA_TYPE") = "int" Then
                    cl.DataType = System.Type.GetType("System.Int32")
                Else
                    cl.DataType = System.Type.GetType("System.String")
                End If
                Table.Columns.Add(cl)
            Next
            If TableName.ToUpper = "HR_Transfer".ToUpper Or TableName.ToUpper = "SmartBooks_Employee_Family".ToUpper Or TableName.ToUpper = "HR_EmployeeRegisMaternityLeave".ToUpper Or TableName.ToUpper = "HR_MaxOvertime".ToUpper Or TableName.ToUpper = "HR_TerminationAsignment".ToUpper Or TableName.ToUpper = "HR_RoundShift".ToUpper Or TableName.ToUpper = "SmartBooks_Employee".ToUpper Then
                Dim clKiemTraDuLieuNhap As DataColumn = New DataColumn("KiemTraDuLieuNhap")
                clKiemTraDuLieuNhap.DataType = System.Type.GetType("System.String")
                Table.Columns.Add(clKiemTraDuLieuNhap)
            End If
            Dim bKiemTraConDuLieuNhap As Boolean
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = LineStart
                Try
                    bKiemTraConDuLieuNhap = True
                    While 1 = 1
                        bKiemTraConDuLieuNhap = False
                        For i = 0 To ColExel.Length - 1
                            If worksheet.Cells(ColExel(i) + index.ToString).Text.Trim <> String.Empty Then
                                bKiemTraConDuLieuNhap = True
                                Exit For
                            End If
                        Next
                        If bKiemTraConDuLieuNhap = False Then
                            Exit While
                        End If
                        Dim newRow As DataRow = Table.NewRow
                        LoiDuLieu = String.Empty
                        For ColIndex = 0 To ColExel.Length - 1
                            If worksheet.Cells(ColExel(ColIndex) + LineConfigDatamember.ToString).Text.Trim <> String.Empty Then
                                If Not IsNothing(worksheet.Cells(ColExel(ColIndex) + index.ToString).Value) Then
                                    If worksheet.Cells(ColExel(ColIndex) + index.ToString).Value.GetType.Name = "ExcelErrorValue" Then
                                        MessageBox.Show(GetLanguagesTranslated("Popup.Banvuilongkiemtragiatricot") + ": " + ColExel(ColIndex) + " " + GetLanguagesTranslated("Popup.Dong") + ": " + index.ToString + " " + GetLanguagesTranslated("Popup.Dulieukhonghople"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Return Nothing
                                    Else
                                        If CStr(worksheet.Cells(ColExel(ColIndex) + index.ToString).Value).Trim <> String.Empty Then
                                            If Table.Columns.Contains(worksheet.Cells(ColExel(ColIndex) + LineConfigDatamember.ToString).Text.Trim) Then
                                                If Table.Columns(worksheet.Cells(ColExel(ColIndex) + LineConfigDatamember.ToString).Text.Trim).DataType.FullName = "System.DateTime" Then
                                                    If worksheet.Cells(ColExel(ColIndex) + index.ToString).Value.GetType.ToString = "System.Double" Then
                                                        newRow(worksheet.Cells(ColExel(ColIndex) + LineConfigDatamember.ToString).Text.Trim) = DateTime.FromOADate(worksheet.Cells(ColExel(ColIndex) + index.ToString).Value)
                                                    Else
                                                        newRow(worksheet.Cells(ColExel(ColIndex) + LineConfigDatamember.ToString).Text.Trim) = worksheet.Cells(ColExel(ColIndex) + index.ToString).Value
                                                    End If
                                                Else
                                                    newRow(worksheet.Cells(ColExel(ColIndex) + LineConfigDatamember.ToString).Text.Trim) = worksheet.Cells(ColExel(ColIndex) + index.ToString).Value
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        If TableName.ToUpper = "HR_EmployeeRegisMaternityLeave".ToUpper Then
                            newRow("PlanStatus") = ReturnLeavePlanStatus(newRow("Employee_ID"), newRow("fromdate"))
                        End If
                        bCheckAddGrid = True
                        For Each r As DataRow In tableInf.Rows
                            If r("IS_NULLABLE") = "NO" And IsDBNull(r("IdentityName")) Then
                                If IsDBNull(newRow(r("COLUMN_NAME"))) Then
                                    LoiDuLieu += r("COLUMN_NAME") + "; "
                                    bCheckAddGrid = False
                                End If
                            End If
                            'If Not IsDBNull(r("PrimaryName")) Then
                            '    If TableName.ToUpper = "HR_TimeKeeping_Data".ToUpper And CStr(r("PrimaryName")).ToUpper = "CardNumber".ToUpper Then
                            '        If IsDBNull(newRow("Employee_ID")) Then
                            '            bCheckAddGrid = False
                            '        End If
                            '    Else
                            '        If IsDBNull(newRow(r("PrimaryName"))) Then
                            '            bCheckAddGrid = False
                            '        End If
                            '    End If
                            'End If
                        Next
                        If bCheckAddGrid = True Then
                            Table.Rows.Add(newRow)
                        Else
                            If TableName.ToUpper = "SmartBooks_Employee".ToUpper Then
                                If LoiDuLieu.ToUpper = "EMPLOYEE_ID; " Then
                                    Table.Rows.Add(newRow)
                                Else
                                    MessageBox.Show(GetLanguagesTranslated("Popup.Dong") + " " + index.ToString + " " + GetLanguagesTranslated("Popup.Khongtheduocnhaplenluoividulieubisaidinhdangbankiemtrakey") + ": " + LoiDuLieu.Replace("Employee_ID; ", ""), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit While
                                End If
                            ElseIf TableName.ToUpper = "HR_Transfer".ToUpper Then
                                If LoiDuLieu.ToUpper = "TYPEOFTRANSFER; " Then
                                    Table.Rows.Add(newRow)
                                Else
                                    MessageBox.Show(GetLanguagesTranslated("Popup.Dong") + " " + index.ToString + " " + GetLanguagesTranslated("Popup.Khongtheduocnhaplenluoividulieubisaidinhdangbankiemtrakey") + ": " + LoiDuLieu.Replace("Employee_ID; ", ""), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit While
                                End If
                            Else
                                MessageBox.Show(GetLanguagesTranslated("Popup.Dong") + " " + index.ToString + " " + GetLanguagesTranslated("Popup.Khongtheduocnhaplenluoividulieubisaidinhdangbankiemtrakey") + ": " + LoiDuLieu, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit While
                            End If
                        End If
                        index += 1
                    End While
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

            End Using
            'Table.AcceptChanges()
            Return Table
        End If
    End Function
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Function NhapExcelInteropExcel(ByVal TableName As String, ByVal LinkOfFile As String, ByVal LineConfigDatamember As Integer, ByVal LineConfigPrimary As Integer, ByVal LineStart As Integer, Optional ByVal FieldInserDate As String = "", Optional ByVal FieldUserName As String = "") As Boolean
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ"}
        Dim str As String
        Dim Datamember As String()
        Dim Datamember_Value As New ArrayList
        Dim Primary As String()
        Dim Primary_Value As New ArrayList
        Dim ColDatamember As New ArrayList
        Dim ColKey As New ArrayList
        Dim ojDate, ojTime As Object
        Dim dtDate, dtTime, dtfromdate, StartedDate As DateTime
        Dim tableInf As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
        'Dim excel As New FileInfo(LinkOfFile)

        Dim xlApp As Excel1.Application
        Dim xlWorkBook As Excel1.Workbook
        Dim xlWorkSheet As Excel1.Worksheet

        xlApp = New Excel1.Application
        xlWorkBook = xlApp.Workbooks.Open(LinkOfFile)
        xlWorkSheet = xlWorkBook.Worksheets(1)
        Try
            For i As Integer = 1 To ColExel.Length
                'MessageBox.Show(xlWorkSheet.Cells(LineConfigDatamember, i).Value)
                If xlWorkSheet.Cells(LineConfigDatamember, i).Value <> "" Then
                    If tableInf.Select("COLUMN_NAME='" + xlWorkSheet.Cells(LineConfigDatamember, i).Value.ToString.Trim + "'").Length > 0 Then
                        str += xlWorkSheet.Cells(LineConfigDatamember, i).Value.ToString.Trim + ","
                        ColDatamember.Add(i)
                    End If
                End If
            Next
            If str <> String.Empty Then
                If FieldInserDate <> String.Empty Then
                    str += FieldInserDate + ","
                End If
                If FieldUserName <> String.Empty Then
                    str += FieldUserName + ","
                End If
                Datamember = Split(str.Remove(str.Length - 1, 1), ",")
            End If
            str = String.Empty
            For i As Integer = 1 To ColExel.Length
                If xlWorkSheet.Cells(LineConfigPrimary, i).value <> "" Then
                    If tableInf.Select("COLUMN_NAME='" + xlWorkSheet.Cells(LineConfigPrimary, i).value.ToString.Trim + "'").Length > 0 Then
                        str += xlWorkSheet.Cells(LineConfigPrimary, i).value.ToString.Trim + ","
                        ColKey.Add(i)
                    End If
                End If
            Next

            If str <> String.Empty Then
                Primary = Split(str.Remove(str.Length - 1, 1), ",")
            End If
            Dim index As Integer = LineStart
            Dim CheckSavingCompleted As Integer = 0
            While CheckSavingCompleted < 2
                If xlWorkSheet.Cells(index, ColKey(0)).value = String.Empty Then
                    CheckSavingCompleted += 1
                Else
                    CheckSavingCompleted = 0
                End If
                If CheckSavingCompleted = 0 Then
                    Primary_Value.Clear()
                    Datamember_Value.Clear()
                    For i As Integer = 0 To ColKey.Count - 1
                        'Worksheet.Cells(index,ColKey(i)).Calculate
                        If tableInf.Select("COLUMN_NAME='" + Primary(i) + "'")(0)("DATA_TYPE") = "datetime" Then
                            ojDate = xlWorkSheet.Cells(index, ColKey(i)).Value
                            ojTime = xlWorkSheet.Cells(index, ColKey(i)).Value
                            If IsNothing(ojTime) And IsNothing(ojTime) Then
                                Primary_Value.Add(New DateTime(1900, 1, 1))
                                MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + GetLanguagesTranslated("Popup.Banluuytruongkhoakhongduocdetrong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            Else
                                If IsNothing(ojDate) Then
                                    dtDate = New DateTime(2001, 1, 1)
                                Else
                                    If dtDate.GetType.ToString = "System.Double" Then
                                        dtDate = DateTime.FromOADate(ojDate)
                                    Else
                                        dtDate = CType(ojDate, DateTime)
                                    End If

                                End If
                                If IsNothing(ojTime) Then
                                    Primary_Value.Add(dtDate)
                                Else
                                    If ojTime.GetType.ToString = "System.Double" Then
                                        dtTime = DateTime.FromOADate(ojTime)
                                    Else
                                        dtTime = CType(ojTime, DateTime)
                                    End If
                                    Primary_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                                End If
                            End If
                        Else
                            If xlWorkSheet.Cells(index, ColKey(i)).value.ToString <> String.Empty Then
                                Primary_Value.Add(xlWorkSheet.Cells(index, ColKey(i)).Value)
                            Else
                                MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + GetLanguagesTranslated("Popup.Banluuytruongkhoakhongduocdetrong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return False
                            End If
                        End If
                    Next
                    For i As Integer = 0 To ColDatamember.Count - 1
                        'xlWorkSheet.Cells(index, ColDatamember(i)).Calculate
                        If tableInf.Select("COLUMN_NAME='" + Datamember(i) + "'")(0)("DATA_TYPE") = "datetime" Then
                            ojDate = xlWorkSheet.Cells(index, ColDatamember(i)).Value
                            ojTime = xlWorkSheet.Cells(index, ColDatamember(i)).Value
                            If IsNothing(ojTime) Then
                                Datamember_Value.Add(New DateTime(1900, 1, 1))
                            Else
                                If IsNothing(ojDate) Then
                                    dtDate = dtfromdate
                                Else
                                    'dtDate = CType(ojDate, DateTime)
                                    If ojDate.GetType.ToString = "System.Double" Then
                                        dtDate = DateTime.FromOADate(ojDate)
                                    Else
                                        dtDate = CType(ojDate, DateTime)
                                    End If
                                    If Datamember(i).ToUpper = "StartedDate".ToUpper Then
                                        StartedDate = dtDate
                                    End If
                                    If TableName = "HR_EmployeeRegisMaternityLeave" Then
                                        If xlWorkSheet.Cells(LineConfigDatamember, ColDatamember(i)).Value.ToString.ToUpper = "FROMDATE" Then
                                            dtfromdate = dtDate
                                        End If
                                    End If
                                    If TableName = "HR_EmployeeWarning" Then
                                        If xlWorkSheet.Cells(LineConfigDatamember, ColDatamember(i)).Value.ToString.ToUpper = "DATE_" Then
                                            dtfromdate = dtDate
                                        End If
                                    End If
                                End If
                                If IsNothing(ojTime) Then
                                    Datamember_Value.Add(dtDate)
                                Else
                                    If ojTime.GetType.ToString = "System.Double" Then
                                        dtTime = DateTime.FromOADate(ojTime)
                                    Else
                                        dtTime = CType(ojTime, DateTime)
                                    End If
                                    Datamember_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                                End If
                            End If
                        Else
                            'worksheet.Cells(ColDatamember(i) + index.ToString()).Calculate()
                            Datamember_Value.Add(xlWorkSheet.Cells(index, ColDatamember(i)).Value)
                        End If
                    Next

                    If FieldInserDate <> String.Empty Then
                        Datamember_Value.Add(Now)
                    End If
                    If FieldUserName <> String.Empty Then
                        Datamember_Value.Add(obj.UserName)
                    End If
                    If LuuKhongGhiLog(False, TableName, Primary, Primary_Value.ToArray, Datamember, Datamember_Value.ToArray) = False Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If
                index += 1
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'edit the cell with new value
        ' xlWorkSheet.Cells(2, 2) = "http://vb.net-informations.com"
        xlWorkBook.Save()
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        MessageBox.Show(GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function

    Public Function NhapExcelToDatableEPPlus_ChuyenKhoa(ByVal LineStart As Integer) As DataTable
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim ColIndex As Integer = 0
            Dim Table As DataTable
            Dim LoiDuLieu As String
            Table = New DataTable("TableName")
            Dim bCheckAddGrid As Boolean
            Dim clEmployee_ID As DataColumn = New DataColumn("Employee_ID")
            clEmployee_ID.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clEmployee_ID)
            Dim clPositionNew As DataColumn = New DataColumn("PositionNew")
            clPositionNew.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clPositionNew)
            Dim clJobCodeNew As DataColumn = New DataColumn("JobCodeNew")
            clJobCodeNew.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clJobCodeNew)
            Dim clEffectiveDate As DataColumn = New DataColumn("EffectiveDate")
            clEffectiveDate.DataType = System.Type.GetType("System.DateTime")
            Table.Columns.Add(clEffectiveDate)
            Dim clRemark As DataColumn = New DataColumn("Remark")
            clRemark.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clRemark)
            Dim clKiemTraDuLieuNhap As DataColumn = New DataColumn("KiemTraDuLieuNhap")
            clKiemTraDuLieuNhap.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clKiemTraDuLieuNhap)
            Dim clInsertDate As DataColumn = New DataColumn("InsertDate")
            clInsertDate.DataType = System.Type.GetType("System.DateTime")
            Table.Columns.Add(clInsertDate)
            Dim clUserName As DataColumn = New DataColumn("UserName")
            clUserName.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clUserName)
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = LineStart
                While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty
                    Dim newRow As DataRow = Table.NewRow
                    LoiDuLieu = String.Empty
                    If Not IsNothing(worksheet.Cells("A" + index.ToString).Value) Then
                        newRow("Employee_ID") = worksheet.Cells("A" + index.ToString).Value
                    End If
                    If Not IsNothing(worksheet.Cells("B" + index.ToString).Value) Then
                        newRow("PositionNew") = worksheet.Cells("B" + index.ToString).Value
                    End If
                    If Not IsNothing(worksheet.Cells("C" + index.ToString).Value) Then
                        newRow("JobCodeNew") = worksheet.Cells("C" + index.ToString).Value
                    End If
                    If Not IsNothing(worksheet.Cells("D" + index.ToString).Value) Then
                        If worksheet.Cells("D" + index.ToString).Value.GetType.ToString = "System.Double" Then
                            newRow("EffectiveDate") = DateTime.FromOADate(worksheet.Cells("D" + index.ToString).Value)
                        Else
                            newRow("EffectiveDate") = worksheet.Cells("D" + index.ToString).Value
                        End If
                    End If
                    If Not IsNothing(worksheet.Cells("E" + index.ToString).Value) Then
                        newRow("Remark") = worksheet.Cells("E" + index.ToString).Value
                    End If
                    Table.Rows.Add(newRow)
                    index += 1
                End While
            End Using
            Return Table
        End If
    End Function
    Public Function NhapExcelToDatableEPPlus_ChuyenChucVu(ByVal LineStart As Integer) As DataTable
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim ColIndex As Integer = 0
            Dim Table As DataTable
            Dim LoiDuLieu As String
            Table = New DataTable("TableName")
            Dim bCheckAddGrid As Boolean
            Dim clEmployee_ID As DataColumn = New DataColumn("Employee_ID")
            clEmployee_ID.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clEmployee_ID)
            Dim clPosition_IDNew As DataColumn = New DataColumn("Position_IDNew")
            clPosition_IDNew.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clPosition_IDNew)
            Dim clEffectiveDate As DataColumn = New DataColumn("EffectiveDate")
            clEffectiveDate.DataType = System.Type.GetType("System.DateTime")
            Table.Columns.Add(clEffectiveDate)
            Dim clRemark As DataColumn = New DataColumn("Remark")
            clRemark.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clRemark)
            Dim clKiemTraDuLieuNhap As DataColumn = New DataColumn("KiemTraDuLieuNhap")
            clKiemTraDuLieuNhap.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clKiemTraDuLieuNhap)
            Dim clInsertDate As DataColumn = New DataColumn("InsertDate")
            clInsertDate.DataType = System.Type.GetType("System.DateTime")
            Table.Columns.Add(clInsertDate)
            Dim clUserName As DataColumn = New DataColumn("UserName")
            clUserName.DataType = System.Type.GetType("System.String")
            Table.Columns.Add(clUserName)
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim index As Integer = LineStart
                While worksheet.Cells("A" + index.ToString).Text.Trim <> String.Empty
                    Dim newRow As DataRow = Table.NewRow
                    LoiDuLieu = String.Empty
                    If Not IsNothing(worksheet.Cells("A" + index.ToString).Value) Then
                        newRow("Employee_ID") = worksheet.Cells("A" + index.ToString).Value
                    End If
                    If Not IsNothing(worksheet.Cells("B" + index.ToString).Value) Then
                        newRow("Position_IDNew") = worksheet.Cells("B" + index.ToString).Value
                    End If
                    If Not IsNothing(worksheet.Cells("C" + index.ToString).Value) Then
                        newRow("EffectiveDate") = worksheet.Cells("C" + index.ToString).Value
                    End If
                    If Not IsNothing(worksheet.Cells("D" + index.ToString).Value) Then
                        newRow("Remark") = worksheet.Cells("D" + index.ToString).Value
                    End If
                    Table.Rows.Add(newRow)
                    index += 1
                End While
            End Using
            Return Table
        End If
    End Function
    Public Function NhapExcel(ByVal SheetName As String, ByVal TableName As String, ByVal LinkOfFile As String, ByVal LineConfigDatamember As Integer, ByVal LineConfigPrimary As Integer, ByVal LineStart As Integer, Optional ByVal FieldInserDate As String = "", Optional ByVal FieldUserName As String = "") As Boolean
        'Dim ofd As New OpenFileDialog
        'With ofd
        '    .FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
        '    .Title = "Locate File"
        '    .Filter = "Excel file (*.xls)|*.xls|All files (*.*)|*.*"
        'End With
        Dim b As Boolean = True
        'Dim result As Integer = MessageBox.Show("Bạn có thực sự muốn cập nhật thông tin nhân viên!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If result = DialogResult.No Then
        '    b = False
        'End If
        Dim urlTemplate As String = LinkOfFile
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        Dim Xls As New XlsReport
        Xls.FileName = urlTemplate
        Xls.Start.File()
        Xls.Page.Begin(SheetName, "1")
        Xls.Page.Name = SheetName
        Dim str, strData, strColKey As String
        Dim Datamember As String()
        Dim Datamember_Value As New ArrayList
        Dim Primary As String()
        Dim Primary_Value As New ArrayList
        Dim ColDatamember As String()
        Dim ColKey As String()
        Dim ojDate, ojTime As Object
        Dim dtDate, dtTime, dtfromdate As DateTime
        Dim tableInf As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] '" + TableName + "'", "table")
        'Dim tab As DataTable = kn.ReadData("select top 1 * from [" + TableName + "]", "table")
        For Each c As String In ColExel
            If CStr(Xls.Cell(c + LineConfigDatamember.ToString).Value).Trim <> "" Then
                str += CStr(Xls.Cell(c + LineConfigDatamember.ToString).Value).Trim + ","
                strData += c + ","
            End If
        Next
        If str <> String.Empty Then
            If FieldInserDate <> String.Empty Then
                str += FieldInserDate + ","
            End If
            If FieldUserName <> String.Empty Then
                str += FieldUserName + ","
            End If
            Datamember = Split(str.Remove(str.Length - 1, 1), ",")
            ColDatamember = Split(strData.Remove(strData.Length - 1, 1), ",")
        End If
        str = String.Empty
        For Each c As String In ColExel
            If CStr(Xls.Cell(c + LineConfigPrimary.ToString).Value).Trim <> "" Then
                If tableInf.Select("COLUMN_NAME='" + CStr(Xls.Cell(c + LineConfigPrimary.ToString).Value).Trim + "'").Count > 0 Then
                    str += CStr(Xls.Cell(c + LineConfigPrimary.ToString).Value).Trim + ","
                    strColKey += c + ","
                End If
            End If
        Next
        If str <> String.Empty Then
            Primary = Split(str.Remove(str.Length - 1, 1), ",")
            ColKey = Split(strColKey.Remove(strColKey.Length - 1, 1), ",")
        End If
        Dim index As Integer = LineStart, isDataNull As Integer = 0
        While Xls.Cell(ColKey(0) + index.ToString).Value <> String.Empty Or isDataNull < 2
            If Xls.Cell(ColKey(0) + index.ToString).Value = String.Empty Then
                isDataNull += 1
                index += 1
            Else
                isDataNull = 0
                Primary_Value.Clear()
                Datamember_Value.Clear()
                For i As Integer = 0 To ColKey.Length - 1
                    If tableInf.Select("COLUMN_NAME='" + Primary(i) + "'")(0)("DATA_TYPE") = "datetime" Then
                        ojDate = CheckExcelNull(Xls, ColKey(i) + index.ToString(), ObjectType.DateType, "Null").Replace("'", "")
                        ojTime = CheckExcelNull(Xls, ColKey(i) + index.ToString(), ObjectType.TimeType, "Null").Replace("'", "")
                        If (ojDate = "" Or CStr(ojDate).ToUpper = "NULL") And (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                            Primary_Value.Add(New DateTime(1900, 1, 1))
                            MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ". " + GetLanguagesTranslated("Popup.Banluuytruongkhoakhongduocdetrong"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            b = False
                            Exit While
                        Else
                            If CStr(ojDate).ToUpper = "NULL" Then
                                dtDate = New DateTime(2001, 1, 1)
                            Else
                                dtDate = CType(ojDate, DateTime)
                            End If
                            If (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                                Primary_Value.Add(dtDate)
                            Else
                                dtTime = CType(ojTime, DateTime)
                                Primary_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                            End If
                        End If
                    Else
                        If CStr(Xls.Cell(ColKey(i) + index.ToString).Value).Trim <> String.Empty Then
                            Primary_Value.Add(CStr(Xls.Cell(ColKey(i) + index.ToString).Value).Trim)
                        Else
                            'MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString + ", bạn lưu ý trường khóa không được để trống.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'b = False
                            Exit While
                        End If
                    End If
                Next
                For i As Integer = 0 To ColDatamember.Length - 1
                    If tableInf.Select("COLUMN_NAME='" + Datamember(i) + "'")(0)("DATA_TYPE") = "datetime" Then
                        ojDate = CheckExcelNull(Xls, ColDatamember(i) + index.ToString(), ObjectType.DateType, "Null").Replace("'", "")
                        ojTime = CheckExcelNull(Xls, ColDatamember(i) + index.ToString(), ObjectType.TimeType, "Null").Replace("'", "")
                        If (ojDate = "" Or CStr(ojDate).ToUpper = "NULL") And (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                            Datamember_Value.Add(New DateTime(1900, 1, 1))
                            'MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString + ", bạn lưu ý trường khóa không được để trống.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'b = False
                            'Exit While
                        Else
                            If CStr(ojDate).ToUpper = "NULL" Or ojDate = "'0001-01-01'" Then
                                dtDate = dtfromdate
                            Else
                                dtDate = CType(ojDate, DateTime)
                                If TableName = "HR_EmployeeRegisMaternityLeave" Then
                                    If CStr(Xls.Cell(ColDatamember(i) + LineConfigDatamember.ToString()).Value).Trim.ToUpper = "FROMDATE" Then
                                        dtfromdate = dtDate
                                    End If
                                End If
                                If TableName = "HR_EmployeeWarning" Then
                                    If CStr(Xls.Cell(ColDatamember(i) + LineConfigDatamember.ToString()).Value).Trim.ToUpper = "DATE_" Then
                                        dtfromdate = dtDate
                                    End If
                                End If
                            End If
                            If (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                                Datamember_Value.Add(dtDate)
                            Else
                                dtTime = CType(ojTime, DateTime)
                                Datamember_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                            End If
                        End If
                    Else
                        Datamember_Value.Add(CStr(Xls.Cell(ColDatamember(i) + index.ToString).Value).Trim)
                    End If
                Next

                If FieldInserDate <> String.Empty Then
                    Datamember_Value.Add(Now)
                End If
                If FieldUserName <> String.Empty Then
                    Datamember_Value.Add(obj.UserName)
                End If
                If LuuKhongGhiLog(False, TableName, Primary, Primary_Value.ToArray, Datamember, Datamember_Value.ToArray) = False Then
                    MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    b = False
                    Exit While
                End If
                index += 1
            End If
        End While
        MessageBox.Show(GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Xls.Page.End()
        Xls.Out.File(urlTemplate)
        Return b
    End Function
    Public Function NhapExcel(ByVal SheetName As String, ByVal TableName As String, ByVal LineConfigDatamember As Integer, ByVal LineConfigPrimary As Integer, ByVal LineStart As Integer, ByVal PathOfFile As String, Optional ByVal FieldInserDate As String = "", Optional ByVal FieldUserName As String = "") As Boolean
        Dim b As Boolean = True
        If PathOfFile <> String.Empty Then
            'Dim result As Integer = MessageBox.Show("Bạn có thực sự muốn cập nhật thông tin nhân viên!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If result = DialogResult.No Then
            '    b = False
            'End If
            Dim urlTemplate As String = PathOfFile
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim Xls As New XlsReport
            Xls.FileName = urlTemplate
            Xls.Start.File()
            Xls.Page.Begin(SheetName, "1")
            Xls.Page.Name = SheetName
            Dim str, strData, strColKey As String
            Dim Datamember As String()
            Dim Datamember_Value As New ArrayList
            Dim Primary As String()
            Dim Primary_Value As New ArrayList
            Dim ColDatamember As String()
            Dim ColKey As String()
            Dim ojDate, ojTime As Object
            Dim dtDate, dtTime, dtfromdate As DateTime
            Dim tab As DataTable = kn.ReadData("select top 1 * from [" + TableName + "]", "table")
            For Each c As String In ColExel
                If CStr(Xls.Cell(c + LineConfigDatamember.ToString).Value).Trim <> "" Then
                    str += CStr(Xls.Cell(c + LineConfigDatamember.ToString).Value).Trim + ","
                    strData += c + ","
                End If
            Next
            If str <> String.Empty Then
                If FieldInserDate <> String.Empty Then
                    str += FieldInserDate + ","
                End If
                If FieldUserName <> String.Empty Then
                    str += FieldUserName + ","
                End If
                Datamember = Split(str.Remove(str.Length - 1, 1), ",")
                ColDatamember = Split(strData.Remove(strData.Length - 1, 1), ",")
            End If
            str = String.Empty
            For Each c As String In ColExel
                If CStr(Xls.Cell(c + LineConfigPrimary.ToString).Value).Trim <> "" Then
                    str += CStr(Xls.Cell(c + LineConfigPrimary.ToString).Value).Trim + ","
                    strColKey += c + ","
                End If
            Next
            If str <> String.Empty Then
                Primary = Split(str.Remove(str.Length - 1, 1), ",")
                ColKey = Split(strColKey.Remove(strColKey.Length - 1, 1), ",")
            End If
            Dim index As Integer = LineStart, isDataNull As Integer = 0
            While CStr(Xls.Cell(ColKey(0) + index.ToString).Value).Trim <> String.Empty Or isDataNull < 2
                If CStr(Xls.Cell(ColKey(0) + index.ToString).Value).Trim = String.Empty Then
                    isDataNull += 1
                    index += 1
                Else
                    'If CStr(Xls.Cell("D" + index.ToString).Value).Trim = "M092" Then
                    '    Dim iii As Integer = 0
                    'End If
                    Primary_Value.Clear()
                    Datamember_Value.Clear()
                    For i As Integer = 0 To ColKey.Length - 1
                        If tab.Columns(Primary(i)).DataType.ToString = "System.DateTime" Then
                            ojDate = CheckExcelNull(Xls, ColKey(i) + index.ToString(), ObjectType.DateType, "Null")
                            ojTime = CheckExcelNull(Xls, ColKey(i) + index.ToString(), ObjectType.TimeType, "Null")
                            If (ojDate = "" Or CStr(ojDate).ToUpper = "NULL") And (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                                Primary_Value.Add(New DateTime(1900, 1, 1))
                                'MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString + ", bạn lưu ý trường khóa không được để trống.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                b = False
                                Exit While
                            Else
                                If CStr(ojDate).ToUpper = "NULL" Then
                                    dtDate = New DateTime(2001, 1, 1)
                                Else
                                    dtDate = CType(ojDate, DateTime)
                                End If
                                If (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                                    Primary_Value.Add(dtDate)
                                Else
                                    dtTime = CType(ojTime, DateTime)
                                    Primary_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                                End If
                            End If
                        Else
                            If CStr(Xls.Cell(ColKey(i) + index.ToString).Value).Trim <> String.Empty Then
                                Primary_Value.Add(CStr(Xls.Cell(ColKey(i) + index.ToString).Value).Trim)
                            Else
                                'MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString + ", bạn lưu ý trường khóa không được để trống.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                b = False
                                Exit While
                            End If
                        End If
                    Next
                    For i As Integer = 0 To ColDatamember.Length - 1
                        If tab.Columns(Datamember(i)).DataType.ToString = "System.DateTime" Then
                            ojDate = CheckExcelNull(Xls, ColDatamember(i) + index.ToString(), ObjectType.DateType, "Null")
                            ojTime = CheckExcelNull(Xls, ColDatamember(i) + index.ToString(), ObjectType.TimeType, "Null")
                            If (ojDate = "" Or CStr(ojDate).ToUpper = "NULL") And (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                                Datamember_Value.Add(New DateTime(1900, 1, 1))
                                'MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString + ", bạn lưu ý trường khóa không được để trống.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                'b = False
                                'Exit While
                            Else
                                If CStr(ojDate).ToUpper = "NULL" Or ojDate = "'0001-01-01'" Then
                                    dtDate = dtfromdate
                                Else
                                    dtDate = CType(ojDate, DateTime)
                                    If TableName = "HR_EmployeeRegisMaternityLeave" Then
                                        If CStr(Xls.Cell(ColDatamember(i) + LineConfigDatamember.ToString()).Value).Trim.ToUpper = "FROMDATE" Then
                                            dtfromdate = dtDate
                                        End If
                                    End If
                                    If TableName = "HR_EmployeeWarning" Then
                                        If CStr(Xls.Cell(ColDatamember(i) + LineConfigDatamember.ToString()).Value).Trim.ToUpper = "DATE_" Then
                                            dtfromdate = dtDate
                                        End If
                                    End If
                                End If
                                If (ojTime = "" Or CStr(ojTime).ToUpper = "NULL") Then
                                    Datamember_Value.Add(dtDate)
                                Else
                                    dtTime = CType(ojTime, DateTime)
                                    Datamember_Value.Add(New DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second))
                                End If
                            End If
                        Else
                            Datamember_Value.Add(CStr(Xls.Cell(ColDatamember(i) + index.ToString).Value).Trim)
                        End If
                    Next

                    If FieldInserDate <> String.Empty Then
                        Datamember_Value.Add(Now)
                    End If
                    If FieldUserName <> String.Empty Then
                        Datamember_Value.Add(obj.UserLogin)
                    End If
                    If LuuKhongGhiLog(False, TableName, Primary, Primary_Value.ToArray, Datamember, Datamember_Value.ToArray) = False Then
                        'MessageBox.Show("Có lỗi ở dòng thứ " + index.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        b = False
                        Exit While
                    End If
                    index += 1
                End If
            End While
            'MessageBox.Show("Thực hiện kết thúc!")
            Xls.Page.End()
            Xls.Out.File(urlTemplate)
            Return b
        Else
            Return False
        End If
    End Function

    Public Function NhapTemplateTheoThoiGian(ByVal TableName As String) As Boolean
        Dim ofd As New OpenFileDialog
        With ofd
            '.FileName = "C:" & "\" & "TempImport\Received Files" 'Points it to the received files folder
            .Title = "Locate File"
            .Filter = "Excel file (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        End With
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim result As Integer = MessageBox.Show(GetLanguagesTranslated("Popup.Bancothucsumuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Return False
            End If
            Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
            Dim excel As New FileInfo(ofd.FileName)
            Using package = New ExcelPackage(excel)
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
                Dim index, rowConfig, rowHeader, colStartDate As Integer

                colStartDate = ws.Cells("A1").Value
                rowHeader = ws.Cells("A2").Value
                rowConfig = ws.Cells("A3").Value
                index = ws.Cells("A4").Value
                Dim i As Integer
                Dim Employee_ID, WorkingDay, Value, SQLQuery, TenCotNgay, TenCotGiaTri, HourLeave As String
                TenCotNgay = IIf(TableName.ToUpper = "HR_EMPREGISTIMESHEET", "TimeDate", IIf(TableName.ToUpper = "HR_MAXOVERTIME", "workingdate", IIf(TableName.ToUpper = "HR_EMPREGISLEAVE", "DateLeave", "")))
                TenCotGiaTri = IIf(TableName.ToUpper = "HR_EMPREGISTIMESHEET", "ShiftName", IIf(TableName.ToUpper = "HR_MAXOVERTIME", "maxovertime", IIf(TableName.ToUpper = "HR_EMPREGISLEAVE", "LeaveType_ID", "")))

                While ws.Cells("C" + index.ToString).Text.Trim <> String.Empty
                    Employee_ID = ws.Cells("C" + index.ToString).Text.Trim
                    SQLQuery = String.Empty
                    For i = colStartDate To ColExel.Length - 1
                        If CDate(ws.Cells(ColExel(i) + rowConfig.ToString()).Value).Year <> 1 Then
                            WorkingDay = "'" + CDate(ws.Cells(ColExel(i) + rowConfig.ToString()).Value).ToString("yyyy-MM-dd") + "'"
                            Value = ws.Cells(ColExel(i) + index.ToString()).Value
                            If IsNothing(Value) Then
                                Value = String.Empty
                            End If
                            If TableName.ToUpper = "HR_EMPREGISLEAVE" Then
                                If Value.IndexOf("/") > 0 Then
                                    HourLeave = Value.Split("/")(1)
                                    Value = Value.Split("/")(0)
                                Else
                                    HourLeave = "8"
                                End If
                                If Value <> String.Empty Then
                                    SQLQuery += "if not exists(select * from " + TableName + " where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + ") " &
                                      "begin insert into " + TableName + " (Employee_ID," + TenCotNgay + "," + TenCotGiaTri + ",HourLeave,Remark,UserName,InsertDate) values('" + Employee_ID + "'," + WorkingDay + ",'" + Value + "','" + HourLeave + "',N'NhapTemplateTheoThoiGian',N'" + obj.UserName + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "') end " &
                                      "else begin update " + TableName + " set " + TenCotGiaTri + "='" + Value + "' where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " end "
                                Else
                                    SQLQuery += "delete " + TableName + " where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " "
                                End If
                            ElseIf TableName.ToUpper = "HR_MAXOVERTIME" Then
                                If Value <> String.Empty Then
                                    SQLQuery += "if not exists(select * from " + TableName + " where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " and TypeOfOT=1) " &
                                      "begin insert into " + TableName + " (Employee_ID," + TenCotNgay + "," + TenCotGiaTri + ",Remark,UserName,InsertDate) values('" + Employee_ID + "'," + WorkingDay + ",'" + Value + "',N'NhapTemplateTheoThoiGian',N'" + obj.UserName + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "') end " &
                                      "else begin update " + TableName + " set " + TenCotGiaTri + "='" + Value + "' where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " end "
                                Else
                                    SQLQuery += "delete " + TableName + " where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " and TypeOfOT=1 "
                                End If
                            Else
                                If Value <> String.Empty Then
                                    SQLQuery += "if not exists(select * from " + TableName + " where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + ") " &
                                      "begin insert into " + TableName + " (Employee_ID," + TenCotNgay + "," + TenCotGiaTri + ",Remark,UserName,InsertDate) values('" + Employee_ID + "'," + WorkingDay + ",'" + Value + "',N'NhapTemplateTheoThoiGian',N'" + obj.UserName + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "') end " &
                                      "else begin update " + TableName + " set " + TenCotGiaTri + "='" + Value + "' where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " end "
                                Else
                                    SQLQuery += "delete " + TableName + " where Employee_ID=N'" + Employee_ID + "' and " + TenCotNgay + "=" + WorkingDay + " "
                                End If
                            End If
                        End If

                    Next
                    If kn.SaveData(SQLQuery) = False Then
                        If MessageBox.Show(GetLanguagesTranslated("Popup.Coloitaidong") + ": " + index.ToString + ", " + GetLanguagesTranslated("Popup.Bancotieptucmuonnhap"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Return False
                        End If
                    End If
                    index += 1
                End While
                MessageBox.Show(GetLanguagesTranslated("Popup.Nhapthanhcong"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End Using
        End If
        Return False
    End Function
#End Region
    Public Sub SaveFileExcel(ByVal LinkFile As String)
        Dim xlApp As New Excel1.Application
        Dim xlWorkBook As Excel1.Workbook
        Dim xlWorkSheet As Excel1.Worksheet
        '~~> Opens Source Workbook. Change path and filename as applicable
        xlWorkBook = xlApp.Workbooks.Open(LinkFile)

        '~~> Display Excel
        xlApp.Visible = False

        '~~> Do some work

        '~~> Save the file
        xlWorkBook.Save()

        '~~> Close the file
        xlWorkBook.Close()
    End Sub
    Public Sub SaveFileExcelToBDF(ByVal LinkFileExcel As String)
        Dim excelApplication As Excel1.Application = New Excel1.Application
        Dim excelWorkbook As Excel1.Workbook = Nothing
        Dim paramSourceBookPath As String = LinkFileExcel
        Dim paramExportFilePath As String = LinkFileExcel.Remove(LinkFileExcel.Length - 5, 5) + ".pdf"
        Dim paramExportFormat As Excel1.XlFixedFormatType =
            Excel1.XlFixedFormatType.xlTypePDF
        Dim paramExportQuality As Excel1.XlFixedFormatQuality =
            Excel1.XlFixedFormatQuality.xlQualityStandard
        Dim paramOpenAfterPublish As Boolean = False
        Dim paramIncludeDocProps As Boolean = True
        Dim paramIgnorePrintAreas As Boolean = True
        Dim paramFromPage As Object = Type.Missing
        Dim paramToPage As Object = Type.Missing

        Try
            ' Open the source workbook.
            excelWorkbook = excelApplication.Workbooks.Open(paramSourceBookPath)

            ' Save it in the target format.
            If Not excelWorkbook Is Nothing Then
                excelWorkbook.ExportAsFixedFormat(paramExportFormat,
                    paramExportFilePath, paramExportQuality,
                    paramIncludeDocProps, paramIgnorePrintAreas,
                    paramFromPage, paramToPage, paramOpenAfterPublish)
            End If
        Catch ex As Exception
            ' Respond to the error.
        Finally
            ' Close the workbook object.
            If Not excelWorkbook Is Nothing Then
                excelWorkbook.Close(False)
                excelWorkbook = Nothing
            End If

            ' Quit Excel and release the ApplicationClass object.
            If Not excelApplication Is Nothing Then
                excelApplication.Quit()
                excelApplication = Nothing
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub
    Public Sub FindControl(ByVal NameOfControl As String, ByVal ParentControl As Control, ByRef ReturnControl As Control)
        If ParentControl.Name.ToUpper = NameOfControl.ToUpper Then
            ReturnControl = ParentControl
        Else
            If ParentControl.Controls.Count > 0 Then
                For Each ct As Control In ParentControl.Controls
                    FindControl(NameOfControl, ct, ReturnControl)
                Next
            End If
        End If
    End Sub

    'Public Sub LoadPosition(ByVal cbbPosition As Janus.Windows.GridEX.EditControls.MultiColumnCombo, ByVal TableName As String, ByVal DisplayMember As String, Optional ByVal Dept As String = "")
    '    Dim tab As DataTable
    '    cbbPosition.DisplayMember = DisplayMember
    '    tab = kn.ReadData("select * from [" + TableName + "] " + IIf(Dept <> "", "where DepartmentCode=N'" + Dept + "'", ""), "tab")
    '    cbbPosition.DataSource = tab
    'End Sub

    Public Sub GetDataOnDropDownCategory(ByVal cbbCategory As DevExpress.XtraEditors.LookUpEdit, ByVal CategoryFather As String) 'DevExpress.XtraEditors.LookUpEdit
        cbbCategory.Properties.DataSource = kn.ReadData("select * from HR_Category where CategoryFather='" + CategoryFather + "'", "Table") 'cbbCategory.Properties.DataSource
        cbbCategory.Properties.DisplayMember = "Name" + obj.Lan
    End Sub

    'Public Sub GetDataOnDropDownCategoryCodeName(ByVal cbbCategory As Janus.Windows.GridEX.EditControls.MultiColumnCombo, ByVal CategoryFather As String) 'DevExpress.XtraEditors.LookUpEdit
    '    cbbCategory.DataSource = kn.ReadData("select Category as Code, Name" + obj.Lan + " as Name from HR_Category where CategoryFather='" + CategoryFather + "'", "table")
    'End Sub
    Public Sub GetDataOnDropDownCategoryCodeName(ByVal cbbCategory As DevExpress.XtraEditors.LookUpEdit, ByVal CategoryFather As String) 'DevExpress.XtraEditors.LookUpEdit
        cbbCategory.Properties.DataSource = kn.ReadData("select Category as Code, Name" + obj.Lan + " as Name from HR_Category where CategoryFather='" + CategoryFather + "'", "table")
        cbbCategory.Properties.DisplayMember = "Name"
        cbbCategory.Properties.ValueMember = "Code"
        cbbCategory.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        cbbCategory.Properties.NullText = ""
    End Sub
    Public Sub SearchEmployee(ByVal cbbSearchEmployee As DevExpress.XtraEditors.LookUpEdit)
        cbbSearchEmployee.Properties.DataSource = kn.ReadData("select * from udf_FindEmployee()", "table")
        cbbSearchEmployee.Properties.DisplayMember = "EmployeeInformation"
        cbbSearchEmployee.Properties.ValueMember = "Employee_ID"
        cbbSearchEmployee.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        cbbSearchEmployee.Properties.NullText = ""
    End Sub
    Public Sub GetDataOnDropDownCategoryCodeName(ByVal cbbCategory As DevExpress.XtraEditors.LookUpEdit, ByVal tabCodeName As DataTable)
        cbbCategory.Properties.DataSource = tabCodeName
        cbbCategory.Properties.DisplayMember = "Name"
        cbbCategory.Properties.ValueMember = "Code"
        cbbCategory.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        cbbCategory.Properties.NullText = ""
    End Sub
    Public Sub GetDataOnDropDown(ByVal cbbDropDown As DevExpress.XtraEditors.LookUpEdit, ByVal tabCodeName As DataTable, ByVal DisplayName As String, ByVal ValueMember As String)
        cbbDropDown.Properties.DataSource = tabCodeName
        cbbDropDown.Properties.DisplayMember = DisplayName
        cbbDropDown.Properties.ValueMember = ValueMember
        cbbDropDown.Properties.BestFitMode = BestFitMode.BestFitResizePopup
        cbbDropDown.Properties.NullText = ""
    End Sub
    Public Sub GetDataOnDropDownCategoryCodeName(ByVal grid As GridView, ByVal KeyOfDropDown As String, ByVal CategoryFather As String)
        If Not IsNothing(grid.Columns(KeyOfDropDown)) Then
            Dim riLookup As New RepositoryItemLookUpEdit()
            riLookup.DataSource = kn.ReadData("select Category as Code, Name" + obj.Lan + " as Name from HR_Category where CategoryFather='" + CategoryFather + "'", "table")
            riLookup.ValueMember = "Code"
            riLookup.DisplayMember = "Name"
            riLookup.NullText = ""
            grid.Columns(KeyOfDropDown).ColumnEdit = riLookup
        End If
    End Sub

    Public Sub NhapDuLieuTuGridLenFormNhap(ByVal ctlControl As Control, ByVal dtRow As DataRow, ByVal ListOfFieldOfTable As String())
        If Not IsNothing(dtRow) Then
            For Each ct As Control In ctlControl.Controls
                If ListOfFieldOfTable.Contains(ct.Name.ToUpper) Then
                    If ct.GetType.ToString = "System.Windows.Forms.CheckBox" Then '"DevExpress.XtraEditors.CheckEdit"
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            CType(ct, System.Windows.Forms.CheckBox).Checked = dtRow(ct.Name)
                        Else
                            CType(ct, System.Windows.Forms.CheckBox).Checked = False
                        End If
                    ElseIf ct.GetType.ToString = "System.Windows.Forms.RadioButton" Then '"DevExpress.XtraEditors.RadioGroup"
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            CType(ct, System.Windows.Forms.RadioButton).Checked = dtRow(ct.Name)
                        Else
                            CType(ct, System.Windows.Forms.RadioButton).Checked = False
                        End If
                        'Dev Express
                    ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.LookUpEdit" Then '"DevExpress.XtraEditors.LookUpEdit"
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue = dtRow(ct.Name)
                        Else
                            CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue = dtRow(ct.Name)
                        End If
                    ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.DateEdit" Then '"DevExpress.XtraEditors.DateEdit"
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            CType(ct, DevExpress.XtraEditors.DateEdit).EditValue = dtRow(ct.Name)
                        Else
                            CType(ct, DevExpress.XtraEditors.DateEdit).EditValue = String.Empty
                        End If
                    ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.CheckEdit" Then '"DevExpress.XtraEditors.CheckEdit"
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            CType(ct, DevExpress.XtraEditors.CheckEdit).Checked = dtRow(ct.Name)
                        Else
                            CType(ct, DevExpress.XtraEditors.CheckEdit).Checked = False
                        End If

                        'ElseIf ct.GetType.ToString = "Infragistics.Win.UltraWinEditors.UltraDateTimeEditor" Then        'Bỏ
                        '    If Not IsDBNull(dtRow(ct.Name)) Then                                                        'Bỏ
                        '        CType(ct, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).Value = dtRow(ct.Name)  'Bỏ
                        '    Else                                                                                        'Bỏ
                        '        CType(ct, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).Value = String.Empty    'Bỏ
                        '    End If                                                                                      'Bỏ
                    ElseIf ct.GetType.ToString = "WindowsControlLibrary.Address" Then
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            ct.Text = dtRow(ct.Name)
                        Else
                            ct.Text = String.Empty
                        End If
                    ElseIf ct.GetType.ToString = "System.Windows.Forms.PictureBox" Then
                        If IsDBNull(dtRow(ct.Name)) = False Then
                            Dim imageData As Byte() = DirectCast(dtRow(ct.Name), Byte())
                            If Not imageData Is Nothing Then
                                Dim ms As New MemoryStream(imageData, 0, imageData.Length)
                                ms.Write(imageData, 0, imageData.Length)
                                CType(ct, System.Windows.Forms.PictureBox).Image = Image.FromStream(ms, True)
                            End If
                        Else
                            CType(ct, System.Windows.Forms.PictureBox).Image = Nothing
                        End If
                    ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.LookUpEdit" Then
                        CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue = dtRow(ct.Name)
                    ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.DateEdit" Then
                        CType(ct, DevExpress.XtraEditors.DateEdit).EditValue = dtRow(ct.Name)
                    Else
                        If Not IsDBNull(dtRow(ct.Name)) Then
                            ct.Text = dtRow(ct.Name)
                        Else
                            ct.Text = String.Empty
                        End If
                    End If
                End If
                If ct.Controls.Count > 0 Then
                    NhapDuLieuTuGridLenFormNhap(ct, dtRow, ListOfFieldOfTable)
                End If
            Next
        End If
    End Sub

    Public Function GetDataMemberAndPrimaryFromControl(ByRef ctlControl As Control, ByVal rowConlumnInfor As DataRow, ByRef arrayDatamember As ArrayList, ByRef arrayDatamember_V As ArrayList, ByRef arrayPrimary As ArrayList, ByRef arrayPrimary_V As ArrayList, ByRef bIdentity As Boolean, ByRef bIdentityIsKey As Boolean, ByVal bCheckingHaveFalse As Boolean, ByVal GetParameterForStore As Boolean) As Boolean
        Dim oj As Object
        Dim Position As String()
        For Each ct As Control In ctlControl.Controls
            If ct.Name.ToUpper = CStr(rowConlumnInfor("COLUMN_NAME")).ToUpper Then
                If ct.GetType.ToString = "DevExpress.XtraEditors.LookUpEdit" Then '"Janus.Windows.GridEX.EditControls.MultiColumnCombo"
                    If GetParameterForStore = True Then
                        If IsNothing(CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue) Or IsDBNull(CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue) Then 'CType(ct, Janus.Windows.GridEX.EditControls.MultiColumnCombo).Value
                            oj = "null"
                        Else
                            oj = "N'" + CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue.ToString.Trim + "'" 'CType(ct, Janus.Windows.GridEX.EditControls.MultiColumnCombo).Value
                        End If
                    Else
                        If IsNothing(CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue) Or IsDBNull(CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue) Then
                            oj = "null"
                        Else
                            oj = CType(ct, DevExpress.XtraEditors.LookUpEdit).EditValue
                        End If

                    End If
                ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.DateEdit" Then '"Janus.Windows.CalendarCombo.CalendarCombo"
                    If GetParameterForStore = True Then
                        If CType(ct, DevExpress.XtraEditors.DateEdit).DateTime.Year = 1 Then
                            oj = "Null"
                        Else
                            oj = "'" + CType(ct, DevExpress.XtraEditors.DateEdit).DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'" 'CType(ct, Janus.Windows.CalendarCombo.CalendarCombo).Value.ToString("yyyy-MM-dd HH:mm:ss")
                        End If
                    Else
                        oj = CType(ct, DevExpress.XtraEditors.DateEdit).DateTime 'CType(ct, Janus.Windows.CalendarCombo.CalendarCombo).Value
                        If IsDBNull(oj) Or CType(ct, DevExpress.XtraEditors.DateEdit).DateTime.Year = 1 Then
                            oj = "null"
                        End If
                    End If
                ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.DateTimeOffsetEdit" Then '"Janus.Windows.CalendarCombo.CalendarCombo"
                    If GetParameterForStore = True Then
                        oj = "'" + CType(ct, DevExpress.XtraEditors.DateTimeOffsetEdit).DateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss") + "'" 'CType(ct, Janus.Windows.CalendarCombo.CalendarCombo).Value.ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        oj = CType(ct, DevExpress.XtraEditors.DateTimeOffsetEdit).EditValue 'CType(ct, Janus.Windows.CalendarCombo.CalendarCombo).Value
                    End If
                ElseIf ct.GetType.ToString = "System.Windows.Forms.NumericUpDown" Then
                    If GetParameterForStore = True Then
                        oj = CType(ct, System.Windows.Forms.NumericUpDown).Value.ToString
                    Else
                        oj = CType(ct, System.Windows.Forms.NumericUpDown).Value
                    End If
                ElseIf ct.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                    If GetParameterForStore = True Then
                        oj = IIf(CType(ct, System.Windows.Forms.CheckBox).Checked = True, "1", "0")
                    Else
                        oj = CType(ct, System.Windows.Forms.CheckBox).Checked
                    End If
                ElseIf ct.GetType.ToString = "System.Windows.Forms.RadioButton" Then
                    If GetParameterForStore = True Then
                        oj = IIf(CType(ct, System.Windows.Forms.RadioButton).Checked = True, "1", "0")
                    Else
                        oj = CType(ct, System.Windows.Forms.RadioButton).Checked
                    End If
                ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.DateTimeOffsetEdit" Then '"Infragistics.Win.UltraWinEditors.UltraDateTimeEditor"
                    If GetParameterForStore = True Then
                        If Not IsNothing(CType(ct, DevExpress.XtraEditors.DateTimeOffsetEdit).EditValue) Then 'CType(ct, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).Value
                            oj = "'" + CType(ct, DevExpress.XtraEditors.DateTimeOffsetEdit).DateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss") + "'" 'CType(ct, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).DateTime.ToString("yyyy-MM-dd HH:mm:ss")
                        Else
                            oj = "null"
                        End If
                    Else
                        oj = CType(ct, DevExpress.XtraEditors.DateTimeOffsetEdit).EditValue 'CType(ct, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).Value
                    End If
                'ElseIf ct.GetType.ToString = "Janus.Windows.EditControls.UIComboBox" Then '
                '    If GetParameterForStore = True Then
                '        oj = "N'" + CType(ct, Janus.Windows.EditControls.UIComboBox).SelectedItem.Value.ToString.Trim + "'"
                '    Else
                '        oj = CType(ct, Janus.Windows.EditControls.UIComboBox).SelectedItem.Value
                '    End If
                ElseIf ct.GetType.ToString = "DevExpress.XtraEditors.ComboBoxEdit" Then '"Infragistics.Win.UltraWinEditors.UltraComboEditor"
                    If Not IsNothing(CType(ct, ComboBoxEdit).SelectedItem) Then 'CType(ct, Infragistics.Win.UltraWinEditors.UltraComboEditor).SelectedItem
                        If GetParameterForStore = True Then
                            oj = "'" + CType(ct, ComboBoxEdit).SelectedItem.ToString() + "'" 'CType(ct, Infragistics.Win.UltraWinEditors.UltraComboEditor).SelectedItem.DataValue.ToString
                        Else
                            oj = CType(ct, ComboBoxEdit).SelectedItem 'CType(ct, Infragistics.Win.UltraWinEditors.UltraComboEditor).SelectedItem.DataValue
                        End If
                    Else
                        If GetParameterForStore = True Then
                            oj = "null"
                        Else
                            oj = String.Empty
                        End If
                    End If
                Else
                    If CStr(rowConlumnInfor("DATA_TYPE")).ToUpper = "INT" Then
                        Try
                            If GetParameterForStore = True Then
                                oj = IIf(ct.Text.Trim = String.Empty, "null", CInt(ct.Text.Trim))
                            Else
                                oj = CInt(ct.Text.Trim)
                            End If
                        Catch ex As Exception
                            If GetParameterForStore = True Then
                                oj = "null"
                            Else
                                oj = String.Empty
                            End If
                        End Try
                    ElseIf CStr(rowConlumnInfor("DATA_TYPE")).ToUpper = "FLOAT" Or CStr(rowConlumnInfor("DATA_TYPE")).ToUpper = "NUMERIC" Then
                        Try
                            If GetParameterForStore = True Then
                                oj = IIf(ct.Text.Trim = String.Empty, "null", CDbl(ct.Text.Trim))
                            Else
                                oj = CDbl(ct.Text.Trim)
                            End If
                        Catch ex As Exception
                            If GetParameterForStore = True Then
                                oj = "null"
                            Else
                                oj = String.Empty
                            End If
                        End Try
                    Else
                        If GetParameterForStore = True Then
                            oj = IIf(ct.Text.Trim = String.Empty, "null", "N'" + ct.Text.Trim + "'")
                        Else
                            oj = ct.Text.Trim
                        End If
                    End If
                End If
                If GetParameterForStore = True Then
                    arrayDatamember_V.Add(oj)
                Else
                    If bIdentity = False Then
                        'If (ct.Name.ToUpper = "DEPARTMENTCODE" Or ct.Name.ToUpper = "SECTIONCODE" Or ct.Name.ToUpper = "TEAMCODE") Then
                        If (ct.Name.ToUpper = "SECTIONCODE" Or ct.Name.ToUpper = "TEAMCODE") Then
                            If oj <> String.Empty Then
                                Position = oj.ToString.Split(New Char() {"_"c})
                                oj = Position(Position.Length - 1)
                            End If
                        End If
                        arrayDatamember_V.Add(oj)
                    End If
                    If rowConlumnInfor("IS_NULLABLE") = "NO" And IsDBNull(rowConlumnInfor("IdentityName")) And CStr(oj) = String.Empty Then
                        Dim FieldName As String
                        For Each ctl As Control In ctlControl.Controls
                            If ctl.Name.ToUpper = "LBL" + ct.Name.ToUpper Then
                                FieldName = ctl.Text
                                Exit For
                            End If
                        Next
                        MessageBox.Show("Bạn vui lòng nhập vào ô:  " + FieldName, "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        ct.Focus()
                        bCheckingHaveFalse = False
                        Return False
                    End If
                    If Not IsDBNull(rowConlumnInfor("PrimaryName")) Or (bIdentity = True And CStr(oj) <> String.Empty) Then
                        If bIdentity = True And CStr(oj) <> String.Empty Then
                            bIdentityIsKey = True
                            arrayPrimary.Clear()
                            arrayPrimary.Add(rowConlumnInfor("COLUMN_NAME"))
                            arrayPrimary_V.Clear()
                            arrayPrimary_V.Add(oj)
                        End If
                        If bIdentityIsKey = False Then
                            arrayPrimary.Add(rowConlumnInfor("COLUMN_NAME"))
                            arrayPrimary_V.Add(oj)
                        End If
                    End If
                    Exit For
                End If
            End If
            If ct.Controls.Count > 0 And bCheckingHaveFalse = True Then
                GetDataMemberAndPrimaryFromControl(ct, rowConlumnInfor, arrayDatamember, arrayDatamember_V, arrayPrimary, arrayPrimary_V, bIdentity, bIdentityIsKey, bCheckingHaveFalse, GetParameterForStore)
            End If
        Next
        Return bCheckingHaveFalse
    End Function

    Public Sub ThemDauSaoChoTruongBuocNhap(ByRef ctlControl As Control, ByVal tablename As String)
        Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + tablename + "'", "table")
        For Each r As DataRow In tabTableInfor.Rows
            TimVaThemDauSaoChoTruongBuocNhap(ctlControl, r)
        Next
    End Sub

    Public Sub TimVaThemDauSaoChoTruongBuocNhap(ByRef ctlControl As Control, ByVal rowConlumnInfor As DataRow)
        For Each ct As Control In ctlControl.Controls
            If ct.Name.ToUpper = "LBL" + CStr(rowConlumnInfor("COLUMN_NAME")).ToUpper Then
                If rowConlumnInfor("IS_NULLABLE") = "NO" And IsDBNull(rowConlumnInfor("IdentityName")) Then
                    'For Each ctl As Control In ctlControl.Controls
                    '    If ctl.Name.ToUpper = "LBL" + ct.Name.ToUpper Then
                    '        ctl.Name
                    '        Exit For
                    '    End If
                    'Next
                    'Exit Sub
                    ct.Text = ct.Text + " *"
                    CType(ct, Label).ForeColor = Color.Red
                End If
                Exit For
            End If
            If ct.Controls.Count > 0 Then
                TimVaThemDauSaoChoTruongBuocNhap(ct, rowConlumnInfor)
            End If
        Next
    End Sub

    'Public Function LuuTuForm(ByVal tableName As String, ByRef ctlControl As Control) As Boolean
    '    Dim tabTableInfor As DataTable = kn.ReadData("exec [dbo].[sp_GetAllInformationInTable] N'" + tableName + "'", "table")
    '    Dim arrayDatamember As New ArrayList
    '    Dim arrayDatamember_V As New ArrayList
    '    Dim arrayPrimary As New ArrayList
    '    Dim arrayPrimary_V As New ArrayList
    '    Dim bIdentity As Boolean
    '    Dim bIdentityIsKey As Boolean
    '    For Each r As DataRow In tabTableInfor.Rows
    '        'TÌM MẢNG GIÁ TRỊ VÀ PRIMARY
    '        If Not IsDBNull(r("IdentityName")) Then
    '            bIdentity = True
    '        Else
    '            arrayDatamember.Add(r("COLUMN_NAME"))
    '            bIdentity = False
    '        End If
    '        If GetDataMemberAndPrimaryFromControl(ctlControl, r, arrayDatamember, arrayDatamember_V, arrayPrimary, arrayPrimary_V, bIdentity, bIdentityIsKey) = False Then
    '            Return False
    '        End If
    '    Next
    '    'THỰC HIỆN SAVE
    '    If LuuKhongGhiLog(False, tableName, CType(arrayPrimary.ToArray(GetType(String)), String()), arrayPrimary_V.ToArray(), CType(arrayDatamember.ToArray(GetType(String)), String()), arrayDatamember_V.ToArray()) = True Then
    '        MessageBox.Show("Lưu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Return True
    '    Else
    '        MessageBox.Show("Lưu không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    '    Return False
    'End Function

    Public Function isNumber(ByVal sCheck As String) As Boolean
        If IsNothing(sCheck) Or sCheck = String.Empty Then
            Return False
        End If
        Try
            Dim db As Double = CDbl(sCheck)
            Return True
        Catch ex As Exception
            Return False
        End Try
        'Dim regex As Regex = New Regex("[-+]?[0-9]+")
        'Dim match As Match = regex.Match(sCheck)
        'If match.Success And sCheck.Length = match.Value.Length Then
        '    Return True
        'End If
    End Function

    Public Sub MailMerge(ByVal PathFileTemplate As String, ByVal PathFileBangMauExcel As String, ByVal PathFileMERGED As String)
        Dim WdApp As Object
        Dim WdDoc As Object
        WdApp = CreateObject("Word.Application")
        WdDoc = CreateObject("Word.Document")

        WdDoc = WdApp.Documents.Open(PathFileTemplate, ConfirmConversions:=
        False, ReadOnly:=False, AddToRecentFiles:=False, PasswordDocument:="",
        PasswordTemplate:="", Revert:=False, WritePasswordDocument:="",
        WritePasswordTemplate:="", XMLTransform:="")
        WdApp.visible = False

        WdDoc.MailMerge.OpenDataSource(Name:=PathFileBangMauExcel,
        ConfirmConversions:=False, ReadOnly:=False, LinkToSource:=True,
        AddToRecentFiles:=False, PasswordDocument:="", PasswordTemplate:="",
        WritePasswordDocument:="", WritePasswordTemplate:="", Revert:=False, Connection:=
        "Provider=Microsoft.ACE.OLEDB.12.0;User ID=Admin; Mode=Read; Extended Properties=""HDR=YES;IMEX=1;"";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Engine Type=35;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global", SQLStatement:="SELECT * FROM `Sheet1$`", SQLStatement1:="")

        ' .Destination  0 = DOCUMENT, 1 = PRINTER
        WdApp.ActiveDocument.MailMerge.Destination = 0 'wdSendToNewDocument
        WdApp.ActiveDocument.MailMerge.SuppressBlankLines = True
        With WdApp.ActiveDocument.MailMerge.DataSource
            .FirstRecord = 1     'wdDefaultFirstRecord
            .LastRecord = -16  'wdDefaultLastRecord
        End With
        WdApp.ActiveDocument.MailMerge.Execute(Pause:=False)

        WdDoc.Close(savechanges:=False) 'Close the original mail-merge template file.
        WdApp.ActiveDocument.SaveAs(PathFileMERGED) 'Now the ActiveDocument becomes the merged data.

        WdApp.Quit()
        WdDoc = Nothing
        WdApp = Nothing
    End Sub

    Public Function XuatFileWord(ByVal CheckXuatPDF As Boolean, ByVal NameOfWordTemplate As String, ByVal NameOfExcelTemplateMergeWord As String, ByVal tabDataTable As DataTable) As Boolean
        'Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        'Dim str_DiaChi As String
        'Dim index As Integer = 7
        'Dim urlTemplate As String = Application.StartupPath() + "\Teamleate\BangMau.xlsx"
        'Dim urlOut As String = Application.StartupPath() + "\In\" + NameOfExcelTemplateMergeWord
        'Dim excel As New FileInfo(urlTemplate)
        'Using package = New ExcelPackage(excel)
        '    Dim workbook = package.Workbook
        '    Dim worksheet = workbook.Worksheets.First()
        '    Dim row As DataRow
        '    Dim col As DataColumn
        '    Dim i As Integer
        '    Dim j As Integer = 0
        '    Dim rowgrid, rowgridChildren As GridEXRow
        '    If System.IO.File.Exists(Application.StartupPath() + "\In\" + NameOfExcelTemplateMergeWord) = True Then
        '        System.IO.File.Delete(Application.StartupPath() + "\In\" + NameOfExcelTemplateMergeWord)
        '    End If
        '    For Each col In tabDataTable.Columns
        '        worksheet.Cells(ColExel(j) + index.ToString).Value = tabDataTable.Columns(j).ColumnName
        '        j += 1
        '    Next
        '    index += 1
        '    For Each row In tabDataTable.Rows
        '        For i = 0 To tabDataTable.Columns.Count - 1
        '            If Not IsDBNull(row(i)) Then
        '                If tabDataTable.Columns(i).ColumnName = "Address_Permanent" Or tabDataTable.Columns(i).ColumnName = "Address_Temporary" Then
        '                    str_DiaChi = CStr(row(i)).Replace("-:-", "-")
        '                    worksheet.Cells(ColExel(i) + index.ToString).Value = str_DiaChi
        '                Else
        '                    worksheet.Cells(ColExel(i) + index.ToString).Value = row(i)
        '                End If
        '                If row(i).GetType().ToString = "System.DateTime" Then
        '                    worksheet.Cells(ColExel(i) + index.ToString).Style.Numberformat.Format = "dd/MM/yyyy"
        '                End If
        '            End If

        '        Next
        '        index += 1
        '    Next
        '    Dim fi As New FileInfo(urlOut)
        '    package.SaveAs(fi)
        'End Using
        'If NameOfWordTemplate = String.Empty Then
        '    MessageBox.Show(GetLanguagesTranslated("Popup.Phaimaukhongtontai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'Else
        '    If System.IO.File.Exists(Application.StartupPath() + "\In\" + NameOfWordTemplate) = False Then
        '        MessageBox.Show(GetLanguagesTranslated("Popup.Phaimaukhongtontai"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Return False
        '    Else
        '        Dim urlOutWord As String
        '        urlOutWord = Application.StartupPath() + "\In\Rac\" + NameOfWordTemplate
        '        MailMerge(Application.StartupPath() + "\In\" + NameOfWordTemplate, Application.StartupPath() + "\In\" + NameOfExcelTemplateMergeWord, Application.StartupPath() + "\In\MERGED_WORD_LETTERS.docx")
        '        If System.IO.File.Exists(urlOutWord.Replace(".docx", "") + ".docx") = True Then
        '            System.IO.File.Delete(urlOutWord.Replace(".docx", "") + ".docx")
        '        End If
        '        File.Copy(Application.StartupPath() + "\In\MERGED_WORD_LETTERS.docx", urlOutWord.Replace(".docx", "") + ".docx")
        '        If CheckXuatPDF = False Then
        '            Dim oWord As Word.Application
        '            Dim oDoc As Word.Document
        '            oWord = CreateObject("Word.Application")
        '            oWord.Visible = True
        '            oDoc = oWord.Documents.Add(urlOutWord.Replace(".docx", "") + ".docx")
        '            'Else
        '            '    SaveWordToPDF(urlOutWord)
        '        End If
        '    End If
        'End If
        'Return True
    End Function

    Public Sub SaveWordToPDF(ByVal filename As String)
        Dim wordApplication As New Microsoft.Office.Interop.Word.Application
        Dim wordDocument As Microsoft.Office.Interop.Word.Document = Nothing
        Dim outputFilename As String

        Try
            wordDocument = wordApplication.Documents.Open(filename)
            outputFilename = System.IO.Path.ChangeExtension(filename, "pdf")

            If Not wordDocument Is Nothing Then
                wordDocument.ExportAsFixedFormat(outputFilename, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, False, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)
            End If
        Catch ex As Exception
            'TODO: handle exception
        Finally
            If Not wordDocument Is Nothing Then
                wordDocument.Close(False)
                wordDocument = Nothing
            End If

            If Not wordApplication Is Nothing Then
                wordApplication.Quit()
                wordApplication = Nothing
            End If
        End Try
    End Sub

    'Public Sub PrintViewDocument(ByVal FormCall As Form, ByVal Table As DataTable, ByVal NameOfFile As String, ByVal PrinViewDocument_Excel As Boolean)
    '    If PrinViewDocument_Excel = True Then
    '        Dim urlExcel As String = Application.StartupPath() + "\In\Rac\" + NameOfFile + ".xlsx"
    '        If DienGiaTriVaoKeyTrenFileExcel(Table, NameOfFile + ".xlsx", True) Then
    '            SaveFileExcelToBDF(urlExcel)
    '            Dim frmPDF As New frmViewPDF
    '            frmPDF.Text = "PrintView(" + NameOfFile + ")"
    '            frmPDF.srcpdf = urlExcel.Replace(".xlsx", ".pdf")
    '            frmPDF.MdiParent = FormCall
    '            frmPDF.Show()
    '        End If
    '    Else
    '        Dim urlWord As String = Application.StartupPath() + "\In\Rac\" + NameOfFile + ".docx"
    '        If XuatFileWord(True, NameOfFile + ".docx", NameOfFile + ".xlsx", Table) Then
    '            SaveWordToPDF(urlWord)
    '            Dim frmPDF As New frmViewPDF
    '            frmPDF.Text = "PrintView(" + NameOfFile + ")"
    '            frmPDF.srcpdf = urlWord.Replace(".docx", ".pdf")
    '            frmPDF.MdiParent = FormCall
    '            frmPDF.Show()
    '        End If
    '    End If
    'End Sub

    Public Function LocTheoBoPhan_PhongBan_To_ChucVu_LoaiChucVu(ByVal Dept As String, ByVal Sect As String, ByVal Team As String, ByVal Pos As String, ByVal Posc As String) As String
        Dim ThemLoc As String = String.Empty
        If Dept <> String.Empty Then
            ThemLoc = ThemLoc + " and DepartmentCode = N'" + Dept + "'"
        End If
        If Sect <> String.Empty Then
            ThemLoc = ThemLoc + " and SectionCode = N'" + Sect + "'"
        End If
        If Team <> String.Empty Then
            ThemLoc = ThemLoc + " and TeamCode = N'" + Team + "'"
        End If
        If Pos <> String.Empty Then
            ThemLoc = ThemLoc + " and Position_ID = N'" + Pos + "'"
        End If
        If Posc <> String.Empty Then
            ThemLoc = ThemLoc + " and PositionCategory_ID = N'" + Posc + "'"
        End If
        Return ThemLoc
    End Function

    Public Function DienGiaTriVaoKeyTrenFileExcel(ByVal Table As DataTable, ByVal TemplateFile As String, ByVal CheckXuatPDF As Boolean) As Boolean
        If Table.Rows.Count <= 0 Then
            MessageBox.Show("Không có giá trị nào để tạo file!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim fileChooser As SaveFileDialog = New SaveFileDialog
        fileChooser.DefaultExt = ".xlsx"
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ"}
        fileChooser.FileName = TemplateFile
        Dim result As DialogResult
        If CheckXuatPDF = False Then
            result = fileChooser.ShowDialog()
        Else
            result = DialogResult.OK
        End If
        fileChooser.CheckFileExists = False
        If result = DialogResult.OK Then
            Dim index, int_TongSoDong, int_ChuyenDongLuong As Integer
            Dim strmang_CotDienGiaTri As String()
            Dim urlTemplate As String = Application.StartupPath() + "\Teamleate\" + TemplateFile
            Dim urlOut As String
            If CheckXuatPDF = False Then
                urlOut = fileChooser.FileName()
            Else
                urlOut = Application.StartupPath() + "\In\Rac\" + TemplateFile
                If File.Exists(urlOut) Then
                    File.Delete(urlOut)
                End If
                If File.Exists(Application.StartupPath() + "\In\Rac\" + TemplateFile.Remove(TemplateFile.Length - 4, 4) + ".pdf") Then
                    File.Delete(Application.StartupPath() + "\In\Rac\" + TemplateFile.Remove(TemplateFile.Length - 4, 4) + ".pdf")
                End If
            End If
            Dim excel As New FileInfo(urlTemplate)
            Using package = New ExcelPackage(excel)
                Dim workbook = package.Workbook
                Dim worksheet = workbook.Worksheets.First()
                Dim dtRow As DataRow() = Table.Select()
                int_TongSoDong = worksheet.Cells("A3").Value
                strmang_CotDienGiaTri = Split(worksheet.Cells("A2").Text.Trim, ";")
                index = int_TongSoDong
                For i As Integer = 0 To Table.Rows.Count / strmang_CotDienGiaTri.Length - 1
                    worksheet.Row(index).PageBreak = True
                    For int_row As Integer = 1 To int_TongSoDong + 1
                        worksheet.Cells(int_row, 1, int_row, worksheet.Dimension.End.Column).Copy(worksheet.Cells(int_row + index, 1, int_row + index, worksheet.Dimension.End.Column))
                        worksheet.Row(int_row + index).Height = worksheet.Row(int_row).Height
                    Next
                    index += int_TongSoDong
                Next
                index = 1
                Dim str_Key As String
                Dim iNext As Integer
                For i As Integer = 0 To Table.Rows.Count - 1
                    For j As Integer = 0 To strmang_CotDienGiaTri.Length - 1
                        For iNext = index To index + int_TongSoDong
                            For Each s As String In Split(strmang_CotDienGiaTri(j), ",")
                                str_Key = worksheet.Cells(s + iNext.ToString).Text.Trim
                                If str_Key <> String.Empty Then
                                    Try
                                        worksheet.Cells(s + iNext.ToString).Value = dtRow(i + j)(str_Key)
                                    Catch ex As Exception
                                    End Try
                                End If
                            Next
                        Next
                    Next
                    i += strmang_CotDienGiaTri.Length - 1
                    index += int_TongSoDong
                Next
                urlOut = urlOut.Replace(".xlsx", "") + ".xlsx"
                Dim fi As New FileInfo(urlOut)
                package.SaveAs(fi)
                If CheckXuatPDF = False Then
                    System.Diagnostics.Process.Start(urlOut)
                End If
                Return True
            End Using
        End If
        Return False
    End Function

    Public Sub ClearTextInControlOnForm(ByVal ctlControl As Control)
        If ctlControl.GetType.ToString <> "System.Windows.Forms.Label" And ctlControl.GetType.ToString <> "Janus.Windows.EditControls.UIButton" Then
            If ctlControl.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                CType(ctlControl, System.Windows.Forms.CheckBox).Checked = False
            ElseIf ctlControl.GetType.ToString = "System.Windows.Forms.PictureBox" Then
                CType(ctlControl, System.Windows.Forms.PictureBox).Image = Nothing
            ElseIf ctlControl.GetType.ToString = "DevExpress.XtraEditors.LookUpEdit" Then
                CType(ctlControl, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
            ElseIf ctlControl.Name <> "EmployeeSearch" And ctlControl.GetType.ToString <> "DevExpress.XtraEditors.SimpleButton" Then
                ctlControl.Text = String.Empty
            End If
        End If
        If ctlControl.Controls.Count > 0 Then
            For Each ctl As Control In ctlControl.Controls
                ClearTextInControlOnForm(ctl)
            Next
        End If
    End Sub

    Public Function CheckLicense(ByVal DateLicense As DateTime) As Boolean
        If Today >= DateLicense Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Phanmemdahethansudungbanvuilonglienhenhacungcap"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
        "{impersonationLevel=impersonate}!\\" &
        computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
        "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
        cpu_ids.Substring(2)
        Return cpu_ids
    End Function

    Private Function SystemSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object =
        wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers =
        serial_numbers.Substring(2)

        Return serial_numbers
    End Function

    Public Function CheckingBlock(ByVal TableName As String, ByVal CheckingDate As DateTime) As Boolean
        Dim tab As DataTable = kn.ReadData("select * from HR_Khoa where TableName=N'" + TableName + "' and Block_User=N'" + obj.UserName + "'", "table")
        If tab.Rows.Count > 0 Then
            If CheckingDate <= tab.Rows(0)("Block_Date") Then
                Return True
            Else
                Return False
            End If
        End If
        Return False
    End Function
    Public Function CheckCoDuocLuuDKTangCa(ByVal Ngay As DateTime) As Boolean
        If (Now >= Ngay.AddHours(15) And Now < Ngay.AddDays(1).AddHours(7)) Or Now >= Ngay.AddDays(1).AddHours(10) Then
            Return False
        End If
        Return True
    End Function

    'Public Sub TaoDropDowTrenGrid(ByVal grid As GridView, ByVal KeyOfDropDown As String, ByVal table As DataTable)
    'Public Sub TaoDropDowTrenGrid(ByVal grid As GridEX, ByVal KeyOfDropDown As String, ByVal table As DataTable)
    '    'Dim riLookup As New RepositoryItemLookUpEdit()
    '    'riLookup.DataSource = table
    '    'riLookup.ValueMember = "Code"
    '    'riLookup.DisplayMember = "Name"
    '    'riLookup.NullText = ""
    '    'grid.Columns(KeyOfDropDown).ColumnEdit = riLookup
    '    Dim gdd As New GridEXDropDown
    '    gdd.Name = KeyOfDropDown
    '    gdd.Key = KeyOfDropDown
    '    Dim c As New GridEXColumn
    '    c.DataMember = "Code"
    '    c.Caption = "Code"
    '    c.Key = "Code"
    '    Dim cName As New GridEXColumn
    '    cName.Caption = "Name"
    '    cName.Key = "Name"
    '    cName.DataMember = "Name"
    '    grid.DropDowns.Add(KeyOfDropDown)
    '    If grid.DropDowns.Item(KeyOfDropDown).Columns.Contains("Code") = False Then
    '        grid.DropDowns.Item(KeyOfDropDown).Columns.Add(c)
    '    End If
    '    If grid.DropDowns.Item(KeyOfDropDown).Columns.Contains("Name") = False Then
    '        grid.DropDowns.Item(KeyOfDropDown).Columns.Add(cName)
    '    End If
    '    grid.DropDowns(KeyOfDropDown).DisplayMember = "Name"
    '    grid.DropDowns(KeyOfDropDown).ValueMember = "Code"
    '    grid.DropDowns.Item(KeyOfDropDown).SetDataBinding(table, "")
    'End Sub

    Public Sub TaoDropDowTrenGrid(ByVal grid As GridView, ByVal KeyOfDropDown As String, ByVal table As DataTable)
        If Not IsNothing(grid.Columns(KeyOfDropDown)) Then
            Dim riLookup As New RepositoryItemLookUpEdit()
            riLookup.DataSource = table
            riLookup.ValueMember = "Code"
            riLookup.DisplayMember = "Name"
            riLookup.NullText = ""
            grid.Columns(KeyOfDropDown).ColumnEdit = riLookup
            grid.Columns(KeyOfDropDown).OptionsColumn.AllowEdit = True
        End If
    End Sub
#Region "Crystall Report"

#End Region
#Region "Một số hàm hỗ trợ"
    Public Function SaveTableXml(ByVal NameTableXML As String, ByVal gridview1 As GridView)
        gridview1.SaveLayoutToXml(Application.StartupPath() + "\Layouts\" + NameTableXML)
    End Function
    Public Function LoadTableXml(ByVal NameTableXml As String, ByVal gridview1 As GridView)
        gridview1.RestoreLayoutFromXml(Application.StartupPath() + "\Layouts\" + NameTableXml)
    End Function
    Public Function ReturnLeavePlanStatus(ByVal Employee_ID As String, ByVal DateLeave As DateTime)
        Dim tab As DataTable = kn.ReadData("select [dbo].[udf_TraVeTrangThaiPlanKhiDKNghi]('" + Employee_ID + "','" + DateLeave.ToString("yyyy-MM-dd") + "')", "table")
        Return tab.Rows(0)(0)
    End Function

    Public Function CheckErrorProvider(ByVal ctlControl As Control, ByVal ep As ErrorProvider, ByVal ListOfNameOfControl As String()) As Boolean
        For Each s As String In ListOfNameOfControl
            Dim rtnControl As Control
            FindControl(s, ctlControl, rtnControl)
            If Not IsNothing(rtnControl) Then
                If rtnControl.Text.Trim = String.Empty Then
                    rtnControl.Select()
                    ep.SetError(rtnControl, "Please enter some values")
                    Return False
                Else
                    ep.Clear()
                End If
            End If
        Next
        Return True
    End Function
    Public Sub Xem(ByVal strQueryView As String, ByVal TableName As String, ByVal GridControl1 As GridControl, ByVal G As GridView, ByVal Table As DataTable) 'GridEX
        If strQueryView <> String.Empty Then
            Table = kn.ReadData(strQueryView, "table")
            If IsNothing(Table) Then
                Exit Sub
            End If
            Table.AcceptChanges()
        End If
        Dim bReloadGridDesign As Boolean = False
        If Not IsNothing(G.GetDataRow(0)) Then 'G.RootTable
            If IsNothing(Table) Then
                bReloadGridDesign = True
            Else
                If G.Columns.Count = Table.Columns.Count Then 'G.RootTable.Columns.Count
                    For i As Integer = 0 To G.Columns.Count - 1 'For i As Integer = 1 To G.RootTable.Columns.Count - 1
                        If Table.Columns(i).Caption <> G.Columns(i).ToString().ToUpper Then 'If Table.Columns(i - 1).Caption <> G.RootTable.Columns(i).DataMember Then
                            bReloadGridDesign = True
                            Exit For
                        End If
                    Next
                Else
                    bReloadGridDesign = True
                End If
            End If
        End If
        If IsNothing(G.GetDataRow(0)) Or bReloadGridDesign = True Then 'G.RootTable
            GridControl1.DataSource = Table 'G.DataSource = Table
            'GridControl1.SetDataBinding(Table, "")
            'G.RetrieveStructure(True)
            'G.FilterMode = FilterMode.Automatic
            'G.RecordNavigator = True 'Comment line
            'G.RowHeaders = InheritableBoolean.True 'Comment line
            'Dim colselector As New GridEXColumn 'Comment line
            'colselector.ActAsSelector = True 'Comment line
            'colselector.Width = 20 'Comment line
            'G.RootTable.Columns.Insert(0, colselector) 'Comment line
            Dim ListOfLANCode As String
            If Not IsNothing(Table) Then
                Dim columnsDisableEdit = {"EMPLOYEE_ID", "USERNAME", "APPROVAL", "INSERTSOURCE"}
                Dim columnsDisableVisible = {"EMPLOYEE_ID1", "ID"}
                Dim columnsDateDisableEdit = {"UPDATETDATE", "INSERTDATE"}
                For Each cl As Columns.GridColumn In G.Columns 'For Each cl As DataColumn In Table.Columns
                    If columnsDisableEdit.Contains(cl.FieldName.ToUpper) Then 'If cl.ColumnName.ToUpper = "Approval" Then
                        cl.OptionsColumn.AllowEdit = False 'G.RootTable.Columns(cl.ColumnName).EditType = EditType.NoEdit
                    ElseIf columnsDateDisableEdit.Contains(cl.FieldName.ToUpper) Then 'If cl.ColumnName.ToUpper = "INSERTDATE" Then 
                        cl.OptionsColumn.AllowEdit = False
                        cl.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss" 'G.RootTable.Columns(cl.ColumnName).FormatString = "dd/MM/yyyy HH:mm:ss"
                        '    G.RootTable.Columns(cl.ColumnName).EditType = EditType.NoEdit
                        'ElseIf cl.ColumnName.ToUpper = "USERNAME" Then
                        '    G.RootTable.Columns(cl.ColumnName).EditType = EditType.NoEdit
                        'ElseIf cl.ColumnName.ToUpper = "UPDATETDATE" Then
                        '    G.RootTable.Columns(cl.ColumnName).FormatString = "dd/MM/yyyy HH:mm:ss"
                        '    G.RootTable.Columns(cl.ColumnName).EditType = EditType.NoEdit
                        'ElseIf cl.ColumnName.ToUpper = "EMPLOYEE_ID1" Then
                        '    G.RootTable.Columns(cl.ColumnName).Visible = False
                        'ElseIf cl.ColumnName = "ID" Then
                        '    G.RootTable.Columns(cl.ColumnName).Visible = False
                    Else
                        If cl.DisplayFormat.ToString = "System.Double" Then
                            cl.DisplayFormat.FormatString = "n2" 'G.RootTable.Columns(cl.ColumnName).FormatString = "#.00;;"
                        End If
                    End If
                Next
            End If
            'Dim dropDownColumn = {"FACTORY_ID", "DEPARTMENTCODE", "SECTIONCODE", "TEAMCODE", "POSITION_ID", "POSITIONCATEGORY_ID", "CHUCDANH", "POSITION", "LEAVETYPE_ID", "TYPEOFOT", "HAZARD"}
            For Each col As Columns.GridColumn In G.Columns 'For Each col As GridEXColumn In G.RootTable.Columns
                'If col.DataMember <> String.Empty Then
                If col.FieldName.ToUpper = "FACTORY_ID" And TableName.ToUpper <> "HR_Factory".ToUpper And TableName.ToUpper <> "SmartBooks_Department".ToUpper And TableName.ToUpper <> "SmartBooks_Team".ToUpper And TableName.ToUpper <> "SmartBooks_Section".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "')", "table")
                    TaoDropDowTrenGrid(G, "FACTORY_ID", tab)
                ElseIf col.FieldName.ToUpper = "DEPARTMENTCODE" And TableName.ToUpper <> "SmartBooks_Department".ToUpper And TableName.ToUpper <> "SmartBooks_Team".ToUpper And TableName.ToUpper <> "SmartBooks_Section".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Department](null,'" + obj.Lan + "',1)", "table")
                    TaoDropDowTrenGrid(G, "DEPARTMENTCODE", tab)
                ElseIf col.FieldName.ToUpper = "SECTIONCODE" And TableName.ToUpper <> "SmartBooks_Section".ToUpper And TableName.ToUpper <> "SmartBooks_Team".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Section](null,null,'" + obj.Lan + "',1)", "table")
                    TaoDropDowTrenGrid(G, "SECTIONCODE", tab)
                ElseIf col.FieldName.ToUpper = "TEAMCODE" And TableName.ToUpper <> "SmartBooks_Team".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Team](null,null,null,'" + obj.Lan + "','" + IIf(TableName.ToUpper <> "HR_Transfer".ToUpper, "1", "0") + "')", "table")
                    TaoDropDowTrenGrid(G, "TEAMCODE", tab)
                ElseIf col.FieldName.ToUpper = "POSITION_ID" And TableName.ToUpper <> "SmartBooks_Position".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select Position_ID as Code," + IIf(obj.Lan = "VN", "Position_NameVN", IIf(obj.Lan = "EN", "Position_NameEN", "Position_NameKR")) + " as Name from SmartBooks_Position", "table")
                    TaoDropDowTrenGrid(G, "POSITION_ID", tab)
                ElseIf col.FieldName.ToUpper = "POSITIONCATEGORY_ID" And TableName.ToUpper <> "SmartBooks_PositionCategory".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select PositionCategory_ID as Code," + IIf(obj.Lan = "VN", "PositionCategory_NameVN", IIf(obj.Lan = "EN", "PositionCategory_NameEN", "PositionCategory_NameKR")) + " as Name from SmartBooks_PositionCategory", "table")
                    TaoDropDowTrenGrid(G, "POSITIONCATEGORY_ID", tab)
                ElseIf col.FieldName.ToUpper = "CHUCDANH" And TableName.ToUpper <> "HR_ChucDanh".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select ChucDanh as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_ChucDanh", "table")
                    TaoDropDowTrenGrid(G, "CHUCDANH", tab)
                ElseIf col.FieldName.ToUpper = "FULLNAME" Then
                    col.Fixed = FixedStyle.Left
                ElseIf col.FieldName.ToUpper = "EMPLOYEE_LASTNAME" Then
                    col.Fixed = FixedStyle.Left
                ElseIf col.FieldName.ToUpper = "POSITION" Then
                    Dim tab As DataTable = kn.ReadData("select * from udf_Position('" + obj.Lan + "',0)", "table")
                    TaoDropDowTrenGrid(G, "POSITION", tab)
                    col.Width = 200
                ElseIf col.FieldName.ToUpper = "LEAVETYPE_ID".ToUpper And TableName <> "SmartBooks_LeaveType" Then
                    Dim tab As DataTable = kn.ReadData("select LeaveType_ID as Code," + IIf(obj.Lan = "VN", "LeaveType_VN", IIf(obj.Lan = "EN", "LeaveType_EN", "LeaveType_KR")) + "+ (case when NumberOfDate is not null or NumberOfMonth is not null then ' - ' else '' end)+ (case when NumberOfDate is not null then N'Tối đa:' + cast(NumberOfDate as varchar(10)) +' ngày ' else '' end) +(case when NumberOfMonth is not null then  N'Tối đa:' + cast(NumberOfMonth as varchar(10)) +' tháng' else '' end) as Name from SmartBooks_LeaveType", "table")
                    TaoDropDowTrenGrid(G, "LeaveType_ID", tab)
                ElseIf col.FieldName.ToUpper = "TYPEOFOT".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather like '%TypeOfOT'", "table")
                    TaoDropDowTrenGrid(G, "TypeOfOT", tab)
                ElseIf col.FieldName.ToUpper = "HAZARD" And TableName.ToUpper <> "HR_HazardCategory".ToUpper Then
                    Dim tab As DataTable = kn.ReadData("select HAZARD as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_HazardCategory", "table")
                    TaoDropDowTrenGrid(G, "HAZARD", tab)
                    col.Width = 250
                    'If col.DataMember.ToUpper = "FACTORY_ID" And TableName.ToUpper <> "HR_Factory".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Factory]('" + obj.Lan + "')", "table")
                    '    TaoDropDowTrenGrid(G, "FACTORY_ID", tab)
                    '    col.EditType = EditType.MultiColumnCombo
                    '    col.DropDown = G.DropDowns("FACTORY_ID")
                    'ElseIf col.DataMember.ToUpper = "DEPARTMENTCODE" And TableName.ToUpper <> "SmartBooks_Department".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Department](null,'" + obj.Lan + "',1)", "table")
                    '    TaoDropDowTrenGrid(G, "DEPARTMENTCODE", tab)
                    '    col.EditType = EditType.MultiColumnCombo
                    '    col.DropDown = G.DropDowns("DEPARTMENTCODE")
                    'ElseIf col.DataMember.ToUpper = "SECTIONCODE" And TableName.ToUpper <> "SmartBooks_Section".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Section](null,null,'" + obj.Lan + "',1)", "table")
                    '    TaoDropDowTrenGrid(G, "SECTIONCODE", tab)
                    '    col.EditType = EditType.MultiColumnCombo
                    '    col.DropDown = G.DropDowns("SECTIONCODE")
                    'ElseIf col.DataMember.ToUpper = "TEAMCODE" And TableName.ToUpper <> "SmartBooks_Team".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select * from [dbo].[udf_Team](null,null,null,'" + obj.Lan + "',1)", "table")
                    '    TaoDropDowTrenGrid(G, "TEAMCODE", tab)
                    '    col.EditType = EditType.MultiColumnCombo
                    '    col.DropDown = G.DropDowns("TEAMCODE")
                    'ElseIf col.DataMember.ToUpper = "POSITION_ID" And TableName.ToUpper <> "SmartBooks_Position".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select Position_ID as Code," + IIf(obj.Lan = "VN", "Position_NameVN", IIf(obj.Lan = "EN", "Position_NameEN", "Position_NameKR")) + " as Name from SmartBooks_Position", "table")
                    '    TaoDropDowTrenGrid(G, "POSITION_ID", tab)
                    '    col.EditType = EditType.MultiColumnCombo
                    '    col.DropDown = G.DropDowns("POSITION_ID")
                    'ElseIf col.DataMember.ToUpper = "POSITIONCATEGORY_ID" And TableName.ToUpper <> "SmartBooks_PositionCategory".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select PositionCategory_ID as Code," + IIf(obj.Lan = "VN", "PositionCategory_NameVN", IIf(obj.Lan = "EN", "PositionCategory_NameEN", "PositionCategory_NameKR")) + " as Name from SmartBooks_PositionCategory", "table")
                    '    TaoDropDowTrenGrid(G, "POSITIONCATEGORY_ID", tab)
                    '    col.EditType = EditType.MultiColumnCombo
                    '    col.DropDown = G.DropDowns("POSITION_ID")
                    'ElseIf col.DataMember.ToUpper = "LeaveType_ID".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select LeaveType_ID as Code," + IIf(obj.Lan = "VN", "LeaveType_VN", IIf(obj.Lan = "EN", "LeaveType_EN", "LeaveType_KR")) + "+ (case when NumberOfDate is not null or NumberOfMonth is not null then ' - ' else '' end)+ (case when NumberOfDate is not null then N'Tối đa:' + cast(NumberOfDate as varchar(10)) +' ngày ' else '' end) +(case when NumberOfMonth is not null then  N'Tối đa:' + cast(NumberOfMonth as varchar(10)) +' tháng' else '' end) as Name from SmartBooks_LeaveType", "table")
                    '    TaoDropDowTrenGrid(G, "LeaveType_ID", tab)
                    '    G.RootTable.Columns("LeaveType_ID").EditType = EditType.MultiColumnCombo
                    '    G.RootTable.Columns("LeaveType_ID").FilterEditType = FilterEditType.Combo
                    '    G.RootTable.Columns("LeaveType_ID").DropDown = G.DropDowns("LeaveType_ID")
                    'ElseIf col.DataMember.ToUpper = "TypeOfOT".ToUpper Then
                    '    Dim tab As DataTable = kn.ReadData("select Category as Code," + IIf(obj.Lan = "VN", "NameVN", IIf(obj.Lan = "EN", "NameEN", "NameKR")) + " as Name from HR_Category where CategoryFather like '%TypeOfOT'", "table")
                    '    TaoDropDowTrenGrid(G, "TypeOfOT", tab)
                    '    G.RootTable.Columns("TypeOfOT").EditType = EditType.MultiColumnCombo
                    '    G.RootTable.Columns("TypeOfOT").FilterEditType = FilterEditType.Combo
                    '    G.RootTable.Columns("TypeOfOT").DropDown = G.DropDowns("TypeOfOT")
                    'ElseIf col.DataMember.ToUpper = "SHIFTNAME" Then
                    Dim riLookup As New RepositoryItemLookUpEdit()
                    riLookup.DataSource = kn.ReadData("exec sp_BangCa", "table")
                    riLookup.ValueMember = "ShiftName"
                    riLookup.DisplayMember = "ShiftName"
                    riLookup.NullText = ""
                    riLookup.BestFitMode = BestFitMode.BestFitResizePopup
                    col.ColumnEdit = riLookup
                    'Dim tab As DataTable = kn.ReadData("exec sp_BangCa", "table")
                    '    Dim gdd As New GridEXDropDown
                    '    gdd.Name = "ShiftName"
                    '    gdd.Key = "ShiftName"
                    '    Dim c As New GridEXColumn
                    '    c.DataMember = "ShiftName"
                    '    c.Caption = "ShiftName"
                    '    c.Key = "ShiftName"
                    '    Dim cFromTime As New GridEXColumn
                    '    cFromTime.Caption = "FromTime"
                    '    cFromTime.Key = "FromTime"
                    '    cFromTime.DataMember = "FromTime"
                    '    Dim cToTime As New GridEXColumn
                    '    cToTime.Caption = "ToTime"
                    '    cToTime.Key = "ToTime"
                    '    cToTime.DataMember = "ToTime"

                    '    Dim cRestTimeFrom As New GridEXColumn
                    '    cRestTimeFrom.Caption = "RestTimeFrom"
                    '    cRestTimeFrom.Key = "RestTimeFrom"
                    '    cRestTimeFrom.DataMember = "RestTimeFrom"
                    '    Dim cRestTimeTo As New GridEXColumn
                    '    cRestTimeTo.Caption = "RestTimeTo"
                    '    cRestTimeTo.Key = "RestTimeTo"
                    '    cRestTimeTo.DataMember = "RestTimeTo"

                    '    G.DropDowns.Add("ShiftName")
                    '    If G.DropDowns.Item("ShiftName").Columns.Contains("ShiftName") = False Then
                    '        G.DropDowns.Item("ShiftName").Columns.Add(c)
                    '    End If
                    '    If G.DropDowns.Item("ShiftName").Columns.Contains("FromTime") = False Then
                    '        G.DropDowns.Item("ShiftName").Columns.Add(cFromTime)
                    '    End If
                    '    If G.DropDowns.Item("ShiftName").Columns.Contains("ToTime") = False Then
                    '        G.DropDowns.Item("ShiftName").Columns.Add(cToTime)
                    '    End If
                    '    If G.DropDowns.Item("ShiftName").Columns.Contains("RestTimeFrom") = False Then
                    '        G.DropDowns.Item("ShiftName").Columns.Add(cRestTimeFrom)
                    '    End If
                    '    If G.DropDowns.Item("ShiftName").Columns.Contains("RestTimeTo") = False Then
                    '        G.DropDowns.Item("ShiftName").Columns.Add(cRestTimeTo)
                    '    End If

                    '    G.DropDowns("ShiftName").DisplayMember = "ShiftName"
                    '    G.DropDowns("ShiftName").ValueMember = "ShiftName"
                    '    G.DropDowns.Item("ShiftName").SetDataBinding(tab, "")

                    '    G.RootTable.Columns("ShiftName").EditType = EditType.MultiColumnCombo
                    '    G.RootTable.Columns("ShiftName").FilterEditType = FilterEditType.Combo
                    '    G.RootTable.Columns("ShiftName").DropDown = G.DropDowns("ShiftName")
                    'End If
                    'col.FilterEditType = FilterEditType.Combo
                End If
                ListOfLANCode += col.FieldName + ","
            Next
            Dim LanFile As String
            LanFile = GetAppPath() & "\lang\lang." + DbSetting.Lan + ".js"
            Dim ListOfLAN As String() = DichNgonNgu(LanFile, ListOfLANCode.Remove(ListOfLANCode.Length - 1).Split(","))
            Dim i As Integer = 0
            For Each col As GridColumn In G.Columns 'For Each col As GridEXColumn In G.RootTable.Columns 
                If col.FieldName <> String.Empty Then 'If col.DataMember <> String.Empty Then
                    If Not IsNothing(ListOfLAN(i)) Then
                        col.Caption = ListOfLAN(i)
                    End If
                    i += 1
                End If
                If IsNothing(TableName) = False Then
                    If col.FieldName.ToUpper = "ACCESSTIME" And TableName.ToUpper = "HR_TIMEKEEPING_DATA" Then
                        col.DisplayFormat.FormatString = "HH:mm:ss"
                    End If
                End If
            Next
        Else
            GridControl1.DataSource = Table
        End If
    End Sub
    Public Function getShiftNameOfEmployee(ByVal Employee_ID As String, ByVal TimeDate As DateTime) As String
        Dim tabSetUp As DataTable = kn.ReadData("select Value from SetUp where ID='SoNgaySauKhiMangBauDuocHuongThaiSan'", "table")
        Dim tab As DataTable = kn.ReadData("select * from udf_TraVeDangKyCaDuaVaoCaXoay('" + TimeDate.ToString("yyyy-MM-dd") + "','" + TimeDate.ToString("yyyy-MM-dd") + "',null,null,null,null,null,null,N'" + Employee_ID + "')", "table")
        If tab.Rows.Count > 0 Then
            Return tab.Rows(0)("ShiftName")
        End If
    End Function

    Public Function getSetUp(ByVal ID As String) As String
        Dim tab As DataTable = kn.ReadData("select * from setup where ID='" + ID + "'", "table")
        If tab.Rows.Count > 0 Then
            Return tab.Rows(0)("Value")
        End If
        Return String.Empty
    End Function
    Public Function GetOnlyFileNameFromPath(ByVal pFilePathLink As String, ByVal pIncludedExtention As Boolean) As String
        Dim result = pFilePathLink
        If pFilePathLink.Trim <> String.Empty Then
            Dim paths = pFilePathLink.Split("\")
            If paths.Length > 0 Then
                Dim filename = paths(paths.Length - 1)
                If pIncludedExtention = True Then
                    result = filename
                Else
                    Dim filename_ext = filename.Split(".")
                    Dim ext = "." + filename_ext(filename_ext.Length - 1)
                    result = filename.Replace(ext, "")
                End If
            End If
        End If
        Return result
    End Function
    Public Function UpdateImageByEmployee_ID(ByVal pEmployee_ID As String, ByVal pArrImage() As Byte) As Boolean
        Try
            'Dim a As System.Drawing.Bitmap
            'a = Me.Images.Image
            Dim flag As Boolean = False
            Dim action As String = ""
            If Not pArrImage Is Nothing Then
                If pArrImage.Length > 0 Then
                    'Dim name() As String = {"@Picture", "@Employee_ID"}
                    'Dim oj() As Object = {pArrImage, pEmployee_ID}
                    'Dim tp() As String = {"Image", "NVarChar"}
                    flag = kn.UpdateImagesInformation("UpdateImagesEmployee", pArrImage, pEmployee_ID)
                    'If pKn.ExecStore("dbo.UpdateImagesEmployee", name, oj, tp) > 0 Then flag = True
                    'flag = pKn.UpdateImagesInformation("UpdateImagesEmployee", pArrImage, pEmployee_ID)
                    'action = "StoreProc: UpdateImagesEmployee - {" + String.Format("Employee_ID:{0}", pEmployee_ID) + "}"
                End If
            Else
                flag = kn.SaveData("UPDATE [dbo].[SmartBooks_Employee] SET [picture] = null WHERE Employee_ID = '" + pEmployee_ID + "'")
                'action = "UPDATE [dbo].[SmartBooks_Employee] SET [picture] = null WHERE Employee_ID = '" + pEmployee_ID + "'"
                'flag = True
            End If

            If flag Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(GetLanguagesTranslated("Popup.Error"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Logs.WriteLogEntry("Error", Now, "Entity.Smartbooks_Employee", "UpdateImageByEmployee_ID", ex.ToString, ex.Message)
        End Try
    End Function
    'ConvertBitmapToBytes
    Public Function GetDrawingImgToBytes(ByVal pDrawingImg As System.Drawing.Image) As Byte()
        Dim arrImage() As Byte
        If Not pDrawingImg Is Nothing Then
            Dim ms As New MemoryStream
            pDrawingImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = ms.GetBuffer
        End If
        Return arrImage
    End Function
    Public Sub AmountFormat(ByVal Amount As TextBox)
        If Amount.Text = String.Empty Then
            Exit Sub
        End If
        If IsNumeric(Amount.Text) Then
            If Amount.Text.Trim <> "0" Then
                Try
                    Amount.Text = CDbl(Amount.Text).ToString("###,###") 'FormatCurrency(Amount.Text, 0).Replace("£", "").Replace("$", "")
                    Amount.SelectionStart = Amount.Text.Length + 1
                Catch ex As Exception
                    If Amount.Text.Length > 0 Then
                        MessageBox.Show(GetLanguagesTranslated("Popup.Loidinhdangtien"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Amount.Text = Amount.Text.Remove(Amount.Text.Trim.Length - 1, 1)
                        Amount.SelectionStart = Amount.Text.Length + 1
                        Amount.Focus()
                    End If
                End Try
            End If
        Else
            MessageBox.Show(GetLanguagesTranslated("Popup.Loidinhdangtien"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Amount.Text = String.Empty
            Amount.Focus()
        End If
    End Sub

    Public Sub FloatFormat(ByVal Amount As TextBox)
        If Amount.Text = String.Empty Then
            Exit Sub
        End If
        If IsNumeric(Amount.Text) = False Then
            MessageBox.Show(GetLanguagesTranslated("Popup.Loidinhdangso"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Amount.Text = String.Empty
            Amount.Select()
            'If Amount.Text.Trim <> "0" Then
            '    Try
            '        Amount.Text = CDbl(Amount.Text).ToString("###.###") 'FormatCurrency(Amount.Text, 0).Replace("£", "").Replace("$", "")
            '        Amount.SelectionStart = Amount.Text.Length + 1
            '    Catch ex As Exception
            '        If Amount.Text.Length > 0 Then
            '            MessageBox.Show("Lỗi định dạng số!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            Amount.Text = Amount.Text.Remove(Amount.Text.Trim.Length - 1, 1)
            '            Amount.SelectionStart = Amount.Text.Length + 1
            '            Amount.Focus()
            '        End If
            '    End Try
            'End If
        End If
    End Sub

    Public Function LuuAnhNhanVien(ByVal DuongDanAnh As String, ByVal MaNV As String) As Boolean
        Dim img As Bitmap
        Try
            img = New Bitmap(DuongDanAnh)
            'Dim a As System.Drawing.Bitmap
            'a = Anh.Image
            If Not img Is Nothing Then
                Dim ms As New MemoryStream
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim arrImage() As Byte = ms.GetBuffer
                Return kn.UpdateImagesInformation("UpdateImagesEmployee", arrImage, MaNV)
            Else
                Return kn.SaveData("UPDATE [dbo].[SmartBooks_Employee] SET [picture] = null WHERE Employee_ID = '" + MaNV + "'")
            End If
        Catch ex As Exception
            MessageBox.Show(GetLanguagesTranslated("Popup.Luuthanhcong") + ": " + MaNV + ". " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Return False
        End Try
    End Function
    Public Function LayNgayChuyenDi(ByVal Employee_ID As String, ByVal ChuyenTuXuong As String, ByVal fromdate As DateTime, ByVal todate As DateTime) As DateTime
        If ChuyenTuXuong = String.Empty Then
            Return Nothing
        End If
        Dim tab As DataTable = kn.ReadData("select EffectiveDate from [dbo].[udf_DanhSachChuyenDi]('" + fromdate.ToString("yyyy-MM-dd") + "','" + todate.ToString("yyyy-MM-dd") + "','" + ChuyenTuXuong + "','" + Employee_ID + "')", "table")
        If tab.Rows.Count > 0 Then
            Return tab.Rows(0)("EffectiveDate")
        End If
    End Function
    Public Function GetLanguagesTranslated(ByVal Key As String) As String
        langDic = loadLanguage(obj.Lan)
        Return getLangDicText(langDic, Key)
    End Function

    Public Sub GhiNoiDungVaoFileDebug(ByVal FilePath As String, ByVal Content As String)
        If System.IO.File.Exists(FilePath) = False Then
            System.IO.File.Create(FilePath)
        End If

        Dim sw As StreamWriter
        Dim fs As FileStream = Nothing

        If (Not File.Exists(FilePath)) Then
            Try
                fs = File.Create(FilePath)
                sw = File.AppendText(FilePath)
                sw.WriteLine(DateTime.Now.ToString("dd/MM/yy HH:mm:ss") & " " & Content)
            Catch ex As Exception
                MsgBox("Error Creating Log File")
            End Try
        Else
            File.Delete(FilePath)
            sw = File.AppendText(FilePath)
            sw.WriteLine(DateTime.Now.ToString("dd/MM/yy HH:mm:ss") & " " & Content)
            sw.Close()
        End If
    End Sub

#End Region
#Region "Dịch ngôn ngữ"
    Dim aText As String
    Private langDic As DataTable
    'Public Sub changeLangForm(ByVal langDic As DataTable, ByVal ctrls As System.Windows.Forms.Control.ControlCollection, ByVal parentText As String)
    '    'DuyetQuaCacControls
    '    For Each myControl As Control In ctrls
    '        If (TypeOf myControl Is Panel Or TypeOf myControl Is GroupBox Or TypeOf myControl Is TabControl Or TypeOf myControl Is TabPage Or TypeOf myControl Is UltraTabControl) Then
    '            If TypeOf myControl Is UltraTabControl Then
    '                For Each tabC As UltraTab In CType(myControl, UltraTabControl).Tabs
    '                    aText = String.Format("{0}.{1}.{2}", parentText, myControl.Name, tabC.TabPage.Name)
    '                    tabC.Text = getLangDicText(langDic, aText)
    '                Next
    '            Else
    '                setTextToControl(langDic, myControl, parentText)
    '            End If
    '            changeLangForm(langDic, myControl.Controls, parentText)
    '        ElseIf (TypeOf myControl Is GridEX) Then
    '            'DuyetQuaColumns
    '            Dim myGrid As GridEX = CType(myControl, GridEX)
    '            If (Not IsNothing(myGrid.RootTable)) Then
    '                setTextToContextMenu(langDic, myControl, parentText)
    '                For Each col As GridEXColumn In myGrid.RootTable.Columns
    '                    ' KiemTra
    '                    setColumnTitle(langDic, col, parentText & "." & myGrid.Name)
    '                Next
    '            End If
    '        End If
    '        If TypeOf myControl Is Label Or TypeOf myControl Is Button _
    '                Or TypeOf myControl Is Janus.Windows.EditControls.UIButton _
    '                Or TypeOf myControl Is CheckBox Or TypeOf myControl Is RadioButton Then
    '            If (TypeOf myControl Is Janus.Windows.EditControls.UIComboBox) Then
    '                aText = "hello"
    '            End If
    '            setTextToControl(langDic, myControl, parentText)
    '        ElseIf TypeOf myControl Is Janus.Windows.EditControls.UIComboBox Then
    '            setTextToContextMenu(langDic, myControl, parentText)
    '        End If
    '    Next
    'End Sub

    'Public Sub changeLangToGrid(ByVal langDic As DataTable, ByVal ctrls As System.Windows.Forms.Control.ControlCollection, ByVal parentText As String)
    '    'DuyetQuaCacControls
    '    For Each myControl As Control In ctrls
    '        If (TypeOf myControl Is GridEX) Then
    '            'DuyetQuaColumns
    '            Dim myGrid As GridEX = CType(myControl, GridEX)
    '            If (Not IsNothing(myGrid.RootTable)) Then
    '                setTextToContextMenu(langDic, myControl, parentText)
    '                For Each col As GridEXColumn In myGrid.RootTable.Columns
    '                    ' KiemTra
    '                    setColumnTitle(langDic, col, parentText & "." & myGrid.Name)
    '                Next
    '            End If
    '        End If
    '    Next
    'End Sub

    Public Function loadLanguage(ByVal lang As String) As DataTable
        'LoadJsonFile
        Dim filePath As String = GetAppPath() & "\lang\lang." + lang + ".js"
        Dim tReader As TextReader = New StreamReader(filePath)
        Dim reader As JsonReader = New JsonReader(tReader)
        Dim _myDic As New DataTable
        _myDic.Columns.Add("key")
        _myDic.Columns.Add("val")
        Dim key As String = ""
        Dim value As String = ""
        Dim i As Integer = 0
        While reader.Read
            i += 1
            If reader.TokenType <> JsonToken.StartObject And reader.TokenType <> JsonToken.EndObject Then
                If reader.TokenType = JsonToken.PropertyName Then
                    key = reader.Value.ToString
                Else
                    value = reader.Value.ToString
                    _myDic.Rows.Add(New Object() {key, value.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">")})
                End If
            End If
        End While
        reader.Close()
        tReader.Close()

        Return _myDic
    End Function
    Public Sub ChangeLanguageToForm(ByVal _f As Form, ByVal KeyOfForm1 As String, Optional ByVal KieuDich As Integer = 0)
        langDic = loadLanguage(obj.Lan)
        If KieuDich = 0 Then
            setTextToControl(langDic, _f, KeyOfForm1)
        End If
        changeLangForm(langDic, _f.Controls, IIf(_f.Name <> "frmPara", String.Format("{0}.{1}", KeyOfForm1, _f.Name), _f.Name), IIf(KieuDich = 1, 1, 0))
    End Sub
#End Region
End Class
