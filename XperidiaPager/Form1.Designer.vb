<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sentinel
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sentinel))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtIP = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SendButton = New System.Windows.Forms.ToolStripButton()
        Me.EraseButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PseudoTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.UPnPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Reconnexion = New System.Windows.Forms.ToolStripButton()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideTimer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.CausesValidation = False
        Me.TextBox1.Location = New System.Drawing.Point(0, 25)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(384, 215)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Initialisation..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtIP})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 240)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(384, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtIP
        '
        Me.txtIP.BackColor = System.Drawing.Color.Transparent
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(0, 17)
        Me.txtIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendButton, Me.EraseButton, Me.ToolStripDropDownButton1, Me.Reconnexion})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(384, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SendButton
        '
        Me.SendButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SendButton.Enabled = False
        Me.SendButton.Image = Global.InstantMess.My.Resources.Resources.sendmessage
        Me.SendButton.Name = "SendButton"
        Me.SendButton.Size = New System.Drawing.Size(23, 22)
        Me.SendButton.Text = "Envoyer un message"
        Me.SendButton.Visible = False
        '
        'EraseButton
        '
        Me.EraseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EraseButton.Image = Global.InstantMess.My.Resources.Resources.cleanup
        Me.EraseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EraseButton.Name = "EraseButton"
        Me.EraseButton.Size = New System.Drawing.Size(23, 22)
        Me.EraseButton.Text = "Effacer"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PseudoTextBox1, Me.UPnPToolStripMenuItem, Me.ToolStripTextBox1, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.InstantMess.My.Resources.Resources.tools
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "Options"
        '
        'PseudoTextBox1
        '
        Me.PseudoTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.PseudoTextBox1.Name = "PseudoTextBox1"
        Me.PseudoTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.PseudoTextBox1.ToolTipText = "Nom"
        '
        'UPnPToolStripMenuItem
        '
        Me.UPnPToolStripMenuItem.Checked = True
        Me.UPnPToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UPnPToolStripMenuItem.Name = "UPnPToolStripMenuItem"
        Me.UPnPToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.UPnPToolStripMenuItem.Text = "UPnP"
        Me.UPnPToolStripMenuItem.ToolTipText = "Activer/désactiver l'UPnP"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox1.ToolTipText = "IP locale"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExitToolStripMenuItem.Text = "Quitter"
        '
        'Reconnexion
        '
        Me.Reconnexion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Reconnexion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Reconnexion.Image = Global.InstantMess.My.Resources.Resources.connect
        Me.Reconnexion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Reconnexion.Name = "Reconnexion"
        Me.Reconnexion.Size = New System.Drawing.Size(23, 22)
        Me.Reconnexion.Text = "Reconnexion"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "IntantMess"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(111, 26)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ShowToolStripMenuItem.Text = "Ouvrir"
        '
        'HideTimer1
        '
        Me.HideTimer1.Interval = 1
        '
        'Sentinel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(384, 262)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(300, 150)
        Me.Name = "Sentinel"
        Me.Text = "InstantMess"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtIP As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SendButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents UPnPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EraseButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PseudoTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents HideTimer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Reconnexion As System.Windows.Forms.ToolStripButton

End Class
