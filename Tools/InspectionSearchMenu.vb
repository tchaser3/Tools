'Title:         Inspection Search Menu
'Date:          11/1/13
'Author:        Terry Holmes

'Description:   This form is used to provide different search functions

Option Strict On

Public Class InspectionSearchMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        'Opens the About Box
        About.ShowDialog()
    End Sub
    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub txtDailyVehicleLogSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDailyVehicleLogSearch.Click

        'Opens Up the Daily Vehicle Inspection Form
        Logon.mstrTypeOfDateSearch = "DAILYVEHICLEINSPECTION"
        DateSearchParameters.Show()
        Me.Close()

    End Sub

    Private Sub txtWeeklyVehicleLogSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWeeklyVehicleLogSearch.Click

        'Displays the Weekly Inspection Form
        Logon.mstrTypeOfDateSearch = "WEEKLYVEHICLEINSPECTION"
        DateSearchParameters.Show()
        Me.Close()

    End Sub
    Private Sub btnDailyVehicleAuditReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyVehicleAuditReport.Click

        Logon.mstrTypeOfDateSearch = "VEHICLESHEETAUDIT"
        DateSearchParameters.Show()
        Me.Close()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnSearchDailyInspectionsByOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDailyInspectionsByOperator.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub btnSearchDailyInspectionsByVehicleNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDailyInspectionsByVehicleNumber.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub btnSearchWeeklyInspectionByVehicleNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchWeeklyInspectionByVehicleNumber.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub
End Class