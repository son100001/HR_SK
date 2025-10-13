Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_Khoa"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_Khoa.
    ''' </summary>
    Public Class HR_Khoa
        Private _functionID As System.String = String.Empty
        Private _tableName As System.String = String.Empty
        Private _block_Date As System.DateTime
        Private _block_User As System.String = String.Empty
        Private _status As System.Boolean
        Private _commnent As System.String = String.Empty
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal TableName As System.String, ByVal Block_User As System.String)
            Dim name() As String = {"@TableName", "@Block_User"}
            Dim oj() As Object = {TableName, Block_User}
            Dim tp() As String = {"NVarChar", "NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_Khoa", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _tableName = TableName
                _block_User = Block_User
            End If
        Else
            _tableName = TableName
            _block_User = Block_User
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("FunctionID")) Then
                    _functionID = _datarow("FunctionID")
                End If
                If Not IsDBNull(_datarow("TableName")) Then
                    _tableName = _datarow("TableName")
                End If
                If Not IsDBNull(_datarow("Block_Date")) Then
                    _block_Date = _datarow("Block_Date")
                End If
                If Not IsDBNull(_datarow("Block_User")) Then
                    _block_User = _datarow("Block_User")
                End If
                If Not IsDBNull(_datarow("Status")) Then
                    _status = _datarow("Status")
                End If
                If Not IsDBNull(_datarow("Commnent")) Then
                    _commnent = _datarow("Commnent")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("FunctionID")) Then
                    _functionID = _datarow("FunctionID")
                End If
                If Not IsDBNull(_datarow("TableName")) Then
                    _tableName = _datarow("TableName")
                End If
                If Not IsDBNull(_datarow("Block_Date")) Then
                    _block_Date = _datarow("Block_Date")
                End If
                If Not IsDBNull(_datarow("Block_User")) Then
                    _block_User = _datarow("Block_User")
                End If
                If Not IsDBNull(_datarow("Status")) Then
                    _status = _datarow("Status")
                End If
                If Not IsDBNull(_datarow("Commnent")) Then
                    _commnent = _datarow("Commnent")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@TableName", "@Block_User"}
            Dim oj() As Object = {TableName, Block_User}
            Dim tp() As String = {"NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_DeleteHR_Khoa", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@FunctionID", "@TableName", "@Block_Date", "@Block_User", "@Status", "@Commnent"}
            Dim oj() As Object = {FunctionID, TableName, Block_Date, Block_User, Status, Commnent}
            Dim tp() As String = {"NVarChar", "NVarChar", "DateTime", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_UpdateHR_Khoa", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@FunctionID", "@TableName", "@Block_Date", "@Block_User", "@Status", "@Commnent"}
            Dim oj() As Object = {FunctionID, TableName, Block_Date, Block_User, Status, Commnent}
            Dim tp() As String = {"NVarChar", "NVarChar", "DateTime", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertHR_Khoa", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@FunctionID", "@TableName", "@Block_Date", "@Block_User", "@Status", "@Commnent"}
            Dim oj() As Object = {FunctionID, TableName, Block_Date, Block_User, Status, Commnent}
            Dim tp() As String = {"NVarChar", "NVarChar", "DateTime", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_Khoa", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __FunctionID As String
            Dim __TableName As String
            Dim __Block_Date As String
            Dim __Block_User As String
            Dim __Status As String
            Dim __Commnent As String
            If FunctionID <> String.Empty Then
                __FunctionID = "N'" + FunctionID + "'"
            Else
                __FunctionID = "null"
            End If
            If TableName <> String.Empty Then
                __TableName = "N'" + TableName + "'"
            Else
                __TableName = "null"
            End If
            If Block_Date <> DateTime.MinValue Then
                __Block_Date = "'" + kn.DateTimeToString(Block_Date) + "'"
            Else
                __Block_Date = "null"
            End If
            If Block_User <> String.Empty Then
                __Block_User = "N'" + Block_User + "'"
            Else
                __Block_User = "null"
            End If
            If Status = True Then
                _Status = "'1'"
            Else
                __Status = "'0'"
            End If
            If Commnent <> String.Empty Then
                __Commnent = "N'" + Commnent + "'"
            Else
                __Commnent = "null"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [HR_Khoa]([FunctionID],[TableName],[Block_Date],[Block_User],[Status],[Commnent])VALUES(" & _
            __FunctionID + "," + __TableName + "," + __Block_Date + "," + __Block_User + "," + __Status + "," + __Commnent + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __FunctionID As String
            Dim __TableName As String
            Dim __Block_Date As String
            Dim __Block_User As String
            Dim __Status As String
            Dim __Commnent As String
            If FunctionID <> String.Empty Then
                __FunctionID = "N'" + FunctionID + "'"
            Else
                __FunctionID = "null"
            End If
            If TableName <> String.Empty Then
                __TableName = "N'" + TableName + "'"
            Else
                __TableName = "null"
            End If
            If Block_Date <> DateTime.MinValue Then
                __Block_Date = "'" + kn.DateTimeToString(Block_Date) + "'"
            Else
                __Block_Date = "null"
            End If
            If Block_User <> String.Empty Then
                __Block_User = "N'" + Block_User + "'"
            Else
                __Block_User = "null"
            End If
            If Status = True Then
                _Status = "'1'"
            Else
                __Status = "'0'"
            End If
            If Commnent <> String.Empty Then
                __Commnent = "N'" + Commnent + "'"
            Else
                __Commnent = "null"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [HR_Khoa] SET [FunctionID]=" + __FunctionID + ",[TableName]=" + __TableName + ",[Block_Date]=" + __Block_Date + ",[Block_User]=" + __Block_User + ",[Status]=" + __Status + ",[Commnent]=" + __Commnent + " WHERE [TableName]=" + __TableName + " and [Block_User]=" + __Block_User
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __TableName As String
            Dim __Block_User As String
            If TableName <> String.Empty Then
                __TableName = "N'" + TableName + "'"
            Else
                __TableName = "null"
            End If
            If Block_User <> String.Empty Then
                __Block_User = "N'" + Block_User + "'"
            Else
                __Block_User = "null"
            End If
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_Khoa] WHERE [TableName]=" + __TableName + " and [Block_User]=" + __Block_User
            Return sql
        End Function

        Public Shared Function NewHR_Khoa(ByVal TableName As System.String, ByVal Block_User As System.String) As HR_Khoa
            Dim newEntity As New HR_Khoa
            newEntity._tableName = TableName
            newEntity._block_User = Block_User
            Return newEntity
        End Function

#Region "Public Properties"
        Public Property FunctionID() As System.String
            Get
                Return _functionID
            End Get
            Set(ByVal value As System.String)
                _functionID = value
            End Set
        End Property

        Public Property TableName() As System.String
            Get
                Return _tableName
            End Get
            Set(ByVal value As System.String)
                _tableName = value
            End Set
        End Property

        Public Property Block_Date() As System.DateTime
            Get
                Return _block_Date
            End Get
            Set(ByVal value As System.DateTime)
                _block_Date = value
            End Set
        End Property

        Public Property Block_User() As System.String
            Get
                Return _block_User
            End Get
            Set(ByVal value As System.String)
                _block_User = value
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

        Public Property Commnent() As System.String
            Get
                Return _commnent
            End Get
            Set(ByVal value As System.String)
                _commnent = value
            End Set
        End Property

#End Region

        Public Shared Function GetHR_Khoa(ByVal TableName As System.String, ByVal Block_User As System.String) As HR_Khoa
            Return New HR_Khoa(TableName, Block_User)
        End Function

        Public Shared Function GetHR_KhoaAll() As HR_Khoa()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM dbo.[HR_Khoa]", "HR_Khoa")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_Khoas(table.Rows.Count - 1) As HR_Khoa
                For Each dr As DataRow In table.Rows
                    HR_Khoas(i) = New HR_Khoa(dr)
                    i += 1
                Next
                GetHR_KhoaAll = HR_Khoas
            End If
        End If
    End Function

    Public Shared Function GetHR_KhoaAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM HR_Khoa", "HR_Khoa")
        Return table
    End Function

    Public Shared Function GetHR_KhoaDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_Khoa()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_KhoasDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_Khoas(table.Rows.Count - 1) As HR_Khoa
                For Each dr As DataRow In table.Rows
                    HR_Khoas(i) = New HR_Khoa(dr)
                    i += 1
                Next
                GetHR_KhoaDynamic = HR_Khoas
            End If
        End If
    End Function

    Public Shared Function GetHR_KhoaDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_KhoasDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_KhoaDynamic(ByVal WhereCondition As String) As HR_Khoa()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_KhoasDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_Khoas(table.Rows.Count - 1) As HR_Khoa
                For Each dr As DataRow In table.Rows
                    HR_Khoas(i) = New HR_Khoa(dr)
                    i += 1
                Next
                GetHR_KhoaDynamic = HR_Khoas
            End If
        End If
    End Function

    Public Shared Function GetHR_KhoaDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_KhoasDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_KhoaFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As HR_Khoa()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_Khoa where " + sqlAfterWhere, "HR_Khoa")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_Khoas(table.Rows.Count - 1) As HR_Khoa
                For Each dr As DataRow In table.Rows
                    HR_Khoas(i) = New HR_Khoa(dr)
                    i += 1
                Next
                GetHR_KhoaFullDynamic = HR_Khoas
            End If
        End If
    End Function

    Public Shared Function GetHR_KhoaFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_Khoa where " + sqlAfterWhere, "HR_Khoa")
        Return table
    End Function

    Public Shared Function DeleteHR_KhoasDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_KhoasDynamic", name, oj, tp)
    End Function



    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As HR_Khoa, ByVal TableName As System.String, ByVal Block_User As System.String) As HR_Khoa
        For Each HR_Khoa1 As HR_Khoa In list
            If HR_Khoa1.TableName = TableName And HR_Khoa1.Block_User = Block_User Then
                Return HR_Khoa1
            End If
        Next
    End Function

End Class
#End Region