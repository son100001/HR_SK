Public Class objectParameter
    Private Dept As String
    Private Sect As String
    Private Team As String
    Private Pos As String
    Private Posc As String
    Private Fromdate As DateTime
    Private Todate As String
    Private Month As Integer
    Private Year As Integer

    Public Sub New()
    End Sub

    Public Property Dept_() As System.String
        Get
            Return Dept
        End Get
        Set(ByVal value As System.String)
            Dept = value
        End Set
    End Property

    Public Property Sect_() As System.String
        Get
            Return Sect
        End Get
        Set(ByVal value As System.String)
            Sect = value
        End Set
    End Property

    Public Property Team_() As System.String
        Get
            Return Team
        End Get
        Set(ByVal value As System.String)
            Team = value
        End Set
    End Property

    Public Property Pos_() As System.String
        Get
            Return Pos
        End Get
        Set(ByVal value As System.String)
            Pos = value
        End Set
    End Property

    Public Property Posc_() As System.String
        Get
            Return Posc
        End Get
        Set(ByVal value As System.String)
            Posc = value
        End Set
    End Property

    Public Property Fromdate_() As System.DateTime
        Get
            Return Fromdate
        End Get
        Set(ByVal value As System.DateTime)
            Fromdate = value
        End Set
    End Property

    Public Property Todate_() As System.DateTime
        Get
            Return Todate
        End Get
        Set(ByVal value As System.DateTime)
            Todate = value
        End Set
    End Property

    Public Property Month_() As Integer
        Get
            Return Month
        End Get
        Set(ByVal value As Integer)
            Month = value
        End Set
    End Property

    Public Property Year_() As Integer
        Get
            Return Year
        End Get
        Set(ByVal value As Integer)
            Year = value
        End Set
    End Property

End Class
