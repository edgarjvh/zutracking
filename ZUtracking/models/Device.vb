<Serializable()>
Public Class Device
    Private _device_id As Integer
    Public Property DeviceId() As Integer
        Get
            Return _device_id
        End Get
        Set(ByVal value As Integer)
            _device_id = value
        End Set
    End Property

    Private _simcard As SimCard
    Public Property SimCard() As SimCard
        Get
            Return _simcard
        End Get
        Set(ByVal value As SimCard)
            _simcard = value
        End Set
    End Property

    Private _device_model As DeviceModel
    Public Property DeviceModel() As DeviceModel
        Get
            Return _device_model
        End Get
        Set(ByVal value As DeviceModel)
            _device_model = value
        End Set
    End Property

    Private _imei As String
    Public Property Imei() As String
        Get
            Return _imei
        End Get
        Set(ByVal value As String)
            _imei = value
        End Set
    End Property

    Private _asigned As Integer
    Public Property Asigned() As Integer
        Get
            Return _asigned
        End Get
        Set(ByVal value As Integer)
            _asigned = value
        End Set
    End Property

    Private _ip As String
    Public Property Ip() As String
        Get
            Return _ip
        End Get
        Set(ByVal value As String)
            _ip = value
        End Set
    End Property

    Private _port As Integer
    Public Property Port() As Integer
        Get
            Return _port
        End Get
        Set(ByVal value As Integer)
            _port = value
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

    Public Sub New()
        SimCard = New SimCard
        DeviceModel = New DeviceModel
    End Sub
End Class
