#Region " Imports "

Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports Microsoft.ApplicationBlocks.Data

Imports SmartBooks.General

#End Region

#Region " Enums "

Public Enum DataType
    [String] = 0
    [Numeric] = 1
    [DateTime] = 2
    [Boolean] = 3
    [Other] = 4
End Enum

Public Enum FormType
    List = 0
    Voucher = 1
End Enum

#End Region

Public Class Common

    ' GetXMLDocument: 
    Public Shared Function GetXMLDocument(ByVal xmlFile As String) As XDocument
        If Not File.Exists(xmlFile) Then Return Nothing
        Using xmlReader As XmlTextReader = New XmlTextReader(xmlFile) With {.EntityHandling = EntityHandling.ExpandEntities, .XmlResolver = New XmlUrlResolver, .WhitespaceHandling = WhitespaceHandling.None}
            Dim xDoc As XDocument = XDocument.Load(xmlReader)
            xmlReader.Close()
            Return xDoc
        End Using
    End Function

    ' GetXMLAttribute: 
    Public Shared Function GetXMLAttribute(ByVal element As XElement, ByVal name As XName) As String
        If (element Is Nothing) Then Return String.Empty
        If Not element.Attribute(name.ToString().ToLower()) Is Nothing Then
            Return element.Attribute(name.ToString().ToLower()).Value
        Else
            Return String.Empty
        End If
    End Function

    ' GetOptionValue: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "value"
    Public Shared Function GetXMLOptionValue(ByVal fileName As String, ByVal optionID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("option") Where GetXMLAttribute(e, "name").ToLower.Trim = optionID.ToLower.Trim Select GetXMLAttribute(e, "value")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ' GetFieldTableID: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "table_id"
    Public Shared Function GetXMLFieldTableID(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "table_id")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ' GetFieldGridID: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "grid_id"
    Public Shared Function GetXMLFieldGridID(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "grid_id")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ' GetFieldGridID: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "column_id"
    Public Shared Function GetXMLFieldColumnID(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "column_id")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    '
    ' GetFieldPrimaryKey: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "isPrimaryKey"

    Public Shared Function GetXMLFieldPrimaryKey(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "isPrimaryKey")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    ' GetFieldCell: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "cell"

    Public Shared Function GetXMLFieldCell(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "cell")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    ' GetFieldWidth: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "width"

    Public Shared Function GetXMLFieldWidth(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "width")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    ' GetFieldDataFormat: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "DataFormat"

    Public Shared Function GetXMLFieldDataFormat(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "DataFormat")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ' GetFieldOperator: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "Operator"
    Public Shared Function GetXMLFieldOperator(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)
            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, "v")).FirstOrDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    ' GetFieldOperator: filename: xmlfilepat; return a valueattribute; inputed: nameattribute = "option", nameattribute = "Operator"
    Public Shared Function GetXMLFieldTitleLanguage(ByVal fileName As String, ByVal fieldID As String) As String
        Try
            Dim xmlDoc As XDocument = GetXMLDocument(fileName)

            Return (From e In xmlDoc.Descendants("field") Where GetXMLAttribute(e, "name").ToLower.Trim = fieldID.ToLower.Trim Select GetXMLAttribute(e, XMLLanguage())).FirstOrDefault

        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Shared ReadOnly Property XMLLanguage() As String
        Get
            Select Case DBConnection.Language.ToLower
                Case "vn"
                    Return "v"
                Case "en"
                    Return "e"
                Case "kr"
                    Return "k"
                Case Else
                    Return "v"
            End Select
        End Get
    End Property
























    Public Shared Sub SaveExcelFile(ByVal fileName As String, ByVal fileStream As MemoryStream)
        Dim svFileDg As SaveFileDialog = New SaveFileDialog()
        svFileDg.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
        svFileDg.FileName = fileName
        svFileDg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
        svFileDg.RestoreDirectory = True

        If svFileDg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using fs As FileStream = New FileStream(svFileDg.FileName, FileMode.Create, FileAccess.Write)
                fileStream.Position = 0
                Dim sBytes() As Byte = New Byte(fileStream.Length - 1) {}
                fileStream.Read(sBytes, 0, sBytes.Length)
                fs.Write(sBytes, 0, sBytes.Length)
            End Using
        End If
    End Sub

    Public Shared Function GetDataType(ByVal sqlType As String) As DataType
        If String.IsNullOrEmpty(sqlType) Then Return DataType.Other
        Select Case sqlType
            Case "bit"
                Return DataType.Boolean
            Case "char", "nchar", "text", "ntext", "varchar", "nvarchar", "xml"
                Return DataType.String
            Case "datetime", "smalldatetime", "date", "time", "datetime2"
                Return DataType.DateTime
            Case Else
                Return DataType.Numeric
        End Select
    End Function

    Public Shared Function CleanInput(ByVal input As String) As String
        Return Regex.Replace(input, "[^\w\.@-]", "")
    End Function

    Public Shared Function CleanQuery(ByVal commandText As String, Optional ByVal isSelectOnly As Boolean = False) As String
        Dim voidList As List(Of String) = "drop,truncate".Split(",").ToList
        If Not isSelectOnly Then voidList.AddRange("insert,delete,update".Split(",").ToArray)

        If commandText.Split().Intersect(voidList, StringComparer.InvariantCultureIgnoreCase).Any() Then
            Return String.Empty
        End If

        Return commandText
    End Function

    Public Shared Function CheckDataSet(ByVal ds As DataSet, Optional ByVal checkTableIndex As Integer = 0) As Boolean
        If ds Is Nothing Then Return False
        If Not ds.Tables.Count > checkTableIndex Then Return False
        Return ds.Tables(checkTableIndex).Rows.Count > 0
    End Function

    Public Shared Function ExecuteDataset(ByVal commandText As String) As DataSet
        Try
            Using connection As SqlConnection = New SqlConnection(DBConnection.Connection.ConnectionString)
                Return SqlHelper.ExecuteDataset(DBConnection.Connection.ConnectionString, CommandType.Text, commandText)
            End Using
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Shared ReadOnly Property AppCommonPath() As String
        Get
            Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Common")
        End Get
    End Property


    Public Shared ReadOnly Property LanguageFile()
        Get
            Return String.Format("{0}\AppLanguage{1}.xml", AppDomain.CurrentDomain.BaseDirectory, DBConnection.Language.ToUpper)
        End Get
    End Property


    Public Shared ReadOnly Property ExcelExportConfigFile() As String
        Get
            Return String.Format("{0}\Excel\ExportConfig.xml", AppCommonPath)
        End Get
    End Property

End Class