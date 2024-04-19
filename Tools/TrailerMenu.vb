'Title:         Trailer Menu
'Date:          3/12/14
'Author:        Terry Holmes

'Description:   This form is for the Trailers

Option Strict On

Public Class TrailerMenu

    Dim TheModuleUnderDevelopement As New ModuleUnderDevelopment

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(sender As System.Object, e As System.EventArgs) Handles btnMainMenu.Click

        'Shows Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAbout_Click(sender As System.Object, e As System.EventArgs) Handles btnAbout.Click

        'Shows the About Box
        About.Show()

    End Sub

    Private Sub btnSignOutTrailer_Click(sender As System.Object, e As System.EventArgs) Handles btnSignOutTrailer.Click

        SignOutATrailer.Show()
        Me.Close()

    End Sub

    Private Sub SignInTrailer_Click(sender As System.Object, e As System.EventArgs) Handles SignInTrailer.Click

        'Shows the Sign In a Trailer
        SignInATrailer.Show()
        Me.Close()
    End Sub

    Private Sub btnTrailersInUse_Click(sender As System.Object, e As System.EventArgs) Handles btnTrailersInUse.Click
        'Shows the Trailer Availability form
        TrailersInUse.Show()
        Me.Close()
    End Sub

    Private Sub btnAvailableTrailers_Click(sender As System.Object, e As System.EventArgs) Handles btnAvailableTrailers.Click
        TheModuleUnderDevelopement.UnderDevelopment()
    End Sub

    Private Sub btnViewTrailerHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnViewTrailerHistory.Click

        'This will show the trailer history
        ViewTrailerHistory.Show()
        Me.Close()

    End Sub

    Private Sub btnViewTrailerInspections_Click(sender As System.Object, e As System.EventArgs) Handles btnViewTrailerInspections.Click
        TheModuleUnderDevelopement.UnderDevelopment()
    End Sub

    Private Sub btnCreateTrailerWorkOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateTrailerWorkOrder.Click
        TheModuleUnderDevelopement.UnderDevelopment()
    End Sub

    Private Sub btnUpdateTrailerWorkOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateTrailerWorkOrder.Click
        TheModuleUnderDevelopement.UnderDevelopment()
    End Sub

    Private Sub btnCloseTrailerWorkOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseTrailerWorkOrder.Click
        TheModuleUnderDevelopement.UnderDevelopment()
    End Sub
End Class