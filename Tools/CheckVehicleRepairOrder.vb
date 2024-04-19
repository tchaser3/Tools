'Title:         Check Vehicle Repair Order
'Date:          10-19-15
'Author:        Terry Holmes

'Description:   This will check to see if there are any open vehicle repair orders

Public Class CheckVehicleRepairOrder


    'Setting up global variables
    Private TheVehicleRepairsDataSet As VehicleRepairsDataSet
    Private TheVehicleRepairsDataTier As VehicleRepairsDataTier
    Private WithEvents TheVehicleRepairsBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Structure Vehicles
        Dim mintVehicleID As Integer
        Dim mintBJCNumber As Integer
        Dim mstrActive As String
    End Structure

    Dim structVehicles() As Vehicles
    Dim mintVehicleCounter As Integer
    Dim mintVehicleUpperLimit As Integer
    
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        VehicleInventorySheets.FinishInformationSave()
        Me.Close()
    End Sub

    Private Sub CheckVehicleRepairOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this will check to see if the vehicle has an open work order
        'setting up local variables

        Dim intVehicleCounter As Integer
        Dim intVehicleNumberOfRecords As Integer
        Dim intWorkOrderCounter As Integer
        Dim intWorkOrderNumberOfRecords As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer
        Dim strVehicleActive As String
        Dim strWorkOrderStatus As String
        Dim blnOpenWorkOrderExists As Boolean = False

        PleaseWait.Show()

        Try

            'setting up the vehicle data variables
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("Text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtVehicleActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehicleBJCNumber.DataBindings.Add("Text", TheVehiclesBindingSource, "BJCNumber")

            'setting up to full the structure
            intVehicleNumberOfRecords = cboVehicleID.Items.Count - 1
            ReDim structVehicles(intVehicleNumberOfRecords)
            mintVehicleCounter = 0

            'Beginning Loop
            For intVehicleCounter = 0 To intVehicleNumberOfRecords

                'incrementing the combo box
                cboVehicleID.SelectedIndex = intVehicleCounter

                'checking to see if the vehicle is active
                strVehicleActive = txtVehicleActive.Text.ToString.ToUpper
                If strVehicleActive = "YES" Then

                    structVehicles(mintVehicleCounter).mintVehicleID = CInt(cboVehicleID.Text)
                    structVehicles(mintVehicleCounter).mintBJCNumber = CInt(txtVehicleBJCNumber.Text)
                    structVehicles(mintVehicleCounter).mstrActive = txtVehicleActive.Text
                    mintVehicleCounter += 1

                End If
            Next

            mintVehicleUpperLimit = mintVehicleCounter - 1
            mintVehicleCounter = 0

            'setting up the repair controls
            TheVehicleRepairsDataTier = New VehicleRepairsDataTier
            TheVehicleRepairsDataSet = TheVehicleRepairsDataTier.GetVehicleRepairsInformation
            TheVehicleRepairsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVehicleRepairsBindingSource
                .DataSource = TheVehicleRepairsDataSet
                .DataMember = "vehiclerepairs"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleRepairsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleRepairsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtWorkOrderStatus.DataBindings.Add("Text", TheVehicleRepairsBindingSource, "Status")
            txtWorkOrderVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")

            'Getting ready for loop
            intWorkOrderNumberOfRecords = cboTransactionID.Items.Count - 1
            intBJCNumberForSearch = Logon.mintBJCNumber

            'Searching Vehicles
            For intVehicleCounter = 0 To mintVehicleUpperLimit

                'getting the BJC Number for Table
                intBJCNumberFromTable = structVehicles(intVehicleCounter).mintBJCNumber

                'if statements
                If intBJCNumberForSearch = intBJCNumberFromTable Then
                    intVehicleIDForSearch = structVehicles(intVehicleCounter).mintVehicleID
                End If

            Next

            'Beginning Work Order Loop
            For intWorkOrderCounter = 0 To intWorkOrderNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intWorkOrderCounter

                'setting the variables
                strWorkOrderStatus = txtWorkOrderStatus.Text
                intVehicleIDFromTable = CInt(txtWorkOrderVehicleID.Text)

                If strWorkOrderStatus = "OPEN" Then
                    If intVehicleIDForSearch = intVehicleIDFromTable Then
                        blnOpenWorkOrderExists = True
                    End If
                End If
            Next

            'If statements if work order exists
            If blnOpenWorkOrderExists = True Then
                VehicleInventorySheets.FinishInformationSave()
                PleaseWait.Close()
                Me.Close()
            ElseIf blnOpenWorkOrderExists = False Then
                Logon.mintVehicleID = intVehicleIDForSearch
            End If

            PleaseWait.Close()

        Catch ex As Exception
            PleaseWait.Close()
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click

        'This will launch the vehicle work order form
        CreateVehicleInspectionWorkOrder.Show()
        Me.Close()

    End Sub
End Class