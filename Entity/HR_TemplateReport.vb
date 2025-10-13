Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_TemplateReport"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_TemplateReport.
    ''' </summary>
    Public Class HR_TemplateReport
        Private _iD As System.String = String.Empty
        Private _fileTemp As System.String = String.Empty
        Private _colExel As System.String = String.Empty
        Private _colOrCell As System.Boolean
        Private _comment As System.String = String.Empty
        Private _keyCol As System.String = String.Empty
        Private _upOrDown As System.Boolean
        Private _viewOnSalaryTable As System.String = String.Empty
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal ID As System.String, ByVal FileTemp As System.String, ByVal ColExel As System.String)
            Dim name() As String = {"@ID", "@FileTemp", "@ColExel"}
            Dim oj() As Object = {ID, FileTemp, ColExel}
            Dim tp() As String = {"VarChar", "NVarChar", "NVarChar"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_TemplateReport", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _iD = ID
                _fileTemp = FileTemp
                _colExel = ColExel
            End If
        Else
            _iD = ID
            _fileTemp = FileTemp
            _colExel = ColExel
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
                If Not IsDBNull(_datarow("ColExel")) Then
                    _colExel = _datarow("ColExel")
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
                If Not IsDBNull(_datarow("ColExel")) Then
                    _colExel = _datarow("ColExel")
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
            Dim name() As String = {"@ID", "@FileTemp", "@ColExel"}
            Dim oj() As Object = {ID, FileTemp, ColExel}
            Dim tp() As String = {"VarChar", "NVarChar", "NVarChar"}
            kn.ExecStore("dbo.usp_DeleteHR_TemplateReport", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@ID", "@FileTemp", "@ColExel", "@ColOrCell", "@Comment", "@KeyCol", "@UpOrDown", "@ViewOnSalaryTable"}
            Dim oj() As Object = {ID, FileTemp, ColExel, ColOrCell, Comment, KeyCol, UpOrDown, ViewOnSalaryTable}
            Dim tp() As String = {"VarChar", "NVarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_UpdateHR_TemplateReport", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@ID", "@FileTemp", "@ColExel", "@ColOrCell", "@Comment", "@KeyCol", "@UpOrDown", "@ViewOnSalaryTable"}
            Dim oj() As Object = {ID, FileTemp, ColExel, ColOrCell, Comment, KeyCol, UpOrDown, ViewOnSalaryTable}
            Dim tp() As String = {"VarChar", "NVarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertHR_TemplateReport", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@ID", "@FileTemp", "@ColExel", "@ColOrCell", "@Comment", "@KeyCol", "@UpOrDown", "@ViewOnSalaryTable"}
            Dim oj() As Object = {ID, FileTemp, ColExel, ColOrCell, Comment, KeyCol, UpOrDown, ViewOnSalaryTable}
            Dim tp() As String = {"VarChar", "NVarChar", "NVarChar", "Bit", "NVarChar", "NVarChar", "Bit", "NVarChar"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_TemplateReport", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim __ID As String
            Dim __FileTemp As String
            Dim __ColExel As String
            Dim __ColOrCell As String
            Dim __Comment As String
            Dim __KeyCol As String
            Dim __UpOrDown As String
            Dim __ViewOnSalaryTable As String
            __ID = "'" + ID + "'"
            If FileTemp <> String.Empty Then
                __FileTemp = "N'" + FileTemp + "'"
            Else
                __FileTemp = "null"
            End If
            If ColExel <> String.Empty Then
                __ColExel = "N'" + ColExel + "'"
            Else
                __ColExel = "null"
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
            sql = "INSERT INTO [HR_TemplateReport]([ID],[FileTemp],[ColExel],[ColOrCell],[Comment],[KeyCol],[UpOrDown],[ViewOnSalaryTable])VALUES(" & _
            __ID + "," + __FileTemp + "," + __ColExel + "," + __ColOrCell + "," + __Comment + "," + __KeyCol + "," + __UpOrDown + "," + __ViewOnSalaryTable + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim __ID As String
            Dim __FileTemp As String
            Dim __ColExel As String
            Dim __ColOrCell As String
            Dim __Comment As String
            Dim __KeyCol As String
            Dim __UpOrDown As String
            Dim __ViewOnSalaryTable As String
            __ID = "'" + ID + "'"
            If FileTemp <> String.Empty Then
                __FileTemp = "N'" + FileTemp + "'"
            Else
                __FileTemp = "null"
            End If
            If ColExel <> String.Empty Then
                __ColExel = "N'" + ColExel + "'"
            Else
                __ColExel = "null"
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
            sql = "UPDATE [HR_TemplateReport] SET [ID]=" + __ID + ",[FileTemp]=" + __FileTemp + ",[ColExel]=" + __ColExel + ",[ColOrCell]=" + __ColOrCell + ",[Comment]=" + __Comment + ",[KeyCol]=" + __KeyCol + ",[UpOrDown]=" + __UpOrDown + ",[ViewOnSalaryTable]=" + __ViewOnSalaryTable + " WHERE [ID]=" + __ID + " and [FileTemp]=" + __FileTemp + " and [ColExel]=" + __ColExel
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim __ID As String
            Dim __FileTemp As String
            Dim __ColExel As String
            __ID = "'" + ID + "'"
            If FileTemp <> String.Empty Then
                __FileTemp = "N'" + FileTemp + "'"
            Else
                __FileTemp = "null"
            End If
            If ColExel <> String.Empty Then
                __ColExel = "N'" + ColExel + "'"
            Else
                __ColExel = "null"
            End If
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_TemplateReport] WHERE [ID]=" + __ID + " and [FileTemp]=" + __FileTemp + " and [ColExel]=" + __ColExel
            Return sql
        End Function

        Public Shared Function NewHR_TemplateReport(ByVal ID As System.String, ByVal FileTemp As System.String, ByVal ColExel As System.String) As HR_TemplateReport
            Dim newEntity As New HR_TemplateReport
            newEntity._iD = ID
            newEntity._fileTemp = FileTemp
            newEntity._colExel = ColExel
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

        Public Property FileTemp() As System.String
            Get
                Return _fileTemp
            End Get
            Set(ByVal value As System.String)
                _fileTemp = value
            End Set
        End Property

        Public Property ColExel() As System.String
            Get
                Return _colExel
            End Get
            Set(ByVal value As System.String)
                _colExel = value
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

        Public Shared Function GetHR_TemplateReport(ByVal ID As System.String, ByVal FileTemp As System.String, ByVal ColExel As System.String) As HR_TemplateReport
            Return New HR_TemplateReport(ID, FileTemp, ColExel)
        End Function

        Public Shared Function GetHR_TemplateReportAll() As HR_TemplateReport()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM dbo.[HR_TemplateReport]", "HR_TemplateReport")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TemplateReports(table.Rows.Count - 1) As HR_TemplateReport
                For Each dr As DataRow In table.Rows
                    HR_TemplateReports(i) = New HR_TemplateReport(dr)
                    i += 1
                Next
                GetHR_TemplateReportAll = HR_TemplateReports
            End If
        End If
    End Function

    Public Shared Function GetHR_TemplateReportAllReturnDataTable() As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("SELECT * FROM HR_TemplateReport", "HR_TemplateReport")
        Return table
    End Function

    Public Shared Function GetHR_TemplateReportDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_TemplateReport()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from HR_TemplateReport where " + WhereCondition + " order by " + OrderByExpression, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TemplateReports(table.Rows.Count - 1) As HR_TemplateReport
                For Each dr As DataRow In table.Rows
                    HR_TemplateReports(i) = New HR_TemplateReport(dr)
                    i += 1
                Next
                GetHR_TemplateReportDynamic = HR_TemplateReports
            End If
        End If
    End Function

    Public Shared Function GetHR_TemplateReportDynamicReturnDataTable(ByVal WhereCondition As String, ByVal OrderByExpression As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from HR_TemplateReport where " + WhereCondition + " order by " + OrderByExpression, "table")
        Return table
    End Function

    Public Shared Function GetHR_TemplateReportDynamic(ByVal WhereCondition As String) As HR_TemplateReport()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select * from HR_TemplateReport where " + WhereCondition, "table")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TemplateReports(table.Rows.Count - 1) As HR_TemplateReport
                For Each dr As DataRow In table.Rows
                    HR_TemplateReports(i) = New HR_TemplateReport(dr)
                    i += 1
                Next
                GetHR_TemplateReportDynamic = HR_TemplateReports
            End If
        End If
    End Function

    Public Shared Function GetHR_TemplateReportDynamicReturnDataTable(ByVal WhereCondition As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ReadData("select * from HR_TemplateReport where " + WhereCondition, "table")
        Return table
    End Function

    Public Shared Function GetHR_TemplateReportFullDynamic(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As HR_TemplateReport()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_TemplateReport where " + sqlAfterWhere, "HR_TemplateReport")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_TemplateReports(table.Rows.Count - 1) As HR_TemplateReport
                For Each dr As DataRow In table.Rows
                    HR_TemplateReports(i) = New HR_TemplateReport(dr)
                    i += 1
                Next
                GetHR_TemplateReportFullDynamic = HR_TemplateReports
            End If
        End If
    End Function

    Public Shared Function GetHR_TemplateReportFullDynamicReturnDataTable(ByVal sqlAfterSelectBeforeWhere As String, ByVal sqlAfterWhere As String) As DataTable
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData("select " + sqlAfterSelectBeforeWhere + " from HR_TemplateReport where " + sqlAfterWhere, "HR_TemplateReport")
        Return table
    End Function

    Public Shared Function DeleteHR_TemplateReportsDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_TemplateReportsDynamic", name, oj, tp)
    End Function



    Public Shared Function SearchFromListFollowPrimaryKey(ByVal list() As HR_TemplateReport, ByVal ID As System.String, ByVal FileTemp As System.String, ByVal ColExel As System.String) As HR_TemplateReport
        For Each HR_TemplateReport1 As HR_TemplateReport In list
            If HR_TemplateReport1.ID = ID And HR_TemplateReport1.FileTemp = FileTemp And HR_TemplateReport1.ColExel = ColExel Then
                Return HR_TemplateReport1
            End If
        Next
    End Function


End Class
#End Region

