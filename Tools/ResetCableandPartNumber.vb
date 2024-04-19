'Title:         Reset Cable and Part Number Message Box
'Date:          2/14/14
'Author:        Terry Holmes

'Description:   This form is used to answer whether the user want to select a New Part Number or
'               cable type

Option Strict On

Public Class ResetCableandPartNumber

    Private Sub ResetCableandPartNumber_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim strErrorMessage As String

        strErrorMessage = "Do want to choose another Cable Type and Part Number"
        lblDislpayMessage.Text = strErrorMessage

    End Sub

    Private Sub btnYes_Click(sender As System.Object, e As System.EventArgs) Handles btnYes.Click

        IssueCable.mblnResetPartNumber = True
        Me.Close()

    End Sub

    Private Sub btnNo_Click(sender As System.Object, e As System.EventArgs) Handles btnNo.Click

        Me.Close()

    End Sub
End Class