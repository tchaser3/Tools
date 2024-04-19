'Title:     Vehicle Menu
'Date:      8/5/13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click

        'Shows the About Form
        About.Show()

    End Sub
    Private Sub btnSignOutAVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOutAVehicle.Click

        'Signs out a Vehicle
        SignOutAVehicle.Show()
        Me.Close()

    End Sub

    Private Sub btnSignInAVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignInAVehicle.Click

        'Signs In A Vehicle
        SignInAVehicle.Show()
        Me.Close()

    End Sub

    Private Sub btnVehiclesCurrentlyOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehiclesCurrentlyOut.Click

        'displays the vehicles signed out
        VehiclesCurrentlySignedOut.Show()
        Me.Close()

    End Sub

    Private Sub btnAvailableVehicles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailableVehicles.Click

        'Displays the Vehicles Available
        AvailableVehicles.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleAssignments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleAssignments.Click
        VehicleAssignmentChoice.Show()
        Me.Close()
    End Sub

    Private Sub btnRetiredVehicles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetiredVehicles.Click

        RetiredVehicles.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleHistory.Click

        'This Shows the Vehicle History
        VehicleHistory.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        MainMenu.Show()
        Me.Hide()

    End Sub

    Private Sub VehicleMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up when the form is loaded

        'Setting Local Variables
        Dim strGroup As String

        'Getting Group Information
        strGroup = Logon.mstrGroup

        'Setting rights within the application
        If (strGroup = "ADMIN" Or strGroup = "WAREHOUSE") Then
            btnSignOutAVehicle.Enabled = True
            btnSignInAVehicle.Enabled = True
            btnVehicleHistory.Enabled = True
            btnRetiredVehicles.Enabled = True
            btnVehicleMassSignIn.Enabled = True
        ElseIf (strGroup = "MANAGERS" Or strGroup = "OFFICE") Then
            btnVehicleHistory.Enabled = True
            btnRetiredVehicles.Enabled = True
        End If

    End Sub

    Private Sub btnVehicleReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleReports.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnVehicleMassSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMassSignIn.Click

        'This will launch the Vehicle Mass Sign In
        VehicleMassSignIn.Show()
        Me.Close()

    End Sub
End Class