Imports MySql.Data.MySqlClient
Public Class Procedure

    Dim enc As New Encryptation
    Dim cmd As MySqlCommand
    Dim cb As MySqlCommandBuilder
    Private _ds As New DataSet
    Private _errorMsg As String

    Public Function strConn() As String
        Dim str As String = ""

        If My.Settings.currentConn = "0" Then
            If Not My.Settings.localConn = "" Then
                str = enc.Decrypt(My.Settings.localConn)
            End If
        ElseIf My.Settings.currentConn = "1" Then
            If Not My.Settings.remoteConn = "" Then
                str = enc.Decrypt(My.Settings.remoteConn)
            End If
        End If

        Return str
    End Function

    Public Property ErrorMsg() As String
        Get
            Return _errorMsg
        End Get
        Set(ByVal value As String)
            _errorMsg = value
        End Set
    End Property

    Public Property Ds() As DataSet
        Get
            Return _ds
        End Get
        Set(ByVal value As DataSet)
            _ds = value
        End Set
    End Property

    'FUNCION PARA EJECUTAR UN PROCEDIMIENTO ALMACENADO DE CARGA SIN PARAMETROS
    Public Function GetData(ByVal sp As String) As Boolean
        Try
            Using conn As New MySqlConnection(strConn())
                conn.Open()

                cmd = New MySqlCommand
                cmd.CommandText = sp
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = conn
                cmd.CommandTimeout = 0

                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(Ds)
                End Using
            End Using

            Return True
        Catch ex As Exception
            ErrorMsg = ex.Message
            Return False
        End Try
    End Function

    'FUNCION PARA EJECUTAR UN PROCEDIMIENTO ALMACENADO DE CARGA CON PARAMETROS
    Public Function GetData(ByVal sp As String, ByVal ParamArray parametro() As Object) As Boolean
        'Try
        Using conn As New MySqlConnection(strConn())

            cmd = New MySqlCommand
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn

            conn.Open()
            'MySqlCommandBuilder.DeriveParameters(cmd)

            For i = 0 To parametro.Length - 1
                'CType(cmd.Parameters(i), MySqlParameter).Value = parametro(i)
                cmd.Parameters.Add(New MySqlParameter("_" & i.ToString, parametro(i)))
            Next

            Using da As New MySqlDataAdapter(cmd)
                da.Fill(Ds)
            End Using
        End Using
            Return True
        'Catch ex As Exception
        'ErrorMsg = ex.Message
        'Return False
        'End Try
    End Function

    'FUNCION PARA EJECUTAR UN PROCEDIMIENTO ALMACENADO DE INSERCION O ACTUALIZACION DE DATOS CON PARAMETROS
    Public Function SendData(ByVal sp As String, ByVal ParamArray parametro() As Object) As Boolean
        Try
            Using conn As New MySqlConnection(strConn())
                conn.Open()

                cmd = New MySqlCommand
                cmd.CommandText = sp
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = conn
                cmd.CommandTimeout = 0

                MySqlCommandBuilder.DeriveParameters(cmd)

                For i = 0 To parametro.Length - 1
                    CType(cmd.Parameters(i), MySqlParameter).Value = parametro(i)
                Next

                cmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            ErrorMsg = ex.Message
            Return False
        End Try
    End Function

    Public Function SendData(ByVal sp As String, ByVal image As Byte(), ByVal ParamArray parametro() As Object) As Boolean
        Try
            Using conn As New MySqlConnection(strConn())
                conn.Open()

                cmd = New MySqlCommand
                cmd.CommandText = sp
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = conn
                cmd.CommandTimeout = 0

                MySqlCommandBuilder.DeriveParameters(cmd)

                For i = 0 To parametro.Length - 1
                    CType(cmd.Parameters(i), MySqlParameter).Value = parametro(i)
                Next

                cmd.ExecuteReader()
            End Using
            Return True
        Catch ex As Exception
            ErrorMsg = ex.Message
            Return False
        End Try
    End Function

    Public Function strRemoteConn() As String
        Return "server=localhost;uid=root;pwd=ZUPre25800;database=zutrackingdb;Convert Zero Datetime=True"
    End Function

    Public Function strLocalConn() As String
        Return "server=localhost;uid=root;pwd=ZUPre25800;database=zutrackingdb;Convert Zero Datetime=True"
    End Function
End Class
