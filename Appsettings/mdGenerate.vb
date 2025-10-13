Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Public Class mdGenerate

    Public memcatarr(100) As String
    Public FeatEnabled(12) As Boolean
    Public LicOK, Lock As Boolean
    Public ExpDays As Integer
    Public webportal As Boolean = True
    Public gServerIP As String
    Dim ipaddress As System.Net.IPAddress
    Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
    Public IPSave As String = CType(h.AddressList.GetValue(0), Object).ToString
    Public hostnamesave As String = CType(h.HostName.Trim, Object).ToString
    'flag to setIcon for JMW or RetenXion
    Public flagICon As Boolean = True

    'Public Function AttemptCounterLock(ByRef TableCode As String, ByRef RecId As String, ByRef UserId As String, ByRef IPAddress As String, ByRef LockDateTime As String) As Boolean
    '    Try
    '        Dim obj As New clsLock
    '        Dim obj2 As New clsApplCtl
    '        Dim waittime, timeout As Integer
    '        Dim LocktimeOut As Boolean = False
    '        Dim flaginsert As Boolean
    '        Dim dslock As New DataSet
    '        Dim strsql As String
    '        Dim LockTm As DateTime
    '        obj.TableCode = TableCode
    '        obj.RecId = RecId
    '        obj.LockDtTm = Now
    '        obj.UserId = UserId
    '        obj.IPAddress = IPAddress
    '        timeout = obj2.GetTimeOut
    '        LockTm = Now.AddSeconds(timeout)
    '        Do
    '            flaginsert = obj.insertLock
    '            If Now.Subtract(LockTm).Seconds > 0 Then
    '                LocktimeOut = True
    '            End If
    '        Loop Until (flaginsert = True) Or LocktimeOut = True
    '        'Do
    '        '    flaginsert = obj.insertLock
    '        '    If flaginsert = False Then
    '        '        waittime += Delay(1)
    '        '    End If
    '        '    If waittime > timeout Then
    '        '        LocktimeOut = True
    '        '    End If
    '        'Loop Until (flaginsert = True) Or LocktimeOut = True

    '        If LocktimeOut Then
    '            dslock = obj.GetCurrentLock()
    '            If dslock.Tables(0).Rows.Count > 0 Then
    '                TableCode = toStr(dslock.Tables(0).Rows(0).Item("TableCode"))
    '                LockDateTime = toStr(toDateTime(dslock.Tables(0).Rows(0).Item("LockDtTm")))
    '                UserId = toStr(dslock.Tables(0).Rows(0).Item("UserId"))
    '                IPAddress = toStr(dslock.Tables(0).Rows(0).Item("IPAddress"))
    '                If IPAddress = obj.IPAddress Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End If
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function
    'Public Function AttemptLockUpdate(ByRef Tableref As String, ByRef RecId As String, ByRef LockUser As String, ByRef LockIP As String, ByRef LockDateTime As String) As Boolean
    '    Try
    '        Dim obj As New clsLock
    '        Dim flaginsert As Boolean
    '        Dim dslock As New DataSet
    '        Dim strsql As String
    '        Dim LockTm As DateTime
    '        obj.TableCode = Tableref
    '        obj.RecId = RecId
    '        obj.LockDtTm = Now
    '        obj.UserId = LockUser
    '        obj.IPAddress = LockIP

    '        If obj.insertLock = True Then
    '            Return True
    '        Else
    '            dslock = obj.GetCurrentLock
    '            Tableref = toStr(dslock.Tables(0).Rows(0).Item("TableCode"))
    '            LockDateTime = toDateTime(dslock.Tables(0).Rows(0).Item("LockDtTm"))
    '            LockUser = toStr(dslock.Tables(0).Rows(0).Item("UserId"))
    '            LockIP = toStr(dslock.Tables(0).Rows(0).Item("IPAddress"))
    '            RecId = toStr(dslock.Tables(0).Rows(0).Item("RecId"))
    '            Return False
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Function
    'Public Function DeleteLock(ByVal Table As String) As String
    '    Dim objLock As New clsLock
    '    Try
    '        objLock.TableCode = Table
    '        objLock.IPAddress = IPSave
    '        objLock.deleteLockUser()
    '        objLock = Nothing
    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function
    'Public Function DeleteLockRec(ByVal Table As String, ByVal RecId As String) As String
    '    Dim objLock As New clsLock
    '    Try
    '        objLock.TableCode = Table
    '        objLock.IPAddress = IPSave
    '        objLock.RecId = RecId
    '        objLock.deleteLock()
    '        objLock = Nothing
    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function
    Public Function Delay(ByVal seconds As Integer) As Integer
        Dim starttime As DateTime
        starttime = DateTime.Now
        Dim WaitSpan As TimeSpan = TimeSpan.FromSeconds(seconds)
        Dim LoopTime As TimeSpan
        Do
            LoopTime = DateTime.Now.Subtract(starttime)
        Loop Until TimeSpan.Compare(LoopTime, WaitSpan) = 1

        Return seconds
    End Function

    Public Function toDateTime(ByVal str As String) As String
        Dim strMonth, strDay, strHour, strMinute, strSecond As String
        Try
            If isNull(str) Then
                Return "0000-00-00 00:00:00"
            End If
            If IsDate(str) Then
                If Month(str) < 10 Then
                    strMonth = "0" & Month(str)
                Else
                    strMonth = Month(str)
                End If
                If Microsoft.VisualBasic.Day(str) < 10 Then
                    strDay = "0" & Microsoft.VisualBasic.Day(str)
                Else
                    strDay = Microsoft.VisualBasic.Day(str)
                End If
                If Hour(str) < 10 Then
                    strHour = "0" & Hour(str)
                Else
                    strHour = Hour(str)
                End If
                If Minute(str) < 10 Then
                    strMinute = "0" & Minute(str)
                Else
                    strMinute = Minute(str)
                End If
                If Second(str) < 10 Then
                    strSecond = "0" & Second(str)
                Else
                    strSecond = Second(str)
                End If

                str = Year(str) & "-" & strMonth & "-" & strDay & " " & strHour & ":" & strMinute & ":" & strSecond
                Return str
            Else
                Return "0000-00-00 00:00:00"
            End If
        Catch e As Exception
            Return "0000-00-00 00:00:00"
        End Try
    End Function
    Public Function toShortDate(ByVal str As String) As String
        Try
            If IsDate(str) = True Then
                Return FormatDateTime(str, DateFormat.ShortDate)
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function toDate(ByVal str As String) As String
        Dim strMonth, strDay As String

        Try
            str = str.Replace("0000", "1900")
            If IsDate(str) Then
                If Month(str) < 10 Then
                    strMonth = "0" & Month(str)
                Else
                    strMonth = Month(str)
                End If
                If Microsoft.VisualBasic.Day(str) < 10 Then
                    strDay = "0" & Microsoft.VisualBasic.Day(str)
                Else
                    strDay = Microsoft.VisualBasic.Day(str)
                End If
                str = Year(str) & "-" & strMonth & "-" & strDay
                str = str.Replace("1900", "0000")
                Return str
            Else
                Return "0000-00-00"
            End If
        Catch e As Exception
            Return "0000-00-00"
        End Try
    End Function

    Public Function toDateBd(ByVal birthdt As String) As String
        Dim Position As Integer = 0
        Dim Matches As Integer = 0
        Dim month, day, year, bd As String
        Dim bdate(3) As String

        birthdt = birthdt.Replace("0000", "1900")
        If IsDate(birthdt) Then
            birthdt = birthdt.Replace("1900", "0000")
            Return birthdt
        End If
        If birthdt <> "" Then
            birthdt = birthdt.Replace("1900", "0000")
            If birthdt.Substring(0, 4) = "0000" Then
                birthdt = birthdt.Substring(5) & "-" & birthdt.Substring(0, 4)
            End If
            If birthdt = "" Then
                Return "0000-00-00"
            End If
            If birthdt.Length = 8 And IsNumeric(birthdt) Then
                birthdt = birthdt.Substring(0, 2) & "-" & birthdt.Substring(2, 2) & "-" & birthdt.Substring(4, 4)
            End If
            If birthdt.Length = 6 And IsNumeric(birthdt) Then
                birthdt = birthdt.Substring(0, 2) & "-" & birthdt.Substring(2, 2) & "-" & birthdt.Substring(4, 2)
            End If
            birthdt = Replace(birthdt, "/", "-")
            birthdt = Replace(birthdt, "\", "-")
            birthdt = Replace(birthdt, ".", "-")
            birthdt = Replace(birthdt, " ", "-")
            birthdt = Replace(birthdt, "_", "-")
            If CountMatches(birthdt, "-") = 1 Then
                birthdt = birthdt & "-0000"
            End If

            bdate = birthdt.Split(New Char() {"-"}, 3)

            If bdate(0).Length = 1 Then bdate(0) = "0" & bdate(0)
            If bdate(1).Length = 1 Then bdate(1) = "0" & bdate(1)
            If bdate(2) = "" Then bdate(2) = "0000"
            If bdate(2).Length = 2 Then
                If bdate(2) < Now.Year.ToString("yy") Then
                    bdate(2) = "19" & bdate(2)
                Else
                    bdate(2) = "20" & bdate(2)
                End If
            End If

            Return bdate(2).Substring(0, 4) & "-" & bdate(0) & "-" & bdate(1)
        Else
            Return "0000-00-00"
        End If
        'Try
        '    If str.Substring(0, 4) = "0000" Then
        '        Return str
        '    End If
        '    If str.Substring(6, 4) = "0000" Or str.Substring(6, 4) = "____" Then
        '        If CInt(str.Substring(0, 2)) > 12 Or CInt(str.Substring(3, 2)) > 31 Then
        '            Return "0000-00-00"
        '        End If
        '        str = "0000" & "-" & str.Substring(0, 2) & "-" & str.Substring(3, 2)
        '        Return str
        '    Else
        '        If IsDate(str) Then
        '            str = str.Substring(6, 4) & "-" & str.Substring(0, 2) & "-" & str.Substring(3, 2)
        '            Return str
        '        Else
        '            Return "0000-00-00"
        '        End If
        '    End If

        'Catch e As Exception
        '    Return "0000-00-00"
        'End Try

    End Function

    Public Function TodateBDNew(ByVal birthdt As String) As String

        Dim Position As Integer = 0
        Dim Matches As Integer = 0
        Dim month, day, year, bd As String
        Dim bdate(3) As String

        If birthdt.Substring(0, 4) = "0000" Then
            birthdt = birthdt.Substring(5) & "-" & birthdt.Substring(0, 4)
        End If

        If birthdt = "" Then
            Return "0000-00-00"
        End If
        If birthdt.Length = 8 And IsNumeric(birthdt) Then
            birthdt = birthdt.Substring(0, 2) & "-" & birthdt.Substring(2, 2) & "-" & birthdt.Substring(4, 4)
        End If
        If birthdt.Length = 6 And IsNumeric(birthdt) Then
            birthdt = birthdt.Substring(0, 2) & "-" & birthdt.Substring(2, 2) & "-" & birthdt.Substring(4, 2)
        End If
        birthdt = Replace(birthdt, "/", "-")
        birthdt = Replace(birthdt, "\", "-")
        birthdt = Replace(birthdt, ".", "-")
        birthdt = Replace(birthdt, " ", "-")
        birthdt = Replace(birthdt, "_", "-")
        If CountMatches(birthdt, "-") = 1 Then
            birthdt = birthdt & "-0000"
        End If

        bdate = birthdt.Split(New Char() {"-"}, 3)

        If bdate(0).Length = 1 Then bdate(0) = "0" & bdate(0)
        If bdate(1).Length = 1 Then bdate(1) = "0" & bdate(1)
        If bdate(2) = "" Then bdate(2) = "0000"
        If bdate(2).Length = 2 Then
            If bdate(2) < Now.Year.ToString("yy") Then
                bdate(2) = "19" & bdate(2)
            Else
                bdate(2) = "20" & bdate(2)
            End If
        End If

        Return bdate(2).Substring(0, 4) & "-" & bdate(0) & "-" & bdate(1)
    End Function

    Public Function validateDate(ByVal str As String) As String
        If IsDate(str) Then
            Return str
        Else
            Return "''"
        End If
    End Function

    Public Function replaceString(ByVal strSource As String, ByVal str1 As String, ByVal str2 As String) As String
        Return strSource.Replace(str1, str2)
    End Function

    Public Function isNull(ByVal str As String) As Boolean
        If Trim(str) = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function validateFieldString(ByVal str As String) As String
        '  str = replaceString(str, "'", "''")
        If Trim(str) <> "" Then
            str = "'" & replaceString(Trim(str), "'", "''") & "'"
            Return str
        Else
            Return "Null"
        End If
    End Function

    Public Function toStringNull(ByVal str As String) As String
        If str = "" Then
            Return System.DBNull.Value.ToString
        Else
            Return str
        End If
    End Function
    Public Function toDateNull(ByVal str As String) As String
        If str = "" Or str = "0000-00-00" Then
            Return "0000-00-00" 'System.DBNull.Value.ToString
        Else
            Return str
        End If
    End Function

    Public Function toDateDBNull(ByVal str As Date) As Date
        If IsDBNull(str) Then
            Return "00:00:00"
        Else
            Return str
        End If

    End Function

    Public Function validateFieldNumber(ByVal str As String) As Double
        If IsNumeric(str) = True Then
            If Trim(str) = "" Then
                Return 0
            Else
                Return str
            End If
        Else
            Return 0
        End If
    End Function
    Public Function validateFieldRealNumber(ByVal str As String) As Double
        Dim dblTemp As Double
        If IsNumeric(str) = True Then
            dblTemp = CDbl(str).ToString("F")
            Return dblTemp
        Else
            Return (0.0).ToString("F")
        End If
    End Function

    Public Function toStr(ByVal str As Object) As String
        Try
            If IsDBNull(str) Then
                Return ""
            End If
            If isNull(str) Then
                Return ""
            Else
                Return str
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function setSelectedIndex(ByVal cmb As ComboBox, ByVal str As String)
        Try
            cmb.SelectedIndex = cmb.Items.IndexOf(str)
        Catch ex As Exception
            cmb.SelectedIndex = 0
        End Try
    End Function

    Public Function toStringStatus(ByVal str As String) As String
        If str.Equals("1") = True Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Public Function toStatus(ByVal str As String) As String
        If str.ToLower.Equals("yes") = True Then
            Return "1"
        Else
            Return "0"
        End If
    End Function
    Public Function convertRTFtoHTML(ByVal strRTF As String) As String
        Dim strHTML As String
        '  strHTML = Replace(strRTF, "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}", "strRTF0")
        ' strHTML = Replace(strHTML, "{\f1\fnil\fcharset0 Arial;}}", "strRTF1")
        'strHTML = Replace(strHTML, "\viewkind4\uc1\pard\f0\fs17", "strRTF2")
        strHTML = Replace(strRTF, "\f1\fs20", "strRTF0")
        strHTML = Replace(strHTML, "\f0\fs17", "strRTF1")
        strHTML = Replace(strHTML, "\f0\fs24", "strRTF4")
        strHTML = Replace(strHTML, "\par", "<br>")
        strHTML = Replace(strHTML, "\b0", "</*b>")
        strHTML = Replace(strHTML, "\b", "<b>")
        strHTML = Replace(strHTML, "\i0", "</*i>")
        strHTML = Replace(strHTML, "\i", "<i>")
        strHTML = Replace(strHTML, "\ulnone", "</*u>")
        strHTML = Replace(strHTML, "\ul", "<u>")
        strHTML = Replace(strHTML, "/*", "/")
        strHTML = Replace(strHTML, "}", "strRTF3")
        strHTML = strHTML.Substring(0, strHTML.IndexOf("strRTF3") + 7)
        Return strHTML
    End Function

    Public Function convertHTMLtoRTF(ByVal strHTML As String) As String
        Dim strRTF As String
        'strRTF = Replace(strHTML, "strRTF0", "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}")
        'strRTF = Replace(strRTF, "strRTF1", "{\f1\fnil\fcharset0 Arial;}}")
        'strRTF = Replace(strRTF, "strRTF2", "\viewkind4\uc1\pard\f0\fs17")
        strRTF = Replace(strHTML, "strRTF0", "\f1\fs20")
        strRTF = Replace(strRTF, "strRTF1", "\f0\fs17")
        strRTF = Replace(strRTF, "strRTF4", "\f0\fs24")
        strRTF = Replace(strRTF, "</b>", "\b0")
        strRTF = Replace(strRTF, "<b>", "\b")
        strRTF = Replace(strRTF, "</i>", "\i0")
        strRTF = Replace(strRTF, "<i>", "\i")
        strRTF = Replace(strRTF, "</u>", "\ulnone")
        strRTF = Replace(strRTF, "<u>", "\ul")
        strRTF = Replace(strRTF, "<br>", "\par")
        strRTF = Replace(strRTF, "strRTF3", "}")
        Return strRTF
    End Function

    Public Function replaceRTF(ByVal str As String) As String
        Try
            str = str.Replace("strRTF0", "")
            str = str.Replace("strRTF1", "")
            str = str.Replace("strRTF3", "")
            str = str.Replace("strRTF4", "")
        Catch ex As Exception
        End Try
        Return str
    End Function
    Public Function formatPhoneNumber(ByVal str As String) As String
        Try
            If str.Length > 6 Then
                If InStr(str, "(") = 0 And InStr(str, ")") = 0 And InStr(str, "-") = 0 Then
                    str = str.Insert(0, "(")
                    str = str.Insert(4, ") ")
                    str = str.Insert(9, "-")
                End If
            End If

            Return str
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function getPhoneNumber(ByVal str) As String
        Try
            str = Replace(str, "(", "")
            str = Replace(str, ")", "")
            str = Replace(str, " ", "")
            str = Replace(str, "-", "")
            Return str
        Catch ex As Exception
            Return str
        End Try
    End Function
    Public Function getFilename(ByVal str As String) As String
        Try
            If str <> "" Then
                str = str.Substring(str.LastIndexOf("\") + 1)
            End If
        Catch ex As Exception
            str = ""
        End Try
        Return str
    End Function
    Public Function ReadNullToFill(ByVal lObj As Object) As String
        If IsDBNull(lObj) Then
            Return "NULL"
        Else
            Return lObj
        End If
    End Function
    '********Function writen by TuanNN****************
    Public Sub PutMask(ByVal obj As Object, ByVal str As String)
        obj.Format = ""
        obj.Mask = ""
        obj.defaultText = ""

        obj.Format = "mm/dd/yyyy"
        obj.SelText = str
        Dim s As String
        s = obj.FormattedText
        obj.Mask = "##/##/####"
        If str <> "" Then
            obj.CtlText = s
        End If
    End Sub

    Public Function ConvertDate(ByVal inpDt As Object) As String
        Try
            Dim newDt, mon, dy, yr, yrSt, cutoffYr As String
            Dim ptr As Integer

            cutoffYr = (Now.Year + 5)
            cutoffYr = cutoffYr.Substring(2, 2)

            mon = inpDt.substring(0, 2)
            dy = inpDt.substring(3, 2)
            yrSt = inpDt.substring(6, 4)
            If mon.Substring(0, 1) = "_" Then
                mon = "0" & mon.Substring(1, 1)
            Else
                If mon.Substring(1, 1) = "_" Then
                    mon = "0" & mon.Substring(0, 1)
                End If
            End If

            If dy.Substring(0, 1) = "_" Then
                dy = "0" & dy.Substring(1, 1)
            Else
                If dy.Substring(1, 1) = "_" Then
                    dy = "0" & dy.Substring(0, 1)
                End If
            End If

            yr = ""
            If Not yrSt.Substring(0, 1) = "_" Then
                yr = yr & yrSt.Substring(0, 1)
            End If
            If Not yrSt.Substring(1, 1) = "_" Then
                yr = yr & yrSt.Substring(1, 1)
            End If
            If Not yrSt.Substring(2, 1) = "_" Then
                yr = yr & yrSt.Substring(2, 1)
            End If
            If Not yrSt.Substring(3, 1) = "_" Then
                yr = yr & yrSt.Substring(3, 1)
            End If
            If yr.Length = 3 Then
                yr = "2" & yr
            End If
            If yr.Length < 3 Then
                If CInt(yr) > CInt(cutoffYr) Then
                    yr = CInt(yr) + 1900
                Else
                    yr = CInt(yr) + 2000
                End If
            End If
            newDt = mon & "/" & dy & "/" & yr
            Return newDt
        Catch ex As Exception
            Return ""
        End Try

    End Function
    ''********Function writen by Hong****************
    'Public Sub fillDgShipCharge(ByVal strConnection As String, ByVal strSQL As String, ByVal dg1 As DataGrid, ByVal ds1 As DataSet)
    '    Dim conn As New Microsoft.Data.Odbc.OdbcConnection(strConnection)
    '    Dim ad As New Microsoft.Data.Odbc.OdbcDataAdapter(strSQL, conn)

    '    Try
    '        conn.Open()
    '    Catch ex As Exception
    '        MsgBox("Error open Connection" & ex.ToString)
    '    End Try
    '    Try
    '        If conn.State = ConnectionState.Open Then
    '            ' refresh datagrid
    '            dg1.DataSource = Nothing
    '            dg1.Refresh()
    '            ds1.Clear()
    '            ad.Fill(ds1, "shipchg")

    '            conn.Close()
    '            dg1.DataSource = ds1.Tables("shipchg").DefaultView
    '            dg1.Refresh()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error Connection: " & ex.ToString())
    '    End Try
    'End Sub
    Public Function ConvertDateBd(ByVal inpDt As Object) As String
        Dim newDt, mon, dy, yr, yrSt, cutoffYr As String
        Dim ptr As Integer

        cutoffYr = (Now.Year + 5)
        cutoffYr = cutoffYr.Substring(2, 2)

        mon = inpDt.substring(0, 2)
        dy = inpDt.substring(3, 2)
        yrSt = inpDt.substring(6, 4)
        If mon.Substring(0, 1) = "_" Then
            mon = "0" & mon.Substring(1, 1)
        Else
            If mon.Substring(1, 1) = "_" Then
                mon = "0" & mon.Substring(0, 1)
            End If
        End If

        If dy.Substring(0, 1) = "_" Then
            dy = "0" & dy.Substring(1, 1)
        Else
            If dy.Substring(1, 1) = "_" Then
                dy = "0" & dy.Substring(0, 1)
            End If
        End If

        yr = ""
        If Not yrSt.Substring(0, 1) = "_" Then
            yr = yr & yrSt.Substring(0, 1)
        End If
        If Not yrSt.Substring(1, 1) = "_" Then
            yr = yr & yrSt.Substring(1, 1)
        End If
        If Not yrSt.Substring(2, 1) = "_" Then
            yr = yr & yrSt.Substring(2, 1)
        End If
        If Not yrSt.Substring(3, 1) = "_" Then
            yr = yr & yrSt.Substring(3, 1)
        End If
        If yr.Length = 3 Then
            yr = "2" & yr
        End If
        If yr.Length < 3 Then
            'If CInt(yr) > CInt(cutoffYr) Then
            '    yr = CInt(yr) + 1900
            'Else
            '    yr = CInt(yr) + 2000
            'End If
            yr = "0000"
        End If
        If yrSt = "____" Or yrSt = "0000" Then
            yr = "0000"
        End If
        newDt = mon & "/" & dy & "/" & yr
        Return newDt
    End Function

    Public Sub PutMaskBD(ByVal obj As Object, ByVal str As String)
        If str = "" Then
            obj.Format = ""
            obj.Mask = ""
            obj.defaultText = ""

            obj.Format = "mm/dd/yyyy"
            obj.SelText = str
            Dim s As String
            s = obj.FormattedText
            obj.Mask = "##/##/####"
            If str <> "" Then
                obj.CtlText = s
            End If
            Exit Sub
        End If

        If str.Substring(6, 4) <> "0000" Then
            obj.Format = ""
            obj.Mask = ""
            obj.defaultText = ""

            obj.Format = "mm/dd/yyyy"
            obj.SelText = str
            Dim s As String
            s = obj.FormattedText
            obj.Mask = "##/##/####"
            If str <> "" Then
                obj.CtlText = s
            End If
            Exit Sub
        ElseIf str.Substring(6, 4) = "0000" And str.Substring(0, 2) <> "00" And str.Substring(3, 2) <> "00" Then

            obj.Format = ""
            obj.Mask = ""
            obj.defaultText = ""

            obj.Format = "mm/dd/0000"
            obj.SelText = str
            Dim s As String
            s = obj.FormattedText
            obj.Mask = "##/##/0000"
            If str <> "" Then
                obj.CtlText = s
            End If
            Exit Sub
        End If
    End Sub

    Public Function toShortDateBD(ByVal str As String) As String
        Try
            If str = "" Then
                Return ""
                Exit Function
            End If
            If IsDate(str) = True Then
                Return str.Substring(5, 2) & "/" & str.Substring(8, 2) & "/" & str.Substring(0, 4)
                Exit Function
            ElseIf str.Substring(0, 4) = "0000" And str.Substring(5, 2) <> "00" Then
                Return str.Substring(5, 2) & "/" & str.Substring(8, 2) & "/" & "0000"
                Exit Function
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function CountMatches(ByVal Stringtosearch As String, ByVal searchfor As String) As Integer
        Dim Position As Integer = 0
        Dim Matches As Integer = 0
        Do
            'return the index of searching word
            Position = Stringtosearch.IndexOf(searchfor, Position)

            If Position <> -1 Then
                Matches += 1
                'set next location ,otherwise it will research the old one
                Position += searchfor.Length
            End If
        Loop Until Position = -1 'Mo matches was found
        Return Matches
    End Function
    Public Sub filllistbox(ByVal ds As DataSet, ByVal lb As ListBox, ByVal display As String, ByVal value As String)
        Try
            Dim memcat, memcatdesc As String
            Dim i, rowcount As Integer
            lb.DataSource = Nothing

            rowcount = ds.Tables(0).Rows.Count

            i = 0
            ReDim memcatarr(rowcount - 1)
            Do While i < ds.Tables(0).Rows.Count
                memcat = ds.Tables(0).Rows(i).Item("MemCatId")
                memcatdesc = ds.Tables(0).Rows(i).Item("MemCatDesc")
                memcatarr(i) = memcat
                lb.Items.Add(memcatdesc)
                i += 1
            Loop
            ds = Nothing
        Catch ex As Exception
            MsgBox("Error Connection: " & ex.ToString())
        End Try

    End Sub
    Public Function NulltoZezo(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return "0"
        Else
            Return obj
        End If
    End Function
End Class