'Title:         Cable Menu
'Date:          12/27/13
'Author:        Terry Holmes

'Description:   This is the Cable Menu

Option Strict On

Public Class CableMenu

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

    Private Sub btnInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryMenu.Click

        'This will open the Inventory Menu
        InventoryMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnIssueCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueCable.Click

        'This will open the Issue Cable Form
        Logon.mstrSourceMenu = "CABLE"
        SearchForProject.Show()
        Me.Close()

    End Sub

    Private Sub btnCableUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableUsage.Click
        'This will execute when the Button is pressed
        Logon.mstrSourceMenu = "CABLE USAGE"
        SearchForProject.Show()
        Me.Close()
    End Sub

    
    Private Sub btnTransferCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferCable.Click

        'This will execute when the Button is pressed
        TransferCable.Show()
        Me.Close()

    End Sub

    Private Sub btnReceiveCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveCable.Click

        'Setting up global variable
        Logon.mstrCableSelectionType = "RECEIVECABLE"
        SelectWarehouse.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAvailability.Click

        'This will launch when the button is pressed
        Logon.mstrCableSelectionType = "AVAILABILITY"
        CableSelection.Show()
        Me.Hide()

    End Sub

    Private Sub btnReturnCableReels_Click(sender As System.Object, e As System.EventArgs) Handles btnReturnCableReels.Click

        'Showing the Return Cable Reel
        Logon.mstrCableSelectionType = "RETURNCABLEREEL"

        SelectWarehouse.Show()
        Me.Close()

    End Sub

    Private Sub btnIssueHandCoil_Click(sender As System.Object, e As System.EventArgs) Handles btnIssueHandCoil.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub btnRecieveHandCoil_Click(sender As System.Object, e As System.EventArgs) Handles btnRecieveHandCoil.Click

        HandCoilTransactionID.Show()

    End Sub

    Private Sub btnHandCoilAvailablity_Click(sender As System.Object, e As System.EventArgs) Handles btnHandCoilAvailablity.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub btnViewManagerCableQueue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewManagerCableQueue.Click

        ManagerCableQueue.Show()
        Me.Close()

    End Sub

    Private Sub btnReturnPeeledCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnPeeledCable.Click
        Logon.mstrCableSelectionType = "CABLEAVAILABILITY"
        SelectWarehouse.Show()
        Me.Close()
    End Sub

    Private Sub btnCableAvailabilityReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAvailabilityReport.Click
        Logon.mstrCableSelectionType = "CABLEREPORT"
        SelectWarehouse.Show()
        Me.Close()
    End Sub

   
    Private Sub btnScrapCableReels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrapCableReels.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub CableMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Logon.mstrGroup = "ADMIN" Or Logon.mstrGroup = "WAREHOUSE" Then

            'Enables buttons for Administrators or Warehouse
            btnIssueCable.Enabled = True
            btnReceiveCable.Enabled = True
            btnReturnCableReels.Enabled = True
            btnScrapCableReels.Enabled = True
            btnTransferCable.Enabled = True
            btnCableUsage.Enabled = True
            btnIssueHandCoil.Enabled = True
            btnRecieveHandCoil.Enabled = True

        End If

    End Sub
End Class