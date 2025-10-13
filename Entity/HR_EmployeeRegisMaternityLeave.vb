Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_EmployeeRegisMaternityLeave"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_EmployeeRegisMaternityLeave.
    ''' </summary>
    Public Class HR_EmployeeRegisMaternityLeave
        Private _iD As System.Int32
        Private _employee_ID As System.String = String.Empty
        Private _fromdate As System.DateTime
        Private _toDate As System.DateTime
        Private _content As System.String = String.Empty
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal ID As System.Int32)
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"Int"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeave", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _iD = ID
            End If
        Else
            _iD = ID
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("ID")) Then
                    _iD = _datarow("ID")
                End If
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("Fromdate")) Then
                    _fromdate = _datarow("Fromdate")
                End If
                If Not IsDBNull(_datarow("ToDate")) Then
                    _toDate = _datarow("ToDate")
                End If
                If Not IsDBNull(_datarow("Content")) Then
                    _content = _datarow("Content")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("ID")) Then
                    _iD = _datarow("ID")
                End If
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("Fromdate")) Then
                    _fromdate = _datarow("Fromdate")
                End If
                If Not IsDBNull(_datarow("ToDate")) Then
                    _toDate = _datarow("ToDate")
                End If
                If Not IsDBNull(_datarow("Content")) Then
                    _content = _datarow("Content")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"Int"}
            kn.ExecStore("dbo.usp_DeleteHR_EmployeeRegisMaternityLeave", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@Employee_ID", "@Fromdate", "@ToDate", "@Content"}
            Dim oj() As Object = {Employee_ID, Fromdate, ToDate, Content}
            Dim tp() As String = {"NVarChar", "DateTime", "DateTime", "NVarChar"}
            kn.ExecStore("dbo.usp_UpdateHR_EmployeeRegisMaternityLeave", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@Employee_ID", "@Fromdate", "@ToDate", "@Content"}
            Dim oj() As Object = {Employee_ID, Fromdate, ToDate, Content}
            Dim tp() As String = {"NVarChar", "DateTime", "DateTime", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertHR_EmployeeRegisMaternityLeave", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@Employee_ID", "@Fromdate", "@ToDate", "@Content"}
            Dim oj() As Object = {Employee_ID, Fromdate, ToDate, Content}
            Dim tp() As String = {"NVarChar", "DateTime", "DateTime", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_EmployeeRegisMaternityLeave", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __Employee_ID As String
            Dim __Fromdate As String
            Dim __ToDate As String
            Dim __Content As String
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            If Fromdate <> DateTime.MinValue Then
                __Fromdate = "'" + kn.DateTimeToString(Fromdate) + "'"
            Else
                __Fromdate = "null"
            End If
            If ToDate <> DateTime.MinValue Then
                __ToDate = "'" + kn.DateTimeToString(ToDate) + "'"
            Else
                __ToDate = "null"
            End If
            If Content <> String.Empty Then
                __Content = "N'" + Content + "'"
            Else
                __Content = "null"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [HR_EmployeeRegisMaternityLeave]([Employee_ID],[Fromdate],[ToDate],[Content])VALUES(" & _
            __Employee_ID + "," + __Fromdate + "," + __ToDate + "," + __Content + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __ID As String
            Dim __Employee_ID As String
            Dim __Fromdate As String
            Dim __ToDate As String
            Dim __Content As String
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            If Fromdate <> DateTime.MinValue Then
                __Fromdate = "'" + kn.DateTimeToString(Fromdate) + "'"
            Else
                __Fromdate = "null"
            End If
            If ToDate <> DateTime.MinValue Then
                __ToDate = "'" + kn.DateTimeToString(ToDate) + "'"
            Else
                __ToDate = "null"
            End If
            If Content <> String.Empty Then
                __Content = "N'" + Content + "'"
            Else
                __Content = "null"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [HR_EmployeeRegisMaternityLeave] SET [Employee_ID]=" + __Employee_ID + ",[Fromdate]=" + __Fromdate + ",[ToDate]=" + __ToDate + ",[Content]=" + __Content + " WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __ID As String
            __ID = "'" + ID.tostring + "'"
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_EmployeeRegisMaternityLeave] WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Shared Function NewHR_EmployeeRegisMaternityLeave(ByVal ID As System.Int32) As HR_EmployeeRegisMaternityLeave
            Dim newEntity As New HR_EmployeeRegisMaternityLeave
            newEntity._iD = ID
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property ID() As System.Int32
            Get
                Return _iD
            End Get
            Set(ByVal value As System.Int32)
                _iD = value
            End Set
        End Property

        Public Property Employee_ID() As System.String
            Get
                Return _employee_ID
            End Get
            Set(ByVal value As System.String)
                _employee_ID = value
            End Set
        End Property

        Public Property Fromdate() As System.DateTime
            Get
                Return _fromdate
            End Get
            Set(ByVal value As System.DateTime)
                _fromdate = value
            End Set
        End Property

        Public Property ToDate() As System.DateTime
            Get
                Return _toDate
            End Get
            Set(ByVal value As System.DateTime)
                _toDate = value
            End Set
        End Property

        Public Property Content() As System.String
            Get
                Return _content
            End Get
            Set(ByVal value As System.String)
                _content = value
            End Set
        End Property

#End Region

        Public Shared Function GetHR_EmployeeRegisMaternityLeave(ByVal ID As System.Int32) As HR_EmployeeRegisMaternityLeave
            Return New HR_EmployeeRegisMaternityLeave(ID)
        End Function

        Public Shared Function GetHR_EmployeeRegisMaternityLeaveAll() As HR_EmployeeRegisMaternityLeave()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM HR_EmployeeRegisMaternityLeave", "HR_EmployeeRegisMaternityLeave")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmployeeRegisMaternityLeaves(table.Rows.Count - 1) As HR_EmployeeRegisMaternityLeave
                For Each dr As DataRow In table.Rows
                    HR_EmployeeRegisMaternityLeaves(i) = New HR_EmployeeRegisMaternityLeave(dr)
                    i += 1
                Next
                GetHR_EmployeeRegisMaternityLeaveAll = HR_EmployeeRegisMaternityLeaves
            End If
        End If
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM HR_EmployeeRegisMaternityLeave", "HR_EmployeeRegisMaternityLeave")
        Return table
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_EmployeeRegisMaternityLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeavesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmployeeRegisMaternityLeaves(table.Rows.Count - 1) As HR_EmployeeRegisMaternityLeave
                For Each dr As DataRow In table.Rows
                    HR_EmployeeRegisMaternityLeaves(i) = New HR_EmployeeRegisMaternityLeave(dr)
                    i += 1
                Next
                GetHR_EmployeeRegisMaternityLeaveDynamic = HR_EmployeeRegisMaternityLeaves
            End If
        End If
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeavesDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveDynamic(ByVal WhereCondition As String) As HR_EmployeeRegisMaternityLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeavesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmployeeRegisMaternityLeaves(table.Rows.Count - 1) As HR_EmployeeRegisMaternityLeave
                For Each dr As DataRow In table.Rows
                    HR_EmployeeRegisMaternityLeaves(i) = New HR_EmployeeRegisMaternityLeave(dr)
                    i += 1
                Next
                GetHR_EmployeeRegisMaternityLeaveDynamic = HR_EmployeeRegisMaternityLeaves
            End If
        End If
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeavesDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveFullDynamic(ByVal BeforeTableNameSQL As String, ByVal AfterTableNameSQL As String) As HR_EmployeeRegisMaternityLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT" + BeforeTableNameSQL + " FROM HR_EmployeeRegisMaternityLeave " + AfterTableNameSQL, "HR_EmployeeRegisMaternityLeave")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmployeeRegisMaternityLeaves(table.Rows.Count - 1) As HR_EmployeeRegisMaternityLeave
                For Each dr As DataRow In table.Rows
                    HR_EmployeeRegisMaternityLeaves(i) = New HR_EmployeeRegisMaternityLeave(dr)
                    i += 1
                Next
                GetHR_EmployeeRegisMaternityLeaveFullDynamic = HR_EmployeeRegisMaternityLeaves
            End If
        End If
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveFullDynamicReturnDataTable(ByVal BeforeTableNameSQL As String, ByVal AfterTableNameSQL As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT" + BeforeTableNameSQL + " FROM HR_EmployeeRegisMaternityLeave " + AfterTableNameSQL, "HR_EmployeeRegisMaternityLeave")
        Return table
    End Function

    Public Shared Function DeleteHR_EmployeeRegisMaternityLeavesDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmployeeRegisMaternityLeavesDynamic", name, oj, tp)
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveByAndEmployee_ID(ByVal Employee_ID As System.String) As HR_EmployeeRegisMaternityLeave()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeavesByAndEmployee_ID", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmployeeRegisMaternityLeaves(table.Rows.Count - 1) As HR_EmployeeRegisMaternityLeave
                For Each dr As DataRow In table.Rows
                    HR_EmployeeRegisMaternityLeaves(i) = New HR_EmployeeRegisMaternityLeave(dr)
                    i += 1
                Next
                GetHR_EmployeeRegisMaternityLeaveByAndEmployee_ID = HR_EmployeeRegisMaternityLeaves
            End If
        End If
    End Function

    Public Shared Function DeleteHR_EmployeeRegisMaternityLeaveByAndEmployee_ID(ByVal Employee_ID As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmployeeRegisMaternityLeavesByAndEmployee_ID", name, oj, tp)
    End Function

    Public Shared Function GetHR_EmployeeRegisMaternityLeaveByAndEmployee_IDReturnDataTable(ByVal Employee_ID As System.String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmployeeRegisMaternityLeavesByAndEmployee_ID", name, oj, tp)
        Return table
    End Function

    Public Shared Function Search(ByVal list() As HR_EmployeeRegisMaternityLeave, ByVal ID As System.Int32) As HR_EmployeeRegisMaternityLeave
        For Each HR_EmployeeRegisMaternityLeave1 As HR_EmployeeRegisMaternityLeave In list
            If HR_EmployeeRegisMaternityLeave1.ID = ID Then
                Return HR_EmployeeRegisMaternityLeave1
            End If
        Next
    End Function

    Public Shared Function Search(ByVal list() As HR_EmployeeRegisMaternityLeave, ByVal Employee_ID As System.String) As HR_EmployeeRegisMaternityLeave()
        Dim arl As New ArrayList
        For Each HR_EmployeeRegisMaternityLeave1 As HR_EmployeeRegisMaternityLeave In list
            If HR_EmployeeRegisMaternityLeave1.Employee_ID = Employee_ID Then
                arl.Add(HR_EmployeeRegisMaternityLeave1)
            End If
        Next
        Dim HR_EmployeeRegisMaternityLeave_Return(arl.Count - 1) As HR_EmployeeRegisMaternityLeave
        For i As Integer = 0 To arl.Count - 1
            HR_EmployeeRegisMaternityLeave_Return(i) = arl(i)
        Next
        Return HR_EmployeeRegisMaternityLeave_Return
    End Function
End Class
#End Region