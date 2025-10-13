Imports VBReport
Imports AxAcroPDFLib
Imports Entity
Imports Excel1 = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO
Imports System
Imports Appsettings
Public Class Giang_TimeKeeping
    Dim kncsdl As New SmartBooks.BusinessLogic.KetNoiCSDL
    Dim kn As New connect(DbSetting.dataPath)
    ' Dim tkp As New SmartBooks.BusinessLogic.Giang_TimeKeeping
    Dim dbda As New SmartBooks.BusinessLogic.DBData

    ' Cac ham tinh toan
    '   kiem tra co trong che do thai san

    Public Function KiemTraCoTrongCheDoThaiSan(ByVal Employee_ID As String, ByVal ThoiDiemKiemTra As DateTime) As Boolean
        Dim dt As New DataTable
        dt = dbda.LayCheDoThaiSan(Employee_ID)
        Dim dt_rowCount = dt.Rows.Count()
        If dt_rowCount = 0 Then
            Return False
        Else
            If DateTime.Compare(ThoiDiemKiemTra, dt.Rows(0)("Fromdate")) >= 0 And DateTime.Compare(ThoiDiemKiemTra, dt.Rows(0)("ToDate")) <= 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function KiemTraCoTrongCheDoNghiSinh(ByVal Employee_ID As String, ByVal ThoiDiemKiemTra As DateTime) As Boolean
        Dim dt As New DataTable
        dt = dbda.LayCheDoNghiSinh(Employee_ID)
        Dim dt_rowCount = dt.Rows.Count()
        If dt_rowCount = 0 Then
            Return False
        Else
            If DateTime.Compare(ThoiDiemKiemTra, dt.Rows(0)("Fromdate")) >= 0 And DateTime.Compare(ThoiDiemKiemTra, dt.Rows(0)("ToDate")) <= 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function KiemTraCoTrongCheDoConNho(ByVal Employee_ID As String, ByVal ThoiDiemKiemTra As DateTime) As Boolean
        Dim dt As New DataTable
        Dim dtime As DateTime
        dt = dbda.LayThongTinTroCapConNho(Employee_ID)
        Dim dt_rowCount = dt.Rows.Count()
        If dt_rowCount = 0 Then
            Return False
        Else
            dtime = dt.Rows(0)("BabyDate")
            dtime = dtime.AddDays(365)
            If DateTime.Compare(ThoiDiemKiemTra, dt.Rows(0)("BabyDate")) >= 0 And DateTime.Compare(ThoiDiemKiemTra, dtime) <= 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function KiemTraCoTrongCheDoConNhoDuoiMotTuoi(ByVal NgayKiemTra As DateTime, ByVal NgaySinh As DateTime) As Boolean
        If DateTime.Compare(NgayKiemTra, NgaySinh) >= 0 And DateTime.Compare(NgayKiemTra, NgaySinh.AddYears(1)) <= 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function KiemTraCoPhepHayKhong(ByVal Employee_ID As String, ByVal ThoiDiemKiemTra As DateTime) As String
        Dim dt As New DataTable
        Dim dtime As DateTime
        dt = dbda.LayThongTinNghiPhep(ThoiDiemKiemTra, Employee_ID)
        Dim dt_rowCount = dt.Rows.Count()
        If dt_rowCount = 0 Then
            Return "TD"
        Else : Return dt.Rows(0)("LeaveType_ID")
        End If
    End Function

    Public Function isHoliday(ByVal NgayKiemTra As DateTime) As Boolean
        Try
            Dim dt As DataTable = dbda.HolidaysPlan_select_ByH_date(NgayKiemTra)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
            Return False
        Catch ex As Exception
            ex.ToString()
        End Try
    End Function
    Public Function KiemTraNhanVienDuDieuKienChamCong(ByVal MaNhanVien As String, ByVal NgayKiemTra As DateTime) As Boolean
        Dim dt As DataTable = dbda.LayNhanVienTheoMa(MaNhanVien)
        If dt.Rows.Count <= 0 Then
            Return False
        End If
        Dim dtNhanVienNghiSinh As DataTable = kncsdl.Select_CauLenhSQL("select * from HR_EmployeeRegisMaternityLeave where Employee_ID = '" + MaNhanVien + "'")
        Dim row As DataRow
        If dt.Rows.Count > 0 And Not IsDBNull(dt.Rows(0).Item("StartedDate")) Then
            If CStr(dt.Rows(0).Item("Employee_Status")) = "Active" Then
                If DateTime.Compare(NgayKiemTra, dt.Rows(0).Item("StartedDate")) >= 0 Then
                    If dtNhanVienNghiSinh.Rows.Count <= 0 Then
                        Return True
                    Else
                        For Each row In dtNhanVienNghiSinh.Rows
                            If DateTime.Compare(NgayKiemTra, row("Fromdate")) >= 0 And DateTime.Compare(NgayKiemTra, row("ToDate")) <= 0 Then
                                Return False
                            End If
                        Next
                        Return True
                    End If
                Else : Return False
                End If
            ElseIf DateTime.Compare(NgayKiemTra, dt.Rows(0).Item("StartedDate")) >= 0 And DateTime.Compare(NgayKiemTra, dt.Rows(0).Item("TernimationDate")) <= 0 Then
                If dtNhanVienNghiSinh.Rows.Count <= 0 Then
                    Return True
                Else
                    For Each row In dtNhanVienNghiSinh.Rows
                        If DateTime.Compare(NgayKiemTra, row("Fromdate")) >= 0 And DateTime.Compare(NgayKiemTra, row("ToDate")) <= 0 Then
                            Return False
                        End If
                    Next
                    Return True
                End If
            Else : Return False
            End If
        End If
        Return False
    End Function

    Public Function TinhCong(ByVal LayGioDauGioCuoi As Boolean, ByVal CauHinhTinhCongDuaVaoDangKyGioiHanTangCa As String, ByVal Employee_ID As String, ByVal NgayTinhCong As DateTime, ByVal GioiHanGioVao As Integer, ByVal GioiHanGioRa As Integer, ByVal DieuKienToiThieuCheDoThaiSanConNhoDuocThemGioLam As Double, ByVal db_GioGioiHanTangCa As Double, ByVal BangXinRaNgoai As DataTable, ByVal Ca As String, ByVal GioVaoCa As DateTime, ByVal GioTanCa As DateTime, ByVal BangKhungGioCuaCa As DataTable, ByVal SoGioToiThieuDuocTinhTangCa As Integer, ByVal dtThoiGianQuet As DataTable, ByVal bKiemTraCheDo As Double, ByVal ChuanHoaGioQuet1 As Integer, ByVal ChuanHoaGioQuet2 As Integer, ByVal MaCongTy As String, ByVal CauHinhTinhCong As String) As String
        Dim sql As String = String.Empty
        Dim GioiHanTangCa As Double = 0
        Dim bVuotQuaThoiGianTangCa As Boolean = False
        Dim TongGioRaNgoai As Double = 0
        Dim Key As String = NgayTinhCong.Year.ToString + getMonth_HaiChuSo(NgayTinhCong) + getDay_HaiChuSo(NgayTinhCong) + "-" + Employee_ID
        Dim mangrow, rowXinRaNgoai As DataRow()
        If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "1" Or CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "2" Then
            'mangrow = BangGioiHanTangCa.Select("Employee_id = '" + Employee_ID + "' and workingdate = '" + DateToString(NgayTinhCong) + "'")
            If db_GioGioiHanTangCa = -400 Then
                If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "2" Then
                    GioiHanTangCa = 100
                Else
                    GioiHanTangCa = 0
                End If
            Else
                GioiHanTangCa = db_GioGioiHanTangCa
            End If
        End If
        Dim dtThoiGianBatDauTinhCa, dtThoiGianKetThucTinhCa, QuetVao, QuetRa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen, GioGioiHanTangCa As DateTime
        Dim WorkingTime As String
        Dim QuetVaoMuon, QuetRaSom As Double
        Dim QuetVao_LanDau As DateTime
        rowXinRaNgoai = BangXinRaNgoai.Select("Employee_ID = '" + Employee_ID + "' and TimeDate = '" + DateToString(NgayTinhCong) + "'")
        GioGioiHanTangCa = GioTanCa.AddMinutes(GioiHanTangCa * 60)
        dtThoiGianBatDauTinhCa = GioVaoCa.AddHours(0 - GioiHanGioVao)
        dtThoiGianKetThucTinhCa = GioTanCa.AddHours(GioiHanGioRa)
        ChuanHoaDuLieuChamCong(dtThoiGianQuet, LayGioDauGioCuoi)
        mangrow = BangKhungGioCuaCa.Select("ShiftName = '" + Ca + "'", "No asc")
        Dim random As New random
        If mangrow.Length > 0 Then
            Dim row, row1 As DataRow
            For i As Integer = 0 To dtThoiGianQuet.Rows.Count - 2
                QuetVao = dtThoiGianQuet.Rows(i)("AccessTime")
                QuetRa = dtThoiGianQuet.Rows(i + 1)("AccessTime")
                If i = 0 Then
                    QuetVao_LanDau = QuetVao
                End If
                If MaCongTy = "HAIVINA" Then
                    If DateTime.Compare(QuetVao, GioVaoCa.AddMinutes(15)) <= 0 And DateTime.Compare(QuetVao, GioVaoCa) > 0 Then
                        QuetVao = GioVaoCa
                    End If
                    If QuetRa.Minute <= 15 Then
                        QuetRa = New DateTime(QuetRa.Year, QuetRa.Month, QuetRa.Day, QuetRa.Hour, 0, 0)
                    ElseIf QuetRa.Minute <= 45 Then
                        QuetRa = New DateTime(QuetRa.Year, QuetRa.Month, QuetRa.Day, QuetRa.Hour, 30, 0)
                    Else
                        QuetRa = New DateTime(QuetRa.AddHours(1).Year, QuetRa.AddHours(1).Month, QuetRa.AddHours(1).Day, QuetRa.AddHours(1).Hour, 0, 0)
                    End If
                End If
                If MaCongTy <> "HAIVINA" Then
                    If ChuanHoaGioQuet1 > 0 Then
                        If QuetVao.Minute > 0 And QuetVao.Minute <= ChuanHoaGioQuet1 Then
                            QuetVao = New DateTime(QuetVao.Year, QuetVao.Month, QuetVao.Day, QuetVao.Hour, 0, 0)
                        ElseIf QuetVao.Minute > ChuanHoaGioQuet1 And QuetVao.Minute <= ChuanHoaGioQuet2 Then
                            QuetVao = New DateTime(QuetVao.Year, QuetVao.Month, QuetVao.Day, QuetVao.Hour, 30, 0)
                        ElseIf QuetVao.Minute > ChuanHoaGioQuet2 Then
                            QuetVao = New DateTime(QuetVao.AddHours(1).Year, QuetVao.AddHours(1).Month, QuetVao.AddHours(1).Day, QuetVao.AddHours(1).Hour, 0, 0)
                        End If

                        If QuetRa.Minute > 0 And QuetRa.Minute <= ChuanHoaGioQuet1 Then
                            QuetRa = New DateTime(QuetRa.Year, QuetRa.Month, QuetRa.Day, QuetRa.Hour, 0, 0)
                        ElseIf QuetRa.Minute > ChuanHoaGioQuet1 And QuetRa.Minute <= ChuanHoaGioQuet2 Then
                            QuetRa = New DateTime(QuetRa.Year, QuetRa.Month, QuetRa.Day, QuetRa.Hour, 30, 0)
                        ElseIf QuetRa.Minute > ChuanHoaGioQuet2 Then
                            QuetRa = New DateTime(QuetRa.AddHours(1).Year, QuetRa.AddHours(1).Month, QuetRa.AddHours(1).Day, QuetRa.AddHours(1).Hour, 0, 0)
                        End If
                    End If
                End If
                If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "1" Or CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "2" Then
                    If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "1" Then
                        If DateTime.Compare(QuetRa, GioGioiHanTangCa) >= 0 Then
                            QuetRa = GioGioiHanTangCa
                            bVuotQuaThoiGianTangCa = True
                        End If
                    Else
                        If GioiHanTangCa < 100 Then
                            If DateTime.Compare(QuetRa, GioGioiHanTangCa) >= 0 Then
                                QuetRa = GioGioiHanTangCa
                                bVuotQuaThoiGianTangCa = True
                            End If
                        End If
                    End If
                End If
                sql += TinhCongDuaVaoDuLieuQuet(Employee_ID, QuetVao, QuetRa, mangrow, rowXinRaNgoai, NgayTinhCong, GioVaoCa, GioTanCa, bKiemTraCheDo, SoGioToiThieuDuocTinhTangCa) + " "
                If bVuotQuaThoiGianTangCa = True Then
                    Exit For
                End If
                i += 1
            Next
            If CauHinhTinhCong = "1" Then
                sql += TinhCongDuaVaoDuLieuQuet(Employee_ID, GioVaoCa, QuetVao_LanDau, mangrow, rowXinRaNgoai, NgayTinhCong, GioVaoCa, GioTanCa, False, SoGioToiThieuDuocTinhTangCa) + " "
            ElseIf CauHinhTinhCong = "2" Then
                If bKiemTraCheDo = True Then
                    sql += TinhCongDuaVaoDuLieuQuet(Employee_ID, QuetRa, GioTanCa.AddMinutes(-60), mangrow, rowXinRaNgoai, NgayTinhCong, GioVaoCa, GioTanCa, False, SoGioToiThieuDuocTinhTangCa) + " "
                Else
                    sql += TinhCongDuaVaoDuLieuQuet(Employee_ID, QuetRa, GioTanCa, mangrow, rowXinRaNgoai, NgayTinhCong, GioVaoCa, GioTanCa, False, SoGioToiThieuDuocTinhTangCa) + " "
                End If
            End If
        Else
            Return sql
        End If
        QuetVao = dtThoiGianQuet.Rows(0)("AccessTime")
        QuetRa = dtThoiGianQuet.Rows(dtThoiGianQuet.Rows.Count - 1)("AccessTime")
        If DateTime.Compare(QuetVao, GioVaoCa) > 0 Then
            'Dim hs As New Entity.HR_Shift(Ca)
            If Not IsNothing(GioNghiTu) And Not IsNothing(GioNghiDen) Then
                QuetVaoMuon = TinhCongMotCaCoGioNghiGiuaGio(GioVaoCa, QuetVao, GioVaoCa, GioTanCa, GioNghiTu, GioNghiDen)
            Else
                QuetVaoMuon = DateDiff(DateInterval.Minute, GioVaoCa, QuetVao)
            End If
        Else
            QuetVaoMuon = 0
        End If
        If bKiemTraCheDo = True Then
            GioTanCa = GioTanCa.AddMinutes(-60)
        End If
        If DateTime.Compare(QuetRa, GioTanCa) < 0 Then
            If Not IsNothing(GioNghiTu) And Not IsNothing(GioNghiDen) Then
                QuetRaSom = TinhCongMotCaCoGioNghiGiuaGio(QuetRa, GioTanCa, GioVaoCa, GioTanCa, GioNghiTu, GioNghiDen)
            Else
                QuetRaSom = DateDiff(DateInterval.Minute, QuetRa, GioTanCa)
            End If
        Else
            QuetRaSom = 0
        End If

        If bKiemTraCheDo = True Then
            Dim BangGioOVERTIMEGanNhat As DataTable = kncsdl.Select_CauLenhSQL("select [Percent], [No] from HR_SetupHourTimeKeeping where isOverTime = '1' and ShiftName = '" + Ca + "' order by [No] asc")
            Dim BangGioThuongXaNhat As DataTable = kncsdl.Select_CauLenhSQL("select [Percent], [No] from HR_SetupHourTimeKeeping where (isOverTime <> '1' or isOverTime is null) and ShiftName = '" + Ca + "' order by [No] desc")
            Dim GioOVERTIMEGanNhat, GioThuongXaNhat As String
            If BangGioOVERTIMEGanNhat.Rows.Count > 0 Then
                GioOVERTIMEGanNhat = CStr(BangGioOVERTIMEGanNhat.Rows(0)("Percent"))
            Else
                GioOVERTIMEGanNhat = String.Empty
            End If
            If GioOVERTIMEGanNhat <> String.Empty Then
                Dim BangCong As DataTable = kncsdl.Select_CauLenhSQL("select sum(isnull(WokingTime,0)) as WokingTime from SmartBooks_TimeKeeping_Date where Employee_ID = '" + Employee_ID + "' and OT_date = '" + DateToString(NgayTinhCong) + "' and [Percent] in (select [Percent] from dbo.HR_SetupHourTimeKeeping where isOverTime <> '1' or isOverTime is null)")
                Dim GioThuong As Double
                If BangCong.Rows.Count > 0 Then
                    If Not IsDBNull(BangCong.Rows(0)("WokingTime")) Then
                        GioThuong = BangCong.Rows(0)("WokingTime")
                    Else
                        GioThuong = 0
                    End If
                Else
                    GioThuong = 0
                End If
                If BangGioThuongXaNhat.Rows.Count > 0 Then
                    GioThuongXaNhat = CStr(BangGioThuongXaNhat.Rows(0)("Percent"))
                Else
                    BangGioThuongXaNhat = kncsdl.Select_CauLenhSQL("select [Percent], [No] from HR_SetupHourTimeKeeping where (isOverTime = '1') and ShiftName = '" + Ca + "' order by [No] desc")
                    GioThuongXaNhat = CStr(BangGioThuongXaNhat.Rows(0)("Percent"))
                End If
                Dim BangGioCongThuongXaNhat As DataTable = kncsdl.Select_CauLenhSQL("select sum(isnull(WokingTime,0)) as WokingTime from SmartBooks_TimeKeeping_Date where Employee_ID = '" + Employee_ID + "' and OT_date = '" + DateToString(NgayTinhCong) + "' and [Percent] = '" + GioThuongXaNhat + "'")
                Dim GioCongThuongXaNhat As Double = 0
                If BangGioCongThuongXaNhat.Rows.Count > 0 Then
                    If Not IsDBNull(BangGioCongThuongXaNhat.Rows(0)("WokingTime")) Then
                        GioCongThuongXaNhat = CDbl(BangGioCongThuongXaNhat.Rows(0)("WokingTime"))
                    End If
                End If
                If GioThuong > 420 Then
                    sql = sql + "DELETE FROM [SmartBooks_TimeKeeping_Date] WHERE OT_date = '" + DateToString(NgayTinhCong) + "' and Employee_ID = '" + Employee_ID + "' and [Percent] = '" + GioThuongXaNhat + "' "
                    sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + GioOVERTIMEGanNhat + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + (GioCongThuongXaNhat - (GioThuong - 420) + 60).ToString + "', '" + GioThuongXaNhat + "') "
                    sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + GioOVERTIMEGanNhat + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + (GioThuong - 420).ToString + "', '" + GioOVERTIMEGanNhat + "') "
                Else
                    If GioThuong >= DieuKienToiThieuCheDoThaiSanConNhoDuocThemGioLam * 60 Then
                        sql = sql + "DELETE FROM [SmartBooks_TimeKeeping_Date] WHERE OT_date = '" + DateToString(NgayTinhCong) + "' and Employee_ID = '" + Employee_ID + "' and [Percent] = '" + GioThuongXaNhat + "' "
                        sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + GioOVERTIMEGanNhat + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + (GioCongThuongXaNhat + 60).ToString + "', '" + GioThuongXaNhat + "') "
                    End If
                End If
            End If
        End If
        'sql = sql + "DELETE FROM [HR_TimeIn_TimeOut] WHERE Employee_ID = '" + Employee_ID + "' AND OT_date = '" + DateToString(NgayTinhCong) + "' "
        sql = sql + "INSERT INTO [HR_TimeIn_TimeOut]([OT_date], [Employee_ID], [TimeIn], [TimeOut], [LateIn], [EarlyOut]) VALUES('" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + DateTimeToString(QuetVao) + "', '" + DateTimeToString(QuetRa) + "', '" + QuetVaoMuon.ToString + "', '" + QuetRaSom.ToString + "') "
        Return sql
    End Function

    Public Function TinhCongDuaVaoDuLieuQuet(ByVal Employee_ID As String, ByVal QuetVao As DateTime, ByVal QuetRa As DateTime, ByVal KhungGioCuaCa As DataRow(), ByVal XinRaNgoai As DataRow(), ByVal NgayTinhCong As DateTime, ByVal GioVaoCa As DateTime, ByVal GioTanCa As DateTime, ByVal bKiemTraCheDo As Boolean, ByVal SoGioToiThieuDuocTinhTangCa As Integer) As String
        Dim dtThoiGianBatDauTinhCa, dtThoiGianKetThucTinhCa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen, GioGioiHanTangCa As DateTime
        Dim TongGioRaNgoai, WorkingTime As Double
        Dim row_XinRaNgoai As DataRow
        TongGioRaNgoai = 0
        Dim sql, Key As String
        Key = NgayTinhCong.Year.ToString + getMonth_HaiChuSo(NgayTinhCong) + getDay_HaiChuSo(NgayTinhCong) + "-" + Employee_ID
        For Each row As DataRow In KhungGioCuaCa
            TongGioRaNgoai = 0
            If Not IsDBNull(row("FromTime")) Then
                KhungGioTu = row("FromTime")
                If Not IsDBNull(row("ToTime")) Then
                    KhungGioDen = row("ToTime")
                Else
                    If DateTime.Compare(KhungGioTu, QuetRa) <= 0 Then
                        KhungGioDen = QuetRa
                    Else
                        KhungGioDen = KhungGioTu
                    End If
                End If
            Else
                Return sql
            End If
            If KhungGioTu.Hour < GioVaoCa.Hour Then
                ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong.AddDays(1), KhungGioTu, KhungGioDen)
            ElseIf KhungGioDen.Hour < KhungGioTu.Hour Then
                KhungGioTu = New DateTime(NgayTinhCong.Year, NgayTinhCong.Month, NgayTinhCong.Day, KhungGioTu.Hour, KhungGioTu.Minute, KhungGioTu.Second)
                KhungGioDen = New DateTime(NgayTinhCong.AddDays(1).Year, NgayTinhCong.AddDays(1).Month, NgayTinhCong.AddDays(1).Day, KhungGioDen.Hour, KhungGioDen.Minute, KhungGioDen.Second)
            Else
                ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, KhungGioTu, KhungGioDen)
            End If

            If DateTime.Compare(KhungGioTu, KhungGioDen) <> 0 And ((DateTime.Compare(KhungGioTu, QuetVao) >= 0 And DateTime.Compare(KhungGioTu, QuetRa) < 0) Or (DateTime.Compare(QuetVao, KhungGioTu) >= 0 And DateTime.Compare(QuetVao, KhungGioDen) <= 0) Or (DateTime.Compare(QuetRa, KhungGioTu) >= 0 And DateTime.Compare(QuetRa, KhungGioDen) <= 0)) Then
                If Not IsDBNull(row("RestTimeFrom")) Then
                    GioNghiTu = row("RestTimeFrom")
                    If Not IsDBNull(row("RestTimeTo")) Then
                        GioNghiDen = row("RestTimeTo")
                        If GioNghiTu.Hour < GioVaoCa.Hour Then
                            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong.AddDays(1), GioNghiTu, GioNghiDen)
                        Else
                            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, GioNghiTu, GioNghiDen)
                            If GioNghiDen.Hour < GioVaoCa.Hour Then
                                GioNghiDen = GioNghiDen.AddDays(1)
                            End If
                        End If
                        For Each row_XinRaNgoai In XinRaNgoai
                            TongGioRaNgoai += TinhCongMotCaCoGioNghiGiuaGio(row_XinRaNgoai("TimeOut"), row_XinRaNgoai("TimeIn"), KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen)
                        Next
                        WorkingTime = TinhCongMotCaCoGioNghiGiuaGio(QuetVao, QuetRa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen) - TongGioRaNgoai
                        If IsDBNull(row("isOverTime")) <> True Then
                            If row("isOverTime") = True And WorkingTime < SoGioToiThieuDuocTinhTangCa Then
                                WorkingTime = 0
                            End If
                        End If
                        If CDbl(WorkingTime) > 0 Then
                            If bKiemTraCheDo = True Then
                                kncsdl.Exec("INSERT INTO SmartBooks_TimeKeeping_Date ([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime.ToString + "', '" + CStr(row("Percent")) + "')")
                            Else
                                sql = sql + "INSERT INTO SmartBooks_TimeKeeping_Date ([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime.ToString + "', '" + CStr(row("Percent")) + "') "
                            End If
                        End If
                    Else
                        For Each row_XinRaNgoai In XinRaNgoai
                            TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row_XinRaNgoai("TimeOut"), row_XinRaNgoai("TimeIn"), KhungGioTu, KhungGioDen)
                        Next
                        WorkingTime = TinhCongMotCaKhongCoGioNghiGiuaCa(QuetVao, QuetRa, KhungGioTu, KhungGioDen) - TongGioRaNgoai
                        If IsDBNull(row("isOverTime")) <> True Then
                            If row("isOverTime") = True And WorkingTime < SoGioToiThieuDuocTinhTangCa Then
                                WorkingTime = 0
                            End If
                        End If
                        If CDbl(WorkingTime) > 0 Then
                            If bKiemTraCheDo = True Then
                                kncsdl.Exec("INSERT INTO SmartBooks_TimeKeeping_Date ([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime.ToString + "', '" + CStr(row("Percent")) + "')")
                            Else
                                sql = sql + "INSERT INTO SmartBooks_TimeKeeping_Date ([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime.ToString + "', '" + CStr(row("Percent")) + "') "
                            End If
                        End If
                    End If
                Else
                    For Each row_XinRaNgoai In XinRaNgoai
                        TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row_XinRaNgoai("TimeOut"), row_XinRaNgoai("TimeIn"), KhungGioTu, KhungGioDen)
                    Next
                    WorkingTime = TinhCongMotCaKhongCoGioNghiGiuaCa(QuetVao, QuetRa, KhungGioTu, KhungGioDen) - TongGioRaNgoai
                    If IsDBNull(row("isOverTime")) <> True Then
                        If row("isOverTime") = True And WorkingTime < SoGioToiThieuDuocTinhTangCa Then
                            WorkingTime = 0
                        End If
                    End If
                    If CDbl(WorkingTime) > 0 Then
                        If bKiemTraCheDo = True Then
                            kncsdl.Exec("INSERT INTO SmartBooks_TimeKeeping_Date ([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime.ToString + "', '" + CStr(row("Percent")) + "')")
                        Else
                            sql = sql + "INSERT INTO SmartBooks_TimeKeeping_Date ([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime.ToString + "', '" + CStr(row("Percent")) + "') "
                        End If
                    End If
                End If
            End If
        Next
        Return sql
    End Function
    'Public Function TinhCong(ByVal LayGioDauGioCuoi As Boolean, ByVal CauHinhTinhCongDuaVaoDangKyGioiHanTangCa As String, ByVal Employee_ID As String, ByVal NgayTinhCong As DateTime, ByVal GioiHanGioVao As Integer, ByVal GioiHanGioRa As Integer, ByVal DieuKienToiThieuCheDoThaiSanConNhoDuocThemGioLam As Double, ByVal db_GioGioiHanTangCa As Double, ByVal BangXinRaNgoai As DataTable, ByVal Ca As String, ByVal GioVaoCa As DateTime, ByVal GioTanCa As DateTime, ByVal BangKhungGioCuaCa As DataTable, ByVal SoGioToiThieuDuocTinhTangCa As Integer, ByVal GioiTinh As String, ByVal dtThoiGianQuet As DataTable, ByVal int_SoPhutDiLamMuonSoVoiGioVaoCa As Integer, ByVal bKiemTraCheDo As Boolean, ByVal dt_QuetVaoThuc As DateTime) As String
    '    Dim sql As String = String.Empty
    '    Dim GioiHanTangCa As Double = 0
    '    Dim bVuotQuaThoiGianTangCa As Boolean = False
    '    Dim TongGioRaNgoai As Double = 0
    '    Dim GioVaoCa_DiLamDuTamGioTinhTangCa As DateTime
    '    If int_SoPhutDiLamMuonSoVoiGioVaoCa > 0 Then 'muộn
    '        GioVaoCa_DiLamDuTamGioTinhTangCa = GioVaoCa.AddMinutes(int_SoPhutDiLamMuonSoVoiGioVaoCa)
    '    ElseIf int_SoPhutDiLamMuonSoVoiGioVaoCa < 0 Then 'sớm
    '        GioVaoCa_DiLamDuTamGioTinhTangCa = GioVaoCa.AddMinutes(int_SoPhutDiLamMuonSoVoiGioVaoCa)
    '    End If
    '    Dim Key As String = NgayTinhCong.Year.ToString + getMonth_HaiChuSo(NgayTinhCong) + getDay_HaiChuSo(NgayTinhCong) + "-" + Employee_ID
    '    Dim mangrow, rowXinRaNgoai As DataRow()
    '    If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "1" Or CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "2" Then
    '        'mangrow = BangGioiHanTangCa.Select("Employee_id = '" + Employee_ID + "' and workingdate = '" + DateToString(NgayTinhCong) + "'")
    '        If db_GioGioiHanTangCa = -400 Then
    '            If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "2" Then
    '                GioiHanTangCa = 100
    '            Else
    '                GioiHanTangCa = 0
    '            End If
    '        Else
    '            GioiHanTangCa = db_GioGioiHanTangCa
    '        End If
    '    End If
    '    Dim dtThoiGianBatDauTinhCa, dtThoiGianKetThucTinhCa, QuetVao, QuetRa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen, GioGioiHanTangCa As DateTime
    '    Dim WorkingTime As String
    '    Dim QuetVaoMuon, QuetRaSom As Double
    '    rowXinRaNgoai = BangXinRaNgoai.Select("Employee_ID = '" + Employee_ID + "' and TimeDate = '" + DateToString(NgayTinhCong) + "'")
    '    GioGioiHanTangCa = GioTanCa.AddMinutes(GioiHanTangCa * 60)
    '    dtThoiGianBatDauTinhCa = GioVaoCa.AddHours(0 - GioiHanGioVao)
    '    dtThoiGianKetThucTinhCa = GioTanCa.AddHours(GioiHanGioRa)
    '    ChuanHoaDuLieuChamCong(dtThoiGianQuet, LayGioDauGioCuoi)
    '    mangrow = BangKhungGioCuaCa.Select("ShiftName = '" + Ca + "'", "Percent asc")
    '    If mangrow.Length > 0 Then
    '        Dim row, row1 As DataRow
    '        For i As Integer = 0 To dtThoiGianQuet.Rows.Count - 2
    '            QuetVao = dtThoiGianQuet.Rows(i)("AccessTime")
    '            QuetRa = dtThoiGianQuet.Rows(i + 1)("AccessTime")
    '            If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "1" Or CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "2" Then
    '                If CauHinhTinhCongDuaVaoDangKyGioiHanTangCa = "1" Then
    '                    If DateTime.Compare(QuetRa, GioGioiHanTangCa) >= 0 Then
    '                        QuetRa = GioGioiHanTangCa
    '                        bVuotQuaThoiGianTangCa = True
    '                    End If
    '                Else
    '                    If GioiHanTangCa < 100 Then
    '                        If DateTime.Compare(QuetRa, GioGioiHanTangCa) >= 0 Then
    '                            QuetRa = GioGioiHanTangCa
    '                            bVuotQuaThoiGianTangCa = True
    '                        End If
    '                    End If
    '                End If
    '            End If
    '            For Each row In mangrow
    '                TongGioRaNgoai = 0
    '                If Not IsDBNull(row("FromTime")) Then
    '                    KhungGioTu = CType(row("FromTime"), DateTime)
    '                    If Not IsDBNull(row("ToTime")) Then
    '                        KhungGioDen = CType(row("ToTime"), DateTime)
    '                    Else
    '                        KhungGioDen = QuetRa
    '                    End If
    '                Else
    '                    Return sql
    '                End If
    '                If GioVaoCa_DiLamDuTamGioTinhTangCa.Day > NgayTinhCong.Day Then 'KhungGioTu.Hour <= GioVaoCa_DiLamDuTamGioTinhTangCa.Hour And KhungGioTu.Hour <= GioVaoCa_DiLamDuTamGioTinhTangCa.Hour - 5 Then
    '                    ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong.AddDays(1), KhungGioTu, KhungGioDen)
    '                Else
    '                    ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, KhungGioTu, KhungGioDen)
    '                End If
    '                If int_SoPhutDiLamMuonSoVoiGioVaoCa > 0 Then 'muộn
    '                    If row("No") = 3 Or row("No") = 4 Then
    '                        KhungGioTu = KhungGioTu.AddMinutes(int_SoPhutDiLamMuonSoVoiGioVaoCa)
    '                        If DateTime.Compare(KhungGioTu, New DateTime(NgayTinhCong.Year, NgayTinhCong.Month, NgayTinhCong.Day, 22, 0, 0)) > 0 Then
    '                            KhungGioTu = New DateTime(NgayTinhCong.Year, NgayTinhCong.Month, NgayTinhCong.Day, 22, 0, 0)
    '                        End If
    '                        If KhungGioDen.Hour <> 22 Then
    '                            KhungGioDen = KhungGioDen.AddMinutes(int_SoPhutDiLamMuonSoVoiGioVaoCa)
    '                            If DateTime.Compare(KhungGioDen, New DateTime(NgayTinhCong.Year, NgayTinhCong.Month, NgayTinhCong.Day, 22, 0, 0)) > 0 Then
    '                                KhungGioDen = New DateTime(NgayTinhCong.Year, NgayTinhCong.Month, NgayTinhCong.Day, 22, 0, 0)
    '                            End If
    '                        End If
    '                        If row("No") = 3 And dt_QuetVaoThuc.Hour >= 12 And dt_QuetVaoThuc.Hour <= 13 Then
    '                            KhungGioDen = KhungGioDen.AddHours(-1)
    '                        ElseIf row("No") = 4 And dt_QuetVaoThuc.Hour >= 12 And dt_QuetVaoThuc.Hour <= 13 Then
    '                            KhungGioTu = KhungGioTu.AddHours(-1)
    '                        End If
    '                    End If
    '                ElseIf int_SoPhutDiLamMuonSoVoiGioVaoCa < 0 Then 'sớm
    '                    If row("No") = 2 Or row("No") = 3 Or row("No") = 4 Then
    '                        If int_SoPhutDiLamMuonSoVoiGioVaoCa < -90 Then
    '                            If row("No") = 2 Then
    '                                KhungGioTu = KhungGioDen
    '                            Else
    '                                KhungGioTu = KhungGioTu.AddMinutes(-90)
    '                                If KhungGioDen.Hour <> 22 Then
    '                                    KhungGioDen = KhungGioDen.AddMinutes(-90)
    '                                End If
    '                            End If
    '                        Else
    '                            KhungGioTu = KhungGioTu.AddMinutes(int_SoPhutDiLamMuonSoVoiGioVaoCa)
    '                            If KhungGioDen.Hour <> 22 Then
    '                                KhungGioDen = KhungGioDen.AddMinutes(int_SoPhutDiLamMuonSoVoiGioVaoCa)
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '                If Not IsDBNull(row("RestTimeFrom")) Then
    '                    GioNghiTu = row("RestTimeFrom")
    '                    If Not IsDBNull(row("RestTimeTo")) Then
    '                        GioNghiDen = row("RestTimeTo")
    '                        If GioNghiTu.Hour < GioVaoCa.Hour Then
    '                            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong.AddDays(1), GioNghiTu, GioNghiDen)
    '                        Else
    '                            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, GioNghiTu, GioNghiDen)
    '                            If GioNghiDen.Hour < GioVaoCa.Hour Then
    '                                GioNghiDen = GioNghiDen.AddDays(1)
    '                            End If
    '                        End If
    '                        For Each row1 In rowXinRaNgoai
    '                            TongGioRaNgoai += TinhCongMotCaCoGioNghiGiuaGio(row1("TimeOut"), row1("TimeIn"), KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen)
    '                        Next
    '                        WorkingTime = TinhCongMotCaCoGioNghiGiuaGio(QuetVao, QuetRa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen) - TongGioRaNgoai
    '                        If IsDBNull(row("isOverTime")) <> True Then
    '                            If row("isOverTime") = True And WorkingTime < SoGioToiThieuDuocTinhTangCa Then
    '                                WorkingTime = 0
    '                            End If
    '                        End If
    '                        If CDbl(WorkingTime) > 0 Then
    '                            If bKiemTraCheDo = True Then
    '                                kncsdl.Exec("INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "')")
    '                            Else
    '                                sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "') "
    '                            End If
    '                        End If
    '                    Else
    '                        For Each row1 In rowXinRaNgoai
    '                            TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row1("TimeOut"), row1("TimeIn"), KhungGioTu, KhungGioDen)
    '                        Next
    '                        WorkingTime = TinhCongMotCaKhongCoGioNghiGiuaCa(QuetVao, QuetRa, KhungGioTu, KhungGioDen) - TongGioRaNgoai
    '                        If IsDBNull(row("isOverTime")) <> True Then
    '                            If row("isOverTime") = True And WorkingTime < SoGioToiThieuDuocTinhTangCa Then
    '                                WorkingTime = 0
    '                            End If
    '                        End If
    '                        If CDbl(WorkingTime) > 0 Then
    '                            If bKiemTraCheDo = True Then
    '                                kncsdl.Exec("INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "')")
    '                            Else
    '                                sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "') "
    '                            End If
    '                        End If
    '                    End If
    '                Else
    '                    For Each row1 In rowXinRaNgoai
    '                        TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row1("TimeOut"), row1("TimeIn"), KhungGioTu, KhungGioDen)
    '                    Next
    '                    WorkingTime = TinhCongMotCaKhongCoGioNghiGiuaCa(QuetVao, QuetRa, KhungGioTu, KhungGioDen) - TongGioRaNgoai
    '                    If IsDBNull(row("isOverTime")) <> True Then
    '                        If row("isOverTime") = True And WorkingTime < SoGioToiThieuDuocTinhTangCa Then
    '                            WorkingTime = 0
    '                        End If
    '                    End If
    '                    If CDbl(WorkingTime) > 0 Then
    '                        If bKiemTraCheDo = True Then
    '                            kncsdl.Exec("INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "')")
    '                        Else
    '                            sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "') "
    '                        End If
    '                    End If
    '                End If
    '            Next
    '            If bVuotQuaThoiGianTangCa = True Then
    '                Exit For
    '            End If
    '            i += 1
    '        Next
    '    Else
    '        Return sql
    '    End If
    '    If dt_QuetVaoThuc.Year = 1 Then
    '        QuetVao = dtThoiGianQuet.Rows(0)("AccessTime")
    '    Else
    '        QuetVao = dt_QuetVaoThuc
    '    End If
    '    QuetRa = dtThoiGianQuet.Rows(dtThoiGianQuet.Rows.Count - 1)("AccessTime")
    '    If DateTime.Compare(QuetVao, GioVaoCa) > 0 Then
    '        'Dim hs As New Entity.HR_Shift(Ca)
    '        If Not IsNothing(GioNghiTu) And Not IsNothing(GioNghiDen) Then
    '            QuetVaoMuon = TinhCongMotCaCoGioNghiGiuaGio(GioVaoCa, QuetVao, GioVaoCa, GioTanCa, GioNghiTu, GioNghiDen)
    '        Else
    '            QuetVaoMuon = DateDiff(DateInterval.Minute, GioVaoCa, QuetVao)
    '        End If
    '    Else
    '        QuetVaoMuon = 0
    '    End If
    '    If bKiemTraCheDo = True Then
    '        GioTanCa = GioTanCa.AddMinutes(-60)
    '    End If
    '    If DateTime.Compare(QuetRa, GioTanCa) < 0 Then
    '        If Not IsNothing(GioNghiTu) And Not IsNothing(GioNghiDen) Then
    '            QuetRaSom = TinhCongMotCaCoGioNghiGiuaGio(QuetRa, GioTanCa, GioVaoCa, GioTanCa, GioNghiTu, GioNghiDen)
    '        Else
    '            QuetRaSom = DateDiff(DateInterval.Minute, QuetRa, GioTanCa)
    '        End If
    '    Else
    '        QuetRaSom = 0
    '    End If

    '    If bKiemTraCheDo = True Then
    '        Dim BangGioOVERTIMEGanNhat As DataTable = kncsdl.Select_CauLenhSQL("select [Percent], [No] from HR_SetupHourTimeKeeping where isOverTime = '1' and ShiftName = '" + Ca + "' order by [No] asc")
    '        Dim BangGioThuongXaNhat As DataTable = kncsdl.Select_CauLenhSQL("select [Percent], [No] from HR_SetupHourTimeKeeping where (isOverTime <> '1' or isOverTime is null) and ShiftName = '" + Ca + "' order by [No] desc")
    '        Dim GioOVERTIMEGanNhat, GioThuongXaNhat As String
    '        If BangGioOVERTIMEGanNhat.Rows.Count > 0 Then
    '            GioOVERTIMEGanNhat = CStr(BangGioOVERTIMEGanNhat.Rows(0)("Percent"))
    '        Else
    '            GioOVERTIMEGanNhat = String.Empty
    '        End If
    '        If GioOVERTIMEGanNhat <> String.Empty Then
    '            Dim BangCong As DataTable = kncsdl.Select_CauLenhSQL("select sum(isnull(WokingTime,0)) as WokingTime from SmartBooks_TimeKeeping_Date where Employee_ID = '" + Employee_ID + "' and OT_date = '" + DateToString(NgayTinhCong) + "' and [Percent] in (select [Percent] from dbo.HR_SetupHourTimeKeeping where isOverTime <> '1' or isOverTime is null)")
    '            Dim GioThuong As Double
    '            If BangCong.Rows.Count > 0 Then
    '                If Not IsDBNull(BangCong.Rows(0)("WokingTime")) Then
    '                    GioThuong = BangCong.Rows(0)("WokingTime")
    '                Else
    '                    GioThuong = 0
    '                End If
    '            Else
    '                GioThuong = 0
    '            End If
    '            If BangGioThuongXaNhat.Rows.Count > 0 Then
    '                GioThuongXaNhat = CStr(BangGioThuongXaNhat.Rows(0)("Percent"))
    '            Else
    '                BangGioThuongXaNhat = kncsdl.Select_CauLenhSQL("select [Percent], [No] from HR_SetupHourTimeKeeping where (isOverTime = '1') and ShiftName = '" + Ca + "' order by [No] desc")
    '                GioThuongXaNhat = CStr(BangGioThuongXaNhat.Rows(0)("Percent"))
    '            End If
    '            Dim BangGioCongThuongXaNhat As DataTable = kncsdl.Select_CauLenhSQL("select sum(isnull(WokingTime,0)) as WokingTime from SmartBooks_TimeKeeping_Date where Employee_ID = '" + Employee_ID + "' and OT_date = '" + DateToString(NgayTinhCong) + "' and [Percent] = '" + GioThuongXaNhat + "'")
    '            Dim GioCongThuongXaNhat As Double = 0
    '            If BangGioCongThuongXaNhat.Rows.Count > 0 Then
    '                If Not IsDBNull(BangGioCongThuongXaNhat.Rows(0)("WokingTime")) Then
    '                    GioCongThuongXaNhat = CDbl(BangGioCongThuongXaNhat.Rows(0)("WokingTime"))
    '                End If
    '            End If
    '            If GioThuong > 420 Then
    '                sql = sql + "DELETE FROM [SmartBooks_TimeKeeping_Date] WHERE OT_date = '" + DateToString(NgayTinhCong) + "' and Employee_ID = '" + Employee_ID + "' and [Percent] = '" + GioThuongXaNhat + "' "
    '                sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-100', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + (GioCongThuongXaNhat - (GioThuong - 420) + 60).ToString + "', '" + GioThuongXaNhat + "') "
    '                sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-150', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + (GioThuong - 420).ToString + "', '150') "
    '            Else
    '                If GioThuong >= DieuKienToiThieuCheDoThaiSanConNhoDuocThemGioLam * 60 Then
    '                    sql = sql + "DELETE FROM [SmartBooks_TimeKeeping_Date] WHERE OT_date = '" + DateToString(NgayTinhCong) + "' and Employee_ID = '" + Employee_ID + "' and [Percent] = '" + GioThuongXaNhat + "' "
    '                    sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-100', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + (GioCongThuongXaNhat + 60).ToString + "', '" + GioThuongXaNhat + "') "
    '                End If
    '            End If
    '        End If
    '    End If
    '    'sql = sql + "DELETE FROM [HR_TimeIn_TimeOut] WHERE Employee_ID = '" + Employee_ID + "' AND OT_date = '" + DateToString(NgayTinhCong) + "' "
    '    sql = sql + "INSERT INTO [HR_TimeIn_TimeOut]([OT_date], [Employee_ID], [TimeIn], [TimeOut], [LateIn], [EarlyOut]) VALUES('" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + DateTimeToString(QuetVao) + "', '" + DateTimeToString(QuetRa) + "', '" + QuetVaoMuon.ToString + "', '" + QuetRaSom.ToString + "') "
    '    Return sql
    'End Function
    Public Function TinhCongAD(ByVal LayGioDauGioCuoi As Boolean, ByVal GioiHanTangCa As Double, ByVal Employee_ID As String, ByVal NgayTinhCong As DateTime, ByVal GioiHanGioVao As Integer, ByVal GioiHanGioRa As Integer, ByVal GioiHanQuetVaoTuyChon As Integer, ByVal GioiHanQuetRaTuyChon As Integer, ByVal TinhCongNgayCN As Boolean, ByVal TinhCongNgayNghiLe As Boolean, ByVal BangXinRaNgoai As DataTable, ByVal BangTenCaChinh As DataTable, ByVal BangThoiGianCuaCa As DataTable, ByVal BangKhungGioCuaCa As DataTable, ByVal BangGioiHanTangCa_AD As DataTable) As String
        Dim sql As String = String.Empty
        If KiemTraCoTrongCheDoConNho(Employee_ID, NgayTinhCong) Or KiemTraCoTrongCheDoThaiSan(Employee_ID, NgayTinhCong) Then
            GioiHanTangCa = -1
        End If
        If NgayTinhCong.DayOfWeek = DayOfWeek.Sunday Then
            If TinhCongNgayCN = False Then
                Return sql
            End If
        End If
        If isHoliday(NgayTinhCong) Then
            If TinhCongNgayNghiLe = False Then
                Return sql
            End If
        End If
        Dim mangrow, rowXinRaNgoai As DataRow()
        mangrow = BangGioiHanTangCa_AD.Select("Employee_id = '" + Employee_ID + "' and workingdate = '" + DateToString(NgayTinhCong) + "'")
        If mangrow.Length > 0 Then
            Try
                GioiHanTangCa = mangrow(0)("maxovertime")
            Catch ex As Exception
            End Try
        End If
        Dim Ca As String
        Dim bVuotQuaThoiGianTangCa As Boolean = False
        Dim TongGioRaNgoai As Double = 0
        Dim dtThoiGianBatDauTinhCa, dtThoiGianKetThucTinhCa, QuetVao, QuetRa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen, GioVaoCa, GioTanCa, GioGioiHanTangCa As DateTime
        Dim WorkingTime As String
        mangrow = BangTenCaChinh.Select("Employee_ID = '" + Employee_ID + "' and TimeDate = '" + DateToString(NgayTinhCong) + "'")
        Dim dtThoiGianQuet As DataTable
        Dim QuetVaoMuon, QuetRaSom As Double
        Dim GioQuetVaoAD, GioQuetRaAD As DateTime
        Dim Key As String = NgayTinhCong.Year.ToString + getMonth_HaiChuSo(NgayTinhCong) + getDay_HaiChuSo(NgayTinhCong) + "-" + Employee_ID
        If mangrow.Length > 0 Then
            Ca = CStr(mangrow(0)("ShiftName")).Trim
            If Ca = String.Empty Then
                Return sql
            End If
            mangrow = BangThoiGianCuaCa.Select("ShiftName = '" + Ca + "'")
            If mangrow.Length > 0 Then
                dtThoiGianBatDauTinhCa = mangrow(0)("FromTime")
                dtThoiGianKetThucTinhCa = mangrow(0)("ToTime")
            End If
            rowXinRaNgoai = BangXinRaNgoai.Select("Employee_ID = '" + Employee_ID + "' and TimeDate = '" + DateToString(NgayTinhCong) + "'")
            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, dtThoiGianBatDauTinhCa, dtThoiGianKetThucTinhCa)
            GioVaoCa = dtThoiGianBatDauTinhCa
            GioTanCa = dtThoiGianKetThucTinhCa
            GioGioiHanTangCa = GioTanCa.AddMinutes(GioiHanTangCa * 60)
            dtThoiGianBatDauTinhCa = dtThoiGianBatDauTinhCa.AddHours(0 - GioiHanGioVao)
            dtThoiGianKetThucTinhCa = dtThoiGianKetThucTinhCa.AddHours(GioiHanGioRa)
            dtThoiGianQuet = dbda.LayThoiGianQuetTrongNgay(Employee_ID, dtThoiGianBatDauTinhCa, dtThoiGianKetThucTinhCa)
            If dtThoiGianQuet.Rows.Count <= 1 Then
                If dtThoiGianQuet.Rows.Count = 1 Then
                    QuetVao = dtThoiGianQuet.Rows(0)("AccessTime")
                    sql = sql + "DELETE FROM [HR_TimeIn_TimeOut_AD] WHERE Employee_ID = '" + Employee_ID + "' AND OT_date = '" + DateToString(NgayTinhCong) + "' "
                    sql = sql + "INSERT INTO [HR_TimeIn_TimeOut_AD]([OT_date], [Employee_ID], [TimeIn]) VALUES('" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + DateTimeToString(QuetVao) + "') "
                End If
                Return sql
            End If
            ChuanHoaDuLieuChamCong(dtThoiGianQuet, LayGioDauGioCuoi)
            mangrow = BangKhungGioCuaCa.Select("ShiftName = '" + Ca + "'", "Percent asc")
            If mangrow.Length > 0 Then
                Dim row, row1 As DataRow
                For i As Integer = 0 To dtThoiGianQuet.Rows.Count - 2
                    QuetVao = dtThoiGianQuet.Rows(i)("AccessTime")
                    QuetRa = dtThoiGianQuet.Rows(i + 1)("AccessTime")
                    If DateTime.Compare(QuetRa, GioGioiHanTangCa) >= 0 Then
                        QuetRa = GioGioiHanTangCa
                        bVuotQuaThoiGianTangCa = True
                    End If
                    For Each row In mangrow
                        TongGioRaNgoai = 0
                        If Not IsDBNull(row("FromTime")) Then
                            KhungGioTu = row("FromTime")
                            If Not IsDBNull(row("ToTime")) Then
                                KhungGioDen = row("ToTime")
                            Else
                                KhungGioDen = QuetRa
                            End If
                        Else
                            Return sql
                        End If
                        If KhungGioTu.Hour <= GioVaoCa.Hour And KhungGioTu.Hour <= GioVaoCa.Hour - 5 Then
                            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong.AddDays(1), KhungGioTu, KhungGioDen)
                        Else
                            ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, KhungGioTu, KhungGioDen)
                        End If
                        If Not IsDBNull(row("RestTimeFrom")) Then
                            GioNghiTu = row("RestTimeFrom")
                            If Not IsDBNull(row("RestTimeTo")) Then
                                GioNghiDen = row("RestTimeTo")
                                If GioNghiTu.Hour <= GioVaoCa.Hour And GioNghiTu.Hour <= GioVaoCa.Hour - 5 Then
                                    ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong.AddDays(1), GioNghiTu, GioNghiDen)
                                Else
                                    ChuanHoaKhungGioTrongCaLamViec(NgayTinhCong, GioNghiTu, GioNghiDen)
                                End If
                                For Each row1 In rowXinRaNgoai
                                    TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row1("TimeOut"), row1("TimeIn"), KhungGioTu, KhungGioDen)
                                Next
                                WorkingTime = TinhCongMotCaCoGioNghiGiuaGio(QuetVao, QuetRa, KhungGioTu, KhungGioDen, GioNghiTu, GioNghiDen) - TongGioRaNgoai
                                If CDbl(WorkingTime) > 0 Then
                                    sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date_AD]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "') "
                                End If
                            Else
                                For Each row1 In rowXinRaNgoai
                                    TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row1("TimeOut"), row1("TimeIn"), KhungGioTu, KhungGioDen)
                                Next
                                WorkingTime = TinhCongMotCaKhongCoGioNghiGiuaCa(QuetVao, QuetRa, KhungGioTu, KhungGioDen) - TongGioRaNgoai
                                If CDbl(WorkingTime) > 0 Then
                                    sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date_AD]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "') "
                                End If
                            End If
                        Else
                            For Each row1 In rowXinRaNgoai
                                TongGioRaNgoai += TinhCongMotCaKhongCoGioNghiGiuaCa(row1("TimeOut"), row1("TimeIn"), KhungGioTu, KhungGioDen)
                            Next
                            WorkingTime = TinhCongMotCaKhongCoGioNghiGiuaCa(QuetVao, QuetRa, KhungGioTu, KhungGioDen) - TongGioRaNgoai
                            If CDbl(WorkingTime) > 0 Then
                                sql = sql + "INSERT INTO [SmartBooks_TimeKeeping_Date_AD]([Key], [OT_date], [Employee_ID], [WokingTime], [Percent]) VALUES('" + Key + "-" + CStr(row("Percent")) + "', '" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + WorkingTime + "', '" + CStr(row("Percent")) + "') "
                            End If
                        End If
                    Next
                    If bVuotQuaThoiGianTangCa = True Then
                        Exit For
                    End If
                    i += 1
                Next
            Else
                Return sql
            End If
        Else
            Return sql
        End If
        Static Generator As System.Random = New System.Random
        QuetVao = dtThoiGianQuet.Rows(0)("AccessTime")
        GioQuetVaoAD = GioVaoCa.AddMinutes(0 - GioiHanQuetVaoTuyChon)
        If bVuotQuaThoiGianTangCa = False Then
            QuetRa = dtThoiGianQuet.Rows(dtThoiGianQuet.Rows.Count - 1)("AccessTime")
        End If
        GioQuetRaAD = GioTanCa.AddMinutes(GioiHanQuetRaTuyChon)
        If DateTime.Compare(QuetVao, GioVaoCa) > 0 Then
            QuetVaoMuon = DateDiff(DateInterval.Minute, GioVaoCa, QuetVao)
        Else
            If DateTime.Compare(QuetVao, GioQuetVaoAD) < 0 Then
                QuetVao = GioVaoCa.AddMinutes(0 - Generator.Next(0, GioiHanQuetVaoTuyChon))
            End If
            QuetVaoMuon = 0
        End If
        If DateTime.Compare(QuetRa, GioTanCa) < 0 Then
            QuetRaSom = DateDiff(DateInterval.Minute, QuetRa, GioTanCa)
            If KiemTraCoTrongCheDoConNho(Employee_ID, NgayTinhCong) Or KiemTraCoTrongCheDoThaiSan(Employee_ID, NgayTinhCong) Then
                If bVuotQuaThoiGianTangCa = True Then
                    QuetRa = QuetRa.AddMinutes(Generator.Next(0, GioiHanQuetRaTuyChon))
                End If
            End If
        Else
            If DateTime.Compare(QuetRa, GioQuetRaAD) > 0 Then
                If bVuotQuaThoiGianTangCa = True Then
                    QuetRa = QuetRa.AddMinutes(Generator.Next(0, GioiHanQuetRaTuyChon))
                End If
            End If
            QuetRaSom = 0
        End If
        sql = sql + "DELETE FROM [HR_TimeIn_TimeOut_AD] WHERE Employee_ID = '" + Employee_ID + "' AND OT_date = '" + DateToString(NgayTinhCong) + "' "
        sql = sql + "INSERT INTO [HR_TimeIn_TimeOut_AD]([OT_date], [Employee_ID], [TimeIn], [TimeOut], [LateIn], [EarlyOut]) VALUES('" + DateToString(NgayTinhCong) + "', '" + Employee_ID + "', '" + DateTimeToString(QuetVao) + "', '" + DateTimeToString(QuetRa) + "', '" + QuetVaoMuon.ToString + "', '" + QuetRaSom.ToString + "') "
        Return sql
    End Function

    Public Function DateToString_ddMMyyyy(ByVal DT As DateTime) As String
        Try
            Dim str As String = DT.ToString("dd") + "/" + DT.ToString("MM") + "/" + DT.ToString("yyyy")
            Return str
        Catch ex As Exception
            Return "01/01/1900"
        End Try
    End Function

    Public Function TinhCongMotCaCoGioNghiGiuaGio(ByVal QuetVao As DateTime, ByVal QuetRa As DateTime, ByVal GioVaoCa As DateTime, ByVal GioTanCa As DateTime, ByVal GioBatDauNghiGiuaCa As DateTime, ByVal GioKetThucNghiGiuaCa As DateTime) As Double
        If DateTime.Compare(GioVaoCa, GioTanCa) >= 0 Then
            Return 0
        End If
        If DateTime.Compare(GioVaoCa, QuetVao) >= 0 Then
            If DateTime.Compare(GioVaoCa, QuetRa) >= 0 Then
                Return 0
            ElseIf DateTime.Compare(QuetRa, GioVaoCa) >= 0 And DateTime.Compare(QuetRa, GioTanCa) <= 0 Then
                Return CDbl(DateDiff(DateInterval.Minute, GioVaoCa, QuetRa) - TruKhoangThoiGianNghiCuaCa(QuetVao, QuetRa, GioBatDauNghiGiuaCa, GioKetThucNghiGiuaCa))
            Else
                Return CDbl(DateDiff(DateInterval.Minute, GioVaoCa, GioTanCa) - TruKhoangThoiGianNghiCuaCa(QuetVao, QuetRa, GioBatDauNghiGiuaCa, GioKetThucNghiGiuaCa))
            End If
        ElseIf DateTime.Compare(GioVaoCa, QuetVao) <= 0 And DateTime.Compare(QuetVao, GioTanCa) <= 0 Then
            If DateTime.Compare(QuetRa, GioTanCa) <= 0 Then
                Return CDbl(DateDiff(DateInterval.Minute, QuetVao, QuetRa) - TruKhoangThoiGianNghiCuaCa(QuetVao, QuetRa, GioBatDauNghiGiuaCa, GioKetThucNghiGiuaCa))
            Else
                Return CDbl(DateDiff(DateInterval.Minute, QuetVao, GioTanCa) - TruKhoangThoiGianNghiCuaCa(QuetVao, QuetRa, GioBatDauNghiGiuaCa, GioKetThucNghiGiuaCa))
            End If
        Else : Return 0
        End If
    End Function

    Public Function TinhCongMotCaKhongCoGioNghiGiuaCa(ByVal QuetVao As DateTime, ByVal QuetRa As DateTime, ByVal GioVaoCa As DateTime, ByVal GioTanCa As DateTime) As Double
        If DateTime.Compare(GioVaoCa, GioTanCa) >= 0 Then
            Return 0
        End If
        If DateTime.Compare(GioVaoCa, QuetVao) >= 0 Then
            DateDiff(DateInterval.Minute, GioVaoCa, QuetRa)
            If DateTime.Compare(GioVaoCa, QuetRa) >= 0 Then
                Return 0
            ElseIf DateTime.Compare(QuetRa, GioVaoCa) >= 0 And DateTime.Compare(QuetRa, GioTanCa) <= 0 Then
                Return CDbl(DateDiff(DateInterval.Minute, GioVaoCa, QuetRa))
            Else
                Return CDbl(DateDiff(DateInterval.Minute, GioVaoCa, GioTanCa))
            End If
        ElseIf DateTime.Compare(GioVaoCa, QuetVao) <= 0 And DateTime.Compare(QuetVao, GioTanCa) <= 0 Then
            If DateTime.Compare(QuetRa, GioTanCa) <= 0 Then
                Return CDbl(DateDiff(DateInterval.Minute, QuetVao, QuetRa))
            Else
                Return CDbl(DateDiff(DateInterval.Minute, QuetVao, GioTanCa))
            End If
        Else : Return 0
        End If
    End Function

    Public Function TruKhoangThoiGianNghiCuaCa(ByVal QuetVao As DateTime, ByVal QuetRa As DateTime, ByVal BatDauNghi As DateTime, ByVal KetThucNghi As DateTime) As Double
        If DateTime.Compare(BatDauNghi, QuetVao) <= 0 And DateTime.Compare(QuetRa, KetThucNghi) <= 0 Then
            Return CDbl(DateDiff(DateInterval.Minute, QuetVao, QuetRa))
        ElseIf DateTime.Compare(QuetVao, BatDauNghi) <= 0 And DateTime.Compare(QuetRa, KetThucNghi) >= 0 Then
            Return CDbl(DateDiff(DateInterval.Minute, BatDauNghi, KetThucNghi))
        ElseIf DateTime.Compare(QuetVao, BatDauNghi) <= 0 And DateTime.Compare(QuetRa, BatDauNghi) >= 0 And DateTime.Compare(QuetRa, KetThucNghi) <= 0 Then
            Return CDbl(DateDiff(DateInterval.Minute, BatDauNghi, QuetRa))
        ElseIf DateTime.Compare(QuetVao, BatDauNghi) >= 0 And DateTime.Compare(QuetVao, KetThucNghi) <= 0 And DateTime.Compare(QuetRa, KetThucNghi) >= 0 Then
            Return CDbl(DateDiff(DateInterval.Minute, QuetVao, KetThucNghi))
        Else : Return 0
        End If
    End Function
    ' Chuan hoa du lieu cham cong. Chuan hoa nay dung cho truong hop chi lay 2 lan quet dau va cuoi trong mot lần lấy thời gian quẹt
    ' Dau vao khong duoc rong, dau vao lay o bang chua thong tin quet cua nhan vien
    ' V1,R1;V2,R2;...;Vn,Rn => (R1-V1) + (R2-V2) + .... + (Rn - Vn)
    ' Dau vao khong duoc rong, dau vao lay o bang chua thong tin quet cua nhan vien
    Public Sub ChuanHoaDuLieuChamCong(ByVal dt As DataTable, ByVal LayGioDauVaGioCuoi As Boolean)
        If LayGioDauVaGioCuoi = False Then
            Dim dt_count As Integer = dt.Rows.Count()
            If dt_count > 2 Then ' And dt_count Mod 2 <> 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i < dt.Rows.Count - 1 Then
                        If DateDiff(DateInterval.Minute, dt.Rows(i)("AccessTime"), dt.Rows(i + 1)("AccessTime")) < 15 Then
                            dt.Rows.RemoveAt(i + 1)
                            i -= 1
                        Else
                            i += 1
                        End If
                    Else
                        Exit For
                    End If
                Next
            End If
            If dt.Rows.Count = 3 Then
                dt.Rows.RemoveAt(2)
            End If
        Else
            If dt.Rows.Count > 2 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows.Count = 2 Then
                        Exit Sub
                    Else
                        dt.Rows.RemoveAt(i + 1)
                        i -= 1
                    End If
                Next
            End If
        End If
    End Sub
    Public Function LamTronGioLamViec(ByVal GiaTriCanLamTron As Double, ByVal GiaTriLamTronXuong As Double, ByVal GiaTriLamTronLen As Double) As String
        Dim PhanThapPhan As String = GiaTriCanLamTron.ToString
        Dim SoPhutLe As Double
        Dim words As String() = Split(PhanThapPhan, ".")
        Dim PhanNguyen As Integer = CInt(words(0))
        If words.Length = 2 Then
            SoPhutLe = CDbl("0." + words(1)) * 60
            If SoPhutLe <= GiaTriLamTronXuong Then
                Return PhanNguyen
            ElseIf SoPhutLe > GiaTriLamTronXuong And SoPhutLe < GiaTriLamTronLen Then
                Return CDbl(PhanNguyen.ToString() + ".5")
            Else : Return CDbl(PhanNguyen + 1)
            End If
        Else : Return GiaTriCanLamTron
        End If
    End Function
    Public Function StringToDate(ByVal strddMMyyyy As String) As Date
        Try
            If strddMMyyyy.Trim() = String.Empty Then Return New Date(1900, 1, 1)
            Dim dd As Integer
            Dim MM As Integer
            Dim yyyy As Integer
            dd = Microsoft.VisualBasic.Left(strddMMyyyy, 2)
            MM = strddMMyyyy.Substring(3, 2)
            yyyy = Microsoft.VisualBasic.Right(strddMMyyyy, 4)
            Return New Date(yyyy, MM, dd)
        Catch ex As Exception
            Return New Date(1900, 1, 1)
        End Try
    End Function

    Public Function DateToString(ByVal DT As DateTime) As String
        Try
            Dim str As String = DT.Year.ToString + "-" + DT.Month.ToString + "-" + DT.Day.ToString
            Return str
        Catch ex As Exception
            Return "1900-01-01"
        End Try
    End Function

    Public Function DateTimeToString(ByVal DT As DateTime) As String
        Try
            Dim str As String = DT.Year.ToString + "-" + DT.Month.ToString + "-" + DT.Day.ToString + " " + DT.Hour.ToString + ":" + DT.Minute.ToString + ":" + DT.Second.ToString
            Return str
        Catch ex As Exception
            Return "1900-01-01 00:00:00"
        End Try
    End Function

    Public Function getDay_HaiChuSo(ByVal dt As DateTime) As String
        If dt.Day < 10 Then
            Return "0" + dt.Day.ToString
        Else
            Return dt.Day.ToString
        End If
    End Function
    Public Function getMonth_HaiChuSo(ByVal dt As DateTime) As String
        If dt.Month < 10 Then
            Return "0" + dt.Month.ToString
        Else
            Return dt.Month.ToString
        End If
    End Function
    Public Function GetTinhTP(ByVal DiaChi As String) As String
        If Split(DiaChi, "-").Length > 0 Then
            If Split(DiaChi, "-").Length = 4 Then
                Return Split(DiaChi, "-")(3)
            ElseIf Split(DiaChi, "-").Length = 3 Then
                Return Split(DiaChi, "-")(2)
            ElseIf Split(DiaChi, "-").Length = 2 Then
                Return Split(DiaChi, "-")(1)
            ElseIf Split(DiaChi, "-").Length = 1 Then
                Return Split(DiaChi, "-")(0)
            End If
        End If
        Return ""
    End Function
    Public Function GetQuanHuyen(ByVal DiaChi As String) As String
        If Split(DiaChi, "-").Length > 0 Then
            If Split(DiaChi, "-").Length = 4 Then
                Return Split(DiaChi, "-")(2)
            ElseIf Split(DiaChi, "-").Length = 3 Then
                Return Split(DiaChi, "-")(1)
            ElseIf Split(DiaChi, "-").Length = 2 Then
                Return Split(DiaChi, "-")(0)
            End If
        End If
        Return ""
    End Function
    Public Function GetXaPhuong(ByVal DiaChi As String) As String
        If Split(DiaChi, "-").Length > 0 Then
            If Split(DiaChi, "-").Length = 4 Then
                Return Split(DiaChi, "-")(1)
            ElseIf Split(DiaChi, "-").Length = 3 Then
                Return Split(DiaChi, "-")(0)
            End If
        End If
        Return ""
    End Function
    Public Function GetSoNhaThonXom(ByVal DiaChi As String) As String
        If Split(DiaChi, "-").Length > 0 Then
            If Split(DiaChi, "-").Length = 4 Then
                Return Split(DiaChi, "-")(0)
            End If
        End If
        Return ""
    End Function
    Public Sub ChuanHoaKhungGioTrongCaLamViec(ByVal Ngay As DateTime, ByRef gio1 As DateTime, ByRef gio2 As DateTime)
        If gio1.Hour <= gio2.Hour Then
            gio1 = New DateTime(Ngay.Year, Ngay.Month, Ngay.Day, gio1.Hour, gio1.Minute, gio1.Second)
            gio2 = New DateTime(Ngay.Year, Ngay.Month, Ngay.Day, gio2.Hour, gio2.Minute, gio2.Second)
        Else
            gio1 = New DateTime(Ngay.Year, Ngay.Month, Ngay.Day, gio1.Hour, gio1.Minute, gio1.Second)
            gio2 = New DateTime(Ngay.AddDays(1).Year, Ngay.AddDays(1).Month, Ngay.AddDays(1).Day, gio2.Hour, gio2.Minute, gio2.Second)
        End If
    End Sub
    Public Function LayCaiDatGiaTri(ByVal dt As DataTable, ByVal sql As String) As String
        Dim row As DataRow() = dt.Select("[ID] = '" + sql + "'")
        If row.Length > 0 Then
            If Not IsDBNull(row(0)("Value")) Then
                Return row(0)("Value")
            End If
        End If
    End Function

    Public Function LayBangCaiDatGiaTri() As DataTable
        Return kncsdl.Select_CauLenhSQL("select * from [dbo].[SetUp]")
    End Function
    Public Function DemSoNgayCN(ByVal NgayDau As DateTime, ByVal NgayCuoi As DateTime) As Integer
        Dim Ngay As DateTime = NgayDau
        Dim i As Integer = 0
        While DateTime.Compare(Ngay, NgayCuoi) <= 0
            If Ngay.DayOfWeek = DayOfWeek.Sunday Then
                i += 1
            End If
            Ngay = Ngay.AddDays(1)
        End While
        Return i
    End Function
    Public Function DemSoNgayT7(ByVal NgayDau As DateTime, ByVal NgayCuoi As DateTime) As Integer
        Dim Ngay As DateTime = NgayDau
        Dim i As Integer = 0
        While DateTime.Compare(Ngay, NgayCuoi) <= 0
            If Ngay.DayOfWeek = DayOfWeek.Saturday Then
                i += 1
            End If
            Ngay = Ngay.AddDays(1)
        End While
        Return i
    End Function
    Public Function KiemTraQuyen(ByVal MaChucNang As String) As String
        Try
            Dim BangQuyen As New UserPermission
            Dim dtKiemTraQuyen As DataTable = BangQuyen.Userpermission(Appsettings.DbSetting.UserName, MaChucNang)
            Return dtKiemTraQuyen.Rows(0)("Quyen")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function UNItokdau(ByVal str$) As String
        Dim kd$, unI$, i&, skd$
        Dim arrkd() As String, STT
        kd = "a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,e,e,e,e,e,e,e,e,e,e,e,i,i,i,i,i,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,u,u,u,u,u,u,u,u,u,u,u,y,y,y,y,y,d,A,A,A,A,A,A,A,A,A,A,A,A,A,A,A,A,A,E,E,E,E,E,E,E,E,E,E,E,I,I,I,I,I,O,O,O,O,O,O,O,O,O,O,O,O,O,O,O,O,O,U,U,U,U,U,U,U,U,U,U,U,Y,Y,Y,Y,Y,D"
        unI = "02250224784302277841025978557857785978617863022678457847784978517853023302327867786978650234787178737875787778790237023678810297788302430242788702457885024478897891789378957897041778997901790379057907025002497911036179090432791379157917791979210253792379277929792502730193019278420195784002587854785678587860786201947844784678487850785202010200786678687864020278707872787478767878020502047880029678820211021078860213788402127888789078927894789604167898790079027904790602180217791003607908043179127914791679187920022179227926792879240272"
        arrkd = Split(kd, ",")
        For i = 1 To Len(str)
            If InStr(unI, AscW(Mid(str$, i, 1))) > 0 And AscW(Mid(str$, i, 1)) > 127 Then
                STT = InStr(unI, AscW(Mid(str$, i, 1))) \ 4
                If AscW(Mid(str$, i, 1)) = 250 Then skd = skd & "u" Else skd = skd & arrkd(STT) 'Tam sua ký tu ú
            Else
                skd = skd & Mid(str, i, 1)
            End If
        Next
        UNItokdau = skd
    End Function

    Public Function KiemTraLoaiGio(ByVal Ca As String, ByVal PhanTram As Double) As Integer
        Dim dt As DataTable = kncsdl.Select_CauLenhSQL("select * from [dbo].[HR_SetupHourTimeKeeping] where [ShiftName] = '" + Ca + "' and [Percent] = '" + PhanTram + "'")
        If dt.Rows.Count <= 0 Then
            Return 3
        ElseIf IsDBNull(dt.Rows(0)("isOverTime")) Then
            Return 2
        ElseIf dt.Rows(0)("isOverTime") = False Then
            Return 2
        Else
            Return 1
        End If
    End Function

    'Public Function XuatExcelTheoGridex_RowChecked(ByVal LinkFileTemplate As String, ByVal LinkFileXuat As String, ByVal grid As GridEX, ByVal isHeaderFollowGridex As Boolean, ByVal isOpen As Boolean, ByVal index As Integer, ByVal Cells() As String, ByVal ContentFollowCell() As String, ByVal No As Boolean, ByVal Format As Boolean) As Boolean
    '    Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"}
    '    Dim Xls As New XlsReport
    '    Dim urlTemplate As String = LinkFileTemplate
    '    Xls.FileName = urlTemplate
    '    Xls.Start.File()
    '    Xls.Page.Begin("Sheet1", "1")
    '    Xls.Page.Name = "Sheet1"
    '    Dim i As Integer
    '    Dim j As Integer = 0
    '    Dim k As Integer = 0
    '    Dim stt As Integer = 0
    '    Dim countCol As Integer = 0
    '    Dim indexGoc As Integer = index
    '    Dim rowgrid, rowgridChildren As GridEXRow
    '    Dim colgrid As GridEXColumn
    '    Try
    '        If System.IO.File.Exists(LinkFileXuat) = True Then
    '            System.IO.File.Delete(LinkFileXuat)
    '        End If
    '    Catch ex As Exception
    '        'MessageBox.Show("File bạn đang mở nên không thể thực hiện thay đổi.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return False
    '    End Try
    '    j = 0
    '    For Each s As String In Cells
    '        Xls.Cell(s).Value = ContentFollowCell(j)
    '        j += 1
    '    Next
    '    j = 0
    '    If isHeaderFollowGridex = True Then
    '        If No = True Then
    '            Xls.Cell(ColExel(0) + index.ToString).Attr.LineBottom = xlLineStyle.lsNormal
    '            Xls.Cell(ColExel(0) + index.ToString).Attr.LineLeft = xlLineStyle.lsNormal
    '            Xls.Cell(ColExel(0) + index.ToString).Attr.LineRight = xlLineStyle.lsNormal
    '            Xls.Cell(ColExel(0) + index.ToString).Attr.LineTop = xlLineStyle.lsNormal

    '            Xls.Cell(ColExel(0) + (index + 1).ToString).Attr.LineLeft = xlLineStyle.lsNormal
    '            Xls.Cell(ColExel(0) + (index + 1).ToString).Attr.LineRight = xlLineStyle.lsDot
    '            Xls.Cell(ColExel(0) + (index + 1).ToString).Attr.LineBottom = xlLineStyle.lsDot
    '            Xls.Cell(ColExel(0) + (index + 2).ToString).Attr.LineLeft = xlLineStyle.lsNormal
    '            Xls.Cell(ColExel(0) + (index + 2).ToString).Attr.LineRight = xlLineStyle.lsDot
    '            Xls.Cell(ColExel(0) + (index + 2).ToString).Attr.LineBottom = xlLineStyle.lsDot
    '            Xls.Cell(ColExel(0) + index.ToString).Value = "STT"
    '            j = 1
    '        End If
    '        For Each colgrid In grid.RootTable.Columns
    '            If colgrid.Visible = True And colgrid.ColumnType <> ColumnType.CheckBox Then
    '                Xls.Cell(ColExel(j) + index.ToString).Attr.LineBottom = xlLineStyle.lsNormal
    '                Xls.Cell(ColExel(j) + index.ToString).Attr.LineLeft = xlLineStyle.lsNormal
    '                Xls.Cell(ColExel(j) + index.ToString).Attr.LineRight = xlLineStyle.lsNormal
    '                Xls.Cell(ColExel(j) + index.ToString).Attr.LineTop = xlLineStyle.lsNormal

    '                Xls.Cell(ColExel(j) + (index + 1).ToString).Attr.LineBottom = xlLineStyle.lsDot
    '                Xls.Cell(ColExel(j) + (index + 1).ToString).Attr.LineLeft = xlLineStyle.lsDot
    '                Xls.Cell(ColExel(j) + (index + 1).ToString).Attr.LineRight = xlLineStyle.lsDot
    '                Xls.Cell(ColExel(j) + (index + 2).ToString).Attr.LineBottom = xlLineStyle.lsDot
    '                Xls.Cell(ColExel(j) + (index + 2).ToString).Attr.LineLeft = xlLineStyle.lsDot
    '                Xls.Cell(ColExel(j) + (index + 2).ToString).Attr.LineRight = xlLineStyle.lsDot
    '                Xls.Cell(ColExel(j) + index.ToString).Value = colgrid.Caption
    '                j += 1
    '                countCol += 1
    '            End If
    '        Next
    '        Xls.Cell(ColExel(countCol) + (index + 1).ToString).Attr.LineBottom = xlLineStyle.lsDot
    '        Xls.Cell(ColExel(countCol) + (index + 1).ToString).Attr.LineLeft = xlLineStyle.lsDot
    '        Xls.Cell(ColExel(countCol) + (index + 1).ToString).Attr.LineRight = xlLineStyle.lsNormal
    '        Xls.Cell(ColExel(countCol) + (index + 2).ToString).Attr.LineBottom = xlLineStyle.lsDot
    '        Xls.Cell(ColExel(countCol) + (index + 2).ToString).Attr.LineLeft = xlLineStyle.lsDot
    '        Xls.Cell(ColExel(countCol) + (index + 2).ToString).Attr.LineRight = xlLineStyle.lsNormal
    '    End If
    '    index += 1
    '    For Each rowgrid In grid.GetCheckedRows
    '        Xls.RowCopy(index, index + 1)
    '        If No = True Then
    '            j = 1
    '            stt += 1
    '            Xls.Cell(ColExel(0) + index.ToString).Value = stt.ToString
    '        Else
    '            j = 0
    '        End If
    '        k = 0
    '        For Each colgrid In grid.RootTable.Columns
    '            If colgrid.Visible = True And colgrid.ColumnType <> ColumnType.CheckBox Then
    '                If Format = True Then
    '                    If Not IsNothing(rowgrid.Cells(k).Value) Then
    '                        If rowgrid.Cells(k).Value.GetType().ToString = "System.DateTime" Then
    '                            Xls.Cell(ColExel(j) + index.ToString).Attr.Format = "dd/MM/yyyy"
    '                            Xls.Cell(ColExel(j) + index.ToString).Value = rowgrid.Cells(k).Value
    '                        ElseIf rowgrid.Cells(k).Value.GetType().ToString = "System.Double" Or rowgrid.Cells(k).Value.GetType().ToString = "System.Int32" Then
    '                            Xls.Cell(ColExel(j) + index.ToString).Attr.Format = "#,##"
    '                            Xls.Cell(ColExel(j) + index.ToString).Value = rowgrid.Cells(k).Value
    '                        Else
    '                            Xls.Cell(ColExel(j) + index.ToString).Attr.Format = "@"
    '                            Xls.Cell(ColExel(j) + index.ToString).Value = rowgrid.Cells(k).Value
    '                        End If
    '                    End If
    '                Else
    '                    If Not IsNothing(rowgrid.Cells(k)) Then
    '                        Xls.Cell(ColExel(j) + index.ToString).Attr.Format = "@"
    '                        Xls.Cell(ColExel(j) + index.ToString).Value = rowgrid.Cells(k).Text
    '                    End If
    '                End If
    '                j += 1
    '                k += 1
    '            Else
    '                k += 1
    '            End If
    '        Next
    '        index += 1
    '    Next
    '    For j = 0 To countCol
    '        Xls.Cell(ColExel(j) + index.ToString).Attr.LineBottom = xlLineStyle.lsNormal
    '    Next
    '    Xls.Page.End()
    '    Xls.Out.File(LinkFileXuat)
    '    SaveFileExcel(LinkFileXuat)
    '    If isOpen = True Then
    '        Dim ps As New ProcessStartInfo
    '        ps.UseShellExecute = True
    '        ps.FileName = LinkFileXuat
    '        Process.Start(ps)
    '    End If
    '    Return True
    'End Function

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

    Public Sub SaveFileExcelToBDF(ByVal LinkFileExcel As String, ByVal LinkFilePDFExport As String)
        Dim excelApplication As Excel1.ApplicationClass = New Excel1.ApplicationClass
        Dim excelWorkbook As Excel1.Workbook = Nothing
        Dim paramSourceBookPath As String = LinkFileExcel
        Dim paramExportFilePath As String = LinkFilePDFExport
        Dim paramExportFormat As Excel1.XlFixedFormatType = _
            Excel1.XlFixedFormatType.xlTypePDF
        Dim paramExportQuality As Excel1.XlFixedFormatQuality = _
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
                excelWorkbook.ExportAsFixedFormat(paramExportFormat, _
                    paramExportFilePath, paramExportQuality, _
                    paramIncludeDocProps, paramIgnorePrintAreas, _
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

    Public Sub SaveFileExcel(ByVal LinkFile As String)
        Dim xlApp As New Excel1.Application
        Dim xlWorkBook As Excel1.Workbook
        Dim xlWorkSheet As Excel1.Worksheet
        '~~> Opens Source Workbook. Change path and filename as applicable
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        xlWorkBook = xlApp.Workbooks.Open(LinkFile)

        '~~> Display Excel
        xlApp.Visible = False

        '~~> Do some work

        '~~> Save the file
        xlWorkBook.Save()

        '~~> Close the file
        xlWorkBook.Close()
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    'Public Sub LoadTemplateCuaGridex(ByVal LinkTemplate As String, ByVal gr As GridEX)
    '    Try
    '        Dim LayoutDir As String = LinkTemplate 'dbset.GetAppPath() + "\Employee.gxl"
    '        Dim LayoutStream As FileStream
    '        LayoutStream = New FileStream(LayoutDir, FileMode.Open)
    '        gr.LoadLayoutFile(LayoutStream)
    '        LayoutStream.Close()
    '    Catch ex As Exception
    '        'MsgBox(ex.ToString, MsgBoxStyle.Critical, dbset.Version)
    '    End Try
    'End Sub

    'LƯU FILE TEMPLATE CỦA GRIDEX
    'Public Sub LuuTemplateCuaGridex(ByVal LinkTemplate As String, ByVal gr As GridEX)
    '    Try
    '        Dim LayoutDir As String
    '        Dim LayoutStream As FileStream
    '        LayoutDir = LinkTemplate 'dbset.GetAppPath() + "\Employee.gxl"
    '        LayoutStream = New FileStream(LayoutDir, FileMode.Create)
    '        gr.SaveLayoutFile(LayoutStream)
    '        LayoutStream.Close()
    '    Catch ex As Exception
    '        'MsgBox(ex.ToString, MsgBoxStyle.Critical, dbset.Version)
    '    End Try
    'End Sub

    'Public Sub LayTemplate(ByVal Grid As GridEX, ByVal FirtsRow As Integer, ByVal LinkFileTemplate As String, ByVal LinkFileExport As String, ByVal DanhSachCotKhongNamTrongTemplate As String())
    '    Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL"}
    '    Dim Xls As New XlsReport
    '    Dim index As Integer = FirtsRow
    '    Xls.FileName = LinkFileTemplate
    '    Xls.Start.File()
    '    Xls.Page.Begin("Sheet1", "1")
    '    Xls.Page.Name = "Sheet1"
    '    Dim col As GridEXColumn
    '    Dim i As Integer = 0
    '    For Each col In Grid.RootTable.Columns
    '        If col.Visible = True And col.ActAsSelector = False And DanhSachCotKhongNamTrongTemplate.IndexOf(DanhSachCotKhongNamTrongTemplate, col.DataMember) < 0 Then
    '            Xls.Cell(ColExel(i) + index.ToString).Value = col.Caption
    '            i += 1
    '        End If
    '    Next
    '    Xls.Page.End()
    '    Xls.Out.File(LinkFileExport)
    '    Dim ps As New ProcessStartInfo
    '    ps.UseShellExecute = True
    '    ps.FileName = LinkFileExport
    '    Process.Start(ps)
    'End Sub

    'Public Sub NhapExcel(ByVal Grid As GridEX, ByVal TableName As String, ByVal DataMember() As String, ByVal Primary() As String, ByVal StartLine As Integer, ByVal placeCall As String, ByVal LinkFileExcel As String)
    '    Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL"}
    '    Dim Xls As New XlsReport
    '    Xls.FileName = LinkFileExcel
    '    Xls.Start.File()
    '    Xls.Page.Begin("Sheet1", "1")
    '    Xls.Page.Name = "Sheet1"
    '    Dim str_sqlInsert, str_sqlUpdate, str_sqlWhere, str_sql As String
    '    Dim index As Integer = StartLine
    '    Dim str_TruongInsert, str_GiaTriInsert As String
    '    str_TruongInsert = String.Empty
    '    Dim PrimaryIndex As New ArrayList
    '    For Each col As GridEXColumn In Grid.RootTable.Columns
    '        If DataMember.IndexOf(DataMember, col.DataMember) >= 0 Then
    '            str_TruongInsert += "[" + col.DataMember + "]" + ","
    '        End If
    '    Next
    '    str_TruongInsert = str_TruongInsert.Remove(str_TruongInsert.Length - 1, 1)
    '    Dim i, int_KiemTraDungVongWHILE As Integer
    '    While True
    '        str_GiaTriInsert = String.Empty
    '        str_sqlUpdate = String.Empty
    '        str_sqlWhere = String.Empty
    '        i = 0
    '        int_KiemTraDungVongWHILE = 0
    '        For Each col As GridEXColumn In Grid.RootTable.Columns
    '            If DataMember.IndexOf(DataMember, col.DataMember) >= 0 Then
    '                If CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim = String.Empty Then
    '                    str_GiaTriInsert += "null,"
    '                    str_sqlUpdate += "[" + col.DataMember + "] = null,"
    '                    int_KiemTraDungVongWHILE += 1
    '                Else
    '                    If Grid.RootTable.Columns(col.DataMember).Type.ToString = "System.String" Then
    '                        str_GiaTriInsert += "N'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "',"
    '                        str_sqlUpdate += "[" + col.DataMember + "] = " + "N'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "',"
    '                    Else
    '                        str_GiaTriInsert += "'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "',"
    '                        str_sqlUpdate += "[" + col.DataMember + "] = " + "'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "',"
    '                    End If
    '                End If
    '                If Not IsNothing(Primary) Then
    '                    For Each P As String In Primary
    '                        If col.DataMember.ToUpper = P.ToUpper Then
    '                            If col.Type.ToString = "System.String" Then
    '                                str_sqlWhere += "[" + P + "] = N'" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "' and "
    '                            Else
    '                                str_sqlWhere += "[" + P + "] = '" + CStr(Xls.Cell(ColExel(i) + index.ToString()).Value).Trim + "' and "
    '                            End If
    '                            Exit For
    '                        End If
    '                    Next
    '                End If
    '                i += 1
    '            End If
    '        Next
    '        If int_KiemTraDungVongWHILE = DataMember.Length Then
    '            Exit While
    '        End If
    '        str_GiaTriInsert = str_GiaTriInsert.Remove(str_GiaTriInsert.Length - 1, 1)
    '        str_sqlUpdate = str_sqlUpdate.Remove(str_sqlUpdate.Length - 1, 1)
    '        If str_sqlWhere <> String.Empty Then
    '            str_sqlWhere = str_sqlWhere.Remove(str_sqlWhere.Length - 5, 5)
    '            str_sql += "IF EXISTS(SELECT * FROM [dbo].[" + TableName + "] WHERE " + str_sqlWhere + ") " & _
    '                "BEGIN UPDATE [dbo].[" + TableName + "] SET " + str_sqlUpdate + " WHERE " + str_sqlWhere + " END " & _
    '                "ELSE BEGIN INSERT INTO [dbo].[" + TableName + "] (" + str_TruongInsert + ") VALUES(" + str_GiaTriInsert + ") END "
    '        End If
    '        index += 1
    '    End While
    '    If str_sql <> String.Empty Then
    '        kn.SaveData(str_sql)
    '    End If
    '    Xls.Page.End()
    '    Xls.Out.File(LinkFileExcel)
    'End Sub

    Public Function CauTruyVanLayTongCong(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal LamTronCong1 As Double, ByVal LamTronCong2 As Double, ByVal LamTronCong3 As Double, Optional ByVal DanhSachMaNhanVien As String() = Nothing) As String
        Dim str_SQL_LayDuLieuCong As String
        If IsNothing(DanhSachMaNhanVien) Then
            str_SQL_LayDuLieuCong = "select tkp.OT_date, emp.Employee_ID, emp.Employee_FirstName, emp.Employee_LastName,emp.StartedDate,emp.TernimationDate,emp.Employee_Status, emp.Position_ID,emp.PositionCategory_ID, emp.DepartmentCode, emp.SectionCode, emp.TeamCode, tkp.WokingTime, tkp.[Percent] " & _
                            "from " & _
                            "(select [OT_date], [Employee_ID], sum(isnull([WokingTime],0)) as [WokingTime], [Percent] from ( " & _
                            "((select [OT_date], [Employee_ID], (case when " + LamTronCong3.ToString + " > 0 then dbo.udf_LamTron1(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ", " + LamTronCong3.ToString + ") else dbo.udf_LamTron(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ") end) as [WokingTime], [Percent] from SmartBooks_TimeKeeping_Date where [OT_date] between '" + DateToString(TuNgay) + "' and '" + DateToString(DenNgay) + "' group by [OT_date], [Employee_ID], [Percent]) " & _
                            "union all " & _
                            "(select [DateAdd] as OT_date, Employee_ID, HoursAdd as [WorkingTime], [Percent] from HR_ThemGioCong_TruongHopNgoaiLe where [DateAdd] between '" + DateToString(TuNgay) + "' and '" + DateToString(DenNgay) + "')) " & _
                            ") as abc group by [OT_date], [Employee_ID], [Percent]) as tkp " & _
                            "left join dbo.SmartBooks_Employee emp " & _
                            "on tkp.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID"
        Else
            Dim str_SQLDanhSachMaNhanVien As String
            For Each s As String In DanhSachMaNhanVien
                str_SQLDanhSachMaNhanVien += "'" + s + "',"
            Next
            If str_SQLDanhSachMaNhanVien <> String.Empty Then
                str_SQLDanhSachMaNhanVien = str_SQLDanhSachMaNhanVien.Remove(str_SQLDanhSachMaNhanVien.Length - 1, 1)
                str_SQL_LayDuLieuCong = "select tkp.OT_date, emp.Employee_ID, emp.Employee_FirstName, emp.Employee_LastName,emp.StartedDate,emp.TernimationDate,emp.Employee_Status, emp.Position_ID,emp.PositionCategory_ID, emp.DepartmentCode, emp.SectionCode, emp.TeamCode, tkp.WokingTime, tkp.[Percent] " & _
                            "from " & _
                            "(select [OT_date], [Employee_ID], sum(isnull([WokingTime],0)) as [WokingTime], [Percent] from ( " & _
                            "((select [OT_date], [Employee_ID], (case when " + LamTronCong3.ToString + " > 0 then dbo.udf_LamTron1(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ", " + LamTronCong3.ToString + ") else dbo.udf_LamTron(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ") end) as [WokingTime], [Percent] from SmartBooks_TimeKeeping_Date where [OT_date] between '" + DateToString(TuNgay) + "' and '" + DateToString(DenNgay) + "' and Employee_ID IN (" + str_SQLDanhSachMaNhanVien + ") group by [OT_date], [Employee_ID], [Percent]) " & _
                            "union all " & _
                            "(select [DateAdd] as OT_date, Employee_ID, HoursAdd as [WorkingTime], [Percent] from HR_ThemGioCong_TruongHopNgoaiLe where [DateAdd] between '" + DateToString(TuNgay) + "' and '" + DateToString(DenNgay) + "' and Employee_ID IN (" + str_SQLDanhSachMaNhanVien + "))) " & _
                            ") as abc group by [OT_date], [Employee_ID], [Percent]) as tkp " & _
                            "left join (select * from dbo.SmartBooks_Employee where Employee_ID IN (" + str_SQLDanhSachMaNhanVien + ")) as emp " & _
                            "on tkp.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID"
            End If
        End If
        Return str_SQL_LayDuLieuCong
    End Function
    Public Function CauTruyVanLayCongThuViec(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal LamTronCong1 As Double, ByVal LamTronCong2 As Double, ByVal LamTronCong3 As Double, Optional ByVal DanhSachMaNhanVien As String() = Nothing) As String
        Dim str_SQL_LayDuLieuCong As String
        If IsNothing(DanhSachMaNhanVien) Then
            str_SQL_LayDuLieuCong = "select tkp.OT_date, emp.Employee_ID, emp.Employee_FirstName, emp.Employee_LastName, emp.Position_ID, emp.DepartmentCode, emp.SectionCode, emp.TeamCode, tkp.WokingTime, tkp.[Percent] " & _
            "from " & _
            "(select [OT_date], [Employee_ID], sum(isnull([WokingTime],0)) as [WokingTime], [Percent] from ( " & _
            "((select [OT_date], [Employee_ID], (case when " + LamTronCong3.ToString + " > 0 then dbo.udf_LamTron1(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ", " + LamTronCong3.ToString + ") else dbo.udf_LamTron(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ") end) as [WokingTime], [Percent] from SmartBooks_TimeKeeping_Date group by [OT_date], [Employee_ID], [Percent]) " & _
            "union all " & _
            "(select [DateAdd] as OT_date, Employee_ID, HoursAdd as [WokingTime], [Percent] from HR_ThemGioCong_TruongHopNgoaiLe)) " & _
            ") as abc group by [OT_date], [Employee_ID], [Percent]) as tkp " & _
            "left join dbo.SmartBooks_Employee emp " & _
            "on tkp.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID " & _
            "where OT_date < emp.ProbationDate and [OT_date] between '" + DateToString(TuNgay) + "' and '" + DateToString(DenNgay) + "'"
        Else
            Dim str_SQLDanhSachMaNhanVien As String
            For Each s As String In DanhSachMaNhanVien
                str_SQLDanhSachMaNhanVien += "'" + s + "',"
            Next
            If str_SQLDanhSachMaNhanVien <> String.Empty Then
                str_SQLDanhSachMaNhanVien = str_SQLDanhSachMaNhanVien.Remove(str_SQLDanhSachMaNhanVien.Length - 1, 1)
                str_SQL_LayDuLieuCong = "select tkp.OT_date, emp.Employee_ID, emp.Employee_FirstName, emp.Employee_LastName, emp.Position_ID, emp.DepartmentCode, emp.SectionCode, emp.TeamCode, tkp.WokingTime, tkp.[Percent] " & _
                                       "from " & _
                                       "(select [OT_date], [Employee_ID], sum(isnull([WokingTime],0)) as [WokingTime], [Percent] from ( " & _
                                       "((select [OT_date], [Employee_ID], (case when " + LamTronCong3.ToString + " > 0 then dbo.udf_LamTron1(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ", " + LamTronCong3.ToString + ") else dbo.udf_LamTron(sum(isnull([WokingTime],0))/60, " + LamTronCong1.ToString + ", " + LamTronCong2.ToString + ") end) as [WokingTime], [Percent] from SmartBooks_TimeKeeping_Date where Employee_ID IN (" + str_SQLDanhSachMaNhanVien + ") group by [OT_date], [Employee_ID], [Percent]) " & _
                                       "union all " & _
                                       "(select [DateAdd] as OT_date, Employee_ID, HoursAdd as [WokingTime], [Percent] from HR_ThemGioCong_TruongHopNgoaiLe where Employee_ID IN (" + str_SQLDanhSachMaNhanVien + "))) " & _
                                       ") as abc group by [OT_date], [Employee_ID], [Percent]) as tkp " & _
                                       "left join (select * from dbo.SmartBooks_Employee where Employee_ID IN (" + str_SQLDanhSachMaNhanVien + ")) as emp " & _
                                       "on tkp.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID " & _
                                       "where OT_date < emp.ProbationDate and [OT_date] between '" + DateToString(TuNgay) + "' and '" + DateToString(DenNgay) + "'"
            End If
        End If
        Return str_SQL_LayDuLieuCong
    End Function
End Class
