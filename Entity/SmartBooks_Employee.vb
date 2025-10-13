Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "SmartBooks_Employee"
    ''' <summary>
    ''' This object represents the properties and methods of a SmartBooks_Employee.
    ''' </summary>
    Public Class SmartBooks_Employee
        Private _employee_ID As System.String = String.Empty
        Private _employee_Firstname As System.String = String.Empty
        Private _employee_LastName As System.String = String.Empty
        Private _birthDate As System.DateTime
        Private _birthPlace As System.String = String.Empty
        Private _birthPlace_EN As System.String = String.Empty
        Private _sex As System.String = String.Empty
        Private _maritalStatus As System.String = String.Empty
        Private _nationality As System.String = String.Empty
        Private _nationality_EN As System.String = String.Empty
        Private _iD_number As System.String = String.Empty
        Private _iD_date As System.DateTime
        Private _iD_place As System.String = String.Empty
        Private _iD_place_EN As System.String = String.Empty
        Private _address_Temporary As System.String = String.Empty
        Private _address_Temporary_EN As System.String = String.Empty
        Private _address_Permanent As System.String = String.Empty
        Private _address_Permanent_EN As System.String = String.Empty
        Private _employee_Status As System.String = String.Empty
        Private _startedDate As System.DateTime
        Private _ternimationDate As System.DateTime
        Private _departmentCode As System.String = String.Empty
        Private _sectionCode As System.String = String.Empty
        Private _teamCode As System.String = String.Empty
        Private _position_ID As System.String = String.Empty
        Private _positionCategory_ID As System.String = String.Empty
        Private _factory As System.String = String.Empty
        Private _tel As System.String = String.Empty
        Private _salaryBasic As System.Double
        Private _salaryInsure As System.Double
        Private _salaryProbation As System.String = String.Empty
        Private _allowance_Responsibility As System.String = String.Empty
        Private _allowance_Experience As System.String = String.Empty
        Private _allowance_Business As System.String = String.Empty
        Private _allowance_Other As System.String = String.Empty
        Private _nguoiGiamHo As System.String = String.Empty
        Private _labourContract_No As System.Double
        Private _labourContract_Date As System.DateTime
        Private _labourBook_No As System.Double
        Private _labourBook_Date As System.DateTime
        Private _labourBook_Place As System.String = String.Empty
        Private _card_No As System.Double
        Private _bankAccount As System.String = String.Empty
        Private _bankName As System.String = String.Empty
        Private _discipline_Note As System.String = String.Empty
        Private _promotion_Note As System.String = String.Empty
        Private _training_note As System.String = String.Empty
        Private _education As System.String = String.Empty
        Private _nativePlace As System.String = String.Empty
        Private _noiDangKyBaoHiem As System.String = String.Empty
        Private _maxl As System.String = String.Empty
    Private _picture As System.Byte()
        Private _related_Note As System.String = String.Empty
        Private _fullDocument As System.String = String.Empty
        Private _qualification As System.String = String.Empty
        Private _fStatus As System.String = String.Empty
        Private _permanentContact_Name As System.String = String.Empty
        Private _permanentContact_Relation As System.String = String.Empty
        Private _temporaryContact_Name As System.String = String.Empty
        Private _temporaryContact_Relation As System.String = String.Empty
        Private _expiredDate As System.String = String.Empty
        Private _probationDate As System.DateTime
        Private _f_Fromdate As System.String = String.Empty
        Private _f_Todate As System.String = String.Empty
        Private _graduatedFrom As System.String = String.Empty
        Private _isExternal As System.String = String.Empty
        Private _isSIHI As System.String = String.Empty
        Private _isManager As System.String = String.Empty
        Private _isEarlyTime As System.Boolean
        Private _defaultShift As System.String = String.Empty
        Private _allowance_Productivity As System.String = String.Empty
        Private _allowance_Style As System.String = String.Empty
        Private _allowance_House As System.String = String.Empty
        Private _allowance_Position As System.String = String.Empty
        Private _allowance_Attendance As System.String = String.Empty
        Private _allowance_Toxic As System.String = String.Empty
        Private _allowance_Petrol As System.String = String.Empty
        Private _resonTerminated As System.String = String.Empty
        Private _email As System.String = String.Empty
        Private _ngayQDNghiViec As System.DateTime
        Private _maQuyetDinh As System.String = String.Empty
        Private _ngayBanGiao As System.DateTime
        Private _maSoThue As System.String = String.Empty
        Private _congViecPhaiLam As System.String = String.Empty
        Private _soNgayPhepCuaThang As System.Double
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal Employee_ID As System.String)
            Dim name() As String = {"@Employee_ID"}
            Dim oj() As Object = {Employee_ID}
            Dim tp() As String = {"NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Employee", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _employee_ID = Employee_ID
            End If
        Else
            _employee_ID = Employee_ID
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("Employee_Firstname")) Then
                    _employee_Firstname = _datarow("Employee_Firstname")
                End If
                If Not IsDBNull(_datarow("Employee_LastName")) Then
                    _employee_LastName = _datarow("Employee_LastName")
                End If
                If Not IsDBNull(_datarow("BirthDate")) Then
                    _birthDate = _datarow("BirthDate")
                End If
                If Not IsDBNull(_datarow("BirthPlace")) Then
                    _birthPlace = _datarow("BirthPlace")
                End If
                If Not IsDBNull(_datarow("BirthPlace_EN")) Then
                    _birthPlace_EN = _datarow("BirthPlace_EN")
                End If
                If Not IsDBNull(_datarow("Sex")) Then
                    _sex = _datarow("Sex")
                End If
                If Not IsDBNull(_datarow("MaritalStatus")) Then
                    _maritalStatus = _datarow("MaritalStatus")
                End If
                If Not IsDBNull(_datarow("Nationality")) Then
                    _nationality = _datarow("Nationality")
                End If
                If Not IsDBNull(_datarow("Nationality_EN")) Then
                    _nationality_EN = _datarow("Nationality_EN")
                End If
                If Not IsDBNull(_datarow("ID_number")) Then
                    _iD_number = _datarow("ID_number")
                End If
                If Not IsDBNull(_datarow("ID_date")) Then
                    _iD_date = _datarow("ID_date")
                End If
                If Not IsDBNull(_datarow("ID_place")) Then
                    _iD_place = _datarow("ID_place")
                End If
                If Not IsDBNull(_datarow("ID_place_EN")) Then
                    _iD_place_EN = _datarow("ID_place_EN")
                End If
                If Not IsDBNull(_datarow("Address_Temporary")) Then
                    _address_Temporary = _datarow("Address_Temporary")
                End If
                If Not IsDBNull(_datarow("Address_Temporary_EN")) Then
                    _address_Temporary_EN = _datarow("Address_Temporary_EN")
                End If
                If Not IsDBNull(_datarow("Address_Permanent")) Then
                    _address_Permanent = _datarow("Address_Permanent")
                End If
                If Not IsDBNull(_datarow("Address_Permanent_EN")) Then
                    _address_Permanent_EN = _datarow("Address_Permanent_EN")
                End If
                If Not IsDBNull(_datarow("Employee_Status")) Then
                    _employee_Status = _datarow("Employee_Status")
                End If
                If Not IsDBNull(_datarow("StartedDate")) Then
                    _startedDate = _datarow("StartedDate")
                End If
                If Not IsDBNull(_datarow("TernimationDate")) Then
                    _ternimationDate = _datarow("TernimationDate")
                End If
                If Not IsDBNull(_datarow("DepartmentCode")) Then
                    _departmentCode = _datarow("DepartmentCode")
                End If
                If Not IsDBNull(_datarow("SectionCode")) Then
                    _sectionCode = _datarow("SectionCode")
                End If
                If Not IsDBNull(_datarow("TeamCode")) Then
                    _teamCode = _datarow("TeamCode")
                End If
                If Not IsDBNull(_datarow("Position_ID")) Then
                    _position_ID = _datarow("Position_ID")
                End If
                If Not IsDBNull(_datarow("PositionCategory_ID")) Then
                    _positionCategory_ID = _datarow("PositionCategory_ID")
                End If
                If Not IsDBNull(_datarow("Factory")) Then
                    _factory = _datarow("Factory")
                End If
                If Not IsDBNull(_datarow("Tel")) Then
                    _tel = _datarow("Tel")
                End If
                If Not IsDBNull(_datarow("SalaryBasic")) Then
                    _salaryBasic = _datarow("SalaryBasic")
                End If
                If Not IsDBNull(_datarow("SalaryInsure")) Then
                    _salaryInsure = _datarow("SalaryInsure")
                End If
                If Not IsDBNull(_datarow("SalaryProbation")) Then
                    _salaryProbation = _datarow("SalaryProbation")
                End If
                If Not IsDBNull(_datarow("Allowance_Responsibility")) Then
                    _allowance_Responsibility = _datarow("Allowance_Responsibility")
                End If
                If Not IsDBNull(_datarow("Allowance_Experience")) Then
                    _allowance_Experience = _datarow("Allowance_Experience")
                End If
                If Not IsDBNull(_datarow("Allowance_Business")) Then
                    _allowance_Business = _datarow("Allowance_Business")
                End If
                If Not IsDBNull(_datarow("Allowance_Other")) Then
                    _allowance_Other = _datarow("Allowance_Other")
                End If
                If Not IsDBNull(_datarow("NguoiGiamHo")) Then
                    _nguoiGiamHo = _datarow("NguoiGiamHo")
                End If
                If Not IsDBNull(_datarow("LabourContract_No")) Then
                    _labourContract_No = _datarow("LabourContract_No")
                End If
                If Not IsDBNull(_datarow("LabourContract_Date")) Then
                    _labourContract_Date = _datarow("LabourContract_Date")
                End If
                If Not IsDBNull(_datarow("LabourBook_No")) Then
                    _labourBook_No = _datarow("LabourBook_No")
                End If
                If Not IsDBNull(_datarow("LabourBook_Date")) Then
                    _labourBook_Date = _datarow("LabourBook_Date")
                End If
                If Not IsDBNull(_datarow("LabourBook_Place")) Then
                    _labourBook_Place = _datarow("LabourBook_Place")
                End If
                If Not IsDBNull(_datarow("Card_No")) Then
                    _card_No = _datarow("Card_No")
                End If
                If Not IsDBNull(_datarow("BankAccount")) Then
                    _bankAccount = _datarow("BankAccount")
                End If
                If Not IsDBNull(_datarow("BankName")) Then
                    _bankName = _datarow("BankName")
                End If
                If Not IsDBNull(_datarow("Discipline_Note")) Then
                    _discipline_Note = _datarow("Discipline_Note")
                End If
                If Not IsDBNull(_datarow("Promotion_Note")) Then
                    _promotion_Note = _datarow("Promotion_Note")
                End If
                If Not IsDBNull(_datarow("Training_note")) Then
                    _training_note = _datarow("Training_note")
                End If
                If Not IsDBNull(_datarow("Education")) Then
                    _education = _datarow("Education")
                End If
                If Not IsDBNull(_datarow("NativePlace")) Then
                    _nativePlace = _datarow("NativePlace")
                End If
                If Not IsDBNull(_datarow("NoiDangKyBaoHiem")) Then
                    _noiDangKyBaoHiem = _datarow("NoiDangKyBaoHiem")
                End If
                If Not IsDBNull(_datarow("maxl")) Then
                    _maxl = _datarow("maxl")
                End If
                If Not IsDBNull(_datarow("picture")) Then
                    _picture = _datarow("picture")
                End If
                If Not IsDBNull(_datarow("Related_Note")) Then
                    _related_Note = _datarow("Related_Note")
                End If
                If Not IsDBNull(_datarow("FullDocument")) Then
                    _fullDocument = _datarow("FullDocument")
                End If
                If Not IsDBNull(_datarow("Qualification")) Then
                    _qualification = _datarow("Qualification")
                End If
                If Not IsDBNull(_datarow("FStatus")) Then
                    _fStatus = _datarow("FStatus")
                End If
                If Not IsDBNull(_datarow("PermanentContact_Name")) Then
                    _permanentContact_Name = _datarow("PermanentContact_Name")
                End If
                If Not IsDBNull(_datarow("PermanentContact_Relation")) Then
                    _permanentContact_Relation = _datarow("PermanentContact_Relation")
                End If
                If Not IsDBNull(_datarow("TemporaryContact_Name")) Then
                    _temporaryContact_Name = _datarow("TemporaryContact_Name")
                End If
                If Not IsDBNull(_datarow("TemporaryContact_Relation")) Then
                    _temporaryContact_Relation = _datarow("TemporaryContact_Relation")
                End If
                If Not IsDBNull(_datarow("ExpiredDate")) Then
                    _expiredDate = _datarow("ExpiredDate")
                End If
                If Not IsDBNull(_datarow("ProbationDate")) Then
                    _probationDate = _datarow("ProbationDate")
                End If
                If Not IsDBNull(_datarow("F_Fromdate")) Then
                    _f_Fromdate = _datarow("F_Fromdate")
                End If
                If Not IsDBNull(_datarow("F_Todate")) Then
                    _f_Todate = _datarow("F_Todate")
                End If
                If Not IsDBNull(_datarow("GraduatedFrom")) Then
                    _graduatedFrom = _datarow("GraduatedFrom")
                End If
                If Not IsDBNull(_datarow("isExternal")) Then
                    _isExternal = _datarow("isExternal")
                End If
                If Not IsDBNull(_datarow("isSIHI")) Then
                    _isSIHI = _datarow("isSIHI")
                End If
                If Not IsDBNull(_datarow("isManager")) Then
                    _isManager = _datarow("isManager")
                End If
                If Not IsDBNull(_datarow("isEarlyTime")) Then
                    _isEarlyTime = _datarow("isEarlyTime")
                End If
                If Not IsDBNull(_datarow("defaultShift")) Then
                    _defaultShift = _datarow("defaultShift")
                End If
                If Not IsDBNull(_datarow("Allowance_Productivity")) Then
                    _allowance_Productivity = _datarow("Allowance_Productivity")
                End If
                If Not IsDBNull(_datarow("Allowance_Style")) Then
                    _allowance_Style = _datarow("Allowance_Style")
                End If
                If Not IsDBNull(_datarow("Allowance_House")) Then
                    _allowance_House = _datarow("Allowance_House")
                End If
                If Not IsDBNull(_datarow("Allowance_Position")) Then
                    _allowance_Position = _datarow("Allowance_Position")
                End If
                If Not IsDBNull(_datarow("Allowance_Attendance")) Then
                    _allowance_Attendance = _datarow("Allowance_Attendance")
                End If
                If Not IsDBNull(_datarow("Allowance_Toxic")) Then
                    _allowance_Toxic = _datarow("Allowance_Toxic")
                End If
                If Not IsDBNull(_datarow("Allowance_Petrol")) Then
                    _allowance_Petrol = _datarow("Allowance_Petrol")
                End If
                If Not IsDBNull(_datarow("ResonTerminated")) Then
                    _resonTerminated = _datarow("ResonTerminated")
                End If
                If Not IsDBNull(_datarow("Email")) Then
                    _email = _datarow("Email")
                End If
                If Not IsDBNull(_datarow("NgayQDNghiViec")) Then
                    _ngayQDNghiViec = _datarow("NgayQDNghiViec")
                End If
                If Not IsDBNull(_datarow("MaQuyetDinh")) Then
                    _maQuyetDinh = _datarow("MaQuyetDinh")
                End If
                If Not IsDBNull(_datarow("NgayBanGiao")) Then
                    _ngayBanGiao = _datarow("NgayBanGiao")
                End If
                If Not IsDBNull(_datarow("MaSoThue")) Then
                    _maSoThue = _datarow("MaSoThue")
                End If
                If Not IsDBNull(_datarow("CongViecPhaiLam")) Then
                    _congViecPhaiLam = _datarow("CongViecPhaiLam")
                End If
                If Not IsDBNull(_datarow("SoNgayPhepCuaThang")) Then
                    _soNgayPhepCuaThang = _datarow("SoNgayPhepCuaThang")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("Employee_Firstname")) Then
                    _employee_Firstname = _datarow("Employee_Firstname")
                End If
                If Not IsDBNull(_datarow("Employee_LastName")) Then
                    _employee_LastName = _datarow("Employee_LastName")
                End If
                If Not IsDBNull(_datarow("BirthDate")) Then
                    _birthDate = _datarow("BirthDate")
                End If
                If Not IsDBNull(_datarow("BirthPlace")) Then
                    _birthPlace = _datarow("BirthPlace")
                End If
                If Not IsDBNull(_datarow("BirthPlace_EN")) Then
                    _birthPlace_EN = _datarow("BirthPlace_EN")
                End If
                If Not IsDBNull(_datarow("Sex")) Then
                    _sex = _datarow("Sex")
                End If
                If Not IsDBNull(_datarow("MaritalStatus")) Then
                    _maritalStatus = _datarow("MaritalStatus")
                End If
                If Not IsDBNull(_datarow("Nationality")) Then
                    _nationality = _datarow("Nationality")
                End If
                If Not IsDBNull(_datarow("Nationality_EN")) Then
                    _nationality_EN = _datarow("Nationality_EN")
                End If
                If Not IsDBNull(_datarow("ID_number")) Then
                    _iD_number = _datarow("ID_number")
                End If
                If Not IsDBNull(_datarow("ID_date")) Then
                    _iD_date = _datarow("ID_date")
                End If
                If Not IsDBNull(_datarow("ID_place")) Then
                    _iD_place = _datarow("ID_place")
                End If
                If Not IsDBNull(_datarow("ID_place_EN")) Then
                    _iD_place_EN = _datarow("ID_place_EN")
                End If
                If Not IsDBNull(_datarow("Address_Temporary")) Then
                    _address_Temporary = _datarow("Address_Temporary")
                End If
                If Not IsDBNull(_datarow("Address_Temporary_EN")) Then
                    _address_Temporary_EN = _datarow("Address_Temporary_EN")
                End If
                If Not IsDBNull(_datarow("Address_Permanent")) Then
                    _address_Permanent = _datarow("Address_Permanent")
                End If
                If Not IsDBNull(_datarow("Address_Permanent_EN")) Then
                    _address_Permanent_EN = _datarow("Address_Permanent_EN")
                End If
                If Not IsDBNull(_datarow("Employee_Status")) Then
                    _employee_Status = _datarow("Employee_Status")
                End If
                If Not IsDBNull(_datarow("StartedDate")) Then
                    _startedDate = _datarow("StartedDate")
                End If
                If Not IsDBNull(_datarow("TernimationDate")) Then
                    _ternimationDate = _datarow("TernimationDate")
                End If
                If Not IsDBNull(_datarow("DepartmentCode")) Then
                    _departmentCode = _datarow("DepartmentCode")
                End If
                If Not IsDBNull(_datarow("SectionCode")) Then
                    _sectionCode = _datarow("SectionCode")
                End If
                If Not IsDBNull(_datarow("TeamCode")) Then
                    _teamCode = _datarow("TeamCode")
                End If
                If Not IsDBNull(_datarow("Position_ID")) Then
                    _position_ID = _datarow("Position_ID")
                End If
                If Not IsDBNull(_datarow("PositionCategory_ID")) Then
                    _positionCategory_ID = _datarow("PositionCategory_ID")
                End If
                If Not IsDBNull(_datarow("Factory")) Then
                    _factory = _datarow("Factory")
                End If
                If Not IsDBNull(_datarow("Tel")) Then
                    _tel = _datarow("Tel")
                End If
                If Not IsDBNull(_datarow("SalaryBasic")) Then
                    _salaryBasic = _datarow("SalaryBasic")
                End If
                If Not IsDBNull(_datarow("SalaryInsure")) Then
                    _salaryInsure = _datarow("SalaryInsure")
                End If
                If Not IsDBNull(_datarow("SalaryProbation")) Then
                    _salaryProbation = _datarow("SalaryProbation")
                End If
                If Not IsDBNull(_datarow("Allowance_Responsibility")) Then
                    _allowance_Responsibility = _datarow("Allowance_Responsibility")
                End If
                If Not IsDBNull(_datarow("Allowance_Experience")) Then
                    _allowance_Experience = _datarow("Allowance_Experience")
                End If
                If Not IsDBNull(_datarow("Allowance_Business")) Then
                    _allowance_Business = _datarow("Allowance_Business")
                End If
                If Not IsDBNull(_datarow("Allowance_Other")) Then
                    _allowance_Other = _datarow("Allowance_Other")
                End If
                If Not IsDBNull(_datarow("NguoiGiamHo")) Then
                    _nguoiGiamHo = _datarow("NguoiGiamHo")
                End If
                If Not IsDBNull(_datarow("LabourContract_No")) Then
                    _labourContract_No = _datarow("LabourContract_No")
                End If
                If Not IsDBNull(_datarow("LabourContract_Date")) Then
                    _labourContract_Date = _datarow("LabourContract_Date")
                End If
                If Not IsDBNull(_datarow("LabourBook_No")) Then
                    _labourBook_No = _datarow("LabourBook_No")
                End If
                If Not IsDBNull(_datarow("LabourBook_Date")) Then
                    _labourBook_Date = _datarow("LabourBook_Date")
                End If
                If Not IsDBNull(_datarow("LabourBook_Place")) Then
                    _labourBook_Place = _datarow("LabourBook_Place")
                End If
                If Not IsDBNull(_datarow("Card_No")) Then
                    _card_No = _datarow("Card_No")
                End If
                If Not IsDBNull(_datarow("BankAccount")) Then
                    _bankAccount = _datarow("BankAccount")
                End If
                If Not IsDBNull(_datarow("BankName")) Then
                    _bankName = _datarow("BankName")
                End If
                If Not IsDBNull(_datarow("Discipline_Note")) Then
                    _discipline_Note = _datarow("Discipline_Note")
                End If
                If Not IsDBNull(_datarow("Promotion_Note")) Then
                    _promotion_Note = _datarow("Promotion_Note")
                End If
                If Not IsDBNull(_datarow("Training_note")) Then
                    _training_note = _datarow("Training_note")
                End If
                If Not IsDBNull(_datarow("Education")) Then
                    _education = _datarow("Education")
                End If
                If Not IsDBNull(_datarow("NativePlace")) Then
                    _nativePlace = _datarow("NativePlace")
                End If
                If Not IsDBNull(_datarow("NoiDangKyBaoHiem")) Then
                    _noiDangKyBaoHiem = _datarow("NoiDangKyBaoHiem")
                End If
                If Not IsDBNull(_datarow("maxl")) Then
                    _maxl = _datarow("maxl")
                End If
                If Not IsDBNull(_datarow("picture")) Then
                    _picture = _datarow("picture")
                End If
                If Not IsDBNull(_datarow("Related_Note")) Then
                    _related_Note = _datarow("Related_Note")
                End If
                If Not IsDBNull(_datarow("FullDocument")) Then
                    _fullDocument = _datarow("FullDocument")
                End If
                If Not IsDBNull(_datarow("Qualification")) Then
                    _qualification = _datarow("Qualification")
                End If
                If Not IsDBNull(_datarow("FStatus")) Then
                    _fStatus = _datarow("FStatus")
                End If
                If Not IsDBNull(_datarow("PermanentContact_Name")) Then
                    _permanentContact_Name = _datarow("PermanentContact_Name")
                End If
                If Not IsDBNull(_datarow("PermanentContact_Relation")) Then
                    _permanentContact_Relation = _datarow("PermanentContact_Relation")
                End If
                If Not IsDBNull(_datarow("TemporaryContact_Name")) Then
                    _temporaryContact_Name = _datarow("TemporaryContact_Name")
                End If
                If Not IsDBNull(_datarow("TemporaryContact_Relation")) Then
                    _temporaryContact_Relation = _datarow("TemporaryContact_Relation")
                End If
                If Not IsDBNull(_datarow("ExpiredDate")) Then
                    _expiredDate = _datarow("ExpiredDate")
                End If
                If Not IsDBNull(_datarow("ProbationDate")) Then
                    _probationDate = _datarow("ProbationDate")
                End If
                If Not IsDBNull(_datarow("F_Fromdate")) Then
                    _f_Fromdate = _datarow("F_Fromdate")
                End If
                If Not IsDBNull(_datarow("F_Todate")) Then
                    _f_Todate = _datarow("F_Todate")
                End If
                If Not IsDBNull(_datarow("GraduatedFrom")) Then
                    _graduatedFrom = _datarow("GraduatedFrom")
                End If
                If Not IsDBNull(_datarow("isExternal")) Then
                    _isExternal = _datarow("isExternal")
                End If
                If Not IsDBNull(_datarow("isSIHI")) Then
                    _isSIHI = _datarow("isSIHI")
                End If
                If Not IsDBNull(_datarow("isManager")) Then
                    _isManager = _datarow("isManager")
                End If
                If Not IsDBNull(_datarow("isEarlyTime")) Then
                    _isEarlyTime = _datarow("isEarlyTime")
                End If
                If Not IsDBNull(_datarow("defaultShift")) Then
                    _defaultShift = _datarow("defaultShift")
                End If
                If Not IsDBNull(_datarow("Allowance_Productivity")) Then
                    _allowance_Productivity = _datarow("Allowance_Productivity")
                End If
                If Not IsDBNull(_datarow("Allowance_Style")) Then
                    _allowance_Style = _datarow("Allowance_Style")
                End If
                If Not IsDBNull(_datarow("Allowance_House")) Then
                    _allowance_House = _datarow("Allowance_House")
                End If
                If Not IsDBNull(_datarow("Allowance_Position")) Then
                    _allowance_Position = _datarow("Allowance_Position")
                End If
                If Not IsDBNull(_datarow("Allowance_Attendance")) Then
                    _allowance_Attendance = _datarow("Allowance_Attendance")
                End If
                If Not IsDBNull(_datarow("Allowance_Toxic")) Then
                    _allowance_Toxic = _datarow("Allowance_Toxic")
                End If
                If Not IsDBNull(_datarow("Allowance_Petrol")) Then
                    _allowance_Petrol = _datarow("Allowance_Petrol")
                End If
                If Not IsDBNull(_datarow("ResonTerminated")) Then
                    _resonTerminated = _datarow("ResonTerminated")
                End If
                If Not IsDBNull(_datarow("Email")) Then
                    _email = _datarow("Email")
                End If
                If Not IsDBNull(_datarow("NgayQDNghiViec")) Then
                    _ngayQDNghiViec = _datarow("NgayQDNghiViec")
                End If
                If Not IsDBNull(_datarow("MaQuyetDinh")) Then
                    _maQuyetDinh = _datarow("MaQuyetDinh")
                End If
                If Not IsDBNull(_datarow("NgayBanGiao")) Then
                    _ngayBanGiao = _datarow("NgayBanGiao")
                End If
                If Not IsDBNull(_datarow("MaSoThue")) Then
                    _maSoThue = _datarow("MaSoThue")
                End If
                If Not IsDBNull(_datarow("CongViecPhaiLam")) Then
                    _congViecPhaiLam = _datarow("CongViecPhaiLam")
                End If
                If Not IsDBNull(_datarow("SoNgayPhepCuaThang")) Then
                    _soNgayPhepCuaThang = _datarow("SoNgayPhepCuaThang")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@Employee_ID"}
            Dim oj() As Object = {Employee_ID}
            Dim tp() As String = {"NVarChar"}
            kn.ExecStore("dbo.usp_DeleteSmartBooks_Employee", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@Employee_ID", "@Employee_Firstname", "@Employee_LastName", "@BirthDate", "@BirthPlace", "@BirthPlace_EN", "@Sex", "@MaritalStatus", "@Nationality", "@Nationality_EN", "@ID_number", "@ID_date", "@ID_place", "@ID_place_EN", "@Address_Temporary", "@Address_Temporary_EN", "@Address_Permanent", "@Address_Permanent_EN", "@Employee_Status", "@StartedDate", "@TernimationDate", "@DepartmentCode", "@SectionCode", "@TeamCode", "@Position_ID", "@PositionCategory_ID", "@Factory", "@Tel", "@SalaryBasic", "@SalaryInsure", "@SalaryProbation", "@Allowance_Responsibility", "@Allowance_Experience", "@Allowance_Business", "@Allowance_Other", "@NguoiGiamHo", "@LabourContract_No", "@LabourContract_Date", "@LabourBook_No", "@LabourBook_Date", "@LabourBook_Place", "@Card_No", "@BankAccount", "@BankName", "@Discipline_Note", "@Promotion_Note", "@Training_note", "@Education", "@NativePlace", "@NoiDangKyBaoHiem", "@maxl", "@picture", "@Related_Note", "@FullDocument", "@Qualification", "@FStatus", "@PermanentContact_Name", "@PermanentContact_Relation", "@TemporaryContact_Name", "@TemporaryContact_Relation", "@ExpiredDate", "@ProbationDate", "@F_Fromdate", "@F_Todate", "@GraduatedFrom", "@isExternal", "@isSIHI", "@isManager", "@isEarlyTime", "@defaultShift", "@Allowance_Productivity", "@Allowance_Style", "@Allowance_House", "@Allowance_Position", "@Allowance_Attendance", "@Allowance_Toxic", "@Allowance_Petrol", "@ResonTerminated", "@Email", "@NgayQDNghiViec", "@MaQuyetDinh", "@NgayBanGiao", "@MaSoThue", "@CongViecPhaiLam", "@SoNgayPhepCuaThang"}
            Dim oj() As Object = {Employee_ID, Employee_Firstname, Employee_LastName, BirthDate, BirthPlace, BirthPlace_EN, Sex, MaritalStatus, Nationality, Nationality_EN, ID_number, ID_date, ID_place, ID_place_EN, Address_Temporary, Address_Temporary_EN, Address_Permanent, Address_Permanent_EN, Employee_Status, StartedDate, TernimationDate, DepartmentCode, SectionCode, TeamCode, Position_ID, PositionCategory_ID, Factory, Tel, SalaryBasic, SalaryInsure, SalaryProbation, Allowance_Responsibility, Allowance_Experience, Allowance_Business, Allowance_Other, NguoiGiamHo, LabourContract_No, LabourContract_Date, LabourBook_No, LabourBook_Date, LabourBook_Place, Card_No, BankAccount, BankName, Discipline_Note, Promotion_Note, Training_note, Education, NativePlace, NoiDangKyBaoHiem, maxl, picture, Related_Note, FullDocument, Qualification, FStatus, PermanentContact_Name, PermanentContact_Relation, TemporaryContact_Name, TemporaryContact_Relation, ExpiredDate, ProbationDate, F_Fromdate, F_Todate, GraduatedFrom, isExternal, isSIHI, isManager, isEarlyTime, defaultShift, Allowance_Productivity, Allowance_Style, Allowance_House, Allowance_Position, Allowance_Attendance, Allowance_Toxic, Allowance_Petrol, ResonTerminated, Email, NgayQDNghiViec, MaQuyetDinh, NgayBanGiao, MaSoThue, CongViecPhaiLam, SoNgayPhepCuaThang}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Float", "Float", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Float", "DateTime", "Float", "DateTime", "NVarChar", "Float", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Binary", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime", "NVarChar", "NText", "Float"}
            kn.ExecStore("dbo.usp_UpdateSmartBooks_Employee", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@Employee_ID", "@Employee_Firstname", "@Employee_LastName", "@BirthDate", "@BirthPlace", "@BirthPlace_EN", "@Sex", "@MaritalStatus", "@Nationality", "@Nationality_EN", "@ID_number", "@ID_date", "@ID_place", "@ID_place_EN", "@Address_Temporary", "@Address_Temporary_EN", "@Address_Permanent", "@Address_Permanent_EN", "@Employee_Status", "@StartedDate", "@TernimationDate", "@DepartmentCode", "@SectionCode", "@TeamCode", "@Position_ID", "@PositionCategory_ID", "@Factory", "@Tel", "@SalaryBasic", "@SalaryInsure", "@SalaryProbation", "@Allowance_Responsibility", "@Allowance_Experience", "@Allowance_Business", "@Allowance_Other", "@NguoiGiamHo", "@LabourContract_No", "@LabourContract_Date", "@LabourBook_No", "@LabourBook_Date", "@LabourBook_Place", "@Card_No", "@BankAccount", "@BankName", "@Discipline_Note", "@Promotion_Note", "@Training_note", "@Education", "@NativePlace", "@NoiDangKyBaoHiem", "@maxl", "@picture", "@Related_Note", "@FullDocument", "@Qualification", "@FStatus", "@PermanentContact_Name", "@PermanentContact_Relation", "@TemporaryContact_Name", "@TemporaryContact_Relation", "@ExpiredDate", "@ProbationDate", "@F_Fromdate", "@F_Todate", "@GraduatedFrom", "@isExternal", "@isSIHI", "@isManager", "@isEarlyTime", "@defaultShift", "@Allowance_Productivity", "@Allowance_Style", "@Allowance_House", "@Allowance_Position", "@Allowance_Attendance", "@Allowance_Toxic", "@Allowance_Petrol", "@ResonTerminated", "@Email", "@NgayQDNghiViec", "@MaQuyetDinh", "@NgayBanGiao", "@MaSoThue", "@CongViecPhaiLam", "@SoNgayPhepCuaThang"}
            Dim oj() As Object = {Employee_ID, Employee_Firstname, Employee_LastName, BirthDate, BirthPlace, BirthPlace_EN, Sex, MaritalStatus, Nationality, Nationality_EN, ID_number, ID_date, ID_place, ID_place_EN, Address_Temporary, Address_Temporary_EN, Address_Permanent, Address_Permanent_EN, Employee_Status, StartedDate, TernimationDate, DepartmentCode, SectionCode, TeamCode, Position_ID, PositionCategory_ID, Factory, Tel, SalaryBasic, SalaryInsure, SalaryProbation, Allowance_Responsibility, Allowance_Experience, Allowance_Business, Allowance_Other, NguoiGiamHo, LabourContract_No, LabourContract_Date, LabourBook_No, LabourBook_Date, LabourBook_Place, Card_No, BankAccount, BankName, Discipline_Note, Promotion_Note, Training_note, Education, NativePlace, NoiDangKyBaoHiem, maxl, picture, Related_Note, FullDocument, Qualification, FStatus, PermanentContact_Name, PermanentContact_Relation, TemporaryContact_Name, TemporaryContact_Relation, ExpiredDate, ProbationDate, F_Fromdate, F_Todate, GraduatedFrom, isExternal, isSIHI, isManager, isEarlyTime, defaultShift, Allowance_Productivity, Allowance_Style, Allowance_House, Allowance_Position, Allowance_Attendance, Allowance_Toxic, Allowance_Petrol, ResonTerminated, Email, NgayQDNghiViec, MaQuyetDinh, NgayBanGiao, MaSoThue, CongViecPhaiLam, SoNgayPhepCuaThang}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Float", "Float", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Float", "DateTime", "Float", "DateTime", "NVarChar", "Float", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Binary", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime", "NVarChar", "NText", "Float"}
            kn.ExecStore("dbo.usp_InsertSmartBooks_Employee", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@Employee_ID", "@Employee_Firstname", "@Employee_LastName", "@BirthDate", "@BirthPlace", "@BirthPlace_EN", "@Sex", "@MaritalStatus", "@Nationality", "@Nationality_EN", "@ID_number", "@ID_date", "@ID_place", "@ID_place_EN", "@Address_Temporary", "@Address_Temporary_EN", "@Address_Permanent", "@Address_Permanent_EN", "@Employee_Status", "@StartedDate", "@TernimationDate", "@DepartmentCode", "@SectionCode", "@TeamCode", "@Position_ID", "@PositionCategory_ID", "@Factory", "@Tel", "@SalaryBasic", "@SalaryInsure", "@SalaryProbation", "@Allowance_Responsibility", "@Allowance_Experience", "@Allowance_Business", "@Allowance_Other", "@NguoiGiamHo", "@LabourContract_No", "@LabourContract_Date", "@LabourBook_No", "@LabourBook_Date", "@LabourBook_Place", "@Card_No", "@BankAccount", "@BankName", "@Discipline_Note", "@Promotion_Note", "@Training_note", "@Education", "@NativePlace", "@NoiDangKyBaoHiem", "@maxl", "@picture", "@Related_Note", "@FullDocument", "@Qualification", "@FStatus", "@PermanentContact_Name", "@PermanentContact_Relation", "@TemporaryContact_Name", "@TemporaryContact_Relation", "@ExpiredDate", "@ProbationDate", "@F_Fromdate", "@F_Todate", "@GraduatedFrom", "@isExternal", "@isSIHI", "@isManager", "@isEarlyTime", "@defaultShift", "@Allowance_Productivity", "@Allowance_Style", "@Allowance_House", "@Allowance_Position", "@Allowance_Attendance", "@Allowance_Toxic", "@Allowance_Petrol", "@ResonTerminated", "@Email", "@NgayQDNghiViec", "@MaQuyetDinh", "@NgayBanGiao", "@MaSoThue", "@CongViecPhaiLam", "@SoNgayPhepCuaThang"}
            Dim oj() As Object = {Employee_ID, Employee_Firstname, Employee_LastName, BirthDate, BirthPlace, BirthPlace_EN, Sex, MaritalStatus, Nationality, Nationality_EN, ID_number, ID_date, ID_place, ID_place_EN, Address_Temporary, Address_Temporary_EN, Address_Permanent, Address_Permanent_EN, Employee_Status, StartedDate, TernimationDate, DepartmentCode, SectionCode, TeamCode, Position_ID, PositionCategory_ID, Factory, Tel, SalaryBasic, SalaryInsure, SalaryProbation, Allowance_Responsibility, Allowance_Experience, Allowance_Business, Allowance_Other, NguoiGiamHo, LabourContract_No, LabourContract_Date, LabourBook_No, LabourBook_Date, LabourBook_Place, Card_No, BankAccount, BankName, Discipline_Note, Promotion_Note, Training_note, Education, NativePlace, NoiDangKyBaoHiem, maxl, picture, Related_Note, FullDocument, Qualification, FStatus, PermanentContact_Name, PermanentContact_Relation, TemporaryContact_Name, TemporaryContact_Relation, ExpiredDate, ProbationDate, F_Fromdate, F_Todate, GraduatedFrom, isExternal, isSIHI, isManager, isEarlyTime, defaultShift, Allowance_Productivity, Allowance_Style, Allowance_House, Allowance_Position, Allowance_Attendance, Allowance_Toxic, Allowance_Petrol, ResonTerminated, Email, NgayQDNghiViec, MaQuyetDinh, NgayBanGiao, MaSoThue, CongViecPhaiLam, SoNgayPhepCuaThang}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Float", "Float", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Float", "DateTime", "Float", "DateTime", "NVarChar", "Float", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Binary", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime", "NVarChar", "NText", "Float"}
            kn.ExecStore("dbo.usp_InsertUpdateSmartBooks_Employee", name, oj, tp)
        End Sub

    'Public Function GetSQLInsert() As String
    '    Dim __Employee_ID As String
    '    Dim __Employee_Firstname As String
    '    Dim __Employee_LastName As String
    '    Dim __BirthDate As String
    '    Dim __BirthPlace As String
    '    Dim __BirthPlace_EN As String
    '    Dim __Sex As String
    '    Dim __MaritalStatus As String
    '    Dim __Nationality As String
    '    Dim __Nationality_EN As String
    '    Dim __ID_number As String
    '    Dim __ID_date As String
    '    Dim __ID_place As String
    '    Dim __ID_place_EN As String
    '    Dim __Address_Temporary As String
    '    Dim __Address_Temporary_EN As String
    '    Dim __Address_Permanent As String
    '    Dim __Address_Permanent_EN As String
    '    Dim __Employee_Status As String
    '    Dim __StartedDate As String
    '    Dim __TernimationDate As String
    '    Dim __DepartmentCode As String
    '    Dim __SectionCode As String
    '    Dim __TeamCode As String
    '    Dim __Position_ID As String
    '    Dim __PositionCategory_ID As String
    '    Dim __Factory As String
    '    Dim __Tel As String
    '    Dim __SalaryBasic As String
    '    Dim __SalaryInsure As String
    '    Dim __SalaryProbation As String
    '    Dim __Allowance_Responsibility As String
    '    Dim __Allowance_Experience As String
    '    Dim __Allowance_Business As String
    '    Dim __Allowance_Other As String
    '    Dim __NguoiGiamHo As String
    '    Dim __LabourContract_No As String
    '    Dim __LabourContract_Date As String
    '    Dim __LabourBook_No As String
    '    Dim __LabourBook_Date As String
    '    Dim __LabourBook_Place As String
    '    Dim __Card_No As String
    '    Dim __BankAccount As String
    '    Dim __BankName As String
    '    Dim __Discipline_Note As String
    '    Dim __Promotion_Note As String
    '    Dim __Training_note As String
    '    Dim __Education As String
    '    Dim __NativePlace As String
    '    Dim __NoiDangKyBaoHiem As String
    '    Dim __maxl As String
    '    Dim __picture As String
    '    Dim __Related_Note As String
    '    Dim __FullDocument As String
    '    Dim __Qualification As String
    '    Dim __FStatus As String
    '    Dim __PermanentContact_Name As String
    '    Dim __PermanentContact_Relation As String
    '    Dim __TemporaryContact_Name As String
    '    Dim __TemporaryContact_Relation As String
    '    Dim __ExpiredDate As String
    '    Dim __ProbationDate As String
    '    Dim __F_Fromdate As String
    '    Dim __F_Todate As String
    '    Dim __GraduatedFrom As String
    '    Dim __isExternal As String
    '    Dim __isSIHI As String
    '    Dim __isManager As String
    '    Dim __isEarlyTime As String
    '    Dim __defaultShift As String
    '    Dim __Allowance_Productivity As String
    '    Dim __Allowance_Style As String
    '    Dim __Allowance_House As String
    '    Dim __Allowance_Position As String
    '    Dim __Allowance_Attendance As String
    '    Dim __Allowance_Toxic As String
    '    Dim __Allowance_Petrol As String
    '    Dim __ResonTerminated As String
    '    Dim __Email As String
    '    Dim __NgayQDNghiViec As String
    '    Dim __MaQuyetDinh As String
    '    Dim __NgayBanGiao As String
    '    Dim __MaSoThue As String
    '    Dim __CongViecPhaiLam As String
    '    Dim __SoNgayPhepCuaThang As String
    '    If Employee_ID <> String.Empty Then
    '        __Employee_ID = "N'" + Employee_ID + "'"
    '    Else
    '        __Employee_ID = "null"
    '    End If
    '    If Employee_Firstname <> String.Empty Then
    '        __Employee_Firstname = "N'" + Employee_Firstname + "'"
    '    Else
    '        __Employee_Firstname = "null"
    '    End If
    '    If Employee_LastName <> String.Empty Then
    '        __Employee_LastName = "N'" + Employee_LastName + "'"
    '    Else
    '        __Employee_LastName = "null"
    '    End If
    '    If BirthDate <> DateTime.MinValue Then
    '        __BirthDate = "'" + kn.DateTimeToString(BirthDate) + "'"
    '    Else
    '        __BirthDate = "null"
    '    End If
    '    If BirthPlace <> String.Empty Then
    '        __BirthPlace = "N'" + BirthPlace + "'"
    '    Else
    '        __BirthPlace = "null"
    '    End If
    '    If BirthPlace_EN <> String.Empty Then
    '        __BirthPlace_EN = "N'" + BirthPlace_EN + "'"
    '    Else
    '        __BirthPlace_EN = "null"
    '    End If
    '    If Sex <> String.Empty Then
    '        __Sex = "N'" + Sex + "'"
    '    Else
    '        __Sex = "null"
    '    End If
    '    If MaritalStatus <> String.Empty Then
    '        __MaritalStatus = "N'" + MaritalStatus + "'"
    '    Else
    '        __MaritalStatus = "null"
    '    End If
    '    If Nationality <> String.Empty Then
    '        __Nationality = "N'" + Nationality + "'"
    '    Else
    '        __Nationality = "null"
    '    End If
    '    If Nationality_EN <> String.Empty Then
    '        __Nationality_EN = "N'" + Nationality_EN + "'"
    '    Else
    '        __Nationality_EN = "null"
    '    End If
    '    If ID_number <> String.Empty Then
    '        __ID_number = "N'" + ID_number + "'"
    '    Else
    '        __ID_number = "null"
    '    End If
    '    If ID_date <> DateTime.MinValue Then
    '        __ID_date = "'" + kn.DateTimeToString(ID_date) + "'"
    '    Else
    '        __ID_date = "null"
    '    End If
    '    If ID_place <> String.Empty Then
    '        __ID_place = "N'" + ID_place + "'"
    '    Else
    '        __ID_place = "null"
    '    End If
    '    If ID_place_EN <> String.Empty Then
    '        __ID_place_EN = "N'" + ID_place_EN + "'"
    '    Else
    '        __ID_place_EN = "null"
    '    End If
    '    If Address_Temporary <> String.Empty Then
    '        __Address_Temporary = "N'" + Address_Temporary + "'"
    '    Else
    '        __Address_Temporary = "null"
    '    End If
    '    If Address_Temporary_EN <> String.Empty Then
    '        __Address_Temporary_EN = "N'" + Address_Temporary_EN + "'"
    '    Else
    '        __Address_Temporary_EN = "null"
    '    End If
    '    If Address_Permanent <> String.Empty Then
    '        __Address_Permanent = "N'" + Address_Permanent + "'"
    '    Else
    '        __Address_Permanent = "null"
    '    End If
    '    If Address_Permanent_EN <> String.Empty Then
    '        __Address_Permanent_EN = "N'" + Address_Permanent_EN + "'"
    '    Else
    '        __Address_Permanent_EN = "null"
    '    End If
    '    If Employee_Status <> String.Empty Then
    '        __Employee_Status = "N'" + Employee_Status + "'"
    '    Else
    '        __Employee_Status = "null"
    '    End If
    '    If StartedDate <> DateTime.MinValue Then
    '        __StartedDate = "'" + kn.DateTimeToString(StartedDate) + "'"
    '    Else
    '        __StartedDate = "null"
    '    End If
    '    If TernimationDate <> DateTime.MinValue Then
    '        __TernimationDate = "'" + kn.DateTimeToString(TernimationDate) + "'"
    '    Else
    '        __TernimationDate = "null"
    '    End If
    '    If DepartmentCode <> String.Empty Then
    '        __DepartmentCode = "N'" + DepartmentCode + "'"
    '    Else
    '        __DepartmentCode = "null"
    '    End If
    '    If SectionCode <> String.Empty Then
    '        __SectionCode = "N'" + SectionCode + "'"
    '    Else
    '        __SectionCode = "null"
    '    End If
    '    If TeamCode <> String.Empty Then
    '        __TeamCode = "N'" + TeamCode + "'"
    '    Else
    '        __TeamCode = "null"
    '    End If
    '    If Position_ID <> String.Empty Then
    '        __Position_ID = "N'" + Position_ID + "'"
    '    Else
    '        __Position_ID = "null"
    '    End If
    '    If PositionCategory_ID <> String.Empty Then
    '        __PositionCategory_ID = "N'" + PositionCategory_ID + "'"
    '    Else
    '        __PositionCategory_ID = "null"
    '    End If
    '    If Factory <> String.Empty Then
    '        __Factory = "N'" + Factory + "'"
    '    Else
    '        __Factory = "null"
    '    End If
    '    If Tel <> String.Empty Then
    '        __Tel = "N'" + Tel + "'"
    '    Else
    '        __Tel = "null"
    '    End If
    '    __SalaryBasic = "'" + SalaryBasic.tostring + "'"
    '    __SalaryInsure = "'" + SalaryInsure.tostring + "'"
    '    If SalaryProbation <> String.Empty Then
    '        __SalaryProbation = "N'" + SalaryProbation + "'"
    '    Else
    '        __SalaryProbation = "null"
    '    End If
    '    If Allowance_Responsibility <> String.Empty Then
    '        __Allowance_Responsibility = "N'" + Allowance_Responsibility + "'"
    '    Else
    '        __Allowance_Responsibility = "null"
    '    End If
    '    If Allowance_Experience <> String.Empty Then
    '        __Allowance_Experience = "N'" + Allowance_Experience + "'"
    '    Else
    '        __Allowance_Experience = "null"
    '    End If
    '    If Allowance_Business <> String.Empty Then
    '        __Allowance_Business = "N'" + Allowance_Business + "'"
    '    Else
    '        __Allowance_Business = "null"
    '    End If
    '    If Allowance_Other <> String.Empty Then
    '        __Allowance_Other = "N'" + Allowance_Other + "'"
    '    Else
    '        __Allowance_Other = "null"
    '    End If
    '    If NguoiGiamHo <> String.Empty Then
    '        __NguoiGiamHo = "N'" + NguoiGiamHo + "'"
    '    Else
    '        __NguoiGiamHo = "null"
    '    End If
    '    __LabourContract_No = "'" + LabourContract_No.tostring + "'"
    '    If LabourContract_Date <> DateTime.MinValue Then
    '        __LabourContract_Date = "'" + kn.DateTimeToString(LabourContract_Date) + "'"
    '    Else
    '        __LabourContract_Date = "null"
    '    End If
    '    __LabourBook_No = "'" + LabourBook_No.tostring + "'"
    '    If LabourBook_Date <> DateTime.MinValue Then
    '        __LabourBook_Date = "'" + kn.DateTimeToString(LabourBook_Date) + "'"
    '    Else
    '        __LabourBook_Date = "null"
    '    End If
    '    If LabourBook_Place <> String.Empty Then
    '        __LabourBook_Place = "N'" + LabourBook_Place + "'"
    '    Else
    '        __LabourBook_Place = "null"
    '    End If
    '    __Card_No = "'" + Card_No.tostring + "'"
    '    If BankAccount <> String.Empty Then
    '        __BankAccount = "N'" + BankAccount + "'"
    '    Else
    '        __BankAccount = "null"
    '    End If
    '    If BankName <> String.Empty Then
    '        __BankName = "N'" + BankName + "'"
    '    Else
    '        __BankName = "null"
    '    End If
    '    If Discipline_Note <> String.Empty Then
    '        __Discipline_Note = "N'" + Discipline_Note + "'"
    '    Else
    '        __Discipline_Note = "null"
    '    End If
    '    If Promotion_Note <> String.Empty Then
    '        __Promotion_Note = "N'" + Promotion_Note + "'"
    '    Else
    '        __Promotion_Note = "null"
    '    End If
    '    If Training_note <> String.Empty Then
    '        __Training_note = "N'" + Training_note + "'"
    '    Else
    '        __Training_note = "null"
    '    End If
    '    If Education <> String.Empty Then
    '        __Education = "N'" + Education + "'"
    '    Else
    '        __Education = "null"
    '    End If
    '    If NativePlace <> String.Empty Then
    '        __NativePlace = "N'" + NativePlace + "'"
    '    Else
    '        __NativePlace = "null"
    '    End If
    '    If NoiDangKyBaoHiem <> String.Empty Then
    '        __NoiDangKyBaoHiem = "N'" + NoiDangKyBaoHiem + "'"
    '    Else
    '        __NoiDangKyBaoHiem = "null"
    '    End If
    '    If maxl <> String.Empty Then
    '        __maxl = "N'" + maxl + "'"
    '    Else
    '        __maxl = "null"
    '    End If
    '    __picture = "'" + picture + "'"
    '    If Related_Note <> String.Empty Then
    '        __Related_Note = "N'" + Related_Note + "'"
    '    Else
    '        __Related_Note = "null"
    '    End If
    '    If FullDocument <> String.Empty Then
    '        __FullDocument = "N'" + FullDocument + "'"
    '    Else
    '        __FullDocument = "null"
    '    End If
    '    If Qualification <> String.Empty Then
    '        __Qualification = "N'" + Qualification + "'"
    '    Else
    '        __Qualification = "null"
    '    End If
    '    If FStatus <> String.Empty Then
    '        __FStatus = "N'" + FStatus + "'"
    '    Else
    '        __FStatus = "null"
    '    End If
    '    If PermanentContact_Name <> String.Empty Then
    '        __PermanentContact_Name = "N'" + PermanentContact_Name + "'"
    '    Else
    '        __PermanentContact_Name = "null"
    '    End If
    '    If PermanentContact_Relation <> String.Empty Then
    '        __PermanentContact_Relation = "N'" + PermanentContact_Relation + "'"
    '    Else
    '        __PermanentContact_Relation = "null"
    '    End If
    '    If TemporaryContact_Name <> String.Empty Then
    '        __TemporaryContact_Name = "N'" + TemporaryContact_Name + "'"
    '    Else
    '        __TemporaryContact_Name = "null"
    '    End If
    '    If TemporaryContact_Relation <> String.Empty Then
    '        __TemporaryContact_Relation = "N'" + TemporaryContact_Relation + "'"
    '    Else
    '        __TemporaryContact_Relation = "null"
    '    End If
    '    If ExpiredDate <> String.Empty Then
    '        __ExpiredDate = "N'" + ExpiredDate + "'"
    '    Else
    '        __ExpiredDate = "null"
    '    End If
    '    If ProbationDate <> DateTime.MinValue Then
    '        __ProbationDate = "'" + kn.DateTimeToString(ProbationDate) + "'"
    '    Else
    '        __ProbationDate = "null"
    '    End If
    '    If F_Fromdate <> String.Empty Then
    '        __F_Fromdate = "N'" + F_Fromdate + "'"
    '    Else
    '        __F_Fromdate = "null"
    '    End If
    '    If F_Todate <> String.Empty Then
    '        __F_Todate = "N'" + F_Todate + "'"
    '    Else
    '        __F_Todate = "null"
    '    End If
    '    If GraduatedFrom <> String.Empty Then
    '        __GraduatedFrom = "N'" + GraduatedFrom + "'"
    '    Else
    '        __GraduatedFrom = "null"
    '    End If
    '    If isExternal <> String.Empty Then
    '        __isExternal = "N'" + isExternal + "'"
    '    Else
    '        __isExternal = "null"
    '    End If
    '    If isSIHI <> String.Empty Then
    '        __isSIHI = "N'" + isSIHI + "'"
    '    Else
    '        __isSIHI = "null"
    '    End If
    '    If isManager <> String.Empty Then
    '        __isManager = "N'" + isManager + "'"
    '    Else
    '        __isManager = "null"
    '    End If
    '    If isEarlyTime = True Then
    '        _isEarlyTime = "'1'"
    '    Else
    '        __isEarlyTime = "'0'"
    '    End If
    '    If defaultShift <> String.Empty Then
    '        __defaultShift = "N'" + defaultShift + "'"
    '    Else
    '        __defaultShift = "null"
    '    End If
    '    If Allowance_Productivity <> String.Empty Then
    '        __Allowance_Productivity = "N'" + Allowance_Productivity + "'"
    '    Else
    '        __Allowance_Productivity = "null"
    '    End If
    '    If Allowance_Style <> String.Empty Then
    '        __Allowance_Style = "N'" + Allowance_Style + "'"
    '    Else
    '        __Allowance_Style = "null"
    '    End If
    '    If Allowance_House <> String.Empty Then
    '        __Allowance_House = "N'" + Allowance_House + "'"
    '    Else
    '        __Allowance_House = "null"
    '    End If
    '    If Allowance_Position <> String.Empty Then
    '        __Allowance_Position = "N'" + Allowance_Position + "'"
    '    Else
    '        __Allowance_Position = "null"
    '    End If
    '    If Allowance_Attendance <> String.Empty Then
    '        __Allowance_Attendance = "N'" + Allowance_Attendance + "'"
    '    Else
    '        __Allowance_Attendance = "null"
    '    End If
    '    If Allowance_Toxic <> String.Empty Then
    '        __Allowance_Toxic = "N'" + Allowance_Toxic + "'"
    '    Else
    '        __Allowance_Toxic = "null"
    '    End If
    '    If Allowance_Petrol <> String.Empty Then
    '        __Allowance_Petrol = "N'" + Allowance_Petrol + "'"
    '    Else
    '        __Allowance_Petrol = "null"
    '    End If
    '    If ResonTerminated <> String.Empty Then
    '        __ResonTerminated = "N'" + ResonTerminated + "'"
    '    Else
    '        __ResonTerminated = "null"
    '    End If
    '    If Email <> String.Empty Then
    '        __Email = "N'" + Email + "'"
    '    Else
    '        __Email = "null"
    '    End If
    '    If NgayQDNghiViec <> DateTime.MinValue Then
    '        __NgayQDNghiViec = "'" + kn.DateTimeToString(NgayQDNghiViec) + "'"
    '    Else
    '        __NgayQDNghiViec = "null"
    '    End If
    '    If MaQuyetDinh <> String.Empty Then
    '        __MaQuyetDinh = "N'" + MaQuyetDinh + "'"
    '    Else
    '        __MaQuyetDinh = "null"
    '    End If
    '    If NgayBanGiao <> DateTime.MinValue Then
    '        __NgayBanGiao = "'" + kn.DateTimeToString(NgayBanGiao) + "'"
    '    Else
    '        __NgayBanGiao = "null"
    '    End If
    '    If MaSoThue <> String.Empty Then
    '        __MaSoThue = "N'" + MaSoThue + "'"
    '    Else
    '        __MaSoThue = "null"
    '    End If
    '    If CongViecPhaiLam <> String.Empty Then
    '        __CongViecPhaiLam = "N'" + CongViecPhaiLam + "'"
    '    Else
    '        __CongViecPhaiLam = "null"
    '    End If
    '    __SoNgayPhepCuaThang = "'" + SoNgayPhepCuaThang.tostring + "'"
    '    Dim sql As String = String.Empty
    '    sql = "INSERT INTO [SmartBooks_Employee]([Employee_ID],[Employee_Firstname],[Employee_LastName],[BirthDate],[BirthPlace],[BirthPlace_EN],[Sex],[MaritalStatus],[Nationality],[Nationality_EN],[ID_number],[ID_date],[ID_place],[ID_place_EN],[Address_Temporary],[Address_Temporary_EN],[Address_Permanent],[Address_Permanent_EN],[Employee_Status],[StartedDate],[TernimationDate],[DepartmentCode],[SectionCode],[TeamCode],[Position_ID],[PositionCategory_ID],[Factory],[Tel],[SalaryBasic],[SalaryInsure],[SalaryProbation],[Allowance_Responsibility],[Allowance_Experience],[Allowance_Business],[Allowance_Other],[NguoiGiamHo],[LabourContract_No],[LabourContract_Date],[LabourBook_No],[LabourBook_Date],[LabourBook_Place],[Card_No],[BankAccount],[BankName],[Discipline_Note],[Promotion_Note],[Training_note],[Education],[NativePlace],[NoiDangKyBaoHiem],[maxl],[picture],[Related_Note],[FullDocument],[Qualification],[FStatus],[PermanentContact_Name],[PermanentContact_Relation],[TemporaryContact_Name],[TemporaryContact_Relation],[ExpiredDate],[ProbationDate],[F_Fromdate],[F_Todate],[GraduatedFrom],[isExternal],[isSIHI],[isManager],[isEarlyTime],[defaultShift],[Allowance_Productivity],[Allowance_Style],[Allowance_House],[Allowance_Position],[Allowance_Attendance],[Allowance_Toxic],[Allowance_Petrol],[ResonTerminated],[Email],[NgayQDNghiViec],[MaQuyetDinh],[NgayBanGiao],[MaSoThue],[CongViecPhaiLam],[SoNgayPhepCuaThang])VALUES(" & _
    '    __Employee_ID + "," + __Employee_Firstname + "," + __Employee_LastName + "," + __BirthDate + "," + __BirthPlace + "," + __BirthPlace_EN + "," + __Sex + "," + __MaritalStatus + "," + __Nationality + "," + __Nationality_EN + "," + __ID_number + "," + __ID_date + "," + __ID_place + "," + __ID_place_EN + "," + __Address_Temporary + "," + __Address_Temporary_EN + "," + __Address_Permanent + "," + __Address_Permanent_EN + "," + __Employee_Status + "," + __StartedDate + "," + __TernimationDate + "," + __DepartmentCode + "," + __SectionCode + "," + __TeamCode + "," + __Position_ID + "," + __PositionCategory_ID + "," + __Factory + "," + __Tel + "," + __SalaryBasic + "," + __SalaryInsure + "," + __SalaryProbation + "," + __Allowance_Responsibility + "," + __Allowance_Experience + "," + __Allowance_Business + "," + __Allowance_Other + "," + __NguoiGiamHo + "," + __LabourContract_No + "," + __LabourContract_Date + "," + __LabourBook_No + "," + __LabourBook_Date + "," + __LabourBook_Place + "," + __Card_No + "," + __BankAccount + "," + __BankName + "," + __Discipline_Note + "," + __Promotion_Note + "," + __Training_note + "," + __Education + "," + __NativePlace + "," + __NoiDangKyBaoHiem + "," + __maxl + "," + __picture + "," + __Related_Note + "," + __FullDocument + "," + __Qualification + "," + __FStatus + "," + __PermanentContact_Name + "," + __PermanentContact_Relation + "," + __TemporaryContact_Name + "," + __TemporaryContact_Relation + "," + __ExpiredDate + "," + __ProbationDate + "," + __F_Fromdate + "," + __F_Todate + "," + __GraduatedFrom + "," + __isExternal + "," + __isSIHI + "," + __isManager + "," + __isEarlyTime + "," + __defaultShift + "," + __Allowance_Productivity + "," + __Allowance_Style + "," + __Allowance_House + "," + __Allowance_Position + "," + __Allowance_Attendance + "," + __Allowance_Toxic + "," + __Allowance_Petrol + "," + __ResonTerminated + "," + __Email + "," + __NgayQDNghiViec + "," + __MaQuyetDinh + "," + __NgayBanGiao + "," + __MaSoThue + "," + __CongViecPhaiLam + "," + __SoNgayPhepCuaThang + ")"
    '    Return sql
    'End Function

    'Public Function GetSQLUpdate() As String
    '    Dim __Employee_ID As String
    '    Dim __Employee_Firstname As String
    '    Dim __Employee_LastName As String
    '    Dim __BirthDate As String
    '    Dim __BirthPlace As String
    '    Dim __BirthPlace_EN As String
    '    Dim __Sex As String
    '    Dim __MaritalStatus As String
    '    Dim __Nationality As String
    '    Dim __Nationality_EN As String
    '    Dim __ID_number As String
    '    Dim __ID_date As String
    '    Dim __ID_place As String
    '    Dim __ID_place_EN As String
    '    Dim __Address_Temporary As String
    '    Dim __Address_Temporary_EN As String
    '    Dim __Address_Permanent As String
    '    Dim __Address_Permanent_EN As String
    '    Dim __Employee_Status As String
    '    Dim __StartedDate As String
    '    Dim __TernimationDate As String
    '    Dim __DepartmentCode As String
    '    Dim __SectionCode As String
    '    Dim __TeamCode As String
    '    Dim __Position_ID As String
    '    Dim __PositionCategory_ID As String
    '    Dim __Factory As String
    '    Dim __Tel As String
    '    Dim __SalaryBasic As String
    '    Dim __SalaryInsure As String
    '    Dim __SalaryProbation As String
    '    Dim __Allowance_Responsibility As String
    '    Dim __Allowance_Experience As String
    '    Dim __Allowance_Business As String
    '    Dim __Allowance_Other As String
    '    Dim __NguoiGiamHo As String
    '    Dim __LabourContract_No As String
    '    Dim __LabourContract_Date As String
    '    Dim __LabourBook_No As String
    '    Dim __LabourBook_Date As String
    '    Dim __LabourBook_Place As String
    '    Dim __Card_No As String
    '    Dim __BankAccount As String
    '    Dim __BankName As String
    '    Dim __Discipline_Note As String
    '    Dim __Promotion_Note As String
    '    Dim __Training_note As String
    '    Dim __Education As String
    '    Dim __NativePlace As String
    '    Dim __NoiDangKyBaoHiem As String
    '    Dim __maxl As String
    '    Dim __picture As String
    '    Dim __Related_Note As String
    '    Dim __FullDocument As String
    '    Dim __Qualification As String
    '    Dim __FStatus As String
    '    Dim __PermanentContact_Name As String
    '    Dim __PermanentContact_Relation As String
    '    Dim __TemporaryContact_Name As String
    '    Dim __TemporaryContact_Relation As String
    '    Dim __ExpiredDate As String
    '    Dim __ProbationDate As String
    '    Dim __F_Fromdate As String
    '    Dim __F_Todate As String
    '    Dim __GraduatedFrom As String
    '    Dim __isExternal As String
    '    Dim __isSIHI As String
    '    Dim __isManager As String
    '    Dim __isEarlyTime As String
    '    Dim __defaultShift As String
    '    Dim __Allowance_Productivity As String
    '    Dim __Allowance_Style As String
    '    Dim __Allowance_House As String
    '    Dim __Allowance_Position As String
    '    Dim __Allowance_Attendance As String
    '    Dim __Allowance_Toxic As String
    '    Dim __Allowance_Petrol As String
    '    Dim __ResonTerminated As String
    '    Dim __Email As String
    '    Dim __NgayQDNghiViec As String
    '    Dim __MaQuyetDinh As String
    '    Dim __NgayBanGiao As String
    '    Dim __MaSoThue As String
    '    Dim __CongViecPhaiLam As String
    '    Dim __SoNgayPhepCuaThang As String
    '    If Employee_ID <> String.Empty Then
    '        __Employee_ID = "N'" + Employee_ID + "'"
    '    Else
    '        __Employee_ID = "null"
    '    End If
    '    If Employee_Firstname <> String.Empty Then
    '        __Employee_Firstname = "N'" + Employee_Firstname + "'"
    '    Else
    '        __Employee_Firstname = "null"
    '    End If
    '    If Employee_LastName <> String.Empty Then
    '        __Employee_LastName = "N'" + Employee_LastName + "'"
    '    Else
    '        __Employee_LastName = "null"
    '    End If
    '    If BirthDate <> DateTime.MinValue Then
    '        __BirthDate = "'" + kn.DateTimeToString(BirthDate) + "'"
    '    Else
    '        __BirthDate = "null"
    '    End If
    '    If BirthPlace <> String.Empty Then
    '        __BirthPlace = "N'" + BirthPlace + "'"
    '    Else
    '        __BirthPlace = "null"
    '    End If
    '    If BirthPlace_EN <> String.Empty Then
    '        __BirthPlace_EN = "N'" + BirthPlace_EN + "'"
    '    Else
    '        __BirthPlace_EN = "null"
    '    End If
    '    If Sex <> String.Empty Then
    '        __Sex = "N'" + Sex + "'"
    '    Else
    '        __Sex = "null"
    '    End If
    '    If MaritalStatus <> String.Empty Then
    '        __MaritalStatus = "N'" + MaritalStatus + "'"
    '    Else
    '        __MaritalStatus = "null"
    '    End If
    '    If Nationality <> String.Empty Then
    '        __Nationality = "N'" + Nationality + "'"
    '    Else
    '        __Nationality = "null"
    '    End If
    '    If Nationality_EN <> String.Empty Then
    '        __Nationality_EN = "N'" + Nationality_EN + "'"
    '    Else
    '        __Nationality_EN = "null"
    '    End If
    '    If ID_number <> String.Empty Then
    '        __ID_number = "N'" + ID_number + "'"
    '    Else
    '        __ID_number = "null"
    '    End If
    '    If ID_date <> DateTime.MinValue Then
    '        __ID_date = "'" + kn.DateTimeToString(ID_date) + "'"
    '    Else
    '        __ID_date = "null"
    '    End If
    '    If ID_place <> String.Empty Then
    '        __ID_place = "N'" + ID_place + "'"
    '    Else
    '        __ID_place = "null"
    '    End If
    '    If ID_place_EN <> String.Empty Then
    '        __ID_place_EN = "N'" + ID_place_EN + "'"
    '    Else
    '        __ID_place_EN = "null"
    '    End If
    '    If Address_Temporary <> String.Empty Then
    '        __Address_Temporary = "N'" + Address_Temporary + "'"
    '    Else
    '        __Address_Temporary = "null"
    '    End If
    '    If Address_Temporary_EN <> String.Empty Then
    '        __Address_Temporary_EN = "N'" + Address_Temporary_EN + "'"
    '    Else
    '        __Address_Temporary_EN = "null"
    '    End If
    '    If Address_Permanent <> String.Empty Then
    '        __Address_Permanent = "N'" + Address_Permanent + "'"
    '    Else
    '        __Address_Permanent = "null"
    '    End If
    '    If Address_Permanent_EN <> String.Empty Then
    '        __Address_Permanent_EN = "N'" + Address_Permanent_EN + "'"
    '    Else
    '        __Address_Permanent_EN = "null"
    '    End If
    '    If Employee_Status <> String.Empty Then
    '        __Employee_Status = "N'" + Employee_Status + "'"
    '    Else
    '        __Employee_Status = "null"
    '    End If
    '    If StartedDate <> DateTime.MinValue Then
    '        __StartedDate = "'" + kn.DateTimeToString(StartedDate) + "'"
    '    Else
    '        __StartedDate = "null"
    '    End If
    '    If TernimationDate <> DateTime.MinValue Then
    '        __TernimationDate = "'" + kn.DateTimeToString(TernimationDate) + "'"
    '    Else
    '        __TernimationDate = "null"
    '    End If
    '    If DepartmentCode <> String.Empty Then
    '        __DepartmentCode = "N'" + DepartmentCode + "'"
    '    Else
    '        __DepartmentCode = "null"
    '    End If
    '    If SectionCode <> String.Empty Then
    '        __SectionCode = "N'" + SectionCode + "'"
    '    Else
    '        __SectionCode = "null"
    '    End If
    '    If TeamCode <> String.Empty Then
    '        __TeamCode = "N'" + TeamCode + "'"
    '    Else
    '        __TeamCode = "null"
    '    End If
    '    If Position_ID <> String.Empty Then
    '        __Position_ID = "N'" + Position_ID + "'"
    '    Else
    '        __Position_ID = "null"
    '    End If
    '    If PositionCategory_ID <> String.Empty Then
    '        __PositionCategory_ID = "N'" + PositionCategory_ID + "'"
    '    Else
    '        __PositionCategory_ID = "null"
    '    End If
    '    If Factory <> String.Empty Then
    '        __Factory = "N'" + Factory + "'"
    '    Else
    '        __Factory = "null"
    '    End If
    '    If Tel <> String.Empty Then
    '        __Tel = "N'" + Tel + "'"
    '    Else
    '        __Tel = "null"
    '    End If
    '    __SalaryBasic = "'" + SalaryBasic.tostring + "'"
    '    __SalaryInsure = "'" + SalaryInsure.tostring + "'"
    '    If SalaryProbation <> String.Empty Then
    '        __SalaryProbation = "N'" + SalaryProbation + "'"
    '    Else
    '        __SalaryProbation = "null"
    '    End If
    '    If Allowance_Responsibility <> String.Empty Then
    '        __Allowance_Responsibility = "N'" + Allowance_Responsibility + "'"
    '    Else
    '        __Allowance_Responsibility = "null"
    '    End If
    '    If Allowance_Experience <> String.Empty Then
    '        __Allowance_Experience = "N'" + Allowance_Experience + "'"
    '    Else
    '        __Allowance_Experience = "null"
    '    End If
    '    If Allowance_Business <> String.Empty Then
    '        __Allowance_Business = "N'" + Allowance_Business + "'"
    '    Else
    '        __Allowance_Business = "null"
    '    End If
    '    If Allowance_Other <> String.Empty Then
    '        __Allowance_Other = "N'" + Allowance_Other + "'"
    '    Else
    '        __Allowance_Other = "null"
    '    End If
    '    If NguoiGiamHo <> String.Empty Then
    '        __NguoiGiamHo = "N'" + NguoiGiamHo + "'"
    '    Else
    '        __NguoiGiamHo = "null"
    '    End If
    '    __LabourContract_No = "'" + LabourContract_No.tostring + "'"
    '    If LabourContract_Date <> DateTime.MinValue Then
    '        __LabourContract_Date = "'" + kn.DateTimeToString(LabourContract_Date) + "'"
    '    Else
    '        __LabourContract_Date = "null"
    '    End If
    '    __LabourBook_No = "'" + LabourBook_No.tostring + "'"
    '    If LabourBook_Date <> DateTime.MinValue Then
    '        __LabourBook_Date = "'" + kn.DateTimeToString(LabourBook_Date) + "'"
    '    Else
    '        __LabourBook_Date = "null"
    '    End If
    '    If LabourBook_Place <> String.Empty Then
    '        __LabourBook_Place = "N'" + LabourBook_Place + "'"
    '    Else
    '        __LabourBook_Place = "null"
    '    End If
    '    __Card_No = "'" + Card_No.tostring + "'"
    '    If BankAccount <> String.Empty Then
    '        __BankAccount = "N'" + BankAccount + "'"
    '    Else
    '        __BankAccount = "null"
    '    End If
    '    If BankName <> String.Empty Then
    '        __BankName = "N'" + BankName + "'"
    '    Else
    '        __BankName = "null"
    '    End If
    '    If Discipline_Note <> String.Empty Then
    '        __Discipline_Note = "N'" + Discipline_Note + "'"
    '    Else
    '        __Discipline_Note = "null"
    '    End If
    '    If Promotion_Note <> String.Empty Then
    '        __Promotion_Note = "N'" + Promotion_Note + "'"
    '    Else
    '        __Promotion_Note = "null"
    '    End If
    '    If Training_note <> String.Empty Then
    '        __Training_note = "N'" + Training_note + "'"
    '    Else
    '        __Training_note = "null"
    '    End If
    '    If Education <> String.Empty Then
    '        __Education = "N'" + Education + "'"
    '    Else
    '        __Education = "null"
    '    End If
    '    If NativePlace <> String.Empty Then
    '        __NativePlace = "N'" + NativePlace + "'"
    '    Else
    '        __NativePlace = "null"
    '    End If
    '    If NoiDangKyBaoHiem <> String.Empty Then
    '        __NoiDangKyBaoHiem = "N'" + NoiDangKyBaoHiem + "'"
    '    Else
    '        __NoiDangKyBaoHiem = "null"
    '    End If
    '    If maxl <> String.Empty Then
    '        __maxl = "N'" + maxl + "'"
    '    Else
    '        __maxl = "null"
    '    End If
    '    __picture = "'" + picture + "'"
    '    If Related_Note <> String.Empty Then
    '        __Related_Note = "N'" + Related_Note + "'"
    '    Else
    '        __Related_Note = "null"
    '    End If
    '    If FullDocument <> String.Empty Then
    '        __FullDocument = "N'" + FullDocument + "'"
    '    Else
    '        __FullDocument = "null"
    '    End If
    '    If Qualification <> String.Empty Then
    '        __Qualification = "N'" + Qualification + "'"
    '    Else
    '        __Qualification = "null"
    '    End If
    '    If FStatus <> String.Empty Then
    '        __FStatus = "N'" + FStatus + "'"
    '    Else
    '        __FStatus = "null"
    '    End If
    '    If PermanentContact_Name <> String.Empty Then
    '        __PermanentContact_Name = "N'" + PermanentContact_Name + "'"
    '    Else
    '        __PermanentContact_Name = "null"
    '    End If
    '    If PermanentContact_Relation <> String.Empty Then
    '        __PermanentContact_Relation = "N'" + PermanentContact_Relation + "'"
    '    Else
    '        __PermanentContact_Relation = "null"
    '    End If
    '    If TemporaryContact_Name <> String.Empty Then
    '        __TemporaryContact_Name = "N'" + TemporaryContact_Name + "'"
    '    Else
    '        __TemporaryContact_Name = "null"
    '    End If
    '    If TemporaryContact_Relation <> String.Empty Then
    '        __TemporaryContact_Relation = "N'" + TemporaryContact_Relation + "'"
    '    Else
    '        __TemporaryContact_Relation = "null"
    '    End If
    '    If ExpiredDate <> String.Empty Then
    '        __ExpiredDate = "N'" + ExpiredDate + "'"
    '    Else
    '        __ExpiredDate = "null"
    '    End If
    '    If ProbationDate <> DateTime.MinValue Then
    '        __ProbationDate = "'" + kn.DateTimeToString(ProbationDate) + "'"
    '    Else
    '        __ProbationDate = "null"
    '    End If
    '    If F_Fromdate <> String.Empty Then
    '        __F_Fromdate = "N'" + F_Fromdate + "'"
    '    Else
    '        __F_Fromdate = "null"
    '    End If
    '    If F_Todate <> String.Empty Then
    '        __F_Todate = "N'" + F_Todate + "'"
    '    Else
    '        __F_Todate = "null"
    '    End If
    '    If GraduatedFrom <> String.Empty Then
    '        __GraduatedFrom = "N'" + GraduatedFrom + "'"
    '    Else
    '        __GraduatedFrom = "null"
    '    End If
    '    If isExternal <> String.Empty Then
    '        __isExternal = "N'" + isExternal + "'"
    '    Else
    '        __isExternal = "null"
    '    End If
    '    If isSIHI <> String.Empty Then
    '        __isSIHI = "N'" + isSIHI + "'"
    '    Else
    '        __isSIHI = "null"
    '    End If
    '    If isManager <> String.Empty Then
    '        __isManager = "N'" + isManager + "'"
    '    Else
    '        __isManager = "null"
    '    End If
    '    If isEarlyTime = True Then
    '        _isEarlyTime = "'1'"
    '    Else
    '        __isEarlyTime = "'0'"
    '    End If
    '    If defaultShift <> String.Empty Then
    '        __defaultShift = "N'" + defaultShift + "'"
    '    Else
    '        __defaultShift = "null"
    '    End If
    '    If Allowance_Productivity <> String.Empty Then
    '        __Allowance_Productivity = "N'" + Allowance_Productivity + "'"
    '    Else
    '        __Allowance_Productivity = "null"
    '    End If
    '    If Allowance_Style <> String.Empty Then
    '        __Allowance_Style = "N'" + Allowance_Style + "'"
    '    Else
    '        __Allowance_Style = "null"
    '    End If
    '    If Allowance_House <> String.Empty Then
    '        __Allowance_House = "N'" + Allowance_House + "'"
    '    Else
    '        __Allowance_House = "null"
    '    End If
    '    If Allowance_Position <> String.Empty Then
    '        __Allowance_Position = "N'" + Allowance_Position + "'"
    '    Else
    '        __Allowance_Position = "null"
    '    End If
    '    If Allowance_Attendance <> String.Empty Then
    '        __Allowance_Attendance = "N'" + Allowance_Attendance + "'"
    '    Else
    '        __Allowance_Attendance = "null"
    '    End If
    '    If Allowance_Toxic <> String.Empty Then
    '        __Allowance_Toxic = "N'" + Allowance_Toxic + "'"
    '    Else
    '        __Allowance_Toxic = "null"
    '    End If
    '    If Allowance_Petrol <> String.Empty Then
    '        __Allowance_Petrol = "N'" + Allowance_Petrol + "'"
    '    Else
    '        __Allowance_Petrol = "null"
    '    End If
    '    If ResonTerminated <> String.Empty Then
    '        __ResonTerminated = "N'" + ResonTerminated + "'"
    '    Else
    '        __ResonTerminated = "null"
    '    End If
    '    If Email <> String.Empty Then
    '        __Email = "N'" + Email + "'"
    '    Else
    '        __Email = "null"
    '    End If
    '    If NgayQDNghiViec <> DateTime.MinValue Then
    '        __NgayQDNghiViec = "'" + kn.DateTimeToString(NgayQDNghiViec) + "'"
    '    Else
    '        __NgayQDNghiViec = "null"
    '    End If
    '    If MaQuyetDinh <> String.Empty Then
    '        __MaQuyetDinh = "N'" + MaQuyetDinh + "'"
    '    Else
    '        __MaQuyetDinh = "null"
    '    End If
    '    If NgayBanGiao <> DateTime.MinValue Then
    '        __NgayBanGiao = "'" + kn.DateTimeToString(NgayBanGiao) + "'"
    '    Else
    '        __NgayBanGiao = "null"
    '    End If
    '    If MaSoThue <> String.Empty Then
    '        __MaSoThue = "N'" + MaSoThue + "'"
    '    Else
    '        __MaSoThue = "null"
    '    End If
    '    If CongViecPhaiLam <> String.Empty Then
    '        __CongViecPhaiLam = "N'" + CongViecPhaiLam + "'"
    '    Else
    '        __CongViecPhaiLam = "null"
    '    End If
    '    __SoNgayPhepCuaThang = "'" + SoNgayPhepCuaThang.tostring + "'"
    '    Dim sql As String = String.Empty
    '    sql = "UPDATE [SmartBooks_Employee] SET [Employee_ID]=" + __Employee_ID + ",[Employee_Firstname]=" + __Employee_Firstname + ",[Employee_LastName]=" + __Employee_LastName + ",[BirthDate]=" + __BirthDate + ",[BirthPlace]=" + __BirthPlace + ",[BirthPlace_EN]=" + __BirthPlace_EN + ",[Sex]=" + __Sex + ",[MaritalStatus]=" + __MaritalStatus + ",[Nationality]=" + __Nationality + ",[Nationality_EN]=" + __Nationality_EN + ",[ID_number]=" + __ID_number + ",[ID_date]=" + __ID_date + ",[ID_place]=" + __ID_place + ",[ID_place_EN]=" + __ID_place_EN + ",[Address_Temporary]=" + __Address_Temporary + ",[Address_Temporary_EN]=" + __Address_Temporary_EN + ",[Address_Permanent]=" + __Address_Permanent + ",[Address_Permanent_EN]=" + __Address_Permanent_EN + ",[Employee_Status]=" + __Employee_Status + ",[StartedDate]=" + __StartedDate + ",[TernimationDate]=" + __TernimationDate + ",[DepartmentCode]=" + __DepartmentCode + ",[SectionCode]=" + __SectionCode + ",[TeamCode]=" + __TeamCode + ",[Position_ID]=" + __Position_ID + ",[PositionCategory_ID]=" + __PositionCategory_ID + ",[Factory]=" + __Factory + ",[Tel]=" + __Tel + ",[SalaryBasic]=" + __SalaryBasic + ",[SalaryInsure]=" + __SalaryInsure + ",[SalaryProbation]=" + __SalaryProbation + ",[Allowance_Responsibility]=" + __Allowance_Responsibility + ",[Allowance_Experience]=" + __Allowance_Experience + ",[Allowance_Business]=" + __Allowance_Business + ",[Allowance_Other]=" + __Allowance_Other + ",[NguoiGiamHo]=" + __NguoiGiamHo + ",[LabourContract_No]=" + __LabourContract_No + ",[LabourContract_Date]=" + __LabourContract_Date + ",[LabourBook_No]=" + __LabourBook_No + ",[LabourBook_Date]=" + __LabourBook_Date + ",[LabourBook_Place]=" + __LabourBook_Place + ",[Card_No]=" + __Card_No + ",[BankAccount]=" + __BankAccount + ",[BankName]=" + __BankName + ",[Discipline_Note]=" + __Discipline_Note + ",[Promotion_Note]=" + __Promotion_Note + ",[Training_note]=" + __Training_note + ",[Education]=" + __Education + ",[NativePlace]=" + __NativePlace + ",[NoiDangKyBaoHiem]=" + __NoiDangKyBaoHiem + ",[maxl]=" + __maxl + ",[picture]=" + __picture + ",[Related_Note]=" + __Related_Note + ",[FullDocument]=" + __FullDocument + ",[Qualification]=" + __Qualification + ",[FStatus]=" + __FStatus + ",[PermanentContact_Name]=" + __PermanentContact_Name + ",[PermanentContact_Relation]=" + __PermanentContact_Relation + ",[TemporaryContact_Name]=" + __TemporaryContact_Name + ",[TemporaryContact_Relation]=" + __TemporaryContact_Relation + ",[ExpiredDate]=" + __ExpiredDate + ",[ProbationDate]=" + __ProbationDate + ",[F_Fromdate]=" + __F_Fromdate + ",[F_Todate]=" + __F_Todate + ",[GraduatedFrom]=" + __GraduatedFrom + ",[isExternal]=" + __isExternal + ",[isSIHI]=" + __isSIHI + ",[isManager]=" + __isManager + ",[isEarlyTime]=" + __isEarlyTime + ",[defaultShift]=" + __defaultShift + ",[Allowance_Productivity]=" + __Allowance_Productivity + ",[Allowance_Style]=" + __Allowance_Style + ",[Allowance_House]=" + __Allowance_House + ",[Allowance_Position]=" + __Allowance_Position + ",[Allowance_Attendance]=" + __Allowance_Attendance + ",[Allowance_Toxic]=" + __Allowance_Toxic + ",[Allowance_Petrol]=" + __Allowance_Petrol + ",[ResonTerminated]=" + __ResonTerminated + ",[Email]=" + __Email + ",[NgayQDNghiViec]=" + __NgayQDNghiViec + ",[MaQuyetDinh]=" + __MaQuyetDinh + ",[NgayBanGiao]=" + __NgayBanGiao + ",[MaSoThue]=" + __MaSoThue + ",[CongViecPhaiLam]=" + __CongViecPhaiLam + ",[SoNgayPhepCuaThang]=" + __SoNgayPhepCuaThang + " WHERE [Employee_ID]=" + __Employee_ID
    '    Return sql
    'End Function

        Public Function GetSQLDelete() As String
            Dim __Employee_ID As String
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            Dim sql As String = String.Empty
            sql = "DELETE FROM [SmartBooks_Employee] WHERE [Employee_ID]=" + __Employee_ID
            Return sql
        End Function

        Public Shared Function NewSmartBooks_Employee(ByVal Employee_ID As System.String) As SmartBooks_Employee
            Dim newEntity As New SmartBooks_Employee
            newEntity._employee_ID = Employee_ID
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property Employee_ID() As System.String
            Get
                Return _employee_ID
            End Get
            Set(ByVal value As System.String)
                _employee_ID = value
            End Set
        End Property

        Public Property Employee_Firstname() As System.String
            Get
                Return _employee_Firstname
            End Get
            Set(ByVal value As System.String)
                _employee_Firstname = value
            End Set
        End Property

        Public Property Employee_LastName() As System.String
            Get
                Return _employee_LastName
            End Get
            Set(ByVal value As System.String)
                _employee_LastName = value
            End Set
        End Property

        Public Property BirthDate() As System.DateTime
            Get
                Return _birthDate
            End Get
            Set(ByVal value As System.DateTime)
                _birthDate = value
            End Set
        End Property

        Public Property BirthPlace() As System.String
            Get
                Return _birthPlace
            End Get
            Set(ByVal value As System.String)
                _birthPlace = value
            End Set
        End Property

        Public Property BirthPlace_EN() As System.String
            Get
                Return _birthPlace_EN
            End Get
            Set(ByVal value As System.String)
                _birthPlace_EN = value
            End Set
        End Property

        Public Property Sex() As System.String
            Get
                Return _sex
            End Get
            Set(ByVal value As System.String)
                _sex = value
            End Set
        End Property

        Public Property MaritalStatus() As System.String
            Get
                Return _maritalStatus
            End Get
            Set(ByVal value As System.String)
                _maritalStatus = value
            End Set
        End Property

        Public Property Nationality() As System.String
            Get
                Return _nationality
            End Get
            Set(ByVal value As System.String)
                _nationality = value
            End Set
        End Property

        Public Property Nationality_EN() As System.String
            Get
                Return _nationality_EN
            End Get
            Set(ByVal value As System.String)
                _nationality_EN = value
            End Set
        End Property

        Public Property ID_number() As System.String
            Get
                Return _iD_number
            End Get
            Set(ByVal value As System.String)
                _iD_number = value
            End Set
        End Property

        Public Property ID_date() As System.DateTime
            Get
                Return _iD_date
            End Get
            Set(ByVal value As System.DateTime)
                _iD_date = value
            End Set
        End Property

        Public Property ID_place() As System.String
            Get
                Return _iD_place
            End Get
            Set(ByVal value As System.String)
                _iD_place = value
            End Set
        End Property

        Public Property ID_place_EN() As System.String
            Get
                Return _iD_place_EN
            End Get
            Set(ByVal value As System.String)
                _iD_place_EN = value
            End Set
        End Property

        Public Property Address_Temporary() As System.String
            Get
                Return _address_Temporary
            End Get
            Set(ByVal value As System.String)
                _address_Temporary = value
            End Set
        End Property

        Public Property Address_Temporary_EN() As System.String
            Get
                Return _address_Temporary_EN
            End Get
            Set(ByVal value As System.String)
                _address_Temporary_EN = value
            End Set
        End Property

        Public Property Address_Permanent() As System.String
            Get
                Return _address_Permanent
            End Get
            Set(ByVal value As System.String)
                _address_Permanent = value
            End Set
        End Property

        Public Property Address_Permanent_EN() As System.String
            Get
                Return _address_Permanent_EN
            End Get
            Set(ByVal value As System.String)
                _address_Permanent_EN = value
            End Set
        End Property

        Public Property Employee_Status() As System.String
            Get
                Return _employee_Status
            End Get
            Set(ByVal value As System.String)
                _employee_Status = value
            End Set
        End Property

        Public Property StartedDate() As System.DateTime
            Get
                Return _startedDate
            End Get
            Set(ByVal value As System.DateTime)
                _startedDate = value
            End Set
        End Property

        Public Property TernimationDate() As System.DateTime
            Get
                Return _ternimationDate
            End Get
            Set(ByVal value As System.DateTime)
                _ternimationDate = value
            End Set
        End Property

        Public Property DepartmentCode() As System.String
            Get
                Return _departmentCode
            End Get
            Set(ByVal value As System.String)
                _departmentCode = value
            End Set
        End Property

        Public Property SectionCode() As System.String
            Get
                Return _sectionCode
            End Get
            Set(ByVal value As System.String)
                _sectionCode = value
            End Set
        End Property

        Public Property TeamCode() As System.String
            Get
                Return _teamCode
            End Get
            Set(ByVal value As System.String)
                _teamCode = value
            End Set
        End Property

        Public Property Position_ID() As System.String
            Get
                Return _position_ID
            End Get
            Set(ByVal value As System.String)
                _position_ID = value
            End Set
        End Property

        Public Property PositionCategory_ID() As System.String
            Get
                Return _positionCategory_ID
            End Get
            Set(ByVal value As System.String)
                _positionCategory_ID = value
            End Set
        End Property

        Public Property Factory() As System.String
            Get
                Return _factory
            End Get
            Set(ByVal value As System.String)
                _factory = value
            End Set
        End Property

        Public Property Tel() As System.String
            Get
                Return _tel
            End Get
            Set(ByVal value As System.String)
                _tel = value
            End Set
        End Property

        Public Property SalaryBasic() As System.Double
            Get
                Return _salaryBasic
            End Get
            Set(ByVal value As System.Double)
                _salaryBasic = value
            End Set
        End Property

        Public Property SalaryInsure() As System.Double
            Get
                Return _salaryInsure
            End Get
            Set(ByVal value As System.Double)
                _salaryInsure = value
            End Set
        End Property

        Public Property SalaryProbation() As System.String
            Get
                Return _salaryProbation
            End Get
            Set(ByVal value As System.String)
                _salaryProbation = value
            End Set
        End Property

        Public Property Allowance_Responsibility() As System.String
            Get
                Return _allowance_Responsibility
            End Get
            Set(ByVal value As System.String)
                _allowance_Responsibility = value
            End Set
        End Property

        Public Property Allowance_Experience() As System.String
            Get
                Return _allowance_Experience
            End Get
            Set(ByVal value As System.String)
                _allowance_Experience = value
            End Set
        End Property

        Public Property Allowance_Business() As System.String
            Get
                Return _allowance_Business
            End Get
            Set(ByVal value As System.String)
                _allowance_Business = value
            End Set
        End Property

        Public Property Allowance_Other() As System.String
            Get
                Return _allowance_Other
            End Get
            Set(ByVal value As System.String)
                _allowance_Other = value
            End Set
        End Property

        Public Property NguoiGiamHo() As System.String
            Get
                Return _nguoiGiamHo
            End Get
            Set(ByVal value As System.String)
                _nguoiGiamHo = value
            End Set
        End Property

        Public Property LabourContract_No() As System.Double
            Get
                Return _labourContract_No
            End Get
            Set(ByVal value As System.Double)
                _labourContract_No = value
            End Set
        End Property

        Public Property LabourContract_Date() As System.DateTime
            Get
                Return _labourContract_Date
            End Get
            Set(ByVal value As System.DateTime)
                _labourContract_Date = value
            End Set
        End Property

        Public Property LabourBook_No() As System.Double
            Get
                Return _labourBook_No
            End Get
            Set(ByVal value As System.Double)
                _labourBook_No = value
            End Set
        End Property

        Public Property LabourBook_Date() As System.DateTime
            Get
                Return _labourBook_Date
            End Get
            Set(ByVal value As System.DateTime)
                _labourBook_Date = value
            End Set
        End Property

        Public Property LabourBook_Place() As System.String
            Get
                Return _labourBook_Place
            End Get
            Set(ByVal value As System.String)
                _labourBook_Place = value
            End Set
        End Property

        Public Property Card_No() As System.Double
            Get
                Return _card_No
            End Get
            Set(ByVal value As System.Double)
                _card_No = value
            End Set
        End Property

        Public Property BankAccount() As System.String
            Get
                Return _bankAccount
            End Get
            Set(ByVal value As System.String)
                _bankAccount = value
            End Set
        End Property

        Public Property BankName() As System.String
            Get
                Return _bankName
            End Get
            Set(ByVal value As System.String)
                _bankName = value
            End Set
        End Property

        Public Property Discipline_Note() As System.String
            Get
                Return _discipline_Note
            End Get
            Set(ByVal value As System.String)
                _discipline_Note = value
            End Set
        End Property

        Public Property Promotion_Note() As System.String
            Get
                Return _promotion_Note
            End Get
            Set(ByVal value As System.String)
                _promotion_Note = value
            End Set
        End Property

        Public Property Training_note() As System.String
            Get
                Return _training_note
            End Get
            Set(ByVal value As System.String)
                _training_note = value
            End Set
        End Property

        Public Property Education() As System.String
            Get
                Return _education
            End Get
            Set(ByVal value As System.String)
                _education = value
            End Set
        End Property

        Public Property NativePlace() As System.String
            Get
                Return _nativePlace
            End Get
            Set(ByVal value As System.String)
                _nativePlace = value
            End Set
        End Property

        Public Property NoiDangKyBaoHiem() As System.String
            Get
                Return _noiDangKyBaoHiem
            End Get
            Set(ByVal value As System.String)
                _noiDangKyBaoHiem = value
            End Set
        End Property

        Public Property maxl() As System.String
            Get
                Return _maxl
            End Get
            Set(ByVal value As System.String)
                _maxl = value
            End Set
        End Property

    Public Property picture() As System.Byte()
        Get
            Return _picture
        End Get
        Set(ByVal value As System.Byte())
            _picture = value
        End Set
    End Property

    Public Property Related_Note() As System.String
        Get
            Return _related_Note
        End Get
        Set(ByVal value As System.String)
            _related_Note = value
        End Set
    End Property

    Public Property FullDocument() As System.String
        Get
            Return _fullDocument
        End Get
        Set(ByVal value As System.String)
            _fullDocument = value
        End Set
    End Property

    Public Property Qualification() As System.String
        Get
            Return _qualification
        End Get
        Set(ByVal value As System.String)
            _qualification = value
        End Set
    End Property

    Public Property FStatus() As System.String
        Get
            Return _fStatus
        End Get
        Set(ByVal value As System.String)
            _fStatus = value
        End Set
    End Property

    Public Property PermanentContact_Name() As System.String
        Get
            Return _permanentContact_Name
        End Get
        Set(ByVal value As System.String)
            _permanentContact_Name = value
        End Set
    End Property

    Public Property PermanentContact_Relation() As System.String
        Get
            Return _permanentContact_Relation
        End Get
        Set(ByVal value As System.String)
            _permanentContact_Relation = value
        End Set
    End Property

    Public Property TemporaryContact_Name() As System.String
        Get
            Return _temporaryContact_Name
        End Get
        Set(ByVal value As System.String)
            _temporaryContact_Name = value
        End Set
    End Property

    Public Property TemporaryContact_Relation() As System.String
        Get
            Return _temporaryContact_Relation
        End Get
        Set(ByVal value As System.String)
            _temporaryContact_Relation = value
        End Set
    End Property

    Public Property ExpiredDate() As System.String
        Get
            Return _expiredDate
        End Get
        Set(ByVal value As System.String)
            _expiredDate = value
        End Set
    End Property

    Public Property ProbationDate() As System.DateTime
        Get
            Return _probationDate
        End Get
        Set(ByVal value As System.DateTime)
            _probationDate = value
        End Set
    End Property

    Public Property F_Fromdate() As System.String
        Get
            Return _f_Fromdate
        End Get
        Set(ByVal value As System.String)
            _f_Fromdate = value
        End Set
    End Property

    Public Property F_Todate() As System.String
        Get
            Return _f_Todate
        End Get
        Set(ByVal value As System.String)
            _f_Todate = value
        End Set
    End Property

    Public Property GraduatedFrom() As System.String
        Get
            Return _graduatedFrom
        End Get
        Set(ByVal value As System.String)
            _graduatedFrom = value
        End Set
    End Property

    Public Property isExternal() As System.String
        Get
            Return _isExternal
        End Get
        Set(ByVal value As System.String)
            _isExternal = value
        End Set
    End Property

    Public Property isSIHI() As System.String
        Get
            Return _isSIHI
        End Get
        Set(ByVal value As System.String)
            _isSIHI = value
        End Set
    End Property

    Public Property isManager() As System.String
        Get
            Return _isManager
        End Get
        Set(ByVal value As System.String)
            _isManager = value
        End Set
    End Property

    Public Property isEarlyTime() As System.Boolean
        Get
            Return _isEarlyTime
        End Get
        Set(ByVal value As System.Boolean)
            _isEarlyTime = value
        End Set
    End Property

    Public Property defaultShift() As System.String
        Get
            Return _defaultShift
        End Get
        Set(ByVal value As System.String)
            _defaultShift = value
        End Set
    End Property

    Public Property Allowance_Productivity() As System.String
        Get
            Return _allowance_Productivity
        End Get
        Set(ByVal value As System.String)
            _allowance_Productivity = value
        End Set
    End Property

    Public Property Allowance_Style() As System.String
        Get
            Return _allowance_Style
        End Get
        Set(ByVal value As System.String)
            _allowance_Style = value
        End Set
    End Property

    Public Property Allowance_House() As System.String
        Get
            Return _allowance_House
        End Get
        Set(ByVal value As System.String)
            _allowance_House = value
        End Set
    End Property

    Public Property Allowance_Position() As System.String
        Get
            Return _allowance_Position
        End Get
        Set(ByVal value As System.String)
            _allowance_Position = value
        End Set
    End Property

    Public Property Allowance_Attendance() As System.String
        Get
            Return _allowance_Attendance
        End Get
        Set(ByVal value As System.String)
            _allowance_Attendance = value
        End Set
    End Property

    Public Property Allowance_Toxic() As System.String
        Get
            Return _allowance_Toxic
        End Get
        Set(ByVal value As System.String)
            _allowance_Toxic = value
        End Set
    End Property

    Public Property Allowance_Petrol() As System.String
        Get
            Return _allowance_Petrol
        End Get
        Set(ByVal value As System.String)
            _allowance_Petrol = value
        End Set
    End Property

    Public Property ResonTerminated() As System.String
        Get
            Return _resonTerminated
        End Get
        Set(ByVal value As System.String)
            _resonTerminated = value
        End Set
    End Property

    Public Property Email() As System.String
        Get
            Return _email
        End Get
        Set(ByVal value As System.String)
            _email = value
        End Set
    End Property

    Public Property NgayQDNghiViec() As System.DateTime
        Get
            Return _ngayQDNghiViec
        End Get
        Set(ByVal value As System.DateTime)
            _ngayQDNghiViec = value
        End Set
    End Property

    Public Property MaQuyetDinh() As System.String
        Get
            Return _maQuyetDinh
        End Get
        Set(ByVal value As System.String)
            _maQuyetDinh = value
        End Set
    End Property

    Public Property NgayBanGiao() As System.DateTime
        Get
            Return _ngayBanGiao
        End Get
        Set(ByVal value As System.DateTime)
            _ngayBanGiao = value
        End Set
    End Property

    Public Property MaSoThue() As System.String
        Get
            Return _maSoThue
        End Get
        Set(ByVal value As System.String)
            _maSoThue = value
        End Set
    End Property

    Public Property CongViecPhaiLam() As System.String
        Get
            Return _congViecPhaiLam
        End Get
        Set(ByVal value As System.String)
            _congViecPhaiLam = value
        End Set
    End Property

    Public Property SoNgayPhepCuaThang() As System.Double
        Get
            Return _soNgayPhepCuaThang
        End Get
        Set(ByVal value As System.Double)
            _soNgayPhepCuaThang = value
        End Set
    End Property

#End Region

        Public Shared Function GetSmartBooks_Employee(ByVal Employee_ID As System.String) As SmartBooks_Employee
            Return New SmartBooks_Employee(Employee_ID)
        End Function

        Public Shared Function GetSmartBooks_EmployeeAll() As SmartBooks_Employee()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM SmartBooks_Employee", "abc")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeAll = SmartBooks_Employees
            End If
        End If
        End Function

        Public Shared Function GetSmartBooks_EmployeeDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As SmartBooks_Employee()
            Dim kn As New connect(DbSetting.dataPath)
            Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
            Dim oj() As Object = {WhereCondition, OrderByExpression}
            Dim tp() As String = {"NVarChar", "NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_EmployeesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeDynamic = SmartBooks_Employees
            End If
        End If
        End Function

        Public Shared Function GetSmartBooks_EmployeeDynamic(ByVal WhereCondition As String) As SmartBooks_Employee()
            Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from dbo.SmartBooks_Employee where " + WhereCondition, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeDynamic = SmartBooks_Employees
            End If
        End If
    End Function
    Public Shared Function GetSmartBooks_EmployeeDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from SmartBooks_Employee where " + WhereCondition, "table")
        Return table
    End Function

    Public Shared Function GetSmartBooks_EmployeeActiveFollowPeriod(ByVal fdate As DateTime, ByVal tdate As DateTime) As SmartBooks_Employee()
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "')", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeActiveFollowPeriod = SmartBooks_Employees
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_EmployeeActiveFollowPeriodReturnDataTable(ByVal fdate As DateTime, ByVal tdate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "')", "table")
        Return table
    End Function
    Public Shared Function GetSmartBooks_EmployeeActiveFollowPeriod_Exclude_ReturnDataTable(ByVal fdate As DateTime, ByVal tdate As DateTime, ByVal strmang_ExcludeEmployeeList As String()) As DataTable
        Dim str_SQLMaNV As String
        For Each s As String In strmang_ExcludeEmployeeList
            str_SQLMaNV += "'" + s + "',"
        Next
        str_SQLMaNV = str_SQLMaNV.Remove(str_SQLMaNV.Length - 1, 1)
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "') where Employee_ID not in (" + str_SQLMaNV + ")", "table")
        Return table
    End Function
    Public Shared Function GetSmartBooks_EmployeeActiveNewComeFollowPeriod(ByVal fdate As DateTime, ByVal tdate As DateTime) As SmartBooks_Employee()
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "') where StartedDate between '" + fdate_ + "' and '" + tdate_ + "'", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeActiveNewComeFollowPeriod = SmartBooks_Employees
            End If
        End If
    End Function
    Public Shared Function GetSmartBooks_EmployeeActiveNewComeFollowPeriodReturnDataTable(ByVal fdate As DateTime, ByVal tdate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "') where StartedDate between '" + fdate_ + "' and '" + tdate_ + "'", "table")
        Return table
    End Function
    Public Shared Function GetSmartBooks_EmployeeTerminalFollowPeriod(ByVal fdate As DateTime, ByVal tdate As DateTime) As SmartBooks_Employee()
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from SmartBooks_Employee where Employee_Status = 'Terminated' and TernimationDate between '" + fdate_ + "' and '" + tdate_ + "'", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeTerminalFollowPeriod = SmartBooks_Employees
            End If
        End If
    End Function
    Public Shared Function GetSmartBooks_EmployeeTerminalFollowPeriodReturnDataTable(ByVal fdate As DateTime, ByVal tdate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from SmartBooks_Employee where Employee_Status = 'Terminated' and TernimationDate between '" + fdate_ + "' and '" + tdate_ + "'", "table")
        Return table
    End Function
    Public Shared Function GetSmartBooks_EmployeeBirthDateFollowPeriod(ByVal fdate As DateTime, ByVal tdate As DateTime) As SmartBooks_Employee()
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "') where month(BirthDate) >= '" + fdate.Month.ToString + "' and month(BirthDate) <= '" + tdate.Month.ToString + "'", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeBirthDateFollowPeriod = SmartBooks_Employees
            End If
        End If
    End Function
    Public Shared Function GetSmartBooks_EmployeeBirthDateFollowPeriodReturnDataTable(ByVal fdate As DateTime, ByVal tdate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim fdate_ As String = fdate.Year.ToString + "-" + fdate.Month.ToString + "-" + fdate.Day.ToString
        Dim tdate_ As String = tdate.Year.ToString + "-" + tdate.Month.ToString + "-" + tdate.Day.ToString
        Dim table As DataTable = kn.ReadData("select * from udf_NhanVienDangActiveTheoKhoangThoiGian('" + fdate_ + "', '" + tdate_ + "') where month(BirthDate) >= '" + fdate.Month.ToString + "' and month(BirthDate) <= '" + tdate.Month.ToString + "'", "table")
        Return table
    End Function
    Public Shared Function GetSmartBooks_EmployeeFullDynamic(ByVal sql As String) As SmartBooks_Employee()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData(sql, "SmartBooks_Employee")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Employees(table.Rows.Count - 1) As SmartBooks_Employee
                For Each dr As DataRow In table.Rows
                    SmartBooks_Employees(i) = New SmartBooks_Employee(dr)
                    i += 1
                Next
                GetSmartBooks_EmployeeFullDynamic = SmartBooks_Employees
            End If
        End If
    End Function

    Public Shared Function DeleteSmartBooks_EmployeesDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteSmartBooks_EmployeesDynamic", name, oj, tp)
    End Function

    Public Shared Function Search(ByVal emp() As SmartBooks_Employee, ByVal Employee_ID As String) As SmartBooks_Employee
        For Each SmartBooks_Employee1 As SmartBooks_Employee In emp
            If SmartBooks_Employee1.Employee_ID = Employee_ID Then
                Return SmartBooks_Employee1
            End If
        Next
    End Function
End Class
#End Region