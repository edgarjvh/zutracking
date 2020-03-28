Imports System.ComponentModel
Imports System.Text
Imports System.Web.Script.Serialization
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports ZUtracking.SMS.Decoder
Imports System.Deployment.Application
Imports System.IO
Imports MimeKit
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class FrmMain

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'My.Settings.curUserId = "0"
        'My.Settings.curUserName = "ADMINISTRADOR DEL SISTEMA"
        'My.Settings.Save()

        CurUser = New User With {
            .Id = 0,
            .FirstName = "ADMINISTRADOR DEL SISTEMA",
            .LastName = ""
        }

        lblUser.Text = CurUser.FirstName & " " & CurUser.LastName
        tbarMapZoom.Parent = mapMain
        btnMap.Parent = mapMain
        btnSatellite.Parent = mapMain
        btnHybrid.Parent = mapMain
        setEventsDatatable()

        Dim fontBold As New Font(tviewClients.Font, FontStyle.Bold)
        tviewClients.Font = fontBold
        tviewActiveClients.Font = fontBold
        tviewInactiveClients.Font = fontBold
    End Sub

    Public Sub New(ByVal user As Object)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CurUser = DirectCast(user, User)

        My.Settings.curUserId = CurUser.Id
        My.Settings.curUserName = (CurUser.FirstName & " " & CurUser.LastName).ToString().Trim
        My.Settings.Save()
        lblUser.Text = My.Settings.curUserName
        tbarMapZoom.Parent = mapMain
        btnMap.Parent = mapMain
        btnSatellite.Parent = mapMain
        btnHybrid.Parent = mapMain

        If user.Id = 0 Then
            panelInfo.Enabled = False
            splitParent.Enabled = False

            For Each mnu As ToolStripItem In menuMain.Items
                If mnu.Name <> "menuUsers" AndAlso mnu.Name <> "menuOptions" Then
                    mnu.Enabled = False
                End If
            Next

            For Each mnu As ToolStripItem In cmenuOptions.Items
                If mnu.Name <> "menuOptionDatabase" Then
                    mnu.Enabled = False
                End If
            Next
        End If

        Dim fontBold As New Font(tviewClients.Font, FontStyle.Bold)
        tviewClients.Font = fontBold
        tviewActiveClients.Font = fontBold
        tviewInactiveClients.Font = fontBold

        setEventsDatatable()
        markersMovingLayer.IsVisibile = False
    End Sub

    Private _curUser As User
    Public Property CurUser() As User
        Get
            Return _curUser
        End Get
        Set(ByVal value As User)
            _curUser = value
        End Set
    End Property


    Dim selectedPage As Integer = 0
    Dim markersLayer As New GMapOverlay("markersLayer")
    Dim markersMovingLayer As New GMapOverlay("markersMovingLayer")
    Dim eventsLayer As New GMapOverlay("eventsLayer")
    Dim bgw As BackgroundWorker
    Dim textsToVoice As New List(Of String)
    Dim dtEvents As New DataTable("dtEvents")

    Private Sub setEventsDatatable()
        dtEvents.Columns.Add(New DataColumn("dgvEvents_onMap"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_client_name"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_imei"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_license_plate"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_date_time"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_name"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_validation"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_client_id"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_vehicle_id"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_report_type_id"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_geofence_id"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_geofence_points"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_latitude"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_longitude"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_speed"))
        dtEvents.Columns.Add(New DataColumn("dgvEvents_orientation"))

    End Sub


    Public Sub changeUser(ByVal username As String)
        lblUser.Text = username
    End Sub

    Private Sub timerDateTime_Tick(sender As Object, e As EventArgs) Handles timerDateTime.Tick
        lblDateTime.Text = Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        Dim ver As String = "0.0.0.0"
        Try
            ver = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Catch ex As Exception
        End Try

        Text = String.Format("ZUtracking V{0} - Principal", ver)

        tabConsole.TabPages.Remove(tpageNoReportingVehicles)
        tabConsole.SelectedTab = tpageModemSms
        tabConsole.SelectedTab = tpageVehicles

        'menuTravelHistory.Text = "Historial de" & vbNewLine & "Recorrido"
        'menuEventHistory.Text = "Historial de" & vbNewLine & "Eventos"
        'menuNoReporting.Text = "Vehículos" & vbNewLine & "Sin Reportar"

        Select Case My.Settings.currentVoice
            Case "Ximena"
                rbtnOptionXimena.Checked = True
                Exit Select
            Case "Carlos"
                rbtnOptionCarlos.Checked = True
                Exit Select
            Case "Carmen"
                rbtnOptionCarmen.Checked = True
                Exit Select
            Case "Soledad"
                rbtnOptionSoledad.Checked = True
                Exit Select
            Case "Jorge"
                rbtnOptionJorge.Checked = True
                Exit Select
            Case Else
                rbtnOptionNone.Checked = True
                Exit Select
        End Select

        eventsLayer.IsVisibile = False

        ServidorPrincipalToolStripMenuItem.Checked = My.Settings.isMainServer

        timerDateTime.Start()
        tbarMapZoom.Value = mapMain.Zoom
        getDealers(0)
        bgwModemSms.RunWorkerAsync()
        bgwGetCurrentLocations.RunWorkerAsync()
        bgwSendEventsEmail.RunWorkerAsync()
    End Sub

    Private Sub timerCountdown_Tick(sender As Object, e As EventArgs) Handles timerCountdown.Tick
        Dim value As Integer = Integer.Parse(lblCountdown.Text)

        If value = 0 Then
            lblCountdown.Text = 30
        Else
            lblCountdown.Text = (value - 1).ToString().PadLeft(2, "0")
        End If

        Select Case value
            Case 25
                If Not bgwGetEvents.IsBusy Then
                    DrawingControl.SuspendDrawing(dgvEvents)
                    dgvEvents.ScrollBars = ScrollBars.None
                    bgwGetEvents.RunWorkerAsync()
                End If

                If Not bgwModemSms.IsBusy Then
                    bgwModemSms.RunWorkerAsync()
                End If
                Exit Select
            Case 20
                'If Not bgwNoReportingVehicles.IsBusy Then
                '    DrawingControl.SuspendDrawing(dgvNoReportingVehicles)
                '    dgvNoReportingVehicles.Rows.Clear()
                '    dgvNoReportingVehicles.ScrollBars = ScrollBars.None
                '    bgwNoReportingVehicles.RunWorkerAsync()
                'End If

                If Not bgwModemSms.IsBusy Then
                    bgwModemSms.RunWorkerAsync()
                End If
                Exit Select
            Case 15
                If Not bgwGeofences.IsBusy Then
                    bgwGeofences.RunWorkerAsync()
                End If

                If Not bgwModemSms.IsBusy Then
                    bgwModemSms.RunWorkerAsync()
                End If
                Exit Select
            Case 10
                If Not bgwModemSms.IsBusy Then
                    bgwModemSms.RunWorkerAsync()
                End If
                Exit Select
            Case 5
                If Not bgwModemSms.IsBusy Then
                    bgwModemSms.RunWorkerAsync()
                End If
                Exit Select
            Case 1
                If Not bgwGetCurrentLocations.IsBusy Then
                    bgwGetCurrentLocations.RunWorkerAsync()
                End If
                If Not bgwModemSms.IsBusy Then
                    bgwModemSms.RunWorkerAsync()
                End If
                Exit Select
        End Select


    End Sub

    Private Sub btnReload_MouseDown(sender As Object, e As MouseEventArgs)
        btnReload.BackgroundImage = My.Resources.refresh_icon_smaller
    End Sub

    Private Sub btnReload_MouseUp(sender As Object, e As MouseEventArgs)
        btnReload.BackgroundImage = My.Resources.refresh_icon
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

    Private Sub mapMain_OnMapZoomChanged() Handles mapMain.OnMapZoomChanged
        tbarMapZoom.Value = mapMain.Zoom
    End Sub

    Private Sub tbarMainMap_ValueChanged(sender As Object, value As Decimal) Handles tbarMapZoom.ValueChanged
        mapMain.Zoom = tbarMapZoom.Value
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("¿Confirma que desea salir del sistema?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is frmLogin Then
                    frm.Close()
                    Exit For
                End If
            Next
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        mapMain.MapProvider = MapProviders.GoogleMapProvider.Instance
        btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
    End Sub

    Private Sub btnSatellite_Click(sender As Object, e As EventArgs) Handles btnSatellite.Click
        mapMain.MapProvider = MapProviders.GoogleChinaSatelliteMapProvider.Instance
        btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
        btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
    End Sub

    Private Sub btnHybrid_Click(sender As Object, e As EventArgs) Handles btnHybrid.Click
        mapMain.MapProvider = MapProviders.GoogleChinaHybridMapProvider.Instance
        btnMap.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnSatellite.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
        btnHybrid.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen
    End Sub

    Private Sub menuOptions_Click(sender As Object, e As EventArgs) Handles menuOptions.Click
        Dim x As Integer = 0

        For Each mnu As ToolStripItem In menuMain.Items
            If mnu.Visible Then
                If Not mnu.Name.ToLower.Contains("options") Then
                    x += mnu.Width
                End If
            End If
        Next

        cmenuOptions.Show(menuMain, x + 6, menuOptions.Height)
    End Sub

    Private Sub cmenuOptions_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles cmenuOptions.Closing
        If e.CloseReason = ToolStripDropDownCloseReason.ItemClicked Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ControlesDelMapaToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles menuOptionShowMapControls.CheckedChanged
        btnMap.Visible = menuOptionShowMapControls.Checked
        btnSatellite.Visible = menuOptionShowMapControls.Checked
        btnHybrid.Visible = menuOptionShowMapControls.Checked
        tbarMapZoom.Visible = menuOptionShowMapControls.Checked
        menuOptionShowMapControls.BackColor = If(menuOptionShowMapControls.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub MostrarCentroDelMapaToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles menuOptionShowMapCenter.CheckedChanged
        mapMain.ShowCenter = menuOptionShowMapCenter.Checked
        mapMain.Refresh()
        menuOptionShowMapCenter.BackColor = If(menuOptionShowMapCenter.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub VentanaDeClientesToolStripMenuItem1_CheckedChanged(sender As Object, e As EventArgs) Handles menuOptionShowClientsWindow.CheckedChanged
        splitParent.Panel1Collapsed = Not menuOptionShowClientsWindow.Checked
        menuOptionShowClientsWindow.BackColor = If(menuOptionShowClientsWindow.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub VentanaDeVehículosToolStripMenuItem1_CheckedChanged(sender As Object, e As EventArgs) Handles menuOptionShowVehiclesWindow.CheckedChanged
        splitChild.Panel2Collapsed = Not menuOptionShowVehiclesWindow.Checked
        menuOptionShowVehiclesWindow.BackColor = If(menuOptionShowVehiclesWindow.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub SimCardsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuSimCards.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmSimCards Then
                frm.WindowState = FormWindowState.Normal
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmSimCards.Show()
        frmSimCards.BringToFront()
    End Sub

    Private Sub DispositivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuDevices.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmDevices Then
                frm.WindowState = FormWindowState.Normal
                frm.BringToFront()
                Exit Sub
            End If
        Next

        Dim frmDevices As New frmDevices(serialModemSms)
        frmDevices.Show()
        frmDevices.BringToFront()
    End Sub

    Private Sub UsuariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles menuUsers.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmUsers Then
                frm.WindowState = FormWindowState.Normal
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmUsers.Show()
        frmUsers.BringToFront()
    End Sub

    Private Sub DealersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles menuDealers.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmDealers Then
                frm.WindowState = FormWindowState.Normal
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmDealers.Show()
        frmDealers.BringToFront()
    End Sub

    Private Sub CambioDeUsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles menuOptionSwitchUsers.Click
        Try
            If Application.OpenForms.Count > 2 Then
                If Not MsgBox("Hay ventanas abiertas que se cerrarán luego del cambio de usuario" & vbNewLine & "¿Desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If

            frmSwitchUser.Show()
            frmSwitchUser.BringToFront()
            Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub menuSystem_Click(sender As Object, e As EventArgs) Handles menuClients.Click
        Dim frm As New frmClients(0, Me)
        frm.Show()
        frm.BringToFront()
    End Sub

    Private Sub menuOptionModemSms_Click(sender As Object, e As EventArgs) Handles menuOptionModemSms.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmModemSms Then
                frm.WindowState = FormWindowState.Normal
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmModemSms.Show()
        frmModemSms.BringToFront()
    End Sub

    Private Sub rbtnOptionXimena_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptionXimena.CheckedChanged
        If rbtnOptionXimena.Checked Then
            My.Settings.currentVoice = "Ximena"
            My.Settings.Save()
        End If
    End Sub

    Private Sub rbtnOptionCarlos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptionCarlos.CheckedChanged
        If rbtnOptionCarlos.Checked Then
            My.Settings.currentVoice = "Carlos"
            My.Settings.Save()
        End If
    End Sub

    Private Sub rbtnOptionCarmen_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptionCarmen.CheckedChanged
        If rbtnOptionCarmen.Checked Then
            My.Settings.currentVoice = "Carmen"
            My.Settings.Save()
        End If
    End Sub

    Private Sub rbtnOptionSoledad_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptionSoledad.CheckedChanged
        If rbtnOptionSoledad.Checked Then
            My.Settings.currentVoice = "Soledad"
            My.Settings.Save()
        End If
    End Sub

    Private Sub rbtnOptionJorge_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptionJorge.CheckedChanged
        If rbtnOptionJorge.Checked Then
            My.Settings.currentVoice = "Jorge"
            My.Settings.Save()
        End If
    End Sub

    Private Sub rbtnOptionNone_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOptionNone.CheckedChanged
        If rbtnOptionNone.Checked Then
            My.Settings.currentVoice = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub menuReports_Click(sender As Object, e As EventArgs) Handles menuReports.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmReports Then
                frm.WindowState = FormWindowState.Maximized
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmReports.Show()
        frmReports.BringToFront()
    End Sub

    Private Sub menuGeofence_Click(sender As Object, e As EventArgs) Handles menuGeofence.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmGeofences Then
                frm.WindowState = FormWindowState.Maximized
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmGeofences.Show()
        frmGeofences.BringToFront()
    End Sub

    Private Sub menuEventHistory_Click(sender As Object, e As EventArgs) Handles menuEventHistory.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmEventHistory Then
                frm.WindowState = FormWindowState.Maximized
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmEventHistory.Show()
        frmEventHistory.BringToFront()
    End Sub

    Private Sub menuTravelHistory_Click(sender As Object, e As EventArgs) Handles menuTravelHistory.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmTravelHistory Then
                frm.WindowState = FormWindowState.Maximized
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmTravelHistory.Show()
        frmTravelHistory.BringToFront()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        If cboDealers.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If Not bgwGetClients.IsBusy Then
            clientsCount = 0
            vehiclesCount = 0
            For Each marker As GmapMarkerMain In markersLayer.Markers
                marker.IsVisible = False
            Next

            eventsLayer.Markers.Clear()
            eventsLayer.Polygons.Clear()

            For Each row As DataGridViewRow In dgvEvents.Rows
                If row.Cells("dgvEvents_onMap").Value Then
                    row.Cells("dgvEvents_onMap").Value = False
                End If
            Next

            lblLicensePlate.Text = "---"
            dgvGeofences.Rows.Clear()

            tviewActiveClients.Nodes.Clear()
            tviewInactiveClients.Nodes.Clear()
            tviewClients.Nodes.Clear()
            dgvConsoleVehicles.Rows.Clear()
            btnReload.Enabled = False

            DrawingControl.SuspendDrawing(tviewActiveClients)
            DrawingControl.SuspendDrawing(tviewInactiveClients)
            DrawingControl.SuspendDrawing(tviewClients)
            panelLoadingClients.Visible = True
            panelClientFilter.Enabled = False
            btnReload.Enabled = False
            bgwGetClients.RunWorkerAsync()
        End If
    End Sub

    Dim clientsCount As Integer = 0
    Dim clientsActivesCount As Integer = 0
    Dim clientsInactivesCount As Integer = 0
    Dim vehiclesCount As Integer = 0

    Private Sub bgwGetClients_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetClients.DoWork
        Try
            Do
            Loop While bgwGetCurrentLocations.IsBusy

            Dim proc As New Procedure
            Dim enc As New Encryptation

            Dim filter As String = txtClientFilter.Text.Trim

            If filter <> "" Then
                filter = "%" & filter & "%"
            End If

            If proc.GetData("clients_getByFilter", cboDealers.SelectedValue, filter) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then

                    Dim client_id As Integer = 0
                    Dim last_client_id As Integer = 0
                    Dim ClientNode As New ZUControls.ZUTreeNode

                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim percentage As Integer = ((i + 1) * 100) / proc.Ds.Tables(0).Rows.Count
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)
                        client_id = row("client_id")

                        If last_client_id = 0 Then ' si es el primer nodo se agrega el cliente y luego se verifica si tiene vehiculos
                            ClientNode.Text = String.Format("{0} {1}", row("first_name"), If(row("last_name") Is DBNull.Value, "", row("last_name"))).Trim() & " ([count])"
                            ClientNode.ClientId = client_id
                            ClientNode.ClientStatus = row("status_client")
                            ClientNode.ForeColor = Color.Black
                            If ClientNode.ClientStatus = 0 Then
                                ClientNode.ForeColor = Color.Red
                            End If

                            Dim DniChildNodeText As String = String.Format("Cédula: {0}", row("dni"))
                            Dim DniChildNode As New ZUControls.HiddenCheckBoxTreeNode(DniChildNodeText)

                            Dim PhonesChildNodeText As String = String.Format("Teléfonos: {0}", row("phone_number1") & If(row("phone_number2") = 0, "", " / " & row("phone_number2")))
                            Dim PhonesChildNode As New ZUControls.HiddenCheckBoxTreeNode(PhonesChildNodeText)

                            Dim VehiclesChildNodeText As String = "Vehículos"
                            Dim VehiclesChildNode As New ZUControls.HiddenCheckBoxTreeNode(VehiclesChildNodeText)

                            ClientNode.Nodes.Add(DniChildNode)
                            ClientNode.Nodes.Add(PhonesChildNode)
                            ClientNode.Nodes.Add(VehiclesChildNode)

                            ' se verifica si tiene vehiculos, y si el vehiculo tiene gps, y si el gps tiene linea
                            If Not TypeOf row("license_plate") Is DBNull AndAlso Not TypeOf row("imei") Is DBNull AndAlso Not TypeOf row("phone_number") Is DBNull Then
                                Dim LicenseChildNodeText As String = String.Format("Matrícula: {0}", row("license_plate"))
                                Dim LicenseChildNode As New ZUControls.HiddenCheckBoxTreeNode(LicenseChildNodeText)
                                LicenseChildNode.ForeColor = Color.Blue

                                Dim VehicleChildNodeText As String = String.Format("Vehículo: {0} {1} {2} {3}",
                                                                            row("brand"), row("model"), row("year"), row("color"))
                                Dim VehicleChildNode As New ZUControls.HiddenCheckBoxTreeNode(VehicleChildNodeText)
                                LicenseChildNode.Nodes.Add(VehicleChildNode)

                                Dim ImeiChildNodeText As String = String.Format("Imei: {0}", row("imei"))
                                Dim ImeiChildNode As New ZUControls.HiddenCheckBoxTreeNode(ImeiChildNodeText)
                                LicenseChildNode.Nodes.Add(ImeiChildNode)

                                Dim SimCardChildNodeText As String = String.Format("SimCard: {0}", row("phone_number"))
                                Dim SimCardChildNode As New ZUControls.HiddenCheckBoxTreeNode(SimCardChildNodeText)
                                LicenseChildNode.Nodes.Add(SimCardChildNode)

                                ClientNode.Nodes(2).Nodes.Add(LicenseChildNode)
                            End If

                            last_client_id = client_id

                            If i = proc.Ds.Tables(0).Rows.Count - 1 Then
                                ClientNode.Text = ClientNode.Text.Replace("[count]", ClientNode.Nodes(2).Nodes.Count)
                                bgwGetClients.ReportProgress(percentage, ClientNode)
                            End If
                        Else ' si es el segundo nodo o mas

                            ' si es el mismo que el anterior significa que se agregara otro vehiculo al mismo cliente
                            If last_client_id = client_id Then
                                If Not TypeOf row("license_plate") Is DBNull AndAlso Not TypeOf row("imei") Is DBNull AndAlso Not TypeOf row("phone_number") Is DBNull Then
                                    Dim LicenseChildNodeText As String = String.Format("Matrícula: {0}", row("license_plate"))
                                    Dim LicenseChildNode As New ZUControls.HiddenCheckBoxTreeNode(LicenseChildNodeText)
                                    LicenseChildNode.ForeColor = Color.Blue

                                    Dim VehicleChildNodeText As String = String.Format("Vehículo: {0} {1} {2} {3}",
                                                                            row("brand"), row("model"), row("year"), row("color"))
                                    Dim VehicleChildNode As New ZUControls.HiddenCheckBoxTreeNode(VehicleChildNodeText)
                                    LicenseChildNode.Nodes.Add(VehicleChildNode)

                                    Dim ImeiChildNodeText As String = String.Format("Imei: {0}", row("imei"))
                                    Dim ImeiChildNode As New ZUControls.HiddenCheckBoxTreeNode(ImeiChildNodeText)
                                    LicenseChildNode.Nodes.Add(ImeiChildNode)

                                    Dim SimCardChildNodeText As String = String.Format("SimCard: {0}", row("phone_number"))
                                    Dim SimCardChildNode As New ZUControls.HiddenCheckBoxTreeNode(SimCardChildNodeText)
                                    LicenseChildNode.Nodes.Add(SimCardChildNode)

                                    ClientNode.Nodes(2).Nodes.Add(LicenseChildNode)
                                End If

                                If i = proc.Ds.Tables(0).Rows.Count - 1 Then
                                    ClientNode.Text = ClientNode.Text.Replace("[count]", ClientNode.Nodes(2).Nodes.Count)
                                    bgwGetClients.ReportProgress(percentage, ClientNode)
                                End If
                            Else
                                ClientNode.Text = ClientNode.Text.Replace("[count]", ClientNode.Nodes(2).Nodes.Count)
                                bgwGetClients.ReportProgress(percentage, ClientNode)

                                ClientNode = New ZUControls.ZUTreeNode

                                ClientNode.Text = String.Format("{0} {1}", row("first_name"), If(row("last_name") Is DBNull.Value, "", row("last_name"))).Trim() & " ([count])"
                                ClientNode.ClientId = client_id
                                ClientNode.ClientStatus = row("status_client")

                                If ClientNode.ClientStatus = 0 Then
                                    ClientNode.ForeColor = Color.Red
                                End If

                                Dim DniChildNodeText As String = String.Format("Cédula: {0}", row("dni"))
                                Dim DniChildNode As New ZUControls.HiddenCheckBoxTreeNode(DniChildNodeText)

                                Dim PhonesChildNodeText As String = String.Format("Teléfonos: {0}", row("phone_number1") & If(row("phone_number2") = 0, "", " / " & row("phone_number2")))
                                Dim PhonesChildNode As New ZUControls.HiddenCheckBoxTreeNode(PhonesChildNodeText)

                                Dim VehiclesChildNodeText As String = "Vehículos"
                                Dim VehiclesChildNode As New ZUControls.HiddenCheckBoxTreeNode(VehiclesChildNodeText)

                                ClientNode.Nodes.Add(DniChildNode)
                                ClientNode.Nodes.Add(PhonesChildNode)
                                ClientNode.Nodes.Add(VehiclesChildNode)

                                ' se verifica si tiene vehiculos, y si el vehiculo tiene gps, y si el gps tiene linea
                                If Not TypeOf row("license_plate") Is DBNull AndAlso Not TypeOf row("imei") Is DBNull AndAlso Not TypeOf row("phone_number") Is DBNull Then
                                    Dim LicenseChildNodeText As String = String.Format("Matrícula: {0}", row("license_plate"))
                                    Dim LicenseChildNode As New ZUControls.HiddenCheckBoxTreeNode(LicenseChildNodeText)
                                    LicenseChildNode.ForeColor = Color.Blue

                                    Dim VehicleChildNodeText As String = String.Format("Vehículo: {0} {1} {2} {3}",
                                                                            row("brand"), row("model"), row("year"), row("color"))
                                    Dim VehicleChildNode As New ZUControls.HiddenCheckBoxTreeNode(VehicleChildNodeText)
                                    LicenseChildNode.Nodes.Add(VehicleChildNode)

                                    Dim ImeiChildNodeText As String = String.Format("Imei: {0}", row("imei"))
                                    Dim ImeiChildNode As New ZUControls.HiddenCheckBoxTreeNode(ImeiChildNodeText)
                                    LicenseChildNode.Nodes.Add(ImeiChildNode)

                                    Dim SimCardChildNodeText As String = String.Format("SimCard: {0}", row("phone_number"))
                                    Dim SimCardChildNode As New ZUControls.HiddenCheckBoxTreeNode(SimCardChildNodeText)
                                    LicenseChildNode.Nodes.Add(SimCardChildNode)

                                    ClientNode.Nodes(2).Nodes.Add(LicenseChildNode)
                                End If

                                last_client_id = client_id

                                If i = proc.Ds.Tables(0).Rows.Count - 1 Then
                                    ClientNode.Text = ClientNode.Text.Replace("[count]", ClientNode.Nodes(2).Nodes.Count)
                                    bgwGetClients.ReportProgress(percentage, ClientNode)
                                End If
                            End If
                        End If
                    Next
                    clientsCount = tviewClients.Nodes.Count
                    vehiclesCount = proc.Ds.Tables(0).Rows.Count
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub bgwGetClients_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetClients.ProgressChanged

        pbarStatusLoadingClients.Value = e.ProgressPercentage
        panelLoadingClients.Visible = True

        Dim node As ZUControls.ZUTreeNode = DirectCast(e.UserState, ZUControls.ZUTreeNode)
        If node.ClientStatus = 0 Then
            tviewInactiveClients.Nodes.Add(node)
        Else
            tviewActiveClients.Nodes.Add(node)
        End If

        Dim newNode As ZUControls.ZUTreeNode = node.Clone
        newNode.ClientId = node.ClientId
        tviewClients.Nodes.Add(newNode)
    End Sub

    Private Sub bgwGetClients_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetClients.RunWorkerCompleted
        panelLoadingClients.Visible = False
        btnReload.Enabled = True
        panelClientFilter.Enabled = True
        lblClientsQuantity.Text = tviewClients.Nodes.Count.ToString("0000")
        lblVehiclesQuantity.Text = vehiclesCount.ToString("0000")

        If cboxExpandClients.Checked Then
            tviewActiveClients.ExpandAll()
            tviewInactiveClients.ExpandAll()
            tviewClients.ExpandAll()
        Else
            tviewActiveClients.CollapseAll()
            tviewInactiveClients.CollapseAll()
            tviewClients.CollapseAll()
        End If

        If tviewActiveClients.Nodes.Count > 0 Then
            tviewActiveClients.Nodes(0).EnsureVisible()
        End If
        If tviewInactiveClients.Nodes.Count > 0 Then
            tviewInactiveClients.Nodes(0).EnsureVisible()
        End If
        If tviewClients.Nodes.Count > 0 Then
            tviewClients.Nodes(0).EnsureVisible()
        End If

        DrawingControl.ResumeDrawing(tviewActiveClients)
        DrawingControl.ResumeDrawing(tviewInactiveClients)
        DrawingControl.ResumeDrawing(tviewClients)

        tpageActiveClients.Text = String.Format("Activos {0}", tviewActiveClients.Nodes.Count.ToString("0000"))
        tpageInactiveClients.Text = String.Format("Inactivos {0}", tviewInactiveClients.Nodes.Count.ToString("0000"))
        tpageAllClients.Text = String.Format("Todos {0}", tviewClients.Nodes.Count.ToString("0000"))

    End Sub

    Public Sub getDealers(ByVal index As Integer)
        Try
            Dim proc As New Procedure

            Dim dt As New DataTable("dealers")
            Dim col1 As New DataColumn("dealer_id")
            Dim col2 As New DataColumn("name")
            dt.Columns.Add(col1)
            dt.Columns.Add(col2)

            If proc.GetData("dealers_getAll") Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    Dim row As DataRow = dt.NewRow
                    row.Item("dealer_id") = 0
                    row.Item("name") = "TODOS"
                    dt.Rows.Add(row)

                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                        row = dt.NewRow
                        row.Item("dealer_id") = row2("dealer_id")
                        row.Item("name") = row2("name")
                        dt.Rows.Add(row)
                    Next
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If

            cboDealers.DataSource = Nothing
            cboDealers.DataSource = dt
            cboDealers.DisplayMember = "name"
            cboDealers.ValueMember = "dealer_id"
            cboDealers.SelectedIndex = index
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub tviewClients_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tviewClients.NodeMouseDoubleClick, tviewActiveClients.NodeMouseDoubleClick, tviewInactiveClients.NodeMouseDoubleClick
        If TypeOf e.Node Is ZUControls.ZUTreeNode AndAlso DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId <> 0 Then
            Dim client_id As Integer = If(e.Node.Parent Is Nothing, DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId, DirectCast(e.Node.Parent, ZUControls.ZUTreeNode).ClientId)

            Dim frm As New frmClients(client_id, Me)
            frm.Show()
            frm.BringToFront()
        End If
    End Sub

    Private Sub tviewClients_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tviewClients.AfterCheck, tviewActiveClients.AfterCheck, tviewInactiveClients.AfterCheck
        Try
            Select Case DirectCast(sender, ZUControls.ZUTreeView).Name
                Case "tviewActiveClients"
                    For Each node As ZUControls.ZUTreeNode In tviewClients.Nodes
                        If DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId = node.ClientId Then
                            If Not node.Checked = e.Node.Checked Then node.Checked = e.Node.Checked
                            Exit For
                        End If
                    Next
                    Exit Select
                Case "tviewInactiveClients"
                    For Each node As ZUControls.ZUTreeNode In tviewClients.Nodes
                        If DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId = node.ClientId Then
                            If Not node.Checked = e.Node.Checked Then node.Checked = e.Node.Checked
                            Exit For
                        End If
                    Next
                    Exit Select
                Case Else
                    For Each node As ZUControls.ZUTreeNode In tviewActiveClients.Nodes
                        If DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId = node.ClientId Then
                            If Not node.Checked = e.Node.Checked Then node.Checked = e.Node.Checked
                            Exit For
                        End If
                    Next
                    For Each node As ZUControls.ZUTreeNode In tviewInactiveClients.Nodes
                        If DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId = node.ClientId Then
                            If Not node.Checked = e.Node.Checked Then node.Checked = e.Node.Checked
                            Exit For
                        End If
                    Next
                    Exit Select
            End Select

            ' EVITAR VOLVER A EJECUTAR EL CODIGO LUEGO DE MARCAR EL CHECKBOX
            If e.Action = TreeViewAction.Unknown Then
                Exit Sub
            End If

            If e.Node.Tag = "0" Then
                If Not e.Node.Parent Is Nothing Then
                    e.Node.Parent.Checked = e.Node.Checked
                    Exit Sub
                End If
            End If

            If e.Node.Checked Then
                tabConsole.SelectedTab = tpageVehicles

                e.Node.BackColor = Color.LightYellow

                bgw = New BackgroundWorker()
                bgw.WorkerReportsProgress = True
                bgw.WorkerSupportsCancellation = True
                AddHandler bgw.DoWork, AddressOf bgw_DoWork
                AddHandler bgw.ProgressChanged, AddressOf bgw_ReportProgress

                dgvConsoleVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                dgvConsoleVehicles.ScrollBars = ScrollBars.None
                DrawingControl.SuspendDrawing(dgvConsoleVehicles)

                bgw.RunWorkerAsync(DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId)
            Else
                If e.Node.Nodes.Count > 0 Then

                End If

                Dim rowsToRemove As New List(Of DataGridViewRow)

                If dgvConsoleVehicles.Rows.Count > 0 Then
                    For i = 0 To dgvConsoleVehicles.Rows.Count - 1
                        Dim row As DataGridViewRow = dgvConsoleVehicles.Rows(i)

                        If dgvConsoleVehicles.Rows(i).Cells("dgvVehicles_client_id").Value = DirectCast(e.Node, ZUControls.ZUTreeNode).ClientId Then
                            rowsToRemove.Add(row)
                        End If
                    Next

                    For x = 0 To rowsToRemove.Count - 1
                        For Each marker As GmapMarkerMain In markersLayer.Markers
                            If rowsToRemove(x).Cells("dgvVehicles_imei").Value = marker.Imei Then
                                marker.IsVisible = False
                                Exit For
                            End If
                        Next

                        If lblLicensePlate.Text <> "---" Then
                            If rowsToRemove(x).Cells("dgvVehicles_license_plate").Value = lblLicensePlate.Text Then
                                lblLicensePlate.Text = "---"
                                dgvGeofences.Rows.Clear()
                                eventsLayer.Polygons.Clear()
                            End If
                        End If
                        dgvConsoleVehicles.Rows.Remove(rowsToRemove(x))
                    Next
                End If
                e.Node.BackColor = Color.Empty
                rowsToRemove.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private dbClick As Boolean = False
    Private Sub tviewClients_MouseDown(sender As Object, e As MouseEventArgs) Handles tviewClients.MouseDown, tviewActiveClients.MouseDown, tviewInactiveClients.MouseDown
        dbClick = e.Button = MouseButtons.Left AndAlso e.Clicks = 2
    End Sub

    Private Sub tviewClients_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles tviewClients.BeforeExpand, tviewActiveClients.BeforeExpand, tviewInactiveClients.BeforeExpand
        If e.Action = TreeViewAction.Expand Then
            e.Cancel = dbClick AndAlso e.Node.Parent Is Nothing
        End If
    End Sub

    Private Sub tviewClients_BeforeCollapse(sender As Object, e As TreeViewCancelEventArgs) Handles tviewClients.BeforeCollapse, tviewActiveClients.BeforeCollapse, tviewInactiveClients.BeforeCollapse
        If e.Action = TreeViewAction.Collapse Then
            e.Cancel = dbClick AndAlso e.Node.Parent Is Nothing
        End If
    End Sub

    Private Sub tviewClients_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles tviewClients.BeforeCheck, tviewActiveClients.BeforeCheck, tviewInactiveClients.BeforeCheck
        If e.Node.Tag = "0" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tviewClients_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles tviewClients.DrawNode, tviewActiveClients.DrawNode, tviewInactiveClients.DrawNode
        If IsThirdLevel(e.Node) Then
            Dim backColor As Color, foreColor As Color

            If (e.State And TreeNodeStates.Selected) = TreeNodeStates.Selected Then
                backColor = SystemColors.Highlight
                foreColor = SystemColors.HighlightText
            ElseIf (e.State And TreeNodeStates.Hot) = TreeNodeStates.Hot Then
                backColor = SystemColors.HotTrack
                foreColor = SystemColors.HighlightText
            Else
                backColor = e.Node.BackColor
                foreColor = e.Node.ForeColor
            End If

            Dim newBounds As Rectangle = e.Node.Bounds
            newBounds.X = -10

            Using brush As New SolidBrush(backColor)
                e.Graphics.FillRectangle(brush, newBounds)
            End Using

            TextRenderer.DrawText(e.Graphics, e.Node.Text, DirectCast(sender, ZUControls.ZUTreeView).Font, e.Node.Bounds, foreColor, backColor)

            If (e.State And TreeNodeStates.Focused) = TreeNodeStates.Focused Then
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Node.Bounds, foreColor, backColor)
            End If

            e.DrawDefault = False
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Shared Function IsThirdLevel(node As TreeNode) As Boolean
        Return node.Parent IsNot Nothing AndAlso node.Parent.Parent IsNot Nothing
    End Function

    Private Sub cboxExpandClients_CheckedChanged(sender As Object, e As EventArgs) Handles cboxExpandClients.CheckedChanged
        DrawingControl.SuspendDrawing(tviewClients)
        DrawingControl.SuspendDrawing(tviewActiveClients)
        DrawingControl.SuspendDrawing(tviewInactiveClients)

        If cboxExpandClients.Checked Then
            tviewClients.ExpandAll()
            tviewActiveClients.ExpandAll()
            tviewInactiveClients.ExpandAll()
        Else
            tviewClients.CollapseAll()
            tviewActiveClients.CollapseAll()
            tviewInactiveClients.CollapseAll()
        End If

        If tviewClients.Nodes.Count > 0 Then
            tviewClients.Nodes(0).EnsureVisible()
        End If
        If tviewActiveClients.Nodes.Count > 0 Then
            tviewActiveClients.Nodes(0).EnsureVisible()
        End If
        If tviewInactiveClients.Nodes.Count > 0 Then
            tviewInactiveClients.Nodes(0).EnsureVisible()
        End If

        DrawingControl.ResumeDrawing(tviewClients)
        DrawingControl.ResumeDrawing(tviewActiveClients)
        DrawingControl.ResumeDrawing(tviewInactiveClients)
    End Sub

    Private Sub bgw_DoWork(sender As Object, e As DoWorkEventArgs)
        Try
            Dim proc As New Procedure

            If proc.GetData("vehicles_toConsole", e.Argument.ToString) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim rowVehicle = proc.Ds.Tables(0).Rows(i)
                        Dim date_time As String = ""
                        Dim speed As String = ""

                        For Each marker As GmapMarkerMain In markersLayer.Markers
                            If marker.Imei = If(rowVehicle("imei") Is DBNull.Value, "", rowVehicle("imei")) Then
                                date_time = marker.DateTime.ToString("dd/MM/yyyy hh:mm:ss tt")
                                speed = marker.Speed.ToString() & " Km/H"
                            End If
                        Next

                        dgvConsoleVehicles.Rows.Add(
                            False,
                            Nothing,
                            If(rowVehicle("device_model") Is DBNull.Value, "", rowVehicle("device_model")),
                            If(rowVehicle("imei") Is DBNull.Value, "", rowVehicle("imei")),
                            If(rowVehicle("phone_number") Is DBNull.Value, 0, rowVehicle("phone_number")),
                            (If(rowVehicle("first_name") Is DBNull.Value, "", rowVehicle("first_name")) & " " & If(rowVehicle("last_name") Is DBNull.Value, "", rowVehicle("last_name"))).ToString().Trim,
                             If(rowVehicle("license_plate") Is DBNull.Value, "", rowVehicle("license_plate")),
                             If(rowVehicle("brand") Is DBNull.Value, "", rowVehicle("brand")),
                             If(rowVehicle("model") Is DBNull.Value, "", rowVehicle("model")),
                            If(rowVehicle("type") Is DBNull.Value, "", rowVehicle("type")),
                             If(rowVehicle("year") Is DBNull.Value, 0, rowVehicle("year")),
                             If(rowVehicle("color") Is DBNull.Value, "", rowVehicle("color")),
                            date_time,
                            speed,
                            If(rowVehicle("expiration_date") Is DBNull.Value, "", Date.Parse(rowVehicle("expiration_date")).ToString("yyyy-MM-dd")),
                            If(rowVehicle("client_id") Is DBNull.Value, "", rowVehicle("client_id")),
                            If(rowVehicle("vehicle_id") Is DBNull.Value, "", rowVehicle("vehicle_id")),
                            If(rowVehicle("device_id") Is DBNull.Value, "", rowVehicle("device_id")),
                            If(rowVehicle("device_model_id") Is DBNull.Value, "", rowVehicle("device_model_id")),
                            If(rowVehicle("sms_stop") Is DBNull.Value, "", rowVehicle("sms_stop")),
                            If(rowVehicle("sms_resume") Is DBNull.Value, "", rowVehicle("sms_resume")),
                            If(rowVehicle("gprs_stop") Is DBNull.Value, "", rowVehicle("gprs_stop")),
                            If(rowVehicle("gprs_resume") Is DBNull.Value, "", rowVehicle("gprs_resume")),
                            If(rowVehicle("phone_pass") Is DBNull.Value, "", rowVehicle("phone_pass"))
                        )
                        bgw.ReportProgress(1, e.Argument)
                    Next
                Else
                    bgw.ReportProgress(0, e.Argument)
                End If
            Else
                bgw.ReportProgress(0, e.Argument)
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub bgw_ReportProgress(sender As Object, e As ProgressChangedEventArgs)
        DrawingControl.ResumeDrawing(dgvConsoleVehicles)
        dgvConsoleVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvConsoleVehicles.ScrollBars = ScrollBars.Both

        For Each node As TreeNode In tviewClients.Nodes
            If node.Tag = e.UserState Then
                If e.ProgressPercentage = 1 Then
                    node.BackColor = Color.LightGreen
                Else
                    node.BackColor = Color.Empty
                    node.Checked = False
                End If

                Exit For
            End If
        Next
    End Sub

    Private Sub dgvConsoleVehicles_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvConsoleVehicles.RowsAdded
        tpageVehicles.Text = "VEHÍCULOS (" & dgvConsoleVehicles.Rows.Count.ToString("000") & ")"
    End Sub

    Private Sub dgvConsoleVehicles_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvConsoleVehicles.RowsRemoved
        tpageVehicles.Text = "VEHÍCULOS (" & dgvConsoleVehicles.Rows.Count.ToString("000") & ")"
    End Sub

    Private Sub bgwGetCurrentLocations_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetCurrentLocations.DoWork
        Try
            ' no hacer nada hasta que la carga de clientes este desocupada
            Do
            Loop While bgwGetClients.IsBusy

            Dim proc As New Procedure

            markersMovingLayer.Markers.Clear()

            If proc.GetData("current_locations_getAll") Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                        ' se obtienen los datos de la BD en variables y se formatea segun se requiera
                        Dim client_name As String = (If(row("first_name") Is DBNull.Value, "", row("first_name")) & " " & If(row("last_name") Is DBNull.Value, "", row("last_name"))).ToString().Trim
                        Dim license_plate As String = If(row("license_plate") Is DBNull.Value, "", row("license_plate"))
                        Dim imei As String = If(row("imei") Is DBNull.Value, "", row("imei"))
                        Dim latitude As Double = If(row("latitude") Is DBNull.Value, 0, row("latitude"))
                        Dim longitude As Double = If(row("longitude") Is DBNull.Value, 0, row("longitude"))
                        Dim date_time As Date = If(row("date_time") Is DBNull.Value, Now, row("date_time"))
                        Dim speed As Integer = If(row("speed") Is DBNull.Value, 0, row("speed"))
                        Dim orientation As Integer = If(row("orientation") Is DBNull.Value, 0, row("orientation"))
                        Dim fix As String = If(row("fix") Is DBNull.Value, "", row("fix"))

                        ' variable que indica si se debe agregar un marcador o actualizar
                        Dim existDevice As Boolean = False

                        ' si existen marcadores se verifica que no existe el actual a procesar
                        If markersLayer.Markers.Count > 0 Then
                            For Each marker As GmapMarkerMain In markersLayer.Markers
                                If marker.Imei = imei Then
                                    marker.Position = New PointLatLng(latitude, longitude)
                                    marker.Client = client_name
                                    marker.LicensePlate = license_plate
                                    marker.Orientation = orientation
                                    marker.Fix = fix
                                    marker.Speed = speed
                                    marker.DateTime = date_time

                                    If dgvConsoleVehicles.CurrentRow IsNot Nothing Then
                                        If dgvConsoleVehicles.CurrentRow.Cells("dgvVehicles_imei").Value.ToString() = imei AndAlso menuOptionAutoCenter.Checked AndAlso marker.IsVisible Then
                                            mapMain.Position = marker.Position
                                        End If
                                    End If

                                    ' se cambia la variable de que existe el gps a true
                                    existDevice = True
                                    Exit For
                                End If
                            Next
                        End If

                        ' si no existe se agrega uno nuevo
                        If Not existDevice Then
                            ' se instancia un nuevo marcador
                            Dim marker As New GmapMarkerMain(New PointLatLng(latitude, longitude))

                            ' se configuran las propiedades del marcador
                            marker.Imei = imei
                            marker.Client = client_name
                            marker.LicensePlate = license_plate
                            marker.Orientation = orientation
                            marker.DateTime = date_time
                            marker.Fix = fix
                            marker.Speed = speed
                            marker.IsVisible = False
                            ' se agrega el marcador a la capa
                            markersLayer.Markers.Add(marker)
                        End If

                        If speed > 0 Then
                            If client_name <> "" Then
                                Dim markerMoving As New GmapMarkerMain(New PointLatLng(latitude, longitude))
                                ' se configuran las propiedades del marcador
                                markerMoving.Imei = imei
                                markerMoving.Client = client_name
                                markerMoving.LicensePlate = license_plate
                                markerMoving.Orientation = orientation
                                markerMoving.DateTime = date_time
                                markerMoving.Fix = fix
                                markerMoving.Speed = speed
                                markerMoving.IsVisible = True
                                ' se agrega el marcador a la capa
                                markersMovingLayer.Markers.Add(markerMoving)
                            End If
                        End If
                    Next

                    ' se verifica que la capa de marcadores se agregue en el mapa
                    If Not mapMain.Overlays.Contains(markersLayer) Then
                        mapMain.Overlays.Add(markersLayer)
                    End If

                    If markersMovingLayer.Markers.Count > 0 Then
                        For i = 0 To markersMovingLayer.Markers.Count - 1
                            markersMovingLayer.Markers(i).IsVisible = True
                        Next
                    End If

                    If Not mapMain.Overlays.Contains(markersMovingLayer) Then
                        mapMain.Overlays.Add(markersMovingLayer)
                    End If

                    markersLayer.IsVisibile = True
                    markersMovingLayer.IsVisibile = VehículosEnMovimientoToolStripMenuItem.Checked
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub bgwGetCurrentLocations_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetCurrentLocations.RunWorkerCompleted
        Try
            ' actualiza la columna de velocidad y ultimo reporte de la ventana de vehiculos de la consola
            If dgvConsoleVehicles.Rows.Count > 0 Then
                For Each marker As GmapMarkerMain In markersLayer.Markers
                    For Each row As DataGridViewRow In dgvConsoleVehicles.Rows
                        If row.Cells("dgvVehicles_imei").Value.ToString().Equals(marker.Imei) Then
                            row.Cells("dgvVehicles_last_report").Value = marker.DateTime.ToString("dd/MM/yyyy hh:mm:ss tt")
                            row.Cells("dgvVehicles_speed").Value = marker.Speed & " Km/H"
                            marker.IsVisible = row.Cells("dgvVehicles_onMap").Value
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub dgvConsoleVehicles_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvConsoleVehicles.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                ' se captura el boton izquierdo del mouse
                If e.Button = MouseButtons.Left Then

                    ' se valida que se hizo click en la columna para ver el vehiculo en el mapa
                    If e.ColumnIndex = 0 Then
                        If dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_expiration_date").Value < Now.AddMonths(-1) Then
                            MsgBox("Este vehículo se encuentra suspendido", MsgBoxStyle.Critical, "Mensaje del Sistema")
                            dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_onMap").Value = False
                            Exit Sub
                        End If

                        ' se muestra el marcador en el mapa y se centra
                        Dim showMarker As Boolean = Not dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_onMap").Value

                        dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_onMap").Value = Not dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_onMap").Value

                        For Each marker As GmapMarkerMain In markersLayer.Markers
                            If marker.Imei = dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_imei").Value.ToString() Then
                                marker.IsVisible = showMarker
                                mapMain.Position = If(showMarker, marker.Position, mapMain.Position)
                                Exit For
                            End If
                        Next

                    ElseIf e.ColumnIndex = 1 Then
                        If dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_expiration_date").Value < Now.AddMonths(-1) Then
                            MsgBox("Este vehículo se encuentra suspendido", MsgBoxStyle.Critical, "Mensaje del Sistema")
                            dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_onMap").Value = False
                            Exit Sub
                        End If

                        Dim frm As New frmDeviceConfig(Nothing, dgvConsoleVehicles.Rows(e.RowIndex), serialModemSms, Me)
                        frm.Show()
                    Else
                        ' si se hizo click en cualquier otra columna se verifica si el vehiculo esta en el mapa
                        ' para centrarlo

                        If dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_onMap").Value Then
                            For Each marker As GmapMarkerMain In markersLayer.Markers
                                If marker.Imei = dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_imei").Value.ToString() AndAlso marker.IsVisible Then
                                    mapMain.Position = marker.Position
                                    Exit For
                                End If
                            Next
                        End If
                    End If

                    If dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_license_plate").Value <> lblLicensePlate.Text Then
                        lblLicensePlate.Text = dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_license_plate").Value

                        Dim proc As New Procedure

                        dgvGeofences.Rows.Clear()
                        eventsLayer.Polygons.Clear()

                        If proc.GetData("geofences_vehicles_getByVehicle", dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_vehicle_id").Value) Then
                            If proc.Ds.Tables(0).Rows.Count > 0 Then
                                For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                                    Dim row As DataRow = proc.Ds.Tables(0).Rows(i)
                                    dgvGeofences.Rows.Add()
                                    dgvGeofences.Rows(i).Cells("dgvGeofences_on_map").Value = False
                                    dgvGeofences.Rows(i).Cells("dgvGeofences_name").Value = row("name")
                                    dgvGeofences.Rows(i).Cells("dgvGeofences_imei").Value = dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_imei").Value
                                    dgvGeofences.Rows(i).Cells("dgvGeofences_geofence_id").Value = row("geofence_id")
                                    dgvGeofences.Rows(i).Cells("dgvGeofences_vehicle_id").Value = dgvConsoleVehicles.Rows(e.RowIndex).Cells("dgvVehicles_vehicle_id").Value
                                    dgvGeofences.Rows(i).Cells("dgvGeofences_points").Value = row("points")
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Public Function sTiempo(dInicio As Date, dFin As Date) As String
        Dim functionReturnValue As String = Nothing
        functionReturnValue = CInt((dFin - dInicio).TotalSeconds / 86400 Mod 365) & " días, "
        functionReturnValue = (functionReturnValue & CInt((dFin - dInicio).TotalSeconds / 3600 Mod 24)) & " horas, "
        functionReturnValue = (functionReturnValue & CInt((dFin - dInicio).TotalSeconds / 60 Mod 60)) & " minutos, "
        functionReturnValue = (functionReturnValue & CInt((dFin - dInicio).TotalSeconds Mod 60)) & " segundos."
        Return functionReturnValue
    End Function

    Private Sub bgwNoReportingVehicles_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwNoReportingVehicles.DoWork
        Try
            Dim proc As New Procedure

            If proc.GetData("current_locations_getNoReporting") Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                        If If(row("device_id") Is DBNull.Value, 0, row("device_id")) > 0 AndAlso
                            If(row("vehicle_id") Is DBNull.Value, 0, row("vehicle_id")) > 0 AndAlso
                             If(row("client_id") Is DBNull.Value, 0, row("client_id")) > 0 Then

                            dgvNoReportingVehicles.Rows.Add(
                                                        (If(row("first_name") Is DBNull.Value, "", row("first_name")) & " " & If(row("last_name") Is DBNull.Value, "", row("last_name"))).ToString().Trim,
                                                        If(row("imei") Is DBNull.Value, "", row("imei")),
                                                        If(row("license_plate") Is DBNull.Value, "", row("license_plate")),
                                                        DirectCast(If(row("date_time") Is DBNull.Value, Now, row("date_time")), Date).ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                        sTiempo(If(row("date_time") Is DBNull.Value, Now, row("date_time")), Now),
                                                        If(row("validation") Is DBNull.Value, "", DirectCast(row("date_time"), Date).ToString("dd/MM/yyyy hh:mm:ss tt")),
                                                        If(row("client_id") Is DBNull.Value, 0, row("client_id")))
                        End If
                    Next
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub bgwNoReportingVehicles_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwNoReportingVehicles.RunWorkerCompleted
        dgvNoReportingVehicles.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvNoReportingVehicles)
        tpageNoReportingVehicles.Text = "VEHÍCULOS SIN REPORTAR (" & dgvNoReportingVehicles.Rows.Count.ToString("000") & ")"
    End Sub

    Private Sub lblCountdown_MouseClick(sender As Object, e As MouseEventArgs) Handles lblCountdown.MouseClick
        If lblCountdown.ForeColor = Color.Red Then
            If e.Button = MouseButtons.Right Then
                lblCountdown.Text = "30"
            End If
            lblCountdown.ForeColor = Color.White
            timerCountdown.Start()
        Else
            If e.Button = MouseButtons.Right Then
                lblCountdown.Text = "30"
            End If
            lblCountdown.ForeColor = Color.Red
            timerCountdown.Stop()
        End If
    End Sub

    Private Sub bgwGetEvents_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetEvents.DoWork
        Try
            Dim proc As New Procedure

            Dim event_name, first_name, last_name, license_plate, imei, geofence_name, validation,
                geofence_points, textToVoice As String

            license_plate = ""
            validation = ""

            Dim client_id, vehicle_id, device_id, geofence_id, report_type_id, current_speed, speed_limit,
                orientation, battery_alert, geofence_alert, speed_alert, ignition_alert, motion_alert As Integer
            Dim latitude, longitude As Double
            Dim date_time As Date

            Dim isVoiceEnabled As Boolean = False

            If dgvEvents.Rows.Count = 0 Then
                isVoiceEnabled = False

                If Not proc.GetData("events_getToConsole", 0, Now) Then
                    MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End If
            Else
                isVoiceEnabled = My.Settings.currentVoice <> ""

                Dim last_event_date As Date = dgvEvents.Rows(0).Cells("dgvEvents_date_time").Value
                Dim seconds As Integer = Now.Subtract(last_event_date).TotalSeconds

                If seconds > 172800 Then

                    If Not proc.GetData("events_getToConsole", 0, Now) Then
                        MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
                        Exit Sub
                    End If
                Else

                    If Not proc.GetData("events_getToConsole", 1, last_event_date) Then
                        MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
                        Exit Sub
                    End If
                End If
            End If

            If proc.Ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                    Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                    event_name = If(row("event_name") Is DBNull.Value, "", row("event_name"))
                    date_time = If(row("date_time") Is DBNull.Value, Now, row("date_time"))
                    latitude = If(row("latitude") Is DBNull.Value, 0, row("latitude"))
                    longitude = If(row("longitude") Is DBNull.Value, 0, row("longitude"))
                    current_speed = If(row("current_speed") Is DBNull.Value, 0, row("current_speed"))
                    speed_limit = If(row("speed_limit") Is DBNull.Value, 0, row("speed_limit"))
                    orientation = If(row("orientation") Is DBNull.Value, 0, row("orientation"))
                    validation = If(row("validation") Is DBNull.Value, "", DirectCast(row("validation"), Date).ToString("dd/MM/yyyy hh:mm:ss tt"))
                    report_type_id = If(row("report_type_id") Is DBNull.Value, 0, row("report_type_id"))

                    imei = If(row("imei") Is DBNull.Value, "", row("imei"))
                    device_id = If(row("device_id") Is DBNull.Value, 0, row("device_id"))

                    vehicle_id = If(row("vehicle_id") Is DBNull.Value, 0, row("vehicle_id"))
                    license_plate = If(row("license_plate") Is DBNull.Value, "", row("license_plate"))

                    battery_alert = If(row("battery_alert") Is DBNull.Value, 0, row("battery_alert"))
                    geofence_alert = If(row("geofence_alert") Is DBNull.Value, 0, row("geofence_alert"))
                    speed_alert = If(row("speed_alert") Is DBNull.Value, 0, row("speed_alert"))
                    ignition_alert = If(row("ignition_alert") Is DBNull.Value, 0, row("ignition_alert"))
                    motion_alert = If(row("motion_alert") Is DBNull.Value, 0, row("motion_alert"))

                    geofence_id = If(row("geofence_id") Is DBNull.Value, 0, row("geofence_id"))
                    geofence_name = If(row("name") Is DBNull.Value, "", row("name"))
                    geofence_points = If(row("geofence_points") Is DBNull.Value, "", row("geofence_points"))

                    client_id = If(row("client_id") Is DBNull.Value, 0, row("client_id"))
                    first_name = If(row("first_name") Is DBNull.Value, "", row("first_name"))
                    last_name = If(row("last_name") Is DBNull.Value, "", row("last_name"))

                    textToVoice = ""

                    Select Case event_name
                        Case "entrada geocerca"
                            If geofence_alert = 1 Then
                                event_name = "ENTRADA A GEOCERCA > " & geofence_name

                                If last_name.Length > 0 Then
                                    Dim nombre As String() = first_name.Split(" ")
                                    Dim apellido As String() = last_name.Split(" ")

                                    textToVoice = nombre(0) + " " + apellido(0) + ", Entrada a Geocerca"
                                Else
                                    textToVoice = first_name + ", Entrada a Geocerca"
                                End If
                            Else
                                Continue For
                            End If

                            Exit Select
                        Case "salida geocerca"
                            If geofence_alert = 1 Then
                                event_name = "SALIDA DE GEOCERCA > " & geofence_name

                                If last_name.Length > 0 Then
                                    Dim nombre As String() = first_name.Split(" ")
                                    Dim apellido As String() = last_name.Split(" ")

                                    textToVoice = nombre(0) + " " + apellido(0) + ", Salida de Geocerca"
                                Else
                                    textToVoice = first_name + ", Salida de Geocerca"
                                End If
                            Else
                                Continue For
                            End If

                            Exit Select
                        Case "ac alarm"
                            If battery_alert = 1 Then
                                event_name = "DESCONEXIÓN DE BATERÍA"

                                If last_name.Length > 0 Then
                                    Dim nombre As String() = first_name.Split(" ")
                                    Dim apellido As String() = last_name.Split(" ")

                                    textToVoice = nombre(0) + " " + apellido(0) + ", Alerta de Batería"
                                Else
                                    textToVoice = first_name + ", Alerta de Batería"
                                End If
                            Else
                                Continue For
                            End If

                            Exit Select
                        Case "low battery"
                            If battery_alert = 1 Then
                                event_name = "BATERÍA BAJA"

                                If last_name.Length > 0 Then
                                    Dim nombre As String() = first_name.Split(" ")
                                    Dim apellido As String() = last_name.Split(" ")

                                    textToVoice = nombre(0) + " " + apellido(0) + ", Alerta de Batería"
                                Else
                                    textToVoice = first_name + ", Alerta de Batería"
                                End If
                            Else
                                Continue For
                            End If

                            Exit Select
                        Case "speed"
                            If speed_alert = 1 Then
                                event_name = "EXCESO DE VELOCIDAD DE " & speed_limit & "Km/H >> " & current_speed & "Km/H"

                                If last_name.Length > 0 Then
                                    Dim nombre As String() = first_name.Split(" ")
                                    Dim apellido As String() = last_name.Split(" ")

                                    textToVoice = nombre(0) + " " + apellido(0) + ", Exceso de Velocidad"
                                Else
                                    textToVoice = first_name + ", Exceso de Velocidad"
                                End If
                            Else
                                Continue For
                            End If

                            Exit Select
                        Case "velocidad"
                            If speed_alert = 1 Then
                                event_name = "EXCESO DE VELOCIDAD DE " & speed_limit & "Km/H >> " & current_speed & "Km/H"

                                If last_name.Length > 0 Then
                                    Dim nombre As String() = first_name.Split(" ")
                                    Dim apellido As String() = last_name.Split(" ")

                                    textToVoice = nombre(0) + " " + apellido(0) + ", Exceso de Velocidad"
                                Else
                                    textToVoice = first_name + ", Exceso de Velocidad"
                                End If
                            Else
                                Continue For
                            End If

                            Exit Select
                        Case Else
                            Continue For
                            Exit Select
                    End Select

                    If client_id > 0 AndAlso vehicle_id > 0 AndAlso device_id > 0 Then
                        If isVoiceEnabled Then
                            If validation = "" OrElse Date.Parse(validation) < Now Then
                                textsToVoice.Add(textToVoice)
                            End If
                        End If

                        dgvEvents.Rows.Insert(0,
                                                False,
                                                (first_name & " " & last_name).ToString().Trim,
                                                imei,
                                                license_plate,
                                                date_time.ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                event_name,
                                                validation,
                                                client_id,
                                                vehicle_id,
                                                report_type_id,
                                                geofence_id,
                                                geofence_points,
                                                latitude,
                                                longitude,
                                                current_speed,
                                                orientation)


                    End If
                Next
                dtEvents.AcceptChanges()
                For x = 0 To dgvEvents.Rows.Count - 1
                    With dgvEvents.Rows(x)
                        If Not TypeOf .Cells("dgvEvents_report_type_id").Value Is DBNull Then
                            If .Cells("dgvEvents_license_plate").Value = license_plate And .Cells("dgvEvents_report_type_id").Value = report_type_id Then
                                .Cells("dgvEvents_validation").Value = validation
                            End If
                        End If
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

        Dim thread As New Threading.Thread(AddressOf speak)
        thread.Start()

    End Sub

    Private Sub speak()
        Try
            Dim voice As LTTS7Lib.LTTS7 = New LTTS7Lib.LTTS7
            voice.Frequency = "48000"
            voice.Language = "SpanishMx"
            voice.Pitch = 30
            voice.Speed = 50
            voice.Voice = My.Settings.currentVoice

            While textsToVoice.Count > 0
                voice.Read(textsToVoice(0))
                textsToVoice.RemoveAt(0)
            End While

        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgwGetEvents_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetEvents.RunWorkerCompleted
        dgvEvents.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvEvents)
        tpageEvents.Text = "EVENTOS (" & dgvEvents.Rows.Count.ToString("000") & ")"
    End Sub

    Private Sub menuOptionAutoCenter_CheckedChanged(sender As Object, e As EventArgs) Handles menuOptionAutoCenter.CheckedChanged
        menuOptionAutoCenter.BackColor = If(menuOptionAutoCenter.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub dgvEvents_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEvents.CellMouseClick
        If e.Button = MouseButtons.Left AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_onMap").Value = False Then
                    For Each row As DataGridViewRow In dgvEvents.Rows
                        row.Cells("dgvEvents_onMap").Value = False
                    Next

                    eventsLayer.Markers.Clear()
                    eventsLayer.Polygons.Clear()

                    Dim event_name = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_name").Value
                    Dim latitude = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_latitude").Value
                    Dim longitude = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_longitude").Value
                    Dim speed = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_speed").Value
                    Dim date_time = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_date_time").Value
                    Dim orientation = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_orientation").Value
                    Dim points = dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_geofence_points").Value

                    Dim marker As New GmapMarkerEvent(New PointLatLng(latitude, longitude))
                    marker.Selected = True
                    marker.DateTime = date_time
                    marker.Orientation = orientation
                    marker.Speed = speed
                    marker.IsVisible = True
                    eventsLayer.Markers.Add(marker)

                    If points <> "" Then
                        Dim _points = New JavaScriptSerializer().Deserialize(Of List(Of GeofencePoint))(points)
                        Dim gpoints As New List(Of PointLatLng)

                        For i = 0 To _points.Count - 1
                            gpoints.Add(New PointLatLng(_points(i).Latitude, _points(i).Longitude))
                        Next

                        Dim geofence As New GMapPolygon(gpoints, "geofence")
                        geofence.Stroke = New Pen(Brushes.Blue, 2)
                        geofence.Fill = If(event_name.ToString().ToLower.Contains("entrada"), New SolidBrush(Color.FromArgb(20, Color.Green)), New SolidBrush(Color.FromArgb(20, Color.Red)))
                        geofence.IsVisible = True
                        eventsLayer.Polygons.Add(geofence)
                    End If

                    mapMain.Position = New PointLatLng(latitude, longitude)

                    dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_onMap").Value = True

                    eventsLayer.IsVisibile = CapaDeEventosToolStripMenuItem.Checked

                    If Not mapMain.Overlays.Contains(eventsLayer) Then
                        mapMain.Overlays.Add(eventsLayer)
                    End If
                Else
                    For Each row As DataGridViewRow In dgvEvents.Rows
                        row.Cells("dgvEvents_onMap").Value = False
                    Next

                    eventsLayer.Markers.Clear()
                    eventsLayer.Polygons.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub bgwGeofences_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGeofences.DoWork
        Try
            If My.Settings.isMainServer Then
                Dim proc As New Procedure

                If proc.GetData("geofences_vehicles_getForEvents") Then
                    If proc.Ds.Tables(0).Rows.Count > 0 Then
                        For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                            Dim row = proc.Ds.Tables(0).Rows(i)

                            If row("key") = 0 Then
                                Dim geofence_vehicle_id = If(row("geofence_vehicle_id") Is DBNull.Value, 0, row("geofence_vehicle_id"))
                                Dim geofence_id = If(row("geofence_id") Is DBNull.Value, 0, row("geofence_id"))
                                Dim imei = If(row("imei") Is DBNull.Value, "", row("imei"))
                                Dim date_time = If(row("date_time") Is DBNull.Value, Now, row("date_time"))
                                Dim latitude = If(row("latitude") Is DBNull.Value, 0, row("latitude"))
                                Dim longitude = If(row("longitude") Is DBNull.Value, 0, row("longitude"))
                                Dim speed = If(row("speed") Is DBNull.Value, 0, row("speed"))
                                Dim orientation = If(row("orientation") Is DBNull.Value, 0, row("orientation"))
                                Dim last_status = If(row("last_status") Is DBNull.Value, 0, row("last_status"))
                                Dim points = If(row("points") Is DBNull.Value, "", row("points"))

                                Dim gPoints As List(Of GeofencePoint) = New JavaScriptSerializer().Deserialize(Of List(Of GeofencePoint))(points)
                                Dim _gPoints As New List(Of PointLatLng)

                                If gPoints.Count > 0 Then
                                    For x = 0 To gPoints.Count - 1
                                        _gPoints.Add(New PointLatLng(gPoints(x).Latitude, gPoints(x).Longitude))
                                    Next
                                End If

                                Dim geofence As New GMapPolygon(_gPoints, "geofence")
                                Dim curPosition As New PointLatLng(latitude, longitude)

                                If last_status = 0 Then
                                    If geofence.IsInside(curPosition) Then
                                        proc.GetData("geofences_vehicles_update", 1, date_time, geofence_vehicle_id)
                                    Else
                                        proc.GetData("geofences_vehicles_update", 2, date_time, geofence_vehicle_id)
                                    End If
                                Else
                                    If geofence.IsInside(curPosition) Then
                                        If last_status <> 1 Then
                                            If proc.GetData("events_insert",
                                                            date_time,
                                                            imei,
                                                            latitude,
                                                            longitude,
                                                            "entrada geocerca",
                                                            speed,
                                                            orientation,
                                                            0,
                                                            geofence_id,
                                                            points) Then

                                                proc.GetData("geofences_vehicles_update", 1, date_time, geofence_vehicle_id)
                                            End If
                                        End If
                                    Else
                                        If last_status <> 2 Then
                                            If proc.GetData("events_insert",
                                                            date_time,
                                                            imei,
                                                            latitude,
                                                            longitude,
                                                            "salida geocerca",
                                                            speed,
                                                            orientation,
                                                            0,
                                                            geofence_id,
                                                            points) Then

                                                proc.GetData("geofences_vehicles_update", 2, date_time, geofence_vehicle_id)
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                If serialModemSms.IsOpen Then
                                    serialModemSms.Write("AT+CMGS=" & Chr(34) & "04122386203" & Chr(34) & Chr(13))
                                    serialModemSms.Write("IS INSIDE GEOFENCE" & Chr(26))
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub dgvEvents_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEvents.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.Button = MouseButtons.Left Then
            Dim frm As New frmClients(dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_client_id").Value, Me, dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_report_type_id").Value, dgvEvents.Rows(e.RowIndex).Cells("dgvEvents_vehicle_id").Value)
            frm.Show()
            frm.BringToFront()
        End If
    End Sub

    Private Sub dgvNoReportingVehicles_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvNoReportingVehicles.CellMouseDoubleClick
        Dim frm As New frmClients(dgvNoReportingVehicles.Rows(e.RowIndex).Cells("dgvNoReportingVehicles_client_id").Value, Me)
        frm.Show()
        frm.BringToFront()
    End Sub

    Private Sub cboDealers_Enter(sender As Object, e As EventArgs) Handles cboDealers.Enter
        getDealers(-1)
    End Sub

    Private Sub bgwModemSms_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwModemSms.DoWork
        Try
            If cboxModem.Checked Then
                If serialModemSms.IsOpen Then
                    serialModemSms.Write("AT" & Chr(13))
                    Threading.Thread.Sleep(1000)
                    Application.DoEvents()

                    If serialModemSms.ReadExisting().IndexOf("OK") Then
                        cboxModem.Text = "Módem Conectado"
                        cboxModem.ForeColor = Color.Green
                    Else
                        cboxModem.Text = "Módem Desconectado"
                        cboxModem.ForeColor = Color.Red
                    End If

                    serialModemSms.DiscardInBuffer()

                    serialModemSms.Write("AT+CSQ" & Chr(13))
                    Threading.Thread.Sleep(1000)
                    serialModemSms.Write("AT+CNMI=1,2,0,1,0" & Chr(13))
                    Threading.Thread.Sleep(1000)
                    Application.DoEvents()

                    serialModemSms.DiscardInBuffer()
                Else
                    connectModem()
                    If serialModemSms.IsOpen Then
                        serialModemSms.Write("ATZ" & Chr(13))
                        Threading.Thread.Sleep(1000)
                        serialModemSms.Write("AT+CMGF=1" & Chr(13))
                        Threading.Thread.Sleep(1000)
                        serialModemSms.Write("AT+CSMP=49,167,0,0" & Chr(13))
                        Threading.Thread.Sleep(1000)
                        serialModemSms.Write("AT+CNMI=1,2,0,1,0" & Chr(13))
                        Threading.Thread.Sleep(1000)
                        Application.DoEvents()

                        If serialModemSms.ReadExisting().IndexOf("OK") Then
                            cboxModem.Text = "Módem Conectado"
                            cboxModem.ForeColor = Color.Green
                        Else
                            cboxModem.Text = "Módem Desconectado"
                            cboxModem.ForeColor = Color.Red
                        End If

                        serialModemSms.DiscardInBuffer()

                        serialModemSms.Write("AT+CSQ" & Chr(13))
                        Threading.Thread.Sleep(1000)
                        Application.DoEvents()

                        serialModemSms.DiscardInBuffer()
                    End If
                End If
            Else
                If serialModemSms.IsOpen Then
                    serialModemSms.Close()

                    cboxModem.Checked = False
                    cboxModem.Text = "Módem Desconectado"
                    cboxModem.ForeColor = Color.Red

                    pbarModem.Minimum = 0
                    pbarModem.Value = 0
                    pbarModem.Minimum = 32
                End If
            End If
        Catch ex As Exception
            cboxModem.Checked = False
            cboxModem.Text = "Módem Desconectado"
            cboxModem.ForeColor = Color.Red

            pbarModem.Minimum = 0
            pbarModem.Value = 0
            pbarModem.Minimum = 32
        End Try
    End Sub

    Private Sub connectModem()
        With serialModemSms
            If .IsOpen Then
                .Close()
            End If

            .PortName = My.Settings.portName
            .BaudRate = My.Settings.baudRate
            .DataBits = My.Settings.dataBits
            Select Case My.Settings.stopBits
                Case "1"
                    .StopBits = Ports.StopBits.One
                Case "1.5"
                    .StopBits = Ports.StopBits.OnePointFive
                Case "2"
                    .StopBits = Ports.StopBits.Two
                Case "Ninguno"
                    .StopBits = Ports.StopBits.None
            End Select

            Select Case My.Settings.parity
                Case "Par"
                    .Parity = Ports.Parity.Even
                Case "Impar"
                    .Parity = Ports.Parity.Odd
                Case "Ninguno"
                    .Parity = Ports.Parity.None
                Case "Marca"
                    .Parity = Ports.Parity.Mark
                Case "Espacio"
                    .Parity = Ports.Parity.Space
            End Select

            Select Case My.Settings.handshake
                Case "Hardware"
                    .Handshake = Ports.Handshake.RequestToSend
                Case "Xon / Xoff"
                    .Handshake = Ports.Handshake.XOnXOff
                Case "Ninguno"
                    .Handshake = Ports.Handshake.None
                Case "Hardware y Xon/Xoff"
                    .Handshake = Ports.Handshake.RequestToSendXOnXOff
            End Select

            .DtrEnable = False
            .ReadBufferSize = My.Settings.readBufferSize
            .WriteBufferSize = My.Settings.writeBufferSize
            .WriteTimeout = My.Settings.writeTimeout
            .RtsEnable = True
            .Encoding = Encoding.Default
            .Open()
        End With
    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuOptionDatabase.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmDataBase Then
                frm.WindowState = FormWindowState.Normal
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmDataBase.Show()
        frmDataBase.BringToFront()
    End Sub

    Private Sub CapaDeEventosToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles CapaDeEventosToolStripMenuItem.CheckedChanged
        eventsLayer.IsVisibile = CapaDeEventosToolStripMenuItem.Checked
        CapaDeEventosToolStripMenuItem.BackColor = If(CapaDeEventosToolStripMenuItem.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub serialModemSms_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles serialModemSms.DataReceived
        Dim strLine = "=========================================================================="

        Dim result As String = serialModemSms.ReadExisting().Trim

        'rtb.AppendText(result & vbCrLf)

        Dim proc As New Procedure

        ' se captura la cobertura del modem
        If result.IndexOf("+CSQ: ") > -1 Then
            Try
                result = Mid(result.Replace(vbCrLf, "").Replace(vbLf, ""), result.IndexOf("+CSQ: ") + 7, 5)

                Dim signalValue As Double = 0.0
                Dim signal As String = result

                Double.TryParse(signal, signalValue)

                pbarModem.Value = Math.Round(signalValue, 0)
            Catch ex As Exception
            End Try

        ElseIf result.IndexOf("+CDS: ") > -1 Then
            '"+CDS: 24" & vbCrLf & "0791852404009045062C0A811422832630716051102171697160511021816900" & vbCrLf & vbCrLf & "^MODE:3,3" & vbCrLf & vbCrLf & "OK"	String
            Try
                result = Mid(result, result.IndexOf("+CDS: ") + 7)
                Dim splitted() As String = result.Split(vbCrLf)
                Dim pduCode As String = splitted(1).Replace(vbLf, "")
                Dim s As Object            '    
                Dim T As SMSBase.SMSType = SMSBase.GetSMSType(pduCode)
                s = New SMS_STATUS_REPORT(pduCode)

                Dim status As String = If((s.status).ToString().ToLower().Contains("success"), "Mensaje Entregado", "Mensaje Fallido")
                Dim date_time As String = DirectCast(s.TP_DP, Date).ToString("dd/MM/yyyy hh:mm:ss tt")
                Dim client_name As String = ""
                Dim textToVoice As String = status

                If proc.GetData("clients_getByPhoneNumber", s.SrcAddressValue) Then
                    If proc.Ds.Tables(0).Rows.Count > 0 Then
                        client_name = (proc.Ds.Tables(0).Rows(0)("first_name") & " " & If(proc.Ds.Tables(0).Rows(0)("last_name") Is DBNull.Value, "", proc.Ds.Tables(0).Rows(0)("last_name"))).ToString().Trim
                        textToVoice = client_name & ", " & status
                    End If
                End If

                textsToVoice.Add(textToVoice)

                rtb.AppendText(vbCrLf & strLine & vbCrLf & status.ToUpper & vbCrLf)
                rtb.AppendText("REMITENTE: " & If(client_name = "", s.SrcAddressValue, client_name & " (" & s.SrcAddressValue & ")") & vbCrLf)
                rtb.AppendText("FECHA/HORA: " & date_time & vbCrLf)
                rtb.AppendText(vbCrLf & strLine & vbCrLf)

                If cboxAutoScroll.Checked Then
                    rtb.Select(rtb.Text.Length, 0)
                    rtb.ScrollToCaret()
                End If

                Dim th As New Threading.Thread(AddressOf speak)
                th.Start()
            Catch ex As Exception
            End Try

        ElseIf result.IndexOf("+CMT: ") > -1 Then
            '"+CMT: ""04122372142"",,""17/06/15,23:58:55-16""" & vbCrLf & "Power: ON" & vbCrLf & "Bat: 100%" & vbCrLf & "GPRS: ON" & vbCrLf & "GPS: ON" & vbCrLf & "ACC: ON" & vbCrLf & "Door: OFF" & vbCrLf & "GSM: 21" & vbCrLf & "Oil: 0.00%" & vbCrLf & "APN: gprsweb.digitel.ve,,;" & vbCrLf & "IP: 190.142.248.235:24000" & vbCrLf & "Arm: OFF"

            Dim incoming As String = Mid(result, result.IndexOf("+CMT: ") + 1)
            Dim arr() As String = incoming.Replace(Chr(34), "").Split(",")
            Dim phone_number As String = arr(0).Replace("+CMT: ", "")
            Dim date_time As String = Date.Parse("20" & arr(2) & " " & Mid(arr(3), 1, 8)).ToString("dd/MM/yyyy hh:mm:ss tt")
            Dim message As String = Mid(incoming, incoming.IndexOf(vbCrLf) + 3).Replace(Chr(34), "")
            Dim status As String = "Mensaje Recibido"
            Dim cmdResponse As String = ""
            Dim client_name As String = ""
            Dim textToVoice As String = status

            If message.ToLower.Contains("adminip") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "ADMIN IPÉ, OKEY"
            End If

            If message.ToLower.Contains("apn") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "A P N, OKEY"
            End If

            If message.ToLower.Contains("gprs") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "GPRS, OKEY"
            End If

            If message.ToLower.Contains("begin") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "BEGUÍN, OKEY"
            End If

            If message.ToLower.Contains("reset") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "RESET, OKEY"
            End If

            If message.ToLower.Contains("admin") AndAlso Not message.ToLower.Contains("ip") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "ADMIN, OKEY"
            End If

            If message.ToLower.Contains("time") AndAlso message.ToLower.Contains("ok") Then
                cmdResponse = "TAIM, OKEY"
            End If

            If proc.GetData("clients_getByPhoneNumber", phone_number) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    client_name = (proc.Ds.Tables(0).Rows(0)("first_name") & " " & If(proc.Ds.Tables(0).Rows(0)("last_name") Is DBNull.Value, "", proc.Ds.Tables(0).Rows(0)("last_name"))).ToString().Trim
                    textToVoice = client_name & ", " & If(cmdResponse = "", status, cmdResponse)
                End If
            End If

            textsToVoice.Add(textToVoice)

            rtb.AppendText(vbCrLf & strLine & vbCrLf & status.ToUpper & vbCrLf)
            rtb.AppendText("REMITENTE: " & If(client_name = "", phone_number, client_name & " (" & phone_number & ")") & vbCrLf)
            rtb.AppendText("FECHA/HORA: " & date_time & vbCrLf)
            rtb.AppendText("MENSAJE: " & vbCrLf & message & vbCrLf)
            rtb.AppendText(strLine & vbCrLf)

            If cboxAutoScroll.Checked Then
                rtb.Select(rtb.Text.Length, 0)
                rtb.ScrollToCaret()
            End If

            Dim th As New Threading.Thread(AddressOf speak)
            th.Start()
        ElseIf result.IndexOf("+CMGL: ") > -1 Then

        ElseIf result.IndexOf("+CMGS: ") > -1 Then


        Else

            If Not result.ToLower = "ok" Then
                If Not result.ToLower = ">" Then
                    rtb.AppendText(vbCrLf & strLine & vbCrLf & "COMANDO AT" & vbCrLf)
                    rtb.AppendText(result)
                    rtb.AppendText(vbCrLf & strLine & vbCrLf)

                    If cboxAutoScroll.Checked Then
                        rtb.Select(rtb.Text.Length, 0)
                        rtb.ScrollToCaret()
                    End If
                End If
            End If
        End If

        serialModemSms.DiscardInBuffer()
    End Sub

    Private Sub btnClearDgvModemSms_Click(sender As Object, e As EventArgs) Handles btnClearDgvModemSms.Click
        rtb.Text = Nothing
    End Sub

    Private Sub menuNoReporting_Click(sender As Object, e As EventArgs) Handles menuNoReporting.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is frmNoReporting Then
                frm.WindowState = FormWindowState.Maximized
                frm.BringToFront()
                Exit Sub
            End If
        Next

        frmNoReporting.Show()
        frmNoReporting.BringToFront()
    End Sub

    Private Sub txtClientFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnReload_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub dgvEvents_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEvents.CellFormatting

        Try
            With dgvEvents.Rows(e.RowIndex)
                If Not TypeOf .Cells("dgvEvents_validation").Value Is DBNull AndAlso Not .Cells("dgvEvents_validation").Value = "" Then

                    Dim fecha As DateTime = .Cells("dgvEvents_date_time").Value
                    Dim valido As DateTime = .Cells("dgvEvents_validation").Value

                    If fecha < valido Then
                        .DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0080FF")
                    Else
                        .DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F5A9A9")
                    End If

                    .DefaultCellStyle.ForeColor = Color.White

                    'If .Cells("dgvEvents_validation").Value > Now Then
                    '.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5c85bc")
                    '.DefaultCellStyle.ForeColor = Color.White
                    'End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Function updateValidationEvents(ByVal license_plate As String, ByVal report_type_id As Integer, ByVal validation As Date)
        'For Each row As DataGridViewRow In Me.dgvEvents.Rows
        '    If Not TypeOf row.Cells("dgvEvents_report_type_id").Value Is DBNull Then
        '        If row.Cells("dgvEvents_license_plate").Value = license_plate AndAlso
        '                row.Cells("dgvEvents_report_type_id").Value = report_type_id Then

        '            row.Cells("dgvEvents_validation").Value = validation
        '        End If
        '    End If
        'Next

        Invoke(refreshEvents(license_plate, report_type_id, validation))
        Return Nothing
    End Function

    Function refreshEvents(ByVal license_plate As String, ByVal report_type_id As Integer, ByVal validation As Date)
        Try
            DrawingControl.SuspendDrawing(dgvEvents)
            For Each row As DataGridViewRow In Me.dgvEvents.Rows
                If Not TypeOf row.Cells("dgvEvents_report_type_id").Value Is DBNull Then
                    If row.Cells("dgvEvents_license_plate").Value = license_plate AndAlso
                        row.Cells("dgvEvents_report_type_id").Value = report_type_id Then

                        row.Cells("dgvEvents_validation").Value = validation
                    End If
                End If
            Next
            dgvEvents.Refresh()
            DrawingControl.ResumeDrawing(dgvEvents)
        Catch ex As Exception

        End Try

        Return Nothing
    End Function

    Private Sub VehículosEnMovimientoToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles VehículosEnMovimientoToolStripMenuItem.CheckedChanged
        markersMovingLayer.IsVisibile = VehículosEnMovimientoToolStripMenuItem.Checked
        VehículosEnMovimientoToolStripMenuItem.BackColor = If(VehículosEnMovimientoToolStripMenuItem.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub bgwSendEventsEmail_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSendEventsEmail.DoWork
        Dim ciclo As Integer = -1

        'Try
        '    Dim proc As New Procedure

        '    If proc.GetData("events_to_send_getUnsent") Then
        '        If proc.Ds.Tables(0).Rows.Count > 0 Then

        '            For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
        '                ciclo = i
        '                Dim row As DataRow = proc.Ds.Tables(0).Rows(i)
        '                Dim asunto As String = "Nuevo Evento - GLS de Venezuela"
        '                Dim mensaje As String = File.ReadAllText(Application.StartupPath & "\mail_template.html")
        '                Dim cliente As String = row("last_name") & ", " & row("first_name")
        '                Dim evento As String = ""
        '                Dim vehiculo As String = row("brand") & " " & row("model")
        '                Dim matricula As String = row("license_plate")

        '                If row("event_name") = "ac alarm" OrElse row("event_name") = "low battery" Then

        '                    evento = "ALERTA de BATERÍA"

        '                ElseIf row("event_name") = "salida geocerca" Then

        '                    evento = "SALIDA DE GEOCERCA"

        '                ElseIf row("event_name") = "entrada geocerca" Then

        '                    evento = "ENTRADA A GEOCERCA"

        '                End If

        '                Dim fecha As String = DirectCast(row("date_time"), Date).ToString("dd-MM-yyyy")
        '                Dim hora As String = DirectCast(row("date_time"), Date).ToString("hh:mm:ss tt")
        '                Dim saludo As String = ""
        '                Dim despedida As String = ""

        '                Dim hour As Integer = Integer.Parse(Now.ToString("HH"))

        '                If hour >= 19 Then
        '                    saludo = "Buenas Noches"
        '                    despedida = "Felíz Noche"
        '                ElseIf hour >= 12 Then
        '                    saludo = "Buenas Tardes"
        '                    despedida = "Felíz Tarde"
        '                Else
        '                    saludo = "Buenos Días"
        '                    despedida = "Felíz Día"
        '                End If

        '                Dim mail As New MimeMessage
        '                mail.From.Add(New MailboxAddress("GLS de Venezuela", "info@bolivarseguro.com.ve"))
        '                mail.To.Add(New MailboxAddress(cliente, row("email")))
        '                mail.Bcc.Add(New MailboxAddress(cliente, "info@bolivarseguro.com.ve"))
        '                mail.Subject = asunto

        '                mensaje = mensaje.Replace("[saludo]", saludo)
        '                mensaje = mensaje.Replace("[cliente]", cliente)
        '                mensaje = mensaje.Replace("[evento]", evento)
        '                mensaje = mensaje.Replace("[fecha]", fecha)
        '                mensaje = mensaje.Replace("[hora]", hora)
        '                mensaje = mensaje.Replace("[modelo]", vehiculo)
        '                mensaje = mensaje.Replace("[matricula]", matricula)
        '                mensaje = mensaje.Replace("[despedida]", despedida)

        '                Dim bodyBuilder As New BodyBuilder
        '                bodyBuilder.HtmlBody = mensaje

        '                mail.Body = bodyBuilder.ToMessageBody()

        '                Using client As New MailKit.Net.Smtp.SmtpClient()
        '                    ServicePointManager.ServerCertificateValidationCallback = Function(s As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) True
        '                    client.Connect("host.caracashosting55.com", 465, True)

        '                    'Note since we don't have an OAuth2 token, disable
        '                    'the XOAUTH2 authentication mechanism.
        '                    client.AuthenticationMechanisms.Remove("XOAUTH2")

        '                    'Note only needed if the SMTP server requires authentication
        '                    client.Authenticate("info@bolivarseguro.com.ve", "infogls2017")

        '                    client.Send(mail)
        '                    client.Disconnect(True)

        '                    Dim pro As New Procedure
        '                    proc.SendData("events_to_send_updateSent", row("event_id"))
        '                End Using
        '            Next
        '        Else
        '            Threading.Thread.Sleep(5000)
        '        End If
        '    Else
        '        Threading.Thread.Sleep(5000)
        '    End If
        'Catch ex As Exception
        '    'MsgBox(ex.Message & " (" & ciclo & ")", MsgBoxStyle.Critical, "Mensaje del Sistema")
        'End Try
    End Sub

    Private Sub bgwSendEventsEmail_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSendEventsEmail.ProgressChanged

    End Sub

    Private Sub bgwSendEventsEmail_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSendEventsEmail.RunWorkerCompleted
        bgwSendEventsEmail.RunWorkerAsync()
    End Sub



    Private Sub ServidorPrincipalToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles ServidorPrincipalToolStripMenuItem.CheckedChanged
        My.Settings.isMainServer = ServidorPrincipalToolStripMenuItem.Checked
        My.Settings.Save()
        ServidorPrincipalToolStripMenuItem.BackColor = If(ServidorPrincipalToolStripMenuItem.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub dgvConsoleVehicles_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvConsoleVehicles.CellFormatting
        Try
            With dgvConsoleVehicles.Rows(e.RowIndex)
                If Not TypeOf .Cells("dgvVehicles_expiration_date").Value Is DBNull AndAlso Not .Cells("dgvVehicles_expiration_date").Value = "" Then
                    If .Cells("dgvVehicles_expiration_date").Value < Now.AddMonths(-1) Then
                        .DefaultCellStyle.BackColor = Color.LightCoral
                        Exit Sub
                    End If

                    If .Cells("dgvVehicles_expiration_date").Value < Now And .Cells("dgvVehicles_expiration_date").Value > Now.AddMonths(1) Then
                        .DefaultCellStyle.BackColor = Color.Orange
                        Exit Sub
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvGeofences_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvGeofences.CellMouseClick
        If e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Left Then
                If e.ColumnIndex = 0 Then
                    eventsLayer.Polygons.Clear()

                    If dgvGeofences.Rows(e.RowIndex).Cells("dgvGeofences_on_map").Value Then
                        dgvGeofences.Rows(e.RowIndex).Cells("dgvGeofences_on_map").Value = False
                    Else
                        For Each marker As GmapMarkerMain In markersLayer.Markers
                            If marker.Imei = dgvGeofences.Rows(e.RowIndex).Cells("dgvGeofences_imei").Value Then

                                Dim points As List(Of GeofencePoint) = New JavaScriptSerializer().Deserialize(Of List(Of GeofencePoint))(dgvGeofences.Rows(e.RowIndex).Cells("dgvGeofences_points").Value)

                                Dim geoPoints As New List(Of PointLatLng)

                                If points.Count > 0 Then
                                    For i = 0 To points.Count - 1
                                        geoPoints.Add(New PointLatLng(points(i).Latitude, points(i).Longitude))
                                    Next
                                End If

                                drawGeofenceSelected(geoPoints, marker.Position)
                                dgvGeofences.Rows(e.RowIndex).Cells("dgvGeofences_on_map").Value = True
                                Exit Sub
                            End If
                        Next

                        MsgBox("Este vehículo no aún no ha reportado", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub drawGeofenceSelected(ByVal pts As List(Of PointLatLng), ByVal curLocation As PointLatLng)

        Dim geofence As New GMapPolygon(pts, "geofenceSelected")
        geofence.Stroke = New Pen(Brushes.Blue, 2)
        geofence.Fill = New SolidBrush(Color.FromArgb(50, Color.LightCoral))

        If geofence.IsInside(curLocation) Then
            geofence.Fill = New SolidBrush(Color.FromArgb(50, Color.LightGreen))
        End If

        eventsLayer.Polygons.Clear()
        eventsLayer.Polygons.Add(geofence)

        If Not mapMain.Overlays.Contains(eventsLayer) Then
            mapMain.Overlays.Add(eventsLayer)
        End If

        eventsLayer.IsVisibile = CapaDeEventosToolStripMenuItem.Checked
    End Sub

    Private Sub VentanaDeGeocercasToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles VentanaDeGeocercasToolStripMenuItem.CheckedChanged
        panelGeofencesVehicles.Visible = VentanaDeGeocercasToolStripMenuItem.Checked
        VentanaDeGeocercasToolStripMenuItem.BackColor = If(VentanaDeGeocercasToolStripMenuItem.Checked, Color.LightGreen, Color.Empty)
    End Sub

    Private Sub btnSendAtCommand_Click(sender As Object, e As EventArgs) Handles btnSendAtCommand.Click
        If serialModemSms.IsOpen Then
            If txtAtCommand.Text.Trim = "" Then
                MsgBox("Debe escribir un comando para enviar", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If

            serialModemSms.Write(txtAtCommand.Text.Trim & Chr(13))
            Application.DoEvents()
        Else
            MsgBox("El modem est{a desconectado", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End If
    End Sub


End Class