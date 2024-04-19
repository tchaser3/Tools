'Title:         Edit Vehicle Work Order
'Date:          11-13-14
'Author:        Terry Holmes

'Description:   This form is used to edit a vehicle work order

Option Strict On

Public Class EditVehicleWorkOrder

    'Setting up global variables
    Private TheVehicleRepairsDataSet As VehicleRepairsDataSet
    Private TheVehicleRepairsDataTier As VehicleRepairsDataTier
    Private WithEvents TheVehicleRepairsBindingSource As BindingSource

    Private TheVendorsDataSet As VendorsDataSet
    Private TheVendorsDataTier As VendorDataTier
    Private WithEvents TheVendorsBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer
    Dim mintSelectedIndex(1000) As Integer

    Dim mintWorkOrderCounter As Integer
    Dim mintWorkOrderUpperLimit As Integer
    Dim mintWorkOrderSelectedIndex(2000) As Integer

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This will open up the main menu
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click

        'This will open up the maintenance menu
        MaintenanceMenu.Show()
        Me.Close()

    End Sub

    Private Sub EditVehicleWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up when the form is launced

        'Try catch to load up the controls
        Try

            'Setting up the vehicle controls
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

            'Setting up the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtVehicleActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")

            'Binding the Vendor Information
            TheVendorsDataTier = New VendorDataTier
            TheVendorsDataSet = TheVendorsDataTier.GetVendorsinformation
            TheVendorsBindingSource = New BindingSource

            'Setting up the binding source
            With TheVendorsBindingSource
                .DataSource = TheVendorsDataSet
                .DataMember = "vendors"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up the combo box
            With cboVendorName
                .DataSource = TheVendorsBindingSource
                .DisplayMember = "VendorName"
                .DataBindings.Add("text", TheVendorsBindingSource, "VendorName", False, DataSourceUpdateMode.Never)
            End With

            'binding the remaining vendor control
            txtVendorTableID.DataBindings.Add("text", TheVendorsBindingSource, "VendorID")

            'Setting up the work order controls and binding
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

            'Setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleRepairsBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleRepairsBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Binding the Rest of the Controls
            txtWorkOrderNumber.DataBindings.Add("text", TheVehicleRepairsBindingSource, "TransactionID")
            txtWorkOrderDateReported.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateReported")
            txtWorkOrderNotes.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Notes")
            txtWorkOrderOdometer.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Odometer")
            txtWorkOrderProblemDescription.DataBindings.Add("text", TheVehicleRepairsBindingSource, "ProblemDescription")
            txtWorkOrderStatus.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Status")
            txtWorkOrderVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")
            txtWorkOrderVendorID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VendorID")

            SetVehicleControlsVisible(False)
            SetWorkOrderControlsVisible(False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetWorkOrderControlsVisible(ByVal valueBoolean As Boolean)

        'This will set the work order controls visible
        txtWorkOrderDateRepairBegan.Visible = valueBoolean
        txtWorkOrderDateReported.Visible = valueBoolean
        txtWorkOrderNotes.Visible = valueBoolean
        txtWorkOrderOdometer.Visible = valueBoolean
        txtWorkOrderProblemDescription.Visible = valueBoolean
        txtWorkOrderStatus.Visible = valueBoolean
        txtWorkOrderVehicleID.Visible = valueBoolean
        txtWorkOrderVendorID.Visible = valueBoolean
        txtWorkOrderNumber.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnBack.Visible = valueBoolean

    End Sub

    Private Sub btnSearchWorkOrderNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchWorkOrderNumber.Click

        'This will find the work order number
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intWorkOrderNumberForSearch As Integer
        Dim intWorkOrderNumberFromTable As Integer
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean = True

        'Setting the navigation buttons
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Beginning Validation
        strValueForValidation = txtEnterWorkOrderNumber.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            txtEnterWorkOrderNumber.Text = ""
            MessageBox.Show("The Work Order Number is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetWorkOrderControlsVisible(True)

        'Setting up for the search
        intWorkOrderNumberForSearch = CInt(strValueForValidation)
        intNumberOfRecords = cboTransactionID.Items.Count - 1

        'Performing the loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboTransactionID.SelectedIndex = intCounter

            'Setting search variable
            intWorkOrderNumberFromTable = CInt(cboTransactionID.Text)

            'If statements to determine if the work order was found
            If intWorkOrderNumberForSearch = intWorkOrderNumberFromTable Then
                intSelectedIndex = intCounter
                blnItemNotFound = False
            End If

        Next

        'If Statement to determine if he work order has been found
        If blnItemNotFound = True Then
            txtEnterWorkOrderNumber.Text = ""
            SetWorkOrderControlsVisible(False)
            MessageBox.Show("Work Order Number Entered Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting the combo box
        cboTransactionID.SelectedIndex = intSelectedIndex
        txtEnterWorkOrderNumber.Text = ""

        SetVehicleControlsVisible(True)
        FindVehicle()
        FindVendor()

    End Sub
    Private Sub FindVehicle()

        'Setting up local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer

        'Setting up the loop
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        intVehicleIDForSearch = CInt(txtWorkOrderVehicleID.Text)

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the vehicle id
            cboVehicleID.SelectedIndex = intCounter

            'Setting the search variable
            intVehicleIDFromTable = CInt(cboVehicleID.Text)

            'If Statement to determine if the vehicle id was found
            If intVehicleIDForSearch = intVehicleIDFromTable Then
                intSelectedIndex = intCounter
            End If
        Next

        'Setting the combo box selected index
        cboVehicleID.SelectedIndex = intSelectedIndex

    End Sub
    Private Sub FindVendor()

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intVendorIDForSearch As Integer
        Dim intVendorIDFromTable As Integer

        'Setting up for the loop
        intNumberOfRecords = cboVendorName.Items.Count - 1
        intVendorIDForSearch = CInt(txtWorkOrderVendorID.Text)

        'Preforming the loop
        For intCounter = 0 To intNumberOfRecords

            'Setting up the combo box
            cboVendorName.SelectedIndex = intCounter

            'Setting up the selected index
            intVendorIDFromTable = CInt(txtVendorTableID.Text)

            If intVendorIDForSearch = intVendorIDFromTable Then

                'Setting the vendor id
                intSelectedIndex = intCounter

            End If

        Next

        'Setting the combo box for the vendor
        cboVendorName.SelectedIndex = intSelectedIndex


    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the counter
        mintWorkOrderCounter += 1
        cboTransactionID.SelectedIndex = mintWorkOrderSelectedIndex(mintWorkOrderCounter)

        btnBack.Enabled = True

        If mintWorkOrderCounter = mintWorkOrderUpperLimit Then
            btnNext.Enabled = False
        End If

        FindVehicle()
        FindVehicle()

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will increment the counter
        mintWorkOrderCounter -= 1
        cboTransactionID.SelectedIndex = mintWorkOrderSelectedIndex(mintWorkOrderCounter)

        btnNext.Enabled = True

        If mintWorkOrderCounter = 0 Then
            btnBack.Enabled = False
        End If

        FindVehicle()
        FindVehicle()

    End Sub

    Private Sub btnSearchBJCNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBJCNumber.Click

        'This Sub Routine will find all work orders that match the BJC Number entered
        Dim intVehicleCounter As Integer
        Dim intVehicleNumberOfRecords As Integer
        Dim intVehicleSelectedIndex As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDForSearch As Integer
        Dim intVehicleIDFromTable As Integer
        Dim strVehicleActive As String
        Dim strWorkOrderStatus As String
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean = True
        Dim blnWorkOrderNotFound As Boolean = True
        Dim strValueForValidation As String
        Dim intWorkOrderCounter As Integer
        Dim intWorkOrderNumberOfRecords As Integer

        'Disabling the navigation buttons
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Beginning Data Validation
        strValueForValidation = txtEnterBJCNumber.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        'Message to user if Validation Fails
        If blnFatalError = True Then
            txtEnterBJCNumber.Text = "'"
            MessageBox.Show("The BJC Number Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making controls visible
        SetVehicleControlsVisible(True)
        SetWorkOrderControlsVisible(True)

        'Beginning for loop
        intVehicleNumberOfRecords = cboVehicleID.Items.Count - 1
        intBJCNumberForSearch = CInt(strValueForValidation)

        'Beginning Loop
        For intVehicleCounter = 0 To intVehicleNumberOfRecords

            'Incrementing the combo box
            cboVehicleID.SelectedIndex = intVehicleCounter

            'Loading up BJC Number
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)

            'Loading up to determine if vehicle is active
            strVehicleActive = txtVehicleActive.Text

            'Beginning If Statements
            If intBJCNumberForSearch = intBJCNumberFromTable Then
                If strVehicleActive = "YES" Then
                    intVehicleSelectedIndex = intVehicleCounter
                    blnItemNotFound = False
                End If
            End If

        Next

        'Out to user if BJC vehicle was not found
        If blnItemNotFound = True Then
            txtEnterBJCNumber.Text = ""
            SetVehicleControlsVisible(False)
            SetWorkOrderControlsVisible(False)
            MessageBox.Show("The BJC Number Entered Was Not Found or Is Not Active", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting the combo box
        cboVehicleID.SelectedIndex = intVehicleSelectedIndex

        'Beginning for search of work orders
        intVehicleIDForSearch = CInt(cboVehicleID.Text)
        intWorkOrderNumberOfRecords = cboTransactionID.Items.Count - 1
        mintWorkOrderCounter = 0

        'Performing Loop
        For intWorkOrderCounter = 0 To intWorkOrderNumberOfRecords

            'incrementing the combo box
            cboTransactionID.SelectedIndex = intWorkOrderCounter

            'Getting the Vehicle ID From the table
            intVehicleIDFromTable = CInt(txtWorkOrderVehicleID.Text)

            'Getting the Work Order Status
            strWorkOrderStatus = txtWorkOrderStatus.Text

            'If Statements to see if the record found meets requirements
            If intVehicleIDForSearch = intVehicleIDFromTable Then

                        'Setting up for incrementing the Array
                        mintWorkOrderSelectedIndex(mintWorkOrderCounter) = intWorkOrderCounter
                        mintWorkOrderCounter += 1
                        blnWorkOrderNotFound = False
                   
            End If
        Next

        'If Statement if Work Orders are not found
        If blnWorkOrderNotFound = True Then
            txtEnterBJCNumber.Text = ""
            SetVehicleControlsVisible(False)
            SetWorkOrderControlsVisible(False)
            MessageBox.Show("There Are Currently No Open Work Orders For This Vehicle", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting up the navigation controls
        mintWorkOrderUpperLimit = mintWorkOrderCounter - 1
        mintWorkOrderCounter = 0
        cboTransactionID.SelectedIndex = mintWorkOrderSelectedIndex(0)

        If mintWorkOrderUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

    End Sub

    Private Sub SetVehicleControlsVisible(ByVal valueBoolean As Boolean)

        'This will set the vehicles controls visible
        txtVehicleActive.Visible = valueBoolean
        txtVehicleBJCNumber.Visible = valueBoolean

    End Sub

    Private Sub btnResetForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetForm.Click

        'This will reset the form to default
        txtEnterBJCNumber.Text = ""
        txtEnterWorkOrderNumber.Text = ""
        cboVehicleID.SelectedIndex = 0
        cboVendorName.SelectedIndex = 0
        cboTransactionID.SelectedIndex = 0
        SetWorkOrderControlsVisible(False)
        SetVehicleControlsVisible(False)

    End Sub

    Private Sub btnFindAllWorkOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAllWorkOrders.Click

        'This will find all open work orders
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strCurrentStatus As String
        Dim blnNoItemsFound As Boolean = True

        'Setting up for the loop
        intNumberOfRecords = cboTransactionID.Items.Count - 1
        mintWorkOrderCounter = 0

        'Making Work Order controls visible
        SetWorkOrderControlsVisible(True)

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting the combo box index
            cboTransactionID.SelectedIndex = intCounter

            'Setting the Status variable
            strCurrentStatus = txtWorkOrderStatus.Text

            'Series of if statements to verify the application works
            If strCurrentStatus = "AWAITING REPAIR" Or strCurrentStatus = "BEING REPAIRED" Then

                mintWorkOrderSelectedIndex(mintWorkOrderCounter) = intCounter
                mintWorkOrderCounter += 1
                blnNoItemsFound = False

            End If
        Next

        'Letting user know that there are no open work orders
        If blnNoItemsFound = True Then
            SetWorkOrderControlsVisible(False)
            MessageBox.Show("There Are No Open Vehicle Work Orders", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Setting the navigation buttons
        mintWorkOrderUpperLimit = mintWorkOrderCounter - 1
        mintWorkOrderCounter = 0
        cboTransactionID.SelectedIndex = mintWorkOrderSelectedIndex(0)

        SetVehicleControlsVisible(True)

        If mintWorkOrderUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

        FindVehicle()
        FindVendor()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If btnEdit.Text = "Edit" Then

        End If

    End Sub
    Private Sub SetWorkOrderControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will allow the user to edit the work order
        txtWorkOrderDateRepairBegan.ReadOnly = valueBoolean
        txtWorkOrderStatus.ReadOnly = valueBoolean
        txtWorkOrderNotes.ReadOnly = valueBoolean

    End Sub
End Class