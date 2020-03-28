<Serializable()>
Public Class CurrentLocation
    Private _current_location_id As Integer
    Public Property CurrentLocationId() As Integer
        Get
            Return _current_location_id
        End Get
        Set(ByVal value As Integer)
            _current_location_id = value
        End Set
    End Property

    Private _event_name As String
    Public Property EventName() As String
        Get
            Return _event_name
        End Get
        Set(ByVal value As String)
            _event_name = value
        End Set
    End Property

    Private _date_time As Date
    Public Property DateTime() As Date
        Get
            Return _date_time
        End Get
        Set(ByVal value As Date)
            _date_time = value
        End Set
    End Property

    Private _fix As String
    Public Property Fix() As String
        Get
            Return _fix
        End Get
        Set(ByVal value As String)
            _fix = value
        End Set
    End Property

    Private _latitude As Double
    Public Property Latitude() As Double
        Get
            Return _latitude
        End Get
        Set(ByVal value As Double)
            _latitude = value
        End Set
    End Property

    Private _longitude As Double
    Public Property Longitude() As Double
        Get
            Return _longitude
        End Get
        Set(ByVal value As Double)
            _longitude = value
        End Set
    End Property

    Private _speed As Integer
    Public Property Speed() As Integer
        Get
            Return _speed
        End Get
        Set(ByVal value As Integer)
            _speed = value
        End Set
    End Property

    Private _orientation As Integer
    Public Property Orientation() As Integer
        Get
            Return _orientation
        End Get
        Set(ByVal value As Integer)
            _orientation = value
        End Set
    End Property

    Private _engine_status As Integer
    Public Property EngineStatus() As Integer
        Get
            Return _engine_status
        End Get
        Set(ByVal value As Integer)
            _engine_status = value
        End Set
    End Property

    Private _validation As String
    Public Property Validation() As String
        Get
            Return _validation
        End Get
        Set(ByVal value As String)
            _validation = value
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

    Private _vehicle As Vehicle
    Public Property Vehicle() As Vehicle
        Get
            Return _vehicle
        End Get
        Set(ByVal value As Vehicle)
            _vehicle = value
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


    Public Sub New()
        Device = New Device
        Vehicle = New Vehicle
        Client = New Client
    End Sub
End Class
