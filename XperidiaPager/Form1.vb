Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class Sentinel

    Public receivingUdpClient As UdpClient
    Public RemoteIpEndPoint As New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
    Public ThreadReceive As System.Threading.Thread

    Dim upnpnat As New NATUPNPLib.UPnPNAT
    Dim mappings As NATUPNPLib.IStaticPortMappingCollection = upnpnat.StaticPortMappingCollection
    Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
    Dim internalip As String = h.AddressList.GetValue(0).ToString

    Dim allowquit As Boolean
    Dim antispamfin As Boolean
    Dim debug As Boolean = False
    Dim Message As String

    Dim WithEvents Player As WMPLib.WindowsMediaPlayer

    Public Sub ReceiveMessages()
        Try
            Dim receiveBytes As [Byte]() = receivingUdpClient.Receive(RemoteIpEndPoint)
            Dim BitDet As BitArray
            BitDet = New BitArray(receiveBytes)

            Dim strReturnData As String = System.Text.Encoding.Unicode.GetString(receiveBytes)
            Message = Encoding.Unicode.GetChars(receiveBytes)
            txtIP.Text = "Dernier message reçu à " & TimeOfDay
            If Message.Length > 5 Then
                If Message.Substring(0, 5) = "#WMP#" Then
                    PlayFile(Message.Remove(0, 5))
                    TextBox1.AppendText(vbCrLf & TimeOfDay & " : Lecture WMP de """ & Message.Remove(0, 5) & """")
                Else
                    TextBox1.AppendText(vbCrLf & TimeOfDay & " : """ & Message & """")
                    MessageP(Message)
                End If
            Else
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : """ & Message & """")
                MessageP(Message)
            End If
            NewInitialize()
        Catch e As Exception

        End Try
    End Sub

    Public Sub NewInitialize()
        ThreadReceive = New System.Threading.Thread(AddressOf ReceiveMessages)
        ThreadReceive.Start()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = internalip
        TextBox1.Text = TimeOfDay & " : Initialisation"
#If debug = True Then
        Me.Text = Me.Text & " [MASTER]"
        debug = True
        SendButton.Enabled = True
        SendButton.Visible = True
#Else
        If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).GetValue(ProductName) Is Nothing Then
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(ProductName, """" & Application.ExecutablePath & """")
        End If
        HideTimer1.Enabled = True
#End If
        If debug = False Then
            Try
                receivingUdpClient = New System.Net.Sockets.UdpClient(2015)
                ThreadReceive = New System.Threading.Thread(AddressOf ReceiveMessages)
                ThreadReceive.Start()
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : Connecté")
                txtIP.Text = "Connecté"
            Catch x As Exception
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : Erreur connexion")
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : " & x.Message)
                txtIP.Text = "Erreur connexion"
            End Try
            If My.Settings.UPnP = True Then
                Try
                    mappings.Add(2015, "UDP", 2015, internalip, True, "InstantMess")
                    UPnPToolStripMenuItem.Checked = True
                    TextBox1.AppendText(vbCrLf & TimeOfDay & " : UPnP activé")
                    txtIP.Text = txtIP.Text & " et UPnP activé"
                Catch x As Exception
                    UPnPToolStripMenuItem.Checked = False
                    TextBox1.AppendText(vbCrLf & TimeOfDay & " : Erreur UPnP")
                    TextBox1.AppendText(vbCrLf & TimeOfDay & " : " & x.Message)
                    txtIP.Text = txtIP.Text & " et erreur UPnP"
                    My.Settings.UPnP = False
                End Try
            Else
                UPnPToolStripMenuItem.Checked = False
                txtIP.Text = txtIP.Text & " et UPnP désactivé"
            End If
        End If
        
        If My.Settings.Pseudo = "" Then
            Try
                Dim DomainUser As String = System.Security.Principal.WindowsIdentity.GetCurrent.Name.Replace("\", "/")
                Dim ADEntry As New System.DirectoryServices.DirectoryEntry("WinNT://" & DomainUser)
                Dim FullName As String = ADEntry.Properties("FullName").Value
                My.Settings.Pseudo = FullName
            Catch ex As Exception
                txtIP.Text = txtIP.Text & " et votre nom est introuvable !"
            End Try
        End If
        PseudoTextBox1.Text = My.Settings.Pseudo
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If allowquit = True Then
            Dim result = MessageBox.Show("Vous êtes sûr de fermer InstantMess ?", "Confirmez", _
                                 MessageBoxButtons.YesNo, _
                                 MessageBoxIcon.Question)
            If (result = DialogResult.No) Then
                e.Cancel = True
            Else
                Try
                    receivingUdpClient.Close()
                Catch ex As Exception

                End Try
            End If
        Else
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Send.Show()
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Reconnexion.Click
        Try
            receivingUdpClient.Close()
        Catch ex As Exception
            TextBox1.Text = TextBox1.Text & vbCrLf & ex.Message
            txtIP.Text = "Erreur"
        End Try
        Try
            receivingUdpClient = New System.Net.Sockets.UdpClient(2015)
            ThreadReceive = New System.Threading.Thread(AddressOf ReceiveMessages)
            ThreadReceive.Start()
            TextBox1.AppendText(vbCrLf & TimeOfDay & " : Connecté")
            txtIP.Text = "Connecté"
        Catch x As Exception
            TextBox1.AppendText(vbCrLf & TimeOfDay & " : " & x.Message)
            txtIP.Text = "Erreur"
        End Try
    End Sub

    Private Sub UPnPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPnPToolStripMenuItem.Click
        If UPnPToolStripMenuItem.Checked = True Then
            Try
                mappings.Remove(2015, "UDP")
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : UPnP désactivé")
                txtIP.Text = "UPnP désactivé"
            Catch ex As Exception
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : Erreur UPnP")
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : " & ex.Message)
                txtIP.Text = "Erreur UPnP"
            End Try
            UPnPToolStripMenuItem.Checked = False
            My.Settings.UPnP = False
            My.Settings.Save()
        Else
            Try
                mappings.Remove(2015, "UDP")
            Catch ex As Exception

            End Try
            Try
                mappings.Add(2015, "UDP", 2015, internalip, True, "InstantMess")
                UPnPToolStripMenuItem.Checked = True
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : UPnP activé")
                txtIP.Text = "UPnP activé"
                My.Settings.UPnP = True
                My.Settings.Save()
            Catch x As Exception
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : Erreur UPnP")
                TextBox1.AppendText(vbCrLf & TimeOfDay & " : " & x.Message)
                txtIP.Text = "Erreur UPnP"
            End Try
        End If
    End Sub

    Private Sub EraseButton_Click(sender As Object, e As EventArgs) Handles EraseButton.Click
        TextBox1.Text = ""
    End Sub

    Private Sub PseudoTextBox1_LostFocus(sender As Object, e As EventArgs) Handles PseudoTextBox1.LostFocus
        My.Settings.Pseudo = PseudoTextBox1.Text
        My.Settings.Save()
    End Sub

    Private Sub ToolStripTextBox1_LostFocus(sender As Object, e As EventArgs) Handles ToolStripTextBox1.LostFocus
        internalip = ToolStripTextBox1.Text
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.MouseDoubleClick, ShowToolStripMenuItem.Click
        Me.Visible = True
    End Sub

    Private Sub HideTimer1_Tick(sender As Object, e As EventArgs) Handles HideTimer1.Tick
        Me.Visible = False
        HideTimer1.Enabled = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        allowquit = True
        Me.Close()
    End Sub

    Private Sub MessageP(ByVal txt As String)
        If InvokeRequired Then
            Invoke(Sub() Alert.Show())
            Invoke(Sub() Alert.Label1.Text = txt)
        Else
            Alert.Show()
            Alert.Label1.Text = txt
        End If
    End Sub

    Private Sub PlayFile(ByVal url As String)
        Player = New WMPLib.WindowsMediaPlayer
        Player.URL = url
        Player.controls.play()
    End Sub

    Private Sub Player_MediaError(ByVal pMediaObject As Object) _
                              Handles Player.MediaError
        TextBox1.AppendText(" (Problème avec le Lecteur Windows Media)")
    End Sub

End Class
