Imports System.ComponentModel
Imports System.IO

Public Class frmDealers

    Enum DealerMode
        Registering
        Editing
    End Enum

    Dim curDealerMode As DealerMode = DealerMode.Registering

    Private Sub funciones_Click(sender As Object, e As EventArgs) Handles btnBatteryAlert.Click,
                                                                          btnSpeedAlert.Click,
                                                                          btnGeofenceAlert.Click,
                                                                          btnIgnitionAlert.Click,
                                                                          btnMotionAlert.Click
        For Each ctl As Control In gboxGeneralData.Controls
            If TypeOf ctl Is ZUControls.ZUButton Then
                If ctl.Name.ToLower.Contains("alert") Then
                    If ctl.Name.Equals(DirectCast(sender, ZUControls.ZUButton).Name) Then
                        DirectCast(ctl, ZUControls.ZUButton).ButtonStyle = If(DirectCast(ctl, ZUControls.ZUButton).ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)
                        Exit For
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub getDealers()
        Try
            Dim proc As New Procedure

            If proc.GetData("dealers_getAll") Then
                Dim dealers As New List(Of Dealer)

                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)
                        dgvDealers.Rows.Add()
                        dgvDealers.Rows(i).Cells("dgvDealers_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvDealers.Rows(i).Cells("dgvDealers_name").Value = If(row("name") Is DBNull.Value, "", row("name"))
                        dgvDealers.Rows(i).Cells("dgvDealers_contact").Value = If(row("contact") Is DBNull.Value, "", row("contact"))
                        dgvDealers.Rows(i).Cells("dgvDealers_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvDealers.Rows(i).Cells("dgvDealers_phone_number2").Value = If(row("phone_number2") Is DBNull.Value, Nothing, row("phone_number2"))
                        dgvDealers.Rows(i).Cells("dgvDealers_address").Value = If(row("address") Is DBNull.Value, "", row("address"))
                        dgvDealers.Rows(i).Cells("dgvDealers_email").Value = If(row("email") Is DBNull.Value, "", row("email"))
                        dgvDealers.Rows(i).Cells("dgvDealers_web_site").Value = If(row("web_site") Is DBNull.Value, "", row("web_site"))
                        dgvDealers.Rows(i).Cells("dgvDealers_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvDealers.Rows(i).Cells("dgvDealers_battery_alert").Value = If(row("battery_alert") Is DBNull.Value, 0, row("battery_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_speed_alert").Value = If(row("speed_alert") Is DBNull.Value, 0, row("speed_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_geofence_alert").Value = If(row("geofence_alert") Is DBNull.Value, 0, row("geofence_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_ignition_alert").Value = If(row("ignition_alert") Is DBNull.Value, 0, row("ignition_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_motion_alert").Value = If(row("motion_alert") Is DBNull.Value, 0, row("motion_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_image").Value = If(row("image") Is DBNull.Value, "", row("image"))
                        dgvDealers.Rows(i).Cells("dgvDealers_dealer_id").Value = If(row("dealer_id") Is DBNull.Value, 0, row("dealer_id"))
                    Next
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            dgvDealers.ScrollBars = ScrollBars.Both
            DrawingControl.ResumeDrawing(dgvDealers)
        End Try
    End Sub

    Private Sub frmDealers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        dgvDealers.ScrollBars = ScrollBars.None
        DrawingControl.SuspendDrawing(dgvDealers)
        getDealers()
    End Sub

    Private Sub btnNewDealer_Click(sender As Object, e As EventArgs) Handles btnNewDealer.Click
        For Each ctl As Control In gboxGeneralData.Controls
            If TypeOf ctl Is ZUControls.ZUNumericBox Or TypeOf ctl Is ZUControls.ZUTextBox Then
                ctl.Text = ""
            End If

            If TypeOf ctl Is ZUControls.ZUButton Then
                If ctl.Name.ToLower.Contains("alert") Then
                    DirectCast(ctl, ZUControls.ZUButton).ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
                End If
            End If

            If Not ctl.Name.ToLower.Contains("remove") Then
                ctl.Enabled = True
            End If
        Next

        cboxStatus.Checked = False
        pboxLogo.Image = Nothing
        dgvDealers.Enabled = False

        btnNewDealer.Enabled = False
        btnEditDealer.Enabled = False
        btnSaveDealer.Enabled = True
        btnDeleteDealer.Enabled = False
        btnCancelDealer.Enabled = True

        curDealerMode = DealerMode.Registering
        txtDni.Focus()
    End Sub

    Private Sub btnCancelDealer_Click(sender As Object, e As EventArgs) Handles btnCancelDealer.Click
        For Each ctl As Control In gboxGeneralData.Controls
            If TypeOf ctl Is ZUControls.ZUNumericBox Or TypeOf ctl Is ZUControls.ZUTextBox Then
                ctl.Text = ""
                ctl.Enabled = False
            End If

            If TypeOf ctl Is ZUControls.ZUButton Then
                If ctl.Name.ToLower.Contains("alert") Then
                    DirectCast(ctl, ZUControls.ZUButton).ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleRed
                End If
                ctl.Enabled = False
            End If

            If TypeOf ctl Is PictureBox Then
                DirectCast(ctl, PictureBox).Image = Nothing
                ctl.Enabled = False
            End If
        Next

        cboxStatus.Checked = False
        cboxStatus.Enabled = False
        dgvDealers.Enabled = True

        btnNewDealer.Enabled = True
        btnEditDealer.Enabled = False
        btnSaveDealer.Enabled = False
        btnDeleteDealer.Enabled = False
        btnCancelDealer.Enabled = False
    End Sub

    Private Sub cboxStatus_CheckedChanged(sender As Object, e As EventArgs) Handles cboxStatus.CheckedChanged
        lblStatus.BackColor = If(cboxStatus.Checked, Color.LightGreen, Color.LightCoral)
    End Sub

    Private Sub btnEditDealer_Click(sender As Object, e As EventArgs) Handles btnEditDealer.Click
        For Each ctl As Control In gboxGeneralData.Controls
            ctl.Enabled = True
        Next

        btnAddImage.Enabled = pboxLogo.Image Is Nothing
        btnRemoveImage.Enabled = Not pboxLogo.Image Is Nothing

        dgvDealers.Enabled = False

        btnNewDealer.Enabled = False
        btnEditDealer.Enabled = False
        btnSaveDealer.Enabled = True
        btnDeleteDealer.Enabled = False
        btnCancelDealer.Enabled = True

        curDealerMode = DealerMode.Editing
        txtDni.Focus()
    End Sub

    Private Sub dgvDealers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDealers.CellClick
        Try
            If e.RowIndex >= 0 Then
                For Each ctl As Control In gboxGeneralData.Controls
                    ctl.Enabled = False
                Next

                txtDni.Text = dgvDealers.CurrentRow.Cells("dgvDealers_dni").Value
                txtName.Text = dgvDealers.CurrentRow.Cells("dgvDealers_name").Value
                txtContact.Text = dgvDealers.CurrentRow.Cells("dgvDealers_contact").Value
                txtPhoneNumber1.Text = dgvDealers.CurrentRow.Cells("dgvDealers_phone_number1").Value
                txtPhoneNumber2.Text = If(dgvDealers.CurrentRow.Cells("dgvDealers_phone_number2").Value = 0, "", dgvDealers.CurrentRow.Cells("dgvDealers_phone_number2").Value)
                txtAddress.Text = dgvDealers.CurrentRow.Cells("dgvDealers_address").Value
                txtEmail.Text = dgvDealers.CurrentRow.Cells("dgvDealers_email").Value
                txtWebSite.Text = dgvDealers.CurrentRow.Cells("dgvDealers_web_site").Value
                cboxStatus.Checked = If(dgvDealers.CurrentRow.Cells("dgvDealers_status").Value = 1, True, False)
                btnBatteryAlert.ButtonStyle = If(dgvDealers.CurrentRow.Cells("dgvDealers_battery_alert").Value = 1, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)
                btnSpeedAlert.ButtonStyle = If(dgvDealers.CurrentRow.Cells("dgvDealers_speed_alert").Value = 1, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)
                btnGeofenceAlert.ButtonStyle = If(dgvDealers.CurrentRow.Cells("dgvDealers_geofence_alert").Value = 1, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)
                btnIgnitionAlert.ButtonStyle = If(dgvDealers.CurrentRow.Cells("dgvDealers_ignition_alert").Value = 1, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)
                btnMotionAlert.ButtonStyle = If(dgvDealers.CurrentRow.Cells("dgvDealers_motion_alert").Value = 1, ZUControls.ZUButton.buttonStyles.StyleGreen, ZUControls.ZUButton.buttonStyles.StyleRed)

                If Not TypeOf dgvDealers.CurrentRow.Cells("dgvDealers_image").Value Is Byte() Then
                    pboxLogo.Image = Nothing
                Else
                    Dim image As New MemoryStream(DirectCast(dgvDealers.CurrentRow.Cells("dgvDealers_image").Value, Byte()))
                    pboxLogo.Image = Drawing.Image.FromStream(image)
                End If

                btnNewDealer.Enabled = True
                btnEditDealer.Enabled = True
                btnSaveDealer.Enabled = False
                btnDeleteDealer.Enabled = True
                btnCancelDealer.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub btnAddImage_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click
        ofdLogo.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png|Bitmap|*.bmp"

        If ofdLogo.ShowDialog() = DialogResult.OK Then
            pboxLogo.Image = Image.FromFile(ofdLogo.FileName)
            btnAddImage.Enabled = False
            btnRemoveImage.Enabled = True
        End If
    End Sub

    Private Sub btnRemoveImage_Click(sender As Object, e As EventArgs) Handles btnRemoveImage.Click
        pboxLogo.Image = Nothing
        btnAddImage.Enabled = True
        btnRemoveImage.Enabled = False
    End Sub

    Private Sub btnSaveDealer_Click(sender As Object, e As EventArgs) Handles btnSaveDealer.Click
        If txtDni.Text.Trim = "" Then
            MsgBox("Debe ingresar la cédula o rif del dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDni.Focus()
            Exit Sub
        End If
        If txtName.Text.Trim = "" Then
            MsgBox("Debe ingresar nombre o razón social del dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtName.Focus()
            Exit Sub
        End If
        If txtContact.Text.Trim = "" Then
            MsgBox("Debe ingresar el nombre de la persona contacto del dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtContact.Focus()
            Exit Sub
        End If
        If txtPhoneNumber1.Text.Trim = "" Then
            MsgBox("Debe ingresar el teléfono principal del dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtPhoneNumber1.Focus()
            Exit Sub
        End If
        If txtAddress.Text.Trim = "" Then
            MsgBox("Debe ingresar la dirección del dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtAddress.Focus()
            Exit Sub
        End If
        If txtEmail.Text.Trim = "" Then
            MsgBox("Debe ingresar correo electrónico del dealer", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtEmail.Focus()
            Exit Sub
        End If

        If Not bgwSavingDealers.IsBusy Then
            dgvDealers.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvDealers)
            bgwSavingDealers.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSavingDealers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSavingDealers.DoWork
        Try
            bgwSavingDealers.ReportProgress(1)
            Dim proc As New Procedure

            Dim arrImage() As Byte = Nothing

            If Not pboxLogo.Image Is Nothing Then
                Dim mstream As New MemoryStream()
                pboxLogo.Image.Save(mstream, Imaging.ImageFormat.Png)
                arrImage = mstream.GetBuffer()
            End If

            Dim dni As String = txtDni.Text.Trim
            Dim name As String = txtName.Text.Trim
            Dim contact As String = txtContact.Text.Trim
            Dim phone1 As String = txtPhoneNumber1.Text.Trim
            Dim phone2 As String = txtPhoneNumber2.Text.Trim
            Dim address As String = txtAddress.Text.Trim
            Dim email As String = txtEmail.Text.Trim
            Dim website As String = txtWebSite.Text.Trim
            Dim status As Integer = If(cboxStatus.Checked, 1, 0)
            Dim bAlert As Integer = If(btnBatteryAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0)
            Dim sAlert As Integer = If(btnSpeedAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0)
            Dim gAlert As Integer = If(btnGeofenceAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0)
            Dim iAlert As Integer = If(btnIgnitionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0)
            Dim mAlert As Integer = If(btnMotionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0)

            If curDealerMode = DealerMode.Registering Then
                If proc.GetData("dealers_insert",
                                                txtDni.Text.Trim,
                                               txtName.Text.Trim,
                                               txtContact.Text.Trim,
                                               txtPhoneNumber1.Text.Trim,
                                               If(txtPhoneNumber2.Text.Trim = "", Nothing, txtPhoneNumber2.Text.Trim),
                                               txtAddress.Text.Trim,
                                               txtEmail.Text.Trim,
                                               txtWebSite.Text.Trim,
                                               If(cboxStatus.Checked, 1, 0),
                                               If(btnBatteryAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                               If(btnSpeedAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                               If(btnGeofenceAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                               If(btnIgnitionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                               If(btnMotionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                               arrImage) Then

                    bgwSavingDealers.ReportProgress(2, proc.Ds.Tables(0))
                Else
                    bgwSavingDealers.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("dealers_update",
                                            dgvDealers.CurrentRow.Cells("dgvDealers_dealer_id").Value,
                                            txtDni.Text.Trim,
                                            txtName.Text.Trim,
                                            txtContact.Text.Trim,
                                            txtPhoneNumber1.Text.Trim,
                                            txtPhoneNumber2.Text.Trim,
                                            txtAddress.Text.Trim,
                                            txtEmail.Text.Trim,
                                            txtWebSite.Text.Trim,
                                            If(cboxStatus.Checked, 1, 0),
                                            If(btnBatteryAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                            If(btnSpeedAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                            If(btnGeofenceAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                            If(btnIgnitionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                            If(btnMotionAlert.ButtonStyle = ZUControls.ZUButton.buttonStyles.StyleGreen, 1, 0),
                                            arrImage) Then

                    bgwSavingDealers.ReportProgress(2, proc.Ds.Tables(0))
                Else
                    bgwSavingDealers.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSavingDealers.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingDealers_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSavingDealers.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                For Each ctl As Control In gboxGeneralData.Controls
                    If Not TypeOf ctl Is PictureBox Then
                        ctl.Enabled = False
                    End If
                Next

                panelButtons.Enabled = False
                dgvDealers.Enabled = False
                lblLoadingDealers.Text = "Guardando dealer... Por favor espere"
                panelLoadingDealers.Visible = True
                Exit Select
            Case 2
                panelButtons.Enabled = True
                dgvDealers.Enabled = True
                panelLoadingDealers.Visible = False
                Dim msg As String = If(curDealerMode = DealerMode.Registering, "Dealer ingresado exitosamente", "Dealer actualizado exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")

                dgvDealers.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvDealers.Rows.Add()
                        dgvDealers.Rows(i).Cells("dgvDealers_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvDealers.Rows(i).Cells("dgvDealers_name").Value = If(row("name") Is DBNull.Value, "", row("name"))
                        dgvDealers.Rows(i).Cells("dgvDealers_contact").Value = If(row("contact") Is DBNull.Value, "", row("contact"))
                        dgvDealers.Rows(i).Cells("dgvDealers_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvDealers.Rows(i).Cells("dgvDealers_phone_number2").Value = If(row("phone_number2") Is DBNull.Value, Nothing, row("phone_number2"))
                        dgvDealers.Rows(i).Cells("dgvDealers_address").Value = If(row("address") Is DBNull.Value, "", row("address"))
                        dgvDealers.Rows(i).Cells("dgvDealers_email").Value = If(row("email") Is DBNull.Value, "", row("email"))
                        dgvDealers.Rows(i).Cells("dgvDealers_web_site").Value = If(row("web_site") Is DBNull.Value, "", row("web_site"))
                        dgvDealers.Rows(i).Cells("dgvDealers_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvDealers.Rows(i).Cells("dgvDealers_battery_alert").Value = If(row("battery_alert") Is DBNull.Value, 0, row("battery_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_speed_alert").Value = If(row("speed_alert") Is DBNull.Value, 0, row("speed_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_geofence_alert").Value = If(row("geofence_alert") Is DBNull.Value, 0, row("geofence_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_ignition_alert").Value = If(row("ignition_alert") Is DBNull.Value, 0, row("ignition_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_motion_alert").Value = If(row("motion_alert") Is DBNull.Value, 0, row("motion_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_image").Value = If(row("image") Is DBNull.Value, "", row("image"))
                        dgvDealers.Rows(i).Cells("dgvDealers_dealer_id").Value = If(row("dealer_id") Is DBNull.Value, 0, row("dealer_id"))
                    Next
                End If

                Call btnCancelDealer_Click(Nothing, Nothing)
                Exit Select
            Case 3
                For Each ctl As Control In gboxGeneralData.Controls
                    ctl.Enabled = True
                Next
                panelButtons.Enabled = True
                dgvDealers.Enabled = True
                panelLoadingDealers.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnDeleteDealer_Click(sender As Object, e As EventArgs) Handles btnDeleteDealer.Click
        If Not bgwDeletingDealers.IsBusy Then
            If MsgBox("¿Está seguro de eliminar el dealer actual", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                dgvDealers.ScrollBars = ScrollBars.None
                DrawingControl.SuspendDrawing(dgvDealers)

                bgwDeletingDealers.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwDeletingDealers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeletingDealers.DoWork
        Try
            bgwDeletingDealers.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("dealers_delete", dgvDealers.CurrentRow.Cells("dgvDealers_dealer_id").Value) Then
                bgwDeletingDealers.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwDeletingDealers.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingDealers.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingDealers_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeletingDealers.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                For Each ctl As Control In gboxGeneralData.Controls
                    If Not TypeOf ctl Is PictureBox Then
                        ctl.Enabled = False
                    End If
                Next

                panelButtons.Enabled = False
                dgvDealers.Enabled = False
                lblLoadingDealers.Text = "Eliminando dealer... Por favor espere"
                panelLoadingDealers.Visible = True
                Exit Select
            Case 2
                panelButtons.Enabled = True
                dgvDealers.Enabled = True
                panelLoadingDealers.Visible = False
                MsgBox("Dealer eliminado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")

                dgvDealers.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvDealers.Rows.Add()
                        dgvDealers.Rows(i).Cells("dgvDealers_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvDealers.Rows(i).Cells("dgvDealers_name").Value = If(row("name") Is DBNull.Value, "", row("name"))
                        dgvDealers.Rows(i).Cells("dgvDealers_contact").Value = If(row("contact") Is DBNull.Value, "", row("contact"))
                        dgvDealers.Rows(i).Cells("dgvDealers_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvDealers.Rows(i).Cells("dgvDealers_phone_number2").Value = If(row("phone_number2") Is DBNull.Value, Nothing, row("phone_number2"))
                        dgvDealers.Rows(i).Cells("dgvDealers_address").Value = If(row("address") Is DBNull.Value, "", row("address"))
                        dgvDealers.Rows(i).Cells("dgvDealers_email").Value = If(row("email") Is DBNull.Value, "", row("email"))
                        dgvDealers.Rows(i).Cells("dgvDealers_web_site").Value = If(row("web_site") Is DBNull.Value, "", row("web_site"))
                        dgvDealers.Rows(i).Cells("dgvDealers_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvDealers.Rows(i).Cells("dgvDealers_battery_alert").Value = If(row("battery_alert") Is DBNull.Value, 0, row("battery_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_speed_alert").Value = If(row("speed_alert") Is DBNull.Value, 0, row("speed_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_geofence_alert").Value = If(row("geofence_alert") Is DBNull.Value, 0, row("geofence_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_ignition_alert").Value = If(row("ignition_alert") Is DBNull.Value, 0, row("ignition_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_motion_alert").Value = If(row("motion_alert") Is DBNull.Value, 0, row("motion_alert"))
                        dgvDealers.Rows(i).Cells("dgvDealers_image").Value = If(row("image") Is DBNull.Value, "", row("image"))
                        dgvDealers.Rows(i).Cells("dgvDealers_dealer_id").Value = If(row("dealer_id") Is DBNull.Value, 0, row("dealer_id"))
                    Next
                End If

                Call btnCancelDealer_Click(Nothing, Nothing)
                Exit Select
            Case 3
                For Each ctl As Control In gboxGeneralData.Controls
                    ctl.Enabled = True
                Next
                panelButtons.Enabled = True
                dgvDealers.Enabled = True
                panelLoadingDealers.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwSavingDealers_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSavingDealers.RunWorkerCompleted
        dgvDealers.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvDealers)
    End Sub

    Private Sub bgwDeletingDealers_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwDeletingDealers.RunWorkerCompleted
        dgvDealers.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvDealers)
    End Sub
End Class