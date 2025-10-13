Imports log4net
Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim obj As New Appsettings.DbSetting
    Public Event doMenu(ByVal ikey As String)
    Private UserName As String
    Dim user As New SmartBooks.BusinessLogic.UserPermission
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents Setup As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents CompanyInformation As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents EmployeeInformation As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents CreateEditEmployee As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents SetupShifts As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BaoHiem As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents BaoCaoBaoHiem As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents QuanLySoBHXH As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TheBHYT As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents RegistSIHI As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditDepartment As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditSection As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditTeam As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditPosition As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Factory As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditContract As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditContractFlow As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ListofUsers As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents SetupPermission As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ReportPermission As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditPositionCategory As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TaoDieuChinhChucDanh As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TaoDieuChinhLoaiNghi As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TaoDieuChinhVungMien As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TaoDieuChinhDanhMuc As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents SetUpFollowDate As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents MayChamCong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TaoDieuChinhLoaiCong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TaoDieuChinhDanhMucLuong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents HR_Hospital As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Salary_Name As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Register As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents RunQuerySQL As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents JobCodeCategory As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents HazardCategory As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents SetupHolidaysSheet As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents EmployeeFamilyInformation As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TransferDepartment As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ChuyenChucVu As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents QuanLyTheTuNhanVien As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Disable As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TerminationAsignment As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Discipline As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Award As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents HeavyAndToxic As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CapPhatAo As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents QuaTrinhHocTapCongTac As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TrainingRecord As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents HealthCheck As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents License As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents DiseasesRecord As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents SurgeryHistory As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TimeKeeping As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents EmpRegisTimeShift As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents DanhSachDangKyDiLam As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents MaxOvertime As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TimeKeepingDaily As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CongBatThuong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents EmpRegisPregnant As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents DangKyNghiSinh As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TimeKeepingData As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents HR_MaxOvertimeInPeriod As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents GoOut As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents RoundShift As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents DangKyCaTheoNhom As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents DangKyPhepTheoGio As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TienCom As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BaoCaoCong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BankAccountOfEmployee As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Payroll As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents DanhSachNguoiPhuThuoc As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents MucLuong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents MucLuongNhanVien As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CaiDatPhuCap As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BacTayNgheNhanVien As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents SalaryComponents As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents luongcodinh As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents CreateEditEmployeeContract As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ThanhToanBaoHiem As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents KeKhaiThueTNCN As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents QuyetToanThueTNCN As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents chucdanh As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents tinhluong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Payslip As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BaoCaoLuong As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents EmpRegisParameter As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents BacTayNghe As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents DayVacationRemain As DevExpress.XtraNavBar.NavBarItem
    Dim kn As New connect(obj.dataPath)

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
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pFA As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Limg As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
        Me.TimeKeeping = New DevExpress.XtraNavBar.NavBarGroup()
        Me.MaxOvertime = New DevExpress.XtraNavBar.NavBarItem()
        Me.HR_MaxOvertimeInPeriod = New DevExpress.XtraNavBar.NavBarItem()
        Me.RoundShift = New DevExpress.XtraNavBar.NavBarItem()
        Me.EmpRegisTimeShift = New DevExpress.XtraNavBar.NavBarItem()
        Me.DangKyCaTheoNhom = New DevExpress.XtraNavBar.NavBarItem()
        Me.TimeKeepingData = New DevExpress.XtraNavBar.NavBarItem()
        Me.GoOut = New DevExpress.XtraNavBar.NavBarItem()
        Me.TimeKeepingDaily = New DevExpress.XtraNavBar.NavBarItem()
        Me.CongBatThuong = New DevExpress.XtraNavBar.NavBarItem()
        Me.EmpRegisPregnant = New DevExpress.XtraNavBar.NavBarItem()
        Me.DangKyNghiSinh = New DevExpress.XtraNavBar.NavBarItem()
        Me.DangKyPhepTheoGio = New DevExpress.XtraNavBar.NavBarItem()
        Me.DanhSachDangKyDiLam = New DevExpress.XtraNavBar.NavBarItem()
        Me.TienCom = New DevExpress.XtraNavBar.NavBarItem()
        Me.BaoCaoCong = New DevExpress.XtraNavBar.NavBarItem()
        Me.DayVacationRemain = New DevExpress.XtraNavBar.NavBarItem()
        Me.Setup = New DevExpress.XtraNavBar.NavBarGroup()
        Me.CompanyInformation = New DevExpress.XtraNavBar.NavBarItem()
        Me.Factory = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditDepartment = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditSection = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditTeam = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditPosition = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditPositionCategory = New DevExpress.XtraNavBar.NavBarItem()
        Me.TaoDieuChinhChucDanh = New DevExpress.XtraNavBar.NavBarItem()
        Me.JobCodeCategory = New DevExpress.XtraNavBar.NavBarItem()
        Me.SetupShifts = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditContract = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditContractFlow = New DevExpress.XtraNavBar.NavBarItem()
        Me.TaoDieuChinhLoaiNghi = New DevExpress.XtraNavBar.NavBarItem()
        Me.SetupHolidaysSheet = New DevExpress.XtraNavBar.NavBarItem()
        Me.TaoDieuChinhVungMien = New DevExpress.XtraNavBar.NavBarItem()
        Me.TaoDieuChinhDanhMuc = New DevExpress.XtraNavBar.NavBarItem()
        Me.TaoDieuChinhLoaiCong = New DevExpress.XtraNavBar.NavBarItem()
        Me.ReportPermission = New DevExpress.XtraNavBar.NavBarItem()
        Me.SetUpFollowDate = New DevExpress.XtraNavBar.NavBarItem()
        Me.TaoDieuChinhDanhMucLuong = New DevExpress.XtraNavBar.NavBarItem()
        Me.Salary_Name = New DevExpress.XtraNavBar.NavBarItem()
        Me.MayChamCong = New DevExpress.XtraNavBar.NavBarItem()
        Me.HazardCategory = New DevExpress.XtraNavBar.NavBarItem()
        Me.HR_Hospital = New DevExpress.XtraNavBar.NavBarItem()
        Me.SetupPermission = New DevExpress.XtraNavBar.NavBarItem()
        Me.Register = New DevExpress.XtraNavBar.NavBarItem()
        Me.ListofUsers = New DevExpress.XtraNavBar.NavBarItem()
        Me.RunQuerySQL = New DevExpress.XtraNavBar.NavBarItem()
        Me.EmployeeInformation = New DevExpress.XtraNavBar.NavBarGroup()
        Me.CreateEditEmployee = New DevExpress.XtraNavBar.NavBarItem()
        Me.EmployeeFamilyInformation = New DevExpress.XtraNavBar.NavBarItem()
        Me.TransferDepartment = New DevExpress.XtraNavBar.NavBarItem()
        Me.ChuyenChucVu = New DevExpress.XtraNavBar.NavBarItem()
        Me.TerminationAsignment = New DevExpress.XtraNavBar.NavBarItem()
        Me.QuanLyTheTuNhanVien = New DevExpress.XtraNavBar.NavBarItem()
        Me.Discipline = New DevExpress.XtraNavBar.NavBarItem()
        Me.Award = New DevExpress.XtraNavBar.NavBarItem()
        Me.Disable = New DevExpress.XtraNavBar.NavBarItem()
        Me.HeavyAndToxic = New DevExpress.XtraNavBar.NavBarItem()
        Me.CapPhatAo = New DevExpress.XtraNavBar.NavBarItem()
        Me.QuaTrinhHocTapCongTac = New DevExpress.XtraNavBar.NavBarItem()
        Me.TrainingRecord = New DevExpress.XtraNavBar.NavBarItem()
        Me.HealthCheck = New DevExpress.XtraNavBar.NavBarItem()
        Me.License = New DevExpress.XtraNavBar.NavBarItem()
        Me.DiseasesRecord = New DevExpress.XtraNavBar.NavBarItem()
        Me.SurgeryHistory = New DevExpress.XtraNavBar.NavBarItem()
        Me.BankAccountOfEmployee = New DevExpress.XtraNavBar.NavBarItem()
        Me.Payroll = New DevExpress.XtraNavBar.NavBarGroup()
        Me.DanhSachNguoiPhuThuoc = New DevExpress.XtraNavBar.NavBarItem()
        Me.MucLuong = New DevExpress.XtraNavBar.NavBarItem()
        Me.BacTayNghe = New DevExpress.XtraNavBar.NavBarItem()
        Me.MucLuongNhanVien = New DevExpress.XtraNavBar.NavBarItem()
        Me.BacTayNgheNhanVien = New DevExpress.XtraNavBar.NavBarItem()
        Me.luongcodinh = New DevExpress.XtraNavBar.NavBarItem()
        Me.SalaryComponents = New DevExpress.XtraNavBar.NavBarItem()
        Me.CaiDatPhuCap = New DevExpress.XtraNavBar.NavBarItem()
        Me.EmpRegisParameter = New DevExpress.XtraNavBar.NavBarItem()
        Me.CreateEditEmployeeContract = New DevExpress.XtraNavBar.NavBarItem()
        Me.tinhluong = New DevExpress.XtraNavBar.NavBarItem()
        Me.ThanhToanBaoHiem = New DevExpress.XtraNavBar.NavBarItem()
        Me.KeKhaiThueTNCN = New DevExpress.XtraNavBar.NavBarItem()
        Me.QuyetToanThueTNCN = New DevExpress.XtraNavBar.NavBarItem()
        Me.chucdanh = New DevExpress.XtraNavBar.NavBarItem()
        Me.Payslip = New DevExpress.XtraNavBar.NavBarItem()
        Me.BaoCaoLuong = New DevExpress.XtraNavBar.NavBarItem()
        Me.BaoHiem = New DevExpress.XtraNavBar.NavBarGroup()
        Me.QuanLySoBHXH = New DevExpress.XtraNavBar.NavBarItem()
        Me.TheBHYT = New DevExpress.XtraNavBar.NavBarItem()
        Me.BaoCaoBaoHiem = New DevExpress.XtraNavBar.NavBarItem()
        Me.RegistSIHI = New DevExpress.XtraNavBar.NavBarItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pFA = New System.Windows.Forms.PictureBox()
        Me.Limg = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3.SuspendLayout()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pFA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.NavBarControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(383, 564)
        Me.Panel3.TabIndex = 9
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.TimeKeeping
        Me.NavBarControl1.BackColor = System.Drawing.Color.White
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.Setup, Me.EmployeeInformation, Me.TimeKeeping, Me.Payroll, Me.BaoHiem})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.CompanyInformation, Me.CreateEditEmployee, Me.SetupShifts, Me.CreateEditDepartment, Me.CreateEditSection, Me.CreateEditTeam, Me.CreateEditPosition, Me.Factory, Me.CreateEditContract, Me.CreateEditContractFlow, Me.ListofUsers, Me.SetupPermission, Me.ReportPermission, Me.CreateEditPositionCategory, Me.TaoDieuChinhChucDanh, Me.TaoDieuChinhLoaiNghi, Me.TaoDieuChinhVungMien, Me.TaoDieuChinhDanhMuc, Me.SetUpFollowDate, Me.MayChamCong, Me.TaoDieuChinhLoaiCong, Me.TaoDieuChinhDanhMucLuong, Me.HR_Hospital, Me.Salary_Name, Me.Register, Me.RunQuerySQL, Me.JobCodeCategory, Me.HazardCategory, Me.SetupHolidaysSheet, Me.EmployeeFamilyInformation, Me.TransferDepartment, Me.ChuyenChucVu, Me.QuanLyTheTuNhanVien, Me.Disable, Me.TerminationAsignment, Me.Discipline, Me.Award, Me.HeavyAndToxic, Me.CapPhatAo, Me.QuaTrinhHocTapCongTac, Me.TrainingRecord, Me.HealthCheck, Me.License, Me.DiseasesRecord, Me.SurgeryHistory, Me.DanhSachNguoiPhuThuoc, Me.MucLuong, Me.MucLuongNhanVien, Me.CaiDatPhuCap, Me.BacTayNgheNhanVien, Me.SalaryComponents, Me.luongcodinh, Me.CreateEditEmployeeContract, Me.ThanhToanBaoHiem, Me.KeKhaiThueTNCN, Me.QuyetToanThueTNCN, Me.chucdanh, Me.tinhluong, Me.Payslip, Me.BaoCaoLuong, Me.EmpRegisParameter, Me.BacTayNghe, Me.EmpRegisTimeShift, Me.DanhSachDangKyDiLam, Me.MaxOvertime, Me.TimeKeepingDaily, Me.CongBatThuong, Me.EmpRegisPregnant, Me.DangKyNghiSinh, Me.TimeKeepingData, Me.HR_MaxOvertimeInPeriod, Me.GoOut, Me.RoundShift, Me.DangKyCaTheoNhom, Me.DangKyPhepTheoGio, Me.TienCom, Me.BaoCaoCong, Me.BankAccountOfEmployee, Me.BaoCaoBaoHiem, Me.QuanLySoBHXH, Me.TheBHYT, Me.RegistSIHI, Me.DayVacationRemain})
        Me.NavBarControl1.Location = New System.Drawing.Point(0, 0)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 383
        Me.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavBarControl1.Size = New System.Drawing.Size(383, 564)
        Me.NavBarControl1.TabIndex = 5
        Me.NavBarControl1.Text = "NavBarControl1"
        '
        'TimeKeeping
        '
        Me.TimeKeeping.Caption = "Công"
        Me.TimeKeeping.Expanded = True
        Me.TimeKeeping.ImageOptions.SvgImage = Global.SmartBooks.HumanResource.My.Resources.Resources.groupbydate
        Me.TimeKeeping.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.MaxOvertime), New DevExpress.XtraNavBar.NavBarItemLink(Me.HR_MaxOvertimeInPeriod), New DevExpress.XtraNavBar.NavBarItemLink(Me.RoundShift), New DevExpress.XtraNavBar.NavBarItemLink(Me.EmpRegisTimeShift), New DevExpress.XtraNavBar.NavBarItemLink(Me.DangKyCaTheoNhom), New DevExpress.XtraNavBar.NavBarItemLink(Me.TimeKeepingData), New DevExpress.XtraNavBar.NavBarItemLink(Me.GoOut), New DevExpress.XtraNavBar.NavBarItemLink(Me.TimeKeepingDaily), New DevExpress.XtraNavBar.NavBarItemLink(Me.CongBatThuong), New DevExpress.XtraNavBar.NavBarItemLink(Me.EmpRegisPregnant), New DevExpress.XtraNavBar.NavBarItemLink(Me.DangKyNghiSinh), New DevExpress.XtraNavBar.NavBarItemLink(Me.DangKyPhepTheoGio), New DevExpress.XtraNavBar.NavBarItemLink(Me.DanhSachDangKyDiLam), New DevExpress.XtraNavBar.NavBarItemLink(Me.TienCom), New DevExpress.XtraNavBar.NavBarItemLink(Me.BaoCaoCong), New DevExpress.XtraNavBar.NavBarItemLink(Me.DayVacationRemain)})
        Me.TimeKeeping.Name = "TimeKeeping"
        Me.TimeKeeping.TopVisibleLinkIndex = 8
        '
        'MaxOvertime
        '
        Me.MaxOvertime.Caption = "MaxOvertime"
        Me.MaxOvertime.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.MaxOvertime.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.MaxOvertime.Name = "MaxOvertime"
        '
        'HR_MaxOvertimeInPeriod
        '
        Me.HR_MaxOvertimeInPeriod.Caption = "HR_MaxOvertimeInPeriod"
        Me.HR_MaxOvertimeInPeriod.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.HR_MaxOvertimeInPeriod.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.HR_MaxOvertimeInPeriod.Name = "HR_MaxOvertimeInPeriod"
        '
        'RoundShift
        '
        Me.RoundShift.Caption = "RoundShift"
        Me.RoundShift.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.RoundShift.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.RoundShift.Name = "RoundShift"
        '
        'EmpRegisTimeShift
        '
        Me.EmpRegisTimeShift.Caption = "EmpRegisTimeShift"
        Me.EmpRegisTimeShift.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.EmpRegisTimeShift.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.EmpRegisTimeShift.Name = "EmpRegisTimeShift"
        '
        'DangKyCaTheoNhom
        '
        Me.DangKyCaTheoNhom.Caption = "DangKyCaTheoNhom"
        Me.DangKyCaTheoNhom.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.DangKyCaTheoNhom.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.DangKyCaTheoNhom.Name = "DangKyCaTheoNhom"
        '
        'TimeKeepingData
        '
        Me.TimeKeepingData.Caption = "Time Keeping - Data"
        Me.TimeKeepingData.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TimeKeepingData.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TimeKeepingData.Name = "TimeKeepingData"
        '
        'GoOut
        '
        Me.GoOut.Caption = "GoOut"
        Me.GoOut.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.GoOut.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.GoOut.Name = "GoOut"
        '
        'TimeKeepingDaily
        '
        Me.TimeKeepingDaily.Caption = "Time Keeping - Daily"
        Me.TimeKeepingDaily.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TimeKeepingDaily.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TimeKeepingDaily.Name = "TimeKeepingDaily"
        '
        'CongBatThuong
        '
        Me.CongBatThuong.Caption = "CongBatThuong"
        Me.CongBatThuong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CongBatThuong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CongBatThuong.Name = "CongBatThuong"
        '
        'EmpRegisPregnant
        '
        Me.EmpRegisPregnant.Caption = "EmpRegisPregnant"
        Me.EmpRegisPregnant.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.EmpRegisPregnant.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.EmpRegisPregnant.Name = "EmpRegisPregnant"
        '
        'DangKyNghiSinh
        '
        Me.DangKyNghiSinh.Caption = "DangKyNghiSinh"
        Me.DangKyNghiSinh.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.DangKyNghiSinh.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.DangKyNghiSinh.Name = "DangKyNghiSinh"
        '
        'DangKyPhepTheoGio
        '
        Me.DangKyPhepTheoGio.Caption = "DangKyPhepTheoGio"
        Me.DangKyPhepTheoGio.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.DangKyPhepTheoGio.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.DangKyPhepTheoGio.Name = "DangKyPhepTheoGio"
        '
        'DanhSachDangKyDiLam
        '
        Me.DanhSachDangKyDiLam.Caption = "DanhSachDangKyDiLam"
        Me.DanhSachDangKyDiLam.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.DanhSachDangKyDiLam.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.DanhSachDangKyDiLam.Name = "DanhSachDangKyDiLam"
        '
        'TienCom
        '
        Me.TienCom.Caption = "TienCom"
        Me.TienCom.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TienCom.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TienCom.Name = "TienCom"
        '
        'BaoCaoCong
        '
        Me.BaoCaoCong.Caption = "BaoCaoCong"
        Me.BaoCaoCong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.BaoCaoCong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.BaoCaoCong.Name = "BaoCaoCong"
        '
        'DayVacationRemain
        '
        Me.DayVacationRemain.Caption = "DayVacationRemain"
        Me.DayVacationRemain.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x168
        Me.DayVacationRemain.Name = "DayVacationRemain"
        '
        'Setup
        '
        Me.Setup.AppearanceBackground.BackColor = System.Drawing.Color.Red
        Me.Setup.AppearanceBackground.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Setup.AppearanceBackground.Options.UseBackColor = True
        Me.Setup.AppearanceBackground.Options.UseForeColor = True
        Me.Setup.Caption = "CÀI ĐẶT TỔNG QUÁT"
        Me.Setup.ImageOptions.SvgImage = Global.SmartBooks.HumanResource.My.Resources.Resources.bo_category
        Me.Setup.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.CompanyInformation), New DevExpress.XtraNavBar.NavBarItemLink(Me.Factory), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditDepartment), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditSection), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditTeam), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditPosition), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditPositionCategory), New DevExpress.XtraNavBar.NavBarItemLink(Me.TaoDieuChinhChucDanh), New DevExpress.XtraNavBar.NavBarItemLink(Me.JobCodeCategory), New DevExpress.XtraNavBar.NavBarItemLink(Me.SetupShifts), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditContract), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditContractFlow), New DevExpress.XtraNavBar.NavBarItemLink(Me.TaoDieuChinhLoaiNghi), New DevExpress.XtraNavBar.NavBarItemLink(Me.SetupHolidaysSheet), New DevExpress.XtraNavBar.NavBarItemLink(Me.TaoDieuChinhVungMien), New DevExpress.XtraNavBar.NavBarItemLink(Me.TaoDieuChinhDanhMuc), New DevExpress.XtraNavBar.NavBarItemLink(Me.TaoDieuChinhLoaiCong), New DevExpress.XtraNavBar.NavBarItemLink(Me.ReportPermission), New DevExpress.XtraNavBar.NavBarItemLink(Me.SetUpFollowDate), New DevExpress.XtraNavBar.NavBarItemLink(Me.TaoDieuChinhDanhMucLuong), New DevExpress.XtraNavBar.NavBarItemLink(Me.Salary_Name), New DevExpress.XtraNavBar.NavBarItemLink(Me.MayChamCong), New DevExpress.XtraNavBar.NavBarItemLink(Me.HazardCategory), New DevExpress.XtraNavBar.NavBarItemLink(Me.HR_Hospital), New DevExpress.XtraNavBar.NavBarItemLink(Me.SetupPermission), New DevExpress.XtraNavBar.NavBarItemLink(Me.Register), New DevExpress.XtraNavBar.NavBarItemLink(Me.ListofUsers), New DevExpress.XtraNavBar.NavBarItemLink(Me.RunQuerySQL)})
        Me.Setup.Name = "Setup"
        '
        'CompanyInformation
        '
        Me.CompanyInformation.Caption = "CompanyInformation"
        Me.CompanyInformation.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x321
        Me.CompanyInformation.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x161
        Me.CompanyInformation.Name = "CompanyInformation"
        '
        'Factory
        '
        Me.Factory.Caption = "Factory"
        Me.Factory.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x322
        Me.Factory.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x162
        Me.Factory.Name = "Factory"
        '
        'CreateEditDepartment
        '
        Me.CreateEditDepartment.Caption = "Create/Edit Department"
        Me.CreateEditDepartment.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x324
        Me.CreateEditDepartment.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x164
        Me.CreateEditDepartment.Name = "CreateEditDepartment"
        '
        'CreateEditSection
        '
        Me.CreateEditSection.Caption = "Create/Edit Section"
        Me.CreateEditSection.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x323
        Me.CreateEditSection.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x163
        Me.CreateEditSection.Name = "CreateEditSection"
        '
        'CreateEditTeam
        '
        Me.CreateEditTeam.Caption = "Create/Edit Team"
        Me.CreateEditTeam.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x325
        Me.CreateEditTeam.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x165
        Me.CreateEditTeam.Name = "CreateEditTeam"
        '
        'CreateEditPosition
        '
        Me.CreateEditPosition.Caption = "Create/Edit Position"
        Me.CreateEditPosition.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x326
        Me.CreateEditPosition.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x166
        Me.CreateEditPosition.Name = "CreateEditPosition"
        '
        'CreateEditPositionCategory
        '
        Me.CreateEditPositionCategory.Caption = "Create/Edit Position Category"
        Me.CreateEditPositionCategory.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x327
        Me.CreateEditPositionCategory.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x167
        Me.CreateEditPositionCategory.Name = "CreateEditPositionCategory"
        '
        'TaoDieuChinhChucDanh
        '
        Me.TaoDieuChinhChucDanh.Caption = "Tao Dieu Chinh Chuc Danh"
        Me.TaoDieuChinhChucDanh.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x329
        Me.TaoDieuChinhChucDanh.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x169
        Me.TaoDieuChinhChucDanh.Name = "TaoDieuChinhChucDanh"
        '
        'JobCodeCategory
        '
        Me.JobCodeCategory.Caption = "JobCodeCategory"
        Me.JobCodeCategory.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.JobCodeCategory.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.JobCodeCategory.Name = "JobCodeCategory"
        '
        'SetupShifts
        '
        Me.SetupShifts.Caption = "Setup Shifts"
        Me.SetupShifts.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.SetupShifts.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.SetupShifts.Name = "SetupShifts"
        '
        'CreateEditContract
        '
        Me.CreateEditContract.Caption = "Create/Edit Contract"
        Me.CreateEditContract.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CreateEditContract.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CreateEditContract.Name = "CreateEditContract"
        '
        'CreateEditContractFlow
        '
        Me.CreateEditContractFlow.Caption = "Create/Edit Contract Flow"
        Me.CreateEditContractFlow.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CreateEditContractFlow.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CreateEditContractFlow.Name = "CreateEditContractFlow"
        '
        'TaoDieuChinhLoaiNghi
        '
        Me.TaoDieuChinhLoaiNghi.Caption = "Tao Dieu Chinh Loai Nghi"
        Me.TaoDieuChinhLoaiNghi.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TaoDieuChinhLoaiNghi.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TaoDieuChinhLoaiNghi.Name = "TaoDieuChinhLoaiNghi"
        '
        'SetupHolidaysSheet
        '
        Me.SetupHolidaysSheet.Caption = "Set up Holidays sheet"
        Me.SetupHolidaysSheet.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.SetupHolidaysSheet.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.SetupHolidaysSheet.Name = "SetupHolidaysSheet"
        '
        'TaoDieuChinhVungMien
        '
        Me.TaoDieuChinhVungMien.Caption = "Tao Dieu Chinh Vung Mien"
        Me.TaoDieuChinhVungMien.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TaoDieuChinhVungMien.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TaoDieuChinhVungMien.Name = "TaoDieuChinhVungMien"
        '
        'TaoDieuChinhDanhMuc
        '
        Me.TaoDieuChinhDanhMuc.Caption = "Tao Dieu Chinh Danh Muc"
        Me.TaoDieuChinhDanhMuc.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TaoDieuChinhDanhMuc.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TaoDieuChinhDanhMuc.Name = "TaoDieuChinhDanhMuc"
        '
        'TaoDieuChinhLoaiCong
        '
        Me.TaoDieuChinhLoaiCong.Caption = "Tao Dieu Chinh Loai Cong"
        Me.TaoDieuChinhLoaiCong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TaoDieuChinhLoaiCong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TaoDieuChinhLoaiCong.Name = "TaoDieuChinhLoaiCong"
        '
        'ReportPermission
        '
        Me.ReportPermission.Caption = "Report Permission"
        Me.ReportPermission.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.ReportPermission.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.ReportPermission.Name = "ReportPermission"
        '
        'SetUpFollowDate
        '
        Me.SetUpFollowDate.Caption = "Set Up Follow Date"
        Me.SetUpFollowDate.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.SetUpFollowDate.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.SetUpFollowDate.Name = "SetUpFollowDate"
        '
        'TaoDieuChinhDanhMucLuong
        '
        Me.TaoDieuChinhDanhMucLuong.Caption = "TaoDieuChinhDanhMucLuong"
        Me.TaoDieuChinhDanhMucLuong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TaoDieuChinhDanhMucLuong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TaoDieuChinhDanhMucLuong.Name = "TaoDieuChinhDanhMucLuong"
        '
        'Salary_Name
        '
        Me.Salary_Name.Caption = "Salary_Name"
        Me.Salary_Name.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.Salary_Name.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.Salary_Name.Name = "Salary_Name"
        '
        'MayChamCong
        '
        Me.MayChamCong.Caption = "May Cham Cong"
        Me.MayChamCong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.MayChamCong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.MayChamCong.Name = "MayChamCong"
        '
        'HazardCategory
        '
        Me.HazardCategory.Caption = "HazardCategory"
        Me.HazardCategory.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.HazardCategory.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.HazardCategory.Name = "HazardCategory"
        '
        'HR_Hospital
        '
        Me.HR_Hospital.Caption = "HR_Hospital"
        Me.HR_Hospital.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.HR_Hospital.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.HR_Hospital.Name = "HR_Hospital"
        '
        'SetupPermission
        '
        Me.SetupPermission.Caption = "Setup Permission"
        Me.SetupPermission.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.SetupPermission.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.SetupPermission.Name = "SetupPermission"
        '
        'Register
        '
        Me.Register.Caption = "Register"
        Me.Register.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.Register.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.Register.Name = "Register"
        '
        'ListofUsers
        '
        Me.ListofUsers.Caption = "List of Users"
        Me.ListofUsers.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.ListofUsers.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.ListofUsers.Name = "ListofUsers"
        '
        'RunQuerySQL
        '
        Me.RunQuerySQL.Caption = "RunQuerySQL"
        Me.RunQuerySQL.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.RunQuerySQL.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.RunQuerySQL.Name = "RunQuerySQL"
        '
        'EmployeeInformation
        '
        Me.EmployeeInformation.Caption = "THÔNG TIN NHÂN VIÊN"
        Me.EmployeeInformation.ImageOptions.SvgImage = Global.SmartBooks.HumanResource.My.Resources.Resources.bo_position_v92
        Me.EmployeeInformation.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditEmployee), New DevExpress.XtraNavBar.NavBarItemLink(Me.EmployeeFamilyInformation), New DevExpress.XtraNavBar.NavBarItemLink(Me.TransferDepartment), New DevExpress.XtraNavBar.NavBarItemLink(Me.ChuyenChucVu), New DevExpress.XtraNavBar.NavBarItemLink(Me.TerminationAsignment), New DevExpress.XtraNavBar.NavBarItemLink(Me.QuanLyTheTuNhanVien), New DevExpress.XtraNavBar.NavBarItemLink(Me.Discipline), New DevExpress.XtraNavBar.NavBarItemLink(Me.Award), New DevExpress.XtraNavBar.NavBarItemLink(Me.Disable), New DevExpress.XtraNavBar.NavBarItemLink(Me.HeavyAndToxic), New DevExpress.XtraNavBar.NavBarItemLink(Me.CapPhatAo), New DevExpress.XtraNavBar.NavBarItemLink(Me.QuaTrinhHocTapCongTac), New DevExpress.XtraNavBar.NavBarItemLink(Me.TrainingRecord), New DevExpress.XtraNavBar.NavBarItemLink(Me.HealthCheck), New DevExpress.XtraNavBar.NavBarItemLink(Me.License), New DevExpress.XtraNavBar.NavBarItemLink(Me.DiseasesRecord), New DevExpress.XtraNavBar.NavBarItemLink(Me.SurgeryHistory), New DevExpress.XtraNavBar.NavBarItemLink(Me.BankAccountOfEmployee)})
        Me.EmployeeInformation.Name = "EmployeeInformation"
        '
        'CreateEditEmployee
        '
        Me.CreateEditEmployee.Caption = "Tạo / Điều chỉnh thông tin nhân viên"
        Me.CreateEditEmployee.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CreateEditEmployee.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CreateEditEmployee.Name = "CreateEditEmployee"
        '
        'EmployeeFamilyInformation
        '
        Me.EmployeeFamilyInformation.Caption = "Employee - Family Information"
        Me.EmployeeFamilyInformation.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.EmployeeFamilyInformation.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.EmployeeFamilyInformation.Name = "EmployeeFamilyInformation"
        '
        'TransferDepartment
        '
        Me.TransferDepartment.Caption = "TransferDepartment"
        Me.TransferDepartment.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TransferDepartment.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TransferDepartment.Name = "TransferDepartment"
        '
        'ChuyenChucVu
        '
        Me.ChuyenChucVu.Caption = "ChuyenChucVu"
        Me.ChuyenChucVu.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.ChuyenChucVu.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.ChuyenChucVu.Name = "ChuyenChucVu"
        '
        'TerminationAsignment
        '
        Me.TerminationAsignment.Caption = "TerminationAsignment"
        Me.TerminationAsignment.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TerminationAsignment.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TerminationAsignment.Name = "TerminationAsignment"
        '
        'QuanLyTheTuNhanVien
        '
        Me.QuanLyTheTuNhanVien.Caption = "QuanLyTheTuNhanVien"
        Me.QuanLyTheTuNhanVien.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.QuanLyTheTuNhanVien.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.QuanLyTheTuNhanVien.Name = "QuanLyTheTuNhanVien"
        '
        'Discipline
        '
        Me.Discipline.Caption = "Discipline"
        Me.Discipline.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.Discipline.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.Discipline.Name = "Discipline"
        '
        'Award
        '
        Me.Award.Caption = "Award"
        Me.Award.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.Award.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.Award.Name = "Award"
        '
        'Disable
        '
        Me.Disable.Caption = "Disable"
        Me.Disable.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.Disable.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.Disable.Name = "Disable"
        '
        'HeavyAndToxic
        '
        Me.HeavyAndToxic.Caption = "HeavyAndToxic"
        Me.HeavyAndToxic.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.HeavyAndToxic.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.HeavyAndToxic.Name = "HeavyAndToxic"
        '
        'CapPhatAo
        '
        Me.CapPhatAo.Caption = "CapPhatAo"
        Me.CapPhatAo.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CapPhatAo.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CapPhatAo.Name = "CapPhatAo"
        '
        'QuaTrinhHocTapCongTac
        '
        Me.QuaTrinhHocTapCongTac.Caption = "QuaTrinhHocTapCongTac"
        Me.QuaTrinhHocTapCongTac.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.QuaTrinhHocTapCongTac.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.QuaTrinhHocTapCongTac.Name = "QuaTrinhHocTapCongTac"
        '
        'TrainingRecord
        '
        Me.TrainingRecord.Caption = "TrainingRecord"
        Me.TrainingRecord.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TrainingRecord.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TrainingRecord.Name = "TrainingRecord"
        '
        'HealthCheck
        '
        Me.HealthCheck.Caption = "HealthCheck"
        Me.HealthCheck.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.HealthCheck.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.HealthCheck.Name = "HealthCheck"
        '
        'License
        '
        Me.License.Caption = "License"
        Me.License.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.License.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.License.Name = "License"
        '
        'DiseasesRecord
        '
        Me.DiseasesRecord.Caption = "DiseasesRecord"
        Me.DiseasesRecord.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.DiseasesRecord.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.DiseasesRecord.Name = "DiseasesRecord"
        '
        'SurgeryHistory
        '
        Me.SurgeryHistory.Caption = "SurgeryHistory"
        Me.SurgeryHistory.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.SurgeryHistory.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.SurgeryHistory.Name = "SurgeryHistory"
        '
        'BankAccountOfEmployee
        '
        Me.BankAccountOfEmployee.Caption = "BankAccountOfEmployee"
        Me.BankAccountOfEmployee.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.BankAccountOfEmployee.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.BankAccountOfEmployee.Name = "BankAccountOfEmployee"
        '
        'Payroll
        '
        Me.Payroll.Caption = "Lương"
        Me.Payroll.ImageOptions.SvgImage = Global.SmartBooks.HumanResource.My.Resources.Resources.financial
        Me.Payroll.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.DanhSachNguoiPhuThuoc), New DevExpress.XtraNavBar.NavBarItemLink(Me.MucLuong), New DevExpress.XtraNavBar.NavBarItemLink(Me.BacTayNghe), New DevExpress.XtraNavBar.NavBarItemLink(Me.MucLuongNhanVien), New DevExpress.XtraNavBar.NavBarItemLink(Me.BacTayNgheNhanVien), New DevExpress.XtraNavBar.NavBarItemLink(Me.luongcodinh), New DevExpress.XtraNavBar.NavBarItemLink(Me.SalaryComponents), New DevExpress.XtraNavBar.NavBarItemLink(Me.CaiDatPhuCap), New DevExpress.XtraNavBar.NavBarItemLink(Me.EmpRegisParameter), New DevExpress.XtraNavBar.NavBarItemLink(Me.CreateEditEmployeeContract), New DevExpress.XtraNavBar.NavBarItemLink(Me.tinhluong), New DevExpress.XtraNavBar.NavBarItemLink(Me.ThanhToanBaoHiem), New DevExpress.XtraNavBar.NavBarItemLink(Me.KeKhaiThueTNCN), New DevExpress.XtraNavBar.NavBarItemLink(Me.QuyetToanThueTNCN), New DevExpress.XtraNavBar.NavBarItemLink(Me.chucdanh), New DevExpress.XtraNavBar.NavBarItemLink(Me.Payslip), New DevExpress.XtraNavBar.NavBarItemLink(Me.BaoCaoLuong)})
        Me.Payroll.Name = "Payroll"
        '
        'DanhSachNguoiPhuThuoc
        '
        Me.DanhSachNguoiPhuThuoc.Caption = "DanhSachNguoiPhuThuoc"
        Me.DanhSachNguoiPhuThuoc.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.DanhSachNguoiPhuThuoc.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.DanhSachNguoiPhuThuoc.Name = "DanhSachNguoiPhuThuoc"
        '
        'MucLuong
        '
        Me.MucLuong.Caption = "MucLuong"
        Me.MucLuong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.MucLuong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.MucLuong.Name = "MucLuong"
        '
        'BacTayNghe
        '
        Me.BacTayNghe.Caption = "BacTayNghe"
        Me.BacTayNghe.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.BacTayNghe.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.BacTayNghe.Name = "BacTayNghe"
        '
        'MucLuongNhanVien
        '
        Me.MucLuongNhanVien.Caption = "MucLuongNhanVien"
        Me.MucLuongNhanVien.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.MucLuongNhanVien.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.MucLuongNhanVien.Name = "MucLuongNhanVien"
        '
        'BacTayNgheNhanVien
        '
        Me.BacTayNgheNhanVien.Caption = "BacTayNgheNhanVien"
        Me.BacTayNgheNhanVien.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.BacTayNgheNhanVien.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.BacTayNgheNhanVien.Name = "BacTayNgheNhanVien"
        '
        'luongcodinh
        '
        Me.luongcodinh.Caption = "luongcodinh"
        Me.luongcodinh.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.luongcodinh.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.luongcodinh.Name = "luongcodinh"
        '
        'SalaryComponents
        '
        Me.SalaryComponents.Caption = "Salary Components"
        Me.SalaryComponents.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.SalaryComponents.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.SalaryComponents.Name = "SalaryComponents"
        '
        'CaiDatPhuCap
        '
        Me.CaiDatPhuCap.Caption = "CaiDatPhuCap"
        Me.CaiDatPhuCap.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CaiDatPhuCap.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CaiDatPhuCap.Name = "CaiDatPhuCap"
        '
        'EmpRegisParameter
        '
        Me.EmpRegisParameter.Caption = "EmpRegisParameter"
        Me.EmpRegisParameter.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.EmpRegisParameter.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.EmpRegisParameter.Name = "EmpRegisParameter"
        '
        'CreateEditEmployeeContract
        '
        Me.CreateEditEmployeeContract.Caption = "Create/Edit Employee Contract"
        Me.CreateEditEmployeeContract.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.CreateEditEmployeeContract.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.CreateEditEmployeeContract.Name = "CreateEditEmployeeContract"
        '
        'tinhluong
        '
        Me.tinhluong.Caption = "tinhluong"
        Me.tinhluong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.tinhluong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.tinhluong.Name = "tinhluong"
        '
        'ThanhToanBaoHiem
        '
        Me.ThanhToanBaoHiem.Caption = "ThanhToanBaoHiem"
        Me.ThanhToanBaoHiem.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.ThanhToanBaoHiem.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.ThanhToanBaoHiem.Name = "ThanhToanBaoHiem"
        '
        'KeKhaiThueTNCN
        '
        Me.KeKhaiThueTNCN.Caption = "KeKhaiThueTNCN"
        Me.KeKhaiThueTNCN.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.KeKhaiThueTNCN.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.KeKhaiThueTNCN.Name = "KeKhaiThueTNCN"
        '
        'QuyetToanThueTNCN
        '
        Me.QuyetToanThueTNCN.Caption = "QuyetToanThueTNCN"
        Me.QuyetToanThueTNCN.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.QuyetToanThueTNCN.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.QuyetToanThueTNCN.Name = "QuyetToanThueTNCN"
        '
        'chucdanh
        '
        Me.chucdanh.Caption = "chucdanh"
        Me.chucdanh.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.chucdanh.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.chucdanh.Name = "chucdanh"
        '
        'Payslip
        '
        Me.Payslip.Caption = "Payslip"
        Me.Payslip.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.Payslip.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.Payslip.Name = "Payslip"
        '
        'BaoCaoLuong
        '
        Me.BaoCaoLuong.Caption = "BaoCaoLuong"
        Me.BaoCaoLuong.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.BaoCaoLuong.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.BaoCaoLuong.Name = "BaoCaoLuong"
        '
        'BaoHiem
        '
        Me.BaoHiem.Caption = "BaoHiem"
        Me.BaoHiem.ImageOptions.SvgImage = Global.SmartBooks.HumanResource.My.Resources.Resources.assigntask
        Me.BaoHiem.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.QuanLySoBHXH), New DevExpress.XtraNavBar.NavBarItemLink(Me.TheBHYT), New DevExpress.XtraNavBar.NavBarItemLink(Me.BaoCaoBaoHiem), New DevExpress.XtraNavBar.NavBarItemLink(Me.RegistSIHI)})
        Me.BaoHiem.Name = "BaoHiem"
        '
        'QuanLySoBHXH
        '
        Me.QuanLySoBHXH.Caption = "QuanLySoBHXH"
        Me.QuanLySoBHXH.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.QuanLySoBHXH.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.QuanLySoBHXH.Name = "QuanLySoBHXH"
        '
        'TheBHYT
        '
        Me.TheBHYT.Caption = "TheBHYT"
        Me.TheBHYT.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.TheBHYT.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.TheBHYT.Name = "TheBHYT"
        '
        'BaoCaoBaoHiem
        '
        Me.BaoCaoBaoHiem.Caption = "BaoCaoBaoHiem"
        Me.BaoCaoBaoHiem.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.BaoCaoBaoHiem.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.BaoCaoBaoHiem.Name = "BaoCaoBaoHiem"
        '
        'RegistSIHI
        '
        Me.RegistSIHI.Caption = "RegistSIHI"
        Me.RegistSIHI.ImageOptions.LargeImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_32x3210
        Me.RegistSIHI.ImageOptions.SmallImage = Global.SmartBooks.HumanResource.My.Resources.Resources.next_16x1610
        Me.RegistSIHI.Name = "RegistSIHI"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "")
        Me.ImageList2.Images.SetKeyName(6, "")
        Me.ImageList2.Images.SetKeyName(7, "")
        Me.ImageList2.Images.SetKeyName(8, "")
        Me.ImageList2.Images.SetKeyName(9, "")
        Me.ImageList2.Images.SetKeyName(10, "")
        Me.ImageList2.Images.SetKeyName(11, "")
        Me.ImageList2.Images.SetKeyName(12, "")
        Me.ImageList2.Images.SetKeyName(13, "")
        Me.ImageList2.Images.SetKeyName(14, "")
        Me.ImageList2.Images.SetKeyName(15, "")
        Me.ImageList2.Images.SetKeyName(16, "")
        Me.ImageList2.Images.SetKeyName(17, "")
        Me.ImageList2.Images.SetKeyName(18, "")
        Me.ImageList2.Images.SetKeyName(19, "")
        Me.ImageList2.Images.SetKeyName(20, "")
        Me.ImageList2.Images.SetKeyName(21, "")
        Me.ImageList2.Images.SetKeyName(22, "")
        Me.ImageList2.Images.SetKeyName(23, "")
        Me.ImageList2.Images.SetKeyName(24, "")
        Me.ImageList2.Images.SetKeyName(25, "")
        Me.ImageList2.Images.SetKeyName(26, "")
        Me.ImageList2.Images.SetKeyName(27, "")
        Me.ImageList2.Images.SetKeyName(28, "")
        Me.ImageList2.Images.SetKeyName(29, "")
        Me.ImageList2.Images.SetKeyName(30, "")
        Me.ImageList2.Images.SetKeyName(31, "")
        Me.ImageList2.Images.SetKeyName(32, "")
        Me.ImageList2.Images.SetKeyName(33, "")
        Me.ImageList2.Images.SetKeyName(34, "")
        Me.ImageList2.Images.SetKeyName(35, "")
        Me.ImageList2.Images.SetKeyName(36, "")
        Me.ImageList2.Images.SetKeyName(37, "")
        Me.ImageList2.Images.SetKeyName(38, "")
        Me.ImageList2.Images.SetKeyName(39, "")
        Me.ImageList2.Images.SetKeyName(40, "")
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Window
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.pFA)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(383, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(561, 564)
        Me.Panel5.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(457, 470)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 84)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'pFA
        '
        Me.pFA.Image = CType(resources.GetObject("pFA.Image"), System.Drawing.Image)
        Me.pFA.Location = New System.Drawing.Point(0, 119)
        Me.pFA.Name = "pFA"
        Me.pFA.Size = New System.Drawing.Size(557, 288)
        Me.pFA.TabIndex = 3
        Me.pFA.TabStop = False
        '
        'Limg
        '
        Me.Limg.ImageStream = CType(resources.GetObject("Limg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Limg.TransparentColor = System.Drawing.Color.Fuchsia
        Me.Limg.Images.SetKeyName(0, "")
        Me.Limg.Images.SetKeyName(1, "")
        Me.Limg.Images.SetKeyName(2, "")
        Me.Limg.Images.SetKeyName(3, "")
        Me.Limg.Images.SetKeyName(4, "")
        Me.Limg.Images.SetKeyName(5, "")
        Me.Limg.Images.SetKeyName(6, "")
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(944, 564)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "Form1"
        Me.Text = "Main Menu"
        Me.Panel3.ResumeLayout(False)
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pFA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    'Public Function getMenuPanel() As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar
    '    Return UltraExplorerBar1
    'End Function

    Public Function getMenuNavBarControl() As DevExpress.XtraNavBar.NavBarControl
        Return NavBarControl1
    End Function

    Private Function GetAppPath() As String
        Dim f As New IO.DirectoryInfo(Application.ExecutablePath)
        Return f.Parent.FullName
    End Function
    Public Sub CheckPermission()
        Dim dsUser As New DataSet("login")
        dsUser.ReadXml(GetAppPath() & "\login.xml")
        UserName = dsUser.Tables(0).Rows(0).Item("username")

        Dim ch As Boolean = False
        ch = user.CheckAdmin(UserName)
        If user.CheckManager(UserName) = False Then
            If user.CheckAdmin(UserName) = False Then
            Else
            End If
        Else

        End If

        Me.Setup_permission()
        Me.Employee_permission()
        Me.Timekeeping_permission()
        Me.Payroll_permission()

    End Sub
    Private Sub Setup_permission()
    End Sub
    Private Sub Employee_permission()
    End Sub
    Private Sub Timekeeping_permission()
    End Sub
    Private Sub Payroll_permission()
    End Sub
    Private Sub UltraExplorerBar1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Count As Integer = 0
        Dim i, j As Integer
        Dim tabQuyen As DataTable = kn.ReadData("select * from Permission where UserName='" + obj.UserName + "'", "table")
        Dim rowQuyen As DataRow()
        Dim bSetVisible As Boolean
        For i = 0 To NavBarControl1.Items.Count - 1
            bSetVisible = False
            rowQuyen = tabQuyen.Select("FormID='" + NavBarControl1.Items(i).Name + "'")
            If rowQuyen.Length > 0 Then
                If Not IsDBNull(rowQuyen(0)("Quyen")) Then
                    If CStr(rowQuyen(0)("Quyen")).ToUpper = "EDIT" Or CStr(rowQuyen(0)("Quyen")).ToUpper = "VIEW" Then
                        bSetVisible = True
                    End If
                End If
            End If
            If bSetVisible = False Then
                NavBarControl1.Items(i).Visible = False
            End If
        Next

        'For i = 0 To UltraExplorerBar1.Groups.Count - 1
        '    For j = 0 To UltraExplorerBar1.Groups(i).Items.Count - 1
        '        bSetVisible = False
        '        rowQuyen = tabQuyen.Select("FormID='" + UltraExplorerBar1.Groups(i).Items(j).Key + "'")
        '        If rowQuyen.Length > 0 Then
        '            If Not IsDBNull(rowQuyen(0)("Quyen")) Then
        '                If CStr(rowQuyen(0)("Quyen")).ToUpper = "EDIT" Or CStr(rowQuyen(0)("Quyen")).ToUpper = "VIEW" Then
        '                    bSetVisible = True
        '                End If
        '            End If
        '        End If
        '        If bSetVisible = False Then
        '            UltraExplorerBar1.Groups(i).Items(j).Visible = False
        '        End If
        '    Next
        'Next
        'Dim tabSetUp As DataTable = kn.ReadData("select * from setup where ID='KH'", "table")
        'If tabSetUp.Rows.Count > 0 Then
        '    Dim KH As String = tabSetUp.Rows(0)("Value")
        '    Dim KHFromDate, KHToDate As DateTime
        '    KHFromDate = CType(KH.Split("#"c)(0), Date)
        '    KHToDate = CType(KH.Split("#"c)(1), Date)
        '    If Today <= KHToDate And Today >= KHFromDate Then
        '        NavBarControl1.Items("CongBatThuong").Visible = False
        '        'UltraExplorerBar1.Groups("timekeeping").Items("CongBatThuong").Visible = False
        '    End If
        'End If
    End Sub

    Private Sub NavBarControl1_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarControl1.LinkClicked
        RaiseEvent doMenu(e.Link.ItemName)
        'MsgBox("Link " + e.Link.Item.Tag.ToString)
    End Sub
End Class
