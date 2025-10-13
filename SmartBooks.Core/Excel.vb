#Region " Imports "

Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Imports SmartBooks.General
Imports SmartBooks.Core.List

#End Region

#Region " Members "

#Region " Enums "

Public Enum FormatType
    General = 0
    HeaderLabel = 1
    ColumnLabel = 2
    GroupLabel = 3
    StringField = 4
    NumericField = 5
    DatetimeField = 6
    BooleanField = 7
    StringGroup = 8
    NumericGroup = 9
    DatetimeGroup = 10
    BooleanGroup = 11
    Other = 12
End Enum

#End Region

Public Class Excel

#Region " Export "

    Public Class Export

#Region " Public Methods "

#End Region

#Region " Private Methods "

        
        Public Sub ReleaseComObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            End Try
        End Sub

        Private Shared Function InitBase(ByVal info As GridInfo) As Boolean
            RowHeight = Common.GetXMLOptionValue(Common.ExcelExportConfigFile, "RowHeight")
            ColumnWidth = Common.GetXMLOptionValue(Common.ExcelExportConfigFile, "ColumnWidth")
            DeltaWidth = Common.GetXMLOptionValue(Common.ExcelExportConfigFile, "DeltaWidth")
            HeaderBeginRow = Common.GetXMLOptionValue(Common.ExcelExportConfigFile, "HeaderBeginRow")
            DetailBeginRow = Common.GetXMLOptionValue(Common.ExcelExportConfigFile, "DetailBeginRow")
            'BaseCurrencyFormat = Common.GetOptionValue(Common.ExcelExportConfigFile, "BaseCurrencyFormat")
            'ForeignCurrencyFormat = Common.GetOptionValue(Common.ExcelExportConfigFile, "ForeignCurrencyFormat")

            MainTitle = info.Title
            ColumnList = info.Fields
            MergeList = GetMergeList(info.Fields)
            StyleList = GetStyleList(FormType.List)
            Return True
        End Function

        Public Shared Function CreateFile(ByVal info As GridInfo) As FileContent
            If InitBase(info) Then
                Dim dataList As List(Of Object) = GetListData(info)
                If dataList Is Nothing Then Return Nothing

                Dim excelFile As New FileContent With {.FileName = String.Empty, .FileStream = Nothing}
                excelFile.FileName = String.Format("{0}.xlsx", info.Title)
                excelFile.FileStream = CreateFileStream(dataList)
                Return excelFile
            Else
                Return Nothing
            End If
        End Function

        Private Shared Function GetListData(ByVal info As GridInfo) As List(Of Object)
            Try
                Dim result As New List(Of Object)
                Dim fieldList As String = String.Join(", ", (From f In info.Fields Select f.Name.Trim).ToArray)
                Dim ds As DataSet = Common.ExecuteDataset(info.SelectCommand)

                If Common.CheckDataSet(ds) Then
                    Dim dt As DataTable = ds.Tables(0)
                    For Each r As DataRow In dt.Rows
                        result.Add(r.ItemArray)
                    Next
                    Return result
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Shared Function CreateFileStream(ByVal dataList As List(Of Object)) As MemoryStream
            Dim fileStream As New MemoryStream, spreadsheet As SpreadsheetDocument, worksheet As Worksheet, sheetData As SheetData

            spreadsheet = CreateWorkbook(fileStream)
            worksheet = spreadsheet.WorkbookPart.WorksheetParts.FirstOrDefault().Worksheet
            sheetData = worksheet.GetFirstChild(Of SheetData)()

            SetWorksheetProperty(worksheet)
            SetMasterContent(worksheet, sheetData)
            SetColumnTitle(worksheet, sheetData)
            SetDetailContent(worksheet, sheetData, dataList)

            worksheet.Save()
            spreadsheet.Close()
            Return fileStream
        End Function

        Private Shared Function CreateWorkbook(ByVal fileStream As MemoryStream) As SpreadsheetDocument
            Dim spreadSheet As SpreadsheetDocument, sharedStringTablePart As SharedStringTablePart, workbookStylesPart As WorkbookStylesPart

            spreadSheet = SpreadsheetDocument.Create(fileStream, SpreadsheetDocumentType.Workbook, False)
            spreadSheet.AddWorkbookPart()

            spreadSheet.WorkbookPart.Workbook = New Workbook()
            spreadSheet.WorkbookPart.Workbook.Save()

            sharedStringTablePart = spreadSheet.WorkbookPart.AddNewPart(Of SharedStringTablePart)()
            sharedStringTablePart.SharedStringTable = New SharedStringTable()
            sharedStringTablePart.SharedStringTable.Save()

            spreadSheet.WorkbookPart.Workbook.Sheets = New Sheets()
            spreadSheet.WorkbookPart.Workbook.Save()

            workbookStylesPart = spreadSheet.WorkbookPart.AddNewPart(Of WorkbookStylesPart)()
            workbookStylesPart.Stylesheet = New Stylesheet()
            workbookStylesPart.Stylesheet.Save()

            spreadSheet.WorkbookPart.WorkbookStylesPart.Stylesheet.InnerXml = StyleList
            spreadSheet.WorkbookPart.WorkbookStylesPart.Stylesheet.Save()

            CreateWorksheet(spreadSheet, DefaultSheetName)
            Return spreadSheet
        End Function

        Private Shared Sub CreateWorksheet(ByVal spreadsheet As SpreadsheetDocument, ByVal sheetName As String)
            Dim sheets As Sheets = spreadsheet.WorkbookPart.Workbook.GetFirstChild(Of Sheets)()
            Dim worksheetPart As WorksheetPart = spreadsheet.WorkbookPart.AddNewPart(Of WorksheetPart)()
            Dim workSheet As New Worksheet(), sheetData As New SheetData()

            workSheet.AppendChild(sheetData)
            worksheetPart.Worksheet = workSheet
            worksheetPart.Worksheet.Save()

            sheets.Append(New Sheet With {.Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart), .SheetId = (spreadsheet.WorkbookPart.Workbook.Sheets.Count() + 1), .Name = sheetName})
            spreadsheet.WorkbookPart.Workbook.Save()
        End Sub

        Private Shared Sub SetWorksheetProperty(ByVal worksheet As Worksheet)
            Dim columns As New Columns, defaultWidth As Double = ColumnWidth
            columns.InsertAt(New Column With {.Min = 1, .Max = 1, .Width = defaultWidth, .CustomWidth = True}, 0)
            worksheet.InsertAt(New SheetFormatProperties With {.DefaultRowHeight = RowHeight, .DefaultColumnWidth = defaultWidth, .DyDescent = DefaultDyDescent}, 0)
            worksheet.InsertAt(columns, 1)
        End Sub

        Private Shared Sub SetMasterContent(ByVal worksheet As Worksheet, ByVal sheetData As SheetData)
            Dim sheetViews As New SheetViews, sheetView As New SheetView
            Dim paneLine As Integer = DetailBeginRow

            MergeCell(worksheet, String.Format("{0}{1}", GetColumnName(1), HeaderBeginRow), String.Format("{0}{1}", GetColumnName(GetMergeRange()), HeaderBeginRow))
            SetStringCellValue(sheetData, 1, HeaderBeginRow, MainTitle, FormatType.HeaderLabel)
            sheetView.WorkbookViewId = 0
            sheetView.AppendChild(New Pane With {.ActivePane = PaneValues.BottomLeft, .State = PaneStateValues.Frozen, .VerticalSplit = paneLine, .TopLeftCell = String.Format("{0}{1}", GetColumnName(1), paneLine + 1)})
            sheetViews.AppendChild(sheetView)
            worksheet.InsertAt(sheetViews, 0)
        End Sub

        Private Shared Sub SetColumnTitle(ByVal worksheet As Worksheet, ByVal sheetData As SheetData)
            Dim fieldList As New List(Of GridField), column As GridField, columnIndex As Integer, rowIndex As Integer = DetailBeginRow

            fieldList = ColumnList
            For i As Integer = 0 To fieldList.Count - 1
                column = fieldList(i)
                columnIndex = i + 1
                SetColumnWidth(worksheet, columnIndex, ConvertWidth(column.Width))
                SetStringCellValue(sheetData, columnIndex, rowIndex, column.Title, FormatType.ColumnLabel)
            Next
        End Sub

        Private Shared Sub SetDetailContent(ByVal worksheet As Worksheet, ByVal sheetData As SheetData, ByVal dataList As List(Of Object))
            If dataList Is Nothing Then Return
            If dataList.Count = 0 Then Return

            Dim fieldList As New List(Of GridField), blankMerge As Integer = 0
            fieldList = ColumnList

            For i As Integer = 0 To dataList.Count - 1
                Dim data As Array = dataList(i)
                SetRowValue(worksheet, sheetData, fieldList, data, i)
            Next
        End Sub

        Private Shared Function GetStyleList(ByVal formType As FormType) As String
            Dim xDoc As XDocument = Common.GetXMLDocument(Common.ExcelExportConfigFile)
            If xDoc Is Nothing Then Return String.Empty

            Dim type As String = IIf(formType = Core.FormType.List, "lists", "vouchers")
            Dim styleXML As XElement = (From e In xDoc.Descendants(type) Select e.Element("style").Element("text")).FirstOrDefault
            If Not styleXML Is Nothing Then Return styleXML.Value.Trim
            Return String.Empty
        End Function

        Private Shared Sub SetRowValue(ByVal worksheet As Worksheet, ByVal sheetData As SheetData, ByVal columnList As List(Of GridField), ByVal rows As Array, ByVal rowIndex As UInt32)
            rowIndex += DetailBeginRow + 1
            For i As Integer = 0 To columnList.Count - 1
                Dim column As GridField = columnList(i)
                SetCellContent(sheetData, i + 1, rowIndex, column.DataType, rows(i))
            Next
        End Sub

        Private Shared Sub SetCellContent(ByVal sheetData As SheetData, ByVal columnIndex As UInt32, ByVal rowIndex As UInt32, ByVal dataType As DataType, ByVal dataValue As Object)
            Dim styleIndex As UInt32
            Select Case dataType
                Case Core.DataType.String
                    styleIndex = UInt32.Parse(FormatType.StringField)
                    SetStringCellValue(sheetData, columnIndex, rowIndex, dataValue, styleIndex)
                Case Core.DataType.Numeric
                    styleIndex = UInt32.Parse(FormatType.NumericField)
                    SetNumericCellValue(sheetData, columnIndex, rowIndex, dataValue, styleIndex)
                Case Core.DataType.DateTime
                    styleIndex = UInt32.Parse(FormatType.DatetimeField)
                    SetStringCellValue(sheetData, columnIndex, rowIndex, dataValue, styleIndex)
                Case Core.DataType.Boolean
                    styleIndex = UInt32.Parse(FormatType.BooleanField)
                    SetBooleanCellValue(sheetData, columnIndex, rowIndex, dataValue, styleIndex)
                Case Else
                    Return
            End Select
        End Sub

        Private Shared Sub SetStringCellValue(ByVal sheetData As SheetData, ByVal columnIndex As UInt32, ByVal rowIndex As UInt32, ByVal cellValue As Object, ByVal styleIndex As UInt32?)
            If IsDBNull(cellValue) Or cellValue Is Nothing Then cellValue = String.Empty
            Dim columnValue As String = cellValue.ToString.Trim
            SetCellValue(sheetData, columnIndex, rowIndex, columnValue, styleIndex, CellValues.String)
        End Sub

        Private Shared Sub SetDateCellValue(ByVal sheetData As SheetData, ByVal columnIndex As UInt32, ByVal rowIndex As UInt32, ByVal cellValue As Object, ByVal styleIndex As UInt32?)
            Dim columnValue As String = String.Empty, dataValue As New Date
            If Not (IsDBNull(cellValue) Or cellValue Is Nothing) Then
                If Date.TryParse(cellValue, dataValue) Then columnValue = dataValue.ToOADate().ToString
            End If
            SetCellValue(sheetData, columnIndex, rowIndex, columnValue, styleIndex, CellValues.Date)
        End Sub

        Private Shared Sub SetNumericCellValue(ByVal sheetData As SheetData, ByVal columnIndex As UInt32, ByVal rowIndex As UInt32, ByVal cellValue As Object, ByVal styleIndex As UInt32?)
            Dim columnValue As Decimal
            If Not (IsDBNull(cellValue) Or cellValue Is Nothing) Then
                cellValue = cellValue.ToString().Replace(",", ".").Replace(" ", "")
                Decimal.TryParse(cellValue, columnValue)
            End If
            SetCellValue(sheetData, columnIndex, rowIndex, columnValue, styleIndex, CellValues.Number)
        End Sub

        Private Shared Sub SetBooleanCellValue(ByVal sheetData As SheetData, ByVal columnIndex As UInt32, ByVal rowIndex As UInt32, ByVal cellValue As Object, ByVal styleIndex As UInt32?)
            Dim columnValue As String = "0"
            If Not (IsDBNull(cellValue) Or cellValue Is Nothing) AndAlso cellValue Then columnValue = "1"
            SetCellValue(sheetData, columnIndex, rowIndex, columnValue, styleIndex, CellValues.Number)
        End Sub

        Private Shared Sub SetCellValue(ByVal sheetData As SheetData, ByVal columnIndex As UInt32, ByVal rowIndex As UInt32, ByVal value As Object, ByVal styleIndex As UInt32, ByVal valueType As CellValues)
            Dim cellAddress As String = String.Format("{0}{1}", GetColumnName(columnIndex), rowIndex)
            Dim row As Row = sheetData.Elements(Of Row)().Where(Function(r) r.RowIndex.Value = rowIndex).FirstOrDefault()
            If row Is Nothing Then
                row = New Row() With {.RowIndex = rowIndex, .Height = RowHeight, .CustomHeight = True}
                sheetData.Append(row)
            End If
            row.InsertBefore(New Cell() With {.CellReference = cellAddress, .CellValue = New CellValue(value), .StyleIndex = styleIndex, .DataType = New EnumValue(Of CellValues)(valueType)}, Nothing)
        End Sub

        Private Shared Function GetColumnName(ByVal index As Integer) As String
            Dim remainder As Integer, columnName As String = String.Empty
            While (index > 0)
                remainder = (index - 1) Mod 26
                columnName = String.Format("{0}{1}", System.Convert.ToChar(65 + remainder), columnName)
                index = ((index - remainder) / 26)
            End While
            Return columnName
        End Function

        Private Shared Function GetColumnIndex(ByVal cellName As String) As Integer
            Dim columnName As String = GetColumnLetter(cellName)
            Dim index As Integer = 0, pow As Integer = 1
            For i As Integer = columnName.Length - 1 To 0 Step -1
                index += (Asc(columnName(i)) - 64) * pow
                pow *= 26
            Next
            Return index
        End Function

        Private Shared Function GetColumnLetter(ByVal cellName As String) As String
            Return New RegularExpressions.Regex("[A-Za-z]+").Match(cellName).Value
        End Function

        Private Shared Function ConvertWidth(ByVal width As Double) As Double
            Return Double.Parse(width / 7D)
        End Function

        Private Shared Sub SetColumnWidth(ByVal worksheet As Worksheet, ByVal columnIndex As Int32, ByVal columnWidth As Double)
            Dim columns As Columns, column As Column
            columns = worksheet.Elements(Of Columns)().FirstOrDefault()
            If columns Is Nothing Then Return
            column = (From item In columns.Elements(Of Column)() Where UInt32Value.ToUInt32(item.Min) = columnIndex Select item).FirstOrDefault

            If column Is Nothing Then
                columns.InsertBefore(New Column() With {.Min = columnIndex, .Max = columnIndex, .Width = columnWidth, .CustomWidth = True}, Nothing)
            Else
                column.Width = columnWidth
                column.CustomWidth = True
            End If
        End Sub

        Private Shared Function MergeCell(ByVal worksheet As Worksheet, ByVal beginAddress As String, ByVal endAddress As String) As Boolean
            Dim mergeCells As MergeCells
            If (worksheet.Elements(Of MergeCells)().Count() > 0) Then
                mergeCells = worksheet.Elements(Of MergeCells).First()
            Else
                mergeCells = New MergeCells()
                worksheet.InsertAfter(mergeCells, worksheet.Elements(Of SheetData)().First())
            End If
            Dim mergedCell As MergeCell = New MergeCell()
            mergedCell.Reference = New StringValue(String.Format("{0}:{1}", beginAddress, endAddress))
            mergeCells.Append(mergedCell)
            Return True
        End Function

        Private Shared Function GetMergeList(ByVal columnList As List(Of GridField)) As ArrayList
            Dim result As New ArrayList, groupRange As New ArrayList
            Dim column As GridField, columnIndex As Integer = 0

            For i As Integer = 0 To columnList.Count - 1
                Dim range As New ArrayList
                range.Add(columnIndex + 1)
                column = columnList(i)
                columnIndex += GetMergeCount(column.Width)
                range.Add(columnIndex)
                result.Add(range)
            Next

            Return result
        End Function

        Private Shared Function GetMergeRange() As Integer
            Dim mergeCount As Integer = 0, totalWidth As Double = 0
            For Each column In ColumnList
                mergeCount += 1
                totalWidth += ConvertWidth(column.Width)
                If (totalWidth > TitleMaxWidth) Then Return mergeCount
            Next
            Return If(ColumnList.Count > 3, ColumnList.Count, ColumnList.Count + 3)
        End Function

        Private Shared Function GetMergeCount(ByVal width As Double) As Integer
            If width <= 0 Then Return 0
            Dim cellWidth As Double = ConvertWidth(width)
            Return System.Math.Ceiling((cellWidth + DeltaWidth / 2) / DeltaWidth)
        End Function

        Private Shared Function GetMergePosition(ByVal beginIndex As Integer, ByVal endIndex As Integer, ByVal rowIndex As Integer) As ArrayList
            Dim position As New ArrayList
            position.Add(String.Format("{0}{1}", GetColumnName(beginIndex), rowIndex))
            position.Add(String.Format("{0}{1}", GetColumnName(endIndex), rowIndex))
            position.Add(beginIndex)
            Return position
        End Function

        Private Shared Function GetMergeContent(ByVal columnIndex As Integer, ByVal rowIndex As Integer) As ArrayList
            Dim position As New ArrayList, range As New ArrayList
            range = MergeList
            Return GetMergePosition(range(columnIndex)(0), range(columnIndex)(1), rowIndex)
        End Function

