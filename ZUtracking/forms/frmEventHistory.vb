Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Win32

Public Class frmEventHistory
    Private Sub bgwGetClients_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwGetClients.DoWork
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
                panelHeader.Enabled = False
                lblLoading.Text = "Cargando lista de clientes... Por favor espere"
                pboxLoading.Visible = True
                Exit Select
            Case 2
                Dim dt As New DataTable("clients")
                Dim col1 As New DataColumn("client_id")
                Dim col2 As New DataColumn("client_name")
                dt.Columns.Add(col1)
                dt.Columns.Add(col2)

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row2 As DataRow = e.UserState.Rows(i)
                        Dim row As DataRow = dt.NewRow
                        row.Item("client_id") = row2("client_id")
                        row.Item("client_name") = (row2("first_name") & " " & If(row2("last_name") Is DBNull.Value, "", row2("last_name"))).ToString().Trim
                        dt.Rows.Add(row)
                    Next
                End If

                cboClients.DataSource = Nothing
                cboClients.DataSource = dt
                cboClients.DisplayMember = "client_name"
                cboClients.ValueMember = "client_id"
                cboClients.SelectedIndex = -1

                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwGetClients_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetClients.RunWorkerCompleted
        lblLoading.Text = ""
        panelHeader.Enabled = True
        pboxLoading.Visible = False
    End Sub

    Private Sub cboxClient_CheckedChanged(sender As Object, e As EventArgs) Handles cboxClient.CheckedChanged
        cboClients.Enabled = cboxClient.Checked
        cboClients.SelectedIndex = -1
    End Sub

    Private Sub cboClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClients.SelectedIndexChanged
        If cboClients.SelectedIndex > -1 Then
            cboxVehicle.Enabled = True
        Else
            cboxVehicle.Enabled = False
            cboxVehicle.Checked = False
        End If
    End Sub

    Private Sub cboxVehicle_CheckedChanged(sender As Object, e As EventArgs) Handles cboxVehicle.CheckedChanged
        cboVehicles.Enabled = cboxVehicle.Checked
        cboVehicles.SelectedIndex = -1
    End Sub

    Private Sub cboxEvent_CheckedChanged(sender As Object, e As EventArgs) Handles cboxEvent.CheckedChanged
        cboEvents.Enabled = cboxEvent.Checked
        cboEvents.SelectedIndex = -1
    End Sub

    Private Sub frmEventHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        dtpByMonth.Value = Date.Parse("01/" & Now.Month.ToString("00") & "/" & Now.Year.ToString("0000"))
        dtpByYear.Value = Now
        dtpByRangeFrom.Value = Now
        dtpByRangeTo.Value = Now

        Dim TargetKey As RegistryKey
        TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application")
        btnExportExcel.Visible = If(TargetKey Is Nothing, False, True)
        TargetKey.Close()

        bgwGetClients.RunWorkerAsync()
    End Sub

    Private Sub rbtnByMonth_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnByMonth.CheckedChanged
        dtpByMonth.Enabled = rbtnByMonth.Checked
        dtpByMonth.Value = Date.Parse("01/" & Now.Month.ToString("00") & "/" & Now.Year.ToString("0000"))
    End Sub

    Private Sub rbtnByYear_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnByYear.CheckedChanged
        dtpByYear.Enabled = rbtnByYear.Checked
        dtpByYear.Value = Now
    End Sub

    Private Sub rbtnByRange_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnByRange.CheckedChanged
        dtpByRangeFrom.Enabled = rbtnByRange.Checked
        dtpByRangeTo.Enabled = rbtnByRange.Checked
        dtpByRangeFrom.Value = Now
        dtpByRangeTo.Value = Now
    End Sub

    Private Sub cboVehicles_Enter(sender As Object, e As EventArgs) Handles cboVehicles.Enter
        Try
            Dim proc As New Procedure

            Dim dt As New DataTable("vehicles")
            Dim col1 As New DataColumn("vehicle_id")
            Dim col2 As New DataColumn("vehicle")
            dt.Columns.Add(col1)
            dt.Columns.Add(col2)

            If proc.GetData("vehicles_getByClient", cboClients.SelectedValue) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row2 As DataRow = proc.Ds.Tables(0).Rows(i)
                        Dim row As DataRow = dt.NewRow
                        row.Item("vehicle_id") = row2("vehicle_id")
                        row.Item("vehicle") = row2("license_plate") & " (" &
                                              row2("brand") & " " &
                                              row2("model") & " " &
                                              row2("year") & " " &
                                              row2("color") & " )"
                        dt.Rows.Add(row)
                    Next
                End If

            End If

            cboVehicles.DataSource = Nothing
            cboVehicles.DataSource = dt
            cboVehicles.DisplayMember = "vehicle"
            cboVehicles.ValueMember = "vehicle_id"
            cboVehicles.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not bgwGetEvents.IsBusy Then
            bgwGetEvents.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwGetEvents_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetEvents.DoWork
        Try
            bgwGetEvents.ReportProgress(1)

            Dim query As String = "SELECT " &
                                      "case e.event_name " &
                                      "when 'acc on' then 'ENCENDIDO DE MOTOR' " &
                                      "When 'acc off' then 'APAGADO DE MOTOR' " &
                                      "when 'ac alarm' then 'ALERTA DE BATERÍA' " &
                                      "when 'low battery' then 'ALERTA DE BATERÍA' " &
                                      "when 'entrada geocerca' then 'ENTRADA A GEOCERCA' " &
                                      "when 'salida geocerca' then 'SALIDA DE GEOCERCA' " &
                                      "when 'velocidad' then 'ALERTA DE VELOCIDAD' " &
                                      "when 'speed' then 'ALERTA DE VELOCIDAD' " &
                                      "when 'motion' then 'ALERTA DE MOVIMIENTO' " &
                                      "when 'move' then 'ALERTA DE MOVIMIENTO' " &
                                      "end as 'event_name', " &
                                      "e.*, " &
                                      "d.device_id, " &
                                      "v.vehicle_id, " &
                                      "v.license_plate, " &
                                      "v.brand, " &
                                      "v.model, " &
                                      "v.type, " &
                                      "v.year, " &
                                      "v.color, " &
                                      "c.client_id, " &
                                      "c.first_name, " &
                                      "c.last_name, " &
                                      "g.name, " &
                                      "g.description " &
                                  "FROM events AS e " &
                                  "left JOIN devices AS d ON e.imei = d.imei " &
                                  "LEFT JOIN vehicles AS v ON d.device_id = v.device_id " &
                                  "LEFT JOIN clients AS c ON v.client_id = c.client_id " &
                                  "LEFT JOIN geofences AS g ON e.geofence_id = g.geofence_id " &
                                  "WHERE c.client_id IS NOT NULL AND v.vehicle_id IS NOT NULL AND d.device_id IS NOT NULL"

            If cboxClient.Checked Then
                If cboClients.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboClients.Focus()
                    Exit Sub
                Else
                    query = query & " AND c.client_id = [client_id]"
                    query = query.Replace("[client_id]", cboClients.SelectedValue)
                End If
            End If

            If cboxVehicle.Checked Then
                If cboVehicles.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboVehicles.Focus()
                    Exit Sub
                Else
                    query = query & " AND v.vehicle_id = [vehicle_id]"
                    query = query.Replace("[vehicle_id]", cboVehicles.SelectedValue)
                End If
            End If

            If cboxEvent.Checked Then
                If cboEvents.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un tipo de evento", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboEvents.Focus()
                    Exit Sub
                Else
                    '0 = BATERÍA
                    '1 = GEOCERCA
                    '2 = VELOCIDAD
                    '3 = IGNICIÓN
                    '4 = MOVIMIENTO

                    Select Case cboEvents.SelectedIndex
                        Case 0
                            query = query & " AND e.event_name IN('low battery','ac alarm')"
                            Exit Select
                        Case 1
                            query = query & " AND e.event_name IN('entrada geocerca','salida geocerca')"
                            Exit Select
                        Case 2
                            query = query & " AND e.event_name IN('speed','velocidad')"
                            Exit Select
                        Case 3
                            query = query & " AND e.event_name IN('acc on','acc off')"
                            Exit Select
                        Case 4
                            query = query & " AND e.event_name IN('motion','move')"
                            Exit Select
                    End Select
                End If
            End If

            If rbtnByMonth.Checked Then
                query = query & " AND MONTH(e.date_time) = [month] AND YEAR(e.date_time) = [year]"
                query = query.Replace("[month]", dtpByMonth.Value.Month)
                query = query.Replace("[year]", dtpByMonth.Value.Year)
            End If

            If rbtnByYear.Checked Then
                query = query & " AND YEAR(e.date_time) = [year]"
                query = query.Replace("[year]", dtpByYear.Value.Year)
            End If

            If rbtnByRange.Checked Then
                query = query & " AND DATE(e.date_time) BETWEEN '[dateFrom]' AND '[dateTo]'"
                query = query.Replace("[dateFrom]", dtpByRangeFrom.Value.ToString("yyyy-MM-dd"))
                query = query.Replace("[dateTo]", dtpByRangeTo.Value.ToString("yyyy-MM-dd"))
            End If

            If rbtnToday.Checked Then
                query = query & " AND DATE(e.date_time) = CURDATE()"
            End If

            query = query & " ORDER BY e.date_time DESC;"

            Dim proc As New Procedure

            If proc.GetData("global_procedure", query) Then
                bgwGetEvents.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwGetEvents.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetEvents.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetEvents_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetEvents.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                lblLoading.Text = "Buscando eventos... Por favor espere"
                pboxLoading.Visible = True
                Exit Select
            Case 2
                dgvEvents.Rows.Clear()
                dgvEvents.ScrollBars = ScrollBars.None
                DrawingControl.SuspendDrawing(dgvEvents)

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvEvents.Rows.Add()
                        dgvEvents.Rows(i).Cells("dgvEvents_client_name").Value = (row("first_name") & " " & If(row("last_name") Is DBNull.Value, "", row("last_name"))).ToString().Trim
                        dgvEvents.Rows(i).Cells("dgvEvents_license_plate").Value = row("license_plate")
                        dgvEvents.Rows(i).Cells("dgvEvents_imei").Value = row("imei")
                        dgvEvents.Rows(i).Cells("dgvEvents_date_time").Value = row("date_time")
                        dgvEvents.Rows(i).Cells("dgvEvents_latitude").Value = Math.Round(row("latitude"), 6)
                        dgvEvents.Rows(i).Cells("dgvEvents_longitude").Value = Math.Round(row("longitude"), 6)
                        dgvEvents.Rows(i).Cells("dgvEvents_event_name").Value = row("event_name")
                        dgvEvents.Rows(i).Cells("dgvEvents_client_id").Value = row("client_id")
                        dgvEvents.Rows(i).Cells("dgvEvents_vehicle_id").Value = row("vehicle_id")
                        dgvEvents.Rows(i).Cells("dgvEvents_device_id").Value = row("device_id")
                        dgvEvents.Rows(i).Cells("dgvEvents_event_id").Value = row("event_id")
                        dgvEvents.Rows(i).Cells("dgvEvents_geofence_id").Value = If(row("geofence_id") Is DBNull.Value, 0, row("geofence_id"))
                    Next
                End If

                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwGetEvents_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetEvents.RunWorkerCompleted
        Application.DoEvents()
        panelHeader.Enabled = True
        lblLoading.Text = dgvEvents.Rows.Count.ToString("00000") & " Eventos encontrados"
        pboxLoading.Visible = False
        dgvEvents.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvEvents)
    End Sub

    Private Sub dgvEvents_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvEvents.RowsAdded
        btnExportExcel.Enabled = dgvEvents.Rows.Count > 0
    End Sub

    Private Sub dgvEvents_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvEvents.RowsRemoved
        btnExportExcel.Enabled = dgvEvents.Rows.Count > 0
    End Sub

    Private Sub bgwExporting_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwExporting.DoWork
        Try
            bgwExporting.ReportProgress(1)

            Dim stream As Stream
            Dim writer As StreamWriter
            Dim rows As Integer = dgvEvents.Rows.Count
            Dim cols As Integer = dgvEvents.Columns.Count

            Dim line As String = ""
            Dim rowdata, column As Integer
            File.Delete(e.Argument.ToString())

            stream = File.OpenWrite(e.Argument.ToString())
            writer = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To cols - 6
                line = line & dgvEvents.Columns(column).HeaderText & ";"
            Next

            line = Mid(line, 1, line.Length - 1)
            writer.WriteLine(line)

            line = ""

            For rowdata = 0 To rows - 1
                For column = 0 To cols - 6
                    line = line & If(column = 2, "'", "") & dgvEvents.Item(column, rowdata).Value.ToString() & If(column = 2, "'", "") & ";"
                Next
                line = Mid(line, 1, line.Length - 1)
                writer.WriteLine(line)
                line = ""
            Next

            writer.Close()

            bgwExporting.ReportProgress(2, e.Argument.ToString())
        Catch ex As Exception
            bgwExporting.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwExporting_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwExporting.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                lblLoading.Text = "Exportando... Por favor espere"
                pboxLoading.Visible = True
                Exit Select
            Case 2

                Try
                    Process.Start("excel.exe", e.UserState.ToString())
                Catch ex As Exception
                End Try

                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwExporting_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwExporting.RunWorkerCompleted
        Application.DoEvents()
        panelHeader.Enabled = True
        lblLoading.Text = dgvEvents.Rows.Count.ToString("00000") & " Eventos encontrados"
        pboxLoading.Visible = False
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        If Not bgwExporting.IsBusy Then
            Dim filename As String = InputBox("Ingrese el nombre del archivo", "Mensaje del Sistema")

            If Not filename = "" Then
                Dim dir As New FolderBrowserDialog
                If dir.ShowDialog = DialogResult.OK Then
                    bgwExporting.RunWorkerAsync(dir.SelectedPath & "\" & filename & ".csv")
                End If
            End If
        End If
    End Sub
End Class