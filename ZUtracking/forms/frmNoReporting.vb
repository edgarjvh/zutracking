Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Win32

Public Class frmNoReporting

    Public Function sTiempo(dInicio As Date, dFin As Date) As String
        Dim functionReturnValue As String = Nothing
        functionReturnValue = CInt((dFin - dInicio).TotalSeconds / 86400 Mod 365) & " días, "
        functionReturnValue = (functionReturnValue & CInt((dFin - dInicio).TotalSeconds / 3600 Mod 24)) & " horas, "
        functionReturnValue = (functionReturnValue & CInt((dFin - dInicio).TotalSeconds / 60 Mod 60)) & " minutos, "
        functionReturnValue = (functionReturnValue & CInt((dFin - dInicio).TotalSeconds Mod 60)) & " segundos."
        Return functionReturnValue
    End Function

    Private Sub frmNoReporting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        Dim TargetKey As RegistryKey
        TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application")
        btnExportExcel.Visible = If(TargetKey Is Nothing, False, True)
        TargetKey.Close()

        numNoReporting.Value = My.Settings.noReportingInterval

        dgvNoReporting.ScrollBars = ScrollBars.None
        DrawingControl.SuspendDrawing(dgvNoReporting)

        getNoReporting.RunWorkerAsync()

        getDealers(0)
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Not getNoReporting.IsBusy Then
            dgvNoReporting.Rows.Clear()
            dgvNoReporting.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvNoReporting)

            getNoReporting.RunWorkerAsync()
        End If

    End Sub

    Private Sub frmNoReporting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
    End Sub

    Private Sub getNoReporting_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles getNoReporting.DoWork
        Try
            Dim proc As New Procedure

            If proc.GetData("current_locations_getNoReporting", My.Settings.noReportingInterval, cboDealers.SelectedValue) Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                        If If(row("device_id") Is DBNull.Value, 0, row("device_id")) > 0 AndAlso
                            If(row("vehicle_id") Is DBNull.Value, 0, row("vehicle_id")) > 0 AndAlso
                            If(row("client_id") Is DBNull.Value, 0, row("client_id")) > 0 Then

                            dgvNoReporting.Rows.Add(
                                                    If(row("priority") Is DBNull.Value, 0, row("priority")),
                                                    If(row("dealer_name") Is DBNull.Value, "", row("dealer_name")),
                                                    (If(row("first_name") Is DBNull.Value, "", row("first_name")) & " " & If(row("last_name") Is DBNull.Value, "", row("last_name"))).ToString().Trim,
                                                    If(row("phone_number1") Is DBNull.Value, "", row("phone_number1")),
                                                    If(row("phone_number2") Is DBNull.Value, "", If(row("phone_number2") = 0, "", row("phone_number2"))),
                                                    If(row("imei") Is DBNull.Value, "", row("imei")),
                                                    If(row("license_plate") Is DBNull.Value, "", row("license_plate")),
                                                    DirectCast(If(row("date_time") Is DBNull.Value, Now, row("date_time")), Date).ToString("dd/MM/yyyy hh:mm:ss tt"),
                                                    sTiempo(If(row("date_time") Is DBNull.Value, Now, row("date_time")), Now),
                                                    If(row("validation") Is DBNull.Value, "", DirectCast(row("date_time"), Date).ToString("dd/MM/yyyy hh:mm:ss tt")),
                                                    If(row("client_id") Is DBNull.Value, 0, row("client_id")),
                                                    If(row("dealer_id") Is DBNull.Value, 0, row("dealer_id")))
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

    Private Sub getNoReporting_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles getNoReporting.RunWorkerCompleted
        dgvNoReporting.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvNoReporting)

        lblCant.Text = dgvNoReporting.Rows.Count.ToString("0000")

        lblCant.ForeColor = If(dgvNoReporting.Rows.Count > 0, Color.Red, Color.Green)
    End Sub

    Private Sub numNoReporting_ValueChanged(sender As Object, e As EventArgs) Handles numNoReporting.ValueChanged
        My.Settings.noReportingInterval = numNoReporting.Value
        My.Settings.Save()
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
            Dim rows As Integer = dgvNoReporting.Rows.Count
            Dim cols As Integer = dgvNoReporting.Columns.Count

            Dim line As String = ""
            Dim rowdata, column As Integer
            File.Delete(e.Argument.ToString())

            stream = File.OpenWrite(e.Argument.ToString())
            writer = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To cols - 2
                line = line & dgvNoReporting.Columns(column).HeaderText & ";"
            Next

            line = Mid(line, 1, line.Length - 1)
            writer.WriteLine(line)

            line = ""

            For rowdata = 0 To rows - 1
                For column = 0 To cols - 2
                    line = line & dgvNoReporting.Item(column, rowdata).Value.ToString() & ";"
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
                panelLoading.Visible = True
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
        panelLoading.Visible = False
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try
    End Sub

    Private Sub cboDealers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDealers.SelectedIndexChanged
        If Not getNoReporting.IsBusy Then
            dgvNoReporting.Rows.Clear()
            dgvNoReporting.ScrollBars = ScrollBars.None
            DrawingControl.SuspendDrawing(dgvNoReporting)

            getNoReporting.RunWorkerAsync()
        End If
    End Sub
End Class