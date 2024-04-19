'Title:         Main Menu
'Date:          8/5/13
'Author:        Terry Holmes

'Description:   This menu has been recreated since the original was not working correctly

Option Strict On
Imports System.IO

Public Class MainMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment
    Dim mstrModuleAccessed As String = ""

    Private Sub btnToolMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolMenu.Click

        ToolsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click

        About.Show()

    End Sub

    Private Sub MainMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strGroup As String

        strGroup = Logon.mstrGroup

        If strGroup = "ADMIN" Or strGroup = "WAREHOUSE" Then

            btnAdministrativeMenu.Enabled = True
            btnReports.Enabled = True
            btnMaintenanceMenu.Enabled = True
            btnInspectionMenu.Enabled = True
            If strGroup = "ADMIN" Then
                btnAssetControl.Enabled = True
            End If

        ElseIf strGroup = "MANAGERS" Or strGroup = "OFFICE" Then

            btnReports.Enabled = True
            btnMaintenanceMenu.Enabled = True
            btnInspectionMenu.Enabled = True

        End If

        If strGroup = "ADMIN" Then
            btnInformationTechnology.Enabled = True
        End If

    End Sub
    Private Sub CreateAdminLogEntry()

        'This Launches the Administrative Menu
        Dim LogDateTime As Date = DateAndTime.Now
        Dim strLogDateTime As String
        Dim LogWriter As New StreamWriter("accesslog.crp", True)
        Dim strLastName As String
        Dim strFirstName As String
        Dim strAccessMessage As String

        'Setting up the Log File
        strLogDateTime = CStr(LogDateTime)
        strLastName = Logon.mstrLastName
        strFirstName = Logon.mstrFirstName
        strAccessMessage = strLogDateTime + " " + strFirstName + " " + strLastName + " Accessed the " + mstrModuleAccessed
        LogWriter.WriteLine(strAccessMessage)
        LogWriter.Close()

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        mstrModuleAccessed = "ADMINISTRATION MENU"
        CreateAdminLogEntry()
        AdministrativeMenu.Show()
        Me.Close()


    End Sub

    Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click

        TheModuleUnderDevelopment.UnderDevelopment()

    End Sub

    Private Sub txtVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleMenu.Click

        'Shwos the Trailer Menu
        TrailerMenu.Show()
        Me.Close()

    End Sub

    Private Sub txtInventoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInventoryMenu.Click
        InventoryMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMaintenanceMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaintenanceMenu.Click

        MaintenanceMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMenu.Click

        VehicleMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnInformationTechnology_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInformationTechnology.Click

        EnterInformationTechnologyPassword.Show()
        Me.Close()

    End Sub

    Private Sub btnAssetControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetControl.Click
        mstrModuleAccessed = "ASSET CONTROL"
        CreateAdminLogEntry()
        AssetControlMenu.Show()
        Me.Close()

    End Sub
End Class