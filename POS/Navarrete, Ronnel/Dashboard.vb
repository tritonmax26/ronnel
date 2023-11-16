Public Class Dashboard
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = Date.Now.ToString("MM/dd/yyyy")

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label7.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub INVENTORYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INVENTORYToolStripMenuItem.Click
        Inventory.Show()
        Me.Hide()

    End Sub
End Class