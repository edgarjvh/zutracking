<Serializable()>
Public Class Vehicle
    Private _vehicle_id As Integer
    Public Property VehicleId() As Integer
        Get
            Return _vehicle_id
        End Get
        Set(ByVal value As Integer)
            _vehicle_id = value
        End Set
    End Property

    Private _license_plate As String
    Public Property LicensePlate() As String
        Get
            Return _license_plate
        End Get
        Set(ByVal value As String)
            _license_plate = value
        End Set
    End Property

    Private _brand As String
    Public Property Brand() As String
        Get
            Return _brand
        End Get
        Set(ByVal value As String)
            _brand = value
        End Set
    End Property

    Private _model As String
    Public Property Model() As String
        Get
            Return _model
        End Get
        Set(ByVal value As String)
            _model = value
        End Set
    End Property

    Private _type As String
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _year As Integer
    Public Property Year() As Integer
        Get
            Return _year
        End Get
        Set(ByVal value As Integer)
            _year = value
        End Set
    End Property

    Private _color As String
    Public Property Color() As String
        Get
            Return _color
        End Get
        Set(ByVal value As String)
            _color = value
        End Set
    End Property

    Private _speed_limit As Integer
    Public Property SpeedLimit() As Integer
        Get
            Return _speed_limit
        End Get
        Set(ByVal value As Integer)
            _speed_limit = value
        End Set
    End Property

    Private _phone_pass As String
    Public Property PhonePass() As String
        Get
            Return _phone_pass
        End Get
        Set(ByVal value As String)
            _phone_pass = value
        End Set
    End Property

    Private _installationDate As Date
    Public Property InstallationDate() As Date
        Get
            Return _installationDate
        End Get
        Set(ByVal value As Date)
            _installationDate = value
        End Set
    End Property

    Private _expiration_date As Date
    Public Property ExpirationDate() As Date
        Get
            Return _expiration_date
        End Get
        Set(ByVal value As Date)
            _expiration_date = value
        End Set
    End Property

    Private _priority As Integer
    Public Property Priority() As Integer
        Get
            Return _priority
        End Get
        Set(ByVal value As Integer)
            _priority = value
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

    Private _observations As String
    Public Property Observations() As String
        Get
            Return _observations
        End Get
        Set(ByVal value As String)
            _observations = value
        End Set
    End Property

    Private _client As Client
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
        End Set
    End Property

    Private _device As Device
    Public Property Device() As Device
        Get
            Return _device
        End Get
        Set(ByVal value As Device)
            _device = value
        End Set
    End Property

    Private _dealer As Dealer
    Public Property Dealer() As Dealer
        Get
            Return _dealer
        End Get
        Set(ByVal value As Dealer)
            _dealer = value
        End Set
    End Property

    Public Sub New()
        Device = New Device
        Dealer = New Dealer
        Client = New Client
    End Sub
End Class