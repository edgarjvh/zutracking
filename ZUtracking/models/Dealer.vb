<Serializable()>
Public Class Dealer
    Private _dealer_id As Integer
    Public Property DealerId() As Integer
        Get
            Return _dealer_id
        End Get
        Set(ByVal value As Integer)
            _dealer_id = value
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

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _contact As String
    Public Property Contact() As String
        Get
            Return _contact
        End Get
        Set(ByVal value As String)
            _contact = value
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

    Private _web_site As String
    Public Property WebSite() As String
        Get
            Return _web_site
        End Get
        Set(ByVal value As String)
            _web_site = value
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

    Private _battery_alert As Integer
    Public Property BatteryAlert() As Integer
        Get
            Return _battery_alert
        End Get
        Set(ByVal value As Integer)
            _battery_alert = value
        End Set
    End Property

    Private _speed_alert As Integer
    Public Property SpeedAlert() As Integer
        Get
            Return _speed_alert
        End Get
        Set(ByVal value As Integer)
            _speed_alert = value
        End Set
    End Property

    Private _geofence_alert As Integer
    Public Property GeofenceAlert() As Integer
        Get
            Return _geofence_alert
        End Get
        Set(ByVal value As Integer)
            _geofence_alert = value
        End Set
    End Property

    Private _ignition_alert As Integer
    Public Property IgnitionAlert() As Integer
        Get
            Return _ignition_alert
        End Get
        Set(ByVal value As Integer)
            _ignition_alert = value
        End Set
    End Property

    Private _motion_alert As Integer
    Public Property MotionAlert() As Integer
        Get
            Return _motion_alert
        End Get
        Set(ByVal value As Integer)
            _motion_alert = value
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
End Class
