Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_TimeIn_TimeOut"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_TimeIn_TimeOut.
    ''' </summary>
    Public Class HR_TimeIn_TimeOut
        Private _timeKeeping_Data_ID As System.Int32
        Private _oT_date As System.DateTime
        Private _employee_ID As System.String = String.Empty
        Private _timeIn As System.DateTime
        Private _timeOut As System.DateTime
        Private _lateIn As System.Double
        Private _earlyOut As System.Double
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal OT_date As System.DateTime, ByVal Employee_ID As System.String)
            Dim name() As String = {"@OT_date", "@Employee_ID"}
            Dim oj() As Object = {OT_date, Employee_ID}
            Dim tp() As String = {"DateTime", "NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_TimeIn_TimeOut", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _oT_date = OT_date
                _employee_ID = Employee_ID
            End If
        Else
            _oT_date = OT_date
            _employee_ID = Employee_ID
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("TimeKeeping_Data_ID")) Then
                    _timeKeeping_Data_ID = _datarow("TimeKeeping_Data_ID")
                End If
                If Not IsDBNull(_datarow("OT_date")) Then
                    _oT_date = _datarow("OT_date")
                End If
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("TimeIn")) Then
                    _timeIn = _datarow("TimeIn")
                End If
                If Not IsDBNull(_datarow("TimeOut")) Then
                    _timeOut = _datarow("TimeOut")
                End If
                If Not IsDBNull(_datarow("LateIn")) Then
                    _lateIn = _datarow("LateIn")
                End If
                If Not IsDBNull(_datarow("EarlyOut")) Then
                    _earlyOut = _datarow("EarlyOut")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("TimeKeeping_Data_ID")) Then
                    _timeKeeping_Data_ID = _datarow("TimeKeeping_Data_ID")
                End If
                If Not IsDBNull(_datarow("OT_date")) Then
                    _oT_date = _datarow("OT_date")
                End If
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("TimeIn")) Then
                    _timeIn = _datarow("TimeIn")
                End If
                If Not IsDBNull(_datarow("TimeOut")) Then
                    _timeOut = _datarow("TimeOut")
                End If
                If Not IsDBNull(_datarow("LateIn")) Then
                    _lateIn = _datarow("LateIn")
                End If
                If Not IsDBNull(_datarow("EarlyOut")) Then
                    _earlyOut = _datarow("EarlyOut")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@OT_date", "@Employee_ID"}
            Dim oj() As Object = {OT_date, Employee_ID}
            Dim tp() As String = {"DateTime", "NVarChar"}
            kn.ExecStore("dbo.usp_DeleteHR_TimeIn_TimeOut", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@OT_date", "@Employee_ID", "@TimeIn", "@TimeOut", "@LateIn", "@EarlyOut"}
            Dim oj() As Object = {OT_date, Employee_ID, TimeIn, TimeOut, LateIn, EarlyOut}
            Dim tp() As String = {"DateTime", "NVarChar", "DateTime", "DateTime", "Float", "Float"}
            kn.ExecStore("dbo.usp_UpdateHR_TimeIn_TimeOut", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@OT_date", "@Employee_ID", "@TimeIn", "@TimeOut", "@LateIn", "@EarlyOut"}
            Dim oj() As Object = {OT_date, Employee_ID, TimeIn, TimeOut, LateIn, EarlyOut}
            Dim tp() As String = {"DateTime", "NVarChar", "DateTime", "DateTime", "Float", "Float"}
            kn.ExecStore("dbo.usp_InsertHR_TimeIn_TimeOut", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@OT_date", "@Employee_ID", "@TimeIn", "@TimeOut", "@LateIn", "@EarlyOut"}
            Dim oj() As Object = {OT_date, Employee_ID, TimeIn, TimeOut, LateIn, EarlyOut}
            Dim tp() As String = {"DateTime", "NVarChar", "DateTime", "DateTime", "Float", "Float"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_TimeIn_TimeOut", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim _OT_date As String
            Dim _Employee_ID As String
            Dim _TimeIn As String
            Dim _TimeOut As String
            Dim _LateIn As String
            Dim _EarlyOut As String
            If OT_date <> DateTime.MinValue Then
                _OT_date = "N'" + kn.DateTimeToString(OT_date) + "'"
            Else
                _OT_date = "null"
            End If
            If Employee_ID <> String.Empty Then
                _Employee_ID = "N'" + Employee_ID + "'"
            Else
                _Employee_ID = "null"
            End If
            If TimeIn <> DateTime.MinValue Then
                _TimeIn = "N'" + kn.DateTimeToString(TimeIn) + "'"
            Else
                _TimeIn = "null"
            End If
            If TimeOut <> DateTime.MinValue Then
                _TimeOut = "N'" + kn.DateTimeToString(TimeOut) + "'"
            Else
                _TimeOut = "null"
            End If
            _LateIn = "'" + LateIn.tostring + "'"
            _EarlyOut = "'" + EarlyOut.tostring + "'"
            Dim sql As String = String.Empty
            sql = "INSERT INTO [HR_TimeIn_TimeOut]([OT_date],[Employee_ID],[TimeIn],[TimeOut],[LateIn],[EarlyOut])VALUES(" & _
            _OT_date + "," + _Employee_ID + "," + _TimeIn + "," + _TimeOut + "," + _LateIn + "," + _EarlyOut + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim _OT_date As String
            Dim _Employee_ID As String
            Dim _TimeIn As String
            Dim _TimeOut As String
            Dim _LateIn As String
            Dim _EarlyOut As String
            If OT_date <> DateTime.MinValue Then
                _OT_date = "N'" + kn.DateTimeToString(OT_date) + "'"
            Else
                _OT_date = "null"
            End If
            If Employee_ID <> String.Empty Then
                _Employee_ID = "N'" + Employee_ID + "'"
            Else
                _Employee_ID = "null"
            End If
            If TimeIn <> DateTime.MinValue Then
                _TimeIn = "N'" + kn.DateTimeToString(TimeIn) + "'"
            Else
                _TimeIn = "null"
            End If
            If TimeOut <> DateTime.MinValue Then
                _TimeOut = "N'" + kn.DateTimeToString(TimeOut) + "'"
            Else
                _TimeOut = "null"
            End If
            _LateIn = "'" + LateIn.tostring + "'"
            _EarlyOut = "'" + EarlyOut.tostring + "'"
            Dim sql As String = String.Empty
            sql = "UPDATE [HR_TimeIn_TimeOut] SET [OT_date]=" + _OT_date + ",[Employee_ID]=" + _Employee_ID + ",[TimeIn]=" + _TimeIn + ",[TimeOut]=" + _TimeOut + ",[LateIn]=" + _LateIn + ",[EarlyOut]=" + _EarlyOut + " WHERE [OT_date]=" + _OT_date + " and [Employee_ID]=" + _Employee_ID
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_TimeIn_TimeOut] WHERE [OT_date]=" + _OT_date + " and [Employee_ID]=" + _Employee_ID
            Return sql
        End Function

        Public Shared Function NewHR_TimeIn_TimeOut(ByVal OT_date As System.DateTime, ByVal Employee_ID As System.String) As HR_TimeIn_TimeOut
            Dim newEntity As New HR_TimeIn_TimeOut
            newEntity._oT_date = OT_date
            newEntity._employee_ID = Employee_ID
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property TimeKeeping_Data_ID() As System.Int32
            Get
                Return _timeKeeping_Data_ID
            End Get
            Set(ByVal value As System.Int32)
                _timeKeeping_Data_ID = value
            End Set
        End Property

        Public Property OT_date() As System.DateTime
            Get
                Return _oT_date
            End Get
            Set(ByVal value As System.DateTime)
                _oT_date = value
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

        Public Property TimeIn() As System.DateTime
            Get
                Return _timeIn
            End Get
            Set(ByVal value As System.DateTime)
                _timeIn = value
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

        Public Property LateIn() As System.Double
            Get
                Return _lateIn
            End Get
            Set(ByVal value As System.Double)
                _lateIn = value
            End Set
        End Property

        Public Property EarlyOut() As System.Double
            Get
                Return _earlyOut
            End Get
            Set(ByVal value As System.Double)
                _earlyOut = value
            End Set
        End Property

#End Region

        Public Shared Function GetHR_TimeIn_TimeOut(ByVal OT_date As System.DateTime, ByVal Employee_ID As System.String) As HR_TimeIn_TimeOut
            Return New HR_TimeIn_TimeOut(OT_date, Employee_ID)
        End Function

        Public Shared Function GetHR_TimeIn_TimeOutAll() As HR_TimeIn_TimeOut()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM HR_TimeIn_TimeOut", "abc")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TimeIn_TimeOuts(table.Rows.Count - 1) As HR_TimeIn_TimeOut
                For Each dr As DataRow In table.Rows
                    HR_TimeIn_TimeOuts(i) = New HR_TimeIn_TimeOut(dr)
                    i += 1
                Next
                GetHR_TimeIn_TimeOutAll = HR_TimeIn_TimeOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_TimeIn_TimeOutDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_TimeIn_TimeOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_TimeIn_TimeOutsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TimeIn_TimeOuts(table.Rows.Count - 1) As HR_TimeIn_TimeOut
                For Each dr As DataRow In table.Rows
                    HR_TimeIn_TimeOuts(i) = New HR_TimeIn_TimeOut(dr)
                    i += 1
                Next
                GetHR_TimeIn_TimeOutDynamic = HR_TimeIn_TimeOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_TimeIn_TimeOutDynamic(ByVal WhereCondition As String) As HR_TimeIn_TimeOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_TimeIn_TimeOutsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TimeIn_TimeOuts(table.Rows.Count - 1) As HR_TimeIn_TimeOut
                For Each dr As DataRow In table.Rows
                    HR_TimeIn_TimeOuts(i) = New HR_TimeIn_TimeOut(dr)
                    i += 1
                Next
                GetHR_TimeIn_TimeOutDynamic = HR_TimeIn_TimeOuts
            End If
        End If
    End Function

    Public Shared Function GetHR_TimeIn_TimeOutFullDynamic(ByVal sql As String) As HR_TimeIn_TimeOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData(sql, "HR_TimeIn_TimeOut")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TimeIn_TimeOuts(table.Rows.Count - 1) As HR_TimeIn_TimeOut
                For Each dr As DataRow In table.Rows
                    HR_TimeIn_TimeOuts(i) = New HR_TimeIn_TimeOut(dr)
                    i += 1
                Next
                GetHR_TimeIn_TimeOutFullDynamic = HR_TimeIn_TimeOuts
            End If
        End If
    End Function

    Public Shared Function DeleteHR_TimeIn_TimeOutsDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_TimeIn_TimeOutsDynamic", name, oj, tp)
    End Function

    Public Shared Function GetHR_TimeIn_TimeOutByAndEmployee_ID(ByVal Employee_ID As System.String) As HR_TimeIn_TimeOut()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_TimeIn_TimeOutsByAndEmployee_ID", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TimeIn_TimeOuts(table.Rows.Count - 1) As HR_TimeIn_TimeOut
                For Each dr As DataRow In table.Rows
                    HR_TimeIn_TimeOuts(i) = New HR_TimeIn_TimeOut(dr)
                    i += 1
                Next
                GetHR_TimeIn_TimeOutByAndEmployee_ID = HR_TimeIn_TimeOuts
            End If
        End If
    End Function

    Public Shared Function DeleteHR_TimeIn_TimeOutByAndEmployee_ID(ByVal Employee_ID As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_TimeIn_TimeOutsByAndEmployee_ID", name, oj, tp)
    End Function

    Public Shared Function Search(ByVal tito() As HR_TimeIn_TimeOut, ByVal Employee_ID As String, ByVal OT_date As DateTime) As HR_TimeIn_TimeOut
        For Each HR_TimeIn_TimeOut1 As HR_TimeIn_TimeOut In tito
            If HR_TimeIn_TimeOut1.Employee_ID = Employee_ID And HR_TimeIn_TimeOut1.OT_date = OT_date Then
                Return HR_TimeIn_TimeOut1
            End If
        Next
    End Function

    Public Shared Function Search(ByVal tito() As HR_TimeIn_TimeOut, ByVal Employee_ID As String) As HR_TimeIn_TimeOut()
        Dim arl As New ArrayList
        For Each HR_TimeIn_TimeOut1 As HR_TimeIn_TimeOut In tito
            If HR_TimeIn_TimeOut1.Employee_ID = Employee_ID Then
                arl.Add(HR_TimeIn_TimeOut1)
            End If
        Next
        Dim HR_TimeIn_TimeOut_Return(arl.Count - 1) As HR_TimeIn_TimeOut
        For i As Integer = 0 To arl.Count - 1
            HR_TimeIn_TimeOut_Return(i) = arl(i)
        Next
        Return HR_TimeIn_TimeOut_Return
    End Function
End Class
#End Region

