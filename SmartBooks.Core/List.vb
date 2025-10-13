#Region " Imports "

Imports System.IO
Imports System.Xml
Imports System.Windows

Imports Janus.Windows.GridEX

#End Region

Public Class List

    Public Class ListExport
        Public Shared Function ToExcelFile(ByVal form As Windows.Forms.Form, Optional ByVal exportID As String = "") As Boolean
            Try
                Dim exportFile As Excel.FileContent = CreateFile(form, exportID)
                If Not exportFile Is Nothing AndAlso Not exportFile.FileStream Is Nothing Then
                    Common.SaveExcelFile(exportFile.FileName, exportFile.FileStream)
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Shared Function CreateFile(ByVal form As Forms.Form, ByVal exportID As String) As Excel.FileContent
            If form Is Nothing Then Return Nothing
            If String.IsNullOrEmpty(exportID) Then exportID = form.Name

            Dim info As GridInfo = Nothing
            info = GetListInfo(form, exportID)

            If info Is Nothing Then Return Nothing
            If info.Fields.Count = 0 Then Return Nothing

            Return Excel.Export.CreateFile(info)
        End Function

        Private Shared Function GetListInfo(ByVal form As Forms.Form, ByVal exportID As String) As GridInfo
            Dim result As New GridInfo, configDoc As XDocument = Common.GetXMLDocument(Common.ExcelExportConfigFile)
            If String.IsNullOrEmpty(exportID) Then Return Nothing

            Dim parentXML As XElement = (From e In configDoc.Descendants("list") Where Common.GetXMLAttribute(e, "id") = exportID Select e).FirstOrDefault
            If parentXML Is Nothing Then Return Nothing

            result.ExportID = exportID
            result.Title = form.Text.Trim
            result.FormID = form.Name.Trim
            result.GridID = Common.GetXMLAttribute(parentXML, "gridID")
            result.TableID = Common.GetXMLAttribute(parentXML, "tableID")
            result.Fields = GetListFields(form, result, parentXML)

            If Not String.IsNullOrEmpty(result.TableID) And result.Fields.Count > 0 Then
                Dim ds As DataSet = Common.ExecuteDataset(String.Format("select column_name, data_type from information_schema.columns where table_name = '{0}'", result.TableID))

                If Common.CheckDataSet(ds) Then
                    Dim dt As DataTable = ds.Tables(0)
                    For Each row As DataRow In dt.Rows
                        Dim name As String = row.Field(Of String)("column_name")
                        Dim dataType As DataType = Common.GetDataType(row.Field(Of String)("data_type"))
                        Dim field As GridField = result.Fields.Find(Function(f) f.Name.ToLower.Trim = name.ToLower.Trim)
                        If Not field Is Nothing Then field.DataType = dataType
                    Next
                End If
            End If

            result.SelectCommand = Common.CleanQuery(GetListSelectCommand(result, parentXML), True)
            Return result
        End Function

        Private Shared Function GetListFields(ByVal form As Forms.Form, ByVal listInfo As GridInfo, ByVal parentXML As XElement) As List(Of GridField)
            Dim result As New List(Of GridField)
            Dim langDoc As XDocument = Common.GetXMLDocument(Common.LanguageFile)

            If Not String.IsNullOrEmpty(listInfo.GridID) Then
                Dim gridViews() As Forms.Control = Nothing
                gridViews = form.Controls.Find(listInfo.GridID, False)

                If gridViews Is Nothing Then Return Nothing
                If gridViews.Length = 0 Then Return Nothing

                Dim gridView As GridEX = gridViews(0)
                If gridView Is Nothing Then Return Nothing

                For Each column As GridEXColumn In gridView.RootTable.Columns
                    If column.Visible AndAlso column.Width > 0 Then
                        Dim listField As New GridField
                        listField.Name = column.DataMember
                        listField.DataFormat = column.FormatString
                        listField.Title = column.Caption
                        If String.IsNullOrEmpty(listField.Title) Then listField.Title = listField.Name
                        listField.Width = column.Width
                        result.Add(listField)
                    End If
                Next
            End If

            Dim fieldXML As List(Of XElement) = parentXML.Elements("field").ToList
            If Not fieldXML Is Nothing Then
                Dim langXML As XElement = (From e In langDoc.Descendants(listInfo.ExportID) Select e).FirstOrDefault
                For Each fieldItem As XElement In fieldXML
                    Dim listField As New GridField
                    listField.Name = Common.GetXMLAttribute(fieldItem, "id")
                    listField.Width = GetFieldWidth(Common.GetXMLAttribute(fieldItem, "width"))
                    listField.DataFormat = Common.GetXMLAttribute(fieldItem, "dataFormat")
                    listField.Title = GetColumnTitle(listField.Name, langXML)

                    If String.IsNullOrEmpty(listField.Title) Then
                        Dim fieldTitle As String = GetFieldTitle(fieldItem.Element("title"))
                        If String.IsNullOrEmpty(fieldTitle) Then fieldTitle = listField.Name
                        listField.Title = fieldTitle
                    End If
                    result.RemoveAll(Function(f) f.Name = listField.Name)
                    result.Add(listField)
                Next
            End If

            Return result
        End Function

        ' GetListSelectCommand
        Private Shared Function GetListSelectCommand(ByVal info As GridInfo, ByVal parentXML As XElement) As String
            Dim commandXML As XElement = parentXML.Element("selectCommand")
            If commandXML Is Nothing Then
                Dim fieldList As String = String.Join(", ", (From f In info.Fields Select f.Name.Trim).ToArray)
                Return String.Format("select {0} from {1}", fieldList, info.TableID)
            Else
                Return commandXML.Value.Trim
            End If
        End Function

        Private Shared Function GetColumnTitle(ByVal columnID As String, ByVal langXML As XElement) As String
            Try
                Return (From e In langXML.Descendants(columnID) Select e.Value).FirstOrDefault
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

        Private Shared Function GetFieldTitle(ByVal titleXML As XElement) As String
            Try
                If titleXML Is Nothing Then Return String.Empty
                Return Common.GetXMLAttribute(titleXML, Common.XMLLanguage)
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

        Private Shared Function GetFieldWidth(ByVal width As String) As Double
            Dim value As Double = 100
            If String.IsNullOrEmpty(width) Then Return value
            If Not Double.TryParse(width, value) Then Return value
            Return value
        End Function
    End Class

    Public Class GridInfo

        Private lcTitle As String = String.Empty, lcTableID As String = String.Empty, lcFormID As String = String.Empty, lcGridID As String = String.Empty
        Private lcSelectCommand As String = String.Empty, lcExportID As String = String.Empty, lcFields As New List(Of GridField)

        Public Property Title() As String
            Get
                Return lcTitle
            End Get
            Set(ByVal value As String)
                lcTitle = value
            End Set
        End Property

        Public Property TableID() As String
            Get
                Return lcTableID
            End Get
            Set(ByVal value As String)
                lcTableID = value
            End Set
        End Property

        Public Property FormID() As String
            Get
                Return lcFormID
            End Get
            Set(ByVal value As String)
                lcFormID = value
            End Set
        End Property

        Public Property GridID() As String
            Get
                Return lcGridID
            End Get
            Set(ByVal value As String)
                lcGridID = value
            End Set
        End Property

        Public Property ExportID() As String
            Get
                Return lcExportID
            End Get
            Set(ByVal value As String)
                lcExportID = value
            End Set
        End Property

        Public Property SelectCommand() As String
            Get
                Return lcSelectCommand
            End Get
            Set(ByVal value As String)
                lcSelectCommand = value
            End Set
        End Property

        Public Property Fields() As List(Of GridField)
            Get
                Return lcFields
            End Get
            Set(ByVal value As List(Of GridField))
                lcFields = value
            End Set
        End Property

    End Class

    Public Class GridField
        Private lcName As String = String.Empty, lcTitle As String = String.Empty, lcDataType As DataType = Core.DataType.Other, lcDataFormat As String = String.Empty, lcWidth As Double = 100

        Public Property Name() As String
            Get
                Return lcName
            End Get
            Set(ByVal value As String)
                lcName = value
            End Set
        End Property

        Public Property DataType() As DataType
            Get
                Return lcDataType
            End Get
            Set(ByVal value As DataType)
                lcDataType = value
            End Set
        End Property

        Public Property DataFormat() As String
            Get
                Return lcDataFormat
            End Get
            Set(ByVal value As String)
                lcDataFormat = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return lcTitle
            End Get
            Set(ByVal value As String)
                lcTitle = value
            End Set
        End Property

        Public Property Width() As Double
            Get
                Return lcWidth
            End Get
            Set(ByVal value As Double)
                lcWidth = value
            End Set
        End Property
    End Class

End Class

