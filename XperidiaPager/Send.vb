Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class Send
    Dim udpClient As New UdpClient
    Dim GLOIP As Net.IPAddress
    Dim bytCommand As Byte() = New Byte() {}
    Dim pRet As String
    Dim txtMessageP As String

    Dim port As Integer = 2015

    Private Delegate Sub UpdateDelegate(ByVal s As String)

    Private Sub Send_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        udpClient.Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelB.Click
        Me.Close()
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        SendButton.Enabled = False
        Dim pRet As Integer
        Dim ip As String
        ip = txtIP.Text
        If ip = "IP" Then
            ip = "0.0.0.0"
        End If
        If IsNumeric(ip) Then

        Else
            Try
                If ip = "DOMAIN" Then
                    ip = "domain.com"
                End If
                Dim hostname As IPHostEntry = Dns.GetHostEntry(ip)
                Dim ipraw As IPAddress() = hostname.AddressList
                For Each elem In ipraw
                    Console.WriteLine(elem)
                    If elem.AddressFamily.ToString() = ProtocolFamily.InterNetworkV6.ToString() Then
                        'ip = ipraw(0).MapToIPv4().ToString()
                    Else
                        ip = elem.ToString()
                    End If
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtInfo.Text = "Impossible de trouver le destinataire"
                Exit Sub
            End Try
        End If
        Try
            GLOIP = IPAddress.Parse(ip)
            udpClient.Connect(GLOIP, port)
            txtMessageP = txtMessage.Text
            bytCommand = Encoding.Unicode.GetBytes(txtMessageP)
            pRet = udpClient.Send(bytCommand, bytCommand.Length)
            Console.WriteLine("No of bytes send " & pRet)
            Console.WriteLine(Encoding.Unicode.GetString(bytCommand))
            Dim BitDet As BitArray
            BitDet = New BitArray(bytCommand)
            txtInfo.Text = txtInfo.Text + vbCrLf
            Dim tempStr As String
            Dim tempStr2 As String
            Dim i As Integer
            i = 0
            Dim j As Integer
            j = 0
            Dim line As Integer
            line = 0
            txtInfo.Text = txtInfo.Text + line.ToString & ") "
            For j = 0 To BitDet.Length - 1
                If BitDet(j) = True Then
                    Console.Write("1 ")
                    tempStr2 = tempStr
                    tempStr = " 1" + tempStr2
                Else
                    Console.Write("0 ")
                    tempStr2 = tempStr
                    tempStr = " 0" + tempStr2
                End If
                i += 1
                If i = 8 And j <= (BitDet.Length - 1) Then
                    line += 1
                    i = 0
                    txtInfo.Text = txtInfo.Text + tempStr
                    tempStr = ""
                    tempStr2 = ""
                    txtInfo.Text = txtInfo.Text + vbCrLf
                    If j <> (BitDet.Length - 1) Then
                        txtInfo.Text = txtInfo.Text + line.ToString & ") "
                        Console.WriteLine()
                    End If
                End If
            Next
            txtInfo.Text = "Message envoyé à " & ip & ":" & port
            SendButton.Enabled = True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            txtInfo.Text = ex.Message
            SendButton.Enabled = True
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        port = TextBox1.Text
    End Sub
End Class