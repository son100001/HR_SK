Public Class DBData
    Dim kncsdl As New SmartBooks.BusinessLogic.KetNoiCSDL

    ' LAY CSDL
    Public Function DongBo_BangCong_BangDangKyCa(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StardDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_DongBo_BangCong_BangDangKyCa", name, oj, 2)
    End Function
    Public Function DongBo_BangCong_BangQuetVanTay(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StardDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_DongBo_BangCong_BangQuetVanTay", name, oj, 2)
    End Function
    Public Function DongBo_BangCong_BangPhep(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StardDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_DongBo_BangCong_BangPhep", name, oj, 2)
    End Function
    Public Function DongBo_BangCong_BangGioiHanTangCa(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StardDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_DongBo_BangCong_BangGioiHanTangCa", name, oj, 2)
    End Function
    Public Function Select_TienComTangCa(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_Select_TienComTangCa", name, oj, 2)
    End Function
    Public Function BaoCaoTongHopTheoBoPhan(ByVal DepartmentCode As String, ByVal OT_date As DateTime, ByVal Ca As String) As DataTable
        Dim name() As String = {"@DepartmentCode", "@OT_date", "@Ca"}
        Dim oj() As Object = {DepartmentCode, OT_date, Ca}
        Return kncsdl.Select_("AGiang_BaoCaoTongHopTheoBoPhan", name, oj, 3)
    End Function
    Public Function Select_HR_MaxOvertime_GioTangCa(ByVal Employee_ID As String, ByVal workingdate As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@workingdate"}
        Dim oj() As Object = {Employee_ID, workingdate}
        Return kncsdl.Select_("AGiang_Select_HR_MaxOvertime_GioTangCa", name, oj, 2)
    End Function
    Public Function Select_HR_EmpRegisLeave(ByVal Employee_ID As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@Startdate", "@Enddate"}
        Dim oj() As Object = {Employee_ID, StartDate, EndDate}
        Return kncsdl.Select_("AGiang_Select_HR_EmpRegisLeave", name, oj, 3)
    End Function
    Public Function TinhLuong(ByVal Key As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@key", "@fromdate", "@todate"}
        Dim oj() As Object = {Key, StartDate, EndDate}
        Return kncsdl.Select_("Employee_Salary_New", name, oj, 3)
    End Function
    Public Sub BuLuongNhanVienDaNghiViec(ByVal Key As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime)
        Dim name() As String = {"@key", "@fromdate", "@todate"}
        Dim oj() As Object = {Key, StartDate, EndDate}
        Dim dt As DataTable = kncsdl.Select_("AGiang_BuLuongNhanVienDaNghiViec", name, oj, 3)
    End Sub
    Public Function SelectAll_HR_ComKhach_TheoKhoangThoiGian(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_SelectAll_HR_ComKhach_TheoKhoangThoiGian", name, oj, 2)
    End Function
    Public Sub Delete_HR_ComKhach(ByVal ID As String)
        Dim name() As String = {"@ID"}
        Dim oj() As Object = {ID}
        kncsdl.Select_("AGiang_Delete_HR_ComKhach", name, oj, 1)
    End Sub
    Public Function Insert_HR_ComKhach(ByVal TenKhach As String, ByVal TimeDate As DateTime, ByVal Rise As Integer, ByVal Bua As String, ByVal Comment As String, ByVal InsertBy As String, ByVal InsertDate As DateTime, ByVal Tien As Double, ByVal Nationality As String, ByVal DepartmentCode As String) As Integer
        Dim name() As String = {"@TenKhach", "@TimeDate", "@Rise", "@Bua", "@Comment", "@InsertBy", "@InsertDate", "@Tien", "@Nationality", "@DepartmentCode"}
        Dim oj() As Object = {TenKhach, TimeDate, Rise, Bua, Comment, InsertBy, InsertDate, Tien, Nationality, DepartmentCode}
        Return kncsdl.Insert("AGiang_Insert_HR_ComKhach", name, oj, 10)
    End Function
    Public Sub Delete_HR_Com(ByVal Employee_ID As String, ByVal TimeDate As DateTime, ByVal Bua As String)
        Dim name() As String = {"@Employee_ID", "@TimeDate", "@Bua"}
        Dim oj() As Object = {Employee_ID, TimeDate, Bua}
        kncsdl.Select_("AGiang_Delete_HR_Com", name, oj, 3)
    End Sub
    Public Function LayThongTinQuetChamComCuaMotNV(ByVal Employee_ID As String, ByVal GioBatDauCa As DateTime, ByVal GioKetThucCa As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@GioBatBatDauCa", "@GioKetThucCa"}
        Dim oj() As Object = {Employee_ID, GioBatDauCa, GioKetThucCa}
        Return kncsdl.Select_("AGiang_LayThongTinQuetChamComCuaMotNV", name, oj, 3)
    End Function

    Public Function SelectAll_HR_Com_TheoKhoangThoiGian(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_SelectAll_HR_Com_TheoKhoangThoiGian", name, oj, 2)
    End Function
    Public Function Update_HR_Com(ByVal Employee_ID As String, ByVal TimeDate As DateTime, ByVal Rise As Integer, ByVal Bua As String, ByVal Tien As Double, ByVal Comment As String, ByVal UpdateBy As String, ByVal UpdateDate As DateTime) As Integer
        Dim name() As String = {"@Employee_ID", "@TimeDate", "@Rise", "@Bua", "@Tien", "@Comment", "@UpdateBy", "@UpdateDate"}
        Dim oj() As Object = {Employee_ID, TimeDate, Rise, Bua, Tien, Comment, UpdateBy, UpdateDate}
        Return kncsdl.Upadate("AGiang_Update_HR_Com", name, oj, 8)
    End Function
    Public Function Insert_HR_Com(ByVal Employee_ID As String, ByVal TimeDate As DateTime, ByVal Rise As Integer, ByVal Bua As String, ByVal Tien As Double, ByVal GioQuet As DateTime, ByVal Comment As String, ByVal InsertBy As String, ByVal InsertDate As DateTime) As Integer
        Dim name() As String = {"@Employee_ID", "@TimeDate", "@Rise", "@Bua", "@Tien", "@GioQuet", "@Comment", "@InsertBy", "@InsertDate"}
        Dim oj() As Object = {Employee_ID, TimeDate, Rise, Bua, Tien, GioQuet, Comment, InsertBy, InsertDate}
        Return kncsdl.Insert("AGiang_Insert_HR_Com", name, oj, 9)
    End Function
    Public Function Select_Permission_One(ByVal UserName As String, ByVal FormID As String) As DataTable
        Dim name() As String = {"@UserName", "@FormID"}
        Dim oj() As Object = {UserName, FormID}
        Return kncsdl.Select_("AGiang_Select_Permission_One", name, oj, 2)
    End Function
    Public Function Insert_Permission(ByVal UserName As String, ByVal FormID As String, ByVal Quyen As String) As Integer
        Dim name() As String = {"@UserName", "@FormID", "@Quyen"}
        Dim oj() As Object = {UserName, FormID, Quyen}
        Return kncsdl.Insert("AGiang_Insert_Permission", name, oj, 3)
    End Function
    Public Function Delete_Permission(ByVal UserName As String, ByVal FormID As String) As Integer
        Dim name() As String = {"@UserName", "@FormID"}
        Dim oj() As Object = {UserName, FormID}
        Return kncsdl.Insert("AGiang_Delete_Permission", name, oj, 2)
    End Function
    Public Function Update_Permission(ByVal UserName As String, ByVal FormID As String, ByVal Quyen As String) As Integer
        Dim name() As String = {"@UserName", "@FormID", "@Quyen"}
        Dim oj() As Object = {UserName, FormID, Quyen}
        Return kncsdl.Upadate("AGiang_Udate_Permission", name, oj, 3)
    End Function
    Public Function LayNhanVienDangActiveTheoKhoangThoiGian(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_LayNhanVienDangActiveTheoKhoangThoiGian", name, oj, 2)
    End Function
    Public Function LayNhanVienDangActiveTheoKhoangThoiGian_TheoBoPhan(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal DepartmentCode As String) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate", "@DepartmentCode"}
        Dim oj() As Object = {StartDate, EndDate, DepartmentCode}
        Return kncsdl.Select_("AGiang_LayNhanVienDangActiveTheoKhoangThoiGian_TheoBoPhan", name, oj, 3)
    End Function
    Public Function LayNhanVienSinhNhatDangActiveTheoKhoangThoiGian(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_LayNhanVienSinhNhatDangActiveTheoKhoangThoiGian", name, oj, 2)
    End Function
    Public Function HR_MaxOverTime_SelectByDate(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim name() As String = {"@StartDate", "@EndDate"}
        Dim oj() As Object = {StartDate, EndDate}
        Return kncsdl.Select_("AGiang_HR_MaxOverTime_SelectByDate", name, oj, 2)
    End Function
    Public Function BaoCaoThang(ByVal Startdate As DateTime, ByVal Enddate As DateTime) As DataTable
        Dim name() As String = {"@Startdate", "@Enddate"}
        Dim oj() As Object = {Startdate, Enddate}
        Return kncsdl.Select_("AGiang_BaoCaoThang", name, oj, 2)
    End Function
    Public Function HR_GoOut_SelectByEmp_Date(ByVal TimeDate As DateTime, ByVal Employee_ID As String) As DataTable
        Dim name() As String = {"@TimeDate", "@Employee_ID"}
        Dim oj() As Object = {TimeDate, Employee_ID}
        Return kncsdl.Select_("AGiang_HR_GoOut_SelectByEmp_Date", name, oj, 2)
    End Function
    Public Function AGiang_SelectAllPosition() As DataTable
        Return kncsdl.Select_("AGiang_SelectAllPosition")
    End Function
    Public Function SelectAllDepartment() As DataTable
        Return kncsdl.Select_("AGiang_SelectAllDepartment")
    End Function
    Public Function LayDanhSachNhanVienTamUngTheoKhoangThoiGian(ByVal DateTimeStart As String, ByVal DateTimeEnd As DateTime) As DataTable
        Dim name() As String = {"@DateTimeStart", "@DateTimeEnd"}
        Dim oj() As Object = {DateTimeStart, DateTimeEnd}
        Return kncsdl.Select_("AGiang_LayDanhSachNhanVienTamUngTheoKhoangThoiGian", name, oj, 2)
    End Function
    Public Function LayMotNhanVienUngTienTheoNgay(ByVal Employee_ID As String, ByVal CreateDate As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@CreateDate"}
        Dim oj() As Object = {Employee_ID, CreateDate}
        Return kncsdl.Select_("AGiang_LayMotNhanVienDangKyUngTienTheoNgay", name, oj, 2)
    End Function
    Public Function DangKyTamUngChoNhanVien(ByVal CreateDate As DateTime) As DataTable
        Dim name() As String = {"@CreateDate"}
        Dim oj() As Object = {CreateDate}
        Return kncsdl.Select_("AGiang_DangKyTamUngChoNhanVien", name, oj, 1)
    End Function
    Public Function BaoCaoThang_NhanVienXinRaNgoai(ByVal TimeDate As DateTime) As DataTable
        Dim name() As String = {"@TimeDate"}
        Dim oj() As Object = {TimeDate}
        Return kncsdl.Select_("AGiang_BaoCaoThang_NhanVienXinRaNgoai", name, oj, 1)
    End Function
    Public Function LayNhanVienActiveTheoThoiDiem(ByVal TimeDate As DateTime) As DataTable
        Dim name() As String = {"@TimeDate"}
        Dim oj() As Object = {TimeDate}
        Return kncsdl.Select_("AGiang_LayNhanVienDangActiveTheoThoiDiem", name, oj, 1)
    End Function
    Public Function SelectAll_HR_GoOut() As DataTable
        Return kncsdl.Select_("AGiang_SelectAll_HR_GoOut")
    End Function
    Public Function LayNhanVienXinRaNgoai(ByVal TimeDate As DateTime) As DataTable
        Dim name() As String = {"@TimeDate"}
        Dim oj() As Object = {TimeDate}
        Return kncsdl.Select_("AGiang_LayNhanVienXinRaNgoai", name, oj, 1)
    End Function
    Public Function LayMotNhanVienXinRaNgoaiTheoNgay(ByVal Employee_ID As String, ByVal TimeDate As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@TimeDate"}
        Dim oj() As Object = {Employee_ID, TimeDate}
        Return kncsdl.Select_("AGiang_LayMotNhanVienXinRaNgoaiTheoNgay", name, oj, 2)
    End Function
    Public Function LayThongTinDangKyComTruaCuaNhanVienTheoThang(ByVal Employee As String, ByVal eDate As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@eDate"}
        Dim oj() As Object = {Employee, eDate}
        Return kncsdl.Select_("AGiang_LayThongTinDangKyComTruaCuaNhanVienTheoThang", name, oj, 2)
    End Function
    Public Function LayThongTinDangKyComTangCaCuaNhanVienTheoThang(ByVal Employee As String, ByVal eDate As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@eDate"}
        Dim oj() As Object = {Employee, eDate}
        Return kncsdl.Select_("AGiang_LayThongTinDangKyComTangCaCuaNhanVienTheoThang", name, oj, 2)
    End Function
    Public Function LayCongNhanVienTrongKhoangThoiGian(ByVal OT_Date_Batdau As DateTime, ByVal OT_Date_KetThuc As DateTime) As DataTable
        Dim name() As String = {"@OT_date_BatDau", "@OT_date_KetThuc"}
        Dim oj() As Object = {OT_Date_Batdau, OT_Date_KetThuc}
        Return kncsdl.Select_("AGiang_Select_Timekeeping_Date1_ByDate", name, oj, 2)
    End Function
    Public Function LayNhanVienActiveTheoPositionVaSection(ByVal SectionCode As String, ByVal Position_ID As String) As DataTable
        Dim name() As String = {"@SectionCode", "@Position_ID"}
        Dim oj() As Object = {SectionCode, Position_ID}
        Return kncsdl.Select_("AGiang_LayNhanVienDangActive_SectionCode_Position", name, oj, 2)
    End Function
    Public Function LayNhanVienDangKyComTrua(ByVal eDate As DateTime) As DataTable
        Dim name() As String = {"@eDate"}
        Dim oj() As Object = {eDate}
        Return kncsdl.Select_("AGiang_LayNhanVienDangKyComTrua", name, oj, 1)
    End Function
    Public Function LayNhanVienDangKyComTangCa(ByVal eDate As DateTime) As DataTable
        Dim name() As String = {"@eDate"}
        Dim oj() As Object = {eDate}
        Return kncsdl.Select_("AGiang_LayNhanVienDangKyComTangCa", name, oj, 1)
    End Function
    Public Function Select_Timekeeping_Date1_Bykey(ByVal Key As String) As DataTable
        Dim name() As String = {"@Key"}
        Dim oj() As Object = {Key}
        Return kncsdl.Select_("AGiang_Select_Timekeeping_Date1_Bykey", name, oj, 1)
    End Function
    Public Function LayNhanVienTheoMa(ByVal Employee_ID As String) As DataTable
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Return kncsdl.Select_("AGiang_LayNhanVienTheoMa", name, oj, 1)
    End Function
    Public Function LayNhanVienActiveTheoPosition(ByVal Position_ID As String) As DataTable
        Dim name() As String = {"@Position_ID"}
        Dim oj() As Object = {Position_ID}
        Return kncsdl.Select_("AGiang_LayNhanVienDangActive_Position", name, oj, 1)
    End Function
    Public Function LayNhanVienActiveTheoSection(ByVal SectionCode As String) As DataTable
        Dim name() As String = {"@SectionCode"}
        Dim oj() As Object = {SectionCode}
        Return kncsdl.Select_("AGiang_LayNhanVienDangActive_SectionCode", name, oj, 1)
    End Function
    Public Function LayThoiGianQuetTrongNgay(ByVal Employee_ID As String, ByVal GioBatDauCa As DateTime, ByVal GioKetThucCa As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@GioBatBatDauCa", "@GioKetThucCa"}
        Dim oj() As Object = {Employee_ID, GioBatDauCa, GioKetThucCa}
        Return kncsdl.Select_("AGiang_LayThongTinQuetCuaMotNhanVienTrongNgay", name, oj, 3)
    End Function

    Public Function LayTenCaChinhCuaNV(ByVal Employee_ID As String, ByVal AccessDate As DateTime) As DataTable
        Dim name() As String = {"@TimeDate", "@Employee_ID"}
        Dim oj() As Object = {AccessDate, Employee_ID}
        Return kncsdl.Select_("AGiang_LayThongTinCaChinhCuaNhanVienTrongNgay", name, oj, 2)
    End Function
    Public Function AGiang_Select_Timekeeping_Date1_ByEm_Date(ByVal Employee_ID As String, ByVal OT_date_BatDau As DateTime, ByVal OT_date_KetThuc As DateTime) As DataTable
        Try
            Dim name() As String = {"@Employee_ID", "@OT_date_BatDau", "@OT_date_KetThuc"}
            Dim oj() As Object = {Employee_ID, OT_date_BatDau, OT_date_KetThuc}
            Return kncsdl.Select_("AGiang_Select_Timekeeping_Date1_ByEm_Date", name, oj, 3)
        Catch ex As Exception
        End Try
    End Function

    Public Function LayThoiGianCuaCaChinh(ByVal ShiftName As String) As DataTable
        Try
            Dim name() As String = {"@ShiftName"}
            Dim oj() As Object = {ShiftName}
            Return kncsdl.Select_("AGiang_LayThoiGianCuaCaChinh", name, oj, 1)
        Catch ex As Exception
        End Try
    End Function

    Public Function LayThoiGianTangCa(ByVal Employee_ID As String, ByVal OT_Date As DateTime) As DataTable
        Dim name() As String = {"@Employee_ID", "@OT_Date"}
        Dim oj() As Object = {Employee_ID, OT_Date}
        Return kncsdl.Select_("AGiang_LayThoiGianTangCaTrongNgayCuaMotNhanVien", name, oj, 2)
    End Function

    Public Function LayThongTinNghiPhep(ByVal DateLeave As DateTime, ByVal Employee_ID As String) As DataTable
        Dim name() As String = {"@DateLeave", "@Employee_ID"}
        Dim oj() As Object = {DateLeave, Employee_ID}
        Return kncsdl.Select_("AGiang_LayThongTinNghiPhepTrongNgay", name, oj, 2)
    End Function

    Public Function LayCheDoThaiSan(ByVal Employee_ID As String) As DataTable
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Return kncsdl.Select_("AGiang_LayThongTinDangKyThaiSan", name, oj, 1)
    End Function
    Public Function LayCheDoNghiSinh(ByVal Employee_ID As String) As DataTable
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Return kncsdl.Select_("AGiang_LayThongTinDangKyNghiSinh", name, oj, 1)
    End Function
    Public Function HolidaysPlan_select_ByH_date(ByVal H_date As DateTime) As DataTable
        Dim name() As String = {"@H_date"}
        Dim oj() As Object = {H_date}
        Return kncsdl.Select_("AGiang_select_HolidaysPlan_ByH_date", name, oj, 1)
    End Function

    Public Function LayThongTinTroCapConNho(ByVal Employee_ID As String) As DataTable
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Return kncsdl.Select_("AGiang_LayThongTinTroCapConNho", name, oj, 1)
    End Function

    Public Function LayNhanVienActive() As DataTable
        Return kncsdl.Select_("AGiang_LayNhanVienDangActive")
    End Function

End Class
