'Title:         Daily Vehicle Inspection Form
'Date:          7/25/13
'Author:        Terry Holmes

'Description:   This form is used for Creating Entries in the Daily Inspection Log

Option Strict On

Public Class DailyVehicleInspection

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheDailyVehicleInspectionDataSet As DailyVehicleInspectionDataSet
    Private TheDailyVehicleInspectionDataTier As DailyVehicleInspectionDataTier
    Private WithEvents TheDailyVehicleInspectionBindingSource As BindingSource

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


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        'Opens the Tool Menu
        ClearDataBindings()
        InspectionsMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        ClearDataBindings()
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
            txtInspectionOdometer.ReadOnly = valueBoolean
            txtInspectionNoOfHoursDriven.ReadOnly = valueBoolean
            txtInspectionDOTFormIn.ReadOnly = valueBoolean

        End With

    End Sub

    Private Sub setInspectionTextBoxesVisible(ByVal valueboolean As Boolean)

        cboInspectionID.Visible = valueboolean
        txtInspectionBJCNumber.Visible = valueboolean
        txtInspectionDate.Visible = valueboolean
        txtInspectionEmployeeID.Visible = valueboolean
        txtInspectionNotes.Visible = valueboolean
        txtInspectionOdometer.Visible = valueboolean
        txtInspectionVehicleID.Visible = valueboolean
        txtInspectionNoOfHoursDriven.Visible = valueboolean
        txtInspectionDOTFormIn.Visible = valueboolean

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

    Private Sub FindEmployeeID(ByVal intEmployeeID As Integer)

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

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
    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        'This subroutine will run if the user is looking for the Employee ID
        Dim intEmployeeIDEntered As Integer
        Dim strEmployeeID As String
        Dim blnFatalError As Boolean

        strEmployeeID = CStr(txtEmployeeIDSearch.Text)
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strEmployeeID)

        If blnFatalError = True Then
            MessageBox.Show("The Employee ID is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Textboxes visible
        txtLastName.Visible = True
        txtFirstName.Visible = True
        txtPhoneNumber.Visible = True
        btnAdd.Enabled = True

        'Sets vaue of the local variable
        intEmployeeIDEntered = CInt(txtEmployeeIDSearch.Text)

        'Call sub-routine
        FindEmployeeID(intEmployeeIDEntered)

        'Message to the user
        If mblnEmployeeIDFound = False Then
            MessageBox.Show("Employee ID Entered Does Not Exist", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSearchByEmployeeLastName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeLastName.Click

        'This routine is used to search for by Last Name

        btnBack.Enabled = False
        btnNext.Enabled = False
        Dim strLastNameEntered As String
        Dim strLastNameFromTable As String
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim blnFatalError As Boolean
        Dim strErrorMessage As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting validation variables
        blnFatalError = False
        strErrorMessage = ""
        mblnLastNameFound = False

        'Performing Validation
        If txtLastNameSearch.Text = "" Then
            blnFatalError = True
            strErrorMessage = strErrorMessage + "No Last Name was entered to be searched" + vbNewLine
        End If

        'Letting User Know if there was a problem
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Making Textboxes Visible
        txtLastName.Visible = True
        txtFirstName.Visible = True
        txtPhoneNumber.Visible = True
        btnAdd.Enabled = True
        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting initial variables
        strLastNameEntered = CStr(txtLastNameSearch.Text)
        intNumberOfRecords = cboEmployeeID.Items.Count
        mintCounter = 0

        'Looking for Employee's Last Name
        For intCounter = 0 To intNumberOfRecords - 1
            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = CStr(txtLastName.Text)

            If strLastNameEntered = strLastNameFromTable Then
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                mblnLastNameFound = True
            End If
        Next

        'Performing Output to User
        If mblnLastNameFound = False Then
            MessageBox.Show("The Employee Last Name was not Found", "Please Verify and Try again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Enabling the Next Button
        If mintCounter > 1 Then
            btnNext.Enabled = True
        End If

        'Setting the Upper Limit Variable
        mintUpperLimit = mintCounter - 1
        mintCounter = 0

        'Placing the the Combobox in the first location
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)


    End Sub

    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        'This sub-routine runs when the Find Tool button is pressed
        Dim blnFatalError As Boolean
        Dim intBJCNumberEntered As Integer
        Dim intBJCNumberFromTable As Integer
        Dim intVehicleIDCBOSelectedIndex As Integer
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim blnBJCNumberNotFound As Boolean = True
        Dim intEmployeeIDFromTools As Integer
        Dim strBJCNumber As String

        btnNext.Enabled = False
        btnBack.Enabled = False

        'Setting Validation Variable initial condition
        strBJCNumber = CStr(txtBJCNumberEntered.Text)

        blnFatalError = TheInputDataValidation.VerifyIntegerData(strBJCNumber)

        'Sending Error Message to User
        If blnFatalError = True Then
            MessageBox.Show("The BJC Number is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        setTextBoxesVisible(True)

        btnSearchByEmployeeID.Enabled = True
        btnSearchByEmployeeLastName.Enabled = True

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
            cboVehicleID.SelectedIndex = intVehicleIDCBOSelectedIndex
        End If

        'Setting the buttons up for signing out the tool
        'setButtonsForEdit()
        setComboBoxBinding()
        strLogDateTime = CStr(LogDateTime)
        txtEmployeeIDSearch.Text = ""
        txtLastNameSearch.Text = ""

        'cboEmployeeID.Visible = True
        txtFirstName.Visible = True
        txtLastName.Visible = True
        txtPhoneNumber.Visible = True


        intEmployeeIDFromTools = CInt(txtVehicleEmployeeID.Text)

        FindEmployeeID(intEmployeeIDFromTools)

        cboVehicleID.Visible = False


    End Sub

    Private Sub DailyVehicleInspection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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


        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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

        Catch ex As Exception

            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Inspection Informtion Try - Catch
        Try

            TheDailyVehicleInspectionDataTier = New DailyVehicleInspectionDataTier
            TheDailyVehicleInspectionDataSet = TheDailyVehicleInspectionDataTier.GetDailyVehicleInpectionInformation
            TheDailyVehicleInspectionBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheDailyVehicleInspectionBindingSource
                .DataSource = TheDailyVehicleInspectionDataSet
                .DataMember = "VehicleDailyInspection"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboInspectionID
                .DataSource = TheDailyVehicleInspectionBindingSource
                .DisplayMember = "InspectionID"
                .DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "InspectionID", False, DataSourceUpdateMode.Never)
            End With

            txtInspectionBJCNumber.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "BJCNumber")
            txtInspectionVehicleID.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "VehicleID")
            txtInspectionEmployeeID.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "EmployeeID")
            txtInspectionDate.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "Date")
            txtInspectionNotes.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "Notes")
            txtInspectionNoOfHoursDriven.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "NumberOfHoursDriven")
            txtInspectionOdometer.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "Odometer")
            txtInspectionDOTFormIn.DataBindings.Add("text", TheDailyVehicleInspectionBindingSource, "DOTFormTurnedIn")

            setControlsReadOnly(True)
            setTextBoxesVisible(False)
            setInspectionTextBoxesVisible(False)

        Catch ex As Exception
            'If an exception is thrown, it is rounted here
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Setting local variables
        Dim blnFatalError As Boolean
        Dim intNumberOfRecords As Integer
        Dim intLastOilChangeOdometer As Integer
        Dim intCurrentOdometer As Integer
        Dim blnNeedsOilChange As Boolean
        Dim strBJCNumber As String = ""
        Dim intOdometerDifference As Integer
        Dim strValueForValidation As String
        Dim strErrorMessage As String

        'This will run when the Add/Save Button is Pressed
        If btnAdd.Text = "Add Inspection" Then

            setInspectionTextBoxesVisible(True)

            txtInspectionDate.Text = ""
            txtInspectionOdometer.Text = ""

            'Placing the Binding Source to Add a record
            With TheDailyVehicleInspectionBindingSource
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
            txtInspectionOdometer.ReadOnly = False
            txtInspectionNotes.ReadOnly = False
            txtInspectionBJCNumber.Text = txtVehicleBJCNumber.Text
            txtInspectionEmployeeID.Text = CStr(cboEmployeeID.Text)
            txtInspectionVehicleID.Text = CStr(cboVehicleID.Text)
            strLogDateTime = CStr(Logon.mdatDateForDataEntry)
            txtInspectionDate.Text = strLogDateTime
            txtInspectionDOTFormIn.Text = "YES"
            txtInspectionDOTFormIn.ReadOnly = True

            txtInspectionOdometer.Focus()

        Else

            'Clearing and setting initial Data Validation Values

            blnFatalError = False

            strValueForValidation = txtInspectionOdometer.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            strErrorMessage = "The Inspection Odometer is not an Integer"
            If blnFatalError = False Then
                strValueForValidation = txtInspectionNoOfHoursDriven.Text
                strErrorMessage = "The Inspection Hours are not an Integer"
                blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
                If blnFatalError = False Then
                    strValueForValidation = txtInspectionDate.Text
                    strErrorMessage = "The Date Entered is not a Date"
                    blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
                End If
            End If

            'Putting out error message if data validation fails
            If (blnFatalError = True) Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            intLastOilChangeOdometer = CInt(txtVehicleLastOilChangeOdometer.Text)
            intCurrentOdometer = CInt(txtInspectionOdometer.Text)
            intOdometerDifference = intCurrentOdometer - intLastOilChangeOdometer

            If intOdometerDifference > 5000 Then
                blnNeedsOilChange = True
                strBJCNumber = txtInspectionBJCNumber.Text
            End If

            If blnNeedsOilChange = True Then
                MessageBox.Show("Vehicle BJC" + strBJCNumber + " Needs Preventative Maintenance", "Please Make Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Updating Database
            Try
                TheDailyVehicleInspectionBindingSource.EndEdit()
                TheDailyVehicleInspectionDataTier.UpdateDB(TheDailyVehicleInspectionDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboInspectionID.SelectedIndex = previousSelectedIndex

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            setTextBoxesVisible(False)
            setInspectionTextBoxesVisible(False)
            txtBJCNumberEntered.Text = ""
            txtEmployeeIDSearch.Text = ""
            txtLastNameSearch.Text = ""
            btnAdd.Enabled = False


        End If
    End Sub

    Private Sub txtBJCNumberEntered_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberEntered.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindVehicle.PerformClick()
            txtEmployeeIDSearch.Focus()
        End If

    End Sub

    Private Sub txtEmployeeIDSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmployeeIDSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeID.PerformClick()
            txtInspectionOdometer.Focus()
        End If
    End Sub

    Private Sub txtLastNameSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastNameSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchByEmployeeLastName.PerformClick()
            If btnNext.Enabled = True Then
                btnNext.Focus()
            Else
                txtInspectionOdometer.Focus()
            End If
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
        txtInspectionBJCNumber.DataBindings.Clear()
        txtInspectionDate.DataBindings.Clear()
        txtInspectionEmployeeID.DataBindings.Clear()
        txtInspectionNotes.DataBindings.Clear()
        txtInspectionOdometer.DataBindings.Clear()
        txtInspectionVehicleID.DataBindings.Clear()
        txtInspectionNoOfHoursDriven.DataBindings.Clear()

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click


        mintCounter = mintCounter + 1
        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnBack.Enabled = True

        If mintCounter = mintUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintCounter = mintCounter - 1

        cboEmployeeID.SelectedIndex = mintSelectedIndex(mintCounter)

        btnNext.Enabled = True

        If mintCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnChangeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDate.Click

        Logon.mstrFormForDataEntry = "DOTFORM"
        DataEntryDate.Show()
        Me.Close()

    End Sub
End Class