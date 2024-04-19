'Title:     Signout Legend
'Date:      8/7/13
'Author:    Terry Holmes

Option Strict On

Public Class Legend



    Private Sub Legend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblAvailable.BackColor = Color.Green
        lblSignedOut.BackColor = Color.Blue
        lblDownForRepai.BackColor = Color.Red
        lblRetired.BackColor = Color.Black


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub
End Class