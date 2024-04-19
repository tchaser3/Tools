'Title:         Cable Administation Menu
'Date:          12/29/13
'Author:        Terry Holmes

'Description:   This form is the menu for the Cable Administration

Option Strict On

Public Class CableAdministrationMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'This Button will call the Administrative Menu
        AdministrativeMenu.Show()
        Me.Close()

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

   

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Calls the Main Menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCableMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableMenu.Click

        'Shows the Cable Menu
        CableMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAddCable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCable.Click

        Logon.mstrCableSelectionType = "ADDCABLE"
        SelectWarehouse.Show()
        Me.Close()

    End Sub

    Private Sub btnAdjustReel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustReel.Click

        'This will activate when the button is pressed

        Logon.mstrCableSelectionType = "ADJUSTCABLEREEL"
        SelectWarehouse.Show()
        Me.Close()

    End Sub

    Private Sub btnViewManagerQueues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewManagerQueues.Click

        'Opens the Manager Queue
        ManagerCableQueue.Show()
        Me.Close()

    End Sub
    Private Sub btnViewTechnicianQueues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTechnicianQueues.Click
        ViewTechnicianQueues.Show()
        Me.Close()
    End Sub

    Private Sub btnEditCableReel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCableReel.Click

        'Will lead to the Editing Cable Reel
        Logon.mstrCableSelectionType = "EDITREEL"
        SelectWarehouse.Show()
        Me.Close()

    End Sub

    Private Sub btnVoidCableIssueTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoidCableIssueTransactions.Click

        VoidCableIssueTransaction.Show()
        Me.Close()

    End Sub

    Private Sub CableAdministrationMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine will load when the form loads

        If Logon.mstrGroup = "ADMIN" Then
            btnVoidCableIssueTransactions.Enabled = True
        End If
        If Logon.mintWarehouseEmployeeID = 20007 Then
            btnPlacePartID.Visible = True
        End If

    End Sub

    Private Sub btnPlacePartID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlacePartID.Click
        PlacePartID.Show()
        Me.Close()
    End Sub
End Class