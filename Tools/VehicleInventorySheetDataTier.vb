'Title:         Vehicle Inventory Sheet Data Tier
'Date:          9/26/13
'Author:        Terry Holmes

'Description:   This file is the Data Tier for the Vehicle Inventory Sheet
'               Input Form

Option Strict On

Public Class VehicleInventorySheetDataTier

    'Setting up modular variables
    Private aVehicleInventorySheetTableAdapter As VehicleInventorySheetDataSetTableAdapters.vehicleinventorysheetTableAdapter

    Private aVehicleInventorySheetDataSet As VehicleInventorySheetDataSet

    Public Function GetVehicleInventorySheetInformation() As VehicleInventorySheetDataSet

        'Setting up the Datatier
        Try
            aVehicleInventorySheetDataSet = New VehicleInventorySheetDataSet
            aVehicleInventorySheetTableAdapter = New VehicleInventorySheetDataSetTableAdapters.vehicleinventorysheetTableAdapter
            aVehicleInventorySheetTableAdapter.Fill(aVehicleInventorySheetDataSet.vehicleinventorysheet)
            Return aVehicleInventorySheetDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleInventorySheetDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleInventorySheetDataSet As VehicleInventorySheetDataSet)

        'This will update the database
        Try
            aVehicleInventorySheetTableAdapter.Update(aVehicleInventorySheetDataSet.vehicleinventorysheet)
        Catch ex As Exception

        End Try
    End Sub

End Class
