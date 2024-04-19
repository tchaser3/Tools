'Title:     Create Vehicles
'Date:      7/12/13
'Author:    Terry Holmes

'Description:   This is used to create new vehicles

'Update:        10-9-15 - Added the Home Office to the form

Option Strict On

Public Class CreateVehicle

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private TheEmployeeDataSet As EmployeeDataSet
    Private TheEmployeeDataTier As EmployeeDataTier
    Private WithEvents TheEmployeeBindingSource As BindingSource

    Dim TheInputDataValidation As New InputDataValidation

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False
    Private previousSelectedIndex As Integer
    Dim mintNumuberOfRecords As Integer

    Dim LogDateTime As Date = DateAndTime.Now
    Dim strLogDateTime As String
    Friend mintCreatedVehicleID As Integer

    'Array for Vehicle Selected Index
    Dim mintVehicleSelectedIndex() As Integer
    Dim mintVehicleUpperLimit As Integer
    Dim mintVehicleCounter As Integer

    'Array for Employee Selected Index
    Dim mintEmployeeSelectedIndex() As Integer
    Dim mintEmployeeUpperLimit As Integer
    Dim mintEmployeeCounter As Integer

    Friend mintBJCNumberForSearching As Integer

    Private Sub CreateVehicle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Setting local variables
        Dim intNumberOfRecords As Integer
        Dim intCounter As Integer
        Dim strLastNameForSearch As String
        Dim strLastNameFromTable As String

        'This routine runs during form load
        Try
            'This will bind the controls to the data source
            TheVehiclesDataTier = New VehiclesDataTier
            TheVehiclesDataSet = TheVehiclesDataTier.GetVehiclesInformation
            TheVehiclesBindingSource = New BindingSource

            With TheVehiclesBindingSource
                .DataSource = TheVehiclesDataSet
                .DataMember = "vehicles"
                .MoveFirst()
                .MoveLast()
            End With

            'Binding controls to for the binding source
            With cboVehicleID
                .DataSource = TheVehiclesBindingSource
                .DisplayMember = "VehicleID"
                .DataBindings.Add("text", TheVehiclesBindingSource, "VehicleID", False, DataSourceUpdateMode.Never)
            End With

            txtEmployeeID.DataBindings.Add("text", TheVehiclesBindingSource, "EmployeeID")
            txtDate.DataBindings.Add("text", TheVehiclesBindingSource, "Date")
            txtLicensePlate.DataBindings.Add("text", TheVehiclesBindingSource, "LicencePlate")
            txtBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtYear.DataBindings.Add("text", TheVehiclesBindingSource, "Year")
            txtAvailable.DataBindings.Add("text", TheVehiclesBindingSource, "Available")
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtNotes.DataBindings.Add("text", TheVehiclesBindingSource, "Notes")
            txtMake.DataBindings.Add("text", TheVehiclesBindingSource, "Make")
            txtModel.DataBindings.Add("text", TheVehiclesBindingSource, "Model")
            txtStartingOdometer.DataBindings.Add("text", TheVehiclesBindingSource, "StartingOdometer")
            txtLastOilChangeOdometer.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeOdometer")
            txtTagExpDate.DataBindings.Add("text", TheVehiclesBindingSource, "TagExpDate")
            txtVehicleDownForMaintenance.DataBindings.Add("Text", TheVehiclesBindingSource, "DownForRepairs")
            txtDOTFormRequired.DataBindings.Add("text", TheVehiclesBindingSource, "DOTFormRequired")
            txtOutOfTown.DataBindings.Add("text", TheVehiclesBindingSource, "OutOfTown")
            txtHomeOffice.DataBindings.Add("text", TheVehiclesBindingSource, "HomeOffice")

            intNumberOfRecords = cboVehicleID.Items.Count - 1
            ReDim mintVehicleSelectedIndex(intNumberOfRecords)

            'Loading up for warehouse id
            TheEmployeeDataTier = New EmployeeDataTier
            TheEmployeeDataSet = TheEmployeeDataTier.GetEmployeeInformation
            TheEmployeeBindingSource = New BindingSource

            'setting up the binding source
            With TheEmployeeBindingSource
                .DataSource = TheEmployeeDataSet
                .DataMember = "employees"
                .MoveFirst()
                .MoveLast()
            End With

            'setting up the combo box
            With cboEmployeeID
                .DataSource = TheEmployeeBindingSource
                .DisplayMember = "EmployeeID"
                .DataBindings.Add("text", TheEmployeeBindingSource, "EmployeeID", False, DataSourceUpdateMode.Never)
            End With

            'Setting up the rest of the controls
            txtLastName.DataBindings.Add("text", TheEmployeeBindingSource, "LastName")
            txtFirstName.DataBindings.Add("text", TheEmployeeBindingSource, "FirstName")

            'setting up for the array
            intNumberOfRecords = cboEmployeeID.Items.Count - 1
            ReDim mintEmployeeSelectedIndex(intNumberOfRecords)
            strLastNameForSearch = "WAREHOUSE"
            mintEmployeeCounter = 0

            'running loop
            For intCounter = 0 To intNumberOfRecords

                'incrementing the combo box
                cboEmployeeID.SelectedIndex = intCounter

                'getting the last name
                strLastNameFromTable = txtLastName.Text.ToString.ToUpper

                'if statements
                If strLastNameForSearch = strLastNameFromTable Then
                    mintEmployeeSelectedIndex(mintEmployeeCounter) = intCounter
                    mintEmployeeCounter += 1
                End If

            Next

            'finishing up
            mintEmployeeUpperLimit = mintEmployeeCounter - 1
            mintEmployeeCounter = 0
            cboEmployeeID.SelectedIndex = mintEmployeeSelectedIndex(0)

            If mintEmployeeUpperLimit > 0 Then
                btnEmployeeNext.Enabled = True
            End If

            setControlsReadOnly(True)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program
        CloseTheProgram.ShowDialog()

    End Sub

    Private Sub btnAdministrativeMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdministrativeMenu.Click
        AdministrativeMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click
        MainMenu.Show()
        Me.Close()
    End Sub
    Private Sub setComboBoxBinding()
        With Me.cboVehicleID
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
        txtBJCNumber.ReadOnly = valueBoolean
        txtYear.ReadOnly = valueBoolean
        txtMake.ReadOnly = valueBoolean
        txtModel.ReadOnly = valueBoolean
        txtLicensePlate.ReadOnly = valueBoolean
        txtEmployeeID.ReadOnly = valueBoolean
        txtDate.ReadOnly = valueBoolean
        txtNotes.ReadOnly = valueBoolean
        txtAvailable.ReadOnly = valueBoolean
        txtActive.ReadOnly = valueBoolean
        txtStartingOdometer.ReadOnly = valueBoolean
        txtLastOilChangeOdometer.ReadOnly = valueBoolean
        txtTagExpDate.ReadOnly = valueBoolean
        txtVehicleDownForMaintenance.ReadOnly = valueBoolean
        txtDOTFormRequired.ReadOnly = valueBoolean
        txtOutOfTown.ReadOnly = valueBoolean
        txtHomeOffice.ReadOnly = valueBoolean

    End Sub
    Private Sub setButtonsForEdit()
        btnAdd.Text = "Save"
        btnEdit.Enabled = False
        btnMainMenu.Enabled = False
    End Sub
    Private Sub ResetButtonAfterEditing()
        btnAdd.Text = "Add"
        btnEdit.Enabled = True
        btnMainMenu.Enabled = True
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'This will add or save a record to the data set

        'Setting local variables
        Dim strErrorMessage As String = ""
        Dim blnFatalError As Boolean = False
        Dim blnThereIsAProblem As Boolean = False
        Dim intNumberOfRecords As Integer
        Dim strValueForValidation As String
        Dim strHomeOffice As String

        'Setting up if statements
        If btnAdd.Text = "Add" Then  'This routine will run if the user is adding a vehicle
            With TheVehiclesBindingSource
                .EndEdit()
                .AddNew()
            End With
            addingBoolean = True
            setComboBoxBinding()
            cboVehicleID.Focus()
            setControlsReadOnly(False)
            setButtonsForEdit()
            If cboVehicleID.SelectedIndex <> -1 Then
                previousSelectedIndex = cboVehicleID.Items.Count - 1
            Else
                previousSelectedIndex = 0
            End If

            'Setting up fields with auto-data to avoid having the user do it.
            mintNumuberOfRecords = cboVehicleID.Items.Count
            intNumberOfRecords = mintNumuberOfRecords + 1000
            mintCreatedVehicleID = intNumberOfRecords

            VehicleIDCheck.Show()

            strHomeOffice = Logon.mstrHomeOffice

            txtEmployeeID.Text = CStr(Logon.mintWarehouseID)

            cboVehicleID.Text = CStr(Logon.mintVehicleID)
            txtActive.Text = "YES"
            txtAvailable.Text = "YES"
            txtOutOfTown.Text = "NO"
            strLogDateTime = CStr(LogDateTime)
            txtDate.Text = strLogDateTime
            txtEmployeeID.ReadOnly = True
            btnEmployeeSelect.Enabled = True

        Else

            'Performing Data Validation
            strErrorMessage = ""
            blnFatalError = False

            strValueForValidation = txtBJCNumber.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The BJC Number is not an Integer" + vbNewLine
            End If

            strValueForValidation = txtYear.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Value for Year is not an Integer" + vbNewLine
            Else
                blnFatalError = TheInputDataValidation.VerifyYear(strValueForValidation)
                If blnFatalError = True Then
                    blnThereIsAProblem = True
                    strErrorMessage = strErrorMessage + "The Year is out of Range" + vbNewLine
                End If
            End If

            strValueForValidation = txtMake.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Make was not Entered" + vbNewLine
            End If

            strValueForValidation = txtModel.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Model was not Entered" + vbNewLine
            End If

            strValueForValidation = txtHomeOffice.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Home Office was not Entered" + vbNewLine
            End If

            strValueForValidation = txtLicensePlate.Text
            blnFatalError = TheInputDataValidation.VerifyTextData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The License Plate was not Entered" + vbNewLine
            End If

            strValueForValidation = txtStartingOdometer.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Starting Odometer Reading is not an Integer" + vbNewLine
            End If

            strValueForValidation = txtLastOilChangeOdometer.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Last Oil Change Odometer is not an Integer" + vbNewLine
            End If

            strValueForValidation = txtEmployeeID.Text
            blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Employee ID is not an Integer" + vbNewLine
            End If

            strValueForValidation = txtDate.Text
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "The Date is not the Correct Format" + vbNewLine
            End If

            strValueForValidation = txtActive.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Active is not a Yes or No" + vbNewLine
            End If

            strValueForValidation = txtAvailable.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Available is not a Yes or No" + vbNewLine
            End If

            strValueForValidation = txtVehicleDownForMaintenance.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Vehicle Down For Maintenance is not a Yes or No" + vbNewLine
            End If

            strValueForValidation = txtOutOfTown.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "Out of Town is not a Yes or No" + vbNewLine
            End If

            strValueForValidation = txtDOTFormRequired.Text
            blnFatalError = TheInputDataValidation.VerifyYesNoData(strValueForValidation)
            If blnFatalError = True Then
                blnThereIsAProblem = True
                strErrorMessage = strErrorMessage + "DOT Form Required is not a Yes or No" + vbNewLine
            End If

            If blnThereIsAProblem = True Then
                MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Updating Database
            Try
                TheVehiclesBindingSource.EndEdit()
                TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)
                addingBoolean = False
                editingBoolean = False
                setControlsReadOnly(True)
                ResetButtonAfterEditing()
                setComboBoxBinding()
                cboVehicleID.SelectedIndex = previousSelectedIndex
                btnEmployeeSelect.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.Message, "There is an Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setControlsReadOnly(False)
        setButtonsForEdit()
        previousSelectedIndex = cboVehicleID.SelectedIndex
        setComboBoxBinding()
        txtEmployeeID.ReadOnly = True
        btnEmployeeSelect.Enabled = True
    End Sub

    
    Private Sub btnSearchForNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchForNumber.Click

        'This sub routine will search for a specific BJC Number
        Dim blnFatalError As Boolean
        Dim strValueForValidation As String
        Dim blnBJCNumberNotFound As Boolean = True
        Dim intNumberOfRecords As Integer
        Dim intBJCNumberFromTable As Integer

        btnBack.Enabled = False
        btnNext.Enabled = False

        strValueForValidation = txtBJCNumberForSearching.Text

        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        If blnFatalError = True Then
            MessageBox.Show("The BJC Number is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        mintBJCNumberForSearching = CInt(strValueForValidation)
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        mintVehicleCounter = 0

        For intCounter = 0 To intNumberOfRecords
            cboVehicleID.SelectedIndex = intCounter
            intBJCNumberFromTable = CInt(txtBJCNumber.Text)
            If intBJCNumberFromTable = mintBJCNumberForSearching Then

                mintVehicleSelectedIndex(mintVehicleCounter) = intCounter
                mintVehicleCounter += 1
                blnBJCNumberNotFound = False

            End If


        Next

        If blnBJCNumberNotFound = True Then

            MessageBox.Show("The BJC Number entered was not found", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBJCNumberForSearching.Text = ""
            Exit Sub

        End If

        mintVehicleUpperLimit = mintVehicleCounter - 1
        mintVehicleCounter = 0
        cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(0)

        If mintVehicleUpperLimit > 0 Then

            btnNext.Enabled = True

        End If

        txtBJCNumberForSearching.Text = ""

    End Sub

    Private Sub txtBJCNumberForSearching_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBJCNumberForSearching.KeyDown

        If e.KeyCode = Keys.Enter Then

            btnSearchForNumber.PerformClick()

        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        mintVehicleCounter = mintVehicleCounter + 1

        cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(mintVehicleCounter)

        btnBack.Enabled = True

        If mintVehicleCounter = mintVehicleUpperLimit Then
            btnNext.Enabled = False
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        mintVehicleCounter -= 1

        cboVehicleID.SelectedIndex = mintVehicleSelectedIndex(mintVehicleCounter)

        btnNext.Enabled = True

        If mintVehicleCounter = 0 Then
            btnBack.Enabled = False
        End If

    End Sub

    Private Sub btnEmployeeNext_Click(sender As Object, e As EventArgs) Handles btnEmployeeNext.Click

        'incrementing the combo
        mintEmployeeCounter += 1
        cboEmployeeID.SelectedIndex = mintEmployeeSelectedIndex(mintEmployeeCounter)

        'setting up the navigation control
        btnEmployeeBack.Enabled = True

        If mintEmployeeCounter = mintEmployeeUpperLimit Then
            btnEmployeeNext.Enabled = False
        End If

    End Sub

    Private Sub btnEmployeeBack_Click(sender As Object, e As EventArgs) Handles btnEmployeeBack.Click

        'incrementing the combo
        mintEmployeeCounter -= 1
        cboEmployeeID.SelectedIndex = mintEmployeeSelectedIndex(mintEmployeeCounter)

        'setting up the navigation control
        btnEmployeeNext.Enabled = True

        If mintEmployeeCounter = 0 Then
            btnEmployeeBack.Enabled = False
        End If

    End Sub

    Private Sub btnEmployeeSelect_Click(sender As Object, e As EventArgs) Handles btnEmployeeSelect.Click

        'This will load the control
        txtHomeOffice.Text = txtFirstName.Text

    End Sub
End Class