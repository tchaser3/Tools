'Title:         Use Cable Used Form
'Date:          8/27/14
'Author:        Terry Holmes

'Description:   This form is used for asking the user, in the form of a dialog box, if they want to use the cable pulled

Option Strict On

Public Class UseCablePulled

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        CableUsage.mblnUseFootagePulled = True
        Me.Close()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        CableUsage.mblnUseFootagePulled = False
        Me.Close()

    End Sub

    Private Sub UseCablePulled_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim strLabelMessage As String

        'Setting output message to user
        strLabelMessage = CableUsage.mstrCabledPulled + " Was Pulled for this Order, Was All Of The Issued Cable Used"
        lblUserMessage.Text = strLabelMessage

    End Sub
End Class