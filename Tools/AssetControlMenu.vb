'Title:         Asset Control Menu
'Date:          7/14/14
'Author:        Terry Holmes

'Description:   This module is designed to access all Asset Information

Option Strict On

Public Class AssetControlMenu

    Dim TheModuleUnderDevelopment As New ModuleUnderDevelopment

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This routine will show the main menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnCreateNewAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewAsset.Click
        CreateAsset.Show()
        Me.Close()
    End Sub

    Private Sub btnEditAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAsset.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnIssueAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssueAsset.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnReturnAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnAsset.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnRetireAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetireAsset.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnAssetReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetReports.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnAssetHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetHistory.Click
        TheModuleUnderDevelopment.UnderDevelopment()
    End Sub

    Private Sub btnCreateAssetCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAssetCategory.Click
        CreateAssetItem.Show()
        Me.Close()
    End Sub
End Class