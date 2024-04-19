'Title:         Issue More Cable 
'Date:          2/19/14
'Author:        Terry Holmes

'Description:   This Form is used for the have the user make a decision on whether they are 
'               issuing more cable.

Option Strict On

Public Class ContineIssuseCable

    Private Sub btnNo_Click(sender As System.Object, e As System.EventArgs) Handles btnNo.Click

        'This will run when the button is pressed
        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnYes_Click(sender As System.Object, e As System.EventArgs) Handles btnYes.Click

        'This will run when the button is pressed
        SearchForProject.Show()
        Me.Close()

    End Sub
End Class