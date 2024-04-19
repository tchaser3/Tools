'Title:         Chose the Vehicle Series
'Date:          8/6/13
'Author:        Terry Holmes

'Description:   From this form, the user will pick the vehicle series to view

Option Strict On

Public Class VehicleAssignmentChoice

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btn1100Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1100Series.Click

        VehicleSeries1100Availability.Show()
        Me.Close()

    End Sub

    Private Sub btn1500Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1500Series.Click

        VehicleSeries1500Availability.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMenu.Click

        VehicleMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btn1200Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1200Series.Click

        VehicleSeries1200Availability.Show()
        Me.Close()

    End Sub
End Class