Imports Appsettings
Imports VBReport
Imports SmartBooks.BusinessLogic
Imports Excel1 = Microsoft.Office.Interop.Excel
Imports System.Drawing
Public Class frmShow
    Inherits System.Windows.Forms.Form
    Dim timekeeping As Giang_TimeKeeping = New Giang_TimeKeeping
    Dim dbdata As DBData = New DBData
    Dim LamTronGioXuong, LamTronGioLen As Double
    Dim tvcn As New ThuVienChucNang
    Dim startTime As DateTime
    Private obj As New Appsettings.DbSetting
    Private dataman As New BusinessLogic.DbAccess
    Dim appOption As New Appsettings.HROption
    Dim kn As New connect(DbSetting.dataPath)
    Public TKD_wtType As Integer
    Public TKD_Fromdate As DateTime
    Public TKD_Todate As DateTime
    Public TKD_Dept As String
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Public TKD_FilePathWT As String
    'Public thread As System.Threading.Thread
    'Dim thread2 As System.Threading.Thread
    'Dim thread3 As System.Threading.Thread



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
        ' aForm = Nothing
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(1, 2)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ProgressBarControl1.Properties.Step = 1
        Me.ProgressBarControl1.Size = New System.Drawing.Size(469, 23)
        Me.ProgressBarControl1.TabIndex = 20
        '
        'btnCancel
        '
        Me.btnCancel.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.cancel_16x161
        Me.btnCancel.Location = New System.Drawing.Point(396, 50)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 24)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        '
        'frmShow
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Aqua
        Me.ClientSize = New System.Drawing.Size(472, 86)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmShow"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Progress"
        'thread = New System.Threading.Thread(AddressOf XuatBangCong)
        'thread.Start()
    End Sub
    Private Sub XuatBangCong()
        Dim PhanTramLuongCoBan As DataTable = kn.ReadData("select distinct [Percent] from ((select distinct [Percent] from dbo.SmartBooks_TimeKeeping_Date) union (select distinct [Percent] from dbo.HR_ThemGioCong_TruongHopNgoaiLe)) per order by [Percent] asc", "PhanTramLuongCoBan")
        Dim row, row1, row2 As DataRow
        Dim numberColExcel As Integer = 34 + PhanTramLuongCoBan.Rows.Count
        Dim GioNghi As Double
        Dim mangrow As DataRow()
        Dim CongNhanVienTheoNgay() As DataRow
        Dim NghiPhepNhanVienTheoNgay() As DataRow
        Dim StartDate As New Date(TKD_Fromdate.Year, TKD_Fromdate.Month, 1)
        Dim EndDate As Date = StartDate.AddMonths(1).AddDays(-1)
        Dim StartDate_, EndDate_ As String
        StartDate_ = timekeeping.DateToString(StartDate)
        EndDate_ = timekeeping.DateToString(EndDate)
        Dim BangNghiPhep As DataTable = kn.ReadData("select * from HR_EmpRegisLeave where DateLeave between '" + StartDate_ + "' and '" + EndDate_ + "'", "BangNghiPhep")
        Dim BangCongExport As DataTable
        Dim BangTongHopPhepThang As DataTable = kn.ReadData("select * from [dbo].[udf_TongHopPhepThang]('" + StartDate_ + "', '" + EndDate_ + "')", "BangTongHopPhepThang")
        Dim urlTemplate As String
        Select Case TKD_wtType
            Case 0
                BangCongExport = kn.ReadData("select * from udf_ExportCong('" + StartDate_ + "','" + EndDate_ + "', '" + LamTronGioXuong.ToString + "', '" + LamTronGioLen.ToString + "') order by Employee_ID, [Percent] asc", "BangCongExport")
                urlTemplate = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay.xls"
            Case 1
                BangCongExport = kn.ReadData("select * from udf_ExportCong_AD('" + StartDate_ + "','" + EndDate_ + "', '" + LamTronGioXuong.ToString + "', '" + LamTronGioLen.ToString + "') order by Employee_ID, [Percent] asc", "BangCongExport")
                urlTemplate = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay_AD.xls"
        End Select
        If TKD_FilePathWT <> String.Empty Then
            Dim dtNhanVien As DataTable
            Select Case TKD_wtType
                Case 0
                    If TKD_Dept = "" Then
                        dtNhanVien = kn.ReadData("select * from SmartBooks_Employee where Employee_ID COLLATE DATABASE_DEFAULT in (select distinct Employee_ID from SmartBooks_TimeKeeping_Date where [OT_date] between '" + StartDate_ + "' and '" + EndDate_ + "' union select distinct Employee_ID from HR_ThemGioCong_TruongHopNgoaiLe where [DateAdd] between '" + StartDate_ + "' and '" + EndDate_ + "') order by DepartmentCode, StartedDate asc", "SmartBooks_Employee")
                    Else
                        dtNhanVien = kn.ReadData("select * from SmartBooks_Employee where DepartmentCode = '" + TKD_Dept + "' and Employee_ID COLLATE DATABASE_DEFAULT in (select distinct Employee_ID from SmartBooks_TimeKeeping_Date where [OT_date] between '" + StartDate_ + "' and '" + EndDate_ + "' union select distinct Employee_ID from HR_ThemGioCong_TruongHopNgoaiLe where [DateAdd] between '" + StartDate_ + "' and '" + EndDate_ + "') order by DepartmentCode, StartedDate asc", "SmartBooks_Employee")
                    End If
                Case 1
                    If TKD_Dept = "" Then
                        dtNhanVien = kn.ReadData("select * from SmartBooks_Employee where Employee_ID COLLATE DATABASE_DEFAULT in (select distinct Employee_ID from SmartBooks_TimeKeeping_Date_AD where [OT_date] between '" + StartDate_ + "' and '" + EndDate_ + "' union select distinct Employee_ID from HR_ThemGioCong_TruongHopNgoaiLe where [DateAdd] between '" + StartDate_ + "' and '" + EndDate_ + "') order by DepartmentCode, StartedDate asc", "SmartBooks_Employee")
                    Else
                        dtNhanVien = kn.ReadData("select * from SmartBooks_Employee where DepartmentCode = '" + TKD_Dept + "' and Employee_ID COLLATE DATABASE_DEFAULT in (select distinct Employee_ID from SmartBooks_TimeKeeping_Date_AD where [OT_date] between '" + StartDate_ + "' and '" + EndDate_ + "' union select distinct Employee_ID from HR_ThemGioCong_TruongHopNgoaiLe where [DateAdd] between '" + StartDate_ + "' and '" + EndDate_ + "') order by DepartmentCode, StartedDate asc", "SmartBooks_Employee")
                    End If
            End Select
            Dim Xls As New XlsReport
            Dim index As Integer = 8
            'open file exel with control XlsReport
            Dim urlOut As String = TKD_FilePathWT
            Xls.FileName = urlTemplate '"URL TeamLeate"
            Xls.Start.File()
            Xls.Page.Begin("Teamlate", "1")
            Xls.Page.Name = "Teamlate"
            'end file exel with control XlsReport
            Select Case TKD_wtType
                Case 0
                    Xls.Cell("C3").Value = "BẢNG CHẤM CÔNG THÁNG " + StartDate.Month.ToString() + "/" + StartDate.Year.ToString
                Case 1
                    Xls.Cell("C3").Value = "BẢNG CHẤM CÔNG AD THÁNG " + StartDate.Month.ToString() + "/" + StartDate.Year.ToString
            End Select
            Dim join, LoaiNghi As String
            Dim stt As Integer = 1
            Dim i, j As Integer
            Dim StartedDate As DateTime
            Dim TimeIn, XRNTimeIn As DateTime
            Dim TimeOut, XRNTimeOut As DateTime
            Dim XinRaNgoai As DataTable
            Dim rowNhanVienXinRaNgoai As DataRow
            Dim ColExel() As String = {"H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH"}
            Dim starD As DateTime
            Dim EndD As DateTime
            Dim b As Boolean
            i = 2
            j = 31
            For Each row1 In PhanTramLuongCoBan.Rows
                Xls.Cell(ColExel(j) + "7").Value = "Tổng giờ " + CStr(row1("Percent")) + "%"
                Xls.Cell(ColExel(j) + "6").Value = CType(row1("Percent"), Decimal)
                j += 1
                i += 1
            Next
            'Xls.Cell(ColExel(j) + "7").Value = "TỔNG GIỜ CÔNG"
            Xls.Cell(ColExel(j) + "7").Value = "TỔNG NGHỈ ĐƯỢC HƯỞNG LƯƠNG"
            Xls.Cell(ColExel(j + 1) + "7").Value = "TỔNG NGHỈ KHÔNG PHÉP"
            Xls.Cell(ColExel(j + 2) + "7").Value = "CHỮ KÝ"
            ProgressBarControl1.Properties.Minimum = 1
            ProgressBarControl1.Properties.Maximum = dtNhanVien.Rows.Count
            Dim progress As Integer = 1
            Dim percent As Integer
            For Each row In dtNhanVien.Rows
                'percent = CInt((CDbl(UltraProgressBar1.Value - UltraProgressBar1.Minimum) / CDbl(UltraProgressBar1.Maximum - UltraProgressBar1.Minimum)) * 100)
                ProgressBarControl1.EditValue = progress
                ProgressBarControl1.Refresh()
                progress += 1
                'gr.DrawString(percent.ToString() + "%", _
                'New System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Regular), _
                'Brushes.Black, _
                'New PointF(ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", New System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Regular)).Width / 2.0F), _
                'ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", New System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Regular)).Height / 2.0F)))

                starD = StartDate
                EndD = StartDate.AddMonths(1).AddDays(-1)
                b = False
                StartedDate = row.Item("StartedDate")
                While (DateTime.Compare(starD, EndD) <= 0)
                    CongNhanVienTheoNgay = BangCongExport.Select("Employee_ID = '" + row.Item("Employee_ID") + "' and OT_date = '" + timekeeping.DateToString(starD) + "'", "Percent")
                    If timekeeping.isHoliday(starD) Then
                        For i = 0 To 2 + PhanTramLuongCoBan.Rows.Count
                            Xls.Cell(ColExel(starD.Day - 1) + (index + i).ToString).Attr.BackColor = xlColor.xcPink
                        Next
                    ElseIf starD.DayOfWeek.ToString = "Sunday" Then
                        For i = 0 To 2 + PhanTramLuongCoBan.Rows.Count
                            Xls.Cell(ColExel(starD.Day - 1) + (index + i).ToString).Attr.BackColor = xlColor.xcYellow
                        Next
                    End If
                    If CongNhanVienTheoNgay.Length > 0 Then
                        TimeIn = New DateTime(1754, 1, 1, 0, 0, 0)
                        TimeOut = New DateTime(1754, 1, 1, 0, 0, 0)
                        If Not IsDBNull(CongNhanVienTheoNgay(0).Item("TimeIn")) Then
                            TimeIn = CongNhanVienTheoNgay(0).Item("TimeIn")
                            If TimeIn.Hour <> 0 Or TimeIn.Minute <> 0 Then
                                Xls.Cell(ColExel(starD.Day - 1) + index.ToString).Value = TimeIn.ToString("HH:mm")
                            End If
                        End If
                        If Not IsDBNull(CongNhanVienTheoNgay(0).Item("TimeOut")) Then
                            TimeOut = CongNhanVienTheoNgay(0).Item("TimeOut")
                            If TimeOut.Hour <> 0 Or TimeOut.Minute <> 0 Then
                                Xls.Cell(ColExel(starD.Day - 1) + (index + 1).ToString).Value = TimeOut.ToString("HH:mm")
                            End If
                        End If
                        If (TimeIn.Year <> 1754 And TimeOut.Year <> 1754) And TimeIn.ToString("HH:mm").Trim.ToUpper = TimeOut.ToString("HH:mm").Trim.ToUpper Then
                            Xls.Cell(ColExel(starD.Day - 1) + index.ToString).Attr.BackColor = xlColor.xcYellow
                            Xls.Cell(ColExel(starD.Day - 1) + (index + 1).ToString).Attr.BackColor = xlColor.xcYellow
                        End If
                        For Each row1 In CongNhanVienTheoNgay
                            i = 2
                            For Each row2 In PhanTramLuongCoBan.Rows
                                If row1("Percent") = row2("Percent") Then
                                    Xls.Cell(ColExel(starD.Day - 1) + (index + i).ToString).Value = CDbl(row1("WokingTime"))
                                End If
                                i += 1
                            Next
                        Next
                        Try
                            NghiPhepNhanVienTheoNgay = BangNghiPhep.Select("Employee_ID = '" + row.Item("Employee_ID") + "' and DateLeave = '" + timekeeping.DateToString(starD) + "'")
                            GioNghi = NghiPhepNhanVienTheoNgay(0).Item("HourLeave")
                        Catch ex As Exception
                            GioNghi = 0
                        End Try
                        If GioNghi = 8 Then
                            Xls.Cell(ColExel(starD.Day - 1) + (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString).Value = NghiPhepNhanVienTheoNgay(0).Item("LeaveType_ID")
                        ElseIf GioNghi > 0 Then
                            Xls.Cell(ColExel(starD.Day - 1) + (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString).Value = NghiPhepNhanVienTheoNgay(0).Item("LeaveType_ID") + "/" + Math.Round(8 / GioNghi, 3).ToString
                        End If
                        b = True
                    Else
                        Try
                            NghiPhepNhanVienTheoNgay = BangNghiPhep.Select("Employee_ID = '" + row.Item("Employee_ID") + "' and DateLeave = '" + timekeeping.DateToString(starD) + "'")
                            GioNghi = NghiPhepNhanVienTheoNgay(0).Item("HourLeave")
                        Catch ex As Exception
                            GioNghi = 0
                        End Try
                        If GioNghi = 8 Then
                            Xls.Cell(ColExel(starD.Day - 1) + (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString).Value = NghiPhepNhanVienTheoNgay(0).Item("LeaveType_ID")
                        ElseIf GioNghi > 0 Then
                            Xls.Cell(ColExel(starD.Day - 1) + (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString).Value = NghiPhepNhanVienTheoNgay(0).Item("LeaveType_ID") + "/" + Math.Round(8 / GioNghi, 3).ToString
                        End If
                    End If
                    starD = starD.AddDays(1)
                End While
                If b = True Then
                    Xls.Cell("G" + (index).ToString()).Value = "Giờ vào"
                    Xls.Cell("G" + (index + 1).ToString()).Value = "Giờ ra"
                    i = 2
                    j = 31
                    For Each row1 In PhanTramLuongCoBan.Rows
                        Xls.Cell("G" + (index + i).ToString()).Value = "Giờ " + CStr(row1("Percent")) + "%"
                        Xls.Cell(ColExel(j) + index.ToString).Value = "=SUM(H" + (index + i).ToString + ":AL" + (index + i).ToString + ")"
                        i += 1
                        j += 1
                    Next
                    Xls.Cell("G" + (index + i).ToString()).Value = "Loại nghỉ"
                    mangrow = BangTongHopPhepThang.Select("Employee_ID = '" + row.Item("Employee_ID") + "'")
                    Xls.Cell(ColExel(j) + index.ToString).Value = "=SUM(" + ColExel(31) + index.ToString + ":" + ColExel(30 + PhanTramLuongCoBan.Rows.Count) + index.ToString + ")"
                    If mangrow.Length > 0 Then
                        If Not IsDBNull(mangrow(0)("TongGioNghiPhepCTYTraLuong")) Then
                            Xls.Cell(ColExel(j) + index.ToString).Value = mangrow(0)("TongGioNghiPhepCTYTraLuong")
                        End If
                        If Not IsDBNull(mangrow(0)("TongGioNghiPhepCTYTraLuong")) Then
                            Xls.Cell(ColExel(j + 1) + index.ToString).Value = mangrow(0)("TongGioKhongPhep")
                        End If
                    End If
                    join = String.Format("A{0}:A{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    Xls.Cell("A" + index.ToString()).Value = stt.ToString
                    join = String.Format("B{0}:B{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    Xls.Cell("B" + index.ToString()).Value = row.Item("Employee_ID")
                    join = String.Format("C{0}:C{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    Xls.Cell("C" + index.ToString()).Value = StartedDate.ToString("dd/MM/yyyy")
                    join = String.Format("D{0}:D{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    If Not IsDBNull(row.Item("DepartmentCode")) Then
                        Xls.Cell("D" + index.ToString()).Value = CStr(row.Item("DepartmentCode"))
                    Else
                        Xls.Cell("D" + index.ToString()).Value = ""
                    End If
                    join = String.Format("D{0}:D{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    join = String.Format("E{0}:E{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    Xls.Cell("E" + index.ToString()).Value = row.Item("Employee_Firstname") + " " + row.Item("Employee_LastName")
                    Xls.Cell("F" + index.ToString()).Value = ""
                    join = String.Format("F{0}:F{1}", index.ToString, (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString)
                    Xls.Cell(join).Attr.Joint = True
                    Xls.Cell(join).Attr.LineBottom = VBReport.xlLineStyle.lsNormal
                    For k As Integer = 0 To numberColExcel - 1
                        Xls.Cell(ColExel(k) + (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString()).Attr.LineBottom = xlLineStyle.lsNormal
                    Next
                    Xls.Cell("G" + (index + 2 + PhanTramLuongCoBan.Rows.Count).ToString).Attr.LineBottom = xlLineStyle.lsNormal
                    stt = stt + 1
                    index = index + 3 + PhanTramLuongCoBan.Rows.Count
                End If
            Next
            Xls.Page.End()
            Xls.Out.File(urlOut)
            Dim ps As New ProcessStartInfo
            ps.UseShellExecute = True
            ps.FileName = urlOut
            Process.Start(ps)
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose(True)
    End Sub
End Class
