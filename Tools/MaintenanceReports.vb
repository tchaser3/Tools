'Title:         Maintenance Reports Menu
'Date:          11-2-15
'Author:        Terry Holmes

'Description:   This form is the menu for the maintenance reports

Option Strict On

Public Class MaintenanceReports

    'setting up global variables
    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseTheProgram.ShowDialog()
    End Sub

    Private Sub MaintenanceReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Logon.mstrLastTransactionSummary = "Loaded the Maintenance Report Menu"
    End Sub

    Private Sub btnVehicleWorkOrderHistoryReport_Click(sender As Object, e As EventArgs) Handles btnVehicleWorkOrderHistoryReport.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnInvoicedWorkOrderReports_Click(sender As Object, e As EventArgs) Handles btnInvoicedWorkOrderReports.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnMaintenanceMenu_Click(sender As Object, e As EventArgs) Handles btnMaintenanceMenu.Click
        LastTransaction.Show()
        MaintenanceMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnOpenWorkOrderReport_Click(sender As Object, e As EventArgs) Handles btnOpenWorkOrderReport.Click
        LastTransaction.Show()
        OpenVehicleWorkOrderReport.Show()
        Me.Close()
    End Sub
End Class