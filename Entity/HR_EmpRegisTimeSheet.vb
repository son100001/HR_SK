Imports System
Imports System.Text
Imports System.Data
Imports Appsettings

#Region "HR_EmpRegisTimeSheet"
    ''' <summary>
    ''' This object represents the properties and methods of a HR_EmpRegisTimeSheet.
    ''' </summary>
    Public Class HR_EmpRegisTimeSheet
        Private _employee_ID As System.String = String.Empty
        Private _sectionCode As System.String = String.Empty
        Private _position_ID As System.String = String.Empty
        Private _timeDate As System.DateTime
        Private _shiftName As System.String = String.Empty
        Private _shiftName_Old As System.String = String.Empty
        Private _description_VN As System.String = String.Empty
        Private _description_EV As System.String = String.Empty
        Private _insertBy As System.String = String.Empty
        Private _insertDate As System.DateTime
        Private _updateBy As System.String = String.Empty
        Private _updateDate As System.DateTime
        Private kn As New connect(DbSetting.dataPath)

        Public Sub New()
        End Sub

        Public Sub New(ByVal Employee_ID As System.String, ByVal TimeDate As System.DateTime)
            Dim name() As String = {"@Employee_ID", "@TimeDate"}
            Dim oj() As Object = {Employee_ID, TimeDate}
            Dim tp() As String = {"NVarChar", "DateTime"}
            Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisTimeSheet", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Me.LoadFromDataRow(table.Select()(0))
            Else
                _employee_ID = Employee_ID
                _timeDate = TimeDate
            End If
        Else
            _employee_ID = Employee_ID
            _timeDate = TimeDate
        End If
        End Sub

        Public Sub New(ByVal _datarow As DataRow)
            If Not IsNothing(_datarow) Then
                If Not IsDBNull(_datarow("Employee_ID")) Then
                    _employee_ID = _datarow("Employee_ID")
                End If
                If Not IsDBNull(_datarow("SectionCode")) Then
                    _sectionCode = _datarow("SectionCode")
                End If
                If Not IsDBNull(_datarow("Position_ID")) Then
                    _position_ID = _datarow("Position_ID")
                End If
                If Not IsDBNull(_datarow("TimeDate")) Then
                    _timeDate = _datarow("TimeDate")
                End If
                If Not IsDBNull(_datarow("ShiftName")) Then
                    _shiftName = _datarow("ShiftName")
                End If
                If Not IsDBNull(_datarow("ShiftName_Old")) Then
                    _shiftName_Old = _datarow("ShiftName_Old")
                End If
                If Not IsDBNull(_datarow("Description_VN")) Then
                    _description_VN = _datarow("Description_VN")
                End If
                If Not IsDBNull(_datarow("Description_EV")) Then
                    _description_EV = _datarow("Description_EV")
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
                If Not IsDBNull(_datarow("SectionCode")) Then
                    _sectionCode = _datarow("SectionCode")
                End If
                If Not IsDBNull(_datarow("Position_ID")) Then
                    _position_ID = _datarow("Position_ID")
                End If
                If Not IsDBNull(_datarow("TimeDate")) Then
                    _timeDate = _datarow("TimeDate")
                End If
                If Not IsDBNull(_datarow("ShiftName")) Then
                    _shiftName = _datarow("ShiftName")
                End If
                If Not IsDBNull(_datarow("ShiftName_Old")) Then
                    _shiftName_Old = _datarow("ShiftName_Old")
                End If
                If Not IsDBNull(_datarow("Description_VN")) Then
                    _description_VN = _datarow("Description_VN")
                End If
                If Not IsDBNull(_datarow("Description_EV")) Then
                    _description_EV = _datarow("Description_EV")
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
            Dim name() As String = {"@Employee_ID", "@TimeDate"}
            Dim oj() As Object = {Employee_ID, TimeDate}
            Dim tp() As String = {"NVarChar", "DateTime"}
            kn.ExecStore("dbo.usp_DeleteHR_EmpRegisTimeSheet", name, oj, tp)
        End Sub

        Public Sub Update()
            Dim name() As String = {"@Employee_ID", "@SectionCode", "@Position_ID", "@TimeDate", "@ShiftName", "@ShiftName_Old", "@Description_VN", "@Description_EV", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate"}
            Dim oj() As Object = {Employee_ID, SectionCode, Position_ID, TimeDate, ShiftName, ShiftName_Old, Description_VN, Description_EV, InsertBy, InsertDate, UpdateBy, UpdateDate}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "VarChar", "DateTime", "VarChar", "DateTime"}
            kn.ExecStore("dbo.usp_UpdateHR_EmpRegisTimeSheet", name, oj, tp)
        End Sub

        Public Sub Create()
            Dim name() As String = {"@Employee_ID", "@SectionCode", "@Position_ID", "@TimeDate", "@ShiftName", "@ShiftName_Old", "@Description_VN", "@Description_EV", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate"}
            Dim oj() As Object = {Employee_ID, SectionCode, Position_ID, TimeDate, ShiftName, ShiftName_Old, Description_VN, Description_EV, InsertBy, InsertDate, UpdateBy, UpdateDate}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "VarChar", "DateTime", "VarChar", "DateTime"}
            kn.ExecStore("dbo.usp_InsertHR_EmpRegisTimeSheet", name, oj, tp)
        End Sub

        Public Sub CreateUpdate()
            Dim name() As String = {"@Employee_ID", "@SectionCode", "@Position_ID", "@TimeDate", "@ShiftName", "@ShiftName_Old", "@Description_VN", "@Description_EV", "@InsertBy", "@InsertDate", "@UpdateBy", "@UpdateDate"}
            Dim oj() As Object = {Employee_ID, SectionCode, Position_ID, TimeDate, ShiftName, ShiftName_Old, Description_VN, Description_EV, InsertBy, InsertDate, UpdateBy, UpdateDate}
            Dim tp() As String = {"NVarChar", "NVarChar", "NVarChar", "DateTime", "NVarChar", "NVarChar", "NVarChar", "NVarChar", "VarChar", "DateTime", "VarChar", "DateTime"}
            kn.ExecStore("dbo.usp_InsertUpdateHR_EmpRegisTimeSheet", name, oj, tp)
        End Sub

        Public Function GetSQLInsert() As String
            Dim _Employee_ID As String
            Dim _SectionCode As String
            Dim _Position_ID As String
            Dim _TimeDate As String
            Dim _ShiftName As String
            Dim _ShiftName_Old As String
            Dim _Description_VN As String
            Dim _Description_EV As String
            Dim _InsertBy As String
            Dim _InsertDate As String
            Dim _UpdateBy As String
            Dim _UpdateDate As String
            If Employee_ID <> String.Empty Then
                _Employee_ID = "N'" + Employee_ID + "'"
            Else
                _Employee_ID = "null"
            End If
            If SectionCode <> String.Empty Then
                _SectionCode = "N'" + SectionCode + "'"
            Else
                _SectionCode = "null"
            End If
            If Position_ID <> String.Empty Then
                _Position_ID = "N'" + Position_ID + "'"
            Else
                _Position_ID = "null"
            End If
            If TimeDate <> DateTime.MinValue Then
                _TimeDate = "N'" + kn.DateTimeToString(TimeDate) + "'"
            Else
                _TimeDate = "null"
            End If
            If ShiftName <> String.Empty Then
                _ShiftName = "N'" + ShiftName + "'"
            Else
                _ShiftName = "null"
            End If
            If ShiftName_Old <> String.Empty Then
                _ShiftName_Old = "N'" + ShiftName_Old + "'"
            Else
                _ShiftName_Old = "null"
            End If
            If Description_VN <> String.Empty Then
                _Description_VN = "N'" + Description_VN + "'"
            Else
                _Description_VN = "null"
            End If
            If Description_EV <> String.Empty Then
                _Description_EV = "N'" + Description_EV + "'"
            Else
                _Description_EV = "null"
            End If
            _InsertBy = "'" + InsertBy + "'"
            If InsertDate <> DateTime.MinValue Then
                _InsertDate = "N'" + kn.DateTimeToString(InsertDate) + "'"
            Else
                _InsertDate = "null"
            End If
            _UpdateBy = "'" + UpdateBy + "'"
            If UpdateDate <> DateTime.MinValue Then
                _UpdateDate = "N'" + kn.DateTimeToString(UpdateDate) + "'"
            Else
                _UpdateDate = "null"
            End If
            Dim sql As String = String.Empty
            sql = "INSERT INTO [HR_EmpRegisTimeSheet]([Employee_ID],[SectionCode],[Position_ID],[TimeDate],[ShiftName],[ShiftName_Old],[Description_VN],[Description_EV],[InsertBy],[InsertDate],[UpdateBy],[UpdateDate])VALUES(" & _
            _Employee_ID + "," + _SectionCode + "," + _Position_ID + "," + _TimeDate + "," + _ShiftName + "," + _ShiftName_Old + "," + _Description_VN + "," + _Description_EV + "," + _InsertBy + "," + _InsertDate + "," + _UpdateBy + "," + _UpdateDate + ")"
            Return sql
        End Function

        Public Function GetSQLUpdate() As String
            Dim _Employee_ID As String
            Dim _SectionCode As String
            Dim _Position_ID As String
            Dim _TimeDate As String
            Dim _ShiftName As String
            Dim _ShiftName_Old As String
            Dim _Description_VN As String
            Dim _Description_EV As String
            Dim _InsertBy As String
            Dim _InsertDate As String
            Dim _UpdateBy As String
            Dim _UpdateDate As String
            If Employee_ID <> String.Empty Then
                _Employee_ID = "N'" + Employee_ID + "'"
            Else
                _Employee_ID = "null"
            End If
            If SectionCode <> String.Empty Then
                _SectionCode = "N'" + SectionCode + "'"
            Else
                _SectionCode = "null"
            End If
            If Position_ID <> String.Empty Then
                _Position_ID = "N'" + Position_ID + "'"
            Else
                _Position_ID = "null"
            End If
            If TimeDate <> DateTime.MinValue Then
                _TimeDate = "N'" + kn.DateTimeToString(TimeDate) + "'"
            Else
                _TimeDate = "null"
            End If
            If ShiftName <> String.Empty Then
                _ShiftName = "N'" + ShiftName + "'"
            Else
                _ShiftName = "null"
            End If
            If ShiftName_Old <> String.Empty Then
                _ShiftName_Old = "N'" + ShiftName_Old + "'"
            Else
                _ShiftName_Old = "null"
            End If
            If Description_VN <> String.Empty Then
                _Description_VN = "N'" + Description_VN + "'"
            Else
                _Description_VN = "null"
            End If
            If Description_EV <> String.Empty Then
                _Description_EV = "N'" + Description_EV + "'"
            Else
                _Description_EV = "null"
            End If
            _InsertBy = "'" + InsertBy + "'"
            If InsertDate <> DateTime.MinValue Then
                _InsertDate = "N'" + kn.DateTimeToString(InsertDate) + "'"
            Else
                _InsertDate = "null"
            End If
            _UpdateBy = "'" + UpdateBy + "'"
            If UpdateDate <> DateTime.MinValue Then
                _UpdateDate = "N'" + kn.DateTimeToString(UpdateDate) + "'"
            Else
                _UpdateDate = "null"
            End If
            Dim sql As String = String.Empty
            sql = "UPDATE [HR_EmpRegisTimeSheet] SET [Employee_ID]=" + _Employee_ID + ",[SectionCode]=" + _SectionCode + ",[Position_ID]=" + _Position_ID + ",[TimeDate]=" + _TimeDate + ",[ShiftName]=" + _ShiftName + ",[ShiftName_Old]=" + _ShiftName_Old + ",[Description_VN]=" + _Description_VN + ",[Description_EV]=" + _Description_EV + ",[InsertBy]=" + _InsertBy + ",[InsertDate]=" + _InsertDate + ",[UpdateBy]=" + _UpdateBy + ",[UpdateDate]=" + _UpdateDate + " WHERE [Employee_ID]=" + _Employee_ID + " and [TimeDate]=" + _TimeDate
            Return sql
        End Function

        Public Function GetSQLDelete() As String
            Dim sql As String = String.Empty
            sql = "DELETE FROM [HR_EmpRegisTimeSheet] WHERE [Employee_ID]=" + _Employee_ID + " and [TimeDate]=" + _TimeDate
            Return sql
        End Function

        Public Shared Function NewHR_EmpRegisTimeSheet(ByVal Employee_ID As System.String, ByVal TimeDate As System.DateTime) As HR_EmpRegisTimeSheet
            Dim newEntity As New HR_EmpRegisTimeSheet
            newEntity._employee_ID = Employee_ID
            newEntity._timeDate = TimeDate
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

        Public Property SectionCode() As System.String
            Get
                Return _sectionCode
            End Get
            Set(ByVal value As System.String)
                _sectionCode = value
            End Set
        End Property

        Public Property Position_ID() As System.String
            Get
                Return _position_ID
            End Get
            Set(ByVal value As System.String)
                _position_ID = value
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

        Public Property ShiftName() As System.String
            Get
                Return _shiftName
            End Get
            Set(ByVal value As System.String)
                _shiftName = value
            End Set
        End Property

        Public Property ShiftName_Old() As System.String
            Get
                Return _shiftName_Old
            End Get
            Set(ByVal value As System.String)
                _shiftName_Old = value
            End Set
        End Property

        Public Property Description_VN() As System.String
            Get
                Return _description_VN
            End Get
            Set(ByVal value As System.String)
                _description_VN = value
            End Set
        End Property

        Public Property Description_EV() As System.String
            Get
                Return _description_EV
            End Get
            Set(ByVal value As System.String)
                _description_EV = value
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

        Public Shared Function GetHR_EmpRegisTimeSheet(ByVal Employee_ID As System.String, ByVal TimeDate As System.DateTime) As HR_EmpRegisTimeSheet
            Return New HR_EmpRegisTimeSheet(Employee_ID, TimeDate)
        End Function

        Public Shared Function GetHR_EmpRegisTimeSheetAll() As HR_EmpRegisTimeSheet()
            Dim kn As New connect(DbSetting.dataPath)
            Dim table As DataTable = kn.ReadData("SELECT * FROM HR_EmpRegisTimeSheet", "abc")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisTimeSheets(table.Rows.Count - 1) As HR_EmpRegisTimeSheet
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisTimeSheets(i) = New HR_EmpRegisTimeSheet(dr)
                    i += 1
                Next
                GetHR_EmpRegisTimeSheetAll = HR_EmpRegisTimeSheets
            End If
        End If
    End Function

    Public Shared Function GetHR_EmpRegisTimeSheetDynamic(ByVal WhereCondition As String, ByVal OrderByExpression As String) As HR_EmpRegisTimeSheet()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition", "@OrderByExpression"}
        Dim oj() As Object = {WhereCondition, OrderByExpression}
        Dim tp() As String = {"NVarChar", "NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisTimeSheetsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisTimeSheets(table.Rows.Count - 1) As HR_EmpRegisTimeSheet
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisTimeSheets(i) = New HR_EmpRegisTimeSheet(dr)
                    i += 1
                Next
                GetHR_EmpRegisTimeSheetDynamic = HR_EmpRegisTimeSheets
            End If
        End If
    End Function

    Public Shared Function GetHR_EmpRegisTimeSheetDynamic(ByVal WhereCondition As String) As HR_EmpRegisTimeSheet()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisTimeSheetsDynamic", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisTimeSheets(table.Rows.Count - 1) As HR_EmpRegisTimeSheet
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisTimeSheets(i) = New HR_EmpRegisTimeSheet(dr)
                    i += 1
                Next
                GetHR_EmpRegisTimeSheetDynamic = HR_EmpRegisTimeSheets
            End If
        End If
    End Function

    Public Shared Function GetHR_EmpRegisTimeSheetFullDynamic(ByVal sql As String) As HR_EmpRegisTimeSheet()
        Dim kn As New connect(DbSetting.dataPath)
        Dim table As DataTable = kn.ReadData(sql, "HR_EmpRegisTimeSheet")
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisTimeSheets(table.Rows.Count - 1) As HR_EmpRegisTimeSheet
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisTimeSheets(i) = New HR_EmpRegisTimeSheet(dr)
                    i += 1
                Next
                GetHR_EmpRegisTimeSheetFullDynamic = HR_EmpRegisTimeSheets
            End If
        End If
    End Function

    Public Shared Function DeleteHR_EmpRegisTimeSheetsDynamic(ByVal WhereCondition As String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@WhereCondition"}
        Dim oj() As Object = {WhereCondition}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmpRegisTimeSheetsDynamic", name, oj, tp)
    End Function

    Public Shared Function GetHR_EmpRegisTimeSheetByAndEmployee_ID(ByVal Employee_ID As System.String) As HR_EmpRegisTimeSheet()
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Dim table As DataTable = kn.ExecStoreReturnTable("dbo.usp_SelectHR_EmpRegisTimeSheetsByAndEmployee_ID", name, oj, tp)
        If Not IsNothing(table) Then
            If table.Rows.Count > 0 Then
                Dim i As Integer = 0
                Dim HR_EmpRegisTimeSheets(table.Rows.Count - 1) As HR_EmpRegisTimeSheet
                For Each dr As DataRow In table.Rows
                    HR_EmpRegisTimeSheets(i) = New HR_EmpRegisTimeSheet(dr)
                    i += 1
                Next
                GetHR_EmpRegisTimeSheetByAndEmployee_ID = HR_EmpRegisTimeSheets
            End If
        End If
    End Function

    Public Shared Function DeleteHR_EmpRegisTimeSheetByAndEmployee_ID(ByVal Employee_ID As System.String) As Integer
        Dim kn As New connect(DbSetting.dataPath)
        Dim name() As String = {"@Employee_ID"}
        Dim oj() As Object = {Employee_ID}
        Dim tp() As String = {"NVarChar"}
        Return kn.ExecStore("dbo.usp_DeleteHR_EmpRegisTimeSheetsByAndEmployee_ID", name, oj, tp)
    End Function

    Public Shared Function Search(ByVal erts() As HR_EmpRegisTimeSheet, ByVal Employee_ID As String) As HR_EmpRegisTimeSheet()
        Dim arl As New ArrayList
        For Each HR_EmpRegisTimeSheet1 As HR_EmpRegisTimeSheet In erts
            If HR_EmpRegisTimeSheet1.Employee_ID = Employee_ID Then
                arl.Add(HR_EmpRegisTimeSheet1)
            End If
        Next
        Dim HR_EmpRegisTimeSheet_Return(arl.Count - 1) As HR_EmpRegisTimeSheet
        For i As Integer = 0 To arl.Count - 1
            HR_EmpRegisTimeSheet_Return(i) = arl(i)
        Next
        Return HR_EmpRegisTimeSheet_Return
    End Function

    Public Shared Function Search(ByVal erts() As HR_EmpRegisTimeSheet, ByVal Employee_ID As String, ByVal TimeDate As DateTime) As HR_EmpRegisTimeSheet()
        Dim arl As New ArrayList
        For Each HR_EmpRegisTimeSheet1 As HR_EmpRegisTimeSheet In erts
            If HR_EmpRegisTimeSheet1.Employee_ID = Employee_ID And HR_EmpRegisTimeSheet1.TimeDate = TimeDate Then
                arl.Add(HR_EmpRegisTimeSheet1)
            End If
        Next
        Dim HR_EmpRegisTimeSheet_Return(arl.Count - 1) As HR_EmpRegisTimeSheet
        For i As Integer = 0 To arl.Count - 1
            HR_EmpRegisTimeSheet_Return(i) = arl(i)
        Next
        Return HR_EmpRegisTimeSheet_Return
    End Function

End Class
#End Region