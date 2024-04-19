'Title:         Create Vehicle Maintenance Work Order
'Date:          11-11-14
'Author:        Terry Holmes

'Description:   This Form is used to create a vehicle work order

Option Strict On

Public Class CreateVehicleMaintenanceWorkOrder

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

    Private Sub SetComboBoxBinding()

        'This will set the binding
        With cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                .DropDownStyle = ComboBoxStyle.Simple
            End If

        End With

    End Sub

    Private Sub CreateVehicleMaintenanceWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up when the form is launced
        Dim intVendorNumberOfRecords As Integer

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
            txtVehicleDownForRepairs.DataBindings.Add("text", TheVehiclesBindingSource, "DownForRepairs")
            txtVehicleNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")

            MakeVehicleControlsVisable(False)

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

            'setting size of array
            intVendorNumberOfRecords = cboVendorName.Items.Count - 1
            ReDim mintSelectedIndex(intVendorNumberOfRecords)

            MakeVendorControlsVisable(False)

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
            txtWorkOrderDateReported.DataBindings.Add("text", TheVehicleRepairsBindingSource, "DateReported")
            txtWorkOrderNotes.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Notes")
            txtWorkOrderOdometer.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Odometer")
            txtWorkOrderProblemDescription.DataBindings.Add("text", TheVehicleRepairsBindingSource, "ProblemDescription")
            txtWorkOrderStatus.DataBindings.Add("text", TheVehicleRepairsBindingSource, "Status")
            txtWorkOrderVehicleID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VehicleID")
            txtWorkOrderVendorID.DataBindings.Add("text", TheVehicleRepairsBindingSource, "VendorID")

            'Creating the New Record
            AddNewRecord()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub AddNewRecord()

        'Setting local variables
        Dim datLogDate As Date = Date.Now
        SetControlsReadOnly(False)

        'This will add a new record
        With TheVehicleRepairsBindingSource
            .EndEdit()
            .AddNew()
        End With

        'Setting up variables for adding a record
        addingBoolean = True
        SetComboBoxBinding()
        cboTransactionID.Focus()
        btnAdd.Text = "Save"
        If cboTransactionID.SelectedIndex <> -1 Then
            previousSelectedIndex = cboTransactionID.Items.Count - 1
        Else
            previousSelectedIndex = 0
        End If

        'Calling Form to create ID
        VehicleRepairID.Show()

        'Placing the ID in the combo box
        cboTransactionID.Text = CStr(Logon.mintCreatedTransactionID)

        'Loading up the rest of the preset controls
        txtWorkOrderStatus.Text = "OPEN"
        txtWorkOrderDateReported.Text = CStr(datLogDate)


    End Sub

    Private Sub MakeVendorControlsVisable(ByVal valueBoolean As Boolean)

        'This will make the Vendor Controls visable
        cboVendorName.Visible = valueBoolean
        txtVendorTableID.Visible = valueBoolean
        txtEnterVendorName.Visible = valueBoolean
        btnSearchForVendor.Visible = valueBoolean
        btnBack.Visible = valueBoolean
        btnNext.Visible = valueBoolean
        btnSelectVendor.Visible = valueBoolean

    End Sub
    Private Sub MakeVehicleControlsVisable(ByVal valueBoolean As Boolean)

        'This will make the vehicle controls visible
        txtVehicleActive.Visible = valueBoolean
        txtVehicleDownForRepairs.Visible = valueBoolean
        txtVehicleBJCNumber.Visible = valueBoolean
        btnSelectVehicle.Visible = valueBoolean
        txtVehicleNotes.Visible = valueBoolean
    End Sub

    Private Sub btnSearchBJCNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBJCNumber.Click

        'This will search for the vehicle entered

        'Setting local variables
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndex As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer
        Dim strVehicleActive As String
        Dim blnItemNotFound As Boolean = True
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False

        'Performing Data Validation
        strValueForValidation = txtEnterBJCNumber.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        'Output to user if there is a problem
        If blnFatalError = True Then
            txtEnterBJCNumber.Text = ""
            MessageBox.Show("BJC Number is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        MakeVehicleControlsVisable(True)

        'Setting up to find the vehicle
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        intBJCNumberForSearch = CInt(strValueForValidation)

        'Beginning loop to find vehicle number
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box
            cboVehicleID.SelectedIndex = intCounter

            'Loading up variables
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)
            strVehicleActive = txtVehicleActive.Text

            'If statements to set the variable
            If strVehicleActive = "YES" Then
                If intBJCNumberForSearch = intBJCNumberFromTable Then
                    intSelectedIndex = intCounter
                    blnItemNotFound = False
                End If
            End If
        Next

        'Output to user if the record was not found
        If blnItemNotFound = True Then
            MakeVehicleControlsVisable(False)
            txtEnterBJCNumber.Text = "'"
            MessageBox.Show("The Item Entered Was Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Viewing the correct record
        cboVehicleID.SelectedIndex = intSelectedIndex

    End Sub

    Private Sub btnSelectVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectVehicle.Click

        'This will add the value to the work order
        txtWorkOrderVehicleID.Text = cboVehicleID.Text
        MakeVehicleControlsVisable(False)
        MakeVendorControlsVisable(True)

    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'This will increment the counter
        mintCounter += 1
        cboVendorName.SelectedIndex = mintSelectedIndex(mintCounter)

        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'This will decrement the counter
        mintCounter -= 1
        cboVendorName.SelectedIndex = mintSelectedIndex(mintCounter)

        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnSelectVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectVendor.Click

        'This will put the Vendor ID in the text box
        txtWorkOrderVendorID.Text = txtVendorTableID.Text
        MakeVendorControlsVisable(False)

    End Sub

    Private Sub btnSearchForVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchForVendor.Click

        'This will search for a specific vendor by name
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim intFirstCounter As Integer
        Dim intSecondCounter As Integer
        Dim strNameForSearch As String
        Dim strNameFromTable As String
        Dim intCharacterCountForSearch As Integer
        Dim intCharacterCountFromTable As Integer
        Dim blnFatalError As Boolean = False
        Dim blnItemNotFound As Boolean = True
        Dim strKeyWordFromTable As String = ""
        Dim chaKeyWordFromTable() As Char

        'Setting up for search
        intNumberOfRecords = cboVendorName.Items.Count - 1
        strNameForSearch = txtEnterVendorName.Text
        mintCounter = 0
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Setting the value from the com
            cboVendorName.SelectedIndex = intCounter
            strNameFromTable = cboVendorName.Text
            intCharacterCountFromTable = strNameFromTable.Length - 1
            intCharacterCountForSearch = strNameForSearch.Length - 1

            'If statement for the search string to be less than or equal to the table
            If intCharacterCountForSearch <= intCharacterCountFromTable Then

                'Checking to see if the strings match
                If intCharacterCountForSearch = intCharacterCountFromTable Then
                    If strNameForSearch = strNameFromTable Then
                        mintSelectedIndex(mintCounter) = intCounter
                        mintCounter += 1
                        blnItemNotFound = False
                    End If
                Else

                    'Beginning Key Word Search
                    chaKeyWordFromTable = strNameFromTable.ToCharArray

                    'Beginning first loop
                    For intFirstCounter = 0 To intCharacterCountFromTable

                        'Beginning second loop
                        For intSecondCounter = intFirstCounter To intCharacterCountForSearch

                            'Setting up the string for search
                            strKeyWordFromTable = strKeyWordFromTable + chaKeyWordFromTable(intSecondCounter)

                        Next

                        'Checking to see if there needs to be another loop
                        If intCharacterCountForSearch < intCharacterCountFromTable Then
                            intCharacterCountForSearch += 1
                        End If

                        'Checking to see if the key word is found
                        If strKeyWordFromTable = strNameForSearch Then
                            mintSelectedIndex(mintCounter) = intCounter
                            mintCounter += 1
                            blnItemNotFound = False
                        End If

                        strKeyWordFromTable = ""

                    Next
                End If
            End If
        Next

        If blnItemNotFound = True Then
            MessageBox.Show("Item Entered Not Found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Setting up the combo box and navigation controls
        mintUpperLimit = mintCounter - 1
        mintCounter = 0
        cboVendorName.SelectedIndex = mintSelectedIndex(0)

        If mintUpperLimit > 0 Then
            btnNext.Enabled = True
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim strLogDate As String
        Dim strProblemDescription As String
        Dim strErrorMessage As String = ""

        If btnAdd.Text = "Add" Then

            'Calling the Add New Record Routine
            AddNewRecord()

        Else

            'This will begin the data validation
            strValueForValidation = txtWorkOrderDateReported.Text
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Date Entered is not a Date" + vbNewLine
            End If

            strValueForValidation = txtWorkOrderOdometer.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Odometer Value Entered is not an Integer" + vbNewLine
            End If

            strValueForValidation = txtWorkOrderProblemDescription.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "No Value Was Entered for Problem Description" + vbNewLine
            End If

            strValueForValidation = txtWorkOrderVehicleID.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Vehicle ID Entered is not an Integer" + vbNewLine
            End If

            strValueForValidation = txtWorkOrderVendorID.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Vendor ID was not Entered" + vbNewLine
            End If
        

        'Output to user if validation fails
            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        strLogDate = txtWorkOrderDateReported.Text
        strProblemDescription = txtWorkOrderProblemDescription.Text
        Logon.mintWorkOrderNumber = CInt(cboTransactionID.Text)

        'Try Catch to save the record
        Try
            TheVehicleRepairsBindingSource.EndEdit()
            TheVehicleRepairsDataTier.UpdateDB(TheVehicleRepairsDataSet)
            editingBoolean = False
            addingBoolean = False
            SetComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex
            SetControlsReadOnly(True)
            btnAdd.Text = "Add"
            txtEnterBJCNumber.Text = ""
            MessageBox.Show("The Work Order is Saved", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtVehicleDownForRepairs.Text = "YES"
            txtVehicleNotes.Text = "VEHICLE DOWN FOR REPAIRS ON " + strLogDate + " " + strProblemDescription
            TheVehiclesBindingSource.EndEdit()
            TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)

            'Print Work Order Option
            PrintWorkOrderOption.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        End If

    End Sub
    Private Sub SetControlsReadOnly(ByVal valueBoolean As Boolean)

        'Will set the controls readonly
        txtWorkOrderOdometer.ReadOnly = valueBoolean
        txtWorkOrderProblemDescription.ReadOnly = valueBoolean
        txtWorkOrderDateReported.ReadOnly = valueBoolean
        txtWorkOrderNotes.ReadOnly = valueBoolean

    End Sub
End Class