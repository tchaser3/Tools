'Title:         Vehicle In Yard Data Tier
'Date:          10-27-14
'Author:        Terry Holmes

'Description:   This is used to as the data tier for Vehicles in The Yard

Public Class VehicleInYardDataTier

    'Setting up modular variables
    Private aVehicleInYardTableAdapter As VehicleInYardDataSetTableAdapters.vehicleinyardTableAdapter

    Private aVehicleInYardDataSet As VehicleInYardDataSet

    Public Function GetVehicleInYardInformation() As VehicleInYardDataSet

        'Setting up the Datatier
        Try
            aVehicleInYardDataSet = New VehicleInYardDataSet
            aVehicleInYardTableAdapter = New VehicleInYardDataSetTableAdapters.vehicleinyardTableAdapter
            aVehicleInYardTableAdapter.Fill(aVehicleInYardDataSet.vehicleinyard)
            Return aVehicleInYardDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleInYardDataSet
        End Try
    End Function

    Public Sub UpdateVehicleInYardDB(ByVal aVehicleInYardDataSet As VehicleInYardDataSet)

        'This will update the database
        Try
            aVehicleInYardTableAdapter.Update(aVehicleInYardDataSet.vehicleinyard)
        Catch ex As Exception

        End Try
    End Sub

End Class
