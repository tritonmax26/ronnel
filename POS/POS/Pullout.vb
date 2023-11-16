Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Public Class Pullout
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox6_Validated(sender As Object, e As EventArgs) Handles TextBox6.Validated
        Dim qty As Integer = Val(TextBox4.Text)
        Dim poqty As Integer = Val(TextBox6.Text)
        Dim rmn As Integer

        If poqty > qty Then
            MsgBox("No more Qty to pullout", MsgBoxStyle.Exclamation)
        ElseIf qty <= 0 Then
            MsgBox("No more Qty to pullout", MsgBoxStyle.Exclamation)
        Else
            rmn = qty - poqty

            TextBox4.Text = rmn.ToString
        End If
    End Sub



    Sub savepullout()
        query = "Insert Into Pullout_table (POnumber,Product_ID,POQuantity,PODate,Remaining,User_Stamp,Reason) Values (@POnumber,@Product_ID,@POQuantity,@PODate,@Remaining,@User_Stamp,@Reason)"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@POnumber", TextBox8.Text)
            .Parameters.AddWithValue("@Product_ID", TextBox1.Text)
            .Parameters.AddWithValue("@POQuantity", TextBox6.Text)
            .Parameters.AddWithValue("@PODate", CDate(Date.Now))
            .Parameters.AddWithValue("@Remaining", TextBox4.Text)
            .Parameters.AddWithValue("@User_Stamp", fname + " " + lname)
            .Parameters.AddWithValue("@Reason", TextBox7.Text)
        End With

        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

    Sub CreatetransactionNo()
        Dim cmd As New SqlCommand
        With cmd
            .CommandText = "USP__PO_AutoNo"
            .CommandType = CommandType.StoredProcedure
            .Connection = sqlconn
            dt = New DataTable
            da = New SqlDataAdapter(cmd)

            da.Fill(dt)
            .ExecuteNonQuery()
            .Dispose()

            TextBox8.Text = dt.Rows(0).Item(0).ToString()
        End With


    End Sub

    Sub updateqty()

        query = "Update Inventorytable set Quantity = @Quantity where Product_ID = @Product_ID"
        cmd = New SqlClient.SqlCommand(query, sqlconn)
        With cmd
            .Parameters.AddWithValue("@Product_ID", TextBox1.Text)
            .Parameters.AddWithValue("@Quantity", TextBox4.Text)


        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub

    Private Sub Pullout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        CreatetransactionNo()
        readdata()
    End Sub



    Sub readdata()
        DataGridView1.Rows.Clear()
        str = "Select * from Pullout_table as P Inner Join Inventorytable as I on I.Product_ID = P.Product_ID "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("POnumber"), dr("PODate"), dr("Product_ID"), dr("Product_Name"), dr("Remaining"), dr("POQuantity"), dr("Price"), dr("Image"), dr("Barcode"), dr("Reason"))
        End While
        dr.Close()
        cmd.Dispose()

    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox6.Text = "" Then
            MsgBox("Invalid Pullout qty", MsgBoxStyle.Critical)
        ElseIf TextBox7.Text = "" Then
            MsgBox("Invalid Reason", MsgBoxStyle.Critical)
        Else
            savepullout()
            updateqty()
            readdata()
            Inventory.readdata()
            Inventory.rowheight()
            CreatetransactionNo()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim confirm = MsgBox("Are you sure you want to Cancel?", MsgBoxStyle.YesNo, "Cancel")
        If confirm = MsgBoxResult.Yes Then
            My.Application.OpenForms.Cast(Of Form)() _
                .Except({Login}) _ '//lagay mo yung form na di mo cclose 
                 .Except({Dashboard}) _
                  .Except({Inventory}) _
                .ToList() _
            .ForEach(Sub(form) form.Close())

            Inventory.Show()


        End If
    End Sub
End Class