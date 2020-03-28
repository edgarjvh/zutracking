Imports System.ComponentModel
Imports System.IO
Public Class frmClients

    Dim main As Form

    Public Sub New(ByVal main As Form)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.main = main
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        rbtnInsertReports.Parent = panelReports
        rbtnSearchReports.Parent = panelReports

        rbtnInsertReports.Location = New Point(7, gboxInsertReport.Location.Y - 1)
        rbtnSearchReports.Location = New Point(7, gboxSearchReports.Location.Y - 1)

    End Sub
    Public Sub New(ByVal client_id As Integer, ByVal main As Form)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.main = main

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        rbtnInsertReports.Parent = panelReports
        rbtnSearchReports.Parent = panelReports

        rbtnInsertReports.Location = New Point(7, gboxInsertReport.Location.Y - 1)
        rbtnSearchReports.Location = New Point(7, gboxSearchReports.Location.Y - 1)

        isFromClientId = client_id
    End Sub

    Public Sub New(ByVal client_id As Integer, ByVal main As Form, ByVal report_type_id As Integer, ByVal vehicle_id As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.main = main

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        rbtnInsertReports.Parent = panelReports
        rbtnSearchReports.Parent = panelReports

        rbtnInsertReports.Location = New Point(7, gboxInsertReport.Location.Y - 1)
        rbtnSearchReports.Location = New Point(7, gboxSearchReports.Location.Y - 1)

        isFromClientId = client_id

        _report_type_id = report_type_id
        _vehicle_id = vehicle_id
    End Sub

    Dim _report_type_id As Integer
    Dim _vehicle_id As Integer
    Dim isFromClientId As Integer = 0
    Dim selectedPage As Integer = 0
    Dim isImage As Boolean = False
    Dim curClientMode As ClientMode = ClientMode.Registering
    Dim curContactMode As ContactMode = ContactMode.Registering
    Dim curVehicleMode As VehicleMode = VehicleMode.Registering
    Dim currentClient As Object = Nothing
    Dim dtReportTypes As DataTable
    Dim dtVehicles As DataTable
    Dim dtPhoneNumbers As DataTable
    Dim dtUsers As DataTable

    Enum ClientMode
        Registering
        Editing
    End Enum

    Enum ContactMode
        Registering
        Editing
    End Enum

    Enum VehicleMode
        Registering
        Editing
    End Enum

    Private Sub frmClients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        rbtnInsertReports.BringToFront()
        rbtnSearchReports.BringToFront()

        dtpFByMonth.MaxDate = Now.AddYears(100)
        dtpFByYear.MaxDate = Now.AddYears(100)
        dtpFRangeFrom.MaxDate = Now.AddYears(100)
        dtpFRangeTo.MaxDate = Now.AddYears(100)

        dtpFByMonth.Value = Date.Parse("01/" & Now.Month.ToString("00") & "/" & Now.Year.ToString("0000"))
        dtpFByYear.Value = Now
        dtpFRangeFrom.Value = Now
        dtpFRangeTo.Value = Now

        cleanReports()

        If isFromClientId > 0 Then
            bgwGetClientById.RunWorkerAsync()
        End If


    End Sub

#Region "Form Cleaners"
    Private Sub cleanClients()

        cboxClientStatus.Checked = False

        For Each ctl As Control In panelCenterPersonal.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If
            ctl.Enabled = False
        Next

        txtDni.Text = Nothing

        For Each ctl As Control In panelHeaderPersonal.Controls
            ctl.Enabled = False
        Next

        cleanContacts()
        cleanVehicles()
        cleanReports()
        isImage = False
        rbtnDni.Enabled = True
        rbtnDni.Checked = True
        txtDni.Enabled = True
        txtDni.Focus()
    End Sub

    Private Sub cleanContacts()
        For Each ctl As Control In panelHeaderContacts.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If

            ctl.Enabled = False
        Next
        btnNewContact.Enabled = True
        dgvContacts.Enabled = True
        dgvContacts.Rows.Clear()
    End Sub

    Private Sub cleanVehicles()
        cboxVehicleStatus.Checked = True
        dtpInstallationDate.Value = Now

        For Each ctl As Control In panelHeaderVehicles.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUComboBox Then
                DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
            End If

            ctl.Enabled = False
        Next

        btnNewVehicle.Enabled = True
        dgvVehicles.Enabled = True
        dgvVehicles.Rows.Clear()
    End Sub

    Private Sub cleanReports()
        rbtnInsertReports.Checked = True
        cboxGeneralReport.Checked = False

        For Each ctl As Control In gboxInsertReport.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUComboBox Then
                DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
            End If
        Next

        cboxFReportType.Checked = False
        cboxFUser.Checked = False
        rbtnFToday.Checked = True
        dtpFRangeFrom.Value = Now
        dtpFRangeTo.Value = Now

        For Each ctl As Control In gboxSearchReports.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUComboBox Then
                DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
            End If

        Next

        dgvReports.Rows.Clear()
        panelReports.Enabled = False
    End Sub


#End Region

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

    Private Sub rbtnDni_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDni.CheckedChanged
        txtDni.Enabled = rbtnDni.Checked
        txtDni.Focus()
    End Sub

    Private Sub btnCancelClient_Click(sender As Object, e As EventArgs) Handles btnCancelClient.Click
        cleanClients()
    End Sub

    Private Sub btnRegisterClient_Click(sender As Object, e As EventArgs) Handles btnRegisterClient.Click
        For Each ctl As Control In panelHeaderPersonal.Controls
            ctl.Enabled = False
        Next

        For Each ctl As Control In panelCenterPersonal.Controls
            ctl.Enabled = True
        Next

        btnSaveClient.Enabled = True
        curClientMode = ClientMode.Registering
        txtFirstName.Focus()
    End Sub

    Private Sub bgwGetClientByDni_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwGetClientByDni.DoWork
        Try
            bgwGetClientByDni.ReportProgress(1)

            Dim proc As New Procedure
            Dim enc As New Encryptation
            Dim client As New Client

            If proc.GetData("clients_getByDni", txtDni.Text.Trim) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    Dim row As DataRow = proc.Ds.Tables(0).Rows(0)
                    client.Id = If(row("client_id") Is DBNull.Value, 0, row("client_id"))
                    client.Dni = If(row("dni") Is DBNull.Value, 0, row("dni"))
                    client.FirstName = If(row("first_name") Is DBNull.Value, "", row("first_name"))
                    client.LastName = If(row("last_name") Is DBNull.Value, "", row("last_name"))
                    client.Email = If(row("email") Is DBNull.Value, "", row("email"))
                    client.Address = If(row("address") Is DBNull.Value, "", row("address"))
                    client.PhoneNumber1 = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                    client.PhoneNumber2 = If(row("phone_number2") Is DBNull.Value, 0, row("phone_number2"))
                    client.WebPass = If(row("web_pass") Is DBNull.Value, "", row("web_pass"))
                    client.Observations = If(row("observations") Is DBNull.Value, "", row("observations"))
                    client.Image = If(row("image") Is DBNull.Value, "", row("image"))
                    client.Status = If(row("status") Is DBNull.Value, 0, row("status"))

                    proc = New Procedure
                    If proc.GetData("contacts_getByClient", client.Id) Then
                        If proc.Ds.Tables(0).Rows.Count > 0 Then
                            For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                                Dim rowContact As DataRow = proc.Ds.Tables(0).Rows(i)
                                Dim contact As New Contact
                                contact.Id = If(rowContact("contact_id") Is DBNull.Value, 0, rowContact("contact_id"))
                                contact.Dni = If(rowContact("dni") Is DBNull.Value, 0, rowContact("dni"))
                                contact.ClientId = If(rowContact("client_id") Is DBNull.Value, 0, rowContact("client_id"))
                                contact.Name = If(rowContact("Name") Is DBNull.Value, "", rowContact("Name"))
                                contact.PhoneNumber1 = If(rowContact("phone_number1") Is DBNull.Value, 0, rowContact("phone_number1"))
                                contact.PhoneNumber2 = If(rowContact("phone_number2") Is DBNull.Value, 0, rowContact("phone_number2"))
                                contact.Observations = If(rowContact("observations") Is DBNull.Value, "", rowContact("observations"))
                                client.Contacts.Add(contact)
                            Next
                        End If
                    End If

                    proc = New Procedure
                    If proc.GetData("vehicles_getByClient", client.Id) Then
                        If proc.Ds.Tables(0).Rows.Count > 0 Then
                            For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                                Dim rowVehicle As DataRow = proc.Ds.Tables(0).Rows(i)
                                Dim vehicle As New Vehicle
                                vehicle.VehicleId = If(rowVehicle("vehicle_id") Is DBNull.Value, 0, rowVehicle("vehicle_id"))
                                vehicle.LicensePlate = If(rowVehicle("license_plate") Is DBNull.Value, "", rowVehicle("license_plate"))
                                vehicle.Brand = If(rowVehicle("brand") Is DBNull.Value, "", rowVehicle("brand"))
                                vehicle.Model = If(rowVehicle("model") Is DBNull.Value, "", rowVehicle("model"))
                                vehicle.Type = If(rowVehicle("type") Is DBNull.Value, "", rowVehicle("type"))
                                vehicle.Year = If(rowVehicle("year") Is DBNull.Value, 0, rowVehicle("year"))
                                vehicle.Color = If(rowVehicle("color") Is DBNull.Value, "", rowVehicle("color"))
                                vehicle.SpeedLimit = If(rowVehicle("speed_limit") Is DBNull.Value, 0, rowVehicle("speed_limit"))
                                vehicle.PhonePass = If(rowVehicle("phone_pass") Is DBNull.Value, "", rowVehicle("phone_pass"))
                                vehicle.InstallationDate = If(rowVehicle("installation_date") Is DBNull.Value, Now, DirectCast(rowVehicle("installation_date"), Date))
                                vehicle.ExpirationDate = If(rowVehicle("expiration_date") Is DBNull.Value, Now, DirectCast(rowVehicle("expiration_date"), Date))
                                vehicle.Priority = If(rowVehicle("priority") Is DBNull.Value, 0, rowVehicle("priority"))
                                vehicle.Status = If(rowVehicle("status") Is DBNull.Value, 0, rowVehicle("status"))
                                vehicle.Observations = If(rowVehicle("observations") Is DBNull.Value, "", rowVehicle("observations"))
                                vehicle.Device.DeviceId = If(rowVehicle("device_id") Is DBNull.Value, 0, rowVehicle("device_id"))
                                vehicle.Device.Imei = If(rowVehicle("imei") Is DBNull.Value, "", rowVehicle("imei"))
                                vehicle.Dealer.DealerId = If(rowVehicle("dealer_id") Is DBNull.Value, 0, rowVehicle("dealer_id"))
                                vehicle.Dealer.Name = If(rowVehicle("name") Is DBNull.Value, "", rowVehicle("name"))
                                vehicle.Dealer.Contact = If(rowVehicle("contact") Is DBNull.Value, "", rowVehicle("contact"))
                                client.Vehicles.Add(vehicle)
                            Next
                        End If
                    End If
                    currentClient = client
                    bgwGetClientByDni.ReportProgress(2)
                Else
                    bgwGetClientByDni.ReportProgress(3)
                End If
            Else
                bgwGetClientByDni.ReportProgress(4, proc.ErrorMsg)
            End If
        Catch ex As Exception
            If ex.InnerException IsNot Nothing Then
                bgwGetClientByDni.ReportProgress(4, ex.InnerException.Message)
            Else
                bgwGetClientByDni.ReportProgress(5, ex.Message)
            End If
        End Try
    End Sub

    Private Sub bgwGetClientByDni_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwGetClientByDni.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                pboxLoading.Visible = True
                Exit Select
            Case 2
                txtFirstName.Text = currentClient.FirstName
                txtLastName.Text = currentClient.LastName
                txtPhoneNumber1.Text = currentClient.PhoneNumber1
                txtPhoneNumber2.Text = If(currentClient.PhoneNumber2 = 0, "", currentClient.PhoneNumber2)
                txtAddress.Text = currentClient.Address
                txtEmail.Text = currentClient.Email
                txtObservations.Text = currentClient.Observations

                cboxClientStatus.Checked = currentClient.Status = 1

                dgvContacts.Rows.Clear()

                If (currentClient.Contacts.Count > 0) Then
                    For c = 0 To currentClient.Contacts.Count - 1
                        dgvContacts.Rows.Add()
                        dgvContacts.Rows(c).Cells("dgvContacts_dni").Value = currentClient.Contacts(c).Dni
                        dgvContacts.Rows(c).Cells("dgvContacts_name").Value = currentClient.Contacts(c).Name
                        dgvContacts.Rows(c).Cells("dgvContacts_phone_number1").Value = currentClient.Contacts(c).PhoneNumber1
                        dgvContacts.Rows(c).Cells("dgvContacts_phone_number2").Value = If(currentClient.Contacts(c).PhoneNumber2 = 0, Nothing, currentClient.Contacts(c).PhoneNumber2)
                        dgvContacts.Rows(c).Cells("dgvContacts_observations").Value = currentClient.Contacts(c).Observations
                        dgvContacts.Rows(c).Cells("dgvContacts_contact_id").Value = currentClient.Contacts(c).Id
                    Next
                End If

                dgvVehicles.Rows.Clear()

                If (currentClient.Vehicles.Count > 0) Then
                    For v = 0 To currentClient.Vehicles.Count - 1
                        dgvVehicles.Rows.Add()
                        dgvVehicles.Rows(v).Cells("dgvVehicles_dealer_name").Value = currentClient.Vehicles(v).Dealer.Name
                        dgvVehicles.Rows(v).Cells("dgvVehicles_imei").Value = currentClient.Vehicles(v).Device.Imei
                        dgvVehicles.Rows(v).Cells("dgvVehicles_license_plate").Value = currentClient.Vehicles(v).LicensePlate
                        dgvVehicles.Rows(v).Cells("dgvVehicles_brand").Value = currentClient.Vehicles(v).Brand
                        dgvVehicles.Rows(v).Cells("dgvVehicles_model").Value = currentClient.Vehicles(v).Model
                        dgvVehicles.Rows(v).Cells("dgvVehicles_type").Value = currentClient.Vehicles(v).Type
                        dgvVehicles.Rows(v).Cells("dgvVehicles_year").Value = currentClient.Vehicles(v).Year
                        dgvVehicles.Rows(v).Cells("dgvVehicles_color").Value = currentClient.Vehicles(v).Color
                        dgvVehicles.Rows(v).Cells("dgvVehicles_speed_limit").Value = currentClient.Vehicles(v).SpeedLimit
                        dgvVehicles.Rows(v).Cells("dgvVehicles_phone_pass").Value = currentClient.Vehicles(v).PhonePass
                        dgvVehicles.Rows(v).Cells("dgvVehicles_installation_date").Value = currentClient.Vehicles(v).InstallationDate
                        dgvVehicles.Rows(v).Cells("dgvVehicles_expiration_date").Value = currentClient.Vehicles(v).ExpirationDate
                        dgvVehicles.Rows(v).Cells("dgvVehicles_priority").Value = currentClient.Vehicles(v).Priority
                        dgvVehicles.Rows(v).Cells("dgvVehicles_status").Value = currentClient.Vehicles(v).Status
                        dgvVehicles.Rows(v).Cells("dgvVehicles_observations").Value = currentClient.Vehicles(v).Observations
                        dgvVehicles.Rows(v).Cells("dgvVehicles_vehicle_id").Value = currentClient.Vehicles(v).VehicleId
                        dgvVehicles.Rows(v).Cells("dgvVehicles_device_id").Value = currentClient.Vehicles(v).Device.DeviceId
                        dgvVehicles.Rows(v).Cells("dgvVehicles_dealer_id").Value = currentClient.Vehicles(v).Dealer.DealerId
                    Next
                End If

                For Each ctl As Control In panelHeaderPersonal.Controls
                    ctl.Enabled = False
                Next

                btnEditClient.Enabled = True
                btnSaveClient.Enabled = False
                btnDeleteClient.Enabled = True
                btnCancelClient.Enabled = True
                btnEditClient.Focus()
                pboxLoading.Visible = False

                Exit Select
            Case 3
                For Each ctl As Control In panelHeaderPersonal.Controls
                    ctl.Enabled = False
                Next

                btnRegisterClient.Enabled = True
                btnCancelClient.Enabled = True
                btnRegisterClient.Focus()

                pboxLoading.Visible = False
                Exit Select

            Case 4
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema - InnerException")
                txtDni.Focus()

                pboxLoading.Visible = False
                Exit Select

            Case 5
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                txtDni.Focus()

                pboxLoading.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub btnSaveClient_Click(sender As Object, e As EventArgs) Handles btnSaveClient.Click
        If txtFirstName.Text.Trim = "" Then
            MsgBox("Debe ingresar el nombre del cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtFirstName.Focus()
            Exit Sub
        End If

        If txtPhoneNumber1.Text.Trim = "" Then
            MsgBox("Debe ingresar el teléfono principal del cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtPhoneNumber1.Focus()
            Exit Sub
        End If

        If txtAddress.Text.Trim = "" Then
            MsgBox("Debe ingresar la dirección de habitación del cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtAddress.Focus()
            Exit Sub
        End If

        If txtEmail.Text.Trim = "" Then
            MsgBox("Debe ingresar el correo electrónico del cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtEmail.Focus()
            Exit Sub
        End If

        If Not bgwSavingClient.IsBusy Then
            bgwSavingClient.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSavingClient_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSavingClient.DoWork
        Try
            bgwSavingClient.ReportProgress(1)
            Dim proc As New Procedure
            Dim enc As New Encryptation

            If curClientMode = ClientMode.Registering Then
                If proc.GetData("clients_insert",
                                                txtDni.Text.Trim,
                                                txtFirstName.Text.Trim,
                                                txtLastName.Text.Trim,
                                                txtPhoneNumber1.Text.Trim,
                                                If(txtPhoneNumber2.Text.Trim = "", 0, txtPhoneNumber2.Text.Trim),
                                                txtAddress.Text.Trim,
                                                txtEmail.Text.Trim,
                                                txtObservations.Text.Trim,
                                                enc.Encrypt(txtDni.Text.Trim),
                                                Nothing,
                                                If(cboxClientStatus.Checked, 1, 0)) Then
                    bgwSavingClient.ReportProgress(2)
                Else
                    bgwSavingClient.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("clients_update",
                                                currentClient.Id,
                                                txtFirstName.Text.Trim,
                                                txtLastName.Text.Trim,
                                                txtPhoneNumber1.Text.Trim,
                                                If(txtPhoneNumber2.Text.Trim = "", 0, txtPhoneNumber2.Text.Trim),
                                                txtAddress.Text.Trim,
                                                txtEmail.Text.Trim,
                                                txtObservations.Text.Trim,
                                                Nothing,
                                                If(cboxClientStatus.Checked, 1, 0)) Then
                    bgwSavingClient.ReportProgress(2)
                Else
                    bgwSavingClient.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSavingClient.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingClient_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwSavingClient.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                For Each ctl As Control In panelCenterPersonal.Controls
                    If Not TypeOf ctl Is PictureBox Then
                        ctl.Enabled = False
                    End If
                Next

                btnSaveClient.Enabled = False
                btnDeleteClient.Enabled = False
                btnCancelClient.Enabled = False
                pboxLoading.Visible = True
                Exit Select
            Case 2
                pboxLoading.Visible = False
                Dim msg As String = If(curClientMode = ClientMode.Registering, "Cliente ingresado exitosamente", "Cliente actualizado exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                cleanClients()
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                For Each ctl As Control In panelCenterPersonal.Controls
                    ctl.Enabled = True
                Next
                btnSaveClient.Enabled = True
                btnDeleteClient.Enabled = False
                btnCancelClient.Enabled = True
                pboxLoading.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub btnEditClient_Click(sender As Object, e As EventArgs) Handles btnEditClient.Click
        For Each ctl As Control In panelCenterPersonal.Controls
            ctl.Enabled = True
        Next
        btnEditClient.Enabled = False
        btnSaveClient.Enabled = True
        curClientMode = ClientMode.Editing
    End Sub

    Private Sub cboxClientStatus_CheckedChanged(sender As Object, e As EventArgs) Handles cboxClientStatus.CheckedChanged
        If cboxClientStatus.Checked Then
            lblStatus.BackColor = Color.LightGreen
        Else
            lblStatus.BackColor = Color.LightCoral
        End If
    End Sub

    Private Sub btnDeleteClient_Click(sender As Object, e As EventArgs) Handles btnDeleteClient.Click
        If MsgBox("Está realmente seguro de eliminar el cliente actual?" & vbNewLine &
                  "Al hacerlo también se eliminarán todos los registros asociados tales como:" & vbNewLine &
                  "vehículos, dispositivos, reportes, etc.", MsgBoxStyle.Question + vbYesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If MsgBox("Presione SI para confirmar la eliminación del cliente actual", MsgBoxStyle.Question + vbYesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If Not bgwDeletingClient.IsBusy Then
                    bgwDeletingClient.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub bgwDeletingClient_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDeletingClient.DoWork
        Try
            bgwDeletingClient.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("clients_delete", currentClient.Id) Then
                bgwDeletingClient.ReportProgress(2)
            Else
                bgwDeletingClient.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingClient.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingClient_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwDeletingClient.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                For Each ctl As Control In panelCenterPersonal.Controls
                    If Not TypeOf ctl Is PictureBox Then
                        ctl.Enabled = False
                    End If
                Next

                btnSaveClient.Enabled = False
                btnDeleteClient.Enabled = False
                btnCancelClient.Enabled = False
                pboxLoading.Visible = True
                Exit Select
            Case 2
                pboxLoading.Visible = False
                MsgBox("Cliente eliminado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                cleanClients()
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                For Each ctl As Control In panelCenterPersonal.Controls
                    ctl.Enabled = True
                Next
                btnSaveClient.Enabled = True
                btnDeleteClient.Enabled = False
                btnCancelClient.Enabled = True
                pboxLoading.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub btnNewContact_Click(sender As Object, e As EventArgs) Handles btnNewContact.Click
        For Each ctl As Control In panelHeaderContacts.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If

            ctl.Enabled = True
        Next

        dgvContacts.Enabled = False

        btnNewContact.Enabled = False
        btnEditContact.Enabled = False
        btnSaveContact.Enabled = True
        btnDeleteContact.Enabled = False
        btnCancelContact.Enabled = True

        curContactMode = ContactMode.Registering
        txtContactDni.Focus()
    End Sub

    Private Sub btnCancelContact_Click(sender As Object, e As EventArgs) Handles btnCancelContact.Click
        For Each ctl As Control In panelHeaderContacts.Controls
            If TypeOf ctl Is ZUControls.ZUTextBox Then
                DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUNumericBox Then
                DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
            End If

            ctl.Enabled = False
        Next

        btnNewContact.Enabled = True
        dgvContacts.Enabled = True
    End Sub

    Private Sub dgvContacts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContacts.CellClick
        If e.RowIndex >= 0 Then
            For Each ctl As Control In panelHeaderContacts.Controls
                If TypeOf ctl Is ZUControls.ZUTextBox Then
                    DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
                End If

                If TypeOf ctl Is ZUControls.ZUNumericBox Then
                    DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
                End If

                If Not TypeOf ctl Is ZUControls.ZUButton AndAlso Not TypeOf ctl Is ZUControls.ZUDataGridView Then
                    ctl.Enabled = False
                End If
            Next

            txtContactDni.Text = dgvContacts.CurrentRow.Cells("dgvContacts_dni").Value
            txtContactName.Text = dgvContacts.CurrentRow.Cells("dgvContacts_name").Value
            txtContactPhoneNumber1.Text = dgvContacts.CurrentRow.Cells("dgvContacts_phone_number1").Value
            txtContactPhoneNumber2.Text = dgvContacts.CurrentRow.Cells("dgvContacts_phone_number2").Value
            txtContactObservations.Text = dgvContacts.CurrentRow.Cells("dgvContacts_observations").Value

            btnNewContact.Enabled = True
            btnEditContact.Enabled = True
            btnSaveContact.Enabled = False
            btnDeleteContact.Enabled = True
            btnCancelContact.Enabled = False
        End If
    End Sub

    Private Sub btnSaveContact_Click(sender As Object, e As EventArgs) Handles btnSaveContact.Click
        If txtContactDni.Text.Trim = "" Then
            MsgBox("Debe ingresar la cédula del contacto", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtContactDni.Focus()
            Exit Sub
        End If

        If txtContactName.Text.Trim = "" Then
            MsgBox("Debe ingresar el nombre del contacto", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtContactName.Focus()
            Exit Sub
        End If

        If txtPhoneNumber1.Text.Trim = "" Then
            MsgBox("Debe ingresar el número telefónico principal del contacto", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtPhoneNumber1.Focus()
            Exit Sub
        End If

        If Not bgwSavingContacts.IsBusy Then
            bgwSavingContacts.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSavingContacts_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSavingContacts.DoWork
        Try
            bgwSavingContacts.ReportProgress(1)
            Dim proc As New Procedure

            If curContactMode = ContactMode.Registering Then

                If proc.GetData("contacts_insert",
                                                txtContactDni.Text.Trim,
                                                currentClient.Id,
                                                txtContactName.Text.Trim,
                                                txtContactPhoneNumber1.Text.Trim,
                                                If(txtContactPhoneNumber2.Text.Trim = "", 0, txtContactPhoneNumber2.Text.Trim),
                                                txtContactObservations.Text.Trim) Then
                    bgwSavingContacts.ReportProgress(2)
                Else
                    bgwSavingContacts.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("contacts_update",
                                                    dgvContacts.CurrentRow.Cells("dgvContacts_contact_id").Value,
                                                   txtContactDni.Text.Trim,
                                                   txtContactName.Text.Trim,
                                                   txtContactPhoneNumber1.Text.Trim,
                                                   If(txtContactPhoneNumber2.Text.Trim = "", 0, txtContactPhoneNumber2.Text.Trim),
                                                   txtContactObservations.Text.Trim) Then
                    bgwSavingContacts.ReportProgress(2)
                Else
                    bgwSavingContacts.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSavingContacts.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingContacts_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwSavingContacts.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderContacts.Enabled = False
                lblLoadingContacts.Text = "Guardando contacto... Por favor espere"
                panelLoadingContacts.Visible = True
                Exit Select
            Case 2
                panelLoadingContacts.Visible = False
                Dim msg As String = If(curContactMode = ContactMode.Registering, "Contacto ingresado exitosamente", "Contacto actualizado exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                cleanContacts()
                getContactsByClient(currentClient.Id)
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelHeaderContacts.Enabled = True
                panelLoadingContacts.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub btnEditContact_Click(sender As Object, e As EventArgs) Handles btnEditContact.Click
        For Each ctl As Control In panelHeaderContacts.Controls
            ctl.Enabled = True
        Next

        btnNewContact.Enabled = False
        btnEditContact.Enabled = False
        btnSaveContact.Enabled = True
        btnDeleteContact.Enabled = True
        btnCancelContact.Enabled = True

        dgvContacts.Enabled = False

        curContactMode = ContactMode.Editing
        txtContactDni.Focus()
    End Sub

    Private Sub dgvContacts_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvContacts.KeyUp
        If e.KeyCode = Keys.Down Then
            For Each ctl As Control In panelHeaderContacts.Controls
                If TypeOf ctl Is ZUControls.ZUTextBox Then
                    DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
                End If

                If TypeOf ctl Is ZUControls.ZUNumericBox Then
                    DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
                End If

                If Not TypeOf ctl Is ZUControls.ZUButton AndAlso Not TypeOf ctl Is ZUControls.ZUDataGridView Then
                    ctl.Enabled = False
                End If
            Next

            txtContactDni.Text = dgvContacts.CurrentRow.Cells("dgvContacts_dni").Value
            txtContactName.Text = dgvContacts.CurrentRow.Cells("dgvContacts_name").Value
            txtContactPhoneNumber1.Text = dgvContacts.CurrentRow.Cells("dgvContacts_phone_number1").Value
            txtContactPhoneNumber2.Text = dgvContacts.CurrentRow.Cells("dgvContacts_phone_number2").Value
            txtContactObservations.Text = dgvContacts.CurrentRow.Cells("dgvContacts_observations").Value

            btnNewContact.Enabled = True
            btnEditContact.Enabled = True
            btnSaveContact.Enabled = False
            btnDeleteContact.Enabled = True
            btnCancelContact.Enabled = False
        End If

        If e.KeyCode = Keys.Up Then
            For Each ctl As Control In panelHeaderContacts.Controls
                If TypeOf ctl Is ZUControls.ZUTextBox Then
                    DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
                End If

                If TypeOf ctl Is ZUControls.ZUNumericBox Then
                    DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
                End If

                If Not TypeOf ctl Is ZUControls.ZUButton AndAlso Not TypeOf ctl Is ZUControls.ZUDataGridView Then
                    ctl.Enabled = False
                End If
            Next

            txtContactDni.Text = dgvContacts.CurrentRow.Cells("dgvContacts_dni").Value
            txtContactName.Text = dgvContacts.CurrentRow.Cells("dgvContacts_name").Value
            txtContactPhoneNumber1.Text = dgvContacts.CurrentRow.Cells("dgvContacts_phone_number1").Value
            txtContactPhoneNumber2.Text = dgvContacts.CurrentRow.Cells("dgvContacts_phone_number2").Value
            txtContactObservations.Text = dgvContacts.CurrentRow.Cells("dgvContacts_observations").Value

            btnNewContact.Enabled = True
            btnEditContact.Enabled = True
            btnSaveContact.Enabled = False
            btnDeleteContact.Enabled = True
            btnCancelContact.Enabled = False
        End If
    End Sub

    Private Sub getContactsByClient(ByVal client_id As Integer)
        If Not bgwGetContacts.IsBusy Then
            dgvContacts.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvContacts)
            bgwGetContacts.RunWorkerAsync(client_id)
        End If
    End Sub

    Private Sub bgwGetContacts_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwGetContacts.DoWork
        Try
            bgwGetContacts.ReportProgress(1)

            Dim proc As New Procedure
            dgvContacts.Rows.Clear()

            If proc.GetData("contacts_getByClient", e.Argument) Then
                bgwGetContacts.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwGetContacts.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetContacts.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetContacts_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetContacts.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderContacts.Enabled = False
                dgvContacts.Enabled = False
                lblLoadingContacts.Text = "Cargando contactos... Por favor espere"
                panelLoadingContacts.Visible = True
                Exit Select
            Case 2
                panelLoadingContacts.Visible = False

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvContacts.Rows.Add()
                        dgvContacts.Rows(i).Cells("dgvContacts_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvContacts.Rows(i).Cells("dgvContacts_name").Value = If(row("name") Is DBNull.Value, "", row("name"))
                        dgvContacts.Rows(i).Cells("dgvContacts_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvContacts.Rows(i).Cells("dgvContacts_phone_number2").Value = If(row("phone_number1") Is DBNull.Value, Nothing, row("phone_number1"))
                        dgvContacts.Rows(i).Cells("dgvContacts_observations").Value = If(row("observations") Is DBNull.Value, "", row("observations"))
                        dgvContacts.Rows(i).Cells("dgvContacts_contact_id").Value = If(row("contact_id") Is DBNull.Value, 0, row("contact_id"))
                    Next
                End If

                panelHeaderContacts.Enabled = True
                dgvContacts.Enabled = True
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelHeaderContacts.Enabled = True
                dgvContacts.Enabled = True
                Exit Select
        End Select
    End Sub

    Private Sub bgwDeletingContacts_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeletingContacts.DoWork
        Try
            bgwDeletingContacts.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("contacts_delete", dgvContacts.CurrentRow.Cells("dgvContacts_contact_id").Value) Then
                bgwDeletingContacts.ReportProgress(2)
            Else
                bgwDeletingContacts.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingContacts.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingContacts_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeletingContacts.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderContacts.Enabled = False
                dgvContacts.Enabled = False
                lblLoadingContacts.Text = "Eliminando contacto... Por favor espere"
                panelLoadingContacts.Visible = True
                Exit Select
            Case 2
                panelLoadingContacts.Visible = False
                MsgBox("Contacto eliminado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                cleanContacts()
                getContactsByClient(currentClient.Id)
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelHeaderContacts.Enabled = True
                dgvContacts.Enabled = True
                panelLoadingContacts.Visible = False
                Exit Select
        End Select
    End Sub

    Private Sub btnDeleteContact_Click(sender As Object, e As EventArgs) Handles btnDeleteContact.Click
        If MsgBox("¿Está seguro de eliminar el contacto actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If Not bgwDeletingContacts.IsBusy Then
                bgwDeletingContacts.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub getVehicleDevices(ByVal asigned As Integer)
        Dim proc As New Procedure

        Dim dt As New DataTable("devices")
        Dim col1 As New DataColumn("device_id")
        Dim col2 As New DataColumn("imei")
        dt.Columns.Add(col1)
        dt.Columns.Add(col2)

        Dim row As DataRow

        If curVehicleMode = VehicleMode.Editing Then
            row = dt.NewRow()
            row.Item("device_id") = CInt(dgvVehicles.CurrentRow.Cells("dgvVehicles_device_id").Value)
            row.Item("imei") = dgvVehicles.CurrentRow.Cells("dgvVehicles_imei").Value
            dt.Rows.Add(row)
        End If

        If proc.GetData("devices_getByAsigned", asigned) Then
            If proc.Ds.Tables(0).Rows.Count > 0 Then

                For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                    Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                    row = dt.NewRow()
                    row.Item("device_id") = If(row2("device_id") Is DBNull.Value, 0, row2("device_id"))
                    row.Item("imei") = If(row2("imei") Is DBNull.Value, "", row2("imei"))
                    dt.Rows.Add(row)
                Next
            End If
        Else
            MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End If

        cboDevice.DataSource = Nothing
        cboDevice.DataSource = dt
        cboDevice.DisplayMember = "imei"
        cboDevice.ValueMember = "device_id"
        cboDevice.SelectedIndex = -1

    End Sub

    Private Sub bgwGetDevices_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetDevices.DoWork
        Try
            bgwGetDevices.ReportProgress(1)
            getVehicleDevices(e.Argument)
            getDealers()
            bgwGetDevices.ReportProgress(2)
        Catch ex As Exception
            bgwGetDevices.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetDevices_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetDevices.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderVehicles.Enabled = False
                dgvVehicles.Enabled = False
                lblLoadingVehicles.Text = "Cargando lista de dispositivos... Por favor espere"
                panelLoadingVehicles.Visible = True
                Exit Select
            Case 2
                panelHeaderVehicles.Enabled = True
                dgvVehicles.Enabled = True
                panelLoadingVehicles.Visible = False

                For Each ctl As Control In panelHeaderVehicles.Controls
                    If Not TypeOf ctl Is ZUControls.ZUButton Then
                        If curVehicleMode = VehicleMode.Registering Then
                            If TypeOf ctl Is ZUControls.ZUComboBox Then
                                DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
                            End If

                            If TypeOf ctl Is ZUControls.ZUTextBox Or TypeOf ctl Is ZUControls.ZUNumericBox Then
                                ctl.Text = ""
                            End If

                            If TypeOf ctl Is CheckBox Then
                                DirectCast(ctl, CheckBox).Checked = True
                            End If
                        End If

                        ctl.Enabled = True
                    End If
                Next

                If curVehicleMode = VehicleMode.Editing Then
                    cboDevice.SelectedValue = CInt(dgvVehicles.CurrentRow.Cells("dgvVehicles_device_id").Value)
                    cboDealer.SelectedValue = CInt(dgvVehicles.CurrentRow.Cells("dgvVehicles_dealer_id").Value)
                End If

                btnNewVehicle.Enabled = False
                btnEditVehicle.Enabled = False
                btnSaveVehicle.Enabled = True
                btnDeleteVehicle.Enabled = False
                btnCancelVehicle.Enabled = True
                txtLicensePlate.Focus()
                dgvVehicles.Enabled = False

                Exit Select
            Case 3
                panelHeaderVehicles.Enabled = True
                dgvVehicles.Enabled = True
                panelLoadingVehicles.Visible = False

                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnNewVehicle_Click(sender As Object, e As EventArgs) Handles btnNewVehicle.Click
        If Not bgwGetDevices.IsBusy Then
            curVehicleMode = VehicleMode.Registering
            bgwGetDevices.RunWorkerAsync(0)
        End If
    End Sub

    Private Sub getDealers()
        Dim dt As New DataTable("dealers")
        Dim col1 As New DataColumn("dealer_id")
        Dim col2 As New DataColumn("dealer")
        dt.Columns.Add(col1)
        dt.Columns.Add(col2)
        Dim row As DataRow
        Dim proc As New Procedure

        If proc.GetData("dealers_getAll") Then
            If proc.Ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                    Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                    row = dt.NewRow()
                    row.Item("dealer_id") = If(row2("dealer_id") Is DBNull.Value, 0, row2("dealer_id"))
                    row.Item("dealer") = If(row2("name") Is DBNull.Value, "", row2("name"))
                    dt.Rows.Add(row)
                Next
            End If
        Else
            MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End If

        cboDealer.Enabled = True
        cboDealer.DataSource = Nothing
        cboDealer.Text = ""
        cboDealer.DataSource = dt
        cboDealer.DisplayMember = "dealer"
        cboDealer.ValueMember = "dealer_id"
        cboDealer.SelectedIndex = -1
        cboDealer.Text = ""
        cboDealer.Enabled = False
    End Sub

    Private Sub bgwGetDealers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetDealers.DoWork
        Try
            getDealers()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub bgwGetDealers_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetDealers.ProgressChanged
        cboDealer.SelectedIndex = -1
    End Sub

    Private Sub btnEditVehicle_Click(sender As Object, e As EventArgs) Handles btnEditVehicle.Click
        If Not bgwGetDevices.IsBusy Then
            curVehicleMode = VehicleMode.Editing
            bgwGetDevices.RunWorkerAsync(0)
        End If
    End Sub

    Private Sub btnCancelVehicle_Click(sender As Object, e As EventArgs) Handles btnCancelVehicle.Click
        cboxVehicleStatus.Checked = True
        dtpInstallationDate.Value = Now

        For Each ctl As Control In panelHeaderVehicles.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                If TypeOf ctl Is ZUControls.ZUComboBox Then
                    DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
                End If

                If TypeOf ctl Is ZUControls.ZUTextBox Or TypeOf ctl Is ZUControls.ZUNumericBox Then
                    ctl.Text = ""
                End If

                ctl.Enabled = False
            End If
        Next

        btnNewVehicle.Enabled = True
        btnEditVehicle.Enabled = False
        btnSaveVehicle.Enabled = False
        btnDeleteVehicle.Enabled = False
        btnCancelVehicle.Enabled = False
        dgvVehicles.Enabled = True
    End Sub

    Private Sub getVehiclesByClient(ByVal vehicle_id As Integer)
        If Not bgwGetVehicles.IsBusy Then
            bgwGetVehicles.RunWorkerAsync(currentClient.Id)
        End If
    End Sub

    Private Sub bgwGetVehicles_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetVehicles.DoWork
        Try
            bgwGetVehicles.ReportProgress(1)
            Dim proc As New Procedure
            dgvVehicles.Rows.Clear()

            If proc.GetData("vehicles_getByClient", e.Argument) Then
                bgwGetVehicles.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwGetVehicles.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetVehicles.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetVehicles_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetVehicles.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderVehicles.Enabled = False
                dgvVehicles.Enabled = False
                lblLoadingVehicles.Text = "Cargando vehículos... Por favor espere"
                panelLoadingVehicles.Visible = True
                Exit Select
            Case 2
                If e.UserState.Rows.Count > 0 Then
                    For v = 0 To e.UserState.Rows.Count - 1
                        Dim rowVehicle As DataRow = e.UserState.Rows(v)
                        dgvVehicles.Rows.Add()
                        dgvVehicles.Rows(v).Cells("dgvVehicles_dealer_name").Value = If(rowVehicle("name") Is DBNull.Value, "", rowVehicle("name"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_imei").Value = If(rowVehicle("imei") Is DBNull.Value, "", rowVehicle("imei"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_license_plate").Value = If(rowVehicle("license_plate") Is DBNull.Value, "", rowVehicle("license_plate"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_brand").Value = If(rowVehicle("brand") Is DBNull.Value, "", rowVehicle("brand"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_model").Value = If(rowVehicle("model") Is DBNull.Value, "", rowVehicle("model"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_type").Value = If(rowVehicle("type") Is DBNull.Value, "", rowVehicle("type"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_year").Value = If(rowVehicle("year") Is DBNull.Value, 0, rowVehicle("year"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_color").Value = If(rowVehicle("color") Is DBNull.Value, "", rowVehicle("color"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_speed_limit").Value = If(rowVehicle("speed_limit") Is DBNull.Value, 0, rowVehicle("speed_limit"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_phone_pass").Value = If(rowVehicle("phone_pass") Is DBNull.Value, "", rowVehicle("phone_pass"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_installation_date").Value = If(rowVehicle("installation_date") Is DBNull.Value, Now, DirectCast(rowVehicle("installation_date"), Date))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_expiration_date").Value = If(rowVehicle("expiration_date") Is DBNull.Value, Now, DirectCast(rowVehicle("expiration_date"), Date))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_priority").Value = If(rowVehicle("priority") Is DBNull.Value, 0, rowVehicle("priority"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_status").Value = If(rowVehicle("status") Is DBNull.Value, 0, rowVehicle("status"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_observations").Value = If(rowVehicle("observations") Is DBNull.Value, "", rowVehicle("observations"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_vehicle_id").Value = If(rowVehicle("vehicle_id") Is DBNull.Value, 0, rowVehicle("vehicle_id"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_device_id").Value = If(rowVehicle("device_id") Is DBNull.Value, 0, rowVehicle("device_id"))
                        dgvVehicles.Rows(v).Cells("dgvVehicles_dealer_id").Value = If(rowVehicle("dealer_id") Is DBNull.Value, 0, rowVehicle("dealer_id"))
                    Next
                End If

                panelHeaderVehicles.Enabled = True
                dgvVehicles.Enabled = True
                panelLoadingVehicles.Visible = False
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelHeaderVehicles.Enabled = True
                dgvVehicles.Enabled = True
                Exit Select
        End Select
    End Sub

    Private Sub btnSaveVehicle_Click(sender As Object, e As EventArgs) Handles btnSaveVehicle.Click
        If txtLicensePlate.Text.Trim = "" Then
            MsgBox("Debe ingresar la matricula del vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtLicensePlate.Focus()
            Exit Sub
        End If

        If txtBrand.Text.Trim = "" Then
            MsgBox("Debe ingresar la marca del vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtBrand.Focus()
            Exit Sub
        End If

        If txtModel.Text.Trim = "" Then
            MsgBox("Debe ingresar el modelo del vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtModel.Focus()
            Exit Sub
        End If

        If txtType.Text.Trim = "" Then
            MsgBox("Debe ingresar el tipo de vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtType.Focus()
            Exit Sub
        End If

        If txtYear.Text.Trim = "" Then
            MsgBox("Debe ingresar el año del vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtYear.Focus()
            Exit Sub
        End If

        If txtColor.Text.Trim = "" Then
            MsgBox("Debe ingresar el color del vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtColor.Focus()
            Exit Sub
        End If

        If txtSpeedLimit.Text.Trim = "" Then
            MsgBox("Debe ingresar la velocidad límite del vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtSpeedLimit.Focus()
            Exit Sub
        End If

        If cboDealer.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboDealer.Focus()
            Exit Sub
        End If

        If cboDevice.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un dispositivo gps", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboDevice.Focus()
            Exit Sub
        End If

        If Not bgwSavingVehicles.IsBusy Then
            bgwSavingVehicles.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSavingVehicles_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSavingVehicles.DoWork
        Try
            bgwSavingVehicles.ReportProgress(1)
            Dim proc As New Procedure
            Dim enc As New Encryptation

            If curVehicleMode = VehicleMode.Registering Then
                If proc.GetData("vehicles_insert",
                                                    currentClient.Id,
                                                    cboDevice.SelectedValue,
                                                    cboDealer.SelectedValue,
                                                    txtLicensePlate.Text.Trim,
                                                    txtBrand.Text.Trim,
                                                    txtModel.Text.Trim,
                                                    txtType.Text.Trim,
                                                    txtYear.Text.Trim,
                                                    txtColor.Text.Trim,
                                                    txtSpeedLimit.Text.Trim,
                                                    If(txtCallPass.Text.Trim = "", "", enc.Encrypt(txtCallPass.Text.Trim)),
                                                    dtpInstallationDate.Value,
                                                    dtpExpirationDate.Value,
                                                    1,
                                                    If(cboxVehicleStatus.Checked, 1, 0),
                                                    txtObservations.Text.Trim) Then
                    bgwSavingVehicles.ReportProgress(2)
                Else
                    bgwSavingVehicles.ReportProgress(3, proc.ErrorMsg)
                End If
            Else

                If proc.GetData("vehicles_update",
                                                    dgvVehicles.CurrentRow.Cells("dgvVehicles_vehicle_id").Value,
                                                    currentClient.Id,
                                                    cboDevice.SelectedValue,
                                                    cboDealer.SelectedValue,
                                                    txtLicensePlate.Text.Trim,
                                                    txtBrand.Text.Trim,
                                                    txtModel.Text.Trim,
                                                    txtType.Text.Trim,
                                                    txtYear.Text.Trim,
                                                    txtColor.Text.Trim,
                                                    txtSpeedLimit.Text.Trim,
                                                    If(txtCallPass.Text.Trim = "", "", enc.Encrypt(txtCallPass.Text.Trim)),
                                                    dtpInstallationDate.Value,
                                                    dtpExpirationDate.Value,
                                                    1,
                                                    If(cboxVehicleStatus.Checked, 1, 0),
                                                    txtVehicleObservations.Text.Trim) Then
                    bgwSavingVehicles.ReportProgress(2)
                Else
                    bgwSavingVehicles.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSavingVehicles.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingVehicles_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSavingVehicles.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderVehicles.Enabled = False
                dgvVehicles.Enabled = False
                lblLoadingVehicles.Text = "Guardando vehículo... Por favor espere"
                panelLoadingVehicles.Visible = True
                Exit Select
            Case 2
                panelLoadingVehicles.Visible = False
                Dim msg As String = If(curVehicleMode = VehicleMode.Registering, "Vehículo ingresado exitosamente", "Vehículo actualizado exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                cleanVehicles()
                getVehiclesByClient(currentClient.Id)
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelHeaderVehicles.Enabled = False
                dgvVehicles.Enabled = True
                Exit Select
        End Select
    End Sub

    Private Sub btnDeleteVehicle_Click(sender As Object, e As EventArgs) Handles btnDeleteVehicle.Click
        If (MsgBox("¿Está seguro de eliminar el vehículo actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema")) = MsgBoxResult.Yes Then
            If Not bgwDeletingVehicles.IsBusy Then
                bgwDeletingVehicles.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwDeletingVehicles_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeletingVehicles.DoWork
        Try
            bgwDeletingVehicles.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("vehicles_delete", dgvVehicles.CurrentRow.Cells("dgvVehicles_vehicle_id").Value) Then
                bgwDeletingVehicles.ReportProgress(2)
            Else
                bgwDeletingVehicles.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingVehicles.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingVehicles_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeletingVehicles.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeaderVehicles.Enabled = False
                dgvVehicles.Enabled = False
                lblLoadingVehicles.Text = "Eliminando vehículo... Por favor espere"
                panelLoadingVehicles.Visible = True
                Exit Select
            Case 2
                panelLoadingVehicles.Visible = False

                MsgBox("Vehículo eliminado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                cleanVehicles()
                getVehiclesByClient(currentClient.Id)
                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                panelLoadingVehicles.Visible = False
                panelHeaderVehicles.Enabled = True
                Exit Select
        End Select
    End Sub

    Private Sub dgvVehicles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVehicles.CellClick
        If e.RowIndex >= 0 Then
            Dim enc As New Encryptation
            txtLicensePlate.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_license_plate").Value
            txtBrand.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_brand").Value
            txtModel.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_model").Value
            txtType.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_type").Value
            txtYear.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_year").Value
            txtColor.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_color").Value
            txtSpeedLimit.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_speed_limit").Value

            cboDealer.DataSource = Nothing
            cboDealer.Items.Clear()
            cboDealer.Items.Add(dgvVehicles.CurrentRow.Cells("dgvVehicles_dealer_name").Value)
            cboDealer.SelectedIndex = 0

            txtCallPass.Text = If(dgvVehicles.CurrentRow.Cells("dgvVehicles_phone_pass").Value = "", "", enc.Decrypt(dgvVehicles.CurrentRow.Cells("dgvVehicles_phone_pass").Value))
            dtpInstallationDate.Value = DirectCast(dgvVehicles.CurrentRow.Cells("dgvVehicles_installation_date").Value, Date)
            dtpExpirationDate.Value = DirectCast(dgvVehicles.CurrentRow.Cells("dgvVehicles_expiration_date").Value, Date)

            cboDevice.DataSource = Nothing
            cboDevice.Items.Clear()
            cboDevice.Items.Add(dgvVehicles.CurrentRow.Cells("dgvVehicles_imei").Value)
            cboDevice.SelectedIndex = 0

            cboxVehicleStatus.Checked = If(dgvVehicles.CurrentRow.Cells("dgvVehicles_status").Value, True, False)
            txtVehicleObservations.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_observations").Value

            For Each ctl As Control In panelHeaderVehicles.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton AndAlso Not TypeOf ctl Is ZUControls.ZUDataGridView Then
                    ctl.Enabled = False
                End If
            Next

            btnNewVehicle.Enabled = True
            btnEditVehicle.Enabled = True
            btnSaveVehicle.Enabled = False
            btnDeleteVehicle.Enabled = True
            btnCancelClient.Enabled = True
        End If
    End Sub

    Private Sub btnMTransmitterUser_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMTransmitterUser.MouseDown
        If e.Button = MouseButtons.Left Then
            btnMTransmitterUser.BackgroundImage = My.Resources.user_icon_clicked
        End If
    End Sub

    Private Sub btnMTransmitterUser_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMTransmitterUser.MouseUp
        If e.Button = MouseButtons.Left Then
            btnMTransmitterUser.BackgroundImage = My.Resources.user_icon
        End If
    End Sub

    Private Sub btnMTransmitterClient_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMTransmitterClient.MouseDown
        If e.Button = MouseButtons.Left Then
            btnMTransmitterClient.BackgroundImage = My.Resources.clients_icon_clicked
        End If
    End Sub

    Private Sub btnMTransmitterClient_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMTransmitterClient.MouseUp
        If e.Button = MouseButtons.Left Then
            btnMTransmitterClient.BackgroundImage = My.Resources.clients_icon
        End If
    End Sub

    Private Sub btnMReceiverUser_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMReceiverUser.MouseDown
        If e.Button = MouseButtons.Left Then
            btnMReceiverUser.BackgroundImage = My.Resources.user_icon_clicked
        End If
    End Sub

    Private Sub btnMReceiverUser_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMReceiverUser.MouseUp
        If e.Button = MouseButtons.Left Then
            btnMReceiverUser.BackgroundImage = My.Resources.user_icon
        End If
    End Sub

    Private Sub btnMReceiverClient_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMReceiverClient.MouseDown
        If e.Button = MouseButtons.Left Then
            btnMReceiverClient.BackgroundImage = My.Resources.clients_icon_clicked
        End If
    End Sub

    Private Sub btnMReceiverClient_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMReceiverClient.MouseUp
        If e.Button = MouseButtons.Left Then
            btnMReceiverClient.BackgroundImage = My.Resources.clients_icon
        End If
    End Sub

    Private Sub rbtnInsertReports_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnInsertReports.CheckedChanged
        gboxInsertReport.Enabled = rbtnInsertReports.Checked
        If rbtnInsertReports.Checked Then dgvReports.Rows.Clear()
    End Sub

    Private Sub rbtnSearchReports_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSearchReports.CheckedChanged
        gboxSearchReports.Enabled = rbtnSearchReports.Checked
    End Sub

    Private Sub cboxFReportType_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFReportType.CheckedChanged
        cboFReportType.Enabled = cboxFReportType.Checked
        cboFReportType.SelectedIndex = -1
    End Sub

    Private Sub cboxFUser_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFUser.CheckedChanged
        cboFUser.Enabled = cboxFUser.Checked
        cboFUser.SelectedIndex = -1
    End Sub

    Private Sub rbtnFByMonth_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFByMonth.CheckedChanged
        dtpFByMonth.Enabled = rbtnFByMonth.Checked
        dtpFByMonth.Value = Date.Parse("01/" & Now.Month.ToString("00") & "/" & Now.Year.ToString("0000"))
    End Sub

    Private Sub rbtnFByYear_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFByYear.CheckedChanged
        dtpFByYear.Enabled = rbtnFByYear.Checked
        dtpFByYear.Value = Now
    End Sub

    Private Sub rbtnFByRange_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFByRange.CheckedChanged
        dtpFRangeFrom.Enabled = rbtnFByRange.Checked
        dtpFRangeTo.Enabled = rbtnFByRange.Checked

        dtpFRangeFrom.Value = Now
        dtpFRangeTo.Value = Now
    End Sub

    Private Sub bgwFiller_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwFiller.DoWork
        Try
            Dim proc As New Procedure

            dtReportTypes = New DataTable("dtReportTypes")
            dtVehicles = New DataTable("dtVehicles")
            dtPhoneNumbers = New DataTable("dtPhoneNumbers")
            dtUsers = New DataTable("dtUsers")

            Dim col1 As New DataColumn("report_type_id")
            Dim col2 As New DataColumn("report_name")
            Dim col3 As New DataColumn("phone_number_id")
            Dim col4 As New DataColumn("phone_number")
            Dim col5 As New DataColumn("user_id")
            Dim col6 As New DataColumn("user_name")
            Dim col7 As New DataColumn("vehicle_id")
            Dim col8 As New DataColumn("license_plate")

            dtReportTypes.Columns.Add(col1)
            dtReportTypes.Columns.Add(col2)
            dtPhoneNumbers.Columns.Add(col3)
            dtPhoneNumbers.Columns.Add(col4)
            dtUsers.Columns.Add(col5)
            dtUsers.Columns.Add(col6)
            dtVehicles.Columns.Add(col7)
            dtVehicles.Columns.Add(col8)

            Dim row As DataRow

            If proc.GetData("clients_misc") Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                        row = dtReportTypes.NewRow()
                        row.Item("report_type_id") = If(row2("report_type_id") Is DBNull.Value, 0, row2("report_type_id"))
                        row.Item("report_name") = If(row2("report_name") Is DBNull.Value, "", row2("report_name"))
                        dtReportTypes.Rows.Add(row)
                    Next
                End If

                If proc.Ds.Tables(1).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(1).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(1).Rows(i)
                        row = dtPhoneNumbers.NewRow()
                        row.Item("phone_number_id") = If(row2("phone_number_id") Is DBNull.Value, 0, row2("phone_number_id"))
                        row.Item("phone_number") = If(row2("phone_number") Is DBNull.Value, 0, row2("phone_number"))
                        dtPhoneNumbers.Rows.Add(row)
                    Next
                End If

                If proc.Ds.Tables(2).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(2).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(2).Rows(i)
                        row = dtUsers.NewRow()
                        row.Item("user_id") = If(row2("user_id") Is DBNull.Value, 0, row2("user_id"))
                        row.Item("user_name") = (If(row2("first_name") Is DBNull.Value, "", row2("first_name")) & " " & If(row2("last_name") Is DBNull.Value, "", row2("last_name"))).ToString().Trim
                        dtUsers.Rows.Add(row)
                    Next
                End If

                cboMReportType.DataSource = dtReportTypes
                cboMReportType.ValueMember = "report_type_id"
                cboMReportType.DisplayMember = "report_name"
                cboMReportType.SelectedIndex = -1

                cboFReportType.DataSource = dtReportTypes
                cboFReportType.ValueMember = "report_type_id"
                cboFReportType.DisplayMember = "report_name"
                cboFReportType.SelectedIndex = -1

                cboFUser.DataSource = dtUsers
                cboFUser.ValueMember = "user_id"
                cboFUser.DisplayMember = "user_name"
                cboFUser.SelectedIndex = -1
            End If

            If dgvVehicles.Rows.Count > 0 Then
                For i = 0 To dgvVehicles.Rows.Count - 1
                    Dim row2 As DataRow = dtVehicles.NewRow
                    row2.Item("vehicle_id") = dgvVehicles.Rows(i).Cells("dgvVehicles_vehicle_id").Value
                    row2.Item("license_plate") = dgvVehicles.Rows(i).Cells("dgvVehicles_license_plate").Value
                    dtVehicles.Rows.Add(row2)
                Next
            End If

            cboMVehicle.DataSource = dtVehicles
            cboMVehicle.ValueMember = "vehicle_id"
            cboMVehicle.DisplayMember = "license_plate"
            cboMVehicle.SelectedIndex = -1

            cboFVehicle.DataSource = dtVehicles
            cboFVehicle.ValueMember = "vehicle_id"
            cboFVehicle.DisplayMember = "license_plate"
            cboFVehicle.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboMReportType_Enter(sender As Object, e As EventArgs)
        cboMReportType.DataSource = dtReportTypes
        cboMReportType.DisplayMember = "report_name"
        cboMReportType.ValueMember = "report_type_id"
        cboMReportType.SelectedIndex = -1
    End Sub

    Private Sub cboFReportType_Enter(sender As Object, e As EventArgs)
        cboFReportType.DataSource = dtReportTypes
        cboFReportType.DisplayMember = "report_name"
        cboFReportType.ValueMember = "report_type_id"
        cboFReportType.SelectedIndex = -1
    End Sub

    Private Sub cboFUser_Enter(sender As Object, e As EventArgs)
        cboFUser.DataSource = dtUsers
        cboFUser.DisplayMember = "user_name"
        cboFUser.ValueMember = "user_id"
        cboFUser.SelectedIndex = -1
    End Sub

    Private Sub cboMVehicle_Enter(sender As Object, e As EventArgs)
        Dim dt As New DataTable("")
        Dim col1 As New DataColumn("value")
        Dim col2 As New DataColumn("display")
        dt.Columns.Add(col1)
        dt.Columns.Add(col2)

        If dgvVehicles.Rows.Count > 0 Then
            For i = 0 To dgvVehicles.Rows.Count - 1
                Dim row As DataRow = dt.NewRow
                row.Item("value") = dgvVehicles.Rows(i).Cells("dgvVehicles_vehicle_id").Value
                row.Item("display") = dgvVehicles.Rows(i).Cells("dgvVehicles_license_plate").Value
                dt.Rows.Add(row)
            Next
        End If

        cboMVehicle.DataSource = dt
        cboMVehicle.ValueMember = "value"
        cboMVehicle.DisplayMember = "display"
        cboMVehicle.SelectedIndex = -1
    End Sub

    Private Sub btnMTransmitterUser_Click(sender As Object, e As EventArgs) Handles btnMTransmitterUser.Click
        Dim c As Integer = dtPhoneNumbers.Rows.Count - 1

        For i = 0 To c
            If txtMTransmitter.Text.Trim = "" Then
                txtMTransmitter.Text = dtPhoneNumbers.Rows(0)("phone_number")
                Exit Sub
            Else
                If txtMTransmitter.Text.Trim = dtPhoneNumbers.Rows(i)("phone_number") Then
                    txtMTransmitter.Text = dtPhoneNumbers.Rows(If(i < c, i + 1, 0))("phone_number")
                    Exit Sub
                End If
            End If
        Next

        Try
            txtMTransmitter.Text = dtPhoneNumbers.Rows(0)("phone_number")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnMReceiverUser_Click(sender As Object, e As EventArgs) Handles btnMReceiverUser.Click
        Dim c As Integer = dtPhoneNumbers.Rows.Count - 1

        For i = 0 To c
            If txtMReceiver.Text.Trim = "" Then
                txtMReceiver.Text = dtPhoneNumbers.Rows(0)("phone_number")
                Exit Sub
            Else
                If txtMReceiver.Text.Trim = dtPhoneNumbers.Rows(i)("phone_number") Then
                    txtMReceiver.Text = dtPhoneNumbers.Rows(If(i < c, i + 1, 0))("phone_number")
                    Exit Sub
                End If
            End If
        Next

        Try
            txtMReceiver.Text = dtPhoneNumbers.Rows(0)("phone_number")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnMTransmitterClient_Click(sender As Object, e As EventArgs) Handles btnMTransmitterClient.Click
        Dim dt As New DataTable("")
        Dim col1 As New DataColumn("phone")
        dt.Columns.Add(col1)

        If Not txtPhoneNumber1.Text.Trim = "" Then
            Dim row As DataRow = dt.NewRow()
            row.Item("phone") = txtPhoneNumber1.Text.Trim
            dt.Rows.Add(row)
        End If

        If Not txtPhoneNumber2.Text.Trim = "" Then
            Dim row As DataRow = dt.NewRow()
            row.Item("phone") = txtPhoneNumber2.Text.Trim
            dt.Rows.Add(row)
        End If

        If dgvContacts.Rows.Count > 0 Then
            For i = 0 To dgvContacts.Rows.Count - 1
                If Not dgvContacts.Rows(i).Cells("dgvContacts_phone_number1").Value = Nothing Then
                    Dim row As DataRow = dt.NewRow
                    row.Item("phone") = dgvContacts.Rows(i).Cells("dgvContacts_phone_number1").Value
                    dt.Rows.Add(row)
                End If

                If Not dgvContacts.Rows(i).Cells("dgvContacts_phone_number2").Value = Nothing Then
                    Dim row As DataRow = dt.NewRow
                    row.Item("phone") = dgvContacts.Rows(i).Cells("dgvContacts_phone_number2").Value
                    dt.Rows.Add(row)
                End If
            Next
        End If

        Dim c As Integer = dt.Rows.Count - 1

        For i = 0 To c
            If txtMTransmitter.Text.Trim = "" Then
                txtMTransmitter.Text = dt.Rows(0)("phone")
                Exit Sub
            Else
                If txtMTransmitter.Text.Trim = dt.Rows(i)("phone") Then
                    txtMTransmitter.Text = dt.Rows(If(i < c, i + 1, 0))("phone")
                    Exit Sub
                End If
            End If
        Next

        txtMTransmitter.Text = dt.Rows(0)("phone")
    End Sub

    Private Sub btnMReceiverClient_Click(sender As Object, e As EventArgs) Handles btnMReceiverClient.Click
        Dim dt As New DataTable("")
        Dim col1 As New DataColumn("phone")
        dt.Columns.Add(col1)

        If Not txtPhoneNumber1.Text.Trim = "" Then
            Dim row As DataRow = dt.NewRow()
            row.Item("phone") = txtPhoneNumber1.Text.Trim
            dt.Rows.Add(row)
        End If

        If Not txtPhoneNumber2.Text.Trim = "" Then
            Dim row As DataRow = dt.NewRow()
            row.Item("phone") = txtPhoneNumber2.Text.Trim
            dt.Rows.Add(row)
        End If

        If dgvContacts.Rows.Count > 0 Then
            For i = 0 To dgvContacts.Rows.Count - 1
                If Not dgvContacts.Rows(i).Cells("dgvContacts_phone_number1").Value = Nothing Then
                    Dim row As DataRow = dt.NewRow
                    row.Item("phone") = dgvContacts.Rows(i).Cells("dgvContacts_phone_number1").Value
                    dt.Rows.Add(row)
                End If

                If Not dgvContacts.Rows(i).Cells("dgvContacts_phone_number2").Value = Nothing Then
                    Dim row As DataRow = dt.NewRow
                    row.Item("phone") = dgvContacts.Rows(i).Cells("dgvContacts_phone_number2").Value
                    dt.Rows.Add(row)
                End If
            Next
        End If

        Dim c As Integer = dt.Rows.Count - 1

        For i = 0 To c
            If txtMReceiver.Text.Trim = "" Then
                txtMReceiver.Text = dt.Rows(0)("phone")
                Exit Sub
            Else
                If txtMReceiver.Text.Trim = dt.Rows(i)("phone") Then
                    txtMReceiver.Text = dt.Rows(If(i < c, i + 1, 0))("phone")
                    Exit Sub
                End If
            End If
        Next

        txtMReceiver.Text = dt.Rows(0)("phone")
    End Sub

    Private Sub cboxGeneralReport_CheckedChanged(sender As Object, e As EventArgs) Handles cboxGeneralReport.CheckedChanged
        cboMVehicle.Enabled = Not cboxGeneralReport.Checked
        cboMVehicle.DataSource = Nothing
    End Sub

    Private Sub numValidation_ValueChanged(sender As Object, e As EventArgs) Handles numValidation.ValueChanged
        If numValidation.Value = 0 Then
            cboMValidation.SelectedIndex = -1
            cboMValidation.Enabled = False
        Else
            cboMValidation.Enabled = True
        End If
    End Sub

    Private Sub btnMInsertReport_Click(sender As Object, e As EventArgs) Handles btnMInsertReport.Click
        If cboMReportType.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un tipo de reporte", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboMReportType.Focus()
            Exit Sub
        End If

        If Not cboxGeneralReport.Checked Then
            If cboMVehicle.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboMVehicle.Focus()
                Exit Sub
            End If
        End If

        If cboCommunicationMode.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el modo de comunicación con el cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboCommunicationMode.Focus()
            Exit Sub
        End If

        If numValidation.Value > 0 Then
            If cboMValidation.SelectedIndex = -1 Then
                MsgBox("Debe indicar el tipo de intervalo para el tiempo de validación", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboMValidation.Focus()
                Exit Sub
            End If
        End If

        If cboCommunicationMode.SelectedIndex >= 0 AndAlso cboCommunicationMode.SelectedIndex <= 2 Then
            If txtMTransmitter.Text.Trim = "" Then
                MsgBox("Debe indicar el número o correo del remitente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                txtMTransmitter.Focus()
                Exit Sub
            End If

            If txtMReceiver.Text.Trim = "" Then
                MsgBox("Debe indicar el número o correo del recipiente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                txtMReceiver.Focus()
                Exit Sub
            End If
        End If

        If txtMDescription.Text.Trim = "" Then
            MsgBox("Debe indicar la descripción del reporte", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtMDescription.Focus()
            Exit Sub
        End If

        If MsgBox("¿Confirma que desea ingresar este reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Try
                'bgwSavingReports.ReportProgress(1)

                Dim validation As Date = Now

                If cboMReportType.SelectedValue = 2 Then
                    If numValidation.Value > 0 Then
                        Select Case cboMValidation.SelectedIndex
                            Case 0
                                validation = validation.AddMinutes(numValidation.Value)
                                Exit Select
                            Case 1
                                validation = validation.AddHours(numValidation.Value)
                                Exit Select
                            Case 2
                                validation = validation.AddDays(numValidation.Value)
                                Exit Select
                            Case 3
                                validation = validation.AddMonths(numValidation.Value)
                                Exit Select
                            Case 4
                                validation = validation.AddYears(numValidation.Value)
                                Exit Select
                        End Select
                    End If

                Else
                    If cboMReportType.SelectedValue = 3 Then ' excesos de velocidad
                        validation = validation.AddHours(2)
                    ElseIf cboMReportType.SelectedValue = 8 Then ' geocercas
                        validation = validation.AddHours(1)
                    End If
                End If

                Dim proc As New Procedure

                If proc.GetData("reports_insert",
                                            currentClient.Id,
                                            If(cboxGeneralReport.Checked, Nothing, cboMVehicle.SelectedValue),
                                            cboMReportType.SelectedValue,
                                            My.Settings.curUserId,
                                            cboCommunicationMode.Text,
                                            If(cboCommunicationMode.SelectedIndex < 3, txtMTransmitter.Text.Trim, Nothing),
                                            If(cboCommunicationMode.SelectedIndex < 3, txtMReceiver.Text.Trim, Nothing),
                                            txtMDescription.Text.Trim,
                                            Now,
                                            validation) Then

                    Dim dataReport(3) As Object
                    dataReport(0) = cboMVehicle.Text
                    dataReport(1) = cboMReportType.SelectedValue
                    dataReport(2) = validation

                    Dim count As Integer = FrmMain.dgvEvents.Rows.Count

                    If cboMVehicle.Text <> "" Then

                        DrawingControl.SuspendDrawing(DirectCast(main, FrmMain).dgvEvents)
                        For i = 0 To DirectCast(main, FrmMain).dgvEvents.Rows.Count - 1
                            With DirectCast(main, FrmMain).dgvEvents
                                If Not TypeOf .Rows(i).Cells("dgvEvents_report_type_id").Value Is DBNull Then
                                    If .Rows(i).Cells("dgvEvents_license_plate").Value = cboMVehicle.Text AndAlso
                                        .Rows(i).Cells("dgvEvents_report_type_id").Value = cboMReportType.SelectedValue Then

                                        .Rows(i).Cells("dgvEvents_validation").Value = validation.ToString("dd/MM/yyyy hh:mm:ss tt")
                                    End If
                                End If
                            End With
                        Next
                        DirectCast(main, FrmMain).dgvEvents.Refresh()
                        DrawingControl.ResumeDrawing(DirectCast(main, FrmMain).dgvEvents)
                    End If

                    bgwSavingReports.ReportProgress(2)
                Else
                    bgwSavingReports.ReportProgress(3, proc.ErrorMsg)
                End If
            Catch ex As Exception
                bgwSavingReports.ReportProgress(3, ex.Message)
            End Try

            'If Not bgwSavingReports.IsBusy Then
            '    bgwSavingReports.RunWorkerAsync()
            'End If
        End If

    End Sub

    Private Sub cboCommunicationMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCommunicationMode.SelectedIndexChanged
        btnMTransmitterUser.Enabled = (cboCommunicationMode.SelectedIndex > -1 And cboCommunicationMode.SelectedIndex < 2)
        btnMTransmitterClient.Enabled = (cboCommunicationMode.SelectedIndex > -1 And cboCommunicationMode.SelectedIndex < 2)
        btnMReceiverUser.Enabled = (cboCommunicationMode.SelectedIndex > -1 And cboCommunicationMode.SelectedIndex < 2)
        btnMReceiverClient.Enabled = (cboCommunicationMode.SelectedIndex > -1 And cboCommunicationMode.SelectedIndex < 2)

        txtMTransmitter.Text = ""
        txtMReceiver.Text = ""

        txtMTransmitter.Enabled = (cboCommunicationMode.SelectedIndex > -1 And cboCommunicationMode.SelectedIndex < 3)
        txtMReceiver.Enabled = (cboCommunicationMode.SelectedIndex > -1 And cboCommunicationMode.SelectedIndex < 3)
    End Sub

    Private Sub bgwSavingReports_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSavingReports.DoWork
        Try
            bgwSavingReports.ReportProgress(1)

            Dim validation As Date = Now

            If cboMReportType.SelectedValue = 2 Then
                If numValidation.Value > 0 Then
                    Select Case cboMValidation.SelectedIndex
                        Case 0
                            validation = validation.AddMinutes(numValidation.Value)
                            Exit Select
                        Case 1
                            validation = validation.AddHours(numValidation.Value)
                            Exit Select
                        Case 2
                            validation = validation.AddDays(numValidation.Value)
                            Exit Select
                        Case 3
                            validation = validation.AddMonths(numValidation.Value)
                            Exit Select
                        Case 4
                            validation = validation.AddYears(numValidation.Value)
                            Exit Select
                    End Select
                End If

            Else
                If cboMReportType.SelectedValue = 3 Then ' excesos de velocidad
                    validation = validation.AddHours(2)
                ElseIf cboMReportType.SelectedValue = 8 Then ' geocercas
                    validation = validation.AddHours(1)
                End If
            End If

            Dim proc As New Procedure

            If proc.GetData("reports_insert",
                                            currentClient.Id,
                                            If(cboxGeneralReport.Checked, Nothing, cboMVehicle.SelectedValue),
                                            cboMReportType.SelectedValue,
                                            My.Settings.curUserId,
                                            cboCommunicationMode.Text,
                                            If(cboCommunicationMode.SelectedIndex < 3, txtMTransmitter.Text.Trim, Nothing),
                                            If(cboCommunicationMode.SelectedIndex < 3, txtMReceiver.Text.Trim, Nothing),
                                            txtMDescription.Text.Trim,
                                            Now,
                                            validation) Then

                Dim dataReport(3) As Object
                dataReport(0) = cboMVehicle.Text
                dataReport(1) = cboMReportType.SelectedValue
                dataReport(2) = validation

                bgwSavingReports.ReportProgress(2, dataReport)
            Else
                bgwSavingReports.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwSavingReports.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingReports_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSavingReports.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                gboxInsertReport.Enabled = False
                rbtnInsertReports.Enabled = False
                rbtnSearchReports.Enabled = False
                dgvReports.Enabled = False
                lblLoadingReports.Text = "Guardando reporte... Por favor espere"
                panelLoadingReports.Visible = True
                Exit Select
            Case 2
                gboxInsertReport.Enabled = True
                rbtnInsertReports.Enabled = True
                rbtnSearchReports.Enabled = True
                dgvReports.Enabled = True
                panelLoadingReports.Visible = False

                MsgBox("Reporte ingresado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")

                For Each ctl As Control In gboxInsertReport.Controls
                    If TypeOf ctl Is ZUControls.ZUComboBox Then
                        DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
                    End If

                    If TypeOf ctl Is ZUControls.ZUTextBox Then
                        ctl.Text = ""
                    End If
                Next

                numValidation.Value = 0
                cboxGeneralReport.Checked = False

                'Dim data() As Object = DirectCast(e.UserState, Object())

                'If data(0) <> "" Then
                'DirectCast(main, FrmMain).dgvEvents.ScrollBars = ScrollBars.None
                'DrawingControl.SuspendDrawing(DirectCast(main, FrmMain).dgvEvents)
                'DirectCast(main, FrmMain).updateValidationEvents(data(0), data(1), data(2))

                'For Each frm As Form In Application.OpenForms
                '    If TypeOf frm Is frmMain Then
                '        If Not DirectCast(frm, frmMain).bgwGetEvents.IsBusy Then
                '            DirectCast(frm, frmMain).bgwGetEvents.RunWorkerAsync()
                '        End If
                '        Exit For
                '    End If
                'Next

                'For Each row As DataGridViewRow In DirectCast(main, FrmMain).dgvEvents.Rows
                '    If Not TypeOf row.Cells("dgvEvents_report_type_id").Value Is DBNull Then
                '        If row.Cells("dgvEvents_license_plate").Value = data(0) AndAlso
                '            row.Cells("dgvEvents_report_type_id").Value = data(1) Then

                '            row.Cells("dgvEvents_validation").Value = data(2)
                '        End If
                '    End If
                'Next

                'DrawingControl.ResumeDrawing(DirectCast(main, FrmMain).dgvEvents)
                'End If

                Exit Select
            Case 3
                gboxInsertReport.Enabled = True
                rbtnInsertReports.Enabled = True
                rbtnSearchReports.Enabled = True
                dgvReports.Enabled = True
                panelLoadingReports.Visible = False

                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwSearchingReports_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSearchingReports.DoWork
        Try
            bgwSearchingReports.ReportProgress(1)

            Dim query As String = "SELECT * FROM reports AS r " &
                                  "LEFT JOIN clients AS c ON r.client_id = c.client_id " &
                                  "LEFT JOIN vehicles AS v ON r.vehicle_id = v.vehicle_id " &
                                  "LEFT JOIN report_types AS t ON r.report_type_id = t.report_type_id " &
                                  "LEFT JOIN users AS u ON r.user_id = u.user_id " &
                                  "WHERE r.client_id = [client_id]"

            If e.Argument.ToString() = "1" Then
                If cboxFReportType.Checked Then
                    If cboFReportType.SelectedIndex = -1 Then
                        MsgBox("Debe seleccionar un tipo de reporte", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        bgwSearchingReports.ReportProgress(2)
                        Exit Sub
                    Else
                        query = query & " AND r.report_type_id = [report_type_id]"
                    End If
                End If

                If cboxFUser.Checked Then
                    If cboFUser.SelectedIndex = -1 Then
                        MsgBox("Debe seleccionar un usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        bgwSearchingReports.ReportProgress(2)
                        Exit Sub
                    Else
                        query = query & " AND r.user_id = [user_id]"
                    End If
                End If

                If cboxFVehicle.Checked Then
                    If cboFVehicle.SelectedIndex = -1 Then
                        MsgBox("Debe seleccionar un vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        bgwSearchingReports.ReportProgress(2)
                        Exit Sub
                    Else
                        query = query & " AND v.vehicle_id = [vehicle_id]"
                    End If
                End If

                If rbtnFToday.Checked Then
                    query = query & " AND DATE(r.date_time) = CURDATE()"
                End If

                If rbtnFByMonth.Checked Then
                    query = query & " AND MONTH(r.date_time) = [month] AND YEAR(r.date_time) = [year]"
                End If

                If rbtnFByYear.Checked Then
                    query = query & " AND YEAR(r.date_time) = [year]"
                End If

                If rbtnFByRange.Checked Then
                    If dtpFRangeFrom.Value > dtpFRangeTo.Value Then
                        MsgBox("La fecha de inicio debe ser menor que la de fin", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        bgwSearchingReports.ReportProgress(2)
                        Exit Sub
                    Else
                        query = query & " AND DATE(r.date_time) BETWEEN '[date_from]' AND '[date_to]'"
                    End If
                End If

                query = query & " ORDER BY r.date_time DESC;"

                If query.Contains("[client_id]") Then
                    query = query.Replace("[client_id]", CInt(currentClient.Id))
                End If

                If query.Contains("[report_type_id]") Then
                    query = query.Replace("[report_type_id]", CInt(cboFReportType.SelectedValue))
                End If

                If query.Contains("[user_id]") Then
                    query = query.Replace("[user_id]", CInt(cboFUser.SelectedValue))
                End If

                If query.Contains("[vehicle_id]") Then
                    query = query.Replace("[vehicle_id]", CInt(cboFVehicle.SelectedValue))
                End If

                If query.Contains("[year]") Then
                    If query.Contains("[month]") Then
                        query = query.Replace("[month]", dtpFByMonth.Value.Month)
                        query = query.Replace("[year]", dtpFByMonth.Value.Year)
                    Else
                        query = query.Replace("[year]", dtpFByYear.Value.Year)
                    End If
                End If

                If query.Contains("[date_from]") Then
                    query = query.Replace("[date_from]", dtpFRangeFrom.Value.ToString("yyyy-MM-dd"))
                    query = query.Replace("[date_to]", dtpFRangeTo.Value.ToString("yyyy-MM-dd"))
                End If
            Else
                query = query & " ORDER BY r.date_time DESC LIMIT 10;"

                If query.Contains("[client_id]") Then
                    query = query.Replace("[client_id]", CInt(currentClient.Id))
                End If
            End If

            Dim proc As New Procedure

            If proc.GetData("global_procedure", query) Then
                bgwSearchingReports.ReportProgress(3, proc.Ds.Tables(0))
            Else
                bgwSearchingReports.ReportProgress(4, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwSearchingReports.ReportProgress(4, ex.Message)
        End Try
    End Sub

    Private Sub bgwSearchingReports_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSearchingReports.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                rbtnInsertReports.Enabled = False
                rbtnSearchReports.Enabled = False
                gboxSearchReports.Enabled = False
                lblLoadingReports.Text = "Buscando reportes... Por favor espere"
                panelLoadingReports.Visible = True
                Exit Select
            Case 2
                rbtnInsertReports.Enabled = True
                rbtnSearchReports.Enabled = True
                gboxSearchReports.Enabled = True
                panelLoadingReports.Visible = False
                Exit Select
            Case 3
                dgvReports.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)

                        dgvReports.Rows.Add()
                        dgvReports.Rows(i).Cells("dgvReports_date_time").Value = If(row("date_time") Is DBNull.Value, Now, DirectCast(row("date_time"), Date))
                        dgvReports.Rows(i).Cells("dgvReports_report_name").Value = If(row("report_name") Is DBNull.Value, "", row("report_name"))
                        dgvReports.Rows(i).Cells("dgvReports_description").Value = If(row("description") Is DBNull.Value, "", row("description"))
                        dgvReports.Rows(i).Cells("dgvReports_license_plate").Value = If(row("license_plate") Is DBNull.Value, "", row("license_plate"))
                        dgvReports.Rows(i).Cells("dgvReports_user_name").Value = (If(row("first_name1") Is DBNull.Value, "", row("first_name1")) & " " & If(row("last_name1") Is DBNull.Value, "", row("last_name1"))).ToString().Trim
                        dgvReports.Rows(i).Cells("dgvReports_communication_mode").Value = If(row("communication_mode") Is DBNull.Value, "", row("communication_mode"))
                        dgvReports.Rows(i).Cells("dgvReports_transmitter").Value = If(row("transmitter") Is DBNull.Value, "", row("transmitter"))
                        dgvReports.Rows(i).Cells("dgvReports_receiver").Value = If(row("receiver") Is DBNull.Value, "", row("receiver"))
                        dgvReports.Rows(i).Cells("dgvReports_report_id").Value = If(row("report_id") Is DBNull.Value, 0, row("report_id"))
                        dgvReports.Rows(i).Cells("dgvReports_report_type_id").Value = If(row("report_type_id") Is DBNull.Value, 0, row("report_type_id"))
                        dgvReports.Rows(i).Cells("dgvReports_vehicle_id").Value = If(row("vehicle_id") Is DBNull.Value, 0, row("vehicle_id"))
                        dgvReports.Rows(i).Cells("dgvReports_user_id").Value = If(row("user_id") Is DBNull.Value, 0, row("user_id"))
                    Next
                End If

                rbtnInsertReports.Enabled = True
                rbtnSearchReports.Enabled = True
                gboxSearchReports.Enabled = True
                panelLoadingReports.Visible = False
                Exit Select
            Case 4
                rbtnInsertReports.Enabled = True
                rbtnSearchReports.Enabled = True
                gboxSearchReports.Enabled = True
                panelLoadingReports.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnFLastTen_Click(sender As Object, e As EventArgs) Handles btnFLastTen.Click
        If Not bgwSearchingReports.IsBusy Then
            bgwSearchingReports.RunWorkerAsync(2)
        End If
    End Sub

    Private Sub btnFSearch_Click(sender As Object, e As EventArgs) Handles btnFSearch.Click
        If Not bgwSearchingReports.IsBusy Then
            bgwSearchingReports.RunWorkerAsync(1)
        End If
    End Sub

    Private Sub cboDni_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDni.KeyDown
        If e.KeyCode = Keys.Enter Then
            getClientsByDni()
        End If
    End Sub

    Private Sub getClientsByDni()
        If txtDni.Text.Trim = "" Then
            MsgBox("Debe indicar la cédula o rif", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDni.Focus()
            Exit Sub
        End If

        If Not bgwGetClientByDni.IsBusy Then
            dgvContacts.ScrollBars = ScrollBars.None
            dgvVehicles.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvContacts)
            DrawingControl.SuspendDrawing(dgvVehicles)
            bgwGetClientByDni.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwGetClientById_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetClientById.DoWork
        Try
            dgvContacts.ScrollBars = ScrollBars.None
            dgvVehicles.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvContacts)
            DrawingControl.SuspendDrawing(dgvVehicles)
            Dim proc As New Procedure
            Dim enc As New Encryptation

            If proc.GetData("clients_getDni", isFromClientId) Then
                bgwGetClientById.ReportProgress(1, proc.Ds.Tables(0).Rows(0)(0))
            Else
                bgwGetClientById.ReportProgress(2, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetClientById.ReportProgress(2, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetClientById_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetClientById.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                txtDni.Text = e.UserState.ToString()
                getClientsByDni()
                Exit Select
            Case 2
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwGetClientById_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetClientById.RunWorkerCompleted
        dgvContacts.ScrollBars = ScrollBars.Both
        dgvVehicles.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvContacts)
        DrawingControl.ResumeDrawing(dgvVehicles)
    End Sub

    Private Sub bgwGetContacts_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetContacts.RunWorkerCompleted
        dgvContacts.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvContacts)
    End Sub

    Private Sub bgwGetClientByDni_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetClientByDni.RunWorkerCompleted
        dgvContacts.ScrollBars = ScrollBars.Both
        dgvVehicles.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvContacts)
        DrawingControl.ResumeDrawing(dgvVehicles)

        If Not bgwSearchingReports.IsBusy Then
            bgwSearchingReports.RunWorkerAsync(2)
        End If

        bgwFiller.RunWorkerAsync()

    End Sub

    Private Sub cboMReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMReportType.SelectedIndexChanged
        Try
            If cboMReportType.SelectedValue = 2 Then
                numValidation.Enabled = True
                cboMValidation.Enabled = True
            Else
                numValidation.Value = 0
                numValidation.Enabled = False
                cboMValidation.SelectedIndex = -1
                cboMValidation.Enabled = False
            End If
        Catch ex As Exception
            numValidation.Value = 0
            numValidation.Enabled = False
            cboMValidation.SelectedIndex = -1
            cboMValidation.Enabled = False
        End Try
    End Sub

    Private Sub dgvVehicles_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvVehicles.KeyUp
        If e.KeyCode = Keys.Down Then
            Dim enc As New Encryptation
            txtLicensePlate.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_license_plate").Value
            txtBrand.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_brand").Value
            txtModel.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_model").Value
            txtType.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_type").Value
            txtYear.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_year").Value
            txtColor.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_color").Value
            txtSpeedLimit.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_speed_limit").Value

            cboDealer.DataSource = Nothing
            cboDealer.Items.Clear()
            cboDealer.Items.Add(dgvVehicles.CurrentRow.Cells("dgvVehicles_dealer_name").Value)
            cboDealer.SelectedIndex = 0

            txtCallPass.Text = If(dgvVehicles.CurrentRow.Cells("dgvVehicles_phone_pass").Value = "", "", enc.Decrypt(dgvVehicles.CurrentRow.Cells("dgvVehicles_phone_pass").Value))
            dtpInstallationDate.Value = DirectCast(dgvVehicles.CurrentRow.Cells("dgvVehicles_installation_date").Value, Date)
            dtpExpirationDate.Value = DirectCast(dgvVehicles.CurrentRow.Cells("dgvVehicles_expiration_date").Value, Date)

            cboDevice.DataSource = Nothing
            cboDevice.Items.Clear()
            cboDevice.Items.Add(dgvVehicles.CurrentRow.Cells("dgvVehicles_imei").Value)
            cboDevice.SelectedIndex = 0

            cboxVehicleStatus.Checked = If(dgvVehicles.CurrentRow.Cells("dgvVehicles_status").Value, True, False)
            txtVehicleObservations.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_observations").Value

            For Each ctl As Control In panelHeaderVehicles.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton AndAlso Not TypeOf ctl Is ZUControls.ZUDataGridView Then
                    ctl.Enabled = False
                End If
            Next

            btnNewVehicle.Enabled = True
            btnEditVehicle.Enabled = True
            btnSaveVehicle.Enabled = False
            btnDeleteVehicle.Enabled = True
            btnCancelClient.Enabled = True
        End If

        If e.KeyCode = Keys.Up Then
            Dim enc As New Encryptation
            txtLicensePlate.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_license_plate").Value
            txtBrand.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_brand").Value
            txtModel.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_model").Value
            txtType.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_type").Value
            txtYear.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_year").Value
            txtColor.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_color").Value
            txtSpeedLimit.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_speed_limit").Value

            cboDealer.DataSource = Nothing
            cboDealer.Items.Clear()
            cboDealer.Items.Add(dgvVehicles.CurrentRow.Cells("dgvVehicles_dealer_name").Value)
            cboDealer.SelectedIndex = 0

            txtCallPass.Text = If(dgvVehicles.CurrentRow.Cells("dgvVehicles_phone_pass").Value = "", "", enc.Decrypt(dgvVehicles.CurrentRow.Cells("dgvVehicles_phone_pass").Value))
            dtpInstallationDate.Value = DirectCast(dgvVehicles.CurrentRow.Cells("dgvVehicles_installation_date").Value, Date)
            dtpExpirationDate.Value = DirectCast(dgvVehicles.CurrentRow.Cells("dgvVehicles_expiration_date").Value, Date)

            cboDevice.DataSource = Nothing
            cboDevice.Items.Clear()
            cboDevice.Items.Add(dgvVehicles.CurrentRow.Cells("dgvVehicles_imei").Value)
            cboDevice.SelectedIndex = 0

            cboxVehicleStatus.Checked = If(dgvVehicles.CurrentRow.Cells("dgvVehicles_status").Value, True, False)
            txtVehicleObservations.Text = dgvVehicles.CurrentRow.Cells("dgvVehicles_observations").Value

            For Each ctl As Control In panelHeaderVehicles.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton AndAlso Not TypeOf ctl Is ZUControls.ZUDataGridView Then
                    ctl.Enabled = False
                End If
            Next

            btnNewVehicle.Enabled = True
            btnEditVehicle.Enabled = True
            btnSaveVehicle.Enabled = False
            btnDeleteVehicle.Enabled = True
            btnCancelClient.Enabled = True
        End If
    End Sub

    Private Sub bgwFiller_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwFiller.RunWorkerCompleted
        If _report_type_id > 0 Then
            cboMReportType.SelectedValue = _report_type_id
            cboFReportType.SelectedIndex = -1
            cboMVehicle.SelectedValue = _vehicle_id
            cboFVehicle.SelectedIndex = -1

            cboMReportType.Enabled = False
            cboMVehicle.Enabled = False
        Else
            cboMReportType.Enabled = True
            cboMVehicle.Enabled = True
        End If

        panelReports.Enabled = True
    End Sub

    Private Sub cboxFVehicle_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFVehicle.CheckedChanged
        cboFVehicle.Enabled = cboxFVehicle.Checked
        cboFVehicle.SelectedIndex = -1
    End Sub
End Class