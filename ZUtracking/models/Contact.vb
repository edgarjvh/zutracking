<Serializable()>
Public Class Contact
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _dni As Long
    Public Property Dni() As Long
        Get
            Return _dni
        End Get
        Set(ByVal value As Long)
            _dni = value
        End Set
    End Property

    Private _client_id As Integer
    Public Property ClientId() As Integer
        Get
            Return _client_id
        End Get
        Set(ByVal value As Integer)
            _client_id = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _phone_number1 As Long
    Public Property PhoneNumber1() As Long
        Get
            Return _phone_number1
        End Get
        Set(ByVal value As Long)
            _phone_number1 = value
        End Set
    End Property

    Private _phone_number2 As Long
    Public Property PhoneNumber2() As Long
        Get
            Return _phone_number2
        End Get
        Set(ByVal value As Long)
            _phone_number2 = value
        End Set
    End Property

    Private _observations As String
    Public Property Observations() As String
        Get
            Return _observations
        End Get
        Set(ByVal value As String)
            _observations = value
        End Set
    End Property
End Class
