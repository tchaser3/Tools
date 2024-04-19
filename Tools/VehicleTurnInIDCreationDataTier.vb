'Title:         Vehicle Turn In ID Creation
'Date:          9/26/13
'Author:        Terry Holmes

'Description:   This class generates the ID both Vehicle Sign Out Sheet Form and 
'               Vehicle Inventory Sheet form

Option Strict On

Public Class VehicleTurnInIDCreationDataTier

    'Setting up modular variables
    Private aVehicleTurnInIDCreationTableAdapter As VehicleTurnInIDCreationDataSetTableAdapters.vehicleturninidcreationTableAdapter

    Private aVehicleTurnInIDCreationDataSet As VehicleTurnInIDCreationDataSet

    Public Function GetVehicleTurnInIDCreationInformation() As VehicleTurnInIDCreationDataSet

        'Setting up the Datatier
        Try
            aVehicleTurnInIDCreationDataSet = New VehicleTurnInIDCreationDataSet
            aVehicleTurnInIDCreationTableAdapter = New VehicleTurnInIDCreationDataSetTableAdapters.vehicleturninidcreationTableAdapter
            aVehicleTurnInIDCreationTableAdapter.Fill(aVehicleTurnInIDCreationDataSet.vehicleturninidcreation)
            Return aVehicleTurnInIDCreationDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleTurnInIDCreationDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleTurnInIDCreationDataSet As VehicleTurnInIDCreationDataSet)

        'This will update the database
        Try
            aVehicleTurnInIDCreationTableAdapter.Update(aVehicleTurnInIDCreationDataSet.vehicleturninidcreation)
        Catch ex As Exception

        End Try
    End Sub


End Class
