<Serializable()>
Public Class DeviceEvent
    Private _event_id As Integer
    Private _event_name As String
    Private _date_time As Date
    Private _latitude As Double
    Private _longitude As Double
    Private _speed_limit As Integer
    Private _current_speed As Integer
    Private _orientation As Integer
    Private _client As Client
    Private _vehicle As Vehicle
    Private _geofence As Geofence
    Private _device As Device

    Public Sub New()
        Client = New Client
        Vehicle = New Vehicle
        Geofence = New Geofence
        Device = New Device
    End Sub

    Private _report_type_id As Integer
    Public Property ReportTypeId() As Integer
        Get
            Return _report_type_id
        End Get
        Set(ByVal value As Integer)
            _report_type_id = value
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

    Public Property EventId As Integer
        Get
            Return _event_id
        End Get
        Set(value As Integer)
            _event_id = value
        End Set
    End Property

    Public Property EventName As String
        Get
            Return _event_name
        End Get
        Set(value As String)
            _event_name = value
        End Set
    End Property

    Public Property DateTime As Date
        Get
            Return _date_time
        End Get
        Set(value As Date)
            _date_time = value
        End Set
    End Property

    Public Property Latitude As Double
        Get
            Return _latitude
        End Get
        Set(value As Double)
            _latitude = value
        End Set
    End Property

    Public Property Longitude As Double
        Get
            Return _longitude
        End Get
        Set(value As Double)
            _longitude = value
        End Set
    End Property

    Public Property SpeedLimit As Integer
        Get
            Return _speed_limit
        End Get
        Set(value As Integer)
            _speed_limit = value
        End Set
    End Property

    Public Property CurrentSpeed As Integer
        Get
            Return _current_speed
        End Get
        Set(value As Integer)
            _current_speed = value
        End Set
    End Property

    Public Property Orientation As Integer
        Get
            Return _orientation
        End Get
        Set(value As Integer)
            _orientation = value
        End Set
    End Property

    Private _geofence_points As String
    Public Property GeofencePoints() As String
        Get
            Return _geofence_points
        End Get
        Set(ByVal value As String)
            _geofence_points = value
        End Set
    End Property

    Public Property Client As Client
        Get
            Return _client
        End Get
        Set(value As Client)
            _client = value
        End Set
    End Property

    Public Property Vehicle As Vehicle
        Get
            Return _vehicle
        End Get
        Set(value As Vehicle)
            _vehicle = value
        End Set
    End Property

    Public Property Geofence As Geofence
        Get
            Return _geofence
        End Get
        Set(value As Geofence)
            _geofence = value
        End Set
    End Property

    Public Property Device As Device
        Get
            Return _device
        End Get
        Set(value As Device)
            _device = value
        End Set
    End Property
End Class
