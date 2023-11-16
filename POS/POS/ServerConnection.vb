
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Module ServerConnection
    Public sqlconn As New SqlConnection
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public str As String
    Public query As String
    Public userid, fname, lname, ulevel As String


    Public Function encrypt(Encryption As String) As String
        Dim pword As String = String.Empty
        Dim encode As Byte() = New Byte(Encryption.Length - 1) {}
        encode = Encoding.UTF8.GetBytes(Encryption)
        pword = Convert.ToBase64String(encode)
        Return pword


    End Function
    Sub connect()
        Try
            If sqlconn.State = ConnectionState.Open Then sqlconn.Close()
            sqlconn.ConnectionString = "Server=DESKTOP-I2CQ4IM;Database=POS;Trusted_Connection=True;MultipleActiveResultSets=True;"
            sqlconn.Open()

        Catch ex As Exception
            MsgBox("Error in Connection please contact administrator", MsgBoxStyle.Critical)
        End Try

    End Sub


End Module
