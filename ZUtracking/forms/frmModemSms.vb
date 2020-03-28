Public Class frmModemSms
    Private Sub frmModemSms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboBaudRate.Text = My.Settings.baudRate
        cboDataBits.Text = My.Settings.dataBits
        cboParity.Text = My.Settings.parity
        cboStopBits.Text = My.Settings.stopBits
        cboHandshake.Text = My.Settings.handshake
        txtWriteTimeout.Text = My.Settings.writeTimeout
        txtReadBufferSize.Text = My.Settings.readBufferSize
        txtWriteBufferSize.Text = My.Settings.writeBufferSize
        If Not My.Settings.portName = "" Then
            cboPortName.Items.Add(My.Settings.portName)
            cboPortName.SelectedIndex = 0
        End If
        txtIgnitionTemplate.Text = My.Settings.ignitionTemplate
        txtBatteryTemplate.Text = My.Settings.batteryTemplate
        txtGeofenceTemplate.Text = My.Settings.geofenceTemplate
        txtSpeedTemplate.Text = My.Settings.speedTemplate
        txtMotionTemplate.Text = My.Settings.motionTemplate
    End Sub

    Private Sub btnDefaultValues_Click(sender As Object, e As EventArgs) Handles btnDefaultValues.Click
        cboBaudRate.Text = "460800"
        cboDataBits.Text = "8"
        cboParity.Text = "Ninguno"
        cboStopBits.Text = "1"
        cboHandshake.Text = "Ninguno"
        txtReadBufferSize.Text = "1024"
        txtWriteBufferSize.Text = "1024"
        txtWriteTimeout.Text = "500"
    End Sub

    Private Sub btnGetPorts_Click(sender As Object, e As EventArgs) Handles btnGetPorts.Click
        Try
            Dim portsName As List(Of String) = getSerialPorts()
            Dim i As Integer

            cboPortName.Items.Clear()

            If portsName.Count > 0 Then
                For i = 0 To portsName.Count - 1
                    cboPortName.Items.Add(portsName(i))
                Next
                cboPortName.SelectedIndex = 0
            Else
                MsgBox("No se han detectado puertos serie en su equipo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Function getSerialPorts() As List(Of String)

        Dim serialPorts As New List(Of String)

        Try
            For Each gotPorts As String In My.Computer.Ports.SerialPortNames
                serialPorts.Add(gotPorts)
            Next
            getSerialPorts = serialPorts
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            getSerialPorts = serialPorts
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboBaudRate.Text.Trim = "" Then
            MsgBox("Debe seleccionar un valor de bits por segundo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboBaudRate.Focus()
            Exit Sub
        End If

        If cboDataBits.Text.Trim = "" Then
            MsgBox("Debe seleccionar un valor de bits de datos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboDataBits.Focus()
            Exit Sub
        End If

        If cboParity.Text.Trim = "" Then
            MsgBox("Debe seleccionar un valor de paridad", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboParity.Focus()
            Exit Sub
        End If

        If cboStopBits.Text.Trim = "" Then
            MsgBox("Debe seleccionar un valor de bits de parada", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboStopBits.Focus()
            Exit Sub
        End If

        If cboHandshake.Text.Trim = "" Then
            MsgBox("Debe seleccionar un valor de control de flujo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboHandshake.Focus()
            Exit Sub
        End If

        If txtWriteTimeout.Text.Trim = "" Then
            MsgBox("Debe indicar un valor para el tiempo de espera", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtWriteTimeout.Focus()
            Exit Sub
        End If

        If txtReadBufferSize.Text.Trim = "" Then
            MsgBox("Debe indicar un valor para el búfer de lectura", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtReadBufferSize.Focus()
            Exit Sub
        End If

        If txtWriteBufferSize.Text.Trim = "" Then
            MsgBox("Debe indicar un valor para el búfer de escritura", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtWriteBufferSize.Focus()
            Exit Sub
        End If

        If cboPortName.Text.Trim = "" Then
            MsgBox("Debe seleccionar un puerto serial", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboPortName.Focus()
            Exit Sub
        End If

        My.Settings.baudRate = cboBaudRate.Text.Trim
        My.Settings.dataBits = cboDataBits.Text.Trim
        My.Settings.parity = cboParity.Text.Trim
        My.Settings.stopBits = cboStopBits.Text.Trim
        My.Settings.handshake = cboHandshake.Text.Trim
        My.Settings.writeTimeout = txtWriteTimeout.Text.Trim
        My.Settings.readBufferSize = txtReadBufferSize.Text.Trim
        My.Settings.writeBufferSize = txtWriteBufferSize.Text.Trim
        My.Settings.portName = cboPortName.Text.Trim
        My.Settings.ignitionTemplate = txtIgnitionTemplate.Text.Trim
        My.Settings.batteryTemplate = txtBatteryTemplate.Text.Trim
        My.Settings.geofenceTemplate = txtGeofenceTemplate.Text.Trim
        My.Settings.speedTemplate = txtSpeedTemplate.Text.Trim
        My.Settings.motionTemplate = txtMotionTemplate.Text.Trim
        My.Settings.Save()
        MsgBox("Parámetros guardados exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
    End Sub
End Class