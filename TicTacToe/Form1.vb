Public Class Form1
    Private game As Game
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        game = New Game(restartBtn, turnLbl)
        game.Init()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        game.HandlePress(0, Button1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        game.HandlePress(1, Button2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        game.HandlePress(2, Button3)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        game.HandlePress(3, Button4)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        game.HandlePress(4, Button5)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        game.HandlePress(5, Button6)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        game.HandlePress(6, Button7)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        game.HandlePress(7, Button8)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        game.HandlePress(8, Button9)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles restartBtn.Click
        Dim buttons = Controls.OfType(Of Button)
        game.Reset(restartBtn, buttons)
    End Sub
End Class
