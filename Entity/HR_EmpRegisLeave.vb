Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_EmpRegisLeave"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_EmpRegisLeave.
    ''' </summary>
    Public Class HR_EmpRegisLeave
    Private _employee_ID As System.String = String.Empty
    Private _dateLeave As System.DateTime
    Private _leaveType_ID As System.String = String.Empty
    Private _hourLeave As System.Double
    Private _tongPhepNam As System.Double
    Private _soNgayNghi As System.Double
    Private _isPaid As System.Int16
    Private _comment As System.String = String.Empty
    Private _insertBy As System.String = String.Empty
    Private _insertDate As System.DateTime
    Private _updateBy As System.String = String.Empty
    Private _updateDate As System.DateTime
    Private kn As New connect(DbSetting.dataPath)

    Public Sub New()
    End Sub

    Public Sub New(ByVal Employee_ID As System.String, ByVal DateLeave As System.DateTime)
        Dim name() As String = {"@Employee_ID", "@DateLeave"}
        Dim oj() As Object = {Employee_ID, DateLeave}
        Dim tp() As String = {"NVarChar", "DateTime"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisLeave", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _employee_ID = Employee_ID
                _dateLeave = DateLeave
            End If
        Else
            _employee_ID = Employee_ID
            _dateLeave = DateLeave
        End If
    End Sub

    Public Sub New(ByVal _datarow As DataRow)
        If Not IsNothing(_datarow) Then
            If Not IsDBNull(_datarow("Employee_ID")) Then
                _employee_ID = _datarow("Employee_ID")
            End If
            If Not IsDBNull(_datarow("DateLeave")) Then
                _dateLeave = _datarow("DateLeave")
            End If
            If Not IsDBNull(_datarow("LeaveType_ID")) Then
                _leaveType_ID = _datarow("LeaveType_ID")
            End If
            If Not IsDBNull(_datarow("HourLeave")) Then
                _hourLeave = _datarow("HourLeave")
            End If
            If Not IsDBNull(_datarow("TongPhepNam")) Then
                _tongPhepNam = _datarow("TongPhepNam")
            End If
            If Not IsDBNull(_datarow("SoNgayNghi")) Then
                _soNgayNghi = _datarow("SoNgayNghi")
            End If
            If Not IsDBNull(_datarow("isPaid")) Then
                _isPaid = _datarow("isPaid")
            End If
            If Not IsDBNull(_datarow("Comment")) Then
                _comment = _datarow("Comment")
            End If
            If Not IsDBNull(_datarow("InsertBy")) Then
                _insertBy = _datarow("InsertBy")
            End If
            If Not IsDBNull(_datarow("InsertDate")) Then
                _insertDate = _datarow("InsertDate")
            End If
            If Not IsDBNull(_datarow("UpdateBy")) Then
                _updateBy = _datarow("UpdateBy")
            End If
            If Not IsDBNull(_datarow("UpdateDate")) Then
                _updateDate = _datarow("UpdateDate")
            End If
        End If
    End Sub

    Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
        If Not IsNothing(_datarow) Then
            If Not IsDBNull(_datarow("Employee_ID")) Then
                _employee_ID = _datarow("Employee_ID")
            End If
            If Not IsDBNull(_datarow("DateLeave")) Then
                _dateLeave = _datarow("DateLeave")
            End If
            If Not IsDBNull(_datarow("LeaveType_ID")) Then
                _leaveType_ID = _datarow("LeaveType_ID")
            End If
            If Not IsDBNull(_datarow("HourLeave")) Then
                _hourLeave = _datarow("HourLeave")
            End If
            If Not IsDBNull(_datarow("TongPhepNam")) Then
                _tongPhepNam = _datarow("TongPhepNam")
            End If
            If Not IsDBNull(_datarow("SoNgayNghi")) Then
                _soNgayNghi = _datarow("SoNgayNghi")
            End If
            If Not IsDBNull(_datarow("isPaid")) Then
                _isPaid = _datarow("isPaid")
            End If
            If Not IsDBNull(_datarow("Comment")) Then
                _comment = _datarow("Comment")
            End If
            If Not IsDBNull(_datarow("InsertBy")) Then
                _insertBy = _datarow("InsertBy")
            End If
            If Not IsDBNull(_datarow("InsertDate")) Then
                _insertDate = _datarow("InsertDate")
            End If
            If Not IsDBNull(_datarow("UpdateBy")) Then
                _updateBy = _datarow("UpdateBy")
            End If
            If Not IsDBNull(_datarow("UpdateDate")) Then
                _updateDate = _datarow("UpdateDate")
            End If
        End If
    End Sub

    Public Sub Delete()
        Dim name() As String = {"@Employee_ID", "@DateLeave"}
        Dim oj() As Object = {Employee_ID, DateLeave}
        Dim tp() As String = {"NVarChar", "DateTime"}
        kn.ExecStore("dbo.usp_DeleteHR_EmpRegisLeave", name, oj, tp)
    End Sub

    Public Sub Update()
        Dim name() As String = {"@Employee_ID", "@DateLeave", "@LeaveType_ID", "@HourLeave", "@TongPhepNam", "@SoNgayNghi", "@isPaid", "@Comment", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate"}
        Dim oj() As Object = {Employee_ID, DateLeave, LeaveType_ID, HourLeave, TongPhepNam, SoNgayNghi, isPaid, Comment, InsertBy, InsertDate, UpdateBy, UpdateDate}
        Dim tp() As String = {"NVarChar", "DateTime", "NVarChar", "Float", "Float", "Float", "SmallInt", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime"}
        kn.ExecStore("dbo.usp_UpdateHR_EmpRegisLeave", name, oj, tp)
    End Sub

    Public Sub Create()
        Dim name() As String = {"@Employee_ID", "@DateLeave", "@LeaveType_ID", "@HourLeave", "@TongPhepNam", "@SoNgayNghi", "@isPaid", "@Comment", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate"}
        Dim oj() As Object = {Employee_ID, DateLeave, LeaveType_ID, HourLeave, TongPhepNam, SoNgayNghi, isPaid, Comment, InsertBy, InsertDate, UpdateBy, UpdateDate}
        Dim tp() As String = {"NVarChar", "DateTime", "NVarChar", "Float", "Float", "Float", "SmallInt", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime"}
        kn.ExecStore("dbo.usp_InsertHR_EmpRegisLeave", name, oj, tp)
    End Sub

    Public Sub CreateUpdate()
        Dim name() As String = {"@Employee_ID", "@DateLeave", "@LeaveType_ID", "@HourLeave", "@TongPhepNam", "@SoNgayNghi", "@isPaid", "@Comment", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate"}
        Dim oj() As Object = {Employee_ID, DateLeave, LeaveType_ID, HourLeave, TongPhepNam, SoNgayNghi, isPaid, Comment, InsertBy, InsertDate, UpdateBy, UpdateDate}
        Dim tp() As String = {"NVarChar", "DateTime", "NVarChar", "Float", "Float", "Float", "SmallInt", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime"}
        kn.ExecStore("dbo.usp_InsertUpdateHR_EmpRegisLeave", name, oj, tp)
    End Sub

    Public Function GetSQLInsert() As String
        Dim __Employee_ID As String
        Dim __DateLeave As String
        Dim __LeaveType_ID As String
        Dim __HourLeave As String
        Dim __TongPhepNam As String
        Dim __SoNgayNghi As String
        Dim __isPaid As String
        Dim __Comment As String
        Dim __InsertBy As String
        Dim __InsertDate As String
        Dim __UpdateBy As String
        Dim __UpdateDate As String
        If Employee_ID <> String.Empty Then
            __Employee_ID = "N'" + Employee_ID + "'"
        Else
            __Employee_ID = "null"
        End If
        If DateLeave <> DateTime.MinValue Then
            __DateLeave = "'" + kn.DateTimeToString(DateLeave) + "'"
        Else
            __DateLeave = "null"
        End If
        If LeaveType_ID <> String.Empty Then
            __LeaveType_ID = "N'" + LeaveType_ID + "'"
        Else
            __LeaveType_ID = "null"
        End If
        __HourLeave = "'" + HourLeave.tostring + "'"
        __TongPhepNam = "'" + TongPhepNam.tostring + "'"
        __SoNgayNghi = "'" + SoNgayNghi.tostring + "'"
        __isPaid = "'" + isPaid.tostring + "'"
        If Comment <> String.Empty Then
            __Comment = "N'" + Comment + "'"
        Else
            __Comment = "null"
        End If
        If InsertBy <> String.Empty Then
            __InsertBy = "N'" + InsertBy + "'"
        Else
            __InsertBy = "null"
        End If
        If InsertDate <> DateTime.MinValue Then
            __InsertDate = "'" + kn.DateTimeToString(InsertDate) + "'"
        Else
            __InsertDate = "null"
        End If
        If UpdateBy <> String.Empty Then
            __UpdateBy = "N'" + UpdateBy + "'"
        Else
            __UpdateBy = "null"
        End If
        If UpdateDate <> DateTime.MinValue Then
            __UpdateDate = "'" + kn.DateTimeToString(UpdateDate) + "'"
        Else
            __UpdateDate = "null"
        End If
        Dim sql As String = String.Empty
        sql = "INSERT INTO [HR_EmpRegisLeave]([Employee_ID],[DateLeave],[LeaveType_ID],[HourLeave],[TongPhepNam],[SoNgayNghi],[isPaid],[Comment],[InsertBy],[InsertDate],[UpdateBy],[UpdateDate])VALUES(" & _
        __Employee_ID + "," + __DateLeave + "," + __LeaveType_ID + "," + __HourLeave + "," + __TongPhepNam + "," + __SoNgayNghi + "," + __isPaid + "," + __Comment + "," + __InsertBy + "," + __InsertDate + "," + __UpdateBy + "," + __UpdateDate + ")"
        Return sql
    End Function

    Public Function GetSQLUpdate() As String
        Dim __Employee_ID As String
        Dim __DateLeave As String
        Dim __LeaveType_ID As String
        Dim __HourLeave As String
        Dim __TongPhepNam As String
        Dim __SoNgayNghi As String
        Dim __isPaid As String
        Dim __Comment As String
        Dim __InsertBy As String
        Dim __InsertDate As String
        Dim __UpdateBy As String
        Dim __UpdateDate As String
        If Employee_ID <> String.Empty Then
            __Employee_ID = "N'" + Employee_ID + "'"
        Else
            __Employee_ID = "null"
        End If
        If DateLeave <> DateTime.MinValue Then
            __DateLeave = "'" + kn.DateTimeToString(DateLeave) + "'"
        Else
            __DateLeave = "null"
        End If
        If LeaveType_ID <> String.Empty Then
            __LeaveType_ID = "N'" + LeaveType_ID + "'"
        Else
            __LeaveType_ID = "null"
        End If
        __HourLeave = "'" + HourLeave.tostring + "'"
        __TongPhepNam = "'" + TongPhepNam.tostring + "'"
        __SoNgayNghi = "'" + SoNgayNghi.tostring + "'"
        __isPaid = "'" + isPaid.tostring + "'"
        If Comment <> String.Empty Then
            __Comment = "N'" + Comment + "'"
        Else
            __Comment = "null"
        End If
        If InsertBy <> String.Empty Then
            __InsertBy = "N'" + InsertBy + "'"
        Else
            __InsertBy = "null"
        End If
        If InsertDate <> DateTime.MinValue Then
            __InsertDate = "'" + kn.DateTimeToString(InsertDate) + "'"
        Else
            __InsertDate = "null"
        End If
        If UpdateBy <> String.Empty Then
            __UpdateBy = "N'" + UpdateBy + "'"
        Else
            __UpdateBy = "null"
        End If
        If UpdateDate <> DateTime.MinValue Then
            __UpdateDate = "'" + kn.DateTimeToString(UpdateDate) + "'"
        Else
            __UpdateDate = "null"
        End If
        Dim sql As String = String.Empty
        sql = "UPDATE [HR_EmpRegisLeave] SET [Employee_ID]=" + __Employee_ID + ",[DateLeave]=" + __DateLeave + ",[LeaveType_ID]=" + __LeaveType_ID + ",[HourLeave]=" + __HourLeave + ",[TongPhepNam]=" + __TongPhepNam + ",[SoNgayNghi]=" + __SoNgayNghi + ",[isPaid]=" + __isPaid + ",[Comment]=" + __Comment + ",[InsertBy]=" + __InsertBy + ",[InsertDate]=" + __InsertDate + ",[UpdateBy]=" + __UpdateBy + ",[UpdateDate]=" + __UpdateDate + " WHERE [Employee_ID]=" + __Employee_ID + " and [DateLeave]=" + __DateLeave
        Return sql
    End Function

    Public Function GetSQLDelete() As String
        Dim __Employee_ID As String
        Dim __DateLeave As String
        If Employee_ID <> String.Empty Then
            __Employee_ID = "N'" + Employee_ID + "'"
        Else
            __Employee_ID = "null"
        End If
        If DateLeave <> DateTime.MinValue Then
            __DateLeave = "'" + kn.DateTimeToString(DateLeave) + "'"
        Else
            __DateLeave = "null"
        End If
        Dim sql As String = String.Empty
        sql = "DELETE FROM [HR_EmpRegisLeave] WHERE [Employee_ID]=" + __Employee_ID + " and [DateLeave]=" + __DateLeave
        Return sql
    End Function

    Public Shared Function NewHR_EmpRegisLeave(ByVal Employee_ID As System.String, ByVal DateLeave As System.DateTime) As HR_EmpRegisLeave
        Dim newEntity As New HR_EmpRegisLeave
        newEntity._employee_ID = Employee_ID
        newEntity._dateLeave = DateLeave
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

    Public Property DateLeave() As System.DateTime
        Get
            Return _dateLeave
        End Get
        Set(ByVal value As System.DateTime)
            _dateLeave = value
        End Set
    End Property

    Public Property LeaveType_ID() As System.String
        Get
            Return _leaveType_ID
        End Get
        Set(ByVal value As System.String)
            _leaveType_ID = value
        End Set
    End Property

    Public Property HourLeave() As System.Double
        Get
            Return _hourLeave
        End Get
        Set(ByVal value As System.Double)
            _hourLeave = value
        End Set
    End Property

    Public Property TongPhepNam() As System.Double
        Get
            Return _tongPhepNam
        End Get
        Set(ByVal value As System.Double)
            _tongPhepNam = value
        End Set
    End Property

    Public Property SoNgayNghi() As System.Double
        Get
            Return _soNgayNghi
        End Get
        Set(ByVal value As System.Double)
            _soNgayNghi = value
        End Set
    End Property

    Public Property isPaid() As System.Int16
        Get
            Return _isPaid
        End Get
        Set(ByVal value As System.Int16)
            _isPaid = value
        End Set
    End Property

    Public Property Comment() As System.String
        Get
            Return _comment
        End Get
        Set(ByVal value As System.String)
            _comment = value
        End Set
    End Property

    Public Property InsertBy() As System.String
        Get
            Return _insertBy
        End Get
        Set(ByVal value As System.String)
            _insertBy = value
        End Set
    End Property

    Public Property InsertDate() As System.DateTime
        Get
            Return _insertDate
        End Get
        Set(ByVal value As System.DateTime)
            _insertDate = value
        End Set
    End Property

    Public Property UpdateBy() As System.String
        Get
            Return _updateBy
        End Get
        Set(ByVal value As System.String)
            _updateBy = value
        End Set
    End Property

    Public Property UpdateDate() As System.DateTime
        Get
            Return _updateDate
        End Get
        Set(ByVal value As System.DateTime)
            _updateDate = value
        End Set
    End Property

#End Region

    Public Shared Function GetHR_EmpRegisLeave(ByVal Employee_ID As System.String, ByVal DateLeave As System.DateTime) As HR_EmpRegisLeave
        Return New HR_EmpRegisLeave(Employee_ID, DateLeave)
    End Function

    Public Shared Function GetHR_EmpRegisLeaveAll() As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM HR_EmpRegisLeave", "abc")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                GetHR_EmpRegisLeaveAll = HR_EmpRegisLeaves
            End If
        End If
    End Function

    Public Shared Function GetHR_EmpRegisLeaveDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisLeavesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                GetHR_EmpRegisLeaveDynamic = HR_EmpRegisLeaves
            End If
        End If
    End Function

    Public Shared Function GetHR_EmpRegisLeaveDynamic(ByVal WhereCondition As String) As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisLeavesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                GetHR_EmpRegisLeaveDynamic = HR_EmpRegisLeaves
            End If
        End If
    End Function
    Public Shared Function GetHR_EmpRegisLeaveDynamic_ReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisLeavesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                GetHR_EmpRegisLeaveDynamic_ReturnDataTable = table
            End If
        End If
    End Function

    Public Shared Function GetHR_EmpRegisLeaveFullDynamic(ByVal sql As String) As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData(sql, "HR_EmpRegisLeave")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                GetHR_EmpRegisLeaveFullDynamic = HR_EmpRegisLeaves
            End If
        End If
    End Function

    Public Shared Function DeleteHR_EmpRegisLeavesDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmpRegisLeavesDynamic", name, oj, tp)
    End Function

    Public Shared Function GetHR_EmpRegisLeaveByAndEmployee_ID(ByVal Employee_ID As System.String) As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisLeavesByAndEmployee_ID", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                GetHR_EmpRegisLeaveByAndEmployee_ID = HR_EmpRegisLeaves
            End If
        End If
    End Function

    Public Shared Function DeleteHR_EmpRegisLeaveByAndEmployee_ID(ByVal Employee_ID As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmpRegisLeavesByAndEmployee_ID", name, oj, tp)
    End Function

    Public Shared Function GetHR_EmpRegisLeaveByAndLeaveType_ID(ByVal LeaveType_ID As System.String) As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@LeaveType_ID"}
        Dim oj() As Object = {LeaveType_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisLeavesByAndLeaveType_ID", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                GetHR_EmpRegisLeaveByAndLeaveType_ID = HR_EmpRegisLeaves
            End If
        End If
    End Function

    Public Shared Function TongHopPhepTheo_TheoThoiGian(ByVal dtfromdate As DateTime, ByVal dttodate As DateTime) As HR_EmpRegisLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave, LeaveType_ID from dbo.HR_EmpRegisLeave group by LeaveType_ID, Employee_ID", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisLeaves(table.Rows.Count - 1) As HR_EmpRegisLeave
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisLeaves(i) = New HR_EmpRegisLeave(dr)
                    i += 1
                Next
                TongHopPhepTheo_TheoThoiGian = HR_EmpRegisLeaves
            End If
        End If
    End Function
    Public Shared Function TongHopPhepTheo_TheoThoiGian_ReturnDataTable(ByVal dtfromdate As DateTime, ByVal dttodate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave, LeaveType_ID from dbo.HR_EmpRegisLeave where DateLeave between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' group by LeaveType_ID, Employee_ID", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepTheo_TheoThoiGian_ReturnDataTable = table
            End If
        End If
    End Function
    Public Shared Function TongHopPhepTheo_TheoThoiGian_ReturnDataTable_DOOSUNG(ByVal dtfromdate As DateTime, ByVal dttodate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim str_sql As String = "select emp.Employee_ID, " & _
        "sum(case when LeaveType_ID <> 'NPN' then isnull([HourLeave],0) else case when emp.DepartmentCode = 'OFFICE' then isnull([HourLeave],0) else round(isnull([HourLeave],0)/8,0)*8 end end) as HourLeave, LeaveType_ID " & _
        "from " & _
            "(SELECT [Employee_ID] ,Sum(isnull([HourLeave],0)) AS [HourLeave], LeaveType_ID " & _
            "FROM [dbo].[HR_EmpRegisLeave] " & _
            "WHERE [DateLeave] between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' " & _
            "group by Employee_ID, Month(DateLeave), LeaveType_ID) as TongHopPhepTheoThoiGianDoosung " & _
            "left join dbo.SmartBooks_Employee emp " & _
            "on TongHopPhepTheoThoiGianDoosung.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID " & _
        "group by emp.Employee_ID, LeaveType_ID"
        Dim table As DataTable = kn.ReadData(str_sql, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepTheo_TheoThoiGian_ReturnDataTable_DOOSUNG = table
            End If
        End If
    End Function
    Public Shared Function TongHopPhepTheo_TheoMaNV_TheoThoiGian_ReturnDataTable(ByVal Employee_ID_ As String, ByVal dtfromdate As DateTime, ByVal dttodate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave, LeaveType_ID from dbo.HR_EmpRegisLeave where Employee_ID = '" + Employee_ID_ + "' and DateLeave between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' group by LeaveType_ID, Employee_ID", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepTheo_TheoMaNV_TheoThoiGian_ReturnDataTable = table
            End If
        End If
    End Function
    Public Shared Function TongHopPhepTheo_TheoMaNV_TheoThoiGian_ReturnDataTable_DOOSUNG(ByVal Employee_ID_ As String, ByVal dtfromdate As DateTime, ByVal dttodate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim str_sql As String = "select emp.Employee_ID, " & _
                "sum(case when LeaveType_ID <> 'NPN' then isnull([HourLeave],0) else case when emp.DepartmentCode = 'OFFICE' then isnull([HourLeave],0) else round(isnull([HourLeave],0)/8,0)*8 end end) as HourLeave, LeaveType_ID " & _
                "from " & _
                "(SELECT [Employee_ID] ,Sum(isnull([HourLeave],0)) AS [HourLeave], LeaveType_ID " & _
                "FROM [dbo].[HR_EmpRegisLeave] " & _
                "WHERE [DateLeave] between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' and Employee_ID = '" + Employee_ID_ + "' " & _
                "group by Employee_ID, LeaveType_ID) as TongHopPhepTheoThoiGianDoosung " & _
                "left join (select * from dbo.SmartBooks_Employee where Employee_ID = '" + Employee_ID_ + "') as emp  " & _
                "on TongHopPhepTheoThoiGianDoosung.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID  " & _
        "group by emp.Employee_ID, LeaveType_ID"
        Dim table As DataTable = kn.ReadData(str_sql, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepTheo_TheoMaNV_TheoThoiGian_ReturnDataTable_DOOSUNG = table
            End If
        End If
    End Function
    'Public Shared Function TongHopPhepNam_ReturnDataTable_DOOSUNG(ByVal Nam As Integer) As DataTable
    '    Dim dtfromdate As DateTime = New DateTime(Nam, 1, 1)
    '    Dim dttodate As DateTime = dtfromdate.AddYears(1).AddDays(-1)
    '    Dim kn As New connect(DbSetting.dataPath)
    '    Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave from dbo.HR_EmpRegisLeave where LeaveType_ID COLLATE DATABASE_DEFAULT in (select [ID] from dbo.SmartBooks_LeaveType where PhepNam = '1') and DateLeave between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' group by LeaveType_ID, Employee_ID", "table")
    '    If Not IsNothing(table) Then
    '        If table.Rows.Count > 0 Then
    '            TongHopPhepNam_ReturnDataTable_DOOSUNG = table
    '        End If
    '    End If
    'End Function
    Public Shared Function TongHopPhepNam_ReturnDataTable(ByVal Nam As Integer) As DataTable
        Dim dtfromdate As DateTime = New DateTime(Nam, 1, 1)
        Dim dttodate As DateTime = dtfromdate.AddYears(1).AddDays(-1)
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave from dbo.HR_EmpRegisLeave where LeaveType_ID COLLATE DATABASE_DEFAULT in (select [ID] from dbo.SmartBooks_LeaveType where PhepNam = '1') and DateLeave between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' group by LeaveType_ID, Employee_ID", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepNam_ReturnDataTable = table
            End If
        End If
    End Function

    Public Shared Function TongHopPhepNam_ReturnDataTable(ByVal Nam As Integer, ByVal Thang As Integer) As DataTable
        Dim dtfromdate As DateTime = New DateTime(Nam, 1, 1)
        Dim dttodate As DateTime = New DateTime(Nam, Thang, 1).AddMonths(1).AddDays(-1)
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave from dbo.HR_EmpRegisLeave where LeaveType_ID COLLATE DATABASE_DEFAULT in (select [ID] from dbo.SmartBooks_LeaveType where PhepNam = '1') and DateLeave between '" + dtfromdate.Year.ToString + "-" + dtfromdate.Month.ToString + "-" + dtfromdate.Day.ToString + "' and '" + dttodate.Year.ToString + "-" + dttodate.Month.ToString + "-" + dttodate.Day.ToString + "' group by LeaveType_ID, Employee_ID", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepNam_ReturnDataTable = table
            End If
        End If
    End Function

    Public Shared Function TongHopPhepNam_ReturnDataTable_DOOSUNG(ByVal Nam As Integer, ByVal Thang As Integer) As DataTable
        Dim dtfromdate As DateTime = New DateTime(Nam, 1, 1)
        Dim dttodate As DateTime = New DateTime(Nam, Thang, 1).AddMonths(1).AddDays(-1)
        Dim kn As New connect(DbSetting.dataPath)
        Dim str_sql As String
        str_sql = "select emp.Employee_ID, sum(case when emp.DepartmentCode = 'OFFICE' then isnull([HourLeave],0) else round(isnull([HourLeave],0)/8,0)*8 end) as HourLeave " & _
        "FROM " & _
            "(SELECT [Employee_ID] ,Sum(isnull([HourLeave],0)) AS [HourLeave] " & _
            "FROM [dbo].[HR_EmpRegisLeave] " & _
            "WHERE year([DateLeave]) = '" + Nam.ToString + "' and LeaveType_ID COLLATE DATABASE_DEFAULT in (select [ID] from dbo.SmartBooks_LeaveType where PhepNam = '1') and Month(DateLeave)<='" + Thang.ToString + "' " & _
            "group by Employee_ID, Month(DateLeave)) as TongHopPhepNamDoosung " & _
            "left join dbo.SmartBooks_Employee emp " & _
            "on TongHopPhepNamDoosung.Employee_ID COLLATE DATABASE_DEFAULT = emp.Employee_ID " & _
        "group by emp.Employee_ID"
        Dim table As DataTable = kn.ReadData(str_sql, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepNam_ReturnDataTable_DOOSUNG = table
            End If
        End If
    End Function

    Public Shared Function TongHopPhepNam_ReturnDataTable(ByVal fromdate As DateTime, ByVal todate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select Employee_ID, sum(HourLeave) as HourLeave from dbo.HR_EmpRegisLeave where LeaveType_ID COLLATE DATABASE_DEFAULT in (select [ID] from dbo.SmartBooks_LeaveType where PhepNam = '1') and DateLeave between '" + fromdate.Year.ToString + "-" + fromdate.Month.ToString + "-" + fromdate.Day.ToString + "' and '" + todate.Year.ToString + "-" + todate.Month.ToString + "-" + todate.Day.ToString + "' group by LeaveType_ID, Employee_ID", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                TongHopPhepNam_ReturnDataTable = table
            End If
        End If
    End Function

    Public Shared Function GetBangNghiDuocHuongLuong_ReturnDataTable(ByVal fromdate As DateTime, ByVal todate As DateTime) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from dbo.HR_EmpRegisLeave where LeaveType_ID COLLATE DATABASE_DEFAULT in (select [ID] from dbo.SmartBooks_LeaveType where isLeave_ComPay = '1') and DateLeave between '" + fromdate.Year.ToString + "-" + fromdate.Month.ToString + "-" + fromdate.Day.ToString + "' and '" + todate.Year.ToString + "-" + todate.Month.ToString + "-" + todate.Day.ToString + "'", "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                GetBangNghiDuocHuongLuong_ReturnDataTable = table
            End If
        End If
    End Function

    Public Shared Function DeleteHR_EmpRegisLeaveByAndLeaveType_ID(ByVal LeaveType_ID As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@LeaveType_ID"}
        Dim oj() As Object = {LeaveType_ID}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmpRegisLeavesByAndLeaveType_ID", name, oj, tp)
    End Function


    Public Shared Function Search(ByVal erl() As HR_EmpRegisLeave, ByVal Employee_ID As String, ByVal DateLeave As DateTime) As HR_EmpRegisLeave()
        Dim arl As New ArrayList
        For Each HR_EmpRegisLeave1 As HR_EmpRegisLeave In erl
            If HR_EmpRegisLeave1.Employee_ID = Employee_ID And HR_EmpRegisLeave1.DateLeave = DateLeave Then
                arl.Add(HR_EmpRegisLeave1)
            End If
        Next
        Dim HR_EmpRegisLeave_Return(arl.Count - 1) As HR_EmpRegisLeave
        For i As Integer = 0 To arl.Count - 1
            HR_EmpRegisLeave_Return(i) = arl(i)
        Next
        Return HR_EmpRegisLeave_Return
    End Function

    Public Shared Function Search(ByVal erl() As HR_EmpRegisLeave, ByVal Employee_ID As String) As HR_EmpRegisLeave()
        Dim arl As New ArrayList
        For Each HR_EmpRegisLeave1 As HR_EmpRegisLeave In erl
            If HR_EmpRegisLeave1.Employee_ID = Employee_ID Then
                arl.Add(HR_EmpRegisLeave1)
            End If
        Next
        Dim HR_EmpRegisLeave_Return(arl.Count - 1) As HR_EmpRegisLeave
        For i As Integer = 0 To arl.Count - 1
            HR_EmpRegisLeave_Return(i) = arl(i)
        Next
        Return HR_EmpRegisLeave_Return
    End Function

End Class
#End Region