<Serializable()>
Public Class PhoneNumber
    Private _phone_number_id As Integer
    Public Property PhoneNumberId() As Integer
        Get
            Return _phone_number_id
        End Get
        Set(ByVal value As Integer)
            _phone_number_id = value
        End Set
    End Property

    Private _phone As Long
    Public Property Phone() As Long
        Get
            Return _phone
        End Get
        Set(ByVal value As Long)
            _phone = value
        End Set
    End Property
End Class
