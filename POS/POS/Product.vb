Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Public Class Product
    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        readdata()
    End Sub

    Sub readdata()
        DataGridView1.Rows.Clear()
        str = "Select * from Inventorytable order by Product_ID Asc"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("Product_ID"), dr("Product_Name"), dr("Category"), dr("Description"), dr("Quantity"), dr("Price"), dr("Image"), dr("Barcode"))
        End While
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer = DataGridView1.CurrentRow.Index

        If Transaction.DataGridView1.Rows.Count = 0 Then The

        With DataGridView1
                Transaction.DataGridView1.Rows.Add(.Item(0, i).Value)
            End With
        End If
    End Sub
End Class