#End Region

#Region " Properties "
        Private Shared lcColumnList As New List(Of GridField), lcMergeList As New ArrayList, lcStyleList As String = String.Empty, lcMainTitle As String = String.Empty
        Private Shared lcRowHeight As Double, lcColumnWidth As Double, lcDeltaWidth As Double, lcHeaderBeginRow As Double, lcDetailBeginRow As Double
        Private Shared lcBaseCurrencyFormat As String = String.Empty, lcForeignCurrencyFormat As String = String.Empty

        Private Shared Property ColumnList() As List(Of GridField)
            Get
                Return lcColumnList
            End Get
            Set(ByVal value As List(Of GridField))
                lcColumnList = value
            End Set
        End Property

        Private Shared Property MergeList() As ArrayList
            Get
                Return lcMergeList
            End Get
            Set(ByVal value As ArrayList)
                lcMergeList = value
            End Set
        End Property

        Private Shared Property MainTitle() As String
            Set(ByVal value As String)
                lcMainTitle = value
            End Set
            Get
                Return lcMainTitle
            End Get
        End Property

        Private Shared Property StyleList() As String
            Set(ByVal value As String)
                lcStyleList = value
            End Set
            Get
                Return lcStyleList
            End Get
        End Property

        Private Shared Property RowHeight() As Double
            Get
                Return lcRowHeight
            End Get
            Set(ByVal value As Double)
                lcRowHeight = value
            End Set
        End Property

        Private Shared Property ColumnWidth() As Double
            Get
                Return lcColumnWidth
            End Get
            Set(ByVal value As Double)
                lcColumnWidth = value
            End Set
        End Property

        Private Shared Property DeltaWidth() As Double
            Get
                Return lcDeltaWidth
            End Get
            Set(ByVal value As Double)
                lcDeltaWidth = value
            End Set
        End Property

        Private Shared Property HeaderBeginRow() As Double
            Get
                Return lcHeaderBeginRow
            End Get
            Set(ByVal value As Double)
                lcHeaderBeginRow = value
            End Set
        End Property

        Private Shared Property DetailBeginRow() As Double
            Get
                Return lcDetailBeginRow
            End Get
            Set(ByVal value As Double)
                lcDetailBeginRow = value
            End Set
        End Property

        Private Shared Property BaseCurrencyFormat() As String
            Get
                Return lcBaseCurrencyFormat
            End Get
            Set(ByVal value As String)
                lcBaseCurrencyFormat = value
            End Set
        End Property

        Private Shared Property ForeignCurrencyFormat() As String
            Get
                Return lcForeignCurrencyFormat
            End Get
            Set(ByVal value As String)
                lcForeignCurrencyFormat = value
            End Set
        End Property

        Private Shared ReadOnly Property TitleMaxWidth() As Integer
            Get
                Return 120
            End Get
        End Property

        Private Shared ReadOnly Property DefaultDyDescent() As Double
            Get
                Return 0.15
            End Get
        End Property

        Private Shared ReadOnly Property DefaultSheetName() As String
            Get
                Return "Main"
            End Get
        End Property

#End Region

    End Class

#End Region

#Region " FileContent "

    Public Class FileContent
        Private lcFileName As String = String.Empty, lcFileStream As Stream = Nothing

        Public Property FileName() As String
            Get
                Return lcFileName
            End Get
            Set(ByVal value As String)
                lcFileName = value
            End Set
        End Property

        Public Property FileStream() As MemoryStream
            Get
                Return lcFileStream
            End Get
            Set(ByVal value As MemoryStream)
                lcFileStream = value
            End Set
        End Property

    End Class

#End Region

End Class

#End Region