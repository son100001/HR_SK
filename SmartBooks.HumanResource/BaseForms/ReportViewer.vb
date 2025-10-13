Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportViewer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.DisplayGroupTree = False
        Me.crViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crViewer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crViewer.Location = New System.Drawing.Point(0, 0)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.ReportSource = Nothing
        Me.crViewer.Size = New System.Drawing.Size(884, 553)
        Me.crViewer.TabIndex = 0
        '
        'ReportViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(884, 553)
        Me.Controls.Add(Me.crViewer)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ReportViewer"
        Me.Text = "Print Preview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private rptDocument As ReportDocument
    Private paramDiscreteValue As ParameterDiscreteValue
    Private paramValues As ParameterValues

    Public Overloads Sub ShowReport(ByVal strReportFile As String, ByVal pValues() As DateTime)
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
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Overloads Sub ShowReport(ByVal strReportFile As String, ByVal pValues() As DateTime, ByVal pValues_str() As String)
        Dim intCounter As Integer

        rptDocument = New ReportDocument
        paramDiscreteValue = New ParameterDiscreteValue
        paramValues = New ParameterValues

        Try
            'Load the report
            rptDocument.Load(strReportFile)

            'Check if there are parameters or not in report.
            intCounter = rptDocument.DataDefinition.ParameterFields.Count
            Dim n As Integer = 0
            If intCounter > 0 Then
                For i As Integer = 0 To pValues.Length - 1
                    paramDiscreteValue.Value = pValues(i)
                    paramValues = rptDocument.DataDefinition.ParameterFields(i).CurrentValues
                    paramValues.Add(paramDiscreteValue)
                    rptDocument.DataDefinition.ParameterFields(i).ApplyCurrentValues(paramValues)
                Next
                For j As Integer = pValues.Length To (pValues.Length + pValues_str.Length) - 1
                    paramDiscreteValue.Value = pValues_str(n)
                    paramValues = rptDocument.DataDefinition.ParameterFields(j).CurrentValues
                    paramValues.Add(paramDiscreteValue)
                    rptDocument.DataDefinition.ParameterFields(j).ApplyCurrentValues(paramValues)
                    n += 1
                Next
            End If

            'Set the connection information to ConInfo object so that we can apply the connection information on each table in the report
            ReportCommon.SetDBLogonForReport(ReportCommon.GetConnectionInfo, rptDocument)

            'Re setting control 
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Overloads Sub ShowReport(ByVal strReportFile As String)
        Dim intCounter As Integer

        rptDocument = New ReportDocument
        'paramDiscreteValue = New ParameterDiscreteValue
        'paramValues = New ParameterValues

        Try
            'Load the report
            rptDocument.Load(strReportFile)

            'Check if there are parameters or not in report.            

            'Set the connection information to ConInfo object so that we can apply the connection information on each table in the report
            ReportCommon.SetDBLogonForReport(ReportCommon.GetConnectionInfo, rptDocument)

            'Re setting control 
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Overloads Sub ShowReport(ByVal strReportFile As String, ByVal pValues() As Integer)
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
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Overloads Sub ShowReport(ByVal strReportFile As String, ByVal pValues() As String)
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
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Overloads Sub ShowReport(ByVal strReportFile As String, ByVal pValues() As Integer, ByVal pValues1() As String)
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

                For j As Integer = 0 To pValues1.Length - 1
                    paramDiscreteValue.Value = pValues1(j)
                    paramValues = rptDocument.DataDefinition.ParameterFields(j).CurrentValues
                    paramValues.Add(paramDiscreteValue)
                    rptDocument.DataDefinition.ParameterFields(j).ApplyCurrentValues(paramValues)
                Next
            End If

            'Set the connection information to ConInfo object so that we can apply the connection information on each table in the report
            ReportCommon.SetDBLogonForReport(ReportCommon.GetConnectionInfo, rptDocument)

            'Re setting control 
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Overloads Sub ShowReport(ByVal strReportFile As String, ByVal pValues() As Object)
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
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Overloads Sub ShowReportWithSub(ByVal strReportFile As String, ByVal pValues() As DateTime, ByVal pSubValues() As DateTime)
        Dim intCounter As Integer
        Dim intSubCounter As Integer

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

            ''Sub Report - 9.2 not supported
            'Dim paramDiscreteValueSub = New ParameterDiscreteValue
            'Dim paramValuesSub = New ParameterValues
            'For Each mSubDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument In rptDocument.Subreports
            '    intSubCounter = mSubDocument.ParameterFields.Count

            '    If intSubCounter > 0 Then
            '        For i As Integer = 0 To pSubValues.Length - 1
            '            paramDiscreteValueSub.Value = pSubValues(i)
            '            paramValuesSub = mSubDocument.DataDefinition.ParameterFields(i).CurrentValues
            '            paramValuesSub.Add(paramDiscreteValueSub)
            '            mSubDocument.DataDefinition.ParameterFields(i).ApplyCurrentValues(paramValuesSub)
            '        Next
            '    End If
            'Next

            'Set the connection information to ConInfo object so that we can apply the connection information on each table in the report
            ReportCommon.SetDBLogonForReport(ReportCommon.GetConnectionInfo, rptDocument)

            'Re setting control 
            crViewer.ReportSource = Nothing

            'Set the current report object to report.
            crViewer.ReportSource = rptDocument

            'Show the report
            crViewer.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
