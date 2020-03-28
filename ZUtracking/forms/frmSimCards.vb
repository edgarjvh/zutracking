Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Win32

Public Class frmSimCards

    Sub New()
        InitializeComponent()

        rbtnSimCardMaintaining.Parent = Me
        rbtnSimCardFiltering.Parent = Me

        rbtnSimCardMaintaining.Location = New Point(10, 1)
        rbtnSimCardFiltering.Location = New Point(10, 153)
    End Sub

    Dim curSimCardMode As SimCardMode = SimCardMode.Registering

    Enum SimCardMode
        Registering
        Editing
    End Enum

    Private Sub rbtnSimCardMaintaining_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSimCardMaintaining.CheckedChanged
        gboxSimCardMaintaining.Enabled = rbtnSimCardMaintaining.Checked
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSimCardFiltering.CheckedChanged
        For Each ctl As Control In gboxSimCardFiltering.Controls
            If TypeOf ctl Is CheckBox Then
                DirectCast(ctl, CheckBox).Checked = False
            End If
        Next

        gboxSimCardFiltering.Enabled = rbtnSimCardFiltering.Checked
    End Sub

    Private Sub frmSimCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        rbtnSimCardMaintaining.BringToFront()
        rbtnSimCardFiltering.BringToFront()

        Dim TargetKey As RegistryKey
        TargetKey = Registry.ClassesRoot.OpenSubKey("excel.application")
        btnExportExcel.Visible = If(TargetKey Is Nothing, False, True)
        TargetKey.Close()

        cboMOperator.Items.Add("DIGITEL")
        cboMOperator.Items.Add("MOVILNET")
        cboMOperator.Items.Add("MOVISTAR")
        cboFOperator.Items.Add("DIGITEL")
        cboFOperator.Items.Add("MOVILNET")
        cboFOperator.Items.Add("MOVISTAR")
    End Sub

    Private Sub cboxFOperator_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFOperator.CheckedChanged
        cboFOperator.Enabled = cboxFOperator.Checked
        cboFOperator.SelectedIndex = -1
    End Sub

    Private Sub cboxFSerialPhone_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFSerialPhone.CheckedChanged
        txtFSerialPhone.Enabled = cboxFSerialPhone.Checked
        txtFSerialPhone.Text = ""
    End Sub

    Private Sub cboxFApn_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFApn.CheckedChanged
        txtFApn.Enabled = cboxFApn.Checked
        txtFApn.Text = ""
    End Sub

    Private Sub cboxFStatus_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFStatus.CheckedChanged
        rbtnFActive.Checked = True
        panelStatusSimCard.Enabled = cboxFStatus.Checked
    End Sub

    Private Sub cboxFAsigned_CheckedChanged(sender As Object, e As EventArgs) Handles cboxFAsigned.CheckedChanged
        rbtnFAsignedYes.Checked = True
        panelAsignedSimCard.Enabled = cboxFAsigned.Checked
    End Sub

    Private Sub btnNewSimCard_Click(sender As Object, e As EventArgs) Handles btnNewSimCard.Click
        For Each ctl As Control In gboxSimCardMaintaining.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                ctl.Enabled = True
            End If

            btnNewSimCard.Enabled = False
            btnEditSimCard.Enabled = False
            btnSaveSimCard.Enabled = True
            btnDeleteSimCard.Enabled = False
            btnCancelSimCard.Enabled = True
            cboMOperator.Focus()
        Next
        rbtnSimCardFiltering.Enabled = False
        dgvSimCards.Enabled = False
        curSimCardMode = SimCardMode.Registering
    End Sub

    Private Sub btnEditSimCard_Click(sender As Object, e As EventArgs) Handles btnEditSimCard.Click
        For Each ctl As Control In gboxSimCardMaintaining.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                ctl.Enabled = True
            End If

            btnNewSimCard.Enabled = False
            btnEditSimCard.Enabled = False
            btnSaveSimCard.Enabled = True
            btnDeleteSimCard.Enabled = False
            btnCancelSimCard.Enabled = True
            cboMOperator.Focus()
        Next
        rbtnSimCardFiltering.Enabled = False
        dgvSimCards.Enabled = False
        curSimCardMode = SimCardMode.Editing
    End Sub

    Private Sub btnSaveSimCard_Click(sender As Object, e As EventArgs) Handles btnSaveSimCard.Click
        If cboMOperator.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la operadora telefónica de la simcard", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboMOperator.Focus()
            Exit Sub
        End If

        If txtMSerial.Text.Trim = "" Then
            MsgBox("Debe indicar el serial de la simcard", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtMSerial.Focus()
            Exit Sub
        End If

        If txtMPhoneNumber.Text.Trim = "" Then
            MsgBox("Debe indicar el número telefónico de la simcard", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtMPhoneNumber.Focus()
            Exit Sub
        End If

        If txtMApn.Text.Trim = "" Then
            MsgBox("Debe indicar el apn de la simcard", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtMApn.Focus()
            Exit Sub
        End If

        If Not bgwSavingSimCard.IsBusy Then
            bgwSavingSimCard.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSavingSimCard_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSavingSimCard.DoWork
        Try
            bgwSavingSimCard.ReportProgress(1)

            Dim proc As New Procedure

            If curSimCardMode = SimCardMode.Registering Then
                If proc.GetData("simcards_insert",
                                            cboMOperator.Text,
                                            txtMSerial.Text.Trim,
                                            txtMPhoneNumber.Text.Trim,
                                            txtMApn.Text.Trim,
                                            If(cboxMCall.Checked, 1, 0),
                                            If(cboxMSms.Checked, 1, 0),
                                            If(cboxMData.Checked, 1, 0),
                                            If(cboxMStatus.Checked, 1, 0),
                                            txtMObservations.Text.Trim) Then
                    bgwSavingSimCard.ReportProgress(2)
                Else
                    bgwSavingSimCard.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("simcards_update",
                                            dgvSimCards.CurrentRow.Cells("dgvSimCards_simcard_id").Value,
                                            cboMOperator.Text,
                                            txtMSerial.Text.Trim,
                                            txtMPhoneNumber.Text.Trim,
                                            txtMApn.Text.Trim,
                                            If(cboxMCall.Checked, 1, 0),
                                            If(cboxMSms.Checked, 1, 0),
                                            If(cboxMData.Checked, 1, 0),
                                            If(cboxMStatus.Checked, 1, 0),
                                            txtMObservations.Text.Trim) Then
                    bgwSavingSimCard.ReportProgress(2)
                Else
                    bgwSavingSimCard.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSavingSimCard.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingSimCard_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSavingSimCard.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                rbtnSimCardMaintaining.Enabled = False
                rbtnSimCardFiltering.Enabled = False
                panelHeader.Enabled = False
                dgvSimCards.Enabled = False
                lblLoading.Text = "Guardando simcard... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                panelLoading.Visible = False
                Dim msg As String = If(curSimCardMode = SimCardMode.Registering, "Simcard ingresada exitosamente", "Simcard actualizada exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True

                btnCancelSimCard_Click(Nothing, Nothing)
                dgvSimCards.Rows.Clear()
                Exit Select
            Case 3
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                Exit Select
        End Select
    End Sub

    Private Sub btnCancelSimCard_Click(sender As Object, e As EventArgs) Handles btnCancelSimCard.Click
        For Each ctl As Control In gboxSimCardMaintaining.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                If TypeOf ctl Is ZUControls.ZUComboBox Then
                    DirectCast(ctl, ZUControls.ZUComboBox).SelectedIndex = -1
                End If

                If TypeOf ctl Is ZUControls.ZUNumericBox Then
                    DirectCast(ctl, ZUControls.ZUNumericBox).Text = ""
                End If

                If TypeOf ctl Is ZUControls.ZUTextBox Then
                    DirectCast(ctl, ZUControls.ZUTextBox).Text = ""
                End If

                If TypeOf ctl Is CheckBox Then
                    DirectCast(ctl, CheckBox).Checked = False
                End If
            End If

            ctl.Enabled = False
        Next

        btnNewSimCard.Enabled = True
        btnEditSimCard.Enabled = False
        btnSaveSimCard.Enabled = False
        btnDeleteSimCard.Enabled = False
        btnCancelSimCard.Enabled = False
        dgvSimCards.Enabled = True
    End Sub

    Private Sub btnDeleteSimCard_Click(sender As Object, e As EventArgs) Handles btnDeleteSimCard.Click
        If MsgBox("¿Está seguro de eliminar la simcard actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If Not bgwDeletingSimCard.IsBusy Then
                bgwDeletingSimCard.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwDeletingSimCard_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeletingSimCard.DoWork
        Try
            bgwDeletingSimCard.ReportProgress(1)

            Dim proc As New Procedure

            If proc.GetData("simcards_delete", dgvSimCards.CurrentRow.Cells("dgvSimCards_simcard_id").Value) Then
                bgwDeletingSimCard.ReportProgress(2)
            Else
                bgwDeletingSimCard.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingSimCard.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingSimCard_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeletingSimCard.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                rbtnSimCardMaintaining.Enabled = False
                rbtnSimCardFiltering.Enabled = False
                panelHeader.Enabled = False
                dgvSimCards.Enabled = False
                lblLoading.Text = "Eliminando simcard... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                panelLoading.Visible = False
                MsgBox("Simcard eliminada exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True

                btnCancelSimCard_Click(Nothing, Nothing)
                Exit Select
            Case 3
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                Exit Select
        End Select
    End Sub

    Private Sub dgvSimCards_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSimCards.CellClick
        If e.RowIndex >= 0 Then
            cboMOperator.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_operator").Value.ToString()
            txtMSerial.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_serial").Value.ToString()
            txtMPhoneNumber.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_phone_number").Value.ToString()
            txtMApn.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_apn").Value.ToString()
            txtMObservations.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_observations").Value.ToString()
            cboxMCall.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_call_service").Value = 1, True, False)
            cboxMSms.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_sms_service").Value = 1, True, False)
            cboxMData.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_data_service").Value = 1, True, False)
            cboxMStatus.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_status").Value = 1, True, False)

            For Each ctl As Control In gboxSimCardMaintaining.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton Then
                    ctl.Enabled = False
                End If
            Next

            btnNewSimCard.Enabled = True
            btnEditSimCard.Enabled = True
            btnSaveSimCard.Enabled = False
            btnDeleteSimCard.Enabled = True
            btnCancelSimCard.Enabled = True
        End If
    End Sub

    Private Sub dgvSimCards_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvSimCards.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            If Not dgvSimCards.CurrentRow Is Nothing Then
                cboMOperator.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_operator").Value
                txtMSerial.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_serial").Value
                txtMPhoneNumber.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_phone_number").Value
                txtMApn.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_apn").Value
                txtMObservations.Text = dgvSimCards.CurrentRow.Cells("dgvSimCards_observations").Value
                cboxMCall.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_call_service").Value = 1, True, False)
                cboxMSms.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_sms_service").Value = 1, True, False)
                cboxMData.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_data_service").Value = 1, True, False)
                cboxMStatus.Checked = If(dgvSimCards.CurrentRow.Cells("dgvSimCards_status").Value = 1, True, False)

                For Each ctl As Control In gboxSimCardMaintaining.Controls
                    If Not TypeOf ctl Is ZUControls.ZUButton Then
                        ctl.Enabled = True
                    End If
                Next

                btnNewSimCard.Enabled = True
                btnEditSimCard.Enabled = True
                btnSaveSimCard.Enabled = False
                btnDeleteSimCard.Enabled = True
                btnCancelSimCard.Enabled = True

                cboMOperator.Focus()
            End If
        End If
    End Sub

    Private Sub btnSearchSimCards_Click(sender As Object, e As EventArgs) Handles btnSearchSimCards.Click
        If Not bgwSearchingSimCards.IsBusy Then
            bgwSearchingSimCards.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgwSearchingSimCards_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSearchingSimCards.DoWork
        Try
            bgwSearchingSimCards.ReportProgress(1)

            Dim query As String = "select * from simcards where simcard_id > 0"

            If cboxFOperator.Checked Then
                If cboFOperator.SelectedIndex = -1 Then
                    MsgBox("Debe indicar una operadora", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cboFOperator.Focus()
                    bgwSearchingSimCards.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " and operator = [operator]"
                End If
            End If

            If cboxFSerialPhone.Checked Then
                If txtFSerialPhone.Text.Trim = "" Then
                    MsgBox("Debe indicar el serial o número telefónico", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    txtFSerialPhone.Focus()
                    bgwSearchingSimCards.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " and (serial like [serial] or phone_number like [phone_number])"
                End If
            End If

            If cboxFApn.Checked Then
                If txtFApn.Text.Trim = "" Then
                    MsgBox("Debe indicar un apn", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    txtFApn.Focus()
                    bgwSearchingSimCards.ReportProgress(2)
                    Exit Sub
                Else
                    query = query & " and apn like [apn]"
                End If
            End If

            If cboxFStatus.Checked Then
                query = query & " and status = [status]"
            End If

            If cboxFAsigned.Checked Then
                query = query & " and asigned = [asigned]"
            End If

            query = query & ";"

            If query.Contains("[operator]") Then
                Dim oper As String

                Dim index As Integer = cboFOperator.SelectedIndex
                Dim text As String = cboFOperator.SelectedText
                Select Case index
                    Case 0
                        oper = "DIGITEL"
                        Exit Select
                    Case 1
                        oper = "MOVILNET"
                        Exit Select
                    Case 2
                        oper = "MOVISTAR"
                        Exit Select
                    Case Else
                        oper = ""
                End Select

                query = query.Replace("[operator]", Chr(34) & oper & Chr(34))
            End If

            If query.Contains("[serial]") Then
                query = query.Replace("[serial]", Chr(39) & Chr(37) & txtFSerialPhone.Text.Trim & Chr(37) & Chr(39))
            End If

            If query.Contains("[phone_number]") Then
                query = query.Replace("[phone_number]", Chr(39) & Chr(37) & txtFSerialPhone.Text.Trim & Chr(37) & Chr(39))
            End If

            If query.Contains("[apn]") Then
                query = query.Replace("[apn]", Chr(39) & Chr(37) & txtFApn.Text.Trim & Chr(37) & Chr(39))
            End If

            If query.Contains("[status]") Then
                query = query.Replace("[status]", If(rbtnFActive.Checked, 1, 0))
            End If

            If query.Contains("[asigned]") Then
                query = query.Replace("[asigned]", If(rbtnFAsignedYes.Checked, 1, 0))
            End If

            Dim proc As New Procedure

            If proc.GetData("global_procedure", query) Then
                bgwSearchingSimCards.ReportProgress(3, proc.Ds.Tables(0))
            Else
                bgwSearchingSimCards.ReportProgress(4, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwSearchingSimCards.ReportProgress(4, ex.Message)
        End Try
    End Sub

    Private Sub bgwSearchingSimCards_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSearchingSimCards.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                dgvSimCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                dgvSimCards.ScrollBars = ScrollBars.None
                DrawingControl.SuspendDrawing(dgvSimCards)

                rbtnSimCardMaintaining.Enabled = False
                rbtnSimCardFiltering.Enabled = False
                panelHeader.Enabled = False
                dgvSimCards.Enabled = False
                lblLoading.Text = "Buscando simcards... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                panelLoading.Visible = False
                Exit Select
            Case 3
                dgvSimCards.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvSimCards.Rows.Add()
                        dgvSimCards.Rows(i).Cells("dgvSimCards_operator").Value = If(row("operator") Is DBNull.Value, "", row("operator"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_serial").Value = If(row("serial") Is DBNull.Value, "", row("serial"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_phone_number").Value = If(row("phone_number") Is DBNull.Value, 0, row("phone_number"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_apn").Value = If(row("apn") Is DBNull.Value, "", row("apn"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_call_service").Value = If(row("call_service") Is DBNull.Value, 0, row("call_service"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_sms_service").Value = If(row("sms_service") Is DBNull.Value, 0, row("sms_service"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_data_service").Value = If(row("data_service") Is DBNull.Value, 0, row("data_service"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_asigned").Value = If(row("asigned") Is DBNull.Value, 0, row("asigned"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_observations").Value = If(row("observations") Is DBNull.Value, "", row("observations"))
                        dgvSimCards.Rows(i).Cells("dgvSimCards_simcard_id").Value = If(row("simcard_id") Is DBNull.Value, 0, row("simcard_id"))
                    Next
                End If

                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                panelLoading.Visible = False
                Exit Select
            Case 4
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub dgvSimCards_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvSimCards.RowsAdded
        lblResult.Text = dgvSimCards.Rows.Count.ToString("0000") & " registros encontrados"
        lblResult.Visible = dgvSimCards.Rows.Count > 0
        btnExportExcel.Enabled = dgvSimCards.Rows.Count > 0
    End Sub

    Private Sub dgvSimCards_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvSimCards.RowsRemoved
        lblResult.Text = dgvSimCards.Rows.Count.ToString("0000") & " registros encontrados"
        lblResult.Visible = dgvSimCards.Rows.Count > 0
        btnExportExcel.Enabled = dgvSimCards.Rows.Count > 0
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
            Dim rows As Integer = dgvSimCards.Rows.Count
            Dim cols As Integer = dgvSimCards.Columns.Count

            Dim line As String = ""
            Dim rowdata, column As Integer
            File.Delete(e.Argument.ToString())

            stream = File.OpenWrite(e.Argument.ToString())
            writer = New StreamWriter(stream, System.Text.Encoding.UTF8)

            For column = 0 To cols - 2
                line = line & dgvSimCards.Columns(column).HeaderText & ";"
            Next

            line = Mid(line, 1, line.Length - 1)
            writer.WriteLine(line)

            line = ""

            For rowdata = 0 To rows - 1
                For column = 0 To cols - 2
                    If column >= 5 Then
                        If column = 8 Then
                            line = line & If(dgvSimCards.Item(column, rowdata).Value.ToString() = "1", "ACTIVO", "SUSPENDIDO") & ";"
                        Else
                            line = line & If(dgvSimCards.Item(column, rowdata).Value.ToString() = "1", "SI", "NO") & ";"
                        End If
                    Else
                        line = line & dgvSimCards.Item(column, rowdata).Value & ";"
                    End If
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
                rbtnSimCardMaintaining.Enabled = False
                rbtnSimCardFiltering.Enabled = False
                panelHeader.Enabled = False
                dgvSimCards.Enabled = False
                lblLoading.Text = "Exportando... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                panelLoading.Visible = False

                Try
                    Process.Start("excel.exe", e.UserState.ToString())
                Catch ex As Exception
                End Try

                Exit Select
            Case 3
                rbtnSimCardMaintaining.Enabled = True
                rbtnSimCardFiltering.Enabled = True
                panelHeader.Enabled = True
                dgvSimCards.Enabled = True
                panelLoading.Visible = False

                MsgBox(e.UserState.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub txtFSerialPhone_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub bgwSearchingSimCards_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSearchingSimCards.RunWorkerCompleted
        dgvSimCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvSimCards.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvSimCards)
    End Sub
End Class