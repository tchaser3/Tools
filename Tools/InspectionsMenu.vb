'Title:         Inspections Menu
'Date:          7/29/13
'Author:        Terry Holmes

'Description:   This is the Inspections Menu

Option Strict On

Public Class InspectionsMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    
    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnDailyVehicleInspection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyVehicleInspection.Click


        Logon.mstrFormForDataEntry = "DOTFORM"
        DataEntryDate.Show()
        Me.Close()

    End Sub
    Private Sub btnWeeklyVehicleInspection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeeklyVehicleInspection.Click

        WeeklyVehicleInspections.Show()
        Me.Close()

    End Sub


    Private Sub btnViewDailyInspectionLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDailyInspectionLog.Click
        ViewDailyInspectionLog.Show()
        Me.Close()
    End Sub

    Private Sub btnViewWeeklyInspectionLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewWeeklyInspectionLog.Click

        ViewWeeklyInspectionLog.Show()
        Me.Close()

    End Sub

    Private Sub InspectionsMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strGroup As String

        strGroup = Logon.mstrGroup

        If strGroup = "ADMIN" Or strGroup = "WAREHOUSE" Then
            btnDailyVehicleInspection.Enabled = True
            btnWeeklyVehicleInspection.Enabled = True
            btnDailyVehicleInventorySheets.Enabled = True
            btnDailyVehicleSignOutLog.Enabled = True
        End If

    End Sub

    Private Sub btnDailyVehicleInventorySheets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyVehicleInventorySheets.Click

        Logon.mstrFormForDataEntry = "VEHICLEINVENTORY"
        DataEntryDate.Show()
        Me.Close()

    End Sub

    Private Sub btnDailyVehicleSignOutLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyVehicleSignOutLog.Click

        Logon.mstrFormForDataEntry = "VEHICLESIGNOUT"
        DataEntryDate.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        InspectionSearchMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleAuditForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleAuditForm.Click

        Logon.mstrTypeOfDateSearch = "VEHICLESHEETAUDIT"
        DateSearchParameters.Show()
        Me.Close()

    End Sub

    Private Sub btnDailyVehiclesInYard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyVehiclesInYard.Click

        Logon.mstrFormForDataEntry = "VEHICLESINYARD"
        DataEntryDate.Show()
        Me.Close()

    End Sub

    
    Private Sub btnVehicleInspectionReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleInspectionReports.Click
        VehicleInspectionReports.Show()
        Me.Close()
    End Sub
End Class