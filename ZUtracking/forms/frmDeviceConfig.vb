Imports System.IO.Ports

Public Class frmDeviceConfig
    Dim port As SerialPort
    Dim row1, row2 As DataGridViewRow
    Dim sms_stop, sms_resume, callPass As String
    Dim client_id As Integer
    Dim vehicle_id As Integer
    Dim mainForm As Form

    Public Sub New(ByVal row1 As DataGridViewRow, ByVal row2 As DataGridViewRow,
                   Optional port As SerialPort = Nothing,
                   Optional mainForm As Form = Nothing)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.row1 = row1
        Me.row2 = row2
        Me.port = port
        Me.mainForm = mainForm

        fillData()
    End Sub

    Private Sub fillData()
        Dim device_model_id As Integer = 0

        If Not row1 Is Nothing Then
            txtImei.Text = row1.Cells("dgvDevices_imei").Value
            txtSimcard.Text = row1.Cells("dgvDevices_phone_number").Value
            device_model_id = row1.Cells("dgvDevices_device_model_id").Value
            sms_stop = row1.Cells("dgvDevices_sms_stop").Value
            sms_resume = row1.Cells("dgvDevices_sms_resume").Value
            client_id = 0
            vehicle_id = 0
        Else
            Dim enc As New Encryptation

            txtImei.Text = row2.Cells("dgvVehicles_imei").Value
            txtSimcard.Text = row2.Cells("dgvVehicles_simcard").Value
            device_model_id = row2.Cells("dgvVehicles_device_model_id").Value
            sms_stop = row2.Cells("dgvVehicles_sms_stop").Value
            sms_resume = row2.Cells("dgvVehicles_sms_resume").Value

            If Not row2.Cells("dgvVehicles_call_pass").Value.ToString() = "" Then
                txtCallPass.Text = enc.Decrypt(row2.Cells("dgvVehicles_call_pass").Value)
            End If

            client_id = row2.Cells("dgvVehicles_client_id").Value
            vehicle_id = row2.Cells("dgvVehicles_vehicle_id").Value
        End If

        If device_model_id <> 1 And device_model_id <> 7 And device_model_id <> 8 And device_model_id <> 9 And device_model_id <> 11 Then
            For Each ctl As Control In gboxSmsCommands.Controls
                If TypeOf ctl Is ZUControls.ZUTextBox Then
                    ctl.Enabled = False
                End If

                If TypeOf ctl Is RadioButton Then
                    ctl.Enabled = False
                End If

                If TypeOf ctl Is ZUControls.ZUButton Then
                    If ctl.Name <> "btnStop" And ctl.Name <> "btnResume" Then
                        ctl.Enabled = False
                    End If
                End If
            Next
        End If

        txtDevicePass.Text = "116069"

        btnFicha.Enabled = client_id > 0
    End Sub

    Private Sub frmDeviceConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        txtDevicePass.Focus()
    End Sub

    Private Sub sendCommand(ByVal phone_number As String, ByVal message As String)
        Try
            If Not port Is Nothing AndAlso port.IsOpen Then
                port.Write("AT+CMGS=" & Chr(34) & phone_number & Chr(34) & Chr(13))
                Threading.Thread.Sleep(500)
                port.Write(message & Chr(26))
                Threading.Thread.Sleep(500)
                port.Write("AT+CNMI=1,2,0,1,0" & Chr(13))
                Threading.Thread.Sleep(500)
                MsgBox("Comando enviado", MsgBoxStyle.Information, "Mensaje del Sistema")
                Application.DoEvents()
            Else
                MsgBox("El modem se encuentra desconectado", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "reset" & txtDevicePass.Text.Trim)
    End Sub

    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "begin" & txtDevicePass.Text.Trim)
    End Sub

    Private Sub btnAdminIp_Click(sender As Object, e As EventArgs) Handles btnAdminIp.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        If txtAdminIp.Text.Trim = "" Then
            MsgBox("Debe ingresar la ip y el puerto del servidor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtAdminIp.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "adminip" & txtDevicePass.Text.Trim & " " & txtAdminIp.Text.Trim)
    End Sub

    Private Sub btnApn_Click(sender As Object, e As EventArgs) Handles btnApn.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        If txtApn.Text.Trim = "" Then
            MsgBox("Debe ingresar el apn de la operadora telefónica", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtApn.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "apn" & txtDevicePass.Text.Trim & " " & txtApn.Text.Trim)
    End Sub

    Private Sub btnGprs_Click(sender As Object, e As EventArgs) Handles btnGprs.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "gprs" & txtDevicePass.Text.Trim & If(rbtnUdp.Checked, ",1,1", ",0,0"))
    End Sub

    Private Sub btnFix_Click(sender As Object, e As EventArgs) Handles btnFix.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        If txtFix.Text.Trim = "" Then
            MsgBox("Debe ingresar el fix", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtFix.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "fix" & txtFix.Text.Trim & txtDevicePass.Text.Trim)
    End Sub

    Private Sub btnPassword_Click(sender As Object, e As EventArgs) Handles btnPassword.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        If txtPassword.Text.Trim = "" Then
            MsgBox("Debe ingresar la nueva clave", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtPassword.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "password" & txtDevicePass.Text.Trim & " " & txtPassword.Text.Trim)
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        If txtAdmin.Text.Trim = "" Then
            MsgBox("Debe ingresar número telefónico administrador", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtAdmin.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "admin" & txtDevicePass.Text.Trim & " " & txtAdmin.Text.Trim)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "check" & txtDevicePass.Text.Trim)
    End Sub

    Private Sub btnFicha_Click(sender As Object, e As EventArgs) Handles btnFicha.Click
        Dim frm As New frmClients(client_id, mainForm, 1, vehicle_id)
        frm.Show()
        frm.BringToFront()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sms_stop = sms_stop.Replace("[ID]", txtImei.Text.Trim)
        sms_stop = sms_stop.Replace("[pass]", "116069")

        sendCommand(txtSimcard.Text.Trim, sms_stop)
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sms_resume = sms_resume.Replace("[ID]", txtImei.Text.Trim)
        sms_resume = sms_resume.Replace("[pass]", "116069")

        sendCommand(txtSimcard.Text.Trim, sms_resume)
    End Sub

    Private Sub btnImei_Click(sender As Object, e As EventArgs) Handles btnImei.Click
        If txtSimcard.Text.Trim = "" Then
            MsgBox("El campo simcard está vacío", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If txtDevicePass.Text.Trim = "" OrElse txtDevicePass.Text.Trim.Length < 6 Then
            MsgBox("El campo clave debe contener 6 dígitos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDevicePass.Focus()
            Exit Sub
        End If

        sendCommand(txtSimcard.Text.Trim, "imei" & txtDevicePass.Text.Trim)
    End Sub
End Class