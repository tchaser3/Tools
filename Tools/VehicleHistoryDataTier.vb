'Title:     Vehicle History Data Tier
'Date:      3/31/13
'Author:    Terry Holmes

Option Strict On

Public Class VehicleHistoryDataTier
    'Setting up modular variables
    Private aVehicleHistoryTableAdapter As VehicleHistoryDataSetTableAdapters.vehiclehistoryTableAdapter

    Private aVehicleHistoryDataSet As VehicleHistoryDataSet

    Public Function GetVehicleHistoryInformation() As VehicleHistoryDataSet

        'Setting up the Datatier
        Try
            aVehicleHistoryDataSet = New VehicleHistoryDataSet
            aVehicleHistoryTableAdapter = New VehicleHistoryDataSetTableAdapters.vehiclehistoryTableAdapter
            aVehicleHistoryTableAdapter.Fill(aVehicleHistoryDataSet.vehiclehistory)
            Return aVehicleHistoryDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleHistoryDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleHistoryDataSet As VehicleHistoryDataSet)

        'This will update the database
        Try
            aVehicleHistoryTableAdapter.Update(aVehicleHistoryDataSet.vehiclehistory)
        Catch ex As Exception

        End Try
    End Sub
End Class
