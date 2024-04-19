'Title:     Inventory Data Tier
'Date:      7/11/13
'Author:    Terry Holmes

'Update:    9-15-15 Removed Inventory References from the Tools DB to the TWCInventory DB
'Update:    9-16-15 Added Void Inventory Transaction information

Option Strict On

Public Class InventoryDataTier

    Private aInventoryDataSetTableAdapter As InventoryDataSetTableAdapters.InventoryTableAdapter
    Private aInventoryDataSet As InventoryDataSet

    Private aCreateInventoryIDDataSetTableAdapter As CreateInventoryIDDataSetTableAdapters.CreateIDTableAdapter
    Private aCreateInventoryIDDataSet As CreateInventoryIDDataSet

    Private aVoidInventoryTransactionDataSetTableAdapter As VoidInventoryTransactionDataSetTableAdapters.voidinventorytransactionTableAdapter
    Private aVoidInventoryTransactionDataSet As VoidInventoryTransactionDataSet

    Public Function GetVoidInventoryTransactionInformation() As VoidInventoryTransactionDataSet

        'Try Catch for execeptions
        Try

            'Loading up the data tier
            aVoidInventoryTransactionDataSet = New VoidInventoryTransactionDataSet
            aVoidInventoryTransactionDataSetTableAdapter = New VoidInventoryTransactionDataSetTableAdapters.voidinventorytransactionTableAdapter
            aVoidInventoryTransactionDataSetTableAdapter.Fill(aVoidInventoryTransactionDataSet.voidinventorytransaction)
            Return aVoidInventoryTransactionDataSet

        Catch ex As Exception

            'This will run if the procedure throws and exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVoidInventoryTransactionDataSet

        End Try

    End Function
    Public Sub UpdateVoidInventoryTransactionDB(ByVal aVoidInventoryTransactionDataSet As VoidInventoryTransactionDataSet)

        'Try Catch if procedure throws an exeption
        Try

            aVoidInventoryTransactionDataSetTableAdapter.Update(aVoidInventoryTransactionDataSet.voidinventorytransaction)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Function GetCreateInventoryIDInformation() As CreateInventoryIDDataSet

        'Try Catch for execeptions
        Try

            'Loading up the data tier
            aCreateInventoryIDDataSet = New CreateInventoryIDDataSet
            aCreateInventoryIDDataSetTableAdapter = New CreateInventoryIDDataSetTableAdapters.CreateIDTableAdapter
            aCreateInventoryIDDataSetTableAdapter.Fill(aCreateInventoryIDDataSet.CreateID)
            Return aCreateInventoryIDDataSet

        Catch ex As Exception

            'This will run if the procedure throws and exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aCreateInventoryIDDataSet

        End Try

    End Function
    Public Sub UpdateCreateInventoryIDDB(ByVal aCreateInventoryIDDataSet As CreateInventoryIDDataSet)

        'Try Catch if procedure throws an exeption
        Try

            aCreateInventoryIDDataSetTableAdapter.Update(aCreateInventoryIDDataSet.CreateID)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Function GetInventoryInformation() As InventoryDataSet

        'Try Catch for execeptions
        Try

            'Loading up the data tier
            aInventoryDataSet = New InventoryDataSet
            aInventoryDataSetTableAdapter = New InventoryDataSetTableAdapters.InventoryTableAdapter
            aInventoryDataSetTableAdapter.Fill(aInventoryDataSet.Inventory)
            Return aInventoryDataSet

        Catch ex As Exception

            'This will run if the procedure throws and exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aInventoryDataSet

        End Try

    End Function
    Public Sub UpdateInventoryDB(ByVal aInventoryDataSet As InventoryDataSet)

        'Try Catch if procedure throws an exeption
        Try

            aInventoryDataSetTableAdapter.Update(aInventoryDataSet.Inventory)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

End Class
