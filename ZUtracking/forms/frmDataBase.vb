Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class frmDataBase
    Private Sub frmDataBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' declaracion de variables de conexion
        Dim server As String = Nothing
        Dim user As String = Nothing
        Dim pass As String = Nothing
        Dim database As String = Nothing
        Dim str As String() = Nothing
        Dim enc As New Encryptation

        ' se carga la cadena en un array dependiendo de la opcion que este marcada (local o remota) si existe...
        If My.Settings.currentConn.Equals("0") Then
            If Not My.Settings.localConn.Equals("") Then
                str = enc.Decrypt(My.Settings.localConn).Split(";")
            End If
            rbtnLocal.Checked = True

        ElseIf My.Settings.currentConn.Equals("1") Then
            If Not My.Settings.remoteConn.Equals("") Then
                str = enc.Decrypt(My.Settings.remoteConn).Split(";")
            End If
            rbtnRemote.Checked = True
        Else
            Exit Sub
        End If

        For i = 0 To str.Length - 1
            If str(i).Contains("Data Source=") Then
                server = str(i).Replace("Data Source=", "").Trim()
            End If

            If str(i).Contains("User ID=") Then
                user = str(i).Replace("User ID=", "").Trim()
            End If

            If str(i).Contains("Pwd=") Then
                pass = str(i).Replace("Pwd=", "").Trim()
            End If

            If str(i).Contains("Initial Catalog=") Then
                database = str(i).Replace("Initial Catalog=", "").Trim()
            End If
        Next

        ' se llenan los campos de textos con sus variables correspondientes
        txtServer.Text = server
        txtUsername.Text = user
        txtPassword.Text = pass
        cboDatabase.Text = database

    End Sub

    Private Sub rbtnLocal_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnLocal.CheckedChanged
        If rbtnLocal.Checked Then
            Dim enc As New Encryptation

            ' procedimiento que carga todos los parametros de la cadena de conexion local en caso de existir
            For Each tb As Control In gboxParameters.Controls
                If TypeOf tb Is ZUControls.ZUTextBox Then
                    tb.Text = ""
                End If
            Next

            ' se elimina el datasource del combo bases de datos
            cboDatabase.DataSource = Nothing
            cboDatabase.Text = Nothing

            ' declaracion de las variables parametros de conexion
            Dim server As String = Nothing
            Dim user As String = Nothing
            Dim pass As String = Nothing
            Dim database As String = Nothing

            ' array que contendra los parametros extraidos y separados por ";"
            Dim str As String() = Nothing

            If My.Settings.currentConn.Equals("0") Then
                cboxAsDefault.Checked = True
            Else
                cboxAsDefault.Checked = False
            End If

            If Not My.Settings.localConn.Equals("") Then
                str = enc.Decrypt(My.Settings.localConn).Split(";")
            Else
                Exit Sub
            End If

            ' se llenan cada una de las variables correspondientes
            For i = 0 To str.Length - 1
                If str(i).Contains("Data Source=") Then
                    server = str(i).Replace("Data Source=", "").Trim()
                End If

                If str(i).Contains("User ID=") Then
                    user = str(i).Replace("User ID=", "").Trim()
                End If

                If str(i).Contains("Pwd=") Then
                    pass = str(i).Replace("Pwd=", "").Trim()
                End If

                If str(i).Contains("Initial Catalog=") Then
                    database = str(i).Replace("Initial Catalog=", "").Trim()
                End If
            Next

            ' se llenan los campos de textos con los valores de las variables
            txtServer.Text = server
            txtUsername.Text = user
            txtPassword.Text = pass
            cboDatabase.Text = database
        End If
    End Sub

    Private Sub rbtnRemote_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnRemote.CheckedChanged
        If rbtnRemote.Checked Then
            Dim enc As New Encryptation

            ' procedimiento que carga todos los parametros de la cadena de conexion local en caso de existir
            For Each tb As Control In gboxParameters.Controls
                If TypeOf tb Is ZUControls.ZUTextBox Then
                    tb.Text = ""
                End If
            Next

            ' se elimina el datasource del combo bases de datos
            cboDatabase.DataSource = Nothing
            cboDatabase.Text = Nothing

            ' declaracion de las variables parametros de conexion
            Dim server As String = Nothing
            Dim user As String = Nothing
            Dim pass As String = Nothing
            Dim database As String = Nothing

            ' array que contendra los parametros extraidos y separados por ";"
            Dim str As String() = Nothing

            If My.Settings.currentConn.Equals("1") Then
                cboxAsDefault.Checked = True
            Else
                cboxAsDefault.Checked = False
            End If

            If Not My.Settings.remoteConn.Equals("") Then
                str = enc.Decrypt(My.Settings.remoteConn).Split(";")
            Else
                Exit Sub
            End If

            ' se llenan cada una de las variables correspondientes
            For i = 0 To str.Length - 1
                If str(i).Contains("Data Source=") Then
                    server = str(i).Replace("Data Source=", "").Trim()
                End If

                If str(i).Contains("User ID=") Then
                    user = str(i).Replace("User ID=", "").Trim()
                End If

                If str(i).Contains("Pwd=") Then
                    pass = str(i).Replace("Pwd=", "").Trim()
                End If

                If str(i).Contains("Initial Catalog=") Then
                    database = str(i).Replace("Initial Catalog=", "").Trim()
                End If
            Next

            ' se llenan los campos de textos con los valores de las variables
            txtServer.Text = server
            txtUsername.Text = user
            txtPassword.Text = pass
            cboDatabase.Text = database
        End If
    End Sub

    Private Sub cboDatabase_Enter(sender As Object, e As EventArgs) Handles cboDatabase.Enter
        Dim tempConn As String = "Data Source=" + txtServer.Text.Trim() + ";User ID=" + txtUsername.Text.Trim()

        If Not txtPassword.Text.Trim().Equals("") Then
            tempConn += ";Pwd=" + txtPassword.Text.Trim()
        End If

        tempConn += ";Persist Security Info=True;Max Pool Size=1000;Connect Timeout=30"

        Try
            ' se elimina el datasource del combo para luego volver a llenarlo en caso de existir datos
            cboDatabase.DataSource = Nothing

            ' se instancia una conexion con la instruccion using de manera que al finalizar esta instruccion
            ' la conexion se cierre automaticamente y todos los objetos que se usaron en el
            Using conn As New MySqlConnection(tempConn)
                conn.Open()

                Dim cmd As New MySqlCommand("SHOW DATABASES", conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim ds As New DataSet()

                da.Fill(ds)

                cboDatabase.DataSource = ds.Tables(0)
                cboDatabase.DisplayMember = "Database"
                cboDatabase.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For Each tb As Control In gboxParameters.Controls
            If TypeOf tb Is ZUControls.ZUTextBox Then
                tb.Text = ""
            End If
        Next

        cboDatabase.DataSource = Nothing
        cboDatabase.Text = Nothing

        txtServer.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim enc As New Encryptation

        If txtServer.Text.Trim = "" Then
            MsgBox("Debe indicar la dirección del servidor", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtServer.Focus()
            Exit Sub
        End If

        If txtUsername.Text.Trim = "" Then
            MsgBox("Debe indicar nombre de usuario de la conexión", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtUsername.Focus()
            Exit Sub
        End If

        If txtUsername.Text.Trim = "" Then
            MsgBox("Debe indicar la contraseña de la conexión", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            txtUsername.Focus()
            Exit Sub
        End If

        If cboDatabase.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el nombre de la base de datos", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            cboDatabase.Focus()
            Exit Sub
        End If

        Dim str As String = "server=[server];uid=[uid];pwd=[pwd];database=[database];Convert Zero Datetime=True"
        str = str.Replace("[server]", txtServer.Text.Trim)
        str = str.Replace("[uid]", txtUsername.Text.Trim)
        str = str.Replace("[pwd]", txtPassword.Text.Trim)
        str = str.Replace("[database]", cboDatabase.Text.Trim)

        If rbtnLocal.Checked Then
            My.Settings.localConn = enc.Encrypt(str)
            If cboxAsDefault.Checked Then
                My.Settings.currentConn = "0"
            End If
        Else
            My.Settings.remoteConn = enc.Encrypt(str)
            If cboxAsDefault.Checked Then
                My.Settings.currentConn = "1"
            End If
        End If

        My.Settings.Save()
        MsgBox("La configuración de la Base de Datos se ha guardado exitosamente", MsgBoxStyle.Information, "Mensaje del Sistema")
    End Sub
End Class