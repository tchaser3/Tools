'Title:     Vehicle Repair ID Check Data Tier
'Date:      4/15/13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleRepairIDCheckDataTier
    'Setting up modular variables
    Private aVehicleRepairIDCheckTableAdapter As VehicleRepairIDCheckDataSetTableAdapters.vehiclerepairidcheckTableAdapter

    Private aVehicleRepairIDCheckDataSet As VehicleRepairIDCheckDataSet

    Public Function GetVehicleRepairIDInformation() As VehicleRepairIDCheckDataSet

        'Setting up the Datatier
        Try
            aVehicleRepairIDCheckDataSet = New VehicleRepairIDCheckDataSet
            aVehicleRepairIDCheckTableAdapter = New VehicleRepairIDCheckDataSetTableAdapters.vehiclerepairidcheckTableAdapter
            aVehicleRepairIDCheckTableAdapter.Fill(aVehicleRepairIDCheckDataSet.vehiclerepairidcheck)
            Return aVehicleRepairIDCheckDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleRepairIDCheckDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleRepairIDCheckDataSet As VehicleRepairIDCheckDataSet)

        'This will update the database
        Try
            aVehicleRepairIDCheckTableAdapter.Update(aVehicleRepairIDCheckDataSet.vehiclerepairidcheck)
        Catch ex As Exception

        End Try
    End Sub
End Class
