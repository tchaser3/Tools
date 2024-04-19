'Title:         Close The Form
'Date:          3/25/14
'Author:        Terry Holmes

'Description:   This program will confirm whether the program is to Close or No

Option Strict On

Public Class CloseTheProgram

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        'This is to confirm the close
        LastTransaction.Show()
        Logon.Close()
        Me.Close()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        'This is to confirm the close
        Me.Close()

    End Sub
End Class