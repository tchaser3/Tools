'Title:         Command Confirmation
'Date:          11-9-15
'Author:        Terry Holmes

'Description:   This form is used to confirm a command

Option Strict On

Public Class CommandConfirmation

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Logon.mblnAreYouSure = True
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Logon.mblnAreYouSure = False
        Me.Close()
    End Sub
End Class