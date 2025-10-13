Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class connect

#Region "Variable"
    Dim cn As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim ds As New DataSet

    Dim _server As String
    Dim _database As String
    Dim _uid As String
    Dim _pass As String
    Dim _fileAccess As String
    Public _passAccess As String

    Dim cnole As New OleDbConnection
    Dim daole As New OleDbDataAdapter
    Dim cmdole As New OleDbCommand
#End Region

#Region "Property"
    Public Property SERVER() As String
        Get
            Return _server
        End Get
        Set(ByVal Value As String)
            _server = Value
        End Set
    End Property

    Public Property DATABASE() As String
        Get
            Return _database
        End Get
        Set(ByVal Value As String)
            _database = Value
        End Set
    End Property

    Public Property UID() As String
        Get
            Return _uid
        End Get
        Set(ByVal Value As String)
            _uid = Value
        End Set
    End Property

    Public Property PASS() As String
        Get
            Return _pass
        End Get
        Set(ByVal Value As String)
            _pass = Value
        End Set
    End Property

    Public Property PASSACCESS() As String
        Get
            Return _passAccess
        End Get
        Set(ByVal Value As String)
            _passAccess = Value
        End Set
    End Property

    Public Property FILEACCESS() As String
        Get
            Return _fileAccess
        End Get
        Set(ByVal Value As String)
            _fileAccess = Value
        End Set
    End Property

#End Region

#Region "Contructor"
    Public Sub New()


    End Sub
    Public Sub New(ByVal dataPath As String)
        'cn.ConnectionString = DbSetting.dataPath
        cn.ConnectionString = dataPath

    End Sub
#End Region

#Region "Open & Close Conection"
    Public Function OpenConnection()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub CloseConnection()
        cn.Close()
    End Sub
    Public Function OpenConnectFile()
        Try
            cnole.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _fileAccess + ";Jet OLEDB:Database Password=" + _passAccess + ";"
            cnole.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub CloseConnectFile()
        cnole.Close()
    End Sub
#End Region

