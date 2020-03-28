<Serializable()>
Public Class GeofencePoint
    Private _geofence_point_id As Integer
    Private _geofence_id As Integer
    Private _latitude As Double
    Private _longitude As Double

    Public Property GeofencePointId As Integer
        Get
            Return _geofence_point_id
        End Get
        Set(value As Integer)
            _geofence_point_id = value
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

    Public Property Latitude As Double
        Get
            Return _latitude
        End Get
        Set(value As Double)
            _latitude = value
        End Set
    End Property

    Public Property Longitude As Double
        Get
            Return _longitude
        End Get
        Set(value As Double)
            _longitude = value
        End Set
    End Property
End Class
