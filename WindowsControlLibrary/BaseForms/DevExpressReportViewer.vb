
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraBars.Ribbon

Public Class DevExpressReportViewer
    Dim linkReport As String = ""
    Public Sub New(ByVal link As String)
        linkReport = link
        InitializeComponent()
    End Sub

    Private Sub DevExpressReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim ReportViewer1 As New XtraReport()
        'Dim ribbonPreview As New PrintPreviewRibbonFormEx()


        'ReportViewer1.LoadLayout(linkReport)
        'ribbonPreview.PrintingSystem = ReportViewer1.PrintingSystem

        'Dim mergedPage As RibbonPage
        'mergedPage = RibbonControl1.MergedPages[0]

        'Dim cat As RibbonPageCategory
        'RibbonControl1.PageCategories.Add(cat)

        'cat.Pages.Add(mergedPage)

        'ribbonPreview.MdiParent = Me.MdiParent
        'ribbonPreview.Show()
    End Sub
End Class