Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_FormulaExcel"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_FormulaExcel.
    ''' </summary>
    Public Class HR_FormulaExcel
        Private _iD As System.Int32
        Private _fileTemp As System.String = String.Empty
        Private _colExcel As System.String = String.Empty
        Private _formula As System.String = String.Empty
        Private _colOrCell As System.Boolean
        Private _comment As System.String = String.Empty
        Private _keyCol As System.String = String.Empty
        Private _upOrDown As System.Boolean
        Private _viewOnSalaryTable As System.String = String.Empty
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal ID As System.Int32)
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"Int"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_FormulaExcel", name, oj, tp)
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
                If Not IsDBNull(_datarow("FileTemp")) Then
                    _fileTemp = _datarow("FileTemp")
                End If
                If Not IsDBNull(_datarow("ColExcel")) Then
                    _colExcel = _datarow("ColExcel")
                End If
                If Not IsDBNull(_datarow("Formula")) Then
                    _formula = _datarow("Formula")
                End If
                If Not IsDBNull(_datarow("ColOrCell")) Then
                    _colOrCell = _datarow("ColOrCell")
                End If
                If Not IsDBNull(_datarow("Comment")) Then
                    _comment = _datarow("Comment")
                End If
                If Not IsDBNull(_datarow("KeyCol")) Then
                    _keyCol = _datarow("KeyCol")
                End If
                If Not IsDBNull(_datarow("UpOrDown")) Then
                    _upOrDown = _datarow("UpOrDown")
                End If
                If Not IsDBNull(_datarow("ViewOnSalaryTable")) Then
                    _viewOnSalaryTable = _datarow("ViewOnSalaryTable")
                End If
            End If
        End Sub

        Protected Sub LoadFromDataRow(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("ID")) Then
                    _iD = _datarow("ID")
                End If
                If Not IsDBNull(_datarow("FileTemp")) Then
                    _fileTemp = _datarow("FileTemp")
                End If
                If Not IsDBNull(_datarow("ColExcel")) Then
                    _colExcel = _datarow("ColExcel")
                End If
                If Not IsDBNull(_datarow("Formula")) Then
                    _formula = _datarow("Formula")
                End If
                If Not IsDBNull(_datarow("ColOrCell")) Then
                    _colOrCell = _datarow("ColOrCell")
                End If
                If Not IsDBNull(_datarow("Comment")) Then
                    _comment = _datarow("Comment")
                End If
                If Not IsDBNull(_datarow("KeyCol")) Then
                    _keyCol = _datarow("KeyCol")
                End If
                If Not IsDBNull(_datarow("UpOrDown")) Then
                    _upOrDown = _datarow("UpOrDown")
                End If
                If Not IsDBNull(_datarow("ViewOnSalaryTable")) Then
                    _viewOnSalaryTable = _datarow("ViewOnSalaryTable")
                End If
            End If
        End Sub

        Public Sub Delete()
            Dim name() As String = {"@ID"}
            Dim oj() As Object = {ID}
            Dim tp() As String = {"Int"}
            kn.ExecStore("dbo.usp_DeleteHR_FormulaExcel", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@FileTemp", "@ColExcel", "@Formula", "@ColOrCell", "@Comment", "@KeyCol", "@UpOrDown", "@ViewOnSalaryTable"}
            Dim oj() As Object = {FileTemp, ColExcel, Formula, ColOrCell, Comment, KeyCol, UpOrDown, ViewOnSalaryTable}
            Dim tp() As String = {"VarChar", "VarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_UpdateHR_FormulaExcel", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@FileTemp", "@ColExcel", "@Formula", "@ColOrCell", "@Comment", "@KeyCol", "@UpOrDown", "@ViewOnSalaryTable"}
            Dim oj() As Object = {FileTemp, ColExcel, Formula, ColOrCell, Comment, KeyCol, UpOrDown, ViewOnSalaryTable}
            Dim tp() As String = {"VarChar", "VarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertHR_FormulaExcel", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@FileTemp", "@ColExcel", "@Formula", "@ColOrCell", "@Comment", "@KeyCol", "@UpOrDown", "@ViewOnSalaryTable"}
            Dim oj() As Object = {FileTemp, ColExcel, Formula, ColOrCell, Comment, KeyCol, UpOrDown, ViewOnSalaryTable}
            Dim tp() As String = {"VarChar", "VarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_FormulaExcel", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __FileTemp As String
            Dim __ColExcel As String
            Dim __Formula As String
            Dim __ColOrCell As String
            Dim __Comment As String
            Dim __KeyCol As String
            Dim __UpOrDown As String
            Dim __ViewOnSalaryTable As String
            __FileTemp = "'" + FileTemp + "'"
            __ColExcel = "'" + ColExcel + "'"
            If Formula <> String.Empty Then
                __Formula = "N'" + Formula + "'"
            Else
                __Formula = "null"
            End If
            If ColOrCell = True Then
                _ColOrCell = "'1'"
            Else
                __ColOrCell = "'0'"
            End If
            If Comment <> String.Empty Then
                __Comment = "N'" + Comment + "'"
            Else
                __Comment = "null"
            End If
            If KeyCol <> String.Empty Then
                __KeyCol = "N'" + KeyCol + "'"
            Else
                __KeyCol = "null"
            End If
            If UpOrDown = True Then
                _UpOrDown = "'1'"
            Else
                __UpOrDown = "'0'"
            End If
            If ViewOnSalaryTable <> String.Empty Then
                __ViewOnSalaryTable = "N'" + ViewOnSalaryTable + "'"
            Else
                __ViewOnSalaryTable = "null"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [HR_FormulaExcel]([FileTemp],[ColExcel],[Formula],[ColOrCell],[Comment],[KeyCol],[UpOrDown],[ViewOnSalaryTable])VALUES(" & _
            __FileTemp + "," + __ColExcel + "," + __Formula + "," + __ColOrCell + "," + __Comment + "," + __KeyCol + "," + __UpOrDown + "," + __ViewOnSalaryTable + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __ID As String
            Dim __FileTemp As String
            Dim __ColExcel As String
            Dim __Formula As String
            Dim __ColOrCell As String
            Dim __Comment As String
            Dim __KeyCol As String
            Dim __UpOrDown As String
            Dim __ViewOnSalaryTable As String
            __ID = "'" + ID.tostring + "'"
            __FileTemp = "'" + FileTemp + "'"
            __ColExcel = "'" + ColExcel + "'"
            If Formula <> String.Empty Then
                __Formula = "N'" + Formula + "'"
            Else
                __Formula = "null"
            End If
            If ColOrCell = True Then
                __ColOrCell = "'1'"
            Else
                __ColOrCell = "'0'"
            End If
            If Comment <> String.Empty Then
                __Comment = "N'" + Comment + "'"
            Else
                __Comment = "null"
            End If
            If KeyCol <> String.Empty Then
                __KeyCol = "N'" + KeyCol + "'"
            Else
                __KeyCol = "null"
            End If
            If UpOrDown = True Then
                __UpOrDown = "'1'"
            Else
                __UpOrDown = "'0'"
            End If
            If ViewOnSalaryTable <> String.Empty Then
                __ViewOnSalaryTable = "N'" + ViewOnSalaryTable + "'"
            Else
                __ViewOnSalaryTable = "null"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [HR_FormulaExcel] SET [FileTemp]=" + __FileTemp + ",[ColExcel]=" + __ColExcel + ",[Formula]=" + __Formula + ",[ColOrCell]=" + __ColOrCell + ",[Comment]=" + __Comment + ",[KeyCol]=" + __KeyCol + ",[UpOrDown]=" + __UpOrDown + ",[ViewOnSalaryTable]=" + __ViewOnSalaryTable + " WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __ID As String
            __ID = "'" + ID.tostring + "'"
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_FormulaExcel] WHERE [ID]=" + __ID
            Return sql
        End Function

        Public Shared Function NewHR_FormulaExcel(ByVal ID As System.Int32) As HR_FormulaExcel
            Dim newEntity As New HR_FormulaExcel
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

        Public Property FileTemp() As System.String
            Get
                Return _fileTemp
            End Get
            Set(ByVal value As System.String)
                _fileTemp = value
            End Set
        End Property

        Public Property ColExcel() As System.String
            Get
                Return _colExcel
            End Get
            Set(ByVal value As System.String)
                _colExcel = value
            End Set
        End Property

        Public Property Formula() As System.String
            Get
                Return _formula
            End Get
            Set(ByVal value As System.String)
                _formula = value
            End Set
        End Property

        Public Property ColOrCell() As System.Boolean
            Get
                Return _colOrCell
            End Get
            Set(ByVal value As System.Boolean)
                _colOrCell = value
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

        Public Property KeyCol() As System.String
            Get
                Return _keyCol
            End Get
            Set(ByVal value As System.String)
                _keyCol = value
            End Set
        End Property

        Public Property UpOrDown() As System.Boolean
            Get
                Return _upOrDown
            End Get
            Set(ByVal value As System.Boolean)
                _upOrDown = value
            End Set
        End Property

        Public Property ViewOnSalaryTable() As System.String
            Get
                Return _viewOnSalaryTable
            End Get
            Set(ByVal value As System.String)
                _viewOnSalaryTable = value
            End Set
        End Property

#End Region

        Public Shared Function GetHR_FormulaExcel(ByVal ID As System.Int32) As HR_FormulaExcel
            Return New HR_FormulaExcel(ID)
        End Function

        Public Shared Function GetHR_FormulaExcelAll() As HR_FormulaExcel()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM dbo.[HR_FormulaExcel]", "HR_FormulaExcel")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_FormulaExcels(table.Rows.Count - 1) As HR_FormulaExcel
                For Each dr As DataRow In table.Rows
                    HR_FormulaExcels(i) = New HR_FormulaExcel(dr)
                    i += 1
                Next
                GetHR_FormulaExcelAll = HR_FormulaExcels
            End If
        End If
    End Function

    Public Shared Function GetHR_FormulaExcelAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM HR_FormulaExcel", "HR_FormulaExcel")
        Return table
    End Function

    Public Shared Function GetHR_FormulaExcelDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_FormulaExcel()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select [FileTemp],[ColExcel],[Formula],[ColOrCell],[Comment],[KeyCol],[UpOrDown],[ViewOnSalaryTable] from HR_FormulaExcel where " + WhereCondition + " order by " + OrderByExpression, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_FormulaExcels(table.Rows.Count - 1) As HR_FormulaExcel
                For Each dr As DataRow In table.Rows
                    HR_FormulaExcels(i) = New HR_FormulaExcel(dr)
                    i += 1
                Next
                GetHR_FormulaExcelDynamic = HR_FormulaExcels
            End If
        End If
    End Function

    Public Shared Function GetHR_FormulaExcelDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select [FileTemp],[ColExcel],[Formula],[ColOrCell],[Comment],[KeyCol],[UpOrDown],[ViewOnSalaryTable] from HR_FormulaExcel where " + WhereCondition + " order by " + OrderByExpression, "table")
        Return table
    End Function

    Public Shared Function GetHR_FormulaExcelDynamic(ByVal WhereCondition As String) As HR_FormulaExcel()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from HR_FormulaExcel where " + WhereCondition, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_FormulaExcels(table.Rows.Count - 1) As HR_FormulaExcel
                For Each dr As DataRow In table.Rows
                    HR_FormulaExcels(i) = New HR_FormulaExcel(dr)
                    i += 1
                Next
                GetHR_FormulaExcelDynamic = HR_FormulaExcels
            End If
        End If
    End Function

    Public Shared Function GetHR_FormulaExcelDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_FormulaExcelsDynamic", name, oj, tp)
        Return table
    End Function

    Public Shared Function GetHR_FormulaExcelFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As HR_FormulaExcel()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_FormulaExcel where " + sqlAfterWhere, "HR_FormulaExcel")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_FormulaExcels(table.Rows.Count - 1) As HR_FormulaExcel
                For Each dr As DataRow In table.Rows
                    HR_FormulaExcels(i) = New HR_FormulaExcel(dr)
                    i += 1
                Next
                GetHR_FormulaExcelFullDynamic = HR_FormulaExcels
            End If
        End If
    End Function

    Public Shared Function GetHR_FormulaExcelFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_FormulaExcel where " + sqlAfterWhere, "HR_FormulaExcel")
        Return table
    End Function

    Public Shared Function DeleteHR_FormulaExcelsDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_FormulaExcelsDynamic", name, oj, tp)
    End Function

    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As HR_FormulaExcel, ByVal ID As System.Int32) As HR_FormulaExcel
        For Each HR_FormulaExcel1 As HR_FormulaExcel In list
            If HR_FormulaExcel1.ID = ID Then
                Return HR_FormulaExcel1
            End If
        Next
    End Function
End Class
#End Region
