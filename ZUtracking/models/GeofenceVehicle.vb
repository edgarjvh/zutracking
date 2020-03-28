<Serializable()>
Public Class GeofenceVehicle
    Private _geofence_vehicle_id As Integer
    Private _geofence_id As Integer
    Private _vehicle_id As Integer
    Private _last_status As Integer
    Private _date_time As Date
    Private _name As String
    Private _license_plate As String
    Private _brand As String
    Private _model As String
    Private _type As String
    Private _year As Integer
    Private _color As String
    Private _client_id As Integer
    Private _first_name As String
    Private _last_name As String

    Private _geofence As Geofence
    Public Property Geofence() As Geofence
        Get
            Return _geofence
        End Get
        Set(ByVal value As Geofence)
            _geofence = value
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

    Private _device As Device
    Public Property Device() As Device
        Get
            Return _device
        End Get
        Set(ByVal value As Device)
            _device = value
        End Set
    End Property

    Private _current_location As CurrentLocation
    Public Property CurrentLocation() As CurrentLocation
        Get
            Return _current_location
        End Get
        Set(ByVal value As CurrentLocation)
            _current_location = value
        End Set
    End Property

    Private _geofence_points As List(Of GeofencePoint)
    Public Property GeofencePoints() As List(Of GeofencePoint)
        Get
            Return _geofence_points
        End Get
        Set(ByVal value As List(Of GeofencePoint))
            _geofence_points = value
        End Set
    End Property

    Public Property GeofenceVehicleId As Integer
        Get
            Return _geofence_vehicle_id
        End Get
        Set(value As Integer)
            _geofence_vehicle_id = value
        End Set
    End Property

    Public Property GeofenceId As Integer
        Get
            Return _geofence_id
        End Get
        Set(value As Integer)
            _geofence_id = value
        End Set
    End Property

    Public Property VehicleId As Integer
        Get
            Return _vehicle_id
        End Get
        Set(value As Integer)
            _vehicle_id = value
        End Set
    End Property

    Public Property LastStatus As Integer
        Get
            Return _last_status
        End Get
        Set(value As Integer)
            _last_status = value
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

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property LicensePlate As String
        Get
            Return _license_plate
        End Get
        Set(value As String)
            _license_plate = value
        End Set
    End Property

    Public Property Brand As String
        Get
            Return _brand
        End Get
        Set(value As String)
            _brand = value
        End Set
    End Property

    Public Property Model As String
        Get
            Return _model
        End Get
        Set(value As String)
            _model = value
        End Set
    End Property

    Public Property Type As String
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property

    Public Property Year As Integer
        Get
            Return _year
        End Get
        Set(value As Integer)
            _year = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return _color
        End Get
        Set(value As String)
            _color = value
        End Set
    End Property

    Public Property ClientId As Integer
        Get
            Return _client_id
        End Get
        Set(value As Integer)
            _client_id = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _first_name
        End Get
        Set(value As String)
            _first_name = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _last_name
        End Get
        Set(value As String)
            _last_name = value
        End Set
    End Property

    Public Sub New()
        Geofence = New Geofence
        Vehicle = New Vehicle
        Device = New Device
        CurrentLocation = New CurrentLocation
        GeofencePoints = New List(Of GeofencePoint)
    End Sub

End Class
