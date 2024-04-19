'Title:         Utilities Menu
'Date:          8-29-15
'Author:        Terry Holmes

'Description:   This menu is used for the utilities

Option Strict On

Public Class UtilitiesMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnAdminMenu_Click(sender As Object, e As EventArgs) Handles btnAdminMenu.Click

        LastTransaction.Show()
        AdministrativeMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click

        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub UtilitiesMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Logon.mstrLastTransactionSummary = "Loaded the Utilities Menu"

    End Sub

    Private Sub btnArchiveLastTransaction_Click(sender As Object, e As EventArgs) Handles btnArchiveLastTransaction.Click

        LastTransaction.Show()
        ArchiveLastTransactions.Show()
        Me.Close()

    End Sub

    Private Sub btnCheckInventoryTables_Click(sender As Object, e As EventArgs) Handles btnCheckInventoryTables.Click

        LastTransaction.Show()
        CheckInventoryTables.Show()
        Me.Close()

    End Sub

    Private Sub btnEditInventoryTables_Click(sender As Object, e As EventArgs) Handles btnEditInventoryTables.Click
        LastTransaction.Show()
        EditInventoryTables.Show()
        Me.Close()
    End Sub

    Private Sub btnCheckWeeklyInspections_Click(sender As Object, e As EventArgs) Handles btnCheckWeeklyInspections.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnCheckDuplicateTools_Click(sender As Object, e As EventArgs) Handles btnCheckDuplicateTools.Click
        LastTransaction.Show()
        CheckDuplicateTools.Show()
        Me.Close()
    End Sub

    Private Sub btnCheckDuplicatePartNumbers_Click(sender As Object, e As EventArgs) Handles btnCheckDuplicatePartNumbers.Click
        LastTransaction.Show()
        CheckDuplicatePartNumbers.Show()
        Me.Close()
    End Sub
    Private Sub btnEditWeeklyInspection_Click(sender As Object, e As EventArgs) Handles btnEditWeeklyInspection.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnCheckDailyInspections_Click(sender As Object, e As EventArgs) Handles btnCheckDailyInspections.Click
        LastTransaction.Show()
        CheckDailyInspectionTables.Show()
        Me.Close()
    End Sub

    Private Sub btnEditDailyInspection_Click(sender As Object, e As EventArgs) Handles btnEditDailyInspection.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnArchiveReceiveTable_Click(sender As Object, e As EventArgs) Handles btnArchiveReceiveTable.Click
        LastTransaction.Show()
        ArchiveReceivedMaterial.Show()
        Me.Close()
    End Sub

    Private Sub btnArchiveIssuedTransactions_Click(sender As Object, e As EventArgs) Handles btnArchiveIssuedTransactions.Click
        LastTransaction.Show()
        ArchiveIssuedMaterial.Show()
        Me.Close()
    End Sub

    Private Sub btnArchiveUsedTransactions_Click(sender As Object, e As EventArgs) Handles btnArchiveUsedTransactions.Click
        LastTransaction.Show()
        ArchiveUsedMaterial.Show()
        Me.Close()
    End Sub

    
    Private Sub btnArchiveInspectionTables_Click(sender As Object, e As EventArgs) Handles btnArchiveInspectionTables.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnArchiveTools_Click(sender As Object, e As EventArgs) Handles btnArchiveTools.Click
        LastTransaction.Show()
        ArchiveToolHistory.Show()
        Me.Close()
    End Sub

    Private Sub btnArchiveVehicles_Click(sender As Object, e As EventArgs) Handles btnArchiveVehicles.Click
        LastTransaction.Show()
        ArchiveVehicleHistory.Show()
        Me.Close()
    End Sub

    Private Sub btnArchiveTrailers_Click(sender As Object, e As EventArgs) Handles btnArchiveTrailers.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnArchiveMaintenance_Click(sender As Object, e As EventArgs) Handles btnArchiveMaintenance.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub
End Class