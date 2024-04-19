'Title:     Vehicle ID Check Data Tier
'Date:      4/15/13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleIDCheckDataTier
    'Setting up modular variables
    Private aVehicleIDCheckTableAdapter As VehicleIDCheckDataSetTableAdapters.vehiclesidcheckTableAdapter

    Private aVehicleIDCheckDataSet As VehicleIDCheckDataSet

    Public Function GetVehicleIDInformation() As VehicleIDCheckDataSet

        'Setting up the Datatier
        Try
            aVehicleIDCheckDataSet = New VehicleIDCheckDataSet
            aVehicleIDCheckTableAdapter = New VehicleIDCheckDataSetTableAdapters.vehiclesidcheckTableAdapter
            aVehicleIDCheckTableAdapter.Fill(aVehicleIDCheckDataSet.vehiclesidcheck)
            Return aVehicleIDCheckDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleIDCheckDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleIDCheckDataSet As VehicleIDCheckDataSet)

        'This will update the database
        Try
            aVehicleIDCheckTableAdapter.Update(aVehicleIDCheckDataSet.vehiclesidcheck)
        Catch ex As Exception

        End Try
    End Sub
End Class
