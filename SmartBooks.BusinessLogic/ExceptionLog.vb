
Public Class ExceptionLog
    Public Shared Sub MessageLog(ByVal Message As String)
        Dim dsLog As DataSet = New DataSet
        Dim dt As DataTable = New DataTable
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "Message"
        ' Add the Column to the DataColumnCollection.
        dt.Columns.Add(column)

        ' Create second column.
        column = New DataColumn
        column.DataType = System.Type.GetType("System.DateTime")
        column.ColumnName = "Log Date"
        dt.Columns.Add(column)

        Dim dr As DataRow = dt.NewRow()
        dr("Message") = Message.ToString()
        dr("Log Date") = DateTime.Today()
        dt.Rows.Add(dr)
        dsLog.Tables.Add(dt)
        dsLog.WriteXml("C:\\ErrorLog.xml")

    End Sub
End Class
