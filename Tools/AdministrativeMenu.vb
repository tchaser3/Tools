'Title:         Administrative Menu
'Author:        Terry Holmes

'Description:   This form is only accessible if the user is part of the Admin or Warehouse Group

Option Strict On

Public Class AdministrativeMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnCreateATool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateATool.Click

        'Opens the Create Tools Form
        LastTransaction.Show()
        CreateTools.Show()
        Me.Close()

    End Sub

    Private Sub btnCreateAUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAUser.Click

        'Opens the Create an Employee form
        LastTransaction.Show()
        CreateEmployee.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'Opens up the Main Menu
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCreateATrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateATrailer.Click

        'Opens the Create a Trailer form
        LastTransaction.Show()
        CreateATrailer.Show()
        Me.Close()

    End Sub

    Private Sub btnCreateAVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAVehicle.Click

        'Opens the Create a Vehicle form
        LastTransaction.Show()
        CreateVehicle.Show()
        Me.Close()

    End Sub

    Private Sub AdministrativeMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded

        'The purpose of this routine is to activate the Create An Employee Button if
        'the User is part of the ADMIN Group
        Logon.mstrLastTransactionSummary = "LOADED ADMINISTRATION MENU"

        'Setting local variable
        Dim strGroup As String

        strGroup = Logon.mstrGroup

        'Checking to see if the user is part of the ADMIN group
        If strGroup = "ADMIN" Then
            btnCreateAUser.Enabled = True
            btnToolCategories.Enabled = True
            btnUtilitiesMenu.Enabled = True
            btnVoidCableTransaction.Enabled = True
            btnVoidInventoryTransaction.Enabled = True
        End If

    End Sub


    Private Sub btnCreateProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateProjects.Click

        LastTransaction.Show()
        InternalProjects.Show()
        Me.Close()

    End Sub

    Private Sub btnCableAdministration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCableAdministration.Click

        'This launches the Cable Administration Menu
        LastTransaction.Show()
        CableAdministrationMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCreatePartNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePartNumbers.Click

        Logon.mstrSourceMenu = "Administrative Menu"
        LastTransaction.Show()
        CreatePartNumbers.Show()
        Me.Close()

    End Sub

    Private Sub btnTerminateEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTerminateEmployee.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnToolCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolCategories.Click
        LastTransaction.Show()
        ToolCategory.Show()
        Me.Close()
    End Sub

    Private Sub btnCreateVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateVendor.Click

        'This will create a Vendor
        LastTransaction.Show()
        CreateAVendor.Show()
        Me.Close()

    End Sub

    Private Sub btnCreateAssetCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAssetCategory.Click

        'This will open the Create an Asset Category
        LastTransaction.Show()
        CreateAssetItem.Show()
        Me.Close()

    End Sub

    

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click

        About.Show()

    End Sub

    Private Sub btnUtilitiesMenu_Click(sender As Object, e As EventArgs) Handles btnUtilitiesMenu.Click

        LastTransaction.Show()
        UtilitiesMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnViewLastTransaction_Click(sender As Object, e As EventArgs) Handles btnViewLastTransaction.Click
        LastTransaction.Show()
        ViewLastTransactions.Show()
        Me.Close()
    End Sub

    Private Sub btnVoidCableTransaction_Click(sender As Object, e As EventArgs) Handles btnVoidCableTransaction.Click
        LastTransaction.Show()
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnVoidInventoryTransaction_Click(sender As Object, e As EventArgs) Handles btnVoidInventoryTransaction.Click
        LastTransaction.Show()
        Logon.mstrSelectionOrigination = "VOID INVENTORY TRANSACTION"
        SelectPartsWarehouse.Show()
        Me.Close()
    End Sub
End Class