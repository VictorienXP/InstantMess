Public Class Alert

    Private Sub Alert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub CloseActions(sender As Object, e As EventArgs) Handles Label1.Click, Me.Click, Me.KeyPress, Label1.KeyPress
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.BackColor = Color.Red Then
            Me.BackColor = Color.Black
            Label1.ForeColor = Color.White
        ElseIf Me.BackColor = Color.Black Then
            Me.BackColor = Color.Red
            Label1.ForeColor = Color.Black
        End If
        Try
            My.Computer.Audio.Play("C:\Windows\Media\Windows Information Bar.wav")
        Catch ex As Exception

        End Try
    End Sub
End Class