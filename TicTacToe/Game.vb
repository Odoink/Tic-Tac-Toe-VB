Public Class Game

    Public currentPlayer As String
    Public grid As String() = New String(9) {}
    Public win As Boolean = False
    Private player1 As String = "X"
    Private player2 As String = "O"
    Private solutions As New List(Of Tuple(Of Integer, Integer, Integer))
    Private restartButton As Button
    Private turnLabel As Label
    Private turns As Integer

    Public Sub New(button As Button, lbl As Label)
        restartButton = button
        turnLabel = lbl
        AddSolutions()
    End Sub

    Private Sub AddSolutions()
        Dim solution As New Tuple(Of Integer, Integer, Integer)(0, 1, 2)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(3, 4, 5)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(6, 7, 8)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(0, 3, 6)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(1, 4, 7)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(2, 5, 8)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(0, 4, 8)
        solutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(2, 4, 6)
        solutions.Add(solution)
    End Sub

    Public Sub HandlePress(idx As Integer, btn As Button)
        btn.Enabled = False
        btn.Text = currentPlayer
        grid(idx) = currentPlayer
        CheckWinner()
        turns += 1
        SwitchPlayer()
    End Sub

    Public Sub Init()
        currentPlayer = player1
        grid = New String(9) {}
        win = False
        turnLabel.Text = $"{currentPlayer} is aan de beurt"
        turns = 0
    End Sub

    Public Sub SwitchPlayer()
        If Not win Then
            If currentPlayer Is player1 Then
                currentPlayer = player2
            Else
                currentPlayer = player1
            End If
            turnLabel.Text = $"{currentPlayer} is aan de beurt"
        ElseIf turns > 7 Then
            turnLabel.Text = ""
        Else
            turnLabel.Text = ""
        End If
    End Sub

    Public Sub CheckWinner()
        For i = 0 To 7
            Dim solution = solutions(i)
            Dim a = grid(solution.Item1)
            Dim b = grid(solution.Item2)
            Dim c = grid(solution.Item3)

            If a Is b And a Is c And a IsNot Nothing Then
                win = True
                Exit For
            End If
        Next
        If win Then
            MessageBox.Show($"{currentPlayer} heeft gewonnen!")
            turnLabel.Text = ""
            restartButton.Visible = True
        ElseIf turns > 7 Then
            MessageBox.Show("Gelijkspel")
            turnLabel.Text = ""
            restartButton.Visible = True
        End If
    End Sub
End Class
