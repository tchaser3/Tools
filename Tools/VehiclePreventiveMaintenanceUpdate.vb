'Title:         Vehicle Preventive Maintenance Update
'Date:          10-31-14
'Author:        Terry Holmes

'Description:   This form is used to update the vehicle odometer and oil change date

Option Strict On

Public Class VehiclePreventiveMaintenanceUpdate

    Private TheVehiclesDataSet As VehiclesDataSet
    Private TheVehiclesDataTier As VehiclesDataTier
    Private WithEvents TheVehiclesBindingSource As BindingSource

    Private addingBoolean As Boolean = False
    Private editingBoolean As Boolean = False

    Dim mstrFormForDataEntry As String = "CURRENT"
    Dim mintBJCNumber As Integer

    Dim mintCounter As Integer
    Dim mintUpperLimit As Integer
    Dim mintSelectedIndex(1000) As Integer

    Dim TheInputDataValidation As New InputDataValidation

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Closes the Program

        If Logon.mstrFormForDataEntry = "CURRENT" Then
            CloseTheProgram.ShowDialog()

        Else
            ClearDataBindings()
            Logon.mintBJCNumber = mintBJCNumber
            Logon.mblnOilChangeDate = True
            WeeklyVehicleInspections.Show()
            Me.Close()
        End If


    End Sub

    Private Sub btnInspectionMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInspectionMenu.Click

        'Opens the Inspection Menu
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

    Private Sub btnMaintenanceMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaintenanceMenu.Click

        'This will open the Maintenance Menu
        ClearDataBindings()
        MaintenanceMenu.Show()
        Me.Close()

    End Sub
    Private Sub ClearDataBindings()

        'This will clear the data bindings
        cboVehicleID.DataBindings.Clear()
        txtBJCNumberEntered.DataBindings.Clear()
        txtActive.DataBindings.Clear()
        txtLastOilChangeDate.DataBindings.Clear()
        txtLastOilChangeOdometer.DataBindings.Clear()

    End Sub

    Private Sub VehiclePreventiveMaintenanceUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This will load up the controls

        'Try Catch to to load up the controls
        Try
            'Setting up the controls
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

            'Setting the rest of the controls
            txtActive.DataBindings.Add("text", TheVehiclesBindingSource, "Active")
            txtVehicleBJCNumber.DataBindings.Add("text", TheVehiclesBindingSource, "BJCNumber")
            txtLastOilChangeDate.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeDate")
            txtLastOilChangeOdometer.DataBindings.Add("text", TheVehiclesBindingSource, "LastOilChangeOdometer")

            FindActiveVehicles()
            SetControlsVisible(False)

            If Logon.mstrFormForDataEntry = "WEEKLYINSPECTION" Then
                mstrFormForDataEntry = "WEEKLYINSPECTION"
                btnInspectionMenu.Enabled = False
                btnMainMenu.Enabled = False
                btnMaintenanceMenu.Enabled = False
                mintBJCNumber = Logon.mintBJCNumber
                txtBJCNumberEntered.Text = CStr(mintBJCNumber)
                btnFindVehicle.PerformClick()
            Else
                btnInspectionMenu.Enabled = True
                btnMainMenu.Enabled = True
                btnMaintenanceMenu.Enabled = True
            End If

        Catch ex As Exception

            'A message box will be display if the proceedure throughs an exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub SetControlsVisible(ByVal valueBoolean As Boolean)

        'This will make the controls visible
        txtActive.Visible = valueBoolean
        txtLastOilChangeDate.Visible = valueBoolean
        txtLastOilChangeOdometer.Visible = valueBoolean
        txtVehicleBJCNumber.Visible = valueBoolean

    End Sub
    Private Sub FindActiveVehicles()

        Dim intCounter As Integer
        Dim intNumberOfRecords As Integer
        Dim strActiveFromTable As String

        'Setting up initial load
        intNumberOfRecords = cboVehicleID.Items.Count - 1
        mintCounter = 0
        mintUpperLimit = 0

        'Beginning Loop
        For intCounter = 0 To intNumberOfRecords

            'Incrementing the combo box 
            cboVehicleID.SelectedIndex = intCounter
            strActiveFromTable = txtActive.Text

            'If statement to preset the array
            If strActiveFromTable = "YES" Then
                mintSelectedIndex(mintCounter) = intCounter
                mintCounter += 1
            End If
        Next

        'Setting up global variables
        mintUpperLimit = mintCounter - 1
        mintCounter = 0

        'Setting the combo box
        cboVehicleID.SelectedIndex = mintSelectedIndex(0)

    End Sub

    Private Sub btnFindVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVehicle.Click

        'This will run and find the vehicle
        Dim intCounter As Integer
        Dim intSelectedIndex As Integer
        Dim blnBJCNumberNotFound As Boolean = True
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean
        Dim intBJCNumberForSearch As Integer
        Dim intBJCNumberFromTable As Integer

        'Running Validation on entry
        strValueForValidation = txtBJCNumberEntered.Text
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)

        'Checking to see if there is a validation error
        If blnFatalError = True Then
            txtBJCNumberEntered.Text = ""
            MessageBox.Show("BJC Number Entered is not an Integer", "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SetControlsVisible(True)
        intBJCNumberForSearch = CInt(txtBJCNumberEntered.Text)

        'Beginning loop
        For intCounter = 0 To mintUpperLimit

            'Incrementing the combo box
            cboVehicleID.SelectedIndex = mintSelectedIndex(intCounter)
            intBJCNumberFromTable = CInt(txtVehicleBJCNumber.Text)

            'IF Statement to determine if the vehicle was found
            If intBJCNumberForSearch = intBJCNumberFromTable Then
                intSelectedIndex = intCounter
                blnBJCNumberNotFound = False
            End If

        Next

        'If statement to determing if vehicle was found
        If blnBJCNumberNotFound = True Then
            txtBJCNumberEntered.Text = ""
            SetControlsVisible(False)
            MessageBox.Show("Vehicle Not Found or Not Active", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        mintBJCNumber = intBJCNumberForSearch

        'Setting the combo box
        cboVehicleID.SelectedIndex = mintSelectedIndex(intSelectedIndex)
        btnUpdateVehicle.Enabled = True

    End Sub

    Private Sub btnUpdateVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateVehicle.Click

        'This will validate the data and update the data set
        Dim strValueForValidation As String
        Dim blnFatalError As Boolean = False
        Dim strErrorMessage As String

        'Beginning Data Validation
        strValueForValidation = txtLastOilChangeOdometer.Text
        strErrorMessage = "Last Oil Change Odometer is not an Integer"
        blnFatalError = TheInputDataValidation.VerifyIntegerData(strValueForValidation)
        If blnFatalError = False Then
            strValueForValidation = txtLastOilChangeDate.Text
            strErrorMessage = "The Last Oil Change Date is not a Date"
            blnFatalError = TheInputDataValidation.VerifyStartingEndingDatesAsDates(strValueForValidation)
        End If

        'validation output to user
        If blnFatalError = True Then
            MessageBox.Show(strErrorMessage, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Loading up variables for creating a preventive work order
        Logon.mintVehicleID = CInt(cboVehicleID.Text)
        Logon.mintOdometerTransferred = CInt(txtLastOilChangeOdometer.Text)
        Logon.mdatStartingDate = CDate(txtLastOilChangeDate.Text)

        'Try Catch to update the vehicle table
        Try
            TheVehiclesBindingSource.EndEdit()
            TheVehiclesDataTier.UpdateDB(TheVehiclesDataSet)
            btnUpdateVehicle.Enabled = False
            SetControlsVisible(False)
            MessageBox.Show("The Vehicle Has Been Updated", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtBJCNumberEntered.Text = ""
            CreateVehiclePreventiveMaintenanceWorkOrder.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Please Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class