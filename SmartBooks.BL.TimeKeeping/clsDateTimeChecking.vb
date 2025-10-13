Imports System.Math
Public Class DateTimeChecking

    Public Structure Period
        Dim FromDate As Date
        Dim ToDate As Date
    End Structure

#Region " Function Day2Char "
    Public Shared Function Day2Char(ByVal day As Byte) As String
        If day < 10 And day >= 0 Then
            Return "0" & day.ToString
        Else
            Return day.ToString
        End If
    End Function

    Public Shared Function Day2Char(ByVal day As Integer) As String
        If day < 10 And day >= 0 Then
            Return "0" & day.ToString
        Else
            Return day.ToString
        End If
    End Function

    Public Shared Function Day2Char(ByVal day As Char) As String
        If Val(day) < 10 And Val(day) >= 0 Then
            Return "0" & day
        Else
            Return day
        End If
    End Function

    Public Shared Function Day2Char(ByVal day As String) As String
        If Val(day) < 10 And Val(day) >= 0 Then
            Return "0" & day
        Else
            Return day
        End If
    End Function
#End Region
    
    ''' <summary>
    ''' Trả lại ngày tháng là chuỗi
    ''' <example>
    ''' Ví dụ 31/12/2008 sẽ trả lại 20081231 nếu <paramref name="separateChar"/> rỗng,
    ''' hoặc 2008-12-31 nếu <paramref name="separateChar"/> = "-"
    ''' </example>
    ''' </summary>
    Public Shared Function Date2String(ByVal inputDate As Date, Optional ByVal separateChar As String = "") As String
        Return inputDate.Year.ToString & separateChar & Day2Char(inputDate.Month) & separateChar & Day2Char(inputDate.Day)
    End Function

    ''' <summary>
    ''' Trả lại ngày tháng là chuỗi
    ''' <example>
    ''' Ví dụ 31/12/2008 14:25:7 sẽ trả lại 20081231142507 nếu <paramref name="separateChar"/> rỗng,
    ''' hoặc 2008-12-31-14-25-07 nếu <paramref name="separateChar"/> = "-"
    ''' </example>
    ''' </summary>
    Public Shared Function DateTime2String(ByVal inputDate As Date, Optional ByVal separateChar As String = "") As String
        Return inputDate.Year.ToString & separateChar & Day2Char(inputDate.Month) & separateChar & Day2Char(inputDate.Day) & separateChar & Day2Char(inputDate.Hour) & separateChar & Day2Char(inputDate.Minute) & separateChar & Day2Char(inputDate.Second)
    End Function

    ''' <summary>
    ''' Trả lại thời gian là chuỗi
    ''' <example>
    ''' Ví dụ 6:7:31 PM sẽ trả lại 18:07:31
    ''' </example>
    ''' </summary>
    Public Shared Function Time2String(ByVal inputTime As Date) As String
        Return Day2Char(inputTime.Hour) & ":" & Day2Char(inputTime.Minute) & ":" & Day2Char(inputTime.Second)
    End Function

    Public Shared Function String2Date(ByVal inputDate As String) As Date
        Dim myCultInf As New Globalization.CultureInfo("vi-VN")
        Return Date.Parse(Right(inputDate, 2) & "/" & Mid(inputDate, 5, 2) & "/" & Left(inputDate, 4), myCultInf)
    End Function

    Public Shared Function String2Time(ByVal inputTime As String) As Date
        Return Date.Parse(Left(inputTime, 2) & ":" & Mid(inputTime, 3, 2) & ":" & Right(inputTime, 2))
    End Function

    Public Shared Function String2DateTime(ByVal inputDate As String, ByVal inputTime As String) As Date
        Dim myCultInf As New Globalization.CultureInfo("vi-VN")
        Return Date.Parse(Right(inputDate, 2) & "/" & Mid(inputDate, 5, 2) & "/" & Left(inputDate, 4) & " " & Left(inputTime, 2) & ":" & Mid(inputTime, 3, 2) & ":" & Right(inputTime, 2), myCultInf)
    End Function
    Public Shared Function Datetime2DateTime(ByVal inputDate As Date, ByVal inputTime As DateTime) As Date
        Dim myCultInf As New Globalization.CultureInfo("vi-VN")
        Return Date.Parse(Right(inputDate, 2) & "/" & Mid(inputDate, 5, 2) & "/" & Left(inputDate, 4) & " " & Left(inputTime, 2) & ":" & Mid(inputTime, 3, 2) & ":" & Right(inputTime, 2), myCultInf)

    End Function
    ''' <summary>
    ''' Đây là hàm kiểm tra khoảng thời gian đăng kí có bị quá hạn mức cho phép k0
    ''' <c>Period</c> là kiểu khoảng thời gian
    ''' <c>PeriodType</c> là loại thời gian cần kiểm tra, mặc định là kiểm tra theo ngày
    ''' <returns>Trả lại <c>True</c> nếu <paramref name="Quota"/> nhỏ hơn 1 hoặc thời hạn > <paramref name="Quota"/></returns>
    ''' </summary>
    Public Shared Function CheckOverQuota(ByVal CheckPeriod As Period, ByVal Quota As Integer, Optional ByVal Interval As DateInterval = DateInterval.Day) As Boolean
        If DateDiff(Interval, CheckPeriod.FromDate, CheckPeriod.ToDate) >= 0 And Quota > 0 Then
            If DateDiff(Interval, CheckPeriod.FromDate, CheckPeriod.ToDate) < Quota Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    '''' <summary>
    '''' Đây là hàm kiểm tra trùng khoảng thời gian đăng kí
    '''' <c>Period</c> là kiểu khoảng thời gian
    '''' <c>Interval</c> là loại thời gian cần kiểm tra, mặc định là kiểm tra theo ngày
    '''' <returns>Trả lại <c>True</c> nếu không bị trùng, còn nếu trùng hoặc <paramref name="ToDate"/> < <paramref name="FromDate"/> thì trả lại <c>False</c></returns>
    '''' </summary>
    Public Shared Function CheckConflicPeriod(ByVal PreviousPeriod() As Period, ByVal CheckPeriod As Period, Optional ByVal Interval As DateInterval = DateInterval.Day, Optional ByVal CanEqual As Boolean = False) As Boolean
        Dim i, j As Integer
        Dim CanUsePeriod(PreviousPeriod.GetUpperBound(0) + 1) As Period
        Dim mdate(PreviousPeriod.GetUpperBound(0) * 2 + 1) As Date

        If DateDiff(Interval, CheckPeriod.FromDate, CheckPeriod.ToDate) < 0 Then Return False

        For i = 0 To PreviousPeriod.GetUpperBound(0)
            If DateDiff(Interval, PreviousPeriod(i).FromDate, PreviousPeriod(i).ToDate) < 0 Then Return False
            mdate(2 * i) = PreviousPeriod(i).FromDate
            mdate(2 * i + 1) = PreviousPeriod(i).ToDate
        Next

        'Sap xep mang thoi gian
        Dim tgdate As Date
        For i = 0 To mdate.Length - 2
            For j = i + 1 To mdate.Length - 1
                If DateDiff(Interval, mdate(j), mdate(i)) > 0 Then
                    tgdate = mdate(i)
                    mdate(i) = mdate(j)
                    mdate(j) = tgdate
                End If
            Next
        Next

        'Mang nhung ngay co the dung dc
        CanUsePeriod(0).FromDate = Date.MinValue
        For i = 0 To PreviousPeriod.Length - 1
            CanUsePeriod(i).ToDate = mdate(i * 2)
            CanUsePeriod(i + 1).FromDate = mdate(i * 2 + 1)
        Next
        CanUsePeriod(PreviousPeriod.Length).ToDate = Date.MaxValue

        'Check xem khoang thoi gian can check co phu hop k0?
        Select Case CanEqual
            Case True
                For i = 0 To CanUsePeriod.Length - 1
                    If DateDiff(Interval, CanUsePeriod(i).FromDate, CheckPeriod.FromDate) >= 0 And DateDiff(Interval, CheckPeriod.ToDate, CanUsePeriod(i).ToDate) >= 0 Then Return True
                Next
            Case False
                For i = 0 To CanUsePeriod.Length - 1
                    If DateDiff(Interval, CanUsePeriod(i).FromDate, CheckPeriod.FromDate) > 0 And DateDiff(Interval, CheckPeriod.ToDate, CanUsePeriod(i).ToDate) > 0 Then Return True
                Next
        End Select
        Return False
    End Function

    ''' <summary>
    ''' Đây là hàm kiểm tra xem 1 ngày hoặc thời gian nào đó có thuộc 1 mảng thời gian đã có k0
    ''' <c>Period</c> là kiểu khoảng thời gian
    ''' <c>Interval</c> là loại thời gian cần kiểm tra, mặc định là kiểm tra theo ngày
    ''' <returns>Trả lại <c>True</c> nếu thuộc, còn lại là <c>False</c></returns>
    ''' </summary>
    Public Shared Function BelongtoPeriods(ByVal periods() As Period, ByVal checkTime As Date, ByVal Interval As DateInterval) As Boolean
        Dim i As Integer
        For i = 0 To periods.GetUpperBound(0)
            If DateDiff(Interval, periods(i).FromDate, periods(i).ToDate) < 0 Then Return False
        Next
        For i = 0 To periods.GetUpperBound(0)
            If DateDiff(Interval, periods(i).FromDate, checkTime) >= 0 And DateDiff(Interval, checkTime, periods(i).ToDate) >= 0 Then Return True
        Next
        Return False
    End Function

    Public Shared Function BelongtoPeriods(ByVal period As Period, ByVal checkTime As Date, ByVal Interval As DateInterval) As Boolean
        If DateDiff(Interval, period.FromDate, period.ToDate) < 0 Then Return False
        If DateDiff(Interval, period.FromDate, checkTime) >= 0 And DateDiff(Interval, checkTime, period.ToDate) >= 0 Then Return True
        Return False
    End Function

    ''' <summary>
    ''' Hàm tính giao của 2 khoảng thời gian, kết quả trả lại là rỗng nếu 2 khoảng này k0 trùng nhau
    ''' Kết quả trả lại là 1 khoảng hoặc chỉ 1 thời điểm duy nhất
    ''' </summary>
    Public Shared Function Add2Period(ByVal Period1 As DateTimeChecking.Period, ByVal Period2 As DateTimeChecking.Period, Optional ByVal Interval As DateInterval = DateInterval.Second) As Period
        Try
            Dim d(-1) As Date
            Dim i, j As Byte
            i = 0
            'So sanh de lay ra mang nhung ngay la giao cua 2 khoang
            If DateDiff(Interval, Period2.FromDate, Period1.FromDate) >= 0 And DateDiff(Interval, Period1.FromDate, Period2.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period1.FromDate
                i += 1
            End If
            If DateDiff(Interval, Period2.FromDate, Period1.ToDate) >= 0 And DateDiff(Interval, Period1.ToDate, Period2.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period1.ToDate
                i += 1
            End If
            If DateDiff(Interval, Period1.FromDate, Period2.FromDate) >= 0 And DateDiff(Interval, Period2.FromDate, Period1.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period2.FromDate
                i += 1
            End If
            If DateDiff(Interval, Period1.FromDate, Period2.ToDate) >= 0 And DateDiff(Interval, Period2.ToDate, Period1.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period2.ToDate
                i += 1
            End If
            'Neu k0 co ket qua
            If d.Length = 0 Then
                Return Nothing
            End If
            'Sap xep lai mang theo thu tu tu nho den lon
            For i = 0 To d.GetUpperBound(0) - 1
                For j = i + 1 To d.GetUpperBound(0)
                    If DateDiff(Interval, d(i), d(j)) < 0 Then
                        Dim tg As Date
                        tg = d(i)
                        d(i) = d(j)
                        d(j) = tg
                    End If
                Next
            Next
            'Neu so phan tu cua mang lon hon 2 thi loai bot nhung phan tu bang nhau
            If d.Length > 2 Then
                For i = 0 To d.GetUpperBound(0) - 1
                    If d(i) = d(i + 1) Then
                        d(i) = Nothing
                    End If
                Next
            End If
            Dim r(-1) As Date
            j = 0
            'Copy sang 1 mang moi
            For i = 0 To d.GetUpperBound(0)
                If d(i) <> Nothing Then
                    ReDim Preserve r(j)
                    r(j) = d(i)
                    j += 1
                End If
            Next
            'Neu so phan tu mang moi chi la 1 thi them 1 phan tu nua bang chinh no de co 2 phan tu
            If r.Length = 1 Then
                ReDim Preserve r(1)
                r(1) = r(0)
            End If
            'Tra lai ket qua
            Dim PeriodResult As Period
            PeriodResult.FromDate = r(0)
            PeriodResult.ToDate = r(1)
            Return PeriodResult
        Catch ex As Exception When DateDiff(Interval, Period1.FromDate, Period1.ToDate) < 0 Or DateDiff(Interval, Period2.FromDate, Period2.ToDate) < 0
            MsgBox("FromDate must lower than or equal ToDate!", MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Hàm này tính khoảng còn lại khi Period1 trừ Period2
    ''' </summary>
    Public Shared Sub Subtract2Period(ByVal Period1 As Period, ByVal Period2 As Period, ByRef Result() As Period, Optional ByVal Interval As DateInterval = DateInterval.Second)
        Dim myCult As New Globalization.CultureInfo("vi-VN")
        Dim NegativePeriod2(1) As Period
        NegativePeriod2(0).FromDate = #12:00:00 AM#
        NegativePeriod2(0).ToDate = Period2.FromDate
        NegativePeriod2(1).FromDate = Period2.ToDate
        NegativePeriod2(1).ToDate = #12/31/9999 11:59:59 PM#

        Dim result1 As Period = Add2Period(Period1, NegativePeriod2(0), Interval)
        Dim result2 As Period = Add2Period(Period1, NegativePeriod2(1), Interval)
        If result1.FromDate <> Nothing And result1.ToDate <> Nothing And DateDiff(Interval, result1.FromDate, result1.ToDate) <> 0 Then
            If result2.FromDate <> Nothing And result2.ToDate <> Nothing And DateDiff(Interval, result2.FromDate, result2.ToDate) <> 0 Then
                ReDim Result(1)
                Result(0) = result1
                Result(1) = result2
            Else
                ReDim Result(0)
                Result(0) = result1
            End If
        Else
            If result2.FromDate <> Nothing And result2.ToDate <> Nothing And DateDiff(Interval, result2.FromDate, result2.ToDate) <> 0 Then
                ReDim Result(0)
                Result(0) = result2
            Else
                ReDim Result(-1)
            End If
        End If
    End Sub
End Class