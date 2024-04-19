'Title:         Is Reel Issued
'Date:          6/2/14
'Author:        Terry Holmes

'Description:   When the user issued a reel out, this will setup a boolean variable

Option Strict On

Public Class IssuedCompleteReel

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        IssueCable.mblnIssuedCompleteReel = True
        Me.Close()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        IssueCable.mblnIssuedCompleteReel = False
        Me.Close()

    End Sub
End Class