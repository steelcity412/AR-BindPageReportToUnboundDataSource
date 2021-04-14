Public Class Form1
    Dim WithEvents runtime As GrapeCity.ActiveReports.Document.PageDocument

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadReport()

    End Sub

    Private Sub LoadReport()
        Dim rptPath As New System.IO.FileInfo("..\..\PageReport1.rdlx")
        'Create a report definition that loads an existing report.
        Dim definition As New GrapeCity.ActiveReports.PageReport(rptPath)
        'Load the report definition into a new page document.
        runtime = New GrapeCity.ActiveReports.Document.PageDocument(definition)
        'Attach the runtime to an event. This line of code creates the event shell below.
        Viewer1.LoadDocument(runtime)
    End Sub

    'ActiveReports raises this event when it cannot locate a report's data source in the usual ways.
    Private Sub runtime_LocateDataSource(ByVal sender As Object, ByVal args As GrapeCity.ActiveReports.LocateDataSourceEventArgs) Handles runtime.LocateDataSource
        Dim dl = New DataLayer
        args.Data = dl.DataSetData.Tables("DataSet1")
    End Sub

End Class
