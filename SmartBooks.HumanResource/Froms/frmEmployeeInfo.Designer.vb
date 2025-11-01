<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeInfo
    Inherits WindowsControlLibrary.HRFORM

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Friend WithEvents OpenFileDialog1 As OpenFileDialog
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.General = New DevExpress.XtraTab.XtraTabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.MainInformation = New DevExpress.XtraTab.XtraTabPage()
        Me.Nation = New System.Windows.Forms.TextBox()
        Me.lblisTanTat = New System.Windows.Forms.Label()
        Me.isTanTat = New System.Windows.Forms.CheckBox()
        Me.Graduated = New System.Windows.Forms.TextBox()
        Me.TonGiao = New System.Windows.Forms.TextBox()
        Me.lblsectioncode1 = New System.Windows.Forms.Label()
        Me.BirthPlace = New System.Windows.Forms.TextBox()
        Me.NativePlace = New System.Windows.Forms.TextBox()
        Me.btnChup = New DevExpress.XtraEditors.SimpleButton()
        Me.cbbChonCam = New System.Windows.Forms.ComboBox()
        Me.AccountCode3 = New System.Windows.Forms.TextBox()
        Me.lblAccountCode3 = New System.Windows.Forms.Label()
        Me.AccountCode2 = New System.Windows.Forms.TextBox()
        Me.lblAccountCode2 = New System.Windows.Forms.Label()
        Me.Accountcode1 = New System.Windows.Forms.TextBox()
        Me.lblAccountcode1 = New System.Windows.Forms.Label()
        Me.NguoiGT = New System.Windows.Forms.TextBox()
        Me.lblNguoiGT = New System.Windows.Forms.Label()
        Me.lblCamket = New System.Windows.Forms.Label()
        Me.CamKet = New System.Windows.Forms.CheckBox()
        Me.lblIsManager = New System.Windows.Forms.Label()
        Me.isManager = New System.Windows.Forms.CheckBox()
        Me.NgayHetHanCCCD = New DevExpress.XtraEditors.DateEdit()
        Me.lblNgayHetHanCCCD = New System.Windows.Forms.Label()
        Me.PicCam = New System.Windows.Forms.PictureBox()
        Me.btnStopCam = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStartCam = New DevExpress.XtraEditors.SimpleButton()
        Me.ID_place = New System.Windows.Forms.TextBox()
        Me.CCCDCu_Date = New DevExpress.XtraEditors.DateEdit()
        Me.CCCDCu_Place = New System.Windows.Forms.TextBox()
        Me.lblCCCDCu_Place = New System.Windows.Forms.Label()
        Me.lblCCCDCu_Date = New System.Windows.Forms.Label()
        Me.CCCDCu = New System.Windows.Forms.TextBox()
        Me.lblCCCDCu = New System.Windows.Forms.Label()
        Me.lblAnhCCCD = New System.Windows.Forms.Label()
        Me.btnXoaAnhCCCD = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAnhCCCD = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureCCCD = New System.Windows.Forms.PictureBox()
        Me.IsNhapNhanVienMoi = New System.Windows.Forms.CheckBox()
        Me.lblNhapNhanVienMoi = New System.Windows.Forms.Label()
        Me.IsSeasonWorker = New System.Windows.Forms.CheckBox()
        Me.lblSeasonWorker = New System.Windows.Forms.Label()
        Me.EndOfSeasonWorker = New DevExpress.XtraEditors.DateEdit()
        Me.lblEndOfSeasonWorker = New System.Windows.Forms.Label()
        Me.SoNgayPhepNam = New System.Windows.Forms.TextBox()
        Me.InsertDate = New DevExpress.XtraEditors.DateEdit()
        Me.RFID = New System.Windows.Forms.TextBox()
        Me.lblTypeOfHiring = New System.Windows.Forms.Label()
        Me.TypeOfHiring = New DevExpress.XtraEditors.LookUpEdit()
        Me.ResonTerminated = New System.Windows.Forms.TextBox()
        Me.ContractFlow = New DevExpress.XtraEditors.LookUpEdit()
        Me.ID_date = New DevExpress.XtraEditors.DateEdit()
        Me.MaritalStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.Sex = New DevExpress.XtraEditors.LookUpEdit()
        Me.BirthDate = New DevExpress.XtraEditors.DateEdit()
        Me.QuanHeVoiChuHo = New DevExpress.XtraEditors.LookUpEdit()
        Me.Nationality = New DevExpress.XtraEditors.LookUpEdit()
        Me.NgayTGCongDoan = New DevExpress.XtraEditors.DateEdit()
        Me.Qualification = New DevExpress.XtraEditors.LookUpEdit()
        Me.GraduatedFrom = New System.Windows.Forms.TextBox()
        Me.DebitAccount = New System.Windows.Forms.TextBox()
        Me.BankCode = New System.Windows.Forms.TextBox()
        Me.BankAccount = New System.Windows.Forms.TextBox()
        Me.BankName = New System.Windows.Forms.TextBox()
        Me.MaSoThue = New System.Windows.Forms.TextBox()
        Me.Employee_Status = New DevExpress.XtraEditors.LookUpEdit()
        Me.PlanTernimationDate = New DevExpress.XtraEditors.DateEdit()
        Me.TernimationDate = New DevExpress.XtraEditors.DateEdit()
        Me.DecisionStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.ChucDanh = New DevExpress.XtraEditors.LookUpEdit()
        Me.PositionCategory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.Position_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.teamcode = New DevExpress.XtraEditors.LookUpEdit()
        Me.sectioncode = New DevExpress.XtraEditors.LookUpEdit()
        Me.departmentcode = New DevExpress.XtraEditors.LookUpEdit()
        Me.Factory_ID = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeeSearch = New DevExpress.XtraEditors.LookUpEdit()
        Me.OfficialDate = New DevExpress.XtraEditors.DateEdit()
        Me.ComStartedDate = New DevExpress.XtraEditors.DateEdit()
        Me.StartedDate = New DevExpress.XtraEditors.DateEdit()
        Me.IE_FLAG = New System.Windows.Forms.TextBox()
        Me.JobCode = New System.Windows.Forms.TextBox()
        Me.DecisionCode = New System.Windows.Forms.TextBox()
        Me.AbsentStatus = New System.Windows.Forms.TextBox()
        Me.NguoiLienHeGap = New System.Windows.Forms.TextBox()
        Me.TenChuHo = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Tel = New System.Windows.Forms.TextBox()
        Me.ID_number = New System.Windows.Forms.TextBox()
        Me.Employee_Lastname = New System.Windows.Forms.TextBox()
        Me.Employee_Firstname = New System.Windows.Forms.TextBox()
        Me.Card_No = New System.Windows.Forms.TextBox()
        Me.Card_Code = New System.Windows.Forms.TextBox()
        Me.Employee_ID = New System.Windows.Forms.TextBox()
        Me.btnXoaAnh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChonAnh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNgayTGCongDoan = New System.Windows.Forms.Label()
        Me.isThuViec85PhanTram = New System.Windows.Forms.CheckBox()
        Me.lblBookCode = New System.Windows.Forms.Label()
        Me.SoSoBaoHiem = New System.Windows.Forms.TextBox()
        Me.lblQuanHeVoiChuHo = New System.Windows.Forms.Label()
        Me.lblTenChuHo = New System.Windows.Forms.Label()
        Me.lblLeaveType_ID = New System.Windows.Forms.Label()
        Me.BirthDateFormat = New System.Windows.Forms.ComboBox()
        Me.lblRFID = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblPicture = New System.Windows.Forms.Label()
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.lblHealthCheckFee = New System.Windows.Forms.Label()
        Me.HealthCheckFee = New System.Windows.Forms.TextBox()
        Me.lblHospital = New System.Windows.Forms.Label()
        Me.Hospital = New System.Windows.Forms.RichTextBox()
        Me.Weight = New System.Windows.Forms.NumericUpDown()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.Height = New System.Windows.Forms.NumericUpDown()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblDecisionStatus = New System.Windows.Forms.Label()
        Me.lblJobCode = New System.Windows.Forms.Label()
        Me.TanTat = New System.Windows.Forms.RichTextBox()
        Me.lblComStartedDate = New System.Windows.Forms.Label()
        Me.lblNguoiLienHeGap = New System.Windows.Forms.Label()
        Me.lblTanTat = New System.Windows.Forms.Label()
        Me.lblTonGiao = New System.Windows.Forms.Label()
        Me.lblFactory_ID = New System.Windows.Forms.Label()
        Me.Address_Temporary = New WindowsControlLibrary.Address()
        Me.Address_Permanent = New WindowsControlLibrary.Address()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.Remark = New System.Windows.Forms.RichTextBox()
        Me.lblContractFlow = New System.Windows.Forms.Label()
        Me.lblSoNgayPhepNam = New System.Windows.Forms.Label()
        Me.lblThongTinKhac = New System.Windows.Forms.Label()
        Me.lblQualification = New System.Windows.Forms.Label()
        Me.lblGraduated = New System.Windows.Forms.Label()
        Me.lblGraduatedFrom = New System.Windows.Forms.Label()
        Me.lblTrinhDoChuyenMon = New System.Windows.Forms.Label()
        Me.lblThongTinLienLac = New System.Windows.Forms.Label()
        Me.lblThongTinNganHangThe = New System.Windows.Forms.Label()
        Me.lblTrangThaiLamViec = New System.Windows.Forms.Label()
        Me.lblThongTinChinh = New System.Windows.Forms.Label()
        Me.lblBirthPlace = New System.Windows.Forms.Label()
        Me.lblAddress_Permanent = New System.Windows.Forms.Label()
        Me.lblAddress_Temporary = New System.Windows.Forms.Label()
        Me.lblDebitAccount = New System.Windows.Forms.Label()
        Me.lblBankCode = New System.Windows.Forms.Label()
        Me.lblBankName = New System.Windows.Forms.Label()
        Me.lblBankAccount = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblTel = New System.Windows.Forms.Label()
        Me.lblNation = New System.Windows.Forms.Label()
        Me.lblNationality = New System.Windows.Forms.Label()
        Me.lbNativePlace = New System.Windows.Forms.Label()
        Me.lblsectioncode = New System.Windows.Forms.Label()
        Me.lblChucDanh = New System.Windows.Forms.Label()
        Me.lblCard_No = New System.Windows.Forms.Label()
        Me.lblCard_Code = New System.Windows.Forms.Label()
        Me.lblCongViecPhaiLam = New System.Windows.Forms.Label()
        Me.CongViecPhaiLam = New System.Windows.Forms.RichTextBox()
        Me.lblMaSoThue = New System.Windows.Forms.Label()
        Me.lblDecisionCode = New System.Windows.Forms.Label()
        Me.lblPlanTernimationDate = New System.Windows.Forms.Label()
        Me.lblteamcode = New System.Windows.Forms.Label()
        Me.lblOfficialDate = New System.Windows.Forms.Label()
        Me.lbldepartmentcode = New System.Windows.Forms.Label()
        Me.lblEmployee_ID = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblBirthDate = New System.Windows.Forms.Label()
        Me.lblSex = New System.Windows.Forms.Label()
        Me.lblPosition_ID = New System.Windows.Forms.Label()
        Me.lblTernimationDate = New System.Windows.Forms.Label()
        Me.lblPositionCategory_ID = New System.Windows.Forms.Label()
        Me.lbStartedDate = New System.Windows.Forms.Label()
        Me.lblEmployee_Status = New System.Windows.Forms.Label()
        Me.lblID_number = New System.Windows.Forms.Label()
        Me.lblID_date = New System.Windows.Forms.Label()
        Me.lblID_place = New System.Windows.Forms.Label()
        Me.lblResonTerminated = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.TextBox()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblInsertDate = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NhapNVMoi = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Utilities = New DevExpress.XtraTab.XtraTabPage()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TruongCapNhat = New DevExpress.XtraEditors.LookUpEdit()
        Me.Url = New System.Windows.Forms.TextBox()
        Me.btnNhapAnh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNhap = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUrl = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLayTemplate = New DevExpress.XtraEditors.SimpleButton()
        Me.gbDoiMaNhanVien = New System.Windows.Forms.GroupBox()
        Me.txtMaNVMoi = New System.Windows.Forms.TextBox()
        Me.txtMaNVCu = New System.Windows.Forms.TextBox()
        Me.btnDoiMaNV = New DevExpress.XtraEditors.SimpleButton()
        Me.lblMaMoi = New System.Windows.Forms.Label()
        Me.lblMaCu = New System.Windows.Forms.Label()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.MainInformation.SuspendLayout()
        CType(Me.NgayHetHanCCCD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayHetHanCCCD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCCDCu_Date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCCDCu_Date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureCCCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EndOfSeasonWorker.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EndOfSeasonWorker.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeOfHiring.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ID_date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ID_date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaritalStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sex.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BirthDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BirthDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuanHeVoiChuHo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nationality.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayTGCongDoan.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayTGCongDoan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Qualification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Employee_Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanTernimationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanTernimationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TernimationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TernimationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DecisionStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChucDanh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Position_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teamcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sectioncode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.departmentcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Factory_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficialDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficialDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComStartedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComStartedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Weight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Height, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NhapNVMoi.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Utilities.SuspendLayout()
        CType(Me.TruongCapNhat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDoiMaNhanVien.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelButton
        '
        Me.PanelButton.Location = New System.Drawing.Point(0, 791)
        Me.PanelButton.Size = New System.Drawing.Size(1530, 55)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.General
        Me.XtraTabControl1.Size = New System.Drawing.Size(1530, 791)
        Me.XtraTabControl1.TabIndex = 1009
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.General, Me.NhapNVMoi, Me.Utilities})
        '
        'General
        '
        Me.General.Controls.Add(Me.Panel1)
        Me.General.Controls.Add(Me.Splitter1)
        Me.General.Controls.Add(Me.GridControl1)
        Me.General.Name = "General"
        Me.General.Size = New System.Drawing.Size(1528, 766)
        Me.General.Text = "General"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.XtraTabControl2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(323, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(1205, 766)
        Me.Panel1.TabIndex = 1324
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.Appearance.BackColor = System.Drawing.Color.White
        Me.XtraTabControl2.Appearance.ForeColor = System.Drawing.Color.White
        Me.XtraTabControl2.Appearance.Options.UseBackColor = True
        Me.XtraTabControl2.Appearance.Options.UseForeColor = True
        Me.XtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl2.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.MainInformation
        Me.XtraTabControl2.Size = New System.Drawing.Size(1205, 766)
        Me.XtraTabControl2.TabIndex = 1325
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.MainInformation})
        '
        'MainInformation
        '
        Me.MainInformation.Appearance.PageClient.BackColor = System.Drawing.Color.White
        Me.MainInformation.Appearance.PageClient.Options.UseBackColor = True
        Me.MainInformation.AutoScroll = True
        Me.MainInformation.Controls.Add(Me.Nation)
        Me.MainInformation.Controls.Add(Me.lblisTanTat)
        Me.MainInformation.Controls.Add(Me.isTanTat)
        Me.MainInformation.Controls.Add(Me.Graduated)
        Me.MainInformation.Controls.Add(Me.TonGiao)
        Me.MainInformation.Controls.Add(Me.lblsectioncode1)
        Me.MainInformation.Controls.Add(Me.BirthPlace)
        Me.MainInformation.Controls.Add(Me.NativePlace)
        Me.MainInformation.Controls.Add(Me.btnChup)
        Me.MainInformation.Controls.Add(Me.cbbChonCam)
        Me.MainInformation.Controls.Add(Me.AccountCode3)
        Me.MainInformation.Controls.Add(Me.lblAccountCode3)
        Me.MainInformation.Controls.Add(Me.AccountCode2)
        Me.MainInformation.Controls.Add(Me.lblAccountCode2)
        Me.MainInformation.Controls.Add(Me.Accountcode1)
        Me.MainInformation.Controls.Add(Me.lblAccountcode1)
        Me.MainInformation.Controls.Add(Me.NguoiGT)
        Me.MainInformation.Controls.Add(Me.lblNguoiGT)
        Me.MainInformation.Controls.Add(Me.lblCamket)
        Me.MainInformation.Controls.Add(Me.CamKet)
        Me.MainInformation.Controls.Add(Me.lblIsManager)
        Me.MainInformation.Controls.Add(Me.isManager)
        Me.MainInformation.Controls.Add(Me.NgayHetHanCCCD)
        Me.MainInformation.Controls.Add(Me.lblNgayHetHanCCCD)
        Me.MainInformation.Controls.Add(Me.PicCam)
        Me.MainInformation.Controls.Add(Me.btnStopCam)
        Me.MainInformation.Controls.Add(Me.btnStartCam)
        Me.MainInformation.Controls.Add(Me.ID_place)
        Me.MainInformation.Controls.Add(Me.CCCDCu_Date)
        Me.MainInformation.Controls.Add(Me.CCCDCu_Place)
        Me.MainInformation.Controls.Add(Me.lblCCCDCu_Place)
        Me.MainInformation.Controls.Add(Me.lblCCCDCu_Date)
        Me.MainInformation.Controls.Add(Me.CCCDCu)
        Me.MainInformation.Controls.Add(Me.lblCCCDCu)
        Me.MainInformation.Controls.Add(Me.lblAnhCCCD)
        Me.MainInformation.Controls.Add(Me.btnXoaAnhCCCD)
        Me.MainInformation.Controls.Add(Me.btnChonAnhCCCD)
        Me.MainInformation.Controls.Add(Me.PictureCCCD)
        Me.MainInformation.Controls.Add(Me.IsNhapNhanVienMoi)
        Me.MainInformation.Controls.Add(Me.lblNhapNhanVienMoi)
        Me.MainInformation.Controls.Add(Me.IsSeasonWorker)
        Me.MainInformation.Controls.Add(Me.lblSeasonWorker)
        Me.MainInformation.Controls.Add(Me.EndOfSeasonWorker)
        Me.MainInformation.Controls.Add(Me.lblEndOfSeasonWorker)
        Me.MainInformation.Controls.Add(Me.SoNgayPhepNam)
        Me.MainInformation.Controls.Add(Me.InsertDate)
        Me.MainInformation.Controls.Add(Me.RFID)
        Me.MainInformation.Controls.Add(Me.lblTypeOfHiring)
        Me.MainInformation.Controls.Add(Me.TypeOfHiring)
        Me.MainInformation.Controls.Add(Me.ResonTerminated)
        Me.MainInformation.Controls.Add(Me.ContractFlow)
        Me.MainInformation.Controls.Add(Me.ID_date)
        Me.MainInformation.Controls.Add(Me.MaritalStatus)
        Me.MainInformation.Controls.Add(Me.Sex)
        Me.MainInformation.Controls.Add(Me.BirthDate)
        Me.MainInformation.Controls.Add(Me.QuanHeVoiChuHo)
        Me.MainInformation.Controls.Add(Me.Nationality)
        Me.MainInformation.Controls.Add(Me.NgayTGCongDoan)
        Me.MainInformation.Controls.Add(Me.Qualification)
        Me.MainInformation.Controls.Add(Me.GraduatedFrom)
        Me.MainInformation.Controls.Add(Me.DebitAccount)
        Me.MainInformation.Controls.Add(Me.BankCode)
        Me.MainInformation.Controls.Add(Me.BankAccount)
        Me.MainInformation.Controls.Add(Me.BankName)
        Me.MainInformation.Controls.Add(Me.MaSoThue)
        Me.MainInformation.Controls.Add(Me.Employee_Status)
        Me.MainInformation.Controls.Add(Me.PlanTernimationDate)
        Me.MainInformation.Controls.Add(Me.TernimationDate)
        Me.MainInformation.Controls.Add(Me.DecisionStatus)
        Me.MainInformation.Controls.Add(Me.ChucDanh)
        Me.MainInformation.Controls.Add(Me.PositionCategory_ID)
        Me.MainInformation.Controls.Add(Me.Position_ID)
        Me.MainInformation.Controls.Add(Me.teamcode)
        Me.MainInformation.Controls.Add(Me.sectioncode)
        Me.MainInformation.Controls.Add(Me.departmentcode)
        Me.MainInformation.Controls.Add(Me.Factory_ID)
        Me.MainInformation.Controls.Add(Me.EmployeeSearch)
        Me.MainInformation.Controls.Add(Me.OfficialDate)
        Me.MainInformation.Controls.Add(Me.ComStartedDate)
        Me.MainInformation.Controls.Add(Me.StartedDate)
        Me.MainInformation.Controls.Add(Me.IE_FLAG)
        Me.MainInformation.Controls.Add(Me.JobCode)
        Me.MainInformation.Controls.Add(Me.DecisionCode)
        Me.MainInformation.Controls.Add(Me.AbsentStatus)
        Me.MainInformation.Controls.Add(Me.NguoiLienHeGap)
        Me.MainInformation.Controls.Add(Me.TenChuHo)
        Me.MainInformation.Controls.Add(Me.Email)
        Me.MainInformation.Controls.Add(Me.Tel)
        Me.MainInformation.Controls.Add(Me.ID_number)
        Me.MainInformation.Controls.Add(Me.Employee_Lastname)
        Me.MainInformation.Controls.Add(Me.Employee_Firstname)
        Me.MainInformation.Controls.Add(Me.Card_No)
        Me.MainInformation.Controls.Add(Me.Card_Code)
        Me.MainInformation.Controls.Add(Me.Employee_ID)
        Me.MainInformation.Controls.Add(Me.btnXoaAnh)
        Me.MainInformation.Controls.Add(Me.btnChonAnh)
        Me.MainInformation.Controls.Add(Me.btnSearch)
        Me.MainInformation.Controls.Add(Me.lblNgayTGCongDoan)
        Me.MainInformation.Controls.Add(Me.isThuViec85PhanTram)
        Me.MainInformation.Controls.Add(Me.lblBookCode)
        Me.MainInformation.Controls.Add(Me.SoSoBaoHiem)
        Me.MainInformation.Controls.Add(Me.lblQuanHeVoiChuHo)
        Me.MainInformation.Controls.Add(Me.lblTenChuHo)
        Me.MainInformation.Controls.Add(Me.lblLeaveType_ID)
        Me.MainInformation.Controls.Add(Me.BirthDateFormat)
        Me.MainInformation.Controls.Add(Me.lblRFID)
        Me.MainInformation.Controls.Add(Me.lblSearch)
        Me.MainInformation.Controls.Add(Me.lblPicture)
        Me.MainInformation.Controls.Add(Me.Picture)
        Me.MainInformation.Controls.Add(Me.lblHealthCheckFee)
        Me.MainInformation.Controls.Add(Me.HealthCheckFee)
        Me.MainInformation.Controls.Add(Me.lblHospital)
        Me.MainInformation.Controls.Add(Me.Hospital)
        Me.MainInformation.Controls.Add(Me.Weight)
        Me.MainInformation.Controls.Add(Me.lblWeight)
        Me.MainInformation.Controls.Add(Me.Height)
        Me.MainInformation.Controls.Add(Me.lblHeight)
        Me.MainInformation.Controls.Add(Me.lblDecisionStatus)
        Me.MainInformation.Controls.Add(Me.lblJobCode)
        Me.MainInformation.Controls.Add(Me.TanTat)
        Me.MainInformation.Controls.Add(Me.lblComStartedDate)
        Me.MainInformation.Controls.Add(Me.lblNguoiLienHeGap)
        Me.MainInformation.Controls.Add(Me.lblTanTat)
        Me.MainInformation.Controls.Add(Me.lblTonGiao)
        Me.MainInformation.Controls.Add(Me.lblFactory_ID)
        Me.MainInformation.Controls.Add(Me.Address_Temporary)
        Me.MainInformation.Controls.Add(Me.Address_Permanent)
        Me.MainInformation.Controls.Add(Me.lblRemark)
        Me.MainInformation.Controls.Add(Me.Remark)
        Me.MainInformation.Controls.Add(Me.lblContractFlow)
        Me.MainInformation.Controls.Add(Me.lblSoNgayPhepNam)
        Me.MainInformation.Controls.Add(Me.lblThongTinKhac)
        Me.MainInformation.Controls.Add(Me.lblQualification)
        Me.MainInformation.Controls.Add(Me.lblGraduated)
        Me.MainInformation.Controls.Add(Me.lblGraduatedFrom)
        Me.MainInformation.Controls.Add(Me.lblTrinhDoChuyenMon)
        Me.MainInformation.Controls.Add(Me.lblThongTinLienLac)
        Me.MainInformation.Controls.Add(Me.lblThongTinNganHangThe)
        Me.MainInformation.Controls.Add(Me.lblTrangThaiLamViec)
        Me.MainInformation.Controls.Add(Me.lblThongTinChinh)
        Me.MainInformation.Controls.Add(Me.lblBirthPlace)
        Me.MainInformation.Controls.Add(Me.lblAddress_Permanent)
        Me.MainInformation.Controls.Add(Me.lblAddress_Temporary)
        Me.MainInformation.Controls.Add(Me.lblDebitAccount)
        Me.MainInformation.Controls.Add(Me.lblBankCode)
        Me.MainInformation.Controls.Add(Me.lblBankName)
        Me.MainInformation.Controls.Add(Me.lblBankAccount)
        Me.MainInformation.Controls.Add(Me.lblEmail)
        Me.MainInformation.Controls.Add(Me.lblTel)
        Me.MainInformation.Controls.Add(Me.lblNation)
        Me.MainInformation.Controls.Add(Me.lblNationality)
        Me.MainInformation.Controls.Add(Me.lbNativePlace)
        Me.MainInformation.Controls.Add(Me.lblsectioncode)
        Me.MainInformation.Controls.Add(Me.lblChucDanh)
        Me.MainInformation.Controls.Add(Me.lblCard_No)
        Me.MainInformation.Controls.Add(Me.lblCard_Code)
        Me.MainInformation.Controls.Add(Me.lblCongViecPhaiLam)
        Me.MainInformation.Controls.Add(Me.CongViecPhaiLam)
        Me.MainInformation.Controls.Add(Me.lblMaSoThue)
        Me.MainInformation.Controls.Add(Me.lblDecisionCode)
        Me.MainInformation.Controls.Add(Me.lblPlanTernimationDate)
        Me.MainInformation.Controls.Add(Me.lblteamcode)
        Me.MainInformation.Controls.Add(Me.lblOfficialDate)
        Me.MainInformation.Controls.Add(Me.lbldepartmentcode)
        Me.MainInformation.Controls.Add(Me.lblEmployee_ID)
        Me.MainInformation.Controls.Add(Me.lblFullName)
        Me.MainInformation.Controls.Add(Me.lblBirthDate)
        Me.MainInformation.Controls.Add(Me.lblSex)
        Me.MainInformation.Controls.Add(Me.lblPosition_ID)
        Me.MainInformation.Controls.Add(Me.lblTernimationDate)
        Me.MainInformation.Controls.Add(Me.lblPositionCategory_ID)
        Me.MainInformation.Controls.Add(Me.lbStartedDate)
        Me.MainInformation.Controls.Add(Me.lblEmployee_Status)
        Me.MainInformation.Controls.Add(Me.lblID_number)
        Me.MainInformation.Controls.Add(Me.lblID_date)
        Me.MainInformation.Controls.Add(Me.lblID_place)
        Me.MainInformation.Controls.Add(Me.lblResonTerminated)
        Me.MainInformation.Controls.Add(Me.UserName)
        Me.MainInformation.Controls.Add(Me.lblUserName)
        Me.MainInformation.Controls.Add(Me.lblInsertDate)
        Me.MainInformation.Name = "MainInformation"
        Me.MainInformation.Size = New System.Drawing.Size(1203, 741)
        Me.MainInformation.Text = "Main Information"
        '
        'Nation
        '
        Me.Nation.Location = New System.Drawing.Point(291, 374)
        Me.Nation.Name = "Nation"
        Me.Nation.Size = New System.Drawing.Size(90, 21)
        Me.Nation.TabIndex = 1560
        '
        'lblisTanTat
        '
        Me.lblisTanTat.BackColor = System.Drawing.Color.Transparent
        Me.lblisTanTat.Location = New System.Drawing.Point(618, 313)
        Me.lblisTanTat.Name = "lblisTanTat"
        Me.lblisTanTat.Size = New System.Drawing.Size(99, 20)
        Me.lblisTanTat.TabIndex = 1559
        Me.lblisTanTat.Text = "Bị tàn tật"
        Me.lblisTanTat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'isTanTat
        '
        Me.isTanTat.AutoSize = True
        Me.isTanTat.Location = New System.Drawing.Point(734, 318)
        Me.isTanTat.Name = "isTanTat"
        Me.isTanTat.Size = New System.Drawing.Size(15, 14)
        Me.isTanTat.TabIndex = 1558
        Me.isTanTat.UseVisualStyleBackColor = True
        '
        'Graduated
        '
        Me.Graduated.Location = New System.Drawing.Point(1020, 277)
        Me.Graduated.Name = "Graduated"
        Me.Graduated.Size = New System.Drawing.Size(190, 21)
        Me.Graduated.TabIndex = 1557
        '
        'TonGiao
        '
        Me.TonGiao.Location = New System.Drawing.Point(481, 375)
        Me.TonGiao.Name = "TonGiao"
        Me.TonGiao.Size = New System.Drawing.Size(107, 21)
        Me.TonGiao.TabIndex = 1556
        '
        'lblsectioncode1
        '
        Me.lblsectioncode1.BackColor = System.Drawing.Color.Transparent
        Me.lblsectioncode1.Location = New System.Drawing.Point(299, 161)
        Me.lblsectioncode1.Name = "lblsectioncode1"
        Me.lblsectioncode1.Size = New System.Drawing.Size(122, 19)
        Me.lblsectioncode1.TabIndex = 1555
        Me.lblsectioncode1.Text = "Loại chức vụ"
        Me.lblsectioncode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BirthPlace
        '
        Me.BirthPlace.Location = New System.Drawing.Point(105, 422)
        Me.BirthPlace.Name = "BirthPlace"
        Me.BirthPlace.Size = New System.Drawing.Size(116, 21)
        Me.BirthPlace.TabIndex = 1554
        '
        'NativePlace
        '
        Me.NativePlace.Location = New System.Drawing.Point(105, 446)
        Me.NativePlace.Name = "NativePlace"
        Me.NativePlace.Size = New System.Drawing.Size(116, 21)
        Me.NativePlace.TabIndex = 1553
        '
        'btnChup
        '
        Me.btnChup.Location = New System.Drawing.Point(8, 665)
        Me.btnChup.Name = "btnChup"
        Me.btnChup.Size = New System.Drawing.Size(85, 22)
        Me.btnChup.TabIndex = 1552
        Me.btnChup.Text = "Chụp ảnh NV"
        '
        'cbbChonCam
        '
        Me.cbbChonCam.FormattingEnabled = True
        Me.cbbChonCam.Items.AddRange(New Object() {"dd/MM/yyyy", "MM/yyyy", "yyyy"})
        Me.cbbChonCam.Location = New System.Drawing.Point(8, 638)
        Me.cbbChonCam.Name = "cbbChonCam"
        Me.cbbChonCam.Size = New System.Drawing.Size(86, 21)
        Me.cbbChonCam.TabIndex = 1551
        '
        'AccountCode3
        '
        Me.AccountCode3.Location = New System.Drawing.Point(934, 670)
        Me.AccountCode3.Name = "AccountCode3"
        Me.AccountCode3.Size = New System.Drawing.Size(106, 21)
        Me.AccountCode3.TabIndex = 1550
        Me.AccountCode3.Visible = False
        '
        'lblAccountCode3
        '
        Me.lblAccountCode3.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountCode3.Location = New System.Drawing.Point(849, 669)
        Me.lblAccountCode3.Name = "lblAccountCode3"
        Me.lblAccountCode3.Size = New System.Drawing.Size(79, 19)
        Me.lblAccountCode3.TabIndex = 1549
        Me.lblAccountCode3.Text = "AccountCode3"
        Me.lblAccountCode3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountCode3.Visible = False
        '
        'AccountCode2
        '
        Me.AccountCode2.Location = New System.Drawing.Point(934, 643)
        Me.AccountCode2.Name = "AccountCode2"
        Me.AccountCode2.Size = New System.Drawing.Size(106, 21)
        Me.AccountCode2.TabIndex = 1548
        Me.AccountCode2.Visible = False
        '
        'lblAccountCode2
        '
        Me.lblAccountCode2.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountCode2.Location = New System.Drawing.Point(849, 642)
        Me.lblAccountCode2.Name = "lblAccountCode2"
        Me.lblAccountCode2.Size = New System.Drawing.Size(79, 19)
        Me.lblAccountCode2.TabIndex = 1547
        Me.lblAccountCode2.Text = "AccountCode2"
        Me.lblAccountCode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountCode2.Visible = False
        '
        'Accountcode1
        '
        Me.Accountcode1.Location = New System.Drawing.Point(734, 667)
        Me.Accountcode1.Name = "Accountcode1"
        Me.Accountcode1.Size = New System.Drawing.Size(106, 21)
        Me.Accountcode1.TabIndex = 1546
        Me.Accountcode1.Visible = False
        '
        'lblAccountcode1
        '
        Me.lblAccountcode1.BackColor = System.Drawing.Color.Transparent
        Me.lblAccountcode1.Location = New System.Drawing.Point(649, 666)
        Me.lblAccountcode1.Name = "lblAccountcode1"
        Me.lblAccountcode1.Size = New System.Drawing.Size(79, 19)
        Me.lblAccountcode1.TabIndex = 1545
        Me.lblAccountcode1.Text = "AccountCode1"
        Me.lblAccountcode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAccountcode1.Visible = False
        '
        'NguoiGT
        '
        Me.NguoiGT.Location = New System.Drawing.Point(734, 642)
        Me.NguoiGT.Name = "NguoiGT"
        Me.NguoiGT.Size = New System.Drawing.Size(106, 21)
        Me.NguoiGT.TabIndex = 1544
        Me.NguoiGT.Visible = False
        '
        'lblNguoiGT
        '
        Me.lblNguoiGT.BackColor = System.Drawing.Color.Transparent
        Me.lblNguoiGT.Location = New System.Drawing.Point(649, 641)
        Me.lblNguoiGT.Name = "lblNguoiGT"
        Me.lblNguoiGT.Size = New System.Drawing.Size(79, 19)
        Me.lblNguoiGT.TabIndex = 1543
        Me.lblNguoiGT.Text = "Người GT"
        Me.lblNguoiGT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNguoiGT.Visible = False
        '
        'lblCamket
        '
        Me.lblCamket.BackColor = System.Drawing.Color.Transparent
        Me.lblCamket.Location = New System.Drawing.Point(649, 616)
        Me.lblCamket.Name = "lblCamket"
        Me.lblCamket.Size = New System.Drawing.Size(99, 20)
        Me.lblCamket.TabIndex = 1542
        Me.lblCamket.Text = "Cam kết"
        Me.lblCamket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCamket.Visible = False
        '
        'CamKet
        '
        Me.CamKet.AutoSize = True
        Me.CamKet.Location = New System.Drawing.Point(754, 620)
        Me.CamKet.Name = "CamKet"
        Me.CamKet.Size = New System.Drawing.Size(15, 14)
        Me.CamKet.TabIndex = 1541
        Me.CamKet.UseVisualStyleBackColor = True
        Me.CamKet.Visible = False
        '
        'lblIsManager
        '
        Me.lblIsManager.BackColor = System.Drawing.Color.Transparent
        Me.lblIsManager.Location = New System.Drawing.Point(618, 288)
        Me.lblIsManager.Name = "lblIsManager"
        Me.lblIsManager.Size = New System.Drawing.Size(99, 20)
        Me.lblIsManager.TabIndex = 1540
        Me.lblIsManager.Text = "Là Quản lý"
        Me.lblIsManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'isManager
        '
        Me.isManager.AutoSize = True
        Me.isManager.Location = New System.Drawing.Point(734, 292)
        Me.isManager.Name = "isManager"
        Me.isManager.Size = New System.Drawing.Size(15, 14)
        Me.isManager.TabIndex = 1539
        Me.isManager.UseVisualStyleBackColor = True
        '
        'NgayHetHanCCCD
        '
        Me.NgayHetHanCCCD.EditValue = Nothing
        Me.NgayHetHanCCCD.Location = New System.Drawing.Point(430, 339)
        Me.NgayHetHanCCCD.Name = "NgayHetHanCCCD"
        Me.NgayHetHanCCCD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayHetHanCCCD.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayHetHanCCCD.Properties.DisplayFormat.FormatString = ""
        Me.NgayHetHanCCCD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayHetHanCCCD.Properties.EditFormat.FormatString = ""
        Me.NgayHetHanCCCD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayHetHanCCCD.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.NgayHetHanCCCD.Properties.MaskSettings.Set("mask", "d")
        Me.NgayHetHanCCCD.Properties.UseMaskAsDisplayFormat = True
        Me.NgayHetHanCCCD.Size = New System.Drawing.Size(173, 20)
        Me.NgayHetHanCCCD.TabIndex = 1538
        '
        'lblNgayHetHanCCCD
        '
        Me.lblNgayHetHanCCCD.BackColor = System.Drawing.Color.Transparent
        Me.lblNgayHetHanCCCD.Location = New System.Drawing.Point(302, 339)
        Me.lblNgayHetHanCCCD.Name = "lblNgayHetHanCCCD"
        Me.lblNgayHetHanCCCD.Size = New System.Drawing.Size(99, 19)
        Me.lblNgayHetHanCCCD.TabIndex = 1537
        Me.lblNgayHetHanCCCD.Text = "Ngày hết CCCD"
        Me.lblNgayHetHanCCCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicCam
        '
        Me.PicCam.BackColor = System.Drawing.Color.Transparent
        Me.PicCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicCam.Location = New System.Drawing.Point(100, 577)
        Me.PicCam.Margin = New System.Windows.Forms.Padding(0)
        Me.PicCam.Name = "PicCam"
        Me.PicCam.Size = New System.Drawing.Size(190, 83)
        Me.PicCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicCam.TabIndex = 1536
        Me.PicCam.TabStop = False
        '
        'btnStopCam
        '
        Me.btnStopCam.Location = New System.Drawing.Point(9, 610)
        Me.btnStopCam.Name = "btnStopCam"
        Me.btnStopCam.Size = New System.Drawing.Size(85, 22)
        Me.btnStopCam.TabIndex = 1535
        Me.btnStopCam.Text = "Tắt Cam"
        '
        'btnStartCam
        '
        Me.btnStartCam.Location = New System.Drawing.Point(8, 582)
        Me.btnStartCam.Name = "btnStartCam"
        Me.btnStartCam.Size = New System.Drawing.Size(85, 22)
        Me.btnStartCam.TabIndex = 1534
        Me.btnStartCam.Text = "Bật Cam"
        '
        'ID_place
        '
        Me.ID_place.Location = New System.Drawing.Point(430, 314)
        Me.ID_place.Name = "ID_place"
        Me.ID_place.Size = New System.Drawing.Size(173, 21)
        Me.ID_place.TabIndex = 1533
        '
        'CCCDCu_Date
        '
        Me.CCCDCu_Date.EditValue = Nothing
        Me.CCCDCu_Date.Location = New System.Drawing.Point(481, 398)
        Me.CCCDCu_Date.Name = "CCCDCu_Date"
        Me.CCCDCu_Date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CCCDCu_Date.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CCCDCu_Date.Properties.DisplayFormat.FormatString = ""
        Me.CCCDCu_Date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CCCDCu_Date.Properties.EditFormat.FormatString = ""
        Me.CCCDCu_Date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CCCDCu_Date.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.CCCDCu_Date.Properties.MaskSettings.Set("mask", "d")
        Me.CCCDCu_Date.Properties.UseMaskAsDisplayFormat = True
        Me.CCCDCu_Date.Size = New System.Drawing.Size(106, 20)
        Me.CCCDCu_Date.TabIndex = 1532
        '
        'CCCDCu_Place
        '
        Me.CCCDCu_Place.Location = New System.Drawing.Point(702, 399)
        Me.CCCDCu_Place.Name = "CCCDCu_Place"
        Me.CCCDCu_Place.Size = New System.Drawing.Size(88, 21)
        Me.CCCDCu_Place.TabIndex = 1531
        '
        'lblCCCDCu_Place
        '
        Me.lblCCCDCu_Place.BackColor = System.Drawing.Color.Transparent
        Me.lblCCCDCu_Place.Location = New System.Drawing.Point(598, 398)
        Me.lblCCCDCu_Place.Name = "lblCCCDCu_Place"
        Me.lblCCCDCu_Place.Size = New System.Drawing.Size(98, 19)
        Me.lblCCCDCu_Place.TabIndex = 1530
        Me.lblCCCDCu_Place.Text = "Đ/C CCCD cũ"
        Me.lblCCCDCu_Place.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCCCDCu_Date
        '
        Me.lblCCCDCu_Date.BackColor = System.Drawing.Color.Transparent
        Me.lblCCCDCu_Date.Location = New System.Drawing.Point(392, 399)
        Me.lblCCCDCu_Date.Name = "lblCCCDCu_Date"
        Me.lblCCCDCu_Date.Size = New System.Drawing.Size(79, 19)
        Me.lblCCCDCu_Date.TabIndex = 1528
        Me.lblCCCDCu_Date.Text = "Ngày CCCD cũ "
        Me.lblCCCDCu_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CCCDCu
        '
        Me.CCCDCu.Location = New System.Drawing.Point(291, 397)
        Me.CCCDCu.Name = "CCCDCu"
        Me.CCCDCu.Size = New System.Drawing.Size(90, 21)
        Me.CCCDCu.TabIndex = 1527
        '
        'lblCCCDCu
        '
        Me.lblCCCDCu.BackColor = System.Drawing.Color.Transparent
        Me.lblCCCDCu.Location = New System.Drawing.Point(202, 397)
        Me.lblCCCDCu.Name = "lblCCCDCu"
        Me.lblCCCDCu.Size = New System.Drawing.Size(79, 19)
        Me.lblCCCDCu.TabIndex = 1526
        Me.lblCCCDCu.Text = "CCCD Cũ"
        Me.lblCCCDCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAnhCCCD
        '
        Me.lblAnhCCCD.BackColor = System.Drawing.Color.Transparent
        Me.lblAnhCCCD.Location = New System.Drawing.Point(909, 164)
        Me.lblAnhCCCD.Name = "lblAnhCCCD"
        Me.lblAnhCCCD.Size = New System.Drawing.Size(108, 19)
        Me.lblAnhCCCD.TabIndex = 1525
        Me.lblAnhCCCD.Text = "Ảnh CCCD"
        Me.lblAnhCCCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnXoaAnhCCCD
        '
        Me.btnXoaAnhCCCD.Location = New System.Drawing.Point(1132, 227)
        Me.btnXoaAnhCCCD.Name = "btnXoaAnhCCCD"
        Me.btnXoaAnhCCCD.Size = New System.Drawing.Size(85, 22)
        Me.btnXoaAnhCCCD.TabIndex = 1524
        Me.btnXoaAnhCCCD.Text = "Xóa ảnh CCCD"
        '
        'btnChonAnhCCCD
        '
        Me.btnChonAnhCCCD.Location = New System.Drawing.Point(1029, 227)
        Me.btnChonAnhCCCD.Name = "btnChonAnhCCCD"
        Me.btnChonAnhCCCD.Size = New System.Drawing.Size(85, 22)
        Me.btnChonAnhCCCD.TabIndex = 1523
        Me.btnChonAnhCCCD.Text = "Chọn ảnh CCCD"
        '
        'PictureCCCD
        '
        Me.PictureCCCD.BackColor = System.Drawing.Color.Transparent
        Me.PictureCCCD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureCCCD.Location = New System.Drawing.Point(1029, 140)
        Me.PictureCCCD.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureCCCD.Name = "PictureCCCD"
        Me.PictureCCCD.Size = New System.Drawing.Size(190, 83)
        Me.PictureCCCD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureCCCD.TabIndex = 1522
        Me.PictureCCCD.TabStop = False
        '
        'IsNhapNhanVienMoi
        '
        Me.IsNhapNhanVienMoi.AutoSize = True
        Me.IsNhapNhanVienMoi.Location = New System.Drawing.Point(585, 14)
        Me.IsNhapNhanVienMoi.Name = "IsNhapNhanVienMoi"
        Me.IsNhapNhanVienMoi.Size = New System.Drawing.Size(15, 14)
        Me.IsNhapNhanVienMoi.TabIndex = 1521
        Me.IsNhapNhanVienMoi.UseVisualStyleBackColor = True
        '
        'lblNhapNhanVienMoi
        '
        Me.lblNhapNhanVienMoi.BackColor = System.Drawing.Color.Transparent
        Me.lblNhapNhanVienMoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNhapNhanVienMoi.Location = New System.Drawing.Point(428, 14)
        Me.lblNhapNhanVienMoi.Name = "lblNhapNhanVienMoi"
        Me.lblNhapNhanVienMoi.Size = New System.Drawing.Size(138, 16)
        Me.lblNhapNhanVienMoi.TabIndex = 1520
        Me.lblNhapNhanVienMoi.Text = "Trạng thái làm việc"
        '
        'IsSeasonWorker
        '
        Me.IsSeasonWorker.AutoSize = True
        Me.IsSeasonWorker.Location = New System.Drawing.Point(947, 620)
        Me.IsSeasonWorker.Name = "IsSeasonWorker"
        Me.IsSeasonWorker.Size = New System.Drawing.Size(15, 14)
        Me.IsSeasonWorker.TabIndex = 1519
        Me.IsSeasonWorker.UseVisualStyleBackColor = True
        Me.IsSeasonWorker.Visible = False
        '
        'lblSeasonWorker
        '
        Me.lblSeasonWorker.BackColor = System.Drawing.Color.Transparent
        Me.lblSeasonWorker.Location = New System.Drawing.Point(831, 616)
        Me.lblSeasonWorker.Name = "lblSeasonWorker"
        Me.lblSeasonWorker.Size = New System.Drawing.Size(99, 20)
        Me.lblSeasonWorker.TabIndex = 1518
        Me.lblSeasonWorker.Text = "Công nhân thời vụ"
        Me.lblSeasonWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSeasonWorker.Visible = False
        '
        'EndOfSeasonWorker
        '
        Me.EndOfSeasonWorker.EditValue = Nothing
        Me.EndOfSeasonWorker.Enabled = False
        Me.EndOfSeasonWorker.Location = New System.Drawing.Point(726, 263)
        Me.EndOfSeasonWorker.Name = "EndOfSeasonWorker"
        Me.EndOfSeasonWorker.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EndOfSeasonWorker.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EndOfSeasonWorker.Properties.DisplayFormat.FormatString = ""
        Me.EndOfSeasonWorker.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EndOfSeasonWorker.Properties.EditFormat.FormatString = ""
        Me.EndOfSeasonWorker.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EndOfSeasonWorker.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.EndOfSeasonWorker.Properties.MaskSettings.Set("mask", "d")
        Me.EndOfSeasonWorker.Properties.UseMaskAsDisplayFormat = True
        Me.EndOfSeasonWorker.Size = New System.Drawing.Size(166, 20)
        Me.EndOfSeasonWorker.TabIndex = 1517
        '
        'lblEndOfSeasonWorker
        '
        Me.lblEndOfSeasonWorker.BackColor = System.Drawing.Color.Transparent
        Me.lblEndOfSeasonWorker.Location = New System.Drawing.Point(618, 262)
        Me.lblEndOfSeasonWorker.Name = "lblEndOfSeasonWorker"
        Me.lblEndOfSeasonWorker.Size = New System.Drawing.Size(99, 19)
        Me.lblEndOfSeasonWorker.TabIndex = 1516
        Me.lblEndOfSeasonWorker.Text = "Ký CN chính thức"
        Me.lblEndOfSeasonWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SoNgayPhepNam
        '
        Me.SoNgayPhepNam.Location = New System.Drawing.Point(831, 539)
        Me.SoNgayPhepNam.Name = "SoNgayPhepNam"
        Me.SoNgayPhepNam.Size = New System.Drawing.Size(15, 21)
        Me.SoNgayPhepNam.TabIndex = 1515
        Me.SoNgayPhepNam.Visible = False
        '
        'InsertDate
        '
        Me.InsertDate.EditValue = Nothing
        Me.InsertDate.Location = New System.Drawing.Point(1021, 427)
        Me.InsertDate.Name = "InsertDate"
        Me.InsertDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsertDate.Properties.DisplayFormat.FormatString = ""
        Me.InsertDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.InsertDate.Properties.EditFormat.FormatString = ""
        Me.InsertDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.InsertDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.InsertDate.Properties.MaskSettings.Set("mask", "d")
        Me.InsertDate.Properties.UseMaskAsDisplayFormat = True
        Me.InsertDate.Size = New System.Drawing.Size(191, 20)
        Me.InsertDate.TabIndex = 1514
        '
        'RFID
        '
        Me.RFID.Location = New System.Drawing.Point(105, 281)
        Me.RFID.Name = "RFID"
        Me.RFID.Size = New System.Drawing.Size(179, 21)
        Me.RFID.TabIndex = 1513
        '
        'lblTypeOfHiring
        '
        Me.lblTypeOfHiring.BackColor = System.Drawing.Color.Transparent
        Me.lblTypeOfHiring.Location = New System.Drawing.Point(302, 213)
        Me.lblTypeOfHiring.Name = "lblTypeOfHiring"
        Me.lblTypeOfHiring.Size = New System.Drawing.Size(122, 19)
        Me.lblTypeOfHiring.TabIndex = 1512
        Me.lblTypeOfHiring.Text = "Loại tuyển dụng"
        Me.lblTypeOfHiring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TypeOfHiring
        '
        Me.TypeOfHiring.Location = New System.Drawing.Point(430, 213)
        Me.TypeOfHiring.Name = "TypeOfHiring"
        Me.TypeOfHiring.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TypeOfHiring.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeOfHiring.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TypeOfHiring.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TypeOfHiring.Size = New System.Drawing.Size(172, 20)
        Me.TypeOfHiring.TabIndex = 1511
        '
        'ResonTerminated
        '
        Me.ResonTerminated.Enabled = False
        Me.ResonTerminated.Location = New System.Drawing.Point(726, 137)
        Me.ResonTerminated.Name = "ResonTerminated"
        Me.ResonTerminated.Size = New System.Drawing.Size(166, 21)
        Me.ResonTerminated.TabIndex = 1510
        '
        'ContractFlow
        '
        Me.ContractFlow.Location = New System.Drawing.Point(1020, 373)
        Me.ContractFlow.Name = "ContractFlow"
        Me.ContractFlow.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ContractFlow.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ContractFlow.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ContractFlow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ContractFlow.Size = New System.Drawing.Size(99, 20)
        Me.ContractFlow.TabIndex = 1509
        '
        'ID_date
        '
        Me.ID_date.EditValue = Nothing
        Me.ID_date.Location = New System.Drawing.Point(430, 289)
        Me.ID_date.Name = "ID_date"
        Me.ID_date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ID_date.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ID_date.Properties.DisplayFormat.FormatString = ""
        Me.ID_date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ID_date.Properties.EditFormat.FormatString = ""
        Me.ID_date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ID_date.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ID_date.Properties.MaskSettings.Set("mask", "d")
        Me.ID_date.Properties.UseMaskAsDisplayFormat = True
        Me.ID_date.Size = New System.Drawing.Size(172, 20)
        Me.ID_date.TabIndex = 1507
        '
        'MaritalStatus
        '
        Me.MaritalStatus.Location = New System.Drawing.Point(195, 258)
        Me.MaritalStatus.Name = "MaritalStatus"
        Me.MaritalStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.MaritalStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MaritalStatus.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.MaritalStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.MaritalStatus.Size = New System.Drawing.Size(89, 20)
        Me.MaritalStatus.TabIndex = 1505
        '
        'Sex
        '
        Me.Sex.Location = New System.Drawing.Point(105, 257)
        Me.Sex.Name = "Sex"
        Me.Sex.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Sex.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Sex.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Sex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Sex.Size = New System.Drawing.Size(85, 20)
        Me.Sex.TabIndex = 1504
        '
        'BirthDate
        '
        Me.BirthDate.EditValue = Nothing
        Me.BirthDate.Location = New System.Drawing.Point(106, 231)
        Me.BirthDate.Name = "BirthDate"
        Me.BirthDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BirthDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BirthDate.Properties.DisplayFormat.FormatString = ""
        Me.BirthDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BirthDate.Properties.EditFormat.FormatString = ""
        Me.BirthDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BirthDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.BirthDate.Properties.MaskSettings.Set("mask", "d")
        Me.BirthDate.Properties.UseMaskAsDisplayFormat = True
        Me.BirthDate.Size = New System.Drawing.Size(84, 20)
        Me.BirthDate.TabIndex = 1503
        '
        'QuanHeVoiChuHo
        '
        Me.QuanHeVoiChuHo.Location = New System.Drawing.Point(609, 524)
        Me.QuanHeVoiChuHo.Name = "QuanHeVoiChuHo"
        Me.QuanHeVoiChuHo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.QuanHeVoiChuHo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.QuanHeVoiChuHo.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.QuanHeVoiChuHo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.QuanHeVoiChuHo.Size = New System.Drawing.Size(181, 20)
        Me.QuanHeVoiChuHo.TabIndex = 1502
        Me.QuanHeVoiChuHo.Visible = False
        '
        'Nationality
        '
        Me.Nationality.Location = New System.Drawing.Point(100, 375)
        Me.Nationality.Name = "Nationality"
        Me.Nationality.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Nationality.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Nationality.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Nationality.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Nationality.Size = New System.Drawing.Size(90, 20)
        Me.Nationality.TabIndex = 1500
        '
        'NgayTGCongDoan
        '
        Me.NgayTGCongDoan.EditValue = Nothing
        Me.NgayTGCongDoan.Location = New System.Drawing.Point(1021, 452)
        Me.NgayTGCongDoan.Name = "NgayTGCongDoan"
        Me.NgayTGCongDoan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayTGCongDoan.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayTGCongDoan.Properties.DisplayFormat.FormatString = ""
        Me.NgayTGCongDoan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayTGCongDoan.Properties.EditFormat.FormatString = ""
        Me.NgayTGCongDoan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayTGCongDoan.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.NgayTGCongDoan.Properties.MaskSettings.Set("mask", "d")
        Me.NgayTGCongDoan.Properties.UseMaskAsDisplayFormat = True
        Me.NgayTGCongDoan.Size = New System.Drawing.Size(196, 20)
        Me.NgayTGCongDoan.TabIndex = 1499
        Me.NgayTGCongDoan.Visible = False
        '
        'Qualification
        '
        Me.Qualification.Location = New System.Drawing.Point(1020, 329)
        Me.Qualification.Name = "Qualification"
        Me.Qualification.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Qualification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Qualification.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Qualification.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Qualification.Size = New System.Drawing.Size(190, 20)
        Me.Qualification.TabIndex = 1498
        '
        'GraduatedFrom
        '
        Me.GraduatedFrom.Location = New System.Drawing.Point(1020, 304)
        Me.GraduatedFrom.Name = "GraduatedFrom"
        Me.GraduatedFrom.Size = New System.Drawing.Size(190, 21)
        Me.GraduatedFrom.TabIndex = 1496
        '
        'DebitAccount
        '
        Me.DebitAccount.Enabled = False
        Me.DebitAccount.Location = New System.Drawing.Point(852, 444)
        Me.DebitAccount.Name = "DebitAccount"
        Me.DebitAccount.Size = New System.Drawing.Size(21, 21)
        Me.DebitAccount.TabIndex = 1495
        Me.DebitAccount.Visible = False
        '
        'BankCode
        '
        Me.BankCode.Enabled = False
        Me.BankCode.Location = New System.Drawing.Point(1030, 116)
        Me.BankCode.Name = "BankCode"
        Me.BankCode.Size = New System.Drawing.Size(190, 21)
        Me.BankCode.TabIndex = 1494
        '
        'BankAccount
        '
        Me.BankAccount.Enabled = False
        Me.BankAccount.Location = New System.Drawing.Point(1030, 37)
        Me.BankAccount.Name = "BankAccount"
        Me.BankAccount.Size = New System.Drawing.Size(190, 21)
        Me.BankAccount.TabIndex = 1493
        '
        'BankName
        '
        Me.BankName.Enabled = False
        Me.BankName.Location = New System.Drawing.Point(1030, 89)
        Me.BankName.Name = "BankName"
        Me.BankName.Size = New System.Drawing.Size(190, 21)
        Me.BankName.TabIndex = 1492
        '
        'MaSoThue
        '
        Me.MaSoThue.Location = New System.Drawing.Point(1030, 64)
        Me.MaSoThue.Name = "MaSoThue"
        Me.MaSoThue.Size = New System.Drawing.Size(190, 21)
        Me.MaSoThue.TabIndex = 1491
        '
        'Employee_Status
        '
        Me.Employee_Status.Enabled = False
        Me.Employee_Status.Location = New System.Drawing.Point(726, 68)
        Me.Employee_Status.Name = "Employee_Status"
        Me.Employee_Status.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Employee_Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Employee_Status.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Employee_Status.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Employee_Status.Size = New System.Drawing.Size(166, 20)
        Me.Employee_Status.TabIndex = 1490
        '
        'PlanTernimationDate
        '
        Me.PlanTernimationDate.EditValue = Nothing
        Me.PlanTernimationDate.Enabled = False
        Me.PlanTernimationDate.Location = New System.Drawing.Point(726, 114)
        Me.PlanTernimationDate.Name = "PlanTernimationDate"
        Me.PlanTernimationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanTernimationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanTernimationDate.Properties.DisplayFormat.FormatString = ""
        Me.PlanTernimationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PlanTernimationDate.Properties.EditFormat.FormatString = ""
        Me.PlanTernimationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PlanTernimationDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.PlanTernimationDate.Properties.MaskSettings.Set("mask", "d")
        Me.PlanTernimationDate.Properties.UseMaskAsDisplayFormat = True
        Me.PlanTernimationDate.Size = New System.Drawing.Size(166, 20)
        Me.PlanTernimationDate.TabIndex = 1489
        '
        'TernimationDate
        '
        Me.TernimationDate.EditValue = Nothing
        Me.TernimationDate.Enabled = False
        Me.TernimationDate.Location = New System.Drawing.Point(726, 90)
        Me.TernimationDate.Name = "TernimationDate"
        Me.TernimationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TernimationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TernimationDate.Properties.DisplayFormat.FormatString = ""
        Me.TernimationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TernimationDate.Properties.EditFormat.FormatString = ""
        Me.TernimationDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TernimationDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.TernimationDate.Properties.MaskSettings.Set("mask", "d")
        Me.TernimationDate.Properties.UseMaskAsDisplayFormat = True
        Me.TernimationDate.Size = New System.Drawing.Size(166, 20)
        Me.TernimationDate.TabIndex = 1488
        '
        'DecisionStatus
        '
        Me.DecisionStatus.Enabled = False
        Me.DecisionStatus.Location = New System.Drawing.Point(726, 161)
        Me.DecisionStatus.Name = "DecisionStatus"
        Me.DecisionStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.DecisionStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DecisionStatus.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.DecisionStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.DecisionStatus.Size = New System.Drawing.Size(166, 20)
        Me.DecisionStatus.TabIndex = 1487
        '
        'ChucDanh
        '
        Me.ChucDanh.Enabled = False
        Me.ChucDanh.Location = New System.Drawing.Point(430, 187)
        Me.ChucDanh.Name = "ChucDanh"
        Me.ChucDanh.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChucDanh.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChucDanh.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.ChucDanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ChucDanh.Size = New System.Drawing.Size(172, 20)
        Me.ChucDanh.TabIndex = 1486
        '
        'PositionCategory_ID
        '
        Me.PositionCategory_ID.Enabled = False
        Me.PositionCategory_ID.Location = New System.Drawing.Point(1106, 644)
        Me.PositionCategory_ID.Name = "PositionCategory_ID"
        Me.PositionCategory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.PositionCategory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PositionCategory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.PositionCategory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.PositionCategory_ID.Size = New System.Drawing.Size(38, 20)
        Me.PositionCategory_ID.TabIndex = 1485
        Me.PositionCategory_ID.Visible = False
        '
        'Position_ID
        '
        Me.Position_ID.Enabled = False
        Me.Position_ID.Location = New System.Drawing.Point(430, 236)
        Me.Position_ID.Name = "Position_ID"
        Me.Position_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Position_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Position_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Position_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Position_ID.Size = New System.Drawing.Size(172, 20)
        Me.Position_ID.TabIndex = 1484
        '
        'teamcode
        '
        Me.teamcode.Enabled = False
        Me.teamcode.Location = New System.Drawing.Point(1106, 618)
        Me.teamcode.Name = "teamcode"
        Me.teamcode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.teamcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.teamcode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.teamcode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.teamcode.Size = New System.Drawing.Size(38, 20)
        Me.teamcode.TabIndex = 1483
        Me.teamcode.Visible = False
        '
        'sectioncode
        '
        Me.sectioncode.Enabled = False
        Me.sectioncode.Location = New System.Drawing.Point(431, 162)
        Me.sectioncode.Name = "sectioncode"
        Me.sectioncode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.sectioncode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sectioncode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.sectioncode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.sectioncode.Size = New System.Drawing.Size(170, 20)
        Me.sectioncode.TabIndex = 1482
        '
        'departmentcode
        '
        Me.departmentcode.Enabled = False
        Me.departmentcode.Location = New System.Drawing.Point(430, 138)
        Me.departmentcode.Name = "departmentcode"
        Me.departmentcode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.departmentcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.departmentcode.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.departmentcode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.departmentcode.Size = New System.Drawing.Size(172, 20)
        Me.departmentcode.TabIndex = 1481
        '
        'Factory_ID
        '
        Me.Factory_ID.Enabled = False
        Me.Factory_ID.Location = New System.Drawing.Point(430, 113)
        Me.Factory_ID.Name = "Factory_ID"
        Me.Factory_ID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.Factory_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Factory_ID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.Factory_ID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.Factory_ID.Size = New System.Drawing.Size(172, 20)
        Me.Factory_ID.TabIndex = 1480
        '
        'EmployeeSearch
        '
        Me.EmployeeSearch.Location = New System.Drawing.Point(69, 14)
        Me.EmployeeSearch.Name = "EmployeeSearch"
        Me.EmployeeSearch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.EmployeeSearch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.EmployeeSearch.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.EmployeeSearch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.EmployeeSearch.Size = New System.Drawing.Size(253, 20)
        Me.EmployeeSearch.TabIndex = 1479
        '
        'OfficialDate
        '
        Me.OfficialDate.EditValue = Nothing
        Me.OfficialDate.Location = New System.Drawing.Point(430, 66)
        Me.OfficialDate.Name = "OfficialDate"
        Me.OfficialDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OfficialDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OfficialDate.Properties.DisplayFormat.FormatString = ""
        Me.OfficialDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.OfficialDate.Properties.EditFormat.FormatString = ""
        Me.OfficialDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.OfficialDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.OfficialDate.Properties.MaskSettings.Set("mask", "d")
        Me.OfficialDate.Properties.UseMaskAsDisplayFormat = True
        Me.OfficialDate.Size = New System.Drawing.Size(172, 20)
        Me.OfficialDate.TabIndex = 1478
        '
        'ComStartedDate
        '
        Me.ComStartedDate.EditValue = Nothing
        Me.ComStartedDate.Location = New System.Drawing.Point(430, 90)
        Me.ComStartedDate.Name = "ComStartedDate"
        Me.ComStartedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComStartedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComStartedDate.Properties.DisplayFormat.FormatString = ""
        Me.ComStartedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ComStartedDate.Properties.EditFormat.FormatString = ""
        Me.ComStartedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ComStartedDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.ComStartedDate.Properties.MaskSettings.Set("mask", "d")
        Me.ComStartedDate.Properties.UseMaskAsDisplayFormat = True
        Me.ComStartedDate.Size = New System.Drawing.Size(172, 20)
        Me.ComStartedDate.TabIndex = 1477
        '
        'StartedDate
        '
        Me.StartedDate.EditValue = Nothing
        Me.StartedDate.Location = New System.Drawing.Point(430, 42)
        Me.StartedDate.Name = "StartedDate"
        Me.StartedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartedDate.Properties.DisplayFormat.FormatString = ""
        Me.StartedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.StartedDate.Properties.EditFormat.FormatString = ""
        Me.StartedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.StartedDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.StartedDate.Properties.MaskSettings.Set("mask", "d")
        Me.StartedDate.Properties.UseMaskAsDisplayFormat = True
        Me.StartedDate.Size = New System.Drawing.Size(172, 20)
        Me.StartedDate.TabIndex = 1476
        '
        'IE_FLAG
        '
        Me.IE_FLAG.Enabled = False
        Me.IE_FLAG.Location = New System.Drawing.Point(814, 206)
        Me.IE_FLAG.Name = "IE_FLAG"
        Me.IE_FLAG.Size = New System.Drawing.Size(78, 21)
        Me.IE_FLAG.TabIndex = 1475
        '
        'JobCode
        '
        Me.JobCode.Enabled = False
        Me.JobCode.Location = New System.Drawing.Point(726, 207)
        Me.JobCode.Name = "JobCode"
        Me.JobCode.Size = New System.Drawing.Size(78, 21)
        Me.JobCode.TabIndex = 1474
        '
        'DecisionCode
        '
        Me.DecisionCode.Enabled = False
        Me.DecisionCode.Location = New System.Drawing.Point(726, 184)
        Me.DecisionCode.Name = "DecisionCode"
        Me.DecisionCode.Size = New System.Drawing.Size(166, 21)
        Me.DecisionCode.TabIndex = 1473
        '
        'AbsentStatus
        '
        Me.AbsentStatus.Enabled = False
        Me.AbsentStatus.Location = New System.Drawing.Point(726, 41)
        Me.AbsentStatus.Name = "AbsentStatus"
        Me.AbsentStatus.Size = New System.Drawing.Size(166, 21)
        Me.AbsentStatus.TabIndex = 1472
        '
        'NguoiLienHeGap
        '
        Me.NguoiLienHeGap.Location = New System.Drawing.Point(102, 553)
        Me.NguoiLienHeGap.Name = "NguoiLienHeGap"
        Me.NguoiLienHeGap.Size = New System.Drawing.Size(688, 21)
        Me.NguoiLienHeGap.TabIndex = 1471
        Me.NguoiLienHeGap.Visible = False
        '
        'TenChuHo
        '
        Me.TenChuHo.Location = New System.Drawing.Point(102, 526)
        Me.TenChuHo.Name = "TenChuHo"
        Me.TenChuHo.Size = New System.Drawing.Size(322, 21)
        Me.TenChuHo.TabIndex = 1470
        Me.TenChuHo.Visible = False
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(100, 397)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(90, 21)
        Me.Email.TabIndex = 1469
        '
        'Tel
        '
        Me.Tel.Location = New System.Drawing.Point(702, 375)
        Me.Tel.Name = "Tel"
        Me.Tel.Size = New System.Drawing.Size(88, 21)
        Me.Tel.TabIndex = 1468
        '
        'ID_number
        '
        Me.ID_number.Location = New System.Drawing.Point(430, 262)
        Me.ID_number.Name = "ID_number"
        Me.ID_number.Size = New System.Drawing.Size(173, 21)
        Me.ID_number.TabIndex = 1467
        '
        'Employee_Lastname
        '
        Me.Employee_Lastname.Location = New System.Drawing.Point(227, 207)
        Me.Employee_Lastname.Name = "Employee_Lastname"
        Me.Employee_Lastname.Size = New System.Drawing.Size(58, 21)
        Me.Employee_Lastname.TabIndex = 1466
        '
        'Employee_Firstname
        '
        Me.Employee_Firstname.Location = New System.Drawing.Point(105, 207)
        Me.Employee_Firstname.Name = "Employee_Firstname"
        Me.Employee_Firstname.Size = New System.Drawing.Size(116, 21)
        Me.Employee_Firstname.TabIndex = 1465
        '
        'Card_No
        '
        Me.Card_No.Location = New System.Drawing.Point(422, 621)
        Me.Card_No.Name = "Card_No"
        Me.Card_No.Size = New System.Drawing.Size(178, 21)
        Me.Card_No.TabIndex = 1464
        Me.Card_No.Visible = False
        '
        'Card_Code
        '
        Me.Card_Code.Location = New System.Drawing.Point(423, 596)
        Me.Card_Code.Name = "Card_Code"
        Me.Card_Code.Size = New System.Drawing.Size(178, 21)
        Me.Card_Code.TabIndex = 1463
        Me.Card_Code.Visible = False
        '
        'Employee_ID
        '
        Me.Employee_ID.Location = New System.Drawing.Point(106, 179)
        Me.Employee_ID.Name = "Employee_ID"
        Me.Employee_ID.Size = New System.Drawing.Size(178, 21)
        Me.Employee_ID.TabIndex = 1462
        '
        'btnXoaAnh
        '
        Me.btnXoaAnh.Location = New System.Drawing.Point(199, 151)
        Me.btnXoaAnh.Name = "btnXoaAnh"
        Me.btnXoaAnh.Size = New System.Drawing.Size(85, 22)
        Me.btnXoaAnh.TabIndex = 1461
        Me.btnXoaAnh.Text = "Xóa ảnh"
        '
        'btnChonAnh
        '
        Me.btnChonAnh.Location = New System.Drawing.Point(105, 151)
        Me.btnChonAnh.Name = "btnChonAnh"
        Me.btnChonAnh.Size = New System.Drawing.Size(85, 22)
        Me.btnChonAnh.TabIndex = 1460
        Me.btnChonAnh.Text = "Chọn ảnh"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(328, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(53, 22)
        Me.btnSearch.TabIndex = 1459
        Me.btnSearch.Text = "Tìm"
        '
        'lblNgayTGCongDoan
        '
        Me.lblNgayTGCongDoan.BackColor = System.Drawing.Color.Transparent
        Me.lblNgayTGCongDoan.Location = New System.Drawing.Point(901, 455)
        Me.lblNgayTGCongDoan.Name = "lblNgayTGCongDoan"
        Me.lblNgayTGCongDoan.Size = New System.Drawing.Size(114, 16)
        Me.lblNgayTGCongDoan.TabIndex = 1458
        Me.lblNgayTGCongDoan.Text = "Ngày tham gia CĐ"
        Me.lblNgayTGCongDoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNgayTGCongDoan.Visible = False
        '
        'isThuViec85PhanTram
        '
        Me.isThuViec85PhanTram.AutoSize = True
        Me.isThuViec85PhanTram.BackColor = System.Drawing.Color.Transparent
        Me.isThuViec85PhanTram.Location = New System.Drawing.Point(1125, 375)
        Me.isThuViec85PhanTram.Name = "isThuViec85PhanTram"
        Me.isThuViec85PhanTram.Size = New System.Drawing.Size(93, 17)
        Me.isThuViec85PhanTram.TabIndex = 1457
        Me.isThuViec85PhanTram.Text = "Thử việc 85%"
        Me.isThuViec85PhanTram.UseVisualStyleBackColor = False
        '
        'lblBookCode
        '
        Me.lblBookCode.BackColor = System.Drawing.Color.Transparent
        Me.lblBookCode.Location = New System.Drawing.Point(901, 564)
        Me.lblBookCode.Name = "lblBookCode"
        Me.lblBookCode.Size = New System.Drawing.Size(114, 18)
        Me.lblBookCode.TabIndex = 1456
        Me.lblBookCode.Text = "Số sổ BH"
        Me.lblBookCode.Visible = False
        '
        'SoSoBaoHiem
        '
        Me.SoSoBaoHiem.Location = New System.Drawing.Point(1021, 561)
        Me.SoSoBaoHiem.Name = "SoSoBaoHiem"
        Me.SoSoBaoHiem.Size = New System.Drawing.Size(196, 21)
        Me.SoSoBaoHiem.TabIndex = 1455
        Me.SoSoBaoHiem.Visible = False
        '
        'lblQuanHeVoiChuHo
        '
        Me.lblQuanHeVoiChuHo.BackColor = System.Drawing.Color.Transparent
        Me.lblQuanHeVoiChuHo.Location = New System.Drawing.Point(429, 523)
        Me.lblQuanHeVoiChuHo.Name = "lblQuanHeVoiChuHo"
        Me.lblQuanHeVoiChuHo.Size = New System.Drawing.Size(174, 22)
        Me.lblQuanHeVoiChuHo.TabIndex = 1454
        Me.lblQuanHeVoiChuHo.Text = "Quan hệ với chủ hộ"
        Me.lblQuanHeVoiChuHo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblQuanHeVoiChuHo.Visible = False
        '
        'lblTenChuHo
        '
        Me.lblTenChuHo.BackColor = System.Drawing.Color.Transparent
        Me.lblTenChuHo.Location = New System.Drawing.Point(12, 526)
        Me.lblTenChuHo.Name = "lblTenChuHo"
        Me.lblTenChuHo.Size = New System.Drawing.Size(84, 19)
        Me.lblTenChuHo.TabIndex = 1453
        Me.lblTenChuHo.Text = "Tên chủ hộ"
        Me.lblTenChuHo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTenChuHo.Visible = False
        '
        'lblLeaveType_ID
        '
        Me.lblLeaveType_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblLeaveType_ID.Location = New System.Drawing.Point(618, 42)
        Me.lblLeaveType_ID.Name = "lblLeaveType_ID"
        Me.lblLeaveType_ID.Size = New System.Drawing.Size(92, 19)
        Me.lblLeaveType_ID.TabIndex = 1452
        Me.lblLeaveType_ID.Text = "LeaveType_ID"
        Me.lblLeaveType_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BirthDateFormat
        '
        Me.BirthDateFormat.FormattingEnabled = True
        Me.BirthDateFormat.Items.AddRange(New Object() {"dd/MM/yyyy", "MM/yyyy", "yyyy"})
        Me.BirthDateFormat.Location = New System.Drawing.Point(196, 231)
        Me.BirthDateFormat.Name = "BirthDateFormat"
        Me.BirthDateFormat.Size = New System.Drawing.Size(89, 21)
        Me.BirthDateFormat.TabIndex = 1451
        '
        'lblRFID
        '
        Me.lblRFID.BackColor = System.Drawing.Color.Transparent
        Me.lblRFID.Location = New System.Drawing.Point(17, 283)
        Me.lblRFID.Name = "lblRFID"
        Me.lblRFID.Size = New System.Drawing.Size(80, 19)
        Me.lblRFID.TabIndex = 1450
        Me.lblRFID.Text = "RFID"
        Me.lblRFID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSearch
        '
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.Location = New System.Drawing.Point(17, 12)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(80, 19)
        Me.lblSearch.TabIndex = 1449
        Me.lblSearch.Text = "Tìm kiếm"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPicture
        '
        Me.lblPicture.BackColor = System.Drawing.Color.Transparent
        Me.lblPicture.Location = New System.Drawing.Point(17, 93)
        Me.lblPicture.Name = "lblPicture"
        Me.lblPicture.Size = New System.Drawing.Size(80, 19)
        Me.lblPicture.TabIndex = 1448
        Me.lblPicture.Text = "Ảnh"
        Me.lblPicture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Picture
        '
        Me.Picture.BackColor = System.Drawing.Color.Transparent
        Me.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture.Location = New System.Drawing.Point(105, 53)
        Me.Picture.Margin = New System.Windows.Forms.Padding(0)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(180, 96)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture.TabIndex = 1447
        Me.Picture.TabStop = False
        '
        'lblHealthCheckFee
        '
        Me.lblHealthCheckFee.BackColor = System.Drawing.Color.Transparent
        Me.lblHealthCheckFee.Location = New System.Drawing.Point(901, 505)
        Me.lblHealthCheckFee.Name = "lblHealthCheckFee"
        Me.lblHealthCheckFee.Size = New System.Drawing.Size(114, 19)
        Me.lblHealthCheckFee.TabIndex = 1446
        Me.lblHealthCheckFee.Text = "Tiền khám SK"
        Me.lblHealthCheckFee.Visible = False
        '
        'HealthCheckFee
        '
        Me.HealthCheckFee.Location = New System.Drawing.Point(1021, 503)
        Me.HealthCheckFee.Name = "HealthCheckFee"
        Me.HealthCheckFee.Size = New System.Drawing.Size(196, 21)
        Me.HealthCheckFee.TabIndex = 1445
        Me.HealthCheckFee.Visible = False
        '
        'lblHospital
        '
        Me.lblHospital.BackColor = System.Drawing.Color.Transparent
        Me.lblHospital.Location = New System.Drawing.Point(901, 532)
        Me.lblHospital.Name = "lblHospital"
        Me.lblHospital.Size = New System.Drawing.Size(114, 18)
        Me.lblHospital.TabIndex = 1444
        Me.lblHospital.Text = "Khám tại bệnh viện"
        Me.lblHospital.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHospital.Visible = False
        '
        'Hospital
        '
        Me.Hospital.Location = New System.Drawing.Point(1021, 530)
        Me.Hospital.Name = "Hospital"
        Me.Hospital.Size = New System.Drawing.Size(196, 24)
        Me.Hospital.TabIndex = 1443
        Me.Hospital.Text = ""
        Me.Hospital.Visible = False
        '
        'Weight
        '
        Me.Weight.DecimalPlaces = 1
        Me.Weight.Location = New System.Drawing.Point(1153, 479)
        Me.Weight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Weight.Name = "Weight"
        Me.Weight.Size = New System.Drawing.Size(64, 21)
        Me.Weight.TabIndex = 1441
        Me.Weight.Visible = False
        '
        'lblWeight
        '
        Me.lblWeight.BackColor = System.Drawing.Color.White
        Me.lblWeight.Location = New System.Drawing.Point(811, 564)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(66, 23)
        Me.lblWeight.TabIndex = 1442
        Me.lblWeight.Text = "Cân nặng"
        Me.lblWeight.Visible = False
        '
        'Height
        '
        Me.Height.DecimalPlaces = 1
        Me.Height.Location = New System.Drawing.Point(1021, 479)
        Me.Height.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(64, 21)
        Me.Height.TabIndex = 1439
        Me.Height.Visible = False
        '
        'lblHeight
        '
        Me.lblHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblHeight.Location = New System.Drawing.Point(901, 481)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(114, 23)
        Me.lblHeight.TabIndex = 1440
        Me.lblHeight.Text = "Chiều cao"
        Me.lblHeight.Visible = False
        '
        'lblDecisionStatus
        '
        Me.lblDecisionStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblDecisionStatus.Location = New System.Drawing.Point(618, 158)
        Me.lblDecisionStatus.Name = "lblDecisionStatus"
        Me.lblDecisionStatus.Size = New System.Drawing.Size(84, 19)
        Me.lblDecisionStatus.TabIndex = 1438
        Me.lblDecisionStatus.Text = "Trạng thái"
        Me.lblDecisionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJobCode
        '
        Me.lblJobCode.BackColor = System.Drawing.Color.Transparent
        Me.lblJobCode.Location = New System.Drawing.Point(618, 206)
        Me.lblJobCode.Name = "lblJobCode"
        Me.lblJobCode.Size = New System.Drawing.Size(92, 19)
        Me.lblJobCode.TabIndex = 1437
        Me.lblJobCode.Text = "Job code"
        Me.lblJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TanTat
        '
        Me.TanTat.Location = New System.Drawing.Point(724, 339)
        Me.TanTat.Name = "TanTat"
        Me.TanTat.Size = New System.Drawing.Size(168, 23)
        Me.TanTat.TabIndex = 1436
        Me.TanTat.Text = ""
        '
        'lblComStartedDate
        '
        Me.lblComStartedDate.BackColor = System.Drawing.Color.Transparent
        Me.lblComStartedDate.Location = New System.Drawing.Point(302, 90)
        Me.lblComStartedDate.Name = "lblComStartedDate"
        Me.lblComStartedDate.Size = New System.Drawing.Size(122, 19)
        Me.lblComStartedDate.TabIndex = 1435
        Me.lblComStartedDate.Text = "Ngày vào công ty"
        Me.lblComStartedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNguoiLienHeGap
        '
        Me.lblNguoiLienHeGap.BackColor = System.Drawing.Color.Transparent
        Me.lblNguoiLienHeGap.Location = New System.Drawing.Point(12, 552)
        Me.lblNguoiLienHeGap.Name = "lblNguoiLienHeGap"
        Me.lblNguoiLienHeGap.Size = New System.Drawing.Size(93, 21)
        Me.lblNguoiLienHeGap.TabIndex = 1434
        Me.lblNguoiLienHeGap.Text = "Người liên hệ gấp"
        Me.lblNguoiLienHeGap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNguoiLienHeGap.Visible = False
        '
        'lblTanTat
        '
        Me.lblTanTat.BackColor = System.Drawing.Color.Transparent
        Me.lblTanTat.Location = New System.Drawing.Point(616, 339)
        Me.lblTanTat.Name = "lblTanTat"
        Me.lblTanTat.Size = New System.Drawing.Size(84, 19)
        Me.lblTanTat.TabIndex = 1433
        Me.lblTanTat.Text = "Tàn tật"
        Me.lblTanTat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTonGiao
        '
        Me.lblTonGiao.BackColor = System.Drawing.Color.Transparent
        Me.lblTonGiao.Location = New System.Drawing.Point(392, 375)
        Me.lblTonGiao.Name = "lblTonGiao"
        Me.lblTonGiao.Size = New System.Drawing.Size(91, 19)
        Me.lblTonGiao.TabIndex = 1432
        Me.lblTonGiao.Text = "Tôn giáo"
        Me.lblTonGiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFactory_ID
        '
        Me.lblFactory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblFactory_ID.Location = New System.Drawing.Point(288, 110)
        Me.lblFactory_ID.Name = "lblFactory_ID"
        Me.lblFactory_ID.Size = New System.Drawing.Size(22, 19)
        Me.lblFactory_ID.TabIndex = 1431
        Me.lblFactory_ID.Text = "Xưởng"
        Me.lblFactory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFactory_ID.Visible = False
        '
        'Address_Temporary
        '
        Me.Address_Temporary.Location = New System.Drawing.Point(102, 494)
        Me.Address_Temporary.Name = "Address_Temporary"
        Me.Address_Temporary.Size = New System.Drawing.Size(688, 24)
        Me.Address_Temporary.TabIndex = 1430
        '
        'Address_Permanent
        '
        Me.Address_Permanent.Location = New System.Drawing.Point(102, 470)
        Me.Address_Permanent.Name = "Address_Permanent"
        Me.Address_Permanent.Size = New System.Drawing.Size(688, 24)
        Me.Address_Permanent.TabIndex = 1429
        '
        'lblRemark
        '
        Me.lblRemark.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark.Location = New System.Drawing.Point(903, 402)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(109, 19)
        Me.lblRemark.TabIndex = 1426
        Me.lblRemark.Text = "Ghi chú"
        Me.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Remark
        '
        Me.Remark.Location = New System.Drawing.Point(1020, 400)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(192, 22)
        Me.Remark.TabIndex = 1425
        Me.Remark.Text = ""
        '
        'lblContractFlow
        '
        Me.lblContractFlow.BackColor = System.Drawing.Color.Transparent
        Me.lblContractFlow.Location = New System.Drawing.Point(900, 375)
        Me.lblContractFlow.Name = "lblContractFlow"
        Me.lblContractFlow.Size = New System.Drawing.Size(97, 20)
        Me.lblContractFlow.TabIndex = 1424
        Me.lblContractFlow.Text = "Luồng hợp đồng"
        Me.lblContractFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSoNgayPhepNam
        '
        Me.lblSoNgayPhepNam.BackColor = System.Drawing.Color.Transparent
        Me.lblSoNgayPhepNam.Location = New System.Drawing.Point(830, 517)
        Me.lblSoNgayPhepNam.Name = "lblSoNgayPhepNam"
        Me.lblSoNgayPhepNam.Size = New System.Drawing.Size(16, 19)
        Me.lblSoNgayPhepNam.TabIndex = 1423
        Me.lblSoNgayPhepNam.Text = "Số ngày phép năm"
        Me.lblSoNgayPhepNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSoNgayPhepNam.Visible = False
        '
        'lblThongTinKhac
        '
        Me.lblThongTinKhac.BackColor = System.Drawing.Color.Transparent
        Me.lblThongTinKhac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThongTinKhac.Location = New System.Drawing.Point(901, 354)
        Me.lblThongTinKhac.Name = "lblThongTinKhac"
        Me.lblThongTinKhac.Size = New System.Drawing.Size(211, 16)
        Me.lblThongTinKhac.TabIndex = 1422
        Me.lblThongTinKhac.Text = "Thông tin khác"
        '
        'lblQualification
        '
        Me.lblQualification.BackColor = System.Drawing.Color.Transparent
        Me.lblQualification.Location = New System.Drawing.Point(900, 329)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(114, 19)
        Me.lblQualification.TabIndex = 1421
        Me.lblQualification.Text = "Chuyên môn"
        Me.lblQualification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGraduated
        '
        Me.lblGraduated.BackColor = System.Drawing.Color.Transparent
        Me.lblGraduated.Location = New System.Drawing.Point(900, 279)
        Me.lblGraduated.Name = "lblGraduated"
        Me.lblGraduated.Size = New System.Drawing.Size(114, 19)
        Me.lblGraduated.TabIndex = 1419
        Me.lblGraduated.Text = "Bằng cấp"
        Me.lblGraduated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGraduatedFrom
        '
        Me.lblGraduatedFrom.BackColor = System.Drawing.Color.Transparent
        Me.lblGraduatedFrom.Location = New System.Drawing.Point(901, 304)
        Me.lblGraduatedFrom.Name = "lblGraduatedFrom"
        Me.lblGraduatedFrom.Size = New System.Drawing.Size(114, 19)
        Me.lblGraduatedFrom.TabIndex = 1420
        Me.lblGraduatedFrom.Text = "Nơi cấp bằng"
        Me.lblGraduatedFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTrinhDoChuyenMon
        '
        Me.lblTrinhDoChuyenMon.BackColor = System.Drawing.Color.Transparent
        Me.lblTrinhDoChuyenMon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrinhDoChuyenMon.Location = New System.Drawing.Point(901, 258)
        Me.lblTrinhDoChuyenMon.Name = "lblTrinhDoChuyenMon"
        Me.lblTrinhDoChuyenMon.Size = New System.Drawing.Size(211, 16)
        Me.lblTrinhDoChuyenMon.TabIndex = 1418
        Me.lblTrinhDoChuyenMon.Text = "Trình độ chuyên môn"
        '
        'lblThongTinLienLac
        '
        Me.lblThongTinLienLac.BackColor = System.Drawing.Color.Transparent
        Me.lblThongTinLienLac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThongTinLienLac.Location = New System.Drawing.Point(12, 350)
        Me.lblThongTinLienLac.Name = "lblThongTinLienLac"
        Me.lblThongTinLienLac.Size = New System.Drawing.Size(137, 16)
        Me.lblThongTinLienLac.TabIndex = 1417
        Me.lblThongTinLienLac.Text = "Thông liên lạc"
        '
        'lblThongTinNganHangThe
        '
        Me.lblThongTinNganHangThe.BackColor = System.Drawing.Color.Transparent
        Me.lblThongTinNganHangThe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThongTinNganHangThe.Location = New System.Drawing.Point(910, 18)
        Me.lblThongTinNganHangThe.Name = "lblThongTinNganHangThe"
        Me.lblThongTinNganHangThe.Size = New System.Drawing.Size(238, 16)
        Me.lblThongTinNganHangThe.TabIndex = 1416
        Me.lblThongTinNganHangThe.Text = "Thông tin Ngân hàng - Thẻ"
        '
        'lblTrangThaiLamViec
        '
        Me.lblTrangThaiLamViec.BackColor = System.Drawing.Color.Transparent
        Me.lblTrangThaiLamViec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrangThaiLamViec.Location = New System.Drawing.Point(621, 18)
        Me.lblTrangThaiLamViec.Name = "lblTrangThaiLamViec"
        Me.lblTrangThaiLamViec.Size = New System.Drawing.Size(138, 16)
        Me.lblTrangThaiLamViec.TabIndex = 1415
        Me.lblTrangThaiLamViec.Text = "Trạng thái làm việc"
        '
        'lblThongTinChinh
        '
        Me.lblThongTinChinh.BackColor = System.Drawing.Color.Transparent
        Me.lblThongTinChinh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThongTinChinh.Location = New System.Drawing.Point(14, 36)
        Me.lblThongTinChinh.Name = "lblThongTinChinh"
        Me.lblThongTinChinh.Size = New System.Drawing.Size(135, 16)
        Me.lblThongTinChinh.TabIndex = 1414
        Me.lblThongTinChinh.Text = "Thông tin chính"
        '
        'lblBirthPlace
        '
        Me.lblBirthPlace.BackColor = System.Drawing.Color.Transparent
        Me.lblBirthPlace.Location = New System.Drawing.Point(14, 422)
        Me.lblBirthPlace.Name = "lblBirthPlace"
        Me.lblBirthPlace.Size = New System.Drawing.Size(80, 19)
        Me.lblBirthPlace.TabIndex = 1411
        Me.lblBirthPlace.Text = "Nơi sinh"
        Me.lblBirthPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress_Permanent
        '
        Me.lblAddress_Permanent.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress_Permanent.Location = New System.Drawing.Point(12, 470)
        Me.lblAddress_Permanent.Name = "lblAddress_Permanent"
        Me.lblAddress_Permanent.Size = New System.Drawing.Size(80, 19)
        Me.lblAddress_Permanent.TabIndex = 1412
        Me.lblAddress_Permanent.Text = "Đ/C thường trú"
        Me.lblAddress_Permanent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress_Temporary
        '
        Me.lblAddress_Temporary.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress_Temporary.Location = New System.Drawing.Point(12, 494)
        Me.lblAddress_Temporary.Name = "lblAddress_Temporary"
        Me.lblAddress_Temporary.Size = New System.Drawing.Size(72, 19)
        Me.lblAddress_Temporary.TabIndex = 1413
        Me.lblAddress_Temporary.Text = "Đ/C Tạm trú"
        Me.lblAddress_Temporary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDebitAccount
        '
        Me.lblDebitAccount.BackColor = System.Drawing.Color.Transparent
        Me.lblDebitAccount.Location = New System.Drawing.Point(796, 446)
        Me.lblDebitAccount.Name = "lblDebitAccount"
        Me.lblDebitAccount.Size = New System.Drawing.Size(50, 19)
        Me.lblDebitAccount.TabIndex = 1410
        Me.lblDebitAccount.Text = "Thẻ ghi nợ"
        Me.lblDebitAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDebitAccount.Visible = False
        '
        'lblBankCode
        '
        Me.lblBankCode.BackColor = System.Drawing.Color.Transparent
        Me.lblBankCode.Location = New System.Drawing.Point(910, 116)
        Me.lblBankCode.Name = "lblBankCode"
        Me.lblBankCode.Size = New System.Drawing.Size(114, 19)
        Me.lblBankCode.TabIndex = 1409
        Me.lblBankCode.Text = "Mã ngân hàng"
        Me.lblBankCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBankName
        '
        Me.lblBankName.BackColor = System.Drawing.Color.Transparent
        Me.lblBankName.Location = New System.Drawing.Point(910, 91)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(114, 19)
        Me.lblBankName.TabIndex = 1408
        Me.lblBankName.Text = "Tên ngân hàng"
        Me.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBankAccount
        '
        Me.lblBankAccount.BackColor = System.Drawing.Color.Transparent
        Me.lblBankAccount.Location = New System.Drawing.Point(910, 40)
        Me.lblBankAccount.Name = "lblBankAccount"
        Me.lblBankAccount.Size = New System.Drawing.Size(114, 19)
        Me.lblBankAccount.TabIndex = 1407
        Me.lblBankAccount.Text = "Số tài khoản"
        Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmail
        '
        Me.lblEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblEmail.Location = New System.Drawing.Point(15, 397)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(79, 19)
        Me.lblEmail.TabIndex = 1406
        Me.lblEmail.Text = "Email"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTel
        '
        Me.lblTel.BackColor = System.Drawing.Color.Transparent
        Me.lblTel.Location = New System.Drawing.Point(598, 375)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(98, 19)
        Me.lblTel.TabIndex = 1405
        Me.lblTel.Text = "Điện thoại"
        Me.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNation
        '
        Me.lblNation.BackColor = System.Drawing.Color.Transparent
        Me.lblNation.Location = New System.Drawing.Point(205, 374)
        Me.lblNation.Name = "lblNation"
        Me.lblNation.Size = New System.Drawing.Size(80, 19)
        Me.lblNation.TabIndex = 1404
        Me.lblNation.Text = "Dân tộc"
        Me.lblNation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNationality
        '
        Me.lblNationality.BackColor = System.Drawing.Color.Transparent
        Me.lblNationality.Location = New System.Drawing.Point(14, 374)
        Me.lblNationality.Name = "lblNationality"
        Me.lblNationality.Size = New System.Drawing.Size(80, 19)
        Me.lblNationality.TabIndex = 1402
        Me.lblNationality.Text = "Quốc tịch"
        Me.lblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbNativePlace
        '
        Me.lbNativePlace.BackColor = System.Drawing.Color.Transparent
        Me.lbNativePlace.Location = New System.Drawing.Point(14, 446)
        Me.lbNativePlace.Name = "lbNativePlace"
        Me.lbNativePlace.Size = New System.Drawing.Size(80, 19)
        Me.lbNativePlace.TabIndex = 1403
        Me.lbNativePlace.Text = "Nguyên quán"
        Me.lbNativePlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblsectioncode
        '
        Me.lblsectioncode.BackColor = System.Drawing.Color.Transparent
        Me.lblsectioncode.Location = New System.Drawing.Point(302, 137)
        Me.lblsectioncode.Name = "lblsectioncode"
        Me.lblsectioncode.Size = New System.Drawing.Size(122, 19)
        Me.lblsectioncode.TabIndex = 1401
        Me.lblsectioncode.Text = "Phòng ban"
        Me.lblsectioncode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChucDanh
        '
        Me.lblChucDanh.BackColor = System.Drawing.Color.Transparent
        Me.lblChucDanh.Location = New System.Drawing.Point(1080, 643)
        Me.lblChucDanh.Name = "lblChucDanh"
        Me.lblChucDanh.Size = New System.Drawing.Size(20, 19)
        Me.lblChucDanh.TabIndex = 1400
        Me.lblChucDanh.Text = "Chức danh"
        Me.lblChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblChucDanh.Visible = False
        '
        'lblCard_No
        '
        Me.lblCard_No.BackColor = System.Drawing.Color.Transparent
        Me.lblCard_No.Location = New System.Drawing.Point(334, 621)
        Me.lblCard_No.Name = "lblCard_No"
        Me.lblCard_No.Size = New System.Drawing.Size(80, 19)
        Me.lblCard_No.TabIndex = 1399
        Me.lblCard_No.Text = "Số thẻ"
        Me.lblCard_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCard_No.Visible = False
        '
        'lblCard_Code
        '
        Me.lblCard_Code.BackColor = System.Drawing.Color.Transparent
        Me.lblCard_Code.Location = New System.Drawing.Point(334, 597)
        Me.lblCard_Code.Name = "lblCard_Code"
        Me.lblCard_Code.Size = New System.Drawing.Size(80, 19)
        Me.lblCard_Code.TabIndex = 1398
        Me.lblCard_Code.Text = "Mã thẻ"
        Me.lblCard_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCard_Code.Visible = False
        '
        'lblCongViecPhaiLam
        '
        Me.lblCongViecPhaiLam.BackColor = System.Drawing.Color.Transparent
        Me.lblCongViecPhaiLam.Location = New System.Drawing.Point(618, 223)
        Me.lblCongViecPhaiLam.Name = "lblCongViecPhaiLam"
        Me.lblCongViecPhaiLam.Size = New System.Drawing.Size(99, 40)
        Me.lblCongViecPhaiLam.TabIndex = 1397
        Me.lblCongViecPhaiLam.Text = "Công việc phải làm"
        Me.lblCongViecPhaiLam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CongViecPhaiLam
        '
        Me.CongViecPhaiLam.Location = New System.Drawing.Point(726, 234)
        Me.CongViecPhaiLam.Name = "CongViecPhaiLam"
        Me.CongViecPhaiLam.Size = New System.Drawing.Size(168, 23)
        Me.CongViecPhaiLam.TabIndex = 1389
        Me.CongViecPhaiLam.Text = ""
        '
        'lblMaSoThue
        '
        Me.lblMaSoThue.BackColor = System.Drawing.Color.Transparent
        Me.lblMaSoThue.Location = New System.Drawing.Point(910, 65)
        Me.lblMaSoThue.Name = "lblMaSoThue"
        Me.lblMaSoThue.Size = New System.Drawing.Size(114, 19)
        Me.lblMaSoThue.TabIndex = 1396
        Me.lblMaSoThue.Text = "Mã số thuế"
        Me.lblMaSoThue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDecisionCode
        '
        Me.lblDecisionCode.BackColor = System.Drawing.Color.Transparent
        Me.lblDecisionCode.Location = New System.Drawing.Point(618, 183)
        Me.lblDecisionCode.Name = "lblDecisionCode"
        Me.lblDecisionCode.Size = New System.Drawing.Size(92, 19)
        Me.lblDecisionCode.TabIndex = 1395
        Me.lblDecisionCode.Text = "Mã quyết định"
        Me.lblDecisionCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPlanTernimationDate
        '
        Me.lblPlanTernimationDate.BackColor = System.Drawing.Color.Transparent
        Me.lblPlanTernimationDate.Location = New System.Drawing.Point(618, 110)
        Me.lblPlanTernimationDate.Name = "lblPlanTernimationDate"
        Me.lblPlanTernimationDate.Size = New System.Drawing.Size(101, 24)
        Me.lblPlanTernimationDate.TabIndex = 1394
        Me.lblPlanTernimationDate.Text = "Ngày TV dự tính"
        Me.lblPlanTernimationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteamcode
        '
        Me.lblteamcode.BackColor = System.Drawing.Color.Transparent
        Me.lblteamcode.Location = New System.Drawing.Point(1080, 618)
        Me.lblteamcode.Name = "lblteamcode"
        Me.lblteamcode.Size = New System.Drawing.Size(20, 19)
        Me.lblteamcode.TabIndex = 1393
        Me.lblteamcode.Text = "Tổ"
        Me.lblteamcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblteamcode.Visible = False
        '
        'lblOfficialDate
        '
        Me.lblOfficialDate.BackColor = System.Drawing.Color.Transparent
        Me.lblOfficialDate.Location = New System.Drawing.Point(302, 66)
        Me.lblOfficialDate.Name = "lblOfficialDate"
        Me.lblOfficialDate.Size = New System.Drawing.Size(122, 19)
        Me.lblOfficialDate.TabIndex = 1392
        Me.lblOfficialDate.Text = "Ngày chính thức"
        Me.lblOfficialDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbldepartmentcode
        '
        Me.lbldepartmentcode.BackColor = System.Drawing.Color.Transparent
        Me.lbldepartmentcode.Location = New System.Drawing.Point(302, 113)
        Me.lbldepartmentcode.Name = "lbldepartmentcode"
        Me.lbldepartmentcode.Size = New System.Drawing.Size(122, 19)
        Me.lbldepartmentcode.TabIndex = 1388
        Me.lbldepartmentcode.Text = "Bộ phận"
        Me.lbldepartmentcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployee_ID
        '
        Me.lblEmployee_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployee_ID.Location = New System.Drawing.Point(17, 179)
        Me.lblEmployee_ID.Name = "lblEmployee_ID"
        Me.lblEmployee_ID.Size = New System.Drawing.Size(80, 19)
        Me.lblEmployee_ID.TabIndex = 1377
        Me.lblEmployee_ID.Text = "Mã nhân viên"
        Me.lblEmployee_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFullName
        '
        Me.lblFullName.BackColor = System.Drawing.Color.Transparent
        Me.lblFullName.Location = New System.Drawing.Point(17, 207)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(80, 19)
        Me.lblFullName.TabIndex = 1391
        Me.lblFullName.Text = "Tên"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBirthDate
        '
        Me.lblBirthDate.BackColor = System.Drawing.Color.Transparent
        Me.lblBirthDate.Location = New System.Drawing.Point(17, 231)
        Me.lblBirthDate.Name = "lblBirthDate"
        Me.lblBirthDate.Size = New System.Drawing.Size(80, 19)
        Me.lblBirthDate.TabIndex = 1378
        Me.lblBirthDate.Text = "Ngày sinh"
        Me.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSex
        '
        Me.lblSex.BackColor = System.Drawing.Color.Transparent
        Me.lblSex.Location = New System.Drawing.Point(17, 255)
        Me.lblSex.Name = "lblSex"
        Me.lblSex.Size = New System.Drawing.Size(80, 19)
        Me.lblSex.TabIndex = 1379
        Me.lblSex.Text = "Giới tính"
        Me.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition_ID
        '
        Me.lblPosition_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPosition_ID.Location = New System.Drawing.Point(301, 236)
        Me.lblPosition_ID.Name = "lblPosition_ID"
        Me.lblPosition_ID.Size = New System.Drawing.Size(122, 19)
        Me.lblPosition_ID.TabIndex = 1385
        Me.lblPosition_ID.Text = "Chức vụ"
        Me.lblPosition_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTernimationDate
        '
        Me.lblTernimationDate.BackColor = System.Drawing.Color.Transparent
        Me.lblTernimationDate.Location = New System.Drawing.Point(618, 92)
        Me.lblTernimationDate.Name = "lblTernimationDate"
        Me.lblTernimationDate.Size = New System.Drawing.Size(92, 19)
        Me.lblTernimationDate.TabIndex = 1387
        Me.lblTernimationDate.Text = "Ngày thôi việc"
        Me.lblTernimationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionCategory_ID
        '
        Me.lblPositionCategory_ID.BackColor = System.Drawing.Color.Transparent
        Me.lblPositionCategory_ID.Location = New System.Drawing.Point(300, 186)
        Me.lblPositionCategory_ID.Name = "lblPositionCategory_ID"
        Me.lblPositionCategory_ID.Size = New System.Drawing.Size(122, 19)
        Me.lblPositionCategory_ID.TabIndex = 1383
        Me.lblPositionCategory_ID.Text = "Loại chức vụ"
        Me.lblPositionCategory_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbStartedDate
        '
        Me.lbStartedDate.BackColor = System.Drawing.Color.Transparent
        Me.lbStartedDate.Location = New System.Drawing.Point(302, 42)
        Me.lbStartedDate.Name = "lbStartedDate"
        Me.lbStartedDate.Size = New System.Drawing.Size(122, 19)
        Me.lbStartedDate.TabIndex = 1384
        Me.lbStartedDate.Text = "Ngày vào"
        Me.lbStartedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployee_Status
        '
        Me.lblEmployee_Status.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployee_Status.Location = New System.Drawing.Point(618, 68)
        Me.lblEmployee_Status.Name = "lblEmployee_Status"
        Me.lblEmployee_Status.Size = New System.Drawing.Size(92, 19)
        Me.lblEmployee_Status.TabIndex = 1386
        Me.lblEmployee_Status.Text = "Trạng thái"
        Me.lblEmployee_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID_number
        '
        Me.lblID_number.BackColor = System.Drawing.Color.Transparent
        Me.lblID_number.Location = New System.Drawing.Point(302, 261)
        Me.lblID_number.Name = "lblID_number"
        Me.lblID_number.Size = New System.Drawing.Size(80, 19)
        Me.lblID_number.TabIndex = 1380
        Me.lblID_number.Text = "CCCD"
        Me.lblID_number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID_date
        '
        Me.lblID_date.BackColor = System.Drawing.Color.Transparent
        Me.lblID_date.Location = New System.Drawing.Point(302, 290)
        Me.lblID_date.Name = "lblID_date"
        Me.lblID_date.Size = New System.Drawing.Size(116, 16)
        Me.lblID_date.TabIndex = 1381
        Me.lblID_date.Text = "Ngày cấp"
        Me.lblID_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblID_place
        '
        Me.lblID_place.BackColor = System.Drawing.Color.Transparent
        Me.lblID_place.Location = New System.Drawing.Point(302, 314)
        Me.lblID_place.Name = "lblID_place"
        Me.lblID_place.Size = New System.Drawing.Size(80, 19)
        Me.lblID_place.TabIndex = 1382
        Me.lblID_place.Text = "Cấp tại"
        Me.lblID_place.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResonTerminated
        '
        Me.lblResonTerminated.BackColor = System.Drawing.Color.Transparent
        Me.lblResonTerminated.Location = New System.Drawing.Point(618, 137)
        Me.lblResonTerminated.Name = "lblResonTerminated"
        Me.lblResonTerminated.Size = New System.Drawing.Size(92, 19)
        Me.lblResonTerminated.TabIndex = 1390
        Me.lblResonTerminated.Text = "Lý do"
        Me.lblResonTerminated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserName
        '
        Me.UserName.Enabled = False
        Me.UserName.Location = New System.Drawing.Point(831, 402)
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Size = New System.Drawing.Size(17, 21)
        Me.UserName.TabIndex = 1374
        Me.UserName.Visible = False
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Location = New System.Drawing.Point(796, 402)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(31, 19)
        Me.lblUserName.TabIndex = 1376
        Me.lblUserName.Text = "UserName"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUserName.Visible = False
        '
        'lblInsertDate
        '
        Me.lblInsertDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertDate.Location = New System.Drawing.Point(901, 429)
        Me.lblInsertDate.Name = "lblInsertDate"
        Me.lblInsertDate.Size = New System.Drawing.Size(114, 19)
        Me.lblInsertDate.TabIndex = 1375
        Me.lblInsertDate.Text = "InsertDate"
        Me.lblInsertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(320, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 766)
        Me.Splitter1.TabIndex = 1322
        Me.Splitter1.TabStop = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(320, 766)
        Me.GridControl1.TabIndex = 1323
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'NhapNVMoi
        '
        Me.NhapNVMoi.Appearance.PageClient.BackColor = System.Drawing.Color.White
        Me.NhapNVMoi.Appearance.PageClient.Options.UseBackColor = True
        Me.NhapNVMoi.Controls.Add(Me.GridControl2)
        Me.NhapNVMoi.Name = "NhapNVMoi"
        Me.NhapNVMoi.Size = New System.Drawing.Size(1528, 766)
        Me.NhapNVMoi.Text = "Nhập nhân viên mới"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1528, 766)
        Me.GridControl2.TabIndex = 1308
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'Utilities
        '
        Me.Utilities.Appearance.PageClient.BackColor = System.Drawing.Color.White
        Me.Utilities.Appearance.PageClient.Options.UseBackColor = True
        Me.Utilities.Controls.Add(Me.FlowLayoutPanel1)
        Me.Utilities.Controls.Add(Me.TruongCapNhat)
        Me.Utilities.Controls.Add(Me.Url)
        Me.Utilities.Controls.Add(Me.btnNhapAnh)
        Me.Utilities.Controls.Add(Me.btnNhap)
        Me.Utilities.Controls.Add(Me.btnUrl)
        Me.Utilities.Controls.Add(Me.btnLayTemplate)
        Me.Utilities.Controls.Add(Me.gbDoiMaNhanVien)
        Me.Utilities.Name = "Utilities"
        Me.Utilities.Size = New System.Drawing.Size(1528, 766)
        Me.Utilities.Text = "Tiện ích"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(29, 128)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(838, 421)
        Me.FlowLayoutPanel1.TabIndex = 1224
        Me.FlowLayoutPanel1.Visible = False
        '
        'TruongCapNhat
        '
        Me.TruongCapNhat.Location = New System.Drawing.Point(29, 81)
        Me.TruongCapNhat.Name = "TruongCapNhat"
        Me.TruongCapNhat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TruongCapNhat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TruongCapNhat.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.TruongCapNhat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TruongCapNhat.Size = New System.Drawing.Size(393, 20)
        Me.TruongCapNhat.TabIndex = 1223
        '
        'Url
        '
        Me.Url.Location = New System.Drawing.Point(29, 52)
        Me.Url.Name = "Url"
        Me.Url.Size = New System.Drawing.Size(356, 21)
        Me.Url.TabIndex = 1222
        '
        'btnNhapAnh
        '
        Me.btnNhapAnh.Location = New System.Drawing.Point(995, 14)
        Me.btnNhapAnh.Name = "btnNhapAnh"
        Me.btnNhapAnh.Size = New System.Drawing.Size(103, 25)
        Me.btnNhapAnh.TabIndex = 1221
        Me.btnNhapAnh.Text = "Nhập ảnh"
        '
        'btnNhap
        '
        Me.btnNhap.Location = New System.Drawing.Point(428, 81)
        Me.btnNhap.Name = "btnNhap"
        Me.btnNhap.Size = New System.Drawing.Size(60, 20)
        Me.btnNhap.TabIndex = 1220
        Me.btnNhap.Text = "Nhập"
        '
        'btnUrl
        '
        Me.btnUrl.Location = New System.Drawing.Point(391, 52)
        Me.btnUrl.Name = "btnUrl"
        Me.btnUrl.Size = New System.Drawing.Size(31, 22)
        Me.btnUrl.TabIndex = 1219
        Me.btnUrl.Text = "..."
        '
        'btnLayTemplate
        '
        Me.btnLayTemplate.Location = New System.Drawing.Point(29, 28)
        Me.btnLayTemplate.Name = "btnLayTemplate"
        Me.btnLayTemplate.Size = New System.Drawing.Size(94, 19)
        Me.btnLayTemplate.TabIndex = 1218
        Me.btnLayTemplate.Text = "Lấy template"
        '
        'gbDoiMaNhanVien
        '
        Me.gbDoiMaNhanVien.Controls.Add(Me.txtMaNVMoi)
        Me.gbDoiMaNhanVien.Controls.Add(Me.txtMaNVCu)
        Me.gbDoiMaNhanVien.Controls.Add(Me.btnDoiMaNV)
        Me.gbDoiMaNhanVien.Controls.Add(Me.lblMaMoi)
        Me.gbDoiMaNhanVien.Controls.Add(Me.lblMaCu)
        Me.gbDoiMaNhanVien.Location = New System.Drawing.Point(568, 14)
        Me.gbDoiMaNhanVien.Name = "gbDoiMaNhanVien"
        Me.gbDoiMaNhanVien.Size = New System.Drawing.Size(406, 89)
        Me.gbDoiMaNhanVien.TabIndex = 1216
        Me.gbDoiMaNhanVien.TabStop = False
        Me.gbDoiMaNhanVien.Text = "Đổi mã nhân viên"
        '
        'txtMaNVMoi
        '
        Me.txtMaNVMoi.Location = New System.Drawing.Point(172, 50)
        Me.txtMaNVMoi.Name = "txtMaNVMoi"
        Me.txtMaNVMoi.Size = New System.Drawing.Size(131, 21)
        Me.txtMaNVMoi.TabIndex = 1301
        '
        'txtMaNVCu
        '
        Me.txtMaNVCu.Location = New System.Drawing.Point(172, 21)
        Me.txtMaNVCu.Name = "txtMaNVCu"
        Me.txtMaNVCu.Size = New System.Drawing.Size(131, 21)
        Me.txtMaNVCu.TabIndex = 1223
        '
        'btnDoiMaNV
        '
        Me.btnDoiMaNV.Location = New System.Drawing.Point(321, 20)
        Me.btnDoiMaNV.Name = "btnDoiMaNV"
        Me.btnDoiMaNV.Size = New System.Drawing.Size(79, 51)
        Me.btnDoiMaNV.TabIndex = 1221
        Me.btnDoiMaNV.Text = "Đổi mã " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "nhân viên"
        '
        'lblMaMoi
        '
        Me.lblMaMoi.BackColor = System.Drawing.Color.Transparent
        Me.lblMaMoi.Location = New System.Drawing.Point(21, 50)
        Me.lblMaMoi.Name = "lblMaMoi"
        Me.lblMaMoi.Size = New System.Drawing.Size(145, 19)
        Me.lblMaMoi.TabIndex = 1300
        Me.lblMaMoi.Text = "Mã mới"
        Me.lblMaMoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaCu
        '
        Me.lblMaCu.BackColor = System.Drawing.Color.Transparent
        Me.lblMaCu.Location = New System.Drawing.Point(21, 21)
        Me.lblMaCu.Name = "lblMaCu"
        Me.lblMaCu.Size = New System.Drawing.Size(145, 19)
        Me.lblMaCu.TabIndex = 1298
        Me.lblMaCu.Text = "Mã cũ"
        Me.lblMaCu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEmployeeInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1530, 846)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.HRFORM_DeleteStore = "usp_DeleteEmployeeInformation"
        Me.HRFORM_GridControl = Me.GridControl1
        Me.HRFORM_Gridview = Me.GridView1
        Me.HRFORM_SaveStore = "usp_InsertUpdateSmartBooks_Employee"
        Me.HRFORM_TableName = "SmartBooks_Employee"
        Me.HRFORM_TuDongDongSauKhiLuu = False
        Me.HRFORM_TypeOfForm = WindowsControlLibrary.HRFORM.TypeOfForm.ViewInput
        Me.HRFORM_VisibleControl_GetTemplate = False
        Me.HRFORM_VisibleControl_Sua = False
        Me.HRFORM_VisibleControl_ThemMoi = False
        Me.HRFORM_XtraTabControl = Me.XtraTabControl1
        Me.Name = "frmEmployeeInfo"
        Me.Text = "frmEmployeeInfo"
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.MainInformation.ResumeLayout(False)
        Me.MainInformation.PerformLayout()
        CType(Me.NgayHetHanCCCD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayHetHanCCCD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCCDCu_Date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCCDCu_Date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureCCCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EndOfSeasonWorker.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EndOfSeasonWorker.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsertDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeOfHiring.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContractFlow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ID_date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ID_date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaritalStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sex.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BirthDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BirthDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuanHeVoiChuHo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nationality.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayTGCongDoan.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayTGCongDoan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Qualification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Employee_Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanTernimationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanTernimationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TernimationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TernimationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DecisionStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChucDanh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PositionCategory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Position_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teamcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sectioncode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.departmentcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Factory_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficialDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficialDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComStartedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComStartedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Weight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Height, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NhapNVMoi.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Utilities.ResumeLayout(False)
        Me.Utilities.PerformLayout()
        CType(Me.TruongCapNhat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDoiMaNhanVien.ResumeLayout(False)
        Me.gbDoiMaNhanVien.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents General As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents NhapNVMoi As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Utilities As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gbDoiMaNhanVien As GroupBox
    Friend WithEvents lblMaMoi As Label
    Friend WithEvents lblMaCu As Label
    Friend WithEvents btnLayTemplate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNhapAnh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNhap As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUrl As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDoiMaNV As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Url As TextBox
    Friend WithEvents txtMaNVMoi As TextBox
    Friend WithEvents txtMaNVCu As TextBox
    Friend WithEvents TruongCapNhat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents MainInformation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SoNgayPhepNam As TextBox
    Friend WithEvents InsertDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents RFID As TextBox
    Friend WithEvents lblTypeOfHiring As Label
    Friend WithEvents TypeOfHiring As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ResonTerminated As TextBox
    Friend WithEvents ContractFlow As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ID_date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents MaritalStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Sex As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BirthDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents QuanHeVoiChuHo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Nationality As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents NgayTGCongDoan As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Qualification As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GraduatedFrom As TextBox
    Friend WithEvents DebitAccount As TextBox
    Friend WithEvents BankCode As TextBox
    Friend WithEvents BankAccount As TextBox
    Friend WithEvents BankName As TextBox
    Friend WithEvents MaSoThue As TextBox
    Friend WithEvents Employee_Status As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PlanTernimationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TernimationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DecisionStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ChucDanh As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PositionCategory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Position_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents teamcode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents sectioncode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents departmentcode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Factory_ID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents EmployeeSearch As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OfficialDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ComStartedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents StartedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents IE_FLAG As TextBox
    Friend WithEvents JobCode As TextBox
    Friend WithEvents DecisionCode As TextBox
    Friend WithEvents AbsentStatus As TextBox
    Friend WithEvents NguoiLienHeGap As TextBox
    Friend WithEvents TenChuHo As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Tel As TextBox
    Friend WithEvents ID_number As TextBox
    Friend WithEvents Employee_Lastname As TextBox
    Friend WithEvents Employee_Firstname As TextBox
    Friend WithEvents Card_No As TextBox
    Friend WithEvents Card_Code As TextBox
    Friend WithEvents Employee_ID As TextBox
    Friend WithEvents btnXoaAnh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAnh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNgayTGCongDoan As Label
    Friend WithEvents isThuViec85PhanTram As CheckBox
    Friend WithEvents lblBookCode As Label
    Friend WithEvents SoSoBaoHiem As TextBox
    Friend WithEvents lblQuanHeVoiChuHo As Label
    Friend WithEvents lblTenChuHo As Label
    Friend WithEvents lblLeaveType_ID As Label
    Friend WithEvents BirthDateFormat As ComboBox
    Friend WithEvents lblRFID As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents lblPicture As Label
    Friend WithEvents Picture As PictureBox
    Friend WithEvents lblHealthCheckFee As Label
    Friend WithEvents HealthCheckFee As TextBox
    Friend WithEvents lblHospital As Label
    Friend WithEvents Hospital As RichTextBox
    Friend WithEvents Weight As NumericUpDown
    Friend WithEvents lblWeight As Label
    Friend WithEvents Height As NumericUpDown
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblDecisionStatus As Label
    Friend WithEvents lblJobCode As Label
    Friend WithEvents TanTat As RichTextBox
    Friend WithEvents lblComStartedDate As Label
    Friend WithEvents lblNguoiLienHeGap As Label
    Friend WithEvents lblTanTat As Label
    Friend WithEvents lblTonGiao As Label
    Friend WithEvents lblFactory_ID As Label
    Friend WithEvents Address_Temporary As WindowsControlLibrary.Address
    Friend WithEvents Address_Permanent As WindowsControlLibrary.Address
    Friend WithEvents lblRemark As Label
    Friend WithEvents Remark As RichTextBox
    Friend WithEvents lblContractFlow As Label
    Friend WithEvents lblSoNgayPhepNam As Label
    Friend WithEvents lblThongTinKhac As Label
    Friend WithEvents lblQualification As Label
    Friend WithEvents lblGraduated As Label
    Friend WithEvents lblGraduatedFrom As Label
    Friend WithEvents lblTrinhDoChuyenMon As Label
    Friend WithEvents lblThongTinLienLac As Label
    Friend WithEvents lblThongTinNganHangThe As Label
    Friend WithEvents lblTrangThaiLamViec As Label
    Friend WithEvents lblThongTinChinh As Label
    Friend WithEvents lblBirthPlace As Label
    Friend WithEvents lblAddress_Permanent As Label
    Friend WithEvents lblAddress_Temporary As Label
    Friend WithEvents lblDebitAccount As Label
    Friend WithEvents lblBankCode As Label
    Friend WithEvents lblBankName As Label
    Friend WithEvents lblBankAccount As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblTel As Label
    Friend WithEvents lblNation As Label
    Friend WithEvents lblNationality As Label
    Friend WithEvents lbNativePlace As Label
    Friend WithEvents lblsectioncode As Label
    Friend WithEvents lblChucDanh As Label
    Friend WithEvents lblCard_No As Label
    Friend WithEvents lblCard_Code As Label
    Friend WithEvents lblCongViecPhaiLam As Label
    Friend WithEvents CongViecPhaiLam As RichTextBox
    Friend WithEvents lblMaSoThue As Label
    Friend WithEvents lblDecisionCode As Label
    Friend WithEvents lblPlanTernimationDate As Label
    Friend WithEvents lblteamcode As Label
    Friend WithEvents lblOfficialDate As Label
    Friend WithEvents lbldepartmentcode As Label
    Friend WithEvents lblEmployee_ID As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblBirthDate As Label
    Friend WithEvents lblSex As Label
    Friend WithEvents lblPosition_ID As Label
    Friend WithEvents lblTernimationDate As Label
    Friend WithEvents lblPositionCategory_ID As Label
    Friend WithEvents lbStartedDate As Label
    Friend WithEvents lblEmployee_Status As Label
    Friend WithEvents lblID_number As Label
    Friend WithEvents lblID_date As Label
    Friend WithEvents lblID_place As Label
    Friend WithEvents lblResonTerminated As Label
    Friend WithEvents UserName As TextBox
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblInsertDate As Label
    Friend WithEvents IsSeasonWorker As CheckBox
    Friend WithEvents lblSeasonWorker As Label
    Friend WithEvents EndOfSeasonWorker As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblEndOfSeasonWorker As Label
    Friend WithEvents IsNhapNhanVienMoi As CheckBox
    Friend WithEvents lblNhapNhanVienMoi As Label
    Friend WithEvents lblAnhCCCD As Label
    Friend WithEvents btnXoaAnhCCCD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChonAnhCCCD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureCCCD As PictureBox
    Friend WithEvents CCCDCu_Place As TextBox
    Friend WithEvents lblCCCDCu_Place As Label
    Friend WithEvents lblCCCDCu_Date As Label
    Friend WithEvents CCCDCu As TextBox
    Friend WithEvents lblCCCDCu As Label
    Friend WithEvents ID_place As TextBox
    Friend WithEvents CCCDCu_Date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnStopCam As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnStartCam As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PicCam As PictureBox
    Friend WithEvents NgayHetHanCCCD As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblNgayHetHanCCCD As Label
    Friend WithEvents lblIsManager As Label
    Friend WithEvents isManager As CheckBox
    Friend WithEvents lblCamket As Label
    Friend WithEvents CamKet As CheckBox
    Friend WithEvents NguoiGT As TextBox
    Friend WithEvents lblNguoiGT As Label
    Friend WithEvents Accountcode1 As TextBox
    Friend WithEvents lblAccountcode1 As Label
    Friend WithEvents AccountCode3 As TextBox
    Friend WithEvents lblAccountCode3 As Label
    Friend WithEvents AccountCode2 As TextBox
    Friend WithEvents lblAccountCode2 As Label
    Friend WithEvents cbbChonCam As ComboBox
    Friend WithEvents btnChup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BirthPlace As TextBox
    Friend WithEvents NativePlace As TextBox
    Friend WithEvents lblsectioncode1 As Label
    Friend WithEvents TonGiao As TextBox
    Friend WithEvents Graduated As TextBox
    Friend WithEvents lblisTanTat As Label
    Friend WithEvents isTanTat As CheckBox
    Friend WithEvents Nation As TextBox
End Class
