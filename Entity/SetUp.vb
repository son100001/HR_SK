Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "SetUp"
    ''' <summary>
    ''' This object represents the properties and methods of a SetUp.
    ''' </summary>
    Public Class SetUp
        Private _iD As System.String = String.Empty
        Private _value As System.String = String.Empty
        Private _comment_VN As System.String = String.Empty
        Private _comment_EN As System.String = String.Empty
        Private _functionID As System.String = String.Empty
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal ID As System.String)
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSetUp", name, oj, tp)
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
                If Not IsDBNull(_datarow("Value")) Then
                    _value = _datarow("Value")
                End If
                If Not IsDBNull(_datarow("Comment_VN")) Then
                    _comment_VN = _datarow("Comment_VN")
                End If
                If Not IsDBNull(_datarow("Comment_EN")) Then
                    _comment_EN = _datarow("Comment_EN")
                End If
                If Not IsDBNull(_datarow("FunctionID")) Then
                    _functionID = _datarow("FunctionID")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("ID")) Then
                    _iD = _datarow("ID")
                End If
                If Not IsDBNull(_datarow("Value")) Then
                    _value = _datarow("Value")
                End If
                If Not IsDBNull(_datarow("Comment_VN")) Then
                    _comment_VN = _datarow("Comment_VN")
                End If
                If Not IsDBNull(_datarow("Comment_EN")) Then
                    _comment_EN = _datarow("Comment_EN")
                End If
                If Not IsDBNull(_datarow("FunctionID")) Then
                    _functionID = _datarow("FunctionID")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"NVarChar"}
            kn.ExecStore("dbo.usp_DeleteSetUp", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@ID", "@Value", "@Comment_VN", "@Comment_EN", "@FunctionID"}
            Dim oj() As Object = {ID, Value, Comment_VN, Comment_EN, FunctionID}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_UpdateSetUp", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@ID", "@Value", "@Comment_VN", "@Comment_EN", "@FunctionID"}
            Dim oj() As Object = {ID, Value, Comment_VN, Comment_EN, FunctionID}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertSetUp", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@ID", "@Value", "@Comment_VN", "@Comment_EN", "@FunctionID"}
            Dim oj() As Object = {ID, Value, Comment_VN, Comment_EN, FunctionID}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertUpdateSetUp", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __ID As String
            Dim __Value As String
            Dim __Comment_VN As String
            Dim __Comment_EN As String
            Dim __FunctionID As String
            If ID <> String.Empty Then
                __ID = "N'" + ID + "'"
            Else
                __ID = "null"
            End If
            If Value <> String.Empty Then
                __Value = "N'" + Value + "'"
            Else
                __Value = "null"
            End If
            If Comment_VN <> String.Empty Then
                __Comment_VN = "N'" + Comment_VN + "'"
            Else
                __Comment_VN = "null"
            End If
            If Comment_EN <> String.Empty Then
                __Comment_EN = "N'" + Comment_EN + "'"
            Else
                __Comment_EN = "null"
            End If
            If FunctionID <> String.Empty Then
                __FunctionID = "N'" + FunctionID + "'"
            Else
                __FunctionID = "null"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [SetUp]([ID],[Value],[Comment_VN],[Comment_EN],[FunctionID])VALUES(" & _
            __ID + "," + __Value + "," + __Comment_VN + "," + __Comment_EN + "," + __FunctionID + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __ID As String
            Dim __Value As String
            Dim __Comment_VN As String
            Dim __Comment_EN As String
            Dim __FunctionID As String
            If ID <> String.Empty Then
                __ID = "N'" + ID + "'"
            Else
                __ID = "null"
            End If
            If Value <> String.Empty Then
                __Value = "N'" + Value + "'"
            Else
                __Value = "null"
            End If
            If Comment_VN <> String.Empty Then
                __Comment_VN = "N'" + Comment_VN + "'"
            Else
                __Comment_VN = "null"
            End If
            If Comment_EN <> String.Empty Then
                __Comment_EN = "N'" + Comment_EN + "'"
            Else
                __Comment_EN = "null"
            End If
            If FunctionID <> String.Empty Then
                __FunctionID = "N'" + FunctionID + "'"
            Else
                __FunctionID = "null"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [SetUp] SET [ID]=" + __ID + ",[Value]=" + __Value + ",[Comment_VN]=" + __Comment_VN + ",[Comment_EN]=" + __Comment_EN + ",[FunctionID]=" + __FunctionID + " WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __ID As String
            If ID <> String.Empty Then
                __ID = "N'" + ID + "'"
            Else
                __ID = "null"
            End If
            Dim sql As String = String.Empty
            sql = "DELETE FROM [SetUp] WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Shared Function NewSetUp(ByVal ID As System.String) As SetUp
            Dim newEntity As New SetUp
            newEntity._iD = ID
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property ID() As System.String
            Get
                Return _iD
            End Get
            Set(ByVal value As System.String)
                _iD = value
            End Set
        End Property

        Public Property Value() As System.String
            Get
                Return _value
            End Get
            Set(ByVal value As System.String)
                _value = value
            End Set
        End Property

        Public Property Comment_VN() As System.String
            Get
                Return _comment_VN
            End Get
            Set(ByVal value As System.String)
                _comment_VN = value
            End Set
        End Property

        Public Property Comment_EN() As System.String
            Get
                Return _comment_EN
            End Get
            Set(ByVal value As System.String)
                _comment_EN = value
            End Set
        End Property

        Public Property FunctionID() As System.String
            Get
                Return _functionID
            End Get
            Set(ByVal value As System.String)
                _functionID = value
            End Set
        End Property

#End Region

        Public Shared Function GetSetUp(ByVal ID As System.String) As SetUp
            Return New SetUp(ID)
        End Function

        Public Shared Function GetSetUpAll() As SetUp()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM SetUp", "SetUp")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SetUps(table.Rows.Count - 1) As SetUp
                For Each dr As DataRow In table.Rows
                    SetUps(i) = New SetUp(dr)
                    i += 1
                Next
                GetSetUpAll = SetUps
            End If
        End If
    End Function

    Public Shared Function GetSetUpAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM SetUp", "SetUp")
        Return table
    End Function

    Public Shared Function GetSetUpDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As SetUp()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSetUpsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SetUps(table.Rows.Count - 1) As SetUp
                For Each dr As DataRow In table.Rows
                    SetUps(i) = New SetUp(dr)
                    i += 1
                Next
                GetSetUpDynamic = SetUps
            End If
        End If
    End Function

    Public Shared Function GetSetUpDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSetUpsDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetSetUpDynamic(ByVal WhereCondition As String) As SetUp()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSetUpsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SetUps(table.Rows.Count - 1) As SetUp
                For Each dr As DataRow In table.Rows
                    SetUps(i) = New SetUp(dr)
                    i += 1
                Next
                GetSetUpDynamic = SetUps
            End If
        End If
    End Function

    Public Shared Function GetSetUpDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSetUpsDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetSetUpFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As SetUp()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from SetUp where " + sqlAfterWhere, "SetUp")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SetUps(table.Rows.Count - 1) As SetUp
                For Each dr As DataRow In table.Rows
                    SetUps(i) = New SetUp(dr)
                    i += 1
                Next
                GetSetUpFullDynamic = SetUps
            End If
        End If
    End Function

    Public Shared Function GetSetUpFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from SetUp where " + sqlAfterWhere, "SetUp")
        Return table
    End Function

    Public Shared Function DeleteSetUpsDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteSetUpsDynamic", name, oj, tp)
    End Function

    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As SetUp, ByVal ID As System.String) As SetUp
        For Each SetUp1 As SetUp In list
            If SetUp1.ID = ID Then
                Return SetUp1
            End If
        Next
    End Function

End Class
#End Region