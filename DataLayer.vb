Imports GrapeCity.ActiveReports.Expressions.ExpressionObjectModel
Imports System.Globalization
Imports System.Data.OleDb

Friend NotInheritable Class DataLayer
    Private _datasetData As System.Data.DataSet

    Public Sub New()
        LoadDataToDataSet()
    End Sub

    Public ReadOnly Property DataSetData() As System.Data.DataSet
        Get
            Return _datasetData
        End Get
    End Property

    Private Sub LoadDataToDataSet()

        Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;
                Data Source=" + Application.StartupPath + "\..\..\Data\NWIND.mdb"
        Dim productSql As String = "SELECT top 15 * FROM Products"

        _datasetData = New DataSet()
        Dim conn As New OleDbConnection(connStr)
        Dim cmd As OleDbCommand = Nothing
        Dim adapter As New OleDbDataAdapter

        cmd = New OleDbCommand(productSql, conn)
        adapter.SelectCommand = cmd
        adapter.Fill(_datasetData, "DataSet1")
    End Sub

End Class