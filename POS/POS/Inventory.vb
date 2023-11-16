Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports ZXing

Public Class Inventory
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        readdata()
        AutoNumber()
        rowheight()
        loadsearchbox()
        generatebarcode()

    End Sub

    Sub generatebarcode()
        Dim writer As New BarcodeWriter
        writer.Format = BarcodeFormat.CODE_128
        PictureBox2.Image = writer.Write(TextBox1.Text)
    End Sub

    Sub CreateNewAutoNumber()
        Try
            Dim cmd As New SqlCommand
            With cmd
                .Connection = sqlconn
                .CommandText = "SP_AutoNo" '// Name ng stored procedure ng autonumber
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@pfx", "PID") '//prefix Char ng autonumber sakin kasi Event kaya EVT
            End With
            cmd.ExecuteScalar()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub clear()
        TextBox2.Clear()
        ComboBox1.Text = Nothing
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        PictureBox1.Image = Nothing
    End Sub


    Sub AutoNumber()

        Dim number As String
        str = "SELECT Max(NewNumber) FROM Autonumber where pfx = @pfx" '// table name ng autonumber
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        With cmd
            .Parameters.AddWithValue("@Pfx", "PID") '//prefix Char ng autonumber sakin kasi Event kaya EVT
            If IsDBNull(cmd.ExecuteScalar) Then
                CreateNewAutoNumber()
                Dim number1 As String
                str = "SELECT Max(NewNumber) FROM Autonumber where pfx = @pfx" '// table name ng autonumber
                cmd = New SqlClient.SqlCommand(str, sqlconn)
                With cmd
                    .Parameters.AddWithValue("@pfx", "PID") '//prefix Char ng autonumber sakin kasi Event kayaEVT
                    number1 = Convert.ToString(cmd.ExecuteScalar)
                    TextBox1.Text = number1 '// sang textbox mo o Object lalagay

                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Else
                number = Convert.ToString(cmd.ExecuteScalar)
                TextBox1.Text = number '// sang textbox mo o Object lalagay

            End If

        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub
    Sub readdata()
        DataGridView1.Rows.Clear()
        str = "Select * from Inventorytable order by Product_ID Asc"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("Product_ID"), dr("Product_Name"), dr("Category"), dr("Description"), dr("Quantity"), dr("Price"), dr("Image"), dr("Barcode"), "Edit")
        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub SAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem.Click
        Dim existingpid As Boolean = False
        Dim exisitngpname As Boolean = False

        str = "Select * from Inventorytable order by Product_ID Asc"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr("Product_ID").ToString.Equals(TextBox1.Text) Then
                existingpid = True
            ElseIf dr("Product_Name").ToString.Equals(TextBox1.Text) Then
                existingpid = True
            End If

        End While
        dr.Close()
        cmd.Dispose()

        If existingpid = True Then
            MsgBox("ProductID already exist", MsgBoxStyle.Critical)
        ElseIf exisitngpname = True Then
            MsgBox("Product Name already exist", MsgBoxStyle.Critical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Invalid Product name", MsgBoxStyle.Critical)
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Invalid Categories ", MsgBoxStyle.Critical)
        ElseIf TextBox3.Text = "" Then
            MsgBox("Invalid Description ", MsgBoxStyle.Critical)
        ElseIf Val(TextBox4.Text) > 50 Then
            MsgBox("Maximum Quantity 50 ", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        ElseIf Val(TextBox4.Text) <= 0 Then
            MsgBox("Invalid Quantity", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        ElseIf Val(TextBox5.Text) > 10000 Then
            MsgBox("Maximum Price 10000 ", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        ElseIf Val(TextBox5.Text) <= 0 Then
            MsgBox("Invalid Price", MsgBoxStyle.Critical, "WARNING")
                TextBox4.Clear()
            Else


            savedata()
            readdata()
            CreateNewAutoNumber()
            AutoNumber()
            rowheight()
            clear()
            generatebarcode()
        End If
    End Sub

    Sub savedata()
        Dim ms As New MemoryStream
        Dim bc As New IO.MemoryStream
        PictureBox2.Image.Save(bc, System.Drawing.Imaging.ImageFormat.Png)
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        query = "Insert Into Inventorytable (Product_ID,Product_Name,Category,Description,Quantity,Price,Image,Barcode,User_Stamp,Date_Stamp) values (@Product_ID,@Product_Name,@Category,@Description,@Quantity,@Price,@Image,@Barcode,@User_Stamp,@Date_Stamp)"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@Product_ID", TextBox1.Text)
            .Parameters.AddWithValue("@Product_Name", TextBox2.Text)
            .Parameters.AddWithValue("@Category", ComboBox1.Text)
            .Parameters.AddWithValue("@Description", TextBox3.Text)
            .Parameters.AddWithValue("@Quantity", TextBox4.Text)
            .Parameters.AddWithValue("@Price", TextBox5.Text)
            .Parameters.AddWithValue("@Image", ms.ToArray())
            .Parameters.AddWithValue("@Barcode", bc.ToArray())
            .Parameters.AddWithValue("@User_Stamp", fname + " " + lname)
            .Parameters.AddWithValue("@Date_Stamp", CDate(Date.Now))


        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 8 Then
            Dim i As Integer = DataGridView1.CurrentRow.Index

            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox2.Text = DataGridView1.Item(1, i).Value
            ComboBox1.Text = DataGridView1.Item(2, i).Value
            TextBox3.Text = DataGridView1.Item(3, i).Value
            TextBox4.Text = DataGridView1.Item(4, i).Value
            TextBox5.Text = DataGridView1.Item(5, i).Value
            viewimage()
            viewbarcode()
        End If
    End Sub
    Sub viewimage()
        Dim img() As Byte
        str = "Select * from Inventorytable where Product_ID  = '" & Me.TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("Image")
            Dim ms As New MemoryStream(img)
            PictureBox1.Image = Image.FromStream(ms)
        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Sub viewbarcode()
        Dim img() As Byte
        str = "Select * from Inventorytable where Product_ID  = '" & Me.TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("Barcode")
            Dim ms As New MemoryStream(img)
            PictureBox2.Image = Image.FromStream(ms)
        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEToolStripMenuItem.Click
        If TextBox2.Text = "" Then
            MsgBox("Invalid Product name", MsgBoxStyle.Critical)
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Invalid Categories ", MsgBoxStyle.Critical)
        ElseIf TextBox3.Text = "" Then
            MsgBox("Invalid Description ", MsgBoxStyle.Critical)
        ElseIf Val(TextBox4.Text) > 50 Then
            MsgBox("Maximum Quantity 50 ", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        ElseIf Val(TextBox4.Text) <= 0 Then
            MsgBox("Invalid Quantity", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        ElseIf Val(TextBox5.Text) > 10000 Then
            MsgBox("Maximum Price 10000 ", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        ElseIf Val(TextBox5.Text) <= 0 Then
            MsgBox("Invalid Price", MsgBoxStyle.Critical, "WARNING")
            TextBox4.Clear()
        Else



            updatedata()
            readdata()
            AutoNumber()
            rowheight()
            clear()
            generatebarcode()
        End If
    End Sub
    Sub updatedata()
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        query = "Update Inventorytable set Product_Name = @Product_Name,Category = @Category,Description = @Description,Quantity = @Quantity,Price = @Price,Image = @Image where Product_ID = @Product_ID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@Product_ID", TextBox1.Text)
            .Parameters.AddWithValue("@Product_Name", TextBox2.Text)
            .Parameters.AddWithValue("@Category", ComboBox1.Text)
            .Parameters.AddWithValue("@Description", TextBox3.Text)
            .Parameters.AddWithValue("@Quantity", TextBox4.Text)
            .Parameters.AddWithValue("@Price", TextBox5.Text)
            .Parameters.AddWithValue("@Image", ms.ToArray())

        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub


    Sub deletedata(ByVal pid As String)

        query = "Delete from Inventorytable  where Product_ID = @Product_ID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@Product_ID", pid)
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Private Sub CLEARToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JPG Files (*.jpg)| *.jpg"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Sub loadsearchbox()
        ComboBox2.Items.Clear()
        With ComboBox2
            .Items.Add("Product ID")
            .Items.Add("Product Name")
            .Items.Add("Category")
            .Items.Add("Description")
        End With
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If ComboBox2.Text = "" Then
                'readdata()
                rowheight()
            Else
                DataGridView1.Rows.Clear()

                If ComboBox2.Text = "Product ID" Then
                    str = "Select * from Inventory where Product_ID like '%" & Me.TextBox6.Text & "%'"
                    dispRec(str)
                    rowheight()
                ElseIf ComboBox2.Text = "Product Name" Then
                    str = "Select * from Inventory where Product_Name like '%" & Me.TextBox6.Text & "%'"
                    dispRec(str)
                    rowheight()
                ElseIf ComboBox2.Text = "Category" Then
                    str = "Select * from Inventory where Category like '%" & Me.TextBox6.Text & "%'"
                    dispRec(str)
                    rowheight()
                ElseIf ComboBox2.Text = "Description" Then
                    str = "Select * from Inventory where Description like '%" & Me.TextBox6.Text & "%'"
                    dispRec(str)
                    rowheight()


                ElseIf ComboBox2.Text = "" Then
                    readdata()
                    rowheight()

                End If
                ComboBox2.Text = ""
                TextBox6.Clear()
            End If
        End If
    End Sub
    Sub rowheight()
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 100
        Next
    End Sub

    Public Sub dispRec(ByVal PstrSQL As String)
        Me.DataGridView1.Rows.Clear()
        With cmd
            .CommandText = PstrSQL
            dr = cmd.ExecuteReader()

        End With
        Do While dr.Read()
            Me.DataGridView1.Rows.Add(dr!Image, dr!Product_ID.ToString.Trim, dr!Product_Name.ToString.Trim, dr!Category.ToString.Trim, dr!Description.ToString.Trim, dr!Quantity.ToString.Trim, dr!Price.ToString.Trim, "EDIT")
            My.Application.DoEvents()
        Loop
        dr.Close()
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged


    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DELETEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELETEToolStripMenuItem.Click
        Dim confirm = MsgBox("Are you sure you want to pullout this item?", MsgBoxStyle.YesNo)
        If confirm = MsgBoxResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Pullout.TextBox1.Text = DataGridView1.Item(0, i).Value
            Pullout.TextBox2.Text = DataGridView1.Item(1, i).Value
            Pullout.ComboBox1.Text = DataGridView1.Item(2, i).Value
            Pullout.TextBox3.Text = DataGridView1.Item(3, i).Value
            Pullout.TextBox4.Text = DataGridView1.Item(4, i).Value
            Pullout.TextBox5.Text = DataGridView1.Item(5, i).Value
            Pullout.Show()
            viewimage1()
            viewbarcode1()
        End If



    End Sub

    Sub viewimage1()
        Dim img() As Byte
        str = "Select * from Inventorytable where Product_ID  = '" & Pullout.TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("Image")
            Dim ms As New MemoryStream(img)
            Pullout.PictureBox1.Image = Image.FromStream(ms)
        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Sub viewbarcode1()
        Dim img() As Byte
        str = "Select * from Inventorytable where Product_ID  = '" & Pullout.TextBox1.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            img = dr("Barcode")
            Dim ms As New MemoryStream(img)
            Pullout.PictureBox2.Image = Image.FromStream(ms)
        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class