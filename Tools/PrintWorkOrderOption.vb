'Title:         Print Work Order Option
'Date:          11-12-14
'Author:        Terry Holmes

'Description:   This will allow the user to decide to print

Option Strict On

Public Class PrintWorkOrderOption

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        'This will close the form
        Me.Close()

    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        'This will load up the Print Work Order Form
        PrintWorkOrder.Show()
        Me.Close()

    End Sub
End Class