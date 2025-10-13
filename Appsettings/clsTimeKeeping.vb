Public Class TimeKeeping

    ''' <summary>
    ''' Kiểu ca làm việc
    ''' </summary>
    Public Structure Shift
        Dim TimeOrder As Integer
        Dim FromTime As Date
        Dim ToTime As Date
        Dim NormalSalaryLevel As Integer
        Dim SundaySalaryLevel As Integer
        Dim HolidaySalaryLevel As Integer
        Dim RestTimeFrom As Date
        Dim RestTimeTo As Date
    End Structure

    Public Structure WorkingTime
        Dim Time As Long 'Tính bằng phút
        Dim SalaryLevel As Integer
    End Structure

    Public Enum RoundType
        RoundTotalMonthTime
        RoundTotalDayTime
        RoundRecordTime
    End Enum

    Public Enum RoundTimeType
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
            Case RoundTimeType.FifteenMinutes
                'm = 15 * Math.Round((value.Minute * 60 + value.Second) / (15 * 60), 0)
                m = 15 * CDbl(FormatNumber((value.Minute * 60 + value.Second) / (15 * 60), 0))
                If m = 60 Then h += 1 : m = 0
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
            Case RoundTimeType.ThirtyMinutes
                'm = 30 * Math.Round((value.Minute * 60 + value.Second) / (30 * 60), 0)
                m = 30 * CDbl(FormatNumber((value.Minute * 60 + value.Second) / (30 * 60), 0))
                If m = 60 Then h += 1 : m = 0
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
            Case RoundTimeType.OneHour
                'm = 60 * Math.Round((value.Minute * 60 + value.Second) / (60 * 60), 0)
                m = 60 * CDbl(FormatNumber((value.Minute * 60 + value.Second) / (60 * 60), 0))
                If m = 60 Then h += 1 : m = 0
                Return Date.Parse(value.Day & "/" & value.Month & "/" & value.Year & " " & h & ":" & m & ":00", myCultureInfo)
        End Select
    End Function

    ''' <summary>
    ''' Làm tròn theo khoảng thời gian 15 phút, nửa tiếng, hay 1 tiếng
    ''' <paramref name="value"/> là kiểu long, là số phút, kết quả trả lại cũng là số phút
    ''' </summary>
    Public Shared Function RoundTime(ByVal value As Long, ByVal type As RoundTimeType) As Long
        Select Case type
            Case RoundTimeType.FifteenMinutes
                'Return 15 * Math.Round(value / 15, 0)
                Return 15 * CDbl(FormatNumber(value / 15, 0))
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
        If value.Length Mod 2 = 0 Then
            Result = value
            Return
        End If
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
    ''' Hàm tính giao của 2 khoảng thời gian, kết quả trả lại là rỗng nếu 2 khoảng này k0 trùng nhau
    ''' Kết quả trả lại là 1 khoảng hoặc chỉ 1 thời điểm duy nhất
    ''' </summary>
    Public Shared Sub ADDTwoPeriod(ByVal Period1 As DateTimeChecking.Period, ByVal Period2 As DateTimeChecking.Period, ByVal Inteval As DateInterval, ByRef PeriodResult As DateTimeChecking.Period)
        Try
            Dim d(-1) As Date
            Dim i, j As Byte
            i = 0
            'So sanh de lay ra mang nhung ngay la giao cua 2 khoang
            If DateDiff(Inteval, Period2.FromDate, Period1.FromDate) >= 0 And DateDiff(Inteval, Period1.FromDate, Period2.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period1.FromDate
                i += 1
            End If
            If DateDiff(Inteval, Period2.FromDate, Period1.ToDate) >= 0 And DateDiff(Inteval, Period1.ToDate, Period2.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period1.ToDate
                i += 1
            End If
            If DateDiff(Inteval, Period1.FromDate, Period2.FromDate) >= 0 And DateDiff(Inteval, Period2.FromDate, Period1.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period2.FromDate
                i += 1
            End If
            If DateDiff(Inteval, Period1.FromDate, Period2.ToDate) >= 0 And DateDiff(Inteval, Period2.ToDate, Period1.ToDate) >= 0 Then
                ReDim Preserve d(i)
                d(i) = Period2.ToDate
                i += 1
            End If
            'Neu k0 co ket qua
            If d.Length = 0 Then
                PeriodResult = Nothing
                Exit Sub
            End If
            'Sap xep lai mang theo thu tu tu nho den lon
            For i = 0 To d.GetUpperBound(0) - 1
                For j = i + 1 To d.GetUpperBound(0)
                    If DateDiff(Inteval, d(i), d(j)) < 0 Then
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
            PeriodResult.FromDate = r(0)
            PeriodResult.ToDate = r(1)
        Catch ex As Exception When DateDiff(Inteval, Period1.FromDate, Period1.ToDate) < 0 Or DateDiff(Inteval, Period2.FromDate, Period2.ToDate) < 0
            MsgBox("FromDate must lower than or equal ToDate!", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' Tính thời gian làm việc mỗi ngày
    ''' Chú ý <paramref name="recordTime"/> phải được lọc trước khi đưa vào biến nếu k0 sẽ bị lỗi
    ''' </summary>
    Public Shared Sub CalcWorkingTimeperDay(ByVal WorkingDay As Date, ByVal isHoliday As Boolean, ByVal mShift() As Shift, ByVal recordTime() As Date, ByVal mRoundType As RoundType, ByVal mRoundTimeType As RoundTimeType, ByRef Result() As WorkingTime)
        Dim i, j, n, x As Integer
        Dim tmp, tmp1, tmp2 As DateTimeChecking.Period
        Dim rs(-1), eighthoursrs(-1), realrs(-1) As WorkingTime
        Dim total As Long
        Dim eighthoursdevide As Boolean
        Dim inTimeSalaryLevel As Integer
        Dim salarylevel(mShift.GetUpperBound(0)) As Integer

        For i = mShift.GetLowerBound(0) To mShift.GetUpperBound(0)
            mShift(i).FromTime = Date.Parse("1/1/2000 " & mShift(i).FromTime.Hour & ":" & mShift(i).FromTime.Minute & ":" & mShift(i).FromTime.Second)
            If i > 0 Then If mShift(i).FromTime < mShift(i - 1).ToTime Then mShift(i).FromTime = mShift(i).FromTime.AddDays(1)
            mShift(i).ToTime = Date.Parse("1/1/2000 " & mShift(i).ToTime.Hour & ":" & mShift(i).ToTime.Minute & ":" & mShift(i).ToTime.Second)
            If mShift(i).FromTime > mShift(i).ToTime Then mShift(i).ToTime = mShift(i).ToTime.AddDays(1)
        Next

        For i = recordTime.GetLowerBound(0) To recordTime.GetUpperBound(0)
            recordTime(i) = Date.Parse("1/1/2000 " & recordTime(i).Hour & ":" & recordTime(i).Minute & ":" & recordTime(i).Second)
            If i > 0 Then If recordTime(i) < recordTime(i - 1) Then recordTime(i) = recordTime(i).AddDays(1)
        Next

        'Tìm mức lương của giờ làm việc bình thường
        'là mức lương thấp nhất của 1 ca làm việc
        If isHoliday Then
            For i = 0 To mShift.GetUpperBound(0)
                salarylevel(i) = mShift(i).HolidaySalaryLevel
            Next
        Else
            If WorkingDay.DayOfWeek = DayOfWeek.Sunday Then
                For i = 0 To mShift.GetUpperBound(0)
                    salarylevel(i) = mShift(i).SundaySalaryLevel
                Next
            Else
                For i = 0 To mShift.GetUpperBound(0)
                    salarylevel(i) = mShift(i).NormalSalaryLevel
                Next
            End If
        End If
        inTimeSalaryLevel = salarylevel(0)
        For i = 1 To salarylevel.GetUpperBound(0)
            If inTimeSalaryLevel > salarylevel(i) Then
                inTimeSalaryLevel = salarylevel(i)
            End If
        Next

        n = 0 'Biến đếm số lượng bản ghi kết quả
        For i = 0 To (recordTime.Length / 2) - 1 'Chạy theo số bản ghi quẹt thẻ
            For j = 0 To mShift.Length - 1 'Chạy theo số ca làm việc
                'tmp1.FromDate = Date.Parse("1/1/2000 " & recordTime(i * 2).Hour & ":" & recordTime(i * 2).Minute & ":" & recordTime(i * 2).Second) 'recordTime(i * 2)
                'tmp1.ToDate = Date.Parse("1/1/2000 " & recordTime(i * 2 + 1).Hour & ":" & recordTime(i * 2 + 1).Minute & ":" & recordTime(i * 2 + 1).Second) 'recordTime(i * 2 + 1)
                'If DateDiff(DateInterval.Second, tmp1.FromDate, tmp1.ToDate) < 0 Then tmp1.ToDate = tmp1.ToDate.AddDays(1)
                'tmp2.FromDate = Date.Parse("1/1/2000 " & mShift(j).FromTime.Hour & ":" & mShift(j).FromTime.Minute & ":" & mShift(j).FromTime.Second) 'mShift(j).FromTime
                'tmp2.ToDate = Date.Parse("1/1/2000 " & mShift(j).ToTime.Hour & ":" & mShift(j).ToTime.Minute & ":" & mShift(j).ToTime.Second) 'mShift(j).ToTime
                'If DateDiff(DateInterval.Second, tmp2.FromDate, tmp2.ToDate) < 0 Then tmp2.ToDate = tmp2.ToDate.AddDays(1)
                tmp1.FromDate = recordTime(i * 2)
                tmp1.ToDate = recordTime(i * 2 + 1)
                tmp2.FromDate = mShift(j).FromTime
                tmp2.ToDate = mShift(j).ToTime
                ADDTwoPeriod(tmp1, tmp2, DateInterval.Second, tmp)
                If tmp.FromDate <> Nothing And tmp.ToDate <> Nothing Then
                    Select Case mRoundType
                        Case RoundType.RoundTotalMonthTime
                            ReDim Preserve rs(n)
                            rs(n).Time = DateDiff(DateInterval.Minute, tmp.FromDate, tmp.ToDate, FirstDayOfWeek.Monday)
                            If isHoliday Then
                                rs(n).SalaryLevel = mShift(j).HolidaySalaryLevel
                            Else
                                If WorkingDay.DayOfWeek = DayOfWeek.Sunday Then
                                    rs(n).SalaryLevel = mShift(j).SundaySalaryLevel
                                Else
                                    rs(n).SalaryLevel = mShift(j).NormalSalaryLevel
                                End If
                            End If
                            n += 1
                        Case RoundType.RoundTotalDayTime
                            ReDim Preserve rs(n)
                            rs(n).Time = RoundTime(DateDiff(DateInterval.Minute, tmp.FromDate, tmp.ToDate, FirstDayOfWeek.Monday), mRoundTimeType)
                            If isHoliday Then
                                rs(n).SalaryLevel = mShift(j).HolidaySalaryLevel
                            Else
                                If WorkingDay.DayOfWeek = DayOfWeek.Sunday Then
                                    rs(n).SalaryLevel = mShift(j).SundaySalaryLevel
                                Else
                                    rs(n).SalaryLevel = mShift(j).NormalSalaryLevel
                                End If
                            End If
                            n += 1
                        Case RoundType.RoundRecordTime
                            ReDim Preserve rs(n)
                            rs(n).Time = DateDiff(DateInterval.Minute, RoundTime(tmp.FromDate, mRoundTimeType), RoundTime(tmp.ToDate, mRoundTimeType), FirstDayOfWeek.Monday)
                            If isHoliday Then
                                rs(n).SalaryLevel = mShift(j).HolidaySalaryLevel
                            Else
                                If WorkingDay.DayOfWeek = DayOfWeek.Sunday Then
                                    rs(n).SalaryLevel = mShift(j).SundaySalaryLevel
                                Else
                                    rs(n).SalaryLevel = mShift(j).NormalSalaryLevel
                                End If
                            End If
                            n += 1
                    End Select
                End If
            Next
        Next
        'Nếu số giờ làm việc trong ngày nhỏ hơn 8h thì đó k0 phải lương ngoài giờ
        total = 0
        x = 0
        eighthoursdevide = False
        For n = 0 To rs.GetUpperBound(0)
            total += rs(n).Time
            If n > 0 Then
                If (total > 480) And (Not eighthoursdevide) Then
                    ReDim Preserve eighthoursrs(x)
                    eighthoursrs(x - 1).Time = rs(n - 1).Time + rs(n).Time - (total - 480)
                    eighthoursrs(x).Time = total - 480
                    eighthoursrs(x).SalaryLevel = rs(n).SalaryLevel
                    x += 1
                    eighthoursdevide = True
                ElseIf total > 480 And eighthoursdevide Then
                    ReDim Preserve eighthoursrs(x)
                    eighthoursrs(x).Time = rs(n).Time
                    eighthoursrs(x).SalaryLevel = rs(n).SalaryLevel
                    x += 1
                ElseIf total <= 480 Then
                    ReDim Preserve eighthoursrs(x)
                    eighthoursrs(x).Time = rs(n).Time
                    'eighthoursrs(x).SalaryLevel = inTimeSalaryLevel
                    If (rs(n).SalaryLevel / inTimeSalaryLevel) >= 1.5 Then
                        eighthoursrs(x).SalaryLevel = rs(n).SalaryLevel / 1.5
                    Else
                        eighthoursrs(x).SalaryLevel = rs(n).SalaryLevel
                    End If
                    x += 1
                End If
            ElseIf n = 0 Then
                If (total > 480) And (Not eighthoursdevide) Then
                    ReDim Preserve eighthoursrs(1)
                    eighthoursrs(0).Time = 480
                    'eighthoursrs(0).SalaryLevel = inTimeSalaryLevel
                    If (rs(0).SalaryLevel / inTimeSalaryLevel) >= 1.5 Then
                        eighthoursrs(0).SalaryLevel = rs(0).SalaryLevel / 1.5
                    Else
                        eighthoursrs(0).SalaryLevel = rs(0).SalaryLevel
                    End If
                    eighthoursrs(1).Time = total - 480
                    eighthoursrs(1).SalaryLevel = rs(0).SalaryLevel
                    eighthoursdevide = True
                    x = 2
                ElseIf total <= 480 Then
                    ReDim Preserve eighthoursrs(0)
                    eighthoursrs(0).Time = rs(0).Time
                    'eighthoursrs(0).SalaryLevel = inTimeSalaryLevel
                    If (rs(0).SalaryLevel / inTimeSalaryLevel) >= 1.5 Then
                        eighthoursrs(0).SalaryLevel = rs(0).SalaryLevel / 1.5
                    Else
                        eighthoursrs(0).SalaryLevel = rs(0).SalaryLevel
                    End If
                    x += 1
                End If
            End If
        Next
        'Tổng hợp số giờ làm có salarylevel bằng nhau
        For i = 0 To eighthoursrs.GetUpperBound(0) - 1
            For j = i + 1 To eighthoursrs.GetUpperBound(0)
                If eighthoursrs(i).SalaryLevel = eighthoursrs(j).SalaryLevel Then
                    eighthoursrs(i).Time += eighthoursrs(j).Time
                    eighthoursrs(j).Time = -1
                    eighthoursrs(j).SalaryLevel = -1
                End If
            Next
        Next
        n = 0
        For i = 0 To eighthoursrs.GetUpperBound(0)
            If eighthoursrs(i).Time <> -1 And eighthoursrs(i).SalaryLevel <> -1 Then
                ReDim Preserve realrs(n)
                realrs(n).Time = eighthoursrs(i).Time
                realrs(n).SalaryLevel = eighthoursrs(i).SalaryLevel
                n += 1
            End If
        Next
        Result = realrs
    End Sub
End Class

