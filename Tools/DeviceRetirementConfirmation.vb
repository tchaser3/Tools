'Title:         Device Retirement Confirmation
'Date:          10/1/14
'Author:        Terry Holmes

'Description:   This is use to confirm the retirement of devices and equipment

Option Strict On

Public Class DeviceRetirementConfirmation

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        'This will confirm your choices
        Logon.mblnDeviceConfirmation = True
        Me.Close()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        'This will decline your choice
        Logon.mblnDeviceConfirmation = False
        Me.Close()

    End Sub
End Class