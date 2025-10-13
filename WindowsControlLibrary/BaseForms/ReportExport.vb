Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportExport
    Public Sub New()

    End Sub

    Private rptDocument As ReportDocument
    Private paramDiscreteValue As ParameterDiscreteValue
    Private paramValues As ParameterValues
    Private strReportFile As String
    Private pValues As Object
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer

    Public Overloads Sub ExportReport(ByVal strReportFile As String, ByVal pValues() As Object, ByVal addressToExport As String)
        Me.strReportFile = strReportFile
        Me.pValues = pValues
        Dim intCounter As Integer

        rptDocument = New ReportDocument
        paramDiscreteValue = New ParameterDiscreteValue
        paramValues = New ParameterValues

        Try
            'Load the report
            rptDocument.Load(strReportFile)

            'Check if there are parameters or not in report.
            intCounter = rptDocument.DataDefinition.ParameterFields.Count

            If intCounter > 0 Then
                For i As Integer = 0 To pValues.Length - 1
                    paramDiscreteValue.Value = pValues(i)
                    paramValues = rptDocument.DataDefinition.ParameterFields(i).CurrentValues
                    paramValues.Add(paramDiscreteValue)
                    rptDocument.DataDefinition.ParameterFields(i).ApplyCurrentValues(paramValues)
                Next
            End If

            'Set the connection information to ConInfo object so that we can apply the connection information on each table in the report
            ReportCommon.SetDBLogonForReport(ReportCommon.GetConnectionInfo, rptDocument)

            'Re setting control 
            'crViewer.ReportSource = Nothing

            'Set the current report object to report.
            rptDocument.ExportToDisk(ExportFormatType.PortableDocFormat, addressToExport)
        Catch ex As Exception
            Print(ex.ToString)
        End Try
    End Sub
End Class
