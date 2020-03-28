<Serializable()>
Public Class ConsoleVehicle
    Private _client As Client
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
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

    Private _simcard As SimCard
    Public Property SimCard() As SimCard
        Get
            Return _simcard
        End Get
        Set(ByVal value As SimCard)
            _simcard = value
        End Set
    End Property

    Public Sub New()
        Client = New Client
        Vehicle = New Vehicle
        Device = New Device
        SimCard = New SimCard
    End Sub
End Class
