<Serializable()>
Public Class ClientMisc
    Private _report_types As List(Of ReportType)
    Public Property ReportTypes() As List(Of ReportType)
        Get
            Return _report_types
        End Get
        Set(ByVal value As List(Of ReportType))
            _report_types = value
        End Set
    End Property

    Private _phone_numbers As List(Of PhoneNumber)
    Public Property PhoneNumbers() As List(Of PhoneNumber)
        Get
            Return _phone_numbers
        End Get
        Set(ByVal value As List(Of PhoneNumber))
            _phone_numbers = value
        End Set
    End Property

    Private _users As List(Of User)
    Public Property Users() As List(Of User)
        Get
            Return _users
        End Get
        Set(ByVal value As List(Of User))
            _users = value
        End Set
    End Property

    Public Sub New()
        ReportTypes = New List(Of ReportType)
        PhoneNumbers = New List(Of PhoneNumber)
        Users = New List(Of User)
    End Sub
End Class
