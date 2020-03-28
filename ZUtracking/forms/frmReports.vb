Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Win32

Public Class frmReports
    Private Sub bgwGetClientsUsersReportTypes_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwGetClientsUsersReportTypes.DoWork
        Try
            bgwGetClientsUsersReportTypes.ReportProgress(1)

            Dim proc As New Procedure

            If proc.GetData("reports_getClientsUsersReportTypes") Then
                bgwGetClientsUsersReportTypes.ReportProgress(2, proc.Ds.Tables)
            Else
                bgwGetClientsUsersReportTypes.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetClientsUsersReportTypes.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetClientsUsersReportTypes_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetClientsUsersReportTypes.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                lblLoading.Text = "Iniciando... Por favor espere"
                pboxLoading.Visible = True
                Exit Select
            Case 2
                lblLoading.Text = "Cargando lista de clientes... Por favor espere"

                If e.UserState(0).Rows.Count > 0 Then
                    Dim dt As New DataTable("clients")
                    Dim col1 As New DataColumn("client_id")
                    Dim col2 As New DataColumn("client_name")
                    dt.Columns.Add(col1)
                    dt.Columns.Add(col2)

                    For i = 0 To e.UserState(0).Rows.Count - 1
                        Dim row2 As DataRow = e.UserState(0).Rows(i)
                        Dim row As DataRow = dt.NewRow
                        row.Item("client_id") = row2("client_id")
                        row.Item("client_name") = (row2("first_name") & " " & If(row2("last_name") Is DBNull.Value, "", row2("last_name"))).ToString().Trim
                        dt.Rows.Add(row)
                    Next

                    cboClients.DataSource = dt
                    cboClients.DisplayMember = "client_name"
                    cboClients.ValueMember = "client_id"
                End If

                lblLoading.Text = "Cargando lista de usuarios... Por favor espere"

                If e.UserState(1).Rows.Count > 0 Then
                    Dim dt As New DataTable("users")
                    Dim col1 As New DataColumn("user_id")
                    Dim col2 As New DataColumn("user_name")
                    dt.Columns.Add(col1)
                    dt.Columns.Add(col2)

                    For i = 0 To e.UserState(1).Rows.Count - 1
                        Dim row2 As DataRow = e.UserState(1).Rows(i)
                        Dim row As DataRow = dt.NewRow
                        row.Item("user_id") = row2("user_id")
                        row.Item("user_name") = (row2("first_name") & " " & If(row2("last_name") Is DBNull.Value, "", row2("last_name"))).ToString().Trim
                        dt.Rows.Add(row)
                    Next

                    cboUsers.DataSource = dt
                    cboUsers.DisplayMember = "user_name"
                    cboUsers.ValueMember = "user_id"
                End If

                lblLoading.Text = "Cargando lista de tipos de reportes... Por favor espere"

                If e.UserState(2).Rows.Count > 0 Then
                    Dim dt As New DataTable("reporTypes")
                    Dim col1 As New DataColumn("report_type_id")
                    Dim col2 As New DataColumn("report_name")
                    dt.Columns.Add(col1)
                    dt.Columns.Add(col2)

                    For i = 0 To e.UserState(2).Rows.Count - 1
                        Dim row2 As DataRow = e.UserState(2).Rows(i)
                        Dim row As DataRow = dt.NewRow
                        row.Item("report_type_id") = row2("report_type_id")
                        row.Item("report_name") = row2("report_name")
                        dt.Rows.Add(row)
                    Next

                    cboReportTypes.DataSource = dt
                    cboReportTypes.DisplayMember = "report_name"
                    cboReportTypes.ValueMember = "report_type_id"
                End If

                Exit Select
            Case 3
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwGetClientsUsersReportTypes_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetClientsUsersReportTypes.RunWorkerCompleted
        panelHeader.Enabled = True
        lblLoading.Text = ""
        pboxLoading.Visible = False
        cboClients.SelectedIndex = -1
        cboUsers.SelectedIndex = -1
        cboReportTypes.SelectedIndex = -1
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        bgwGetClientsUsersReportTypes.RunWorkerAsync()
        dtpByMonth.Value = Date.Parse("01/" & Now.Month.ToString("00") & "/" & Now.Year.ToString("0000"))
        dtpByYear.Value = Now
        dtpByRangeFrom.Value = Now
        dtpByRangeTo.Value = Now

        Dim TargetKey As RegistryKey
        TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application")
        btnExportExcel.Visible = If(TargetKey Is Nothing, False, True)
        TargetKey.Close()
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
        If cboxVehicle.Checked Then
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
                                                  row2("color") & ")"
                            dt.Rows.Add(row)
                        Next
                    End If
                Else
                    MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
                End If
                cboVehicles.DataSource = Nothing

                cboVehicles.DataSource = dt
                cboVehicles.DisplayMember = "vehicle"
                cboVehicles.ValueMember = "vehicle_id"
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

            cboVehicles.Enabled = True
            cboVehicles.SelectedIndex = -1
        Else
            cboVehicles.Enabled = False
            cboVehicles.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboxUser_CheckedChanged(sender As Object, e As EventArgs) Handles cboxUser.CheckedChanged
        cboUsers.Enabled = cboxUser.Checked
        cboUsers.SelectedIndex = -1
    End Sub

    Private Sub cboxReportType_CheckedChanged(sender As Object, e As EventArgs) Handles cboxReportType.CheckedChanged
        cboReportTypes.Enabled = cboxReportType.Checked
        cboReportTypes.SelectedIndex = -1
    End Sub

    Private Sub cboxCommunicationType_CheckedChanged(sender As Object, e As EventArgs) Handles cboxCommunicationType.CheckedChanged
        dgvReports.Columns("dgvReports_communication_type").Visible = cboxCommunicationType.Checked
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not bgwGetReports.IsBusy Then

            If cboxUser.Checked AndAlso cboUsers.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboUsers.Focus()
                Exit Sub
            End If

            If cboxReportType.Checked AndAlso cboReportTypes.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un tipo de reporte", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cboReportTypes.Focus()
                Exit Sub
            End If

            If rbtnByRange.Checked Then
                If dtpByRangeFrom.Value > dtpByRangeTo.Value Then
                    MsgBox("La fecha <desde> debe ser menor que la fecha <hasta>", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    dtpByRangeFrom.Focus()
                    Exit Sub
                End If
            End If

            dgvReports.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvReports)
            bgwGetReports.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwGetReports_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwGetReports.DoWork
        Try
            bgwGetReports.ReportProgress(1)

            Dim query As String = "SELECT * FROM reports AS r " &
                                  "LEFT JOIN clients AS c ON r.client_id = c.client_id " &
                                  "LEFT JOIN vehicles AS v ON r.vehicle_id = v.vehicle_id " &
                                  "LEFT JOIN report_types AS t ON r.report_type_id = t.report_type_id " &
                                  "LEFT JOIN users AS u ON r.user_id = u.user_id " &
                                  "WHERE c.client_id IS NOT NULL AND v.vehicle_id IS NOT NULL"

            If cboxClient.Checked Then
                If cboClients.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un cliente", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboClients.Focus()
                    bgwGetReports.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " AND r.client_id = [client_id]"
                    query = query.Replace("[client_id]", cboClients.SelectedValue)
                End If
            End If

            If cboxVehicle.Checked Then
                If cboVehicles.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un vehículo", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboVehicles.Focus()
                    bgwGetReports.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " AND r.vehicle_id = [vehicle_id]"
                    query = query.Replace("[vehicle_id]", cboVehicles.SelectedValue)
                End If
            End If

            If cboxUser.Checked Then
                If cboUsers.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboUsers.Focus()
                    bgwGetReports.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " AND r.user_id = [user_id]"
                    query = query.Replace("[user_id]", cboUsers.SelectedValue)
                End If
            End If

            If cboxReportType.Checked Then
                If cboReportTypes.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un tipo de reporte", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboReportTypes.Focus()
                    bgwGetReports.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " AND r.report_type_id = [report_type_id]"
                    query = query.Replace("[report_type_id]", cboReportTypes.SelectedValue)
                End If
            End If

            If rbtnByMonth.Checked Then
                query = query & " AND MONTH(r.date_time) = [month] AND YEAR(r.date_time) = [year]"
                query = query.Replace("[month]", dtpByMonth.Value.Month)
                query = query.Replace("[year]", dtpByMonth.Value.Year)
            End If

            If rbtnByYear.Checked Then
                query = query & " AND YEAR(r.date_time) = [year]"
                query = query.Replace("[year]", dtpByYear.Value.Year)
            End If

            If rbtnByRange.Checked Then
                query = query & " AND r.date_time BETWEEN [dateFrom] AND [dateTo]"
                query = query.Replace("[date_from]", dtpByRangeFrom.Value.ToString("yyyy-MM-dd"))
                query = query.Replace("[date_to]", dtpByRangeTo.Value.ToString("yyyy-MM-dd"))
            End If

            If rbtnToday.Checked Then
                query = query & " AND DATE(r.date_time) = CURDATE()"
            End If

            query = query & " ORDER BY r.date_time DESC;"

            Dim proc As New Procedure

            If proc.GetData("global_procedure", query) Then
                bgwGetReports.ReportProgress(3, proc.Ds.Tables(0))
            Else
                bgwGetReports.ReportProgress(4, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwGetReports.ReportProgress(4, ex.Message)
        End Try
    End Sub

    Private Sub bgwGetReports_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwGetReports.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                panelHeader.Enabled = False
                dgvReports.Rows.Clear()
                lblLoading.Text = "Buscando reportes... Por favor espere"
                pboxLoading.Visible = True
                Exit Select
            Case 2
                panelHeader.Enabled = True
                lblLoading.Text = ""
                pboxLoading.Visible = False
                Exit Select
            Case 3
                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvReports.Rows.Add()
                        dgvReports.Rows(i).Cells("dgvReports_client_name").Value = (row("first_name") & " " & If(row("last_name") Is DBNull.Value, "", row("last_name"))).ToString().Trim
                        dgvReports.Rows(i).Cells("dgvReports_license_plate").Value = row("license_plate")
                        dgvReports.Rows(i).Cells("dgvReports_user_name").Value = (row("first_name") & " " & If(row("last_name") Is DBNull.Value, "", row("last_name1"))).ToString().Trim
                        dgvReports.Rows(i).Cells("dgvReports_date_time").Value = row("date_time")
                        dgvReports.Rows(i).Cells("dgvReports_report_type_name").Value = If(row("report_name") Is DBNull.Value, "", row("report_name"))
                        dgvReports.Rows(i).Cells("dgvReports_communication_type").Value = If(row("communication_mode") Is DBNull.Value, "", row("communication_mode"))
                        dgvReports.Rows(i).Cells("dgvReports_transmitter").Value = If(row("transmitter") Is DBNull.Value, "", row("transmitter"))
                        dgvReports.Rows(i).Cells("dgvReports_receiver").Value = If(row("receiver") Is DBNull.Value, "", row("receiver"))
                        dgvReports.Rows(i).Cells("dgvReports_description").Value = row("description")
                        dgvReports.Rows(i).Cells("dgvReports_validation_date").Value = If(row("validation") Is DBNull.Value, Nothing, DirectCast(row("validation"), Date))
                        dgvReports.Rows(i).Cells("dgvReports_report_id").Value = row("report_id")
                        dgvReports.Rows(i).Cells("dgvReports_client_id").Value = row("client_id")
                        dgvReports.Rows(i).Cells("dgvReports_vehicle_id").Value = row("vehicle_id")
                        dgvReports.Rows(i).Cells("dgvReports_user_id").Value = row("user_id")
                        dgvReports.Rows(i).Cells("dgvReports_report_type_id").Value = row("report_type_id")
                    Next
                End If

                panelHeader.Enabled = True
                lblLoading.Text = dgvReports.Rows.Count.ToString("0000") & " Reportes encontrados"
                pboxLoading.Visible = False
                Exit Select
            Case 4
                panelHeader.Enabled = True
                lblLoading.Text = ""
                pboxLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub dgvReports_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvReports.RowsAdded
        btnExportExcel.Enabled = dgvReports.Rows.Count > 0
    End Sub

    Private Sub dgvReports_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvReports.RowsRemoved
        btnExportExcel.Enabled = dgvReports.Rows.Count > 0
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

    Private Sub bgwExporting_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwExporting.DoWork
        Try
            bgwExporting.ReportProgress(1)

            Dim stream As Stream
            Dim writer As StreamWriter
            Dim rows As Integer = dgvReports.Rows.Count
            Dim cols As Integer = dgvReports.Columns.Count

            Dim line As String = ""
            Dim rowdata, column As Integer
            File.Delete(e.Argument.ToString())

            stream = File.OpenWrite(e.Argument.ToString())
            writer = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To cols - 6
                line = line & dgvReports.Columns(column).HeaderText & ";"
            Next

            line = Mid(line, 1, line.Length - 1)
            writer.WriteLine(line)

            line = ""

            For rowdata = 0 To rows - 1
                For column = 0 To cols - 6
                    line = line & dgvReports.Item(column, rowdata).Value.ToString() & ";"
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
        lblLoading.Text = dgvReports.Rows.Count.ToString("00000") & " Reportes encontrados"
        pboxLoading.Visible = False
    End Sub

    Private Sub bgwGetReports_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwGetReports.RunWorkerCompleted
        dgvReports.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvReports)
    End Sub
End Class