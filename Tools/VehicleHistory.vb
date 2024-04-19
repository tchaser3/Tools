'Title:         Vehicle History
'Date:          7/23/13
'Author:        Terry Holmes

'Description:   This will show all the Vehicle History

Option Strict On

Public Class VehicleHistory

    Dim TheInputDataValidation As New InputDataValidation
    Dim mblnFatalError As Boolean

    'Setting Modular Variables
    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource
    Private WithEvents TheWarehouseEmployeeBindingSource As BindingSource

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheVehicleHistoryDataSet As VehicleHistoryDataSet
    Private TheVehicleHistoryDataTier As VehicleHistoryDataTier
    Private WithEvents TheVehicleHistoryBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Dim mblnEmployeeIDFound As Boolean
    Dim mintSelectedIndex(10000) As Integer
    Dim mintCounter As Integer
    Dim mblnLastNameFound As Boolean
    Dim mintUpperLimit As Integer
    Dim mintEmployeeID As Integer
    Dim mintWarehouseID As Integer
    Dim mintBJCNumber As Integer
    Dim mintSearchUpperLimit As Integer


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnVehicleMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleMenu.Click

        'Opens the vehicle Menu
        RemoveDataBindings()
        VehicleMenu.Show()
        Me.Close()

    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click

        'This opens the Main menu
        RemoveDataBindings()
        MainMenu.Show()
        VehicleMenu.Close()
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
                'Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If

        End With

        With Me.cboTransactionID
            If (addingBoolean Or editingBoolean) Then
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                .DropDownStyle = ComboBoxStyle.Simple
            Else
                .DataBindings!text.DataSourceUpdateMode = DataSourceUpdateMode.Never
                .DropDownStyle = ComboBoxStyle.DropDownList
            End If
        End With

        With Me.cboWareHouseEmployeeID
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

        End With

    End Sub
    Private Sub setButtonsForEdit()



    End Sub
    Private Sub ResetButtonAfterEditing()



    End Sub

    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        'This subroutine loads when the Find Vehicle button is pressed

        'Setting Local Variables
        Dim strBJCNumber As String
        Dim intCounter As Integer
        Dim intBJCNumberEntered As Integer
        Dim intBJCNumberFromTable As Integer
        Dim blnToolIDNotFound As Boolean

        'Setting initial conditions
        btnIDBack.Enabled = False
        btnIDNext.Enabled = False

        'Setting Local Variables for validation
        blnToolIDNotFound = True

        mblnFatalError = False
        strBJCNumber = CStr(txtBJCNumberForSearching.Text)
        mblnFatalError = TheInputDataValidation.VerifyIntegerData(strBJCNumber)

        If mblnFatalError = True Then
            MessageBox.Show("BJC Number Entered is not an Integer", "Please correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intBJCNumberEntered = CInt(txtBJCNumberForSearching.Text)
        mintCounter = 0

        For intCounter = 0 To mintUpperLimit

            cboTransactionID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtHistoryBJCNumber.Text)

            If intBJCNumberEntered = intBJCNumberFromTable Then

                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                blnToolIDNotFound = False

            End If

        Next

        If blnToolIDNotFound = False Then
            btnHistoryBack.Enabled = False
            btnHistoryNext.Enabled = False
        Else
            MessageBox.Show("Tool ID Entered is Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        mintSearchUpperLimit = mintCounter
        mintCounter = 0

        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWarehouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)

        If mintSearchUpperLimit > 1 Then
            btnIDNext.Enabled = True
        End If

        txtBJCNumberForSearching.Text = ""

    End Sub

    Private Sub btnSearchByEmployeeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeID.Click

        'Setting Local Variables
        Dim intCounter As Integer
        Dim intEmployeeIDEntered As Integer
        Dim intEmployeeIDFromTable As Integer
        Dim blnEmployeeIDNotFound As Boolean

        'Setting initial conditions
        btnIDNext.Enabled = False
        btnIDBack.Enabled = False
        Dim strEmployeeID As String

        strEmployeeID = CStr(txtSearchEmployeeID.Text)
        mblnFatalError = False
        mblnFatalError = TheInputDataValidation.VerifyIntegerData(strEmployeeID)

        If mblnFatalError = True Then
            MessageBox.Show("Employee ID Entered is not an Integer", "Please correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intEmployeeIDEntered = CInt(txtSearchEmployeeID.Text)
        mintCounter = 0

        For intCounter = 0 To mintUpperLimit

            cboTransactionID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(txtHistoryEmployeeID.Text)

            If intEmployeeIDEntered = intEmployeeIDFromTable Then

                mintSelectedIndex(mintCounter) = intCounter
                mintCounter = mintCounter + 1
                blnEmployeeIDNotFound = False

            End If

        Next

        If blnEmployeeIDNotFound = False Then
            btnHistoryBack.Enabled = False
            btnHistoryNext.Enabled = False
        Else
            MessageBox.Show("Employee ID Entered is Not Found", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        mintSearchUpperLimit = mintCounter - 1
        mintCounter = 0

        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)
        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWarehouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)

        If mintSearchUpperLimit > 1 Then
            btnIDNext.Enabled = True
        End If

        txtSearchEmployeeID.Text = ""

    End Sub

    Private Sub SetControlsReadOnly()

        'This sets the TextBoxes to ReadOnly

        'This sets Readonly for the employee area
        txtFirstName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtPhoneNumber.ReadOnly = True

        'This sets Readonly for the Warehouse Employee
        txtWarehouseFirstName.ReadOnly = True
        txtWarehouselastName.ReadOnly = True
        txtWarehousePhoneNumber.ReadOnly = True

        'This sets the History Transaction Textboxes to Readonly
        txtHistoryVehicleId.ReadOnly = True
        txtHistoryDate.ReadOnly = True
        txtHistoryEmployeeID.ReadOnly = True
        txtHistoryNotes.ReadOnly = True
        txtHistoryBJCNumber.ReadOnly = True
        txtHistoryWarehouseEmployeeID.ReadOnly = True
        txtHistoryRemoteVehicle.ReadOnly = True

        'This sets the Tool Textboxes to Readonly
        txtVehicleBJCNumber.ReadOnly = True
        txtVehicleYear.ReadOnly = True
        txtVehicleMake.ReadOnly = True
        txtVehicleModel.ReadOnly = True
        txtVehicleLicencePlate.ReadOnly = True
        txtVehicleEmployeeID.ReadOnly = True
        txtVehicleDate.ReadOnly = True
        txtVehicleNotes.ReadOnly = True
        txtVehicleActive.ReadOnly = True
        txtVehiclelAvailable.ReadOnly = True

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

    Private Sub FindWarehouseEmployeeID(ByVal intEmployeeID As Integer)

        'Setting Local Variables
        Dim intEmployeeIDFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboWareHouseEmployeeID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboWareHouseEmployeeID.SelectedIndex = intCounter
            intEmployeeIDFromTable = CInt(cboWareHouseEmployeeID.Text)

            If intEmployeeIDFromTable = intEmployeeID Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboWareHouseEmployeeID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub

    Private Sub btnHistoryNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryNext.Click

        'This increments the Next Buttons for History Transaction Searches
        Dim intSelectedIndex As Integer

        intSelectedIndex = cboTransactionID.SelectedIndex
        intSelectedIndex = intSelectedIndex + 1
        cboTransactionID.SelectedIndex = intSelectedIndex

        If intSelectedIndex < mintUpperLimit And intSelectedIndex <> 0 Then
            btnHistoryBack.Enabled = True
        End If

        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)
        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)

        If intSelectedIndex = mintUpperLimit Then
            btnHistoryNext.Enabled = False
        End If

    End Sub

    Private Sub btnHistoryBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryBack.Click

        'This increments the Next Buttons for History Transaction Searches
        Dim intSelectedIndex As Integer

        intSelectedIndex = cboTransactionID.SelectedIndex
        intSelectedIndex = intSelectedIndex - 1
        cboTransactionID.SelectedIndex = intSelectedIndex

        If intSelectedIndex < mintUpperLimit And intSelectedIndex <> mintUpperLimit Then
            btnHistoryNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)
        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)

        If intSelectedIndex = 0 Then
            btnHistoryBack.Enabled = False
        End If
    End Sub
    Private Sub FindBJCNumber(ByVal intBJCNumber As Integer)

        'Setting Local Variables
        Dim intBJCNumberFromTable As Integer
        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim intSelectedIndexFound As Integer

        'Setting the value of the variables
        mblnEmployeeIDFound = False
        intNumberOfRecords = cboVehicleID.Items.Count

        'Performing Compare
        For intCounter = 0 To intNumberOfRecords - 1

            cboVehicleID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)

            If intBJCNumberFromTable = intBJCNumber Then
                mblnEmployeeIDFound = True
                intSelectedIndexFound = intCounter
            End If

        Next

        'Setting Combobox Selected Index
        If mblnEmployeeIDFound = True Then
            cboVehicleID.SelectedIndex = intSelectedIndexFound
        End If

    End Sub

    Private Sub VehicleHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This sub-routine runs when the form is loaded

        'Locks the controls to readonly
        setControlsReadOnly()

        'Try - Catch for the History
        Try
            'This will bind the controls to the data source
            TheVehicleHistoryDataTier = New VehicleHistoryDataTier
            TheVehicleHistoryDataSet = TheVehicleHistoryDataTier.GetVehicleHistoryInformation
            TheVehicleHistoryBindingSource = New BindingSource

            'Setting the binding for the combo box
            With TheVehicleHistoryBindingSource
                .DataSource = TheVehicleHistoryDataSet
                .DataMember = "vehiclehistory"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding for the combo box
            With cboTransactionID
                .DataSource = TheVehicleHistoryBindingSource
                .DisplayMember = "TransactionID"
                .DataBindings.Add("text", TheVehicleHistoryBindingSource, "TransactionID", False, DataSourceUpdateMode.Never)
            End With

            'Setting the binding for all other textbox controls
            txtHistoryEmployeeID.DataBindings.Add("text", TheVehicleHistoryBindingSource, "EmployeeID")
            txtHistoryDate.DataBindings.Add("text", TheVehicleHistoryBindingSource, "Date")
            txtHistoryNotes.DataBindings.Add("text", TheVehicleHistoryBindingSource, "Notes")
            txtHistoryBJCNumber.DataBindings.Add("text", TheVehicleHistoryBindingSource, "BJCNumber")
            txtHistoryWarehouseEmployeeID.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "WarehouseEmployeeID")
            txtHistoryVehicleId.DataBindings.Add("Text", TheVehicleHistoryBindingSource, "VehicleID")
            txtHistoryRemoteVehicle.DataBindings.Add("text", TheVehicleHistoryBindingSource, "RemoteVehicle")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Try - Catch for Employee and Warehouse Employee
        Try
            'This will bind the controls to the data source
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource
            TheWarehouseEmployeeBindingSource = New BindingSource

            'Setting up Binding Source for the Combo Box
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'Setting up Binding Source for the Combo Box
            With TheWarehouseEmployeeBindingSource
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

            With cboWareHouseEmployeeID
                .DataSource = TheWarehouseEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With


            'Setting the data binding for the text boxes
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtPhoneNumber.DataBindings.Add("text", TheEmployeeBindingSource, "PhoneNumber")

            'Setting the data binding for the text boxes
            txtWarehouseFirstName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "FirstName")
            txtWarehouselastName.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "LastName")
            txtWarehousePhoneNumber.DataBindings.Add("text", TheWarehouseEmployeeBindingSource, "PhoneNumber")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try - Catch for Vehicles
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
                .DisplayMember = "VehicleId"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtVehicleYear.DataBindings.Add("text", TheVehiclesBindingSource, "Year")
            txtVehicleMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtVehicleModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")
            txtVehicleLicencePlate.DataBindings.Add("text", TheVehiclesBindingSource, "LicencePlate")
            txtVehicleEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtVehicleDate.DataBindings.Add("text", TheVehiclesBindingSource, "Date")
            txtVehicleNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")
            txtVehicleActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehiclelAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        mintUpperLimit = cboTransactionID.Items.Count - 1
        mintCounter = 0
        cboTransactionID.SelectedIndex = 0

        If mintUpperLimit > 1 Then
            btnHistoryNext.Enabled = True
        End If

        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWarehouseEmployeeID.Text)
        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)

    End Sub

    Private Sub btnResetNavagation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetNavagation.Click

        'This sub-routine resets the navagation

        btnIDBack.Enabled = False
        btnIDNext.Enabled = False

        cboTransactionID.SelectedIndex = 0

        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)


        If mintUpperLimit > 1 Then
            btnHistoryNext.Enabled = True
        End If


    End Sub
    Private Sub btnIDNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDNext.Click


        'This Routine will run the Next Buttons
        mintCounter = mintCounter + 1
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)
        btnIDBack.Enabled = True


        If mintCounter = mintSearchUpperLimit Then
            btnIDNext.Enabled = False

        End If


        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)



    End Sub

    Private Sub btnIDBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDBack.Click

        'This Routine will run the Next Buttons
        mintCounter = mintCounter - 1
        cboTransactionID.SelectedIndex = mintSelectedIndex(mintCounter)



        If mintCounter < mintSearchUpperLimit Then
            btnIDNext.Enabled = True

        End If
        If mintCounter = 0 Then
            btnIDBack.Enabled = False
        End If


        mintBJCNumber = CInt(txtHistoryBJCNumber.Text)
        mintEmployeeID = CInt(txtHistoryEmployeeID.Text)
        mintWarehouseID = CInt(txtHistoryWareHouseEmployeeID.Text)

        FindEmployeeID(mintEmployeeID)
        FindWarehouseEmployeeID(mintWarehouseID)
        FindBJCNumber(mintBJCNumber)

    End Sub


    Private Sub txtBJCNumberForSearching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberForSearching.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindVehicle.PerformClick()
            txtSearchEmployeeID.focus
        End If

    End Sub

    Private Sub btnSearchByEmployeeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByEmployeeName.Click
        'This will search for the Employee by name

        Dim strFirstNameEntered As String
        Dim strLastNameEntered As String
        Dim strFirstNameFromTable As String
        Dim strLastNameFromTable As String
        Dim blnFatalErrors As Boolean
        Dim strErrorMessage As String
        Dim intEmployeeIDFromSearch As Integer
        Dim intCounter As Integer
        Dim intEmployeeIDUpperLevel As Integer
        Dim blnEmployeeFound As Boolean

        'Setting Data Validation Variables
        blnFatalErrors = False
        strErrorMessage = ""
        blnEmployeeFound = False



        If txtSearchLastName.Text = "" Then
            blnFatalErrors = True
            strErrorMessage = strErrorMessage + "The Last Name For Searching was not entered" + vbNewLine
        End If
        If txtSearchFirstName.Text = "" Then
            blnFatalErrors = True
            strErrorMessage = strErrorMessage + "The First Name for Searching was not Entered" + vbNewLine
        End If

        If blnFatalErrors = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strFirstNameEntered = txtSearchFirstName.Text
        strLastNameEntered = txtSearchLastName.Text

        intEmployeeIDUpperLevel = cboEmployeeID.Items.Count - 1

        For intCounter = 0 To intEmployeeIDUpperLevel

            cboEmployeeID.SelectedIndex = intCounter
            strLastNameFromTable = txtLastName.Text
            strFirstNameFromTable = txtFirstName.Text

            If strLastNameEntered = strLastNameFromTable Then
                If strFirstNameEntered = strFirstNameFromTable Then

                    intEmployeeIDFromSearch = CInt(cboEmployeeID.Text)
                    blnEmployeeFound = True

                End If
            End If

        Next

        If blnEmployeeFound = False Then
            MessageBox.Show("The Employee Name Entered does not Exist", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        txtSearchEmployeeID.Text = CStr(intEmployeeIDFromSearch)
        btnSearchByEmployeeID.PerformClick()
        txtSearchEmployeeID.Text = ""
        txtSearchFirstName.Text = ""
        txtSearchLastName.Text = ""

    End Sub

    Private Sub RemoveDataBindings()

        'Removing History Databindings
        cboTransactionID.DataBindings.Clear()
        txtHistoryBJCNumber.DataBindings.Clear()
        txtHistoryDate.DataBindings.Clear()
        txtHistoryEmployeeID.DataBindings.Clear()
        txtHistoryNotes.DataBindings.Clear()
        txtHistoryVehicleId.DataBindings.Clear()
        txtHistoryWarehouseEmployeeID.DataBindings.Clear()

        'Clears Vehicle Databindings
        cboVehicleID.DataBindings.Clear()
        txtVehicleActive.DataBindings.Clear()
        txtVehicleBJCNumber.DataBindings.Clear()
        txtVehicleDate.DataBindings.Clear()
        txtVehicleEmployeeID.DataBindings.Clear()
        txtVehiclelAvailable.DataBindings.Clear()
        txtVehicleLicencePlate.DataBindings.Clear()
        txtVehicleMake.DataBindings.Clear()
        txtVehicleModel.DataBindings.Clear()
        txtVehicleNotes.DataBindings.Clear()
        txtVehicleYear.DataBindings.Clear()

        'Clears Employee and Warehouse employee databindings
        cboEmployeeID.DataBindings.Clear()
        cboWareHouseEmployeeID.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtFirstName.DataBindings.Clear()
        txtPhoneNumber.DataBindings.Clear()
        txtWarehouseFirstName.DataBindings.Clear()
        txtWarehouselastName.DataBindings.Clear()
        txtWarehousePhoneNumber.DataBindings.Clear()


    End Sub

    Private Sub txtSearchEmployeeID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchEmployeeID.KeyDown

        If e.KeyCode = Keys.Return Then
            btnSearchByEmployeeID.PerformClick()
        End If

    End Sub


    Private Sub txtSearchLastName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchLastName.KeyDown

        If e.KeyCode = Keys.Return Then
            txtSearchFirstName.Focus()
        End If

    End Sub


    Private Sub txtSearchFirstName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFirstName.KeyDown

        If e.KeyCode = Keys.Return Then
            btnSearchByEmployeeName.PerformClick()
        End If

    End Sub
End Class