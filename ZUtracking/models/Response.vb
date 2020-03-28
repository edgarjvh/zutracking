<Serializable()>
Public Class Response
    Private _result As String
    Public Property Result() As String
        Get
            Return _result
        End Get
        Set(ByVal value As String)
            _result = value
        End Set
    End Property

    Private _message As Object
    Public Property Message() As Object
        Get
            Return _message
        End Get
        Set(ByVal value As Object)
            _message = value
        End Set
    End Property
End Class
