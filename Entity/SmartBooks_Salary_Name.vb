Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "SmartBooks_Salary_Name"
    ''' <summary>
    ''' This object represents the properties and methods of a SmartBooks_Salary_Name.
    ''' </summary>
    Public Class SmartBooks_Salary_Name
        Private _iD As System.Int32
        Private _salary As System.String = String.Empty
        Private _name_VN As System.String = String.Empty
        Private _name_EN As System.String = String.Empty
        Private _name_KR As System.String = String.Empty
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal Salary As System.String)
            Dim name() As String = {"@Salary"}
            Dim oj() As Object = {Salary}
            Dim tp() As String = {"NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Salary_Name", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _salary = Salary
            End If
        Else
                _salary = Salary
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("ID")) Then
                    _iD = _datarow("ID")
                End If
                If Not IsDBNull(_datarow("Salary")) Then
                    _salary = _datarow("Salary")
                End If
                If Not IsDBNull(_datarow("Name_VN")) Then
                    _name_VN = _datarow("Name_VN")
                End If
                If Not IsDBNull(_datarow("Name_EN")) Then
                    _name_EN = _datarow("Name_EN")
                End If
                If Not IsDBNull(_datarow("Name_KR")) Then
                    _name_KR = _datarow("Name_KR")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("ID")) Then
                    _iD = _datarow("ID")
                End If
                If Not IsDBNull(_datarow("Salary")) Then
                    _salary = _datarow("Salary")
                End If
                If Not IsDBNull(_datarow("Name_VN")) Then
                    _name_VN = _datarow("Name_VN")
                End If
                If Not IsDBNull(_datarow("Name_EN")) Then
                    _name_EN = _datarow("Name_EN")
                End If
                If Not IsDBNull(_datarow("Name_KR")) Then
                    _name_KR = _datarow("Name_KR")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@Salary"}
            Dim oj() As Object = {Salary}
            Dim tp() As String = {"NVarChar"}
            kn.ExecStore("dbo.usp_DeleteSmartBooks_Salary_Name", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@Salary", "@Name_VN", "@Name_EN", "@Name_KR"}
            Dim oj() As Object = {Salary, Name_VN, Name_EN, Name_KR}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_UpdateSmartBooks_Salary_Name", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@Salary", "@Name_VN", "@Name_EN", "@Name_KR"}
            Dim oj() As Object = {Salary, Name_VN, Name_EN, Name_KR}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertSmartBooks_Salary_Name", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@Salary", "@Name_VN", "@Name_EN", "@Name_KR"}
            Dim oj() As Object = {Salary, Name_VN, Name_EN, Name_KR}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertUpdateSmartBooks_Salary_Name", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __Salary As String
            Dim __Name_VN As String
            Dim __Name_EN As String
            Dim __Name_KR As String
            If Salary <> String.Empty Then
                __Salary = "N'" + Salary + "'"
            Else
                __Salary = "null"
            End If
            If Name_VN <> String.Empty Then
                __Name_VN = "N'" + Name_VN + "'"
            Else
                __Name_VN = "null"
            End If
            If Name_EN <> String.Empty Then
                __Name_EN = "N'" + Name_EN + "'"
            Else
                __Name_EN = "null"
            End If
            If Name_KR <> String.Empty Then
                __Name_KR = "N'" + Name_KR + "'"
            Else
                __Name_KR = "null"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [SmartBooks_Salary_Name]([Salary],[Name_VN],[Name_EN],[Name_KR])VALUES(" & _
            __Salary + "," + __Name_VN + "," + __Name_EN + "," + __Name_KR + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __ID As String
            Dim __Salary As String
            Dim __Name_VN As String
            Dim __Name_EN As String
            Dim __Name_KR As String
            __ID = "'" + ID.tostring + "'"
            If Salary <> String.Empty Then
                __Salary = "N'" + Salary + "'"
            Else
                __Salary = "null"
            End If
            If Name_VN <> String.Empty Then
                __Name_VN = "N'" + Name_VN + "'"
            Else
                __Name_VN = "null"
            End If
            If Name_EN <> String.Empty Then
                __Name_EN = "N'" + Name_EN + "'"
            Else
                __Name_EN = "null"
            End If
            If Name_KR <> String.Empty Then
                __Name_KR = "N'" + Name_KR + "'"
            Else
                __Name_KR = "null"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [SmartBooks_Salary_Name] SET [Salary]=" + __Salary + ",[Name_VN]=" + __Name_VN + ",[Name_EN]=" + __Name_EN + ",[Name_KR]=" + __Name_KR + " WHERE [Salary]=" + __Salary
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __Salary As String
            If Salary <> String.Empty Then
                __Salary = "N'" + Salary + "'"
            Else
                __Salary = "null"
            End If
            Dim sql As String = String.Empty
            sql = "DELETE FROM [SmartBooks_Salary_Name] WHERE [Salary]=" + __Salary
            Return sql
        End Function

        Public Shared Function NewSmartBooks_Salary_Name(ByVal Salary As System.String) As SmartBooks_Salary_Name
            Dim newEntity As New SmartBooks_Salary_Name
            newEntity._salary = Salary
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

        Public Property Salary() As System.String
            Get
                Return _salary
            End Get
            Set(ByVal value As System.String)
                _salary = value
            End Set
        End Property

        Public Property Name_VN() As System.String
            Get
                Return _name_VN
            End Get
            Set(ByVal value As System.String)
                _name_VN = value
            End Set
        End Property

        Public Property Name_EN() As System.String
            Get
                Return _name_EN
            End Get
            Set(ByVal value As System.String)
                _name_EN = value
            End Set
        End Property

        Public Property Name_KR() As System.String
            Get
                Return _name_KR
            End Get
            Set(ByVal value As System.String)
                _name_KR = value
            End Set
        End Property

#End Region

        Public Shared Function GetSmartBooks_Salary_Name(ByVal Salary As System.String) As SmartBooks_Salary_Name
            Return New SmartBooks_Salary_Name(Salary)
        End Function

        Public Shared Function GetSmartBooks_Salary_NameAll() As SmartBooks_Salary_Name()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM dbo.[SmartBooks_Salary_Name]", "SmartBooks_Salary_Name")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salary_Names(table.Rows.Count - 1) As SmartBooks_Salary_Name
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salary_Names(i) = New SmartBooks_Salary_Name(dr)
                    i += 1
                Next
                GetSmartBooks_Salary_NameAll = SmartBooks_Salary_Names
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_Salary_NameAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM SmartBooks_Salary_Name", "SmartBooks_Salary_Name")
        Return table
    End Function

    Public Shared Function GetSmartBooks_Salary_NameDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As SmartBooks_Salary_Name()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Salary_NamesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salary_Names(table.Rows.Count - 1) As SmartBooks_Salary_Name
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salary_Names(i) = New SmartBooks_Salary_Name(dr)
                    i += 1
                Next
                GetSmartBooks_Salary_NameDynamic = SmartBooks_Salary_Names
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_Salary_NameDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Salary_NamesDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetSmartBooks_Salary_NameDynamic(ByVal WhereCondition As String) As SmartBooks_Salary_Name()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Salary_NamesDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salary_Names(table.Rows.Count - 1) As SmartBooks_Salary_Name
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salary_Names(i) = New SmartBooks_Salary_Name(dr)
                    i += 1
                Next
                GetSmartBooks_Salary_NameDynamic = SmartBooks_Salary_Names
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_Salary_NameDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectSmartBooks_Salary_NamesDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetSmartBooks_Salary_NameFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As SmartBooks_Salary_Name()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from SmartBooks_Salary_Name where " + sqlAfterWhere, "SmartBooks_Salary_Name")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim SmartBooks_Salary_Names(table.Rows.Count - 1) As SmartBooks_Salary_Name
                For Each dr As DataRow In table.Rows
                    SmartBooks_Salary_Names(i) = New SmartBooks_Salary_Name(dr)
                    i += 1
                Next
                GetSmartBooks_Salary_NameFullDynamic = SmartBooks_Salary_Names
            End If
        End If
    End Function

    Public Shared Function GetSmartBooks_Salary_NameFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from SmartBooks_Salary_Name where " + sqlAfterWhere, "SmartBooks_Salary_Name")
        Return table
    End Function

    Public Shared Function DeleteSmartBooks_Salary_NamesDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteSmartBooks_Salary_NamesDynamic", name, oj, tp)
    End Function



    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As SmartBooks_Salary_Name, ByVal Salary As System.String) As SmartBooks_Salary_Name
        For Each SmartBooks_Salary_Name1 As SmartBooks_Salary_Name In list
            If SmartBooks_Salary_Name1.Salary = Salary Then
                Return SmartBooks_Salary_Name1
            End If
        Next
    End Function


End Class
#End Region

