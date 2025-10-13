Imports Appsettings
Imports VBReport
Imports SmartBooks.BusinessLogic
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.IO
Public Class frmPBar
    Inherits System.Windows.Forms.Form
    Dim timekeeping As Giang_TimeKeeping = New Giang_TimeKeeping
    Private obj As New WindowsControlLibrary.DbSetting
    Dim dbdata As DBData = New DBData
    Dim tvcn As New WindowsControlLibrary.ThuVienChucNang
    Dim startTime As DateTime
    Private dataman As New BusinessLogic.DbAccess
    Dim kn As New connect(DbSetting.dataPath)
    'Khai báo lọc
    Public TKD_TinhCong_Loc As String
    'Khai báo xuất công
    Public TKD_XuatBangCong_wtType As Integer
    Public TKD_XuatBangCong_Fromdate As DateTime
    Public TKD_XuatBangCong_Todate As DateTime
    Public TKD_XuatBangCong_FilePathWT As String
    Public TKD_XuatBangCong_Loc As String
    Public TKD_XuatBangCong_XuatPDF As Boolean
    Public TKD_XuatBangCong_TragThaiNV As String
    Public TKD_XuatBangCong_In As Boolean
    Public TKD_XuatBangCong_DanhSachNhanVienSQL As String
    Public TKD_XuatBangCong_DanhSachLoaiCong As String()
    Public TKD_XuatBangCong_DanhSachTenCong As String()
    Public TKD_XuatBangCong_BangCong As String
    Public TKD_XuatBangCong_ViewShift As Boolean
    Public TKD_XuatBangCong_ViewLeave As Boolean
    Public TKD_XuatBangCong_ViewTimeInTimeOut As Boolean
    Public TKD_XuatBangCong_ViewPhieuCong As Boolean
    Public TKD_XuatBangCong_ViewDKTangCa As Boolean
    Public TKD_XuatBangCong_ViewLateIn As Boolean
    Public TKD_XuatBangPhep_LoaiSoSanh As String
    Public TKD_XuatBangPhep_GiaTriSoSanh As Double
    Public TKD_XuatBangPhep_DanhSachTenLoaiNghi() As String
    'Khai báo tính công
    Public TKD_TinhCong_Fromdate As DateTime
    Public TKD_TinhCong_Todate As DateTime
    Public TKD_TinhCong_DSNV As String
    Public TKD_TinhCong_MangDSNV As String()
    Public TKD_TinhCong_wtType As Integer
    Public TKD_TinhCong_Dept As String
    Public TKD_TinhCong_CachTinhCong As String
    'Lấy dữ liệu quẹt vân tay
    Public DLQVT_DiaChiLayDuLieuQuetVanTay As String
    Public DLQVT_TuNgay As DateTime
    Public DLQVT_DenNgay As DateTime
    Public DLQVT_CapNhatDuLieu As Boolean
    Public DLQVT_BangDuLieuQuet As String
    Public DLQVT_DanhSachTheTuSQL As String
    'Đổi mã nhân viên
    Public DMNV_FilePath As String
    'Nhập công ngoại lệ
    Public TKD_NhapCongNgoaiLe_FilePath As String

    Public FormKeyCall As String
    Public MaCongTy, progressname As String
    Public thread As System.Threading.Thread
    Public FACT, DEPT, SECT, TEAM, POS, POSC, EMPLOYEE_ID, CONFIGLINE, WRITELINE As String
    Friend WithEvents btnStop As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnStart As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl

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
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.btnStart = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStop = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Please wait ..."
        '
        'btnCancel
        '
        Me.btnCancel.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.cancel_16x16
        Me.btnCancel.Location = New System.Drawing.Point(396, 78)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 24)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "Cancel"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(1, 35)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ProgressBarControl1.Properties.Step = 1
        Me.ProgressBarControl1.Size = New System.Drawing.Size(469, 23)
        Me.ProgressBarControl1.TabIndex = 19
        '
        'btnStart
        '
        Me.btnStart.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.play_16x16
        Me.btnStart.Location = New System.Drawing.Point(326, 78)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(64, 24)
        Me.btnStart.TabIndex = 17
        Me.btnStart.Text = "Start"
        '
        'btnStop
        '
        Me.btnStop.ImageOptions.Image = Global.SmartBooks.HumanResource.My.Resources.Resources.stop_16x16
        Me.btnStop.Location = New System.Drawing.Point(256, 78)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(64, 24)
        Me.btnStop.TabIndex = 16
        Me.btnStop.Text = "Stop"
        '
        'frmPBar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 114)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmPBar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPBar"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmPBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckForIllegalCrossThreadCalls = False
        If progressname = String.Empty Or progressname = "" Then
            Me.Text = "Progress"
        Else
            Me.Text = progressname
        End If
        btnStart.Enabled = False
        If FormKeyCall = "TKD_XuatBangCong" Then
            thread = New System.Threading.Thread(AddressOf TKD_XuatBangCong)
            thread.Start()
        ElseIf FormKeyCall = "TKD_XuatBangCongSK1" Then
            thread = New System.Threading.Thread(AddressOf TKD_XuatBangCongSK1)
            thread.Start()
        ElseIf FormKeyCall = "TKD_XuatBangCongSK2" Then
            thread = New System.Threading.Thread(AddressOf TKD_XuatBangCongSK2)
            thread.Start()
        ElseIf FormKeyCall = "TKD_TinhCong" Then
            thread = New System.Threading.Thread(AddressOf TinhCong)
            thread.Start()
        ElseIf FormKeyCall = "DLQVT_LayDuLieuQuet" Then
            thread = New System.Threading.Thread(AddressOf LayDuLieuQuetVanTay)
            thread.Start()
        ElseIf FormKeyCall = "DOIMANHANVIEN" Then
            thread = New System.Threading.Thread(AddressOf DoiMaNhanVien)
            thread.Start()
        End If
    End Sub

    Private Sub DoiMaNhanVien()
        Dim urlTemplate As String = DMNV_FilePath
        Dim ColExel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"}
        Dim Xls As New XlsReport
        Xls.FileName = urlTemplate
        Xls.Start.File()
        Xls.Page.Begin("Sheet1", "1")
        Xls.Page.Name = "Sheet1"
        Dim index As Integer
        Dim Employee_IDOld, Employee_IDNew As String
        Dim sql As String
        Dim tab_BangChuaMaNhanVien As DataTable = kn.ReadData("exec sp_BangChuaMaNhanVien", "table")
        index = 7
        sql = String.Empty
        While CStr(Xls.Cell("B" + index.ToString).Value).Trim <> String.Empty
            Employee_IDOld = CStr(Xls.Cell("B" + index.ToString).Value).Trim
            Employee_IDNew = CStr(Xls.Cell("C" + index.ToString).Value).Trim
            If Employee_IDNew <> String.Empty Then
                sql += "update ##### set Employee_ID=N'" + Employee_IDNew + "' where Employee_ID=N'" + Employee_IDOld + "' "
            End If
            index += 1
        End While
        Dim progress As Integer = 1
        ProgressBarControl1.Properties.Minimum = 1
        ProgressBarControl1.Properties.Maximum = tab_BangChuaMaNhanVien.Rows.Count
        Dim sqlupdate As String
        For Each row As DataRow In tab_BangChuaMaNhanVien.Rows
            Me.Text = row("TableName")
            ProgressBarControl1.EditValue = progress
            ProgressBarControl1.Refresh()
            progress += 1
            sqlupdate = sql.Replace("#####", row("TableName"))
            If kn.SaveData(sqlupdate) = False Then
                MessageBox.Show(row("TableName"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Next
        Xls.Page.End()
        Xls.Out.File(urlTemplate)
        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Thuchienketthuc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub DoiMaNhanVien(ByVal EmployeeID_Old As String, ByVal EmployeeID_New As String)
        Dim tab_BangChuaMaNhanVien As DataTable = kn.ReadData("exec sp_BangChuaMaNhanVien", "table")
        Dim sql As String
        For Each row As DataRow In tab_BangChuaMaNhanVien.Rows
            sql = "update " + row("TableName") + " set Employee_ID=N'" + EmployeeID_New + "' where Employee_ID=N'" + EmployeeID_Old + "'"
            If kn.SaveData(sql) = False Then
                If MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + row("TableName"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub TinhCong()
        Me.Text = "Tính công"
        ProgressBarControl1.Visible = False
        If TKD_TinhCong_CachTinhCong = "0" Then
            If TKD_TinhCong_DSNV = String.Empty Then
                If kn.SaveData("exec [dbo].[sp_TinhCongTheoCap] '" + TKD_TinhCong_Fromdate.ToString("yyyy-MM-dd") + "','" + TKD_TinhCong_Todate.ToString("yyyy-MM-dd") + "',N'" + obj.UserName + "','" + DEPT + "','" + SECT + "','" + TEAM + "','" + POS + "','" + POSC + "'") = False Then
                    MessageBox.Show("Có lỗi trong quá trình tính công", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Dim strEmployee_ID As String() = TKD_TinhCong_DSNV.Split(",")
                For Each Employee_ID As String In strEmployee_ID
                    If kn.SaveData("exec [dbo].[sp_TinhCongTheoCap] '" + TKD_TinhCong_Fromdate.ToString("yyyy-MM-dd") + "','" + TKD_TinhCong_Todate.ToString("yyyy-MM-dd") + "',N'" + obj.UserName + "',null,null,null,null,null,N'" + Employee_ID + "'") = False Then
                        If MessageBox.Show("Có lỗi trong quá trình tính công của mã " + Employee_ID + ". Bạn có muốn tiếp tục thực hiện lệnh?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Me.Close()
                        End If
                    End If
                Next
            End If
            MessageBox.Show("Tính công kết thúc." + Now.ToString("dd/MM/yyyy HH:mm:ss"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If TKD_TinhCong_DSNV = String.Empty Then
                If kn.SaveData("exec [dbo].[sp_TinhCong] '" + TKD_TinhCong_Fromdate.ToString("yyyy-MM-dd") + "','" + TKD_TinhCong_Todate.ToString("yyyy-MM-dd") + "',N'" + obj.UserName + "','" + DEPT + "','" + SECT + "','" + TEAM + "','" + POS + "','" + POSC + "'") = False Then
                    MessageBox.Show("Có lỗi trong quá trình tính công", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Dim strEmployee_ID As String() = TKD_TinhCong_DSNV.Split(",")
                For Each Employee_ID As String In strEmployee_ID
                    If kn.SaveData("exec [dbo].[sp_TinhCong] '" + TKD_TinhCong_Fromdate.ToString("yyyy-MM-dd") + "','" + TKD_TinhCong_Todate.ToString("yyyy-MM-dd") + "',N'" + obj.UserName + "',null,null,null,null,null,N'" + Employee_ID + "'") = False Then
                        If MessageBox.Show("Có lỗi trong quá trình tính công của mã " + Employee_ID + ". Bạn có muốn tiếp tục thực hiện lệnh?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                            Me.Close()
                        End If
                    End If
                Next
            End If
            MessageBox.Show("Tính công kết thúc." + Now.ToString("dd/MM/yyyy HH:mm:ss"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Close()
    End Sub

    Private Sub LayDuLieuQuetVanTay()
        Dim FormDate, ToDate As String
        Dim bCheckGetData As Boolean = False
        Dim tbCheckInOut, tbCardCode As DataTable
        Dim row As DataRow
        Dim Employee_ID, AccessDate, AccessTime, CardCode, CardCodeName, CardCodeType, DanhSachMaNV, DanhSachTheTu, Device_ID, DeviceIP, InOutStatus As String
        Dim strAddress, strQuery, strQueryDelete, strListOfUser, strPassWord As String
        Dim bEmployeeIDIsCardNumber As Boolean
        Dim progress, result As Integer
        FormDate = PublicFunction.DateTimeToString(DLQVT_TuNgay)
        ToDate = PublicFunction.DateTimeToString(DLQVT_DenNgay)
        Dim FromDate_MayChamCong, ToDate_MayChamCong As String
        Dim tabMayChamCong As DataTable
        tabMayChamCong = kn.ReadData("select * from HR_MayChamCong where '" + obj.UserName + "' in (select Data from Split(ListOfUser,','))", "table")
        Dim bACCESS, bSQL As Boolean
        For Each r As DataRow In tabMayChamCong.Rows
            If Not IsDBNull(r("ListOfUser")) Then
                strListOfUser = r("ListOfUser").ToString.ToUpper
                If Split(strListOfUser, ",").IndexOf(Split(strListOfUser, ","), obj.UserName.ToUpper) >= 0 Then 'Kiểm tra quyền
                    If Not IsDBNull(r("Address")) And Not IsDBNull(r("Query")) Then 'Kiểm tra có tồn tại địa chỉ hoặc query
                        strQueryDelete = "exec sp_XoaDuLieuQuet '" + FormDate + "','" + ToDate + "',N'" + FACT + "',N'" + DEPT + "',N'" + SECT + "',N'" + TEAM + "',N'" + POS + "',N'" + POSC + "',N'" + TKD_XuatBangCong_DanhSachNhanVienSQL.Replace("'", "") + "',N'" + r("Code") + "'"
                        FromDate_MayChamCong = DLQVT_TuNgay.ToString(r("FormatDate"))
                        ToDate_MayChamCong = DLQVT_DenNgay.ToString(r("FormatDate"))
                        strQuery = r("Query")
                        strAddress = r("Address")
                        If Not IsDBNull(r("CardCodeName")) Then
                            CardCodeName = r("CardCodeName")
                        End If
                        If Not IsDBNull(r("CardCodeType")) Then
                            CardCodeType = r("CardCodeType")
                        End If
                        If TKD_XuatBangCong_DanhSachNhanVienSQL <> String.Empty Then
                            If CardCodeType.ToUpper = "INT" Then
                                DanhSachMaNV = TKD_XuatBangCong_DanhSachNhanVienSQL.Replace("'", "")
                            Else
                                DanhSachMaNV = TKD_XuatBangCong_DanhSachNhanVienSQL
                            End If
                        End If
                        If DLQVT_DanhSachTheTuSQL <> String.Empty Then
                            If CardCodeType.ToUpper = "INT" Then
                                DanhSachTheTu = DLQVT_DanhSachTheTuSQL.Replace("'", "")
                            Else
                                DanhSachTheTu = DLQVT_DanhSachTheTuSQL
                            End If
                        End If
                        If strQuery.Trim <> String.Empty And strAddress.Trim <> String.Empty Then
                            strQuery = strQuery.Replace("FROMDATE", FromDate_MayChamCong).Replace("TODATE", ToDate_MayChamCong)
                            If Not IsDBNull(r("isACCESS")) Then 'Kiểm tra nếu là file access
                                bACCESS = r("isACCESS")
                            End If
                            If Not IsDBNull(r("isSQL")) Then 'Kiểm tra nếu là kết nối SQL
                                bSQL = r("isSQL")
                            End If
                            If Not IsDBNull(r("PassWord_")) Then
                                strPassWord = r("PassWord_")
                            End If
                            bEmployeeIDIsCardNumber = False
                            If Not IsDBNull(r("EmployeeIDIsCardNumber")) Then
                                bEmployeeIDIsCardNumber = r("EmployeeIDIsCardNumber")
                            End If
                            If bEmployeeIDIsCardNumber = False Then
                                If DLQVT_DanhSachTheTuSQL <> String.Empty Then
                                    strQuery += " and " + CardCodeName + " IN (" + DanhSachTheTu + ")"
                                End If
                            Else
                                If TKD_XuatBangCong_DanhSachNhanVienSQL <> String.Empty Then
                                    strQuery += " and " + CardCodeName + " IN (" + DanhSachMaNV + ")"
                                End If
                            End If
                            If bACCESS = True Then
                                If IO.File.Exists(strAddress) Then
                                    kn.FILEACCESS = strAddress
                                    kn._passAccess = strPassWord
                                    tbCheckInOut = kn.ReadDataFormFile(strQuery, "table")
                                    If IsNothing(tbCheckInOut) Then
                                        Me.Close()
                                    End If
                                    If (tbCheckInOut.Rows.Count > 0) Then
                                        bCheckGetData = True
                                        If kn.SaveData(strQueryDelete) Then
                                        End If
                                        ProgressBarControl1.Properties.Minimum = 1
                                        ProgressBarControl1.Properties.Maximum = tbCheckInOut.Rows.Count
                                        progress = 1
                                        For Each row In tbCheckInOut.Rows
                                            ProgressBarControl1.EditValue = progress
                                            ProgressBarControl1.Refresh()
                                            progress += 1
                                            If Not IsDBNull(row("CardCode")) And Not IsDBNull(row("AccessDate")) And Not IsDBNull(row("AccessTime")) Then
                                                AccessDate = timekeeping.DateToString(row("AccessDate"))
                                                AccessTime = CDate(row("AccessTime")).ToString("yyyy-MM-dd HH:mm")
                                                CardCode = row("CardCode")
                                                If bEmployeeIDIsCardNumber = True Then
                                                    Employee_ID = row("CardCode")
                                                End If
                                                'If Not IsDBNull(row("InOutStatus")) Then
                                                '    InOutStatus = "'" + row("InOutStatus") + "'"
                                                'Else
                                                '    InOutStatus = "null"
                                                'End If
                                                strQuery = "INSERT INTO " + DLQVT_BangDuLieuQuet + " (Employee_ID,AccessDate,AccessTime,CardNumber,InsertSource,UserName,InsertDate) " &
                                                                     " VALUES(N'" + Employee_ID + "','" + AccessDate + "','" + AccessTime + "',N'" + CardCode + "',N'" + r("Code") + "', N'" + obj.UserName + "', '" + timekeeping.DateTimeToString(Now) + "') "
                                                If (kn.SaveDataNotReport(strQuery) = False) Then
                                                    'MessageBox.Show("Quá trình lấy dữ liệu có lỗi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                    'Exit For
                                                End If
                                            End If
                                        Next
                                    End If
                                Else
                                    result = MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + strAddress + ". " + tvcn.GetLanguagesTranslated("Popup.Bancomuontieptucthuchienkhong"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    If result = DialogResult.No Then
                                        Exit For
                                    End If
                                End If
                            ElseIf bSQL = True Then
                                Dim kn1 As New connect(strAddress)
                                tbCheckInOut = kn1.ReadData(strQuery, "table")
                                'MessageBox.Show(tbCheckInOut.Rows.Count.ToString)
                                If (tbCheckInOut.Rows.Count > 0) Then
                                    bCheckGetData = True
                                    If kn.SaveData(strQueryDelete) Then
                                    End If
                                    ProgressBarControl1.Properties.Minimum = 1
                                    ProgressBarControl1.Properties.Maximum = tbCheckInOut.Rows.Count
                                    progress = 1
                                    For Each row In tbCheckInOut.Rows
                                        ProgressBarControl1.EditValue = progress
                                        ProgressBarControl1.Refresh()
                                        progress += 1
                                        AccessDate = CDate(row("AccessDate")).ToString("yyyy-MM-dd")
                                        AccessTime = CDate(row("AccessTime")).ToString("yyyy-MM-dd HH:mm:ss")
                                        CardCode = row("CardCode")
                                        If Not IsDBNull(row("Device_ID")) Then
                                            Device_ID = row("Device_ID")
                                        End If
                                        If Not IsDBNull(row("DeviceIP")) Then
                                            DeviceIP = row("DeviceIP")
                                        End If
                                        If Not IsDBNull(row("InOutStatus")) Then
                                            InOutStatus = "'" + row("InOutStatus") + "'"
                                        Else
                                            InOutStatus = "null"
                                        End If
                                        If bEmployeeIDIsCardNumber = True Then
                                            Employee_ID = row("CardCode")
                                        End If
                                        strQuery = '"exec usp_InsertUpdateHR_TimeKeeping_Data1 null,N'" + Employee_ID + "','" + AccessDate + "','" + AccessTime + "',N'" + CardCode + "','" + Device_ID + "','" + DeviceIP + "'," + InOutStatus + ",'MayChamCong','','', N'" + obj.UserName + "', '" + timekeeping.DateTimeToString(Now) + "'"
                                        "INSERT INTO " + DLQVT_BangDuLieuQuet + " (Employee_ID,AccessDate,AccessTime,CardNumber,Device_ID,DeviceIP,InOutStatus,InsertSource,UserName,InsertDate) " &
                                             " VALUES(N'" + Employee_ID + "','" + AccessDate + "','" + AccessTime + "',N'" + CardCode + "','" + Device_ID + "','" + DeviceIP + "'," + InOutStatus + ",N'" + r("Code") + "', N'" + obj.UserName + "', '" + timekeeping.DateTimeToString(Now) + "') "
                                        kn.SaveDataNotReport(strQuery)
                                    Next
                                End If
                            End If
                        End If
                    End If
                    'Else
                    '    MessageBox.Show("Bạn không có quyền lấy dữ liệu!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Me.Close()
                End If
            End If
        Next
        If bCheckGetData = True Then
            If bEmployeeIDIsCardNumber <> True Then
                Me.Text = tvcn.GetLanguagesTranslated("Popup.Capnhatmanhanvien")
                If DLQVT_BangDuLieuQuet = "HR_TimeKeeping_Data" Then
                    kn.SaveData("ALTER INDEX ALL ON [dbo].[HR_TimeKeeping_Data] REBUILD")
                    If kn.SaveData("exec [dbo].[NhapMaNhanVienVaoBangDuLieuQuet1] '" + FormDate + "', '" + ToDate + "','" + obj.UserName + "'") = False Then
                        MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": " + tvcn.GetLanguagesTranslated("Popup.Capnhatmanhanvien"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    If kn.SaveData("exec [dbo].[NhapMaNhanVienVaoBangDuLieuQuet] '" + FormDate + "', '" + ToDate + "'") Then
                    End If
                End If
            End If
        End If
        'xóa dữ liệu quẹt đã duyệt xóa từ trước
        If kn.SaveData("exec sp_XoaDuLieuQuetDoNguoiDungDaChonXoa '" + timekeeping.DateToString(DLQVT_TuNgay) + "','" + timekeeping.DateToString(DLQVT_DenNgay) + "','" + obj.UserName + "'") = False Then
            MessageBox.Show(tvcn.GetLanguagesTranslated("Popup.Error") + ": XOADULIEUQUETDONGUOIDUNGCHONXOA", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Close()
    End Sub
    Public Sub TKD_XuatBangCong()
        Dim TemplateFile As String
        If TKD_XuatBangCong_ViewPhieuCong = True Then
            TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay_PhieuCong.xlsx"
        Else
            TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay.xlsx"
        End If
        Dim excel As New FileInfo(TemplateFile)

        Using package = New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim ColExcel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"}
            Dim SoCotThongTinChung As Integer = 13
            Dim SoDongQuetVaoRa, SoDongCa, SoDongPhep, SoDongLoaiCong, SoDongHeaderPhieuCong, SoDongCachNhauGiuaHaiPhieuCong, SoDongDKTangCa, SoDongMuon, CotBatDauDienThongTinLoc As Integer
            CotBatDauDienThongTinLoc = 64
            SoDongMuon = 0
            If TKD_XuatBangCong_ViewLateIn = True Then
                SoDongMuon = 1
            End If
            SoDongPhep = 0
            If TKD_XuatBangCong_ViewLeave = True Then
                SoDongPhep = 1
            End If
            SoDongCa = 0
            If TKD_XuatBangCong_ViewShift = True Then
                SoDongCa = 1
            End If
            SoDongQuetVaoRa = 0
            If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                SoDongQuetVaoRa = 2
            End If
            SoDongLoaiCong = 0
            If Not IsNothing(TKD_XuatBangCong_DanhSachLoaiCong) Then
                SoDongLoaiCong = TKD_XuatBangCong_DanhSachLoaiCong.Length
            End If
            SoDongDKTangCa = 0
            If TKD_XuatBangCong_ViewDKTangCa = True Then
                SoDongDKTangCa = 1
            End If
            SoDongHeaderPhieuCong = 0
            SoDongCachNhauGiuaHaiPhieuCong = 0
            If TKD_XuatBangCong_ViewPhieuCong = True Then
                SoDongHeaderPhieuCong = 1
                SoDongCachNhauGiuaHaiPhieuCong = 2
            End If
            Dim dnext As DateTime = obj.PARA_FROMDATE
            Dim inext As Integer = 0
            Dim TongPhepHuongLuong, TongPhepKhongLuong, TongNgayCong, TongNgayCongThucTe, PCAnToi, PCFood, TienCC, TienXX, TienConNho, LuongCB, PCTrachNhiem, TienCom, PCDienThoai, PhepNamDaSuDung, PhepNamConlai As Double
            Dim RowConfig, RowHeader, RowStart As Integer
            Dim rowCong As DataRow()
            Dim NgayCong As DateTime
            Dim TimeIn, TimeOut As DateTime
            RowConfig = 9
            RowHeader = 10
            RowStart = 12
            If TKD_XuatBangCong_ViewPhieuCong = False Then
                ws.Cells("A5").Value = ws.Cells("A5").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
            Else
                ws.Cells("A6").Value = ws.Cells("A6").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
            End If

            Dim join, join1 As String
            'Điền thông tin công ty
            Dim tabCompany As DataTable = kn.ReadData("select * from SmartBooks_Company", "table")
            If tabCompany.Rows.Count > 0 Then
                If Not IsDBNull(tabCompany.Rows(0)("company_name")) Then
                    ws.Cells("A1").Value = tabCompany.Rows(0)("company_name")
                End If
                If Not IsDBNull(tabCompany.Rows(0)("address_en")) Then
                    ws.Cells("A2").Value = "Địa chỉ: " + tabCompany.Rows(0)("address_en")
                End If
                If Not IsDBNull(tabCompany.Rows(0)("phone")) Then
                    ws.Cells("A2").Value = "Điện thoại:" + tabCompany.Rows(0)("phone")
                End If
            End If
            While dnext <= obj.PARA_TODATE
                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Value = dnext.Day.ToString
                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + (RowHeader - 1).ToString).Value = dnext
                If dnext.DayOfWeek = DayOfWeek.Sunday Then
                    ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.BackgroundColor.SetColor(Color.Red)
                End If
                dnext = dnext.AddDays(1)
                inext += 1
            End While
            Dim ColDelete As Integer = inext + 1
            While inext < 31
                ws.DeleteColumn(SoCotThongTinChung + ColDelete)
                inext += 1
            End While

            Dim tabLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "table")
            Dim tabLoaiPhep As DataTable = kn.ReadData("select * from SmartBooks_LeaveType", "table")
            Dim tabNhanVien As DataTable = kn.ReadData("exec [dbo].[sp_BangThongTinNhanVien] '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',12,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
            inext = RowStart
            Dim i, j, k, No As Integer
            Dim Config As String
            No = 1
            Dim BangCong As DataTable = kn.ReadData("exec sp_bangcong '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',26,N'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
            ProgressBarControl1.Properties.Minimum = 1
            ProgressBarControl1.Properties.Maximum = tabNhanVien.Rows.Count
            Dim progress As Integer = 1
            For Each row As DataRow In tabNhanVien.Rows
                ProgressBarControl1.EditValue = progress
                ProgressBarControl1.Refresh()
                progress += 1
                'Khởi tạo giá trị tổng của 1 nv
                TongPhepHuongLuong = 0
                TongPhepKhongLuong = 0
                TienCC = 0
                TienXX = 0
                TienConNho = 0
                LuongCB = 0
                PCTrachNhiem = 0
                TienCom = 0
                'Điền thông tin nhân viên
                For i = 0 To SoCotThongTinChung - 1
                    Config = ws.Cells(ColExcel(i) + RowConfig.ToString).Value
                    If Config <> String.Empty Then
                        For j = inext To inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon
                            If Config = "No" Then
                                ws.Cells(ColExcel(i) + j.ToString).Value = No
                            Else
                                ws.Cells(ColExcel(i) + j.ToString).Value = row(Config)
                                If TKD_XuatBangCong_ViewPhieuCong = True Then
                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + j.ToString).Value = row(Config)
                                    If j = inext Then
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 1).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 2).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 3).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 4).ToString).Value = row(Config)
                                        If inext = RowStart Then
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 5).ToString).Value = row(Config)
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 6).ToString).Value = row(Config)
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 7).ToString).Value = row(Config)
                                        End If
                                    ElseIf j = inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon Then
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j + 1).ToString).Value = row(Config)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                'Điền thông tin chung
                If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + inext.ToString).Value = "Quẹt vào"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + inext.ToString).Value = "HR_TimeKeeping_Data"
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + 1).ToString).Value = "Quẹt ra"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + 1).ToString).Value = "HR_TimeKeeping_Data"
                End If
                If TKD_XuatBangCong_ViewLateIn = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa).ToString).Value = "Muộn"
                End If
                For i = 0 To SoDongLoaiCong - 1
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachTenCong(i)
                    ws.Cells(ColExcel(SoCotThongTinChung - 2) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachLoaiCong(i)
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = "HR_WTDaily"
                Next
                If TKD_XuatBangCong_ViewDKTangCa = True Then
                    'ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Tăng ca thực tế"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "HR_MaxOvertime"
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Kế hoạch tăng ca"
                End If
                If TKD_XuatBangCong_ViewLeave = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Lý do nghỉ"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisLeave"
                End If
                If TKD_XuatBangCong_ViewShift = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Ca"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisTimeSheet"
                End If
                'Điền thông tin công
                rowCong = BangCong.Select("Employee_ID='" + row("Employee_ID") + "'")
                For Each rc As DataRow In rowCong
                    NgayCong = rc("Ngay")
                    For i = SoCotThongTinChung To SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)
                        Config = ws.Cells(ColExcel(i) + RowHeader.ToString).Value
                        If NgayCong.Day.ToString = Config Then
                            'ThucTeTCTheoNgay = 0
                            TongNgayCong = rc("TongNgayCong")
                            TongNgayCongThucTe = rc("TongNgayCongThucTe")
                            If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                                If Not IsDBNull(rc("RealTimeIn")) Then
                                    TimeIn = rc("RealTimeIn")
                                    ws.Cells(ColExcel(i) + inext.ToString).Value = New DateTime(TimeIn.Ticks).ToString("HH:mm")
                                End If
                                If Not IsDBNull(rc("RealTimeOut")) Then
                                    TimeOut = rc("RealTimeOut")
                                    ws.Cells(ColExcel(i) + (inext + 1).ToString).Value = New DateTime(TimeOut.Ticks).ToString("HH:mm")
                                End If
                            End If
                            If TKD_XuatBangCong_ViewLateIn = True Then
                                If Not IsDBNull(rc("LateIn")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa).ToString).Value = rc("LateIn")
                                End If
                            End If
                            For j = 0 To SoDongLoaiCong - 1
                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongMuon + j).ToString).Value = rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
                                'If tabLoaiCong.Select("MaCong='" + TKD_XuatBangCong_DanhSachLoaiCong(j) + "' and isOverTime=1").Length > 0 Then
                                '    If Not IsDBNull(rc(TKD_XuatBangCong_DanhSachLoaiCong(j))) Then
                                '        ThucTeTCTheoNgay += rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
                                '    End If
                                'End If
                            Next
                            If TKD_XuatBangCong_ViewDKTangCa = True Then
                                'If ThucTeTCTheoNgay > 0 Then
                                '    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = ThucTeTCTheoNgay
                                'End If
                                If Not IsDBNull(rc("maxovertime")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = rc("maxovertime")
                                End If
                            End If
                            TongPhepHuongLuong = rc("PhepHuongLuong")
                            TongPhepKhongLuong = rc("NghiKhongLuong")
                            LuongCB = rc("LuongCoDinh")
                            PCTrachNhiem = rc("TienTrachNhiem")
                            TienCom = rc("TienCaDem")
                            PCDienThoai = rc("TienDienThoai")
                            TienXX = rc("TienXX")
                            TienCC = rc("TienCC")
                            TienConNho = rc("TienConNho")
                            PhepNamDaSuDung = rc("PhepNam")
                            PhepNamConlai = rc("PhepNamConLai")
                            If Not IsDBNull(rc("AbsentSign")) Then
                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("AbsentSign")
                            End If
                            If TKD_XuatBangCong_ViewShift = True Then
                                If Not IsDBNull(rc("ShiftName")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("ShiftName")
                                End If
                            End If
                        End If
                    Next
                Next
                'Điền tổng hợp
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext).ToString).Formula = "=Round(SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + 1).ToString + ")/8,1)"
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 2) + (inext).ToString).Value = TongPhepHuongLuong
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 3) + (inext).ToString).Value = TongPhepKhongLuong
                For i = 0 To SoDongLoaiCong - 1
                    'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
                    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 4 + i) + (inext).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
                Next
                'If SoDongMuon > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa).ToString + ")"
                'End If
                'If SoDongDKTangCa > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ")"
                '    'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ")"
                'End If
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 12) + (inext).ToString).Value = LuongCB
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 13) + (inext).ToString).Value = PCTrachNhiem
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 14) + (inext).ToString).Value = TienCom
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 15) + (inext).ToString).Value = PCDienThoai
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 16) + (inext).ToString).Value = TienXX
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 17) + (inext).ToString).Value = TienCC
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 18) + (inext).ToString).Value = TienConNho
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 19) + (inext).ToString).Value = PhepNamDaSuDung
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + (inext).ToString).Value = PhepNamConlai

                'If SoDongLoaiCong > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1 + i) + inext.ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + SoDongLoaiCong) + inext.ToString + ")"
                'End If
                'Điền border
                join1 = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 1).ToString + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                join = String.Format(ColExcel(SoCotThongTinChung).ToString + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + "{0}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join1).Style.Border.Bottom.Style = ExcelBorderStyle.None
                ws.Cells(join1).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + "{1}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                'Tô màu ngày lễ
                Dim LoaiNgayCong As DataTable = kn.ReadData("select * from udf_NgayCongDacBietToanCongTy ('" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "')", "table")
                Dim NgayLe As DateTime
                For Each row1 As DataRow In LoaiNgayCong.Rows
                    NgayLe = row1("Ngay")
                    ws.Cells(ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.BackgroundColor.SetColor(Color.LightPink)
                Next
                'Kết thúc tô màu ngày lễ
                'Tô màu chủ nhật
                Dim dnext1 As DateTime = obj.PARA_FROMDATE
                Dim inext1 As Integer = 0
                While dnext1 <= obj.PARA_TODATE
                    If dnext1.DayOfWeek = DayOfWeek.Sunday Then
                        ws.Cells(ColExcel(SoCotThongTinChung + inext1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + inext1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                        ws.Cells(ColExcel(SoCotThongTinChung + inext1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + inext1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
                    End If
                    dnext1 = dnext1.AddDays(1)
                    inext1 += 1
                End While
                'BackColor trắng
                join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 2) + "{1}", (inext + 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join).Style.Font.Color.SetColor(Color.White)
                'Merge thông tin chung
                If TKD_XuatBangCong_ViewPhieuCong = True Then
                    For j = 0 To SoCotThongTinChung - 2
                        join = String.Format(ColExcel(j) + "{0}:" + ColExcel(j) + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString)
                        ws.Cells(join).Merge = True
                    Next
                End If
                No += 1
                inext += SoDongCa + SoDongPhep + SoDongQuetVaoRa + SoDongLoaiCong + SoDongHeaderPhieuCong + SoDongCachNhauGiuaHaiPhieuCong + SoDongMuon + SoDongDKTangCa
                If TKD_XuatBangCong_ViewPhieuCong = True Then 'copy thông tin chung của fieu lương như ghi chú, header
                    ws.Cells(5, 1, 5, ws.Dimension.End.Column).Copy(ws.Cells(inext - 1, 1, inext - 1, ws.Dimension.End.Column))
                    ws.Cells(6, 1, 6, ws.Dimension.End.Column).Copy(ws.Cells(inext, 1, inext, ws.Dimension.End.Column))
                    ws.Cells(RowHeader, 1, RowHeader, ws.Dimension.End.Column).Copy(ws.Cells(inext + 1, 1, inext + 1, ws.Dimension.End.Column))
                    inext += 2
                End If
            Next

            package.SaveAs(New FileInfo(TKD_XuatBangCong_FilePathWT))
            System.Diagnostics.Process.Start(TKD_XuatBangCong_FilePathWT)
        End Using
        Me.Close()
    End Sub
    Public Sub TKD_XuatBangCongSK2()
        Dim TemplateFile As String
        If TKD_XuatBangCong_ViewPhieuCong = True Then
            TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay_PhieuCong.xlsx"
        Else
            TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay.xlsx"
        End If
        Dim excel As New FileInfo(TemplateFile)

        Using package = New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim ColExcel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"}
            Dim SoCotThongTinChung As Integer = 13
            Dim SoDongQuetVaoRa, SoDongCa, SoDongPhep, SoDongLoaiCong, SoDongHeaderPhieuCong, SoDongCachNhauGiuaHaiPhieuCong, SoDongDKTangCa, SoDongMuon, CotBatDauDienThongTinLoc As Integer
            CotBatDauDienThongTinLoc = 64
            SoDongMuon = 0
            If TKD_XuatBangCong_ViewLateIn = True Then
                SoDongMuon = 1
            End If
            SoDongPhep = 0
            If TKD_XuatBangCong_ViewLeave = True Then
                SoDongPhep = 1
            End If
            SoDongCa = 0
            If TKD_XuatBangCong_ViewShift = True Then
                SoDongCa = 1
            End If
            SoDongQuetVaoRa = 0
            If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                SoDongQuetVaoRa = 2
            End If
            SoDongLoaiCong = 0
            If Not IsNothing(TKD_XuatBangCong_DanhSachLoaiCong) Then
                SoDongLoaiCong = TKD_XuatBangCong_DanhSachLoaiCong.Length
            End If
            SoDongDKTangCa = 0
            If TKD_XuatBangCong_ViewDKTangCa = True Then
                SoDongDKTangCa = 1
            End If
            SoDongHeaderPhieuCong = 0
            SoDongCachNhauGiuaHaiPhieuCong = 0
            If TKD_XuatBangCong_ViewPhieuCong = True Then
                SoDongHeaderPhieuCong = 1
                SoDongCachNhauGiuaHaiPhieuCong = 2
            End If
            Dim dnext As DateTime = obj.PARA_FROMDATE
            Dim inext As Integer = 0
            Dim TongPhepHuongLuong, TongPhepKhongLuong, TongNgayCong, TongNgayCongThucTe, PCAnToi, PCFood, TienCC, TienXX, TienConNho, LuongCB, PCTrachNhiem, TienCom, PCDienThoai, PhepNamDaSuDung, PhepNamConlai As Double
            Dim RowConfig, RowHeader, RowStart As Integer
            Dim rowCong As DataRow()
            Dim NgayCong As DateTime
            Dim TimeIn, TimeOut As DateTime
            RowConfig = 9
            RowHeader = 10
            RowStart = 12
            If TKD_XuatBangCong_ViewPhieuCong = False Then
                ws.Cells("A5").Value = ws.Cells("A5").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
            Else
                ws.Cells("A6").Value = ws.Cells("A6").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
            End If

            Dim join, join1 As String
            'Điền thông tin công ty
            Dim tabCompany As DataTable = kn.ReadData("select * from SmartBooks_Company", "table")
            If tabCompany.Rows.Count > 0 Then
                If Not IsDBNull(tabCompany.Rows(0)("company_name")) Then
                    ws.Cells("A1").Value = tabCompany.Rows(0)("company_name")
                End If
                If Not IsDBNull(tabCompany.Rows(0)("address_en")) Then
                    ws.Cells("A2").Value = "Địa chỉ: " + tabCompany.Rows(0)("address_en")
                End If
                If Not IsDBNull(tabCompany.Rows(0)("phone")) Then
                    ws.Cells("A2").Value = "Điện thoại:" + tabCompany.Rows(0)("phone")
                End If
            End If
            While dnext <= obj.PARA_TODATE
                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Value = dnext.Day.ToString
                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + (RowHeader - 1).ToString).Value = dnext
                If dnext.DayOfWeek = DayOfWeek.Sunday Then
                    ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.BackgroundColor.SetColor(Color.Red)
                End If
                dnext = dnext.AddDays(1)
                inext += 1
            End While
            Dim ColDelete As Integer = inext + 1
            While inext < 31
                ws.DeleteColumn(SoCotThongTinChung + ColDelete)
                inext += 1
            End While

            Dim tabLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "table")
            Dim tabLoaiPhep As DataTable = kn.ReadData("select * from SmartBooks_LeaveType", "table")
            Dim tabNhanVien As DataTable = kn.ReadData("exec [dbo].[sp_BangThongTinNhanVien] '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',12,'" + obj.Lan + "',N'SK2',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
            inext = RowStart
            Dim i, j, k, No As Integer
            Dim Config As String
            No = 1
            Dim BangCong As DataTable = kn.ReadData("exec sp_bangcong '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',27,N'" + obj.Lan + "',N'SK2',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
            ProgressBarControl1.Properties.Minimum = 1
            ProgressBarControl1.Properties.Maximum = tabNhanVien.Rows.Count
            Dim progress As Integer = 1
            For Each row As DataRow In tabNhanVien.Rows
                ProgressBarControl1.EditValue = progress
                ProgressBarControl1.Refresh()
                progress += 1
                'Khởi tạo giá trị tổng của 1 nv
                TongPhepHuongLuong = 0
                TongPhepKhongLuong = 0
                TienCC = 0
                TienXX = 0
                TienConNho = 0
                LuongCB = 0
                PCTrachNhiem = 0
                TienCom = 0
                'Điền thông tin nhân viên
                For i = 0 To SoCotThongTinChung - 1
                    Config = ws.Cells(ColExcel(i) + RowConfig.ToString).Value
                    If Config <> String.Empty Then
                        For j = inext To inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon
                            If Config = "No" Then
                                ws.Cells(ColExcel(i) + j.ToString).Value = No
                            Else
                                ws.Cells(ColExcel(i) + j.ToString).Value = row(Config)
                                If TKD_XuatBangCong_ViewPhieuCong = True Then
                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + j.ToString).Value = row(Config)
                                    If j = inext Then
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 1).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 2).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 3).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 4).ToString).Value = row(Config)
                                        If inext = RowStart Then
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 5).ToString).Value = row(Config)
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 6).ToString).Value = row(Config)
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 7).ToString).Value = row(Config)
                                        End If
                                    ElseIf j = inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon Then
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j + 1).ToString).Value = row(Config)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                'Điền thông tin chung
                If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + inext.ToString).Value = "Quẹt vào"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + inext.ToString).Value = "HR_TimeKeeping_Data"
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + 1).ToString).Value = "Quẹt ra"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + 1).ToString).Value = "HR_TimeKeeping_Data"
                End If
                If TKD_XuatBangCong_ViewLateIn = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa).ToString).Value = "Muộn"
                End If
                For i = 0 To SoDongLoaiCong - 1
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachTenCong(i)
                    ws.Cells(ColExcel(SoCotThongTinChung - 2) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachLoaiCong(i)
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = "HR_WTDaily"
                Next
                If TKD_XuatBangCong_ViewDKTangCa = True Then
                    'ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Tăng ca thực tế"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "HR_MaxOvertime"
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Kế hoạch tăng ca"
                End If
                If TKD_XuatBangCong_ViewLeave = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Lý do nghỉ"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisLeave"
                End If
                If TKD_XuatBangCong_ViewShift = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Ca"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisTimeSheet"
                End If
                'Điền thông tin công
                rowCong = BangCong.Select("Employee_ID='" + row("Employee_ID") + "'")
                For Each rc As DataRow In rowCong
                    NgayCong = rc("Ngay")
                    For i = SoCotThongTinChung To SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)
                        Config = ws.Cells(ColExcel(i) + RowHeader.ToString).Value
                        If NgayCong.Day.ToString = Config Then
                            'ThucTeTCTheoNgay = 0
                            TongNgayCong = rc("TongNgayCong")
                            TongNgayCongThucTe = rc("TongNgayCongThucTe")
                            If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                                If Not IsDBNull(rc("RealTimeIn")) Then
                                    TimeIn = rc("RealTimeIn")
                                    ws.Cells(ColExcel(i) + inext.ToString).Value = New DateTime(TimeIn.Ticks).ToString("HH:mm")
                                End If
                                If Not IsDBNull(rc("RealTimeOut")) Then
                                    TimeOut = rc("RealTimeOut")
                                    ws.Cells(ColExcel(i) + (inext + 1).ToString).Value = New DateTime(TimeOut.Ticks).ToString("HH:mm")
                                End If
                            End If
                            If TKD_XuatBangCong_ViewLateIn = True Then
                                If Not IsDBNull(rc("LateIn")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa).ToString).Value = rc("LateIn")
                                End If
                            End If
                            For j = 0 To SoDongLoaiCong - 1
                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongMuon + j).ToString).Value = rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
                                'If tabLoaiCong.Select("MaCong='" + TKD_XuatBangCong_DanhSachLoaiCong(j) + "' and isOverTime=1").Length > 0 Then
                                '    If Not IsDBNull(rc(TKD_XuatBangCong_DanhSachLoaiCong(j))) Then
                                '        ThucTeTCTheoNgay += rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
                                '    End If
                                'End If
                            Next
                            If TKD_XuatBangCong_ViewDKTangCa = True Then
                                'If ThucTeTCTheoNgay > 0 Then
                                '    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = ThucTeTCTheoNgay
                                'End If
                                If Not IsDBNull(rc("maxovertime")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = rc("maxovertime")
                                End If
                            End If
                            TongPhepHuongLuong = rc("PhepHuongLuong")
                            TongPhepKhongLuong = rc("NghiKhongLuong")
                            LuongCB = rc("LuongCoDinh")
                            PCTrachNhiem = rc("TienTrachNhiem")
                            TienCom = rc("TienCaDem")
                            PCDienThoai = rc("TienDienThoai")
                            TienXX = rc("TienXX")
                            TienCC = rc("TienCC")
                            TienConNho = rc("TienConNho")
                            PhepNamDaSuDung = rc("PhepNam")
                            PhepNamConlai = rc("PhepNamConLai")
                            If Not IsDBNull(rc("AbsentSign")) Then
                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("AbsentSign")
                            End If
                            If TKD_XuatBangCong_ViewShift = True Then
                                If Not IsDBNull(rc("ShiftName")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("ShiftName")
                                End If
                            End If
                        End If
                    Next
                Next
                'Điền tổng hợp
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext).ToString).Formula = "=Round(SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + 1).ToString + ")/8,1)"
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 2) + (inext).ToString).Value = TongPhepHuongLuong
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 3) + (inext).ToString).Value = TongPhepKhongLuong
                For i = 0 To SoDongLoaiCong - 1
                    'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
                    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 4 + i) + (inext).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
                Next
                'If SoDongMuon > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa).ToString + ")"
                'End If
                'If SoDongDKTangCa > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ")"
                '    'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ")"
                'End If
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 12) + (inext).ToString).Value = LuongCB
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 13) + (inext).ToString).Value = PCTrachNhiem
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 14) + (inext).ToString).Value = TienCom
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 15) + (inext).ToString).Value = PCDienThoai
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 16) + (inext).ToString).Value = TienXX
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 17) + (inext).ToString).Value = TienCC
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 18) + (inext).ToString).Value = TienConNho
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 19) + (inext).ToString).Value = PhepNamDaSuDung
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + (inext).ToString).Value = PhepNamConlai

                'If SoDongLoaiCong > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1 + i) + inext.ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + SoDongLoaiCong) + inext.ToString + ")"
                'End If
                'Điền border
                join1 = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 1).ToString + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                join = String.Format(ColExcel(SoCotThongTinChung).ToString + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + "{0}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join1).Style.Border.Bottom.Style = ExcelBorderStyle.None
                ws.Cells(join1).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + "{1}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                'Tô màu ngày lễ
                Dim LoaiNgayCong As DataTable = kn.ReadData("select * from udf_NgayCongDacBietToanCongTy ('" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "')", "table")
                Dim NgayLe As DateTime
                For Each row1 As DataRow In LoaiNgayCong.Rows
                    NgayLe = row1("Ngay")
                    ws.Cells(ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.BackgroundColor.SetColor(Color.LightPink)
                Next
                'Kết thúc tô màu ngày lễ
                'Tô màu chủ nhật
                Dim dnext1 As DateTime = obj.PARA_FROMDATE
                Dim inext1 As Integer = 0
                While dnext1 <= obj.PARA_TODATE
                    If dnext1.DayOfWeek = DayOfWeek.Sunday Then
                        ws.Cells(ColExcel(SoCotThongTinChung + inext1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + inext1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                        ws.Cells(ColExcel(SoCotThongTinChung + inext1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + inext1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
                    End If
                    dnext1 = dnext1.AddDays(1)
                    inext1 += 1
                End While
                'BackColor trắng
                join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 2) + "{1}", (inext + 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join).Style.Font.Color.SetColor(Color.White)
                'Merge thông tin chung
                If TKD_XuatBangCong_ViewPhieuCong = True Then
                    For j = 0 To SoCotThongTinChung - 2
                        join = String.Format(ColExcel(j) + "{0}:" + ColExcel(j) + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString)
                        ws.Cells(join).Merge = True
                    Next
                End If
                No += 1
                inext += SoDongCa + SoDongPhep + SoDongQuetVaoRa + SoDongLoaiCong + SoDongHeaderPhieuCong + SoDongCachNhauGiuaHaiPhieuCong + SoDongMuon + SoDongDKTangCa
                If TKD_XuatBangCong_ViewPhieuCong = True Then 'copy thông tin chung của fieu lương như ghi chú, header
                    ws.Cells(5, 1, 5, ws.Dimension.End.Column).Copy(ws.Cells(inext - 1, 1, inext - 1, ws.Dimension.End.Column))
                    ws.Cells(6, 1, 6, ws.Dimension.End.Column).Copy(ws.Cells(inext, 1, inext, ws.Dimension.End.Column))
                    ws.Cells(RowHeader, 1, RowHeader, ws.Dimension.End.Column).Copy(ws.Cells(inext + 1, 1, inext + 1, ws.Dimension.End.Column))
                    inext += 2
                End If
            Next

            package.SaveAs(New FileInfo(TKD_XuatBangCong_FilePathWT))
            System.Diagnostics.Process.Start(TKD_XuatBangCong_FilePathWT)
        End Using
        Me.Close()
    End Sub
    Public Sub TKD_XuatBangCongSK1()
        Dim TemplateFile As String
        If TKD_XuatBangCong_ViewPhieuCong = True Then
            TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay_PhieuCong.xlsx"
        Else
            TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay.xlsx"
        End If
        Dim excel As New FileInfo(TemplateFile)

        Using package = New ExcelPackage(excel)
            Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
            Dim ColExcel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"}
            Dim SoCotThongTinChung As Integer = 13
            Dim SoDongQuetVaoRa, SoDongCa, SoDongPhep, SoDongLoaiCong, SoDongHeaderPhieuCong, SoDongCachNhauGiuaHaiPhieuCong, SoDongDKTangCa, SoDongMuon, CotBatDauDienThongTinLoc As Integer
            CotBatDauDienThongTinLoc = 64
            SoDongMuon = 0
            If TKD_XuatBangCong_ViewLateIn = True Then
                SoDongMuon = 1
            End If
            SoDongPhep = 0
            If TKD_XuatBangCong_ViewLeave = True Then
                SoDongPhep = 1
            End If
            SoDongCa = 0
            If TKD_XuatBangCong_ViewShift = True Then
                SoDongCa = 1
            End If
            SoDongQuetVaoRa = 0
            If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                SoDongQuetVaoRa = 2
            End If
            SoDongLoaiCong = 0
            If Not IsNothing(TKD_XuatBangCong_DanhSachLoaiCong) Then
                SoDongLoaiCong = TKD_XuatBangCong_DanhSachLoaiCong.Length
            End If
            SoDongDKTangCa = 0
            If TKD_XuatBangCong_ViewDKTangCa = True Then
                SoDongDKTangCa = 1
            End If
            SoDongHeaderPhieuCong = 0
            SoDongCachNhauGiuaHaiPhieuCong = 0
            If TKD_XuatBangCong_ViewPhieuCong = True Then
                SoDongHeaderPhieuCong = 1
                SoDongCachNhauGiuaHaiPhieuCong = 2
            End If
            Dim dnext As DateTime = obj.PARA_FROMDATE
            Dim inext As Integer = 0
            Dim TongPhepHuongLuong, TongPhepKhongLuong, TongNgayCong, TongNgayCongThucTe, PCAnToi, PCFood, TienCC, TienXX, TienConNho, LuongCB, PCTrachNhiem, TienCom, PCDienThoai, PhepNamDaSuDung, PhepNamConlai As Double
            Dim RowConfig, RowHeader, RowStart As Integer
            Dim rowCong As DataRow()
            Dim NgayCong As DateTime
            Dim TimeIn, TimeOut As DateTime
            RowConfig = 9
            RowHeader = 10
            RowStart = 12
            If TKD_XuatBangCong_ViewPhieuCong = False Then
                ws.Cells("A5").Value = ws.Cells("A5").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
            Else
                ws.Cells("A6").Value = ws.Cells("A6").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
            End If

            Dim join, join1 As String
            'Điền thông tin công ty
            Dim tabCompany As DataTable = kn.ReadData("select * from SmartBooks_Company", "table")
            If tabCompany.Rows.Count > 0 Then
                If Not IsDBNull(tabCompany.Rows(0)("company_name")) Then
                    ws.Cells("A1").Value = tabCompany.Rows(0)("company_name")
                End If
                If Not IsDBNull(tabCompany.Rows(0)("address_en")) Then
                    ws.Cells("A2").Value = "Địa chỉ: " + tabCompany.Rows(0)("address_en")
                End If
                If Not IsDBNull(tabCompany.Rows(0)("phone")) Then
                    ws.Cells("A2").Value = "Điện thoại:" + tabCompany.Rows(0)("phone")
                End If
            End If
            While dnext <= obj.PARA_TODATE
                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Value = dnext.Day.ToString
                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + (RowHeader - 1).ToString).Value = dnext
                If dnext.DayOfWeek = DayOfWeek.Sunday Then
                    ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.BackgroundColor.SetColor(Color.Red)
                End If
                dnext = dnext.AddDays(1)
                inext += 1
            End While
            Dim ColDelete As Integer = inext + 1
            While inext < 31
                ws.DeleteColumn(SoCotThongTinChung + ColDelete)
                inext += 1
            End While

            Dim tabLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "table")
            Dim tabLoaiPhep As DataTable = kn.ReadData("select * from SmartBooks_LeaveType", "table")
            Dim tabNhanVien As DataTable = kn.ReadData("exec [dbo].[sp_BangThongTinNhanVien] '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',16,'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
            inext = RowStart
            Dim i, j, k, No As Integer
            Dim Config As String
            No = 1
            Dim BangCong As DataTable = kn.ReadData("exec sp_bangcong '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',28,N'" + obj.Lan + "',N'" + obj.UserName + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
            ProgressBarControl1.Properties.Minimum = 1
            ProgressBarControl1.Properties.Maximum = tabNhanVien.Rows.Count
            Dim progress As Integer = 1
            For Each row As DataRow In tabNhanVien.Rows
                ProgressBarControl1.EditValue = progress
                ProgressBarControl1.Refresh()
                progress += 1
                'Khởi tạo giá trị tổng của 1 nv
                TongPhepHuongLuong = 0
                TongPhepKhongLuong = 0
                TienCC = 0
                TienXX = 0
                TienConNho = 0
                LuongCB = 0
                PCTrachNhiem = 0
                TienCom = 0
                'Điền thông tin nhân viên
                For i = 0 To SoCotThongTinChung - 1
                    Config = ws.Cells(ColExcel(i) + RowConfig.ToString).Value
                    If Config <> String.Empty Then
                        For j = inext To inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon
                            If Config = "No" Then
                                ws.Cells(ColExcel(i) + j.ToString).Value = No
                            Else
                                ws.Cells(ColExcel(i) + j.ToString).Value = row(Config)
                                If TKD_XuatBangCong_ViewPhieuCong = True Then
                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + j.ToString).Value = row(Config)
                                    If j = inext Then
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 1).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 2).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 3).ToString).Value = row(Config)
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 4).ToString).Value = row(Config)
                                        If inext = RowStart Then
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 5).ToString).Value = row(Config)
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 6).ToString).Value = row(Config)
                                            ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 7).ToString).Value = row(Config)
                                        End If
                                    ElseIf j = inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon Then
                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j + 1).ToString).Value = row(Config)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                'Điền thông tin chung
                If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + inext.ToString).Value = "Quẹt vào"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + inext.ToString).Value = "HR_TimeKeeping_Data"
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + 1).ToString).Value = "Quẹt ra"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + 1).ToString).Value = "HR_TimeKeeping_Data"
                End If
                If TKD_XuatBangCong_ViewLateIn = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa).ToString).Value = "Muộn"
                End If
                For i = 0 To SoDongLoaiCong - 1
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachTenCong(i)
                    ws.Cells(ColExcel(SoCotThongTinChung - 2) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachLoaiCong(i)
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = "HR_WTDaily"
                Next
                If TKD_XuatBangCong_ViewDKTangCa = True Then
                    'ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Tăng ca thực tế"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "HR_MaxOvertime"
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Kế hoạch tăng ca"
                End If
                If TKD_XuatBangCong_ViewLeave = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Lý do nghỉ"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisLeave"
                End If
                If TKD_XuatBangCong_ViewShift = True Then
                    ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Ca"
                    ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisTimeSheet"
                End If
                'Điền thông tin công
                rowCong = BangCong.Select("Employee_ID='" + row("Employee_ID") + "'")
                For Each rc As DataRow In rowCong
                    NgayCong = rc("Ngay")
                    For i = SoCotThongTinChung To SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)
                        Config = ws.Cells(ColExcel(i) + RowHeader.ToString).Value
                        If NgayCong.Day.ToString = Config Then
                            'ThucTeTCTheoNgay = 0
                            TongNgayCong = rc("TongNgayCong")
                            TongNgayCongThucTe = rc("TongNgayCongThucTe")
                            If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
                                If Not IsDBNull(rc("RealTimeIn")) Then
                                    TimeIn = rc("RealTimeIn")
                                    ws.Cells(ColExcel(i) + inext.ToString).Value = New DateTime(TimeIn.Ticks).ToString("HH:mm")
                                End If
                                If Not IsDBNull(rc("RealTimeOut")) Then
                                    TimeOut = rc("RealTimeOut")
                                    ws.Cells(ColExcel(i) + (inext + 1).ToString).Value = New DateTime(TimeOut.Ticks).ToString("HH:mm")
                                End If
                            End If
                            If TKD_XuatBangCong_ViewLateIn = True Then
                                If Not IsDBNull(rc("LateIn")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa).ToString).Value = rc("LateIn")
                                End If
                            End If
                            For j = 0 To SoDongLoaiCong - 1
                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongMuon + j).ToString).Value = rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
                                'If tabLoaiCong.Select("MaCong='" + TKD_XuatBangCong_DanhSachLoaiCong(j) + "' and isOverTime=1").Length > 0 Then
                                '    If Not IsDBNull(rc(TKD_XuatBangCong_DanhSachLoaiCong(j))) Then
                                '        ThucTeTCTheoNgay += rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
                                '    End If
                                'End If
                            Next
                            If TKD_XuatBangCong_ViewDKTangCa = True Then
                                'If ThucTeTCTheoNgay > 0 Then
                                '    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = ThucTeTCTheoNgay
                                'End If
                                If Not IsDBNull(rc("maxovertime")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = rc("maxovertime")
                                End If
                            End If
                            TongPhepHuongLuong = rc("PhepHuongLuong")
                            TongPhepKhongLuong = rc("NghiKhongLuong")
                            LuongCB = rc("LuongCoDinh")
                            PCTrachNhiem = rc("TienTrachNhiem")
                            TienCom = rc("TienCaDem")
                            PCDienThoai = rc("TienDienThoai")
                            TienXX = rc("TienXX")
                            TienCC = rc("TienCC")
                            TienConNho = rc("TienConNho")
                            PhepNamDaSuDung = rc("PhepNam")
                            PhepNamConlai = rc("PhepNamConLai")
                            If Not IsDBNull(rc("AbsentSign")) Then
                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("AbsentSign")
                            End If
                            If TKD_XuatBangCong_ViewShift = True Then
                                If Not IsDBNull(rc("ShiftName")) Then
                                    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("ShiftName")
                                End If
                            End If
                        End If
                    Next
                Next
                'Điền tổng hợp
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext).ToString).Formula = "=Round(SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + 1).ToString + ")/8,1)"
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 2) + (inext).ToString).Value = TongPhepHuongLuong
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 3) + (inext).ToString).Value = TongPhepKhongLuong
                For i = 0 To SoDongLoaiCong - 1
                    'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
                    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 4 + i) + (inext).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
                Next
                'If SoDongMuon > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa).ToString + ")"
                'End If
                'If SoDongDKTangCa > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ")"
                '    'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ")"
                'End If
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 12) + (inext).ToString).Value = LuongCB
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 13) + (inext).ToString).Value = PCTrachNhiem
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 14) + (inext).ToString).Value = TienCom
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 15) + (inext).ToString).Value = PCDienThoai
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 16) + (inext).ToString).Value = TienXX
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 17) + (inext).ToString).Value = TienCC
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 18) + (inext).ToString).Value = TienConNho
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 19) + (inext).ToString).Value = PhepNamDaSuDung
                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + (inext).ToString).Value = PhepNamConlai

                'If SoDongLoaiCong > 0 Then
                '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1 + i) + inext.ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + SoDongLoaiCong) + inext.ToString + ")"
                'End If
                'Điền border
                join1 = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 1).ToString + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                join = String.Format(ColExcel(SoCotThongTinChung).ToString + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + "{0}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join1).Style.Border.Bottom.Style = ExcelBorderStyle.None
                ws.Cells(join1).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Dotted
                ws.Cells(join).Style.Border.Right.Style = ExcelBorderStyle.Dotted
                join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 20) + "{1}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                'Tô màu ngày lễ
                Dim LoaiNgayCong As DataTable = kn.ReadData("select * from udf_NgayCongDacBietToanCongTy ('" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "')", "table")
                Dim NgayLe As DateTime
                For Each row1 As DataRow In LoaiNgayCong.Rows
                    NgayLe = row1("Ngay")
                    ws.Cells(ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells(ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + NgayLe.Day - 1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.BackgroundColor.SetColor(Color.LightPink)
                Next
                'Kết thúc tô màu ngày lễ
                'Tô màu chủ nhật
                Dim dnext1 As DateTime = obj.PARA_FROMDATE
                Dim inext1 As Integer = 0
                While dnext1 <= obj.PARA_TODATE
                    If dnext1.DayOfWeek = DayOfWeek.Sunday Then
                        ws.Cells(ColExcel(SoCotThongTinChung + inext1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + inext1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
                        ws.Cells(ColExcel(SoCotThongTinChung + inext1).ToString + (RowHeader + 1).ToString + ":" + ColExcel(SoCotThongTinChung + inext1).ToString + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString).Style.Fill.BackgroundColor.SetColor(Color.LightGreen)
                    End If
                    dnext1 = dnext1.AddDays(1)
                    inext1 += 1
                End While
                'BackColor trắng
                join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 2) + "{1}", (inext + 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
                ws.Cells(join).Style.Font.Color.SetColor(Color.White)
                'Merge thông tin chung
                If TKD_XuatBangCong_ViewPhieuCong = True Then
                    For j = 0 To SoCotThongTinChung - 2
                        join = String.Format(ColExcel(j) + "{0}:" + ColExcel(j) + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString)
                        ws.Cells(join).Merge = True
                    Next
                End If
                No += 1
                inext += SoDongCa + SoDongPhep + SoDongQuetVaoRa + SoDongLoaiCong + SoDongHeaderPhieuCong + SoDongCachNhauGiuaHaiPhieuCong + SoDongMuon + SoDongDKTangCa
                If TKD_XuatBangCong_ViewPhieuCong = True Then 'copy thông tin chung của fieu lương như ghi chú, header
                    ws.Cells(5, 1, 5, ws.Dimension.End.Column).Copy(ws.Cells(inext - 1, 1, inext - 1, ws.Dimension.End.Column))
                    ws.Cells(6, 1, 6, ws.Dimension.End.Column).Copy(ws.Cells(inext, 1, inext, ws.Dimension.End.Column))
                    ws.Cells(RowHeader, 1, RowHeader, ws.Dimension.End.Column).Copy(ws.Cells(inext + 1, 1, inext + 1, ws.Dimension.End.Column))
                    inext += 2
                End If
            Next

            package.SaveAs(New FileInfo(TKD_XuatBangCong_FilePathWT))
            System.Diagnostics.Process.Start(TKD_XuatBangCong_FilePathWT)
        End Using
        Me.Close()
    End Sub
    'Public Sub TKD_XuatBangCong()
    'Dim TemplateFile As String
    'If TKD_XuatBangCong_ViewPhieuCong = True Then
    '        TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay_PhieuCong.xlsx"
    '    Else
    '        TemplateFile = Application.StartupPath() + "\Teamleate\ChamCongChiTietNgay.xlsx"
    '    End If
    'Dim excel As New FileInfo(TemplateFile)

    'Using package = New ExcelPackage(excel)
    'Dim ws As ExcelWorksheet = package.Workbook.Worksheets.First 'or any other name for the WorkSheet 
    'Dim ColExcel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"}
    'Dim SoCotThongTinChung As Integer = 13
    'Dim SoDongQuetVaoRa, SoDongCa, SoDongPhep, SoDongLoaiCong, SoDongHeaderPhieuCong, SoDongCachNhauGiuaHaiPhieuCong, SoDongDKTangCa, SoDongMuon, CotBatDauDienThongTinLoc As Integer
    '        CotBatDauDienThongTinLoc = 64
    '        SoDongMuon = 0
    '        If TKD_XuatBangCong_ViewLateIn = True Then
    '            SoDongMuon = 1
    '        End If
    '        SoDongPhep = 0
    '        If TKD_XuatBangCong_ViewLeave = True Then
    '            SoDongPhep = 1
    '        End If
    '        SoDongCa = 0
    '        If TKD_XuatBangCong_ViewShift = True Then
    '            SoDongCa = 1
    '        End If
    '        SoDongQuetVaoRa = 0
    '        If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
    '            SoDongQuetVaoRa = 2
    '        End If
    '        SoDongLoaiCong = 0
    '        If Not IsNothing(TKD_XuatBangCong_DanhSachLoaiCong) Then
    '            SoDongLoaiCong = TKD_XuatBangCong_DanhSachLoaiCong.Length
    '        End If
    '        SoDongDKTangCa = 0
    '        If TKD_XuatBangCong_ViewDKTangCa = True Then
    '            SoDongDKTangCa = 1
    '        End If
    '        SoDongHeaderPhieuCong = 0
    '        SoDongCachNhauGiuaHaiPhieuCong = 0
    '        If TKD_XuatBangCong_ViewPhieuCong = True Then
    '            SoDongHeaderPhieuCong = 1
    '            SoDongCachNhauGiuaHaiPhieuCong = 2
    '        End If
    'Dim dnext As DateTime = obj.PARA_FROMDATE
    'Dim inext As Integer = 0
    'Dim TongPhepHuongLuong As Double
    'Dim RowConfig, RowHeader, RowStart As Integer
    'Dim rowCong As DataRow()
    'Dim NgayCong As DateTime
    'Dim TimeIn, TimeOut As TimeSpan
    '        RowConfig = 9
    '        RowHeader = 10
    '        RowStart = 12
    '        If TKD_XuatBangCong_ViewPhieuCong = False Then
    '            ws.Cells("A5").Value = ws.Cells("A5").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
    '        Else
    '            ws.Cells("A6").Value = ws.Cells("A6").Value + ": " + obj.PARA_FROMDATE.ToString("MM/yyyy")
    '        End If

    'Dim join As String
    ''Điền thông tin công ty
    'Dim tabCompany As DataTable = kn.ReadData("select * from SmartBooks_Company", "table")
    'If tabCompany.Rows.Count > 0 Then
    'If Not IsDBNull(tabCompany.Rows(0)("company_name")) Then
    '                ws.Cells("A1").Value = tabCompany.Rows(0)("company_name")
    '            End If
    'If Not IsDBNull(tabCompany.Rows(0)("address_en")) Then
    '                ws.Cells("A2").Value = "Địa chỉ: " + tabCompany.Rows(0)("address_en")
    '            End If
    'If Not IsDBNull(tabCompany.Rows(0)("phone")) Then
    '                ws.Cells("A2").Value = "Điện thoại:" + tabCompany.Rows(0)("phone")
    '            End If
    'End If
    'While dnext <= obj.PARA_TODATE
    '            ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Value = dnext.Day.ToString
    '            ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + (RowHeader - 1).ToString).Value = dnext
    '            If dnext.DayOfWeek = DayOfWeek.Sunday Then
    '                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.PatternType = ExcelFillStyle.Solid
    '                ws.Cells(ColExcel(SoCotThongTinChung + inext).ToString + RowHeader.ToString).Style.Fill.BackgroundColor.SetColor(Color.Red)
    '            End If
    '            dnext = dnext.AddDays(1)
    '            inext += 1
    '        End While
    'Dim ColDelete As Integer = inext + 1
    'While inext < 31
    '            ws.DeleteColumn(SoCotThongTinChung + ColDelete)
    '            inext += 1
    '        End While

    'Dim tabLoaiCong As DataTable = kn.ReadData("select * from HR_LoaiCong", "table")
    ''Dim tabLoaiPhep As DataTable = kn.ReadData("select * from SmartBooks_LeaveType", "table")
    'Dim tabNhanVien As DataTable = kn.ReadData("exec [dbo].[sp_BangThongTinNhanVien] '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',12,N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
    '        inext = RowStart
    '        Dim i, j, k, No As Integer
    'Dim Config As String
    '        No = 1
    '        Dim BangCong As DataTable = kn.ReadData("exec sp_bangcong '" + obj.PARA_FROMDATE.ToString("yyyy-MM-dd") + "','" + obj.PARA_TODATE.ToString("yyyy-MM-dd") + "',3,N'" + obj.Lan + "',N'" + obj.PARA_FACTORY_ID + "',N'" + obj.PARA_DEPARTMENTCODE + "',N'" + obj.PARA_SECTIONCODE + "',N'" + obj.PARA_TEAMCODE + "',N'" + obj.PARA_POSITION_ID + "',N'" + obj.PARA_POSITIONCATEGORY_ID + "'", "table")
    '        ProgressBarControl1.Properties.Minimum = 1
    '        ProgressBarControl1.Properties.Maximum = tabNhanVien.Rows.Count
    '        Dim progress As Integer = 1
    'For Each row As DataRow In tabNhanVien.Rows
    '            ProgressBarControl1.EditValue = progress
    '            ProgressBarControl1.Refresh()
    '            progress += 1
    '            'Khởi tạo giá trị tổng của 1 nv
    '            TongPhepHuongLuong = 0
    '            'Điền thông tin nhân viên
    '            For i = 0 To SoCotThongTinChung - 1
    '                Config = ws.Cells(ColExcel(i) + RowConfig.ToString).Value
    '                If Config <> String.Empty Then
    'For j = inext To inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon
    'If Config = "No" Then
    '                            ws.Cells(ColExcel(i) + j.ToString).Value = No
    '                        Else
    '                            ws.Cells(ColExcel(i) + j.ToString).Value = row(Config)
    '                            If TKD_XuatBangCong_ViewPhieuCong = True Then
    '                                ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + j.ToString).Value = row(Config)
    '                                If j = inext Then
    '                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 1).ToString).Value = row(Config)
    '                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 2).ToString).Value = row(Config)
    '                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 3).ToString).Value = row(Config)
    '                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 4).ToString).Value = row(Config)
    '                                    If inext = RowStart Then
    '                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 5).ToString).Value = row(Config)
    '                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 6).ToString).Value = row(Config)
    '                                        ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j - 7).ToString).Value = row(Config)
    '                                    End If
    'ElseIf j = inext + SoDongLoaiCong + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongDKTangCa + SoDongMuon Then
    '                                    ws.Cells(ColExcel(CotBatDauDienThongTinLoc - (31 - DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + i) + (j + 1).ToString).Value = row(Config)
    '                                End If
    'End If
    'End If
    'Next
    'End If
    'Next
    ''Điền thông tin chung
    'If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + inext.ToString).Value = "Quẹt vào"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 3) + inext.ToString).Value = "HR_TimeKeeping_Data"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + 1).ToString).Value = "Quẹt ra"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + 1).ToString).Value = "HR_TimeKeeping_Data"
    '            End If
    'If TKD_XuatBangCong_ViewLateIn = True Then
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa).ToString).Value = "Muộn"
    '            End If
    'For i = 0 To SoDongLoaiCong - 1
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachTenCong(i)
    '                ws.Cells(ColExcel(SoCotThongTinChung - 2) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = TKD_XuatBangCong_DanhSachLoaiCong(i)
    '                ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + i + SoDongQuetVaoRa + SoDongMuon).ToString).Value = "HR_WTDaily"
    '            Next
    'If TKD_XuatBangCong_ViewDKTangCa = True Then
    '                'ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Tăng ca thực tế"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "HR_MaxOvertime"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = "Kế hoạch tăng ca"
    '            End If
    'If TKD_XuatBangCong_ViewLeave = True Then
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Lý do nghỉ"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisLeave"
    '            End If
    'If TKD_XuatBangCong_ViewShift = True Then
    '                ws.Cells(ColExcel(SoCotThongTinChung - 1) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "Ca"
    '                ws.Cells(ColExcel(SoCotThongTinChung - 3) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = "HR_EmpRegisTimeSheet"
    '            End If
    '            'Điền thông tin công
    '            rowCong = BangCong.Select("Employee_ID='" + row("Employee_ID") + "'")
    '            For Each rc As DataRow In rowCong
    '                NgayCong = rc("Ngay")
    '                For i = SoCotThongTinChung To SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)
    '                    Config = ws.Cells(ColExcel(i) + RowHeader.ToString).Value
    '                    If NgayCong.Day.ToString = Config Then
    ''ThucTeTCTheoNgay = 0
    'If TKD_XuatBangCong_ViewTimeInTimeOut = True Then
    'If Not IsDBNull(rc("RealTimeIn")) Then
    '                                TimeIn = rc("RealTimeIn")
    '                                ws.Cells(ColExcel(i) + inext.ToString).Value = New DateTime(TimeIn.Ticks).ToString("HH:mm")
    '                            End If
    'If Not IsDBNull(rc("RealTimeOut")) Then
    '                                TimeOut = rc("RealTimeOut")
    '                                ws.Cells(ColExcel(i) + (inext + 1).ToString).Value = New DateTime(TimeOut.Ticks).ToString("HH:mm")
    '                            End If
    'End If
    'If TKD_XuatBangCong_ViewLateIn = True Then
    'If Not IsDBNull(rc("LateIn")) Then
    '                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa).ToString).Value = rc("LateIn")
    '                            End If
    'End If
    'For j = 0 To SoDongLoaiCong - 1
    '                            ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongMuon + j).ToString).Value = rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
    '                            'If tabLoaiCong.Select("MaCong='" + TKD_XuatBangCong_DanhSachLoaiCong(j) + "' and isOverTime=1").Length > 0 Then
    '                            '    If Not IsDBNull(rc(TKD_XuatBangCong_DanhSachLoaiCong(j))) Then
    '                            '        ThucTeTCTheoNgay += rc(TKD_XuatBangCong_DanhSachLoaiCong(j))
    '                            '    End If
    '                            'End If
    '                        Next
    'If TKD_XuatBangCong_ViewDKTangCa = True Then
    ''If ThucTeTCTheoNgay > 0 Then
    ''    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = ThucTeTCTheoNgay
    ''End If
    'If Not IsDBNull(rc("maxovertime")) Then
    '                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Value = rc("maxovertime")
    '                            End If
    'End If
    'If TKD_XuatBangCong_ViewLeave = True Then
    'If Not IsDBNull(rc("AbsentSign")) Then
    '                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("AbsentSign")
    '                                'If rc("HourLeave") = 8 Then
    '                                '    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("LeaveType_ID")
    '                                'Else
    '                                '    ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("LeaveType_ID") + "/" + rc("HourLeave").ToString
    '                                'End If
    '                                'If tabLoaiPhep.Select("LeaveType_ID='" + rc("LeaveType_ID") + "' and isLeave_ComPay=1").Length > 0 Then
    '                                '    TongPhepHuongLuong += rc("HourLeave")
    '                                'End If
    '                            End If
    'End If
    'If TKD_XuatBangCong_ViewShift = True Then
    'If Not IsDBNull(rc("ShiftSign")) Then
    '                                ws.Cells(ColExcel(i) + (inext + SoDongQuetVaoRa + SoDongPhep + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = rc("ShiftSign")
    '                            End If
    'End If
    'End If
    'Next
    'Next
    ''Điền tổng hợp
    'If SoDongMuon > 0 Then
    '                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa).ToString + ")"
    '            End If
    'For i = 0 To SoDongLoaiCong - 1
    '                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongMuon + i).ToString + ")"
    '            Next
    'If SoDongDKTangCa > 0 Then
    '                ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon).ToString + ")"
    '                'ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE)) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongMuon + 1).ToString + ")"
    '            End If
    'If SoDongPhep > 0 Then
    'If TongPhepHuongLuong > 0 Then
    '                    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + (inext + SoDongQuetVaoRa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString).Value = TongPhepHuongLuong
    '                End If
    '                i += 1
    '            End If

    '            'If SoDongLoaiCong > 0 Then
    '            '    ws.Cells(ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1 + i) + inext.ToString).Formula = "=SUM(" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + inext.ToString + ":" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + SoDongLoaiCong) + inext.ToString + ")"
    '            'End If
    '            'Điền border
    '            join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
    '            ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Dotted
    '            ws.Cells(join).Style.Border.Right.Style = ExcelBorderStyle.Thin
    '            join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung + DateDiff(DateInterval.Day, obj.PARA_FROMDATE, obj.PARA_TODATE) + 1) + "{1}", (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
    '            ws.Cells(join).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
    '            'BackColor trắng
    '            join = String.Format("A{0}:" + ColExcel(SoCotThongTinChung - 2) + "{1}", (inext + 1).ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon - 1).ToString)
    '            ws.Cells(join).Style.Font.Color.SetColor(Color.White)
    '            'Merge thông tin chung
    '            If TKD_XuatBangCong_ViewPhieuCong = True Then
    'For j = 0 To SoCotThongTinChung - 2
    '                    join = String.Format(ColExcel(j) + "{0}:" + ColExcel(j) + "{1}", inext.ToString, (inext + SoDongQuetVaoRa + SoDongPhep + SoDongCa - 1 + SoDongLoaiCong + SoDongDKTangCa + SoDongMuon).ToString)
    '                    ws.Cells(join).Merge = True
    '                Next
    'End If
    '            No += 1
    '            inext += SoDongCa + SoDongPhep + SoDongQuetVaoRa + SoDongLoaiCong + SoDongHeaderPhieuCong + SoDongCachNhauGiuaHaiPhieuCong + SoDongMuon + SoDongDKTangCa
    '            If TKD_XuatBangCong_ViewPhieuCong = True Then 'copy thông tin chung của fieu lương như ghi chú, header
    '                ws.Cells(5, 1, 5, ws.Dimension.End.Column).Copy(ws.Cells(inext - 1, 1, inext - 1, ws.Dimension.End.Column))
    '                ws.Cells(6, 1, 6, ws.Dimension.End.Column).Copy(ws.Cells(inext, 1, inext, ws.Dimension.End.Column))
    '                ws.Cells(RowHeader, 1, RowHeader, ws.Dimension.End.Column).Copy(ws.Cells(inext + 1, 1, inext + 1, ws.Dimension.End.Column))
    '                inext += 2
    '            End If
    'Next

    '        package.SaveAs(New FileInfo(TKD_XuatBangCong_FilePathWT))
    '        System.Diagnostics.Process.Start(TKD_XuatBangCong_FilePathWT)
    '    End Using
    'Me.Close()
    'End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If kn.cn.State = ConnectionState.Open Then
            kn.cmd.Cancel()
        End If
        thread.Suspend()
        btnStop.Enabled = False
        btnStart.Enabled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If kn.cn.State = ConnectionState.Open Then
            kn.cmd.Cancel()
        End If
        If thread.ThreadState = Threading.ThreadState.Running Then
            thread.Abort()
        End If
        Me.Close()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        thread.Resume()
        btnStart.Enabled = False
        btnStop.Enabled = True
    End Sub

End Class
