'Title:         Vehicle Sheet Turn In ID Creation
'Date:          9/26/13
'Author:        Terry Holmes

'Description:   This form is used to create the ID for the Vehicle Inventory Sheet Entry and
'               the Vehicle Signed In form

Option Strict On


Public Class VehicleSheetTurnInIDCreation

    'Creating Modular Variables
    Private TheVehicleTurnInIDCreationDataSet As VehicleTurnInIDCreationDataSet
    Private TheVehicleTurnInIDCreationDataTier As VehicleTurnInIDCreationDataTier
    Private WithEvents TheVehicleTurnInIDCreationBindingSource As BindingSource

    Private Sub VehicleSheetTurnInIDCreation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'setting up the local variables
        Dim intNewTransactionID As Integer

        Try

            'setting up the data variables
            TheVehicleTurnInIDCreationDataTier = New VehicleTurnInIDCreationDataTier
            TheVehicleTurnInIDCreationDataSet = TheVehicleTurnInIDCreationDataTier.GetVehicleTurnInIDCreationInformation
            TheVehicleTurnInIDCreationBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleTurnInIDCreationBindingSource
                .DataSource = TheVehicleTurnInIDCreationDataSet
                .DataMember = "vehicleturninidcreation"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the binding source
            With cboTableTransactionID
                .DataSource = TheVehicleTurnInIDCreationBindingSource
                .DisplayMember = "TableTransactionID"
                .DataBindings.Add("text", TheVehicleTurnInIDCreationBindingSource, "TableTransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtTransactionID.DataBindings.Add("Text", TheVehicleTurnInIDCreationBindingSource, "TransactionID")

            'creating new id
            intNewTransactionID = CInt(txtTransactionID.Text)
            intNewTransactionID += 1
            txtTransactionID.Text = CStr(intNewTransactionID)
            Logon.mintCreatedTransactionID = intNewTransactionID

            'updating the dataset
            TheVehicleTurnInIDCreationBindingSource.EndEdit()
            TheVehicleTurnInIDCreationDataTier.UpdateDB(TheVehicleTurnInIDCreationDataSet)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Complete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class