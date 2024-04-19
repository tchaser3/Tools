'Title:         Warehouse Inventory Data Tier
'Date:          9-15-15
'Author:        Terry Holmes

'Description:   This is the data tier for the warehouse inventory

Option Strict On

Public Class WarehouseInventoryDataTier

    Private aWarehouseInventoryDataSetTableAdapter As WarehouseInventoryDataSetTableAdapters.WarehouseInventoryTableAdapter
    Private aWarehouseInventoryDataSet As New WarehouseInventoryDataSet

    Public Function GetWarehouseInventoryInformation() As WarehouseInventoryDataSet
        'Try Catch for execeptions
        Try

            'Loading up the data tier
            aWarehouseInventoryDataSet = New WarehouseInventoryDataSet
            aWarehouseInventoryDataSetTableAdapter = New WarehouseInventoryDataSetTableAdapters.WarehouseInventoryTableAdapter
            aWarehouseInventoryDataSetTableAdapter.Fill(aWarehouseInventoryDataSet.WarehouseInventory)
            Return aWarehouseInventoryDataSet

        Catch ex As Exception

            'This will run if the procedure throws and exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aWarehouseInventoryDataSet

        End Try

    End Function
    Public Sub UpdateWarehouseInventoryDB(ByVal aWarehouseInventoryDataSet As WarehouseInventoryDataSet)

        'Try Catch if procedure throws an exeption
        Try

            aWarehouseInventoryDataSetTableAdapter.Update(aWarehouseInventoryDataSet.WarehouseInventory)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

End Class
