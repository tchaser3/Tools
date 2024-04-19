'Title:     Weekly Vehicle Inspection Data Tier
'Date:      7/25/13
'Author:    Terry Holmes

Option Strict On

Public Class WeeklyVehicleInpectionDataTier

    'Setting up modular Variables
    Private aWeeklyVehicleInpectionsTableAdapter As WeeklyVehicleInspectionsDataSetTableAdapters.WeeklyVehicleInspectionsTableAdapter

    Private aWeeklyVehicleInspectionsDataSet As WeeklyVehicleInspectionsDataSet

    Public Function GetWeeklyVehicleInpectionInformation() As WeeklyVehicleInspectionsDataSet

        'Setting up the Datatier
        Try
            aWeeklyVehicleInspectionsDataSet = New WeeklyVehicleInspectionsDataSet
            aWeeklyVehicleInpectionsTableAdapter = New WeeklyVehicleInspectionsDataSetTableAdapters.WeeklyVehicleInspectionsTableAdapter
            aWeeklyVehicleInpectionsTableAdapter.Fill(aWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections)
            Return aWeeklyVehicleInspectionsDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aWeeklyVehicleInspectionsDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aWeeklyVehicleInpectionsDataSet As WeeklyVehicleInspectionsDataSet)

        'This will update the database
        Try
            aWeeklyVehicleInpectionsTableAdapter.Update(aWeeklyVehicleInspectionsDataSet.WeeklyVehicleInspections)
        Catch ex As Exception

        End Try
    End Sub

End Class
