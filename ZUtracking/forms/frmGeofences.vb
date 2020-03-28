Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports GMap.NET
Imports GMap
Imports GMap.NET.WindowsForms

Public Class frmGeofences
    Dim selectedPage As Integer = 0
    Dim panel2LastHeight As Integer = 0

    Dim geoPoints As New List(Of PointLatLng)
    Dim mainGeofenceLayer As New GMapOverlay("mainGeofenceLayer")
    Dim clientGeofenceLayer As New GMapOverlay("clientGeofenceLayer")
    Dim asignGeofenceLayer As New GMapOverlay("asignGeofenceLayer")

    Private _isDrawing As Boolean
    Public Property IsDrawing() As Boolean
        Get
            Return _isDrawing
        End Get
        Set(ByVal value As Boolean)
            _isDrawing = value
            btnDraw.ButtonStyle = If(IsDrawing, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)
        End Set
    End Property

    Enum GeofenceMode
        Registering
        Editing
    End Enum

    Dim curGeofenceMode As GeofenceMode = GeofenceMode.Registering

    Dim dtGeofences As New DataTable("geofences")
    Dim dtClients As New DataTable("clients")

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        btnDraw.Parent = mapMainGeofence
        btnClean.Parent = mapMainGeofence
        btnRemoveLast.Parent = mapMainGeofence

        btnMap.Parent = mapMainGeofence
        btnSatellite.Parent = mapMainGeofence
        btnHybrid.Parent = mapMainGeofence
        tbarMapZoom.Parent = mapMainGeofence

        btnMapAsign.Parent = mapAsigns
        btnSatteliteAsign.Parent = mapAsigns
        btnHybridAsign.Parent = mapAsigns
        tbarMapAsign.Parent = mapAsigns

        rbtnAsignGeofence.Parent = panelHeader
        rbtnSearchAsigned.Parent = panelHeader

        rbtnAsignGeofence.Location = New Point(rbtnAsignGeofence.Location.X, gboxAsignGeofence.Location.Y)
        rbtnSearchAsigned.Location = New Point(rbtnSearchAsigned.Location.X, gboxSearchAsigned.Location.Y)

        Dim col1 As New DataColumn("geofence_id")
        Dim col2 As New DataColumn("geofence_name")
        Dim col3 As New DataColumn("client_id")
        Dim col4 As New DataColumn("client_name")
        dtGeofences.Columns.Add(col1)
        dtGeofences.Columns.Add(col2)
        dtClients.Columns.Add(col3)
        dtClients.Columns.Add(col4)
    End Sub

    Private Sub tabConsole_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabConsole.DrawItem
        If e.Index = selectedPage Then
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGreen), e.Bounds)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.FromKnownColor(KnownColor.Control)), e.Bounds)
        End If

        Dim tabCtrl As TabControl = DirectCast(sender, TabControl)
        Dim fontBrush As Brush = Brushes.Black
        Dim title As String = tabCtrl.TabPages(e.Index).Text
        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        Dim indent As Integer = 2
        Dim rect As New Rectangle(e.Bounds.X, e.Bounds.Y + indent, e.Bounds.Width, e.Bounds.Height - indent)

        ' draw title
        e.Graphics.DrawString(title, tabCtrl.Font, fontBrush, rect, sf)

        ' draw image if available
        If tabCtrl.TabPages(e.Index).ImageIndex >= 0 Then
            Dim img As Image = tabCtrl.ImageList.Images(tabCtrl.TabPages(e.Index).ImageIndex)
            Dim _x As Single = (rect.X + rect.Width) - img.Width - indent - 2
            Dim _y As Single = ((rect.Height - img.Height) / 2.0F) + rect.Y - 2
            e.Graphics.DrawImage(img, _x, _y)
        End If
    End Sub

    Private Sub tabConsole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabConsole.SelectedIndexChanged
        selectedPage = tabConsole.SelectedIndex
        tabConsole.Refresh()
    End Sub

    Private Sub btnHeaderPanel2Collapsing_Click(sender As Object, e As EventArgs) Handles btnHeaderPanel2Collapsing.Click
        If splitHeader.Panel2Collapsed Then
            splitHeader.Panel2Collapsed = False
            splitHorizontal.SplitterDistance = splitHeader.Panel1.Size.Height + panel2LastHeight
            splitHorizontal.IsSplitterFixed = splitHeader.Panel2Collapsed
        Else
            panel2LastHeight = splitHeader.Panel2.Height
            splitHeader.Panel2Collapsed = True
            splitHorizontal.SplitterDistance = splitHeader.Panel1MinSize
            splitHorizontal.IsSplitterFixed = splitHeader.Panel2Collapsed
        End If

        btnHeaderPanel2Collapsing.BackgroundImage = If(splitHeader.Panel2Collapsed, My.Resources.uncollapse_icon, My.Resources.collapse_icon)

    End Sub

    Private Sub frmGeofences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        panel2LastHeight = splitHeader.Panel2.Height
        tbarMapZoom.Value = mapMainGeofence.Zoom
        tbarMapAsign.Value = mapAsigns.Zoom

        dgvGeofences.ScrollBars = ScrollBars.None
        DrawingControl.SuspendDrawing(dgvGeofences)
        bgwGetGeofences.RunWorkerAsync()
        bgwGetClients.RunWorkerAsync()

        rbtnAsignGeofence.BringToFront()
        rbtnSearchAsigned.BringToFront()
    End Sub

    Private Sub fillComboGeofences(ByVal geofence As Object)
        cboGeofenceToAsign.DataSource = Nothing

        dtGeofences.Rows.Clear()

        If geofence.Rows.Count > 0 Then
            For i = 0 To geofence.Rows.Count - 1
                Dim row2 As DataRow = geofence.Rows(i)
                Dim row As DataRow = dtGeofences.NewRow
                row.Item("geofence_id") = row2("geofence_id")
                row.Item("geofence_name") = row2("name")
                dtGeofences.Rows.Add(row)
            Next
        End If

        cboGeofenceToAsign.DataSource = dtGeofences.Copy
        cboGeofenceToAsign.DisplayMember = "geofence_name"
        cboGeofenceToAsign.ValueMember = "geofence_id"
        cboGeofenceToAsign.SelectedIndex = -1
    End Sub

    Private Sub bgwGetGeofences_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwGetGeofences.DoWork
        Try
            bgwGetGeofences.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("geofences_getAll") Then
                bgwGetGeofences.ReportProgress(2, proc.Ds.Tables)
            Else
                bgwGetGeofences.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetGeofences.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetGeofences_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetGeofences.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                lblLoading.Text = "Cargando geocercas... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                dgvGeofences.Rows.Clear()

                If e.UserState(0).Rows.Count > 0 Then
                    For i = 0 To e.UserState(0).Rows.Count - 1
                        Dim row As DataRow = e.UserState(0).Rows(i)
                        dgvGeofences.Rows.Add()
                        dgvGeofences.Rows(i).Cells("dgvGeofences_name").Value = row("name")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_description").Value = row("description")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_status").Value = row("status")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_asigns").Value = row("asigns")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_geofence_id").Value = row("geofence_id")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_points").Value = row("points")

                        'Dim points As New List(Of GeofencePoint)
                        'If e.UserState(1).Rows.Count > 0 Then
                        '    For x = 0 To e.UserState(1).Rows.Count - 1
                        '        Dim row2 As DataRow = e.UserState(1).Rows(x)
                        '        Dim geofencePoint As New GeofencePoint
                        '        geofencePoint.GeofencePointId = If(row2("geofence_point_id") Is DBNull.Value, 0, row2("geofence_point_id"))
                        '        geofencePoint.GeofenceId = row("geofence_id")
                        '        geofencePoint.Latitude = If(row2("latitude") Is DBNull.Value, 0, row2("latitude"))
                        '        geofencePoint.Longitude = If(row2("longitude") Is DBNull.Value, 0, row2("longitude"))
                        '        points.Add(geofencePoint)
                        '    Next
                        'End If

                        'dgvGeofences.Rows(i).Cells("dgvGeofences_points").Value = New JavaScriptSerializer().Serialize(points)
                    Next
                End If

                fillComboGeofences(e.UserState(0))

                panelLoading.Visible = False
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelLoading.Visible = False
                Exit Select
        End Select
    End Sub

    Public Function GetRectOfPolygonMain(polygonName As String) As RectLatLng?
        Dim ret As RectLatLng? = Nothing

        Dim left As Double = Double.MaxValue
        Dim top As Double = Double.MinValue
        Dim right As Double = Double.MinValue
        Dim bottom As Double = Double.MaxValue

        For Each o As GMapOverlay In mapMainGeofence.Overlays
            If mainGeofenceLayer.IsVisibile AndAlso o.Polygons.Count > 0 Then
                For Each poly As GMapPolygon In o.Polygons
                    If poly.IsVisible AndAlso poly.From.HasValue AndAlso poly.[To].HasValue AndAlso poly.Name.Equals(polygonName) Then
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

    Public Function GetRectOfPolygonAsign(polygonName As String) As RectLatLng?
        Dim ret As RectLatLng? = Nothing

        Dim left As Double = Double.MaxValue
        Dim top As Double = Double.MinValue
        Dim right As Double = Double.MinValue
        Dim bottom As Double = Double.MaxValue

        For Each o As GMapOverlay In mapAsigns.Overlays
            If asignGeofenceLayer.IsVisibile AndAlso o.Polygons.Count > 0 Then
                For Each poly As GMapPolygon In o.Polygons
                    If poly.IsVisible AndAlso poly.From.HasValue AndAlso poly.[To].HasValue AndAlso poly.Name.Equals(polygonName) Then
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

    Private Sub dgvGeofences_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGeofences.CellClick
        If e.RowIndex >= 0 Then
            If Not dgvGeofences.CurrentRow.Cells("dgvGeofences_points").Value = "" Then
                txtName.Text = dgvGeofences.CurrentRow.Cells("dgvGeofences_name").Value
                txtDescription.Text = dgvGeofences.CurrentRow.Cells("dgvGeofences_description").Value
                cboxGeofenceStatus.Checked = dgvGeofences.CurrentRow.Cells("dgvGeofences_status").Value = 1

                Dim points As List(Of GeofencePoint) = New JavaScriptSerializer().Deserialize(Of List(Of GeofencePoint))(dgvGeofences.CurrentRow.Cells("dgvGeofences_points").Value)

                geoPoints.Clear()

                If points.Count > 0 Then
                    For i = 0 To points.Count - 1
                        geoPoints.Add(New PointLatLng(points(i).Latitude, points(i).Longitude))
                    Next
                End If

                drawGeofence()

                Dim rect As RectLatLng? = GetRectOfPolygonMain("geofence")
                If rect.HasValue Then
                    mapMainGeofence.SetZoomToFitRect(rect.Value)
                End If

                btnNewGeofence.Enabled = True
                btnEditGeofence.Enabled = True
                btnSaveGeofence.Enabled = False
                btnDeleteGeofence.Enabled = True
                btnCancelGeofence.Enabled = True
            End If
        End If
    End Sub

    Private Sub cboxGeofenceStatus_CheckedChanged(sender As Object, e As EventArgs) Handles cboxGeofenceStatus.CheckedChanged
        lblGeofenceStatus.BackColor = If(cboxGeofenceStatus.Checked, Color.LightGreen, Color.LightCoral)
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        mapMainGeofence.MapProvider = MapProviders.GoogleChinaMapProvider.Instance
    End Sub

    Private Sub btnSatellite_Click(sender As Object, e As EventArgs) Handles btnSatellite.Click
        mapMainGeofence.MapProvider = MapProviders.GoogleChinaSatelliteMapProvider.Instance
    End Sub

    Private Sub btnHybrid_Click(sender As Object, e As EventArgs) Handles btnHybrid.Click
        mapMainGeofence.MapProvider = MapProviders.GoogleChinaHybridMapProvider.Instance
    End Sub

    Private Sub mapMainGeofence_OnMapZoomChanged() Handles mapMainGeofence.OnMapZoomChanged
        tbarMapZoom.Value = mapMainGeofence.Zoom
    End Sub

    Private Sub tbarMapZoom_ValueChanged(sender As Object, value As Decimal) Handles tbarMapZoom.ValueChanged
        mapMainGeofence.Zoom = tbarMapZoom.Value
    End Sub

    Private Sub btnNewGeofence_Click(sender As Object, e As EventArgs) Handles btnNewGeofence.Click
        txtName.Enabled = True
        txtName.Text = ""
        txtDescription.Enabled = True
        txtDescription.Text = ""
        cboxGeofenceStatus.Enabled = True
        cboxGeofenceStatus.Checked = True

        dgvGeofences.Enabled = False

        btnNewGeofence.Enabled = False
        btnEditGeofence.Enabled = False
        btnSaveGeofence.Enabled = False
        btnDeleteGeofence.Enabled = False
        btnCancelGeofence.Enabled = True

        IsDrawing = False
        btnDraw.Enabled = True
        btnClean.Enabled = False
        btnRemoveLast.Enabled = False

        mainGeofenceLayer.Polygons.Clear()

        geoPoints = New List(Of PointLatLng)
        curGeofenceMode = GeofenceMode.Registering
        txtName.Focus()
    End Sub

    Private Sub btnCancelGeofence_Click(sender As Object, e As EventArgs) Handles btnCancelGeofence.Click
        txtName.Enabled = False
        txtName.Text = ""
        txtDescription.Enabled = False
        txtDescription.Text = ""
        cboxGeofenceStatus.Enabled = False
        cboxGeofenceStatus.Checked = False

        dgvGeofences.Enabled = True

        btnNewGeofence.Enabled = True
        btnEditGeofence.Enabled = False
        btnSaveGeofence.Enabled = False
        btnDeleteGeofence.Enabled = False
        btnCancelGeofence.Enabled = False

        IsDrawing = False
        btnDraw.Enabled = False
        btnClean.Enabled = False
        btnRemoveLast.Enabled = False

        mainGeofenceLayer.Polygons.Clear()
    End Sub

    Private Sub btnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        IsDrawing = Not IsDrawing
        If Not IsDrawing Then
            btnClean.Enabled = False
            btnRemoveLast.Enabled = False
        End If
    End Sub

    Private Sub mapMainGeofence_MouseClick(sender As Object, e As MouseEventArgs) Handles mapMainGeofence.MouseClick
        Try
            If e.Button = MouseButtons.Left Then
                If IsDrawing Then
                    If Not mapMainGeofence.IsDragging Then
                        geoPoints.Add(mapMainGeofence.FromLocalToLatLng(e.X, e.Y))
                        drawGeofence()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub drawGeofence()
        mainGeofenceLayer.IsVisibile = False

        Dim geofence As New GMapPolygon(geoPoints, "geofence")
        geofence.Stroke = New Pen(Brushes.Blue, 2)
        geofence.Fill = New SolidBrush(Color.FromArgb(20, Color.Blue))
        mainGeofenceLayer.Polygons.Clear()
        mainGeofenceLayer.Polygons.Add(geofence)

        If Not mapMainGeofence.Overlays.Contains(mainGeofenceLayer) Then
            mapMainGeofence.Overlays.Add(mainGeofenceLayer)
        End If

        mainGeofenceLayer.IsVisibile = True

        btnSaveGeofence.Enabled = geoPoints.Count > 2
        btnClean.Enabled = IsDrawing And geoPoints.Count > 0
        btnRemoveLast.Enabled = IsDrawing And geoPoints.Count > 0
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        geoPoints.Clear()
        drawGeofence()
    End Sub

    Private Sub btnRemoveLast_Click(sender As Object, e As EventArgs) Handles btnRemoveLast.Click
        geoPoints.RemoveAt(geoPoints.Count - 1)
        drawGeofence()
    End Sub

    Private Sub btnEditGeofence_Click(sender As Object, e As EventArgs) Handles btnEditGeofence.Click
        txtName.Enabled = True
        txtDescription.Enabled = True
        cboxGeofenceStatus.Enabled = True

        dgvGeofences.Enabled = False

        btnNewGeofence.Enabled = False
        btnEditGeofence.Enabled = False
        btnSaveGeofence.Enabled = geoPoints.Count > 2
        btnDeleteGeofence.Enabled = False
        btnCancelGeofence.Enabled = True

        IsDrawing = False
        btnDraw.Enabled = True
        btnClean.Enabled = False
        btnRemoveLast.Enabled = False

        curGeofenceMode = GeofenceMode.Editing
        txtName.Focus()
    End Sub

    Private Sub btnSaveGeofence_Click(sender As Object, e As EventArgs) Handles btnSaveGeofence.Click
        If Not bgwSavingGeofences.IsBusy Then
            If txtName.Text.Trim = "" Then
                MsgBox("Debe indicar un nombre para la geocerca", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                txtName.Focus()
                Exit Sub
            End If

            If txtDescription.Text.Trim = "" Then
                MsgBox("Debe indicar la descripción de la geocerca", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                txtDescription.Focus()
                Exit Sub
            End If

            If MsgBox("¿Confirma que desea guardar la geocerca?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                bgwSavingGeofences.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwSavingGeofences_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSavingGeofences.DoWork
        Try
            bgwSavingGeofences.ReportProgress(1)

            Dim points As New List(Of GeofencePoint)

            For i = 0 To geoPoints.Count - 1
                Dim point As New GeofencePoint
                point.Latitude = geoPoints(i).Lat
                point.Longitude = geoPoints(i).Lng
                points.Add(point)
            Next

            Dim strPoints As String = New JavaScriptSerializer().Serialize(points)

            Dim proc As New Procedure

            If curGeofenceMode = GeofenceMode.Registering Then
                If proc.GetData("geofences_insert",
                                                txtName.Text.Trim,
                                                txtDescription.Text.Trim,
                                                If(cboxGeofenceStatus.Checked, 1, 0),
                                                strPoints) Then

                    bgwSavingGeofences.ReportProgress(2, proc.Ds.Tables)
                Else
                    bgwSavingGeofences.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("geofences_update",
                                                dgvGeofences.CurrentRow.Cells("dgvGeofences_geofence_id").Value,
                                                txtName.Text.Trim,
                                                txtDescription.Text.Trim,
                                                If(cboxGeofenceStatus.Checked, 1, 0),
                                                strPoints) Then
                    bgwSavingGeofences.ReportProgress(2, proc.Ds.Tables)
                Else
                    bgwSavingGeofences.ReportProgress(3, proc.ErrorMsg)
                End If
            End If

        Catch ex As Exception
            bgwSavingGeofences.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingGeofences_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSavingGeofences.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                gboxGeofenceMantainer.Enabled = False
                dgvGeofences.Enabled = False
                splitHorizontal.Panel2.Enabled = False
                lblLoading.Text = "Guardando geocerca... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                dgvGeofences.Rows.Clear()

                If e.UserState(0).Rows.Count > 0 Then
                    For i = 0 To e.UserState(0).Rows.Count - 1
                        Dim row As DataRow = e.UserState(0).Rows(i)
                        dgvGeofences.Rows.Add()
                        dgvGeofences.Rows(i).Cells("dgvGeofences_name").Value = row("name")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_description").Value = row("description")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_status").Value = row("status")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_asigns").Value = row("asigns")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_geofence_id").Value = row("geofence_id")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_points").Value = row("points")

                        'Dim points As New List(Of GeofencePoint)
                        'If e.UserState(1).Rows.Count > 0 Then
                        '    For x = 0 To e.UserState(1).Rows.Count - 1
                        '        Dim row2 As DataRow = e.UserState(1).Rows(x)
                        '        Dim geofencePoint As New GeofencePoint
                        '        geofencePoint.GeofencePointId = If(row2("geofence_point_id") Is DBNull.Value, 0, row2("geofence_point_id"))
                        '        geofencePoint.GeofenceId = row("geofence_id")
                        '        geofencePoint.Latitude = If(row2("latitude") Is DBNull.Value, 0, row2("latitude"))
                        '        geofencePoint.Longitude = If(row2("longitude") Is DBNull.Value, 0, row2("longitude"))
                        '        points.Add(geofencePoint)
                        '    Next
                        'End If


                    Next
                End If

                fillComboGeofences(e.UserState(0))

                gboxGeofenceMantainer.Enabled = True
                dgvGeofences.Enabled = True
                splitHorizontal.Panel2.Enabled = True
                panelLoading.Visible = False

                Dim msg As String = If(curGeofenceMode = GeofenceMode.Registering, "Geocerca ingresada exitosamente", "Geocerca actualizada exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                Call btnCancelGeofence_Click(Nothing, Nothing)
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString, MsgBoxStyle.Critical, "Mensaje del Sistema")
                gboxGeofenceMantainer.Enabled = True
                dgvGeofences.Enabled = True
                splitHorizontal.Panel2.Enabled = True
                panelLoading.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub btnDeleteGeofence_Click(sender As Object, e As EventArgs) Handles btnDeleteGeofence.Click
        If Not bgwDeletingGeofences.IsBusy Then
            If MsgBox("¿Confirma que desea guardar la geocerca?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                bgwDeletingGeofences.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwDeletingGeofences_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeletingGeofences.DoWork
        Try
            bgwDeletingGeofences.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("geofences_delete", dgvGeofences.CurrentRow.Cells("dgvGeofences_geofence_id").Value) Then
                bgwDeletingGeofences.ReportProgress(2, proc.Ds.Tables)
            Else
                bgwDeletingGeofences.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingGeofences.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingGeofences_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeletingGeofences.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                gboxGeofenceMantainer.Enabled = False
                dgvGeofences.Enabled = False
                splitHorizontal.Panel2.Enabled = False
                lblLoading.Text = "Eliminando geocerca... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                dgvGeofences.Rows.Clear()

                If e.UserState(0).Rows.Count > 0 Then
                    For i = 0 To e.UserState(0).Rows.Count - 1
                        Dim row As DataRow = e.UserState(0).Rows(i)
                        dgvGeofences.Rows.Add()
                        dgvGeofences.Rows(i).Cells("dgvGeofences_name").Value = row("name")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_description").Value = row("description")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_status").Value = row("status")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_asigns").Value = row("asigns")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_geofence_id").Value = row("geofence_id")
                        dgvGeofences.Rows(i).Cells("dgvGeofences_points").Value = row("points")
                        'Dim points As New List(Of GeofencePoint)
                        'If e.UserState(1).Rows.Count > 0 Then
                        '    For x = 0 To e.UserState(1).Rows.Count - 1
                        '        Dim row2 As DataRow = e.UserState(1).Rows(x)
                        '        Dim geofencePoint As New GeofencePoint
                        '        geofencePoint.GeofencePointId = If(row2("geofence_point_id") Is DBNull.Value, 0, row2("geofence_point_id"))
                        '        geofencePoint.GeofenceId = row("geofence_id")
                        '        geofencePoint.Latitude = If(row2("latitude") Is DBNull.Value, 0, row2("latitude"))
                        '        geofencePoint.Longitude = If(row2("longitude") Is DBNull.Value, 0, row2("longitude"))
                        '        points.Add(geofencePoint)
                        '    Next
                        'End If
                    Next
                End If

                fillComboGeofences(e.UserState(0))

                gboxGeofenceMantainer.Enabled = True
                dgvGeofences.Enabled = True
                splitHorizontal.Panel2.Enabled = True
                panelLoading.Visible = False

                MsgBox("Geocerca eliminada exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                Call btnCancelGeofence_Click(Nothing, Nothing)
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString, MsgBoxStyle.Critical, "Mensaje del Sistema")
                gboxGeofenceMantainer.Enabled = True
                dgvGeofences.Enabled = True
                splitHorizontal.Panel2.Enabled = True
                panelLoading.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub rbtnAsignGeofence_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAsignGeofence.CheckedChanged
        cboClientToAsign.SelectedIndex = -1
        cboVehicleToAsign.SelectedIndex = -1
        cboGeofenceToAsign.SelectedIndex = -1
        gboxAsignGeofence.Enabled = rbtnAsignGeofence.Checked
    End Sub

    Private Sub rbtnSearchAsigned_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSearchAsigned.CheckedChanged
        gboxSearchAsigned.Enabled = rbtnSearchAsigned.Checked
        dgvAsigns.Enabled = rbtnSearchAsigned.Checked
    End Sub

    Private Sub bgwGetClients_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetClients.DoWork
        Try
            bgwGetClients.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("clients_getAll") Then
                bgwGetClients.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwGetClients.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetClients.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetClients_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetClients.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                lblLoadingAsigns.Text = "Cargando clientes... Por favor espere"
                panelLoadingAsigns.Visible = True
                Exit Select
            Case 2
                cboClientToAsign.DataSource = Nothing

                dtClients.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row2 = e.UserState.Rows(i)
                        Dim row As DataRow = dtClients.NewRow
                        row.Item("client_id") = row2("client_id")
                        row.Item("client_name") = (row2("first_name") & " " & If(row2("last_name") Is DBNull.Value, "", row2("last_name"))).ToString().Trim
                        dtClients.Rows.Add(row)
                    Next
                End If

                cboClientToAsign.DataSource = dtClients.Copy
                cboClientToAsign.DisplayMember = "client_name"
                cboClientToAsign.ValueMember = "client_id"
                cboClientToAsign.SelectedIndex = -1

                panelLoadingAsigns.Visible = False
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelLoadingAsigns.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub cboVehicleToAsign_Enter(sender As Object, e As EventArgs) Handles cboVehicleToAsign.Enter
        Try
            If cboClientToAsign.SelectedIndex > -1 Then
                Dim proc As New Procedure

                cboVehicleToAsign.DataSource = Nothing

                Dim dt As New DataTable("vehicles")
                Dim col1 As New DataColumn("vehicle_id")
                Dim col2 As New DataColumn("vehicle_info")
                dt.Columns.Add(col1)
                dt.Columns.Add(col2)

                If proc.GetData("vehicles_getByClient", cboClientToAsign.SelectedValue) Then
                    If proc.Ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                            Dim row2 = proc.Ds.Tables(0).Rows(i)
                            Dim row As DataRow = dt.NewRow
                            row.Item("vehicle_id") = row2("vehicle_id")
                            row.Item("vehicle_info") = row2("license_plate") & " (" &
                                                   row2("brand") & " " &
                                                   row2("model") & " " &
                                                   row2("year") & " " &
                                                   row2("color") & ")"
                            dt.Rows.Add(row)
                        Next
                    End If
                Else
                    MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If

                cboVehicleToAsign.DataSource = dt
                cboVehicleToAsign.DisplayMember = "vehicle_info"
                cboVehicleToAsign.ValueMember = "vehicle_id"
                cboVehicleToAsign.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub cboClientToAsign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClientToAsign.SelectedIndexChanged
        cboVehicleToAsign.DataSource = Nothing
    End Sub

    Private Sub cboGeofenceToAsign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGeofenceToAsign.SelectedIndexChanged
        Try
            If cboGeofenceToAsign.SelectedIndex > -1 Then
                Dim index As Integer = 0

                For i = 0 To dgvGeofences.Rows.Count - 1
                    If dgvGeofences.Rows(i).Cells("dgvGeofences_geofence_id").Value = cboGeofenceToAsign.SelectedValue Then
                        index = i
                        Exit For
                    End If
                Next

                If Not dgvGeofences.Rows(index).Cells("dgvGeofences_points").Value = "" Then

                    Dim points As List(Of GeofencePoint) = New JavaScriptSerializer().Deserialize(Of List(Of GeofencePoint))(dgvGeofences.Rows(index).Cells("dgvGeofences_points").Value)

                    Dim geoAsignPoints As New List(Of PointLatLng)

                    If points.Count > 0 Then
                        For i = 0 To points.Count - 1
                            geoAsignPoints.Add(New PointLatLng(points(i).Latitude, points(i).Longitude))
                        Next
                    End If

                    drawGeofenceAsign(geoAsignPoints)

                    Dim rect As RectLatLng? = GetRectOfPolygonAsign("geofenceAsign")
                    If rect.HasValue Then
                        mapAsigns.SetZoomToFitRect(rect.Value)
                    End If
                End If
            Else
                asignGeofenceLayer.Polygons.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub drawGeofenceAsign(ByVal pts As List(Of PointLatLng))
        asignGeofenceLayer.IsVisibile = False

        Dim geofence As New GMapPolygon(pts, "geofenceAsign")
        geofence.Stroke = New Pen(Brushes.Blue, 2)
        geofence.Fill = New SolidBrush(Color.FromArgb(20, Color.Blue))
        asignGeofenceLayer.Polygons.Clear()
        asignGeofenceLayer.Polygons.Add(geofence)

        If Not mapAsigns.Overlays.Contains(asignGeofenceLayer) Then
            mapAsigns.Overlays.Add(asignGeofenceLayer)
        End If

        asignGeofenceLayer.IsVisibile = True
    End Sub

    Private Sub mapAsigns_OnMapZoomChanged() Handles mapAsigns.OnMapZoomChanged
        tbarMapAsign.Value = mapAsigns.Zoom
    End Sub

    Private Sub tbarMapAsign_ValueChanged(sender As Object, value As Decimal) Handles tbarMapAsign.ValueChanged
        mapAsigns.Zoom = tbarMapAsign.Value
    End Sub

    Private Sub btnAsign_Click(sender As Object, e As EventArgs) Handles btnAsign.Click
        If Not bgwAsigning.IsBusy Then
            If cboClientToAsign.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboClientToAsign.Focus()
                Exit Sub
            End If

            If cboVehicleToAsign.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboVehicleToAsign.Focus()
                Exit Sub
            End If

            If cboGeofenceToAsign.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una geocerca", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboGeofenceToAsign.Focus()
                Exit Sub
            End If

            bgwAsigning.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwAsigning_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwAsigning.DoWork
        Try
            bgwAsigning.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("geofences_vehicles_insert", cboGeofenceToAsign.SelectedValue, cboVehicleToAsign.SelectedValue) Then
                bgwAsigning.ReportProgress(2)
            Else
                bgwAsigning.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwAsigning.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwAsigning_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwAsigning.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                dgvAsigns.Enabled = False
                splitHorizontalAsign1.Panel2.Enabled = False
                lblLoadingAsigns.Text = "Asignando geocerca... Por favor espere"
                panelLoadingAsigns.Visible = True
                Exit Select
            Case 2
                panelHeader.Enabled = True
                dgvAsigns.Enabled = True
                splitHorizontalAsign1.Panel2.Enabled = True
                panelLoadingAsigns.Visible = False

                cboClientToAsign.SelectedIndex = -1
                cboVehicleToAsign.SelectedIndex = -1
                cboGeofenceToAsign.SelectedIndex = -1

                asignGeofenceLayer.Polygons.Clear()

                MsgBox("Geocerca asignada exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Select
            Case 3
                panelHeader.Enabled = True
                dgvAsigns.Enabled = True
                splitHorizontalAsign1.Panel2.Enabled = True
                panelLoadingAsigns.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub rbtnSearchAllAsigns_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSearchAllAsigns.CheckedChanged
        cboSearchAsigns.DataSource = Nothing
        cboSearchAsigns.Enabled = False
    End Sub

    Private Sub rbtnSearchByGeofence_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSearchByGeofence.CheckedChanged
        cboSearchAsigns.DataSource = dtGeofences.Copy
        cboSearchAsigns.DisplayMember = "geofence_name"
        cboSearchAsigns.ValueMember = "geofence_id"
        cboSearchAsigns.Enabled = True
        cboSearchAsigns.SelectedIndex = -1
    End Sub

    Private Sub rbtnSearchByClient_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSearchByClient.CheckedChanged
        cboSearchAsigns.DataSource = dtClients.Copy
        cboSearchAsigns.DisplayMember = "client_name"
        cboSearchAsigns.ValueMember = "client_id"
        cboSearchAsigns.Enabled = True
        cboSearchAsigns.SelectedIndex = -1
    End Sub

    Private Sub dgvAsigns_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvAsigns.RowsAdded
        btnUnAsign.Enabled = dgvAsigns.CurrentRow IsNot Nothing
    End Sub

    Private Sub dgvAsigns_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvAsigns.RowsRemoved
        btnUnAsign.Enabled = dgvAsigns.CurrentRow IsNot Nothing
    End Sub

    Private Sub dgvAsigns_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAsigns.CellClick
        btnUnAsign.Enabled = dgvAsigns.CurrentRow IsNot Nothing

        If e.RowIndex >= 0 Then
            Dim index As Integer = 0

            For i = 0 To dgvGeofences.Rows.Count - 1
                If dgvGeofences.Rows(i).Cells("dgvGeofences_geofence_id").Value = dgvAsigns.CurrentRow.Cells("dgvAsigns_geofence_id").Value Then
                    index = i
                    Exit For
                End If
            Next

            If Not dgvGeofences.Rows(index).Cells("dgvGeofences_points").Value = "" Then

                Dim points As List(Of GeofencePoint) = New JavaScriptSerializer().Deserialize(Of List(Of GeofencePoint))(dgvGeofences.Rows(index).Cells("dgvGeofences_points").Value)

                Dim geoAsignPoints As New List(Of PointLatLng)

                If points.Count > 0 Then
                    For i = 0 To points.Count - 1
                        geoAsignPoints.Add(New PointLatLng(points(i).Latitude, points(i).Longitude))
                    Next
                End If

                drawGeofenceAsign(geoAsignPoints)

                Dim rect As RectLatLng? = GetRectOfPolygonAsign("geofenceAsign")
                If rect.HasValue Then
                    mapAsigns.SetZoomToFitRect(rect.Value)
                End If
            End If
        End If
    End Sub

    Private Sub btnSearchAsigns_Click(sender As Object, e As EventArgs) Handles btnSearchAsigns.Click
        If Not bgwSearchAsigns.IsBusy Then
            If rbtnSearchByGeofence.Checked AndAlso cboSearchAsigns.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una geocerca para buscar", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboSearchAsigns.Focus()
                Exit Sub
            End If

            If rbtnSearchByClient.Checked AndAlso cboSearchAsigns.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un cliente para buscar", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboSearchAsigns.Focus()
                Exit Sub
            End If

            dgvAsigns.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvAsigns)
            bgwSearchAsigns.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSearchAsigns_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSearchAsigns.DoWork
        Try
            bgwSearchAsigns.ReportProgress(1)

            Dim geofence_id As Integer = If(rbtnSearchByGeofence.Checked, cboSearchAsigns.SelectedValue, 0)
            Dim client_id As Integer = If(rbtnSearchByClient.Checked, cboSearchAsigns.SelectedValue, 0)

            Dim proc As New Procedure

            If proc.GetData("geofences_vehicles_getAll", geofence_id, client_id) Then
                bgwSearchAsigns.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwSearchAsigns.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwSearchAsigns.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSearchAsigns_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSearchAsigns.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                dgvAsigns.Enabled = False
                splitHorizontalAsign1.Panel2.Enabled = False
                lblLoadingAsigns.Text = "Buscando geocercas... Por favor espere"
                panelLoadingAsigns.Visible = True
                Exit Select
            Case 2
                panelHeader.Enabled = True
                dgvAsigns.Enabled = True
                dgvAsigns.Rows.Clear()
                splitHorizontalAsign1.Panel2.Enabled = True
                panelLoadingAsigns.Visible = False
                asignGeofenceLayer.Polygons.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvAsigns.Rows.Add()
                        dgvAsigns.Rows(i).Cells("dgvAsigns_client_name").Value = (row("first_name") & " " & If(row("last_name") Is DBNull.Value, "", row("last_name"))).ToString().Trim
                        dgvAsigns.Rows(i).Cells("dgvAsigns_license_plate").Value = row("license_plate")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_brand").Value = row("brand")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_model").Value = row("model")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_type").Value = row("type")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_year").Value = row("year")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_color").Value = row("color")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_geofence_name").Value = row("name")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_client_id").Value = row("client_id")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_vehicle_id").Value = row("vehicle_id")
                        dgvAsigns.Rows(i).Cells("dgvAsigns_geofence_id").Value = row("geofence_id")
                    Next
                End If
                asignGeofenceLayer.Polygons.Clear()
                btnUnAsign.Enabled = dgvAsigns.CurrentRow IsNot Nothing
                Exit Select
            Case 3
                panelHeader.Enabled = True
                dgvAsigns.Enabled = True
                splitHorizontalAsign1.Panel2.Enabled = True
                panelLoadingAsigns.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnUnAsign_Click(sender As Object, e As EventArgs) Handles btnUnAsign.Click
        If Not bgwUnAsigning.IsBusy Then
            If MsgBox("¿Está seguro de desasignar la geocerca seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                bgwUnAsigning.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwUnAsigning_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwUnAsigning.DoWork
        Try
            bgwUnAsigning.ReportProgress(1)
            Dim geofence_id As Integer = dgvAsigns.CurrentRow.Cells("dgvAsigns_geofence_id").Value
            Dim vehicle_id As Integer = dgvAsigns.CurrentRow.Cells("dgvAsigns_vehicle_id").Value

            Dim proc As New Procedure

            If proc.GetData("geofences_vehicles_delete", geofence_id, vehicle_id) Then
                bgwUnAsigning.ReportProgress(2)
            Else
                bgwUnAsigning.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwUnAsigning.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwUnAsigning_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwUnAsigning.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                dgvAsigns.Enabled = False
                splitHorizontalAsign1.Panel2.Enabled = False
                lblLoadingAsigns.Text = "Desasignando geocerca... Por favor espere"
                panelLoadingAsigns.Visible = True
                Exit Select
            Case 2
                panelHeader.Enabled = True
                dgvAsigns.Enabled = True
                dgvAsigns.Rows.Clear()
                splitHorizontalAsign1.Panel2.Enabled = True
                panelLoadingAsigns.Visible = False
                asignGeofenceLayer.Polygons.Clear()
                btnUnAsign.Enabled = dgvAsigns.CurrentRow IsNot Nothing
                MsgBox("Geocerca desasignada exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Select
            Case 3
                panelHeader.Enabled = True
                dgvAsigns.Enabled = True
                splitHorizontalAsign1.Panel2.Enabled = True
                panelLoadingAsigns.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnMapAsign_Click(sender As Object, e As EventArgs) Handles btnMapAsign.Click
        mapAsigns.MapProvider = MapProviders.GoogleChinaMapProvider.Instance
    End Sub

    Private Sub btnSatteliteAsign_Click(sender As Object, e As EventArgs) Handles btnSatteliteAsign.Click
        mapAsigns.MapProvider = MapProviders.GoogleChinaSatelliteMapProvider.Instance
    End Sub

    Private Sub btnHybridAsign_Click(sender As Object, e As EventArgs) Handles btnHybridAsign.Click
        mapAsigns.MapProvider = MapProviders.GoogleChinaHybridMapProvider.Instance
    End Sub

    Private Sub bgwGetGeofences_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetGeofences.RunWorkerCompleted
        dgvGeofences.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvGeofences)
    End Sub

    Private Sub bgwSearchAsigns_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSearchAsigns.RunWorkerCompleted
        dgvAsigns.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvAsigns)
    End Sub

    Private Sub bgwAsigning_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwAsigning.RunWorkerCompleted
        If Not bgwGetGeofences.IsBusy Then
            bgwGetGeofences.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwUnAsigning_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwUnAsigning.RunWorkerCompleted
        If Not bgwGetGeofences.IsBusy Then
            bgwGetGeofences.RunWorkerAsync()
        End If
    End Sub
End Class