'Title:         Enter Vehicle Inventory Sheets
'Date:          9/16/13
'Author:        Terry Holmes

'Description:   The User would enter Vehicle Inventory Sheets In

Option Strict On

Public Class VehicleInventorySheets

    'Setting Modular Variables
    Private TheVehicleInventorySheetDataSet As VehicleInventorySheetDataSet
    Private TheVehicleInventorySheetDataTier As VehicleInventorySheetDataTier
    Private WithEvents TheVehicleInventorySheetBindingSource As BindingSource

    Private TheVehicleDataTier As VehiclesDataTier
    Private TheVehicleDataSet As VehiclesDataSet
    Private WithEvents TheVehicleBindingSource As BindingSource

    'setting up the vehicle structure
    Structure Vehicles
        Dim mintVehicleID As Integer
        Dim mintBJCNumber As Integer
        Dim mintLastOilChangeOdometer As Integer
        Dim mstrActive As String
    End Structure

    Dim structVehicles() As Vehicles
    Dim mintVehicleUpperLimit As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String

    Dim mintCreatedTransactionID As Integer
    Friend mstrDoneDataEntry As String

    'Setting local variables
    Dim strValueForValidation As String
    Dim blnFatalError As Boolean
    Dim intNumberOfRecords As Integer
    Dim mblnFatalError As Boolean
    Dim mstrErrorMessage As String

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click
        LastTransaction.Show()
        InspectionsMenu.Show()
        Me.Close()
    End Sub
    Private Sub setComboBoxBinding()

        'Sets the Combobox Binding
        With cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Function SetVehicleBindings() As Boolean

        'Setting local variables
        Dim blnFatalError As Boolean = False
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer

        'try catch for exceptions
        Try

            'setting the vehicle bindings
            TheVehicleDataTier = New VehiclesDataTier
            TheVehicleDataSet = TheVehicleDataTier.GetVehiclesInformation
            TheVehicleBindingSource = New BindingSource

            'setting up the binding source
            With TheVehicleBindingSource
                .DataSource = TheVehicleDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboTransactionID
                .DataSource = TheVehicleBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("Text", TheVehicleBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'setting up the rest of the controls
            txtBJCNumber.DataBindings.Add("text", TheVehicleBindingSource, "BJCNumber")
            txtOdometerReading.DataBindings.Add("text", TheVehicleBindingSource, "LastOilChangeOdometer")
            txtNotes.DataBindings.Add("text", TheVehicleBindingSource, "Active")

            'gettingready for the loop
            intNumberOfRecords = cboTransactionID.Items.Count - 1
            ReDim structVehicles(intNumberOfRecords)
            mintVehicleUpperLimit = intNumberOfRecords

            'Preforming Loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboTransactionID.SelectedIndex = intCounter

                structVehicles(intCounter).mintVehicleID = CInt(cboTransactionID.Text)
                structVehicles(intCounter).mintBJCNumber = CInt(txtBJCNumber.Text)
                structVehicles(intCounter).mintLastOilChangeOdometer = CInt(txtOdometerReading.Text)
                structVehicles(intCounter).mstrActive = txtNotes.Text

            Next

            'returning value to call sub-routine
            Return blnFatalError

        Catch ex As Exception

            'Message to user
            mstrErrorMessage = ex.Message
            blnFatalError = True

            'returning value to call sub-routine
            Return blnFatalError

        End Try


    End Function
    Private Sub ClearSelectedBindings()

        'This will clear the vehicle data Bindings
        cboTransactionID.DataBindings.Clear()
        txtBJCNumber.DataBindings.Clear()
        txtOdometerReading.DataBindings.Clear()
        txtNotes.DataBindings.Clear()
        txtNotes.Text = ""
        txtOdometerReading.Text = ""

    End Sub

    Private Sub VehicleInventorySheets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This routine runs when the form is loaded
        'setting local variables
        Dim blnFatalError As Boolean = False

        PleaseWait.Show()

        'This Try Catch will catch any exceptions that are through during the routine
        Logon.mstrLastTransactionSummary = "Running Vehicle Inventory Sheets"
        blnFatalError = SetVehicleBindings()

        If blnFatalError = True Then

            MessageBox.Show(mstrErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf blnFatalError = False Then

            'clearing the bindings
            ClearSelectedBindings()

            Try

                'This will bind the controls to the data source
                TheVehicleInventorySheetDataTier = New VehicleInventorySheetDataTier
                TheVehicleInventorySheetDataSet = TheVehicleInventorySheetDataTier.GetVehicleInventorySheetInformation
                TheVehicleInventorySheetBindingSource = New BindingSource

                'Setting up the binding for the Combobox
                With TheVehicleInventorySheetBindingSource
                    .DataSource = TheVehicleInventorySheetDataSet
                    .DataMember = "vehicleinventorysheet"
                    .MoveFirst()
                    .MoveLast()
                End With

                'Setting up the Table Relationships and binding for the table.
                With cboTransactionID
                    .DataSource = TheVehicleInventorySheetBindingSource
                    .DisplayMember = "TransactionID"
                    .DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
                End With

                'Setting up the data bindings for the textboxes
                txtBJCNumber.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "BJCNumber")
                txtDate.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "Date")
                txtInventorySheetPresent.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "InventorySheet")
                txtOdometerReading.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "OdometerReading")
                txtNotes.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "Notes")
                txtProblemCritical.DataBindings.Add("text", TheVehicleInventorySheetBindingSource, "ProblemCritical")
                txtProblemReported.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "ProblemReported")
                txtWorkOrderCreated.DataBindings.Add("Text", TheVehicleInventorySheetBindingSource, "WorkOrderCreated")

                PleaseWait.Close()
                btnAdd.PerformClick()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
    Private Sub SetForPreLoad()

        'Placing the Binding Source to Add a record
        With TheVehicleInventorySheetBindingSource
            .EndEdit()
            .AddNew()
        End With

        'Calling routines and setting the values
        addingBoolean = True
        setComboBoxBinding()
        cboTransactionID.Focus()
        setControlsReadOnly(False)
        setButtonsForEdit()
        If cboTransactionID.SelectedIndex <> -1 Then
            previousSelectedIndex = cboTransactionID.Items.Count - 1
        Else
            previousSelectedIndex = 0
        End If

        txtAreYouDoneWithDataEntry.Text = "NO"
        

        'Setting up fields with auto-data to avoid having the user do it.
        mintNumuberOfRecords = cboTransactionID.Items.Count
        intNumberOfRecords = mintNumuberOfRecords + 1000
        mintCreatedTransactionID = intNumberOfRecords

        Logon.mintCreatedTransactionID = mintCreatedTransactionID

        VehicleSheetTurnInIDCreation.Show()

        mintCreatedTransactionID = CInt(Logon.mintCreatedTransactionID)

        cboTransactionID.Text = CStr(mintCreatedTransactionID)
        txtInventorySheetPresent.Text = "YES"
        strLogDateTime = CStr(Logon.mdatDateForDataEntry)
        txtDate.Text = strLogDateTime

    End Sub
    Private Sub SaveData()

        Dim strErrorMessage As String = ""
        Dim blnThereIsAProblem As Boolean = False
        Dim strProblemReported As String
        Dim strProblemCritical As String
        Dim strWorkOrderCreated As String
        Dim strNotes As String
        Dim intOdometerReading As Integer
        Dim intBJCNumberForSearch As Integer
        Dim intOdometerDifference As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intCounter As Integer
        Dim blnPreventiveMaintenaceNeeded As Boolean = False
        Dim strVehicleNotes As String = ""
        Dim strNotesEntered As String

        'Preforming Data Validation
        strValueForValidation = txtBJCNumber.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "BJC Number is not an Integer" + vbNewLine
        Else
            If strValueForValidation.Length > 4 Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "BJC Number is not the valid format" + vbNewLine
            End If
        End If

        strValueForValidation = txtDate.Text
        blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Date Entered is not a Date" + vbNewLine
        End If

        strValueForValidation = txtInventorySheetPresent.Text
        blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "Inventory Sheet Present has to be Either a Yes or No" + vbNewLine
        End If

        strValueForValidation = txtProblemReported.Text
        blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
        strProblemReported = txtProblemReported.Text
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Problem Reported has to be Either a Yes or No" + vbNewLine
        End If

        strProblemCritical = txtProblemCritical.Text
        blnFatalError = TheInputDataValidation.VerifyYesNoData(strProblemCritical)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Problem Critical has to be either a Yes or No" + vbNewLine
        End If

        strWorkOrderCreated = txtWorkOrderCreated.Text
        blnFatalError = TheInputDataValidation.VerifyYesNoData(strWorkOrderCreated)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Work Order Created has to be either a Yes or No" + vbNewLine
        End If

        strValueForValidation = txtOdometerReading.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = True Then
            blnThereIsAProblem = True
            strErrorMessage = strErrorMessage + "The Odometer Reading is not an Integer" + vbNewLine
        End If

        If strProblemReported = "YES" Then
            strNotes = txtNotes.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strNotes)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Notes were not Entered" + vbNewLine
            End If
        End If

        strValueForValidation = txtAreYouDoneWithDataEntry.Text
        blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)

        'Putting out error message if data validation fails
        If blnThereIsAProblem = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'getting ready for the loop
        intBJCNumberForSearch = CInt(txtBJCNumber.Text)
        intOdometerReading = CInt(txtOdometerReading.Text)

        'Preparing for loop
        For intCounter = 0 To mintVehicleUpperLimit

            'getting bjc number
            intBJCNumberFromTable = structVehicles(intCounter).mintBJCNumber

            'if statements
            If intBJCNumberForSearch = intBJCNumberFromTable Then
                If structVehicles(intCounter).mstrActive = "YES" Then

                    'getting ready to check the mileage
                    intOdometerDifference = intOdometerReading - structVehicles(intCounter).mintLastOilChangeOdometer

                    If intOdometerDifference > 3000 Then
                        blnPreventiveMaintenaceNeeded = True
                        strNotesEntered = txtNotes.Text
                        txtNotes.Text = strNotesEntered + " And Vehicle is in Need of Preventive Maintenance"
                        MessageBox.Show("Vehicle is in Need of Preventive Maintenance", "Please Alert Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If
            End If
        Next

        If strProblemCritical = "YES" Then
            strVehicleNotes = strVehicleNotes + txtNotes.Text + vbNewLine
        End If

        'Checking Preventive Maintenance
        If txtProblemCritical.Text = "YES" Then
            Logon.mstrNotes = strVehicleNotes
            Logon.mintBJCNumber = CInt(txtBJCNumber.Text)
            Logon.mintOdometerTransferred = CInt(txtOdometerReading.Text)
            Logon.mstrDownForRepair = "YES"
            CheckVehicleRepairOrder.Show()
        Else
            FinishInformationSave()
        End If


    End Sub
    Public Sub FinishInformationSave()

        'if statement to see if a work order was created
        If Logon.mblnWorkOrderCreated = True Then
            txtWorkOrderCreated.Text = "YES"
        Else
            txtWorkOrderCreated.Text = "NO"
        End If

        'Updating Database
        Try
            TheVehicleInventorySheetBindingSource.EndEdit()
            TheVehicleInventorySheetDataTier.UpdateDB(TheVehicleInventorySheetDataSet)
            addingBoolean = False
            editingBoolean = False
            setComboBoxBinding()
            cboTransactionID.SelectedIndex = previousSelectedIndex

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        mstrDoneDataEntry = txtAreYouDoneWithDataEntry.Text
        txtBJCNumber.Focus()
        If mstrDoneDataEntry = "YES" Then

            setControlsReadOnly(True)
            ResetButtonAfterEditing()

        Else

            SetForPreLoad()
            txtBJCNumber.Text = ""
            txtProblemCritical.Text = ""
            txtProblemReported.Text = ""
            txtWorkOrderCreated.Text = ""
            txtOdometerReading.Text = ""
            txtNotes.Text = ""

        End If

        txtBJCNumber.Focus()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'This will add or save a record to the data set
        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding a trailer

            'setting up to create new record
            SetForPreLoad()

        Else

            'saving information
            SaveData()

        End If
    End Sub

    Private Sub setButtonsForEdit()

        'Sets the buttons up for editing and saving a record
        btnAdd.Text = "Save"
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons up for adding records
        btnAdd.Text = "Add"
        btnMainMenu.Enabled = True

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me
            
            txtDate.ReadOnly = valueBoolean
            txtBJCNumber.ReadOnly = valueBoolean
            txtInventorySheetPresent.ReadOnly = valueBoolean
            txtAreYouDoneWithDataEntry.ReadOnly = valueBoolean
        End With

    End Sub

    Private Sub txtBJCNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumber.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnAdd.PerformClick()

        End If
    End Sub

    Private Sub txtDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDate.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnAdd.PerformClick()

        End If

    End Sub
    Private Sub btnChangeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDate.Click

        Logon.mstrFormForDataEntry = "VEHICLEINVENTORY"
        DataEntryDate.Show()
        Me.Close()

    End Sub
End Class