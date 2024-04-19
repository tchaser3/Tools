'Title:         Update Vehicle Repair Status
'Date:          10-22-15
'Author:        Terry Holmes

'Description:   This will update the vehicle repair status

Option Strict On

Public Class UpdateVehicleRepairStatus

    'setting up the global variables
    Private TheVehicleDataTier As VehiclesDataTier
    Private TheVehicleDataSet As VehiclesDataSet
    Private WithEvents TheVehiclcBindingSource As BindingSource

    Private Sub UpdateVehicleRepairStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this will load up the form
        'setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer

        'try catch for exceptions
        Try

            'setting global variables
            TheVehicleDataTier = New VehiclesDataTier
            TheVehicleDataSet = TheVehicleDataTier.GetVehiclesInformation
            TheVehiclcBindingSource = New BindingSource

            'setting up the binding source
            With TheVehiclcBindingSource
                .DataSource = TheVehicleDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboVehicleID
                .DataSource = TheVehiclcBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclcBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            txtDownForRepairs.DataBindings.Add("text", TheVehiclcBindingSource, "DownForRepairs")
            txtNotes.DataBindings.Add("Text", TheVehiclcBindingSource, "Notes")

            'getting ready for the loop
            intNumberOfRecords = cboVehicleID.Items.Count - 1
            intVehicleIDForSearch = CInt(Logon.mintVehicleID)

            'Preforming loop
            For intCounter = 0 To intNumberOfRecords

                'Incrementing the combo box
                cboVehicleID.SelectedIndex = intCounter

                'getting the vehicle id
                intVehicleIDFromTable = CInt(cboVehicleID.Text)

                'if statements to determine if the vehicle id is correct
                If intVehicleIDForSearch = intVehicleIDFromTable Then
                    intSelectedIndex = intCounter
                End If
            Next

            'setting up to save the record
            cboVehicleID.SelectedIndex = intSelectedIndex
            txtDownForRepairs.Text = Logon.mstrDownForRepair
            txtNotes.Text = Logon.mstrNotes

            'saving the record
            TheVehiclcBindingSource.EndEdit()
            TheVehicleDataTier.UpdateDB(TheVehicleDataSet)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class