<Serializable()>
Public Class Geofence
    Private _geofence_id As Integer
    Private _name As String
    Private _description As String
    Private _status As Integer
    Private _asigns As Integer
    Private _points As List(Of GeofencePoint)

    Public Property GeofenceId As Integer
        Get
            Return _geofence_id
        End Get
        Set(value As Integer)
            _geofence_id = value
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

    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(value As Integer)
            _status = value
        End Set
    End Property

    Public Property Asigns() As Integer
        Get
            Return _asigns
        End Get
        Set(ByVal value As Integer)
            _asigns = value
        End Set
    End Property
    Public Property Points As List(Of GeofencePoint)
        Get
            Return _points
        End Get
        Set(value As List(Of GeofencePoint))
            _points = value
        End Set
    End Property

    Public Sub New()
        Points = New List(Of GeofencePoint)
    End Sub
End Class
