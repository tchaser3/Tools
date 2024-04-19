'Title:         Tools Menu
'Date:          4/15/13
'Author:        Terry Holmes

'Description:   This is the Tools Menu

Option Strict On

Public Class ToolsMenu

    Private TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click

        'Shows the About Form
        About.ShowDialog()

    End Sub

    Private Sub btnSignOutATool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignOutATool.Click

        'Opens the Sign Out A Tool Form
        SignOutATool.Show()
        Me.Close()

    End Sub

    Private Sub btnSignInATool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignInATool.Click

        'Opens the Sign In A Tool Form
        SignInATool.Show()
        Me.Close()

    End Sub

    Private Sub btnAvailableTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailableTools.Click

        'Opens the Available Tools Form
        ToolsAvailable.Show()
        Me.Close()

    End Sub

    Private Sub btnToolHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolHistory.Click

        'Opens the Tool History Form
        ToolHistory.Show()
        Me.Close()

    End Sub

    Private Sub ToolsMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'This will load up when the form is loaded

        'Setting Local Variables
        Dim strGroup As String

        'Getting Group Information
        strGroup = Logon.mstrGroup

        'Setting rights within the application
        If (strGroup = "ADMIN" Or strGroup = "WAREHOUSE") Then
            btnSignOutATool.Enabled = True
            btnSignInATool.Enabled = True
            btnToolHistory.Enabled = True
            btnToolsAssignedToTechnicans.Enabled = True
            btnRetiredTools.Enabled = True
            btnRetiredTools.Enabled = True
        ElseIf (strGroup = "MANAGERS" Or strGroup = "OFFICE") Then
            btnToolHistory.Enabled = True
            btnToolsAssignedToTechnicans.Enabled = True
            btnRetiredTools.Enabled = True
            btnRetiredTools.Enabled = True
        End If


    End Sub

    Private Sub btnToolsCurrentlyOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolsCurrentlyOut.Click

        'Opens the tool Signed out form
        ToolsCurrentlySignedOut.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnToolsAssignedToTechnicans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolsAssignedToTechnicans.Click

        'This will launch the Technician Tool Queue
        TechnicianToolQueues.Show()
        Me.Close()
    End Sub

    Private Sub btnRetiredTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetiredTools.Click

        'This will launch the Retired Tool Form
        RetiredTools.Show()
        Me.Close()

    End Sub

    Private Sub btnDitchWitches_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDitchWitches.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnSpecialtyTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpecialtyTools.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub
End Class