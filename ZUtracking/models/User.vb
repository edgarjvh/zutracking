<Serializable()>
Public Class User

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

    Private _address As String
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Private _phone_number_1 As Long
    Public Property PhoneNumber1() As Long
        Get
            Return _phone_number_1
        End Get
        Set(ByVal value As Long)
            _phone_number_1 = value
        End Set
    End Property

    Private _phone_number_2 As Long
    Public Property PhoneNumber2() As Long
        Get
            Return _phone_number_2
        End Get
        Set(ByVal value As Long)
            _phone_number_2 = value
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

    Private _permission_level As Integer
    Public Property PermissionLevel() As Integer
        Get
            Return _permission_level
        End Get
        Set(ByVal value As Integer)
            _permission_level = value
        End Set
    End Property

    Private _pass As String
    Public Property Pass() As String
        Get
            Return _pass
        End Get
        Set(ByVal value As String)
            _pass = value
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
End Class
