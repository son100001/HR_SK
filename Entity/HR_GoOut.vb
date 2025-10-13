Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_GoOut"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_GoOut.
    ''' </summary>
    Public Class HR_GoOut
        Private _iD As System.Int64
        Private _employee_ID As System.String = String.Empty
        Private _timeDate As System.DateTime
        Private _ca As System.String = String.Empty
        Private _timeOut As System.DateTime
        Private _timeIn As System.DateTime
        Private _hours As System.Double
        Private _place As System.String = String.Empty
        Private _reason As System.String = String.Empty
        Private _insertBy As System.String = String.Empty
        Private _insertDate As System.DateTime
        Private _updateBy As System.String = String.Empty
        Private _updateDate As System.DateTime
        Private _status As System.Boolean
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal ID As System.Int64)
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"BigInt"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOut", name, oj, tp)
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
                If Not IsDBNull(_datarow("TimeDate")) Then
                    _timeDate = _datarow("TimeDate")
                End If
                If Not IsDBNull(_datarow("Ca")) Then
                    _ca = _datarow("Ca")
                End If
                If Not IsDBNull(_datarow("TimeOut")) Then
                    _timeOut = _datarow("TimeOut")
                End If
                If Not IsDBNull(_datarow("TimeIn")) Then
                    _timeIn = _datarow("TimeIn")
                End If
                If Not IsDBNull(_datarow("Hours")) Then
                    _hours = _datarow("Hours")
                End If
                If Not IsDBNull(_datarow("Place")) Then
                    _place = _datarow("Place")
                End If
                If Not IsDBNull(_datarow("Reason")) Then
                    _reason = _datarow("Reason")
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
                If Not IsDBNull(_datarow("Status")) Then
                    _status = _datarow("Status")
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
                If Not IsDBNull(_datarow("TimeDate")) Then
                    _timeDate = _datarow("TimeDate")
                End If
                If Not IsDBNull(_datarow("Ca")) Then
                    _ca = _datarow("Ca")
                End If
                If Not IsDBNull(_datarow("TimeOut")) Then
                    _timeOut = _datarow("TimeOut")
                End If
                If Not IsDBNull(_datarow("TimeIn")) Then
                    _timeIn = _datarow("TimeIn")
                End If
                If Not IsDBNull(_datarow("Hours")) Then
                    _hours = _datarow("Hours")
                End If
                If Not IsDBNull(_datarow("Place")) Then
                    _place = _datarow("Place")
                End If
                If Not IsDBNull(_datarow("Reason")) Then
                    _reason = _datarow("Reason")
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
                If Not IsDBNull(_datarow("Status")) Then
                    _status = _datarow("Status")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"BigInt"}
            kn.ExecStore("dbo.usp_DeleteHR_GoOut", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@ID", "@Employee_ID", "@TimeDate", "@Ca", "@TimeOut", "@TimeIn", "@Hours", "@Place", "@Reason", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate", "@Status"}
            Dim oj() As Object = {ID, Employee_ID, TimeDate, Ca, TimeOut, TimeIn, Hours, Place, Reason, InsertBy, InsertDate, UpdateBy, UpdateDate, Status}
            Dim tp() As String = {"BigInt", "NVarChar", "DateTime", "NVarChar", "DateTime", "DateTime", "Float", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime", "Bit"}
            kn.ExecStore("dbo.usp_UpdateHR_GoOut", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@ID", "@Employee_ID", "@TimeDate", "@Ca", "@TimeOut", "@TimeIn", "@Hours", "@Place", "@Reason", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate", "@Status"}
            Dim oj() As Object = {ID, Employee_ID, TimeDate, Ca, TimeOut, TimeIn, Hours, Place, Reason, InsertBy, InsertDate, UpdateBy, UpdateDate, Status}
            Dim tp() As String = {"BigInt", "NVarChar", "DateTime", "NVarChar", "DateTime", "DateTime", "Float", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime", "Bit"}
            kn.ExecStore("dbo.usp_InsertHR_GoOut", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@ID", "@Employee_ID", "@TimeDate", "@Ca", "@TimeOut", "@TimeIn", "@Hours", "@Place", "@Reason", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate", "@Status"}
            Dim oj() As Object = {ID, Employee_ID, TimeDate, Ca, TimeOut, TimeIn, Hours, Place, Reason, InsertBy, InsertDate, UpdateBy, UpdateDate, Status}
            Dim tp() As String = {"BigInt", "NVarChar", "DateTime", "NVarChar", "DateTime", "DateTime", "Float", "NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "DateTime", "Bit"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_GoOut", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __ID As String
            Dim __Employee_ID As String
            Dim __TimeDate As String
            Dim __Ca As String
            Dim __TimeOut As String
            Dim __TimeIn As String
            Dim __Hours As String
            Dim __Place As String
            Dim __Reason As String
            Dim __InsertBy As String
            Dim __InsertDate As String
            Dim __UpdateBy As String
            Dim __UpdateDate As String
            Dim __Status As String
            __ID = "'" + ID + "'"
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            If TimeDate <> DateTime.MinValue Then
                __TimeDate = "'" + kn.DateTimeToString(TimeDate) + "'"
            Else
                __TimeDate = "null"
            End If
            If Ca <> String.Empty Then
                __Ca = "N'" + Ca + "'"
            Else
                __Ca = "null"
            End If
            If TimeOut <> DateTime.MinValue Then
                __TimeOut = "'" + kn.DateTimeToString(TimeOut) + "'"
            Else
                __TimeOut = "null"
            End If
            If TimeIn <> DateTime.MinValue Then
                __TimeIn = "'" + kn.DateTimeToString(TimeIn) + "'"
            Else
                __TimeIn = "null"
            End If
            __Hours = "'" + Hours.tostring + "'"
            If Place <> String.Empty Then
                __Place = "N'" + Place + "'"
            Else
                __Place = "null"
            End If
            If Reason <> String.Empty Then
                __Reason = "N'" + Reason + "'"
            Else
                __Reason = "null"
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
            If Status = True Then
                _Status = "'1'"
            Else
                __Status = "'0'"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [HR_GoOut]([ID],[Employee_ID],[TimeDate],[Ca],[TimeOut],[TimeIn],[Hours],[Place],[Reason],[InsertBy],[InsertDate],[UpdateBy],[UpdateDate],[Status])VALUES(" & _
            __ID + "," + __Employee_ID + "," + __TimeDate + "," + __Ca + "," + __TimeOut + "," + __TimeIn + "," + __Hours + "," + __Place + "," + __Reason + "," + __InsertBy + "," + __InsertDate + "," + __UpdateBy + "," + __UpdateDate + "," + __Status + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __ID As String
            Dim __Employee_ID As String
            Dim __TimeDate As String
            Dim __Ca As String
            Dim __TimeOut As String
            Dim __TimeIn As String
            Dim __Hours As String
            Dim __Place As String
            Dim __Reason As String
            Dim __InsertBy As String
            Dim __InsertDate As String
            Dim __UpdateBy As String
            Dim __UpdateDate As String
            Dim __Status As String
            __ID = "'" + ID + "'"
            If Employee_ID <> String.Empty Then
                __Employee_ID = "N'" + Employee_ID + "'"
            Else
                __Employee_ID = "null"
            End If
            If TimeDate <> DateTime.MinValue Then
                __TimeDate = "'" + kn.DateTimeToString(TimeDate) + "'"
            Else
                __TimeDate = "null"
            End If
            If Ca <> String.Empty Then
                __Ca = "N'" + Ca + "'"
            Else
                __Ca = "null"
            End If
            If TimeOut <> DateTime.MinValue Then
                __TimeOut = "'" + kn.DateTimeToString(TimeOut) + "'"
            Else
                __TimeOut = "null"
            End If
            If TimeIn <> DateTime.MinValue Then
                __TimeIn = "'" + kn.DateTimeToString(TimeIn) + "'"
            Else
                __TimeIn = "null"
            End If
            __Hours = "'" + Hours.tostring + "'"
            If Place <> String.Empty Then
                __Place = "N'" + Place + "'"
            Else
                __Place = "null"
            End If
            If Reason <> String.Empty Then
                __Reason = "N'" + Reason + "'"
            Else
                __Reason = "null"
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
            If Status = True Then
                _Status = "'1'"
            Else
                __Status = "'0'"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [HR_GoOut] SET [ID]=" + __ID + ",[Employee_ID]=" + __Employee_ID + ",[TimeDate]=" + __TimeDate + ",[Ca]=" + __Ca + ",[TimeOut]=" + __TimeOut + ",[TimeIn]=" + __TimeIn + ",[Hours]=" + __Hours + ",[Place]=" + __Place + ",[Reason]=" + __Reason + ",[InsertBy]=" + __InsertBy + ",[InsertDate]=" + __InsertDate + ",[UpdateBy]=" + __UpdateBy + ",[UpdateDate]=" + __UpdateDate + ",[Status]=" + __Status + " WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __ID As String
            __ID = "'" + ID + "'"
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_GoOut] WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Shared Function NewHR_GoOut(ByVal ID As System.Int64) As HR_GoOut
            Dim newEntity As New HR_GoOut
            newEntity._iD = ID
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property ID() As System.Int64
            Get
                Return _iD
            End Get
            Set(ByVal value As System.Int64)
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

        Public Property TimeDate() As System.DateTime
            Get
                Return _timeDate
            End Get
            Set(ByVal value As System.DateTime)
                _timeDate = value
            End Set
        End Property

        Public Property Ca() As System.String
            Get
                Return _ca
            End Get
            Set(ByVal value As System.String)
                _ca = value
            End Set
        End Property

        Public Property TimeOut() As System.DateTime
            Get
                Return _timeOut
            End Get
            Set(ByVal value As System.DateTime)
                _timeOut = value
            End Set
        End Property

        Public Property TimeIn() As System.DateTime
            Get
                Return _timeIn
            End Get
            Set(ByVal value As System.DateTime)
                _timeIn = value
            End Set
        End Property

        Public Property Hours() As System.Double
            Get
                Return _hours
            End Get
            Set(ByVal value As System.Double)
                _hours = value
            End Set
        End Property

        Public Property Place() As System.String
            Get
                Return _place
            End Get
            Set(ByVal value As System.String)
                _place = value
            End Set
        End Property

        Public Property Reason() As System.String
            Get
                Return _reason
            End Get
            Set(ByVal value As System.String)
                _reason = value
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

        Public Property Status() As System.Boolean
            Get
                Return _status
            End Get
            Set(ByVal value As System.Boolean)
                _status = value
            End Set
        End Property

#End Region

        Public Shared Function GetHR_GoOut(ByVal ID As System.Int64) As HR_GoOut
            Return New HR_GoOut(ID)
        End Function

        Public Shared Function GetHR_GoOutAll() As HR_GoOut()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM HR_GoOut", "HR_GoOut")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_GoOuts(table.Rows.Count - 1) As HR_GoOut
                For Each dr As DataRow In table.Rows
                    HR_GoOuts(i) = New HR_GoOut(dr)
                    i += 1
                Next
                GetHR_GoOutAll = HR_GoOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_GoOutAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM HR_GoOut", "HR_GoOut")
        Return table
    End Function

    Public Shared Function GetHR_GoOutDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_GoOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOutsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_GoOuts(table.Rows.Count - 1) As HR_GoOut
                For Each dr As DataRow In table.Rows
                    HR_GoOuts(i) = New HR_GoOut(dr)
                    i += 1
                Next
                GetHR_GoOutDynamic = HR_GoOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_GoOutDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOutsDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_GoOutDynamic(ByVal WhereCondition As String) As HR_GoOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOutsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_GoOuts(table.Rows.Count - 1) As HR_GoOut
                For Each dr As DataRow In table.Rows
                    HR_GoOuts(i) = New HR_GoOut(dr)
                    i += 1
                Next
                GetHR_GoOutDynamic = HR_GoOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_GoOutDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOutsDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_GoOutFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As HR_GoOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_GoOut where " + sqlAfterWhere, "HR_GoOut")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_GoOuts(table.Rows.Count - 1) As HR_GoOut
                For Each dr As DataRow In table.Rows
                    HR_GoOuts(i) = New HR_GoOut(dr)
                    i += 1
                Next
                GetHR_GoOutFullDynamic = HR_GoOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_GoOutFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_GoOut where " + sqlAfterWhere, "HR_GoOut")
        Return table
    End Function

    Public Shared Function DeleteHR_GoOutsDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_GoOutsDynamic", name, oj, tp)
    End Function

    Public Shared Function GetHR_GoOutByAndEmployee_ID(ByVal Employee_ID As System.String) As HR_GoOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOutsByAndEmployee_ID", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_GoOuts(table.Rows.Count - 1) As HR_GoOut
                For Each dr As DataRow In table.Rows
                    HR_GoOuts(i) = New HR_GoOut(dr)
                    i += 1
                Next
                GetHR_GoOutByAndEmployee_ID = HR_GoOuts
            End If
        End If
    End Function

    Public Shared Function DeleteHR_GoOutByAndEmployee_ID(ByVal Employee_ID As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_GoOutsByAndEmployee_ID", name, oj, tp)
    End Function

    Public Shared Function GetHR_GoOutByAndCa(ByVal Ca As System.String) As HR_GoOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Ca"}
        Dim oj() As Object = {Ca}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_GoOutsByAndCa", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_GoOuts(table.Rows.Count - 1) As HR_GoOut
                For Each dr As DataRow In table.Rows
                    HR_GoOuts(i) = New HR_GoOut(dr)
                    i += 1
                Next
                GetHR_GoOutByAndCa = HR_GoOuts
            End If
        End If
    End Function

    Public Shared Function DeleteHR_GoOutByAndCa(ByVal Ca As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Ca"}
        Dim oj() As Object = {Ca}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_GoOutsByAndCa", name, oj, tp)
    End Function

    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As HR_GoOut, ByVal ID As System.Int64) As HR_GoOut
        For Each HR_GoOut1 As HR_GoOut In list
            If HR_GoOut1.ID = ID Then
                Return HR_GoOut1
            End If
        Next
    End Function

    Public Shared Function SearchFromListFollowEmployee_ID(ByVal list() As HR_GoOut, ByVal Employee_ID As System.String) As HR_GoOut()
        Dim arl As New ArrayList
        For Each HR_GoOut1 As HR_GoOut In list
            If HR_GoOut1.Employee_ID = Employee_ID Then
                arl.Add(HR_GoOut1)
            End If
        Next
        Dim HR_GoOut_Return(arl.Count - 1) As HR_GoOut
        For i As Integer = 0 To arl.Count - 1
            HR_GoOut_Return(i) = arl(i)
        Next
        Return HR_GoOut_Return
    End Function

    Public Shared Function SearchFromListFollowCa(ByVal list() As HR_GoOut, ByVal Ca As System.String) As HR_GoOut()
        Dim arl As New ArrayList
        For Each HR_GoOut1 As HR_GoOut In list
            If HR_GoOut1.Ca = Ca Then
                arl.Add(HR_GoOut1)
            End If
        Next
        Dim HR_GoOut_Return(arl.Count - 1) As HR_GoOut
        For i As Integer = 0 To arl.Count - 1
            HR_GoOut_Return(i) = arl(i)
        Next
        Return HR_GoOut_Return
    End Function
End Class
#End Region