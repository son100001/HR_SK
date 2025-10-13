Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraTab

Public Module PublicFunction
    'Public kn As connect
    Public server As String
    Public data As String
    Public uid As String
    Public pass As String


    'Public Sub LoadCombobox(ByVal cbo As UIComboBox, ByVal tb As DataTable, ByVal Text As String, ByVal Value As String, Optional ByVal ShowAll As Boolean = False)
    '    If tb.Rows.Count <= 0 Then
    '        Exit Sub
    '    End If
    '    Dim i As Integer
    '    Dim item As UIComboBoxItem
    '    If (ShowAll) Then cbo.Items.Add("--All--", String.Empty)
    '    If (tb.Rows.Count = 0) Then Exit Sub
    '    For i = 0 To tb.Rows.Count - 1
    '        item = New UIComboBoxItem
    '        item.Text = IIf(IsDBNull(tb.Rows(i)(Text)), "", tb.Rows(i)(Text))
    '        item.Value = IIf(IsDBNull(tb.Rows(i)(Value)), "", tb.Rows(i)(Value))
    '        cbo.Items.Add(item)
    '    Next
    'End Sub

    Public Function GetColumnNameToDate(ByVal ColumnName As String) As Date
        '_MM_dd_yyyy : _01_10_2010
        Dim Result As String = ColumnName.Replace("_", "/")
        Result = Result.Substring(1, Result.Length - 1)
        Return ParseDateTime(Result)
    End Function

    Public Function ParseDateTime(ByVal value As String) As DateTime
        Dim DEFAULT_DATE_FORMAT As String = "MM/dd/yyyy"
        Dim result As DateTime
        Dim info As System.Globalization.DateTimeFormatInfo
        info = DirectCast(Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.Clone(), System.Globalization.DateTimeFormatInfo)
        info.ShortDatePattern = DEFAULT_DATE_FORMAT
        info.FullDateTimePattern = DEFAULT_DATE_FORMAT
        Try
            result = DateTime.Parse(value, info)
        Catch
            result = Date.MinValue
        End Try
        Return (result)
    End Function

    Public Function DateTimeToString(ByVal value As DateTime) As String
        Return value.ToString("MM/dd/yyyy hh:mm:ss tt")
    End Function
    Public Function DateTimeToString2(ByVal value As DateTime) As String
        Return value.ToString("MM/dd/yyyy")
    End Function
    Public Function DateTimeToString3(ByVal value As DateTime) As String
        Return value.ToString("yyyy-MM-dd")
    End Function
    Public Function DateTimeToString1(ByVal value As DateTime) As String
        Return value.ToString("yyyy/MM/dd")
    End Function
    Public Function DateTimeVietToString(ByVal value As DateTime) As String
        Return value.ToString("dd/MM/yyyy")
    End Function
    Public Function DateTimeVietToString1(ByVal value As DateTime) As String
        Return value.ToString("dd/MM/yyyy hh:mm:ss tt")
    End Function
    Public Function DateTimeToString4(ByVal value As String, ByVal accessdate As DateTime) As String
        Dim abc As String()
        Dim tt As String()
        Dim ad As String()
        Dim mm, hh As String
        Dim phut, gio As Integer
        abc = value.Split(":")
        hh = abc(0)
        mm = abc(1)
        tt = value.Split(" ")
        If tt.Length >= 2 Then
            If tt(1) = "PM" Then
                If CInt(hh) < 11 And CInt(hh) > 0 Then
                    gio = CInt(hh) + 12
                End If
            Else
                gio = CInt(hh)
            End If
        Else
            gio = CInt(hh)
        End If

        'Dim yyyy, m, dd As String
        'ad = accessdate.ToString("MM/dd/yyyy").Split("/")
        'yyyy = ad(2)
        'm = ad(0)
        'dd = ad(1)

        Return New DateTime(accessdate.Year, accessdate.Month, accessdate.Day, gio, CInt(mm), 0, 0).ToString("MM/dd/yyyy HH:mm:ss tt")
    End Function



    ''''''''' Vantk85

    Public Function CreateSQLConnectionString(ByVal ServerName As String, ByVal UserName As String, ByVal Password As String, ByVal DatabaseName As String) As String
        Return String.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False", ServerName, DatabaseName, UserName, Password)
    End Function

    Public Function CreateAccessConnectionString(ByVal accessFile As String, ByVal pass As String) As String
        Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", accessFile, pass)

    End Function

    Public Enum ObjectType
        StringType = 0
        IntType = 1
        DoubleType = 2
        DecimalType = 3
        DateType = 4
        BoolType = 5
        TimeType = 6
        DateTimeType = 7
    End Enum
    Public Function CheckDBNull(ByVal obj As Object, _
    Optional ByVal ObjectType As ObjectType = ObjectType.StringType, Optional ByVal _defaultVal As Object = Nothing) As Object
        Dim objReturn As Object
        objReturn = obj
        If ObjectType = ObjectType.StringType And IsDBNull(obj) Then
            If (_defaultVal Is Nothing) Then
                objReturn = ""
            Else
                objReturn = _defaultVal
            End If
        ElseIf ObjectType = ObjectType.IntType And IsDBNull(obj) Then
            If (_defaultVal Is Nothing) Then
                objReturn = 0
            Else
                objReturn = _defaultVal
            End If
        ElseIf ObjectType = ObjectType.DoubleType And IsDBNull(obj) Then
            If (_defaultVal Is Nothing) Then
                objReturn = 0.0
            Else
                objReturn = _defaultVal
            End If
        ElseIf ObjectType = ObjectType.DecimalType And IsDBNull(obj) Then
            If (_defaultVal Is Nothing) Then
                objReturn = 0.0
            Else
                objReturn = _defaultVal
            End If
        ElseIf ObjectType = ObjectType.DateType Then
            If (IsDBNull(obj)) Or obj.ToString.Trim = "" Then
                If (_defaultVal Is Nothing) Then
                    objReturn = New Date(1900, 1, 1)
                Else
                    objReturn = _defaultVal
                End If
            Else
                Try
                    DateTime.Parse(obj.ToString)
                Catch ex As Exception
                    Try
                        Dim year As Integer = Integer.Parse(obj.ToString)
                        objReturn = New Date(year, 1, 1)
                    Catch ex1 As Exception

                    End Try
                End Try

            End If
        ElseIf ObjectType = ObjectType.BoolType And IsDBNull(obj) Then
            objReturn = False
        End If
        Return objReturn
    End Function

    Public Function checkColumnValue(ByVal columns As DataColumnCollection, ByVal row As DataRow, ByVal columnName As String, Optional ByVal ObjectType As ObjectType = PublicFunction.ObjectType.StringType) As Object
        If columns.IndexOf(columnName) >= 0 Then
            Return CheckDBNull(row(columnName), PublicFunction.ObjectType.StringType)
        End If
        Return ""
    End Function

    Dim aText As String

#Region "XuLyNgonNgu ContextMenu"
    ' Start ##############

    'Public Sub exportLangText(ByRef langDic As DataTable, ByVal ctrls As System.Windows.Forms.Control.ControlCollection, ByVal parentText As String)
    '    'DuyetQuaCacControls
    '    For Each myControl As Control In ctrls
    '        If (TypeOf myControl Is Panel Or TypeOf myControl Is GroupBox Or TypeOf myControl Is TabControl Or TypeOf myControl Is TabPage Or TypeOf myControl Is UltraTabControl) Then
    '            If TypeOf myControl Is UltraTabControl Then
    '                For Each tabC As UltraTab In CType(myControl, UltraTabControl).Tabs
    '                    langDic.Rows.Add(New Object() {String.Format("{0}.{1}.{2}", parentText, myControl.Name, tabC.TabPage.Name), tabC.Text})
    '                Next
    '            Else
    '                parentText = parentText.Replace("." + myControl.Name, "")
    '                getTextFromControl(langDic, myControl, parentText)
    '            End If
    '            exportLangText(langDic, myControl.Controls, parentText)
    '        ElseIf (TypeOf myControl Is GridEX) Then
    '            'DuyetQuaColumns
    '            Dim myGrid As GridEX = CType(myControl, GridEX)
    '            If (Not IsNothing(myGrid.RootTable)) Then
    '                getTextFromContextMenu(langDic, myControl, parentText)
    '                For Each col As GridEXColumn In myGrid.RootTable.Columns
    '                    ' KiemTra
    '                    getTextFromColumnTitle(langDic, col, parentText & "." & myGrid.Name)
    '                Next
    '            End If
    '        End If
    '        If TypeOf myControl Is Label Or TypeOf myControl Is Button _
    '                Or TypeOf myControl Is Janus.Windows.EditControls.UIButton _
    '                Or TypeOf myControl Is Janus.Windows.EditControls.UIComboBox Then
    '            getTextFromControl(langDic, myControl, parentText)
    '        End If
    '    Next
    'End Sub

    Public Sub changeLangForm(ByVal langDic As DataTable, ByVal ctrls As System.Windows.Forms.Control.ControlCollection, ByVal parentText As String)
        'DuyetQuaCacControls
        For Each myControl As Control In ctrls
            If (TypeOf myControl Is Panel Or TypeOf myControl Is GroupBox Or TypeOf myControl Is TabControl Or TypeOf myControl Is TabPage Or TypeOf myControl Is RadioButton Or TypeOf myControl Is CheckBox Or TypeOf myControl Is XtraTabControl) Then
                If TypeOf myControl Is XtraTabControl Then
                    For Each tabC As XtraTabPage In CType(myControl, XtraTabControl).TabPages
                        aText = String.Format("{0}.{1}.{2}", parentText, myControl.Name, tabC.Name)
                        tabC.Text = getLangDicText(langDic, aText)
                    Next
                End If
                changeLangForm(langDic, myControl.Controls, parentText)
            ElseIf (TypeOf myControl Is GridControl) Then
                'DuyetQuaColumns
                Dim myGridControl As GridControl = CType(myControl, GridControl)
                Dim myGridView As GridView = myGridControl.FocusedView
                If Not IsNothing(myGridView) Then
                    setTextToContextMenu(langDic, myControl, parentText)
                    For Each col As Columns.GridColumn In myGridView.Columns
                        ' KiemTra
                        setColumnTitle(langDic, col, parentText)
                    Next
                End If
            End If
            If TypeOf myControl Is Label Or TypeOf myControl Is Button _
                    Or TypeOf myControl Is DevExpress.XtraEditors.SimpleButton Then
                setTextToControl(langDic, myControl, parentText)
            End If
        Next
    End Sub
    ' End ##############
#End Region

#Region "XuLyNgonNgu ContextMenu"
    ' Start ##############
    Public Sub getTextFromContextMenu(ByRef langDic As DataTable, ByVal myControl As Control, ByVal parentText As String)
        If (Not IsNothing(myControl.ContextMenu) And myControl.Tag <> "NoLang") Then
            Dim myContextMenu As ContextMenu = myControl.ContextMenu
            Dim _mnIndex As Integer = 0
            For Each _mnItem As MenuItem In myContextMenu.MenuItems()
                aText = getKey(myControl, parentText)
                langDic.Rows.Add(New Object() {String.Format("{0}.Menu.{1}", aText, _mnIndex), _mnItem.Text})
                _mnIndex += 1
            Next
        End If
    End Sub

    Public Sub setTextToContextMenu(ByRef langDic As DataTable, ByVal myControl As Control, ByVal parentText As String)
        If (Not IsNothing(myControl.ContextMenu) And myControl.Tag <> "NoLang") Then
            Dim myContextMenu As ContextMenu = myControl.ContextMenu
            Dim _mnIndex As Integer = 0
            For Each _mnItem As MenuItem In myContextMenu.MenuItems()
                aText = getKey(myControl, parentText)
                _mnItem.Text = getLangDicText(langDic, String.Format("{0}.Menu.{1}", aText, _mnIndex))
                _mnIndex += 1
            Next
        End If
    End Sub
    ' End ##############
#End Region


#Region "XuLyNgonNgu Grid"
    ' Start ##############
    'Private Sub getTextFromColumnTitle(ByRef langDic As DataTable, ByVal myControl As GridEXColumn, ByVal parentText As String)

    '    Dim _regex As Regex = New Regex("s[0-9]+")
    '    Dim _regex1 As Regex = New Regex("SalaryComponent[0-9]+")
    '    Dim _regex2 As Regex = New Regex("AllowanceNonContract[0-9]+")
    '    Dim _regex3 As Regex = New Regex("Rate[0-9]+")
    '    Dim _regex4 As Regex = New Regex("Allowance[0-9]+")

    '    aText = AdjustCaptionCol(myControl)
    '    If (_regex.IsMatch(aText) Or _regex1.IsMatch(aText) Or _regex2.IsMatch(aText) Or _regex3.IsMatch(aText) Or _regex4.IsMatch(aText)) Then
    '        Exit Sub
    '    End If
    '    langDic.Rows.Add(New Object() {parentText + "." + aText, myControl.Caption})
    'End Sub

    Private Sub setColumnTitle(ByVal langDic As DataTable, ByVal myControl As GridColumn, ByVal parentText As String)

        'Dim _regex As Regex = New Regex("s[0-9]+")
        'Dim _regex1 As Regex = New Regex("SalaryComponent[0-9]+")
        'Dim _regex2 As Regex = New Regex("AllowanceNonContract[0-9]+")
        'Dim _regex3 As Regex = New Regex("Rate[0-9]+")
        'Dim _regex4 As Regex = New Regex("Allowance[0-9]+")

        aText = AdjustCaptionCol(myControl)
        'If (_regex.IsMatch(aText) Or _regex1.IsMatch(aText) Or _regex2.IsMatch(aText) Or _regex3.IsMatch(aText) Or _regex4.IsMatch(aText)) Then
        '    Exit Sub
        'End If
        myControl.Caption = getLangDicText(langDic, parentText + "." + aText)
    End Sub
    ' End ##############
#End Region




#Region "XuLyNgonNgu Control"
    ' Start ##############
    Public Sub getTextFromControl(ByRef langDic As DataTable, ByVal myControl As Control, ByVal parentText As String)
        aText = getKey(myControl, parentText)
        langDic.Rows.Add(New Object() {aText, myControl.Text})
        getTextFromContextMenu(langDic, myControl, parentText)
        'If Not langDic.ContainsKey(aText) Then
        '    langDic.Add(aText, myControl.Text)
        'End If
    End Sub
    Public Sub getTextTab(ByRef langDic As DataTable, ByVal myControl As Control, ByVal parentText As String)
        aText = getKey(myControl, parentText)
        langDic.Rows.Add(New Object() {aText, myControl.Text})
        getTextFromContextMenu(langDic, myControl, parentText)
        'If Not langDic.ContainsKey(aText) Then
        '    langDic.Add(aText, myControl.Text)
        'End If
    End Sub


    Public Sub setTextToControl(ByVal langDic As DataTable, ByVal myControl As Control, ByVal parentText As String)
        ' Ghi DisplayText
        aText = getKey(myControl, parentText)
        If TypeOf myControl Is Label Or TypeOf myControl Is Button Or TypeOf myControl Is CheckBox Or TypeOf myControl Is RadioButton Or TypeOf myControl Is GroupBox Then
            If TypeOf myControl Is CheckBox Or TypeOf myControl Is RadioButton Or TypeOf myControl Is GroupBox Then
                If myControl.Text.Trim <> String.Empty Then
                    myControl.Text = getLangDicText(langDic, aText, myControl.Text)
                End If
            Else
                myControl.Text = getLangDicText(langDic, aText, myControl.Text)
            End If
        Else
            myControl.Text = getLangDicText(langDic, aText)
        End If

        setTextToContextMenu(langDic, myControl, parentText)
    End Sub
    ' End ##############
#End Region


    Public Function AdjustCaption(ByVal ctrl As Control) As String
        Dim text As String = ctrl.Name
        If (Not IsNothing(ctrl.Tag)) Then
            text = ctrl.Tag.ToString
        End If
        If TypeOf ctrl Is GroupBox Then
            Return IIf(Left(text, 2) = "gb", text.Substring(2), text)
        ElseIf (text.StartsWith("lbl") Or text.StartsWith("btn")) Then
            Return text.Substring(3)
        ElseIf (text.StartsWith("lb") Or text.StartsWith("bt")) Then
            Return text.Substring(2)
        End If
        Return text
    End Function

    Public Function AdjustCaptionCol(ByVal ctrl As Columns.GridColumn) As String
        Dim text As String = ctrl.FieldName
        If (Not IsNothing(ctrl.FieldName)) Then
            text = ctrl.FieldName
        End If
        Return text
    End Function

    Private Function getKey(ByVal myControl As Control, ByVal parentText As String) As String
        If (myControl.Text = "" And Not TypeOf myControl Is GridControl) Then
            Return ""
        End If
        If (parentText <> "") Then
            parentText += "."
        End If
        Return parentText + AdjustCaption(myControl)
    End Function

    Public Function getLangDicText(ByVal langDic As DataTable, ByVal key As String) As String
        Dim _rows As DataRow() = langDic.Select(String.Format("key = '{0}'", key))
        If _rows.Length > 0 Then
            Return _rows(0)(1) 'UuTienIDChiDinh
        Else 'NeuKoTimThayThiHienLayIDChung
            Dim _regex As Regex = New Regex("[^\.]+$")
            key = _regex.Match(key).Value
            _rows = langDic.Select(String.Format("key = 'General.{0}'", key))
            If _rows.Length > 0 Then
                Return _rows(0)(1) 'UuTienIDChiDinh
            Else 'NeuKoTimThayThiHienLayIDChung
                Return key
            End If
        End If
    End Function
    Public Function getLangDicText(ByVal langDic As DataTable, ByVal key As String, ByVal text As String) As String
        Dim _rows As DataRow() = langDic.Select(String.Format("key = '{0}'", key))
        If _rows.Length > 0 Then
            Return _rows(0)(1) 'UuTienIDChiDinh
        Else 'NeuKoTimThayThiHienLayIDChung
            Dim _regex As Regex = New Regex("[^\.]+$")
            key = _regex.Match(key).Value
            _rows = langDic.Select(String.Format("key = 'General.{0}'", key))
            If _rows.Length > 0 Then
                Return _rows(0)(1) 'UuTienIDChiDinh
            Else 'NeuKoTimThayThiHienLayIDChung
                Return key
            End If
        End If
    End Function

End Module
