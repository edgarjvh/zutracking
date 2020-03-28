Imports System.ComponentModel
Imports GMap.NET
Imports GMap.NET.WindowsForms

Public Class frmTravelHistory

    Dim markersLayer As New GMapOverlay("markersLayer")
    Dim linePoints As New List(Of PointLatLng)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        btnMap.Parent = mapTravelHistory
        btnSatellite.Parent = mapTravelHistory
        btnHybrid.Parent = mapTravelHistory
        tbarMapZoom.Parent = mapTravelHistory
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not bgwSearchHistory.IsBusy Then
            Dim dateFrom As Date = Date.Parse(dtpDateFrom.Value.ToShortDateString() & " " & dtpTimeFrom.Value.ToString("HH:mm:00"))
            Dim dateTo As Date = Date.Parse(dtpDateTo.Value.ToShortDateString() & " " & dtpTimeTo.Value.ToString("HH:mm:00"))

            If dateFrom > dateTo Then
                MsgBox("La fecha <desde> deber ser menor que la fecha <hasta>", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                dtpDateFrom.Focus()
                Exit Sub
            End If

            If cboClients.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un cliente de la lista", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboClients.Focus()
                Exit Sub
            End If

            If cboVehicles.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboVehicles.Focus()
                Exit Sub
            End If

            If Not bgwSearchHistory.IsBusy Then
                markersLayer.Markers.Clear()
                markersLayer.Polygons.Clear()
                markersLayer.Routes.Clear()
                tviewPoints.Nodes.Clear()
                DrawingControl.SuspendDrawing(mapTravelHistory)
                DrawingControl.SuspendDrawing(tviewPoints)
                linePoints.Clear()
                btnCenterSelection.Enabled = markersLayer.Markers.Count > 0
                btnShowTravelLine.Enabled = markersLayer.Markers.Count > 0
                bgwSearchHistory.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub frmTravelHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        dtpDateFrom.Value = Now
        dtpDateTo.Value = Now
        dtpTimeFrom.Value = Now
        dtpTimeTo.Value = Now

        getClients()
    End Sub

    Private Sub getClients()
        Try
            Dim proc As New Procedure
            Dim dt As New DataTable("clients")
            Dim col1 As New DataColumn("client_id")
            Dim col2 As New DataColumn("name")
            dt.Columns.Add(col1)
            dt.Columns.Add(col2)

            If proc.GetData("clients_getAll") Then
                For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                    Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                    Dim row As DataRow = dt.NewRow
                    row.Item("client_id") = row2("client_id")
                    row.Item("name") = (row2("first_name") & " " & row2("last_name")).ToString().Trim
                    dt.Rows.Add(row)
                Next
            End If

            cboClients.DataSource = Nothing
            cboClients.DataSource = dt
            cboClients.DisplayMember = "name"
            cboClients.ValueMember = "client_id"
            cboClients.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub cboClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClients.SelectedIndexChanged
        Try
            If TypeOf cboClients.SelectedValue Is String Then
                Dim proc As New Procedure

                Dim dt As New DataTable("vehicles")
                Dim col1 As New DataColumn("vehicle_id")
                Dim col2 As New DataColumn("vehicle")
                dt.Columns.Add(col1)
                dt.Columns.Add(col2)

                If proc.GetData("vehicles_getByClient", cboClients.SelectedValue) Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                        Dim row As DataRow = dt.NewRow
                        row.Item("vehicle_id") = row2("imei")
                        row.Item("vehicle") = row2("license_plate") & " (" &
                                              row2("brand") & " " &
                                              row2("model") & " " &
                                              row2("type") & " " &
                                              row2("year") & " " &
                                              row2("color") & ")"
                        dt.Rows.Add(row)
                    Next
                End If

                cboVehicles.DataSource = Nothing
                cboVehicles.DataSource = dt
                cboVehicles.DisplayMember = "vehicle"
                cboVehicles.ValueMember = "vehicle_id"
                cboVehicles.SelectedIndex = -1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        mapTravelHistory.MapProvider = MapProviders.GoogleMapProvider.Instance
        btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
    End Sub

    Private Sub btnSatellite_Click(sender As Object, e As EventArgs) Handles btnSatellite.Click
        mapTravelHistory.MapProvider = MapProviders.GoogleChinaSatelliteMapProvider.Instance
        btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
    End Sub

    Private Sub btnHybrid_Click(sender As Object, e As EventArgs) Handles btnHybrid.Click
        mapTravelHistory.MapProvider = MapProviders.GoogleChinaHybridMapProvider.Instance
        btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
    End Sub

    Private Sub mapMain_OnMapZoomChanged() Handles mapTravelHistory.OnMapZoomChanged
        tbarMapZoom.Value = mapTravelHistory.Zoom
    End Sub

    Private Sub tbarMainMap_ValueChanged(sender As Object, value As Decimal) Handles tbarMapZoom.ValueChanged
        mapTravelHistory.Zoom = tbarMapZoom.Value
    End Sub

    Private Sub bgwSearchHistory_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSearchHistory.DoWork
        Try
            bgwSearchHistory.ReportProgress(1)
            Dim proc As New Procedure

            Dim dateFrom As String = dtpDateFrom.Value.ToString("yyyy-MM-dd") & " " & dtpTimeFrom.Value.ToString("HH:mm:00")
            Dim dateTo As String = dtpDateTo.Value.ToString("yyyy-MM-dd") & " " & dtpTimeTo.Value.ToString("HH:mm:00")

            If proc.GetData("traces_getTravelHistory",
                                                    cboVehicles.SelectedValue,
                                                    dateFrom,
                                                    dateTo) Then

                Dim curIndex As Integer = 0
                Dim jump As Integer = 0
                Dim curPoint As New PointLatLng(0, 0)
                Dim curDate As Date
                Dim curSpeed As Integer
                Dim orientation As Integer
                Dim lastIndex As Integer = 0
                Dim lastPoint As New PointLatLng(0, 0)
                Dim lastDate As Date
                Dim lastSpeed As Integer = 0
                Dim samePoint As Boolean = False

                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                        curPoint = New PointLatLng(row("latitude"), row("longitude"))
                        curDate = row("date_time")
                        curSpeed = row("speed")
                        orientation = row("orientation")

                        curIndex = (i - jump + 1).ToString().PadLeft(3, "0")

                        If markersLayer.Markers.Count = 0 Then
                            Dim marker As New GmapMarkerTravel(curPoint)
                            marker.Index = curIndex
                            marker.CurrentDateTime = curDate.ToString("dd/MM/yyyy hh:mm:ss tt")
                            marker.LastDateTime = ""
                            marker.Orientation = orientation
                            marker.IsVisible = True
                            marker.Speed = curSpeed
                            markersLayer.Markers.Add(marker)

                            Dim parentNode As New TreeNodeTravel
                            parentNode.Position = curIndex
                            parentNode.Text = curIndex.ToString("0000") & " > " & curDate.ToString("dd/MM/yyyy hh:mm:ss tt")
                            parentNode.Speed = curSpeed
                            parentNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)

                            Dim childNode As New TreeNode()
                            childNode.Name = curIndex & "c"
                            childNode.Text = "Latitud: " & Math.Round(row("latitude"), 6)
                            childNode.Tag = curIndex & "c"
                            childNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)
                            parentNode.Nodes.Add(childNode)

                            childNode = New TreeNode()
                            childNode.Name = curIndex & "c"
                            childNode.Text = "Longitud: " & Math.Round(row("longitude"), 6)
                            childNode.Tag = curIndex & "c"
                            childNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)
                            parentNode.Nodes.Add(childNode)

                            childNode = New TreeNode()
                            childNode.Name = curIndex & "c"
                            childNode.Text = "Velocidad: " & curSpeed & " Km/h"
                            childNode.Tag = curIndex & "c"
                            childNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)
                            parentNode.Nodes.Add(childNode)

                            bgwSearchHistory.ReportProgress(2, parentNode)

                            linePoints.Add(curPoint)
                            lastIndex = curIndex
                            lastPoint = curPoint
                            lastDate = curDate
                            lastSpeed = curSpeed
                        Else
                            'si son las mismas coordenadas que el punto anterior
                            If curPoint = lastPoint Then
                                samePoint = True
                            Else

                                ' si no son las mismas coordenadas que el punto anterior
                                ' se captura la distancia entre el punto anterior y el actual
                                Dim distance As Double = Math.Round(mapTravelHistory.MapProvider.Projection.GetDistance(lastPoint, curPoint) * 1000, 0)

                                ' compara la velocidad actual y la distancia para determinar
                                ' si se toma como el mismo punto
                                If curSpeed > 10 Then
                                    samePoint = False
                                Else
                                    samePoint = lastSpeed < 10 AndAlso samePoint = distance <= 30 '30 metros
                                End If

                                If samePoint Then
                                    jump += 1
                                    For Each marker As GmapMarkerTravel In markersLayer.Markers                                    '
                                        If marker.Index = lastIndex Then
                                            marker.LastDateTime = marker.CurrentDateTime
                                            marker.CurrentDateTime = curDate.ToString("dd/MM/yyyy hh:mm:ss tt")
                                            Exit For
                                        End If
                                    Next

                                    For Each node As TreeNodeTravel In tviewPoints.Nodes
                                        If node.Position = lastIndex Then
                                            node.Text = lastIndex.ToString("0000") & " > " & lastDate.ToString("dd/MM/yyyy hh:mm:ss tt") & " >> " & curDate.ToString("dd/MM/yyyy hh:mm:ss tt")
                                            Exit For
                                        End If
                                    Next
                                Else
                                    Dim marker As New GmapMarkerTravel(curPoint)
                                    marker.Index = curIndex
                                    marker.CurrentDateTime = curDate.ToString("dd/MM/yyyy hh:mm:ss tt")
                                    marker.LastDateTime = ""
                                    marker.Orientation = orientation
                                    marker.IsVisible = True
                                    marker.Speed = curSpeed

                                    markersLayer.Markers.Add(marker)

                                    linePoints.Add(curPoint)
                                    lastIndex = curIndex
                                    lastPoint = curPoint
                                    lastDate = curDate
                                    lastSpeed = curSpeed

                                    Dim parentNode As New TreeNodeTravel
                                    parentNode.Position = curIndex
                                    parentNode.Text = curIndex.ToString("0000") & " > " & curDate.ToString("dd/MM/yyyy hh:mm:ss tt")
                                    parentNode.Speed = curSpeed
                                    parentNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)

                                    Dim childNode As New TreeNode()
                                    childNode.Name = curIndex & "c"
                                    childNode.Text = "Latitud: " & Math.Round(row("latitude"), 6)
                                    childNode.Tag = curIndex & "c"
                                    childNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)
                                    parentNode.Nodes.Add(childNode)

                                    childNode = New TreeNode()
                                    childNode.Name = curIndex & "c"
                                    childNode.Text = "Longitud: " & Math.Round(row("longitude"), 6)
                                    childNode.Tag = curIndex & "c"
                                    childNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)
                                    parentNode.Nodes.Add(childNode)

                                    childNode = New TreeNode()
                                    childNode.Name = curIndex & "c"
                                    childNode.Text = "Velocidad: " & curSpeed & " Km/h"
                                    childNode.Tag = curIndex & "c"
                                    childNode.BackColor = If(curSpeed > 0, Color.LightGreen, Color.LightCoral)
                                    parentNode.Nodes.Add(childNode)

                                    bgwSearchHistory.ReportProgress(2, parentNode)
                                End If
                            End If
                        End If
                    Next

                    ' fin del ciclo for
                    If Not mapTravelHistory.Overlays.Contains(markersLayer) Then
                        mapTravelHistory.Overlays.Add(markersLayer)
                    End If

                    Dim geofence As New GMapPolygon(linePoints, "geofence")
                    geofence.IsVisible = False
                    markersLayer.Polygons.Add(geofence)

                    Dim route As New GMapRoute(linePoints, "route")
                    route.Stroke = New Pen(Color.Red, 2)
                    route.IsVisible = btnShowTravelLine.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
                    markersLayer.Routes.Add(route)

                    Dim rect As RectLatLng? = GetRectOfPolygonTravel(geofence.Name)
                    If rect.HasValue Then
                        mapTravelHistory.SetZoomToFitRect(rect.Value)
                    End If

                    markersLayer.IsVisibile = True
                End If
            End If
        Catch ex As Exception
            bgwSearchHistory.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSearchHistory_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSearchHistory.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                tviewPoints.Enabled = False
                mapTravelHistory.Enabled = False
                lblLoading.Text = "Buscando recorrido... Por favor espere"
                lblLoading.ForeColor = Color.Blue
                pboxLoading.Visible = True
                Exit Select
            Case 2
                tviewPoints.Nodes.Add(DirectCast(e.UserState, TreeNode))
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwSearchHistory_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSearchHistory.RunWorkerCompleted
        panelHeader.Enabled = True
        tviewPoints.Enabled = True
        mapTravelHistory.Enabled = True
        pboxLoading.Visible = False
        btnCenterSelection.Enabled = markersLayer.Markers.Count > 0
        btnShowTravelLine.Enabled = markersLayer.Markers.Count > 0

        DrawingControl.ResumeDrawing(mapTravelHistory)
        DrawingControl.ResumeDrawing(tviewPoints)

        lblLoading.Text = If(markersLayer.Markers.Count > 0, markersLayer.Markers.Count.ToString("0000") & " Registros encontrados", "No se encontraron resultados")
        lblLoading.ForeColor = If(markersLayer.Markers.Count > 0, Color.Green, Color.Red)
    End Sub

    Public Function GetRectOfPolygonTravel(polygonName As String) As RectLatLng?
        Dim ret As RectLatLng? = Nothing

        Dim left As Double = Double.MaxValue
        Dim top As Double = Double.MinValue
        Dim right As Double = Double.MinValue
        Dim bottom As Double = Double.MaxValue

        For Each o As GMapOverlay In mapTravelHistory.Overlays
            If o.Polygons.Count > 0 Then
                For Each poly As GMapPolygon In o.Polygons
                    If poly.From.HasValue AndAlso poly.[To].HasValue AndAlso poly.Name.Equals(polygonName) Then
                        For Each p As PointLatLng In poly.Points
                            ' left
                            If p.Lng < left Then
                                left = p.Lng
                            End If

                            ' top
                            If p.Lat > top Then
                                top = p.Lat
                            End If

                            ' right
                            If p.Lng > right Then
                                right = p.Lng
                            End If

                            ' bottom
                            If p.Lat < bottom Then
                                bottom = p.Lat
                            End If
                        Next
                    End If
                Next
            End If
        Next

        If left <> Double.MaxValue AndAlso right <> Double.MinValue AndAlso top <> Double.MinValue AndAlso bottom <> Double.MaxValue Then
            ret = RectLatLng.FromLTRB(left, top, right, bottom)
        End If

        Return ret
    End Function

    Private Sub btnShowTravelLine_Click(sender As Object, e As EventArgs) Handles btnShowTravelLine.Click
        btnShowTravelLine.ButtonStyle = If(btnShowTravelLine.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed, ZUControls.ZUButton.buttonStyles.StyleGreen)

        If markersLayer.Routes.Count > 0 Then
            markersLayer.Routes(0).IsVisible = btnShowTravelLine.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        End If
    End Sub

    Private Sub btnCenterSelection_Click(sender As Object, e As EventArgs) Handles btnCenterSelection.Click
        btnCenterSelection.ButtonStyle = If(btnCenterSelection.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed, ZUControls.ZUButton.buttonStyles.StyleGreen)
    End Sub

    Private Sub tviewPoints_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tviewPoints.NodeMouseClick
        Dim pos As PointLatLng = mapTravelHistory.Position
        Dim node = DirectCast(e.Node, TreeNodeTravel)

        For i = 0 To markersLayer.Markers.Count - 1
            Dim marker = DirectCast(markersLayer.Markers(i), GmapMarkerTravel)

            If node.Position = marker.Index Then
                pos = marker.Position
                marker.Selected = True
            Else
                If marker.Selected Then
                    marker.Selected = False
                End If
            End If
        Next

        For Each nodo As TreeNode In tviewPoints.Nodes
            If nodo Is e.Node Then
                nodo.BackColor = ColorTranslator.FromHtml("#0078D7")
                nodo.ForeColor = Color.White
            Else
                nodo.BackColor = If(DirectCast(nodo, TreeNodeTravel).Speed > 0, Color.LightGreen, Color.LightCoral)
                nodo.ForeColor = Color.Black
            End If
        Next

        If btnCenterSelection.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen Then
            mapTravelHistory.Position = pos
        End If

        mapTravelHistory.Refresh()
    End Sub
End Class