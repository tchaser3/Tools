'Title:         Inventory Menu
'Date:          12/27/13
'Author:        Terry Holmes

'Description:   This form is the Menu for Inventory Control

Option Strict On

Public Class InventoryMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnFindPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPartNumber.Click

        'Shows the Find Part Number form
        Logon.mstrSourceMenu = "Inventory Menu"
        CreatePartNumbers.Show()
        Me.Close()

    End Sub

    Private Sub btnInventoryLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryLookup.Click

        'Shows the Inventory Form


    End Sub

    
    Private Sub btnNewOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewOrders.Click
        Logon.mstrSourceMenu = "ORDERS"
        SearchForProject.Show()
        Me.Close()
    End Sub

    Private Sub btnGeneratePickList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneratePickList.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnFillPickList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFillPickList.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnReceiveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveOrder.Click
        
    End Sub

    Private Sub btnEmployeeInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeInventory.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnTruckInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckInventory.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnReportPartsUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportPartsUsage.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub
End Class