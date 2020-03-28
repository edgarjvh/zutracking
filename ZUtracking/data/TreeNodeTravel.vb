Public Class TreeNodeTravel
    Inherits TreeNode

    Private _position As Integer
    Public Property Position() As Integer
        Get
            Return _position
        End Get
        Set(ByVal value As Integer)
            _position = value
        End Set
    End Property

    Private _speed As Integer
    Public Property Speed() As Integer
        Get
            Return _speed
        End Get
        Set(ByVal value As Integer)
            _speed = value
        End Set
    End Property
End Class
