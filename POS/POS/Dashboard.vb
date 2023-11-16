Public Class Dashboard
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Label7.Text = Date.Now.ToString("hh:mm:ss")

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        Label9.Text = Date.Now.ToString("MM/dd/yyyy")

    End Sub

    Private Sub INVENTORYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INVENTORYToolStripMenuItem.Click
        Inventory.Show()
        Me.Hide()
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub TRANSACTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TRANSACTIONToolStripMenuItem.Click
        Transaction.Show()
        Me.Hide()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        clear()
        Login.Show()
        Me.Hide()
    End Sub
    Sub clear()
        Login.TextBox1.Text = ""
        Login.TextBox2.Text = ""
    End Sub


    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ACCOUNTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACCOUNTSToolStripMenuItem.Click
        Accounts.Show()
        Me.Hide()
    End Sub
End Class