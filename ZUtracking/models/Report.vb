<Serializable()>
Public Class Report
    Private _report_id As Integer
    Public Property ReportId() As Integer
        Get
            Return _report_id
        End Get
        Set(ByVal value As Integer)
            _report_id = value
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

    Private _vehicle As Vehicle
    Public Property Vehicle() As Vehicle
        Get
            Return _vehicle
        End Get
        Set(ByVal value As Vehicle)
            _vehicle = value
        End Set
    End Property

    Private _report_type As ReportType
    Public Property ReportType() As ReportType
        Get
            Return _report_type
        End Get
        Set(ByVal value As ReportType)
            _report_type = value
        End Set
    End Property

    Private _user As User
    Public Property User() As User
        Get
            Return _user
        End Get
        Set(ByVal value As User)
            _user = value
        End Set
    End Property

    Private _communication_mode As String
    Public Property CommunicationMode() As String
        Get
            Return _communication_mode
        End Get
        Set(ByVal value As String)
            _communication_mode = value
        End Set
    End Property

    Private _transmitter As String
    Public Property Transmitter() As String
        Get
            Return _transmitter
        End Get
        Set(ByVal value As String)
            _transmitter = value
        End Set
    End Property

    Private _receiver As String
    Public Property Receiver() As String
        Get
            Return _receiver
        End Get
        Set(ByVal value As String)
            _receiver = value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
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

    Private _validation As Date
    Public Property Validation() As Date
        Get
            Return _validation
        End Get
        Set(ByVal value As Date)
            _validation = value
        End Set
    End Property

    Public Sub New()
        Client = New Client
        Vehicle = New Vehicle
        ReportType = New ReportType
        User = New User
    End Sub
End Class
