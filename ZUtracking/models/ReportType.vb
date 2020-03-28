<Serializable()>
Public Class ReportType
    Private _report_type_id As Integer
    Public Property ReportTypeId() As Integer
        Get
            Return _report_type_id
        End Get
        Set(ByVal value As Integer)
            _report_type_id = value
        End Set
    End Property

    Private _related_service As Integer
    Public Property RelatedService() As Integer
        Get
            Return _related_service
        End Get
        Set(ByVal value As Integer)
            _related_service = value
        End Set
    End Property

    Private _reference As Integer
    Public Property Reference() As Integer
        Get
            Return _reference
        End Get
        Set(ByVal value As Integer)
            _reference = value
        End Set
    End Property

    Private _department As Integer
    Public Property Department() As Integer
        Get
            Return _department
        End Get
        Set(ByVal value As Integer)
            _department = value
        End Set
    End Property

    Private _report_name As String
    Public Property ReportName() As String
        Get
            Return _report_name
        End Get
        Set(ByVal value As String)
            _report_name = value
        End Set
    End Property
End Class