#Region "Method Access Data SQL"
    Public Function SaveData(ByVal sql As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(sql, cn)
            cmd.CommandTimeout = 9000
            cmd.ExecuteNonQuery()
            SaveData = True
        Catch ex As Exception
            MsgBox(ex.Message)
            SaveData = False
        Finally
            cn.Close()
        End Try
    End Function
    Public Function SaveDataNotReport(ByVal sql As String) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(sql, cn)
            cmd.CommandTimeout = 9000
            cmd.ExecuteNonQuery()
            SaveDataNotReport = True
        Catch ex As Exception
            SaveDataNotReport = False
        Finally
            cn.Close()
        End Try
    End Function
    Public Function ReadData(ByVal sql As String, ByVal Table As String) As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand(sql, cn)
            cmd.CommandTimeout = 9000
            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, Table)
            cn.Close()
            ReadData = ds.Tables(Table)
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try
    End Function
    Public Function ExecStore(ByVal StoreName As String, ByVal Parameter As String(), ByVal value As Object(), ByVal Type As String()) As Integer
        Try
            OpenConnection()
            Dim cmd As New SqlCommand(StoreName, cn)
            cmd.CommandTimeout = 9000
            cmd.CommandType = CommandType.StoredProcedure
            For i As Integer = 0 To Parameter.Length - 1
                If Type(i) = "DateTime" Then
                    If value(i) = DateTime.MinValue Then
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.DateTime))
                        cmd.Parameters(Parameter(i)).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.DateTime))
                        cmd.Parameters(Parameter(i)).Value = value(i)
                    End If
                ElseIf Type(i) = "Float" Then
                    If value(i) = 0 Then
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Float))
                        cmd.Parameters(Parameter(i)).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Float))
                        cmd.Parameters(Parameter(i)).Value = value(i)
                    End If
                ElseIf Type(i) = "Int" Then
                    If value(i) = 0 Then
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Int))
                        cmd.Parameters(Parameter(i)).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Int))
                        cmd.Parameters(Parameter(i)).Value = value(i)
                    End If
                ElseIf Type(i) = "NVarChar" Then
                    If value(i) = String.Empty Then
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.NVarChar))
                        cmd.Parameters(Parameter(i)).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.NVarChar))
                        cmd.Parameters(Parameter(i)).Value = value(i)
                    End If
                ElseIf Type(i) = "Bit" Then
                    If CStr(value(i)) = Boolean.FalseString Then
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Bit))
                        cmd.Parameters(Parameter(i)).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Bit))
                        cmd.Parameters(Parameter(i)).Value = value(i)
                    End If
                ElseIf Type(i) = "Binary" Then
                    If value(i) Is Nothing Then
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Binary))
                        cmd.Parameters(Parameter(i)).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add(New SqlParameter(Parameter(i), SqlDbType.Binary))
                        cmd.Parameters(Parameter(i)).Value = value(i)
                    End If
                Else
                    cmd.Parameters.Add(New SqlParameter(Parameter(i), value(i)))
                    cmd.Parameters(Parameter(i)).Value = value(i)
                End If
            Next
            ExecStore = cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try
    End Function
    Public Function ExecStoreReturnTable(ByVal StoreName As String, ByVal Parameter As String(), ByVal value As Object(), ByVal Type As String()) As DataTable
        Try
            OpenConnection()
            Dim cmd As New SqlCommand(StoreName, cn)
            cmd.CommandTimeout = 9000
            cmd.CommandType = CommandType.StoredProcedure
            For i As Integer = 0 To Parameter.Length - 1
                cmd.Parameters.Add(New SqlParameter(Parameter(i), value(i)))
                cmd.Parameters(Parameter(i)).Value = value(i)
            Next
            Dim adapter As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            adapter.Fill(dt)
            cn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try
    End Function
    Public Function Lamtrongio(ByVal number As Double) As Double
        Try
            Dim a, b, c As Double
            Dim duong, am As String
            Dim tien() As String

            b = Int(number)
            a = number - Int(number)
            a = a * 10

            If a < 5 Then
                a = 0.0
            Else
                a = 0.5
                'b = b + 1
            End If

            Return b + a

        Catch ex As Exception
            MsgBox(ex.Message)
            Return number
        End Try
    End Function
    Public Function ReadDataFormStore(ByVal _StoreName As String, ByVal _StartDate As DateTime, ByVal _EndDate As DateTime, ByVal _TeamCode As String)
        Try
            OpenConnection()
            cmd = New SqlCommand(_StoreName, cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@StartDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)
            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@EndDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)

            'TeamCode
            Dim sparTeamCode As New SqlParameter
            With sparTeamCode
                .ParameterName = "@TeamCode"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _TeamCode
            End With
            cmd.Parameters.Add(sparTeamCode)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "EmpRegisLeave")
            cn.Close()
            ReadDataFormStore = ds.Tables("EmpRegisLeave")
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function

    Public Function TranferDataAdjusment(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime, ByVal _Terminal As String)
        Try
            OpenConnection()
            cmd = New SqlCommand("tranfer_data_adjusment", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@fromdate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)
            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@todate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)

            'TeamCode
            'Dim sparTeamCode As New SqlParameter
            'With sparTeamCode
            '    .ParameterName = "@Terminal"
            '    .SqlDbType = SqlDbType.NVarChar
            '    .Value = _Terminal
            'End With
            'cmd.Parameters.Add(sparTeamCode)

            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function

    Public Function ReadData(ByVal _StoreName As String, ByVal _month As Integer, ByVal _year As Integer)

        Try
            OpenConnection()
            cmd = New SqlCommand(_StoreName, cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparMonth As New SqlParameter
            With sparMonth
                .ParameterName = "@Month"
                .SqlDbType = SqlDbType.Int
                .Value = _month
            End With
            cmd.Parameters.Add(sparMonth)
            'End Date
            Dim sparYear As New SqlParameter
            With sparYear
                .ParameterName = "@Year"
                .SqlDbType = SqlDbType.Int
                .Value = _year
            End With
            cmd.Parameters.Add(sparYear)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "Result")
            cn.Close()
            ReadData = ds.Tables("Result")
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function
    Public Function TotalInOut(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime)

        Try
            OpenConnection()
            cmd = New SqlCommand("sp_TotalInOut", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@StartDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)
            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@EndDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "TotalInOut")
            cn.Close()
            TotalInOut = ds.Tables("TotalInOut")
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function
    Public Function Employee_ExpiriedDate(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime) As DataTable
        Dim tbExpiriedDate As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand("Employee_ExpiriedDate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@Fromdate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)
            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@todate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)
            tbExpiriedDate = New DataTable
            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "Employee_ExpiriedDate")
            cn.Close()
            tbExpiriedDate = ds.Tables("Employee_ExpiriedDate")
            Return tbExpiriedDate
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            Return Nothing
        End Try

    End Function
    'Public Function TimeKeeping(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime)
    '    Try
    '        OpenConnection()
    '        cmd = New SqlCommand("sp_TongHopCong", cn)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 9000
    '        'Start Date
    '        Dim sparStartDate As New SqlParameter
    '        With sparStartDate
    '            .ParameterName = "@StartDate"
    '            .SqlDbType = SqlDbType.DateTime
    '            .Value = _StartDate
    '        End With
    '        cmd.Parameters.Add(sparStartDate)
    '        'End Date
    '        Dim sparEndDate As New SqlParameter
    '        With sparEndDate
    '            .ParameterName = "@EndDate"
    '            .SqlDbType = SqlDbType.DateTime
    '            .Value = _EndDate
    '        End With
    '        cmd.Parameters.Add(sparEndDate)
    '        da = New SqlDataAdapter(cmd)
    '        ds.Tables.Clear()
    '        da.Fill(ds, "TimeKeeping")
    '        cn.Close()
    '        TimeKeeping = ds.Tables("TimeKeeping")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        cn.Close()
    '    End Try

    'End Function

    ''Hiếu làm thêm
    Public Function TimeKeeping(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime, ByVal _depart As String, ByVal _team As String, ByVal _section As String, ByVal _position As String, ByVal _empid As String, ByVal _ch As Integer) As DataTable
        Dim dt As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand("sp_TongHopCong1", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            Dim FilteredRecordTime(-1) As Date
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@StartDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)

            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@EndDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)

            ''Department
            'Dim dept As New SqlParameter
            'With dept
            '    .ParameterName = "@Department"
            '    .SqlDbType = SqlDbType.NVarChar
            '    .Value = _depart
            'End With
            'cmd.Parameters.Add(dept)

            ''team
            'Dim teamcode As New SqlParameter
            'With teamcode
            '    .ParameterName = "@team"
            '    .SqlDbType = SqlDbType.NVarChar
            '    .Value = _team
            'End With
            'cmd.Parameters.Add(teamcode)

            'section
            Dim sectioncode As New SqlParameter
            With sectioncode
                .ParameterName = "@section"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _section
            End With
            cmd.Parameters.Add(sectioncode)

            'position
            Dim position As New SqlParameter
            With position
                .ParameterName = "@position"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _position
            End With
            cmd.Parameters.Add(position)

            'employee_id
            Dim employeeid As New SqlParameter
            With employeeid
                .ParameterName = "@empid"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _empid
            End With
            cmd.Parameters.Add(employeeid)

            ''employee_id
            'Dim choose As New SqlParameter
            'With choose
            '    .ParameterName = "@chon"
            '    .SqlDbType = SqlDbType.Int
            '    .Value = _ch
            'End With
            'cmd.Parameters.Add(choose)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "tonghopcong")

            dt = ds.Tables("tonghopcong")
            'TimeKeeping = ds.Tables("TimeKeeping")
            cn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            dt = Nothing
            Return dt
        End Try

    End Function
    ''Hiếu làm thêm
    Public Function TimeKeeping1(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime, ByVal _depart As String, ByVal _team As String, ByVal _section As String, ByVal _position As String, ByVal _empid As String, ByVal _ch As Integer) As DataTable
        Dim dt As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand("sp_TongHopCong2", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            Dim FilteredRecordTime(-1) As Date
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@StartDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)

            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@EndDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)

            'section
            Dim sectioncode As New SqlParameter
            With sectioncode
                .ParameterName = "@section"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _section
            End With
            cmd.Parameters.Add(sectioncode)

            'position
            Dim position As New SqlParameter
            With position
                .ParameterName = "@position"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _position
            End With
            cmd.Parameters.Add(position)

            'employee_id
            Dim employeeid As New SqlParameter
            With employeeid
                .ParameterName = "@empid"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _empid
            End With
            cmd.Parameters.Add(employeeid)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "tonghopcong")

            dt = ds.Tables("tonghopcong")
            'TimeKeeping = ds.Tables("TimeKeeping")
            cn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            dt = Nothing
            Return dt
        End Try

    End Function
    Public Function TimeKeeping_External(ByVal _edate As String, ByVal _StartDate As DateTime, ByVal _EndDate As DateTime, ByVal _section As String, ByVal _position As String, ByVal _empid As String, ByVal _ch As Integer) As DataTable
        Dim dt As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand("sp_TongCongNgoaiGio", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            Dim FilteredRecordTime(-1) As Date

            'edate
            Dim eDate As New SqlParameter
            With eDate
                .ParameterName = "@eDate"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _edate
            End With
            cmd.Parameters.Add(eDate)

            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@StartDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)

            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@EndDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)
            'section
            Dim sectioncode As New SqlParameter
            With sectioncode
                .ParameterName = "@section"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _section
            End With
            cmd.Parameters.Add(sectioncode)

            'position
            Dim position As New SqlParameter
            With position
                .ParameterName = "@position"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _position
            End With
            cmd.Parameters.Add(position)

            'employee_id
            Dim employeeid As New SqlParameter
            With employeeid
                .ParameterName = "@empid"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _empid
            End With
            cmd.Parameters.Add(employeeid)

            ''employee_id
            'Dim choose As New SqlParameter
            'With choose
            '    .ParameterName = "@chon"
            '    .SqlDbType = SqlDbType.Int
            '    .Value = _ch
            'End With
            'cmd.Parameters.Add(choose)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "tonghopcong_external")

            dt = ds.Tables("tonghopcong_external")
            'TimeKeeping = ds.Tables("TimeKeeping")
            cn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            dt = Nothing
            Return dt
        End Try

    End Function
    ''Hiếu làm thêm
    Public Function BHXH(ByVal month As Integer, ByVal year As Integer) As DataTable
        Dim dt As DataTable
        Try
            OpenConnection()
            cmd = New SqlCommand("sp_BangKeBHXH", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            Dim FilteredRecordTime(-1) As Date
            'Start Date
            Dim sparMonth As New SqlParameter
            With sparMonth
                .ParameterName = "@Month"
                .SqlDbType = SqlDbType.Int
                .Value = month
            End With
            cmd.Parameters.Add(sparMonth)

            Dim sparYear As New SqlParameter
            With sparYear
                .ParameterName = "@Year"
                .SqlDbType = SqlDbType.Int
                .Value = year
            End With
            cmd.Parameters.Add(sparYear)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "BHXH")

            dt = ds.Tables("BHXH")
            'TimeKeeping = ds.Tables("TimeKeeping")
            cn.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            dt = Nothing
            Return dt
        End Try

    End Function
    Public Function TotalTimeKeepingDate(ByVal _StartDate As DateTime, ByVal _EndDate As DateTime, ByVal empid As String)

        Try
            OpenConnection()
            cmd = New SqlCommand("sp_SelectTongHopCong", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@StartDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _StartDate
            End With
            cmd.Parameters.Add(sparStartDate)
            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@EndDate"
                .SqlDbType = SqlDbType.DateTime
                .Value = _EndDate
            End With
            cmd.Parameters.Add(sparEndDate)
            Dim employeeid As New SqlParameter
            With employeeid
                .ParameterName = "@EmployeeID"
                .SqlDbType = SqlDbType.VarChar
                .Value = empid
            End With
            cmd.Parameters.Add(employeeid)

            da = New SqlDataAdapter(cmd)
            ds.Tables.Clear()
            da.Fill(ds, "TimeKeeping")
            cn.Close()
            TotalTimeKeepingDate = ds.Tables("TimeKeeping")
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function
    Public Function ExcuteData(ByVal _StoreName As String, ByVal _year As Integer, ByVal _NgayGiuLai As Integer) As Boolean
        Try
            OpenConnection()
            cmd = New SqlCommand(_StoreName, cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Start Date
            Dim sparStartDate As New SqlParameter
            With sparStartDate
                .ParameterName = "@Year"
                .SqlDbType = SqlDbType.Int
                .Value = _year
            End With
            cmd.Parameters.Add(sparStartDate)
            'End Date
            Dim sparEndDate As New SqlParameter
            With sparEndDate
                .ParameterName = "@GiuLai"
                .SqlDbType = SqlDbType.Float
                .Value = _NgayGiuLai
            End With
            cmd.Parameters.Add(sparEndDate)
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            Return False
        End Try
    End Function
    Public Function UpdateImagesInformation(ByVal _StoreName As String, ByVal _Images As Byte(), ByVal _Employee_ID As String)

        Try
            OpenConnection()
            cmd = New SqlCommand(_StoreName, cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Images
            Dim sparImages As New SqlParameter
            With sparImages
                .ParameterName = "@Picture"
                .SqlDbType = SqlDbType.Image
                .Value = _Images
            End With
            cmd.Parameters.Add(sparImages)
            'Employee_ID
            Dim sparEmployeeID As New SqlParameter
            With sparEmployeeID
                .ParameterName = "@Employee_ID"
                .SqlDbType = SqlDbType.NVarChar
                .Value = _Employee_ID
            End With
            cmd.Parameters.Add(sparEmployeeID)

            cmd.ExecuteNonQuery()

            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function

    Public Function UpdateImagesInformation(ByVal _StoreName As String, ByVal _Images As Byte())

        Try
            OpenConnection()
            cmd = New SqlCommand(_StoreName, cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 9000
            'Images
            Dim sparImages As New SqlParameter
            With sparImages
                .ParameterName = "@Picture"
                .SqlDbType = SqlDbType.Image
                .Value = _Images
            End With
            cmd.Parameters.Add(sparImages)

            cmd.ExecuteNonQuery()

            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
        End Try

    End Function

#End Region

#Region "Method Access Data File Access"
    Public Function SaveDataToFile(ByVal sql As String) As Boolean
        Try
            OpenConnectFile()
            cmdole = New OleDbCommand(sql, cnole)
            cmdole.ExecuteNonQuery()
            SaveDataToFile = True
        Catch ex As Exception
            MsgBox(ex.Message)
            SaveDataToFile = False
        Finally
            CloseConnectFile()
        End Try
    End Function
    Public Function ReadDataFormFile(ByVal sql As String, ByVal Table As String) As DataTable
        Try
            OpenConnectFile()
            cmdole = New OleDbCommand(sql, cnole)
            daole = New OleDbDataAdapter(cmdole)
            ds.Tables.Clear()
            daole.Fill(ds, Table)
            ReadDataFormFile = ds.Tables(Table)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CloseConnectFile()
        End Try

    End Function
#End Region

#Region "Working Exel"

    Public Function GetListDataFromSheetExcel(ByVal strQuery As String, ByVal strFileName As String, ByVal table As String) As DataTable
        Try
            Dim cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + ";Extended Properties=""Excel 8.0;HDR=YES;""")
            Dim da As OleDbDataAdapter
            Dim ds As DataSet
            ds = Nothing
            da = Nothing
            da = New OleDb.OleDbDataAdapter(strQuery, cnn)
            ds = New DataSet("ExcelFile")
            ds.Tables.Clear()
            da.Fill(ds, table)
            GetListDataFromSheetExcel = ds.Tables(table)
        Catch ex As Exception
            GetListDataFromSheetExcel = Nothing
        End Try
    End Function

#End Region

#Region "Working Time"
    Public Function DateTimeToString(ByVal DT As DateTime) As String
        Try
            Dim str As String = DT.Year.ToString + "-" + DT.Month.ToString + "-" + DT.Day.ToString + " " + DT.Hour.ToString + ":" + DT.Minute.ToString + ":" + DT.Second.ToString
            Return str
        Catch ex As Exception
            Return "1900-01-01 00:00:00"
        End Try
    End Function
#End Region
End Class
