'Title:     Vehicles Data Tier
'Date:      3/31/13
'Author:    Terry Holmes

Option Strict On

Public Class VehiclesDataTier
    'Setting up modular variables
    Private aVehiclesTableAdapter As VehiclesDataSetTableAdapters.vehiclesTableAdapter

    Private aVehiclesDataSet As VehiclesDataSet

    Public Function GetVehiclesInformation() As VehiclesDataSet
        Dim intReturn = 0
        'Setting up the Datatier
        Try
            aVehiclesDataSet = New VehiclesDataSet
            aVehiclesTableAdapter = New VehiclesDataSetTableAdapters.vehiclesTableAdapter
            aVehiclesTableAdapter.Fill(aVehiclesDataSet.vehicles)
            Return aVehiclesDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehiclesDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehiclesDataSet As VehiclesDataSet)

        'This will update the database
        Try
            aVehiclesTableAdapter.Update(aVehiclesDataSet.vehicles)
        Catch ex As Exception

        End Try
    End Sub
End Class
