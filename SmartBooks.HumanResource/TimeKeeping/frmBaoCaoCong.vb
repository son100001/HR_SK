Imports Appsettings
Imports SmartBooks.BusinessLogic
 
Imports VBReport
Imports Microsoft.Office
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Entity
Imports Excel1 = Microsoft.Office.Interop.Excel
Imports System.IO
Public Class frmBaoCaoCong
    Dim str_UrlSave, str_Loc As String
    Dim strmang_LoaiCong(), strmang_TenMaCong() As String
    Public thread As System.Threading.Thread
    Dim tab_GioLamTheoThang As DataTable
    Dim FD, TD As DateTime
    Private Sub frmBaoCaoCong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGiaoDienTheoDieuKien()
        Search()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Search()
        FD = New DateTime(CInt(para_Year.Text), CInt(para_Month.Text), 1)
        TD = FD.AddMonths(1).AddDays(-1)
        HRFORM_QueryView = "select [Employee_ID],[Employee_Firstname],[Employee_LastName],Employee_Status,[StartedDate],[ComStartedDate],Factory_ID,DepartmentCode,SectionCode,TeamCode,position,[Position_ID],[PositionCategory_ID],[ChucDanh],[BirthDate][Sex] from udf_EmployeeFilter('" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "',NULL,'" + TD.ToString("yyyy-MM-dd") + "') where employee_id in (select distinct Employee_ID from hr_wtdaily where ngay between '" + FD.ToString("yyyy-MM-dd") + "' and '" + TD.ToString("yyyy-MM-dd") + "')"
        Xem(HRFORM_QueryView, False, HRFORM_GridControl, HRFORM_Gridview)
    End Sub
    Public Overrides Sub ExecSubOrFunctionOfVB()
        If ReportRow("ReportCode") = "PhieuCong" Then
            FD = New DateTime(CInt(para_Year.Text), CInt(para_Month.Text), 1)
            TD = FD.AddMonths(1).AddDays(-1)
            Dim frmLoaiCong As New para_BangLoaiGioCong
            frmLoaiCong.ShowDialog()
            If IsNothing(frmLoaiCong.Get_MangLoaiCong) Then
                Exit Sub
            End If
            strmang_LoaiCong = frmLoaiCong.Get_MangLoaiCong
            strmang_TenMaCong = frmLoaiCong.Get_MangTenCong
            Dim fileChooser As SaveFileDialog = New SaveFileDialog
            fileChooser.FileName = "PhieuCong" + para_Month.Text + para_Year.Text + ".xls"
            Dim result As DialogResult
            fileChooser.DefaultExt = "xls"
            result = fileChooser.ShowDialog()
            str_UrlSave = fileChooser.FileName
            'fileChooser.CheckFileExists = False
            If result = DialogResult.OK Then
                'If File.Exists(str_UrlSave) Then
                '    File.Delete(str_UrlSave)
                'End If
                PhieuCong()
            End If
        End If
    End Sub
    Private Sub PhieuCong()
        'ProgressBar1.Visible = True
        'Dim MaCongTy As String = tvcn.MaCongTy
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ", "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ", "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LI", "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LQ", "LR", "LS", "LT", "LU", "LV", "LW", "LX", "LY", "LZ", "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MI", "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ"}
        Dim index As Integer = 13
        Cursor = Cursors.WaitCursor
        Dim Xls As New XlsReport
        Dim urlTemplate As String = Application.StartupPath() + "\Teamleate\PhieuCong.xls"
        Dim urlOut As String
        Dim rowmang_Cong(), row As DataRow
        Dim int_index As Integer
        urlOut = str_UrlSave 'fileChooser.FileName()
        Xls.FileName = urlTemplate
        Xls.Start.File()
        Xls.Page.Begin("Sheet1", "1")
        Xls.Page.Name = "Sheet1"
        Dim int_ThongTinChung, int_CotExcel, int_CachDongGiuaHaiPhieuCong, int_DongBatDauPhieuCong, int_Copy, int_DongBatDauGhi As Integer
        int_ThongTinChung = 8
        int_CotExcel = 8
        int_index = 0
        int_DongBatDauPhieuCong = 1
        int_CachDongGiuaHaiPhieuCong = Xls.Cell("A2").Value
        int_Copy = 0
        int_DongBatDauGhi = index
        Dim dt_index As DateTime = FD
        Dim rowgrid As DataRow
        'TẠO FORM
        Xls.Cell("D5").Value = "Từ ngày " + FD.ToString("dd/MM/yyyy") + " đến ngày " + TD.ToString("dd/MM/yyyy")
        For Each s As String In strmang_TenMaCong
            Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineTop = xlLineStyle.lsNormal
            Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineRight = xlLineStyle.lsNormal
            Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineBottom = xlLineStyle.lsNormal
            Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineRight = xlLineStyle.lsNormal
            Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineBottom = xlLineStyle.lsNormal
            Xls.Cell(ColExel(int_CotExcel) + "11").Value = s
            Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineRight = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineBottom = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineRight = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineBottom = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineRight = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineBottom = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineRight = xlLineStyle.lsDot
            Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineBottom = xlLineStyle.lsDot
            int_CotExcel += 1
        Next
        Xls.Cell(ColExel(int_CotExcel) + "11").Value = "Giờ nghỉ"
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineTop = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineBottom = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineBottom = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineBottom = xlLineStyle.lsDot
        int_CotExcel += 1
        Xls.Cell(ColExel(int_CotExcel) + "11").Value = "Loại nghỉ"
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineTop = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineBottom = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineBottom = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineBottom = xlLineStyle.lsDot
        int_CotExcel += 1
        Xls.Cell(ColExel(int_CotExcel) + "11").Value = "Ghi chú"
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineTop = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "11").Attr.LineBottom = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "12").Attr.LineBottom = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineBottom = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineRight = xlLineStyle.lsDot
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineBottom = xlLineStyle.lsDot

        Xls.Cell(ColExel(int_CotExcel) + "13").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "14").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "15").Attr.LineRight = xlLineStyle.lsNormal
        Xls.Cell(ColExel(int_CotExcel) + "16").Attr.LineRight = xlLineStyle.lsNormal
        While DateTime.Compare(dt_index, TD) <= 0
            Xls.RowCopy(index + int_index + 1)
            Xls.RowPaste(index + int_index + 2)
            Xls.Cell("B" + (index + int_index).ToString).Value = int_index + 1
            Xls.Cell("C" + (index + int_index).ToString).Value = dt_index.ToString("dd/MM/yyyy")
            Xls.Cell("H" + (index + int_index).ToString).Value = "=SUM(I" + (index + int_index).ToString + ":" + ColExel(int_CotExcel - 3) + (index + int_index).ToString + ")"
            If dt_index.DayOfWeek = DayOfWeek.Sunday Then
                For i As Integer = 1 To int_ThongTinChung + strmang_LoaiCong.Length + 2 '2 là Loại nghỉ và ghi chú.
                    Xls.Cell(ColExel(i) + (index + int_index).ToString).Attr.BackColor = xlColor.xcYellow
                Next
            End If
            dt_index = dt_index.AddDays(1)
            int_index += 1
        End While
        Xls.RowDelete(index + int_index)
        Xls.RowDelete(index + int_index)
        Xls.Cell("C" + (index + int_index).ToString).Value = "Tổng cộng"
        Xls.Cell("C" + (index + int_index).ToString).Attr.FontStyle = xlFontStyle.xsBold
        Xls.Cell("H" + (index + int_index).ToString).Value = "=SUM(H13:H" + (index + int_index - 1).ToString + ")"
        For i As Integer = 0 To strmang_LoaiCong.Length
            Xls.Cell(ColExel(int_ThongTinChung + i) + (index + int_index).ToString).Value = "=SUM(" + ColExel(int_ThongTinChung + i) + "13:" + ColExel(int_ThongTinChung + i) + (index + int_index - 1).ToString + ")"
        Next
        For i As Integer = 1 To int_CotExcel
            Xls.Cell(ColExel(i) + (index + int_index).ToString).Attr.LineBottom = xlLineStyle.lsNormal
        Next
        Xls.Cell("C" + (index + int_index + 2).ToString).Value = "Ngày lập:" + Today.ToString("dd/MM/yyyy")
        Xls.Cell("C" + (index + int_index + 3).ToString).Value = "Người lập"
        'Xls.Cell("C" + (index + int_index + 6).ToString).Value = tvcn.GetFullNameOfUser(obj.UserLogin)
        Xls.Cell("J" + (index + int_index + 2).ToString).Value = "Chữ ký xác nhận của công nhân:"
        'COPY FORM
        ' Set Minimum to 1 to represent the first file being copied.
        'ProgressBar1.Minimum = 0
        ' Set Maximum to the total number of files to copy.
        'ProgressBar1.Maximum = index + DateDiff(DateInterval.Day, FD, TD) + int_CachDongGiuaHaiPhieuCong
        ' Set the initial value of the ProgressBar.
        'ProgressBar1.Value = 0
        For i As Integer = 1 To index + DateDiff(DateInterval.Day, FD, TD) + int_CachDongGiuaHaiPhieuCong
            'ProgressBar1.Value += 1
            Xls.RowCopy(i)
            int_Copy = index + DateDiff(DateInterval.Day, FD, TD) + int_CachDongGiuaHaiPhieuCong
            For j As Integer = 0 To HRFORM_Gridview.SelectedRowsCount - 2
                Xls.RowPaste(int_Copy + i)
                int_Copy += index + DateDiff(DateInterval.Day, FD, TD) + int_CachDongGiuaHaiPhieuCong
            Next
        Next
        'ĐIỀN GIÁ TRỊ
        Dim rowdatamang(), rowCong As DataRow
        Dim tab_BangCong As DataTable ' = kn.ReadData("sp_TongHopCongTheoKhoangThoiGian '" + str_Fromdate + "','" + str_ToDate + "'", "BangCong")
        Dim tab_BangLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "HR_LoaiCong")
        Dim str_PhanTram As String
        ' Set Minimum to 1 to represent the first file being copied.
        'ProgressBar1.Minimum = 0
        ' Set Maximum to the total number of files to copy.
        'ProgressBar1.Maximum = HRFORM_Gridex.GetCheckedRows.Length
        ' Set the initial value of the ProgressBar.
        'ProgressBar1.Value = 0
        For r As Integer = 0 To HRFORM_Gridview.RowCount - 1
            rowgrid = HRFORM_Gridview.GetDataRow(r)
            'ProgressBar1.Value += 1
            tab_BangCong = kn.ReadData("sp_BangCong '" + FD.ToString("yyyy-MM-dd") + "','" + TD.ToString("yyyy-MM-dd") + "',17,'" + obj.Lan + "'," + "N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "','" + obj.PARA_POSITIONCATEGORY_ID + "','" + rowgrid.Item("Employee_ID").Value + "',null", "BangCong")
            If tab_BangCong.Rows.Count > 0 Then
                rowdatamang = tab_BangCong.Select()
                If Not IsDBNull(rowgrid.Item("Employee_LastName").Value) Then
                    Xls.Cell("D" + (index - 6).ToString).Value = rowgrid.Item("Employee_Firstname").Value + " " + rowgrid.Item("Employee_LastName").Value
                Else
                    Xls.Cell("D" + (index - 6).ToString).Value = rowgrid.Item("Employee_Firstname").Value
                End If
                If Not IsDBNull(rowgrid.Item("Card_Code").Value) Then
                    Xls.Cell("D" + (index - 5).ToString).Value = rowgrid.Item("Card_Code").Value
                End If
                Xls.Cell("D" + (index - 4).ToString).Value = rowgrid.Item("Employee_ID").Value
                If Not IsDBNull(rowgrid.Item("StartedDate").Value) Then
                    Xls.Cell("J" + (index - 6).ToString).Value = rowgrid.Item("StartedDate").Value
                End If
                If Not IsDBNull(rowgrid.Item("Position_ID").Value) Then
                    Xls.Cell("J" + (index - 5).ToString).Value = rowgrid.Item("Position_ID").Value
                End If
                If Not IsDBNull(rowgrid.Item("BirthDate").Value) Then
                    Xls.Cell("J" + (index - 4).ToString).Value = rowgrid.Item("BirthDate").Value
                End If
                For Each rowCong In rowdatamang
                    int_index = int_ThongTinChung
                    For Each s As String In strmang_LoaiCong
                        Xls.Cell(ColExel(int_index) + index.ToString).Value = rowCong(tab_BangLoaiCong.Select("macong='" + s + "'")(0)("macong"))
                        int_index += 1
                    Next
                    If Not IsDBNull(rowCong("RealTimeIn")) Then
                        Xls.Cell("D" + index.ToString).Value = rowCong("RealTimeIn")
                    End If
                    If Not IsDBNull(rowCong("RealTimeOut")) Then
                        Xls.Cell("E" + index.ToString).Value = rowCong("RealTimeOut")
                    End If
                    If Not IsDBNull(rowCong("HourLeave")) Then
                        Xls.Cell(ColExel(int_index) + index.ToString).Value = rowCong("HourLeave")
                    End If
                    int_index += 1
                    Xls.Cell(ColExel(int_index) + index.ToString).Value = rowCong("AbsentSign")
                    index += 1
                Next
                Xls.Cell("A" + (index + int_CachDongGiuaHaiPhieuCong).ToString).Break = True
                index += int_CachDongGiuaHaiPhieuCong + int_DongBatDauGhi - 1
            End If
        Next
        'ProgressBar1.Visible = False
        Xls.Page.End()
        Xls.Out.File(urlOut)
        tvcn.SaveFileExcel(urlOut)
        ''Open File
        Dim ps As New ProcessStartInfo
        ps.UseShellExecute = True
        ps.FileName = urlOut
        Process.Start(ps)
        Cursor = Cursors.Default
    End Sub
End Class