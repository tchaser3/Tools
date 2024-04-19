'Title:         Vehicle Signed Out Data Tier
'Date:          9/26/13
'Author:        Terry Holmes

'Description:   This is the Data Tier Class for the the Vehicle Sign Out Sheet Audit

Option Strict On

Public Class VehicleSignedOutDataTier

    'Setting up modular variables
    Private aVehicleSignedOutTableAdapter As VehicleSignedOutDataSetTableAdapters.vehiclesignedoutTableAdapter

    Private aVehicleSignedOutDataSet As VehicleSignedOutDataSet

    Public Function GetVehicleSignedOutInformation() As VehicleSignedOutDataSet

        'Setting up the Datatier
        Try
            aVehicleSignedOutDataSet = New VehicleSignedOutDataSet
            aVehicleSignedOutTableAdapter = New VehicleSignedOutDataSetTableAdapters.vehiclesignedoutTableAdapter
            aVehicleSignedOutTableAdapter.Fill(aVehicleSignedOutDataSet.vehiclesignedout)
            Return aVehicleSignedOutDataSet

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return aVehicleSignedOutDataSet
        End Try
    End Function

    Public Sub UpdateDB(ByVal aVehicleSignedOutDataSet As VehicleSignedOutDataSet)

        'This will update the database
        Try
            aVehicleSignedOutTableAdapter.Update(aVehicleSignedOutDataSet.vehiclesignedout)
        Catch ex As Exception

        End Try
    End Sub


End Class
