Imports System.ComponentModel

Public Class frmUsers

    Enum UserMode
        Registering
        Editing
    End Enum

    Dim curUserMode As UserMode = UserMode.Registering

    Private Sub btnNewContact_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        For Each ctl As Control In gboxData.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                If TypeOf ctl Is ZUControls.ZUNumericBox Or TypeOf ctl Is ZUControls.ZUTextBox Then
                    ctl.Text = ""
                End If
                ctl.Enabled = True
            End If
        Next

        btnNewUser.Enabled = False
        btnEditUser.Enabled = False
        btnSaveUser.Enabled = True
        btnDeleteUser.Enabled = False
        btnCancelUser.Enabled = True
        dgvUsers.Enabled = False
        curUserMode = UserMode.Registering

        txtDni.Focus()
    End Sub

    Private Sub btnCancelUser_Click(sender As Object, e As EventArgs) Handles btnCancelUser.Click
        For Each ctl As Control In gboxData.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                If TypeOf ctl Is ZUControls.ZUNumericBox Or TypeOf ctl Is ZUControls.ZUTextBox Then
                    ctl.Text = ""
                End If
                ctl.Enabled = False
            End If
        Next

        btnNewUser.Enabled = True
        btnEditUser.Enabled = False
        btnSaveUser.Enabled = False
        btnDeleteUser.Enabled = False
        btnCancelUser.Enabled = False
        dgvUsers.Enabled = True
    End Sub

    Private Sub btnEditUser_Click(sender As Object, e As EventArgs) Handles btnEditUser.Click
        For Each ctl As Control In gboxData.Controls
            If Not TypeOf ctl Is ZUControls.ZUButton Then
                ctl.Enabled = True
            End If
        Next

        btnNewUser.Enabled = False
        btnEditUser.Enabled = False
        btnSaveUser.Enabled = True
        btnDeleteUser.Enabled = False
        btnCancelUser.Enabled = True
        dgvUsers.Enabled = False
        curUserMode = UserMode.Editing

        txtDni.Focus()
    End Sub

    Private Sub btnSaveUser_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click
        If txtDni.Text.Trim = "" Then
            MsgBox("Debe ingresar la cédula del usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtDni.Focus()
            Exit Sub
        End If

        If txtFirstName.Text.Trim = "" Then
            MsgBox("Debe ingresar el o los nombres del usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtFirstName.Focus()
            Exit Sub
        End If

        If txtEmail.Text.Trim = "" Then
            MsgBox("Debe ingresar el correo electrónico del usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtEmail.Focus()
            Exit Sub
        End If

        If txtPhoneNumber1.Text.Trim = "" Then
            MsgBox("Debe ingresar teléfono principal del usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtPhoneNumber1.Focus()
            Exit Sub
        End If

        If txtAddress.Text.Trim = "" Then
            MsgBox("Debe ingresar la dirección del usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtAddress.Focus()
            Exit Sub
        End If

        If txtPass.Text.Trim = "" Then
            MsgBox("Debe ingresar la contraseña del usuario", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtPass.Focus()
            Exit Sub
        End If

        If Not bgwSavingUsers.IsBusy Then
            DrawingControl.SuspendDrawing(dgvUsers)
            dgvUsers.ScrollBars = ScrollBars.None
            bgwSavingUsers.RunWorkerAsync()
        End If
    End Sub

    Private Sub getUsers()
        dgvUsers.Rows.Clear()

        Try
            Dim proc As New Procedure

            If proc.GetData("users_getAll") Then
                If proc.Ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                        Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                        dgvUsers.Rows.Add()
                        dgvUsers.Rows(i).Cells("dgvUsers_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvUsers.Rows(i).Cells("dgvUsers_first_name").Value = If(row("first_name") Is DBNull.Value, "", row("first_name"))
                        dgvUsers.Rows(i).Cells("dgvUsers_last_name").Value = If(row("last_name") Is DBNull.Value, "", row("last_name"))
                        dgvUsers.Rows(i).Cells("dgvUsers_email").Value = If(row("email") Is DBNull.Value, "", row("email"))
                        dgvUsers.Rows(i).Cells("dgvUsers_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvUsers.Rows(i).Cells("dgvUsers_phone_number2").Value = If(row("phone_number2") Is DBNull.Value, Nothing, row("phone_number2"))
                        dgvUsers.Rows(i).Cells("dgvUsers_address").Value = If(row("address") Is DBNull.Value, "", row("address"))
                        dgvUsers.Rows(i).Cells("dgvUsers_pass").Value = If(row("pass") Is DBNull.Value, "", row("pass"))
                        dgvUsers.Rows(i).Cells("dgvUsers_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvUsers.Rows(i).Cells("dgvUsers_user_id").Value = If(row("user_id") Is DBNull.Value, 0, row("user_id"))
                    Next
                End If
            Else
                MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical, "Mensaje del Sistema")
        Finally
            dgvUsers.ScrollBars = ScrollBars.Both
            DrawingControl.ResumeDrawing(dgvUsers)
        End Try
    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

        dgvUsers.ScrollBars = ScrollBars.None
        DrawingControl.SuspendDrawing(dgvUsers)
        getUsers()
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex >= 0 Then
            Dim enc As New Encryptation
            txtDni.Text = dgvUsers.CurrentRow.Cells("dgvUsers_dni").Value
            txtFirstName.Text = dgvUsers.CurrentRow.Cells("dgvUsers_first_name").Value
            txtLastName.Text = dgvUsers.CurrentRow.Cells("dgvUsers_last_name").Value
            txtEmail.Text = dgvUsers.CurrentRow.Cells("dgvUsers_email").Value
            txtPhoneNumber1.Text = dgvUsers.CurrentRow.Cells("dgvUsers_phone_number1").Value
            txtPhoneNumber2.Text = If(dgvUsers.CurrentRow.Cells("dgvUsers_phone_number2").Value = 0, Nothing, dgvUsers.CurrentRow.Cells("dgvUsers_phone_number2").Value)
            txtAddress.Text = dgvUsers.CurrentRow.Cells("dgvUsers_address").Value
            txtPass.Text = enc.Decrypt(dgvUsers.CurrentRow.Cells("dgvUsers_pass").Value)
            cboxStatus.Checked = If(dgvUsers.CurrentRow.Cells("dgvUsers_status").Value = 1, True, False)

            For Each ctl As Control In gboxData.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton Then
                    ctl.Enabled = False
                End If
            Next

            btnNewUser.Enabled = True
            btnEditUser.Enabled = True
            btnSaveUser.Enabled = False
            btnDeleteUser.Enabled = True
            btnCancelUser.Enabled = True
        End If
    End Sub

    Private Sub dgvUsers_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvUsers.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            Dim enc As New Encryptation
            txtDni.Text = dgvUsers.CurrentRow.Cells("dgvUsers_dni").Value
            txtFirstName.Text = dgvUsers.CurrentRow.Cells("dgvUsers_first_name").Value
            txtLastName.Text = dgvUsers.CurrentRow.Cells("dgvUsers_last_name").Value
            txtEmail.Text = dgvUsers.CurrentRow.Cells("dgvUsers_email").Value
            txtPhoneNumber1.Text = dgvUsers.CurrentRow.Cells("dgvUsers_phone_number1").Value
            txtPhoneNumber2.Text = If(dgvUsers.CurrentRow.Cells("dgvUsers_phone_number2").Value = 0, Nothing, dgvUsers.CurrentRow.Cells("dgvUsers_phone_number2").Value)
            txtAddress.Text = dgvUsers.CurrentRow.Cells("dgvUsers_address").Value
            txtPass.Text = enc.Decrypt(dgvUsers.CurrentRow.Cells("dgvUsers_pass").Value)
            cboxStatus.Checked = If(dgvUsers.CurrentRow.Cells("dgvUsers_status").Value = 1, True, False)

            For Each ctl As Control In gboxData.Controls
                If Not TypeOf ctl Is ZUControls.ZUButton Then
                    ctl.Enabled = False
                End If
            Next

            btnNewUser.Enabled = True
            btnEditUser.Enabled = True
            btnSaveUser.Enabled = False
            btnDeleteUser.Enabled = True
            btnCancelUser.Enabled = True
        End If
    End Sub

    Private Sub bgwSavingUsers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwSavingUsers.DoWork
        Try
            bgwSavingUsers.ReportProgress(1)
            Dim proc As New Procedure
            Dim enc As New Encryptation

            If curUserMode = UserMode.Registering Then
                If proc.GetData("users_insert",
                                                txtDni.Text.Trim,
                                                txtFirstName.Text.Trim,
                                                txtLastName.Text.Trim,
                                                txtEmail.Text.Trim,
                                                txtAddress.Text.Trim,
                                                txtPhoneNumber1.Text.Trim,
                                                If(txtPhoneNumber2.Text.Trim = "", Nothing, txtPhoneNumber2.Text.Trim),
                                                enc.Encrypt(txtPass.Text.Trim),
                                                1,
                                                Nothing,
                                                If(cboxStatus.Checked, 1, 0)) Then

                    bgwSavingUsers.ReportProgress(2, proc.Ds.Tables(0))
                Else
                    bgwSavingUsers.ReportProgress(3, proc.ErrorMsg)
                End If
            Else
                If proc.GetData("users_update",
                                                dgvUsers.CurrentRow.Cells("dgvUsers_user_id").Value,
                                                txtDni.Text.Trim,
                                                txtFirstName.Text.Trim,
                                                txtLastName.Text.Trim,
                                                txtEmail.Text.Trim,
                                                txtAddress.Text.Trim,
                                                txtPhoneNumber1.Text.Trim,
                                                If(txtPhoneNumber2.Text.Trim = "", Nothing, txtPhoneNumber2.Text.Trim),
                                                enc.Encrypt(txtPass.Text.Trim),
                                                1,
                                                Nothing,
                                                If(cboxStatus.Checked, 1, 0)) Then

                    bgwSavingUsers.ReportProgress(2, proc.Ds.Tables(0))
                Else
                    bgwSavingUsers.ReportProgress(3, proc.ErrorMsg)
                End If
            End If
        Catch ex As Exception
            bgwSavingUsers.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwSavingUsers_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwSavingUsers.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                gboxData.Enabled = False
                dgvUsers.Enabled = False
                lblLoading.Text = "Guardando usuario... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                gboxData.Enabled = True
                dgvUsers.Enabled = True
                Call btnCancelUser_Click(Nothing, Nothing)

                dgvUsers.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvUsers.Rows.Add()
                        dgvUsers.Rows(i).Cells("dgvUsers_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvUsers.Rows(i).Cells("dgvUsers_first_name").Value = If(row("first_name") Is DBNull.Value, "", row("first_name"))
                        dgvUsers.Rows(i).Cells("dgvUsers_last_name").Value = If(row("last_name") Is DBNull.Value, "", row("last_name"))
                        dgvUsers.Rows(i).Cells("dgvUsers_email").Value = If(row("email") Is DBNull.Value, "", row("email"))
                        dgvUsers.Rows(i).Cells("dgvUsers_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvUsers.Rows(i).Cells("dgvUsers_phone_number2").Value = If(row("phone_number2") Is DBNull.Value, Nothing, row("phone_number2"))
                        dgvUsers.Rows(i).Cells("dgvUsers_address").Value = If(row("address") Is DBNull.Value, "", row("address"))
                        dgvUsers.Rows(i).Cells("dgvUsers_pass").Value = If(row("pass") Is DBNull.Value, "", row("pass"))
                        dgvUsers.Rows(i).Cells("dgvUsers_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvUsers.Rows(i).Cells("dgvUsers_user_id").Value = If(row("user_id") Is DBNull.Value, 0, row("user_id"))
                    Next
                End If

                Dim msg As String = If(curUserMode = UserMode.Registering, "Usuario ingresado exitosamente", "Usuario actualizado exitosamente")
                MsgBox(msg, MsgBoxStyle.Information, "Mensaje del Sistema")
                panelLoading.Visible = False
                Exit Select
            Case 3
                gboxData.Enabled = True
                dgvUsers.Enabled = True
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If MsgBox("¿Está seguro de eliminar el usuario actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If Not bgwDeletingUsers.IsBusy Then
                DrawingControl.SuspendDrawing(dgvUsers)
                dgvUsers.ScrollBars = ScrollBars.None
                bgwDeletingUsers.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwDeletingUsers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwDeletingUsers.DoWork
        Try
            bgwDeletingUsers.ReportProgress(1)
            Dim proc As New Procedure

            If proc.GetData("users_delete", dgvUsers.CurrentRow.Cells("dgvUsers_user_id").Value) Then
                bgwDeletingUsers.ReportProgress(2, proc.Ds.Tables(0))
            Else
                bgwDeletingUsers.ReportProgress(3, proc.ErrorMsg)
            End If
        Catch ex As Exception
            bgwDeletingUsers.ReportProgress(3, ex.Message)
        End Try
    End Sub

    Private Sub bgwDeletingUsers_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bgwDeletingUsers.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                gboxData.Enabled = False
                dgvUsers.Enabled = False
                lblLoading.Text = "Eliminando usuario... Por favor espere"
                panelLoading.Visible = True
                Exit Select
            Case 2
                gboxData.Enabled = True
                dgvUsers.Enabled = True
                Call btnCancelUser_Click(Nothing, Nothing)

                dgvUsers.Rows.Clear()

                If e.UserState.Rows.Count > 0 Then
                    For i = 0 To e.UserState.Rows.Count - 1
                        Dim row As DataRow = e.UserState.Rows(i)
                        dgvUsers.Rows.Add()
                        dgvUsers.Rows(i).Cells("dgvUsers_dni").Value = If(row("dni") Is DBNull.Value, 0, row("dni"))
                        dgvUsers.Rows(i).Cells("dgvUsers_first_name").Value = If(row("first_name") Is DBNull.Value, "", row("first_name"))
                        dgvUsers.Rows(i).Cells("dgvUsers_last_name").Value = If(row("last_name") Is DBNull.Value, "", row("last_name"))
                        dgvUsers.Rows(i).Cells("dgvUsers_email").Value = If(row("email") Is DBNull.Value, "", row("email"))
                        dgvUsers.Rows(i).Cells("dgvUsers_phone_number1").Value = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1"))
                        dgvUsers.Rows(i).Cells("dgvUsers_phone_number2").Value = If(row("phone_number2") Is DBNull.Value, Nothing, row("phone_number2"))
                        dgvUsers.Rows(i).Cells("dgvUsers_address").Value = If(row("address") Is DBNull.Value, "", row("address"))
                        dgvUsers.Rows(i).Cells("dgvUsers_pass").Value = If(row("pass") Is DBNull.Value, "", row("pass"))
                        dgvUsers.Rows(i).Cells("dgvUsers_status").Value = If(row("status") Is DBNull.Value, 0, row("status"))
                        dgvUsers.Rows(i).Cells("dgvUsers_user_id").Value = If(row("user_id") Is DBNull.Value, 0, row("user_id"))
                    Next
                End If

                MsgBox("Usuario eliminado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
                panelLoading.Visible = False
                Exit Select
            Case 3
                gboxData.Enabled = True
                dgvUsers.Enabled = True
                panelLoading.Visible = False
                MsgBox(e.UserState.ToString(), MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Select
        End Select
    End Sub

    Private Sub bgwSavingUsers_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwSavingUsers.RunWorkerCompleted
        DrawingControl.ResumeDrawing(dgvUsers)
        dgvUsers.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub bgwDeletingUsers_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwDeletingUsers.RunWorkerCompleted
        dgvUsers.ScrollBars = ScrollBars.Both
        DrawingControl.ResumeDrawing(dgvUsers)
    End Sub
End Class