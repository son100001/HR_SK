Imports System.Data.SqlClient

Public Class Logs

    Friend Shadows WithEvents conn As SqlConnection

    Public Sub New()
        conn.ConnectionString = Appsettings.DbSetting.dataPath
    End Sub

    Public Function NewLog(ByVal LogDate As Date, ByVal UserName As String, ByVal LogObject As String, ByVal Content As String, ByVal Progress As String) As Integer

    End Function

    Public Function EditLog(ByVal LogID As Integer, Optional ByVal NewLogDate As Date = #12:00:00 AM#, Optional ByVal NewUserName As String = Nothing, Optional ByVal NewLogObject As String = Nothing, Optional ByVal NewContent As String = Nothing, Optional ByVal NewProgress As String = Nothing) As Boolean

    End Function

    Public Function EditProgress(ByVal LogID As Integer, ByVal Progress As String) As Boolean

    End Function

    Public Function DeleteLog(ByVal LogID As Integer) As Boolean

    End Function

    Public Function PurgeLogs(ByVal FromDate As Date, ByVal ToDate As Date) As Boolean

    End Function
End Class
