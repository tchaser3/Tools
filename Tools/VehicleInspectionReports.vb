'Title:         Vehicle Inspection Reports Menu
'Date:          10/28/14
'Author:        Terry Holmes

'Description:   This will list all of reports for Vehicle Inspections

Option Strict On

Public Class VehicleInspectionReports

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub


    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the Main Menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub


    Private Sub btnVehicleAuditReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleAuditReport.Click
        LastTransaction.Show()
        Logon.mstrTypeOfDateSearch = "DAILYVEHICLEAUDIT"
        DateSearchParameters.Show()
        Me.Close()
    End Sub

    Private Sub btnWeeklyVehicleInspectionsReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeeklyVehicleInspectionsReport.Click
        Logon.mstrTypeOfDateSearch = "WEEKLYINSPECTIONREPORT"
        LastTransaction.Show()
        DateSearchParameters.Show()
        Me.Close()
    End Sub

    Private Sub btnAvailableVehiclesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvailableVehiclesReport.Click

        'This will open the Daily Vehicle Availability Report
        LastTransaction.Show()
        DailyVehicleAvailabilityReport.Show()
        Me.Close()

    End Sub

    Private Sub btnInspectionsMenu_Click(sender As Object, e As EventArgs) Handles btnInspectionsMenu.Click
        LastTransaction.Show()
        InspectionsMenu.Show()
        Me.Close()
    End Sub

    Private Sub VehicleInspectionReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this will load the last transaction variable
        Logon.mstrLastTransactionSummary = "Loaded Vehicle Inspection Reports Menu"
    End Sub

    Private Sub btnVehicleInspectionHistory_Click(sender As Object, e As EventArgs) Handles btnVehicleInspectionHistory.Click

        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub btnDailyVehicleInspectionReport_Click(sender As Object, e As EventArgs) Handles btnDailyVehicleInspectionReport.Click

        Logon.mstrTypeOfDateSearch = "DAILYVEHICLEINSPECTIONREPORT"
        LastTransaction.Show()
        DateSearchParameters.Show()
        Me.Close()
    End Sub
End Class