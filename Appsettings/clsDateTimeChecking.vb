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
    ''' Trả lại ngày tháng là chuỗi
    ''' <example>
    ''' Ví dụ 2/2008 sẽ trả lại 200802 nếu <paramref name="separateChar"/> rỗng,
    ''' hoặc 2008-02 nếu <paramref name="separateChar"/> = "-"
    ''' </example>
    ''' </summary>
    Public Shared Function Month2String(ByVal inputDate As Date, Optional ByVal separateChar As String = "") As String
        Return inputDate.Year.ToString & separateChar & Day2Char(inputDate.Month)
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

    ''' <summary>
    ''' Đây là hàm kiểm tra khoảng thời gian đăng kí có bị quá hạn mức cho phép k0
    ''' <c>Period</c> là kiểu khoảng thời gian
    ''' <c>PeriodType</c> là loại thời gian cần kiểm tra, mặc định là kiểm tra theo ngày
    ''' <returns>Trả lại <c>True</c> nếu <paramref name="Quota"/> nhỏ hơn 1 hoặc thời hạn > <paramref name="Quota"/></returns>
    ''' </summary>
    Public Shared Function CheckOverQuota(ByVal CheckPeriod As Period, ByVal Quota As Integer, Optional ByVal Inteval As DateInterval = DateInterval.Day) As Boolean
        If DateDiff(Inteval, CheckPeriod.FromDate, CheckPeriod.ToDate) >= 0 And Quota > 0 Then
            If DateDiff(Inteval, CheckPeriod.FromDate, CheckPeriod.ToDate) < Quota Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Đây là hàm kiểm tra trùng khoảng thời gian đăng kí
    ''' <c>Period</c> là kiểu khoảng thời gian
    ''' <c>Inteval</c> là loại thời gian cần kiểm tra, mặc định là kiểm tra theo ngày
    ''' <returns>Trả lại <c>True</c> nếu không bị trùng, còn nếu trùng hoặc <paramref name="ToDate"/> < <paramref name="FromDate"/> thì trả lại <c>False</c></returns>
    ''' </summary>
    Public Shared Function CheckConflicPeriod(ByVal PreviousPeriod() As Period, ByVal CheckPeriod As Period, Optional ByVal Inteval As DateInterval = DateInterval.Day, Optional ByVal CanEqual As Boolean = False) As Boolean
        Dim i, j As Integer
        Dim CanUsePeriod(PreviousPeriod.GetUpperBound(0) + 1) As Period
        Dim mdate(PreviousPeriod.GetUpperBound(0) * 2 + 1) As Date

        If DateDiff(Inteval, CheckPeriod.FromDate, CheckPeriod.ToDate) < 0 Then Return False

        For i = 0 To PreviousPeriod.GetUpperBound(0)
            If DateDiff(Inteval, PreviousPeriod(i).FromDate, PreviousPeriod(i).ToDate) < 0 Then Return False
            mdate(2 * i) = PreviousPeriod(i).FromDate
            mdate(2 * i + 1) = PreviousPeriod(i).ToDate
        Next

        'Sap xep mang thoi gian
        Dim tgdate As Date
        For i = 0 To mdate.Length - 2
            For j = i + 1 To mdate.Length - 1
                If DateDiff(Inteval, mdate(j), mdate(i)) > 0 Then
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
                    If DateDiff(Inteval, CanUsePeriod(i).FromDate, CheckPeriod.FromDate) >= 0 And DateDiff(Inteval, CheckPeriod.ToDate, CanUsePeriod(i).ToDate) >= 0 Then Return True
                Next
            Case False
                For i = 0 To CanUsePeriod.Length - 1
                    If DateDiff(Inteval, CanUsePeriod(i).FromDate, CheckPeriod.FromDate) > 0 And DateDiff(Inteval, CheckPeriod.ToDate, CanUsePeriod(i).ToDate) > 0 Then Return True
                Next
        End Select
        Return False
    End Function

    ''' <summary>
    ''' Đây là hàm kiểm tra xem 1 ngày hoặc thời gian nào đó có thuộc 1 mảng thời gian đã có k0
    ''' <c>Period</c> là kiểu khoảng thời gian
    ''' <c>Inteval</c> là loại thời gian cần kiểm tra, mặc định là kiểm tra theo ngày
    ''' <returns>Trả lại <c>True</c> nếu thuộc, còn lại là <c>False</c></returns>
    ''' </summary>
    Public Shared Function CheckBelongtoPeriods(ByVal periods() As Period, ByVal checkTime As Date, ByVal Inteval As DateInterval)
        Dim i As Integer
        For i = 0 To periods.GetUpperBound(0)
            If DateDiff(Inteval, periods(i).FromDate, periods(i).ToDate) < 0 Then Return False
        Next
        For i = 0 To periods.GetUpperBound(0)
            If DateDiff(Inteval, periods(i).FromDate, checkTime) >= 0 And DateDiff(Inteval, checkTime, periods(i).ToDate) >= 0 Then Return True
        Next
        Return False
    End Function

End Class