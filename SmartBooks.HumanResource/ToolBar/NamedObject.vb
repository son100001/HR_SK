Public Class NamedObject

    Dim mValue As Object
    Dim mName As String
    Dim mImageBytes As Byte()
    Public Sub New(ByVal value As Object, ByVal name As String)
        Me.New(value, name, Nothing)
    End Sub
    Public Sub New(ByVal value As Object, ByVal name As String, ByVal imageBytes As Byte())
        mValue = value
        mName = name
        mImageBytes = imageBytes
    End Sub
    Public Property Value() As Object
        Get
            Return mValue
        End Get
        Set(ByVal Value As Object)
            mValue = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            mName = Value
        End Set
    End Property
    Public Property ImageBytes() As Byte()
        Get
            Return mImageBytes
        End Get
        Set(ByVal Value As Byte())
            mImageBytes = Value
        End Set
    End Property
End Class
