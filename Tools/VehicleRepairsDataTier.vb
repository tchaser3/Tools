'Title:     Vehicle Repairs Data Tier
'Date:      3/31/13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleRepairsDataTier
    'Setting up modular variables
    Private aVehicleRepairsTableAdapter As VehicleRepairsDataSetTableAdapters.vehiclerepairsTableAdapter

    Private aVehicleRepairsDataSet As VehicleRepairsDataSet

    Public Function GetVehicleRepairsInformation() As VehicleRepairsDataSet

        'Setting up the Datatier
        Try
            aVehicleRepairsDataSet = New VehicleRepairsDataSet
            aVehicleRepairsTableAdapter = New VehicleRepairsDataSetTableAdapters.vehiclerepairsTableAdapter
            aVehicleRepairsTableAdapter.Fill(aVehicleRepairsDataSet.vehiclerepairs)
            Return aVehicleRepairsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleRepairsDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleRepairsDataSet As VehicleRepairsDataSet)

        'This will update the database
        Try
            aVehicleRepairsTableAdapter.Update(aVehicleRepairsDataSet.vehiclerepairs)
        Catch ex As Exception

        End Try
    End Sub
End Class
