'Title:         Archive Data Tier
'Date:          8-24-15
'Author:        Terry Holmes

'Description:   This class is designed as the data tier for archiving information

Option Strict On

Public Class ArchiveDataTier

    Private aArchiveLastTransactionDataSetTableAdapter As ArchiveLastTransactionDataSetTableAdapters.archivelasttransactionTableAdapter
    Private aArchiveLastTransactionDataSet As ArchiveLastTransactionDataSet

    Private aArchiveIssuedDataSetTableAdapter As ArchiveIssuedDataSetTableAdapters.archivedissuedTableAdapter
    Private aArchiveIssuedDataSet As ArchiveIssuedDataSet

    Private aArchiveReceivedDataSetTableAdapter As ArchiveReceivedDataSetTableAdapters.archivedreceivedTableAdapter
    Private aArchiveReceivedDataSet As ArchiveReceivedDataSet

    'Setting global variables
    Private aArchiveUsedDataSetTableAdapter As ArchiveUsedDataSetTableAdapters.archivedusedTableAdapter
    Private aArchiveUsedDataSet As ArchiveUsedDataSet

    'Setting global variables
    Private aArchiveVehicleDailyInspectionDataSetTableAdapter As ArchiveVehicleDailyInspectionDataSetTableAdapters.archivevehicledailyinspectionTableAdapter
    Private aArchiveVehicleDailyInspectionDataSet As ArchiveVehicleDailyInspectionDataSet

    'Setting global variables
    Private aArchiveVehicleHistoryDataSetTableAdapter As ArchiveVehicleHistoryDataSetTableAdapters.archivevehiclehistoryTableAdapter
    Private aArchiveVehicleHistoryDataSet As ArchiveVehicleHistoryDataSet

    'Setting global variables
    Private aArchiveVehicleInventoryDataSetTableAdapter As ArchiveVehicleInventoryDataSetTableAdapters.archivevehicleinventorysheetTableAdapter
    Private aArchiveVehicleInventoryDataSet As ArchiveVehicleInventoryDataSet

    'Setting global variables
    Private aArchiveVehicleInYardDataSetTableAdapter As ArchiveVehicleInYardDataSetTableAdapters.archivevehicleinyardTableAdapter
    Private aArchiveVehicleInYardDataSet As ArchiveVehicleInYardDataSet

    'Setting global variables
    Private aArchiveVehicleSignedOutDataSetTableAdapter As ArchiveVehicleSignedOutDataSetTableAdapters.archivevehiclesignedoutTableAdapter
    Private aArchiveVehicleSignedOutDataSet As ArchiveVehicleSignedOutDataSet

    'Setting global variables
    Private aArchiveWeeklyInspectionsDataSetTableAdapter As ArchiveWeeklyInspectionsDataSetTableAdapters.archiveweeklyinspectionsTableAdapter
    Private aArchiveWeeklyInspectionsDataSet As ArchiveWeeklyInspectionsDataSet

    Private aArchiveToolHistoryDataSetTableAdapter As ArchiveToolHistoryDataSetTableAdapters.archivetoolhistoryTableAdapter
    Private aArchiveToolHistoryDataSet As ArchiveToolHistoryDataSet

    Public Function GetArchiveToolHistoryInformation() As ArchiveToolHistoryDataSet

        'Setting up the Datatier
        Try
            aArchiveToolHistoryDataSet = New ArchiveToolHistoryDataSet
            aArchiveToolHistoryDataSetTableAdapter = New ArchiveToolHistoryDataSetTableAdapters.archivetoolhistoryTableAdapter
            aArchiveToolHistoryDataSetTableAdapter.Fill(aArchiveToolHistoryDataSet.archivetoolhistory)
            Return aArchiveToolHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveToolHistoryDataSet
        End Try
    End Function

    Public Sub UpdateArchiveToolHistoryDB(ByVal aArchiveToolHistoryDataSetDataSet As ArchiveToolHistoryDataSet)

        'This will update the database
        Try
            aArchiveToolHistoryDataSetTableAdapter.Update(aArchiveToolHistoryDataSetDataSet.archivetoolhistory)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveWeeklyInspectionsInformation() As ArchiveWeeklyInspectionsDataSet

        'Setting up the Datatier
        Try
            aArchiveWeeklyInspectionsDataSet = New ArchiveWeeklyInspectionsDataSet
            aArchiveWeeklyInspectionsDataSetTableAdapter = New ArchiveWeeklyInspectionsDataSetTableAdapters.archiveweeklyinspectionsTableAdapter
            aArchiveWeeklyInspectionsDataSetTableAdapter.Fill(aArchiveWeeklyInspectionsDataSet.archiveweeklyinspections)
            Return aArchiveWeeklyInspectionsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveWeeklyInspectionsDataSet
        End Try
    End Function

    Public Sub UpdateArchiveWeeklyInspectionsDB(ByVal aArchiveWeeklyInspectionsDataSetDataSet As ArchiveWeeklyInspectionsDataSet)

        'This will update the database
        Try
            aArchiveWeeklyInspectionsDataSetTableAdapter.Update(aArchiveWeeklyInspectionsDataSetDataSet.archiveweeklyinspections)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveVehicleSignedOutInformation() As ArchiveVehicleSignedOutDataSet

        'Setting up the Datatier
        Try
            aArchiveVehicleSignedOutDataSet = New ArchiveVehicleSignedOutDataSet
            aArchiveVehicleSignedOutDataSetTableAdapter = New ArchiveVehicleSignedOutDataSetTableAdapters.archivevehiclesignedoutTableAdapter
            aArchiveVehicleSignedOutDataSetTableAdapter.Fill(aArchiveVehicleSignedOutDataSet.archivevehiclesignedout)
            Return aArchiveVehicleSignedOutDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveVehicleSignedOutDataSet
        End Try
    End Function

    Public Sub UpdateArchiveVehicleSignedOutDB(ByVal aArchiveVehicleSignedOutDataSetDataSet As ArchiveVehicleSignedOutDataSet)

        'This will update the database
        Try
            aArchiveVehicleSignedOutDataSetTableAdapter.Update(aArchiveVehicleSignedOutDataSetDataSet.archivevehiclesignedout)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveVehicleInYardInformation() As ArchiveVehicleInYardDataSet

        'Setting up the Datatier
        Try
            aArchiveVehicleInYardDataSet = New ArchiveVehicleInYardDataSet
            aArchiveVehicleInYardDataSetTableAdapter = New ArchiveVehicleInYardDataSetTableAdapters.archivevehicleinyardTableAdapter
            aArchiveVehicleInYardDataSetTableAdapter.Fill(aArchiveVehicleInYardDataSet.archivevehicleinyard)
            Return aArchiveVehicleInYardDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveVehicleInYardDataSet
        End Try
    End Function

    Public Sub UpdateArchiveVehicleInYardDB(ByVal aArchiveVehicleInYardDataSetDataSet As ArchiveVehicleInYardDataSet)

        'This will update the database
        Try
            aArchiveVehicleInYardDataSetTableAdapter.Update(aArchiveVehicleInYardDataSetDataSet.archivevehicleinyard)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveVehicleInventoryInformation() As ArchiveVehicleInventoryDataSet

        'Setting up the Datatier
        Try
            aArchiveVehicleInventoryDataSet = New ArchiveVehicleInventoryDataSet
            aArchiveVehicleInventoryDataSetTableAdapter = New ArchiveVehicleInventoryDataSetTableAdapters.archivevehicleinventorysheetTableAdapter
            aArchiveVehicleInventoryDataSetTableAdapter.Fill(aArchiveVehicleInventoryDataSet.archivevehicleinventorysheet)
            Return aArchiveVehicleInventoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveVehicleInventoryDataSet
        End Try
    End Function

    Public Sub UpdateArchiveVehicleInventoryDB(ByVal aArchiveVehicleInventoryDataSetDataSet As ArchiveVehicleInventoryDataSet)

        'This will update the database
        Try
            aArchiveVehicleInventoryDataSetTableAdapter.Update(aArchiveVehicleInventoryDataSetDataSet.archivevehicleinventorysheet)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveVehicleHistoryInformation() As ArchiveVehicleHistoryDataSet

        'Setting up the Datatier
        Try
            aArchiveVehicleHistoryDataSet = New ArchiveVehicleHistoryDataSet
            aArchiveVehicleHistoryDataSetTableAdapter = New ArchiveVehicleHistoryDataSetTableAdapters.archivevehiclehistoryTableAdapter
            aArchiveVehicleHistoryDataSetTableAdapter.Fill(aArchiveVehicleHistoryDataSet.archivevehiclehistory)
            Return aArchiveVehicleHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveVehicleHistoryDataSet
        End Try
    End Function

    Public Sub UpdateArchiveVehicleHistoryDB(ByVal aArchiveVehicleHistoryDataSetDataSet As ArchiveVehicleHistoryDataSet)

        'This will update the database
        Try
            aArchiveVehicleHistoryDataSetTableAdapter.Update(aArchiveVehicleHistoryDataSetDataSet.archivevehiclehistory)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveVehicleDailyInspectionDataSetInformation() As ArchiveVehicleDailyInspectionDataSet

        'Setting up the Datatier
        Try
            aArchiveVehicleDailyInspectionDataSet = New ArchiveVehicleDailyInspectionDataSet
            aArchiveVehicleDailyInspectionDataSetTableAdapter = New ArchiveVehicleDailyInspectionDataSetTableAdapters.archivevehicledailyinspectionTableAdapter
            aArchiveVehicleDailyInspectionDataSetTableAdapter.Fill(aArchiveVehicleDailyInspectionDataSet.archivevehicledailyinspection)
            Return aArchiveVehicleDailyInspectionDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveVehicleDailyInspectionDataSet
        End Try
    End Function

    Public Sub UpdateArchiveVehicleDailyInspectionDataSetDB(ByVal aArchiveVehicleDailyInspectionDataSetDataSet As ArchiveVehicleDailyInspectionDataSet)

        'This will update the database
        Try
            aArchiveVehicleDailyInspectionDataSetTableAdapter.Update(aArchiveVehicleDailyInspectionDataSetDataSet.archivevehicledailyinspection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function GetArchiveUsedInformation() As ArchiveUsedDataSet

        'Setting up the Datatier
        Try
            aArchiveUsedDataSet = New ArchiveUsedDataSet
            aArchiveUsedDataSetTableAdapter = New ArchiveUsedDataSetTableAdapters.archivedusedTableAdapter
            aArchiveUsedDataSetTableAdapter.Fill(aArchiveUsedDataSet.archivedused)
            Return aArchiveUsedDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveUsedDataSet
        End Try
    End Function

    Public Sub UpdateArchiveUsedDB(ByVal aArchiveUsedDataSet As ArchiveUsedDataSet)

        'This will update the database
        Try
            aArchiveUsedDataSetTableAdapter.Update(aArchiveUsedDataSet.archivedused)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveReceivedInformation() As ArchiveReceivedDataSet

        'Setting up the Datatier
        Try
            aArchiveReceivedDataSet = New ArchiveReceivedDataSet
            aArchiveReceivedDataSetTableAdapter = New ArchiveReceivedDataSetTableAdapters.archivedreceivedTableAdapter
            aArchiveReceivedDataSetTableAdapter.Fill(aArchiveReceivedDataSet.archivedreceived)
            Return aArchiveReceivedDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveReceivedDataSet
        End Try
    End Function

    Public Sub UpdateArchiveReceivedDB(ByVal aArchiveReceivedDataSet As ArchiveReceivedDataSet)

        'This will update the database
        Try
            aArchiveReceivedDataSetTableAdapter.Update(aArchiveReceivedDataSet.archivedreceived)
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetArchiveIssuedInformation() As ArchiveIssuedDataSet

        'Setting up the Datatier
        Try
            aArchiveIssuedDataSet = New ArchiveIssuedDataSet
            aArchiveIssuedDataSetTableAdapter = New ArchiveIssuedDataSetTableAdapters.archivedissuedTableAdapter
            aArchiveIssuedDataSetTableAdapter.Fill(aArchiveIssuedDataSet.archivedissued)
            Return aArchiveIssuedDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveIssuedDataSet
        End Try
    End Function

    Public Sub UpdateArchiveIssuedDB(ByVal aArchiveIssuedDataSet As ArchiveIssuedDataSet)

        'This will update the database
        Try
            aArchiveIssuedDataSetTableAdapter.Update(aArchiveIssuedDataSet.archivedissued)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetArchiveLastTransactionInformation() As ArchiveLastTransactionDataSet

        Try

            'Setting up Variables
            aArchiveLastTransactionDataSet = New ArchiveLastTransactionDataSet
            aArchiveLastTransactionDataSetTableAdapter = New ArchiveLastTransactionDataSetTableAdapters.archivelasttransactionTableAdapter
            aArchiveLastTransactionDataSetTableAdapter.Fill(aArchiveLastTransactionDataSet.archivelasttransaction)
            Return aArchiveLastTransactionDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aArchiveLastTransactionDataSet
        End Try

    End Function
    Public Sub UpdateArchiveLastTransactionDB(ByVal aArchiveLastTransactionDataSet As ArchiveLastTransactionDataSet)

        Try
            aArchiveLastTransactionDataSetTableAdapter.Update(aArchiveLastTransactionDataSet.archivelasttransaction)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class
