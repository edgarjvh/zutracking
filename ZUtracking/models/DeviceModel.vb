<Serializable()>
Public Class DeviceModel
    Private _device_model_id As Integer
    Public Property DeviceModelId() As Integer
        Get
            Return _device_model_id
        End Get
        Set(ByVal value As Integer)
            _device_model_id = value
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

    Private _gprs_stop As String
    Public Property GprsStop() As String
        Get
            Return _gprs_stop
        End Get
        Set(ByVal value As String)
            _gprs_stop = value
        End Set
    End Property

    Private _gprs_resume As String
    Public Property GprsResume() As String
        Get
            Return _gprs_resume
        End Get
        Set(ByVal value As String)
            _gprs_resume = value
        End Set
    End Property

    Private _sms_stop As String
    Public Property SmsStop() As String
        Get
            Return _sms_stop
        End Get
        Set(ByVal value As String)
            _sms_stop = value
        End Set
    End Property

    Private _sms_resume As String
    Public Property SmsResume() As String
        Get
            Return _sms_resume
        End Get
        Set(ByVal value As String)
            _sms_resume = value
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
