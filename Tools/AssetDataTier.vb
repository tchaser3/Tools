'Title:         Asset Data Tier
'Date:          7/15/14
'Author:        Terry Holmes

'Description:   This is used as the Data Tier for the entire module

Option Strict On

Public Class AssetDataTier

    Private aAssetDataSetTableAdapter As AssetDataSetTableAdapters.assetTableAdapter
    Private aAssetDataSet As AssetDataSet

    Private aAssetHistoryDataSetTableAdapter As AssetHistoryDataSetTableAdapters.assethistoryTableAdapter
    Private aAssetHistoryDataSet As AssetHistoryDataSet

    Private aAssetModuleIDDataSetTableAdapter As AssetModuleIDDataSetTableAdapters.assetmoduleidTableAdapter
    Private aAssetModuleIDDataSet As AssetModuleIDDataSet

    Private aAssetItemDataSetTableAdapter As AssetItemDataSetTableAdapters.assetitemTableAdapter
    Private aAssetItemDataSet As AssetItemDataSet

    Private aVerifyAssetExistsDataSetTableAdapter As VerifyAssetExistsDataSetTableAdapters.verifyassetexitsTableAdapter
    Private aVerifyAssetExistsDataSet As VerifyAssetExistsDataSet

    Public Function GetVerifyAssetExistsInformation() As VerifyAssetExistsDataSet

        Try

            'Setting up Variables
            aVerifyAssetExistsDataSet = New VerifyAssetExistsDataSet
            aVerifyAssetExistsDataSetTableAdapter = New VerifyAssetExistsDataSetTableAdapters.verifyassetexitsTableAdapter
            aVerifyAssetExistsDataSetTableAdapter.Fill(aVerifyAssetExistsDataSet.verifyassetexits)
            Return aVerifyAssetExistsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVerifyAssetExistsDataSet
        End Try

    End Function
    Public Sub UpdateVerifyAssetExistsDB(ByVal aVerifyAssetExistsDataSet As VerifyAssetExistsDataSet)

        Try
            aVerifyAssetExistsDataSetTableAdapter.Update(aVerifyAssetExistsDataSet.verifyassetexits)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetAssetItemInformation() As AssetItemDataSet

        Try

            'Setting up Variables
            aAssetItemDataSet = New AssetItemDataSet
            aAssetItemDataSetTableAdapter = New AssetItemDataSetTableAdapters.assetitemTableAdapter
            aAssetItemDataSetTableAdapter.Fill(aAssetItemDataSet.assetitem)
            Return aAssetItemDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aAssetItemDataSet
        End Try

    End Function
    Public Sub UpdateAssetItem(ByVal aAssetItemDataSet As AssetItemDataSet)

        Try
            aAssetItemDataSetTableAdapter.Update(aAssetItemDataSet.assetitem)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetAssetModuleIDInformation() As AssetModuleIDDataSet

        Try

            'Setting up Variables
            aAssetModuleIDDataSet = New AssetModuleIDDataSet
            aAssetModuleIDDataSetTableAdapter = New AssetModuleIDDataSetTableAdapters.assetmoduleidTableAdapter
            aAssetModuleIDDataSetTableAdapter.Fill(aAssetModuleIDDataSet.assetmoduleid)
            Return aAssetModuleIDDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aAssetModuleIDDataSet
        End Try

    End Function
    Public Sub UpdateAssetModuleID(ByVal aAssetModuleIDDataSet As AssetModuleIDDataSet)

        Try
            aAssetModuleIDDataSetTableAdapter.Update(aAssetModuleIDDataSet.assetmoduleid)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetAssetHisotryInformation() As AssetHistoryDataSet

        'Setting up this Function of the Data Tier
        Try

            aAssetHistoryDataSet = New AssetHistoryDataSet
            aAssetHistoryDataSetTableAdapter = New AssetHistoryDataSetTableAdapters.assethistoryTableAdapter
            aAssetHistoryDataSetTableAdapter.Fill(aAssetHistoryDataSet.assethistory)
            Return aAssetHistoryDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aAssetHistoryDataSet

        End Try
    End Function

    Public Sub UpdateAssetHistoryDB(ByVal aAssetHistoryDataSet As AssetHistoryDataSet)

        Try

            aAssetHistoryDataSetTableAdapter.Update(aAssetHistoryDataSet.assethistory)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetAssetInformation() As AssetDataSet

        'Setting up this Function of the Data Tier
        Try

            aAssetDataSet = New AssetDataSet
            aAssetDataSetTableAdapter = New AssetDataSetTableAdapters.assetTableAdapter
            aAssetDataSetTableAdapter.Fill(aAssetDataSet.asset)
            Return aAssetDataSet

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aAssetDataSet

        End Try
    End Function

    Public Sub UpdateAssetDB(ByVal aAssetDataSet As AssetDataSet)

        Try

            aAssetDataSetTableAdapter.Update(aAssetDataSet.asset)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Fix", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
