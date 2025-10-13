Public Class CompanyList
    Public Sub New()
    End Sub

    Public Property CompanyInfor As List(Of CompanyInfor)
End Class

Public Class CompanyInfor
    Public Sub New()
    End Sub

    Public Property ID As Integer
    Public Property Name As String
    Public Property Code As String
    Public Property ServerName As String
    Public Property DatabaseName As String
    Public Property UserID As String
    Public Property Password As String
End Class