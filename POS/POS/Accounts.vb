Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Accounts
    Private Sub Accounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        gridview()
        AutoNumber()
        userlevel()
        loadcb()
    End Sub
    Sub gridview()


        DataGridView1.Rows.Clear()
        str = "Select * from Accounts order by User_ID"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read()

            DataGridView1.Rows.Add(dr("User_ID"), dr("Username"), dr("Password"), dr("Fname"), dr("Mname"), dr("Lname"), dr("UserLevel"), dr("Date_Stamp"), dr("User_Stamp"))
        End While
        dr.Close()
        cmd.Dispose()
    End Sub
    Sub CreateNewAutoNumber()
        Try
            Dim cmd As New SqlCommand
            With cmd
                .Connection = sqlconn
                .CommandText = "SP_AutoNo" ' Name ng stored procedure ng autonumber
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@pfx", "UID") 'prefix Char ng autonumber sakin kasi Event kaya EVT
            End With
            cmd.ExecuteScalar()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub AutoNumber()

        Dim number As String
        str = "SELECT Max(NewNumber) FROM Autonumber where pfx = @pfx" ' table name ng autonumber
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        With cmd
            .Parameters.AddWithValue("@Pfx", "UID") 'prefix Char ng autonumber sakin kasi Event kaya EVT
            If IsDBNull(cmd.ExecuteScalar) Then
                CreateNewAutoNumber()
                Dim number1 As String
                str = "SELECT Max(NewNumber) FROM Autonumber where pfx = @pfx" 'table name ng autonumber
                cmd = New SqlClient.SqlCommand(str, sqlconn)
                With cmd
                    .Parameters.AddWithValue("@pfx", "UID") 'prefix Char ng autonumber sakin kasi Event kayaEVT
                    number1 = Convert.ToString(cmd.ExecuteScalar)
                    TextBox1.Text = number1 ' sang textbox mo o Object lalagay

                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Else
                number = Convert.ToString(cmd.ExecuteScalar)
                TextBox1.Text = number ' sang textbox mo o Object lalagay

            End If

        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub ADDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem.Click
        Dim existinguser As Boolean = False
        Dim existingname As Boolean = False
        Dim existingid As Boolean = False
        str = "Select * from Accounts order by User_ID"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read()
            If dr("User_ID").ToString.Equals(TextBox1.Text) Then
                existingid = True
            ElseIf dr("Username").ToString.Equals(TextBox2.Text) Then
                existinguser = True
            ElseIf dr("Fname").ToString.Equals(TextBox4.Text) And dr("Mname").ToString.Equals(TextBox5.Text) And dr("Lname").ToString.Equals(TextBox6.Text) Then
                existingname = True
            End If

        End While
        dr.Close()
        cmd.Dispose()

        If existinguser = True Then
            MsgBox("Username already exist", MsgBoxStyle.Critical, "WARNING")
        ElseIf existingname = True Then
            MsgBox("Name already exist", MsgBoxStyle.Critical, "WARNING")
        ElseIf existingid = True Then
            MsgBox("ID already exist", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Invalid Username", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Invalid Password", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Invalid Firstname", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox5.Text = "" Then
            MsgBox("Invalid Middlename", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Invalid Lastname", MsgBoxStyle.Critical, "WARNING")

        ElseIf ComboBox1.Text = Nothing Then
            MsgBox("Invalid Userlevel", MsgBoxStyle.Critical, "WARNING")
        Else
            Dim confirm = MsgBox("Do you want to save user?", MsgBoxStyle.YesNo, "SAVE")
            If confirm = MsgBoxResult.Yes Then
                TextBox3.Text = encrypt(TextBox3.Text)

                saveaccounts()
                gridview()
                CreateNewAutoNumber()
                AutoNumber()
                clear()
                MsgBox("Save")

            End If

        End If


    End Sub

    Sub updatedata()

        query = "Update Accounts set Username = @Username,Password=@Password,Fname =@Fname,Mname=@Mname, Lname=@Lname,UserLevel = @UserLevel where User_ID = @User_ID"
        cmd = New SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@User_ID", TextBox1.Text)
            .Parameters.AddWithValue("@Username", TextBox2.Text)
            .Parameters.AddWithValue("@Password", TextBox3.Text)
            .Parameters.AddWithValue("@Fname", TextBox4.Text)
            .Parameters.AddWithValue("@Mname", TextBox5.Text)
            .Parameters.AddWithValue("@Lname", TextBox6.Text)
            .Parameters.AddWithValue("@UserLevel", ComboBox1.Text)

        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub
    Sub clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        userlevel()
    End Sub
    Sub saveaccounts()

        query = "Insert into Accounts (User_ID,Username,Password,Fname,Mname,Lname,UserLevel,User_Stamp,Date_Stamp) values (@User_ID,@Username,@Password,@Fname,@Mname,@Lname,@UserLevel,@User_Stamp,@Date_Stamp)"
        cmd = New SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@User_ID", TextBox1.Text)
            .Parameters.AddWithValue("@Username", TextBox2.Text)
            .Parameters.AddWithValue("@Password", TextBox3.Text)
            .Parameters.AddWithValue("@Fname", TextBox4.Text)
            .Parameters.AddWithValue("@Mname", TextBox5.Text)
            .Parameters.AddWithValue("@Lname", TextBox6.Text)
            .Parameters.AddWithValue("@UserLevel", ComboBox1.Text)
            .Parameters.AddWithValue("@User_stamp", fname + " " + lname)
            .Parameters.AddWithValue("@Date_stamp", Date.Now)

        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub
    Sub deleteaccounts(ByVal uid)

        query = "Delete from Accounts where User_ID = @User_ID"
        cmd = New SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@User_ID", uid)


        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Sub loadcb()
        ToolStripComboBox1.Items.Clear()
        With ToolStripComboBox1
            .Items.Add("User_ID")
            .Items.Add("UserName")
            .Items.Add("Fname")
            .Items.Add("Mname")
            .Items.Add("Lname")
            .Items.Add("UserLevel")
        End With
    End Sub

    Sub userlevel()
        Dim ExistSuperAdmin As Boolean = False

        str = "select * from Accounts where UserLevel = 'Super Admin'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read()
            If dr.HasRows Then
                ExistSuperAdmin = True 'kung may super admin na
            End If

        End While
        dr.Close()
        cmd.Dispose()

        If ExistSuperAdmin = True Then
            ComboBox1.Items.Clear() 'kung meron na
            With ComboBox1

                .Items.Add("Owner")
                .Items.Add("Staff")


            End With
        Else
            ComboBox1.Items.Clear() 'kung wala pa
            With ComboBox1
                .Items.Add("Super Admin")

                .Items.Add("Owner")
                .Items.Add("Staff")
            End With

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_Validated(sender As Object, e As EventArgs) Handles TextBox2.Validated

    End Sub

    Private Function isValid(ByVal strText) As Boolean
        Dim regex As Regex = New Regex("[^a-zA-Z]")
        Dim match As Match = regex.Match(strText)
        If match.Success Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        If ulevel <> "Super Admin" And DataGridView1.Item(6, i).Value = "Super Admin" Then
            MsgBox("Cannot edit Super admin Account", MsgBoxStyle.Critical, "WARNING")
        ElseIf ulevel = "Owner" And DataGridView1.Item(6, i).Value = "Owner" Then
            MsgBox("the same administrator cannot be deleted ", MsgBoxStyle.Critical, "WARNING")
        Else
            clear()
            If DataGridView1.Item(6, i).Value = "Super Admin" Then
                ComboBox1.Items.Clear() 'kung wala pa
                With ComboBox1
                    .Items.Add("Super Admin")
                    .Items.Add("Administrator") ' pati dito sa pag walang superadmin pa
                    .Items.Add("Owner")
                    .Items.Add("Staff")
                End With
                ComboBox1.SelectedIndex = 0
                ComboBox1.Enabled = False
            Else
                ComboBox1.Text = DataGridView1.Item(6, i).Value
            End If
            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox2.Text = DataGridView1.Item(1, i).Value
            TextBox4.Text = DataGridView1.Item(3, i).Value
            TextBox5.Text = DataGridView1.Item(4, i).Value
            TextBox6.Text = DataGridView1.Item(5, i).Value



            If ulevel = "Owner" Then
                ComboBox1.Enabled = False
            End If
        End If

    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEToolStripMenuItem.Click
        If TextBox2.Text = "" Then
            MsgBox("Invalid Username", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Invalid Password", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Invalid Firstname", MsgBoxStyle.Critical, "WARNING")

        ElseIf TextBox5.Text = "" Then
            MsgBox("Invalid Middlename", MsgBoxStyle.Critical, "WARNING")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Invalid Lastname", MsgBoxStyle.Critical, "WARNING")
        ElseIf ComboBox1.Text = Nothing Then
            MsgBox("Invalid Userlevel", MsgBoxStyle.Critical, "WARNING")

        Else
            Dim confirm = MsgBox("Do you want to Update User?", MsgBoxStyle.YesNo, "Update")
            If confirm = MsgBoxResult.Yes Then
                updatedata()
                gridview()
                clear()
                AutoNumber()
                MsgBox("Updated")

            End If
        End If
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELETEToolStripMenuItem.Click
        Dim i As Integer = DataGridView1.CurrentRow.Index
        If userid = DataGridView1.Item(0, i).Value Then                      'codes para hinde madelete yung makalogin
            MsgBox("Cant Delete Current Login User", MsgBoxStyle.Critical, "DELETE")
        ElseIf DataGridView1.Item(6, i).Value = "Super Admin" Then  'codes para hinde madelete si super admin
            MsgBox("Cant delete Super Admin Account", MsgBoxStyle.Critical, "WARNING")
        ElseIf ulevel = "Owner" And DataGridView1.Item(6, i).Value = "Owner" Then
            MsgBox("the same owner cannot be deleted", MsgBoxStyle.Critical, "WARNING")
        Else
            Dim confirm = MsgBox("Do you want to Delete user?", MsgBoxStyle.YesNo, "DELETE")
            If confirm = MsgBoxResult.Yes Then
                deleteaccounts(DataGridView1.Item(0, i).Value)
                AutoNumber()
                gridview()
                clear()
                MsgBox("deleted")

            End If

        End If
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

    End Sub

    Private Sub ToolStripTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ToolStripTextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If ToolStripComboBox1.Text = "" Then
                gridview()

            Else

                DataGridView1.Rows.Clear()

                If ToolStripComboBox1.Text = "User_ID" Then
                    str = "select * from Accounts where User_ID like '%" & Me.ToolStripTextBox1.Text.Trim & "%'"
                    dispRec(str)

                ElseIf ToolStripComboBox1.Text = "UserName" Then
                    str = "select * from Accounts where Username like '%" & Me.ToolStripTextBox1.Text.Trim & "%'"
                    dispRec(str)

                ElseIf ToolStripComboBox1.Text = "Fname" Then
                    str = "select * from Accounts where Fname like '%" & Me.ToolStripTextBox1.Text.Trim & "%'"
                    dispRec(str)


                ElseIf ToolStripComboBox1.Text = "Mname" Then
                    str = "select * from Accounts where Mname like '%" & Me.ToolStripTextBox1.Text.Trim & "%'"
                    dispRec(str)

                ElseIf ToolStripComboBox1.Text = "Lname" Then
                    str = "select * from Accounts where Lname like '%" & Me.ToolStripTextBox1.Text.Trim & "%'"
                    dispRec(str)

                ElseIf ToolStripComboBox1.Text = "UserLevel" Then
                    str = "select * from Accounts where UserLevel like '%" & Me.ToolStripTextBox1.Text.Trim & "%'"
                    dispRec(str)

                ElseIf ToolStripComboBox1.Text = "" Then
                    gridview()

                End If
                ToolStripComboBox1.Text = ""
                ToolStripTextBox1.Text = ""

            End If
        End If
    End Sub
    Public Sub dispRec(ByVal PstrSQL As String)

        Me.DataGridView1.Rows.Clear()
        With cmd
            .CommandText = PstrSQL
            dr = cmd.ExecuteReader()
        End With
        Do While dr.Read
            Me.DataGridView1.Rows.Add(dr!User_ID.ToString.Trim, dr!Username.ToString.Trim, dr!Password.ToString.Trim, dr!Fname.ToString.Trim, dr!Mname.ToString.Trim, dr!Lname.ToString.Trim, dr!UserLevel.ToString.Trim)
            My.Application.DoEvents()
        Loop
        dr.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_Validated(sender As Object, e As EventArgs) Handles TextBox3.Validated
        If TextBox3.TextLength < 8 Then
            MsgBox("Password must atleast 8 characters long", MsgBoxStyle.Critical, "PASSWORD") ' 8 character password
        ElseIf isValid(TextBox3.Text) Then
            MsgBox("Password must atleast have 1 special characters or number", MsgBoxStyle.Critical, "PASSWORD")
        End If
    End Sub

    Private Sub CANCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CANCELToolStripMenuItem.Click
        Me.Close()
        Dashboard.Show()
    End Sub

    Private Sub CLEARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLEARToolStripMenuItem.Click
        clear()
        AutoNumber()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class