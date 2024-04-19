'Title:         Vehicle Repair ID
'Date:          11-7-14
'Author:        Terry Holmes

'Description:   This routine will create a work order number

Option Strict On

Public Class VehicleRepairID

    'Setting up the global data variables
    Private TheVehicleRepairIDCheckDataSet As VehicleRepairIDCheckDataSet
    Private TheVehicleRepairIDCheckDataTier As VehicleRepairIDCheckDataTier
    Private WithEvents TheVehicleRepairIDCheckBindSource As BindingSource

    Private Sub VehicleRepairID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Setting Local Variables
        Dim intNewTransactionID As Integer

        'Try Catch
        Try

            'Setting up the global data variables
            TheVehicleRepairIDCheckDataTier = New VehicleRepairIDCheckDataTier
            TheVehicleRepairIDCheckDataSet = TheVehicleRepairIDCheckDataTier.GetVehicleRepairIDInformation
            TheVehicleRepairIDCheckBindSource = New BindingSource

            'Setting up the bindingsource
            With TheVehicleRepairIDCheckBindSource
                .DataSource = TheVehicleRepairIDCheckDataSet
                .DataMember = "vehiclerepairidcheck"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboVehicleRepairID
                .DataSource = TheVehicleRepairIDCheckBindSource
                .DisplayMember = "VehicleRepairID"
                .DataBindings.Add("text", TheVehicleRepairIDCheckBindSource, "VehicleRepairID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the remaining controls
            txtTransactionID.DataBindings.Add("text", TheVehicleRepairIDCheckBindSource, "TransactionID")

            'Creating the new ID
            intNewTransactionID = CInt(txtTransactionID.Text)
            intNewTransactionID += 1
            txtTransactionID.Text = CStr(intNewTransactionID)
            Logon.mintCreatedTransactionID = intNewTransactionID

            'updating the table
            TheVehicleRepairIDCheckBindSource.EndEdit()
            TheVehicleRepairIDCheckDataTier.UpdateDB(TheVehicleRepairIDCheckDataSet)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class