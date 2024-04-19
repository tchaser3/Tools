'Title:     About
'Date:      3/28/13
'Author:    Terry Holmes

Option Strict On

Public Class About

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Close the about box
        Logon.mstrLastTransactionSummary = "OPENED ABOUT BOX"
        LastTransaction.Show()
        Me.Close()
    End Sub
End Class