Imports System.Drawing.Drawing2D
Imports GMap.NET
Imports GMap.NET.WindowsForms

Public Class GmapMarkerMain
    Inherits GMapMarker

    Public Sub New(p As PointLatLng)
        MyBase.New(p)

        Image = New Bitmap(My.Resources.marker_icon_default)
        Orientation = 0
        Fix = "A"
        Speed = 0
        DateTime = Now
    End Sub

    Public Overrides Sub OnRender(g As Graphics)
        Using img As Bitmap = RotateImage(Image, Orientation)
            g.DrawImage(img, New Point(LocalPosition.X - img.Width / 2, LocalPosition.Y - img.Height / 2))
        End Using
    End Sub

#Region "Properties"
    Private _image As Bitmap
    Private Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
        End Set
    End Property

    Private _client As String
    Public Property Client() As String
        Get
            Return _client
        End Get
        Set(ByVal value As String)
            _client = value
            SetToolTip()
        End Set
    End Property

    Private _imei As String
    Public Property Imei() As String
        Get
            Return _imei
        End Get
        Set(ByVal value As String)
            _imei = value
            SetToolTip()
        End Set
    End Property

    Private _license_plate As String
    Public Property LicensePlate() As String
        Get
            Return _license_plate
        End Get
        Set(ByVal value As String)
            _license_plate = value
            SetToolTip()
        End Set
    End Property

    Private _speed As Integer
    Public Property Speed() As Integer
        Get
            Return _speed
        End Get
        Set(ByVal value As Integer)
            _speed = value
            ChangeImage()
            SetToolTip()
        End Set
    End Property

    Private _fix As String
    Public Property Fix() As String
        Get
            Return _fix
        End Get
        Set(ByVal value As String)
            _fix = value
        End Set
    End Property

    Private _orientation As Integer
    Public Property Orientation() As Integer
        Get
            Return _orientation
        End Get
        Set(ByVal value As Integer)
            _orientation = value
        End Set
    End Property

    Private _date_time As Date
    Public Property DateTime() As Date
        Get
            Return _date_time
        End Get
        Set(ByVal value As Date)
            _date_time = value
            SetToolTip()
        End Set
    End Property
#End Region

    Private Shared Function RotateImage(image As Image, angle As Single) As Bitmap
        If image Is Nothing Then
            Throw New ArgumentNullException("image")
        End If

        Const pi2 As Double = Math.PI / 2.0

        ' Why can't C# allow these to be const, or at least readonly
        Dim oldWidth As Double = Convert.ToDouble(image.Width)
        Dim oldHeight As Double = Convert.ToDouble(image.Height)

        ' Convert degrees to radians
        Dim theta As Double = Convert.ToDouble(angle) * Math.PI / 180.0
        Dim locked_theta As Double = theta

        ' Make sure theta is now [0, 2pi)
        While locked_theta < 0.0
            locked_theta += 2 * Math.PI
        End While

        Dim newWidth As Double = 0
        Dim newHeight As Double = 0
        Dim nWidth As Integer = 0
        Dim nHeight As Integer = 0

        Dim adjacentTop As Double = 0
        Dim oppositeTop As Double = 0
        Dim adjacentBottom As Double = 0
        Dim oppositeBottom As Double = 0

        If (locked_theta >= 0.0 AndAlso locked_theta < pi2) OrElse (locked_theta >= Math.PI AndAlso locked_theta < (Math.PI + pi2)) Then
            adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth
            oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth

            adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight
            oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight
        Else
            adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight
            oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight

            adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth
            oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth
        End If

        newWidth = adjacentTop + oppositeBottom
        newHeight = adjacentBottom + oppositeTop

        nWidth = Convert.ToInt32(Math.Ceiling(newWidth))
        nHeight = Convert.ToInt32(Math.Ceiling(newHeight))

        Dim rotatedBmp As New Bitmap(nWidth, nHeight)

        Using g As Graphics = Graphics.FromImage(rotatedBmp)
            ' This array will be used to pass in the three points that 
            ' make up the rotated image
            Dim points As Point() = Nothing
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = PixelOffsetMode.HighQuality


            If locked_theta >= 0.0 AndAlso locked_theta < pi2 Then
                points = New Point() {New Point(Convert.ToInt32(oppositeBottom), 0), New Point(nWidth, Convert.ToInt32(oppositeTop)), New Point(0, Convert.ToInt32(adjacentBottom))}
            ElseIf locked_theta >= pi2 AndAlso locked_theta < Math.PI Then
                points = New Point() {New Point(nWidth, Convert.ToInt32(oppositeTop)), New Point(Convert.ToInt32(adjacentTop), nHeight), New Point(Convert.ToInt32(oppositeBottom), 0)}
            ElseIf locked_theta >= Math.PI AndAlso locked_theta < (Math.PI + pi2) Then
                points = New Point() {New Point(Convert.ToInt32(adjacentTop), nHeight), New Point(0, Convert.ToInt32(adjacentBottom)), New Point(nWidth, Convert.ToInt32(oppositeTop))}
            Else
                points = New Point() {New Point(0, Convert.ToInt32(adjacentBottom)), New Point(Convert.ToInt32(oppositeBottom), 0), New Point(Convert.ToInt32(adjacentTop), nHeight)}
            End If

            g.DrawImage(image, points)
        End Using

        Return rotatedBmp
    End Function

    Private Sub SetToolTip()
        ToolTipText = "Cliente: " & Client & vbNewLine &
                      "Matrícula: " & LicensePlate & vbNewLine &
                      "Imei: " & Imei & vbNewLine &
                      "Latitud: " & Math.Round(Position.Lat, 6) & vbNewLine &
                      "Longitud: " & Math.Round(Position.Lng, 6) & vbNewLine &
                      "Velocidad: " & Speed & " Km/H" & vbNewLine &
                      "Fecha: " & DateTime.ToString("dd/MM/yyyy hh:mm:ss tt")
        ToolTipMode = MarkerTooltipMode.OnMouseOver
        ToolTip.Format.Alignment = StringAlignment.Near

        ToolTip.Fill = If(Fix = "A", If(Speed > 0, New SolidBrush(Color.LightGreen), New SolidBrush(Color.LightCoral)), New SolidBrush(Color.Orange))
    End Sub

    Private Sub ChangeImage()
        Image = If(Fix = "A", If(Speed > 0, New Bitmap(My.Resources.move_icon), New Bitmap(My.Resources.stop_icon)), New Bitmap(My.Resources.move_error_icon))
        Size = New Size(Image.Size.Width, Image.Size.Height)
    End Sub
End Class
