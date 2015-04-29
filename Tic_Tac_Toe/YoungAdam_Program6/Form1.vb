Option Explicit On
Option Strict On

Public Class Form1
    'Declare Global Variables
    Dim x_turn As Boolean
    Dim xscore As Integer
    Dim oscore As Integer
    Dim clickcount As Integer
    Dim play As Boolean = False

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        'Declaration section
        Dim p1Name, p2Name As String

        'Set play to true
        play = True

        'Get player names with validation
        Do
            p1Name = InputBox("Please enter player 1", "Tic Tac Toe")
        Loop While p1Name = ""
        Do
            p2Name = InputBox("Please enter player 2", "Tic Tac Toe")
        Loop While p2Name = ""

        'Call function to put players in correct text box
        SetPlayers(p1Name, p2Name)

        'Call function to set the board
        SetAll()

    End Sub
    '************************************************************
    '*
    '* Function:      SetPlayers()
    '* 
    '* Description:   Puts the names of the players in the correct text box
    '*
    '* Parameters:    none
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Sub SetPlayers(ByRef p1Name As String, ByRef p2Name As String)
        txtP1Name.Text = P1Name
        txtP2Name.Text = p2Name

    End Sub
    '************************************************************
    '*
    '* Function:      SetAll()
    '* 
    '* Description:   sets all spaces to nothing at the beginning of the game
    '*
    '* Parameters:    none
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Sub SetAll()
        L1.Text = ""
        L2.Text = ""
        L3.Text = ""
        L4.Text = ""
        L5.Text = ""
        L6.Text = ""
        L7.Text = ""
        L8.Text = ""
        L9.Text = ""
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click
        'Reset variables
        ResetVariables(x_turn, xscore, oscore, clickcount, play)
        
        'Reset player names
        ResetPlayers(txtP1Name.Text, txtP2Name.Text)

        'Reset squares to original letters and colors
        ResetBoard(L1.Text, L2.Text, L3.Text, L4.Text, L5.Text, L6.Text, L7.Text, L8.Text, L9.Text)
        'Set the initial colors of the text
        L1.ForeColor = Color.Yellow
        L2.ForeColor = Color.Orange
        L3.ForeColor = Color.Red
        L4.ForeColor = Color.Teal
        L5.ForeColor = Color.Blue
        L6.ForeColor = Color.Green
        L7.ForeColor = Color.Purple
        L8.ForeColor = Color.Fuchsia

        'Reset play back to false
        play = False
    End Sub
    Sub ResetPlayers(ByRef p1Name As String, ByRef p2Name As String)
        p1Name = ""
        p2Name = ""
    End Sub
    Sub ResetVariables(ByRef x_turn As Boolean, ByRef xscore As Integer, ByRef oscore As Integer, _
                       ByRef clickcount As Integer, ByRef play As Boolean)
        x_turn = True
        xscore = 0
        oscore = 0
        clickcount = 0
        play = False
    End Sub
    Sub ResetBoard(ByRef L1 As String, ByRef L2 As String, ByRef L3 As String, ByRef L4 As String, _
                   ByRef L5 As String, ByRef L6 As String, ByRef L7 As String, ByRef L8 As String, ByRef L9 As String)
        L1 = "T"
        L2 = "I"
        L3 = "C"
        L4 = "T"
        L5 = "A"
        L6 = "C"
        L7 = "T"
        L8 = "O"
        L9 = "E"
    End Sub

    Private Sub L1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L1.Click
        If play And L1.Text = "" Then
            CellClicked(1)
        End If
    End Sub

    Private Sub L2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L2.Click
        If play And L2.Text = "" Then
            CellClicked(2)
        End If
    End Sub

    Private Sub L3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L3.Click
        If play And L3.Text = "" Then
            CellClicked(3)
        End If
    End Sub

    Private Sub L4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L4.Click
        If play And L4.Text = "" Then
            CellClicked(4)
        End If
    End Sub

    Private Sub L5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L5.Click
        If play And L5.Text = "" Then
            CellClicked(5)
        End If
    End Sub

    Private Sub L6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L6.Click
        If play And L6.Text = "" Then
            CellClicked(6)
        End If
    End Sub

    Private Sub L7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L7.Click
        If play And L7.Text = "" Then
            CellClicked(7)
        End If
    End Sub

    Private Sub L8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L8.Click
        If play And L8.Text = "" Then
            CellClicked(8)
        End If
    End Sub

    Private Sub L9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L9.Click
        If play And L9.Text = "" Then
            CellClicked(9)
        End If
    End Sub
    '************************************************************
    '*
    '* Function:      CellClicked()
    '* 
    '* Description:   calls ShowXO() and CheckWin()
    '*
    '* Parameters:    cellLetter
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Sub CellClicked(ByVal blocknumber As Integer)
        Dim win As Boolean

        clickcount += 1

        If clickcount = 1 Then
            x_turn = True
        End If

        ShowXO(blocknumber)
        If x_turn = True Then
            x_turn = False
        Else
            x_turn = True
        End If

        If clickcount >= 5 Then
            win = CheckWin(L1.Text, L2.Text, L3.Text, L4.Text, L5.Text, L6.Text, L7.Text, L8.Text, L9.Text)
        End If

        If win Then
            IncrementScore()
            ShowScore()
            SetAll()
            clickcount = 0
            x_turn = True
        End If

        If clickcount = 9 And win = False Then
            MsgBox("Game Over: tie", MsgBoxStyle.Information, "Tic Tac Toe")
            SetAll()
            clickcount = 0
            x_turn = True
        End If
    End Sub
    '************************************************************
    '*
    '* Function:      ShowXO()
    '* 
    '* Description:   Determines if the click is X or O
    '*
    '* Parameters:    bn (blocknumber)
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Sub ShowXO(ByVal bn As Integer)
        Dim cellLetter As String

        If x_turn = True Then
            cellLetter = "X"
        Else
            cellLetter = "O"
        End If

        If bn = 1 Then
            L1.ForeColor = Color.Black
            L1.Text = cellLetter
        ElseIf bn = 2 Then
            L2.ForeColor = Color.Black
            L2.Text = cellLetter
        ElseIf bn = 3 Then
            L3.ForeColor = Color.Black
            L3.Text = cellLetter
        ElseIf bn = 4 Then
            L4.ForeColor = Color.Black
            L4.Text = cellLetter
        ElseIf bn = 5 Then
            L5.ForeColor = Color.Black
            L5.Text = cellLetter
        ElseIf bn = 6 Then
            L6.ForeColor = Color.Black
            L6.Text = cellLetter
        ElseIf bn = 7 Then
            L7.ForeColor = Color.Black
            L7.Text = cellLetter
        ElseIf bn = 8 Then
            L8.ForeColor = Color.Black
            L8.Text = cellLetter
        Else
            L9.ForeColor = Color.Black
            L9.Text = cellLetter
        End If

    End Sub
    '************************************************************
    '*
    '* Function:      CheckWin()
    '* 
    '* Description:   Checks to see if there is a win or draw
    '*
    '* Parameters:    cc, L1, L2, L3, L4, L5, L6, L7, L8, L9
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Function CheckWin(ByVal cell1 As String, ByVal cell2 As String, ByVal cell3 As String, _
                      ByVal cell4 As String, ByVal cell5 As String, ByVal cell6 As String, ByVal cell7 As String, _
                      ByVal cell8 As String, ByVal cell9 As String) As Boolean
        If (cell1 = "X" And cell2 = "X" And cell3 = "X") Or (cell1 = "O" And cell2 = "O" And cell3 = "O") Then
            L1.ForeColor = Color.Red
            L2.ForeColor = Color.Red
            L3.ForeColor = Color.Red
            Return True
        ElseIf (cell4 = "X" And cell5 = "X" And cell6 = "X") Or (cell4 = "O" And cell5 = "O" And cell6 = "O") Then
            L4.ForeColor = Color.Red
            L5.ForeColor = Color.Red
            L6.ForeColor = Color.Red
            Return True
        ElseIf (cell7 = "X" And cell8 = "X" And cell9 = "X") Or (cell7 = "O" And cell8 = "O" And cell9 = "O") Then
            L7.ForeColor = Color.Red
            L8.ForeColor = Color.Red
            L9.ForeColor = Color.Red
            Return True
        ElseIf (cell1 = "X" And cell4 = "X" And cell7 = "X") Or (cell1 = "O" And cell4 = "O" And cell7 = "O") Then
            L1.ForeColor = Color.Red
            L4.ForeColor = Color.Red
            L7.ForeColor = Color.Red
            Return True
        ElseIf (cell2 = "X" And cell5 = "X" And cell8 = "X") Or (cell2 = "O" And cell5 = "O" And cell8 = "O") Then
            L2.ForeColor = Color.Red
            L5.ForeColor = Color.Red
            L8.ForeColor = Color.Red
            Return True
        ElseIf (cell3 = "X" And cell6 = "X" And cell9 = "X") Or (cell3 = "O" And cell6 = "O" And cell9 = "O") Then
            L3.ForeColor = Color.Red
            L6.ForeColor = Color.Red
            L9.ForeColor = Color.Red
            Return True
        ElseIf (cell1 = "X" And cell5 = "X" And cell9 = "X") Or (cell1 = "O" And cell5 = "O" And cell9 = "O") Then
            L1.ForeColor = Color.Red
            L5.ForeColor = Color.Red
            L9.ForeColor = Color.Red
            Return True
        ElseIf (cell3 = "X" And cell5 = "X" And cell7 = "X") Or (cell3 = "O" And cell5 = "O" And cell7 = "O") Then
            L3.ForeColor = Color.Red
            L5.ForeColor = Color.Red
            L7.ForeColor = Color.Red
            Return True
        Else
            Return False
        End If

    End Function
    '************************************************************
    '*
    '* Function:      IncrementScore()
    '* 
    '* Description:   If there is a win, then the player's score increases by 1
    '*
    '* Parameters:    none
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Sub IncrementScore()
        If x_turn = False Then
            MsgBox("Game Over: Xs Win", MsgBoxStyle.Information, "Tic Tac Toe")
            xscore += 1
        Else
            MsgBox("Game Over: Os Win", MsgBoxStyle.Information, "Tic Tac Toe")
            oscore += 1
        End If
    End Sub
    '************************************************************
    '*
    '* Function:      ShowScore
    '* 
    '* Description:   Shows current score to the users
    '*
    '* Parameters:    none
    '*
    '* Author name:   Adam Young
    '*
    '************************************************************
    Sub ShowScore()
        txtP1Points.Text = CStr(xscore)
        txtP2Points.Text = CStr(oscore)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
