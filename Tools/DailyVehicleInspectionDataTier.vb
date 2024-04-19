'Title:         Daily Vehicle Inspection Data Tier
'Date:          7/25/13
'Author:        Terry Holmes

'Description:   This class runs for Daily Vehicle Inspections

Public Class DailyVehicleInspectionDataTier

    'Setting up modular variables
    Private aDailyVehicleInpectionTableAdapter As DailyVehicleInspectionDataSetTableAdapters.VehicleDailyInspectionTableAdapter

    Private aDailyVehicleInspectionDataSet As DailyVehicleInspectionDataSet

    Public Function GetDailyVehicleInpectionInformation() As DailyVehicleInspectionDataSet

        'Setting up the Datatier
        Try
            aDailyVehicleInspectionDataSet = New DailyVehicleInspectionDataSet
            aDailyVehicleInpectionTableAdapter = New DailyVehicleInspectionDataSetTableAdapters.VehicleDailyInspectionTableAdapter
            aDailyVehicleInpectionTableAdapter.Fill(aDailyVehicleInspectionDataSet.VehicleDailyInspection)
            Return aDailyVehicleInspectionDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aDailyVehicleInspectionDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aDailyVehicleInpectionDataSet As DailyVehicleInspectionDataSet)

        'This will update the database
        Try
            aDailyVehicleInpectionTableAdapter.Update(aDailyVehicleInspectionDataSet.VehicleDailyInspection)
        Catch ex As Exception

        End Try
    End Sub

End Class
