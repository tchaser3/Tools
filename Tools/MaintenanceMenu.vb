'Title:         Vehicle Maintenance Menu
'Date:          9/23/13
'Author:        Terry Holmes

'Description:   This form is used for Vehicle Repairs

Option Strict On

Public Class MaintenanceMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program

        CloseTheProgram.ShowDialog()


    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click

        About.Show()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click

        MaintenanceReports.Show()
        Me.Close()

    End Sub

    Private Sub btnNewWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewWorkOrder.Click

        CreateVehicleMaintenanceWorkOrder.Show()
        Me.Close()

    End Sub

    Private Sub btnEditWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditWorkOrder.Click

        'This will load the Edit Vehicle Maintence Work Order
        EditVehicleWorkOrder.Show()
        Me.Close()

    End Sub

    Private Sub btnCompleteWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleteWorkOrder.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub btnInvoiceTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceTracking.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

  
    Private Sub btnPreventiveMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreventiveMaintenance.Click

        'This will launch the Vehicle Preventive Maintenance form
        Logon.mstrFormForDataEntry = "CURRENT"
        VehiclePreventiveMaintenanceUpdate.Show()
        Me.Close()

    End Sub

    Private Sub MaintenanceMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loading up the last transaction variable
        Logon.mstrLastTransactionSummary = "Loaded the Maintenance Menu"
    End Sub
End Class