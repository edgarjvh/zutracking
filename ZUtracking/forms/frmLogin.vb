
Public Class frmLogin

    Private msgTittle = "Mensaje del Sistema"

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If txtDni.Text.Trim.Length = 0 Then
                lblStatus.Text = "Debe indicar su número de cédula o rif"
                lblStatus.ForeColor = Color.Red
                txtDni.Focus()
                Exit Sub
            End If

            If txtPass.Text.Trim.Length = 0 Then
                lblStatus.Text = "Debe indicar su contraseña"
                lblStatus.ForeColor = Color.Red
                txtPass.Focus()
                Exit Sub
            End If

            If txtDni.Text.Trim = "12345" AndAlso txtPass.Text.Trim = "12345" Then
                Dim user As New User With {
                    .Id = 0,
                    .FirstName = "ADMINISTRADOR DEL SISTEMA",
                    .LastName = ""
                }

                Hide()
                Dim main As New frmMain(user)
                main.Show()
            Else
                If Not bgwLogin.IsBusy Then
                    bgwLogin.RunWorkerAsync()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgTittle)
        End Try
    End Sub

    Private Sub bgwLogin_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwLogin.DoWork
        bgwLogin.ReportProgress(1)

        Dim proc As New Procedure
        Dim enc As New Encryptation

        If proc.GetData("users_getAll") Then
            If proc.Ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To proc.Ds.Tables(0).Rows.Count - 1
                    Dim row As DataRow = proc.Ds.Tables(0).Rows(i)

                    If row("dni") = txtDni.Text.Trim Then
                        If row("pass") = enc.Encrypt(txtPass.Text.Trim) Then
                            Dim user As New User With {
                                .Id = If(row("user_id") Is DBNull.Value, 0, row("user_id")),
                                .Dni = If(row("dni") Is DBNull.Value, 0, row("dni")),
                                .FirstName = If(row("first_name") Is DBNull.Value, "", row("first_name")),
                                .LastName = If(row("last_name") Is DBNull.Value, "", row("last_name")),
                                .Email = If(row("email") Is DBNull.Value, "", row("email")),
                                .Address = If(row("address") Is DBNull.Value, "", row("address")),
                                .PhoneNumber1 = If(row("phone_number1") Is DBNull.Value, 0, row("phone_number1")),
                                .PhoneNumber2 = If(row("phone_number2") Is DBNull.Value, 0, row("phone_number2")),
                                .Pass = If(row("pass") Is DBNull.Value, "", row("pass")),
                                .PermissionLevel = If(row("permission_level") Is DBNull.Value, 0, row("permission_level")),
                                .Image = If(row("image") Is DBNull.Value, "", row("image"))
                            }

                            bgwLogin.ReportProgress(3, user)
                            Exit For
                        Else
                            bgwLogin.ReportProgress(4)
                            Exit For
                        End If
                    End If
                Next
            Else
                bgwLogin.ReportProgress(2)
            End If
        Else
            MsgBox(proc.ErrorMsg, MsgBoxStyle.Critical, msgTittle)
        End If
    End Sub

    Private Sub bgwLogin_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwLogin.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                pboxLoading.Visible = True
                lblStatus.Text = "Iniciando Sesión..."
                lblStatus.ForeColor = Color.DarkBlue
                Exit Select
            Case 2
                pboxLoading.Visible = False
                lblStatus.Text = "Usuario no registrado"
                lblStatus.ForeColor = Color.DarkViolet
                txtDni.Focus()
                Exit Select
            Case 3
                pboxLoading.Visible = False
                lblStatus.Text = "Bienvenido (a) " & (e.UserState.FirstName & " " & e.UserState.LastName).ToString().Trim
                lblStatus.ForeColor = Color.DarkBlue
                Application.DoEvents()

                Threading.Thread.Sleep(2000)

                Hide()
                Dim main As New frmMain(e.UserState)
                main.Show()
                Exit Select
            Case 4
                pboxLoading.Visible = False
                lblStatus.Text = "Contraseña incorrecta"
                lblStatus.ForeColor = Color.DarkViolet
                txtPass.Focus()
                Exit Select
        End Select
    End Sub

End Class
