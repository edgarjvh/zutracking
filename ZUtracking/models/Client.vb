<Serializable()>
Public Class Client
    Private _client_id As Integer
    Public Property Id() As Integer
        Get
            Return _client_id
        End Get
        Set(ByVal value As Integer)
            _client_id = value
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

    Private _first_name As String
    Public Property FirstName() As String
        Get
            Return _first_name
        End Get
        Set(ByVal value As String)
            _first_name = value
        End Set
    End Property

    Private _last_name As String
    Public Property LastName() As String
        Get
            Return _last_name
        End Get
        Set(ByVal value As String)
            _last_name = value
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

    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
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

    Private _web_pass As String
    Public Property WebPass() As String
        Get
            Return _web_pass
        End Get
        Set(ByVal value As String)
            _web_pass = value
        End Set
    End Property

    Private _image As Object
    Public Property Image() As Object
        Get
            Return _image
        End Get
        Set(ByVal value As Object)
            _image = value
        End Set
    End Property

    Private _status As Integer
    Public Property Status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Private _contacts As List(Of Contact)
    Public Property Contacts() As List(Of Contact)
        Get
            Return _contacts
        End Get
        Set(ByVal value As List(Of Contact))
            _contacts = value
        End Set
    End Property

    Private _vehicles As List(Of Vehicle)
    Public Property Vehicles() As List(Of Vehicle)
        Get
            Return _vehicles
        End Get
        Set(ByVal value As List(Of Vehicle))
            _vehicles = value
        End Set
    End Property

    Private _vehicles_count As Integer
    Public Property VehiclesCount() As Integer
        Get
            Return _vehicles_count
        End Get
        Set(ByVal value As Integer)
            _vehicles_count = value
        End Set
    End Property

    Public Sub New()
        Contacts = New List(Of Contact)
        Vehicles = New List(Of Vehicle)
    End Sub
End Class
