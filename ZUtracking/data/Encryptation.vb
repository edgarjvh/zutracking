Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Encryptation
    'Llamada al proveedor de encriptados 3DES

    Private m_des As New TripleDESCryptoServiceProvider

    ' Define en controlador de cadenas de texto

    Private m_utf8 As New UTF8Encoding

    ' Propiedades de los arrays

    Private m_key() As Byte

    Private m_iv() As Byte

    'Llave local y vector de bytes

    Private ReadOnly key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}

    Private ReadOnly iv() As Byte = {41, 16, 38, 35, 24, 32, 87, 14} ' Cambiar los valores numéricos por unos diferentes ya que es parte de la llave de codificación y decodificación.

    Public Sub New()
        m_key = key
        m_iv = iv
    End Sub

    Public Function Encrypt(ByVal input() As Byte) As Byte()
        Return Transform(input, m_des.CreateEncryptor(m_key, m_iv))
    End Function

    Public Function Decrypt(ByVal input() As Byte) As Byte()
        Return Transform(input, m_des.CreateDecryptor(m_key, m_iv))
    End Function

    ' FUNCION PARA ENCRIPTAR

    Public Function Encrypt(ByVal text As String) As String

        Dim input() As Byte = m_utf8.GetBytes(text)

        Dim output() As Byte = Transform(input, m_des.CreateEncryptor(m_key, m_iv))

        Return Convert.ToBase64String(output)

    End Function

    ' FUNCION PARA DESENCRIPTAR

    Public Function Decrypt(ByVal text As String) As String

        Dim input() As Byte = Convert.FromBase64String(text)

        Dim output() As Byte = Transform(input, m_des.CreateDecryptor(m_key, m_iv))

        Return m_utf8.GetString(output)

    End Function

    Private Function Transform(ByVal input() As Byte, ByVal CryptoTransformar As ICryptoTransform) As Byte()

        ' Crea los streams necesarios

        Dim memStream As MemoryStream = New MemoryStream

        Dim cryptStream As CryptoStream = New CryptoStream(memStream, CryptoTransformar, CryptoStreamMode.Write)

        'transforma la peticion en bytes

        cryptStream.Write(input, 0, input.Length)

        cryptStream.FlushFinalBlock()

        ' Lee la posicion de memoria y lo convierte en arreglo de bytes

        memStream.Position = 0

        Dim result(CType(memStream.Length - 1, System.Int32)) As Byte

        memStream.Read(result, 0, CType(result.Length, System.Int32))

        ' Libera y cierra los streams

        memStream.Close()

        cryptStream.Close()

        Return result

    End Function
End Class
