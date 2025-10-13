Imports System.IO
Public Class TimeKeeping
    ''' <summary>
    ''' Kiểu ca làm việc
    ''' </summary>
    Public Structure Shift
        Dim FromTime As Date
        Dim ToTime As Date
        Dim RestTimeFrom As Date
        Dim RestTimeTo As Date
        Dim RestTimeFrom2 As Date
        Dim RestTimeTo2 As Date
        Dim RestTimeFrom3 As Date
        Dim RestTimeTo3 As Date
    End Structure

    Public Structure CheckInOut
        Dim CheckDate As Date 'Ngày
        Dim CheckTime As Date 'Giờ
    End Structure

    Public Enum SalaryRateType
        Normal_Day
        Normal_Night
        OT_Normal_Day
        OT_Normal_Night
        Sunday_Day
        Sunday_Night
        OT_Sunday_Day
        OT_Sunday_Night
        Holiday_Day
        Holiday_Night
        OT_Holiday_Day
        OT_Holiday_Night
    End Enum

    Public Structure WorkingTime
        Dim Time As Long 'Tính bằng phút
        Dim SalaryType As SalaryRateType
    End Structure

    Public Structure LaborHours
        Dim WorkPeriod As DateTimeChecking.Period
        Dim SalaryType As SalaryRateType
    End Structure

    Public Enum RoundType
        RoundTotalMonthTime
        RoundTotalDayTime
        RoundRecordTime
    End Enum

    Public Enum RoundTimeType
        zero
        five
        ten
        FifteenMinutes 'Làm tròn về 15 phút
        ThirtyMinutes 'Làm tròn về 30 phút
        OneHour 'Làm tròn về 1 giờ
    End Enum

    ''' <summary>
    ''' Làm tròn theo khoảng thời gian 15 phút, nửa tiếng, hay 1 tiếng
    ''' <paramref name="value"/> là kiểu Date
    ''' </summary>
    Public Shared Function RoundTime(ByVal value As Date, ByVal type As RoundTimeType) As Date
        Dim h, m As Integer
        h = value.Hour
        Dim myCultureInfo As New Globalization.CultureInfo("vi-VN")

        Select Case type
            Case RoundTimeType.zero
                m = value.Minute
                If h = 24 Then Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " 00:" & m & ":00", myCultureInfo).AddDays(1)
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
            Case RoundTimeType.five
                m = value.Minute
                If m < 5 Then m = 0
                If m >= 5 And m < 10 Then m = 5
                If m >= 10 And m < 15 Then m = 10
                If m >= 15 And m < 20 Then m = 15
                If m >= 20 And m < 25 Then m = 20
                If m >= 25 And m < 30 Then m = 25
                If m >= 30 And m < 35 Then m = 30
                If m >= 35 And m < 40 Then m = 35
                If m >= 40 And m < 45 Then m = 40
                If m >= 45 And m < 50 Then m = 45
                If m >= 50 And m < 55 Then m = 50
                If m >= 55 Then m = 0 : h += 1
                If h = 24 Then Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " 00:" & m & ":00", myCultureInfo).AddDays(1)
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
            Case RoundTimeType.FifteenMinutes
                'm = 15 * Math.Round((value.Minute * 60 + value.Second) / (15 * 60), 0)
                'Sửa riêng cái này cho SHVINA
                'm = 15 * CDbl(FormatNumber((value.Minute * 60 + value.Second) / (15 * 60), 0))
                'If m = 60 Then h += 1 : m = 0
                'If h = 24 Then Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " 00:" & m & ":00", myCultureInfo).AddDays(1)
                'Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
                '-------
                m = value.Minute
                If m < 10 Then m = 0
                If m >= 10 And m < 20 Then m = 15
                If m >= 20 And m < 40 Then m = 30
                If m >= 40 And m < 50 Then m = 45
                If m >= 50 Then m = 0 : h += 1
                If h = 24 Then Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " 00:" & m & ":00", myCultureInfo).AddDays(1)
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
            Case RoundTimeType.ThirtyMinutes
                'm = 30 * Math.Round((value.Minute * 60 + value.Second) / (30 * 60), 0)
                m = 30 * CDbl(FormatNumber((value.Minute * 60 + value.Second) / (30 * 60), 0))
                If m = 60 Then h += 1 : m = 0
                If h = 24 Then Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " 00:" & m & ":00", myCultureInfo).AddDays(1)
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
            Case RoundTimeType.OneHour
                'm = 60 * Math.Round((value.Minute * 60 + value.Second) / (60 * 60), 0)
                m = 60 * CDbl(FormatNumber((value.Minute * 60 + value.Second) / (60 * 60), 0))
                If m = 60 Then h += 1 : m = 0
                If h = 24 Then Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " 00:" & m & ":00", myCultureInfo).AddDays(1)
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)

        End Select
    End Function

    ''' <summary>
    ''' Làm tròn theo khoảng thời gian 15 phút, nửa tiếng, hay 1 tiếng
    ''' <paramref name="value"/> là kiểu long, là số phút, kết quả trả lại cũng là số phút
    ''' </summary>
    Public Shared Function RoundTime(ByVal value As Long, ByVal type As RoundTimeType) As Long
        Select Case type
            Case BL.TimeKeeping.TimeKeeping.RoundTimeType.five
                Dim du As Integer = value Mod 60

                If du < 5 Then du = 0
                If du >= 5 And du < 10 Then du = 5
                If du >= 10 And du < 15 Then du = 10
                If du >= 15 And du < 20 Then du = 15
                If du >= 20 And du < 25 Then du = 20
                If du >= 25 And du < 30 Then du = 25
                If du >= 30 And du < 35 Then du = 30
                If du >= 35 And du < 40 Then du = 35
                If du >= 40 And du < 45 Then du = 40
                If du >= 45 And du < 50 Then du = 45
                If du >= 50 And du < 55 Then du = 50
                If du >= 55 Then du = 60
                Return Fix(value \ 60) * 60 + du
            Case RoundTimeType.FifteenMinutes
                'Return 15 * Math.Round(value / 15, 0)
                'Return 15 * CDbl(FormatNumber(value / 15, 0))
                Dim du As Integer = value Mod 60
                If du < 10 Then du = 0
                If du >= 10 And du < 20 Then du = 15
                If du >= 20 And du < 40 Then du = 30
                If du >= 40 And du < 50 Then du = 45
                If du >= 50 Then du = 60
                Return value \ 60 * 60 + du
            Case RoundTimeType.ThirtyMinutes
                'Return 30 * Math.Round(value / 30, 0)
                Return 30 * CDbl(FormatNumber(value / 30, 0))
            Case RoundTimeType.OneHour
                'Return 60 * Math.Round(value / 60, 0)
                Return 60 * CDbl(FormatNumber(value / 60, 0))
        End Select
    End Function

    ''' <summary>
    ''' Hàm lọc thời gian, nếu số lượng lần quẹt thẻ là chẵn thì k0 lọc nữa
    ''' Nếu số lượng lần quẹt thẻ là lẻ thì lọc xem có lần quét nào gần nhau theo tham số minutes
    ''' Nếu sau khi lọc còn lại số lần quẹt thẻ là chẵn thì OK, còn k0 thì cắt bớt 1 lần quẹt thẻ trước lần quẹt cuối cùng
    ''' </summary>
    Public Shared Sub FilterScanCardTime(ByVal value() As Date, ByVal minutes As Integer, ByRef Result() As Date)
        Dim i, j As Integer
        'Nếu số lượng lần quẹt thẻ là chẵn thì k0 lọc nữa
        'If value.Length Mod 2 = 0 Then
        '    Result = value
        '    Return
        'End If
        'lọc xem có lần quét nào gần nhau theo tham số minutes
        For i = 0 To value.GetUpperBound(0) - 1
            For j = i + 1 To value.GetUpperBound(0)
                If value(i) = Nothing Then Exit For
                Dim other As Long = DateDiff(DateInterval.Second, value(i), value(j))
                If other < 0 Then other += 86400
                If other < (minutes * 60) Then
                    value(j) = Nothing
                End If
            Next
        Next
        j = 0
        Dim newarr(-1) As Date
        For i = 0 To value.GetUpperBound(0)
            If value(i) <> Nothing Then
                ReDim Preserve newarr(j)
                newarr(j) = value(i)
                j += 1
            End If
        Next
        'Nếu số lần quét là lẻ thì cắt bớt 1 lần cạnh lần cuối
        If newarr.Length Mod 2 <> 0 Then
            If newarr.Length > 1 Then newarr(newarr.GetUpperBound(0) - 1) = newarr(newarr.GetUpperBound(0))
            newarr(newarr.GetUpperBound(0)) = Nothing
            ReDim Result(newarr.GetUpperBound(0) - 1)
            For i = 0 To newarr.GetUpperBound(0) - 1
                Result(i) = newarr(i)
            Next
        Else
            Result = newarr
        End If
    End Sub

    ''' <summary>
    ''' Tính thời gian làm việc mỗi ngày
    ''' Chú ý <paramref name="recordTime"/> phải được lọc trước khi đưa vào biến nếu k0 sẽ bị lỗi
    ''' </summary>
    Public Shared Sub CalcWorkingTimeperDay(ByVal WorkingDay As Date, ByVal isHoliday As Boolean, ByVal mShift As Shift, ByVal NightTime As DateTimeChecking.Period, ByVal recordTime() As Date, ByVal mRoundType As RoundType, ByVal mRoundTimeType As RoundTimeType, ByVal AcceptEarlyTime As Boolean, ByRef Result() As WorkingTime)
        Dim shiftperiod(-1) As DateTimeChecking.Period
        Dim WorkingTimeStipulate As Integer 'Tính bằng phút
        Dim myCult As New Globalization.CultureInfo("vi-VN")

        mShift.FromTime = mShift.FromTime 'Date.Parse("1/1/0001 " & mShift.FromTime.Hour & ":" & mShift.FromTime.Minute & ":" & mShift.FromTime.Second, myCult)
        mShift.ToTime = mShift.ToTime 'Date.Parse("1/1/0001 " & mShift.ToTime.Hour & ":" & mShift.ToTime.Minute & ":" & mShift.ToTime.Second, myCult)
        If (mShift.RestTimeFrom = Nothing) And (mShift.RestTimeTo = Nothing) Then 'Trường hợp 1, 2: nếu k0 có thời gian nghỉ
            If mShift.FromTime > mShift.ToTime Then mShift.ToTime = mShift.ToTime.AddDays(1)
            WorkingTimeStipulate = DateDiff(DateInterval.Second, mShift.FromTime, mShift.ToTime)
            If AcceptEarlyTime Then 'Nếu chấp nhận đi làm sớm thì ta có khoảng shift dài từ -∞ đến +∞
                ReDim shiftperiod(0)
                shiftperiod(0).FromDate = Date.MinValue '#12:00:00 AM#
                shiftperiod(0).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            Else 'Nếu k0 chấp nhận đi làm sớm thì ta có khoảng shift dài từ FromTime tới +∞
                ReDim shiftperiod(0)
                shiftperiod(0).FromDate = mShift.FromTime.AddYears(1999)
                shiftperiod(0).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            End If
        Else 'Trường hợp 3, 4: nếu có thời gian nghỉ
            mShift.RestTimeFrom = mShift.RestTimeFrom 'Date.Parse("1/1/0001 " & mShift.RestTimeFrom.Hour & ":" & mShift.RestTimeFrom.Minute & ":" & mShift.RestTimeFrom.Second, myCult)
            mShift.RestTimeTo = mShift.RestTimeTo 'Date.Parse("1/1/0001 " & mShift.RestTimeTo.Hour & ":" & mShift.RestTimeTo.Minute & ":" & mShift.RestTimeTo.Second, myCult)
            If mShift.FromTime > mShift.RestTimeFrom Then mShift.RestTimeFrom = mShift.RestTimeFrom.AddDays(1)
            If mShift.RestTimeFrom > mShift.RestTimeTo Then mShift.RestTimeTo = mShift.RestTimeTo.AddDays(1)
            If mShift.RestTimeTo > mShift.ToTime Then mShift.ToTime = mShift.ToTime.AddDays(1)
            WorkingTimeStipulate = DateDiff(DateInterval.Second, mShift.FromTime, mShift.RestTimeFrom) + DateDiff(DateInterval.Second, mShift.RestTimeTo, mShift.ToTime)
            If AcceptEarlyTime Then 'Nếu chấp nhận đi làm sớm thì ta có 2 khoảng shift dài từ -∞ đến RestTimeFrom và từ RestTimeTo đến +∞
                ReDim shiftperiod(1)
                shiftperiod(0).FromDate = Date.MinValue '#12:00:00 AM#
                shiftperiod(0).ToDate = mShift.RestTimeFrom 'mShift.RestTimeFrom.AddYears(1999)
                shiftperiod(1).FromDate = mShift.RestTimeTo 'mShift.RestTimeTo.AddYears(1999)
                shiftperiod(1).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            Else 'Nếu k0 chấp nhận đi làm sớm thì ta có 2 khoảng shift dài từ FromTime tới RestTimeFrom và từ RestTimeTo tới +∞
                ReDim shiftperiod(1)
                shiftperiod(0).FromDate = mShift.FromTime 'mShift.FromTime.AddYears(1999)
                shiftperiod(0).ToDate = mShift.RestTimeFrom 'mShift.RestTimeFrom.AddYears(1999)
                shiftperiod(1).FromDate = mShift.RestTimeTo 'mShift.RestTimeTo.AddYears(1999)
                shiftperiod(1).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            End If
        End If

        'Thêm ngày cho nighttime
        NightTime.FromDate = NightTime.FromDate 'Date.Parse("1/1/2000 " & NightTime.FromDate.Hour & ":" & NightTime.FromDate.Minute & ":" & NightTime.FromDate.Second, myCult)
        NightTime.ToDate = NightTime.ToDate 'Date.Parse("1/1/2000 " & NightTime.ToDate.Hour & ":" & NightTime.ToDate.Minute & ":" & NightTime.ToDate.Second, myCult)
        'NightTime.FromDate = NightTime.FromDate.AddYears(1999)
        'NightTime.ToDate = NightTime.ToDate.AddYears(1999)
        If NightTime.FromDate > NightTime.ToDate Then NightTime.ToDate = NightTime.ToDate.AddDays(1)

        Dim i, j As Integer
        'Sắp xếp lại thời gian quẹt thẻ theo chính xác cả ngày và giờ
        For i = 0 To recordTime.GetUpperBound(0)
            If mRoundType = RoundType.RoundRecordTime Then
                recordTime(i) = RoundTime(recordTime(i), mRoundTimeType) 'RoundTime(Date.Parse("1/1/2000 " & recordTime(i).Hour & ":" & recordTime(i).Minute & ":" & recordTime(i).Second, myCult), mRoundTimeType)
            Else
                recordTime(i) = recordTime(i) 'Date.Parse("1/1/2000 " & recordTime(i).Hour & ":" & recordTime(i).Minute & ":" & recordTime(i).Second, myCult)
            End If
        Next
        For i = 1 To recordTime.GetUpperBound(0)
            If recordTime(i).CompareTo(recordTime(i - 1)) < 0 Then
                recordTime(i) = recordTime(i).AddDays(1)
            End If
        Next

        'Lấy ra các khoảng thời gian đi làm để tính công
        Dim n As Integer
        Dim tmp, tmpresult As DateTimeChecking.Period
        Dim WTPeriod(-1) As DateTimeChecking.Period
        n = 0
        For i = 0 To recordTime.Length / 2 - 1
            tmp.FromDate = recordTime(i * 2)
            tmp.ToDate = recordTime(i * 2 + 1)
            For j = 0 To shiftperiod.GetUpperBound(0)
                tmpresult = DateTimeChecking.Add2Period(tmp, shiftperiod(j), DateInterval.Second)
                If tmpresult.FromDate <> Nothing And tmpresult.ToDate <> Nothing Then
                    ReDim Preserve WTPeriod(n)
                    WTPeriod(n) = tmpresult
                    n += 1
                End If
            Next
        Next

        'Tính tổng thời gian làm việc trong ngày
        Dim TotalWorkingTime As Integer = 0
        For i = 0 To WTPeriod.GetUpperBound(0)
            'Không làm tròn ở đây, để cuối cùng mới làm tròn
            TotalWorkingTime += DateDiff(DateInterval.Second, WTPeriod(i).FromDate, WTPeriod(i).ToDate)
        Next

        Dim wt As Integer = 0
        Dim FullTimeStipulate As Date 'Giờ đủ giờ làm quy định
        Dim WTAfterCalcNightTime(-1) As LaborHours
        If TotalWorkingTime > WorkingTimeStipulate Then 'Nếu tổng thời gian làm việc lớn hơn 8h
            'Lấy thời gian mà tổng số giờ làm đã đủ 8h quy định
            For i = 0 To WTPeriod.GetUpperBound(0)
                wt += DateDiff(DateInterval.Second, WTPeriod(i).FromDate, WTPeriod(i).ToDate)
                If wt > WorkingTimeStipulate Then
                    FullTimeStipulate = WTPeriod(i).ToDate.Subtract(New TimeSpan(0, 0, wt - WorkingTimeStipulate))
                    Exit For
                End If
            Next

            'Tạo 1 bảng mới chứa các period sau khi đã tách FullTimeStipulate
            Dim WTBeforeCalcNightTime(WTPeriod.GetUpperBound(0) + 1) As LaborHours
            n = 0
            For i = 0 To WTPeriod.GetUpperBound(0)
                WTBeforeCalcNightTime(n).WorkPeriod = WTPeriod(i)
                WTBeforeCalcNightTime(n).SalaryType = SalaryRateType.Normal_Day
                If DateTimeChecking.BelongtoPeriods(WTPeriod(i), FullTimeStipulate, DateInterval.Second) Then
                    WTBeforeCalcNightTime(n).WorkPeriod.ToDate = FullTimeStipulate
                    n += 1
                    WTBeforeCalcNightTime(n).WorkPeriod.FromDate = FullTimeStipulate
                    WTBeforeCalcNightTime(n).WorkPeriod.ToDate = WTPeriod(i).ToDate
                    WTBeforeCalcNightTime(n).SalaryType = SalaryRateType.OT_Normal_Day
                End If

                If n > 0 Then
                    If WTBeforeCalcNightTime(n - 1).SalaryType = SalaryRateType.OT_Normal_Day Then WTBeforeCalcNightTime(n).SalaryType = SalaryRateType.OT_Normal_Day
                End If
                n += 1
            Next

            'Kết hợp với thời gian làm đêm
            n = 0
            For i = 0 To WTBeforeCalcNightTime.GetUpperBound(0)
                tmp = DateTimeChecking.Add2Period(WTBeforeCalcNightTime(i).WorkPeriod, NightTime, DateInterval.Second)
                If tmp.FromDate = Nothing And tmp.ToDate = Nothing Then
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n) = WTBeforeCalcNightTime(i)
                    n += 1
                Else
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n).WorkPeriod = tmp
                    If WTBeforeCalcNightTime(i).SalaryType = SalaryRateType.Normal_Day Then
                        WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Night
                    ElseIf WTBeforeCalcNightTime(i).SalaryType = SalaryRateType.OT_Normal_Day Then
                        WTAfterCalcNightTime(n).SalaryType = SalaryRateType.OT_Normal_Night
                    End If
                    n += 1

                    Dim tmp2(-1) As DateTimeChecking.Period
                    DateTimeChecking.Subtract2Period(WTBeforeCalcNightTime(i).WorkPeriod, NightTime, tmp2)
                    For j = 0 To tmp2.GetUpperBound(0)
                        ReDim Preserve WTAfterCalcNightTime(n)
                        WTAfterCalcNightTime(n).WorkPeriod = tmp2(j)
                        WTAfterCalcNightTime(n).SalaryType = WTBeforeCalcNightTime(i).SalaryType
                        n += 1
                    Next
                End If
            Next

        Else 'Nếu tổng thời gian làm việc nhỏ hơn 8h
            'Kết hợp với thời gian làm đêm
            n = 0
            For i = 0 To WTPeriod.GetUpperBound(0)
                tmp = DateTimeChecking.Add2Period(WTPeriod(i), NightTime, DateInterval.Second)
                If tmp.FromDate = Nothing And tmp.ToDate = Nothing Then
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n).WorkPeriod = WTPeriod(i)
                    WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Day
                    n += 1
                Else
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n).WorkPeriod = tmp
                    WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Night
                    n += 1

                    Dim tmp2(-1) As DateTimeChecking.Period
                    DateTimeChecking.Subtract2Period(WTPeriod(i), NightTime, tmp2)
                    For j = 0 To tmp2.GetUpperBound(0)
                        ReDim Preserve WTAfterCalcNightTime(n)
                        WTAfterCalcNightTime(n).WorkPeriod = tmp2(j)
                        WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Day
                        n += 1
                    Next
                End If
            Next
        End If

        'Đặt lại loại lương cho đúng
        If isHoliday Then
            For i = 0 To WTAfterCalcNightTime.GetUpperBound(0)
                Select Case WTAfterCalcNightTime(i).SalaryType
                    Case SalaryRateType.Normal_Day
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Holiday_Day
                    Case SalaryRateType.Normal_Night
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Holiday_Night
                    Case SalaryRateType.OT_Normal_Day
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Holiday_Day
                    Case SalaryRateType.OT_Normal_Night
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Holiday_Night
                End Select
            Next
        Else
            If WorkingDay.DayOfWeek = DayOfWeek.Sunday Then
                For i = 0 To WTAfterCalcNightTime.GetUpperBound(0)
                    Select Case WTAfterCalcNightTime(i).SalaryType
                        Case SalaryRateType.Normal_Day
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Sunday_Day
                        Case SalaryRateType.Normal_Night
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Sunday_Night
                        Case SalaryRateType.OT_Normal_Day
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Sunday_Day
                        Case SalaryRateType.OT_Normal_Night
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Sunday_Night
                    End Select
                Next
            End If
        End If

        'Tính giờ công
        Dim WTResult(WTAfterCalcNightTime.GetUpperBound(0)) As WorkingTime
        For i = 0 To WTAfterCalcNightTime.GetUpperBound(0)
            WTResult(i).Time = DateDiff(DateInterval.Second, WTAfterCalcNightTime(i).WorkPeriod.FromDate, WTAfterCalcNightTime(i).WorkPeriod.ToDate)
            WTResult(i).SalaryType = WTAfterCalcNightTime(i).SalaryType
        Next

        'Tổng hợp số giờ làm có cùng loại lương
        For i = 0 To WTResult.GetUpperBound(0) - 1
            For j = i + 1 To WTResult.GetUpperBound(0)
                If WTResult(i).SalaryType = WTResult(j).SalaryType Then
                    WTResult(i).Time += WTResult(j).Time
                    WTResult(j).Time = -1
                End If
            Next
        Next
        n = 0
        Dim realresult(-1) As WorkingTime
        For i = 0 To WTResult.GetUpperBound(0)
            If WTResult(i).Time <> -1 Then
                ReDim Preserve realresult(n)
                realresult(n) = WTResult(i)
                n += 1
            End If
        Next

        'Làm tròn kết quả
        For i = realresult.GetLowerBound(0) To realresult.GetUpperBound(0)
            If mRoundType = RoundType.RoundTotalDayTime Then
                realresult(i).Time = RoundTime(CLng(FormatNumber((realresult(i).Time / 60), 0)), mRoundTimeType)
            Else
                realresult(i).Time = CLng(FormatNumber((realresult(i).Time / 60), 0))
            End If
        Next
        Result = realresult
    End Sub
    Public Shared Sub CalcWorkingTimeperDay2(ByVal WorkingDay As Date, ByVal isHoliday As Boolean, ByVal mShift As Shift, ByVal NightTime As DateTimeChecking.Period, ByVal recordTime() As Date, ByVal mRoundType As RoundType, ByVal mRoundTimeType As RoundTimeType, ByVal AcceptEarlyTime As Boolean, ByRef Result() As WorkingTime)
        Dim shiftperiod(-1) As DateTimeChecking.Period
        Dim WorkingTimeStipulate As Integer 'Tính bằng phút
        Dim myCult As New Globalization.CultureInfo("vi-VN")

        mShift.FromTime = Date.Parse("1/1/0001 " & mShift.FromTime.Hour & ":" & mShift.FromTime.Minute & ":" & mShift.FromTime.Second, myCult)
        mShift.ToTime = Date.Parse("1/1/0001 " & mShift.ToTime.Hour & ":" & mShift.ToTime.Minute & ":" & mShift.ToTime.Second, myCult)
        If (mShift.RestTimeFrom = Nothing) And (mShift.RestTimeTo = Nothing) Then 'Trường hợp 1, 2: nếu k0 có thời gian nghỉ
            If mShift.FromTime > mShift.ToTime Then mShift.ToTime = mShift.ToTime.AddDays(1)
            WorkingTimeStipulate = DateDiff(DateInterval.Second, mShift.FromTime, mShift.ToTime)
            If AcceptEarlyTime Then 'Nếu chấp nhận đi làm sớm thì ta có khoảng shift dài từ -∞ đến +∞
                ReDim shiftperiod(0)
                shiftperiod(0).FromDate = Date.MinValue '#12:00:00 AM#
                shiftperiod(0).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            Else 'Nếu k0 chấp nhận đi làm sớm thì ta có khoảng shift dài từ FromTime tới +∞
                ReDim shiftperiod(0)
                shiftperiod(0).FromDate = mShift.FromTime.AddYears(1999)
                shiftperiod(0).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            End If
        Else 'Trường hợp 3, 4: nếu có thời gian nghỉ
            mShift.RestTimeFrom = Date.Parse("1/1/0001 " & mShift.RestTimeFrom.Hour & ":" & mShift.RestTimeFrom.Minute & ":" & mShift.RestTimeFrom.Second, myCult)
            mShift.RestTimeTo = Date.Parse("1/1/0001 " & mShift.RestTimeTo.Hour & ":" & mShift.RestTimeTo.Minute & ":" & mShift.RestTimeTo.Second, myCult)

            mShift.RestTimeFrom2 = Date.Parse("1/1/0001 " & mShift.RestTimeFrom2.Hour & ":" & mShift.RestTimeFrom2.Minute & ":" & mShift.RestTimeFrom2.Second, myCult)
            mShift.RestTimeTo2 = Date.Parse("1/1/0001 " & mShift.RestTimeTo2.Hour & ":" & mShift.RestTimeTo2.Minute & ":" & mShift.RestTimeTo2.Second, myCult)

            If mShift.FromTime > mShift.RestTimeFrom Then mShift.RestTimeFrom = mShift.RestTimeFrom.AddDays(1)
            If mShift.RestTimeFrom > mShift.RestTimeTo Then mShift.RestTimeTo = mShift.RestTimeTo.AddDays(1)
            If mShift.RestTimeTo > mShift.ToTime Then mShift.ToTime = mShift.ToTime.AddDays(1)


            WorkingTimeStipulate = DateDiff(DateInterval.Second, mShift.FromTime, mShift.RestTimeFrom) + DateDiff(DateInterval.Second, mShift.RestTimeTo, mShift.ToTime)

            If AcceptEarlyTime Then 'Nếu chấp nhận đi làm sớm thì ta có 2 khoảng shift dài từ -∞ đến RestTimeFrom và từ RestTimeTo đến +∞
                ReDim shiftperiod(1)
                shiftperiod(0).FromDate = Date.MinValue '#12:00:00 AM#
                shiftperiod(0).ToDate = mShift.RestTimeFrom.AddYears(1999)
                shiftperiod(1).FromDate = mShift.RestTimeTo.AddYears(1999)
                shiftperiod(1).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            Else 'Nếu k0 chấp nhận đi làm sớm thì ta có 2 khoảng shift dài từ FromTime tới RestTimeFrom và từ RestTimeTo tới +∞
                ReDim shiftperiod(1)
                shiftperiod(0).FromDate = mShift.FromTime.AddYears(1999)
                shiftperiod(0).ToDate = mShift.RestTimeFrom.AddYears(1999)
                shiftperiod(1).FromDate = mShift.RestTimeTo.AddYears(1999)
                shiftperiod(1).ToDate = Date.MaxValue '#12/31/9999 11:59:59 PM#
            End If
        End If

        'Thêm ngày cho nighttime
        NightTime.FromDate = Date.Parse("1/1/2000 " & NightTime.FromDate.Hour & ":" & NightTime.FromDate.Minute & ":" & NightTime.FromDate.Second, myCult)
        NightTime.ToDate = Date.Parse("1/1/2000 " & NightTime.ToDate.Hour & ":" & NightTime.ToDate.Minute & ":" & NightTime.ToDate.Second, myCult)
        'NightTime.FromDate = NightTime.FromDate.AddYears(1999)
        'NightTime.ToDate = NightTime.ToDate.AddYears(1999)
        If NightTime.FromDate > NightTime.ToDate Then NightTime.ToDate = NightTime.ToDate.AddDays(1)

        Dim i, j As Integer
        'Sắp xếp lại thời gian quẹt thẻ theo chính xác cả ngày và giờ
        For i = 0 To recordTime.GetUpperBound(0)
            If mRoundType = RoundType.RoundRecordTime Then
                recordTime(i) = RoundTime(Date.Parse("1/1/2000 " & recordTime(i).Hour & ":" & recordTime(i).Minute & ":" & recordTime(i).Second, myCult), mRoundTimeType)
            Else
                recordTime(i) = Date.Parse("1/1/2000 " & recordTime(i).Hour & ":" & recordTime(i).Minute & ":" & recordTime(i).Second, myCult)
            End If
        Next
        For i = 1 To recordTime.GetUpperBound(0)
            If recordTime(i).CompareTo(recordTime(i - 1)) < 0 Then
                recordTime(i) = recordTime(i).AddDays(1)
            End If
        Next

        'Lấy ra các khoảng thời gian đi làm để tính công
        Dim n As Integer
        Dim tmp, tmpresult As DateTimeChecking.Period
        Dim WTPeriod(-1) As DateTimeChecking.Period
        n = 0
        For i = 0 To recordTime.Length / 2 - 1
            tmp.FromDate = recordTime(i * 2)
            tmp.ToDate = recordTime(i * 2 + 1)
            For j = 0 To shiftperiod.GetUpperBound(0)
                tmpresult = DateTimeChecking.Add2Period(tmp, shiftperiod(j), DateInterval.Second)
                If tmpresult.FromDate <> Nothing And tmpresult.ToDate <> Nothing Then
                    ReDim Preserve WTPeriod(n)
                    WTPeriod(n) = tmpresult
                    n += 1
                End If
            Next
        Next

        'Tính tổng thời gian làm việc trong ngày
        Dim TotalWorkingTime As Integer = 0
        For i = 0 To WTPeriod.GetUpperBound(0)
            'Không làm tròn ở đây, để cuối cùng mới làm tròn
            TotalWorkingTime += DateDiff(DateInterval.Second, WTPeriod(i).FromDate, WTPeriod(i).ToDate)
        Next

        Dim wt As Integer = 0
        Dim FullTimeStipulate As Date 'Giờ đủ giờ làm quy định
        Dim WTAfterCalcNightTime(-1) As LaborHours
        If TotalWorkingTime > WorkingTimeStipulate Then 'Nếu tổng thời gian làm việc lớn hơn 8h
            'Lấy thời gian mà tổng số giờ làm đã đủ 8h quy định
            For i = 0 To WTPeriod.GetUpperBound(0)
                wt += DateDiff(DateInterval.Second, WTPeriod(i).FromDate, WTPeriod(i).ToDate)
                If wt > WorkingTimeStipulate Then
                    FullTimeStipulate = WTPeriod(i).ToDate.Subtract(New TimeSpan(0, 0, wt - WorkingTimeStipulate))
                    Exit For
                End If
            Next

            'Tạo 1 bảng mới chứa các period sau khi đã tách FullTimeStipulate
            Dim WTBeforeCalcNightTime(WTPeriod.GetUpperBound(0) + 1) As LaborHours
            n = 0
            For i = 0 To WTPeriod.GetUpperBound(0)
                WTBeforeCalcNightTime(n).WorkPeriod = WTPeriod(i)
                WTBeforeCalcNightTime(n).SalaryType = SalaryRateType.Normal_Day
                If DateTimeChecking.BelongtoPeriods(WTPeriod(i), FullTimeStipulate, DateInterval.Second) Then
                    WTBeforeCalcNightTime(n).WorkPeriod.ToDate = FullTimeStipulate
                    n += 1
                    WTBeforeCalcNightTime(n).WorkPeriod.FromDate = FullTimeStipulate
                    WTBeforeCalcNightTime(n).WorkPeriod.ToDate = WTPeriod(i).ToDate
                    WTBeforeCalcNightTime(n).SalaryType = SalaryRateType.OT_Normal_Day
                End If

                If n > 0 Then
                    If WTBeforeCalcNightTime(n - 1).SalaryType = SalaryRateType.OT_Normal_Day Then WTBeforeCalcNightTime(n).SalaryType = SalaryRateType.OT_Normal_Day
                End If
                n += 1
            Next

            'Kết hợp với thời gian làm đêm
            n = 0
            For i = 0 To WTBeforeCalcNightTime.GetUpperBound(0)
                tmp = DateTimeChecking.Add2Period(WTBeforeCalcNightTime(i).WorkPeriod, NightTime, DateInterval.Second)
                If tmp.FromDate = Nothing And tmp.ToDate = Nothing Then
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n) = WTBeforeCalcNightTime(i)
                    n += 1
                Else
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n).WorkPeriod = tmp
                    If WTBeforeCalcNightTime(i).SalaryType = SalaryRateType.Normal_Day Then
                        WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Night
                    ElseIf WTBeforeCalcNightTime(i).SalaryType = SalaryRateType.OT_Normal_Day Then
                        WTAfterCalcNightTime(n).SalaryType = SalaryRateType.OT_Normal_Night
                    End If
                    n += 1

                    Dim tmp2(-1) As DateTimeChecking.Period
                    DateTimeChecking.Subtract2Period(WTBeforeCalcNightTime(i).WorkPeriod, NightTime, tmp2)
                    For j = 0 To tmp2.GetUpperBound(0)
                        ReDim Preserve WTAfterCalcNightTime(n)
                        WTAfterCalcNightTime(n).WorkPeriod = tmp2(j)
                        WTAfterCalcNightTime(n).SalaryType = WTBeforeCalcNightTime(i).SalaryType
                        n += 1
                    Next
                End If
            Next

        Else 'Nếu tổng thời gian làm việc nhỏ hơn 8h
            'Kết hợp với thời gian làm đêm
            n = 0
            For i = 0 To WTPeriod.GetUpperBound(0)
                tmp = DateTimeChecking.Add2Period(WTPeriod(i), NightTime, DateInterval.Second)
                If tmp.FromDate = Nothing And tmp.ToDate = Nothing Then
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n).WorkPeriod = WTPeriod(i)
                    WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Day
                    n += 1
                Else
                    ReDim Preserve WTAfterCalcNightTime(n)
                    WTAfterCalcNightTime(n).WorkPeriod = tmp
                    WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Night
                    n += 1

                    Dim tmp2(-1) As DateTimeChecking.Period
                    DateTimeChecking.Subtract2Period(WTPeriod(i), NightTime, tmp2)
                    For j = 0 To tmp2.GetUpperBound(0)
                        ReDim Preserve WTAfterCalcNightTime(n)
                        WTAfterCalcNightTime(n).WorkPeriod = tmp2(j)
                        WTAfterCalcNightTime(n).SalaryType = SalaryRateType.Normal_Day
                        n += 1
                    Next
                End If
            Next
        End If

        'Đặt lại loại lương cho đúng
        If isHoliday Then
            For i = 0 To WTAfterCalcNightTime.GetUpperBound(0)
                Select Case WTAfterCalcNightTime(i).SalaryType
                    Case SalaryRateType.Normal_Day
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Holiday_Day
                    Case SalaryRateType.Normal_Night
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Holiday_Night
                    Case SalaryRateType.OT_Normal_Day
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Holiday_Day
                    Case SalaryRateType.OT_Normal_Night
                        WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Holiday_Night
                End Select
            Next
        Else
            If WorkingDay.DayOfWeek = DayOfWeek.Sunday Then
                For i = 0 To WTAfterCalcNightTime.GetUpperBound(0)
                    Select Case WTAfterCalcNightTime(i).SalaryType
                        Case SalaryRateType.Normal_Day
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Sunday_Day
                        Case SalaryRateType.Normal_Night
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.Sunday_Night
                        Case SalaryRateType.OT_Normal_Day
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Sunday_Day
                        Case SalaryRateType.OT_Normal_Night
                            WTAfterCalcNightTime(i).SalaryType = SalaryRateType.OT_Sunday_Night
                    End Select
                Next
            End If
        End If

        'Tính giờ công
        Dim WTResult(WTAfterCalcNightTime.GetUpperBound(0)) As WorkingTime
        For i = 0 To WTAfterCalcNightTime.GetUpperBound(0)
            WTResult(i).Time = DateDiff(DateInterval.Second, WTAfterCalcNightTime(i).WorkPeriod.FromDate, WTAfterCalcNightTime(i).WorkPeriod.ToDate)
            WTResult(i).SalaryType = WTAfterCalcNightTime(i).SalaryType
        Next

        'Tổng hợp số giờ làm có cùng loại lương
        For i = 0 To WTResult.GetUpperBound(0) - 1
            For j = i + 1 To WTResult.GetUpperBound(0)
                If WTResult(i).SalaryType = WTResult(j).SalaryType Then
                    WTResult(i).Time += WTResult(j).Time
                    WTResult(j).Time = -1
                End If
            Next
        Next
        n = 0
        Dim realresult(-1) As WorkingTime
        For i = 0 To WTResult.GetUpperBound(0)
            If WTResult(i).Time <> -1 Then
                ReDim Preserve realresult(n)
                realresult(n) = WTResult(i)
                n += 1
            End If
        Next

        'Làm tròn kết quả
        For i = realresult.GetLowerBound(0) To realresult.GetUpperBound(0)
            If mRoundType = RoundType.RoundTotalDayTime Then
                realresult(i).Time = RoundTime(CLng(FormatNumber((realresult(i).Time / 60), 0)), mRoundTimeType)
            Else
                realresult(i).Time = CLng(FormatNumber((realresult(i).Time / 60), 0))
            End If
        Next
        Result = realresult
    End Sub
    ''' <summary>
    ''' <paramref name="FromDate"/> là thời gian ngày bắt đầu quẹt thẻ
    ''' <paramref name="ToDate"/> là thời gian ngày kết thúc quẹt thẻ (không tính ngày mới của ca đêm)
    ''' <paramref name="checkDateTime"/> là mảng thời gian quẹt thẻ bao gồm cả ngày lẫn giờ
    ''' <paramref name="defaultShift"/> là ca mặc định được đăng kí bởi employee đó chỉ có giờ
    ''' <paramref name="ReggedShifts"/> là mảng thời gian đăng kí thay đổi ca bao gồm cả ngày lẫn giờ
    ''' Kết quả bao gồm 1 mảng gồm có 2 trường ngày quẹt thẻ và giờ quẹt thẻ tương ứng với ngày đó
    ''' </summary>
    Public Shared Sub GetCheckIO(ByVal FromDate As Date, ByVal ToDate As Date, ByVal checkDateTime() As Date, ByVal defaultShift As Shift, ByVal ReggedShifts() As Shift, ByRef Result() As CheckInOut)
        Dim checkIO(-1) As CheckInOut
        Dim mDate As Date 'Ngày giờ
        Dim i, j, k As Integer
        Dim myCult As New Globalization.CultureInfo("vi-VN")

        'Sắp xếp lại thời gian quẹt thẻ từ nhỏ tới lớn
        For i = checkDateTime.GetLowerBound(0) To checkDateTime.GetUpperBound(0) - 1
            For j = i + 1 To checkDateTime.GetUpperBound(0)
                If checkDateTime(i) > checkDateTime(j) Then
                    mDate = checkDateTime(i)
                    checkDateTime(i) = checkDateTime(j)
                    checkDateTime(j) = mDate
                End If
            Next
        Next

        'Tính thời gian shift mỗi ngày
        Dim minDate As Date = FromDate 'checkDateTime(checkDateTime.GetLowerBound(0)).Date 'Ngày
        Dim maxdate As Date = ToDate 'checkDateTime(checkDateTime.GetUpperBound(0)).Date 'Ngày
        Dim shift_every_day(DateDiff(DateInterval.Day, minDate, maxdate)) As Shift 'Ngày giờ

        For i = shift_every_day.GetLowerBound(0) To shift_every_day.GetUpperBound(0)
            'Gán shift mỗi ngày = default shift
            shift_every_day(i).FromTime = minDate.Add(New TimeSpan(i, defaultShift.FromTime.Hour, defaultShift.FromTime.Minute, defaultShift.FromTime.Second))
            shift_every_day(i).ToTime = minDate.Add(New TimeSpan(i, defaultShift.ToTime.Hour, defaultShift.ToTime.Minute, defaultShift.ToTime.Second))
            If shift_every_day(i).FromTime > shift_every_day(i).ToTime Then shift_every_day(i).ToTime = shift_every_day(i).ToTime.AddDays(1)
            'Nếu trùng với ngày đã đăng kí thì lấy ngày đã đăng kí
            For j = ReggedShifts.GetLowerBound(0) To ReggedShifts.GetUpperBound(0)
                If shift_every_day(i).FromTime.Date = ReggedShifts(j).FromTime.Date Then
                    shift_every_day(i) = ReggedShifts(j)
                    Exit For
                End If
            Next
        Next

        'Phân chia thành các phân đoạn để tính thời gian quẹt thẻ thuộc ca nào
        Dim shift_range(shift_every_day.GetUpperBound(0)) As DateTimeChecking.Period 'Ngày giờ
        For i = shift_range.GetLowerBound(0) To shift_range.GetUpperBound(0)
            If i = shift_range.GetLowerBound(0) And i <> shift_range.GetUpperBound(0) Then
                Dim quagio4tiengcatruoc As Date = minDate.Add(New TimeSpan(-1, 4 + defaultShift.ToTime.Hour, defaultShift.ToTime.Minute, defaultShift.ToTime.Second))
                If defaultShift.FromTime > defaultShift.ToTime Then quagio4tiengcatruoc = quagio4tiengcatruoc.AddDays(1)
                Dim lech As TimeSpan = shift_every_day(i).FromTime.Subtract(quagio4tiengcatruoc)
                shift_range(i).FromDate = shift_every_day(i).FromTime.AddHours(-lech.TotalHours / 2)

                Dim cong4tiengcuoica As Date = shift_every_day(i).ToTime.AddHours(4)
                shift_range(i).ToDate = cong4tiengcuoica.AddHours((shift_every_day(i + 1).FromTime.Subtract(cong4tiengcuoica)).TotalHours / 2)
            ElseIf i = shift_range.GetUpperBound(0) And i <> shift_range.GetLowerBound(0) Then
                shift_range(i).FromDate = shift_range(i - 1).ToDate

                Dim cong4tiengcuoica As Date = shift_every_day(i).ToTime.AddHours(4)
                shift_range(i).ToDate = cong4tiengcuoica.AddHours((maxdate.Add(New TimeSpan(1, defaultShift.FromTime.Hour, defaultShift.FromTime.Minute, defaultShift.FromTime.Second)).Subtract(cong4tiengcuoica)).TotalHours / 2)
            ElseIf shift_range.GetLowerBound(0) = shift_range.GetUpperBound(0) Then
                Dim quagio4tiengcatruoc As Date = minDate.Add(New TimeSpan(-1, 4 + defaultShift.ToTime.Hour, defaultShift.ToTime.Minute, defaultShift.ToTime.Second))
                If defaultShift.FromTime > defaultShift.ToTime Then quagio4tiengcatruoc = quagio4tiengcatruoc.AddDays(1)
                Dim lech As TimeSpan = shift_every_day(i).FromTime.Subtract(quagio4tiengcatruoc)
                shift_range(i).FromDate = shift_every_day(i).FromTime.AddHours(-lech.TotalHours / 2)

                Dim cong4tiengcuoica As Date = shift_every_day(i).ToTime.AddHours(4)
                shift_range(i).ToDate = cong4tiengcuoica.AddHours((maxdate.Add(New TimeSpan(1, defaultShift.FromTime.Hour, defaultShift.FromTime.Minute, defaultShift.FromTime.Second)).Subtract(cong4tiengcuoica)).TotalHours / 2)
            Else
                shift_range(i).FromDate = shift_range(i - 1).ToDate

                Dim cong4tiengcuoica As Date = shift_every_day(i).ToTime.AddHours(4)
                shift_range(i).ToDate = cong4tiengcuoica.AddHours((shift_every_day(i + 1).FromTime.Subtract(cong4tiengcuoica)).TotalHours / 2)
            End If
        Next

        'Kiểm tra xem thời gian quẹt thẻ có thuộc các phân đoạn ca k0
        k = 0
        For i = shift_range.GetLowerBound(0) To shift_range.GetUpperBound(0)
            For j = checkDateTime.GetLowerBound(0) To checkDateTime.GetUpperBound(0)
                If DateTimeChecking.BelongtoPeriods(shift_range(i), checkDateTime(j), DateInterval.Second) Then
                    If checkDateTime(j) <> shift_range(i).ToDate Then
                        ReDim Preserve checkIO(k)
                        checkIO(k).CheckDate = shift_range(i).FromDate.Date
                        'Tuan Modify
                        'checkIO(k).CheckTime = Date.Parse("30/12/1899 " & checkDateTime(j).Hour & ":" & checkDateTime(j).Minute & ":" & checkDateTime(j).Second, myCult)
                        checkIO(k).CheckTime = checkDateTime(j)
                        k += 1
                    End If
                End If
            Next
        Next

        Result = checkIO
    End Sub
End Class
