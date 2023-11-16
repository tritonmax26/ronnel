Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Public Class Login
    Dim trynumber As Integer = 0

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sqlconn.State <> ConnectionState.Open Then
            sqlconn.Open()

        End If
        TextBox2.Text = encrypt(TextBox2.Text)
        Dim da As New SqlDataAdapter("Select * from Accounts", sqlconn)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        Dim resultat As Integer
        For i = 0 To dt.Rows.Count - 1
            If TextBox1.Text = Convert.ToString(dt.Rows(i)("Username")) And
                    TextBox2.Text = Convert.ToString(dt.Rows(i)("Password")) Then

                fname = Convert.ToString(dt.Rows(i)("Fname"))
                lname = Convert.ToString(dt.Rows(i)("Lname"))
                ulevel = Convert.ToString(dt.Rows(i)("Userlevel"))

                MsgBox("Welcome you are now logged in ", MsgBoxStyle.Information)
                resultat = 1

                Dashboard.Label3.Text = fname + " " + lname
                Dashboard.Label5.Text = ulevel
                Dashboard.Show()
                Me.Hide()

            End If
        Next
        If resultat <> 1 Then
            MsgBox("Invalid Username and Password", MsgBoxStyle.Exclamation)
            trynumber += 1

            If trynumber >= 3 Then
                MsgBox("You have reach the maximum login attempt!, system will dsiable in 3 minutes", MsgBoxStyle.Critical)
                Label4.Text = 180
                Label4.Visible = True
                Label3.Visible = True

                Me.Enabled = False
                Timer1.Start()
            End If

        End If









    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label4.Text = 0 Then
            Label3.Visible = False
            Label4.Visible = False
            Me.Enabled = True
            Timer1.Stop()
        Else

            Label4.Text = Val(Label4.Text) - 1
        End If
    End Sub
End Class
