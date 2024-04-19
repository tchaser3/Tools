'Title:         Vehicle Sheet Entry Confirmation
'Date:          9/27/13
'Author:        Terry Holmes

Option Strict On

Public Class AllVehicleSheetsDone

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click

        VehicleInventorySheets.mstrDoneDataEntry = "YES"
        Me.Close()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click

        VehicleInventorySheets.mstrDoneDataEntry = "NO"
        Me.Close()

    End Sub
End Class