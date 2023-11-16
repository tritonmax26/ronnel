<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Timer1 As System.Windows.Forms.Timer
        Dim Timer2 As System.Windows.Forms.Timer
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.INVENTORYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TRANSACTIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPORTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ACCOUNTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LOGOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Timer1 = New System.Windows.Forms.Timer(Me.components)
        Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Timer1.Enabled = True
        Timer1.Interval = 1000
        AddHandler Timer1.Tick, AddressOf Me.Timer1_Tick
        '
        'Timer2
        '
        Timer2.Enabled = True
        Timer2.Interval = 1000
        AddHandler Timer2.Tick, AddressOf Me.Timer2_Tick
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImage = Global.POS.My.Resources.Resources.Vape_trick_smoke_ring_on_dark_background
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INVENTORYToolStripMenuItem, Me.TRANSACTIONToolStripMenuItem, Me.REPORTSToolStripMenuItem, Me.ACCOUNTSToolStripMenuItem, Me.LOGOUTToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(611, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'INVENTORYToolStripMenuItem
        '
        Me.INVENTORYToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.INVENTORYToolStripMenuItem.BackgroundImage = Global.POS.My.Resources.Resources.Buttons_PNG_Image_93809
        Me.INVENTORYToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.INVENTORYToolStripMenuItem.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INVENTORYToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.INVENTORYToolStripMenuItem.Name = "INVENTORYToolStripMenuItem"
        Me.INVENTORYToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.INVENTORYToolStripMenuItem.Text = "INVENTORY"
        '
        'TRANSACTIONToolStripMenuItem
        '
        Me.TRANSACTIONToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.TRANSACTIONToolStripMenuItem.BackgroundImage = Global.POS.My.Resources.Resources.Buttons_PNG_Image_93809
        Me.TRANSACTIONToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TRANSACTIONToolStripMenuItem.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRANSACTIONToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.TRANSACTIONToolStripMenuItem.Name = "TRANSACTIONToolStripMenuItem"
        Me.TRANSACTIONToolStripMenuItem.Size = New System.Drawing.Size(113, 20)
        Me.TRANSACTIONToolStripMenuItem.Text = "TRANSACTION"
        '
        'REPORTSToolStripMenuItem
        '
        Me.REPORTSToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.REPORTSToolStripMenuItem.BackgroundImage = Global.POS.My.Resources.Resources.Buttons_PNG_Image_93809
        Me.REPORTSToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.REPORTSToolStripMenuItem.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.REPORTSToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.REPORTSToolStripMenuItem.Name = "REPORTSToolStripMenuItem"
        Me.REPORTSToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.REPORTSToolStripMenuItem.Text = "REPORTS"
        '
        'ACCOUNTSToolStripMenuItem
        '
        Me.ACCOUNTSToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.ACCOUNTSToolStripMenuItem.BackgroundImage = Global.POS.My.Resources.Resources.Buttons_PNG_Image_93809
        Me.ACCOUNTSToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ACCOUNTSToolStripMenuItem.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACCOUNTSToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.ACCOUNTSToolStripMenuItem.Name = "ACCOUNTSToolStripMenuItem"
        Me.ACCOUNTSToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.ACCOUNTSToolStripMenuItem.Text = "ACCOUNTS"
        '
        'LOGOUTToolStripMenuItem
        '
        Me.LOGOUTToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.LOGOUTToolStripMenuItem.BackgroundImage = Global.POS.My.Resources.Resources.Buttons_PNG_Image_93809
        Me.LOGOUTToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LOGOUTToolStripMenuItem.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOGOUTToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control
        Me.LOGOUTToolStripMenuItem.Name = "LOGOUTToolStripMenuItem"
        Me.LOGOUTToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.LOGOUTToolStripMenuItem.Text = "LOGOUT"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Lucida Handwriting", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(22, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 311)
        Me.Panel1.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(77, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 18)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Time"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(12, 269)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 18)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(77, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(12, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(108, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(16, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "UserLevel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(108, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(16, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(38, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "WELCOME"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = Global.POS.My.Resources.Resources.Vape_trick_smoke_ring_on_dark_background
        Me.ClientSize = New System.Drawing.Size(611, 433)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents INVENTORYToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TRANSACTIONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REPORTSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ACCOUNTSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOGOUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
