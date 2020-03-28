Imports System.ComponentModel
Imports System.IO
Imports System.IO.Ports
Imports Microsoft.Win32

Public Class frmDevices
    Dim port As SerialPort
    Sub New(Optional port As SerialPort = Nothing)
        InitializeComponent()

        Me.port = port

        rbtnDeviceMaintaining.Parent = Me
        rbtnDeviceFiltering.Parent = Me

        rbtnDeviceMaintaining.Location = New Point(10, 1)
        rbtnDeviceFiltering.Location = New Point(10, 142)
    End Sub

    Dim curDeviceMode As DeviceMode = DeviceMode.Registering

    Enum DeviceMode
        Registering
        Editing
    End Enum

    Private Sub frmDevices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        rbtnDeviceMaintaining.BringToFront()
        rbtnDeviceFiltering.BringToFront()

        Dim TargetKey As RegistryKey
        TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application")
        btnExportExcel.Visible = If(TargetKey Is Nothing, False, True)
        TargetKey.Close()
    End Sub

    Private Sub btnNewDevice_Click(sender As Object, e As EventArgs) Handles btnNewDevice.Click
        If Not bgwGetSimCards.IsBusy Then
            curDeviceMode = DeviceMode.Registering
            bgwGetSimCards.RunWorkerAsync(0)
        End If
    End Sub

    Private Sub getSimCards(ByVal asigned As Integer)
        Try
            Dim proc As New Procedure
            Dim row As DataRow
            Dim dt As New DataTable("simcards")
            Dim col1 As New DataColumn("simcard_id")
            Dim col2 As New DataColumn("simcard")
            dt.Columns.Add(col1)
            dt.Columns.Add(col2)

            If curDeviceMode = DeviceMode.Editing Then
                row = dt.NewRow()
                row.Item("simcard_id") = CInt(dgvDevices.CurrentRow.Cells("dgvDevices_simcard_id").Value)
                row.Item("simcard") = dgvDevices.CurrentRow.Cells("dgvDevices_simcard").Value
                dt.Rows.Add(row)
            End If

            If proc.GetData("simcards_getByAsigned", asigned) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                        row = dt.NewRow()
                        row.Item("simcard_id") = If(row2("simcard_id") Is DBNull.Value, 0, row2("simcard_id"))
                        row.Item("simcard") = If(row2("phone_number") Is DBNull.Value, 0, row2("phone_number")) & " (" & If(row2("serial") Is DBNull.Value, "", row2("serial")) & ")"
                        dt.Rows.Add(row)
                    Next
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If

            cboMSimCards.DataSource = Nothing
            cboMSimCards.DataSource = dt
            cboMSimCards.DisplayMember = "simcard"
            cboMSimCards.ValueMember = "simcard_id"
            cboMSimCards.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub getDeviceModels()
        Try
            Dim dt As New DataTable("device_models")
            Dim col1 As New DataColumn("device_model_id")
            Dim col2 As New DataColumn("device_model")
            dt.Columns.Add(col1)
            dt.Columns.Add(col2)

            Dim row As DataRow
            Dim proc As New Procedure

            If proc.GetData("device_models_getAll") Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                        row = dt.NewRow()
                        row.Item("device_model_id") = If(row2("device_model_id") Is DBNull.Value, 0, row2("device_model_id"))
                        row.Item("device_model") = If(row2("model") Is DBNull.Value, "", row2("model")) & " (" & If(row2("brand") Is DBNull.Value, "", row2("brand")) & ")"
                        dt.Rows.Add(row)
                    Next
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If

            cboMModels.DataSource = Nothing
            cboMModels.DataSource = dt
            cboMModels.DisplayMember = "device_model"
            cboMModels.ValueMember = "device_model_id"
            cboMModels.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub
    Private Sub btnEditDevice_Click(sender As Object, e As EventArgs) Handles btnEditDevice.Click
        If Not bgwGetSimCards.IsBusy Then
            curDeviceMode = DeviceMode.Editing
            bgwGetSimCards.RunWorkerAsync(0)
        End If
    End Sub

    Private Sub bgwGetSimCards_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetSimCards.DoWork
        Try
            bgwGetSimCards.ReportProgress(1)

            getSimCards(Integer.Parse(e.Argument))
            getDeviceModels()

            bgwGetSimCards.ReportProgress(2, e.Argument)
        Catch ex As Exception
            bgwGetSimCards.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetSimCards_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetSimCards.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                gboxDeviceMaintaining.Enabled = False
                gboxDeviceFiltering.Enabled = False
                rbtnDeviceMaintaining.Enabled = False
                rbtnDeviceFiltering.Enabled = False
                dgvDevices.Enabled = False
                lblLoading.Text = "Cargando lista de simcards y modelos de dispositivos... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                gboxDeviceMaintaining.Enabled = True
                gboxDeviceFiltering.Enabled = False
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = False
                dgvDevices.Enabled = True
                panelLoading.Visible = False

                For Each ctl As Control In gboxDeviceMaintaining.Controls
                    If Not TypeOf ctl Is ZUControls.ZUButton Then
                        ctl.Enabled = True
                    End If
                Next

                If curDeviceMode = DeviceMode.Registering Then
                    cboMSimCards.SelectedIndex = -1
                    cboMModels.SelectedIndex = -1
                    txtMImei.Text = ""
                    txtMObservations.Text = ""
                    cboxMStatus.Checked = True
                Else
                    cboMSimCards.SelectedValue = CInt(dgvDevices.CurrentRow.Cells("dgvDevices_simcard_id").Value)
                    cboMModels.SelectedValue = CInt(dgvDevices.CurrentRow.Cells("dgvDevices_device_model_id").Value)
                End If

                btnNewDevice.Enabled = False
                btnEditDevice.Enabled = False
                btnSaveDevice.Enabled = True
                btnDeleteDevice.Enabled = False
                btnCancelDevice.Enabled = True
                cboMSimCards.Focus()
                dgvDevices.Enabled = False

                Exit Select
            Case 3
                gboxDeviceMaintaining.Enabled = True
                gboxDeviceFiltering.Enabled = True
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False

                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub rbtnDeviceMaintaining_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDeviceMaintaining.CheckedChanged
        gboxDeviceMaintaining.Enabled = rbtnDeviceMaintaining.Checked
    End Sub

    Private Sub rbtnDeviceFiltering_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnDeviceFiltering.CheckedChanged
        gboxDeviceFiltering.Enabled = rbtnDeviceFiltering.Checked
    End Sub

    Private Sub dgvDevices_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDevices.CellClick
        If e.RowIndex >= 0 Then

            For Each ctl As Control In gboxDeviceMaintaining.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton Then
                    ctl.Enabled = False
                End If
            Next

            cboMSimCards.DataSource = Nothing
            cboMSimCards.Items.Clear()
            cboMModels.DataSource = Nothing
            cboMModels.Items.Clear()

            cboMSimCards.Items.Add(dgvDevices.CurrentRow.Cells("dgvDevices_simcard").Value.ToString)
            cboMSimCards.SelectedIndex = 0
            cboMModels.Items.Add(dgvDevices.CurrentRow.Cells("dgvDevices_model").Value.ToString)
            cboMModels.SelectedIndex = 0
            txtMImei.Text = dgvDevices.CurrentRow.Cells("dgvDevices_imei").Value.ToString
            txtMObservations.Text = dgvDevices.CurrentRow.Cells("dgvDevices_observations").Value.ToString
            cboxMStatus.Checked = If(CInt(dgvDevices.CurrentRow.Cells("dgvDevices_status").Value) = 1, True, False)

            btnNewDevice.Enabled = True
            btnEditDevice.Enabled = True
            btnSaveDevice.Enabled = False
            btnDeleteDevice.Enabled = True
            btnCancelDevice.Enabled = True

            If e.ColumnIndex = 0 Then
                Dim frm As New frmDeviceConfig(dgvDevices.Rows(e.RowIndex), Nothing, port)
                frm.Show()
            End If
        End If
    End Sub

    Private Sub btnSearchDevices_Click(sender As Object, e As EventArgs) Handles btnSearchDevices.Click
        If Not bgwSearchDevices.IsBusy Then
            bgwSearchDevices.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSearchDevices_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSearchDevices.DoWork
        Try
            bgwSearchDevices.ReportProgress(1)

            Dim query As String = "select * from devices as d " &
                                   "left join simcards as s on d.simcard_id = s.simcard_id " &
                                   "left join device_models as m on d.device_model_id = m.device_model_id " &
                                   "where d.device_id > 0"

            If cboxFSimCard.Checked Then
                If txtFSerialPhone.Text.Trim = "" Then
                    MsgBox("Debe indicar el serial o teléfono de la simcard", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    txtFSerialPhone.Focus()
                    bgwSearchDevices.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " and (s.serial like [serial] or s.phone_number like [phone_number])"
                End If
            End If

            If cboxFImei.Checked Then
                If txtFImei.Text.Trim = "" Then
                    MsgBox("Debe indicar el imei del dispositivo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    txtFImei.Focus()
                    bgwSearchDevices.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " and d.imei like [imei]"
                End If
            End If

            If cboxFStatus.Checked Then
                query = query & " and d.status = [status]"
            End If

            If cboxFAsigned.Checked Then
                query = query & " and d.asigned = [asigned]"
            End If

            query = query & ";"

            If query.Contains("[serial]") Then
                query = query.Replace("[serial]", Chr(39) & Chr(37) & txtFSerialPhone.Text.Trim & Chr(37) & Chr(39))
            End If

            If query.Contains("[phone_number]") Then
                query = query.Replace("[phone_number]", Chr(39) & Chr(37) & txtFSerialPhone.Text.Trim & Chr(37) & Chr(39))
            End If

            If query.Contains("[imei]") Then
                query = query.Replace("[imei]", Chr(39) & Chr(37) & txtFImei.Text.Trim & Chr(37) & Chr(39))
            End If

            If query.Contains("[status]") Then
                query = query.Replace("[status]", If(rbtnFActive.Checked, 1, 0))
            End If

            If query.Contains("[asigned]") Then
                query = query.Replace("[asigned]", If(rbtnFAsignedYes.Checked, 1, 0))
            End If

            Dim proc As New Procedure

            If proc.GetData("global_procedure", query) Then
                bgwSearchDevices.ReportProgress(3, proc.Ds.Tables(0))
            Else
                bgwSearchDevices.ReportProgress(4, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwSearchDevices.ReportProgress(4, ex.Message)
        End Try
    End Sub

    Private Sub bgwSearchDevices_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSearchDevices.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                dgvDevices.Rows.Clear()
                dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                dgvDevices.ScrollBars = ScrollBars.None
                DrawingControl.SuspendDrawing(dgvDevices)

                rbtnDeviceMaintaining.Enabled = False
                rbtnDeviceFiltering.Enabled = False
                gboxDeviceMaintaining.Enabled = False
                gboxDeviceFiltering.Enabled = False
                dgvDevices.Enabled = False
                lblLoading.Text = "Buscando dispositivos... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                gboxDeviceFiltering.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False
                Exit Select
            Case 3


                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvDevices.Rows.Add()
                        dgvDevices.Rows(i).Cells("dgvDevices_simcard").Value = If(row("phone_number") Is DBNull.Value, 0, row("phone_number")) & " (" & If(row("serial") Is DBNull.Value, "", row("serial")) & ")"
                        dgvDevices.Rows(i).Cells("dgvDevices_phone_number").Value = If(row("phone_number") Is DBNull.Value, 0, row("phone_number"))
                        dgvDevices.Rows(i).Cells("dgvDevices_model").Value = If(row("model") Is DBNull.Value, "", row("model")) & " (" & If(row("brand") Is DBNull.Value, "", row("brand")) & ")"
                        dgvDevices.Rows(i).Cells("dgvDevices_imei").Value = If(row("imei") Is DBNull.Value, "", row("imei"))
                        dgvDevices.Rows(i).Cells("dgvDevices_observations").Value = If(row("observations") Is DBNull.Value, "", row("observations"))
                        dgvDevices.Rows(i).Cells("dgvDevices_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvDevices.Rows(i).Cells("dgvDevices_device_id").Value = If(row("device_id") Is DBNull.Value, 0, row("device_id"))
                        dgvDevices.Rows(i).Cells("dgvDevices_simcard_id").Value = If(row("simcard_id") Is DBNull.Value, 0, row("simcard_id"))
                        dgvDevices.Rows(i).Cells("dgvDevices_device_model_id").Value = If(row("device_model_id") Is DBNull.Value, 0, row("device_model_id"))
                        dgvDevices.Rows(i).Cells("dgvDevices_sms_stop").Value = If(row("sms_stop") Is DBNull.Value, "", row("sms_stop"))
                        dgvDevices.Rows(i).Cells("dgvDevices_sms_resume").Value = If(row("sms_resume") Is DBNull.Value, "", row("sms_resume"))
                        dgvDevices.Rows(i).Cells("dgvDevices_gprs_stop").Value = If(row("gprs_stop") Is DBNull.Value, "", row("gprs_stop"))
                        dgvDevices.Rows(i).Cells("dgvDevices_gprs_resume").Value = If(row("gprs_resume") Is DBNull.Value, "", row("gprs_resume"))
                    Next
                End If

                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                gboxDeviceFiltering.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False
                Exit Select
            Case 4
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                gboxDeviceFiltering.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub cboxFSimCard_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFSimCard.CheckedChanged
        txtFSerialPhone.Enabled = cboxFSimCard.Checked
        txtFSerialPhone.Text = ""
    End Sub

    Private Sub cboxFImei_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFImei.CheckedChanged
        txtFImei.Enabled = cboxFImei.Checked
        txtFImei.Text = ""
    End Sub

    Private Sub cboxFStatus_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFStatus.CheckedChanged
        panelStatusDevice.Enabled = cboxFStatus.Checked
        rbtnFActive.Checked = True
    End Sub

    Private Sub cboxFAsigned_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFAsigned.CheckedChanged
        panelAsignedDevice.Enabled = cboxFAsigned.Checked
        rbtnFAsignedYes.Checked = True
    End Sub

    Private Sub btnSaveDevice_Click(sender As Object, e As EventArgs) Handles btnSaveDevice.Click
        If cboMSimCards.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una simcard", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboMSimCards.Focus()
            Exit Sub
        End If

        If cboMModels.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un modelo de dispositivo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboMModels.Focus()
            Exit Sub
        End If

        If txtMImei.Text.Trim = "" Then
            MsgBox("Debe indicar el imei del dispositivo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtMImei.Focus()
            Exit Sub
        End If

        If Not bgwSaveDevice.IsBusy Then
            bgwSaveDevice.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSaveDevice_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSaveDevice.DoWork
        Try
            bgwSaveDevice.ReportProgress(1)
            Dim proc As New Procedure

            If curDeviceMode = DeviceMode.Registering Then
                If proc.GetData("devices_insert",
                                                cboMSimCards.SelectedValue,
                                                cboMModels.SelectedValue,
                                                txtMImei.Text.Trim,
                                                If(cboxMStatus.Checked, 1, 0),
                                                txtMObservations.Text.Trim) Then
                    bgwSaveDevice.ReportProgress(2)
                Else
                    bgwSaveDevice.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("devices_update",
                                                dgvDevices.CurrentRow.Cells("dgvDevices_device_id").Value,
                                                cboMSimCards.SelectedValue,
                                                cboMModels.SelectedValue,
                                                txtMImei.Text.Trim,
                                                If(cboxMStatus.Checked, 1, 0),
                                                txtMObservations.Text.Trim) Then
                    bgwSaveDevice.ReportProgress(2)
                Else
                    bgwSaveDevice.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSaveDevice.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSaveDevice_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSaveDevice.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                rbtnDeviceMaintaining.Enabled = False
                rbtnDeviceFiltering.Enabled = False
                gboxDeviceMaintaining.Enabled = False
                dgvDevices.Enabled = False
                lblLoading.Text = "Guardando dispositivo... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False
                Dim msg As String = If(curDeviceMode = DeviceMode.Registering, "Dispositivo guardado exitosamente", "Dispositivo actualizado exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                Call btnCancelDevice_Click(Nothing, Nothing)
                dgvDevices.Rows.Clear()
                Exit Select
            Case 3
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnCancelDevice_Click(sender As Object, e As EventArgs) Handles btnCancelDevice.Click
        For Each ctl As Control In gboxDeviceMaintaining.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                If TypeOf ctl Is ZUControls.ZUComboBox Then
                    DirectCast(ctl, ZUControls.ZUComboBox).DataSource = Nothing
                    DirectCast(ctl, ZUControls.ZUComboBox).Items.Clear()
                End If

                If TypeOf ctl Is ZUControls.ZUTextBox Or TypeOf ctl Is ZUControls.ZUNumericBox Then
                    ctl.Text = ""
                End If
            End If

            ctl.Enabled = False
        Next

        cboxMStatus.Checked = False

        btnNewDevice.Enabled = True
        btnEditDevice.Enabled = False
        btnSaveDevice.Enabled = False
        btnDeleteDevice.Enabled = False
        btnCancelDevice.Enabled = False
        dgvDevices.Enabled = True

        rbtnDeviceFiltering.Enabled = True
    End Sub

    Private Sub btnDeleteDevice_Click(sender As Object, e As EventArgs) Handles btnDeleteDevice.Click
        If MsgBox("¿Está seguro de eliminar el dispositivo actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If Not bgwDeleteDevice.IsBusy Then
                bgwDeleteDevice.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwDeleteDevice_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeleteDevice.DoWork
        Try
            bgwDeleteDevice.ReportProgress(1)

            Dim proc As New Procedure

            If proc.GetData("devices_delete", dgvDevices.CurrentRow.Cells("dgvDevices_device_id").Value) Then
                bgwDeleteDevice.ReportProgress(2)
            Else
                bgwDeleteDevice.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeleteDevice.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeleteDevice_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeleteDevice.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                rbtnDeviceMaintaining.Enabled = False
                rbtnDeviceFiltering.Enabled = False
                gboxDeviceMaintaining.Enabled = False
                dgvDevices.Enabled = False
                lblLoading.Text = "Eliminando dispositivo... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                rbtnDeviceMaintaining.Checked = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False

                MsgBox("Dispositivo eliminado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")

                Call btnCancelDevice_Click(Nothing, Nothing)
                dgvDevices.Rows.Clear()
                Exit Select
            Case 3
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False

                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub dgvDevices_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvDevices.RowsAdded
        btnExportExcel.Enabled = dgvDevices.Rows.Count > 0
    End Sub

    Private Sub dgvDevices_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvDevices.RowsRemoved
        btnExportExcel.Enabled = dgvDevices.Rows.Count > 0
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If Not bgwExportExcel.IsBusy Then
            Dim filename As String = InputBox("Ingrese el nombre del archivo", "Mensaje del Sistema")

            If Not filename = "" Then
                Dim dir As New FolderBrowserDialog
                If dir.ShowDialog = DialogResult.OK Then
                    bgwExportExcel.RunWorkerAsync(dir.SelectedPath & "\" & filename & ".csv")
                End If
            End If
        End If
    End Sub

    Private Sub bgwExportExcel_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwExportExcel.DoWork
        Try
            bgwExportExcel.ReportProgress(1)

            Dim stream As Stream
            Dim writer As StreamWriter
            Dim rows As Integer = dgvDevices.Rows.Count
            Dim cols As Integer = dgvDevices.Columns.Count

            Dim line As String = ""
            Dim rowdata, column As Integer
            File.Delete(e.Argument.ToString())

            stream = File.OpenWrite(e.Argument.ToString())
            writer = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To cols - 4
                line = line & dgvDevices.Columns(column).HeaderText & ";"
            Next

            line = Mid(line, 1, line.Length - 1)
            writer.WriteLine(line)

            line = ""

            For rowdata = 0 To rows - 1
                For column = 0 To cols - 2
                    If column = 4 Then
                        line = line & If(dgvDevices.Item(column, rowdata).Value.ToString() = "1", "ACTIVO", "SUSPENDIDO") & ";"
                    ElseIf column < 4 Then
                        line = line & dgvDevices.Item(column, rowdata).Value & ";"
                    End If
                Next
                line = Mid(line, 1, line.Length - 1)
                writer.WriteLine(line)
                line = ""
            Next

            writer.Close()

            bgwExportExcel.ReportProgress(2, e.Argument.ToString())
        Catch ex As Exception
            bgwExportExcel.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwExportExcel_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwExportExcel.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                rbtnDeviceMaintaining.Enabled = False
                rbtnDeviceFiltering.Enabled = False
                gboxDeviceMaintaining.Enabled = False
                dgvDevices.Enabled = False
                lblLoading.Text = "Exportando... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                rbtnDeviceMaintaining.Checked = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False

                Try
                    Process.Start("excel.exe", e.UserState.ToString())
                Catch ex As Exception
                End Try
                Exit Select
            Case 3
                rbtnDeviceMaintaining.Enabled = True
                rbtnDeviceFiltering.Enabled = True
                gboxDeviceMaintaining.Enabled = True
                dgvDevices.Enabled = True
                panelLoading.Visible = False

                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwSearchDevices_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSearchDevices.RunWorkerCompleted
        dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvDevices.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvDevices)
    End Sub
End Class