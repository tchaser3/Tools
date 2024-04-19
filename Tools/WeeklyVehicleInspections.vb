'Title:         Weekly Inspection Form
'Date:          7/29/13
'Author:        Terry Holmes

'Description:   This form is used to log in the Weekly Inspections

Option Strict On

Public Class WeeklyVehicleInspections

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheWeeklyVehicleInspectionsDataSet As WeeklyVehicleInspectionsDataSet
    Private TheWeeklyVehicleInspectionDataTier As WeeklyVehicleInpectionDataTier
    Private WithEvents TheWeeklyVehicleInspectionBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer

    'Variables for History
    Friend mintVehicleID As Integer
    Friend mintEmployeeID As Integer
    Friend mstrLogDateTime As String
    Friend mstrNotes As String
    Friend mintBJCNumber As Integer
    Friend mblnOilChangeUpdated As Boolean = False

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Calls the close the program form
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        LastTransaction.Show()
        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
        LastTransaction.Show()
        MainMenu.Show()
        Me.Close()

    End Sub

    Private Sub setComboBoxBinding()

        'Sets the Combobox Bindings
        With Me.cboEmployeeID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboVehicleID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboInspectionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

    End Sub
    Private Sub setControlsReadOnly(ByVal valueBoolean As Boolean)

        'This will set controls either to read only or not
        With Me

            txtInspectionDate.ReadOnly = valueBoolean
            txtInspectionNotes.ReadOnly = valueBoolean
            txtInspectionCurrentOdometer.ReadOnly = valueBoolean
            txtInspectionNextOilChangeOdometer.ReadOnly = valueBoolean
            txtInspectionPPEInspected.ReadOnly = valueBoolean
            txtInspectionToolsInspected.ReadOnly = valueBoolean
            txtInspectionVehicleCleanliness.ReadOnly = valueBoolean
            txtInspectionVehicleServiceable.ReadOnly = valueBoolean

        End With

    End Sub

    Private Sub setInspectionTextBoxesVisible(ByVal valueboolean As Boolean)

        cboInspectionID.Visible = valueboolean
        txtInspectionBJCNumber.Visible = valueboolean
        txtInspectionDate.Visible = valueboolean
        txtInspectionEmployeeID.Visible = valueboolean
        txtInspectionNotes.Visible = valueboolean
        txtInspectionCurrentOdometer.Visible = valueboolean
        txtInspectionVehicleID.Visible = valueboolean
        txtInspectionNextOilChangeOdometer.Visible = valueboolean
        txtInspectionPPEInspected.Visible = valueboolean
        txtInspectionToolsInspected.Visible = valueboolean
        txtInspectionVehicleCleanliness.Visible = valueboolean
        txtInspectionVehicleServiceable.Visible = valueboolean

    End Sub


    Private Sub setTextBoxesVisible(ByVal valueBoolean As Boolean)

        'This will set controls either to visible or not
        With Me

            txtFirstName.Visible = valueBoolean
            txtLastName.Visible = valueBoolean
            txtPhoneNumber.Visible = valueBoolean

            txtVehicleBJCNumber.Visible = valueBoolean
            txtVehicleLastOilChangeOdometer.Visible = valueBoolean
            txtVehicleMake.Visible = valueBoolean
            txtVehicleModel.Visible = valueBoolean
            txtVehicleEmployeeID.Visible = valueBoolean

        End With

    End Sub

    Private Sub FindEmployeeID()

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer
        Dim intEmployeeID As Integer

        intEmployeeID = Logon.mintEmployeeID

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboEmployeeID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboEmployeeID.Text)

            If intEmployeeIDFromTable = intEmployeeID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboEmployeeID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub


    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        'This will find the vehicle
        FindIndividualVehicle()

    End Sub
    Private Sub FindIndividualVehicle()

        'This sub-routine runs when the Find Tool button is pressed
        Dim blnFatalError As Boolean
        Dim intBJCNumberEntered As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDCBOSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnBJCNumberNotFound As Boolean = True
        Dim strBJCNumber As String

        'Setting Validation Variable initial condition
        strBJCNumber = CStr(txtBJCNumberEntered.Text)

        blnFatalError = TheInputDataValidation.VerifyIntegerData(strBJCNumber)

        'Sending Error Message to User
        If blnFatalError = True Then
            MessageBox.Show("The BJC Number is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnAdd.Enabled = True
        setTextBoxesVisible(True)

        'Setting Variables for Tool ID Search
        intBJCNumberEntered = CInt(txtBJCNumberEntered.Text)
        intNumberOfRecords = cboVehicleID.Items.Count

        'Performing Search
        For intCounter = 0 To intNumberOfRecords - 1
            cboVehicleID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)

            If intBJCNumberEntered = intBJCNumberFromTable Then
                blnBJCNumberNotFound = False
                intVehicleIDCBOSelectedIndex = intCounter
            End If

        Next

        'Putting out Error Message or moving the Combo Box
        If blnBJCNumberNotFound = True Then
            cboVehicleID.Visible = False
            MessageBox.Show("BJC Number Not Found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else

        End If

        'Setting the buttons up for signing out the tool

        'setComboBoxBinding()
        strLogDateTime = CStr(LogDateTime)
        cboVehicleID.SelectedIndex = intVehicleIDCBOSelectedIndex

        'cboEmployeeID.Visible = True
        txtFirstName.Visible = True
        txtLastName.Visible = True
        txtPhoneNumber.Visible = True
        btnPreventiveMaintenance.Enabled = True

        FindEmployeeID()

        cboVehicleID.Visible = False
    End Sub
    Private Sub setButtonsForEdit()

        'Sets the buttons up for editing and saving a record
        btnAdd.Text = "Save Inspection"
        btnMainMenu.Enabled = False

    End Sub
    Private Sub ResetButtonAfterEditing()

        'Setting the buttons up for adding records
        btnAdd.Text = "Add Inspection"
        btnMainMenu.Enabled = True

    End Sub
    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindVehicle.PerformClick()
            btnAdd.Focus()
        End If

    End Sub

    Private Sub ClearDataBindings()

        'This sub routine clears all Data Bindings

        'Removing Data Bindings for Employees
        cboEmployeeID.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()

        'Removing Data Bindings for Vehicles
        cboVehicleID.DataBindings.Clear()
        txtVehicleBJCNumber.DataBindings.Clear()
        txtVehicleEmployeeID.DataBindings.Clear()
        txtVehicleLastOilChangeOdometer.DataBindings.Clear()
        txtVehicleMake.DataBindings.Clear()
        txtVehicleModel.DataBindings.Clear()

        'Removing Data Bindings for Inspection
        cboInspectionID.DataBindings.Clear()
        txtInspectionVehicleID.DataBindings.Clear()
        txtInspectionBJCNumber.DataBindings.Clear()
        txtInspectionEmployeeID.DataBindings.Clear()
        txtInspectionCurrentOdometer.DataBindings.Clear()
        txtInspectionDate.DataBindings.Clear()
        txtInspectionNextOilChangeOdometer.DataBindings.Clear()
        txtInspectionToolsInspected.DataBindings.Clear()
        txtInspectionVehicleCleanliness.DataBindings.Clear()
        txtInspectionPPEInspected.DataBindings.Clear()
        txtInspectionNotes.DataBindings.Clear()
        txtInspectionVehicleServiceable.DataBindings.Clear()


    End Sub


    Private Sub WeeklyVehicleInspections_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Employee Try - Catch
        Try
            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting the data relationship for the Combo Box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")

            LastTransaction.Show()

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        SetVehicleBindings()

        FindEmployeeID()

        'Inspection Informtion Try - Catch
        Try

            TheWeeklyVehicleInspectionDataTier = New WeeklyVehicleInpectionDataTier
            TheWeeklyVehicleInspectionsDataSet = TheWeeklyVehicleInspectionDataTier.GetWeeklyVehicleInpectionInformation
            TheWeeklyVehicleInspectionBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheWeeklyVehicleInspectionBindingSource
                .DataSource = TheWeeklyVehicleInspectionsDataSet
                .DataMember = "WeeklyVehicleInspections"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboInspectionID
                .DataSource = TheWeeklyVehicleInspectionBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            txtInspectionVehicleID.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleID")
            txtInspectionBJCNumber.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "BJCNumber")
            txtInspectionEmployeeID.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "EmployeeID")
            txtInspectionCurrentOdometer.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "CurrentOdometer")
            txtInspectionDate.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionDate")
            txtInspectionNextOilChangeOdometer.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "NextOilChangeOdometer")
            txtInspectionToolsInspected.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "ToolsInspected")
            txtInspectionVehicleCleanliness.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleCleanliness")
            txtInspectionPPEInspected.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "PPEInspected")
            txtInspectionNotes.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "InspectionNotes")
            txtInspectionVehicleServiceable.DataBindings.Add("text", TheWeeklyVehicleInspectionBindingSource, "VehicleServiceability")

            setControlsReadOnly(True)

            setTextBoxesVisible(False)
            setInspectionTextBoxesVisible(False)
            mblnOilChangeUpdated = False

            If Logon.mblnOilChangeDate = True Then
                setTextBoxesVisible(True)
            End If

            Logon.mblnOilChangeDate = False

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearVehicleBindings()

        'This will clear the vehicle bindings
        cboVehicleID.DataBindings.Clear()
        txtVehicleBJCNumber.DataBindings.Clear()
        txtVehicleEmployeeID.DataBindings.Clear()
        txtVehicleLastOilChangeOdometer.DataBindings.Clear()
        txtVehicleModel.DataBindings.Clear()
        txtVehicleMake.DataBindings.Clear()

    End Sub
    Public Sub SetVehicleBindings()

        ClearVehicleBindings()
        'Vehicle Try - Catch
        Try

            'This will bind the controls to the data source
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehicleEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtVehicleLastOilChangeOdometer.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeOdometer")
            txtVehicleMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtVehicleModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")

            If Logon.mblnOilChangeDate = True Then
                txtBJCNumberEntered.Text = CStr(Logon.mintBJCNumber)
                FindIndividualVehicle()
            End If

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error With Vehicle Bindings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim strOdometer As String
        Dim intLastOilChangeOdometer As Integer
        Dim intCurrentOdometer As Integer
        Dim blnNeedsOilChange As Boolean
        Dim strBJCNumber As String = ""
        Dim intOdometerDifference As Integer
        Dim strNextOilChangeOdometer As String
        Dim intNextOilChangeOdometer As Integer
        Dim strInputValueForValidation As String
        Dim strErrorMessage As String = ""


        'This will run when the Add/Save Button is Pressed
        If btnAdd.Text = "Add Inspection" Then

            setInspectionTextBoxesVisible(True)

            btnPreventiveMaintenance.Enabled = False

            'Placing the Binding Source to Add a record
            With TheWeeklyVehicleInspectionBindingSource
                .EndEdit()
                .AddNew()
            End With

            'Calling routines and setting the values
            addingBoolean = True
            setComboBoxBinding()
            cboInspectionID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboInspectionID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboInspectionID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboInspectionID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000
            Logon.mintCreatedInspectionID = intNumberOfRecords

            'Calling the Trailer ID From
            InspectionIDGenerator.Show()

            cboInspectionID.Text = CStr(Logon.mintCreatedInspectionID)
            txtInspectionCurrentOdometer.ReadOnly = False
            txtInspectionNotes.ReadOnly = False
            txtInspectionBJCNumber.Text = txtVehicleBJCNumber.Text
            txtInspectionEmployeeID.Text = CStr(cboEmployeeID.Text)
            txtInspectionVehicleID.Text = CStr(cboVehicleID.Text)
            strLogDateTime = CStr(LogDateTime)
            txtInspectionDate.Text = strLogDateTime

            intLastOilChangeOdometer = CInt(txtVehicleLastOilChangeOdometer.Text)
            intNextOilChangeOdometer = intLastOilChangeOdometer + 5000
            txtInspectionNextOilChangeOdometer.Text = CStr(intNextOilChangeOdometer)

        Else

            blnFatalError = False

            strOdometer = txtInspectionCurrentOdometer.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strOdometer)

            If blnFatalError = False Then
                strNextOilChangeOdometer = txtInspectionNextOilChangeOdometer.Text
                strErrorMessage = "The Next Oil Change Odometer is not an Integer"
                blnFatalError = TheInputDataValidation.VerifyIntegerData(strNextOilChangeOdometer)
            End If

            If blnFatalError = False Then
                strInputValueForValidation = txtInspectionToolsInspected.Text
                strErrorMessage = "The Tools Inspected is not a Yes or No"
                blnFatalError = TheInputDataValidation.VerifyYesNoData(strInputValueForValidation)
            End If
            If blnFatalError = False Then
                strInputValueForValidation = txtInspectionVehicleCleanliness.Text
                strErrorMessage = "The Vehicle Cleanliness is not a Yes or No"
                blnFatalError = TheInputDataValidation.VerifyYesNoData(strInputValueForValidation)
            End If
            If blnFatalError = False Then
                strInputValueForValidation = txtInspectionPPEInspected.Text
                strErrorMessage = "The PPE Inspected is not a Yes or No"
                blnFatalError = TheInputDataValidation.VerifyYesNoData(strInputValueForValidation)
            End If
            If blnFatalError = False Then
                strInputValueForValidation = txtInspectionVehicleServiceable.Text
                strErrorMessage = "The Vehicle Serviceable is not a Yes or No"
                blnFatalError = TheInputDataValidation.VerifyYesNoData(strInputValueForValidation)
            End If

            'Putting out error message if data validation fails
            If (blnFatalError = True) Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Setting global variable for Last Transaction
            LastTransaction.Show()

            'Updating Database
            Try
                'MessageBox.Show(cboInspectionID.Text, "Fuck Head", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TheWeeklyVehicleInspectionBindingSource.EndEdit()
                TheWeeklyVehicleInspectionDataTier.UpdateDB(TheWeeklyVehicleInspectionsDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboInspectionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            intLastOilChangeOdometer = CInt(txtVehicleLastOilChangeOdometer.Text)
            intCurrentOdometer = CInt(txtInspectionCurrentOdometer.Text)
            intOdometerDifference = intCurrentOdometer - intLastOilChangeOdometer

            If intOdometerDifference > 5000 Then
                blnNeedsOilChange = True
                strBJCNumber = txtInspectionBJCNumber.Text
            End If

            If blnNeedsOilChange = True Then
                MessageBox.Show("Vehicle BJC" + strBJCNumber + " Needs Preventative Maintenance", "Please Make Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            setTextBoxesVisible(False)
            setInspectionTextBoxesVisible(False)
            txtBJCNumberEntered.Text = ""
            btnAdd.Enabled = False
            btnPreventiveMaintenance.Enabled = False

        End If

        'ClearDataBindings()


    End Sub


    Private Sub btnPreventiveMaintenance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreventiveMaintenance.Click

        LastTransaction.Show()
        Logon.mintBJCNumber = CInt(txtVehicleBJCNumber.Text)
        Logon.mstrFormForDataEntry = "WEEKLYINSPECTION"
        VehiclePreventiveMaintenanceUpdate.Show()
        Me.Close()

    End Sub
End Class