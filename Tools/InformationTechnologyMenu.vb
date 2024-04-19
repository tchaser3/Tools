'Title:         Information Technology
'Date:          9-15-14
'Author:        Terry Holmes

'Description:   

Public Class InformationTechnologyMenu

    Private TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAddDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDevice.Click

        'This will open the Add Information Technology Device Form
        LastTransaction.Show()
        AddInformationTechnologyDevice.Show()
        Me.Close()

    End Sub

    Private Sub btnIssueDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueDevice.Click

        'This will call the Issue Information Technology Device
        LastTransaction.Show()
        IssueInformationTechnologyDevice.Show()
        Me.Close()

    End Sub

    Private Sub btnReturnDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnDevice.Click

        'This will call the return form
        LastTransaction.Show()
        ReturnInformationTechnologyDevices.Show()
        Me.Close()

    End Sub

    Private Sub btnAvailableDevices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailableDevices.Click

        LastTransaction.Show()
        ViewAvailableInformationTechnologyDevices.Show()
        Me.Close()

    End Sub

    Private Sub btnIssuedDevices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssuedDevices.Click

        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnDeviceInspection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceInspection.Click

        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnReportTechnologyProblem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportTechnologyProblem.Click

        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    
    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Displays the Main Menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click

        'This will launch the Change Password
        LastTransaction.Show()
        ChangeInformationTechnologyPassword.Show()
        Me.Close()

    End Sub

    Private Sub btnDeviceReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceReports.Click

        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnRetireDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetireDevice.Click

        'Displays the Retire Information Technology Device Form
        LastTransaction.Show()
        RetireInformationTechnologyDevice.Show()
        Me.Close()

    End Sub

    Private Sub InformationTechnologyMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'This will set the last transaction
        Logon.mstrLastTransactionSummary = "LOADED INFORMATION TECHNOLOGY MENU"

    End Sub

    Private Sub btnEditDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDevice.Click
        LastTransaction.Show()
        EditInformationTechnologyDevice.Show()
        Me.Close()
    End Sub

    Private Sub btnUpdateTechnologyProblem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateTechnologyProblem.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnProblemReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProblemReport.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub
End Class