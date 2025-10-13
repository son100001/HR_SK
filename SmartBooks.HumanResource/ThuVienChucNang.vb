Imports SmartBooks.BusinessLogic
 
Imports Janus.Windows.EditControls.UIComboBox
Imports System.Random
Imports Appsettings
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Drawing.Bitmap
Imports VBReport
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Excel1 = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.COMException
Imports System.Diagnostics
Imports System.Threading
Imports System
Imports log4net
Imports Entity
Imports JSON.NET.Framework
'Imports Newtonsoft.Json
Imports System.Reflection


Public Class ThuVienChucNang
    Dim kn As New connect(DbSetting.dataPath)
    Dim TimeKeeping As New SmartBooks.BusinessLogic.Giang_TimeKeeping
    Dim obj As New Appsettings.DbSetting

    'GHI LOC
    Public UPDATE As String = "UPDATE"
    Public INSERT As String = "INSERT"
    Public DELETE As String = "DELETE"

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

                                CheckExcelNull = String.Format("'{0}'", _dateTime.ToString("yyyy/MM/dd"))
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
                        CheckExcelNull = String.Format("'{0}'", _result.ToString("yyyy/MM/dd"))
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
                        CheckExcelNull = String.Format("'{0}'", _result.ToString("yyyy/MM/dd HH:mm:ss"))
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

End Class
