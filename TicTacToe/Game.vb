Public Class Game

    Public strCurrentPlayer As String
    Public strGrid As String() = New String(9) {}
    Public boolWin As Boolean = False
    Private ReadOnly strPlayer1 As String = "X"
    Private ReadOnly strPlayer2 As String = "O"
    Private ReadOnly lstSolutions As New List(Of Tuple(Of Integer, Integer, Integer))
    Private restartButton As Button
    Private turnLabel As Label
    Private intTurns As Integer
    Private boolDraw = False

    Public Sub New(button As Button, lbl As Label)
        restartButton = button
        turnLabel = lbl
        AddSolutions()
    End Sub

    'Add all possible solutions to a list of solutions'
    Private Sub AddSolutions()
        Dim solution As New Tuple(Of Integer, Integer, Integer)(0, 1, 2)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(3, 4, 5)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(6, 7, 8)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(0, 3, 6)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(1, 4, 7)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(2, 5, 8)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(0, 4, 8)
        lstSolutions.Add(solution)
        solution = New Tuple(Of Integer, Integer, Integer)(2, 4, 6)
        lstSolutions.Add(solution)
    End Sub

    'Handle button onclick'
    Public Sub HandlePress(idx As Integer, btn As Button)
        btn.Enabled = False
        btn.Text = strCurrentPlayer
        strGrid(idx) = strCurrentPlayer
        intTurns += 1
        CheckWinner()
        SwitchPlayer()
    End Sub

    'Initialize new game'
    Public Sub Init()
        'Set current player'
        strCurrentPlayer = strPlayer1
        'Empty grid'
        strGrid = New String(9) {}
        'Set both booleans to false'
        boolWin = False
        boolDraw = False
        turnLabel.Text = $"{strCurrentPlayer} is aan de beurt"
        intTurns = 0
    End Sub

    'switches the current player'
    Public Sub SwitchPlayer()
        'check if the game is not over'
        If Not boolWin And Not boolDraw Then
            If strCurrentPlayer Is strPlayer1 Then
                strCurrentPlayer = strPlayer2
            Else
                strCurrentPlayer = strPlayer1
            End If
            'change current player label'
            turnLabel.Text = $"{strCurrentPlayer} is aan de beurt"
        Else
            'if the game is over, empty current player label'
            turnLabel.Text = ""
        End If
    End Sub


    'Check if someone has 3 in a row'
    Public Sub CheckWinner()
        'loop through all possible solutions'
        For i = 0 To 7
            Dim solution = lstSolutions(i)
            Dim a = strGrid(solution.Item1)
            Dim b = strGrid(solution.Item2)
            Dim c = strGrid(solution.Item3)

            If a Is b And a Is c And a IsNot Nothing Then
                boolWin = True
                Exit For
            End If
        Next
        If boolWin Then
            MessageBox.Show($"{strCurrentPlayer} heeft gewonnen!")
            turnLabel.Text = ""
            restartButton.Visible = True
        ElseIf intTurns >= 9 Then
            boolDraw = True
            MessageBox.Show("Gelijkspel")
            turnLabel.Text = ""
            restartButton.Visible = True
        End If
    End Sub

    'Reset everything for new game'
    Public Sub Reset(restartBtn As Button, buttons As IEnumerable(Of Button))
        restartBtn.Visible = False
        'Enable every play button'
        For i = 1 To 9
            buttons(i).Enabled = True
            buttons(i).Text = ""
        Next
        Init()
    End Sub
End Class
