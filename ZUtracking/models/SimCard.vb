<Serializable()>
Public Class SimCard
    Private _simcard_id As Integer
    Public Property SimCardId() As Integer
        Get
            Return _simcard_id
        End Get
        Set(ByVal value As Integer)
            _simcard_id = value
        End Set
    End Property

    Private _mobile_operator As String
    Public Property MobileOperator() As String
        Get
            Return _mobile_operator
        End Get
        Set(ByVal value As String)
            _mobile_operator = value
        End Set
    End Property

    Private _serial As String
    Public Property Serial() As String
        Get
            Return _serial
        End Get
        Set(ByVal value As String)
            _serial = value
        End Set
    End Property

    Private _phone_number As Long
    Public Property PhoneNumber() As Long
        Get
            Return _phone_number
        End Get
        Set(ByVal value As Long)
            _phone_number = value
        End Set
    End Property

    Private _apn As String
    Public Property Apn() As String
        Get
            Return _apn
        End Get
        Set(ByVal value As String)
            _apn = value
        End Set
    End Property

    Private _call_service As Integer
    Public Property CallService() As Integer
        Get
            Return _call_service
        End Get
        Set(ByVal value As Integer)
            _call_service = value
        End Set
    End Property

    Private _sms_service As Integer
    Public Property SmsService() As Integer
        Get
            Return _sms_service
        End Get
        Set(ByVal value As Integer)
            _sms_service = value
        End Set
    End Property

    Private _data_service As Integer
    Public Property DataService() As Integer
        Get
            Return _data_service
        End Get
        Set(ByVal value As Integer)
            _data_service = value
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

    Private _asigned As Integer
    Public Property Asigned() As Integer
        Get
            Return _asigned
        End Get
        Set(ByVal value As Integer)
            _asigned = value
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
End Class
